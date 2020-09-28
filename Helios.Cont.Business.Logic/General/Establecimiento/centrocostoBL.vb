Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Logic
Imports Helios.Seguridad.Business.Entity

Public Class centrocostoBL
    Inherits BaseBL

    Public Function InsertEstablecimiento(estableBE As centrocosto) As Integer
        Dim AlmacenVR As New almacen
        Try
            Using ts As New TransactionScope
                Insert(estableBE)
                ' HeliosData.centrocosto.Add(estableBE)
                With AlmacenVR
                    .idEstablecimiento = estableBE.idCentroCosto
                    .idEmpresa = estableBE.idEmpresa
                    .descripcionAlmacen = "EN TRANSITO"
                    .tipo = "AV"
                    .estado = "S"
                    .usuarioModificacion = estableBE.usuarioActualizacion
                    .fechaModificacion = estableBE.fechaActualizacion
                End With
                HeliosData.almacen.Add(AlmacenVR)
                HeliosData.SaveChanges()
                ts.Complete()
                Return estableBE.idCentroCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Insert(estableBE As centrocosto) As Integer
        Dim AlmacenVR As New almacen
        Try
            Using ts As New TransactionScope
                HeliosData.centrocosto.Add(estableBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return estableBE.idCentroCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetObtenerEstablecimiento(strEmpresa As String) As List(Of centrocosto)
        Return (From a In HeliosData.centrocosto Where a.idEmpresa = strEmpresa Select a).ToList
    End Function

    Public Function GetObtenerEstablecimientoPorID(intIdEstable As Integer) As centrocosto
        Return (From a In HeliosData.centrocosto Where a.idCentroCosto = intIdEstable Select a).First
    End Function

#Region "transporte"
    Public Sub ChangeEstatusAgencia(obj As centrocosto)
        Dim agencias = HeliosData.centrocosto.Where(Function(o) o.idCentroCosto = obj.idCentroCosto).SingleOrDefault
        Try
            If agencias.predeterminada = True Then
                Throw New Exception("Debe cambiar otra agencia como predetrminada")
            End If

            Using ts As New TransactionScope
                agencias.TipoEstab = obj.TipoEstab
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub PredeterminarAgencia(estableBE As centrocosto)
        Dim agencias = HeliosData.centrocosto.Where(Function(o) o.idCentroCosto <> estableBE.idCentroCosto).ToList
        Using ts As New TransactionScope
            For Each i In agencias
                i.predeterminada = False
            Next

            Dim agencia = HeliosData.centrocosto.Where(Function(o) o.idCentroCosto = estableBE.idCentroCosto).Single
            agencia.predeterminada = True
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function InsertEstablecimientoSingle(estableBE As centrocosto) As Integer
        Dim AlmacenVR As New almacen
        Try
            Using ts As New TransactionScope
                HeliosData.centrocosto.Add(estableBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return estableBE.idCentroCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


#Region "MUNICIPALIDAD"

    Public Function GrabarCentroCosto(estableBE As centrocosto) As Integer
        Try
            Dim idUnidOrg As Integer
            Using ts As New TransactionScope
                HeliosData.centrocosto.Add(estableBE)
                HeliosData.SaveChanges()
                idUnidOrg = estableBE.idCentroCosto
                ts.Complete()
            End Using
            Return idUnidOrg
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertListaEstablecimiento(estableBE As centrocosto) As List(Of centrocosto)
        Dim AlmacenVR As New almacen
        Dim empresaBL As New empresaBL
        Dim empresaBE As New empresa
        Dim itemSA As New itemBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Dim idUnidOrg As Integer
        Dim cierremensual As New empresaCierreMensual
        Dim AsegurableBL As New AsegurableBL
        Dim asegurables As Seguridad.Business.Entity.Asegurable
        Dim RolBL As New RolBL
        Try

            idUnidOrg = GrabarCentroCosto(estableBE)

            empresaBE.idEmpresa = estableBE.idEmpresa

            empresaBL.InsertarEmpresaUnidadOrganica(empresaBE, idUnidOrg)


            '/////////////////////////////////////  TIPO DE MODULO ////////////////////

            If (estableBE.IDNegocioComercial > 0) Then
                Dim CentroCostosXNegocioBL As New centroCostosXNComercialBL
                Dim CentroCostosXNegocioBE As New centroCostosXNComercial

                CentroCostosXNegocioBE.idCentroCosto = idUnidOrg
                CentroCostosXNegocioBE.idEmpresa = empresaBE.idEmpresa
                CentroCostosXNegocioBE.IdNegocioComercial = estableBE.IDNegocioComercial
                CentroCostosXNegocioBE.EstaAutorizado = "A"
                CentroCostosXNegocioBE.idUsuario = Nothing
                CentroCostosXNegocioBE.usuarioActualizacion = "ADMINISTRADOR"
                CentroCostosXNegocioBE.fechaActualizacion = Date.Now

                CentroCostosXNegocioBL.GetInsertarcentroCostosXNComercial(CentroCostosXNegocioBE)
            End If

            '////////////////////////////////
            Dim SeguridadproductoBL As New Seguridad.Business.Logic.productoDetalleBL
            Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(39)

            If ProductoAquirido.Count > 0 Then
                For Each s In ProductoAquirido
                    asegurables = New Seguridad.Business.Entity.Asegurable
                    asegurables.IDAsegurable = s.IDAsegurable
                    asegurables.IDAsegurablePadre = s.IDAsegurablePadre
                    asegurables.IDEmpresa = estableBE.idEmpresa
                    asegurables.IDEstablecimiento = idUnidOrg 'usuario.IDEstablecimiento  ' - -SE CAMBIO SOLO PARA SUPER ADMINISTRADOR
                    asegurables.Nombre = s.Nombre
                    asegurables.Descripcion = s.Descripcion
                    asegurables.CodRef = s.formulario
                    asegurables.orden = s.orden
                    asegurables.UsuarioActualizacion = "Sistema"
                    asegurables.FechaActualizacion = DateTime.Now
                    AsegurableBL.Insert(asegurables)

                Next

            End If



            '///////////////////////////////

            Dim objetoCat As New item
            With objetoCat
                .tipo = "H"
                .idEmpresa = estableBE.idEmpresa
                .idEstablecimiento = idUnidOrg
                .descripcion = "SIN CLASIFICACION"
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .preciocompratipo = "NN"
                .usuarioActualizacion = "ADMINISTRADOR"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codCatx As Integer = itemSA.Insert(objetoCat)

            Dim objeto As New item
            With objeto
                .idPadre = codCatx
                .tipo = TipoGrupoArticulo.CategoriaGeneral
                .idEmpresa = estableBE.idEmpresa
                .idEstablecimiento = idUnidOrg
                .descripcion = "SIN CATEGORIA"
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .preciocompratipo = "NN"
                .usuarioActualizacion = "ADMINISTRADOR"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.Insert(objeto)

            Dim objeto2 As New item

            With objeto2
                .idPadre = codx
                .tipo = TipoGrupoArticulo.SubCategoriaGeneral
                .idEmpresa = estableBE.idEmpresa
                .idEstablecimiento = idUnidOrg
                .descripcion = "SIN SUBCATEGORIA"
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .preciocompratipo = "NN"
                .usuarioActualizacion = "ADMINISTRADOR"
                .fechaActualizacion = DateTime.Now
            End With


            Dim codxxx As Integer = itemSA.Insert(objeto2)


            Dim objeto3 As New item

            With objeto3
                .idPadre = codxxx
                .tipo = TipoGrupoArticulo.Marca
                .idEmpresa = estableBE.idEmpresa
                .idEstablecimiento = idUnidOrg
                .descripcion = "SIN MARCA"
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .preciocompratipo = "NN"
                .usuarioActualizacion = "ADMINISTRADOR"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx2 As Integer = itemSA.Insertmarca(objeto3)

            Dim objeto4 As New item

            With objeto4
                .idPadre = codx2
                .tipo = TipoGrupoArticulo.Presentacion
                .idEmpresa = estableBE.idEmpresa
                .idEstablecimiento = idUnidOrg
                .descripcion = "SIN PRESENTACION"
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .preciocompratipo = "NN"
                .usuarioActualizacion = "ADMINISTRADOR"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx3 As Integer = itemSA.Insertmarca(objeto4)


            Dim ListaColorTalla As New List(Of tabladetalle)
            Dim tablaDetalleSA As New tabladetalleBL

            Dim objetoTlla As New tabladetalle
            objetoTlla.idtabla = 18
            objetoTlla.codigoDetalle = 1
            objetoTlla.codigoDetalle2 = "N"
            objetoTlla.descripcion = "SIN DETERMINAR"
            objetoTlla.estadodetalle = 1
            objetoTlla.fechaModificacion = DateTime.Now
            objetoTlla.usuarioModificacion = 1
            ListaColorTalla.Add(objetoTlla)

            Dim objetoColor As New tabladetalle
            objetoColor.idtabla = 19
            objetoColor.codigoDetalle = 1
            objetoColor.codigoDetalle2 = "N"
            objetoColor.descripcion = "SIN DETERMINAR"
            objetoColor.estadodetalle = 1
            objetoColor.fechaModificacion = DateTime.Now
            objetoColor.usuarioModificacion = 1
            ListaColorTalla.Add(objetoColor)

            If ListaColorTalla.Count > 0 Then
                tablaDetalleSA.GrabarListaTallaColor(ListaColorTalla)
            End If


            cierremensual = New empresaCierreMensual
            cierremensual.idEmpresa = estableBE.idEmpresa
            cierremensual.idCentroCosto = idUnidOrg
            If (estableBE.inicioOperaciones.Length = 18) Then
                cierremensual.anio = estableBE.inicioOperaciones.Substring(5, 4)
                cierremensual.mes = estableBE.inicioOperaciones.Substring(2, 2)
            ElseIf (estableBE.inicioOperaciones.Length = 19) Then
                cierremensual.anio = estableBE.inicioOperaciones.Substring(6, 4)
                cierremensual.mes = estableBE.inicioOperaciones.Substring(3, 2)
            Else
                cierremensual.anio = estableBE.inicioOperaciones.Substring(6, 4)
                cierremensual.mes = estableBE.inicioOperaciones.Substring(3, 2)
            End If
            cierremensual.status = True
            cierremensual.idDocumento = 0
            cierremensual.tipoCierre = statusTipoCierre.AperturaEmpresa
            cierremensual.usuarioActualizacion = "ADMINISTRADOR"
            cierremensual.fechaActualizacion = Date.Now

            empresaCierreMensualBL.EditarEmpresaCierreMensual(cierremensual)

            '///////////////////////////////

            Dim consulta = (From a In HeliosData.centrocosto Where a.idEmpresa = estableBE.idEmpresa Select a).ToList


            Return consulta

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertListaEstablecimientoApoyo(estableBE As centrocosto) As List(Of centrocosto)
        Dim AlmacenVR As New almacen
        Dim empresaBL As New empresaBL
        Dim empresaBE As New empresa
        Dim itemSA As New itemBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Dim idUnidOrg As Integer
        Dim cierremensual As New empresaCierreMensual
        Dim AsegurableBL As New AsegurableBL
        Dim asegurables As Seguridad.Business.Entity.Asegurable
        Dim RolBL As New RolBL
        Dim anioBL As New empresaPeriodoBL
        Try

            'Select Case estableBE.formaControl
            '    Case "COMERCIAL"
            '        idUnidOrg = GrabarCentroCosto(estableBE)
            '        empresaBE.idEmpresa = estableBE.idEmpresa

            '    Case "LOGISTICA"
            '        idUnidOrg = GrabarCentroCosto(estableBE)
            '        empresaBE.idEmpresa = estableBE.idEmpresa

            '    Case "FINANZAS"
            '        idUnidOrg = GrabarCentroCosto(estableBE)
            '        empresaBE.idEmpresa = estableBE.idEmpresa

            '    Case "RR.HH."
            '        idUnidOrg = GrabarCentroCosto(estableBE)
            '        empresaBE.idEmpresa = estableBE.idEmpresa

            '    Case "TICS"
            '        idUnidOrg = GrabarCentroCosto(estableBE)
            '        empresaBE.idEmpresa = estableBE.idEmpresa

            'End Select

            idUnidOrg = GrabarCentroCosto(estableBE)
            empresaBE.idEmpresa = estableBE.idEmpresa

            '//ENTIDAD GRABAR POR UNIDAD DE NEGOCIO
            anioBL.Insert(New empresaPeriodo With
                              {
                                  .idEmpresa = empresaBE.idEmpresa,
                                  .idCentroCosto = idUnidOrg,
                                  .periodo = Date.Now.Year,
                                  .usuarioActualizacion = "1",
                                  .fechaActualizacion = Date.Now
                              })


            '/////////////////////////////////////  TIPO DE MODULO ////////////////////

            If (estableBE.IDNegocioComercial > 0) Then
                Dim CentroCostosXNegocioBL As New centroCostosXNComercialBL
                Dim CentroCostosXNegocioBE As New centroCostosXNComercial

                CentroCostosXNegocioBE.idCentroCosto = idUnidOrg
                CentroCostosXNegocioBE.idEmpresa = empresaBE.idEmpresa
                CentroCostosXNegocioBE.IdNegocioComercial = estableBE.IDNegocioComercial
                CentroCostosXNegocioBE.EstaAutorizado = "A"
                CentroCostosXNegocioBE.idUsuario = Nothing
                CentroCostosXNegocioBE.usuarioActualizacion = "ADMINISTRADOR"
                CentroCostosXNegocioBE.fechaActualizacion = Date.Now

                CentroCostosXNegocioBL.GetInsertarcentroCostosXNComercial(CentroCostosXNegocioBE)
            End If


            '////////////////////////////////
            Dim SeguridadproductoBL As New Seguridad.Business.Logic.productoDetalleBL
            Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(39)

            If ProductoAquirido.Count > 0 Then
                For Each s In ProductoAquirido
                    asegurables = New Seguridad.Business.Entity.Asegurable
                    asegurables.IDAsegurable = s.IDAsegurable
                    asegurables.IDAsegurablePadre = s.IDAsegurablePadre
                    asegurables.IDEmpresa = estableBE.idEmpresa
                    asegurables.IDEstablecimiento = idUnidOrg 'usuario.IDEstablecimiento  ' - -SE CAMBIO SOLO PARA SUPER ADMINISTRADOR
                    asegurables.Nombre = s.Nombre
                    asegurables.Descripcion = s.Descripcion
                    asegurables.CodRef = s.formulario
                    asegurables.orden = s.orden
                    asegurables.UsuarioActualizacion = "Sistema"
                    asegurables.FechaActualizacion = DateTime.Now
                    AsegurableBL.Insert(asegurables)

                Next

            End If


            cierremensual = New empresaCierreMensual
            cierremensual.idEmpresa = estableBE.idEmpresa
            cierremensual.idCentroCosto = idUnidOrg
            cierremensual.anio = Date.Now.Year
            cierremensual.mes = 5
            cierremensual.status = True
            cierremensual.idDocumento = 0
            cierremensual.tipoCierre = statusTipoCierre.AperturaEmpresa
            cierremensual.usuarioActualizacion = "ADMINISTRADOR"
            cierremensual.fechaActualizacion = Date.Now

            empresaCierreMensualBL.EditarEmpresaCierreMensual(cierremensual)

            '///////////////////////////////

            Dim consulta = (From a In HeliosData.centrocosto Where a.idEmpresa = estableBE.idEmpresa Select a).ToList


            Return consulta

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetObtenerUnidadNegocio(IsEstablecimiento As Integer) As List(Of centrocosto)
        Return (From a In HeliosData.centrocosto Where a.idCentroCosto = IsEstablecimiento Select a).ToList
    End Function

    Public Function GetObtenerEstablecimiento2(strEmpresa As String) As List(Of centrocosto)
        Try
            Dim consulta = HeliosData.centrocosto _
                      .Include(Function(lot) lot.jerarquia).ToList


            Dim lista As New List(Of centrocosto)
            Dim listajerarquia As New List(Of jerarquia)

            For Each i In consulta


                Dim objeto As New centrocosto

                objeto.idCentroCosto = i.idCentroCosto
                objeto.idEmpresa = i.idEmpresa
                objeto.nombre = i.nombre
                objeto.TipoEstab = i.TipoEstab
                objeto.ubigeo = i.ubigeo
                objeto.otrasReferencias = i.otrasReferencias
                objeto.idpadre = i.idpadre
                objeto.usuarioActualizacion = i.usuarioActualizacion
                objeto.fechaActualizacion = i.fechaActualizacion

                If i.TipoEstab = "UN" Then

                    If i.jerarquia.Count > 0 Then

                        Dim kistjerar As New List(Of jerarquia)

                        For Each h In i.jerarquia

                            Dim jer As New jerarquia

                            jer.idCentroCosto = h.idCentroCosto
                            jer.nivel = h.nivel
                            jer.descripcion = h.descripcion
                            kistjerar.Add(jer)
                        Next

                        objeto.jerarquia = kistjerar

                    End If


                End If


                lista.Add(objeto)


            Next

            Return lista
        Catch ex As Exception

        End Try


    End Function
#End Region
End Class
