Partial Public Class documentoventaAbarrotes
    Inherits BaseBE
    Public Property EstadoPagoDevolucion() As String

    Public Property idPSE As String

    Public Property ImporteDevMN() As Decimal?
    Public Property ImporteDevME() As Decimal?
    Public Property SaldoVentaMN() As Decimal?
    Public Property SaldoVentaME() As Decimal?

    Public Property CpePen() As Integer
    Public Property AnuPen() As Integer

    Public Property nombreCliente As String
    Public Property rucCliente As String

    Public Property IgvDevMN() As Decimal?
    Public Property BiDevMN() As Decimal?
    Public Property Bi2DevMN() As Decimal?

    Public Property TipoAfectado As String

    Public Property CountVentas() As Integer
    Public Property TipoDocNumeracion() As String
    'Public Property tipoOperacion() As String
    Public Property tipoDocEntidad() As String
    Public Property NroDocEntidad() As String
    Public Property NombreEntidad() As String
    Public Property TipoPersona() As String
    Public Property nombreEstablecimiento() As String
    Public Property TipoConfiguracion() As String
    Public Property IdNumeracion() As Integer
    Public Property Quantity() As Decimal

    Public Property sustentado() As String
    Public Property conteoCuotas() As Integer?

    Public Property SerieNota() As String
    Public Property NumeroNota() As String
    Public Property TipoDocNota() As String
    Public Property FechaNota() As DateTime

    Public Property Monto30mn() As Decimal
    Public Property Monto30me() As Decimal

    Public Property Monto60mn() As Decimal
    Public Property Monto60me() As Decimal

    Public Property Monto90mn() As Decimal
    Public Property Monto90me() As Decimal

    Public Property Monto90Masmn() As Decimal
    Public Property Monto90Masme() As Decimal

    Public Property PagoSumaMN() As Decimal
    Public Property PagoSumaME() As Decimal
    Public Property CajaSeleccionada() As Integer

    Public Property IdDocumentoCotizacion() As Integer?

    Public Property montocrono() As Decimal
    Public Property montocronome() As Decimal

    Public Property montovencido() As Decimal
    Public Property montovencidome() As Decimal
    Public Property ImportePagoVencidoMN() As Decimal
    Public Property ImportePagoVencidoME() As Decimal

    Public Property PagoNotaCreditoMN() As Decimal
    Public Property PagoNotaCreditoME() As Decimal
    Public Property PagoNotaDebitoMN() As Decimal
    Public Property PagoNotaDebitoME() As Decimal

    Public Property CantFact() As Integer
    Public Property CantBol() As Integer
    Public Property CantNotaFact() As Integer
    Public Property CantNotaBol() As Integer
    Public Property CantFactAnu() As Integer
    Public Property CantBolAnu() As Integer

    'informe general
    Public Property ventaPos() As Decimal
    Public Property ventaPosContado() As Decimal
    Public Property ventaVtag() As Decimal
    Public Property ventaVtaggContado() As Decimal
    Public Property preVenta() As Decimal
    Public Property cuentasXCobrar() As Decimal

    Public Property CustomEntidad As entidad

    Public Property ListaEstado As List(Of String)

    Public Property ListaIdDocumento As List(Of String)

    Public Property idEstablecimientoDestino As Integer
    Public Property idEmpresaDes As String

    Public Function GetEstadoPagoComprobante() As String

        Dim beneficios As New List(Of String)
        beneficios.Add("OFERTA")
        'beneficios.Add("DESCUENTO")

        Dim pagosPendientes = documentoventaAbarrotesDet.Where(Function(o) o.estadoPago = "PN" And o.bonificacion = False And Not beneficios.Contains(o.tipobeneficio)).Count
        If pagosPendientes > 0 Then
            Return "PN"
        Else
            Return "DC"
        End If
    End Function

    Public ReadOnly Property SaldoReclamacion As Decimal?
        Get
            Return ImporteNacional - ImporteDevMN
        End Get
    End Property


End Class
