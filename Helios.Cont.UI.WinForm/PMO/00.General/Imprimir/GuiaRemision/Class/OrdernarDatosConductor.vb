Public Class OrdernarDatosConductor
    Public delimitador() As Char = "^"

    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerTipoDoc(ByVal TipoDoc As String) As String
        Dim delimitado() As String = TipoDoc.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerNroDoc(ByVal NroDoc As String) As String
        Dim delimitado() As String = NroDoc.Split(delimitador)
        Return delimitado(1)
    End Function


    Public Function GenerarTotal(ByVal TipoDoc As String, ByVal NroDoc As String) As String
        GenerarTotal = TipoDoc + delimitador(0) + NroDoc
    End Function

End Class
