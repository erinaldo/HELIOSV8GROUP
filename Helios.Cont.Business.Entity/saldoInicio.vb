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

Partial Public Class saldoInicio
    Public Property idDocumento As Integer
    Public Property codigoLibro As String
    Public Property idEmpresa As String
    Public Property idCentroCosto As Integer
    Public Property fechaDoc As Nullable(Of Date)
    Public Property fechaVcto As Nullable(Of Date)
    Public Property periodo As String
    Public Property tipoDoc As String
    Public Property serie As String
    Public Property numeroDoc As String
    Public Property idPersona As Nullable(Of Integer)
    Public Property tipoPersona As String
    Public Property monedaDoc As String
    Public Property tasaIgv As Nullable(Of Decimal)
    Public Property tcDolLoc As Nullable(Of Decimal)
    Public Property importeTotal As Nullable(Of Decimal)
    Public Property importeUS As Nullable(Of Decimal)
    Public Property destino As String
    Public Property estadoPago As String
    Public Property glosa As String
    Public Property tipoCompra As String
    Public Property idPadre As Nullable(Of Integer)
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property documento As documento
    Public Overridable Property saldoInicioDetalle As ICollection(Of saldoInicioDetalle) = New HashSet(Of saldoInicioDetalle)

End Class