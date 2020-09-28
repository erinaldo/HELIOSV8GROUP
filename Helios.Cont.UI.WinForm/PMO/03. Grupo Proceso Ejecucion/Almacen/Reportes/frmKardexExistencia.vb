Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmKardexExistencia
    Inherits frmMaster
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub ConsultaReporteTotalesPorPeriodo(intIdAlmacen As String, strAlmacen As String, intIdItem As String, srpProducto As String)
        Dim inventarioMovimientoSA As New inventarioMovimientoRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteKardexExistencia.rdlc"
        Me.reportData = inventarioMovimientoSA.ObtenerProdPorAlmacenesPeriodoRPT(intIdAlmacen, intIdItem, AnioGeneral, MesGeneral)
        Me.nombreMainDS = "DSInventario"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpPeriodo", String.Concat(MesGeneral + "/" + AnioGeneral)))
        oParams.Add(New ReportParameter("rpAlmacen", strAlmacen))
        oParams.Add(New ReportParameter("rpProducto", srpProducto))
        'oParams.Add(New ReportParameter("rpItem", cbotipoexistencia.ComboBox.Text))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

    Public Sub ConsultaReporteTotalesPorDia(intIdAlmacen As String, strAlmacen As String, intIdItem As String, srpProducto As String)
        Dim inventarioMovimientoSA As New inventarioMovimientoRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteKardexExistencia.rdlc"
        Me.reportData = inventarioMovimientoSA.ObtenerProdPorAlmacenesPeriodoRPT(intIdAlmacen, intIdItem, AnioGeneral, MesGeneral)
        Me.nombreMainDS = "DSInventario"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpPeriodo", Date.Now.Date))
        oParams.Add(New ReportParameter("rpAlmacen", strAlmacen))
        oParams.Add(New ReportParameter("rpProducto", srpProducto))
        'oParams.Add(New ReportParameter("rpItem", cbotipoexistencia.ComboBox.Text))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

    Private Sub frmKardexExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class