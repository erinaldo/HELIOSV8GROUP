Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmCostoByGastos
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
        cboTipo.SelectedIndex = 0
    End Sub

#Region "Métodos"
    Public Sub GetGastos(subtipo As String)
        Dim recursoSA As New recursoCostoSA

        cbogasto.DisplayMember = "nombreCosto"
        cbogasto.ValueMember = "idCosto"

        Select Case subtipo
            Case "GASTO ADMINISTRATIVO"
                cbogasto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
            Case "GASTO FINANCIERO"
                cbogasto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})
            Case "GASTO DE VENTAS"
                cbogasto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
        End Select


    End Sub


    Public Sub ConsultaReporteCosto()
        Dim costoSA As New recursoCostoSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvCostoByGasto.rdlc"
        Me.reportData = costoSA.GetResporteItemsByGastos(New recursoCosto With {.idCosto = cbogasto.SelectedValue})
        Me.nombreMainDS = "DSCosto"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpGasto", cbogasto.Text))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub
#End Region

    Private Sub frmCostoByGastos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       

    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cboTipo.Text.Trim.Length > 0 Then
            GetGastos(cboTipo.Text)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If cbogasto.Text.Trim.Length > 0 Then
            ConsultaReporteCosto()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
