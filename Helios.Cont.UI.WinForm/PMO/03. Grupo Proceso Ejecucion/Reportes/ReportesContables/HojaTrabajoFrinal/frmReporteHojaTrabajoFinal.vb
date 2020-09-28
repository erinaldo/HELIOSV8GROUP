Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmReporteHojaTrabajoFinal
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Sub listaDeReportesHojaTrabajoFinalFull(strPeriodo As Integer)
        Dim compraSA As New HojaTrabajoFinalRPTSA
        Me.reportData = compraSA.BuscarHojaTrabajoFinalFullReporte(strPeriodo)
        ConsultaReporteMaster(CStr(strPeriodo))
    End Sub

    Sub listaDeReportesAsientoPorMes(dtpPeriodoAnio As Date, dtpPEriodoMes As Date)
        Dim compraSA As New HojaTrabajoFinalRPTSA
        Me.reportData = compraSA.BuscarHojaTrabajoFinalPorMesReporte(dtpPeriodoAnio, dtpPEriodoMes)
        ConsultaReporteMaster(String.Concat(CStr(dtpPEriodoMes) + "/" + CStr(dtpPeriodoAnio)))
    End Sub

    Sub listaDeReportesHojaTrabajoPorAcumulado(dtpDesdeAnio As Date, dtphastaAnio As Date)
        Dim compraSA As New HojaTrabajoFinalRPTSA
        Me.reportData = compraSA.BuscarHojaTrabajoFinalPorAcumuladoReporte(dtpDesdeAnio, dtphastaAnio)
        ConsultaReporteMaster(String.Concat(CStr(dtpDesdeAnio) + " - " + CStr(dtphastaAnio)))
    End Sub

    Public Sub ConsultaReporteMaster(srtPeriodo As String)
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.HojaTrabajoFinal.rdlc"
        Me.nombreMainDS = "DSHojaTrabajoFinal"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptHojaTrabajoFinal.KeepSessionAlive = True
        rptHojaTrabajoFinal.Reset()
        rptHojaTrabajoFinal.LocalReport.DataSources.Add(reporte)
        rptHojaTrabajoFinal.LocalReport.Refresh()
        rptHojaTrabajoFinal.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptHojaTrabajoFinal.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", srtPeriodo))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptHojaTrabajoFinal.LocalReport.SetParameters(oParams)
        rptHojaTrabajoFinal.RefreshReport()
        rptHojaTrabajoFinal.SetDisplayMode(DisplayMode.PrintLayout)
        rptHojaTrabajoFinal.ZoomMode = ZoomMode.Percent
        rptHojaTrabajoFinal.ZoomPercent = 75
    End Sub
End Class