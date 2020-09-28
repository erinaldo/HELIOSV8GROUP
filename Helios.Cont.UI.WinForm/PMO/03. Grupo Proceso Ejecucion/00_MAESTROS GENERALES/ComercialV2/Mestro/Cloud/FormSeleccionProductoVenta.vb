Public Class FormSeleccionProductoVenta
    Private Sub ChMenor_OnChange(sender As Object, e As EventArgs) Handles ChMenor.OnChange
        If ChMenor.Checked Then
            ChMayor.Checked = False
            ChGranMayor.Checked = False
        End If
    End Sub

    Private Sub ChMayor_OnChange(sender As Object, e As EventArgs) Handles ChMayor.OnChange
        If ChMayor.Checked Then
            ChMenor.Checked = False
            ChGranMayor.Checked = False
        End If
    End Sub

    Private Sub ChGranMayor_OnChange(sender As Object, e As EventArgs) Handles ChGranMayor.OnChange
        If ChGranMayor.Checked Then
            ChMayor.Checked = False
            ChMenor.Checked = False
        End If
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click

    End Sub
End Class