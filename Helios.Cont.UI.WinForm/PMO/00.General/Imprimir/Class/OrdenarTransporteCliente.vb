Public Class OrdenarTransporteCliente
    Public delimitador() As Char = "^"

    Public Sub OrdernarVendedor(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerNumeroBoleta(ByVal NumeroBoleta As String) As String
        Dim delimitado() As String = NumeroBoleta.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerFechaViaje(ByVal fechaViaje As String) As String
        Dim delimitado() As String = fechaViaje.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerHoraViaje(ByVal horaViaje As String) As String
        Dim delimitado() As String = horaViaje.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerOrigen(ByVal origen As String) As String
        Dim delimitado() As String = origen.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function ObtenerDestino(ByVal destino As String) As String
        Dim delimitado() As String = destino.Split(delimitador)
        Return delimitado(4)
    End Function

    Public Function Obtenerasiento(ByVal asiento As String) As String
        Dim delimitado() As String = asiento.Split(delimitador)
        Return delimitado(5)
    End Function

    Public Function ObtenerImporte(ByVal importe As String) As String
        Dim delimitado() As String = importe.Split(delimitador)
        Return delimitado(6)
    End Function

    Public Function ObtenerPiso(ByVal piso As String) As String
        Dim delimitado() As String = piso.Split(delimitador)
        Return delimitado(7)
    End Function


    Public Function GenerarTotal(ByVal NumeroBoleta As String, ByVal fechaViaje As String, ByVal ObtenerHoraViaje As String, ByVal origen As String, ByVal destino As String, ByVal asiento As String, ByVal importe As String, ByVal piso As String) As String
        GenerarTotal = NumeroBoleta + delimitador(0) + fechaViaje + delimitador(0) + ObtenerHoraViaje + delimitador(0) + origen + delimitador(0) + destino + delimitador(0) + asiento + delimitador(0) + importe + delimitador(0) + piso
    End Function
End Class
