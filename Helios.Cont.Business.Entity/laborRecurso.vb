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

Partial Public Class laborRecurso
    Public Property idlaborRecurso As Integer
    Public Property idLabor As Integer
    Public Property idActividadRecurso As Integer
    Public Property descripcionItem As String
    Public Property unidad As String
    Public Property cantidad As Nullable(Of Decimal)
    Public Property precUnit As Nullable(Of Decimal)
    Public Property Importe As Nullable(Of Decimal)
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property Actividades As Actividades
    Public Overridable Property laborRecursoPersona As ICollection(Of laborRecursoPersona) = New HashSet(Of laborRecursoPersona)

End Class
