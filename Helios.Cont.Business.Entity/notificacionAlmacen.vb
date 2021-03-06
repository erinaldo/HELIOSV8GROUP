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

Partial Public Class notificacionAlmacen
    Public Property idDocumento As Integer
    Public Property codigoLibro As String
    Public Property idEmpresa As String
    Public Property idCentroCosto As Integer
    Public Property tipoMovimiento As String
    Public Property fechaDoc As Nullable(Of Date)
    Public Property fechaContable As String
    Public Property tipoDoc As String
    Public Property serie As String
    Public Property numeroDoc As String
    Public Property idProveedor As Nullable(Of Integer)
    Public Property monedaDoc As String
    Public Property monedaObligacion As String
    Public Property moneda As String
    Public Property entidadFinanciera As String
    Public Property entidadFinancieraDestino As Nullable(Of Integer)
    Public Property tipoCambio As Nullable(Of Decimal)
    Public Property tasaIgv As Nullable(Of Decimal)
    Public Property importeTotal As Nullable(Of Decimal)
    Public Property importeUS As Nullable(Of Decimal)
    Public Property estado As String
    Public Property glosa As String
    Public Property idPadre As Nullable(Of Integer)
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property documento As documento
    Public Overridable Property notificacionAlmacenDetalle As ICollection(Of notificacionAlmacenDetalle) = New HashSet(Of notificacionAlmacenDetalle)

End Class
