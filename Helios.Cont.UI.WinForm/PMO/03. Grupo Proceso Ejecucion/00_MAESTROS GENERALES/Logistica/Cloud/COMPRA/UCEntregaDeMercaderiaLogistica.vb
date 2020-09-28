Imports Helios.Cont.Business.Entity

Public Class UCEntregaDeMercaderiaLogistica

#Region "Attributes"
    Public Property UCMercaderiaEntransito As UCMercaderiaEntransito
    Public Property UCEnvioProductoPendienteRecepcion As UCEnvioProductoPendienteRecepcion
    Public Property formLogistica As FormMaestroLogistica
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCMercaderiaEntransito = New UCMercaderiaEntransito(Me)
        UCMercaderiaEntransito.Dock = DockStyle.Fill
        UCMercaderiaEntransito.Show()
        PanelBody.Controls.Add(UCMercaderiaEntransito)

        UCEnvioProductoPendienteRecepcion = New UCEnvioProductoPendienteRecepcion(Me)
        UCEnvioProductoPendienteRecepcion.Dock = DockStyle.Fill
        UCEnvioProductoPendienteRecepcion.Show()
        PanelBody.Controls.Add(UCEnvioProductoPendienteRecepcion)
    End Sub

    Public Sub New(Logistica As FormMaestroLogistica)

        ' This call is required by the designer.
        InitializeComponent()
        formLogistica = Logistica
        ' Add any initialization after the InitializeComponent() call.
        UCMercaderiaEntransito = New UCMercaderiaEntransito(Me)
        UCMercaderiaEntransito.Dock = DockStyle.Fill
        UCMercaderiaEntransito.Show()
        PanelBody.Controls.Add(UCMercaderiaEntransito)

        UCEnvioProductoPendienteRecepcion = New UCEnvioProductoPendienteRecepcion(Me)
        UCEnvioProductoPendienteRecepcion.Dock = DockStyle.Fill
        UCEnvioProductoPendienteRecepcion.Show()
        PanelBody.Controls.Add(UCEnvioProductoPendienteRecepcion)
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "EN TRANSITO"
                UCEnvioProductoPendienteRecepcion.Visible = False
                If UCMercaderiaEntransito IsNot Nothing Then
                    UCMercaderiaEntransito.Visible = True
                    UCMercaderiaEntransito.BringToFront()
                    UCMercaderiaEntransito.Show()
                End If
            Case "PENDIENTES DE RECEPCION"
                Cursor = Cursors.WaitCursor
                UCMercaderiaEntransito.Visible = False
                UCEnvioProductoPendienteRecepcion.listaProductos = New List(Of inventarioTransito)
                UCEnvioProductoPendienteRecepcion.ListaAlmacen = New List(Of almacen)
                UCEnvioProductoPendienteRecepcion.GetLoadAlmacenes()
                UCEnvioProductoPendienteRecepcion.GetProductosEntransito()
                UCEnvioProductoPendienteRecepcion.LoadProductosTransito()
                If UCEnvioProductoPendienteRecepcion IsNot Nothing Then
                    UCEnvioProductoPendienteRecepcion.Visible = True
                    UCEnvioProductoPendienteRecepcion.Show()
                End If
                Cursor = Cursors.Default
        End Select
    End Sub
#End Region

End Class
