Partial Public Class item
    Inherits BaseBE


    Private Shared datos As List(Of item)

    Public Property nombrePadre As String

    Public Shared Function Instance() As List(Of item)

        If datos Is Nothing Then
            datos = New List(Of item)
        End If

        Return datos
    End Function

    Public PadreTemportal As String
    Public idEntidad As Integer


    Public serie As String
    Public numero As String
    Public tipoDocumento As String
End Class
