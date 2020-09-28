Imports Helios.Cont.Business.Entity
Public Class ConfiguracionInicioSA

    Public Sub EditarV00(configBE As configuracionInicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarV00(configBE)
    End Sub

    Public Sub EditarConfiguracionGeneral(configBE As configuracionInicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarConfiguracionGeneral(configBE)
    End Sub

    Public Sub InsertConfigInicio(configBE As configuracionInicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertConfigInicio(configBE)
    End Sub

    Public Sub EditarConfigInicio(configBE As configuracionInicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarConfigInicio(configBE)
    End Sub

    Public Sub EliminarConfigInicio(configBE As configuracionInicio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarConfigInicio(configBE)
    End Sub

    Public Function ObtenerConfigXempresa(strIdEmpresa As String, intIdEstaclecimiento As Integer) As configuracionInicio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerConfigXempresa(strIdEmpresa, intIdEstaclecimiento)
    End Function

End Class
