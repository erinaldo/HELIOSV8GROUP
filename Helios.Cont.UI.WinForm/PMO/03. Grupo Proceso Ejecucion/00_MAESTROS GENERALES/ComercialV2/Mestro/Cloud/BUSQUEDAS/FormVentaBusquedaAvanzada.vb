Imports Helios.General.Constantes
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms

Public Class FormVentaBusquedaAvanzada


    Public Property ListaDeMarcas() As List(Of item)
    Public Property ListaDeGrupos() As List(Of item)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadCombos()
    End Sub

    Private Sub LoadCombos()
        ListaDeMarcas = New List(Of item)
        ListaDeGrupos = New List(Of item)

        Dim itemSA As New itemSA
        ListaDeGrupos = itemSA.GetListaItemsPorTipo(New item With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .tipo = TipoGrupoArticulo.CategoriaGeneral
                                                          })

        ListaDeMarcas = itemSA.GetListaItemsPorTipo(New item With
                                                         {
                                                         .idEmpresa = Gempresas.IdEmpresaRuc,
                                                         .tipo = TipoGrupoArticulo.Marca
                                                         })
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        If Not txtFiltrar.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese un parametro valida", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If txtFiltrar.Text.Trim.Length > 0 Then
            If txtFiltrar.ForeColor = Color.Black Then
                MessageBox.Show("Verificar el ingreso correcto del parametro", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFiltrar.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
        End If
        Dim c As New BusquedaAvanzadaProductos With {
            .tipo = ComboFiltros.Text,
            .codigo = txtFiltrar.Tag
            }

        Dim miInterfaz As IBusquedaAvanzadaProductos = TryCast(Me.Owner, IBusquedaAvanzadaProductos)
        If miInterfaz IsNot Nothing Then miInterfaz.BusquedaAvanzadaProductos(c)
        Close()
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged
        txtFiltrar.ForeColor = Color.Black
        txtFiltrar.Tag = Nothing
    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else

            Select Case ComboFiltros.Text
                Case "CLASIFICACION"
                    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                    Me.pcLikeCategoria.Size = New Size(241, 110)
                    Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
                    Me.pcLikeCategoria.ShowPopup(Point.Empty)
                    Dim consulta = (From n In ListaDeGrupos
                                    Where n.descripcion.StartsWith(txtFiltrar.Text)).ToList

                    lsvCategoria.DataSource = consulta
                    lsvCategoria.DisplayMember = "descripcion"
                    lsvCategoria.ValueMember = "idItem"
                Case "MARCA"

                    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                    Me.pcLikeCategoria.Size = New Size(241, 110)
                    Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
                    Me.pcLikeCategoria.ShowPopup(Point.Empty)
                    Dim consulta = (From n In ListaDeMarcas
                                    Where n.descripcion.StartsWith(txtFiltrar.Text)).ToList


                    lsvCategoria.DataSource = consulta
                    lsvCategoria.DisplayMember = "descripcion"
                    lsvCategoria.ValueMember = "idItem"
            End Select

            'e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            lsvCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtFiltrar.Text = lsvCategoria.Text
                txtFiltrar.Tag = lsvCategoria.SelectedValue
                txtFiltrar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtFiltrar.Focus()
        End If
    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Close()
    End Sub
End Class