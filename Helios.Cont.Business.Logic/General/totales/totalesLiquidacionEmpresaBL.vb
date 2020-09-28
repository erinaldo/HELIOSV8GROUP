Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class totalesLiquidacionEmpresaBL
    Inherits BaseBL

    Public Function Insert(ByVal totalesLiquidacionEmpresaBE As totalesLiquidacionEmpresa) As Integer
        Using ts As New TransactionScope
            HeliosData.totalesLiquidacionEmpresa.Add(totalesLiquidacionEmpresaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return totalesLiquidacionEmpresaBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal totalesLiquidacionEmpresaBE As totalesLiquidacionEmpresa)
        Using ts As New TransactionScope
            Dim totLiquEmp As totalesLiquidacionEmpresa = HeliosData.totalesLiquidacionEmpresa.Where(Function(o) _
                                            o.secuencia = totalesLiquidacionEmpresaBE.secuencia _
                                            And o.idEmpresa = totalesLiquidacionEmpresaBE.idEmpresa _
                                            And o.idEstablecimiento = totalesLiquidacionEmpresaBE.idEstablecimiento _
                                            And o.idProyecto = totalesLiquidacionEmpresaBE.idProyecto _
                                            And o.idEstrategia = totalesLiquidacionEmpresaBE.idEstrategia).First()

            totLiquEmp.Fecha = totalesLiquidacionEmpresaBE.Fecha
            totLiquEmp.LI_ib_ini = totalesLiquidacionEmpresaBE.LI_ib_ini
            totLiquEmp.LI_cfAcum_ini = totalesLiquidacionEmpresaBE.LI_cfAcum_ini
            totLiquEmp.LI_ib_ns = totalesLiquidacionEmpresaBE.LI_ib_ns
            totLiquEmp.LI_cfAcum_ns = totalesLiquidacionEmpresaBE.LI_cfAcum_ns
            totLiquEmp.LI_ib_adic = totalesLiquidacionEmpresaBE.LI_ib_adic
            totLiquEmp.LI_afAcum_adic = totalesLiquidacionEmpresaBE.LI_afAcum_adic
            totLiquEmp.LI_Ajcf_ini = totalesLiquidacionEmpresaBE.LI_Ajcf_ini
            totLiquEmp.LI_Ajcf_ns = totalesLiquidacionEmpresaBE.LI_Ajcf_ns
            totLiquEmp.LI_Ajcf_adic = totalesLiquidacionEmpresaBE.LI_Ajcf_adic
            totLiquEmp.LI_Ajcfng_ini = totalesLiquidacionEmpresaBE.LI_Ajcfng_ini
            totLiquEmp.LI_Ajcfng_ns = totalesLiquidacionEmpresaBE.LI_Ajcfng_ns
            totLiquEmp.LI_Ajcfng_adic = totalesLiquidacionEmpresaBE.LI_Ajcfng_adic
            totLiquEmp.LI_IgvPorPagar_ini = totalesLiquidacionEmpresaBE.LI_IgvPorPagar_ini
            totLiquEmp.LI_IgvPorPagar_ns = totalesLiquidacionEmpresaBE.LI_IgvPorPagar_ns
            totLiquEmp.LI_IgvPorPagar_adic = totalesLiquidacionEmpresaBE.LI_IgvPorPagar_adic
            totLiquEmp.LR_ventan_ini = totalesLiquidacionEmpresaBE.LR_ventan_ini
            totLiquEmp.LR_costov_ini = totalesLiquidacionEmpresaBE.LR_costov_ini
            totLiquEmp.LR_ventan_ns = totalesLiquidacionEmpresaBE.LR_ventan_ns
            totLiquEmp.LR_costov_ns = totalesLiquidacionEmpresaBE.LR_costov_ns
            totLiquEmp.LR_inc_ns = totalesLiquidacionEmpresaBE.LR_inc_ns
            totLiquEmp.LR_ventan_adic = totalesLiquidacionEmpresaBE.LR_ventan_adic
            totLiquEmp.LR_costov_adic = totalesLiquidacionEmpresaBE.LR_costov_adic
            totLiquEmp.LR_inc_adic = totalesLiquidacionEmpresaBE.LR_inc_adic
            totLiquEmp.LRVentasNetas_ini = totalesLiquidacionEmpresaBE.LRVentasNetas_ini
            totLiquEmp.LRVentasNetas_ns = totalesLiquidacionEmpresaBE.LRVentasNetas_ns
            totLiquEmp.LRVentasNetas_adic = totalesLiquidacionEmpresaBE.LRVentasNetas_adic
            totLiquEmp.LRDscto_ini = totalesLiquidacionEmpresaBE.LRDscto_ini
            totLiquEmp.LRDscto_ns = totalesLiquidacionEmpresaBE.LRDscto_ns
            totLiquEmp.LRDscto_adic = totalesLiquidacionEmpresaBE.LRDscto_adic
            totLiquEmp.LRAjusteCostops_ini = totalesLiquidacionEmpresaBE.LRAjusteCostops_ini
            totLiquEmp.LRAjusteCostops_ns = totalesLiquidacionEmpresaBE.LRAjusteCostops_ns
            totLiquEmp.LRAjusteCostops_adic = totalesLiquidacionEmpresaBE.LRAjusteCostops_adic
            totLiquEmp.LRAjusteCostong_ini = totalesLiquidacionEmpresaBE.LRAjusteCostong_ini
            totLiquEmp.LRAjusteCostong_ns = totalesLiquidacionEmpresaBE.LRAjusteCostong_ns
            totLiquEmp.LRAjusteCostong_adic = totalesLiquidacionEmpresaBE.LRAjusteCostong_adic
            totLiquEmp.LRRB_ini = totalesLiquidacionEmpresaBE.LRRB_ini
            totLiquEmp.LRRB_ns = totalesLiquidacionEmpresaBE.LRRB_ns
            totLiquEmp.LRRB_adic = totalesLiquidacionEmpresaBE.LRRB_adic
            totLiquEmp.LRRB_inc_ini = totalesLiquidacionEmpresaBE.LRRB_inc_ini
            totLiquEmp.LRRB_inc_ns = totalesLiquidacionEmpresaBE.LRRB_inc_ns
            totLiquEmp.LRRB_inc_adic = totalesLiquidacionEmpresaBE.LRRB_inc_adic
            totLiquEmp.LRParUtil_ini = totalesLiquidacionEmpresaBE.LRParUtil_ini
            totLiquEmp.LRParUtil_ns = totalesLiquidacionEmpresaBE.LRParUtil_ns
            totLiquEmp.LRParUtil_adic = totalesLiquidacionEmpresaBE.LRParUtil_adic
            totLiquEmp.LRIF_ini = totalesLiquidacionEmpresaBE.LRIF_ini
            totLiquEmp.LRIF_ns = totalesLiquidacionEmpresaBE.LRIF_ns
            totLiquEmp.LRIF_adic = totalesLiquidacionEmpresaBE.LRIF_adic
            totLiquEmp.LROI_ini = totalesLiquidacionEmpresaBE.LROI_ini
            totLiquEmp.LROI_ns = totalesLiquidacionEmpresaBE.LROI_ns
            totLiquEmp.LROI_adic = totalesLiquidacionEmpresaBE.LROI_adic
            totLiquEmp.LRPorcDLR = totalesLiquidacionEmpresaBE.LRPorcDLR
            totLiquEmp.LRDLR_ini = totalesLiquidacionEmpresaBE.LRDLR_ini
            totLiquEmp.LRDLR_ns = totalesLiquidacionEmpresaBE.LRDLR_ns
            totLiquEmp.LRDLR_adic = totalesLiquidacionEmpresaBE.LRDLR_adic
            totLiquEmp.LRPorcRenta = totalesLiquidacionEmpresaBE.LRPorcRenta
            totLiquEmp.LRResulImpuesto_ini = totalesLiquidacionEmpresaBE.LRResulImpuesto_ini
            totLiquEmp.LRResulImpuesto_ns = totalesLiquidacionEmpresaBE.LRResulImpuesto_ns
            totLiquEmp.LRResulImpuesto_adic = totalesLiquidacionEmpresaBE.LRResulImpuesto_adic
            totLiquEmp.LRIRenta_ini = totalesLiquidacionEmpresaBE.LRIRenta_ini
            totLiquEmp.LRIRenta_ns = totalesLiquidacionEmpresaBE.LRIRenta_ns
            totLiquEmp.LRIRenta_adic = totalesLiquidacionEmpresaBE.LRIRenta_adic
            totLiquEmp.LRRE_ini = totalesLiquidacionEmpresaBE.LRRE_ini
            totLiquEmp.LRRE_ns = totalesLiquidacionEmpresaBE.LRRE_ns
            totLiquEmp.LRRE_adic = totalesLiquidacionEmpresaBE.LRRE_adic
            totLiquEmp.LRPorcPago = totalesLiquidacionEmpresaBE.LRPorcPago
            totLiquEmp.LRPagoCta_ini = totalesLiquidacionEmpresaBE.LRPagoCta_ini
            totLiquEmp.LRPagoCta_ns = totalesLiquidacionEmpresaBE.LRPagoCta_ns
            totLiquEmp.LRPagoCta_adic = totalesLiquidacionEmpresaBE.LRPagoCta_adic
            totLiquEmp.LRImpReg_ini = totalesLiquidacionEmpresaBE.LRImpReg_ini
            totLiquEmp.LRImpReg_ns = totalesLiquidacionEmpresaBE.LRImpReg_ns
            totLiquEmp.LRImpReg_adic = totalesLiquidacionEmpresaBE.LRImpReg_adic
            totLiquEmp.LRCoePago_ini = totalesLiquidacionEmpresaBE.LRCoePago_ini
            totLiquEmp.LRCoePago_ns = totalesLiquidacionEmpresaBE.LRCoePago_ns
            totLiquEmp.LRCoePago_adic = totalesLiquidacionEmpresaBE.LRCoePago_adic
            totLiquEmp.LOO_ReDeAp_ini = totalesLiquidacionEmpresaBE.LOO_ReDeAp_ini
            totLiquEmp.LOO_ReDeAp_ns = totalesLiquidacionEmpresaBE.LOO_ReDeAp_ns
            totLiquEmp.LOO_ReDeAp_adic = totalesLiquidacionEmpresaBE.LOO_ReDeAp_adic
            totLiquEmp.LF_Igv_ini = totalesLiquidacionEmpresaBE.LF_Igv_ini
            totLiquEmp.LF_Igv_ns = totalesLiquidacionEmpresaBE.LF_Igv_ns
            totLiquEmp.LF_Igv_adic = totalesLiquidacionEmpresaBE.LF_Igv_adic
            totLiquEmp.LF_Renta_ini = totalesLiquidacionEmpresaBE.LF_Renta_ini
            totLiquEmp.LF_Renta_ns = totalesLiquidacionEmpresaBE.LF_Renta_ns
            totLiquEmp.LF_Renta_adic = totalesLiquidacionEmpresaBE.LF_Renta_adic
            totLiquEmp.LF_RDA_ini = totalesLiquidacionEmpresaBE.LF_RDA_ini
            totLiquEmp.LF_RDA_ns = totalesLiquidacionEmpresaBE.LF_RDA_ns
            totLiquEmp.LF_RDA_adic = totalesLiquidacionEmpresaBE.LF_RDA_adic
            totLiquEmp.LF_Total_ini = totalesLiquidacionEmpresaBE.LF_Total_ini
            totLiquEmp.LF_Total_ns = totalesLiquidacionEmpresaBE.LF_Total_ns
            totLiquEmp.LF_Total_adic = totalesLiquidacionEmpresaBE.LF_Total_adic
            totLiquEmp.LF_OtrosGastos_ini = totalesLiquidacionEmpresaBE.LF_OtrosGastos_ini
            totLiquEmp.LF_OtrosGastos_ns = totalesLiquidacionEmpresaBE.LF_OtrosGastos_ns
            totLiquEmp.LF_OtrosGastos_adic = totalesLiquidacionEmpresaBE.LF_OtrosGastos_adic
            totLiquEmp.LF_TotalObligacion_ini = totalesLiquidacionEmpresaBE.LF_TotalObligacion_ini
            totLiquEmp.LF_TotalObligacion_ns = totalesLiquidacionEmpresaBE.LF_TotalObligacion_ns
            totLiquEmp.LF_TotalObligacion_adic = totalesLiquidacionEmpresaBE.LF_TotalObligacion_adic
            totLiquEmp.detraccion_ini = totalesLiquidacionEmpresaBE.detraccion_ini
            totLiquEmp.detraccion_ns = totalesLiquidacionEmpresaBE.detraccion_ns
            totLiquEmp.detraccion_adic = totalesLiquidacionEmpresaBE.detraccion_adic
            totLiquEmp.LF_TO_ini = totalesLiquidacionEmpresaBE.LF_TO_ini
            totLiquEmp.LF_TO_ns = totalesLiquidacionEmpresaBE.LF_TO_ns
            totLiquEmp.LF_TO_adic = totalesLiquidacionEmpresaBE.LF_TO_adic
            totLiquEmp.LFPorcRetUti = totalesLiquidacionEmpresaBE.LFPorcRetUti
            totLiquEmp.LF_RetUti_ini = totalesLiquidacionEmpresaBE.LF_RetUti_ini
            totLiquEmp.LF_RetUti_ns = totalesLiquidacionEmpresaBE.LF_RetUti_ns
            totLiquEmp.LF_RetUti_adic = totalesLiquidacionEmpresaBE.LF_RetUti_adic
            totLiquEmp.LF_ini = totalesLiquidacionEmpresaBE.LF_ini
            totLiquEmp.LF_ns = totalesLiquidacionEmpresaBE.LF_ns
            totLiquEmp.LF_adic = totalesLiquidacionEmpresaBE.LF_adic
            totLiquEmp.AF_IngNeto_ini = totalesLiquidacionEmpresaBE.AF_IngNeto_ini
            totLiquEmp.AF_IngNeto_ns = totalesLiquidacionEmpresaBE.AF_IngNeto_ns
            totLiquEmp.AF_IngNeto_adic = totalesLiquidacionEmpresaBE.AF_IngNeto_adic
            totLiquEmp.AF_EjecucionIng_ini = totalesLiquidacionEmpresaBE.AF_EjecucionIng_ini
            totLiquEmp.AF_EjecucionIng_ns = totalesLiquidacionEmpresaBE.AF_EjecucionIng_ns
            totLiquEmp.AF_EjecucionIng_adic = totalesLiquidacionEmpresaBE.AF_EjecucionIng_adic
            totLiquEmp.AF_Percepcion_ini = totalesLiquidacionEmpresaBE.AF_Percepcion_ini
            totLiquEmp.AF_Percepcion_ns = totalesLiquidacionEmpresaBE.AF_Percepcion_ns
            totLiquEmp.AF_Percepcion_adic = totalesLiquidacionEmpresaBE.AF_Percepcion_adic
            totLiquEmp.AF_Otrosps_ini = totalesLiquidacionEmpresaBE.AF_Otrosps_ini
            totLiquEmp.AF_Otrosps_ns = totalesLiquidacionEmpresaBE.AF_Otrosps_ns
            totLiquEmp.AF_Otrosps_adic = totalesLiquidacionEmpresaBE.AF_Otrosps_adic
            totLiquEmp.AF_Detraccion_ini = totalesLiquidacionEmpresaBE.AF_Detraccion_ini
            totLiquEmp.AF_Detraccion_ns = totalesLiquidacionEmpresaBE.AF_Detraccion_ns
            totLiquEmp.AF_Detraccion_adic = totalesLiquidacionEmpresaBE.AF_Detraccion_adic
            totLiquEmp.AF_Retencion_ini = totalesLiquidacionEmpresaBE.AF_Retencion_ini
            totLiquEmp.AF_Retencion_ns = totalesLiquidacionEmpresaBE.AF_Retencion_ns
            totLiquEmp.AF_Retencion_adic = totalesLiquidacionEmpresaBE.AF_Retencion_adic
            totLiquEmp.AF_Otrosng_ini = totalesLiquidacionEmpresaBE.AF_Otrosng_ini
            totLiquEmp.AF_Otrosng_ns = totalesLiquidacionEmpresaBE.AF_Otrosng_ns
            totLiquEmp.AF_Otrosng_adic = totalesLiquidacionEmpresaBE.AF_Otrosng_adic
            totLiquEmp.AF_TotalPagoProvSust_ini = totalesLiquidacionEmpresaBE.AF_TotalPagoProvSust_ini
            totLiquEmp.AF_TotalPagoProvSust_ns = totalesLiquidacionEmpresaBE.AF_TotalPagoProvSust_ns
            totLiquEmp.AF_TotalPagoProvSust_adic = totalesLiquidacionEmpresaBE.AF_TotalPagoProvSust_adic
            totLiquEmp.AF_RefGastoNoSust_ini = totalesLiquidacionEmpresaBE.AF_RefGastoNoSust_ini
            totLiquEmp.AF_RefGastoNoSust_ns = totalesLiquidacionEmpresaBE.AF_RefGastoNoSust_ns
            totLiquEmp.AF_RefGastoNoSust_adic = totalesLiquidacionEmpresaBE.AF_RefGastoNoSust_adic
            totLiquEmp.AF_SaldoEF_ini = totalesLiquidacionEmpresaBE.AF_SaldoEF_ini
            totLiquEmp.AF_SaldoEF_ns = totalesLiquidacionEmpresaBE.AF_SaldoEF_ns
            totLiquEmp.AF_SaldoEF_adic = totalesLiquidacionEmpresaBE.AF_SaldoEF_adic
            totLiquEmp.AF_Igv_ini = totalesLiquidacionEmpresaBE.AF_Igv_ini
            totLiquEmp.AF_Igv_ns = totalesLiquidacionEmpresaBE.AF_Igv_ns
            totLiquEmp.AF_Igv_adic = totalesLiquidacionEmpresaBE.AF_Igv_adic
            totLiquEmp.AF_Renta_ini = totalesLiquidacionEmpresaBE.AF_Renta_ini
            totLiquEmp.AF_Renta_ns = totalesLiquidacionEmpresaBE.AF_Renta_ns
            totLiquEmp.AF_Renta_adic = totalesLiquidacionEmpresaBE.AF_Renta_adic
            totLiquEmp.AF_RDA_ini = totalesLiquidacionEmpresaBE.AF_RDA_ini
            totLiquEmp.AF_RDA_ns = totalesLiquidacionEmpresaBE.AF_RDA_ns
            totLiquEmp.AF_RDA_adic = totalesLiquidacionEmpresaBE.AF_RDA_adic
            totLiquEmp.AF_OtrosPagos_ini = totalesLiquidacionEmpresaBE.AF_OtrosPagos_ini
            totLiquEmp.AF_OtrosPagos_ns = totalesLiquidacionEmpresaBE.AF_OtrosPagos_ns
            totLiquEmp.AF_OtrosPagos_adic = totalesLiquidacionEmpresaBE.AF_OtrosPagos_adic
            totLiquEmp.AF_TotalPagoOT_ini = totalesLiquidacionEmpresaBE.AF_TotalPagoOT_ini
            totLiquEmp.AF_TotalPagoOT_ns = totalesLiquidacionEmpresaBE.AF_TotalPagoOT_ns
            totLiquEmp.AF_TotalPagoOT_adic = totalesLiquidacionEmpresaBE.AF_TotalPagoOT_adic
            totLiquEmp.AF_SaldoFinal_ini = totalesLiquidacionEmpresaBE.AF_SaldoFinal_ini
            totLiquEmp.AF_SaldoFinal_ns = totalesLiquidacionEmpresaBE.AF_SaldoFinal_ns
            totLiquEmp.AF_SaldoFinal_adic = totalesLiquidacionEmpresaBE.AF_SaldoFinal_adic
            totLiquEmp.AF_AjusteCF_ini = totalesLiquidacionEmpresaBE.AF_AjusteCF_ini
            totLiquEmp.AF_AjusteCF_ns = totalesLiquidacionEmpresaBE.AF_AjusteCF_ns
            totLiquEmp.AF_AjusteCF_adic = totalesLiquidacionEmpresaBE.AF_AjusteCF_adic
            totLiquEmp.AF_AjusteCFng_ini = totalesLiquidacionEmpresaBE.AF_AjusteCFng_ini
            totLiquEmp.AF_AjusteCFng_ns = totalesLiquidacionEmpresaBE.AF_AjusteCFng_ns
            totLiquEmp.AF_AjusteCFng_adic = totalesLiquidacionEmpresaBE.AF_AjusteCFng_adic
            totLiquEmp.AF_AjPerc_ini = totalesLiquidacionEmpresaBE.AF_AjPerc_ini
            totLiquEmp.AF_AjPerc_ns = totalesLiquidacionEmpresaBE.AF_AjPerc_ns
            totLiquEmp.AF_AjPerc_adic = totalesLiquidacionEmpresaBE.AF_AjPerc_adic
            totLiquEmp.AF_AjOtros1_ini = totalesLiquidacionEmpresaBE.AF_AjOtros1_ini
            totLiquEmp.AF_AjOtros1_ns = totalesLiquidacionEmpresaBE.AF_AjOtros1_ns
            totLiquEmp.AF_AjOtros1_adic = totalesLiquidacionEmpresaBE.AF_AjOtros1_adic
            totLiquEmp.AF_AjDetra_ini = totalesLiquidacionEmpresaBE.AF_AjDetra_ini
            totLiquEmp.AF_AjDetra_ns = totalesLiquidacionEmpresaBE.AF_AjDetra_ns
            totLiquEmp.AF_AjDetra_adic = totalesLiquidacionEmpresaBE.AF_AjDetra_adic
            totLiquEmp.AF_AjReten_ini = totalesLiquidacionEmpresaBE.AF_AjReten_ini
            totLiquEmp.AF_AjReten_ns = totalesLiquidacionEmpresaBE.AF_AjReten_ns
            totLiquEmp.AF_AjReten_adic = totalesLiquidacionEmpresaBE.AF_AjReten_adic
            totLiquEmp.AF_AjOtros2_ini = totalesLiquidacionEmpresaBE.AF_AjOtros2_ini
            totLiquEmp.AF_AjOtros2_ns = totalesLiquidacionEmpresaBE.AF_AjOtros2_ns
            totLiquEmp.AF_AjOtros2_adic = totalesLiquidacionEmpresaBE.AF_AjOtros2_adic
            totLiquEmp.AF_AjRentaps_ini = totalesLiquidacionEmpresaBE.AF_AjRentaps_ini
            totLiquEmp.AF_AjRentaps_ns = totalesLiquidacionEmpresaBE.AF_AjRentaps_ns
            totLiquEmp.AF_AjRentaps_adic = totalesLiquidacionEmpresaBE.AF_AjRentaps_adic
            totLiquEmp.AF_AjRentang_ini = totalesLiquidacionEmpresaBE.AF_AjRentang_ini
            totLiquEmp.AF_AjRentang_ns = totalesLiquidacionEmpresaBE.AF_AjRentang_ns
            totLiquEmp.AF_AjRentang_adic = totalesLiquidacionEmpresaBE.AF_AjRentang_adic
            totLiquEmp.AF_SaldoFinalC_ini = totalesLiquidacionEmpresaBE.AF_SaldoFinalC_ini
            totLiquEmp.AF_SaldoFinalC_ns = totalesLiquidacionEmpresaBE.AF_SaldoFinalC_ns
            totLiquEmp.AF_SaldoFinalC_adic = totalesLiquidacionEmpresaBE.AF_SaldoFinalC_adic
            totLiquEmp.AF_Validador_ini = totalesLiquidacionEmpresaBE.AF_Validador_ini
            totLiquEmp.AF_Validador_ns = totalesLiquidacionEmpresaBE.AF_Validador_ns
            totLiquEmp.AF_Validador_adic = totalesLiquidacionEmpresaBE.AF_Validador_adic
            totLiquEmp.LP_IN_ini = totalesLiquidacionEmpresaBE.LP_IN_ini
            totLiquEmp.LP_IN_ns = totalesLiquidacionEmpresaBE.LP_IN_ns
            totLiquEmp.LP_IN_adic = totalesLiquidacionEmpresaBE.LP_IN_adic
            totLiquEmp.LP_IngProy_ini = totalesLiquidacionEmpresaBE.LP_IngProy_ini
            totLiquEmp.LP_IngProy_ns = totalesLiquidacionEmpresaBE.LP_IngProy_ns
            totLiquEmp.LP_IngProy_adic = totalesLiquidacionEmpresaBE.LP_IngProy_adic
            totLiquEmp.LP_Percep_ini = totalesLiquidacionEmpresaBE.LP_Percep_ini
            totLiquEmp.LP_Percep_ns = totalesLiquidacionEmpresaBE.LP_Percep_ns
            totLiquEmp.LP_Percep_adic = totalesLiquidacionEmpresaBE.LP_Percep_adic
            totLiquEmp.LP_Otros1_ini = totalesLiquidacionEmpresaBE.LP_Otros1_ini
            totLiquEmp.LP_Otros1_ns = totalesLiquidacionEmpresaBE.LP_Otros1_ns
            totLiquEmp.LP_Otros1_adic = totalesLiquidacionEmpresaBE.LP_Otros1_adic
            totLiquEmp.LP_Detra_ini = totalesLiquidacionEmpresaBE.LP_Detra_ini
            totLiquEmp.LP_Detra_ns = totalesLiquidacionEmpresaBE.LP_Detra_ns
            totLiquEmp.LP_Detra_adic = totalesLiquidacionEmpresaBE.LP_Detra_adic
            totLiquEmp.LP_Reten_ini = totalesLiquidacionEmpresaBE.LP_Reten_ini
            totLiquEmp.LP_Reten_ns = totalesLiquidacionEmpresaBE.LP_Reten_ns
            totLiquEmp.LP_Reten_adic = totalesLiquidacionEmpresaBE.LP_Reten_adic
            totLiquEmp.LP_Otros2_ini = totalesLiquidacionEmpresaBE.LP_Otros2_ini
            totLiquEmp.LP_Otros2_ns = totalesLiquidacionEmpresaBE.LP_Otros2_ns
            totLiquEmp.LP_Otros2_adic = totalesLiquidacionEmpresaBE.LP_Otros2_adic
            totLiquEmp.LP_Egreso_ini = totalesLiquidacionEmpresaBE.LP_Egreso_ini
            totLiquEmp.LP_Egreso_ns = totalesLiquidacionEmpresaBE.LP_Egreso_ns
            totLiquEmp.LP_Egreso_adic = totalesLiquidacionEmpresaBE.LP_Egreso_adic
            totLiquEmp.LP_PagoProv_ini = totalesLiquidacionEmpresaBE.LP_PagoProv_ini
            totLiquEmp.LP_PagoProv_ns = totalesLiquidacionEmpresaBE.LP_PagoProv_ns
            totLiquEmp.LP_PagoProv_adic = totalesLiquidacionEmpresaBE.LP_PagoProv_adic
            totLiquEmp.LP_EgresoNoSustentado_ns = totalesLiquidacionEmpresaBE.LP_EgresoNoSustentado_ns
            totLiquEmp.LP_EgresoNoSustentado_adic = totalesLiquidacionEmpresaBE.LP_EgresoNoSustentado_adic
            totLiquEmp.LP_EgresoInciAdic_adic = totalesLiquidacionEmpresaBE.LP_EgresoInciAdic_adic
            totLiquEmp.LP_ResTributo_ini = totalesLiquidacionEmpresaBE.LP_ResTributo_ini
            totLiquEmp.LP_ResTributo_ns = totalesLiquidacionEmpresaBE.LP_ResTributo_ns
            totLiquEmp.LP_ResTributo_adic = totalesLiquidacionEmpresaBE.LP_ResTributo_adic
            totLiquEmp.LP_Tributo_ini = totalesLiquidacionEmpresaBE.LP_Tributo_ini
            totLiquEmp.LP_Tributo_ns = totalesLiquidacionEmpresaBE.LP_Tributo_ns
            totLiquEmp.LP_Tributo_adic = totalesLiquidacionEmpresaBE.LP_Tributo_adic
            totLiquEmp.LP_Igv_ini = totalesLiquidacionEmpresaBE.LP_Igv_ini
            totLiquEmp.LP_Igv_ns = totalesLiquidacionEmpresaBE.LP_Igv_ns
            totLiquEmp.LP_Igv_adic = totalesLiquidacionEmpresaBE.LP_Igv_adic
            totLiquEmp.LP_Renta_ini = totalesLiquidacionEmpresaBE.LP_Renta_ini
            totLiquEmp.LP_Renta_ns = totalesLiquidacionEmpresaBE.LP_Renta_ns
            totLiquEmp.LP_Renta_adic = totalesLiquidacionEmpresaBE.LP_Renta_adic
            totLiquEmp.LP_RDA_ini = totalesLiquidacionEmpresaBE.LP_RDA_ini
            totLiquEmp.LP_RDA_ns = totalesLiquidacionEmpresaBE.LP_RDA_ns
            totLiquEmp.LP_RDA_adic = totalesLiquidacionEmpresaBE.LP_RDA_adic
            totLiquEmp.LP_RetUti_ini = totalesLiquidacionEmpresaBE.LP_RetUti_ini
            totLiquEmp.LP_RetUti_ns = totalesLiquidacionEmpresaBE.LP_RetUti_ns
            totLiquEmp.LP_RetUti_adic = totalesLiquidacionEmpresaBE.LP_RetUti_adic
            totLiquEmp.LP_OtrodsPagos_ini = totalesLiquidacionEmpresaBE.LP_OtrodsPagos_ini
            totLiquEmp.LP_OtrodsPagos_ns = totalesLiquidacionEmpresaBE.LP_OtrodsPagos_ns
            totLiquEmp.LP_OtrodsPagos_adic = totalesLiquidacionEmpresaBE.LP_OtrodsPagos_adic
            totLiquEmp.LP_SaldoEfe_ini = totalesLiquidacionEmpresaBE.LP_SaldoEfe_ini
            totLiquEmp.LP_SaldoEfe_ns = totalesLiquidacionEmpresaBE.LP_SaldoEfe_ns
            totLiquEmp.LP_SaldoEfe_adic = totalesLiquidacionEmpresaBE.LP_SaldoEfe_adic
            totLiquEmp.totalIngreso = totalesLiquidacionEmpresaBE.totalIngreso
            totLiquEmp.obsLiquiIgv = totalesLiquidacionEmpresaBE.obsLiquiIgv
            totLiquEmp.obsLiquiRenta = totalesLiquidacionEmpresaBE.obsLiquiRenta
            totLiquEmp.obsLiquiLoo = totalesLiquidacionEmpresaBE.obsLiquiLoo
            totLiquEmp.obsLiquiAnalisis = totalesLiquidacionEmpresaBE.obsLiquiAnalisis
            totLiquEmp.obsLiquiEventoProyecto = totalesLiquidacionEmpresaBE.obsLiquiEventoProyecto
            totLiquEmp.DT_ini = totalesLiquidacionEmpresaBE.DT_ini
            totLiquEmp.DT_ns = totalesLiquidacionEmpresaBE.DT_ns
            totLiquEmp.DT_adic = totalesLiquidacionEmpresaBE.DT_adic
            totLiquEmp.DT_OI_ini = totalesLiquidacionEmpresaBE.DT_OI_ini
            totLiquEmp.DT_OI_ns = totalesLiquidacionEmpresaBE.DT_OI_ns
            totLiquEmp.DT_OI_adic = totalesLiquidacionEmpresaBE.DT_OI_adic
            totLiquEmp.DT_OE_ini = totalesLiquidacionEmpresaBE.DT_OE_ini
            totLiquEmp.DT_OE_ns = totalesLiquidacionEmpresaBE.DT_OE_ns
            totLiquEmp.DT_OE_adic = totalesLiquidacionEmpresaBE.DT_OE_adic
            totLiquEmp.DT_saldo_ini = totalesLiquidacionEmpresaBE.DT_saldo_ini
            totLiquEmp.DT_saldo_ns = totalesLiquidacionEmpresaBE.DT_saldo_ns
            totLiquEmp.DT_saldo_adic = totalesLiquidacionEmpresaBE.DT_saldo_adic
            totLiquEmp.TipoPlan = totalesLiquidacionEmpresaBE.TipoPlan
            totLiquEmp.tipoReporte = totalesLiquidacionEmpresaBE.tipoReporte
            totLiquEmp.usuarioActualizacion = totalesLiquidacionEmpresaBE.usuarioActualizacion
            totLiquEmp.fechaActualizacion = totalesLiquidacionEmpresaBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(totLiquEmp).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal totalesLiquidacionEmpresaBE As totalesLiquidacionEmpresa)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(totalesLiquidacionEmpresaBE)
    End Sub

    Public Function GetListar_totalesLiquidacionEmpresa() As List(Of totalesLiquidacionEmpresa)
        Return (From a In HeliosData.totalesLiquidacionEmpresa Select a).ToList
    End Function

    Public Function GetUbicar_totalesLiquidacionEmpresaPorID(Secuencia As Integer) As totalesLiquidacionEmpresa
        Return (From a In HeliosData.totalesLiquidacionEmpresa
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class
