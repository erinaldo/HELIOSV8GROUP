Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCrearUsuarioEmpresa
    Inherits frmMaster

    Public Property strEstadoManipulacion() As String
    Public Property strTipoAdmin As String
    Public Property idUsuario As Integer

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        btOperacion.EnableTouchMode = False
        ButtonAdv2.EnableTouchMode = False
    End Sub

#Region "métodos"

    Sub limpiarCajas()
        txtNombres.Clear()
        txtAappat.Clear()
        txtApmat.Clear()
        txtDNI.Clear()
        txtAlias.Clear()
        txtPass.Clear()
        chkTrial.Checked = False
        dtpFechaIniVigencia.Value = Date.Now
        dtpFechaFinVigencia.Value = Date.Now
    End Sub

    Sub CargarDatos()
        'Select Case strTipoAdmin
        '    Case "CAJERO"
        '        pnCajero.Location = New Point(20, 20)
        '        pnVendedor.Visible = False
        '        pnAdmin.Visible = False
        '        pnCajero.Visible = True
        '    Case "ADMIN"
        '        pnCajero.Location = New Point(207, 20)
        '        pnVendedor.Location = New Point(100, 18)
        '        pnVendedor.Visible = False
        '        pnAdmin.Visible = True
        '        pnCajero.Visible = False
        '    Case "VENDEDOR"
        '        pnCajero.Location = New Point(207, 20)
        '        pnVendedor.Location = New Point(20, 20)
        '        pnVendedor.Visible = True
        '        pnAdmin.Visible = False
        '        pnCajero.Visible = False
        'End Select
    End Sub

    Public Sub Grabar()

        Try
            Dim Usuario As New AutenticacionUsuario
            Usuario.CustomUsuario = New Usuario

            With Usuario.CustomUsuario
                .Action = BaseBE.EntityAction.INSERT
                .ApellidoPaterno = txtAappat.Text.Trim
                .ApellidoMaterno = txtApmat.Text.Trim
                .IDCliente = "GENERICO"
                .Nombres = txtNombres.Text.Trim
                .TipoDocumento = "DNI"
                .NroDocumento = txtDNI.Text.Trim
                .CorreoElectronico = ""
                .UsuarioActualizacion = "Sistema"
                .FechaActualizacion = Date.Now
            End With

            With Usuario
                .Action = BaseBE.EntityAction.INSERT
                .AliasLogin = txtAlias.Text
                .Alias = txtAlias.Text.Trim
                .Contrasena = txtPass.Text.Trim
                .CorreoElectronico = ""
                .EstaAutenticado = True
                .FechaActualizacion = Date.Now
                .PreguntaSecreta = ""
                .RespuestaSecreta = ""
                .UltimaFechaCambioPassword = Date.Now
                .UltimaFechaLogueo = Date.Now
                .UsuarioActualizacion = "Sistema"
                .Bloqueado = False
                '.Trial = chkTrial.Checked
                '.FechaInicioVigencia = dtpFechaIniVigencia.Value
                '.FechaFinVigencia = dtpFechaFinVigencia.Value
            End With

            Usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
            With Usuario.CustomUsuario.CustomUsuarioRol
                .Action = BaseBE.EntityAction.INSERT
                If rbCajeroCentral.Checked = True Then
                    .IDRol = 3
                Else
                    .IDRol = 4
                End If

                .UsuarioActualizacion = "Sistema"
                .FechaActualizacion = Date.Now
            End With

            Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
            Dim idUsuario As Integer

            idUsuario = AutenticacionUsuarioSA.AutenticacionUsuarioGrabarTodo(Usuario)
            MessageBox.Show("Usuario grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
            If MessageBox.Show("Desea asignar una caja para este usuario?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim f As New frmAbrirCajaUsuario ' frmCreaUsuarioEmpresa
                f.cboPersona.Text = txtNombres.Text & " " & txtAappat.Text & " " & txtApmat.Text
                f.cboPersona.SelectedValue = idUsuario
                f.txtDni.Text = txtDNI.Text
                f.cboPersona.Enabled = False
                f.txtDni.Enabled = False
                f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox("Error al grabar usuario. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

        'Dim objservice = HeliosSEProxy.CrearProxyHELIOS()
        'Dim objUserEO As New HeliosService.UsuariosEmpresaEO()
        'Try
        '    With objUserEO
        '        .dni = Convert.ToInt32(txtDNI.Text)
        '        .IdEmpresa = CEmpresa
        '        .appat = Convert.ToString(txtAappat.Text.Trim)
        '        .apmat = Convert.ToString(txtApmat.Text.Trim)
        '        .nombres = Convert.ToString(txtNombres.Text.Trim)
        '        .password = Convert.ToString(txtPass.Text.Trim)
        '    End With
        '    If objservice.GetUserCreate(objUserEO) Then
        '        MessageBox.Show("Usuario grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Close()
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error al grabar usuario. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        'End Try
    End Sub

    Public Sub UpdateUsuario()

        Try
            Dim Usuario As New AutenticacionUsuario
            Usuario.CustomUsuario = New Usuario

            With Usuario.CustomUsuario
                .Action = BaseBE.EntityAction.UPDATE
                .ApellidoPaterno = txtAappat.Text.Trim
                .ApellidoMaterno = txtApmat.Text.Trim
                .IDCliente = "GENERICO"
                .Nombres = txtNombres.Text.Trim
                .TipoDocumento = "DNI"
                .NroDocumento = txtDNI.Text.Trim
                .CorreoElectronico = ""
                .UsuarioActualizacion = "Sistema"
                .FechaActualizacion = Date.Now
            End With

            With Usuario
                .Action = BaseBE.EntityAction.UPDATE
                .IDUsuario = idUsuario
                .AliasLogin = txtAlias.Text
                .Alias = txtAlias.Text.Trim
                .Contrasena = txtPass.Text.Trim
                .CorreoElectronico = ""
                .EstaAutenticado = True
                .FechaActualizacion = Date.Now
                .PreguntaSecreta = ""
                .RespuestaSecreta = ""
                .UltimaFechaCambioPassword = Date.Now
                .UltimaFechaLogueo = Date.Now
                .UsuarioActualizacion = "Sistema"
                .Bloqueado = False
                '.Trial = chkTrial.Checked
                '.FechaInicioVigencia = dtpFechaIniVigencia.Value
                '.FechaFinVigencia = dtpFechaFinVigencia.Value
            End With

            Usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
            With Usuario.CustomUsuario.CustomUsuarioRol
                .Action = BaseBE.EntityAction.UPDATE
                'If rbAdmin.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.ADMIN
                'If rbUser.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.USUARIO
                'If rbInvitado.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.INVITADO
                .UsuarioActualizacion = "Sistema"
                .FechaActualizacion = Date.Now
            End With

            Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
            AutenticacionUsuarioSA.AutenticacionUsuarioGrabarTodo(Usuario)
            MessageBox.Show("Usuario grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        Catch ex As Exception
            MsgBox("Error al grabar usuario. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try

    End Sub

    Public Sub UbicarUsaurio(dni As Integer)
        Dim UsuarioSA As New UsuarioSA
        Dim UsuarioBL As New Usuario

        UsuarioBL = UsuarioSA.UbicarUsuarioCaja(New Usuario With {.IDUsuario = dni})

        If (Not IsNothing(UsuarioBL)) Then
            txtNombres.Text = UsuarioBL.Nombres
            txtAappat.Text = UsuarioBL.ApellidoPaterno
            txtApmat.Text = UsuarioBL.ApellidoMaterno
            txtDNI.Text = UsuarioBL.NroDocumento
            txtAlias.Text = UsuarioBL.userName
            txtPass.Text = UsuarioBL.password
        End If
       
    End Sub

#End Region


    Private Sub frmCrearUsuarioEmpresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub chkTrial_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrial.CheckedChanged
        If chkTrial.Checked Then
            dtpFechaIniVigencia.Value = Date.Now
            dtpFechaFinVigencia.Value = Date.Now.AddDays(15)
        Else
            dtpFechaIniVigencia.Value = Date.Now
            dtpFechaFinVigencia.Value = Date.Now.AddYears(1)
        End If
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If txtNombres.Text.Trim.Length > 0 Then
            If txtAappat.Text.Trim.Length > 0 Then
                If txtApmat.Text.Trim.Length > 0 Then
                    If txtPass.Text.Trim.Length > 0 Then
                        If (txtDNI.Text.Length = 8) Then
                            Select Case strEstadoManipulacion
                                Case ENTITY_ACTIONS.INSERT
                                    Grabar()
                                Case ENTITY_ACTIONS.UPDATE
                                    UpdateUsuario()
                                    Dispose()
                            End Select

                        Else
                            MsgBox("Ingrese un dni valido.", MsgBoxStyle.Information, "!Atención")
                            txtPass.Focus()
                            txtPass.Select()
                            txtPass.Select(0, txtDNI.Text.Length)
                        End If
                    Else
                        MsgBox("Ingrese una contraseña válida.", MsgBoxStyle.Information, "!Atención")
                        txtPass.Focus()
                    End If

                Else
                    MsgBox("Ingrese el apellido materno.", MsgBoxStyle.Information, "!Atención")
                    txtApmat.Focus()
                End If
            Else
                MsgBox("Ingrese el apellido paterno.", MsgBoxStyle.Information, "!Atención")
                txtAappat.Focus()
            End If
        Else
            MsgBox("Ingrese el nombre(s).", MsgBoxStyle.Information, "!Atención")
            txtNombres.Focus()
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Close()
    End Sub

    Private Sub txtNombres_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombres.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtAappat.Select()
                txtAappat.Select(0, txtAappat.Text.Length)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAappat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAappat.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtApmat.Select()
                txtApmat.Select(0, txtApmat.Text.Length)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtApmat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApmat.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtDNI.Select()
                txtDNI.Select(0, txtDNI.Text.Length)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDNI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDNI.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtAlias.Select()
                txtAlias.Select(0, txtAlias.Text.Length)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAlias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAlias.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtPass.Select()
                txtPass.Select(0, txtPass.Text.Length)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmCrearUsuarioEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class