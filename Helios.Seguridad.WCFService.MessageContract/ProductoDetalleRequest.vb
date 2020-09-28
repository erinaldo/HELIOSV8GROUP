Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)>
Public Class ProductoDetalleRequest
    <MessageBodyMember()>
    Property ListadoProductoDetalle As List(Of ProductoDetalle)
    <MessageBodyMember()>
    Property ObjProductoDetalle As ProductoDetalle
    <MessageBodyMember()>
    Property idProductoDetalle As Integer
End Class
