Public Class OrdernarDatosComplentarias
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerTotalNombre(ByVal totalItem As String) As String
        Dim delimitado() As String = totalItem.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerTotalNroCuentaSoles(ByVal CuentaSoles As String) As String
        Dim delimitado() As String = CuentaSoles.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerTotalNroCuentaSoles2(ByVal CuentaSoles2 As String) As String
        Dim delimitado() As String = CuentaSoles2.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerTotalNroCuentaDolares(ByVal CuentaDolares As String) As String
        Dim delimitado() As String = CuentaDolares.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function ObtenerTotalNroCuentaDolares2(ByVal CuentaDolares2 As String) As String
        Dim delimitado() As String = CuentaDolares2.Split(delimitador)
        Return delimitado(4)
    End Function

    Public Function ObtenerTotalDescripcion(ByVal DescripcionComplementaria As String) As String
        Dim delimitado() As String = DescripcionComplementaria.Split(delimitador)
        Return delimitado(5)
    End Function

    Public Function GenerarTotal(ByVal totalName As String, ByVal CuentaSoles As String, ByVal CuentaSoles2 As String, ByVal CuentaDolares As String, ByVal CuentaDolares2 As String, ByVal DescripcionComplementaria As String) As String
        GenerarTotal = totalName + delimitador(0) + CuentaSoles + delimitador(0) + CuentaSoles2 + delimitador(0) + CuentaDolares + delimitador(0) + CuentaDolares2 + delimitador(0) + DescripcionComplementaria
    End Function
End Class
