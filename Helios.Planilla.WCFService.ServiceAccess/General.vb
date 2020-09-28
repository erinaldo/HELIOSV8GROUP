Imports Helios.Planilla.WCFService.ServiceContract
Imports Helios.Planilla.Business.Entity
Imports JNetFx.Framework.Data.WCFService

Module General
    Public Structure PlanillaServiceData
        ''' <summary>
        ''' Código que identifica al servicio
        ''' </summary>
        ''' <remarks></remarks>
        Const CODE_SERVICE_USE = "HeliosPlanillaService" ' "PlanillaService"
        ''' <summary>
        ''' Nombre del servicio en el archivo de configuración
        ''' </summary>
        ''' <remarks></remarks>
        Const NAME_SERVICE_CONF = "PlanillaService" ' "Binding_IPlanillaService"
    End Structure

    Public Function GetServiceProxy() As IPlanillaService
        Return ProxyManager(Of IPlanillaService).GetProxy(PlanillaServiceData.CODE_SERVICE_USE,
                                                              PlanillaServiceData.NAME_SERVICE_CONF,
                                                               ProxyManager(Of Global.Helios.Planilla.WCFService.ServiceContract.IPlanillaService).TipoCache.CacheChannel)

    End Function
End Module
