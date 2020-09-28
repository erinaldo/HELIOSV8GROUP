Imports Helios.General
Public Class UCAnticiposRecibidos

#Region "Attributes"
    Private TabFN_Reclamaciones As TabFN_Reclamaciones
    Private TabFN_AnticipoReclamacionStatus As TabFN_AnticipoReclamacionStatus
    Private TabFN_DevolucionNotaCreditoAnt As TabFN_DevolucionNotaCreditoAnt
    Private TabFN_DevolucionNotaSeguimiento As TabFN_DevolucionNotaSeguimiento
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabFN_Reclamaciones = New TabFN_Reclamaciones(Anticipo.Estado.NotaCredito, Anticipo.Tipo.Recibido) With {.Dock = DockStyle.Fill, .Visible = True}
        TabFN_AnticipoReclamacionStatus = New TabFN_AnticipoReclamacionStatus(Anticipo.EstadoCobroNotaCredito.Pendiente, Anticipo.Tipo.Recibido) With {.Dock = DockStyle.Fill, .Visible = False}
        TabFN_DevolucionNotaCreditoAnt = New TabFN_DevolucionNotaCreditoAnt(Anticipo.EstadoCobroNotaCredito.SolicitudDevolucion, Anticipo.Tipo.Recibido) With {.Dock = DockStyle.Fill, .Visible = False}
        TabFN_DevolucionNotaSeguimiento = New TabFN_DevolucionNotaSeguimiento(Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, Anticipo.Tipo.Recibido) With {
                 .Dock = DockStyle.Fill, .Visible = False
             }

        PanelBody.Controls.Add(TabFN_Reclamaciones)
        PanelBody.Controls.Add(TabFN_AnticipoReclamacionStatus)
        PanelBody.Controls.Add(TabFN_DevolucionNotaCreditoAnt)
        PanelBody.Controls.Add(TabFN_DevolucionNotaSeguimiento)
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton4.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Recibidos"
                TabFN_DevolucionNotaSeguimiento.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_Reclamaciones.Visible = True


            Case "Compensaciones"
                TabFN_DevolucionNotaSeguimiento.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_Reclamaciones.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = True

            Case "Anticipos por devolver"
                TabFN_DevolucionNotaSeguimiento.Visible = False
                TabFN_Reclamaciones.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = True


            Case "Devolución de anticipo"
                TabFN_Reclamaciones.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_DevolucionNotaSeguimiento.Visible = True
        End Select
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Cursor = Cursors.WaitCursor
        Dim FormCrearAnticipo As New FormCrearAnticipo()
        FormCrearAnticipo.StartPosition = FormStartPosition.CenterParent
        FormCrearAnticipo.ShowDialog(Me)
        Cursor = Cursors.Default
    End Sub
#End Region

End Class
