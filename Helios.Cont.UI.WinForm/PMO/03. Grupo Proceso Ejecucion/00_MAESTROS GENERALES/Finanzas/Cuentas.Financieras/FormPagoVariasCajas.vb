Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormPagoVariasCajas
    Public listaPagos As List(Of documentoCaja)
#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridPagos, False, False, 11.0F)
        GetDataPays()
    End Sub
#End Region

#Region "Methods"

    Private Function GetPagos() As List(Of documentoCaja)
        GetPagos = New List(Of documentoCaja)
        For Each r As Record In GridPagos.Table.Records
            'If CDec(r.GetValue("importe")) <= 0 Then
            '    Throw New Exception("Debe indicar un importe mayor a cero")
            'End If

            If CDec(r.GetValue("importe")) > 0 Then
                GetPagos.Add(New documentoCaja With
                         {
                            .IdEntidadFinanciera = Integer.Parse(r.GetValue("identidad").ToString()),
                            .NomCajaOrigen = r.GetValue("entidad"),
                            .montoSoles = Decimal.Parse(r.GetValue("importe")),
                            .formapago = r.GetValue("idforma")
                         })
            End If
        Next
    End Function

    Sub GetDataPays()
        Dim dt As New DataTable
        dt.Columns.Add("idforma")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("identidad")
        dt.Columns.Add("entidad")
        dt.Columns.Add("codigocontable")
        dt.Columns.Add("importe")

        For Each i In ListConfigurationPays
            dt.Rows.Add(i.IDFormaPago, i.FormaPago, i.identidad, i.entidad, String.Empty, 0)
        Next
        'Dim efectivo = ListConfigurationPays.Where(Function(o) o.tipo = "EF").SingleOrDefault

        'If efectivo IsNot Nothing Then
        '    dt.Rows.Add("EFECTIVO", efectivo.identidad, efectivo.entidad, String.Empty, 0)
        'Else
        '    'dt.Rows.Add("EFECTIVO", 0, String.Empty, String.Empty, 0)
        'End If

        'dt.Rows.Add("DEPOSITO", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("TARJETA", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("CHEQUE", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("VALE", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("COMPENSACION", 0, String.Empty, String.Empty, 0)

        GridPagos.DataSource = dt
    End Sub

    Private Function SumaPagos() As Decimal
        SumaPagos = 0
        For Each i In GridPagos.Table.Records
            'If i.GetValue("importe") <= 0 Then
            '    Throw New Exception("El monto abonado debe sre mayor a cero")
            'End If
            SumaPagos += CDec(i.GetValue("importe"))
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

                    If listaPagos.Count = 0 Then
                        MessageBox.Show("Debe realizar al menos un pago", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Tag = listaPagos
                    Close()
                Else
                    Exit Sub
                End If
            ElseIf pagos = CDec(txtMontoXcobrar.Text) Then
                listaPagos = GetPagos()
                If listaPagos.Count = 0 Then
                    MessageBox.Show("Debe realizar al menos un pago", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                Tag = listaPagos
                Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Validar importe")
        End Try
    End Sub

    Private Sub GridPagos_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridPagos.TableControlCellClick

    End Sub

    Private Sub GridPagos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridPagos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            Select Case ColIndex
                Case 3
                    Dim pagos As Decimal = SumaPagos()
                    If pagos > CDec(txtMontoXcobrar.Text) Then
                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        GridPagos.Table.CurrentRecord.SetValue("importe", 0)
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub
#End Region

End Class