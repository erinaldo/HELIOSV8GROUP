Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)>
Public Class ProductoRequest
    <MessageBodyMember()>
    Property ListadoProducto As List(Of Producto)
    <MessageBodyMember()>
    Property ObjProducto As Producto
    <MessageBodyMember()>
    Property idProducto As Integer
    <MessageBodyMember()>
    Property tipoProducto As String
    <MessageBodyMember()>
    Property ListadoProductoID As List(Of Integer)
End Class
