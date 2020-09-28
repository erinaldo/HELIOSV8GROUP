Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class UCCanstaDeVentas

#Region "Attributes"
    Public Property UCEstructuraCabeceraVenta As UCEstructuraCabeceraVentaV2
    'Private UCPreciosCanastaVenta As UCPreciosCanastaVenta
#End Region

#Region "Constructors"
    Public Sub New(ucVenta As UCEstructuraCabeceraVentaV2)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'UCPreciosCanastaVenta = New UCPreciosCanastaVenta With {.Dock = DockStyle.Fill}
        ' PanelBody.Controls.Add(UCPreciosCanastaVenta)
        'FormatoGridAvanzado(GridTotales, False, False, 9.0F)
        'UCEstructuraCabeceraVenta = ucVenta
        'Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        'Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DisplayMember = "detalle"
        'Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        'Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        'Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCell


        'Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        'Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DisplayMember = "nombre_corto"
        'Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.ValueMember = "idCatalogo"

        ''     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
        'Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive


        'OrdenamientoGrid(GridTotales, False)
        'GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Events"
    'Private Sub GetProductosEnAlmacen(idProducto As Integer)
    '    Dim invSA As New TotalesAlmacenSA

    '    Dim listaInventario = invSA.GetDetalleLoteXproductoFullAlmacen(New totalesAlmacen With
    '                                                                   {
    '                                                                   .idEmpresa = Gempresas.IdEmpresaRuc,
    '                                                                   .idItem = idProducto
    '                                                                   })

    '    ListInventario.Items.Clear()

    '    For Each i In listaInventario
    '        Dim n As New ListViewItem(i.idAlmacen)
    '        n.SubItems.Add(i.NomAlmacen)
    '        n.SubItems.Add(i.CustomLote.codigoLote)
    '        n.SubItems.Add(i.CustomLote.nroLote)
    '        n.SubItems.Add(i.cantidad)
    '        n.SubItems.Add(i.CustomLote.fechaentrada)
    '        n.SubItems.Add(i.CustomLote.fechaVcto)
    '        n.SubItems.Add(i.CustomLote.productoSustentado)
    '        ListInventario.Items.Add(n)
    '    Next
    '    ListInventario.Refresh()

    '    Dim cantidadTotal = listaInventario.Sum(Function(o) o.cantidad)
    '    TextStockTotal.Text = CDec(cantidadTotal).ToString("N2")

    '    Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

    '    TextProductoSel.Text = producto.descripcionItem
    'End Sub

    Private Sub GridTotales_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridTotales.TableControlCellClick
        Dim r As Record = GridTotales.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridTotales.Table.Records.Count > 0 Then
                Dim value As String = r.GetValue("idItem").ToString()
                Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

                If idEquiva.Trim.Length > 0 Then
                    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                    Dim idCat = r.GetValue("cboPrecios").ToString()
                    If idCat.Trim.Length > 0 Then
                        Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                        '   UCPreciosCanastaVenta.ListInventario.Items.Clear()

                        If OBJCatalog IsNot Nothing Then
                            Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                            '     UCPreciosCanastaVenta.GetDetallePrecios(lista)
                        End If
                    Else
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GridTotales_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridTotales.TableControlKeyDown
        Try
            Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
            If cc.RowIndex > -1 Then
                If e.Inner.KeyCode = Keys.Up Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
                        '                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        'Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                        If currenrecord IsNot Nothing Then
                            Dim value As String = currenrecord.GetValue("idItem").ToString()
                            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                            Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

                            If idEquiva.Trim.Length > 0 Then
                                Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                Dim idCat = currenrecord.GetValue("cboPrecios").ToString()
                                If idCat.Trim.Length > 0 Then
                                    Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault
                                    '       UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then

                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)

                                        '         UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                    End If
                                Else
                                End If
                            End If
                        End If

                    End If
                ElseIf e.Inner.KeyCode = Keys.Down Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex + 1, cc.ColIndex), GridTableCellStyleInfo)
                        If style.TableCellIdentity IsNot Nothing Then
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            ' Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                            '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                            If currenrecord IsNot Nothing Then
                                Dim value As String = currenrecord.GetValue("idItem").ToString()
                                Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                                Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

                                If idEquiva.Trim.Length > 0 Then
                                    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                    Dim idCat = currenrecord.GetValue("cboPrecios").ToString()
                                    If idCat.Trim.Length > 0 Then
                                        Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                                   '     UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                        If OBJCatalog IsNot Nothing Then
                                            Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                            '          UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                        End If

                                    Else
                                    End If
                                End If
                            End If
                        End If

                    End If

                Else
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                        'Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        'Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))

                        If currenrecord IsNot Nothing Then
                            Dim value As String = currenrecord.GetValue("idItem").ToString()
                            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                            Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

                            If idEquiva.Trim.Length > 0 Then
                                Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                Dim idCat = currenrecord.GetValue("cboPrecios").ToString()
                                If idCat.Trim.Length > 0 Then
                                    Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault
                                    '      UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then
                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                        '        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                    End If
                                Else
                                End If
                            End If
                        End If


                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("detalle")
        dt.Columns.Add("fraccion")

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.fraccionUnidad)
        Next
        Return dt
    End Function

    Private Function GetCatalogoPrecios(lista As List(Of detalleitemequivalencia_catalogos)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("idCatalogo")
        dt.Columns.Add("nombre_corto")
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
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim listaEquivalencias = prod.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

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
        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboPrecios" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
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
        Dim max = 0
        For index = 0 To lista.Count - 1
            Dim rangoMinimo = lista(index).rango_inicio
            If rangoMinimo = maxValor Then
                max = 0
            Else
                max = lista(index + 1).rango_inicio.GetValueOrDefault - 1
            End If
            ConvertirPreciosArangos.Add(AddItemNuevaListaPrecios(lista(index), rangoMinimo, max))
        Next
    End Function

    Private Function AddItemNuevaListaPrecios(be As detalleitemequivalencia_precios, rangoMinimo As Integer?, max As Integer) As detalleitemequivalencia_precios

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

    Private Function GetCalculoPrecioVenta(cantidadVenta As Decimal, idProducto As Integer, idEquivalencia As Integer, idCatalogo As Integer) As Decimal
        GetCalculoPrecioVenta = 0
        Dim objProducto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        If objProducto IsNot Nothing Then
            Dim listaEquivalencias = objProducto.detalleitem_equivalencias.ToList

            Dim objEQ = listaEquivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

            Dim catalogoOBJ = objEQ.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault

            If catalogoOBJ IsNot Nothing Then



                Dim ListaPrecios = catalogoOBJ.detalleitemequivalencia_precios.ToList
                Dim listaDeRangos = ConvertirPreciosArangos(ListaPrecios)

                If listaDeRangos.Count = 0 Or listaDeRangos Is Nothing Then
                    Throw New Exception("El producto no tiene precios de venta asignados")
                End If

                For Each i In listaDeRangos
                    Dim rango_inicio = i.rango_inicio
                    Dim rango_fin = i.rango_final
                    If cantidadVenta >= rango_inicio AndAlso rango_fin = 0 Then
                        Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                            Case "CONTADO"
                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                            Case "CREDITO"
                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                        End Select
                        Exit Function
                    End If
                    If cantidadVenta >= rango_inicio AndAlso cantidadVenta <= rango_fin Then
                        Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                            Case "CONTADO"
                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                            Case "CREDITO"
                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                        End Select
                        Exit Function
                    End If
                Next
            Else
                Throw New Exception("Debe configurar los catálogos de precios!")
            End If
        End If
    End Function


    Private Sub GridTotales_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridTotales.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 9 Then

                Dim equivalencia = GridTotales.TableModel(e.Inner.RowIndex, 6).CellValue
                Dim CatalogoPrecio = GridTotales.TableModel(e.Inner.RowIndex, 7).CellValue

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

                            Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                            precioVenta = precioventaFormula

                            Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                            If eqLista.productoRestringido = True Then
                                If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If

                            Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
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
                '  GetProductosEnAlmacen(idProducto)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar")
        End Try

        Me.Cursor = Cursors.Default
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
                If r IsNot Nothing Then

                    'r.SetValue("cboPrecios", String.Empty)
                    'r.SetValue("cboEquivalencias", String.Empty)
                    'r.SetValue("importeMn", 0)
                End If
                'If text.Trim.Length > 0 Then
                '    Dim value As Decimal = Convert.ToDecimal(text)
                '    cc.Renderer.ControlValue = value

                'End If
            ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then

                'Dim r = style.TableCellIdentity.Table.CurrentRecord
                'If r IsNot Nothing Then
                '    Dim value As String = r.GetValue("idItem").ToString()
                '    Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                '    Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

                '    If idEquiva.Trim.Length > 0 Then
                '        Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                '        Dim idCat = r.GetValue("cboPrecios").ToString()
                '        If idCat.Trim.Length > 0 Then
                '            Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                '            UCPreciosCanastaVenta.ListInventario.Items.Clear()

                '            If OBJCatalog IsNot Nothing Then
                '                Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                '                UCPreciosCanastaVenta.GetDetallePrecios(lista)
                '            End If
                '        Else
                '        End If
                '    End If
                'End If

                'Dim text As String = cc.Renderer.ControlText

                'Dim r As Record = GridTotales.Table.CurrentRecord
                'If r IsNot Nothing Then
                '    Dim value As String = r.GetValue("idItem").ToString()
                '    Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                '    Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

                '    If idEquiva.Trim.Length > 0 Then
                '        Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single

                '        Dim idCat = r.GetValue("cboPrecios").ToString()
                '        Dim style2 As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex + 1)
                '        If idCat.Trim.Length > 0 Then

                '            Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                '            'Dim listaCatalog = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
                '            Dim listaPreciosVenta = GetDetallePrecios(OBJCatalog.detalleitemequivalencia_precios.ToList)


                '            'style2.DataSource = listaPreciosVenta 'OBJCatalog.detalleitemequivalencia_precios.ToList
                '            'style2.DisplayMember = "precio"
                '            'style2.ValueMember = "precio_id"

                '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
                '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
                '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.ValueMember = "precio"
                '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DataSource = listaPreciosVenta
                '            '     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
                '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
                '        Else
                '            'style2.DataSource = Nothing
                '            'style2.DisplayMember = "precio"
                '            'style2.ValueMember = "precio_id"
                '        End If


                '    End If
                'End If

            ElseIf style.TableCellIdentity.Column.Name = "importeMn" Then

            End If

        End If

    End Sub

    'Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    'End Sub

    'Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
    '    Try
    '        If e.KeyCode = Keys.Enter Then
    '            e.SuppressKeyPress = True
    '            BunifuThinButton24_Click(sender, e)
    '        ElseIf e.KeyCode = Keys.Down Then
    '            If GridTotales.Table.Records.Count > 0 Then
    '                Dim colIndex As Integer = Me.GridTotales.TableDescriptor.FieldToColIndex(0)
    '                Dim rowIndex As Integer = Me.GridTotales.Table.Records(0).GetRowIndex()
    '                Me.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
    '                Me.GridTotales.Focus()

    '                'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
    '                'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()

    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub GridTotales_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridTotales.TableControlCurrentCellKeyDown
        Try
            If e.Inner.KeyCode = Keys.Enter Then
                Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
                Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
                cc.ConfirmChanges()
                If cc.Renderer IsNot Nothing Then

                    If cc.ColIndex > -1 Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                        If style.TableCellIdentity.Column.Name = "cboEquivalencias" Then
                            Dim equivalencia = GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                            Dim CatalogoPrecio = GridTotales.Table.CurrentRecord.GetValue("cboPrecios")
                            ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                            Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

                            If eqLista.productoRestringido = True Then
                                If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If

                            Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            'If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                            '    Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                            '    If catalogPredeterminado IsNot Nothing Then
                            '        GridTotales.Table.CurrentRecord.SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                            '    Else
                            '        GridTotales.Table.CurrentRecord.SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                            '    End If
                            '    Me.GridTotales.Table.CurrentRecord.SetCurrent("cboPrecios")
                            '    Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                            'End If

                            'Agregando Producto
                            '-----------------------------------------------------------------------------------------
                            '*******************************************************************************************

                            If CatalogoPrecio.ToString.Trim.Length = 0 Then
                                MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If

                            Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                            Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                            Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                            If inp IsNot Nothing Then
                                If IsNumeric(inp) Then
                                    If (inp) > 0 Then

                                        Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                                        precioVenta = precioventaFormula

                                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
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
                                Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                                If inp IsNot Nothing Then
                                    If IsNumeric(inp) Then
                                        If (inp) > 0 Then

                                            Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                                            precioVenta = precioventaFormula

                                            Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                                            Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                                            Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                                            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
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

                        Else 'If style.TableCellIdentity.Column.Name = "totalmn" Then
                            Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                            Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar!")
        End Try

    End Sub

    'Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
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
    '    End With
    'End Sub

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
            '                Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
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

    'Private Sub CheckStock_OnChange(sender As Object, e As EventArgs) Handles CheckStock.OnChange
    '    If UCEstructuraCabeceraVenta.CheckStock.Checked = True Then
    '        GridTotales.TableDescriptor.Columns("cantidad").Width = 70
    '    ElseIf CheckStock.Checked = False Then
    '        GridTotales.TableDescriptor.Columns("cantidad").Width = 0
    '    End If
    'End Sub
#End Region

End Class
