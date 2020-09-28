Public Class Form1
    Dim str As String = ""
    Function IsNumeric(ByVal Val As Integer)
        Return ((Val >= 48 And Val <= 57) Or (Val = 8) Or (Val = 46) Or Val = 104)
    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Dim KeyCode As Integer = e.KeyValue
        '1
        If KeyCode = 97 Then
            KeyCode = 49

            '2
        ElseIf KeyCode = 98 Then
            KeyCode = 50

            '3
        ElseIf KeyCode = 99 Then
            KeyCode = 51


            '4
        ElseIf KeyCode = 100 Then
            KeyCode = 52


            '5
        ElseIf KeyCode = 101 Then
            KeyCode = 53


            '6
        ElseIf KeyCode = 102 Then
            KeyCode = 54


            ' 7
        ElseIf KeyCode = 103 Then
            KeyCode = 55


            '8
        ElseIf KeyCode = 104 Then
            KeyCode = 56


            '9
        ElseIf KeyCode = 105 Then
            KeyCode = 57


            '0
        ElseIf KeyCode = 96 Then
            KeyCode = 48
        End If

        If (Not IsNumeric(KeyCode)) Then

            e.Handled = True
            Return

        Else
            e.Handled = True
        End If
        If (((KeyCode = 8) Or (KeyCode = 46)) And (str.Length > 0)) Then

            str = str.Substring(0, str.Length - 1)

        ElseIf (Not ((KeyCode = 8) Or (KeyCode = 46))) Then
            str = str + Convert.ToChar(KeyCode)
        End If
        If (str.Length = 0) Then

            TextBox1.Text = "0.00"

        End If
        If (str.Length = 1) Then

            TextBox1.Text = str + ".00"

        ElseIf (str.Length = 2) Then

            TextBox1.Text = str + ".00"

        ElseIf (str.Length > 2) Then
            Dim S As String = str.Substring(0, str.Length - 2)
            Dim X As String = str.Substring(str.Length - 2)
            '    Dim Y = "00"
            TextBox1.Text = S + "." + X
            '   TextBox1.Text = str + "." + "00"
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        e.Handled = True
    End Sub
   

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

End Class
