Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCreaUsuarioEmpresa
    Inherits frmMaster

#Region "métodos"
    Public Sub Grabar()

        Try
            Dim Usuario As New AutenticacionUsuario
            Usuario.CustomUsuario = New Usuario

            With Usuario.CustomUsuario
                .Action = BaseBE.EntityAction.INSERT
                .ApellidoPaterno = txtAappat.Text.Trim
                .ApellidoMaterno = txtApmat.Text.Trim
                .IDCliente = "GENERICO" ' Constante.Seguridad.IDCLIENTEGERENICO"
                .Nombres = txtNombres.Text.Trim
                .TipoDocumento = "DNI"
                .NroDocumento = txtDNI.Text.Trim
                .CorreoElectronico = ""
                .UsuarioActualizacion = "Sistema"
                .FechaActualizacion = Date.Now
            End With

            With Usuario
                .Action = BaseBE.EntityAction.INSERT
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
                If rbAdmin.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.ADMIN
                If rbUser.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.USUARIO
                If rbInvitado.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.INVITADO
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

    Private Sub frmCreaUsuarioEmpresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCreaUsuarioEmpresa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click

        If txtNombres.Text.Trim.Length > 0 Then
            If txtAappat.Text.Trim.Length > 0 Then
                If txtApmat.Text.Trim.Length > 0 Then
                    If txtPass.Text.Trim.Length > 0 Then
                        If (txtDNI.Text.Length = 8) Then
                            Grabar()
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

    Private Sub chkTrial_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTrial.CheckedChanged
        If chkTrial.Checked Then
            dtpFechaIniVigencia.Value = Date.Now
            dtpFechaFinVigencia.Value = Date.Now.AddDays(15)
        Else
            dtpFechaIniVigencia.Value = Date.Now
            dtpFechaFinVigencia.Value = Date.Now.AddYears(1)
        End If
    End Sub


    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Dispose()
    End Sub
End Class