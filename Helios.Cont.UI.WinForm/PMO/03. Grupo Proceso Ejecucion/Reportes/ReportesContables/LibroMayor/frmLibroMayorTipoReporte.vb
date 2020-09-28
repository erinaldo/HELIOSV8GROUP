Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class frmLibroMayorTipoReporte
    Public listaCuenta As New List(Of String)
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        With frmReporteLibroMayor
            If (rbTodo.Checked = True) Then
                '.listaDeReporteLibroMayorFull(listaCuenta)
                        .StartPosition = FormStartPosition.CenterScreen
                .Show()
                Me.Dispose()
            ElseIf (rbPorCuenta.Checked = True) Then
                If (cboCuentas.SelectedItem = True) Then
                    .listaDeReporteLibroMayorPorCuenta(cboCuentas.SelectedItem.ToString)
                    .StartPosition = FormStartPosition.CenterScreen
                    .Show()
                    Me.Dispose()
                End If
            End If
        End With
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbPorCuenta.CheckedChanged
        cboCuentas.Enabled = True
        cboCuentas.Items.Clear()
        For Each lista In listaCuenta

            cboCuentas.Items.Add(lista)
        Next
    End Sub

    Private Sub rbTodo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbTodo.CheckedChanged
        cboCuentas.Enabled = False
    End Sub
End Class