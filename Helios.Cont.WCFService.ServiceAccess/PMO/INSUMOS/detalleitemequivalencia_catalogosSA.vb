Imports Helios.Cont.Business.Entity

Public Class detalleitemequivalencia_catalogosSA
    Public Function CatalogoPrecioSave(be As detalleitemequivalencia_catalogos) As detalleitemequivalencia_catalogos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CatalogoPrecioSave(be)
    End Function

    Public Sub CatalogoPredeterminado(obj As detalleitemequivalencia_catalogos)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CatalogoPredeterminado(obj)
    End Sub
End Class
