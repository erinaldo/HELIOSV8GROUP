Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

'martin
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmReporteDocumentoCompra
    Inherits frmMaster
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub ConsultaReporteTotalesPorPeriodo(strPeriodo As String)
        Dim totalesAlmacenSA As New documentoCompraRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteRegistroCompra.rdlc"
        Me.reportData = totalesAlmacenSA.GetListarComprasPorPeriodoReporte(GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSCompra"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub

    Public Sub ConsultaReporteTotalesPorDia()
        Dim totalesAlmacenSA As New documentoCompraRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteRegistroCompra.rdlc"
        '  Me.reportData = totalesAlmacenSA.GetListarComprasPorDiaReporte(GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DSCompra"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
       oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpPeriodo", Date.Now.Date))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub

    Private Sub frmReporteDocumentoCompra_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub
End Class