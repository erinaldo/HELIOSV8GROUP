Partial Public Class totalesAlmacen
    Inherits BaseBE
    Public Property idCaracteristica As Integer
    Public Property modelo As String
    Public Property CantDetalle() As Integer
    Public Property NombreProveedor() As String
    Public Property Moneda() As String
    Public Property CodigoBarra() As String
    Public Property CustomPrecios As configuracionPrecioProducto
    Public Property CustomLote As recursoCostoLote
    Public Property ArticulosConexos As totalesAlmacen

    Public Property NombreEstablecimiento() As String
    Public Property Marca() As String

    Public Property idDocumento As Integer
    Public Property Clasificicacion() As String
    Public Property Modulo() As String
    Public Property SecuenciaDetalle() As Integer
    Public Property TipoDoc() As String
    Public Property NomAlmacen() As String
    Public Property Presentacion() As String
    Public Property NombrePresentacion() As String

    Public Property CuentaContable() As String

    Public Property tipoConfiguracion() As String
    Public Property precioVentaMN() As Decimal
    Public Property montoDsctounitMenorMN() As Decimal
    Public Property montoDsctounitMenorME() As Decimal
    Public Property precioVentaFinalMenorMN() As Decimal
    Public Property precioVentaFinalMenorME() As Decimal
    Public Property montoDsctounitMayorMN() As Decimal
    Public Property montoDsctounitMayorME() As Decimal
    Public Property precioVentaFinalMayorMN() As Decimal
    Public Property precioVentaFinalMayorME() As Decimal
    Public Property montoDsctounitGMayorMN() As Decimal
    Public Property montoDsctounitGMayorME() As Decimal
    Public Property precioVentaFinalGMayorMN() As Decimal
    Public Property precioVentaFinalGMayorME() As Decimal
    Public Property detalleMenor() As Decimal
    Public Property detalleMayor() As Decimal
    Public Property detalleGMayor() As Decimal

    Public Property nombreempresa() As String

    Public Property FechaUltimoPrecioKardex() As DateTime
    Public Property FechaUltimoPrecioConfigurado() As DateTime

    Public Property TipoAcces() As String
    Public Property idItemPadre() As Integer
    Public Property PMprecioMN() As Decimal
    Public Property PMprecioME() As Decimal
    Public Property fechaLote() As DateTime?
    Public Property NroLote() As String
    Public Property NroEnlaces As Integer?
    Public Property SelecionDirecta() As Boolean
    Public Property InvAcumulado() As Boolean = False
    Public Property CantidadComprada As Decimal?
    Public ReadOnly Property UltimoPMmn() As Decimal
        Get
            If cantidad > 0 Then
                Return importeSoles / cantidad
            Else
                Return 0
            End If

        End Get
    End Property

    Public ReadOnly Property UltimoPMme() As Decimal
        Get
            If cantidad > 0 Then
                Return importeDolares / cantidad
            Else
                Return 0
            End If

        End Get
    End Property

    Private _cantidadUsada As Decimal
    Public Property CantidadUsada() As Decimal
        Get
            Return _cantidadUsada
        End Get
        Set(ByVal value As Decimal)
            _cantidadUsada = value
        End Set
    End Property

    Public ReadOnly Property StockSaldo() As Decimal
        Get
            Return cantidad - CantidadUsada
        End Get
    End Property


    Public Property tipoConsulta As String

End Class
