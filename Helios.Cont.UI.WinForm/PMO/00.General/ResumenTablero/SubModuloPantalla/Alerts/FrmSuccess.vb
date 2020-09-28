Public Class FrmSuccess

#Region "Constructor"

    Sub New(mensaje As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblMessage.Text = mensaje
    End Sub

#End Region

#Region "Metodos"

    Public Shared Sub ConfirmationForm(mensaje As String)
        Dim frm As FrmSuccess = New FrmSuccess(mensaje)
        frm.ShowDialog()
    End Sub

#End Region

    Private Sub FrmSuccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'esclarecerForm.ShowAsyc(Me)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class