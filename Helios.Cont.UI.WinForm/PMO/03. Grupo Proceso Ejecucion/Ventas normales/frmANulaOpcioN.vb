Public Class frmANulaOpcioN
    Inherits frmMaster
    Public Property ValorRetorno() As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        rbSin.Checked = True
        ValorRetorno = "SIN"
    End Sub

    Private Sub frmANulaOpcioN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'ValorRetorno = Nothing
    End Sub
    Private Sub frmANulaOpcioN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub rbCon_CheckedChanged(sender As Object, e As EventArgs) Handles rbCon.CheckedChanged
        If rbCon.Checked = True Then
            ValorRetorno = "CON"
        End If
    End Sub

    Private Sub rbSin_CheckedChanged(sender As Object, e As EventArgs) Handles rbSin.CheckedChanged
        If rbSin.Checked = True Then
            ValorRetorno = "SIN"
        End If
    End Sub
End Class