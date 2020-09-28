Imports Helios.Cont.Business.Entity

Public Class detalleitem_preciosSA
    Public Function DetalleItemPrecioSave(obj As detalleitem_precios) As detalleitem_precios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DetalleItemPrecioSave(obj)
    End Function
End Class
