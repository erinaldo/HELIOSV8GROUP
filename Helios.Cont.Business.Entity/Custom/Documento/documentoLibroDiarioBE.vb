Partial Public Class documentoLibroDiario
    Inherits BaseBE

    Public Property TipoConfiguracion() As String
    Public Property IdNumeracion() As Integer

    Public Property CustomAsiento As New asiento
    Public Property serie() As String
    Public Property AsientoNotificado() As String

    Public Property montoIgv() As Decimal
    Public Property montoFacturado() As Decimal
    Public Property montoPago() As Decimal
End Class
