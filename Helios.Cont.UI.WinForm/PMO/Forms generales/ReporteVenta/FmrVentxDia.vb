Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms

Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions

Public Class FmrVentxDia

    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        txtFecha.Value = DateTime.Now
        ' Add any initialization after the InitializeComponent() call.
        'LoadANios()
    End Sub



#Region "METODOS"

    Public Sub ConsultaReporteTotalesPorPeriodo(strPeriodo As String)
        Dim totalesAlmacenSA As New documentoVentaRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteRegistroVentas.rdlc"
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
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        rptAportes.LocalReport.SetParameters(oParams)
        rptAportes.RefreshReport()
        rptAportes.SetDisplayMode(DisplayMode.PrintLayout)
        rptAportes.ZoomMode = ZoomMode.Percent
        rptAportes.ZoomPercent = 75

    End Sub

    Public Sub ConsultaReporteTotalesPorMes()
        Dim totalesAlmacenSA As New documentoVentaRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteRegistroVentas.rdlc"
        Me.reportData = totalesAlmacenSA.OntenerListadoVentasAbaXDia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, txtFecha.Value)
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
        oParams.Add(New ReportParameter("rpPeriodo", PeriodoGeneral))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        rptAportes.LocalReport.SetParameters(oParams)
        rptAportes.RefreshReport()
        rptAportes.SetDisplayMode(DisplayMode.PrintLayout)
        rptAportes.ZoomMode = ZoomMode.Percent
        rptAportes.ZoomPercent = 75
    End Sub
#End Region



    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        ConsultaReporteTotalesPorMes()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub FmrVentxDia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FmrVentxDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
