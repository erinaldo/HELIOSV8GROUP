Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.MessageContract
Imports JNetFx.Framework.General

Public Class AutenticacionUsuarioSA

    Public Function BuscarContraseñaAliasUser(usuario As AutenticacionUsuario) As AutenticacionUsuario
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.BuscarContraseñaAliasUser(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = usuario})
        Return Response.AutenticacionUsuario
    End Function
    Public Function UpdateContrasenaUsuario(usuario As AutenticacionUsuario) As AutenticacionUsuario
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.UpdateContrasenaUsuario(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = usuario})
        Return Response.AutenticacionUsuario
    End Function
    Public Function AutenticarUsuario(ByRef be As AutenticacionUsuario) As Boolean
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography
        be.Alias = Cryptography.Encode(be.Alias)
        be.Contrasena = Cryptography.Encode(be.Contrasena)

        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.AutenticarUsuario(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = be})

        'Dim UsuarioRolLista As IList(Of UsuarioRol) = New List(Of UsuarioRol) From {Response.UsuarioRol}
        If Response.Usuario IsNot Nothing Then
            Response.Usuario.CustomUsuarioRol = Response.UsuarioRol
            Response.AutenticacionUsuario.CustomUsuario = Response.Usuario
        End If
        be = Response.AutenticacionUsuario
        Return Response.rpta
    End Function

    Public Function getRecuperarUsaurioLogeo(ByRef be As AutenticacionUsuario) As Boolean
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography
        be.Alias = Cryptography.Encode(be.Alias)
        be.Contrasena = Cryptography.Encode(be.Contrasena)

        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.getRecuperarUsaurioLogeo(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = be})

        'Dim UsuarioRolLista As IList(Of UsuarioRol) = New List(Of UsuarioRol) From {Response.UsuarioRol}
        If Response.Usuario IsNot Nothing Then
            Response.Usuario.CustomListaUsuarioRol = Response.ListaUsuarioRol
            Response.AutenticacionUsuario.CustomUsuario = Response.Usuario
        End If
        be = Response.AutenticacionUsuario
        Return Response.rpta
    End Function



    Public Function EsUsuarioAutenticadoConfPrecio(ByRef be As AutenticacionUsuario) As Boolean
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography
        be.Alias = Cryptography.Encode(be.Alias)
        be.Contrasena = Cryptography.Encode(be.Contrasena)

        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.EsUsuarioAutenticadoConfPrecio(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = be})

        'Dim UsuarioRolLista As IList(Of UsuarioRol) = New List(Of UsuarioRol) From {Response.UsuarioRol}
        If Response.Usuario IsNot Nothing Then
            Response.Usuario.CustomUsuarioRol = Response.UsuarioRol
            Response.AutenticacionUsuario.CustomUsuario = Response.Usuario
        End If
        be = Response.AutenticacionUsuario
        Return Response.rpta
    End Function

    Public Function AutenticarUsuarioSingle(ByRef be As AutenticacionUsuario) As Boolean
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography
        be.Alias = Cryptography.Encode(be.Alias)
        be.Contrasena = Cryptography.Encode(be.Contrasena)

        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.AutenticarUsuarioSingle(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = be})

        'Dim UsuarioRolLista As IList(Of UsuarioRol) = New List(Of UsuarioRol) From {Response.UsuarioRol}
        If Response.Usuario IsNot Nothing Then
            Response.Usuario.CustomUsuarioRol = Response.UsuarioRol
            Response.AutenticacionUsuario.CustomUsuario = Response.Usuario
        End If
        be = Response.AutenticacionUsuario
        Return Response.rpta
    End Function

    Public Function AutenticacionUsuarioGrabarTodo(ByVal be As AutenticacionUsuario) As Integer
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography
        Dim objUsuario As New Usuario
        be.Alias = Cryptography.Encode(be.Alias)
        be.Contrasena = Cryptography.Encode(be.Contrasena)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.AutenticacionUsuarioGrabarTodo(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = be})
        Return Response.idPersona
    End Function

    Public Function AutenticacionUsuarioGrabarTodoXModulo(ByVal be As AutenticacionUsuario, ByVal listaAutorizacionRol As List(Of Asegurable)) As Integer
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography
        Dim objUsuario As New Usuario
        be.Alias = Cryptography.Encode(be.Alias)
        be.Contrasena = Cryptography.Encode(be.Contrasena)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.AutenticacionUsuarioGrabarTodoXModulo(New AutenticacionUsuarioRequest() With {.listaAsegurableRol = listaAutorizacionRol, .AutenticacionUsuario = be})
        Return Response.idPersona
    End Function


    Public Sub GrabarAdministradorDefault(ByVal be As AutenticacionUsuario)
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography
        Dim objUsuario As New Usuario
        be.IDCliente = be.IDCliente
        be.IdEmpresa = be.IdEmpresa
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarAdministradorDefault(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = be})
    End Sub

    Public Sub GrabarSuperAdministradorDefault(ByVal be As AutenticacionUsuario)
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography
        Dim objUsuario As New Usuario
        be.IDCliente = be.IDCliente
        be.IdEmpresa = be.IdEmpresa
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarSuperAdministradorDefault(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = be})
    End Sub

    Public Function CambiarContrasena(ByRef be As AutenticacionUsuario) As Boolean
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography
        be.Alias = Cryptography.Encode(be.Alias)
        be.Contrasena = Cryptography.Encode(be.Contrasena)

        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.CambiarContrasena(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = be})

        'Dim UsuarioRolLista As IList(Of UsuarioRol) = New List(Of UsuarioRol) From {Response.UsuarioRol}
        If Response.Usuario IsNot Nothing Then
            Response.Usuario.CustomUsuarioRol = Response.UsuarioRol
            Response.AutenticacionUsuario.CustomUsuario = Response.Usuario
        End If
        be = Response.AutenticacionUsuario
        Return Response.rpta
    End Function

    Public Function EsUsuarioAutenticadoLoginRecuperarPassword(ByRef be As AutenticacionUsuario) As String
        'Se controla la seguridad en ambos extremos de la llamada
        Dim Cryptography As New Cryptography


        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.EsUsuarioAutenticadoLoginRecuperarPassword(New AutenticacionUsuarioRequest() With {.AutenticacionUsuario = be})

        'Dim UsuarioRolLista As IList(Of UsuarioRol) = New List(Of UsuarioRol) From {Response.UsuarioRol}

        Response.password = Response.password

        Return Response.password
    End Function

End Class
