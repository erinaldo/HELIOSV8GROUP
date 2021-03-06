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

Partial Public Class documentoPrestamos
    Public Property idDocumento As Integer
    Public Property idCuota As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Integer
    Public Property cuentaContable As String
    Public Property tipoMovimiento As String
    Public Property tipoBeneficiario As String
    Public Property idBeneficiario As Integer
    Public Property fecha As Date
    Public Property referencia As String
    Public Property moneda As String
    Public Property tipoCambio As Nullable(Of Decimal)
    Public Property montoSoles As Nullable(Of Decimal)
    Public Property montoDolares As Nullable(Of Decimal)
    Public Property entregado As String
    Public Property estadoPago As String
    Public Property fechaVcto As Nullable(Of Date)
    Public Property fechaPlazo As Nullable(Of Date)
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property documento As documento
    Public Overridable Property documentoPrestamoDetalle As ICollection(Of documentoPrestamoDetalle) = New HashSet(Of documentoPrestamoDetalle)

End Class
