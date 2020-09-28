Partial Public Class estadosFinancieros
    Inherits BaseBE

    Public Property Ingresos() As Decimal?

    Public Property IngresosME() As Decimal?
    Public Property Salidas() As Decimal?
    Public Property SalidasME() As Decimal?
    Public Property NomCortoEmpresa() As String
    Public Property SaldoAnterior() As Decimal?
    Public Property IdCaja() As Integer?
    Public ReadOnly Property SaldoCaja() As Decimal?
        Get
            Return Ingresos.GetValueOrDefault - Salidas.GetValueOrDefault
        End Get

    End Property

    Public ReadOnly Property SaldoCajaCierre() As Decimal?
        Get
            Return SaldoCaja.GetValueOrDefault + SaldoAnterior.GetValueOrDefault
        End Get

    End Property

    Public Property tipoConsulta() As String

End Class
