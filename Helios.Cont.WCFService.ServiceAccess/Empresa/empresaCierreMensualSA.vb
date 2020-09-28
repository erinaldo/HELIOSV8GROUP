Imports Helios.Cont.Business.Entity

Public Class empresaCierreMensualSA

    Public Sub GrabarCierrePeriodo(be As empresaCierreMensual, documento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCierrePeriodo(be, documento)
    End Sub

    Public Function EstadoMesCerrado(be As empresaCierreMensual) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.EstadoMesCerrado(be)
    End Function

    Public Function GetCierresByEmpresa(be As empresaCierreMensual) As List(Of empresaCierreMensual)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCierresByEmpresa(be)
    End Function

    Public Sub EliminarCierre(be As empresaCierreMensual)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCierre(be)
    End Sub

End Class
