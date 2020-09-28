Imports Helios.Cont.Business.Entity
Public Class ModuloConfiguracionSA
    Public Function ListaModulos() As List(Of moduloApp)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaModulos
    End Function

    Public Function TieneConfiguracionComprobante(strIdEmpresa As String, strIdModulo As String) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TieneConfiguracionComprobante(strIdEmpresa, strIdModulo)
    End Function

    'Public Function UbicarConfiguracionPorEmpresaModulo(strIdModulo As String, strIdEmpresa As String, intIdEstablecimiento As Integer) As moduloConfiguracion
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIdEmpresa, intIdEstablecimiento)
    'End Function

    Public Function UbicarModuloPorCodigo(strIdModulo As String) As moduloApp
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarModuloPorCodigo(strIdModulo)
    End Function

    Public Function UbicarConfiguracionPorID(intIdConfig As Integer) As moduloConfiguracion
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarConfiguracionPorID(intIdConfig)
    End Function

    Public Function ListaModulosConfigurados(moduloConfiguracionBE As moduloConfiguracion) As List(Of moduloConfiguracion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaModulosConfigurados(moduloConfiguracionBE)
    End Function

    Public Function GrabarConfigSistema(objConfiguracion As moduloConfiguracion) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarConfigSistema(objConfiguracion)
    End Function

    Public Function UpdateConfigSistema(objConfiguracion As moduloConfiguracion) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateConfigSistema(objConfiguracion)
    End Function

    Public Sub EliminarConfigSistema(objConfiguracion As moduloConfiguracion)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarConfigSistema(objConfiguracion)
    End Sub
End Class
