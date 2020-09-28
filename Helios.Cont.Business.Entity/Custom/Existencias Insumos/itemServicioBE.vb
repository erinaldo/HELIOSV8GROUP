Public Class itemServicio
    Inherits BaseBE

    Private Shared datos As List(Of itemServicio)

    Public Shared Function Instance() As List(Of itemServicio)

        If datos Is Nothing Then
            datos = New List(Of itemServicio)
        End If
        Return datos
    End Function

End Class
