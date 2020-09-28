Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmReporteAporteGeneral
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
        Me.reportName = "Helios.Cont.Presentation.WinForm.AporteGeneralPorPeriodo.rdlc"
        Me.reportData = totalesAlmacenSA.OntenerListadoComprasPorAportaciones(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSAportacionGeneral"
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

    Public Sub ConsultaReporteTotalesPorDia()
        Dim totalesAlmacenSA As New documentoCompraRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.AporteGeneralPorPeriodo.rdlc"
        Me.reportData = totalesAlmacenSA.OntenerListadoComprasPorAportacionesPorDia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DSAportacionGeneral"
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

End Class