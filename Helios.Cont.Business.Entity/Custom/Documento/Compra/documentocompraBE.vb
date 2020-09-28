Partial Public Class documentocompra
    Inherits BaseBE


    Public Property CustomDetalleCompra As documentocompradetalle
    Public Property CustomEntidad As entidad

    Public Property rucProveedor As String
    Public Property AsigancionDeLotes() As String
    Public Property conteoCuotas As Integer?
    Public Property TipoExistencia() As String
    Public Property EstadoPagoDevolucion() As String

    Public Property ImporteDevMN() As Decimal?
    Public Property ImporteDevME() As Decimal?
    Public Property SaldoVentaMN() As Decimal?
    Public Property SaldoVentaME() As Decimal?

    Public Property Monto30mn() As Decimal
    Public Property Monto30me() As Decimal

    Public Property modulo As String
    Public Property terminos As String

    Public Property SerieNota() As String
    Public Property NumeroNota() As String
    Public Property TipoDocNota() As String
    Public Property FechaNota() As DateTime

    Public Property Monto60mn() As Decimal
    Public Property Monto60me() As Decimal

    Public Property Monto90mn() As Decimal
    Public Property Monto90me() As Decimal

    Public Property Monto90Masmn() As Decimal
    Public Property Monto90Masme() As Decimal

    Public Property tipoDocEntidad() As String
    Public Property NroDocEntidad() As String
    Public Property NombreEntidad() As String
    Public Property TipoPersona() As String

    Property nombreProveedor As String
    Property numeroDocumento As String
    Property nombreEstablecimiento As String
    Public Property TipoConfiguracion() As String
    Public Property IdNumeracion() As Integer
    Public Property NroComprobanteNotas() As String

    'caja
    Public Property DetalleItemCaja() As String
    Public Property TipoDocPagoCaja() As String
    Public Property NumDocOperCaja() As String
    Public Property NumeroTipoDocCaja() As String
    Public Property CtaCorrienteDeposito() As String
    Public Property BancoDeposito() As String
    Public Property ImportePagoME() As Decimal
    Public Property ImportePagoMN() As Decimal
    Public Property NombreCajaPago() As String
    Public Property FechaPago() As DateTime


    Public Property ImporteCompraDetalleMN() As Decimal
    Public Property ImporteCompraDetalleME() As Decimal

    Public Property CountCompras() As Integer

    Public Property PagoSumaMN() As Decimal?
    Public Property PagoSumaME() As Decimal?

    Public Property CajaSeleccionada() As Integer

    Public Property Atraso() As Integer

    'Public Property Ant() As Integer
    '    Get
    'Return DateDiff(DateInterval.Day, DateTime.Now.Date, CDate(fechaDoc))
    'End Get
    'End Property

    Public Property NomProducto() As String
    Public Property UnidMedidad() As String
    Public Property Cantidad() As Decimal
    Public Property PrecUnit() As Decimal

    Public Property NomAlmacenOrigen() As String
    Public Property NomAlmacenDestino() As String

    Public ReadOnly Property SaldoReclamacion As Decimal?
        Get
            Return importeTotal - ImporteDevMN
        End Get
    End Property

    Public ReadOnly Property SaldoMN() As Decimal
        Get
            Return importeTotal - PagoSumaMN.GetValueOrDefault
        End Get
    End Property

    Public ReadOnly Property SaldoME() As Decimal
        Get
            Return importeUS - PagoSumaME.GetValueOrDefault
        End Get
    End Property


    Public Property tipocosto() As String
    Public Property idCosto() As Integer?


    Public Property montocrono() As Decimal
    Public Property montocronome() As Decimal
    Public Property montovencido() As Decimal
    Public Property montovencidome() As Decimal
    Public Property ImportePagoVencidoMN() As Decimal
    Public Property ImportePagoVencidoME() As Decimal

    'Public Class CuentasPorPagar

    Public Property PagoNotaCreditoMN() As Decimal?
    Public Property PagoNotaCreditoME() As Decimal?
    Public Property PagoNotaDebitoMN() As Decimal?
    Public Property PagoNotaDebitoME() As Decimal?
    'End Class

    'Informacion general
    Public Property comprasCredito() As Decimal?
    Public Property transferenciaAlmacen() As Decimal?
    Public Property entrdasAlmacen() As Decimal?
    Public Property salidaAlmacen() As Decimal?
    Public Property transferenciaRecepcion() As Decimal?
    Public Property compraTransito() As Decimal?
    Public Property CompraTransitoRecepcion() As Decimal?

    Public ReadOnly Property SaldoComprobanteDocumentoCompraMN() As Decimal
        Get
            Return importeTotal - PagoSumaMN.GetValueOrDefault - PagoNotaCreditoMN.GetValueOrDefault + PagoNotaDebitoMN.GetValueOrDefault
        End Get
    End Property

    Public ReadOnly Property SaldoComprobanteDocumentoCompraME() As Decimal
        Get
            Return importeUS - PagoSumaME.GetValueOrDefault - PagoNotaCreditoME.GetValueOrDefault + PagoNotaDebitoME.GetValueOrDefault
        End Get
    End Property

    Public Property StatusEntregaProductosTransito As String

    Public Property tipoConsulta As String
End Class
