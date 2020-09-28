Imports Syncfusion.Windows.Forms.Tools

Public Class TextboxJiu
    Inherits TextBoxExt

    ' Override the IsInputKey method to identify the special keys.
    Protected Overrides Function IsInputKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
   ' Add the list of special keys that you want to handle.
            Case Keys.Tab
                Return True
            Case Else
                Return MyBase.IsInputKey(keyData)
        End Select
    End Function

End Class
