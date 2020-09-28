Partial Public Class documentoventaAbarrotesDet
    Inherits BaseBE

    '  Public Property codigoLote() As Integer

    Public Property CustomtotalesAlmacenOthers As totalesAlmacenOthers
    Public Property idalmacenDestino As Integer
    Public Property CodigoCosto As String
    Public Property ContenidoNetoUnidadComercialMaxima As Decimal?
    Public Property CustomProducto As detalleitems

    Public Property CustomAlmacenPartida As almacen
    Public Property CustomAlmacenLlegada As almacen

    Public Property CustomTotalMovimientosGuia As List(Of documentoguiaDetalle)

    Public Property Customlote As recursoCostoLote
    Public Property CustomListaVentaDetalle As List(Of documentoventaAbarrotesDet)
    Public Property CustomListaInventarioMovimiento As List(Of InventarioMovimiento)
    Public Property CustomEquivalencia As detalleitem_equivalencias
    Public Property CustomCatalogo As detalleitemequivalencia_catalogos
    Public Property CustomEntidad As entidad

    Public Property idDocuemntoNotaInv As Integer
    Public Property NomEstablecimiento() As String

    Public Property saldoVentaMN() As Decimal
    Public Property saldoVentaME() As Decimal

    Public Property ImporteDevolucionmn() As Decimal?
    Public Property ImporteDevolucionme() As Decimal?

    Public Property IgvDevolucionmn() As Decimal?
    Public Property BiDevolucionmn() As Decimal?
    Public Property Bi2Devolucionmn() As Decimal?

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
    'Public Property idPadreDTCompra() As String

    Public Property FechaPeriodo() As String
    Public Property ImporteDBMN() As Decimal
    Public Property ImporteDBME() As Decimal

    Public Property TipoOperacion() As String
    Public Property FlagBonif() As String
    Public Property TieneExcedente() As Boolean
    Public Property stock() As Double


    Public Property VentaTotalSinIgv() As Decimal?
    Public Property CostoTotalInv() As Decimal?
    Public Property NombreAlmacen() As String

    Public Property tipoCambio As Decimal
    Public Property NomMarca() As String

    Public Property FechaLaboral() As DateTime?
    Public Property cantidadEntrega() As Decimal

    Public Property montokardexDB() As Decimal
    Public Property montokardexDBUS() As Decimal

    Public Property montoCompesacion() As Decimal
    Public Property montoCompesacionme() As Decimal

    Public Property montoDevuelto() As Decimal
    Public Property montoDevueltome() As Decimal

    Public Property cantNC As Decimal
    Public Property igvNC As Decimal
    Public Property igvNCME As Decimal
    Public Property biNC As Decimal
    Public Property biNCME As Decimal

    Public montoNC As Decimal
    Public montoNCME As Decimal

    Public Property nombreComercial As String

    Public Property CustomOferta_Detalle() As ventaDetalle_oferta

    Public ReadOnly Property GetSustento() As Boolean
        Get
            If NomMarca = "Doc." Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

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
            Return importeMN.GetValueOrDefault - MontoPago
        End Get
    End Property

    Public ReadOnly Property MontoSaldoME() As Decimal
        Get
            Return importeME.GetValueOrDefault - MontoPagoME
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

    Public ReadOnly Property RentabilidadMN() As Decimal
        Get
            Return VentaTotalSinIgv.GetValueOrDefault - CostoTotalInv.GetValueOrDefault
        End Get
    End Property


    ''' <summary>
    ''' Suma de cantidades distribuidas
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GetCantidadAcuenta() As Decimal?
        Get
            Dim sumaCantidad As Decimal = 0
            sumaCantidad = cantidadEntrega
            'If CustomTotalMovimientosGuia IsNot Nothing Then
            '    sumaCantidad = CustomTotalMovimientosGuia.Sum(Function(o) o.cantidad).GetValueOrDefault()
            'End If
            Return sumaCantidad
        End Get
    End Property

    ''' <summary>
    ''' Saldo pendiente en unidades o cantidad
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GetCantidadSaldo As Decimal?
        Get
            Return Decimal.Subtract(monto1.GetValueOrDefault, GetCantidadAcuenta.GetValueOrDefault)
        End Get
    End Property

    Public Property PrecioUnitarioVentaMN As Decimal?
    Public Property PrecioUnitarioVentaME As Decimal?

    Public Property PagoSumaMN As Decimal?
    Public Property PagoSumaME As Decimal?

    Public Property Menor As Decimal?
    Public Property Mayor As Decimal?
    Public Property GMayor As Decimal?
    Public Property codigoBarra As String
    Public Property canDisponible As Decimal?

    Public Property cantidadInventario() As Decimal

    Public Property AfectoInventario() As Boolean

    Public Property conteoHospedados As Integer
    Public Property fechaIngreso As DateTime
    Public Property fechaFin As DateTime
    Public Property listaPersonaHospedada As List(Of personaBeneficio)

    Public Property listaConexos As List(Of detalleitems_conexo)
    Public Property ocupacionInfra As ocupacionInfraestructura
    Public Property listaIdDistribucion As List(Of String)

End Class
