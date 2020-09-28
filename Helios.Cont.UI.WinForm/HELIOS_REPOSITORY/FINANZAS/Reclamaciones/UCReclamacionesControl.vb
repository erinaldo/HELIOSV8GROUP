Public Class UCReclamacionesControl

#Region "Attributes"
    Private UCReclamacionesXcobrar As UCReclamacionesXcobrar
    Private UCReclamacionesXpagar As UCReclamacionesXpagar
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCReclamacionesXcobrar = New UCReclamacionesXcobrar With {.Dock = DockStyle.Fill, .Visible = True}
        UCReclamacionesXpagar = New UCReclamacionesXpagar With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCReclamacionesXcobrar)
        PanelBody.Controls.Add(UCReclamacionesXpagar)
    End Sub

#End Region

#Region "Methdos"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        UCReclamacionesXcobrar.Visible = True
        UCReclamacionesXpagar.Visible = False
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        UCReclamacionesXcobrar.Visible = False
        UCReclamacionesXpagar.Visible = True
    End Sub
#End Region

End Class
