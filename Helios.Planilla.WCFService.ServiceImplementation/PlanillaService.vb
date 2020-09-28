Imports Helios.Planilla.WCFService.ServiceContract
Imports Helios.Planilla.Business.Logic
Imports Helios.Planilla.WCFService.MessageContract

Public Class PlanillaService
    Implements IPlanillaService


    Public Function SCO_Plantilla(request As PlantillaRequest) As PlantillaResponse Implements IPlanillaService.SCO_Plantilla
        Dim BLPlantilla As New PlantillaBL
        Dim response As New PlantillaResponse

        Select Case request.Operacion
            Case PlantillaOperation.PlantillaSaveAll
                BLPlantilla.PlanillaSaveAll(request.Plantilla, request.TransactionData)
            Case PlantillaOperation.PlantillaSel
                response.Plantilla = BLPlantilla.Sel(request.Plantilla)
            Case PlantillaOperation.PlantillaSelAll
                response.ListaPlantilla = BLPlantilla.PlantillaSelAll()
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_PlantillaDetalle(request As PlantillaDetalleRequest) As PlantillaDetalleResponse Implements IPlanillaService.SCO_PlantillaDetalle
        Dim BLPlantillaDetalle As New PlantillaDetalleBL
        Dim response As New PlantillaDetalleResponse

        Select Case request.Operacion
            Case PlantillaDetalleOperation.PlantillaDetalleSelxPlantilla
                response.PlantillaDetalleList = BLPlantillaDetalle.PlantillaDetalleSelxPlantilla(request.PlantillaDetalle)
            Case PlantillaDetalleOperation.PlantillaDetalleSel
                response.PlantillaDetalle = BLPlantillaDetalle.Sel(request.PlantillaDetalle)
            Case PlantillaDetalleOperation.PlantillaDetalleSelxPlantillaV2
                response.PlantillaDetalleList = BLPlantillaDetalle.PlantillaDetalleSelxPlantillaV2(request.PlantillaDetalle)
            Case PlantillaDetalleOperation.PlantillaDetalleSelxPlantillaxConcepto
                response.PlantillaDetalle = BLPlantillaDetalle.PlantillaDetalleSelxPlantillaxConcepto(request.PlantillaDetalle)
            Case PlantillaDetalleOperation.PlantillaDetalleSave
                response.PlantillaDetalle = BLPlantillaDetalle.PlanillaDetalleSave(request.PlantillaDetalle, request.TransactionData)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function
    Public Function SCO_AFP(request As AFPRequest) As AFPResponse Implements IPlanillaService.SCO_AFP
        Dim BLAFP As New AFPBL
        Dim response As New AFPResponse

        Select Case request.Operacion
            Case AFPOperation.AFPSelAll
                response.AFPList = BLAFP.AFPSelAll(request.AFP)
            Case AFPOperation.AFPSelxID
                response.AFPList = BLAFP.AFPSelxID(request.AFP)
            Case AFPOperation.AFPSave
                response.AFP = BLAFP.AFPSave(request.AFP, request.TransactionData)
            Case AFPOperation.AFPDelete
                BLAFP.Delete(request.AFP)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_TablaDetalle(request As TablaDetalleRequest) As TablaDetalleResponse Implements IPlanillaService.SCO_TablaDetalle
        Dim BLTablaDetalle As New TablaDetalleBL
        Dim response As New TablaDetalleResponse

        Select Case request.Operacion
            Case TablaDetalleOperation.TablaDetalleSelxTabla
                response.TablaDetalleList = BLTablaDetalle.TablaDetalleSelxTabla(request.TablaDetalle)
            Case TablaDetalleOperation.TablaDetalleDepartamentos
                response.TablaDetalleList = BLTablaDetalle.TablaDetalleDepartamentos()
            Case TablaDetalleOperation.TablaDetalleProvincia
                response.TablaDetalleList = BLTablaDetalle.TablaDetalleProvincia(request.TablaDetalle)
            Case TablaDetalleOperation.TablaDetalleDistrito
                response.TablaDetalleList = BLTablaDetalle.TablaDetalleDistrito(request.TablaDetalle)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_Personal(request As PersonalRequest) As PersonalResponse Implements IPlanillaService.SCO_Personal
        Dim BLPersonal As New PersonalBL
        Dim response As New PersonalResponse

        Select Case request.Operacion
            Case PersonalOperation.PersonalSel
                response.Personal = BLPersonal.Sel(request.Personal)
            Case PersonalOperation.PersonalSelxEstado
                response.PersonalList = BLPersonal.PersonalSelxEstado(request.Personal)
            Case PersonalOperation.PersonalSelxID
                response.Personal = BLPersonal.PersonalSelxID(request.Personal)
            Case PersonalOperation.PersonalSave
                response.Personal = BLPersonal.PersonalSave(request.Personal, request.TransactionData)
            Case PersonalOperation.PersonalDelete
                BLPersonal.Delete(request.Personal)
            Case PersonalOperation.PersonalSelxDNI
                response.Personal = BLPersonal.PersonalSelxDNI(request.Personal)
            Case PersonalOperation.PersonalSelStartwithNombres
                response.PersonalList = BLPersonal.PersonalSelStartwithNombres(request.Personal)

            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_Cargos(request As CargosRequest) As CargosResponse Implements IPlanillaService.SCO_Cargos
        Dim BLCargos As New CargosBL
        Dim response As New CargosResponse

        Select Case request.Operacion
            Case CargosOperation.CargosSel
                response.Cargos = BLCargos.Sel(request.Cargos)
            Case CargosOperation.CargosSelxID
                response.Cargos = BLCargos.CargosSelxID(request.Cargos)
            Case CargosOperation.CargosSave
                response.Cargos = BLCargos.CargosSave(request.Cargos, request.TransactionData)
            Case CargosOperation.CargosDelete
                BLCargos.Delete(request.Cargos)
            Case CargosOperation.CargosSelAll
                response.CargosList = BLCargos.CargosSelAll()
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_Periodos(request As PeriodosRequest) As PeriodosResponse Implements IPlanillaService.SCO_Periodos
        Dim BLPeriodos As New PeriodosBL
        Dim response As New PeriodosResponse

        Select Case request.Operacion
            Case PeriodosOperation.PeriodosSel
                response.Periodos = BLPeriodos.Sel(request.Periodos)
            Case PeriodosOperation.PeriodosSelxID
                response.Periodos = BLPeriodos.PeriodosSelxID(request.Periodos)
            Case PeriodosOperation.PeriodosSave
                response.Periodos = BLPeriodos.PeriodosSave(request.Periodos, request.TransactionData)
            Case PeriodosOperation.PeriodosDelete
                BLPeriodos.Delete(request.Periodos)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function


    Public Function SCO_Concepto(request As ConceptoRequest) As ConceptoResponse Implements IPlanillaService.SCO_Concepto
        Dim BLConcepto As New ConceptoBL
        Dim response As New ConceptoResponse

        Select Case request.Operacion
            Case ConceptoOperation.ConceptoSel
                response.Concepto = BLConcepto.Sel(request.Concepto)
            Case ConceptoOperation.ConceptoSelxTipoConcepto
                response.ConceptoList = BLConcepto.ConceptoSelxTipoConcepto(request.Concepto)
            Case ConceptoOperation.ConceptoSelxActivo
                response.ConceptoList = BLConcepto.ConceptoSelxActivo(request.Concepto)
            Case ConceptoOperation.ConceptoSave
                response.Concepto = BLConcepto.ConceptoSave(request.Concepto, request.TransactionData)
            Case ConceptoOperation.ConceptoDelete
                BLConcepto.Delete(request.Concepto)
            Case ConceptoOperation.ConceptoSelxCargo
                response.ConceptoList = BLConcepto.ConceptoSelxCargo(request.Concepto)
            Case ConceptoOperation.ConceptoSelxID
                response.Concepto = BLConcepto.ConceptoSelxID(request.Concepto)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_DerechoHabientes(request As DerechoHabientesRequest) As DerechoHabientesResponse Implements IPlanillaService.SCO_DerechoHabientes
        Dim BLDerechoHabientes As New DerechoHabientesBL
        Dim response As New DerechoHabientesResponse

        Select Case request.Operacion
            Case DerechoHabientesOperation.DerechoHabientesSel
                response.DerechoHabientes = BLDerechoHabientes.Sel(request.DerechoHabientes)
            Case DerechoHabientesOperation.DerechoHabientesSelxBuscado
                response.DerechoHabientesList = BLDerechoHabientes.DerechoHabientesSelxBuscado(request.DerechoHabientes)
            Case DerechoHabientesOperation.DerechoHabientesSave
                response.DerechoHabientes = BLDerechoHabientes.DerechoHabientesSave(request.DerechoHabientes, request.TransactionData)
            Case DerechoHabientesOperation.DerechoHabientesDelete
                BLDerechoHabientes.Delete(request.DerechoHabientes)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_PersonalConceptos(request As PersonalConceptosRequest) As PersonalConceptosResponse Implements IPlanillaService.SCO_PersonalConceptos
        Dim BLPersonalConceptos As New PersonalConceptosBL
        Dim response As New PersonalConceptosResponse

        Select Case request.Operacion
            Case PersonalConceptosOperation.PersonalConceptosSel
                response.PersonalConceptos = BLPersonalConceptos.Sel(request.PersonalConceptos)
            Case PersonalConceptosOperation.PersonalConceptosSelxBuscado
                response.PersonalConceptosList = BLPersonalConceptos.PersonalConceptosSelxBuscado(request.PersonalConceptos)
            Case PersonalConceptosOperation.PersonalConceptosSave
                response.PersonalConceptos = BLPersonalConceptos.PersonalConceptosSave(request.PersonalConceptos, request.TransactionData)
            Case PersonalConceptosOperation.PersonalConceptosDelete
                BLPersonalConceptos.Delete(request.PersonalConceptos)
            Case PersonalConceptosOperation.PersonalConceptosSaveLista
                response.PersonalConceptosList = BLPersonalConceptos.PersonalConceptosSaveLista(request.PersonalConceptosList, request.TransactionData)
            Case PersonalConceptosOperation.PersonalConceptosSelxCargo
                response.PersonalConceptosList = BLPersonalConceptos.PersonalConceptosSelxCargo(request.PersonalConceptos)
            Case PersonalConceptosOperation.PersonalConceptosXIDAU
                response.PersonalConceptos = BLPersonalConceptos.PersonalConceptosXIDAU(request.PersonalConceptos)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_PersonalHorarios(request As PersonalHorariosRequest) As PersonalHorariosResponse Implements IPlanillaService.SCO_PersonalHorarios
        Dim BLPersonalHorarios As New PersonalHorariosBL
        Dim response As New PersonalHorariosResponse

        Select Case request.Operacion
            Case PersonalHorariosOperation.PersonalHorariosSel
                response.PersonalHorarios = BLPersonalHorarios.Sel(request.PersonalHorarios)
            Case PersonalHorariosOperation.PersonalHorariosSelxID
                response.PersonalHorarios = BLPersonalHorarios.PersonalHorariosSelxID(request.PersonalHorarios)
            Case PersonalHorariosOperation.PersonalHorariosSelxIDPersonalDiaSemana
                response.PersonalHorarios = BLPersonalHorarios.PersonalHorariosSelxIDPersonalDiaSemana(request.PersonalHorarios)
            Case PersonalHorariosOperation.PersonalHorariosSave
                response.PersonalHorarios = BLPersonalHorarios.PersonalHorariosSave(request.PersonalHorarios, request.TransactionData)
            Case PersonalHorariosOperation.PersonalHorariosSaveLista
                response.PersonalHorarios = BLPersonalHorarios.PersonalHorariosSaveLista(request.PersonalHorariosList, request.TransactionData)

            Case PersonalHorariosOperation.PersonalHorariosDelete
                BLPersonalHorarios.Delete(request.PersonalHorarios)
            Case PersonalHorariosOperation.PersonalHorariosSelxCargo
                response.PersonalHorariosList = BLPersonalHorarios.PersonalHorariosSelxCargo(request.PersonalHorarios)
            Case PersonalHorariosOperation.PersonalHorariosSelxIDPersonal
                response.PersonalHorariosList = BLPersonalHorarios.PersonalHorariosSelxIDPersonal(request.PersonalHorarios)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function


    Public Function SCO_ControlAsistencia(request As ControlAsistenciaRequest) As ControlAsistenciaResponse Implements IPlanillaService.SCO_ControlAsistencia
        Dim BLControlAsistencia As New ControlAsistenciaBL
        Dim response As New ControlAsistenciaResponse

        Select Case request.Operacion
            Case ControlAsistenciaOperation.ControlAsistenciaSel
                response.ControlAsistencia = BLControlAsistencia.Sel(request.ControlAsistencia)
            Case ControlAsistenciaOperation.ControlAsistenciaSelxIDPersonal
                response.ControlAsistenciaList = BLControlAsistencia.ControlAsistenciaSelxIDPersonal(request.ControlAsistencia)
            Case ControlAsistenciaOperation.ControlAsistenciaSave
                response.ControlAsistencia = BLControlAsistencia.ControlAsistenciaSave(request.ControlAsistencia, request.TransactionData)
            Case ControlAsistenciaOperation.ControlAsistenciaDelete
                '     BLControlAsistencia.Delete(request.ControlAsistencia)
                response.ControlAsistencia = BLControlAsistencia.ControlAsistenciaDelete(request.ControlAsistencia, request.TransactionData)
            Case ControlAsistenciaOperation.ControlAsistenciaSelxID
                response.ControlAsistenciaList = BLControlAsistencia.ControlAsistenciaSelxID(request.ControlAsistencia)
            Case ControlAsistenciaOperation.ControlAsistenciaSelxIDPersonalFecha
                response.ControlAsistenciaList = BLControlAsistencia.ControlAsistenciaSelxIDPersonalFecha(request.ControlAsistencia)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_ControlDeAsistencia(request As ControlDeAsistenciaRequest) As ControlDeAsistenciaResponse Implements IPlanillaService.SCO_ControlDeAsistencia
        Dim BLControlDeAsistencia As New ControlDeAsistenciaBL
        Dim response As New ControlDeAsistenciaResponse

        Select Case request.Operacion
            Case ControlDeAsistenciaOperation.ControlDeAsistenciaSel
                response.ControlDeAsistencia = BLControlDeAsistencia.Sel(request.ControlDeAsistencia)
            Case ControlDeAsistenciaOperation.ControlDeAsistenciaSelxIDAsistencia
                response.ControlDeAsistenciaList = BLControlDeAsistencia.ControlDeAsistenciaSelxIDAsistencia(request.ControlDeAsistencia)
            Case ControlDeAsistenciaOperation.ControlDeAsistenciaSelxIDPersonal
                response.ControlDeAsistenciaList = BLControlDeAsistencia.ControlDeAsistenciaSelxIDPersonal(request.ControlDeAsistencia)
            Case ControlDeAsistenciaOperation.ControlDeAsistenciaSelxPersonalFecha
                response.ControlDeAsistenciaList = BLControlDeAsistencia.ControldeAsistenciaSelxPersonalFecha(request.ControlDeAsistencia)
            Case ControlDeAsistenciaOperation.ControldeAsistenciaSelxIDPersonalFecha
                response.ControlDeAsistencia = BLControlDeAsistencia.ControlDeAsistenciaSelxIDPersonalFecha(request.ControlDeAsistencia)
            Case ControlDeAsistenciaOperation.ControlDeAsistenciaSave
                response.ControlDeAsistencia = BLControlDeAsistencia.ControlDeAsistenciaSave(request.ControlDeAsistencia, request.TransactionData)
            Case ControlDeAsistenciaOperation.ControlDeAsistenciaDelete
                BLControlDeAsistencia.Delete(request.ControlDeAsistencia)
            Case ControlDeAsistenciaOperation.ControlDeAsistenciaSelxIDPersonal_SP
                response.GetAsistenciaXtrabajador = BLControlDeAsistencia.ControlDeAsistenciaSelxIDPersonal_SP(request.ControlDeAsistencia)
            Case ControlDeAsistenciaOperation.ControldeAsistenciaSelxPersonalDetalle
                response.ControlDeAsistenciaList = BLControlDeAsistencia.ControldeAsistenciaSelxPersonalDetalle(request.ControlDeAsistencia)
            Case ControlDeAsistenciaOperation.ControlDeAsistenciaSelxSocio
                response.ControlDeAsistenciaList = BLControlDeAsistencia.ControlDeAsistenciaSelxSocio(request.ControlDeAsistencia)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_PlanillaGeneral(request As PlanillaGeneralRequest) As PlanillaGeneralResponse Implements IPlanillaService.SCO_PlanillaGeneral
        Dim BLPlanillaGeneral As New PlanillaGeneralBL
        Dim response As New PlanillaGeneralResponse

        Select Case request.Operacion
            Case PlanillaGeneralOperation.PlanillaGeneralSel
                response.PlanillaGeneral = BLPlanillaGeneral.Sel(request.PlanillaGeneral)

            Case PlanillaGeneralOperation.PlanillaGeneralSelXPeriodo
                response.PlanillaGeneralList = BLPlanillaGeneral.PlanillaGeneralSelXPeriodo(request.PlanillaGeneral)

            Case PlanillaGeneralOperation.PlanillaGeneralSelxID
                response.PlanillaGeneral = BLPlanillaGeneral.PlanillaGeneralSelxID(request.PlanillaGeneral)
            Case PlanillaGeneralOperation.PlanillaGeneralSelxPersonalTipoConcepto
                response.PlanillaGeneralList = BLPlanillaGeneral.PlanillaGeneralSelxPersonalTipoConcepto(request.PlanillaGeneral)
            Case PlanillaGeneralOperation.PlanillaGeneralSave
                response.PlanillaGeneral = BLPlanillaGeneral.PlanillaGeneralSave(request.PlanillaGeneral, request.TransactionData)
            Case PlanillaGeneralOperation.PlanillaGeneralDelete
                BLPlanillaGeneral.Delete(request.PlanillaGeneral)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    Public Function SCO_VariablesDelSistema(request As VariablesDelSistemaRequest) As VariablesDelSistemaResponse Implements IPlanillaService.SCO_VariablesDelSistema
        Dim BLVariablesDelSistema As New VariablesDelSistemaBL
        Dim response As New VariablesDelSistemaResponse

        Select Case request.Operacion
            Case VariablesDelSistemaOperation.VariablesDelSistemaSel
                response.VariablesDelSistema = BLVariablesDelSistema.Sel(request.VariablesDelSistema)
            Case VariablesDelSistemaOperation.VariablesDelSistemaSelxTipoConcepto
                response.VariablesDelSistemaList = BLVariablesDelSistema.VariablesDelSistemaSelxTipoConcepto(request.VariablesDelSistema)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function

    ''' <summary>
    ''' Método auxiliar que sólo sirve para hacer una llamada en falso al servicio.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Ping() As Boolean Implements IPlanillaService.Ping
        Return True
    End Function

    Public Function SCO_PersonalCargo(request As PersonalCargoRequest) As PersonalCargoResponse Implements IPlanillaService.SCO_PersonalCargo
        Dim BLPersonalCargo As New PersonalCargoBL
        Dim response As New PersonalCargoResponse

        Select Case request.Operacion
            Case PersonalCargoOperation.PersonalCargoSel
                response.PersonalCargoList = BLPersonalCargo.PersonalCargoSel(request.PersonalCargo)
            Case PersonalCargoOperation.PersonalCargoSelxID
                response.PersonalCargo = BLPersonalCargo.PersonalCargoSelxID(request.PersonalCargo)
            Case PersonalCargoOperation.PersonalCargoSave
                response.PersonalCargo = BLPersonalCargo.PersonalCargoSave(request.PersonalCargo, request.TransactionData)
            Case PersonalCargoOperation.PersonalCargoSelxAll
                response.PersonalCargoList = BLPersonalCargo.PersonalCargoSelxAll(request.PersonalCargo)
            Case PersonalCargoOperation.PersonalCargoSelxCargo
                response.PersonalCargo = BLPersonalCargo.PersonalCargoSelxCargo(request.PersonalCargo)
                'Case PersonalCargoOperation.PersonalDelete
                '    BLPersonal.Delete(request.Personal)
            Case Else
                Throw New NotImplementedException
        End Select
        response.Rpta = True
        Return response
    End Function
End Class
