Imports Helios.Cont.Business.Entity
Imports Helios.General

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMasterLiquidacion

#Region "Métodos"
    Sub Calculos()
        Dim varIgvPago_ini As Decimal = 0
        Dim varIgvPago_ns As Decimal = 0
        Dim varIgvPago_adic As Decimal = 0

        Dim VarAjusteps_ini As Decimal = 0
        Dim VarAjusteps_ns As Decimal = 0
        Dim VarAjusteps_adic As Decimal = 0

        Dim VarAjusteng_ini As Decimal = 0
        Dim VarAjusteng_ns As Decimal = 0
        Dim VarAjusteng_adic As Decimal = 0
        '2
        Dim VarDscto_ini As Decimal = 0
        Dim VarDscto_ns As Decimal = 0
        Dim VarDscto_adic As Decimal = 0
        Dim VarVentasNetas_ini As Decimal = 0
        Dim VarVentasNetas_ns As Decimal = 0
        Dim VarVentasNetas_adic As Decimal = 0

        Dim VarAjusteCostops_ini As Decimal = 0
        Dim VarAjusteCostops_ns As Decimal = 0
        Dim VarAjusteCostops_adic As Decimal = 0
        Dim VarAjusteCostong_ini As Decimal = 0
        Dim VarAjusteCostong_ns As Decimal = 0
        Dim VarAjusteCostong_adic As Decimal = 0
        Dim VarRB_ini As Decimal = 0
        Dim VarRB_ns As Decimal = 0
        Dim VarRB_adic As Decimal = 0

        Dim VarRB_INC_ini As Decimal = 0
        Dim VarRB_INC_ns As Decimal = 0
        Dim VarRB_INC_adic As Decimal = 0

        Dim VarIF_ini As Decimal = 0
        Dim VarIF_ns As Decimal = 0
        Dim VarIF_adic As Decimal = 0

        Dim VarOI_ini As Decimal = 0
        Dim VarOI_ns As Decimal = 0
        Dim VarOI_adic As Decimal = 0

        Dim VarParUtil_ini As Decimal = 0
        Dim VarParUtil_ns As Decimal = 0
        Dim VarParUtil_adic As Decimal = 0

        Dim VarPorcDL As Decimal = 0
        VarPorcDL = nudPorcDLR.Value ' Math.Round(nudPorcDLR.Value / 100, 2)

        Dim VarPorcRenta As Decimal = 0
        VarPorcRenta = nudPorcRenta.Value 'Math.Round(nudPorcRenta.Value / 100, 2)

        Dim VarPorcPago As Decimal = 0
        VarPorcPago = nudPorcPago.Value

        Dim VarDLR_ini As Decimal = 0
        Dim VarDLR_ns As Decimal = 0
        Dim VarDLR_adic As Decimal = 0

        Dim VarResulImpuesto_ini As Decimal = 0
        Dim VarResulImpuesto_ns As Decimal = 0
        Dim VarResulImpuesto_adic As Decimal = 0

        Dim VarIRenta_ini As Decimal = 0
        Dim VarIRenta_ns As Decimal = 0
        Dim VarIRenta_adic As Decimal = 0

        Dim VarRE_ini As Decimal = 0
        Dim VarRE_ns As Decimal = 0
        Dim VarRE_adic As Decimal = 0

        Dim VarPagoCta_ini As Decimal = 0
        Dim VarPagoCta_ns As Decimal = 0
        Dim VarPagoCta_adic As Decimal = 0

        Dim VarImpReg_ini As Decimal = 0
        Dim VarImpReg_ns As Decimal = 0
        Dim VarImpReg_adic As Decimal = 0


        VarAjusteps_ini = nudAjusteps_ini.Value
        VarAjusteps_ns = nudAjusteps_ns.Value
        VarAjusteps_adic = nudAjusteps_adic.Value

        VarAjusteng_ini = nudAjusteng_ini.Value
        VarAjusteng_ns = nudAjusteng_ns.Value
        VarAjusteng_adic = nudAjusteng_adic.Value

        varIgvPago_ini = Math.Round(CDec(lblIB_ini.Text) - CDec(lblcfAcum_ini.Text) + CDec(VarAjusteps_ini) - CDec(VarAjusteng_ini), 2)
        varIgvPago_ns = Math.Round(CDec(lblIB_ns.Text) - CDec(lblcfAcum_ns.Text) + CDec(VarAjusteps_ns) - CDec(VarAjusteng_ns), 2)
        varIgvPago_adic = Math.Round(CDec(lblIB_adic.Text) - CDec(lblcfAcum_adic.Text) + CDec(VarAjusteps_adic) - CDec(VarAjusteng_adic), 2)

        lblIgvPorPagar_ini.Text = varIgvPago_ini.ToString("N2")
        lblIgvPorPagar_ns.Text = varIgvPago_ns.ToString("N2")
        lblIgvPorPagar_adic.Text = varIgvPago_adic.ToString("N2")
        If CDec(lblTotalIngresos.Text) > 0 Then
            lblPorcIgv_ini.Text = Math.Round((varIgvPago_ini / CDec(lblTotalIngresos.Text)) * 100, 2) & " %"
            lblPorcIgv_ns.Text = Math.Round((varIgvPago_ns / CDec(lblTotalIngresos.Text)) * 100, 2) & " %"
            lblPorcIgv_adic.Text = Math.Round((varIgvPago_adic / CDec(lblTotalIngresos.Text)) * 100, 2) & " %"
        End If
        If lblTotalIngresos.Text.Trim.Length > 0 Then
            If CDec(lblTotalIngresos.Text) > 0 Then
                lblLI_ini.Text = Math.Round(varIgvPago_ini / CDec(lblTotalIngresos.Text), 2).ToString("N2") & " %"
                lblLI_ns.Text = Math.Round(varIgvPago_ns / CDec(lblTotalIngresos.Text), 2).ToString("N2") & " %"
                lblLI_adic.Text = Math.Round(varIgvPago_adic / CDec(lblTotalIngresos.Text), 2).ToString("N2") & " %"
            End If
        End If



        lblLF_Igv_ini.Text = varIgvPago_ini.ToString("N2")
        lblLF_Igv_ns.Text = varIgvPago_ns.ToString("N2")
        lblLF_Igv_adic.Text = varIgvPago_adic.ToString("N2")


        If lblTotalIngresos.Text.Trim.Length > 0 Then
            If CDec(lblTotalIngresos.Text) > 0 Then
                por1_ini.Text = Math.Round(varIgvPago_ini / CDec(lblTotalIngresos.Text) * 100, 2).ToString("N2") & " %"
                por1_ns.Text = Math.Round(varIgvPago_ns / CDec(lblTotalIngresos.Text) * 100, 2).ToString("N2") & " %"
                por1_adic.Text = Math.Round(varIgvPago_adic / CDec(lblTotalIngresos.Text) * 100, 2).ToString("N2") & " %"
            End If
        End If



        '2
        VarDscto_ini = nudDscto_ini.Value
        VarDscto_ns = nudDscto_ns.Value
        VarDscto_adic = nudDscto_adic.Value

        'resultado Ventas Netas
        If lblventan_ini.Text.Trim.Length > 0 Then
            VarVentasNetas_ini = Math.Round(CDec(lblventan_ini.Text) - CDec(VarDscto_ini), 2)
            nudVentasNetas_ini.Value = VarVentasNetas_ini.ToString("N2")
        End If

        If lblventan_ns.Text.Trim.Length > 0 Then
            VarVentasNetas_ns = Math.Round(CDec(lblventan_ns.Text) - CDec(VarDscto_ns), 2)
            nudVentasNetas_ns.Value = VarVentasNetas_ns.ToString("N2")
        End If

        If lblventan_adic.Text.Trim.Length > 0 Then
            VarVentasNetas_adic = Math.Round(CDec(lblventan_adic.Text) - CDec(VarDscto_adic), 2)
            nudVentasNetas_adic.Value = VarVentasNetas_adic.ToString("N2")
        End If

        '---------------------------------------------------------------------------------

        VarAjusteCostops_ini = nudAjusteCostops_ini.Value
        VarAjusteCostops_ns = nudAjusteCostops_ns.Value
        VarAjusteCostops_adic = nudAjusteCostops_adic.Value

        VarAjusteCostong_ini = nudAjusteCostong_ini.Value
        VarAjusteCostong_ns = nudAjusteCostong_ns.Value
        VarAjusteCostong_adic = nudAjusteCostong_adic.Value
        'resultado Venta Bruta
        If lblcostov_ini.Text.Trim.Length > 0 Then
            VarRB_ini = Math.Round(CDec(VarVentasNetas_ini) - CDec(lblcostov_ini.Text) + CDec(VarAjusteCostops_ini) - CDec(VarAjusteCostong_ini), 2)
        End If
        If lblcostov_ns.Text.Trim.Length > 0 Then
            VarRB_ns = Math.Round(CDec(VarVentasNetas_ns) - CDec(lblcostov_ns.Text) + CDec(VarAjusteCostops_ns) - CDec(VarAjusteCostong_ns), 2)
        End If
        If lblcostov_adic.Text.Trim.Length > 0 Then
            VarRB_adic = Math.Round(CDec(VarVentasNetas_adic) - CDec(lblcostov_adic.Text) + CDec(VarAjusteCostops_adic) - CDec(VarAjusteCostong_adic), 2)
        End If

        lblRB_ini.Text = VarRB_ini.ToString("N2")
        lblRB_ns.Text = VarRB_ns.ToString("N2")
        lblRB_adic.Text = VarRB_adic.ToString("N2")

        'RESULTADO BRUTO CON INCIDENCIA
        VarRB_INC_ini = Math.Round(VarRB_ini - 0, 2)
        If lblinc_ns.Text.Trim.Length > 0 Then
            VarRB_INC_ns = Math.Round(VarRB_ns - CDec(lblinc_ns.Text), 2)
        End If

        If lblinc_adic.Text.Trim.Length > 0 Then
            VarRB_INC_adic = Math.Round(VarRB_adic - CDec(lblinc_adic.Text), 2)
        End If

        lblRB_inc_ini.Text = VarRB_INC_ini.ToString("N2")
        lblRB_inc_ns.Text = VarRB_INC_ns.ToString("N2")
        lblRB_inc_adic.Text = VarRB_INC_adic.ToString("N2")
        '------------------------------------------------------------------------------------------
        'Resultado Antes de Partic. De Utilidades
        VarIF_ini = nudIF_ini.Value
        VarIF_ns = nudIF_ns.Value
        VarIF_adic = nudIF_adic.Value

        VarOI_ini = nudOI_ini.Value
        VarOI_ns = nudOI_ns.Value
        VarOI_adic = nudOI_adic.Value

        VarParUtil_ini = Math.Round(VarRB_INC_ini + VarIF_ini + VarOI_ini, 2)
        VarParUtil_ns = Math.Round(VarRB_INC_ns + VarIF_ns + VarOI_ns, 2)
        VarParUtil_adic = Math.Round(VarRB_INC_adic + VarIF_adic + VarOI_adic, 2)
        lblParUtil_ini.Text = VarParUtil_ini.ToString("N2")
        lblParUtil_ns.Text = VarParUtil_ns.ToString("N2")
        lblParUtil_adic.Text = VarParUtil_adic.ToString("N2")
        '---------------------------------------------------------------------------------------

        VarDLR_ini = Math.Round((VarParUtil_ini * VarPorcDL) / 100, 2)
        VarResulImpuesto_ini = Math.Round(VarParUtil_ini - VarDLR_ini, 2)
        nudDLR_ini.Value = VarDLR_ini.ToString("N2")

        VarDLR_ns = Math.Round((VarParUtil_ns * VarPorcDL) / 100, 2)
        VarResulImpuesto_ns = Math.Round(VarParUtil_ns - VarDLR_ns, 2)
        nudDLR_ns.Value = VarDLR_ns.ToString("N2")

        VarDLR_adic = Math.Round((VarParUtil_adic * VarPorcDL) / 100, 2)
        VarResulImpuesto_adic = Math.Round(VarParUtil_adic - VarDLR_adic, 2)
        nudDLR_adic.Value = VarDLR_adic.ToString("N2")

        lblResulImpuesto_ini.Text = VarResulImpuesto_ini.ToString("N2")
        lblResulImpuesto_ns.Text = VarResulImpuesto_ns.ToString("N2")
        lblResulImpuesto_adic.Text = VarResulImpuesto_adic.ToString("N2")
        '-------------------------------------------------------------------------------------------
        If VarResulImpuesto_ini > 0 Then
            VarIRenta_ini = Math.Round((VarResulImpuesto_ini * VarPorcRenta) / 100, 2)
            'VarRE_ini = Math.Round(VarResulImpuesto_ini - VarIRenta_ini, 2)
        Else
            VarIRenta_ini = 0
            VarRE_ini = 0
        End If
        VarRE_ini = Math.Round(VarResulImpuesto_ini - VarIRenta_ini, 2)

        If VarIRenta_ini > 0 Then
            nudIRenta_ini.Value = VarIRenta_ini.ToString("N2")
            lblLF_Renta_ini.Text = VarIRenta_ini.ToString("N2")
        Else
            nudIRenta_ini.Value = 0
        End If

        If VarResulImpuesto_ns > 0 Then
            VarIRenta_ns = Math.Round((VarResulImpuesto_ns * VarPorcRenta) / 100, 2)
            'VarRE_ns = Math.Round(VarResulImpuesto_ns - VarIRenta_ns, 2)
        Else
            VarIRenta_ns = 0
            VarRE_ns = 0
        End If
        VarRE_ns = Math.Round(VarResulImpuesto_ns - VarIRenta_ns, 2)

        If VarIRenta_ns > 0 Then
            nudIRenta_ns.Value = VarIRenta_ns.ToString("N2")
            lblLF_Renta_ns.Text = VarIRenta_ns.ToString("N2")
        Else
            nudIRenta_ns.Value = 0
        End If

        If VarResulImpuesto_adic > 0 Then
            VarIRenta_adic = Math.Round((VarResulImpuesto_adic * VarPorcRenta) / 100, 2)
            'VarRE_adic = Math.Round(VarResulImpuesto_adic - VarIRenta_adic, 2)
        Else
            VarIRenta_adic = 0
            VarRE_adic = 0
        End If
        VarRE_adic = Math.Round(VarResulImpuesto_adic - VarIRenta_adic, 2)

        If VarIRenta_adic > 0 Then
            nudIRenta_adic.Value = VarIRenta_adic.ToString("N2")
            lblLF_Renta_adic.Text = VarIRenta_adic.ToString("N2")
        Else
            nudIRenta_adic.Value = 0
        End If


        lblRE_ini.Text = VarRE_ini.ToString("N2")
        lblRE_ns.Text = VarRE_ns.ToString("N2")
        lblRE_adic.Text = VarRE_adic.ToString("N2")
        '-----------------------------------------------------------------------------------------------
        If lblventan_ini.Text.Trim.Length > 0 Then
            VarPagoCta_ini = Math.Round((CDec(lblventan_ini.Text) * VarPorcPago) / 100, 2)
            nudPagoCta_ini.Value = VarPagoCta_ini.ToString("N2")
        End If
        If lblventan_ns.Text.Trim.Length > 0 Then
            VarPagoCta_ns = Math.Round((CDec(lblventan_ns.Text) * VarPorcPago) / 100, 2)
            nudPagoCta_ns.Value = VarPagoCta_ns.ToString("N2")
        End If
        If lblventan_adic.Text.Trim.Length > 0 Then
            VarPagoCta_adic = Math.Round((CDec(lblventan_adic.Text) * VarPorcPago) / 100, 2)
            nudPagoCta_adic.Value = VarPagoCta_adic.ToString("N2")
        End If

        VarImpReg_ini = Math.Round(nudIRenta_ini.Value - VarPagoCta_ini, 2)
        VarImpReg_ns = Math.Round(nudIRenta_ns.Value - VarPagoCta_ns, 2)
        VarImpReg_adic = Math.Round(nudIRenta_adic.Value - VarPagoCta_adic, 2)

        lblImpReg_ini.Text = VarImpReg_ini.ToString("N2")
        lblImpReg_ns.Text = VarImpReg_ns.ToString("N2")
        lblImpReg_adic.Text = VarImpReg_adic.ToString("N2")

        If nudIRenta_ini.Value > 0 Then
            nudCoePago_ini.Value = Math.Round((CDec(nudIRenta_ini.Value) / (CDec(nudVentasNetas_ini.Value) + CDec(nudIF_ini.Value) + CDec(nudOI_ini.Value))) * 100, 2)
        End If

        If nudIRenta_ns.Value > 0 Then
            nudCoePago_ns.Value = Math.Round((CDec(nudIRenta_ns.Value) / (CDec(nudVentasNetas_ns.Value) + CDec(nudIF_ns.Value) + CDec(nudOI_ns.Value))) * 100, 2)
        End If
        If nudIRenta_adic.Value > 0 Then
            nudCoePago_adic.Value = Math.Round((CDec(nudIRenta_adic.Value) / (CDec(nudVentasNetas_adic.Value) + CDec(nudIF_adic.Value) + CDec(nudOI_adic.Value))) * 100, 2)
        End If
        '3er reporte
        LF_Igv_ini.Text = CDec(lblIgvPorPagar_ini.Text).ToString("N2")
        LF_Igv_ns.Text = CDec(lblIgvPorPagar_ns.Text).ToString("N2")
        LF_Igv_adic.Text = CDec(lblIgvPorPagar_adic.Text).ToString("N2")

        LF_Irenta__ini.Text = nudIRenta_ini.Value.ToString("N2")
        LF_Irenta__ns.Text = nudIRenta_ns.Value.ToString("N2")
        LF_Irenta__adic.Text = nudIRenta_adic.Value.ToString("N2")

        If lblTotalIngresos.Text.Trim.Length > 0 Then
            If CDec(lblTotalIngresos.Text) > 0 Then
                por2_ini.Text = Math.Round(CDec(LF_Irenta__ini.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                por2_ns.Text = Math.Round(CDec(LF_Irenta__ns.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                por2_adic.Text = Math.Round(CDec(LF_Irenta__adic.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
            End If
        End If


        If LF_RDA_ini.Text.Trim.Length > 0 Then
            LF_Total_ini.Text = Math.Round(CDec(LF_Igv_ini.Text) + CDec(LF_Irenta__ini.Text) + CDec(LF_RDA_ini.Text), 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por4_ini.Text = Math.Round(CDec(LF_Total_ini.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If



        End If
        If LF_RDA_ns.Text.Trim.Length > 0 Then
            LF_Total_ns.Text = Math.Round(CDec(LF_Igv_ns.Text) + CDec(LF_Irenta__ns.Text) + CDec(LF_RDA_ns.Text), 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por4_ns.Text = Math.Round(CDec(LF_Total_ns.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If

        End If
        If LF_RDA_adic.Text.Trim.Length > 0 Then
            LF_Total_adic.Text = Math.Round(CDec(LF_Igv_adic.Text) + CDec(LF_Irenta__adic.Text) + CDec(LF_RDA_adic.Text), 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por4_adic.Text = Math.Round(CDec(LF_Total_adic.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If

        End If

        If LF_Total_ini.Text.Trim.Length > 0 Then
            lblLF_TotalObligacion_ini.Text = Math.Round(CDec(LF_Total_ini.Text) + CDec(nudLF_OtrosGastos_ini.Value), 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por6_ini.Text = Math.Round(CDec(lblLF_TotalObligacion_ini.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If

        End If

        If LF_Total_ns.Text.Trim.Length > 0 Then
            lblLF_TotalObligacion_ns.Text = Math.Round(CDec(LF_Total_ns.Text) + CDec(nudLF_OtrosGastos_ns.Value), 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por6_ns.Text = Math.Round(CDec(lblLF_TotalObligacion_ns.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If
        End If

        If LF_Total_adic.Text.Trim.Length > 0 Then
            lblLF_TotalObligacion_adic.Text = Math.Round(CDec(LF_Total_adic.Text) + CDec(nudLF_OtrosGastos_adic.Value), 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por6_adic.Text = Math.Round(CDec(lblLF_TotalObligacion_adic.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If
        End If

        If lblLF_TotalObligacion_ini.Text.Trim.Length > 0 Then
            lblLF_TO_ini.Text = Math.Round(CDec(lblLF_TotalObligacion_ini.Text) - CDec(lblLF_Detraccion_ini.Text), 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por8_ini.Text = Math.Round(CDec(lblLF_TO_ini.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If

        End If
        If lblLF_TotalObligacion_ns.Text.Trim.Length > 0 Then
            lblLF_TO_ns.Text = Math.Round(CDec(lblLF_TotalObligacion_ns.Text) - CDec(lblLF_Detraccion_ns.Text), 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por8_ns.Text = Math.Round(CDec(lblLF_TO_ns.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If
        End If
        If lblLF_TotalObligacion_adic.Text.Trim.Length > 0 Then
            lblLF_TO_adic.Text = Math.Round(CDec(lblLF_TotalObligacion_adic.Text) - CDec(lblLF_Detraccion_adic.Text), 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por8_adic.Text = Math.Round(CDec(lblLF_TO_adic.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If
        End If


        Dim LF_RetUti_ini As Decimal = 0
        Dim LF_RetUti_ns As Decimal = 0
        Dim LF_RetUti_adic As Decimal = 0

        LF_RetUti_ini = Math.Round((CDec(lblRE_ini.Text) * CDec(nudPorcRetUti.Value)) / 100, 2)
        LF_RetUti_ns = Math.Round((CDec(lblRE_ns.Text) * CDec(nudPorcRetUti.Value)) / 100, 2)
        LF_RetUti_adic = Math.Round((CDec(lblRE_adic.Text) * CDec(nudPorcRetUti.Value)) / 100, 2)

        If (LF_RetUti_ini) < 0 Then
            nudLF_RetUti_ini.Value = 0
        Else
            nudLF_RetUti_ini.Value = LF_RetUti_ini.ToString("N2")
        End If

        If (LF_RetUti_ns) < 0 Then
            nudLF_RetUti_ns.Value = 0
        Else
            nudLF_RetUti_ns.Value = LF_RetUti_ns.ToString("N2")
        End If

        If (LF_RetUti_adic) < 0 Then
            nudLF_RetUti_adic.Value = 0
        Else
            nudLF_RetUti_adic.Value = LF_RetUti_adic.ToString("N2")
        End If

        If lblTotalIngresos.Text.Trim.Length > 0 Then
            If CDec(lblTotalIngresos.Text) > 0 Then
                por9_ini.Text = Math.Round(CDec(nudLF_RetUti_ini.Value) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                por9_ns.Text = Math.Round(CDec(nudLF_RetUti_ns.Value) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                por9_adic.Text = Math.Round(CDec(nudLF_RetUti_adic.Value) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
            End If
        End If


        If LF_RetUti_ini < 0 Then
            lblLF_RetUti_ini.Text = 0
        Else
            lblLF_RetUti_ini.Text = LF_RetUti_ini.ToString("N2")
        End If

        If LF_RetUti_ns < 0 Then
            lblLF_RetUti_ns.Text = 0
        Else
            lblLF_RetUti_ns.Text = LF_RetUti_ns.ToString("N2")
        End If

        If LF_RetUti_adic < 0 Then
            lblLF_RetUti_adic.Text = 0
        Else
            lblLF_RetUti_adic.Text = LF_RetUti_adic.ToString("N2")
        End If

        If lblLF_TO_ini.Text.Trim.Length > 0 Then
            LF_ini.Text = Math.Round(CDec(lblLF_TO_ini.Text) + nudLF_RetUti_ini.Value, 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por10_ini.Text = Math.Round(CDec(LF_ini.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If

        End If
        If lblLF_TO_ns.Text.Trim.Length > 0 Then
            LF_ns.Text = Math.Round(CDec(lblLF_TO_ns.Text) + nudLF_RetUti_ns.Value, 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por10_ns.Text = Math.Round(CDec(LF_ns.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If
        End If
        If lblLF_TO_adic.Text.Trim.Length > 0 Then
            LF_adic.Text = Math.Round(CDec(lblLF_TO_adic.Text) + nudLF_RetUti_adic.Value, 2).ToString("N2")

            If lblTotalIngresos.Text.Trim.Length > 0 Then
                If CDec(lblTotalIngresos.Text) > 0 Then
                    por10_adic.Text = Math.Round(CDec(LF_adic.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                End If
            End If
        End If

        '4
        Dim VarAF_IN_ini As Decimal = 0
        Dim VarAF_IN_ns As Decimal = 0
        Dim VarAF_IN_adic As Decimal = 0
        If lblAF_EI_ini.Text.Trim.Length > 0 Then
            VarAF_IN_ini = Math.Round(CDec(lblAF_EI_ini.Text) + CDec(lblAF_Perc_ini.Text) + CDec(lblAF_Otrosps_ini.Text) - CDec(lblAF_Detra_ini.Text) - CDec(lblAF_Reten_ini.Text) - CDec(lblAF_Otrosng_ini.Text), 2).ToString("N2")
        End If
        If lblAF_EI_ns.Text.Trim.Length > 0 Then
            VarAF_IN_ns = Math.Round(CDec(lblAF_EI_ns.Text) + CDec(lblAF_Perc_ns.Text) + CDec(lblAF_Otrosps_ns.Text) - CDec(lblAF_Detra_ns.Text) - CDec(lblAF_Reten_ns.Text) - CDec(lblAF_Otrosng_ns.Text), 2).ToString("N2")
        End If
        If lblAF_EI_adic.Text.Trim.Length > 0 Then
            VarAF_IN_adic = Math.Round(CDec(lblAF_EI_adic.Text) + CDec(lblAF_Perc_adic.Text) + CDec(lblAF_Otrosps_adic.Text) - CDec(lblAF_Detra_adic.Text) - CDec(lblAF_Reten_adic.Text) - CDec(lblAF_Otrosng_adic.Text), 2).ToString("N2")
        End If
        lblAF_IN_ini.Text = VarAF_IN_ini.ToString("N2")
        lblAF_IN_ns.Text = VarAF_IN_ns.ToString("N2")
        lblAF_IN_adic.Text = VarAF_IN_adic.ToString("N2")

        Dim VarAF_SaldoEF_ini As Decimal = 0
        Dim VarAF_SaldoEF_ns As Decimal = 0
        Dim VarAF_SaldoEF_adic As Decimal = 0
        'igv
        lblAF_Igv_ini.Text = CDec(lblIgvPorPagar_ini.Text).ToString("N2")
        lblAF_Igv_ns.Text = CDec(lblIgvPorPagar_ns.Text).ToString("N2")
        lblAF_Igv_adic.Text = CDec(lblIgvPorPagar_adic.Text).ToString("N2")
        'renta
        lblAF_Renta_ini.Text = nudIRenta_ini.Value
        lblAF_Renta_ns.Text = nudIRenta_ns.Value
        lblAF_Renta_adic.Text = nudIRenta_adic.Value

        If lblAF_PagoProv_ini.Text.Trim.Length > 0 Then
            VarAF_SaldoEF_ini = Math.Round(VarAF_IN_ini - CDec(lblAF_PagoProv_ini.Text), 2).ToString("N2")
        End If
        If lblAF_PagoProv_ns.Text.Trim.Length > 0 Then
            VarAF_SaldoEF_ns = Math.Round(VarAF_IN_ns - CDec(lblAF_PagoProv_ns.Text), 2).ToString("N2")
        End If
        If lblAF_PagoProv_adic.Text.Trim.Length > 0 Then
            VarAF_SaldoEF_adic = Math.Round(VarAF_IN_adic - CDec(lblAF_PagoProv_adic.Text), 2).ToString("N2")
        End If


        lblAF_SaldoEF_ini.Text = VarAF_SaldoEF_ini.ToString("N2")
        lblAF_SaldoEF_ns.Text = VarAF_SaldoEF_ns.ToString("N2")
        lblAF_SaldoEF_adic.Text = VarAF_SaldoEF_adic.ToString("N2")

        If lblAF_Igv_ini.Text.Trim.Length > 0 Then
            If lblAF_RDA_ini.Text.Trim.Length > 0 Then
                lblAF_TotalPagoOT_ini.Text = Math.Round(CDec(lblAF_Igv_ini.Text) + CDec(lblAF_Renta_ini.Text) + CDec(lblAF_RDA_ini.Text) + CDec(nudAF_OtrosPagos_ini.Value), 2).ToString("N2")
            End If

        End If
        If lblAF_Igv_ns.Text.Trim.Length > 0 Then
            If lblAF_RDA_ns.Text.Trim.Length > 0 Then
                lblAF_TotalPagoOT_ns.Text = Math.Round(CDec(lblAF_Igv_ns.Text) + CDec(lblAF_Renta_ns.Text) + CDec(lblAF_RDA_ns.Text) + CDec(nudAF_OtrosPagos_ns.Value), 2).ToString("N2")
            End If
        End If
        If lblAF_Igv_adic.Text.Trim.Length > 0 Then
            If lblAF_RDA_adic.Text.Trim.Length > 0 Then
                lblAF_TotalPagoOT_adic.Text = Math.Round(CDec(lblAF_Igv_adic.Text) + CDec(lblAF_Renta_adic.Text) + CDec(lblAF_RDA_adic.Text) + CDec(nudAF_OtrosPagos_adic.Value), 2).ToString("N2")
            End If

        End If
        'saldo final
        If lblAF_TotalPagoOT_ini.Text.Trim.Length > 0 Then
            lblAF_SaldoFinal_ini.Text = Math.Round(CDec(lblAF_SaldoEF_ini.Text) - CDec(lblAF_TotalPagoOT_ini.Text), 2).ToString("N2")
            If CDec(lblAF_EI_ini.Text) > 0 Then
                lblPorcSaldo_ini.Text = Math.Round((CDec(lblAF_SaldoFinal_ini.Text) / CDec(lblAF_EI_ini.Text)) * 100, 2) & " %"
                lblPorcCon_ini.Text = Math.Round((CDec(lblAF_SaldoFinalC_ini.Text) / CDec(lblAF_EI_ini.Text)) * 100, 2) & " %"
            End If

        End If
        If lblAF_TotalPagoOT_ns.Text.Trim.Length > 0 Then
            lblAF_SaldoFinal_ns.Text = Math.Round(CDec(lblAF_SaldoEF_ns.Text) - CDec(lblAF_TotalPagoOT_ns.Text), 2).ToString("N2")
            If CDec(lblAF_EI_ns.Text) > 0 Then
                lblPorcSaldo_ns.Text = Math.Round((CDec(lblAF_SaldoFinal_ns.Text) / CDec(lblAF_EI_ns.Text)) * 100, 2) & " %"
                lblPorcCon_ns.Text = Math.Round((CDec(lblAF_SaldoFinalC_ns.Text) / CDec(lblAF_EI_ns.Text)) * 100, 2) & " %"
            End If

        End If
        If lblAF_TotalPagoOT_adic.Text.Trim.Length > 0 Then
            lblAF_SaldoFinal_adic.Text = Math.Round(CDec(lblAF_SaldoEF_adic.Text) - CDec(lblAF_TotalPagoOT_adic.Text), 2).ToString("N2")
            If CDec(lblAF_EI_adic.Text) > 0 Then
                lblPorcSaldo_adic.Text = Math.Round((CDec(lblAF_SaldoFinal_adic.Text) / CDec(lblAF_EI_adic.Text)) * 100, 2) & " %"
                lblPorcCon_adic.Text = Math.Round((CDec(lblAF_SaldoFinalC_adic.Text) / CDec(lblAF_EI_adic.Text)) * 100, 2) & " %"
            End If

        End If

        If lblAF_SaldoFinal_ini.Text.Trim.Length > 0 Then
            lblAF_SaldoFinalC_ini.Text = Math.Round(CDec(lblAF_SaldoFinal_ini.Text) + CDec(nudAF_AjusteCF_ini.Value) - CDec(nudAF_AjusteCFng_ini.Value) - CDec(lblAF_Perc2_ini.Text) - CDec(lblAF_Otrosps2_ini.Text) + CDec(lblAF_Detra2_ini.Text) + CDec(lblAF_Reten2_ini.Text) + CDec(lblAF_Otrosng2_ini.Text) + CDec(nudAF_AjRentaps_ini.Value) - CDec(nudAF_AjRentang_ini.Value), 2).ToString("N2")
        End If

        If lblAF_SaldoFinal_ns.Text.Trim.Length > 0 Then
            lblAF_SaldoFinalC_ns.Text = Math.Round(CDec(lblAF_SaldoFinal_ns.Text) + CDec(nudAF_AjusteCF_ns.Value) - CDec(nudAF_AjusteCFng_ns.Value) - CDec(lblAF_Perc2_ns.Text) - CDec(lblAF_Otrosps2_ns.Text) + CDec(lblAF_Detra2_ns.Text) + CDec(lblAF_Reten2_ns.Text) + CDec(lblAF_Otrosng2_ns.Text) + CDec(nudAF_AjRentaps_ns.Value) - CDec(nudAF_AjRentang_ns.Value), 2).ToString("N2")
        End If

        If lblAF_SaldoFinal_adic.Text.Trim.Length > 0 Then
            lblAF_SaldoFinalC_adic.Text = Math.Round(CDec(lblAF_SaldoFinal_adic.Text) + CDec(nudAF_AjusteCF_adic.Value) - CDec(nudAF_AjusteCFng_adic.Value) - CDec(lblAF_Perc2_adic.Text) - CDec(lblAF_Otrosps2_adic.Text) + CDec(lblAF_Detra2_adic.Text) + CDec(lblAF_Reten2_adic.Text) + CDec(lblAF_Otrosng2_adic.Text) + CDec(nudAF_AjRentaps_adic.Value) - CDec(nudAF_AjRentang_adic.Value), 2).ToString("N2")
        End If

        If lblAF_SaldoFinalC_ini.Text.Trim.Length > 0 Then
            lblValidador_ini.Text = Math.Round(CDec(lblAF_SaldoFinalC_ini.Text) - CDec(lblRE_ini.Text), 2).ToString("N2")
        End If

        If lblAF_SaldoFinalC_ns.Text.Trim.Length > 0 Then
            lblValidador_ns.Text = Math.Round(CDec(lblAF_SaldoFinalC_ns.Text) - CDec(lblRE_ns.Text), 2).ToString("N2")
        End If

        If lblAF_SaldoFinalC_adic.Text.Trim.Length > 0 Then
            lblValidador_adic.Text = Math.Round(CDec(lblAF_SaldoFinalC_adic.Text) - CDec(lblRE_adic.Text), 2).ToString("N2")
        End If


        'LIQUIDACION PLANEAMIENTO       
        If lblLP_IngProy_ini.Text.Trim.Length > 0 And lblAF_Perc3_ini.Text.Trim.Length > 0 And lblAF_Otrosps3_ini.Text.Trim.Length > 0 And lblAF_Detra3_ini.Text.Trim.Length > 0 And lblAF_Reten3_ini.Text.Trim.Length > 0 And lblAF_Otrosng3_ini.Text.Trim.Length > 0 Then
            lblLP_IN_ini.Text = Math.Round(CDec((lblLP_IngProy_ini.Text)) + CDec((lblAF_Perc3_ini.Text)) + CDec((lblAF_Otrosps3_ini.Text)) - CDec((lblAF_Detra3_ini.Text)) - CDec((lblAF_Reten3_ini.Text)) - CDec((lblAF_Otrosng3_ini.Text)), 2).ToString("N2")
        End If
        If lblLP_IngProy_ns.Text.Trim.Length > 0 And lblAF_Perc3_ns.Text.Trim.Length > 0 And lblAF_Otrosps3_ns.Text.Trim.Length > 0 And lblAF_Detra3_ns.Text.Trim.Length > 0 And lblAF_Reten3_ns.Text.Trim.Length > 0 And lblAF_Otrosng3_ns.Text.Trim.Length > 0 Then
            lblLP_IN_ns.Text = Math.Round(CDec((lblLP_IngProy_ns.Text)) + CDec((lblAF_Perc3_ns.Text)) + CDec((lblAF_Otrosps3_ns.Text)) - CDec((lblAF_Detra3_ns.Text)) - CDec((lblAF_Reten3_ns.Text)) - CDec((lblAF_Otrosng3_ns.Text)), 2).ToString("N2")
        End If
        If lblLP_IngProy_adic.Text.Trim.Length > 0 _
            And lblAF_Perc3_adic.Text.Trim.Length > 0 _
            And lblAF_Otrosps3_adic.Text.Trim.Length > 0 _
            And lblAF_Detra3_adic.Text.Trim.Length > 0 _
            And lblAF_Reten3_adic.Text.Trim.Length > 0 _
            And lblAF_Otrosng3_adic.Text.Trim.Length > 0 Then
            lblLP_IN_adic.Text = Math.Round(CDec((lblLP_IngProy_adic.Text)) + CDec((lblAF_Perc3_adic.Text)) + CDec((lblAF_Otrosps3_adic.Text)) - CDec((lblAF_Detra3_adic.Text)) - CDec((lblAF_Reten3_adic.Text)) - CDec((lblAF_Otrosng3_adic.Text)), 2).ToString("N2")
        End If

        If lblAF_EI_ini.Text.Trim.Length > 0 Then
            lblLP_IngProy_ini.Text = CDec(lblAF_EI_ini.Text).ToString("N2") ' VarAF_IN_ini
        End If
        If lblAF_EI_ns.Text.Trim.Length > 0 Then
            lblLP_IngProy_ns.Text = CDec(lblAF_EI_ns.Text).ToString("N2") ' VarAF_IN_ns
        End If
        If lblAF_EI_adic.Text.Trim.Length > 0 Then
            lblLP_IngProy_adic.Text = CDec(lblAF_EI_adic.Text).ToString("N2") ' VarAF_IN_adic
        End If

        'EGRESOS(SUMATORIA)
        If lblAF_PagoProv2_ini.Text.Trim.Length > 0 Then
            lblLF_Egreso_ini.Text = Math.Round(CDec((lblAF_PagoProv2_ini.Text)), 2).ToString("N2")
        End If
        If lblAF_PagoProv2_ns.Text.Trim.Length > 0 And lblLP_EgresoNS_ns.Text.Trim.Length > 0 Then
            lblLF_Egreso_ns.Text = Math.Round(CDec((lblAF_PagoProv2_ns.Text)) + CDec((lblLP_EgresoNS_ns.Text)), 2).ToString("N2")
        End If
        If lblAF_PagoProv2_adic.Text.Trim.Length > 0 And lblLP_EgresoNS_adic.Text.Trim.Length > 0 And lblLP_EgresoIncAdic_adic.Text.Trim.Length > 0 Then
            lblLF_Egreso_adic.Text = Math.Round(CDec((lblAF_PagoProv2_adic.Text)) + CDec((lblLP_EgresoNS_adic.Text)) + CDec((lblLP_EgresoIncAdic_adic.Text)), 2).ToString("N2")
        End If


        'resultado antes de tributo
        If lblLP_IN_ini.Text.Trim.Length > 0 And lblLF_Egreso_ini.Text.Trim.Length > 0 Then
            lblLF_ResTributo_ini.Text = Math.Round(CDec((lblLP_IN_ini.Text)) - CDec((lblLF_Egreso_ini.Text)), 2).ToString("N2")
        End If
        If lblLP_IN_ns.Text.Trim.Length > 0 And lblLF_Egreso_ns.Text.Trim.Length > 0 Then
            lblLF_ResTributo_ns.Text = Math.Round(CDec((lblLP_IN_ns.Text)) - CDec((lblLF_Egreso_ns.Text)), 2).ToString("N2")
        End If
        If lblLP_IN_adic.Text.Trim.Length > 0 And lblLF_Egreso_adic.Text.Trim.Length > 0 Then
            lblLF_ResTributo_adic.Text = Math.Round(CDec((lblLP_IN_adic.Text)) - CDec((lblLF_Egreso_adic.Text)), 2).ToString("N2")
        End If


        'TRIBUTOS
        If lblLF_Renta_ini.Text.Trim.Length > 0 And lblLF_Igv_ini.Text.Trim.Length > 0 And lblLF_RDA_ini.Text.Trim.Length > 0 And lblLF_RetUti_ini.Text.Trim.Length > 0 Then
            lblAF_Tributo_ini.Text = Math.Round(CDec((lblLF_Igv_ini.Text)) + CDec((lblLF_Renta_ini.Text)) + CDec((lblLF_RDA_ini.Text)) + CDec((lblLF_RetUti_ini.Text)) + CDec((nudLP_OtrodsPagos_ini.Value)) - CDec(lblAF_Perc4_ini.Text) - CDec(lblAF_Detra4_ini.Text) - CDec(lblAF_Reten4_ini.Text), 2).ToString("N2")
        End If
        If lblLF_Renta_ns.Text.Trim.Length > 0 And lblLF_Igv_ns.Text.Trim.Length > 0 And lblLF_RDA_ns.Text.Trim.Length > 0 And lblLF_RetUti_ns.Text.Trim.Length > 0 Then
            lblAF_Tributo_ns.Text = Math.Round(CDec((lblLF_Igv_ns.Text)) + CDec((lblLF_Renta_ns.Text)) + CDec((lblLF_RDA_ns.Text)) + CDec((lblLF_RetUti_ns.Text)) + CDec((nudLP_OtrodsPagos_ns.Value)) - CDec(lblAF_Perc4_ns.Text) - CDec(lblAF_Detra4_ns.Text) - CDec(lblAF_Reten4_ns.Text), 2).ToString("N2")
        End If
        If lblLF_Renta_adic.Text.Trim.Length > 0 And lblLF_Igv_adic.Text.Trim.Length > 0 And lblLF_RDA_adic.Text.Trim.Length > 0 And lblLF_RetUti_adic.Text.Trim.Length > 0 Then
            lblAF_Tributo_adic.Text = Math.Round(CDec((lblLF_Igv_adic.Text)) + CDec((lblLF_Renta_adic.Text)) + CDec((lblLF_RDA_adic.Text)) + CDec((lblLF_RetUti_adic.Text)) + CDec((nudLP_OtrodsPagos_adic.Value)) - CDec(lblAF_Perc4_adic.Text) - CDec(lblAF_Detra4_adic.Text) - CDec(lblAF_Reten4_adic.Text), 2).ToString("N2")
        End If


        'SALDO DE EFECTIVO
        If lblLF_ResTributo_ini.Text.Trim.Length > 0 And lblAF_Tributo_ini.Text.Trim.Length > 0 Then
            lblLP_SaldoEfe_ini.Text = Math.Round(CDec((lblLF_ResTributo_ini.Text)) - CDec((lblAF_Tributo_ini.Text)), 2).ToString("N2")
            lblDT_ini.Text = lblLP_SaldoEfe_ini.Text

            lblDT_saldo_ini.Text = Math.Round(CDec(lblDT_ini.Text) + CDec(nudDT_OI_ini.Value) - CDec(nudDT_OE_ini.Value), 2).ToString("N2")

            'porcentaje
            If CDec(lblLP_IN_ini.Text) > 0 Then
                lblLE_ini.Text = Math.Round((CDec(lblLP_SaldoEfe_ini.Text) / CDec(lblLP_IN_ini.Text)) * 100, 2).ToString("N2") & " %"
            End If
        End If
        If lblLF_ResTributo_ns.Text.Trim.Length > 0 And lblAF_Tributo_ns.Text.Trim.Length > 0 Then
            lblLP_SaldoEfe_ns.Text = Math.Round(CDec((lblLF_ResTributo_ns.Text)) - CDec((lblAF_Tributo_ns.Text)), 2).ToString("N2")
            lblDT_ns.Text = lblLP_SaldoEfe_ns.Text

            lblDT_saldo_ns.Text = Math.Round(CDec(lblDT_ns.Text) + CDec(nudDT_OI_ns.Value) - CDec(nudDT_OE_ns.Value), 2).ToString("N2")

            'porcentaje
            If CDec(lblLP_IN_ns.Text) > 0 Then
                lblLE_ns.Text = Math.Round((CDec(lblLP_SaldoEfe_ns.Text) / CDec(lblLP_IN_ns.Text)) * 100, 2).ToString("N2") & " %"
            End If

        End If
        If lblLF_ResTributo_adic.Text.Trim.Length > 0 And lblAF_Tributo_adic.Text.Trim.Length > 0 Then
            lblLP_SaldoEfe_adic.Text = Math.Round((CDec(lblLF_ResTributo_adic.Text)) - CDec((lblAF_Tributo_adic.Text)), 2).ToString("N2")
            lblDT_adic.Text = lblLP_SaldoEfe_adic.Text

            lblDT_saldo_adic.Text = Math.Round(CDec(lblDT_adic.Text) + CDec(nudDT_OI_adic.Value) - CDec(nudDT_OE_adic.Value), 2).ToString("N2")

            'porcentaje
            If CDec(lblLP_IN_adic.Text) > 0 Then
                lblLE_adic.Text = Math.Round((CDec(lblLP_SaldoEfe_adic.Text) / CDec(lblLP_IN_adic.Text)) * 100, 2).ToString("N2") & " %"
            End If
        End If



    End Sub

    Sub calculoDistribuciones()
        Dim calIni, Calns, CalAdic As Decimal
        calIni = Math.Round(CDec(lblDT_saldo_ini.Text) * (nudDTTasa.Value / 100), 2)
        Calns = Math.Round(CDec(lblDT_saldo_ns.Text) * (nudDTTasa.Value / 100), 2)
        CalAdic = Math.Round(CDec(lblDT_saldo_adic.Text) * (nudDTTasa.Value / 100), 2)

        lblDT_ganado_ini.Text = calIni.ToString("N2")
        lblDT_ganado_ns.Text = Calns.ToString("N2")
        lblDT_ganado_adic.Text = CalAdic.ToString("N2")
    End Sub

    Public Sub ObtenerLiquidacion()
        Dim liquidacionSA As New totalesLiquidacionSA
        Dim objLista As List(Of totalesLiquidacion) = Nothing

        If (GModoProyecto = "Aprobado") Then
            objLista = liquidacionSA.GetListaLiquidacionPreliminar(GProyectos.IdProyecto, "AP")
        Else
            objLista = liquidacionSA.GetListaLiquidacionPreliminar(GProyectos.IdProyecto, "A")
        End If

        For Each i In objLista
            Select Case i.tipoLiquidacion
                Case "INGRESOS"
                    lblIB_ini.Text = String.Format("{0:n2}", i.LI_ib_ini) ' i.LI_ib_ini.ToString("N2")
                    lblIB_ns.Text = String.Format("{0:n2}", i.LI_ib_ns) ' i.LI_ib_ns.ToString("N2")
                    lblIB_adic.Text = String.Format("{0:n2}", i.LI_ib_adic) 'i.LI_ib_adic.ToString("N2")
                    '2
                    lblventan_ini.Text = String.Format("{0:n2}", i.LR_ventan_ini) ' i.LR_ventan_ini.ToString("N2")
                    lblventan_ns.Text = String.Format("{0:n2}", i.LR_ventan_ns) 'i.LR_ventan_ns.ToString("N2")
                    lblventan_adic.Text = String.Format("{0:n2}", i.LR_ventan_adic) 'i.LR_ventan_adic.ToString("N2")
                    '3
                    lblLF_Detraccion_ini.Text = 0 ' i.detraccion_ini
                    lblLF_Detraccion_ns.Text = 0 ' i.detraccion_ns
                    lblLF_Detraccion_adic.Text = 0 'i.detraccion_adic
                    '4
                    lblAF_EI_ini.Text = String.Format("{0:n2}", i.AF_EjecucionIng_ini) ' i.AF_EjecucionIng_ini.ToString("N2")
                    lblAF_EI_ns.Text = String.Format("{0:n2}", i.AF_EjecucionIng_ns) ' i.AF_EjecucionIng_ns.ToString("N2")
                    lblAF_EI_adic.Text = String.Format("{0:n2}", i.AF_EjecucionIng_adic) ' i.AF_EjecucionIng_adic.ToString("N2")

                    lblAF_Perc_ini.Text = String.Format("{0:n2}", i.AF_Percepcion_ini) ' i.AF_Percepcion_ini.ToString("N2")
                    lblAF_Perc_ns.Text = String.Format("{0:n2}", i.AF_Percepcion_ns) ' i.AF_Percepcion_ns.ToString("N2")
                    lblAF_Perc_adic.Text = String.Format("{0:n2}", i.AF_Percepcion_adic) 'i.AF_Percepcion_adic.ToString("N2")

                    lblAF_Perc2_ini.Text = String.Format("{0:n2}", i.AF_Percepcion_ini) ' i.AF_Percepcion_ini.ToString("N2")
                    lblAF_Perc2_ns.Text = String.Format("{0:n2}", i.AF_Percepcion_ns) ' i.AF_Percepcion_ns.ToString("N2")
                    lblAF_Perc2_adic.Text = String.Format("{0:n2}", i.AF_Percepcion_adic) ' i.AF_Percepcion_adic.ToString("N2")

                    lblAF_Perc3_ini.Text = String.Format("{0:n2}", i.AF_Percepcion_ini) ' i.AF_Percepcion_ini.ToString("N2")
                    lblAF_Perc3_ns.Text = String.Format("{0:n2}", i.AF_Percepcion_ns) ' i.AF_Percepcion_ns.ToString("N2")
                    lblAF_Perc3_adic.Text = String.Format("{0:n2}", i.AF_Percepcion_adic) ' i.AF_Percepcion_adic.ToString("N2")

                    lblAF_Otrosps_ini.Text = String.Format("{0:n2}", i.AF_Otrosps_ini) ' i.AF_Otrosps_ini.ToString("N2")
                    lblAF_Otrosps_ns.Text = String.Format("{0:n2}", i.AF_Otrosps_ns) ' i.AF_Otrosps_ns.ToString("N2")
                    lblAF_Otrosps_adic.Text = String.Format("{0:n2}", i.AF_Otrosps_adic) 'i.AF_Otrosps_adic.ToString("N2")

                    lblAF_Otrosps2_ini.Text = String.Format("{0:n2}", i.AF_Otrosps_ini) ' i.AF_Otrosps_ini.ToString("N2")
                    lblAF_Otrosps2_ns.Text = String.Format("{0:n2}", i.AF_Otrosps_ns) ' i.AF_Otrosps_ns.ToString("N2")
                    lblAF_Otrosps2_adic.Text = String.Format("{0:n2}", i.AF_Otrosps_adic) ' i.AF_Otrosps_adic.ToString("N2")

                    lblAF_Otrosps3_ini.Text = String.Format("{0:n2}", i.AF_Otrosps_ini) ' i.AF_Otrosps_ini.ToString("N2")
                    lblAF_Otrosps3_ns.Text = String.Format("{0:n2}", i.AF_Otrosps_ns) ' i.AF_Otrosps_ns.ToString("N2")
                    lblAF_Otrosps3_adic.Text = String.Format("{0:n2}", i.AF_Otrosps_adic) ' i.AF_Otrosps_adic.ToString("N2")

                    lblAF_Detra_ini.Text = String.Format("{0:n2}", i.AF_Detraccion_ini) ' i.AF_Detraccion_ini.ToString("N2")
                    lblAF_Detra_ns.Text = String.Format("{0:n2}", i.AF_Detraccion_ns) ' i.AF_Detraccion_ns.ToString("N2")
                    lblAF_Detra_adic.Text = String.Format("{0:n2}", i.AF_Detraccion_adic) ' i.AF_Detraccion_adic.ToString("N2")

                    lblAF_Detra2_ini.Text = String.Format("{0:n2}", i.AF_Detraccion_ini) 'i.AF_Detraccion_ini.ToString("N2")
                    lblAF_Detra2_ns.Text = String.Format("{0:n2}", i.AF_Detraccion_ns) ' i.AF_Detraccion_ns.ToString("N2")
                    lblAF_Detra2_adic.Text = String.Format("{0:n2}", i.AF_Detraccion_adic) ' i.AF_Detraccion_adic.ToString("N2")

                    lblAF_Detra3_ini.Text = String.Format("{0:n2}", i.AF_Detraccion_ini) ' i.AF_Detraccion_ini.ToString("N2")
                    lblAF_Detra3_ns.Text = String.Format("{0:n2}", i.AF_Detraccion_ns) ' i.AF_Detraccion_ns.ToString("N2")
                    lblAF_Detra3_adic.Text = String.Format("{0:n2}", i.AF_Detraccion_adic) 'i.AF_Detraccion_adic.ToString("N2")

                    lblAF_Detra4_ini.Text = String.Format("{0:n2}", i.AF_Detraccion_ini) ' i.AF_Detraccion_ini.ToString("N2")
                    lblAF_Detra4_ns.Text = String.Format("{0:n2}", i.AF_Detraccion_ns) ' i.AF_Detraccion_ns.ToString("N2")
                    lblAF_Detra4_adic.Text = String.Format("{0:n2}", i.AF_Detraccion_adic) ' i.AF_Detraccion_adic.ToString("N2")

                    lblAF_Reten_ini.Text = String.Format("{0:n2}", i.AF_Retencion_ini) ' i.AF_Retencion_ini.ToString("N2")
                    lblAF_Reten_ns.Text = String.Format("{0:n2}", i.AF_Retencion_ns) ' i.AF_Retencion_ns.ToString("N2")
                    lblAF_Reten_adic.Text = String.Format("{0:n2}", i.AF_Retencion_adic) ' i.AF_Retencion_adic.ToString("N2")

                    lblAF_Reten2_ini.Text = String.Format("{0:n2}", i.AF_Retencion_ini) ' i.AF_Retencion_ini.ToString("N2")
                    lblAF_Reten2_ns.Text = String.Format("{0:n2}", i.AF_Retencion_ns) ' i.AF_Retencion_ns.ToString("N2")
                    lblAF_Reten2_adic.Text = String.Format("{0:n2}", i.AF_Retencion_adic) 'i.AF_Retencion_adic.ToString("N2")

                    lblAF_Reten3_ini.Text = String.Format("{0:n2}", i.AF_Retencion_ini) 'i.AF_Retencion_ini.ToString("N2")
                    lblAF_Reten3_ns.Text = String.Format("{0:n2}", i.AF_Retencion_ns) ' i.AF_Retencion_ns.ToString("N2")
                    lblAF_Reten3_adic.Text = String.Format("{0:n2}", i.AF_Retencion_adic) ' i.AF_Retencion_adic.ToString("N2")

                    lblAF_Reten4_ini.Text = String.Format("{0:n2}", i.AF_Retencion_ini) ' i.AF_Retencion_ini.ToString("N2")
                    lblAF_Reten4_ns.Text = String.Format("{0:n2}", i.AF_Retencion_ns) ' i.AF_Retencion_ns.ToString("N2")
                    lblAF_Reten4_adic.Text = String.Format("{0:n2}", i.AF_Retencion_adic) ' i.AF_Retencion_adic.ToString("N2")

                    lblAF_Otrosng_ini.Text = String.Format("{0:n2}", i.AF_Otrosng_ini) ' i.AF_Otrosng_ini.ToString("N2")
                    lblAF_Otrosng_ns.Text = String.Format("{0:n2}", i.AF_Otrosng_ns) ' i.AF_Otrosng_ns.ToString("N2")
                    lblAF_Otrosng_adic.Text = String.Format("{0:n2}", i.AF_Otrosng_adic) ' i.AF_Otrosng_adic.ToString("N2")

                    lblAF_Otrosng2_ini.Text = String.Format("{0:n2}", i.AF_Otrosng_ini) ' i.AF_Otrosng_ini.ToString("N2")
                    lblAF_Otrosng2_ns.Text = String.Format("{0:n2}", i.AF_Otrosng_ns) ' i.AF_Otrosng_ns.ToString("N2")
                    lblAF_Otrosng2_adic.Text = String.Format("{0:n2}", i.AF_Otrosng_adic) ' i.AF_Otrosng_adic.ToString("N2")

                    lblAF_Otrosng3_ini.Text = String.Format("{0:n2}", i.AF_Otrosng_ini) ' i.AF_Otrosng_ini.ToString("N2")
                    lblAF_Otrosng3_ns.Text = String.Format("{0:n2}", i.AF_Otrosng_ns) 'i.AF_Otrosng_ns.ToString("N2")
                    lblAF_Otrosng3_adic.Text = String.Format("{0:n2}", i.AF_Otrosng_adic) ' i.AF_Otrosng_adic.ToString("N2")

                    lblTotalIngresos.Text = String.Format("{0:n2}", i.totalIngresos) ' i.totalIngresos.ToString("N2")
                Case "CADIN" 'LR_inc_ns
                    lblcfAcum_ini.Text = String.Format("{0:n2}", i.LI_cfAcum_ini)
                    lblcfAcum_ns.Text = String.Format("{0:n2}", i.LI_cfAcum_ns) 'i.LI_cfAcum_ns.ToString("N2")
                    lblcfAcum_adic.Text = String.Format("{0:n2}", i.LI_afAcum_adic) 'i.LI_afAcum_adic.ToString("N2")
                    '2
                    lblcostov_ini.Text = String.Format("{0:n2}", i.LR_costov_ini) ' i.LR_costov_ini.ToString("N2")
                    lblcostov_ns.Text = String.Format("{0:n2}", i.LR_costov_ns) ' i.LR_costov_ns.ToString("N2")
                    lblcostov_adic.Text = String.Format("{0:n2}", i.LR_costov_adic) ' i.LR_costov_adic.ToString("N2")
                    lblinc_ns.Text = String.Format("{0:n2}", i.LR_inc_ns) ' i.LR_inc_ns.ToString("N2")
                    lblinc_adic.Text = String.Format("{0:n2}", i.LR_inc_adic) ' i.LR_inc_adic.ToString("N2")
                    '4
                    lblAF_PagoProv_ini.Text = String.Format("{0:n2}", i.AF_TotalPagoProvSust_ini) 'i.AF_TotalPagoProvSust_ini.ToString("N2")
                    lblAF_PagoProv_ns.Text = String.Format("{0:n2}", i.AF_TotalPagoProvSust_ns) 'i.AF_TotalPagoProvSust_ns.ToString("N2")
                    lblAF_PagoProv_adic.Text = String.Format("{0:n2}", i.AF_TotalPagoProvSust_adic) ' i.AF_TotalPagoProvSust_adic.ToString("N2")

                    lblAF_PagoProv2_ini.Text = String.Format("{0:n2}", i.LP_TotalPagoProvCSSust_ini) ' i.LP_TotalPagoProvCSSust_ini.ToString("N2")
                    lblAF_PagoProv2_ns.Text = String.Format("{0:n2}", i.LP_TotalPagoProvCSSust_ns) ' i.LP_TotalPagoProvCSSust_ns.ToString("N2")
                    lblAF_PagoProv2_adic.Text = String.Format("{0:n2}", i.LP_TotalPagoProvCSSust_adic) ' i.LP_TotalPagoProvCSSust_adic.ToString("N2")

                    lblAF_GastoNS_ini.Text = String.Format("{0:n2}", i.AF_RefGastoNoSust_ini) 'i.AF_RefGastoNoSust_ini.ToString("N2")
                    lblAF_GastoNS_ns.Text = String.Format("{0:n2}", i.AF_RefGastoNoSust_ns) 'i.AF_RefGastoNoSust_ns.ToString("N2")
                    lblAF_GastoNS_adic.Text = String.Format("{0:n2}", i.AF_RefGastoNoSust_adic) 'i.AF_RefGastoNoSust_adic.ToString("N2")

                    lblLP_EgresoNS_ns.Text = String.Format("{0:n2}", i.LP_EgresoNoSustentado_ns) 'i.LP_EgresoNoSustentado_ns.ToString("N2")
                    lblLP_EgresoNS_adic.Text = String.Format("{0:n2}", i.LP_EgresoNoSustentado_adic) ' i.LP_EgresoNoSustentado_adic.ToString("N2")

                    lblLP_EgresoIncAdic_adic.Text = String.Format("{0:n2}", i.LP_EgresoInciAdic_adic) ' i.LP_EgresoInciAdic_adic.ToString("N2")

                    LOO_RDA_ini.Value = String.Format("{0:n2}", i.LOO_ReDeAp_ini) ' i.LOO_ReDeAp_ini '.ToString("N2")
                    LOO_RDA_ns.Value = String.Format("{0:n2}", i.LOO_ReDeAp_ns) 'i.LOO_ReDeAp_ns '.ToString("N2")
                    LOO_RDA_adic.Value = String.Format("{0:n2}", i.LOO_ReDeAp_adic) ' i.LOO_ReDeAp_adic '.ToString("N2")

                    LF_RDA_ini.Text = String.Format("{0:n2}", i.LOO_ReDeAp_ini) ' i.LOO_ReDeAp_ini.ToString("N2")
                    LF_RDA_ns.Text = String.Format("{0:n2}", i.LOO_ReDeAp_ns) ' i.LOO_ReDeAp_ns.ToString("N2")
                    LF_RDA_adic.Text = String.Format("{0:n2}", i.LOO_ReDeAp_adic) ' i.LOO_ReDeAp_adic.ToString("N2")

                    If lblTotalIngresos.Text.Trim.Length > 0 Then
                        If CDec(lblTotalIngresos.Text) > 0 Then
                            por3_ini.Text = Math.Round(CDec(LF_RDA_ini.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                            por3_ns.Text = Math.Round(CDec(LF_RDA_ns.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                            por3_adic.Text = Math.Round(CDec(LF_RDA_adic.Text) / CDec(lblTotalIngresos.Text) * 100, 2) & "%"
                        End If
                    End If

                    lblAF_RDA_ini.Text = String.Format("{0:n2}", i.LOO_ReDeAp_ini) ' i.LOO_ReDeAp_ini.ToString("N2")
                    lblAF_RDA_ns.Text = String.Format("{0:n2}", i.LOO_ReDeAp_ns) ' i.LOO_ReDeAp_ns.ToString("N2")
                    lblAF_RDA_adic.Text = String.Format("{0:n2}", i.LOO_ReDeAp_adic) ' i.LOO_ReDeAp_adic.ToString("N2")

                    lblLF_RDA_ini.Text = String.Format("{0:n2}", i.LOO_ReDeAp_ini) 'i.LOO_ReDeAp_ini.ToString("N2")
                    lblLF_RDA_ns.Text = String.Format("{0:n2}", i.LOO_ReDeAp_ns) ' i.LOO_ReDeAp_ns.ToString("N2")
                    lblLF_RDA_adic.Text = String.Format("{0:n2}", i.LOO_ReDeAp_adic) ' i.LOO_ReDeAp_adic.ToString("N2")

            End Select
        Next
    End Sub
#End Region

    Private Sub frmMasterLiquidacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim propiedadListView As System.Reflection.PropertyInfo
        propiedadListView = GetType(TabControl).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
        propiedadListView.SetValue(TabControl1, True, Nothing)

        TabPage1.Parent = TabControl1
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        TabPage6.Parent = Nothing
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        TabPage1.Parent = TabControl1
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        TabPage6.Parent = Nothing
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        TabPage2.Parent = TabControl1
        TabPage1.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        TabPage6.Parent = Nothing
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        TabPage3.Parent = TabControl1
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        TabPage6.Parent = Nothing
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        TabPage4.Parent = TabControl1
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage5.Parent = Nothing
        TabPage6.Parent = Nothing
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        TabPage5.Parent = TabControl1
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage6.Parent = Nothing
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        TabPage6.Parent = TabControl1
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
    End Sub
End Class