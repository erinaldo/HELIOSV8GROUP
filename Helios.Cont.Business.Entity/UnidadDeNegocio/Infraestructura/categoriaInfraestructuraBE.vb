Public Class categoriaInfraestructura
    Inherits BaseBE

    Private Shared datos As List(Of categoriaInfraestructura)

    Public Shared Function Instance() As List(Of categoriaInfraestructura)

        If datos Is Nothing Then
            datos = New List(Of categoriaInfraestructura)
        End If

        Return datos
    End Function

End Class
