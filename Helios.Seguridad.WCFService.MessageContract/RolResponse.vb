Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)> _
Public Class RolResponse

    <MessageBodyMember()>
    Public Property ListadoRoles As List(Of Rol)
    <MessageBodyMember()>
    Public Property ObjRoles As Rol
    <MessageBodyMember()>
      Public Property idRol As Integer
End Class
