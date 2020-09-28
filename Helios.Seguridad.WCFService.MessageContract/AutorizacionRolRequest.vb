Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)> _
Public Class AutorizacionRolRequest
    <MessageBodyMember()>
    Property AutorizacionRol As AutorizacionRol
    <MessageBodyMember()>
    Property AutorizacionRolList As List(Of AutorizacionRol)
    <MessageBodyMember()>
    Property Asegurable As Asegurable
    <MessageBodyMember()>
    Property IdProducto As Integer
End Class
