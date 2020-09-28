Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Public Class Line2
    Inherits Control

    Private m_LineColor As Color = Color.Black

    ''' <summary>
    ''' Gets or sets the color of the divider line
    ''' </summary>
    <Category("Appearance")>
    <Description("Gets or sets the color of the divider line")>
    Public Property LineColor() As Color
        Get
            Return m_LineColor
        End Get
        Set
            m_LineColor = Value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Using brush As New SolidBrush(LineColor)
            pe.Graphics.FillRectangle(brush, pe.ClipRectangle)
        End Using
    End Sub

End Class
