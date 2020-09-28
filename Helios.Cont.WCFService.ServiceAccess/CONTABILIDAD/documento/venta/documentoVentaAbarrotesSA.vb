Imports Helios.Cont.Business.Entity

Public Class documentoVentaAbarrotesSA
    Public Function GetVentasXDistribuirSelDate(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasXDistribuirSelDate(be)
    End Function
    Public Function GetVentasXDistribuirSelCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasXDistribuirSelCliente(be)
    End Function
    Public Function GetListarTodasVentasProductosTipoDoc(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarTodasVentasProductosTipoDoc(be, tipoConsulta)
    End Function

    Public Sub ConfirmarTransferencia(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmarTransferencia(be)
    End Sub

    Public Function GetTransferenciaEnTransitoCount(be As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTransferenciaEnTransitoCount(be)
    End Function

    Public Function GetTransferenciaEnTransito(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTransferenciaEnTransito(be)
    End Function

    Public Function GrabarTransferencia(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarTransferencia(be)
    End Function
    Public Function GrabarInventarioEquivalencia(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarInventarioEquivalencia(be)
    End Function

    Public Function GrabarInventarioEquivalenciaTranferencia(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarInventarioEquivalenciaTranferencia(be)
    End Function

    Public Function GetTransferenciasPeriodo(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTransferenciasPeriodo(be)
    End Function

    Public Function ConsultaLotesDisponiblesAdmin(i As documentoventaAbarrotesDet) As List(Of recursoCostoLote)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConsultaLotesDisponiblesAdmin(i)
    End Function

    Public Function ConsultaStockItemV2(i As documentoventaAbarrotesDet) As List(Of usp_GetValidacionLotes_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConsultaStockItemV2(i)
    End Function


    Public Function ListaCpePendientes(fecha As DateTime, idEmpresa As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaCpePendientes(fecha, idEmpresa)
    End Function
    Public Function ListaCpePendientesDeEnvio(fecha As DateTime, idEmpresa As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaCpePendientesDeEnvio(fecha, idEmpresa)
    End Function


    Public Function AnuladosPendientesCPE(fecha As DateTime, ruc As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.AnuladosPendientesCPE(fecha, ruc)
    End Function

    Public Function DocumentosAnuladosPendientes(fecha As DateTime, ruc As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentosAnuladosPendientes(fecha, ruc)
    End Function

    Public Function AlertaEnvioPSE(Empresa As String) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.AlertaEnvioPSE(Empresa)
    End Function

    Public Function RankingVentas(opcion As String, be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RankingVentas(opcion, be)
    End Function

    Public Function GetCuentaCobrarSelCliente(strPeriodo As Date, StrMoneda As String, intIdCliente As Integer, terminos As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentaCobrarSelCliente(strPeriodo, StrMoneda, intIdCliente, terminos)
    End Function

    Public Function GetResumenCuentasXCobrarTerminos(strEmpresa As String, intIdEstablecimiento As Integer, FechaConsulta As Date, StrMoneda As String, estadocobro As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetResumenCuentasXCobrarTerminos(strEmpresa, intIdEstablecimiento, FechaConsulta, StrMoneda, estadocobro)
    End Function

    Public Function BuscarNotasBoletasPeriodo(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarNotasBoletasPeriodo(fecha, tipoDoc, idEmpresa)
    End Function
    Public Function GetProformaCode(be As documento) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProformaCode(be)
    End Function

    Public Function ConteoNotasVenta(idDoc As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConteoNotasVenta(idDoc)

    End Function


    Public Function NotasActivas(idDoc As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.NotasActivas(idDoc)

    End Function


    Public Sub CambiarEstadoRecCompra(be As documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarEstadoRecCompra(be)
    End Sub

    Public Sub EditarDocumentoVenta(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarDocumentoVenta(be)
    End Sub

    Public Function GrabarReclamacionCompromiso(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarReclamacionCompromiso(objDocumento)
    End Function

    Public Function ObtenerSaldoReclamacion(idanticipo As Integer) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerSaldoReclamacion(idanticipo)
    End Function

    Function GetReclamacionesXClientes(parametro As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetReclamacionesXClientes(parametro)
    End Function

    Function GetCuentasPagarReclamacionesClientes(parametro As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasPagarReclamacionesClientes(parametro)
    End Function

    Public Function DocumentoAfectadoNC(be As documentoventaAbarrotes) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoAfectadoNC(be)
    End Function

    Public Sub CambiarEstadoNotaCreditoAnticipoCompra(be As documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarEstadoNotaCreditoAnticipoCompra(be)
    End Sub

    Public Function HistorialDeCobranza(iNtPadre As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.HistorialDeCobranza(iNtPadre)
    End Function


    Public Sub GrabarDocumentoCajaDevolucionAntOtor(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDocumentoCajaDevolucionAntOtor(be)
    End Sub

    Public Function GetVentasCriterio(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasCriterio(be)
    End Function

    Public Function FacturasAnuPendientesEnv(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.FacturasAnuPendientesEnv(fecha, tipodoc, ruc)
    End Function

    Public Function BoletasAnuPendEnvio(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BoletasAnuPendEnvio(fecha, IdEmpresa)
    End Function

    Public Sub UpdateAnulacionEnviada(objDocumento As Integer, idNum As Integer, nroTicket As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateAnulacionEnviada(objDocumento, idNum, nroTicket)
    End Sub

    Public Function GetListarTodasVentasProductosAcumulado(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarTodasVentasProductosAcumulado(be, tipoConsulta)
    End Function

    Public Function GetListarTodasVentasProductos(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarTodasVentasProductos(be, tipoConsulta)
    End Function

    Public Function GetListarTodasVentas(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarTodasVentas(be, tipoConsulta)
    End Function

    Public Function GetListarVentasPeriodoXTipoAnuladosDia(intIdEstablec As Integer, fechaLab As Date, tipo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPeriodoXTipoAnuladosDia(intIdEstablec, fechaLab, tipo)
    End Function

    Public Function GetListarNotaDeVentasDia(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarNotaDeVentasDia(be)
    End Function

    Public Function GrabarVentaEquivalencia(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarVentaEquivalencia(be)
    End Function

    Public Function GetVentasFiltroComprobanteCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasFiltroComprobanteCliente(be)
    End Function

    Public Function UpdatePedidoProforma(be As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdatePedidoProforma(be)
    End Function

    Public Function GetCobroPorCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCobroPorCliente(be)
    End Function

    Public Function GetVentasFiltroComprobante(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasFiltroComprobante(be)
    End Function

    Public Sub EliminarPagoDevolucion(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPagoDevolucion(be)
    End Sub

    Public Function GetVentaID(be As documento) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentaID(be)
    End Function

    Public Function SaveNotaCreditoFE(objDocumento As documento,
                                      nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveNotaCreditoFE(objDocumento, nDocumentoNota, nDocumentoSaldoVenta)
    End Function

    Public Sub GrabarDocumentoCajaDevolucionAnt(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDocumentoCajaDevolucionAnt(be)
    End Sub

    Public Sub CambiarEstadoNotaCreditoAnticipo(be As documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarEstadoNotaCreditoAnticipo(be)
    End Sub

    Public Function GrabarVentaDocumentoGeneral(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarVentaDocumentoGeneral(objDocumento)
    End Function

    Public Function GetCobrosByDocumento(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCobrosByDocumento(be)
    End Function

    Public Function GetVentaPorID(iDocuemnto As Integer) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentaPorID(iDocuemnto)
    End Function


    Public Function GetVentaxCobrarVenc(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentaxCobrarVenc(be, opcion)
    End Function

    Public Function GetComprasPorCobrarOpcion(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetComprasPorCobrarOpcion(be, opcion)
    End Function

    Public Function GetAcumuladoCuentasCobrarByAnio(be As documentoventaAbarrotes) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAcumuladoCuentasCobrarByAnio(be)
    End Function


    Public Function GetResumenAnualCuentasVenc(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetResumenAnualCuentasVenc(be)
    End Function

    Public Function GetResumenAnualCuentasCobrar(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetResumenAnualCuentasCobrar(be)
    End Function

    Public Function BoletasAnuladasPeriodo(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BoletasAnuladasPeriodo(fecha, tipodoc, ruc)
    End Function

    Public Function FacturasAnuladasPeriodo(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.FacturasAnuladasPeriodo(fecha, tipodoc, ruc)
    End Function

    Public Function NotasBoletasPeriodo(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.NotasBoletasPeriodo(fecha, tipodoc, ruc)
    End Function


    Public Function BoletasPeriodo(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BoletasPeriodo(fecha, tipodoc, ruc)
    End Function

    Public Function AlertaPSE(Empresa As String) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.AlertaPSE(Empresa)
    End Function

    Public Function ListarVentasTipoClientePeriodo(be As documentoventaAbarrotes, ListaTipo As List(Of String)) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarVentasTipoClientePeriodo(be, ListaTipo)
    End Function


    Public Function GetBuscarComprobante(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetBuscarComprobante(be)
    End Function

    Public Function GetListarRegistroVentasXTipo(intIdEstablec As Integer, strPeriodo As String, ListaTipo As List(Of String)) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarRegistroVentasXTipo(intIdEstablec, strPeriodo, ListaTipo)
    End Function


    Public Function GetListarRegistroNotasVentas(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarRegistroNotasVentas(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarRegistroVentas(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarRegistroVentas(intIdEstablec, strPeriodo)
    End Function

    Public Function GetVentasPorCriterio(be As documentoventaAbarrotes, criterio As String, valor As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasPorCriterio(be, criterio, valor)
    End Function

    Public Function GetNotaVentasPorFecha(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNotaVentasPorFecha(be, opcion)
    End Function

    Public Function GetVentasPorFechaConteo(be As documentoventaAbarrotes, opcion As String) As List(Of String)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasPorFechaConteo(be, opcion)
    End Function

    Public Function GetInventoryProductoID(idProducto As Integer, almacen As Integer) As usp_GetProductInventoryID_Result
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventoryProductoID(idProducto, almacen)
    End Function

    Public Function GetVentasPorFecha(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasPorFecha(be, opcion)
    End Function

    Public Function GetListarVentasPeriodoXTipoAnulados(intIdEstablec As Integer, strPeriodo As String, tipo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPeriodoXTipoAnulados(intIdEstablec, strPeriodo, tipo)
    End Function

    Public Function GetListarVentasPeriodoXTipo(IDempresa As String, intIdEstablec As Integer, strPeriodo As String, tipo As String, TipoConsulta As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPeriodoXTipo(IDempresa, intIdEstablec, strPeriodo, tipo, TipoConsulta)
    End Function

    Public Function GetListarVentasNotasPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasNotasPeriodo(intIdEstablec, strPeriodo)
    End Function


    Public Function SaveVentaNotaCredito2Electronica(objDocumento As documento,
                                      nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaNotaCredito2Electronica(objDocumento, nDocumentoNota, nDocumentoSaldoVenta)
    End Function

    Public Function BuscarDocumentosAnuladosFechaTicket(tipodoc As String, ruc As String, ticket As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarDocumentosAnuladosFechaTicket(tipodoc, ruc, ticket)
    End Function

    Public Sub ListaReenvioSunatAnulados(lista As List(Of documentoventaAbarrotes), nroticket As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListaReenvioSunatAnulados(lista, nroticket)
    End Sub

    Public Sub ValidarEnviosSunat(lista As List(Of documentoventaAbarrotes))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ValidarEnviosSunat(lista)
    End Sub

    Public Sub ListaReenvioSunatResumen(lista As List(Of documentoventaAbarrotes), nroTicket As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListaReenvioSunatResumen(lista, nroTicket)
    End Sub

    Public Function BuscarBoletasXTicketSunat(ticket As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarBoletasXTicketSunat(ticket)
    End Function

    Public Function BuscarBoletasXTicketSunatNotas(ticket As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarBoletasXTicketSunatNotas(ticket)
    End Function

    Public Function FacturaBajasPendiente(docVentaAbarrotes As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.FacturaBajasPendiente(docVentaAbarrotes)
    End Function

    Public Function BoletasBaja(docVentaAbarrotes As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BoletasBaja(docVentaAbarrotes)
    End Function

    Public Function BoletasBajaValidar(docVentaAbarrotes As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BoletasBajaValidar(docVentaAbarrotes)
    End Function

    Public Function FacturasBajasValidar(docVentaAbarrotes As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.FacturasBajasValidar(docVentaAbarrotes)
    End Function

    Public Function ResumenBoletasPendiente(docVentaAbarrotes As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenBoletasPendiente(docVentaAbarrotes)
    End Function

    Public Function BoletasPendientesEnvio(docVentaAbarrotes As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BoletasPendientesEnvio(docVentaAbarrotes)
    End Function

    Public Function NotasPendientesSunat(docVentaAbarrotes As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.NotasPendientesSunat(docVentaAbarrotes)
    End Function

    Public Function FacturasPendientesSunat(docVentaAbarrotes As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.FacturasPendientesSunat(docVentaAbarrotes)
    End Function

    Public Function TicketsXvalidarBajasFactura(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TicketsXvalidarBajasFactura(docVentaAbarrotes)
    End Function

    Public Function TicketsXvalidar(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TicketsXvalidar(docVentaAbarrotes)
    End Function

    Public Function TicketsXvalidarNotasBoleta(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TicketsXvalidarNotasBoleta(docVentaAbarrotes)
    End Function

    Public Function TicketsXvalidarBajasBoletas(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TicketsXvalidarBajasBoletas(docVentaAbarrotes)
    End Function

    Public Function BuscarBoletasAnuladas(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarBoletasAnuladas(fecha, IdEmpresa)
    End Function

    Public Function BuscarFacturanoEnviadasPeriodo(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarFacturanoEnviadasPeriodo(fecha, tipoDoc, idEmpresa)
    End Function

    Public Sub UpdateFacturasXEstado(iddoc As Integer, estado As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateFacturasXEstado(iddoc, estado)
    End Sub

    Public Function Grabar_VentaNotaSinInventario(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Grabar_VentaNotaSinInventario(objDocumento)
    End Function

    Public Function GrabarVentaSinIventario(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarVentaSinIventario(listaDocumento)
    End Function

    Public Sub ListaEnvioSunatAnulados(lista As List(Of documentoventaAbarrotes), nroticket As String, idNum As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListaEnvioSunatAnulados(lista, nroticket, idNum)
    End Sub

    Public Function BuscarDocumentosAnuladosFecha(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarDocumentosAnuladosFecha(fecha, tipodoc, ruc)
    End Function

    Public Sub UpdateEnvioSunat(iddoc As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateEnvioSunat(iddoc)
    End Sub

    Public Sub PrepararEntregaVenta(documentoventaAbarrotes As documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.PrepararEntregaVenta(documentoventaAbarrotes)
    End Sub

    Public Function GetVentasStatusPreparacionAlmacen(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasStatusPreparacionAlmacen(be)
    End Function

    Public Function GetUbicar_NotaXID(idDocumento As Integer) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_NotaXID(idDocumento)
    End Function

    Public Function BuscarDocumentosFecha(fecha As DateTime, tipodoc As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarDocumentosFecha(fecha, tipodoc)
    End Function

    Public Function BuscarNotasXDocumento(idDoc As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarNotasXDocumento(idDoc)
    End Function

    Public Sub ListaEnvioSunat(lista As List(Of documentoventaAbarrotes))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListaEnvioSunat(lista)
    End Sub

    Public Sub ListaEnvioSunatResumen(lista As List(Of documentoventaAbarrotes), idNum As Integer, nroTicket As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListaEnvioSunatResumen(lista, idNum, nroTicket)
    End Sub

    Public Function NotasCreditoBoleta(fecha As DateTime, tipoDoc As String, IdEmpresa As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.NotasCreditoBoleta(fecha, tipoDoc, IdEmpresa)
    End Function

    Public Function BuscarFacturanoEnviadas(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarFacturanoEnviadas(fecha, tipoDoc, idEmpresa)
    End Function

    Public Function Grabar_VentaNotaSinLote(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Grabar_VentaNotaSinLote(objDocumento)
    End Function

    Public Function Grabar_VentaEspecialSinLote(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Grabar_VentaEspecialSinLote(listaDocumento)
    End Function

    Public Function Grabar_VentaEspecialExistencia(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Grabar_VentaEspecialExistencia(listaDocumento)
    End Function

    Public Sub CobrarVentaJiuni(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CobrarVentaJiuni(be)
    End Sub

    Public Sub CobrarVentaEspecial(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CobrarVentaEspecial(be)
    End Sub

    Public Function Grabar_VentaEspecial(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Grabar_VentaEspecial(listaDocumento)
    End Function

    Public Sub GetActualizarImpresion(be As documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetActualizarImpresion(be)
    End Sub

    Public Function Grabar_VentaNota(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Grabar_VentaNota(objDocumento)
    End Function

    Public Function GenerarComprobanteVenta(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GenerarComprobanteVenta(objDocumento)
    End Function

    Public Sub AnularNotaVenta(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.AnularNotaVenta(documentoBE)
    End Sub

    Public Function GetListarNotaDeVentasPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarNotaDeVentasPeriodo(intIdEstablec, strPeriodo)
    End Function

    Public Sub GrabarFacReconocimiento(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarFacReconocimiento(objDocumento)
    End Sub

    Public Function GetListarRetenciones(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarRetenciones(intIdEstablec, strPeriodo)
    End Function

    Public Function SaveRetencion(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveRetencion(objDocumento)
    End Function

    Public Sub CobrarVentaRapida(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CobrarVentaRapida(be)
    End Sub

    Public Sub CobrarVentaRapidaEspecal(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CobrarVentaRapidaEspecal(be)
    End Sub

    Public Function Grabar_Venta(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Grabar_Venta(objDocumento)
    End Function

    Function GetListarVentasPorAnio2(empresa As String, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPorAnio2(empresa, strPeriodo)
    End Function

    Public Function getListaServiosXVenta(be As InventarioMovimiento, fechaini As DateTime, fechafin As DateTime, tipo As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaServiosXVenta(be, fechaini, fechafin, tipo)
    End Function

    Public Function GetVentasDelDiaXTipoVenta(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasDelDiaXTipoVenta(be)
    End Function

    Public Sub EliminarVenta(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarVenta(documentoBE)
    End Sub

    Function GetCuentasXPagarTodoClientes(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As Date, intmoneda As String, estadocobro As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasXPagarTodoClientes(strEmpresa, intIdEstablecimiento, strPeriodo, intmoneda, estadocobro)
    End Function

    Public Function StockEliminarNotaVenta(idDocVenta As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.StockEliminarNotaVenta(idDocVenta)
    End Function

    Public Function TieneClientesApertura(be As documentoventaAbarrotes) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TieneClientesApertura(be)
    End Function

    Public Function UpdateCotizacion(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateCotizacion(objDocumento)
    End Function

    Public Function GenerarTXTventa(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GenerarTXTventa(intIdEstablec, strPeriodo)
    End Function

    Public Function UbicarVentaPorCompensar(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, intmoneda As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorCompensar(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, intmoneda)
    End Function

    Public Function CompensacionDocumentosVenta(objDocumento As documento, objDoc As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CompensacionDocumentosVenta(objDocumento, objDoc)
    End Function

    Public Function ListadoComprobateVentaNotasXidPadre(iNtPadre As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoComprobateVentaNotasXidPadre(iNtPadre)
    End Function

    Public Function UbicarVentaPorClienteXperiodo2Ant(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As String, intmoneda As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorClienteXperiodo2Ant(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, intmoneda)
    End Function

    Public Function GetVentasByFecha(intIdEstablec As Integer, fecha As Date) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasByFecha(intIdEstablec, fecha)
    End Function

    Public Sub CambiarPeriodoVenta(be As documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarPeriodoVenta(be)
    End Sub

    Public Function UbicarTodosVentaPorClienteMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarTodosVentaPorClienteMNME(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function ListacajausuarioXDetalleAcumulado(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListacajausuarioXDetalleAcumulado(intIdPersona, fechaInicio, fechaFin)
    End Function

    Public Function CobrosGenerales() As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CobrosGenerales()
    End Function

    Public Function ListacajausuarioXCuentasXcobrar(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListacajausuarioXCuentasXcobrar(intIdPersona, fechaInicio, fechaFin)
    End Function

    Public Function ListacajausuarioXCuentasXCompra(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListacajausuarioXCuentasXCompra(intIdPersona, fechaInicio, fechaFin)
    End Function

    Public Function GetSumaVentasDelDia(be As documentoventaAbarrotes) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaVentasDelDia(be)
    End Function

    Public Function GetSumaVentasDelDiaAllEmpresa(be As documentoventaAbarrotes) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaVentasDelDiaAllEmpresa(be)
    End Function

    Public Sub GrabarVentaMultiEmpresa(listadoDocVenta As List(Of documento))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarVentaMultiEmpresa(listadoDocVenta)
    End Sub

    Public Function UbicarVentaPorClienteMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorClienteMNME(strEmpresa, intIdEstablecimiento, strRuc)
    End Function

    Public Function UbicarCuentaCobrarComercial(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCuentaCobrarComercial(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function UbicarCobrosPorTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCobrosPorTodo(strEmpresa, intIdEstablecimiento, strMoneda)
    End Function

    Public Function UbicarCobrosPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMoneda As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCobrosPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strPeriodo, strMoneda)
    End Function

    Public Function UbicarCobrosPorClienteTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String, idprov As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCobrosPorClienteTodo(strEmpresa, intIdEstablecimiento, strMoneda, idprov, strPeriodo)
    End Function

    Public Sub ConfirmarVentaTicketConsumoDirecto(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmarVentaTicketConsumoDirecto(objDocumento)
    End Sub

    Public Function SaveVentaPSPinturas(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaPSPinturas(objDocumento)
    End Function

    Public Function UpdateVentaPS(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateVentaPS(objDocumento, objTotalesAlmacen)
    End Function

    Public Function GetListarAllVentasPeriodoAnulado(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasAnuladas(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarAllVentasPorCliente(objDocumento As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasPorCliente(objDocumento)
    End Function

    Public Function GetArticulosVendidosByDia(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetArticulosVendidosByDia(be)
    End Function

    Public Function GetListarAllVentasPeriodoXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasPeriodoXUsuario(documentoventaAbarrotesBE)
    End Function

    Public Function GetListarAllVentasDiaXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasDiaXUsuario(documentoventaAbarrotesBE)
    End Function

    Public Function GetListarAllCotizacionXPeriodoXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllCotizacionXPeriodoXUsuario(documentoventaAbarrotesBE)
    End Function

    Public Function GetListarAllCotizacionXDiaXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllCotizacionXDiaXUsuario(documentoventaAbarrotesBE)
    End Function


    Public Function GetArticulosVendidosByMes(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetArticulosVendidosByMes(be)
    End Function

    Public Sub GetConfirmarAlertaventa(be As documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetConfirmarAlertaventa(be)
    End Sub

    Public Function ListadoventasObservadasChild(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoventasObservadasChild(be)
    End Function

    Public Function GetRentabilidadPorPeriodo(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRentabilidadPorPeriodo(be)
    End Function

    Public Function GetRentabilidadPorDia(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRentabilidadPorDia(be)
    End Function

    Public Function GetVentasPeriodoByClienteConteo(be As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasPeriodoByClienteConteo(be)
    End Function

    Public Function SaveVentaCobrada(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaCobrada(objDocumento)
    End Function

    Public Function GrabarCotizacion(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarCotizacion(objDocumento)
    End Function

    Public Function GetventasDeApertura(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetventasDeApertura(be)
    End Function

    Public Function GetCuentasPorCobrarInicio(be As documentoventaAbarrotes) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasPorCobrarInicio(be)
    End Function

    Public Function ListadoventasObservadasConteo(be As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoventasObservadasConteo(be)
    End Function

    Public Function ListadoventasObservadas(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoventasObservadas(be)
    End Function

    Public Function VentasCantidadStock(cantidad As String, fechaini As Date, fechafin As Date, mayor As Decimal, menor As Decimal) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.VentasCantidadStock(cantidad, fechaini, fechafin, mayor, menor)
    End Function

    Public Function GetListarAllNotasPedido(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllNotasPedido(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarCotizaciones(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarCotizaciones(intIdEstablec, strPeriodo)
    End Function

    Public Function GetConteoPedidos(intIdEstablec As Integer, strPeriodo As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConteoPedidos(intIdEstablec, strPeriodo)
    End Function

    Public Function SaveVentaTicketPS(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaTicketPS(objDocumento, objTotalesAlmacen)
    End Function

    Public Sub EliminarNotaCreditoMetodoVenta(obj As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarNotaCreditoMetodoVenta(obj)
    End Sub

    Public Sub EliminarNotaDebitoVenta(obj As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarNotaDebitoVenta(obj)
    End Sub

    Public Function UbicarExcedenteVentaPorClienteXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As String, intmoneda As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarExcedenteVentaPorClienteXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, intmoneda)
    End Function

    Public Function UbicarVentaPorClienteXperiodo2(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As DateTime, intmoneda As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorClienteXperiodo2(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, intmoneda)
    End Function

    Public Function SaveVentaNotaCredito2(objDocumento As documento,
                                      nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaNotaCredito2(objDocumento, nDocumentoNota, nDocumentoSaldoVenta)
    End Function

    Public Function SaveVentaNotaDebito(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaNotaDebito(objDocumento)
    End Function

    Public Sub GrabarCuetasPorCobrarApertura(be As List(Of documento))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCuetasPorCobrarApertura(be)
    End Sub

    Public Function GrabarVentaGeneral(objDocumento As documento) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarVentaGeneral(objDocumento)
    End Function

    Public Function GetListarAllVentasxDia(intIdEstablec As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasxDia(intIdEstablec)
    End Function

    Public Function GetListarVentasNormalPorDia(intIdEstablec As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasNormalPorDia(intIdEstablec)
    End Function


    Public Function GetListarVentasNormalPorDiaCredito(intIdEstablec As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasNormalPorDiaCredito(intIdEstablec)
    End Function

    Public Function GetListarAllVentasPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasPeriodo(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarAllVentasPeriodoPendiente(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasPeriodoPendiente(intIdEstablec, strPeriodo)
    End Function


    Public Function GetListarAllVentasPeriodoPendienteEspecial(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasPeriodoPendienteEspecial(intIdEstablec, strPeriodo)
    End Function

    Public Function GetVentasPeriodoByCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasPeriodoByCliente(be)
    End Function

    Public Function SaveVentaNormalServicioCredito(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaNormalServicioCredito(objDocumento)
    End Function

    Public Function GetListarVentasNormalPorPeriodoCredito(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasNormalPorPeriodoCredito(intIdEstablec, strPeriodo)
    End Function

    Public Sub UpdateVentaNormalServicioCredito(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateVentaNormalServicioCredito(objDocumento)
    End Sub


    Public Function OntenerVentasAnuales(intIdEstablecimiento As String, anio As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerVentasAnuales(intIdEstablecimiento, anio)
    End Function


    Public Function ListadoVentaClienteArticulo(idclie As Integer, nameArt As String, fecINic As DateTime, fecHasta As DateTime) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoVentaClienteArticulo(idclie, nameArt, fecINic, fecHasta)
    End Function

    Public Function ListadoNotasXCliente(fecINic As Date, fecHasta As Date, idProv As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.LidtadoNotasXCliente(fecINic, fecHasta, idProv)
    End Function

    Public Sub ConfirmarVentaTicketSL(objDocumento As documento, objDocumentoCaja As documento,
                                   objTotalesAlmacen As List(Of totalesAlmacen),
                                   cajaUsuario As cajaUsuario, ndocAnticipoDetalle As documentoAnticipoDetalle,
                                   cajaUsuarioAporte As documento, objDocCajaDetalle As List(Of documentoCajaDetalle))

        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmarVentaTicketSL(objDocumento, objDocumentoCaja, objTotalesAlmacen, cajaUsuario, ndocAnticipoDetalle, cajaUsuarioAporte, objDocCajaDetalle)
    End Sub


    Public Function GetVentasAnuales(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasAnuales(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetSumaCuentasXCobrar(intIdEstable As Integer, intNumero As Integer) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaCuentasXCobrar(intIdEstable, intNumero)
    End Function

    Public Function GetListarVentasPorCategoria(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPorCategoria(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarVentasPorAnio(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPorAnio(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function SaveVentaNormalServicio(objDocumento As documento, objDocumentoCaja As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaNormalServicio(objDocumento, objDocumentoCaja)
    End Function

    Public Sub UpdateVentaNormalServicio(objDocumento As documento, objDocumentoCaja As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateVentaNormalServicio(objDocumento, objDocumentoCaja)
    End Sub

    Public Sub UpdateVentaNormalContado(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateVentaNormalContado(objDocumento, listaTotales, objDeleteTotales, objDocumentoCaja)
    End Sub

    Public Function SaveVentaNormalAlContado(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objDocumentoCaja As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaNormalAlContado(objDocumento, objTotalesAlmacen, objDocumentoCaja)
    End Function

    Public Function Grabar_VentaList(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Grabar_VentaList(listaDocumento)
    End Function

    Public Function GetListarVentasPorPeriodoCobrados(intIdEstablec As Integer, strPeriodo As String, strTipoVenta As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPorPeriodoCobrados(intIdEstablec, strPeriodo, strTipoVenta)
    End Function

    Public Sub DeleteVentaTicketXitem(ByVal documentoBE As documento, objTotalBorrar As totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteVentaTicketXitem(documentoBE, objTotalBorrar)
    End Sub

    Public Function SaveVentaNormalAlCredito(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaNormalAlCredito(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveCompraNotaCreditoVenta(objDocumento As documento, nListaTotalesAlmacen As List(Of totalesAlmacen),
                                        nDocumentoNota As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraNotaCreditoVenta(objDocumento, nListaTotalesAlmacen, nDocumentoNota)
    End Function

    Public Function GetListarNotasPorIdVentaPadre(intIDoCumento As Integer, strTipoNota As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarNotasPorIdVentaPadre(intIDoCumento, strTipoNota)
    End Function

    Public Function DocumentoCanceladoVenta(intIdDocumento As Integer) As String
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoCanceladoVenta(intIdDocumento)
    End Function

    Public Function GetListarVentasPorDiaEstablecimiento(be As documentoventaAbarrotes, Optional UsuarioCaja As String = Nothing) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPorDiaEstablecimiento(be, UsuarioCaja)
    End Function

    Public Function SaveOtrasSalidas(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveOtrasSalidas(objDocumento, objTotalesAlmacen)
    End Function

    Public Sub UpdateOtrasSalidas(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateOtrasSalidas(objDocumento, listaTotales, objDeleteTotales)
    End Sub

    Public Function GetUbicar_documentoventaAbarrotesPorID(idDocumento As Integer) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
    End Function

    Public Function SaveVentaTicket(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaTicket(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveVentaALCredito(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaALCredito(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveVentaPagada(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objDocumentoCaja As documento,
                                    cajaUsuario As cajaUsuario) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaPagada(objDocumento, objTotalesAlmacen, objDocumentoCaja, cajaUsuario)
    End Function

    Public Function SaveVentaDirectaTicket(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen),
                                         objDocumentoCaja As documento, cajaUsuario As cajaUsuario) As Integer

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaDirectaTicket(objDocumento, objTotalesAlmacen, objDocumentoCaja, cajaUsuario)
    End Function

    Public Sub UpdateVentaTicket(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateVentaTicket(objDocumento, listaTotales, objDeleteTotales)
    End Sub

    Public Function UpdateVentaALCredito(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateVentaALCredito(objDocumento, listaTotales, objDeleteTotales)
    End Function

    Public Function UpdateVentaPagada(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento,
                                      nCajaUsuarioMontos As cajaUsuario, nCajaUsuarioEliminar As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateVentaPagada(objDocumento, listaTotales, objDeleteTotales, objDocumentoCaja, nCajaUsuarioMontos, nCajaUsuarioEliminar)
    End Function

    Public Function UpdateVentaDirectaTicket(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento,
                                             nCajaUsuarioMontos As cajaUsuario, nCajaUsuarioEliminar As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateVentaDirecta(objDocumento, listaTotales, objDeleteTotales, objDocumentoCaja, nCajaUsuarioMontos, nCajaUsuarioEliminar)
    End Function

    Public Function GetListarVentasPorPeriodo(intIdProyecto As Integer, strPeriodo As String, strTipoVenta As String, Optional UsuarioCaja As String = Nothing) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPorPeriodo(intIdProyecto, strPeriodo, strTipoVenta, UsuarioCaja)
    End Function

    Public Function UbicarVentaPorClienteXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorClienteXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Sub UpdateVentaNormal(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateVentaNormal(objDocumento, listaTotales, objDeleteTotales)
    End Sub

    Public Function GetListarVentasNormalPorPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasNormalPorPeriodo(intIdEstablec, strPeriodo)
    End Function

    Function GetListarVentasPorPeriodo_CONT(strPeriodo As String, strTipoVenta As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPorPeriodo_CONT(strPeriodo, strTipoVenta)
    End Function

    Public Function GetListarVentasPorPeriodoGeneral(intIdProyecto As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPorPeriodoGeneral(intIdProyecto, strPeriodo)
    End Function

    Public Function GetListarVentasPorPeriodoGeneral_CONT(strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarVentasPorPeriodoGeneral_CONT(strPeriodo)
    End Function

    Public Function GetObtenerVentaPorNumero(intIdEstablecimiento As Integer, strPeriodo As String, strTipoVenta As String,
                                             strTipoDoc As String, strSerie As String, strNumDoc As String) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerVentaPorNumero(intIdEstablecimiento, strPeriodo, strTipoVenta, strTipoDoc, strSerie, strNumDoc)
    End Function

    Public Function GetObtenerVentaPorNumeroComprobante(ntIdEstablecimiento As Integer, strPeriodo As String, strTipoVenta As String,
                                             strTipoDoc As String, strNumDoc As String) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerVentaPorNumeroComprobante(ntIdEstablecimiento, strPeriodo, strTipoVenta, strTipoDoc, strNumDoc)
    End Function

    Public Sub ConfirmarVentaTicket(objDocumento As documento, objDocumentoCaja As documento,
                                     objTotalesAlmacen As List(Of totalesAlmacen),
                                     cajaUsuario As cajaUsuario)

        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmarVentaTicket(objDocumento, objDocumentoCaja, objTotalesAlmacen, cajaUsuario)
    End Sub

    Public Function SaveRegistroHonorariosVenta(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveRegistroHonorariosVenta(objDocumento)
    End Function



    Public Function GetListarAllVentasGeneralesPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasGeneralesPeriodo(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarAllVentasGeneralAprobado(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasGeneralAprobado(intIdEstablec, strPeriodo)
    End Function

    Public Function SaveVentaCobradaContado(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveVentaCobradaContado(objDocumento)
    End Function

    Public Function GrabarVentaGeneralCredito(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarVentaGeneralCredito(objDocumento)
    End Function


    Public Function ListaTotalXVenta(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As Integer, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentoventaAbarrotes
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaTotalXVenta(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio, intMes, intDia)
    End Function

    Public Function GetListarAllVentasInformeGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime, pago As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasInformeGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin, pago)
    End Function

    Public Function GetConteoPedidosAprobado(intIdEstablec As Integer, strPeriodo As String, strTipo As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConteoPedidosAprobado(intIdEstablec, strPeriodo, strTipo)
    End Function

    Public Function UbicarVentaPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, tipo)
    End Function

    Public Function UbicarVentaPorProveedorXperiodoFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarVentaPorProveedorXperiodoFull(strEmpresa, intIdEstablecimiento, strPeriodo, tipo)
    End Function

    Public Function ListadoVentaClienteOrAnticulo(strIdEmpresa As String, intEstablec As Integer, idclie As Integer, nameArt As String, fecINic As DateTime, fecHasta As DateTime, tipo As String) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoVentaClienteOrAnticulo(strIdEmpresa, intEstablec, idclie, nameArt, fecINic, fecHasta, tipo)
    End Function

    Public Function GetListarAllVentasPorDIa(objDocumento As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasPorDIa(objDocumento)
    End Function

    Public Function CobrosxDocumentoImpresion(iNtPadre As Integer) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CobrosxDocumentoImpresion(iNtPadre)
    End Function

#Region "Restaurant"
    Public Function GetListaVentaID(be As documento) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaVentaID(be)
    End Function

    Public Function GrabarVentaEquivalenciaXListaDoc(be As List(Of documento)) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarVentaEquivalenciaXListaDoc(be)
    End Function

    Public Function GetListarAllVentasPeriodoPendienteInfra(intIdEstablec As Integer, strPeriodo As String, listaIdDistribucion As List(Of String)) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasPeriodoPendienteInfra(intIdEstablec, strPeriodo, listaIdDistribucion)
    End Function

    Public Function GetListarAllVentasXIdDistribucion(distribucionBE As distribucionInfraestructura) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasXIdDistribucion(distribucionBE)
    End Function

    Public Function GetImprimirPedido(distribucionBE As documento) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetImprimirPedido(distribucionBE)
    End Function

    Public Function GetImprimirPrecuenta(distribucionBE As documento) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetImprimirPrecuenta(distribucionBE)
    End Function

    Public Function ListaClienteActivo(i As entidad) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaClienteActivo(i)
    End Function

    Public Function GrabarVentaEquivalenciaXInfraMasivo(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarVentaEquivalenciaXInfraMasivo(be)
    End Function

    Public Function GrabarVentaEquivalenciaXInfra(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarVentaEquivalenciaXInfra(be)
    End Function

    Public Function GrabarVentaEquivalenciaXPedido(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarVentaEquivalenciaXPedido(be)
    End Function

    Function GetListaPedidosXCliente(documentoVentaBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaPedidosXCliente(documentoVentaBE)
    End Function

#End Region

End Class
