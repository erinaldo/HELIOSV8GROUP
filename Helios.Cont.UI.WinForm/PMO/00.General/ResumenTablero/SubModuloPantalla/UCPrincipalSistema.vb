Public Class UCPrincipalSistema

#Region "Atributos"

    Public UCAdministrarCuentas As UCAdministrarCuentas
    'Public UCCierresDelPeriodo As UCCierresDelPeriodo
    Public TabCM_RegistroDatosGenerales As TabCM_RegistroDatosGenerales
    Public UCInventarioInicial As UCInventarioInicial
#End Region
#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCAdministrarCuentas = New UCAdministrarCuentas With {.Dock = DockStyle.Fill, .Visible = True}
        'TabCM_RegistroDatosGenerales = New TabCM_RegistroDatosGenerales With {.Dock = DockStyle.Fill, .Visible = False}
        ' UCInventarioInicial = New UCInventarioInicial With {.Dock = DockStyle.Fill, .Visible = False}

        'UCCierresDelPeriodo = New UCCierresDelPeriodo With {.Dock = DockStyle.Fill, .Visible = False}
        'TabCargos = New TabCargos With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCAdministrarCuentas)
        'PanelBody.Controls.Add(TabCM_RegistroDatosGenerales)
        'PanelBody.Controls.Add(UCInventarioInicial)
        'PanelBody.Controls.Add(UCCierresDelPeriodo)
        'PanelBody.Controls.Add(TabCargos)
    End Sub


#Region "Metodos"

    Public Sub OcultarTodos()
        If UCAdministrarCuentas IsNot Nothing Then
            UCAdministrarCuentas.Visible = False
        End If
        'If UCCierresDelPeriodo IsNot Nothing Then
        '    UCCierresDelPeriodo.Visible = False
        'End If
        If TabCM_RegistroDatosGenerales IsNot Nothing Then
            TabCM_RegistroDatosGenerales.Visible = False
        End If
        If UCInventarioInicial IsNot Nothing Then
            UCInventarioInicial.Visible = False
        End If

    End Sub
#End Region

    Private Sub btnCierresDelPeriodo_Click(sender As Object, e As EventArgs) Handles btnConfiguracionFinanciera.Click, btnImpresion.Click, btnInventarioInicial.Click
        Try
            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
            Dim btn = sender
            'Dim btn2 = CType(sender, Button)

            If btn IsNot Nothing Then

                Select Case btn.Text
                    'Case "CIERRES DEL PERIODO"
                    '    If validarPermisos(PermisosDelSistema.CIERRE_DE_PERIODO_, AutorizacionRolList) = 1 Then

                    '        OcultarTodos()
                    '        If UCCierresDelPeriodo Is Nothing Then
                    '            UCCierresDelPeriodo = New UCCierresDelPeriodo With {.Dock = DockStyle.Fill, .Visible = False}
                    '            PanelBody.Controls.Add(UCCierresDelPeriodo)
                    '            UCCierresDelPeriodo.Visible = True
                    '            UCCierresDelPeriodo.BringToFront()
                    '            UCCierresDelPeriodo.Show()
                    '        Else
                    '            UCCierresDelPeriodo.Visible = True
                    '            UCCierresDelPeriodo.BringToFront()
                    '            UCCierresDelPeriodo.Show()
                    '        End If
                    '    Else
                    '        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    End If


                    Case "CONFIG. FINANCIERA"
                        If validarPermisos(PermisosDelSistema.CONFIGURAR_CAJAS_, AutorizacionRolList) = 1 Then

                            OcultarTodos()

                            If UCAdministrarCuentas IsNot Nothing Then
                                UCAdministrarCuentas.Visible = True
                                UCAdministrarCuentas.BringToFront()
                                UCAdministrarCuentas.Show()
                            End If
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    Case "IMPRESION"
                        If validarPermisos(PermisosDelSistema.IMPRESION, AutorizacionRolList) = 1 Then

                            OcultarTodos()
                            If TabCM_RegistroDatosGenerales Is Nothing Then
                                TabCM_RegistroDatosGenerales = New TabCM_RegistroDatosGenerales With {.Dock = DockStyle.Fill, .Visible = False}
                                PanelBody.Controls.Add(TabCM_RegistroDatosGenerales)
                                TabCM_RegistroDatosGenerales.Visible = True
                                TabCM_RegistroDatosGenerales.BringToFront()
                                TabCM_RegistroDatosGenerales.Show()
                            Else
                                TabCM_RegistroDatosGenerales.Visible = True
                                TabCM_RegistroDatosGenerales.BringToFront()
                                TabCM_RegistroDatosGenerales.Show()
                            End If

                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Case "INVENTARIO INICIAL"

                        OcultarTodos()
                        If UCInventarioInicial Is Nothing Then
                            UCInventarioInicial = New UCInventarioInicial With {.Dock = DockStyle.Fill, .Visible = False}
                            PanelBody.Controls.Add(UCInventarioInicial)
                            UCInventarioInicial.Visible = True
                            UCInventarioInicial.BringToFront()
                            UCInventarioInicial.Show()
                        Else
                            UCInventarioInicial.Visible = True
                            UCInventarioInicial.BringToFront()
                            UCInventarioInicial.Show()
                        End If

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCierreMensual_Click(sender As Object, e As EventArgs) Handles btnCierreMensual.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CIERRE_MENSUAL_, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.CIERRE_DE_PERIODO_, AutorizacionRolList) = 1 Then
            Dim f As New frmselectCierre
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

#End Region

#Region "Metodos"



#End Region
End Class
