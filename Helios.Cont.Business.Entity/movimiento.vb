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

Partial Public Class movimiento
    Public Property idmovimiento As Integer
    Public Property idAsiento As Integer
    Public Property cuenta As String
    Public Property descripcion As String
    Public Property tipo As String
    Public Property monto As Nullable(Of Decimal)
    Public Property montoUSD As Nullable(Of Decimal)
    Public Property tipoCosto As String
    Public Property idCosto As Nullable(Of Integer)
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property asiento As asiento

End Class