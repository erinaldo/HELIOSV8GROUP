Imports Helios.General
Public Class FrmReferenciaAlSustento2

    Private Sub Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Aceptar.Click
        Dim n As New RecuperarDatosPlaneamiento()
        Dim datos As List(Of RecuperarDatosPlaneamiento) = RecuperarDatosPlaneamiento.Instance()
        datos.Clear()
        If CheckBox1.Checked = True Then
            n.TipoSustento = TipoReferenciaSustento.COSTO_IGV
        ElseIf CheckBox2.Checked = True Then
            n.TipoSustento = TipoReferenciaSustento.SOLO_COSTO
        ElseIf CheckBox3.Checked = True Then
            n.TipoSustento = TipoReferenciaSustento.NO_SUSTENTADO
        End If
        n.Monto2 = 0
        datos.Add(n)
        Dispose()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False
        End If
    End Sub
End Class