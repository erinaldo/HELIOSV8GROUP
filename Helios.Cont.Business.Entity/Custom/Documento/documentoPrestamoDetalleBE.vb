Partial Public Class documentoPrestamoDetalle
    Inherits BaseBE

    Public Property referencia() As String
    Public Property PagadoMonto() As Decimal
    Public Property PagadoMontoME() As Decimal
    Public Property DeudaMonto() As Decimal
    Public Property DeudaMontoME() As Decimal

    Public Property tipoBeneficiario() As String
    Public Property idBeneficiario() As Integer
    Public Property moneda() As String
    Public Property montoprestamo() As Decimal
    Public Property montoprestamome() As Decimal
    Public Property numcuotas() As Decimal
    Public Property modopago() As String
    Public Property fechainicio() As Date
    Public Property tipoprestamo() As String
End Class
