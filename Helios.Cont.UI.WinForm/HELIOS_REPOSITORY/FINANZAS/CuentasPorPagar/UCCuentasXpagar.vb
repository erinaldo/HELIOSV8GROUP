Imports Helios.General

Public Class UCCuentasXpagar
    Private TabFN_GetCuentasPagarPeriodo As TabFN_GetCuentasPagarPeriodo
    Private TabFN_DevolucionRecNotaSeguimiento As TabFN_DevolucionRecNotaSeguimiento
    Private TabFN_DevolucionNotaSeguimiento As TabFN_DevolucionNotaSeguimiento
    Private UCHistorialPagos As UCHistorialPagos
    'Private f2 As 

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabFN_GetCuentasPagarPeriodo = New TabFN_GetCuentasPagarPeriodo With {.Dock = DockStyle.Fill, .Visible = True}
        TabFN_DevolucionRecNotaSeguimiento = New TabFN_DevolucionRecNotaSeguimiento(Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, "VENTAS") With {.Dock = DockStyle.Fill, .Visible = False}
        TabFN_DevolucionNotaSeguimiento = New TabFN_DevolucionNotaSeguimiento(Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, Anticipo.Tipo.Recibido) With {.Dock = DockStyle.Fill, .Visible = False}

        UCHistorialPagos = New UCHistorialPagos With {.Dock = DockStyle.Fill, .Visible = False}


        PanelBody.Controls.Add(TabFN_GetCuentasPagarPeriodo)
        PanelBody.Controls.Add(TabFN_DevolucionRecNotaSeguimiento)
        PanelBody.Controls.Add(TabFN_DevolucionNotaSeguimiento)
        PanelBody.Controls.Add(UCHistorialPagos)
    End Sub


    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click, BunifuFlatButton4.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Pagos pendientes"
                TabFN_DevolucionRecNotaSeguimiento.Visible = False
                TabFN_DevolucionNotaSeguimiento.Visible = False
                UCHistorialPagos.Visible = False
                'UCMovimientos.Visible = False
                'If UCRegistroOtrosMovimientos IsNot Nothing Then
                '    UCRegistroOtrosMovimientos.Visible = True
                '    UCRegistroOtrosMovimientos.BringToFront()
                '    UCRegistroOtrosMovimientos.Show()
                'End If
                TabFN_GetCuentasPagarPeriodo.Visible = True
                TabFN_GetCuentasPagarPeriodo.BringToFront()
                TabFN_GetCuentasPagarPeriodo.Show()
            Case "Reclamaciones x pagar"
                TabFN_GetCuentasPagarPeriodo.Visible = False
                TabFN_DevolucionNotaSeguimiento.Visible = False
                UCHistorialPagos.Visible = False
                'UCMovimientos.Visible = False
                'If UCRegistroOtrosMovimientos IsNot Nothing Then
                '    UCRegistroOtrosMovimientos.Visible = True
                '    UCRegistroOtrosMovimientos.BringToFront()
                '    UCRegistroOtrosMovimientos.Show()
                'End If
                TabFN_DevolucionRecNotaSeguimiento.Visible = True
                TabFN_DevolucionRecNotaSeguimiento.BringToFront()
                TabFN_DevolucionRecNotaSeguimiento.Show()

            Case "Anticipos Devolución Pago"
                TabFN_DevolucionRecNotaSeguimiento.Visible = False
                TabFN_GetCuentasPagarPeriodo.Visible = False
                UCHistorialPagos.Visible = False
                'UCMovimientos.Visible = False
                'If UCRegistroOtrosMovimientos IsNot Nothing Then
                '    UCRegistroOtrosMovimientos.Visible = True
                '    UCRegistroOtrosMovimientos.BringToFront()
                '    UCRegistroOtrosMovimientos.Show()
                'End If
                TabFN_DevolucionNotaSeguimiento.Visible = True
                TabFN_DevolucionNotaSeguimiento.BringToFront()
                TabFN_DevolucionNotaSeguimiento.Show()

            Case "Historial de Pagos"

                TabFN_DevolucionRecNotaSeguimiento.Visible = False
                TabFN_GetCuentasPagarPeriodo.Visible = False
                TabFN_DevolucionNotaSeguimiento.Visible = False
                'UCMovimientos.Visible = False
                'If UCRegistroOtrosMovimientos IsNot Nothing Then
                '    UCRegistroOtrosMovimientos.Visible = True
                '    UCRegistroOtrosMovimientos.BringToFront()
                '    UCRegistroOtrosMovimientos.Show()
                'End If
                UCHistorialPagos.Visible = True
                UCHistorialPagos.BringToFront()
                UCHistorialPagos.Show()

        End Select
    End Sub
End Class
