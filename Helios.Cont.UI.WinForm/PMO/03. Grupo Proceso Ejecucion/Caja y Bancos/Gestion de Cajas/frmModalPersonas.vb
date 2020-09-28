Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalPersonas

    Public Sub ObtenerPersonasStarWidth(strTexto As String)
        Dim personaSA As New PersonaSA

        lstPersonas.DisplayMember = "nombreCompleto"
        lstPersonas.ValueMember = "idPersona"
        lstPersonas.DataSource = personaSA.ObtenerPersonaPorNombres(Gempresas.IdEmpresaRuc, strTexto)
    End Sub

    Private Sub frmModalPersonas_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltro.Text.Trim.Length > 0 Then
                ObtenerPersonasStarWidth(txtFiltro.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub lstPersonas_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstPersonas.MouseDoubleClick
        If lstPersonas.SelectedItems.Count > 0 Then
            Dim n As New RecuperarCarteras()
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            n.ID = lstPersonas.SelectedValue
            n.NombreEntidad = lstPersonas.Text
            datos.Add(n)
            Dispose()
        End If
    End Sub

    Private Sub lstPersonas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstPersonas.SelectedIndexChanged

    End Sub
End Class