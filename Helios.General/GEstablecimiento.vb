Public Class GEstablecimiento

    Public Property IdEstablecimiento() As Integer?
    Public Property NombreEstablecimiento() As String
    Public Property TipoEstablecimiento() As String
    Public Property Ubigeo() As String
    Public Property OtrasReferencias() As String

    Private Shared datos As List(Of GEstablecimiento)

    Private Shared objEstablecimiento As GEstablecimiento


    Public Shared Function Instance() As List(Of GEstablecimiento)

        If datos Is Nothing Then
            datos = New List(Of GEstablecimiento)
        End If

        Return datos
    End Function

    Public Shared Function InstanceSingle() As GEstablecimiento

        If objEstablecimiento Is Nothing Then
            objEstablecimiento = New GEstablecimiento
        End If

        Return objEstablecimiento
    End Function

    Public Sub Clear()
        IdEstablecimiento = Nothing
        NombreEstablecimiento = String.Empty
        TipoEstablecimiento = String.Empty
        Ubigeo = String.Empty
        OtrasReferencias = String.Empty
    End Sub
End Class
