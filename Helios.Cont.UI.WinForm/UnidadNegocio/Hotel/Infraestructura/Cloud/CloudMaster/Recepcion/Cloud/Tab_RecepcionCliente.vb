Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class Tab_RecepcionCliente

    Private TabMG_GestionRecepInfra As TabMG_GestionRecepInfra

    Private TabMG_GestionRecepInfraLista As TabMG_GestionRecepInfraLista

    Dim tipoFrm As String

    Public Property ListaproductosVendidos As List(Of documentoventaAbarrotesDet)

    Public Property fechaIngreso As DateTime

    Public Property fechaFin As DateTime

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        TabMG_GestionRecepInfra = New TabMG_GestionRecepInfra(Me) With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabMG_GestionRecepInfra)
        TabMG_GestionRecepInfra.Visible = True

        TabMG_GestionRecepInfraLista = New TabMG_GestionRecepInfraLista(Me) With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabMG_GestionRecepInfraLista)
        TabMG_GestionRecepInfraLista.Visible = False

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton5.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "MODO GRÁFICO"
                TabMG_GestionRecepInfra.Visible = False
                If TabMG_GestionRecepInfraLista IsNot Nothing Then
                    TabMG_GestionRecepInfraLista.Visible = True
                    TabMG_GestionRecepInfraLista.BringToFront()
                    TabMG_GestionRecepInfraLista.Show()
                End If
            Case "MODO BASICO"
                TabMG_GestionRecepInfraLista.Visible = False
                If TabMG_GestionRecepInfra IsNot Nothing Then
                    TabMG_GestionRecepInfra.Visible = True
                    TabMG_GestionRecepInfra.BringToFront()
                    TabMG_GestionRecepInfra.Show()
                End If
        End Select
    End Sub
End Class
