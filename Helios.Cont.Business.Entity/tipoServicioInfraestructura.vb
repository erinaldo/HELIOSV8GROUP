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

Partial Public Class tipoServicioInfraestructura
    Public Property idTipoServicio As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Nullable(Of Integer)
    Public Property idCategoria As Nullable(Of Integer)
    Public Property descripcionTipoServicio As String
    Public Property estadoTipoServicio As String
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property categoriaInfraestructura As categoriaInfraestructura
    Public Overridable Property distribucionInfraestructura As ICollection(Of distribucionInfraestructura) = New HashSet(Of distribucionInfraestructura)

End Class
