Imports System
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class SunatContribuyente
    <JsonProperty("ruc")>
    Public Property Ruc As Long

    <JsonProperty("nombre_o_razon_social")>
    Public Property NombreORazonSocial As String

    <JsonProperty("estado_del_contribuyente")>
    Public Property EstadoDelContribuyente As String

    <JsonProperty("condicion_de_domicilio")>
    Public Property CondicionDeDomicilio As String

    <JsonProperty("ubigeo")>
    Public Property Ubigeo As Integer

    <JsonProperty("tipo_de_via")>
    Public Property TipoDeVia As String

    <JsonProperty("nombre_de_via")>
    Public Property NombreDeVia As String

    <JsonProperty("codigo_de_zona")>
    Public Property CodigoDeZona As String

    <JsonProperty("tipo_de_zona")>
    Public Property TipoDeZona As String

    <JsonProperty("numero")>
    Public Property Numero As Integer

    <JsonProperty("interior")>
    Public Property Interior As String

    <JsonProperty("lote")>
    Public Property Lote As String

    <JsonProperty("dpto")>
    Public Property Dpto As String

    <JsonProperty("manzana")>
    Public Property Manzana As String

    <JsonProperty("kilometro")>
    Public Property Kilometro As String

    <JsonProperty("direccion")>
    Public Property Direccion As String
End Class
