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

Partial Public Class documentoLibroDiarioDetalle
    Public Property idDocumento As Integer
    Public Property secuencia As Integer
    Public Property cuenta As String
    Public Property idItem As Nullable(Of Integer)
    Public Property descripcion As String
    Public Property tipoAsiento As String
    Public Property monto1 As Nullable(Of Decimal)
    Public Property importeMN As Nullable(Of Decimal)
    Public Property importeME As Nullable(Of Decimal)
    Public Property Evento As String
    Public Property idEvento As String
    Public Property cuentaPadre As String
    Public Property idEstablecimiento As Nullable(Of Integer)
    Public Property entregadoCancelado As String
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)
    Public Property idCosto As Nullable(Of Integer)
    Public Property estadoPago As String
    Public Property tipoPago As String
    Public Property glosa As String
    Public Property ididentificacion As Nullable(Of Integer)
    Public Property tipoIdentificacion As String
    Public Property tipoCosto As String

    Public Overridable Property documentoLibroDiario As documentoLibroDiario

End Class