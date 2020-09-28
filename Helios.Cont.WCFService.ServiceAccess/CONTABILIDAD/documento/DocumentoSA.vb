Imports Helios.Cont.Business.Entity
Public Class DocumentoSA
#Region "APORTES"
    Public Sub DeleteAporte(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteAporte(documentoBE, objTotalBorrar)
    End Sub
#End Region

    Public Sub EliminarPagoMembresia(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPagoMembresia(documentoBE)
    End Sub

    Public Sub EliminarCompensacion(ByVal idDocumentoOrigen As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCompensacion(idDocumentoOrigen)
    End Sub

    Public Sub EliminarPedidos(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPedidos(documentoBE)
    End Sub

    Public Sub EliminarConsumoDirecto(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarConsumoDirecto(documentoBE)
    End Sub

    Public Sub ElimiNarPagoAnticipoCompra(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ElimiNarPagoAnticipoCompra(documentoBE)
    End Sub

    Public Sub ElimiNarCobroAnticipoVenta(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ElimiNarCobroAnticipoVenta(documentoBE)
    End Sub


    Public Function UbicarConteoVentaCompra(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarConteoVentaCompra(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Sub EliminarComprobanteORPByCosto(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarComprobanteORPByCosto(documentoBE)
    End Sub

#Region "VENTAS"

    Public Sub EliminarVentaTicketDirecta(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarVentaTicketDirecta(documentoBE)
    End Sub

    Sub EliminarVentaGeneralPV(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarVentaGeneralPV(documentoBE)
    End Sub

    Public Sub DeleteVentaNormalAlCredito(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteVentaNormalAlCredito(documentoBE, objTotalBorrar)
    End Sub
#End Region

    Public Sub EliminarCompraGeneral(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCompraGeneral(documentoBE)
    End Sub

    Public Sub ElimiNarPagoCompra(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ElimiNarPagoCompra(documentoBE)
    End Sub

    Public Sub DeleteAnticipoSL(nDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteAnticipoSL(nDocumento)
    End Sub

    Public Sub EliminarPagoPrestamo(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPagoPrestamo(documentoBE)
    End Sub

    Public Sub EliminarOtrosMovimientosCaja(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarOtrosMovimientosCaja(documentoBE)
    End Sub

    Public Sub EliminarTransferenciaCaja(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarTransferenciaCaja(documentoBE)
    End Sub

    Public Sub EliminarDocumentoCaja(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarDocumentoCaja(documentoBE)
    End Sub

    Public Function UbicarDocumento(intIdDocumento As Integer) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumento(intIdDocumento)
    End Function

    Public Sub DeleteDocumento(nDocumento As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteDocumento(nDocumento, objTotalBorrar)
    End Sub

    Public Sub DeleteDocumentoPagado(nDocumento As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteDocumentoPagado(nDocumento, objTotalBorrar)
    End Sub

    Public Sub DeleteCompraDirectaSinRecepcion(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteCompraDirectaSinRecepcion(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteOtrasEntradas(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteOtrasEntradas(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteOtrasSalidasDeAlmacen(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteOtrasSalidasDeAlmacen(documentoBE, objTotalBorrar)
    End Sub


    Public Sub DeleteOtrasTransAlmacenOE(ByVal documentoBE As documento, ListaOrigen As List(Of totalesAlmacen),
                                         ListaDestino As List(Of totalesAlmacen))

        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteOtrasTransAlmacenOE(documentoBE, ListaOrigen, ListaDestino)
    End Sub

    Public Sub DeleteOtrasTransAlmacenOESL(ByVal documentoBE As documento)

        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteOtrasTransAlmacenOESL(documentoBE)
    End Sub

    Public Sub DeleteOtrasSalidas(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteOtrasSalidas(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteNotas(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteNotas(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteNotasDebito(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteNotasDebito(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteVentaTicket(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteVentaTicket(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteVentaTicketCobrado(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteVentaTicketCobrado(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteDocumentoSL(nDocumento As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteDocumentoSL(nDocumento, objTotalBorrar)
    End Sub

    Public Sub DeleteDocumentoPagadoSL(nDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteDocumentoPagadoSL(nDocumento)
    End Sub

    Public Sub DeleteCompraDirectaSinRecepcionSL(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteCompraDirectaSinRecepcionSL(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteCompraCreditoConRecepcionSL(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteCompraCreditoConRecepcionSL(documentoBE)
    End Sub

    Public Sub DeleteDocumentoPagadoAlCredito(nDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteDocumentoPagadoAlCredito(nDocumento)
    End Sub

    Public Function DeleteUsuarioCajaSL(nDocumento As documento) As String
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DeleteUsuarioCajaSL(nDocumento)
    End Function

    Public Sub DeleteVentaNormalServicio(ByVal documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteVentaNormalServicio(documentoBE)
    End Sub

    Public Sub DeleteSingleVariable(ByVal intIdDocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteSingleVariable(intIdDocumento)
    End Sub
End Class
