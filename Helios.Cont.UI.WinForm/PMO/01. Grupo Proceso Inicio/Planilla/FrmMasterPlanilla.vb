Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FrmMasterPlanilla

#Region "metodos"
    'Sub ObtenerListaOcupacion(idestable As Integer)
    '    Dim ocupacioSA As New ocupacionSA
    '    Try
    '        ocupacioSA.ObtenerOcupacion(idestable)
    '        cboOcupacion.DisplayMember = "nombreOcupacion"
    '        cboOcupacion.ValueMember = "codOcupacion"


    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '    End Try
    'End Sub
#End Region

    Private Sub dgvOcupacion_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Label12_Click(sender As System.Object, e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub dgvPlazo_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPlazo.CellContentClick

    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub dgvIngresos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIngresos.CellContentClick

    End Sub

    Private Sub dgvIngresos_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIngresos.CellValueChanged
        If dgvIngresos.Rows.Count > 0 Then

            For Each t As DataGridViewRow In dgvIngresos.Rows
                t.Cells(9).Value = Math.Round(CDec(t.Cells(8).Value) + CDec(t.Cells(7).Value) + CDec(t.Cells(6).Value) + CDec(t.Cells(5).Value) + CDec(t.Cells(4).Value), 2).ToString("N2")
            Next
        End If
    End Sub

    Private Sub dgvPlazo_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPlazo.CellValueChanged

    End Sub

    Private Sub dgvPlazo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvPlazo.KeyDown
        If txtdiasalmes.Text > 0 Then
            If txtmesporaño.Text > 0 Then
                dgvPlazo.Rows(0).Cells(3).Value = Math.Round(CDec(dgvPlazo.Rows(0).Cells(2).Value / CDec(txtdiasalmes.Text))).ToString("N2")
                dgvPlazo.Rows(0).Cells(4).Value = Math.Round(CDec(dgvPlazo.Rows(0).Cells(3).Value / CDec(txtmesporaño.Text))).ToString("N2")
            End If
        End If
    End Sub

    Private Sub FrmMasterPlanilla_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
       
        With FrmMasterOcupacion
            .Tag = "1"
            .ShowDialog()
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        With FrmDetalleIngresoSunat
            .Tag = "1"
            .ShowDialog()
        End With

        Me.Cursor = Cursors.Arrow
    End Sub
End Class