Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class servicioBL
    Inherits BaseBL

    Public Sub EditarTipoPrestamo(i As servicio)
        Using ts As New TransactionScope
            Dim obj = (From n In HeliosData.servicio _
                  Where n.idServicio = i.idServicio).FirstOrDefault

            obj.descripcion = i.descripcion
            'obj.cuenta = i.cuenta
            'obj.tipo = i.tipo

            HeliosData.SaveChanges()
            ts.Complete()
        End Using


    End Sub



    Public Function SaveTipoPrestamoPadre(servicioBE As servicio) As Integer
        Dim servicioNuevo As New servicio()
        Try
            Dim obj = (From n In HeliosData.servicio _
                 Where n.descripcion = servicioBE.descripcion And n.tipo = servicioBE.tipo).Count

            If obj = 0 Then
                Using ts As New TransactionScope
                    servicioNuevo = New servicio()
                    servicioNuevo.codigo = servicioBE.codigo
                    servicioNuevo.descripcion = servicioBE.descripcion
                    servicioNuevo.cuenta = servicioBE.cuenta
                    servicioNuevo.cuentaH = servicioBE.cuentaH
                    servicioNuevo.observaciones = servicioBE.observaciones
                    servicioNuevo.estado = servicioBE.estado
                    servicioNuevo.tipo = servicioBE.tipo
                    HeliosData.servicio.Add(servicioNuevo)
                    HeliosData.SaveChanges()
                    ts.Complete()
                    Return servicioNuevo.idServicio
                End Using

            Else
                Return 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function SaveTipoPrestamo(servicioBE As servicio, hijopred As List(Of servicio)) As Integer
        Dim servicioNuevo As New servicio()
        Dim idpadre As Integer
        Try
            idpadre = Me.SaveTipoPrestamoPadre(servicioBE)

            Using ts As New TransactionScope
                If idpadre = 0 Then

                    Throw New Exception("Este tipo de Prestamo ya existe")
                Else
                    For Each i In hijopred
                        servicioNuevo = New servicio()
                        servicioNuevo.codigo = i.codigo
                        servicioNuevo.idPadre = idpadre
                        servicioNuevo.descripcion = i.descripcion
                        servicioNuevo.cuenta = i.cuenta
                        servicioNuevo.cuentaH = i.cuentaH
                        servicioNuevo.cuentaDev = i.cuentaDev
                        servicioNuevo.cuentaDevH = i.cuentaDevH
                        servicioNuevo.observaciones = i.observaciones
                        servicioNuevo.estado = i.estado
                        servicioNuevo.valor = i.valor
                        servicioNuevo.tipo = i.tipo
                        HeliosData.servicio.Add(servicioNuevo)
                    Next
                    HeliosData.SaveChanges()
                    ts.Complete()
                    Return servicioNuevo.idServicio
                End If
            End Using


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUbicarConceptosPrestamo(codigo As String, tipoPrestamo As String) As List(Of servicio)
        Dim lista As New List(Of servicio)
        Dim objServ As New servicio

        Dim consulta = (From a In HeliosData.servicio
                 Where a.codigo = codigo And a.tipo = tipoPrestamo).ToList

        For Each i In consulta
            objServ = New servicio
            objServ.idServicio = i.idServicio
            objServ.descripcion = i.descripcion
            objServ.cuenta = i.cuenta
            objServ.valor = i.valor
            objServ.tipo = i.tipo
            lista.Add(objServ)
        Next

        Return lista
    End Function

    Public Sub UpdateConceptoPrestamo(i As servicio)
        Using ts As New TransactionScope
            Dim obj = (From n In HeliosData.servicio _
                  Where n.idServicio = i.idServicio).FirstOrDefault

            obj.descripcion = i.descripcion
            obj.cuenta = i.cuenta
            obj.valor = i.valor
            obj.cuentaH = i.cuentaH
            obj.cuentaDev = i.cuentaDev
            obj.cuentaDevH = i.cuentaDevH

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function SaveConceptosPrestamo(servicioBE As servicio) As Integer
        Dim servicioNuevo As New servicio()
        Try

            Dim obj = (From n In HeliosData.servicio _
                 Where n.idPadre = servicioBE.idPadre And
                 n.descripcion = servicioBE.descripcion And
                 n.codigo = servicioBE.codigo).Count

            Using ts As New TransactionScope

                If obj = 0 Then
                    servicioNuevo = New servicio()
                    servicioNuevo.idPadre = servicioBE.idPadre
                    servicioNuevo.codigo = servicioBE.codigo
                    servicioNuevo.descripcion = servicioBE.descripcion
                    servicioNuevo.cuenta = servicioBE.cuenta
                    servicioNuevo.cuentaH = servicioBE.cuentaH
                    servicioNuevo.cuentaDev = servicioBE.cuentaDev
                    servicioNuevo.cuentaDevH = servicioBE.cuentaDevH
                    servicioNuevo.observaciones = servicioBE.observaciones
                    servicioNuevo.estado = servicioBE.estado
                    servicioNuevo.valor = servicioBE.valor
                    servicioNuevo.tipo = servicioBE.tipo
                    HeliosData.servicio.Add(servicioNuevo)
                    HeliosData.SaveChanges()
                    ts.Complete()
                    Return servicioNuevo.idServicio
                Else
                    Throw New Exception("Este Concepto ya existe")


                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function SaveServicio(servicioBE As servicio) As Integer
        Dim servicioNuevo As New servicio()
        Try
            Using ts As New TransactionScope
                servicioNuevo = New servicio()
                servicioNuevo.idPadre = servicioBE.idPadre
                servicioNuevo.descripcion = servicioBE.descripcion
                servicioNuevo.estado = "1"
                servicioNuevo.cuenta = servicioBE.cuenta
                HeliosData.servicio.Add(servicioNuevo)
                HeliosData.SaveChanges()
                ts.Complete()
                Return servicioNuevo.idServicio
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateServicio(i As servicio)
        Using ts As New TransactionScope
            Dim obj = (From n In HeliosData.servicio _
                  Where n.idServicio = i.idServicio).FirstOrDefault

            obj.descripcion = i.descripcion

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Function ListadoServiciostipo(ByVal tipo As String) As List(Of servicio)
        Return (From n In HeliosData.servicio _
               Where n.idPadre Is Nothing And n.codigo = tipo Order By n.cuenta Ascending).ToList
    End Function


    Public Function ListadoServiciosHijosXIdTipo(servicioBE As servicio) As List(Of servicio)
        Return (From n In HeliosData.servicio _
               Where n.idPadre = servicioBE.idPadre And n.codigo = servicioBE.codigo).ToList
    End Function

    Public Function SaveServicioPadre(servicioBE As servicio) As Integer
        Try
            Using ts As New TransactionScope
                HeliosData.servicio.Add(servicioBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return 1
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteHijos(intIdServicio As Integer)
        Dim consulta As List(Of servicio) = HeliosData.servicio.Where(Function(o) o.idPadre = intIdServicio).ToList
        For Each obj In consulta
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
        Next
        HeliosData.SaveChanges()
    End Sub

    Public Sub EliminarServicioPadreHijo(servicioBE As servicio)
        Try
            Using ts As New TransactionScope
                Dim servicio As servicio = HeliosData.servicio.Where(Function(o) o.idServicio = servicioBE.idServicio).FirstOrDefault
                ' Dim servicioHijo As List(Of servicio) = HeliosData.servicio.Where(Function(o) o.idPadre = servicioBE.idServicio).ToList
                If Not IsNothing(servicio) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(servicio)
                    HeliosData.SaveChanges()
                End If

                DeleteHijos(servicioBE.idServicio)
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarPadre(i As servicio)
        Try

            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.servicio
                           Where n.idServicio = i.idServicio And n.idEmpresa = i.idEmpresa).FirstOrDefault

                If (Not IsNothing(obj)) Then
                    If (i.tipo = "ESTADO") Then
                        obj.estado = i.estado

                    ElseIf (i.tipo = "DESCRIPCION") Then
                        obj.descripcion = i.descripcion
                        obj.observaciones = i.observaciones
                    End If
                    HeliosData.SaveChanges()
                    ts.Complete()
                Else
                    Throw New Exception("VERIFICAR DATOS")
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ListadoServicios(SERVCIOBE As servicio) As List(Of servicio)
        Return (From n In HeliosData.servicio Where n.idEmpresa = SERVCIOBE.idEmpresa).ToList
    End Function

    Public Function ListadoServiciosHijos() As List(Of servicio)
        Return (From n In HeliosData.servicio _
               Where n.idPadre IsNot Nothing).ToList
    End Function

    Public Function ListadoServiciosHijosXtipo(servicioBE As servicio) As List(Of servicio)
        Return (From n In HeliosData.servicio _
               Where n.idPadre IsNot Nothing AndAlso n.codigo = servicioBE.codigo).ToList
    End Function

    Public Function UbicarServicioPorId(servicioBE As servicio) As servicio
        Return (From n In HeliosData.servicio _
             Where n.idServicio = servicioBE.idServicio).FirstOrDefault
    End Function

    Public Function Save(servicioBE As servicio) As Integer
        Dim servicioNuevo As New servicio()
        Try
            Using ts As New TransactionScope
                servicioNuevo = New servicio()
                servicioNuevo.codigo = servicioBE.codigo
                servicioNuevo.idPadre = servicioBE.idPadre
                servicioNuevo.descripcion = servicioBE.descripcion
                servicioNuevo.cuenta = servicioBE.cuenta
                servicioNuevo.observaciones = servicioBE.observaciones
                servicioNuevo.estado = servicioBE.estado
                HeliosData.servicio.Add(servicioNuevo)
                HeliosData.SaveChanges()
                ts.Complete()
                Return servicioNuevo.idServicio
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EliminarServicio(servicioBE As servicio)
        Try
            Using ts As New TransactionScope
                Dim servicio As servicio = HeliosData.servicio.Where(Function(o) o.idServicio = servicioBE.idServicio).FirstOrDefault
                If Not IsNothing(servicio) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(servicio)
                    HeliosData.SaveChanges()
                    ts.Complete()
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '************************************
    Public Function InsertItemServicio(ByVal ProductoBE As List(Of servicio)) As Integer

        Dim preciosBL As New ConfiguracionPrecioProductoBL
        Dim codigoProducto = 0
        ' Dim varAlmacen As Integer
        Try

            Using ts As New TransactionScope

                For Each itemServicio In ProductoBE
                    codigoProducto = GrabarSolo(itemServicio)
                    If itemServicio.CustomPrecios IsNot Nothing Then
                        If itemServicio.CustomPrecios.Count > 0 Then
                            preciosBL.GrabarListadoPrecios(itemServicio.CustomPrecios, codigoProducto)
                        End If
                    End If
                    'codigoProducto = GrabarSolo(ProductoBE)
                    'If ProductoBE.CustomPrecios IsNot Nothing Then
                    '    If ProductoBE.CustomPrecios.Count > 0 Then
                    '        preciosBL.GrabarListadoPrecios(ProductoBE.CustomPrecios, codigoProducto)
                    '    End If
                    'End If
                    HeliosData.SaveChanges()
                Next

                ts.Complete()

            End Using


        Catch ex As Exception
            Throw ex
        End Try

        Return codigoProducto 'objDEtalle.codigodetalle
    End Function

    Public Function InsertItemServicioSimple(ByVal ProductoBE As servicio) As Integer

        Dim preciosBL As New ConfiguracionPrecioProductoBL
        Dim codigoProducto = 0
        ' Dim varAlmacen As Integer
        Try

            Using ts As New TransactionScope


                codigoProducto = GrabarSolo(ProductoBE)
                If ProductoBE.CustomPrecios IsNot Nothing Then
                    If ProductoBE.CustomPrecios.Count > 0 Then
                        preciosBL.GrabarListadoPrecios(ProductoBE.CustomPrecios, codigoProducto)
                    End If
                End If
                'codigoProducto = GrabarSolo(ProductoBE)
                'If ProductoBE.CustomPrecios IsNot Nothing Then
                '    If ProductoBE.CustomPrecios.Count > 0 Then
                '        preciosBL.GrabarListadoPrecios(ProductoBE.CustomPrecios, codigoProducto)
                '    End If
                'End If
                HeliosData.SaveChanges()


                ts.Complete()

            End Using


        Catch ex As Exception
            Throw ex
        End Try

        Return codigoProducto 'objDEtalle.codigodetalle
    End Function

    Function GrabarSolo(ByVal ProductoBE As servicio) As Integer
        Dim servicioNuevo As New servicio
        Dim preciosBL As New ConfiguracionPrecioProductoBL
        ' Dim varAlmacen As Integer
        Try
            'If Not IsNothing(ProductoBE.codigo) Then
            '    If ProductoBE.codigo.Trim.Length > 0 Then
            '        Dim validarCodigoBar As Integer = HeliosData.servicio.Where(Function(o) o.codigo = ProductoBE.codigo).Count

            '        If validarCodigoBar > 0 Then
            '            Throw New Exception("El producto ya esta registrado, ingrese otro.")
            '        End If
            '    End If
            'Else

            'End If

            Dim consulta As Integer = HeliosData.servicio.Where(Function(o) _
                                                                            o.descripcion = ProductoBE.descripcion).Count

            If consulta > 0 Then
                Throw New Exception("El producto ya esta registrado, ingrese otro.")
            End If

            Using ts As New TransactionScope
                '    objDEtalle = New detalleitems
                servicioNuevo = New servicio
                With servicioNuevo
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    servicioNuevo.idEmpresa = ProductoBE.idEmpresa
                    servicioNuevo.idEstablecimiento = ProductoBE.idEstablecimiento
                    servicioNuevo.idItemServicio = ProductoBE.idItemServicio
                    servicioNuevo.idPadre = ProductoBE.idPadre
                    servicioNuevo.fecha = ProductoBE.fecha
                    servicioNuevo.descripcion = ProductoBE.descripcion
                    servicioNuevo.unidadMedida = ProductoBE.unidadMedida
                    servicioNuevo.tipo = ProductoBE.tipo
                    servicioNuevo.tipoServicio = ProductoBE.tipoServicio
                    servicioNuevo.tipoExist = ProductoBE.tipoExist
                    servicioNuevo.idProveedor = ProductoBE.idProveedor
                    servicioNuevo.codigo = ProductoBE.codigo
                    servicioNuevo.costo = ProductoBE.costo
                    servicioNuevo.valor = ProductoBE.valor
                    servicioNuevo.categoria = ProductoBE.categoria
                    servicioNuevo.subCategoria = ProductoBE.subCategoria
                    servicioNuevo.cuenta = ProductoBE.cuenta
                    servicioNuevo.cuentaH = ProductoBE.cuentaH
                    servicioNuevo.cuentaDev = ProductoBE.cuentaDev
                    servicioNuevo.cuentaDevH = ProductoBE.cuentaDevH
                    servicioNuevo.observaciones = ProductoBE.observaciones
                    servicioNuevo.estado = ProductoBE.estado
                    servicioNuevo.usuarioActualizacion = ProductoBE.usuarioActualizacion
                    servicioNuevo.fechaActualizacion = ProductoBE.fechaActualizacion
                End With
                HeliosData.servicio.Add(servicioNuevo)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try
        Return servicioNuevo.idServicio
    End Function

    Public Sub CambiarEstadoItemServicio(be As servicio)
        Dim item = HeliosData.servicio.Where(Function(o) o.idServicio = be.idServicio).Single
        Using ts As New TransactionScope
            item.estado = be.estado
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetServicioByEmpresaSinPrecios(empresa As String, tipo As String) As List(Of servicio)
        Dim obj As New servicio
        Dim Lista As New List(Of servicio)

        Dim consulta = HeliosData.usp_GetProductsServicioEmpresa(empresa, tipo).ToList


        Dim datosPreciosMenor() As String
        Dim datosPreciosMayor() As String
        Dim datosPreciosGranMenor() As String

        Dim ValorprecioMenorMN As Decimal = 0
        Dim ValorprecioMenorME As Decimal = 0
        Dim ValorprecioMayorMN As Decimal = 0
        Dim ValorprecioMayorME As Decimal = 0
        Dim ValorprecioGMayorMN As Decimal = 0
        Dim ValorprecioGMayorME As Decimal = 0
        For Each i In consulta
            obj = New servicio

            '   Dim valorNulo() As String = {"0.00", "0.00"}
            Dim precMenor As String = i.menor
            Dim precMayor As String = i.mayor
            Dim precGMayor As String = i.granMayor


            If precMenor IsNot Nothing Then
                datosPreciosMenor = precMenor.Split(New Char() {"|"c})
                ValorprecioMenorMN = datosPreciosMenor(0)
                ValorprecioMenorME = datosPreciosMenor(1)
            Else
                ValorprecioMenorMN = 0
                ValorprecioMenorME = 0
            End If

            If precMayor IsNot Nothing Then
                datosPreciosMayor = precMayor.Split(New Char() {"|"c})
                ValorprecioMayorMN = datosPreciosMayor(0)
                ValorprecioMayorME = datosPreciosMayor(1)
            Else
                ValorprecioMayorMN = 0
                ValorprecioMayorME = 0
            End If

            If precGMayor IsNot Nothing Then
                datosPreciosGranMenor = precGMayor.Split(New Char() {"|"c})
                ValorprecioGMayorMN = datosPreciosGranMenor(0)
                ValorprecioGMayorME = datosPreciosGranMenor(1)
            Else
                ValorprecioGMayorMN = 0
                ValorprecioGMayorME = 0
            End If

            If i.UltimaEntrada IsNot Nothing Then
                Dim s As String = i.UltimaEntrada

                Dim datosEntrada() As String = s.Split(New Char() {","c})


                '   Dim parts As String() = s.Split(New Char() {","c})

                Dim tipcompra As String = datosEntrada(0)
                Dim fechacompra As String = datosEntrada(1)
                Dim destino As String = datosEntrada(2)
                Dim baseimponible = datosEntrada(3)
                Dim total = datosEntrada(4)
                Dim cant = datosEntrada(5)

                'obj.CustomDetalleCompra = New documentocompradetalle With
                '{
                '    .FechaDoc = fechacompra,' i.UltimaCompra.comp.fechaDoc,
                '    .monto1 = cant,'i.UltimaCompra.d.monto1,
                '    .destino = destino,' i.UltimaCompra.d.destino,
                '    .importe = total'i.UltimaCompra.d.importe
                '}
                'obj.CustomDetalleCompra.documentocompra = New documentocompra With
                '{
                '.tipoCompra = tipcompra' i.UltimaCompra.comp.tipoCompra
                '}
            End If

            'If i.UltimaEntradaInicio IsNot Nothing Then
            '    obj.InventarioInicio = i.UltimaEntradaInicio
            'End If

            obj.idServicio = i.idServicio
            obj.descripcion = i.descripcion
            obj.categoria = i.GrupoName
            obj.subCategoria = i.MarcaName
            'obj.codigo = i.codigo
            obj.tipoExist = i.tipoExist
            obj.unidadMedida = i.unidadMedida
            'obj.unidad2 = i.MarcaName
            'obj.presentacion = String.Empty 'i.presentacion
            obj.codigo = i.codigo
            'obj.precioCompra = i.precioCompra
            obj.menor = ValorprecioMenorMN ' i.menor.GetValueOrDefault '  i.precioMenor.GetValueOrDefault
            obj.mayor = ValorprecioMayorMN ' i.mayor.GetValueOrDefault ' i.PrecioMayor.GetValueOrDefault
            obj.gMayor = ValorprecioGMayorMN ' i.granMayor.GetValueOrDefault ' i.PrecioGranMayor.GetValueOrDefault

            obj.menorME = ValorprecioMenorME ' 0 ' i.precioMenorME.GetValueOrDefault
            obj.mayorME = ValorprecioMayorME '0 ' i.PrecioMayorME.GetValueOrDefault
            obj.gMayorME = ValorprecioGMayorME ' 0 ' i.PrecioGranMayorME.GetValueOrDefault
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetServicioSinAlmacenSearchText(empresa As String, search As String) As List(Of servicio)
        'GetServicioSinAlmacenSearchText = New List(Of servicio)
        'Dim consulta = (From art In HeliosData.servicio
        '                Where
        '                   art.idEmpresa = empresa And
        '                    art.descripcion.Trim.Contains(search) And
        '                   Not (Not _
        '                   (From TotalesAlmacen In HeliosData.totalesAlmacen
        '                    Where
        '                        TotalesAlmacen.idItem = art.idServicio
        '                    Select New With {
        '                        TotalesAlmacen
        '                        }).FirstOrDefault() Is Nothing)
        '                Select
        '                   codigodetalle = art.idServicio,
        '                   idItem = art.idServicio,
        '                   idEmpresa = art.idEmpresa,
        '                   idEstablecimiento = art.idEstablecimiento,
        '                   cuenta = art.cuenta,
        '                   descripcionItem = art.descripcion,
        '                                            unidad1 = art.unidadMedida,
        '                                           TipoExistencia = art.tipoExist,
        '                                  tipoProducto = art.tipoServicio,
        '                                    codigo = art.codigo,
        '                               estado = art.estado,
        '                   usuarioActualizacion = art.usuarioActualizacion,
        '                   fechaActualizacion = art.fechaActualizacion,
        '                    precioMenor = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = art.idServicio And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 1 And
        '                          configuracionPrecioProductoes.tipoModalidad = "GS" And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
        '                                    And configuracionPrecioProductoes0.idproducto = art.idServicio And
        '                                          configuracionPrecioProductoes0.tipoModalidad = "GS"
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioMN
        '                          }).FirstOrDefault().precioMN)),
        '                    precioMenorME = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = art.idServicio And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 1 And
        '                          configuracionPrecioProductoes.tipoModalidad = "GS" And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
        '                                    And configuracionPrecioProductoes0.idproducto = art.idServicio And
        '                                          configuracionPrecioProductoes0.tipoModalidad = "GS"
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioME
        '                          }).FirstOrDefault().precioME)),
        '                    PrecioMayor = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = art.idServicio And
        '                            configuracionPrecioProductoes.tipoModalidad = "GS" And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 2 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
        '                                    And configuracionPrecioProductoes0.idproducto = art.idServicio And
        '                                          configuracionPrecioProductoes0.tipoModalidad = "GS"
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioMN
        '                          }).FirstOrDefault().precioMN)),
        '                    PrecioMayorME = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = art.idServicio And
        '                            configuracionPrecioProductoes.tipoModalidad = "GS" And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 2 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
        '                                    And configuracionPrecioProductoes0.idproducto = art.idServicio And
        '                                          configuracionPrecioProductoes0.tipoModalidad = "GS"
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioME
        '                          }).FirstOrDefault().precioME)),
        '                    PrecioGranMayor = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = art.idServicio And
        '                            configuracionPrecioProductoes.tipoModalidad = "GS" And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 3 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
        '                                    And configuracionPrecioProductoes0.idproducto = art.idServicio And
        '                                          configuracionPrecioProductoes0.tipoModalidad = "GS"
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioMN
        '                          }).FirstOrDefault().precioMN)),
        '                    PrecioGranMayorME = (
        '                    ((From
        '                          configuracionPrecioProductoes
        '                          In HeliosData.configuracionPrecioProducto
        '                      Where
        '                          configuracionPrecioProductoes.idproducto = art.idServicio And
        '                            configuracionPrecioProductoes.tipoModalidad = "GS" And
        '                          CLng(configuracionPrecioProductoes.idPrecio) = 3 And
        '                          configuracionPrecioProductoes.fecha =
        '                          (Aggregate t2 In
        '                               (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                Where
        '                                    CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
        '                                    And configuracionPrecioProductoes0.idproducto = art.idServicio And
        '                                          configuracionPrecioProductoes0.tipoModalidad = "GS"
        '                                Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                      Select New With
        '                          {
        '                          configuracionPrecioProductoes.precioME
        '                          }).FirstOrDefault().precioME))
        ').ToList

        'For Each i In consulta
        '    GetServicioSinAlmacenSearchText.Add(New servicio With
        '                                {
        '                                .idServicio = i.codigodetalle,
        '                                 .idEmpresa = i.idEmpresa,
        '                                .idEstablecimiento = i.idEstablecimiento,
        '                                .cuenta = i.cuenta,
        '                                .descripcion = i.descripcionItem,
        '                                                                      .unidadMedida = i.unidad1,
        '                                                                      .tipoExist = i.TipoExistencia,
        '                                                                       .tipo = i.tipoProducto,
        '                                                                      .codigo = i.codigo,
        '                                                                       .estado = i.estado,
        '                                .usuarioActualizacion = i.usuarioActualizacion,
        '                                .fechaActualizacion = i.fechaActualizacion,
        '                                         .menor = i.precioMenor.GetValueOrDefault,
        '                                         .mayor = i.PrecioMayor.GetValueOrDefault,
        '                                         .gMayor = i.PrecioGranMayor.GetValueOrDefault,
        '                                         .menorME = i.precioMenorME.GetValueOrDefault,
        '                                         .mayorME = i.PrecioMayorME.GetValueOrDefault,
        '                                         .gMayorME = i.PrecioGranMayorME.GetValueOrDefault
        '                                })
        'Next

        GetServicioSinAlmacenSearchText = New List(Of servicio)
        Dim consulta = (From art In HeliosData.servicio
                        Where
                           art.idEmpresa = empresa And
                            art.descripcion.Trim.Contains(search)
                        Select
                           codigodetalle = art.idServicio,
                           idItem = art.idServicio,
                           idEmpresa = art.idEmpresa,
                           idEstablecimiento = art.idEstablecimiento,
                           cuenta = art.cuenta,
                           descripcionItem = art.descripcion,
                                                    unidad1 = art.unidadMedida,
                                                   TipoExistencia = art.tipoExist,
                                          tipoProducto = art.tipoServicio,
                                            codigo = art.codigo,
                                       estado = art.estado,
                           usuarioActualizacion = art.usuarioActualizacion,
                           fechaActualizacion = art.fechaActualizacion,
                            precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.idServicio And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.tipoModalidad = "GS" And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = art.idServicio And
                                                  configuracionPrecioProductoes0.tipoModalidad = "GS"
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            precioMenorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.idServicio And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.tipoModalidad = "GS" And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = art.idServicio And
                                                  configuracionPrecioProductoes0.tipoModalidad = "GS"
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.idServicio And
                                    configuracionPrecioProductoes.tipoModalidad = "GS" And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = art.idServicio And
                                                  configuracionPrecioProductoes0.tipoModalidad = "GS"
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.idServicio And
                                    configuracionPrecioProductoes.tipoModalidad = "GS" And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = art.idServicio And
                                                  configuracionPrecioProductoes0.tipoModalidad = "GS"
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                            PrecioGranMayor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.idServicio And
                                    configuracionPrecioProductoes.tipoModalidad = "GS" And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = art.idServicio And
                                                  configuracionPrecioProductoes0.tipoModalidad = "GS"
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN)),
                            PrecioGranMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = art.idServicio And
                                    configuracionPrecioProductoes.tipoModalidad = "GS" And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = art.idServicio And
                                                  configuracionPrecioProductoes0.tipoModalidad = "GS"
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME))
        ).ToList

        For Each i In consulta
            GetServicioSinAlmacenSearchText.Add(New servicio With
                                        {
                                        .idServicio = i.codigodetalle,
                                         .idEmpresa = i.idEmpresa,
                                        .idEstablecimiento = i.idEstablecimiento,
                                        .cuenta = i.cuenta,
                                        .descripcion = i.descripcionItem,
                                                                              .unidadMedida = i.unidad1,
                                                                              .tipoExist = i.TipoExistencia,
                                                                               .tipo = i.tipoProducto,
                                                                              .codigo = i.codigo,
                                                                               .estado = i.estado,
                                        .usuarioActualizacion = i.usuarioActualizacion,
                                        .fechaActualizacion = i.fechaActualizacion,
                                                 .menor = i.precioMenor.GetValueOrDefault,
                                                 .mayor = i.PrecioMayor.GetValueOrDefault,
                                                 .gMayor = i.PrecioGranMayor.GetValueOrDefault,
                                                 .menorME = i.precioMenorME.GetValueOrDefault,
                                                 .mayorME = i.PrecioMayorME.GetValueOrDefault,
                                                 .gMayorME = i.PrecioGranMayorME.GetValueOrDefault
                                        })
        Next

    End Function

    Function GetUbicaServicioID(intIdProducto As Integer) As servicio
        Dim consulta As New servicio
        consulta = (From a In HeliosData.servicio
                    Where a.idServicio = intIdProducto).First
        Return consulta
    End Function

    Public Function updateItemServicio(ByVal ProductoBE As servicio) As Integer

        Try

            Using ts As New TransactionScope

                Dim servicioNuevo = (From n In HeliosData.servicio
                                     Where n.idServicio = ProductoBE.idServicio).FirstOrDefault

                If (Not IsNothing(servicioNuevo)) Then
                    With servicioNuevo
                        .Action = Business.Entity.BaseBE.EntityAction.INSERT
                        servicioNuevo.idEmpresa = ProductoBE.idEmpresa
                        servicioNuevo.idEstablecimiento = ProductoBE.idEstablecimiento
                        servicioNuevo.idItemServicio = ProductoBE.idItemServicio
                        servicioNuevo.idPadre = ProductoBE.idPadre
                        servicioNuevo.fecha = ProductoBE.fecha
                        servicioNuevo.descripcion = ProductoBE.descripcion
                        servicioNuevo.unidadMedida = ProductoBE.unidadMedida
                        servicioNuevo.tipo = ProductoBE.tipo
                        servicioNuevo.tipoServicio = ProductoBE.tipoServicio
                        servicioNuevo.tipoExist = ProductoBE.tipoExist
                        servicioNuevo.idProveedor = ProductoBE.idProveedor
                        servicioNuevo.codigo = ProductoBE.codigo
                        servicioNuevo.costo = ProductoBE.costo
                        servicioNuevo.valor = ProductoBE.valor
                        servicioNuevo.categoria = ProductoBE.categoria
                        servicioNuevo.subCategoria = ProductoBE.subCategoria
                        servicioNuevo.cuenta = ProductoBE.cuenta
                        servicioNuevo.cuentaH = ProductoBE.cuentaH
                        servicioNuevo.cuentaDev = ProductoBE.cuentaDev
                        servicioNuevo.cuentaDevH = ProductoBE.cuentaDevH
                        servicioNuevo.observaciones = ProductoBE.observaciones
                        servicioNuevo.estado = ProductoBE.estado
                        servicioNuevo.usuarioActualizacion = ProductoBE.usuarioActualizacion
                        servicioNuevo.fechaActualizacion = ProductoBE.fechaActualizacion
                    End With
                    HeliosData.SaveChanges()
                End If
                ts.Complete()
            End Using
            Return ProductoBE.idServicio
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListaServicios(ByVal ProductoBE As servicio) As List(Of servicio)
        '    Dim con = HeliosData.detalleitems.Include("item").Where(Function(o) o.idEstablecimiento = intEstable).ToList
        Dim obj As servicio
        Dim con = (From a In HeliosData.servicio
                   Join cat In HeliosData.itemServicio
                       On cat.idItemServicio Equals a.idItemServicio
                   Where
                       a.idEmpresa = ProductoBE.idEmpresa).ToList

        GetListaServicios = New List(Of servicio)

        For Each i In con
            obj = New servicio
            'If i.x IsNot Nothing Then
            '    obj.itemServicio = New itemServicio With
            '    {
            '    .idItemServicio = i.x.idItemServicio,
            '    .descripcion = i.x.descripcion
            '    }

            'End If

            'If i.marca_empty IsNot Nothing Then
            '    obj.customMarca = New itemServicio With
            '    {
            '    .idItemServicio = i.marca_empty.idItemServicio,
            '    .descripcion = i.marca_empty.descripcion
            '    }
            'End If
            obj.idItemServicio = i.a.idItemServicio
            obj.idServicio = i.a.idServicio
            obj.codigo = i.a.codigo
            obj.descripcion = i.a.descripcion
            obj.unidadMedida = i.a.unidadMedida
            obj.tipoExist = i.a.tipoExist
            obj.categoria = i.a.categoria
            obj.subCategoria = i.a.subCategoria
            'obj.origenProducto = i.a.origenProducto
            obj.estado = i.a.estado
            GetListaServicios.Add(obj)
        Next

        'fsddfd
        'Return (From a In HeliosData.detalleitems Where a.idEstablecimiento = intEstable).ToList
    End Function

    Public Function GetServicioByEmpresaConPrecios(empresa As String, tipo As String) As List(Of servicio)
        Dim obj As New servicio
        Dim Lista As New List(Of servicio)

        Dim consulta = HeliosData.usp_GetProductsServicioEmpresa(empresa, tipo).ToList

        Dim datosPreciosMenor() As String
        Dim datosPreciosMayor() As String
        Dim datosPreciosGranMenor() As String

        Dim ValorprecioMenorMN As Decimal = 0
        Dim ValorprecioMenorME As Decimal = 0
        Dim ValorprecioMayorMN As Decimal = 0
        Dim ValorprecioMayorME As Decimal = 0
        Dim ValorprecioGMayorMN As Decimal = 0
        Dim ValorprecioGMayorME As Decimal = 0
        For Each i In consulta
            obj = New servicio

            '   Dim valorNulo() As String = {"0.00", "0.00"}
            Dim precMenor As String = i.menor
            Dim precMayor As String = i.mayor
            Dim precGMayor As String = i.granMayor


            If precMenor IsNot Nothing Then
                datosPreciosMenor = precMenor.Split(New Char() {"|"c})
                ValorprecioMenorMN = datosPreciosMenor(0)
                ValorprecioMenorME = If(datosPreciosMenor(1) = "", 0, datosPreciosMenor(1))
            Else
                ValorprecioMenorMN = 0
                ValorprecioMenorME = 0
            End If

            If precMayor IsNot Nothing Then
                datosPreciosMayor = precMayor.Split(New Char() {"|"c})
                ValorprecioMayorMN = datosPreciosMayor(0)
                ValorprecioMayorME = If(datosPreciosMayor(1) = "", 0, datosPreciosMayor(1))
            Else
                ValorprecioMayorMN = 0
                ValorprecioMayorME = 0
            End If

            If precGMayor IsNot Nothing Then
                datosPreciosGranMenor = precGMayor.Split(New Char() {"|"c})
                ValorprecioGMayorMN = datosPreciosGranMenor(0)
                ValorprecioGMayorME = If(datosPreciosGranMenor(1) = "", 0, datosPreciosGranMenor(1))
            Else
                ValorprecioGMayorMN = 0
                ValorprecioGMayorME = 0
            End If

            If i.UltimaEntrada IsNot Nothing Then
                Dim s As String = i.UltimaEntrada

                Dim datosEntrada() As String = s.Split(New Char() {","c})


                '   Dim parts As String() = s.Split(New Char() {","c})

                Dim tipcompra As String = datosEntrada(0)
                Dim fechacompra As String = datosEntrada(1)
                Dim destino As String = datosEntrada(2)
                Dim baseimponible = datosEntrada(3)
                Dim total = datosEntrada(4)
                Dim cant = datosEntrada(5)



                'obj.CustomDetalleCompra = New documentocompradetalle With
                '{
                '    .FechaDoc = fechacompra,' i.UltimaCompra.comp.fechaDoc,
                '    .monto1 = cant,'i.UltimaCompra.d.monto1,
                '    .destino = destino,' i.UltimaCompra.d.destino,
                '    .importe = total'i.UltimaCompra.d.importe
                '}
                'obj.CustomDetalleCompra.documentocompra = New documentocompra With
                '{
                '.tipoCompra = tipcompra' i.UltimaCompra.comp.tipoCompra
                '}
            End If

            'If i.UltimaEntradaInicio IsNot Nothing Then
            '    obj.InventarioInicio = i.UltimaEntradaInicio
            'End If

            obj.idServicio = i.idServicio
            obj.descripcion = i.descripcion
            obj.categoria = i.GrupoName
            obj.subCategoria = i.MarcaName
            'obj.codigo = i.codigo
            obj.tipoExist = i.tipoExist
            obj.unidadMedida = i.unidadMedida
            'obj.unidad2 = i.MarcaName
            'obj.presentacion = String.Empty 'i.presentacion
            obj.codigo = i.codigo
            'obj.precioCompra = i.precioCompra
            obj.menor = ValorprecioMenorMN ' i.menor.GetValueOrDefault '  i.precioMenor.GetValueOrDefault
            obj.mayor = ValorprecioMayorMN ' i.mayor.GetValueOrDefault ' i.PrecioMayor.GetValueOrDefault
            obj.gMayor = ValorprecioGMayorMN ' i.granMayor.GetValueOrDefault ' i.PrecioGranMayor.GetValueOrDefault

            obj.menorME = ValorprecioMenorME ' 0 ' i.precioMenorME.GetValueOrDefault
            obj.mayorME = ValorprecioMayorME '0 ' i.PrecioMayorME.GetValueOrDefault
            obj.gMayorME = ValorprecioGMayorME ' 0 ' i.PrecioGranMayorME.GetValueOrDefault


            Lista.Add(obj)
        Next

        Return Lista
    End Function

End Class
