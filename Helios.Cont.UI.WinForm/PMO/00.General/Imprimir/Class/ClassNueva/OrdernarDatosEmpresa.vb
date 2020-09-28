Public Class OrdernarDatosEmpresa
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerRazonSocial(ByVal razonSocial As String) As String
        Dim delimitado() As String = razonSocial.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerNombreComercial(ByVal NombreComercial As String) As String
        Dim delimitado() As String = NombreComercial.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerDireccionPrincipal(ByVal DireccionPrincipal As String) As String
        Dim delimitado() As String = DireccionPrincipal.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerDireccionAnexo(ByVal DireccionAnexo As String) As String
        Dim delimitado() As String = DireccionAnexo.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function ObtenerTelefono(ByVal Telefono As String) As String
        Dim delimitado() As String = Telefono.Split(delimitador)
        Return delimitado(4)
    End Function


    Public Function GenerarTotal(ByVal razonSocial As String,
                                 ByVal NombreComercial As String,
                                 ByVal DireccionPrincipal As String,
                                 ByVal DireccionAnexo As String,
                                 ByVal Telefono As String) As String
        GenerarTotal = razonSocial + delimitador(0) +
        NombreComercial + delimitador(0) +
        DireccionPrincipal + delimitador(0) +
        DireccionAnexo + delimitador(0) +
        Telefono
    End Function
End Class
