Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class UCEncomiendas

    Public UCRecepcionEncomiendas As UCRecepcionEncomiendas
    Public Property UCEncomiendasPorEntregar As UCEncomiendasPorEntregar
    Public Property UCmaestroManifiestoEncomiendas As UCmaestroManifiestoEncomiendas
    Public Property UCLiquidacionEncomiendas As UCLiquidacionEncomiendas

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Conteos()
        UCRecepcionEncomiendas = New UCRecepcionEncomiendas(Me) With {
                   .Dock = DockStyle.Fill
               }
        UCRecepcionEncomiendas.BringToFront()
        PanelBody.Controls.Add(UCRecepcionEncomiendas)
    End Sub

    Public Sub Conteos()

        Dim ventaSA As New DocumentoventaTransporteSA

        Dim conteo = ventaSA.GetEncomiendasSelEstadoEntregaConteo(New Business.Entity.documentoventaTransporte With
                                             {
                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                             .estado = Transporte.EncomiendaEstado.PendienteDeEntrega
                                              })
        BunifuFlatButton2.Text = "Por entregar: " & conteo
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click, BunifuFlatButton2.Click, BunifuFlatButton4.Click, BunifuFlatButton3.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        PanelBody.Controls.Clear()
        Select Case btn.Tag
            Case "Recepción"
                UCRecepcionEncomiendas = New UCRecepcionEncomiendas(Me) With {
                    .Dock = DockStyle.Fill
                }
                UCRecepcionEncomiendas.BringToFront()
                PanelBody.Controls.Add(UCRecepcionEncomiendas)
            Case "Por entregar"
                UCEncomiendasPorEntregar = New UCEncomiendasPorEntregar(Me) With {
                    .Dock = DockStyle.Fill
                }
                UCEncomiendasPorEntregar.BringToFront()
                PanelBody.Controls.Add(UCEncomiendasPorEntregar)

            Case "Manifiestos"
                UCmaestroManifiestoEncomiendas = New UCmaestroManifiestoEncomiendas(Me) With {
                   .Dock = DockStyle.Fill
               }
                UCmaestroManifiestoEncomiendas.BringToFront()
                PanelBody.Controls.Add(UCmaestroManifiestoEncomiendas)

            Case "Liquidación"
                UCLiquidacionEncomiendas = New UCLiquidacionEncomiendas() With {
                 .Dock = DockStyle.Fill
             }
                UCLiquidacionEncomiendas.BringToFront()
                PanelBody.Controls.Add(UCLiquidacionEncomiendas)
        End Select
    End Sub

    Private Sub PanelBody_Paint(sender As Object, e As PaintEventArgs) Handles PanelBody.Paint

    End Sub
End Class
