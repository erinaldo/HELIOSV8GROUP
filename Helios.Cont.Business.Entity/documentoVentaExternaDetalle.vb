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

Partial Public Class documentoVentaExternaDetalle
    Public Property idDocumento As Integer
    Public Property secuencia As Integer
    Public Property idAlmacen As Nullable(Of Integer)
    Public Property establecimientoOrigen As Nullable(Of Integer)
    Public Property cuentaOrigen As String
    Public Property idItem As String
    Public Property tipoExistencia As String
    Public Property idOrigen As String
    Public Property destino As String
    Public Property unidad1 As String
    Public Property monto1 As Nullable(Of Decimal)
    Public Property unidad2 As String
    Public Property monto2 As Nullable(Of Decimal)
    Public Property precioUnitario As Nullable(Of Decimal)
    Public Property precioUnitarioUS As Nullable(Of Decimal)
    Public Property importe As Nullable(Of Decimal)
    Public Property importeUS As Nullable(Of Decimal)
    Public Property bonificacion As Nullable(Of Decimal)
    Public Property montokardex As Nullable(Of Decimal)
    Public Property montoIsc As Nullable(Of Decimal)
    Public Property montoIgv As Nullable(Of Decimal)
    Public Property otrosTributos As Nullable(Of Decimal)
    Public Property montokardexUS As Nullable(Of Decimal)
    Public Property montoIscUS As Nullable(Of Decimal)
    Public Property montoIgvUS As Nullable(Of Decimal)
    Public Property otrosTributosUS As Nullable(Of Decimal)
    Public Property estadoMovimiento As String
    Public Property usuarioModificacion As String
    Public Property fechaModificacion As Nullable(Of Date)

    Public Overridable Property documentoVentaExterna As documentoVentaExterna

End Class
