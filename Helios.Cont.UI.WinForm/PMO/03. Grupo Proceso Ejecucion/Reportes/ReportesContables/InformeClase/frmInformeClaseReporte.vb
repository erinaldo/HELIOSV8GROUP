Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmInformeClaseReporte
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Sub listaDeReporteInformePorClase(strCuenta As String)
        Dim compraSA As New InformeClaseRPTSA
        'Me.reportData = compraSA.BuscarInformePorClaseReporte(strCuenta)
        ConsultaReporteMaster(2014, strCuenta)
    End Sub

    Sub listaDeReporteInformePorClaseMes(strFechaDesde As Date, strFechaHasta As Date, strCuenta As String)
        Dim compraSA As New InformeClaseRPTSA
        Me.reportData = compraSA.BuscarInformePorClaseAcumuladoReporte(strFechaDesde, strFechaHasta, strCuenta)
        ConsultaReporteMaster(2014, strCuenta)
    End Sub

    Sub listaDeReporteInformePorClaseAcumulado(strPeriodo As Date, intMes As Date, strCuenta As String)
        Dim compraSA As New InformeClaseRPTSA
        Me.reportData = compraSA.BuscarInformePorClaseMesReporte(strPeriodo, intMes, strCuenta)
        ConsultaReporteMaster(2014, strCuenta)
    End Sub

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
        oParams.Add(New ReportParameter("rpClase", strCuenta))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptInformeClase.LocalReport.SetParameters(oParams)
        rptInformeClase.RefreshReport()
        rptInformeClase.SetDisplayMode(DisplayMode.PrintLayout)
        rptInformeClase.ZoomMode = ZoomMode.Percent
        rptInformeClase.ZoomPercent = 75
    End Sub
End Class