Partial Public Class inventarioTransito
    Inherits BaseBE

    Public Property cantidadOriginal As Decimal?
    Public Property CustomProducto As detalleitems
    Public Property CustomDetalleCompra As documentocompradetalle
    Public Property CustomListaInventario As List(Of InventarioMovimiento)
    Public Property AlmacenEnvio() As Integer?
End Class
