Public Class UCCuentasXcobrar

#Region "Attributes"
    Private TabFN_GetCuentasCobrarPeriodo As TabFN_GetCuentasCobrarPeriodo
    Private TabFN_DevolucionRecNotaSeguimiento As TabFN_DevolucionRecNotaSeguimiento
    Private TabFN_DevolucionNotaSeguimiento As TabFN_DevolucionNotaSeguimiento
    Private UCHistorialCobranza As UCHistorialCobranza
#End Region



#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabFN_GetCuentasCobrarPeriodo = New TabFN_GetCuentasCobrarPeriodo With {.Dock = DockStyle.Fill, .Visible = True}
        'TabFN_DevolucionRecNotaSeguimiento = New TabFN_DevolucionRecNotaSeguimiento(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, "COMPRAS") With {.Dock = DockStyle.Fill, .Visible = False}
        'TabFN_DevolucionNotaSeguimiento = New TabFN_DevolucionNotaSeguimiento(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, General.Anticipo.Tipo.otorgado) With {.Dock = DockStyle.Fill, .Visible = False}
        'UCHistorialCobranza = New UCHistorialCobranza With {.Dock = DockStyle.Fill, .Visible = False}


        PanelBody.Controls.Add(TabFN_GetCuentasCobrarPeriodo)
        'PanelBody.Controls.Add(TabFN_DevolucionRecNotaSeguimiento)
        'PanelBody.Controls.Add(UCHistorialCobranza)
    End Sub

#End Region
#Region "Metodos"

    Public Sub OcultarTodos()
        If TabFN_GetCuentasCobrarPeriodo IsNot Nothing Then
            TabFN_GetCuentasCobrarPeriodo.Visible = False
        End If
        If TabFN_DevolucionRecNotaSeguimiento IsNot Nothing Then
            TabFN_DevolucionRecNotaSeguimiento.Visible = False
        End If
        If TabFN_DevolucionNotaSeguimiento IsNot Nothing Then
            TabFN_DevolucionNotaSeguimiento.Visible = False
        End If
        If UCHistorialCobranza IsNot Nothing Then
            UCHistorialCobranza.Visible = False
        End If


    End Sub

#End Region

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click, BunifuFlatButton4.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Cobros pendientes"
                'TabFN_DevolucionRecNotaSeguimiento.Visible = False
                'TabFN_DevolucionNotaSeguimiento.Visible = False
                'UCHistorialCobranza.Visible = False

                OcultarTodos()

                TabFN_GetCuentasCobrarPeriodo.Visible = True
                TabFN_GetCuentasCobrarPeriodo.BringToFront()
                TabFN_GetCuentasCobrarPeriodo.Show()
            Case "Reclamaciones"
                'TabFN_GetCuentasCobrarPeriodo.Visible = False
                'TabFN_DevolucionNotaSeguimiento.Visible = False
                'UCHistorialCobranza.Visible = False
                OcultarTodos()
                'UCMovimientos.Visible = False
                'If UCRegistroOtrosMovimientos IsNot Nothing Then
                '    UCRegistroOtrosMovimientos.Visible = True
                '    UCRegistroOtrosMovimientos.BringToFront()
                '    UCRegistroOtrosMovimientos.Show()
                'End If

                If TabFN_DevolucionRecNotaSeguimiento IsNot Nothing Then
                    TabFN_DevolucionRecNotaSeguimiento.Visible = True
                    TabFN_DevolucionRecNotaSeguimiento.BringToFront()
                    TabFN_DevolucionRecNotaSeguimiento.Show()
                Else
                    TabFN_DevolucionRecNotaSeguimiento = New TabFN_DevolucionRecNotaSeguimiento(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, "COMPRAS") With {.Dock = DockStyle.Fill, .Visible = False}
                    PanelBody.Controls.Add(TabFN_DevolucionRecNotaSeguimiento)
                    TabFN_DevolucionRecNotaSeguimiento.Visible = True
                    TabFN_DevolucionRecNotaSeguimiento.BringToFront()
                    TabFN_DevolucionRecNotaSeguimiento.Show()
                End If

                'TabFN_DevolucionRecNotaSeguimiento.Visible = True
                'TabFN_DevolucionRecNotaSeguimiento.BringToFront()
                'TabFN_DevolucionRecNotaSeguimiento.Show()

            Case "Anticipos Devolución Cobro"
                'TabFN_GetCuentasCobrarPeriodo.Visible = False
                'TabFN_DevolucionRecNotaSeguimiento.Visible = False
                'UCHistorialCobranza.Visible = False
                OcultarTodos()
                'UCMovimientos.Visible = False
                'If UCRegistroOtrosMovimientos IsNot Nothing Then
                '    UCRegistroOtrosMovimientos.Visible = True
                '    UCRegistroOtrosMovimientos.BringToFront()
                '    UCRegistroOtrosMovimientos.Show()
                'End If
                'TabFN_DevolucionNotaSeguimiento.Visible = True
                'TabFN_DevolucionNotaSeguimiento.BringToFront()
                'TabFN_DevolucionNotaSeguimiento.Show()

                If TabFN_DevolucionNotaSeguimiento IsNot Nothing Then
                    TabFN_DevolucionNotaSeguimiento.Visible = True
                    TabFN_DevolucionNotaSeguimiento.BringToFront()
                    TabFN_DevolucionNotaSeguimiento.Show()
                Else
                    TabFN_DevolucionNotaSeguimiento = New TabFN_DevolucionNotaSeguimiento(General.Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, General.Anticipo.Tipo.otorgado) With {.Dock = DockStyle.Fill, .Visible = False}
                    PanelBody.Controls.Add(TabFN_DevolucionNotaSeguimiento)
                    TabFN_DevolucionNotaSeguimiento.Visible = True
                    TabFN_DevolucionNotaSeguimiento.BringToFront()
                    TabFN_DevolucionNotaSeguimiento.Show()
                End If
            Case "Historial De Cobros"



                'TabFN_GetCuentasCobrarPeriodo.Visible = False
                'TabFN_DevolucionRecNotaSeguimiento.Visible = False
                'TabFN_DevolucionNotaSeguimiento.Visible = False
                OcultarTodos()
                'UCMovimientos.Visible = False
                'If UCRegistroOtrosMovimientos IsNot Nothing Then
                '    UCRegistroOtrosMovimientos.Visible = True
                '    UCRegistroOtrosMovimientos.BringToFront()
                '    UCRegistroOtrosMovimientos.Show()
                'End If
                'UCHistorialCobranza.Visible = True
                'UCHistorialCobranza.BringToFront()
                'UCHistorialCobranza.Show()

                If UCHistorialCobranza IsNot Nothing Then
                    UCHistorialCobranza.Visible = True
                    UCHistorialCobranza.BringToFront()
                    UCHistorialCobranza.Show()
                Else
                    UCHistorialCobranza = New UCHistorialCobranza With {.Dock = DockStyle.Fill, .Visible = False}
                    PanelBody.Controls.Add(UCHistorialCobranza)
                    UCHistorialCobranza.Visible = True
                    UCHistorialCobranza.BringToFront()
                    UCHistorialCobranza.Show()
                End If
        End Select
    End Sub







End Class
