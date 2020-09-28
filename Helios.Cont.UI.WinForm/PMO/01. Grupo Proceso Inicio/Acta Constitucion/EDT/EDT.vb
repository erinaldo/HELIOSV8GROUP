Public Class EDT

    Private Shared datos As List(Of EDT)
    Private Shared EDTs As EDT

    Public Shared Function Instance() As List(Of EDT)

        If datos Is Nothing Then
            datos = New List(Of EDT)
        End If

        Return datos
    End Function

    Public Shared Function InstanceSingle() As EDT

        If EDTs Is Nothing Then
            EDTs = New EDT
        End If

        Return EDTs
    End Function

    Public Property Id() As Integer
    Public Property Director() As String
    Public Property ConceptoEDT() As String
    Public Property NroEntregable() As String
    Public Property FechaEntrega() As DateTime?
    Public ReadOnly DiasAtraso() As Decimal
    Public Property DescripcionEDT() As String

End Class
