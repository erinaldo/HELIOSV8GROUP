Public Class OrdernarDescripcionNota
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerTituloCredito(ByVal TituloCredito As String) As String
        Dim delimitado() As String = TituloCredito.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerDescripcionNota(ByVal DescripcionNota As String) As String
        Dim delimitado() As String = DescripcionNota.Split(delimitador)
        Return delimitado(1)
    End Function


    Public Function GenerarTotal(ByVal TituloCredito As String, ByVal DescripcionNota As String) As String
        GenerarTotal = TituloCredito + delimitador(0) + DescripcionNota
    End Function
End Class
