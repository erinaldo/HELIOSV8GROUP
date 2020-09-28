Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.Collections.Generic
Public Class frmModalCanasta
    Public Property IdItemval() As Integer
#Region "Métodos"
    Public Function UbicarTablas(ByVal Codigo As String, ByVal idtabla As Integer) As String
        Dim TablaSA As New tablaDetalleSA
        Dim tabla As New tabladetalle
        Dim strValreturn As String = Nothing
        Try
            tabla = TablaSA.GetUbicarTablaID(idtabla, Codigo)
            If Not IsNothing(tabla) Then
                strValreturn = tabla.descripcion
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return strValreturn
    End Function
#End Region

    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890.", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    Public Sub AgregarAcanasta()
        If Not CDec(frmCanastaVentas.dgvItems.Item(14, frmCanastaVentas.dgvItems.CurrentRow.Index).Value()) > 0 Then
            MsgBox("Por favor, Ingrese un importe de venta.", MsgBoxStyle.Exclamation, "Atención!")
            Exit Sub
        End If
        '    Dim n As New RecolectarDatos()
        '    Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()

        Me.Cursor = Cursors.WaitCursor
        Dim statusForm As New frmStatus()
        statusForm.Tag = "CEX"
        statusForm.Show("PROCESANDO ITEMS...!")


        'n.Secuencia = datos.Count + 1
        'n.Gravado = frmCanastaPedidos.dgvItems.Item(2, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.IdArticulo = frmCanastaPedidos.dgvItems.Item(3, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.NameArticulo = frmCanastaPedidos.dgvItems.Item(4, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.UM = frmCanastaPedidos.dgvItems.Item(5, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.Cantidad = txtCantidad.Text
        'n.PrecUnitKardexMN = frmCanastaPedidos.dgvItems.Item(7, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.CantDisponible = frmCanastaPedidos.dgvItems.Item(6, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.PUmn = frmCanastaPedidos.dgvItems.Item(14, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.PUme = frmCanastaPedidos.dgvItems.Item(15, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.ImporteMN = lblTotalMN.Text
        'n.ImporteME = lblTotalME.Text
        'n.DsctoMN = frmCanastaPedidos.dgvItems.Item(16, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.DsctoME = frmCanastaPedidos.dgvItems.Item(17, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.KardexMN = "0.00"
        'n.IscMN = "0.00"
        'n.IgvMN = "0.00"
        'n.OtcMN = "0.00"
        'n.KardexME = "0.00"
        'n.IscME = "0.00"
        'n.IgvME = "0.00"
        'n.OtcME = "0.00"
        'n.Estado = "N"
        'n.TipoExistencia = frmCanastaPedidos.dgvItems.Item(1, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.IdAlmacen = frmCanastaPedidos.dgvItems.Item(0, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.Cuenta = frmCanastaPedidos.dgvItems.Item(11, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.Establecimiento = frmCanastaPedidos.dgvItems.Item(12, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.PreEvento = frmCanastaPedidos.dgvItems.Item(13, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.PrecUnitKardexME = frmCanastaPedidos.dgvItems.Item(9, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.Presentacion = frmCanastaPedidos.dgvItems.Item(18, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.FechaVcto = frmCanastaPedidos.dgvItems.Item(19, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.NamePresentacion = frmCanastaPedidos.dgvItems.Item(20, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'n.TipoVenta = frmCanastaPedidos.dgvItems.Item(22, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()
        'datos.Add(n)




        With frmCanastaVentas
            .dgvNuevoDoc.Rows.Add("00",
                                  .dgvItems.Item(2, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(3, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(4, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(5, .dgvItems.CurrentRow.Index).Value(),
                                  txtCantidad.Text,
                                  .dgvItems.Item(7, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(6, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(14, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(15, .dgvItems.CurrentRow.Index).Value(),
                                  lblTotalMN.Text,
                                  lblTotalME.Text,
                                  .dgvItems.Item(16, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(17, .dgvItems.CurrentRow.Index).Value(),
                                  "0.00",
                                  "0.00",
                                  "0.00",
                                  "0.00",
                                  "0.00",
                                  "0.00",
                                  "0.00",
                                  "0.00",
                                  "N",
                                  .dgvItems.Item(1, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(0, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(11, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(12, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(13, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(9, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(18, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(19, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(20, .dgvItems.CurrentRow.Index).Value(),
                                  .dgvItems.Item(22, .dgvItems.CurrentRow.Index).Value())

        End With
        Me.Cursor = Cursors.Arrow
        '   frmCanastaPedidos.txtFiltrar.Clear()
        '   frmCanastaPedidos.txtFiltrar.Focus()
        ' End If
        Dispose()
    End Sub

    
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'If BuscarLINQ(frmCanastaPedidos.dgvItems.Item(4, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value, frmCanastaPedidos.dgvItems.Item(2, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value, "Art", "Gravado", frmPedidoAbarrote.dgvNuevoDoc) = True Then
        '    MsgBox("Item: " & frmCanastaPedidos.dgvItems.Item(4, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value & vbCrLf & _
        '           "Destino: " & frmCanastaPedidos.dgvItems.Item(2, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value & vbCrLf & _
        '           "El Registro ya se encuentra en la canasta!", MsgBoxStyle.Exclamation, "Atención!")
        'Else
        '    If Not CDec(frmCanastaPedidos.dgvItems.Item(14, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value()) > 0 Then
        '        MsgBox("Por favor, Ingrese un importe de venta.", MsgBoxStyle.Exclamation, "Atención!")
        '        Exit Sub
        '    End If

        '    Me.Cursor = Cursors.WaitCursor
        '    Dim statusForm As New frmStatus()
        '    statusForm.Tag = "CEX"
        '    statusForm.Show("PROCESANDO ITEMS...!")
        '    With frmPedidoAbarrote
        '        .dgvNuevoDoc.Rows.Add("00",
        '                              frmCanastaPedidos.dgvItems.Item(2, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(3, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(4, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(5, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              nudCantidad.Value,
        '                              frmCanastaPedidos.dgvItems.Item(7, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(6, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(14, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(15, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              "0.00",
        '                              "0.00",
        '                              frmCanastaPedidos.dgvItems.Item(16, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(17, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              "0.00",
        '                              "0.00",
        '                              "0.00",
        '                              "0.00",
        '                              "0.00",
        '                              "0.00",
        '                              "0.00",
        '                              "0.00",
        '                              "N",
        '                              frmCanastaPedidos.dgvItems.Item(1, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(0, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(11, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(12, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(13, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(), frmCanastaPedidos.dgvItems.Item(9, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(18, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(19, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(20, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value(),
        '                              frmCanastaPedidos.dgvItems.Item(22, frmCanastaPedidos.dgvItems.CurrentRow.Index).Value())

        '    End With
        '    Me.Cursor = Cursors.Arrow
        '    frmCanastaPedidos.txtFiltrar.Clear()
        '    frmCanastaPedidos.txtFiltrar.Focus()
        'End If
        'Dispose()
        
        If txtCantidad.Text.Trim.Length > 0 Then
            If txtCantidad.Text = "." Then
                MsgBox("La cantidad debe ser un número válido.", MsgBoxStyle.Information, "Atención!")
                txtCantidad.Clear()
                txtCantidad.Focus()
            Else
                If txtCantidad.Text > 0 Then
                    If CDec(txtCantidad.Text) > CDec(lblDisponible.Text) Then
                        MsgBox("No hay suficiente cantidad pra realizar la venta, " & vbCrLf & "Verifique la cantidad en su inventario!", MsgBoxStyle.Information, "Atención!")
                        txtCantidad.Focus()
                        txtCantidad.Select(0, txtCantidad.Text.Length)
                    Else
                        AgregarAcanasta()
                    End If

                Else
                    MsgBox("La cantidad debe ser mayor a cero.", MsgBoxStyle.Information, "Atención")
                    txtCantidad.Focus()
                    txtCantidad.Select(0, txtCantidad.Text.Length)
                End If
            End If
        Else
            MsgBox("La cantidad debe ser un número válido.", MsgBoxStyle.Information, "Atención!")
            txtCantidad.Focus()
        End If
    End Sub
    Dim precioSA As New ListadoPrecioSA
    Dim precio As New listadoPrecios
    Sub confCheck(ByVal opcion As String)
        If IdItemval > 0 Then
            precio = precioSA.UbicarVentaPorItem(frmCanastaVentas.txtAlmacen.ValueMember, IdItemval)
            Select Case opcion
                Case "PM"
                    'Your add functionality here
                    'frmCanastaVentas.dgvItems.Item(16, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(2).Text
                    'frmCanastaVentas.dgvItems.Item(17, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(3).Text
                    'frmCanastaVentas.dgvItems.Item(14, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(4).Text
                    'frmCanastaVentas.dgvItems.Item(15, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(5).Text
                    frmCanastaVentas.dgvItems.Item(22, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = "PM"

                    If Not IsNothing(precio) Then
                        lblMenor.Text = precio.precioVentaFinalMenorMN
                        lblMenorME.Text = precio.precioVentaFinalMenorME
                        lblDscto.Text = precio.montoDsctounitMenorMN
                        lblDsctoME.Text = precio.montoDsctounitMenorME
                    End If


                Case "PMY"
                    'Your edit functionality here
                    'frmCanastaVentas.dgvItems.Item(16, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(6).Text
                    'frmCanastaVentas.dgvItems.Item(17, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(7).Text
                    'frmCanastaVentas.dgvItems.Item(14, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(8).Text
                    'frmCanastaVentas.dgvItems.Item(15, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(9).Text
                    frmCanastaVentas.dgvItems.Item(22, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = "PMY"

                    lblMayor.Text = precio.precioVentaFinalMayorMN
                    lblMayorME.Text = precio.precioVentaFinalMayorME
                    lblDscto.Text = precio.montoDsctounitMayorMN
                    lblDsctoME.Text = precio.montoDsctounitMayorME
                Case "PGM"
                    'Your delete functionality here
                    'frmCanastaVentas.dgvItems.Item(16, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(10).Text
                    'frmCanastaVentas.dgvItems.Item(17, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(11).Text
                    'frmCanastaVentas.dgvItems.Item(14, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(12).Text
                    'frmCanastaVentas.dgvItems.Item(15, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(13).Text
                    frmCanastaVentas.dgvItems.Item(22, frmCanastaVentas.dgvItems.CurrentRow.Index).Value = "PGM"

                    lblGMayor.Text = precio.precioVentaFinalGMayorMN
                    lblGMayorME.Text = precio.precioVentaFinalGMayorME
                    lblDscto.Text = precio.montoDsctounitGMayorMN
                    lblDsctoME.Text = precio.montoDsctounitGMayorME
            End Select
        End If
    End Sub
    Public Sub LOadDatos(intIdAlmacen As Integer, intIdItem As Integer)
        precio = precioSA.UbicarVentaPorItem(intIdAlmacen, intIdItem)

        lblMenor.Text = precio.precioVentaFinalMenorMN
        lblMenorME.Text = precio.precioVentaFinalMenorME
        ' lblDscto.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(2).Text
        ' lblDsctoME.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(3).Text

        lblMayor.Text = precio.precioVentaFinalMayorMN
        lblMayorME.Text = precio.precioVentaFinalMayorME
        ' lblDscto.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(6).Text
        ' lblDsctoME.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(7).Text

        lblGMayor.Text = precio.precioVentaFinalGMayorMN
        lblGMayorME.Text = precio.precioVentaFinalGMayorME
        ' lblDscto.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(10).Text
        ' lblDsctoME.Text = frmCanastaPedidos.lsvDetalle.SelectedItems(0).SubItems(11).Text
        '     nudCantidad_MouseClick(sender, e)
    End Sub

    Private Sub frmModalCanasta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
    End Sub

    Private Sub rbMenor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMenor.CheckedChanged
        ' nudCantidad_ValueChanged(sender, e)
        If rbMenor.Checked = True Then
            txtCantidad_TextChanged(sender, e)
            confCheck("PM")
            '   nudCantidad.Focus()
            '   nudCantidad.Select(0, nudCantidad.Text.Length)
            txtCantidad.Focus()
            txtCantidad.Select(0, txtCantidad.Text.Length)
        End If
    End Sub

    Private Sub rbMayor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMayor.CheckedChanged

        If rbMayor.Checked = True Then
            txtCantidad_TextChanged(sender, e)
            confCheck("PMY")
            ' nudCantidad.Focus()
            '   nudCantidad.Select(0, nudCantidad.Text.Length)
            txtCantidad.Focus()
            txtCantidad.Select(0, txtCantidad.Text.Length)
        End If
    End Sub

    Private Sub rbGMayor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGMayor.CheckedChanged
        If rbGMayor.Checked = True Then
            txtCantidad_TextChanged(sender, e)
            confCheck("PGM")
            'nudCantidad.Focus()
            'nudCantidad.Select(0, nudCantidad.Text.Length)
            txtCantidad.Focus()
            txtCantidad.Select(0, txtCantidad.Text.Length)
        End If
    End Sub


    Sub calculos()
        If rbMenor.Checked = True Then
            If lblMenor.Text.Trim.Length > 0 Then
                lblTotalMN.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblMenor.Text), 2)
            End If
            If lblMenorME.Text.Trim.Length > 0 Then
                lblTotalME.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblMenorME.Text), 2)
            End If

        End If
        If rbMayor.Checked = True Then
            If lblMayor.Text.Trim.Length > 0 Then
                lblTotalMN.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblMayor.Text), 2)
            End If

            If lblMayorME.Text.Trim.Length > 0 Then
                lblTotalME.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblMayorME.Text), 2)
            End If

        End If
        If rbGMayor.Checked = True Then
            If lblGMayor.Text.Trim.Length > 0 Then
                lblTotalMN.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblGMayor.Text), 2)
            End If

            If lblGMayorME.Text.Trim.Length > 0 Then
                lblTotalME.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblGMayorME.Text), 2)
            End If

        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown

    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidad_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCantidad.MouseClick
        txtCantidad.Select(0, txtCantidad.Text.Length)
    End Sub

    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        If txtCantidad.Text.Trim.Length > 0 Then
            If txtCantidad.Text = "." Then
                MsgBox("Ingrese un valor válido!", MsgBoxStyle.Information, "Atención!")
                txtCantidad.Clear()
                txtCantidad.Focus()
            Else
                calculos()
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If txtCantidad.Text.Trim.Length > 0 Then
            If txtCantidad.Text = "." Then
                MsgBox("La cantidad debe ser un número válido.", MsgBoxStyle.Information, "Atención!")
                txtCantidad.Clear()
                txtCantidad.Focus()
            Else
                If txtCantidad.Text > 0 Then
                    If CDec(txtCantidad.Text) > CDec(lblDisponible.Text) Then
                        MsgBox("No hay suficiente cantidad pra realizar la venta, " & vbCrLf & "Verifique la cantidad en su inventario!", MsgBoxStyle.Information, "Atención!")
                        txtCantidad.Focus()
                        txtCantidad.Select(0, txtCantidad.Text.Length)
                    Else
                        AgregarAcanasta()
                    End If

                Else
                    MsgBox("La cantidad debe ser mayor a cero.", MsgBoxStyle.Information, "Atención")
                    txtCantidad.Focus()
                    txtCantidad.Select(0, txtCantidad.Text.Length)
                End If
            End If
        Else
            MsgBox("La cantidad debe ser un número válido.", MsgBoxStyle.Information, "Atención!")
            txtCantidad.Focus()
        End If
    End Sub
End Class