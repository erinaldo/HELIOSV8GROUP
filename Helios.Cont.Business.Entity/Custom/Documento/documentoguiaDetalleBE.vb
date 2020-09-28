Partial Public Class documentoguiaDetalle
    Inherits BaseBE

    Public Property NombreAlmacen() As String
    Public Property NombreEstablecimiento As String
    Public Property Serie() As String
    Public Property Numero() As String
    Public Property TipoRegistro As String
    Public Property pendiente As Integer
    Public Property cantConforme As Integer
    Public Property fecha As Date
    Public Property tipodoc As String
    Public Property numerodoc As String
    Public Property ImporteTotal As Decimal
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Integer
    Public Property cantPendiente As Integer
    Public Property codigoLote As Integer

    Public Property AfectoInventario As Boolean

    Public Property CustomInventarioTransito As inventarioTransito
End Class
