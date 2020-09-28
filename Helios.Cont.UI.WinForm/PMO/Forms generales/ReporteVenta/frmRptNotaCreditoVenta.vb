Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions

Public Class frmRptNotaCreditoVenta

    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "metodos"

    Public Sub ObtenerListaControlesLoad()
        Dim eNtidadSA As New entidadSA
        Dim eNtidad As New List(Of entidad)

        Dim objENtidad As New entidad With {.idEntidad = -1, .nombreCompleto = "Todos los clientes", .nrodoc = 0}
        eNtidad = eNtidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        eNtidad.Add(objENtidad)

        cbocliente.ValueMember = "idEntidad"
        cbocliente.DisplayMember = "nombreCompleto"
        cbocliente.DataSource = eNtidad
    End Sub


    Public Sub ConsultaReportePorCliente(idclie As Integer, ini As Date, fin As Date)
        Dim totalesAlmacenSA As New documentoVentaAbarrotesSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.RptNotaCreditoVenta.rdlc"
        Me.reportData = totalesAlmacenSA.ListadoNotasXCliente(ini, fin, idclie)
        Me.nombreMainDS = "dsnota"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        'oParams.Add(New ReportParameter("rpPeriodo", PeriodoGeneral))
        oParams.Add(New ReportParameter("rpFecha", dtpini.Value.ToShortDateString & " al " & dtpfin.Value.ToShortDateString))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

#End Region

    Private Sub frmRptNotaCreditoVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmRptNotaCreditoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpini.Value = DateTime.Now
        dtpfin.Value = DateTime.Now

        ObtenerListaControlesLoad()

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        ConsultaReportePorCliente(cbocliente.SelectedValue, dtpini.Value, dtpfin.Value)
    End Sub
End Class
