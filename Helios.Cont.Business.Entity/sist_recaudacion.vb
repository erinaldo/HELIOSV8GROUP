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

Partial Public Class sist_recaudacion
    Public Property id As Integer
    Public Property idItem As Integer
    Public Property tipoSistema As String
    Public Property modulo As String
    Public Property descripcion As String
    Public Property tasa As Nullable(Of Decimal)
    Public Property vigencia As Nullable(Of Date)
    Public Property cuenta As String
    Public Property ubicacion As String
    Public Property montoAfecto As Nullable(Of Decimal)
    Public Property usuarioModificacion As String
    Public Property fechaModificacion As Nullable(Of Date)

    Public Overridable Property detalleitems As detalleitems

End Class