Public Class UCOperacionVenta
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If ListView1.SelectedItems.Count > 0 Then

            Select Case ListView1.SelectedItems(0).Text
                Case "Venta en soles"
                    Dim f As New FormVentaNueva
                    f.ComboComprobante.Text = "VENTA"
                    f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "NUEVO SOL"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Show(Me)
                Case "Venta en dolares"
                    Dim f As New FormVentaNueva
                    f.ComboComprobante.Text = "VENTA"
                    f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Show(Me)
            End Select
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class
