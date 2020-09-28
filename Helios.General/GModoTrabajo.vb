Public Class GModoTrabajo
    Public Property IdActividad() As Integer?
    Public Property NombreActividad() As String
    Public Property Modulo() As String
    Private Shared datos As List(Of GModoTrabajo)
    Private Shared objActividad As GModoTrabajo

    Public Shared Function Instance() As List(Of GModoTrabajo)

        If datos Is Nothing Then
            datos = New List(Of GModoTrabajo)
        End If

        Return datos
    End Function

    Public Shared Function InstanceSingle() As GModoTrabajo

        If objActividad Is Nothing Then
            objActividad = New GModoTrabajo
        End If

        Return objActividad
    End Function

    Public Sub Clear()
        IdActividad = Nothing
        NombreActividad = Nothing
    End Sub
End Class
