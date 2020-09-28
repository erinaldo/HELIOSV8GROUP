Partial Public Class documentocompradetalle
    Inherits BaseBE

    Public ReadOnly Property GetBonificion As Boolean
        Get
            If bonificacion = "S" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Property CantVenta As Decimal?
    Public Property cantNC As Decimal
    Public Property igvNC As Decimal
    Public Property igvNCME As Decimal

    Public Property biNC As Decimal
    Public Property biNCME As Decimal
    Public Property montoNC As Decimal
    Public Property montoNCME As Decimal

    Public Property IgvDevolucionmn As Decimal?
    Public Property BiDevolucionmn As Decimal?
    Public Property salidaCostoMN As Decimal?
    Public Property salidaCostoME As Decimal?
    Public Property montoDevuelto As Decimal
    Public Property montoDevueltome As Decimal

    Public Property CustomListaDocumentoGuia As List(Of documento)
    Public Property CustomProducto As detalleitems
    Public Property CustomProducto_equivalencia As detalleitem_equivalencias


    Public Property DescripcionArticulo2() As String
    Public Property montokardexDB() As Decimal
    Public Property montokardexDBUS() As Decimal

    Public Property TipoRegistro() As String
    Public Property IdEmpresa() As String
    Public Property IdEstablecimiento() As Integer
    Public Property Glosa() As String
    Public Property tipoCompra() As String

    Public Property motivoCosto() As String

    Public Property CuentaItem() As String
    Public Property DetalleItem() As String
    Public Property FechaDoc() As DateTime?
    Public Property FechaVcto() As DateTime?

    Public Property CuentaProvedor() As String
    Public Property NombreProveedor() As String

    Public Property NumDoc() As String
    Public Property Serie() As String
    Public Property TipoDoc() As String

    Public Property Moneda() As String
    Public Property TipoOperacion() As String
    Public Property idEntidad() As Integer

    Public Property Editable() As String
    ''' <summary>
    ''' Importe nota de debito moneda nacional
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImporteDBMN() As Decimal

    ''' <summary>
    ''' Importe nota de debito moneda extranjera
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImporteDBME() As Decimal

    Public Property porcUtimenor() As Decimal
    Public Property porcUtimayor() As Decimal
    Public Property porcUtigranMayor() As Decimal
    Public Property FlagBonif() As String
    Public Property FlagModificaPrecioVenta() As String
    Public Property marcaRef() As String

    Public Property ImporteDevolucionmn() As Decimal?
    Public Property ImporteDevolucionme() As Decimal?

    Public Property saldoVentaMN() As Decimal
    Public Property saldoVentaME() As Decimal
    Public Property TieneExcedente() As Boolean

    Public Property ImporteAJmn() As Decimal
    Public Property ImporteAJme() As Decimal

    Public Property NomAlmacen() As String
    Public Property CantidadDisponible() As String
    Public Property NumNotas() As Integer
    Public Property NumPagos() As Integer
    Public Property UltimaVenta() As DateTime?

    Public Property montoCompesacion() As Decimal
    Public Property montoCompesacionme() As Decimal

    Public Property DineroDevuelto() As Decimal
    Public Property DineroDevueltome() As Decimal

    Public Property CodigoCosto() As String
    Public Property produccion() As String
    Public Property EstadoCosto() As String
    Public Property Inicio() As Date?
    Public Property Finaliza() As Date?
    Public Property Status() As String
    Public Property tipoCambio() As Decimal

    Public Property CantMaxima() As Double
    Public Property CantMinima() As Double


    Public Property GuiaCantidad() As Decimal
    Public Property GuiaMontoMN() As Decimal
    Public Property GuiaMontoME() As Decimal

    Public Property PorcIva() As Decimal
    Public Property idProceso() As Integer
    Public Property idProyecto As Integer
    Public Property SecuenciaCosto() As Integer

    Public Property secuenciaOrigen() As Integer
    Public Property NombreProyectoGeneral() As String

    Public Property FechaLaboral() As DateTime

    Public ReadOnly Property SaldoCantidad() As Decimal
        Get
            Return monto1 - GuiaCantidad
        End Get
    End Property

    Public ReadOnly Property SaldoMontoMN() As Decimal
        Get
            If destino = 1 Then
                Return montokardex.GetValueOrDefault - GuiaMontoMN
            Else
                Return importe.GetValueOrDefault - GuiaMontoMN
            End If
        End Get
    End Property

    Public ReadOnly Property SaldoMontoME() As Decimal
        Get
            If destino = 1 Then
                Return montokardexUS.GetValueOrDefault - GuiaMontoME
            Else
                Return importe.GetValueOrDefault - GuiaMontoME
            End If
        End Get
    End Property
    Public Property CustomDocumentoCaja As List(Of documentoCaja)
    Public Property CustomPrecios As List(Of configuracionPrecioProducto)
    Public Property CustomRecursoCostoLote As recursoCostoLote
    Public Property CustomInventarioMovimiento As InventarioMovimiento
    Public Property CustomListaInventarioMovimiento As List(Of InventarioMovimiento)
    Public Property puntoLlegada As String
    Public Property observaciones As String
    Public Property ubigeo As String
    Public Property nombreRecepcion As String
    Public Property dniRecepcion As String


    Public Property PagoSumaMN() As Decimal?
    Public Property PagoSumaME() As Decimal?

    Public ReadOnly Property EstadoPagos() As String
        Get
            If MontoSaldo <= 0 Then
                Return "PG"
            Else
                Return "PN"
            End If

        End Get
    End Property

    Public ReadOnly Property MontoSaldo() As Decimal
        Get
            Return importe - MontoPago
        End Get
    End Property

    Public ReadOnly Property MontoSaldoME() As Decimal
        Get
            Return importeUS - MontoPagoME
        End Get
    End Property


    Public ReadOnly Property MontoSaldoV2() As Decimal
        Get
            If CustomDocumentoCaja Is Nothing Then
                Return 0
            End If
            Dim PagosDoc = CustomDocumentoCaja.Sum(Function(o) o.montoSoles).GetValueOrDefault
            Dim saldo = importe - PagosDoc

            Return saldo
        End Get
    End Property

    Public ReadOnly Property ItemSaldado() As String
        Get
            Return "PG"
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

    Private _montoPagoME As Decimal
    Public Property MontoPagoME() As Decimal
        Get
            Return _montoPagoME
        End Get
        Set(ByVal value As Decimal)
            _montoPagoME = value
        End Set
    End Property


End Class
