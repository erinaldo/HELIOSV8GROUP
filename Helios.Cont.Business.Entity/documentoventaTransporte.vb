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

Partial Public Class documentoventaTransporte
    Public Property idDocumento As Integer
    Public Property tareo_id As Integer
    Public Property tipoOperacion As String
    Public Property idEmpresa As String
    Public Property idOrganizacion As Nullable(Of Integer)
    Public Property agenciaDestino_id As Nullable(Of Integer)
    Public Property programacion_id As Nullable(Of Integer)
    Public Property UbigeoCiudadOrigen As String
    Public Property ciudadOrigen As String
    Public Property UbigeoCiudadDestino As String
    Public Property ciudadDestino As String
    Public Property tipoDocumento As String
    Public Property fechaProgramada As Nullable(Of Date)
    Public Property fechadoc As Nullable(Of Date)
    Public Property fechaVcto As Nullable(Of Date)
    Public Property serie As String
    Public Property numero As Nullable(Of Integer)
    Public Property razonSocial As Nullable(Of Integer)
    Public Property idPersona As Nullable(Of Integer)
    Public Property sexo As String
    Public Property edad As Nullable(Of Integer)
    Public Property comprador As String
    Public Property moneda As String
    Public Property tipocambio As Nullable(Of Decimal)
    Public Property tasaIgv As Nullable(Of Decimal)
    Public Property baseImponible1 As Nullable(Of Decimal)
    Public Property baseImponible2 As Nullable(Of Decimal)
    Public Property igv1 As Nullable(Of Decimal)
    Public Property igv2 As Nullable(Of Decimal)
    Public Property total As Nullable(Of Decimal)
    Public Property estadoCobro As String
    Public Property glosa As String
    Public Property tipoVenta As String
    Public Property numeroAsiento As Nullable(Of Integer)
    Public Property idcajaUsuario As Nullable(Of Integer)
    Public Property estado As Nullable(Of Integer)
    Public Property telefonoRemitente As String
    Public Property telefonoConsignado As String
    Public Property nroPlaca As String
    Public Property usuarioActualizacion As Nullable(Of Integer)
    Public Property fechaActualizacion As Nullable(Of Date)
    Public Property ticketElectronico As String
    Public Property numeracionElectronica As Nullable(Of Long)
    Public Property EnvioSunat As String

    Public Overridable Property documento As documento
    Public Overridable Property documentoventaTransporteDetalle As ICollection(Of documentoventaTransporteDetalle) = New HashSet(Of documentoventaTransporteDetalle)

End Class
