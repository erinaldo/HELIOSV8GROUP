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

Partial Public Class inventario
    Public Property idInventario As String
    Public Property idDocumento As Integer
    Public Property idEmpresa As String
    Public Property idCentroCosto As String
    Public Property idAlmacen As String
    Public Property idItem As String
    Public Property ingresoID As String
    Public Property idEvento As Integer
    Public Property origen As String
    Public Property secuencia As Nullable(Of Integer)
    Public Property fecha As Nullable(Of Date)
    Public Property tipo As String
    Public Property cantidad As Nullable(Of Decimal)
    Public Property costoUnitario As Nullable(Of Decimal)
    Public Property costoTotal As Nullable(Of Decimal)
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property documento As documento

End Class
