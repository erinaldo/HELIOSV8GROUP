Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class Tab_GestionCategoria

#Region "Attributes"
    Public Property MANIPULACION As String
    Public Property ItemID As Integer

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        FormatoGridAvanzado(dgvPedidoDetalle, False, False)

    End Sub

    Private Sub DgvPedidoDetalle_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvPedidoDetalle.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 4 Then
                'e.Inner.Style.Description = "Eliminar"
                'e.Inner.Style.TextColor = Color.Black

                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                              )
                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)

            ElseIf e.Inner.ColIndex = 5 Then
                'e.Inner.Style.Description = "ACTUALIZAR"
                'e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(1), irect)
            End If

        End If
    End Sub

    Private Sub DgvPedidoDetalle_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvPedidoDetalle.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 4 Then

            ElseIf e.Inner.ColIndex = 5 Then
                Dim f As New frmNuevaClasificacion
                Dim style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                Dim Record = style.TableCellIdentity.DisplayElement.GetRecord()
                'f.ItemID = Record.GetValue("ID")
                f.txtDescripcion.Text = Record.GetValue("descripcion")
                'f.MANIPULACION = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GetDocumentoVentaID()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Metodos"

    Public Sub GetDocumentoVentaID()
        Dim dt As New DataTable
        Dim itemSA As New itemSA
        Dim itemBE As New item
        Dim listaCategoria As New List(Of item)

        itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        itemBE.tipo = "C"

        listaCategoria = itemSA.GetListaItemsPorTipo(itemBE)

        dgvPedidoDetalle.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("descripcion")
            .Add("estado")
            .Add("eliminar")
            .Add("actualizar")
            .Add("inhabilitar")
        End With

        For Each i In listaCategoria

            dt.Rows.Add(i.idItem,
                    i.descripcion,
                    "HABILITADO",
                    "", "",
                    False)

        Next
        dgvPedidoDetalle.DataSource = dt

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim f As New frmNuevaClasificacion
        'f.MANIPULACION = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetDocumentoVentaID()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        GetDocumentoVentaID()
    End Sub

#End Region

#Region "Events"


#End Region

End Class
