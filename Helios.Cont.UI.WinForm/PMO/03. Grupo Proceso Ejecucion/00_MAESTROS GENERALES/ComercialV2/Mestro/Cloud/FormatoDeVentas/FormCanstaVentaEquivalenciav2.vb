Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class FormCanstaVentaEquivalenciav2

#Region "Attributes"
    Public Property UCEstructuraCabeceraVenta As UCEstructuraCabeceraVenta
#End Region

#Region "Constructors"
    Public Sub New(ucVenta As UCEstructuraCabeceraVenta)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridTotales, False, False, 9.0F)
        OrdenamientoGrid(GridTotales, False)
        UCEstructuraCabeceraVenta = ucVenta
        GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DisplayMember = "detalle"
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.ValueMember = "precio"
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridTotales, False, False, 9.0F)
        OrdenamientoGrid(GridTotales, False)
        'UCEstructuraCabeceraVenta = ucVenta
        GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DisplayMember = "detalle"
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.ValueMember = "precio"
    End Sub
#End Region

#Region "Methods"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            'Case Keys.F7
            '    ToolStripButton1.PerformClick()

            Case Keys.F9
                Me.Hide()

                'Case Keys.F10
                '    ToolStripButton2.PerformClick()

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("detalle")
        dt.Columns.Add("fraccion")

        dt.Columns(0).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.fraccionUnidad)
        Next
        Return dt
    End Function

    Private Function GetPrecios(lista As List(Of detalleitem_precios)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Rangoinicio")
        dt.Columns.Add("Hasta")
        dt.Columns.Add("Precio")
        dt.Columns.Add("Ct.c.igv")
        dt.Columns.Add("Ct.s.igv")
        dt.Columns.Add("Cr.c.igv")
        dt.Columns.Add("Cr.s.igv")

        For Each i In lista
            dt.Rows.Add(i.rango_inicio,
                        i.rango_final,
                        i.tipo_precio,
                        i.VContadoPrecioConIgv,
                        i.VContadoPrecioSinIgv,
                        i.VCreditoPrecioConIgv,
                        i.VCreditoPrecioSinIgv)
        Next
        Return dt
    End Function

    Private Sub GetProductosEnAlmacen(idProducto As Integer)
        Dim invSA As New TotalesAlmacenSA

        Dim listaInventario = invSA.GetDetalleLoteXproductoFullAlmacen(New totalesAlmacen With
                                                                       {
                                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                       .idItem = idProducto
                                                                       })

        ListInventario.Items.Clear()

        For Each i In listaInventario
            Dim n As New ListViewItem(i.idAlmacen)
            n.SubItems.Add(i.NomAlmacen)
            n.SubItems.Add(i.CustomLote.codigoLote)
            n.SubItems.Add(i.CustomLote.nroLote)
            n.SubItems.Add(i.cantidad)
            n.SubItems.Add(i.CustomLote.fechaentrada)
            n.SubItems.Add(i.CustomLote.fechaVcto)
            n.SubItems.Add(i.CustomLote.productoSustentado)
            ListInventario.Items.Add(n)
        Next
        ListInventario.Refresh()

        Dim cantidadTotal = listaInventario.Sum(Function(o) o.cantidad)
        TextStockTotal.Text = CDec(cantidadTotal).ToString("N2")

        Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        TextProductoSel.Text = producto.descripcionItem
    End Sub
#End Region

#Region "Events"

    Private Sub GridTotales_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridTotales.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboEquivalencias" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim listaEquivalencias = prod.detalleitem_equivalencias.ToList

            '   If value = "a" Then
            e.Style.DataSource = GetEquivalencias(listaEquivalencias)
            e.Style.DisplayMember = "detalle"
            e.Style.ValueMember = "equivalencia_id"
            'ElseIf value = "b" Then
            '    e.Style.DataSource = ZipCodes
            '    e.Style.DisplayMember = "City"
            '    e.Style.ValueMember = "Class"
            'ElseIf value = "c" Then
            '    e.Style.DataSource = Shippers
            '    e.Style.DisplayMember = "Shipper ID"
            '    e.Style.ValueMember = "Company Name"
            'End If

            'Dim idEquiva = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cboEquivalencias").ToString()
            'If idEquiva.Trim.Length > 0 Then
            '    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
            '    Dim listaPreciosVenta = GetPrecios(objEquivalencia.detalleitemequivalencia_precios.ToList)
            '    e.Style.DataSource = listaPreciosVenta
            '    e.Style.DisplayMember = "precioCode"
            '    e.Style.ValueMember = "precio"
            'Else
            '    e.Style.DataSource = Nothing
            '    e.Style.DisplayMember = "precioCode"
            '    e.Style.ValueMember = "precio"
            'End If


        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboPrecios" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim listaPrecios = prod.detalleitem_precios.ToList

            '   If value = "a" Then
            e.Style.DataSource = GetPrecios(listaPrecios)
            e.Style.DisplayMember = "Precio"
            e.Style.ValueMember = "Precio"

        End If
    End Sub

    Private Sub GridTotales_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridTotales.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "Agregar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            ElseIf e.Inner.ColIndex = 10 Then
                e.Inner.Style.Description = "Stock"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
            End If
        End If
    End Sub

    Private Sub GridTotales_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridTotales.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 9 Then

                Dim equivalencia = GridTotales.TableModel(e.Inner.RowIndex, 6).CellValue
                Dim precio = GridTotales.TableModel(e.Inner.RowIndex, 7).CellValue

                If equivalencia.ToString.Trim.Length = 0 Then
                    MessageBox.Show("Debe ingresar una equivalencia valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                'If precio.ToString.Trim.Length = 0 Then
                '    MessageBox.Show("Debe ingresar un precio valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Me.Cursor = Cursors.Default
                '    Exit Sub
                'End If


                Dim idProducto = GridTotales.TableModel(e.Inner.RowIndex, 2).CellValue
                Dim precioVenta = 0 ' CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                If inp IsNot Nothing Then
                    If IsNumeric(inp) Then
                        If (inp) > 0 Then

                            Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto)
                            precioVenta = precioventaFormula

                            Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                            Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ)
                            UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
                        Else
                            MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Default
                End If
                'MsgBox("Cantidad: " & inp)
            ElseIf e.Inner.ColIndex = 10 Then
                Dim idProducto = GridTotales.TableModel(e.Inner.RowIndex, 2).CellValue
                GetProductosEnAlmacen(idProducto)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Function GetCalculoPrecioVenta(cantidadVenta As Decimal, idProducto As Integer) As Decimal
        GetCalculoPrecioVenta = 0
        Dim objProducto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        If objProducto IsNot Nothing Then
            Dim listaPrecios = objProducto.detalleitem_precios.ToList

            If listaPrecios.Count = 0 Or listaPrecios Is Nothing Then
                Throw New Exception("El producto no tiene precios de venta asignados")
            End If

            For Each i In listaPrecios
                Dim rango_inicio = i.rango_inicio
                Dim rango_fin = i.rango_final

                If cantidadVenta >= rango_inicio AndAlso cantidadVenta <= rango_fin Then
                    GetCalculoPrecioVenta = i.VContadoPrecioConIgv
                    Exit Function
                End If
            Next
        End If
    End Function

    Private Sub GridTotales_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridTotales.TableControlCurrentCellKeyDown
        Try
            If e.Inner.KeyCode = Keys.Enter Then
                If Me.GridTotales.Table.CurrentRecord IsNot Nothing Then
                    Dim equivalencia = GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                    Dim precio = GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                    If equivalencia.ToString.Trim.Length = 0 Then
                        MessageBox.Show("Debe ingresar una equivalencia valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If


                    Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                    Dim precioVenta = 0 ' CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                    Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                    If inp IsNot Nothing Then
                        If IsNumeric(inp) Then
                            If (inp) > 0 Then

                                Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto)
                                precioVenta = precioventaFormula

                                Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                                Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                                Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                                UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ)
                                UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
                            Else
                                MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Default
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar!")
        End Try

    End Sub

    Private Sub GridTotales_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridTotales.TableControlCurrentCellCloseDropDown

        Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
        cc.ConfirmChanges()

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        If cc.ColIndex > -1 Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "cboEquivalencias" Then
                'Dim CodigoEQ As String = cc.Renderer.ControlText
                Dim r As Record = GridTotales.Table.CurrentRecord
                r.SetValue("cboPrecios", String.Empty)
                'r.SetValue("cboEquivalencias", String.Empty)
                r.SetValue("importeMn", 0)

                'If text.Trim.Length > 0 Then
                '    Dim value As Decimal = Convert.ToDecimal(text)
                '    cc.Renderer.ControlValue = value

                'End If
            ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
                Dim text As String = cc.Renderer.ControlText

                'If text.Trim.Length > 0 Then
                '    Dim r As Record = GridTotales.Table.CurrentRecord

                '    Dim CodigoPrecio As String = text
                '    Dim codigoEQ = r.GetValue("cboEquivalencias")

                '    'cc.Renderer.ControlValue = CodigoPrecio

                '    Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = r.GetValue("idItem")).Single
                '    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(i) i.equivalencia_id = codigoEQ).SingleOrDefault
                '    If prod IsNot Nothing Then
                '        Dim precID = text
                '        Dim Precios = objEquivalencia.detalleitemequivalencia_precios.Where(Function(o) o.precioCode = precID).SingleOrDefault
                '        If Precios IsNot Nothing Then
                '            r.SetValue("importeMn", Precios.precio)
                '        End If
                '    End If
                'End If

            End If

        End If

    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Dim listaSA As New detalleitemsSA
        UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalenciasV2(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = txtFiltrar.Text
                                                          })


        Dim dt As New DataTable
        dt.Columns.Add("destino")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cboEquivalencias")
        dt.Columns.Add("cboPrecios")
        dt.Columns.Add("importeMn")

        For Each i In UCEstructuraCabeceraVenta.listaProductos
            dt.Rows.Add(
                i.origenProducto,
                i.codigodetalle,
                i.descripcionItem,
                i.composicion,
                i.unidad1,
                i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id,
                If(i.detalleitem_precios IsNot Nothing AndAlso i.detalleitem_precios.Count > 0, i.detalleitem_precios.FirstOrDefault.tipo_precio, "0"))
        Next
        GridTotales.DataSource = dt
        GridTotales.TableDescriptor.Columns("cantidad").Width = 0
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                BunifuThinButton24_Click(sender, e)
            ElseIf e.KeyCode = Keys.Down Then
                If GridTotales.Table.Records.Count > 0 Then
                    Dim colIndex As Integer = Me.GridTotales.TableDescriptor.FieldToColIndex(0)
                    Dim rowIndex As Integer = Me.GridTotales.Table.Records(0).GetRowIndex()
                    Me.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                    Me.GridTotales.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Dim frmNuevaExistencia As New frmNuevaExistencia
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            If Gempresas.Regimen = "1" Then
                .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            Else
                .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            End If
            '.UCNuenExistencia.chClasificacion.Checked = False
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub GridTotales_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridTotales.TableControlCellClick

    End Sub

    Private Sub BunifuCheckbox1_OnChange(sender As Object, e As EventArgs) Handles BunifuCheckbox1.OnChange

    End Sub
#End Region

End Class