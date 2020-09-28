Partial Public Class estadosFinancierosConfiguracionPagos
    Inherits BaseBE

    Public Property CodigoAlfa As String

    Public Property TipoEF As String
    Public Property FormaPago As String
    Public Property IDFormaPago As String

    Public Property IDCaja As Integer

    Public Property MontoCaja As Decimal
    Public Property MontoCajaME As Decimal

    Public Property MontoAbonado As Decimal?

    Public Property NumeroOperacion() As String
End Class
