'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class ordenCompras
    Public Property idOrden As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Integer
    Public Property idProyecto As Nullable(Of Integer)
    Public Property idEvento As Nullable(Of Integer)
    Public Property idProceso As Nullable(Of Integer)
    Public Property idTarea As Nullable(Of Integer)
    Public Property tipoOrden As String
    Public Property codigoOrden As String
    Public Property fechaProceso As Nullable(Of Date)
    Public Property periodo As String
    Public Property tipoOperacion As String
    Public Property confirmado As String
    Public Property importeMN As Nullable(Of Decimal)
    Public Property importeME As Nullable(Of Decimal)
    Public Property usuarioModificacion As String
    Public Property fechaModificacion As Nullable(Of Date)

    Public Overridable Property ordenDetalle As ICollection(Of ordenDetalle) = New HashSet(Of ordenDetalle)

End Class
