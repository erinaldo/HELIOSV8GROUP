Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class recursoCostoBL
    Inherits BaseBL

    Public Sub CambioEstadoCostoReal(idEntregable As Integer, estadoProy As String)
        Using ts As New TransactionScope
            Dim obj As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = idEntregable).FirstOrDefault

            If Not IsNothing(obj) Then
                obj.estado = estadoProy
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetEntregablesXSubProy(idEmpresa As String, idEstable As Integer, idSubProy As Integer, periodoProy As String) As List(Of recursoCosto)
        Dim listaRecurso As New List(Of recursoCosto)
        Dim Recurso As New recursoCosto


        Dim consulta = (From entre In HeliosData.recursoCosto
                        Join cuenta In HeliosData.cuentaplanContableEmpresa On CInt(entre.idCosto) Equals cuenta.idCosto
                        Where entre.idpadre = idSubProy
                        Select
                                idEntre = entre.idCosto,
                                nomEntre = entre.nombreCosto,
                                estado = entre.estado,
                                unidad = entre.unidad,
                                subtipo = entre.subtipo,
                                idItem = entre.codigo,
                            costoUnit = entre.precUnit,
                                cantidad = entre.cantidad,
                                inicio = entre.inicio,
                                finaliza = entre.finaliza,
                                cuenta = cuenta.cuenta,
                                costoTotal = (CType((Aggregate t1 In
                                       (From RecursoCostoDetalle In HeliosData.documentoLibroDiario
                                        Where
                                        RecursoCostoDetalle.idCosto = entre.idCosto
                                        Select New With {
                                            RecursoCostoDetalle.importeMN
                                        }) Into Sum(t1.importeMN)), Decimal?)),
                            subprod = (From recur In HeliosData.recursoCosto
                                       Where recur.idpadre = entre.idCosto).Count).ToList

        'Dim consulta = (From entre In HeliosData.recursoCosto
        '                Where entre.idpadre = idSubProy
        '                Select
        '                        idEntre = entre.idCosto,
        '                        nomEntre = entre.nombreCosto,
        '                        estado = entre.estado,
        '                        unidad = entre.unidad,
        '                        subtipo = entre.subtipo,
        '                        idItem = entre.codigo,
        '                    costoUnit = entre.precUnit,
        '                        cantidad = entre.cantidad,
        '                        inicio = entre.inicio,
        '                        finaliza = entre.finaliza,
        '                        costoTotal = (CType((Aggregate t1 In
        '                               (From RecursoCostoDetalle In HeliosData.recursoCostoDetalle
        '                                Where
        '                                RecursoCostoDetalle.idCosto = entre.idCosto And RecursoCostoDetalle.Periodo = periodoProy And
        '                                    RecursoCostoDetalle.tipoCosto = "RL"
        '                                Select New With {
        '                                    RecursoCostoDetalle.montoMN
        '                                }) Into Sum(t1.montoMN)), Decimal?)),
        '                    subprod = (From recur In HeliosData.recursoCosto
        '                               Where recur.idpadre = entre.idCosto).Count).ToList



        For Each i In consulta

            Recurso = New recursoCosto

            Recurso.idEntregable = i.idEntre
            Recurso.nombreEntregable = i.nomEntre
            Recurso.estado = i.estado
            Recurso.unidad = i.unidad
            Recurso.cantidad = i.cantidad
            Recurso.inicio = i.inicio
            Recurso.finaliza = i.finaliza
            Recurso.TotalMN = i.costoTotal.GetValueOrDefault
            Recurso.codigo = i.idItem
            Recurso.subtipo = i.subtipo
            Recurso.nroSubProductos = i.subprod
            Recurso.precUnit = i.costoUnit
            Recurso.nombreCuenta = i.cuenta



            listaRecurso.Add(Recurso)

        Next

        Return listaRecurso
    End Function

    Public Function GetGastosTipoAll(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto)
        Dim listaRecurso As New List(Of recursoCosto)
        Dim Recurso As New recursoCosto

        Dim consulta = (From entre In HeliosData.recursoCosto
                        Join cue In HeliosData.cuentaplanContableEmpresa
                                On entre.idCosto Equals cue.idCosto
                        Where entre.tipo = "HG"
                        Select
                         idEntregable = entre.idCosto,
                         nombreEntregable = entre.nombreCosto,
                            cuenta = cue.cuenta,
                            subtipo = entre.subtipo,
                      compras = ((Aggregate t1 In
                        (From det In HeliosData.documentocompradetalle
                         Join rec In HeliosData.recursoCosto On CInt(det.idCosto) Equals rec.idCosto
                         Where
                          det.tipoExistencia = "GS" And
                          det.documentocompra.idEmpresa = idEmpresa And
                          det.documentocompra.idCentroCosto = idEstable And
                          (New String() {"CMP", "BOFR", "NTC", "NDB", "CSP", "CRH"}).Contains(det.documentocompra.tipoCompra) _
                          And Not ((New String() {"11", "18"}).Contains(det.idItem.Substring(1 - 1, 2))) And
                          (New String() {"62", "63", "64", "65", "66", "67", "68"}).Contains(det.idItem.Substring(1 - 1, 2)) _
                             And det.tipoCosto = "PG" _
                             And det.idCosto = entre.idCosto
                         Select
                          det,
                          det.documentocompra,
                          rec)
                        Into Count())),
                          finanza = (CType((Aggregate t1 In
                            (From mov In HeliosData.movimiento
                             Where
                              mov.tipoCosto = "PG" And
                              mov.idCosto = entre.idCosto
                             Select mov) Into Count()), Int64?)),
                          libro = ((Aggregate t1 In
                            (From det In HeliosData.documentoLibroDiarioDetalle
                             Where
                              det.documentoLibroDiario.idEmpresa = idEmpresa And
                              det.documentoLibroDiario.idEstablecimiento = idEstable And
                              det.tipoCosto = "PG" And
                              det.idCosto = entre.idCosto
                             Select
                              det,
                              det.documentoLibroDiario)
                            Into Count()))).ToList

        For Each i In consulta

            Recurso = New recursoCosto

            Recurso.idEntregable = i.idEntregable
            Recurso.nombreEntregable = i.nombreEntregable
            Recurso.Conteocompras = i.compras
            Recurso.Conteoinventario = 0
            Recurso.Conteofinanza = i.finanza
            Recurso.Conteolibro = i.libro
            Recurso.subtipo = i.subtipo
            Recurso.nombreCuenta = i.cuenta

            listaRecurso.Add(Recurso)

        Next

        Return listaRecurso
    End Function

    Public Sub CambioEstado(idEntregable As Integer)
        Using ts As New TransactionScope
            Dim obj As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = idEntregable).FirstOrDefault

            If Not IsNothing(obj) Then
                obj.estado = "EJE"
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function CierreDeEntregables(fechaPeriodo As DateTime, idEmpresa As String, idEstable As Integer) As List(Of recursoCostoDetalle)
        Dim lista As New List(Of recursoCostoDetalle)
        Dim objeto As New recursoCostoDetalle

        Dim consulta = (From det In HeliosData.recursoCostoDetalle
                        Join cuen In HeliosData.cuentaplanContableEmpresa On det.recursoCosto.idCosto Equals CInt(cuen.idCosto)
                        Where det.fechaTrabajo.Value.Year = fechaPeriodo.Year And det.fechaTrabajo.Value.Month = fechaPeriodo.Month
                        Group New With {det.recursoCosto, cuen, det} By
                          det.recursoCosto.idCosto,
                          det.recursoCosto.nombreCosto,
                          cuen.cuenta
                         Into g = Group
                        Select
                          idCosto,
                          nombreCosto,
                          monto = CType(g.Sum(Function(p) p.det.montoMN), Decimal?),
                          cuenta).ToList
        For Each i In consulta

            objeto = New recursoCostoDetalle
            objeto.idCosto = i.idCosto
            objeto.NombreCosto = i.nombreCosto
            objeto.montoMN = i.monto
            objeto.montoME = CDec(0)
            objeto.cuenta = i.cuenta
            lista.Add(objeto)
        Next


        Return lista
    End Function

    Public Function GetProyectosAll(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto)
        Dim listaRecurso As New List(Of recursoCosto)
        Dim Recurso As New recursoCosto


        Dim consulta = (From entre In HeliosData.recursoCosto
                       Join subproy In HeliosData.recursoCosto On CInt(entre.idpadre) Equals subproy.idCosto
                       Join proy In HeliosData.recursoCosto On CInt(subproy.idpadre) Equals proy.idCosto
                       Join cuenta In HeliosData.cuentaplanContableEmpresa On CInt(entre.idCosto) Equals cuenta.idCosto
                       Where entre.tipo = "PT"
                       Select
                               idProy = proy.idCosto,
                               nomProy = proy.nombreCosto,
                               idSubProy = subproy.idCosto,
                               nomSubProy = subproy.nombreCosto,
                               idEntre = entre.idCosto,
                               nomEntre = entre.nombreCosto,
                               estado = entre.estado,
                           costoUnit = entre.precUnit,
                           subtipo = entre.subtipo,
                           idItem = entre.codigo,
                               unidad = entre.unidad,
                               cantidad = entre.cantidad,
                               inicio = entre.inicio,
                               finaliza = entre.finaliza,
                               cuenta = cuenta.cuenta,
                               costoTotal = (CType((Aggregate t1 In
                                       (From RecursoCostoDetalle In HeliosData.documentoLibroDiario
                                        Where
                                       RecursoCostoDetalle.idCosto = entre.idCosto
                                       Select New With {
                                           RecursoCostoDetalle.importeMN
                                      }) Into Sum(t1.importeMN)), Decimal?)),
                           subprod = (From recur In HeliosData.recursoCosto
                                      Where recur.idpadre = entre.idCosto).Count).ToList

        'Dim consulta = (From entre In HeliosData.recursoCosto
        '                Join subproy In HeliosData.recursoCosto On CInt(entre.idpadre) Equals subproy.idCosto
        '                Join proy In HeliosData.recursoCosto On CInt(subproy.idpadre) Equals proy.idCosto
        '                Where entre.tipo = "PT"
        '                Select
        '                        idProy = proy.idCosto,
        '                        nomProy = proy.nombreCosto,
        '                        idSubProy = subproy.idCosto,
        '                        nomSubProy = subproy.nombreCosto,
        '                        idEntre = entre.idCosto,
        '                        nomEntre = entre.nombreCosto,
        '                        estado = entre.estado,
        '                    costoUnit = entre.precUnit,
        '                    subtipo = entre.subtipo,
        '                    idItem = entre.codigo,
        '                        unidad = entre.unidad,
        '                        cantidad = entre.cantidad,
        '                        inicio = entre.inicio,
        '                        finaliza = entre.finaliza,
        '                        costoTotal = (CType((Aggregate t1 In
        '                               (From RecursoCostoDetalle In HeliosData.recursoCostoDetalle
        '                                Where
        '                                RecursoCostoDetalle.idCosto = entre.idCosto And RecursoCostoDetalle.tipoCosto = "RL"
        '                                Select New With {
        '                                    RecursoCostoDetalle.montoMN
        '                                }) Into Sum(t1.montoMN)), Decimal?)),
        '                    subprod = (From recur In HeliosData.recursoCosto
        '                               Where recur.idpadre = entre.idCosto).Count).ToList



        For Each i In consulta

            Recurso = New recursoCosto
            Recurso.idProyecto = i.idProy
            Recurso.nombreProyecto = i.nomProy
            Recurso.idSubProyecto = i.idSubProy
            Recurso.nombreSubProyecto = i.nomSubProy

            Recurso.idEntregable = i.idEntre
            Recurso.nombreEntregable = i.nomEntre
            Recurso.estado = i.estado
            Recurso.unidad = i.unidad
            Recurso.cantidad = i.cantidad

            Recurso.inicio = i.inicio
            Recurso.finaliza = i.finaliza

            Recurso.codigo = i.idItem

            Recurso.TotalMN = i.costoTotal.GetValueOrDefault

            Recurso.subtipo = i.subtipo

            Recurso.nroSubProductos = i.subprod

            Recurso.precUnit = i.costoUnit

            Recurso.nombreCuenta = i.cuenta



            listaRecurso.Add(Recurso)

        Next

        Return listaRecurso
    End Function

    Public Function GetEntregablesXProyecto(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto)
        Dim listaRecurso As New List(Of recursoCosto)
        Dim Recurso As New recursoCosto



        Dim consulta = (From entre In HeliosData.recursoCosto
                        Join subproy In HeliosData.recursoCosto On CInt(entre.idpadre) Equals subproy.idCosto
                        Join proy In HeliosData.recursoCosto On CInt(subproy.idpadre) Equals proy.idCosto
                        Join cuen In HeliosData.cuentaplanContableEmpresa On entre.idCosto Equals cuen.idCosto
                        Where entre.tipo = "PT"
                        Select
                        idProyecto = proy.idCosto,
                        nombreProyecto = proy.nombreCosto,
                         idSubProyecto = subproy.idCosto,
                        nombreSubProyecto = subproy.nombreCosto,
                         idEntregable = entre.idCosto,
                         nombreEntregable = entre.nombreCosto,
                            cuenta = cuen.cuenta,
                        estado = entre.estado,
                            subtipo = entre.subtipo,
                          finanza = (CType((Aggregate t1 In
                            (From mov In HeliosData.movimiento
                             Where
                              mov.tipoCosto = "PC" And
                              mov.idCosto = entre.idCosto
                             Select mov) Into Count()), Int64?))).ToList


        For Each i In consulta

            Recurso = New recursoCosto

            Recurso.idProyecto = i.idProyecto
            Recurso.nombreProyecto = i.nombreProyecto
            Recurso.idSubProyecto = i.idSubProyecto
            Recurso.nombreSubProyecto = i.nombreSubProyecto

            Recurso.idEntregable = i.idEntregable
            Recurso.nombreEntregable = i.nombreEntregable
            Recurso.Conteocompras = 0
            Recurso.Conteoinventario = 0
            Recurso.Conteofinanza = i.finanza
            Recurso.Conteolibro = 0
            Recurso.estado = i.estado
            Recurso.subtipo = i.subtipo
            Recurso.nombreCuenta = i.cuenta

            listaRecurso.Add(Recurso)

        Next


        Return listaRecurso
    End Function

    Public Sub GrabarProyectoGeneral(be As recursoCosto, subProy As recursoCosto, listaEntregable As List(Of recursoCosto))
        Dim obj As New recursoCosto
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Dim idSubProy As Integer
        Dim codigoEntregable As Integer
        Dim planNuevo As New List(Of cuentaplanContableEmpresa)
        Dim IDNum As Integer
        Dim SubProductos As New List(Of recursoCosto)
        Dim SubProductoXAgregar As New List(Of recursoCosto)
        Try

            'sdfsdgds

            SubProductos = (From i In listaEntregable
                            Where i.jerarquia = "ESP").ToList


            IDNum = be.idNumeracion
            Me.GrabarConstruccion(be)
            idSubProy = Me.GrabarSubConstruccion(subProy, be.idCosto)


            For Each i In listaEntregable

                If i.jerarquia = "EP" Then

                    If i.contrato = "HC - MERCADERIA" Then
                        codigoEntregable = Me.GrabarEntregableConstruccion(i, idSubProy)
                    Else
                        codigoEntregable = Me.GrabarEntregableConstruccion(i, idSubProy)

                        planNuevo = ListaCuentasPorEntregable(i, codigoEntregable, IDNum)

                        cuentaBL.InsertarListaDeCuentas(planNuevo)

                        ' InsertElmentosCosto(planNuevo, codigoEntregable)

                    End If

                    'llenar si tiene subproductos
                    SubProductoXAgregar = (From prod In SubProductos
                                           Where prod.nroEntregable = i.nroEntregable).ToList

                    For Each j In SubProductoXAgregar
                        Me.GrabarEntregableConstruccion(j, codigoEntregable)
                    Next


                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ListaCuentasPorEntregable(be As recursoCosto, idEntregable As Integer, idEnu As Integer)

        Dim lista As New List(Of cuentaplanContableEmpresa)
        Dim item As New cuentaplanContableEmpresa


        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer
        cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(idEnu))

        'por entregable
        item = New cuentaplanContableEmpresa
        item.NomCosto = be.nombreCuenta
        item.idEmpresa = Gempresas.IdEmpresaRuc
        item.cuenta = be.codigocuenta
        item.descripcion = be.detalle
        item.Observaciones = Nothing
        Select Case be.contrato
            Case "HC - COSTOS POR VALORACION"

                item.cuenta = "921" & cval
                item.cuentaPadre = "92"
            Case "HC - PROCESOS PRODUCTIVOS A VALORES HISTORICOS"
                item.cuenta = "922" & cval
                item.cuentaPadre = "92"
            Case "HC - PROCESO PRODUCTIVO A VALORES ESTANDAR"
                item.cuenta = "923" & cval
                item.cuentaPadre = "92"
        End Select
        item.usuarioModificacion = be.usuarioActualizacion
        item.fechaModificacion = DateTime.Now
        item.idCosto = idEntregable
        lista.Add(item)

        Return lista
    End Function

    Public Function GetListaSubProyectos(recurso As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)

        Dim consulta = (From n In HeliosData.recursoCosto _
                       Where n.tipo = recurso.tipo _
                       And n.idpadre = recurso.idpadre _
                       And n.status = recurso.status _
                       Select n).ToList

        For Each i In consulta
            obj = New recursoCosto
            obj.idCosto = i.idCosto
            obj.tipo = i.tipo
            obj.subtipo = i.subtipo
            obj.nombreCosto = i.nombreCosto
            obj.status = i.status
            'Select Case i.status
            '    Case StatusCosto.Culminado
            '        obj.status = "Culminado"
            '    Case StatusCosto.Avance_Obra_Cartera
            '        obj.status = "En Cartera"
            '    Case StatusCosto.Proceso
            '        obj.status = "En proceso"

            '    Case StatusCosto.Suspendido
            '        obj.status = "Suspendido"
            'End Select

            obj.codigo = i.codigo
            obj.detalle = i.detalle
            obj.subdetalle = i.subdetalle
            If i.tipo = "HC" Then
                obj.inicio = FormatDateTime(i.inicio, DateFormat.ShortDate)
                obj.finaliza = FormatDateTime(i.finaliza, DateFormat.ShortDate)
            End If
            lista.Add(obj)
        Next
        Return lista
    End Function


    Public Sub GrabarSubProyectoConstruccion(idProyecto As Integer, subProy As recursoCosto, listaEntregable As List(Of recursoCosto))
        Dim obj As New recursoCosto
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Dim idSubProy As Integer
        Dim codigoEntregable As Integer
        Dim planNuevo As New List(Of cuentaplanContableEmpresa)
        Try
            'Me.GrabarConstruccion(be)
            idSubProy = Me.GrabarSubConstruccion(subProy, idProyecto)




            For Each i In listaEntregable

                If i.contrato = "HC - MERCADERIA" Then
                    codigoEntregable = Me.GrabarEntregableConstruccion(i, idSubProy)
                Else
                    codigoEntregable = Me.GrabarEntregableConstruccion(i, idSubProy)

                    ''elemento costo


                    ' cuentaBL.InsertarListaDeCuentasConst(i)

                    planNuevo = ListaPlan(i)

                    cuentaBL.InsertarListaDeCuentas(planNuevo)
                    'plan.RemoveAt(0)


                    'InsertElmentosCosto(plan, idSubProy)
                    InsertElmentosCosto(planNuevo, codigoEntregable)
                    'fin
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub GrabarProyectoConstruccion(be As recursoCosto, subProy As recursoCosto, listaEntregable As List(Of recursoCosto), plan As List(Of cuentaplanContableEmpresa))
        Dim obj As New recursoCosto
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Dim idSubProy As Integer
        Dim codigoEntregable As Integer
        Dim planNuevo As New List(Of cuentaplanContableEmpresa)
        Try
            Me.GrabarConstruccion(be)
            idSubProy = Me.GrabarSubConstruccion(subProy, be.idCosto)




            For Each i In listaEntregable

                If i.contrato = "HC - MERCADERIA" Then
                    codigoEntregable = Me.GrabarEntregableConstruccion(i, idSubProy)
                Else
                    codigoEntregable = Me.GrabarEntregableConstruccion(i, idSubProy)

                    ''elemento costo


                    ' cuentaBL.InsertarListaDeCuentasConst(i)

                    planNuevo = ListaPlan(i)

                    cuentaBL.InsertarListaDeCuentas(planNuevo)
                    'plan.RemoveAt(0)


                    'InsertElmentosCosto(plan, idSubProy)
                    InsertElmentosCosto(planNuevo, codigoEntregable)
                    'fin
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function ListaPlan(be As recursoCosto)

        Dim lista As New List(Of cuentaplanContableEmpresa)
        Dim item As New cuentaplanContableEmpresa


        'elemtooooooooooooooooooooooooooooooooooooooo
        item = New cuentaplanContableEmpresa
        item.NomCosto = be.nombreCosto
        item.idEmpresa = Gempresas.IdEmpresaRuc
        item.cuenta = be.codigocuenta
        item.descripcion = be.detalle
        item.Observaciones = Nothing
        Select Case be.contrato
            Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                item.cuentaPadre = "92"

            Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"

                item.cuentaPadre = "92"

            Case "ACTIVO FIJO"
                item.cuentaPadre = "92"

            Case "GASTO ADMINISTRATIVO"
                item.cuentaPadre = "94"

            Case "GASTO DE VENTAS"
                item.cuentaPadre = "95"

            Case "GASTO FINANCIERO"
                item.cuentaPadre = "97"

        End Select
        item.usuarioModificacion = be.usuarioActualizacion
        item.fechaModificacion = DateTime.Now
        lista.Add(item)

        'ELEMENTOS DEL COSTO

        Select Case be.contrato
            Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO", _
                "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO", _
                "ACTIVO FIJO"

                item = New cuentaplanContableEmpresa
                item.NomCosto = be.nombreCosto
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = be.mdp
                item.descripcion = "MATERIA PRIMA DIRECTA"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "MPD"
                Select Case be.contrato
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                        "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                        "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                        "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = be.usuarioActualizacion
                item.fechaModificacion = DateTime.Now
                lista.Add(item)

                'Elementos del costo
                item = New cuentaplanContableEmpresa
                item.NomCosto = be.nombreCosto
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = be.mod1
                item.descripcion = "MANO DE OBRA DIRECTA"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "MOD"
                Select Case be.contrato
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                        "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                        "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                        "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = be.usuarioActualizacion
                item.fechaModificacion = DateTime.Now
                lista.Add(item)


                item = New cuentaplanContableEmpresa
                item.NomCosto = be.nombreCosto
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = be.ocd
                item.descripcion = "OTROS COSTOS DIRECTOS"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "OCD"
                Select Case be.contrato
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                          "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                          "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                          "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = be.usuarioActualizacion
                item.fechaModificacion = DateTime.Now
                lista.Add(item)

                '04 Gastos de produccion indirectos
                item = New cuentaplanContableEmpresa
                item.NomCosto = be.nombreCosto
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = be.gpi
                item.descripcion = "GASTOS DE PRODUCCION INDIRECTOS"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "GPI"
                Select Case be.contrato
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                         "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                         "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                          "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                          "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                          "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = be.usuarioActualizacion
                item.fechaModificacion = DateTime.Now
                lista.Add(item)

                '041 GPI-Materiales y suministros indirectos
                item = New cuentaplanContableEmpresa
                item.NomCosto = be.nombreCosto
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = be.gpimpi
                item.descripcion = "GPI-MATERIALES Y SUMINISTROS INDIRECTOS"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "GPI-MPI"
                Select Case be.contrato
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                      "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                      "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                          "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                          "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                          "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = be.usuarioActualizacion
                item.fechaModificacion = DateTime.Now
                lista.Add(item)


                '042 GPI-mano de obra indirecto
                item = New cuentaplanContableEmpresa
                item.NomCosto = be.nombreCosto
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = be.gpimoi
                item.descripcion = "GPI-MANO DE OBRA INDIRECTO"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "GPI-MOI"
                Select Case be.contrato
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                        "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                        "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                        "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = be.usuarioActualizacion
                item.fechaModificacion = DateTime.Now
                lista.Add(item)


                '043 GPI-OTROS GASTOS DE PRODUCCION INDIRECTOS
                item = New cuentaplanContableEmpresa
                item.NomCosto = be.nombreCosto
                item.idEmpresa = Gempresas.IdEmpresaRuc
                item.cuenta = be.gpiogi
                item.descripcion = "GPI-OTROS GASTOS DE PRODUCCION INDIRECTOS"
                item.Observaciones = Nothing
                item.tipoCosto = "ELC"
                item.SubTipoCosto = "GPI-OGI"
                Select Case be.contrato
                    Case "CONTRATOS DE CONSTRUCCION", "HC - CONSTRUC. Y SIMILARES",
                        "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES", "HC - SERV. VARIOS",
                        "CONTRATOS DE ARRENDAMIENTOS", "HC - ARRENDAMIENTO"
                        item.cuentaPadre = "92"

                    Case "OP. CONTINUA DE BIENES", "HC - PRODUCCION",
                        "OP. CONTINUA DE SERVICIOS", "HC - SERV. EDUCAT",
                        "OP. DE SERVICIOS - CONTROL INDEPENDIENTE", "HC - SERV. TRANSP", _
                        "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES", "HC - CONSUMO INMEDIATO"
                        item.cuentaPadre = "92"

                    Case "ACTIVO FIJO"
                        item.cuentaPadre = "92"

                    Case "GASTO ADMINISTRATIVO"
                        item.cuentaPadre = "94"

                    Case "GASTO DE VENTAS"
                        item.cuentaPadre = "95"

                    Case "GASTO FINANCIERO"
                        item.cuentaPadre = "97"

                End Select
                item.usuarioModificacion = be.usuarioActualizacion
                item.fechaModificacion = DateTime.Now
                lista.Add(item)
            Case Else

        End Select

        Return lista
    End Function

    Public Function GrabarEntregableConstruccion(be As recursoCosto, idsubproy As Integer)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                obj = New recursoCosto With
                      {
                          .idpadre = idsubproy,
                          .codigo = be.codigo,
                          .tipo = be.tipo,
                          .subtipo = be.subtipo,
                          .nombreCosto = be.nombreCosto,
                          .status = be.status,
                          .detalle = be.detalle,
                          .inicio = be.inicio,
                          .finaliza = be.finaliza,
                          .procesado = be.procesado,
                          .tipoExistencia = be.tipoExistencia,
                          .precUnit = be.precUnit,
                         .unidad = be.unidad,
                       .presentacion = be.presentacion,
                          .cantidad = be.cantidad,
                          .presupuesto = be.presupuesto,
                          .usuarioActualizacion = be.usuarioActualizacion,
                          .fechaActualizacion = be.fechaActualizacion,
                          .estado = be.estado,
                .jerarquia = be.jerarquia
                    }
                HeliosData.recursoCosto.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                Return obj.idCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub GrabarConstruccion(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                obj = New recursoCosto With
                      {
                      .idpadre = be.idpadre,
                          .tipo = be.tipo,
                          .subtipo = be.subtipo,
                          .nombreCosto = be.nombreCosto,
                          .status = be.status,
                          .codigo = be.codigo,
                          .detalle = be.detalle,
                          .subdetalle = be.subdetalle,
                          .inicio = be.inicio,
                          .finaliza = be.finaliza,
                          .procesado = be.procesado,
                          .usuarioActualizacion = be.usuarioActualizacion,
                .fechaActualizacion = be.fechaActualizacion
                    }
                HeliosData.recursoCosto.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                be.idCosto = obj.idCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function GrabarSubConstruccion(subProy As recursoCosto, idcosto As Integer)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                obj = New recursoCosto With
                      {
                          .idpadre = idcosto,
                          .tipo = subProy.tipo,
                          .subtipo = subProy.subtipo,
                          .nombreCosto = subProy.nombreCosto,
                          .cantidad = subProy.cantidad,
                          .status = subProy.status,
                          .codigo = subProy.codigo,
                          .detalle = subProy.detalle,
                          .subdetalle = subProy.subdetalle,
                          .inicio = subProy.inicio,
                          .finaliza = subProy.finaliza,
                          .director = subProy.director,
                          .procesado = subProy.procesado,
                          .jerarquia = subProy.jerarquia,
                          .usuarioActualizacion = subProy.usuarioActualizacion,
                .fechaActualizacion = subProy.fechaActualizacion
                    }
                HeliosData.recursoCosto.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                Return obj.idCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GetEliminarEnvioAalmacen(be As recursoCosto)
        Dim documentoBL As New documentoBL
        Dim invBL As New InventarioMovimientoBL
        Using ts As New TransactionScope
            Dim Envios = HeliosData.documentocompradetalle.Where(Function(o) o.idCosto = be.idCosto).ToList
            Dim codDocumento = Envios(0).idDocumento
            For Each i In Envios

                Dim obj = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.almacenRef And o.idItem = i.idItem).FirstOrDefault

                If Not IsNothing(obj) Then
                    obj.cantidad = obj.cantidad - i.monto1
                    obj.importeSoles = obj.importeSoles - i.importe
                    obj.importeDolares = obj.importeDolares - i.importeUS
                End If

            Next
            invBL.DeleteInventarioPorDocumento(codDocumento)

            Dim documento = HeliosData.documento.Where(Function(o) o.idDocumento = codDocumento).FirstOrDefault
            documentoBL.DeleteSingle(documento)

            Dim objCosto As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
            objCosto.status = StatusProductosTerminados.Pendiente

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GetEliminarProductosEnPlanta(be As recursoCosto)
        Dim documentoBL As New documentoBL
        Try
            Using ts As New TransactionScope

                Dim validaEnvios = HeliosData.documentocompradetalle.Where(Function(o) o.idCosto = be.idCosto).Count

                If validaEnvios > 0 Then
                    Throw New Exception("Existe un envío a almacén, no puede realizar la operación")
                End If

                Dim documentoComprobante = HeliosData.documento.Where(Function(o) o.idProyecto = be.idCosto).First
                documentoBL.DeleteSingle(documentoComprobante)
                EliminarCosto(be)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetNumRecursosConEntregaParcial(be As recursoCosto) As Integer
        Return HeliosData.recursoCosto.Where(Function(o) o.idpadre = be.idpadre AndAlso
                                                 o.subtipo = "PPR").Count
    End Function

    Public Function GetNumRecursosEnPlanta(be As recursoCosto) As Integer
        Return HeliosData.recursoCosto.Where(Function(o) o.idpadre = be.idpadre AndAlso
                                                 o.subtipo = "PPR" AndAlso
                                                 o.status = StatusProductosTerminados.Pendiente).Count
    End Function

    Public Sub GetCerrarPresupuesto(be As recursoCosto)
        Using ts As New TransactionScope

            Dim obj = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault

            If Not IsNothing(obj) Then
                obj.presupuesto = be.presupuesto
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarEntregable(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                obj = New recursoCosto With
                      {
                          .idpadre = be.idpadre,
                          .codigo = be.codigo,
                          .tipo = be.tipo,
                          .subtipo = be.subtipo,
                          .nombreCosto = be.nombreCosto,
                          .status = be.status,
                          .detalle = be.detalle,
                          .finaliza = be.finaliza,
                          .procesado = be.procesado,
                          .cantidad = be.cantidad,
                          .presupuesto = be.presupuesto,
                          .usuarioActualizacion = be.usuarioActualizacion,
                          .fechaActualizacion = be.fechaActualizacion
                    }
                HeliosData.recursoCosto.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                be.idCosto = obj.idCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EditarEntregable(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope

                Dim entregable = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault

                If Not IsNothing(entregable) Then
                    entregable.codigo = be.codigo
                    entregable.nombreCosto = be.nombreCosto
                    entregable.detalle = be.detalle
                    entregable.finaliza = be.finaliza
                    entregable.cantidad = be.cantidad
                    entregable.usuarioActualizacion = be.usuarioActualizacion
                    entregable.fechaActualizacion = be.fechaActualizacion
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarEntregable(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope

                Dim entregable = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault

                If Not IsNothing(entregable) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(entregable)
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetUpdateSecuencia(be As List(Of recursoCosto))
        Using ts As New TransactionScope
            For Each r In be
                Dim obj = HeliosData.recursoCosto.Where(Function(o) o.idCosto = r.idCosto).FirstOrDefault
                If Not IsNothing(obj) Then
                    obj.secuenciaCosto = r.secuenciaCosto
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub GetUpdatefechaActual(be As recursoCosto)
        Dim costo As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
        Using ts As New TransactionScope
            If Not IsNothing(costo) Then
                costo.inicioActual = be.inicioActual
                'costo.finalizaActual = be.finalizaActual
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GetCierreActividad(be As recursoCosto)
        Dim costo As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
        Using ts As New TransactionScope
            If Not IsNothing(costo) Then
                costo.status = StatusCosto.Culminado
                costo.finalizaActual = be.finalizaActual
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GetOpenActividad(be As recursoCosto)
        Dim costo As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
        Using ts As New TransactionScope
            If Not IsNothing(costo) Then
                costo.status = StatusCosto.Proceso
                costo.inicioActual = be.inicioActual
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GetPendingActividad(be As recursoCosto)
        Dim costo As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
        Using ts As New TransactionScope
            If Not IsNothing(costo) Then
                costo.status = StatusCosto.Avance_Obra_Cartera
                costo.inicioActual = Nothing
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub GetUpdateCronograma(be As recursoCosto)
        Dim costo As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
        Using ts As New TransactionScope
            If Not IsNothing(costo) Then
                costo.inicio = be.inicio
                costo.finaliza = be.finaliza
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetPlaneamientoActividades(be As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)

        Dim consulta = (From proceso In HeliosData.recursoCosto _
                        Group Join act In HeliosData.recursoCosto On New With {.IdCosto = proceso.idCosto} Equals New With {.IdCosto = CInt(act.idpadre)} Into act_join = Group _
                        From act In act_join.DefaultIfEmpty() _
                        Group Join det In HeliosData.recursoCostoDetalle On New With {act.idCosto} Equals New With {det.idCosto} Into det_join = Group _
                        From det In det_join.DefaultIfEmpty() _
                        Where _
                        proceso.tipo = "PRC" And _
                        CLng(proceso.idpadre) = be.idCosto _
                        Group New With {proceso, act, det} By _
                        SecuenciaTrabajoProceso = proceso.secuenciaCosto, _
                        idProceso = proceso.idCosto, _
                        nomProceso = proceso.nombreCosto, _
                        idActividad = act.idCosto, _
                        NomActividad = act.nombreCosto, _
                        act.inicio, _
                        act.finaliza, _
                        act.inicioActual, _
                        act.finalizaActual, _
                        act.secuenciaCosto _
                        Into g = Group _
                        Select _
                        SecuenciaTrabajoProceso, _
                        idProceso = CType(idProceso, Int32?), _
                        nomProceso, _
                        idActividad = CType(idActividad, Int32?), _
                        NomActividad = NomActividad, _
                        Inicio = CType(inicio, DateTime?), _
                        Finaliza = CType(finaliza, DateTime?), _
                        inicioActual, _
                        finalizaActual, _
                        secuenciaCosto, _
                        costo = CType(g.Sum(Function(p) p.det.montoMN), Decimal?)).ToList


        For Each i In consulta
            obj = New recursoCosto
            obj.SecuenciaTrabajoProceso = i.SecuenciaTrabajoProceso.GetValueOrDefault
            obj.secuenciaCosto = i.secuenciaCosto.GetValueOrDefault
            obj.IdProceso = i.idProceso
            obj.NomProceso = i.NomProceso
            obj.IdActividad = i.idActividad.GetValueOrDefault
            obj.NomActividad = i.NomActividad
            obj.inicio = i.inicio.GetValueOrDefault
            obj.finaliza = i.finaliza.GetValueOrDefault
            obj.TotalMN = i.costo.GetValueOrDefault
            obj.inicioActual = i.inicioActual.GetValueOrDefault
            obj.finalizaActual = i.finalizaActual.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function


    Public Function GetPlaneamientoEDT_Produccion(be As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)

        Dim con = (From proceso In HeliosData.recursoCosto
                   Where
                       proceso.tipo = "PRC" _
                       And proceso.idpadre = be.idCosto
                   Select
                   proceso.secuenciaCosto,
                   proceso.idCosto,
                   proceso.nombreCosto,
                   proceso.inicio,
                   proceso.finaliza,
                   proceso.inicioActual,
                   proceso.finalizaActual,
                   Column1 = proceso.secuenciaCosto,
                   CostoPlan = (CType((Aggregate t1 In
                                       (From RecursoCostoDetalle In HeliosData.recursoCostoDetalle
                                        Where
                                        RecursoCostoDetalle.tipoCosto = "PL" And
                                        RecursoCostoDetalle.idProceso = proceso.idCosto
                                        Select New With {
                                            RecursoCostoDetalle.montoMN
                                        }) Into Sum(t1.montoMN)), Decimal?)),
                    CostoReal = (CType((Aggregate t1 In
                                        (From RecursoCostoDetalle In HeliosData.recursoCostoDetalle
                                         Where
                                         RecursoCostoDetalle.tipoCosto = "RL" And
                                         RecursoCostoDetalle.idProceso = proceso.idCosto
                                         Select New With {
                                             RecursoCostoDetalle.montoMN
                                         }) Into Sum(t1.montoMN)), Decimal?))).ToList

        'Dim consulta = (From proceso In HeliosData.recursoCosto _
        '                Group Join det In HeliosData.recursoCostoDetalle On proceso.idCosto Equals det.idProceso Into det_join = Group _
        '                From det In det_join.DefaultIfEmpty() _
        '                Where _
        '                proceso.tipo = "PRC" And _
        '                CLng(proceso.idpadre) = be.idCosto _
        '                Group New With {proceso, det} By _
        '                SecuenciaTrabajoProceso = proceso.secuenciaCosto, _
        '                idProceso = proceso.idCosto, _
        '                nomProceso = proceso.nombreCosto,
        '                proceso.inicio, _
        '                proceso.finaliza, _
        '                proceso.inicioActual, _
        '                proceso.finalizaActual, _
        '                proceso.secuenciaCosto _
        '                Into g = Group _
        '                Select _
        '                SecuenciaTrabajoProceso, _
        '                idProceso = CType(idProceso, Int32?), _
        '                nomProceso, _
        '                Inicio = CType(inicio, DateTime?), _
        '                Finaliza = CType(finaliza, DateTime?), _
        '                inicioActual, _
        '                finalizaActual, _
        '                secuenciaCosto, _
        '                costo = CType(g.Sum(Function(p) p.det.montoMN), Decimal?)).ToList


        For Each i In con
            obj = New recursoCosto
            obj.SecuenciaTrabajoProceso = i.secuenciaCosto.GetValueOrDefault
            obj.secuenciaCosto = i.secuenciaCosto.GetValueOrDefault
            obj.IdProceso = i.idCosto
            obj.NomProceso = i.nombreCosto
            obj.inicio = i.inicio.GetValueOrDefault
            obj.finaliza = i.finaliza.GetValueOrDefault
            obj.CostoPresupuesto = i.CostoPlan.GetValueOrDefault
            obj.CostoReal = i.CostoReal.GetValueOrDefault
            obj.inicioActual = i.inicioActual.GetValueOrDefault
            obj.finalizaActual = i.finalizaActual.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function


    Public Function GetPlaneamientoKanban(be As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)

        Dim consulta = (From proceso In HeliosData.recursoCosto _
                        Group Join act In HeliosData.recursoCosto On New With {.IdCosto = proceso.idCosto} Equals New With {.IdCosto = CInt(act.idpadre)} Into act_join = Group _
                        From act In act_join.DefaultIfEmpty() _
                        Group Join det In HeliosData.recursoCostoDetalle On New With {act.idCosto} Equals New With {det.idCosto} Into det_join = Group _
                        From det In det_join.DefaultIfEmpty() _
                        Group Join per In HeliosData.Persona On per.idPersona Equals act.director Into per_join = Group _
                        From per In per_join.DefaultIfEmpty() _
                        Where _
                        proceso.tipo = "PRC" And _
                        CLng(proceso.idpadre) = be.idCosto _
                        And act.status = be.status _
                        Group New With {proceso, act, det, per} By _
                        idProceso = proceso.idCosto, _
                        nomProceso = proceso.nombreCosto, _
                        idActividad = act.idCosto, _
                        NomActividad = act.nombreCosto, _
                        act.inicio, _
                        act.finaliza, _
                        act.inicioActual, _
                        act.finalizaActual, _
                        per.nombreCompleto, _
                        act.secuenciaCosto, _
                        secuenciaProcesoTrabajo = proceso.secuenciaCosto _
                        Into g = Group _
                        Select _
                        secuenciaProcesoTrabajo, _
                        idProceso = CType(idProceso, Int32?), _
                        nomProceso, _
                        idActividad = CType(idActividad, Int32?), _
                        NomActividad = NomActividad, _
                        Inicio = CType(inicio, DateTime?), _
                        Finaliza = CType(finaliza, DateTime?), _
                        inicioActual, _
                        finalizaActual, _
                        nombreCompleto, _
                        secuenciaCosto, _
                        costo = CType(g.Sum(Function(p) p.det.montoMN), Decimal?) Order By secuenciaProcesoTrabajo).ToList


        For Each i In consulta
            obj = New recursoCosto
            obj.IdProceso = i.idProceso
            obj.NomProceso = i.nomProceso
            obj.IdActividad = i.idActividad.GetValueOrDefault
            obj.NomActividad = i.NomActividad
            obj.inicio = i.Inicio.GetValueOrDefault
            obj.finaliza = i.Finaliza.GetValueOrDefault
            obj.TotalMN = i.costo.GetValueOrDefault
            obj.inicioActual = i.inicioActual.GetValueOrDefault
            obj.finalizaActual = i.finalizaActual.GetValueOrDefault
            obj.NombreResponsable = i.nombreCompleto
            obj.secuenciaCosto = i.secuenciaCosto.GetValueOrDefault
            obj.SecuenciaTrabajoProceso = i.secuenciaProcesoTrabajo.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista
    End Function
    

    Public Sub GetEliminarCierreCosto(be As recursoCosto)
        Dim documentoBL As New documentoBL
        Try
            Using ts As New TransactionScope
                Dim costo As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
                Select Case costo.status
                    Case StatusCosto.Avance_Obra_Cartera
                        Throw New Exception("El costo ya fue abierto, intente en otra ocasión")
                    Case Else
                        GetCulminaAbreCosto(be)
                        Dim asiento As asiento = HeliosData.asiento.Where(Function(o) o.tipoAsiento = "CCS").FirstOrDefault
                        If Not IsNothing(asiento) Then
                            documentoBL.DeleteSingleVariable(asiento.idDocumento)
                        End If
                End Select
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        
    End Sub


    Public Sub GetEliminarCierreProduccion(be As recursoCosto)
        Dim documentoBL As New documentoBL
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        Try
            Using ts As New TransactionScope
                Dim costo As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
                Select Case costo.status
                    Case StatusCosto.Avance_Obra_Cartera
                        Throw New Exception("La orden de producción ya fue abierta, intente en otra ocasión")
                    Case Else
                        GetCulminaAbreCosto(be)
                        Dim asiento As asiento = HeliosData.asiento.Where(Function(o) o.tipoAsiento = "OPCN").FirstOrDefault
                        If Not IsNothing(asiento) Then

                            Dim consutaDetalle As List(Of documentocompradetalle) = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = asiento.idDocumento).ToList

                            inventarioBL.DeleteInventarioPorDocumento(asiento.idDocumento)

                            For Each i In consutaDetalle
                                t = New totalesAlmacen
                                t.idEmpresa = asiento.idEmpresa
                                t.idEstablecimiento = asiento.idCentroCostos
                                t.idAlmacen = i.almacenRef
                                t.origenRecaudo = i.destino
                                t.idItem = i.idItem
                                t.cantidad = i.monto1 * -1
                                t.importeSoles = i.importe * -1
                                t.importeDolares = 0
                                totalesBL.UpdateSingle2(t)
                            Next
                            documentoBL.DeleteSingleVariable(asiento.idDocumento)
                        End If
                End Select
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub GetCulminarProduccion(be As recursoCosto)
        Using ts As New TransactionScope
            Dim obj = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
            obj.status = be.status
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub GetCulminarCosto(be As recursoCosto, documento As documento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim asientoBL As New AsientoBL
        Dim libroBL As New documentoLibroDiarioBL
        Dim documentoBL As New documentoBL
        Dim docDetalle As New documentoLibroDiarioDetalle

        Using ts As New TransactionScope
            GetCulminaAbreCosto(be)
            documentoBL.Insert(documento)
            libroBL.InsertCabecera(documento.documentoLibroDiario, documento.idDocumento)
            asientoBL.SavebyGroupDoc(documento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GetCulminarCostoProduccion(be As recursoCosto, documento As documento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim asientoBL As New AsientoBL
        Dim libroBL As New documentoLibroDiarioBL
        Dim documentoBL As New documentoBL
        Dim docDetalle As New documentoLibroDiarioDetalle
        Dim documentocompraBL As New documentocompraBL
        Dim compraDetalleBL As New documentocompradetalleBL
        Dim inventario As New InventarioMovimientoBL
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL

        Using ts As New TransactionScope
            GetCulminaAbreCosto(be)
            documentoBL.Insert(documento)
            libroBL.InsertCabecera(documento.documentoLibroDiario, documento.idDocumento)

            'Otras entradas a almacen
            documentocompraBL.Insert(documento.documentocompra, documento.idDocumento)

            For Each i In documento.documentocompra.documentocompradetalle
                Dim costoTerminado As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = i.idCosto).FirstOrDefault
                costoTerminado.cantidadCierre = i.monto1
                costoTerminado.precUnitCierre = i.precioUnitario
                costoTerminado.costoCierre = i.importe

                Dim codSecuencia = compraDetalleBL.InsertSingle(i, documento.idDocumento)
                i.secuencia = codSecuencia
                inventario.InsertAlmacenOEDefault(i, documento)

                t = New totalesAlmacen
                t.idEmpresa = i.IdEmpresa
                t.idEstablecimiento = i.IdEstablecimiento
                t.tipoExistencia = i.tipoExistencia
                t.descripcion = i.descripcionItem
                ' t.descripcion = i.DetalleItem
                t.idUnidad = i.unidad1
                t.idAlmacen = i.almacenRef
                t.origenRecaudo = i.destino
                t.idItem = i.idItem
                t.cantidad = i.monto1
                t.precioUnitarioCompra = 0
                t.importeSoles = i.importe
                t.importeDolares = i.importeUS
                t.usuarioActualizacion = i.usuarioModificacion
                t.fechaActualizacion = i.fechaModificacion
                totalesBL.UpdateStockOtrasEntradas(t)
            Next

            asientoBL.SavebyGroupDoc(documento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GetCulminaAbreCosto(be As recursoCosto)
        Dim con = (From n In HeliosData.recursoCosto _
                  Where n.idCosto = be.idCosto).FirstOrDefault
        Using ts As New TransactionScope
            If Not IsNothing(con) Then
                con.status = be.status
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetResporteItemsByProyecto(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim lista As New List(Of recursoCostoDetalle)
        Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                       Join c In HeliosData.recursoCosto _
                       On c.idCosto Equals det.idCosto _
                       Join mo In HeliosData.recursoCosto _
                       On mo.idCosto Equals c.idpadre _
                       Join doc In HeliosData.documento _
                       On doc.idDocumento Equals det.documentoRef _
                       Where mo.idCosto = be.idCosto).ToList

        For Each i In consulta
            obj = New recursoCostoDetalle
            obj.NombreCosto = i.mo.nombreCosto
            obj.iditem = i.det.iditem
            obj.descripcion = i.det.descripcion
            obj.destino = i.det.destino
            obj.um = i.det.um
            obj.montoMN = i.det.montoMN

            obj.ManoObra = i.c.nombreCosto
            obj.TipoOperacionBase = i.doc.tipoOperacion
            obj.tipoDocBase = i.doc.tipoDoc
            obj.NroComprobateBase = i.doc.nroDoc

            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function GetResporteItemsByGastos(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim lista As New List(Of recursoCostoDetalle)
        Dim consulta = (From det In HeliosData.recursoCostoDetalle _
                       Join c In HeliosData.recursoCosto _
                       On c.idCosto Equals det.idCosto _
                       Join doc In HeliosData.documento _
                       On doc.idDocumento Equals det.documentoRef _
                       Where c.idCosto = be.idCosto).ToList

        For Each i In consulta
            obj = New recursoCostoDetalle
            obj.NombreCosto = i.c.nombreCosto
            obj.iditem = i.det.iditem
            obj.descripcion = i.det.descripcion
            obj.destino = i.det.destino
            obj.um = i.det.um
            obj.montoMN = i.det.montoMN

            ' obj.ManoObra = i.c.nombreCosto
            obj.TipoOperacionBase = i.doc.tipoOperacion
            obj.tipoDocBase = i.doc.tipoDoc
            obj.NroComprobateBase = i.doc.nroDoc

            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function GetElementosCostoByCosto(be As recursoCosto) As List(Of recursoCosto)
        Dim consulta = (From n In HeliosData.recursoCosto _
                       Where n.idpadre = be.idCosto And n.tipo = "ELC").ToList

        Return consulta
    End Function

    Public Function GetActividadProcesoByProyecto(be As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)

        Dim consulta = (From ACT In HeliosData.recursoCosto _
                       Join PR In HeliosData.recursoCosto On New With {.IdCosto = CInt(ACT.idpadre)} Equals New With {.IdCosto = PR.idCosto} _
                       Where _
                       ACT.tipo = "TRS" _
                       And PR.idpadre = be.idCosto _
                       Select _
                       ACT.idCosto, _
                       Actividad = ACT.nombreCosto, _
                       Proceso = PR.nombreCosto,
                       ACT.inicio, ACT.finaliza).ToList

        For Each i In consulta
            obj = New recursoCosto
            obj.idCosto = i.idCosto
            obj.nombreCosto = i.Actividad & "-" & i.Proceso
            obj.inicio = i.inicio.GetValueOrDefault
            obj.finaliza = i.finaliza.GetValueOrDefault
            lista.Add(obj)
        Next
        Return lista

    End Function

    Public Function GetProcesosByCosto(be As recursoCosto) As List(Of recursoCosto)
        Dim consulta = (From n In HeliosData.recursoCosto _
                       Where n.idpadre = be.idCosto And n.tipo = "PRC").ToList

        Return consulta
    End Function

    Public Function GetTareasByProyecto(be As recursoCosto) As List(Of recursoCosto)
        Dim consulta = (From n In HeliosData.recursoCosto _
                       Where n.idpadre = be.idCosto And n.tipo = "TRS").ToList

        Return consulta
    End Function

    Public Function GetProductosTerminadosByCosto(be As recursoCosto) As List(Of recursoCosto)
        Dim consulta = (From n In HeliosData.recursoCosto _
                       Where n.idpadre = be.idCosto And n.tipo = "PT").ToList

        Return consulta
    End Function

    Public Function GetSumaTotalByProyecto(be As recursoCostoDetalle) As List(Of recursoCostoDetalle)
        Dim obj As New recursoCostoDetalle
        Dim lista As New List(Of recursoCostoDetalle)
        Dim costoPlan = (CType((Aggregate t2 In _
                                                (From det In HeliosData.recursoCostoDetalle _
                                                 Group Join r0 In HeliosData.recursoCosto On New With {det.idCosto} Equals New With {r0.IdCosto} Into r0_join = Group _
                                                 From r0 In r0_join.DefaultIfEmpty() _
                                                 Group Join proce In HeliosData.recursoCosto On New With {.IdCosto = CInt(r0.idpadre)} Equals New With {.IdCosto = proce.IdCosto} Into proce_join = Group _
                                                 From proce In proce_join.DefaultIfEmpty() _
                                                 Group Join py In HeliosData.recursoCosto On New With {.IdCosto = CInt(proce.idpadre)} Equals New With {.IdCosto = py.IdCosto} Into py_join = Group _
                                                 From py In py_join.DefaultIfEmpty() _
                                                 Where _
                                                 CLng(py.idCosto) = be.idCosto And _
                                                 det.tipoCosto = "PL" _
                                                 Select New With { _
                                                     det.montoMN _
                                                 }) Into Sum(t2.montoMN)), Decimal?))


        obj = New recursoCostoDetalle
        obj.tipoCosto = "PL"
        obj.descripcion = "COSTO PLANEADO"
        obj.montoMN = costoPlan.GetValueOrDefault
        lista.Add(obj)
        Dim CostoReal = Aggregate n In HeliosData.recursoCostoDetalle _
                        Join elementoCosto In HeliosData.recursoCosto _
                        On elementoCosto.idCosto Equals n.idCosto _
                        Where elementoCosto.idpadre = be.idCosto _
                        And n.tipoCosto = "RL" _
                        Into SumaReal = Sum(n.montoMN)
        obj = New recursoCostoDetalle
        obj.tipoCosto = "RL"
        obj.descripcion = "COSTO EJECUTADO"
        obj.montoMN = CostoReal.GetValueOrDefault
        lista.Add(obj)

        Return lista


    End Function


    Public Function GetProductosTerminadosByProyecto(be As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim Lista As New List(Of recursoCosto)
        Dim consultaFull = (From r In HeliosData.recursoCosto _
                            Group Join item In HeliosData.detalleitems On New With {.Codigodetalle = r.codigo} Equals New With {.Codigodetalle = CStr(item.codigodetalle)} Into item_join = Group _
                            From item In item_join.DefaultIfEmpty() _
                            Where _
                            r.tipo = "PT" And _
                            CLng(r.idpadre) = be.idCosto _
                            Select _
                            r.idCosto, _
                            r.secuenciaCosto, _
                            r.nombreCosto, _
                            r.finaliza, _
                            r.finalizaActual, _
                            TipoExistencia = item.tipoExistencia, _
                            Unidad1 = item.unidad1, _
                            r.cantidad _
                            ).ToList


        Lista = New List(Of recursoCosto)

        For Each i In consultaFull
            obj = New recursoCosto
            obj.idCosto = i.idCosto
            obj.nombreCosto = i.nombreCosto
            obj.secuenciaCosto = i.secuenciaCosto
            obj.finaliza = i.finaliza.GetValueOrDefault
            obj.finalizaActual = i.finalizaActual.GetValueOrDefault
            obj.tipoExistencia = i.TipoExistencia
            obj.UnidadMedida = i.Unidad1
            obj.cantidad = i.cantidad.GetValueOrDefault
            obj.costo = 0
            obj.costoCierre = 0
            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function GetOrdenesDeProduccionInfo(be As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim Lista As New List(Of recursoCosto)

        Dim consulta = (From costo In HeliosData.recursoCosto
                        Group Join prod In HeliosData.detalleitems On costo.codigo Equals prod.codigodetalle Into prod_join = Group
                        From prod In prod_join.DefaultIfEmpty()
                        Where
                        costo.tipo = "PT" And
                        costo.idpadre = be.idCosto _
                        And costo.status = be.status
                        Select
                        costo.presupuesto,
                        costo.idCosto,
                        costo.secuenciaCosto,
                        costo.nombreCosto,
                        costo.finaliza,
                        costo.finalizaActual,
                        TipoExistencia = prod.tipoExistencia,
                        Unidad1 = prod.unidad1,
                        costo.cantidad,
                        costo.codigo,
                        CantPresupuesto = (CType((Aggregate t1 In
                                                  (From RecursoCostoDetalle In HeliosData.recursoCostoDetalle
                                                   Where
                                                   RecursoCostoDetalle.tipoCosto = "PL" And
                                                   RecursoCostoDetalle.idCosto = costo.idCosto
                                                   Select New With {
                                                       RecursoCostoDetalle.cant
                                                   }) Into Sum(t1.cant)), Decimal?)),
                               CostoPresupuesto = (CType((Aggregate t1 In
                                                          (From RecursoCostoDetalle In HeliosData.recursoCostoDetalle
                                                           Where
                                                           RecursoCostoDetalle.tipoCosto = "PL" And
                                                           RecursoCostoDetalle.idCosto = costo.idCosto
                                                           Select New With {
                                                               RecursoCostoDetalle.montoMN
                                                           }) Into Sum(t1.montoMN)), Decimal?)),
                                       CantidadReal = ((Aggregate c In
                                                       HeliosData.recursoCosto
                                                        Join det In HeliosData.recursoCostoDetalle On c.idCosto Equals det.idProceso
                                                        Where
                                                        det.tipoCosto = "RL" And
                                                        c.idpadre = costo.idCosto
                                                         Into Sum(det.cant))),
                                         CostoReal = ((Aggregate c In
                                                       HeliosData.recursoCosto
                                                        Join det In HeliosData.recursoCostoDetalle On c.idCosto Equals det.idProceso
                                                        Where
                                                        det.tipoCosto = "RL" And
                                                        c.idpadre = costo.idCosto
                                                         Into Sum(det.montoMN)))).ToList

        'Dim consultaFull = (From costo In HeliosData.recursoCosto _
        '                    Group Join item In HeliosData.detalleitems On New With {.Codigodetalle = costo.codigo} Equals New With {.Codigodetalle = CStr(item.codigodetalle)} Into item_join = Group _
        '                    From item In item_join.DefaultIfEmpty() _
        '                    Where _
        '                    costo.tipo = "PT" And _
        '                    CLng(costo.idpadre) = be.idCosto _
        '                    Select _
        '                    costo.idCosto, _
        '                    costo.secuenciaCosto, _
        '                    costo.nombreCosto, _
        '                    costo.finaliza, _
        '                    costo.finalizaActual, _
        '                    TipoExistencia = item.tipoExistencia, _
        '                    Unidad1 = item.unidad1, _
        '                    costo.cantidad, _
        '                    costo.codigo, _
        '                    cantPresupuesto = (CType((Aggregate t1 In _
        '                                              (From det In HeliosData.recursoCostoDetalle _
        '                                               Where _
        '                                               det.tipoCosto = "PL" And _
        '                                               det.idCosto = costo.idCosto _
        '                                               Select New With {
        '                                                   det.cant _
        '                                               }) Into Sum(t1.cant)), Decimal?)), _
        '                           CostoPresupuesto = (CType((Aggregate t1 In _
        '                                                      (From det In HeliosData.recursoCostoDetalle _
        '                                                       Where _
        '                                                       det.tipoCosto = "PL" And _
        '                                                       det.idCosto = costo.idCosto _
        '                                                       Select New With {
        '                                                           det.montoMN _
        '                                                       }) Into Sum(t1.montoMN)), Decimal?)), _
        '                                   CostoReal = (CType((Aggregate t1 In _
        '                                                      (From det In HeliosData.recursoCostoDetalle _
        '                                                       Where _
        '                                                       det.tipoCosto = "RL" And _
        '                                                       det.idCosto = costo.idCosto _
        '                                                       Select New With {
        '                                                           det.montoMN _
        '                                                       }) Into Sum(t1.montoMN)), Decimal?))).ToList


        Lista = New List(Of recursoCosto)

        For Each i In consulta
            obj = New recursoCosto
            obj.codigo = i.codigo
            obj.idCosto = i.idCosto
            obj.presupuesto = i.presupuesto
            obj.nombreCosto = i.nombreCosto
            obj.secuenciaCosto = i.secuenciaCosto
            obj.finaliza = i.finaliza.GetValueOrDefault
            obj.finalizaActual = i.finalizaActual.GetValueOrDefault
            obj.tipoExistencia = i.TipoExistencia
            obj.UnidadMedida = i.Unidad1
            obj.cantidad = i.cantidad.GetValueOrDefault
            obj.cantPresupuesto = i.CantPresupuesto.GetValueOrDefault
            obj.CostoPresupuesto = i.CostoPresupuesto.GetValueOrDefault
            obj.CantidadReal = i.CantidadReal.GetValueOrDefault
            obj.CostoReal = i.CostoReal.GetValueOrDefault
            obj.costo = 0
            obj.costoCierre = 0
            Lista.Add(obj)
        Next
        Return Lista
    End Function


    Public Function GetListaRecursosXtipo(recurso As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)

        Dim consulta = (From n In HeliosData.recursoCosto _
                       Where n.tipo = recurso.tipo _
                       And n.subtipo = recurso.subtipo _
                       And n.status = StatusCosto.Proceso _
                       Select n).ToList

        For Each i In consulta
            obj = New recursoCosto
            obj.idCosto = i.idCosto
            obj.tipo = i.tipo
            obj.subtipo = i.subtipo
            obj.nombreCosto = i.nombreCosto
            Select Case i.status
                Case StatusCosto.Culminado
                    obj.status = "Culminado"
                Case StatusCosto.Avance_Obra_Cartera
                    obj.status = "Avance"
                Case StatusCosto.Proceso
                    obj.status = "En proceso"

                Case StatusCosto.Suspendido
                    obj.status = "Suspendido"

            End Select

            obj.codigo = i.codigo
            obj.detalle = i.detalle
            obj.subdetalle = i.subdetalle
            If i.tipo = "HC" Then
                obj.inicio = FormatDateTime(i.inicio, DateFormat.ShortDate)
                obj.finaliza = FormatDateTime(i.finaliza, DateFormat.ShortDate)
            End If
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetListaPryectosEnCarteraFull(recurso As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)
        Dim listaTipo As New List(Of String)

        listaTipo.Add(TipoCosto.CONTRATOS_DE_CONSTRUCCION)
        listaTipo.Add(TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS)
        listaTipo.Add(TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES)


        listaTipo.Add(TipoCosto.OP_CONTINUA_DE_BIENES)
        listaTipo.Add(TipoCosto.OP_CONTINUA_DE_SERVICIOS)
        listaTipo.Add(TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE)
        listaTipo.Add(TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES)
        listaTipo.Add(TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE)

        listaTipo.Add(TipoCosto.ActivoFijo)
        'listaTipo.Add(TipoCosto.Proyecto)

        Dim consulta = (From n In HeliosData.recursoCosto _
                       Where n.tipo = recurso.tipo _
                       And listaTipo.Contains(n.subtipo) _
                       Select n).ToList

        For Each i In consulta
            obj = New recursoCosto
            obj.idCosto = i.idCosto
            obj.tipo = i.tipo
            obj.subtipo = i.subtipo
            obj.nombreCosto = i.nombreCosto
            obj.status = i.status
            'Select Case i.status
            '    Case StatusCosto.Culminado
            '        obj.status = "Culminado"
            '    Case StatusCosto.Avance_Obra_Cartera
            '        obj.status = "En Cartera"
            '    Case StatusCosto.Proceso
            '        obj.status = "En proceso"

            '    Case StatusCosto.Suspendido
            '        obj.status = "Suspendido"
            'End Select

            obj.codigo = i.codigo
            obj.detalle = i.detalle
            obj.subdetalle = i.subdetalle
            If i.tipo = "HC" Then
                obj.inicio = FormatDateTime(i.inicio, DateFormat.ShortDate)
                obj.finaliza = FormatDateTime(i.finaliza, DateFormat.ShortDate)
            End If
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetListaProtectosByProyGeneral(recurso As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)
        Dim listaTipo As New List(Of String)

        listaTipo.Add(TipoCosto.CONTRATOS_DE_CONSTRUCCION)
        listaTipo.Add(TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS)
        listaTipo.Add(TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES)
        listaTipo.Add(TipoCosto.HC_Mercaderia)


        listaTipo.Add(TipoCosto.OP_CONTINUA_DE_BIENES)
        listaTipo.Add(TipoCosto.OP_CONTINUA_DE_SERVICIOS)
        listaTipo.Add(TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE)
        listaTipo.Add(TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES)
        listaTipo.Add(TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE)

        listaTipo.Add(TipoCosto.ActivoFijo)
        'listaTipo.Add(TipoCosto.Proyecto)

        Dim consulta = (From n In HeliosData.recursoCosto _
                       Where n.tipo = recurso.tipo _
                       And listaTipo.Contains(n.subtipo) _
                       And n.idpadre = recurso.idpadre _
                       Select n).ToList

        For Each i In consulta
            obj = New recursoCosto
            obj.idCosto = i.idCosto
            obj.tipo = i.tipo
            obj.subtipo = i.subtipo
            obj.nombreCosto = i.nombreCosto
            obj.status = i.status
            'Select Case i.status
            '    Case StatusCosto.Culminado
            '        obj.status = "Culminado"
            '    Case StatusCosto.Avance_Obra_Cartera
            '        obj.status = "En Cartera"
            '    Case StatusCosto.Proceso
            '        obj.status = "En proceso"

            '    Case StatusCosto.Suspendido
            '        obj.status = "Suspendido"
            'End Select

            obj.codigo = i.codigo
            obj.detalle = i.detalle
            obj.subdetalle = i.subdetalle
            If i.tipo = "HC" Then
                obj.inicio = FormatDateTime(i.inicio, DateFormat.ShortDate)
                obj.finaliza = FormatDateTime(i.finaliza, DateFormat.ShortDate)
            End If
            lista.Add(obj)
        Next
        Return lista
    End Function


    Public Function GetListaProyectosBySubTipo(recurso As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)

        Dim consulta = (From n In HeliosData.recursoCosto _
                       Where n.tipo = recurso.tipo _
                       And (n.subtipo = recurso.subtipo) _
                       And n.idpadre = recurso.idpadre _
                       And n.status = recurso.status _
                       Select n).ToList

        For Each i In consulta
            obj = New recursoCosto
            obj.idCosto = i.idCosto
            obj.tipo = i.tipo
            obj.subtipo = i.subtipo
            obj.nombreCosto = i.nombreCosto
            obj.status = i.status
            'Select Case i.status
            '    Case StatusCosto.Culminado
            '        obj.status = "Culminado"
            '    Case StatusCosto.Avance_Obra_Cartera
            '        obj.status = "En Cartera"
            '    Case StatusCosto.Proceso
            '        obj.status = "En proceso"

            '    Case StatusCosto.Suspendido
            '        obj.status = "Suspendido"
            'End Select

            obj.codigo = i.codigo
            obj.detalle = i.detalle
            obj.subdetalle = i.subdetalle
            If i.tipo = "HC" Then
                obj.inicio = FormatDateTime(i.inicio, DateFormat.ShortDate)
                obj.finaliza = FormatDateTime(i.finaliza, DateFormat.ShortDate)
            End If
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetProyectoByCodigoGenerado(recurso As recursoCosto) As recursoCosto
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)
        Dim listaTipo As New List(Of String)

        listaTipo.Add(TipoCosto.Proyecto)
        listaTipo.Add(TipoCosto.ActivoFijo)
        listaTipo.Add(TipoCosto.Proyecto)

        Dim i = (From n In HeliosData.recursoCosto _
                       Where n.codigo = recurso.codigo).FirstOrDefault

        If Not IsNothing(i) Then
            obj = New recursoCosto
            obj.idCosto = i.idCosto
            obj.tipo = i.tipo
            obj.subtipo = i.subtipo
            obj.nombreCosto = i.nombreCosto
            'Select Case i.status
            '    Case StatusCosto.Culminado
            '        obj.status = "Culminado"
            '    Case StatusCosto.Avance_Obra_Cartera
            '        obj.status = "En Cartera"
            '    Case StatusCosto.Proceso
            '        obj.status = "En proceso"

            '    Case StatusCosto.Suspendido
            obj.status = i.status
            'End Select

            obj.codigo = i.codigo
            obj.detalle = i.detalle
            obj.subdetalle = i.subdetalle
            obj.director = i.director
            If i.tipo = "HC" Then
                obj.inicio = FormatDateTime(i.inicio, DateFormat.ShortDate)
                obj.finaliza = FormatDateTime(i.finaliza, DateFormat.ShortDate)
            End If
            Return obj
        Else
            Return Nothing
        End If


    End Function


    Public Function GetCostoById(be As recursoCosto) As recursoCosto
        Return HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault
    End Function

    Public Function GetCostoCount(subTipoCosto As String) As Integer
        Return HeliosData.recursoCosto.Where(Function(o) o.subtipo = subTipoCosto).Count
    End Function

    Public Sub InsertElmentosCosto(be As List(Of cuentaplanContableEmpresa), idCostoPadre As Integer)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                For Each i In be
                    obj = New recursoCosto With
                     {
                         .idpadre = idCostoPadre,
                         .tipo = i.tipoCosto,
                         .subtipo = i.SubTipoCosto,
                         .nombreCosto = i.descripcion,
                         .status = 0,
                         .codigo = i.cuenta,
                         .procesado = "N",
                         .usuarioActualizacion = i.usuarioModificacion,
                    .fechaActualizacion = i.fechaModificacion
                   }
                    HeliosData.recursoCosto.Add(obj)
                Next

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertProcesosByCosto(be As List(Of recursoCosto), idCostoPadre As Integer)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                For Each i In be
                    obj = New recursoCosto With
                     {
                         .idpadre = idCostoPadre,
                         .secuenciaCosto = i.secuenciaCosto,
                         .tipo = i.tipo,
                         .subtipo = i.subtipo,
                         .nombreCosto = i.nombreCosto,
                         .status = 0,
                         .codigo = i.codigo,
                         .procesado = "N",
                         .cantidad = i.cantidad,
                         .precUnit = i.precUnit,
                         .costo = i.costo,
                         .almacen = i.almacen,
                         .usuarioActualizacion = i.usuarioActualizacion,
                         .fechaActualizacion = i.fechaActualizacion
                   }
                    HeliosData.recursoCosto.Add(obj)
                Next

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub GrabarCosto(be As recursoCosto, plan As List(Of cuentaplanContableEmpresa), listaProcesos As List(Of recursoCosto))
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Try
            Using ts As New TransactionScope
                GrabarCostoOne_2(be)

                Select Case be.subtipo
                    Case TipoCosto.HC_Mercaderia

                    Case Else
                        cuentaBL.InsertarListaDeCuentasV2(plan, be.idCosto, be.idNumeracion)

                        plan.RemoveAt(0)

                        Select Case be.subtipo
                            Case TipoCosto.GastoAdministrativo, TipoCosto.GastoFinanciero, TipoCosto.GastoVentas

                            Case Else
                                InsertElmentosCosto(plan, be.idCosto)
                        End Select

                        If listaProcesos.Count > 0 Then
                            InsertProcesosByCosto(listaProcesos, be.idCosto)
                        End If
                End Select
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarTask(be As recursoCosto)
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Try
            Using ts As New TransactionScope
                GrabarCostoTarea(be)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarCostoOne(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                obj = New recursoCosto With
                      {
                          .tipo = be.tipo,
                          .subtipo = be.subtipo,
                          .nombreCosto = be.nombreCosto,
                          .status = be.status,
                          .codigo = be.codigo,
                          .detalle = be.detalle,
                          .subdetalle = be.subdetalle,
                          .inicio = be.inicio,
                          .finaliza = be.finaliza,
                          .director = be.director,
                          .procesado = be.procesado,
                          .jerarquia = be.jerarquia,
                          .usuarioActualizacion = be.usuarioActualizacion,
                .fechaActualizacion = be.fechaActualizacion
                    }
                HeliosData.recursoCosto.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                be.idCosto = obj.idCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function GetProductosProducidosEnPlanta(be As recursoCosto) As List(Of recursoCosto)
        Dim obj As New recursoCosto
        Dim lista As New List(Of recursoCosto)
        Dim con = (From n In HeliosData.recursoCosto
                   Where n.subtipo = TipoCosto.ProductoProducido And n.idpadre = be.idCosto
                   Select n.idCosto,
                       n.inicio,
                       n.detalle,
                       n.cantidad,
                       n.status,
                       n.codigo,
                       EnvioAlmacen = CType((Aggregate c In HeliosData.documentocompradetalle
                                           Where c.idCosto = n.idCosto
                                               Into Count(c.idDocumento)), Int16?)).ToList


        For Each i In con
            obj = New recursoCosto
            obj.inicio = i.inicio
            obj.idCosto = i.idCosto
            obj.detalle = i.detalle
            obj.cantidad = i.cantidad
            obj.status = i.status
            obj.codigo = i.codigo
            obj.EnvioAlmacen = If(i.EnvioAlmacen.GetValueOrDefault = 0, "No", "Si")
            lista.Add(obj)
        Next


        Return lista
        '  Return HeliosData.recursoCosto.Where(Function(o) o.subtipo = TipoCosto.ProductoProducido And o.idpadre = be.idCosto).ToList
    End Function

    Public Function GetCantidadEntregadaProduccion(be As recursoCosto) As recursoCosto
        Dim obj As New recursoCosto

        Dim con = (From c In HeliosData.recursoCosto _
                   Where _
                   CLng(c.idCosto) = be.idCosto _
                   Select _
                   c.idCosto, _
                   c.nombreCosto, _
                   c.cantidad, _
                   CantProducida = (CType((Aggregate t1 In _
                                           (From prod In HeliosData.recursoCosto _
                                            Where _
                                            prod.idpadre = c.idCosto And _
                                            prod.subtipo = "PPR" _
                                            Select New With {
                                                prod.cantidad _
                                            }) Into Sum(t1.cantidad)), Decimal?))).FirstOrDefault


        obj = New recursoCosto
        obj.idCosto = con.idCosto
        obj.nombreCosto = con.nombreCosto
        obj.cantidad = con.cantidad.GetValueOrDefault - con.CantProducida.GetValueOrDefault

        Return obj

    End Function



    Public Sub CulminarOrdenProduccionParcial(Be As recursoCosto)
        Dim docBL As New documentoBL
        Dim asientoBL As New AsientoBL
        Using ts As New TransactionScope

            Dim obj = HeliosData.recursoCosto.Where(Function(o) o.idCosto = Be.idCosto).FirstOrDefault
            obj.status = Be.status

            Be.CustomDocumento.idProyecto = Be.idCosto
            docBL.Insert(Be.CustomDocumento)
            asientoBL.SavebyGroupDoc(Be.CustomDocumento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarProduccionParcial(be As recursoCosto)
        Dim docBL As New documentoBL
        Dim asientoBL As New AsientoBL
        Using ts As New TransactionScope
            GrabarProduccion(be)
            be.CustomDocumento.idProyecto = be.idCosto
            docBL.Insert(be.CustomDocumento)
            asientoBL.SavebyGroupDoc(be.CustomDocumento)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarCostoOne_2(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                obj = New recursoCosto With
                      {
                          .idpadre = be.idpadre,
                          .tipo = be.tipo,
                          .subtipo = be.subtipo,
                          .nombreCosto = be.nombreCosto,
                          .cantidad = be.cantidad,
                          .status = be.status,
                          .codigo = be.codigo,
                          .detalle = be.detalle,
                          .subdetalle = be.subdetalle,
                          .inicio = be.inicio,
                          .finaliza = be.finaliza,
                          .director = be.director,
                          .procesado = be.procesado,
                          .jerarquia = be.jerarquia,
                          .usuarioActualizacion = be.usuarioActualizacion,
                .fechaActualizacion = be.fechaActualizacion
                    }
                HeliosData.recursoCosto.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                be.idCosto = obj.idCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarProduccion(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                obj = New recursoCosto With
                      {
                      .costo = be.costo,
                          .idpadre = be.idpadre,
                          .tipo = be.tipo,
                          .subtipo = be.subtipo,
                          .nombreCosto = be.nombreCosto,
                          .cantidad = be.cantidad,
                          .status = be.status,
                          .codigo = be.codigo,
                          .detalle = be.detalle,
                          .subdetalle = be.subdetalle,
                          .inicio = be.inicio,
                          .finaliza = be.finaliza,
                          .director = be.director,
                          .procesado = be.procesado,
                          .jerarquia = be.jerarquia,
                          .usuarioActualizacion = be.usuarioActualizacion,
                .fechaActualizacion = be.fechaActualizacion
                    }
                HeliosData.recursoCosto.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                be.idCosto = obj.idCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarCostoTarea(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                obj = New recursoCosto With
                      {
                          .idpadre = be.idpadre,
                          .tipo = be.tipo,
                          .subtipo = be.subtipo,
                          .nombreCosto = be.nombreCosto,
                          .status = be.status,
                          .codigo = be.codigo,
                          .detalle = be.detalle,
                          .subdetalle = be.subdetalle,
                          .inicio = be.inicio,
                          .finaliza = be.finaliza,
                          .director = be.director,
                          .procesado = be.procesado,
                          .usuarioActualizacion = be.usuarioActualizacion,
                .fechaActualizacion = be.fechaActualizacion
                    }
                HeliosData.recursoCosto.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                be.idCosto = obj.idCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EditarCostoTarea(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                Dim costo As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault

                If Not IsNothing(costo) Then
                    costo.tipo = be.tipo
                    costo.subtipo = be.subtipo
                    costo.nombreCosto = be.nombreCosto
                    costo.detalle = be.detalle
                    costo.subdetalle = be.subdetalle
                    costo.inicio = be.inicio
                    costo.finaliza = be.finaliza
                    costo.director = be.director
                    costo.usuarioActualizacion = be.usuarioActualizacion
                    costo.fechaActualizacion = be.fechaActualizacion
                End If
                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarCostoProceso(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope
                obj = New recursoCosto With
                      {
                          .idpadre = be.idpadre,
                          .tipo = be.tipo,
                          .subtipo = be.subtipo,
                          .nombreCosto = be.nombreCosto,
                          .status = be.status,
                          .codigo = be.codigo,
                          .detalle = be.detalle,
                          .subdetalle = be.subdetalle,
                          .inicio = be.inicio,
                          .finaliza = be.finaliza,
                          .procesado = be.procesado,
                          .usuarioActualizacion = be.usuarioActualizacion,
                .fechaActualizacion = be.fechaActualizacion
                    }
                HeliosData.recursoCosto.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                be.idCosto = obj.idCosto
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EditarCosto(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope

                obj = (From n In HeliosData.recursoCosto _
                      Where n.idCosto = be.idCosto).FirstOrDefault

                If Not IsNothing(obj) Then

                    obj.tipo = be.tipo
                    obj.subtipo = be.subtipo
                    obj.nombreCosto = be.nombreCosto
                    obj.status = be.status
                    obj.codigo = be.codigo
                    obj.detalle = be.detalle
                    obj.subdetalle = be.subdetalle
                    obj.inicio = be.inicio
                    obj.finaliza = be.finaliza
                    obj.procesado = be.procesado
                    obj.director = be.director
                    obj.usuarioActualizacion = be.usuarioActualizacion
                    obj.fechaActualizacion = be.fechaActualizacion

                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarCosto(be As recursoCosto)
        Dim obj As New recursoCosto
        Try
            Using ts As New TransactionScope

                obj = (From n In HeliosData.recursoCosto _
                      Where n.idCosto = be.idCosto).FirstOrDefault

                If Not IsNothing(obj) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarCostoPadre(be As recursoCosto)
        Dim ObjCompra As New documentocompradetalle
        Dim ObjCaja As New documentoCaja
        Dim obj As New recursoCosto
        Using ts As New TransactionScope
            Dim detalle = (From det In HeliosData.recursoCostoDetalle _
                          Join costo In HeliosData.recursoCosto _
                          On costo.idCosto Equals det.idCosto _
                          Where costo.idpadre = be.idCosto).ToList

            For Each i In detalle
                ObjCaja = New documentoCaja
                ObjCompra = New documentocompradetalle
                ObjCompra = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.det.itemRef).FirstOrDefault

                If Not IsNothing(ObjCompra) Then
                    ObjCompra.idCosto = Nothing
                    ObjCompra.tipoCosto = Nothing
                End If

                ObjCaja = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = i.det.documentoRef).FirstOrDefault
                If Not IsNothing(ObjCaja) Then
                    ObjCaja.estado = "N"
                End If
            Next

            Dim con = (From n In detalle _
                      Select n.det.documentoRef).Distinct

            con.ToList()

            Dim listParam As New List(Of String)
            listParam.Add("ACCA") 'CONTRATOS DE CONSTRUCCION
            listParam.Add("OPCN") ' ORDENES DE PRODUCCION


            For Each i In con
                Dim asiento As List(Of asiento) = HeliosData.asiento.Where(Function(o) o.idDocumento = i.Value And listParam.Contains(o.tipoAsiento)).ToList
                For Each a In asiento
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(a)
                Next
            Next


            obj = (From n In HeliosData.recursoCosto _
                   Where n.idCosto = be.idCosto).FirstOrDefault

            If Not IsNothing(obj) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
            End If

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EditarStatusCostoByID(be As recursoCosto)
        Using ts As New TransactionScope
            Dim obj As recursoCosto = HeliosData.recursoCosto.Where(Function(o) o.idCosto = be.idCosto).FirstOrDefault

            If Not IsNothing(obj) Then
                obj.status = be.status
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
