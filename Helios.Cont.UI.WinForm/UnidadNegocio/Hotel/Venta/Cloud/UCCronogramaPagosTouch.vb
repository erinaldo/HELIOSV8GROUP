Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCCronogramaPagosTouch

    Public Property FormVenta As FormVentaNuevaTouch

    Public Property ListaCronograma As List(Of Cronograma)

    Public Sub New(FormVentaMaster As FormVentaNuevaTouch)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormVenta = FormVentaMaster
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        OrdenamientoGrid(GridCompra, False)
    End Sub

    Private Sub MappingColumnGrid()
        Dim dt As New DataTable
        dt.Columns.Add("nroCuota")
        dt.Columns.Add("fechaOper")
        dt.Columns.Add("fechaPago")
        dt.Columns.Add("importe")
        dt.Columns.Add("estado", GetType(Boolean))

        For Each i In ListaCronograma
            dt.Rows.Add(i.nrocuota, i.fechaoperacion, "", i.montoAutorizadoMN, i.GetBoolEstado)
        Next
        GridCompra.DataSource = dt

        Dim sumaCuotas = ListaCronograma.Sum(Function(o) o.montoAutorizadoMN).GetValueOrDefault
        Dim saldo = TextImporte.DecimalValue - sumaCuotas
        If saldo < 0 Then
            saldo = saldo * -1
            Dim balance As Decimal = GridCompra.Table.Records(GridCompra.Table.Records.Count - 1).GetValue("importe")
            balance = balance - saldo
            GridCompra.Table.Records(GridCompra.Table.Records.Count - 1).SetValue("importe", balance)
        ElseIf saldo > 0 Then
            Dim balance As Decimal = GridCompra.Table.Records(GridCompra.Table.Records.Count - 1).GetValue("importe")
            balance = balance + saldo
            GridCompra.Table.Records(GridCompra.Table.Records.Count - 1).SetValue("importe", balance)
        End If
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        CalcularCuotas()
    End Sub

    Private Sub CalcularCuotas()
        ListaCronograma = New List(Of Cronograma)
        Dim ValorCuota = Math.Round(TextImporte.DecimalValue / NumCuotas.Value, 2)
        Dim i As Integer = 1
        For index = 0 To NumCuotas.Value - 1
            AddCuotaGrid(i, ValorCuota)
            i = i + 1
        Next
        MappingColumnGrid()
    End Sub

    Private Sub AddCuotaGrid(nroCuota As Integer, valorCuota As Decimal)
        ListaCronograma.Add(New Business.Entity.Cronograma With
                       {
                       .nrocuota = nroCuota,
                       .fechaoperacion = Date.Now,
                       .montoAutorizadoMN = valorCuota,
                       .estado = "0"
                       })
    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

    End Sub

    Private Sub GridCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellChanged
        If ListaCronograma IsNot Nothing Then
            Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
            cc.ConfirmChanges()
            If cc.Renderer IsNot Nothing Then

                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                    If style.TableCellIdentity.Column.Name = "fechaPago" Or style.TableCellIdentity.Column.Name = "importe" Then
                        If cc.Renderer IsNot Nothing Then

                            If e.TableControl.Model.Modified = True Then
                                Dim text As String = cc.Renderer.ControlText

                                If text.Trim.Length > 0 Then
                                    If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                        EditarItem(GridCompra.Table.CurrentRecord)
                                    End If
                                    'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.GridCompra.TableModel(RowIndex, 5).CellValue
            Select Case valCheck
                Case "False" 'TRUE
                    EditarItem(RowIndex, "1")
                    'MessageBox.Show(True)
                Case Else ' FALSE
                    EditarItem(RowIndex, "0")
                    'MessageBox.Show(False)
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EditarItem(currentRecord As Record)
        Dim cronograma = ListaCronograma.Where(Function(o) o.nrocuota = currentRecord.GetValue("nroCuota")).SingleOrDefault
        If cronograma IsNot Nothing Then
            If (IsDate(currentRecord.GetValue("fechaPago"))) Then
                cronograma.fechaPago = DateTime.Parse(currentRecord.GetValue("fechaPago"))
            End If
            cronograma.montoAutorizadoMN = Decimal.Parse(currentRecord.GetValue("importe"))
        End If
    End Sub

    Private Sub EditarItem(RowIndex As Integer, value As String)
        If RowIndex <> -1 Then
            Dim cronograma = ListaCronograma.Where(Function(o) o.nrocuota = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
            If cronograma IsNot Nothing Then
                cronograma.estado = value
            End If
        End If
    End Sub
End Class
