Imports Syncfusion.Windows.Forms
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Public Class RoundButton2
    Inherits ButtonAdv
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        Dim grPath As New GraphicsPath()
        grPath = Create(0, 0, ClientSize.Width, ClientSize.Height, 12, RectangleCorners.All)
        grPath.FillMode = System.Drawing.Drawing2D.FillMode.Alternate
        Me.Region = New System.Drawing.Region(grPath)
        MyBase.OnPaint(e)
    End Sub

    Public Function Create(x As Integer, y As Integer, width As Integer, height As Integer, radius As Integer, corners As RectangleCorners) As GraphicsPath
        Dim xw As Integer = x + width
        Dim yh As Integer = y + height
        Dim xwr As Integer = xw - radius
        Dim yhr As Integer = yh - radius
        Dim xr As Integer = x + radius
        Dim yr As Integer = y + radius
        Dim r2 As Integer = radius * 2
        Dim xwr2 As Integer = xw - r2
        Dim yhr2 As Integer = yh - r2

        Dim p As New GraphicsPath()
        p.StartFigure()

        'Top Left Corner
        If (RectangleCorners.TopLeft And corners) = RectangleCorners.TopLeft Then
            p.AddArc(x, y, r2, r2, 180, 90)
        Else
            p.AddLine(x, yr, x, y)
            p.AddLine(x, y, xr, y)
        End If

        'Top Edge
        p.AddLine(xr, y, xwr, y)

        'Top Right Corner
        If (RectangleCorners.TopRight And corners) = RectangleCorners.TopRight Then
            p.AddArc(xwr2, y, r2, r2, 270, 90)
        Else
            p.AddLine(xwr, y, xw, y)
            p.AddLine(xw, y, xw, yr)
        End If

        'Right Edge
        p.AddLine(xw, yr, xw, yhr)

        'Bottom Right Corner
        If (RectangleCorners.BottomRight And corners) = RectangleCorners.BottomRight Then
            p.AddArc(xwr2, yhr2, r2, r2, 0, 90)
        Else
            p.AddLine(xw, yhr, xw, yh)
            p.AddLine(xw, yh, xwr, yh)
        End If

        'Bottom Edge
        p.AddLine(xwr, yh, xr, yh)

        'Bottom Left Corner
        If (RectangleCorners.BottomLeft And corners) = RectangleCorners.BottomLeft Then
            p.AddArc(x, yhr2, r2, r2, 90, 90)
        Else
            p.AddLine(xr, yh, x, yh)
            p.AddLine(x, yh, x, yhr)
        End If

        'Left Edge
        p.AddLine(x, yhr, x, yr)

        p.CloseFigure()
        Return p
    End Function

    Public Enum RectangleCorners
        None = 0
        TopLeft = 1
        TopRight = 1
        BottomLeft = 1
        BottomRight = 1
        All = TopLeft Or TopRight Or BottomLeft Or BottomRight
    End Enum

End Class
