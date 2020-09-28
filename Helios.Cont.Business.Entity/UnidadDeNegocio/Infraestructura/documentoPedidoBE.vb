Public Class documentoPedido
    Inherits BaseBE

    Public Property TipoConfiguracion() As String
    Public Property IdNumeracion() As Integer
    Public Property tipoDocEntidad() As String
    Public Property NroDocEntidad() As String
    Public Property NombreEntidad() As String
    Public Property TipoPersona() As String
    Public Property nombreInfra As String
    Public Property pedidoOrigen As Integer
    Public Property pedidoDestino As Integer
    Public Property ListaEstado As List(Of String)

    Public Property ListaTipoExistencia As List(Of String)
    Public Property ListaTipoVenta As List(Of String)

    Public Property listaIdDistribucion As List(Of String)
    Public Property tipo As String
    Public Property predeterminado As String

    Public Property CustomEntidad As entidad

    Public Property sustentado() As String

    Public Function GetEstadoPagoComprobante() As String
        Dim pagosPendientes = documentoPedidoDet.Where(Function(o) o.estadoPago = "PN").Count
        If pagosPendientes > 0 Then
            Return "PN"
        Else
            Return "DC"
        End If
    End Function

End Class
