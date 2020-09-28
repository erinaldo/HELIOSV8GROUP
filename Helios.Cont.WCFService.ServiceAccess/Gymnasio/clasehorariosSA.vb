Imports Helios.Cont.Business.Entity

Public Class clasehorariosSA
    Public Shared Function GetUbicarActividadGYMDetalle(idActividad As Integer) As List(Of clasehorarios)
        Dim servicio = General.GetHeliosProxy()
        Return servicio.GetUbicarActividadGYMDetalle(idActividad)
    End Function
End Class
