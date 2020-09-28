Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmArticulosVendidosByDia
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
        txtFecha.Value = DateTime.Now
    End Sub


#Region "Métodos"

    Public Sub ConsultaReporteArticulosVendidosPorDia()
        Dim ventaSA As New documentoVentaAbarrotesSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvArticulosVendidosPorDia.rdlc"
        Me.reportData = ventaSA.GetArticulosVendidosByDia(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFecha.Value})
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
        oParams.Add(New ReportParameter("rpDia", txtFecha.Value.Date))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

#End Region

    Private Sub frmArticulosVendidosByDia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmArticulosVendidosBydia_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        ConsultaReporteArticulosVendidosPorDia()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
