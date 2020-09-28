Public Class OrdenarElementos
    Public delimitador() As Char = "   "

    Public Sub OrdenarElementos(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerCantidadDeElementos(ByVal orderItem As String) As String
        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(CStr(0))
    End Function

    Public Function ObtenerNombreElemento(ByVal orderItem As String) As String
        Dim delimitado() As String = orderItem.Split(delimitador)
        Dim concatenar As String = String.Empty
        Dim numerqacion As Integer = 0
        For Each item In delimitado
            If (numerqacion = 4) Then
                concatenar = item
            ElseIf (numerqacion > 4) Then
                concatenar = concatenar + " " + item
            End If
            numerqacion = numerqacion + 1
        Next
        Return concatenar
    End Function

    Public Function ObtenerUMElemento(ByVal orderItem As String) As String
        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerprecioUnitElemento(ByVal orderItem As String) As String
        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerPrecioElemento(ByVal orderItem As String) As String
        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function GenerarElemento(ByVal cantidad As String, ByVal UM As String, ByVal precioUnit As String, ByVal Precio As String, ByVal nombreArticulo As String) As String
        Return cantidad + delimitador(0) + UM + delimitador(0) + precioUnit + delimitador(0) + Precio + delimitador(0) + nombreArticulo
    End Function

    Public Function GenerarNombreElemento(ByVal NombreElemento As String) As String
        Return NombreElemento + delimitador(0)
    End Function
End Class
