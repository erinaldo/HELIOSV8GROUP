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

Public Class frmReporteCuentasXPagar

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "metodos"
    Public Sub Consultar()
        Dim totalesAlmacenSA As New DocumentoCompraSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.Formato3.12CuentasPorPagar.rdlc"
        Me.reportData = totalesAlmacenSA.UbicarCuentasXPagarComerciales()
        Me.nombreMainDS = "DsCuenPagar"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaXPagar.KeepSessionAlive = True
        rptCuentaXPagar.Reset()
        rptCuentaXPagar.LocalReport.DataSources.Add(reporte)
        rptCuentaXPagar.LocalReport.Refresh()
        rptCuentaXPagar.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaXPagar.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaXPagar.LocalReport.SetParameters(oParams)
        rptCuentaXPagar.RefreshReport()
        rptCuentaXPagar.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaXPagar.ZoomMode = ZoomMode.Percent
        rptCuentaXPagar.ZoomPercent = 75
    End Sub
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rptCuentaXPagar.RefreshReport()
        Consultar()
    End Sub
End Class
