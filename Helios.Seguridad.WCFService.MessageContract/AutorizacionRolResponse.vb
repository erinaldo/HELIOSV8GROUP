Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)> _
Public Class AutorizacionRolResponse
    <MessageBodyMember()>
    Property AutorizacionRol As AutorizacionRol
    <MessageBodyMember()>
    Property AutorizacionRolList As List(Of AutorizacionRol)
    <MessageBodyMember()>
    Property AsegurableList As List(Of Asegurable)
    <MessageBodyMember()>
    Property IdProducto As Integer
End Class
