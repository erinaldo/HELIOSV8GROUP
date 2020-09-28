Public Class FormAsignarCantidadVenta

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextCantidad.Select()
        TextCantidad.SelectAll()

    End Sub
    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If TextCantidad.DecimalValue > 0 Then
            Tag = TextCantidad.DecimalValue
            Close()
        Else
            MessageBox.Show("Debe indícar una cantidad mayor a cero!", "Verificar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextCantidad.Select()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Tag = 0
        Close()
    End Sub
End Class