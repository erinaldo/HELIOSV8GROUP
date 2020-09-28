Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes

Public Class FormCalculoUM
    Dim PrecioUnitario As Double
    Dim PrecioTotal As Decimal
    Dim centimetro1 As Double
    Dim centimetro2 As Double
    Dim perimetroTotal As Double
    Public DocumentoID As Integer

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dispose()
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Dim documento As New documentoventaAbarrotesDet

        If (CDec(txtTotalPies.Text) > 0) Then
            documento.importeMN = txtTotalPies.Text
            Me.Tag = documento
            Dispose()
        Else
            MessageBox.Show("Verifique correctamente el ingreso", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        centimetro1 = txtMedida1.Value
        centimetro2 = txtMedida2.Value

        If (centimetro1 > 0 And centimetro2 > 0 And txtCantidad.Value > 0) Then
            perimetroTotal = (centimetro1 * centimetro2) / 900

            txtTotalPies.Text = Math.Round((perimetroTotal) * txtCantidad.Value, 4)
        Else
            MessageBox.Show("Debe Ingresar datos correctos", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub txtMedida1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMedida1.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub FormCalculoUM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMedida1.Select()
        txtMedida1.Select(0, txtMedida1.Text.Length)
    End Sub

    Private Sub txtMedida1_Click(sender As Object, e As EventArgs) Handles txtMedida1.Click
        txtMedida1.Select()
        txtMedida1.Select(0, txtMedida1.Text.Length)
    End Sub

    Private Sub txtMedida2_Click(sender As Object, e As EventArgs) Handles txtMedida2.Click
        txtMedida2.Select()
        txtMedida2.Select(0, txtMedida2.Text.Length)
    End Sub

    Private Sub txtMedida1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMedida1.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtMedida2.Select()
            txtMedida2.Select(0, txtMedida2.Text.Length)
        End If

    End Sub

    Private Sub txtMedida2_ValueChanged(sender As Object, e As EventArgs) Handles txtMedida2.ValueChanged

    End Sub

    Private Sub txtCantidad_Click(sender As Object, e As EventArgs) Handles txtCantidad.Click
        txtCantidad.Select()
        txtCantidad.Select(0, txtCantidad.Text.Length)
    End Sub

    Private Sub txtMedida2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMedida2.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtCantidad.Select()
            txtCantidad.Select(0, txtCantidad.Text.Length)
        End If
    End Sub
End Class
