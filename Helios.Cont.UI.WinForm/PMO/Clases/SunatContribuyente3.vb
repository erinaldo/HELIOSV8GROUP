Imports System
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class SunatContribuyente3
    <JsonProperty("Ruc")>
    Public Property Ruc As Long

    <JsonProperty("RazonSocial")>
    Public Property NombreORazonSocial As String

    <JsonProperty("Estado")>
    Public Property EstadoDelContribuyente As String

    <JsonProperty("Condicion")>
    Public Property contribuyente_condicion As String

    <JsonProperty("Ubigeo")>
    Public Property contribuyente_Ubigeo As String

    <JsonProperty("DireccionCompleta")>
    Public Property Direccion As String
End Class
