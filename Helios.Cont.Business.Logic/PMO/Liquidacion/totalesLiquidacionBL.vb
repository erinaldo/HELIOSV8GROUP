Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class totalesLiquidacionBL
    Inherits BaseBL

    Public Structure TipoIncidencia
        Const INC_ADIC = "INCIDENCIA ADICIONAL"
        Const INC_NO_SUSTENTADO = "INCIDENCIA PARA NO SUSTENTADO"
    End Structure

    Structure IngresoLiquidacion
        Const NUEVO = "N"
        Const EDITAR = "E"
    End Structure

    Public Sub InsertAll(ByVal liquidacionBE As totalesLiquidacion)
        Using ts As New TransactionScope
            Insert(liquidacionBE)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Insert(ByVal liquidacionBE As totalesLiquidacion)
        Using ts As New TransactionScope
            'Se inserta asiento
            HeliosData.totalesLiquidacion.Add(liquidacionBE)
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub

    Public Sub UpdateInsert(ByVal liquidacionBE As totalesLiquidacion)
        Using ts As New TransactionScope
            'Se inserta asiento
            HeliosData.totalesLiquidacion.Attach(liquidacionBE)
            HeliosData.Entry(liquidacionBE).State = System.Data.Entity.EntityState.Modified
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub SaveLiquidacionPreliminar(ByVal objListaDetalle As totalesLiquidacion, IntIdActividadRecurosVar As Integer)
        Dim objLiquidacion As New totalesLiquidacion()
        '   Dim intCodigoDetalle As Integer

        Dim listIngreso As New List(Of String)()
        listIngreso.Add("INGRESOS")

        Dim listCadena As New List(Of String)()
        listCadena.Add("CADIN")

        Dim CONSULTA As New totalesLiquidacion()
        Try
            Using ts As New TransactionScope()
                With objListaDetalle

                    Select Case .Otros
                        Case "INGRESOS"
                            Dim xEmpresa As String = .idEmpresa
                            Dim xEstablec As String = .idEstablecimiento
                            Dim xIdProy As Integer = .idActividad
                            Dim xModulo As String = .modulo

                            Dim xTipoLiquidacion As String = .Otros
                            Dim xTipoPlan As String = .tipoPlan
                            CONSULTA = (From n In HeliosData.totalesLiquidacion _
                                           Where n.idEmpresa = xEmpresa _
                                           And n.idEstablecimiento = xEstablec _
                                           And n.idActividad = xIdProy _
                                           And n.tipoPlan = xTipoPlan _
                                           And listIngreso.Contains(n.tipoLiquidacion)).FirstOrDefault
                        Case "CADIN"

                            Dim xEmpresa As String = .idEmpresa
                            Dim xEstablec As String = .idEstablecimiento
                            Dim xIdProy As Integer = .idActividad
                            Dim xModulo As String = .modulo

                            Dim xTipoLiquidacion As String = .Otros
                            Dim xTipoPlan As String = .tipoPlan
                            CONSULTA = (From n In HeliosData.totalesLiquidacion _
                                           Where n.idEmpresa = xEmpresa _
                                           And n.idEstablecimiento = xEstablec _
                                           And n.idActividad = xIdProy _
                                           And n.tipoPlan = xTipoPlan _
                                           And listCadena.Contains(n.tipoLiquidacion)).FirstOrDefault
                    End Select

                    objLiquidacion = New totalesLiquidacion()
                    objLiquidacion.idEmpresa = .idEmpresa
                    objLiquidacion.idEstablecimiento = .idEstablecimiento
                    objLiquidacion.idActividad = .idActividad

                    objLiquidacion.tipoLiquidacion = .tipoLiquidacion
                    objLiquidacion.modulo = .modulo
                    objLiquidacion.Fecha = .Fecha

                    objLiquidacion.tipoPlan = .tipoPlan

                    objLiquidacion.usuarioActualizacion = .usuarioActualizacion
                    objLiquidacion.fechaActualizacion = .fechaActualizacion
                    If IsNothing(CONSULTA) Then 'no existe agregar nuevo

                        Select Case .tipoLiquidacion

                            Case "INGRESOS"
                                objLiquidacion.LI_ib_ini = .LI_ib_ini
                                objLiquidacion.LI_ib_ns = .LI_ib_ns
                                objLiquidacion.LI_ib_adic = .LI_ib_adic

                                objLiquidacion.LR_ventan_ini = .LR_ventan_ini
                                objLiquidacion.LR_ventan_ns = .LR_ventan_ns
                                objLiquidacion.LR_ventan_adic = .LR_ventan_adic

                                objLiquidacion.detraccion_ini = .detraccion_ini
                                objLiquidacion.detraccion_ns = .detraccion_ns
                                objLiquidacion.detraccion_adic = .detraccion_adic

                                'otros resportes
                                '--------------------------------------------------------
                                objLiquidacion.AF_EjecucionIng_ini = .AF_EjecucionIng_ini
                                objLiquidacion.AF_EjecucionIng_ns = .AF_EjecucionIng_ns
                                objLiquidacion.AF_EjecucionIng_adic = .AF_EjecucionIng_adic

                                objLiquidacion.AF_Percepcion_ini = .AF_Percepcion_ini
                                objLiquidacion.AF_Percepcion_ns = .AF_Percepcion_ns
                                objLiquidacion.AF_Percepcion_adic = .AF_Percepcion_adic

                                objLiquidacion.AF_Otrosps_ini = .AF_Otrosps_ini
                                objLiquidacion.AF_Otrosps_ns = .AF_Otrosps_ns
                                objLiquidacion.AF_Otrosps_adic = .AF_Otrosps_adic

                                objLiquidacion.AF_Detraccion_ini = .AF_Detraccion_ini
                                objLiquidacion.AF_Detraccion_ns = .AF_Detraccion_ns
                                objLiquidacion.AF_Detraccion_adic = .AF_Detraccion_adic

                                objLiquidacion.AF_Retencion_ini = .AF_Retencion_ini
                                objLiquidacion.AF_Retencion_ns = .AF_Retencion_ns
                                objLiquidacion.AF_Retencion_adic = .AF_Retencion_adic

                                objLiquidacion.AF_Otrosng_ini = .AF_Otrosng_ini
                                objLiquidacion.AF_Otrosng_ns = .AF_Otrosng_ns
                                objLiquidacion.AF_Otrosng_adic = .AF_Otrosng_adic

                                objLiquidacion.totalIngresos = .totalIngresos


                            Case "INCIDENCIA DIRECTA" ' CADENA DE SUMINISTROS

                                objLiquidacion.LR_costov_ini = .LR_costov_ini
                                objLiquidacion.LR_costov_ns = .LR_costov_ns
                                objLiquidacion.LR_costov_adic = .LR_costov_adic

                                '3ER REPORTE
                                objLiquidacion.LOO_ReDeAp_ini = .LOO_ReDeAp_ini
                                objLiquidacion.LOO_ReDeAp_ns = .LOO_ReDeAp_ns
                                objLiquidacion.LOO_ReDeAp_adic = .LOO_ReDeAp_adic

                                'ANALISIS FINANCIERO
                                objLiquidacion.AF_TotalPagoProvSust_ini = .AF_TotalPagoProvSust_ini
                                objLiquidacion.AF_TotalPagoProvSust_ns = .AF_TotalPagoProvSust_ns
                                objLiquidacion.AF_TotalPagoProvSust_adic = .AF_TotalPagoProvSust_adic

                                objLiquidacion.LP_TotalPagoProvCSSust_ini = .LP_TotalPagoProvCSSust_ini
                                objLiquidacion.LP_TotalPagoProvCSSust_ns = .LP_TotalPagoProvCSSust_ns
                                objLiquidacion.LP_TotalPagoProvCSSust_adic = .LP_TotalPagoProvCSSust_adic

                                'NOS SUSTENTADOS
                                objLiquidacion.AF_RefGastoNoSust_ini = .AF_RefGastoNoSust_ini
                                objLiquidacion.AF_RefGastoNoSust_ns = .AF_RefGastoNoSust_ns
                                objLiquidacion.AF_RefGastoNoSust_adic = .AF_RefGastoNoSust_adic
                                Select Case .RefSustento1
                                    Case TipoReferenciaSustento.COSTO_IGV
                                        objLiquidacion.LI_cfAcum_ini = .LI_cfAcum_ini
                                        objLiquidacion.LI_cfAcum_ns = .LI_cfAcum_ns
                                        objLiquidacion.LI_afAcum_adic = .LI_afAcum_adic
                                    Case Else
                                        objLiquidacion.LI_cfAcum_ini = 0
                                        objLiquidacion.LI_cfAcum_ns = 0
                                        objLiquidacion.LI_afAcum_adic = 0
                                End Select


                            Case "INCIDENCIA1"
                                objLiquidacion.LR_inc_ns = .LR_inc_ns
                                objLiquidacion.LR_inc_adic = .LR_inc_adic

                                '3ER REPORTE
                                objLiquidacion.LOO_ReDeAp_ns = .LOO_ReDeAp_ns
                                objLiquidacion.LOO_ReDeAp_adic = .LOO_ReDeAp_adic

                                'ANALISIS FINANCIERO
                                objLiquidacion.AF_TotalPagoProvSust_ns = .AF_TotalPagoProvSust_ns
                                objLiquidacion.AF_TotalPagoProvSust_adic = .AF_TotalPagoProvSust_adic
                                'NOS SUSTENTADOS
                                objLiquidacion.AF_RefGastoNoSust_ns = .AF_RefGastoNoSust_ns
                                '  objLiquidacion.AF_RefGastoNoSust_adic = i.AF_RefGastoNoSust_adic
                                'EGRESOS
                                objLiquidacion.LP_EgresoNoSustentado_ns = .LP_EgresoNoSustentado_ns
                                objLiquidacion.LP_EgresoNoSustentado_adic = .LP_EgresoNoSustentado_adic
                                objLiquidacion.LP_EgresoInciAdic_adic = .LP_EgresoInciAdic_adic
                                Select Case .RefSustento1
                                    Case TipoReferenciaSustento.COSTO_IGV
                                        objLiquidacion.LI_cfAcum_ns = .LI_cfAcum_ns
                                        objLiquidacion.LI_afAcum_adic = .LI_afAcum_adic

                                    Case Else
                                        objLiquidacion.LI_cfAcum_ns = 0
                                        objLiquidacion.LI_afAcum_adic = 0
                                End Select
                        End Select
                        SaveLiquidacion(objLiquidacion, .Otros)
                    Else ' editar existente


                        Select Case .tipoLiquidacion

                            Case "INGRESOS"
                                IntIdActividadRecurosVar = .secuencia '.CodigoDetalle

                                objLiquidacion.LI_ib_ini = .LI_ib_ini
                                objLiquidacion.LI_ib_ns = .LI_ib_ns
                                objLiquidacion.LI_ib_adic = .LI_ib_adic

                                objLiquidacion.LR_ventan_ini = .LR_ventan_ini
                                objLiquidacion.LR_ventan_ns = .LR_ventan_ns
                                objLiquidacion.LR_ventan_adic = .LR_ventan_adic

                                objLiquidacion.detraccion_ini = .detraccion_ini
                                objLiquidacion.detraccion_ns = .detraccion_ns
                                objLiquidacion.detraccion_adic = .detraccion_adic

                                'otros resportes
                                '--------------------------------------------------------
                                objLiquidacion.AF_EjecucionIng_ini = .AF_EjecucionIng_ini
                                objLiquidacion.AF_EjecucionIng_ns = .AF_EjecucionIng_ns
                                objLiquidacion.AF_EjecucionIng_adic = .AF_EjecucionIng_adic

                                objLiquidacion.AF_Percepcion_ini = .AF_Percepcion_ini
                                objLiquidacion.AF_Percepcion_ns = .AF_Percepcion_ns
                                objLiquidacion.AF_Percepcion_adic = .AF_Percepcion_adic

                                objLiquidacion.AF_Otrosps_ini = .AF_Otrosps_ini
                                objLiquidacion.AF_Otrosps_ns = .AF_Otrosps_ns
                                objLiquidacion.AF_Otrosps_adic = .AF_Otrosps_adic

                                objLiquidacion.AF_Detraccion_ini = .AF_Detraccion_ini
                                objLiquidacion.AF_Detraccion_ns = .AF_Detraccion_ns
                                objLiquidacion.AF_Detraccion_adic = .AF_Detraccion_adic

                                objLiquidacion.AF_Retencion_ini = .AF_Retencion_ini
                                objLiquidacion.AF_Retencion_ns = .AF_Retencion_ns
                                objLiquidacion.AF_Retencion_adic = .AF_Retencion_adic

                                objLiquidacion.AF_Otrosng_ini = .AF_Otrosng_ini
                                objLiquidacion.AF_Otrosng_ns = .AF_Otrosng_ns
                                objLiquidacion.AF_Otrosng_adic = .AF_Otrosng_adic

                                objLiquidacion.modulo = .modulo
                                objLiquidacion.totalIngresos = .totalIngresos


                            Case "INCIDENCIA DIRECTA"
                                IntIdActividadRecurosVar = .secuencia '.
                                objLiquidacion.LR_costov_ini = .LR_costov_ini
                                objLiquidacion.LR_costov_ns = .LR_costov_ns
                                objLiquidacion.LR_costov_adic = .LR_costov_adic

                                '3ER REPORTE
                                objLiquidacion.LOO_ReDeAp_ini = .LOO_ReDeAp_ini
                                objLiquidacion.LOO_ReDeAp_ns = .LOO_ReDeAp_ns
                                objLiquidacion.LOO_ReDeAp_adic = .LOO_ReDeAp_adic

                                'ANALISIS FINANCIERO
                                objLiquidacion.AF_TotalPagoProvSust_ini = .AF_TotalPagoProvSust_ini
                                objLiquidacion.AF_TotalPagoProvSust_ns = .AF_TotalPagoProvSust_ns
                                objLiquidacion.AF_TotalPagoProvSust_adic = .AF_TotalPagoProvSust_adic
                                'NOS SUSTENTADOS
                                objLiquidacion.AF_RefGastoNoSust_ini = .AF_RefGastoNoSust_ini
                                objLiquidacion.AF_RefGastoNoSust_ns = .AF_RefGastoNoSust_ns
                                objLiquidacion.AF_RefGastoNoSust_adic = .AF_RefGastoNoSust_adic


                                objLiquidacion.LP_TotalPagoProvCSSust_ini = .LP_TotalPagoProvCSSust_ini
                                objLiquidacion.LP_TotalPagoProvCSSust_ns = .LP_TotalPagoProvCSSust_ns
                                objLiquidacion.LP_TotalPagoProvCSSust_adic = .LP_TotalPagoProvCSSust_adic
                                Select Case .RefSustento1
                                    Case TipoReferenciaSustento.COSTO_IGV
                                        objLiquidacion.LI_cfAcum_ini = .LI_cfAcum_ini
                                        objLiquidacion.LI_cfAcum_ns = .LI_cfAcum_ns
                                        objLiquidacion.LI_afAcum_adic = .LI_afAcum_adic
                                    Case Else
                                        objLiquidacion.LI_cfAcum_ini = 0
                                        objLiquidacion.LI_cfAcum_ns = 0
                                        objLiquidacion.LI_afAcum_adic = 0

                                End Select

                                objLiquidacion.modulo = .modulo

                            Case "INCIDENCIA1"
                                objLiquidacion.LR_inc_ns = .LR_inc_ns
                                objLiquidacion.LR_inc_adic = .LR_inc_adic
                                IntIdActividadRecurosVar = .secuencia '.

                                '3ER REPORTE
                                objLiquidacion.LOO_ReDeAp_ns = .LOO_ReDeAp_ns
                                objLiquidacion.LOO_ReDeAp_adic = .LOO_ReDeAp_adic

                                'ANALISIS FINANCIERO
                                objLiquidacion.AF_TotalPagoProvSust_ns = .AF_TotalPagoProvSust_ns
                                objLiquidacion.AF_TotalPagoProvSust_adic = .AF_TotalPagoProvSust_adic
                                'NOS SUSTENTADOS
                                objLiquidacion.AF_RefGastoNoSust_ns = .AF_RefGastoNoSust_ns
                                objLiquidacion.AF_RefGastoNoSust_adic = .AF_RefGastoNoSust_adic
                                'EGRESOS
                                objLiquidacion.LP_EgresoNoSustentado_ns = .LP_EgresoNoSustentado_ns
                                objLiquidacion.LP_EgresoNoSustentado_adic = .LP_EgresoNoSustentado_adic
                                objLiquidacion.LP_EgresoInciAdic_adic = .LP_EgresoInciAdic_adic
                                Select Case .RefSustento1
                                    Case TipoReferenciaSustento.COSTO_IGV
                                        objLiquidacion.LI_cfAcum_ns = .LI_cfAcum_ns
                                        objLiquidacion.LI_afAcum_adic = .LI_afAcum_adic
                                    Case Else
                                        objLiquidacion.LI_cfAcum_ns = 0
                                        objLiquidacion.LI_afAcum_adic = 0

                                End Select

                                objLiquidacion.modulo = .modulo
                        End Select
                        UpdateLiquidacion(objLiquidacion, IntIdActividadRecurosVar, .Otros)
                    End If

                End With
                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarTotalLiquidacionAP(ByVal intEmpresa As String, ByVal intIDEstable As Integer, ByVal IdActividad As Integer, ByVal srtTipoPlan As String)
        Dim liquidacionBL As New totalesLiquidacionBL
        Dim objActividad As New totalesLiquidacion
        Using ts As New TransactionScope
            Dim consulta = (From a In HeliosData.totalesLiquidacion
              Where a.idEmpresa = intEmpresa _
              And a.idEstablecimiento = intIDEstable _
              And a.idActividad = IdActividad _
              And a.tipoPlan = srtTipoPlan Select a).FirstOrDefault

            With objActividad
                .idEmpresa = intEmpresa
                .idEstablecimiento = intIDEstable
                .idActividad = IdActividad
                .tipoLiquidacion = consulta.tipoLiquidacion
                .modulo = consulta.modulo
                .Fecha = consulta.Fecha
                .LI_ib_ini = consulta.LI_ib_ini
                .LI_cfAcum_ini = consulta.LI_cfAcum_ini
                .LI_ib_ns = consulta.LI_ib_ns
                .LI_cfAcum_ns = consulta.LI_cfAcum_ini
                .LI_ib_adic = consulta.LI_ib_adic
                .LI_afAcum_adic = consulta.LI_afAcum_adic
                .LR_ventan_ini = consulta.LR_ventan_ini
                .LR_costov_ini = consulta.LR_costov_ini
                .LR_ventan_ns = consulta.LR_ventan_ns
                .LR_costov_ns = consulta.LR_costov_ns
                .LR_inc_ns = consulta.LR_inc_ns
                .LR_ventan_adic = consulta.LR_ventan_adic
                .LR_costov_adic = consulta.LR_costov_adic
                .LR_inc_adic = consulta.LR_inc_adic
                .LOO_ReDeAp_ini = consulta.LOO_ReDeAp_ini
                .LOO_ReDeAp_ns = consulta.LOO_ReDeAp_ns
                .LOO_ReDeAp_adic = consulta.LOO_ReDeAp_adic
                .detraccion_ini = consulta.detraccion_ini
                .detraccion_ns = consulta.detraccion_ns
                .detraccion_adic = consulta.detraccion_adic
                .AF_EjecucionIng_ini = consulta.AF_EjecucionIng_ini
                .AF_EjecucionIng_ns = consulta.AF_EjecucionIng_ns
                .AF_EjecucionIng_adic = consulta.AF_EjecucionIng_adic
                .AF_Percepcion_ini = consulta.AF_Percepcion_ini
                .AF_Percepcion_ns = consulta.AF_Percepcion_ns
                .AF_Percepcion_adic = consulta.AF_Percepcion_adic
                .AF_Otrosps_ini = consulta.AF_Otrosps_ini
                .AF_Otrosps_ns = consulta.AF_Otrosps_ns
                .AF_Otrosps_adic = consulta.AF_Otrosps_adic
                .AF_Detraccion_ini = consulta.AF_Detraccion_ini
                .AF_Detraccion_ns = consulta.AF_Detraccion_ns
                .AF_Detraccion_adic = consulta.AF_Detraccion_adic
                .AF_Retencion_ini = consulta.AF_Retencion_ini
                .AF_Retencion_ns = consulta.AF_Retencion_ns
                .AF_Retencion_adic = consulta.AF_Retencion_adic
                .AF_Otrosng_ini = consulta.AF_Otrosng_ini
                .AF_Otrosng_ns = consulta.AF_Otrosng_ns
                .AF_Otrosng_adic = consulta.AF_Otrosng_adic
                .AF_TotalPagoProvSust_ini = consulta.AF_TotalPagoProvSust_ini
                .AF_TotalPagoProvSust_ns = consulta.AF_TotalPagoProvSust_ns
                .AF_TotalPagoProvSust_adic = consulta.AF_TotalPagoProvSust_adic
                .AF_RefGastoNoSust_ini = consulta.AF_RefGastoNoSust_ini
                .AF_RefGastoNoSust_ns = consulta.AF_RefGastoNoSust_ns
                .AF_RefGastoNoSust_adic = consulta.AF_RefGastoNoSust_adic
                .LP_TotalPagoProvCSSust_ini = consulta.LP_TotalPagoProvCSSust_ini
                .LP_TotalPagoProvCSSust_ns = consulta.LP_TotalPagoProvCSSust_ns
                .LP_TotalPagoProvCSSust_adic = consulta.LP_TotalPagoProvCSSust_adic
                .LP_EgresoNoSustentado_ns = consulta.LP_EgresoNoSustentado_ns
                .LP_EgresoNoSustentado_adic = consulta.LP_EgresoNoSustentado_adic
                .LP_EgresoInciAdic_adic = consulta.LP_EgresoInciAdic_adic
                .totalIngresos = consulta.totalIngresos
                .tipoPlan = "AP"
                .usuarioActualizacion = "NN"
                .fechaActualizacion = Date.Now
            End With
            HeliosData.totalesLiquidacion.Add(objActividad)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub SaveLiquidacionPreliminarExcel(ByVal objListaDetalle As List(Of totalesLiquidacion), IntIdActividadRecurosVar As Integer)
        Dim objLiquidacion As New totalesLiquidacion()
        '   Dim intCodigoDetalle As Integer

        Dim listIngreso As New List(Of String)()
        listIngreso.Add("INGRESOS")

        Dim listCadena As New List(Of String)()
        listCadena.Add("CADIN")

        Dim CONSULTA As New totalesLiquidacion()
        Try
            Using ts As New TransactionScope()
                For Each objLista In objListaDetalle
                    With objLista

                        Select Case .Otros
                            Case "INGRESOS"
                                Dim xEmpresa As String = .idEmpresa
                                Dim xEstablec As String = .idEstablecimiento
                                Dim xIdProy As Integer = .idActividad
                                Dim xModulo As Integer = .modulo

                                Dim xTipoLiquidacion As String = .Otros
                                Dim xTipoPlan As String = .tipoPlan
                                CONSULTA = (From n In HeliosData.totalesLiquidacion _
                                               Where n.idEmpresa = xEmpresa _
                                               And n.idEstablecimiento = xEstablec _
                                               And n.idActividad = xIdProy _
                                               And n.tipoPlan = xTipoPlan _
                                               And listIngreso.Contains(n.tipoLiquidacion)).FirstOrDefault
                            Case "CADIN"

                                Dim xEmpresa As String = .idEmpresa
                                Dim xEstablec As String = .idEstablecimiento
                                Dim xIdProy As Integer = .idActividad
                                Dim xModulo As String = .modulo

                                Dim xTipoLiquidacion As String = .Otros
                                Dim xTipoPlan As String = .tipoPlan
                                CONSULTA = (From n In HeliosData.totalesLiquidacion _
                                               Where n.idEmpresa = xEmpresa _
                                               And n.idEstablecimiento = xEstablec _
                                               And n.idActividad = xIdProy _
                                               And n.tipoPlan = xTipoPlan _
                                               And listCadena.Contains(n.tipoLiquidacion)).FirstOrDefault
                        End Select

                        objLiquidacion = New totalesLiquidacion()
                        objLiquidacion.idEmpresa = .idEmpresa
                        objLiquidacion.idEstablecimiento = .idEstablecimiento
                        objLiquidacion.idActividad = .idActividad

                        objLiquidacion.tipoLiquidacion = .tipoLiquidacion
                        objLiquidacion.modulo = .modulo
                        objLiquidacion.Fecha = .Fecha

                        objLiquidacion.tipoPlan = .tipoPlan

                        objLiquidacion.usuarioActualizacion = .usuarioActualizacion
                        objLiquidacion.fechaActualizacion = .fechaActualizacion
                        If IsNothing(CONSULTA) Then 'no existe agregar nuevo

                            Select Case .tipoLiquidacion

                                Case "INGRESOS"
                                    objLiquidacion.LI_ib_ini = .LI_ib_ini
                                    objLiquidacion.LI_ib_ns = .LI_ib_ns
                                    objLiquidacion.LI_ib_adic = .LI_ib_adic

                                    objLiquidacion.LR_ventan_ini = .LR_ventan_ini
                                    objLiquidacion.LR_ventan_ns = .LR_ventan_ns
                                    objLiquidacion.LR_ventan_adic = .LR_ventan_adic

                                    objLiquidacion.detraccion_ini = .detraccion_ini
                                    objLiquidacion.detraccion_ns = .detraccion_ns
                                    objLiquidacion.detraccion_adic = .detraccion_adic

                                    'otros resportes
                                    '--------------------------------------------------------
                                    objLiquidacion.AF_EjecucionIng_ini = .AF_EjecucionIng_ini
                                    objLiquidacion.AF_EjecucionIng_ns = .AF_EjecucionIng_ns
                                    objLiquidacion.AF_EjecucionIng_adic = .AF_EjecucionIng_adic

                                    objLiquidacion.AF_Percepcion_ini = .AF_Percepcion_ini
                                    objLiquidacion.AF_Percepcion_ns = .AF_Percepcion_ns
                                    objLiquidacion.AF_Percepcion_adic = .AF_Percepcion_adic

                                    objLiquidacion.AF_Otrosps_ini = .AF_Otrosps_ini
                                    objLiquidacion.AF_Otrosps_ns = .AF_Otrosps_ns
                                    objLiquidacion.AF_Otrosps_adic = .AF_Otrosps_adic

                                    objLiquidacion.AF_Detraccion_ini = .AF_Detraccion_ini
                                    objLiquidacion.AF_Detraccion_ns = .AF_Detraccion_ns
                                    objLiquidacion.AF_Detraccion_adic = .AF_Detraccion_adic

                                    objLiquidacion.AF_Retencion_ini = .AF_Retencion_ini
                                    objLiquidacion.AF_Retencion_ns = .AF_Retencion_ns
                                    objLiquidacion.AF_Retencion_adic = .AF_Retencion_adic

                                    objLiquidacion.AF_Otrosng_ini = .AF_Otrosng_ini
                                    objLiquidacion.AF_Otrosng_ns = .AF_Otrosng_ns
                                    objLiquidacion.AF_Otrosng_adic = .AF_Otrosng_adic

                                    objLiquidacion.totalIngresos = .totalIngresos


                                Case "INCIDENCIA DIRECTA" ' CADENA DE SUMINISTROS

                                    objLiquidacion.LR_costov_ini = .LR_costov_ini
                                    objLiquidacion.LR_costov_ns = .LR_costov_ns
                                    objLiquidacion.LR_costov_adic = .LR_costov_adic

                                    '3ER REPORTE
                                    objLiquidacion.LOO_ReDeAp_ini = .LOO_ReDeAp_ini
                                    objLiquidacion.LOO_ReDeAp_ns = .LOO_ReDeAp_ns
                                    objLiquidacion.LOO_ReDeAp_adic = .LOO_ReDeAp_adic

                                    'ANALISIS FINANCIERO
                                    objLiquidacion.AF_TotalPagoProvSust_ini = .AF_TotalPagoProvSust_ini
                                    objLiquidacion.AF_TotalPagoProvSust_ns = .AF_TotalPagoProvSust_ns
                                    objLiquidacion.AF_TotalPagoProvSust_adic = .AF_TotalPagoProvSust_adic

                                    objLiquidacion.LP_TotalPagoProvCSSust_ini = .LP_TotalPagoProvCSSust_ini
                                    objLiquidacion.LP_TotalPagoProvCSSust_ns = .LP_TotalPagoProvCSSust_ns
                                    objLiquidacion.LP_TotalPagoProvCSSust_adic = .LP_TotalPagoProvCSSust_adic

                                    'NOS SUSTENTADOS
                                    objLiquidacion.AF_RefGastoNoSust_ini = .AF_RefGastoNoSust_ini
                                    objLiquidacion.AF_RefGastoNoSust_ns = .AF_RefGastoNoSust_ns
                                    objLiquidacion.AF_RefGastoNoSust_adic = .AF_RefGastoNoSust_adic
                                    Select Case .RefSustento1
                                        Case TipoReferenciaSustento.COSTO_IGV
                                            objLiquidacion.LI_cfAcum_ini = .LI_cfAcum_ini
                                            objLiquidacion.LI_cfAcum_ns = .LI_cfAcum_ns
                                            objLiquidacion.LI_afAcum_adic = .LI_afAcum_adic
                                        Case Else
                                            objLiquidacion.LI_cfAcum_ini = 0
                                            objLiquidacion.LI_cfAcum_ns = 0
                                            objLiquidacion.LI_afAcum_adic = 0
                                    End Select


                                Case "INCIDENCIA1"
                                    objLiquidacion.LR_inc_ns = .LR_inc_ns
                                    objLiquidacion.LR_inc_adic = .LR_inc_adic

                                    '3ER REPORTE
                                    objLiquidacion.LOO_ReDeAp_ns = .LOO_ReDeAp_ns
                                    objLiquidacion.LOO_ReDeAp_adic = .LOO_ReDeAp_adic

                                    'ANALISIS FINANCIERO
                                    objLiquidacion.AF_TotalPagoProvSust_ns = .AF_TotalPagoProvSust_ns
                                    objLiquidacion.AF_TotalPagoProvSust_adic = .AF_TotalPagoProvSust_adic
                                    'NOS SUSTENTADOS
                                    objLiquidacion.AF_RefGastoNoSust_ns = .AF_RefGastoNoSust_ns
                                    '  objLiquidacion.AF_RefGastoNoSust_adic = i.AF_RefGastoNoSust_adic
                                    'EGRESOS
                                    objLiquidacion.LP_EgresoNoSustentado_ns = .LP_EgresoNoSustentado_ns
                                    objLiquidacion.LP_EgresoNoSustentado_adic = .LP_EgresoNoSustentado_adic
                                    objLiquidacion.LP_EgresoInciAdic_adic = .LP_EgresoInciAdic_adic
                                    Select Case .RefSustento1
                                        Case TipoReferenciaSustento.COSTO_IGV
                                            objLiquidacion.LI_cfAcum_ns = .LI_cfAcum_ns
                                            objLiquidacion.LI_afAcum_adic = .LI_afAcum_adic

                                        Case Else
                                            objLiquidacion.LI_cfAcum_ns = 0
                                            objLiquidacion.LI_afAcum_adic = 0
                                    End Select
                            End Select
                            SaveLiquidacion(objLiquidacion, .Otros)
                        Else ' editar existente


                            Select Case .tipoLiquidacion

                                Case "INGRESOS"
                                    IntIdActividadRecurosVar = .secuencia '.CodigoDetalle

                                    objLiquidacion.LI_ib_ini = .LI_ib_ini
                                    objLiquidacion.LI_ib_ns = .LI_ib_ns
                                    objLiquidacion.LI_ib_adic = .LI_ib_adic

                                    objLiquidacion.LR_ventan_ini = .LR_ventan_ini
                                    objLiquidacion.LR_ventan_ns = .LR_ventan_ns
                                    objLiquidacion.LR_ventan_adic = .LR_ventan_adic

                                    objLiquidacion.detraccion_ini = .detraccion_ini
                                    objLiquidacion.detraccion_ns = .detraccion_ns
                                    objLiquidacion.detraccion_adic = .detraccion_adic

                                    'otros resportes
                                    '--------------------------------------------------------
                                    objLiquidacion.AF_EjecucionIng_ini = .AF_EjecucionIng_ini
                                    objLiquidacion.AF_EjecucionIng_ns = .AF_EjecucionIng_ns
                                    objLiquidacion.AF_EjecucionIng_adic = .AF_EjecucionIng_adic

                                    objLiquidacion.AF_Percepcion_ini = .AF_Percepcion_ini
                                    objLiquidacion.AF_Percepcion_ns = .AF_Percepcion_ns
                                    objLiquidacion.AF_Percepcion_adic = .AF_Percepcion_adic

                                    objLiquidacion.AF_Otrosps_ini = .AF_Otrosps_ini
                                    objLiquidacion.AF_Otrosps_ns = .AF_Otrosps_ns
                                    objLiquidacion.AF_Otrosps_adic = .AF_Otrosps_adic

                                    objLiquidacion.AF_Detraccion_ini = .AF_Detraccion_ini
                                    objLiquidacion.AF_Detraccion_ns = .AF_Detraccion_ns
                                    objLiquidacion.AF_Detraccion_adic = .AF_Detraccion_adic

                                    objLiquidacion.AF_Retencion_ini = .AF_Retencion_ini
                                    objLiquidacion.AF_Retencion_ns = .AF_Retencion_ns
                                    objLiquidacion.AF_Retencion_adic = .AF_Retencion_adic

                                    objLiquidacion.AF_Otrosng_ini = .AF_Otrosng_ini
                                    objLiquidacion.AF_Otrosng_ns = .AF_Otrosng_ns
                                    objLiquidacion.AF_Otrosng_adic = .AF_Otrosng_adic

                                    objLiquidacion.modulo = .modulo
                                    objLiquidacion.totalIngresos = .totalIngresos


                                Case "INCIDENCIA DIRECTA"
                                    IntIdActividadRecurosVar = .secuencia '.
                                    objLiquidacion.LR_costov_ini = .LR_costov_ini
                                    objLiquidacion.LR_costov_ns = .LR_costov_ns
                                    objLiquidacion.LR_costov_adic = .LR_costov_adic

                                    '3ER REPORTE
                                    objLiquidacion.LOO_ReDeAp_ini = .LOO_ReDeAp_ini
                                    objLiquidacion.LOO_ReDeAp_ns = .LOO_ReDeAp_ns
                                    objLiquidacion.LOO_ReDeAp_adic = .LOO_ReDeAp_adic

                                    'ANALISIS FINANCIERO
                                    objLiquidacion.AF_TotalPagoProvSust_ini = .AF_TotalPagoProvSust_ini
                                    objLiquidacion.AF_TotalPagoProvSust_ns = .AF_TotalPagoProvSust_ns
                                    objLiquidacion.AF_TotalPagoProvSust_adic = .AF_TotalPagoProvSust_adic
                                    'NOS SUSTENTADOS
                                    objLiquidacion.AF_RefGastoNoSust_ini = .AF_RefGastoNoSust_ini
                                    objLiquidacion.AF_RefGastoNoSust_ns = .AF_RefGastoNoSust_ns
                                    objLiquidacion.AF_RefGastoNoSust_adic = .AF_RefGastoNoSust_adic


                                    objLiquidacion.LP_TotalPagoProvCSSust_ini = .LP_TotalPagoProvCSSust_ini
                                    objLiquidacion.LP_TotalPagoProvCSSust_ns = .LP_TotalPagoProvCSSust_ns
                                    objLiquidacion.LP_TotalPagoProvCSSust_adic = .LP_TotalPagoProvCSSust_adic
                                    Select Case .RefSustento1
                                        Case TipoReferenciaSustento.COSTO_IGV
                                            objLiquidacion.LI_cfAcum_ini = .LI_cfAcum_ini
                                            objLiquidacion.LI_cfAcum_ns = .LI_cfAcum_ns
                                            objLiquidacion.LI_afAcum_adic = .LI_afAcum_adic
                                        Case Else
                                            objLiquidacion.LI_cfAcum_ini = 0
                                            objLiquidacion.LI_cfAcum_ns = 0
                                            objLiquidacion.LI_afAcum_adic = 0

                                    End Select

                                    objLiquidacion.modulo = .modulo

                                Case "INCIDENCIA1"
                                    objLiquidacion.LR_inc_ns = .LR_inc_ns
                                    objLiquidacion.LR_inc_adic = .LR_inc_adic
                                    IntIdActividadRecurosVar = .secuencia '.

                                    '3ER REPORTE
                                    objLiquidacion.LOO_ReDeAp_ns = .LOO_ReDeAp_ns
                                    objLiquidacion.LOO_ReDeAp_adic = .LOO_ReDeAp_adic

                                    'ANALISIS FINANCIERO
                                    objLiquidacion.AF_TotalPagoProvSust_ns = .AF_TotalPagoProvSust_ns
                                    objLiquidacion.AF_TotalPagoProvSust_adic = .AF_TotalPagoProvSust_adic
                                    'NOS SUSTENTADOS
                                    objLiquidacion.AF_RefGastoNoSust_ns = .AF_RefGastoNoSust_ns
                                    objLiquidacion.AF_RefGastoNoSust_adic = .AF_RefGastoNoSust_adic
                                    'EGRESOS
                                    objLiquidacion.LP_EgresoNoSustentado_ns = .LP_EgresoNoSustentado_ns
                                    objLiquidacion.LP_EgresoNoSustentado_adic = .LP_EgresoNoSustentado_adic
                                    objLiquidacion.LP_EgresoInciAdic_adic = .LP_EgresoInciAdic_adic
                                    Select Case .RefSustento1
                                        Case TipoReferenciaSustento.COSTO_IGV
                                            objLiquidacion.LI_cfAcum_ns = .LI_cfAcum_ns
                                            objLiquidacion.LI_afAcum_adic = .LI_afAcum_adic
                                        Case Else
                                            objLiquidacion.LI_cfAcum_ns = 0
                                            objLiquidacion.LI_afAcum_adic = 0

                                    End Select

                                    objLiquidacion.modulo = .modulo
                            End Select
                            UpdateLiquidacion(objLiquidacion, IntIdActividadRecurosVar, .Otros)
                        End If

                    End With
                Next
                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function UpdateLiquidacionPreliminar(ByVal objLiquidacionEO As totalesLiquidacion, ByVal objDeleteLiquidacion As totalesLiquidacion,
                                         ByVal intCodigoDetalle As Integer) As Boolean
        Dim objLiquidacion As New totalesLiquidacion()
        '  Dim intCodigoDetalle As Integer

        Dim listIngreso As New List(Of String)()
        listIngreso.Add("INGRESOS")

        Dim listCadena As New List(Of String)()
        listCadena.Add("CADIN")

        Dim CONSULTA As New totalesLiquidacion()
        Try
            Using ts As New TransactionScope()

                DeleteLiquidacionModal(objDeleteLiquidacion, intCodigoDetalle)

                Select Case objLiquidacionEO.Otros  'objLiquidacionEO.tipoLiquidacion
                    Case "INGRESOS"
                        Dim xEmpresa As String = objLiquidacionEO.idEmpresa
                        Dim xEstablec As String = objLiquidacionEO.idEstablecimiento
                        Dim xIdProy As Integer = objLiquidacionEO.idActividad
                        '    Dim xIdEstrategia As Integer = objLiquidacionEO.IdEstrategia
                        Dim xTipoPlan As String = objLiquidacionEO.tipoPlan

                        Dim xTipoLiquidacion As String = objLiquidacionEO.Otros
                        'CONSULTA = (From n In HeliosData.totalesLiquidacion _
                        '               Where n.idEmpresa = xEmpresa _
                        '               And n.idEstablecimiento = xEstablec _
                        '               And n.idActividad = xIdProy _
                        '               And n.tipoPlan = xTipoPlan _
                        '               And listIngreso.Contains(n.tipoLiquidacion)).FirstOrDefault

                        CONSULTA = HeliosData.totalesLiquidacion.Where(Function(o) o.idEmpresa = objDeleteLiquidacion.idEmpresa And _
                                                                       o.idEstablecimiento = objDeleteLiquidacion.idEstablecimiento And _
                                                                       o.idActividad = objDeleteLiquidacion.idActividad And _
                                                                       o.tipoPlan = objDeleteLiquidacion.tipoPlan And _
                                                                       listIngreso.Contains(o.tipoLiquidacion)).FirstOrDefault

                    Case "CADIN"

                        'And n.idProceso = xIdProceso _
                        'And n.idTarea = xIdTarea _

                        Dim xEmpresa As String = objLiquidacionEO.idEmpresa
                        Dim xEstablec As String = objLiquidacionEO.idEstablecimiento
                        Dim xIdProy As Integer = objLiquidacionEO.idActividad
                        '  Dim xIdEstrategia As Integer = objLiquidacionEO.IdEstrategia
                        'Dim xIdProceso As Integer = i.IdProceso
                        'Dim xIdTarea As Integer = i.IdTarea
                        Dim xTipoLiquidacion As String = objLiquidacionEO.Otros
                        Dim xTipoPlan As String = objLiquidacionEO.tipoPlan
                        'CONSULTA = (From n In HeliosData.totalesLiquidacion _
                        '               Where n.idEmpresa = xEmpresa _
                        '               And n.idEstablecimiento = xEstablec _
                        '               And n.idActividad = xIdProy _
                        '               And n.tipoPlan = xTipoPlan _
                        '               And listCadena.Contains(n.tipoLiquidacion)).FirstOrDefault


                        CONSULTA = HeliosData.totalesLiquidacion.Where(Function(o) o.idEmpresa = objDeleteLiquidacion.idEmpresa And _
                                                                       o.idEstablecimiento = objDeleteLiquidacion.idEstablecimiento And _
                                                                       o.idActividad = objDeleteLiquidacion.idActividad And _
                                                                       o.tipoPlan = objDeleteLiquidacion.tipoPlan And _
                                                                       listCadena.Contains(o.tipoLiquidacion)).FirstOrDefault
                End Select



                objLiquidacion = New totalesLiquidacion()
                objLiquidacion.idEmpresa = objLiquidacionEO.idEmpresa
                objLiquidacion.idEstablecimiento = objLiquidacionEO.idEstablecimiento
                objLiquidacion.idActividad = objLiquidacionEO.idActividad
                ' objLiquidacion.idEstrategia = objLiquidacionEO.IdEstrategia
                'objLiquidacion.idProceso = i.IdProceso
                'objLiquidacion.idTarea = i.IdTarea
                objLiquidacion.tipoLiquidacion = objLiquidacionEO.tipoLiquidacion
                objLiquidacion.modulo = objLiquidacionEO.modulo
                objLiquidacion.Fecha = objLiquidacionEO.Fecha

                objLiquidacion.tipoPlan = objLiquidacionEO.tipoPlan

                objLiquidacion.usuarioActualizacion = objLiquidacionEO.usuarioActualizacion
                objLiquidacion.fechaActualizacion = objLiquidacionEO.fechaActualizacion
                If IsNothing(CONSULTA) Then 'no existe agregar nuevo

                    Select Case objLiquidacionEO.tipoLiquidacion

                        Case "INGRESOS"
                            objLiquidacion.LI_ib_ini = objLiquidacionEO.LI_ib_ini
                            objLiquidacion.LI_ib_ns = objLiquidacionEO.LI_ib_ns
                            objLiquidacion.LI_ib_adic = objLiquidacionEO.LI_ib_adic

                            objLiquidacion.LR_ventan_ini = objLiquidacionEO.LR_ventan_ini
                            objLiquidacion.LR_ventan_ns = objLiquidacionEO.LR_ventan_ns
                            objLiquidacion.LR_ventan_adic = objLiquidacionEO.LR_ventan_adic

                            objLiquidacion.detraccion_ini = objLiquidacionEO.detraccion_ini
                            objLiquidacion.detraccion_ns = objLiquidacionEO.detraccion_ns
                            objLiquidacion.detraccion_adic = objLiquidacionEO.detraccion_adic

                            'otros resportes
                            '--------------------------------------------------------
                            objLiquidacion.AF_EjecucionIng_ini = objLiquidacionEO.AF_EjecucionIng_ini
                            objLiquidacion.AF_EjecucionIng_ns = objLiquidacionEO.AF_EjecucionIng_ns
                            objLiquidacion.AF_EjecucionIng_adic = objLiquidacionEO.AF_EjecucionIng_adic

                            objLiquidacion.AF_Percepcion_ini = objLiquidacionEO.AF_Percepcion_ini
                            objLiquidacion.AF_Percepcion_ns = objLiquidacionEO.AF_Percepcion_ns
                            objLiquidacion.AF_Percepcion_adic = objLiquidacionEO.AF_Percepcion_adic

                            objLiquidacion.AF_Otrosps_ini = objLiquidacionEO.AF_Otrosps_ini
                            objLiquidacion.AF_Otrosps_ns = objLiquidacionEO.AF_Otrosps_ns
                            objLiquidacion.AF_Otrosps_adic = objLiquidacionEO.AF_Otrosps_adic

                            objLiquidacion.AF_Detraccion_ini = objLiquidacionEO.AF_Detraccion_ini
                            objLiquidacion.AF_Detraccion_ns = objLiquidacionEO.AF_Detraccion_ns
                            objLiquidacion.AF_Detraccion_adic = objLiquidacionEO.AF_Detraccion_adic

                            objLiquidacion.AF_Retencion_ini = objLiquidacionEO.AF_Retencion_ini
                            objLiquidacion.AF_Retencion_ns = objLiquidacionEO.AF_Retencion_ns
                            objLiquidacion.AF_Retencion_adic = objLiquidacionEO.AF_Retencion_adic

                            objLiquidacion.AF_Otrosng_ini = objLiquidacionEO.AF_Otrosng_ini
                            objLiquidacion.AF_Otrosng_ns = objLiquidacionEO.AF_Otrosng_ns
                            objLiquidacion.AF_Otrosng_adic = objLiquidacionEO.AF_Otrosng_adic

                            objLiquidacion.totalIngresos = objLiquidacionEO.totalIngresos


                        Case "INCIDENCIA DIRECTA" ' CADENA DE SUMINISTROS

                            objLiquidacion.LR_costov_ini = objLiquidacionEO.LR_costov_ini
                            objLiquidacion.LR_costov_ns = objLiquidacionEO.LR_costov_ns
                            objLiquidacion.LR_costov_adic = objLiquidacionEO.LR_costov_adic

                            '3ER REPORTE
                            objLiquidacion.LOO_ReDeAp_ini = objLiquidacionEO.LOO_ReDeAp_ini
                            objLiquidacion.LOO_ReDeAp_ns = objLiquidacionEO.LOO_ReDeAp_ns
                            objLiquidacion.LOO_ReDeAp_adic = objLiquidacionEO.LOO_ReDeAp_adic

                            'ANALISIS FINANCIERO


                            objLiquidacion.AF_TotalPagoProvSust_ini = objLiquidacionEO.AF_TotalPagoProvSust_ini
                            objLiquidacion.AF_TotalPagoProvSust_ns = objLiquidacionEO.AF_TotalPagoProvSust_ns
                            objLiquidacion.AF_TotalPagoProvSust_adic = objLiquidacionEO.AF_TotalPagoProvSust_adic

                            objLiquidacion.LP_TotalPagoProvCSSust_ini = objLiquidacionEO.LP_TotalPagoProvCSSust_ini
                            objLiquidacion.LP_TotalPagoProvCSSust_ns = objLiquidacionEO.LP_TotalPagoProvCSSust_ns
                            objLiquidacion.LP_TotalPagoProvCSSust_adic = objLiquidacionEO.LP_TotalPagoProvCSSust_adic

                            'NOS SUSTENTADOS
                            objLiquidacion.AF_RefGastoNoSust_ini = objLiquidacionEO.AF_RefGastoNoSust_ini
                            objLiquidacion.AF_RefGastoNoSust_ns = objLiquidacionEO.AF_RefGastoNoSust_ns
                            objLiquidacion.AF_RefGastoNoSust_adic = objLiquidacionEO.AF_RefGastoNoSust_adic
                            Select Case objLiquidacionEO.RefSustento1
                                Case TipoReferenciaSustento.COSTO_IGV
                                    objLiquidacion.LI_cfAcum_ini = objLiquidacionEO.LI_cfAcum_ini
                                    objLiquidacion.LI_cfAcum_ns = objLiquidacionEO.LI_cfAcum_ns
                                    objLiquidacion.LI_afAcum_adic = objLiquidacionEO.LI_afAcum_adic
                                Case Else
                                    objLiquidacion.LI_cfAcum_ini = 0
                                    objLiquidacion.LI_cfAcum_ns = 0
                                    objLiquidacion.LI_afAcum_adic = 0
                            End Select


                        Case "INCIDENCIA1"
                            objLiquidacion.LR_inc_ns = objLiquidacionEO.LR_inc_ns
                            objLiquidacion.LR_inc_adic = objLiquidacionEO.LR_inc_adic

                            '3ER REPORTE
                            objLiquidacion.LOO_ReDeAp_ns = objLiquidacionEO.LOO_ReDeAp_ns
                            objLiquidacion.LOO_ReDeAp_adic = objLiquidacionEO.LOO_ReDeAp_adic

                            'ANALISIS FINANCIERO
                            objLiquidacion.AF_TotalPagoProvSust_ns = objLiquidacionEO.AF_TotalPagoProvSust_ns
                            objLiquidacion.AF_TotalPagoProvSust_adic = objLiquidacionEO.AF_TotalPagoProvSust_adic
                            'NOS SUSTENTADOS
                            objLiquidacion.AF_RefGastoNoSust_ns = objLiquidacionEO.AF_RefGastoNoSust_ns
                            objLiquidacion.AF_RefGastoNoSust_adic = objLiquidacionEO.AF_RefGastoNoSust_adic
                            'EGRESOS
                            objLiquidacion.LP_EgresoNoSustentado_ns = objLiquidacionEO.LP_EgresoNoSustentado_ns
                            objLiquidacion.LP_EgresoNoSustentado_adic = objLiquidacionEO.LP_EgresoNoSustentado_adic
                            objLiquidacion.LP_EgresoInciAdic_adic = objLiquidacionEO.LP_EgresoInciAdic_adic
                            Select Case objLiquidacionEO.RefSustento1
                                Case TipoReferenciaSustento.COSTO_IGV
                                    objLiquidacion.LI_cfAcum_ns = objLiquidacionEO.LI_cfAcum_ns
                                    objLiquidacion.LI_afAcum_adic = objLiquidacionEO.LI_afAcum_adic

                                Case Else
                                    objLiquidacion.LI_cfAcum_ns = 0
                                    objLiquidacion.LI_afAcum_adic = 0
                            End Select
                    End Select
                    '  objContext.AddTototalesLiquidacion(objLiquidacion)

                    SaveLiquidacion(objLiquidacion, objLiquidacionEO.Otros)
                Else ' editar existente

                    'objLiquidacion.usuarioActualizacion = i.UsuarioActualizacion
                    'objLiquidacion.fechaActualizacion = i.FechaActualizacion
                    Select Case objLiquidacionEO.tipoLiquidacion

                        Case "INGRESOS"
                            intCodigoDetalle = intCodigoDetalle '.CodigoDetalle

                            objLiquidacion.LI_ib_ini = objLiquidacionEO.LI_ib_ini
                            objLiquidacion.LI_ib_ns = objLiquidacionEO.LI_ib_ns
                            objLiquidacion.LI_ib_adic = objLiquidacionEO.LI_ib_adic

                            objLiquidacion.LR_ventan_ini = objLiquidacionEO.LR_ventan_ini
                            objLiquidacion.LR_ventan_ns = objLiquidacionEO.LR_ventan_ns
                            objLiquidacion.LR_ventan_adic = objLiquidacionEO.LR_ventan_adic

                            objLiquidacion.detraccion_ini = objLiquidacionEO.detraccion_ini
                            objLiquidacion.detraccion_ns = objLiquidacionEO.detraccion_ns
                            objLiquidacion.detraccion_adic = objLiquidacionEO.detraccion_adic

                            'otros resportes
                            '--------------------------------------------------------
                            objLiquidacion.AF_EjecucionIng_ini = objLiquidacionEO.AF_EjecucionIng_ini
                            objLiquidacion.AF_EjecucionIng_ns = objLiquidacionEO.AF_EjecucionIng_ns
                            objLiquidacion.AF_EjecucionIng_adic = objLiquidacionEO.AF_EjecucionIng_adic

                            objLiquidacion.AF_Percepcion_ini = objLiquidacionEO.AF_Percepcion_ini
                            objLiquidacion.AF_Percepcion_ns = objLiquidacionEO.AF_Percepcion_ns
                            objLiquidacion.AF_Percepcion_adic = objLiquidacionEO.AF_Percepcion_adic

                            objLiquidacion.AF_Otrosps_ini = objLiquidacionEO.AF_Otrosps_ini
                            objLiquidacion.AF_Otrosps_ns = objLiquidacionEO.AF_Otrosps_ns
                            objLiquidacion.AF_Otrosps_adic = objLiquidacionEO.AF_Otrosps_adic

                            objLiquidacion.AF_Detraccion_ini = objLiquidacionEO.AF_Detraccion_ini
                            objLiquidacion.AF_Detraccion_ns = objLiquidacionEO.AF_Detraccion_ns
                            objLiquidacion.AF_Detraccion_adic = objLiquidacionEO.AF_Detraccion_adic

                            objLiquidacion.AF_Retencion_ini = objLiquidacionEO.AF_Retencion_ini
                            objLiquidacion.AF_Retencion_ns = objLiquidacionEO.AF_Retencion_ns
                            objLiquidacion.AF_Retencion_adic = objLiquidacionEO.AF_Retencion_adic

                            objLiquidacion.AF_Otrosng_ini = objLiquidacionEO.AF_Otrosng_ini
                            objLiquidacion.AF_Otrosng_ns = objLiquidacionEO.AF_Otrosng_ns
                            objLiquidacion.AF_Otrosng_adic = objLiquidacionEO.AF_Otrosng_adic

                            objLiquidacion.modulo = objLiquidacionEO.modulo
                            objLiquidacion.totalIngresos = objLiquidacionEO.totalIngresos


                        Case "INCIDENCIA DIRECTA"
                            intCodigoDetalle = objLiquidacionEO.secuencia '.
                            objLiquidacion.LR_costov_ini = objLiquidacionEO.LR_costov_ini
                            objLiquidacion.LR_costov_ns = objLiquidacionEO.LR_costov_ns
                            objLiquidacion.LR_costov_adic = objLiquidacionEO.LR_costov_adic

                            '3ER REPORTE
                            objLiquidacion.LOO_ReDeAp_ini = objLiquidacionEO.LOO_ReDeAp_ini
                            objLiquidacion.LOO_ReDeAp_ns = objLiquidacionEO.LOO_ReDeAp_ns
                            objLiquidacion.LOO_ReDeAp_adic = objLiquidacionEO.LOO_ReDeAp_adic

                            'ANALISIS FINANCIERO
                            objLiquidacion.AF_TotalPagoProvSust_ini = objLiquidacionEO.AF_TotalPagoProvSust_ini
                            objLiquidacion.AF_TotalPagoProvSust_ns = objLiquidacionEO.AF_TotalPagoProvSust_ns
                            objLiquidacion.AF_TotalPagoProvSust_adic = objLiquidacionEO.AF_TotalPagoProvSust_adic
                            'NOS SUSTENTADOS
                            objLiquidacion.AF_RefGastoNoSust_ini = objLiquidacionEO.AF_RefGastoNoSust_ini
                            objLiquidacion.AF_RefGastoNoSust_ns = objLiquidacionEO.AF_RefGastoNoSust_ns
                            objLiquidacion.AF_RefGastoNoSust_adic = objLiquidacionEO.AF_RefGastoNoSust_adic


                            objLiquidacion.LP_TotalPagoProvCSSust_ini = objLiquidacionEO.LP_TotalPagoProvCSSust_ini
                            objLiquidacion.LP_TotalPagoProvCSSust_ns = objLiquidacionEO.LP_TotalPagoProvCSSust_ns
                            objLiquidacion.LP_TotalPagoProvCSSust_adic = objLiquidacionEO.LP_TotalPagoProvCSSust_adic
                            Select Case objLiquidacionEO.RefSustento1
                                Case TipoReferenciaSustento.COSTO_IGV
                                    objLiquidacion.LI_cfAcum_ini = objLiquidacionEO.LI_cfAcum_ini
                                    objLiquidacion.LI_cfAcum_ns = objLiquidacionEO.LI_cfAcum_ns
                                    objLiquidacion.LI_afAcum_adic = objLiquidacionEO.LI_afAcum_adic
                                Case Else
                                    objLiquidacion.LI_cfAcum_ini = 0
                                    objLiquidacion.LI_cfAcum_ns = 0
                                    objLiquidacion.LI_afAcum_adic = 0

                            End Select

                            objLiquidacion.modulo = objLiquidacionEO.modulo

                        Case "INCIDENCIA1"
                            objLiquidacion.LR_inc_ns = objLiquidacionEO.LR_inc_ns
                            objLiquidacion.LR_inc_adic = objLiquidacionEO.LR_inc_adic
                            intCodigoDetalle = objLiquidacionEO.secuencia '.

                            '3ER REPORTE
                            objLiquidacion.LOO_ReDeAp_ns = objLiquidacionEO.LOO_ReDeAp_ns
                            objLiquidacion.LOO_ReDeAp_adic = objLiquidacionEO.LOO_ReDeAp_adic

                            'ANALISIS FINANCIERO
                            objLiquidacion.AF_TotalPagoProvSust_ns = objLiquidacionEO.AF_TotalPagoProvSust_ns
                            objLiquidacion.AF_TotalPagoProvSust_adic = objLiquidacionEO.AF_TotalPagoProvSust_adic
                            'NOS SUSTENTADOS
                            objLiquidacion.AF_RefGastoNoSust_ns = objLiquidacionEO.AF_RefGastoNoSust_ns
                            objLiquidacion.AF_RefGastoNoSust_adic = objLiquidacionEO.AF_RefGastoNoSust_adic
                            'EGRESOS
                            objLiquidacion.LP_EgresoNoSustentado_ns = objLiquidacionEO.LP_EgresoNoSustentado_ns
                            objLiquidacion.LP_EgresoNoSustentado_adic = objLiquidacionEO.LP_EgresoNoSustentado_adic
                            objLiquidacion.LP_EgresoInciAdic_adic = objLiquidacionEO.LP_EgresoInciAdic_adic
                            Select Case objLiquidacionEO.RefSustento1
                                Case TipoReferenciaSustento.COSTO_IGV
                                    objLiquidacion.LI_cfAcum_ns = objLiquidacionEO.LI_cfAcum_ns
                                    objLiquidacion.LI_afAcum_adic = objLiquidacionEO.LI_afAcum_adic
                                Case Else
                                    objLiquidacion.LI_cfAcum_ns = 0
                                    objLiquidacion.LI_afAcum_adic = 0

                            End Select

                            objLiquidacion.modulo = objLiquidacionEO.modulo
                    End Select
                    UpdateLiquidacion(objLiquidacion, intCodigoDetalle, objLiquidacionEO.Otros)
                End If

                ' Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteLiquidacionModal(ByVal objDeleteLiquidacion As totalesLiquidacion,
                                           ByVal intCodigoDetalle As Integer) As Boolean
        Dim objNuevo As New totalesLiquidacion()
        Dim objDetalle As New actividadRecursoBL()
        '                                     And n.tipoLiquidacion = Me.TipoLiquidacion
        Dim listIngreso As New List(Of String)()
        listIngreso.Add("INGRESOS")

        Dim listCadena As New List(Of String)()
        listCadena.Add("CADIN")
        ' listCadena.Add("INCIDENCIA DIRECTA")
        Try
            Using TS As New TransactionScope()
                'And n.idProceso = Me.IdProceso _
                'And n.idTarea = Me.IdTarea _

                Dim objBackDoc = (From k In HeliosData.actividadRecurso _
                                            Where k.idActividadRecurso = intCodigoDetalle).First

                Select Case objDeleteLiquidacion.Otros
                    Case "INGRESOS"
                        'objNuevo = (From n In HeliosData.totalesLiquidacion _
                        '         Where n.idEmpresa = objDeleteLiquidacion.idEmpresa _
                        '         And n.idEstablecimiento = objDeleteLiquidacion.idEstablecimiento _
                        '         And n.idActividad = objDeleteLiquidacion.idActividad _
                        '         And n.tipoPlan = objDeleteLiquidacion.tipoPlan _
                        '         And listIngreso.Contains(n.tipoLiquidacion)).FirstOrDefault

                        objNuevo = HeliosData.totalesLiquidacion.Where(Function(o) o.idEmpresa = objDeleteLiquidacion.idEmpresa And _
                                                                           o.idEstablecimiento = objDeleteLiquidacion.idEstablecimiento And _
                                                                           o.idActividad = objDeleteLiquidacion.idActividad And _
                                                                           o.tipoPlan = objDeleteLiquidacion.tipoPlan And _
                                                                           listIngreso.Contains(o.tipoLiquidacion)).FirstOrDefault
                    Case "CADIN"

                        'objNuevo = (From n In HeliosData.totalesLiquidacion _
                        '         Where n.idEmpresa = objDeleteLiquidacion.idEmpresa _
                        '         And n.idEstablecimiento = objDeleteLiquidacion.idEstablecimiento _
                        '         And n.idActividad = objDeleteLiquidacion.idActividad _
                        '         And n.tipoPlan = objDeleteLiquidacion.tipoPlan _
                        '         And listCadena.Contains(n.tipoLiquidacion)).FirstOrDefault

                        objNuevo = HeliosData.totalesLiquidacion.Where(Function(o) o.idEmpresa = objDeleteLiquidacion.idEmpresa And _
                                                                        o.idEstablecimiento = objDeleteLiquidacion.idEstablecimiento And _
                                                                        o.idActividad = objDeleteLiquidacion.idActividad And _
                                                                        o.tipoPlan = objDeleteLiquidacion.tipoPlan And _
                                                                        listCadena.Contains(o.tipoLiquidacion)).FirstOrDefault
                End Select


                'objNuevo = (From n In objContext.totalesLiquidacion _
                '                 Where n.idEmpresa = Me.IdEmpresa _
                '                 And n.idEstablecimiento = Me.IdEstablecimiento _
                '                 And n.idProyecto = Me.IdProyecto _
                '                 And n.idEstrategia = Me.IdEstrategia _
                '                 And n.idProceso = Me.IdProceso _
                '                 And n.idTarea = Me.IdTarea).FirstOrDefault

                With objNuevo

                    Select Case objDeleteLiquidacion.tipoLiquidacion

                        Case "INGRESOS"
                            If Not IsNothing(objNuevo) Then
                                objNuevo.LI_ib_ini = objNuevo.LI_ib_ini - objBackDoc.Igv
                                objNuevo.LI_ib_ns = objNuevo.LI_ib_ns - objBackDoc.Igv
                                objNuevo.LI_ib_adic = objNuevo.LI_ib_adic - objBackDoc.Igv

                                objNuevo.LR_ventan_ini = objNuevo.LR_ventan_ini - objBackDoc.ValorVenta
                                objNuevo.LR_ventan_ns = objNuevo.LR_ventan_ns - objBackDoc.ValorVenta
                                objNuevo.LR_ventan_adic = objNuevo.LR_ventan_adic - objBackDoc.ValorVenta

                                objNuevo.detraccion_ini = objNuevo.detraccion_ini - objBackDoc.Detracciones
                                objNuevo.detraccion_ns = objNuevo.detraccion_ns - objBackDoc.Detracciones
                                objNuevo.detraccion_adic = objNuevo.detraccion_adic - objBackDoc.Detracciones

                                'otros reportes
                                '-------------------------------------------------------------------------------------------------
                                objNuevo.AF_EjecucionIng_ini = objNuevo.AF_EjecucionIng_ini - objBackDoc.TotalProyecto
                                objNuevo.AF_EjecucionIng_ns = objNuevo.AF_EjecucionIng_ns - objBackDoc.TotalProyecto
                                objNuevo.AF_EjecucionIng_adic = objNuevo.AF_EjecucionIng_adic - objBackDoc.TotalProyecto

                                objNuevo.AF_Percepcion_ini = objNuevo.AF_Percepcion_ini - objBackDoc.Percepciones
                                objNuevo.AF_Percepcion_ns = objNuevo.AF_Percepcion_ns - objBackDoc.Percepciones
                                objNuevo.AF_Percepcion_adic = objNuevo.AF_Percepcion_adic - objBackDoc.Percepciones

                                objNuevo.AF_Otrosps_ini = objNuevo.AF_Otrosps_ini - objBackDoc.OtrosIn2
                                objNuevo.AF_Otrosps_ns = objNuevo.AF_Otrosps_ns - objBackDoc.OtrosIn2
                                objNuevo.AF_Otrosps_adic = objNuevo.AF_Otrosps_adic - objBackDoc.OtrosIn2

                                objNuevo.AF_Detraccion_ini = objNuevo.AF_Detraccion_ini - objBackDoc.Detracciones
                                objNuevo.AF_Detraccion_ns = objNuevo.AF_Detraccion_ns - objBackDoc.Detracciones
                                objNuevo.AF_Detraccion_adic = objNuevo.AF_Detraccion_adic - objBackDoc.Detracciones

                                objNuevo.AF_Retencion_ini = objNuevo.AF_Retencion_ini - objBackDoc.Retenciones
                                objNuevo.AF_Retencion_ns = objNuevo.AF_Retencion_ns - objBackDoc.Retenciones
                                objNuevo.AF_Retencion_adic = objNuevo.AF_Retencion_adic - objBackDoc.Retenciones

                                objNuevo.AF_Otrosng_ini = objNuevo.AF_Otrosng_ini - objBackDoc.OtroIn3
                                objNuevo.AF_Otrosng_ns = objNuevo.AF_Otrosng_ns - objBackDoc.OtroIn3
                                objNuevo.AF_Otrosng_adic = objNuevo.AF_Otrosng_adic - objBackDoc.OtroIn3

                                objNuevo.totalIngresos = objNuevo.totalIngresos - objBackDoc.TotalProyecto
                            End If
                        Case "INCIDENCIA DIRECTA"
                            If Not IsNothing(objNuevo) Then

                                objNuevo.LI_cfAcum_ini = objNuevo.LI_cfAcum_ini - objBackDoc.Igv.Value
                                objNuevo.LI_cfAcum_ns = objNuevo.LI_cfAcum_ns - objBackDoc.Igv
                                objNuevo.LI_afAcum_adic = objNuevo.LI_afAcum_adic - objBackDoc.Igv

                                Dim x1 As Decimal = 0
                                x1 = objBackDoc.Costo + objBackDoc.Otros1 + objBackDoc.AporPlanilla
                                objNuevo.LR_costov_ini = objNuevo.LR_costov_ini - x1
                                objNuevo.LR_costov_ns = objNuevo.LR_costov_ns - x1
                                objNuevo.LR_costov_adic = objNuevo.LR_costov_adic - x1

                                '3ER REPORTE---------------------------------------------------------------------------------------------------
                                objNuevo.LOO_ReDeAp_ini = objNuevo.LOO_ReDeAp_ini - objBackDoc.TotalRetenciones
                                objNuevo.LOO_ReDeAp_ns = objNuevo.LOO_ReDeAp_ns - objBackDoc.TotalRetenciones
                                objNuevo.LOO_ReDeAp_adic = objNuevo.LOO_ReDeAp_adic - objBackDoc.TotalRetenciones

                                Select Case objBackDoc.ReferenciaSustento
                                    Case TipoReferenciaSustento.COSTO_IGV, TipoReferenciaSustento.SOLO_COSTO
                                        'analisis FINANCIERO-------------------------------------------------------------------------------------------
                                        objNuevo.AF_TotalPagoProvSust_ini = objNuevo.AF_TotalPagoProvSust_ini - objBackDoc.NetoPagar
                                        objNuevo.AF_TotalPagoProvSust_ns = objNuevo.AF_TotalPagoProvSust_ns - objBackDoc.NetoPagar
                                        objNuevo.AF_TotalPagoProvSust_adic = objNuevo.AF_TotalPagoProvSust_adic - objBackDoc.NetoPagar
                                    Case TipoReferenciaSustento.NO_SUSTENTADO
                                        'no sustentados
                                        objNuevo.AF_RefGastoNoSust_ini = objNuevo.AF_RefGastoNoSust_ini - objBackDoc.NoSustentado
                                        objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns - objBackDoc.NoSustentado
                                        objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic - objBackDoc.NoSustentado
                                End Select

                                'LIQUIDACION PLANEAMIENTO
                                objNuevo.LP_TotalPagoProvCSSust_ini = objNuevo.LP_TotalPagoProvCSSust_ini - objBackDoc.NetoPagar
                                objNuevo.LP_TotalPagoProvCSSust_ns = objNuevo.LP_TotalPagoProvCSSust_ns - objBackDoc.NetoPagar
                                objNuevo.LP_TotalPagoProvCSSust_adic = objNuevo.LP_TotalPagoProvCSSust_adic - objBackDoc.NetoPagar
                            End If


                        Case "INCIDENCIA1"
                            If Not IsNothing(objNuevo) Then

                                Select Case objBackDoc.TipoIncidencia
                                    Case TipoIncidencia.INC_NO_SUSTENTADO
                                        objNuevo.LP_EgresoNoSustentado_ns = objNuevo.LP_EgresoNoSustentado_ns - objBackDoc.TotalImpor
                                        objNuevo.LP_EgresoNoSustentado_adic = objNuevo.LP_EgresoNoSustentado_adic - objBackDoc.TotalImpor

                                        '   objNuevo.LP_EgresoInciAdic_adic = objNuevo.LP_EgresoInciAdic_adic - objBackDoc.TotalImpor


                                        objNuevo.LI_cfAcum_ns = objNuevo.LI_cfAcum_ns - objBackDoc.Igv
                                        objNuevo.LI_afAcum_adic = objNuevo.LI_afAcum_adic - objBackDoc.Igv
                                        '    3ER REPORTE-------------------------------------------------------
                                        objNuevo.LOO_ReDeAp_ns = objNuevo.LOO_ReDeAp_ns - objBackDoc.TotalRetenciones
                                        objNuevo.LOO_ReDeAp_adic = objNuevo.LOO_ReDeAp_adic - objBackDoc.TotalRetenciones

                                        Dim X As Decimal = 0
                                        X = objBackDoc.Costo + objBackDoc.Otros1 + objBackDoc.AporPlanilla
                                        objNuevo.LR_inc_ns = objNuevo.LR_inc_ns - X
                                        objNuevo.LR_inc_adic = objNuevo.LR_inc_adic - X


                                        Select Case objBackDoc.ReferenciaSustento
                                            Case TipoReferenciaSustento.COSTO_IGV, TipoReferenciaSustento.SOLO_COSTO
                                                ' analisis(FINANCIERO)
                                                objNuevo.AF_TotalPagoProvSust_ns = objNuevo.AF_TotalPagoProvSust_ns - objBackDoc.NetoPagar
                                                objNuevo.AF_TotalPagoProvSust_adic = objNuevo.AF_TotalPagoProvSust_adic - objBackDoc.NetoPagar

                                            Case TipoReferenciaSustento.NO_SUSTENTADO
                                                '  no(sustentados)
                                                Dim xRefGasto As Decimal = objBackDoc.TotalCosto + objBackDoc.TotalAporte
                                                If CDec(objNuevo.AF_RefGastoNoSust_ns) > 0 Then
                                                    objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns - xRefGasto
                                                    '  objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic - xRefGasto
                                                Else
                                                    objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns + xRefGasto
                                                    '  objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic + xRefGasto
                                                End If
                                        End Select

                                    Case TipoIncidencia.INC_ADIC
                                        'objNuevo.LP_EgresoNoSustentado_ns = objNuevo.LP_EgresoNoSustentado_ns - objBackDoc.TotalImpor
                                        'objNuevo.LP_EgresoNoSustentado_adic = objNuevo.LP_EgresoNoSustentado_adic - objBackDoc.TotalImpor

                                        objNuevo.LP_EgresoInciAdic_adic = objNuevo.LP_EgresoInciAdic_adic - objBackDoc.TotalImpor

                                        objNuevo.LI_afAcum_adic = objNuevo.LI_afAcum_adic - objBackDoc.Igv
                                        ' 3ER REPORTE-------------------------------------------------------
                                        objNuevo.LOO_ReDeAp_adic = objNuevo.LOO_ReDeAp_adic - objBackDoc.TotalRetenciones

                                        Dim X As Decimal = 0
                                        X = objBackDoc.Costo + objBackDoc.Otros1 + objBackDoc.AporPlanilla
                                        objNuevo.LR_inc_adic = objNuevo.LR_inc_adic - X


                                        Select Case objBackDoc.ReferenciaSustento
                                            Case TipoReferenciaSustento.COSTO_IGV, TipoReferenciaSustento.SOLO_COSTO
                                                'analisis FINANCIERO
                                                '    objNuevo.AF_TotalPagoProvSust_ns = objNuevo.AF_TotalPagoProvSust_ns - objBackDoc.NetoPagar
                                                objNuevo.AF_TotalPagoProvSust_adic = objNuevo.AF_TotalPagoProvSust_adic - objBackDoc.NetoPagar

                                            Case TipoReferenciaSustento.NO_SUSTENTADO
                                                ''no sustentados
                                                'If CDec(objNuevo.AF_RefGastoNoSust_ns) > 0 Then
                                                '    objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns - objBackDoc.Total
                                                '    objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic - objBackDoc.Total
                                                'Else
                                                '    objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns + objBackDoc.Total
                                                '    objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic + objBackDoc.Total
                                                'End If

                                        End Select
                                End Select

                            End If
                    End Select

                End With

                'objDetalle.DeleteDefault(objDeleteLiquidacion.secuencia)
                'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                HeliosData.SaveChanges()
                TS.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteTotalLiquidacionSingle(nLiquidacion As totalesLiquidacion)
        Dim objNuevo As New totalesLiquidacion()
        Dim objDetalle As New actividadRecursoBL()
        '                                     And n.tipoLiquidacion = Me.TipoLiquidacion
        Dim listIngreso As New List(Of String)()
        listIngreso.Add("INGRESOS")

        Dim listCadena As New List(Of String)()
        listCadena.Add("CADIN")

        Try
            Using TS As New TransactionScope()
                Select Case nLiquidacion.Otros
                    Case "INGRESOS"
                        objNuevo = HeliosData.totalesLiquidacion.Where(Function(o) o.idEmpresa = nLiquidacion.idEmpresa And _
                                                                         o.idEstablecimiento = nLiquidacion.idEstablecimiento And _
                                                                         o.idActividad = nLiquidacion.idActividad And _
                                                                         o.tipoPlan = nLiquidacion.tipoPlan And _
                                                                         listIngreso.Contains(o.tipoLiquidacion)).FirstOrDefault
                    Case "CADIN"
                        objNuevo = HeliosData.totalesLiquidacion.Where(Function(o) o.idEmpresa = nLiquidacion.idEmpresa And _
                                                                    o.idEstablecimiento = nLiquidacion.idEstablecimiento And _
                                                                    o.idActividad = nLiquidacion.idActividad And _
                                                                    o.tipoPlan = nLiquidacion.tipoPlan And _
                                                                    listCadena.Contains(o.tipoLiquidacion)).FirstOrDefault
                End Select


                With objNuevo


                    Select Case nLiquidacion.tipoLiquidacion

                        Case "INGRESOS"
                            objNuevo.LI_ib_ini = objNuevo.LI_ib_ini - nLiquidacion.LI_ib_ini
                            objNuevo.LI_ib_ns = objNuevo.LI_ib_ns - nLiquidacion.LI_ib_ns
                            objNuevo.LI_ib_adic = objNuevo.LI_ib_adic - nLiquidacion.LI_ib_adic

                            objNuevo.LR_ventan_ini = objNuevo.LR_ventan_ini - nLiquidacion.LR_ventan_ini
                            objNuevo.LR_ventan_ns = objNuevo.LR_ventan_ns - nLiquidacion.LR_ventan_ns
                            objNuevo.LR_ventan_adic = objNuevo.LR_ventan_adic - nLiquidacion.LR_ventan_adic

                            objNuevo.detraccion_ini = objNuevo.detraccion_ini - nLiquidacion.detraccion_ini
                            objNuevo.detraccion_ns = objNuevo.detraccion_ns - nLiquidacion.detraccion_ns
                            objNuevo.detraccion_adic = objNuevo.detraccion_adic - nLiquidacion.detraccion_adic

                            'otros reportes
                            '--------------------------------------------------------
                            objNuevo.AF_EjecucionIng_ini = objNuevo.AF_EjecucionIng_ini - nLiquidacion.AF_EjecucionIng_ini
                            objNuevo.AF_EjecucionIng_ns = objNuevo.AF_EjecucionIng_ns - nLiquidacion.AF_EjecucionIng_ns
                            objNuevo.AF_EjecucionIng_adic = objNuevo.AF_EjecucionIng_adic - nLiquidacion.AF_EjecucionIng_adic

                            objNuevo.AF_Percepcion_ini = objNuevo.AF_Percepcion_ini - nLiquidacion.AF_Percepcion_ini
                            objNuevo.AF_Percepcion_ns = objNuevo.AF_Percepcion_ns - nLiquidacion.AF_Percepcion_ns
                            objNuevo.AF_Percepcion_adic = objNuevo.AF_Percepcion_adic - nLiquidacion.AF_Percepcion_adic

                            objNuevo.AF_Otrosps_ini = objNuevo.AF_Otrosps_ini - nLiquidacion.AF_Otrosps_ini
                            objNuevo.AF_Otrosps_ns = objNuevo.AF_Otrosps_ns - nLiquidacion.AF_Otrosps_ns
                            objNuevo.AF_Otrosps_adic = objNuevo.AF_Otrosps_adic - nLiquidacion.AF_Otrosps_adic

                            objNuevo.AF_Detraccion_ini = objNuevo.AF_Detraccion_ini - nLiquidacion.AF_Detraccion_ini
                            objNuevo.AF_Detraccion_ns = objNuevo.AF_Detraccion_ns - nLiquidacion.AF_Detraccion_ns
                            objNuevo.AF_Detraccion_adic = objNuevo.AF_Detraccion_adic - nLiquidacion.AF_Detraccion_adic

                            objNuevo.AF_Retencion_ini = objNuevo.AF_Retencion_ini - nLiquidacion.AF_Retencion_ini
                            objNuevo.AF_Retencion_ns = objNuevo.AF_Retencion_ns - nLiquidacion.AF_Retencion_ns
                            objNuevo.AF_Retencion_adic = objNuevo.AF_Retencion_adic - nLiquidacion.AF_Retencion_adic

                            objNuevo.AF_Otrosng_ini = objNuevo.AF_Otrosng_ini - nLiquidacion.AF_Otrosng_ini
                            objNuevo.AF_Otrosng_ns = objNuevo.AF_Otrosng_ns - nLiquidacion.AF_Otrosng_ns
                            objNuevo.AF_Otrosng_adic = objNuevo.AF_Otrosng_adic - nLiquidacion.AF_Otrosng_adic

                            objNuevo.totalIngresos = objNuevo.totalIngresos - nLiquidacion.totalIngresos

                        Case "INCIDENCIA DIRECTA"
                            objNuevo.LI_cfAcum_ini = objNuevo.LI_cfAcum_ini - nLiquidacion.LI_cfAcum_ini
                            objNuevo.LI_cfAcum_ns = objNuevo.LI_cfAcum_ns - nLiquidacion.LI_cfAcum_ns
                            objNuevo.LI_afAcum_adic = objNuevo.LI_afAcum_adic - nLiquidacion.LI_afAcum_adic

                            objNuevo.LR_costov_ini = objNuevo.LR_costov_ini - nLiquidacion.LR_costov_ini
                            objNuevo.LR_costov_ns = objNuevo.LR_costov_ns - nLiquidacion.LR_costov_ns
                            objNuevo.LR_costov_adic = objNuevo.LR_costov_adic - nLiquidacion.LR_costov_adic

                            '3ER REPORTE-------------------------------------------------------
                            objNuevo.LOO_ReDeAp_ini = objNuevo.LOO_ReDeAp_ini - nLiquidacion.LOO_ReDeAp_ini
                            objNuevo.LOO_ReDeAp_ns = objNuevo.LOO_ReDeAp_ns - nLiquidacion.LOO_ReDeAp_ns
                            objNuevo.LOO_ReDeAp_adic = objNuevo.LOO_ReDeAp_adic - nLiquidacion.LOO_ReDeAp_adic

                            'analisis FINANCIERO
                            objNuevo.AF_TotalPagoProvSust_ini = objNuevo.AF_TotalPagoProvSust_ini - nLiquidacion.AF_TotalPagoProvSust_ini
                            objNuevo.AF_TotalPagoProvSust_ns = objNuevo.AF_TotalPagoProvSust_ns - nLiquidacion.AF_TotalPagoProvSust_ns
                            objNuevo.AF_TotalPagoProvSust_adic = objNuevo.AF_TotalPagoProvSust_adic - nLiquidacion.AF_TotalPagoProvSust_adic
                            'no sustentados
                            objNuevo.AF_RefGastoNoSust_ini = objNuevo.AF_RefGastoNoSust_ini - nLiquidacion.AF_RefGastoNoSust_ini
                            objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns - nLiquidacion.AF_RefGastoNoSust_ns
                            objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic - nLiquidacion.AF_RefGastoNoSust_adic
                            'LIQUIDACION PLANEAMIENTO
                            objNuevo.LP_TotalPagoProvCSSust_ini = objNuevo.LP_TotalPagoProvCSSust_ini - nLiquidacion.LP_TotalPagoProvCSSust_ini
                            objNuevo.LP_TotalPagoProvCSSust_ns = objNuevo.LP_TotalPagoProvCSSust_ns - nLiquidacion.LP_TotalPagoProvCSSust_ns
                            objNuevo.LP_TotalPagoProvCSSust_adic = objNuevo.LP_TotalPagoProvCSSust_adic - nLiquidacion.LP_TotalPagoProvCSSust_adic
                        Case "INCIDENCIA1"
                            objNuevo.LI_cfAcum_ns = objNuevo.LI_cfAcum_ns - nLiquidacion.LI_cfAcum_ns
                            objNuevo.LI_afAcum_adic = objNuevo.LI_afAcum_adic - nLiquidacion.LI_afAcum_adic

                            objNuevo.LR_inc_ns = objNuevo.LR_inc_ns - nLiquidacion.LR_inc_ns
                            objNuevo.LR_inc_adic = objNuevo.LR_inc_adic - nLiquidacion.LR_inc_adic

                            '3ER REPORTE-------------------------------------------------------
                            objNuevo.LOO_ReDeAp_ns = objNuevo.LOO_ReDeAp_ns - nLiquidacion.LOO_ReDeAp_ns
                            objNuevo.LOO_ReDeAp_adic = objNuevo.LOO_ReDeAp_adic - nLiquidacion.LOO_ReDeAp_adic


                            'analisis FINANCIERO
                            objNuevo.AF_TotalPagoProvSust_ns = objNuevo.AF_TotalPagoProvSust_ns - nLiquidacion.AF_TotalPagoProvSust_ns
                            objNuevo.AF_TotalPagoProvSust_adic = objNuevo.AF_TotalPagoProvSust_adic - nLiquidacion.AF_TotalPagoProvSust_adic
                            'no sustentados
                            objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns + nLiquidacion.AF_RefGastoNoSust_ns
                            objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic + nLiquidacion.AF_RefGastoNoSust_adic
                            'EGRESOS NO SUSTENTADOS
                            objNuevo.LP_EgresoNoSustentado_ns = objNuevo.LP_EgresoNoSustentado_ns - nLiquidacion.LP_EgresoNoSustentado_ns
                            objNuevo.LP_EgresoNoSustentado_adic = objNuevo.LP_EgresoNoSustentado_adic - nLiquidacion.LP_EgresoNoSustentado_adic
                            objNuevo.LP_EgresoInciAdic_adic = objNuevo.LP_EgresoInciAdic_adic - nLiquidacion.LP_EgresoInciAdic_adic
                    End Select
                End With
                objDetalle.DeleteDefault(nLiquidacion.secuencia) ' idActividadRecurso
                'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                HeliosData.SaveChanges()
                TS.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateLiquidacion(ByVal objLiquidacionEO As totalesLiquidacion, ByVal intCodigoDetalle As Integer,
                                      ByVal strFlagIdent As String)
        Dim objNuevo As New totalesLiquidacion()
        Dim listIngreso As New List(Of String)()
        listIngreso.Add("INGRESOS")

        Dim listCadena As New List(Of String)()
        listCadena.Add("CADIN")
        '   listCadena.Add("INCIDENCIA DIRECTA")

        Using ts As New TransactionScope()
            Select Case strFlagIdent
                Case "INGRESOS"
                    'objNuevo = (From n In HeliosData.totalesLiquidacion _
                    '         Where n.idEmpresa = objLiquidacionEO.idEmpresa _
                    '         And n.idEstablecimiento = objLiquidacionEO.idEstablecimiento _
                    '         And n.idActividad = objLiquidacionEO.idActividad _
                    '         And n.tipoPlan = objLiquidacionEO.tipoPlan _
                    '         And listIngreso.Contains(n.tipoLiquidacion)).FirstOrDefault

                    objNuevo = HeliosData.totalesLiquidacion.Where(Function(o) o.idEmpresa = objLiquidacionEO.idEmpresa And _
                                                                    o.idEstablecimiento = objLiquidacionEO.idEstablecimiento And _
                                                                    o.idActividad = objLiquidacionEO.idActividad And _
                                                                    o.tipoPlan = objLiquidacionEO.tipoPlan And _
                                                                    listIngreso.Contains(o.tipoLiquidacion)).FirstOrDefault

                Case "CADIN"

                    'objNuevo = (From n In HeliosData.totalesLiquidacion _
                    '         Where n.idEmpresa = objLiquidacionEO.idEmpresa _
                    '         And n.idEstablecimiento = objLiquidacionEO.idEstablecimiento _
                    '         And n.idActividad = objLiquidacionEO.idActividad _
                    '         And n.tipoPlan = objLiquidacionEO.tipoPlan _
                    '         And listCadena.Contains(n.tipoLiquidacion)).FirstOrDefault

                    objNuevo = HeliosData.totalesLiquidacion.Where(Function(o) o.idEmpresa = objLiquidacionEO.idEmpresa And _
                                                                   o.idEstablecimiento = objLiquidacionEO.idEstablecimiento And _
                                                                   o.idActividad = objLiquidacionEO.idActividad And _
                                                                   o.tipoPlan = objLiquidacionEO.tipoPlan And _
                                                                   listCadena.Contains(o.tipoLiquidacion)).FirstOrDefault
            End Select

            'objNuevo = (From n In objContext.totalesLiquidacion _
            '                 Where n.idEmpresa = objLiquidacionEO.idEmpresa _
            '                 And n.idEstablecimiento = objLiquidacionEO.idEstablecimiento _
            '                 And n.idProyecto = objLiquidacionEO.idProyecto _
            '                 And n.idEstrategia = objLiquidacionEO.idEstrategia _
            '                 And n.idProceso = objLiquidacionEO.idProceso _
            '                 And n.idTarea = objLiquidacionEO.idTarea).FirstOrDefault

            With objNuevo

                Select Case objLiquidacionEO.modulo

                    Case IngresoLiquidacion.NUEVO

                        Select Case objLiquidacionEO.tipoLiquidacion
                            Case "INGRESOS"
                                objNuevo.LI_ib_ini = objNuevo.LI_ib_ini + objLiquidacionEO.LI_ib_ini
                                objNuevo.LI_ib_ns = objNuevo.LI_ib_ns + objLiquidacionEO.LI_ib_ns
                                objNuevo.LI_ib_adic = objNuevo.LI_ib_adic + objLiquidacionEO.LI_ib_adic

                                objNuevo.LR_ventan_ini = objNuevo.LR_ventan_ini + objLiquidacionEO.LR_ventan_ini
                                objNuevo.LR_ventan_ns = objNuevo.LR_ventan_ns + objLiquidacionEO.LR_ventan_ns
                                objNuevo.LR_ventan_adic = objNuevo.LR_ventan_adic + objLiquidacionEO.LR_ventan_adic

                                objNuevo.detraccion_ini = objNuevo.detraccion_ini + objLiquidacionEO.detraccion_ini
                                objNuevo.detraccion_ns = objNuevo.detraccion_ns + objLiquidacionEO.detraccion_ns
                                objNuevo.detraccion_adic = objNuevo.detraccion_adic + objLiquidacionEO.detraccion_adic


                                'otros resportes
                                '--------------------------------------------------------
                                objNuevo.AF_EjecucionIng_ini = objNuevo.AF_EjecucionIng_ini + objLiquidacionEO.AF_EjecucionIng_ini
                                objNuevo.AF_EjecucionIng_ns = objNuevo.AF_EjecucionIng_ns + objLiquidacionEO.AF_EjecucionIng_ns
                                objNuevo.AF_EjecucionIng_adic = objNuevo.AF_EjecucionIng_adic + objLiquidacionEO.AF_EjecucionIng_adic

                                objNuevo.AF_Percepcion_ini = objNuevo.AF_Percepcion_ini + objLiquidacionEO.AF_Percepcion_ini
                                objNuevo.AF_Percepcion_ns = objNuevo.AF_Percepcion_ns + objLiquidacionEO.AF_Percepcion_ns
                                objNuevo.AF_Percepcion_adic = objNuevo.AF_Percepcion_adic + objLiquidacionEO.AF_Percepcion_adic

                                objNuevo.AF_Otrosps_ini = objNuevo.AF_Otrosps_ini + objLiquidacionEO.AF_Otrosps_ini
                                objNuevo.AF_Otrosps_ns = objNuevo.AF_Otrosps_ns + objLiquidacionEO.AF_Otrosps_ns
                                objNuevo.AF_Otrosps_adic = objNuevo.AF_Otrosps_adic + objLiquidacionEO.AF_Otrosps_adic

                                objNuevo.AF_Detraccion_ini = objNuevo.AF_Detraccion_ini + objLiquidacionEO.AF_Detraccion_ini
                                objNuevo.AF_Detraccion_ns = objNuevo.AF_Detraccion_ns + objLiquidacionEO.AF_Detraccion_ns
                                objNuevo.AF_Detraccion_adic = objNuevo.AF_Detraccion_adic + objLiquidacionEO.AF_Detraccion_adic

                                objNuevo.AF_Retencion_ini = objNuevo.AF_Retencion_ini + objLiquidacionEO.AF_Retencion_ini
                                objNuevo.AF_Retencion_ns = objNuevo.AF_Retencion_ns + objLiquidacionEO.AF_Retencion_ns
                                objNuevo.AF_Retencion_adic = objNuevo.AF_Retencion_adic + objLiquidacionEO.AF_Retencion_adic

                                objNuevo.AF_Otrosng_ini = objNuevo.AF_Otrosng_ini + objLiquidacionEO.AF_Otrosng_ini
                                objNuevo.AF_Otrosng_ns = objNuevo.AF_Otrosng_ns + objLiquidacionEO.AF_Otrosng_ns
                                objNuevo.AF_Otrosng_adic = objNuevo.AF_Otrosng_adic + objLiquidacionEO.AF_Otrosng_adic

                                objNuevo.totalIngresos = objNuevo.totalIngresos + objLiquidacionEO.totalIngresos
                            Case "INCIDENCIA DIRECTA"

                                objNuevo.LI_cfAcum_ini = objNuevo.LI_cfAcum_ini + objLiquidacionEO.LI_cfAcum_ini
                                objNuevo.LI_cfAcum_ns = objNuevo.LI_cfAcum_ns + objLiquidacionEO.LI_cfAcum_ns
                                objNuevo.LI_afAcum_adic = objNuevo.LI_afAcum_adic + objLiquidacionEO.LI_afAcum_adic

                                objNuevo.LR_costov_ini = objNuevo.LR_costov_ini + objLiquidacionEO.LR_costov_ini
                                objNuevo.LR_costov_ns = objNuevo.LR_costov_ns + objLiquidacionEO.LR_costov_ns
                                objNuevo.LR_costov_adic = objNuevo.LR_costov_adic + objLiquidacionEO.LR_costov_adic

                                '3ER REPORTE
                                objNuevo.LOO_ReDeAp_ini = objNuevo.LOO_ReDeAp_ini + objLiquidacionEO.LOO_ReDeAp_ini
                                objNuevo.LOO_ReDeAp_ns = objNuevo.LOO_ReDeAp_ns + objLiquidacionEO.LOO_ReDeAp_ns
                                objNuevo.LOO_ReDeAp_adic = objNuevo.LOO_ReDeAp_adic + objLiquidacionEO.LOO_ReDeAp_adic

                                'ANALISIS FINANCIERO
                                objNuevo.AF_TotalPagoProvSust_ini = objNuevo.AF_TotalPagoProvSust_ini + objLiquidacionEO.AF_TotalPagoProvSust_ini
                                objNuevo.AF_TotalPagoProvSust_ns = objNuevo.AF_TotalPagoProvSust_ns + objLiquidacionEO.AF_TotalPagoProvSust_ns
                                objNuevo.AF_TotalPagoProvSust_adic = objNuevo.AF_TotalPagoProvSust_adic + objLiquidacionEO.AF_TotalPagoProvSust_adic
                                'NOS SUSTENTADOS
                                objNuevo.AF_RefGastoNoSust_ini = objNuevo.AF_RefGastoNoSust_ini + objLiquidacionEO.AF_RefGastoNoSust_ini
                                objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns + objLiquidacionEO.AF_RefGastoNoSust_ns
                                '    objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic + objLiquidacionEO.AF_RefGastoNoSust_adic

                                objNuevo.LP_TotalPagoProvCSSust_ini = objNuevo.LP_TotalPagoProvCSSust_ini + objLiquidacionEO.LP_TotalPagoProvCSSust_ini
                                objNuevo.LP_TotalPagoProvCSSust_ns = objNuevo.LP_TotalPagoProvCSSust_ns + objLiquidacionEO.LP_TotalPagoProvCSSust_ns
                                objNuevo.LP_TotalPagoProvCSSust_adic = objNuevo.LP_TotalPagoProvCSSust_adic + objLiquidacionEO.LP_TotalPagoProvCSSust_adic
                            Case "INCIDENCIA1"


                                objNuevo.LI_cfAcum_ns = objNuevo.LI_cfAcum_ns + objLiquidacionEO.LI_cfAcum_ns
                                objNuevo.LI_afAcum_adic = objNuevo.LI_afAcum_adic + objLiquidacionEO.LI_afAcum_adic

                                objNuevo.LR_inc_ns = objNuevo.LR_inc_ns + objLiquidacionEO.LR_inc_ns
                                objNuevo.LR_inc_adic = objNuevo.LR_inc_adic + objLiquidacionEO.LR_inc_adic

                                '3ER REPORTE
                                objNuevo.LOO_ReDeAp_ns = objNuevo.LOO_ReDeAp_ns + objLiquidacionEO.LOO_ReDeAp_ns
                                objNuevo.LOO_ReDeAp_adic = objNuevo.LOO_ReDeAp_adic + objLiquidacionEO.LOO_ReDeAp_adic

                                'ANALISIS FINANCIERO
                                objNuevo.AF_TotalPagoProvSust_ns = objNuevo.AF_TotalPagoProvSust_ns + objLiquidacionEO.AF_TotalPagoProvSust_ns
                                objNuevo.AF_TotalPagoProvSust_adic = objNuevo.AF_TotalPagoProvSust_adic + objLiquidacionEO.AF_TotalPagoProvSust_adic

                                'NOS SUSTENTADOS
                                objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns - objLiquidacionEO.AF_RefGastoNoSust_ns
                                '   objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic - objLiquidacionEO.AF_RefGastoNoSust_adic
                                'EGRESOS
                                objNuevo.LP_EgresoNoSustentado_ns = objNuevo.LP_EgresoNoSustentado_ns + objLiquidacionEO.LP_EgresoNoSustentado_ns
                                objNuevo.LP_EgresoNoSustentado_adic = objNuevo.LP_EgresoNoSustentado_adic + objLiquidacionEO.LP_EgresoNoSustentado_adic
                                objNuevo.LP_EgresoInciAdic_adic = objNuevo.LP_EgresoInciAdic_adic + objLiquidacionEO.LP_EgresoInciAdic_adic
                        End Select



                    Case IngresoLiquidacion.EDITAR
                        Dim cVarianzaCan As Decimal = 0
                        Dim cVarianza2 As Decimal = 0
                        Dim cVarianza3 As Decimal = 0

                        Dim VarianzaAc_ini As Decimal = 0
                        Dim VarianzaAc_ns As Decimal = 0
                        Dim VarianzaAc_inc As Decimal = 0

                        Dim VarVenta_ini As Decimal = 0
                        Dim VarVenta_ns As Decimal = 0
                        Dim VarVenta_adic As Decimal = 0

                        Dim VarCosto_ini As Decimal = 0
                        Dim VarCosto_ns As Decimal = 0
                        Dim VarCosto_adic As Decimal = 0


                        Dim VarINC_ns As Decimal = 0
                        Dim VarINC_adic As Decimal = 0

                        Dim VarReDeAp_ini As Decimal = 0
                        Dim VarReDeAp_ns As Decimal = 0
                        Dim VarReDeAp_adic As Decimal = 0

                        Dim varDetraccion_ini As Decimal = 0
                        Dim varDetraccion_ns As Decimal = 0
                        Dim varDetraccion_adic As Decimal = 0

                        '----------------------------------------
                        '----------------------------------------
                        Dim VarAF_EjecucionIng_ini As Decimal = 0
                        Dim VarAF_EjecucionIng_ns As Decimal = 0
                        Dim VarAF_EjecucionIng_adic As Decimal = 0

                        Dim VarAF_Percepcion_ini As Decimal = 0
                        Dim VarAF_Percepcion_ns As Decimal = 0
                        Dim VarAF_Percepcion_adic As Decimal = 0

                        Dim VarAF_Otrosps_ini As Decimal = 0
                        Dim VarAF_Otrosps_ns As Decimal = 0
                        Dim VarAF_Otrosps_adic As Decimal = 0

                        Dim VarAF_Detraccion_ini As Decimal = 0
                        Dim VarAF_Detraccion_ns As Decimal = 0
                        Dim VarAF_Detraccion_adic As Decimal = 0

                        Dim VarAF_Retencion_ini As Decimal = 0
                        Dim VarAF_Retencion_ns As Decimal = 0
                        Dim VarAF_Retencion_adic As Decimal = 0

                        Dim VarAF_Otrosng_ini As Decimal = 0
                        Dim VarAF_Otrosng_ns As Decimal = 0
                        Dim VarAF_Otrosng_adic As Decimal = 0

                        Dim VarAF_TotalPagoProvSust_ini As Decimal = 0
                        Dim VarAF_TotalPagoProvSust_ns As Decimal = 0
                        Dim VarAF_TotalPagoProvSust_adic As Decimal = 0

                        Dim VarAF_TotalPagoProvCSSust_ini As Decimal = 0
                        Dim VarAF_TotalPagoProvCSSust_ns As Decimal = 0
                        Dim VarAF_TotalPagoProvCSSust_adic As Decimal = 0

                        Dim VarAF_RefGastoNoSust_ini As Decimal = 0
                        Dim VarAF_RefGastoNoSust_ns As Decimal = 0
                        Dim VarAF_RefGastoNoSust_adic As Decimal = 0

                        Dim VarLP_EgresoNoSustentado_ns As Decimal = 0
                        Dim VarLP_EgresoNoSustentado_adic As Decimal = 0
                        Dim VarLP_EgresoInciAdic_adic As Decimal = 0


                        Dim objBackDoc = (From k In HeliosData.actividadRecurso _
                                         Where k.idActividadRecurso = intCodigoDetalle).First

                        Select Case objLiquidacionEO.tipoLiquidacion
                            Case "INGRESOS"
                                '------------------------------------------------------------------------------
                                'CASE 1 FORMULA (+) >=
                                If objBackDoc.Igv <= objLiquidacionEO.LI_ib_ini Then
                                    cVarianzaCan = objLiquidacionEO.LI_ib_ini - objBackDoc.Igv
                                    objNuevo.LI_ib_ini = cVarianzaCan + objNuevo.LI_ib_ini

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.Igv > objLiquidacionEO.LI_ib_ini Then
                                    cVarianzaCan = objBackDoc.Igv - objLiquidacionEO.LI_ib_ini
                                    objNuevo.LI_ib_ini = objNuevo.LI_ib_ini - cVarianzaCan
                                End If
                                '------------------------------------------------------------------------------

                                '------------------------------------------------------------------------------
                                'CASE 1 FORMULA (+) >=
                                If objBackDoc.Igv <= objLiquidacionEO.LI_ib_ns Then
                                    cVarianza2 = objLiquidacionEO.LI_ib_ns - objBackDoc.Igv
                                    objNuevo.LI_ib_ns = cVarianza2 + objNuevo.LI_ib_ns

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.Igv > objLiquidacionEO.LI_ib_ns Then
                                    cVarianza2 = objBackDoc.Igv - objLiquidacionEO.LI_ib_ns
                                    objNuevo.LI_ib_ns = objNuevo.LI_ib_ns - cVarianza2
                                End If
                                '------------------------------------------------------------------------------

                                '------------------------------------------------------------------------------
                                'CASE 1 FORMULA (+) >=
                                If objBackDoc.Igv <= objLiquidacionEO.LI_ib_adic Then
                                    cVarianza3 = objLiquidacionEO.LI_ib_adic - objBackDoc.Igv
                                    objNuevo.LI_ib_adic = cVarianza3 + objNuevo.LI_ib_adic

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.Igv > objLiquidacionEO.LI_ib_adic Then
                                    cVarianza3 = objBackDoc.Igv - objLiquidacionEO.LI_ib_adic
                                    objNuevo.LI_ib_adic = objNuevo.LI_ib_adic - cVarianza3
                                End If
                                '------------------------------------------------------------------------------


                                'segundo reporte: LIQUIDACION DE IMPUESTO A LA RENTA

                                VarVenta_ini = (objBackDoc.ValorVenta - objLiquidacionEO.LR_ventan_ini) * -1
                                objNuevo.LR_ventan_ini = (VarVenta_ini + objNuevo.LR_ventan_ini)

                                VarVenta_ns = (objBackDoc.ValorVenta - objLiquidacionEO.LR_ventan_ns) * -1
                                objNuevo.LR_ventan_ns = (VarVenta_ns + objNuevo.LR_ventan_ns)

                                VarVenta_adic = (objBackDoc.ValorVenta - objLiquidacionEO.LR_ventan_adic) * -1
                                objNuevo.LR_ventan_adic = (VarVenta_adic + objNuevo.LR_ventan_adic)

                                '------------------------------------------------------------------------------

                                'otros reportes
                                varDetraccion_ini = (objBackDoc.Detracciones - objLiquidacionEO.detraccion_ini) * -1
                                objNuevo.detraccion_ini = (varDetraccion_ini + objNuevo.detraccion_ini)

                                varDetraccion_ns = (objBackDoc.Detracciones - objLiquidacionEO.detraccion_ns) * -1
                                objNuevo.detraccion_ns = (varDetraccion_ns + objNuevo.detraccion_ns)

                                varDetraccion_adic = (objBackDoc.Detracciones - objLiquidacionEO.detraccion_adic) * -1
                                objNuevo.detraccion_adic = (varDetraccion_adic + objNuevo.detraccion_adic)
                                '------------------------------------------------------------------------------------------------------
                                '-----------------------------------------------------------------------------------------------------

                                'INGRESOS
                                '**********************************************************************************************************
                                VarAF_EjecucionIng_ini = (objBackDoc.TotalProyecto - objLiquidacionEO.AF_EjecucionIng_ini) * -1
                                objNuevo.AF_EjecucionIng_ini = (VarAF_EjecucionIng_ini + objNuevo.AF_EjecucionIng_ini)

                                VarAF_EjecucionIng_ns = (objBackDoc.TotalProyecto - objLiquidacionEO.AF_EjecucionIng_ns) * -1
                                objNuevo.AF_EjecucionIng_ns = (VarAF_EjecucionIng_ns + objNuevo.AF_EjecucionIng_ns)

                                VarAF_EjecucionIng_adic = (objBackDoc.TotalProyecto - objLiquidacionEO.AF_EjecucionIng_adic) * -1
                                objNuevo.AF_EjecucionIng_adic = (VarAF_EjecucionIng_adic + objNuevo.AF_EjecucionIng_adic)
                                '-----------------------------------------------------------------------------------------------------------

                                VarAF_Percepcion_ini = (objBackDoc.Percepciones - objLiquidacionEO.AF_Percepcion_ini) * -1
                                objNuevo.AF_Percepcion_ini = (VarAF_Percepcion_ini + objNuevo.AF_Percepcion_ini)

                                VarAF_Percepcion_ns = (objBackDoc.Percepciones - objLiquidacionEO.AF_Percepcion_ns) * -1
                                objNuevo.AF_Percepcion_ns = (VarAF_Percepcion_ns + objNuevo.AF_Percepcion_ns)

                                VarAF_Percepcion_adic = (objBackDoc.Percepciones - objLiquidacionEO.AF_Percepcion_adic) * -1
                                objNuevo.AF_Percepcion_adic = (VarAF_Percepcion_adic + objNuevo.AF_Percepcion_adic)
                                '------------------------------------------------------------------------------------------------------------

                                VarAF_Otrosps_ini = (objBackDoc.OtrosIn2 - objLiquidacionEO.AF_Otrosps_ini) * -1
                                objNuevo.AF_Otrosps_ini = (VarAF_Otrosps_ini + objNuevo.AF_Otrosps_ini)

                                VarAF_Otrosps_ns = (objBackDoc.OtrosIn2 - objLiquidacionEO.AF_Otrosps_ns) * -1
                                objNuevo.AF_Otrosps_ns = (VarAF_Otrosps_ns + objNuevo.AF_Otrosps_ns)

                                VarAF_Otrosps_adic = (objBackDoc.OtrosIn2 - objLiquidacionEO.AF_Otrosps_adic) * -1
                                objNuevo.AF_Otrosps_adic = (VarAF_Otrosps_adic + objNuevo.AF_Otrosps_adic)
                                '-------------------------------------------------------------------------------------------------------------

                                VarAF_Detraccion_ini = (objBackDoc.Detracciones - objLiquidacionEO.AF_Detraccion_ini) * -1
                                objNuevo.AF_Detraccion_ini = (VarAF_Detraccion_ini + objNuevo.AF_Detraccion_ini)

                                VarAF_Detraccion_ns = (objBackDoc.Detracciones - objLiquidacionEO.AF_Detraccion_ns) * -1
                                objNuevo.AF_Detraccion_ns = (VarAF_Detraccion_ns + objNuevo.AF_Detraccion_ns)

                                VarAF_Detraccion_adic = (objBackDoc.Detracciones - objLiquidacionEO.AF_Detraccion_adic) * -1
                                objNuevo.AF_Detraccion_adic = (VarAF_Detraccion_adic + objNuevo.AF_Detraccion_adic)
                                '--------------------------------------------------------------------------------------------------------------

                                VarAF_Retencion_ini = (objBackDoc.Retenciones - objLiquidacionEO.AF_Retencion_ini) * -1
                                objNuevo.AF_Retencion_ini = (VarAF_Retencion_ini + objNuevo.AF_Retencion_ini)

                                VarAF_Retencion_ns = (objBackDoc.Retenciones - objLiquidacionEO.AF_Retencion_ns) * -1
                                objNuevo.AF_Retencion_ns = (VarAF_Retencion_ns + objNuevo.AF_Retencion_ns)

                                VarAF_Retencion_adic = (objBackDoc.Retenciones - objLiquidacionEO.AF_Retencion_adic) * -1
                                objNuevo.AF_Retencion_adic = (VarAF_Retencion_adic + objNuevo.AF_Retencion_adic)
                                '---------------------------------------------------------------------------------------------------------------

                                VarAF_Otrosng_ini = (objBackDoc.OtroIn3 - objLiquidacionEO.AF_Otrosng_ini) * -1
                                objNuevo.AF_Otrosng_ini = (VarAF_Otrosng_ini + objNuevo.AF_Otrosng_ini)

                                VarAF_Otrosng_ns = (objBackDoc.OtroIn3 - objLiquidacionEO.AF_Otrosng_ns) * -1
                                objNuevo.AF_Otrosng_ns = (VarAF_Otrosng_ns + objNuevo.AF_Otrosng_ns)

                                VarAF_Otrosng_adic = (objBackDoc.OtroIn3 - objLiquidacionEO.AF_Otrosng_adic) * -1
                                objNuevo.AF_Otrosng_adic = (VarAF_Otrosng_adic + objNuevo.AF_Otrosng_adic)
                                '----------------------------------------------------------------------------------------------------------------

                                'VarAF_TotalPagoProvSust_ini = (objBackDoc.OtroIn3 - objLiquidacionEO.AF_TotalPagoProvSust_ini) * -1
                                'objNuevo.AF_TotalPagoProvSust_ini = (VarAF_TotalPagoProvSust_ini + objNuevo.AF_TotalPagoProvSust_ini)

                            Case "INCIDENCIA DIRECTA"
                                '------------------------------------------------------------------------------
                                'CASE 1 FORMULA (+) >=
                                If objBackDoc.Igv <= objLiquidacionEO.LI_cfAcum_ini Then
                                    VarianzaAc_ini = objLiquidacionEO.LI_cfAcum_ini - objBackDoc.Igv
                                    objNuevo.LI_cfAcum_ini = VarianzaAc_ini + objNuevo.LI_cfAcum_ini

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.Igv > objLiquidacionEO.LI_cfAcum_ini Then
                                    VarianzaAc_ini = objBackDoc.Igv - objLiquidacionEO.LI_cfAcum_ini
                                    objNuevo.LI_cfAcum_ini = objNuevo.LI_cfAcum_ini - VarianzaAc_ini
                                End If
                                '------------------------------------------------------------------------------
                                If objBackDoc.Igv <= objLiquidacionEO.LI_cfAcum_ns Then
                                    VarianzaAc_ns = objLiquidacionEO.LI_cfAcum_ns - objBackDoc.Igv
                                    objNuevo.LI_cfAcum_ns = VarianzaAc_ns + objNuevo.LI_cfAcum_ns

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.Igv > objLiquidacionEO.LI_cfAcum_ns Then
                                    VarianzaAc_ns = objBackDoc.Igv - objLiquidacionEO.LI_cfAcum_ns
                                    objNuevo.LI_cfAcum_ns = objNuevo.LI_cfAcum_ns - VarianzaAc_ns
                                End If
                                '------------------------------------------------------------------------------
                                If objBackDoc.Igv <= objLiquidacionEO.LI_afAcum_adic Then
                                    VarianzaAc_inc = objLiquidacionEO.LI_afAcum_adic - objBackDoc.Igv
                                    objNuevo.LI_afAcum_adic = VarianzaAc_inc + objNuevo.LI_afAcum_adic

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.Igv > objLiquidacionEO.LI_afAcum_adic Then
                                    VarianzaAc_inc = objBackDoc.Igv - objLiquidacionEO.LI_afAcum_adic
                                    objNuevo.LI_afAcum_adic = objNuevo.LI_afAcum_adic - VarianzaAc_inc
                                End If
                                '------------------------------------------------------------------------------


                                'SEGUNDO REPORTE
                                Dim suma1 As Decimal = 0
                                suma1 = objBackDoc.Costo + objBackDoc.Otros1 + objBackDoc.AporPlanilla
                                '------------------------------------------------------------------------------
                                If suma1 <= objLiquidacionEO.LR_costov_ini Then
                                    VarCosto_ini = objLiquidacionEO.LR_costov_ini - suma1
                                    objNuevo.LR_costov_ini = VarCosto_ini + objNuevo.LR_costov_ini

                                    'CASE 2 FORMULA (-)<
                                ElseIf suma1 > objLiquidacionEO.LR_costov_ini Then
                                    VarCosto_ini = suma1 - objLiquidacionEO.LR_costov_ini
                                    objNuevo.LR_costov_ini = objNuevo.LR_costov_ini - VarCosto_ini
                                End If
                                '------------------------------------------------------------------------------

                                '------------------------------------------------------------------------------
                                If suma1 <= objLiquidacionEO.LR_costov_ns Then
                                    VarCosto_ns = objLiquidacionEO.LR_costov_ns - suma1
                                    objNuevo.LR_costov_ns = VarCosto_ns + objNuevo.LR_costov_ns

                                    'CASE 2 FORMULA (-)<
                                ElseIf suma1 > objLiquidacionEO.LR_costov_ns Then
                                    VarCosto_ns = suma1 - objLiquidacionEO.LR_costov_ns
                                    objNuevo.LR_costov_ns = objNuevo.LR_costov_ns - VarCosto_ns
                                End If
                                '------------------------------------------------------------------------------

                                '------------------------------------------------------------------------------
                                If suma1 <= objLiquidacionEO.LR_costov_adic Then
                                    VarCosto_adic = objLiquidacionEO.LR_costov_adic - suma1
                                    objNuevo.LR_costov_adic = VarCosto_adic + objNuevo.LR_costov_adic

                                    'CASE 2 FORMULA (-)<
                                ElseIf suma1 > objLiquidacionEO.LR_costov_adic Then
                                    VarCosto_adic = suma1 - objLiquidacionEO.LR_costov_adic
                                    objNuevo.LR_costov_adic = objNuevo.LR_costov_adic - VarCosto_adic
                                End If
                                '------------------------------------------------------------------------------


                                '3ER REPORTE ----------------------------------------------------------------
                                '************************************

                                If objBackDoc.TotalRetenciones <= objLiquidacionEO.LOO_ReDeAp_ini Then
                                    VarReDeAp_ini = objLiquidacionEO.LOO_ReDeAp_ini - objBackDoc.TotalRetenciones
                                    objNuevo.LOO_ReDeAp_ini = VarReDeAp_ini + objNuevo.LOO_ReDeAp_ini

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.TotalRetenciones > objLiquidacionEO.LOO_ReDeAp_ini Then
                                    VarReDeAp_ini = objBackDoc.TotalRetenciones - objLiquidacionEO.LOO_ReDeAp_ini
                                    objNuevo.LOO_ReDeAp_ini = objNuevo.LOO_ReDeAp_ini - VarReDeAp_ini
                                End If
                                '------------------------------------------------------------------------------


                                If objBackDoc.TotalRetenciones <= objLiquidacionEO.LOO_ReDeAp_ns Then
                                    VarReDeAp_ns = objLiquidacionEO.LOO_ReDeAp_ns - objBackDoc.TotalRetenciones
                                    objNuevo.LOO_ReDeAp_ns = VarReDeAp_ns + objNuevo.LOO_ReDeAp_ns

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.TotalRetenciones > objLiquidacionEO.LOO_ReDeAp_ns Then
                                    VarReDeAp_ns = objBackDoc.TotalRetenciones - objLiquidacionEO.LOO_ReDeAp_ns
                                    objNuevo.LOO_ReDeAp_ns = objNuevo.LOO_ReDeAp_ns - VarReDeAp_ns
                                End If
                                '------------------------------------------------------------------------------


                                If objBackDoc.TotalRetenciones <= objLiquidacionEO.LOO_ReDeAp_adic Then
                                    VarReDeAp_adic = objLiquidacionEO.LOO_ReDeAp_adic - objBackDoc.TotalRetenciones
                                    objNuevo.LOO_ReDeAp_adic = VarReDeAp_adic + objNuevo.LOO_ReDeAp_adic

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.TotalRetenciones > objLiquidacionEO.LOO_ReDeAp_adic Then
                                    VarReDeAp_adic = objBackDoc.TotalRetenciones - objLiquidacionEO.LOO_ReDeAp_adic
                                    objNuevo.LOO_ReDeAp_adic = objNuevo.LOO_ReDeAp_adic - VarReDeAp_adic
                                End If
                                '------------------------------------------------------------------------------

                                '---------------------------------------------------------------------------------------

                                'ANALISIS FINANCIERO
                                '
                                'TOTALES POR PAGAR A PROVEEDORES CON SUSTENTO
                                If objBackDoc.NetoPagar <= objLiquidacionEO.AF_TotalPagoProvSust_ini Then
                                    VarAF_TotalPagoProvSust_ini = objLiquidacionEO.AF_TotalPagoProvSust_ini - objBackDoc.NetoPagar
                                    objNuevo.AF_TotalPagoProvSust_ini = VarAF_TotalPagoProvSust_ini + objNuevo.AF_TotalPagoProvSust_ini

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.NetoPagar > objLiquidacionEO.AF_TotalPagoProvSust_ini Then
                                    VarAF_TotalPagoProvSust_ini = objBackDoc.NetoPagar - objLiquidacionEO.AF_TotalPagoProvSust_ini
                                    objNuevo.AF_TotalPagoProvSust_ini = objNuevo.AF_TotalPagoProvSust_ini - VarAF_TotalPagoProvSust_ini

                                    ' ElseIf objBackDoc.NetoPagar = objLiquidacionEO.AF_TotalPagoProvSust_ini Then
                                    'VarAF_TotalPagoProvSust_ini = objNuevo.AF_TotalPagoProvSust_ini - objBackDoc.NetoPagar
                                    'objNuevo.AF_TotalPagoProvSust_ini = VarAF_TotalPagoProvSust_ini
                                End If
                                '------------------------------------------------------------------------------

                                If objBackDoc.NetoPagar <= objLiquidacionEO.AF_TotalPagoProvSust_ns Then
                                    VarAF_TotalPagoProvSust_ns = objLiquidacionEO.AF_TotalPagoProvSust_ns - objBackDoc.NetoPagar
                                    objNuevo.AF_TotalPagoProvSust_ns = VarAF_TotalPagoProvSust_ns + objNuevo.AF_TotalPagoProvSust_ns

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.NetoPagar > objLiquidacionEO.AF_TotalPagoProvSust_ns Then
                                    VarAF_TotalPagoProvSust_ns = objBackDoc.NetoPagar - objLiquidacionEO.AF_TotalPagoProvSust_ns
                                    objNuevo.AF_TotalPagoProvSust_ns = objNuevo.AF_TotalPagoProvSust_ns - VarAF_TotalPagoProvSust_ns

                                    'ElseIf objBackDoc.NetoPagar = objLiquidacionEO.AF_TotalPagoProvSust_ns Then
                                    '    VarAF_TotalPagoProvSust_ns = objNuevo.AF_TotalPagoProvSust_ns - objBackDoc.NetoPagar
                                    '    objNuevo.AF_TotalPagoProvSust_ns = VarAF_TotalPagoProvSust_ns
                                End If
                                '------------------------------------------------------------------------------

                                If objBackDoc.NetoPagar <= objLiquidacionEO.AF_TotalPagoProvSust_adic Then
                                    VarAF_TotalPagoProvSust_adic = objLiquidacionEO.AF_TotalPagoProvSust_adic - objBackDoc.NetoPagar
                                    objNuevo.AF_TotalPagoProvSust_adic = VarAF_TotalPagoProvSust_adic + objNuevo.AF_TotalPagoProvSust_adic

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.NetoPagar > objLiquidacionEO.AF_TotalPagoProvSust_adic Then
                                    VarAF_TotalPagoProvSust_adic = objBackDoc.NetoPagar - objLiquidacionEO.AF_TotalPagoProvSust_adic
                                    objNuevo.AF_TotalPagoProvSust_adic = objNuevo.AF_TotalPagoProvSust_adic - VarAF_TotalPagoProvSust_adic

                                    'ElseIf objBackDoc.NetoPagar = objLiquidacionEO.AF_TotalPagoProvSust_adic Then

                                    '    VarAF_TotalPagoProvSust_adic = objNuevo.AF_TotalPagoProvSust_adic - objBackDoc.NetoPagar
                                    '    objNuevo.AF_TotalPagoProvSust_adic = VarAF_TotalPagoProvSust_adic
                                End If
                                '------------------------------------------------------------------------------


                                'NO SUSTENTADOS

                                If objBackDoc.NoSustentado <= objLiquidacionEO.AF_RefGastoNoSust_ini Then
                                    VarAF_RefGastoNoSust_ini = objLiquidacionEO.AF_RefGastoNoSust_ini - objBackDoc.NoSustentado
                                    objNuevo.AF_RefGastoNoSust_ini = VarAF_RefGastoNoSust_ini + objNuevo.AF_RefGastoNoSust_ini

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.NoSustentado > objLiquidacionEO.AF_RefGastoNoSust_ini Then
                                    VarAF_RefGastoNoSust_ini = objBackDoc.NoSustentado - objLiquidacionEO.AF_RefGastoNoSust_ini
                                    objNuevo.AF_RefGastoNoSust_ini = objNuevo.AF_RefGastoNoSust_ini - VarAF_RefGastoNoSust_ini
                                End If
                                '------------------------------------------------------------------------------


                                If objBackDoc.NoSustentado <= objLiquidacionEO.AF_RefGastoNoSust_ns Then
                                    VarAF_RefGastoNoSust_ns = objLiquidacionEO.AF_RefGastoNoSust_ns - objBackDoc.NoSustentado
                                    objNuevo.AF_RefGastoNoSust_ns = VarAF_RefGastoNoSust_ns + objNuevo.AF_RefGastoNoSust_ns

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.NoSustentado > objLiquidacionEO.AF_RefGastoNoSust_ns Then
                                    VarAF_RefGastoNoSust_ns = objBackDoc.NoSustentado - objLiquidacionEO.AF_RefGastoNoSust_ns
                                    objNuevo.AF_RefGastoNoSust_ns = objNuevo.AF_RefGastoNoSust_ns - VarAF_RefGastoNoSust_ns
                                End If
                                '------------------------------------------------------------------------------


                                If objBackDoc.NoSustentado <= objLiquidacionEO.AF_RefGastoNoSust_adic Then
                                    VarAF_RefGastoNoSust_adic = objLiquidacionEO.AF_RefGastoNoSust_adic - objBackDoc.NoSustentado
                                    objNuevo.AF_RefGastoNoSust_adic = VarAF_RefGastoNoSust_adic + objNuevo.AF_RefGastoNoSust_adic

                                    'CASE 2 FORMULA (-)<
                                ElseIf objBackDoc.NoSustentado > objLiquidacionEO.AF_RefGastoNoSust_adic Then
                                    VarAF_RefGastoNoSust_adic = objBackDoc.NoSustentado - objLiquidacionEO.AF_RefGastoNoSust_adic
                                    objNuevo.AF_RefGastoNoSust_adic = objNuevo.AF_RefGastoNoSust_adic - VarAF_RefGastoNoSust_adic
                                End If
                                '------------------------------------------------------------------------------


                                'liquidacion planeamiento

                                objNuevo.LP_TotalPagoProvCSSust_ini = objNuevo.AF_TotalPagoProvSust_ini + objNuevo.AF_RefGastoNoSust_ini
                                objNuevo.LP_TotalPagoProvCSSust_ns = objNuevo.AF_TotalPagoProvSust_ns + objNuevo.AF_RefGastoNoSust_ns
                                objNuevo.LP_TotalPagoProvCSSust_adic = objNuevo.AF_TotalPagoProvSust_adic + objNuevo.AF_RefGastoNoSust_adic

                                'VarAF_TotalPagoProvCSSust_ini = (objBackDoc.NetoPagar - objLiquidacionEO.LP_TotalPagoProvCSSust_ini) * -1
                                'objNuevo.LP_TotalPagoProvCSSust_ini = (VarAF_TotalPagoProvCSSust_ini + objNuevo.LP_TotalPagoProvCSSust_ini)

                                'VarAF_TotalPagoProvCSSust_ns = (objBackDoc.NetoPagar - objLiquidacionEO.LP_TotalPagoProvCSSust_ns) * -1
                                'objNuevo.LP_TotalPagoProvCSSust_ns = (VarAF_TotalPagoProvCSSust_ns + objNuevo.LP_TotalPagoProvCSSust_ns)

                                'VarAF_TotalPagoProvCSSust_adic = (objBackDoc.NetoPagar - objLiquidacionEO.LP_TotalPagoProvCSSust_adic) * -1
                                'objNuevo.LP_TotalPagoProvCSSust_adic = (VarAF_TotalPagoProvCSSust_adic + objNuevo.LP_TotalPagoProvCSSust_adic)

                            Case "INCIDENCIA1"

                                VarianzaAc_ns = (objBackDoc.Igv - objLiquidacionEO.LI_cfAcum_ns) * -1
                                objNuevo.LI_cfAcum_ns = (VarianzaAc_ns + objNuevo.LI_cfAcum_ns)

                                VarianzaAc_inc = (objBackDoc.Igv - objLiquidacionEO.LI_afAcum_adic) * -1
                                objNuevo.LI_afAcum_adic = (VarianzaAc_inc + objNuevo.LI_afAcum_adic)

                                'INCIDENCIAS

                                'segundo reporte
                                Dim suma1 As Decimal = 0
                                suma1 = objBackDoc.Costo + objBackDoc.Otros1 + objBackDoc.AporPlanilla

                                VarINC_ns = (suma1 - objLiquidacionEO.LR_inc_ns) * -1
                                objNuevo.LR_inc_ns = (VarINC_ns + objNuevo.LR_inc_ns)

                                VarINC_adic = (suma1 - objLiquidacionEO.LR_inc_adic) * -1
                                objNuevo.LR_inc_adic = (VarINC_adic + objNuevo.LR_inc_adic)


                                '3ER REPORTE ----------------------------------------------------------------
                                '************************************

                                VarReDeAp_ns = (objBackDoc.TotalRetenciones - objLiquidacionEO.LOO_ReDeAp_ns) * -1
                                objNuevo.LOO_ReDeAp_ns = (VarReDeAp_ns + objNuevo.LOO_ReDeAp_ns)

                                VarReDeAp_adic = (objBackDoc.TotalRetenciones - objLiquidacionEO.LOO_ReDeAp_adic) * -1
                                objNuevo.LOO_ReDeAp_adic = (VarReDeAp_adic + objNuevo.LOO_ReDeAp_adic)

                                'ANALISIS FINANCIERO
                                '
                                VarAF_TotalPagoProvSust_ns = (objBackDoc.NetoPagar - objLiquidacionEO.AF_TotalPagoProvSust_ns) * -1
                                objNuevo.AF_TotalPagoProvSust_ns = (VarAF_TotalPagoProvSust_ns + objNuevo.AF_TotalPagoProvSust_ns)

                                VarAF_TotalPagoProvSust_adic = (objBackDoc.NetoPagar - objLiquidacionEO.AF_TotalPagoProvSust_adic) * -1
                                objNuevo.AF_TotalPagoProvSust_adic = (VarAF_TotalPagoProvSust_adic + objNuevo.AF_TotalPagoProvSust_adic)

                                'NO SUSTENTADOS
                                VarAF_RefGastoNoSust_ns = (objBackDoc.Total - objLiquidacionEO.AF_RefGastoNoSust_ns) * -1
                                objNuevo.AF_RefGastoNoSust_ns = (VarAF_RefGastoNoSust_ns - objNuevo.AF_RefGastoNoSust_ns) * -1

                                VarAF_RefGastoNoSust_adic = (objBackDoc.Total - objLiquidacionEO.AF_RefGastoNoSust_adic) * -1
                                objNuevo.AF_RefGastoNoSust_adic = (VarAF_RefGastoNoSust_adic - objNuevo.AF_RefGastoNoSust_adic) * -1
                                '---------------------------------------------------------------------------------------------------
                                'EGRESOS
                                VarLP_EgresoNoSustentado_ns = (objBackDoc.TotalImpor - objLiquidacionEO.LP_EgresoNoSustentado_ns) * -1
                                objNuevo.LP_EgresoNoSustentado_ns = (VarLP_EgresoNoSustentado_ns + objNuevo.LP_EgresoNoSustentado_ns)

                                VarLP_EgresoNoSustentado_adic = (objBackDoc.TotalImpor - objLiquidacionEO.LP_EgresoNoSustentado_adic) * -1
                                objNuevo.LP_EgresoNoSustentado_adic = (VarLP_EgresoNoSustentado_adic + objNuevo.LP_EgresoNoSustentado_adic)

                                VarLP_EgresoInciAdic_adic = (objBackDoc.TotalImpor - objLiquidacionEO.LP_EgresoInciAdic_adic) * -1
                                objNuevo.LP_EgresoInciAdic_adic = (VarLP_EgresoInciAdic_adic + objNuevo.LP_EgresoInciAdic_adic)
                        End Select


                End Select


            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub

    Public Sub SaveLiquidacion(ByVal objLiquidacionEO As totalesLiquidacion, ByVal strFlagIdent As String)
        Dim objNuevo As New totalesLiquidacion()
        Using ts As New TransactionScope()
            With objNuevo
                .idEmpresa = objLiquidacionEO.idEmpresa
                .idEstablecimiento = objLiquidacionEO.idEstablecimiento
                .idActividad = objLiquidacionEO.idActividad
                .tipoLiquidacion = strFlagIdent ' objLiquidacionEO.tipoLiquidacion
                .modulo = objLiquidacionEO.modulo
                .Fecha = objLiquidacionEO.Fecha
                .tipoPlan = objLiquidacionEO.tipoPlan
                Select Case objLiquidacionEO.tipoLiquidacion

                    Case "INGRESOS"
                        .LI_ib_ini = objLiquidacionEO.LI_ib_ini
                        .LI_ib_ns = objLiquidacionEO.LI_ib_ns
                        .LI_ib_adic = objLiquidacionEO.LI_ib_adic

                        .LI_cfAcum_ini = 0
                        .LI_cfAcum_ns = 0
                        .LI_afAcum_adic = 0

                        .LR_ventan_ini = objLiquidacionEO.LR_ventan_ini
                        .LR_ventan_ns = objLiquidacionEO.LR_ventan_ns
                        .LR_ventan_adic = objLiquidacionEO.LR_ventan_adic

                        .LR_costov_ini = 0
                        .LR_costov_ns = 0
                        .LR_costov_adic = 0

                        .LR_inc_ns = 0
                        .LR_inc_adic = 0

                        .LOO_ReDeAp_ini = 0
                        .LOO_ReDeAp_ns = 0
                        .LOO_ReDeAp_adic = 0

                        .detraccion_ini = objLiquidacionEO.detraccion_ini
                        .detraccion_ns = objLiquidacionEO.detraccion_ns
                        .detraccion_adic = objLiquidacionEO.detraccion_adic

                        'otros resportes
                        '--------------------------------------------------------
                        .AF_EjecucionIng_ini = objLiquidacionEO.AF_EjecucionIng_ini
                        .AF_EjecucionIng_ns = objLiquidacionEO.AF_EjecucionIng_ns
                        .AF_EjecucionIng_adic = objLiquidacionEO.AF_EjecucionIng_adic

                        .AF_Percepcion_ini = objLiquidacionEO.AF_Percepcion_ini
                        .AF_Percepcion_ns = objLiquidacionEO.AF_Percepcion_ns
                        .AF_Percepcion_adic = objLiquidacionEO.AF_Percepcion_adic

                        .AF_Otrosps_ini = objLiquidacionEO.AF_Otrosps_ini
                        .AF_Otrosps_ns = objLiquidacionEO.AF_Otrosps_ns
                        .AF_Otrosps_adic = objLiquidacionEO.AF_Otrosps_adic

                        .AF_Detraccion_ini = objLiquidacionEO.AF_Detraccion_ini
                        .AF_Detraccion_ns = objLiquidacionEO.AF_Detraccion_ns
                        .AF_Detraccion_adic = objLiquidacionEO.AF_Detraccion_adic

                        .AF_Retencion_ini = objLiquidacionEO.AF_Retencion_ini
                        .AF_Retencion_ns = objLiquidacionEO.AF_Retencion_ns
                        .AF_Retencion_adic = objLiquidacionEO.AF_Retencion_adic

                        .AF_Otrosng_ini = objLiquidacionEO.AF_Otrosng_ini
                        .AF_Otrosng_ns = objLiquidacionEO.AF_Otrosng_ns
                        .AF_Otrosng_adic = objLiquidacionEO.AF_Otrosng_adic

                        .AF_TotalPagoProvSust_ini = 0
                        .AF_TotalPagoProvSust_ns = 0
                        .AF_TotalPagoProvSust_adic = 0

                        .AF_RefGastoNoSust_ini = 0
                        .AF_RefGastoNoSust_ns = 0
                        .AF_RefGastoNoSust_adic = 0

                        .LP_EgresoNoSustentado_ns = 0
                        .LP_EgresoNoSustentado_adic = 0
                        .LP_EgresoInciAdic_adic = 0

                        .totalIngresos = objLiquidacionEO.totalIngresos
                    Case "INCIDENCIA DIRECTA"

                        .LI_ib_ini = 0
                        .LI_ib_ns = 0
                        .LI_ib_adic = 0

                        .LI_cfAcum_ini = objLiquidacionEO.LI_cfAcum_ini
                        .LI_cfAcum_ns = objLiquidacionEO.LI_cfAcum_ns
                        .LI_afAcum_adic = objLiquidacionEO.LI_afAcum_adic

                        .LR_ventan_ini = 0
                        .LR_ventan_ns = 0
                        .LR_ventan_adic = 0

                        .LR_costov_ini = objLiquidacionEO.LR_costov_ini
                        .LR_costov_ns = objLiquidacionEO.LR_costov_ns
                        .LR_costov_adic = objLiquidacionEO.LR_costov_adic

                        .LR_inc_ns = 0
                        .LR_inc_adic = 0

                        '3ER REPORTE
                        .LOO_ReDeAp_ini = objLiquidacionEO.LOO_ReDeAp_ini
                        .LOO_ReDeAp_ns = objLiquidacionEO.LOO_ReDeAp_ns
                        .LOO_ReDeAp_adic = objLiquidacionEO.LOO_ReDeAp_adic

                        .detraccion_ini = 0
                        .detraccion_ns = 0
                        .detraccion_adic = 0

                        .AF_EjecucionIng_ini = 0
                        .AF_EjecucionIng_ns = 0
                        .AF_EjecucionIng_adic = 0

                        .AF_Percepcion_ini = 0
                        .AF_Percepcion_ns = 0
                        .AF_Percepcion_adic = 0

                        .AF_Otrosps_ini = 0
                        .AF_Otrosps_ns = 0
                        .AF_Otrosps_adic = 0

                        .AF_Detraccion_ini = 0
                        .AF_Detraccion_ns = 0
                        .AF_Detraccion_adic = 0

                        .AF_Retencion_ini = 0
                        .AF_Retencion_ns = 0
                        .AF_Retencion_adic = 0

                        .AF_Otrosng_ini = 0
                        .AF_Otrosng_ns = 0
                        .AF_Otrosng_adic = 0

                        'ANALISIS FINANCIERO
                        .AF_TotalPagoProvSust_ini = objLiquidacionEO.AF_TotalPagoProvSust_ini
                        .AF_TotalPagoProvSust_ns = objLiquidacionEO.AF_TotalPagoProvSust_ns
                        .AF_TotalPagoProvSust_adic = objLiquidacionEO.AF_TotalPagoProvSust_adic
                        'NOS SUSTENTADOS
                        .AF_RefGastoNoSust_ini = objLiquidacionEO.AF_RefGastoNoSust_ini
                        .AF_RefGastoNoSust_ns = objLiquidacionEO.AF_RefGastoNoSust_ns
                        '     .AF_RefGastoNoSust_adic = objLiquidacionEO.AF_RefGastoNoSust_adic

                        .LP_EgresoNoSustentado_ns = 0
                        .LP_EgresoNoSustentado_adic = 0
                        .LP_EgresoInciAdic_adic = 0


                        .LP_TotalPagoProvCSSust_ini = objLiquidacionEO.LP_TotalPagoProvCSSust_ini
                        .LP_TotalPagoProvCSSust_ns = objLiquidacionEO.LP_TotalPagoProvCSSust_ns
                        .LP_TotalPagoProvCSSust_adic = objLiquidacionEO.LP_TotalPagoProvCSSust_adic

                    Case "INCIDENCIA1"



                        .LI_ib_ini = 0
                        .LI_ib_ns = 0
                        .LI_ib_adic = 0

                        .LI_cfAcum_ini = 0
                        .LI_cfAcum_ns = objLiquidacionEO.LI_cfAcum_ns
                        .LI_afAcum_adic = objLiquidacionEO.LI_afAcum_adic

                        .LR_ventan_ini = 0
                        .LR_ventan_ns = 0
                        .LR_ventan_adic = 0

                        .LR_costov_ini = 0
                        .LR_costov_ns = 0
                        .LR_costov_adic = 0

                        .LR_inc_ns = objLiquidacionEO.LR_inc_ns
                        .LR_inc_adic = objLiquidacionEO.LR_inc_adic

                        '3ER REPORTE
                        .LOO_ReDeAp_ini = 0
                        .LOO_ReDeAp_ns = objLiquidacionEO.LOO_ReDeAp_ns
                        .LOO_ReDeAp_adic = objLiquidacionEO.LOO_ReDeAp_adic

                        .detraccion_ini = 0
                        .detraccion_ns = 0
                        .detraccion_adic = 0

                        .AF_EjecucionIng_ini = 0
                        .AF_EjecucionIng_ns = 0
                        .AF_EjecucionIng_adic = 0

                        .AF_Percepcion_ini = 0
                        .AF_Percepcion_ns = 0
                        .AF_Percepcion_adic = 0

                        .AF_Otrosps_ini = 0
                        .AF_Otrosps_ns = 0
                        .AF_Otrosps_adic = 0

                        .AF_Detraccion_ini = 0
                        .AF_Detraccion_ns = 0
                        .AF_Detraccion_adic = 0

                        .AF_Retencion_ini = 0
                        .AF_Retencion_ns = 0
                        .AF_Retencion_adic = 0

                        .AF_Otrosng_ini = 0
                        .AF_Otrosng_ns = 0
                        .AF_Otrosng_adic = 0


                        'ANALISIS FINANCIERO
                        .AF_TotalPagoProvSust_ini = 0
                        .AF_TotalPagoProvSust_ns = objLiquidacionEO.AF_TotalPagoProvSust_ns
                        .AF_TotalPagoProvSust_adic = objLiquidacionEO.AF_TotalPagoProvSust_adic

                        'NOS SUSTENTADOS
                        '  .AF_RefGastoNoSust_ini = 0
                        .AF_RefGastoNoSust_ns = objLiquidacionEO.AF_RefGastoNoSust_ns * -1
                        '  .AF_RefGastoNoSust_adic = objLiquidacionEO.AF_RefGastoNoSust_adic
                        'EGRESOS
                        .LP_EgresoNoSustentado_ns = objLiquidacionEO.LP_EgresoNoSustentado_ns
                        .LP_EgresoNoSustentado_adic = objLiquidacionEO.LP_EgresoNoSustentado_adic
                        .LP_EgresoInciAdic_adic = objLiquidacionEO.LP_EgresoInciAdic_adic
                End Select
            End With
            HeliosData.totalesLiquidacion.Add(objNuevo)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function GetUbicaLiquidacionPorID(nLiquidacion As totalesLiquidacion) As totalesLiquidacion
        Dim objTotalLiquidacion As totalesLiquidacion = HeliosData.totalesLiquidacion.Where(Function(o) o.idEmpresa = nLiquidacion.idEmpresa And _
                                                                  o.idEstablecimiento = nLiquidacion.idEstablecimiento And _
                                                                  o.idActividad = nLiquidacion.idActividad And _
                                                                  o.tipoPlan = nLiquidacion.tipoPlan And _
                                                                  o.tipoLiquidacion = nLiquidacion.tipoLiquidacion).FirstOrDefault
        Return objTotalLiquidacion
    End Function

    Public Function GetListaLiquidacionPreliminar(intIdProyecto As Integer, strTipoPlan As String) As List(Of totalesLiquidacion)
        Dim consulta = (From n In HeliosData.totalesLiquidacion _
                             Where n.idActividad = intIdProyecto _
                             And n.tipoPlan = strTipoPlan _
                             Select n).ToList
        Return consulta
    End Function

    Public Sub UpdateTotalLiquidacionID(ByVal IdActividad As Integer, ByVal IdActividadAnt As String)
        Dim ObjProyecto As New totalesLiquidacion
        Dim IDconsulta As Integer
        Dim listTipoRecurso As New List(Of String)()
        listTipoRecurso.Add("INGRESOS")
        listTipoRecurso.Add("CADIN")
        Using ts As New TransactionScope
            Dim objConsulta = (From a In HeliosData.totalesLiquidacion
                                Where listTipoRecurso.Contains(a.tipoLiquidacion) _
                                And a.idActividad = IdActividadAnt _
                                And a.tipoPlan = "B"
                                Select a).ToList

            For Each consulta In objConsulta
                IDconsulta = consulta.secuencia
                Dim proyect As totalesLiquidacion = HeliosData.totalesLiquidacion.Where _
                                                  (Function(o) o.secuencia = IDconsulta).First()


                ObjProyecto = New totalesLiquidacion
                With proyect
                    .Action = Business.Entity.BaseBE.EntityAction.UPDATE
                    .idActividad = IdActividad
                End With
                'HeliosData.ObjectStateManager.GetObjectStateEntry(proyect).State.ToString()

            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
