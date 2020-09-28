Imports Helios.Cont.Business.Entity
Imports System.Data.Entity
Imports System.Linq
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Presentation.WinForm

Public Class FormCrearCompraPrecios

    Public _product As detalleitems

    Public Sub New(IDProducto As Integer, precioCompra As Decimal)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetProduct(IDProducto)
        FormatoGrid(GridPrecioVigente, True)
        FormatoGrid(GridEquivalencia, True)
        FormatoGrid2(GridPrecios)
        TextPrecioCompraNuevo.Value = precioCompra
    End Sub

    Private Sub FormatoGrid2(grid As GridGroupingControl)
        grid.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        '   grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        '  grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        '  grid.TableOptions.ListBoxSelectionMode = SelectionMode.None
        ' grid.TableOptions.SelectionBackColor = ColorTranslator.FromHtml("#FF97F4BB")
        grid.TableOptions.SelectionTextColor = Color.WhiteSmoke
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center


        'grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'grid.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'grid.TableOptions.SelectionBackColor = Color.Gray
    End Sub

    Private Sub FormatoGrid(grid As GridGroupingControl, fullRow As Boolean)
        grid.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        If fullRow Then
            grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        End If
        grid.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    End Sub


    Private Sub GetProduct(iDProducto As Integer)
        Dim productoSA As New WCFService.ServiceAccess.detalleitemsSA

        _product = productoSA.GetUbicaProductoID(iDProducto)
        If _product.preciocompratipo = "PCT" Then
            TogglePrecio.ToggleState = ToggleButton2.ToggleButtonState.OFF
        Else
            TogglePrecio.ToggleState = ToggleButton2.ToggleButtonState.ON
        End If
        TextFirstDescuento.Value = _product.firstpercent.GetValueOrDefault
        TextBeforeDescuento.Value = _product.beforepercent.GetValueOrDefault
        TexUltimaCompra.Value = _product.precioCompra.GetValueOrDefault

        GetEquivalencias()
        GetPrecioLotesVigente()
    End Sub

    Private Sub GetPrecioLotesVigente()
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim dt As New DataTable
        dt.Columns.Add("lote")
        dt.Columns.Add("fecha")
        dt.Columns.Add("precioIgv")
        dt.Columns.Add("precioSinIgv")
        dt.Columns.Add("stock")
        dt.Columns.Add("unidadcomercial")
        dt.Columns.Add("proveedor")

        Dim lotes = ventaSA.ConsultaLotesDisponiblesAdmin(New documentoventaAbarrotesDet With {.idItem = _product.codigodetalle})
        Dim coniva As Decimal = 0
        Dim siniva As Decimal = 0
        Dim conIvaMaximo As Decimal = 0
        Dim conIvaMinimo As Decimal = 0

        Dim sumaStock As Decimal = 0
        For Each i In lotes.OrderByDescending(Function(o) o.fechaProduccion).ToList
            sumaStock += CDec(i.stock)
            Select Case _product.origenProducto
                Case "1"
                    If i.CustomCompraDetail.importe.GetValueOrDefault > 0 AndAlso i.CustomCompraDetail.monto1.GetValueOrDefault > 0 Then
                        coniva = Math.Round(i.CustomCompraDetail.importe.GetValueOrDefault / i.CustomCompraDetail.monto1.GetValueOrDefault, 2)
                    Else
                        coniva = 0
                    End If

                    If i.CustomCompraDetail.montokardex.GetValueOrDefault > 0 AndAlso i.CustomCompraDetail.monto1.GetValueOrDefault > 0 Then
                        siniva = Math.Round(i.CustomCompraDetail.montokardex.GetValueOrDefault / i.CustomCompraDetail.monto1.GetValueOrDefault, 2)
                    Else
                        siniva = 0
                    End If
                    'coniva = Math.Round(i.CustomCompraDetail.importe.GetValueOrDefault / i.CustomCompraDetail.monto1.GetValueOrDefault, 2) 'i.precioUnitarioIva.GetValueOrDefault * 0.18
                    'coniva = coniva + i.precioUnitarioIva.GetValueOrDefault

                    dt.Rows.Add(
                        i.codigoLote,
                        i.fechaProduccion.GetValueOrDefault,
                        coniva.ToString("N2"),
                        siniva,
                        i.stock.GetValueOrDefault,
                        i.UnidadComercial,
                        i.Proveedor)
                Case "2"
                    If i.CustomCompraDetail.montokardex.GetValueOrDefault > 0 AndAlso i.CustomCompraDetail.monto1.GetValueOrDefault > 0 Then
                        siniva = Math.Round(i.CustomCompraDetail.montokardex.GetValueOrDefault / i.CustomCompraDetail.monto1.GetValueOrDefault, 2)
                    Else
                        siniva = 0
                    End If
                    coniva = 0

                    dt.Rows.Add(
                        i.codigoLote,
                        i.fechaProduccion.GetValueOrDefault,
                        coniva.ToString("N2"),
                        siniva,
                        i.stock.GetValueOrDefault,
                        i.UnidadComercial,
                        i.Proveedor)
            End Select
        Next

        If lotes.Count > 0 Then
            dt.Rows.Add(
                        "TOTAL",
                        "",
                        "",
                        "",
                        sumaStock,
                        "",
                        "")
        End If

        GridPrecioVigente.DataSource = dt

    End Sub

    Private Sub GetEquivalencias()
        Dim dt As New DataTable
        dt.Columns.Add("IDEQ")
        dt.Columns.Add("detalle")
        dt.Columns.Add("unidadcomercial")
        dt.Columns.Add("contenido")
        dt.Columns.Add("fraccion")
        dt.Columns.Add("estado", GetType(Boolean))
        dt.Columns.Add("contenidoneto")
        For Each i In _product.detalleitem_equivalencias.ToList()
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.contenido, i.fraccionUnidad, i.estado_bool, i.contenido_neto.GetValueOrDefault)
        Next
        GridEquivalencia.DataSource = dt
        If _product.detalleitem_equivalencias.Count > 0 Then
            GetPreciosSelEquivalencia(_product.detalleitem_equivalencias.FirstOrDefault.equivalencia_id)
        End If
        Me.CaptionLabels(0).Text = _product.descripcionItem
    End Sub

    Private Sub GetPreciosSelEquivalencia(equivalencia_id As Integer)
        Dim equivalencia = _product.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = equivalencia_id).SingleOrDefault
        Dim ListaCatalogoPrecios = equivalencia.detalleitemequivalencia_catalogos.ToList
        ComboCatalogoPrecios.DataSource = ListaCatalogoPrecios
        ComboCatalogoPrecios.DisplayMember = "nombre_corto"
        ComboCatalogoPrecios.ValueMember = "idCatalogo"

        If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
            If GridEquivalencia.Table.Records.Count > 0 Then
                GridPrecios.Table.Records.DeleteAll()
                Dim idCatalogo = Integer.Parse(ComboCatalogoPrecios.SelectedValue)
                PreciosSelCatalogo(equivalencia.equivalencia_id, idCatalogo)
            End If
        End If
    End Sub

    Private Sub PreciosSelCatalogo(idEquivalencia As Integer, idCatalogo As Integer)
        Dim equivalencias = _product.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault
        Dim catalogoPrec = equivalencias.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault

        If equivalencias IsNot Nothing Then
            If catalogoPrec IsNot Nothing Then
                Dim ListPrices = catalogoPrec.detalleitemequivalencia_precios.ToList

                Dim dt As New DataTable
                dt.Columns.Add("id")
                dt.Columns.Add("rangoinicio")
                dt.Columns.Add("rangofin")
                dt.Columns.Add("tipoprecio")
                dt.Columns.Add("PrecioContado")
                dt.Columns.Add("PrecioContadoUSD")
                dt.Columns.Add("PrecioCredito")
                dt.Columns.Add("PrecioCreditoUSD")
                dt.Columns.Add("btEliminar")

                Select Case _product.preciocompratipo
                    Case "PCT"
                        Dim firstPercent = _product.firstpercent
                        Dim beforePercent = _product.beforepercent
                        Dim precioCompra = _product.precioCompra
                        If ListPrices.Count = 0 Then

                        ElseIf ListPrices.Count = 1 Then


                            Dim result = precioCompra * (firstPercent / 100)
                            result = result + precioCompra

                            For Each i In ListPrices
                                dt.Rows.Add(
                                    i.precio_id,
                                    i.rango_inicio,
                                    i.rango_final,
                                    i.precioCode,
                                    result,
                                    0,
                                    result,
                                    0)
                            Next

                        ElseIf ListPrices.Count > 1 Then
                            Dim eqprec = _product.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
                            Dim valorUnitarioItem = _product.precioCompra / eqprec.contenido_neto
                            Dim ultimoIndex = ListPrices.Count - 1
                            Dim index = 0


                            'Dim UnidadPrincipal = _product.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
                            'Dim RestoUnidades = _product.detalleitem_equivalencias.Where(Function(e) e.flag <> "MAX").ToList
                            If equivalencias.flag = "MAX" Then
                                For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                    If index = ultimoIndex Then
                                        Dim result = precioCompra * (beforePercent / 100)
                                        result = result + precioCompra

                                        dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)
                                    Else

                                        Dim result = precioCompra * (firstPercent / 100)
                                        result = result + precioCompra

                                        dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)

                                    End If
                                    index += 1
                                Next


                            Else


                                For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                    If index = ultimoIndex Then
                                        Dim result = valorUnitarioItem * (beforePercent / 100)
                                        result = result + valorUnitarioItem

                                        dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)
                                    Else

                                        Dim result = valorUnitarioItem * (firstPercent / 100)
                                        result = result + valorUnitarioItem

                                        dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)

                                    End If
                                    index += 1
                                Next
                            End If




                        End If


                    Case Else ' CONFIGURACION NORMAL
                        For Each i In ListPrices
                            dt.Rows.Add(
                                i.precio_id,
                                i.rango_inicio,
                                i.rango_final,
                                i.precioCode,
                                i.precio.GetValueOrDefault,
                                i.precioUSD.GetValueOrDefault,
                                i.precioCredito.GetValueOrDefault,
                                i.precioCreditoUSD.GetValueOrDefault)
                        Next
                End Select
                GridPrecios.DataSource = dt
            End If
        End If
    End Sub

    Private Sub PreciosSelCatalogo(idEquivalencia As Integer, idCatalogo As Integer, PrecioCompraTestFirst As Decimal, PrecioCompraTestBefore As Decimal, PrecioCompraTest As Decimal, preciocompratipoTest As String)
        Dim equivalencias = _product.detalleitem_equivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault
        Dim catalogoPrec = equivalencias.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault

        If equivalencias IsNot Nothing Then
            If catalogoPrec IsNot Nothing Then
                Dim ListPrices = catalogoPrec.detalleitemequivalencia_precios.ToList

                Dim dt As New DataTable
                dt.Columns.Add("id")
                dt.Columns.Add("rangoinicio")
                dt.Columns.Add("rangofin")
                dt.Columns.Add("tipoprecio")
                dt.Columns.Add("PrecioContado")
                dt.Columns.Add("PrecioContadoUSD")
                dt.Columns.Add("PrecioCredito")
                dt.Columns.Add("PrecioCreditoUSD")
                dt.Columns.Add("btEliminar")

                Select Case preciocompratipoTest'_product.preciocompratipo
                    Case "PCT"
                        Dim firstPercent = PrecioCompraTestFirst '_product.firstpercent
                        Dim beforePercent = PrecioCompraTestBefore '_product.beforepercent
                        Dim precioCompra = PrecioCompraTest ' _product.precioCompra
                        If ListPrices.Count = 0 Then

                        ElseIf ListPrices.Count = 1 Then


                            Dim result = precioCompra * (firstPercent / 100)
                            result = result + precioCompra

                            For Each i In ListPrices
                                dt.Rows.Add(
                                    i.precio_id,
                                    i.rango_inicio,
                                    i.rango_final,
                                    i.precioCode,
                                    result,
                                    0,
                                    result,
                                    0)
                            Next

                        ElseIf ListPrices.Count > 1 Then
                            Dim eqprec = _product.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
                            Dim valorUnitarioItem = PrecioCompraTest / eqprec.contenido_neto
                            Dim ultimoIndex = ListPrices.Count - 1
                            Dim index = 0


                            'Dim UnidadPrincipal = _product.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
                            'Dim RestoUnidades = _product.detalleitem_equivalencias.Where(Function(e) e.flag <> "MAX").ToList
                            If equivalencias.flag = "MAX" Then
                                For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                    If index = ultimoIndex Then
                                        Dim result = precioCompra * (beforePercent / 100)
                                        result = result + precioCompra

                                        dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)
                                    Else

                                        Dim result = precioCompra * (firstPercent / 100)
                                        result = result + precioCompra

                                        dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)

                                    End If
                                    index += 1
                                Next


                            Else


                                For Each i In ListPrices '.OrderByDescending(Function(o) o.precio_id).ToList
                                    If index = ultimoIndex Then
                                        Dim result = valorUnitarioItem * (beforePercent / 100)
                                        result = result + valorUnitarioItem

                                        dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)
                                    Else

                                        Dim result = valorUnitarioItem * (firstPercent / 100)
                                        result = result + valorUnitarioItem

                                        dt.Rows.Add(
                                        i.precio_id,
                                        i.rango_inicio,
                                        i.rango_final,
                                        i.precioCode,
                                        result,
                                        0,
                                        result,
                                        0)

                                    End If
                                    index += 1
                                Next
                            End If




                        End If


                    Case Else ' CONFIGURACION NORMAL
                        For Each i In ListPrices
                            dt.Rows.Add(
                                i.precio_id,
                                i.rango_inicio,
                                i.rango_final,
                                i.precioCode,
                                i.precio.GetValueOrDefault,
                                i.precioUSD.GetValueOrDefault,
                                i.precioCredito.GetValueOrDefault,
                                i.precioCreditoUSD.GetValueOrDefault)
                        Next
                End Select
                GridPrecios.DataSource = dt
            End If
        End If
    End Sub

    Private Sub ComboCatalogoPrecios_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCatalogoPrecios.SelectedValueChanged
        If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
            Dim r As Record = GridEquivalencia.Table.CurrentRecord
            If r IsNot Nothing Then
                If GridEquivalencia.Table.Records.Count > 0 Then
                    GridPrecios.Table.Records.DeleteAll()
                    Dim idCatalogo = Integer.Parse(ComboCatalogoPrecios.SelectedValue)
                    PreciosSelCatalogo(CInt(r.GetValue("IDEQ")), idCatalogo)
                End If
            End If

        End If
    End Sub

    Private Sub GridEquivalencia_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridEquivalencia.TableControlCellClick
        Dim r As Record = GridEquivalencia.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridEquivalencia.Table.Records.Count > 0 Then
                GridPrecios.Table.Records.DeleteAll()
                Dim idEQ = Integer.Parse(r.GetValue("IDEQ"))
                GetPreciosSelEquivalencia(idEQ)
            End If
        End If
    End Sub

    Private Sub GridPrecios_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridPrecios.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridPrecios_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridPrecios.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Try
            If e.Inner.ColIndex = 9 Then

                If GridEquivalencia.Table.CurrentRecord IsNot Nothing Then
                    If MessageBox.Show("Desea eliminar el precio seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim idPrecio = GridPrecios.TableModel(e.Inner.RowIndex, 1).CellValue

                        'Dim EQ = ListaEquivalencia.Where(Function(o) o.IDGUI = idEquivalencia).Single
                        precioSA.PrecioEquivalenciaSave(New detalleitemequivalencia_precios With
                                                            {
                                                            .Action = BaseBE.EntityAction.DELETE,
                                                            .precio_id = idPrecio
                                                            })


                        Dim Productos = _product 'listaProductos.Where(Function(o) o.codigodetalle = Integer.Parse(GridProductos.Table.CurrentRecord.GetValue("idproducto"))).SingleOrDefault
                        Dim equivalencias = Productos.detalleitem_equivalencias.ToList
                        Dim OBJEquivalencia = equivalencias.Where(Function(eq) eq.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))).SingleOrDefault

                        If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
                            Dim ObjCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = ComboCatalogoPrecios.SelectedValue).SingleOrDefault

                            Dim listaPrecios = ObjCatalogo.detalleitemequivalencia_precios.ToList

                            Dim objPrecio = ObjCatalogo.detalleitemequivalencia_precios.Where(Function(p) p.precio_id = idPrecio).SingleOrDefault

                            ObjCatalogo.detalleitemequivalencia_precios.Remove(objPrecio)

                            PreciosSelCatalogo(Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")), CInt(ComboCatalogoPrecios.SelectedValue))
                        End If
                    End If
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPrecios.TableControlCellClick

    End Sub

    Private Sub GridPrecios_TableControlCurrentCellValidated(sender As Object, e As GridTableControlEventArgs) Handles GridPrecios.TableControlCurrentCellValidated
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridPrecios.TableControl.CurrentCell
        'cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                Select Case style.TableCellIdentity.Column.Name
                    Case "rangoinicio" ', "rangofin", "tipoprecio", "PrecioContado", "PrecioCredito", "PrecioContadoUSD", "PrecioCreditoUSD"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 2).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Cant. mínima", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("rangoinicio", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 2).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If

                    Case "PrecioContado"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 5).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Precio contado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("PrecioContado", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 5).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If

                    Case "PrecioCredito"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 7).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Precio Credito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("PrecioCredito", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 7).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If

                    Case "PrecioContadoUSD"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 6).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Precio Contado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("PrecioContadoUSD", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 6).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If

                    Case "PrecioCreditoUSD"
                        If cc.Renderer IsNot Nothing Then

                            Dim oldValue = CDec(Me.GridPrecios.TableModel(cc.RowIndex, 8).CellValue)
                            Dim newValue = CDec(cc.Renderer.ControlText)
                            Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                            If oldValue <> newValue Then
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim mensaje = $"Valor nuevo: {newValue}, valor anterior: {oldValue} {vbCrLf} Guardar cambios ?"
                                    If MessageBox.Show(mensaje, "Precio Credito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                        If r IsNot Nothing Then
                                            r.SetValue("PrecioCreditoUSD", newValue)
                                            EditarPrecio(r)
                                        End If
                                        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                    Else
                                        cc.RejectChanges()
                                        Me.GridPrecios.TableModel(cc.RowIndex, 8).CellValue = oldValue
                                        Me.GridPrecios.EndUpdate(True)
                                    End If
                                End If
                            End If
                        End If

                End Select


            End If
        End If

    End Sub

    Private Sub EditarPrecio(r As Record)
        Dim precioSA As New detalleitemequivalencia_preciosSA

        '.rango_final = Decimal.Parse(r.GetValue("rangofin")),
        Dim obj As New detalleitemequivalencia_precios With
                       {
                       .Action = BaseBE.EntityAction.UPDATE,
                       .idCatalogo = ComboCatalogoPrecios.SelectedValue,
                       .precio_id = Integer.Parse(r.GetValue("id")),
                       .rango_inicio = Decimal.Parse(r.GetValue("rangoinicio")),
                       .equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ")),
                       .codigodetalle = _product.codigodetalle,
                       .precioCode = r.GetValue("tipoprecio"),
                       .precio = Decimal.Parse(r.GetValue("PrecioContado")),
                       .precioUSD = Decimal.Parse(r.GetValue("PrecioContadoUSD")),
                       .precioCredito = Decimal.Parse(r.GetValue("PrecioCredito")),
                       .precioCreditoUSD = Decimal.Parse(r.GetValue("PrecioCreditoUSD")),
                       .usuarioActualizacion = usuario.IDUsuario,
                       .fechaActualizacion = Date.Now
        }
        precioSA.PrecioEquivalenciaSave(obj)

        Dim Productos = _product
        Dim equivalencias = Productos.detalleitem_equivalencias.ToList
        Dim OBJEquivalencia = equivalencias.Where(Function(e) e.equivalencia_id = Integer.Parse(GridEquivalencia.Table.CurrentRecord.GetValue("IDEQ"))).SingleOrDefault

        If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
            Dim ObjCatalogo = OBJEquivalencia.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CInt(ComboCatalogoPrecios.SelectedValue)).SingleOrDefault

            Dim listaPrecios = ObjCatalogo.detalleitemequivalencia_precios.ToList

            Dim objPrecio = listaPrecios.Where(Function(p) p.precio_id = obj.precio_id).SingleOrDefault
            objPrecio.precioCode = obj.precioCode
            objPrecio.precio = obj.precio
            objPrecio.precioUSD = obj.precioUSD
            objPrecio.precioCredito = obj.precioCredito
            objPrecio.precioCreditoUSD = obj.precioCreditoUSD
            objPrecio.rango_inicio = obj.rango_inicio
            'objPrecio.rango_final = obj.rango_final
        End If

        ' MessageBox.Show("Equivalencia editada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Close()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        ActualizarPreciosProduct()
        If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
            Dim r As Record = GridEquivalencia.Table.CurrentRecord
            If r IsNot Nothing Then
                If GridEquivalencia.Table.Records.Count > 0 Then
                    GridPrecios.Table.Records.DeleteAll()
                    Dim idCatalogo = Integer.Parse(ComboCatalogoPrecios.SelectedValue)
                    PreciosSelCatalogo(CInt(r.GetValue("IDEQ")), idCatalogo)
                End If
            End If

        End If
    End Sub

    Private Sub ActualizarPreciosProduct()
        Dim productoSA As New detalleitemsSA
        Dim obj As New detalleitems
        obj.codigodetalle = _product.codigodetalle
        obj.precioCompra = TextPrecioCompraNuevo.Value
        obj.preciocompratipo = If(TogglePrecio.ToggleState = ToggleButton2.ToggleButtonState.OFF, "PCT", "FJ")
        obj.firstpercent = TextFirstDescuento.Value
        obj.beforepercent = TextBeforeDescuento.Value

        productoSA.EditarValoresRentabilidadCompra(obj)
        MessageBox.Show("Precio actualizado!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        _product.precioCompra = TextPrecioCompraNuevo.Value
        _product.preciocompratipo = obj.preciocompratipo
        _product.firstpercent = TextFirstDescuento.Value
        _product.beforepercent = TextBeforeDescuento.Value
        'Dim objeq As detalleitem_equivalencias
        'For Each eq In _product.detalleitem_equivalencias
        '    objeq = New detalleitem_equivalencias
        '    objeq.equivalencia_id = eq.equivalencia_id

        'Next


    End Sub

    Private Sub TogglePrecio_Click(sender As Object, e As EventArgs) Handles TogglePrecio.Click

    End Sub

    Private Sub TogglePrecio_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles TogglePrecio.ButtonStateChanged
        If TogglePrecio.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            'MsgBox("PORCENTAJE")
            'NumericUpDownExt2.Visible = True
            'TextPrecioCompraNuevo.Visible = True
        ElseIf TogglePrecio.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            'MsgBox("MANUAL")
            'NumericUpDownExt2.Visible = False
            'TextPrecioCompraNuevo.Visible = False

        End If
        'If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
        '    Dim r As Record = GridEquivalencia.Table.CurrentRecord
        '    If r IsNot Nothing Then
        '        If GridEquivalencia.Table.Records.Count > 0 Then
        '            GridPrecios.Table.Records.DeleteAll()
        '            Dim idCatalogo = Integer.Parse(ComboCatalogoPrecios.SelectedValue)
        '            PreciosSelCatalogo(CInt(r.GetValue("IDEQ")), idCatalogo)
        '        End If
        '    End If

        'End If
    End Sub

    Private Sub ComboCatalogoPrecios_Click(sender As Object, e As EventArgs) Handles ComboCatalogoPrecios.Click

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If IsNumeric(ComboCatalogoPrecios.SelectedValue) Then
            Dim r As Record = GridEquivalencia.Table.CurrentRecord
            If r IsNot Nothing Then
                If GridEquivalencia.Table.Records.Count > 0 Then
                    GridPrecios.Table.Records.DeleteAll()
                    Dim idCatalogo = Integer.Parse(ComboCatalogoPrecios.SelectedValue)

                    'If _product.preciocompratipo = "PCT" Then
                    '    TogglePrecio.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    'Else
                    '    TogglePrecio.ToggleState = ToggleButton2.ToggleButtonState.ON
                    'End If

                    If TogglePrecio.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                        PreciosSelCatalogo(CInt(r.GetValue("IDEQ")), idCatalogo, TextFirstDescuento.Value, TextBeforeDescuento.Value, TextPrecioCompraNuevo.Value, "PCT")
                    Else
                        PreciosSelCatalogo(CInt(r.GetValue("IDEQ")), idCatalogo, TextFirstDescuento.Value, TextBeforeDescuento.Value, TextPrecioCompraNuevo.Value, "FJ")
                    End If


                End If
            End If

        End If
    End Sub

    Private Sub TextFirstDescuento_ValueChanged(sender As Object, e As EventArgs) Handles TextFirstDescuento.ValueChanged
        TextBeforeDescuento.Maximum = TextFirstDescuento.Value
    End Sub
End Class