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
Public Class frmReporteNotaCredito
    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadProveedores()
        cboProv.Text = "Todos los proveedores"
        txtINic.Value = New DateTime(AnioGeneral, Date.Now.Month, 1)
        txtHasta.Value = New DateTime(AnioGeneral, Date.Now.Month, Date.Now.Day)
    End Sub

#Region "Métodos"
    Sub LoadProveedores()
        Dim eNtidadSA As New entidadSA
        Dim eNtidad As New List(Of entidad)
        Dim objENtidad As New entidad With {.idEntidad = -1, .nombreCompleto = "Todos los proveedores", .nrodoc = 0}


        eNtidad = eNtidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        eNtidad.Add(objENtidad)

        cboProv.DisplayMember = "nombreCompleto"
        cboProv.ValueMember = "idEntidad"
        cboProv.DataSource = eNtidad
    End Sub

    Public Sub ConsultaReporte(fecINic As DateTime, fecHasta As DateTime, idProv As Integer)
        Dim DocumentoCompraSA As New documentoCompraRPTSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvNotaCredito.rdlc"
        Me.reportData = DocumentoCompraSA.LidtadoNotasXempresa(fecINic, fecHasta, idProv)
        Me.nombreMainDS = "DSNotas"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpFecha", txtINic.Value.ToShortDateString & " al " & txtHasta.Value.ToShortDateString))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
    End Sub

#End Region

    Private Sub frmReporteNotaCredito_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '     Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        ConsultaReporte(txtINic.Value, txtHasta.Value, cboProv.SelectedValue)
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
