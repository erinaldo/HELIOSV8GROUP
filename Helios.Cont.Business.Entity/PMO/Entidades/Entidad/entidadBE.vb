Partial Public Class entidad
    Inherits BaseBE

    Public Property moneda() As String
    Public Property tipoCambio() As Decimal
    Public Property ImporteMN() As Decimal
    Public Property ImporteME() As Decimal
    Public Property EnvioPlanilla() As Boolean
    Public Property EnvioEntidades() As Boolean
    Public Property DireccionSeleccionada() As String

    Public Property Ubigeo() As String
    Public Property TipoVia() As String
    Public Property Via() As String

    Public Property listaDistribucion() As String
    Public Property clienteActivo() As Integer
    Public Property totalVEntas() As Integer

    Public Property tipoConsulta() As String

End Class
