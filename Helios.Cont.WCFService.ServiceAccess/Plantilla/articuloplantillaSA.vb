Imports Helios.Cont.Business.Entity
Public Class articuloplantillaSA

    Public Function GetPlantillaByIdPadre(be As articuloplantilla) As List(Of articuloplantilla)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPlantillaByIdPadre(be)
    End Function

    Public Function GetPlantillaByArticulo(be As detalleitems) As List(Of articuloplantilla)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPlantillaByArticulo(be)
    End Function

    Public Function GetPlantillaPadre(be As detalleitems) As List(Of articuloplantilla)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPlantillaPadre(be)
    End Function

    Public Sub EditarPlantillaArticulo(be As articuloplantilla)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarPlantillaArticulo(be)
    End Sub

    Public Sub EliminarPlantillaArticulo(be As articuloplantilla)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPlantillaArticulo(be)
    End Sub

    Public Sub InsertPlantillaArticulo(be As articuloplantilla)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertPlantillaArticulo(be)
    End Sub

End Class
