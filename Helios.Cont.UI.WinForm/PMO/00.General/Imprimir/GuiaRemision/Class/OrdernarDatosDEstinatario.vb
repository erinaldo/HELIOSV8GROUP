Public Class OrdernarDatosDEstinatario
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerTotalNombre(ByVal nombre As String) As String
        Dim delimitado() As String = nombre.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerDocumento(ByVal documento As String) As String
        Dim delimitado() As String = documento.Split(delimitador)
        Return delimitado(1)
    End Function


    Public Function GenerarTotal(ByVal nombre As String, ByVal documento As String) As String
        GenerarTotal = nombre + delimitador(0) + documento
    End Function


End Class
