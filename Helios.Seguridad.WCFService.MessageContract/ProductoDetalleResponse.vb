Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)>
Public Class productoDetalleResponse
    <MessageBodyMember()>
    Public Property ListadoProductoDetalle As List(Of ProductoDetalle)
    <MessageBodyMember()>
    Public Property ObjProductoDetalle As ProductoDetalle
    <MessageBodyMember()>
    Public Property idProductoDetalle As Integer
End Class
