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
Public Class frmReporteComprasPorProv
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
        txtINic.Value = New DateTime(DateTime.Now.Year, Date.Now.Month, 1)
        txtHasta.Value = New DateTime(DateTime.Now.Year, Date.Now.Month, Date.Now.Day)

        rbCliente.Checked = True
        cboProv.Visible = True
        Label2.Visible = True
        cboProv.SelectedValue = -1

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
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvComprasXprov.rdlc"
        'Me.reportData = DocumentoCompraSA.ListaComprasXporveedor(fecINic, fecHasta, idProv, "PR")
        Me.reportData = DocumentoCompraSA.ListaComprasPorveedorOrArticulo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, fecINic, fecHasta, idProv, "PR", Nothing)
        Me.nombreMainDS = "DSProv"
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

    Public Sub ConsultaReporteXArticulo(fecINic As DateTime, fecHasta As DateTime, idProv As Integer, BuscarProducto As String)
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvComprasXprov.rdlc"
        Me.reportData = DocumentoCompraSA.ListaComprasPorveedorOrArticulo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, fecINic, fecHasta, idProv, "ART", BuscarProducto)
        Me.nombreMainDS = "DSProv"
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

    Public Sub ConsultaReporteProvedorXArticulo(fecINic As DateTime, fecHasta As DateTime, idProv As Integer, BuscarProducto As String)
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA

        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvComprasXprov.rdlc"
        Me.reportData = DocumentoCompraSA.ListaComprasPorveedorOrArticulo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, fecINic, fecHasta, idProv, "PRART", BuscarProducto)
        Me.nombreMainDS = "DSProv"
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

    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            '   n.SubItems.Add(i.codigo & "   " & "-" & "   " & i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.origenProducto)
            n.SubItems.Add(i.codigo)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub

#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor

        Dim fechaInicio = New DateTime(txtINic.Value.Year, txtINic.Value.Month, txtINic.Value.Day, 12, 0, 0)
        Dim fechaFinal = New DateTime(txtHasta.Value.Year, txtHasta.Value.Month, txtHasta.Value.Day, 23, 59, 59)

        If rbArticulo.Checked = True Then
            ConsultaReporteXArticulo(fechaInicio, fechaFinal, cboProv.SelectedValue, txtBuscarProducto.Text)
        ElseIf rbCliente.Checked = True Then
            ConsultaReporte(fechaInicio, fechaFinal, cboProv.SelectedValue)
        ElseIf rbProArt.Checked = True Then
            ConsultaReporteProvedorXArticulo(fechaInicio, fechaFinal, cboProv.SelectedValue, txtBuscarProducto.Text)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbCliente.CheckedChanged
        If (rbCliente.Checked = True) Then
            rbCliente.Checked = True
            rbArticulo.Checked = False
            rbProArt.Checked = False
            '     ConsultaReporte(Nothing, Nothing, 0)
            cboProv.SelectedValue = -1
            txtINic.Value = DateTime.Now
            txtHasta.Value = DateTime.Now
            pnCliente.Visible = True
            pnArticulo.Visible = False
            pnCliente.Location = New Point(29, 75)
            pnFecha.Location = New Point(343, 75)
        End If
    End Sub

    Private Sub rbArticulo_CheckedChanged(sender As Object, e As EventArgs) Handles rbArticulo.CheckedChanged
        If (rbArticulo.Checked = True) Then
            rbArticulo.Checked = True
            rbCliente.Checked = False
            rbProArt.Checked = False
            '      ConsultaReporte(Nothing, Nothing, 0)
            txtBuscarProducto.Clear()
            txtBuscarProducto.Select()
            txtINic.Value = DateTime.Now
            txtHasta.Value = DateTime.Now
            pnCliente.Visible = False
            pnArticulo.Visible = True
            pnFecha.Location = New Point(343, 75)
            pnArticulo.Location = New Point(29, 75)
        End If
    End Sub

    Private Sub rbProArt_CheckedChanged(sender As Object, e As EventArgs) Handles rbProArt.CheckedChanged
        If (rbProArt.Checked = True) Then
            rbArticulo.Checked = False
            rbCliente.Checked = False
            rbProArt.Checked = True
            '    ConsultaReporte(Nothing, Nothing, 0)
            txtBuscarProducto.Clear()
            txtINic.Value = DateTime.Now
            txtHasta.Value = DateTime.Now
            pnCliente.Visible = True
            pnArticulo.Visible = True
            pnFecha.Location = New Point(659, 75)
            pnArticulo.Location = New Point(343, 75)
            pnCliente.Location = New Point(29, 75)
        End If
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvListadoItems.SelectedItems.Count > 0 Then
                Me.txtBuscarProducto.Text = lsvListadoItems.SelectedItems(0).SubItems(1).Text

                txtBuscarProducto.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtBuscarProducto.Focus()
        End If
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        If lsvListadoItems.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtBuscarProducto
            Me.popupControlContainer1.ShowPopup(Point.Empty)


            ListaMercaderias("01", txtBuscarProducto.Text.Trim)

            Me.Cursor = Cursors.Arrow

            e.Handled = True

        End If
    End Sub

    Private Sub txtBuscarProducto_Click(sender As Object, e As EventArgs) Handles txtBuscarProducto.Click
        txtBuscarProducto.Select()
        txtBuscarProducto.Select(0, txtBuscarProducto.Text.Length)
    End Sub

    Private Sub cboProv_Click(sender As Object, e As EventArgs) Handles cboProv.Click

    End Sub
End Class
