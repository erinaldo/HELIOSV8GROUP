Public Class frmMaestroGasto

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim f As New frmControlGastos
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim f As New frmMaestroGastos
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
End Class