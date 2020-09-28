Partial Public Class Personal
    Inherits BaseBE


    Public ReadOnly Property FullName() As String
        Get
            Return String.Format("{0} {1} {2}", ApellidoPaterno, ApellidoMaterno, Nombre)
        End Get
    End Property

End Class