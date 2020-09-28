Partial Public Class documentoLibroDiarioDetalle
    Inherits BaseBE

   
    Public Property FechaDoc() As DateTime
    'Public Property idCosto() As Integer
    Public Property idProceso() As Integer
    Public Property nroDoc() As String
    Public Property fecha() As Date
    Public Property moneda() As String
    Public Property razonSocial() As Integer
    Public Property informacionReferencial() As String
    Public Property tipoRazon() As String
    Public Property modulo() As String

    Public Property fechaPeriodo() As String
    Public Property numeroDoc() As String
    Public Property tipoDocumento() As String
    Public Property fechaVcto() As Date
    Public Property montocrono() As Decimal
    Public Property montocronome() As Decimal
    Public Property PagoSumaMN() As Decimal
    Public Property PagoSumaME() As Decimal
    Public Property tipoCambio() As Decimal

    Public Property fechaRegistro() As Date
    Public Property operacion() As String
    Public Property procesado() As String
    Public Property recursoCosto() As String
    Public Property cuentaCosto() As String

    Public Property ImportePagoMN() As Decimal
    Public Property ImportePagoME() As Decimal
    Public Property montovencido() As Decimal
    Public Property montovencidome() As Decimal
    Public Property ImportePagoVencidoMN() As Decimal
    Public Property ImportePagoVencidoME() As Decimal
    Public Property NombreRazon() As String
    Public Property conteoCuota() As Integer

End Class
