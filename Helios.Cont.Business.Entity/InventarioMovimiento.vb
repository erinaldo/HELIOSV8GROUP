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

Partial Public Class InventarioMovimiento
    Public Property idInventario As Long
    Public Property idorigenDetalle As Nullable(Of Integer)
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Nullable(Of Integer)
    Public Property idAlmacen As Integer
    Public Property nrolote As String
    Public Property tipoOperacion As String
    Public Property tipoDocAlmacen As String
    Public Property serie As String
    Public Property numero As String
    Public Property idDocumento As Nullable(Of Integer)
    Public Property idDocumentoRef As String
    Public Property descripcion As String
    Public Property fechaLaboral As Nullable(Of Date)
    Public Property fecha As Nullable(Of Date)
    Public Property tipoRegistro As String
    Public Property destinoGravadoItem As String
    Public Property tipoProducto As String
    Public Property OrigentipoProducto As String
    Public Property cuentaOrigen As String
    Public Property idItem As Integer
    Public Property marca As String
    Public Property presentacion As String
    Public Property fechavcto As Nullable(Of Date)
    Public Property cantidad As Nullable(Of Decimal)
    Public Property unidad As String
    Public Property cantidad2 As Nullable(Of Decimal)
    Public Property unidad2 As String
    Public Property precUnite As Nullable(Of Decimal)
    Public Property precUniteUSD As Nullable(Of Decimal)
    Public Property monto As Nullable(Of Decimal)
    Public Property montoUSD As Nullable(Of Decimal)
    Public Property montoOther As Nullable(Of Decimal)
    Public Property monedaOther As String
    Public Property disponible As Nullable(Of Decimal)
    Public Property disponible2 As Nullable(Of Decimal)
    Public Property saldoMonto As Nullable(Of Decimal)
    Public Property saldoMontoUsd As Nullable(Of Decimal)
    Public Property status As String
    Public Property entragado As String
    Public Property preEvento As String
    Public Property usuarioActualizacion As String
    Public Property consignado As String
    Public Property fechaActualizacion As Nullable(Of Date)
    Public Property contenido_neto As Nullable(Of Decimal)

    Public Overridable Property almacen As almacen
    Public Overridable Property detalleitems As detalleitems

End Class
