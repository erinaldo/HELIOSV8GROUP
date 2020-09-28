Imports Helios.Cont.Business.Entity

Public Class provinciasSA
    Public Function GetProvinciasSelRegion(region As String) As List(Of provincias)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProvinciasSelRegion(region)
    End Function
End Class
