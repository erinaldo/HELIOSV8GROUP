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
Public Class ReporteKardexXproducto
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
        txtINic.Value = New DateTime(DateTime.Now.Year, 1, 1)
        txtHasta.Value = New DateTime(DateTime.Now.Year, Date.Now.Month, DateTime.Now.Day)
    End Sub

#Region "Métodos"
    Sub LoadCMB()
        Dim tablaSA As New tablaDetalleSA
        Dim estableSA As New establecimientoSA
        cboEstable.DisplayMember = "nombre"
        cboEstable.ValueMember = "idCentroCosto"
        cboEstable.DataSource = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)


        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")
    End Sub

    Sub LoadALmaceN(iNtEstablecimi As Integer)
        Dim almaceNSA As New almacenSA
        cboAlmace.DisplayMember = "descripcionAlmacen"
        cboAlmace.ValueMember = "idAlmacen"
        cboAlmace.DataSource = almaceNSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = iNtEstablecimi, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub


    Public Sub ObetnerListaProductosLSTPorItem(intIdAlmacen As Integer, strProducto As String, strTipoExistencia As String)
        Dim totalesSA As New TotalesAlmacenSA

        lstProductos.DisplayMember = "descripcion"
        lstProductos.ValueMember = "idItem"
        lstProductos.DataSource = totalesSA.GetProductoPorAlmacenTipoEx(intIdAlmacen, strTipoExistencia, strProducto)

    End Sub


    Public Sub ConsultaReporte(fecINic As DateTime, fecHasta As DateTime)
        Dim DocumentoCompraSA As New inventarioMovimientoRPTSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvReporteKardexXproducto.rdlc"
        Me.reportData = DocumentoCompraSA.ReporteKardexPorProducto(cboAlmace.SelectedValue, txtBuscarProducto.Tag, fecINic, fecHasta)
        Me.nombreMainDS = "DSDatos"
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

        oParams.Add(New ReportParameter("rpAlmacen", cboAlmace.Text))
        oParams.Add(New ReportParameter("rpProducto", txtBuscarProducto.Text))
        oParams.Add(New ReportParameter("rpTipoEx", cboTipoExistencia.Text))

        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
    End Sub

#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                '   If txtAlmacen.Text.Trim.Length > 0 Then
                pcProductos.Font = New Font("Segoe UI", 8)
                Me.pcProductos.ParentControl = Me.txtBuscarProducto
                Me.pcProductos.ShowPopup(Point.Empty)
                ObetnerListaProductosLSTPorItem(cboAlmace.SelectedValue, txtBuscarProducto.Text.Trim, cboTipoExistencia.SelectedValue)
                Me.Cursor = Cursors.Arrow
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub pcProductos_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProductos.BeforePopup
        Me.pcProductos.BackColor = Color.White
    End Sub

    Private Sub pcProductos_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProductos.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstProductos.SelectedItems.Count > 0 Then
                '   If txtAlmacen.Text.Trim.Length > 0 Then
                txtBuscarProducto.Text = lstProductos.Text
                txtBuscarProducto.Tag = lstProductos.SelectedValue
              
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtBuscarProducto.Focus()
        End If
    End Sub

    Private Sub cboEstable_Click(sender As Object, e As EventArgs) Handles cboEstable.Click

    End Sub

    Private Sub cboEstable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstable.SelectedIndexChanged
        LoadALmaceN(cboEstable.SelectedValue)
    End Sub

    Private Sub lstProductos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstProductos.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If lstProductos.SelectedItems.Count > 0 Then
            Me.pcProductos.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        ConsultaReporte(txtINic.Value, txtHasta.Value)
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
