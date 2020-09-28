Public Class UCReclamacionesXcobrar
#Region "Attributes"
    Private TabFN_GetCobrarReclamacion As TabFN_GetCobrarReclamacion
    Private TabFN_ReclamacionStatus As TabFN_ReclamacionStatus
    Private TabFN_DevolucionNotaReclamacion As TabFN_DevolucionNotaReclamacion
    Private TabFN_DevolucionRecNotaSeguimiento As TabFN_DevolucionRecNotaSeguimiento
#End Region

#Region "Constrcutors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabFN_GetCobrarReclamacion = New TabFN_GetCobrarReclamacion(General.Anticipo.Estado.NotaCredito) With {.Dock = DockStyle.Fill, .Visible = True}
        TabFN_ReclamacionStatus = New TabFN_ReclamacionStatus(General.Anticipo.EstadoCobroNotaCredito.Pendiente, "COMPRAS") With {.Dock = DockStyle.Fill, .Visible = False}
        TabFN_DevolucionNotaReclamacion = New TabFN_DevolucionNotaReclamacion(General.Anticipo.EstadoCobroNotaCredito.SolicitudDevolucion, "COMPRAS") With {.Dock = DockStyle.Fill, .Visible = False}
        TabFN_DevolucionRecNotaSeguimiento = New TabFN_DevolucionRecNotaSeguimiento(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, "COMPRAS") With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(TabFN_GetCobrarReclamacion)
        PanelBody.Controls.Add(TabFN_ReclamacionStatus)
        PanelBody.Controls.Add(TabFN_DevolucionNotaReclamacion)
        PanelBody.Controls.Add(TabFN_DevolucionRecNotaSeguimiento)
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton4.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Pendientes"
                TabFN_DevolucionRecNotaSeguimiento.Visible = False
                TabFN_DevolucionNotaReclamacion.Visible = False
                TabFN_ReclamacionStatus.Visible = False
                TabFN_GetCobrarReclamacion.Visible = True

            Case "Compensaciones"
                TabFN_DevolucionRecNotaSeguimiento.Visible = False
                TabFN_DevolucionNotaReclamacion.Visible = False
                TabFN_GetCobrarReclamacion.Visible = False
                TabFN_ReclamacionStatus.Visible = True

            Case "Solicitud de devolución"
                TabFN_DevolucionRecNotaSeguimiento.Visible = False
                TabFN_GetCobrarReclamacion.Visible = False
                TabFN_ReclamacionStatus.Visible = False
                TabFN_DevolucionNotaReclamacion.Visible = True

            Case "Cobro de devolución"
                TabFN_GetCobrarReclamacion.Visible = False
                TabFN_ReclamacionStatus.Visible = False
                TabFN_DevolucionNotaReclamacion.Visible = False
                TabFN_DevolucionRecNotaSeguimiento.Visible = True
        End Select
    End Sub
#End Region


End Class
