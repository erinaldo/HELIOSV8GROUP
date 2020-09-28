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

Imports Helios.General.Constantes.TIPO_COMPRA


Public Class frmRptClaseReporte

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

    Sub listaDeReporteInformePorClase(strCuenta As String, anio As String)
        Dim compraSA As New InformeClaseRPTSA
        Me.reportData = compraSA.BuscarInformePorClaseReporte(strCuenta, anio)
        ConsultaReporteMaster(cboAnios.Text, strCuenta)
    End Sub

    Sub listaDeReporteInformePorClaseMes(strFechaDesde As Date, strFechaHasta As Date, strCuenta As String)
        Dim compraSA As New InformeClaseRPTSA
        Me.reportData = compraSA.BuscarInformePorClaseAcumuladoReporte(strFechaDesde, strFechaHasta, strCuenta)
        ConsultaReporteMaster(AnioGeneral, strCuenta)
    End Sub

    Sub listaDeReporteInformePorClaseAcumulado(strPeriodo As String, intMes As String, strCuenta As String)
        Dim compraSA As New InformeClaseRPTSA
        Me.reportData = compraSA.BuscarInformePorClaseMesReporte(strPeriodo, intMes, strCuenta)
        ConsultaReporteMaster(cboAnios.Text, strCuenta)
    End Sub

#End Region

    

    Public Sub ConsultaReporteMaster(srtPeriodo As String, strCuenta As String)
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.InformeClase.rdlc"
        Me.nombreMainDS = "DSInformeClase"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptInformeClase.KeepSessionAlive = True
        rptInformeClase.Reset()
        rptInformeClase.LocalReport.DataSources.Add(reporte)
        rptInformeClase.LocalReport.Refresh()
        rptInformeClase.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptInformeClase.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", srtPeriodo))
        oParams.Add(New ReportParameter("rpClase", "Clase: " & strCuenta))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa & " (" & GEstableciento.NombreEstablecimiento.ToLower & ")"))
        rptInformeClase.LocalReport.SetParameters(oParams)
        rptInformeClase.RefreshReport()
        rptInformeClase.SetDisplayMode(DisplayMode.PrintLayout)
        rptInformeClase.ZoomMode = ZoomMode.Percent
        rptInformeClase.ZoomPercent = 100
    End Sub

    Private Sub frmRptClaseReporte_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        años()
        cboAnios.Text = AnioGeneral


        Label4.Visible = False
        Label5.Visible = False
        dtpini.Visible = False
        dtpfin.Visible = False
        Label2.Visible = True
        cboAnios.Visible = True

        '   Label3.Visible = False
        Label6.Visible = False
        cboMes.Visible = False


        Me.rptInformeClase.RefreshReport()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If (txtClase.Text.Length > 0) Then

            If (rbTodo.Checked = True) Then
                listaDeReporteInformePorClase(txtClase.Text, cboAnios.Text)
            ElseIf (rbAcumulado.Checked = True) Then

                listaDeReporteInformePorClaseMes(dtpini.Value, dtpfin.Value, txtClase.Text)

            ElseIf (rbMensual.Checked = True) Then

                If cboMes.Text = "ENERO" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "01", txtClase.Text)
                ElseIf cboMes.Text = "FEBRERO" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "02", txtClase.Text)
                ElseIf cboMes.Text = "MARZO" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "03", txtClase.Text)
                ElseIf cboMes.Text = "ABRIL" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "04", txtClase.Text)
                ElseIf cboMes.Text = "MAYO" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "05", txtClase.Text)
                ElseIf cboMes.Text = "JUNIO" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "06", txtClase.Text)
                ElseIf cboMes.Text = "JULIO" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "07", txtClase.Text)
                ElseIf cboMes.Text = "AGOSTO" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "08", txtClase.Text)
                ElseIf cboMes.Text = "SETIEMBRE" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "09", txtClase.Text)
                ElseIf cboMes.Text = "OCTUBRE" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "10", txtClase.Text)
                ElseIf cboMes.Text = "NOVIEMBRE" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "11", txtClase.Text)
                ElseIf cboMes.Text = "DICIEMBRE" Then
                    listaDeReporteInformePorClaseAcumulado(cboAnios.Text, "12", txtClase.Text)
                End If

            End If

        Else
            MessageBox.Show("Escriba una cuenta a buscar", "Atención", Nothing, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbMensual_CheckedChanged(sender As Object, e As EventArgs) Handles rbMensual.CheckedChanged
        If rbMensual.Checked = True Then
            Label4.Visible = False
            Label5.Visible = False
            dtpini.Visible = False
            dtpfin.Visible = False
            Label2.Visible = True
            cboAnios.Visible = False

            '     Label3.Visible = True
            Label6.Visible = True
            cboAnios.Visible = True
            cboMes.Visible = True
        End If
    End Sub

    Private Sub rbAcumulado_CheckedChanged(sender As Object, e As EventArgs) Handles rbAcumulado.CheckedChanged


        If rbAcumulado.Checked = True Then
            Label4.Visible = True
            Label5.Visible = True
            dtpini.Visible = True
            dtpfin.Visible = True
            Label2.Visible = False
            cboAnios.Visible = False

            '     Label3.Visible = False
            Label6.Visible = False
            cboAnios.Visible = False
            cboMes.Visible = False
        End If

    End Sub

    Private Sub rbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodo.CheckedChanged
        If rbTodo.Checked = True Then
            Label4.Visible = False
            Label5.Visible = False
            dtpini.Visible = False
            dtpfin.Visible = False

            Label2.Visible = True
            cboAnios.Visible = True

            '     Label3.Visible = False
            Label6.Visible = False
            cboMes.Visible = False
        End If
    End Sub
End Class
