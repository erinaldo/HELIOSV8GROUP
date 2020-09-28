Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class Tab_GestionSubCategoria

#Region "Attributes"
    Dim listaItem As New List(Of item)
    Dim PadreID As Integer = 0
    Public Property TipoManejo As Boolean
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
                Dim itemSA As New itemSA
                Dim itemBE As New item

                Dim style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                Dim Record = style.TableCellIdentity.DisplayElement.GetRecord()

                itemBE.idItem = Record.GetValue("ID")

                Dim tipo = itemSA.DeleteCategoriaSL(itemBE)

                Select Case tipo
                    Case True
                        MessageBox.Show("No puede eliminar, esta anexado a productos")
                    Case False
                        Dim consulta = listaItem.Where(Function(o) o.tipo = "M" And o.idPadre = PadreID).ToList
                        GetDocumentoVentaID(consulta)
                End Select

            ElseIf e.Inner.ColIndex = 5 Then
                Dim itemSA As New itemSA
                Dim f As New frmNuevaMarca
                Dim style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                Dim Record = style.TableCellIdentity.DisplayElement.GetRecord()
                'f.MANIPULACION = ENTITY_ACTIONS.UPDATE
                'f.ItemID = Record.GetValue("ID")
                f.txtDescripcion.Text = Record.GetValue("descripcion")
                f.txtCodigo.Tag = PadreID
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc).ToList
                Dim consulta = listaItem.Where(Function(o) o.tipo = "M").ToList
                GetDocumentoVentaID(consulta)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Metodos"

    Public Sub CargarCategorias()
        Dim itemBE As New item
        Dim itemSA As New itemSA

        flowCategoria.Visible = False
        dgvPedidoDetalle.Table.Records.DeleteAll()
        Label1.Text = "Sub Categoria"

        itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc).ToList

        dibujarCategorias(listaItem)

    End Sub

    Public Sub CargarSubCategoria()
        Try
            Dim itemBE As New item
            Dim itemSA As New itemSA

            itemBE.idEmpresa = Gempresas.IdEmpresaRuc
            itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento

            pnContenedorCategoria.Enabled = False
            dgvPedidoDetalle.Table.Records.DeleteAll()

            listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc).ToList

            Dim consulta = (listaItem.Where(Function(o) o.tipo = "M")).ToList

            GetDocumentoVentaID(consulta)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub dibujarCategorias(listDistr As List(Of item))

        flowCategoria.Controls.Clear()
        flowCategoria.Visible = True


        Label20.Text = "Categoria"

        Dim consulta = (listDistr.Where(Function(o) o.tipo = "C")).ToList

        For Each items In consulta
            Dim b As New RoundButton2
            b.BackColor = System.Drawing.Color.DarkSlateGray
            b.Text = items.descripcion
            b.Name = items.idItem
            b.FlatStyle = FlatStyle.Standard
            b.TabIndex = items.idItem
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            b.ForeColor = System.Drawing.Color.White
            If (items.descripcion.Length >= 10) Then
                b.Size = New System.Drawing.Size(130, 40)
            Else
                b.Size = New System.Drawing.Size(130, 40)
            End If
            b.Tag = items
            b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            b.UseVisualStyleBackColor = False

            flowCategoria.Controls.Add(b)

            AddHandler b.Click, AddressOf Butto1

        Next
    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Try
            'flowCategoria.Visible = False
            dgvPedidoDetalle.Table.Records.DeleteAll()

            Dim c = CType(sender.Tag, item)
            Label1.Text = c.descripcion
            Label1.Tag = c.idItem
            PadreID = c.idItem
            Dim consulta = (listaItem.Where(Function(o) o.tipo = "M" And o.idPadre = c.idItem)).ToList

            GetDocumentoVentaID(consulta)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub GetDocumentoVentaID(consulta As List(Of item))
        Dim dt As New DataTable
        Dim itemSA As New itemSA
        Dim itemBE As New item
        Dim listaCategoria As New List(Of item)

        itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        itemBE.tipo = "M"

        'listaCategoria = itemSA.GetListaItemsPorTipo(itemBE)

        dgvPedidoDetalle.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("descripcion")
            .Add("estado")
            .Add("eliminar")
            .Add("actualizar")
            .Add("inhabilitar")
        End With

        For Each i In consulta

            dt.Rows.Add(i.idItem,
                    i.descripcion,
                    "HABILITADO",
                    "", "",
                    False)

        Next
        dgvPedidoDetalle.DataSource = dt

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try
            If (Label1.Tag > 0) Then
                Dim itemBE As New item
                Dim itemSA As New itemSA

                Dim f As New frmNuevaMarca
                'f.MANIPULACION = ENTITY_ACTIONS.INSERT
                f.txtCodigo.Tag = PadreID
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc).ToList
                Dim consulta = listaItem.Where(Function(o) o.tipo = "M" And o.idPadre = PadreID).ToList
                GetDocumentoVentaID(consulta)
            Else
                MessageBox.Show("Debe Seleccionar una categoria")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Select Case TipoManejo
            Case True
                CargarCategorias()
            Case False
                CargarSubCategoria()
        End Select

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Select Case TipoManejo
            Case True
                Dim f As New frmNuevaClasificacion
                'f.MANIPULACION = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                CargarCategorias()
            Case False
                Dim f As New frmNuevaMarca
                'f.MANIPULACION = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                CargarSubCategoria()
        End Select

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            Select Case TipoManejo
                Case True
                    If (Label1.Tag > 0) Then
                        Dim itemBE As New item
                        Dim itemSA As New itemSA

                        Dim f As New frmNuevaMarca
                        'f.MANIPULACION = ENTITY_ACTIONS.INSERT
                        f.txtCodigo.Tag = PadreID
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()

                        listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc).ToList
                        Dim consulta = listaItem.Where(Function(o) o.tipo = "M" And o.idPadre = PadreID).ToList
                        GetDocumentoVentaID(consulta)
                    Else
                        MessageBox.Show("Debe Seleccionar una categoria")
                    End If
                Case False
                    Dim itemBE As New item
                    Dim itemSA As New itemSA

                    Dim f As New frmNuevaMarca
                    'f.MANIPULACION = ENTITY_ACTIONS.INSERT
                    f.txtCodigo.Tag = PadreID
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc).ToList
                    Dim consulta = listaItem.Where(Function(o) o.tipo = "M").ToList
                    GetDocumentoVentaID(consulta)
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"


#End Region

End Class
