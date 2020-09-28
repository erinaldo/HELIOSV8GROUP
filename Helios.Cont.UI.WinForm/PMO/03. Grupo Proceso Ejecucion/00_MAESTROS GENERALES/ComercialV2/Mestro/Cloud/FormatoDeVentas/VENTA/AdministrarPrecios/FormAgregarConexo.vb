Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormAgregarConexo

    Public Property CustomProducto As detalleitems
    Public Property CustomEquivalencia As List(Of detalleitem_equivalencias)
    Dim productoSA As New detalleitemsSA
    Public Property idProductoPadre As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CustomProducto = New detalleitems
        CustomEquivalencia = New List(Of detalleitem_equivalencias)

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


                Dim itemProd = productoSA.InvocarProductoID(Integer.Parse(ListProductos.SelectedItems(0).Text)) '  listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(ListProductos.SelectedItems(0).Text)).SingleOrDefault

                CustomProducto = itemProd
                txtProducto.Text = CustomProducto.descripcionItem
                CustomEquivalencia = CustomProducto.detalleitem_equivalencias
                ComboEquivalencias(CustomProducto.detalleitem_equivalencias)
                'If itemProd IsNot Nothing Then
                '    ListaItemsConexos.Add(New detalleitems_conexo With
                '                          {
                '                          .customdetalleitems = itemProd,
                '                          .codigodetalle = itemProd.codigodetalle, .detalle = itemProd.descripcionItem,
                '                          .cantidad = 1,
                '                          .idProducto = itemProd.codigodetalle,
                '                          .customEquivalencia = itemProd.detalleitem_equivalencias.FirstOrDefault,
                '                          .equivalencia_id = itemProd.detalleitem_equivalencias.FirstOrDefault.equivalencia_id,
                '                          .unidadComercial = itemProd.detalleitem_equivalencias.FirstOrDefault.unidadComercial,
                '                          .fraccion = itemProd.detalleitem_equivalencias.FirstOrDefault.fraccionUnidad
                '                          })
                '    LoadProductosConexos()
                'End If

            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            txtProducto.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ComboEquivalencias(detalleitem_equivalencias As List(Of detalleitem_equivalencias))
        ComboUnidades.DataSource = detalleitem_equivalencias
        ComboUnidades.ValueMember = "equivalencia_id"
        ComboUnidades.DisplayMember = "unidadComercial"
    End Sub

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
            Dim listaProductos = productoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = txtProducto.Text})

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

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        If CustomEquivalencia IsNot Nothing Then
            MessageBox.Show("Seleccionar un producto al menos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If CustomEquivalencia.Count = 0 Then
            MessageBox.Show("No tiene unidades comerciales disponibles!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If textCantidad.DecimalValue <= 0 Then
            MessageBox.Show("Ingrese una cantidad mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If CustomProducto IsNot Nothing Then
            Dim obj As New detalleitems_conexo
            Dim conexoSA As New detalleitems_conexoSA

            obj.codigodetalle = idProductoPadre
            obj.Action = BaseBE.EntityAction.INSERT
            obj.idProducto = CustomProducto.codigodetalle
            obj.detalle = CustomProducto.descripcionItem
            obj.cantidad = textCantidad.DecimalValue
            obj.equivalencia_id = ComboUnidades.SelectedValue
            obj.unidadComercial = ComboUnidades.Text
            obj.fraccion = TextFraccion.DecimalValue
            obj.estado = 1
            obj.usuarioActualizacion = usuario.IDUsuario
            obj.fechaActualizacion = Date.Now
            Dim objConexo = conexoSA.SaveConexo(obj)
            Tag = objConexo
            Close()
        Else
            MessageBox.Show("Seleccionar un producto al menos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ListProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListProductos.SelectedIndexChanged

    End Sub

    Private Sub ListProductos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListProductos.MouseDoubleClick
        If ListProductos.SelectedItems.Count > 0 Then
            Dim itemProd = productoSA.InvocarProductoID(Integer.Parse(ListProductos.SelectedItems(0).Text)) '  listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(ListProductos.SelectedItems(0).Text)).SingleOrDefault

            CustomProducto = itemProd
            txtProducto.Text = CustomProducto.descripcionItem
            CustomEquivalencia = CustomProducto.detalleitem_equivalencias
            ComboEquivalencias(CustomProducto.detalleitem_equivalencias)
        End If
    End Sub

    Private Sub ComboUnidades_Click(sender As Object, e As EventArgs) Handles ComboUnidades.Click

    End Sub

    Private Sub ComboUnidades_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboUnidades.SelectedValueChanged
        If IsNumeric(ComboUnidades.SelectedValue) Then
            Dim eq = CustomEquivalencia.Where(Function(o) o.equivalencia_id = ComboUnidades.SelectedValue).SingleOrDefault
            If eq IsNot Nothing Then
                TextFraccion.DecimalValue = eq.fraccionUnidad
            End If
        End If
    End Sub
End Class