Partial Public Class documento
    Inherits BaseBE

    Public Property Codigo As String

    Public Property CustomSerie() As String
    Public Property CustomNumero() As String

    Public Property ventaConLotes As Boolean

    Public Property IsFormatoGeneral() As Boolean

    Public Property IsInicio() As Boolean
    Public Property IdDocumentoAfectado() As Integer
    Public Property tipoConfirmacion() As String

    Public Property ImporteMN() As Decimal?
    Public Property ImporteME() As Decimal?

    Public Property CustomDocumentoCaja() As documento

    Public Property ListaCustomDocumento() As List(Of documento)

    Public Property ListaCustomDocumentoCaja() As List(Of documentoCaja)

    Public Property ListaDetalleAnticipos() As List(Of documentoAnticipoConciliacion)

    Public Property ListaDetalleAnticiposCompra() As List(Of documentoAnticipoConciliacionCompra)


    Public Property idPrestamo() As Integer

    Public Property TipoEnvio() As String
    Public Property TieneCotizacion() As Boolean

    Public Property InventarioMovimiento As New List(Of InventarioMovimiento)
    Public Property idEstablecimientoTransaccion() As Integer


    Public Property FormaPagoCajaUnica() As Boolean

    Public Property CustomBeneficio As beneficio

    Public Property CustomListaBeneficios As List(Of beneficio)

    Public Property CustomComisionAutorizacion As List(Of registrocomision_autorizacion)

    Public Property AfectaInventario As Boolean

    Public Property ListaDocumentoID() As List(Of Integer)

    Public Property ocupacionInfra As ocupacionInfraestructura

    Public Property personaBeneficio As List(Of personaBeneficio)

    Public Property IDCajaUsuario As Integer

    Public Property idPse() As String

    Public Property idEmpresaDes() As String

    Public Property IdPerfil As Integer
    Public Property tipo As String

End Class
