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

Partial Public Class empresa
    Public Property idEmpresa As String
    Public Property idclientespk As Integer
    Public Property razonSocial As String
    Public Property nombreCorto As String
    Public Property ruc As String
    Public Property direccion As String
    Public Property telefono As String
    Public Property fax As String
    Public Property celular As String
    Public Property e_mail As String
    Public Property regimen As String
    Public Property actividad As String
    Public Property inicioOperacion As String
    Public Property departamento As String
    Public Property provincia As String
    Public Property distrito As String
    Public Property ubigeo As String
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)
    Public Property estado As String

    Public Overridable Property activosFijos As ICollection(Of activosFijos) = New HashSet(Of activosFijos)
    Public Overridable Property centrocosto As ICollection(Of centrocosto) = New HashSet(Of centrocosto)
    Public Overridable Property cuentaplanContableEmpresa As ICollection(Of cuentaplanContableEmpresa) = New HashSet(Of cuentaplanContableEmpresa)
    Public Overridable Property EmpresaEmail As ICollection(Of EmpresaEmail) = New HashSet(Of EmpresaEmail)
    Public Overridable Property EmpresaSoporte As ICollection(Of EmpresaSoporte) = New HashSet(Of EmpresaSoporte)
    Public Overridable Property presupuesto As ICollection(Of presupuesto) = New HashSet(Of presupuesto)

End Class
