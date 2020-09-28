Imports Helios.Cont.Business.Entity

Public Class actividadPersonalSA

    Public Shared Sub EditarActividadGym(be As actividadPersonal)
        Dim servicio = General.GetHeliosProxy()
        servicio.EditarActividadGym(be)
    End Sub

    Public Shared Sub GrabarActividadPersonalGym(be As actividadPersonal)
        Dim servicio = General.GetHeliosProxy()
        servicio.GrabarActividadPersonalGym(be)
    End Sub

    Public Shared Function GetActividadesEmpresa(be As actividadPersonal) As List(Of actividadPersonal)
        Dim servicio = General.GetHeliosProxy()
        Return servicio.GetActividadesEmpresa(be)
    End Function

    Public Shared Function GetUbicarActividadGYM(idActividad As Integer) As actividadPersonal
        Dim servicio = General.GetHeliosProxy()
        Return servicio.GetUbicarActividadGYM(idActividad)
    End Function
End Class
