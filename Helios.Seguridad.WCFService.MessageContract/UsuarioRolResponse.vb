Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)>
Public Class UsuarioRolResponse
    <MessageBodyMember()>
    Public Property ListadoUsuarioRol As List(Of UsuarioRol)
    <MessageBodyMember()>
    Public Property ObjUsuarioRol As UsuarioRol
    <MessageBodyMember()>
    Public Property idUsuarioRol As Integer
    <MessageBodyMember()>
    Public Property ClienteID As Integer
End Class
