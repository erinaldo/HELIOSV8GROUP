Imports Microsoft.Reporting.WinForms
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.Security
Imports System.Security.Permissions

Public Class frmReporteCajaOnline
    'documentoCajaSA.
#Region "Métodos"
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String


    Public Sub ConsultaReporte(intIdEStablecimiento As Integer, strMes As String, strAnio As String, strEF As String, strNombreEF As String)
        Dim docCajaSA As New documentoCajaRPTSA
        'Dim STRMoneda As String
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteCajaOnline.rdlc"
        Me.reportData = docCajaSA.ObtenerCajaOnlineRPT(Gempresas.IdEmpresaRuc, intIdEStablecimiento, strMes, strAnio, strEF)
        Me.nombreMainDS = "DSCajaOnline"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCaja.KeepSessionAlive = True
        rptCaja.Reset()
        rptCaja.LocalReport.DataSources.Add(reporte)
        rptCaja.LocalReport.Refresh()
        rptCaja.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCaja.LocalReport.ReportEmbeddedResource = reportName

        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", frmCajaOnline.cboEstablecimiento.Text))
        oParams.Add(New ReportParameter("rpCuentaFinanciera", strNombreEF))
        '(frmCajaOnline.lsvAlmacen.SelectedItems(0).SubItems(1).Text) & "-" & frmCajaOnline.lsvAlmacen.SelectedItems(0).SubItems(4).Text)
        'If frmCajaOnline.rbMN.Checked = True Then
        '    STRMoneda = "MONEDA NACIONAL"
        'Else
        '    STRMoneda = "MONEDA EXTRANJERA"
        'End If
        'oParams.Add(New ReportParameter("rpMoneda", STRMoneda))
        rptCaja.LocalReport.SetParameters(oParams)
        rptCaja.RefreshReport()
        rptCaja.SetDisplayMode(DisplayMode.PrintLayout)
        rptCaja.ZoomMode = ZoomMode.Percent
        rptCaja.ZoomPercent = 75
    End Sub


    Public Sub ConsultaReporteDia(intIdEStablecimiento As Integer, strEF As String, strNombreEF As String)
        Dim docCajaSA As New documentoCajaRPTSA
        'Dim STRMoneda As String
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteCajaOnline.rdlc"
        Me.reportData = docCajaSA.ObtenerCajaOnlineDiaRPT(Gempresas.IdEmpresaRuc, intIdEStablecimiento, strEF)
        Me.nombreMainDS = "DSCajaOnline"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCaja.KeepSessionAlive = True
        rptCaja.Reset()
        rptCaja.LocalReport.DataSources.Add(reporte)
        rptCaja.LocalReport.Refresh()
        rptCaja.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCaja.LocalReport.ReportEmbeddedResource = reportName

        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", frmCajaOnline.cboEstablecimiento.Text))
        oParams.Add(New ReportParameter("rpCuentaFinanciera", strNombreEF))
        '(frmCajaOnline.lsvAlmacen.SelectedItems(0).SubItems(1).Text) & "-" & frmCajaOnline.lsvAlmacen.SelectedItems(0).SubItems(4).Text)
        'If frmCajaOnline.rbMN.Checked = True Then
        '    STRMoneda = "MONEDA NACIONAL"
        'Else
        '    STRMoneda = "MONEDA EXTRANJERA"
        'End If
        'oParams.Add(New ReportParameter("rpMoneda", STRMoneda))
        rptCaja.LocalReport.SetParameters(oParams)
        rptCaja.RefreshReport()
        rptCaja.SetDisplayMode(DisplayMode.PrintLayout)
        rptCaja.ZoomMode = ZoomMode.Percent
        rptCaja.ZoomPercent = 75
    End Sub

    Public Sub ConsultaReporteAcumulado(intIdEStablecimiento As Integer)
        Dim docCajaSA As New documentoCajaRPTSA
        'Dim STRMoneda As String
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteCajaOnline.rdlc"
        Me.reportData = docCajaSA.ObtenerCajaOnlineAcumuladoRPT(Gempresas.IdEmpresaRuc, intIdEStablecimiento)
        Me.nombreMainDS = "DSCajaOnline"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCaja.KeepSessionAlive = True
        rptCaja.Reset()
        rptCaja.LocalReport.DataSources.Add(reporte)
        rptCaja.LocalReport.Refresh()
        rptCaja.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCaja.LocalReport.ReportEmbeddedResource = reportName

        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", frmCajaOnline.cboEstablecimiento.Text))
        oParams.Add(New ReportParameter("rpCuentaFinanciera", ""))
        '(frmCajaOnline.lsvAlmacen.SelectedItems(0).SubItems(1).Text) & "-" & frmCajaOnline.lsvAlmacen.SelectedItems(0).SubItems(4).Text)
        'If frmCajaOnline.rbMN.Checked = True Then
        '    STRMoneda = "MONEDA NACIONAL"
        'Else
        '    STRMoneda = "MONEDA EXTRANJERA"
        'End If
        'oParams.Add(New ReportParameter("rpMoneda", STRMoneda))
        rptCaja.LocalReport.SetParameters(oParams)
        rptCaja.RefreshReport()
        rptCaja.SetDisplayMode(DisplayMode.PrintLayout)
        rptCaja.ZoomMode = ZoomMode.Percent
        rptCaja.ZoomPercent = 75
    End Sub
#End Region

    Private Sub frmReporteCajaOnline_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmReporteCajaOnline_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonCaption1.ItemActivated

    End Sub
End Class