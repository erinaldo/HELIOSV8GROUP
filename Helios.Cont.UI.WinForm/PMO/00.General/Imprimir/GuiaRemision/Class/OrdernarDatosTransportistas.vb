Public Class OrdernarDatosTransportistas
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerNroPLaca(ByVal NroPLaca As String) As String
        Dim delimitado() As String = NroPLaca.Split(delimitador)
        Return delimitado(0)
    End Function


    Public Function GenerarTotal(ByVal NroPLaca As String) As String
        GenerarTotal = NroPLaca
    End Function
End Class
