Imports Helios.Seguridad.Business.Entity
Imports JNetFx.Framework.General
Imports System.Transactions

Public Class AutenticacionUsuarioBL
    Inherits BaseBL
    ''' <summary>
    ''' Verifica si usuario y contraseña ingresada puede acceder al sistema
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 

    Public Function BuscarContraseñaAliasUser(usuario As AutenticacionUsuario) As AutenticacionUsuario

        Dim consulta = (From i In SeguridadData.AutenticacionUsuario
                        Where i.IDUsuario = usuario.IDUsuario).FirstOrDefault

        Return consulta

    End Function
    Public Function UpdateContrasenaUsuario(usuario As AutenticacionUsuario) As AutenticacionUsuario
        Dim obj As New Usuario
        Dim encriptador As New Cryptography

        Try

            usuario.Alias = encriptador.Encode(usuario.Alias)
            usuario.Contrasena = encriptador.Encode(usuario.Contrasena)

            Dim consultaAlias = (From s In SeguridadData.AutenticacionUsuario
                                 Where s.Alias = usuario.Alias And Not s.IDUsuario = s.IDUsuario
                                 Select s).FirstOrDefault




            If (IsNothing(consultaAlias)) Then
                Dim consulta = (From s In SeguridadData.AutenticacionUsuario
                                Where s.IDUsuario = usuario.IDUsuario
                                Select s).FirstOrDefault

                If (Not IsNothing(consulta)) Then




                    consulta.Alias = encriptador.Decode(usuario.Alias)
                    consulta.Contrasena = encriptador.getSHA1Hash(encriptador.Decode(usuario.Contrasena))




                    SeguridadData.SaveChanges()
                End If
            Else
                Throw New Exception("El Alias ya esta siendo usado por otro Usuario")
            End If
        Catch ex As Exception
            Throw ex
        End Try


        Return usuario
    End Function
    Public Function EsUsuarioAutenticado(ByRef usuario As AutenticacionUsuario) As Boolean
        Try

            Dim usuarioAutenticado As AutenticacionUsuario
            Dim encriptador As New Cryptography
            Dim strAlias As String, strContrasena As String, strIDCliente As String
            Dim IDUsuario As Integer
            Dim idEmpresa As String = String.Empty
            Dim IdEstablecimiento As Integer = 0
            EsUsuarioAutenticado = False

            strIDCliente = usuario.IDCliente
            'Se desencripta el usuario y password
            strAlias = encriptador.Decode(usuario.Alias)
            strContrasena = encriptador.Decode(usuario.Contrasena)
            'Se encripta la contraseña hash para comparar con BD
            strContrasena = encriptador.getSHA1Hash(strContrasena)
            'Se consulta el alias de usuario



            If (strAlias = "20603329156") Then
                IdEstablecimiento = 0
                idEmpresa = Nothing
            ElseIf (strAlias <> "20603329156") Then
                IdEstablecimiento = usuario.IDEstablecimiento
                idEmpresa = usuario.IdEmpresa
            End If



            usuarioAutenticado = (From a In SeguridadData.AutenticacionUsuario
                                  Join u In SeguridadData.Usuario On a.IDUsuario Equals u.IDUsuario
                                  Where a.Alias = strAlias And u.estado = "A"
                                  Select a).SingleOrDefault

            If usuarioAutenticado IsNot Nothing Then
                'Se verifica la contraseña.
                If usuarioAutenticado.Contrasena.CompareTo(strContrasena) = 0 Then
                    'usuario = usuarioAutenticado
                    With usuario
                        .Alias = usuarioAutenticado.Alias
                        .Bloqueado = usuarioAutenticado.Bloqueado
                        .Contrasena = usuarioAutenticado.Contrasena
                        .EstaAutenticado = usuarioAutenticado.EstaAutenticado
                        .IDCliente = usuarioAutenticado.IDCliente
                        .IDLogin = usuarioAutenticado.IDLogin
                        .IDUsuario = usuarioAutenticado.IDUsuario
                        .PreguntaSecreta = usuarioAutenticado.PreguntaSecreta
                        .RespuestaSecreta = usuarioAutenticado.RespuestaSecreta
                        .Usuario = Nothing
                        .CustomUsuario = New Usuario
                    End With


                    IDUsuario = usuario.IDUsuario
                    usuario.EstaAutenticado = True
                    'Se obtiene el rol de usuario
                    Dim usuarioBE = (From u In SeguridadData.Usuario Where u.IDUsuario = IDUsuario).Single

                    'usuario.CustomUsuario = usuarioBE
                    With usuario.CustomUsuario
                        .IDUsuario = usuarioBE.IDUsuario
                        .Nombres = usuarioBE.Nombres
                        .ApellidoMaterno = usuarioBE.ApellidoMaterno
                        .ApellidoPaterno = usuarioBE.ApellidoPaterno
                        .CorreoElectronico = usuarioBE.CorreoElectronico
                        .TipoDocumento = usuarioBE.TipoDocumento
                        .NroDocumento = usuarioBE.NroDocumento
                        .CustomUsuarioRol = New UsuarioRol
                    End With

                    'With usuario.Usuario
                    '    .IDUsuario = usuarioBE.IDUsuario
                    '    .Nombres = usuarioBE.Nombres
                    '    .ApellidoMaterno = usuarioBE.ApellidoMaterno
                    '    .ApellidoPaterno = usuarioBE.ApellidoPaterno
                    '    .CorreoElectronico = usuarioBE.CorreoElectronico
                    '    .TipoDocumento = usuarioBE.TipoDocumento
                    '    .NroDocumento = usuarioBE.NroDocumento
                    '    .CustomUsuarioRol = New UsuarioRol
                    'End With


                    usuarioBE.CustomUsuarioRol = (From r In SeguridadData.UsuarioRol Where r.IDUsuario = IDUsuario).Single()
                    With usuario.CustomUsuario.CustomUsuarioRol
                        .IDUsuario = CType(usuarioBE.CustomUsuarioRol.IDUsuario, Integer)
                        .IDRol = usuarioBE.CustomUsuarioRol.IDRol
                    End With

                    'Dim rol = New UsuarioRol
                    'rol.IDUsuario = CType(usuarioBE.CustomUsuarioRol.IDUsuario, Integer)
                    'rol.IDRol = usuarioBE.CustomUsuarioRol.IDRol

                    'usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
                    'usuario.CustomUsuario.CustomUsuarioRol.IDUsuario = rol.IDUsuario
                    'usuario.CustomUsuario.CustomUsuarioRol.IDRol = rol.IDRol

                    EsUsuarioAutenticado = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EsUsuarioAutenticadoV2(ByRef usuario As AutenticacionUsuario) As Boolean
        Try

            Dim usuarioAutenticado As AutenticacionUsuario
            Dim encriptador As New Cryptography
            Dim strAlias As String, strContrasena As String
            'DIM strIDCliente As String
            Dim IDUsuario As Integer
            Dim idEmpresa As String = String.Empty
            Dim IdEstablecimiento As Integer = 0
            EsUsuarioAutenticadoV2 = False

            'strIDCliente = usuario.IDCliente
            'Se desencripta el usuario y password
            strAlias = encriptador.Decode(usuario.Alias)
            strContrasena = encriptador.Decode(usuario.Contrasena)
            'Se encripta la contraseña hash para comparar con BD
            strContrasena = encriptador.getSHA1Hash(strContrasena)
            'Se consulta el alias de usuario



            If (strAlias = "20603329156") Then
                IdEstablecimiento = 0
                idEmpresa = Nothing
            ElseIf (strAlias <> "20603329156") Then
                IdEstablecimiento = usuario.IDEstablecimiento
                idEmpresa = usuario.IdEmpresa
            End If



            usuarioAutenticado = (From a In SeguridadData.AutenticacionUsuario
                                  Join u In SeguridadData.Usuario On a.IDUsuario Equals u.IDUsuario
                                  Where a.Alias = strAlias AndAlso
                                      u.estado = "A"
                                  Select a).SingleOrDefault

            If usuarioAutenticado IsNot Nothing Then
                'Se verifica la contraseña.
                If usuarioAutenticado.Contrasena.CompareTo(strContrasena) = 0 Then
                    'usuario = usuarioAutenticado
                    With usuario
                        .Alias = usuarioAutenticado.Alias
                        .Bloqueado = usuarioAutenticado.Bloqueado
                        .Contrasena = usuarioAutenticado.Contrasena
                        .EstaAutenticado = usuarioAutenticado.EstaAutenticado
                        .IDCliente = usuarioAutenticado.IDCliente
                        .IDLogin = usuarioAutenticado.IDLogin
                        .IDUsuario = usuarioAutenticado.IDUsuario
                        .PreguntaSecreta = usuarioAutenticado.PreguntaSecreta
                        .RespuestaSecreta = usuarioAutenticado.RespuestaSecreta
                        .Usuario = Nothing
                        .CustomUsuario = New Usuario
                    End With


                    IDUsuario = usuario.IDUsuario
                    usuario.EstaAutenticado = True
                    'Se obtiene el rol de usuario
                    Dim usuarioBE = (From u In SeguridadData.Usuario Where u.IDUsuario = IDUsuario).Single

                    'usuario.CustomUsuario = usuarioBE
                    With usuario.CustomUsuario
                        .IDUsuario = usuarioBE.IDUsuario
                        .Nombres = usuarioBE.Nombres
                        .ApellidoMaterno = usuarioBE.ApellidoMaterno
                        .ApellidoPaterno = usuarioBE.ApellidoPaterno
                        .CorreoElectronico = usuarioBE.CorreoElectronico
                        .TipoDocumento = usuarioBE.TipoDocumento
                        .NroDocumento = usuarioBE.NroDocumento
                        .CustomUsuarioRol = New UsuarioRol
                    End With

                    usuarioBE.CustomUsuarioRol = (From r In SeguridadData.UsuarioRol Where r.IDUsuario = IDUsuario).Single()
                    With usuario.CustomUsuario.CustomUsuarioRol
                        .IDUsuario = CType(usuarioBE.CustomUsuarioRol.IDUsuario, Integer)
                        .IDRol = usuarioBE.CustomUsuarioRol.IDRol
                    End With

                    EsUsuarioAutenticadoV2 = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EsUsuarioAutenticadoSingle(ByRef usuario As AutenticacionUsuario) As Boolean
        Dim usuarioAutenticado As AutenticacionUsuario
        Dim encriptador As New Cryptography
        Dim strAlias As String, strContrasena As String, strIDCliente As String
        Dim IDUsuario As Integer
        Dim IDEmpresa As String
        Dim IDEstablecimiento As Integer
        EsUsuarioAutenticadoSingle = False


        IDEmpresa = usuario.IdEmpresa
        IDEstablecimiento = usuario.IDEstablecimiento

        strIDCliente = usuario.IDCliente
        'Se desencripta el usuario y password
        strAlias = encriptador.Decode(usuario.Alias)
        strContrasena = encriptador.Decode(usuario.Contrasena)
        'Se encripta la contraseña hash para comparar con BD
        strContrasena = encriptador.getSHA1Hash(strContrasena)
        'Se consulta el alias de usuario
        usuarioAutenticado = (From a In SeguridadData.AutenticacionUsuario
                              Join u In SeguridadData.Usuario On a.IDUsuario Equals u.IDUsuario
                              Where a.Alias = strAlias
                              Select a).SingleOrDefault

        If usuarioAutenticado IsNot Nothing Then
            'Se verifica la contraseña.
            If usuarioAutenticado.Contrasena.CompareTo(strContrasena) = 0 Then
                'usuario = usuarioAutenticado
                With usuario
                    .Alias = usuarioAutenticado.Alias
                    .Bloqueado = usuarioAutenticado.Bloqueado
                    .Contrasena = usuarioAutenticado.Contrasena
                    .EstaAutenticado = usuarioAutenticado.EstaAutenticado
                    .IDCliente = usuarioAutenticado.IDCliente
                    .IDLogin = usuarioAutenticado.IDLogin
                    .IDUsuario = usuarioAutenticado.IDUsuario
                    .PreguntaSecreta = usuarioAutenticado.PreguntaSecreta
                    .RespuestaSecreta = usuarioAutenticado.RespuestaSecreta
                    .Usuario = Nothing
                    .CustomUsuario = New Usuario
                End With


                IDUsuario = usuario.IDUsuario
                usuario.EstaAutenticado = True
                'Se obtiene el rol de usuario
                Dim usuarioBE = (From u In SeguridadData.Usuario Where u.IDUsuario = IDUsuario).Single

                'usuario.CustomUsuario = usuarioBE
                With usuario.CustomUsuario
                    .IDUsuario = usuarioBE.IDUsuario
                    .Nombres = usuarioBE.Nombres
                    .ApellidoMaterno = usuarioBE.ApellidoMaterno
                    .ApellidoPaterno = usuarioBE.ApellidoPaterno
                    .CorreoElectronico = usuarioBE.CorreoElectronico
                    .TipoDocumento = usuarioBE.TipoDocumento
                    .NroDocumento = usuarioBE.NroDocumento
                    .CustomUsuarioRol = New UsuarioRol
                End With

                'With usuario.Usuario
                '    .IDUsuario = usuarioBE.IDUsuario
                '    .Nombres = usuarioBE.Nombres
                '    .ApellidoMaterno = usuarioBE.ApellidoMaterno
                '    .ApellidoPaterno = usuarioBE.ApellidoPaterno
                '    .CorreoElectronico = usuarioBE.CorreoElectronico
                '    .TipoDocumento = usuarioBE.TipoDocumento
                '    .NroDocumento = usuarioBE.NroDocumento
                '    .CustomUsuarioRol = New UsuarioRol
                'End With


                usuarioBE.CustomUsuarioRol = (From r In SeguridadData.UsuarioRol Where r.IDUsuario = IDUsuario).Single()
                With usuario.CustomUsuario.CustomUsuarioRol
                    .IDUsuario = CType(usuarioBE.CustomUsuarioRol.IDUsuario, Integer)
                    .IDRol = usuarioBE.CustomUsuarioRol.IDRol
                End With

                'Dim rol = New UsuarioRol
                'rol.IDUsuario = CType(usuarioBE.CustomUsuarioRol.IDUsuario, Integer)
                'rol.IDRol = usuarioBE.CustomUsuarioRol.IDRol

                'usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
                'usuario.CustomUsuario.CustomUsuarioRol.IDUsuario = rol.IDUsuario
                'usuario.CustomUsuario.CustomUsuarioRol.IDRol = rol.IDRol

                EsUsuarioAutenticadoSingle = True
            End If
        End If
    End Function

    Public Function EsUsuarioAutenticadoConfPrecio(ByRef usuario As AutenticacionUsuario) As Boolean
        Dim usuarioAutenticado As AutenticacionUsuario
        Dim encriptador As New Cryptography
        Dim strAlias As String, strContrasena As String, strIDCliente As String
        Dim IDUsuario As Integer
        EsUsuarioAutenticadoConfPrecio = False
        'And a.IDUsuario = strIDCliente
        ' strIDCliente = usuario.IDUsuario
        'Se desencripta el usuario y password
        strAlias = encriptador.Decode(usuario.Alias)
        strContrasena = encriptador.Decode(usuario.Contrasena)
        'Se encripta la contraseña hash para comparar con BD
        strContrasena = encriptador.getSHA1Hash(strContrasena)
        'Se consulta el alias de usuario
        usuarioAutenticado = (From a In SeguridadData.AutenticacionUsuario
                              Join u In SeguridadData.Usuario On a.IDUsuario Equals u.IDUsuario
                              Join rol In SeguridadData.UsuarioRol On rol.IDUsuario Equals u.IDUsuario
                              Where a.Alias = strAlias _
                                  And rol.IDRol = 1
                              Select a).SingleOrDefault

        If usuarioAutenticado IsNot Nothing Then
            'Se verifica la contraseña.
            If usuarioAutenticado.Contrasena.CompareTo(strContrasena) = 0 Then
                'usuario = usuarioAutenticado
                With usuario
                    .Alias = usuarioAutenticado.Alias
                    .Bloqueado = usuarioAutenticado.Bloqueado
                    .Contrasena = usuarioAutenticado.Contrasena
                    .EstaAutenticado = usuarioAutenticado.EstaAutenticado
                    .IDCliente = usuarioAutenticado.IDCliente
                    .IDLogin = usuarioAutenticado.IDLogin
                    .IDUsuario = usuarioAutenticado.IDUsuario
                    .PreguntaSecreta = usuarioAutenticado.PreguntaSecreta
                    .RespuestaSecreta = usuarioAutenticado.RespuestaSecreta
                    .Usuario = Nothing
                    .CustomUsuario = New Usuario
                End With


                IDUsuario = usuario.IDUsuario
                usuario.EstaAutenticado = True
                'Se obtiene el rol de usuario
                Dim usuarioBE = (From u In SeguridadData.Usuario Where u.IDUsuario = IDUsuario).Single

                'usuario.CustomUsuario = usuarioBE
                With usuario.CustomUsuario
                    .IDUsuario = usuarioBE.IDUsuario
                    .Nombres = usuarioBE.Nombres
                    .ApellidoMaterno = usuarioBE.ApellidoMaterno
                    .ApellidoPaterno = usuarioBE.ApellidoPaterno
                    .CorreoElectronico = usuarioBE.CorreoElectronico
                    .TipoDocumento = usuarioBE.TipoDocumento
                    .NroDocumento = usuarioBE.NroDocumento
                    .CustomUsuarioRol = New UsuarioRol
                End With

                'With usuario.Usuario
                '    .IDUsuario = usuarioBE.IDUsuario
                '    .Nombres = usuarioBE.Nombres
                '    .ApellidoMaterno = usuarioBE.ApellidoMaterno
                '    .ApellidoPaterno = usuarioBE.ApellidoPaterno
                '    .CorreoElectronico = usuarioBE.CorreoElectronico
                '    .TipoDocumento = usuarioBE.TipoDocumento
                '    .NroDocumento = usuarioBE.NroDocumento
                '    .CustomUsuarioRol = New UsuarioRol
                'End With


                usuarioBE.CustomUsuarioRol = (From r In SeguridadData.UsuarioRol Where r.IDUsuario = IDUsuario).Single()
                With usuario.CustomUsuario.CustomUsuarioRol
                    .IDUsuario = CType(usuarioBE.CustomUsuarioRol.IDUsuario, Integer)
                    .IDRol = usuarioBE.CustomUsuarioRol.IDRol
                End With

                'Dim rol = New UsuarioRol
                'rol.IDUsuario = CType(usuarioBE.CustomUsuarioRol.IDUsuario, Integer)
                'rol.IDRol = usuarioBE.CustomUsuarioRol.IDRol

                'usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
                'usuario.CustomUsuario.CustomUsuarioRol.IDUsuario = rol.IDUsuario
                'usuario.CustomUsuario.CustomUsuarioRol.IDRol = rol.IDRol

                EsUsuarioAutenticadoConfPrecio = True
            End If
        End If
    End Function

    Public Sub AutenticacionUsuarioGrabar(ByVal usuario As AutenticacionUsuario)
        SeguridadData.AutenticacionUsuario.Attach(usuario)
        'SeguridadData.ObjectStateManager.GetObjectStateEntry(usuario).ChangeState(EntityState.Modified)
        SeguridadData.SaveChanges()
    End Sub

    'Public Sub AutenticacionUsuarioModificarContrasena(ByVal usuario As AutenticacionUsuario, ByVal nuevaContrasena As String)
    '    If Not usuario.EstaAutenticado Then
    '        usuario.EstaAutenticado = EsUsuarioAutenticado(usuario)
    '    End If
    '    If usuario.EstaAutenticado Then
    '        Dim encriptador As New Cryptography
    '        'Se desencripta contraseña
    '        'Se encripta para grabar en BD
    '        usuario.Contrasena = encriptador.getSHA1Hash(encriptador.Decode(nuevaContrasena))
    '        'Se carga data para actualizar en BD
    '        Dim usuarioBE = (From obj In SeguridadData.AutenticacionUsuario
    '                        Where obj.IDUsuario = usuario.IDUsuario).Single
    '        usuarioBE.Contrasena = nuevaContrasena
    '        usuarioBE.UltimaFechaCambioPassword = Date.Now

    '        SeguridadData.SaveChanges()
    '    End If

    'End Sub

    Public Sub Insert(ByVal usuario As AutenticacionUsuario)
        SeguridadData.AutenticacionUsuario.Add(usuario)
        SeguridadData.SaveChanges()
    End Sub

    Public Sub Update(ByVal usuario As AutenticacionUsuario)
        SeguridadData.AutenticacionUsuario.Attach(usuario)
        '   SeguridadData.ObjectStateManager.GetObjectStateEntry(usuario).ChangeState(EntityState.Modified)
        SeguridadData.SaveChanges()
    End Sub


    Public Function MappingUsuarioAdmin(idCliente As Integer, idCargo As Integer, idEstablec As Integer, idEmpresa As String, numeracion As Integer, listaAsegurable As List(Of Asegurable)) As Rol
        Dim Usuario As New AutenticacionUsuario
        Usuario.CustomUsuario = New Usuario

        With Usuario.CustomUsuario
            .Action = BaseBE.EntityAction.INSERT
            .codigo = Nothing
            .ApellidoPaterno = "Admin"
            .ApellidoMaterno = "Admin"
            .IDCliente = idCliente
            .Nombres = "Admin"
            .idEmpresa = idEmpresa
            .TipoDocumento = "DNI"
            .NroDocumento = "-"
            .CorreoElectronico = "softpack@softpack.com.pe"
            .estado = "A"
            .UsuarioActualizacion = "Sistema"
            .FechaActualizacion = Date.Now
            .idCargo = idCargo

        End With

        With Usuario
            .IDCliente = idCliente
            .Action = BaseBE.EntityAction.INSERT
            .AliasLogin = "Admin"
            .Alias = "Admin"
            .Contrasena = "123"
            .IdEmpresa = idEmpresa
            .IDEstablecimiento = idEstablec
            .CorreoElectronico = "softpack@softpack.com.pe"
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

        'Usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
        'With Usuario.CustomUsuario.CustomUsuarioRol
        '    .Action = BaseBE.EntityAction.INSERT
        '    If rbCajeroCentral.Checked = True Then
        '        .IDRol = 3
        '    Else
        '        .IDRol = 4
        '    End If

        '    .UsuarioActualizacion = "Sistema"
        '    .FechaActualizacion = Date.Now
        'End With
        MappingUsuarioAdmin = GrabarUsuarioAdminInicioSingle(Usuario, listaAsegurable)
    End Function

    Public Function MappingSuperUsuarioAdmin(idCliente As Integer, idEstablec As Integer, idEmpresa As String, numeracion As Integer, listaProductosAsegurable As List(Of Asegurable)) As Rol
        Dim Usuario As New AutenticacionUsuario
        Dim RolBL As New RolBL

        Usuario.CustomUsuario = New Usuario

        With Usuario.CustomUsuario
            .Action = BaseBE.EntityAction.INSERT
            .codigo = Nothing
            .ApellidoPaterno = "SoftPack"
            .ApellidoMaterno = "SoftPack"
            .IDCliente = idCliente
            .Nombres = "ADMINISTRADOR"
            .TipoDocumento = "SUPER"
            .NroDocumento = "-"
            '.IDEmpresa = Nothing 'idEmpresa
            '.IDEstablecimiento = 0 ' idEstablec
            .CorreoElectronico = "softpack@softpack.com.pe"
            .estado = "A"
            .UsuarioActualizacion = "Sistema"
            .FechaActualizacion = Date.Now
            '.idCargo = idCargo

        End With

        With Usuario
            .IDCliente = idCliente
            .Action = BaseBE.EntityAction.INSERT
            .AliasLogin = "ADMINISTRADOR"
            .Alias = "ADMINISTRADOR"
            .Contrasena = "123"
            '.IdEmpresa = Nothing ' idEmpresa
            .IDEstablecimiento = idEstablec
            .CorreoElectronico = "softpack@softpack.com.pe"
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
            .IdEmpresa = idEmpresa
        End With




        'Usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
        'With Usuario.CustomUsuario.CustomUsuarioRol
        '    .Action = BaseBE.EntityAction.INSERT
        '    If rbCajeroCentral.Checked = True Then
        '        .IDRol = 3
        '    Else
        '        .IDRol = 4
        '    End If

        '    .UsuarioActualizacion = "Sistema"
        '    .FechaActualizacion = Date.Now
        'End With
        'MappingSuperUsuarioAdmin =
        GrabarUsuarioAdminInicio(Usuario, listaProductosAsegurable)
    End Function


    'Public Function MappingUsuarioAdmin(idCliente As Integer) As Integer
    '    Dim Usuario As New AutenticacionUsuario
    '    Usuario.CustomUsuario = New Usuario

    '    With Usuario.CustomUsuario
    '        .Action = BaseBE.EntityAction.INSERT
    '        .codigo = "11"
    '        .ApellidoPaterno = "Admin"
    '        .ApellidoMaterno = "Admin"
    '        .IDCliente = idCliente
    '        .Nombres = "Admin"
    '        .TipoDocumento = "DNI"
    '        .NroDocumento = "-"
    '        .CorreoElectronico = "softpack@softpack.com.pe"
    '        .estado = "A"
    '        .UsuarioActualizacion = "Sistema"
    '        .FechaActualizacion = Date.Now
    '    End With

    '    With Usuario
    '        .IDCliente = idCliente
    '        .Action = BaseBE.EntityAction.INSERT
    '        .AliasLogin = "Admin"
    '        .Alias = "Admin"
    '        .Contrasena = "123"
    '        .CorreoElectronico = "softpack@softpack.com.pe"
    '        .EstaAutenticado = True
    '        .FechaActualizacion = Date.Now
    '        .PreguntaSecreta = ""
    '        .RespuestaSecreta = ""
    '        .UltimaFechaCambioPassword = Date.Now
    '        .UltimaFechaLogueo = Date.Now
    '        .UsuarioActualizacion = "Sistema"
    '        .Bloqueado = False
    '        '.Trial = chkTrial.Checked
    '        '.FechaInicioVigencia = dtpFechaIniVigencia.Value
    '        '.FechaFinVigencia = dtpFechaFinVigencia.Value
    '    End With

    '    'Usuario.CustomUsuario.CustomUsuarioRol = New UsuarioRol
    '    'With Usuario.CustomUsuario.CustomUsuarioRol
    '    '    .Action = BaseBE.EntityAction.INSERT
    '    '    If rbCajeroCentral.Checked = True Then
    '    '        .IDRol = 3
    '    '    Else
    '    '        .IDRol = 4
    '    '    End If

    '    '    .UsuarioActualizacion = "Sistema"
    '    '    .FechaActualizacion = Date.Now
    '    'End With
    '    MappingUsuarioAdmin = GrabarUsuarioAdminInicio(Usuario)
    'End Function

    Public Sub GrabarAdministradorDefault(be As AutenticacionUsuario)
        Try


            Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL
            Dim AsegurableBL As New AsegurableBL
            Dim asegurables As Seguridad.Business.Entity.Asegurable

            Dim SeguridadproductoBL As New Seguridad.Business.Logic.productoDetalleBL
            Dim autorizacionRolBL As New Seguridad.Business.Logic.AutorizacionRolBL
            Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(39)
            Dim LISTAProdcutoAdquirido As New List(Of Asegurable)
            'Dim ListaPermisos = AsegurableBL.GetAsegurables() 'nuevo
            Dim asegurableBE As New Asegurable
            'be.IDProducto = be.IDProducto
            If ProductoAquirido.Count > 0 Then
                For Each s In ProductoAquirido
                    asegurables = New Seguridad.Business.Entity.Asegurable
                    asegurables.IDAsegurable = s.IDAsegurable
                    asegurables.IDAsegurablePadre = s.IDAsegurablePadre
                    asegurables.IDEmpresa = be.IdEmpresa
                    asegurables.IDEstablecimiento = be.IDEstablecimiento
                    asegurables.Nombre = s.Nombre
                    asegurables.Descripcion = s.Descripcion
                    asegurables.CodRef = s.formulario
                    asegurables.orden = s.orden
                    asegurables.UsuarioActualizacion = "Sistema"
                    asegurables.FechaActualizacion = DateTime.Now
                    asegurableBE = AsegurableBL.Insert(asegurables)
                    asegurables.IDModulo = asegurableBE.IDModulo
                    LISTAProdcutoAdquirido.Add(asegurables)
                Next

            End If

            'Dim Cargo As New jerarquiaCargo
            'Cargo.descripcion = "ADMINISTRADOR"
            'Cargo.tipo = "S"
            'Cargo.IDCliente = 2
            'Cargo.IDEmpresa = be.IdEmpresa
            'Cargo.IDEstablecimiento = be.IDEstablecimiento

            'Dim cargoAdmin = jerarquiaCargoBL.GetSoloInserCargos(Cargo)


            Dim rol = AutenticacionUsuarioBL.MappingUsuarioAdmin(Integer.Parse(be.IDUsuario), Nothing, be.IDEstablecimiento, be.IdEmpresa, be.numeracion, LISTAProdcutoAdquirido)


            'autorizacionRolBL.InsertarListaAsegurables(LISTAProdcutoAdquirido, rol.IDRol, Integer.Parse(rol.usuarioID))


            'autorizacionRolBL.InsertarListaAsegurablesAdmin(ListaPermisos, idRol, Integer.Parse(be.IDCliente))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarSuperAdministradorDefault(be As AutenticacionUsuario)
        Try

            Dim consultaUsaurio = (From pd In SeguridadData.Usuario).Count

            If (consultaUsaurio <= 0) Then

                Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL
                Dim AsegurableBL As New AsegurableBL
                Dim asegurables As Seguridad.Business.Entity.Asegurable
                Dim SeguridadproductoBL As New Seguridad.Business.Logic.productoDetalleBL
                Dim autorizacionRolBL As New Seguridad.Business.Logic.AutorizacionRolBL



                'Dim Cargo As New jerarquiaCargo
                'Cargo.descripcion = "SUPER_ADMINISTRADOR"
                'Cargo.tipo = "S"
                'Cargo.IDCliente = 2
                'Cargo.IDEmpresa = be.IdEmpresa
                'Cargo.IDEstablecimiento = be.IDEstablecimiento

                'Dim cargoAdmin = jerarquiaCargoBL.GetSoloInserCargos(Cargo)


                Dim rolGrupoEmp = AutenticacionUsuarioBL.MappingSuperUsuarioAdmin(Integer.Parse(be.IDUsuario), be.IDEstablecimiento, be.IdEmpresa, be.numeracion, Nothing)


                'autorizacionRolBL.InsertarListaAsegurables(LISTAProdcutoAdquirido, rol.IDRol, Integer.Parse(rol.usuarioID))

                'autorizacionRolBL.InsertarListaAsegurables(LISTAProdcutoAdquirido, rol.IDRol, Integer.Parse(rol.idCargo))
                'autorizacionRolBL.InsertarListaAsegurablesAdmin(ListaPermisos, idRol, Integer.Parse(be.IDCliente))
            Else
                'Throw New Exception("YA EXISTE UN USUARIO, SE CREO PERMISOS ADICIONAL")

                Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL
                Dim AsegurableBL As New AsegurableBL
                Dim asegurables As Seguridad.Business.Entity.Asegurable
                Dim SeguridadproductoBL As New Seguridad.Business.Logic.productoDetalleBL
                Dim autorizacionRolBL As New Seguridad.Business.Logic.AutorizacionRolBL
                Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(39)
                Dim LISTAProdcutoAdquirido As New List(Of Asegurable)
                'Dim ListaPermisos = AsegurableBL.GetAsegurables() 'nuevo
                Dim asegurableBE As New Asegurable
                'be.IDProducto = be.IDProducto


                'Dim AutorizacionRolBL As New AutorizacionRolBL


                LISTAProdcutoAdquirido = New List(Of Asegurable)

                    If ProductoAquirido.Count > 0 Then
                        For Each s In ProductoAquirido
                            asegurables = New Seguridad.Business.Entity.Asegurable
                            asegurables.IDAsegurable = s.IDAsegurable
                            asegurables.IDAsegurablePadre = s.IDAsegurablePadre
                            asegurables.IDEmpresa = be.IdEmpresa
                            asegurables.IDEstablecimiento = be.IDEstablecimiento
                            asegurables.Nombre = s.Nombre
                            asegurables.Descripcion = s.Descripcion
                            asegurables.CodRef = s.formulario
                            asegurables.orden = s.orden
                            asegurables.UsuarioActualizacion = "Sistema"
                            asegurables.FechaActualizacion = DateTime.Now
                            asegurableBE = AsegurableBL.Insert(asegurables)
                            asegurables.IDModulo = asegurableBE.IDModulo
                            LISTAProdcutoAdquirido.Add(asegurables)
                        Next

                    End If


                    Dim RolRecuperado = (From pd In SeguridadData.Rol
                                         Where pd.control = "SA").FirstOrDefault

                    If (Not IsNothing(RolRecuperado)) Then


                    autorizacionRolBL.InsertarListaAsegurables(LISTAProdcutoAdquirido, Nothing, Integer.Parse(0))

                Else
                        Throw New Exception("VERIFICAR REGISTRO")
                    End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Public Sub GrabarAdministradorDefault(be As AutenticacionUsuario)

    '    Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL
    '    Dim AsegurableBL As New AsegurableBL
    '    Dim asegurables As Seguridad.Business.Entity.Asegurable
    '    Dim SeguridadproductoBL As New Seguridad.Business.Logic.productoDetalleBL
    '    Dim autorizacionRolBL As New Seguridad.Business.Logic.AutorizacionRolBL
    '    Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(39)

    '    '   be.IDProducto = be.IDProducto
    '    If ProductoAquirido.Count > 0 Then
    '        For Each s In ProductoAquirido
    '            asegurables = New Seguridad.Business.Entity.Asegurable
    '            asegurables.IDAsegurable = s.IDAsegurable
    '            asegurables.IDAsegurablePadre = s.IDAsegurablePadre
    '            asegurables.IDCliente = be.IDCliente
    '            asegurables.Nombre = s.Nombre
    '            asegurables.Descripcion = s.Descripcion
    '            asegurables.CodRef = s.formulario
    '            asegurables.orden = s.orden
    '            asegurables.UsuarioActualizacion = "Sistema"
    '            asegurables.FechaActualizacion = DateTime.Now
    '            AsegurableBL.Insert(asegurables)
    '        Next
    '    End If

    '    Dim idRol = AutenticacionUsuarioBL.MappingUsuarioAdmin(Integer.Parse(be.IDCliente))
    '    autorizacionRolBL.InsertarListaAsegurables(ProductoAquirido, idRol, Integer.Parse(be.IDCliente))
    'End Sub

    Public Function GrabarUsuarioAdminInicio(ByVal usuario As AutenticacionUsuario, listaAsegurable As List(Of Asegurable)) As Rol
        Dim UsuarioBL As New UsuarioBL
        Dim UsuarioRolBL As New Rol
        Dim RolBL As New RolBL
        Dim encriptador As New Cryptography
        Dim objAutenticacionUsuario As New AutenticacionUsuario
        Dim objUsuario As New Usuario
        Dim objUsuarioRol As New UsuarioRol
        Dim AutorizacionRolBL As New AutorizacionRolBL

        Dim AutenticacionUsuarioBL As New AutenticacionUsuarioBL
        Dim AsegurableBL As New AsegurableBL
        Dim asegurables As Seguridad.Business.Entity.Asegurable
        Dim SeguridadproductoBL As New Seguridad.Business.Logic.productoDetalleBL
        'Dim autorizacionRolBL As New Seguridad.Business.Logic.AutorizacionRol
        'Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(39)
        Dim LISTAProdcutoAdquirido As New List(Of Asegurable)
        'Dim ListaPermisos = AsegurableBL.GetAsegurables() 'nuevo
        Dim asegurableBE As New Asegurable
        'be.IDProducto = be.IDProducto


        Try
            Using ts As New TransactionScope


                usuario.Alias = encriptador.Encode(usuario.Alias)
                usuario.Contrasena = encriptador.Encode(usuario.Contrasena)



                Dim rolRecuperado = RolBL.GetInserRoles(New Rol With {
                                    .Nombre = "SUPER_ADMINISTRADOR",
                                    .Descripcion = "SUPER_ADMINISTRADOR",
                                    .control = "SA",
                                    .UsuarioActualizacion = "1",
                                    .FechaActualizacion = Date.Now})


                '/////////////////////CARGOS////////////////////

                'CREAACION DE CARGOSPOR DEFAULT

                Dim rolRecuperadoo = RolBL.GetInserRolSingle(New Rol With {
                                    .Nombre = "ADMINISTRADOR",
                                    .Descripcion = "ADMINISTRADOR",
                                    .idEmpresa = usuario.IdEmpresa,
                                            .control = "GR",
                                    .tipo = "U",
                                    .tipoEF = "ADM",
                                    .UsuarioActualizacion = "1",
                                    .FechaActualizacion = Date.Now})

                Dim rolRecuperado1 = RolBL.GetInserRolSingle(New Rol With {
                                    .Nombre = "JEFE DE CAJA",
                                    .Descripcion = "JEFE DE CAJA",
                                    .idEmpresa = usuario.IdEmpresa,
                                                              .control = "GR",
                                    .tipo = "U",
                                    .tipoEF = "ADM",
                                    .UsuarioActualizacion = "1",
                                    .FechaActualizacion = Date.Now})

                Dim rolRecuperado2 = RolBL.GetInserRolSingle(New Rol With {
                                    .Nombre = "CAJERO",
                                    .Descripcion = "CAJERO",
                                    .idEmpresa = usuario.IdEmpresa,
                                                               .idPadre = rolRecuperado1.IDRol,
                                    .control = "GR",
                                    .tipo = "U",
                                    .tipoEF = "POS",
                                    .UsuarioActualizacion = "1",
                                    .FechaActualizacion = Date.Now})

                Dim rolRecuperado3 = RolBL.GetInserRolSingle(New Rol With {
                                    .Nombre = "VENDEDOR",
                                    .Descripcion = "VENDEDOR",
                                    .idEmpresa = usuario.IdEmpresa,
                                            .control = "GR",
                                    .tipo = "U",
                                    .tipoEF = "POS",
                                    .UsuarioActualizacion = "1",
                                    .FechaActualizacion = Date.Now})


                ''For Each rolemp In usuario.listaRolXgrupoEmp
                'LISTAProdcutoAdquirido = New List(Of Asegurable)

                'If ProductoAquirido.Count > 0 Then
                '    For Each s In ProductoAquirido
                '        asegurables = New Seguridad.Business.Entity.Asegurable
                '        asegurables.IDAsegurable = s.IDAsegurable
                '        asegurables.IDAsegurablePadre = s.IDAsegurablePadre
                '        asegurables.IDEmpresa = usuario.IdEmpresa
                '        asegurables.IDEstablecimiento = 0 'usuario.IDEstablecimiento  ' - -SE CAMBIO SOLO PARA SUPER ADMINISTRADOR
                '        asegurables.Nombre = s.Nombre
                '        asegurables.Descripcion = s.Descripcion
                '        asegurables.CodRef = s.formulario
                '        asegurables.orden = s.orden
                '        asegurables.UsuarioActualizacion = "Sistema"
                '        asegurables.FechaActualizacion = DateTime.Now
                '        asegurableBE = AsegurableBL.Insert(asegurables)
                '        asegurables.IDModulo = asegurableBE.IDModulo
                '        LISTAProdcutoAdquirido.Add(asegurables)
                '    Next

                'End If



                'objRolGrupoEmpreBE = New RolXGrupoEmp

                'objRolGrupoEmpreBE.[IDRol] = rolRecuperado.IDRol
                'objRolGrupoEmpreBE.[IDPadre] = Nothing
                'objRolGrupoEmpreBE.[descripcion] = rolemp.descripcion
                'objRolGrupoEmpreBE.[tipo] = "SA"
                'objRolGrupoEmpreBE.[IDReferencia] = rolemp.IDReferencia
                'objRolGrupoEmpreBE.[estado] = True
                'objRolGrupoEmpreBE.[UsuarioActualizacion] = "Administrador"
                'objRolGrupoEmpreBE.[FechaActualizacion] = DateTime.Now

                'rolGrupoEmpBE = RolGRupoEmpBL.GetInserRolesXgrupoEmp(objRolGrupoEmpreBE)

                'AutorizacionRolBL.InsertarListaAsegurables(LISTAProdcutoAdquirido, rolGrupoEmpBE.IDRolXGrupoEmp, Integer.Parse(rolRecuperado.IDRol))
                'Next

                With objUsuario
                    .Action = usuario.CustomUsuario.Action
                    .codigo = usuario.CustomUsuario.codigo
                    .ApellidoMaterno = usuario.CustomUsuario.ApellidoMaterno
                    .ApellidoPaterno = usuario.CustomUsuario.ApellidoPaterno
                    .CorreoElectronico = usuario.CustomUsuario.CorreoElectronico
                    .FechaActualizacion = Date.Now
                    '.IDEmpresa = Nothing ' usuario.CustomUsuario.IDEmpresa
                    '.IDEstablecimiento = 0
                    .IDCliente = usuario.CustomUsuario.IDCliente
                    .Nombres = usuario.CustomUsuario.Nombres
                    .NroDocumento = usuario.CustomUsuario.NroDocumento
                    .TipoDocumento = usuario.CustomUsuario.TipoDocumento
                    .estado = usuario.CustomUsuario.estado
                    .UsuarioActualizacion = usuario.CustomUsuario.UsuarioActualizacion
                    .idCargo = usuario.CustomUsuario.idCargo
                End With

                With objAutenticacionUsuario
                    .Action = usuario.Action

                    Dim consulta2 = (From obj In SeguridadData.AutenticacionUsuario
                                     Join user In SeguridadData.Usuario
                                             On user.IDUsuario Equals obj.IDUsuario
                                     Where obj.Alias = usuario.AliasLogin
                                     Select obj).FirstOrDefault
                    If (IsNothing(consulta2)) Then
                        .Alias = encriptador.Decode(usuario.Alias)
                    Else
                        Throw New Exception("Existe un usuario registrado con ese Alias!")
                    End If
                    .Contrasena = encriptador.getSHA1Hash(encriptador.Decode(usuario.Contrasena))
                    .CorreoElectronico = usuario.CorreoElectronico
                    .EstaAutenticado = usuario.EstaAutenticado
                    .FechaActualizacion = Date.Now
                    .IDCliente = usuario.IDCliente
                    .PreguntaSecreta = usuario.PreguntaSecreta
                    .IdEmpresa = usuario.IdEmpresa
                    .RespuestaSecreta = usuario.RespuestaSecreta
                    .UltimaFechaCambioPassword = usuario.UltimaFechaCambioPassword
                    .UltimaFechaLogueo = usuario.UltimaFechaLogueo
                    .UsuarioActualizacion = usuario.UsuarioActualizacion
                End With
                With objUsuarioRol
                    .Action = BaseBE.EntityAction.INSERT
                    .IDRol = rolRecuperado.IDRol
                    .predeterminado = True
                    .FechaActualizacion = Date.Now
                    .UsuarioActualizacion = "1"
                End With
                objUsuario.UsuarioRol.Add(objUsuarioRol)
                objUsuario.AutenticacionUsuario.Add(objAutenticacionUsuario)
                Dim usuarioBE = SeguridadData.Usuario.Add(objUsuario)

                SeguridadData.SaveChanges()
                ts.Complete()

                rolRecuperado.usuarioID = usuarioBE.IDUsuario

                'rolRecuperado.IDUsuario = objUsuario.IDUsuario
                'GrabarUsuarioAdminInicio = rolGrupoEmpBE
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GrabarUsuarioAdminInicioSingle(ByVal usuario As AutenticacionUsuario, ListaProductos As List(Of Asegurable)) As Rol
        Dim UsuarioBL As New UsuarioBL
        Dim UsuarioRolBL As New Rol
        Dim RolBL As New RolBL
        Dim encriptador As New Cryptography
        Dim objAutenticacionUsuario As New AutenticacionUsuario
        Dim objUsuario As New Usuario
        Dim objUsuarioRol As New UsuarioRol

        Dim AutorizacionRolBL As New AutorizacionRolBL

        Try
            Using ts As New TransactionScope


                usuario.Alias = encriptador.Encode(usuario.Alias)
                usuario.Contrasena = encriptador.Encode(usuario.Contrasena)

                Dim rolRecuperado = RolBL.GetInserRolSingle(New Rol With {
                                    .Nombre = "ADMINISTRADOR",
                                    .Descripcion = "ADMINISTRADOR",
                                    .idEmpresa = usuario.IdEmpresa,
                                                                .UsuarioActualizacion = "1",
                                  .control = "UN",
                                  .tipo = "U",
                                  .tipoEF = "ADM",
                                    .FechaActualizacion = Date.Now})


                'AutorizacionRolBL.InsertarListaAsegurables(ListaProductos, rolGrupoEmpBE.IDRolXGrupoEmp, Integer.Parse(rolGrupoEmpBE.IDRol))


                'CREAACION DE CARGOSPOR DEFAULT
                Dim rolRecuperado1 = RolBL.GetInserRolSingle(New Rol With {
                                    .Nombre = "JEFE DE CAJA",
                                    .Descripcion = "JEFE DE CAJA",
                                    .idEmpresa = usuario.IdEmpresa,
                                                                 .control = "UN",
                                    .tipo = "U",
                                    .tipoEF = "ADM",
                                    .UsuarioActualizacion = "1",
                                    .FechaActualizacion = Date.Now})



                Dim rolRecuperado2 = RolBL.GetInserRolSingle(New Rol With {
                                    .Nombre = "CAJERO",
                                    .Descripcion = "CAJERO",
                                    .idEmpresa = usuario.IdEmpresa,
                                                                     .idPadre = rolRecuperado1.IDRol,
                                    .control = "UN",
                                    .tipo = "U",
                                    .tipoEF = "POS",
                                    .UsuarioActualizacion = "1",
                                    .FechaActualizacion = Date.Now})



                With objUsuario
                    .Action = usuario.CustomUsuario.Action
                    .codigo = usuario.CustomUsuario.codigo
                    .ApellidoMaterno = usuario.CustomUsuario.ApellidoMaterno
                    .ApellidoPaterno = usuario.CustomUsuario.ApellidoPaterno
                    .CorreoElectronico = usuario.CustomUsuario.CorreoElectronico
                    .FechaActualizacion = Date.Now
                    .IDCliente = usuario.CustomUsuario.IDCliente
                    .Nombres = usuario.CustomUsuario.Nombres
                    .NroDocumento = usuario.CustomUsuario.NroDocumento
                    .TipoDocumento = usuario.CustomUsuario.TipoDocumento
                    .estado = usuario.CustomUsuario.estado
                    .UsuarioActualizacion = usuario.CustomUsuario.UsuarioActualizacion
                    .idCargo = usuario.CustomUsuario.idCargo
                End With
                With objAutenticacionUsuario
                    .Action = usuario.Action

                    Dim consulta2 = (From obj In SeguridadData.AutenticacionUsuario
                                     Join user In SeguridadData.Usuario
                                             On user.IDUsuario Equals obj.IDUsuario
                                     Where obj.Alias = usuario.AliasLogin And user.IDEmpresa = usuario.IdEmpresa
                                     Select obj).FirstOrDefault
                    If (IsNothing(consulta2)) Then
                        .Alias = encriptador.Decode(usuario.Alias)
                    Else
                        Throw New Exception("Existe un usuario registrado con ese Alias!")
                    End If
                    .Contrasena = encriptador.getSHA1Hash(encriptador.Decode(usuario.Contrasena))
                    .CorreoElectronico = usuario.CorreoElectronico
                    .EstaAutenticado = usuario.EstaAutenticado
                    .FechaActualizacion = Date.Now
                    .IDCliente = usuario.IDCliente
                    .PreguntaSecreta = usuario.PreguntaSecreta
                    .RespuestaSecreta = usuario.RespuestaSecreta
                    .UltimaFechaCambioPassword = usuario.UltimaFechaCambioPassword
                    .UltimaFechaLogueo = usuario.UltimaFechaLogueo
                    .UsuarioActualizacion = usuario.UsuarioActualizacion
                End With
                With objUsuarioRol
                    .Action = BaseBE.EntityAction.INSERT
                    .IDRol = rolRecuperado.IDRol
                    .predeterminado = True
                    .FechaActualizacion = Date.Now
                    .UsuarioActualizacion = "1"
                End With
                objUsuario.UsuarioRol.Add(objUsuarioRol)
                objUsuario.AutenticacionUsuario.Add(objAutenticacionUsuario)
                Dim usuarioBE = SeguridadData.Usuario.Add(objUsuario)

                SeguridadData.SaveChanges()
                ts.Complete()

                rolRecuperado.usuarioID = usuarioBE.IDUsuario

                'rolRecuperado.IDUsuario = objUsuario.IDUsuario
                GrabarUsuarioAdminInicioSingle = rolRecuperado
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function AutenticacionUsuarioGrabarTodo(ByVal usuario As AutenticacionUsuario) As Integer
        Dim UsuarioBL As New UsuarioBL
        Dim UsuarioRolBL As New Rol
        Dim encriptador As New Cryptography
        Dim objAutenticacionUsuario As New AutenticacionUsuario
        Dim objUsuario As New Usuario
        Dim objUsuarioRol As New UsuarioRol

        Using ts As New TransactionScope

            If usuario.Action = BaseBE.EntityAction.INSERT Then



                Dim codigoenuso = (From obj In SeguridadData.Usuario
                                   Where obj.codigo = usuario.CustomUsuario.codigo).FirstOrDefault


                If Not (IsNothing(codigoenuso)) Then
                    Throw New Exception("Codigo de usuario en uso ingrese otro!")
                End If



                Dim consulta = (From obj In SeguridadData.Usuario
                                Where obj.NroDocumento = usuario.CustomUsuario.NroDocumento
                                 ).FirstOrDefault

                If (IsNothing(consulta)) Then
                    With objUsuario
                        .Action = usuario.CustomUsuario.Action
                        .ApellidoMaterno = usuario.CustomUsuario.ApellidoMaterno
                        .ApellidoPaterno = usuario.CustomUsuario.ApellidoPaterno
                        .IDEmpresa = usuario.IdEmpresa

                        .CorreoElectronico = usuario.CustomUsuario.CorreoElectronico
                        .FechaActualizacion = Date.Now
                        .IDCliente = usuario.CustomUsuario.IDCliente
                        .Nombres = usuario.CustomUsuario.Nombres
                        .estado = usuario.CustomUsuario.estado
                        .codigo = usuario.CustomUsuario.codigo
                        .NroDocumento = usuario.CustomUsuario.NroDocumento
                        .TipoDocumento = usuario.CustomUsuario.TipoDocumento
                        .UsuarioActualizacion = usuario.CustomUsuario.UsuarioActualizacion
                        .idUsuarioResponsable = usuario.CustomUsuario.idUsuarioResponsable
                    End With
                    With objAutenticacionUsuario
                        .Action = usuario.Action

                        Dim consulta2 = (From obj In SeguridadData.AutenticacionUsuario
                                         Join user In SeguridadData.Usuario
                                             On user.IDUsuario Equals obj.IDUsuario
                                         Where obj.Alias = usuario.AliasLogin
                                         Select obj).FirstOrDefault
                        If (IsNothing(consulta2)) Then
                            .Alias = encriptador.Decode(usuario.Alias)
                        Else
                            Throw New Exception("Existe un usuario registrado con ese Alias!")
                        End If
                        .IdEmpresa = usuario.IdEmpresa
                        .IDEstablecimiento = usuario.IDEstablecimiento
                        .Contrasena = encriptador.getSHA1Hash(encriptador.Decode(usuario.Contrasena))
                        .CorreoElectronico = usuario.CorreoElectronico
                        .EstaAutenticado = usuario.EstaAutenticado
                        .FechaActualizacion = Date.Now
                        .IDCliente = usuario.IDCliente
                        .PreguntaSecreta = usuario.PreguntaSecreta
                        .RespuestaSecreta = usuario.RespuestaSecreta
                        .UltimaFechaCambioPassword = usuario.UltimaFechaCambioPassword
                        .UltimaFechaLogueo = usuario.UltimaFechaLogueo
                        .UsuarioActualizacion = usuario.UsuarioActualizacion
                    End With

                    With objUsuarioRol
                        .Action = usuario.CustomUsuario.CustomUsuarioRol.Action
                        .IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol
                        .predeterminado = usuario.CustomUsuario.CustomUsuarioRol.predeterminado
                        .FechaActualizacion = Date.Now
                        .UsuarioActualizacion = usuario.CustomUsuario.CustomUsuarioRol.UsuarioActualizacion
                    End With

                    If usuario.Action = BaseBE.EntityAction.INSERT Then
                        objUsuario.UsuarioRol.Add(objUsuarioRol)
                        objUsuario.AutenticacionUsuario.Add(objAutenticacionUsuario)
                        SeguridadData.Usuario.Add(objUsuario)

                        objUsuarioRol.IDUsuario = objUsuario.IDUsuario

                        objUsuario.UsuarioRol.Add(objUsuarioRol)


                    Else
                        SeguridadData.Usuario.Attach(objUsuario)
                        ' SeguridadData.ObjectStateManager.GetObjectStateEntry(usuario).ChangeState(EntityState.Modified)
                    End If

                    'SeguridadData.SaveChanges()

                Else
                    Throw New Exception("Existe un usuario registrado con esos datos!")
                End If
            Else
                Dim consulta = (From obj In SeguridadData.Usuario
                                Where obj.IDUsuario = usuario.IDUsuario).FirstOrDefault

                If (Not IsNothing(consulta)) Then

                    Dim objUsuarioUpdate As Usuario = SeguridadData.Usuario.Where(Function(o) o.IDUsuario = usuario.IDUsuario
                                                                                     ).First

                    With objUsuarioUpdate
                        .Action = usuario.CustomUsuario.Action
                        .ApellidoMaterno = usuario.CustomUsuario.ApellidoMaterno
                        .ApellidoPaterno = usuario.CustomUsuario.ApellidoPaterno
                        .IDEmpresa = usuario.CustomUsuario.IDEmpresa

                        .CorreoElectronico = usuario.CustomUsuario.CorreoElectronico
                        .FechaActualizacion = Date.Now
                        .estado = usuario.CustomUsuario.estado
                        .IDCliente = usuario.CustomUsuario.IDCliente
                        .Nombres = usuario.CustomUsuario.Nombres
                        .NroDocumento = usuario.CustomUsuario.NroDocumento
                        .TipoDocumento = usuario.CustomUsuario.TipoDocumento
                        .UsuarioActualizacion = usuario.CustomUsuario.UsuarioActualizacion
                    End With

                    Dim objAutenticacionUsuarioUpdate As AutenticacionUsuario = SeguridadData.AutenticacionUsuario.Where(Function(o) o.IDUsuario = usuario.IDUsuario _
                                                                                                                             And o.IdEmpresa = usuario.IdEmpresa _
                                                                                                                             And o.IDEstablecimiento = usuario.IDEstablecimiento).First

                    With objAutenticacionUsuarioUpdate
                        .Action = usuario.Action

                        .IdEmpresa = usuario.IdEmpresa
                        .IDEstablecimiento = usuario.IDEstablecimiento
                        .Alias = encriptador.Decode(usuario.Alias)
                        .Contrasena = encriptador.getSHA1Hash(encriptador.Decode(usuario.Contrasena))
                        .CorreoElectronico = usuario.CorreoElectronico
                        .EstaAutenticado = usuario.EstaAutenticado
                        .FechaActualizacion = Date.Now
                        .IDCliente = usuario.IDCliente
                        .PreguntaSecreta = usuario.PreguntaSecreta
                        .RespuestaSecreta = usuario.RespuestaSecreta
                        .UltimaFechaCambioPassword = usuario.UltimaFechaCambioPassword
                        .UltimaFechaLogueo = usuario.UltimaFechaLogueo
                        .UsuarioActualizacion = usuario.UsuarioActualizacion
                    End With


                Else
                    Throw New Exception("No existe Usuario con estos datos!")
                End If
            End If
            SeguridadData.SaveChanges()
            ts.Complete()

            Return objUsuario.IDUsuario

        End Using
    End Function

    Public Function AutenticacionUsuarioGrabarTodoXModulo(ByVal usuario As AutenticacionUsuario, listAsegurableRol As List(Of Asegurable)) As Integer
        Dim UsuarioBL As New UsuarioBL
        Dim UsuarioRolBL As New Rol
        Dim encriptador As New Cryptography
        Dim objAutenticacionUsuario As New AutenticacionUsuario
        Dim objUsuario As New Usuario
        Dim objUsuarioRol As New UsuarioRol
        Dim AutorizacionRolBL As New AutorizacionRolBL

        Using ts As New TransactionScope

            If usuario.Action = BaseBE.EntityAction.INSERT Then



                Dim codigoenuso = (From obj In SeguridadData.Usuario
                                   Where obj.codigo = usuario.CustomUsuario.codigo).FirstOrDefault


                If Not (IsNothing(codigoenuso)) Then
                    Throw New Exception("Codigo de usuario en uso ingrese otro!")
                End If



                Dim consulta = (From obj In SeguridadData.Usuario
                                Where obj.NroDocumento = usuario.CustomUsuario.NroDocumento
                                 ).FirstOrDefault

                If (IsNothing(consulta)) Then
                    With objUsuario
                        .Action = usuario.CustomUsuario.Action
                        .ApellidoMaterno = usuario.CustomUsuario.ApellidoMaterno
                        .ApellidoPaterno = usuario.CustomUsuario.ApellidoPaterno
                        .idEmpresa = usuario.IdEmpresa

                        .CorreoElectronico = usuario.CustomUsuario.CorreoElectronico
                        .FechaActualizacion = Date.Now
                        .IDCliente = usuario.CustomUsuario.IDCliente
                        .Nombres = usuario.CustomUsuario.Nombres
                        .estado = usuario.CustomUsuario.estado
                        .codigo = usuario.CustomUsuario.codigo
                        .NroDocumento = usuario.CustomUsuario.NroDocumento
                        .TipoDocumento = usuario.CustomUsuario.TipoDocumento
                        .UsuarioActualizacion = usuario.CustomUsuario.UsuarioActualizacion
                        .idUsuarioResponsable = usuario.CustomUsuario.idUsuarioResponsable
                    End With
                    With objAutenticacionUsuario
                        .Action = usuario.Action

                        Dim consulta2 = (From obj In SeguridadData.AutenticacionUsuario
                                         Join user In SeguridadData.Usuario
                                             On user.IDUsuario Equals obj.IDUsuario
                                         Where obj.Alias = usuario.AliasLogin
                                         Select obj).FirstOrDefault
                        If (IsNothing(consulta2)) Then
                            .Alias = encriptador.Decode(usuario.Alias)
                        Else
                            Throw New Exception("Existe un usuario registrado con ese Alias!")
                        End If
                        .IdEmpresa = usuario.IdEmpresa
                        .IDEstablecimiento = usuario.IDEstablecimiento
                        .Contrasena = encriptador.getSHA1Hash(encriptador.Decode(usuario.Contrasena))
                        .CorreoElectronico = usuario.CorreoElectronico
                        .EstaAutenticado = usuario.EstaAutenticado
                        .FechaActualizacion = Date.Now
                        .IDCliente = usuario.IDCliente
                        .PreguntaSecreta = usuario.PreguntaSecreta
                        .RespuestaSecreta = usuario.RespuestaSecreta
                        .UltimaFechaCambioPassword = usuario.UltimaFechaCambioPassword
                        .UltimaFechaLogueo = usuario.UltimaFechaLogueo
                        .UsuarioActualizacion = usuario.UsuarioActualizacion
                    End With
                    With objUsuarioRol
                        .Action = usuario.CustomUsuario.CustomUsuarioRol.Action
                        .IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol
                        .predeterminado = usuario.CustomUsuario.CustomUsuarioRol.predeterminado
                        .estado = "A"
                        .idEmpresa = usuario.IdEmpresa
                        .idEstablecimiento = usuario.IDEstablecimiento
                        .FechaActualizacion = Date.Now
                        .UsuarioActualizacion = usuario.CustomUsuario.CustomUsuarioRol.UsuarioActualizacion
                    End With
                    If usuario.Action = BaseBE.EntityAction.INSERT Then

                        SeguridadData.Usuario.Add(objUsuario)
                        SeguridadData.SaveChanges()

                        objUsuarioRol.IDUsuario = objUsuario.IDUsuario
                        objUsuario.UsuarioRol.Add(objUsuarioRol)
                        SeguridadData.SaveChanges()

                        objAutenticacionUsuario.IDUsuario = objUsuario.IDUsuario
                        objUsuario.AutenticacionUsuario.Add(objAutenticacionUsuario)
                        SeguridadData.SaveChanges()
                        If (Not IsNothing(listAsegurableRol)) Then
                            AutorizacionRolBL.InsertarListaAsegurables(listAsegurableRol, objUsuarioRol.IDRol, objUsuario.IDUsuario)
                        End If


                    Else
                            SeguridadData.Usuario.Attach(objUsuario)
                        ' SeguridadData.ObjectStateManager.GetObjectStateEntry(usuario).ChangeState(EntityState.Modified)
                    End If

                    'SeguridadData.SaveChanges()

                Else
                    Throw New Exception("Existe un usuario registrado con esos datos!")
                End If
            Else
                Dim consulta = (From obj In SeguridadData.Usuario
                                Where obj.IDUsuario = usuario.IDUsuario).FirstOrDefault

                If (Not IsNothing(consulta)) Then

                    Dim objUsuarioUpdate As Usuario = SeguridadData.Usuario.Where(Function(o) o.IDUsuario = usuario.IDUsuario
                                                                                     ).First

                    With objUsuarioUpdate
                        .Action = usuario.CustomUsuario.Action
                        .ApellidoMaterno = usuario.CustomUsuario.ApellidoMaterno
                        .ApellidoPaterno = usuario.CustomUsuario.ApellidoPaterno
                        .idEmpresa = usuario.CustomUsuario.idEmpresa

                        .CorreoElectronico = usuario.CustomUsuario.CorreoElectronico
                        .FechaActualizacion = Date.Now
                        .estado = usuario.CustomUsuario.estado
                        .IDCliente = usuario.CustomUsuario.IDCliente
                        .Nombres = usuario.CustomUsuario.Nombres
                        .NroDocumento = usuario.CustomUsuario.NroDocumento
                        .TipoDocumento = usuario.CustomUsuario.TipoDocumento
                        .UsuarioActualizacion = usuario.CustomUsuario.UsuarioActualizacion
                    End With

                    Dim objAutenticacionUsuarioUpdate As AutenticacionUsuario = SeguridadData.AutenticacionUsuario.Where(Function(o) o.IDUsuario = usuario.IDUsuario _
                                                                                                                             And o.IdEmpresa = usuario.IdEmpresa _
                                                                                                                             And o.IDEstablecimiento = usuario.IDEstablecimiento).First

                    With objAutenticacionUsuarioUpdate
                        .Action = usuario.Action

                        .IdEmpresa = usuario.IdEmpresa
                        .IDEstablecimiento = usuario.IDEstablecimiento
                        .Alias = encriptador.Decode(usuario.Alias)
                        .Contrasena = encriptador.getSHA1Hash(encriptador.Decode(usuario.Contrasena))
                        .CorreoElectronico = usuario.CorreoElectronico
                        .EstaAutenticado = usuario.EstaAutenticado
                        .FechaActualizacion = Date.Now
                        .IDCliente = usuario.IDCliente
                        .PreguntaSecreta = usuario.PreguntaSecreta
                        .RespuestaSecreta = usuario.RespuestaSecreta
                        .UltimaFechaCambioPassword = usuario.UltimaFechaCambioPassword
                        .UltimaFechaLogueo = usuario.UltimaFechaLogueo
                        .UsuarioActualizacion = usuario.UsuarioActualizacion
                    End With


                Else
                    Throw New Exception("No existe Usuario con estos datos!")
                End If
            End If
            SeguridadData.SaveChanges()
            ts.Complete()

            Return objUsuario.IDUsuario

        End Using
    End Function

    Public Function AutenticacionUsuarioModificarContrasena(ByVal usuario As AutenticacionUsuario, ByVal nuevaContrasena As String) As Boolean
        Dim encriptador As New Cryptography
        Dim estado As Boolean = False
        If Not usuario.EstaAutenticado Then
            usuario.EstaAutenticado = EsUsuarioAutenticado(usuario)

        End If
        If (usuario.EstaAutenticado) = True Then
            'Dim encriptador As New Cryptography
            ''Se desencripta contraseña
            ''Se encripta para grabar en BD
            'usuario.Contrasena = String.Empty
            'usuario.Contrasena = encriptador.getSHA1Hash(encriptador.Decode(usuario.PasswordNuevo))
            'Se carga data para actualizar en BD

            'Dim strContrasena = encriptador.Decode(usuario.PasswordNuevo)
            'Se encripta la contraseña hash para comparar con BD
            Dim strContrasena = encriptador.getSHA1Hash(usuario.PasswordNuevo)

            Dim usuarioBE = (From obj In SeguridadData.AutenticacionUsuario
                             Where obj.IDUsuario = usuario.IDUsuario And obj.IdEmpresa = usuario.IdEmpresa And obj.IDEstablecimiento = usuario.IDEstablecimiento).Single
            usuarioBE.Contrasena = strContrasena
            usuarioBE.UltimaFechaCambioPassword = Date.Now
            SeguridadData.SaveChanges()
            estado = True
        Else
            estado = False
        End If
        Return estado
    End Function

    Public Function getRecuperarUsaurioLogeo(ByRef usuario As AutenticacionUsuario) As AutenticacionUsuario
        Try
            Dim usuarioAutenticado As AutenticacionUsuario
            Dim encriptador As New Cryptography
            Dim strAlias As String, strContrasena As String, strIDCliente As String
            Dim IDUsuario As Integer
            Dim idEmpresa As String = String.Empty
            Dim IdEstablecimiento As Integer = 0

            strIDCliente = usuario.IDCliente
            'Se desencripta el usuario y password
            strAlias = encriptador.Decode(usuario.Alias)
            strContrasena = encriptador.Decode(usuario.Contrasena)
            'Se encripta la contraseña hash para comparar con BD
            strContrasena = encriptador.getSHA1Hash(strContrasena)
            'Se consulta el alias de usuario

            idEmpresa = usuario.IdEmpresa
            IdEstablecimiento = usuario.IDEstablecimiento

            usuarioAutenticado = (From a In SeguridadData.AutenticacionUsuario
                                  Join u In SeguridadData.Usuario On a.IDUsuario Equals u.IDUsuario
                                  Where a.Alias = strAlias AndAlso
                                      u.estado = "A" And u.IDEmpresa = idEmpresa
                                  Select a).SingleOrDefault

            If usuarioAutenticado IsNot Nothing Then
                'Se verifica la contraseña.
                If usuarioAutenticado.Contrasena.CompareTo(strContrasena) = 0 Then
                    'usuario = usuarioAutenticado
                    With usuario
                        .Alias = usuarioAutenticado.Alias
                        .Bloqueado = usuarioAutenticado.Bloqueado
                        .Contrasena = usuarioAutenticado.Contrasena
                        .EstaAutenticado = usuarioAutenticado.EstaAutenticado
                        .IDCliente = usuarioAutenticado.IDCliente
                        .IDLogin = usuarioAutenticado.IDLogin
                        .IDUsuario = usuarioAutenticado.IDUsuario
                        .PreguntaSecreta = usuarioAutenticado.PreguntaSecreta
                        .RespuestaSecreta = usuarioAutenticado.RespuestaSecreta
                        .Usuario = Nothing
                        .CustomUsuario = New Usuario
                    End With

                    IDUsuario = usuario.IDUsuario
                    usuario.EstaAutenticado = True

                End If
            End If
            Return usuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function EsUsuarioAutenticadoLogin(ByRef usuario As AutenticacionUsuario) As Boolean
        Try

            Dim usuarioAutenticado As AutenticacionUsuario
            Dim encriptador As New Cryptography
            Dim strAlias As String, strContrasena As String, strIDCliente As String
            Dim IDUsuario As Integer
            Dim IDEmpresa As String
            Dim IDEstablecimiento As Integer
            Dim listaRolUsuario As New List(Of UsuarioRol)

            EsUsuarioAutenticadoLogin = False


            IDEmpresa = usuario.IdEmpresa
            IDEstablecimiento = usuario.IDEstablecimiento

            'strIDCliente = usuario.IDCliente
            'Se desencripta el usuario y password
            strAlias = encriptador.Decode(usuario.Alias)
            strContrasena = encriptador.Decode(usuario.Contrasena)
            'Se encripta la contraseña hash para comparar con BD
            strContrasena = encriptador.getSHA1Hash(strContrasena)
            'Se consulta el alias de usuario

            If (strAlias = "ADMINISTRADOR") Then

                usuarioAutenticado = (From a In SeguridadData.AutenticacionUsuario
                                      Join u In SeguridadData.Usuario On a.IDUsuario Equals u.IDUsuario
                                      Where a.Alias = strAlias
                                      Select a).SingleOrDefault

            Else
                usuarioAutenticado = (From a In SeguridadData.AutenticacionUsuario
                                      Join u In SeguridadData.UsuarioRol On a.IDUsuario Equals u.IDUsuario
                                      Where a.Alias = strAlias And u.idEmpresa = IDEmpresa And u.idEstablecimiento = IDEstablecimiento
                                      Select a).FirstOrDefault

            End If




            If usuarioAutenticado IsNot Nothing Then
                'Se verifica la contraseña.
                If usuarioAutenticado.Contrasena.CompareTo(strContrasena) = 0 Then
                    'usuario = usuarioAutenticado
                    With usuario
                        .Alias = usuarioAutenticado.Alias
                        .Bloqueado = usuarioAutenticado.Bloqueado
                        .Contrasena = usuarioAutenticado.Contrasena
                        .EstaAutenticado = usuarioAutenticado.EstaAutenticado
                        .IDCliente = usuarioAutenticado.IDCliente
                        .IDLogin = usuarioAutenticado.IDLogin
                        .IDUsuario = usuarioAutenticado.IDUsuario
                        .PreguntaSecreta = usuarioAutenticado.PreguntaSecreta
                        .RespuestaSecreta = usuarioAutenticado.RespuestaSecreta
                        .Usuario = Nothing
                        .CustomUsuario = New Usuario
                    End With


                    IDUsuario = usuario.IDUsuario
                    usuario.EstaAutenticado = True
                    'Se obtiene el rol de usuario
                    Dim usuarioBE = (From u In SeguridadData.Usuario Where u.IDUsuario = IDUsuario).Single

                    'usuario.CustomUsuario = usuarioBE
                    With usuario.CustomUsuario
                        .IDUsuario = usuarioBE.IDUsuario
                        .Nombres = usuarioBE.Nombres
                        .ApellidoMaterno = usuarioBE.ApellidoMaterno
                        .ApellidoPaterno = usuarioBE.ApellidoPaterno
                        .CorreoElectronico = usuarioBE.CorreoElectronico
                        .TipoDocumento = usuarioBE.TipoDocumento
                        .NroDocumento = usuarioBE.NroDocumento
                        .CustomUsuarioRol = New UsuarioRol
                    End With



                    Dim consulta = (From r In SeguridadData.UsuarioRol Join x In SeguridadData.Rol On r.IDRol Equals x.IDRol Where r.IDUsuario = IDUsuario And r.estado = "A").ToList()

                    For Each item In consulta

                        'Dim listaRolGrupoEmp = (From r In SeguridadData.RolXGrupoEmp Where r.IDRol = item.r.IDRol).ToList()

                        Dim rol As New UsuarioRol
                        rol.IDUsuario = item.r.IDUsuario
                        rol.IDRol = item.r.IDRol
                        rol.predeterminado = item.r.predeterminado
                        rol.nombrePerfil = item.x.Descripcion
                        rol.tipoEF = item.x.tipoEF
                        rol.control = item.x.control


                        'rol.listaRolGrupoEmp = New List(Of RolXGrupoEmp)
                        'rol.listaRolGrupoEmp = listaRolGrupoEmp

                        listaRolUsuario.Add(rol)
                    Next

                    usuario.CustomUsuario.CustomListaUsuarioRol = listaRolUsuario

                    'With usuario.CustomUsuario.CustomUsuarioRol
                    '    .IDUsuario = CType(usuarioBE.CustomUsuarioRol.IDUsuario, Integer)
                    '    .IDRol = usuarioBE.CustomUsuarioRol.IDRol
                    'End With


                    EsUsuarioAutenticadoLogin = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EsUsuarioAutenticadoLoginRecuperarPassword(ByRef usuario As AutenticacionUsuario) As String
        Try

            Dim usuarioAutenticado As AutenticacionUsuario
            Dim encriptador As New Cryptography
            Dim strAlias As String, strContrasena As String, strIDCliente As String
            Dim IDUsuario As Integer
            Dim IDEmpresa As String
            Dim IDEstablecimiento As Integer
            Dim estado As String
            Dim listaRolUsuario As New List(Of UsuarioRol)

            EsUsuarioAutenticadoLoginRecuperarPassword = False


            IDEmpresa = usuario.IdEmpresa
            IDEstablecimiento = usuario.IDEstablecimiento
            IDUsuario = usuario.IDUsuario
            'strIDCliente = usuario.IDCliente
            'Se desencripta el usuario y password
            'strAlias = encriptador.Decode(usuario.Alias)

            'Se consulta el alias de usuario


            usuarioAutenticado = (From a In SeguridadData.AutenticacionUsuario
                                  Join u In SeguridadData.UsuarioRol On a.IDUsuario Equals u.IDUsuario
                                  Where a.IDUsuario = IDUsuario And u.idEmpresa = IDEmpresa And u.idEstablecimiento = IDEstablecimiento
                                  Select a).FirstOrDefault



            If usuarioAutenticado IsNot Nothing Then
                'Se verifica la contraseña.

                With usuario
                    .Alias = usuarioAutenticado.Alias
                    .Bloqueado = usuarioAutenticado.Bloqueado
                    .Contrasena = usuarioAutenticado.Contrasena
                    .EstaAutenticado = usuarioAutenticado.EstaAutenticado
                    .IDCliente = usuarioAutenticado.IDCliente
                    .IDLogin = usuarioAutenticado.IDLogin
                    .IDUsuario = usuarioAutenticado.IDUsuario
                    .PreguntaSecreta = usuarioAutenticado.PreguntaSecreta
                    .RespuestaSecreta = usuarioAutenticado.RespuestaSecreta
                    .Usuario = Nothing
                    .CustomUsuario = New Usuario
                End With


                'strContrasena = encriptador.Decode(usuario.Contrasena)
                'Se encripta la contraseña hash para comparar con BD
                'strContrasena = encriptador.getSHA1Hash(usuario.Contrasena)
                strContrasena = encriptador.Decode(strContrasena)

                EsUsuarioAutenticadoLoginRecuperarPassword = strContrasena
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
