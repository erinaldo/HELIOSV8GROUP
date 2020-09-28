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

Partial Public Class controlInversionesMoviliarias
    Public Property idInventario As Integer
    Public Property idEmpresa As String
    Public Property idEstablecimiento As Nullable(Of Integer)
    Public Property cuenta As String
    Public Property motivoIngreso As String
    Public Property tipoOperacion As String
    Public Property codigoLibro As String
    Public Property fechaProceso As Nullable(Of Date)
    Public Property tipoDoc As String
    Public Property numeroDoc As String
    Public Property glosa As String
    Public Property tipoCaja As String
    Public Property idEntidadFinanciera As String
    Public Property monedaCaja As String
    Public Property idActivo As String
    Public Property descripcionActivo As String
    Public Property idDocumentoCompra As Nullable(Of Integer)
    Public Property idDocRef As String
    Public Property totalMN As Nullable(Of Decimal)
    Public Property totalME As Nullable(Of Decimal)
    Public Property relacionado As String
    Public Property usuarioActualizacion As String
    Public Property fechaActualizacion As Nullable(Of Date)

    Public Overridable Property conceptosInversiones As ICollection(Of conceptosInversiones) = New HashSet(Of conceptosInversiones)

End Class
