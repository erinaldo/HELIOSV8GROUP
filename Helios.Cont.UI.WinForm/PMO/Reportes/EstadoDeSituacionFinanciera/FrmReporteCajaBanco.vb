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

Public Class FrmReporteCajaBanco

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "Métodos"

    Public Sub ConsultaPrecios()
        Dim totalesAlmacenSA As New EstadosFinancierosSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.Formato3.2CajayBancos.rdlc"
        Me.reportData = totalesAlmacenSA.GetEstadoCajasTodosDetalle()
        Me.nombreMainDS = "DsCajaBanco"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCajaBancos.KeepSessionAlive = True
        rptCajaBancos.Reset()
        rptCajaBancos.LocalReport.DataSources.Add(reporte)
        rptCajaBancos.LocalReport.Refresh()
        rptCajaBancos.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCajaBancos.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCajaBancos.LocalReport.SetParameters(oParams)
        rptCajaBancos.RefreshReport()
        rptCajaBancos.SetDisplayMode(DisplayMode.PrintLayout)
        rptCajaBancos.ZoomMode = ZoomMode.Percent
        rptCajaBancos.ZoomPercent = 75
    End Sub

#End Region

    Private Sub FrmReporteCajaBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultaPrecios()
    End Sub
End Class