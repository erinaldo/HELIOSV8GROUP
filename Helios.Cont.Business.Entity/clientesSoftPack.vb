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

Partial Public Class clientesSoftPack
    Public Property idclientespk As Integer
    Public Property IDProducto As Nullable(Of Integer)
    Public Property tipodoc As Integer
    Public Property nroDoc As String
    Public Property razonsocial As String
    Public Property logo As Byte()
    Public Property nrotrabajadores As Integer
    Public Property horariolaboral As String
    Public Property direccion As String
    Public Property departamento As Integer
    Public Property provincia As Integer
    Public Property distrito As Integer
    Public Property pais As Integer
    Public Property sectorEmpresarial As Integer
    Public Property tipoempresa As Integer
    Public Property detalle As String
    Public Property paginaweb As String
    Public Property nombreContacto As String
    Public Property apellidosContacto As String
    Public Property telefono1 As String
    Public Property telefono2 As String
    Public Property clave As String
    Public Property status As Nullable(Of Integer)

    Public Overridable Property clientecontrato As ICollection(Of clientecontrato) = New HashSet(Of clientecontrato)

End Class