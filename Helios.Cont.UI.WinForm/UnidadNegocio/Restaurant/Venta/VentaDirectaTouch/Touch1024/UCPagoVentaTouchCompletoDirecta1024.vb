Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class UCPagoVentaTouchCompletoDirecta1024


#Region "Attributes"
    Public Property FormVentaPrincipal As FormVentaTouchDirecta1024
    Private listaActivas As List(Of cajaUsuario)
    Private listaCuentasGrid As List(Of estadosFinancierosConfiguracionPagos)
#End Region

#Region "Constructors"
    Public Sub New(FormVenta As FormVentaTouchDirecta1024)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormVentaPrincipal = FormVenta
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        GetCajasActivas()
        FormatoGrid()
        GetUsuarioUnico()
    End Sub
#End Region

#Region "Methods"
    Private Sub FormatoGrid()
        For Each i In GridCompra.TableDescriptor.Columns
            i.AllowSort = False
            i.Appearance.AnyRecordFieldCell.TextColor = Color.Black
        Next
    End Sub

    Private Sub GetUsuarioUnico()
        ' If CheckUsuarioUnico.Checked = True Then
        Dim user = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).SingleOrDefault
        If user IsNot Nothing Then
            TextCodigoVendedor.Text = user.codigo
            TextBoxExt1.Text = user.CustomAutenticacionUsuario.Alias
        End If
        'End If
    End Sub

    Private Sub GetUsuarioUnicoSel(CodigoUser As String)
        ' If CheckUsuarioUnico.Checked = True Then
        Dim user = UsuariosList.Where(Function(o) o.codigo = CodigoUser).SingleOrDefault
        If user IsNot Nothing Then
            TextCodigoVendedor.Text = user.codigo
            TextBoxExt1.Text = user.CustomAutenticacionUsuario.Alias
        Else
            TextCodigoVendedor.Text = String.Empty
            TextBoxExt1.Text = String.Empty
        End If
        'End If
    End Sub

    Sub GetCajasActivas()
        Dim UsuarioBE = New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        UsuarioBE.idEmpresa = Gempresas.IdEmpresaRuc
        UsuarioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        UsuarioBE.estadoCaja = "A"

        listaActivas = cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE)

        ComboCaja.DataSource = listaActivas
        ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
        ComboCaja.DisplayMember = "NombrePersona"

    End Sub

    Public Sub GetLoadGridCajas(idCaja As Integer)
        Dim dt As New DataTable
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        With dt.Columns
            .Add("IDforma")
            .Add("forma")
            .Add("idCuenta")
            .Add("Cuenta")
            .Add("tipodoc")
            .Add("nrooper")
            .Add("codigoTarjeta")
            .Add("monto")
            .Add("action")
            .Add("iddocumento")
        End With

        listaCuentasGrid = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                 {
                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                 .IDCaja = idCaja
                                                 })

        For Each i In listaCuentasGrid ' ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
            If i.FormaPago = "EFECTIVO" And FormVentaPrincipal.UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue > 0 Then
                dt.Rows.Add(i.IDFormaPago, i.FormaPago, i.identidad, i.entidad, "VOUCHER", String.Empty, String.Empty, FormVentaPrincipal.UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue, "", 0)
            Else
                dt.Rows.Add(i.IDFormaPago, i.FormaPago, i.identidad, i.entidad, "VOUCHER", String.Empty, String.Empty, 0.0, "", 0)
            End If

        Next
        GridCompra.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub ComboCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCaja.SelectedValueChanged
        If IsNumeric(ComboCaja.SelectedValue) Then
            GetLoadGridCajas(Integer.Parse(ComboCaja.SelectedValue))
        End If
    End Sub

    Private Sub ComboCaja_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboCaja_Click_1(sender As Object, e As EventArgs) Handles ComboCaja.Click

    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

    End Sub

    Public Function SumaPagos() As Decimal
        SumaPagos = 0
        For Each i In GridCompra.Table.Records
            SumaPagos += CDec(i.GetValue("monto"))
        Next
        SumaPagos = SumaPagos
        TextPagado.DecimalValue = SumaPagos
        Return SumaPagos
    End Function

    Private Sub GridCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try

            Select Case ColIndex
                Case 6
                    Dim pagos As Decimal = SumaPagos()

                    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

                    If pagos > TextCompraTotal.DecimalValue Then
                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        GridCompra.Table.CurrentRecord.SetValue("monto", 0)
                        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Sub TextCodigoVendedor_TextChanged(sender As Object, e As EventArgs) Handles TextCodigoVendedor.TextChanged

    End Sub

    Private Sub TextCodigoVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigoVendedor.KeyDown
        If TextCodigoVendedor.Text.Trim.Length > 0 Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                GetUsuarioUnicoSel(TextCodigoVendedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridCompra.TableControlKeyDown

        Try

            Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
            If cc.RowIndex > -1 Then
                If e.Inner.KeyCode = Keys.Up Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        If cc.RowIndex = 2 Then
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("monto"))

                            Dim pagos As Decimal = SumaPagos()

                            TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

                            If pagos > TextCompraTotal.DecimalValue Then
                                cc.Renderer.ControlText = 0
                                cc.Renderer.ControlValue = 0
                                'currenrecord.SetValue("monto", 0)
                                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
                                Exit Sub
                            End If

                            'Dim pagos As Decimal = SumaPagos()

                            'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

                            'If pagos > TextCompraTotal.DecimalValue Then
                            '    currenrecord.SetValue("monto", 0)
                            '    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            '    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
                            '    Exit Sub
                            'End If

                        Else
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("monto"))
                            Dim pagos As Decimal = SumaPagos()

                            TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

                            If pagos > TextCompraTotal.DecimalValue Then
                                cc.Renderer.ControlText = 0
                                cc.Renderer.ControlValue = 0
                                'currenrecord.SetValue("monto", 0)
                                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
                                Exit Sub
                            End If

                            'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

                            'If pagos > TextCompraTotal.DecimalValue Then
                            '    currenrecord.SetValue("monto", 0)
                            '    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            '    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
                            '    Exit Sub
                            'End If
                        End If

                    End If
                ElseIf e.Inner.KeyCode = Keys.Down Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                        If style IsNot Nothing Then
                            ' Dim rows = dgvCompra.Table.Records.Count
                            If style.TableCellIdentity IsNot Nothing Then
                                Dim currenrecord = style.TableCellIdentity.DisplayElement.GetRecord()
                                If currenrecord IsNot Nothing Then
                                    Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("monto"))

                                    'currenrecord.SetValue("monto", 0)

                                    Dim pagos As Decimal = SumaPagos()

                                    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

                                    If pagos > TextCompraTotal.DecimalValue Then
                                        cc.Renderer.ControlText = 0
                                        cc.Renderer.ControlValue = 0
                                        'currenrecord.SetValue("monto", 0)
                                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
                                        Exit Sub
                                    End If
                                End If
                            End If

                        End If

                    End If

                Else
                    cc.ConfirmChanges()
                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                    Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("monto"))
                    Dim pagos As Decimal = SumaPagos()

                    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

                    If pagos > TextCompraTotal.DecimalValue Then
                        cc.Renderer.ControlText = 0
                        cc.Renderer.ControlValue = 0
                        'currenrecord.SetValue("monto", 0)
                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
                        Exit Sub
                    End If


                    'Dim pagos As Decimal = SumaPagos()

                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

                    'If pagos > TextCompraTotal.DecimalValue Then

                    '    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    '    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
                    '    Exit Sub
                    'End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Try

        '    Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        '    If cc.RowIndex > -1 Then
        '        If e.Inner.KeyCode = Keys.Up Then
        '            If cc IsNot Nothing Then
        '                cc.ConfirmChanges()
        '                If cc.RowIndex = 3 Then
        '                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()

        '                    'dfgdfgdfgdfg
        '                    Dim pagos As Decimal = SumaPagos()

        '                    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '                    If pagos > TextCompraTotal.DecimalValue Then
        '                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                        GridCompra.Table.CurrentRecord.SetValue("monto", 0)


        '                        currenrecord.SetValue("monto", 0)


        '                        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                        Exit Sub
        '                    End If

        '                End If

        '            End If
        '        ElseIf e.Inner.KeyCode = Keys.Down Then


        '            If cc IsNot Nothing Then
        '                cc.ConfirmChanges()
        '                Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex + 1, cc.ColIndex), GridTableCellStyleInfo)


        '                Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()

        '                If style IsNot Nothing Then
        '                    ' Dim rows = dgvCompra.Table.Records.Count
        '                    If style.TableCellIdentity IsNot Nothing Then
        '                        'Dim currenrecord = style.TableCellIdentity.DisplayElement.GetRecord()
        '                        'If currenrecord IsNot Nothing Then
        '                        '    Dim monto As Integer = Integer.Parse(currenrecord.GetValue("monto"))

        '                        'End If
        '                        'dfgdfgdfgdfg
        '                        Dim pagos As Decimal = SumaPagos()

        '                        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '                        If pagos > TextCompraTotal.DecimalValue Then

        '                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            GridCompra.Table.CurrentRecord.SetValue("monto", 0)
        '                            currenrecord.SetValue("monto", 0)
        '                            TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                            Exit Sub
        '                        End If

        '                    End If

        '                End If

        '            End If

        '        Else
        '            cc.ConfirmChanges()
        '            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()


        '            'dfgdfgdfgdfg
        '            Dim pagos As Decimal = SumaPagos()

        '            TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '            If pagos > TextCompraTotal.DecimalValue Then
        '                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                GridCompra.Table.CurrentRecord.SetValue("monto", 0)
        '                TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                Exit Sub
        '            End If

        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try



    End Sub
#End Region

End Class
