Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions

Public Class frmRptListadoFactura

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
        LoadAnios()
    End Sub


#Region "METODOS"

    Sub LoadAnios()
        Dim empresaPeriodoSA As New empresaPeriodoSA

        cboAnio.DataSource = empresaPeriodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.ValueMember = "periodo"
        cboAnio.DisplayMember = "periodo"

    End Sub


    Private Sub cbomes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMes.SelectedIndexChanged
        'If cbomes.Text = "ENERO" Then

        '    ConsultaReporteTotalesPorMes("01")

        'ElseIf cbomes.Text = "FEBRERO" Then
        '    ConsultaReporteTotalesPorMes("02")
        'ElseIf cbomes.Text = "MARZO" Then
        '    ConsultaReporteTotalesPorMes("03")
        'ElseIf cbomes.Text = "ABRIL" Then
        '    ConsultaReporteTotalesPorMes("04")
        'ElseIf cbomes.Text = "MAYO" Then
        '    ConsultaReporteTotalesPorMes("05")
        'ElseIf cbomes.Text = "JUNIO" Then
        '    ConsultaReporteTotalesPorMes("06")
        'ElseIf cbomes.Text = "JULIO" Then
        '    ConsultaReporteTotalesPorMes("07")
        'ElseIf cbomes.Text = "AGOSTO" Then
        '    ConsultaReporteTotalesPorMes("08")
        'ElseIf cbomes.Text = "SETIEMBRE" Then
        '    ConsultaReporteTotalesPorMes("09")
        'ElseIf cbomes.Text = "OCTUBRE" Then
        '    ConsultaReporteTotalesPorMes("10")
        'ElseIf cbomes.Text = "NOVIEMBRE" Then
        '    ConsultaReporteTotalesPorMes("11")
        'ElseIf cbomes.Text = "DICIEMBRE" Then
        '    ConsultaReporteTotalesPorMes("12")


        'End If
    End Sub

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



    Public Sub ConsultaReporteTotalesPorMes(mes As String, Anio As Integer)
        Dim totalesAlmacenSA As New documentoVentaRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteRegistroVentas.rdlc"
        Me.reportData = totalesAlmacenSA.OntenerListadoVentasAbarrotesPorMes(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, mes, Anio)
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
        oParams.Add(New ReportParameter("rpPeriodo", mes & "-" & Anio))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        rptAportes.LocalReport.SetParameters(oParams)
        rptAportes.RefreshReport()
        rptAportes.SetDisplayMode(DisplayMode.PrintLayout)
        rptAportes.ZoomMode = ZoomMode.Percent
        rptAportes.ZoomPercent = 75
    End Sub
#End Region

    Private Sub frmRptListadoFactura_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmRptListadoFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboAnio.Text = AnioGeneral
    End Sub

    Private Sub cboMes_Click(sender As Object, e As EventArgs) Handles cboMes.Click

    End Sub

    Private Sub cboMes_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMes.SelectedValueChanged

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If cboMes.Text = "ENERO" Then
            ConsultaReporteTotalesPorMes("01", Val(cboAnio.Text))
        ElseIf cboMes.Text = "FEBRERO" Then
            ConsultaReporteTotalesPorMes("02", Val(cboAnio.Text))
        ElseIf cboMes.Text = "MARZO" Then
            ConsultaReporteTotalesPorMes("03", Val(cboAnio.Text))
        ElseIf cboMes.Text = "ABRIL" Then
            ConsultaReporteTotalesPorMes("04", Val(cboAnio.Text))
        ElseIf cboMes.Text = "MAYO" Then
            ConsultaReporteTotalesPorMes("05", Val(cboAnio.Text))
        ElseIf cboMes.Text = "JUNIO" Then
            ConsultaReporteTotalesPorMes("06", Val(cboAnio.Text))
        ElseIf cboMes.Text = "JULIO" Then
            ConsultaReporteTotalesPorMes("07", Val(cboAnio.Text))
        ElseIf cboMes.Text = "AGOSTO" Then
            ConsultaReporteTotalesPorMes("08", Val(cboAnio.Text))
        ElseIf cboMes.Text = "SETIEMBRE" Then
            ConsultaReporteTotalesPorMes("09", Val(cboAnio.Text))
        ElseIf cboMes.Text = "OCTUBRE" Then
            ConsultaReporteTotalesPorMes("10", Val(cboAnio.Text))
        ElseIf cboMes.Text = "NOVIEMBRE" Then
            ConsultaReporteTotalesPorMes("11", Val(cboAnio.Text))
        ElseIf cboMes.Text = "DICIEMBRE" Then
            ConsultaReporteTotalesPorMes("12", Val(cboAnio.Text))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
