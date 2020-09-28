Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class formLotesSinVerificar
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' FormatoGridAvanzado(GridGroupingControl1, False, False, 9.0F, SelectionMode.None)
        GridGroupingControl1.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        GridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GridGroupingControl1.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        GridGroupingControl1.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GridGroupingControl1.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GetLotesSinVerificar()
    End Sub

    Private Sub GetLotesSinVerificar()
        Dim loteSA As New recursoCostoLoteSA
        Dim dt As New DataTable
        dt.Columns.Add("codigolote")
        dt.Columns.Add("NroLote")
        dt.Columns.Add("fechaCompra")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("nrocompra")
        dt.Columns.Add("cantidadtotal")
        dt.Columns.Add("obj", GetType(recursoCostoLote))
        dt.Columns.Add("btConfirmar")

        Dim lista = loteSA.GetLotesSelVerificacion(New Business.Entity.recursoCostoLote() With {.verificado = False})
        For Each i In lista
            dt.Rows.Add(i.codigoLote, i.nroLote, i.CustomCompra.fechaDoc, i.CustomCompra.tipoDoc, $"{i.CustomCompra.serie}-{i.CustomCompra.numeroDoc}", i.cantidad, i)
        Next
        GridGroupingControl1.DataSource = dt

    End Sub

    Private Sub GridPrecios_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridGroupingControl1.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 7 Then
                e.Inner.Style.Description = "Configurar"
                e.Inner.Style.TextColor = Color.White
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridPrecios_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridGroupingControl1.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Try
            If e.Inner.ColIndex = 7 Then
                Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                Dim record = sty.TableCellIdentity.DisplayElement.GetRecord()
                If record IsNot Nothing Then
                    Dim var = record.GetValue("obj")
                    Dim lote = CType(var, recursoCostoLote)
                    Dim f As New FormRecursoCostoLoteTalla(lote)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If (f.Tag = "Grabado") Then
                        GetLotesSinVerificar()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCellClick

    End Sub
End Class