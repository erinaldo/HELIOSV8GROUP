Public Class frmStatus

    Public Overloads Sub Show(ByVal message As String)
        lblStatus.Text = message
        If Tag = "CEX" Then
            Me.StartPosition = FormStartPosition.CenterParent
            Me.ShowDialog()
        Else
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Show()
        End If
        Application.DoEvents()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Tag = "CEX" Then
            Me.Text = "Done.!"
            Me.Close()
        End If
    End Sub

    Private Sub frmStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class