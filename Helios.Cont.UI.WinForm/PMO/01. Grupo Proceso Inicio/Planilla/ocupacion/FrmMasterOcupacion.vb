Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FrmMasterOcupacion

#Region "METODOS"

    Sub ObtenerListaOcupacion(idestable As Integer)
        Dim ocupacioSA As New ocupacionSA
        Try
            dgvOcupacion.Rows.Clear()
            For Each i In ocupacioSA.ObtenerOcupacion(idestable)
                dgvOcupacion.Rows.Add(i.idEmpresa, i.idEstablecimiento,
                                         i.codOcupacion, i.nombreOcupacion)
            Next
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub


    Sub eliminarOcupacion()

        Dim ocupacioSA As New ocupacionSA
        Dim ocupacio As New ocupacion
        Try
            ocupacio = New ocupacion With {
            .Action = Business.Entity.BaseBE.EntityAction.INSERT,
            .codOcupacion = dgvOcupacion.SelectedRows(0).Cells(2).Value}

            If (ocupacioSA.DeleteOcupacion(ocupacio)) Then
                lblEstado.Text = " Eliminado!"
                lblEstado.Image = My.Resources.ok4

                dgvOcupacion.Rows.RemoveAt(dgvOcupacion.CurrentRow.Index)

            Else
                lblEstado.Text = "Error al Eliminar "
                lblEstado.Image = My.Resources.cross
            End If

        Catch ex As Exception
            lblEstado.Text = "Error al Eliminar" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub
#End Region

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        With FrmOcupacionMantenimiento

            .actyon = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        If dgvOcupacion.Rows.Count > 0 Then
            With FrmOcupacionMantenimiento
                .actyon = ENTITY_ACTIONS.UPDATE
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else

            lblEstado.Text = "Debe seleccionar una tabla"
            lblEstado.Image = My.Resources.cross

        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If dgvOcupacion.Rows.Count > 0 Then
            eliminarOcupacion()
        Else
            lblEstado.Text = "Debe seleccionar una fila"
            lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Private Sub FrmMasterOcupacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ObtenerListaOcupacion(GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub dgvOcupacion_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOcupacion.CellContentClick

    End Sub

    Private Sub dgvOcupacion_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOcupacion.CellDoubleClick

        If dgvOcupacion.Rows.Count > 0 Then
            If Tag = "1" Then
                FrmMasterPlanilla.txtOcupacion.Text = dgvOcupacion.SelectedRows(0).Cells(3).Value
            End If
        End If
    End Sub
End Class