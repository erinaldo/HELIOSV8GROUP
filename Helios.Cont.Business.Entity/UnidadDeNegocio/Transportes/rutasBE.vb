Partial Public Class rutas
    Inherits BaseBE

    Public ReadOnly Property GetNameLarge() As String
        Get
            Return $"{ciudadOrigen}-{ciudadDestino}"
        End Get
    End Property

    Public Property CustomRuta_horarios As ruta_horarios

    Public Property ListaSubRutas As List(Of rutas)

End Class


