Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmNuevaMarca
    Inherits frmMaster

#Region "VARIABLES"
    Public Property ManipulacionEstado() As String
#End Region


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
                item.codigo = txtCodigo.Text
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

    Public Sub InsertMarca()


        Dim itemSA As New itemSA
        Dim item As New item

        Dim datos As List(Of item) = item.Instance()
        datos.Clear()
        Dim c As New item

        Try
            With item
                .tipo = TipoGrupoArticulo.Marca
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                '.idPadre = CboClasificacion.SelectedValue
                '.idPadre = lblidSubClasificacion.Text
                Dim idpadre = txtCodigo.Tag
                '.idPadre = CInt(idpadre)
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

            Dim codx As Integer = itemSA.InsertarMarcaHijo(item)

            c.idItem = codx
            c.descripcion = txtDescripcion.Text
            datos.Add(c)

            Dispose()

        Catch ex As Exception
            MsgBox("No se pudo grabar la marca." & vbCrLf & ex.Message)
        End Try


        'Dim objmarca As New tabladetalle
        'Dim tablaSA As New tablaDetalleSA

        'Try
        '    objmarca.idtabla = "503"
        '    objmarca.codigoDetalle = txtCodigo.Text
        '    objmarca.descripcion = txtDescripcion.Text
        '    objmarca.estadodetalle = "1"
        '    objmarca.usuarioModificacion = usuario.IDUsuario
        '    objmarca.fechaModificacion = DateTime.Now
        '    tablaSA.InsertarMarca(objmarca)
        '    '  MessageBox.Show("Grabo Correctamente")
        '    Me.Tag = objmarca
        '    Dispose()

        'Catch ex As Exception
        '    'Manejo de errores
        '    MsgBox("No se pudo grabar la marca." & vbCrLf & ex.Message)
        'End Try
    End Sub

    Private Sub frmNuevaMarca_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
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

            If chkCodigo.Checked = True Then

                If txtCodigoInterno.Text.Trim.Length > 0 Then
                Else
                    MessageBox.Show("Ingrese un Codigo o desactive la opcion  codigo")
                End If

            End If



            If Not txtDescripcion.Text.Trim.Length > 0 Then
                txtDescripcion.Select()
                MessageBoxAdv.Show("Ingrese una descripción válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                InsertMarca()
            ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                UpdateTipoCategoria()
            End If


        Catch ex As Exception
            Tag = Nothing
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub frmNuevaMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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