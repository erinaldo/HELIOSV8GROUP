Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class UCPrincipalKardex

#Region "Atributos"

    Public Property UCInventario As UCInventario
    Public Property UCKardex As UCKardex
    'Public Property UCOtrasEntradas As UCOtrasEntradas
    'Public Property UCOtrasSalidas As UCOtrasSalidas
    Public Property UCInventarioInicial As UCInventarioInicial

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        If validarPermisos(PermisosDelSistema.KARDEX_, AutorizacionRolList) = 1 Then
                UCInventario = New UCInventario With {.Dock = DockStyle.Fill, .Visible = True}
            Else
                UCInventario = New UCInventario With {.Dock = DockStyle.Fill, .Visible = False}
            End If


        UCKardex = New UCKardex With {.Dock = DockStyle.Fill, .Visible = False}
        'UCOtrasEntradas = New UCOtrasEntradas With {.Dock = DockStyle.Fill, .Visible = False}
        'UCOtrasSalidas = New UCOtrasSalidas With {.Dock = DockStyle.Fill, .Visible = False}
        UCInventarioInicial = New UCInventarioInicial With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(UCInventario)
        PanelBody.Controls.Add(UCKardex)
        'PanelBody.Controls.Add(UCOtrasEntradas)
        'PanelBody.Controls.Add(UCOtrasSalidas)
        PanelBody.Controls.Add(UCInventarioInicial)
    End Sub

    Private Sub btnKardex_Click(sender As Object, e As EventArgs) Handles btnKardex.Click, btnKardexMovimientos.Click
        Try

            Dim btn = sender
            'Dim btn2 = CType(sender, Button)

            If btn IsNot Nothing Then
                Select Case btn.Text
                    Case "KARDEX"
                        If validarPermisos(PermisosDelSistema.KARDEX_, AutorizacionRolList) = 1 Then

                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            UCKardex.Visible = False
                            'UCOtrasEntradas.Visible = False
                            'UCOtrasSalidas.Visible = False
                            UCInventarioInicial.Visible = False
                            If UCInventario IsNot Nothing Then
                                UCInventario.Visible = True
                                UCInventario.BringToFront()
                                UCInventario.Show()
                            End If
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Case "MOVIMIENTOS DE KARDEX"
                        If validarPermisos(PermisosDelSistema.MOVIMIENTO_KARDEX_, AutorizacionRolList) = 1 Then

                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            UCInventario.Visible = False
                            'UCOtrasEntradas.Visible = False
                            'UCOtrasSalidas.Visible = False
                            UCInventarioInicial.Visible = False
                            If UCKardex IsNot Nothing Then
                                UCKardex.Visible = True
                                UCKardex.BringToFront()
                                UCKardex.Show()
                            End If
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    'Case "OTRAS ENTRADAS"
                    '    If validarPermisos(PermisosDelSistema.SALIDA_DE_INVENTARIO_, AutorizacionRolList) = 1 Then

                    '        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                    '        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                    '        UCInventario.Visible = False
                    '        UCKardex.Visible = False
                    '        UCOtrasSalidas.Visible = False
                    '        UCInventarioInicial.Visible = False
                    '        If UCOtrasEntradas IsNot Nothing Then
                    '            UCOtrasEntradas.Visible = True
                    '            UCOtrasEntradas.BringToFront()
                    '            UCOtrasEntradas.Show()
                    '        End If
                    '    Else
                    '        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    End If
                    'Case "OTRAS SALIDAS"
                    '    If validarPermisos(PermisosDelSistema.ENTRADA_INVENTARIO_, AutorizacionRolList) = 1 Then

                    '        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                    '        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                    '        UCInventario.Visible = False
                    '        UCKardex.Visible = False
                    '        UCOtrasEntradas.Visible = False
                    '        UCInventarioInicial.Visible = False
                    '        If UCOtrasSalidas IsNot Nothing Then
                    '            UCOtrasSalidas.Visible = True
                    '            UCOtrasSalidas.BringToFront()
                    '            UCOtrasSalidas.Show()
                    '        End If
                    '    Else
                    '        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    End If
                    Case "INVENTARIO INICIAL"
                        If validarPermisos(PermisosDelSistema.INVENTARIO_INICIAL_, AutorizacionRolList) = 1 Then

                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            UCInventario.Visible = False
                            UCKardex.Visible = False
                            'UCOtrasEntradas.Visible = False
                            'UCOtrasSalidas.Visible = False
                            If UCInventarioInicial IsNot Nothing Then
                                UCInventarioInicial.Visible = True
                                UCInventarioInicial.BringToFront()
                                UCInventarioInicial.Show()
                            End If
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnInventarioInicial_Click(sender As Object, e As EventArgs)

    End Sub




#End Region

End Class
