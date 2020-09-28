Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class UCListaLotes

#Region "Atributos"

    Public UserControlCanasta As UserControlCanasta

#End Region

#Region "Constructor"



    Sub New(form As UserControlCanasta)

        ' This call is required by the designer.
        InitializeComponent()
        UserControlCanasta = form
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ListInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListInventario.SelectedIndexChanged

    End Sub

    Private Sub ListInventario_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListInventario.MouseDoubleClick
        If ListInventario.SelectedItems.Count = 0 Then Exit Sub
        'If UserControlCanasta.UCEstructuraCabeceraVenta.ChVentaLote.Checked = True Then
        Try

            'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            'Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
            'cc.ConfirmChanges()


            Dim equivalencia = ListInventario.SelectedItems(0).SubItems(9).Text ' GridTotales.Table.CurrentRecord.GetValue("cboEquivalencias")
            Dim CatalogoPrecio As Integer = 0 ' style.TableCellIdentity.Table.CurrentRecord.GetValue("cboPrecios") ' GridTotales.Table.CurrentRecord.GetValue("cboPrecios")

            Dim codiProducto As Integer = ListInventario.SelectedItems(0).SubItems(10).Text
            Dim eqLista = UserControlCanasta.UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = codiProducto).SingleOrDefault ' GridTotales.Table.CurrentRecord.GetValue("idItem")).SingleOrDefault

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
                Dim lote = eqLista.recursoCostoLote.Where(Function(o) o.codigoLote = ListInventario.SelectedItems(0).SubItems(2).Text).SingleOrDefault


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

                        CatalogoPrecio = catalogPredeterminado.idCatalogo
                        Else

                        CatalogoPrecio = objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo
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
                        If UserControlCanasta.UCEstructuraCabeceraVenta.ChVentaLote.Checked Then
                            stock = Decimal.Parse(ListInventario.SelectedItems(0).SubItems(4).Text)
                        Else
                        stock = Decimal.Parse(UserControlCanasta.GridCompra.Table.CurrentRecord.GetValue("cantidad"))
                    End If
                    UserControlCanasta.UCEstructuraCabeceraVenta.AgregarProductoDetalleVentaLote(CatalogoPrecio, inp, codiProducto, objEQ, stock, lote)
                    'End If


                    UserControlCanasta.UCEstructuraCabeceraVenta.LoadCanastaVentas(UserControlCanasta.UCEstructuraCabeceraVenta.ListaproductosVendidos)


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
        'End If
    End Sub

#End Region

End Class
