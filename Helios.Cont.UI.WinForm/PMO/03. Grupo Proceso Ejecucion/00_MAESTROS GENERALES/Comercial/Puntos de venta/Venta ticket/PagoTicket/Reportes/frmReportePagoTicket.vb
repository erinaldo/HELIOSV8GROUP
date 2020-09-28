Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmReportePagoTicket
    Inherits frmMaster
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub ConsultaReporteTotalesPorPeriodo(strPeriodo As String)
        Dim totalesAlmacenSA As New documentoVentaRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.PagoTicketPorPeriodo.rdlc"
        Me.reportData = totalesAlmacenSA.OntenerListadoVentasAbarrotesPorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSVentas"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptAportes.KeepSessionAlive = True
        rptAportes.Reset()
        rptAportes.LocalReport.DataSources.Add(reporte)
        rptAportes.LocalReport.Refresh()
        rptAportes.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptAportes.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        rptAportes.LocalReport.SetParameters(oParams)
        rptAportes.RefreshReport()
        rptAportes.SetDisplayMode(DisplayMode.PrintLayout)
        rptAportes.ZoomMode = ZoomMode.Percent
        rptAportes.ZoomPercent = 75
    End Sub

    Public Sub ConsultaReporteTotalesPorDia(strTipoVenta As String)
        Dim totalesAlmacenSA As New documentoVentaRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.PagoTicketPorPeriodo.rdlc"
        Me.reportData = totalesAlmacenSA.OntenerListadoVentasAbarrotesPorDia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strTipoVenta)
        Me.nombreMainDS = "DSVentas"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptAportes.KeepSessionAlive = True
        rptAportes.Reset()
        rptAportes.LocalReport.DataSources.Add(reporte)
        rptAportes.LocalReport.Refresh()
        rptAportes.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptAportes.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpPeriodo", Date.Now.Date))
        rptAportes.LocalReport.SetParameters(oParams)
        rptAportes.RefreshReport()
        rptAportes.SetDisplayMode(DisplayMode.PrintLayout)
        rptAportes.ZoomMode = ZoomMode.Percent
        rptAportes.ZoomPercent = 75
    End Sub

    Private Sub frmReportePagoTicket_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub frmReportePagoTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class