Public Class OrdernarEncabezadoFactura
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerNumeroRuc(ByVal Ruc As String) As String
        Dim delimitado() As String = Ruc.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerNumeroFactura(ByVal NumeroComprobante As String) As String
        Dim delimitado() As String = NumeroComprobante.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerTipoComprobante(ByVal TipoComprobante As String) As String
        Dim delimitado() As String = TipoComprobante.Split(delimitador)
        Return delimitado(2)
    End Function



    Public Function GenerarImprimir(ByVal Ruc As String, ByVal NumeroComprobante As String, ByVal tipoComprobante As String) As String
        GenerarImprimir = Ruc + delimitador(0) + NumeroComprobante + delimitador(0) + tipoComprobante
    End Function

End Class
