Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Drawing

Public Class UserControlCanasta
    Public Property UCEstructuraCabeceraVenta As UCEstructuraCabeceraVentaV2
    Private UCPreciosCanastaVenta As UCPreciosCanastaVenta

    Public Property UCListaPrecios As UCListaPrecios
    Public Property UCListaLotes As UCListaLotes

    Public Event OKEvent()
    Public Sub New(ucVenta As UCEstructuraCabeceraVentaV2)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridCompra, False, False, 7.5F)
        UCEstructuraCabeceraVenta = ucVenta
        UCPreciosCanastaVenta = New UCPreciosCanastaVenta With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCPreciosCanastaVenta)
        Me.GridCompra.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridCompra.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
        Me.GridCompra.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        Me.GridCompra.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridCompra.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCell


        Me.GridCompra.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridCompra.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DisplayMember = "nombre_corto"
        Me.GridCompra.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.ValueMember = "idCatalogo"

        '     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
        Me.GridCompra.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive


        OrdenamientoGrid(GridCompra, False)
        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        btnOK.Visible = True


        UCListaLotes = New UCListaLotes(Me) With {.Dock = DockStyle.Fill}
        UCListaPrecios = New UCListaPrecios()
        PanelBody.Controls.Add(UCListaLotes)
        PanelBody.Controls.Add(UCListaPrecios)
        PanelBody.Controls.Add(PanellOTES)

        'AddHandler GridCompra.TableModel.QueryRowHeight, AddressOf TableModel_QueryRowHeight
        AddHandler GridCompra.TableControl.HScrollBar.Scroll, AddressOf HScrollBar_Scroll

    End Sub

    Private Sub HScrollBar_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs)
        If e.Type = ScrollEventType.EndScroll Then
            GridCompra.Refresh()
        End If
    End Sub


    Private Sub TableModel_QueryRowHeight(ByVal sender As Object, ByVal e As GridRowColSizeEventArgs)
        If e.Index > 0 Then
            Dim graphicsProvider As IGraphicsProvider = Me.GridCompra.TableModel.GetGraphicsProvider()
            Dim g As Graphics = graphicsProvider.Graphics
            Dim style As GridStyleInfo = Me.GridCompra.TableModel(e.Index, 3)
            Dim model As GridCellModelBase = style.CellModel
            e.Size = model.CalculatePreferredCellSize(g, e.Index, 3, style, GridQueryBounds.Height).Height
            e.Handled = True

        End If
    End Sub


#Region "Events"


    Private Sub GetProductosEnAlmacen(be As detalleitems)
        ' Dim invSA As New TotalesAlmacenSA

        'Dim listaInventario = UCEstructuraCabeceraVenta.listaProductos.Where(invSA.GetDetalleLoteXproductoFullAlmacen(New totalesAlmacen With
        '                                                               {
        '                                                               .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                               .idItem = idProducto
        '                                                               })


        Dim listaInventario = be.totalesAlmacen
        ListLotes.Items.Clear()

        For Each i In listaInventario '.OrderByDescending(Function(o) o.CustomLote.fechaentrada).ToList
            Dim n As New ListViewItem(i.idAlmacen)
            n.SubItems.Add(i.NomAlmacen)
            n.SubItems.Add(i.CustomLote.codigoLote)
            n.SubItems.Add(i.CustomLote.nroLote)
            n.SubItems.Add(i.cantidad)
            n.SubItems.Add(i.CustomLote.fechaentrada)
            n.SubItems.Add(i.CustomLote.fechaVcto)
            n.SubItems.Add(i.CustomLote.productoSustentado)
            ListLotes.Items.Add(n)
        Next
        ListLotes.Refresh()

        '  Dim cantidadTotal = listaInventario.Sum(Function(o) o.cantidad)
        '   TextStockTotal.Text = CDec(cantidadTotal).ToString("N2")

        '  Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        '    TextProductoSel.Text = producto.descripcionItem
    End Sub


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

    Private Sub GridTotales_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs)
        Dim r As Record = GridCompra.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridCompra.Table.Records.Count > 0 Then
                Dim value As String = r.GetValue("idItem").ToString()
                Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

                If idEquiva.Trim.Length > 0 Then
                    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                    Dim idCat = r.GetValue("cboPrecios").ToString()
                    If idCat.Trim.Length > 0 Then
                        Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                        UCPreciosCanastaVenta.ListInventario.Items.Clear()

                        If OBJCatalog IsNot Nothing Then
                            Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                            UCPreciosCanastaVenta.GetDetallePrecios(lista)
                        End If
                    Else
                    End If


                    If UCEstructuraCabeceraVenta.ChVentaLote.Checked = True Then

                        If prod IsNot Nothing Then
                            GetProductosEnAlmacen(prod)
                        End If
                    End If
                End If





            End If


        End If
    End Sub

    Private Sub GridTotales_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs)
        Try
            Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
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
                                    UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then

                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)

                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
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

                                        UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                        If OBJCatalog IsNot Nothing Then
                                            Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                            UCPreciosCanastaVenta.GetDetallePrecios(lista)
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
                                    UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then
                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
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
        dt.Columns.Add("U.M.")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("contenido_neto")



        dt.Columns(0).ColumnMapping = MappingType.Hidden
        dt.Columns(1).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.contenido_neto)
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

    Private Sub GridTotales_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)

        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboEquivalencias" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
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
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim idEquiva = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cboEquivalencias").ToString()
            If idEquiva.Trim.Length > 0 Then

                Dim objEquivalencia As detalleitem_equivalencias
                If IsNumeric(idEquiva) Then
                    objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                Else
                    objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.unidadComercial = idEquiva).Single
                End If

                'Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                Dim listaPreciosVenta = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.estado = 1).ToList)
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



    Private Sub GridTotales_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs)
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

#Region "Prices configurations"

    Private Shared Function GetPrecioCreditoFijo(i As detalleitemequivalencia_precios) As Decimal
        Dim GetCalculoPrecioVenta As Decimal

        If i.precioCredito.GetValueOrDefault > 0 Then
            GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
        Else
            GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
        End If

        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPriceProductUniCategoryMIN(objProducto As detalleitems, category As item, PocentajeUtilidad As Decimal) As Decimal
        Dim GetCalculoPrecioVenta As Decimal
        Dim eqprec = objProducto.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
        Dim valorUnitarioItem = objProducto.precioCompra / eqprec.contenido_neto
        '  Dim firstPercent = objProducto.firstpercent
        'Dim precioCompra = category.precioCompra
        Dim result = valorUnitarioItem * (PocentajeUtilidad / 100)
        result = result + valorUnitarioItem
        GetCalculoPrecioVenta = result
        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPriceProductUnidMIN(objProducto As detalleitems, porcentaje As Decimal) As Decimal
        Dim GetCalculoPrecioVenta As Decimal
        Dim eqprec = objProducto.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
        Dim valorUnitarioItem = objProducto.precioCompra / eqprec.contenido_neto
        ' Dim firstPercent = objProducto.firstpercent
        Dim precioCompra = objProducto.precioCompra
        Dim result = valorUnitarioItem * (porcentaje / 100)
        result = result + valorUnitarioItem
        GetCalculoPrecioVenta = result
        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPriceCategoryMax(category As item, PocentajeUtilidad As Decimal, precioCompra As Decimal) As Decimal
        Dim GetCalculoPrecioVenta As Decimal
        'Dim firstPercent = objProducto.firstpercent
        ' Dim precioCompra = category.precioCompra
        Dim result = precioCompra * (PocentajeUtilidad / 100)
        result = result + precioCompra
        GetCalculoPrecioVenta = result
        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPrecioFijo1(i As detalleitemequivalencia_precios) As Decimal
        Dim GetCalculoPrecioVenta As Decimal

        If i.precio.GetValueOrDefault > 0 Then
            GetCalculoPrecioVenta = i.precio.GetValueOrDefault
        Else
            GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
        End If

        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPrecioUnidadComercialMax(objProducto As detalleitems, porcentaje As Decimal) As Decimal?
        ' Dim firstPercent = objProducto.firstpercent
        Dim precioCompra = objProducto.precioCompra
        Dim result = precioCompra * (porcentaje / 100)
        result = result + precioCompra
        Return result
    End Function
#End Region

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


                Dim index = 0
                Dim ultimaPosicion = listaDeRangos.Count - 1
                For Each i In listaDeRangos
                    Dim rango_inicio = i.rango_inicio
                    Dim rango_fin = i.rango_final
                    If cantidadVenta >= rango_inicio AndAlso rango_fin = 0 Then

                        If UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text = "PRE VENTA" Then
                            Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
                                Case "NUEVO SOL"
                                    'Corregido evaluar

                                    Dim HasCategory = False
                                    If objProducto.idItem > 0 Then
                                        HasCategory = True
                                    End If

                                    If listaDeRangos.Count = 1 Then

                                        If HasCategory Then
                                            'NIVEL DE CATEGORIA

                                            Dim category = objProducto.item
                                            Dim configuration = category.preciocompratipo
                                            Select Case configuration
                                                Case "NN"
                                                    Select Case objProducto.preciocompratipo
                                                        Case "FJ"
                                                            GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        Case Else
                                                            Dim PocentajeUtilidad As Decimal = objProducto.firstpercent ' objProducto.firstpercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                    End Select
                                                Case "PCT"
                                                    Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.firstpercent


                                                    If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                        GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                    Else
                                                        GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                    End If
                                                Case "FJ"

                                            End Select
                                        Else
                                            'NIVEL DE PRODUCTO
                                            Select Case objProducto.preciocompratipo
                                                Case "PCT"
                                                    Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                    If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                        Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                        GetCalculoPrecioVenta = result
                                                    Else
                                                        GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                    End If

                                                Case Else '"FJ"
                                                    GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                            End Select
                                        End If


                                        'mayor a una unidad comercial
                                    ElseIf listaDeRangos.Count > 1 Then

                                        If index = ultimaPosicion Then 'ultima fila

                                            If HasCategory Then
                                                'AFECTO A CATEGORIA
                                                Dim category = objProducto.item
                                                Dim configuration = category.preciocompratipo
                                                Select Case configuration
                                                    Case "NN"
                                                        Select Case objProducto.preciocompratipo
                                                            Case "FJ"
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                            Case Else

                                                                Dim PocentajeUtilidad As Decimal = objProducto.beforepercent

                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If

                                                        End Select

                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                        Else
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        End If
                                                    Case "FJ"

                                                End Select


                                            Else
                                                'AFECTO A PRODCUTOS
                                                Select Case objProducto.preciocompratipo
                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                        Else
                                                            ' Dim porcentaje As Decimal = objProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                        End If
                                                    Case Else
                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                End Select
                                            End If
                                        Else ' no es la ultima fila

                                            If HasCategory Then
                                                Dim category = objProducto.item
                                                Dim configuration = category.preciocompratipo
                                                Select Case configuration
                                                    Case "NN"
                                                        Select Case objProducto.preciocompratipo
                                                            Case "FJ"
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)

                                                            Case Else
                                                                Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                        End Select


                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            ' Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            '    Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                        Else
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            '   Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        End If
                                                    Case "FJ"

                                                End Select

                                            Else
                                                Select Case objProducto.preciocompratipo
                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            '    Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                        Else
                                                            '   Dim porcentaje As Decimal = objProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                        End If
                                                    Case Else
                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                End Select
                                            End If
                                        End If
                                    End If

                                Case Else
                                    'DOLARES

                                    If i.precioUSD.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                    End If
                            End Select
                        Else
                            Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
                                Case "NUEVO SOL"
                                    Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                                        Case "CONTADO"
                                            'If i.precio.GetValueOrDefault > 0 Then
                                            '    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                            'Else
                                            '    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                            'End If

                                            Dim HasCategory = False
                                            If objProducto.idItem > 0 Then
                                                HasCategory = True
                                            End If

                                            'categoria

                                            If listaDeRangos.Count = 1 Then
                                                If HasCategory Then
                                                    Dim category = objProducto.item
                                                    Dim configuration = category.preciocompratipo
                                                    Select Case configuration
                                                        Case "NN"
                                                            Select Case objProducto.preciocompratipo
                                                                Case "FJ"
                                                                    GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                                Case Else
                                                                    Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                            End Select
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                            ' GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case "FJ"

                                                    End Select
                                                Else
                                                    'NIVEL DE PRODUCTO
                                                    Select Case objProducto.preciocompratipo
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = objProducto.firstpercent

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                GetCalculoPrecioVenta = result
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If


                                                        Case Else '"FJ"
                                                            GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                    End Select
                                                End If

                                            ElseIf listaDeRangos.Count > 1 Then
                                                If index = ultimaPosicion Then 'ultima posicion ++

                                                    If HasCategory Then

                                                        Dim category = objProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                            ' Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                            ' Dim porcentaje As Decimal = objProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If

                                                                End Select

                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then

                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent '
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    '   Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select

                                                    Else
                                                        'AFECTO A PRODCUTOS
                                                        Select Case objProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim porcentaje As Decimal = objProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        End Select
                                                    End If

                                                Else ' no es la ultima posicion
                                                    If HasCategory Then
                                                        Dim category = objProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)

                                                                    Case Else
                                                                        Dim porcentaje As Decimal = objProducto.firstpercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                            '   Dim porcentaje As Decimal = objProducto.beforepercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            '  Dim porcentaje As Decimal = objProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                        End If
                                                                End Select


                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select
                                                    Else
                                                        Select Case objProducto.preciocompratipo

                                                            Case "PCT"
                                                                Dim porcentaje As Decimal = objProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    '  Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    ' Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        End Select
                                                    End If
                                                End If
                                            End If


                                        Case "CREDITO"

                                            Dim HasCategory = False
                                            If objProducto.idItem > 0 Then
                                                HasCategory = True
                                            End If

                                            If listaDeRangos.Count = 1 Then 'unidad principal
                                                If HasCategory Then
                                                    Dim category = objProducto.item
                                                    Dim configuration = category.preciocompratipo
                                                    Select Case configuration
                                                        Case "NN"
                                                            Select Case objProducto.preciocompratipo
                                                                Case "FJ"
                                                                    GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                                Case Else
                                                                    Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                            End Select
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.firstpercent
                                                            '   GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)


                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case "FJ"

                                                    End Select
                                                Else
                                                    'NIVEL DE PRODUCTO
                                                    Select Case objProducto.preciocompratipo
                                                        Case "PCT"
                                                            Dim porcentaje As Decimal = objProducto.firstpercent
                                                            '  Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                            '  GetCalculoPrecioVenta = result

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                GetCalculoPrecioVenta = result
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                            End If
                                                        Case Else '"FJ"
                                                            GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                    End Select
                                                End If

                                            ElseIf listaDeRangos.Count > 1 Then
                                                If index = ultimaPosicion Then 'ultima posicion
                                                    If HasCategory Then

                                                        Dim category = objProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                                    Case Else
                                                                        Dim porcentaje As Decimal = objProducto.beforepercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                            '  Dim porcentaje As Decimal = objProducto.firstpercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            ' Dim porcentaje As Decimal = objProducto.firstpercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                        End If

                                                                End Select

                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.beforepercent '
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select

                                                    Else
                                                        'AFECTO A PRODCUTOS
                                                        Select Case objProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim porcentaje As Decimal = objProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                        End Select
                                                    End If

                                                Else ' no es la ultima posicion
                                                    If HasCategory Then
                                                        Dim category = objProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)

                                                                    Case Else
                                                                        Dim porcentaje As Decimal = objProducto.firstpercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                            'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                        End If
                                                                End Select


                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select
                                                    Else
                                                        Select Case objProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim porcentaje As Decimal = objProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                        End Select
                                                    End If
                                                End If
                                            End If

                                    End Select
                                    '   End Select
                                Case Else
                                    'DOLARES
                                    Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                                        Case "CONTADO"
                                            If i.precioUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                            End If

                                        Case "CREDITO"
                                            If i.precioCreditoUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
                                            End If
                                    End Select

                            End Select
                        End If
                        Exit Function

                    End If
                    If cantidadVenta >= rango_inicio AndAlso cantidadVenta <= rango_fin Then
                        If UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text = "PRE VENTA" Then
                            Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
                                Case "NUEVO SOL"
                                    'If i.precio.GetValueOrDefault > 0 Then
                                    '    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                    'Else
                                    '    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                    'End If

                                    Dim HasCategory = False
                                    If objProducto.idItem > 0 Then
                                        HasCategory = True
                                    End If

                                    If listaDeRangos.Count = 1 Then
                                        If HasCategory Then
                                            Dim category = objProducto.item
                                            Dim configuration = category.preciocompratipo
                                            Select Case configuration
                                                Case "NN"
                                                    Select Case objProducto.preciocompratipo
                                                        Case "FJ"
                                                            GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        Case Else
                                                            Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                    End Select
                                                Case "PCT"
                                                    Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                    ' GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)


                                                    If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                        GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                    Else
                                                        GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                    End If
                                                Case "FJ"

                                            End Select
                                        Else
                                            'NIVEL DE PRODUCTO
                                            Select Case objProducto.preciocompratipo
                                                Case "PCT"
                                                    Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                    'Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                    'GetCalculoPrecioVenta = result

                                                    If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                        Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                        GetCalculoPrecioVenta = result
                                                    Else
                                                        GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                    End If
                                                Case Else '"FJ"
                                                    GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                            End Select
                                        End If

                                    ElseIf listaDeRangos.Count > 1 Then
                                        If index = ultimaPosicion Then 'ultima posicion

                                            If HasCategory Then

                                                Dim category = objProducto.item
                                                Dim configuration = category.preciocompratipo
                                                Select Case configuration
                                                    Case "NN"
                                                        Select Case objProducto.preciocompratipo
                                                            Case "FJ"
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                            Case Else
                                                                Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If

                                                        End Select

                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                        Else
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        End If
                                                    Case "FJ"

                                                End Select

                                            Else
                                                'AFECTO A PRODCUTOS
                                                Select Case objProducto.preciocompratipo
                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            ' Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                        Else
                                                            'Dim porcentaje As Decimal = objProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                        End If
                                                    Case Else
                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                End Select
                                            End If

                                        Else 'no es la ultima fila
                                            If HasCategory Then
                                                Dim category = objProducto.item
                                                Dim configuration = category.preciocompratipo
                                                Select Case configuration
                                                    Case "NN"
                                                        Select Case objProducto.preciocompratipo
                                                            Case "FJ"
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)

                                                            Case Else
                                                                Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                        End Select


                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            'Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                        Else
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        End If
                                                    Case "FJ"

                                                End Select
                                            Else
                                                Select Case objProducto.preciocompratipo
                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                        Else
                                                            'Dim porcentaje As Decimal = objProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                        End If
                                                    Case Else
                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                End Select
                                            End If
                                        End If
                                    End If


                                Case Else
                                    'DOLARES

                                    If i.precioUSD.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                    End If
                            End Select
                        Else
                            Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
                                Case "NUEVO SOL"
                                    Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                                        Case "CONTADO"
                                            'If i.precio.GetValueOrDefault > 0 Then
                                            '    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                            'Else
                                            '    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                            'End If
                                            Dim HasCategory = False
                                            If objProducto.idItem > 0 Then
                                                HasCategory = True
                                            End If

                                            If listaDeRangos.Count = 1 Then
                                                If HasCategory Then
                                                    Dim category = objProducto.item
                                                    Dim configuration = category.preciocompratipo
                                                    Select Case configuration
                                                        Case "NN"
                                                            Select Case objProducto.preciocompratipo
                                                                Case "FJ"
                                                                    GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                                Case Else
                                                                    Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                            End Select
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                            '   GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case "FJ"

                                                    End Select
                                                Else
                                                    'NIVEL DE PRODUCTO
                                                    Select Case objProducto.preciocompratipo
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            'Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            'GetCalculoPrecioVenta = result

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                GetCalculoPrecioVenta = result
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case Else '"FJ"
                                                            GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                    End Select
                                                End If

                                            ElseIf listaDeRangos.Count > 1 Then
                                                If index = ultimaPosicion Then 'ultima pisicion

                                                    If HasCategory Then

                                                        Dim category = objProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If

                                                                End Select

                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select

                                                    Else
                                                        'AFECTO A PRODCUTOS
                                                        Select Case objProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    '  Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    ' Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        End Select
                                                    End If

                                                Else ' no es la ultima fila
                                                    If HasCategory Then
                                                        Dim category = objProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)

                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If
                                                                End Select


                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select
                                                    Else
                                                        Select Case objProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        End Select
                                                    End If
                                                End If
                                            End If

                                          '  End Select


                                        Case "CREDITO"
                                            'If i.precioCredito.GetValueOrDefault > 0 Then
                                            '    GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                                            'Else
                                            '    GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
                                            'End If
                                            Dim HasCategory = False
                                            If objProducto.idItem > 0 Then
                                                HasCategory = True
                                            End If


                                            If listaDeRangos.Count = 1 Then
                                                If HasCategory Then
                                                    Dim category = objProducto.item
                                                    Dim configuration = category.preciocompratipo
                                                    Select Case configuration
                                                        Case "NN"
                                                            Select Case objProducto.preciocompratipo
                                                                Case "FJ"
                                                                    GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                                Case Else
                                                                    Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                            End Select
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.firstpercent
                                                            ' GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case "FJ"

                                                    End Select
                                                Else
                                                    'NIVEL DE PRODUCTO
                                                    Select Case objProducto.preciocompratipo
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                            'Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            'GetCalculoPrecioVenta = result

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                GetCalculoPrecioVenta = result
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case Else '"FJ"
                                                            GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                    End Select
                                                End If

                                            ElseIf listaDeRangos.Count > 1 Then
                                                If index = ultimaPosicion Then 'ultima posicion
                                                    If HasCategory Then

                                                        Dim category = objProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                            '     Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            '    Dim porcentaje As Decimal = objProducto.firstpercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If

                                                                End Select

                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    '  Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    ' Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select

                                                    Else
                                                        'AFECTO A PRODCUTOS
                                                        Select Case objProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                        End Select
                                                    End If

                                                Else ' no es la ultima fila
                                                    If HasCategory Then
                                                        Dim category = objProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)

                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If
                                                                End Select


                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    ' Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    ' Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select
                                                    Else
                                                        Select Case objProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                        End Select
                                                    End If
                                                End If
                                            End If

                                    End Select
                                Case Else
                                    'DOLARES -----------------

                                    Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                                        Case "CONTADO"
                                            If i.precioUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                            End If

                                            'Select Case objProducto.preciocompratipo
                                            '    Case "FJ"
                                            '        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                            '    Case Else

                                            '        If objProducto.detalleitem_equivalencias.Count = 1 Then
                                            '            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '            GetCalculoPrecioVenta = result

                                            '        ElseIf objProducto.detalleitem_equivalencias.Count > 1 Then
                                            '            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO"  Then
                                            '                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '                GetCalculoPrecioVenta = result
                                            '            Else
                                            '                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto)
                                            '            End If
                                            '        End If

                                            'End Select


                                        Case "CREDITO"
                                            If i.precioCreditoUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
                                            End If

                                            'Select Case objProducto.preciocompratipo
                                            '    Case "FJ"
                                            '        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                            '    Case Else

                                            '        If listaDeRangos.Count = 1 Then
                                            '            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '            GetCalculoPrecioVenta = result

                                            '        ElseIf listaDeRangos.Count > 1 Then
                                            '            If index = ultimaPosicion Then 'posi
                                            '                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO"  Then
                                            '                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '                    GetCalculoPrecioVenta = result
                                            '                Else
                                            '                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto)
                                            '                End If
                                            '            Else
                                            '                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO"  Then
                                            '                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '                    GetCalculoPrecioVenta = result
                                            '                Else
                                            '                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto)
                                            '                End If
                                            '            End If
                                            '        End If

                                            'End Select

                                    End Select
                            End Select
                        End If
                        'Select Case ComboTerminosPago.Text
                        '    Case "CONTADO"
                        '        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                        '    Case "CREDITO"
                        '        GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                        'End Select
                        Exit Function
                    End If
                Next
            Else
                Throw New Exception("Debe configurar los catálogos de precios!")
            End If
        End If
    End Function

    'Private Function GetCalculoPrecioVenta(cantidadVenta As Decimal, idProducto As Integer, idEquivalencia As Integer, idCatalogo As Integer) As Decimal
    '    GetCalculoPrecioVenta = 0
    '    Dim objProducto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

    '    If objProducto IsNot Nothing Then
    '        Dim listaEquivalencias = objProducto.detalleitem_equivalencias.ToList



    '        Dim objEQ = listaEquivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

    '        Dim catalogoOBJ = objEQ.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault

    '        If catalogoOBJ IsNot Nothing Then

    '            Dim ListaPrecios = catalogoOBJ.detalleitemequivalencia_precios.ToList
    '            Dim listaDeRangos = ConvertirPreciosArangos(ListaPrecios)

    '            If listaDeRangos.Count = 0 Or listaDeRangos Is Nothing Then
    '                Throw New Exception("El producto no tiene precios de venta asignados")
    '            End If

    '            For Each i In listaDeRangos
    '                Dim rango_inicio = i.rango_inicio
    '                Dim rango_fin = i.rango_final
    '                If cantidadVenta >= rango_inicio AndAlso rango_fin = 0 Then
    '                    'Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
    '                    '    Case "CONTADO"
    '                    '        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
    '                    '    Case "CREDITO"
    '                    '        GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
    '                    'End Select

    '                    If UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text = "PRE VENTA" Then

    '                        Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
    '                            Case "NUEVO SOL"
    '                                If i.precio.GetValueOrDefault > 0 Then
    '                                    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
    '                                Else
    '                                    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
    '                                End If

    '                            Case Else
    '                                'DOLARES

    '                                If i.precioUSD.GetValueOrDefault > 0 Then
    '                                    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
    '                                Else
    '                                    GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
    '                                End If

    '                        End Select


    '                    Else

    '                        Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
    '                            Case "NUEVO SOL"
    '                                Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
    '                                    Case "CONTADO"
    '                                        If i.precio.GetValueOrDefault > 0 Then
    '                                            GetCalculoPrecioVenta = i.precio.GetValueOrDefault
    '                                        Else
    '                                            GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
    '                                        End If

    '                                    Case "CREDITO"
    '                                        If i.precioCredito.GetValueOrDefault > 0 Then
    '                                            GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
    '                                        Else
    '                                            GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
    '                                        End If
    '                                End Select
    '                            Case Else
    '                                'DOLARES
    '                                Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
    '                                    Case "CONTADO"
    '                                        If i.precioUSD.GetValueOrDefault > 0 Then
    '                                            GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
    '                                        Else
    '                                            GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
    '                                        End If

    '                                    Case "CREDITO"
    '                                        If i.precioCreditoUSD.GetValueOrDefault > 0 Then
    '                                            GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
    '                                        Else
    '                                            GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
    '                                        End If
    '                                End Select
    '                        End Select

    '                    End If

    '                    Exit Function
    '                End If
    '                If cantidadVenta >= rango_inicio AndAlso cantidadVenta <= rango_fin Then
    '                    If UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text = "PRE VENTA" Then

    '                        Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
    '                            Case "NUEVO SOL"
    '                                If i.precio.GetValueOrDefault > 0 Then
    '                                    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
    '                                Else
    '                                    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
    '                                End If
    '                            Case Else
    '                                'DOLARES

    '                                If i.precioUSD.GetValueOrDefault > 0 Then
    '                                    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
    '                                Else
    '                                    GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
    '                                End If
    '                        End Select


    '                    Else

    '                        Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
    '                            Case "NUEVO SOL"
    '                                Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
    '                                    Case "CONTADO"
    '                                        If i.precio.GetValueOrDefault > 0 Then
    '                                            GetCalculoPrecioVenta = i.precio.GetValueOrDefault
    '                                        Else
    '                                            GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
    '                                        End If

    '                                    Case "CREDITO"
    '                                        If i.precioCredito.GetValueOrDefault > 0 Then
    '                                            GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
    '                                        Else
    '                                            GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
    '                                        End If

    '                                End Select
    '                            Case Else
    '                                'DOLARES -----------------

    '                                Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
    '                                    Case "CONTADO"
    '                                        If i.precioUSD.GetValueOrDefault > 0 Then
    '                                            GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
    '                                        Else
    '                                            GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
    '                                        End If

    '                                    Case "CREDITO"
    '                                        If i.precioCreditoUSD.GetValueOrDefault > 0 Then
    '                                            GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
    '                                        Else
    '                                            GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
    '                                        End If

    '                                End Select
    '                        End Select


    '                    End If
    '                    Exit Function
    '                End If
    '            Next
    '        Else
    '            Throw New Exception("Debe configurar los catálogos de precios!")
    '        End If
    '    End If
    'End Function


    Private Sub GridTotales_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 9 Then

                Dim equivalencia = GridCompra.TableModel(e.Inner.RowIndex, 6).CellValue
                Dim CatalogoPrecio = GridCompra.TableModel(e.Inner.RowIndex, 7).CellValue

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


                Dim idProducto = GridCompra.TableModel(e.Inner.RowIndex, 2).CellValue

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
                Dim idProducto = GridCompra.TableModel(e.Inner.RowIndex, 2).CellValue
                '  GetProductosEnAlmacen(idProducto)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar")
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridTotales_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs)

        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
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
                    Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                    Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

                    Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

                    Dim Unidades = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault


                    If Unidades.detalleitemequivalencia_catalogos IsNot Nothing Then
                        If Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                            Dim cataPredeterminado = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True AndAlso c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault

                            If cataPredeterminado IsNot Nothing Then
                                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cataPredeterminado.idCatalogo)

                            ElseIf Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", Unidades.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                            End If
                        Else
                            MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
                    Dim cat As detalleitemequivalencia_catalogos = Nothing

                    If IsNumeric(idCatalogo) Then
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
                    ElseIf idCatalogo.ToString.Trim.Length > 0 Then
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                    Else
                        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    'If idCatalogo.ToString.Trim.Length > 0 Then
                    '    'cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                    '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                    'Else
                    '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Me.Cursor = Cursors.Default
                    '    Exit Sub
                    'End If

                    If cat IsNot Nothing Then
                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                    Else

                    End If


                    '    'Agregando Producto
                    '    '-----------------------------------------------------------------------------------------
                    '    '*******************************************************************************************

                    '    Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                    '    Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                    '    '   If inp IsNot Nothing Then
                    '    If IsNumeric(inp) Then
                    '        If (inp) > 0 Then

                    '            Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), producto.codigodetalle, Unidades.equivalencia_id, cat.idCatalogo)
                    '            precioVenta = precioventaFormula

                    '            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, producto.codigodetalle, precioventaFormula, Unidades, cat.idCatalogo)
                    '            UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
                    '            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                    '            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
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

                    'r.SetValue("cboPrecios", String.Empty)
                    'r.SetValue("cboEquivalencias", String.Empty)
                    'r.SetValue("importeMn", 0)
                    'End If



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

                    '  Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                    '  Me.GridTotales.TableControl.CurrentCell.ShowDropDown()

                End If
            ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
                If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                    cc.EndEdit()
                    Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                    Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

                    Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

                    Dim Unidades = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault


                    'If Unidades.detalleitemequivalencia_catalogos IsNot Nothing Then
                    '    If Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                    '        Dim cataPredeterminado = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True AndAlso c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault

                    '        If cataPredeterminado IsNot Nothing Then
                    '            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cataPredeterminado.idCatalogo)

                    '        ElseIf Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                    '            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", Unidades.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                    '        End If
                    '    Else
                    '        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '        Me.Cursor = Cursors.Default
                    '        Exit Sub
                    '    End If
                    'Else
                    '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Me.Cursor = Cursors.Default
                    '    Exit Sub
                    'End If

                    Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
                    Dim cat As detalleitemequivalencia_catalogos = Nothing

                    If IsNumeric(idCatalogo) Then
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
                    ElseIf idCatalogo.ToString.Trim.Length > 0 Then
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                    Else
                        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    'If idCatalogo.ToString.Trim.Length > 0 Then
                    '    'cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                    '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                    'Else
                    '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Me.Cursor = Cursors.Default
                    '    Exit Sub
                    'End If

                    If cat IsNot Nothing Then
                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                    Else

                    End If
                End If


                'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
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

    Private Sub GridTotales_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs)
        Try
            If e.Inner.KeyCode = Keys.Enter Then
                Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
                Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
                cc.ConfirmChanges()

                'cc.TableControl.CurrentCell.EndEdit()
                'cc.TableControl.Table.TableDirty = True
                'dgvCompra.TableControl.Table.EndEdit()
                'If cc.Renderer IsNot Nothing Then

                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                    If style.TableCellIdentity.Column.Name = "cboEquivalencias" Then
                        cc.EndEdit()
                        e.TableControl.Table.EndEdit()
                        'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                        'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()

                        Dim equivalencia = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias") ' GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                        Dim CatalogoPrecio As Integer = 0 ' style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios") ' GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                        Dim codiProducto As Integer = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")

                        Dim codiAlmacen = style.TableCellIdentity.Table.CurrentRecord.GetValue("idAlmacen")


                        ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                        Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).SingleOrDefault ' GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

                        If eqLista.productoRestringido = True Then
                            If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If

                        Dim listaEquivalencias = eqLista.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList
                        Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                        If objEQ Is Nothing Then
                            MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                            If objEQ.detalleitemequivalencia_catalogos.Count > 0 Then
                                Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault

                                If catalogPredeterminado IsNot Nothing Then
                                    style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                                    CatalogoPrecio = catalogPredeterminado.idCatalogo
                                Else
                                    style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                    CatalogoPrecio = objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo
                                End If

                                Me.GridCompra.Table.CurrentRecord.SetCurrent("descripcion")
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
                        Dim precioVenta As Decimal = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                        Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                        '   If inp IsNot Nothing Then
                        If IsNumeric(inp) Then
                            If (inp) > 0 Then

                                Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), codiProducto, equivalencia, CatalogoPrecio)
                                precioVenta = precioventaFormula




                                If codiAlmacen IsNot Nothing Then


                                    UCEstructuraCabeceraVenta.AgregarProductoDetalleVentaAlmacen(inp, codiProducto, precioventaFormula, objEQ, CatalogoPrecio, codiAlmacen)
                                Else
                                    UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, codiProducto, precioventaFormula, objEQ, CatalogoPrecio)
                                End If




                                UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)

                                Me.GridCompra.Table.CurrentRecord.SetCurrent("descripcion")
                                'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                                'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
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


                        'End If
                    ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
                        If Me.GridCompra.Table.CurrentRecord IsNot Nothing Then
                            Dim equivalencia = GridCompra.Table.CurrentRecord.GetValue("cboEquivalencias")
                            Dim CatalogoPrecio = GridCompra.Table.CurrentRecord.GetValue("cboPrecios")

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


                            Dim idProducto = GridCompra.Table.CurrentRecord.GetValue("idItem")
                            Dim codiAlmacen = style.TableCellIdentity.Table.CurrentRecord.GetValue("idAlmacen")
                            Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                            Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                            '   If inp IsNot Nothing Then
                            If IsNumeric(inp) Then
                                If (inp) > 0 Then

                                    Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                                    precioVenta = precioventaFormula

                                    Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                                    Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                                    Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault



                                    If codiAlmacen IsNot Nothing Then


                                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVentaAlmacen(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio, codiAlmacen)
                                    Else
                                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio)
                                    End If

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
                            'Else
                            '    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Me.Cursor = Cursors.Default
                            'End If
                        End If
                        Me.GridCompra.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                        Me.GridCompra.TableControl.CurrentCell.ShowDropDown()
                    Else 'If style.TableCellIdentity.Column.Name = "totalmn" Then
                        Me.GridCompra.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                        Me.GridCompra.TableControl.CurrentCell.ShowDropDown()
                    End If
                End If
                'End If

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

    Private Sub GridTotales_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs)

    End Sub

    Private Sub GridTotales_TableControlCurrentCellShowingDropDown(sender As Object, e As GridTableControlCurrentCellShowingDropDownEventArgs)
        If e.Inner.Size.Height = 117 Then
            e.Inner.Size = New Size(e.Inner.Size.Width, 180)
        Else
            e.Inner.Size = New Size(e.Inner.Size.Width, e.Inner.Size.Height)
        End If
        'e.Inner.Size = New Size(e.Inner.Size.Width, e.Inner.Size.Height + 20)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
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

    Private Sub GridTotales_TableControlCurrentCellShowedDropDown(sender As Object, e As GridTableControlEventArgs)

    End Sub

    Private Sub GridTotales_QueryCellFormattedText(sender As Object, e As GridCellTextEventArgs)

    End Sub

    Private Sub UserControlCanasta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Hide()
        End If
    End Sub

    Private Sub btnOK_Click_1(sender As Object, e As EventArgs) Handles btnOK.Click
        RaiseEvent OKEvent()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click


        'sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        'sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        'Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        ''PanelBody.Controls.Clear()

        ''If Not UCNuenExistencia.cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
        ''    Exit Sub
        ''End If

        'Select Case btn.Text
        '    Case "LOTES"
        '        If UCListaLotes IsNot Nothing Then
        '            UCListaLotes.Visible = False
        '        End If

        '        PanellOTES.Visible = False
        '        If UCListaLotes IsNot Nothing Then
        '            UCListaLotes.Visible = True
        '            UCListaLotes.BringToFront()
        '            UCListaLotes.Show()
        '            'btOperacion.ButtonText = "Grabar"
        '        End If
        '    Case "PRECIOS"

        '        If UCListaPrecios IsNot Nothing Then
        '            UCListaPrecios.Visible = False
        '        End If

        '        UCListaLotes.Visible = False

        '        If UCListaPrecios IsNot Nothing Then
        '            UCListaPrecios.Visible = True
        '            UCListaPrecios.BringToFront()
        '            UCListaPrecios.Show()
        '            'btOperacion.ButtonText = "Grabar"
        '        End If



        'End Select
    End Sub

    Private Sub PanelBody_Paint(sender As Object, e As PaintEventArgs) Handles PanelBody.Paint

    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click




        'sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        'sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        'Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        ''PanelBody.Controls.Clear()

        ''If Not UCNuenExistencia.cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
        ''    Exit Sub
        ''End If

        'Select Case btn.Text
        '    Case "LOTES"
        '        If UCListaLotes IsNot Nothing Then
        '            UCListaLotes.Visible = False
        '        End If

        '        PanellOTES.Visible = False

        '        If UCListaLotes IsNot Nothing Then
        '            UCListaLotes.Visible = True
        '            UCListaLotes.BringToFront()
        '            UCListaLotes.Show()
        '            'btOperacion.ButtonText = "Grabar"
        '        End If
        '    Case "PRECIOS"
        '        UCListaLotes.Visible = False
        '        UCListaPrecios.Visible = False

        '        PanellOTES.Visible = True
        '        PanellOTES.BringToFront()
        '        PanellOTES.Show()




        'End Select
    End Sub

    Private Sub ListInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListInventario.SelectedIndexChanged

    End Sub

    Private Sub ListLotes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListLotes.SelectedIndexChanged

    End Sub

    Private Sub ListLotes_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListLotes.MouseDoubleClick
        If ListLotes.SelectedItems.Count = 0 Then Exit Sub
        If UCEstructuraCabeceraVenta.ChVentaLote.Checked Then
            Try

                'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
                'Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
                'cc.ConfirmChanges()

                Dim r As Record = GridCompra.Table.CurrentRecord
                Dim equivalencia = r.GetValue("cboEquivalencias") ' GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                Dim CatalogoPrecio As Integer = 0 ' style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios") ' GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                Dim codiProducto As Integer = r.GetValue("idItem")
                Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).SingleOrDefault ' GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

                If eqLista.productoRestringido = True Then
                    If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                If eqLista.recursoCostoLote.Count <= 0 Then
                    MessageBox.Show("No tiene lotes disponibles", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                Dim lote = eqLista.recursoCostoLote.Where(Function(o) o.codigoLote = ListLotes.SelectedItems(0).SubItems(2).Text).SingleOrDefault


                Dim listaEquivalencias = eqLista.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList
                Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                If objEQ Is Nothing Then
                    MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                    If objEQ.detalleitemequivalencia_catalogos.Count > 0 Then
                        Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault

                        If catalogPredeterminado IsNot Nothing Then
                            r.SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                            CatalogoPrecio = catalogPredeterminado.idCatalogo
                        Else
                            r.SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                            CatalogoPrecio = objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo
                        End If

                        r.SetCurrent("descripcion")
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
                Dim precioVenta As Decimal = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                '   If inp IsNot Nothing Then
                If IsNumeric(inp) Then
                    If (inp) > 0 Then

                        'Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), codiProducto, equivalencia, CatalogoPrecio)
                        'precioVenta = precioventaFormula

                        'If UCEstructuraCabeceraVenta.ChVentaLote.Checked Then

                        '    UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, codiProducto, objEQ, eqLista.recursoCostoLote)
                        'Else
                        Dim stock As Decimal = 0
                        If UCEstructuraCabeceraVenta.ChVentaLote.Checked Then
                            stock = Decimal.Parse(ListLotes.SelectedItems(0).SubItems(4).Text)
                        Else
                            stock = Decimal.Parse(GridCompra.Table.CurrentRecord.GetValue("cantidad"))
                        End If
                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVentaLote(CatalogoPrecio, inp, codiProducto, objEQ, stock, lote)
                        'End If


                        UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)

                        r.SetCurrent("descripcion")
                        'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                        'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
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
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar!")
            End Try
        End If
    End Sub

    Private Sub GridCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridCompra.QueryCellStyleInfo
        'GridCompra.TableDescriptor.Columns("descripcion").Width = 334

        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboEquivalencias" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
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
            Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim idEquiva = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cboEquivalencias").ToString()
            If idEquiva.Trim.Length > 0 Then

                Dim objEquivalencia As detalleitem_equivalencias
                If IsNumeric(idEquiva) Then
                    objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                Else
                    objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.unidadComercial = idEquiva).Single
                End If

                'Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                Dim listaPreciosVenta = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.estado = 1).ToList)
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




    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

        'GridCompra.TableDescriptor.Columns("descripcion").Width = 334
        Dim r As Record = GridCompra.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridCompra.Table.Records.Count > 0 Then
                Dim value As String = r.GetValue("idItem").ToString()
                Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

                If idEquiva.Trim.Length > 0 Then
                    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                    Dim idCat = r.GetValue("cboPrecios").ToString()
                    If idCat.Trim.Length > 0 Then
                        Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                        UCPreciosCanastaVenta.ListInventario.Items.Clear()

                        If OBJCatalog IsNot Nothing Then
                            Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                            UCPreciosCanastaVenta.GetDetallePrecios(lista)
                        End If
                    Else
                    End If


                    If UCEstructuraCabeceraVenta.ChVentaLote.Checked = True Then

                        If prod IsNot Nothing Then
                            GetProductosEnAlmacen(prod)
                        End If
                    End If
                End If





            End If


        End If

        '  GridCompra.TableDescriptor.Columns("descripcion").Width = 330
    End Sub

    Private Sub GridCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridCompra.TableControlCurrentCellCloseDropDown
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
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
                    Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                    Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

                    Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

                    Dim Unidades = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault


                    If Unidades.detalleitemequivalencia_catalogos IsNot Nothing Then
                        If Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                            Dim cataPredeterminado = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True AndAlso c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault

                            If cataPredeterminado IsNot Nothing Then
                                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cataPredeterminado.idCatalogo)

                            ElseIf Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", Unidades.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                            End If
                        Else
                            MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
                    Dim cat As detalleitemequivalencia_catalogos = Nothing

                    If IsNumeric(idCatalogo) Then
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
                    ElseIf idCatalogo.ToString.Trim.Length > 0 Then
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                    Else
                        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    'If idCatalogo.ToString.Trim.Length > 0 Then
                    '    'cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                    '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                    'Else
                    '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Me.Cursor = Cursors.Default
                    '    Exit Sub
                    'End If

                    If cat IsNot Nothing Then
                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                    Else

                    End If


                    '    'Agregando Producto
                    '    '-----------------------------------------------------------------------------------------
                    '    '*******************************************************************************************

                    '    Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                    '    Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                    '    '   If inp IsNot Nothing Then
                    '    If IsNumeric(inp) Then
                    '        If (inp) > 0 Then

                    '            Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), producto.codigodetalle, Unidades.equivalencia_id, cat.idCatalogo)
                    '            precioVenta = precioventaFormula

                    '            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, producto.codigodetalle, precioventaFormula, Unidades, cat.idCatalogo)
                    '            UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
                    '            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                    '            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
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

                    'r.SetValue("cboPrecios", String.Empty)
                    'r.SetValue("cboEquivalencias", String.Empty)
                    'r.SetValue("importeMn", 0)
                    'End If



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

                    '  Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                    '  Me.GridTotales.TableControl.CurrentCell.ShowDropDown()

                End If
            ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
                If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                    cc.EndEdit()
                    Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
                    Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

                    Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

                    Dim Unidades = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault


                    'If Unidades.detalleitemequivalencia_catalogos IsNot Nothing Then
                    '    If Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                    '        Dim cataPredeterminado = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True AndAlso c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault

                    '        If cataPredeterminado IsNot Nothing Then
                    '            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cataPredeterminado.idCatalogo)

                    '        ElseIf Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
                    '            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", Unidades.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                    '        End If
                    '    Else
                    '        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '        Me.Cursor = Cursors.Default
                    '        Exit Sub
                    '    End If
                    'Else
                    '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Me.Cursor = Cursors.Default
                    '    Exit Sub
                    'End If

                    Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
                    Dim cat As detalleitemequivalencia_catalogos = Nothing

                    If IsNumeric(idCatalogo) Then
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
                    ElseIf idCatalogo.ToString.Trim.Length > 0 Then
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                    Else
                        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    'If idCatalogo.ToString.Trim.Length > 0 Then
                    '    'cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                    '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
                    'Else
                    '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Me.Cursor = Cursors.Default
                    '    Exit Sub
                    'End If

                    If cat IsNot Nothing Then
                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
                        cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

                        Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                    Else

                    End If
                End If


                'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
            ElseIf style.TableCellIdentity.Column.Name = "importeMn" Then

            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlCurrentCellShowingDropDown(sender As Object, e As GridTableControlCurrentCellShowingDropDownEventArgs) Handles GridCompra.TableControlCurrentCellShowingDropDown
        If e.Inner.Size.Height = 117 Then
            e.Inner.Size = New Size(e.Inner.Size.Width, 180)
        Else
            e.Inner.Size = New Size(e.Inner.Size.Width, e.Inner.Size.Height)
        End If
        'e.Inner.Size = New Size(e.Inner.Size.Width, e.Inner.Size.Height + 20)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
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

    Private Sub GridCompra_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridCompra.TableControlDrawCell
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



    Private Sub GridCompra_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridCompra.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 9 Then

                Dim equivalencia = GridCompra.TableModel(e.Inner.RowIndex, 6).CellValue
                Dim CatalogoPrecio = GridCompra.TableModel(e.Inner.RowIndex, 7).CellValue

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


                Dim idProducto = GridCompra.TableModel(e.Inner.RowIndex, 2).CellValue

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
                Dim idProducto = GridCompra.TableModel(e.Inner.RowIndex, 2).CellValue
                '  GetProductosEnAlmacen(idProducto)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar")
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridCompra.TableControlCurrentCellKeyDown
        Try
            If e.Inner.KeyCode = Keys.Enter Then
                Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
                Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
                cc.ConfirmChanges()

                'cc.TableControl.CurrentCell.EndEdit()
                'cc.TableControl.Table.TableDirty = True
                'dgvCompra.TableControl.Table.EndEdit()
                'If cc.Renderer IsNot Nothing Then

                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                    If style.TableCellIdentity.Column.Name = "cboEquivalencias" Then
                        cc.EndEdit()
                        e.TableControl.Table.EndEdit()
                        'Me.GridTotales.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                        'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()

                        Dim equivalencia = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias") ' GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
                        Dim CatalogoPrecio As Integer = 0 ' style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios") ' GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

                        Dim codiProducto As Integer = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")

                        Dim codiAlmacen = style.TableCellIdentity.Table.CurrentRecord.GetValue("idAlmacen")


                        ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                        Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).SingleOrDefault ' GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

                        If eqLista.productoRestringido = True Then
                            If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If

                        Dim listaEquivalencias = eqLista.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList
                        Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                        If objEQ Is Nothing Then
                            MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                            If objEQ.detalleitemequivalencia_catalogos.Count > 0 Then
                                Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault

                                If catalogPredeterminado IsNot Nothing Then
                                    style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                                    CatalogoPrecio = catalogPredeterminado.idCatalogo
                                Else
                                    style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                    CatalogoPrecio = objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo
                                End If

                                Me.GridCompra.Table.CurrentRecord.SetCurrent("descripcion")
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
                        Dim precioVenta As Decimal = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                        Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                        '   If inp IsNot Nothing Then
                        If IsNumeric(inp) Then
                            If (inp) > 0 Then

                                Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), codiProducto, equivalencia, CatalogoPrecio)
                                precioVenta = precioventaFormula




                                If codiAlmacen IsNot Nothing Then


                                    UCEstructuraCabeceraVenta.AgregarProductoDetalleVentaAlmacen(inp, codiProducto, precioventaFormula, objEQ, CatalogoPrecio, codiAlmacen)
                                Else
                                    UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, codiProducto, precioventaFormula, objEQ, CatalogoPrecio)
                                End If




                                UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)

                                Me.GridCompra.Table.CurrentRecord.SetCurrent("descripcion")
                                'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                                'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
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


                        'End If
                    ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
                        If Me.GridCompra.Table.CurrentRecord IsNot Nothing Then
                            Dim equivalencia = GridCompra.Table.CurrentRecord.GetValue("cboEquivalencias")
                            Dim CatalogoPrecio = GridCompra.Table.CurrentRecord.GetValue("cboPrecios")

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


                            Dim idProducto = GridCompra.Table.CurrentRecord.GetValue("idItem")
                            Dim codiAlmacen = style.TableCellIdentity.Table.CurrentRecord.GetValue("idAlmacen")
                            Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                            Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                            '   If inp IsNot Nothing Then
                            If IsNumeric(inp) Then
                                If (inp) > 0 Then

                                    Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                                    precioVenta = precioventaFormula

                                    Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                                    Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                                    Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault



                                    If codiAlmacen IsNot Nothing Then


                                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVentaAlmacen(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio, codiAlmacen)
                                    Else
                                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio)
                                    End If

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
                            'Else
                            '    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Me.Cursor = Cursors.Default
                            'End If
                        End If
                        Me.GridCompra.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                        Me.GridCompra.TableControl.CurrentCell.ShowDropDown()
                    Else 'If style.TableCellIdentity.Column.Name = "totalmn" Then
                        Me.GridCompra.Table.CurrentRecord.SetCurrent("cboEquivalencias")
                        Me.GridCompra.TableControl.CurrentCell.ShowDropDown()
                    End If
                End If
                'End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar!")
        End Try
    End Sub

    Private Sub GridCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridCompra.TableControlKeyDown
        Try
            Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
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
                                    UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then

                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)

                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
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

                                        UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                        If OBJCatalog IsNot Nothing Then
                                            Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                            UCPreciosCanastaVenta.GetDetallePrecios(lista)
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
                                    UCPreciosCanastaVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then
                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
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

    'Private Sub CheckStock_OnChange(sender As Object, e As EventArgs) Handles CheckStock.OnChange
    '    If UCEstructuraCabeceraVenta.CheckStock.Checked = True Then
    '        GridTotales.TableDescriptor.Columns("cantidad").Width = 70
    '    ElseIf CheckStock.Checked = False Then
    '        GridTotales.TableDescriptor.Columns("cantidad").Width = 0
    '    End If
    'End Sub
#End Region
End Class
