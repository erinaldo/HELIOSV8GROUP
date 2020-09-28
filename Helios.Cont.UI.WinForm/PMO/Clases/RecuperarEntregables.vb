Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Public Class RecuperarEntregables
    Private Shared datos As List(Of RecuperarEntregables)

    Public Shared Function Instance() As List(Of RecuperarEntregables)

        If datos Is Nothing Then
            datos = New List(Of RecuperarEntregables)
        End If

        Return datos
    End Function

    Public Property idEntregable() As Integer
    Public Property idAlmacen() As Integer
    Public Property nombreAlmacen() As String
    Public Property fechaIncio() As DateTime
    Public Property fechaFin() As DateTime
    Public Property fechaInicioGarantia() As DateTime
    Public Property fechaFinGarantia() As DateTime
    Public Property idItem() As Integer
    Public Property nombreItem() As String
    Public Property cantidad() As Integer
    Public Property notas() As String
    Public Property indicaciones() As String
    Public Property direccionAlmacen() As String
    Public Property objetoContratacion() As String
    Public Property periodoValorizacion() As String
    Public Property penalidades() As String
    Public Property importeMN() As Decimal
    Public Property importeME() As Decimal


End Class
