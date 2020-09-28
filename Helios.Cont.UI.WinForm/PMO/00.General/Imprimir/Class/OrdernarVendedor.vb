Public Class OrdernarVendedor
    Public delimitador() As Char = "^"

    Public Sub OrdernarVendedor(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerTotalVendedor(ByVal totalVendedor As String) As String
        Dim delimitado() As String = totalVendedor.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerTotalDescripción(ByVal TotalDescripcion As String) As String
        Dim delimitado() As String = TotalDescripcion.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerTotalCorreo(ByVal TotalCorreo As String) As String
        Dim delimitado() As String = TotalCorreo.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function GenerarTotal(ByVal totalVendedor As String, ByVal totalDescripcion As String, ByVal totalCorreo As String) As String
        GenerarTotal = totalVendedor + delimitador(0) + totalDescripcion + delimitador(0) + totalCorreo
    End Function

End Class
