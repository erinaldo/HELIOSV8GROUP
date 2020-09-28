Imports Helios.Cont.Business.Entity

Public Class distritosBL
    Inherits BaseBL

    Public Function GetDistritosSelProvincia(provincia_id As String, region_id As String) As List(Of distritos)
        Return HeliosData.distritos.Where(Function(o) o.province_id = provincia_id And o.region_id = region_id).ToList
    End Function

    Public Function GetDistritosSelID(distrito_id As String) As distritos
        Return HeliosData.distritos.Where(Function(o) o.id = distrito_id).SingleOrDefault
    End Function

End Class
