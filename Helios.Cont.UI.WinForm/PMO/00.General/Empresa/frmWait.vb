Public Class frmWait

    'Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
    '    Timer1.Interval = 250
    '    Dim scr = Screen.FromPoint(Me.Location)
    '    Me.Location = New Point(scr.WorkingArea.Right - Me.Width, scr.WorkingArea.Top)
    '    MyBase.OnLoad(e)
    'End Sub

    Private Sub frmWait_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Timer1.Start()
    End Sub

    Private Sub frmWait_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = 250
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Now.TimeOfDay.Ticks
        Application.DoEvents()
    End Sub
End Class