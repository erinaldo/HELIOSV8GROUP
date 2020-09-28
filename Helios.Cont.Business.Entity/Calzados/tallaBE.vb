Partial Public Class talla
    Inherits BaseBE

    Public ReadOnly Property GetInfo() As String
        Get
            Return $"Talla {Id}"
        End Get
    End Property

    Public ReadOnly Property GetNameGenero() As String

        Get
            GetNameGenero = String.Empty
            Select Case genero
                Case "V"
                    GetNameGenero = "Hombre"
                Case "M"
                    GetNameGenero = "Mujer"
                Case "N"
                    GetNameGenero = "Niños"
                Case "I"
                    GetNameGenero = "Infantes"
            End Select
        End Get

    End Property

    '  Public Property CustomRecursoCostoLoteTallaList As List(Of recursoCostoLoteTalla)


End Class
