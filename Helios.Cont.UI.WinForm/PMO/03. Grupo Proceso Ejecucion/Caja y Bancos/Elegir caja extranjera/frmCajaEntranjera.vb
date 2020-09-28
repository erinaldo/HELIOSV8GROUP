Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmCajaEntranjera
    Inherits frmMaster

    Public Property ListadoPagos As New List(Of movimientocajaextranjera)
    Public ReadOnly Property _Compra As documentocompra

    Public Sub New(be As estadosFinancieros)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ListadoPagos = New List(Of movimientocajaextranjera)
        GridCFG(dgvPagos)
        GetCajasHabilitadas(be)
        txtTipoCambio.DoubleValue = TmpTipoCambioTransaccionVenta

    End Sub

    Public Sub New(be As estadosFinancieros, compra As documentocompra)

        ' This call is required by the designer.
        _Compra = compra
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ListadoPagos = New List(Of movimientocajaextranjera)
        GridCFG(dgvPagos)
        GetCajasHabilitadas(be)
        txtTipoCambio.DoubleValue = TmpTipoCambioTransaccionVenta

        TextMonedaObligacion.Text = If(_Compra.monedaDoc = "1", "SOLES", "MON.EXTRANJERA")
    End Sub

#Region "Métodos"
    Public Sub GetCleanPagos()
        For Each r As Record In dgvPagos.Table.Records
            r.SetValue("pago", 0)
        Next

    End Sub


    Public Sub GetPagosGrid(value As Decimal)
        If value > 0 Then

            For Each r As Record In dgvPagos.Table.Records

                Dim valTrue = Convert.ToBoolean(r.GetValue("confirmar"))

                If valTrue = True Then
                    Dim valSaldo As Decimal = 0
                    If value <= 0 Then
                        Return
                    End If

                    Dim val1 = Convert.ToDecimal(r.GetValue("saldo"))


                    If value > val1 Then
                        valSaldo = value - val1
                        r.SetValue("pago", val1)
                    Else
                        valSaldo = value - val1
                        r.SetValue("pago", value)
                    End If

                    value = valSaldo
                End If
            Next
        End If
    End Sub


    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False
        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left
        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub GetCajasHabilitadas(be As estadosFinancieros)
        Dim cajaSA As New DocumentoCajaSA
        Dim dt As New DataTable

        dt.Columns.Add("iddocumento")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("tipocambio")
        dt.Columns.Add("monto")
        dt.Columns.Add("desembolso")
        dt.Columns.Add("saldo")
        dt.Columns.Add("pago")
        dt.Columns.Add("confirmar", GetType(Boolean))

        For Each i In cajaSA.GetSaldosCajaEntranjera(be)
            Select Case i.moneda
                Case "1"
                    dt.Rows.Add(i.idDocumento, i.fechaProceso, i.tipoCambio.GetValueOrDefault, CDec(i.montoSoles).ToString("N2"), CDec(i.ImporteDesembolsado).ToString("N2"), CDec(i.montoSoles - i.ImporteDesembolsado).ToString("N2"), 0, True)
                Case "2"
                    dt.Rows.Add(i.idDocumento, i.fechaProceso, i.tipoCambio.GetValueOrDefault, CDec(i.montoUsd).ToString("N2"), CDec(i.ImporteDesembolsado).ToString("N2"), CDec(i.montoUsd - i.ImporteDesembolsado).ToString("N2"), 0, True)
            End Select
        Next
        dgvPagos.DataSource = dt
        TxtMontoDesembolso.MaxValue = SaldoCuenta()
    End Sub
#End Region

    Private Sub frmCajaEntranjera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtMontoDesembolso.Select()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Dim n As New RecuperarCarteras
        datos.Clear()
        Dim obj As New movimientocajaextranjera
        For Each i As Record In dgvPagos.Table.Records
            If CDec(i.GetValue("pago")) > 0 Then
                obj = New movimientocajaextranjera
                obj.idDocumento = Val(i.GetValue("iddocumento"))
                obj.identidad = txtCuenta.Tag
                obj.fecha = DateTime.Now
                obj.tipomovimiento = StatusCajaExtranjera.pago

                If cboPago.Text = "NACIONAL" Then
                    obj.moneda = 1
                Else
                    obj.moneda = 2
                End If

                obj.tipocambioorigen = CDec(i.GetValue("tipocambio"))
                obj.tipocambio = txtTipoCambio.DoubleValue
                Select Case _Compra.monedaDoc
                    Case "1"
                        obj.importe = CDec(i.GetValue("pago"))
                        obj.Importe2 = txtMontoconvertido.DoubleValue
                    Case "2"
                        obj.importe = CDec(i.GetValue("pago"))
                        obj.Importe2 = txtMontoconvertido.DoubleValue
                End Select


                obj.Desembolso = TxtMontoDesembolso.DoubleValue
                obj.usuarioActualizacion = usuario.IDUsuario
                obj.fechaActualizacion = DateTime.Now
                ListadoPagos.Add(obj)
            End If
        Next

        'n = New RecuperarCarteras
        'n.TasaIva = txtTipoCambio.DoubleValue
        'If cboPago.Text = "NACIONAL" Then
        '    n.Montomn = TxtMontoDesembolso.DoubleValue
        '    n.Montome = txtMontoconvertido.DoubleValue
        'Else
        '    n.Montomn = txtMontoconvertido.DoubleValue
        '    n.Montome = TxtMontoDesembolso.DoubleValue
        'End If
        'datos.Add(n)
        Me.Tag = ListadoPagos
        Close()
        'Else
        '    MessageBox.Show("Debe ingrear pagos a la canasta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Function SaldoCuenta() As Decimal
        Dim suma As Decimal = 0
        For Each i In dgvPagos.Table.Records
            suma += CDec(i.GetValue("saldo"))
        Next
        Return suma
    End Function

    Private Sub TxtMontoDesembolso_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMontoDesembolso.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            GetCalculoDesembolso()
        End If

    End Sub

    Private Sub GetCalculoDesembolso()
        Try
            GetCleanPagos()

            Select Case _Compra.monedaDoc
                Case "1"
                    If cboPago.Text = "NACIONAL" Then
                        If TxtMontoDesembolso.DoubleValue > 0 Then
                            txtMontoconvertido.DoubleValue = 0
                            If _Compra.monedaDoc = "1" Then
                                GetPagosGrid(TxtMontoDesembolso.DoubleValue)
                            Else
                                GetPagosGrid(txtMontoconvertido.DoubleValue)
                            End If
                        End If
                        'txtMontoconvertido.DoubleValue = TxtMontoDesembolso.DoubleValue / txtTipoCambio.DoubleValue
                    Else
                        If TxtMontoDesembolso.DoubleValue > 0 Then
                            txtMontoconvertido.DoubleValue = TxtMontoDesembolso.DoubleValue * txtTipoCambio.DoubleValue
                            GetPagosGrid(TxtMontoDesembolso.DoubleValue)
                        Else
                            txtMontoconvertido.DoubleValue = 0
                        End If

                    End If
                Case "2"
                    If cboPago.Text = "NACIONAL" Then
                        If TxtMontoDesembolso.DoubleValue > 0 Then
                            txtMontoconvertido.DoubleValue = TxtMontoDesembolso.DoubleValue / txtTipoCambio.DoubleValue
                            If _Compra.monedaDoc = "1" Then
                                GetPagosGrid(TxtMontoDesembolso.DoubleValue)
                            Else
                                GetPagosGrid(txtMontoconvertido.DoubleValue)
                            End If
                        End If
                        'txtMontoconvertido.DoubleValue = TxtMontoDesembolso.DoubleValue / txtTipoCambio.DoubleValue
                    Else
                        If TxtMontoDesembolso.DoubleValue > 0 Then
                            txtMontoconvertido.DoubleValue = TxtMontoDesembolso.DoubleValue * txtTipoCambio.DoubleValue
                            GetPagosGrid(TxtMontoDesembolso.DoubleValue)
                        Else
                            txtMontoconvertido.DoubleValue = 0
                        End If

                    End If
            End Select


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtMontoDesembolso_TextChanged(sender As Object, e As EventArgs) Handles TxtMontoDesembolso.TextChanged
        GetCalculoDesembolso()
    End Sub

    Private Sub TxtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged
        GetCalculoDesembolso()
    End Sub
End Class