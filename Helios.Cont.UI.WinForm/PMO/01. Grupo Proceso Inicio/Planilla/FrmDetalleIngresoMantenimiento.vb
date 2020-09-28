Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FrmDetalleIngresoMantenimiento

    Public Property actyon As String



#Region "metodos"
    Sub Grabar()
        Dim intCodSunat As Integer
        Dim ingresosunatSA As New ingresoSunatSA
        Dim ingresosunat As New ingresoSunat

        Try
            ingresosunat = New ingresoSunat With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idPadre = FrmDetalleIngresoSunat.txtCodigo.Text,
            .codigoSunat = txtCodigo.Text,
            .descripcion = txtDescripcion.Text}
            intCodSunat = ingresosunatSA.InsertarIngresoSunat(ingresosunat)

            If intCodSunat <> Nothing Then
                lblEstado.Text = "registrado"
                lblEstado.Image = My.Resources.ok4
                FrmDetalleIngresoSunat.dgvIngresoSunat.Rows.Add("", txtCodigo.Text, "", txtDescripcion.Text, FrmDetalleIngresoSunat.txtCodigo.Text)
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

        Dim ingresoSunatSA As New ingresoSunatSA
        Dim ingresosunat As New ingresoSunat
        Try
            ingresosunat = New ingresoSunat With {
            .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
            .idIngresoSunat = FrmDetalleIngresoSunat.dgvIngresoSunat.SelectedRows(0).Cells(0).Value,
            .codigoSunat = txtCodigo.Text,
            .descripcion = txtDescripcion.Text,
            .idPadre = FrmDetalleIngresoSunat.txtCodigo.Text}

            lblEstado.Text = " Actualizado!"
            lblEstado.Image = My.Resources.ok4

            If (ingresoSunatSA.UpdateIngresoSunat(ingresosunat)) Then
                lblEstado.Text = "Recurso editado!"
                lblEstado.Image = My.Resources.ok4
                With FrmDetalleIngresoSunat.dgvIngresoSunat
                    .Item(1, FrmDetalleIngresoSunat.dgvIngresoSunat.CurrentRow.Index).Value = txtCodigo.Text
                    .Item(2, FrmDetalleIngresoSunat.dgvIngresoSunat.CurrentRow.Index).Value = txtDescripcion.Text
                    .Item(3, FrmDetalleIngresoSunat.dgvIngresoSunat.CurrentRow.Index).Value = FrmDetalleIngresoSunat.txtCodigo.Text
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

            End If
        End If
    End Sub
End Class