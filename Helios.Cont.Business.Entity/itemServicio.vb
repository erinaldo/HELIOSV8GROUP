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

Partial Public Class itemServicio
    Public Property idItemServicio As Integer
    Public Property idPadre As Nullable(Of Integer)
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Nullable(Of Integer)
    Public Property fechaIngreso As Nullable(Of Date)
    Public Property descripcion As String
    Public Property tipo As String
    Public Property utilidad As Nullable(Of Decimal)
    Public Property utilidadmayor As Nullable(Of Decimal)
    Public Property utilidadgranmayor As Nullable(Of Decimal)
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property servicio As ICollection(Of servicio) = New HashSet(Of servicio)

End Class
