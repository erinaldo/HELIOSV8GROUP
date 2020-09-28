Imports Helios.General
Imports Helios.Cont.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class frmTablaDetalle

    Public Property actyon As String

#Region "METODOS"

    Public Sub limpiarCajas()
        txtTablaMaestra.Text = ""
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
    End Sub


    Sub Grabar()
        Dim intIdTabla As Integer
        Dim tabladetalleSA As New tablaDetalleSA
        Dim tabladet As New tabladetalle

        Try
            tabladet = New tabladetalle With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idtabla = frmMasterTabla.txtidtabla.Text,
            .codigoDetalle = txtCodigo.Text,
            .estadodetalle = "1",
            .descripcion = txtDescripcion.Text,
            .usuarioModificacion = "Martin",
            .fechaModificacion = DateTime.Now}
            intIdTabla = tabladetalleSA.InsertarTablaDetalle(tabladet)


            If intIdTabla <> Nothing Then
                lblEstado.Text = "registrado"
                lblEstado.Image = My.Resources.ok4
                Dim n As New ListViewItem(txtCodigo.Text.Trim)
                n.SubItems.Add(txtDescripcion.Text.Trim)
                frmMasterTabla.lsvTablas.Items.Add(n)
                Dispose()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
            

        Catch ex As Exception
            lblEstado.Text = "Error al grabar " & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub




    Sub Editar()

        Dim tabladetalleSA As New tablaDetalleSA
        Dim TabDetall As New tabladetalle
        Try
            TabDetall = New tabladetalle With {
            .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
            .idtabla = frmMasterTabla.lsvTablas.SelectedItems(0).SubItems(2).Text,
            .codigoDetalle = txtCodigo.Text,
            .descripcion = txtDescripcion.Text,
            .usuarioModificacion = "Martin",
            .fechaModificacion = DateTime.Now}
            


            lblEstado.Text = " Actualizado!"
            lblEstado.Image = My.Resources.ok4

            If (tabladetalleSA.UpdateTablaDetalle(TabDetall)) Then
                lblEstado.Text = "Recurso editado!"
                lblEstado.Image = My.Resources.ok4
                With frmMasterTabla.lsvTablas
                    .SelectedItems(0).SubItems(0).Text = txtCodigo.Text
                    .SelectedItems(0).SubItems(1).Text = txtDescripcion.Text
                End With

                Dispose()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If

            Dispose()
        Catch ex As Exception
            lblEstado.Text = "Error al Actualizar" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub

#End Region

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Dispose()
    End Sub

    Private Sub frmTablaDetalle_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If (txtDescripcion.Text <> "" And txtCodigo.Text <> "" And txtTablaMaestra.Text <> "") Then
            Me.Cursor = Cursors.WaitCursor
            Select Case actyon
                Case ENTITY_ACTIONS.INSERT
                    Grabar()
                Case ENTITY_ACTIONS.UPDATE
                    Editar()
            End Select
            Me.Cursor = Cursors.Arrow
        Else
            If (txtDescripcion.Text = "" Or txtCodigo.Text = "" Or txtTablaMaestra.Text = "") Then
                lblEstado.Text = "Debe ingresar todo los campos correctamente"
                lblEstado.Image = My.Resources.cross
                'ErrorEDT.SetError(txtDescripcionEDT, "Ingresar una descripción")
                'If (txtFechaIEDT.Value > txtFechaFEDT.Value) Then
                '    lblEstado.Text = "La fecha inicio debe ser menor a la fecha fin"
                '    lblEstado.Image = My.Resources.cross

                'End If
                'If (txtIdResponsable.Text = "") Then
                '    ErrorEDT.SetError(lblCambiar, "Ingresar un trabajador")
                'End If
                'If (txtIdResponsable.Text = "") Then
                '    ErrorEDT.SetError(txtDescripcionEDT, "Ingresar una descripción")
                'End If
            End If
        End If
    End Sub

    Private Sub frmTablaDetalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        txtCodigo.MaxLength = 5
    End Sub

    Private Sub txtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCodigo.TextChanged

    End Sub
End Class