Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity

Public Class frmCrearUsuariosDelSistema

#Region "Attributes"
    Public Property strEstadoManipulacion() As String
    Public Property strTipoAdmin As String
    Public Property idUsuario As Integer
    Public Property RolSA As New RolSA

    Public Property perfilAnexoSA As New perfilAnexoSA

    Public Property CargosSA As New RolSA

    Dim producRolSA As New AutorizacionRolSA
    Dim Usuario As New AutenticacionUsuario
    Dim autorizacionRolBE As New AutorizacionRol
    Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA

    Dim ListaAsegurable As New List(Of Asegurable)

    Dim listaPermisos As New List(Of Rol)
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
        Try
            cboSeguridad.ValueMember = "idRol"
            cboSeguridad.DisplayMember = "descripcion"

            'cboSeguridad.DataSource = RolSA.GetRolesXcliente(New Rol With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})
            'cboSeguridad.DataSource = RolSA.GetRolesXcliente(Nothing)

            cboSeguridad.DataSource = perfilAnexoSA.GetObtenerPerfilIDestablecimiento(New perfilAnexo With {.idCentroCosto = GEstableciento.IdEstablecimiento})

            listaPermisos = RolSA.GetRolesXcliente(New Rol With {.idEmpresa = Gempresas.IdEmpresaRuc})


            'MODERNO
            Dim sa As New perfilAnexoSA
            Dim RolRecuperadoSA As New RolSA
            Dim listaId As New List(Of Integer)
            Dim rolbe As New perfilAnexo
            'rolbe.idCentroCosto = Gempresas.IdEmpresaRuc
            rolbe.idCentroCosto = GEstableciento.IdEstablecimiento

            Dim listaPerfil = sa.GetObtenerPerfilIDestablecimiento(rolbe)

            For Each listaRol In listaPerfil
                listaId.Add(listaRol.idRol)
            Next

            Dim lista = RolRecuperadoSA.RoleListXUnidOrg(New Rol With {.listaID = listaId})


            cboCargos.ValueMember = "IDRol"
            cboCargos.DisplayMember = "Nombre"
            cboCargos.DataSource = lista ' CargosSA.RoleList(New Rol With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub Grabar()
        Dim usuarioSA As New Seguridad.WCFService.ServiceAccess.UsuarioSA
        Usuario = New AutenticacionUsuario
        Usuario.CustomUsuario = New Usuario
        Try
            With Usuario.CustomUsuario
                .Action = Business.Entity.BaseBE.EntityAction.INSERT
                .IDCliente = Gempresas.IDCliente
                .ApellidoPaterno = txtPaterno.Text.Trim
                .ApellidoMaterno = txtMaterno.Text.Trim
                '   .IDCliente = "GENERICO"
                .IDEmpresa = Gempresas.IdEmpresaRuc
                '.IDEstablecimiento = GEstableciento.IdEstablecimiento
                .Nombres = txtNombres.Text.Trim
                .TipoDocumento = "DNI"
                .NroDocumento = txtDni.Text.Trim
                .estado = "A"
                .codigo = txtCodigoAsig.Text
                .CorreoElectronico = txtEmail.Text
                .UsuarioActualizacion = "Sistema"
                .FechaActualizacion = Date.Now
                .idUsuarioResponsable = 0
            End With

            With Usuario
                .Action = Business.Entity.BaseBE.EntityAction.INSERT
                .IDCliente = Gempresas.IDCliente
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
                .IDEstablecimiento = GEstableciento.IdEstablecimiento
                .IdEmpresa = Gempresas.IdEmpresaRuc
                '.Trial = chkTrial.Checked
                '.FechaInicioVigencia = dtpFechaIniVigencia.Value
                '.FechaFinVigencia = dtpFechaFinVigencia.Value
            End With

            Usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
            With Usuario.CustomUsuario.CustomUsuarioRol
                .Action = Business.Entity.BaseBE.EntityAction.INSERT

                '.IDRol = cboSeguridad.SelectedValue
                .IDRol = lblidPermiso.Text
                If cboCargos.Text.Trim.Length > 0 Then

                    .IDRol = cboCargos.SelectedValue
                    .predeterminado = True

                End If

                'If rbAdmin.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.ADMIN
                'If rbUser.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.USUARIO
                'If rbInvitado.Checked Then .IDRol = Constantes.SEGURIDAD.Roles.INVITADO
                .UsuarioActualizacion = "Sistema"
                .FechaActualizacion = Date.Now
            End With
            Dim idUsuario As Integer
            'idUsuario = AutenticacionUsuarioSA.AutenticacionUsuarioGrabarTodo(Usuario)

            idUsuario = AutenticacionUsuarioSA.AutenticacionUsuarioGrabarTodoXModulo(Usuario, ListaAsegurable)

            MessageBox.Show("Usuario grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            UsuariosList = usuarioSA.ListadoUsuariosv2()
            Seguridad.General.ListaUsuariosSoftpack = UsuariosList
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

        If cboCargos.Text.Trim.Length > 0 Then
            If txtNombres.Text.Trim.Length > 0 Then
                If txtPaterno.Text.Trim.Length > 0 Then
                    If txtMaterno.Text.Trim.Length > 0 Then
                        If txtPass.Text.Trim.Length > 0 Then
                            If (txtDni.Text.Length = 8) Then
                                Select Case strEstadoManipulacion
                                    Case ENTITY_ACTIONS.INSERT

                                        Dim f As New FrmConfiguracionPerfilXUsuario
                                        f.txtIdRol.Text = cboCargos.SelectedValue
                                        f.txtRol.Text = cboCargos.Text
                                        f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                                        f.cargarAsegurable()
                                        f.StartPosition = FormStartPosition.CenterParent
                                        f.ShowDialog(Me)

                                        If f.Tag IsNot Nothing Then
                                            Dim ent = CType(f.Tag, List(Of Asegurable))
                                            ListaAsegurable = ent
                                        Else
                                            ListaAsegurable = Nothing
                                        End If

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


        Else
            MsgBox("Seleccione un Cargo o Crear uno nuevo", MsgBoxStyle.Information, "!Atención")
            txtNombres.Focus()

        End If
    End Sub

    Private Sub cboSeguridad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSeguridad.SelectedIndexChanged
        'If (cboSeguridad.SelectedIndex >= 0) Then
        '    autorizacionRolBE.IDRol = cboSeguridad.SelectedValue
        '    txtNombreProducto.Text = producRolSA.GetProductoXRolXID(autorizacionRolBE).Nomasegurable
        'End If
    End Sub

    Private Sub frmCrearUsuariosDelSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboCargos_Click(sender As Object, e As EventArgs) Handles cboCargos.Click

    End Sub

    Private Sub cboCargos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCargos.SelectedValueChanged
        If listaPermisos.Count > 0 Then

            Dim consulta = (From i In listaPermisos
                            ).FirstOrDefault

            If consulta IsNot Nothing Then
                lblidPermiso.Text = consulta.IDRol
            End If


        End If


    End Sub

    Private Sub cboSeguridad_Click(sender As Object, e As EventArgs) Handles cboSeguridad.Click

    End Sub

    Private Sub cboSeguridad_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSeguridad.SelectedValueChanged

    End Sub
#End Region

End Class