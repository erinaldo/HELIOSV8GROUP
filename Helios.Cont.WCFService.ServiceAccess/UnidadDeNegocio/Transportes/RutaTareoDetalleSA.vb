Imports Helios.Cont.Business.Entity

Public Class RutaTareoDetalleSA
    Public Function GetProgamacionEnCurso(be As rutaProgramacionSalidas) As List(Of vehiculoAsiento_Precios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProgamacionEnCurso(be)
    End Function
End Class
