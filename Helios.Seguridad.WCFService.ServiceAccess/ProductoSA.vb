Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.MessageContract
Public Class ProductoSA

    Public Function insertAsegurableProducto(objListaAsegurable As Producto) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetInsertAsegurableProducto(New ProductoRequest() With {.ObjProducto = objListaAsegurable})
        Return Response.idProducto
    End Function

    Public Function ListadoProductoXID(ID As Integer) As Producto
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoProductoXID(New ProductoRequest() With {.idProducto = ID})
        Return Response.ObjProducto
    End Function

    Public Function ListadoAsegurableProductoXtipo(tipo As String) As List(Of Producto)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetAsegurableProducto(New ProductoRequest() With {.tipoProducto = tipo})
        Return Response.ListadoProducto
    End Function

    Public Function ListadoProductoFull() As List(Of Producto)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoTipoProducto()
        Return Response.ListadoProducto
    End Function

    Public Sub InsertItemProducto(objProducto As Producto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertItemProducto(New ProductoRequest() With {.ObjProducto = objProducto})
    End Sub
End Class
