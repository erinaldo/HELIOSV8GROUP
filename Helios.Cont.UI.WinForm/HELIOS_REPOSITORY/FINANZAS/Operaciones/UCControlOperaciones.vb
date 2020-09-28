Public Class UCControlOperaciones

#Region "Attributes"
    Public UCOtrosEgresos As UCOtrosEgresos
    Public UCRegistroOtrosMovimientos As UCRegistroOtrosMovimientos
    Public UCMovimientos As UCMovimientos
    Public UCConfirmacionBancaria As UCConfirmacionBancaria
    Public UCMovimientosBancariosConfirmados As UCMovimientosBancariosConfirmados

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'UCOtrosEgresos = New UCOtrosEgresos With {.Dock = DockStyle.Fill}
        UCRegistroOtrosMovimientos = New UCRegistroOtrosMovimientos With {.Dock = DockStyle.Fill}
        'UCMovimientos = New UCMovimientos With {.Dock = DockStyle.Fill}
        'UCConfirmacionBancaria = New UCConfirmacionBancaria With {.Dock = DockStyle.Fill}
        'UCMovimientosBancariosConfirmados = New UCMovimientosBancariosConfirmados With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCRegistroOtrosMovimientos)
        'PanelBody.Controls.Add(UCOtrosEgresos)
        'PanelBody.Controls.Add(UCMovimientos)
        'PanelBody.Controls.Add(UCConfirmacionBancaria)
        'PanelBody.Controls.Add(UCMovimientosBancariosConfirmados)
    End Sub

#End Region

#Region "Methods"
    Public Sub OcultarTodos()
        If UCRegistroOtrosMovimientos IsNot Nothing Then
            UCRegistroOtrosMovimientos.Visible = False
        End If
        If UCOtrosEgresos IsNot Nothing Then
            UCOtrosEgresos.Visible = False
        End If
        If UCMovimientos IsNot Nothing Then
            UCMovimientos.Visible = False
        End If
        If UCConfirmacionBancaria IsNot Nothing Then
            UCConfirmacionBancaria.Visible = False
        End If
        If UCMovimientosBancariosConfirmados IsNot Nothing Then
            UCMovimientosBancariosConfirmados.Visible = False
        End If

    End Sub
#End Region

#Region "Events"
    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton4.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click, BunifuFlatButton5.Click, BunifuFlatButton6.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Otros Ingresos"
                'UCOtrosEgresos.Visible = False
                'UCMovimientos.Visible = False
                'UCConfirmacionBancaria.Visible = False
                'UCMovimientosBancariosConfirmados.Visible = False
                OcultarTodos()
                If UCRegistroOtrosMovimientos IsNot Nothing Then
                    UCRegistroOtrosMovimientos.Visible = True
                    UCRegistroOtrosMovimientos.BringToFront()
                    UCRegistroOtrosMovimientos.Show()
                End If
            Case "Otros Egresos"
                'UCRegistroOtrosMovimientos.Visible = False
                'UCMovimientos.Visible = False
                'UCConfirmacionBancaria.Visible = False
                'UCMovimientosBancariosConfirmados.Visible = False
                'If UCOtrosEgresos IsNot Nothing Then
                '    UCOtrosEgresos.Visible = True
                '    UCOtrosEgresos.BringToFront()
                '    UCOtrosEgresos.Show()
                'End If


                OcultarTodos()
                If UCOtrosEgresos Is Nothing Then
                    UCOtrosEgresos = New UCOtrosEgresos With {.Dock = DockStyle.Fill, .Visible = False}
                    PanelBody.Controls.Add(UCOtrosEgresos)
                    UCOtrosEgresos.Visible = True
                    UCOtrosEgresos.BringToFront()
                    UCOtrosEgresos.Show()
                Else
                    UCOtrosEgresos.Visible = True
                    UCOtrosEgresos.BringToFront()
                    UCOtrosEgresos.Show()
                End If


            Case "Movimientos"
                'UCRegistroOtrosMovimientos.Visible = False
                'UCOtrosEgresos.Visible = False
                'UCConfirmacionBancaria.Visible = False
                'UCMovimientosBancariosConfirmados.Visible = False
                'If UCMovimientos IsNot Nothing Then
                '    UCMovimientos.Visible = True
                '    UCMovimientos.BringToFront()
                '    UCMovimientos.Show()
                'End If

                OcultarTodos()
                If UCMovimientos Is Nothing Then
                    UCMovimientos = New UCMovimientos With {.Dock = DockStyle.Fill, .Visible = False}
                    PanelBody.Controls.Add(UCMovimientos)
                    UCMovimientos.Visible = True
                    UCMovimientos.BringToFront()
                    UCMovimientos.Show()
                Else
                    UCMovimientos.Visible = True
                    UCMovimientos.BringToFront()
                    UCMovimientos.Show()
                End If

            Case "Operaciones Bancarias Pendientes"

                'UCRegistroOtrosMovimientos.Visible = False
                'UCOtrosEgresos.Visible = False
                'UCMovimientos.Visible = False
                'UCMovimientosBancariosConfirmados.Visible = False
                'If UCConfirmacionBancaria IsNot Nothing Then
                '    UCConfirmacionBancaria.Visible = True
                '    UCConfirmacionBancaria.BringToFront()
                '    UCConfirmacionBancaria.Show()
                'End If


                OcultarTodos()
                If UCConfirmacionBancaria Is Nothing Then
                    UCConfirmacionBancaria = New UCConfirmacionBancaria With {.Dock = DockStyle.Fill, .Visible = False}
                    PanelBody.Controls.Add(UCConfirmacionBancaria)
                    UCConfirmacionBancaria.Visible = True
                    UCConfirmacionBancaria.BringToFront()
                    UCConfirmacionBancaria.Show()
                Else
                    UCConfirmacionBancaria.Visible = True
                    UCConfirmacionBancaria.BringToFront()
                    UCConfirmacionBancaria.Show()
                End If


            Case "Movimientos Bancarios Confirmados"

                'UCRegistroOtrosMovimientos.Visible = False
                'UCOtrosEgresos.Visible = False
                'UCMovimientos.Visible = False
                'UCMovimientosBancariosConfirmados.Visible = False
                'If UCMovimientosBancariosConfirmados IsNot Nothing Then
                '    UCMovimientosBancariosConfirmados.Visible = True
                '    UCMovimientosBancariosConfirmados.BringToFront()
                '    UCMovimientosBancariosConfirmados.Show()
                'End If
                OcultarTodos()
                If UCMovimientosBancariosConfirmados Is Nothing Then
                    UCMovimientosBancariosConfirmados = New UCMovimientosBancariosConfirmados With {.Dock = DockStyle.Fill, .Visible = False}
                    PanelBody.Controls.Add(UCMovimientosBancariosConfirmados)
                    UCMovimientosBancariosConfirmados.Visible = True
                    UCMovimientosBancariosConfirmados.BringToFront()
                    UCMovimientosBancariosConfirmados.Show()
                Else
                    UCMovimientosBancariosConfirmados.Visible = True
                    UCMovimientosBancariosConfirmados.BringToFront()
                    UCMovimientosBancariosConfirmados.Show()
                End If

        End Select
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim frmMovimientoME As New frmMovimientoME
        frmMovimientoME.StartPosition = FormStartPosition.CenterParent
        frmMovimientoME.ShowDialog(Me)
    End Sub
#End Region

End Class
