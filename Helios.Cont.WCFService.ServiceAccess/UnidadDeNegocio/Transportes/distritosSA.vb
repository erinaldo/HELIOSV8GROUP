Imports Helios.Cont.Business.Entity

Public Class distritosSA
    Public Function GetDistritosSelProvincia(provincia_id As String, region_id As String) As List(Of distritos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDistritosSelProvincia(provincia_id, region_id)
    End Function

    Public Function GetDistritosSelID(distrito_id As String) As distritos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDistritosSelID(distrito_id)
    End Function
End Class
