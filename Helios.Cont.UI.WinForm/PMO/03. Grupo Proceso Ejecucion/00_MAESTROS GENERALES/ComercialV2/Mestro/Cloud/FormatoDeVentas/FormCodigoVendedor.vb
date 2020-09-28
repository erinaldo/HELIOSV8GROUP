Imports Helios.General
Public Class FormCodigoVendedor
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
End Class