Imports Helios.Cont.Business.Entity
Public Class plantillaActivoBL
    Inherits BaseBL

    Public Function GetPlantillaActivo(plantillaActivoBE As PlantillaActivo) As List(Of PlantillaActivo)
        'Return HeliosData.PlantillaActivo.Where(Function(o) o.idEmpresa = plantillaActivoBE.idEmpresa And
        '                                            o.estado = plantillaActivoBE.estado).ToList
    End Function

End Class
