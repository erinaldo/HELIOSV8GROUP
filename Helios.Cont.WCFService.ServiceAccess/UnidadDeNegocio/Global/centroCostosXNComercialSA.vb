Imports Helios.Cont.Business.Entity

Public Class centroCostosXNComercialSA
    Public Function GetListacentroCostosXNComercial(centroCostosXNComercialBE As centroCostosXNComercial) As List(Of centroCostosXNComercial)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListacentroCostosXNComercial(centroCostosXNComercialBE)
    End Function

    Public Function GetListaNegociosDisponibles(centroCostosXNComercialBE As centroCostosXNComercial) As centroCostosXNComercial
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaNegociosDisponibles(centroCostosXNComercialBE)
    End Function

    Public Function GetInsertarcentroCostosXNComercial(centroCostosXNComercialBE As centroCostosXNComercial) As centroCostosXNComercial
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInsertarcentroCostosXNComercial(centroCostosXNComercialBE)
    End Function

    Public Function GetCentroCostosXNComercialUpdate(be As centroCostosXNComercial) As centroCostosXNComercial
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCentroCostosXNComercialUpdate(be)
    End Function

    Public  Sub EliminarPermisoNegocioCOmercial(ByVal be As centroCostosXNComercial)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPermisoNegocioCOmercial(be)
    End Sub
End Class
