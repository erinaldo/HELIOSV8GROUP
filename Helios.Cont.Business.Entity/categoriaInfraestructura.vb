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

Partial Public Class categoriaInfraestructura
    Public Property idCategoria As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Nullable(Of Integer)
    Public Property descripcionInfraestructura As String
    Public Property estado As String
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property tipoServicioInfraestructura As ICollection(Of tipoServicioInfraestructura) = New HashSet(Of tipoServicioInfraestructura)

End Class
