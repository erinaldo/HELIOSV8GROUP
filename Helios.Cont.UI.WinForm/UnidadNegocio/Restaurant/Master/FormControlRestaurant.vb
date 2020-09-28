Imports System.ComponentModel

Public Class FormControlRestaurant
#Region "Attributes"
    Public Property TabP_RestaurantMaster As TabP_RestaurantMaster
    Public TabR_GestionInfraRestaurant As TabR_GestionInfraRestaurant
    Public Tab_ListaPedidosRestaurant As Tab_ListaPedidosRestaurant
    Public TabR_GestionCajaCentralizada As TabR_GestionCajaCentralizada
    Public FormCanastaPedidoPorCobrar As FormCanastaPedidoPorCobrar
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.
        TabP_RestaurantMaster = New TabP_RestaurantMaster(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabP_RestaurantMaster)

        TabR_GestionInfraRestaurant = New TabR_GestionInfraRestaurant(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabR_GestionInfraRestaurant)

        Tab_ListaPedidosRestaurant = New Tab_ListaPedidosRestaurant(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(Tab_ListaPedidosRestaurant)

        TabR_GestionCajaCentralizada = New TabR_GestionCajaCentralizada(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabR_GestionCajaCentralizada)

        FormCanastaPedidoPorCobrar = New FormCanastaPedidoPorCobrar(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(FormCanastaPedidoPorCobrar)

    End Sub

    Public Sub New(tipo As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ''Add any initialization after the InitializeComponent() call.
        'TabP_RestaurantMaster = New TabP_RestaurantMaster(Me, 1) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(TabP_RestaurantMaster)

        TabR_GestionInfraRestaurant = New TabR_GestionInfraRestaurant(Me, 1) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabR_GestionInfraRestaurant)

        Tab_ListaPedidosRestaurant = New Tab_ListaPedidosRestaurant(Me, 1) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(Tab_ListaPedidosRestaurant)

        'TabR_GestionCajaCentralizada = New TabR_GestionCajaCentralizada(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(TabR_GestionCajaCentralizada)

        'FormCanastaPedidoPorCobrar = New FormCanastaPedidoPorCobrar(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(FormCanastaPedidoPorCobrar)

    End Sub

#End Region

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