Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)> _
Public Class UsuarioRequest

    <MessageBodyMember()>
    Property ListadoUsuarios As List(Of Usuario)

    <MessageBodyMember()>
    Property UsuarioConteo As Integer

    <MessageBodyMember()>
    Property Usuario As Usuario

    '<MessageBodyMember()>
    'Property Usuario As Usuario
    <MessageBodyMember()>
    Property UsuarioRol As UsuarioRol

    <MessageBodyMember()>
    Property IDCliente As String

End Class
