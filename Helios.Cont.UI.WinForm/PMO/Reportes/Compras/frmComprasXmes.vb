Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Microsoft.Reporting.WinForms
Imports Helios.Cont.Business.Entity
Public Class frmComprasXmes
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadComboAnio()
    End Sub

    Private Sub LoadComboAnio()
        Dim empresaPeriodoSA As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaPeriodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = CInt(cboAnio.Text)
    End Sub

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
        Me.reportData = totalesAlmacenSA.GetListarComprasPorPeriodoReporte(GEstableciento.IdEstablecimiento, strPeriodo).Where(Function(o) o.tipoCompra = TIPO_COMPRA.COMPRA_ANULADA).ToList
        Me.nombreMainDS = "DSCompra"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa & "- ( " & GEstableciento.NombreEstablecimiento & ")"))
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

    Private Sub frmComprasXmes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case cboMes.Text

            Case "ENERO"
                ConsultaReporteTotalesPorPeriodo("01/" & CInt(cboAnio.Text))
            Case "FEBRERO"
                ConsultaReporteTotalesPorPeriodo("02/" & CInt(cboAnio.Text))
            Case "MARZO"
                ConsultaReporteTotalesPorPeriodo("03/" & CInt(cboAnio.Text))
            Case "ABRIL"
                ConsultaReporteTotalesPorPeriodo("04/" & CInt(cboAnio.Text))
            Case "MAYO"
                ConsultaReporteTotalesPorPeriodo("05/" & CInt(cboAnio.Text))
            Case "JUNIO"
                ConsultaReporteTotalesPorPeriodo("06/" & CInt(cboAnio.Text))
            Case "JULIO"
                ConsultaReporteTotalesPorPeriodo("07/" & CInt(cboAnio.Text))
            Case "AGOSTO"
                ConsultaReporteTotalesPorPeriodo("08/" & CInt(cboAnio.Text))
            Case "SETIEMBRE"
                ConsultaReporteTotalesPorPeriodo("09/" & CInt(cboAnio.Text))
            Case "OCTUBRE"
                ConsultaReporteTotalesPorPeriodo("10/" & CInt(cboAnio.Text))
            Case "NOVIEMBRE"
                ConsultaReporteTotalesPorPeriodo("11/" & CInt(cboAnio.Text))
            Case "DICIEMBRE"
                ConsultaReporteTotalesPorPeriodo("12/" & CInt(cboAnio.Text))
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
