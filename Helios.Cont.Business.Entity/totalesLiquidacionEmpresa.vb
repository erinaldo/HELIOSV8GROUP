'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class totalesLiquidacionEmpresa
    Public Property secuencia As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Integer
    Public Property idProyecto As Integer
    Public Property idEstrategia As Integer
    Public Property Fecha As Nullable(Of Date)
    Public Property LI_ib_ini As Nullable(Of Decimal)
    Public Property LI_cfAcum_ini As Nullable(Of Decimal)
    Public Property LI_ib_ns As Nullable(Of Decimal)
    Public Property LI_cfAcum_ns As Nullable(Of Decimal)
    Public Property LI_ib_adic As Nullable(Of Decimal)
    Public Property LI_afAcum_adic As Nullable(Of Decimal)
    Public Property LI_Ajcf_ini As Nullable(Of Decimal)
    Public Property LI_Ajcf_ns As Nullable(Of Decimal)
    Public Property LI_Ajcf_adic As Nullable(Of Decimal)
    Public Property LI_Ajcfng_ini As Nullable(Of Decimal)
    Public Property LI_Ajcfng_ns As Nullable(Of Decimal)
    Public Property LI_Ajcfng_adic As Nullable(Of Decimal)
    Public Property LI_IgvPorPagar_ini As Nullable(Of Decimal)
    Public Property LI_IgvPorPagar_ns As Nullable(Of Decimal)
    Public Property LI_IgvPorPagar_adic As Nullable(Of Decimal)
    Public Property LR_ventan_ini As Nullable(Of Decimal)
    Public Property LR_costov_ini As Nullable(Of Decimal)
    Public Property LR_ventan_ns As Nullable(Of Decimal)
    Public Property LR_costov_ns As Nullable(Of Decimal)
    Public Property LR_inc_ns As Nullable(Of Decimal)
    Public Property LR_ventan_adic As Nullable(Of Decimal)
    Public Property LR_costov_adic As Nullable(Of Decimal)
    Public Property LR_inc_adic As Nullable(Of Decimal)
    Public Property LRVentasNetas_ini As Nullable(Of Decimal)
    Public Property LRVentasNetas_ns As Nullable(Of Decimal)
    Public Property LRVentasNetas_adic As Nullable(Of Decimal)
    Public Property LRDscto_ini As Nullable(Of Decimal)
    Public Property LRDscto_ns As Nullable(Of Decimal)
    Public Property LRDscto_adic As Nullable(Of Decimal)
    Public Property LRAjusteCostops_ini As Nullable(Of Decimal)
    Public Property LRAjusteCostops_ns As Nullable(Of Decimal)
    Public Property LRAjusteCostops_adic As Nullable(Of Decimal)
    Public Property LRAjusteCostong_ini As Nullable(Of Decimal)
    Public Property LRAjusteCostong_ns As Nullable(Of Decimal)
    Public Property LRAjusteCostong_adic As Nullable(Of Decimal)
    Public Property LRRB_ini As Nullable(Of Decimal)
    Public Property LRRB_ns As Nullable(Of Decimal)
    Public Property LRRB_adic As Nullable(Of Decimal)
    Public Property LRRB_inc_ini As Nullable(Of Decimal)
    Public Property LRRB_inc_ns As Nullable(Of Decimal)
    Public Property LRRB_inc_adic As Nullable(Of Decimal)
    Public Property LRParUtil_ini As String
    Public Property LRParUtil_ns As String
    Public Property LRParUtil_adic As String
    Public Property LRIF_ini As Nullable(Of Decimal)
    Public Property LRIF_ns As Nullable(Of Decimal)
    Public Property LRIF_adic As Nullable(Of Decimal)
    Public Property LROI_ini As Nullable(Of Decimal)
    Public Property LROI_ns As Nullable(Of Decimal)
    Public Property LROI_adic As Nullable(Of Decimal)
    Public Property LRPorcDLR As Nullable(Of Decimal)
    Public Property LRDLR_ini As Nullable(Of Decimal)
    Public Property LRDLR_ns As Nullable(Of Decimal)
    Public Property LRDLR_adic As Nullable(Of Decimal)
    Public Property LRPorcRenta As Nullable(Of Decimal)
    Public Property LRResulImpuesto_ini As Nullable(Of Decimal)
    Public Property LRResulImpuesto_ns As Nullable(Of Decimal)
    Public Property LRResulImpuesto_adic As Nullable(Of Decimal)
    Public Property LRIRenta_ini As Nullable(Of Decimal)
    Public Property LRIRenta_ns As Nullable(Of Decimal)
    Public Property LRIRenta_adic As Nullable(Of Decimal)
    Public Property LRRE_ini As Nullable(Of Decimal)
    Public Property LRRE_ns As Nullable(Of Decimal)
    Public Property LRRE_adic As Nullable(Of Decimal)
    Public Property LRPorcPago As Nullable(Of Decimal)
    Public Property LRPagoCta_ini As Nullable(Of Decimal)
    Public Property LRPagoCta_ns As Nullable(Of Decimal)
    Public Property LRPagoCta_adic As Nullable(Of Decimal)
    Public Property LRImpReg_ini As Nullable(Of Decimal)
    Public Property LRImpReg_ns As Nullable(Of Decimal)
    Public Property LRImpReg_adic As Nullable(Of Decimal)
    Public Property LRCoePago_ini As Nullable(Of Decimal)
    Public Property LRCoePago_ns As Nullable(Of Decimal)
    Public Property LRCoePago_adic As Nullable(Of Decimal)
    Public Property LOO_ReDeAp_ini As Nullable(Of Decimal)
    Public Property LOO_ReDeAp_ns As Nullable(Of Decimal)
    Public Property LOO_ReDeAp_adic As Nullable(Of Decimal)
    Public Property LF_Igv_ini As Nullable(Of Decimal)
    Public Property LF_Igv_ns As Nullable(Of Decimal)
    Public Property LF_Igv_adic As Nullable(Of Decimal)
    Public Property LF_Renta_ini As Nullable(Of Decimal)
    Public Property LF_Renta_ns As Nullable(Of Decimal)
    Public Property LF_Renta_adic As Nullable(Of Decimal)
    Public Property LF_RDA_ini As Nullable(Of Decimal)
    Public Property LF_RDA_ns As Nullable(Of Decimal)
    Public Property LF_RDA_adic As Nullable(Of Decimal)
    Public Property LF_Total_ini As Nullable(Of Decimal)
    Public Property LF_Total_ns As Nullable(Of Decimal)
    Public Property LF_Total_adic As Nullable(Of Decimal)
    Public Property LF_OtrosGastos_ini As Nullable(Of Decimal)
    Public Property LF_OtrosGastos_ns As Nullable(Of Decimal)
    Public Property LF_OtrosGastos_adic As Nullable(Of Decimal)
    Public Property LF_TotalObligacion_ini As Nullable(Of Decimal)
    Public Property LF_TotalObligacion_ns As Nullable(Of Decimal)
    Public Property LF_TotalObligacion_adic As Nullable(Of Decimal)
    Public Property detraccion_ini As Nullable(Of Decimal)
    Public Property detraccion_ns As Nullable(Of Decimal)
    Public Property detraccion_adic As Nullable(Of Decimal)
    Public Property LF_TO_ini As Nullable(Of Decimal)
    Public Property LF_TO_ns As Nullable(Of Decimal)
    Public Property LF_TO_adic As Nullable(Of Decimal)
    Public Property LFPorcRetUti As Nullable(Of Decimal)
    Public Property LF_RetUti_ini As Nullable(Of Decimal)
    Public Property LF_RetUti_ns As Nullable(Of Decimal)
    Public Property LF_RetUti_adic As Nullable(Of Decimal)
    Public Property LF_ini As Nullable(Of Decimal)
    Public Property LF_ns As Nullable(Of Decimal)
    Public Property LF_adic As Nullable(Of Decimal)
    Public Property AF_IngNeto_ini As Nullable(Of Decimal)
    Public Property AF_IngNeto_ns As Nullable(Of Decimal)
    Public Property AF_IngNeto_adic As Nullable(Of Decimal)
    Public Property AF_EjecucionIng_ini As Nullable(Of Decimal)
    Public Property AF_EjecucionIng_ns As Nullable(Of Decimal)
    Public Property AF_EjecucionIng_adic As Nullable(Of Decimal)
    Public Property AF_Percepcion_ini As Nullable(Of Decimal)
    Public Property AF_Percepcion_ns As Nullable(Of Decimal)
    Public Property AF_Percepcion_adic As Nullable(Of Decimal)
    Public Property AF_Otrosps_ini As Nullable(Of Decimal)
    Public Property AF_Otrosps_ns As Nullable(Of Decimal)
    Public Property AF_Otrosps_adic As Nullable(Of Decimal)
    Public Property AF_Detraccion_ini As Nullable(Of Decimal)
    Public Property AF_Detraccion_ns As Nullable(Of Decimal)
    Public Property AF_Detraccion_adic As Nullable(Of Decimal)
    Public Property AF_Retencion_ini As Nullable(Of Decimal)
    Public Property AF_Retencion_ns As Nullable(Of Decimal)
    Public Property AF_Retencion_adic As Nullable(Of Decimal)
    Public Property AF_Otrosng_ini As Nullable(Of Decimal)
    Public Property AF_Otrosng_ns As Nullable(Of Decimal)
    Public Property AF_Otrosng_adic As Nullable(Of Decimal)
    Public Property AF_TotalPagoProvSust_ini As Nullable(Of Decimal)
    Public Property AF_TotalPagoProvSust_ns As Nullable(Of Decimal)
    Public Property AF_TotalPagoProvSust_adic As Nullable(Of Decimal)
    Public Property AF_RefGastoNoSust_ini As Nullable(Of Decimal)
    Public Property AF_RefGastoNoSust_ns As Nullable(Of Decimal)
    Public Property AF_RefGastoNoSust_adic As Nullable(Of Decimal)
    Public Property AF_SaldoEF_ini As Nullable(Of Decimal)
    Public Property AF_SaldoEF_ns As Nullable(Of Decimal)
    Public Property AF_SaldoEF_adic As Nullable(Of Decimal)
    Public Property AF_Igv_ini As Nullable(Of Decimal)
    Public Property AF_Igv_ns As Nullable(Of Decimal)
    Public Property AF_Igv_adic As Nullable(Of Decimal)
    Public Property AF_Renta_ini As Nullable(Of Decimal)
    Public Property AF_Renta_ns As Nullable(Of Decimal)
    Public Property AF_Renta_adic As Nullable(Of Decimal)
    Public Property AF_RDA_ini As Nullable(Of Decimal)
    Public Property AF_RDA_ns As Nullable(Of Decimal)
    Public Property AF_RDA_adic As Nullable(Of Decimal)
    Public Property AF_OtrosPagos_ini As Nullable(Of Decimal)
    Public Property AF_OtrosPagos_ns As Nullable(Of Decimal)
    Public Property AF_OtrosPagos_adic As Nullable(Of Decimal)
    Public Property AF_TotalPagoOT_ini As Nullable(Of Decimal)
    Public Property AF_TotalPagoOT_ns As Nullable(Of Decimal)
    Public Property AF_TotalPagoOT_adic As Nullable(Of Decimal)
    Public Property AF_SaldoFinal_ini As Nullable(Of Decimal)
    Public Property AF_SaldoFinal_ns As Nullable(Of Decimal)
    Public Property AF_SaldoFinal_adic As Nullable(Of Decimal)
    Public Property AF_AjusteCF_ini As Nullable(Of Decimal)
    Public Property AF_AjusteCF_ns As Nullable(Of Decimal)
    Public Property AF_AjusteCF_adic As Nullable(Of Decimal)
    Public Property AF_AjusteCFng_ini As Nullable(Of Decimal)
    Public Property AF_AjusteCFng_ns As Nullable(Of Decimal)
    Public Property AF_AjusteCFng_adic As Nullable(Of Decimal)
    Public Property AF_AjPerc_ini As Nullable(Of Decimal)
    Public Property AF_AjPerc_ns As Nullable(Of Decimal)
    Public Property AF_AjPerc_adic As Nullable(Of Decimal)
    Public Property AF_AjOtros1_ini As Nullable(Of Decimal)
    Public Property AF_AjOtros1_ns As Nullable(Of Decimal)
    Public Property AF_AjOtros1_adic As Nullable(Of Decimal)
    Public Property AF_AjDetra_ini As Nullable(Of Decimal)
    Public Property AF_AjDetra_ns As Nullable(Of Decimal)
    Public Property AF_AjDetra_adic As Nullable(Of Decimal)
    Public Property AF_AjReten_ini As Nullable(Of Decimal)
    Public Property AF_AjReten_ns As Nullable(Of Decimal)
    Public Property AF_AjReten_adic As Nullable(Of Decimal)
    Public Property AF_AjOtros2_ini As Nullable(Of Decimal)
    Public Property AF_AjOtros2_ns As Nullable(Of Decimal)
    Public Property AF_AjOtros2_adic As Nullable(Of Decimal)
    Public Property AF_AjRentaps_ini As Nullable(Of Decimal)
    Public Property AF_AjRentaps_ns As Nullable(Of Decimal)
    Public Property AF_AjRentaps_adic As Nullable(Of Decimal)
    Public Property AF_AjRentang_ini As Nullable(Of Decimal)
    Public Property AF_AjRentang_ns As Nullable(Of Decimal)
    Public Property AF_AjRentang_adic As Nullable(Of Decimal)
    Public Property AF_SaldoFinalC_ini As Nullable(Of Decimal)
    Public Property AF_SaldoFinalC_ns As Nullable(Of Decimal)
    Public Property AF_SaldoFinalC_adic As Nullable(Of Decimal)
    Public Property AF_Validador_ini As Nullable(Of Decimal)
    Public Property AF_Validador_ns As Nullable(Of Decimal)
    Public Property AF_Validador_adic As Nullable(Of Decimal)
    Public Property LP_IN_ini As Nullable(Of Decimal)
    Public Property LP_IN_ns As Nullable(Of Decimal)
    Public Property LP_IN_adic As Nullable(Of Decimal)
    Public Property LP_IngProy_ini As Nullable(Of Decimal)
    Public Property LP_IngProy_ns As Nullable(Of Decimal)
    Public Property LP_IngProy_adic As Nullable(Of Decimal)
    Public Property LP_Percep_ini As Nullable(Of Decimal)
    Public Property LP_Percep_ns As Nullable(Of Decimal)
    Public Property LP_Percep_adic As Nullable(Of Decimal)
    Public Property LP_Otros1_ini As Nullable(Of Decimal)
    Public Property LP_Otros1_ns As Nullable(Of Decimal)
    Public Property LP_Otros1_adic As Nullable(Of Decimal)
    Public Property LP_Detra_ini As Nullable(Of Decimal)
    Public Property LP_Detra_ns As Nullable(Of Decimal)
    Public Property LP_Detra_adic As Nullable(Of Decimal)
    Public Property LP_Reten_ini As Nullable(Of Decimal)
    Public Property LP_Reten_ns As Nullable(Of Decimal)
    Public Property LP_Reten_adic As Nullable(Of Decimal)
    Public Property LP_Otros2_ini As Nullable(Of Decimal)
    Public Property LP_Otros2_ns As Nullable(Of Decimal)
    Public Property LP_Otros2_adic As Nullable(Of Decimal)
    Public Property LP_Egreso_ini As Nullable(Of Decimal)
    Public Property LP_Egreso_ns As Nullable(Of Decimal)
    Public Property LP_Egreso_adic As Nullable(Of Decimal)
    Public Property LP_PagoProv_ini As Nullable(Of Decimal)
    Public Property LP_PagoProv_ns As Nullable(Of Decimal)
    Public Property LP_PagoProv_adic As Nullable(Of Decimal)
    Public Property LP_EgresoNoSustentado_ns As Nullable(Of Decimal)
    Public Property LP_EgresoNoSustentado_adic As Nullable(Of Decimal)
    Public Property LP_EgresoInciAdic_adic As Nullable(Of Decimal)
    Public Property LP_ResTributo_ini As Nullable(Of Decimal)
    Public Property LP_ResTributo_ns As Nullable(Of Decimal)
    Public Property LP_ResTributo_adic As Nullable(Of Decimal)
    Public Property LP_Tributo_ini As Nullable(Of Decimal)
    Public Property LP_Tributo_ns As Nullable(Of Decimal)
    Public Property LP_Tributo_adic As Nullable(Of Decimal)
    Public Property LP_Igv_ini As Nullable(Of Decimal)
    Public Property LP_Igv_ns As Nullable(Of Decimal)
    Public Property LP_Igv_adic As Nullable(Of Decimal)
    Public Property LP_Renta_ini As Nullable(Of Decimal)
    Public Property LP_Renta_ns As Nullable(Of Decimal)
    Public Property LP_Renta_adic As Nullable(Of Decimal)
    Public Property LP_RDA_ini As Nullable(Of Decimal)
    Public Property LP_RDA_ns As Nullable(Of Decimal)
    Public Property LP_RDA_adic As Nullable(Of Decimal)
    Public Property LP_RetUti_ini As Nullable(Of Decimal)
    Public Property LP_RetUti_ns As Nullable(Of Decimal)
    Public Property LP_RetUti_adic As Nullable(Of Decimal)
    Public Property LP_OtrodsPagos_ini As Nullable(Of Decimal)
    Public Property LP_OtrodsPagos_ns As Nullable(Of Decimal)
    Public Property LP_OtrodsPagos_adic As Nullable(Of Decimal)
    Public Property LP_SaldoEfe_ini As Nullable(Of Decimal)
    Public Property LP_SaldoEfe_ns As Nullable(Of Decimal)
    Public Property LP_SaldoEfe_adic As Nullable(Of Decimal)
    Public Property totalIngreso As Nullable(Of Decimal)
    Public Property obsLiquiIgv As String
    Public Property obsLiquiRenta As String
    Public Property obsLiquiLoo As String
    Public Property obsLiquiAnalisis As String
    Public Property obsLiquiEventoProyecto As String
    Public Property DT_ini As Nullable(Of Decimal)
    Public Property DT_ns As Nullable(Of Decimal)
    Public Property DT_adic As Nullable(Of Decimal)
    Public Property DT_OI_ini As Nullable(Of Decimal)
    Public Property DT_OI_ns As Nullable(Of Decimal)
    Public Property DT_OI_adic As Nullable(Of Decimal)
    Public Property DT_OE_ini As Nullable(Of Decimal)
    Public Property DT_OE_ns As Nullable(Of Decimal)
    Public Property DT_OE_adic As Nullable(Of Decimal)
    Public Property DT_saldo_ini As Nullable(Of Decimal)
    Public Property DT_saldo_ns As Nullable(Of Decimal)
    Public Property DT_saldo_adic As Nullable(Of Decimal)
    Public Property TipoPlan As String
    Public Property tipoReporte As String
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

End Class
