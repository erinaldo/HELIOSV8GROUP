Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmUsuariosDelSistema

#Region "Attributes"
    Public Property strEstadoManipulacion() As String
    Public Property strTipoAdmin As String
    Public Property idUsuario As Integer
    Public Property RolSA As New RolSA
    Dim Usuario As New AutenticacionUsuario
    Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetPefiles()
    End Sub
#End Region

#Region "Methods"

    Sub GetPefiles()
        cboSeguridad.ValueMember = "IDRol"
        cboSeguridad.DisplayMember = "Nombre"
        cboSeguridad.DataSource = RolSA.ListadoRoles
    End Sub

    Public Sub Grabar()

        Try
            Usuario = New AutenticacionUsuario
            Usuario.CustomUsuario = New Usuario

            With Usuario.CustomUsuario
                .Action = BaseBE.EntityAction.INSERT
                .ApellidoPaterno = txtPaterno.Text.Trim
                .ApellidoMaterno = txtMaterno.Text.Trim
                .IDCliente = "GENERICO"
                .Nombres = txtNombres.Text.Trim
                .TipoDocumento = "DNI"
                .NroDocumento = txtDni.Text.Trim
                .CorreoElectronico = txtEmail.Text
                .UsuarioActualizacion = "Sistema"
                .FechaActualizacion = Date.Now
            End With

            With Usuario
                .Action = BaseBE.EntityAction.INSERT
                .AliasLogin = txtAlias.Text
                .Alias = txtAlias.Text.Trim
                .Contrasena = txtPass.Text.Trim
                .CorreoElectronico = txtEmail.Text
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

                .IDRol = cboSeguridad.SelectedValue
                'If rbAdmin.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.ADMIN
                'If rbUser.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.USUARIO
                'If rbInvitado.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.INVITADO
                .UsuarioActualizacion = "Sistema"
                .FechaActualizacion = Date.Now
            End With
            Dim idUsuario As Integer
            idUsuario = AutenticacionUsuarioSA.AutenticacionUsuarioGrabarTodo(Usuario)
            MessageBox.Show("Usuario grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
            'If MessageBox.Show("Desea asignar una caja para este usuario?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '    Dim f As New frmAbrirCajaUsuario ' frmCreaUsuarioEmpresa
            '    f.cboPersona.Text = txtNombres.Text & " " & txtAappat.Text & " " & txtApmat.Text
            '    f.cboPersona.SelectedValue = idUsuario
            '    f.txtDni.Text = txtDNI.Text
            '    f.cboPersona.Enabled = False
            '    f.txtDni.Enabled = False
            '    f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            '    f.StartPosition = FormStartPosition.CenterParent
            '    f.ShowDialog()
            'End If

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
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Close()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If txtNombres.Text.Trim.Length > 0 Then
            If txtPaterno.Text.Trim.Length > 0 Then
                If txtMaterno.Text.Trim.Length > 0 Then
                    If txtPass.Text.Trim.Length > 0 Then
                        If (txtDni.Text.Length = 8) Then
                            Select Case strEstadoManipulacion
                                Case ENTITY_ACTIONS.INSERT
                                    Grabar()
                                Case ENTITY_ACTIONS.UPDATE
                                    'UpdateUsuario()
                                    Close()
                            End Select

                        Else
                            MsgBox("Ingrese un dni valido.", MsgBoxStyle.Information, "!Atención")
                            txtPass.Focus()
                            txtPass.Select()
                            txtPass.Select(0, txtDni.Text.Length)
                        End If
                    Else
                        MsgBox("Ingrese una contraseña válida.", MsgBoxStyle.Information, "!Atención")
                        txtPass.Focus()
                    End If

                Else
                    MsgBox("Ingrese el apellido materno.", MsgBoxStyle.Information, "!Atención")
                    txtMaterno.Focus()
                End If
            Else
                MsgBox("Ingrese el apellido paterno.", MsgBoxStyle.Information, "!Atención")
                txtPaterno.Focus()
            End If
        Else
            MsgBox("Ingrese el nombre(s).", MsgBoxStyle.Information, "!Atención")
            txtNombres.Focus()
        End If
    End Sub
#End Region

End Class