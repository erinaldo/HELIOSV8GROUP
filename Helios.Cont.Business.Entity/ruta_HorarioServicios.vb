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

Partial Public Class ruta_HorarioServicios
    Public Property ruta_id As Integer
    Public Property horario_id As Integer
    Public Property codigoServicio As Integer
    Public Property idServicioInfraestructura As Nullable(Of Integer)
    Public Property tipoServicio As String
    Public Property descripcionCorta As String
    Public Property descripcionLarga As String
    Public Property costoEstimado As Nullable(Of Decimal)
    Public Property capacidad As Nullable(Of Integer)
    Public Property usuarioActualizacion As Nullable(Of Integer)
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property ruta_horarios As ruta_horarios
    Public Overridable Property servicioInfraestructura As servicioInfraestructura

End Class
