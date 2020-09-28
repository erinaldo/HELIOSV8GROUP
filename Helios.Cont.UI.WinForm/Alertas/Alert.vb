Imports Helios.General.Constantes

Public Class Alert
    Dim interval = 0
    Public Sub New(message As String, type As alertType)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblMessage.Text = message
        Select Case type
            Case alertType.success
                BackColor = Color.FromArgb(18, 137, 32)
                PictureBox1.Image = ImageList1.Images(0)
            Case alertType.info
                BackColor = Color.Gray
                PictureBox1.Image = ImageList1.Images(1)
            Case alertType.warning
                BackColor = Color.FromArgb(205, 140, 38)
                PictureBox1.Image = ImageList1.Images(2)
            Case alertType.Errors
                BackColor = Color.FromArgb(187, 42, 19)
                PictureBox1.Image = ImageList1.Images(3)
        End Select
    End Sub

    Private Sub Alert_Load(sender As Object, e As EventArgs) Handles Me.Load
        Top = -1 * (Height)
        Left = Screen.PrimaryScreen.Bounds.Width - Width - 60
        showx.Start()
    End Sub

    Private Sub closex_Tick(sender As Object, e As EventArgs) Handles closex.Tick
        If Opacity > 0 Then
            Opacity -= 0.1
        Else
            Close()
        End If
    End Sub

    Private Sub showx_Tick(sender As Object, e As EventArgs) Handles showx.Tick
        If Top < 60 Then
            Top += interval
            interval += 2
        Else
            showx.Stop()
        End If
    End Sub

    Private Sub timeout_Tick(sender As Object, e As EventArgs) Handles timeout.Tick
        Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        closex.Start()
    End Sub
End Class