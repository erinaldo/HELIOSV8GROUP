Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)> _
Public Class AsegurableRequest

    <MessageBodyMember()>
    Property ListadoAsegurables As List(Of Asegurable)
    <MessageBodyMember()>
    Property ObjAsegurables As Asegurable
    <MessageBodyMember()>
    Property idAsegurables As Integer
    <MessageBodyMember()>
    Property ListadoAsegurablesID As List(Of Integer)
End Class
