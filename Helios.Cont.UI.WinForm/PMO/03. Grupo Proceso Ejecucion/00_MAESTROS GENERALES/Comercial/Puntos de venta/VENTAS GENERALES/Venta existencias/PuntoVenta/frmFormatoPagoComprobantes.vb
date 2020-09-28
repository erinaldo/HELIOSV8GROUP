Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmFormatoPagoComprobantes

    Public cuentasSA As New EstadosFinancierosSA
    Public listaCajas As List(Of estadosFinancieros)
    Public listaPagos As List(Of documentoCaja)
    Public Property cajaUsuarioSA As New cajaUsuarioSA

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCuentas, False, False)
        GetMappingColumnsGrid()
        listaCajas = New List(Of estadosFinancieros)
        listaPagos = New List(Of documentoCaja)

        For Each i In cajaUsuarioSA.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = GFichaUsuarios.IdCajaUsuario, .idPersona = usuario.IDUsuario})
            listaCajas.Add(New estadosFinancieros With {.idestado = i.identidad, .descripcion = i.nombreentidad, .tipo = i.tipo, .codigo = i.moneda})
        Next
        '        listaCajas = cuentasSA.ObtenerEstadosFinancierosPorEstablecimiento(0, Gempresas.IdEmpresaRuc)
        cboCajas.Enabled = True
        CboFormaPago.Enabled = True
        ChEfectivo.Checked = True
        PagosLoading()
    End Sub

    Private Sub GetMappingColumnsGrid()
        Dim dt As New DataTable

        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
        End With
        dgvCuentas.DataSource = dt
    End Sub

    Private Sub ChEfectivo_OnChange(sender As Object, e As EventArgs) Handles ChEfectivo.OnChange
        PagosLoading()
    End Sub

    Private Sub PagosLoading()
        If ChEfectivo.Checked = True AndAlso ChBanco.Checked = True Then
            Dim lista = listaCajas.ToList
            GetComboCuentas(lista)
        ElseIf ChEfectivo.Checked = True AndAlso ChBanco.Checked = False Then
            Dim lista = listaCajas.Where(Function(o) o.tipo = "EF").ToList
            GetComboCuentas(lista)
        ElseIf ChEfectivo.Checked = False AndAlso ChBanco.Checked = True Then
            Dim lista = listaCajas.Where(Function(o) o.tipo <> "EF").ToList
            GetComboCuentas(lista)
        End If
    End Sub

    Private Sub GetComboCuentas(listaCajas As List(Of estadosFinancieros))

        cboCajas.DataSource = listaCajas
        cboCajas.DisplayMember = "descripcion"
        cboCajas.ValueMember = "idestado"
    End Sub

    Private Sub ChBanco_OnChange(sender As Object, e As EventArgs) Handles ChBanco.OnChange
        PagosLoading()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Try
            ValidaCajaDuplicada()
            AgregarCaja()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validar cajas")
        End Try
    End Sub

    Private Sub ValidaCajaDuplicada()
        For Each i In dgvCuentas.Table.Records
            If Integer.Parse(i.GetValue("identidad")) = cboCajas.SelectedValue Then
                Throw New Exception("No puede agregar la caja seleccionada, ya está agregada.")
            End If
        Next
    End Sub

    Private Sub AgregarCaja()

        Dim prompt As String = String.Empty
        Dim title As String = String.Empty
        Dim defaultResponse As String = 0

        Dim answer As Object

        Dim pagosAcum As Decimal = SumaPagos()
        Dim saldo As Decimal = CDec(txtMontoXcobrar.Text) - pagosAcum

        prompt = "Importe por pagar: " & saldo.ToString("N2")
        title = "X Pagar"
        defaultResponse = 0

        answer = InputBox(prompt, title, defaultResponse)

        If answer.ToString.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar un importe válido", "Validar pago", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btOperacion.Select()
            Exit Sub
        End If
        If IsNumeric(answer) Then
            Dim caja = cuentasSA.GetUbicar_estadosFinancierosPorID(cboCajas.SelectedValue)

            Me.dgvCuentas.Table.AddNewRecord.SetCurrent()
            Me.dgvCuentas.Table.AddNewRecord.BeginEdit()
            Me.dgvCuentas.Table.CurrentRecord.SetValue("tipo", caja.tipo)
            Me.dgvCuentas.Table.CurrentRecord.SetValue("identidad", caja.idestado)
            Me.dgvCuentas.Table.CurrentRecord.SetValue("entidad", caja.descripcion)
            Me.dgvCuentas.Table.CurrentRecord.SetValue("abonado", CDec(answer))
            Me.dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", 1.0)
            Me.dgvCuentas.Table.CurrentRecord.SetValue("idforma", CboFormaPago.SelectedValue)
            Me.dgvCuentas.Table.CurrentRecord.SetValue("formaPago", CboFormaPago.Text)
            Me.dgvCuentas.Table.AddNewRecord.EndEdit()
            dgvCuentas.Table.TableDirty = True

            Dim pagos As Decimal = SumaPagos()
            If pagos > CDec(txtMontoXcobrar.Text) Then
                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If dgvCuentas.Table.CurrentRecord IsNot Nothing Then
                    dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                Else
                    dgvCuentas.Table.Records(dgvCuentas.Table.Records.Count - 1).Delete()
                End If
                Exit Sub
            End If
        Else
            MessageBox.Show("Debe ingresar un importe válido", "Validar pago", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btOperacion.Select()
            Exit Sub
        End If

    End Sub

    Private Sub dgvCuentas_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvCuentas.TableControlCellClick

    End Sub

    Private Sub dgvCuentas_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCuentas.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            Select Case ColIndex
                Case 3
                    Dim pagos As Decimal = SumaPagos()
                    If pagos > CDec(txtMontoXcobrar.Text) Then
                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Function SumaPagos() As Decimal
        SumaPagos = 0
        For Each i In dgvCuentas.Table.Records
            If i.GetValue("abonado") <= 0 Then
                Throw New Exception("El monto abonado debe sre mayor a cero")
            End If
            SumaPagos += CDec(i.GetValue("abonado"))
        Next
        Return SumaPagos
    End Function

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Try
            Dim pagos As Decimal = SumaPagos()
            If pagos > CDec(txtMontoXcobrar.Text) Then
                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf pagos <= 0 Then
                MessageBox.Show("El pago debe ser mayor cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If pagos < CDec(txtMontoXcobrar.Text) Then
                If MessageBox.Show("El pago realizado es menor a la venta total, desea continuar ?", "Verificar pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    listaPagos = GetPagos()
                    Tag = listaPagos
                    Close()
                Else
                    Exit Sub
                End If
            ElseIf pagos = CDec(txtMontoXcobrar.Text) Then
                listaPagos = GetPagos()
                Tag = listaPagos
                Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Validar importe")
        End Try
    End Sub

    Private Function GetPagos() As List(Of documentoCaja)
        GetPagos = New List(Of documentoCaja)
        For Each r As Record In dgvCuentas.Table.Records
            If CDec(r.GetValue("abonado")) <= 0 Then
                Throw New Exception("Debe indicar un importe mayor a cero")
            End If

            GetPagos.Add(New documentoCaja With
                         {
                            .IdEntidadFinanciera = Integer.Parse(r.GetValue("identidad").ToString()),
                            .NomCajaOrigen = r.GetValue("entidad"),
                            .montoSoles = Decimal.Parse(r.GetValue("abonado")),
                            .formapago = r.GetValue("idforma")
                         })
        Next
    End Function

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If dgvCuentas.Table.CurrentRecord IsNot Nothing Then
            dgvCuentas.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub cboCajas_Click(sender As Object, e As EventArgs) Handles cboCajas.Click

    End Sub

    Private Sub cboCajas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCajas.SelectedValueChanged
        Dim codigo As Object
        codigo = cboCajas.SelectedValue
        If IsNumeric(codigo) Then
            GetFillComboFormaPago(codigo)
        End If
    End Sub

    Private Sub GetFillComboFormaPago(codigo As Integer)
        Dim entidadSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(codigo)
        Select Case ef.tipo
            Case "BC", "TC"
                Dim tablas() As String = {"001", "003", "005", "006", "007", "011", "102", "111"}
                CboFormaPago.DataSource = tablaSA.GetListaTablaDetalle(1, "1").Where(Function(o) tablas.Contains(o.codigoDetalle)).ToList
                CboFormaPago.DisplayMember = "descripcion"
                CboFormaPago.ValueMember = "codigoDetalle"
                CboFormaPago.SelectedValue = "001"
            Case "EF"
                Dim tablas() As String = {"004", "008", "009", "109", "9903"}
                CboFormaPago.DataSource = tablaSA.GetListaTablaDetalle(1, "1").Where(Function(o) tablas.Contains(o.codigoDetalle)).ToList
                CboFormaPago.DisplayMember = "descripcion"
                CboFormaPago.ValueMember = "codigoDetalle"
                CboFormaPago.SelectedValue = "109"
        End Select
    End Sub

End Class