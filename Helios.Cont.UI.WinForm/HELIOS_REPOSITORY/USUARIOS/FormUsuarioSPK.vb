Imports System.ComponentModel
Imports System.Net
Imports System.IO
Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Windows.Forms
Public Class FormUsuarioSPK
    Private UCHistorialCajaUsuario As UCHistorialCajaUsuario
    Private UCArqueoCaja As UCArqueoCaja
    Private TabUsuarios As TabUsuarios
    'Private TabPerfiles As TabPerfiles
    Private TabCargos As TabCargos
    Private TabControlSubordinados As TabControlSubordinados

    Public Property cajaUsuaroSA As New cajaUsuarioSA
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'TabPerfiles = New TabPerfiles With {.Dock = DockStyle.Fill, .Visible = False}
        UCHistorialCajaUsuario = New UCHistorialCajaUsuario With {.Dock = DockStyle.Fill, .Visible = True}
        TabUsuarios = New TabUsuarios With {.Dock = DockStyle.Fill, .Visible = False}
        UCArqueoCaja = New UCArqueoCaja With {.Dock = DockStyle.Fill, .Visible = False}
        TabCargos = New TabCargos With {.Dock = DockStyle.Fill, .Visible = False}
        TabControlSubordinados = New TabControlSubordinados With {.Dock = DockStyle.Fill, .Visible = False}

        'PanelBody.Controls.Add(TabPerfiles)
        PanelBody.Controls.Add(UCHistorialCajaUsuario)
        PanelBody.Controls.Add(TabUsuarios)
        PanelBody.Controls.Add(TabCargos)
        PanelBody.Controls.Add(TabControlSubordinados)
        PanelBody.Controls.Add(UCArqueoCaja)
        General.Centrar(Me)
        BunifuFlatButton16.Enabled = True
    End Sub

    Private Sub bunifuImageButton2_Click_1(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton16.Click, BunifuFlatButton1.Click, BunifuFlatButton3.Click, BunifuFlatButton5.Click, BunifuFlatButton6.Click

        Try



            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
            '  End If
            Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
            Select Case btn.Text
                Case "Usuario"
                    'TabPerfiles.Visible = False
                    UCHistorialCajaUsuario.Visible = False
                    TabCargos.Visible = False
                    TabControlSubordinados.Visible = False
                    UCArqueoCaja.Visible = False

                    If TabUsuarios IsNot Nothing Then
                        TabUsuarios.Visible = True
                        TabUsuarios.BringToFront()
                        TabUsuarios.Show()
                    End If
                Case "Historial cajas"
                    'TabPerfiles.Visible = False
                    TabUsuarios.Visible = False
                    TabCargos.Visible = False
                    TabControlSubordinados.Visible = False
                    UCArqueoCaja.Visible = False

                    If UCHistorialCajaUsuario IsNot Nothing Then
                        UCHistorialCajaUsuario.Visible = True
                        UCHistorialCajaUsuario.BringToFront()
                        UCHistorialCajaUsuario.Show()
                    End If
                Case "Permisos"
                    UCHistorialCajaUsuario.Visible = False
                    TabUsuarios.Visible = False
                    TabCargos.Visible = False
                    UCArqueoCaja.Visible = False
                    TabControlSubordinados.Visible = False
                    'If TabPerfiles IsNot Nothing Then
                    '    TabPerfiles.Visible = True
                    '    TabPerfiles.BringToFront()
                    '    TabPerfiles.Show()
                    'End If

                Case "Cargos"
                    UCHistorialCajaUsuario.Visible = False
                    TabUsuarios.Visible = False
                    'TabPerfiles.Visible = False
                    TabControlSubordinados.Visible = False
                    UCArqueoCaja.Visible = False

                    If TabCargos IsNot Nothing Then
                        TabCargos.Visible = True
                        TabCargos.BringToFront()
                        TabCargos.Show()
                    End If

                Case "Control de Usuario Responsable"


                    UCHistorialCajaUsuario.Visible = False
                    TabUsuarios.Visible = False
                    'TabPerfiles.Visible = False
                    TabCargos.Visible = False
                    UCArqueoCaja.Visible = False

                    If TabControlSubordinados IsNot Nothing Then
                        TabControlSubordinados.Visible = True
                        TabControlSubordinados.BringToFront()
                        TabControlSubordinados.Show()
                    End If
                Case "Arqueo de Caja"
                    UCHistorialCajaUsuario.Visible = False
                    TabUsuarios.Visible = False
                    'TabPerfiles.Visible = False
                    TabCargos.Visible = False
                    TabControlSubordinados.Visible = False

                    If UCArqueoCaja IsNot Nothing Then
                        UCArqueoCaja.Visible = True
                        UCArqueoCaja.BringToFront()
                        UCArqueoCaja.Show()
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Dim usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

        Dim f As New frmCrearUsuariosDelSistema
        f.strEstadoManipulacion = General.ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        UsuariosList = usuarioListSA.ListadoUsuariosv2()

        'PanelBody.Controls.Clear()
    End Sub


    Public Sub hola()



    End Sub
    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click

        'Try


        '    Me.Cursor = Cursors.WaitCursor

        '    If validarPermisos(PermisosDelSistema.CIERRE_DE_CAJA_, AutorizacionRolList) = 1 Then



        '        Dim cajaActiva = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        '        If cajaActiva IsNot Nothing Then

        '            MessageBox.Show("La Caja Administrativa ya esta Abierta ")
        '            Me.Cursor = Cursors.Arrow
        '            Exit Sub

        '        End If







        '        If usuario.tipoCaja = "ADM" Then
        '            Dim f As New FormCrearCajeroAdmi
        '            f.StartPosition = FormStartPosition.CenterParent
        '            f.ShowDialog(Me)
        '        Else
        '            MessageBox.Show("Su cargo no tiene permiso para Caja Administrativa", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End If
        '    Else
        '        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        '    Me.Cursor = Cursors.Arrow
        'Catch ex As Exception
        '    Me.Cursor = Cursors.Arrow
        'End Try



    End Sub

    Private Sub panelheader_Paint(sender As Object, e As PaintEventArgs) Handles panelheader.Paint

    End Sub


End Class