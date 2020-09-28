Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmCajausuario
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub ConsultaReporte(idCajaUsuario As Integer, idpersona As Integer, nombre As String, ident As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.aperturaCaja.rdlc"
        Me.reportData = cajaUsuarioSA.ResumenTransaccionesXusuarioCajaReporte(New cajaUsuario With {.idcajaUsuario = idCajaUsuario, .idPersona = idpersona})
        Me.nombreMainDS = "DSCaja"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCajaUsuario.KeepSessionAlive = True
        rptCajaUsuario.Reset()
        rptCajaUsuario.LocalReport.DataSources.Add(reporte)
        rptCajaUsuario.LocalReport.Refresh()
        rptCajaUsuario.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCajaUsuario.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpFecha", Date.Now.Date))
        oParams.Add(New ReportParameter("rpHora", Date.Now.Hour))
        oParams.Add(New ReportParameter("rpCajero", nombre))
        oParams.Add(New ReportParameter("rpIdentificacion", ident))

        rptCajaUsuario.LocalReport.SetParameters(oParams)
        rptCajaUsuario.RefreshReport()
        rptCajaUsuario.SetDisplayMode(DisplayMode.PrintLayout)
        rptCajaUsuario.ZoomMode = ZoomMode.Percent
        rptCajaUsuario.ZoomPercent = 75
    End Sub

End Class