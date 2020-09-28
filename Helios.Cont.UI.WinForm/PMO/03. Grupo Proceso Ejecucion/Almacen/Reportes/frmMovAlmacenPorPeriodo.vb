Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions

Public Class frmMovAlmacenPorPeriodo
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
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteMovAlmacenPorPeriodo.rdlc"
        Me.reportData = totalesAlmacenSA.OntenerListadoComprasPorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSMovInfomePorPeriodo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptMovAlmacen.KeepSessionAlive = True
        rptMovAlmacen.Reset()
        rptMovAlmacen.LocalReport.DataSources.Add(reporte)
        rptMovAlmacen.LocalReport.Refresh()
        rptMovAlmacen.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptMovAlmacen.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        'oParams.Add(New ReportParameter("rpItem", cbotipoexistencia.ComboBox.Text))
        rptMovAlmacen.LocalReport.SetParameters(oParams)
        rptMovAlmacen.RefreshReport()
        rptMovAlmacen.SetDisplayMode(DisplayMode.PrintLayout)
        rptMovAlmacen.ZoomMode = ZoomMode.Percent
        rptMovAlmacen.ZoomPercent = 75
    End Sub

    Public Sub ConsultaReporteTotalesPorDia(strTipoCompra As String)
        Dim totalesAlmacenSA As New documentoCompraRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteMovAlmacenPorPeriodo.rdlc"
        Me.reportData = totalesAlmacenSA.GetListarMvimientosAlmacenPorDiaReporte(GEstableciento.IdEstablecimiento, strTipoCompra)
        Me.nombreMainDS = "DSMovInfomePorPeriodo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptMovAlmacen.KeepSessionAlive = True
        rptMovAlmacen.Reset()
        rptMovAlmacen.LocalReport.DataSources.Add(reporte)
        rptMovAlmacen.LocalReport.Refresh()
        rptMovAlmacen.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptMovAlmacen.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpPeriodo", Date.Now.Date))
        'oParams.Add(New ReportParameter("rpItem", cbotipoexistencia.ComboBox.Text))
        rptMovAlmacen.LocalReport.SetParameters(oParams)
        rptMovAlmacen.RefreshReport()
        rptMovAlmacen.SetDisplayMode(DisplayMode.PrintLayout)
        rptMovAlmacen.ZoomMode = ZoomMode.Percent
        rptMovAlmacen.ZoomPercent = 75
    End Sub

    Private Sub frmMovAlmacenPorPeriodo_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub
End Class