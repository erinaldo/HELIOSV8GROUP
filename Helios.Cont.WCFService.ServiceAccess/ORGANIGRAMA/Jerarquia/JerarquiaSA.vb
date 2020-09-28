Imports Helios.Cont.Business.Entity
Public Class JerarquiaSA


    Public Sub SaveJerarquia(JerarBe As List(Of jerarquia))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveJerarquia(JerarBe)
    End Sub


    Public Function GetObtenerJerar(Idorgani As Integer) As List(Of jerarquia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerJerar(Idorgani)
    End Function
End Class
