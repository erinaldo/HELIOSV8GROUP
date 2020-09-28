Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmArticulosVendidosByMes
    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        getAnios()
    End Sub

#Region "Métodos"
    Private Sub getAnios()
        Dim anioSA As New empresaPeriodoSA

        cboAnio.DataSource = anioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.Text = AnioGeneral
    End Sub
    Public Sub ConsultaReporteArticulosVendidosPorMes(strPeriodo As String)
        Dim ventaSA As New documentoVentaAbarrotesSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvArticulosVendidosPorMes.rdlc"
        Me.reportData = ventaSA.GetArticulosVendidosByMes(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaPeriodo = strPeriodo})
        Me.nombreMainDS = "DSVentas"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

#End Region

    Private Sub frmArticulosVendidosByMes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmArticulosVendidosBydia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case cboMes.Text

            Case "ENERO"
                ConsultaReporteArticulosVendidosPorMes("01/" & cboAnio.Text)
            Case "FEBRERO"
                ConsultaReporteArticulosVendidosPorMes("02/" & cboAnio.Text)
            Case "MARZO"
                ConsultaReporteArticulosVendidosPorMes("03/" & cboAnio.Text)
            Case "ABRIL"
                ConsultaReporteArticulosVendidosPorMes("04/" & cboAnio.Text)
            Case "MAYO"
                ConsultaReporteArticulosVendidosPorMes("05/" & cboAnio.Text)
            Case "JUNIO"
                ConsultaReporteArticulosVendidosPorMes("06/" & cboAnio.Text)
            Case "JULIO"
                ConsultaReporteArticulosVendidosPorMes("07/" & cboAnio.Text)
            Case "AGOSTO"
                ConsultaReporteArticulosVendidosPorMes("08/" & cboAnio.Text)
            Case "SETIEMBRE"
                ConsultaReporteArticulosVendidosPorMes("09/" & cboAnio.Text)
            Case "OCTUBRE"
                ConsultaReporteArticulosVendidosPorMes("10/" & cboAnio.Text)
            Case "NOVIEMBRE"
                ConsultaReporteArticulosVendidosPorMes("11/" & cboAnio.Text)
            Case "DICIEMBRE"
                ConsultaReporteArticulosVendidosPorMes("12/" & cboAnio.Text)
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
