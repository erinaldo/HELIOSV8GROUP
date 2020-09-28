Public Class OrdenarElementoFacturaTicket
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerCantidad(ByVal cantidad As String) As String
        Dim delimitado() As String = cantidad.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerDescripcion(ByVal Descripcion As String) As String
        Dim delimitado() As String = Descripcion.Split(delimitador)
        Return delimitado(1)
    End Function


    Public Function ObtenerUM(ByVal UM As String) As String
        Dim delimitado() As String = UM.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerPrecioVenta(ByVal PrecioVenta As String) As String
        Dim delimitado() As String = PrecioVenta.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function ObtenerVentaTotal(ByVal VentaTotal As String) As String
        Dim delimitado() As String = VentaTotal.Split(delimitador)
        Return delimitado(4)
    End Function

    Public Function GenerarImprimir(ByVal cantidad As String, ByVal Descripcion As String,
                                                   ByVal UM As String, ByVal PrecioVenta As String, ByVal VentaTotal As String) As String

        GenerarImprimir = cantidad + delimitador(0) + Descripcion + delimitador(0) + UM + delimitador(0) +
                    PrecioVenta + delimitador(0) + VentaTotal
    End Function
End Class
