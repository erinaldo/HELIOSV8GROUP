Public Class OrdernarFirmasEncomiendas
    Public delimitador() As Char = "^"

    Public Sub OrdernarVendedor(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerAdministracion(ByVal Administracion As String) As String
        Dim delimitado() As String = Administracion.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerTotalChofer(ByVal TotalChofer As String) As String
        Dim delimitado() As String = TotalChofer.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerTotalConforme(ByVal Conforme As String) As String
        Dim delimitado() As String = Conforme.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function GenerarTotal(ByVal Administracion As String, ByVal TotalChofer As String, ByVal Conforme As String) As String
        GenerarTotal = Administracion + delimitador(0) + TotalChofer + delimitador(0) + Conforme
    End Function

End Class
