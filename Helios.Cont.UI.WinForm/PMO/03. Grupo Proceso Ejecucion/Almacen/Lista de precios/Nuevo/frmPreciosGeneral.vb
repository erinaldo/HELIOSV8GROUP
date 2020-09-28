Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmPreciosGeneral
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        CargarControles()
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvPrecios)
        GridCFG(GridGroupingControl1)
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Dim colorx As New GridMetroColors()
    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub


    
#Region "Métodos"
    'GetProductoPorAlmacenTipoEx
    Public Sub UbicarUltimosPreciosXproducto(r As Record)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(cboAlmacen.SelectedValue, r.GetValue("idItem"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt

    End Sub
    Sub LoadProductosXalmacen()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim dt As New DataTable()
        Dim codigo As Integer = cboAlmacen.SelectedValue

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")
        dt.Columns.Add("btnUltimasEntradas")

        Dim str As String = Nothing
        Dim str1 As String = Nothing

        For Each i In totalesAlmacenSA.GetListaProductosPorAlmacen(codigo)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = "ultimas"
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        Me.dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub


    Sub ListarInventarioXproducto()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim dt As New DataTable()
        Dim codigo As Integer = cboAlmacen.SelectedValue

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")

        For Each i In totalesAlmacenSA.GetProductoPorAlmacenTipoEx(codigo, cboTipoExistencia.SelectedValue, txtBuscar.Text.Trim)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        Me.dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Sub CargarControles()
        Dim tablaSA As New tablaDetalleSA
        Dim almacenSA As New almacenSA

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub
#End Region

    Private Sub frmPreciosGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmPreciosGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEmpresa.Text = Gempresas.NomEmpresa
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
            UbicarUltimosPreciosXproducto(dgvPrecios.Table.CurrentRecord)
        End If
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        LoadProductosXalmacen()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvPrecios_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvPrecios.SelectedRecordsChanged
        GridGroupingControl1.Table.Records.DeleteAll()
    End Sub

    Private Sub dgvPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPrecios.TableControlCellClick

    End Sub

    Private Sub cboAlmacen_Click(sender As Object, e As EventArgs) Handles cboAlmacen.Click

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
            Dim f As New frmNuevoPrecio
            f.txtAlmacen.Text = cboAlmacen.Text
            f.txtAlmacen.Tag = cboAlmacen.SelectedValue
            f.txtProducto.Tag = dgvPrecios.Table.CurrentRecord.GetValue("idItem")
            f.txtProducto.Text = dgvPrecios.Table.CurrentRecord.GetValue("item")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListarInventarioXproducto()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim detalleItemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmNuevaExistencia
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .Precios = True
            .IdAlmacenPrecio = TmpIdAlmacen
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            'If datos.Count > 0 Then
            '    If datos(0).Cuenta = "Grabado" Then
            '        With detalleItemSA.InvocarProductoID(datos(0).ID)
            '            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            '            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("fecha", Nothing)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", .descripcionItem)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("vc", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimenor", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimenor", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("pvmenor", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("vc2", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimayor", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimayor", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("pvmayor", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("vc3", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtigranmayor", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtigranmayor", 0.0)
            '            Me.dgvCompra.Table.CurrentRecord.SetValue("pvgranmayor", 0.0)
            '            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            '        End With
            '    End If
            'End If

        End With
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvPrecios.Table.CurrentRecord) Then
            Dim detalleItemSA As New detalleitemsSA
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            With frmNuevaExistencia
                .EstadoManipulacion = ENTITY_ACTIONS.UPDATE
                '.cboTipoExistencia.SelectedValue = "01"
                .Precios = True
                .IdAlmacenPrecio = TmpIdAlmacen
                ' .cboTipoExistencia.Text = cboTipoExistencia.Text
                .UCNuenExistencia.UbicarProducto(Me.dgvPrecios.Table.CurrentRecord.GetValue("idItem"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                'If datos.Count > 0 Then
                '    If datos(0).Cuenta = "Grabado" Then
                '        With detalleItemSA.InvocarProductoID(datos(0).ID)
                '            'Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                '            'Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("fecha", Nothing)
                '            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", .codigodetalle)
                '            Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", .descripcionItem)
                '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("vc", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimenor", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimenor", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("pvmenor", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("vc2", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtimayor", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtimayor", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("pvmayor", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("vc3", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("porcUtigranmayor", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("montoUtigranmayor", 0.0)
                '            'Me.dgvCompra.Table.CurrentRecord.SetValue("pvgranmayor", 0.0)
                '            '     Me.dgvCompra.Table.AddNewRecord.EndEdit()
                '        End With
                '    End If
                'End If

            End With
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim detalleItem As New detalleitems
        Dim detalleItemSA As New detalleitemsSA
        Try
            If MessageBox.Show("Desea eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
                    detalleItem = New detalleitems
                    detalleItem.idEmpresa = Gempresas.IdEmpresaRuc
                    detalleItem.idEstablecimiento = GEstableciento.IdEstablecimiento
                    detalleItem.codigodetalle = Me.dgvPrecios.Table.CurrentRecord.GetValue("idItem")
                    detalleItemSA.DeleteProductoAllReferences(detalleItem)
                    Me.dgvPrecios.Table.CurrentRecord.Delete()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", Nothing, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvPrecios_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvPrecios.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 6 Then
                e.Inner.Style.Description = "btUltimasEntradas"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageListAdv1.Images(0), irect)
            End If

        End If
    End Sub

    Private Sub dgvPrecios_TableControlPrepareViewStyleInfo(sender As Object, e As GridTableControlPrepareViewStyleInfoEventArgs) Handles dgvPrecios.TableControlPrepareViewStyleInfo
        If (e.Inner.ColIndex > 0) AndAlso (e.Inner.ColIndex < 7) Then
            e.Inner.Style.CellTipText = e.Inner.Style.Text
        End If
    End Sub

    Private Sub dgvPrecios_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvPrecios.TableControlPushButtonClick
        If e.Inner.ColIndex = 6 Then
            Dim f As New frmUltimasCompras
            f.txtItem.Text = Me.dgvPrecios.TableModel(e.Inner.RowIndex, 1).CellValue
            f.txtItem.ValueMember = Me.dgvPrecios.TableModel(e.Inner.RowIndex, 7).CellValue
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub
End Class