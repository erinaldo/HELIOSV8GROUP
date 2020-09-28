Public Class FormCodeEnter

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextCodigoProforma.Select()
        TextCodigoProforma.SelectAll()
    End Sub
    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Tag = TextCodigoProforma.Text.Trim
        Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Tag = Nothing
        Close()
    End Sub
End Class