Public Class OrdernarDatosPuntosPartida
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerLlegada(ByVal Llegada As String) As String
        Dim delimitado() As String = Llegada.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerPartida(ByVal Partida As String) As String
        Dim delimitado() As String = Partida.Split(delimitador)
        Return delimitado(1)
    End Function


    Public Function GenerarTotal(ByVal Llegada As String, ByVal Partida As String) As String
        GenerarTotal = Llegada + delimitador(0) + Partida
    End Function
End Class
