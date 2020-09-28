

Public Class UCPrincipalFinanzas


#Region "Atributos"

    Public UCControlOperaciones As UCControlOperaciones
    Private UCCuentasXpagar As UCCuentasXpagar
    Private UCCuentasXcobrar As UCCuentasXcobrar

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'If validarPermisos(PermisosDelSistema.CUENTAS_POR_PAGAR_, AutorizacionRolList) = 1 Then
        'UCCuentasXcobrar = New UCCuentasXcobrar With {.Dock = DockStyle.Fill, .Visible = True}
        'Else
        'UCCuentasXcobrar = New UCCuentasXcobrar With {.Dock = DockStyle.Fill, .Visible = False}
        'End If
        UCControlOperaciones = New UCControlOperaciones With {.Dock = DockStyle.Fill, .Visible = True}

        'UCCuentasXpagar = New UCCuentasXpagar With {.Dock = DockStyle.Fill, .Visible = False}
        'UCControlOperaciones = New UCControlOperaciones With {.Dock = DockStyle.Fill, .Visible = False}
        'UCArqueoCaja = New UCArqueoCaja With {.Dock = DockStyle.Fill, .Visible = False}
        'UCHistorialCajaUsuario = New UCHistorialCajaUsuario With {.Dock = DockStyle.Fill, .Visible = False}
        'PanelBody.Controls.Add(UCCuentasXpagar)
        'PanelBody.Controls.Add(UCCuentasXcobrar)
        PanelBody.Controls.Add(UCControlOperaciones)
        'PanelBody.Controls.Add(UCArqueoCaja)
        'PanelBody.Controls.Add(UCHistorialCajaUsuario)
    End Sub

    Private Sub btnCuentasPorCobrar_Click(sender As Object, e As EventArgs) Handles btnCuentasPorCobrar.Click, btnCuentasPorPagar.Click, btnMovimientosCaja.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text

            Case "CUENTAS POR PAGAR"
                If validarPermisos(PermisosDelSistema.CUENTAS_POR_PAGAR_, AutorizacionRolList) = 1 Then
                    OcultarTodos()
                    If UCCuentasXpagar Is Nothing Then
                        UCCuentasXpagar = New UCCuentasXpagar With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCCuentasXpagar)
                        UCCuentasXpagar.Visible = True
                        UCCuentasXpagar.BringToFront()
                        UCCuentasXpagar.Show()
                    Else
                        UCCuentasXpagar.Visible = True
                        UCCuentasXpagar.BringToFront()
                        UCCuentasXpagar.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "CUENTAS POR COBRAR"

                If validarPermisos(PermisosDelSistema.CUENTAS_POR_COBRAR_, AutorizacionRolList) = 1 Then
                    OcultarTodos()

                    If UCCuentasXcobrar Is Nothing Then
                        UCCuentasXcobrar = New UCCuentasXcobrar With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCCuentasXcobrar)
                        UCCuentasXcobrar.Visible = True
                        UCCuentasXcobrar.BringToFront()
                        UCCuentasXcobrar.Show()
                    Else
                        UCCuentasXcobrar.Visible = True
                        UCCuentasXcobrar.BringToFront()
                        UCCuentasXcobrar.Show()
                    End If

                    'If UCCuentasXcobrar IsNot Nothing Then
                    '    UCCuentasXcobrar.Visible = True
                    '    UCCuentasXcobrar.BringToFront()
                    '    UCCuentasXcobrar.Show()
                    'End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "MOVIMIENTOS"
                If validarPermisos(PermisosDelSistema.MOVIMIENTO_FINANZAS_, AutorizacionRolList) = 1 Then
                    OcultarTodos()

                    If UCControlOperaciones IsNot Nothing Then
                        UCControlOperaciones.Visible = True
                        UCControlOperaciones.BringToFront()
                        UCControlOperaciones.Show()
                    End If

                    'If UCControlOperaciones Is Nothing Then
                    '    UCControlOperaciones = New UCControlOperaciones With {.Dock = DockStyle.Fill, .Visible = False}
                    '    PanelBody.Controls.Add(UCControlOperaciones)
                    '    UCControlOperaciones.Visible = True
                    '    UCControlOperaciones.BringToFront()
                    '    UCControlOperaciones.Show()
                    'Else
                    '    UCControlOperaciones.Visible = True
                    '    UCControlOperaciones.BringToFront()
                    '    UCControlOperaciones.Show()
                    'End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If


        End Select
    End Sub





#End Region

#Region "Metodos"
    Public Sub OcultarTodos()
        If UCControlOperaciones IsNot Nothing Then
            UCControlOperaciones.Visible = False
        End If
        If UCCuentasXpagar IsNot Nothing Then
            UCCuentasXpagar.Visible = False
        End If
        If UCCuentasXcobrar IsNot Nothing Then
            UCCuentasXcobrar.Visible = False
        End If

    End Sub
#End Region


End Class
