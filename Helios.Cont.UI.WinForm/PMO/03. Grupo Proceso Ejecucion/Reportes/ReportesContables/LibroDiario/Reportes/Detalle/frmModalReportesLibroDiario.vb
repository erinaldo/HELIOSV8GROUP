Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General.Constantes.TIPO_COMPRA

Public Class frmModalReportesLibroDiario
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Sub listaDeReportesAsientoFull(strPeriodo As Integer)
        Dim compraSA As New LibroDiarioRPTSA
        Me.reportData = compraSA.UbicarReporteAsientosPorPeriodoFull(strPeriodo)
        ConsultaReporteMaster(CStr(strPeriodo))
    End Sub

    Sub listaDeReportesAsientoPorMes(dtpPeriodoAnio As Date, dtpPEriodoMes As Date)
        Dim compraSA As New LibroDiarioRPTSA
        Me.reportData = compraSA.UbicarReporteAsientoPorPeriodo(dtpPeriodoAnio, dtpPEriodoMes)
        ConsultaReporteMaster(String.Concat(CStr(dtpPEriodoMes) + "/" + CStr(dtpPeriodoAnio)))
    End Sub

    Sub listaDeReportesAsientoPorAcumulado(dtpDesdeAnio As Date, dtphastaAnio As Date)
        Dim compraSA As New LibroDiarioRPTSA
        Me.reportData = compraSA.UbicarReporteAsientoPorPeriodo(dtpDesdeAnio, dtphastaAnio)
        ConsultaReporteMaster(String.Concat(CStr(dtpDesdeAnio) + " - " + CStr(dtphastaAnio)))
    End Sub

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
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptLibroDiario.LocalReport.SetParameters(oParams)
        rptLibroDiario.RefreshReport()
        rptLibroDiario.SetDisplayMode(DisplayMode.PrintLayout)
        rptLibroDiario.ZoomMode = ZoomMode.Percent
        rptLibroDiario.ZoomPercent = 75
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
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptLibroDiario.LocalReport.SetParameters(oParams)
        rptLibroDiario.RefreshReport()
        rptLibroDiario.SetDisplayMode(DisplayMode.PrintLayout)
        rptLibroDiario.ZoomMode = ZoomMode.Percent
        rptLibroDiario.ZoomPercent = 75
    End Sub

    Private Sub frmModalReportesLibroDiario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        '  frmPMO.Panel3.Width = 249
        Dispose()
    End Sub
End Class