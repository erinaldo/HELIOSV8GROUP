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

Partial Public Class Plantilla
    Public Property IDPlantilla As Integer
    Public Property DescripcionCorta As String
    Public Property DescripcionLarga As String
    Public Property FechaModificacion As Nullable(Of Date)
    Public Property UsuarioModificacion As String

    Public Overridable Property PlantillaDetalle As ICollection(Of PlantillaDetalle) = New HashSet(Of PlantillaDetalle)

End Class
