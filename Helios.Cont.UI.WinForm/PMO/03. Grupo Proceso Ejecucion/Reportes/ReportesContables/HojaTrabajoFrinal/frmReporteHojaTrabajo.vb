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

Public Class frmReporteHojaTrabajo

    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property reportData2 As Object
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

#End Region


    Sub listaDeReportesHojaTrabajoFinalFull(strPeriodo As Integer)
        Dim compraSA As New HojaTrabajoFinalRPTSA
        Me.reportData = compraSA.BuscarHojaTrabajoFinalFullReporte(strPeriodo)
        ConsultaReporteMaster(CStr(strPeriodo))
    End Sub

    Sub listaDeReportesAsientoPorMes(dtpPeriodoAnio As String, dtpPEriodoMes As String)
        Dim compraSA As New HojaTrabajoFinalRPTSA
        Dim cierreSA As New CierreContableSA

        Me.reportData = compraSA.BuscarHojaTrabajoFinalPorMesReporte(dtpPeriodoAnio, dtpPEriodoMes)
        Me.reportData2 = cierreSA.ReporteSaldoInicioXperiodo(dtpPeriodoAnio, dtpPEriodoMes)

        ConsultaReporteMaster(String.Concat(CStr(dtpPEriodoMes) + "/" + CStr(dtpPeriodoAnio)))
    End Sub

    Sub listaDeReportesHojaTrabajoPorAcumulado(dtpDesdeAnio As Date, dtphastaAnio As Date)
        Dim compraSA As New HojaTrabajoFinalRPTSA
        Me.reportData = compraSA.BuscarHojaTrabajoFinalPorAcumuladoReporte(dtpDesdeAnio, dtphastaAnio)
        ConsultaReporteMaster(String.Concat(CStr(dtpDesdeAnio) + " - " + CStr(dtphastaAnio)))
    End Sub

    Public Sub ConsultaReporteMaster(srtPeriodo As String)
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.HojaTrabajoFinal.rdlc"
        Me.nombreMainDS = "DSHojaTrabajoFinal"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        Dim reporte2 As New ReportDataSource("dsCierre", reportData2)

        rptHojaTrabajoFinal.KeepSessionAlive = True
        rptHojaTrabajoFinal.Reset()
        rptHojaTrabajoFinal.LocalReport.DataSources.Add(reporte)
        rptHojaTrabajoFinal.LocalReport.DataSources.Add(reporte2)

        rptHojaTrabajoFinal.LocalReport.Refresh()
        rptHojaTrabajoFinal.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptHojaTrabajoFinal.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", srtPeriodo))
        '  oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa & " " & GEstableciento.NombreEstablecimiento))
        ' oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptHojaTrabajoFinal.LocalReport.SetParameters(oParams)
        rptHojaTrabajoFinal.RefreshReport()
        rptHojaTrabajoFinal.SetDisplayMode(DisplayMode.PrintLayout)
        rptHojaTrabajoFinal.ZoomMode = ZoomMode.Percent
        rptHojaTrabajoFinal.ZoomPercent = 100
    End Sub

    Private Sub frmReporteHojaTrabajo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        años()
        cboAnios.Text = AnioGeneral
        Me.rptHojaTrabajoFinal.RefreshReport()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    If (rbAcumulado.Checked = True) Then
    '        Tag = TIPO_REPORTE.ACUMULADO
    '        listaDeReportesHojaTrabajoPorAcumulado(CDate(String.Concat(txtDesdeAnio.Text + txtDesdeA.Text)).Date, CDate(String.Concat(txtHastaAnio.Text + txtHastaD.Text)).Date)
    '        'StartPosition = FormStartPosition.CenterScreen
    '        'WindowState = FormWindowState.Maximized
    '        'Show()
    '    ElseIf (rbMensual.Checked = True) Then
    '        Tag = TIPO_REPORTE.PERIODO
    '        listaDeReportesAsientoPorMes((dtpPeriodoAnio.Value), (dtpPeriodoMes.Value))
    '        '.StartPosition = FormStartPosition.CenterScreen
    '        '.WindowState = FormWindowState.Maximized
    '        '.Show()
    '    ElseIf (rbTodo.Checked = True) Then
    '        Tag = TIPO_REPORTE.FULL
    '        listaDeReportesHojaTrabajoFinalFull(AnioGeneral)
    '        '.StartPosition = FormStartPosition.CenterScreen
    '        '.WindowState = FormWindowState.Maximized
    '        '.Show()

    '    End If
    'End Sub

    Private Sub rbAcumulado_CheckedChanged(sender As Object, e As EventArgs) Handles rbAcumulado.CheckedChanged
        If rbAcumulado.Checked = True Then

            Label4.Visible = False
            Label6.Visible = False
            cboAnios.Visible = False
            cboMes.Visible = False

            Label8.Visible = True
            Label7.Visible = True
            dtpini.Visible = True
            dtpfin.Visible = True

            '   Label5.Visible = False
            cboAnios.Visible = False

        End If
    End Sub

    Private Sub rbMensual_CheckedChanged(sender As Object, e As EventArgs) Handles rbMensual.CheckedChanged
        If rbMensual.Checked = True Then

            Label4.Visible = False
            Label6.Visible = True
            cboAnios.Visible = True
            cboMes.Visible = True

            Label8.Visible = False
            Label7.Visible = False
            dtpini.Visible = False
            dtpfin.Visible = False

            ' Label5.Visible = False
            cboAnios.Visible = True

        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If (rbAcumulado.Checked = True) Then
            Tag = TIPO_REPORTE.ACUMULADO
            listaDeReportesHojaTrabajoPorAcumulado(dtpini.Value, dtpfin.Value)


        ElseIf (rbMensual.Checked = True) Then


            If cboAnios.Text.Trim.Length > 0 Then
                Tag = TIPO_REPORTE.PERIODO
                'listaDeReportesAsientoPorMes(txtAnio.Text, (dtpPeriodoMes.Value))


                If cboMes.Text = "ENERO" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "01")


                ElseIf cboMes.Text = "FEBRERO" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "02")
                ElseIf cboMes.Text = "MARZO" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "03")
                ElseIf cboMes.Text = "ABRIL" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "04")
                ElseIf cboMes.Text = "MAYO" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "05")
                ElseIf cboMes.Text = "JUNIO" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "06")
                ElseIf cboMes.Text = "JULIO" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "07")
                ElseIf cboMes.Text = "AGOSTO" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "08")
                ElseIf cboMes.Text = "SETIEMBRE" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "09")
                ElseIf cboMes.Text = "OCTUBRE" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "10")
                ElseIf cboMes.Text = "NOVIEMBRE" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "11")
                ElseIf cboMes.Text = "DICIEMBRE" Then
                    listaDeReportesAsientoPorMes(cboAnios.Text, "12")
                End If


            Else
                MessageBox.Show("eliga un año")

            End If

        ElseIf (rbTodo.Checked = True) Then
        Tag = TIPO_REPORTE.FULL
        listaDeReportesHojaTrabajoFinalFull(cboAnios.Text)
        '.StartPosition = FormStartPosition.CenterScreen
        '.WindowState = FormWindowState.Maximized
        '.Show()

        End If
    End Sub

    Private Sub rbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodo.CheckedChanged
        If rbTodo.Checked = True Then

            Label4.Visible = True
            Label6.Visible = False
            cboAnios.Visible = False
            cboMes.Visible = False

            Label8.Visible = False
            Label7.Visible = False
            dtpini.Visible = False
            dtpfin.Visible = False

            '  Label5.Visible = True
            cboAnios.Visible = True

        End If
    End Sub
End Class
