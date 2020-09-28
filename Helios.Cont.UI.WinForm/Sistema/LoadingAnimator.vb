
Public NotInheritable Class LoadingAnimator
    Private Sub New()
    End Sub
    Private Shared isAnimate As Boolean
    Private Delegate Sub PaintControlEventHandler(sender As Object)
    Private Shared control As Control

    ''' <summary>
    ''' Initializes the static variables defined.
    ''' </summary>
    Shared Sub New()
        Image = My.Resources.loader_transparent ' Bitmap.FromFile("..\..\Resources\loader-transparent.gif")
        isAnimate = True
    End Sub

    ''' <summary>
    ''' Wires the control with the loading indicator and starts the animation.
    ''' </summary>
    ''' <param name="ctrl">Any UI Control that requires long running operations to perform.</param>
    Public Shared Sub Wire(ctrl As Control)
        control = ctrl
        isAnimate = True
        Cursor.Current = Cursors.[Default]
        AnimateLoading()
    End Sub

    ''' <summary>
    ''' Unwires the control from the loading indicator and stops the animation.
    ''' </summary>
    ''' <param name="ctrl">Any UI Control that requires long running operations to perform.</param>
    Public Shared Sub UnWire(ctrl As Control)
        control = ctrl
        isAnimate = False
    End Sub

    ''' <summary>
    ''' Gets or Sets Animated Image(with multiple frames).
    ''' </summary>
    Public Shared Property Image() As Image
        Get
            Return m_Image
        End Get
        Set(value As Image)
            m_Image = Value
        End Set
    End Property
    Private Shared m_Image As Image

    ''' <summary>
    ''' A method that initiates the loading animation.
    ''' </summary>
    Private Shared Sub AnimateLoading()
        ImageAnimator.Animate(Image, New EventHandler(AddressOf RaiseControlPaint))
    End Sub

    ''' <summary>
    ''' A method that paints the loading indicator over the wired control.
    ''' </summary>
    ''' <param name="sender">Wired Control.</param>
    Private Shared Sub PaintControl(sender As Object)
        Dim ctrl As Control = TryCast(sender, Control)
        If isAnimate Then
            Using gr As Graphics = ctrl.CreateGraphics()
                ImageAnimator.UpdateFrames(Image)
                gr.DrawImage(Image, New Point(ctrl.Bounds.Width / 2, ctrl.Bounds.Height / 2))
            End Using
        End If
    End Sub

    ''' <summary>
    ''' A method that invokes the loading animation aside during long running operation in wired control.
    ''' </summary>
    ''' <param name="o">sender</param>
    ''' <param name="e">event argument</param>
    Private Shared Sub RaiseControlPaint(o As Object, e As EventArgs)
        If control IsNot Nothing AndAlso Not control.IsDisposed Then
            If control.InvokeRequired Then
                Dim handler As New PaintControlEventHandler(AddressOf PaintControl)
                Dim result As IAsyncResult = handler.BeginInvoke(control, Nothing, Nothing)
                handler.EndInvoke(result)
            Else
                control.Invalidate(True)
            End If
        End If
    End Sub
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
