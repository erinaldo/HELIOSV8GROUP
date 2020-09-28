Partial Public Class registrocomision_autorizacion
    Inherits BaseBE

    Public Property customProducto As detalleitems

    Public Property customUnidadComercial As detalleitem_equivalencias

    Public Property customCatalogoPrecio As detalleitemequivalencia_catalogos

    Public Property customRegistrocomision_usuarios As registrocomision_usuarios

    Public Property customRegistrocomision_usuarios_detalle As registrocomision_usuarios_detalle

    Public Property customDocumentoVenta As documentoventaAbarrotes

    Private _montoPago As Decimal
    Private _montoPagoME As Decimal
    Public Property MontoPago() As Decimal
        Get
            Return _montoPago
        End Get
        Set(ByVal value As Decimal)
            _montoPago = value
        End Set
    End Property

    Public Property MontoPagoME() As Decimal
        Get
            Return _montoPagoME
        End Get
        Set(ByVal value As Decimal)
            _montoPagoME = value
        End Set
    End Property


    Public ReadOnly Property MontoSaldo() As Decimal
        Get
            Return importeAutorizado - MontoPago
        End Get
    End Property

    Public ReadOnly Property ItemSaldado() As Integer
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property ItemPendiente() As Integer
        Get
            Return 0
        End Get
    End Property

End Class
