Imports Helios.General
Public Class formReimpresion
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub EnviarUsuario()

        If lblPrecioTotal.Text > 0 Then
            Tag = lblPrecioTotal.Text
            Dispose()
        Else
            MessageBox.Show("Debe indicar un codigo en la caja de texto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        EnviarUsuario()
    End Sub

    Private Sub LblPrecioTotal_Click(sender As Object, e As EventArgs) Handles lblPrecioTotal.Click
        lblPrecioTotal.Select(0, lblPrecioTotal.Text.Length)
    End Sub

    Private Sub FormReimpresion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPrecioTotal.Select(0, lblPrecioTotal.Text.Length)
    End Sub
End Class