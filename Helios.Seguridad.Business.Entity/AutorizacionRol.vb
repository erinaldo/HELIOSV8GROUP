'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class AutorizacionRol
    Public Property IDRol As Integer
    Public Property IDUsuario As Integer
    Public Property IDAsegurable As Integer
    Public Property IDModulo As Integer
    Public Property IDProducto As Nullable(Of Integer)
    Public Property EstaAutorizado As Boolean
    Public Property UsuarioActualizacion As String
    Public Property FechaActualizacion As Date

    Public Overridable Property Asegurable As Asegurable
    Public Overridable Property UsuarioRol As UsuarioRol

End Class
