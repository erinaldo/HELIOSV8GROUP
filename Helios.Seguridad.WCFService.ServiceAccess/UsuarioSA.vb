Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.MessageContract
Public Class UsuarioSA

    Public Function UpdateCargoXID(usuario As Usuario) As Usuario
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.UpdateCargoXID(New UsuarioRequest() With {.Usuario = usuario})
        Return Response.Usuario
    End Function
    Public Function GetListaUsuarios() As List(Of Usuario)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoUsuarios()
        Return Response.ListadoUsuarios
    End Function

    Public Function UbicarUsuarioXid(ByVal be As Usuario) As Usuario
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.UbicarUsuarioXid(New UsuarioRequest() With {.Usuario = be})
        Return Response.Usuario
    End Function



    Public Function GetUpdateUsuario(ByVal be As Usuario) As Usuario
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetUpdateUsuario(New UsuarioRequest() With {.Usuario = be})
        Return Response.Usuario
    End Function

    Public Function ListadoUsuariosSoloCargoNoResp(ByVal be As Usuario) As List(Of Usuario)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoUsuariosSoloCargoNoResp(New UsuarioRequest() With {.Usuario = be})
        Return Response.ListadoUsuarios
    End Function

    Public Function ListadoUsuariosConResponsable(ByVal be As Usuario) As List(Of Usuario)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoUsuariosConResponsable(New UsuarioRequest() With {.Usuario = be})
        Return Response.ListadoUsuarios
    End Function


    Public Function ListadoUsuariosXclienteCargo(usuarioBE As Usuario) As List(Of Usuario)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoUsuariosXclienteCargo(New UsuarioRequest() With {.Usuario = usuarioBE})
        Return Response.ListadoUsuarios
    End Function
    Public Function ListadoUsuariosXcliente(ByVal IDCliente As String) As List(Of Usuario)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoUsuariosXcliente(New UsuarioRequest() With {.IDCliente = IDCliente})
        Return Response.ListadoUsuarios
    End Function

    Public Function GetListaAsegurablesXClientePOS(ObjAsegurable As Asegurable) As List(Of Asegurable)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetListaAsegurablesXClientePOS(New AsegurableRequest() With {.ObjAsegurables = ObjAsegurable})
        Return Response.ListadoAsegurables
    End Function

    Public Function ListadoUsuariosPuntoVenta(usuarioRol As UsuarioRol) As List(Of Usuario)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoUsuariosPuntoVenta(New UsuarioRequest() With {.UsuarioRol = usuarioRol})
        Return Response.ListadoUsuarios
    End Function

    Public Function ListadoUsuariosconteo() As Integer
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoUsuariosconteo()
        Return Response
    End Function

    Public Function UbicarUsuarioCaja(usuario As Usuario) As Usuario
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.UbicarUsuarioCaja(New UsuarioRequest() With {.Usuario = usuario})
        Return Response.Usuario
    End Function

    Public Sub DeletePersonaXCaja(usuario As Usuario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeletePersonaXCaja(New UsuarioRequest() With {.Usuario = usuario})
    End Sub

    Public Function UpdateUsuarioXID(usuario As Usuario) As Usuario
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.UpdateUsuarioXID(New UsuarioRequest() With {.Usuario = usuario})
        Return Response.Usuario
    End Function

    Public Function UpdateUsuarioCodigoAsignado(usuario As Usuario) As Usuario
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.UpdateUsuarioCodigoAsignado(New UsuarioRequest() With {.Usuario = usuario})
        Return Response.Usuario
    End Function

    Public Function ListadoUsuariosv2() As List(Of Usuario)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.ListadoUsuariosv2()
        Return Response.ListadoUsuarios
    End Function

End Class
