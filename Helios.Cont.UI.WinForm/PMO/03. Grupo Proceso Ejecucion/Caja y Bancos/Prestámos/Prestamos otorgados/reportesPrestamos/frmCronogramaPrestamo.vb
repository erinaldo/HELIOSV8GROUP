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
Public Class frmCronogramaPrestamo

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'LoadANios()
    End Sub

    Public Sub ConsultaCronograma(strAnio As String)
        Dim totalesAlmacenSA As New DocumentoCajaDetalleSA
        Dim caja As New List(Of documentoPrestamoDetalle)
        Dim mes(11) As Decimal

        Me.reportName = "Helios.Cont.Presentation.WinForm.CronogramaPrestamo.rdlc"
        ' Me.reportData = totalesAlmacenSA.GetListarComprasPorANioReporte(GEstableciento.IdEstablecimiento, AnioGeneral)
        caja = totalesAlmacenSA.ListarPrestamosPorPagarPorDetails(111)
        'Me.nombreMainDS = "DSCompra"
        'Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCronograma.KeepSessionAlive = True
        rptCronograma.Reset()
        '   ReportViewer1.LocalReport.DataSources.Add(reporte)
        rptCronograma.LocalReport.Refresh()
        rptCronograma.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCronograma.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        'oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpAnio", cboMes.Text))

      

        rptCronograma.LocalReport.SetParameters(oParams)
        rptCronograma.RefreshReport()
        rptCronograma.SetDisplayMode(DisplayMode.PrintLayout)
        rptCronograma.ZoomMode = ZoomMode.Percent
        rptCronograma.ZoomPercent = 100
    End Sub


    Private Sub frmCronogramaPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rptCronograma.RefreshReport()
    End Sub
End Class