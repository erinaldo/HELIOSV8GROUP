Public Class UCReclamacionesXpagar

#Region "Attributes"
    Private TabFN_GetPagarReclamacion As TabFN_GetPagarReclamacion
    Private TabFN_ReclamacionStatus As TabFN_ReclamacionStatus
    Private TabFN_DevolucionNotaReclamacion As TabFN_DevolucionNotaReclamacion
    Private TabFN_DevolucionRecNotaSeguimiento As TabFN_DevolucionRecNotaSeguimiento
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabFN_GetPagarReclamacion = New TabFN_GetPagarReclamacion(General.Anticipo.Estado.NotaCredito) With {.Dock = DockStyle.Fill, .Visible = True}
        TabFN_ReclamacionStatus = New TabFN_ReclamacionStatus(General.Anticipo.EstadoCobroNotaCredito.Pendiente, "VENTAS") With {.Dock = DockStyle.Fill, .Visible = False}
        TabFN_DevolucionNotaReclamacion = New TabFN_DevolucionNotaReclamacion(General.Anticipo.EstadoCobroNotaCredito.SolicitudDevolucion, "VENTAS") With {.Dock = DockStyle.Fill, .Visible = False}
        TabFN_DevolucionRecNotaSeguimiento = New TabFN_DevolucionRecNotaSeguimiento(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, "VENTAS") With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(TabFN_GetPagarReclamacion)
        PanelBody.Controls.Add(TabFN_ReclamacionStatus)
        PanelBody.Controls.Add(TabFN_DevolucionNotaReclamacion)
        PanelBody.Controls.Add(TabFN_DevolucionRecNotaSeguimiento)
    End Sub

#End Region

#Region "Methods"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton4.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Pendientes"
                TabFN_ReclamacionStatus.Visible = False
                TabFN_DevolucionNotaReclamacion.Visible = False
                TabFN_DevolucionRecNotaSeguimiento.Visible = False
                TabFN_GetPagarReclamacion.Visible = True

            Case "Compensaciones"
                TabFN_DevolucionNotaReclamacion.Visible = False
                TabFN_DevolucionRecNotaSeguimiento.Visible = False
                TabFN_GetPagarReclamacion.Visible = False
                TabFN_ReclamacionStatus.Visible = True

            Case "Solicitud de devolución"
                TabFN_DevolucionRecNotaSeguimiento.Visible = False
                TabFN_GetPagarReclamacion.Visible = False
                TabFN_ReclamacionStatus.Visible = False
                TabFN_DevolucionNotaReclamacion.Visible = True

            Case "Pago de devolución"
                TabFN_GetPagarReclamacion.Visible = False
                TabFN_ReclamacionStatus.Visible = False
                TabFN_DevolucionNotaReclamacion.Visible = False
                TabFN_DevolucionRecNotaSeguimiento.Visible = True

        End Select
    End Sub
#End Region

End Class
