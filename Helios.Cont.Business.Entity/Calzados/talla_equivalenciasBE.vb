Partial Public Class talla_equivalencias
    Inherits BaseBE

    Public ReadOnly Property GetInfo() As String
        Get
            Return $"Talla {id_equivalencia}"
        End Get
    End Property

End Class
