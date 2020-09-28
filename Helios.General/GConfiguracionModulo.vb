Public Class GConfiguracionModulo

    Private Shared datos As List(Of GConfiguracionModulo)
    Private Shared objConfiguracion As GConfiguracionModulo

    Public Property IdModulo() As String
    Public Property NomModulo() As String
    Public Property ConfigComprobante() As Integer?
    Public Property TipoComprobante() As String
    Public Property TipoConfiguracion() As String
    Public Property NombreComprobante() As String
    Public Property Serie() As String
    Public Property ValorActual() As Integer?

    Public Property IdAlmacen() As Integer?
    Public Property NombreAlmacen() As String

    Public Property IDCaja() As Integer?
    Public Property NomCaja() As String

    Public Property EncargadoCaja() As String


    Public Shared Function Instance() As List(Of GConfiguracionModulo)

        If datos Is Nothing Then
            datos = New List(Of GConfiguracionModulo)
        End If

        Return datos
    End Function

    Public Shared Function InstanceSingle() As GConfiguracionModulo

        If objConfiguracion Is Nothing Then
            objConfiguracion = New GConfiguracionModulo
        End If

        Return objConfiguracion
    End Function

    Public Sub Clear()
        IdModulo = String.Empty
        NomModulo = String.Empty
        ConfigComprobante = Nothing
        TipoComprobante = String.Empty
        TipoConfiguracion = String.Empty
        NombreComprobante = String.Empty
        Serie = String.Empty
        ValorActual = Nothing
        IdAlmacen = Nothing
        NombreAlmacen = String.Empty
        IDCaja = Nothing
        NomCaja = String.Empty
        EncargadoCaja = String.Empty
    End Sub

End Class
