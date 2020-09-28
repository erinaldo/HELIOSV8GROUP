Imports System
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class SunatContribuyente2
    <JsonProperty("ruc")>
    Public Property Ruc As Long

    <JsonProperty("razon_social")>
    Public Property NombreORazonSocial As String

    <JsonProperty("contribuyente_estado")>
    Public Property EstadoDelContribuyente As String

    <JsonProperty("contribuyente_condicion")>
    Public Property contribuyente_condicion As String

    <JsonProperty("contribuyente_tipo")>
    Public Property contribuyente_tipo As String

    <JsonProperty("domicilio_fiscal")>
    Public Property Direccion As String
End Class
