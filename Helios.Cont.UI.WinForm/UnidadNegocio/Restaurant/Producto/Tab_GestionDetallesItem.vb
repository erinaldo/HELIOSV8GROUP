Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class Tab_GestionDetallesItem

#Region "Attributes"
    Dim listaItem As New List(Of item)
    Dim PadreID As Integer = 0
    Public Property TipoManejo As Boolean

    Dim ListaProductos As New List(Of detalleitems)
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        FormatoGridAvanzado(dgvPedidoDetalle, False, False)
        FormatoGridAvanzado(dgvProductos, False, False)

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
                Dim style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                Dim Record = style.TableCellIdentity.DisplayElement.GetRecord()
                If Record IsNot Nothing Then
                    Dim f As New frmNuevaExistencia(Val(Record.GetValue("ID")))
                    f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    CargarCategorias()
                    GetDetalleItems("TODO")
                End If
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

        flowCategoria.Visible = True
        flowSubCategoria.Visible = False
        dgvPedidoDetalle.Table.Records.DeleteAll()
        'Label1.Text = "Sub Categoria"
        lblNomCategoria.Text = ""
        lblNomSubCategoria.Text = ""
        lblNomSubCategoria.Tag = Nothing
        itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc).ToList

        dibujarCategorias(listaItem)

    End Sub

    Public Sub CargarSubCategorias()
        Dim itemBE As New item
        Dim itemSA As New itemSA

        flowCategoria.Visible = False
        flowSubCategoria.Visible = True
        dgvPedidoDetalle.Table.Records.DeleteAll()
        'Label1.Text = "Sub Categoria"
        lblNomCategoria.Text = "-"
        lblNomSubCategoria.Text = ""
        lblNomSubCategoria.Tag = Nothing
        itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc).ToList

        DibujarSubCategoria(listaItem.Where(Function(o) o.tipo = "M").ToList)

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

    Sub DibujarSubCategoria(consulta As List(Of item))
        dgvPedidoDetalle.Table.Records.DeleteAll()
        flowSubCategoria.Controls.Clear()

        Label20.Text = "Categoria"
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
            'b.Image = ImageList1.Images(0)
            'b.ImageAlign = ContentAlignment.MiddleCenter
            'b.TextImageRelation = TextImageRelation.ImageAboveText
            b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            b.UseVisualStyleBackColor = False

            flowSubCategoria.Controls.Add(b)

            AddHandler b.Click, AddressOf Butto2

        Next
    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Try
            flowCategoria.Visible = False
            flowSubCategoria.Visible = True

            Dim c = CType(sender.Tag, item)
            lblNomCategoria.Text = c.descripcion
            Dim consulta = (listaItem.Where(Function(o) o.tipo = "M" And o.idPadre = c.idItem)).ToList

            DibujarSubCategoria(consulta)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Try
        '    'flowCategoria.Visible = False
        '    dgvPedidoDetalle.Table.Records.DeleteAll()

        '    Dim c = CType(sender.Tag, item)
        '    Label1.Text = c.descripcion
        '    Label1.Tag = c.idItem
        '    PadreID = c.idItem
        '    Dim consulta = (listaItem.Where(Function(o) o.tipo = "M" And o.idPadre = c.idItem)).ToList

        '    GetDocumentoVentaID(consulta)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub Butto2(sender As Object, e As EventArgs)
        Dim PRODCUTOSA As New detalleitemsSA
        Dim c = CType(sender.Tag, item)
        lblNomSubCategoria.Text = c.descripcion
        lblNomSubCategoria.Tag = c.idItem

        Dim listaProductos = PRODCUTOSA.GetProductosWithEquivalenciasXCat(New detalleitems With {.idItem = c.idItem})
        GetDocumentoVentaID(listaProductos)
    End Sub

    Private Sub cargarUpdate()
        Dim PRODCUTOSA As New detalleitemsSA
        Dim listaProductos = PRODCUTOSA.GetProductosWithEquivalenciasXCat(New detalleitems With {.idItem = lblNomSubCategoria.Tag})
        GetDocumentoVentaID(listaProductos)
    End Sub

    Sub GetDocumentoVentaID(consulta As List(Of detalleitems))
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
                    i.descripcionItem,
                    "HABILITADO",
                    "", "",
                    False)

        Next
        dgvPedidoDetalle.DataSource = dt

    End Sub

    Public Sub GetDetalleItems(tipo As String)
        Dim dt As New DataTable
        Dim itemSA As New detalleitemsSA
        Dim itemBE As New detalleitems
        Dim listaCategoria As New List(Of detalleitems)

        itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        itemBE.estado = "A"

        Select Case tipo
            Case "TODO"
                listaCategoria = itemSA.GetUbicarProductoXMarca(itemBE)
                ListaProductos = listaCategoria
            Case "FILTRO"
                listaCategoria = itemSA.GetUbicarProductoXMarca(itemBE).Where(Function(O) String.IsNullOrEmpty(O.idItem)).ToList
                ListaProductos = listaCategoria
            Case "TEXTO"
                listaCategoria = ListaProductos.Where(Function(O) O.descripcionItem.Contains(TextFiltrar.Text)).ToList
        End Select

        dgvProductos.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("descripcion")
            .Add("idMarca")
            .Add("marca")
            .Add("actualizar")
        End With

        For Each i In listaCategoria

            dt.Rows.Add(i.codigodetalle,
                    i.descripcionItem,
                    i.idItem,
                    i.presentacion,
                    "")
        Next
        dgvProductos.DataSource = dt

    End Sub


    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        Try
            If (Label1.Tag > 0) Then
                Dim itemBE As New item
                Dim itemSA As New itemSA

                Dim f As New frmNuevaMarca
                'f.MANIPULACION = ENTITY_ACTIONS.INSERT
                f.txtCodigo.Tag = PadreID
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                'listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento).ToList
                'Dim consulta = listaItem.Where(Function(o) o.tipo = "M" And o.idPadre = PadreID).ToList
                'GetDocumentoVentaID(consulta)
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
                GetDetalleItems("TODO")
            Case False
                CargarSubCategorias()
                GetDetalleItems("TODO")
        End Select
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Select Case TipoManejo
            Case True
                CargarCategorias()
                GetDetalleItems("TODO")
            Case False
                CargarSubCategorias()
                GetDetalleItems("TODO")
        End Select
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Try
            If (Label1.Tag > 0) Then
                Dim itemBE As New item
                Dim itemSA As New itemSA

                Dim f As New frmNuevaMarca
                'f.MANIPULACION = ENTITY_ACTIONS.INSERT
                f.txtCodigo.Tag = PadreID
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                'listaItem = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento).ToList
                'Dim consulta = listaItem.Where(Function(o) o.tipo = "M" And o.idPadre = PadreID).ToList
                'GetDocumentoVentaID(consulta)
            Else
                MessageBox.Show("Debe Seleccionar una categoria")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridGroupingControl1_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvProductos.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 4 Then
                e.Inner.Style.Description = "Agregar"
                e.Inner.Style.TextColor = Color.Black

                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                              )
                'e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If

        End If
    End Sub

    Private Sub DgvProductos_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvProductos.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 4 Then

                If (lblNomSubCategoria.Tag > 0 And lblNomSubCategoria.Text.Length > 0) Then
                    Dim itemBE As New detalleitems
                    Dim itemSA As New detalleitemsSA

                    Dim style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                    Dim Record = style.TableCellIdentity.DisplayElement.GetRecord()

                    itemBE.codigodetalle = Record.GetValue("ID")
                    itemBE.idItem = lblNomSubCategoria.Tag

                    itemSA.actualizarMarcaProducto(itemBE)
                    cargarUpdate()
                    chMarcaFiltro.Checked = False
                    GetDetalleItems("TODO")
                Else
                    MessageBox.Show("Debe elegir una Categoria")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ChMarcaFiltro_CheckedChanged(sender As Object, e As EventArgs) Handles chMarcaFiltro.CheckedChanged
        If (chMarcaFiltro.Checked = True) Then
            GetDetalleItems("FILTRO")
        ElseIf (chMarcaFiltro.Checked = False) Then
            GetDetalleItems("TODO")
        End If
    End Sub

    Private Sub TextFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles TextFiltrar.KeyDown
        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                If TextFiltrar.Text.Trim.Length > 0 AndAlso TextFiltrar.Text.Trim.Length >= 2 Then
                    GetDetalleItems("TEXTO")
                ElseIf TextFiltrar.Text.Trim.Length = 0 Then
                    GetDetalleItems("TODO")
                End If
                If e.KeyCode = Keys.Down Then

                    'usercontrol.GridTotales.TableControl.CurrentCell.ShowDropDown()
                End If            '   End If

                ' e.SuppressKeyPress = True
                If e.KeyCode = Keys.Escape Then

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureLoadingProduct_Click(sender As Object, e As EventArgs) Handles PictureLoadingProduct.Click
        GetDetalleItems("TODO")
    End Sub



#End Region

#Region "Events"


#End Region

End Class
