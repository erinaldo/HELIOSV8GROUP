Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class UCItemsAnexos

#Region "Attributes"
    Public Property ListaItemsConexos As List(Of detalleitems_conexo)
    Public ProductoSA As New detalleitemsSA
    Public Property listaProductos As List(Of detalleitems)

    Public Property FormPrincipal As frmNuevaExistencia
#End Region

#Region "Constructors"
    Public Sub New(frmNuevaExistencia As frmNuevaExistencia)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListaItemsConexos = New List(Of detalleitems_conexo)
        FormPrincipal = frmNuevaExistencia
        FormatoGridAvanzado(GridEquivalencia, False, False, 9.0F)
        txtProducto.ReadOnly = False

        Me.GridEquivalencia.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl

        Me.GridEquivalencia.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
        Me.GridEquivalencia.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"
        Me.GridEquivalencia.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridEquivalencia.TableDescriptor.Columns("unidadComercial").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCellEditing
    End Sub


#End Region

#Region "Methods"
    Private Sub GetListProductos(consulta As List(Of detalleitems))
        ListProductos.Items.Clear()
        For Each i In consulta
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.composicion)
            If i.recursoCostoLote.Count > 0 Then
                n.SubItems.Add(i.recursoCostoLote.FirstOrDefault.fechaentrada.GetValueOrDefault)
                n.SubItems.Add(i.recursoCostoLote.FirstOrDefault.precioUnitarioIva.GetValueOrDefault)
            Else
                n.SubItems.Add("-")
                n.SubItems.Add("-")
            End If

            ListProductos.Items.Add(n)
        Next
        ListProductos.Refresh()
    End Sub

    Private Sub LoadProductosConexos()
        Dim dt As New DataTable
        dt.Columns.Add("Producto")
        dt.Columns.Add("Unidad")
        dt.Columns.Add("TipoExistenc")
        dt.Columns.Add("ID")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("unidadComercial")

        For Each i In ListaItemsConexos
            dt.Rows.Add(i.customdetalleitems.descripcionItem, i.customdetalleitems.unidad1, i.customdetalleitems.tipoExistencia, i.codigodetalle, i.cantidad.GetValueOrDefault, i.customEquivalencia.equivalencia_id)
        Next
        GridEquivalencia.DataSource = dt
    End Sub

    Public Sub LoadProductosConexos(ListaItemsConexos As List(Of detalleitems_conexo))
        Dim prodSA As New detalleitemsSA

        Dim dt As New DataTable
        dt.Columns.Add("Producto")
        dt.Columns.Add("Unidad")
        dt.Columns.Add("TipoExistenc")
        dt.Columns.Add("ID")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("unidadComercial")

        For Each i In ListaItemsConexos
            Dim item = prodSA.InvocarProductoID(i.codigodetalle)
            dt.Rows.Add(item.descripcionItem, item.unidad1, item.tipoExistencia, i.codigodetalle, i.cantidad.GetValueOrDefault, i.equivalencia_id)
        Next
        GridEquivalencia.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub txtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProducto.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then

            'If ComboAlmacen.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Ingrese el almaén de destino!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    ComboDespacho.Select()
            '    ComboDespacho.DroppedDown = True
            '    Exit Sub
            'End If

            PictureLoadingProduct.Visible = True
            listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = txtProducto.Text})

            ListProductos.Items.Clear()

            If listaProductos.Count > 0 Then
                Dim consulta As New List(Of detalleitems)
                ' consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                consulta.AddRange(listaProductos)
                GetListProductos(consulta)

                Me.PopupProductos.Size = New Size(563, 147)
                Me.PopupProductos.ParentControl = Me.txtProducto
                Me.PopupProductos.ShowPopup(Point.Empty)
                PictureLoadingProduct.Visible = False
            Else
                'If Me.PopupProductos.IsShowing() Then
                '    Me.PopupProductos.HidePopup(PopupCloseType.Canceled)
                'End If
                'PictureLoadingProduct.Visible = False

                'If MessageBox.Show("Desea crear el producto ahora?", "Nuevo producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '    Dim frmNuevaExistencia As New frmNuevaExistencia
                '    With frmNuevaExistencia
                '        If TextBoxExt1.Text.Trim.Length > 0 Then
                '            .UCNuenExistencia.txtProductoNew.Text = TextBoxExt1.Text.Trim
                '        End If

                '        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '            .UCNuenExistencia.cboTipoExistencia.Enabled = False
                '            .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                '            .UCNuenExistencia.cboUnidades.Enabled = True
                '        Else

                '        End If

                '        If Gempresas.Regimen = "1" Then
                '            .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                '            .UCNuenExistencia.cboIgv.Enabled = True
                '        Else
                '            .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                '            .UCNuenExistencia.cboIgv.Enabled = True
                '        End If
                '        .UCNuenExistencia.chClasificacion.Checked = False
                '        .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
                '        .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
                '        .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog(Me)
                '        If frmNuevaExistencia.Tag IsNot Nothing Then
                '            Dim p = CType(frmNuevaExistencia.Tag, detalleitems)
                '            Dim prod = ProductoSA.GetUbicaProductoID(p.codigodetalle)
                '            listaProductos.Add(prod)
                '            AgregarProductoDetalleCompra(prod)
                '        End If
                '    End With
                'End If
            End If

        Else
            'Me.PopupProductos.Size = New Size(319, 128)
            'Me.PopupProductos.ParentControl = Me.TextBoxExt1
            'Me.PopupProductos.ShowPopup(Point.Empty)
            'Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
            'Dim consulta2 = (From n In listaProveedores
            '                 Where n.nombreCompleto.StartsWith(txtProveedor.Text) Or n.nrodoc.StartsWith(txtProveedor.Text)).ToList

            'consulta.AddRange(consulta2)
            'FillLSVProveedores(consulta)
            'e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupProductos.Size = New Size(563, 147)
            Me.PopupProductos.ParentControl = Me.txtProducto
            Me.PopupProductos.ShowPopup(Point.Empty)
            ListProductos.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PopupProductos.IsShowing() Then
                Me.PopupProductos.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub PopupProductos_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupProductos.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If ListProductos.SelectedItems.Count > 0 Then
                'If ListProductos.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                '    Dim frmNuevaExistencia As New frmNuevaExistencia
                '    With frmNuevaExistencia
                '        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '            .UCNuenExistencia.cboTipoExistencia.Enabled = False
                '            .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                '            .UCNuenExistencia.cboUnidades.Enabled = True
                '        Else

                '        End If

                '        If Gempresas.Regimen = "1" Then
                '            .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                '            .UCNuenExistencia.cboIgv.Enabled = True
                '        Else
                '            .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                '            .UCNuenExistencia.cboIgv.Enabled = True
                '        End If
                '        .UCNuenExistencia.chClasificacion.Checked = False
                '        .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
                '        .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
                '        .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '        If frmNuevaExistencia.Tag IsNot Nothing Then
                '            Dim p = CType(frmNuevaExistencia.Tag, detalleitems)
                '            Dim prod = ProductoSA.GetUbicaProductoID(p.codigodetalle)
                '            listaProductos.Add(prod)
                '            AgregarProductoDetalleCompra(prod)
                '        End If
                '    End With
                'Else
                '    AgregarProductoDetalleCompra(ListProductos.SelectedItems(0))
                'End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)


                Dim itemProd = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(ListProductos.SelectedItems(0).Text)).SingleOrDefault
                If itemProd IsNot Nothing Then
                    ListaItemsConexos.Add(New detalleitems_conexo With
                                          {
                                          .customdetalleitems = itemProd,
                                          .codigodetalle = itemProd.codigodetalle, .detalle = itemProd.descripcionItem,
                                          .cantidad = 1,
                                          .idProducto = itemProd.codigodetalle,
                                          .customEquivalencia = itemProd.detalleitem_equivalencias.FirstOrDefault,
                                          .equivalencia_id = itemProd.detalleitem_equivalencias.FirstOrDefault.equivalencia_id,
                                          .unidadComercial = itemProd.detalleitem_equivalencias.FirstOrDefault.unidadComercial,
                                          .fraccion = itemProd.detalleitem_equivalencias.FirstOrDefault.fraccionUnidad
                                          })
                    LoadProductosConexos()
                End If

            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            txtProducto.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim codigoProd = GridEquivalencia.Table.CurrentRecord.GetValue("ID")

        Dim prod = ListaItemsConexos.Where(Function(o) o.codigodetalle = codigoProd).SingleOrDefault
        If prod IsNot Nothing Then
            ListaItemsConexos.Remove(prod)
            LoadProductosConexos()
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridEquivalencia.TableControlCellClick

    End Sub

    Private Sub GridEquivalencia_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridEquivalencia.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = GridEquivalencia.TableControl.CurrentCell
        cc.ConfirmChanges()

        If cc.ColIndex > -1 Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "cantidad" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    cc.Renderer.ControlValue = text
                    Dim r = GridEquivalencia.Table.CurrentRecord
                    Dim cod = r.GetValue("ID")

                    Dim item = ListaItemsConexos.Where(Function(o) o.codigodetalle = cod).SingleOrDefault
                    If item IsNot Nothing Then
                        item.cantidad = CDec(text)
                    End If
                End If
            ElseIf style.TableCellIdentity.Column.Name = "unidadComercial" Then
                If cc.Renderer IsNot Nothing Then
                    Dim text As String = cc.Renderer.ControlText

                    If text.Trim.Length > 0 Then
                        'If e.TableControl.CurrentCell.IsChanging = True Then
                        Dim r = GridEquivalencia.Table.CurrentRecord

                        If r IsNot Nothing Then
                            Dim cod = r.GetValue("ID")
                            Dim item = ListaItemsConexos.Where(Function(o) o.codigodetalle = cod).SingleOrDefault
                            If item IsNot Nothing Then

                                Dim codeEQ = r.GetValue("unidadComercial")
                                Dim prodEQ = item.customdetalleitems.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codeEQ).SingleOrDefault
                                item.customEquivalencia = prodEQ
                                item.equivalencia_id = prodEQ.equivalencia_id
                                item.unidadComercial = prodEQ.unidadComercial
                                item.fraccion = prodEQ.fraccionUnidad
                                LoadProductosConexos()
                                'EditarItemCompra(GridCompra.Table.CurrentRecord)
                            End If
                        End If
                        '  End If
                    End If
                End If
            End If
        End If





    End Sub

    Private Sub GridEquivalencia_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridEquivalencia.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "unidadComercial" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            'Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idProducto").ToString()
            Dim codigo As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("ID").ToString()
            Dim p = ListaItemsConexos.Where(Function(o) o.codigodetalle = codigo).SingleOrDefault
            If p IsNot Nothing Then
                If p.customdetalleitems.detalleitem_equivalencias IsNot Nothing Then
                    If p.customdetalleitems.detalleitem_equivalencias.Count > 0 Then
                        Dim listaEquivalencias = p.customdetalleitems.detalleitem_equivalencias.ToList

                        e.Style.DataSource = GetEquivalencias(listaEquivalencias)
                        e.Style.DisplayMember = "unidadComercial"
                        e.Style.ValueMember = "equivalencia_id"
                    End If
                End If
            End If

        End If
    End Sub

    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("fraccion")

        dt.Columns(0).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.unidadComercial, i.fraccionUnidad)
        Next
        Return dt
    End Function

    Private Sub txtProducto_TextChanged(sender As Object, e As EventArgs) Handles txtProducto.TextChanged

    End Sub

    Private Sub ListProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListProductos.SelectedIndexChanged

    End Sub

    Private Sub ListProductos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListProductos.MouseDoubleClick
        If ListProductos.SelectedItems.Count > 0 Then
            'If ListProductos.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
            '    Dim frmNuevaExistencia As New frmNuevaExistencia
            '    With frmNuevaExistencia
            '        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            '            .UCNuenExistencia.cboTipoExistencia.Enabled = False
            '            .UCNuenExistencia.cboUnidades.SelectedIndex = -1
            '            .UCNuenExistencia.cboUnidades.Enabled = True
            '        Else

            '        End If

            '        If Gempresas.Regimen = "1" Then
            '            .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
            '            .UCNuenExistencia.cboIgv.Enabled = True
            '        Else
            '            .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
            '            .UCNuenExistencia.cboIgv.Enabled = True
            '        End If
            '        .UCNuenExistencia.chClasificacion.Checked = False
            '        .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            '        .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            '        .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            '        .StartPosition = FormStartPosition.CenterParent
            '        .ShowDialog()
            '        If frmNuevaExistencia.Tag IsNot Nothing Then
            '            Dim p = CType(frmNuevaExistencia.Tag, detalleitems)
            '            Dim prod = ProductoSA.GetUbicaProductoID(p.codigodetalle)
            '            listaProductos.Add(prod)
            '            AgregarProductoDetalleCompra(prod)
            '        End If
            '    End With
            'Else
            '    AgregarProductoDetalleCompra(ListProductos.SelectedItems(0))
            'End If
            'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)


            Dim itemProd = listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(ListProductos.SelectedItems(0).Text)).SingleOrDefault
            If itemProd IsNot Nothing Then
                ListaItemsConexos.Add(New detalleitems_conexo With
                                      {
                                      .customdetalleitems = itemProd,
                                      .codigodetalle = itemProd.codigodetalle, .detalle = itemProd.descripcionItem,
                                      .cantidad = 1,
                                      .idProducto = itemProd.codigodetalle,
                                      .customEquivalencia = itemProd.detalleitem_equivalencias.FirstOrDefault,
                                      .equivalencia_id = itemProd.detalleitem_equivalencias.FirstOrDefault.equivalencia_id,
                                      .unidadComercial = itemProd.detalleitem_equivalencias.FirstOrDefault.unidadComercial,
                                      .fraccion = itemProd.detalleitem_equivalencias.FirstOrDefault.fraccionUnidad
                                      })
                LoadProductosConexos()
            End If

        End If
    End Sub
#End Region

End Class
