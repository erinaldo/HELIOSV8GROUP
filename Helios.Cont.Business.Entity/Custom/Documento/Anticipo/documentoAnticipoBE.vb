Partial Public Class documentoAnticipo
    Inherits BaseBE

    Public Property CustomEntidad As entidad

    Public Property NombreEntidad() As String
    Public Property TipoConfiguracion() As String
    Public Property IdNumeracion() As Integer
    Public Property NombreEstadoFinanciero() As String

    Public Property MontoPagadoSoles() As Decimal
    Public Property MontoPagadoUSD() As Decimal

    Public Property MontoDeudaSoles() As Decimal
    Public Property MontoDeudaUSD() As Decimal

    Public Property formaPago() As String

    Public Property conteoCuotas() As Integer
    Public Property TotalNotas() As Decimal?
    Public Property ConteoNota() As Integer

    Public ReadOnly Property Saldo() As Decimal?
        Get
            Return importeMN - MontoPagadoSoles
        End Get
    End Property

    Public ReadOnly Property SaldoReclamacion() As Decimal?
        Get
            Return importeMN - TotalNotas
        End Get
    End Property

    'Public ReadOnly Property SaldoReclamacionDetail() As String
    '    Get
    '        If SaldoReclamacion <= 0 Then
    '            SaldoReclamacionDetail = ""
    '        End If
    '    End Get
    'End Property

    Public ReadOnly Property EstadoName() As String
        Get
            Select Case estado
                Case "PN"
                    EstadoName = "Pendiente"
                Case Else
                    EstadoName = "Cobrado"
            End Select
        End Get
    End Property
End Class
