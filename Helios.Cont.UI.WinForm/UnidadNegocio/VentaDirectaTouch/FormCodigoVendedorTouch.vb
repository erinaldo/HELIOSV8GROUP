Imports Helios.General
Public Class FormCodigoVendedorTouch
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function EnviarUsuario() As Helios.Seguridad.Business.Entity.Usuario
        EnviarUsuario = Nothing
        Dim usuario As String = TextCodigoVendedor.Text
        If usuario.ToString.Trim.Length > 0 Then
            Dim sel = UsuariosList.Where(Function(o) o.codigo = usuario).FirstOrDefault
            If sel IsNot Nothing Then
                EnviarUsuario = sel
                Tag = sel
                Close()
            Else
                MessageBox.Show("El codigo ingresado no existe en la base de datos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe indicar un codigo en la caja de texto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Function

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        EnviarUsuario()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextCodigoVendedor.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "1"
        Else
            TextCodigoVendedor.Text = "1"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "2"
        Else
            TextCodigoVendedor.Text = "2"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "3"
        Else
            TextCodigoVendedor.Text = "3"
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "4"
        Else
            TextCodigoVendedor.Text = "4"
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "5"
        Else
            TextCodigoVendedor.Text = "5"
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "6"
        Else
            TextCodigoVendedor.Text = "6"
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "7"
        Else
            TextCodigoVendedor.Text = "7"
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "8"
        Else
            TextCodigoVendedor.Text = "8"
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "9"
        Else
            TextCodigoVendedor.Text = "9"
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "0"
        Else
            TextCodigoVendedor.Text = "0"
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs)
        If (TextCodigoVendedor.Text.Length > 0) Then
            TextCodigoVendedor.Text = TextCodigoVendedor.Text & "."
        Else
            TextCodigoVendedor.Text = "."
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Try
            Dim LARGO As Integer
            If (TextCodigoVendedor.Text <> "") Then
                LARGO = TextCodigoVendedor.Text.Length
                TextCodigoVendedor.Text = Mid(TextCodigoVendedor.Text, 1, LARGO - 1)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class