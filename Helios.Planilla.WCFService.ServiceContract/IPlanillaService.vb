Imports JNetFx.Framework.Data.WCFService
Imports System.ServiceModel
Imports Helios.Planilla.WCFService.MessageContract

<ServiceContract()> _
Public Interface IPlanillaService
    Inherits IServiceBase

    <OperationContract> Function SCO_Plantilla(request As PlantillaRequest) As PlantillaResponse
    <OperationContract> Function SCO_PlantillaDetalle(request As PlantillaDetalleRequest) As PlantillaDetalleResponse
    <OperationContract> Function SCO_ControlAsistencia(request As ControlAsistenciaRequest) As ControlAsistenciaResponse
    <OperationContract> Function SCO_ControlDeAsistencia(request As ControlDeAsistenciaRequest) As ControlDeAsistenciaResponse
    <OperationContract> Function SCO_Concepto(request As ConceptoRequest) As ConceptoResponse
    <OperationContract> Function SCO_Personal(request As PersonalRequest) As PersonalResponse
    <OperationContract> Function SCO_PersonalConceptos(request As PersonalConceptosRequest) As PersonalConceptosResponse
    <OperationContract> Function SCO_PersonalHorarios(request As PersonalHorariosRequest) As PersonalHorariosResponse
    <OperationContract> Function SCO_PersonalCargo(request As PersonalCargoRequest) As PersonalCargoResponse
    <OperationContract> Function SCO_DerechoHabientes(request As DerechoHabientesRequest) As DerechoHabientesResponse
    <OperationContract> Function SCO_PlanillaGeneral(request As PlanillaGeneralRequest) As PlanillaGeneralResponse
    <OperationContract> Function SCO_VariablesDelSistema(request As VariablesDelSistemaRequest) As VariablesDelSistemaResponse
    <OperationContract> Function SCO_Cargos(request As CargosRequest) As CargosResponse
    <OperationContract> Function SCO_Periodos(request As PeriodosRequest) As PeriodosResponse
    <OperationContract> Function SCO_TablaDetalle(request As TablaDetalleRequest) As TablaDetalleResponse
    <OperationContract> Function SCO_AFP(request As AFPRequest) As AFPResponse

End Interface
