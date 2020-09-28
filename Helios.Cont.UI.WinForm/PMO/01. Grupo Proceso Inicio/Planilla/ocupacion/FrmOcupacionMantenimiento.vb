Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FrmOcupacionMantenimiento

    Public Property actyon As String


#Region "metodos"
    Sub Grabar()
        Dim codOcupacion As Integer
        Dim ocupacioSA As New ocupacionSA
        Dim ocupacio As New ocupacion

        Try
            ocupacio = New ocupacion With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .nombreOcupacion = txtOcupacion.Text,
            .usuarioActualizacion = "MARTIN",
            .fechaActualizacion = Date.Now}

            codOcupacion = ocupacioSA.InsertarOcupacion(ocupacio)

            If codOcupacion <> Nothing Then
                lblEstado.Text = "registrado"
                lblEstado.Image = My.Resources.ok4
                FrmMasterOcupacion.dgvOcupacion.Rows.Add(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "", txtOcupacion.Text)
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

        Dim ocupacioSA As New ocupacionSA
        Dim ocupacio As New ocupacion
        Try
            ocupacio = New ocupacion With {
            .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
            .codOcupacion = FrmMasterOcupacion.dgvOcupacion.SelectedRows(0).Cells(2).Value,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .nombreOcupacion = txtOcupacion.Text,
            .usuarioActualizacion = "MARTIN",
            .fechaActualizacion = Date.Now}

            lblEstado.Text = " Actualizado!"
            lblEstado.Image = My.Resources.ok4

            If (ocupacioSA.UpdateOcupacion(ocupacio)) Then
                lblEstado.Text = "Recurso editado!"
                lblEstado.Image = My.Resources.ok4
                With FrmDetalleIngresoSunat.dgvIngresoSunat
                    .Item(3, FrmDetalleIngresoSunat.dgvIngresoSunat.CurrentRow.Index).Value = txtOcupacion.Text
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

    Private Sub FrmOcupacionMantenimiento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If (txtOcupacion.Text <> "") Then
            Me.Cursor = Cursors.WaitCursor
            Select Case actyon
                Case ENTITY_ACTIONS.INSERT
                    Grabar()
                Case ENTITY_ACTIONS.UPDATE
                    'Editar()
            End Select
            Me.Cursor = Cursors.Arrow
        Else
            If (txtOcupacion.Text = "") Then
                lblEstado.Text = "Debe ingresar todo los campos correctamente"
                lblEstado.Image = My.Resources.cross

            End If
        End If
    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Dispose()
    End Sub
End Class