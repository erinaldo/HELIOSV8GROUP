Public Class OrdernarSubEncabezadoDatosGeneralesTransporte
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

    Public Function ObtenerHabitacion(ByVal habitacion As String) As String
        Dim delimitado() As String = habitacion.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerTipoHabitacion(ByVal TipoHabitacion As String) As String
        Dim delimitado() As String = TipoHabitacion.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function ObtenerFechaIN(ByVal fechaIN As String) As String
        Dim delimitado() As String = fechaIN.Split(delimitador)
        Return delimitado(4)
    End Function

    Public Function ObtenerFechaON(ByVal fechaON As String) As String
        Dim delimitado() As String = fechaON.Split(delimitador)
        Return delimitado(5)
    End Function

    Public Function ObtenerDias(ByVal dias As String) As String
        Dim delimitado() As String = dias.Split(delimitador)
        Return delimitado(6)
    End Function

    Public Function ObtenerNombre(ByVal Nombre As String) As String
        Dim delimitado() As String = Nombre.Split(delimitador)
        Return delimitado(7)
    End Function

    Public Function Obtenerdireccion(ByVal direccion As String) As String
        Dim delimitado() As String = direccion.Split(delimitador)
        Return delimitado(8)
    End Function

    Public Function ObtenerdireccionEntrega(ByVal direccionEntrega As String) As String
        Dim delimitado() As String = direccionEntrega.Split(delimitador)
        Return delimitado(9)
    End Function

    Public Function ObtenerdocIdentidad(ByVal docIdentidad As String) As String
        Dim delimitado() As String = docIdentidad.Split(delimitador)
        Return delimitado(10)
    End Function

    Public Function Obtenermoneda(ByVal moneda As String) As String
        Dim delimitado() As String = moneda.Split(delimitador)
        Return delimitado(11)
    End Function

    Public Function ObtenerTelefono(ByVal telefono As String) As String
        Dim delimitado() As String = telefono.Split(delimitador)
        Return delimitado(12)
    End Function

    Public Function ObtenerConductor(ByVal conductor1 As String) As String
        Dim delimitado() As String = conductor1.Split(delimitador)
        Return delimitado(12)
    End Function

    Public Function ObtenerLicencia(ByVal Licencia As String) As String
        Dim delimitado() As String = Licencia.Split(delimitador)
        Return delimitado(12)
    End Function

    Public Function ObtenerConductor2(ByVal conductor2 As String) As String
        Dim delimitado() As String = conductor2.Split(delimitador)
        Return delimitado(12)
    End Function

    Public Function ObtenerLicencia2(ByVal Licencia2 As String) As String
        Dim delimitado() As String = Licencia2.Split(delimitador)
        Return delimitado(12)
    End Function

    Public Function ObtenerAyudante(ByVal ayudante As String) As String
        Dim delimitado() As String = ayudante.Split(delimitador)
        Return delimitado(12)
    End Function

    Public Function GenerarImprimir(ByVal fechaEmisiom As String, ByVal Lugar As String, ByVal habitacion As String,
                                      ByVal TipoHabitacion As String, ByVal fechaIN As String, ByVal fechaON As String,
                                    ByVal dias As String,
                                                   ByVal Nombre As String, ByVal direccion As String,
                                                  ByVal direccionEntrega As String, ByVal docIdentidad As String,
                                                  ByVal moneda As String, ByVal telefono As String,
                                    ByVal conductor1 As String, ByVal Licencia As String, ByVal conductor2 As String,
                                    ByVal Licencia2 As String, ByVal ayudante As String) As String
        GenerarImprimir = fechaEmisiom + delimitador(0) +
                            Lugar + delimitador(0) +
                            habitacion + delimitador(0) +
                            TipoHabitacion + delimitador(0) +
                            fechaIN + delimitador(0) +
                            fechaON + delimitador(0) +
                            dias + delimitador(0) +
                            Nombre + delimitador(0) +
                            direccion + delimitador(0) +
                            direccionEntrega + delimitador(0) +
                            docIdentidad + delimitador(0) +
                            moneda + delimitador(0) +
                            telefono + delimitador(0) +
                              conductor1 + delimitador(0) +
                                Licencia + delimitador(0) +
                                  conductor2 + delimitador(0) +
                                    Licencia2 + delimitador(0) +
                                      ayudante
    End Function


End Class
