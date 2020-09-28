Public Class FormAlertaPiscina
#Region "Attributes"
    Public Property TabMG_GestionAlertas As TabMG_GestionAlertas

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        TabMG_GestionAlertas = New TabMG_GestionAlertas(Me)
        TabMG_GestionAlertas.Dock = DockStyle.Fill
        PanelBody.Controls.Add(TabMG_GestionAlertas)

    End Sub

#End Region

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton3.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "ALERTAS"
                If TabMG_GestionAlertas IsNot Nothing Then
                    TabMG_GestionAlertas.Visible = True
                    TabMG_GestionAlertas.BringToFront()
                    TabMG_GestionAlertas.Show()
                End If
        End Select
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub
End Class