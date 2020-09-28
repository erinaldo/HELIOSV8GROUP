Public Class ListadoVentas

    Public Sub New()

    End Sub

    Public Property ListadoProductos As List(Of ListadoVentas)

    Public Property DestinoGravado() As String
    Public Property IdItem() As Integer
    Public Property DescripcionItem() As String
    Public Property UnidadMedida() As String
    Public Property IdPresentacion() As String
    Public Property NombrePresentacion() As String
    Public Property Cantidad() As Decimal
    Public Property PuKardexMN() As Decimal
    Public Property PuKardexME() As Decimal
    Public Property ImporteMN() As Decimal
    Public Property ImporteME() As Decimal
    Public Property PrecioVentaMenorMN() As Decimal
    Public Property PrecioVentaMenorME() As Decimal
    Public Property PrecioVentaMayorMN() As Decimal
    Public Property PrecioVentaMayorME() As Decimal
    Public Property PrecioVentaGMayorMN() As Decimal
    Public Property PrecioVentaGMayorME() As Decimal
End Class
