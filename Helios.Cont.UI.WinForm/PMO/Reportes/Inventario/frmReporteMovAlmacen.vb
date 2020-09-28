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
Public Class frmReporteMovAlmacen
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
        GetAnios()
    End Sub

#Region "Métodos"

    Public Sub ConsultaReporteMovimientosPorPeriodo(strPeriodo As String)
        Dim totalesAlmacenSA As New DocumentoCompraSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvMovAlmacenByPeriodo.rdlc"
        Me.reportData = totalesAlmacenSA.GetReporteMovAlmcenByEntradaSalida(GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSMov"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpAnio", strPeriodo))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

    Public Sub ConsultaTransferenciaPorPeriodo(strPeriodo As String)
        Dim totalesAlmacenSA As New DocumentoCompraSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvTransferencia.rdlc"
        Me.reportData = totalesAlmacenSA.GetReporteTransferenciaAlmacen(GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSMov"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpAnio", strPeriodo))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

    Public Sub GetAnios()
        Dim periodoSA As New empresaPeriodoSA

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = periodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral

    End Sub
#End Region

    Private Sub frmReporteMovAlmacen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case cboMes.Text

            Case "ENERO"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("01/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("01/" & AnioGeneral)
                End If

            Case "FEBRERO"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("02/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("02/" & AnioGeneral)
                End If

            Case "MARZO"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("03/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("03/" & AnioGeneral)
                End If

            Case "ABRIL"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("04/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("04/" & AnioGeneral)
                End If

            Case "MAYO"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("05/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("05/" & AnioGeneral)
                End If

            Case "JUNIO"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("06/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("06/" & AnioGeneral)
                End If

            Case "JULIO"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("07/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("07/" & AnioGeneral)
                End If

            Case "AGOSTO"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("08/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("08/" & AnioGeneral)
                End If

            Case "SETIEMBRE"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("09/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("09/" & AnioGeneral)
                End If

            Case "OCTUBRE"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("10/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("10/" & AnioGeneral)
                End If

            Case "NOVIEMBRE"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("11/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("11/" & AnioGeneral)
                End If

            Case "DICIEMBRE"
                If cboModulo.Text = "Entrada y Sálida de almacén" Then
                    ConsultaReporteMovimientosPorPeriodo("12/" & AnioGeneral)
                Else
                    ConsultaTransferenciaPorPeriodo("12/" & AnioGeneral)
                End If

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
