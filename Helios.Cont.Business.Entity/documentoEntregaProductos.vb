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

Partial Public Class documentoEntregaProductos
    Public Property idDocumento As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Integer
    Public Property origenVenta As String
    Public Property codigoLibro As String
    Public Property fechaEntrega As Nullable(Of Date)
    Public Property serie As String
    Public Property numeroDoc As String
    Public Property tipoDocumento As String
    Public Property ImporteMN As Nullable(Of Decimal)
    Public Property ImporteME As Nullable(Of Decimal)
    Public Property documentoRef As Nullable(Of Integer)
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property documento As documento
    Public Overridable Property documentoEntregaDetalle As ICollection(Of documentoEntregaDetalle) = New HashSet(Of documentoEntregaDetalle)

End Class
