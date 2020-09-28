Imports Helios.Cont.Business.Entity
Public Class BeneficioDetalleSA
    Public Function GetListDetalleSel(be As beneficio) As List(Of beneficioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListDetalleSel(be)
    End Function
End Class
