Imports Helios.General
Public Class FormCodigoAcceso
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function EnviarUsuario() As String
        EnviarUsuario = Nothing
        Dim usuario As String = TextCodigoVendedor.Text
        If usuario.ToString.Trim.Length > 0 Then

            EnviarUsuario = usuario
            Tag = EnviarUsuario
            Close()

        Else
            MessageBox.Show("Debe indicar un codigo en la caja de texto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Function

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        EnviarUsuario()
    End Sub
End Class