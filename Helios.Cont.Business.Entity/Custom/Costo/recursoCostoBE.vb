Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Threading

Partial Public Class recursoCosto
    Inherits BaseBE

    Public Property EnvioAlmacen() As String
    Public Property TotalMN() As Decimal
    Public Property TotalME() As Decimal
    Public Property Anio As Integer
    Public Property IdProceso() As Integer
    Public Property NomProceso() As String
    Public Property IdActividad() As Integer
    Public Property NomActividad() As String
    Public Property NombreResponsable() As String
    Public Property SecuenciaTrabajoProceso() As Integer

    Public Property UnidadMedida() As String

    Public Property idNumeracion() As Integer

    Public Property nombreCuenta() As String

    Public Property nroEntregable() As Integer

    Public Property nroSubProductos() As Integer


    Public Property cantPresupuesto() As Decimal?
    Public Property CostoPresupuesto() As Decimal?
    Public Property CostoReal() As Decimal?
    Public Property CantidadReal() As Decimal?
    Public Property CustomDocumento() As documento

    Public Property codigocuenta() As String
    Public Property mdp() As String
    Public Property mod1() As String
    Public Property ocd() As String
    Public Property gpi() As String
    Public Property gpimpi() As String
    Public Property gpimoi() As String
    Public Property gpiogi() As String
    Public Property contrato() As String



    Public Property idProyecto() As Integer
    Public Property nombreProyecto() As String
    Public Property idSubProyecto() As Integer
    Public Property nombreSubProyecto() As String

    Public Property idEntregable() As Integer
    Public Property nombreEntregable() As String
    Public Property Conteocompras() As Integer
    Public Property Conteoinventario() As Integer
    Public Property Conteofinanza() As Integer
    Public Property Conteolibro() As Integer
    Public Property idItem() As Integer

End Class


