Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)>
Public Class AutenticacionUsuarioResponse
    <MessageBodyMember()> Public Property AutenticacionUsuario As AutenticacionUsuario
    <MessageBodyMember()> Public Property UsuarioRol As UsuarioRol
    <MessageBodyMember()> Public Property ListaUsuarioRol As List(Of UsuarioRol)
    <MessageBodyMember()> Public Property Usuario As Usuario
    <MessageBodyMember()> Public Property rpta As Boolean
    <MessageBodyMember()> Public Property password As String

    <MessageBodyMember()> Public Property Messages As List(Of String)
    <MessageBodyMember()> Public Property idPersona As Integer
    <MessageBodyMember()> Public Property ListaAutorizacionRol As List(Of AutorizacionRol)
End Class
