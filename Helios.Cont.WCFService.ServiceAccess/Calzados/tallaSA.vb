Imports Helios.Cont.Business.Entity

Public Class tallaSA
    Public Function GetTallasSelCategoria(be As talla) As List(Of talla)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTallasSelCategoria(be)
    End Function

End Class
