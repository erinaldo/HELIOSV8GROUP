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

Partial Public Class areaOperativa
    Public Property idArea As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Nullable(Of Integer)
    Public Property AreaOperativa1 As String
    Public Property tipoArea As String

    Public Overridable Property ProductoXAreaOperativa As ICollection(Of ProductoXAreaOperativa) = New HashSet(Of ProductoXAreaOperativa)

End Class
