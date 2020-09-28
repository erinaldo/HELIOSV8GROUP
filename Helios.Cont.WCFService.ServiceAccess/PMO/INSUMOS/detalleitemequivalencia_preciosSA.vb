Imports Helios.Cont.Business.Entity

Public Class detalleitemequivalencia_preciosSA
    Public Function PrecioEquivalenciaSave(be As detalleitemequivalencia_precios) As detalleitemequivalencia_precios
        Dim miServicio = General.GetHeliosProxy()
        return miServicio.PrecioEquivalenciaSave(be)
    End Function
End Class
