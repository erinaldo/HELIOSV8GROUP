Imports Helios.Cont.Business.Entity

Public Class negocioComercialSA

    Public Function GetListaNegocioComercial() As List(Of negocioComercial)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaNegocioComercial()
    End Function

    Public Function GetListaNEgocioComercialXUnidOrg(negocioComercialBE As negocioComercial) As List(Of negocioComercial)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaNEgocioComercialXUnidOrg(negocioComercialBE)
    End Function

End Class
