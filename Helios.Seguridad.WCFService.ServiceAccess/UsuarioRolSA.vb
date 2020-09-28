Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.MessageContract
Public Class UsuarioRolSA

    Public Function InserRoleUser(objRol As UsuarioRol) As UsuarioRol
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.InserRoleUser(New UsuarioRolRequest() With {.ObjUsuarioRol = objRol})
        Return Response.ObjUsuarioRol
    End Function

    Public Function GetListaUsuariosXPerfil() As List(Of UsuarioRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetListaUsuariosXPerfil()
        Return Response.ListadoUsuarioRol
    End Function

    Public Function GetListaUsuariosXPerfilXCliente(ClienteID As String) As List(Of UsuarioRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetListaUsuariosXPerfilXCliente(New UsuarioRolRequest() With {.ClieneID = ClienteID})
        Return Response.ListadoUsuarioRol
    End Function

    Public Function GetListaUsuariosXPerfilAndPassword(ClienteID As String) As List(Of UsuarioRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetListaUsuariosXPerfilAndPassword(New UsuarioRolRequest() With {.ClieneID = ClienteID})
        Return Response.ListadoUsuarioRol
    End Function

    Public Function GetListaCargosXPerfilAndPassword(autorizacionRolBE As AutenticacionUsuario) As List(Of UsuarioRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.GetListaCargosXPerfilAndPassword(New UsuarioRolRequest() With {.ObjUsuarioAutenticacion = autorizacionRolBE})
        Return Response.ListadoUsuarioRol
    End Function

    Public Function updateEstadoRoleUser(autorizacionRolBE As UsuarioRol) As List(Of UsuarioRol)
        Dim miServicio = General.GetHeliosProxy()
        Dim Response = miServicio.updateEstadoRoleUser(New UsuarioRolRequest() With {.ObjUsuarioRol = autorizacionRolBE})
        Return Response.ListadoUsuarioRol
    End Function


End Class
