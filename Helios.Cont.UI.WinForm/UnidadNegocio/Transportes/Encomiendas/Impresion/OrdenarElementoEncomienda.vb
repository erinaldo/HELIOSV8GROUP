Public Class OrdenarElementoEncomienda
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function OptenerGuia(ByVal numero As String) As String
        Dim delimitado() As String = numero.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function OptenerRemitente(ByVal Remitente As String) As String
        Dim delimitado() As String = Remitente.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerConsignado(ByVal Consignado As String) As String
        Dim delimitado() As String = Consignado.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerCantidad(ByVal cantidad As String) As String
        Dim delimitado() As String = cantidad.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function ObtenerDetalle(ByVal Detalle As String) As String
        Dim delimitado() As String = Detalle.Split(delimitador)
        Return delimitado(4)
    End Function

    Public Function ObtenerTipo(ByVal Tipo As String) As String
        Dim delimitado() As String = Tipo.Split(delimitador)
        Return delimitado(5)
    End Function

    Public Function ObtenerImporte(ByVal Importe As String) As String
        Dim delimitado() As String = Importe.Split(delimitador)
        Return delimitado(6)
    End Function

    Public Function ObtenerFecha(ByVal Fecha As String) As String
        Dim delimitado() As String = Fecha.Split(delimitador)
        Return delimitado(7)
    End Function

    Public Function GenerarImprimir(ByVal numero As String, ByVal Remitente As String, ByVal Consignado As String, ByVal cantidad As String,
                                                   ByVal Detalle As String, ByVal Tipo As String, ByVal Importe As String, ByVal Fecha As String) As String

        GenerarImprimir = numero + delimitador(0) + Remitente + delimitador(0) + Consignado + delimitador(0) + cantidad + delimitador(0) + Detalle + delimitador(0) +
                    Tipo + delimitador(0) + Importe + delimitador(0) + Fecha
    End Function
End Class
