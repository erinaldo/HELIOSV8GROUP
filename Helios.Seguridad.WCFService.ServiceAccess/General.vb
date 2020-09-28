Imports Helios.Seguridad.WCFService.ServiceContract
'Imports JNetFx.Framework.General.WCFService
Imports JNetFx.Framework.Data.WCFService
Public Module General

    Public Structure SeguridadServiceData
        ''' <summary>
        ''' Código que identifica al servicio.
        ''' </summary>
        ''' <remarks></remarks>
        Const CODIGO_SERVICIO_USE = "HeliosSeguridadService"
        ''' <summary>
        ''' Nombre indicado en el archivo de configuración que indica la dirección donde se encuentra el servicio
        ''' </summary>
        ''' <remarks></remarks>
        Const NOMBRE_SERVICIO_CONF = "SeguridadService" ' "BasicHttpBinding_ISeguridadService"
    End Structure

    Public Function GetHeliosProxy() As ISeguridadService
        Return ProxyManager(Of ISeguridadService).GetProxy(SeguridadServiceData.CODIGO_SERVICIO_USE, _
                                                    SeguridadServiceData.NOMBRE_SERVICIO_CONF, _
                                                    ProxyManager(Of ISeguridadService).TipoCache.CacheChannel)
    End Function

End Module