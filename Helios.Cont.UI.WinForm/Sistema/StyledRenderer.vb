#Region "Copyright Syncfusion Inc. 2001 - 2014"
' Copyright Syncfusion Inc. 2001 - 2014. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region
Imports Syncfusion.Windows.Forms.Tools
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Public Class StyledRenderer
    Implements IToggleButtonRenderer

    Private m_toggleButton As ToggleButton

#Region "IToggleButtonRenderer Members"

    Public Sub DrawButton(e As PaintEventArgs, toggleState As ToggleButtonState, displayMode As DisplayType, font As Font, activeState As ActiveStateCollection, inactiveState As InactiveStateCollection, _
     righttoLeft As RightToLeft, isMouseHover As Boolean, togglebutton As ToggleButton) Implements Syncfusion.Windows.Forms.Tools.IToggleButtonRenderer.DrawButton
        Dim displaytext As String = If(toggleState = ToggleButtonState.Active, activeState.Text, inactiveState.Text)
        Dim textsize As SizeF = e.Graphics.MeasureString(displaytext, font)
        Dim controlrect As New Rectangle(e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 4, e.ClipRectangle.Height - 4)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim gp As New GraphicsPath()
        Using br As New LinearGradientBrush(e.ClipRectangle, ColorTranslator.FromHtml("#007feb"), ColorTranslator.FromHtml("#51a7f2"), LinearGradientMode.Vertical)
            If controlrect.Height > 1 Then
                gp.AddArc(controlrect.X, controlrect.Y, controlrect.Height, controlrect.Height, 180, 90)
                gp.AddArc(controlrect.X + controlrect.Width - controlrect.Height, controlrect.Y, controlrect.Height, controlrect.Height, 270, 90)
                gp.AddArc(controlrect.X + controlrect.Width - controlrect.Height, controlrect.Y + controlrect.Height - controlrect.Height, controlrect.Height, controlrect.Height, 0, 90)
                gp.AddArc(controlrect.X, controlrect.Y + controlrect.Height - controlrect.Height, controlrect.Height, controlrect.Height, 90, 90)
                gp.CloseFigure()
                e.Graphics.DrawPath(New Pen(ColorTranslator.FromHtml("#002f69"), 2), gp)
            End If
        End Using
        Dim gp1 As New GraphicsPath()
        Using br As New LinearGradientBrush(e.ClipRectangle, ColorTranslator.FromHtml("#007feb"), ColorTranslator.FromHtml("#51a7f2"), LinearGradientMode.Vertical)
            If controlrect.Height > 1 Then
                gp1.AddArc(controlrect.X, controlrect.Y + 1, controlrect.Height + 2, controlrect.Height, 180, 90)
                gp1.AddArc(controlrect.X + controlrect.Width - controlrect.Height, controlrect.Y, controlrect.Height, controlrect.Height, 270, 90)
                gp1.AddArc(controlrect.X + 1 + controlrect.Width - controlrect.Height, controlrect.Y + controlrect.Height - controlrect.Height, controlrect.Height, controlrect.Height, 0, 90)
                gp1.AddArc(controlrect.X, controlrect.Y + controlrect.Height - controlrect.Height, controlrect.Height, controlrect.Height, 90, 90)
                gp1.CloseFigure()
                e.Graphics.FillPath(br, gp1)
                gp1.Dispose()
            End If
        End Using
        Dim gp2 As New GraphicsPath()
        Using br As New LinearGradientBrush(e.ClipRectangle, ColorTranslator.FromHtml("#51a7f2"), ColorTranslator.FromHtml("#51a7f2"), LinearGradientMode.Vertical)
            If controlrect.Height > 1 Then
                gp2.AddArc(controlrect.X + 5, controlrect.Y + CDec(controlrect.Height / 2), controlrect.Height - CDec(controlrect.Height / 2), CDec(controlrect.Height / 2), 180, 90)
                gp2.AddArc(controlrect.X + 5 + controlrect.Width - controlrect.Height, controlrect.Y + CDec(controlrect.Height / 2), controlrect.Height - CDec(controlrect.Height / 2), CDec(controlrect.Height / 2), 270, 90)
                gp2.AddArc(controlrect.X + 5 + controlrect.Width - controlrect.Height, controlrect.Y + controlrect.Height - controlrect.Height + CDec(controlrect.Height / 2), controlrect.Height - CDec(controlrect.Height / 2), CDec(controlrect.Height / 2), 0, 90)
                gp2.AddArc(controlrect.X + 5, controlrect.Y + controlrect.Height - controlrect.Height + CDec(controlrect.Height / 2), controlrect.Height - CDec(controlrect.Height / 2), CDec(controlrect.Height / 2), 90, 90)
                gp2.CloseFigure()
                e.Graphics.FillPath(br, gp2)
                gp2.Dispose()
            End If
        End Using

        If isMouseHover Then
            Using br As New SolidBrush(ColorTranslator.FromHtml("#51a7f2"))
                e.Graphics.FillPath(br, gp)
            End Using
        End If
        Dim pt1 As New PointF(e.ClipRectangle.X + e.ClipRectangle.Width / 2 - textsize.Width / 2, e.ClipRectangle.Y + e.ClipRectangle.Height / 2 - textsize.Height / 2)
        Using br As New SolidBrush(activeState.ForeColor)
            If displayMode = DisplayType.Text Then
                e.Graphics.DrawString(displaytext, font, br, pt1)
            End If
        End Using
        gp.Dispose()
    End Sub

    Public Sub DrawSlider(e As PaintEventArgs, p As Point, toggleState As ToggleButtonState, slider As SliderCollection, font As Font, righttoLeft As RightToLeft, _
     isMouseMove As Boolean, isMouseHover As Boolean) Implements Syncfusion.Windows.Forms.Tools.IToggleButtonRenderer.DrawSlider
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim controlrect As New Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, slider.Width, slider.Width - 1)
        Dim t_sliderRectangle As Rectangle
        If Not isMouseMove Then
            If toggleState = ToggleButtonState.Inactive Then
                t_sliderRectangle = New Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Height - 1, e.ClipRectangle.Height - 1)
            Else
                t_sliderRectangle = New Rectangle(e.ClipRectangle.X + e.ClipRectangle.Width - e.ClipRectangle.Height, e.ClipRectangle.Y, e.ClipRectangle.Height - 1, e.ClipRectangle.Height - 1)
            End If
        Else
            t_sliderRectangle = New Rectangle(p.X, e.ClipRectangle.Y, e.ClipRectangle.Height - 1, e.ClipRectangle.Height - 1)
        End If
        If isMouseHover Then
            Using br As New SolidBrush(slider.BackColor)
                e.Graphics.FillEllipse(br, t_sliderRectangle)
                Using pn As New Pen(Color.Gray, 2)
                    e.Graphics.DrawEllipse(pn, t_sliderRectangle)
                End Using
            End Using
        Else
            Using br As New SolidBrush(slider.BackColor)
                e.Graphics.FillEllipse(br, t_sliderRectangle)
                e.Graphics.DrawEllipse(Pens.Gray, t_sliderRectangle)
            End Using
        End If
    End Sub
#End Region

#Region "IToggleButtonRenderer Members"

    Public Property ToggleButton() As ToggleButton
        Get
            Return m_toggleButton
        End Get
        Set(value As ToggleButton)
            m_toggleButton = value
        End Set
    End Property

#End Region


End Class
