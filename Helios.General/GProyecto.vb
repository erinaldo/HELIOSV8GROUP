Public Class GProyecto
    Public Property IdProyecto() As Integer?
    Public Property IdProyectoActividad() As Integer?
    Public Property NombreProyecto() As String
    Public Property DirectorProyecto() As String
    Public Property NombreDirector() As String
    Public Property FechaInicio() As DateTime?
    Public Property FechaFin() As DateTime?
    Public Property ModoTrabajo() As String
    Public Property IdModoTrabajo() As String
    Public Property IdActividadTrabajo() As String

    Private Shared datos As List(Of GProyecto)
    Private Shared objProyecto As GProyecto

    Public Shared Function Instance() As List(Of GProyecto)

        If datos Is Nothing Then
            datos = New List(Of GProyecto)
        End If

        Return datos
    End Function

    Public Shared Function InstanceSingle() As GProyecto

        If objProyecto Is Nothing Then
            objProyecto = New GProyecto
        End If

        Return objProyecto
    End Function

    Public Sub Clear()
        IdProyecto = Nothing
        IdProyectoActividad = Nothing
        NombreProyecto = Nothing
        DirectorProyecto = Nothing
        NombreDirector = Nothing
        FechaInicio = Nothing
        FechaFin = Nothing
        ModoTrabajo = Nothing
        IdActividadTrabajo = Nothing
    End Sub

End Class
