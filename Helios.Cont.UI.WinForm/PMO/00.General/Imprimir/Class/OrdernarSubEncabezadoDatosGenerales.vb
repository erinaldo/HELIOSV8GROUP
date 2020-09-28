Public Class OrdernarSubEncabezadoDatosGenerales
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function OrdernarfechaEmision(ByVal fechaEmision As String) As String
        Dim delimitado() As String = fechaEmision.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerLugar(ByVal Lugar As String) As String
        Dim delimitado() As String = Lugar.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerNombre(ByVal Nombre As String) As String
        Dim delimitado() As String = Nombre.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function Obtenerdireccion(ByVal direccion As String) As String
        Dim delimitado() As String = direccion.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function ObtenerdireccionEntrega(ByVal direccionEntrega As String) As String
        Dim delimitado() As String = direccionEntrega.Split(delimitador)
        Return delimitado(4)
    End Function

    Public Function ObtenerdocIdentidad(ByVal docIdentidad As String) As String
        Dim delimitado() As String = docIdentidad.Split(delimitador)
        Return delimitado(5)
    End Function

    Public Function Obtenermoneda(ByVal moneda As String) As String
        Dim delimitado() As String = moneda.Split(delimitador)
        Return delimitado(6)
    End Function

    Public Function ObtenerTelefono(ByVal telefono As String) As String
        Dim delimitado() As String = telefono.Split(delimitador)
        Return delimitado(7)
    End Function

    Public Function GenerarImprimir(ByVal fechaEmisiom As String, ByVal Lugar As String,
                                                   ByVal Nombre As String, ByVal direccion As String,
                                                  ByVal direccionEntrega As String, ByVal docIdentidad As String,
                                                  ByVal moneda As String, ByVal telefono As String) As String
        GenerarImprimir = fechaEmisiom + delimitador(0) + Lugar + delimitador(0) + Nombre + delimitador(0) + direccion + delimitador(0) +
            direccionEntrega + delimitador(0) + docIdentidad + delimitador(0) + moneda + delimitador(0) + telefono
    End Function
End Class
