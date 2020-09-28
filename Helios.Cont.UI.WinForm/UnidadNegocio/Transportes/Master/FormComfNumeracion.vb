Imports Helios.General
Public Class FormComfNumeracion
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub EnviarUsuario()

        If TextCodigoVendedor.Text > 0 Then
            Tag = TextCodigoVendedor.Text
            Dispose()
        Else
            MessageBox.Show("Debe indicar un codigo en la caja de texto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        EnviarUsuario()
    End Sub

    Private Sub TextCodigoVendedor_TextChanged(sender As Object, e As EventArgs)
        TextCodigoVendedor.Select(0, TextCodigoVendedor.Text.Length)
    End Sub
End Class