Public Class FormTipoImpresionEncomienda
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Dim seleccion As String = String.Empty

        If RBPendiente.Checked = True Then
            seleccion = "SEL"
        ElseIf RBAcumulado.Checked = True Then
            seleccion = "ACU"
        End If

        Tag = seleccion
        Close()
    End Sub
End Class