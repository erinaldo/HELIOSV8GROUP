Public Class documentoPedidoDet
    Inherits BaseBE

    Public Property CodigoCosto As String
    Public Property NomEstablecimiento() As String
    Public Property IdEmpresa() As String
    Public Property IdEstablecimiento() As Integer
    Public Property Glosa() As String

    Public Property DetalleItem() As String
    Public Property FechaDoc() As DateTime?

    Public Property CuentaProvedor() As String
    Public Property NombreProveedor() As String

    Public Property NumDoc() As String
    Public Property Serie() As String
    Public Property TipoDoc() As String

    Public Property nombreMesa() As String
    Public Property nombreArea() As String
    Public Property NumeroMesa() As Integer

    Public Property CustomOferta_Detalle() As ventaDetalle_oferta
    Public Property listaEstado() As List(Of String)
    Public Property listaSecuencia() As List(Of Integer)
    Public Property informacionComplementariaBE As informacionComplementaria

    Public ReadOnly Property EstadoPagos() As String
        Get
            If MontoSaldo <= 0 Then
                Return "DC"
            Else
                Return "PN"
            End If

        End Get
    End Property

    Public ReadOnly Property MontoSaldo() As Decimal
        Get
            Return importeMN - MontoPago
        End Get
    End Property

    Public ReadOnly Property ItemSaldado() As String
        Get
            Return "DC"
        End Get
    End Property

    Public ReadOnly Property ItemPendiente() As String
        Get
            Return "PN"
        End Get
    End Property

    Private _montoPago As Decimal
    Public Property MontoPago() As Decimal
        Get
            Return _montoPago
        End Get
        Set(ByVal value As Decimal)
            _montoPago = value
        End Set
    End Property

    Public Property CustomProducto As detalleitems
    Public Property CustomListaInventarioMovimiento As List(Of InventarioMovimiento)
    Public Property CustomEquivalencia As detalleitem_equivalencias
    Public Property CustomCatalogo As detalleitemequivalencia_catalogos

    Public Property AfectoInventario() As Boolean

End Class
