Public Class FormFiltroAvanzadoDia

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Value = Date.Now
    End Sub
#End Region

#Region "Events"
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Dim fehaLaboral = txtFecha.Value
        Tag = fehaLaboral
        Close()
    End Sub
#End Region

End Class