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

Public Class frmRptCuentaContable

    Inherits frmMaster


    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String


#Region "metodos"

    Public listaCuenta As New List(Of String)

    Public Sub BuscarMovimientosFull()
        Dim movimientoSA As New MovimientoSA
        For Each i In movimientoSA.BuscarMovimientosFull(AnioGeneral)
            listaCuenta.Add(i.cuenta)
        Next

    End Sub

    Sub llenarCuentas(strCuenta As List(Of String))
        cboCuentas.Items.Clear()
        txtClase.Clear()
        For Each lista In strCuenta
            cboCuentas.Items.Add(lista)
        Next
    End Sub
#End Region

    Sub listaDeReporteInformePorCuentaContable(strCuenta As String, strRazonSocial As String)
        Dim compraSA As New InformeCuentaContableRPTSA
        Me.reportData = compraSA.BuscarInformePorCuentaContableReporte(strCuenta, strRazonSocial)
        ConsultaReporteMaster(PeriodoGeneral, strCuenta)
    End Sub

    Public Sub ConsultaReporteMaster(srtPeriodo As String, strCuenta As String)
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.InformeCuentaContable.rdlc"
        Me.nombreMainDS = "DSInformeCuentaContable"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rpInformeCuentaContable.KeepSessionAlive = True
        rpInformeCuentaContable.Reset()
        rpInformeCuentaContable.LocalReport.DataSources.Add(reporte)
        rpInformeCuentaContable.LocalReport.Refresh()
        rpInformeCuentaContable.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rpInformeCuentaContable.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", srtPeriodo))
        oParams.Add(New ReportParameter("rpClase", "Cuenta - " & strCuenta))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa & " (" & GEstableciento.NombreEstablecimiento.ToLower & ")"))
        rpInformeCuentaContable.LocalReport.SetParameters(oParams)
        rpInformeCuentaContable.RefreshReport()
        rpInformeCuentaContable.SetDisplayMode(DisplayMode.PrintLayout)
        rpInformeCuentaContable.ZoomMode = ZoomMode.Percent
        rpInformeCuentaContable.ZoomPercent = 100
    End Sub

    Private Sub frmRptCuentaContable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarMovimientosFull()

        llenarCuentas(listaCuenta)
        Me.rpInformeCuentaContable.RefreshReport()
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If (cboRazonSocial.Text.Length > 0) Then
            listaDeReporteInformePorCuentaContable(cboCuentas.SelectedItem, cboRazonSocial.SelectedItem)
        End If
    End Sub

    Private Sub cboCuentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCuentas.SelectedIndexChanged
        Dim compraSA As New MovimientoSA
        cboRazonSocial.Items.Clear()
        cboRazonSocial.Text = String.Empty
        For Each lista In compraSA.GetUbicarMovimiento(cboCuentas.SelectedItem)
            cboRazonSocial.Items.Add(lista.nombreEntidad)
            txtClase.Text = lista.descripcion
        Next
    End Sub
End Class
