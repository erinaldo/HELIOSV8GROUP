Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmConfigPrecioVenta
    Inherits frmMaster

    Private Property IdPrecio() As Integer?

    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel
    Public Property lblDestino() As String
    'Public CFG As Configuracion_General
    Private Sub ConfigDock()
        '  Panel1.Visible = False
        '    Me.dockingManager1.DockControlInAutoHideMode(Me.Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 494)
        '   dockingManager1.DockControlInAutoHideMode(Panel1, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 200)
        DockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.DockingClientPanel1.AutoScroll = True
        '  Me.dockingClientPanel1.SizeToFit = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        ' dockingManager1.SetDockVisibility ( panel)
        '   dockingManager1.SetDockLabel(Panel5, "Nuevo precio")
        LoadGrids()
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ConfiguracionInicio()
        ' Add any initialization after the InitializeComponent() call.
        ConfigDock()
        ObtenerAlmacenes()
    End Sub

#Region "Métodos"
    Private Sub EliminarLIsta(intIdCodigo As Integer)
        Dim listadoSA As New ListadoPrecioSA

        Dim nLista As New listadoPrecios With {
            .autoCodigo = intIdCodigo}

        listadoSA.EliminarListadoPrecio(nLista)
        ' Me..Table.CurrentRecord.Delete()
        'lblEstado.Text = "Registro eliminado!"
        'lblEstado.Image = My.Resources.ok4
    End Sub

    'Private Function getParentTablePrecioVentaPorProducto(intIdAlmacen As Integer, intIdItem As Integer, strProducto As String) As DataTable
    '    Dim objLista As New List(Of listadoPrecios)
    '    Dim listadoSA As New ListadoPrecioSA
    '    Dim objTablaSA As New tablaDetalleSA
    '    Dim objTabla As New tabladetalle
    '    Dim productoSA As New detalleitemsSA
    '    Dim producto As New detalleitems

    '    Dim dt As New DataTable("Producto, PV. " & strProducto)

    '    dt.Columns.Add(New DataColumn("autoCodigo", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("destinoGravado", GetType(String)))
    '    'lower case p
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
    '    dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("unidad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("valcompraIgvMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("valcompraSinIgvMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montoUtilidad", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("utilidadsinIgvMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("valorVentaMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precioVentaMN", GetType(Decimal)))

    '    dt.Columns.Add(New DataColumn("PorDsctounitMenor", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montoDsctounitMenorMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precioVentaFinalMenorMN", GetType(Decimal)))

    '    dt.Columns.Add(New DataColumn("PorDsctounitMayor", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montoDsctounitMayorMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precioVentaFinalMayorMN", GetType(Decimal)))

    '    dt.Columns.Add(New DataColumn("PorDsctounitGMayor", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montoDsctounitGMayorMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precioVentaFinalGMayorMN", GetType(Decimal)))

    '    Dim str As String

    '    objLista = listadoSA.ObtenerPrecioPorItemSL(intIdAlmacen, intIdItem, TmpTipoIVA)
    '    txtFiltro.Tag = intIdItem
    '    txtFiltro.Text = lsvListado.SelectedItems(0).SubItems(6).Text
    '    For Each i As listadoPrecios In objLista
    '        'producto = productoSA.InvocarProductoID(i.idItem)

    '        Dim dr As DataRow = dt.NewRow()
    '        str = Nothing
    '        str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
    '        dr(0) = i.autoCodigo
    '        dr(1) = i.destinoGravado
    '        dr(2) = str
    '        dr(3) = i.tipoExistencia
    '        dr(4) = i.descripcion
    '        dr(5) = i.presentacion  ' presentacion
    '        dr(6) = lsvListado.SelectedItems(0).SubItems(8).Text ' unidad
    '        dr(7) = i.valcompraIgvMN
    '        dr(8) = i.valcompraSinIgvMN
    '        dr(9) = i.montoUtilidad
    '        dr(10) = i.utilidadsinIgvMN
    '        dr(11) = i.valorVentaMN
    '        dr(12) = i.precioVentaMN

    '        dr(13) = i.PorDsctounitMenor
    '        dr(14) = i.montoDsctounitMenorMN
    '        dr(15) = i.precioVentaFinalMenorMN

    '        dr(16) = i.PorDsctounitMayor
    '        dr(17) = i.montoDsctounitMayorMN
    '        dr(18) = i.precioVentaFinalMayorMN

    '        dr(19) = i.PorDsctounitGMayor
    '        dr(20) = i.montoDsctounitGMayorMN
    '        dr(21) = i.precioVentaFinalGMayorMN
    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt



    'End Function

    'Private Function getParentTablePrecioVentaPorAlmacen(intIdAlmacen As Integer) As DataTable
    '    Dim objLista As New List(Of listadoPrecios)
    '    Dim listadoSA As New ListadoPrecioSA
    '    Dim objTablaSA As New tablaDetalleSA
    '    Dim objTabla As New tabladetalle

    '    Dim dt As New DataTable("Producto, PV. " & txtAlmacen.Text)

    '    dt.Columns.Add(New DataColumn("autoCodigo", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("destinoGravado", GetType(String)))
    '    'lower case p
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
    '    dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("unidad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("valcompraIgvMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("valcompraSinIgvMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montoUtilidad", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("utilidadsinIgvMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("valorVentaMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precioVentaMN", GetType(Decimal)))

    '    dt.Columns.Add(New DataColumn("PorDsctounitMenor", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montoDsctounitMenorMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precioVentaFinalMenorMN", GetType(Decimal)))

    '    dt.Columns.Add(New DataColumn("PorDsctounitMayor", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montoDsctounitMayorMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precioVentaFinalMayorMN", GetType(Decimal)))

    '    dt.Columns.Add(New DataColumn("PorDsctounitGMayor", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("montoDsctounitGMayorMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("precioVentaFinalGMayorMN", GetType(Decimal)))

    '    Dim str As String
    '    objLista = listadoSA.ObtenerPrecioPorIdAlmacen(intIdAlmacen)
    '    For Each i As listadoPrecios In objLista
    '        Dim dr As DataRow = dt.NewRow()
    '        str = Nothing
    '        str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
    '        dr(0) = i.autoCodigo
    '        dr(1) = i.destinoGravado
    '        dr(2) = str
    '        dr(3) = i.tipoExistencia
    '        dr(4) = i.descripcion
    '        dr(5) = i.presentacion
    '        dr(6) = i.unidad
    '        dr(7) = i.valcompraIgvMN
    '        dr(8) = i.valcompraSinIgvMN
    '        dr(9) = i.montoUtilidad
    '        dr(10) = i.utilidadsinIgvMN
    '        dr(11) = i.valorVentaMN
    '        dr(12) = i.precioVentaMN

    '        dr(13) = i.PorDsctounitMenor
    '        dr(14) = i.montoDsctounitMenorMN
    '        dr(15) = i.precioVentaFinalMenorMN

    '        dr(16) = i.PorDsctounitMayor
    '        dr(17) = i.montoDsctounitMayorMN
    '        dr(18) = i.precioVentaFinalMayorMN

    '        dr(19) = i.PorDsctounitGMayor
    '        dr(20) = i.montoDsctounitGMayorMN
    '        dr(21) = i.precioVentaFinalGMayorMN
    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt


    'End Function


    'Private Sub ObtenerListaPorAlmacen(intIdAlmacen As Integer)
    '    Dim parentTable As DataTable = getParentTablePrecioVentaPorAlmacen(intIdAlmacen)
    '    Me.dgvCompra.DataSource = parentTable
    '    dgvCompra.TableDescriptor.Relations.Clear()
    '    dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '    dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
    '    dgvCompra.GroupDropPanel.Visible = True
    '    dgvCompra.TableDescriptor.GroupedColumns.Clear()
    '    dgvCompra.TableDescriptor.GroupedColumns.Add("descripcion")
    'End Sub

    'Private Sub ObtenerListaPorAlmacenPorProducto()
    '    Dim parentTable As DataTable = getParentTablePrecioVentaPorProducto(txtAlmacen.ValueMember, lsvListado.SelectedItems(0).SubItems(5).Text, lsvListado.SelectedItems(0).SubItems(6).Text)
    '    Me.dgvCompra.DataSource = parentTable
    '    dgvCompra.TableDescriptor.Relations.Clear()
    '    dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '    dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
    '    dgvCompra.GroupDropPanel.Visible = True
    '    dgvCompra.TableDescriptor.GroupedColumns.Clear()
    '    '   dgvCompra.TableDescriptor.GroupedColumns.Add("descripcion")
    'End Sub

    Private Sub ObtenerAlmacenes()
        Dim almacenSA As New almacenSA
        Dim almacen As New List(Of almacen)

        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        lstAlmacen.ValueMember = "idAlmacen"
        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.DataSource = almacen

        Me.txtAlmacen.ValueMember = TmpIdAlmacen
        txtAlmacen.Text = TmpNombreAlmacen
    End Sub
    Public Sub ObtenerListadoPreciosLiked(intIdAlmacen As Integer, strBusqueda As String)

        Dim totalSA As New TotalesAlmacenSA
        Try
            lsvListado.Columns.Clear()
            lsvListado.Items.Clear()
            lsvListado.Columns.Add("IdEmpresa", 0) '0
            lsvListado.Columns.Add("IdEstablecimiento", 0) '1
            lsvListado.Columns.Add("Almacén", 0) '2
            lsvListado.Columns.Add("G.", 0) '3
            lsvListado.Columns.Add("T.E.", 50, HorizontalAlignment.Center) '4
            lsvListado.Columns.Add("ID Item", 0) '5
            lsvListado.Columns.Add("Descripcion", 200, HorizontalAlignment.Left) '6
            lsvListado.Columns.Add("Presentación", 0, HorizontalAlignment.Center) '7
            lsvListado.Columns.Add("U.M.", 70, HorizontalAlignment.Center) '8
            lsvListado.Columns.Add("Cant.", 0, HorizontalAlignment.Center) '9
            lsvListado.Columns.Add("Impórte", 0, HorizontalAlignment.Center) '10
            lsvListado.Columns.Add("P.M.", 70, HorizontalAlignment.Center) '11
            lsvListado.Columns.Add("Utilidad", 70, HorizontalAlignment.Center) '12

            For Each i As totalesAlmacen In totalSA.GetListaProductosTAPorProductoByTake(intIdAlmacen, strBusqueda)
                Dim n As New ListViewItem(i.idEmpresa)
                n.SubItems.Add(i.idEstablecimiento)
                n.SubItems.Add(i.idAlmacen)
                n.SubItems.Add(i.origenRecaudo)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.Presentacion)
                n.SubItems.Add(i.unidadMedida)
                n.SubItems.Add(FormatNumber(i.cantidad, 2))
                n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2))
                Else
                    n.SubItems.Add(0)
                End If
                n.SubItems.Add(i.porcentajeUtilidad)
                n.SubItems.Add(0)
                lsvListado.Items.Add(n)
            Next
            'For Each item As ListViewItem In lsvListado.Items
            '    Dim i As Short
            '    If i Mod 2 = 0 Then
            '        item.BackColor = Color.Transparent
            '        item.ForeColor = Color.Gray
            '    Else
            '        item.BackColor = Color.WhiteSmoke
            '        item.ForeColor = Color.Gray
            '    End If
            '    i = i + 1
            'Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Private Sub ConfiguracionInicio()
        Me.RibbonControlAdv1.QuickPanelVisible = True
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel.Text = "Período:"
        Me.lblPeriodoLabel.Font = New Font("Segoe UI", 8.25, FontStyle.Bold)
        lblPeriodoLabel.Enabled = False

        Me.lblPeriodo.Font = New Font("Segoe UI", 8.25)
        ' Set the text and DisplayStyle property.
        Me.lblPeriodo.Text = PeriodoGeneral
        lblPeriodo.Enabled = False
        Me.lblPeriodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text

        ' Add the toolstripbutton in the header of the RibbonControlAdv.
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodoLabel)
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodo) 'ToolStripSeparator1
        '  Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub
#End Region

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacen.ValueMember = lstAlmacen.SelectedValue
                txtAlmacen.Text = lstAlmacen.Text
                txtFiltro.Clear()
                txtFiltro.Tag = String.Empty
                'dgvCompra.Table.Records.DeleteAll()
                '  ListadoItemsEnTransito(MesGeneral, AnioGeneral, txtExistencia.ValueMember)
                '    ObtenerListadoPrecios(txtAlmacen.ValueMember)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen.Focus()
        End If
    End Sub

    Private Sub frmConfigPrecioVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        pcAlmacen.Font = New Font("Segoe UI", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            'ObtenerListaPorAlmacen(txtAlmacen.ValueMember)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        'LimnpiarCajas()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lsvListado_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListado.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If lsvListado.SelectedItems.Count > 0 Then
            Me.pcProductos.HidePopup(PopupCloseType.Done)
            txtFiltro.Text = lsvListado.SelectedItems(0).SubItems(6).Text
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            pcProductos.Font = New Font("Segoe UI", 8)
            pcProductos.Size = New Size(323, 151)
            Me.pcProductos.ParentControl = Me.txtFiltro
            Me.pcProductos.ShowPopup(Point.Empty)
            lsvListado.FullRowSelect = True
            '    If txtFiltroMercaderia.Text.Trim.Length > 0 Then
            lsvListado.Items.Clear()

            'If e.KeyCode = Keys.Enter Then
            '    e.SuppressKeyPress = True

            '    If txtAlmacen.Text.Trim.Length > 0 Then
            'If txtFiltro.Text.Trim.Length > 0 Then
            '    If txtAlmacen.Text.Trim.Length > 0 Then
            ObtenerListadoPreciosLiked(txtAlmacen.ValueMember, txtFiltro.Text.Trim)

        End If
        'Else
        ''lblEstado.Text = "Debe escribir el nombre del producto a buscar"
        ''Timer1.Enabled = True
        ''TiempoEjecutar(5)
        'End If
        '    Else
        ''lblEstado.Text = "Debe elegir un alamacen"
        ''Timer1.Enabled = True
        ''TiempoEjecutar(5)
        '    End If
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFiltro_MouseClick(sender As Object, e As MouseEventArgs) Handles txtFiltro.MouseClick
        'If txtFiltro.FarImage. = "2" Then
        '    txtFiltro.Clear()
        '    txtFiltro.Tag = String.Empty
        '    txtFiltro.Select()
        'End If
    End Sub

    Private Sub txtFiltro_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtFiltro.MouseDoubleClick
        If lsvListado.SelectedItems.Count > 0 Then
            Me.pcProductos.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub pcProductos_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProductos.BeforePopup
        Me.pcProductos.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcProductos_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProductos.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvListado.SelectedItems.Count > 0 Then
                If txtAlmacen.Text.Trim.Length > 0 Then
                    If lsvListado.SelectedItems.Count > 0 Then
                        'ObtenerListaPorAlmacenPorProducto()
                        txtFiltro.Tag = lsvListado.SelectedItems(0).SubItems(5).Text
                        txtFiltro.Text = lsvListado.SelectedItems(0).SubItems(6).Text
                        txtDestino.Text = lsvListado.SelectedItems(0).SubItems(3).Text
                        MostrarUltimoPrecioItem(txtAlmacen.ValueMember, lsvListado.SelectedItems(0).SubItems(5).Text)
                    Else
                        txtFiltro.Tag = String.Empty
                    End If
                End If

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtFiltro.Focus()
        End If
    End Sub

    Private Sub lstAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacen.MouseDoubleClick
        If lstAlmacen.SelectedItems.Count > 0 Then
            Me.pcAlmacen.HidePopup(PopupCloseType.Done)
        End If
    End Sub

#Region "IVA - NO IVA METODOS"
    Sub LoadGrids()
        Dim dt As New DataTable
        dt.Columns.Add("IdItem", GetType(Integer))
        dt.Columns.Add("existencia", GetType(String))
        dt.Columns.Add("destino", GetType(String))
        dt.Columns.Add("vc", GetType(Decimal))
        dt.Columns.Add("porcUtilidad", GetType(Decimal))
        dt.Columns.Add("impUti1", GetType(Decimal))
        dt.Columns.Add("vv", GetType(Decimal))
        dt.Columns.Add("igv", GetType(Decimal))
        dt.Columns.Add("precVenta", GetType(Decimal))
        dgvMenor.DataSource = dt

        Me.dgvMenor.Table.AddNewRecord.SetCurrent()
        Me.dgvMenor.Table.AddNewRecord.BeginEdit()
        Me.dgvMenor.Table.CurrentRecord.SetValue("vc", 0)
        Me.dgvMenor.Table.CurrentRecord.SetValue("precVenta", 0)
        Me.dgvMenor.Table.AddNewRecord.EndEdit()
        Me.dgvMenor.Table.AddNewRecord.SetCurrent()
        Me.dgvMenor.Table.AddNewRecord.BeginEdit()
        Me.dgvMenor.Table.CurrentRecord.SetValue("vc", 0)
        Me.dgvMenor.Table.CurrentRecord.SetValue("precVenta", 0)
        Me.dgvMenor.Table.AddNewRecord.EndEdit()


        Dim dt2 As New DataTable
        dt2.Columns.Add("IdItem2", GetType(Integer))
        dt2.Columns.Add("existencia2", GetType(String))
        dt2.Columns.Add("destino2", GetType(String))
        dt2.Columns.Add("vc2", GetType(Decimal))
        dt2.Columns.Add("porcUtilidad2", GetType(Decimal))
        dt2.Columns.Add("impUti", GetType(Decimal))
        dt2.Columns.Add("vv2", GetType(Decimal))
        dt2.Columns.Add("igv2", GetType(Decimal))
        dt2.Columns.Add("precVenta2", GetType(Decimal))
        dgvMayor.DataSource = dt2

        Dim dt3 As New DataTable
        dt3.Columns.Add("IdItem3", GetType(Integer))
        dt3.Columns.Add("existencia3", GetType(String))
        dt3.Columns.Add("destino3", GetType(String))
        dt3.Columns.Add("vc3", GetType(Decimal))
        dt3.Columns.Add("porcUtilidad3", GetType(Decimal))
        dt3.Columns.Add("impUti3", GetType(Decimal))
        dt3.Columns.Add("vv3", GetType(Decimal))
        dt3.Columns.Add("igv3", GetType(Decimal))
        dt3.Columns.Add("precVenta3", GetType(Decimal))
        dgvGranMayor.DataSource = dt3


        Me.dgvMayor.Table.AddNewRecord.SetCurrent()
        Me.dgvMayor.Table.AddNewRecord.BeginEdit()
        Me.dgvMayor.Table.CurrentRecord.SetValue("vc2", 0)
        Me.dgvMayor.Table.CurrentRecord.SetValue("precVenta2", 0)
        Me.dgvMayor.Table.AddNewRecord.EndEdit()
        Me.dgvMayor.Table.AddNewRecord.SetCurrent()
        Me.dgvMayor.Table.AddNewRecord.BeginEdit()
        Me.dgvMayor.Table.CurrentRecord.SetValue("vc2", 0)
        Me.dgvMayor.Table.CurrentRecord.SetValue("precVenta2", 0)
        Me.dgvMayor.Table.AddNewRecord.EndEdit()

        Me.dgvGranMayor.Table.AddNewRecord.SetCurrent()
        Me.dgvGranMayor.Table.AddNewRecord.BeginEdit()
        Me.dgvGranMayor.Table.CurrentRecord.SetValue("vc3", 0)
        Me.dgvGranMayor.Table.CurrentRecord.SetValue("precVenta3", 0)
        Me.dgvGranMayor.Table.AddNewRecord.EndEdit()
        Me.dgvGranMayor.Table.AddNewRecord.SetCurrent()
        Me.dgvGranMayor.Table.AddNewRecord.BeginEdit()
        Me.dgvGranMayor.Table.CurrentRecord.SetValue("vc3", 0)
        Me.dgvGranMayor.Table.CurrentRecord.SetValue("precVenta3", 0)
        Me.dgvGranMayor.Table.AddNewRecord.EndEdit()
    End Sub

    Public Sub MostrarUltimoPrecioItem(ByVal intIdAlmacen As Integer, ByVal intIdItem As Integer)

        Dim listadoSA As New ListadoPrecioSA
        Dim items As New listadoPrecios
        IdPrecio = Nothing
        items = listadoSA.UbicarPVxItem(intIdAlmacen, intIdItem)

        If (Not IsNothing(items.fecha)) Then

            IdPrecio = items.autoCodigo
            Me.dgvMenor.Table.AddNewRecord.SetCurrent()
            Me.dgvMenor.Table.AddNewRecord.BeginEdit()
            Me.dgvMenor.Table.Records(0).SetValue("vc", items.vcmenor)
            Me.dgvMenor.Table.Records(0).SetValue("porcUtilidad", items.porcUtimenor)
            Me.dgvMenor.Table.Records(0).SetValue("impUti1", items.montoUtimenor)
            Me.dgvMenor.Table.Records(0).SetValue("vv", items.vvmenor)
            Me.dgvMenor.Table.Records(0).SetValue("igv", items.igvmenor)
            Me.dgvMenor.Table.Records(0).SetValue("precVenta", items.pvmenor)
            Me.dgvMenor.Table.AddNewRecord.EndEdit()

            Me.dgvMenor.Table.AddNewRecord.SetCurrent()
            Me.dgvMenor.Table.AddNewRecord.BeginEdit()
            Me.dgvMenor.Table.Records(1).SetValue("vc", items.vcmenorme)
            Me.dgvMenor.Table.Records(1).SetValue("porcUtilidad", items.porcUtimenor)
            Me.dgvMenor.Table.Records(1).SetValue("impUti1", items.montoUtimenorme)
            Me.dgvMenor.Table.Records(1).SetValue("vv", items.vvmenorme)
            Me.dgvMenor.Table.Records(1).SetValue("igv", items.igvmenormeme)
            Me.dgvMenor.Table.Records(1).SetValue("precVenta", items.pvmenorme)
            Me.dgvMenor.Table.AddNewRecord.EndEdit()


            '*------------------------------------------------------------------------
            Me.dgvMayor.Table.AddNewRecord.SetCurrent()
            Me.dgvMayor.Table.AddNewRecord.BeginEdit()
            Me.dgvMayor.Table.Records(0).SetValue("vc2", items.vcmayor)
            Me.dgvMayor.Table.Records(0).SetValue("porcUtilidad2", items.porcUtimayor)
            Me.dgvMayor.Table.Records(0).SetValue("impUti", items.montoUtimayor)
            Me.dgvMayor.Table.Records(0).SetValue("vv2", items.vvmayor)
            Me.dgvMayor.Table.Records(0).SetValue("igv2", items.igvmayor)
            Me.dgvMayor.Table.Records(0).SetValue("precVenta2", items.pvmayor)
            Me.dgvMayor.Table.AddNewRecord.EndEdit()

            Me.dgvMayor.Table.AddNewRecord.SetCurrent()
            Me.dgvMayor.Table.AddNewRecord.BeginEdit()
            Me.dgvMayor.Table.Records(1).SetValue("vc2", items.vcmayorme)
            Me.dgvMayor.Table.Records(1).SetValue("porcUtilidad2", items.porcUtimayor)
            Me.dgvMayor.Table.Records(1).SetValue("impUti", items.montoUtimayorme)
            Me.dgvMayor.Table.Records(1).SetValue("vv2", items.vvmayorme)
            Me.dgvMayor.Table.Records(1).SetValue("igv2", items.igvmayormeme)
            Me.dgvMayor.Table.Records(1).SetValue("precVenta2", items.pvmayorme)
            Me.dgvMayor.Table.AddNewRecord.EndEdit()

            '*------------------------------------------------------------------------
            Me.dgvGranMayor.Table.AddNewRecord.SetCurrent()
            Me.dgvGranMayor.Table.AddNewRecord.BeginEdit()
            Me.dgvGranMayor.Table.Records(0).SetValue("vc3", items.vcgranmayor)
            Me.dgvGranMayor.Table.Records(0).SetValue("porcUtilidad3", items.porcUtigranmayor)
            Me.dgvGranMayor.Table.Records(0).SetValue("impUti3", items.montoUtigranmayor)
            Me.dgvGranMayor.Table.Records(0).SetValue("vv3", items.vvgranmayor)
            Me.dgvGranMayor.Table.Records(0).SetValue("igv3", items.igvgranmayor)
            Me.dgvGranMayor.Table.Records(0).SetValue("precVenta3", items.pvgranmayor)
            Me.dgvGranMayor.Table.AddNewRecord.EndEdit()

            Me.dgvGranMayor.Table.AddNewRecord.SetCurrent()
            Me.dgvGranMayor.Table.AddNewRecord.BeginEdit()
            Me.dgvGranMayor.Table.Records(1).SetValue("vc3", items.vcgranmayorme)
            Me.dgvGranMayor.Table.Records(1).SetValue("porcUtilidad3", items.porcUtigranmayor)
            Me.dgvGranMayor.Table.Records(1).SetValue("impUti3", items.montoUtigranmayorme)
            Me.dgvGranMayor.Table.Records(1).SetValue("vv3", items.vvgranmayorme)
            Me.dgvGranMayor.Table.Records(1).SetValue("igv3", items.igvgranmayorme)
            Me.dgvGranMayor.Table.Records(1).SetValue("precVenta3", items.pvgranmayorme)
            Me.dgvGranMayor.Table.AddNewRecord.EndEdit()

        End If


    End Sub
#End Region

    Private Sub txtUltimaEntradaIVA_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            If txtFiltro.Tag.Trim.Length > 0 Then
                With frmHistorialPrecioVenta
                    .txtProducto.Text = lsvListado.SelectedItems(0).SubItems(6).Text
                    .txtAlamcen.Text = txtAlmacen.Text
                    .txtAlamcen.ValueMember = txtAlmacen.ValueMember
                    .ObtenerListaPorAlmacenPorProducto(txtAlmacen.ValueMember, lsvListado.SelectedItems(0).SubItems(5).Text, "SIVA")
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        Else
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtUltimaEntradaNoIVA_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            If txtFiltro.Tag.Trim.Length > 0 Then
                With frmHistorialPrecioVenta
                    .txtProducto.Text = lsvListado.SelectedItems(0).SubItems(6).Text
                    .txtAlamcen.Text = txtAlmacen.Text
                    .txtAlamcen.ValueMember = txtAlmacen.ValueMember
                    .ObtenerListaPorAlmacenPorProducto(txtAlmacen.ValueMember, lsvListado.SelectedItems(0).SubItems(5).Text, "NIVA")
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        Else
        End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        If CDec(Me.dgvMenor.Table.Records(0).GetValue("precVenta")) > 0 Then
            If txtFiltro.Text.Trim.Length > 0 Then
                If MessageBoxAdv.Show("Desea eliminar el precio actual?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    EliminarLIsta(IdPrecio)
                    txtFiltro.Clear()
                    txtFiltro.Tag = String.Empty
                    dgvMenor.Table.Records.DeleteAll()
                    dgvMayor.Table.Records.DeleteAll()
                    dgvGranMayor.Table.Records.DeleteAll()
                End If
            End If
        End If
    End Sub

    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles btnEditCompra.Click

    End Sub

    Private Sub ToolStripButton3_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            If txtFiltro.Tag.Trim.Length > 0 Then
                With frmTablaPrecios
                    .txtDestino.Text = lsvListado.SelectedItems(0).SubItems(3).Text
                    .txtProducto.Text = lsvListado.SelectedItems(0).SubItems(6).Text
                    .txtProducto.ValueMember = lsvListado.SelectedItems(0).SubItems(5).Text
                    .txtAlmacenDestino.Text = txtAlmacen.Text
                    .txtAlmacenDestino.ValueMember = txtAlmacen.ValueMember
                    .txtTipoCambio.Value = TmpTipoCambio
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBoxAdv.Show("Ingrese un producto válido.!", "Atención")
            End If
        Else

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If txtFiltro.Text.Trim.Length > 0 Then
            With frmUltimasCompras
                .txtItem.Text = txtFiltro.Text
                .txtItem.ValueMember = txtFiltro.Tag
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            If txtFiltro.Tag.Trim.Length > 0 Then
                With frmHistorialPrecioVenta
                    .txtProducto.Text = txtFiltro.Text ' lsvListado.SelectedItems(0).SubItems(6).Text
                    .txtAlamcen.Text = txtAlmacen.Text
                    .txtAlamcen.ValueMember = txtAlmacen.ValueMember
                    .txtDestino.Text = lsvListado.SelectedItems(0).SubItems(3).Text
                    .ObtenerListaPorAlmacenPorProducto(txtAlmacen.ValueMember, txtFiltro.Tag, "SIVA")
                    .StartPosition = FormStartPosition.CenterParent
                    .WindowState = FormWindowState.Maximized
                    .ShowDialog()
                End With
            End If
        Else
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvListado.SelectedItems.Count > 0 Then
            If txtAlmacen.Text.Trim.Length > 0 Then
                If txtFiltro.Text.Trim.Length > 0 Then
                    'ObtenerListaPorAlmacenPorProducto()
                    txtFiltro.Tag = lsvListado.SelectedItems(0).SubItems(5).Text
                    txtFiltro.Text = lsvListado.SelectedItems(0).SubItems(6).Text
                    MostrarUltimoPrecioItem(txtAlmacen.ValueMember, lsvListado.SelectedItems(0).SubItems(5).Text)
                Else
                    txtFiltro.Tag = String.Empty
                    dgvMenor.Table.Records.DeleteAll()
                    dgvMayor.Table.Records.DeleteAll()
                    dgvGranMayor.Table.Records.DeleteAll()
                End If
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmConfigPrecioVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txtFiltro.FarImage.
        'txtFiltro.NearImage.Tag = "1"
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text.Trim.Length > 0 Then
            txtFiltro.FarImage = My.Resources.Close1
        Else
            txtFiltro.FarImage = Nothing
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            Dim f As New frmMaestroPreciosVenta()
            'f.IdAlmacen = txtAlmacen.ValueMember
            'f.NombreAlmacen = txtAlmacen.Text
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Maximized
            f.ShowDialog()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class