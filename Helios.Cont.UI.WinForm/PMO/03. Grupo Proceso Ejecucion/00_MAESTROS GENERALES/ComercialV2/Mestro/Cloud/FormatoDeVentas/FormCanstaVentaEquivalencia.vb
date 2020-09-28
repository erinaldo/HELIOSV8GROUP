Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class FormCanstaVentaEquivalencia
    'Private UCEstructuraCabeceraVenta.listaProductos As List(Of detalleitems)
    Public Property UCEstructuraCabeceraVenta As UCEstructuraCabeceraVentaV2
    Private UCPreciosCanastaVenta As UCPreciosCanastaVenta

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
    End Sub

    Public Sub New(ucVenta As UCEstructuraCabeceraVentaV2)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCPreciosCanastaVenta = New UCPreciosCanastaVenta With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCPreciosCanastaVenta)
        'FormatoGridAvanzado(GridTotales, False, False, 9.0F)
        FormatoGridBlack(GridTotales, False)
        UCEstructuraCabeceraVenta = ucVenta
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCell


        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DisplayMember = "nombre_corto"
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.ValueMember = "idCatalogo"

        '     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive


        'Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        'Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
        'Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.ValueMember = "precio"
        ''     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
        'Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive

        'OrdenamientoGrid(GridTotales, False)
        GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        CargarAlmacenes()
    End Sub
#End Region

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.Escape
                Close()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    Public Sub CargarAlmacenes()
        Dim almacenSA As New almacenSA
        Dim almacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        Dim objeto As New almacen
        objeto.idAlmacen = 0
        objeto.descripcionAlmacen = "TODOS"
        almacenes.Add(objeto)

        ComboAlmacenes.DataSource = almacenes
        ComboAlmacenes.DisplayMember = "descripcionAlmacen"
        ComboAlmacenes.ValueMember = "idAlmacen"

        ComboAlmacenes.Text = "TODOS"
    End Sub
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
                        'cc.ConfirmChanges()
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
                        If UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text = "PRE VENTA" Then

                            Select Case UCEstructuraCabeceraVenta.cboMoneda.Text
                                Case "NUEVO SOL"
                                    If i.precio.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
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
                                            If i.precio.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                            End If

                                        Case "CREDITO"
                                            If i.precioCredito.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
                                            End If
                                    End Select
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
                                    If i.precio.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
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
                                            If i.precio.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                            End If

                                        Case "CREDITO"
                                            If i.precioCredito.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
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

                            Dim idcatalogo = GridTotales.TableModel(e.Inner.RowIndex, 7).CellValue

                            If idcatalogo.ToString.Trim.Length = 0 Then
                                MessageBox.Show("Debe ingresar un catalogo de precio valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If

                            Dim objCatalogo = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idcatalogo).SingleOrDefault


                            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, objCatalogo.idCatalogo)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar")
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridTotales_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridTotales.TableControlCurrentCellCloseDropDown

        'Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'e.TableControl.CurrentCell.EndEdit()
        'e.TableControl.Table.TableDirty = True
        'e.TableControl.Table.EndEdit()

        'If cc.ColIndex > -1 Then
        '    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)


        '    If style.TableCellIdentity.Column.Name = "cboEquivalencias" Then
        '        If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
        '            cc.EndEdit()
        '            Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
        '            Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

        '            Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

        '            Dim Unidades = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault


        '            If Unidades.detalleitemequivalencia_catalogos IsNot Nothing Then
        '                If Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
        '                    Dim cataPredeterminado = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True AndAlso c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault

        '                    If cataPredeterminado IsNot Nothing Then
        '                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cataPredeterminado.idCatalogo)

        '                    ElseIf Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
        '                        style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", Unidades.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
        '                    End If
        '                Else
        '                    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                    Me.Cursor = Cursors.Default
        '                    Exit Sub
        '                End If
        '            Else
        '                MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                Me.Cursor = Cursors.Default
        '                Exit Sub
        '            End If

        '            Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
        '            Dim cat As detalleitemequivalencia_catalogos = Nothing

        '            If IsNumeric(idCatalogo) Then
        '                cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
        '            ElseIf idCatalogo.ToString.Trim.Length > 0 Then
        '                cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

        '                Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
        '                UCPreciosCanastaVenta.GetDetallePrecios(lista)
        '            Else
        '                MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                Me.Cursor = Cursors.Default
        '                Exit Sub
        '            End If

        '            'If idCatalogo.ToString.Trim.Length > 0 Then
        '            '    'cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
        '            '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
        '            'Else
        '            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '    Me.Cursor = Cursors.Default
        '            '    Exit Sub
        '            'End If

        '            If cat IsNot Nothing Then
        '                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
        '                cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

        '                Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
        '                UCPreciosCanastaVenta.GetDetallePrecios(lista)
        '            Else

        '            End If

        '        End If
        '    ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then

        '        If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
        '            cc.EndEdit()
        '            Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")
        '            Dim codiUnidadComercial = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboEquivalencias")

        '            Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

        '            Dim Unidades = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault


        '            'If Unidades.detalleitemequivalencia_catalogos IsNot Nothing Then
        '            '    If Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
        '            '        Dim cataPredeterminado = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True AndAlso c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault

        '            '        If cataPredeterminado IsNot Nothing Then
        '            '            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cataPredeterminado.idCatalogo)

        '            '        ElseIf Unidades.detalleitemequivalencia_catalogos.Count > 0 Then
        '            '            style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", Unidades.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
        '            '        End If
        '            '    Else
        '            '        MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '        Me.Cursor = Cursors.Default
        '            '        Exit Sub
        '            '    End If
        '            'Else
        '            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '    Me.Cursor = Cursors.Default
        '            '    Exit Sub
        '            'End If

        '            Dim idCatalogo = style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios")
        '            Dim cat As detalleitemequivalencia_catalogos = Nothing

        '            If IsNumeric(idCatalogo) Then
        '                cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
        '            ElseIf idCatalogo.ToString.Trim.Length > 0 Then
        '                cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault

        '                Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
        '                UCPreciosCanastaVenta.GetDetallePrecios(lista)
        '            Else
        '                MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                Me.Cursor = Cursors.Default
        '                Exit Sub
        '            End If

        '            'If idCatalogo.ToString.Trim.Length > 0 Then
        '            '    'cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
        '            '    cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.predeterminado = True And c.equivalencia_id = Unidades.equivalencia_id).FirstOrDefault
        '            'Else
        '            '    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            '    Me.Cursor = Cursors.Default
        '            '    Exit Sub
        '            'End If

        '            If cat IsNot Nothing Then
        '                style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", cat.idCatalogo)
        '                cat = Unidades.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = cat.idCatalogo).SingleOrDefault

        '                Dim lista = ConvertirPreciosArangos(cat.detalleitemequivalencia_precios.ToList)
        '                UCPreciosCanastaVenta.GetDetallePrecios(lista)
        '            Else

        '            End If
        '        End If

        '    ElseIf style.TableCellIdentity.Column.Name = "importeMn" Then

        '    End If

        'End If
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

                                    Dim producto = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).Single

                                    Dim UnidadesLista = producto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

                                    Dim Unidades = UnidadesLista.Where(Function(o) o.equivalencia_id = codiUnidadComercial).SingleOrDefault

                                    If Unidades Is Nothing Then
                                        MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If

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
                                            MessageBox.Show("Identificar un catalogo de precios valido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            Exit Sub
                                        End If


                                        Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)

                                        Dim formCantidad As New FormAsignarCantidadVenta
                                        formCantidad.StartPosition = FormStartPosition.CenterParent
                                        formCantidad.ShowDialog(Me)
                                        If formCantidad.Tag IsNot Nothing Then
                                            If IsNumeric(formCantidad.Tag) Then
                                                Dim inp = CDec(formCantidad.Tag) 'InputBox("Ingreser cantidad", "Atención", "")
                                                '   If inp IsNot Nothing Then
                                                If IsNumeric(inp) Then
                                                    If (inp) > 0 Then

                                                        Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), codiProducto, Unidades.equivalencia_id, cat.idCatalogo)

                                                        If precioventaFormula <= 0 Then
                                                            MessageBox.Show("Precio de venta debe ser mayor a cero!", "Validar precio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                            Exit Sub
                                                        End If
                                                        precioVenta = precioventaFormula
                                                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, codiProducto, precioventaFormula, Unidades, cat.idCatalogo)
                                                        UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
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
                                            End If
                                        End If

                                    End If


                                    Case Else

                        End Select
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


        UCEstructuraCabeceraVenta.listaProductos = ListadoProductosSingleton.Where(Function(o) o.descripcionItem.Contains(txtFiltrar.Text.Trim.ToString)).ToList

        Dim StockTotal As Decimal = 0
        For Each i In UCEstructuraCabeceraVenta.listaProductos
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


    Public Sub ConsultaProductoAlmacen(idAlmacen As Integer)
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
            dt.Columns.Add("idAlmacen")


            If CheckStock.Checked = True Then
                UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventarioTipoAlmacen(New detalleitems With
                                                              {
                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                              .descripcionItem = txtFiltrar.Text,
                                                              .idAlmacen = idAlmacen
                                                              })

            Else

                UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                            {
                                                            .idEmpresa = Gempresas.IdEmpresaRuc,
                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                            .descripcionItem = txtFiltrar.Text
                                                            })
            End If

            Dim StockTotal As Decimal = 0
            For Each i In UCEstructuraCabeceraVenta.listaProductos
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
                  i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0, i.idAlmacen)
                '              If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precioCode, "0"),
                'If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precio, "0"))
            Next
            GridTotales.DataSource = dt
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        End If
    End Sub

    Public Sub ConsultaProducto()
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
                UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                              {
                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                              .descripcionItem = txtFiltrar.Text
                                                              })

            Else

                UCEstructuraCabeceraVenta.listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                            {
                                                            .idEmpresa = Gempresas.IdEmpresaRuc,
                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                            .descripcionItem = txtFiltrar.Text
                                                            })
            End If

            Dim StockTotal As Decimal = 0
            For Each i In UCEstructuraCabeceraVenta.listaProductos
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

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click


        If txtFiltrar.Text.Trim.Length >= 2 Then

            If ComboAlmacenes.Text = "TODOS" Then
                ConsultaProducto()
            Else
                ConsultaProductoAlmacen(ComboAlmacenes.SelectedValue)
            End If

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
                            Dim codiAlmacen As Integer = style.TableCellIdentity.Table.CurrentRecord.GetValue("idAlmacen")
                            ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                            Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).SingleOrDefault ' GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

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

                            'UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, codiProducto, precioventaFormula, objEQ, CatalogoPrecio)
                            'UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)

                            'Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                            'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
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
                            'Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

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

                            '            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
                            '            UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
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
                                Dim CodiAlmacen = GridTotales.Table.CurrentRecord.GetValue("idAlmacen")
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




                                        If CodiAlmacen IsNot Nothing Then
                                            UCEstructuraCabeceraVenta.AgregarProductoDetalleVentaAlmacen(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio, CodiAlmacen)
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

                            '                Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

                            '                Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                            '                Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                            '                UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
                            '                UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)
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
            '.UCNuenExistencia.chClasificacion.Checked = False
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

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click

    End Sub

    Private Sub GridTotales_KeyDown(sender As Object, e As KeyEventArgs) Handles GridTotales.KeyDown

    End Sub
End Class