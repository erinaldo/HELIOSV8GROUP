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

Public Class frmReporteServicioOtroAnticipado

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "metodos"
    Public Sub Consultar()
        Dim totalesAlmacenSA As New DocumentoCompraDetalleSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.Formato3.5ServicioyOtroContrato.rdlc"
        Me.reportData = totalesAlmacenSA.ListaServiciosOtrosAnticipado()
        Me.nombreMainDS = "DsServAnt"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptServicioAnticipado.KeepSessionAlive = True
        rptServicioAnticipado.Reset()
        rptServicioAnticipado.LocalReport.DataSources.Add(reporte)
        rptServicioAnticipado.LocalReport.Refresh()
        rptServicioAnticipado.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptServicioAnticipado.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptServicioAnticipado.LocalReport.SetParameters(oParams)
        rptServicioAnticipado.RefreshReport()
        rptServicioAnticipado.SetDisplayMode(DisplayMode.PrintLayout)
        rptServicioAnticipado.ZoomMode = ZoomMode.Percent
        rptServicioAnticipado.ZoomPercent = 75
    End Sub
#End Region

    Private Sub frmReporteServicioOtroAnticipado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
        Me.rptServicioAnticipado.RefreshReport()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
