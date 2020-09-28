Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)> _
Public Class AsegurableResponse

    <MessageBodyMember()>
    Public Property ListadoAsegurables As List(Of Asegurable)
    <MessageBodyMember()>
    Public Property ObjAsegurables As Asegurable
    <MessageBodyMember()>
    Public Property idAsegurables As Integer
    <MessageBodyMember()>
    Public Property ListadoAsegurablesID As List(Of Integer)
End Class
