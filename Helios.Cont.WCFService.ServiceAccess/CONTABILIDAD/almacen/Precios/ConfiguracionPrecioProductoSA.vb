Imports Helios.Cont.Business.Entity
Public Class ConfiguracionPrecioProductoSA

    Function GetPreciosproductoMaxFecha(intIdItem As Integer, CodPrecio As Integer) As configuracionPrecioProducto
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPreciosproductoMaxFecha(intIdItem, CodPrecio)
    End Function

    Public Sub PrecioSave(be As configuracionPrecioProducto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.PrecioSave(be)
    End Sub

    Public Function GetReporteListaGeneralPrecios() As List(Of configuracionPrecioProducto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetReporteListaGeneralPrecios()
    End Function

    Public Sub GrabarListadoPrecios(listaProductos As List(Of configuracionPrecioProducto))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarListadoPrecios(listaProductos)
    End Sub

    Public Function GetPreciosItems() As List(Of configuracionPrecioProducto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPreciosItems()
    End Function

    Public Function ListarPreciosXproductoMaxFecha(ByVal intIdAlmacen As Integer, intIdItem As Integer) As List(Of configuracionPrecioProducto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPreciosXproductoMaxFecha(intIdAlmacen, intIdItem)
    End Function

    Public Sub GrabarPrecio(Producto As List(Of configuracionPrecioProducto))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarPrecio(Producto)
    End Sub

    Public Sub EliminarPrecio(configuracionPrecioProducto As configuracionPrecioProducto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPrecio(configuracionPrecioProducto)
    End Sub
End Class
