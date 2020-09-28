Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmReporteLibroMayor
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    'Sub listaDeReporteLibroMayorFull(listaCuenta As List(Of String))
    '    Dim compraSA As New LibroMayorRPTSA
    '    Me.reportData = compraSA.GetUbicarMovimientoLibroMayorFull(listaCuenta)
    '    ConsultaReporteMaster(2014)
    'End Sub

    Sub listaDeReporteLibroMayorPorCuenta(listaCuenta As String)
        Dim compraSA As New LibroMayorRPTSA
        Me.reportData = compraSA.GetUbicarMovimientoLibroMayorPorIdDocumento(listaCuenta)
        ConsultaReporteMaster(2014)
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
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptLibroMayor.LocalReport.SetParameters(oParams)
        rptLibroMayor.RefreshReport()
        rptLibroMayor.SetDisplayMode(DisplayMode.PrintLayout)
        rptLibroMayor.ZoomMode = ZoomMode.Percent
        rptLibroMayor.ZoomPercent = 75
    End Sub

End Class