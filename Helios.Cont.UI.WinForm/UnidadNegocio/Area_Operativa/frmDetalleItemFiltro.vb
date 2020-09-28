Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports PopupControl
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmDetalleItemFiltro


#Region "Attributes"
    'Public Property UC_AreaOperativa As Tab_AreaOperativa
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.WindowState = FormWindowState.Normal
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvExistencias, False, 11.0F)

    End Sub

    'Public Sub New(tab_AreaOperativa As Tab_AreaOperativa)
    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    Me.WindowState = FormWindowState.Normal
    '    ' Add any initialization after the InitializeComponent() call.
    '    FormatoGridPequeño(dgvExistencias, False, 11.0F)

    '    UC_AreaOperativa = tab_AreaOperativa

    'End Sub
#End Region

    Private Sub GetProductosContains(textoFilter As String)
        Try

            Dim itemSA As New detalleitemsSA
            Dim lista = itemSA.GetExistenciasByEstablecimiento(GEstableciento.IdEstablecimiento).Where(Function(o) o.descripcionItem.Contains(textoFilter)).Where(Function(O) O.tipoExistencia <> "03").ToList

            Dim dt As New DataTable
            dt.Columns.Add("ID")
            dt.Columns.Add("descripcionComposicion")
            dt.Columns.Add("boton")

            For Each i In lista
                dt.Rows.Add(i.codigodetalle, i.descripcionItem, "")
            Next

            dgvExistencias.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub LoadCanastaVentas(lista As List(Of composicion))
        Try

            Dim dt As New DataTable
            Dim detalleItemsSA As New detalleitemsSA
            Dim listaDetalleItems As New List(Of detalleitems)


            dt.Columns.Add("ID")
            dt.Columns.Add("descripcionComposicion")
            dt.Columns.Add("boton")

            listaDetalleItems = detalleItemsSA.GetProductosWithEquivalenciasEstablecimiento(New detalleitems With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento}).Where(Function(O) O.tipoExistencia <> "03").ToList

            dgvExistencias.Table.Records.DeleteAll()

            For Each i In listaDetalleItems

                dt.Rows.Add(i.codigodetalle,
                            i.descripcionItem,
                                    "")

            Next
            dgvExistencias.DataSource = dt
            dgvExistencias.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvExistencias_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvExistencias.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 3 Then
                Dim style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                Dim Record = style.TableCellIdentity.DisplayElement.GetRecord()

                'Dim equivalencia = GridTotales.TableModel(e.Inner.RowIndex, 6).CellValue

                Dim idProducto = dgvExistencias.TableModel(e.Inner.RowIndex, 1).CellValue

                'UC_AreaOperativa.AgregarProductoDetalleVenta(idProducto)

                MessageBox.Show("SE AGREGO EL PRODUCTO AL ÁREA OPERATIVA")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvExistencias_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvExistencias.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 3 Then
                e.Inner.Style.Description = "AGREGAR"
                e.Inner.Style.TextColor = Color.Black

                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                              )
                'e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If

        End If
    End Sub

    Private Sub TextFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles TextFiltrar.KeyDown
        Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If TextFiltrar.Text.Trim.Length > 2 Then
                    e.SuppressKeyPress = True

                    GetProductosContains(TextFiltrar.Text.Trim)

                Else
                    TextFiltrar.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub
End Class