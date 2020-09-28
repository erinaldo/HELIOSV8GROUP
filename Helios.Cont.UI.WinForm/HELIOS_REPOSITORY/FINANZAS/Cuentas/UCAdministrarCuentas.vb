Public Class UCAdministrarCuentas

#Region "Attributes"
    Public UCCuentasFinancieras As UCCuentasFinancieras
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCCuentasFinancieras = New UCCuentasFinancieras With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCCuentasFinancieras)
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Events"

#End Region

End Class
