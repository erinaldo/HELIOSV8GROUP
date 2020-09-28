Public Class OrdenarElementoFacElectronico
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function OptenerRuc(ByVal ruc As String) As String
        Dim delimitado() As String = ruc.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerTipoDoc(ByVal TipoDoc As String) As String
        Dim delimitado() As String = TipoDoc.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerSerie(ByVal serie As String) As String
        Dim delimitado() As String = serie.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function ObtenerNumero(ByVal numero As String) As String
        Dim delimitado() As String = numero.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function GenerarImprimir(ByVal ruc As String, ByVal TipoDoc As String, ByVal serie As String,
                                                   ByVal numero As String) As String
        GenerarImprimir = ruc + delimitador(0) + TipoDoc + delimitador(0) + serie + delimitador(0) + numero
    End Function
End Class
