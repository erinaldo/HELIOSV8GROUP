Public Class distribucionInfraestructura
    Inherits BaseBE

    Public Property NombreBloque As String
    Public Property NombreSector As String
    Public Property NombrePiso As String
    Public Property unidadMedida As String
    Public Property TipoExistencia As String
    Public Property menor As Decimal?
    Public Property mayor As Decimal?
    Public Property gMayor As Decimal?
    Public Property menorME As Decimal?
    Public Property mayorME As Decimal?
    Public Property gMayorME As Decimal?
    Public Property Codigo As Integer

    Public Property Categoria As String

    Public Property SubCategoria As String

    Public Property conteoPrecioMenor As Decimal

    Public Property listaEstado As List(Of String)

    Public Property idDocumento As Integer

    Public Property secuencia As Integer

    Public Property ctaXCobrar As Decimal

    Public Property conteoHabitaciones As Integer
    Public Property conteoHospedados As Integer
    Public Property conteoPedidoPendiente As Integer
    Public Property importeVentaTotal As Decimal
    Public Property VentaCredito As Decimal
    Public Property VentaTotal As Decimal
    Public Property VentaXCtasXCobrar As Decimal

    Public Property AnticiposRecibidos As Decimal

    Public Property Reclamaciones As Decimal

    Public Property Devolucion As Decimal

    Public Property InfraestructuraUpdate As Integer


End Class
