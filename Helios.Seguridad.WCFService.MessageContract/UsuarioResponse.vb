Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)> _
Public Class UsuarioResponse

    <MessageBodyMember()>
    Public Property ListadoUsuarios As List(Of Usuario)
    '<MessageBodyMember()>
    'Public Property Usuario As Usuario

    <MessageBodyMember()>
    Public Property Usuario As Usuario

    <MessageBodyMember()>
    Public Property UsuarioConteo As Integer


    <MessageBodyMember()>
    Public Property UsuarioRol As UsuarioRol
   
End Class
