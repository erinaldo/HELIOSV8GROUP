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

Partial Public Class documentoPrestamoDetalle
    Public Property idDocumento As Integer
    Public Property idCuota As Integer
    Public Property secuencia As Integer
    Public Property cuota As String
    Public Property descripcion As String
    Public Property montoSoles As Nullable(Of Decimal)
    Public Property montoUsd As Nullable(Of Decimal)
    Public Property estadoPago As String
    Public Property cuenta As String
    Public Property fechaVencimiento As Nullable(Of Date)
    Public Property fechaPlazo As Nullable(Of Date)
    Public Property fechaModificacion As Nullable(Of Date)
    Public Property usuarioModificacion As String
    Public Property tieneCosto As String
    Public Property tipo As String
    Public Property cuentaH As String
    Public Property devengado As String
    Public Property devengadoH As String

    Public Overridable Property documentoPrestamos As documentoPrestamos

End Class