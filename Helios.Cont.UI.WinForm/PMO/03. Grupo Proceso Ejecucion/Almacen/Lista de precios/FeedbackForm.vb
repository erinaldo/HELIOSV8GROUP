Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms


'Public Interface IDisplayFeedback
'    Sub Show()
'    Sub DisplaySN(text As String)

'End Interface

Public Class FeedbackForm
    Inherits System.Windows.Forms.Form
    'Implements IDisplayFeedback

    'Private pictureBox1 As PictureBox
    'Private components As IContainer = Nothing
    Private feedBack As String = "Compiling"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ShowInTaskbar = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub


    'Private Function GetApproximateSize(text As String) As Integer
    '    Return 0
    'End Function

    'Private Const CS_DROPSHADOW As Integer = &H20000
    'Protected Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        ' add the drop shadow flag for automatically drawing
    '        ' a drop shadow around the form
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
    '        Return cp
    '    End Get
    'End Property

    'Public Sub DisplaySN(text As String) Implements IDisplayFeedback.DisplaySN
    '    Me.feedBack = text
    '    If Me.feedBack.CompareTo("Populating the Tree. Please Wait...") = 0 Then
    '        'Me.pictureBox1.Image = Image.FromFile("../../CompilingWaitingpopup1_new.png")
    '    End If
    'End Sub

    'Public Sub Show1() Implements IDisplayFeedback.Show

    'End Sub
End Class