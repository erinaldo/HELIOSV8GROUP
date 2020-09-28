Public Class FormLogisticaMenu

    Public Property TabLG_LogEntradaMenu As TabLG_LogEntradaMenu

    Private Sub BtDashBoard_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        PanelBody.Controls.Clear()
        TabLG_LogEntradaMenu = New TabLG_LogEntradaMenu() With {
            .Dock = DockStyle.Fill
        }
        TabLG_LogEntradaMenu.BringToFront()
        PanelBody.Controls.Add(TabLG_LogEntradaMenu)
    End Sub

    Private Sub FormLogisticaMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
    End Sub
End Class