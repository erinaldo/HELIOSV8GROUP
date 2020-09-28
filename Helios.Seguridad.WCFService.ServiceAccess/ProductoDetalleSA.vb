Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.MessageContract
Public Class ProductoDetalleSA

    Public Function ListadoAsegurableProducto(ID As Integer) As List(Of ProductoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAsegurableProductoDetalle(New ProductoDetalleRequest() With {.idProductoDetalle = ID})
        Return Response.ListadoProductoDetalle
    End Function

    Public Sub insertProductoDetalle(objProductoDetalle As ProductoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.insertProductoDetalle(New ProductoDetalleRequest() With {.ObjProductoDetalle = objProductoDetalle})
    End Sub
End Class
