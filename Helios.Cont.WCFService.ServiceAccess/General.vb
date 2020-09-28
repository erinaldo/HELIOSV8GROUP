Imports Helios.Cont.WCFService.ServiceContract
Imports JNetFx.Framework.Data.WCFService

Public Module General

    Public Structure HeliosServiceData
        ''' <summary>
        ''' Código que identifica al servicio.
        ''' </summary>
        ''' <remarks></remarks>
        Const CODIGO_SERVICIO_USE = "HeliosContService"
        ''' <summary>
        ''' Nombre indicado en el archivo de configuración que indica la dirección donde se encuentra el servicio
        ''' </summary>
        ''' <remarks></remarks>
        Const NOMBRE_SERVICIO_CONF = "ContService"
    End Structure

    Public Function GetHeliosProxy() As IContService
        Return ProxyManager(Of IContService).GetProxy(HeliosServiceData.CODIGO_SERVICIO_USE,
                                                    HeliosServiceData.NOMBRE_SERVICIO_CONF,
                                                    ProxyManager(Of Helios.Cont.WCFService.ServiceContract.IContService).TipoCache.CacheChannel)
    End Function
End Module
