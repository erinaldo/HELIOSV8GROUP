Imports System.ComponentModel

Public Class FormRepositorRestaurant
#Region "Attributes"
    Public Property TabR_GestionInfraRestaurant As TabR_GestionInfraRestaurant
    Public Property Tab_ListaPedidosRestaurant As Tab_ListaPedidosRestaurant

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'TabR_GestionInfraRestaurant = New TabR_GestionInfraRestaurant(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(TabR_GestionInfraRestaurant)

        'Tab_ListaPedidosRestaurant = New Tab_ListaPedidosRestaurant(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(Tab_ListaPedidosRestaurant)
        'Tab_ListaPedidosRestaurant.Visible = False
    End Sub

#End Region

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "RECEPCIÓN Y CONTROL"

                If TabR_GestionInfraRestaurant IsNot Nothing Then
                    TabR_GestionInfraRestaurant.Visible = True
                    TabR_GestionInfraRestaurant.BringToFront()
                    TabR_GestionInfraRestaurant.Show()
                End If

        End Select
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub

    Private Sub FormRepositoryPiscina_Load(sender As Object, e As EventArgs) Handles Me.Load
        General.Centrar(Me)
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class