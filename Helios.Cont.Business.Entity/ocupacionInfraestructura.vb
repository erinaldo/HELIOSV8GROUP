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

Partial Public Class ocupacionInfraestructura
    Public Property idOcupacion As Integer
    Public Property idDocumento As Integer
    Public Property secuencia As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Nullable(Of Integer)
    Public Property idDistribucion As Nullable(Of Integer)
    Public Property idEntidad As Nullable(Of Integer)
    Public Property chek_in As Nullable(Of Date)
    Public Property check_on As Nullable(Of Date)
    Public Property estado As String
    Public Property glosario As String
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property distribucionInfraestructura As distribucionInfraestructura
    Public Overridable Property documentoventaAbarrotesDet As documentoventaAbarrotesDet

End Class
