Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class Tab_RecepcionControl

    Public TabMG_GestionInfraestructura As TabMG_GestionInfraestructura

    Public Tab_ListaPedidos As Tab_ListaPedidos

    Public TabMG_RecepcionCliente As TabMG_RecepcionCliente


    Public TabRC_Cliente As TabRC_Cliente

    Public TabMG_Dashboard As TabMG_Dashboard

    Dim tipoFrm As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        TabMG_GestionInfraestructura = New TabMG_GestionInfraestructura(Me) With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabMG_GestionInfraestructura)


        Tab_ListaPedidos = New Tab_ListaPedidos(Me) With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(Tab_ListaPedidos)
        Tab_ListaPedidos.Visible = False

        'TabMG_RecepcionCliente = New TabMG_RecepcionCliente(Me) With {.Dock = DockStyle.Fill}
        'pnContenedor.Controls.Add(TabMG_RecepcionCliente)
        'TabMG_RecepcionCliente.Visible = False


        TabMG_Dashboard = New TabMG_Dashboard() With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabMG_Dashboard)
        TabMG_Dashboard.Visible = False

        TabRC_Cliente = New TabRC_Cliente(Me) With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabRC_Cliente)
        TabRC_Cliente.Visible = False
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton5.Click, BunifuFlatButton4.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "CONTROL"
                Tab_ListaPedidos.Visible = False
                TabMG_RecepcionCliente.Visible = False
                TabRC_Cliente.Visible = False
                TabMG_GestionInfraestructura.Visible = False
                If TabMG_Dashboard IsNot Nothing Then
                    'TabMG_Dashboard.CargarDefault()
                    TabMG_Dashboard.Visible = True
                    TabMG_Dashboard.BringToFront()
                    TabMG_Dashboard.Show()
                End If
            Case "RECEPCIÓN DE CLIENTES Y HUÉSPED"
                Tab_ListaPedidos.Visible = False
                TabMG_GestionInfraestructura.Visible = False
                TabRC_Cliente.Visible = False
                TabMG_Dashboard.Visible = False
                If TabMG_RecepcionCliente IsNot Nothing Then
                    TabMG_RecepcionCliente.Visible = True
                    TabMG_RecepcionCliente.BringToFront()
                    TabMG_RecepcionCliente.Show()
                End If

            Case "RESERVACIONES"
                Tab_ListaPedidos.Visible = False
                TabRC_Cliente.Visible = False
                TabMG_GestionInfraestructura.Visible = False
                TabMG_RecepcionCliente.Visible = False
                TabMG_Dashboard.Visible = False
            Case "COTIZACIONES"
                Tab_ListaPedidos.Visible = False
                TabMG_GestionInfraestructura.Visible = False
                TabRC_Cliente.Visible = False
                TabMG_RecepcionCliente.Visible = False
                TabMG_Dashboard.Visible = False
            Case "HORARIO DE ATENCIÓN"
                TabRC_Cliente.Visible = False
                Tab_ListaPedidos.Visible = False
                TabMG_GestionInfraestructura.Visible = False
                TabMG_RecepcionCliente.Visible = False
                TabMG_Dashboard.Visible = False
        End Select
    End Sub

#Region "Metodos"




#End Region



End Class
