Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmInformeCuentaContableReporte
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

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
        oParams.Add(New ReportParameter("rpClase", strCuenta))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rpInformeCuentaContable.LocalReport.SetParameters(oParams)
        rpInformeCuentaContable.RefreshReport()
        rpInformeCuentaContable.SetDisplayMode(DisplayMode.PrintLayout)
        rpInformeCuentaContable.ZoomMode = ZoomMode.Percent
        rpInformeCuentaContable.ZoomPercent = 75
    End Sub

End Class