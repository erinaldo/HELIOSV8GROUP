Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Bunifu.Framework.UI

Public Class UserControlRestaurant

    Public Event OKEvent()
    Dim listaItem As New List(Of item)
    Public listaProductos As List(Of detalleitems)
    Private Property ProductoSA As New detalleitemsSA
    Public Property UCEstructuraCabeceraVenta As UCEstructuraVentaRestaurant

    Public Sub New(ucVenta As UCEstructuraVentaRestaurant)

        ' This call is required by the designer.
        InitializeComponent()

        UCEstructuraCabeceraVenta = ucVenta

        ' Add any initialization after the InitializeComponent() call.
        CargarCategorias()
    End Sub

#Region "Events"

    Private Sub CargarCategorias()
        Dim itemBE As New item
        Dim itemSA As New itemSA


        itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)

        dibujarCategorias(listaItem)
        sliderTop1.Visible = False
        sliderTop.Visible = False
    End Sub

    Sub dibujarCategorias(listDistr As List(Of item))
        FlowCategoria.Controls.Clear()
        FlowProductos.Controls.Clear()
        FlowSubCategoria.Controls.Clear()

        sliderTop1.Visible = False
        sliderTop.Visible = False

        Dim consulta = (listDistr.Where(Function(o) o.tipo = "C")).ToList

        For Each items In consulta
            Dim b As New BunifuFlatButton

            b.BackColor = System.Drawing.Color.White
            b.Text = items.descripcion
            b.TabIndex = items.idItem
            b.Textcolor = System.Drawing.Color.Blue
            b.Tag = items
            b.TextFont = New Font("Segoe UI Semibold", 9, FontStyle.Bold)
            b.Normalcolor = System.Drawing.Color.White
            b.OnHovercolor = System.Drawing.Color.White
            b.OnHoverTextColor = System.Drawing.Color.Peru
            b.AutoSize = False
            b.IconVisible = False
            b.DisabledColor = System.Drawing.Color.White
            b.Activecolor = System.Drawing.Color.White
            b.Size = New System.Drawing.Size(80, 25)
            b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            FlowCategoria.Controls.Add(b)

            AddHandler b.Click, AddressOf Butto1

        Next
    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Try
            FlowProductos.Controls.Clear()
            sliderTop.Visible = True
            sliderTop1.Visible = False
            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

            Dim c = CType(sender.Tag, item)
            Dim consulta = (listaItem.Where(Function(o) o.tipo = "M" And o.idPadre = c.idItem)).ToList
            FlowSubCategoria.Controls.Clear()
            For Each items In consulta
                Dim b As New BunifuFlatButton

                b.BackColor = System.Drawing.Color.White
                b.Text = items.descripcion
                b.TabIndex = items.idItem
                b.Textcolor = System.Drawing.Color.Blue
                b.Tag = items
                b.TextFont = New Font("Segoe UI Semibold", 9, FontStyle.Bold)
                b.Normalcolor = System.Drawing.Color.White
                b.OnHovercolor = System.Drawing.Color.White
                b.OnHoverTextColor = System.Drawing.Color.Peru
                b.AutoSize = False
                b.IconVisible = False
                b.DisabledColor = System.Drawing.Color.White
                b.Activecolor = System.Drawing.Color.White
                If (items.descripcion.Length >= 10) Then
                    b.Size = New System.Drawing.Size(100, 20)
                Else
                    b.Size = New System.Drawing.Size(80, 20)
                End If

                b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                FlowSubCategoria.Controls.Add(b)

                AddHandler b.Click, AddressOf Butto2

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Butto2(sender As Object, e As EventArgs)
        Try
            Dim catalagoDefault As Object
            Dim PRECIO As Object
            sliderTop1.Visible = True
            sliderTop1.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop1.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

            Dim c = CType(sender.Tag, item)

            FlowProductos.Controls.Clear()

            listaProductos = ProductoSA.GetProductosWithEquivalenciasXCat(New detalleitems With {.idItem = c.idItem})

            For Each items In listaProductos
                Dim b As New RoundButton2

                If items.detalleitem_equivalencias.Count > 0 Then
                    catalagoDefault = items.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault
                Else
                    catalagoDefault = Nothing
                End If

                b.BackColor = System.Drawing.Color.Green

                If (Not IsNothing(catalagoDefault)) Then
                    PRECIO = (catalagoDefault.detalleitemequivalencia_precios(0).PRECIO)
                Else
                    PRECIO = 0.0
                End If

                'b.Text = items.descripcionItem & vbNewLine & "S/. " & If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, 0.00)
                b.Text = items.descripcionItem & vbNewLine & "S/. " & PRECIO
                b.Name = items.codigodetalle
                b.FlatStyle = FlatStyle.Standard
                b.TabIndex = items.codigodetalle
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                b.ForeColor = System.Drawing.Color.White
                b.Size = New System.Drawing.Size(130, 100)
                b.Tag = items
                b.Image = ImageList1.Images(0)
                b.ImageAlign = ContentAlignment.MiddleCenter
                b.TextImageRelation = TextImageRelation.ImageAboveText
                b.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                b.UseVisualStyleBackColor = False
                FlowProductos.Controls.Add(b)

                AddHandler b.Click, AddressOf Butto3

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Butto3(sender As Object, e As EventArgs)
        Try

            Dim c = CType(sender.Tag, detalleitems)

            'Agregando Producto
            '-----------------------------------------------------------------------------------------
            '*******************************************************************************************

            Dim equivalencia = c.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault

            Dim StockTotal = If(c.totalesAlmacen IsNot Nothing, c.totalesAlmacen.Sum(Function(o) o.cantidad), 0)

            Dim CatalogoPrecio As Integer = 0 ' style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios") ' GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

            Dim codiProducto As Integer = c.codigodetalle
            ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
            Dim eqLista = c ' GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

            If eqLista.productoRestringido = True Then
                If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            Dim listaEquivalencias = eqLista.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList
            Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia.equivalencia_id).SingleOrDefault

            If objEQ Is Nothing Then
                MessageBox.Show("Indicar una unidad comercial!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim catalagoDefault = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

            If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                If objEQ.detalleitemequivalencia_catalogos.Count > 0 Then
                    Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault

                    If catalogPredeterminado IsNot Nothing Then
                        'If (catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing) Then

                        '    'style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                        '    CatalogoPrecio = catalogPredeterminado.idCatalogo
                        'Else
                        '    'style.TableCellIdentity.Table.CurrentRecord.SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                        CatalogoPrecio = objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo
                        'End If
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



                'Dim idProducto = GridTotales.Table.CurrentRecord.GetValue("idItem")
                Dim precioVenta As Decimal = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                '   If inp IsNot Nothing Then
                If IsNumeric(inp) Then
                    If (inp) > 0 Then

                        Dim precioventaFormula = GetCalculoPrecioVenta(sender, CDec(inp), codiProducto, equivalencia.equivalencia_id, CatalogoPrecio)
                        precioVenta = precioventaFormula

                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVentaTouch(sender, inp, codiProducto, precioventaFormula, objEQ, CatalogoPrecio)
                        UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)

                        'Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
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

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetCalculoPrecioVenta(SENDER As Object, cantidadVenta As Decimal, idProducto As Integer, idEquivalencia As Integer, idCatalogo As Integer) As Decimal

        Dim DETALLE = CType(SENDER.Tag, detalleitems)

        GetCalculoPrecioVenta = 0
        Dim objProducto = DETALLE

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
                        'Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                        '    Case "CONTADO"
                        '        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                        '    Case "CREDITO"
                        '        GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                        'End Select

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

                        ElseIf UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text = "PEDIDO" Then

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

                        ElseIf UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text = "PEDIDO" Then

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

    'Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
    '                        precioVenta = precioventaFormula

    '                        Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

    '                        If eqLista.productoRestringido = True Then
    '                            If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
    '                                Me.Cursor = Cursors.Default
    '                                Exit Sub
    '                            End If
    '                        End If

    '                        Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
    '                        Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

    '                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioVenta, objEQ, CatalogoPrecio)
    '                        UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)


    Private Sub GridTotales_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs)
        Try

            'Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
            '                        precioVenta = precioventaFormula

            '                        Dim eqLista = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

            '                        Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
            '                        Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

            '                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio)
            '                        UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar!")
        End Try

    End Sub

    Private Sub UserControlCanasta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Hide()
        End If
    End Sub

    Private Sub btnOK_Click_1(sender As Object, e As EventArgs)
        RaiseEvent OKEvent()
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs)
        FlowProductos.Controls.Clear()
        dibujarCategorias(listaItem)
    End Sub

#End Region
End Class
