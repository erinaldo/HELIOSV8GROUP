Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class FrmProdItems

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "Métodos"


    Public Sub ConsultaReporteTotalesPorItems()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        'Dim prod As String
        'prod = lstProductos.SelectedItems(0).SubItems(0).Text
        'prod = lstProductos.Text
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteAlmacenPorItem.rdlc"
        Me.reportData = totalesAlmacenSA.GetListaProductosPorItems(CDec(frmReporteAlmacen.cboalmacen.ComboBox.SelectedValue), CDec(frmReporteAlmacen.cbotipoexistencia.ComboBox.SelectedValue))
        Me.nombreMainDS = "DSTotalesAlmacen2"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        frmReporteAlmacen.rptCompras.KeepSessionAlive = True
        frmReporteAlmacen.rptCompras.Reset()
        frmReporteAlmacen.rptCompras.LocalReport.DataSources.Add(reporte)
        frmReporteAlmacen.rptCompras.LocalReport.Refresh()
        frmReporteAlmacen.rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        frmReporteAlmacen.rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpAlmacen", frmReporteAlmacen.cboalmacen.ComboBox.Text))
        oParams.Add(New ReportParameter("rpItem", "CEMENTO"))
        frmReporteAlmacen.rptCompras.LocalReport.SetParameters(oParams)
        frmReporteAlmacen.rptCompras.RefreshReport()
        frmReporteAlmacen.rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        frmReporteAlmacen.rptCompras.ZoomMode = ZoomMode.Percent
        frmReporteAlmacen.rptCompras.ZoomPercent = 75
    End Sub



    Public Sub ObtenerItemsProd(idempresa As String, idestable As Integer)
        Dim almacenSA As New TotalesAlmacenSA
        lsvAlmacen.Items.Clear()
        For Each i As item In almacenSA.GetListaItemsProd(idempresa, idestable)
            Dim n As New ListViewItem(i.idItem)
            n.SubItems.Add(i.descripcion)
            lsvAlmacen.Items.Add(n)
        Next
        'If lsvAlmacen.Items.Count > 0 Then
        '    lsvAlmacen.Items(0).Selected = True
        '    lsvAlmacen.Items(0).Focused = True
        'End If
        'lblEstado.Text = "Almacenes encontrados: " & lsvAlmacen.Items.Count
        'lblEstado.Image = My.Resources.ok4
    End Sub

#End Region


    Private Sub FrmProdItems_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lsvAlmacen_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvAlmacen.MouseDoubleClick
        If lsvAlmacen.SelectedItems.Count > 0 Then
            'Dim n As New RecuperarCarteras()
            'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            'datos.Clear()
            'frmReporteAlmacen.lblIdItem.Text = lsvAlmacen.SelectedItems(0).SubItems(0).Text
            'frmReporteAlmacen.lblitem.Text = lsvAlmacen.SelectedItems(0).SubItems(1).Text


            ConsultaReporteTotalesPorItems()
            'datos.Add(n)
            Dispose()
        End If
    End Sub

    Private Sub lsvAlmacen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvAlmacen.SelectedIndexChanged

    End Sub
End Class