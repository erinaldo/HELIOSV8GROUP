Imports Helios.Cont.Business.Entity

Public Class tallaSA
    Public Function GetPlantillaTallas() As List(Of talla)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPlantillaTallas()
    End Function

    Public Function GetPlantillaTallaSelcategory(be As talla) As List(Of talla)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPlantillaTallaSelcategory(be)
    End Function

End Class
