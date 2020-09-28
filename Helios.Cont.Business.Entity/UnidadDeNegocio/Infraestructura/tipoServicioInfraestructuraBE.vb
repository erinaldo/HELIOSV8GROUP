Public Class tipoServicioInfraestructura
    Inherits BaseBE

    Private Shared datos As List(Of tipoServicioInfraestructura)

    Public Property nombreCategoria As String

    Public Shared Function Instance() As List(Of tipoServicioInfraestructura)

        If datos Is Nothing Then
            datos = New List(Of tipoServicioInfraestructura)
        End If

        Return datos
    End Function

End Class
