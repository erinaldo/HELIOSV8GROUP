Partial Public Class documentoCaja
    Inherits BaseBE

    Public Property IDformapago As String
    Public Property formaPagoName As String
    Public Property ListaIDCajas As New List(Of Integer)
    Public Property establecimientoComprobante() As Integer
    Public Property EntradaDineroEspecial As Decimal?

    Public Property IdProveedor() As Integer
    Public Property NombreEntidad() As String
    Public Property NombreCaja() As String
    Public Property Comprobante() As String
    Public Property SerieCompra() As String
    Public Property numeroCompra() As String
    Public Property tipoDocCompra() As String
    Public Property monedaCompra() As String

    Public Property monedaCaja() As String
    Public Property NombreOperacion() As String
    Public Property cuentaCosteo() As String
    Public Property dni() As String
    Public Property tipousuario() As String

    Public Property TipoDocumentoPago() As String
    Public Property NumeroDocumento() As String

    Public Property DeudaEvalMN() As Decimal
    Public Property DeudaEvalME() As Decimal

    Public Property NomCajaOrigen() As String
    Public Property NomCajaDestino() As String

    Public Property montoMNSalida() As Decimal
    Public Property montoMESalida() As Decimal

    Public Property saldoMN() As Decimal
    Public Property saldoME() As Decimal

    Public Property MontoIngresosMN() As Decimal
    Public Property MontoIngresosME() As Decimal

    Public Property MontoEgresosMN() As Decimal
    Public Property MontoEgresosME() As Decimal
    Public Property DetalleItem() As String
    Public Property IdEntidadFinanciera() As Integer
    Public Property difTipoCambio() As Decimal

    Public Property montoSolesTransacc() As Decimal
    Public Property montoUsdTransacc() As Decimal

    Public Property ImporteDesembolsado() As Decimal?
    Public Property ImporteDesembolsadoME() As Decimal?
    Public Property NomCortoEmpresa() As String
    Public Property NomCortoEstablecimiento() As String

    Public Property idEstado() As Integer
    Public Property codigo() As Integer
    Public Property tipo() As String

    'Informe general
    Public Property Aporte() As Decimal?
    Public Property otrasEntradas() As Decimal?
    Public Property otrasSalidas() As Decimal?
    Public Property anticiposOtorgados() As Decimal?
    Public Property anticiposRecibidos() As Decimal?
    Public Property ticket() As Decimal?
    Public Property cuentasXPagar() As Decimal?
    Public Property ventaPost() As Decimal?
    Public Property ventaContado() As Decimal?
    Public Property cuentasXcobrar() As Decimal?
    Public Property transferenciaRecibido() As Decimal?
    Public Property notaVenta() As Decimal?
    Public Property transferenciaOtorgado() As Decimal?

    Public Property nombreCosto() As String
    Public Property tipoCosto() As String
    Public Property VentaHeredadaMN() As Decimal?
    Public Property VentaElectronicas() As Decimal?

    Public Property TotalEgresos() As Decimal?
    Public Property TotalIngresos() As Decimal?
End Class
