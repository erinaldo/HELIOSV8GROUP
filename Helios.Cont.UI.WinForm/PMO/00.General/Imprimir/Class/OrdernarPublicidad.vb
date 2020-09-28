Public Class OrdernarPublicidad
    Public delimitador() As Char = "^"

    Public Sub OrdernarEmpresa(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerPublicidad(ByVal totalPublicidad As String) As String
        Dim delimitado() As String = totalPublicidad.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function GenerarTotal(ByVal totalName As String) As String
        GenerarTotal = totalName
    End Function

End Class
