Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class frmNuevoPresentacion


#Region "VARIABLES"
    Public Property ManipulacionEstado() As String
#End Region

#Region "metodos"


    Public Sub UpdateTipoCategoria()
        Dim itemSA As New itemSA
        Dim item As New item

        Dim datos As List(Of item) = item.Instance()
        datos.Clear()
        Dim c As New item

        Try
            With item
                .idItem = lblCodigo.Text
                .descripcion = txtDescripcion.Text.Trim
            End With



            If chkCodigo.Checked = True Then
                item.codigo = txtCodigoInterno.Text
            End If


            Dim codx As Integer = itemSA.UpdateTipoCategoria(item)
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

    Public Sub GrabarPresentacionxMarca()
        Dim itemSA As New itemSA
        Dim item As New item

        Dim datos As List(Of item) = item.Instance()
        datos.Clear()
        Dim c As New item

        Try
            With item
                .tipo = TipoGrupoArticulo.Presentacion
                .idPadre = lblidmarca.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .descripcion = txtDescripcion.Text.Trim
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
                .preciocompratipo = "NN"
                .precioCompra = 0
                .firstpercent = 0
                .beforepercent = 0
            End With


            If chkCodigo.Checked = True Then
                item.codigo = txtCodigoInterno.Text
            End If



            Dim codx As Integer = itemSA.InsertMultiplePresentacion(item)
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
#End Region

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click


        If chkCodigo.Checked = True Then

            If txtCodigoInterno.Text.Trim.Length > 0 Then
            Else
                MessageBox.Show("Ingrese un Codigo o desactive la opcion  codigo")
            End If

        End If

        If txtDescripcion.Text.Trim.Length > 0 Then


            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                GrabarPresentacionxMarca()
            ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                UpdateTipoCategoria()
            End If

        Else
                MessageBox.Show("Debe indicar el nombre de la categoría!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub frmNuevaClasificacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevaClasificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub chkCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCodigo.CheckedChanged
        txtCodigoInterno.Text = ""

        If chkCodigo.Checked = True Then

            txtCodigoInterno.Visible = True
        ElseIf chkCodigo.Checked = False Then
            txtCodigoInterno.Visible = False
        End If
    End Sub
End Class