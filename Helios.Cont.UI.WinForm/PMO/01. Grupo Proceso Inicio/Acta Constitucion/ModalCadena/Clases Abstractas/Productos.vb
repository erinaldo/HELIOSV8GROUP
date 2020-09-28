Imports System.Collections.Generic
'Imports System.Linq
Imports System.Text
Public Class Productos
    Private Shared datos As List(Of Productos)

    Public Shared Function Instance() As List(Of Productos)

        If datos Is Nothing Then
            datos = New List(Of Productos)
        End If
        Return datos
    End Function

    Public Property m_IdAlmace() As Integer
    Public Property m_TipoExistencia() As String
    Public Property m_Origen() As String
    Public Property m_IdItem() As String
    Public Property m_Descripcion() As String
    Public Property m_UM() As String
    Public Property m_CanDisponible() As Decimal
    Public Property m_PrecioUnit() As Decimal
    Public Property m_MontoMN() As Decimal
    Public Property m_PrecioUnitME() As Decimal
    Public Property m_MontoME() As Decimal
    Public Property m_Cuenta() As String
    Public Property m_Establecimiento() As Integer
    Public Property m_Evento() As String
    Public Property m_PVMN() As Decimal
    Public Property m_PVME() As Decimal
    Public Property m_DsctoMN() As Decimal
    Public Property m_DsctoME() As Decimal
    Public Property m_Presentacion() As String
    Public Property m_FechaVcto() As Nullable(Of DateTime) = Nothing
    Public Property m_NamePresentacion() As String
    Public Property m_Catnidad() As Decimal
    Public Property m_tipoVenta() As String
    Public Property m_DetMenor() As String
    Public Property m_DetMayor() As String
    Public Property m_DetGMayor() As String

End Class
