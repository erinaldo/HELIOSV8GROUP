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

Partial Public Class Actividades
    Public Property idActividad As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Integer
    Public Property idProyecto As Integer
    Public Property NombreActividad As String
    Public Property descripcion As String
    Public Property idPadre As Nullable(Of Integer)
    Public Property modulo As String
    Public Property modalidadEjecucion As String
    Public Property modalidadEjecucionDescripcion As String
    Public Property prioridadSecuencia As String
    Public Property cantidad As Nullable(Of Decimal)
    Public Property unidad As String
    Public Property importePrecUni As Nullable(Of Decimal)
    Public Property importeMEPrecUni As Nullable(Of Decimal)
    Public Property responsable As String
    Public Property NroOrden As String
    Public Property Limitaciones As String
    Public Property FactorExito As String
    Public Property CriterioFin As String
    Public Property Modalidad As String
    Public Property FechaInicio As Nullable(Of Date)
    Public Property FechaFinal As Nullable(Of Date)
    Public Property TotalPlazo As String
    Public Property Estado As String
    Public Property Observacion As String
    Public Property Horas As String
    Public Property Dias As String
    Public Property Horas1 As String
    Public Property Dias2 As String
    Public Property activo As String
    Public Property flag As String
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property Actividades1 As Actividades
    Public Overridable Property Actividades2 As Actividades
    Public Overridable Property ProyectoPlaneacion As ProyectoPlaneacion
    Public Overridable Property actividadRecurso As ICollection(Of actividadRecurso) = New HashSet(Of actividadRecurso)
    Public Overridable Property actividadSeguimiento As ICollection(Of actividadSeguimiento) = New HashSet(Of actividadSeguimiento)
    Public Overridable Property laborRecurso As ICollection(Of laborRecurso) = New HashSet(Of laborRecurso)
    Public Overridable Property mensajeriaGOP As ICollection(Of mensajeriaGOP) = New HashSet(Of mensajeriaGOP)

End Class
