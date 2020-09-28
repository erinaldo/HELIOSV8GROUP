Imports Helios.Cont.Business.Entity
Public Class asientoContablePlantillaSA

    Public Function GetPantillasGeneral(tipoOper As String) As List(Of asientoContablePlantilla)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPantillasGeneral(tipoOper)
    End Function

End Class
