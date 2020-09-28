Imports Helios.Cont.Business.Entity
Public Class documentoCajaRPTSA

    Public Function GetListarMvimientosCajaPorDiaReporte(intIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoCaja)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarMvimientosCajaPorDiaReporte(intIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetListarMvimientosCajaPorPeriodoReporte(strEmpresa As String, intIdEstablecimiento As Integer,
                                             strPeriodo As String) As List(Of documentoCaja)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarMvimientosCajaPorPeriodoReporte(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function ObtenerCajaOnlineRPT(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineRPT(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlineDiaRPT(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineDiaRPT(strIdEmpresa, intIdEstablecimiento, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlineAcumuladoRPT(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineAcumuladoRPT(strIdEmpresa, intIdEstablecimiento)
    End Function

End Class
