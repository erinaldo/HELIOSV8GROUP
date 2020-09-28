Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class AsientosW

    Private Shared datos As List(Of AsientosW)
    Private Shared objEmpresa As AsientosW

    Public Shared Function Instance() As List(Of AsientosW)

        If datos Is Nothing Then
            datos = New List(Of AsientosW)
        End If

        Return datos
    End Function

    Public Property IdAsiento() As String
    Public Property NombreAsiento() As String


    Public Class MovimientoW
        Public Property IdAsiento() As String
        Public Property Cuenta() As String
        Public Property Descripcion() As String
        Public Property TipoAsiento() As ASIENTO_CONTABLE.UBICACION
        Public Property ImporteMN() As Decimal
        Public Property ImporteME() As Decimal
    End Class

End Class
