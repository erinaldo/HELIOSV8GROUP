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
Public Class frmReporteListaInventario
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
        LoadCMB()
    End Sub

#Region "Métodos"
    Sub LoadCMB()
        Dim lista As List(Of tabladetalle)
        Dim TablaSA As New tablaDetalleSA
        Dim estableSA As New establecimientoSA
        cboEstable.DisplayMember = "nombre"
        cboEstable.ValueMember = "idCentroCosto"
        cboEstable.DataSource = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)

        lista = New List(Of tabladetalle)
        lista = TablaSA.GetListaTablaDetalle(5, "1")
        lista.Add(New tabladetalle With {.idtabla = 5, .codigoDetalle = "00", .codigoDetalle2 = "00", .descripcion = "-Todos-"})

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = lista
    End Sub

    Sub LoadALmaceN(iNtEstablecimi As Integer)
        Dim almaceNSA As New almacenSA
        Dim lista As New List(Of almacen)
        Dim source As New List(Of almacen)

        lista = almaceNSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = iNtEstablecimi, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        'source.Add(New almacen With {.idAlmacen = 0, .descripcionAlmacen = "-Todos-"})
        source.AddRange(lista)

        cboAlmace.DisplayMember = "descripcionAlmacen"
        cboAlmace.ValueMember = "idAlmacen"
        cboAlmace.DataSource = source 'almaceNSA.GetListar_almacenExceptAV(iNtEstablecimi)
    End Sub

    Public Sub ConsultaReporte()
        Dim TotalesAlmacenSA As New TotalesAlmacenSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvListadoINveNtario.rdlc"
        Me.reportData = TotalesAlmacenSA.GetProductosByAlmacen(cboAlmace.SelectedValue, cboTipoExistencia.SelectedValue) ' DocumentoCompraSA.GetListaProductosPorAlmacen(cboAlmace.SelectedValue)
        Me.nombreMainDS = "DSProductos"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa & " (" & cboEstable.Text & ")"))
        oParams.Add(New ReportParameter("rpAlmacen", cboAlmace.Text & ", al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
    End Sub

    Public Sub ConsultaReporteByEstablecimiento()
        Dim DocumentoCompraSA As New TotalesAlmacenSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvInventarioFull.rdlc"
        Me.reportData = DocumentoCompraSA.GetListaProductosByEstablecimiento(GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DSProductos"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa & " (" & cboEstable.Text & ")"))
        oParams.Add(New ReportParameter("rpPeriodo", "Al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
    End Sub
#End Region

    Private Sub frmReporteListaInventario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub cboEstable_Click(sender As Object, e As EventArgs) Handles cboEstable.Click

    End Sub

    Private Sub cboEstable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstable.SelectedIndexChanged
        LoadALmaceN(cboEstable.SelectedValue)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If cboAlmace.SelectedValue = 0 Then
            ConsultaReporteByEstablecimiento()
        Else
            ConsultaReporte()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
