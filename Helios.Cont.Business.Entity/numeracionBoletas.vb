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

Partial Public Class numeracionBoletas
    Public Property IdEnumeracion As Integer
    Public Property codigoNumeracion As String
    Public Property tipo As String
    Public Property serie As String
    Public Property valorInicial As Nullable(Of Long)
    Public Property empresa As String
    Public Property establecimiento As Nullable(Of Integer)
    Public Property valorMinimo As Nullable(Of Integer)
    Public Property valorMaximo As Nullable(Of Long)
    Public Property incremento As Nullable(Of Integer)
    Public Property anclado As String
    Public Property tipo1 As String
    Public Property serie1 As String
    Public Property valorInicial1 As Nullable(Of Long)
    Public Property valorMinimo1 As Nullable(Of Integer)
    Public Property valorMaximo1 As Nullable(Of Long)
    Public Property incremento1 As Nullable(Of Integer)
    Public Property tipoControl As String
    Public Property estado As String
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property distribucionNumeracionAO As ICollection(Of distribucionNumeracionAO) = New HashSet(Of distribucionNumeracionAO)

End Class
