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

Partial Public Class PersonalConceptos
    Public Property IDConcepto As Integer
    Public Property IDPersonal As Integer
    Public Property IDCargo As Integer
    Public Property IDTipoPlanilla As Nullable(Of Integer)
    Public Property orden As String
    Public Property DescripcionCorta As String
    Public Property DescripcionLarga As String
    Public Property IDSunat As Nullable(Of Integer)
    Public Property IDContable As Nullable(Of Integer)
    Public Property Moneda As String
    Public Property TipoCalculo As String
    Public Property Formula As String
    Public Property Activo As Nullable(Of Boolean)
    Public Property TipoConcepto As String
    Public Property ValorCalculo As Nullable(Of Decimal)
    Public Property FechaModificacion As Nullable(Of Date)
    Public Property UsuarioModificacion As String

    Public Overridable Property PersonalCargo As PersonalCargo

End Class
