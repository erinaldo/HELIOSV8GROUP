Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)> _
Public Class RolRequest

    <MessageBodyMember()>
    Property ListadoRoles As List(Of Rol)
    <MessageBodyMember()>
    Property ObjRoles As Rol
    <MessageBodyMember()>
    Property idRol As Integer
End Class
