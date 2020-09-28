Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmCajaUsuarioCierre
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub ConsultaReporte(cajaUsuatio As List(Of cajaUsuario), nombre As String, ident As Integer, FIngreso As Decimal, FEgreso As Decimal, FTotal As Decimal, FApertura As Decimal)
        Dim cajaUsuarioSA As New cajaUsuarioRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.cierreCaja.rdlc"
        'Me.reportData = cajaUsuarioSA.ResumenTransaccionesXusuarioCajaReporte(New cajaUsuario With {.idcajaUsuario = idCajaUsuario, .idPersona = idpersona, .fechaRegistro = fechaRegistro})
        'Me.reportData = cajaUsuatio
        'Me.nombreMainDS = "DSCajaDetalle"
        'Dim reporte As New ReportDataSource(nombreMainDS)
        rptCierreCaja.KeepSessionAlive = True
        rptCierreCaja.Reset()
        'rptCierreCaja.LocalReport.DataSources.Add(reporte)
        rptCierreCaja.LocalReport.Refresh()
        rptCierreCaja.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCierreCaja.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpFecha", Date.Now.Date))
        oParams.Add(New ReportParameter("rpHora", Date.Now.Hour))
        oParams.Add(New ReportParameter("rpCajero", nombre))
        oParams.Add(New ReportParameter("rpIdentificacion", ident))
        oParams.Add(New ReportParameter("rpInicio", CDec(FIngreso).ToString("N2")))
        oParams.Add(New ReportParameter("rpEgreso", CDec(FEgreso).ToString("N2")))
        oParams.Add(New ReportParameter("rpCierre", CDec(FTotal).ToString("N2")))
        oParams.Add(New ReportParameter("rpFondo", CDec(FApertura).ToString("N2")))

        rptCierreCaja.LocalReport.SetParameters(oParams)
        rptCierreCaja.RefreshReport()
        rptCierreCaja.SetDisplayMode(DisplayMode.PrintLayout)
        rptCierreCaja.ZoomMode = ZoomMode.Percent
        rptCierreCaja.ZoomPercent = 75
    End Sub

    'Public Sub ConsultaReporte(cajaUsuatio As List(Of cajaUsuario), nombre As String, ident As Integer)
    '    Dim cajaUsuarioSA As New cajaUsuarioRPTSA
    '    Dim totalUtilidad As Decimal = 0
    '    Dim totalUtilidadme As Decimal = 0
    '    Dim totalVentas As Decimal = 0
    '    Me.reportName = "Helios.Cont.Presentation.WinForm.cierreCaja.rdlc"
    '    'Me.reportData = cajaUsuarioSA.ResumenTransaccionesXusuarioCajaReporte(New cajaUsuario With {.idcajaUsuario = idCajaUsuario, .idPersona = idpersona, .fechaRegistro = fechaRegistro})
    '    Me.reportData = cajaUsuatio
    '    Me.nombreMainDS = "DSCajaDetalle"
    '    Dim reporte As New ReportDataSource(nombreMainDS, reportData)
    '    rptCierreCaja.KeepSessionAlive = True
    '    rptCierreCaja.Reset()
    '    rptCierreCaja.LocalReport.DataSources.Add(reporte)
    '    rptCierreCaja.LocalReport.Refresh()
    '    rptCierreCaja.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
    '    rptCierreCaja.LocalReport.ReportEmbeddedResource = reportName
    '    Dim oParams As New List(Of ReportParameter)
    '    oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
    '    oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
    '    oParams.Add(New ReportParameter("rpFecha", Date.Now.Date))
    '    oParams.Add(New ReportParameter("rpHora", Date.Now.Hour))
    '    oParams.Add(New ReportParameter("rpCajero", nombre))
    '    oParams.Add(New ReportParameter("rpIdentificacion", ident))

    '    rptCierreCaja.LocalReport.SetParameters(oParams)
    '    rptCierreCaja.RefreshReport()
    '    rptCierreCaja.SetDisplayMode(DisplayMode.PrintLayout)
    '    rptCierreCaja.ZoomMode = ZoomMode.Percent
    '    rptCierreCaja.ZoomPercent = 75
    'End Sub


    Public Sub ConsultaReportePost(idCajaUsuario As Integer, idpersona As Integer, nombre As String, ident As Integer, fechaRegistro As DateTime)
        Dim cajaUsuarioSA As New cajaUsuarioRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.cierreCaja.rdlc"
        Me.reportData = cajaUsuarioSA.ResumenTransaccionesXusuarioCajaReporte(New cajaUsuario With {.idcajaUsuario = idCajaUsuario, .idPersona = idpersona, .fechaRegistro = fechaRegistro})
        Me.nombreMainDS = "DSCajaDetalle"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCierreCaja.KeepSessionAlive = True
        rptCierreCaja.Reset()
        rptCierreCaja.LocalReport.DataSources.Add(reporte)
        rptCierreCaja.LocalReport.Refresh()
        rptCierreCaja.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCierreCaja.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpFecha", Date.Now.Date))
        oParams.Add(New ReportParameter("rpHora", Date.Now.Hour))
        oParams.Add(New ReportParameter("rpCajero", nombre))
        oParams.Add(New ReportParameter("rpIdentificacion", ident))

        rptCierreCaja.LocalReport.SetParameters(oParams)
        rptCierreCaja.RefreshReport()
        rptCierreCaja.SetDisplayMode(DisplayMode.PrintLayout)
        rptCierreCaja.ZoomMode = ZoomMode.Percent
        rptCierreCaja.ZoomPercent = 75
    End Sub




End Class