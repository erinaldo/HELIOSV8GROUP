Imports Helios.Cont.Business.Entity
Public Class CentrocostosSA

    Public Function GetObtenerEstablecimiento(strEmpresa As String) As List(Of centrocosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerEstablecimiento(strEmpresa)
    End Function

#Region "MUNICIPALIDAD"
    Public Function GetObtenerEstablecimiento2(strEmpresa As String) As List(Of centrocosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerEstablecimiento2(strEmpresa)
    End Function


    Public Function GetObtenerUnidadNegocio(IsEstablecimiento As Integer) As List(Of centrocosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerUnidadNegocio(IsEstablecimiento)
    End Function

    Public Function InsertListaEstablecimiento(estableBE As centrocosto) As List(Of centrocosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertListaEstablecimiento(estableBE)
    End Function

    Public Function InsertListaEstablecimientoApoyo(estableBE As centrocosto) As List(Of centrocosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertListaEstablecimientoApoyo(estableBE)
    End Function

#End Region
End Class
