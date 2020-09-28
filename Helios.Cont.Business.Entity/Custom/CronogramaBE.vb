Public Class Cronograma
    Inherits BaseBE

    Public Property EstadoPago() As String
    Public Property PagosMN() As Decimal?
    Public Property serie() As String
    Public Property nrodoc() As String
    Public Property CustomConfiguracionPagos As List(Of estadosFinancierosConfiguracionPagos)

    Public ReadOnly Property GetBoolEstado() As Boolean
        Get
            If estado = "1" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property GetSaldoMN() As Decimal?
        Get
            Return montoAutorizadoMN - PagosMN.GetValueOrDefault
        End Get
    End Property

    Public Property GetSaldoPendiente As Decimal?


End Class
