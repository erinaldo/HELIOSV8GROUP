Imports Helios.Cont.Business.Entity
Public Class ListadoPrecioSA
    Public Function UbicarPrecioExistente(intIdProducto As Integer) As listadoPrecios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ValidarPrecioExistente(intIdProducto)
    End Function

    Public Function UbicarPVxListadoItems(ByVal intIdAlmacen As Integer) As List(Of listadoPrecios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPVxListadoItems(intIdAlmacen)
    End Function

    Public Function UbicarPVxItem(ByVal intIdAlmacen As Integer, intIdItem As Integer) As listadoPrecios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPVxItem(intIdAlmacen, intIdItem)
    End Function
    Public Function InsertarPrecioVV(ByVal listadoPreciosBE As listadoPrecios) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarPrecioVV(listadoPreciosBE)
    End Function

    Public Function PrecioVentaXitemXiva(ByVal intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As listadoPrecios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.PrecioVentaXitemXiva(intIdAlmacen, intIdItem, strIVA)
    End Function

    Public Function ObtenerPrecioPorIdAlmacen(intIdAlmacen As Integer) As List(Of listadoPrecios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrecioPorIdAlmacen(intIdAlmacen)
    End Function

    Public Function ObtenerPrecioPorItem(intIdAlmacen As Integer, intIdItem As Integer) As List(Of listadoPrecios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrecioPorItem(intIdAlmacen, intIdItem)
    End Function

    Public Function ObtenerPrecioPorItemSL(intIdAlmacen As Integer, intIdItem As Integer, strTipoIVA As String) As List(Of listadoPrecios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrecioPorItemSL(intIdAlmacen, intIdItem, strTipoIVA)
    End Function

    Public Function UbicarVentaPorItem(ByVal intIdAlmacen As Integer, intIdItem As Integer) As listadoPrecios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorItem(intIdAlmacen, intIdItem)
    End Function

    Public Function UbicarVentaPorItemCSIVA(ByVal intIdAlmacen As Integer, intIdItem As Integer) As List(Of listadoPrecios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorItemCSIVA(intIdAlmacen, intIdItem)
    End Function

    Public Function UbicarVentaPorItemCSIVASL(ByVal intIdAlmacen As Integer, intIdItem As Integer, srtIVA As String) As listadoPrecios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorItemCSIVASL(intIdAlmacen, intIdItem, srtIVA)
    End Function

    Public Function UbicarPrecioNuevo(ByVal intIdAlmacen As Integer, intIdItem As Integer, srtIVA As String) As Decimal
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPrecioNuevo(intIdAlmacen, intIdItem, srtIVA)
    End Function

    Public Sub InsertListadoPrecio(ByVal listadoPreciosBE As listadoPrecios)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertListadoPrecio(listadoPreciosBE)
    End Sub

    Public Sub InsertListadoPrecioSL(ByVal listadoPreciosBE As List(Of listadoPrecios))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertListadoPrecioSL(listadoPreciosBE)
    End Sub

    Public Sub EditarListadoPrecio(ByVal listadoPreciosBE As listadoPrecios)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarListadoPrecio(listadoPreciosBE)
    End Sub

    Public Sub EliminarListadoPrecio(ByVal listadoPreciosBE As listadoPrecios)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarListadoPrecio(listadoPreciosBE)
    End Sub
End Class
