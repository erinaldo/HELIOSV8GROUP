Public Class UCAnticiposControl

#Region "Attributes"
    Private UCAnticiposOtorgados As UCAnticiposOtorgados
    Private UCAnticiposRecibidos As UCAnticiposRecibidos
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCAnticiposOtorgados = New UCAnticiposOtorgados With {.Dock = DockStyle.Fill, .Visible = True}
        UCAnticiposRecibidos = New UCAnticiposRecibidos With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCAnticiposOtorgados)
        PanelBody.Controls.Add(UCAnticiposRecibidos)
    End Sub


#End Region

#Region "Methdos"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        UCAnticiposRecibidos.Visible = False
        UCAnticiposOtorgados.Visible = True
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        UCAnticiposOtorgados.Visible = False
        UCAnticiposRecibidos.Visible = True
    End Sub
#End Region

End Class
