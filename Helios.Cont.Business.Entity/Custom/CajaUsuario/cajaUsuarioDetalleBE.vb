Partial Public Class cajaUsuariodetalle
    Inherits BaseBE

    Public Property Tipo() As String

    Public ReadOnly Property TipoEF() As String
        Get
            Return IIf(Tipo = "EF", "EFECTIVO", "BANCO")
        End Get
    End Property

    Public Property Movimiento() As String
    Public Property NomEntidad() As String

    Public Property INICIO_MN() As Decimal
    Public Property INICIO_ME() As Decimal

    Public Property TOTAL_MN() As Decimal
    Public Property TOTAL_ME() As Decimal

End Class
