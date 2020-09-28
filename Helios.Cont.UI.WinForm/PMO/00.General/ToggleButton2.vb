Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Collections
Imports System.IO
Public Class ToggleButton2
    Inherits Control
#Region "variables"
    Private f As FileInfo
    Private contentRectangle As Rectangle = Rectangle.Empty
    Private pts2 As Point() = New Point(3) {}
    Private controlBounds As Rectangle = Rectangle.Empty
    Private justRefresh As Boolean = False

#End Region

    Public Sub New()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.SupportsTransparentBackColor, True)
        f = FindApplicationFile("screw.png")
    End Sub


    Dim r As New Rectangle
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        controlBounds = e.ClipRectangle
        e.Graphics.ResetClip()
        Select Case ToggleStyle
            Case ToggleButtonStyle.Android
                Me.MinimumSize = New Size(75, 23)
                Me.MaximumSize = New Size(119, 32)
                contentRectangle = e.ClipRectangle
                Me.BackColor = Color.FromArgb(32, 32, 32)
                DrawAndroidStyle(e)
                Exit Select
            Case ToggleButtonStyle.Windows
                Me.MinimumSize = New Size(65, 23)
                Me.MaximumSize = New Size(119, 32)
                contentRectangle = New Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, Me.Width - 1, Me.Height - 1)
                DrawWindowsStyle(e)
                Exit Select
            Case ToggleButtonStyle.IOS
                Me.MinimumSize = New Size(93, 30)
                Me.MaximumSize = New Size(135, 51)
                Dim r As New Rectangle(0, 0, Me.Width, Me.Height)
                contentRectangle = r
                DrawIOSStyle(e)
                Exit Select
            Case ToggleButtonStyle.[Custom]
                Me.MinimumSize = New Size(160, 50)
                r = New Rectangle(2, 2, Me.Width - 3, Me.Height - 3)
                contentRectangle = r
                DrawCustomStyle(e)
                Exit Select
            Case ToggleButtonStyle.Metallic
                Me.MinimumSize = New Size(93, 30)
                Me.MaximumSize = New Size(135, 45)
                r = New Rectangle(0, 0, Me.Width, Me.Height)
                contentRectangle = r
                DrawMetallicStyle(e)
                Exit Select
        End Select
        MyBase.OnPaint(e)
    End Sub

#Region "AndroidStyle"
    Private andPoints As Point() = New Point(3) {}
    Private p1 As Point, p2 As Point, p3 As Point, p4 As Point
    Private Function AndroidPoints() As Point()
        p1 = New Point(padx, contentRectangle.Y)
        If padx = 0 Then
            p2 = New Point(padx, contentRectangle.Bottom)
        Else
            p2 = New Point(padx - SlidingAngle, contentRectangle.Bottom)
        End If

        p4 = New Point(p1.X + (contentRectangle.Width / 2), contentRectangle.Y)

        p3 = New Point(p4.X - SlidingAngle, contentRectangle.Bottom)
        If p4.X = contentRectangle.Right Then
            p3 = New Point(p4.X, contentRectangle.Bottom)
        End If

        andPoints(0) = p1
        andPoints(1) = p2
        andPoints(2) = p3
        andPoints(3) = p4
        Return andPoints




    End Function

    Private Sub DrawAndroidStyle(e As PaintEventArgs)
        e.Graphics.ResetClip()
        Dim val As Single = 7.0F
        Dim f As New Font("Microsoft Sans Serif", val)
        contentRectangle = e.ClipRectangle
        If Not isMouseMoved Then
            If Me.ToggleState = ToggleButtonState.[ON] Then
                padx = Me.contentRectangle.Right - (Me.contentRectangle.Width / 2)
            Else
                padx = 0
            End If
        End If
        Using sb As New SolidBrush(Me.BackColor)
            e.Graphics.FillRectangle(sb, e.ClipRectangle)
        End Using
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Dim clr As Color
        If padx = 0 Then
            clr = Me.InActiveColor
        Else
            clr = Me.ActiveColor
        End If
        Using sb As New SolidBrush(clr)
            e.Graphics.FillPolygon(sb, AndroidPoints())
        End Using
        If padx = 0 Then
            e.Graphics.DrawString(Me.InActiveText, f, Brushes.White, New PointF(padx + ((contentRectangle.Width / 2) / 6), contentRectangle.Y + (contentRectangle.Height / 4)))
        Else
            e.Graphics.DrawString(Me.ActiveText, f, Brushes.White, New PointF(padx + ((contentRectangle.Width / 2) / 4), contentRectangle.Y + (contentRectangle.Height / 4)))
        End If
    End Sub

#End Region

#Region "Windows style"
    Private ReadOnly Property WindowSliderBounds() As Rectangle
        Get
            Dim rect As Rectangle = Rectangle.Empty
            If sliderPoint.X > controlBounds.Right - 15 Then
                sliderPoint.X = controlBounds.Right - 15
            End If
            If sliderPoint.X < controlBounds.Left Then
                sliderPoint.X = controlBounds.Left
            End If
            rect = New Rectangle(sliderPoint.X, controlBounds.Y, 15, Me.Height)
            Return rect
        End Get
    End Property


    ''' <summary>
    ''' make sure the diff in rect is acceptable
    ''' </summary>
    ''' <param name="e"></param>
    Private Sub DrawWindowsStyle(e As PaintEventArgs)
        contentRectangle = New Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, Me.Width - 1, Me.Height - 1)
        If Not isMouseMoved Then
            If Me.ToggleState = ToggleButtonState.[ON] Then
                sliderPoint = New Point(controlBounds.Right - 15, sliderPoint.Y)
            Else
                sliderPoint = New Point(controlBounds.Left, sliderPoint.Y)
            End If
        End If
        Dim p As New Pen(Color.FromArgb(159, 159, 159))

        p.Width = 1.9F
        e.Graphics.DrawRectangle(p, contentRectangle)
        e.Graphics.DrawRectangle(p, Rectangle.Inflate(contentRectangle, -3, -3))
        Dim r1 As New Rectangle(Rectangle.Inflate(contentRectangle, -3, -3).Left, Rectangle.Inflate(contentRectangle, -3, -3).Y, WindowSliderBounds.Left - Rectangle.Inflate(contentRectangle, -3, -3).Left, Rectangle.Inflate(contentRectangle, -3, -3).Height)
        Dim r2 As New Rectangle(WindowSliderBounds.Right, r1.Y, Rectangle.Inflate(contentRectangle, -3, -3).Right - WindowSliderBounds.Right, r1.Height)

        Using sb As New SolidBrush(Me.ActiveColor)
            e.Graphics.FillRectangle(sb, r1)
        End Using
        Using sb As New SolidBrush(Me.SliderColor)
            e.Graphics.FillRectangle(sb, WindowSliderBounds)
        End Using
        Using sb As New SolidBrush(Me.InActiveColor)
            e.Graphics.FillRectangle(sb, r2)
        End Using

        Me.BackColor = Color.White
    End Sub

#End Region

#Region "IOS Style"
    Private Sub DrawIOSStyle(e As PaintEventArgs)

        Me.BackColor = Color.Transparent
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality

        Dim r As New Rectangle(0, 0, Me.Width, Me.Height)
        contentRectangle = r
        If Not isMouseMoved Then
            If Me.ToggleState = ToggleButtonState.[ON] Then
                ipadx = Me.contentRectangle.Right - (Me.contentRectangle.Height - 3)
            Else
                ipadx = 2
            End If
        End If
        Dim rect As New Rectangle(ipadx, r.Y, r.Height - 5, r.Height)
        Dim r2 As New Rectangle(Me.Width / 6 - 10, Me.Height / 2, (Me.Width / 6 - 10) + (rect.X + rect.Width / 2), Me.Height / 2)

        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
        Dim d As Integer = Me.Height
        gp.AddArc(r.X, r.Y, d, d, 180, 90)
        gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90)
        gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90)
        Me.Region = New Region(gp)
        '#Region "inner Rounded Rectangle"

        Dim gp2 As New System.Drawing.Drawing2D.GraphicsPath()
        d = Me.Height / 2
        gp2.AddArc(r2.X, r2.Y, d, d, 180, 90)
        gp2.AddArc(r2.X + r2.Width - d, r2.Y, d, d, 270, 90)
        gp2.AddArc(r2.X + r2.Width - d, r2.Y + r2.Height - d, d, d, 0, 90)
        gp2.AddArc(r2.X, r2.Y + r2.Height - d, d, d, 90, 90)

        '#End Region

        If ipadx < contentRectangle.Width / 2 Then
            iosSelected = False
        ElseIf ipadx = contentRectangle.Right - (contentRectangle.Height - 3) OrElse ipadx > contentRectangle.Width / 2 Then
            iosSelected = True
        End If


        Dim ar1 As New Rectangle(r.X, r.Y, r.X + rect.Right, r.Height)
        Dim ar2 As New Rectangle(rect.X + rect.Width / 2, r.Y, (rect.X + rect.Width / 2) + r.Right, r.Height)

        ' br3 - inner rect
        Dim br3 As New LinearGradientBrush(ar1, Color.FromArgb(255, 96, 174, 241), Color.FromArgb(255, 96, 174, 241), LinearGradientMode.Vertical)

        'br - outer rect
        Dim br As New LinearGradientBrush(ar1, Color.FromArgb(0, 127, 234), Color.FromArgb(96, 174, 241), LinearGradientMode.Vertical)

        e.Graphics.FillRectangle(br, ar1)

        e.Graphics.FillPath(br3, gp2)


        '#Region "Inactive path"

        '#Region "inner Rounded Rectangle"

        r2 = New Rectangle((rect.X + rect.Width / 2), Me.Height / 2, (((Me.Width / 2) + (Me.Width / 4)) - (rect.X + rect.Width / 2)) + Me.Height / 2, Me.Height / 2)
        '4 * (this.Width / 6) + 20
        gp2 = New System.Drawing.Drawing2D.GraphicsPath()
        d = Me.Height / 2
        gp2.AddArc(r2.X, r2.Y, d, d, 180, 90)
        gp2.AddArc(r2.X + r2.Width - d, r2.Y, d, d, 270, 90)
        gp2.AddArc(r2.X + r2.Width - d, r2.Y + r2.Height - d, d, d, 0, 90)
        gp2.AddArc(r2.X, r2.Y + r2.Height - d, d, d, 90, 90)
        '#End Region

        br3 = New LinearGradientBrush(ar2, Color.FromArgb(238, 238, 238), Color.LightGray, LinearGradientMode.Vertical)

        'br - outer rect
        br = New LinearGradientBrush(ar2, Color.FromArgb(238, 238, 238), Color.Silver, LinearGradientMode.Vertical)

        e.Graphics.FillRectangle(br, ar2)

        e.Graphics.FillPath(br3, gp2)


        '#End Region

        If iosSelected Then
            e.Graphics.DrawString(Me.ActiveText, Font, Brushes.White, New PointF(r.Width / 4, contentRectangle.Y + (contentRectangle.Height / 4)))
        Else
            e.Graphics.DrawString(Me.InActiveText, Font, New SolidBrush(Color.FromArgb(123, 123, 123)), New PointF(r.Width / 2, contentRectangle.Y + (contentRectangle.Height / 4)))
        End If



        '#Region "Center Ellipse"
        Dim c As Color = If(Me.Parent IsNot Nothing, Me.Parent.BackColor, Color.White)
        e.Graphics.DrawEllipse(New Pen(Color.LightGray, 2.0F), rect)
        Dim br2 As New LinearGradientBrush(rect, Color.White, Color.Silver, LinearGradientMode.Vertical)
        e.Graphics.FillEllipse(br2, rect)
        '#End Region

        e.Graphics.DrawPath(New Pen(c, 2.0F), gp)

        e.Graphics.ResetClip()
    End Sub

    Protected Overridable Sub FillShape(g As Graphics, brush As [Object], path As GraphicsPath)
        If brush.[GetType]().ToString() = "System.Drawing.Drawing2D.LinearGradientBrush" Then
            g.FillPath(DirectCast(brush, LinearGradientBrush), path)
        ElseIf brush.[GetType]().ToString() = "System.Drawing.Drawing2D.PathGradientBrush" Then
            g.FillPath(DirectCast(brush, PathGradientBrush), path)
        End If
    End Sub
#End Region

#Region "Metallic Style"
    Private _reflectionColor As Color = Color.FromArgb(180, 255, 255, 255)
    Private _surroundColor As Color() = New Color() {Color.FromArgb(0, 255, 255, 255)}
    Private Sub DrawMetallicStyle(e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality

        Dim r As New Rectangle(0, 0, Me.Width, Me.Height)
        contentRectangle = r
        If Not isMouseMoved Then
            If Me.ToggleState = ToggleButtonState.[ON] Then
                ipadx = Me.contentRectangle.Right - (Me.contentRectangle.Height - 3)
            Else
                ipadx = 2
            End If
        End If
        Dim rect As New Rectangle(ipadx, r.Y, r.Height - 5, r.Height)
        Dim r2 As New Rectangle(Me.Width / 6 - 10, Me.Height / 2, (Me.Width / 6 - 10) + (rect.X + rect.Width / 2), Me.Height / 2)

        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
        Dim d As Integer = Me.Height
        gp.AddArc(r.X, r.Y, d, d, 180, 90)
        gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90)
        gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90)
        Me.Region = New Region(gp)


        If ipadx < contentRectangle.Width / 2 Then
            iosSelected = False
        ElseIf ipadx = contentRectangle.Right - (contentRectangle.Height - 3) OrElse ipadx > contentRectangle.Width / 2 Then
            iosSelected = True
        End If

        Dim ar1 As New Rectangle(r.X, r.Y, r.X + rect.Right, r.Height)
        Dim ar2 As New Rectangle(rect.X + rect.Width / 2, r.Y, (rect.X + rect.Width / 2) + r.Right, r.Height)

        Dim br As New SolidBrush(Me.ActiveColor)

        e.Graphics.FillRectangle(br, ar1)

        '#Region "Inactive path"

        br = New SolidBrush(Me.InActiveColor)
        e.Graphics.FillRectangle(br, ar2)

        '#End Region

        If iosSelected Then
            e.Graphics.DrawString(Me.ActiveText, Font, New SolidBrush(TextColor), New PointF(contentRectangle.X + 8, contentRectangle.Y + (contentRectangle.Height / 4)))
        Else
            e.Graphics.DrawString(Me.InActiveText, Font, New SolidBrush(TextColor), New PointF(rect.Right + 5, contentRectangle.Y + (contentRectangle.Height / 4)))
        End If



        '#Region "Center Ellipse"
        Dim c As Color = If(Me.Parent IsNot Nothing, Me.Parent.BackColor, Color.White)
        Dim br2 As New SolidBrush(InActiveColor)
        If Me.ToggleState = ToggleButtonState.[ON] Then
            br2.Color = Me.ActiveColor
        End If
        e.Graphics.DrawEllipse(New Pen(br2.Color), rect)
        e.Graphics.FillEllipse(br2, rect)
        '#End Region

        e.Graphics.DrawPath(New Pen(c, 2.0F), gp)
        If Not Me.DesignMode Then
            Dim img As Image = Image.FromFile(f.FullName)
            e.Graphics.DrawImage(img, rect)
        End If
    End Sub
#End Region

#Region "Custom Style"
    Private tPadx As Integer
    Private custInnerRect As RectangleF, staticInnerRect As RectangleF
    Private Sub DrawCustomStyle(e As PaintEventArgs)
        Me.BackColor = Color.FromArgb(43, 43, 45)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality

        Dim r As New Rectangle(0, 0, Me.Width, Me.Height)
        contentRectangle = r


        '#Region "Parent RoundedRect"

        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
        Dim d As Integer = Me.Height
        gp.AddArc(r.X, r.Y, d, d, 180, 90)
        gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90)
        gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90)
        Me.Region = New Region(gp)

        Dim c As Color = If(Me.Parent IsNot Nothing, Me.Parent.BackColor, Color.White)
        e.Graphics.DrawPath(New Pen(c, 2.0F), gp)

        '#End Region

        Dim p1 As New Point(r.Width / 4, r.Y)
        Dim p2 As New Point(r.X + (r.Width / 4 + r.Width / 2), r.Y)

        '#Region "inner Rounded Rectangle"
        Dim r2 As New Rectangle(p1.X, Me.Height / 2 - (r.Height / 8), p2.X - p1.X, r.Height / 6)

        Dim gp2 As New System.Drawing.Drawing2D.GraphicsPath()
        d = Me.Height / 6
        gp2.AddArc(r2.X, r2.Y, d, d, 180, 90)
        gp2.AddArc(r2.X + r2.Width - d, r2.Y, d, d, 270, 90)
        gp2.AddArc(r2.X + r2.Width - d, r2.Y + r2.Height - d, d, d, 0, 90)
        gp2.AddArc(r2.X, r2.Y + r2.Height - d, d, d, 90, 90)
        Dim irp As RectangleF = gp2.GetBounds()
        staticInnerRect = New RectangleF(irp.X, irp.Y, irp.Width, irp.Height)

        If Not isMouseMoved Then
            If Me.ToggleState = ToggleButtonState.[ON] Then
                tPadx = CInt(staticInnerRect.Right) - 20
            Else
                tPadx = CInt(staticInnerRect.X)
            End If
        End If

        custInnerRect = New RectangleF(tPadx, irp.Y, irp.Width, irp.Height)
        '#End Region

        e.Graphics.DrawPath(New Pen(Color.FromArgb(64, 64, 64), 2.0F), gp2)
        Using brs As New LinearGradientBrush(gp2.GetBounds(), Color.FromArgb(19, 19, 19), Color.FromArgb(64, 64, 64), LinearGradientMode.Vertical)
            e.Graphics.FillPath(brs, gp2)
            e.Graphics.DrawString(Me.InActiveText, Font, Brushes.Gray, New Point(r.X + 10, CInt(gp2.GetBounds().Y)))
            e.Graphics.DrawString(Me.ActiveText, Font, Brushes.Gray, New Point(CInt(gp2.GetBounds().Right) + 10, CInt(gp2.GetBounds().Y)))
        End Using

        '#Region "center shape"
        Dim cp1 As New Point(CInt(custInnerRect.X) + 12, CInt(irp.Y) - 9)
        Dim cp2 As New Point(CInt(custInnerRect.X) - 2, CInt(irp.Y))
        Dim cp3 As New Point(CInt(custInnerRect.X) + 3, CInt(irp.Bottom) + 7)
        Dim cp4 As New Point(CInt(custInnerRect.X) + 20, CInt(irp.Bottom) + 7)
        Dim cp5 As New Point(CInt(custInnerRect.X) + 24, CInt(irp.Y))

        Dim centerPoints As Point() = New Point() {cp1, cp2, cp3, cp4, cp5}
        e.Graphics.DrawPolygon(Pens.Black, centerPoints)

        Using brs As New LinearGradientBrush(cp1, cp3, Color.Gray, Color.Black)
            e.Graphics.FillPolygon(brs, centerPoints)
        End Using

        Dim x1 As Integer = cp3.X + (cp4.X - cp3.X) / 4
        If Me.ToggleState = ToggleButtonState.OFF Then
            e.Graphics.FillEllipse(New SolidBrush(Me.InActiveColor), x1, (cp2.Y), 10, 10)
        Else
            e.Graphics.FillEllipse(New SolidBrush(Me.ActiveColor), x1, (cp2.Y), 10, 10)
        End If


        '#End Region

    End Sub

    Private Function GetPolygonPoints(r As Rectangle) As Point()
        Dim pts As Point() = Nothing

        Dim p1 As New Point(ipadx, r.Y + (r.Height / 3))
        Dim p2 As New Point(p1.X + 40, r.Y)
        Dim p4 As New Point(p1.X + 20, r.Bottom)
        Dim p3 As New Point(p4.X + 40, r.Height - (r.Height / 3))
        Return InlineAssignHelper(pts, New Point() {p1, p2, p3, p4})
    End Function

#End Region

#Region "Event Handlers"

    Private iosSelected As Boolean = False

    Private dblclick As Boolean = False



    Public Event ButtonStateChanged As ToggleButtonStateChanged

    Protected Sub RaiseButtonStateChanged()
        RaiseEvent ButtonStateChanged(Me, New ToggleButtonStateEventArgs(Me.ToggleState))
    End Sub


    Public Delegate Sub ToggleButtonStateChanged(sender As Object, e As ToggleButtonStateEventArgs)

    Public Class ToggleButtonStateEventArgs
        Inherits EventArgs

        Public Sub New(ButtonState As ToggleButtonState)
        End Sub

        'Arguements Can be Included
    End Class

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        sliderPoint = downpos
        dblclick = Not dblclick
        switchrec = Not switchrec
        If Me.ToggleStyle = ToggleButtonStyle.Windows Then
            If WindowSliderBounds.X < (controlBounds.Width / 2) Then
                sliderPoint = New Point(controlBounds.Left, sliderPoint.Y)
                Me.ToggleState = ToggleButtonState.OFF
            Else
                sliderPoint = New Point(controlBounds.Right - 15, sliderPoint.Y)

                Me.ToggleState = ToggleButtonState.[ON]
            End If
        ElseIf Me.ToggleStyle = ToggleButtonStyle.Android Then
            If downpos.X <= contentRectangle.Width / 4 Then
                padx = contentRectangle.Left
                Me.ToggleState = ToggleButtonState.OFF
            Else
                padx = contentRectangle.Right - (contentRectangle.Width / 2)
                Me.ToggleState = ToggleButtonState.[ON]
            End If
        ElseIf Me.ToggleStyle = ToggleButtonStyle.IOS OrElse Me.ToggleStyle = ToggleButtonStyle.Metallic Then
            If downpos.X <= contentRectangle.Width / 4 Then
                ipadx = 2
                Me.ToggleState = ToggleButtonState.OFF
            Else
                ipadx = InlineAssignHelper(ipadx, contentRectangle.Right - (contentRectangle.Height - 3))
                Me.ToggleState = ToggleButtonState.[ON]
            End If
        ElseIf Me.ToggleStyle = ToggleButtonStyle.[Custom] Then
            tPadx = downpos.X
            If tPadx <= (staticInnerRect.X + staticInnerRect.Width / 2) Then
                tPadx = CInt(staticInnerRect.X)
                Me.ToggleState = ToggleButtonState.OFF
            ElseIf tPadx >= (staticInnerRect.X + staticInnerRect.Width / 2) Then
                tPadx = CInt(staticInnerRect.Right) - 20
                Me.ToggleState = ToggleButtonState.[ON]
            End If
        End If
        Me.Refresh()
    End Sub



    Private Function GetRectangle() As Rectangle
        Return New Rectangle(2, 2, Me.Width - 5, Me.Height - 5)


    End Function

    Private isMouseDown As Boolean = False
    Private downpos As Point = Point.Empty
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Not Me.DesignMode Then
            isMouseDown = True
            downpos = e.Location
        End If
        Me.Invalidate()
    End Sub
    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.Space Then
            If Me.ToggleState = ToggleButtonState.[ON] Then
                Me.ToggleState = ToggleButtonState.OFF
            Else
                Me.ToggleState = ToggleButtonState.[ON]
            End If
        End If
    End Sub
    Private isMouseMoved As Boolean = False
    Private sliderPoint As Point = Point.Empty
    Private padx As Integer = 0
    Private ipadx As Integer = 2
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If e.Button = MouseButtons.Left AndAlso Not Me.DesignMode Then
            sliderPoint = e.Location
            isMouseMoved = True
            If Me.ToggleStyle = ToggleButtonStyle.Android Then

                padx = e.X
                If padx <= contentRectangle.Left + SlidingAngle Then
                    padx = contentRectangle.Left
                    Me.ToggleState = ToggleButtonState.OFF
                End If

                If padx >= contentRectangle.Right - (contentRectangle.Width / 2) Then
                    padx = contentRectangle.Right - (contentRectangle.Width / 2)
                    Me.ToggleState = ToggleButtonState.[ON]
                End If
            ElseIf Me.ToggleStyle = ToggleButtonStyle.IOS OrElse Me.ToggleStyle = ToggleButtonStyle.Metallic Then
                ipadx = e.X
                If ipadx <= 2 Then
                    ipadx = 2
                    Me.ToggleState = ToggleButtonState.OFF
                End If

                If ipadx >= contentRectangle.Right - (contentRectangle.Height - 3) Then
                    ipadx = contentRectangle.Right - (contentRectangle.Height - 3)
                    Me.ToggleState = ToggleButtonState.[ON]
                End If
            ElseIf Me.ToggleStyle = ToggleButtonStyle.[Custom] Then
                tPadx = e.X
                If tPadx <= staticInnerRect.X Then
                    tPadx = CInt(staticInnerRect.X)
                    Me.ToggleState = ToggleButtonState.OFF
                End If

                If tPadx >= staticInnerRect.Right - 20 Then
                    tPadx = CInt(staticInnerRect.Right) - 20
                    Me.ToggleState = ToggleButtonState.[ON]
                End If
            End If
            Refresh()
        End If
    End Sub
    Private switchrec As Boolean = False
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If Not Me.DesignMode Then
            Me.Invalidate()
            If isMouseMoved Then
                If Me.ToggleStyle = ToggleButtonStyle.Windows Then
                    sliderPoint = e.Location

                    If WindowSliderBounds.X < (controlBounds.Width / 2) Then
                        sliderPoint = New Point(controlBounds.Left, sliderPoint.Y)
                        Me.ToggleState = ToggleButtonState.OFF
                    Else
                        sliderPoint = New Point(controlBounds.Right - 15, sliderPoint.Y)

                        Me.ToggleState = ToggleButtonState.[ON]
                    End If
                ElseIf Me.ToggleStyle = ToggleButtonStyle.Android Then
                    padx = e.Location.X
                    If padx < contentRectangle.Width / 4 Then
                        padx = contentRectangle.Left
                        Me.ToggleState = ToggleButtonState.OFF
                    Else
                        padx = contentRectangle.Right - (contentRectangle.Width / 2)
                        Me.ToggleState = ToggleButtonState.[ON]
                    End If
                ElseIf Me.ToggleStyle = ToggleButtonStyle.IOS OrElse Me.ToggleStyle = ToggleButtonStyle.Metallic Then
                    ipadx = e.Location.X
                    If ipadx < contentRectangle.Width / 2 Then
                        ipadx = 2
                        Me.ToggleState = ToggleButtonState.OFF
                    Else
                        ipadx = contentRectangle.Right - (contentRectangle.Height - 3)
                        Me.ToggleState = ToggleButtonState.[ON]
                    End If
                ElseIf Me.ToggleStyle = ToggleButtonStyle.[Custom] Then
                    tPadx = e.Location.X
                    If tPadx <= (staticInnerRect.X + staticInnerRect.Width / 2) Then
                        tPadx = CInt(staticInnerRect.X)
                        '
                        Me.ToggleState = ToggleButtonState.OFF
                    ElseIf tPadx >= (staticInnerRect.X + staticInnerRect.Width / 2) Then
                        tPadx = CInt(staticInnerRect.Right) - 20
                        Me.ToggleState = ToggleButtonState.[ON]
                    End If
                End If
                Invalidate()

                Update()
            End If

            isMouseMoved = False
            isMouseDown = False
        End If
    End Sub
#End Region

#Region "properties"
    Private m_activeText As String = "ON"
    Public Property ActiveText() As String
        Get
            Return m_activeText
        End Get
        Set(value As String)
            m_activeText = value
        End Set
    End Property

    Private m_inActiveText As String = "OFF"
    Public Property InActiveText() As String
        Get
            Return m_inActiveText
        End Get
        Set(value As String)
            m_inActiveText = value
        End Set
    End Property

    Private m_slidingAngle As Integer = 5
    Public Property SlidingAngle() As Integer
        Get
            Return m_slidingAngle
        End Get
        Set(value As Integer)
            m_slidingAngle = value
            Me.Refresh()
        End Set
    End Property


    Private m_activeColor As Color = Color.FromArgb(27, 161, 226)
    Public Property ActiveColor() As Color
        Get
            Return m_activeColor
        End Get
        Set(value As Color)
            m_activeColor = value
            Me.Refresh()
        End Set
    End Property

    Private m_sliderColor As Color = Color.Black
    Public Property SliderColor() As Color
        Get
            Return m_sliderColor
        End Get
        Set(value As Color)
            m_sliderColor = value
            Me.Refresh()
        End Set
    End Property
    Private m_textColor As Color = Color.White
    Public Property TextColor() As Color
        Get
            Return m_textColor
        End Get
        Set(value As Color)
            m_textColor = value
            Me.Refresh()
        End Set
    End Property
    Private m_inActiveColor As Color = Color.FromArgb(70, 70, 70)
    Public Property InActiveColor() As Color
        Get
            Return m_inActiveColor
        End Get
        Set(value As Color)
            m_inActiveColor = value
            Me.Refresh()
        End Set
    End Property

    Private m_toggleStyle As ToggleButtonStyle = ToggleButtonStyle.Android
    Public Property ToggleStyle() As ToggleButtonStyle
        Get
            Return m_toggleStyle
        End Get
        Set(value As ToggleButtonStyle)
            m_toggleStyle = value
            justRefresh = False
            Select Case value
                Case ToggleButtonStyle.Android
                    Me.Region = New Region(New Rectangle(0, 0, Me.Width, Me.Height))
                    Me.BackColor = Color.FromArgb(32, 32, 32)
                    Me.InActiveColor = Color.FromArgb(70, 70, 70)
                    Me.SlidingAngle = 8
                    Exit Select
                Case ToggleButtonStyle.IOS
                    Me.InActiveColor = Color.WhiteSmoke
                    Exit Select
            End Select

            Invalidate(True)
            Update()
            Me.Refresh()
        End Set
    End Property


    Private m_toggleState As ToggleButtonState = ToggleButtonState.OFF
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property ToggleState() As ToggleButtonState
        Get
            Return m_toggleState
        End Get
        Set(value As ToggleButtonState)
            If m_toggleState <> value Then
                RaiseButtonStateChanged()
                m_toggleState = value
                Invalidate()
                Me.Refresh()
            End If
        End Set
    End Property


    Private Sub RefreshToggleState(state As ToggleButtonState)
        Me.ToggleState = state
        justRefresh = True
    End Sub
    Public Enum ToggleButtonState
        ''' <summary>
        ''' Opcion ON
        ''' </summary>
        ''' <remarks></remarks>
        [ON]

        ''' <summary>
        ''' Opcion OFF
        ''' </summary>
        ''' <remarks></remarks>
        OFF
    End Enum


    Public Enum ToggleButtonStyle
        Android
        Windows
        IOS
        [Custom]
        Metallic
    End Enum
#End Region

#Region "Other"
    Public Shared Function FindApplicationFile(fileName As String) As FileInfo
        Dim startPath As String = Path.Combine(Application.StartupPath, fileName)
        Dim file As New FileInfo(startPath)
        While Not file.Exists
            If file.Directory.Parent Is Nothing Then
                Return Nothing
            End If
            Dim parentDir As DirectoryInfo = file.Directory.Parent
            file = New FileInfo(Path.Combine(parentDir.FullName, file.Name))
        End While
        Return file
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

#End Region
End Class
