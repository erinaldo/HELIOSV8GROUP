Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)>
Public Class UsuarioRolRequest
    <MessageBodyMember()>
    Property ListadoUsuarioRol As List(Of UsuarioRol)
    <MessageBodyMember()>
    Property ObjUsuarioRol As UsuarioRol

    <MessageBodyMember()>
    Property ObjUsuarioAutenticacion As AutenticacionUsuario

    <MessageBodyMember()>
    Property idUsuarioRol As Integer
    <MessageBodyMember()>
    Property ClieneID As Integer
End Class
