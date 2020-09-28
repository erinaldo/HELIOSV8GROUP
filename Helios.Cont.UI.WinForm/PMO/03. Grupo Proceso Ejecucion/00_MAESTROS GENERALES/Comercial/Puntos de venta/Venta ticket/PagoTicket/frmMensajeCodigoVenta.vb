Public Class frmMensajeCodigoVenta

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Timer1.Enabled = True
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub
    Dim time As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        time += 1000
        If time = 1000 Then

        End If

        If time >= 4000 Then
            '  Timer3.Stop()
            'statusForm.Dispose()
            'Dispose()
            Dispose()
        Else

        End If
    End Sub
End Class