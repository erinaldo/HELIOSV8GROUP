Imports System.Drawing.Drawing2D

Public Class CirclePictureBox
    Inherits PictureBox

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g As New GraphicsPath
        g.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height)
        Me.Region = New Region(g)
        MyBase.OnPaint(pe)
    End Sub

End Class
