Partial Public Class InventarioMovimiento
    Inherits BaseBE

    Public customLote As recursoCostoLote
    Public customProducto As detalleitems

    Public ReadOnly Property GetImporteAlmacen As Decimal
        Get
            Return cantidad * precUnite
        End Get
    End Property

    Public Property codigoBarra() As String

    Public Property NomEstablecimiento() As String
    Public Property nombreItem() As String
    Public Property tipoExistencia() As String
    Public Property NombreAlmacen() As String
    Public Property ComprobanteCompra() As String
    Public Property NumDocCompra() As String
    Public Property TipoCambio() As Decimal
    Public Property IdProveedor() As Integer
    Public Property nombreProveedor() As String
    Public Property NombrePresentacion() As String
    Public Property glosa() As String
    Public Property DetalleTipoOperacion() As String

    Public Property Secuencia() As Integer



    Public Property CantSalida() As Decimal
    Public Property PrUnitS() As Decimal
    Public Property CostoSalida() As Decimal


    Public Property CantEntrada() As Decimal
    Public Property PrUnitE() As Decimal
    Public Property CostoEntrada() As Decimal


    Public Property CantSaldo() As Decimal
    Public Property CostoSaldo() As Decimal

    Public Property PrecioPromedio() As Decimal
    Public Property TipoAlmacen() As String

    Public Property ValorDeVenta() As Decimal?

    Public Property rentabilidad() As Decimal?

    Public Property UnidadFraccion As Decimal?
    Public Property MatriculaVehiculo As String
    Public Property Chofer As String
    Public Property CodigoUsuario As Integer
    Public Property nombreUsuario As String

    Public Property montoOtherME As Nullable(Of Decimal)

    Public Property tipoConsulta As String

End Class
