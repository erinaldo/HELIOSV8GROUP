Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class UserCanastaComposicion
    Public Property UCEstructuraCabeceraVenta As frmComposicionSingle
    Private UCPreciosCanastaVenta As UCPreciosCanastaVenta
    Public Event OKEvent()
    Public Sub New(ucVenta As frmComposicionSingle)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridTotales, False, False, 9.0F)
        UCEstructuraCabeceraVenta = ucVenta
        UCPreciosCanastaVenta = New UCPreciosCanastaVenta With {.Dock = DockStyle.Fill}


        OrdenamientoGrid(GridTotales, False)
        GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

    End Sub

#Region "Events"


    Private Sub GridTotales_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridTotales.TableControlKeyDown
        Try
            Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
            If cc.RowIndex > -1 Then
                If e.Inner.KeyCode = Keys.Enter Then

                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
                        '                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        'Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                        If currenrecord IsNot Nothing Then
                            Dim value As String = currenrecord.GetValue("idItem").ToString()
                            Dim prod = UCEstructuraCabeceraVenta.listaCategoria.Where(Function(o) o.codigodetalle = value).Single
                            'Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

                            UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(prod.codigodetalle)

                            Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")

                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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
        'If e.Inner.Style.CellType = "PushButton" Then
        '    e.Inner.Cancel = True

        '    ' //Draw the Image in a cell.
        '    If e.Inner.ColIndex = 9 Then
        '        e.Inner.Style.Description = "Agregar"
        '        e.Inner.Style.TextColor = Color.Black
        '        e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
        '        Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
        '                                   New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
        '            )
        '        '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
        '    ElseIf e.Inner.ColIndex = 10 Then
        '        e.Inner.Style.Description = "Stock"
        '        e.Inner.Style.TextColor = Color.Black
        '        e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
        '        Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
        '                                   New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
        '            )
        '    End If
        'End If
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

    'Private Sub GridTotales_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridTotales.TableControlPushButtonClick
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        If e.Inner.ColIndex = 9 Then

    '            Dim equivalencia = GridTotales.TableModel(e.Inner.RowIndex, 6).CellValue
    '            Dim CatalogoPrecio = GridTotales.TableModel(e.Inner.RowIndex, 7).CellValue

    '            If equivalencia.ToString.Trim.Length = 0 Then
    '                MessageBox.Show("Debe ingresar una equivalencia valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Me.Cursor = Cursors.Default
    '                Exit Sub
    '            End If

    '            'If precio.ToString.Trim.Length = 0 Then
    '            '    MessageBox.Show("Debe ingresar un precio valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            '    Me.Cursor = Cursors.Default
    '            '    Exit Sub
    '            'End If


    '            Dim idProducto = GridTotales.TableModel(e.Inner.RowIndex, 2).CellValue

    '            Dim precioVenta = 0 ' CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
    '            Dim inp = InputBox("Ingreser cantidad", "Atención", "")
    '            If inp IsNot Nothing Then
    '                If IsNumeric(inp) Then
    '                    If (inp) > 0 Then

    '                        Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
    '                        precioVenta = precioventaFormula

    '                        Dim eqLista = UCEstructuraCabeceraVenta.listaCategoria.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

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
    '                    Else
    '                        MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        Me.Cursor = Cursors.Default
    '                        Exit Sub
    '                    End If
    '                Else
    '                    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Me.Cursor = Cursors.Default
    '                    Exit Sub
    '                End If
    '            Else
    '                MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Me.Cursor = Cursors.Default
    '            End If
    '            'MsgBox("Cantidad: " & inp)
    '        ElseIf e.Inner.ColIndex = 10 Then
    '            Dim idProducto = GridTotales.TableModel(e.Inner.RowIndex, 2).CellValue
    '            '  GetProductosEnAlmacen(idProducto)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar")
    '    End Try

    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub GridTotales_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridTotales.TableControlCurrentCellCloseDropDown

        Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
        cc.ConfirmChanges()

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        If cc.ColIndex > -1 Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)


            If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                    cc.EndEdit()
                    Dim codiProducto = style.TableCellIdentity.Table.CurrentRecord.GetValue("idItem")


                UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(codiProducto)

                Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")

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


                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)
                    cc.ConfirmChanges()

                    '                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                    'Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                    '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                    If currenrecord IsNot Nothing Then
                        Dim value As String = currenrecord.GetValue("idItem").ToString()
                        Dim prod = UCEstructuraCabeceraVenta.listaCategoria.Where(Function(o) o.codigodetalle = value).Single
                        'Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

                        UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(prod.codigodetalle)

                        Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")

                    End If
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar!")
        End Try

    End Sub

    Private Sub GridTotales_TableControlCurrentCellShowingDropDown(sender As Object, e As GridTableControlCurrentCellShowingDropDownEventArgs) Handles GridTotales.TableControlCurrentCellShowingDropDown
        If e.Inner.Size.Height = 117 Then
            e.Inner.Size = New Size(e.Inner.Size.Width, 180)
        Else
            e.Inner.Size = New Size(e.Inner.Size.Width, e.Inner.Size.Height)
        End If
        'e.Inner.Size = New Size(e.Inner.Size.Width, e.Inner.Size.Height + 20)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

        End If

    End Sub


    Private Sub UserControlCanasta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Hide()
        End If
    End Sub

    Private Sub btnOK_Click_1(sender As Object, e As EventArgs)
        RaiseEvent OKEvent()
    End Sub

    Private Sub GridTotales_KeyDown(sender As Object, e As KeyEventArgs) Handles GridTotales.KeyDown
        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                Dim idProducto As Integer = Integer.Parse(GridTotales.Table.Records(0).GetValue("idproducto"))
                'If currenrecord IsNot Nothing Then
                Dim value As String = GridTotales.Table.Records(0).GetValue("idItem").ToString()
                    Dim prod = UCEstructuraCabeceraVenta.listaCategoria.Where(Function(o) o.codigodetalle = value).Single
                    'Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

                    UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(prod.codigodetalle)

                    Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")
                'Else

                'End If
            End If
            If e.KeyCode = Keys.Down Then

                'If UserControl.GridTotales.Table.Records.Count > 0 Then
                '    popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                '    Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
                '    Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
                '    Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                'End If


            End If

            If e.KeyCode = Keys.Escape Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Try
        '    Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
        '    If cc.RowIndex > -1 Then

        '        If cc IsNot Nothing Then
        '                cc.ConfirmChanges()
        '                Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
        '                '                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '                'Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
        '                Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '                '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
        '                If currenrecord IsNot Nothing Then
        '                    Dim value As String = currenrecord.GetValue("idItem").ToString()
        '                    Dim prod = UCEstructuraCabeceraVenta.listaCategoria.Where(Function(o) o.codigodetalle = value).Single
        '                    'Dim idEquiva = currenrecord.GetValue("cboEquivalencias").ToString()

        '                    UCEstructuraCabeceraVenta.AgregarProductoDetalleVenta(prod.codigodetalle)

        '                    Me.GridTotales.Table.CurrentRecord.SetCurrent("descripcion")

        '                End If

        '            End If


        '        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub



#End Region
End Class
