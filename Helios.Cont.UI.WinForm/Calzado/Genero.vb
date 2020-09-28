Public Class Genero
    Public Property idGenero As String
    Public Property genero As String

    Public ReadOnly Property NameGenero() As String
        Get
            Dim str = ""
            Select Case genero
                Case "V"
                    str = "Hombre"
                Case "M"
                    str = "Mujer"
                Case "N"
                    str = "Niño"
                Case "J"
                    str = "Joven"
            End Select
            Return str
        End Get
    End Property
End Class
