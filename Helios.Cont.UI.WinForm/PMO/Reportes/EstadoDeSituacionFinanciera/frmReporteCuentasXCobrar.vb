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

Public Class frmReporteCuentasXCobrar

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String


#Region "Métodos"

    Public Sub ConsultaPrecios()
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.Formato3.3CuentasPorCobrarComerciales.rdlc"
        Me.reportData = documentoVentaSA.UbicarCuentaCobrarComercial(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsCuentaCobro"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaCobro.KeepSessionAlive = True
        rptCuentaCobro.Reset()
        rptCuentaCobro.LocalReport.DataSources.Add(reporte)
        rptCuentaCobro.LocalReport.Refresh()
        rptCuentaCobro.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaCobro.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaCobro.LocalReport.SetParameters(oParams)
        rptCuentaCobro.RefreshReport()
        rptCuentaCobro.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaCobro.ZoomMode = ZoomMode.Percent
        rptCuentaCobro.ZoomPercent = 75
    End Sub

#End Region

    Private Sub frmReporteCuentasXCobrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rptCuentaCobro.RefreshReport()
        ConsultaPrecios()
    End Sub
End Class
