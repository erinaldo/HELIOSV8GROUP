Public Class Range
    'Public Sub New(ByVal Desde As T, ByVal Hasta As T)
    '    If Desde.CompareTo(Hasta) > 0 Then Throw New ArgumentException("From should not be greater than To")
    '    Desde = Desde
    '    Hasta = Hasta

    'End Sub

    Public Sub New(ByVal Desde As DateTime, ByVal Hasta As DateTime)
        FechaDesde = Desde
        FechaHasta = Hasta
    End Sub

    'Public Property Desde As T
    'Public Property Hasta As T

    Public Property FechaDesde As Date
    Public Property FechaHasta As Date

    'Public Function Contains(ByVal value As T) As Boolean
    '    Return value.CompareTo(Desde) >= 0 AndAlso value.CompareTo(Hasta) <= 0
    'End Function
    Public Function ContainsDate(ByVal value As DateTime) As Boolean
        Return value.CompareTo(FechaDesde) >= 0 AndAlso value.CompareTo(FechaHasta) <= 0
    End Function
End Class