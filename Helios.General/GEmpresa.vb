Public Class GEmpresa

    Public Property IDProducto() As String
    Public Property IdEmpresaRuc() As String
    Public Property IDCliente() As String
    Public Property NomEmpresa() As String
    Public Property NomCorto() As String
    Public Property InicioOpeaciones() As String
    Public Property Ruc() As String
    Public Property Regimen() As String
    Public Property direccionEmpresa() As String
    Public Property TelefonoEmpresa() As String

    Public Property departamento() As String
    Public Property provincia() As String
    Public Property distrito() As String
    Public Property ubigeo() As String

    Private Shared datos As List(Of GEmpresa)
    Private Shared objEmpresa As GEmpresa

    Public Shared Function Instance() As List(Of GEmpresa)

        If datos Is Nothing Then
            datos = New List(Of GEmpresa)
        End If

        Return datos
    End Function

    Public Shared Function InstanceSingle() As GEmpresa

        If objEmpresa Is Nothing Then
            objEmpresa = New GEmpresa
        End If

        Return objEmpresa
    End Function

    Public Sub Clear()
        IdEmpresaRuc = String.Empty
        NomCorto = String.Empty
        NomEmpresa = String.Empty
        InicioOpeaciones = String.Empty
    End Sub

End Class
