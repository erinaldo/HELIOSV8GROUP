Partial Public Class documentoventaTransporte
    Inherits BaseBE

    Public Property CustomPerson As Persona

    Public Property CustomDocumentoVentaDetalle As documentoventaTransporteDetalle

    Public Property TotalPendientes As Integer
    Public Property TotalEntregados As Integer
    Public Property numeroDocNormal As String
    Public Property TipoConfiguracion As String
    Public Property IdNumeracion() As Integer
    Public Property CustomVehiculoAsiento_Precios As vehiculoAsiento_Precios

    Public Property Remitente() As String
    Public Property Consignado() As String
    Public Property itemsEnviados() As Integer

    Public Property ContenidoEnviado As String
    Public Property Cantidad As Decimal
    Public Property Secuencia As Integer
    Public Property CostoDetalle As Decimal
    Public Property tipo As String

    Public Property nrodoc As String
    Public Property tipDocClie As String

    Public Property CantFact() As Integer
    Public Property CantBol() As Integer
    Public Property CantNotaFact() As Integer
    Public Property CantNotaBol() As Integer
    Public Property CantFactAnu() As Integer
    Public Property CantBolAnu() As Integer

    Public Property CpePen() As Integer
    Public Property AnuPen() As Integer

    Public Property idPSE() As String

    Public Property idDistribucion() As Integer

End Class
