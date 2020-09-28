Public Class GFichaUsuario

    Public Property IdCajaUsuario() As Integer?
    Public Property IdPersona() As Integer
    Public Property NombrePersona() As String

    Public Property IdCajaOrigen() As Integer
    Public Property NomCajaOrigen() As String
    Public Property IdCajaDestino() As Integer
    Public Property NomCajaDestinb() As String
    Public Property IdCajaCierre() As Integer

    Public Property ClaveUsuario() As String
    Public Property FechaApertura() As DateTime?
    Public Property FechaCierre() As DateTime?

    Public Property Moneda() As String
    Public Property FondoMN() As Decimal
    Public Property TipoCambio() As Decimal
    Public Property FondoME() As Decimal
    Public Property EstadoCaja() As String
    Public Property EnUso() As String

    Public Property SaldoMN() As Decimal
    Public Property SaldoME() As Decimal

    Public Property cuentaDestino() As Integer

    Private Shared datos As List(Of GFichaUsuario)
    Private Shared objCajaUsuario As GFichaUsuario

    Public Shared Function Instance() As List(Of GFichaUsuario)

        If datos Is Nothing Then
            datos = New List(Of GFichaUsuario)
        End If

        Return datos
    End Function

    Public Shared Function InstanceSingle() As GFichaUsuario

        If objCajaUsuario Is Nothing Then
            objCajaUsuario = New GFichaUsuario
        End If

        Return objCajaUsuario
    End Function

    Public Sub Clear()
        IdCajaUsuario = Nothing
        IdPersona = Nothing
        NombrePersona = String.Empty
        ClaveUsuario = String.Empty
        IdCajaOrigen = Nothing
        IdCajaDestino = Nothing
        TipoCambio = 0
        Moneda = String.Empty
        FondoMN = 0
        FondoME = 0
        EstadoCaja = String.Empty
        EnUso = String.Empty
    End Sub

End Class
