Imports Helios.Cont.Business.Entity

Public Class regionesSA
    Public Function GetRegiones() As List(Of regiones)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRegiones()
    End Function

    Public Function ListarUbigeosActivos() As List(Of regiones)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarUbigeosActivos()
    End Function
End Class
