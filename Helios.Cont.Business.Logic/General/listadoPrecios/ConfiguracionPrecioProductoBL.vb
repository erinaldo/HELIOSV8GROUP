Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity.Migrations

Public Class ConfiguracionPrecioProductoBL
    Inherits BaseBL

    Public Sub PrecioSave(be As configuracionPrecioProducto)
        Using ts As New TransactionScope
            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    HeliosData.configuracionPrecioProducto.Add(be)
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.configuracionPrecioProducto.AddOrUpdate(be)
            End Select
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetReporteListaGeneralPrecios() As List(Of configuracionPrecioProducto)
        Dim obj As New configuracionPrecioProducto
        Dim lista As New List(Of configuracionPrecioProducto)

        Dim con = (From precio In HeliosData.configuracionPrecioProducto _
                   Join conf In HeliosData.configuracionPrecio On conf.idPrecio Equals precio.idPrecio _
                   Group Join prod In HeliosData.detalleitems On precio.idproducto Equals prod.codigodetalle Into prod_join = Group _
                   From prod In prod_join.DefaultIfEmpty() _
                   Where _
                   Not (prod.codigodetalle = Nothing) _
                   Group New With {precio, prod} By _
                   precio.idPrecio, _
                   conf.precio, _
                   prod.codigodetalle, _
                   prod.descripcionItem _
                   Into g = Group _
                   Order By _
                   descripcionItem _
                   Select _
                   idPrecio, _
                   precio, _
                   Codigodetalle = CType(codigodetalle, Int32?), _
                   DescripcionItem = descripcionItem, _
                   maxFecha = CType(g.Max(Function(p) p.precio.fecha), DateTime?), _
                   MaxPrecio = CType(g.Max(Function(p) p.precio.precioMN), Decimal?))

        'Dim consulta = (From c In HeliosData.configuracionPrecioProducto _
        '                Join prod In HeliosData.detalleitems On prod.codigodetalle Equals c.idproducto _
        '                by  _
        '               c.idproducto, _
        '               c.descripcion, _
        '               c.detalleitems.descripcionItem _
        '               Into g = Group _
        '               Order By _
        '               idproducto _
        '               Select _
        '               idproducto, _
        '               descripcionItem, _
        '               descripcion, _
        '               MaxFecha = CType(g.Max(Function(p) p.c.fecha), DateTime?), _
        '               MaxPrecio = CType(g.Max(Function(p) p.c.precioMN), Decimal?)).ToList

        ' consulta.OrderBy(Function(o) o.descripcionItem).ToList()

        For Each i In con
            obj = New configuracionPrecioProducto
            obj.idproducto = i.Codigodetalle.GetValueOrDefault
            obj.NomProducto = i.DescripcionItem
            obj.descripcion = i.precio
            obj.fecha = i.maxFecha
            obj.precioMN = i.MaxPrecio
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetPreciosItems() As List(Of configuracionPrecioProducto)
        Return HeliosData.configuracionPrecioProducto.ToList()
    End Function

    Public Function ListarPreciosXproductoMaxFecha(ByVal intIdAlmacen As Integer, intIdItem As Integer) As List(Of configuracionPrecioProducto)
        Dim objPrecioBE As New configuracionPrecioProducto
        Dim lista As New List(Of configuracionPrecioProducto)

        Dim query = (From data In HeliosData.configuracionPrecioProducto
                     Where
                     data.fecha = (Aggregate t1 In
                                   (From ConfiguracionPrecioProducto In HeliosData.configuracionPrecioProducto
                                    Where ConfiguracionPrecioProducto.idproducto = data.idproducto And
                                    ConfiguracionPrecioProducto.idPrecio = data.idPrecio
                                    Select New With {
                                        ConfiguracionPrecioProducto.fecha
                                    }) Into Max(t1.fecha)) And
                        CLng(data.idproducto) = intIdItem _
                         And data.precioMN > 0
                     Order By data.idPrecio
                     Select idPrecio = data.idPrecio,
                        idproducto = data.idproducto,
                        fecha = data.fecha,
                        tipo = data.tipo,
                        valPorcentaje = data.valPorcentaje,
                        nroLote = data.nroLote,
                        descripcion = data.descripcion,
                        precioMN = data.precioMN,
                        precioME = data.precioME).ToList

        For Each i In query
            objPrecioBE = New configuracionPrecioProducto() With
                            {
                                .idPrecio = i.idPrecio,
                                .fecha = i.fecha,
                                .tipo = i.tipo,
                                .valPorcentaje = i.valPorcentaje,
                                .precioMN = i.precioMN,
                                .precioME = i.precioME,
                                .descripcion = i.descripcion
                             }

            lista.Add(objPrecioBE)
        Next

        Return lista
    End Function

    Public Function GetPreciosproductoMaxFecha(intIdItem As Integer, CodPrecio As Integer) As configuracionPrecioProducto
        Dim objPrecioBE As New configuracionPrecioProducto

        Dim query = (From data In HeliosData.configuracionPrecioProducto
                     Where
                     data.idPrecio = CodPrecio And
                     data.fecha = (Aggregate t1 In
                                   (From ConfiguracionPrecioProducto In HeliosData.configuracionPrecioProducto
                                    Where ConfiguracionPrecioProducto.idproducto = data.idproducto And
                                    ConfiguracionPrecioProducto.idPrecio = data.idPrecio
                                    Select New With {
                                        ConfiguracionPrecioProducto.fecha
                                    }) Into Max(t1.fecha)) And
                        CLng(data.idproducto) = intIdItem
                     Select idPrecio = data.idPrecio,
                            data.idPrecioProducto,
                        idproducto = data.idproducto,
                        fecha = data.fecha,
                        tipo = data.tipo,
                        valPorcentaje = data.valPorcentaje,
                        nroLote = data.nroLote,
                        descripcion = data.descripcion,
                        precioMN = data.precioMN,
                        precioME = data.precioME).FirstOrDefault


        If Not IsNothing(query) Then
            objPrecioBE = New configuracionPrecioProducto() With
                        {
                        .idPrecioProducto = query.idPrecioProducto,
                        .idPrecio = query.idPrecio,
                        .idproducto = query.idproducto,
                        .fecha = query.fecha,
                        .tipo = query.tipo,
                        .valPorcentaje = query.valPorcentaje,
                        .precioMN = query.precioMN,
                        .precioME = query.precioME,
                        .descripcion = query.descripcion
                         }

            Return objPrecioBE
        Else
            Return Nothing

        End If


    End Function

    Public Sub GrabarListadoPrecios(listaProductos As List(Of configuracionPrecioProducto))
        Dim objPrecio As New configuracionPrecioProducto
        Using ts As New TransactionScope
            For Each i In listaProductos
                objPrecio = New configuracionPrecioProducto
                objPrecio.idPrecio = i.idPrecio
                objPrecio.idproducto = i.idproducto
                objPrecio.fecha = i.fecha
                objPrecio.tipo = i.tipo
                objPrecio.valPorcentaje = i.valPorcentaje
                objPrecio.descripcion = i.descripcion
                objPrecio.tipoModalidad = i.tipoModalidad
                objPrecio.precioMN = i.precioMN
                objPrecio.precioME = i.precioME
                HeliosData.configuracionPrecioProducto.Add(objPrecio)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarListadoPrecios(listaProductos As List(Of configuracionPrecioProducto), codigoProducto As Integer)
        Dim objPrecio As New configuracionPrecioProducto
        Using ts As New TransactionScope
            For Each i In listaProductos
                objPrecio = New configuracionPrecioProducto
                objPrecio.idPrecio = i.idPrecio
                objPrecio.idproducto = codigoProducto
                objPrecio.fecha = i.fecha
                objPrecio.tipo = i.tipo
                objPrecio.valPorcentaje = i.valPorcentaje
                objPrecio.tipoModalidad = i.tipoModalidad
                objPrecio.descripcion = i.descripcion
                objPrecio.precioMN = i.precioMN
                objPrecio.precioME = i.precioME
                HeliosData.configuracionPrecioProducto.Add(objPrecio)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarPrecio(Producto As List(Of configuracionPrecioProducto))
        Dim objPrecio As New configuracionPrecioProducto

        'Dim Sel = Producto.FirstOrDefault
        For Each i In Producto
            Dim ultimosPrecios = HeliosData.configuracionPrecioProducto.Where(
            Function(o) o.idproducto = i.idproducto And o.idPrecio = i.idPrecio).ToList

            '-------------------------------------------------------------------------------
            For Each y In ultimosPrecios
                EliminarPrecioSingle(y)
            Next
        Next

        Using ts As New TransactionScope
            For Each i In Producto
                objPrecio = New configuracionPrecioProducto
                objPrecio.idPrecio = i.idPrecio
                objPrecio.idproducto = i.idproducto
                objPrecio.fecha = i.fecha
                objPrecio.tipo = i.tipo
                objPrecio.valPorcentaje = i.valPorcentaje
                objPrecio.descripcion = i.descripcion
                objPrecio.tipoModalidad = i.tipoModalidad
                objPrecio.precioMN = i.precioMN
                objPrecio.precioME = i.precioME
                HeliosData.configuracionPrecioProducto.Add(objPrecio)
                '   HeliosData.configuracionPrecioProducto.AddRange(Producto)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarPrecioApertura(Producto As List(Of configuracionPrecioProducto), intIdProducto As Integer)
        Dim objPrecio As New configuracionPrecioProducto

        Using ts As New TransactionScope
            For Each i In Producto
                objPrecio = New configuracionPrecioProducto
                objPrecio.idPrecio = i.idPrecio
                objPrecio.idproducto = intIdProducto
                objPrecio.fecha = i.fecha
                objPrecio.tipo = i.tipo
                objPrecio.valPorcentaje = i.valPorcentaje
                objPrecio.descripcion = i.descripcion
                objPrecio.precioMN = i.precioMN
                objPrecio.precioME = i.precioME
                HeliosData.configuracionPrecioProducto.Add(objPrecio)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarPrecio(be As configuracionPrecioProducto)
        Using ts As New TransactionScope
            Dim precio = GetPreciosproductoMaxFecha(be.idproducto, be.idPrecio)
            Dim precioBorrar = HeliosData.configuracionPrecioProducto.Where(Function(o) o.idPrecioProducto = precio.idPrecioProducto).FirstOrDefault

            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(precioBorrar)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarPrecioSingle(be As configuracionPrecioProducto)
        Using ts As New TransactionScope
            Dim precioBorrar =
                HeliosData.configuracionPrecioProducto.Where(
                Function(o) o.idPrecioProducto = be.idPrecioProducto).FirstOrDefault

            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(precioBorrar)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
