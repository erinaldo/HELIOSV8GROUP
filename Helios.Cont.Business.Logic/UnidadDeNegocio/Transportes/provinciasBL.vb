Imports Helios.Cont.Business.Entity

Public Class provinciasBL
    Inherits BaseBL

    Public Function GetProvinciasSelRegion(region As String) As List(Of provincias)
        Return HeliosData.provincias.Where(Function(o) o.region_id = region).ToList
    End Function

End Class
