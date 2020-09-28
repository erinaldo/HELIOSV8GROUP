Imports System.ComponentModel
Imports System.Net
Imports System.IO
Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Windows.Forms
Public Class UCPrincipalUsuarios

#Region "Atributos"
    Private TabUsuarios As TabUsuarios
    Private TabCargos As TabCargos
    Private TabControlSubordinados As TabControlSubordinados
#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If validarPermisos(PermisosDelSistema.CONTROL_USUARIOS_, AutorizacionRolList) = 1 Then
            TabUsuarios = New TabUsuarios With {.Dock = DockStyle.Fill, .Visible = True}
        ElseIf (usuario.nombreCargo = "SUPER_ADMINISTRADOR") Then
            TabUsuarios = New TabUsuarios With {.Dock = DockStyle.Fill, .Visible = True}
        Else
            TabUsuarios = New TabUsuarios With {.Dock = DockStyle.Fill, .Visible = False}
        End If

        TabCargos = New TabCargos With {.Dock = DockStyle.Fill, .Visible = False}
        TabControlSubordinados = New TabControlSubordinados With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(TabUsuarios)
        PanelBody.Controls.Add(TabCargos)
        PanelBody.Controls.Add(TabControlSubordinados)
    End Sub

    Private Sub btnCargos_Click(sender As Object, e As EventArgs) Handles btnCargos.Click, btnUsuarios.Click, btnResponsable.Click
        Try

            Dim btn = sender
            'Dim btn2 = CType(sender, Button)

            If btn IsNot Nothing Then
                Select Case btn.Text
                    Case "CARGOS"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        TabUsuarios.Visible = False
                        TabControlSubordinados.Visible = False
                        If TabCargos IsNot Nothing Then
                            TabCargos.Visible = True
                            TabCargos.BringToFront()
                            TabCargos.Show()
                        End If
                    Case "USUARIOS"
                        If validarPermisos(PermisosDelSistema.CONTROL_USUARIOS_, AutorizacionRolList) = 1 Then
                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            TabCargos.Visible = False
                            TabControlSubordinados.Visible = False
                            If TabUsuarios IsNot Nothing Then
                                TabUsuarios.Visible = True
                                TabUsuarios.BringToFront()
                                TabUsuarios.Show()
                            End If
                        ElseIf (usuario.nombreCargo = "SUPER_ADMINISTRADOR") Then
                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            TabCargos.Visible = False
                            TabControlSubordinados.Visible = False
                            If TabUsuarios IsNot Nothing Then
                                TabUsuarios.Visible = True
                                TabUsuarios.BringToFront()
                                TabUsuarios.Show()
                            End If
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Case "RESPONSABLES"
                        If validarPermisos(PermisosDelSistema.ASIGNAR_RESPONSABLE_, AutorizacionRolList) = 1 Then
                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            TabCargos.Visible = False
                            TabUsuarios.Visible = False
                            If TabControlSubordinados IsNot Nothing Then
                                TabControlSubordinados.Visible = True
                                TabControlSubordinados.CargarCargos()
                                TabControlSubordinados.BringToFront()
                                TabControlSubordinados.Show()
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

    Private Sub btnResponsable_Click(sender As Object, e As EventArgs)

    End Sub



#End Region

#Region "Metodos"

#End Region

End Class
