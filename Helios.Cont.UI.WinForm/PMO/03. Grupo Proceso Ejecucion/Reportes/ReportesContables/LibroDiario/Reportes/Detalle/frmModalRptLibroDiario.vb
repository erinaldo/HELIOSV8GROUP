Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General.Constantes.TIPO_COMPRA

Public Class frmModalRptLibroDiario

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

    Sub listaDeReportesAsientoFull(strPeriodo As Integer)
        Dim compraSA As New LibroDiarioRPTSA
        Me.reportData = compraSA.UbicarReporteAsientosPorPeriodoFull(strPeriodo)
        ConsultaReporteMaster(CStr(strPeriodo))
    End Sub

    Sub listaDeReportesAsientoPorMes(dtpPeriodoAnio As String, dtpPEriodoMes As String)
        Dim compraSA As New LibroDiarioRPTSA
        Me.reportData = compraSA.UbicarReporteAsientoPorPeriodo(dtpPeriodoAnio, dtpPEriodoMes)
        ConsultaReporteMaster(String.Concat(CStr(dtpPEriodoMes) + "/" + CStr(dtpPeriodoAnio)))
    End Sub

    Sub listaDeReportesAsientoPorAcumulado(dtpDesdeAnio As Date, dtphastaAnio As Date)
        Dim compraSA As New LibroDiarioRPTSA
        Me.reportData = compraSA.UbicarReporteAsientoPorAcumulado(dtpDesdeAnio, dtphastaAnio)
        ConsultaReporteMaster(String.Concat(CStr(dtpDesdeAnio) + " - " + CStr(dtphastaAnio)))
    End Sub

#End Region

    Public Sub ConsultaReporteMaster(srtPeriodo As String)
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.LibroDiario.rdlc"
        Me.nombreMainDS = "DSLibroDiario"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptLibroDiario.KeepSessionAlive = True
        rptLibroDiario.Reset()
        rptLibroDiario.LocalReport.DataSources.Add(reporte)
        rptLibroDiario.LocalReport.Refresh()
        rptLibroDiario.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptLibroDiario.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", srtPeriodo))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa & " (" & GEstableciento.NombreEstablecimiento & ")"))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        rptLibroDiario.LocalReport.SetParameters(oParams)
        rptLibroDiario.RefreshReport()
        rptLibroDiario.SetDisplayMode(DisplayMode.PrintLayout)
        rptLibroDiario.ZoomMode = ZoomMode.Percent
        rptLibroDiario.ZoomPercent = 100
    End Sub


    Public Sub ConsultaReporte(ByVal strIdDocumento As Integer, ByVal strIdEntidad As Integer, _
                                ByVal strIdProveedor As Integer, ByVal dtpFechaInicio As Date, _
                                ByVal dtpFechaFin As Date, ByVal dtpPeridoMes As Date, _
                                ByVal dtpPEriodoAnio As Date, ByVal strPeriodoAnio As Integer)
        Dim compraSA As New LibroDiarioRPTSA
        Dim personaSA As New AsientoSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0

        Me.reportName = "Helios.Cont.Presentation.WinForm.LibroDiario.rdlc"

        Select Case Tag
            Case TIPO_REPORTE.FULL
                Me.reportData = compraSA.UbicarReporteAsientosPorPeriodoFull(strPeriodoAnio)
            Case "Documento"
                Me.reportData = compraSA.UbicarReporteAsientoPorDocumento(strIdDocumento)
            Case "Entidad"
                Me.reportData = compraSA.UbicarReporteAsientoPorEntidad(strIdProveedor)
            Case "Código Libro"
                Me.reportData = compraSA.UbicarReporteAsientoPorTipo(strIdEntidad)
            Case "Fecha Progreso"
                Me.reportData = compraSA.UbicarReporteAsientoPorFecha(dtpFechaInicio, dtpFechaFin, strIdEntidad)
            Case "Período"
                Me.reportData = compraSA.UbicarReporteAsientoPorPeriodo(dtpPeridoMes, dtpPEriodoAnio)
        End Select
        'Me.reportData = compraSA.ObtenerAsientosPorPeriodoFullReporte()

        Me.nombreMainDS = "DSLibroDiario"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptLibroDiario.KeepSessionAlive = True
        rptLibroDiario.Reset()
        rptLibroDiario.LocalReport.DataSources.Add(reporte)
        rptLibroDiario.LocalReport.Refresh()
        rptLibroDiario.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptLibroDiario.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        'oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        rptLibroDiario.LocalReport.SetParameters(oParams)
        rptLibroDiario.RefreshReport()
        rptLibroDiario.SetDisplayMode(DisplayMode.PrintLayout)
        rptLibroDiario.ZoomMode = ZoomMode.Percent
        rptLibroDiario.ZoomPercent = 100
    End Sub

    Private Sub frmModalRptLibroDiario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        años()
        cboAnios.Text = AnioGeneral
        Me.rptLibroDiario.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If (rbAcumulado.Checked = True) Then
            Tag = TIPO_REPORTE.ACUMULADO
            listaDeReportesAsientoPorAcumulado(dtpini.Value, dtpfin.Value)

        ElseIf (rbMensual.Checked = True) Then
            Tag = TIPO_REPORTE.PERIODO

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


        ElseIf (rbTodo.Checked = True) Then
            Tag = TIPO_REPORTE.FULL
            listaDeReportesAsientoFull(cboAnios.Text)

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbMensual_CheckedChanged(sender As Object, e As EventArgs) Handles rbMensual.CheckedChanged
        If rbMensual.Checked = True Then
            '  Label4.Visible = True
            Label2.Visible = True
            cboMes.Visible = True

            Label7.Visible = False
            Label8.Visible = False
            dtpini.Visible = False
            dtpfin.Visible = False

            Label5.Visible = True
            cboAnios.Visible = True
        End If
    End Sub

    Private Sub rbAcumulado_CheckedChanged(sender As Object, e As EventArgs) Handles rbAcumulado.CheckedChanged
        If rbAcumulado.Checked = True Then
            '      Label4.Visible = False
            cboMes.Visible = False
            cboAnios.Visible = False
            Label2.Visible = False

            Label7.Visible = True
            Label8.Visible = True
            dtpini.Visible = True
            dtpfin.Visible = True

            Label5.Visible = False
            cboAnios.Visible = False
        End If
    End Sub

    Private Sub rbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodo.CheckedChanged
        If rbTodo.Checked = True Then
        
            cboMes.Visible = False
            Label2.Visible = False
            Label7.Visible = False
            Label8.Visible = False
            dtpini.Visible = False
            dtpfin.Visible = False

            Label5.Visible = True
            cboAnios.Visible = True
        End If
    End Sub
End Class
