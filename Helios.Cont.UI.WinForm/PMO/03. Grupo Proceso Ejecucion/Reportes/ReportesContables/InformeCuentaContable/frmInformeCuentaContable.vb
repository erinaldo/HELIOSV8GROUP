Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class frmInformeCuentaContable

    Sub llenarCuentas(strCuenta As List(Of String))
        cboCuentas.Items.Clear()
        txtClase.Clear()
        For Each lista In strCuenta
            cboCuentas.Items.Add(lista)
        Next
    End Sub

    Private Sub cboCuentas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCuentas.SelectedIndexChanged
        Dim compraSA As New MovimientoSA
        cboRazonSocial.Items.Clear()
        cboRazonSocial.Text = String.Empty
        For Each lista In compraSA.GetUbicarMovimiento(cboCuentas.SelectedItem)
            cboRazonSocial.Items.Add(lista.nombreEntidad)
            txtClase.Text = lista.descripcion
        Next
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If (cboRazonSocial.Text.Length > 0) Then
            With frmInformeCuentaContableReporte
                .listaDeReporteInformePorCuentaContable(cboCuentas.SelectedItem, cboRazonSocial.SelectedItem)
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            End With
            Me.Dispose()
        End If
    End Sub
End Class
