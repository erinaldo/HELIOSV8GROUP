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

Partial Public Class asistenciaTrabajador
    Public Property idAsistenciaTrabajador As Integer
    Public Property destinoLaboral As String
    Public Property horasLaboradas As Nullable(Of Date)
    Public Property fechaAsistencia As Nullable(Of Date)
    Public Property horaIngreso As Nullable(Of Date)
    Public Property horaSalida As Nullable(Of Date)
    Public Property horaRefrigerioSalida As Nullable(Of Date)
    Public Property horaRefrigerioRetorno As Nullable(Of Date)
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property asistenciaTrabajadorConcepto As ICollection(Of asistenciaTrabajadorConcepto) = New HashSet(Of asistenciaTrabajadorConcepto)

End Class
