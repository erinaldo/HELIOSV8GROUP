Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)> _
Public Class AutenticacionUsuarioRequest
    <MessageBodyMember()>
    Property AutenticacionUsuario As AutenticacionUsuario
    <MessageBodyMember()>
    Property NuevaContrasena As String

    <MessageBodyMember()>
    Property listaAsegurableRol As List(Of Asegurable)
End Class

