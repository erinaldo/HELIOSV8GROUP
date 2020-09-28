Imports Helios.Seguridad.Business.Entity
Imports System.ServiceModel

<MessageContract(IsWrapped:=True)>
Public Class ProductoResponse
    <MessageBodyMember()>
    Public Property ListadoProducto As List(Of Producto)
    <MessageBodyMember()>
    Public Property ObjProducto As Producto
    <MessageBodyMember()>
    Public Property idProducto As Integer
    <MessageBodyMember()>
    Public Property ListadoProductoID As List(Of Integer)
    <MessageBodyMember()>
    Public Property tipoProducto As String
End Class
