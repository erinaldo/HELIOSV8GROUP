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

Partial Public Class clientecontrato
    Public Property idContrato As Integer
    Public Property idclientespk As Integer
    Public Property tipoContrato As String
    Public Property codigoPago As String
    Public Property serial As String
    Public Property statuspago As Nullable(Of Integer)
    Public Property fechacontrato As Nullable(Of Date)
    Public Property fechainicio As Nullable(Of Date)
    Public Property fechaExpiracion As Nullable(Of Date)

    Public Overridable Property clientesSoftPack As clientesSoftPack
    Public Overridable Property clientecontratodetalle As ICollection(Of clientecontratodetalle) = New HashSet(Of clientecontratodetalle)

End Class
