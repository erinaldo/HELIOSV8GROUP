Imports Helios.Cont.Business.Entity
Public Class PlantillaActivoSA
    Public Function GetPlantillaActivo(plantillaActivoBE As PlantillaActivo) As List(Of PlantillaActivo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPlantillaActivo(plantillaActivoBE)
    End Function
End Class
