Partial Public Class PlantillaDetalle
    Inherits BaseBE

    Private custom_concepto As Concepto
    Public Property CustomConcepto() As Concepto
        Get
            Return custom_concepto
        End Get
        Set(ByVal value As Concepto)
            custom_concepto = value
        End Set
    End Property

End Class
