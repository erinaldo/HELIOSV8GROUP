
Public Class UsuarioLogin

    Public Property Nombre() As Integer?
    Public Property Appat() As String
    Public Property Apmat() As String
    Public Property TipoDoc() As String
    Public Property NumeroDocumento() As String

    Private Shared datos As List(Of UsuarioLogin)
    Private Shared objUsuarioLogin As UsuarioLogin

    Public Shared Function Instance() As List(Of UsuarioLogin)

        If datos Is Nothing Then
            datos = New List(Of UsuarioLogin)
        End If

        Return datos
    End Function

    Public Shared Function InstanceSingle() As UsuarioLogin

        If objUsuarioLogin Is Nothing Then
            objUsuarioLogin = New UsuarioLogin
        End If

        Return objUsuarioLogin
    End Function

    Public Sub Clear()
        Nombre = Nothing
        Appat = String.Empty
        Apmat = String.Empty
        TipoDoc = String.Empty
        NumeroDocumento = String.Empty
    End Sub

End Class
