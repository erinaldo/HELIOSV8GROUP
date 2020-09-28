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

Public Class frmRptLibroMayor
    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "metodos"


    Public Sub años()
        Dim AniosSA As New empresaPeriodoSA
        cboAnios.DisplayMember = "periodo"
        cboAnios.ValueMember = "periodo"
        cboAnios.DataSource = AniosSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
    End Sub

    Public Sub BuscarMovimientosFull()
        Dim movimientoSA As New MovimientoSA
        For Each i In movimientoSA.BuscarMovimientosFull(AnioGeneral)
            listaCuenta.Add(i.cuenta)
        Next

    End Sub

    Public listaCuenta As New List(Of String)

#End Region

    Sub GetUbicarMovimientoLibroMayorFullMensual(listaCuenta As List(Of String), periodo As String, mesPer As String)
        Dim compraSA As New LibroMayorRPTSA
        Me.reportData = compraSA.GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, periodo, mesPer)
        ConsultaReporteMaster(AnioGeneral)
    End Sub

    Sub listaDeReporteLibroMayorFull(listaCuenta As List(Of String), periodo As String)
        Dim compraSA As New LibroMayorRPTSA
        Me.reportData = compraSA.GetUbicarMovimientoLibroMayorFull(listaCuenta, periodo)
        ConsultaReporteMaster(AnioGeneral)
    End Sub

    Sub listaDeReporteLibroMayorPorCuenta(listaCuenta As String)
        Dim compraSA As New LibroMayorRPTSA
        Me.reportData = compraSA.GetUbicarMovimientoLibroMayorPorIdDocumento(listaCuenta)
        ConsultaReporteMaster(AnioGeneral)
    End Sub

    Public Sub ConsultaReporteMaster(srtPeriodo As String)
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.LibroMayor.rdlc"
        Me.nombreMainDS = "DSLibroMayor"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptLibroMayor.KeepSessionAlive = True
        rptLibroMayor.Reset()
        rptLibroMayor.LocalReport.DataSources.Add(reporte)
        rptLibroMayor.LocalReport.Refresh()
        rptLibroMayor.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptLibroMayor.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", srtPeriodo))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa & "( " & GEstableciento.NombreEstablecimiento.ToLower & ")"))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        rptLibroMayor.LocalReport.SetParameters(oParams)
        rptLibroMayor.RefreshReport()
        rptLibroMayor.SetDisplayMode(DisplayMode.PrintLayout)
        rptLibroMayor.ZoomMode = ZoomMode.Percent
        rptLibroMayor.ZoomPercent = 100
    End Sub

    Private Sub frmRptLibroMayor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        años()

        BuscarMovimientosFull()
        Me.rptLibroMayor.RefreshReport()
    End Sub

    

    Private Sub rbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodo.CheckedChanged
        cboCuentas.Enabled = False

        Label2.Visible = False
        cboMes.Visible = False
    End Sub

    Private Sub rbPorCuenta_CheckedChanged(sender As Object, e As EventArgs) Handles rbPorCuenta.CheckedChanged
        cboCuentas.Enabled = True
        Label2.Visible = False
        cboMes.Visible = False
        cboCuentas.Visible = True


        cboCuentas.Items.Clear()
        For Each lista In listaCuenta

            cboCuentas.Items.Add(lista)
        Next
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If (rbTodo.Checked = True) Then
            listaDeReporteLibroMayorFull(listaCuenta, cboAnios.Text)


        ElseIf (rbMensual.Checked = True) Then

            If cboMes.Text = "ENERO" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "01")
            ElseIf cboMes.Text = "FEBRERO" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "02")
            ElseIf cboMes.Text = "MARZO" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "03")
            ElseIf cboMes.Text = "ABRIL" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "04")
            ElseIf cboMes.Text = "MAYO" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "05")
            ElseIf cboMes.Text = "JUNIO" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "06")
            ElseIf cboMes.Text = "JULIO" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "07")
            ElseIf cboMes.Text = "AGOSTO" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "08")
            ElseIf cboMes.Text = "SETIEMBRE" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "09")
            ElseIf cboMes.Text = "OCTUBRE" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "10")
            ElseIf cboMes.Text = "NOVIEMBRE" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "11")
            ElseIf cboMes.Text = "DICIEMBRE" Then
                GetUbicarMovimientoLibroMayorFullMensual(listaCuenta, cboAnios.Text, "12")
            End If



        ElseIf (rbPorCuenta.Checked = True) Then
            If (cboCuentas.SelectedItem = True) Then
                listaDeReporteLibroMayorPorCuenta(cboCuentas.SelectedItem.ToString)

            End If
        End If
    End Sub

  
    Private Sub rbMensual_CheckedChanged(sender As Object, e As EventArgs) Handles rbMensual.CheckedChanged
        Label2.Visible = True
        cboMes.Visible = True
        cboCuentas.Visible = False
    End Sub
End Class
