Imports Helios.Cont.Business.Entity
Imports Helios.General
Public Class ucBuscarCategorias


#Region "Atributos"

    Public ReadOnly Property _UCNuenExistencia As UCNuenExistencia
    Public Property ListaItem As List(Of item)

#End Region

#Region "Constructor"


    Sub New(UCNuenExistencia As UCNuenExistencia)

        ' This call is required by the designer.
        InitializeComponent()
        _UCNuenExistencia = UCNuenExistencia
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Metodos"

    Public Sub FillLSVItems(consulta As List(Of item), tipo As String)


        ListaItem = New List(Of item)
        ListaItem = consulta

        TextBox1.Text = tipo
        LsvCategorias.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In ListaItem
            Dim n As New ListViewItem(i.idItem)

            n.SubItems.Add(i.descripcion)
            LsvCategorias.Items.Add(n)
        Next
        LsvCategorias.Refresh
    End Sub


    Public Sub FillLSVItemsSolo(consulta As List(Of item))




        LsvCategorias.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idItem)

            n.SubItems.Add(i.descripcion)
            LsvCategorias.Items.Add(n)
        Next
        LsvCategorias.Refresh()
    End Sub

    Private Sub LsvCategorias_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvCategorias.MouseDoubleClick
        If LsvCategorias.SelectedItems.Count > 0 Then

            If TextBox1.Text = TipoGrupoArticulo.Principal Then
                _UCNuenExistencia.txtClasificacion.Text = LsvCategorias.SelectedItems(0).SubItems(1).Text
                _UCNuenExistencia.txtClasificacion.Tag = LsvCategorias.SelectedItems(0).SubItems(0).Text

                _UCNuenExistencia.txtCategoria.Text = ""
                _UCNuenExistencia.txtCategoria.Tag = Nothing

                _UCNuenExistencia.txtSubCategoria.Text = ""
                _UCNuenExistencia.txtSubCategoria.Tag = Nothing

            ElseIf TextBox1.Text = TipoGrupoArticulo.CategoriaGeneral Then
                _UCNuenExistencia.txtCategoria.Text = LsvCategorias.SelectedItems(0).SubItems(1).Text
                _UCNuenExistencia.txtCategoria.Tag = LsvCategorias.SelectedItems(0).SubItems(0).Text

                _UCNuenExistencia.txtSubCategoria.Text = ""
                _UCNuenExistencia.txtSubCategoria.Tag = Nothing

            ElseIf TextBox1.Text = TipoGrupoArticulo.SubCategoriaGeneral Then
                _UCNuenExistencia.txtSubCategoria.Text = LsvCategorias.SelectedItems(0).SubItems(1).Text
                _UCNuenExistencia.txtSubCategoria.Tag = LsvCategorias.SelectedItems(0).SubItems(0).Text


            ElseIf TextBox1.Text = TipoGrupoArticulo.Marca Then
                _UCNuenExistencia.txtMarca.Text = LsvCategorias.SelectedItems(0).SubItems(1).Text
                _UCNuenExistencia.txtMarca.Tag = LsvCategorias.SelectedItems(0).SubItems(0).Text

                _UCNuenExistencia.TextPresentacion.Text = ""
                _UCNuenExistencia.TextPresentacion.Tag = Nothing

            ElseIf TextBox1.Text = TipoGrupoArticulo.Presentacion Then
                _UCNuenExistencia.TextPresentacion.Text = LsvCategorias.SelectedItems(0).SubItems(1).Text
                _UCNuenExistencia.TextPresentacion.Tag = LsvCategorias.SelectedItems(0).SubItems(0).Text


                If _UCNuenExistencia.EstadoManipulacion = ENTITY_ACTIONS.INSERT Then

                    _UCNuenExistencia.txtProductoNew.Text = _UCNuenExistencia.txtClasificacion.Text + "-" +
                                                        _UCNuenExistencia.txtCategoria.Text + "-" +
                                                        _UCNuenExistencia.txtSubCategoria.Text + "-" +
                                                        _UCNuenExistencia.txtMarca.Text + "-" +
                                                        _UCNuenExistencia.TextPresentacion.Text
                End If
            End If


            End If
    End Sub

    'Private Sub LsvCategorias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LsvCategorias.SelectedIndexChanged

    'End Sub

    'Private Sub TextLikeCategoria_TextChanged(sender As Object, e As EventArgs) Handles TextLikeCategoria.TextChanged

    'End Sub

    'Private Sub TextLikeCategoria_KeyDown(sender As Object, e As KeyEventArgs)


    '    If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

    '    ElseIf e.KeyCode = Keys.Enter Then

    '        Dim filter = TextLikeCategoria.Text.Trim

    '        If filter.Trim.Length = 0 Then
    '            FillLSVItems(ListaItem, TextBox1.Text)
    '        Else

    '            Dim consulta = ListaItem.Where(Function(o) o.descripcion.Contains(filter)).ToList
    '            LsvCategorias.Items.Clear()
    '            If consulta.Count > 0 Then
    '                FillLSVItems(consulta, TextBox1.Text)
    '            End If
    '        End If
    '    End If
    'End Sub



    Private Sub TextLikeCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TextLikeCliente.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then

            Dim filter = TextLikeCliente.Text.Trim

            If filter.Trim.Length = 0 Then
                'FillLSVItems(ListaItem, TextBox1.Text)
                FillLSVItemsSolo(ListaItem)

            Else

                Dim consulta = ListaItem.Where(Function(o) o.descripcion.Contains(filter)).ToList

                If consulta.Count > 0 Then
                    'FillLSVItems(consulta, TextBox1.Text)

                    FillLSVItemsSolo(consulta)

                End If
            End If
        End If
    End Sub

    Private Sub TextLikeCliente_TextChanged(sender As Object, e As EventArgs) Handles TextLikeCliente.TextChanged

    End Sub

    Private Sub LsvCategorias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LsvCategorias.SelectedIndexChanged

    End Sub















#End Region

End Class
