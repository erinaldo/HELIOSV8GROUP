Imports Helios.General
Public Class frmTipoItemBonifica
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Function ReturnValor() As String
        If rbIgual.Checked = True Then
            SelecNombreEstable = "="
        End If
        If rbRef.Checked = True Then
            SelecNombreEstable = "=!"
        End If
        Return (SelecNombreEstable)
    End Function

    Private Sub frmTipoItemBonifica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonCategoria_Click(sender As Object, e As EventArgs) Handles ButtonCategoria.Click
        ReturnValor()
        Hide()
    End Sub
End Class