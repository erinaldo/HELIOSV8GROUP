Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping


Public Class FormCanastaProductsGeneral
    Public Property listaProductos As List(Of detalleitems)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        FormatoGridBlack(GridTotales, False)
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCell


        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DisplayMember = "nombre_corto"
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.ValueMember = "idCatalogo"

        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive

        GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.Escape
                Close()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("fraccion")


        dt.Columns(0).ColumnMapping = MappingType.Hidden

        For Each i In lista.Where(Function(o) o.estado = "A").ToList
            dt.Rows.Add(i.equivalencia_id, i.unidadComercial, i.fraccionUnidad)
        Next
        Return dt
    End Function

    Private Function GetCatalogoPrecios(lista As List(Of detalleitemequivalencia_catalogos)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("idCatalogo")
        dt.Columns.Add("nombre_corto")

        dt.Columns(0).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.idCatalogo, i.nombre_corto)
        Next

        'Dim dt As New DataTable
        'dt.Columns.Add("idCatalogo")
        'dt.Columns.Add("nombre_corto")
        'dt.Columns.Add("Cant.minima")
        'dt.Columns.Add("Al credito")
        'dt.Columns.Add("Al contado")
        'For Each i In lista
        '    dt.Rows.Add(i.idCatalogo, i.nombre_corto)
        '    For Each prec In i.detalleitemequivalencia_precios
        '        dt.Rows.Add(Nothing, Nothing, prec.rango_inicio, prec.precioCredito, prec.precio)
        '    Next
        'Next
        Return dt
    End Function

    Private Sub GridTotales_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridTotales.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboEquivalencias" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim listaEquivalencias = prod.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

            '   If value = "a" Then
            e.Style.DataSource = GetEquivalencias(listaEquivalencias)
            e.Style.DisplayMember = "unidadComercial"
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
        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboPrecios" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim idEquiva = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cboEquivalencias").ToString()
            If idEquiva.Trim.Length > 0 Then
                Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                Dim listaPreciosVenta = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
                e.Style.DataSource = listaPreciosVenta
                e.Style.DisplayMember = "nombre_corto"
                e.Style.ValueMember = "idCatalogo"
            Else
                e.Style.DataSource = Nothing
                e.Style.DisplayMember = "nombre_corto"
                e.Style.ValueMember = "idCatalogo"
            End If
            'If idEquiva.Trim.Length > 0 Then
            '    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
            '    Dim listaPreciosVenta = GetPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
            '    e.Style.DataSource = listaPreciosVenta
            '    e.Style.DisplayMember = "precioCode"
            '    e.Style.ValueMember = "precio"
            'Else
            '    e.Style.DataSource = Nothing
            '    e.Style.DisplayMember = "precioCode"
            '    e.Style.ValueMember = "precio"
            'End If
        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "importeMn" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then


        End If
    End Sub

    Private Function GetDetallePrecios(ListaPrecios As List(Of detalleitemequivalencia_precios)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("precio_id")
        dt.Columns.Add("precioCode")
        dt.Columns.Add("rango_inicio")
        dt.Columns.Add("precio")
        dt.Columns.Add("precioCredito")

        For Each i In ListaPrecios
            dt.Rows.Add(i.precio_id, i.precioCode, i.rango_inicio, i.precio, i.precioCredito)
        Next
        Return dt
    End Function



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

    Private Function ConvertirPreciosArangos(lista As List(Of detalleitemequivalencia_precios)) As List(Of detalleitemequivalencia_precios)
        '   Dim ListaEntera = GetConverToListInteger(lista)

        ConvertirPreciosArangos = New List(Of detalleitemequivalencia_precios)

        Dim maxValor = lista.Max(Function(o) o.rango_inicio).GetValueOrDefault
        Dim max As Decimal = 0
        For index = 0 To lista.Count - 1
            Dim rangoMinimo = lista(index).rango_inicio
            If rangoMinimo = maxValor Then
                max = 0
            Else
                Dim max1 = lista(index + 1).rango_inicio.GetValueOrDefault
                If max1 <= 1 Then
                    max = lista(index + 1).rango_inicio.GetValueOrDefault - 0.01
                Else
                    max = lista(index + 1).rango_inicio.GetValueOrDefault - 1
                End If
            End If
            ConvertirPreciosArangos.Add(AddItemNuevaListaPrecios(lista(index), rangoMinimo, max))
        Next
    End Function

    Private Function AddItemNuevaListaPrecios(be As detalleitemequivalencia_precios, rangoMinimo As Decimal?, max As Decimal) As detalleitemequivalencia_precios

        AddItemNuevaListaPrecios = New detalleitemequivalencia_precios
        AddItemNuevaListaPrecios = be
        AddItemNuevaListaPrecios.rango_inicio = rangoMinimo
        AddItemNuevaListaPrecios.rango_final = max
    End Function

    'Private Function GetConverToListInteger(lista As List(Of detalleitemequivalencia_precios)) As List(Of Integer)
    '    GetConverToListInteger = New List(Of Integer)
    '    For Each i In lista
    '        GetConverToListInteger.Add(i.rango_inicio)
    '    Next
    'End Function


    Private Sub GridTotales_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridTotales.TableControlCurrentCellCloseDropDown

        Try
            Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
            cc.ConfirmChanges()

            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)


                If style.TableCellIdentity.Column.Name = "cboEquivalencias" Then

                    'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                    'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()


                    '  Dim CodigoEQ As String = cc.Renderer.ControlText
                    'Dim r As Record = GridTotales.Table.CurrentRecord
                    If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                        cc.EndEdit()
                        '   Dim cc As GridCurrentCell = e.TableControl.CurrentCell
                        '   Dim cr As GridComboBoxCellRenderer = TryCast(cc.Renderer, GridComboBoxCellRenderer)

                        'If cc.Renderer.HasFocusControl IsNot Nothing Then
                        '    Console.WriteLine(cr.ListBoxPart.SelectedIndex)
                        'End If
                        Select Case cc.MoveToColIndex
                            Case 6

                                If e.Inner.PopupCloseType = Syncfusion.Windows.Forms.PopupCloseType.Canceled Then

                                ElseIf e.Inner.PopupCloseType = Syncfusion.Windows.Forms.PopupCloseType.Deactivated Then

                                ElseIf e.Inner.PopupCloseType = Syncfusion.Windows.Forms.PopupCloseType.Done Then
                                    Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                                    Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

                                    Dim producto = listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

                                    Dim UnidadesLista = producto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

                                    Dim Unidades = UnidadesLista.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault

                                    If Unidades Is Nothing Then
                                        MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If

                                    producto.customdetalleitem_equivalencias = Unidades

                                    If Unidades.detalleitemequivalencia_catalogos IsNot Nothing Then
                                        If Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                                            Dim cataPredeterminado = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True AndAlso c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault

                                            If cataPredeterminado IsNot Nothing Then
                                                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cataPredeterminado.idCatalogo)
                                                producto.customdetalleitemequivalencia_catalogos = cataPredeterminado

                                            ElseIf Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                                                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", Unidades.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                                producto.customdetalleitemequivalencia_catalogos = Unidades.detalleitemequivalencia_catalogos.FirstOrDefault
                                            End If
                                        Else
                                            MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                    Else
                                        ' MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If

                                    Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
                                    Dim cat As detalleitemequivalencia_catalogos = Nothing

                                    If IsNumeric(idCatalogo) Then
                                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
                                    ElseIf idCatalogo.ToString.Trim.Length > 0 Then
                                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

                                        '    Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                                        ' UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                    Else
                                        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If

                                    If cat IsNot Nothing Then
                                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
                                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

                                        'Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                                        ' UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                    Else
                                        MessageBox.Show("Identificar un catalogo de precios valido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Exit Sub
                                    End If


                                    Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                                    'MessageBox.Show("Producto agregado")
                                    producto.customdetalleitemequivalencia_catalogos = cat
                                    Tag = producto
                                    Close()

                                    GridTotales.Table.CurrentRecord.EndEdit()
                                    'Me.GridTotales.TableControl.CurrentCell.CloseDropDown(Syncfusion.Windows.Forms.PopupCloseType.Done)
                                    'Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                                    'Me.GridTotales.TableControl.CurrentCell.CloseDropDown(Syncfusion.Windows.Forms.PopupCloseType.Deactivated)
                                    Me.GridTotales.TableControl.CurrentCell.MoveTo(cc.RowIndex, 1, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                                    'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).SetCurrent()
                                    'GridTotales.Table.Records(GridTotales.Table.Records.Count - 1).BeginEdit()
                                    Me.ActiveControl = Me.GridTotales.TableControl
                                    GridTotales.WantTabKey = True
                                    txtFiltrar.Clear()
                                    txtFiltrar.Select()

                                End If


                            Case Else

                        End Select


                    End If
                ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
                    If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                        cc.EndEdit()
                        Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                        Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

                        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

                        Dim Unidades = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault


                        Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
                        Dim cat As detalleitemequivalencia_catalogos = Nothing

                        If IsNumeric(idCatalogo) Then
                            cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
                        ElseIf idCatalogo.ToString.Trim.Length > 0 Then
                            cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

                            'Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                            'UCPreciosCanastaVenta.GetDetallePrecios(lista)
                        Else
                            MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If

                        If cat IsNot Nothing Then
                            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
                            cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

                            'Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                            'UCPreciosCanastaVenta.GetDetallePrecios(lista)
                        Else

                        End If
                    End If


                    'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                    'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                ElseIf style.TableCellIdentity.Column.Name = "importeMn" Then

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar precios")
        End Try

    End Sub

    Private Sub GetProductosVirtual()
        Dim listaSA As New detalleitemsSA
        ' GetProductosWithInventario
        'GetProductosWithEquivalencias
        Dim dt As New DataTable
        dt.Columns.Add("destino")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cboEquivalencias")
        dt.Columns.Add("cboPrecios")
        dt.Columns.Add("importeMn")


        listaProductos = ListadoProductosSingleton.Where(Function(o) o.descripcionItem.Contains(txtFiltrar.Text.Trim.ToString)).ToList

        Dim StockTotal As Decimal = 0
        For Each i In listaProductos
            'dt.Rows.Add(
            '    i.origenProducto,
            '    i.codigodetalle,
            '    i.descripcionItem,
            '    i.composicion,
            '    i.unidad1)

            '   Dim catalagoDefault As Object

            Dim catalagoDefault = i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

            StockTotal = 0
            If CheckStock.Checked = True Then
                StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            End If

            dt.Rows.Add(
              i.origenProducto,
              i.codigodetalle,
              i.descripcionItem,
              StockTotal,
              i.unidad1,
              i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0)
            '              If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precioCode, "0"),
            'If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precio, "0"))
        Next
        GridTotales.DataSource = dt
        GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        If txtFiltrar.Text.Trim.Length >= 2 Then
            Dim listaSA As New detalleitemsSA
            ' GetProductosWithInventario
            'GetProductosWithEquivalencias
            Dim dt As New DataTable
            dt.Columns.Add("destino")
            dt.Columns.Add("idItem")
            dt.Columns.Add("descripcion")
            dt.Columns.Add("cantidad")
            dt.Columns.Add("unidad")
            dt.Columns.Add("cboEquivalencias")
            dt.Columns.Add("cboPrecios")
            dt.Columns.Add("importeMn")


            If CheckStock.Checked = True Then
                listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                              {
                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                              .descripcionItem = txtFiltrar.Text
                                                              })

            Else

                listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                            {
                                                            .idEmpresa = Gempresas.IdEmpresaRuc,
                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                            .descripcionItem = txtFiltrar.Text
                                                            })
            End If

            Dim StockTotal As Decimal = 0
            For Each i In listaProductos
                'dt.Rows.Add(
                '    i.origenProducto,
                '    i.codigodetalle,
                '    i.descripcionItem,
                '    i.composicion,
                '    i.unidad1)

                '   Dim catalagoDefault As Object

                Dim catalagoDefault = i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                StockTotal = 0
                If CheckStock.Checked = True Then
                    StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
                End If

                dt.Rows.Add(
                  i.origenProducto,
                  i.codigodetalle,
                  i.descripcionItem,
                  StockTotal,
                  i.unidad1,
                  i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0)
                '              If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precioCode, "0"),
                'If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precio, "0"))
            Next
            GridTotales.DataSource = dt
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        End If


    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Try


            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case ToggleProducts.ToggleState
                    Case ToggleButton2.ToggleButtonState.OFF ' VIRTUAL
                      '  GetProductosVirtual()
                    Case ToggleButton2.ToggleButtonState.ON ' DATABASE
                        BunifuThinButton24_Click(sender, e)
                End Select

            ElseIf e.KeyCode = Keys.Down Then
                If GridTotales.Table.Records.Count > 0 Then
                    Dim colIndex As Integer = Me.GridTotales.TableDescriptor.FieldToColIndex(0)
                    Dim rowIndex As Integer = Me.GridTotales.Table.Records(0).GetRowIndex()
                    Me.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                    Me.GridTotales.Focus()

                    'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                    'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()

                End If
            Else

                Select Case ToggleProducts.ToggleState
                    Case ToggleButton2.ToggleButtonState.OFF ' VIRTUAL
                        If txtFiltrar.Text.Trim.Length > 0 Then
                            GetProductosVirtual()
                        End If
                    Case ToggleButton2.ToggleButtonState.ON ' DATABASE

                End Select

            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridTotales_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridTotales.TableControlCurrentCellKeyDown
        Try
            If e.Inner.KeyCode = Keys.Enter Then
                Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
                Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
                cc.ConfirmChanges()
                If cc.Renderer IsNot Nothing Then

                    If cc.ColIndex > -1 Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                        If style.TableCellIdentity.Column.Name = "cboEquivalenciasss" Then


                            cc.EndEdit()
                            e.TableControl.Table.EndEdit()
                            'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                            'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()

                            Dim equivalencia = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias") ' GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                            Dim CatalogoPrecio As Integer = 0 ' style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios") ' GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                            Dim codiProducto As Integer = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                            ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                            Dim eqLista = listaProductos.Where(Function(o) o.codigodetalle = codiProducto).SingleOrDefault ' GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

                            If eqLista.productoRestringido = True Then
                                If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If

                            Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                                If objEQ.detalleitemequivalencia_catalogos.Count > 0 Then
                                    Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                                    If catalogPredeterminado IsNot Nothing Then
                                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                                        CatalogoPrecio = catalogPredeterminado.idCatalogo
                                    Else
                                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                        CatalogoPrecio = objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo
                                    End If

                                    Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                                Else
                                    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            Else

                                MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                                'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                            End If

                            'Agregando Producto
                            '-----------------------------------------------------------------------------------------
                            '*******************************************************************************************
                            'If CatalogoPrecio.ToString.Trim.Length = 0 Then
                            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Me.Cursor = Cursors.Default
                            '    Exit Sub
                            'End If


                            'Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                            '  Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                            'Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                            '   If inp IsNot Nothing Then
                            'If IsNumeric(inp) Then
                            'If (inp) > 0 Then

                            'Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), codiProducto, equivalencia, CatalogoPrecio)
                            'precioVenta = precioventaFormula

                            'AgregarProductoDetalleVenta(inp, codiProducto, precioventaFormula, objEQ, CatalogoPrecio)
                            'LoadCanastaVentas(ListaproductosVendidos)

                            'Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                            'FormPurchase.ToolStrip1.Focus()
                            'FormPurchase.ToolStrip1.Select()
                            'Else
                            ' MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '           Me.Cursor = Cursors.Default
                            '  Exit Sub
                            'End If
                            'Else
                            '   MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '  Me.Cursor = Cursors.Default
                            ' Exit Sub
                            'End If


                            '-------------------------------------------------------------------------------------------------------------------------------
                            '-------------------------------------------------------------------------------------------------------------------------------

                            'CODIGO OLD---------------------------------------------------------------------------------------------------------------------------
                            '-------------------------------------------------------------------------------------------------------------------------------
                            '-------------------------------------------------------------------------------------------------------------------------------


                            'Dim equivalencia = GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                            'Dim CatalogoPrecio = GridTotales.Table.CurrentRecord.GetValue("cboPrecios")
                            '' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                            'Dim eqLista = listaProductos.Where(Function(o) o.codigodetalle = GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

                            'If eqLista.productoRestringido = True Then
                            '    If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            '        Me.Cursor = Cursors.Default
                            '        Exit Sub
                            '    End If
                            'End If

                            'Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            'Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            ''Agregando Producto
                            ''-----------------------------------------------------------------------------------------
                            ''*******************************************************************************************

                            'If CatalogoPrecio.ToString.Trim.Length = 0 Then
                            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Me.Cursor = Cursors.Default
                            '    Exit Sub
                            'End If

                            'Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                            'Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                            'Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                            'If inp IsNot Nothing Then
                            '    If IsNumeric(inp) Then
                            '        If (inp) > 0 Then

                            '            Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                            '            precioVenta = precioventaFormula

                            '            AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
                            '            LoadCanastaVentas(ListaproductosVendidos)
                            '        Else
                            '            MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '            Me.Cursor = Cursors.Default
                            '            Exit Sub
                            '        End If
                            '    Else
                            '        MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '        Me.Cursor = Cursors.Default
                            '        Exit Sub
                            '    End If
                            'Else
                            '    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Me.Cursor = Cursors.Default
                            'End If


                            'End If
                        ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
                            If Me.GridTotales.Table.CurrentRecord IsNot Nothing Then
                                Dim equivalencia = GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                                Dim CatalogoPrecio = GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                                If CatalogoPrecio.ToString.Trim.Length = 0 Then
                                    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If

                                If equivalencia.ToString.Trim.Length = 0 Then
                                    MessageBox.Show("Debe ingresar una equivalencia valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If


                                Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                                Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                                Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                                '   If inp IsNot Nothing Then
                                If IsNumeric(inp) Then
                                    If (inp) > 0 Then

                                        'Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                                        'precioVenta = precioventaFormula

                                        Dim eqLista = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                                        Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                                        Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                                        'MessageBox.Show("Producto agregado 2")
                                        'Close()

                                        'AgregarProductoDetalleVenta(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio)
                                        'LoadCanastaVentas(ListaproductosVendidos)

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
                                'Else
                                '    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                '    Me.Cursor = Cursors.Default
                                'End If
                            End If
                            Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                            Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                            'If Me.GridTotales.Table.CurrentRecord IsNot Nothing Then
                            '    Dim equivalencia = GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                            '    Dim CatalogoPrecio = GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                            '    If CatalogoPrecio.ToString.Trim.Length = 0 Then
                            '        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '        Me.Cursor = Cursors.Default
                            '        Exit Sub
                            '    End If

                            '    If equivalencia.ToString.Trim.Length = 0 Then
                            '        MessageBox.Show("Debe ingresar una equivalencia valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '        Me.Cursor = Cursors.Default
                            '        Exit Sub
                            '    End If


                            '    Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                            '    Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                            '    Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                            '    If inp IsNot Nothing Then
                            '        If IsNumeric(inp) Then
                            '            If (inp) > 0 Then

                            '                Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                            '                precioVenta = precioventaFormula

                            '                Dim eqLista = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                            '                Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            '                Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            '                AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
                            '                LoadCanastaVentas(ListaproductosVendidos)
                            '            Else
                            '                MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '                Me.Cursor = Cursors.Default
                            '                Exit Sub
                            '            End If
                            '        Else
                            '            MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '            Me.Cursor = Cursors.Default
                            '            Exit Sub
                            '        End If
                            '    Else
                            '        MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '        Me.Cursor = Cursors.Default
                            '    End If
                            'End If
                            'ElseIf style.TableCellIdentity.Column.Name = "descripcion" Then
                            'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                            'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                        ElseIf style.TableCellIdentity.Column.Name = "descripcion" Then
                            Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                            'If Me.GridTotales.TableControl.CurrentCell.CloseDropDown(Syncfusion.Windows.Forms.PopupCloseType.Deactivated) Then
                            Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                            'End If
                        ElseIf style.TableCellIdentity.Column.Name = "cboEquivalencias" Then
                            Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                        ElseIf style.TableCellIdentity.Column.Name = "destino" Then
                            Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar!")
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
            'UCNuenExistencia.chClasificacion.Checked = False
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub GridTotales_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridTotales.TableControlCurrentCellChanged

    End Sub

    Private Sub GridTotales_TableControlCurrentCellShowingDropDown(sender As Object, e As GridTableControlCurrentCellShowingDropDownEventArgs) Handles GridTotales.TableControlCurrentCellShowingDropDown
        '      e.Inner.Size = New Size(100, 100)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            'If cc.ColIndex > -1 Then
            '    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)
            '    Dim r = style.TableCellIdentity.Table.CurrentRecord
            '    If style.TableCellIdentity.Column.Name = "importeMn" Then
            '        'If cc.Renderer IsNot Nothing Then
            '        Dim text As String = cc.Renderer.ControlText

            '            'If text.Trim.Length > 0 Then

            '            Dim value As String = e.TableControl.Table.TableModel(cc.RowIndex, 2).CellValue
            '                Dim prod = listaProductos.Where(Function(o) o.codigodetalle = value).Single
            '                Dim idEquiva = e.TableControl.Table.TableModel(cc.RowIndex, 6).CellValue.ToString()

            '                If idEquiva.Trim.Length > 0 Then
            '                    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single

            '                    Dim idCat = e.TableControl.Table.TableModel(cc.RowIndex, 7).CellValue.ToString()
            '                    If idCat.Trim.Length > 0 Then

            '                        Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

            '                        'Dim listaCatalog = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
            '                        Dim listaPreciosVenta = GetDetallePrecios(OBJCatalog.detalleitemequivalencia_precios.ToList)


            '                        'style2.DataSource = listaPreciosVenta 'OBJCatalog.detalleitemequivalencia_precios.ToList
            '                        'style2.DisplayMember = "precio"
            '                        'style2.ValueMember = "precio_id"

            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.ValueMember = "precio"
            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DataSource = listaPreciosVenta
            '                        '     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
            '                        Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
            '                    Else
            '                        'style2.DataSource = Nothing
            '                        'style2.DisplayMember = "precio"
            '                        'style2.ValueMember = "precio_id"
            '                    End If


            '                End If
            '            'End If

            '            'End If


            '        ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
            '        'If cc.Renderer IsNot Nothing Then
            '        '    Dim text As String = cc.Renderer.ControlText

            '        '    If text.Trim.Length > 0 Then
            '        '        If GridCompra.Table.CurrentRecord IsNot Nothing Then
            '        '            GetCalculoItem(GridCompra.Table.CurrentRecord)
            '        '            EditarItemVenta(GridCompra.Table.CurrentRecord)
            '        '            '   FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
            '        '        End If
            '        '        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
            '        '    End If
            '        'End If
            '    End If
            'End If
        End If

    End Sub

    Private Sub GridTotales_TableControlCurrentCellShowedDropDown(sender As Object, e As GridTableControlEventArgs) Handles GridTotales.TableControlCurrentCellShowedDropDown

    End Sub

    Private Sub CheckStock_OnChange(sender As Object, e As EventArgs) Handles CheckStock.OnChange
        If CheckStock.Checked = True Then
            GridTotales.TableDescriptor.Columns("cantidad").Width = 70
        ElseIf CheckStock.Checked = False Then
            GridTotales.TableDescriptor.Columns("cantidad").Width = 0
        End If
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        Dim detalleitemsSA As New detalleitemsSA
        txtFiltrar.Enabled = False
        Cursor = Cursors.WaitCursor
        ListadoProductosSingleton = detalleitemsSA.GetProductosWithInventario(New detalleitems With {
                                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                              .descripcionItem = ""
                                                                              })

        txtFiltrar.Enabled = True
        txtFiltrar.Select()
        Cursor = Cursors.Default
    End Sub

    Private Sub GridTotales_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridTotales.TableControlCellClick

    End Sub
End Class