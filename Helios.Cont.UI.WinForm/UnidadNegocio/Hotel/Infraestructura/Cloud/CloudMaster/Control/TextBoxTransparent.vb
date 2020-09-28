Public Class TextBoxTransparent
    Inherits TextBox

    Public Sub New()

        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)

        BackColor = Color.Transparent

    End Sub

End Class
