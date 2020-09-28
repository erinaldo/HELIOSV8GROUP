Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmNuevaMarcaInfraestructura
    Inherits frmMaster

    Dim listaCategoria As New List(Of item)

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CMBClasificacion()
    End Sub

    Public Sub New(idSubCategoria As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        CMBClasificacion()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        UbicarSubCategoria(idSubCategoria)
    End Sub

    Public Sub GrabarSubClasificacion()
        Dim tipoServicioInfraestructuraBE As New item
        Dim tipoServicioInfraestructuraSA As New itemSA

        Dim datos As List(Of item) = item.Instance()
        datos.Clear()
        Dim c As New item

        Try
            With tipoServicioInfraestructuraBE

                'obj.[idTipoServicio] = objCategoria.[idTipoServicio]
                .[idEmpresa] = Gempresas.IdEmpresaRuc
                .[idEstablecimiento] = GEstableciento.IdEstablecimiento
                .idPadre = txtCategoria.Tag
                .descripcion = txtDescripcion.Text
                .tipo = "M"
                .fechaIngreso = Date.Now
                .[usuarioActualizacion] = usuario.IDUsuario
                .[fechaActualizacion] = DateTime.Now

            End With

            Dim codx As Integer = tipoServicioInfraestructuraSA.InsertarMarcaHijo(tipoServicioInfraestructuraBE)
            'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
            'Me.txtCategoria.Tag = CStr(codx)
            'txtCategoria.Text = txtNewClasificacion.Text.Trim
            c.idItem = codx
            c.descripcion = txtDescripcion.Text
            datos.Add(c)
            'clasificacion()
            Dispose()
            'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UbicarSubCategoria(idSubCategoria As Integer)
        Dim tipoServicioInfraestructuraBE As New tipoServicioInfraestructura
        Dim tipoServicioInfraestructuraSA As New tipoServicioInfraestructuraSA
        Dim objtipoServicioInfraestructura As New tipoServicioInfraestructura

        tipoServicioInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        tipoServicioInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        tipoServicioInfraestructuraBE.idCategoria = idSubCategoria

        'objtipoServicioInfraestructura = tipoServicioInfraestructuraSA.GetUbicartipoServicioInfraestructuraXID(tipoServicioInfraestructuraBE)

        'If (Not IsNothing(objtipoServicioInfraestructura)) Then
        '    txtDescripcion.Text = objtipoServicioInfraestructura.descripcionTipoServicio
        '    txtDescripcion.Tag = objtipoServicioInfraestructura.idTipoServicio
        'End If

    End Sub


    Private Sub CMBClasificacion()
        Dim categoriaSA As New itemSA
        ' categoriaSA.GetListaPadre()
        listaCategoria = New List(Of item)
        listaCategoria = categoriaSA.GetListaItemsPorTipo(New item With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .tipo = "c"
                                                          })

    End Sub

    Private Sub frmNuevaMarca_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Try
            'If Not txtCodigo.Text.Trim.Length > 0 Then
            '    txtCodigo.Select()
            '    MessageBoxAdv.Show("Ingrese un código válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If

            If Not txtDescripcion.Text.Trim.Length > 0 Then
                txtDescripcion.Select()
                MessageBoxAdv.Show("Ingrese una descripción válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            GrabarSubClasificacion()
        Catch ex As Exception
            Tag = Nothing
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim datos As List(Of item) = item.Instance()
        datos.Clear()

        Dim f As New frmNuevaClasificacion
        f.txtDescripcion.Text = txtCategoria.Text
        txtCategoria.Clear()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        CMBClasificacion()
        If datos.Count > 0 Then
            txtCategoria.Text = datos(0).descripcion
            txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCategoria.Tag = CInt(datos(0).idItem)
        End If
    End Sub

    Private Sub ChClasificacion_CheckedChanged(sender As Object, e As EventArgs) Handles chClasificacion.CheckedChanged
        If (chClasificacion.Checked = False) Then
            Label8.Visible = False
            txtCategoria.Visible = False
            PictureBox3.Visible = False
            Label1.Visible = True
            txtCategoria.Tag = Nothing
            txtCategoria.Clear()
        Else
            Label8.Visible = True
            txtCategoria.Visible = True
            PictureBox3.Visible = True
            Label1.Visible = True
            txtCategoria.Tag = Nothing
            txtCategoria.Clear()
            CMBClasificacion()
        End If
    End Sub

    Private Sub TxtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaCategoria
                            Where n.descripcion.StartsWith(txtCategoria.Text)).ToList

            lsvCategoria.DataSource = consulta
            lsvCategoria.DisplayMember = "descripcion"
            lsvCategoria.ValueMember = "idItem"
            'e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
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

    Private Sub PcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtCategoria.Text = lsvCategoria.Text
                txtCategoria.Tag = lsvCategoria.SelectedValue
                txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                ' Label43.Text = "0 items"
                '  Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub LsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub TxtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged
        txtCategoria.ForeColor = Color.White
        txtCategoria.Tag = Nothing
    End Sub
End Class