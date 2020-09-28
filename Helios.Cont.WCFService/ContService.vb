Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Business.Logic
Imports Helios.Cont.WCFService.ServiceContract

<ServiceBehaviorAttribute(InstanceContextMode:=InstanceContextMode.PerCall, ConcurrencyMode:=ConcurrencyMode.Multiple)>
Public Class ContService
    Implements IContService

#Region "DEPURADO"
#Region "COMPRAS"
    Public Function GetListarComprasPorDia_CONT(documentocompraBE As documentocompra) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasPorDia_CONT
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorDia_CONT(documentocompraBE)
    End Function


    Public Function GetListarComprasPorDia_CONT_CONTADO(documentocompraBE As documentocompra, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra) Implements IContService.GetListarComprasPorDia_CONT_CONTADO
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorDia_CONT_CONTADO(documentocompraBE, UsuarioCaja)
    End Function



#End Region

#Region "FINANZAS"
    Public Function ObtenerEstadosFinancierosPorEstablecimiento(estadoFinancieroBE As estadosFinancieros) As System.Collections.Generic.List(Of Business.Entity.estadosFinancieros) Implements ServiceContract.IContService.ObtenerEstadosFinancierosPorEstablecimiento
        Dim efBL As New estadosFinancierosBL
        Return efBL.ObtenerEstadosFinancierosPorEstablecimiento(estadoFinancieroBE)
    End Function
#End Region

#End Region

    Public Function GetListarComprasPorDia_CONT_CREDITO(intIdEstablecimiento As Integer, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra) Implements IContService.GetListarComprasPorDia_CONT_CREDITO
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorDia_CONT_CREDITO(intIdEstablecimiento, UsuarioCaja)
    End Function

    Public Sub GrabarListaDeItemTipo(lista As List(Of item)) Implements IContService.GrabarListaDeItemTipo
        Dim notaBL As New itemBL
        notaBL.GrabarListaDeItemTipo(lista)
    End Sub

    Public Function GetCuentasPagarReclamacionesClientes(parametro As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetCuentasPagarReclamacionesClientes
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetCuentasPagarReclamacionesClientes(parametro)
    End Function

    Public Function GrabarReclamacionCompromiso(objDocumento As documento) As Integer Implements IContService.GrabarReclamacionCompromiso
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarReclamacionCompromiso(objDocumento)
    End Function

    Public Function ObtenerSaldoReclamacion(idanticipo As Integer) As documentoAnticipo Implements IContService.ObtenerSaldoReclamacion
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.ObtenerSaldoReclamacion(idanticipo)
    End Function

    Public Function GetReclamacionesXClientes(parametro As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetReclamacionesXClientes
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetReclamacionesXClientes(parametro)
    End Function

    Public Function GetReclamacionesStatusCompras(be As documentocompra) As List(Of documentoAnticipo) Implements IContService.GetReclamacionesStatusCompras
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetReclamacionesStatusCompras(be)
    End Function

    Public Function GrabarReclamacionCompromisoCobro(objDocumento As documento) As Integer Implements IContService.GrabarReclamacionCompromisoCobro
        Dim ventaBL As New documentocompraBL
        Return ventaBL.GrabarReclamacionCompromisoCobro(objDocumento)
    End Function

    Public Function GetReclamacionesStatusVenta(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetReclamacionesStatusVenta
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetReclamacionesStatusVenta(be)
    End Function

    Public Sub CambiarEstadoRecCompra(be As documentocompra) Implements IContService.CambiarEstadoRecCompra
        Dim notaBL As New documentoventaAbarrotesBL
        notaBL.CambiarEstadoRecCompra(be)
    End Sub

    Public Function ObtenerSaldoReclamacionCobro(idanticipo As Integer) As documentoAnticipo Implements IContService.ObtenerSaldoReclamacionCobro
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.ObtenerSaldoReclamacionCobro(idanticipo)
    End Function

    Public Function GetCuentasCobrarReclamacionesSoloProveedor(parametro As documentocompra) As List(Of documentocompra) Implements IContService.GetCuentasCobrarReclamacionesSoloProveedor
        Dim ventaBL As New documentocompraBL
        Return ventaBL.GetCuentasCobrarReclamacionesSoloProveedor(parametro)
    End Function

    Public Function GetCuentasCobrarReclamacionesProveedor(parametro As documentocompra) As List(Of documentocompra) Implements IContService.GetCuentasCobrarReclamacionesProveedor
        Dim ventaBL As New documentocompraBL
        Return ventaBL.GetCuentasCobrarReclamacionesProveedor(parametro)
    End Function

    Public Function DocumentoAfectadoNC(be As documentoventaAbarrotes) As documentoventaAbarrotes Implements IContService.DocumentoAfectadoNC
        Dim documentoventaAbarrotesBL As New documentoventaAbarrotesBL
        Return documentoventaAbarrotesBL.DocumentoAfectadoNC(be)
    End Function

    Public Function GetCompromisoXDocumento(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetCompromisoXDocumento
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetCompromisoXDocumento(be)
    End Function

    Public Function ObtenerSaldoAnticipoV2Compra(idanticipo As Integer) As documentoAnticipo Implements IContService.ObtenerSaldoAnticipoV2Compra
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.ObtenerSaldoAnticipoV2Compra(idanticipo)
    End Function

    Public Function GetPaySaldoCaja(Be As estadosFinancierosConfiguracionPagos) As estadosFinancierosConfiguracionPagos Implements IContService.GetPaySaldoCaja
        Dim compraBL As New estadosFinancierosConfiguracionPagosBL
        Return compraBL.GetPaySaldoCaja(Be)
    End Function

    Public Function GetAnticiposOtorgadosStatusAll(be As documentocompra) As List(Of documentoAnticipo) Implements IContService.GetAnticiposOtorgadosStatusAll
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetAnticiposOtorgadosStatusAll(be)
    End Function

    Public Function GetAnticipoRecibidosStatusAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetAnticipoRecibidosStatusAll
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetAnticipoRecibidosStatusAll(be)
    End Function

    Public Function GetANTReclamacionesStatusCompra(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.GetANTReclamacionesStatusCompra
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesStatusCompra(be)
    End Function


    Public Sub CambiarEstadoNotaCreditoAnticipoCompra(be As documentocompra) Implements IContService.CambiarEstadoNotaCreditoAnticipoCompra
        Dim notaBL As New documentoventaAbarrotesBL
        notaBL.CambiarEstadoNotaCreditoAnticipoCompra(be)
    End Sub

    Public Function GrabarCompraDocumentoGeneral(objDocumento As documento) As Integer Implements IContService.GrabarCompraDocumentoGeneral
        Dim ventaBL As New documentocompraBL
        Return ventaBL.GrabarCompraDocumentoGeneral(objDocumento)
    End Function

    Public Function HistorialDeCobranza(iNtPadre As Integer) As List(Of documentoventaAbarrotes) Implements IContService.HistorialDeCobranza

        Dim notaBL As New documentoventaAbarrotesBL
        Return notaBL.HistorialDeCobranza(iNtPadre)

    End Function

    Public Function GetANTReclamacionesPeriodoCompra(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.GetANTReclamacionesPeriodoCompra
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesPeriodoCompra(be)
    End Function


    Public Function DocumentoCompraAfectadoNC(be As documentocompra) As documentocompra Implements IContService.DocumentoCompraAfectadoNC
        Dim documentocomprasBL As New documentocompraBL
        Return documentocomprasBL.DocumentoCompraAfectadoNC(be)
    End Function

    Public Function SaveNotaCreditoCompraFE(objDocumento As documento, nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer Implements IContService.SaveNotaCreditoCompraFE
        Dim ventaBL As New documentocompraBL
        Return ventaBL.SaveNotaCreditoCompraFE(objDocumento, nDocumentoNota, nDocumentoSaldoVenta)
    End Function

    Public Sub PagoCompensacionVentas(objDocumento As documento) Implements IContService.PagoCompensacionVentas
        Dim cajabL As New documentoCajaBL
        cajabL.PagoCompensacionVentas(objDocumento)
    End Sub

    Public Sub GrabarDocumentoCajaDevolucionAntOtor(be As documento) Implements IContService.GrabarDocumentoCajaDevolucionAntOtor
        Dim notaBL As New documentoventaAbarrotesBL
        notaBL.GrabarDocumentoCajaDevolucionAntOtor(be)
    End Sub

    Public Function GetDevolucionAntSeguimientoCompra(be As documentocompra) As List(Of documentoAnticipo) Implements IContService.GetDevolucionAntSeguimientoCompra
        Dim notaBL As New documentoAnticipoBL
        Return notaBL.GetDevolucionAntSeguimientoCompra(be)
    End Function

    Public Function GetDevolucionesByDocumentoNotaCompra(be As documentocompra) As List(Of documentoAnticipo) Implements IContService.GetDevolucionesByDocumentoNotaCompra
        Dim notaBL As New documentoAnticipoBL
        Return notaBL.GetDevolucionesByDocumentoNotaCompra(be)
    End Function

    Public Function GetDevolucionVentaSeguimiento(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetDevolucionVentaSeguimiento
        Dim notaBL As New documentoAnticipoBL
        Return notaBL.GetDevolucionVentaSeguimiento(be)
    End Function

    Public Sub GrabarDocumentoCajaDevolucionCobro(be As documento) Implements IContService.GrabarDocumentoCajaDevolucionCobro
        Dim notaBL As New documentocompraBL
        notaBL.GrabarDocumentoCajaDevolucionCobro(be)
    End Sub

    Public Sub updatePredeterminado(datoGeneralBE As datosGenerales) Implements IContService.updatePredeterminado
        Dim datosGeneralesBL As New datosGeneralesBL
        datosGeneralesBL.updatePredeterminado(datoGeneralBE)
    End Sub

    Public Function GetDevolucionCompraSeguimiento(be As documentocompra) As List(Of documentoAnticipo) Implements IContService.GetDevolucionCompraSeguimiento
        Dim notaBL As New documentoAnticipoBL
        Return notaBL.GetDevolucionCompraSeguimiento(be)
    End Function

    Public Function GetMovimientosKardexByExistencia(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento) Implements IContService.GetMovimientosKardexByExistencia
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetMovimientosKardexByExistencia(be, cierre)
    End Function

    Public Sub ConfirmarPagoTarjeta(iddoc As Integer, fecha As Date) Implements IContService.ConfirmarPagoTarjeta
        Dim compraBL As New documentoCajaBL
        compraBL.ConfirmarPagoTarjeta(iddoc, fecha)
    End Sub

    Public Function GetPagosTarjetaxConfirmar(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetPagosTarjetaxConfirmar
        Dim ventaBL As New documentoCajaBL
        Return ventaBL.GetPagosTarjetaxConfirmar(be)

    End Function

    Public Function SaveNotaCreditoFE(objDocumento As documento, nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer Implements IContService.SaveNotaCreditoFE
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.SaveNotaCreditoFE(objDocumento, nDocumentoNota, nDocumentoSaldoVenta)
    End Function

    Public Function GetBusquedaAvanzadaProductosSinAlmacen(be As detalleitems, caso As String) As List(Of totalesAlmacen) Implements IContService.GetBusquedaAvanzadaProductosSinAlmacen
        Dim precioCompraBL As New totalesAlmacenBL
        Return precioCompraBL.GetBusquedaAvanzadaProductosSinAlmacen(be, caso)
    End Function

    Public Sub EliminarImpresion(datoGeneralBE As datosGenerales) Implements IContService.EliminarImpresion
        Dim datosGeneralesBL As New datosGeneralesBL
        datosGeneralesBL.EliminarImpresion(datoGeneralBE)
    End Sub

    Public Function GetArticulosSinAlmacenSearchCodigo(empresa As String, search As String) As List(Of detalleitems) Implements IContService.GetArticulosSinAlmacenSearchCodigo
        Dim productoBL As New detalleitemsBL
        Return productoBL.GetArticulosSinAlmacenSearchCodigo(empresa, search)
    End Function

    Public Function GetListarRegistroVentasXTipo(intIdEstablec As Integer, strPeriodo As String, ListaTipo As List(Of String)) As List(Of documentoventaAbarrotes) Implements IContService.GetListarRegistroVentasXTipo
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarRegistroVentasXTipo(intIdEstablec, strPeriodo, ListaTipo)
    End Function

    Public Function UbicaEmpresaFull(datosgerales As datosGenerales) As List(Of datosGenerales) Implements ServiceContract.IContService.UbicaEmpresaFull
        Dim establecBL As New datosGeneralesBL()
        Return establecBL.UbicaEmpresaFull(datosgerales)
    End Function

    Public Function GetListarRegistroVentas(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarRegistroVentas
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarRegistroVentas(intIdEstablec, strPeriodo)
    End Function


    Public Function UbicarAnticiposProveedor(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentoCaja) Implements IContService.UbicarAnticiposProveedor
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.UbicarAnticiposProveedor(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function ObtenerAnticipoDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle) Implements IContService.ObtenerAnticipoDetails
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerAnticipoDetails(strDocumentoAfectado)
    End Function


    Public Function GetUbicar_documentoAnticipoPorID(intIdDocumento As Integer) As documentoCaja Implements IContService.GetUbicar_documentoAnticipoPorID
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.GetUbicar_documentoAnticipoPorID(intIdDocumento)
    End Function

    Public Function TxtPleLibroDiarioV2(idempresa As String, anio As String, mes As String) As List(Of movimiento) Implements IContService.TxtPleLibroDiarioV2
        Dim movimeintoBL As New movimientoBL
        Return movimeintoBL.TxtPleLibroDiarioV2(idempresa, anio, mes)
    End Function

    Public Function getListaServiosXVenta(be As InventarioMovimiento, fechaini As DateTime, fechafin As DateTime, tipo As String) As List(Of InventarioMovimiento) Implements IContService.getListaServiosXVenta
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.getListaServiosXVenta(be, fechaini, fechafin, tipo)
    End Function

    Public Function CompensacionDocCompraAnticipo(objDocumento As documento, objDoc As documento) As Integer Implements IContService.CompensacionDocCompraAnticipo
        Dim documentoBL As New documentocompraBL
        Return documentoBL.CompensacionDocCompraAnticipo(objDocumento, objDoc)
    End Function

    Public Sub GrabarSalidaProduccion(objDocumento As documento) Implements IContService.GrabarSalidaProduccion
        Dim documentoBL As New documentocompraBL
        documentoBL.GrabarSalidaProduccion(objDocumento)
    End Sub

    Public Function SaveOtrasSalidasProduccion(objDocumento As documento) As Integer Implements IContService.SaveOtrasSalidasProduccion
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveOtrasSalidasProduccion(objDocumento)
    End Function

    Public Function GetGastosTipoAll(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto) Implements IContService.GetGastosTipoAll
        Dim recursoBL As New recursoCostoBL
        Return recursoBL.GetGastosTipoAll(idEmpresa, idEstable)
    End Function

    Public Function EnvioDeProductosTerminados(periodo As String, idEntregable As Integer) As List(Of documentocompradetalle) Implements IContService.EnvioDeProductosTerminados
        Dim documentoCompraBL As New documentocompraBL
        Return documentoCompraBL.EnvioDeProductosTerminados(periodo, idEntregable)
    End Function

    Public Function GastosFinanzas(documentoCaja As documentoCaja) As List(Of documentoCaja) Implements IContService.GastosFinanzas
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GastosFinanzas(documentoCaja)
    End Function


    Public Function ListaRecursosGastoLibroEntregable(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle) Implements IContService.ListaRecursosGastoLibroEntregable
        Dim recursoBL As New documentoLibroDiarioBL
        Return recursoBL.ListaRecursosGastoLibroEntregable(compraBE)
    End Function

    Public Function ListaRecursosGastoEntregable(compraBE As documentocompra, idEntregable As Integer) As List(Of documentocompradetalle) Implements IContService.ListaRecursosGastoEntregable
        Dim recursoBL As New documentocompraBL
        Return recursoBL.ListaRecursosGastoEntregable(compraBE, idEntregable)
    End Function

    Public Function GetEntregablesXSubProy(idEmpresa As String, idEstable As Integer, idSubProy As Integer, periodo As String) As List(Of recursoCosto) Implements IContService.GetEntregablesXSubProy
        Dim recursoBL As New recursoCostoBL
        Return recursoBL.GetEntregablesXSubProy(idEmpresa, idEstable, idSubProy, periodo)
    End Function


    Public Function GetCuentasFinancierasEmpresaXtipoFecha(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipoFecha_Result) Implements IContService.GetCuentasFinancierasEmpresaXtipoFecha
        Dim cuentaFinancieraBL As New estadosFinancierosBL
        Return cuentaFinancieraBL.GetCuentasFinancierasEmpresaXtipoFecha(be)
    End Function

    Public Function GetConsultaCuentasPorpagarFiltro(be As documentocompra) As List(Of documentocompra) Implements IContService.GetConsultaCuentasPorpagarFiltro
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetConsultaCuentasPorpagarFiltro(be)
    End Function

    Public Sub GrabarDetalleRecursosLibro(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento)) Implements IContService.GrabarDetalleRecursosLibro
        Dim recursoBL As New recursoCostoDetalleBL
        recursoBL.GrabarDetalleRecursosLibro(be, listaAsiento)
    End Sub

    Public Function SubProductosEntregables(idEntregable As Integer) As List(Of detalleitems) Implements IContService.SubProductosEntregables
        Dim ProductoBL As New detalleitemsBL()
        Return ProductoBL.SubProductosEntregables(idEntregable)
    End Function

    Public Function SaveEntradasProduccion(objDocumento As documento, idEntregable As Integer) As Integer Implements IContService.SaveEntradasProduccion
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveEntradasProduccion(objDocumento, idEntregable)
    End Function

    Public Function SaveReversionOtraSalida(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer Implements IContService.SaveReversionOtraSalida
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveReversionOtraSalida(objDocumento, nDocumentoCaja, nDocumentoSaldoVenta)
    End Function


    Public Sub GrabarSubProyectoConstruccion(idProyecto As Integer, besub As recursoCosto, listaentregable As List(Of recursoCosto)) Implements IContService.GrabarSubProyectoConstruccion
        Dim costoBL As New recursoCostoBL
        costoBL.GrabarSubProyectoConstruccion(idProyecto, besub, listaentregable)
    End Sub

    Public Function SaveReversionOtraEntrada(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer Implements IContService.SaveReversionOtraEntrada
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveReversionOtraEntrada(objDocumento, nDocumentoCaja, nDocumentoSaldoVenta)
    End Function

    Public Sub GetChangeStatusArticulo(Be As totalesAlmacen) Implements IContService.GetChangeStatusArticulo
        Dim totalBL As New totalesAlmacenBL
        totalBL.GetChangeStatusArticulo(Be)
    End Sub

    Public Function ListaRecursosCostoLibro(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle) Implements IContService.ListaRecursosCostoLibro
        Dim recursoBL As New documentoLibroDiarioBL
        Return recursoBL.ListaRecursosCostoLibro(compraBE)
    End Function

    Public Function UbicarVentaPorCompensar(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, intmoneda As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarVentaPorCompensar
        Dim documentoBL As New documentoventaAbarrotesBL
        Return documentoBL.UbicarVentaPorCompensar(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, intmoneda)
    End Function

    Public Function SumaNotasXidPadreItemVentaOpcionDefault(intIdSecuencia As Integer) As documentoventaAbarrotesDet Implements IContService.SumaNotasXidPadreItemVentaOpcionDefault
        Dim cajaBL As New documentocompradetalleBL
        Return cajaBL.SumaNotasXidPadreItemVentaOpcionDefault(intIdSecuencia)
    End Function

    Public Function CompensacionDocumentosVenta(objDocumento As documento, objDoc As documento) As Integer Implements IContService.CompensacionDocumentosVenta
        Dim documentoBL As New documentoventaAbarrotesBL
        Return documentoBL.CompensacionDocumentosVenta(objDocumento, objDoc)
    End Function

    Public Function ListadoNotasVentaDetalleHijos(intIdDocumento As Integer) As List(Of documentoventaAbarrotesDet) Implements IContService.ListadoNotasVentaDetalleHijos
        Dim DocumentoCajaBL As New documentoventaAbarrotesDetBL
        Return DocumentoCajaBL.ListadoNotasVentaDetalleHijos(intIdDocumento)
    End Function

    Public Function ListadoComprobateVentaNotasXidPadre(iNtPadre As Integer) As List(Of documentoventaAbarrotes) Implements IContService.ListadoComprobateVentaNotasXidPadre
        Dim DocumentoCompraBL As New documentoventaAbarrotesBL
        Return DocumentoCompraBL.ListadoComprobateVentaNotasXidPadre(iNtPadre)
    End Function

    Public Function ListadoNotasDetalleHijos(intIdDocumento As Integer) As List(Of documentocompradetalle) Implements IContService.ListadoNotasDetalleHijos
        Dim DocumentoCajaBL As New documentocompradetalleBL
        Return DocumentoCajaBL.ListadoNotasDetalleHijos(intIdDocumento)
    End Function

    Public Function ListadoComprobateNotasXidPadre(iNtPadre As Integer) As List(Of documentocompra) Implements IContService.ListadoComprobateNotasXidPadre
        Dim DocumentoCompraBL As New documentocompraBL
        Return DocumentoCompraBL.ListadoComprobateNotasXidPadre(iNtPadre)
    End Function

    Public Function UbicarTodoPagosAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarTodoPagosAsientoManualMNME
        Dim libroBL As New documentoLibroDiarioBL
        Return libroBL.UbicarTodoPagosAsientoManualMNME(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function UbicarTodosPagosPendienteMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentocompra) Implements IContService.UbicarTodosPagosPendienteMNME
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarTodosPagosPendienteMNME(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function CobrosGeneralesAsientos() As List(Of documentoLibroDiarioDetalle) Implements IContService.CobrosGeneralesAsientos
        Dim cronoBL As New documentoLibroDiarioBL
        Return cronoBL.CobrosGeneralesAsiento()
    End Function

    Public Function GetReporteElmentoCostoAnual(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetReporteElmentoCostoAnual
        Dim itemBL As New recursoCostoDetalleBL
        Return itemBL.GetReporteElmentoCostoAnual(be)
    End Function

    Public Function GetListadoRecursosByPadre(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetListadoRecursosByPadre
        Dim itemBL As New recursoCostoDetalleBL
        Return itemBL.GetListadoRecursosByPadre(be)
    End Function

    Public Function GetExistenciasByempresa() As List(Of detalleitems) Implements IContService.GetExistenciasByempresa
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetExistenciasByempresa
    End Function

    Public Function GetTipoExistenciasByempresa(tipo As Integer) As List(Of detalleitems) Implements IContService.GetTipoExistenciasByempresa
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetTipoExistenciasByempresa(tipo)
    End Function

    Public Function GetVentasPeriodoByClienteConteo(be As documentoventaAbarrotes) As Integer Implements IContService.GetVentasPeriodoByClienteConteo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasPeriodoByClienteConteo(be)
    End Function

    Public Function GetProveedoresEnTransito(be As documentocompra) As List(Of entidad) Implements IContService.GetProveedoresEnTransito
        Dim compraBL As New InventarioMovimientoBL
        Return compraBL.GetProveedoresEnTransito(be)
    End Function

    Public Function GetEsAlmacenVirtual(intIdAlmacen As Integer) As Boolean Implements IContService.GetEsAlmacenVirtual
        Dim almacenBL As New almacenBL
        Return almacenBL.GetEsAlmacenVirtual(intIdAlmacen)
    End Function

    Public Sub GrabarEnvioTransito(be As documento) Implements IContService.GrabarEnvioTransito
        Dim inventarioBL As New InventarioMovimientoBL
        inventarioBL.GrabarEnvioTransito(be)
    End Sub

    Public Function GetCountExistenciaTransito(be As documentocompra) As Integer Implements IContService.GetCountExistenciaTransito
        Dim compraBL As New InventarioMovimientoBL
        Return compraBL.GetCountExistenciaTransito(be)
    End Function

    Public Function GetProductosByAlmacen(almacenBE As almacen, Optional ByVal TipoExistencia As String = Nothing) As List(Of totalesAlmacen) Implements IContService.GetProductosByAlmacen
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetProductosByAlmacen(almacenBE, TipoExistencia)
    End Function

    Public Function GetExistenciaTransito(be As documentocompra) As List(Of documentocompradetalle) Implements IContService.GetExistenciaTransito
        Dim inventarioBL As New InventarioMovimientoBL
        Return inventarioBL.GetExistenciaTransitoByProveedor(be)
    End Function

    Public Function GetExistenciasInicio(be As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetExistenciasInicio
        Dim libroBL As New documentoLibroDiarioBL
        Return libroBL.GetExistenciasInicio(be)
    End Function

    Public Function GetventasDeApertura(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetventasDeApertura
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasDeApertura(be)
    End Function

    Public Function GetComprasDeApertura(be As documentocompra) As List(Of documentocompra) Implements IContService.GetComprasDeApertura
        Dim compraBL As New documentocompraBL
        Return compraBL.GetComprasDeApertura(be)
    End Function

    Public Function GetSumaInicioExistencias(be As documentoLibroDiario) As documentoLibroDiario Implements IContService.GetSumaInicioExistencias
        Dim libroBL As New documentoLibroDiarioBL
        Return libroBL.GetSumaInicioExistencias(be)
    End Function

    Public Function GetCuentasPorCobrarInicio(be As documentoventaAbarrotes) As documentoventaAbarrotes Implements IContService.GetCuentasPorCobrarInicio
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetCuentasPorCobrarInicio(be)
    End Function

    Public Function GetCuentasPorPagarInicio(be As documentocompra) As documentocompra Implements IContService.GetCuentasPorPagarInicio
        Dim compraBL As New documentocompraBL
        Return compraBL.GetCuentasPorPagarInicio(be)
    End Function

    Public Function GetCuentasByTipoDeAporteInicio(be As estadosFinancieros) As List(Of estadosFinancieros) Implements IContService.GetCuentasByTipoDeAporteInicio
        Dim cajaBL As New estadosFinancierosBL
        Return cajaBL.GetCuentasByTipoDeAporteInicio(be)
    End Function

    Public Function ListadoEstadosFinanConteo(strIdEmpresa As String, intEstablec As Integer) As Integer Implements IContService.ListadoEstadosFinanConteo
        Dim cajaBL As New estadosFinancierosBL
        Return cajaBL.ListadoEstadosFinanConteo(strIdEmpresa, intEstablec)
    End Function

    Public Function GetSumaCuentasByTipo(be As estadosFinancieros) As List(Of estadosFinancieros) Implements IContService.GetSumaCuentasByTipo
        Dim cajaBL As New estadosFinancierosBL
        Return cajaBL.GetSumaCuentasByTipo(be)
    End Function

    Public Function GetConteoDetracciones(be As documentocompra) As Integer Implements IContService.GetConteoDetracciones
        Dim compraBL As New documentocompraBL
        Return compraBL.GetConteoDetracciones(be)
    End Function

    Public Sub UpdateDataDetraccion(be As documentocompra) Implements IContService.UpdateDataDetraccion
        Dim recursoBL As New documentocompraBL
        recursoBL.UpdateDataDetraccion(be)
    End Sub

    Public Function GetListadoDetracciones(be As documentocompra) As List(Of documentocompra) Implements IContService.GetListadoDetracciones
        Dim recursoBL As New documentocompraBL
        Return recursoBL.GetListadoDetracciones(be)
    End Function

    Public Function GetElementosCostoByCosto(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetElementosCostoByCosto
        Dim recursoBL As New recursoCostoBL
        Return recursoBL.GetElementosCostoByCosto(be)
    End Function

    Public Function GetCostoCount(subTipoCosto As String) As Integer Implements IContService.GetCostoCount
        Dim recursoBL As New recursoCostoBL
        Return recursoBL.GetCostoCount(subTipoCosto)
    End Function

    Public Function ObtenerMaxCuentabyCuenta(be As cuentaplanContableEmpresa) As cuentaplanContableEmpresa Implements IContService.ObtenerMaxCuentabyCuenta
        Dim cuentabL As New cuentaplanContableEmpresaBL
        Return cuentabL.ObtenerMaxCuentabyCuenta(be)
    End Function

    Public Function GetSumByCostoGastos(be As recursoCosto) As Double Implements IContService.GetSumByCostoGastos
        Dim recursoBL As New recursoCostoDetalleBL
        Return recursoBL.GetSumByCostoGastos(be)
    End Function

    Public Function GetSumByCosto(be As recursoCosto) As Double Implements IContService.GetSumByCosto
        Dim recursoBL As New recursoCostoDetalleBL
        Return recursoBL.GetSumByCosto(be)
    End Function

    Public Function ListadoventasObservadasConteo(be As documentoventaAbarrotes) As Integer Implements IContService.ListadoventasObservadasConteo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.ListadoventasObservadasConteo(be)
    End Function

    Public Function ListadoventasObservadas(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.ListadoventasObservadas
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.ListadoventasObservadas(be)
    End Function

    Public Function GetVentasNotificadasAtendCompras(intIdDocumento As Integer) As List(Of documentoventaAbarrotesDet) Implements IContService.GetVentasNotificadasAtendCompras
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasNotificadasAtendCompras(intIdDocumento)
    End Function


    Public Sub GrabarListaAsientosXConciliar(be As List(Of asiento)) Implements IContService.GrabarListaAsientosXConciliar
        Dim asientoBL As New AsientoBL
        asientoBL.GrabarListaAsientosXConciliar(be)
    End Sub

    Public Function GetListaTablaDetalleMotivo(intIdTabla As Integer, strEstado As String, codigo As String) As System.Collections.Generic.List(Of Business.Entity.tabladetalle) Implements ServiceContract.IContService.GetListaTablaDetalleMotivo
        Dim tablaBL As New tabladetalleBL
        Return tablaBL.GetListaTablaDetalleMotivo(intIdTabla, strEstado, codigo)
    End Function

    Public Function GetUbicarTablaexistenciaCambioInventario() As System.Collections.Generic.List(Of Business.Entity.tabladetalle) Implements ServiceContract.IContService.GetUbicarTablaexistenciaCambioInventario
        Dim tablaBL As New tabladetalleBL
        Return tablaBL.GetUbicarTablaexistenciaCambioInventario()
    End Function

    Public Function GetPantillasGeneral(tipoOper As String) As List(Of asientoContablePlantilla) Implements IContService.GetPantillasGeneral
        Dim platillaBL As New asientoContablePlantillaBL
        Return platillaBL.GetPantillasGeneral(tipoOper)
    End Function


    Public Function GetListadoRecursosByIdCosto(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetListadoRecursosByIdCosto
        Dim recursoBL As New recursoCostoDetalleBL
        Return recursoBL.GetListadoRecursosByIdCosto(be)
    End Function

    Public Sub GrabarDetalleRecursos(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento)) Implements IContService.GrabarDetalleRecursos
        Dim recursoBL As New recursoCostoDetalleBL
        recursoBL.GrabarDetalleRecursos(be, listaAsiento)
    End Sub

    Public Function GetNumAlertasInventariosSinAsiento(be As documentocompra) As Integer Implements IContService.GetNumAlertasInventariosSinAsiento
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetNumAlertasInventariosSinAsiento(be)
    End Function

    Public Function GetFinanzasSinAsiento(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetFinanzasSinAsiento
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetFinanzasSinAsiento(be)
    End Function

    Public Function GetNumFinanzasSinAsiento(be As documentoCaja) As Integer Implements IContService.GetNumFinanzasSinAsiento
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetNumFinanzasSinAsiento(be)
    End Function

    Public Function GetInventariosSinAsiento(be As documentocompra) As List(Of documentocompra) Implements IContService.GetInventariosSinAsiento
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetInventariosSinAsiento(be)
    End Function

    Public Function UbicarConteoVentaCompra(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As documento Implements ServiceContract.IContService.UbicarConteoVentaCompra
        Dim cajaBL As New documentoBL
        Return cajaBL.UbicarConteoVentaCompra(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function



    Public Function ListadoCajaAsigConteo(strEmpresa As String, intIdEstablecimiento As Integer) As Integer Implements ServiceContract.IContService.ListadoCajaAsigConteo
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.ListadoCajaAsigConteo(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function ListadoCajaFullConteo(strEmpresa As String, intIdEstablecimiento As Integer) As Integer Implements ServiceContract.IContService.ListadoCajaFullConteo
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.ListadoCajaFullConteo(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function VerificarCajaEstadoXUsuario(idPersona As String) As Boolean Implements ServiceContract.IContService.VerificarCajaEstadoXUsuario
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.VerificarCajaEstadoXUsuario(idPersona)
    End Function

    Public Function ObtenerCajaUsuarioFullEstado() As List(Of cajaUsuario) Implements ServiceContract.IContService.ObtenerCajaUsuarioFullEstado
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.ObtenerCajaUsuarioFullEstado()
    End Function

    Public Function ObtenerCajaUsuarioFullXpersona(strEmpresa As String, idEstablec As Integer, periodo As String, idPersonal As Integer) As List(Of cajaUsuario) Implements ServiceContract.IContService.ObtenerCajaUsuarioFullXpersona
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.ObtenerCajaUsuarioFullXpersona(strEmpresa, idEstablec, periodo, idPersonal)
    End Function

    Public Function GetTotalComprasByPeriodoProveedor(be As documentocompra) As List(Of documentocompra) Implements IContService.GetTotalComprasByPeriodoProveedor
        Dim comprabl As New documentocompraBL
        Return comprabl.GetTotalComprasByPeriodoProveedor(be)
    End Function

    Public Function GetProductoPorAlmacenTipoExTodo(intIdAlmacen As Integer) As List(Of totalesAlmacen) Implements IContService.GetProductoPorAlmacenTipoExTodo
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetProductoPorAlmacenTipoExTodo(intIdAlmacen)
    End Function

    Public Function GetSumaNotasXperiodo(be As documentocompra) As List(Of documentocompra) Implements IContService.GetSumaNotasXperiodo
        Dim compraBL As New documentocompraBL
        Return compraBL.GetSumaNotasXperiodo(be)
    End Function

    Public Function GetTatalResumenComprasXtipo(be As documentocompra) As List(Of documentocompra) Implements IContService.GetTatalResumenComprasXtipo
        Dim compraBL As New documentocompraBL
        Return compraBL.GetTatalResumenComprasXtipo(be)
    End Function

    Public Function GetNumComprasXparameter(be As documentocompra, caso As String) As Integer Implements IContService.GetNumComprasXparameter
        Dim compraBL As New documentocompraBL
        Return compraBL.GetNumComprasXparameter(be, caso)
    End Function

    Public Function GetCountItemsNoAsignados(compraBE As documentocompra) As Integer Implements IContService.GetCountItemsNoAsignados
        Dim recursoBL As New documentocompradetalleBL
        Return recursoBL.GetCountItemsNoAsignados(compraBE)
    End Function

    Public Sub GrabarGrupoDetalle(be As recursoCosto) Implements IContService.GrabarGrupoDetalle
        'Dim recursoBL As New recursoCostoDetalleBL
        'recursoBL.GrabarGrupoDetalle(be)
    End Sub

    Public Function ObtenerGastosEmpresa(recursoBE As recursoCosto) As List(Of recursoCosto) Implements IContService.ObtenerGastosEmpresa
        'Dim recursoBL As New recursoCostoBL
        'Return recursoBL.ObtenerGastosEmpresa(recursoBE)
        Return Nothing
    End Function

    'Public Sub EditarCosto(be As recursoCosto) Implements IContService.EditarCosto
    '    Dim recursoBL As New recursoCostoBL
    '    recursoBL.EditarCosto(be)
    'End Sub

    'Public Sub EliminarCosto(be As recursoCosto) Implements IContService.EliminarCosto
    '    Dim recursoBL As New recursoCostoBL
    '    recursoBL.EliminarCosto(be)
    'End Sub

    'Public Sub GrabarCosto(be As recursoCosto) Implements IContService.GrabarCosto
    '    Dim recursoBL As New recursoCostoBL
    '    recursoBL.GrabarCosto(be)
    'End Sub

    Public Sub EliminarComprobanteORPByCosto(documentoBE As documento) Implements IContService.EliminarComprobanteORPByCosto
        Dim compraBL As New documentoBL
        compraBL.EliminarComprobanteORPByCosto(documentoBE)
    End Sub

    Public Function ListadoComprobantesPorORP(compraBE As documentocompra) As List(Of documentocompra) Implements IContService.ListadoComprobantesPorORP
        Dim compraBL As New documentocompraBL
        Return compraBL.ListadoComprobantesPorORP(compraBE)
    End Function

    Public Function GrabarProductosTerminados(objDocumento As documento) As Integer Implements IContService.GrabarProductosTerminados
        Dim compraBL As New documentocompraBL
        Return compraBL.GrabarProductosTerminados(objDocumento)
    End Function

    'Public Function SumatoriaXcosto(recursoBE As recursoCosto) As documentocompradetalle Implements IContService.SumatoriaXcosto
    '    Dim recursoBL As New recursoCostoBL
    '    Return recursoBL.SumatoriaXcosto(recursoBE)
    'End Function

    'Public Sub CulminarCosto(r As recursoCosto, documento As documento) Implements IContService.CulminarCosto
    '    'Dim recursoBL As New recursoCostoBL
    '    'recursoBL.CulminarCosto(r, documento)
    'End Sub

    Public Sub QuitarAsignacionRecurso(i As documentocompradetalle) Implements IContService.QuitarAsignacionRecurso
        Dim recursoBL As New documentocompradetalleBL
        recursoBL.QuitarAsignacionRecurso(i)
    End Sub

    Public Sub UpdateCostoItemSingle(i As documentocompradetalle) Implements IContService.UpdateCostoItemSingle
        Dim detBL As New documentocompradetalleBL
        detBL.UpdateCostoItemSingle(i)
    End Sub

    Public Function ListaRecursoAsignadoByIdCostoSingle(i As documentocompradetalle, doccompra As documentocompra) As List(Of documentocompradetalle) Implements IContService.ListaRecursoAsignadoByIdCostoSingle
        Dim detBL As New documentocompradetalleBL
        Return detBL.ListaRecursoAsignadoByIdCostoSingle(i, doccompra)
    End Function

    Public Function ListaRecursoAsignadoByIdCosto(i As documentocompradetalle, doccompra As documentocompra) As List(Of documentocompradetalle) Implements IContService.ListaRecursoAsignadoByIdCosto
        Dim detBL As New documentocompradetalleBL
        Return detBL.ListaRecursoAsignadoByIdCosto(i, doccompra)
    End Function

    Public Sub UpdateCostoItem(i As documentocompradetalle, documento As documento) Implements IContService.UpdateCostoItem
        Dim detBL As New documentocompradetalleBL
        detBL.UpdateCostoItem(i, documento)
    End Sub

    Public Function ObtenerCostoById(recursoBE As recursoCosto) As recursoCosto Implements IContService.ObtenerCostoById
        'Dim recursoBL As Ne  w recursoCostoBL
        '  Return recursoBL.ObtenerCostoById(recursoBE)
        Return Nothing
    End Function

    Public Function ListaRecursosCosto(compraBE As documentocompra) As List(Of documentocompradetalle) Implements IContService.ListaRecursosCosto
        Dim recursoBL As New documentocompraBL
        Return recursoBL.ListaRecursosCosto(compraBE)
    End Function

    'Public Function ObtenerCostosPorSubTipoPorStatus(recursoBE As recursoCosto, Optional listaStatus As List(Of String) = Nothing) As List(Of recursoCosto) Implements IContService.ObtenerCostosPorSubTipoPorStatus
    '    'Dim recursoBL As New recursoCostoBL
    '    'Return recursoBL.ObtenerCostosPorSubTipoPorStatus(recursoBE, listaStatus)
    'End Function

    'Public Function ObtenerCostosPorSubTipo(recursoBE As recursoCosto) As List(Of recursoCosto) Implements IContService.ObtenerCostosPorSubTipo
    '    Dim recursoBL As New recursoCostoBL
    '    Return recursoBL.ObtenerCostosPorSubTipo(recursoBE)
    'End Function

    'Public Function ObtenerCostosPorTipo(recursoBE As recursoCosto) As List(Of recursoCosto) Implements IContService.ObtenerCostosPorTipo
    '    Dim recursoBL As New recursoCostoBL
    '    Return recursoBL.ObtenerCostosPorTipo(recursoBE)
    'End Function

    Public Function BalanceGeneralAnual(asientoBE As asiento) As List(Of movimiento) Implements IContService.BalanceGeneralAnual
        Dim movBL As New movimientoBL
        Return movBL.BalanceGeneralAnual(asientoBE)
    End Function

    Public Sub CerrarTipoCambioDolaresPeriodo(lista As List(Of documentocompra)) Implements IContService.CerrarTipoCambioDolaresPeriodo
        Dim compraBL As New documentocompraBL
        compraBL.CerrarTipoCambioDolaresPeriodo(lista)
    End Sub

    Public Function CerrarComprasMonedaExtranjera(compraBE As documentocompra) As List(Of documentocompra) Implements IContService.CerrarComprasMonedaExtranjera
        Dim compraBL As New documentocompraBL
        Return compraBL.CerrarComprasMonedaExtranjera(compraBE)
    End Function

    Public Function CuentaExistenteEnBD(cuentaBE As cuentaplanContableEmpresa) As Boolean Implements IContService.CuentaExistenteEnBD
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.CuentaExistenteEnBD(cuentaBE)
    End Function

    Public Sub InsertarListaDeCuentas(ListaCuentas As List(Of cuentaplanContableEmpresa)) Implements IContService.InsertarListaDeCuentas
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        cuentaBL.InsertarListaDeCuentas(ListaCuentas)
    End Sub

    Public Sub EditarRecepcionDePagos(be As List(Of Cronograma)) Implements IContService.EditarRecepcionDePagos
        'Dim CronogramaBL As New CronogramaBL
        'CronogramaBL.EditarRecepcionDePagos(be)
    End Sub

    'Public Sub EliminarItemCronograma(be As Cronograma) Implements IContService.EliminarItemCronograma
    '    Dim CronogramaBL As New CronogramaBL
    '    CronogramaBL.EliminarItemCronograma(be)
    'End Sub

    'Public Function GetListadoPagosPorUsuario(be As Cronograma) As List(Of Cronograma) Implements IContService.GetListadoPagosPorUsuario
    '    Dim CronogramaBL As New CronogramaBL
    '    Return CronogramaBL.GetListadoPagosPorUsuario(be)
    'End Function

    'Public Sub GrabarRecepcionDePagos(be As List(Of Cronograma)) Implements IContService.GrabarRecepcionDePagos
    '    Dim CronogramaBL As New CronogramaBL
    '    CronogramaBL.GrabarRecepcionDePagos(be)
    'End Sub

    Public Sub DeleteItemVenta(documentoventaAbarrotesDetBE As documentoventaAbarrotesDet) Implements IContService.DeleteItemVenta
        Dim ventaDetBL As New documentoventaAbarrotesDetBL
        ventaDetBL.DeleteItemVenta(documentoventaAbarrotesDetBE)
    End Sub

    Public Function GetListar_almaPuntoUbi(intIdEstablecimiento As Integer) As List(Of almacen) Implements IContService.GetListar_almaPuntoUbi
        Dim AlmacenBL As New almacenBL
        Return AlmacenBL.GetListar_AlmaPuntoUbi(intIdEstablecimiento)
    End Function

    Public Sub EditarCajaUsuarioNuevo(objCajaUsuarioBE As cajaUsuario) Implements IContService.EditarCajaUsuarioNuevo
        Dim CajausuarioBL As New CajaUsuarioBL
        CajausuarioBL.EditarCajaUsuarioNuevo(objCajaUsuarioBE)
    End Sub

    Public Function ResumenDetailVenta(be As cajaUsuario) As List(Of cajaUsuariodetalle) Implements IContService.ResumenDetailVenta
        Dim CajausuarioBL As New cajaUsuarioDetalleBL
        Return CajausuarioBL.ResumenDetailVenta(be)
    End Function

    Public Function LoadCuentasActInmov(strEmpresa As String) As List(Of cuentaplanContableEmpresa) Implements IContService.LoadCuentasActInmov
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.LoadCuentasActivoInm(strEmpresa)
    End Function

    Public Function InsertarMarcaHijo(nTabDet As item) As Integer Implements IContService.InsertarMarcaHijo
        Dim actividadBL As New itemBL
        Return actividadBL.Insertmarca(nTabDet)
    End Function

    Public Function GetListar_almacenesTipobyEmpresa(almacenBE As almacen) As List(Of almacen) Implements IContService.GetListar_almacenesTipobyEmpresa
        Dim AlmacenBL As New almacenBL
        Return AlmacenBL.GetListar_almacenesTipobyEmpresa(almacenBE)
    End Function

    Public Function GetListar_almacenesTipo(intIdEstablecimiento As Integer, tipo As String) As List(Of almacen) Implements IContService.GetListar_almacenesTipo
        Dim AlmacenBL As New almacenBL
        Return AlmacenBL.GetListar_almacenesTipo(intIdEstablecimiento, tipo)
    End Function

    Public Function GetUbicarProductosXIdHijo(idEmpresa As String, idEstablec As Integer, iditem As Integer, tipo As String) As List(Of detalleitems) Implements IContService.GetUbicarProductosXIdHijo
        Dim productoBL As New detalleitemsBL
        Return productoBL.GetUbicarProductoIdHijo(idEmpresa, idEstablec, iditem, tipo)
    End Function

    Public Function ListaIdPadre() As List(Of item) Implements IContService.ListaIdPadre
        Dim InsumoBL As New itemBL()
        Return InsumoBL.GetListaIdPadre()
    End Function

    Public Function ProductosMayoresStock(tot As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.ProductosMayoresStock
        Dim totalesBL As New totalesAlmacenBL
        Return totalesBL.ProductosMayorStock(tot)
    End Function

    Public Function ListarPadreHijos(idpadre As Integer) As List(Of item) Implements IContService.ListarPadreHijos
        Dim InsumoBL As New itemBL()
        Return InsumoBL.GetListaPorIdPadre(idpadre)
    End Function

    Public Function ResumenTransaccionesXusuarioCaja(be As cajaUsuario) As List(Of cajaUsuario) Implements IContService.ResumenTransaccionesXusuarioCaja
        Dim usuarioBL As New CajaUsuarioBL
        Return usuarioBL.ResumenTransaccionesXusuarioCaja(be)
    End Function

    Public Function ResumenTransaccionesXusuarioCajaPago(be As cajaUsuario) As List(Of cajaUsuario) Implements IContService.ResumenTransaccionesXusuarioCajaPago
        Dim usuarioBL As New CajaUsuarioBL
        Return usuarioBL.ResumenTransaccionesXusuarioCajaPago(be)
    End Function

    Public Function usp_ResumenTransaccionesXusuarioCajaXCierre(be As cajaUsuario) As List(Of cajaUsuario) Implements IContService.usp_ResumenTransaccionesXusuarioCajaXCierre
        Dim usuarioBL As New CajaUsuarioBL
        Return usuarioBL.usp_ResumenTransaccionesXusuarioCajaXCierre(be)
    End Function

    Public Function ProductosMenoresStock(tot As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.ProductosMenoresStock
        Dim totalesBL As New totalesAlmacenBL
        Return totalesBL.ProductosPocoStock(tot)
    End Function

    Public Function VentasCantidadStock(cantidad As String, fechaini As Date, fechafin As Date, mayor As Decimal, menor As Decimal) As List(Of documentoventaAbarrotesDet) Implements IContService.VentasCantidadStock
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.VentasCantidadStock(cantidad, fechaini, fechafin, mayor, menor)
    End Function

    Public Sub EliminarVentaGeneralPV(documentoBE As documento) Implements IContService.EliminarVentaGeneralPV
        Dim documentoBL As New documentoBL
        documentoBL.EliminarVentaGeneralPV(documentoBE)
    End Sub

    Public Sub EliminarVentaTicketDirecta(documentoBE As documento) Implements IContService.EliminarVentaTicketDirecta
        Dim documentoBL As New documentoBL
        documentoBL.EliminarVentaTicketDirecta(documentoBE)
    End Sub

    Public Function ObtenerTipoCambioXfecha(idempresa As String, fecha As Date, intIdEstablecimiento As Integer) As tipoCambio Implements IContService.ObtenerTipoCambioXfecha
        Dim configBL As New tipoCambioBL
        Return configBL.ObtenerCambioXFecha(idempresa, fecha, intIdEstablecimiento)
    End Function

    Public Function GetListarAllNotasPedido(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllNotasPedido
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllNotasPedido(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarCotizaciones(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarCotizaciones
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarCotizaciones(intIdEstablec, strPeriodo)
    End Function

    Public Function SP_UbicarDetalleCompraControl(intIdDocumento As Integer) As List(Of documentocompradetalle) Implements IContService.SP_UbicarDetalleCompraControl
        Dim compraBL As New documentocompradetalleBL
        Return compraBL.SP_UbicarDetalleCompraControl(intIdDocumento)
    End Function

    Public Function ReporteSaldoInicioXperiodoHojaTrabajo(intAnio As Integer, intMes As Integer, idEmpresa As String) As List(Of cierrecontable) Implements IContService.ReporteSaldoInicioXperiodoHojaTrabajo
        Dim cierreBL As New cierrecontableBL
        Return cierreBL.ReporteSaldoInicioXperiodoHojaTrabajo(intAnio, intMes, idEmpresa)
    End Function

    Public Function ListarCuentasPorPadreDescrip(strEmpresa As String, strCuentaPadre As String) As List(Of cuentaplanContableEmpresa) Implements IContService.ListarCuentasPorPadreDescrip
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.ListarCuentasPorPadreDescrip(strEmpresa, strCuentaPadre)
    End Function

    Public Function UbicarClientePoID(ByVal strNroPersona As String) As Business.Entity.entidad Implements ServiceContract.IContService.UbicarClientePoID
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.UbicarClientePoID(strNroPersona)
    End Function

    Public Function UbicarClienteXID(ByVal entidadBE As entidad) As entidad Implements ServiceContract.IContService.UbicarClienteXID
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.UbicarClienteXID(entidadBE)
    End Function

    Public Function ListadoServiciosPadreTipo(tipo As String) As List(Of servicio) Implements IContService.ListadoServiciosPadreTipo
        Dim servicioBL As New servicioBL
        Return servicioBL.ListadoServiciostipo(tipo)
    End Function

    Public Function NumProductosSinListaPrecio(tot As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.NumProductosSinListaPrecio
        Dim totalesBL As New totalesAlmacenBL
        Return totalesBL.NumProductosSinListaPrecio(tot)
    End Function

    Public Function SaveVentaTicketPS(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Integer Implements ServiceContract.IContService.SaveVentaTicketPS
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveVentaPS(objDocumento, objTotalesAlmacen)
    End Function

    Public Function UpdateVentaPS(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Integer Implements ServiceContract.IContService.UpdateVentaPS
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.UpdateVentaPS(objDocumento, objTotalesAlmacen)
    End Function


    Public Function ListarDetallexCuenta(strPeriodo As String, intMes As String, cuenta As String) As List(Of movimiento) Implements IContService.ListarDetallexCuenta
        Dim cajaBL As New HojaTrabajoFinalRPT
        Return cajaBL.ListarDetalleXCuenta(strPeriodo, intMes, cuenta)
    End Function

    Public Function ObtenerProdXAlmacenesXMesAllXExisten(idAlmacen As String, periodo As Integer, mes As String, tipo As String) As List(Of InventarioMovimiento) Implements IContService.ObtenerProdXAlmacenesXMesAllXExisten
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerProdPorAlmacenesXMesAllExis(idAlmacen, periodo, mes, tipo)
    End Function

    Public Sub GrabarPrecioGeneral(listaProductos As configuracionPrecio) Implements IContService.GrabarPrecioGeneral
        Dim almacenBL As New ConfiguracionPrecioBL
        almacenBL.GrabarPrecioGeneral(listaProductos)
    End Sub

    Public Sub UpdatePrecioGeneral(listaProductos As configuracionPrecio) Implements IContService.UpdatePrecioGeneral
        Dim almacenBL As New ConfiguracionPrecioBL
        almacenBL.UpdatePrecioGeneral(listaProductos)
    End Sub

    Public Sub DeletePrecioGeneral(listaProductos As configuracionPrecio) Implements IContService.DeletePrecioGeneral
        Dim almacenBL As New ConfiguracionPrecioBL
        almacenBL.DeletePrecioGeneral(listaProductos)
    End Sub

    Public Function ObtenerAlertaDePrecioConteo(productoBE As totalesAlmacen) As Integer Implements IContService.ObtenerAlertaDePrecioConteo
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.ObtenerAlertaDePrecioConteo(productoBE)
    End Function

    Public Function ObtenerAlertaDePrecio(productoBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.ObtenerAlertaDePrecio
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.ObtenerAlertaDePrecio(productoBE)
    End Function

    Public Function ListadoServiciosHijosXIdTipo(servicioBE As servicio) As List(Of servicio) Implements IContService.ListadoServiciosHijosXIdTipo
        Dim servicioBL As New servicioBL
        Return servicioBL.ListadoServiciosHijosXIdTipo(servicioBE)
    End Function

    Public Function GrabarServicioPadre(servicioBE As servicio) As Integer Implements IContService.GrabarServicioPadre
        Dim servicioBL As New servicioBL
        Return servicioBL.SaveServicioPadre(servicioBE)
    End Function

    Public Sub EditarServicioPadre(servicioBE As servicio) Implements IContService.EditarServicioPadre
        Dim servicioBL As New servicioBL
        servicioBL.ActualizarPadre(servicioBE)
    End Sub

    Public Sub EliminarServicioPadreHijo(servicioBE As servicio) Implements IContService.EliminarServicioPadreHijo
        Dim servicioBL As New servicioBL
        servicioBL.EliminarServicioPadreHijo(servicioBE)
    End Sub

    Public Sub UpdateCantMaxMin(totalesALmacenBE As totalesAlmacen) Implements IContService.UpdateCantMaxMin
        Dim CantMaxBL As New totalesAlmacenBL
        CantMaxBL.UpdateCantMaxMin(totalesALmacenBE)
    End Sub

    Public Function GetUbicar_documentocompradetallePorCompraEx(intIdDocumento As Integer) As List(Of documentocompradetalle) Implements IContService.GetUbicar_documentocompradetallePorCompraEx
        Dim libroBL As New documentocompradetalleBL
        Return libroBL.GetUbicar_documentocompradetallePorCompraEx(intIdDocumento)
    End Function

    Public Function MostrarPagosVariosCP(intIdDocumentoPadre As Integer) As List(Of documentoLibroDiario) Implements IContService.MostrarPagosVariosCP
        Dim libroBL As New documentoLibroDiarioBL
        Return libroBL.MostrarPagosVariosCP(intIdDocumentoPadre)
    End Function

    Public Function GrabarAjustes(objDocumento As documento) As Integer Implements IContService.GrabarAjustes
        Dim libroBL As New documentoLibroDiarioBL
        Return libroBL.GrabarAjustes(objDocumento)
    End Function

    Public Function ReporteSaldoInicioXperiodo(intAnio As Integer, intMes As Integer) As List(Of cierrecontable) Implements IContService.ReporteSaldoInicioXperiodo
        Dim cierreBL As New cierrecontableBL
        Return cierreBL.ReporteSaldoInicioXperiodo(intAnio, intMes)
    End Function

    Public Function BuscarCuentasBalance(strPeriodo As Integer) As List(Of movimiento) Implements IContService.BuscarCuentasBalance
        Dim cajaBL As New movimientoBL
        Return cajaBL.BuscarCuentasBalance(strPeriodo)
    End Function

    Public Sub ListadoItemsDeInicio(list As List(Of detalleitems), documentoBE As documento) Implements IContService.ListadoItemsDeInicio
        Dim itemBL As New detalleitemsBL
        itemBL.ListadoItemsDeInicio(list, documentoBE)
    End Sub

    Public Sub InsertGrupoEntidad(list As List(Of entidad)) Implements IContService.InsertGrupoEntidad
        Dim DocumetoBL As New entidadBL
        DocumetoBL.InsertGrupoEntidad(list)
    End Sub

    Public Sub DeleteLibroDiario(intIdDocumento As Integer) Implements IContService.DeleteLibroDiario
        Dim DocumetoBL As New documentoLibroDiarioBL
        DocumetoBL.DeleteLibroDiario(intIdDocumento)
    End Sub

    Public Function UbicarDocumentoLibroDiario(intIdDocumento As Integer) As documentoLibroDiario Implements IContService.UbicarDocumentoLibroDiario
        Dim DocumetoBL As New documentoLibroDiarioBL
        Return DocumetoBL.GetUbicar_documentoLibroDiarioPorID(intIdDocumento)
    End Function

    Public Sub ActualizarDocumentoLibroDiario(objLibro As documento) Implements IContService.ActualizarDocumentoLibroDiario
        Dim DocumetoBL As New documentoLibroDiarioBL
        DocumetoBL.ActualizarLibroDiarioDet(objLibro)
    End Sub

    Public Sub EliminarCierreContable(cierreBE As cierrecontable) Implements IContService.EliminarCierreContable
        Dim cierreCajaBL As New cierrecontableBL
        cierreCajaBL.EliminarCierreContable(cierreBE)
    End Sub

    Public Function GetEstadoSaldoEF(EF As estadosFinancieros) As estadosFinancieros Implements IContService.GetEstadoSaldoEF
        Dim entidadBL As New estadosFinancierosBL
        Return entidadBL.GetEstadoSaldoEF(EF)
    End Function

    Public Function GetListado_cierreCajasPorPeriodo(cierreBE As cierreCaja) As List(Of cierreCaja) Implements IContService.GetListado_cierreCajasPorPeriodo
        Dim cierreCajaBL As New cierreCajaBL
        Return cierreCajaBL.GetListado_cierreCajasPorPeriodo(cierreBE)
    End Function

    Public Sub EliminarCierreCaja(cierreBE As cierreCaja) Implements IContService.EliminarCierreCaja
        Dim cierreCajaBL As New cierreCajaBL
        cierreCajaBL.EliminarCierreCaja(cierreBE)
    End Sub

    Public Sub EliminarCierreInventario(cierreBE As cierreinventario) Implements IContService.EliminarCierreInventario
        Dim cierreBL As New cierreinventarioBL
        cierreBL.EliminarCierreInventario(cierreBE)
    End Sub

    Public Function MostrarCierreInvPorPeriodo(inventarioMov As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.MostrarCierreInvPorPeriodo
        Dim invBL As New InventarioMovimientoBL
        Return invBL.ListadoCierreInvPorPeriodo2(inventarioMov)
    End Function

    Public Function RecuperarCierreCajaXEF(intAnio As Integer, intMes As Integer, intIdEF As Integer) As cierreCaja Implements IContService.RecuperarCierreCajaXEF
        Dim cierreCajaBL As New cierreCajaBL
        Return cierreCajaBL.RecuperarCierre(intAnio, intMes, intIdEF)
    End Function

    Public Function PeriodoInventarioCerrado(strempresa As String, strPeriodo As String) As Boolean Implements IContService.PeriodoInventarioCerrado
        Dim cierreInventarioBL As New cierreinventarioBL
        Return cierreInventarioBL.PeriodoInventarioCerrado(strempresa, strPeriodo)
    End Function

    Public Function ObtenerPeriodosCerrados(cierreBE As cierreinventario) As List(Of cierreinventario) Implements IContService.ObtenerPeriodosCerrados
        Dim cierreInventarioBL As New cierreinventarioBL
        Return cierreInventarioBL.ObtenerPeriodosCerrados(cierreBE)
    End Function

    Public Function GetListado_cierreinventarioPorPeriodo(cierreBE As cierreinventario) As List(Of cierreinventario) Implements IContService.GetListado_cierreinventarioPorPeriodo
        Dim cierreInventarioBL As New cierreinventarioBL
        Return cierreInventarioBL.GetListado_cierreinventarioPorPeriodo(cierreBE)
    End Function

    Public Function CajaTienePeriodoCerrado(strEmpresa As String, strperiodo As String, intIdEstaclecimiento As Integer) As Boolean Implements IContService.CajaTienePeriodoCerrado
        Dim cajaBL As New cierreCajaBL
        Return cajaBL.CajaTienePeriodoCerrado(strEmpresa, strperiodo, intIdEstaclecimiento)
    End Function

    Public Function UbicarExcedenteCompraPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As String, moneda As String) As List(Of documentocompra) Implements IContService.UbicarExcedenteCompraPorProveedorXperiodo
        Dim compraBL As New documentocompraBL
        Return compraBL.UbicarExcedenteCompraPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, moneda)
    End Function
#Region "Servicios"
    Public Sub EliminarServicio(servicioBE As servicio) Implements IContService.EliminarServicio
        Dim servicioBL As New servicioBL
        servicioBL.EliminarServicio(servicioBE)
    End Sub

    Public Function GrabarServicio(servicioBE As servicio) As Integer Implements IContService.GrabarServicio
        Dim servicioBL As New servicioBL
        Return servicioBL.Save(servicioBE)
    End Function

    Public Function ListadoServiciosHijos() As List(Of servicio) Implements IContService.ListadoServiciosHijos
        Dim servicioBL As New servicioBL
        Return servicioBL.ListadoServiciosHijos()
    End Function

    Public Function ListadoServiciosHijosXtipo(servicioBE As servicio) As List(Of servicio) Implements IContService.ListadoServiciosHijosXtipo
        Dim servicioBL As New servicioBL
        Return servicioBL.ListadoServiciosHijosXtipo(servicioBE)
    End Function



    Public Function UbicarServicioPorId(servicioBE As servicio) As servicio Implements IContService.UbicarServicioPorId
        Dim servicioBL As New servicioBL
        Return servicioBL.UbicarServicioPorId(servicioBE)
    End Function
#End Region

    Public Sub EliminarNotaCreditoMetodoVenta(obj As documento) Implements IContService.EliminarNotaCreditoMetodoVenta
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.EliminarNotaCreditoMetodoVenta(obj)
    End Sub

    Public Sub EliminarNotaDebitoVenta(obj As documento) Implements IContService.EliminarNotaDebitoVenta
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.EliminarNotaDebitoVenta(obj)
    End Sub

    Public Function UbicarExcedenteVentaPorClienteXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As String, intmoneda As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarExcedenteVentaPorClienteXperiodo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.UbicarExcedenteVentaPorClienteXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, intmoneda)
    End Function

    Public Function ListarDetallePagosXcodigoLibro(caja As documentoCaja) As List(Of documentoCajaDetalle) Implements IContService.ListarDetallePagosXcodigoLibro
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ListarDetallePagosXcodigoLibro(caja)
    End Function

    Public Function UbicarVentaPorClienteXperiodo2(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As DateTime, intmoneda As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarVentaPorClienteXperiodo2
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.UbicarVentaPorClienteXperiodo2(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, intmoneda)
    End Function

    Public Function GetCuentasXPagarTodoClientes(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As Date, intmoneda As String, estadocobro As String) As List(Of documentoventaAbarrotes) Implements IContService.GetCuentasXPagarTodoClientes
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetCuentasXPagarTodoClientes(strEmpresa, intIdEstablecimiento, strPeriodo, intmoneda, estadocobro)
    End Function

    Public Function SaveVentaNotaCredito2(objDocumento As documento, nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer Implements IContService.SaveVentaNotaCredito2
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.SaveVentaNotaCredito2(objDocumento, nDocumentoNota, nDocumentoSaldoVenta)
    End Function

    Public Function SaveVentaNotaDebito(objDocumento As documento) As Integer Implements IContService.SaveVentaNotaDebito
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.SaveVentaNotaDebito(objDocumento)
    End Function

    Public Function RecuperarCierre(intAnio As Integer, intMes As Integer, intIdItem As Integer) As cierreinventario Implements IContService.RecuperarCierre
        Dim ventaBL As New cierreinventarioBL
        Return ventaBL.RecuperarCierre(intAnio, intMes, intIdItem)
    End Function

    'Public Function RecuperarCierreListado(intAnio As Integer, intMes As Integer, intIdItem As Integer) As List(Of cierreinventario) Implements IContService.RecuperarCierreListado
    '    Dim ventaBL As New cierreinventarioBL
    '    Return ventaBL.RecuperarCierreListado(intAnio, intMes, intIdItem)
    'End Function


    Public Function ObtenerKardexRangoFecha(idAlmacen As String, fecDesde As Date, fecHasta As Date) As List(Of InventarioMovimiento) Implements IContService.ObtenerKardexRangoFecha
        Dim ventaBL As New InventarioMovimientoBL
        Return ventaBL.ObtenerKardexRangoFecha(idAlmacen, fecDesde, fecHasta)
    End Function

    Public Function GrabarVentaGeneral(objDocumento As documento) As List(Of totalesAlmacen) Implements IContService.GrabarVentaGeneral
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarVentaGeneral(objDocumento)
    End Function

    Public Sub GrabarCuetasPorCobrarApertura(be As List(Of documento)) Implements IContService.GrabarCuetasPorCobrarApertura
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.GrabarCuetasPorCobrarApertura(be)
    End Sub

    Public Sub CerrarInventario(lista As List(Of cierreinventario)) Implements IContService.CerrarInventario
        Dim cierreBL As New cierreinventarioBL
        cierreBL.CerrarInventario(lista)
    End Sub

    Public Function GrabarNotaDebito(objDocumento As documento, nDocumentoNota As documento) As Integer Implements IContService.GrabarNotaDebito
        Dim compraBL As New documentocompraBL
        Return compraBL.GrabarNotaDebito(objDocumento, nDocumentoNota)
    End Function

    Public Sub UpdateReciboHonorario(objDocumento As documento) Implements IContService.UpdateReciboHonorario
        Dim documentoBL As New documentocompraBL
        documentoBL.UpdateRegistroHonorarios(objDocumento)
    End Sub
    Public Sub DeleteReciboHonorario(nDocumento As documento) Implements IContService.DeleteReciboHonorario
        Dim documentoBL As New documentoBL
        documentoBL.DeleteSinglePagado(nDocumento.idDocumento) 'ELIMINANDO DOCUMENTO CAJA
    End Sub

    Public Function ListarCuentasServiciosPublicos(strIdEmpresa As String) As List(Of mascaraGastosEmpresa) Implements IContService.ListarCuentasServiciosPublicos
        Dim cuentasBL As New mascaraGastosEmpresaBL
        Return cuentasBL.ListarCuentasServiciosPublicos(strIdEmpresa)
    End Function

    Public Sub EliminarNotaCreditoMetodoNuevo(obj As documento) Implements IContService.EliminarNotaCreditoMetodoNuevo
        Dim compraBL As New documentocompraBL
        compraBL.EliminarNotaCreditoMetodoNuevo(obj)
    End Sub

    Public Sub EliminarNotaCreditoBonificacion(obj As documento) Implements IContService.EliminarNotaCreditoBonificacion
        Dim compraBL As New documentocompraBL
        compraBL.EliminarNotaCreditoBonificacion(obj)
    End Sub

    Public Sub EliminarNotaDebitoMetodoNuevo(obj As documento) Implements IContService.EliminarNotaDebitoMetodoNuevo
        Dim compraBL As New documentocompraBL
        compraBL.EliminarNotaDebitoMetodoNuevo(obj)
    End Sub

    Public Function BuscarCuentasFull(strPeriodo As Integer) As List(Of movimiento) Implements IContService.BuscarCuentasFull
        Dim cajaBL As New movimientoBL
        Return cajaBL.BuscarCuentasFull(strPeriodo)
    End Function

    Public Function ValidarPrecioExistente(intIdProducto As Integer) As listadoPrecios Implements IContService.ValidarPrecioExistente
        Dim cajaBL As New listadoPreciosBL
        Return cajaBL.GetUbicar_PrecioExistente(intIdProducto)
    End Function

    Public Sub ListaComprasAutoriza(objListaCompras As List(Of documentocompra)) Implements IContService.ListaComprasAutoriza
        Dim tipoCambioBL As New documentocompraBL
        tipoCambioBL.ListaComprasAutoriza(objListaCompras)
    End Sub

    Public Function CambiarTipoCambio(tipoCambioBE As tipoCambio) As Integer Implements IContService.CambiarTipoCambio
        Dim tipoCambioBL As New tipoCambioBL
        Return tipoCambioBL.InsertTipoCambio(tipoCambioBE)
    End Function


    Public Sub EliminarCompraGeneral(documentoBE As documento) Implements IContService.EliminarCompraGeneral
        Dim documentoBL As New documentoBL
        documentoBL.EliminarCompraGeneral(documentoBE)
    End Sub

    Public Function ValidarUsuarioAbierto(intIdUsuario As Integer) As cajaUsuario Implements IContService.ValidarUsuarioAbierto
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.ValidarUsuarioCajaAbierto(intIdUsuario)
    End Function

    Public Function InsertarMarca(nTabDet As tabladetalle) As Integer Implements IContService.InsertarMarca
        Dim actividadBL As New tabladetalleBL
        Return actividadBL.InsertMarca(nTabDet)
    End Function

    Public Function GetUbicarTablaexistencia() As List(Of tabladetalle) Implements IContService.GetUbicarTablaexistencia
        Dim asientoBL As New tabladetalleBL
        Return asientoBL.GetUbicarTablaexistencia()
    End Function

    Public Function GetListaTablaDetalleXusuario(intIdTabla As Integer, strEstado As String, listaoperacion As List(Of String)) As List(Of tabladetalle) Implements ServiceContract.IContService.GetListaTablaDetalleXusuario
        Dim tablaBL As New tabladetalleBL
        Return tablaBL.GetListaTablaDetalleXusuario(intIdTabla, strEstado, listaoperacion)
    End Function

    Public Function GetListarVentasNormalPorDiaCredito(intIdEstablec As Integer) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasNormalPorDiaCredito
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasNormalPorDiaCredito(intIdEstablec)
    End Function

    Public Function GetListarVentasNormalPorDia(intIdEstablec As Integer) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasNormalPorDia
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasNormalPorDia(intIdEstablec)
    End Function

    Public Function GetListarAllVentasxDia(intIdEstablec As Integer) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasxDia
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasxDia(intIdEstablec)
    End Function



    Public Function GetListAllComprasxDia(intIdEstablecimiento As Integer, Optional Dia As DateTime = Nothing) As List(Of documentocompra) Implements IContService.GetListAllComprasxDia
        Dim documentoBL As New documentocompraBL
        Return documentoBL.ListarComprasxDia(intIdEstablecimiento, Dia)
    End Function

    Public Function UbicarAsientoPorPeriodoXcodigo(srtFechaMes As Date, srtFechaAnio As Date, strAprobado As String, strCodigo As String) As List(Of asiento) Implements IContService.UbicarAsientoPorPeriodoXcodigo
        Dim asieNtoBL As New AsientoBL
        Return asieNtoBL.UbicarAsientoPorPeriodoXcodigo(srtFechaMes, srtFechaAnio, strAprobado, strCodigo)
    End Function

    Public Function GetListarAllVentasPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasPeriodo
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasPeriodo(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarAllVentasPeriodoXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasPeriodoXUsuario
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasPeriodoXUsuario(documentoventaAbarrotesBE)
    End Function

    Public Function GetListarAllVentasDiaXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasDiaXUsuario
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasDiaXUsuario(documentoventaAbarrotesBE)
    End Function

    Public Function GetListarAllCotizacionXDiaXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllCotizacionXDiaXUsuario
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllCotizacionXDiaXUsuario(documentoventaAbarrotesBE)
    End Function

    Public Function GetListarAllCotizacionXPeriodoXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllCotizacionXPeriodoXUsuario
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllCotizacionXPeriodoXUsuario(documentoventaAbarrotesBE)
    End Function

    Public Function GetListarAllVentasPeriodoPendiente(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasPeriodoPendiente
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasPeriodoPendiente(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarAllVentasPeriodoPendienteEspecial(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasPeriodoPendienteEspecial
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasPeriodoPendienteEspecial(intIdEstablec, strPeriodo)
    End Function

    Public Function GetVentasPeriodoByCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasPeriodoByCliente
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetVentasPeriodoByCliente(be)
    End Function

    Public Sub ElimiNarPagoCompra(documentoBE As documento) Implements IContService.ElimiNarPagoCompra
        Dim DocumentoCajaBL As New documentoBL
        DocumentoCajaBL.ElimiNarPagoCompra(documentoBE)
    End Sub

    Public Function GetListarVentasNormalPorPeriodoCredito(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasNormalPorPeriodoCredito
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasNormalPorPeriodoCredito(intIdEstablec, strPeriodo)
    End Function


    Public Function SaveVentaNormalServicioCredito(objDocumento As documento) As Integer Implements IContService.SaveVentaNormalServicioCredito
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveVentaNormalServicioCredito(objDocumento)
    End Function

    Public Sub UpdateVentaNormalServicioCredito(objDocumento As documento) Implements IContService.UpdateVentaNormalServicioCredito
        Dim documentoventaBL As New documentoventaAbarrotesBL
        documentoventaBL.UpdateVentaNormalServicioCredito(objDocumento)
    End Sub

    Public Function ListadoCajaDetalleHijos(intIdDocumento As Integer) As List(Of documentoCajaDetalle) Implements IContService.ListadoCajaDetalleHijos
        Dim DocumentoCajaBL As New documentoCajaDetalleBL
        Return DocumentoCajaBL.ListadoCajaDetalleHijos(intIdDocumento)
    End Function

    Public Function ListadoComprobaNtesXidPadre(iNtPadre As Integer) As List(Of documentoCaja) Implements IContService.ListadoComprobaNtesXidPadre
        Dim DocumentoCajaBL As New documentoCajaBL
        Return DocumentoCajaBL.ListadoComprobaNtesXidPadre(iNtPadre)
    End Function

    Public Function ObtenerMarcaPorAlmacenesPorMes(idAlmacen As String, marca As String, periodo As Integer, mes As String) As List(Of InventarioMovimiento) Implements IContService.ObtenerMarcaPorAlmacenesPorMes
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerMarcaPorAlmacenesPorMes(idAlmacen, marca, periodo, mes)
    End Function

    Public Function ObtenerMarcaPorAlmacenes(idAlmacen As String, marca As String) As List(Of InventarioMovimiento) Implements IContService.ObtenerMarcaPorAlmacenes
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerMarcaPorAlmacenes(idAlmacen, marca)
    End Function

    Public Function ObtenerMarcaPorAlmacenesPorAnio(idAlmacen As String, marca As String, Anio As Integer) As List(Of InventarioMovimiento) Implements IContService.ObtenerMarcaPorAlmacenesPorAnio
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerMarcaPorAlmacenesPorAnio(idAlmacen, marca, Anio)
    End Function

    Public Function ResumenTransaccionesUsuarios(intIdUserCaja As Integer, strTipoMov As String) As documentoCaja Implements IContService.ResumenTransaccionesUsuarios
        Dim documentoventaBL As New documentoCajaBL
        Return documentoventaBL.ResumenTransaccionesUsuarios(intIdUserCaja, strTipoMov)
    End Function

    Public Function GetSaldoCuentaFinancieraXusuario(documentoBE As documentoCaja) As documentoCaja Implements IContService.GetSaldoCuentaFinancieraXusuario
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.GetSaldoCuentaFinancieraXusuario(documentoBE)
    End Function

    Public Function ResumenTransaccionesxUsuarioDEP(intIdUserCaja As Integer) As documentoCaja Implements IContService.ResumenTransaccionesxUsuarioDEP
        Dim documentoventaBL As New documentoCajaBL
        Return documentoventaBL.ResumenTransaccionesxUsuarioDEP(intIdUserCaja)
    End Function

    Public Function ResumenTransaccionesFullUsers(intIdPadre As Integer, strTipoMov As String) As List(Of documentoCaja) Implements IContService.ResumenTransaccionesFullUsers
        Dim documentoventaBL As New documentoCajaBL
        Return documentoventaBL.ResumenTransaccionesFullUsers(intIdPadre, strTipoMov)
    End Function

    Public Function BuscarCajaOtrosMovimientosSingleME() As Decimal Implements ServiceContract.IContService.BuscarCajaOtrosMovimientosSingleME
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.BuscarCajaOtrosMovimientosSingleME()
    End Function


    Public Function getTableAnticiposPorPeriodoTipo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoAnticipo) Implements IContService.getTableAnticiposPorPeriodoTipo
        Dim documentoventaBL As New documentoAnticipoBL
        Return documentoventaBL.getTableAnticiposPorPeriodoTipo(strIdEmpresa, intIdEstablecimiento, strPeriodo, tipo)
    End Function
#Region "REPORTES"
#Region "veNtas"
    Public Function OntenerListadoVentasAbarrotesDia(strEmpresa As String, intIdEstablecimiento As Integer, day As Date) As List(Of documentoventaAbarrotes) Implements IContService.OntenerListadoVentasAbarrotesDia
        Dim compraBL As New documentoVentasAbarrotesRPT
        Return compraBL.OntenerListadoVentasAbarrotesDia(strEmpresa, intIdEstablecimiento, day)
    End Function

    Public Function OntenerListadoVentasAbarrotesPorMes(strEmpresa As String, intIdEstablecimiento As Integer, intmes As String, anio As Integer) As List(Of documentoventaAbarrotes) Implements IContService.OntenerListadoVentasAbarrotesPorMes
        Dim compraBL As New documentoVentasAbarrotesRPT
        Return compraBL.OntenerListadoVentasAbarrotesPorMes(strEmpresa, intIdEstablecimiento, intmes, anio)
    End Function

    Public Function ReportePagosDetalladoPorCliente(fecINic As Date, fecHAsta As Date, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle) Implements IContService.ReportePagosDetalladoPorCliente
        Dim documentocompraBL As New documentoCajaDetalleBL
        Return documentocompraBL.ReportePagosDetalladoPorCliente(fecINic, fecHAsta, idProv, MetodoPago)
    End Function

    Public Function ReporteCuentasPorCobrarPorCliente(fecINic As Date, fecHAsta As Date, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle) Implements IContService.ReporteCuentasPorCobrarPorCliente
        Dim documentocompraBL As New documentoCajaDetalleBL
        Return documentocompraBL.ReporteCuentasPorCobrarPorCliente(fecINic, fecHAsta, idProv, MetodoPago)
    End Function

    Public Function LidtadoNotasXCliente(fecINic As Date, fecHasta As Date, idProv As Integer) As List(Of documentoventaAbarrotes) Implements IContService.LidtadoNotasXCliente
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.LidtadoNotasXCliente(fecINic, fecHasta, idProv)
    End Function

    Public Function ListadoVentaClienteOrAnticulo(strIdEmpresa As String, intEstablec As Integer, idclie As Integer, nameArt As String, fecINic As Date, fecHasta As Date, tipo As String) As List(Of documentoventaAbarrotesDet) Implements IContService.ListadoVentaClienteOrAnticulo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.ListadoVentaClienteOrAnticulo(strIdEmpresa, intEstablec, idclie, nameArt, fecINic, fecHasta, tipo)
    End Function

    Public Function OntenerVentasAnuales(intIdEstablecimiento As Integer, anio As String) As List(Of documentoventaAbarrotes) Implements IContService.OntenerVentasAnuales
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasAnualesReporte(intIdEstablecimiento, anio)
    End Function

    Public Function OntenerCobrosVentaMes(intIdEstablecimiento As Integer, anio As String) As List(Of documentoCaja) Implements IContService.OntenerCobrosVentaMes
        Dim compraBL As New documentoCajaBL
        Return compraBL.GetCobrosPorMes(intIdEstablecimiento, anio)
    End Function

    Public Function ListadoVentaClienteArticulo(idclie As Integer, nameArt As String, fecINic As Date, fecHasta As Date) As List(Of documentoventaAbarrotesDet) Implements IContService.ListadoVentaClienteArticulo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.ListadoVentaClienteArticulo(idclie, nameArt, fecINic, fecHasta)
    End Function
#End Region

    Public Function UbicarAnticipoPorProveedorNroVoucher(intIdProveedor As Integer) As documentoAnticipo Implements ServiceContract.IContService.UbicarAnticipoPorProveedorNroVoucher
        Dim documentoventaBL As New documentoAnticipoBL
        Return documentoventaBL.UbicarAnticipoPorProveedorNroVoucher(intIdProveedor)
    End Function

    Public Function ObtenerCajaPagoPorVentaSL(ByVal idDocumentoVenta As Integer) As List(Of documentoCaja) Implements ServiceContract.IContService.ObtenerCajaPagoPorVentaSL
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaPagoPorVentaSL(idDocumentoVenta)
    End Function

    Public Sub ConfirmarVentaTicketSL(objDocumento As Business.Entity.documento, objDocumentoCaja As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen),
                                   cajaUsuario As Business.Entity.cajaUsuario, ndocAnticipoDetalle As documentoAnticipoDetalle,
                                    cajaUsuarioAporte As documento, objDocCajaDetalle As List(Of documentoCajaDetalle)) Implements ServiceContract.IContService.ConfirmarVentaTicketSL
        Dim documentoventaBL As New documentoventaAbarrotesBL
        documentoventaBL.ConfirmarVentaTicketSL(objDocumento, objDocumentoCaja, objTotalesAlmacen, cajaUsuario, ndocAnticipoDetalle, cajaUsuarioAporte, objDocCajaDetalle)
    End Sub
    Public Function ReportePagosDetalladoPorProveedor(fecINic As Date, fecHAsta As Date, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle) Implements IContService.ReportePagosDetalladoPorProveedor
        Dim documentocompraBL As New documentoCajaDetalleBL
        Return documentocompraBL.ReportePagosDetalladoPorProveedor(fecINic, fecHAsta, idProv, MetodoPago)
    End Function

    Public Function ReporteCuentasPorPagarPorProveedor(fecINic As Date, fecHAsta As Date, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle) Implements IContService.ReporteCuentasPorPagarPorProveedor
        Dim documentocompraBL As New documentoCajaDetalleBL
        Return documentocompraBL.ReporteCuentasPorPagarPorProveedor(fecINic, fecHAsta, idProv, MetodoPago)
    End Function

    Public Function ListaComprasXporveedor(fecInic As Date, fecHasta As Date, idProv As Integer) As List(Of documentocompradetalle) Implements IContService.ListaComprasXporveedor
        Dim documentocompraBL As New documentocompradetalleBL
        Return documentocompraBL.ListaComprasXporveedor(fecInic, fecHasta, idProv)
    End Function

    Public Function GetListarPagosPorANioReporte(ANio As Integer, strTipoMov As String) As List(Of documentoCaja) Implements IContService.GetListarPagosPorANioReporte
        Dim documentocompraBL As New documentoCajaBL
        Return documentocompraBL.GetListarPagosPorANioReporte(ANio, strTipoMov)
    End Function

    Public Function LidtadoNotasXempresa(fecINic As Date, fecHasta As Date, idProv As Integer) As List(Of documentocompra) Implements IContService.LidtadoNotasXempresa
        Dim documentocompraBL As New documentoCompraRPT
        Return documentocompraBL.LidtadoNotasXempresa(fecINic, fecHasta, idProv)
    End Function

    Public Function GetListarComprasPorANioReporte(intIdEstablecimiento As Integer, ANio As Integer) As List(Of documentocompra) Implements IContService.GetListarComprasPorANioReporte
        Dim documentocompraBL As New documentoCompraRPT
        Return documentocompraBL.GetListarComprasPorANioReporte(intIdEstablecimiento, ANio)
    End Function
#End Region

    Public Function GetVentasAnuales(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasAnuales
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetVentasAnuales(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetSumaCuentasXCobrar(intIdEstable As Integer, intNumero As Integer) As documentoventaAbarrotes Implements IContService.GetSumaCuentasXCobrar
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetSumaCuentasXCobrar(intIdEstable, intNumero)
    End Function

    Public Function GetListarVentasPorCategoria(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasPorCategoria
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPorCategoria(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarVentasPorAnio(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasPorAnio
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPorAnio(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function SumaxINgresosEgresos(strTipoMov As String) As List(Of documentoCaja) Implements IContService.SumaxINgresosEgresos
        Dim documentoventaBL As New documentoCajaBL
        Return documentoventaBL.SumaxINgresosEgresos(strTipoMov)
    End Function

    Public Function SumaxINgresosEgresosAnual() As List(Of documentoCaja) Implements IContService.SumaxINgresosEgresosAnual
        Dim documentoventaBL As New documentoCajaBL
        Return documentoventaBL.SumaxINgresosEgresosAnual()
    End Function

#Region "Anticipo"
    Public Function GetSumaCuentasXpagar(intIdEstable As Integer, strPeriodo As String) As documentocompra Implements IContService.GetSumaCuentasXpagar
        Dim compraBL As New documentocompraBL
        Return compraBL.GetSumaCuentasXpagar(intIdEstable, strPeriodo)
    End Function

    Public Function GetCuentasXpagarPorFechaVencimiento(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, caso As String) As List(Of documentocompra) Implements IContService.GetCuentasXpagarPorFechaVencimiento
        Dim compraBL As New documentocompraBL
        Return compraBL.GetCuentasXpagarPorFechaVencimiento(strEmpresa, intIdEstablecimiento, strRuc, caso)
    End Function

    Public Function GetCuentasXpagarPorFechaPeriodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra) Implements IContService.GetCuentasXpagarPorFechaPeriodo
        Dim compraBL As New documentocompraBL
        Return compraBL.GetCuentasXpagarPorFechaPeriodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function SumaxTipoEF(strTipo As String, strTipoMov As String) As documentoCaja Implements IContService.SumaxTipoEF
        Dim docCajaBL As New documentoCajaBL
        Return docCajaBL.SumaxTipoEF(strTipo, strTipoMov)
    End Function

    Public Function getTableAnticiposPorPeriodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoAnticipo) Implements IContService.getTableAnticiposPorPeriodo
        Dim documentoventaBL As New documentoAnticipoBL
        Return documentoventaBL.getTableAnticiposPorPeriodo(strIdEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function SaveAnticipoSL(objDocumento As Business.Entity.documento, objDocumentoCaja As Business.Entity.documento) As Integer Implements ServiceContract.IContService.SaveAnticipoSL
        Dim documentoBL As New documentoAnticipoBL
        Return documentoBL.SaveAnticipoSL(objDocumento, objDocumentoCaja)
    End Function

    Public Sub UpdateAnticipoSL(objDocumento As Business.Entity.documento, objDocumentoCaja As Business.Entity.documento) Implements ServiceContract.IContService.UpdateAnticipoSL
        Dim documentoventaBL As New documentoAnticipoBL
        documentoventaBL.UpdateAnticipoSL(objDocumento, objDocumentoCaja)
    End Sub

    Public Function UbicarDocumentoAnticipo(intidDocumento As Integer) As documentoAnticipo Implements ServiceContract.IContService.UbicarDocumentoAnticipo
        Dim documentoventaBL As New documentoAnticipoBL
        Return documentoventaBL.UbicarDocumentoAnticipo(intidDocumento)
    End Function

    Public Function ObtenerOtrosAportesXFinanzas(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipo As String) As List(Of documentoAnticipo) Implements IContService.ObtenerOtrosAportesXFinanzas
        Dim cajaBL As New documentoAnticipoBL
        Return cajaBL.ObtenerOtrosAportesXFinanzas(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, tipo)
    End Function

    Public Function ObtenerOtrosAportesXFinanzasFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoAnticipo) Implements IContService.ObtenerOtrosAportesXFinanzasFull
        Dim cajaBL As New documentoAnticipoBL
        Return cajaBL.ObtenerOtrosAportesXFinanzasFull(strEmpresa, intIdEstablecimiento, strPeriodo, tipo)
    End Function

    Public Sub DeleteAnticipoSL(nDocumento As Business.Entity.documento) Implements ServiceContract.IContService.DeleteAnticipoSL
        Dim documentoBL As New documentoBL
        documentoBL.DeleteAnticipoSL(nDocumento)
    End Sub

#End Region
    Public Function SaveVentaNormalServicio(objDocumento As documento, objDocumentoCaja As documento) As Integer Implements IContService.SaveVentaNormalServicio
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveVentaNormalServicio(objDocumento, objDocumentoCaja)
    End Function

    Public Sub UpdateVentaNormalServicio(objDocumento As documento, objDocumentoCaja As documento) Implements IContService.UpdateVentaNormalServicio
        Dim documentoventaBL As New documentoventaAbarrotesBL
        documentoventaBL.UpdateVentaNormalServicio(objDocumento, objDocumentoCaja)
    End Sub

    Public Sub DeleteVentaNormalServicio(documentoBE As documento) Implements IContService.DeleteVentaNormalServicio
        Dim documentoBL As New documentoBL
        documentoBL.DeleteVentaNormalServicio(documentoBE)
    End Sub

    Public Sub DeleteSingleVariable(ByVal intIdDocumento As Integer) Implements ServiceContract.IContService.DeleteSingleVariable
        Dim cajaBL As New documentoBL
        cajaBL.DeleteSingleVariableSL(intIdDocumento)
    End Sub

#Region "LIBROS COMTABLES"
    Public Function SaveVentaNormalAlContado(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objDocumentoCaja As documento) As Integer Implements IContService.SaveVentaNormalAlContado
        Dim DocumetoBL As New documentoventaAbarrotesBL
        Return DocumetoBL.SaveVentaNormalAlContado(objDocumento, objTotalesAlmacen, objDocumentoCaja)
    End Function

    Public Sub DeletePorIdAsiento(intIdAsiento As Integer) Implements IContService.DeletePorIdAsiento
        Dim DocumetoBL As New AsientoBL
        DocumetoBL.DeletePorIdAsiento(intIdAsiento)
    End Sub

    Public Sub ActualizarAsientoDetalleXidAsiento(objAsiento As asiento) Implements IContService.ActualizarAsientoDetalleXidAsiento
        Dim DocumetoBL As New AsientoBL
        DocumetoBL.ActualizarAsientoDetalleXidAsiento(objAsiento)
    End Sub

    Public Function UbicarAsientoPorIDAsiento(intIdAsiento As Integer) As asiento Implements IContService.UbicarAsientoPorIDAsiento
        Dim DocumetoBL As New AsientoBL
        Return DocumetoBL.UbicarAsientoPorIDAsiento(intIdAsiento)
    End Function

    Public Sub ActualizarEstadoAprobado(asientos As List(Of asiento)) Implements IContService.ActualizarEstadoAprobado
        Dim DocumetoBL As New AsientoBL
        DocumetoBL.ActualizarEstadoAprobado(asientos)
    End Sub

    Public Function UbicarMovimientosXidDocumento(intIdAsiento As Integer) As List(Of movimiento) Implements IContService.UbicarMovimientosXidDocumento
        Dim DocumetoBL As New movimientoBL
        Return DocumetoBL.UbicarMovimientosXidDocumento(intIdAsiento)
    End Function

    Public Function GetUbicar_documentoLibroDiarioDetallePorIDDocumento(idDoc As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_documentoLibroDiarioDetallePorIDDocumento
        Dim DocumetoBL As New documentoLibroDiarioDetalleBL
        Return DocumetoBL.GetUbicar_documentoLibroDiarioDetallePorIDDocumento(idDoc)
    End Function

    Public Function GrabarLibro(documento As documento) As Integer Implements IContService.GrabarLibro
        Dim DocumetoBL As New documentoLibroDiarioBL
        Return DocumetoBL.GrabarLibro(documento)
    End Function

    Public Function ListaLibroContable(libroBE As documentoLibroDiario) As List(Of documentoLibroDiario) Implements IContService.ListaLibroContable
        Dim DocumetoBL As New documentoLibroDiarioBL
        Return DocumetoBL.Lista(libroBE)
    End Function
#End Region

#Region "EMPRESA"
    Public Sub InsertarEmpresa(empresaBE As empresa, ListaMascaraContable2 As List(Of mascaraContable2), ListaCuentaMascara As List(Of cuentaMascara), ListamascaraGastosEmpresa As List(Of mascaraGastosEmpresa), ListacuentaplanContableEmpresa As List(Of cuentaplanContableEmpresa)) Implements IContService.InsertarEmpresa
        Dim empresaBL As New empresaBL
        empresaBL.InsertarEmpresa(empresaBE, ListaMascaraContable2, ListaCuentaMascara, ListamascaraGastosEmpresa, ListacuentaplanContableEmpresa)
    End Sub
#End Region

#Region "TIPO CAMBIO"
    Public Function GetListar_tipoCambio() As List(Of tipoCambio) Implements IContService.GetListar_tipoCambio
        Dim tipoCambioBL As New tipoCambioBL
        Return tipoCambioBL.GetListar_tipoCambio()
    End Function

    Public Sub EditarTC(tipoCambioBE As tipoCambio) Implements IContService.EditarTC
        Dim tipoCambioBL As New tipoCambioBL
        tipoCambioBL.Update(tipoCambioBE)
    End Sub

    Public Function InsertTC(tipoCambioBE As tipoCambio) As Integer Implements IContService.InsertTC
        Dim tipoCambioBL As New tipoCambioBL
        Return tipoCambioBL.Insert(tipoCambioBE)
    End Function

    Public Function GetListaTipoCambioMaxFecha(idEmpresa As String, intIdEstablecimiento As Integer) As tipoCambio Implements IContService.GetListaTipoCambioMaxFecha
        Dim tipoCambioBL As New tipoCambioBL
        Return tipoCambioBL.GetListaTipoCambioMaxFecha(idEmpresa, intIdEstablecimiento)
    End Function
#End Region

#Region "CONFIGURACION DE INICIO"
    Public Sub EditarConfigInicio(configBE As configuracionInicio) Implements IContService.EditarConfigInicio
        Dim configBL As New ConfiguracionInicioBL
        configBL.Editar(configBE)
    End Sub

    Public Sub EliminarConfigInicio(configBE As configuracionInicio) Implements IContService.EliminarConfigInicio
        Dim configBL As New ConfiguracionInicioBL
        configBL.Eliminar(configBE)
    End Sub

    Public Sub InsertConfigInicio(configBE As configuracionInicio) Implements IContService.InsertConfigInicio
        Dim configBL As New ConfiguracionInicioBL
        configBL.Insert(configBE)
    End Sub

    Public Function ObtenerConfigXempresa(strIdEmpresa As String, intIdEstaclecimiento As Integer) As configuracionInicio Implements IContService.ObtenerConfigXempresa
        Dim configBL As New ConfiguracionInicioBL
        Return configBL.ObtenerConfigXempresa(strIdEmpresa, intIdEstaclecimiento)
    End Function
#End Region

#Region "Notificacion"
    Public Function GetUbicarNotificacion(strIdEmpresa As String, intIdEstablecimiento As Integer, strEstado As String) As List(Of notificacionAlmacen) Implements IContService.GetUbicarNotificacion
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Return notificacionAlmacenBL.GetUbicarNotificacion(strIdEmpresa, intIdEstablecimiento, strEstado)
    End Function

    Public Function GetUbicarNotificacionCaja(strIdEmpresa As String, intIdEstablecimiento As Integer, strEstado As String) As List(Of notificacionAlmacen) Implements IContService.GetUbicarNotificacionCaja
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Return notificacionAlmacenBL.GetUbicarNotificacionCaja(strIdEmpresa, intIdEstablecimiento, strEstado)
    End Function

    Public Function GetUbicarNotificacionConteo(strIdEmpresa As String, intIdEstablecimiento As Integer, strSituacioN As String) As Integer Implements IContService.GetUbicarNotificacionConteo
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Return notificacionAlmacenBL.GetUbicarNotificacionConteo(strIdEmpresa, intIdEstablecimiento, strSituacioN)
    End Function

    Public Sub DeleteNotificacion(intIdDocumento As Integer) Implements IContService.DeleteNotificacion
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        notificacionAlmacenBL.DeleteNotificacion(intIdDocumento)
    End Sub
#End Region

#Region "MASCARA CUENTAS POR MODULO"
    Public Function UbicarCuentaXmoduloXitem(strEmpresa As String, strParametro As String, strTipoItem As String, strModulo As String) As Business.Entity.cuentaMascara Implements ServiceContract.IContService.UbicarCuentaXmoduloXitem
        Dim cierreBL As New cuentaMascaraBL
        Return cierreBL.UbicarCuentaXmoduloXitem(strEmpresa, strParametro, strTipoItem, strModulo)
    End Function

    Public Function UbicarEmpresaXmodulo(strEmpresa As String, strModulo As String) As System.Collections.Generic.List(Of Business.Entity.cuentaMascara) Implements ServiceContract.IContService.UbicarEmpresaXmodulo
        Dim cierreBL As New cuentaMascaraBL
        Return cierreBL.UbicarEmpresaXmodulo(strEmpresa, strModulo)
    End Function

#End Region

    Public Function UbicarAsientoXidDocumento(intIdDocumento As Integer) As List(Of movimiento) Implements IContService.UbicarAsientoXidDocumento
        Dim asientoBL As New movimientoBL
        Return asientoBL.UbicarAsientoXidDocumento(intIdDocumento)
    End Function

    Public Function RecuperarEstadoCierrePeriodo(strEmpresa As String, intIdEstablec As Integer, strPeriodo As String) As Business.Entity.cierrecontable Implements ServiceContract.IContService.RecuperarEstadoCierrePeriodo
        Dim cierreBL As New cierrecontableBL
        Return cierreBL.RecuperarEstadoCierrePeriodo(strEmpresa, intIdEstablec, strPeriodo)
    End Function

    Public Sub AperturarPeriodo(strEmpresa As String, intIdEstablec As Integer, strPeriodo As String) Implements ServiceContract.IContService.AperturarPeriodo
        Dim cierreBL As New cierrecontableBL
        cierreBL.AperturarPeriodo(strEmpresa, intIdEstablec, strPeriodo)
    End Sub

    Public Sub GrabarListaCierreCaja(lista As System.Collections.Generic.List(Of Business.Entity.cierreCaja)) Implements ServiceContract.IContService.GrabarListaCierreCaja
        Dim cierreBL As New cierreCajaBL
        cierreBL.GrabarListaCierreCaja(lista)
    End Sub

    Public Function GetObtenerCierreCajasModulos(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, intIdUser As String) As List(Of documentoCaja) Implements IContService.GetObtenerCierreCajasModulos
        Dim cierreBL As New documentoCajaBL
        Return cierreBL.GetObtenerCierreCajasModulos(strEmpresa, intIdEstablecimiento, strPeriodo, intIdUser)
    End Function

    Public Function CierreCerrado(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As Boolean Implements IContService.CierreCerrado
        Dim cierreBL As New cierrecontableBL
        Return cierreBL.CierreCerrado(strIdEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetCargarCierrePorPeriodo(idEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of cierrecontable) Implements IContService.GetCargarCierrePorPeriodo
        Dim cierreBL As New cierrecontableBL
        Return cierreBL.GetCargarCierrePorPeriodo(idEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Sub GrabarListaAsientos(lista As System.Collections.Generic.List(Of Business.Entity.cierrecontable), asiento As asiento, documento As documento) Implements ServiceContract.IContService.GrabarListaAsientos
        Dim cierreBL As New cierrecontableBL
        cierreBL.GrabarListaAsientos(lista, asiento, documento)
    End Sub

    Public Sub GrabarListaAsientosCierre(lista As List(Of cierrecontable)) Implements IContService.GrabarListaAsientosCierre
        Dim cierreBL As New cierrecontableBL
        cierreBL.GrabarListaAsientosCierre(lista)
    End Sub

    Public Sub UpdateListaAsientos(lista As System.Collections.Generic.List(Of Business.Entity.cierrecontable)) Implements ServiceContract.IContService.UpdateListaAsientos
        Dim cierreBL As New cierrecontableBL
        cierreBL.UpdateListaAsientos(lista)
    End Sub

    Public Function GetObetnerCierrePorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer, anio As Integer, mes As String) As System.Collections.Generic.List(Of Business.Entity.movimiento) Implements ServiceContract.IContService.GetObetnerCierrePorPeriodo
        Dim movmientoBL As New movimientoBL
        Return movmientoBL.GetObetnerCierrePorPeriodo(strEmpresa, intIdEstablecimiento, anio, mes)
    End Function

#Region "SOLICITUDES"



#Region "DOCUMENTO DATOS EXTRAS"
    Public Function UbicarDocumentoOtros(intIdDocumento As Integer) As Business.Entity.documentoOtrosDatos Implements ServiceContract.IContService.UbicarDocumentoOtros
        Dim documentoBL As New documentoOtrosDatosBL
        Return documentoBL.GetUbicar_documentocompraID(intIdDocumento)
    End Function

    Public Function UbicarDocumentoOtrosReferencia(intIdDocumento As Integer) As Business.Entity.documentoOtrosDatos Implements ServiceContract.IContService.UbicarDocumentoOtrosReferencia
        Dim documentoBL As New documentoOtrosDatosBL
        Return documentoBL.GetUbicar_documentocompraPorIDReferencia(intIdDocumento)
    End Function


    Public Sub UpdateDocOtros(idSolc As Business.Entity.documentoOtrosDatos) Implements ServiceContract.IContService.UpdateDocOtros
        Dim otrosBL As New documentoOtrosDatosBL()
        otrosBL.UpdateOtros(idSolc)
    End Sub

    Public Sub GrabarDatosEntregaOrdenesFull(ByVal documentoOtrosDatosBE As List(Of documentoOtrosDatos), intIdDocumento As Integer) Implements ServiceContract.IContService.GrabarDatosEntregaOrdenesFull
        Dim documentoBL As New documentoOtrosDatosBL
        documentoBL.GrabarDatosEntregaOrdenesFull(documentoOtrosDatosBE, intIdDocumento)
    End Sub

    Public Function UbicarDocumentoOtrosHistorialEntrega(intIdDocumento As Integer) As List(Of documentoOtrosDatos) Implements ServiceContract.IContService.UbicarDocumentoOtrosHistorialEntrega
        Dim documentoBL As New documentoOtrosDatosBL
        Return documentoBL.UbicarDocumentoOtrosHistorialEntrega(intIdDocumento)
    End Function

    Public Function DeleteSingleOC(intIdDocumento As Integer) As Boolean Implements ServiceContract.IContService.DeleteSingleOC
        Dim documentoBL As New documentoOtrosDatosBL
        Return documentoBL.DeleteSingleOC(intIdDocumento)
    End Function

    Public Sub GrabarDatosEntregaOrdenes(ByVal documentoOtrosDatosBE As documentoOtrosDatos, ByVal documentoCompraDeatlle As documentocompradetalle) Implements ServiceContract.IContService.GrabarDatosEntregaOrdenes
        Dim documentoBL As New documentoOtrosDatosBL
        documentoBL.InsertOrdenDetalle(documentoOtrosDatosBE, documentoCompraDeatlle)
    End Sub

    Public Sub GrabarDatosEntregaOrdeneCompra(ByVal documentoOtrosDatosBE As documentoOtrosDatos, ByVal intidDocumento As Integer) Implements ServiceContract.IContService.GrabarDatosEntregaOrdeneCompra
        Dim documentoBL As New documentoOtrosDatosBL
        documentoBL.Insert(documentoOtrosDatosBE, intidDocumento)
    End Sub
#End Region

#Region "ORDENES"
    Public Function GetListarOrdenCompraPorDia(intIdEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarOrdenCompraPorDia
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarOrdenCompraPorDia(intIdEmpresa)
    End Function

    Public Function GetListarOrdenServicioPorDia(intIdEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarOrdenServicioPorDia
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarOrdenServicioPorDia(intIdEmpresa)
    End Function

    Public Function GetListarOrdenServicio(intIdEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarOrdenServicio
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarOrdenServicio(intIdEmpresa)
    End Function

    Public Function GetListarOrdenCompra(intIdEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarOrdenCompra
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarOrdenCompra(intIdEmpresa)
    End Function
#End Region

    Public Sub UpdateDoc(idSolc As Business.Entity.documentocompra) Implements ServiceContract.IContService.UpdateDoc
        Dim recursoBL As New documentocompraBL()
        recursoBL.UpdateSoli(idSolc)
    End Sub

    Public Sub UpdateOrdenCompra(idSolc As Business.Entity.documentocompradetalle, strTipoDoc As String) Implements ServiceContract.IContService.UpdateOrdenCompra
        Dim recursoBL As New documentocompradetalleBL()
        recursoBL.UpdateSolicitudMartin(idSolc, strTipoDoc)
    End Sub

    Public Function SumaNotasXidPadreItem(intIdSecuencia As Integer) As documentocompradetalle Implements IContService.SumaNotasXidPadreItem
        Dim recursoBL As New documentocompradetalleBL()
        Return recursoBL.SumaNotasXidPadreItem(intIdSecuencia)
    End Function

    Public Function SumaNotasXidPadreItemVentas(intIdSecuencia As Integer) As documentoventaAbarrotesDet Implements IContService.SumaNotasXidPadreItemVentas
        Dim recursoBL As New documentocompradetalleBL()
        Return recursoBL.SumaNotasXidPadreItemVentas(intIdSecuencia)
    End Function

    Public Function SaveDocumentoCompraSolicitud(nDocumento As Business.Entity.documento) As Integer Implements ServiceContract.IContService.SaveDocumentoCompraSolicitud
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraSolicitud(nDocumento)
    End Function

    Public Function GrabarOrdenes(objDocumento As documento, objOtroDoc As documentoOtrosDatos) As Integer Implements IContService.GrabarOrdenes
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GrabarOrdenes(objDocumento, objOtroDoc)
    End Function

    Public Sub EstadoSoli(idSolc As Business.Entity.documentocompra) Implements ServiceContract.IContService.EstadoSoli
        Dim recursoBL As New documentocompradetalleBL()
        recursoBL.EstadoSoli(idSolc)
    End Sub

    Public Function GetListarSolicitudesCompra(intIdEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarSolicitudesCompra
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarSolicitudes(intIdEmpresa)
    End Function

    Public Function GetListarSolicitudesCompraDia(intIdEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarSolicitudesCompraDia
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarSolicitudesDia(intIdEmpresa)
    End Function
#End Region

#Region "CONFIGURACION DEL SISTEMA"
    Public Function UbicarConfiguracionPorEmpresaModulo(strIdModulo As String, strIdEmpresa As String, intIdEstablecimiento As Integer) As Business.Entity.moduloConfiguracion Implements ServiceContract.IContService.UbicarConfiguracionPorEmpresaModulo
        Dim sistemaBL As New ModuloConfiguracionBL
        Return sistemaBL.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function UbicarConfiguracionPorID(intIdConfig As Integer) As Business.Entity.moduloConfiguracion Implements ServiceContract.IContService.UbicarConfiguracionPorID
        Dim sistemaBL As New ModuloConfiguracionBL
        Return sistemaBL.UbicarConfiguracionPorID(intIdConfig)
    End Function

    Public Function UbicarModuloPorCodigo(strIdModulo As String) As Business.Entity.moduloApp Implements ServiceContract.IContService.UbicarModuloPorCodigo
        Dim sistemaBL As New ModuloAppBL
        Return sistemaBL.UbicarModuloPorCodigo(strIdModulo)
    End Function

    Public Function TieneConfiguracionComprobante(strIdEmpresa As String, strIdModulo As String) As Boolean Implements ServiceContract.IContService.TieneConfiguracionComprobante
        Dim sistemaBL As New ModuloConfiguracionBL
        Return sistemaBL.TieneConfiguracionComprobante(strIdEmpresa, strIdModulo)
    End Function

    Public Function ListaModulos() As System.Collections.Generic.List(Of Business.Entity.moduloApp) Implements ServiceContract.IContService.ListaModulos
        Dim sistemaBL As New ModuloAppBL
        Return sistemaBL.ListaModulos
    End Function

    Public Sub EliminarConfigSistema(objConfiguracion As Business.Entity.moduloConfiguracion) Implements ServiceContract.IContService.EliminarConfigSistema
        Dim sistemaBL As New ModuloConfiguracionBL
        sistemaBL.Delete(objConfiguracion)
    End Sub

    Public Function GrabarConfigSistema(objConfiguracion As Business.Entity.moduloConfiguracion) As Integer Implements ServiceContract.IContService.GrabarConfigSistema
        Dim sistemaBL As New ModuloConfiguracionBL
        Return sistemaBL.Grabar(objConfiguracion)
    End Function

    Public Function ListaModulosConfigurados(moduloConfiguracionBE As moduloConfiguracion) As System.Collections.Generic.List(Of Business.Entity.moduloConfiguracion) Implements ServiceContract.IContService.ListaModulosConfigurados
        Dim sistemaBL As New ModuloConfiguracionBL
        Return sistemaBL.ListaModulosConfigurados(moduloConfiguracionBE)
    End Function

    Public Function UpdateConfigSistema(objConfiguracion As Business.Entity.moduloConfiguracion) As Integer Implements ServiceContract.IContService.UpdateConfigSistema
        Dim sistemaBL As New ModuloConfiguracionBL
        Return sistemaBL.Update2(objConfiguracion)
    End Function
#End Region

#Region "OBLIGACIONES TRIBUTOS"
    Public Function UbicarDetallePorTributo(intIdDocumento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoObligacionDetalle) Implements ServiceContract.IContService.UbicarDetallePorTributo
        Dim docObligacionBL As New documentoObligacionTributariaDetalleBL
        Return docObligacionBL.UbicarDetallePorTributo(intIdDocumento)
    End Function

    Public Sub UpdateTributo(objDocumento As Business.Entity.documento, intIdDocumentoOrigen As Integer) Implements ServiceContract.IContService.UpdateTributo
        Dim docObligacionBL As New documentoObligacionTributariaBL
        docObligacionBL.UpdateTributo(objDocumento, intIdDocumentoOrigen)
    End Sub

    Public Function ExistenDatosDetalleObligacion(intIdDocumentoOrigen As Integer) As Boolean Implements ServiceContract.IContService.ExistenDatosDetalleObligacion
        Dim docObligacionBL As New documentoObligacionTributariaDetalleBL
        Return docObligacionBL.ExistenDatosDetalleObligacion(intIdDocumentoOrigen)
    End Function

    Public Function UbicarDocumentoObligacion(intIdDocumento As Integer) As Business.Entity.documentoObligacionTributaria Implements ServiceContract.IContService.UbicarDocumentoObligacion
        Dim docObligacionBL As New documentoObligacionTributariaBL
        Return docObligacionBL.UbicarDocumentoObligacion(intIdDocumento)
    End Function

    Public Function SaveObligacion(objDocumento As Business.Entity.documento, intIdDocumentoOrigen As Integer) As Integer Implements ServiceContract.IContService.SaveObligacion
        Dim docObligacionBL As New documentoObligacionTributariaBL
        Return docObligacionBL.SaveObligacion(objDocumento, intIdDocumentoOrigen)
    End Function

    Public Function UbicarTributoPorIdDocumentoCompra(intIdDocumento As Integer) As Business.Entity.documentoObligacionTributaria Implements ServiceContract.IContService.UbicarTributoPorIdDocumentoCompra
        Dim docObligacionBL As New documentoObligacionTributariaBL
        Return docObligacionBL.UbicarTributoPorIdDocumentoCompra(intIdDocumento)
    End Function

    Public Function ListadoTributoPorIdDocumentoOrigen(intIdDocumentoOrigen As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoObligacionTributaria) Implements ServiceContract.IContService.ListadoTributoPorIdDocumentoOrigen
        Dim docObligacionBL As New documentoObligacionTributariaBL
        Return docObligacionBL.ListadoTributoPorIdDocumentoOrigen(intIdDocumentoOrigen)
    End Function

    Public Sub EliminarObligacion(intIdDocumento As Integer) Implements ServiceContract.IContService.EliminarObligacion
        Dim docObligacionBL As New documentoObligacionTributariaBL
        docObligacionBL.EliminarObligacion(intIdDocumento)
    End Sub

    Public Sub EliminarObligacionPercepcion(intIdDocumento As Integer, intIdDocumentoTributo As Integer) Implements ServiceContract.IContService.EliminarObligacionPercepcion
        Dim docObligacionBL As New documentoBL
        docObligacionBL.EliminarObligacionPercepcion(intIdDocumento, intIdDocumentoTributo)
    End Sub
#End Region

#Region "MASCARA CONTABLE GASTOS"
    Public Function ObtenerMascaraGastos(strIdEmpresa As String, strCuentaPadre As String) As System.Collections.Generic.List(Of Business.Entity.mascaraGastosEmpresa) Implements ServiceContract.IContService.ObtenerMascaraGastos
        Dim MascaraBL As New mascaraGastosEmpresaBL
        Return MascaraBL.ObtenerMascaraGastos(strIdEmpresa, strCuentaPadre)
    End Function
#End Region

#Region "GUIAS DE REMISION"
    Public Function UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento As Integer) As Business.Entity.documentoguiaDetalle Implements ServiceContract.IContService.UbicarGuiaDetallePorIdDocumentoPadreCAC
        Dim documentoDetalleBL As New documentoguiaDetalleBL
        Return documentoDetalleBL.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
    End Function

    Public Function UbicarDocumentoGuiaDetalle(intIdDocumento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoguiaDetalle) Implements ServiceContract.IContService.UbicarDocumentoGuiaDetalle
        Dim documentoDetalleBL As New documentoguiaDetalleBL
        Return documentoDetalleBL.UbicarDocumentoGuiaDetalle(intIdDocumento)
    End Function

    Public Function ListaGuiasPorCompra(intIdDocumentoCompra As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoGuia) Implements ServiceContract.IContService.ListaGuiasPorCompra
        Dim documentoBL As New documentoGuiaBL
        Return documentoBL.ListaGuiasPorCompra(intIdDocumentoCompra)
    End Function

    Public Function ListaGuiasPorCompraConEntidad(intIdDocumentoCompra As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoGuia) Implements ServiceContract.IContService.ListaGuiasPorCompraConEntidad
        Dim documentoBL As New documentoGuiaBL
        Return documentoBL.ListaGuiasPorCompraConEntidad(intIdDocumentoCompra)
    End Function

    Public Function ListaGuiasPorCompraSinEntidad(intIdDocumentoCompra As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoGuia) Implements ServiceContract.IContService.ListaGuiasPorCompraSinEntidad
        Dim documentoBL As New documentoGuiaBL
        Return documentoBL.ListaGuiasPorCompraSinEntidad(intIdDocumentoCompra)
    End Function

    Public Function UbicarGuiaPorIdDocumento(intIdDocumento As Integer) As Business.Entity.documentoGuia Implements ServiceContract.IContService.UbicarGuiaPorIdDocumento
        Dim documentoBL As New documentoGuiaBL
        Return documentoBL.UbicarGuiaPorIdDocumento(intIdDocumento)
    End Function
#End Region

#Region "Reportes"
    Public Function GetListarComprasPorAnio(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra) Implements IContService.GetListarComprasPorAnio
        Dim compraBL As New documentocompraBL
        Return compraBL.GetListarComprasPorAnioEmpresa(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarComprasPorANioGeNeral(intIdEstablecimiento As Integer, strANio As String) As List(Of documentocompra) Implements IContService.GetListarComprasPorANioGeNeral
        Dim compraBL As New documentocompraBL
        Return compraBL.GetListarComprasPorANioGeNeral(intIdEstablecimiento, strANio)
    End Function

    Public Function GetListarComprasPorDiaReporte(intIdEstablecimiento As Integer, fechaDia As Date) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasPorDiaReporte
        Dim compraBL As New documentoCompraRPT
        Return compraBL.GetListarComprasPorDiaReporte(intIdEstablecimiento, fechaDia)
    End Function

    Public Function GetListarComprasPorPeriodoReporte(intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasPorPeriodoReporte
        Dim compraBL As New documentoCompraRPT
        Return compraBL.GetListarComprasPorPeriodoReporte(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarMvimientosCajaPorDiaReporte(intIdEmpresa As String, intIdEstablecimiento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.GetListarMvimientosCajaPorDiaReporte
        Dim compraBL As New documentoCajaRPT
        Return compraBL.GetListarMvimientosCajaPorDiaReporte(intIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetListarMvimientosCajaPorPeriodoReporte(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.GetListarMvimientosCajaPorPeriodoReporte
        Dim compraBL As New documentoCajaRPT
        Return compraBL.GetListarMvimientosCajaPorPeriodoReporte(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarMvimientosAlmacenPorDiaReporte(intIdEstablecimiento As Integer, strTipoCompra As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarMvimientosAlmacenPorDiaReporte
        Dim compraBL As New documentoCompraRPT
        Return compraBL.GetListarMvimientosAlmacenPorDiaReporte(intIdEstablecimiento, strTipoCompra)
    End Function

    Public Function OntenerListadoComprasPorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.OntenerListadoComprasPorPeriodo
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasPorPeriodo(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function ObtenerAsientosPorPeriodoFullReporte() As System.Collections.Generic.List(Of asiento) Implements ServiceContract.IContService.ObtenerAsientosPorPeriodoFullReporte
        Dim compraBL As New LibroDiarioRPT
        Return compraBL.ObtenerAsientosPorPeriodoFullReporte
    End Function

    Public Function UbicarReporteAsientoPorDocumento(intIdDocumento As Integer) As System.Collections.Generic.List(Of asiento) Implements ServiceContract.IContService.UbicarReporteAsientoPorDocumento
        Dim compraBL As New LibroDiarioRPT
        Return compraBL.UbicarReporteAsientoPorDocumento(intIdDocumento)
    End Function

    Public Function UbicarReporteAsientoPorEntidad(intidEntidad As Integer) As System.Collections.Generic.List(Of asiento) Implements ServiceContract.IContService.UbicarReporteAsientoPorEntidad
        Dim compraBL As New LibroDiarioRPT
        Return compraBL.UbicarReporteAsientoPorEntidad(intidEntidad)
    End Function

    Public Function UbicarReporteAsientoPorTipo(srtidTipo As String) As System.Collections.Generic.List(Of asiento) Implements ServiceContract.IContService.UbicarReporteAsientoPorTipo
        Dim compraBL As New LibroDiarioRPT
        Return compraBL.UbicarReporteAsientoPorTipo(srtidTipo)
    End Function

    Public Function UbicarReporteAsientoPorFecha(srtFechaInicio As Date, srtFechaHasta As Date, srtidTipo As String) As System.Collections.Generic.List(Of asiento) Implements ServiceContract.IContService.UbicarReporteAsientoPorFecha
        Dim compraBL As New LibroDiarioRPT
        Return compraBL.UbicarReporteAsientoPorFecha(srtFechaInicio, srtFechaHasta, srtidTipo)
    End Function

    Public Function UbicarReporteAsientoPorPeriodo(srtFechaAnio As String, srtFechaMes As String) As List(Of asiento) Implements IContService.UbicarReporteAsientoPorPeriodo
        Dim compraBL As New LibroDiarioRPT
        Return compraBL.UbicarReporteAsientoPorPeriodo(srtFechaAnio, srtFechaMes)
    End Function

    Public Function UbicarReporteAsientosPorPeriodoFull(srtFechaAnio As Integer) As System.Collections.Generic.List(Of asiento) Implements ServiceContract.IContService.UbicarReporteAsientosPorPeriodoFull
        Dim compraBL As New LibroDiarioRPT
        Return compraBL.UbicarReporteAsientosPorPeriodoFull(srtFechaAnio)
    End Function

    Public Function UbicarReporteAsientoPorAcumulado(dtpDesdeAnio As Date, dtphastaAnio As Date) As System.Collections.Generic.List(Of asiento) Implements ServiceContract.IContService.UbicarReporteAsientoPorAcumulado
        Dim compraBL As New LibroDiarioRPT
        Return compraBL.UbicarReporteAsientoPorAcumulado(dtpDesdeAnio, dtphastaAnio)
    End Function

    Public Function GetUbicarMovimientoLibroMayorFull(strPeriodo As List(Of String), periodo As String) As List(Of movimiento) Implements IContService.GetUbicarMovimientoLibroMayorFull
        Dim compraBL As New LibroMayorRPT
        Return compraBL.GetUbicarMovimientoLibroMayorFull(strPeriodo, periodo)
    End Function

    Public Function GetUbicarMovimientoLibroMayorPorIdDocumento(strCuenta As String) As System.Collections.Generic.List(Of movimiento) Implements ServiceContract.IContService.GetUbicarMovimientoLibroMayorPorIdDocumento
        Dim compraBL As New LibroMayorRPT
        Return compraBL.GetUbicarMovimientoLibroMayorPorIdDocumento(strCuenta)
    End Function

    Public Function BuscarInformePorClaseReporte(strCuenta As String, anio As String) As List(Of movimiento) Implements IContService.BuscarInformePorClaseReporte
        Dim compraBL As New InformeClasesRPT
        Return compraBL.BuscarInformePorClaseReporte(strCuenta, anio)
    End Function

    Public Function BuscarInformePorClaseAcumuladoReporte(strFechaDesde As Date, strFechaHasta As Date, strCuenta As String) As System.Collections.Generic.List(Of movimiento) Implements ServiceContract.IContService.BuscarInformePorClaseAcumuladoReporte
        Dim compraBL As New InformeClasesRPT
        Return compraBL.BuscarInformePorClaseAcumuladoReporte(strFechaDesde, strFechaHasta, strCuenta)
    End Function

    Public Function BuscarInformePorClaseMesReporte(strPeriodo As String, intMes As String, strCuenta As String) As List(Of movimiento) Implements IContService.BuscarInformePorClaseMesReporte
        Dim compraBL As New InformeClasesRPT
        Return compraBL.BuscarInformePorClaseMesReporte(strPeriodo, intMes, strCuenta)
    End Function

    'Reportes hoja de traajo final

    Public Function BuscarHojaTrabajoFinalFullReporte(strPeriodo As Integer) As System.Collections.Generic.List(Of Business.Entity.movimiento) Implements ServiceContract.IContService.BuscarHojaTrabajoFinalFullReporte
        Dim cajaBL As New HojaTrabajoFinalRPT
        Return cajaBL.BuscarHojaTrabajoFinalFullReporte(strPeriodo)
    End Function

    Public Function BuscarHojaTrabajoFinalPorMesReporte(strPeriodo As String, intMes As String) As List(Of movimiento) Implements IContService.BuscarHojaTrabajoFinalPorMesReporte
        Dim cajaBL As New HojaTrabajoFinalRPT
        Return cajaBL.ReporteHojaTrabajoXperiodo(strPeriodo, intMes)
    End Function

    Public Function BuscarHojaTrabajoFinalPorAcumuladoReporte(strFechaDesde As Date, strFechaHasta As Date) As System.Collections.Generic.List(Of Business.Entity.movimiento) Implements ServiceContract.IContService.BuscarHojaTrabajoFinalPorAcumuladoReporte
        Dim cajaBL As New HojaTrabajoFinalRPT
        Return cajaBL.BuscarHojaTrabajoFinalPorAcumuladoReporte(strFechaDesde, strFechaHasta)
    End Function

    Public Function BuscarInformePorCuentaContableReporte(strCuenta As String, strRazonSocial As String) As System.Collections.Generic.List(Of Business.Entity.movimiento) Implements ServiceContract.IContService.BuscarInformePorCuentaContableReporte
        Dim cajaBL As New InformeCuentaContableRPT
        Return cajaBL.BuscarInformePorCuentaContableReporte(strCuenta, strRazonSocial)
    End Function

    'martin

    Public Function OntenerListadoComprasPorEmpresa(strEmpresa As String, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.OntenerListadoComprasPorEmpresa
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasPorEmpresa(strEmpresa, strPeriodo)
    End Function

    Public Function OntenerListadoComprasConBonificacion(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompradetalle) Implements ServiceContract.IContService.OntenerListadoComprasConBonificacion
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasConBonificacion(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function OntenerListadoComprasPorProveedor(strEmpresa As String, intIdProveedor As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.OntenerListadoComprasPorProveedor
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasPorProveedor(strEmpresa, intIdProveedor, strPeriodo)
    End Function

    Public Function OntenerListadoComprasPorProveedorEstablec(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.OntenerListadoComprasPorProveedorEstablec
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasPorProveedorEstablec(strEmpresa, intIdEstablecimiento, intIdProveedor, strPeriodo)
    End Function

    Public Function OntenerListadoVentasAbarrotesPorDia(strEmpresa As String, intIdEstablecimiento As Integer, strTipoCompra As String) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotes) Implements ServiceContract.IContService.OntenerListadoVentasAbarrotesPorDia
        Dim compraBL As New documentoVentasAbarrotesRPT
        Return compraBL.OntenerListadoVentasAbarrotesPorDia(strEmpresa, intIdEstablecimiento, strTipoCompra)
    End Function

    Public Function OntenerListadoVentasAbarrotes(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotes) Implements ServiceContract.IContService.OntenerListadoVentasAbarrotes
        Dim compraBL As New documentoVentasAbarrotesRPT
        Return compraBL.OntenerListadoVentasAbarrotesPorPeriodo(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function OntenerListadoVentasAbarrotesEmpresa(strEmpresa As String, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotes) Implements ServiceContract.IContService.OntenerListadoVentasAbarrotesEmpresa
        Dim compraBL As New documentoVentasAbarrotesRPT
        Return compraBL.OntenerListadoVentasAbarrotesEmpresa(strEmpresa, strPeriodo)
    End Function

    Public Function OntenerListadoVentasAbarrotesPorCliente(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, intIDcliente As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotes) Implements ServiceContract.IContService.OntenerListadoVentasAbarrotesPorCliente
        Dim compraBL As New documentoVentasAbarrotesRPT
        Return compraBL.OntenerListadoVentasAbarrotesPorCliente(strEmpresa, intIdEstablecimiento, strPeriodo, intIDcliente)
    End Function

    Public Function OntenerListadoComprasPorAportacionesPorDia(strEmpresa As String, intIdEstablecimiento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.OntenerListadoComprasPorAportacionesPorDia
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasPorAportacionesPorDia(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function OntenerListadoComprasPorAportaciones(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.OntenerListadoComprasPorAportaciones
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasPorAportaciones(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function OntenerListadoComprasAportacionesPorEmpresa(strEmpresa As String, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.OntenerListadoComprasAportacionesPorEmpresa
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasPorAporteEmpresa(strEmpresa, strPeriodo)
    End Function

    Public Function OntenerListadoComprasAportacionesProveedor(strEmpresa As String, intIdProveedor As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.OntenerListadoComprasAportacionesProveedor
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasAportacionesPorProveedor(strEmpresa, intIdProveedor, strPeriodo)
    End Function

    Public Function OntenerListadoComprasAportacionesPorProveedorEstablec(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.OntenerListadoComprasAportacionesPorProveedorEstablec
        Dim compraBL As New documentoCompraRPT
        Return compraBL.OntenerListadoComprasAportacionesPorProveedorEstablec(strEmpresa, intIdEstablecimiento, intIdProveedor, strPeriodo)
    End Function

    Public Function ObtenerProdPorAlmacenesPeriodoRPT(idAlmacen As String, strItem As String, periodo As Integer, mes As String) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerProdPorAlmacenesPeriodoRPT
        Dim almacenBL As New inventarioMovimientoRPT
        Return almacenBL.ObtenerProdPorAlmacenesPeriodoRPT(idAlmacen, strItem, periodo, mes)
    End Function

    'Public Function ObtenerKardexPorAlmacen(idAlmacen As String, periodo As Integer, mes As String) As List(Of InventarioMovimiento) Implements IContService.ObtenerKardexPorAlmacen
    '    Dim almacenBL As New inventarioMovimientoRPT
    '    Return almacenBL.ObtenerKardexPorAlmacen(idAlmacen, periodo, mes)
    'End Function

    Public Function ObtenerProdPorAlmacenesDiaRPT(idAlmacen As String, strItem As String) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerProdPorAlmacenesDiaRPT
        Dim almacenBL As New inventarioMovimientoRPT
        Return almacenBL.ObtenerProdPorAlmacenesDiaRPT(idAlmacen, strItem)
    End Function

    Public Function ObtenerKardexPorAlmacenAnio(ByVal idAlmacen As String, ByVal Anio As Integer) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerKardexPorAlmacenAnio
        Dim almacenBL As New inventarioMovimientoRPT
        Return almacenBL.ObtenerKardexPorAlmacenAnio(idAlmacen, Anio)
    End Function

    Public Function ObtenerKardexPorAlmacenMes(idAlmacen As String, periodo As Integer, mes As String) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerKardexPorAlmacenMes
        Dim almacenBL As New inventarioMovimientoRPT
        Return almacenBL.ObtenerKardexPorAlmacenMes(idAlmacen, periodo, mes)
    End Function


    Public Function ReporteKardexPorProducto(idAlmacen As String, iNtProducto As Integer, fecDesde As Date, fecHasta As Date) As List(Of InventarioMovimiento) Implements IContService.ReporteKardexPorProducto
        Dim almacenBL As New inventarioMovimientoRPT
        Return almacenBL.ReporteKardexPorProducto(idAlmacen, iNtProducto, fecDesde, fecHasta)
    End Function

    Public Function ObtenerKardexPorAlmacenDia(idAlmacen As String) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerKardexPorAlmacenDia
        Dim almacenBL As New inventarioMovimientoRPT
        Return almacenBL.ObtenerKardexPorAlmacenDia(idAlmacen)
    End Function

    Public Function ObtenerProrAlmacenesPeriodoRPT(intIdAlmacen As Integer, strTipoEx As Integer, strBusqueda As String) As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen) Implements ServiceContract.IContService.ObtenerProrAlmacenesPeriodoRPT
        Dim almacenBL As New totalesAlmacenRPT
        Return almacenBL.ObtenerProrAlmacenesPeriodoRPT(intIdAlmacen, strTipoEx, strBusqueda)
    End Function

    Public Function ObtenerCajaOnlineRPT(strIdEmpresa As String, intIdEstablecimiento As Integer, strMEs As String, strAnio As String, strEntidadFinanciera As String) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineRPT
        Dim documentoBL As New documentoCajaRPT
        Return documentoBL.ObtenerCajaOnlineRPT(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlineAcumuladoRPT(strIdEmpresa As String, intIdEstablecimiento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineAcumuladoRPT
        Dim documentoBL As New documentoCajaRPT
        Return documentoBL.ObtenerCajaOnlineAcumuladoRPT(strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function ObtenerCajaOnlineDiaRPT(strIdEmpresa As String, intIdEstablecimiento As Integer, strEntidadFinanciera As String) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineDiaRPT
        Dim documentoBL As New documentoCajaRPT
        Return documentoBL.ObtenerCajaOnlineDiaRPT(strIdEmpresa, intIdEstablecimiento, strEntidadFinanciera)
    End Function

    Public Function ResumenTransaccionesXusuarioCajaReporte(be As cajaUsuario) As List(Of cajaUsuario) Implements ServiceContract.IContService.ResumenTransaccionesXusuarioCajaReporte
        Dim documentoBL As New cajaUsuarioRPT
        Return documentoBL.ResumenTransaccionesXusuarioCajaReporte(be)
    End Function

#End Region

#Region "APORTES"
    Public Sub DeleteAporte(documentoBE As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteAporte
        Dim aporteBL As New documentoBL
        aporteBL.DeleteAporte(documentoBE, objTotalBorrar)
    End Sub

    Public Function GetListarAportesPorPeriodo(strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarAportesPorPeriodo
        Dim aporteBL As New documentocompraBL
        Return aporteBL.GetListarAportesPorPeriodo(strPeriodo)
    End Function

    Public Function SaveAporteExistencia(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Integer Implements ServiceContract.IContService.SaveAporteExistencia
        Dim aporteBL As New documentocompraBL
        Return aporteBL.SaveAporteExistencia(objDocumento, objTotalesAlmacen)
    End Function
#End Region

#Region "USUARIOS CAJA"

    Public Sub EliminarCajaUsuarioFull(cajaUsuarioBE As Business.Entity.cajaUsuario) Implements ServiceContract.IContService.EliminarCajaUsuarioFull
        Dim cajaBL As New CajaUsuarioBL
        cajaBL.EliminarCajaUsuarioFull(cajaUsuarioBE)
    End Sub

    Public Function UbicarCajaUsuarioPorID(intIdCajaUsuario As Integer) As Business.Entity.cajaUsuario Implements ServiceContract.IContService.UbicarCajaUsuarioPorID
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.UbicarCajaUsuarioPorID(intIdCajaUsuario)
    End Function

    Public Function CerrarCajaUsuario(nCajaUsuario As Business.Entity.cajaUsuario, nDocumento As Business.Entity.documento) As cajaUsuario Implements ServiceContract.IContService.CerrarCajaUsuario
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.CerrarCajaUsuario(nCajaUsuario, nDocumento)
    End Function

    Public Sub AperturarCajaUsuario(nCajaUsuario As cajaUsuario, nDocumento As documento) Implements IContService.AperturarCajaUsuario
        Dim cajaBL As New CajaUsuarioBL
        cajaBL.AperturarCajaUsuario(nCajaUsuario, nDocumento)
    End Sub

    Public Function UbicarCajaUsuarioAbierto(intIdCajaUsuario As Integer, strEstado As String) As Business.Entity.cajaUsuario Implements ServiceContract.IContService.UbicarCajaUsuarioAbierto
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.UbicarCajaUsuarioAbierto(intIdCajaUsuario, strEstado)
    End Function

    Public Function ListaDetallePorCaja(intIdCajaUsuario As Integer) As System.Collections.Generic.List(Of Business.Entity.cajaUsuariodetalle) Implements ServiceContract.IContService.ListaDetallePorCaja
        Dim cajaBL As New cajaUsuarioDetalleBL
        Return cajaBL.ListaDetallePorCaja(intIdCajaUsuario)
    End Function

    Public Function ListaDetalleUsuarioXUsuario(be As cajaUsuario) As List(Of cajaUsuariodetalle) Implements IContService.ListaDetalleUsuarioXUsuario
        Dim cajaBL As New cajaUsuarioDetalleBL
        Return cajaBL.ListaDetalleUsuarioXUsuario(be)
    End Function

    Public Function ListaDetalleUsuarioXEntidades(be As cajaUsuario) As List(Of cajaUsuariodetalle) Implements IContService.ListaDetalleUsuarioXEntidades
        Dim cajaBL As New cajaUsuarioDetalleBL
        Return cajaBL.ListaDetalleUsuarioXEntidades(be)
    End Function

    Public Sub HabilitarUsoDeCajaUser(cajaUsuarioBE As Business.Entity.cajaUsuario) Implements ServiceContract.IContService.HabilitarUsoDeCajaUser
        Dim cajaBL As New CajaUsuarioBL
        cajaBL.HabilitarUsoDeCajaUser(cajaUsuarioBE)
    End Sub

    Public Function UbicarCajaAsignadaUser(strNumDocUser As String, strEstadoCaja As String, InUso As String, strClave As String) As Business.Entity.cajaUsuario Implements ServiceContract.IContService.UbicarCajaAsignadaUser
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.UbicarCajaAsignadaUser(strNumDocUser, strEstadoCaja, InUso, strClave)
    End Function

    Public Sub EditarUsuarioCaja(cajaUsuarioBE As Business.Entity.cajaUsuario) Implements ServiceContract.IContService.EditarUsuarioCaja
        Dim cajaBL As New CajaUsuarioBL
        cajaBL.Editar(cajaUsuarioBE)
    End Sub

    Public Sub EliminarUsuarioCaja(cajaUsuarioBE As Business.Entity.cajaUsuario) Implements ServiceContract.IContService.EliminarUsuarioCaja
        Dim cajaBL As New CajaUsuarioBL
        cajaBL.Eliminar(cajaUsuarioBE)
    End Sub

    Public Function InsertUsuarioCaja(cajaUsuarioBE As Business.Entity.cajaUsuario) As Integer Implements ServiceContract.IContService.InsertUsuarioCaja
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.Insert(cajaUsuarioBE)
    End Function

    Public Function ListarPorCaja(intIdCaja As Integer) As System.Collections.Generic.List(Of Business.Entity.cajaUsuario) Implements ServiceContract.IContService.ListarPorCaja
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.ListarPorCaja(intIdCaja)
    End Function

    Public Function ListarPorCajaPorPeriodo(intIdCaja As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.cajaUsuario) Implements ServiceContract.IContService.ListarPorCajaPorPeriodo
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.ListarPorCajaPorPeriodo(intIdCaja, strPeriodo)
    End Function

    Public Function ListaCajasHabilitadas(strIdEmpresa As String, intIdEstablecimiento As Integer) As System.Collections.Generic.List(Of Business.Entity.cajaUsuario) Implements ServiceContract.IContService.ListaCajasHabilitadas
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.ListaCajasHabilitadas(strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function UbicarCajasHijasXpadre(iNtIdPadre As Integer) As List(Of cajaUsuario) Implements IContService.UbicarCajasHijasXpadre
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.UbicarCajasHijasXpadre(iNtIdPadre)
    End Function

    Public Function UbicarCajasHijasFull(ListadoPadres As List(Of Integer)) As List(Of cajaUsuario) Implements IContService.UbicarCajasHijasFull
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.UbicarCajasHijasFull(ListadoPadres)
    End Function

    Public Sub CerrarAbrirCajaSubUsuario(nCajaUsuario As cajaUsuario) Implements IContService.CerrarAbrirCajaSubUsuario
        Dim cajaBL As New CajaUsuarioBL
        cajaBL.CerrarAbrirCajaSubUsuario(nCajaUsuario)
    End Sub

    Public Function GetListAllCompras(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra) Implements IContService.GetListAllCompras
        Dim documentoBL As New documentocompraBL
        Return documentoBL.ListarCompras(intIdEstablecimiento, strPeriodo)
    End Function

#End Region


#Region "ASIENTOS CONTABLES"
    Public Sub UpdateGroupCajaApertura(objDocumentoBE As Business.Entity.documento, objCajaUsuarioBE As Business.Entity.cajaUsuario, listaSubUsers As List(Of cajaUsuario)) Implements ServiceContract.IContService.UpdateGroupCajaApertura
        Dim cajaBL As New documentoCajaBL
        cajaBL.UpdateGroupCajaApertura(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Sub

    Public Function ValidarCajaXUsuario(intIdPersona As Integer) As cajaUsuario Implements ServiceContract.IContService.ValidarCajaXUsuario
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.ValidarCajaXUsuario(intIdPersona)
    End Function

    Function UbicarCajaXPersona(intPersona As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer Implements ServiceContract.IContService.UbicarCajaXPersona
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.UbicarCajaXPersona(intPersona, intEstablecimiento, strEmpresa)
    End Function

    Function UbicarCajaXIdEntidadOrigen(intEntidadFinanciera As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer Implements ServiceContract.IContService.UbicarCajaXIdEntidadOrigen
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.UbicarCajaXIdEntidadOrigen(intEntidadFinanciera, intEstablecimiento, strEmpresa)
    End Function

    Public Function ObtenerCajaUser(ByVal intIdCaja As Integer) As cajaUsuario Implements ServiceContract.IContService.ObtenerCajaUser
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.ObtenerCajaUser(intIdCaja)
    End Function

    Public Function UbicarAsientoPorDocumento(intIdDocumento As Integer) As System.Collections.Generic.List(Of Business.Entity.asiento) Implements ServiceContract.IContService.UbicarAsientoPorDocumento
        Dim cajaBL As New AsientoBL
        Return cajaBL.UbicarAsientoPorDocumento(intIdDocumento)
    End Function

    Public Function UbicarAsientoPorEntidad(intIdEntidad As Integer) As System.Collections.Generic.List(Of Business.Entity.asiento) Implements ServiceContract.IContService.UbicarAsientoPorEntidad
        Dim cajaBL As New AsientoBL
        Return cajaBL.UbicarAsientoPorEntidad(intIdEntidad)
    End Function

    Public Function UbicarAsientoPorTipo(srtidTipo As String) As System.Collections.Generic.List(Of Business.Entity.asiento) Implements ServiceContract.IContService.UbicarAsientoPorTipo
        Dim cajaBL As New AsientoBL
        Return cajaBL.UbicarAsientoPorTipo(srtidTipo)
    End Function

    Public Function UbicarAsientoPorFecha(srtFechaInicio As Date, srtFechaHasta As Date, srtidTipo As String) As System.Collections.Generic.List(Of Business.Entity.asiento) Implements ServiceContract.IContService.UbicarAsientoPorFecha
        Dim cajaBL As New AsientoBL
        Return cajaBL.UbicarAsientoPorFecha(srtFechaInicio, srtFechaHasta, srtidTipo)
    End Function

    Public Function UbicarAsientoPorPeriodo(srtFechaMes As Date, srtFechaAnio As Date, strAprobado As String) As System.Collections.Generic.List(Of Business.Entity.asiento) Implements ServiceContract.IContService.UbicarAsientoPorPeriodo
        Dim cajaBL As New AsientoBL
        Return cajaBL.UbicarAsientoPorPeriodo(srtFechaMes, srtFechaAnio, strAprobado)
    End Function

    Public Function UbicarMovimientoPorAsiento(intIdAsiento As Integer) As System.Collections.Generic.List(Of Business.Entity.movimiento) Implements ServiceContract.IContService.UbicarMovimientoPorAsiento
        Dim cajaBL As New movimientoBL
        Return cajaBL.UbicarMovimientoPorAsiento(intIdAsiento)
    End Function

    Public Function BuscarMovimientosFull(strPeriodo As Integer) As System.Collections.Generic.List(Of Business.Entity.movimiento) Implements ServiceContract.IContService.BuscarMovimientosFull
        Dim cajaBL As New movimientoBL
        Return cajaBL.BuscarMovimientosFull(strPeriodo)
    End Function

    Public Function BuscarMovimientosPorMes(strPeriodo As Integer, intMes As Integer) As System.Collections.Generic.List(Of Business.Entity.movimiento) Implements ServiceContract.IContService.BuscarMovimientosPorMes
        Dim cajaBL As New movimientoBL
        Return cajaBL.BuscarMovimientosPorMes(strPeriodo, intMes)
    End Function

    Public Function BuscarMovimientosPorAcumulado(strFechaDesde As Date, strFechaHasta As Date) As System.Collections.Generic.List(Of Business.Entity.movimiento) Implements ServiceContract.IContService.BuscarMovimientosPorAcumulado
        Dim cajaBL As New movimientoBL
        Return cajaBL.BuscarMovimientosPorAcumulado(strFechaDesde, strFechaHasta)
    End Function

    Public Function GetUbicarMovimiento(strCuenta As String) As List(Of movimiento) Implements ServiceContract.IContService.GetUbicarMovimiento
        Dim documentoBL As New movimientoBL
        Return documentoBL.GetUbicarMovimiento(strCuenta)
    End Function

    Public Function GetUbicarDocumentoDetallePorIdDocumento(strCuenta As String) As List(Of movimiento) Implements ServiceContract.IContService.GetUbicarDocumentoDetallePorIdDocumento
        Dim documentoBL As New movimientoBL
        Return documentoBL.GetUbicarDocumentoDetallePorIdDocumento(strCuenta)
    End Function

#End Region

#Region "PRESTAMOS"
    Public Function UbicarPrestamoXcodigoDefault(intCodigo As Integer) As prestamos Implements IContService.UbicarPrestamoXcodigoDefault
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.UbicarPrestamoXcodigoDefault(intCodigo)
    End Function

    Public Function PrestamoEstadoAprobado(intCodigo As Integer) As Boolean Implements IContService.PrestamoEstadoAprobado
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.PrestamoEstadoAprobado(intCodigo)
    End Function

    Public Function UbicarPrestamoXcodigoSingle(intIdDocumento As Integer) As prestamos Implements IContService.UbicarPrestamoXcodigoSingle
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.UbicarPrestamoXcodigoSingle(intIdDocumento)
    End Function

    Public Function ObtenerHistorialPagoPrestamoXCuota(intIdCuota As Integer) As List(Of documentoCajaDetalle) Implements IContService.ObtenerHistorialPagoPrestamoXCuota
        Dim prestamoBL As New documentoCajaDetalleBL
        Return prestamoBL.ObtenerHistorialPagoPrestamoXCuota(intIdCuota)
    End Function

    Public Function ObtenerPagosAcumPrestamos(strDocumentoAfectado As Integer, srtTipoCobro As String) As List(Of documentoCajaDetalle) Implements IContService.ObtenerPagosAcumPrestamos
        Dim prestamoBL As New documentoCajaDetalleBL
        Return prestamoBL.ObtenerPagosAcumPrestamos(strDocumentoAfectado, srtTipoCobro)
    End Function

    'Public Function ListadoPrestamosPendientes(strEmpresa As String, intIdEstablecimiento As Integer, intIdBeneficiario As Integer, strPeriodo As String, strTipoMovimiento As String) As List(Of documentoPrestamos) Implements IContService.ListadoPrestamosPendientes
    '    Dim prestamoBL As New documentoPrestamosBL
    '    Return prestamoBL.ListadoPrestamosPendientes(strEmpresa, intIdEstablecimiento, intIdBeneficiario, strPeriodo, strTipoMovimiento)
    'End Function



    Public Function UbicarPrestamoXcodigo(intCodigo As Integer) As Business.Entity.prestamos Implements ServiceContract.IContService.UbicarPrestamoXcodigo
        Dim cajaBL As New prestamosBL
        Return cajaBL.UbicarPrestamoXcodigo(intCodigo)
    End Function

    Public Function ObtenerPrestamos(strIdEmpresa As String, strEstado As String, strTipoPrestamo As String) As List(Of prestamos) Implements IContService.ObtenerPrestamos
        Dim cajaBL As New prestamosBL
        Return cajaBL.ObtenerPrestamos(strIdEmpresa, strEstado, strTipoPrestamo)
    End Function

    Public Function ObtenerPrestamosXperiodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strTipoPrestamo As String) As List(Of prestamos) Implements IContService.ObtenerPrestamosXperiodo
        Dim cajaBL As New prestamosBL
        Return cajaBL.ObtenerPrestamosXperiodo(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoPrestamo)
    End Function

    Public Sub EditarPrePrestamo(prestamosBE As prestamos) Implements IContService.EditarPrePrestamo
        Dim cajaBL As New prestamosBL
        cajaBL.UpdatePrePrestamo(prestamosBE)
    End Sub

    Public Sub EliminarPrePrestamo(prestamosBE As prestamos) Implements IContService.EliminarPrePrestamo
        Dim cajaBL As New prestamosBL
        cajaBL.ElimiarPrePrestamo(prestamosBE)
    End Sub

    Public Sub EliminarPrestamoAprobado(prestamosBE As prestamos) Implements IContService.EliminarPrestamoAprobado
        Dim cajaBL As New prestamosBL
        cajaBL.EliminarPrestamoAprobado(prestamosBE)
    End Sub

    Public Function SavePrePrestamo(prestamosBE As prestamos) As Integer Implements IContService.SavePrePrestamo
        Dim cajaBL As New prestamosBL
        Return cajaBL.Save(prestamosBE)
    End Function
#End Region

#Region "CAJA ONLINE"

    Public Function ConsultaEstadoPago(intIDDOcumentoCompra As Integer) As documentoCajaDetalle Implements IContService.ConsultaEstadoPago
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ConsultaEstadoPago(intIDDOcumentoCompra)
    End Function

    Public Function ObtenerPagosPorPeriodo(strPeriodo As String) As List(Of documentoCajaDetalle) Implements IContService.ObtenerPagosPorPeriodo
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerPagosPorPeriodo(strPeriodo)
    End Function

    Public Function ObtenerPagosPorPeriodoporEstablecimiento(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCajaDetalle) Implements IContService.ObtenerPagosPorPeriodoporEstablecimiento
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerPagosPorPeriodoporEstablecimiento(intIdEstablecimiento, strPeriodo)
    End Function

#Region "OTROS MOVIMIENTOS DE CAJA"
    Public Function ObtenerMovimientosPorPeriodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerMovimientosPorPeriodo
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ObtenerMovimientosPorPeriodo(strIdEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function ObtenerMovimientosPorDia(strIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoCaja) Implements IContService.ObtenerMovimientosPorDia
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ObtenerMovimientosPorDia(strIdEmpresa, intIdEstablecimiento)
    End Function

#End Region
    Public Sub EliminarTransferenciaCaja(documentoBE As Business.Entity.documento) Implements ServiceContract.IContService.EliminarTransferenciaCaja
        Dim cajaBL As New documentoBL
        cajaBL.EliminarTransferenciaCaja(documentoBE)
    End Sub

    Public Sub EliminarOtrosMovimientosCaja(documentoBE As Business.Entity.documento) Implements ServiceContract.IContService.EliminarOtrosMovimientosCaja
        Dim cajaBL As New documentoBL
        cajaBL.EliminarOtrosMovimientosCaja(documentoBE)
    End Sub

    Public Function UbicarUltimaFechaPago(intIdDocumento As Integer) As Date Implements ServiceContract.IContService.UbicarUltimaFechaPago
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.UbicarUltimaFechaPago(intIdDocumento)
    End Function

    Public Sub EditarGroupCaja(objDocumentoBE As Business.Entity.documento) Implements ServiceContract.IContService.EditarGroupCaja
        Dim cajaBL As New documentoCajaBL
        cajaBL.EditarGroupCaja(objDocumentoBE)
    End Sub

    Public Sub EliminarDocumentoCaja(documentoBE As Business.Entity.documento) Implements ServiceContract.IContService.EliminarDocumentoCaja
        Dim cajaBL As New documentoBL
        cajaBL.deleteSingleCaja(documentoBE)
    End Sub

    Public Sub EliminarPagoPrestamo(documentoBE As documento) Implements IContService.EliminarPagoPrestamo
        Dim cajaBL As New documentoBL
        cajaBL.EliminarPagoPrestamo(documentoBE)
    End Sub

    Public Function ObtenerCajaDetalleME(ByVal montoUSD As Decimal, intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle) Implements IContService.ObtenerCajaDetalleME
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCajaDetalleME(montoUSD, intEntidadFinanciera)
    End Function

    Public Function ObtenerCajaDetalle(ByVal montoUSD As Decimal, intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle) Implements IContService.ObtenerCajaDetalle
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCajaDetalle(montoUSD, intEntidadFinanciera)
    End Function


    Public Function ObtenerHistorialPagos(intIdDocumentoCompra As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoCajaDetalle) Implements ServiceContract.IContService.ObtenerHistorialPagos
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerHistorialPagos(intIdDocumentoCompra)
    End Function

    Public Function ObtenerHistorialPagosPorIdPago(intIdDocumentoPago As Integer) As documentoCajaDetalle Implements IContService.ObtenerHistorialPagosPorIdPago
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerHistorialPagosPorIdPago(intIdDocumentoPago)
    End Function

    Public Function ObtenerPagosDelDia() As System.Collections.Generic.List(Of Business.Entity.documentoCajaDetalle) Implements ServiceContract.IContService.ObtenerPagosDelDia
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerPagosDelDia()
    End Function

    Public Function ObtenerPagosDelDiaPorEstablecimiento(intIdEstablecimiento As Integer) As List(Of documentoCajaDetalle) Implements IContService.ObtenerPagosDelDiaPorEstablecimiento
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerPagosDelDiaPorEstablecimiento(intIdEstablecimiento)
    End Function

    Public Function SumaCobroPorCliente(intIdEstable As Integer, strFiltro As String, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoCajaDetalle) Implements ServiceContract.IContService.SumaCobroPorCliente
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.SumaCobroPorCliente(intIdEstable, strFiltro, strPeriodo)
    End Function

    Public Function SumaCobroPorModulo(intIdEstable As Integer, strFiltro As String, strPeriodo As String, strTipoModuloVenta As String) As System.Collections.Generic.List(Of Business.Entity.documentoCajaDetalle) Implements ServiceContract.IContService.SumaCobroPorModulo
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.SumaCobroPorModulo(intIdEstable, strFiltro, strPeriodo, strTipoModuloVenta)
    End Function

    Public Function SumaPagosPorProveedor(intIdEstable As Integer, strFiltro As String, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoCajaDetalle) Implements ServiceContract.IContService.SumaPagosPorProveedor
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.SumaPagosPorProveedor(intIdEstable, strFiltro, strPeriodo)
    End Function

    Public Function SumaPagosPorIdDocumentoCompra(intIdDocumento As Integer) As Business.Entity.documentoCajaDetalle Implements ServiceContract.IContService.SumaPagosPorIdDocumentoCompra
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.SumaPagosPorIdDocumentoCompra(intIdDocumento)
    End Function

    Public Function GetUbicar_DetallePorIdDocumento(intIdDocumento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoCajaDetalle) Implements ServiceContract.IContService.GetUbicar_DetallePorIdDocumento
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.GetUbicar_DetallePorIdDocumento(intIdDocumento)
    End Function

    Public Function GetUbicar_DetalleXdocumentoAfectado(docAfectado As Integer) As List(Of documentoCajaDetalle) Implements IContService.GetUbicar_DetalleXdocumentoAfectado
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.GetUbicar_DetalleXdocumentoAfectado(docAfectado)
    End Function

    Public Function SumaCobroPorDocumento(intIdEstable As Integer, strTipoDoc As String,
                                          strFiltro As String) As Business.Entity.documentoCajaDetalle Implements ServiceContract.IContService.SumaCobroPorDocumento
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.SumaCobroPorDocumento(intIdEstable, strTipoDoc, strFiltro)
    End Function

    Public Function SumaCobroPorDocumentoPagos(intIdEstable As Integer, strTipoDoc As String, strFiltro As String, strSerie As String) As Business.Entity.documentoCajaDetalle Implements ServiceContract.IContService.SumaCobroPorDocumentoPagos
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.SumaCobroPorDocumentoPagos(intIdEstable, strTipoDoc, strFiltro, strSerie)
    End Function

    Public Function SaveGroupCajaNotas(objDocumentoBE As documento) As Integer Implements IContService.SaveGroupCajaNotas
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaNotas(objDocumentoBE)
    End Function

    Public Function SaveGroupCajaVentas(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer Implements IContService.SaveGroupCajaVentas
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaVentas(objDocumentoBE, cajaUsuario)
    End Function

    Public Function GrabarExcedenteCompra(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer Implements IContService.GrabarExcedenteCompra
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GrabarExcedenteCompra(objDocumentoBE, cajaUsuario)
    End Function

    Public Function GrabarExcedenteVenta(objDocumentoBE As documento) As Integer Implements IContService.GrabarExcedenteVenta
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GrabarExcedenteVenta(objDocumentoBE)
    End Function

    Public Function SaveGroupCaja(objDocumentoBE As Business.Entity.documento, cajaUsuario As Business.Entity.cajaUsuario) As Integer Implements ServiceContract.IContService.SaveGroupCaja
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCaja(objDocumentoBE, cajaUsuario)
    End Function

    Public Function SaveGroupCajaPrestamo(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer Implements IContService.SaveGroupCajaPrestamo
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SavePrestamoGroup(objDocumentoBE, cajaUsuario)
    End Function

    Public Function SaveGroupCajaNotacredito(objDocumentoBE As Business.Entity.documento, cajaUsuario As Business.Entity.cajaUsuario) As Integer Implements ServiceContract.IContService.SaveGroupCajaNotacredito
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaNotacredito(objDocumentoBE, cajaUsuario)
    End Function

    Public Function SaveGroupCajaApertura(objDocumentoBE As Business.Entity.documento, objCajaUsuarioBE As Business.Entity.cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer Implements ServiceContract.IContService.SaveGroupCajaApertura
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaApertura(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Function

    Public Sub SaveGroupCajaOtrosMovimientos(objDocumentoBE As Business.Entity.documento) Implements ServiceContract.IContService.SaveGroupCajaOtrosMovimientos
        Dim cajaBL As New documentoCajaBL
        cajaBL.SaveGroupCajaOtrosMovimientos(objDocumentoBE)
    End Sub

    Public Function SaveGroupCajaOtrosMovimientosSingle(objDocumentoBE As Business.Entity.documento) As Integer Implements ServiceContract.IContService.SaveGroupCajaOtrosMovimientosSingle
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaOtrosMovimientosSingle(objDocumentoBE)
    End Function

    Public Sub UpdateGroupCajaOtrosMovimientosSingle(objDocumentoBE As Business.Entity.documento) Implements ServiceContract.IContService.UpdateGroupCajaOtrosMovimientosSingle
        Dim cajaBL As New documentoCajaBL
        cajaBL.UpdateGroupCajaOtrosMovimientosSingle(objDocumentoBE)
    End Sub

    Public Sub SaveCajaExcedente(objDocumentoBE As Business.Entity.documento) Implements ServiceContract.IContService.SaveCajaExcedente
        Dim cajaBL As New documentoCajaBL
        cajaBL.SaveCajaExcedente(objDocumentoBE)
    End Sub

    Public Function ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoCajaDetalle) Implements ServiceContract.IContService.ObtenerCuentasPorCobrarPorDetails
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado)
    End Function

    Public Function ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoCajaDetalle) Implements ServiceContract.IContService.ObtenerCuentasPorPagarPorDetails
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado)
    End Function

    Public Function ObtenerCuentasPorPagarPorDetailsME(strDocumentoAfectado As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoCajaDetalle) Implements ServiceContract.IContService.ObtenerCuentasPorPagarPorDetailsME
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCuentasPorPagarPorDetailsME(strDocumentoAfectado)
    End Function

    Public Function ObtenerCuentasPorPagarPorDetailsVentas(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle) Implements IContService.ObtenerCuentasPorPagarPorDetailsVentas
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCuentasPorPagarPorDetailsVentas(strDocumentoAfectado)
    End Function
#End Region

#Region "NUMERACION BOLETA"

    Public Function ObtenerDocumentoPorEstablecimiento(intIdEstablecimiento As Integer, strSerie As String, strcodigoNumeracion As String, strTipo As String) As Business.Entity.numeracionBoletas Implements ServiceContract.IContService.ObtenerDocumentoPorEstablecimiento
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.ObtenerDocumentoPorEstablecimiento(intIdEstablecimiento, strSerie, strcodigoNumeracion, strTipo)
    End Function

    Public Function ObtenerAncladosPorComprobante(strIdEmpresa As String, intIdEstablecimiento As Integer, strComprobante As String) As System.Collections.Generic.List(Of Business.Entity.numeracionBoletas) Implements ServiceContract.IContService.ObtenerAncladosPorComprobante
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.ObtenerAncladosPorComprobante(strIdEmpresa, intIdEstablecimiento, strComprobante)
    End Function

    Public Function GetUbicar_numeracionBoletasPorID(IdEnumeracion As Integer) As Business.Entity.numeracionBoletas Implements ServiceContract.IContService.GetUbicar_numeracionBoletasPorID
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.GetUbicar_numeracionBoletasPorID(IdEnumeracion)
    End Function

    Public Function GetUbicar_numeracionBoletasXUnidadNegocio(numeracionBoletasBE As numeracionBoletas) As numeracionBoletas Implements ServiceContract.IContService.GetUbicar_numeracionBoletasXUnidadNegocio
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.GetUbicar_numeracionBoletasXUnidadNegocio(numeracionBoletasBE)
    End Function

    Public Function NumeracionBoletasSelV2(intIdEstablecimiento As Integer,
                                         strcodigoNumeracion As String, strTipo As String, idCargo As Integer) As numeracionBoletas Implements ServiceContract.IContService.NumeracionBoletasSelV2
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.NumeracionBoletasSelV2(intIdEstablecimiento, strcodigoNumeracion, strTipo, idCargo)
    End Function

    'Public Function ObtenerNumeracionPredterminada(strIdEmpresa As String, intIdEstablecimiento As Integer, strComprobante As String, strTipoDoc As String) As Business.Entity.numeracionBoletas Implements ServiceContract.IContService.ObtenerNumeracionPredterminada
    '    Dim numeracionBL As New numeracionBoletasBL
    '    Return numeracionBL.ObtenerNumeracionPredterminada(strIdEmpresa, intIdEstablecimiento, strComprobante, strTipoDoc)
    'End Function

    Public Function ObtenerNumeracionPredterminada(strIdEmpresa As String, intIdEstablecimiento As Integer, strTipoDoc As String) As Business.Entity.numeracionBoletas Implements ServiceContract.IContService.ObtenerNumeracionPredterminada
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.ObtenerNumeracionPredterminada(strIdEmpresa, intIdEstablecimiento, strTipoDoc)
    End Function

#Region "EMPRESA SERIE"
    Public Function obtenerSeriePorEEmpresa(strIdEmpresa As String, intIdEstablecimiento As Integer) As System.Collections.Generic.List(Of Business.Entity.EmpresaSeries) Implements ServiceContract.IContService.obtenerSeriePorEEmpresa
        Dim serieBL As New EmpresaSeriesBL
        Return serieBL.obtenerSeriePorEEmpresa(strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Sub DeleteEmpresaSerie(EmpresaSeriesBE As Business.Entity.EmpresaSeries) Implements ServiceContract.IContService.DeleteEmpresaSerie
        Dim serieBL As New EmpresaSeriesBL
        serieBL.Delete(EmpresaSeriesBE)
    End Sub

    Public Sub EditarEmpresaSerie(EmpresaSeriesBE As Business.Entity.EmpresaSeries) Implements ServiceContract.IContService.EditarEmpresaSerie
        Dim serieBL As New EmpresaSeriesBL
        serieBL.Update(EmpresaSeriesBE)
    End Sub

    Public Sub InsertEmpresaSerie(EmpresaSeriesBE As Business.Entity.EmpresaSeries) Implements ServiceContract.IContService.InsertEmpresaSerie
        Dim serieBL As New EmpresaSeriesBL
        serieBL.Insert(EmpresaSeriesBE)
    End Sub
#End Region

    Public Function ObtenerNumeracionEES(strIdEmpresa As String, intIdEstablecimiento As Integer, strSerie As String) As System.Collections.Generic.List(Of Business.Entity.numeracionBoletas) Implements ServiceContract.IContService.ObtenerNumeracionEES
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.ObtenerNumeracionEES(strIdEmpresa, intIdEstablecimiento, strSerie)
    End Function

    Public Sub EditarNumBoletas(numeracionBoletasBE As Business.Entity.numeracionBoletas) Implements ServiceContract.IContService.EditarNumBoletas
        Dim numeracionBL As New numeracionBoletasBL
        numeracionBL.Update(numeracionBoletasBE)
    End Sub

    Public Sub EliminarNumBoletas(numeracionBoletasBE As Business.Entity.numeracionBoletas) Implements ServiceContract.IContService.EliminarNumBoletas
        Dim numeracionBL As New numeracionBoletasBL
        numeracionBL.Delete(numeracionBoletasBE)
    End Sub

    Public Function ObtenerSeriesPorModulo(intIdEstablecimiento As Integer, strModulo As String) As System.Collections.Generic.List(Of Business.Entity.numeracionBoletas) Implements ServiceContract.IContService.ObtenerSeriesPorModulo
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.ObtenerSeriesPorModulo(intIdEstablecimiento, strModulo)
    End Function

    Public Function InsertNumBoletas(numeracionBoletasBE As Business.Entity.numeracionBoletas) As Integer Implements ServiceContract.IContService.InsertNumBoletas
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.Insert(numeracionBoletasBE)
    End Function

    Public Function InsertNumeracionXAreaOperativa(ByVal numeracionBoletasBE As distribucionNumeracionAO) As Integer Implements ServiceContract.IContService.InsertNumeracionXAreaOperativa
        Dim numeracionBL As New distribucionNumeracionAOBL
        Return numeracionBL.InsertNumeracionXAreaOperativa(numeracionBoletasBE)
    End Function

    Public Function InsertAreaOperativaNumeracion(ByVal numeracionBoletasBE As distribucionNumeracionAO) As Integer Implements ServiceContract.IContService.InsertAreaOperativaNumeracion
        Dim numeracionBL As New distribucionNumeracionAOBL
        Return numeracionBL.InsertAreaOperativaNumeracion(numeracionBoletasBE)
    End Function

    Public Function InsertListaNumeracionAo(conItem As List(Of distribucionNumeracionAO)) As Integer Implements ServiceContract.IContService.InsertListaNumeracionAo
        Dim numeracionBL As New distribucionNumeracionAOBL
        Return numeracionBL.InsertListaNumeracionAo(conItem)
    End Function

    Public Sub UpdatePredeterminadoAll(nNumeracionBE As Business.Entity.numeracionBoletas) Implements ServiceContract.IContService.UpdatePredeterminadoAll
        Dim numeracionBL As New numeracionBoletasBL
        numeracionBL.UpdatePredeterminadoAll(nNumeracionBE)
    End Sub

    Public Function GetTieneConfiguracion(strIdEmpresa As String, intIdEstablecimiento As Integer, strSerie As String) As Boolean Implements ServiceContract.IContService.GetTieneConfiguracion
        Dim numeracionBL As New numeracionBoletasBL
        Return numeracionBL.GetTieneConfiguracion(strIdEmpresa, intIdEstablecimiento, strSerie)
    End Function
#End Region

#Region "ESTADOS FINANCIEROS"

    Public Function ObtenerEFPorCuentaFinanciera(estadosFinancierosBE As estadosFinancieros) As List(Of estadosFinancieros) Implements IContService.ObtenerEFPorCuentaFinanciera
        Dim efBL As New estadosFinancierosBL
        Return efBL.ObtenerEFPorCuentaFinanciera(estadosFinancierosBE)
    End Function


    Public Function ObtenerEstadosFinancierosPorTipo(intIdEstablecimiento As Integer, strTipo As String) As System.Collections.Generic.List(Of Business.Entity.estadosFinancieros) Implements ServiceContract.IContService.ObtenerEstadosFinancierosPorTipo
        Dim efBL As New estadosFinancierosBL
        Return efBL.ObtenerEstadosFinancierosPorTipo(intIdEstablecimiento, strTipo)
    End Function

    Public Sub DeleteEF(estadosFinancierosBE As Business.Entity.estadosFinancieros) Implements ServiceContract.IContService.DeleteEF
        Dim efBL As New estadosFinancierosBL
        efBL.Delete(estadosFinancierosBE)
    End Sub

    Public Function InsertEF(estadosFinancierosBE As Business.Entity.estadosFinancieros) As Integer Implements ServiceContract.IContService.InsertEF
        Dim efBL As New estadosFinancierosBL
        Return efBL.Insert(estadosFinancierosBE)
    End Function

    Public Function GrabarEFApertura(estadosFinancierosBE As estadosFinancieros, docume As documento) As Integer Implements IContService.GrabarEFApertura
        Dim efBL As New estadosFinancierosBL
        Return efBL.GrabarEFApertura(estadosFinancierosBE, docume)
    End Function

    Public Function InsertEFDoc(estadosFinancierosBE As estadosFinancieros, docume As documento) As Integer Implements IContService.InsertEFDoc
        Dim efBL As New estadosFinancierosBL
        Return efBL.InsertEFDoc(estadosFinancierosBE, docume)
    End Function

    Public Sub UpdateEF(estadosFinancierosBE As Business.Entity.estadosFinancieros) Implements ServiceContract.IContService.UpdateEF
        Dim efBL As New estadosFinancierosBL
        efBL.Update(estadosFinancierosBE)
    End Sub

    Public Sub UpdateEFDoc(estadosFinancierosBE As estadosFinancieros, Optional docume As documento = Nothing) Implements IContService.UpdateEFDoc
        Dim efBL As New estadosFinancierosBL
        efBL.UpdateEFDoc(estadosFinancierosBE, docume)
    End Sub

    Public Sub DeleteEntidadFinancieraReferencia(ByVal estadosFinancierosBE As estadosFinancieros) Implements IContService.DeleteEntidadFinancieraReferencia
        Dim efBL As New estadosFinancierosBL
        efBL.DeleteEntidadFinancieraReferencia(estadosFinancierosBE)
    End Sub


    Public Function ObtenerEstadosFinancierosPredeterminado(intIdEstablecimiento As Integer) As Business.Entity.estadosFinancieros Implements ServiceContract.IContService.ObtenerEstadosFinancierosPredeterminado
        Dim efBL As New estadosFinancierosBL
        Return efBL.ObtenerEstadosFinancierosPredeterminado(intIdEstablecimiento)
    End Function

    Public Function ObtenerEstadosFinancierosPorMoneda(intIdEstablecimiento As Integer, strTipo As String, strMoneda As String) As System.Collections.Generic.List(Of Business.Entity.estadosFinancieros) Implements ServiceContract.IContService.ObtenerEstadosFinancierosPorMoneda
        Dim efBL As New estadosFinancierosBL
        Return efBL.ObtenerEstadosFinancierosPorMoneda(intIdEstablecimiento, strTipo, strMoneda)
    End Function

    Public Function GetUbicar_estadosFinancierosPorID(idestado As Integer) As Business.Entity.estadosFinancieros Implements ServiceContract.IContService.GetUbicar_estadosFinancierosPorID
        Dim efBL As New estadosFinancierosBL
        Return efBL.GetUbicar_estadosFinancierosPorID(idestado)
    End Function

    Public Function ObtenerEstadosFinancierosPorCodigo(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strCodigo As Integer) As estadosFinancieros Implements ServiceContract.IContService.ObtenerEstadosFinancierosPorCodigo
        Dim efBL As New estadosFinancierosBL
        Return efBL.ObtenerEstadosFinancierosPorCodigo(strIdEmpresa, intIdEstablecimiento, strCodigo)
    End Function

    Public Function GetEstadoSaldoEFME(idestado As Integer, fechaProceso As DateTime) As estadosFinancieros Implements IContService.GetEstadoSaldoEFME
        Dim entidadBL As New estadosFinancierosBL
        Return entidadBL.GetEstadoSaldoEFME(idestado, fechaProceso)
    End Function

    Public Function ObtenerEFPorCuentaFinancieraDestino(intIdEstablecimiento As Integer, strTipo As String, cuentaOrigen As Integer, tipoMo As Integer) As List(Of estadosFinancieros) Implements IContService.ObtenerEFPorCuentaFinancieraDestino
        Dim efBL As New estadosFinancierosBL
        Return efBL.ObtenerEFPorCuentaFinancieraDestino(intIdEstablecimiento, strTipo, cuentaOrigen, tipoMo)
    End Function

    Public Function GetEstadoCajasInformacionGeneral(be As documentoCaja, listaPersona As List(Of String), tipo As String, fechaIncio As DateTime, fechaFin As DateTime, intAnio As Integer, intMes As Integer, strEmpresa As String, idEstablec As Integer, intDia As Integer) As List(Of estadosFinancieros) Implements IContService.GetEstadoCajasInformacionGeneral
        Dim cajaBL As New estadosFinancierosBL
        Return cajaBL.GetEstadoCajasInformacionGeneral(be, listaPersona, tipo, fechaIncio, fechaFin, intAnio, intMes, strEmpresa, idEstablec, intDia)
    End Function

#Region "DOCUMENTO CAJA"
    Public Function VerificarConciliarCheque(objDocCaja As documentoCaja) As Boolean Implements IContService.VerificarConciliarCheque
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.VerificarConciliarCheque(objDocCaja)
    End Function

    Public Sub ConciliarCheque(objDocCaja As documentoCaja, objDocumentoBE As documento, cajaUsuario As cajaUsuario) Implements IContService.ConciliarCheque
        Dim documentoBL As New documentoCajaBL
        documentoBL.ConciliarCheque(objDocCaja, objDocumentoBE, cajaUsuario)
    End Sub

    Public Function ListaChequesPorProveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String) As List(Of documentoCaja) Implements IContService.ListaChequesPorProveedor
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ListaChequesPorProveedor(intIdEstablecimiento, intIdProveedor, strPeriodo)
    End Function

    Public Sub EditarEstadoCompra(intIdDocumento As Integer, strEstadoPago As String) Implements IContService.EditarEstadoCompra
        Dim documentoBL As New documentocompraBL
        documentoBL.EditarEstadoCompra(intIdDocumento, strEstadoPago)
    End Sub

    Public Function ListaComprasPendientesXproveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer) As Integer Implements IContService.ListaComprasPendientesXproveedor
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ListaComprasPendientesXproveedor(intIdEstablecimiento, intIdProveedor)
    End Function

    Public Function ListaChequesPendientesXProveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String) As Integer Implements IContService.ListaChequesPendientesXProveedor
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ListaChequesPendientesXProveedor(intIdEstablecimiento, intIdProveedor, strPeriodo)
    End Function

    Public Function GetListarComprasPorProveedorCaja(intIdEstable As Integer, intIdProveedor As Integer, strPeriodo As String) As List(Of documentocompra) Implements IContService.GetListarComprasPorProveedorCaja
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorProveedorCaja(intIdEstable, intIdProveedor, strPeriodo)
    End Function

    Public Function GetListarComprasNotaCreditoPorProveedorCaja(intIdEstable As Integer, intIdProveedor As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasNotaCreditoPorProveedorCaja
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasNotaCreditoPorProveedorCaja(intIdEstable, intIdProveedor, strPeriodo)
    End Function

    Public Function ObtenerCajasMovimientosPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCaja) Implements IContService.ObtenerCajasMovimientosPorPeriodo
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajasMovimientosPorPeriodo(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetUbicar_documentoCajaPorID(idDocumento As Integer) As Business.Entity.documentoCaja Implements ServiceContract.IContService.GetUbicar_documentoCajaPorID
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.GetUbicar_documentoCajaPorID(idDocumento)
    End Function

    Public Function RecuperarIDCompra(intIdDocumentoCompra As Integer) As Integer Implements ServiceContract.IContService.RecuperarIDCompra
        Dim documentocajadetalleBL As New documentoCajaDetalleBL
        Return documentocajadetalleBL.RecuperarIDCompra(intIdDocumentoCompra)
    End Function

    Public Function ObtenerCajaOnline(strIdEmpresa As String, intIdEstablecimiento As Integer, strMEs As String, strAnio As String, strEntidadFinanciera As String) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnline
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnline(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlineConTramiteDoc(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineConTramiteDoc
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineConTramiteDoc(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, listaEstado)
    End Function

    Public Function ObtenerCajaOnlineXDocumento(strIdEmpresa As String, intIdEstablecimiento As Integer, strMEs As String, strAnio As String, strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineXDocumento
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineXDocumento(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, listaEstado)
    End Function

    Public Function ObtenerCajaOnlineXDocumentoConTramiteDoc(strIdEmpresa As String, intIdEstablecimiento As Integer, strMEs As String, strAnio As String, strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineXDocumentoConTramiteDoc
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineXDocumentoConTramiteDoc(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, listaEstado)
    End Function

    Public Function ObtenerCajaOnlineXDocumentoXId(strIdEmpresa As String, intIdEstablecimiento As Integer, strMEs As String, strAnio As String, strEntidadFinanciera As String, idCaja As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineXDocumentoXId
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineXDocumentoXId(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, idCaja)
    End Function

    Public Function ObtenerCajaOnlineXIdCaja(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strperiodo As String, ByVal strEntidadFinanciera As String, idCaja As Integer) As List(Of documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineXIdCaja
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineXIdCaja(strIdEmpresa, intIdEstablecimiento, strperiodo, strEntidadFinanciera, idCaja)
    End Function

#End Region
#End Region

#Region "ALMACEN"

    Public Function GetUbicar_proveedorPorIdItem(stridEmpresa As String, intIdEstablec As Integer, intIdItem As Integer) As List(Of documentocompradetalle) Implements IContService.GetUbicar_proveedorPorIdItem
        Dim almacenBL As New documentocompradetalleBL
        Return almacenBL.GetUbicar_proveedorPorIdItem(stridEmpresa, intIdEstablec, intIdItem)
    End Function

    Public Function GetUbicar_OrdenCompraHistorial(idDocumento As Integer, situacion As String) As List(Of documentocompradetalle) Implements IContService.GetUbicar_OrdenCompraHistorial
        Dim DocumentoCompraDetalleBL As New documentocompradetalleBL
        Return DocumentoCompraDetalleBL.GetUbicar_OrdenCompraHistorial(idDocumento, situacion)
    End Function

    Public Sub UpdateFullDocOrden(ByVal idDocumento As Integer, ByVal strSituacion As String) Implements IContService.UpdateFullDocOrden
        Dim DocumentoCompraDetalleBL As New documentocompradetalleBL
        DocumentoCompraDetalleBL.UpdateFullDocOrden(idDocumento, strSituacion)
    End Sub

#Region "NUMETO METODO DE PRECIOS"

    Public Function ListarPreciosXproductoMaxFecha(intIdAlmacen As Integer, intIdItem As Integer) As List(Of configuracionPrecioProducto) Implements IContService.ListarPreciosXproductoMaxFecha
        Dim almacenBL As New ConfiguracionPrecioProductoBL
        Return almacenBL.ListarPreciosXproductoMaxFecha(intIdAlmacen, intIdItem)
    End Function

    Public Sub GrabarListadoPrecios(listaProductos As List(Of configuracionPrecioProducto)) Implements IContService.GrabarListadoPrecios
        Dim almacenBL As New ConfiguracionPrecioProductoBL
        almacenBL.GrabarListadoPrecios(listaProductos)
    End Sub

    Public Sub GrabarPrecio(Producto As List(Of configuracionPrecioProducto)) Implements IContService.GrabarPrecio
        Dim almacenBL As New ConfiguracionPrecioProductoBL
        almacenBL.GrabarPrecio(Producto)
    End Sub

    Public Function ListadoPrecios() As List(Of configuracionPrecio) Implements IContService.ListadoPrecios
        Dim almacenBL As New ConfiguracionPrecioBL
        Return almacenBL.ListadoPrecios()
    End Function

    Public Function EncontrarPrecioXitem(configBE As configuracionPrecio) As configuracionPrecio Implements IContService.EncontrarPrecioXitem
        Dim almacenBL As New ConfiguracionPrecioBL
        Return almacenBL.EncontrarPrecioXitem(configBE)
    End Function
#End Region

#Region "LISTADO DE PRECIOS"
    Public Function UbicarPVxItem(intIdAlmacen As Integer, intIdItem As Integer) As listadoPrecios Implements IContService.UbicarPVxItem
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.UbicarPVxItem(intIdAlmacen, intIdItem)
    End Function

    Public Function UbicarPVxListadoItems(intIdAlmacen As Integer) As List(Of listadoPrecios) Implements IContService.UbicarPVxListadoItems
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.UbicarPVxListadoItems(intIdAlmacen)
    End Function

    Public Function InsertarPrecioVV(listadoPreciosBE As listadoPrecios) As Integer Implements IContService.InsertarPrecioVV
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.InsertarPrecioVV(listadoPreciosBE)
    End Function

    Public Function PrecioVentaXitemXiva(intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As listadoPrecios Implements IContService.PrecioVentaXitemXiva
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.UbicarVentaPorItemXiva(intIdAlmacen, intIdItem, strIVA)
    End Function

    Public Function UltimasEntradasPorFecha(strEmpresa As String, intIdEstablecimiento As Integer, intAlnacenConsulta As Integer, IntIdItem As String) As List(Of documentocompradetalle) Implements IContService.UltimasEntradasPorFecha
        Dim almacenBL As New documentocompradetalleBL
        Return almacenBL.UltimasEntradasPorFecha(strEmpresa, intIdEstablecimiento, intAlnacenConsulta, IntIdItem)
    End Function

    Public Function UbicarVentaPorItem(intIdAlmacen As Integer, intIdItem As Integer) As Business.Entity.listadoPrecios Implements ServiceContract.IContService.UbicarVentaPorItem
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.UbicarVentaPorItem(intIdAlmacen, intIdItem)
    End Function

    Public Function UbicarVentaPorItemCSIVA(intIdAlmacen As Integer, intIdItem As Integer) As List(Of Business.Entity.listadoPrecios) Implements ServiceContract.IContService.UbicarVentaPorItemCSIVA
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.UbicarVentaPorItemCSIVA(intIdAlmacen, intIdItem)
    End Function

    Public Function UbicarVentaPorItemCSIVASL(intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As Business.Entity.listadoPrecios Implements ServiceContract.IContService.UbicarVentaPorItemCSIVASL
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.UbicarVentaPorItemCSIVASL(intIdAlmacen, intIdItem, strIVA)
    End Function

    Public Function UbicarPrecioNuevo(intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As Decimal Implements ServiceContract.IContService.UbicarPrecioNuevo
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.UbicarPrecioNuevo(intIdAlmacen, intIdItem, strIVA)
    End Function

    Public Sub EditarListadoPrecio(listadoPreciosBE As Business.Entity.listadoPrecios) Implements ServiceContract.IContService.EditarListadoPrecio
        Dim almacenBL As New listadoPreciosBL
        almacenBL.Update(listadoPreciosBE)
    End Sub

    Public Sub EliminarListadoPrecio(listadoPreciosBE As Business.Entity.listadoPrecios) Implements ServiceContract.IContService.EliminarListadoPrecio
        Dim almacenBL As New listadoPreciosBL
        almacenBL.Delete(listadoPreciosBE)
    End Sub

    Public Sub InsertListadoPrecio(listadoPreciosBE As Business.Entity.listadoPrecios) Implements ServiceContract.IContService.InsertListadoPrecio
        Dim almacenBL As New listadoPreciosBL
        almacenBL.Insert(listadoPreciosBE)
    End Sub

    Public Sub InsertListadoPrecioSL(listadoPreciosBE As List(Of Business.Entity.listadoPrecios)) Implements ServiceContract.IContService.InsertListadoPrecioSL
        Dim almacenBL As New listadoPreciosBL
        almacenBL.InsertSL(listadoPreciosBE)
    End Sub

    Public Function ObtenerPrecioPorItem(intIdAlmacen As Integer, intIdItem As Integer) As System.Collections.Generic.List(Of Business.Entity.listadoPrecios) Implements ServiceContract.IContService.ObtenerPrecioPorItem
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.ObtenerPrecioPorItem(intIdAlmacen, intIdItem)
    End Function

    Public Function ObtenerPrecioPorItemSL(intIdAlmacen As Integer, intIdItem As Integer, strTipoIVA As String) As System.Collections.Generic.List(Of Business.Entity.listadoPrecios) Implements ServiceContract.IContService.ObtenerPrecioPorItemSL
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.ObtenerPrecioPorItemSL(intIdAlmacen, intIdItem, strTipoIVA)
    End Function

    Public Function ObtenerPrecioPorIdAlmacen(intIdAlmacen As Integer) As List(Of listadoPrecios) Implements IContService.ObtenerPrecioPorIdAlmacen
        Dim almacenBL As New listadoPreciosBL
        Return almacenBL.ObtenerPrecioPorIdAlmacen(intIdAlmacen)
    End Function
#End Region

    Public Function ObtenerCanastaDeVentaPorProducto(intIdAlmacen As Integer, strTipoExistencia As String, strFiltroProducto As String) As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen) Implements ServiceContract.IContService.ObtenerCanastaDeVentaPorProducto
        Dim totalesBL As New totalesAlmacenBL
        Return totalesBL.ObtenerCanastaDeVentaPorProducto2(intIdAlmacen, strTipoExistencia, strFiltroProducto)
    End Function

    Public Function ObtenerCanastaDeVenta(intIdAlmacen As Integer, strTipoExistencia As String) As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen) Implements ServiceContract.IContService.ObtenerCanastaDeVenta
        Dim totalesBL As New totalesAlmacenBL
        Return totalesBL.ObtenerCanastaDeVenta(intIdAlmacen, strTipoExistencia)
    End Function

    Public Function GetUbicar_almacenPredeterminado(intIdEstablecimiento As Integer) As Business.Entity.almacen Implements ServiceContract.IContService.GetUbicar_almacenPredeterminado
        Dim almacenBL As New almacenBL
        Return almacenBL.GetUbicar_almacenPredeterminado(intIdEstablecimiento)
    End Function

    Public Function GetMovimientosKardexByMesAllAlmacenXusuario(be As InventarioMovimiento, listaUsuario As List(Of String), tipo As String, periodo As String, fechainicio As DateTime, fechaFin As DateTime) As List(Of InventarioMovimiento) Implements IContService.GetMovimientosKardexByMesAllAlmacenXusuario
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetMovimientosKardexByMesAllAlmacenXusuario(be, listaUsuario, tipo, periodo, fechainicio, fechaFin)
    End Function

    Public Function GetMovimientosKardexByMesXusuario(be As InventarioMovimiento, listaUsuario As List(Of String), tipo As String, periodo As String, fechainicio As DateTime, fechaFin As DateTime) As List(Of InventarioMovimiento) Implements IContService.GetMovimientosKardexByMesXusuario
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetMovimientosKardexByMesXusuario(be, listaUsuario, tipo, periodo, fechainicio, fechaFin)
    End Function

    Public Function GetUbicar_InventarioMovimientoCompra(idDocumento As Integer, strTipoRegistro As String) As Business.Entity.InventarioMovimiento Implements ServiceContract.IContService.GetUbicar_InventarioMovimientoCompra
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.GetUbicar_InventarioMovimientoCompra(idDocumento, strTipoRegistro)
    End Function

    Public Function GetUbicarTotalesAlmacen(strIdEmpresa As String, intIdEstablecimiento As Integer, strIdAlmacen As Integer) As List(Of totalesAlmacen) Implements ServiceContract.IContService.GetUbicarTotalesAlmacen
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetUbicarTotalesAlmacen(strIdEmpresa, intIdEstablecimiento, strIdAlmacen)
    End Function

    Public Function GetUbicarProductoTAlmacen(intIdAlmacen As Integer, intIdItem As Integer) As Business.Entity.totalesAlmacen Implements ServiceContract.IContService.GetUbicarProductoTAlmacen
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetUbicarProductoTAlmacen(intIdAlmacen, intIdItem)
    End Function

    Public Function ObtenerItemsPorAlmacen(idAlmacen As Integer) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerItemsPorAlmacen
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerItmesPorAlmacen(idAlmacen)
    End Function

    Public Function ObtenerProdPorAlmacenes(idAlmacen As String, strItem As String) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerProdPorAlmacenes
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerProdPorAlmacenes(idAlmacen, strItem)
    End Function

    Public Function ObtenerProdPorAlmacenesXdiaAll(ByVal idAlmacen As String) As List(Of InventarioMovimiento) Implements ServiceContract.IContService.ObtenerProdPorAlmacenesXdiaAll
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerProdPorAlmacenesXdiaAll(idAlmacen)
    End Function

    Public Function GetListaProductosPorAlmacen(intIdAlmacen As Integer) As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen) Implements ServiceContract.IContService.GetListaProductosPorAlmacen
        Dim almacenBL As New totalesAlmacenBL 'GetListaProductosPorAlmacenFechas
        Return almacenBL.GetListaProductosPorAlmacen(intIdAlmacen)
        'Return almacenBL.GetListaProductosPorAlmacenFechas(intIdAlmacen)
    End Function

    Public Function GetListaProductosPorAlmacenPorCategoria(intIdAlmacen As Integer, intCategoria As Integer) As List(Of totalesAlmacen) Implements IContService.GetListaProductosPorAlmacenPorCategoria
        Dim almacenBL As New totalesAlmacenBL 'GetListaProductosPorAlmacenFechas
        Return almacenBL.GetListaProductosPorAlmacenPorCategoria(intIdAlmacen, intCategoria)
    End Function

    Public Function GetListaProductosPorAlmacenSinCategoria(intIdAlmacen As Integer, intCategoria As Integer) As List(Of totalesAlmacen) Implements IContService.GetListaProductosPorAlmacenSinCategoria
        Dim almacenBL As New totalesAlmacenBL 'GetListaProductosPorAlmacenFechas
        Return almacenBL.GetListaProductosPorAlmacenSinCategoria(intIdAlmacen, intCategoria)
    End Function

    Public Function GetProductoPorTipoExistencia(intIdAlmacen As Integer, strTipoEx As String) As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen) Implements ServiceContract.IContService.GetProductoPorTipoExistencia
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetProductoPorTipoExistencia(intIdAlmacen, strTipoEx)
    End Function

    Public Function GetProductosXempresa(be As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetProductosXempresa
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetProductosXempresa(be)
    End Function


    Public Function GetListaProductosTAPorProducto(intIdAlmacen As Integer, strBusqueda As String) As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen) Implements ServiceContract.IContService.GetListaProductosTAPorProducto
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListaProductosTAPorProducto(intIdAlmacen, strBusqueda)
    End Function

    Public Function GetListaProductosTAPorProductoByTake(intIdAlmacen As Integer, strBusqueda As String) As List(Of totalesAlmacen) Implements IContService.GetListaProductosTAPorProductoByTake
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListaProductosTAPorProductoByTakeSL(intIdAlmacen, strBusqueda)
    End Function

    Public Function GetNotificacionAlmacen() As List(Of totalesAlmacen) Implements IContService.GetNotificacionAlmacen
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetNotificacionAlmacen()
    End Function

    Public Function GetListadoProductosParaVentaXproducto(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetListadoProductosParaVentaXproducto
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListadoProductosParaVentaXproducto(objTotalBE)
    End Function

    Public Function GetListadoProductosParaVentaXproductoXAlmacen(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetListadoProductosParaVentaXproductoXAlmacen
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListadoProductosParaVentaXproductoXAlmacen(objTotalBE)
    End Function

    Public Function GetListadoProductosParaVentaXproductoXAlmacenFull(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetListadoProductosParaVentaXproductoXAlmacenFull
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListadoProductosParaVentaXproductoXAlmacenFull(objTotalBE)
    End Function

    Public Function GetProductoPorAlmacenTipoEx(intIdAlmacen As Integer, strTipoEx As String, strBusqueda As String) As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen) Implements ServiceContract.IContService.GetProductoPorAlmacenTipoEx
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetProductoPorAlmacenTipoEx(intIdAlmacen, strTipoEx, strBusqueda)
    End Function

    Public Function GetUbicar_almacenVirtual(intIdEstablecimiento As Integer) As Business.Entity.almacen Implements ServiceContract.IContService.GetUbicar_almacenVirtual
        Dim almacenBL As New almacenBL
        Return almacenBL.GetUbicar_almacenVirtual(intIdEstablecimiento)
    End Function

    Public Function GetUbicar_almacenPorID(idAlmacen As Integer) As Business.Entity.almacen Implements ServiceContract.IContService.GetUbicar_almacenPorID
        Dim almacenBL As New almacenBL
        Return almacenBL.GetUbicar_almacenPorID(idAlmacen)
    End Function

    Public Function ObtenerProductosEnTransito(strIdEmpresa As String, strIdEstablecimiento As String, strTipoAlmacen As String, Mes As String, Anio As String, strTipoProducto As String) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerProductosEnTransito
        Dim InventarioBL As New InventarioMovimientoBL
        Return InventarioBL.ObtenerProductosEnTransito(strIdEmpresa, strIdEstablecimiento, strTipoAlmacen, Mes, Anio, strTipoProducto)
    End Function

    Public Function GetListar_almacenExceptAV(almacenBE As almacen) As System.Collections.Generic.List(Of Business.Entity.almacen) Implements ServiceContract.IContService.GetListar_almacenExceptAV
        Dim AlmacenBL As New almacenBL
        Return AlmacenBL.GetListar_almacenExceptAV(almacenBE)
    End Function

    Public Function GetListar_almacenes(intIdEstablecimiento As Integer) As System.Collections.Generic.List(Of Business.Entity.almacen) Implements ServiceContract.IContService.GetListar_almacenes
        Dim AlmacenBL As New almacenBL
        Return AlmacenBL.GetListar_almacenes(intIdEstablecimiento)
    End Function

    Public Sub InsertItemsEnTransito(objSalida As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento), objEntrada As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento), listaAsiento As System.Collections.Generic.List(Of Business.Entity.asiento), objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen),
                                      documento As Business.Entity.documento, totalesAlmAV As List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.InsertItemsEnTransito
        Dim AlmacenBL As New InventarioMovimientoBL
        AlmacenBL.InsertItemsEnTransito(objSalida, objEntrada, listaAsiento, objTotalesAlmacen, documento, totalesAlmAV)
    End Sub

    Public Sub InsertItemsEnTransitoSL(objSalida As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento), objEntrada As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento), listaAsiento As System.Collections.Generic.List(Of Business.Entity.asiento), objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen),
                                documento As Business.Entity.documento, totalesAlmAV As List(Of Business.Entity.totalesAlmacen), ByVal objListaPrecios As List(Of listadoPrecios)) Implements ServiceContract.IContService.InsertItemsEnTransitoSL
        Dim AlmacenBL As New InventarioMovimientoBL
        AlmacenBL.InsertItemsEnTransitoSL(objSalida, objEntrada, listaAsiento, objTotalesAlmacen, documento, totalesAlmAV, objListaPrecios)
    End Sub

    Public Function ObtenerProductosEnTransitoPorDocumento(strIdEmpresa As String, strIdEstablecimiento As String, strTipoAlmacen As String, Mes As String, Anio As String, strTipoProducto As String, strNumDocCompra As String) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerProductosEnTransitoPorDocumento
        Dim AlmacenBL As New InventarioMovimientoBL
        Return AlmacenBL.ObtenerProductosEnTransitoPorDocumento(strIdEmpresa, strIdEstablecimiento, strTipoAlmacen, Mes, Anio, strTipoProducto, strNumDocCompra)
    End Function

    Public Sub InsertNuevaAlmacen(lista As Business.Entity.almacen) Implements ServiceContract.IContService.InsertNuevaAlmacen
        Dim almacenBL As New almacenBL
        almacenBL.Insert(lista)
    End Sub

    Public Sub UpdateNuevaAlmacen(lista As Business.Entity.almacen) Implements ServiceContract.IContService.UpdateNuevaAlmacen
        Dim almacenBL As New almacenBL
        almacenBL.Update(lista)
    End Sub

    Public Sub DeleteNuevoAlmacen(almacenBE As Business.Entity.almacen) Implements ServiceContract.IContService.DeleteNuevoAlmacen
        Dim almacenBL As New almacenBL
        almacenBL.Delete(almacenBE)
    End Sub

    Public Function GetEsAlmacenVirtualXFull(strIdempresa As String, intIdEstblec As Integer, intTipo As String) As almacen Implements IContService.GetEsAlmacenVirtualXFull
        Dim almacenBL As New almacenBL
        Return almacenBL.GetEsAlmacenVirtualXFull(strIdempresa, intIdEstblec, intTipo)
    End Function

    Public Function GetListar_almacenPorUsuario(idEmpresa As String, idEstable As Integer, listaPersona As List(Of String), intAnio As Integer, intMes As Integer, fechaInicio As DateTime, fechaFin As DateTime, tipo As String, intDia As Integer) As List(Of almacen) Implements IContService.GetListar_almacenPorUsuario
        Dim almacenBL As New almacenBL
        Return almacenBL.GetListar_almacenPorUsuario(idEmpresa, idEstable, listaPersona, intAnio, intMes, fechaInicio, fechaFin, tipo, intDia)
    End Function

#End Region

#Region "MASCARA CONTABLE 2"

    Public Function ObtenerMascaraExistencias(strIdEmpresa As String, strTipoExistencia As String) As System.Collections.Generic.List(Of Business.Entity.mascaraContableExistencia) Implements ServiceContract.IContService.ObtenerMascaraExistencias
        Dim mascarabl As New mascaraContableExistenciaBL
        Return mascarabl.ObtenerMascaraExistencias(strIdEmpresa, strTipoExistencia)
    End Function

    Public Function ObtenerMascaraContableMercaderia(strEmpresa As String, InitCuenta As String) As System.Collections.Generic.IList(Of Business.Entity.mascaraContable2) Implements ServiceContract.IContService.ObtenerMascaraContableMercaderia
        Dim mascarabl As New mascaraContable2BL
        Return mascarabl.ObtenerMascaraContableMercaderia(strEmpresa, InitCuenta)
    End Function

    Public Function GetUbicar_mascaraContable2PorEmpresa(strIEmpresa As String, strCuenta As String) As Business.Entity.mascaraContable2 Implements ServiceContract.IContService.GetUbicar_mascaraContable2PorEmpresa
        Dim mascarabl As New mascaraContable2BL
        Return mascarabl.GetUbicar_mascaraContable2PorEmpresa(strIEmpresa, strCuenta)
    End Function

    Public Function GetUbicar_mascaraContableExistenciaPorEmpresaCF(idEmpresa As String, strCuenta As String, strTipoEx As String) As Business.Entity.mascaraContableExistencia Implements ServiceContract.IContService.GetUbicar_mascaraContableExistenciaPorEmpresaCF
        Dim mascarabl As New mascaraContableExistenciaBL
        Return mascarabl.GetUbicar_mascaraContableExistenciaPorEmpresaCF(idEmpresa, strCuenta, strTipoEx)
    End Function


    Public Function ObtenerMascaraContable2PorEmpresa(strIdEmpresa As String) As System.Collections.Generic.List(Of mascaraContable2) Implements ServiceContract.IContService.ObtenerMascaraContable2PorEmpresa
        Dim compraBL As New mascaraContable2BL
        Return compraBL.ObtenerMascaraContable2PorEmpresa(strIdEmpresa)
    End Function

    Public Function ObtenerMascaraContable2PorItems(strIdEmpresa As String) As System.Collections.Generic.List(Of mascaraContable2) Implements ServiceContract.IContService.ObtenerMascaraContable2PorItems
        Dim compraBL As New mascaraContable2BL
        Return compraBL.ObtenerMascaraContable2PorItems(strIdEmpresa)
    End Function

    Public Function UpdateMascaraContable2(ByVal mascaraContableExistenciaBE As mascaraContable2) As String Implements ServiceContract.IContService.UpdateMascaraContable2
        Dim UpdateMascaraC As New mascaraContable2BL
        Return UpdateMascaraC.UpdateMantenimientoMascarara2(mascaraContableExistenciaBE)
    End Function

    Public Function InsertarMascaraSingle(ByVal mascaraContable2BE As mascaraContable2) As Integer Implements ServiceContract.IContService.InsertarMascaraSingle
        Dim mascaraContable2 As New mascaraContable2BL
        Return mascaraContable2.InsertarMascaraSingle(mascaraContable2BE)
    End Function

#End Region

#Region "VENTA"
    'Public Sub UpdateVentaNormalContado(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento) Implements IContService.UpdateVentaNormalContado
    '    Dim documentoventaBL As New documentoventaAbarrotesBL
    '    documentoventaBL.UpdateVentaNormalContado(objDocumento, listaTotales, objDeleteTotales, objDocumentoCaja)
    'End Sub
#Region "NOTA CREDITO"

    Public Function ListarNotasXidCompra(intIDoCumento As Integer) As List(Of documentocompra) Implements IContService.ListarNotasXidCompra
        Dim documentoventaBL As New documentocompraBL
        Return documentoventaBL.ListarNotasXidCompra(intIDoCumento)
    End Function

    Public Function GetListarNotasPorIdVentaPadre(intIDoCumento As Integer, strTipoNota As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarNotasPorIdVentaPadre
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarNotasPorIdVentaPadre(intIDoCumento, strTipoNota)
    End Function

    Public Function SaveCompraNotaCreditoVenta(objDocumento As documento, nListaTotalesAlmacen As List(Of totalesAlmacen), nDocumentoNota As documento) As Integer Implements IContService.SaveCompraNotaCreditoVenta
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveCompraNotaCreditoVenta(objDocumento, nListaTotalesAlmacen, nDocumentoNota)
    End Function

    Public Function TieneNotasCD(intIdDocumentoCompra As Integer) As Boolean Implements IContService.TieneNotasCD
        Dim notaBL As New documentocompraBL
        Return notaBL.TieneNotasCD(intIdDocumentoCompra)
    End Function
#End Region

    Public Function DocumentoCanceladoVenta(intIdDocumento As Integer) As String Implements IContService.DocumentoCanceladoVenta
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.DocumentoCancelado(intIdDocumento)
    End Function

    Public Function GetListarVentasPorDiaEstablecimiento(be As documentoventaAbarrotes, Optional UsuarioCaja As String = Nothing) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasPorDiaEstablecimiento
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPorDiaEstablecimiento(be, UsuarioCaja)
    End Function

    Public Function GetListarVentasPorPeriodoCobrados(intIdEstablec As Integer, strPeriodo As String, strTipoVenta As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasPorPeriodoCobrados
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPorPeriodoCobrados(intIdEstablec, strPeriodo, strTipoVenta)
    End Function

#Region "RENTABILIDAD"
    Public Function GetAnalisiRentabilidad(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotesDet) Implements ServiceContract.IContService.GetAnalisiRentabilidad
        Dim ventaBL As New documentoventaAbarrotesDetBL
        Return ventaBL.GetAnalisiRentabilidad(strIdEmpresa, intIdEstablecimiento, strPeriodo)
    End Function
#End Region

    Public Function GetObtenerVentaPorNumeroComprobante(ntIdEstablecimiento As Integer, strPeriodo As String, strTipoVenta As String, strTipoDoc As String, strNumDoc As String) As Business.Entity.documentoventaAbarrotes Implements ServiceContract.IContService.GetObtenerVentaPorNumeroComprobante
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetObtenerVentaPorNumeroComprobante(ntIdEstablecimiento, strPeriodo, strTipoVenta, strTipoDoc, strNumDoc)
    End Function

    Public Function GetListarAllVentasPorCajaAbierta(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotesDet) Implements ServiceContract.IContService.GetListarAllVentasPorCajaAbierta
        Dim documentoventaBL As New documentoventaAbarrotesDetBL
        Return documentoventaBL.GetListarAllVentasPorCajaAbierta(intIdPersona, fechaInicio, fechaFin)
    End Function

    Public Function GetListarAllVentasPorUsuarioGeneral(intIdPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentoventaAbarrotesDet) Implements IContService.GetListarAllVentasPorUsuarioGeneral
        Dim cajaBL As New documentoventaAbarrotesDetBL
        Return cajaBL.GetListarAllVentasPorUsuarioGeneral(intIdPersona, fechaInicio, fechaFin, periodo, tipo)
    End Function

    Public Function GetListarAllVentasDetallado(idDocumento As Integer, tipoexistencia As String) As List(Of documentoventaAbarrotesDet) Implements IContService.GetListarAllVentasDetallado
        Dim cajaBL As New documentoventaAbarrotesDetBL
        Return cajaBL.GetListarAllVentasDetallado(idDocumento, tipoexistencia)
    End Function

    Public Function SaveVentaDirectaTicket(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDocumentoCaja As Business.Entity.documento, cajaUsuario As Business.Entity.cajaUsuario) As Integer Implements ServiceContract.IContService.SaveVentaDirectaTicket
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveVentaDirectaTicket(objDocumento, objTotalesAlmacen, objDocumentoCaja, cajaUsuario)
    End Function

    Public Sub UpdateVentaTicket(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen)) Implements IContService.UpdateVentaTicket
        Dim documentoventaBL As New documentoventaAbarrotesBL
        documentoventaBL.UpdateVenta(objDocumento, listaTotales, objDeleteTotales)
    End Sub

    Public Sub UpdateVentaNormal(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen)) Implements IContService.UpdateVentaNormal
        Dim documentoventaBL As New documentoventaAbarrotesBL
        documentoventaBL.UpdateVentaNormal(objDocumento, listaTotales, objDeleteTotales)
    End Sub

    Public Function UpdateVentaALCredito(objDocumento As Business.Entity.documento, listaTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDeleteTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Object Implements ServiceContract.IContService.UpdateVentaALCredito
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.UpdateVentaALCredito(objDocumento, listaTotales, objDeleteTotales)
    End Function

    Public Function UpdateVentaPagada(objDocumento As Business.Entity.documento, listaTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDeleteTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDocumentoCaja As Business.Entity.documento,
                                      nCajaUsuarioMontos As Business.Entity.cajaUsuario, nCajaUsuarioEliminar As Business.Entity.cajaUsuario) As Object Implements ServiceContract.IContService.UpdateVentaPagada
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.UpdateVentaPagada(objDocumento, listaTotales, objDeleteTotales, objDocumentoCaja, nCajaUsuarioMontos, nCajaUsuarioEliminar)
    End Function

    Public Function UpdateVentaDirecta(objDocumento As Business.Entity.documento, listaTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDeleteTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDocumentoCaja As Business.Entity.documento,
                                       nCajaUsuarioMontos As Business.Entity.cajaUsuario, nCajaUsuarioEliminar As Business.Entity.cajaUsuario) As Object Implements ServiceContract.IContService.UpdateVentaDirecta
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.UpdateVentaDirecta(objDocumento, listaTotales, objDeleteTotales, objDocumentoCaja, nCajaUsuarioMontos, nCajaUsuarioEliminar)
    End Function
    Public Function GetUbicar_documentoventaAbarrotesPorID(idDocumento As Integer) As Business.Entity.documentoventaAbarrotes Implements ServiceContract.IContService.GetUbicar_documentoventaAbarrotesPorID
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
    End Function

    Public Sub ConfirmarVentaTicket(objDocumento As Business.Entity.documento, objDocumentoCaja As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen),
                                    cajaUsuario As Business.Entity.cajaUsuario) Implements ServiceContract.IContService.ConfirmarVentaTicket
        Dim documentoventaBL As New documentoventaAbarrotesBL
        documentoventaBL.ConfirmarVentaTicket(objDocumento, objDocumentoCaja, objTotalesAlmacen, cajaUsuario)
    End Sub

    Public Function SaveRegistroHonorariosVenta(objDocumento As documento) As Integer Implements IContService.SaveRegistroHonorariosVenta
        Dim documentoBL As New documentoventaAbarrotesBL
        Return documentoBL.SaveRegistroHonorariosVenta(objDocumento)
    End Function

    'Public Sub UpdateVentaNormalContado(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento) Implements IContService.UpdateVentaNormalContado
    '    Dim documentoventaBL As New documentoventaAbarrotesBL
    '    documentoventaBL.UpdateVentaNormalContado(objDocumento, listaTotales, objDeleteTotales, objDocumentoCaja)
    'End Sub

    Public Function GetUbicar_documentoventaAbarrotesDetPorIDocumento(intidDocumento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotesDet) Implements ServiceContract.IContService.GetUbicar_documentoventaAbarrotesDetPorIDocumento
        Dim documentoventaBL As New documentoventaAbarrotesDetBL
        Return documentoventaBL.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intidDocumento)
    End Function

    Public Function usp_EditarDetalleVenta(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet) Implements IContService.usp_EditarDetalleVenta
        Dim documentoventaBL As New documentoventaAbarrotesDetBL
        Return documentoventaBL.usp_EditarDetalleVenta(intidDocumento)
    End Function

    Public Function Get_EditarDetalleVentaSinLote(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet) Implements IContService.Get_EditarDetalleVentaSinLote
        Dim documentoventaBL As New documentoventaAbarrotesDetBL
        Return documentoventaBL.Get_EditarDetalleVentaSinLote(intidDocumento)
    End Function


    Public Function GetUbicar_documentoventaAbarrotesDetPorID(Secuencia As Integer) As documentoventaAbarrotesDet Implements IContService.GetUbicar_documentoventaAbarrotesDetPorID
        Dim documentoventaBL As New documentoventaAbarrotesDetBL
        Return documentoventaBL.GetUbicar_documentoventaAbarrotesDetPorID(Secuencia)
    End Function

    Public Function SaveVentaTicket(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Integer Implements ServiceContract.IContService.SaveVentaTicket
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveVenta(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveVentaALCredito(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Integer Implements ServiceContract.IContService.SaveVentaALCredito
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveVentaALCredito(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveVentaNormalAlCredito(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer Implements IContService.SaveVentaNormalAlCredito
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveVentaNormalAlCredito(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveVentaPagada(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDocumentoCaja As Business.Entity.documento,
                                    cajaUsuario As Business.Entity.cajaUsuario) As Integer Implements ServiceContract.IContService.SaveVentaPagada
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveVentaPagada(objDocumento, objTotalesAlmacen, objDocumentoCaja, cajaUsuario)
    End Function

    Public Function SaveOtrasSalidas(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Integer Implements ServiceContract.IContService.SaveOtrasSalidas
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.SaveOtrasSalidas(objDocumento, objTotalesAlmacen)
    End Function

    Public Function GetListarVentasPorPeriodo(intIdProyecto As Integer, strPeriodo As String, strTipoVenta As String, Optional UsuarioCaja As String = Nothing) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotes) Implements ServiceContract.IContService.GetListarVentasPorPeriodo
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPorPeriodo(intIdProyecto, strPeriodo, strTipoVenta, UsuarioCaja)
    End Function

    Public Function GetListarVentasNormalPorPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasNormalPorPeriodo
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasNormalPorPeriodo(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarVentasPorPeriodo_CONT(strPeriodo As String, strTipoVenta As String) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotes) Implements ServiceContract.IContService.GetListarVentasPorPeriodo_CONT
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPorPeriodo_CONT(strPeriodo, strTipoVenta)
    End Function

    Public Function GetListarVentasPorPeriodoGeneral(intIdProyecto As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotes) Implements ServiceContract.IContService.GetListarVentasPorPeriodoGeneral
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPorPeriodoGeneral(intIdProyecto, strPeriodo)
    End Function

    Public Function GetListarVentasPorPeriodoGeneral_CONT(strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoventaAbarrotes) Implements ServiceContract.IContService.GetListarVentasPorPeriodoGeneral_CONT
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPorPeriodoGeneral_CONT(strPeriodo)
    End Function

    Public Function GetObtenerVentaPorNumero(intIdEstablecimiento As Integer, strPeriodo As String, strTipoVenta As String, strTipoDoc As String, strSerie As String, strNumDoc As String) As Business.Entity.documentoventaAbarrotes Implements ServiceContract.IContService.GetObtenerVentaPorNumero
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetObtenerVentaPorNumero(intIdEstablecimiento, strPeriodo, strTipoVenta, strTipoDoc, strSerie, strNumDoc)
    End Function
#End Region

#Region "COMPRA"


    Public Function SumatoriaImportesCompra(intIdDocumento As Integer) As Business.Entity.documentocompradetalle Implements ServiceContract.IContService.SumatoriaImportesCompra
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.SumatoriaImportesCompra(intIdDocumento)
    End Function

    Public Function TieneItemsEnAV(intIdDocumento As Integer) As Boolean Implements ServiceContract.IContService.TieneItemsEnAV
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.TieneItemsEnAV(intIdDocumento)
    End Function
    Public Function UbicarCompraPorProveedor(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.UbicarCompraPorProveedor
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarCompraPorProveedor(strEmpresa, intIdEstablecimiento, intIdProveedor)
    End Function

    Public Function UbicarCompraPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra) Implements IContService.UbicarCompraPorProveedorXperiodo
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarCompraPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function UbicarCompraPorProveedorXperiodo2(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, strMoneda As String) As List(Of documentocompra) Implements IContService.UbicarCompraPorProveedorXperiodo2
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarCompraPorProveedorXperiodo2(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, strMoneda)
    End Function

    Public Function UbicarVentaPorClienteXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarVentaPorClienteXperiodo
        Dim documentoBL As New documentoventaAbarrotesBL
        Return documentoBL.UbicarVentaPorClienteXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function UbicarCompraPorProveedorSerie(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer, strSerie As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.UbicarCompraPorProveedorSerie
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarCompraPorProveedorSerie(strEmpresa, intIdEstablecimiento, intIdProveedor, strSerie)
    End Function

    Public Function ValidarEstadoManipulacion(intIdDocumentoCompra As Integer) As Integer Implements ServiceContract.IContService.ValidarEstadoManipulacion
        Dim documentoBL As New documentocompraBL
        Return documentoBL.ValidarEstadoManipulacion(intIdDocumentoCompra)
    End Function

    Public Function SaveCompraNotaCredito(objDocumento As Business.Entity.documento, nListaTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), nDocumentoNota As Business.Entity.documento) As Integer Implements ServiceContract.IContService.SaveCompraNotaCredito
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraNotaCredito(objDocumento, nListaTotalesAlmacen, nDocumentoNota)
    End Function

    Public Function SaveCompraNotaCredito2(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer Implements IContService.SaveCompraNotaCredito2
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraNotaCredito2(objDocumento, nDocumentoCaja, nDocumentoSaldoVenta)
    End Function

    Public Function SaveCompraNotaDebito(objDocumento As Business.Entity.documento, nListaTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), nDocumentoNota As documento) As Integer Implements ServiceContract.IContService.SaveCompraNotaDebito
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraNotaDebito(objDocumento, nListaTotalesAlmacen, nDocumentoNota)
    End Function

    Public Function GetListarComprasPorProveedor(strIdEmpresa As String, intIdEstable As Integer, intIdProveedor As Integer) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasPorProveedor
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorProveedor(strIdEmpresa, intIdEstable, intIdProveedor)
    End Function

    Public Function SaveCompraPagada(objDocumento As Business.Entity.documento, objDocumentoCaja As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen),
                                      cajaUsuario As Business.Entity.cajaUsuario, objListaPrecio As List(Of listadoPrecios),
                                       Optional nDocumentoTributo As Business.Entity.documento = Nothing) As Integer Implements ServiceContract.IContService.SaveCompraPagada
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraPagada(objDocumento, objDocumentoCaja, objTotalesAlmacen, cajaUsuario, objListaPrecio, nDocumentoTributo)
    End Function

    Public Function SaveOtrasEntradas(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen),
                                       nListaOrigenAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Integer Implements ServiceContract.IContService.SaveOtrasEntradas
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveOtrasEntradas(objDocumento, objTotalesAlmacen, nListaOrigenAlmacen)
    End Function

    Public Sub GrabarTransferenciaAlmacenes(objDocumento As documento) Implements IContService.GrabarTransferenciaAlmacenes
        Dim documentoBL As New documentocompraBL
        documentoBL.GrabarTransferenciaAlmacenes(objDocumento)
    End Sub

    Public Function SaveOtrasEntradasDefault(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Integer Implements ServiceContract.IContService.SaveOtrasEntradasDefault
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveOtrasEntradasDefault(objDocumento, objTotalesAlmacen)
    End Function

    Public Sub DeleteCompraDetalle(nDocumento As Business.Entity.documentocompradetalle) Implements ServiceContract.IContService.DeleteCompraDetalle
        Dim documentoBL As New documentocompradetalleBL
        documentoBL.Delete(nDocumento)
    End Sub
    Public Function GetUbicar_documentocompradetallePorID(Secuencia As Integer) As Business.Entity.documentocompradetalle Implements ServiceContract.IContService.GetUbicar_documentocompradetallePorID
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.GetUbicar_documentocompradetallePorID(Secuencia)
    End Function

    Public Sub DeleteDocumento(nDocumento As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteDocumento
        Dim documentoBL As New documentoBL
        documentoBL.Delete(nDocumento, objTotalBorrar)
    End Sub

    Public Sub DeleteDocumentoSL(nDocumento As Business.Entity.documento, objTotalBorrar As List(Of totalesAlmacen)) Implements ServiceContract.IContService.DeleteDocumentoSL
        Dim documentoBL As New documentoBL
        documentoBL.DeleteSL(nDocumento, objTotalBorrar)
    End Sub

    Public Sub EliminarDocNotasRef(intIdDocumentoPadre As Integer) Implements IContService.EliminarDocNotasRef
        Dim documentoBL As New documentoBL
        documentoBL.EliminarDocNotasRef(intIdDocumentoPadre)
    End Sub

    Public Sub DeleteDocumentoPagado(nDocumento As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteDocumentoPagado
        Dim documentoBL As New documentoBL
        documentoBL.DeletePagado(nDocumento, objTotalBorrar)
    End Sub

    Public Sub DeleteDocumentoPagadoSL(nDocumento As Business.Entity.documento) Implements ServiceContract.IContService.DeleteDocumentoPagadoSL
        Dim documentoBL As New documentoBL
        documentoBL.DeletePagadoSL(nDocumento)
    End Sub

    Public Sub DeleteDocumentoPagadoAlCredito(nDocumento As Business.Entity.documento) Implements ServiceContract.IContService.DeleteDocumentoPagadoAlCredito
        Dim documentoBL As New documentoBL
        documentoBL.DeleteDocumentoPagadoAlCredito(nDocumento)
    End Sub

    Public Function DeleteUsuarioCajaSL(nDocumento As Business.Entity.documento) As String Implements ServiceContract.IContService.DeleteUsuarioCajaSL
        Dim documentoBL As New documentoBL
        Return documentoBL.DeleteUsuarioCajaSL(nDocumento)
    End Function

    Public Sub DeleteOtrasEntradas(documentoBE As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteOtrasEntradas
        Dim documentoBL As New documentoBL
        documentoBL.DeleteOtrasEntradas(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteOtrasSalidasDeAlmacen(documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen)) Implements IContService.DeleteOtrasSalidasDeAlmacen
        Dim documentoBL As New documentoBL
        documentoBL.DeleteOtrasSalidasDeAlmacen(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteOtrasTransAlmacenOE(documentoBE As Business.Entity.documento, ListaOrigen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), ListaDestino As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteOtrasTransAlmacenOE
        Dim documentoBL As New documentoBL
        documentoBL.DeleteOtrasTransAlmacenOE(documentoBE, ListaOrigen, ListaDestino)
    End Sub

    Public Sub DeleteOtrasTransAlmacenOESL(documentoBE As Business.Entity.documento) Implements ServiceContract.IContService.DeleteOtrasTransAlmacenOESL
        Dim documentoBL As New documentoBL
        documentoBL.DeleteOtrasTransAlmacenOESL(documentoBE)
    End Sub

    Public Sub DeleteOtrasSalidas(documentoBE As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteOtrasSalidas
        Dim documentoBL As New documentoBL
        documentoBL.DeleteOtrasSalidas(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteNotas(documentoBE As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteNotas
        Dim documentoBL As New documentoBL
        documentoBL.DeleteNotas(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteNotasDebito(documentoBE As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteNotasDebito
        Dim documentoBL As New documentoBL
        documentoBL.DeleteNotasDebito(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteVentaTicket(documentoBE As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteVentaTicket
        Dim documentoBL As New documentoBL
        documentoBL.DeleteVentaTicket(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteVentaTicketXitem(documentoBE As documento, objTotalBorrar As totalesAlmacen) Implements IContService.DeleteVentaTicketXitem
        Dim documentoBL As New documentoBL
        documentoBL.DeleteVentaTicketXitem(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteVentaNormalAlCredito(documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen)) Implements IContService.DeleteVentaNormalAlCredito
        Dim documentoBL As New documentoBL
        documentoBL.DeleteVentaNormalAlCredito(documentoBE, objTotalBorrar)
    End Sub


    Public Sub DeleteVentaTicketCobrado(documentoBE As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteVentaTicketCobrado
        Dim documentoBL As New documentoBL
        documentoBL.DeleteVentaTicketCobrado(documentoBE, objTotalBorrar)
    End Sub

    Public Sub UpdateDocumentoCompra(nDocumento As Business.Entity.documento, listaTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDeleteTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen),
                                     Optional nDocumentoTributo As Business.Entity.documento = Nothing) Implements ServiceContract.IContService.UpdateDocumentoCompra
        Dim documentoBL As New documentocompraBL
        documentoBL.UpdateCompra(nDocumento, listaTotales, objDeleteTotales, nDocumentoTributo)
    End Sub

    Public Sub UpdateCompraAlCreditoCnRecep(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), Optional nDocumentoTributo As documento = Nothing) Implements IContService.UpdateCompraAlCreditoCnRecep
        Dim documentoBL As New documentocompraBL
        documentoBL.UpdateCompraAlCreditoCnRecep(objDocumento, listaTotales, objDeleteTotales, nDocumentoTributo)
    End Sub

    Public Sub UpdateAporteExistencia(objDocumento As Business.Entity.documento, listaTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDeleteTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.UpdateAporteExistencia
        Dim documentoBL As New documentocompraBL
        documentoBL.UpdateAporteExistencia(objDocumento, listaTotales, objDeleteTotales)
    End Sub

    Public Sub UpdateDocumentoCompraPagada(nDocumento As Business.Entity.documento, listaTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDeleteTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDocumentoCaja As Business.Entity.documento,
                                           nCajaUsuarioMontos As Business.Entity.cajaUsuario, nCajaUsuarioEliminar As Business.Entity.cajaUsuario) Implements ServiceContract.IContService.UpdateDocumentoCompraPagada
        Dim documentoBL As New documentocompraBL
        documentoBL.UpdateCompraPagada(nDocumento, listaTotales, objDeleteTotales, objDocumentoCaja, nCajaUsuarioMontos, nCajaUsuarioEliminar)
    End Sub

    Public Sub UpdateOtrasEntradas(objDocumento As Business.Entity.documento, listaTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDeleteTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.UpdateOtrasEntradas
        Dim documentoBL As New documentocompraBL
        documentoBL.UpdateOtrasEntradas(objDocumento, listaTotales, objDeleteTotales)
    End Sub

    Public Sub UpdateOtrasSalidas(objDocumento As Business.Entity.documento, listaTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDeleteTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.UpdateOtrasSalidas
        Dim documentoBL As New documentoventaAbarrotesBL
        documentoBL.UpdateOtrasSalidas(objDocumento, listaTotales, objDeleteTotales)
    End Sub

    Public Function SaveDocumentoCompra(nDocumento As Business.Entity.documento, objTotalesAlmacen As List(Of Business.Entity.totalesAlmacen), Optional nDocumentoTributo As Business.Entity.documento = Nothing) As Integer Implements ServiceContract.IContService.SaveDocumentoCompra
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompra(nDocumento, objTotalesAlmacen, nDocumentoTributo)
    End Function

    Public Function SaveCompraAlCreditoConRecep(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), listaPrecios As List(Of listadoPrecios), Optional nDocumentoTributo As documento = Nothing) As Integer Implements IContService.SaveCompraAlCreditoConRecep
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraAlCreditoConRecep(objDocumento, objTotalesAlmacen, listaPrecios, nDocumentoTributo)
    End Function

    Public Function SaveCompraNuevoMetodo(objDocumento As documento) As Integer Implements IContService.SaveCompraNuevoMetodo
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraNuevoMetodo(objDocumento)
    End Function

    Public Function SaveCompraNuevoMetodoContado(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer Implements IContService.SaveCompraNuevoMetodoContado
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraNuevoMetodoContado(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveCompraNuevoMetodoOrden(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objOtrosDatos As documentoOtrosDatos) As Integer Implements IContService.SaveCompraNuevoMetodoOrden
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraNuevoMetodoOrden(objDocumento, objTotalesAlmacen, objOtrosDatos)
    End Function

    Public Sub GrabarCuetasPorPagarApertura(be As List(Of documento)) Implements IContService.GrabarCuetasPorPagarApertura
        Dim documentoBL As New documentocompraBL
        documentoBL.GrabarCuetasPorPagarApertura(be)
    End Sub

    Public Sub ActualualizarCompraSingle(objDocumento As documento) Implements IContService.ActualualizarCompraSingle
        Dim documentoBL As New documentocompraBL
        documentoBL.ActualualizarCompraSingle(objDocumento)
    End Sub

    Public Function UbicarDetalleCompraEval(intIdDocumento As Integer) As List(Of documentocompradetalle) Implements IContService.UbicarDetalleCompraEval
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.UbicarDetalleCompraEval(intIdDocumento)
    End Function

    Public Function GrabarBonificaciones(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer Implements IContService.GrabarBonificaciones
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GrabarBonificaciones(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveRegistroHonorarios(objDocumento As documento) As Integer Implements IContService.SaveRegistroHonorarios
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveRegistroHonorarios(objDocumento)
    End Function

#Region "COMPRA DIRECTA SIN RECEPCION"

    Public Function SaveRegistroCompraAnticipada(objDocumento As documento) As Integer Implements IContService.SaveRegistroCompraAnticipada
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveRegistroCompraAnticipada(objDocumento)
    End Function

    Public Function UbicarCompraPorSerieNro(strEmpresa As String, intIdEstablecimiento As Integer, strSerie As String, strNumero As String, strRuc As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.UbicarCompraPorSerieNro
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarCompraPorSerieNro(strEmpresa, intIdEstablecimiento, strSerie, strNumero, strRuc)
    End Function

    Public Function UbicarNCreditoPorSerieNro(strEmpresa As String, intIdEstablecimiento As Integer, strSerie As String, strNumero As String, strRuc As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.UbicarNCreditoPorSerieNro
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarNCreditoPorSerieNro(strEmpresa, intIdEstablecimiento, strSerie, strNumero, strRuc)
    End Function

    Public Function SaveCompraDirectaSinRecepcion(objDocumento As Business.Entity.documento, objTotalesAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDocumentoCaja As Business.Entity.documento, cajaUsuario As Business.Entity.cajaUsuario, Optional nDocumentoTributo As Business.Entity.documento = Nothing) As Integer Implements ServiceContract.IContService.SaveCompraDirectaSinRecepcion
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraDirectaSinRecepcion(objDocumento, objTotalesAlmacen, objDocumentoCaja, cajaUsuario, nDocumentoTributo)
    End Function

    Public Function UpdateCompraDirectaSinRecepcion(objDocumento As Business.Entity.documento, listaTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDeleteTotales As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen), objDocumentoCaja As Business.Entity.documento, nCajaUsuarioMontos As Business.Entity.cajaUsuario, nCajaUsuarioEliminar As Business.Entity.cajaUsuario) As Object Implements ServiceContract.IContService.UpdateCompraDirectaSinRecepcion
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UpdateCompraDirectaSinRecepcion(objDocumento, listaTotales, objDeleteTotales, objDocumentoCaja, nCajaUsuarioMontos, nCajaUsuarioEliminar)
    End Function

    Public Sub DeleteCompraDirectaSinRecepcion(documentoBE As Business.Entity.documento, objTotalBorrar As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) Implements ServiceContract.IContService.DeleteCompraDirectaSinRecepcion
        Dim documentoBL As New documentoBL
        documentoBL.DeleteCompraDirectaSinRecepcion(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteCompraDirectaSinRecepcionSL(documentoBE As Business.Entity.documento, objTotalBorrar As List(Of totalesAlmacen)) Implements ServiceContract.IContService.DeleteCompraDirectaSinRecepcionSL
        Dim documentoBL As New documentoBL
        documentoBL.DeleteCompraDirectaSinRecepcionSL(documentoBE, objTotalBorrar)
    End Sub

    Public Sub DeleteCompraCreditoConRecepcionSL(documentoBE As Business.Entity.documento) Implements ServiceContract.IContService.DeleteCompraCreditoConRecepcionSL
        Dim documentoBL As New documentoBL
        documentoBL.DeleteCompraCreditoConRecepcionSL(documentoBE)
    End Sub
#End Region

    Public Function UbicarDocumento(intIdDocumento As Integer) As Business.Entity.documento Implements ServiceContract.IContService.UbicarDocumento
        Dim documentoBL As New documentoBL
        Return documentoBL.GetUbicar_documentoPorID(intIdDocumento)
    End Function

    Public Function GetListarPorPeriodoEntradas(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strTipoCompra As String, strTipoConsulta As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarPorPeriodoEntradas
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarPorPeriodoEntradas(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoCompra, strTipoConsulta)
    End Function

    Public Function GetListarPorPeriodoEntradasTransferencia(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strTipoCompra As String, strTipoConsulta As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarPorPeriodoEntradasTransferencia
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarPorPeriodoEntradasTransferencia(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoCompra, strTipoConsulta)
    End Function

    Public Function GetListarMvimientosAlmacenPorDia(intIdEmpresa As String, intIdEstablecimiento As Integer, strTipoCompra As String, tipoConsulta As String, Optional fecha As DateTime = Nothing) As List(Of documentocompra) Implements IContService.GetListarMvimientosAlmacenPorDia
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarMvimientosAlmacenPorDia(intIdEmpresa, intIdEstablecimiento, strTipoCompra, tipoConsulta, fecha)
    End Function

    Public Function GetListarComprasPorPeriodo(intIdProyecto As Integer, strPeriodo As String, strTipoCompra As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasPorPeriodo
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorPeriodo(intIdProyecto, strPeriodo, strTipoCompra)
    End Function

    Public Function GetListarComprasPorPeriodoGeneral(intIdProyecto As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasPorPeriodoGeneral
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorPeriodoGeneral(intIdProyecto, strPeriodo)
    End Function
    Public Function GetListarComprasPorPeriodoGeneral_CONT(intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasPorPeriodoGeneral_CONT
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorPeriodoGeneral_CONT(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarComprasPorPeriodoGeneral_CONT_CONTADO(documentocompraBE As documentocompra, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra) Implements IContService.GetListarComprasPorPeriodoGeneral_CONT_CONTADO
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(documentocompraBE, strPeriodo, UsuarioCaja)
    End Function

    Public Function GetListarComprasPorPeriodoGeneralTransferencia(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra) Implements IContService.GetListarComprasPorPeriodoGeneralTransferencia
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorPeriodoGeneralTransferencia(intIdEstablecimiento, strPeriodo, UsuarioCaja)
    End Function

    Public Function GetListarComprasPorPeriodoGeneral_CONT_CREDITO(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra) Implements IContService.GetListarComprasPorPeriodoGeneral_CONT_CREDITO
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorPeriodoGeneral_CONT_CREDITO(intIdEstablecimiento, strPeriodo, UsuarioCaja)
    End Function

    Public Function GetListarComprasPorPeriodoGeneralCentral(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra) Implements IContService.GetListarComprasPorPeriodoGeneralCentral
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorPeriodoGeneralCentral(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarOrdenComprasPorPeriodoGeneral(intIdEstablecimiento As Integer, strPeriodo As String, tipoOrden As String) As List(Of documentocompra) Implements IContService.GetListarOrdenComprasPorPeriodoGeneral
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarOrdenComprasPorPeriodoGeneral(intIdEstablecimiento, strPeriodo, tipoOrden)
    End Function

    Public Function GetListarOrdenComprasPorFiltro(intIdEstablecimiento As Integer, strPeriodo As String, tipoOrden As String, intproveedor As Integer, moneda As Integer) As List(Of documentocompra) Implements IContService.GetListarOrdenComprasPorFiltro
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarOrdenComprasPorFiltro(intIdEstablecimiento, strPeriodo, tipoOrden, intproveedor, moneda)
    End Function

    Public Function GetListarOrdenServiciosPorPeriodoGeneral(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra) Implements IContService.GetListarOrdenServiciosPorPeriodoGeneral
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarOrdenServiciosPorPeriodoGeneral(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarNotasPorIdCompraPadre(intIDocumentoPadre As Integer, strTipoNota As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarNotasPorIdCompraPadre
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarNotasPorIdCompraPadre(intIDocumentoPadre, strTipoNota)
    End Function

    Public Function GetListarComprasPorPeriodoCambioGeneral(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra) Implements IContService.GetListarComprasPorPeriodoCambioGeneral
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorPeriodoCambioGeneral(intIdEstablecimiento, strPeriodo, UsuarioCaja)
    End Function

    Public Function UbicarDocumentoCompra(intIdDocumento As Integer) As Business.Entity.documentocompra Implements ServiceContract.IContService.UbicarDocumentoCompra
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetUbicar_documentocompraPorID(intIdDocumento)
    End Function

    Public Function UbicarDocumentoCompraDetalle(intIdDocumento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentocompradetalle) Implements ServiceContract.IContService.UbicarDocumentoCompraDetalle
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.GetUbicar_documentocompradetallePorCompra(intIdDocumento)
    End Function

    Public Function GetUbicar_documentocompradetallePorCompraNotificacion(strSerie As String, strNroDoc As String) As System.Collections.Generic.List(Of Business.Entity.documentocompradetalle) Implements ServiceContract.IContService.GetUbicar_documentocompradetallePorCompraNotificacion
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.GetUbicar_documentocompradetallePorCompraNotificacion(strSerie, strNroDoc)
    End Function

    Public Function UltimasOtrasSalidasPorFecha(strEmpresa As String, intIdEstablecimiento As Integer, intCuota As Integer, intAlnacenConsulta As Integer, IntIdItem As String) As List(Of documentocompradetalle) Implements IContService.UltimasOtrasSalidasPorFecha
        Dim almacenBL As New documentocompradetalleBL
        Return almacenBL.UltimasOtrasSalidasPorFecha(strEmpresa, intIdEstablecimiento, intCuota, intAlnacenConsulta, IntIdItem)
    End Function

    Public Function GetUbicar_documentocompradetallePorItem(strNombreItem As String, strSitucion As String) As System.Collections.Generic.List(Of Business.Entity.documentocompradetalle) Implements ServiceContract.IContService.GetUbicar_documentocompradetallePorItem
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.GetUbicar_documentocompradetallePorItem(strNombreItem, strSitucion)
    End Function

    Public Function GetUbicar_documentocompradetallePorCompra(strSerie As String, strNroDoc As String, strSitucion As String) As System.Collections.Generic.List(Of Business.Entity.documentocompradetalle) Implements ServiceContract.IContService.GetUbicar_documentocompradetallePorCompra
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.GetUbicar_documentocompradetallePorCompraSL(strSerie, strNroDoc, strSitucion)
    End Function

    Public Function UbicarDocumentoCompraDetalleSituacion(intIdDocumento As Integer, strSituacion As String) As System.Collections.Generic.List(Of Business.Entity.documentocompradetalle) Implements ServiceContract.IContService.UbicarDocumentoCompraDetalleSituacion
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.UbicarDocumentoCompraDetalleSituacion(intIdDocumento, strSituacion)
    End Function


#End Region


#Region "ENTIDAD"
    Public Function ListarEntidadesPorNombres(strtipo As String, strEmpresa As String, strBusqueda As String) As System.Collections.Generic.List(Of Business.Entity.entidad) Implements ServiceContract.IContService.ListarEntidadesPorNombres
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.ListarEntidadesPorNombres(strtipo, strEmpresa, strBusqueda)
    End Function

    Public Function ListarEntidadesPorRuc(strtipo As String, strEmpresa As String, strBusqueda As String) As System.Collections.Generic.List(Of Business.Entity.entidad) Implements ServiceContract.IContService.ListarEntidadesPorRuc
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.ListarEntidadesPorRuc(strtipo, strEmpresa, strBusqueda)
    End Function

    Public Sub DeleteEntidad(nEntidad As Business.Entity.entidad) Implements ServiceContract.IContService.DeleteEntidad
        Dim EntidadBL As New entidadBL()
        EntidadBL.Delete(nEntidad)
    End Sub
    Public Function SaveEntidad(nEntidad As Business.Entity.entidad) As Integer Implements ServiceContract.IContService.SaveEntidad
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.Insert(nEntidad)
    End Function

    Public Function UbicarEntidadPorRucNro(strEmpresa As String, strTipoEntidad As String, strNroDoc As String) As entidad Implements IContService.UbicarEntidadPorRucNro
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.UbicarEntidadPorRucNro(strEmpresa, strTipoEntidad, strNroDoc)
    End Function

    Public Function UbicarEntidadVarios(strtipo As String, strEmpresa As String, strBusqueda As String, idEstablecimiento As Integer) As Business.Entity.entidad Implements ServiceContract.IContService.UbicarEntidadVarios
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.UbicarEntidadVarios(strtipo, strEmpresa, strBusqueda, idEstablecimiento)
    End Function

    Public Sub UpdateEntidad(nEntidad As Business.Entity.entidad) Implements ServiceContract.IContService.UpdateEntidad
        Dim EntidadBL As New entidadBL()
        EntidadBL.Update(nEntidad)
    End Sub
    Public Function GetListarEntidad(EntidadBE As entidad) As System.Collections.Generic.List(Of Business.Entity.entidad) Implements ServiceContract.IContService.GetListarEntidad
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.GetListarEntidad(EntidadBE)
    End Function

    Public Function GetUbicarEntidadPorID(intIdEntidad As Integer) As System.Collections.Generic.List(Of Business.Entity.entidad) Implements ServiceContract.IContService.GetUbicarEntidadPorID
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.GetUbicarEntidadPorID(intIdEntidad)
    End Function


#End Region

#Region "EMPRESAS"
    Public Function GetUbicarSerieEmpresa(intIDEstablecimiento As Integer, strComprobante As String, strSerie As String) As Business.Entity.EmpresaSeries Implements ServiceContract.IContService.GetUbicarSerieEmpresa
        Dim empresaBL As New EmpresaSeriesBL()
        Return empresaBL.GetUbicarSerieEmpresa(intIDEstablecimiento, strComprobante, strSerie)
    End Function

    Public Function GetListaEmpresas() As System.Collections.Generic.List(Of Business.Entity.empresa) Implements ServiceContract.IContService.GetListaEmpresas
        Dim empresaBL As New empresaBL()
        Return empresaBL.GetObtenerEmpresas()
    End Function

    Public Function GetUbicaEmpresaRuc(strIdEmpresa As String) As Business.Entity.empresa Implements ServiceContract.IContService.GetUbicaEmpresaRuc
        Dim empresaBL As New empresaBL()
        Return empresaBL.GetObtenerEmpresasPorID(strIdEmpresa)
    End Function


#End Region

#Region "ESTABLECIMIENTOS"
    Public Function GetUbicaEstablecimientoID(intIdEstable As Integer) As Business.Entity.centrocosto Implements ServiceContract.IContService.GetUbicaEstablecimientoID
        Dim establecBL As New centrocostoBL()
        Return establecBL.GetObtenerEstablecimientoPorID(intIdEstable)
    End Function

    Public Function GetListaEstablecimientos(srtEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.centrocosto) Implements ServiceContract.IContService.GetListaEstablecimientos
        Dim establecBL As New centrocostoBL()
        Return establecBL.GetObtenerEstablecimiento(srtEmpresa)
    End Function

    Public Function InsertEstablecimiento(estableBE As Business.Entity.centrocosto) As Integer Implements ServiceContract.IContService.InsertEstablecimiento
        Dim establecBL As New centrocostoBL()
        Return establecBL.InsertEstablecimiento(estableBE)
    End Function
#End Region

#Region "PROYECTO"

    'Public Sub EditarProyectoModoTrabajo(nProyecto As Business.Entity.ProyectoPlaneacion) Implements ServiceContract.IContService.EditarProyectoModoTrabajo
    '    Dim ProyectoBL As New ProyectoPlaneacionBL()
    '    ProyectoBL.UpdateModoTrabajo(nProyecto)
    'End Sub

    Public Sub SaveProyecto(nProyecto As Business.Entity.ProyectoPlaneacion) Implements ServiceContract.IContService.SaveProyecto
        Dim ProyectoBL As New ProyectoPlaneacionBL()
        ProyectoBL.Insert(nProyecto)
    End Sub

    Public Sub DeleteProyecto(nProyecto As Business.Entity.ProyectoPlaneacion) Implements ServiceContract.IContService.DeleteProyecto
        Dim ProyectoBL As New ProyectoPlaneacionBL()
        ProyectoBL.Delete(nProyecto)
    End Sub

    Public Sub EditarProyecto(nProyecto As Business.Entity.ProyectoPlaneacion) Implements ServiceContract.IContService.EditarProyecto
        Dim ProyectoBL As New ProyectoPlaneacionBL()
        ProyectoBL.Update(nProyecto)
    End Sub
    Public Function GetListaProyectos(intIdEstable As Integer) As System.Collections.Generic.List(Of Business.Entity.ProyectoPlaneacion) Implements ServiceContract.IContService.GetListaProyectos
        Dim ProyectoBL As New ProyectoPlaneacionBL()
        Return ProyectoBL.GetProyectos(intIdEstable)
    End Function

    Public Function GetUbicaProyecto(intIdProyecto As Integer) As Business.Entity.ProyectoPlaneacion Implements ServiceContract.IContService.GetUbicaProyecto
        Dim ProyectoBL As New ProyectoPlaneacionBL()
        Return ProyectoBL.GetUbicaProyecto(intIdProyecto)
    End Function

    Public Function UpdateModoTrabajo(nProyecto As Business.Entity.ProyectoPlaneacion, ByVal IdActividadMTAnt As Integer, ByVal EstadoMTAnt As String) As Boolean Implements ServiceContract.IContService.UpdateModoTrabajo
        Dim ProyectoBL As New ProyectoPlaneacionBL()
        Return ProyectoBL.UpdateModoTrabajo(nProyecto, IdActividadMTAnt, EstadoMTAnt)
    End Function

    Public Sub EditarProyectoModoTrabajo(nProyecto As Business.Entity.ProyectoPlaneacion) Implements ServiceContract.IContService.EditarProyectoModoTrabajo
        Dim ProyectoBL As New ProyectoPlaneacionBL()
        ProyectoBL.UpdateModoTrabajo(nProyecto)
    End Sub

#End Region

    Public Function AsientoGetAll() As System.Collections.Generic.List(Of Business.Entity.asiento) Implements ServiceContract.IContService.AsientoGetAll
        Dim AsientoBL As New AsientoBL()
        Return AsientoBL.GetAll()
    End Function

    Public Sub AsientoSaveByGroup(lista As System.Collections.Generic.List(Of Business.Entity.asiento)) Implements ServiceContract.IContService.AsientoSaveByGroup
        Dim AsientoBL As New AsientoBL()
        AsientoBL.SavebyGroup(lista)
    End Sub

#Region "TRABAJADOR"
    Public Sub EliminarTrabajador(nTrab As Business.Entity.Trabajador_PL) Implements ServiceContract.IContService.EliminarTrabajador
        Dim TrabBL As New Trabajador_PLBL()
        TrabBL.Delete(nTrab)
    End Sub

    Public Sub SaveTrabajador(nTrab As Business.Entity.Trabajador_PL) Implements ServiceContract.IContService.SaveTrabajador
        Dim TrabBL As New Trabajador_PLBL()
        TrabBL.Insert(nTrab)
    End Sub

    Public Sub UpdateTrabajador(nTrab As Business.Entity.Trabajador_PL) Implements ServiceContract.IContService.UpdateTrabajador
        Dim TrabBL As New Trabajador_PLBL()
        TrabBL.Update(nTrab)
    End Sub

    Public Function GetListaTrabPorEmpresa(strIDEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.Trabajador_PL) Implements ServiceContract.IContService.GetListaTrabPorEmpresa
        Dim TrabBL As New Trabajador_PLBL()
        Return TrabBL.ObtenerTrabPorEmpresa(strIDEmpresa)
    End Function

    Public Function GetListaTrabPorEstable(intIdEstable As Integer) As System.Collections.Generic.List(Of Business.Entity.Trabajador_PL) Implements ServiceContract.IContService.GetListaTrabPorEstable
        Dim TrabBL As New Trabajador_PLBL()
        Return TrabBL.ObtenerTrabPorEstable(intIdEstable)
    End Function

    Public Function GetUbicaTrab(strCodTrab As String, intEstable As Integer) As Business.Entity.Trabajador_PL Implements ServiceContract.IContService.GetUbicaTrab
        Dim TrabBL As New Trabajador_PLBL()
        Return TrabBL.ObtenerTrabPorDNI(strCodTrab, intEstable)
    End Function


#End Region

#Region "INSUMOS"

    Public Function DeleteInsumoSL(nInsumo As Business.Entity.item) As Boolean Implements ServiceContract.IContService.DeleteInsumoSL
        Dim InsumoBL As New itemBL()
        Return InsumoBL.DeleteSL(nInsumo)
    End Function

    Public Sub DeleteInsumo(nInsumo As Business.Entity.item) Implements ServiceContract.IContService.DeleteInsumo
        Dim InsumoBL As New itemBL()
        InsumoBL.Delete(nInsumo)
    End Sub


    Public Function InsertMultiplePresentacion(nInsumo As Business.Entity.item) As Integer Implements ServiceContract.IContService.InsertMultiplePresentacion
        Dim InsumoBL As New itemBL()
        Return InsumoBL.InsertMultiplePresentacion(nInsumo)
    End Function

    Public Function SaveInsumo(nInsumo As Business.Entity.item) As Integer Implements ServiceContract.IContService.SaveInsumo
        Dim InsumoBL As New itemBL()
        Return InsumoBL.Insert(nInsumo)
    End Function



    Public Function ReviewProductos(ProductoBE As detalleitems) As List(Of detalleitems) Implements IContService.ReviewProductos
        Dim InsumoBL As New detalleitemsBL()
        Return InsumoBL.ReviewProductos(ProductoBE)
    End Function

    Public Function SaveInsumoSL(nInsumo As Business.Entity.item) As item Implements ServiceContract.IContService.SaveInsumoSL
        Dim InsumoBL As New itemBL()
        Return InsumoBL.InsertSL(nInsumo)
    End Function

    Public Sub UpdateInsumo(nInsumo As Business.Entity.item) Implements ServiceContract.IContService.UpdateInsumo
        Dim InsumoBL As New itemBL()
        InsumoBL.Update(nInsumo)
    End Sub

    Public Sub InsumoSaveByGroup(lista As System.Collections.Generic.List(Of Business.Entity.item)) Implements ServiceContract.IContService.InsumoSaveByGroup
        Dim InsumoBL As New itemBL()
        InsumoBL.SavebyGroup(lista)
    End Sub

    Public Sub UpdateCategoriaFull(lista As System.Collections.Generic.List(Of Business.Entity.item)) Implements ServiceContract.IContService.UpdateCategoriaFull
        Dim InsumoBL As New itemBL()
        InsumoBL.UpdateCategoriaFull(lista)
    End Sub

    Public Sub GrabarProductosExcel(insumos As System.Collections.Generic.List(Of Business.Entity.item)) Implements ServiceContract.IContService.GrabarProductosExcel
        Dim InsumoBL As New itemBL()
        InsumoBL.GrabarProductosExcel(insumos)
    End Sub

    Public Function ListaClasificacion(intEstable As Integer) As System.Collections.Generic.List(Of Business.Entity.item) Implements ServiceContract.IContService.ListaClasificacion
        Dim InsumoBL As New itemBL()
        Return InsumoBL.GetListaInsumoPorEstable(intEstable)
    End Function

    Public Sub InsumoSaveByGroupExcel(lista As System.Collections.Generic.List(Of Business.Entity.item)) Implements ServiceContract.IContService.InsumoSaveByGroupExcel
        Dim InsumoBL As New itemBL()
        InsumoBL.SavebyGroupFormatoExcel(lista)
    End Sub



    Public Function GetListaItemID(strDescripcion As String) As String Implements ServiceContract.IContService.GetListaItemID
        Dim TablaBL As New itemBL()
        Return TablaBL.GetListaItemID(strDescripcion)
    End Function

    Public Function GetListaItemPorEstable(strEstable As Integer, strIdEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.item) Implements ServiceContract.IContService.GetListaItemPorEstable
        Dim TablaBL As New itemBL()
        Return TablaBL.GetListaItemPorEstable(strEstable, strIdEmpresa)
    End Function

    Public Function GetListaItemPorEstableLike(strEstable As Integer, strLike As String) As List(Of item) Implements IContService.GetListaItemPorEstableLike
        Dim TablaBL As New itemBL()
        Return TablaBL.GetListaItemPorEstableLike(strEstable, strLike)
    End Function

    Public Function InsertarItemClasificaion(nTabDet As Business.Entity.item) As Integer Implements ServiceContract.IContService.InsertarItemClasificaion
        Dim actividadBL As New itemBL
        Return actividadBL.InsertarItemClasificaion(nTabDet)
    End Function

    Public Function ObtenerItemsFull() As System.Collections.IList Implements ServiceContract.IContService.ObtenerItemsFull
        Dim tablaBL As New itemBL()
        Return tablaBL.ObtenerItemsFull()
    End Function

    Public Function GetUbicarItemID(intIdTablaDep As String) As Business.Entity.item Implements ServiceContract.IContService.GetUbicarItemID
        Dim tablaBL As New itemBL
        Return tablaBL.GetUbicarItemID(intIdTablaDep)
    End Function

    Public Function UbicarCategoriaPorID(intIdCategoria As Integer) As Business.Entity.item Implements ServiceContract.IContService.UbicarCategoriaPorID
        Dim tablaBL As New itemBL
        Return tablaBL.UbicarCategoriaPorID(intIdCategoria)
    End Function

    Public Function GetUbicaCategoriaItem_Utilidad(ByVal strIdEmpresa As String, ByVal intIdEstable As Integer, intIdItem As Integer) As Decimal Implements ServiceContract.IContService.GetUbicaCategoriaItem_Utilidad
        Dim tablaBL As New itemBL
        Return tablaBL.GetUbicaCategoriaItem_Utilidad(strIdEmpresa, intIdEstable, intIdItem)
    End Function

    Public Function GetListaItemPorEmpresa(strIdEmpresa As String, intIdEstablec As Integer) As System.Collections.Generic.List(Of Business.Entity.item) Implements ServiceContract.IContService.GetListaItemPorEmpresa
        Dim TablaBL As New itemBL()
        Return TablaBL.GetListaItemPorEmpresa(strIdEmpresa, intIdEstablec)
    End Function

#Region "PRODUCTO"
    Public Sub DeleteProductoAllReferences(ProductoBE As detalleitems) Implements IContService.DeleteProductoAllReferences
        Dim ProductoBL As New detalleitemsBL()
        ProductoBL.DeleteProductoAllReferences(ProductoBE)
    End Sub

    Public Sub SaveListaProducto(nListaProducto As System.Collections.Generic.List(Of Business.Entity.detalleitems)) Implements ServiceContract.IContService.SaveListaProducto
        Dim ProductoBL As New detalleitemsBL()
        ProductoBL.InsertLista(nListaProducto)
    End Sub

    Public Sub SaveProducto(nProducto As Business.Entity.detalleitems) Implements ServiceContract.IContService.SaveProducto
        Dim ProductoBL As New detalleitemsBL()
        ProductoBL.Insert(nProducto)
    End Sub

    Public Function InsertNuevaItems(nProducto As Business.Entity.detalleitems) As Integer Implements ServiceContract.IContService.InsertNuevaItems
        Dim ProductoBL As New detalleitemsBL()
        Return ProductoBL.InsertNuevaItems(nProducto)
    End Function

    Public Function InsertItemDualTabla(ProductoBE As detalleitems) As Integer Implements IContService.InsertItemDualTabla
        Dim ProductoBL As New detalleitemsBL()
        Return ProductoBL.InsertItemDualTabla(ProductoBE)
    End Function


    Public Sub UpdateProducto(nProducto As Business.Entity.detalleitems) Implements ServiceContract.IContService.UpdateProducto
        Dim ProductoBL As New detalleitemsBL()
        ProductoBL.Update(nProducto)
    End Sub

    Public Sub DeleteProducto(nProducto As Business.Entity.detalleitems) Implements ServiceContract.IContService.DeleteProducto
        Dim ProductoBL As New detalleitemsBL()
        ProductoBL.Delete(nProducto)
    End Sub

    Public Function GetUbicaProductoID(intIdProducto As Integer) As Business.Entity.detalleitems Implements ServiceContract.IContService.GetUbicaProductoID
        Dim ProductoBL As New detalleitemsBL()
        Return ProductoBL.GetUbicaProductoID(intIdProducto)
    End Function

    Public Function GetUbicaProductoNombre(strNomProducto As String, strIdEmpresa As String, intIdEstable As Integer) As Business.Entity.detalleitems Implements ServiceContract.IContService.GetUbicaProductoNombre
        Dim ProductoBL As New detalleitemsBL()
        Return ProductoBL.GetUbicaProductoNombre(strNomProducto, strIdEmpresa, intIdEstable)
    End Function

    Public Function GetProductoClasificado(intEstable As Integer, intClasificacion As Integer) As System.Collections.Generic.List(Of Business.Entity.detalleitems) Implements ServiceContract.IContService.GetProductoClasificado
        Dim ProductoBL As New detalleitemsBL()
        Return ProductoBL.GetListaProductoClasificado(intEstable, intClasificacion)
    End Function

    Public Function GetUbicarDetalleItemTipoExistencia(idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String) As System.Collections.Generic.List(Of Business.Entity.detalleitems) Implements ServiceContract.IContService.GetUbicarDetalleItemTipoExistencia
        Dim ProductoBL As New detalleitemsBL
        Return ProductoBL.GetUbicarDetalleItemTipoExistencia(idEmpresa, idEstablec, intIdCategoria, strTipoExistencia)
    End Function

    Public Function GetUbicarDetalleItems(strempresa As String, intestablec As Integer, strNombre As String) As Integer Implements ServiceContract.IContService.GetUbicarDetalleItems
        Dim ProductoBL As New detalleitemsBL()
        Return ProductoBL.GetUbicarDetalleItems(strempresa, intestablec, strNombre)
    End Function

    Public Function InsertDetalle(ByVal itemBE As detalleitems) As Integer Implements ServiceContract.IContService.InsertDetalle
        Dim ProductoBL As New detalleitemsBL()
        Return ProductoBL.InsertDetalle(itemBE)
    End Function

    Public Function GetUbicarProductoXNotificacion(ByVal idEmpresa As String, idEstablec As Integer, intIdItem As Integer) As detalleitems Implements ServiceContract.IContService.GetUbicarProductoXNotificacion
        Dim ProductoBL As New detalleitemsBL()
        Return ProductoBL.GetUbicarProductoXNotificacion(idEmpresa, idEstablec, intIdItem)
    End Function
#End Region
#End Region

#Region "TABLA GENERAL"
    Public Function GetListaTabla() As List(Of tabla) Implements IContService.GetListaTabla
        Dim TablaBL As New tablaBL()
        Return TablaBL.GetListaTabla()
    End Function

    Public Function GetListaTablaID(strDescripcion As String) As String Implements ServiceContract.IContService.GetListaTablaID
        Dim TablaBL As New tabladetalleBL()
        Return TablaBL.GetListaTablaID(strDescripcion)
    End Function


#End Region

#Region "ACTIVIDAD"
    Public Function GetListaInsumosPorProyecto(intIDProyecto As Integer, strTipoRecurso As String) As System.Collections.Generic.List(Of Business.Entity.actividadRecurso) Implements ServiceContract.IContService.GetListaInsumosPorProyecto
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetListaInsumosPorProyecto(intIDProyecto, strTipoRecurso)
    End Function

    Public Sub UpdateIdPadreActividad(nLista As System.Collections.Generic.List(Of Business.Entity.Actividades)) Implements ServiceContract.IContService.UpdateIdPadreActividad
        Dim actividadBL As New ActividadesBL()
        actividadBL.UpdateIdPadreActividad(nLista)
    End Sub

    Public Sub GrabarActividadEquipo(nLista As System.Collections.Generic.List(Of Business.Entity.Actividades), nProyecto As Business.Entity.ProyectoPlaneacion) Implements ServiceContract.IContService.GrabarActividadEquipo
        Dim actividadBL As New ActividadesBL()
        actividadBL.GrabarActividadEquipo(nLista, nProyecto)
    End Sub

    Public Function GetUbicarActividadPorModulo(intIdProyecto As Integer, strModulo As String) As System.Collections.Generic.List(Of Business.Entity.Actividades) Implements ServiceContract.IContService.GetUbicarActividadPorModulo
        Dim actividadBL As New ActividadesBL()
        Return actividadBL.GetUbicarActividadPorModulo(intIdProyecto, strModulo)
    End Function

    Public Function GetUbicarActividadPorModuloOcupa(intIdProyecto As Integer, strModulo As String) As System.Collections.Generic.List(Of Business.Entity.Actividades) Implements ServiceContract.IContService.GetUbicarActividadPorModuloOcupa
        Dim actividadBL As New ActividadesBL()
        Return actividadBL.GetUbicarActividadPorModuloOcupa(intIdProyecto, strModulo)
    End Function

    Public Sub ProyectoActividadGrabarTodo(nActividad As Business.Entity.Actividades) Implements ServiceContract.IContService.ProyectoActividadGrabarTodo
        Dim ActividadBL As New ActividadesBL()
        ActividadBL.ProyectoActividadGrabarTodo(nActividad)
    End Sub

    Public Function GetUbicarListaEDT(intIdProyecto As Integer, intIdPadre As Integer, strModulo As String) As List(Of Actividades) Implements ServiceContract.IContService.GetUbicarListaEDT
        Dim actividadBL As New ActividadesBL()
        Return actividadBL.GetUbicarListaEDT(intIdProyecto, strModulo)
    End Function

    Public Function UbicaProyectoActividad(intProyecto As Integer, strModulo As String) As Business.Entity.Actividades Implements ServiceContract.IContService.UbicaProyectoActividad
        Dim actividadBL As New ActividadesBL()
        Return actividadBL.GetUbicarProyectoActividad(intProyecto, strModulo)
    End Function

    Public Sub DeleteEDT(nActividad As Business.Entity.Actividades) Implements ServiceContract.IContService.DeleteEDT
        Dim actividadBL As New ActividadesBL
        actividadBL.Delete(nActividad)
    End Sub

    Public Sub EditarEDT(nActividad As Business.Entity.Actividades) Implements ServiceContract.IContService.EditarEDT
        Dim actividadBL As New ActividadesBL
        actividadBL.Update(nActividad)
    End Sub

    Public Function InsertarEDT(nActividad As Business.Entity.Actividades) As Integer Implements ServiceContract.IContService.InsertarEDT
        Dim actividadBL As New ActividadesBL
        Return actividadBL.Insert(nActividad)
    End Function

    Public Sub GrabarActividadListaEDT(ByVal intIDProyecto As Integer, ByVal intIDEstable As Integer, ByVal srtTipoPlan As String) Implements ServiceContract.IContService.GrabarActividadListaEDT
        Dim actividadBL As New ActividadesBL
        actividadBL.GrabarActividadListaEDT(intIDProyecto, intIDEstable, srtTipoPlan)
    End Sub

    Public Function UbicaEDT(intProyecto As Integer) As Business.Entity.Actividades Implements ServiceContract.IContService.UbicaEDT
        Dim actividadBL As New ActividadesBL()
        Return actividadBL.GetUbicarEDT(intProyecto)
    End Function

    Public Function GetUbicarMontoContractual(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) As List(Of Actividades) Implements ServiceContract.IContService.GetUbicarMontoContractual
        Dim actividadBL As New ActividadesBL()
        Return actividadBL.GetUbicarMontoContractual(intIDProyecto, strTipoRecurso, strFlag)
    End Function

    Public Function ListaEDT(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) As System.Collections.Generic.List(Of Business.Entity.Actividades) Implements ServiceContract.IContService.ListaEDT
        Dim actividadBL As New ActividadesBL()
        Return actividadBL.GetListaEDT(intIDProyecto, strTipoRecurso, strFlag)
    End Function

    Public Function GetListaActividadPorProyecto(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) As System.Collections.Generic.List(Of Business.Entity.Actividades) Implements ServiceContract.IContService.GetListaActividadPorProyecto
        Dim actividadBL As New ActividadesBL()
        Return actividadBL.GetListaActividadPorProyecto(intIDProyecto, strTipoRecurso, strFlag)
    End Function

    Public Function GetBusquedaActividadGeneralPorEstado(intIDProyecto As Integer, strTipoRecurso As String, strEstado As String, strFlag As String) As System.Collections.Generic.List(Of Business.Entity.Actividades) Implements ServiceContract.IContService.GetBusquedaActividadGeneralPorEstado
        Dim actividadBL As New ActividadesBL()
        Return actividadBL.GetBusquedaActividadGeneralPorEstado(intIDProyecto, strTipoRecurso, strEstado, strFlag)
    End Function
#End Region

#Region "RECURSO"
    Public Sub UpdateCotizacionFinal(nListaRecurso As System.Collections.Generic.List(Of Business.Entity.actividadRecurso)) Implements ServiceContract.IContService.UpdateCotizacionFinal
        Dim recursoBL As New actividadRecursoBL()
        recursoBL.UpdateCotizacionFinal(nListaRecurso)
    End Sub

    Public Sub InsertCotizacionFinal(nListaProducto As System.Collections.Generic.List(Of Business.Entity.actividadRecurso)) Implements ServiceContract.IContService.InsertCotizacionFinal
        Dim ProductoBL As New actividadRecursoBL()
        ProductoBL.InsertCotizacionFinal(nListaProducto)
    End Sub

    Public Function SaveRecursoCotizacion(nRecurso As Business.Entity.actividadRecurso, nLiquidacion As Business.Entity.totalesLiquidacion) As Integer Implements ServiceContract.IContService.SaveRecursoCotizacion
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.InsertSingleCotizacionLiquidacion(nRecurso, nLiquidacion)
    End Function

    Public Function ListaRecursosCotizacionGasto(intIDProyecto As Integer, strSustento As String, strTipoPlan As String) As System.Collections.Generic.List(Of Business.Entity.actividadRecurso) Implements ServiceContract.IContService.ListaRecursosCotizacionGasto
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetListaCotizacionAndGasto(intIDProyecto, strSustento, strTipoPlan)
    End Function

    Public Function GetConteoActividadRecursos(intIDProyecto As Integer) As Integer Implements ServiceContract.IContService.GetConteoActividadRecursos
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetConteoActividadRecursos(intIDProyecto)
    End Function

    Public Function ListaRecursosCotizacionGastoFinal(intIDProyecto As Integer, strTipoRecurso As String, strSustentado As String) As System.Collections.Generic.List(Of Business.Entity.actividadRecurso) Implements ServiceContract.IContService.ListaRecursosCotizacionGastoFinal
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetListaCotizacionAndGastoFinal(intIDProyecto, strTipoRecurso, strSustentado)
    End Function

    Public Function ListaRecursosGastosFinal(intIDProyecto As Integer, strTipoRecurso As String, strSustentado As String) As System.Collections.Generic.List(Of Business.Entity.actividadRecurso) Implements ServiceContract.IContService.ListaRecursosGastosFinal
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetListaGastosFinal(intIDProyecto, strTipoRecurso, strSustentado)
    End Function

    Public Function GetListaGastoPlaneacion(intIDProyecto As Integer, strTipoRecurso As String, intIDActividad As Integer) As System.Collections.Generic.List(Of Business.Entity.actividadRecurso) Implements ServiceContract.IContService.GetListaGastoPlaneacion
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetListaGastoPlaneacion(intIDProyecto, strTipoRecurso, intIDActividad)
    End Function

    Public Function GetListaGPlaneacionIngreso(intIDProyecto As Integer, strTipoRecurso As String, intIDActividad As Integer) As System.Collections.Generic.List(Of Business.Entity.actividadRecurso) Implements ServiceContract.IContService.GetListaGPlaneacionIngreso
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetListaGPlaneacionIngreso(intIDProyecto, strTipoRecurso, intIDActividad)
    End Function

    Public Function ListaRecursosGastoPreliminar(intIDProyecto As Integer, strTipoRecurso As String, strTipoPresupuesto As String, strTipoPlan As String) As System.Collections.Generic.List(Of Business.Entity.actividadRecurso) Implements ServiceContract.IContService.ListaRecursosGastoPreliminar
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetListaGastoPreliminar(intIDProyecto, strTipoRecurso, strTipoPresupuesto, strTipoPlan)
    End Function

    Public Function GetUbicaRecursoID(intIdRecurso As Integer) As Business.Entity.actividadRecurso Implements ServiceContract.IContService.GetUbicaRecursoID
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetUbicaActividadRecursoID(intIdRecurso)
    End Function

    Public Function GetUbicaCotizacionbRecursoID(intIdRecurso As Integer) As Business.Entity.actividadRecurso Implements ServiceContract.IContService.GetUbicaCotizacionbRecursoID
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.GetUbicaCotizacionActividadRecursoID(intIdRecurso)
    End Function

    Public Sub DeleteRecurso(nRecurso As Business.Entity.actividadRecurso) Implements ServiceContract.IContService.DeleteRecurso
        Dim recursoBL As New actividadRecursoBL()
        recursoBL.DeleteSingle(nRecurso)
    End Sub

    Public Function SaveRecursoIniciacion(nRecurso As Business.Entity.actividadRecurso, nLiquidacion As Business.Entity.totalesLiquidacion) As Integer Implements ServiceContract.IContService.SaveRecursoIniciacion
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.InsertSingleLiquidacionIniciacion(nRecurso, nLiquidacion)
    End Function

    Public Function SaveRecurso(nRecurso As Business.Entity.actividadRecurso, nLiquidacion As Business.Entity.totalesLiquidacion) As Integer Implements ServiceContract.IContService.SaveRecurso
        Dim recursoBL As New actividadRecursoBL()
        Return recursoBL.InsertSingleLiquidacion(nRecurso, nLiquidacion)
    End Function

    Public Sub UpdateRecursoCotizacion(nRecurso As Business.Entity.actividadRecurso, nRecursoDelete As Business.Entity.totalesLiquidacion, nLiquidacion As Business.Entity.totalesLiquidacion) Implements ServiceContract.IContService.UpdateRecursoCotizacion
        Dim recursoBL As New actividadRecursoBL()
        recursoBL.UpdateSingleCotizacionLiquidacion(nRecurso, nRecursoDelete, nLiquidacion)
    End Sub

    Public Sub UpdateRecursoIniciacion(nRecurso As Business.Entity.actividadRecurso, nRecursoDelete As Business.Entity.totalesLiquidacion, nLiquidacion As Business.Entity.totalesLiquidacion) Implements ServiceContract.IContService.UpdateRecursoIniciacion
        Dim recursoBL As New actividadRecursoBL()
        recursoBL.UpdateSingleLiquidacionInciacion(nRecurso, nRecursoDelete, nLiquidacion)
    End Sub

    Public Sub UpdateRecurso(nRecurso As Business.Entity.actividadRecurso, nRecursoDelete As Business.Entity.totalesLiquidacion, nLiquidacion As Business.Entity.totalesLiquidacion) Implements ServiceContract.IContService.UpdateRecurso
        Dim recursoBL As New actividadRecursoBL()
        recursoBL.UpdateSingleLiquidacion(nRecurso, nRecursoDelete, nLiquidacion)
    End Sub

#End Region

#Region "TABLA DETALLE"
    Public Function GetUbicarTablaID(intIdTabla As Integer, strCodigo As String) As Business.Entity.tabladetalle Implements ServiceContract.IContService.GetUbicarTablaID
        Dim tablaBL As New tabladetalleBL
        Return tablaBL.GetUbicarTablaID(intIdTabla, strCodigo)
    End Function

    Public Function GetListaTablaDetalle(intIdTabla As Integer, strEstado As String) As System.Collections.Generic.List(Of Business.Entity.tabladetalle) Implements ServiceContract.IContService.GetListaTablaDetalle
        Dim tablaBL As New tabladetalleBL
        Return tablaBL.GetListaTablaDetalle(intIdTabla, strEstado)
    End Function

    Public Function GetUbicarTablaNombre(strNombreTabla As String) As System.Collections.Generic.List(Of Business.Entity.tabladetalle) Implements ServiceContract.IContService.GetUbicarTablaNombre
        Dim tablaBL As New tabladetalleBL()
        Return tablaBL.GetUbicarTablaNombre(strNombreTabla)
    End Function

    Public Function InsertarTablaDetalle(nTabDet As Business.Entity.tabladetalle) As Integer Implements ServiceContract.IContService.InsertarTablaDetalle
        Dim actividadBL As New tabladetalleBL
        Return actividadBL.Insert(nTabDet)
    End Function

    Public Sub EditarTablaDetalle(nTabDet As Business.Entity.tabladetalle) Implements ServiceContract.IContService.EditarTablaDetalle
        Dim tabladetalleBL As New tabladetalleBL
        tabladetalleBL.Update(nTabDet)
    End Sub

    Public Sub DeleteTablaDetalle(nTabDet As Business.Entity.tabladetalle) Implements ServiceContract.IContService.DeleteTablaDetalle
        Dim tabladetalleBL As New tabladetalleBL
        tabladetalleBL.Delete(nTabDet)
    End Sub
#End Region




#Region "INGRESO SUNAT"

    Public Function GetUbicarIdPadre(intIdPadre As Integer) As System.Collections.Generic.List(Of Business.Entity.ingresoSunat) Implements ServiceContract.IContService.GetUbicarIdPadre
        Dim ingresosunatBL As New ingresoSunatBl()
        Return ingresosunatBL.GetUbicarTablaNombre(intIdPadre)
    End Function

    Public Function InsertarIngresoSunat(nCodSunat As Business.Entity.ingresoSunat) As Integer Implements ServiceContract.IContService.InsertarIngresoSunat
        Dim ingresosunatBL As New ingresoSunatBl
        Return ingresosunatBL.Insert(nCodSunat)
    End Function

    Public Sub EditarIngresoSunat(nCodSunatt As Business.Entity.ingresoSunat) Implements ServiceContract.IContService.EditarIngresoSunat
        Dim ingresosunatBL As New ingresoSunatBl
        ingresosunatBL.Update(nCodSunatt)
    End Sub

    Public Sub DeleteIngresoSunat(nCodSunat As Business.Entity.ingresoSunat) Implements ServiceContract.IContService.DeleteIngresoSunat
        Dim ingresosunatBL As New ingresoSunatBl
        ingresosunatBL.Delete(nCodSunat)
    End Sub

#End Region


#Region "OCUPACION"
    Public Function GetUbicarOcupacionPorID(intCodOcupacion As Integer) As Business.Entity.ocupacion Implements ServiceContract.IContService.GetUbicarOcupacionPorID
        Dim ocupacionBL As New ocupacionBL
        Return ocupacionBL.GetUbicarOcupacionPorID(intCodOcupacion)
    End Function

    Public Function GetUbicarOcupacionPorNombre(strNombre As String, intIdEstable As Integer) As Business.Entity.ocupacion Implements ServiceContract.IContService.GetUbicarOcupacionPorNombre
        Dim ocupacionBL As New ocupacionBL
        Return ocupacionBL.GetUbicarOcupacionPorNombre(strNombre, intIdEstable)
    End Function

    Public Function GetUbicarOcupacion(idEstable As Integer) As System.Collections.Generic.List(Of Business.Entity.ocupacion) Implements ServiceContract.IContService.GetUbicarOcupacion
        Dim ocupacionBL As New ocupacionBL()
        Return ocupacionBL.GetUbicarOcupacion(idEstable)
    End Function

    Public Function InsertarOcupacion(idEstable As Business.Entity.ocupacion) As Integer Implements ServiceContract.IContService.InsertarOcupacion
        Dim ocupacionBL As New ocupacionBL
        Return ocupacionBL.Insert(idEstable)
    End Function

    Public Sub EditarOcupacion(idEstable As Business.Entity.ocupacion) Implements ServiceContract.IContService.EditarOcupacion
        Dim ocupacionBL As New ocupacionBL
        ocupacionBL.Update(idEstable)
    End Sub

    Public Sub DeleteOcupacion(idEstable As Business.Entity.ocupacion) Implements ServiceContract.IContService.DeleteOcupacion
        Dim ocupacionBL As New ocupacionBL
        ocupacionBL.Delete(idEstable)
    End Sub

#End Region

    Public Function ObtenerTablaFull() As System.Collections.IList Implements ServiceContract.IContService.ObtenerTablaFull
        Dim tablaBL As New tabladetalleBL()
        Return tablaBL.ObtenerTablaFull()
    End Function

    Public Function ObtenerTablaMaximo() As Integer Implements ServiceContract.IContService.ObtenerTablaMaximo
        Dim tablaBL As New tabladetalleBL()
        Return tablaBL.ObtenerTablaMaximo()
    End Function

#Region "LIQUIDACION"
    Public Sub GetEliminarLiquidacion(nLiquidacion As Business.Entity.totalesLiquidacion) Implements ServiceContract.IContService.GetEliminarLiquidacion
        Dim LiquidacionBL As New totalesLiquidacionBL()
        LiquidacionBL.DeleteTotalLiquidacionSingle(nLiquidacion)
    End Sub

    Public Function GetListaLiquidacionPreliminar(intIdProyecto As Integer, strTipoPlan As String) As System.Collections.Generic.List(Of Business.Entity.totalesLiquidacion) Implements ServiceContract.IContService.GetListaLiquidacionPreliminar
        Dim LiquidacionBL As New totalesLiquidacionBL()
        Return LiquidacionBL.GetListaLiquidacionPreliminar(intIdProyecto, strTipoPlan)
    End Function

    Public Function GetUbicaLiquidacionID(nLiquidacion As Business.Entity.totalesLiquidacion) As Business.Entity.totalesLiquidacion Implements ServiceContract.IContService.GetUbicaLiquidacionID
        Dim LiquidacionBL As New totalesLiquidacionBL()
        Return LiquidacionBL.GetUbicaLiquidacionPorID(nLiquidacion)
    End Function
#End Region

#Region "PLAN CONTABLE"
    Public Function ListarCuentasPorPadre(strEmpresa As String, strCuentaPadre As String) As System.Collections.Generic.List(Of Business.Entity.cuentaplanContableEmpresa) Implements ServiceContract.IContService.ListarCuentasPorPadre
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.ListarCuentasPorPadre(strEmpresa, strCuentaPadre)
    End Function

    Public Function LoadCuentasGastos(strEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.cuentaplanContableEmpresa) Implements ServiceContract.IContService.LoadCuentasGastos
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.LoadCuentasGastos(strEmpresa)
    End Function

    Public Function LoadCuentasGastosPadre(strEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.cuentaplanContableEmpresa) Implements ServiceContract.IContService.LoadCuentasGastosPadre
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.LoadCuentasGastosPadre(strEmpresa)
    End Function

    Public Function LoadCuentasPagoHonorarios(strEmpresa As String) As List(Of cuentaplanContableEmpresa) Implements IContService.LoadCuentasPagoHonorarios
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.LoadCuentasPagoHonorarios(strEmpresa)
    End Function

    Public Function LoadCuentasServicios(strEmpresa As String) As List(Of cuentaplanContableEmpresa) Implements IContService.LoadCuentasServicios
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.LoadCuentasServicios(strEmpresa)
    End Function

    Public Function ObtenerCuentaPorID(strEmpresa As String, strCuenta As String) As Business.Entity.cuentaplanContableEmpresa Implements ServiceContract.IContService.ObtenerCuentaPorID
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.ObtenerCuentaPorID(strEmpresa, strCuenta)
    End Function

    Public Function ObtenerCuentasConf(strEmpresa As String, strCuenta As String) As System.Collections.Generic.List(Of Business.Entity.cuentaplanContableEmpresa) Implements ServiceContract.IContService.ObtenerCuentasConf
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.ObtenerCuentasConf(strEmpresa, strCuenta)
    End Function

    Public Sub GrabarCuenta(cuenta As cuentaplanContableEmpresa) Implements IContService.GrabarCuenta
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        cuentaBL.GrabarCuenta(cuenta)
    End Sub

    Public Sub EliminarCuenta(cuentaBE As cuentaplanContableEmpresa) Implements IContService.EliminarCuenta
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        cuentaBL.EliminarCuenta(cuentaBE)
    End Sub

    Public Sub EditarCuenta(cuentaBE As cuentaplanContableEmpresa) Implements IContService.EditarCuenta
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        cuentaBL.EditarCuenta(cuentaBE)
    End Sub

    Public Function ObtenerCuentasPorEmpresaEscalable(strIdEmpresa As String) As List(Of cuentaplanContableEmpresa) Implements IContService.ObtenerCuentasPorEmpresaEscalable
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.ObtenerCuentasPorEmpresaEscalable(strIdEmpresa)
    End Function

    Public Function ObtenerCuentasPorEmpresaEscalableV2(strIdEmpresa As String) As List(Of cuentaplanContableEmpresa) Implements IContService.ObtenerCuentasPorEmpresaEscalableV2
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.ObtenerCuentasPorEmpresaEscalableV2(strIdEmpresa)
    End Function

    Public Function ObtenerCuentasPorEmpresa(strEmpresa As String) As System.Collections.Generic.List(Of Business.Entity.cuentaplanContableEmpresa) Implements ServiceContract.IContService.ObtenerCuentasPorEmpresa
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.ObtenerCuentasPorEmpresa(strEmpresa)
    End Function
#End Region

#Region "PERSONA"
    Public Sub DeletePersona(nPersona As Business.Entity.Persona) Implements ServiceContract.IContService.DeletePersona
        Dim personaBL As New PersonaBL
        personaBL.Delete(nPersona)
    End Sub

    Public Function InsertPersona(nPersona As Business.Entity.Persona) As Persona Implements ServiceContract.IContService.InsertPersona
        Dim personaBL As New PersonaBL
        Return personaBL.Insert(nPersona)
    End Function

    Public Sub UpdatePersona(nPersona As Business.Entity.Persona) Implements ServiceContract.IContService.UpdatePersona
        Dim personaBL As New PersonaBL
        personaBL.Editar(nPersona)
    End Sub

    Public Function ObtenerPersonaNumDoc(strEmpresa As String, strNumDoc As String) As Business.Entity.Persona Implements ServiceContract.IContService.ObtenerPersonaNumDoc
        Dim personaBL As New PersonaBL
        Return personaBL.ObtenerPersonaNumDoc(strEmpresa, strNumDoc)
    End Function

    Public Function ObtenerPersonaPorNombres(strIDEmpresa As String, strNombres As String) As System.Collections.Generic.List(Of Business.Entity.Persona) Implements ServiceContract.IContService.ObtenerPersonaPorNombres
        Dim personaBL As New PersonaBL
        Return personaBL.ObtenerPersonaPorNombres(strIDEmpresa, strNombres)
    End Function

    Public Function ObtenerPersonaNumDocPorNivel(strIDEmpresa As String, strNumDoc As String, strNivel As String) As Persona Implements IContService.ObtenerPersonaNumDocPorNivel
        Dim personaBL As New PersonaBL
        Return personaBL.ObtenerPersonaNumDocPorNivel(strIDEmpresa, strNumDoc, strNivel)
    End Function
#End Region

    Public Function ObtenerTrabPorDNIExcel(strCodTrab As String, intEstable As Integer) As Integer Implements ServiceContract.IContService.ObtenerTrabPorDNIExcel
        Dim TrabajadorBL As New Trabajador_PLBL
        Return TrabajadorBL.ObtenerTrabPorDNIExcel(strCodTrab, intEstable)
    End Function

    Public Sub SaveListaRecurso(nProyecto As System.Collections.Generic.List(Of Business.Entity.actividadRecurso), ListaGastoBE As System.Collections.Generic.List(Of Business.Entity.actividadRecurso), ListaETD As System.Collections.Generic.List(Of Business.Entity.Actividades), nLiquidacion As System.Collections.Generic.List(Of Business.Entity.totalesLiquidacion)) Implements ServiceContract.IContService.SaveListaRecurso
        Dim recursoBL As New actividadRecursoBL()
        recursoBL.InsertSingleCotizacionLiquidacionExcel(nProyecto, ListaGastoBE, ListaETD, nLiquidacion)
    End Sub
#Region "PERIODO POR EMPRESA"
    Public Function GetListar_empresaPeriodo(empresaPeriodoBE As empresaPeriodo) As System.Collections.Generic.List(Of Business.Entity.empresaPeriodo) Implements ServiceContract.IContService.GetListar_empresaPeriodo
        Dim PeriodoBL As New empresaPeriodoBL()
        Return PeriodoBL.GetListar_empresaPeriodo(empresaPeriodoBE)
    End Function

    Public Function InsertarPeriodo(empresaPeriodoBE As Business.Entity.empresaPeriodo) As Integer Implements ServiceContract.IContService.InsertarPeriodo
        Dim PeriodoBL As New empresaPeriodoBL()
        Return PeriodoBL.Insert(empresaPeriodoBE)
    End Function
#End Region

#Region "MARTIN"
    Public Function GetListaProductosPorItems(intIdAlmacen As Integer, intitem As Integer) As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen) Implements ServiceContract.IContService.GetListaProductosPorItems
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListaProductosPorAlmacenItems(intIdAlmacen, intitem)
    End Function

    Public Function GetListaAlmacenDet(idEmpresa As String, idEstablecimiento As Integer) As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen) Implements ServiceContract.IContService.GetListaAlmacenDet
        Dim totalesalmacenBL As New totalesAlmacenBL
        Return totalesalmacenBL.GetListaAlmaceneDetalle(idEmpresa, idEstablecimiento)
    End Function

#End Region

    Public Function OntenerListadoProductoEstablec(strEmpresa As String, intIdEstablecimiento As Integer, idAlmacen As String, desde As Date, hasta As Date) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.OntenerListadoProductoEstablec
        Dim compraBL As New InventarioMovimientoBL
        Return compraBL.ObtenerConsultaKaredexProductos(strEmpresa, intIdEstablecimiento, idAlmacen, desde, hasta)
    End Function

    Public Function OntenerListadoProductoAlmacen(strEmpresa As String, intIdEstablecimiento As Integer, idAlmacen As String, strItem As String, desde As Date, hasta As Date) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.OntenerListadoProductoAlmacen
        Dim compraBL As New InventarioMovimientoBL
        Return compraBL.ObtenerConsultaKaredexFecha(strEmpresa, intIdEstablecimiento, idAlmacen, strItem, desde, hasta)
    End Function

    Public Function GetUbicarGuiaRemision(stremp As String, periodo As String) As System.Collections.Generic.List(Of Business.Entity.documentoguiaDetalle) Implements ServiceContract.IContService.GetUbicarGuiaRemision
        Dim documentoguiadetalleBL As New documentoguiaDetalleBL
        Return documentoguiadetalleBL.ConsultaDocumentoGuiaDetalle(stremp, periodo)
    End Function

    Public Function GetListaProdItems(strEmpresa As String, intIdEstablecimiento As Integer) As System.Collections.Generic.List(Of Business.Entity.item) Implements ServiceContract.IContService.GetListaProdItems
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListaItemsProd(strEmpresa, intIdEstablecimiento)
    End Function

    Public Sub UpdateTotalesAlmacen(ByVal listadoAlmacenBE As List(Of totalesAlmacen), ByVal objDocumento As Integer) Implements ServiceContract.IContService.UpdateTotalesAlmacen
        Dim almacenBL As New totalesAlmacenBL
        almacenBL.UpdateTotalesAlmacen(listadoAlmacenBE, objDocumento)
    End Sub

    Public Function UpdateTotalesAlmacen2(ByVal listadoAlmacenBE As List(Of totalesAlmacen), ByVal objDocumento As Integer) As Boolean Implements ServiceContract.IContService.UpdateTotalesAlmacen2
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.UpdateTotalesAlmacen2(listadoAlmacenBE, objDocumento)
    End Function

    Public Function ObtenerCajaOnlinePorDia(strIdEmpresa As String, intIdEstablecimiento As Integer, strEntidadFinanciera As String) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlinePorDia
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlinePorDia(strIdEmpresa, intIdEstablecimiento, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlinePorRango(strIdEmpresa As String, intIdEstablecimiento As Integer, strEntidadFinanciera As String, desde As Date, hasta As Date) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlinePorRango
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlinePorRango(strIdEmpresa, intIdEstablecimiento, strEntidadFinanciera, desde, hasta)
    End Function

    Public Sub SaveGroupCajaOtrosMovimientosME(objDocumentoBE As Business.Entity.documento) Implements ServiceContract.IContService.SaveGroupCajaOtrosMovimientosME
        Dim cajaBL As New documentoCajaBL
        cajaBL.SaveGroupCajaOtrosMovimientosME(objDocumentoBE)
    End Sub

    Public Function ObtenerCajaOnlineME(strIdEmpresa As String, intIdEstablecimiento As Integer, strMEs As String, strAnio As String, strEntidadFinanciera As String) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineME
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineME(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlineSaldosME(strIdEmpresa As String, intIdEstablecimiento As Integer, strMEs As String, strAnio As String, strEntidadFinanciera As String) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineSaldosME
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineSaldosME(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaDetallePorId(ByVal idDocumentoVenta As Integer) As documentoCaja Implements ServiceContract.IContService.ObtenerCajaDetallePorId
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaDetallePorId(idDocumentoVenta)
    End Function

    Public Function SaveGroupCajaME(objDocumentoBE As Business.Entity.documento, cajaUsuario As Business.Entity.cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer Implements ServiceContract.IContService.SaveGroupCajaME
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaME(objDocumentoBE, cajaUsuario, listaDetalle)
    End Function

    Public Function ConsultaCajaXEmpresa(strEmpresa As String) As documentoCajaDetalle Implements ServiceContract.IContService.ConsultaCajaXEmpresa
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ConsultaCajaXEmpresa(strEmpresa)
    End Function

    Public Function ConsultaMovimientoME(intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle) Implements ServiceContract.IContService.ConsultaMovimientoME
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ConsultaMovimientoME(intEntidadFinanciera)
    End Function

    Public Function SaveGroupCajaVentasME(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer Implements IContService.SaveGroupCajaVentasME
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaVentasME(objDocumentoBE, cajaUsuario)
    End Function

    Public Function SaveGroupCajaOtrosMovimientosSingleME(objDocumentoBE As Business.Entity.documento) As Integer Implements ServiceContract.IContService.SaveGroupCajaOtrosMovimientosSingleME
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaOtrosMovimientosSingleME(objDocumentoBE)
    End Function

    Public Function GetListarAportesPorMes(intIdEstablecimiento As Integer, ByVal strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarAportesPorMes
        Dim aporteBL As New documentocompraBL
        Return aporteBL.GetListarAportesPorMes(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarAportesPorDia(intIdEstablecimiento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarAportesPorDia
        Dim aporteBL As New documentocompraBL
        Return aporteBL.GetListarAportesPorDia(intIdEstablecimiento)
    End Function

    Public Function GetListarAportesPorRango(desde As Date, hasta As Date) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarAportesPorRango
        Dim aporteBL As New documentocompraBL
        Return aporteBL.GetListarAportesPorRango(desde, hasta)
    End Function

    Public Function ObtenerProdPorAlmacenesPorMes(idAlmacen As String, strItem As String, periodo As Integer, mes As String) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerProdPorAlmacenesPorMes
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerProdPorAlmacenesPorMes(idAlmacen, strItem, periodo, mes)
    End Function

    Public Function ObtenerProdPorAlmacenesPorMesAll(idAlmacen As String, periodo As Integer, mes As String) As List(Of InventarioMovimiento) Implements IContService.ObtenerProdPorAlmacenesPorMesAll
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerProdPorAlmacenesPorMesAll(idAlmacen, periodo, mes)
    End Function

    Public Function ObtenerProdPorAlmacenesPorAnio(idAlmacen As String, strItem As String, Anio As Integer) As List(Of InventarioMovimiento) Implements IContService.ObtenerProdPorAlmacenesPorAnio
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerProdPorAlmacenesPorAnio(idAlmacen, strItem, Anio)
    End Function

    Public Function ObtenerProdPorAlmacenesPorAnioAll(ByVal idAlmacen As String, ByVal Anio As Integer) As List(Of InventarioMovimiento) Implements IContService.ObtenerProdPorAlmacenesPorAnioAll
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerProdPorAlmacenesPorAnioAll(idAlmacen, Anio)
    End Function

    Public Function ObtenerProdPorAlmacenesPorRango(idAlmacen As String, strItem As String, desde As Date, hasta As Date) As System.Collections.Generic.List(Of Business.Entity.InventarioMovimiento) Implements ServiceContract.IContService.ObtenerProdPorAlmacenesPorRango
        Dim almacenBL As New InventarioMovimientoBL
        Return almacenBL.ObtenerProdPorAlmacenesPorRango(idAlmacen, strItem, desde, hasta)
    End Function



    Public Function GetListarComprasPorMes_CONT(año As Integer, mes As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasPorMes_CONT
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorMes_CONT(año, mes)
    End Function

    Public Function GetListarComprasPorRango_CONT(desde As Date, hasta As Date) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarComprasPorRango_CONT
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorRango_CONT(desde, hasta)
    End Function

    Public Function GrabarOrdenesServicio(objDocumento As documento, objOtroDoc As documentoOtrosDatos) As Integer Implements IContService.GrabarOrdenesServicio
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GrabarOrdenesServicio(objDocumento, objOtroDoc)
    End Function

    Public Function GetListarOrdenCompraNoAprobadoSL(intIdEmpresa As String, ByVal intidEstablecimiento As Integer, ByVal EstadoOrden As String, ByVal strTipoSituacion As String) As System.Collections.Generic.List(Of Business.Entity.documentocompra) Implements ServiceContract.IContService.GetListarOrdenCompraNoAprobadoSL
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarOrdenCompraNoAprobadoSL(intIdEmpresa, intidEstablecimiento, EstadoOrden, strTipoSituacion)
    End Function

    Public Function GetListarComprasPorPeriodoGeneralTransferenciaSC(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra) Implements IContService.GetListarComprasPorPeriodoGeneralTransferenciaSC
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarComprasPorPeriodoGeneralTransferenciaSC(intIdEstablecimiento, strPeriodo, UsuarioCaja)
    End Function

    Public Function ListaGuiasPorCompraSinNumeracion(intIdEstablecimiento As Integer, srtPeriodo As String, strIdEmpresarial As String) As List(Of Business.Entity.documentoGuia) Implements ServiceContract.IContService.ListaGuiasPorCompraSinNumeracion
        Dim documentoBL As New documentoGuiaBL
        Return documentoBL.ListaGuiasPorCompraSinNumeracion(intIdEstablecimiento, srtPeriodo, strIdEmpresarial)
    End Function

#Region "MARCARA CONTABLE EXISTENCIA"
    Public Function InsertMascaraContableExistenciaSingle(ByVal mascaraContableExistenciaBE As mascaraContableExistencia) As String Implements ServiceContract.IContService.InsertMascaraContableExistenciaSingle
        Dim InsertMascaraCE As New mascaraContableExistenciaBL
        Return InsertMascaraCE.InsertMascaraContableExistenciaSingle(mascaraContableExistenciaBE)
    End Function

    Public Function UpdateMascaraContableExistenciaSingle(ByVal mascaraContableExistenciaBE As mascaraContableExistencia) As String Implements ServiceContract.IContService.UpdateMascaraContableExistenciaSingle
        Dim InsertMascaraCE As New mascaraContableExistenciaBL
        Return InsertMascaraCE.UpdateMascaraContableExistenciaSingle(mascaraContableExistenciaBE)
    End Function
#End Region

#Region "SALDOS DE INICIO"
    Public Function SaldosXpagarXproveedor(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, intIdProveedor As Integer) As List(Of saldoInicio) Implements IContService.SaldosXpagarXproveedor
        Dim EstadoBL As New saldoInicialBL
        Return EstadoBL.SaldosXpagarXproveedor(strEmpresa, intIdEstablecimiento, strPeriodo, intIdProveedor)
    End Function

    Public Function UbicarSaldoXidDocumento(intIdDocumento As Integer) As saldoInicio Implements IContService.UbicarSaldoXidDocumento
        Dim EstadoBL As New saldoInicialBL
        Return EstadoBL.UbicarSaldoXidDocumento(intIdDocumento)
    End Function

    Public Function ListadoDetalleSaldoXidDocumento(intIdDocumento As Integer) As List(Of saldoInicioDetalle) Implements IContService.ListadoDetalleSaldoXidDocumento
        Dim EstadoBL As New saldoInicioDetalleBL
        Return EstadoBL.ListadoDetalleSaldoXidDocumento(intIdDocumento)
    End Function

    Public Function ListadoMercaderiaXidDocumento(intIdDocumento As Integer) As List(Of saldoInicioDetalle) Implements IContService.ListadoMercaderiaXidDocumento
        Dim EstadoBL As New saldoInicioDetalleBL
        Return EstadoBL.ListadoMercaderiaXidDocumento(intIdDocumento)
    End Function

    Public Function ObtenerEstadosFinancierosPorMonedaXdescripcion(intIdEstablecimiento As Integer, strTipo As String, strBusqueda As String) As System.Collections.Generic.List(Of Business.Entity.estadosFinancieros) Implements ServiceContract.IContService.ObtenerEstadosFinancierosPorMonedaXdescripcion
        Dim EstadoBL As New estadosFinancierosBL
        Return EstadoBL.ObtenerEstadosFinancierosPorMonedaXdescripcion(intIdEstablecimiento, strTipo, strBusqueda)
    End Function

    Public Sub DeleteSaldoAporte(documentoBE As documento, ListaItemsAeliminar As List(Of totalesAlmacen)) Implements IContService.DeleteSaldoAporte
        Dim EstadoBL As New saldoInicialBL
        EstadoBL.EliminarSaldoAporte(documentoBE, ListaItemsAeliminar)
    End Sub

    Public Function ListadoSaldosXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As System.Collections.Generic.List(Of Business.Entity.saldoInicio) Implements ServiceContract.IContService.ListadoSaldosXperiodo
        Dim documentoBL As New saldoInicialBL
        Return documentoBL.ListadoSaldosXperiodo(strEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function InsertarAporteInicio(documentoBE As Business.Entity.documento, listaProductosAlmacen As System.Collections.Generic.List(Of Business.Entity.totalesAlmacen)) As Integer Implements ServiceContract.IContService.InsertarAporteInicio
        Dim documentoBL As New saldoInicialBL
        Return documentoBL.InsertarAporteInicio(documentoBE, listaProductosAlmacen)
    End Function

    Public Function GetUbicarProductoXdescripcion(idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String, strBusqueda As String) As System.Collections.Generic.List(Of Business.Entity.detalleitems) Implements ServiceContract.IContService.GetUbicarProductoXdescripcion
        Dim documentoBL As New detalleitemsBL
        Return documentoBL.GetUbicarProductoXdescripcion(idEmpresa, idEstablec, intIdCategoria, strTipoExistencia, strBusqueda)
    End Function

    Public Function GetUbicarProductoXdescripcion2(idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String, strBusqueda As String) As List(Of detalleitems) Implements IContService.GetUbicarProductoXdescripcion2
        Dim productoBL As New detalleitemsBL
        Return productoBL.GetUbicarProductoXdescripcion2(idEmpresa, idEstablec, intIdCategoria, strTipoExistencia, strBusqueda)
    End Function

    Public Function InsertarSaldos(documentoBE As Business.Entity.documento) As Integer Implements ServiceContract.IContService.InsertarSaldos
        Dim documentoBL As New saldoInicialBL
        Return documentoBL.InsertarSaldos(documentoBE)
    End Function

    Public Function BuscarEntidadXdescripcion(strEmpresa As String, strTipoEntidad As String, strBusqueda As String) As List(Of entidad) Implements ServiceContract.IContService.BuscarEntidadXdescripcion
        Dim documentoBL As New entidadBL
        Return documentoBL.BuscarEntidadXdescripcion(strEmpresa, strTipoEntidad, strBusqueda)
    End Function

    Public Function ObtenerPersonaNumDocPorNivelxDescripcion(strIDEmpresa As String, strNivel As String, strbusqueda As String) As List(Of Persona) Implements IContService.ObtenerPersonaNumDocPorNivelxDescripcion
        Dim documentoBL As New PersonaBL
        Return documentoBL.ObtenerPersonaNumDocPorNivelxDescripcion(strIDEmpresa, strNivel, strbusqueda)
    End Function
#End Region

    Public Function GetUbicar_documentocompradetallePorCompraSL(strSerie As String, strNroDoc As String, strSitucion As String, intIdProveedor As Integer) As List(Of documentocompradetalle) Implements IContService.GetUbicar_documentocompradetallePorCompraSL
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.GetUbicar_documentocompradetallePorCompraSL(strSerie, strNroDoc, strSitucion, intIdProveedor)
    End Function


    Public Function Ping() As Boolean Implements JNetFx.Framework.Data.WCFService.IServiceBase.Ping
        Return True
    End Function

    Public Sub UpdateVentaNormalContado(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento) Implements IContService.UpdateVentaNormalContado

    End Sub

    Public Function ObtenerEstadosFinancierosPorTipo1(intIdEstablecimiento As Integer, strTipo As String, strBusqueda As String) As List(Of estadosFinancieros) Implements IContService.ObtenerEstadosFinancierosPorTipo1
        Dim EstadoBL As New estadosFinancierosBL
        Return EstadoBL.ObtenerEstadosFinancierosTipo(intIdEstablecimiento, strTipo, strBusqueda)
    End Function

    Public Function ListaDeCajasPorCerrar(be As documentoCaja) As List(Of documentoCaja) Implements IContService.ListaDeCajasPorCerrar
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ListaDeCajasPorCerrar2(be)
    End Function


    Public Function GetProductoPorAlmacenItem(intIdAlmacen As Integer, strTipoEx As String, iditem As Integer) As List(Of totalesAlmacen) Implements IContService.GetProductoPorAlmacenItem
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetProductoPorAlmacenItem(intIdAlmacen, strTipoEx, iditem)
    End Function

    Public Function UbicarEntidadPorId(strEmpresa As String, strTipoEntidad As String, idEntidad As Integer) As entidad Implements IContService.UbicarEntidadPorId
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.UbicarEntidadPorIdEntidad(strEmpresa, strTipoEntidad, idEntidad)
    End Function

    Public Function RptPagosPrestamoFecha(fechaini As Date, fechafin As Date) As List(Of documentoCaja) Implements IContService.RptPagosPrestamoFecha
        Dim prestamoBL As New documentoCajaBL
        Return prestamoBL.ListadoPagosPrestamo(fechaini, fechafin)
    End Function

    Public Function RptPrestamosOtorgados(idBenef As Integer) As List(Of prestamos) Implements IContService.RptPrestamosOtorgados
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.ListadoPrestamoOtorgados(idBenef)
    End Function

    Public Function ObtenerPrestamosPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle) Implements IContService.ObtenerPrestamosPorCobrarPorDetails
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerPrestamosPorCobrarPorDetails(strDocumentoAfectado)
    End Function

    Public Function ObtenerPrestamosEmitidosXperiodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strTipoPrestamo As String) As List(Of prestamos) Implements IContService.ObtenerPrestamosEmitidosXperiodo
        Dim cajaBL As New prestamosBL
        Return cajaBL.ObtenerPrestamosEmitidosXperiodo(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoPrestamo)
    End Function

    Public Function ObtenerPrestamosEmitidos(strIdEmpresa As String, strEstado As String, strTipoPrestamo As String) As List(Of prestamos) Implements IContService.ObtenerPrestamosEmitidos
        Dim cajaBL As New prestamosBL
        Return cajaBL.ObtenerPrestamosEmitidos(strIdEmpresa, strEstado, strTipoPrestamo)
    End Function

    Public Sub ActualizarFechaPrestamo(documentoBE As prestamos, listaDocumentos As List(Of documentoPrestamos)) Implements IContService.ActualizarFechaPrestamo
        Dim prestamoBL As New documentoPrestamosBL
        prestamoBL.UpdateFechaDesembolso(documentoBE, listaDocumentos)
    End Sub

    Public Function SaveDesembolso(objDocumentoBE As documento, documentoBE As prestamos, listaDocumentos As List(Of documentoPrestamos)) As Integer Implements IContService.SaveDesembolso
        Dim cajaBL As New prestamosBL
        Return cajaBL.SaveDesembolso(objDocumentoBE, documentoBE, listaDocumentos)
    End Function

    Public Function RptPrestamosMayorMenor(inicio As Decimal, fin As Decimal) As List(Of prestamos) Implements IContService.RptPrestamosMayorMenor
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.PrestamosMayoresMenores(inicio, fin)
    End Function

    Public Function ListadoFechasCuotas(idDoc As Integer) As List(Of documentoPrestamos) Implements IContService.ListadoFechasCuotas
        Dim prestamoBL As New documentoPrestamosBL
        Return prestamoBL.ListadoFechasCuotas(idDoc)
    End Function

    Public Sub EliminarItemCronograma(be As Cronograma) Implements IContService.EliminarItemCronograma

    End Sub

    Public Function GetListadoPagosPorUsuario(be As Cronograma) As List(Of Cronograma) Implements IContService.GetListadoPagosPorUsuario
        Return Nothing
    End Function

    Public Sub GrabarRecepcionDePagos(be As List(Of Cronograma)) Implements IContService.GrabarRecepcionDePagos

    End Sub

    Public Function ObtenerCostosPorSubTipo(recursoBE As recursoCosto) As List(Of recursoCosto) Implements IContService.ObtenerCostosPorSubTipo
        Return Nothing
    End Function

    Public Function ObtenerCostosPorSubTipoPorStatus(recursoBE As recursoCosto, Optional listaStatus As List(Of String) = Nothing) As List(Of recursoCosto) Implements IContService.ObtenerCostosPorSubTipoPorStatus
        Return Nothing
    End Function

    Public Function ObtenerCostosPorTipo(recursoBE As recursoCosto) As List(Of recursoCosto) Implements IContService.ObtenerCostosPorTipo
        Return Nothing
    End Function

    Public Function SumatoriaXcosto(recursoBE As recursoCosto) As documentocompradetalle Implements IContService.SumatoriaXcosto
        Return Nothing
    End Function

    Public Sub EditarCosto(be As recursoCosto) Implements IContService.EditarCosto
        Dim costoBL As New recursoCostoBL
        costoBL.EditarCosto(be)
    End Sub

    Public Sub EliminarCosto(be As recursoCosto) Implements IContService.EliminarCosto
        Dim costoBL As New recursoCostoBL
        costoBL.EliminarCosto(be)
    End Sub

    Public Function GetCostoById(be As recursoCosto) As recursoCosto Implements IContService.GetCostoById
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetCostoById(be)
    End Function

    Public Function GetListaRecursosXtipo(recurso As recursoCosto) As List(Of recursoCosto) Implements IContService.GetListaRecursosXtipo
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetListaRecursosXtipo(recurso)
    End Function

    Public Sub GrabarCosto(be As recursoCosto, plan As List(Of cuentaplanContableEmpresa), listaProcesos As List(Of recursoCosto)) Implements IContService.GrabarCosto
        Dim costoBL As New recursoCostoBL
        costoBL.GrabarCosto(be, plan, listaProcesos)
    End Sub

    Public Sub GrabarCostoOne(be As recursoCosto) Implements IContService.GrabarCostoOne
        Dim costoBL As New recursoCostoBL
        costoBL.GrabarCostoProceso(be)
    End Sub

    Public Function SaveIngresoDesembolso(objDocumentoBE As documento, documentoBE As prestamos) As Integer Implements IContService.SaveIngresoDesembolso
        Dim cajaBL As New prestamosBL
        Return cajaBL.SaveIngresoDesembolso(objDocumentoBE, documentoBE)
    End Function

    Public Function GetCuentasAperturaEmpresa(be As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetCuentasAperturaEmpresa
        Dim libroBL As New documentoLibroDiarioBL
        Return libroBL.GetCuentasAperturaEmpresa(be)
    End Function

    Public Function GetKardexByPerido(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetKardexByPerido
        Dim inventarioBL As New InventarioMovimientoBL
        Return inventarioBL.GetKardexByPerido(be)
    End Function

    Public Function GetExistenciasByEstablecimiento(intEstable As Integer) As List(Of detalleitems) Implements IContService.GetExistenciasByEstablecimiento
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetExistenciasByEstablecimiento(intEstable)
    End Function

    Public Function GetExistenciasByEstablecimientoEspecial(intEstable As Integer) As List(Of detalleitems) Implements IContService.GetExistenciasByEstablecimientoEspecial
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetExistenciasByEstablecimientoEspecial(intEstable)
    End Function

    Public Function GetKardexPeridoByExistencia(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetKardexPeridoByExistencia
        Dim itemBL As New InventarioMovimientoBL
        Return itemBL.GetKardexPeridoByExistencia(be)
    End Function

    Public Function GetStockAlmacenesBytem(be As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetStockAlmacenesBytem
        Dim totalesBL As New totalesAlmacenBL
        Return totalesBL.GetStockAlmacenesBytem(be)
    End Function

    Public Function ObtenerCuentasPorPagarBySecuencia(strItemAfectado As Integer) As documentoCajaDetalle Implements IContService.ObtenerCuentasPorPagarBySecuencia
        Dim compraBL As New documentoCajaDetalleBL
        Return compraBL.ObtenerCuentasPorPagarBySecuencia(strItemAfectado)
    End Function

    Public Function GrabarCotizacion(objDocumento As documento) As Integer Implements IContService.GrabarCotizacion
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarCotizacion(objDocumento)
    End Function

    Public Function SaveVentaCobrada(objDocumento As documento) As Integer Implements IContService.SaveVentaCobrada
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.SaveVentaCobrada(objDocumento)
    End Function

    Public Function ObtenerCuentasPorPagarAnticipoDetails(strDocumentoAfectado As Integer) As List(Of documentoAnticipoDetalle) Implements IContService.ObtenerCuentasPorPagarAnticipoDetails
        Dim cajaBL As New documentoAnticipoDetalleBL
        Return cajaBL.ObtenerPagosAnticiposDetails(strDocumentoAfectado)
    End Function

    Public Function UbicarCompraPorProveedorXperiodoAnt(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra) Implements IContService.UbicarCompraPorProveedorXperiodoAnt
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarCompraPorProveedorXperiodoAnt(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function UbicarPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipo As String) As List(Of documentocompra) Implements IContService.UbicarPorProveedorXperiodo
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, tipo)
    End Function

    Public Function UbicarCompraPorProveedorXperiodoAntFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentocompra) Implements IContService.UbicarCompraPorProveedorXperiodoAntFull
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarCompraPorProveedorXperiodoAntFull(strEmpresa, intIdEstablecimiento, strPeriodo, tipo)
    End Function

    Public Function ListaTotalXCompra(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentocompra) Implements IContService.ListaTotalXCompra
        Dim documentoBL As New documentocompraBL
        Return documentoBL.ListaTotalXCompra(listaidPersona, fechaInicio, fechaFin, periodo, tipo)
    End Function


    Public Function ListaTotalXCompraAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentocompra Implements IContService.ListaTotalXCompraAll
        Dim documentoBL As New documentocompraBL
        Return documentoBL.ListaTotalXCompraAll(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio, intMes, intDia)
    End Function

    Public Function ListaCompraAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As documentocompra Implements IContService.ListaCompraAll
        Dim documentoBL As New documentocompraBL
        Return documentoBL.ListaCompraAll(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio)
    End Function

    Public Function GetListarComprasTransitoInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra) Implements IContService.GetListarComprasTransitoInfGeneral
        Dim documentoventaBL As New documentocompraBL
        Return documentoventaBL.GetListarComprasTransitoInfGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function

    Public Function GetListarTransferenciaInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra) Implements IContService.GetListarTransferenciaInfGeneral
        Dim documentoventaBL As New documentocompraBL
        Return documentoventaBL.GetListarTransferenciaInfGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function


    Public Function GetListarComprasTransitoInfGeneralRecepcion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra) Implements IContService.GetListarComprasTransitoInfGeneralRecepcion
        Dim documentoventaBL As New documentocompraBL
        Return documentoventaBL.GetListarComprasTransitoInfGeneralRecepcion(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function


    Public Function GetListarComprasPorPeriodoGeneralInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra) Implements IContService.GetListarComprasPorPeriodoGeneralInfGeneral
        Dim documentoventaBL As New documentocompraBL
        Return documentoventaBL.GetListarComprasPorPeriodoGeneralInfGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function

    Public Function ListaTotalXCompraTransito(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentocompra) Implements IContService.ListaTotalXCompraTransito
        Dim documentoBL As New documentocompraBL
        Return documentoBL.ListaTotalXCompraTransito(listaidPersona, fechaInicio, fechaFin, periodo, tipo)
    End Function

    Public Function ObtenerAnticiposMontoActual(idproveedor As Integer, tipo As String) As List(Of documentoAnticipo) Implements IContService.ObtenerAnticiposMontoActual
        Dim documentoBL As New documentoAnticipoBL
        Return documentoBL.ObtenerAnticiposMontoActual(idproveedor, tipo)
    End Function

    Public Function SaveGroupAnticipo(objDocumentoBE As documento) As Integer Implements IContService.SaveGroupAnticipo
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupAnticipoME(objDocumentoBE)
    End Function

    Public Function ListadoComprobanteAnticipo(iNtPadre As Integer) As List(Of documentoAnticipo) Implements IContService.ListadoComprobanteAnticipo
        Dim DocumentoCajaBL As New documentoAnticipoBL
        Return DocumentoCajaBL.ListadoComprobateAnticipoXidPadre(iNtPadre)
    End Function

    Public Function ListadoAnticiposDetalleHijos(intIdDocumento As Integer) As List(Of documentoAnticipoDetalle) Implements IContService.ListadoAnticiposDetalleHijos
        Dim DocumentoCajaBL As New documentoAnticipoDetalleBL
        Return DocumentoCajaBL.ListadoAnticiposDetalleHijos(intIdDocumento)
    End Function

    Public Sub ElimiNarCobroAnticipoVenta(documentoBE As documento) Implements IContService.ElimiNarCobroAnticipoVenta
        Dim DocumentoCajaBL As New documentoBL
        DocumentoCajaBL.ElimiNarCobroAnticipoVenta(documentoBE)
    End Sub

    Public Sub ElimiNarPagoAnticipoCompra(documentoBE As documento) Implements IContService.ElimiNarPagoAnticipoCompra
        Dim DocumentoCajaBL As New documentoBL
        DocumentoCajaBL.ElimiNarPagoAnticipoCompra(documentoBE)
    End Sub

    Public Function getTableAnticiposTipoPersonal(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String, idproveedor As Integer) As List(Of documentoAnticipo) Implements IContService.getTableAnticiposTipoPersonal
        Dim documentoventaBL As New documentoAnticipoBL
        Return documentoventaBL.getTableAnticiposPorTipoProveedor(strIdEmpresa, intIdEstablecimiento, strPeriodo, tipo, idproveedor)
    End Function

    Public Function ListadoAnticiposDetalle(idAnticipo As String) As List(Of documentoAnticipoDetalle) Implements IContService.ListadoAnticiposDetalle
        Dim DocumentoCajaBL As New documentoCajaDetalleBL
        Return DocumentoCajaBL.ListadoAnticiposDetalle(idAnticipo)
    End Function

    Public Function ObtenerSaldoAnticipo(idanticipo As Integer) As documentoAnticipo Implements IContService.ObtenerSaldoAnticipo
        Dim documentoBL As New documentoAnticipoBL
        Return documentoBL.ObtenerSaldoAnticipo(idanticipo)
    End Function

    Public Function SaveAnticipoDevolucion(objDocumento As documento, objDocumentoCaja As documento) As Integer Implements IContService.SaveAnticipoDevolucion
        Dim documentoBL As New documentoAnticipoBL
        Return documentoBL.SaveDevolucionAnticipo(objDocumento, objDocumentoCaja)
    End Function

    Public Function GetAlertaIventarioMinimo(be As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetAlertaIventarioMinimo
        Dim totalBL As New totalesAlmacenBL
        Return totalBL.GetAlertaIventarioMinimo(be)
    End Function

    Public Function GetAlertaIventarioMinimoConteo(be As totalesAlmacen) As Integer Implements IContService.GetAlertaIventarioMinimoConteo
        Dim totalBL As New totalesAlmacenBL
        Return totalBL.GetAlertaIventarioMinimoConteo(be)
    End Function

    Public Function GetRentabilidadPorPeriodo(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet) Implements IContService.GetRentabilidadPorPeriodo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetRentabilidadPorPeriodo(be)
    End Function

    Public Function GetRentabilidadPorDia(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet) Implements IContService.GetRentabilidadPorDia
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetRentabilidadPorDia(be)
    End Function

    Public Function GetExistenciaByCodeBar(intCodigoBar As String) As detalleitems Implements IContService.GetExistenciaByCodeBar
        Dim existenciaBL As New detalleitemsBL
        Return existenciaBL.GetExistenciaByCodeBar(intCodigoBar)
    End Function

    Public Function GetResporteItemsByProyecto(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetResporteItemsByProyecto
        Dim recursoBL As New recursoCostoBL
        Return recursoBL.GetResporteItemsByProyecto(be)
    End Function

    Public Function GetResporteItemsByGastos(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetResporteItemsByGastos
        Dim recursoBL As New recursoCostoBL
        Return recursoBL.GetResporteItemsByGastos(be)
    End Function

    Public Function GetConteoPedidos(intIdEstablec As Integer, strPeriodo As String) As Integer Implements IContService.GetConteoPedidos
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetConteoPedidos(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListar_tipoCambioByPeriodo(idempresa As String, mes As Integer, anio As Integer, intIdEstablecimiento As Integer) As List(Of tipoCambio) Implements IContService.GetListar_tipoCambioByPeriodo
        Dim cambioBL As New tipoCambioBL
        Return cambioBL.GetListar_tipoCambioByPeriodo(idempresa, mes, anio, intIdEstablecimiento)
    End Function

    Public Sub DeleteTC(tipoCambioBE As tipoCambio) Implements IContService.DeleteTC
        Dim cambioBL As New tipoCambioBL
        cambioBL.DeleteTC(tipoCambioBE)
    End Sub

    Public Function GetPreciosItems() As List(Of configuracionPrecioProducto) Implements IContService.GetPreciosItems
        Dim precioBL As New ConfiguracionPrecioProductoBL
        Return precioBL.GetPreciosItems()
    End Function

    Public Function GetListaProductosByEstablecimiento(IntIdEstablecimiento As Integer) As List(Of totalesAlmacen) Implements IContService.GetListaProductosByEstablecimiento
        Dim totalBL As New totalesAlmacenBL
        Return totalBL.GetListaProductosByEstablecimiento(IntIdEstablecimiento)
    End Function

    Public Function GetReporteMovAlmcenByEntradaSalida(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra) Implements IContService.GetReporteMovAlmcenByEntradaSalida
        Dim almacenBL As New documentocompraBL
        Return almacenBL.GetReporteMovAlmcenByEntradaSalida(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetReporteTransferenciaAlmacen(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra) Implements IContService.GetReporteTransferenciaAlmacen
        Dim almacenBL As New documentocompraBL
        Return almacenBL.GetReporteTransferenciaAlmacen(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetReporteListaGeneralPrecios() As List(Of configuracionPrecioProducto) Implements IContService.GetReporteListaGeneralPrecios
        Dim precioBL As New ConfiguracionPrecioProductoBL
        Return precioBL.GetReporteListaGeneralPrecios()
    End Function

    Public Function GetMovimientoXusuarioInfo(intUsuario As Integer, fechaActual As Date) As List(Of documentoCaja) Implements IContService.GetMovimientoXusuarioInfo
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientoXusuarioInfo(intUsuario, fechaActual)
    End Function

    Public Function UbicarDocCajaXIdEntidadOrigen(intEntidadFinan As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer Implements IContService.UbicarDocCajaXIdEntidadOrigen
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.UbicarDocCajaXIdEntidadOrigen(intEntidadFinan, intEstablecimiento, strEmpresa)
    End Function

    Public Function ObtenerMovimientosPorPeriodoFinanzasXiDCaja(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, idCaja As Integer) As List(Of documentoCaja) Implements ServiceContract.IContService.ObtenerMovimientosPorPeriodoFinanzasXiDCaja
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ObtenerMovimientosPorPeriodoFinanzasXiDCaja(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, idCaja)
    End Function

    Public Function ListaReversionXDoc(strEmpresa As String, intIdEstablecimiento As Integer, idDocumento As Integer) As List(Of documentoCaja) Implements IContService.ListaReversionXDoc
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ListaReversionXDoc(strEmpresa, intIdEstablecimiento, idDocumento)
    End Function

    Public Function ObtenerMovimientosPorPeriodoFinanzasInforGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, intAnio As Integer, intMes As Integer, strMovimiento As String, tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentoCaja) Implements ServiceContract.IContService.ObtenerMovimientosPorPeriodoFinanzasInforGeneral
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ObtenerMovimientosPorPeriodoFinanzasInforGeneral(strIdEmpresa, intIdEstablecimiento, intAnio, intMes, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function

    Public Function SaveGroupCajaReversiones(objDocumentoBE As Business.Entity.documento) As Integer Implements ServiceContract.IContService.SaveGroupCajaReversiones
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaReversiones(objDocumentoBE)
    End Function

    Public Sub updateEstadoCaja(idDocumento As Integer, estado As String) Implements ServiceContract.IContService.updateEstadoCaja
        Dim cajaBL As New documentoCajaBL
        cajaBL.updateEstadoCaja(idDocumento, estado)
    End Sub

    Public Function ObtenerMovCajaReversion(strEmpresa As String, anio As Integer, mes As Integer) As List(Of documentoCaja) Implements ServiceContract.IContService.ObtenerMovCajaReversion
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ObtenerMovCajaReversion(strEmpresa, anio, mes)
    End Function

    Public Function ObtenerHistorialReversion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, tipoEstado As List(Of String)) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerHistorialReversion
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ObtenerHistorialReversion(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipoEstado)
    End Function

    Public Function ObtenerAnticiposConDevolucion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, listaMovimiento As List(Of String), tipoEstado As List(Of String), listaTransac As List(Of String)) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerAnticiposConDevolucion
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ObtenerAnticiposConDevolucion(strIdEmpresa, intIdEstablecimiento, strPeriodo, listaMovimiento, tipoEstado, listaTransac)
    End Function

    Public Function ObtenerMovCajaDevolucion(strEmpresa As String, anio As Integer, mes As Integer, tipo As List(Of String), listaEstado As List(Of String), listaMov As List(Of String)) As List(Of documentoCaja) Implements ServiceContract.IContService.ObtenerMovCajaDevolucion
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ObtenerMovCajaDevolucion(strEmpresa, anio, mes, tipo, listaEstado, listaMov)
    End Function

    Public Function ObtenerMovimientosPorPeriodoFinanzas(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String) As System.Collections.Generic.List(Of Business.Entity.documentoCaja) Implements ServiceContract.IContService.ObtenerMovimientosPorPeriodoFinanzas
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ObtenerMovimientosPorPeriodoFinanzas(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento)
    End Function

    Public Function GetMovimientoXusuarioInfoDetalle(intUsuario As Integer, fechaActual As Date) As List(Of documentoCajaDetalle) Implements IContService.GetMovimientoXusuarioInfoDetalle
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.GetMovimientoXusuarioInfoDetalle(intUsuario, fechaActual)
    End Function

    Public Function ListadoventasObservadasChild(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet) Implements IContService.ListadoventasObservadasChild
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.ListadoventasObservadasChild(be)
    End Function

    Public Sub GetConfirmarAlertaventa(be As documentoventaAbarrotes) Implements IContService.GetConfirmarAlertaventa
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.GetConfirmarAlertaventa(be)
    End Sub

    Public Function GetArticulosVendidosByMes(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet) Implements IContService.GetArticulosVendidosByMes
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetArticulosVendidosByMes(be)
    End Function

    Public Function GetArticulosVendidosByDia(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet) Implements IContService.GetArticulosVendidosByDia
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetArticulosVendidosByDia(be)
    End Function

    Public Function GetListarAllVentasPorCliente(objDocumento As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasPorCliente
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasPorCliente(objDocumento)
    End Function

    Public Sub ActulizarCantidadesByItem(be As totalesAlmacen) Implements IContService.ActulizarCantidadesByItem
        Dim totalBL As New totalesAlmacenBL
        totalBL.ActulizarCantidadesByItem(be)
    End Sub

    Public Function GetAlertaMovimientosAlmacen() As List(Of documentocompra) Implements IContService.GetAlertaMovimientosAlmacen
        Dim compraBL As New documentocompraBL
        Return compraBL.GetAlertaMovimientosAlmacen()
    End Function

    Public Function GetKardexByAnio(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetKardexByAnio
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetKardexByAnio(be)
    End Function

    Public Function GetKardexByfechaDocumentoLote(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetKardexByfechaDocumentoLote
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetKardexByfechaDocumentoLote(be)
    End Function


    Public Function GetListarAllVentasAnuladas(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasAnuladas
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasAnuladas(intIdEstablec, strPeriodo)
    End Function

    Public Function GrabarNewServicio(servicioBE As servicio) As Integer Implements IContService.GrabarNewServicio
        Dim servicioBL As New servicioBL
        Return servicioBL.SaveServicio(servicioBE)
    End Function

    Public Sub UpdateServicio(servicioBE As servicio) Implements IContService.UpdateServicio
        Dim servicioBL As New servicioBL
        servicioBL.UpdateServicio(servicioBE)
    End Sub

    Public Function GetAlmacenesByProducto(intIdItem As Integer, strIdEmpresa As String) As List(Of totalesAlmacen) Implements IContService.GetAlmacenesByProducto
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetAlmacenesByProducto(intIdItem, strIdEmpresa)
    End Function

    Public Function GetProcesosByCosto(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetProcesosByCosto
        Dim recursoCostoBL As New recursoCostoBL
        Return recursoCostoBL.GetProcesosByCosto(be)
    End Function

    Public Function GetListadoRecursosByProceso(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetListadoRecursosByProceso
        Dim recursoCostoBL As New recursoCostoDetalleBL
        Return recursoCostoBL.GetListadoRecursosByProceso(be)
    End Function

    Public Function GetCountItemsByProceso(be As recursoCosto) As Integer Implements IContService.GetCountItemsByProceso
        Dim recursoCostoBL As New recursoCostoDetalleBL
        Return recursoCostoBL.GetCountItemsByProceso(be)
    End Function

    Public Sub CambioAsigancion(be As recursoCostoDetalle) Implements IContService.CambioAsigancion
        Dim costoBL As New recursoCostoDetalleBL
        costoBL.CambioAsigancion(be)
    End Sub

    Public Sub EliminarAsientoCostos(be As asiento) Implements IContService.EliminarAsientoCostos
        Dim asientoBL As New AsientoBL
        asientoBL.EliminarAsientoCostos(be)
    End Sub

    Public Function GetSumaTotalImportesByCosto(be As recursoCosto) As recursoCosto Implements IContService.GetSumaTotalImportesByCosto
        Dim recursoBL As New recursoCostoDetalleBL
        Return recursoBL.GetSumaTotalImportesByCosto(be)
    End Function

    Public Sub GetCulminarCosto(be As recursoCosto, documento As documento) Implements IContService.GetCulminarCosto
        Dim recursoBL As New recursoCostoBL
        recursoBL.GetCulminarCosto(be, documento)
    End Sub

    Public Sub GetEliminarCierreCosto(be As recursoCosto) Implements IContService.GetEliminarCierreCosto
        Dim recursoBL As New recursoCostoBL
        recursoBL.GetEliminarCierreCosto(be)
    End Sub

    Public Function GetSumaTotalElementoCosto(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetSumaTotalElementoCosto
        Dim recursoBL As New recursoCostoDetalleBL
        Return recursoBL.GetSumaTotalElementoCosto(be)
    End Function

    Public Sub GetEliminarCierreProduccion(be As recursoCosto) Implements IContService.GetEliminarCierreProduccion
        Dim recursoBL As New recursoCostoBL
        recursoBL.GetEliminarCierreProduccion(be)
    End Sub

    Public Sub EliminarCostoPadre(be As recursoCosto) Implements IContService.EliminarCostoPadre
        Dim recursoBL As New recursoCostoBL
        recursoBL.EliminarCostoPadre(be)
    End Sub

    Public Function GetEstadoSaldoXEFME(idestado As Integer) As estadosFinancieros Implements IContService.GetEstadoSaldoXEFME
        Dim entidadBL As New estadosFinancierosBL
        Return entidadBL.GetEstadoSaldoXEFME(idestado)
    End Function

    Public Function ListadoMontosCuentas(idDoc As Integer) As List(Of documentoPrestamoDetalle) Implements IContService.ListadoMontosCuentas
        Dim prestamoBL As New documentoPrestamosBL
        Return prestamoBL.ListadoMontosCuotas(idDoc)
    End Function

    Public Function ListarPrestamosPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle) Implements IContService.ListarPrestamosPorCobrarPorDetails
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ListaPrestamosPorCobrarPorDetails(strDocumentoAfectado)
    End Function

    Public Sub UpdateConfirmarPrestamo(idDocumento As Integer) Implements IContService.UpdateConfirmarPrestamo
        Dim cajaBL As New prestamosBL
        cajaBL.UpdateConfirmarPrestamo(idDocumento)
    End Sub

    Public Function PrestamoListaDetalle(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle) Implements IContService.PrestamoListaDetalle
        Dim cajaBL As New documentoPrestamosBL
        Return cajaBL.PrestamoListadoDetalle(strDocumentoAfectado)
    End Function

    Public Sub InsertPrestamoRecibido(documentoBE As documento, prestamo As prestamos, listaDocumentos As List(Of documentoPrestamos), listaDetalle As List(Of documentoPrestamoDetalle)) Implements IContService.InsertPrestamoRecibido
        Dim prestamoBL As New documentoPrestamosBL
        prestamoBL.InsertPrestamoRecibido(documentoBE, prestamo, listaDocumentos, listaDetalle)
    End Sub

    Public Function ObtenerPrestamoAprobadoDesembolsado(idBenef As Integer, tipo As String, tipoProv As String) As List(Of prestamos) Implements IContService.ObtenerPrestamoAprobadoDesembolsado
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.ListadoPrestamoAprobadoDesembolsado(idBenef, tipo, tipoProv)
    End Function

    Public Function ObtenerPrestamoAprobadoBeneficiario(idBenef As Integer, tipo As String, tipoProv As String) As List(Of prestamos) Implements IContService.ObtenerPrestamoAprobadoBeneficiario
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.ListadoPrestamoAprobadosBenefi(idBenef, tipo, tipoProv)
    End Function

    Public Function ObtenerDesembolsoApto(idempresa As String, tipo As String) As List(Of prestamos) Implements IContService.ObtenerDesembolsoApto
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.ListadoDesembolsoApto(idempresa, tipo)
    End Function

    Public Function PrestamoSinConfirmarDetalle(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle) Implements IContService.PrestamoSinConfirmarDetalle
        Dim cajaBL As New documentoPrestamosBL
        Return cajaBL.PrestamoSinConfirmarDetalle(strDocumentoAfectado)
    End Function

    Public Function ObtenerTodoCuotasVencidas(tipo As String) As List(Of prestamos) Implements IContService.ObtenerTodoCuotasVencidas
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.ListadoTodoCuotasVencidas(tipo)
    End Function

    Public Function ObtenerPrestamosRecibidoXperiodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strTipoPrestamo As String) As List(Of prestamos) Implements IContService.ObtenerPrestamosRecibidoXperiodo
        Dim cajaBL As New prestamosBL
        Return cajaBL.ObtenerPrestamosRecibidoXperiodo(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoPrestamo)
    End Function

    Public Function ObtenerPrestamoPagoCobro(periodo As String, tipo As String) As List(Of prestamos) Implements IContService.ObtenerPrestamoPagoCobro
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.ListadoPrestamoPagoCobro(periodo, tipo)
    End Function

    Public Function ObtenerCuotasVencidas(idBenef As Integer, tipo As String) As List(Of prestamos) Implements IContService.ObtenerCuotasVencidas
        Dim prestamoBL As New prestamosBL
        Return prestamoBL.ListadoCuotasVencidas(idBenef, tipo)
    End Function

    Public Function LoadCuentasConceptos(strEmpresa As String) As List(Of cuentaplanContableEmpresa) Implements IContService.LoadCuentasConceptos
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.LoadCuentasConcepto(strEmpresa)
    End Function

    Public Function GrabarConceptoPrestamo(servicioBE As servicio) As Integer Implements IContService.GrabarConceptoPrestamo
        Dim servicioBL As New servicioBL
        Return servicioBL.SaveConceptosPrestamo(servicioBE)
    End Function

    Public Sub EditarConceptoPrestamo(servicioBE As servicio) Implements IContService.EditarConceptoPrestamo
        Dim servicioBL As New servicioBL
        servicioBL.UpdateConceptoPrestamo(servicioBE)
    End Sub

    Public Function ListadoComprobantexPagoPrestamo(iNtPadre As Integer) As List(Of documentoCaja) Implements IContService.ListadoComprobantexPagoPrestamo
        Dim DocumentoCajaBL As New documentoCajaBL
        Return DocumentoCajaBL.ListadoComprobantesPagoPadre(iNtPadre)
    End Function

    Public Function ListadoCajaDetallePagoPrestamo(intIdDocumento As Integer) As List(Of documentoCajaDetalle) Implements IContService.ListadoCajaDetallePagoPrestamo
        Dim DocumentoCajaBL As New documentoCajaDetalleBL
        Return DocumentoCajaBL.ListadoCajaDetallePago(intIdDocumento)
    End Function

    Public Function UbicarConceptosPrestamos(codigo As String, tipoPrestamo As String) As List(Of servicio) Implements IContService.UbicarConceptosPrestamos
        Dim servicioBL As New servicioBL
        Return servicioBL.GetUbicarConceptosPrestamo(codigo, tipoPrestamo)
    End Function

    Public Function GrabarTipoPrestamoPadre(servicioBE As servicio, detalle As List(Of servicio)) As Integer Implements IContService.GrabarTipoPrestamoPadre
        Dim servicioBL As New servicioBL
        Return servicioBL.SaveTipoPrestamo(servicioBE, detalle)
    End Function

    Public Sub EditarTipoPrestamo(servicioBE As servicio) Implements IContService.EditarTipoPrestamo
        Dim servicioBL As New servicioBL
        servicioBL.EditarTipoPrestamo(servicioBE)
    End Sub

    Public Sub InsertPrestamoOtorgado(documentoBE As documento, listaDocumentos As List(Of documentoPrestamos), listaDetalle As List(Of documentoPrestamoDetalle)) Implements IContService.InsertPrestamoOtorgado
        Dim prestamoBL As New documentoPrestamosBL
        prestamoBL.InsertPrestamoOtorgado(documentoBE, listaDocumentos, listaDetalle)
    End Sub

    Public Function GetFlujoEfectivo() As List(Of documentoCaja) Implements IContService.GetFlujoEfectivo
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetFlujoEfectivo()
    End Function

    Public Function GetEstadoCajasTodos() As estadosFinancieros Implements IContService.GetEstadoCajasTodos
        Dim cajaBL As New estadosFinancierosBL
        Return cajaBL.GetEstadoCajasTodos()
    End Function

    Public Function GetEstadoCajasTodosDetalle() As List(Of estadosFinancieros) Implements IContService.GetEstadoCajasTodosDetalle
        Dim cajaBL As New estadosFinancierosBL
        Return cajaBL.GetEstadoCajasTodosDetalle()
    End Function

    Public Function GetProductosTerminadosByCosto(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetProductosTerminadosByCosto
        Dim recursoCostoBL As New recursoCostoBL
        Return recursoCostoBL.GetProductosTerminadosByCosto(be)
    End Function

    Public Sub GetCulminarCostoProduccion(be As recursoCosto, documento As documento) Implements IContService.GetCulminarCostoProduccion
        Dim recursoCostoBL As New recursoCostoBL
        recursoCostoBL.GetCulminarCostoProduccion(be, documento)
    End Sub

    Public Function GetReporteElmentoCostoByProceso(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetReporteElmentoCostoByProceso
        Dim recursoCostoBL As New recursoCostoDetalleBL
        Return recursoCostoBL.GetReporteElmentoCostoByProceso(be)
    End Function

    Public Function GetListaPryectosEnCarteraFull(recurso As recursoCosto) As List(Of recursoCosto) Implements IContService.GetListaPryectosEnCarteraFull
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetListaPryectosEnCarteraFull(recurso)
    End Function

    Public Function GetProyectoByCodigoGenerado(recurso As recursoCosto) As recursoCosto Implements IContService.GetProyectoByCodigoGenerado
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetProyectoByCodigoGenerado(recurso)
    End Function

    Public Sub GrabarTask(be As recursoCosto) Implements IContService.GrabarTask
        Dim costoBL As New recursoCostoBL
        costoBL.GrabarTask(be)
    End Sub

    Public Function GetTareasByProyecto(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetTareasByProyecto
        Dim recurso As New recursoCostoBL
        Return recurso.GetTareasByProyecto(be)
    End Function

    Public Sub GrabarDetalleRecursosByTarea(be As recursoCostoDetalle) Implements IContService.GrabarDetalleRecursosByTarea
        Dim detalleBL As New recursoCostoDetalleBL
        detalleBL.GrabarDetalleRecursosByTarea(be)
    End Sub

    Public Function GetRecursosAsignadosByCosto(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetRecursosAsignadosByCosto
        Dim detalleBL As New recursoCostoDetalleBL
        Return detalleBL.GetRecursosAsignadosByCosto(be)
    End Function

    Public Function GetRecursosAsignadosByProceso(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetRecursosAsignadosByProceso
        Dim detalleBL As New recursoCostoDetalleBL
        Return detalleBL.GetRecursosAsignadosByProceso(be)
    End Function


    Public Sub EditarDetalleRecursoTareaBySecuencia(be As recursoCostoDetalle) Implements IContService.EditarDetalleRecursoTareaBySecuencia
        Dim detalleBL As New recursoCostoDetalleBL
        detalleBL.EditarDetalleRecursoTareaBySecuencia(be)
    End Sub

    Public Sub EliminarDetalleCostoPlan(be As recursoCostoDetalle) Implements IContService.EliminarDetalleCostoPlan
        Dim detalleBL As New recursoCostoDetalleBL
        detalleBL.EliminarDetalleCostoPlan(be)
    End Sub

    Public Sub EliminarCostoDetalleBySec(i As recursoCostoDetalle) Implements IContService.EliminarCostoDetalleBySec
        Dim detalleBL As New recursoCostoDetalleBL
        detalleBL.EliminarCostoDetalleBySec(i)
    End Sub

    Public Sub EliminarProcesos(i As recursoCosto) Implements IContService.EliminarProcesos
        Dim detalleBL As New recursoCostoDetalleBL
        detalleBL.EliminarProcesos(i)
    End Sub

    Public Sub EditarCostoTarea(be As recursoCosto) Implements IContService.EditarCostoTarea
        Dim detalleBL As New recursoCostoBL
        detalleBL.EditarCostoTarea(be)
    End Sub

    Public Sub EditarStatusCostoByID(be As recursoCosto) Implements IContService.EditarStatusCostoByID
        Dim detalleBL As New recursoCostoBL
        detalleBL.EditarStatusCostoByID(be)
    End Sub

    Public Function GetActividadProcesoByProyecto(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetActividadProcesoByProyecto
        Dim detalleBL As New recursoCostoBL
        Return detalleBL.GetActividadProcesoByProyecto(be)
    End Function

    Public Sub EditarRequerimeintoBySec(be As recursoCostoDetalle) Implements IContService.EditarRequerimeintoBySec
        Dim detalleBL As New recursoCostoDetalleBL
        detalleBL.EditarRequerimeintoBySec(be)
    End Sub

    Public Function GetRecursosAsignadosByTipoCosto(be As recursoCostoDetalle) As List(Of recursoCostoDetalle) Implements IContService.GetRecursosAsignadosByTipoCosto
        Dim detalleBL As New recursoCostoDetalleBL
        Return detalleBL.GetRecursosAsignadosByTipoCosto(be)
    End Function

    Public Function GetRecursoPlaneadoConteo(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetRecursoPlaneadoConteo
        Dim detalleBL As New recursoCostoDetalleBL
        Return detalleBL.GetRecursoPlaneadoConteo(be)
    End Function

    Public Function GetRecursoPlaneadosPendientesAprobacion(be As recursoCostoDetalle) As List(Of recursoCostoDetalle) Implements IContService.GetRecursoPlaneadosPendientesAprobacion
        Dim detalleBL As New recursoCostoDetalleBL
        Return detalleBL.GetRecursoPlaneadosPendientesAprobacion(be)
    End Function

    Public Function GetProductosParecidosRequeridos(be As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetProductosParecidosRequeridos
        Dim detalleBL As New totalesAlmacenBL
        Return detalleBL.GetProductosParecidosRequeridos(be)
    End Function

    Public Function GetUbicar_totalesAlmacenPorID(idMovimiento As Integer) As totalesAlmacen Implements IContService.GetUbicar_totalesAlmacenPorID
        Dim detalleBL As New totalesAlmacenBL
        Return detalleBL.GetUbicar_totalesAlmacenPorID(idMovimiento)
    End Function

    Public Function GrabarProduccion(objDocumento As documento) As Integer Implements IContService.GrabarProduccion
        Dim compraBL As New documentocompraBL
        Return compraBL.GrabarProduccion(objDocumento)
    End Function

    Public Function GetPlaneamientoActividades(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetPlaneamientoActividades
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetPlaneamientoActividades(be)
    End Function

    Public Function GetPlaneamientoEDT_Produccion(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetPlaneamientoEDT_Produccion
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetPlaneamientoEDT_Produccion(be)
    End Function


    Public Sub GetUpdateCronograma(be As recursoCosto) Implements IContService.GetUpdateCronograma
        Dim costoBL As New recursoCostoBL
        costoBL.GetUpdateCronograma(be)
    End Sub

    Public Sub GetUpdatefechaActual(be As recursoCosto) Implements IContService.GetUpdatefechaActual
        Dim costoBL As New recursoCostoBL
        costoBL.GetUpdatefechaActual(be)
    End Sub

    Public Sub GetCierreActividad(be As recursoCosto) Implements IContService.GetCierreActividad
        Dim costoBL As New recursoCostoBL
        costoBL.GetCierreActividad(be)
    End Sub

    Public Sub GetUpdateSecuencia(be As List(Of recursoCosto)) Implements IContService.GetUpdateSecuencia
        Dim costoBL As New recursoCostoBL
        costoBL.GetUpdateSecuencia(be)
    End Sub

    Public Function GetPlaneamientoKanban(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetPlaneamientoKanban
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetPlaneamientoKanban(be)
    End Function

    Public Sub GetOpenActividad(be As recursoCosto) Implements IContService.GetOpenActividad
        Dim costoBL As New recursoCostoBL
        costoBL.GetOpenActividad(be)
    End Sub

    Public Sub GrabarEntregable(be As recursoCosto) Implements IContService.GrabarEntregable
        Dim costoBL As New recursoCostoBL
        costoBL.GrabarEntregable(be)
    End Sub

    Public Function GetProductosTerminadosByProyecto(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetProductosTerminadosByProyecto
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetProductosTerminadosByProyecto(be)
    End Function

    Public Sub EditarEntregable(be As recursoCosto) Implements IContService.EditarEntregable
        Dim costoBL As New recursoCostoBL
        costoBL.EditarEntregable(be)
    End Sub

    Public Sub EliminarEntregable(be As recursoCosto) Implements IContService.EliminarEntregable
        Dim costoBL As New recursoCostoBL
        costoBL.EliminarEntregable(be)
    End Sub

    Public Sub GetPendingActividad(be As recursoCosto) Implements IContService.GetPendingActividad
        Dim costoBL As New recursoCostoBL
        costoBL.GetPendingActividad(be)
    End Sub

    Public Function GetSumaTotalByProyecto(be As recursoCostoDetalle) As List(Of recursoCostoDetalle) Implements IContService.GetSumaTotalByProyecto
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetSumaTotalByProyecto(be)
    End Function

    Public Function SaveVentaPSPinturas(objDocumento As documento) As Integer Implements IContService.SaveVentaPSPinturas
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.SaveVentaPSPinturas(objDocumento)
    End Function

    Public Sub ConfirmarVentaTicketConsumoDirecto(objDocumento As documento) Implements IContService.ConfirmarVentaTicketConsumoDirecto
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.ConfirmarVentaTicketConsumoDirecto(objDocumento)
    End Sub


    Public Function GetConsumoByidDocumento(be As documentoconsumodirecto) As List(Of documentoconsumodirecto) Implements IContService.GetConsumoByidDocumento
        Dim ventaBL As New documentoconsumodirectoBL
        Return ventaBL.GetConsumoByidDocumento(be)
    End Function

    Public Function GetSumaBySecuencia(be As documentoconsumodirecto) As Decimal Implements IContService.GetSumaBySecuencia
        Dim ventaBL As New documentoconsumodirectoBL
        Return ventaBL.GetSumaBySecuencia(be)
    End Function

    Public Sub UpdateEstadoCronograma(be As Cronograma) Implements IContService.UpdateEstadoCronograma
        Dim recursoBL As New CronogramaBL
        recursoBL.UpdateEstado(be)
    End Sub

    Public Function GetCronogramaPendiente() As List(Of Cronograma) Implements IContService.GetCronogramaPendiente
        Dim cronoBL As New CronogramaBL
        Return cronoBL.GetCronogramaPendiente()
    End Function

    Public Sub UpdateCronogramaHijo(be As Cronograma) Implements IContService.UpdateCronogramaHijo
        Dim recursoBL As New CronogramaBL
        recursoBL.UpdateHijoCronograma(be)
    End Sub


    Public Sub UpdateGastoModulo(be As documentoLibroDiario) Implements IContService.UpdateGastoModulo
        Dim recursoBL As New documentoLibroDiarioBL
        recursoBL.UpdateGastoModulo(be)
    End Sub

    Public Sub DeleteHijoCronograma(intIdCronograma As Integer) Implements IContService.DeleteHijoCronograma
        Dim DocumetoBL As New CronogramaBL
        DocumetoBL.DeleteCronoHijo(intIdCronograma)
    End Sub

    Public Function GetCronograma() As List(Of Cronograma) Implements IContService.GetCronograma
        Dim cronoBL As New CronogramaBL
        Return cronoBL.GetCronograma()
    End Function


    Public Sub InsertCronograma(lista As List(Of Cronograma)) Implements IContService.InsertCronograma
        Dim cronogramaBL As New CronogramaBL
        cronogramaBL.InsertCronograma(lista)
    End Sub

    Public Function ObtenerCuentasPorPagarTodoDetails(idProv As Integer, strperiodo As String) As List(Of documentoCajaDetalle) Implements IContService.ObtenerCuentasPorPagarTodoDetails
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCuentasPorPagarTodoDetails(idProv, strperiodo)
    End Function

    Public Function UbicarCobrosModulo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, strPeriodo As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarCobrosModulo
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.UbicarCobrosModulo(strEmpresa, intIdEstablecimiento, cuenta, strPeriodo)
    End Function

    Public Function UbicarCobrosModuloTodo(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarCobrosModuloTodo
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.UbicarCobrosModuloTodo(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function UbicarCobrosModuloTodoProveedor(strEmpresa As String, intIdEstablecimiento As Integer, idprov As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarCobrosModuloTodoProveedor
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.UbicarCobrosModuloTodoProveedor(strEmpresa, intIdEstablecimiento, idprov)
    End Function

    Public Function UbicarCobrosPorClienteTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String, idprov As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarCobrosPorClienteTodo
        Dim documentoBL As New documentoventaAbarrotesBL
        Return documentoBL.UbicarCobrosClienteTodo(strEmpresa, intIdEstablecimiento, strMoneda, idprov, strPeriodo)
    End Function

    Public Function UbicarCobrosPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMoneda As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarCobrosPorProveedorXperiodo
        Dim documentoBL As New documentoventaAbarrotesBL
        Return documentoBL.UbicarCobrosProveedorXperiodo(strEmpresa, intIdEstablecimiento, strPeriodo, strMoneda)
    End Function

    Public Function UbicarCobrosPorTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarCobrosPorTodo
        Dim documentoBL As New documentoventaAbarrotesBL
        Return documentoBL.UbicarCobrosTodo(strEmpresa, intIdEstablecimiento, strMoneda)
    End Function

    Public Function UbicarPagosModulo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, strPeriodo As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarPagosModulo
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.UbicarPagosModulo(strEmpresa, intIdEstablecimiento, cuenta, strPeriodo)
    End Function

    Public Function UbicarPagosModuloTodo(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarPagosModuloTodo
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.UbicarPagosModuloTodo(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function UbicarPagosModuloTodoProveedor(strEmpresa As String, intIdEstablecimiento As Integer, idprov As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarPagosModuloTodoProveedor
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.UbicarPagosModuloTodoProveedor(strEmpresa, intIdEstablecimiento, idprov)
    End Function

    Public Function UbicarPagosPorProveedor(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String) As List(Of documentocompra) Implements IContService.UbicarPagosPorProveedor
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarPagosProveedor(strEmpresa, intIdEstablecimiento, strMoneda)
    End Function

    Public Function UbicarPagosPorProveedorTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String, idprov As Integer, strPeriodo As String) As List(Of documentocompra) Implements IContService.UbicarPagosPorProveedorTodo
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarPagosProveedorTodo(strEmpresa, intIdEstablecimiento, strMoneda, idprov, strPeriodo)
    End Function


    Public Function UbicarPagosPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMoneda As String) As List(Of documentocompra) Implements IContService.UbicarPagosPorProveedorXperiodo
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarPagosProveedorXperiodo(strEmpresa, intIdEstablecimiento, strPeriodo, strMoneda)
    End Function

    Public Function UbicarPagosPorTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String) As List(Of documentocompra) Implements IContService.UbicarPagosPorTodo
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarPagosTodo(strEmpresa, intIdEstablecimiento, strMoneda)
    End Function

    Public Function ListarGastosModulo(tipo As String, periodo As String) As List(Of documentoLibroDiario) Implements IContService.ListarGastosModulo
        Dim servicioBL As New documentoLibroDiarioBL
        Return servicioBL.ListaGastosModulo(tipo, periodo)
    End Function

    Public Function SaveGastosXModulo(objDocumento As documento) As Object Implements IContService.SaveGastosXModulo
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.GrabarGastoXModulo(objDocumento)
    End Function

    Public Function UbicarDocumentoModuloDetalle(intIdDocumento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarDocumentoModuloDetalle
        Dim documentoBL As New documentoLibroDiarioDetalleBL
        Return documentoBL.GetUbicar_documentoModuloDetalle(intIdDocumento)
    End Function

    Public Function UbicarGastosModulo(iddoc As Integer) As documentoLibroDiario Implements IContService.UbicarGastosModulo
        Dim servicioBL As New documentoLibroDiarioBL
        Return servicioBL.UbicarGastosModulo(iddoc)
    End Function

    Public Function UbicarDetallePinturas(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet) Implements IContService.UbicarDetallePinturas
        Dim servicioBL As New documentoventaAbarrotesDetBL
        Return servicioBL.UbicarDetallePinturas(intidDocumento)
    End Function

    Public Sub GetSaveConsumo(doc As documento, lista As List(Of documentoconsumodirecto)) Implements IContService.GetSaveConsumo
        Dim consumoBL As New documentoconsumodirectoBL
        consumoBL.GetSaveConsumo(doc, lista)
    End Sub

    Public Function GetPlantillaByArticulo(be As detalleitems) As List(Of articuloplantilla) Implements IContService.GetPlantillaByArticulo
        Dim consumoBL As New articuloplantillaBL
        Return consumoBL.GetPlantillaByArticulo(be)
    End Function

    Public Sub UpdateEstadoCronogramaDelete(be As Cronograma, iddocumento As Integer) Implements IContService.UpdateEstadoCronogramaDelete
        Dim recursoBL As New CronogramaBL
        recursoBL.UpdateEstadoDeletPago(be, iddocumento)
    End Sub

    Public Function ObtenerCuentasPorCobrarTodoDetails(idclie As Integer, strperiodo As String) As List(Of documentoCajaDetalle) Implements IContService.ObtenerCuentasPorCobrarTodoDetails
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCuentasPorCobrarTodoDetails(idclie, strperiodo)
    End Function

    Public Sub EliminarConsumoDirecto(documentoBE As documento) Implements IContService.EliminarConsumoDirecto
        Dim ventaBL As New documentoBL
        ventaBL.EliminarConsumoDirecto(documentoBE)
    End Sub

    Public Sub EditarPlantillaArticulo(be As articuloplantilla) Implements IContService.EditarPlantillaArticulo
        Dim plantillaBL As New articuloplantillaBL
        plantillaBL.EditarPlantillaArticulo(be)
    End Sub

    Public Sub EliminarPlantillaArticulo(be As articuloplantilla) Implements IContService.EliminarPlantillaArticulo
        Dim plantillaBL As New articuloplantillaBL
        plantillaBL.EliminarPlantillaArticulo(be)
    End Sub

    Public Sub InsertPlantillaArticulo(be As articuloplantilla) Implements IContService.InsertPlantillaArticulo
        Dim plantillaBL As New articuloplantillaBL
        plantillaBL.InsertPlantillaArticulo(be)
    End Sub

    Public Function GetPlantillaPadre(be As detalleitems) As List(Of articuloplantilla) Implements IContService.GetPlantillaPadre
        Dim plantillaBL As New articuloplantillaBL
        Return plantillaBL.GetPlantillaPadre(be)
    End Function

    Public Function GetPlantillaByIdPadre(be As articuloplantilla) As List(Of articuloplantilla) Implements IContService.GetPlantillaByIdPadre
        Dim plantillaBL As New articuloplantillaBL
        Return plantillaBL.GetPlantillaByIdPadre(be)
    End Function

    Public Sub UpdateEstadoCronogramaDeleteCobro(be As Cronograma, iddocumento As Integer) Implements IContService.UpdateEstadoCronogramaDeleteCobro
        Dim recursoBL As New CronogramaBL
        recursoBL.UpdateEstadoDeletCobro(be, iddocumento)
    End Sub

    Public Function GetCronogramaDetalle(fechaprog As Date, fechaVen As DateTime) As List(Of Cronograma) Implements IContService.GetCronogramaDetalle
        Dim cronoBL As New CronogramaBL
        Return cronoBL.GetCronogramaDetalle(fechaprog, fechaVen)
    End Function



    Public Sub UpdateEstadoCronogramaLista(be As List(Of Cronograma)) Implements IContService.UpdateEstadoCronogramaLista
        Dim recursoBL As New CronogramaBL
        recursoBL.UpdateEstadoLista(be)
    End Sub

    Public Function GetCronogramaTipo(fechaprog As Date, tipoprog As String, fechaVen As DateTime) As List(Of Cronograma) Implements IContService.GetCronogramaTipo
        Dim cronoBL As New CronogramaBL
        Return cronoBL.GetCronogramaTotalesTipo(fechaprog, tipoprog, fechaVen)
    End Function

    Public Function ObtenerCuentasPorPagarDocumentoDetails(list As List(Of documentocompra)) As List(Of documentoCajaDetalle) Implements IContService.ObtenerCuentasPorPagarDocumentoDetails
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCuentasPorPagarDocumentoDetails(list)
    End Function

    Public Function ConsultaMovimientosPorCajaYTipoExistencia(idCaja As Integer) As List(Of documentoCajaDetalle) Implements IContService.ConsultaMovimientosPorCajaYTipoExistencia
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ConsultaMovimientosPorCajaYTipoExistencia(idCaja)
    End Function

    Public Function ConsultaMovimientosPorCajaxEstadoFinanciero(idCaja As Integer) As List(Of documentoCajaDetalle) Implements IContService.ConsultaMovimientosPorCajaxEstadoFinanciero
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ConsultaMovimientosPorCajaxEstadoFinanciero(idCaja)
    End Function

    Public Function ListacajausuarioXCuentasXcobrar(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotes) Implements IContService.ListacajausuarioXCuentasXcobrar
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ListacajausuarioXCuentasXcobrar(intIdPersona, fechaInicio, fechaFin)
    End Function

    Public Function ListacajausuarioXCuentasXCompra(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentocompra) Implements IContService.ListacajausuarioXCuentasXCompra
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ListacajausuarioXCuentasXCompra(intIdPersona, fechaInicio, fechaFin)
    End Function

    Public Function ListacajausuarioXDetalleAcumulado(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotesDet) Implements IContService.ListacajausuarioXDetalleAcumulado
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ListacajausuarioXDetalleAcumulado(intIdPersona, fechaInicio, fechaFin)
    End Function

    Public Function ObtenerPagosDetailsAsientoManual(idProv As Integer, strperiodo As String, tipop As String, modulo As String) As List(Of documentoCajaDetalle) Implements IContService.ObtenerPagosDetailsAsientoManual
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerPagosDetailsAsientoManual(idProv, strperiodo, tipop, modulo)
    End Function

    Public Function SaveGroupCajaMEAsiento(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer Implements IContService.SaveGroupCajaMEAsiento
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaMEAsiento(objDocumentoBE, cajaUsuario, listaDetalle)
    End Function

    Public Function UbicarPagosPorProveedorPendiente(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strMoneda As String) As List(Of documentocompra) Implements IContService.UbicarPagosPorProveedorPendiente
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarPagosPorProveedorPendiente(strEmpresa, intIdEstablecimiento, strRuc, strMoneda)
    End Function

    Public Function GetUbicarProductosXcodigoBarra(idEmpresa As String, idEstablec As Integer, codigobarra As String) As detalleitems Implements IContService.GetUbicarProductosXcodigoBarra
        Dim productoBL As New detalleitemsBL
        Return productoBL.GetUbicarProductoXcodigoBarra(idEmpresa, idEstablec, codigobarra)
    End Function

    Public Function GetExistenciasByempresaCodigo(idempresa As String, idEstable As Integer, codigobarra As String) As List(Of detalleitems) Implements IContService.GetExistenciasByempresaCodigo
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetExistenciasByempresaCodigo(idempresa, idEstable, codigobarra)
    End Function

    Public Function GetProductosByAlmacenCodigo(intIdAlmacen As Integer, Optional CodigoBarra As String = Nothing) As List(Of totalesAlmacen) Implements IContService.GetProductosByAlmacenCodigo
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetProductosByAlmacenCodigo(intIdAlmacen, CodigoBarra)
    End Function

    Public Sub EliminarPagoProgramado(iddocuemnto As Integer, estado As String) Implements IContService.EliminarPagoProgramado
        Dim recursoBL As New CronogramaBL
        recursoBL.EliminarPagosProgramado(iddocuemnto, estado)
    End Sub

    Public Function GetPagosxProgramacion(idprov As Integer, tipo As String, tipoestado As String, mes As Integer) As List(Of Cronograma) Implements IContService.GetPagosxProgramacion
        Dim cronoBL As New CronogramaBL
        Return cronoBL.GetPagosxProgramacion(idprov, tipo, tipoestado, mes)
    End Function

    Public Function GetCronogramaDetalleTipo(idprov As Integer, tipo As String, tipoestado As String, fechaprog As Date, tipomoneda As String, fechavenc As DateTime) As List(Of Cronograma) Implements IContService.GetCronogramaDetalleTipo
        Dim cronoBL As New CronogramaBL
        Return cronoBL.GetCronogramaDetalleTipo(idprov, tipo, tipoestado, fechaprog, tipomoneda, fechavenc)
    End Function

    Public Function UbicarPagosPorProveedorPendienteMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentocompra) Implements IContService.UbicarPagosPorProveedorPendienteMNME
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarPagosPorProveedorPendienteMNME(strEmpresa, intIdEstablecimiento, strRuc)
    End Function

    Public Function ObtenerCuentasPorPagarDocumentoDetailsME(list As List(Of documentocompra)) As List(Of documentoCajaDetalle) Implements IContService.ObtenerCuentasPorPagarDocumentoDetailsME
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCuentasPorPagarDocumentoDetailsME(list)
    End Function

    Public Function SaveGroupCajaDocsME(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer Implements IContService.SaveGroupCajaDocsME
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaDocsME(objDocumentoBE, cajaUsuario, listaDetalle)
    End Function

    Public Function GetExistenciasByempresaNombre(nombre As String, empresaID As String) As List(Of detalleitems) Implements IContService.GetExistenciasByempresaNombre
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetExistenciasByempresaNombre(nombre, empresaID)
    End Function

    Public Function ListaServiciosOtrosAnticipado() As List(Of documentocompradetalle) Implements IContService.ListaServiciosOtrosAnticipado
        Dim recursoBL As New documentocompraBL
        Return recursoBL.ListaServiciosOtrosAnticipado()
    End Function

    Public Function UbicarCuentaCobrarComercial(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoventaAbarrotes) Implements IContService.UbicarCuentaCobrarComercial
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.UbicarCuentasXCobrarComerciales(strEmpresa, intIdEstablecimiento)
    End Function

    Public Sub CulminarCosto(r As recursoCosto, documento As documento) Implements IContService.CulminarCosto

    End Sub

    Public Function UbicarCuentasXPagarComerciales() As List(Of documentocompra) Implements IContService.UbicarCuentasXPagarComerciales
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarCuentasXPagarComerciales()
    End Function

    Public Function GetListadoProductosParaVentaXproductoEmpresa(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetListadoProductosParaVentaXproductoEmpresa
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListadoProductosParaVentaXproductoEmpresa(objTotalBE)
    End Function

    Public Function GetListadoProductosParaVentaXproductoEmpresaFull(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetListadoProductosParaVentaXproductoEmpresaFull
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListadoProductosParaVentaXproductoEmpresaFull(objTotalBE)
    End Function

    Public Function GetListadoProductosParaVentaXbarCode(objTotalBE As totalesAlmacen) As totalesAlmacen Implements IContService.GetListadoProductosParaVentaXbarCode
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetListadoProductosParaVentaXbarCode(objTotalBE)
    End Function

    Public Function DeudasGenerales() As List(Of documentocompra) Implements IContService.DeudasGenerales
        Dim cronoBL As New documentocompraBL
        Return cronoBL.DeudasGenerales()
    End Function

    Public Function UbicarVentaPorClienteMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer) As List(Of documentoventaAbarrotes) Implements IContService.UbicarVentaPorClienteMNME
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.UbicarVentaPorClientePendienteMNME(strEmpresa, intIdEstablecimiento, strRuc)
    End Function

    Public Function GetPreciosproductoMaxFecha(intIdItem As Integer, CodPrecio As Integer) As configuracionPrecioProducto Implements IContService.GetPreciosproductoMaxFecha
        Dim precioBL As New ConfiguracionPrecioProductoBL
        Return precioBL.GetPreciosproductoMaxFecha(intIdItem, CodPrecio)
    End Function

    Public Function GetCuentasFinancierasByEmpresa(idEmpresa As String, strTipo As String) As List(Of estadosFinancieros) Implements IContService.GetCuentasFinancierasByEmpresa
        Dim precioBL As New estadosFinancierosBL
        Return precioBL.GetCuentasFinancierasByEmpresa(idEmpresa, strTipo)
    End Function

    Public Sub GrabarVentaMultiEmpresa(listadoDocVenta As List(Of documento)) Implements IContService.GrabarVentaMultiEmpresa
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.GrabarVentaMultiEmpresa(listadoDocVenta)
    End Sub

    Public Sub CambiarStatusEntidad(entidadBE As entidad) Implements IContService.CambiarStatusEntidad
        Dim entidadBL As New entidadBL
        entidadBL.Delete(entidadBE)
    End Sub

    Public Function GetEntidadesGenerales(tipo As String, strIdEmpresa As String) As List(Of entidad) Implements IContService.GetEntidadesGenerales
        Dim entidadBL As New entidadBL
        Return entidadBL.GetEntidadesGenerales(tipo, strIdEmpresa)
    End Function

    Public Function GetUbicarEntPorID(strEmpresa As String, intIdEntidad As Integer) As entidad Implements ServiceContract.IContService.GetUbicarEntPorID
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.GetUbicarEntPorID(strEmpresa, intIdEntidad)
    End Function


    Public Function GetSaldosCajaEntranjera(be As estadosFinancieros) As List(Of documentoCaja) Implements IContService.GetSaldosCajaEntranjera
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetSaldosCajaEntranjera(be)
    End Function

    Public Function UbicarPagosPorAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarPagosPorAsientoManualMNME
        Dim libroBL As New documentoLibroDiarioBL
        Return libroBL.UbicarPagosPorAsientoManualMNME(strEmpresa, intIdEstablecimiento, strRuc)
    End Function

    Public Function ObtenerCuentasPorPagarAsientoDetails(lista As List(Of documentoLibroDiarioDetalle)) As List(Of documentoCajaDetalle) Implements IContService.ObtenerCuentasPorPagarAsientoDetails
        Dim libroBL As New documentoCajaDetalleBL
        Return libroBL.ObtenerCuentasPorPagarAsientoDetails(lista)
    End Function

    Public Function GetCronogramaDetalleTipoAsiento(idprov As Integer, tipo As String, tipoEstado As String, fechaprog As Date, tipomoneda As String, fechaven As DateTime) As List(Of Cronograma) Implements IContService.GetCronogramaDetalleTipoAsiento
        Dim libroBL As New CronogramaBL
        Return libroBL.GetCronogramaDetalleTipoAsiento(idprov, tipo, tipoEstado, fechaprog, tipomoneda, fechaven)
    End Function

    Public Function GetCronogramaPagoCobroHistorial(TipoProg As String) As List(Of Cronograma) Implements IContService.GetCronogramaPagoCobroHistorial
        Dim libroBL As New CronogramaBL
        Return libroBL.GetCronogramaPagoCobroHistorial(TipoProg)
    End Function

    Public Function GetCronogramaDetalleCobro(fechaprog As Date, fechaVen As DateTime) As List(Of Cronograma) Implements IContService.GetCronogramaDetalleCobro
        Dim libroBL As New CronogramaBL
        Return libroBL.GetCronogramaDetalleCobros(fechaprog, fechaVen)
    End Function

    Public Function GetCronogramaDetalleTipoCobros(idprov As Integer, tipo As String, tipoEstado As String, fechaprog As Date, tipomoneda As String) As List(Of Cronograma) Implements IContService.GetCronogramaDetalleTipoCobros
        Dim libroBL As New CronogramaBL
        Return libroBL.GetCronogramaDetalleTipoCobros(idprov, tipo, tipoEstado, fechaprog, tipomoneda)
    End Function

    Public Function GetCronogramaPagoCobro(TipoProg As String) As List(Of Cronograma) Implements IContService.GetCronogramaPagoCobro
        Dim libroBL As New CronogramaBL
        Return libroBL.GetCronogramaPagoCobro(TipoProg)
    End Function

    Public Function DeudasGeneralesAsiento() As List(Of documentoLibroDiarioDetalle) Implements IContService.DeudasGeneralesAsiento
        Dim libroBL As New documentoLibroDiarioBL
        Return libroBL.DeudasGeneralesAsiento()
    End Function

    Public Function GetCronogramaDetalleAsiento(fechaprog As Date) As List(Of Cronograma) Implements IContService.GetCronogramaDetalleAsiento
        Dim cronogramaBL As New CronogramaBL
        Return cronogramaBL.GetCronogramaDetalleAsiento(fechaprog)
    End Function

    Public Function CobrosGenerales() As List(Of documentoventaAbarrotes) Implements IContService.CobrosGenerales
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.CobrosGenerales()
    End Function

    Public Function GetDepositosExtranjeros(be As estadosFinancieros) As List(Of documentoCaja) Implements IContService.GetDepositosExtranjeros
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetDepositosExtranjeros(be)
    End Function

    Public Function GetMovimientosDetalleByDepodito(be As movimientocajaextranjera) As List(Of movimientocajaextranjera) Implements IContService.GetMovimientosDetalleByDepodito
        Dim cajaBL As New movimientocajaextranjeraBL
        Return cajaBL.GetMovimientosDetalleByDepodito(be)
    End Function

    Public Function GetProductoPorAlmacenTipoExByCodigoBarra(intIdAlmacen As Integer, strTipoEx As String, CodBarra As String) As List(Of totalesAlmacen) Implements IContService.GetProductoPorAlmacenTipoExByCodigoBarra
        Dim cajaBL As New totalesAlmacenBL
        Return cajaBL.GetProductoPorAlmacenTipoExByCodigoBarra(intIdAlmacen, strTipoEx, CodBarra)
    End Function

    Public Function SumaNotasXidPadreItemOpcionDefault(intIdSecuencia As Integer) As documentocompradetalle Implements IContService.SumaNotasXidPadreItemOpcionDefault
        Dim cajaBL As New documentocompradetalleBL
        Return cajaBL.SumaNotasXidPadreItemOpcionDefault(intIdSecuencia)
    End Function

    Public Function GetFlujoEfectivoByDia(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetFlujoEfectivoByDia
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetFlujoEfectivoByDia(be)
    End Function

    Public Function GetFlujoEfectivoByDiaAllEmpresa(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetFlujoEfectivoByDiaAllEmpresa
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetFlujoEfectivoByDiaAllEmpresa(be)
    End Function

    Public Function GetEstadoCajasTodosDetalleByDia(be As documentoCaja) As List(Of estadosFinancieros) Implements IContService.GetEstadoCajasTodosDetalleByDia
        Dim cajaBL As New estadosFinancierosBL
        Return cajaBL.GetEstadoCajasTodosDetalleByDia(be)
    End Function

    Public Function GetEstadoCajasTodosDetalleByDiaAllEmpresa(be As documentoCaja) As List(Of estadosFinancieros) Implements IContService.GetEstadoCajasTodosDetalleByDiaAllEmpresa
        Dim cajaBL As New estadosFinancierosBL
        Return cajaBL.GetEstadoCajasTodosDetalleByDiaAllEmpresa(be)
    End Function

    Public Function GetSumaComprasDelDia(be As documentocompra) As documentocompra Implements IContService.GetSumaComprasDelDia
        Dim compraBL As New documentocompraBL
        Return compraBL.GetSumaComprasDelDia(be)
    End Function

    Public Function GetSumaComprasDelDiaAllEmpresa(be As documentocompra) As documentocompra Implements IContService.GetSumaComprasDelDiaAllEmpresa
        Dim compraBL As New documentocompraBL
        Return compraBL.GetSumaComprasDelDiaAllEmpresa(be)
    End Function

    Public Function GetSumaVentasDelDiaAllEmpresa(be As documentoventaAbarrotes) As documentoventaAbarrotes Implements IContService.GetSumaVentasDelDiaAllEmpresa
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetSumaVentasDelDiaAllEmpresa(be)
    End Function

    Public Function GetSumaVentasDelDia(be As documentoventaAbarrotes) As documentoventaAbarrotes Implements IContService.GetSumaVentasDelDia
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetSumaVentasDelDia(be)
    End Function

    Public Function GetEstadoCajasTodosByDia(be As documentoCaja) As estadosFinancieros Implements IContService.GetEstadoCajasTodosByDia
        Dim compraBL As New estadosFinancierosBL
        Return compraBL.GetEstadoCajasTodosByDia(be)
    End Function

    Public Function GetEstadoCajasTodosByDiaAllEmpresa(be As documentoCaja) As estadosFinancieros Implements IContService.GetEstadoCajasTodosByDiaAllEmpresa
        Dim compraBL As New estadosFinancierosBL
        Return compraBL.GetEstadoCajasTodosByDiaAllEmpresa(be)
    End Function

    Public Function CuentaAnticipos(asientoBE As asiento) As movimiento Implements IContService.CuentaAnticipos
        Dim movBL As New movimientoBL
        Return movBL.CuentaAnticipos(asientoBE)
    End Function

    Public Function CuentaCobroComercial(asientoBE As asiento) As movimiento Implements IContService.CuentaCobroComercial
        Dim movBL As New movimientoBL
        Return movBL.CuentaCobroComercial(asientoBE)
    End Function

    Public Function CuentaEntregaRendir(asientoBE As asiento) As movimiento Implements IContService.CuentaEntregaRendir
        Dim movBL As New movimientoBL
        Return movBL.CuentaEntregaRendir(asientoBE)
    End Function

    Public Function CuentaPagoComercial(asientoBE As asiento) As movimiento Implements IContService.CuentaPagoComercial
        Dim movBL As New movimientoBL
        Return movBL.CuentaPagoComercial(asientoBE)
    End Function

    Public Function CuentaPagoComercialRel(asientoBE As asiento) As movimiento Implements IContService.CuentaPagoComercialRel
        Dim movBL As New movimientoBL
        Return movBL.CuentaPagoComercialRel(asientoBE)
    End Function

    Public Function CuentaPagoLetras(asientoBE As asiento) As movimiento Implements IContService.CuentaPagoLetras
        Dim movBL As New movimientoBL
        Return movBL.CuentaPagoLetras(asientoBE)
    End Function

    Public Function ListaRecursosCostoInventario(compraBE As documentocompra) As List(Of documentocompradetalle) Implements IContService.ListaRecursosCostoInventario
        Dim costoBL As New documentocompraBL
        Return costoBL.ListaRecursosCostoInventario(compraBE)
    End Function

    Public Function GetKardexByAnioDiaLaboral(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetKardexByAnioDiaLaboral
        Dim costoBL As New InventarioMovimientoBL
        Return costoBL.GetKardexByAnioDiaLaboral(be)
    End Function

    Public Function GetKardexByAnioDiaLaboralLote(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetKardexByAnioDiaLaboralLote
        Dim costoBL As New InventarioMovimientoBL
        Return costoBL.GetKardexByAnioDiaLaboralLote(be)
    End Function

    Public Function GetKardexByDia(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetKardexByDia
        Dim costoBL As New InventarioMovimientoBL
        Return costoBL.GetKardexByDia(be)
    End Function

    Public Function GetKardexByDiaLaboral_1(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetKardexByDiaLaboral_1
        Dim costoBL As New InventarioMovimientoBL
        Return costoBL.GetKardexByDiaLaboral_1(be)
    End Function

    Public Function CuentaCostoVenta(asientoBE As asiento) As movimiento Implements IContService.CuentaCostoVenta
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaCostoVenta(asientoBE)
    End Function

    Public Function CuentaOtrosIngreso(asientoBE As asiento) As movimiento Implements IContService.CuentaOtrosIngreso
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaOtrosIngreso(asientoBE)
    End Function

    Public Function CuentaVentasNetas(asientoBE As asiento) As movimiento Implements IContService.CuentaVentasNetas
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaVentasNetas(asientoBE)
    End Function

    Public Function CuentaVentasNetas2(asientoBE As asiento) As movimiento Implements IContService.CuentaVentasNetas2
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaVentasNetas2(asientoBE)
    End Function

    Public Function CuentaUtilidadOperativa(asientoBE As asiento) As movimiento Implements IContService.CuentaUtilidadOperativa
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaUtilidadOperativa(asientoBE)
    End Function

#Region "GUIA DE REMISION"

    Public Function SaveVentaCobradaContado(objDocumento As documento) As Integer Implements IContService.SaveVentaCobradaContado
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.SaveVentaCobradaContado(objDocumento)
    End Function

    Public Function GetConteoPedidosAprobado(intIdEstablec As Integer, strPeriodo As String, strTipo As String) As Integer Implements IContService.GetConteoPedidosAprobado
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetConteoPedidosAprobado(intIdEstablec, strPeriodo, strTipo)
    End Function

    Public Function UbicarVentaPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipo As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarVentaPorProveedorXperiodo
        Dim documentoBL As New documentoventaAbarrotesBL
        Return documentoBL.UbicarVentaPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, tipo)
    End Function

    Public Function UbicarVentaPorProveedorXperiodoFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarVentaPorProveedorXperiodoFull
        Dim documentoBL As New documentoventaAbarrotesBL
        Return documentoBL.UbicarVentaPorProveedorXperiodoFull(strEmpresa, intIdEstablecimiento, strPeriodo, tipo)
    End Function

    Public Function GrabarVentaGeneralCredito(objDocumento As documento) As Integer Implements IContService.GrabarVentaGeneralCredito
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarVentaGeneralCredito(objDocumento)
    End Function

    Public Function ListaTotalXVenta(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As Integer, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentoventaAbarrotes Implements IContService.ListaTotalXVenta
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.ListaTotalXVenta(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio, intMes, intDia)
    End Function

    Public Function GetListarAllVentasInformeGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime, pago As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasInformeGeneral
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasInformeGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin, pago)
    End Function

    Public Function GetListarTransferenciaRecepcionInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra) Implements IContService.GetListarTransferenciaRecepcionInfGeneral
        Dim documentoventaBL As New documentocompraBL
        Return documentoventaBL.GetListarTransferenciaRecepcionInfGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function

    Public Function GetListaSumatoriaCompras(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As documentocompra Implements IContService.GetListaSumatoriaCompras
        Dim documentoventaBL As New documentocompraBL
        Return documentoventaBL.GetListaSumatoriaCompras(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio)
    End Function

    Public Function GetListarAllVentasGeneralAprobado(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasGeneralAprobado
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasGeneralAprobado(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarAllVentasGeneralesPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasGeneralesPeriodo
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasGeneralesPeriodo(intIdEstablec, strPeriodo)
    End Function

    Public Function GetListarAllVentasEntregablesDeMercaderia(intIdEstablec As Integer, strPeriodo As String, stridDocumento As Integer) As List(Of documentoventaAbarrotesDet) Implements IContService.GetListarAllVentasEntregablesDeMercaderia
        Dim documentoventaBL As New documentoventaAbarrotesDetBL
        Return documentoventaBL.GetListarAllVentasEntregablesDeMercaderia(intIdEstablec, strPeriodo, stridDocumento)
    End Function

    Public Function SaveGuiaRemisionEntregado(objDocumento As documento) As Integer Implements ServiceContract.IContService.SaveGuiaRemisionEntregado
        Dim documentoBL As New documentoGuiaBL
        Return documentoBL.SaveGuiaRemisionEntregado(objDocumento)
    End Function

    Public Function UbicarGuiaDetallePorIdDocumentoguia(intIdDocumento As Integer) As System.Collections.Generic.List(Of Business.Entity.documentoguiaDetalle) Implements ServiceContract.IContService.UbicarGuiaDetallePorIdDocumentoguia
        Dim documentoDetalleBL As New documentoguiaDetalleBL
        Return documentoDetalleBL.UbicarGuiaDetallePorIdDocumentoguia(intIdDocumento)
    End Function

    Public Sub SaveGuiaRemisionCondicion(objDocumento As List(Of documentoguiaDetalleCondicion), objDocumentoDet As List(Of documentoguiaDetalle)) Implements ServiceContract.IContService.SaveGuiaRemisionCondicion
        Dim documentoBL As New documentoGuiaDetalleCondicionBL
        documentoBL.SaveGuiaRemisionCondicion(objDocumento, objDocumentoDet)
    End Sub

    Function UbicarDocumentoGuiaDetCondicionFull(intIdDocumento As Integer) As List(Of documentoguiaDetalleCondicion) Implements ServiceContract.IContService.UbicarDocumentoGuiaDetCondicionFull
        Dim documentoBL As New documentoGuiaDetalleCondicionBL
        Return documentoBL.UbicarDocumentoGuiaDetCondicionFull(intIdDocumento)
    End Function

    Public Function GetUbicar_PorDocumento(intIdDocumento As Integer) As List(Of documentocompradetalle) Implements IContService.GetUbicar_PorDocumento
        Dim DocumentoCompraDetalleBL As New documentocompradetalleBL
        Return DocumentoCompraDetalleBL.GetUbicar_PorDocumento(intIdDocumento)
    End Function

    Public Function ListaTotalXCompraDetalleAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As List(Of documentocompradetalle) Implements IContService.ListaTotalXCompraDetalleAll
        Dim DocumentoCompraDetalleBL As New documentocompradetalleBL
        Return DocumentoCompraDetalleBL.ListaTotalXCompraDetalleAll(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio)
    End Function

    Public Function ListaComprasPorveedorOrArticulo(strEmpresa As String, intIdEstable As Integer, fecInic As DateTime, fecHasta As DateTime, idProv As Integer, tipo As String, nombreitem As String) As List(Of documentocompradetalle) Implements IContService.ListaComprasPorveedorOrArticulo
        Dim documentocompraBL As New documentocompradetalleBL
        Return documentocompraBL.ListaComprasPorveedorOrArticulo(strEmpresa, intIdEstable, fecInic, fecHasta, idProv, tipo, nombreitem)
    End Function

    Public Sub SaveGuiaRemisionCondicionTransferenciaAlmacenSC(objDocumento As List(Of documentoguiaDetalleCondicion), objDocumentoDet As List(Of documentoguiaDetalle), objListaAsiento As documento) Implements ServiceContract.IContService.SaveGuiaRemisionCondicionTransferenciaAlmacenSC
        Dim documentoBL As New documentoGuiaDetalleCondicionBL
        documentoBL.SaveGuiaRemisionCondicionTransferenciaAlmacenSC(objDocumento, objDocumentoDet, objListaAsiento)
    End Sub

    Public Function listarUbigeo() As List(Of ubigeo) Implements IContService.listarUbigeo
        Dim cajaBL As New ubigeoBL
        Return cajaBL.GetAllubigeo()
    End Function

    Public Function UbicarGuiaPendiente() As List(Of Business.Entity.documentoGuia) Implements ServiceContract.IContService.UbicarGuiaPendiente
        Dim documentoBL As New documentoGuiaBL
        Return documentoBL.UbicarGuiaPendiente()
    End Function

    Public Sub updateDocumentoTransferencia(objdocumento As documentoGuia) Implements IContService.updateDocumentoTransferencia
        Dim documentoBL As New documentoGuiaBL
        documentoBL.updateDocumentoTransferencia(objdocumento)
    End Sub

#End Region

    Public Function GetListaEstadoCuenta12(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta12
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetListaEstadoCuenta12(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetListaEstadoCuenta122(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta122
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetListaEstadoCuenta122(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta)
    End Function

    Public Function GetListaEstadoCuenta42(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta42
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetListaEstadoCuenta42(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta123133(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta123133
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta123133(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta13(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta13
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta13(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta14(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta14
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta14(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta1413(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta1413
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta1413(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta16(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta16
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta16(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta20al28(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta20al28
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta20al28(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta30al38(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta30al38
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta30al38(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta40(strEmpresa As String, intIdEstablecimiento As Integer, tipo As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta40
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta40(strEmpresa, intIdEstablecimiento, tipo)
    End Function

    Public Function GetUbicar_EstadoCuenta41(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta41
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta41(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta423433(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta423433
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta423433(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoCuenta43(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta43
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoCuenta43(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoXCuentaActivo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoXCuentaActivo
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoXCuentaActivo(strEmpresa, intIdEstablecimiento, cuenta)
    End Function

    Public Function GetUbicar_EstadoXCuentaPasivo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoXCuentaPasivo
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoXCuentaPasivo(strEmpresa, intIdEstablecimiento, cuenta)
    End Function

    Public Function GetListaEstadoCuenta11y18(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta11y18
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetListaEstadoCuenta11y18(strEmpresa, intIdEstablecimiento, tipoCuenta)
    End Function

    Public Function GetUbicar_EstadoCuenta20(idEmpresa As String, periodo As String) As List(Of totalesAlmacen) Implements IContService.GetUbicar_EstadoCuenta20
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetUbicar_EstadoCuenta20(idEmpresa, periodo)
    End Function

    Public Function GetLotes() As List(Of recursoCostoLote) Implements IContService.GetLotes
        Dim almacenBL As New recursoCostoLoteBL
        Return almacenBL.GetLotes()
    End Function

    Public Function ExisteCodigoLote(lote As String) As Boolean Implements IContService.ExisteCodigoLote
        Dim almacenBL As New recursoCostoLoteBL
        Return almacenBL.ExisteCodigoLote(lote)
    End Function

    Public Sub EditarConfiguracionGeneral(configBE As configuracionInicio) Implements IContService.EditarConfiguracionGeneral
        Dim configBL As New ConfiguracionInicioBL
        configBL.EditarConfiguracionGeneral(configBE)
    End Sub

    Public Function GetListaProtectosByProyGeneral(recurso As recursoCosto) As List(Of recursoCosto) Implements IContService.GetListaProtectosByProyGeneral
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetListaProtectosByProyGeneral(recurso)
    End Function

    Public Function GetListaProyectosBySubTipo(recurso As recursoCosto) As List(Of recursoCosto) Implements IContService.GetListaProyectosBySubTipo
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetListaProyectosBySubTipo(recurso)
    End Function

    Public Function GetCronogramaTrabajo(fechaprog As String, mes As Integer) As List(Of Cronograma) Implements IContService.GetCronogramaTrabajo
        Dim costoBL As New CronogramaBL
        Return costoBL.GetCronogramaTrabajo(fechaprog, mes)
    End Function

    Public Function GetListarPagosPorMes(tipoProg As String) As List(Of Cronograma) Implements IContService.GetListarPagosPorMes
        Dim costoBL As New CronogramaBL
        Return costoBL.GetListarPagosPorMes(tipoProg)
    End Function

    Public Function UbicarCronogramaFecha(TipoProg As String, FechaInicio As Date, FechaFin As Date) As List(Of Cronograma) Implements IContService.UbicarCronogramaFecha
        Dim costoBL As New CronogramaBL
        Return costoBL.UbicarCronogramaFecha(TipoProg, FechaInicio, FechaFin)
    End Function

    Public Function UbicarCronogramaVencidos(TipoProg As String) As List(Of Cronograma) Implements IContService.UbicarCronogramaVencidos
        Dim costoBL As New CronogramaBL
        Return costoBL.UbicarCronogramaVencidos(TipoProg)
    End Function

    Public Function GetCronogramaDetalleTipoMes(idprov As Integer, tipo As String, tipoEstado As String, mes As Integer, tipoProg As String, tipoMoneda As String) As List(Of Cronograma) Implements IContService.GetCronogramaDetalleTipoMes
        Dim costoBL As New CronogramaBL
        Return costoBL.GetCronogramaDetalleTipoMes(idprov, tipo, tipoEstado, mes, tipoProg, tipoMoneda)
    End Function

    Public Function GetCronogramaTipoAsientoMes(idprov As Integer, tipo As String, tipoEstado As String, mes As Integer, tipoProg As String, tipoMoneda As String) As List(Of Cronograma) Implements IContService.GetCronogramaTipoAsientoMes
        Dim costoBL As New CronogramaBL
        Return costoBL.GetCronogramaTipoAsientoMes(idprov, tipo, tipoEstado, mes, tipoProg, tipoMoneda)
    End Function

    Public Function UbicarCronogramaPorEntidad(idprov As Integer, tipoprov As String) As List(Of Cronograma) Implements IContService.UbicarCronogramaPorEntidad
        Dim costoBL As New CronogramaBL
        Return costoBL.UbicarCronogramaPorEntidad(idprov, tipoprov)
    End Function

    Public Function ConteoDeAsientosNoNegociados() As Integer Implements IContService.ConteoDeAsientosNoNegociados
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.ConteoDeAsientosNoNegociados()
    End Function

    Public Function ConteoDeNoNegociados() As Integer Implements IContService.ConteoDeNoNegociados
        Dim documentoBL As New documentocompraBL
        Return documentoBL.ConteoDeNoNegociados()
    End Function

    Public Function ConteoVencidosCronograma() As Integer Implements IContService.ConteoVencidosCronograma
        Dim documentoBL As New CronogramaBL
        Return documentoBL.ConteoVencidosCronograma()
    End Function

    Public Function GetConsultaCuentasPorpagar(be As documentocompra) As List(Of documentocompra) Implements IContService.GetConsultaCuentasPorpagar
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetConsultaCuentasPorpagar(be)
    End Function

    Public Function GetConsultaCuentasPorpagarTodosProveedores(be As documentocompra) As List(Of documentocompra) Implements IContService.GetConsultaCuentasPorpagarTodosProveedores
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetConsultaCuentasPorpagarTodosProveedores(be)
    End Function

    Public Sub GrabarCostoProducido(be As recursoCosto) Implements IContService.GrabarCostoProducido
        Dim documentoBL As New recursoCostoBL
        documentoBL.GrabarCostoOne_2(be)
    End Sub

    Public Function GetCantidadEntregadaProduccion(be As recursoCosto) As recursoCosto Implements IContService.GetCantidadEntregadaProduccion
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetCantidadEntregadaProduccion(be)
    End Function

    Public Function GetProductosProducidosEnPlanta(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetProductosProducidosEnPlanta
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetProductosProducidosEnPlanta(be)
    End Function

    Public Function UbicarCobrosPorAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarCobrosPorAsientoManualMNME
        Dim costoBL As New documentoLibroDiarioBL
        Return costoBL.UbicarCobrosPorAsientoManualMNME(strEmpresa, intIdEstablecimiento, strRuc)
    End Function

    Public Function UbicarCobrosPorAsientoManualRazon(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, moneda As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarCobrosPorAsientoManualRazon
        Dim costoBL As New documentoLibroDiarioBL
        Return costoBL.UbicarCobrosPorAsientoManualRazon(strEmpresa, intIdEstablecimiento, strRuc, moneda)
    End Function

    Public Function UbicarPagosPorAsientoManualRazon(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, moneda As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.UbicarPagosPorAsientoManualRazon
        Dim costoBL As New documentoLibroDiarioBL
        Return costoBL.UbicarPagosPorAsientoManualRazon(strEmpresa, intIdEstablecimiento, strRuc, moneda)
    End Function

    Public Function ConteoDeAsientosNoNegociadosCobro() As Integer Implements IContService.ConteoDeAsientosNoNegociadosCobro
        Dim cronogramaBL As New documentoLibroDiarioBL
        Return cronogramaBL.ConteoDeAsientosNoNegociadosCobro()
    End Function

    Public Function ConteoVencidosCobroCronograma() As Integer Implements IContService.ConteoVencidosCobroCronograma
        Dim cronogramaBL As New CronogramaBL
        Return cronogramaBL.ConteoVencidosCobroCronograma()
    End Function


    Public Function ConteoVentasNoNegociados() As Integer Implements IContService.ConteoVentasNoNegociados
        Dim cronogramaBL As New documentoventaAbarrotesBL
        Return cronogramaBL.ConteoVentasNoNegociados()
    End Function

    Public Function UbicarTodosVentaPorClienteMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoventaAbarrotes) Implements IContService.UbicarTodosVentaPorClienteMNME
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.UbicarTodosVentaPorClienteMNME(strEmpresa, intIdEstablecimiento)
    End Function


    Public Sub DeleteCronoDocumento(cronograma As List(Of Cronograma)) Implements IContService.DeleteCronoDocumento
        Dim cronogramaBL As New CronogramaBL
        cronogramaBL.DeleteCronoDocumento(cronograma)
    End Sub

    Public Function GetCronogramaCobroFecha(TipoProg As String, FechaInicio As Date, FechaFin As Date) As List(Of Cronograma) Implements IContService.GetCronogramaCobroFecha
        Dim cronogramaBL As New CronogramaBL
        Return cronogramaBL.GetCronogramaCobroFecha(TipoProg, FechaInicio, FechaFin)
    End Function

    Public Function GetListarCobrosPorMes(tipoProg As String) As List(Of Cronograma) Implements IContService.GetListarCobrosPorMes
        Dim cronogramaBL As New CronogramaBL
        Return cronogramaBL.GetListarCobrosPorMes(tipoProg)
    End Function

    Public Function GetListarCronogramaDpcumento(idDocumento As Integer) As List(Of Cronograma) Implements IContService.GetListarCronogramaDpcumento
        Dim cronogramaBL As New CronogramaBL
        Return cronogramaBL.GetListarCronogramaDpcumento(idDocumento)
    End Function

    Public Function UbicarCronogramaPorEntidadCobro(idprov As Integer, tipoprov As String) As List(Of Cronograma) Implements IContService.UbicarCronogramaPorEntidadCobro
        Dim cronogramaBL As New CronogramaBL
        Return cronogramaBL.UbicarCronogramaPorEntidadCobro(idprov, tipoprov)
    End Function

    Public Function UbicarCronogramaVencidosCobro(TipoProg As String) As List(Of Cronograma) Implements IContService.UbicarCronogramaVencidosCobro
        Dim cronogramaBL As New CronogramaBL
        Return cronogramaBL.UbicarCronogramaVencidosCobro(TipoProg)
    End Function

    Public Function GetOrdenesDeProduccionInfo(be As recursoCosto) As List(Of recursoCosto) Implements IContService.GetOrdenesDeProduccionInfo
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetOrdenesDeProduccionInfo(be)
    End Function

    Public Sub GetCerrarPresupuesto(be As recursoCosto) Implements IContService.GetCerrarPresupuesto
        Dim costoBL As New recursoCostoBL
        costoBL.GetCerrarPresupuesto(be)
    End Sub

    Public Sub GrabarRetornoProductosTerminados(objDocumento As documento) Implements IContService.GrabarRetornoProductosTerminados
        Dim compraBL As New documentocompraBL
        compraBL.GrabarRetornoProductosTerminados(objDocumento)
    End Sub

    Public Sub GetEliminarCierreTotal(be As recursoCosto) Implements IContService.GetEliminarCierreTotal
        Dim compraBL As New documentocompraBL
        compraBL.GetEliminarCierreTotal(be)
    End Sub

    Public Sub GrabarCambioTipoInventario(objDocumento As documento) Implements IContService.GrabarCambioTipoInventario
        Dim documentoBL As New documentocompraBL
        documentoBL.GrabarCambioTipoInventario(objDocumento)
    End Sub

    Public Sub GrabarProduccionParcial(be As recursoCosto) Implements IContService.GrabarProduccionParcial
        Dim compraBL As New recursoCostoBL
        compraBL.GrabarProduccionParcial(be)
    End Sub

    Public Function GetNumRecursosEnPlanta(be As recursoCosto) As Integer Implements IContService.GetNumRecursosEnPlanta
        Dim compraBL As New recursoCostoBL
        Return compraBL.GetNumRecursosEnPlanta(be)
    End Function

    Public Function GetNumRecursosConEntregaParcial(be As recursoCosto) As Integer Implements IContService.GetNumRecursosConEntregaParcial
        Dim compraBL As New recursoCostoBL
        Return compraBL.GetNumRecursosConEntregaParcial(be)
    End Function

    Public Sub CulminarOrdenProduccionParcial(Be As recursoCosto) Implements IContService.CulminarOrdenProduccionParcial
        Dim compraBL As New recursoCostoBL
        compraBL.CulminarOrdenProduccionParcial(Be)
    End Sub

    Public Sub GetEliminarCierreParcialTotal(be As recursoCosto) Implements IContService.GetEliminarCierreParcialTotal
        Dim compraBL As New documentocompraBL
        compraBL.GetEliminarCierreParcialTotal(be)
    End Sub

    Public Sub GetEliminarProductosEnPlanta(be As recursoCosto) Implements IContService.GetEliminarProductosEnPlanta
        Dim costoBL As New recursoCostoBL
        costoBL.GetEliminarProductosEnPlanta(be)
    End Sub

    Public Sub GetEliminarEnvioAalmacen(be As recursoCosto) Implements IContService.GetEliminarEnvioAalmacen
        Dim costoBL As New recursoCostoBL
        costoBL.GetEliminarEnvioAalmacen(be)
    End Sub

    Public Sub GetCulminarProduccion(be As recursoCosto) Implements IContService.GetCulminarProduccion
        Dim costoBL As New recursoCostoBL
        costoBL.GetCulminarProduccion(be)
    End Sub

    Public Function GetSelXtipoExistenciaVenta(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetSelXtipoExistenciaVenta
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetSelXtipoExistenciaVenta(be)
    End Function

    Public Function SaveCompraNotaDevolucionGasto(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer Implements IContService.SaveCompraNotaDevolucionGasto
        Dim documentoBL As New documentocompraBL
        Return documentoBL.SaveCompraNotaDevolucionGasto(objDocumento, nDocumentoCaja, nDocumentoSaldoVenta)
    End Function

    Public Function SumaNotasFinancierasDefault(intIdSecuencia As Integer) As documentocompradetalle Implements IContService.SumaNotasFinancierasDefault
        Dim cajaBL As New documentocompradetalleBL
        Return cajaBL.SumaNotasFinancierasDefault(intIdSecuencia)
    End Function

    Public Sub CambiarPeriodoCompra(be As documentocompra) Implements IContService.CambiarPeriodoCompra
        Dim compraBL As New documentocompraBL
        compraBL.CambiarPeriodoCompra(be)
    End Sub

    Public Sub CambiarPeriodoVenta(be As documentoventaAbarrotes) Implements IContService.CambiarPeriodoVenta
        Dim compraBL As New documentoventaAbarrotesBL
        compraBL.CambiarPeriodoVenta(be)
    End Sub

    Public Sub CambiarPeriodoLibroDiario(be As documentoLibroDiario) Implements IContService.CambiarPeriodoLibroDiario
        Dim compraBL As New documentoLibroDiarioBL
        compraBL.CambiarPeriodoLibroDiario(be)
    End Sub

    Public Sub EditarEmpresa(be As empresa, listaCierre As List(Of empresaCierreMensual)) Implements IContService.EditarEmpresa
        Dim empresaBL As New empresaBL
        empresaBL.EditarEmpresa(be, listaCierre)
    End Sub

    Public Function GetKardexByAnioAlmacenAll(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetKardexByAnioAlmacenAll
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetKardexByAnioAlmacenAll(be)
    End Function

    Public Function GetProductosPorAlmacen(intIdAlmacen As Integer) As List(Of totalesAlmacen) Implements IContService.GetProductosPorAlmacen
        Dim totalBL As New totalesAlmacenBL
        Return totalBL.GetProductosPorAlmacen(intIdAlmacen)
    End Function

    Public Function GetArticulosCompradosByPeriodo(be As documentocompra) As List(Of documentocompradetalle) Implements IContService.GetArticulosCompradosByPeriodo
        Dim comprasBL As New documentocompraBL
        Return comprasBL.GetArticulosCompradosByPeriodo(be)
    End Function

    Public Function GetVentasByFecha(intIdEstablec As Integer, fecha As Date) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasByFecha
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasByFecha(intIdEstablec, fecha)
    End Function

    Public Function CompensacionDocumentos(objDocumento As documento, objDoc As documento) As Integer Implements IContService.CompensacionDocumentos
        Dim documentoBL As New documentocompraBL
        Return documentoBL.CompensacionDocumentos(objDocumento, objDoc)
    End Function

    Public Function UbicarComprasXCompensar(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra) Implements IContService.UbicarComprasXCompensar
        Dim documentoBL As New documentocompraBL
        Return documentoBL.UbicarComprasXCompensar(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function GetConsultaCuentasPorpagarAnt(be As documentocompra) As List(Of documentocompra) Implements IContService.GetConsultaCuentasPorpagarAnt
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetConsultaCuentasPorpagarAnt(be)
    End Function

    Public Function UbicarVentaPorClienteXperiodo2Ant(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As String, intmoneda As String) As List(Of documentoventaAbarrotes) Implements IContService.UbicarVentaPorClienteXperiodo2Ant
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.UbicarVentaPorClienteXperiodo2Ant(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, intmoneda)
    End Function

    Public Function GetUbicarMovimientoLibroMayorFullMensual(strPeriodo As List(Of String), periodo As String, mesPer As String) As List(Of movimiento) Implements IContService.GetUbicarMovimientoLibroMayorFullMensual
        Dim compraBL As New LibroMayorRPT
        Return compraBL.GetUbicarMovimientoLibroMayorFullMensual(strPeriodo, periodo, mesPer)
    End Function

    Public Function GetCostoVentaMensual(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetCostoVentaMensual
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetCostoVentaMensual(be)
    End Function

    Public Function GetListado_cierreCostoVenta(cierreBE As cierreCostoVenta) As List(Of cierreCostoVenta) Implements IContService.GetListado_cierreCostoVenta
        Dim cierreInventarioBL As New cierreCostoVentaBL
        Return cierreInventarioBL.GetListado_cierreCostoVenta(cierreBE)
    End Function

    Public Sub GrabarListaCierreCostoVenta(lista As List(Of cierreCostoVenta), objDocumento As documento) Implements IContService.GrabarListaCierreCostoVenta
        Dim cierreBL As New cierreCostoVentaBL
        cierreBL.GrabarListaCierreCostoVenta(lista, objDocumento)
    End Sub

    Public Function GetComprobantesEnTransito(be As documentocompra) As List(Of documentocompra) Implements IContService.GetComprobantesEnTransito
        Dim inventarioBL As New InventarioMovimientoBL
        Return inventarioBL.GetComprobantesEnTransito(be)
    End Function

    Public Function GetExistenciaTransitoByCompra(be As documentocompra) As List(Of documentocompradetalle) Implements IContService.GetExistenciaTransitoByCompra
        Dim inventarioBL As New InventarioMovimientoBL
        Return inventarioBL.GetExistenciaTransitoByCompra(be)
    End Function

    Public Function GetListadoGastosConsolidados(be As recursoCosto) As List(Of recursoCostoDetalle) Implements IContService.GetListadoGastosConsolidados
        Dim costoBL As New recursoCostoDetalleBL
        Return costoBL.GetListadoGastosConsolidados(be)
    End Function

    Public Function GetItemsNoAsignadosFinanzas(documentoCaja As documentoCaja) As List(Of documentoCaja) Implements IContService.GetItemsNoAsignadosFinanzas
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetItemsNoAsignadosFinanzas(documentoCaja)
    End Function

    Public Function ListaTotalXCaja(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentoCaja Implements IContService.ListaTotalXCaja
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ListaTotalXCaja(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio, intMes, intDia)
    End Function

    Public Function ResumenCiereCaja(strEmpresa As String, intIdEstablecimiento As Integer, intIdCaja As Integer, estado As String) As List(Of documentoCaja) Implements IContService.ResumenCiereCaja
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ResumenCiereCaja(strEmpresa, intIdEstablecimiento, intIdCaja, estado)
    End Function

    Public Function ObtenerCajaOnlineXUsuario(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strperiodo As String, ByVal strEntidadFinanciera As String, listasuarios As List(Of String), tipo As String, fechainicio As DateTime, fechaFin As DateTime, intAnio As Integer) As List(Of documentoCaja) Implements ServiceContract.IContService.ObtenerCajaOnlineXUsuario
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineXUsuario(strIdEmpresa, intIdEstablecimiento, strperiodo, strEntidadFinanciera, listasuarios, tipo, fechainicio, fechaFin, intAnio)
    End Function

    Public Sub GrabarDetalleRecursoFinanza(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento)) Implements IContService.GrabarDetalleRecursoFinanza
        Dim costoBL As New recursoCostoDetalleBL
        costoBL.GrabarDetalleRecursoFinanza(be, listaAsiento)
    End Sub

    Public Function GetListadoRecursosPorProyectoGeneral(be As recursoCosto) As List(Of usp_GetRecursosByProyectoGeneral_Result) Implements IContService.GetListadoRecursosPorProyectoGeneral
        Dim costoBL As New recursoCostoDetalleBL
        Return costoBL.GetListadoRecursosPorProyectoGeneral(be)
    End Function

    Public Sub ActualizarDocumentoLibroDiarioASM(objLibro As documento) Implements IContService.ActualizarDocumentoLibroDiarioASM
        Dim DocumetoBL As New documentoLibroDiarioBL
        DocumetoBL.ActualizarDocumentoLibroDiarioASM(objLibro)
    End Sub

    Public Function GetResumenLibroDiarioByPeriodo(be As asiento) As List(Of asiento) Implements IContService.GetResumenLibroDiarioByPeriodo
        Dim asientoBL As New AsientoBL
        Return asientoBL.GetResumenLibroDiarioByPeriodo(be)
    End Function

    Public Function GetMovimientosKardexByMes(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento) Implements IContService.GetMovimientosKardexByMes
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetMovimientosKardexByMes(be, cierre)
    End Function

    Public Function GetMovimientosKardexByArticulo(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento) Implements IContService.GetMovimientosKardexByArticulo
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetMovimientosKardexByArticulo(be, cierre)
    End Function

    Public Function GetCierreContablePeriodo(be As asiento, periodoAnt As String) As List(Of movimiento) Implements IContService.GetCierreContablePeriodo
        Dim movimientoBL As New movimientoBL
        Return movimientoBL.GetCierreContablePeriodo(be, periodoAnt)
    End Function

    Public Function GetUbicar_empresaPeriodoPorID(idempresa As String, periodo As String, idCentroCostos As Integer) As empresaPeriodo Implements IContService.GetUbicar_empresaPeriodoPorID
        Dim empresaBL As New empresaPeriodoBL
        Return empresaBL.GetUbicar_empresaPeriodoPorID(idempresa, periodo, idCentroCostos)
    End Function

    Public Function EstadoMesCerrado(be As empresaCierreMensual) As Boolean Implements IContService.EstadoMesCerrado
        Dim cierreBL As New empresaCierreMensualBL
        Return cierreBL.EstadoMesCerrado(be)
    End Function

    Public Function GetCierresByEmpresa(be As empresaCierreMensual) As List(Of empresaCierreMensual) Implements IContService.GetCierresByEmpresa
        Dim cierreBL As New empresaCierreMensualBL
        Return cierreBL.GetCierresByEmpresa(be)
    End Function

    Public Sub EliminarCierre(be As empresaCierreMensual) Implements IContService.EliminarCierre
        Dim cierreBL As New empresaCierreMensualBL
        cierreBL.EliminarCierre(be)
    End Sub

    Public Sub GrabarCierrePeriodo(be As empresaCierreMensual, documento As documento) Implements IContService.GrabarCierrePeriodo
        Dim cierreBL As New empresaCierreMensualBL
        cierreBL.GrabarCierrePeriodo(be, documento)
    End Sub

    Public Function GetFilterArticulosStartWith(be As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetFilterArticulosStartWith
        Dim BL As New totalesAlmacenBL
        Return BL.GetFilterArticulosStartWith(be)
    End Function

    Public Function GetListadoProductosByAlmacen(be As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetListadoProductosByAlmacen
        Dim BL As New totalesAlmacenBL
        Return BL.GetListadoProductosByAlmacen(be)
    End Function

    Public Function GetUbicar_documentoCajaID(intIdDocumento As Integer) As documentoCaja Implements IContService.GetUbicar_documentoCajaID
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.GetUbicar_documentoCajaID(intIdDocumento)
    End Function

    Public Sub CambiarPeriodoCaja(be As documentoCaja) Implements IContService.CambiarPeriodoCaja
        Dim compraBL As New documentoCajaBL
        compraBL.CambiarPeriodoCaja(be)
    End Sub

    Public Function GenerarTXTcompras(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra) Implements IContService.GenerarTXTcompras
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GenerarTXTcompras(intIdEstablecimiento, strPeriodo, UsuarioCaja)
    End Function

    Public Function GenerarTXTventa(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GenerarTXTventa
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GenerarTXTventa(intIdEstablec, strPeriodo)
    End Function

    Public Sub GetChangeState(be As documentocompra) Implements IContService.GetChangeState
        Dim compraBL As New documentocompraBL
        compraBL.GetChangeState(be)
    End Sub

    Public Function GetComprasObservadas(be As documentocompra) As List(Of documentocompra) Implements IContService.GetComprasObservadas
        Dim compraBL As New documentocompraBL
        Return compraBL.GetComprasObservadas(be)
    End Function

    Public Function GrabarCambioArticulo(objDocumento As documento, art As detalleitems) As Integer Implements IContService.GrabarCambioArticulo
        Dim compraBL As New documentocompraBL
        Return compraBL.GrabarCambioArticulo(objDocumento, art)
    End Function

    Public Function GetCambiosDeArticulo(be As documentocompra) As List(Of documentocompra) Implements IContService.GetCambiosDeArticulo
        Dim compraBL As New documentocompraBL
        Return compraBL.GetCambiosDeArticulo(be)
    End Function

    Public Sub GetCurarKardexCaberas(be As List(Of totalesAlmacen)) Implements IContService.GetCurarKardexCaberas
        Dim totalesBL As New totalesAlmacenBL
        totalesBL.GetCurarKardexCaberas(be)
    End Sub

    Public Function GetHojaTrabajCompras(be As asiento) As List(Of usp_HojaTrabajoCompras_Result) Implements IContService.GetHojaTrabajCompras
        Dim hojaBL As New AsientoBL
        Return hojaBL.GetHojaTrabajCompras(be)
    End Function

    Public Function GetHojaTrabajoXmodulo(be As asiento) As List(Of usp_HojaTrabajoXmodulo_Result) Implements IContService.GetHojaTrabajoXmodulo
        Dim hojaBL As New AsientoBL
        Return hojaBL.GetHojaTrabajoXmodulo(be)
    End Function

    Public Function GetExistenComprasSuperiores(be As documentocompra) As Integer Implements IContService.GetExistenComprasSuperiores
        Dim compraBL As New documentocompraBL
        Return compraBL.GetExistenComprasSuperiores(be)
    End Function

    Public Sub CerrarByPeriodo(doc As documento) Implements IContService.CerrarByPeriodo
        Dim documentobl As New cierreinventarioBL
        documentobl.CerrarByPeriodo(doc)
    End Sub

    Public Function GetMovimientosKardexByMesAllAlmacen(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetMovimientosKardexByMesAllAlmacen
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetMovimientosKardexByMesAllAlmacen(be)
    End Function

    Public Function UpdateCotizacion(objDocumento As documento) As Integer Implements IContService.UpdateCotizacion
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.UpdateCotizacion(objDocumento)
    End Function

    Public Sub EliminarPedidos(documentoBE As documento) Implements IContService.EliminarPedidos
        Dim ventaBL As New documentoBL
        ventaBL.EliminarPedidos(documentoBE)
    End Sub

    Public Function CompraEsvalida(nDOcumento As documentocompra) As Boolean Implements IContService.CompraEsvalida
        Dim ventaBL As New documentocompraBL
        Return ventaBL.ValidarDocumentoNro(nDOcumento)
    End Function

    Public Function GetEstadoCajasTodosDetalleByMensual(be As documentoCaja, periodoAnt As String) As List(Of estadosFinancieros) Implements IContService.GetEstadoCajasTodosDetalleByMensual
        Dim efBL As New estadosFinancierosBL
        Return efBL.GetEstadoCajasTodosDetalleByMensual(be, periodoAnt)
    End Function

    Public Function GetListaSubProyectos(recurso As recursoCosto) As List(Of recursoCosto) Implements IContService.GetListaSubProyectos
        Dim costoBL As New recursoCostoBL
        Return costoBL.GetListaSubProyectos(recurso)
    End Function

    Public Sub GrabarProyectoConstruccion(be As recursoCosto, besub As recursoCosto, listaentregable As List(Of recursoCosto), plan As List(Of cuentaplanContableEmpresa)) Implements IContService.GrabarProyectoConstruccion
        Dim costoBL As New recursoCostoBL
        costoBL.GrabarProyectoConstruccion(be, besub, listaentregable, plan)
    End Sub

    Public Function GetTieneArticulosEnTransitoCompra(be As documentocompra) As Boolean Implements IContService.GetTieneArticulosEnTransitoCompra
        Dim compraBL As New InventarioMovimientoBL
        Return compraBL.GetTieneArticulosEnTransitoCompra(be)
    End Function

    Public Sub InsertarNumeracionInicio(lista As List(Of numeracionBoletas), listaCentroCostos As List(Of centrocosto)) Implements IContService.InsertarNumeracionInicio
        Dim numeracionBL As New numeracionBoletasBL
        numeracionBL.InsertarNumeracionInicio(lista, listaCentroCostos)
    End Sub

    Public Sub InsertarNumeracionXUnidOrg(lista As List(Of numeracionBoletas)) Implements IContService.InsertarNumeracionXUnidOrg
        Dim numeracionBL As New numeracionBoletasBL
        numeracionBL.InsertarNumeracionXUnidOrg(lista)
    End Sub

    Public Sub EliminarCompensacion(idDocumentoOrigen As Integer) Implements IContService.EliminarCompensacion
        Dim DocumentoCompensacionBL As New CompensacionBL
        DocumentoCompensacionBL.EliminarCompensacion(idDocumentoOrigen)
    End Sub

    Public Function GetListarCuotasDocumento(idDocumento As Integer) As List(Of Cronograma) Implements IContService.GetListarCuotasDocumento
        Dim cronogramaBL As New CronogramaBL
        Return cronogramaBL.GetListarCuotasDocumento(idDocumento)
    End Function

    Public Function GetListar_almacenALL(idEmpresa As String) As List(Of almacen) Implements IContService.GetListar_almacenALL
        Dim almacenBL As New almacenBL
        Return almacenBL.GetListar_almacenALL(idEmpresa)
    End Function

    Public Function TienenAperturaInventario(be As documentoLibroDiario) As Boolean Implements IContService.TienenAperturaInventario
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.TienenAperturaInventario(be)
    End Function

    Public Function TieneProveedoresApertura(be As documentocompra) As Boolean Implements IContService.TieneProveedoresApertura
        Dim compraBL As New documentocompraBL
        Return compraBL.TieneProveedoresApertura(be)
    End Function

    Public Function TieneClientesApertura(be As documentoventaAbarrotes) As Boolean Implements IContService.TieneClientesApertura
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.TieneClientesApertura(be)
    End Function

    Public Function ObtenerCajaOnlineAnual(strIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoCaja) Implements IContService.ObtenerCajaOnlineAnual
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineAnual(strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_EstadoXCuentaActivoInverso(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoXCuentaActivoInverso
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetUbicar_EstadoXCuentaActivoInverso(strEmpresa, intIdEstablecimiento, cuenta)
    End Function

    Public Function GetListaEstadoCuenta422(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta422
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetListaEstadoCuenta422(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta)
    End Function

    Public Function GetListaEstadoCuenta432(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta432
        Dim libroBL As New documentoLibroDiarioDetalleBL
        Return libroBL.GetListaEstadoCuenta432(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta)
    End Function

    Public Function GetTransferenciasByEmpresa(intIdEstablecimiento As Integer) As List(Of documentocompra) Implements IContService.GetTransferenciasByEmpresa
        Dim compraBL As New documentocompraBL
        Return compraBL.GetTransferenciasByEmpresa(intIdEstablecimiento)
    End Function

    Public Sub GrabarMembresia(be As membresia_Gym) Implements IContService.GrabarMembresia
        Dim membresiaBL As New membresia_GymBL
        membresiaBL.GrabarMembresia(be)
    End Sub

    Public Function UbicarMembresia(id As Integer) As membresia_Gym Implements IContService.UbicarMembresia
        Dim membresiaBL As New membresia_GymBL
        Return membresiaBL.UbicarMembresia(id)
    End Function

    Public Sub EditarMembresia(be As membresia_Gym) Implements IContService.EditarMembresia
        Dim membresiaBL As New membresia_GymBL
        membresiaBL.EditarMembresia(be)
    End Sub

    Public Function GetMembresias() As List(Of membresia_Gym) Implements IContService.GetMembresias
        Dim membresiaBL As New membresia_GymBL
        Return membresiaBL.GetMembresias()
    End Function

    Public Sub GrabarClienteMembresia(documento As documento) Implements IContService.GrabarClienteMembresia
        Dim membresiaBL As New membresia_GymBL
        membresiaBL.GrabarClienteMembresia(documento)
    End Sub

    Public Function GetRegistroMembresiasByPeriodo(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym) Implements IContService.GetRegistroMembresiasByPeriodo
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetRegistroMembresiasByPeriodo(be)
    End Function

    Public Function GetUbicarDocumentoMembresia(idDocumento As Integer) As Entidadmembresia_Gym Implements IContService.GetUbicarDocumentoMembresia
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetUbicarDocumentoMembresia(idDocumento)
    End Function

    Public Sub GetConfirmarInicio(be As Entidadmembresia_Gym, isEnabled As Boolean) Implements IContService.GetConfirmarInicio
        Dim membresiaBL As New Entidadmembresia_GymBL
        membresiaBL.GetConfirmarInicio(be, isEnabled)
    End Sub

    Public Function GetMembresiasPorVencer(entidadmembresia_Gym As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym) Implements IContService.GetMembresiasPorVencer
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetMembresiasPorVencer(entidadmembresia_Gym)
    End Function

    Public Function GetMembresiasPorVencerPeriodo(entidadmembresia_Gym As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym) Implements IContService.GetMembresiasPorVencerPeriodo
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetMembresiasPorVencerPeriodo(entidadmembresia_Gym)
    End Function

    Public Sub GrabarCongelamiento(be As membresia_congelamiento) Implements IContService.GrabarCongelamiento
        Dim membresiaBL As New membresia_congelamientoBL
        membresiaBL.GrabarCongelamiento(be)
    End Sub

    Public Function GetCongelamientoByDocumento(idDocumento As Integer) As List(Of membresia_congelamiento) Implements IContService.GetCongelamientoByDocumento
        Dim membresiaBL As New membresia_congelamientoBL
        Return membresiaBL.GetCongelamientoByDocumento(idDocumento)
    End Function

    Public Sub EliminarCongelamiento(idcongelamiento As Integer) Implements IContService.EliminarCongelamiento
        Dim membresiaBL As New membresia_congelamientoBL
        membresiaBL.EliminarCongelamiento(idcongelamiento)
    End Sub

    Public Function GetSumaCongelamientoByPeriodo(be As membresia_congelamiento) As List(Of membresia_congelamiento) Implements IContService.GetSumaCongelamientoByPeriodo
        Dim membresiaBL As New membresia_congelamientoBL
        Return membresiaBL.GetSumaCongelamientoByPeriodo(be)
    End Function

    Public Sub GrabarGrupoCongelamiento(be As List(Of membresia_congelamiento)) Implements IContService.GrabarGrupoCongelamiento
        Dim membresiaBL As New membresia_congelamientoBL
        membresiaBL.GrabarGrupoCongelamiento(be)
    End Sub

    Public Function BalanceGeneralMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As List(Of movimiento) Implements IContService.BalanceGeneralMensual
        Dim movBL As New movimientoBL
        Return movBL.BalanceGeneralMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaPagoComercialMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaPagoComercialMensual
        Dim movBL As New movimientoBL
        Return movBL.CuentaPagoComercialMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaPagoComercialRelMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaPagoComercialRelMensual
        Dim movBL As New movimientoBL
        Return movBL.CuentaPagoComercialRelMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaPagoLetrasMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaPagoLetrasMensual
        Dim movBL As New movimientoBL
        Return movBL.CuentaPagoLetrasMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaCobroComercialMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaCobroComercialMensual
        Dim movBL As New movimientoBL
        Return movBL.CuentaCobroComercialMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaAnticiposMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaAnticiposMensual
        Dim movBL As New movimientoBL
        Return movBL.CuentaAnticiposMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaEntregaRendirMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaEntregaRendirMensual
        Dim movBL As New movimientoBL
        Return movBL.CuentaEntregaRendirMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function GetUbicar_EstadoCuenta41Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta41Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta41Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta423433Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta423433Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta423433Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta42Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta42Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta42Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta43Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta43Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta43Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta12Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta12Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta12Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta13Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta13Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta13Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta46Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta46Anual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta46Anual(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetListaEstadoCuenta46Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta46Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta46Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoXCuentaPasivoMensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa, intIdEstablecimiento, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta132Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta132Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta132Mensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta122Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta122Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta122Mensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoXCuentaActivoMensual(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoXCuentaActivoMensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoXCuentaActivoMensual(strEmpresa, intIdEstablecimiento, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta123133Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta123133Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta123133Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta14Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta14Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta14Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta16Mensual(strEmpresa As String, intIdEstablecimiento As Integer, PeriodoCont As String) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta16Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta16Mensual(strEmpresa, intIdEstablecimiento, PeriodoCont)
    End Function

    Public Function GetListaEstadoCuenta16Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta16Anual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta16Anual(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetListaEstadoCuenta16Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta16Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta16Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta1413Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta1413Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta1413Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta30al38Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta30al38Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta30al38Mensual(strEmpresa, intIdEstablecimiento, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta422Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta422Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta422Mensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta432Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta432Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta432Mensual(strEmpresa, intIdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoXCuentaActivoInversoMensual(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoXCuentaActivoInversoMensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoXCuentaActivoInversoMensual(strEmpresa, intIdEstablecimiento, cuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetListaEstadoCuenta11y18Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetListaEstadoCuenta11y18Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetListaEstadoCuenta11y18Mensual(strEmpresa, intIdEstablecimiento, tipoCuenta, FechaInicio, FechaFin)
    End Function

    Public Function GetUbicar_EstadoCuenta40Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipo As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle) Implements IContService.GetUbicar_EstadoCuenta40Mensual
        Dim movBL As New documentoLibroDiarioDetalleBL
        Return movBL.GetUbicar_EstadoCuenta40Mensual(strEmpresa, intIdEstablecimiento, tipo, FechaInicio, FechaFin)
    End Function

    Public Function ObtenerCajaOnlineMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As List(Of documentoCaja) Implements IContService.ObtenerCajaOnlineMensual
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function GetMaximoMinimoFechaCongelamiento(be As membresia_congelamiento) As membresia_congelamiento Implements IContService.GetMaximoMinimoFechaCongelamiento
        Dim documentoBL As New membresia_congelamientoBL
        Return documentoBL.GetMaximoMinimoFechaCongelamiento(be)
    End Function

    Public Sub GetCambiarEstado(membresia_Gym As membresia_Gym) Implements IContService.GetCambiarEstado
        Dim membresiaBL As New membresia_GymBL
        membresiaBL.GetCambiarEstado(membresia_Gym)
    End Sub

    Public Function GetMembresiasByStatus(be As membresia_Gym) As List(Of membresia_Gym) Implements IContService.GetMembresiasByStatus
        Dim membresiaBL As New membresia_GymBL
        Return membresiaBL.GetMembresiasByStatus(be)
    End Function

    Public Function GetDocumentoCajaMembresiaByDocumento(iddocumento As Integer) As Entidadmembresia_Gym Implements IContService.GetDocumentoCajaMembresiaByDocumento
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetDocumentoCajaMembresiaByDocumento(iddocumento)
    End Function

    Public Function GetCuentasFinancierasEmpresaXtipo(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipo_Result) Implements IContService.GetCuentasFinancierasEmpresaXtipo
        Dim cuentaFinancieraBL As New estadosFinancierosBL
        Return cuentaFinancieraBL.GetCuentasFinancierasEmpresaXtipo(be)
    End Function

    Public Function GetCuentasFinancierasEmpresaXtipoXidCaja(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipoXIdCaja_Result) Implements IContService.GetCuentasFinancierasEmpresaXtipoXidCaja
        Dim cuentaFinancieraBL As New estadosFinancierosBL
        Return cuentaFinancieraBL.GetCuentasFinancierasEmpresaXtipoXidCaja(be)
    End Function

    Public Function GrabarPagoMembresia(objDocumentoBE As documento) As Integer Implements IContService.GrabarPagoMembresia
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GrabarPagoMembresia(objDocumentoBE)
    End Function

    Public Sub EliminarPagoMembresia(documentoBE As documento) Implements IContService.EliminarPagoMembresia
        Dim cajaBL As New documentoBL
        cajaBL.EliminarPagoMembresia(documentoBE)
    End Sub

    Public Function GetRegistroMembresiasByEmpresa(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym) Implements IContService.GetRegistroMembresiasByEmpresa
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetRegistroMembresiasByEmpresa(be)
    End Function

    Public Function GetMembresiaActivaXSocio(be As Entidadmembresia_Gym) As Entidadmembresia_Gym Implements IContService.GetMembresiaActivaXSocio
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetMembresiaActivaXSocio(be)
    End Function

    Public Function GetMembresiasPorStatusMembresiaXfecha(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym) Implements IContService.GetMembresiasPorStatusMembresiaXfecha
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetMembresiasPorStatusMembresiaXfecha(be)
    End Function

    Public Sub GetMembresiasVencidasDelDia(be As List(Of Entidadmembresia_Gym)) Implements IContService.GetMembresiasVencidasDelDia
        Dim membresiaBL As New Entidadmembresia_GymBL
        membresiaBL.GetMembresiasVencidasDelDia(be)
    End Sub

    Public Function GetMembresiasPorStatusMembresiaXfechaConteo(be As Entidadmembresia_Gym) As Integer Implements IContService.GetMembresiasPorStatusMembresiaXfechaConteo
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetMembresiasPorStatusMembresiaXfechaConteo(be)
    End Function

    Public Function CuentaVentasNetasMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaVentasNetasMensual
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaVentasNetasMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaVentasNetas2Mensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaVentasNetas2Mensual
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaVentasNetas2Mensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaCostoVentaMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaCostoVentaMensual
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaCostoVentaMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaUtilidadOperativaMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaUtilidadOperativaMensual
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaUtilidadOperativaMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function CuentaOtrosIngresoMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento Implements IContService.CuentaOtrosIngresoMensual
        Dim asientoBL As New movimientoBL
        Return asientoBL.CuentaOtrosIngresoMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Sub GetEliminarMembresia(be As Entidadmembresia_Gym) Implements IContService.GetEliminarMembresia
        Dim membresiaBL As New Entidadmembresia_GymBL
        membresiaBL.GetEliminarMembresia(be)
    End Sub

    Public Sub EliminarPrecio(configuracionPrecioProducto As configuracionPrecioProducto) Implements IContService.EliminarPrecio
        Dim precioBL As New ConfiguracionPrecioProductoBL
        precioBL.EliminarPrecio(configuracionPrecioProducto)
    End Sub

    Public Function GetProveedoresXpagar(anio As Integer, empresa As String) As List(Of usp_GetProveedoresXpagar_Result) Implements IContService.GetProveedoresXpagar
        Dim cuentasBL As New documentocompraBL
        Return cuentasBL.GetProveedoresXpagar(anio, empresa)
    End Function

    Public Function GetPagosPendienteXproveedor(idEntidad As Integer, anio As Integer) As List(Of usp_GetCuentasXpagarXproveedorAnual_Result) Implements IContService.GetPagosPendienteXproveedor
        Dim cuentasBL As New documentocompraBL
        Return cuentasBL.GetPagosPendienteXproveedor(idEntidad, anio)
    End Function

    Public Function GrabarSocioGym(entidadBE As entidad) As Integer Implements IContService.GrabarSocioGym
        Dim socioBL As New entidadBL
        Return socioBL.GrabarSocioGym(entidadBE)
    End Function

    Public Function GetMembresiasContratadasXSocio(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym) Implements IContService.GetMembresiasContratadasXSocio
        Dim membresiaBL As New Entidadmembresia_GymBL
        Return membresiaBL.GetMembresiasContratadasXSocio(be)
    End Function

    Public Function GetUbicaCierreResultado(strIdEmpresa As String, anioPeriodo As String, mesPeriodo As String) As List(Of cierreResultados) Implements IContService.GetUbicaCierreResultado
        Dim empresaBL As New cierreResultadosBL()
        Return empresaBL.GetUbicaCierreResultado(strIdEmpresa, anioPeriodo, mesPeriodo)
    End Function

    Public Function GetUbicaCierrePorPeriodo(strIdEmpresa As String, periodo As String) As cierreResultados Implements IContService.GetUbicaCierrePorPeriodo
        Dim empresaBL As New cierreResultadosBL()
        Return empresaBL.GetObtenerCierrePorPeriodo(strIdEmpresa, periodo)
    End Function

    Public Sub GrabarActividadPersonalGym(be As actividadPersonal) Implements IContService.GrabarActividadPersonalGym
        Dim actividadBL As New actividadPersonalBL
        actividadBL.GrabarActividad(be)
    End Sub

    Public Sub GetDetraccionChangeStateByDocumento(be As documentocompra) Implements IContService.GetDetraccionChangeStateByDocumento
        Dim impuestoBL As New documentocompraBL
        impuestoBL.GetDetraccionChangeStateByDocumento(be)
    End Sub

    Public Sub GetChangeStatusArticuloRange(listaInventario As List(Of totalesAlmacen)) Implements IContService.GetChangeStatusArticuloRange
        Dim inventarioBL As New totalesAlmacenBL
        inventarioBL.GetChangeStatusArticuloRange(listaInventario)
    End Sub

    Public Function GetActividadesEmpresa(be As actividadPersonal) As List(Of actividadPersonal) Implements IContService.GetActividadesEmpresa
        Dim actividadesBL As New actividadPersonalBL
        Return actividadesBL.GetActividadesEmpresa(be)
    End Function

    Public Function GetUbicarActividadGYM(idActividad As Integer) As actividadPersonal Implements IContService.GetUbicarActividadGYM
        Dim actividadesBL As New actividadPersonalBL
        Return actividadesBL.GetUbicarActividadGYM(idActividad)
    End Function

    Public Function GetUbicarActividadGYMDetalle(idActividad As Integer) As List(Of clasehorarios) Implements IContService.GetUbicarActividadGYMDetalle
        Dim actividadesBL As New clasehorariosBL
        Return actividadesBL.GetUbicarActividadGYMDetalle(idActividad)
    End Function

    Public Sub EditarActividadGym(be As actividadPersonal) Implements IContService.EditarActividadGym
        Dim actividadesBL As New actividadPersonalBL
        actividadesBL.EditarActividadGym(be)
    End Sub

    Public Function ObtenerCanDisponibleProdct(bt As totalesAlmacen) As totalesAlmacen Implements IContService.ObtenerCanDisponibleProduct
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.ObtenerCanDisponibleProduct(bt)
    End Function

    Public Sub EditarMovimientosContablesByAsiento(movimiento As movimiento) Implements IContService.EditarMovimientosContablesByAsiento
        Dim movimientoBL As New movimientoBL
        movimientoBL.EditarMovimientosContablesByAsiento(movimiento)
    End Sub

    Public Sub ReingresarAsientoContable(objAsiento As asiento) Implements IContService.ReingresarAsientoContable
        Dim asientoBL As New AsientoBL
        asientoBL.ReingresarAsientoContable(objAsiento)
    End Sub

    Public Sub EliminarAsigancionDeAsientoInventario(be As documentocompra) Implements IContService.EliminarAsigancionDeAsientoInventario
        Dim compraBL As New documentocompraBL
        compraBL.EliminarAsigancionDeAsientoInventario(be)
    End Sub

    Public Function LoadEstructuraLibroDiario(strEmpresa As String, strPeriodo As String) As List(Of cuentaplanContableEmpresa) Implements IContService.LoadEstructuraLibroDiario
        Dim cuentaplanContableEmpresaBL As New cuentaplanContableEmpresaBL()
        Return cuentaplanContableEmpresaBL.LoadEstructuraLibroDiario(strEmpresa, strPeriodo)
    End Function

    Public Function TxtPleLibroDiario(periodo As String, idempresa As String) As List(Of usp_PleLibroDiario_Result) Implements IContService.TxtPleLibroDiario
        Dim movimeintoBL As New movimientoBL
        Return movimeintoBL.TxtPleLibroDiario(periodo, idempresa)
    End Function

    Public Function GetClientesXcobrar(anio As Integer, empresa As String) As List(Of usp_GetClientesXcobrar_Result) Implements IContService.GetClientesXcobrar
        Dim compraBL As New documentocompraBL
        Return compraBL.GetClientesXcobrar(anio, empresa)
    End Function

    Public Function GetCobrosPendienteXcliente(idEntidad As Integer, anio As Integer) As List(Of usp_GetCuentasXcobrarXclienteAnual_Result) Implements IContService.GetCobrosPendienteXcliente
        Dim compraBL As New documentocompraBL
        Return compraBL.GetCobrosPendienteXcliente(idEntidad, anio)
    End Function

    Public Function StockEliminarNotaVenta(idDocVenta As Integer) As Integer Implements IContService.StockEliminarNotaVenta
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.StockEliminarNotaVenta(idDocVenta)
    End Function

    Public Function GeTipoCambioXfecha(idEmpresa As String, fecha As Date, intIdEstablecimiento As Integer) As tipoCambio Implements IContService.GeTipoCambioXfecha
        Dim tipocambioBL As New tipoCambioBL
        Return tipocambioBL.GeTipoCambioXfecha(idEmpresa, fecha, intIdEstablecimiento)
    End Function

    Public Sub GrabarClienteSoftPack(be As clientesSoftPack, empresaBE As empresa, listaCentoCosto As List(Of centrocosto)) Implements IContService.GrabarClienteSoftPack
        Dim clienteBL As New clientesSoftPackBL
        clienteBL.Save(be, empresaBE, listaCentoCosto)
    End Sub

    Public Function GetEmpresasClientes(rucCliente As String) As List(Of clientesSoftPack) Implements IContService.GetEmpresasClientes
        Dim clienteBL As New clientesSoftPackBL
        Return clienteBL.GetEmpresasClientes(rucCliente)
    End Function

    Public Function GetProductoClientesXID(ClienteID As String) As clientesSoftPack Implements IContService.GetProductoClientesXID
        Dim clienteBL As New clientesSoftPackBL
        Return clienteBL.GetProductoClientesXID(ClienteID)
    End Function

    Public Function GetEmpresasXcliente(idclientespk As Integer) As List(Of empresa) Implements IContService.GetEmpresasXcliente
        Dim empresaBL As New empresaBL
        Return empresaBL.GetEmpresasXcliente(idclientespk)
    End Function

    Public Sub EditarV00(configBE As configuracionInicio) Implements IContService.EditarV00
        Dim configuracionBL As New ConfiguracionInicioBL
        configuracionBL.EditarV00(configBE)
    End Sub

    Public Sub GrabarProyectoGeneral(be As recursoCosto, besub As recursoCosto, listaentregable As List(Of recursoCosto)) Implements IContService.GrabarProyectoGeneral
        Dim costoBL As New recursoCostoBL
        costoBL.GrabarProyectoGeneral(be, besub, listaentregable)
    End Sub

    Public Function GetEntregablesXProyecto(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto) Implements IContService.GetEntregablesXProyecto
        Dim recursoBL As New recursoCostoBL
        Return recursoBL.GetEntregablesXProyecto(idEmpresa, idEstable)
    End Function

    Public Function ListaRecursosCostoEntregable(compraBE As documentocompra, idEntregable As Integer) As List(Of documentocompradetalle) Implements IContService.ListaRecursosCostoEntregable
        Dim recursoBL As New documentocompraBL
        Return recursoBL.ListaRecursosCostoEntregable(compraBE, idEntregable)
    End Function

    Public Function ListaRecursosCostoLibroEntregable(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle) Implements IContService.ListaRecursosCostoLibroEntregable
        Dim recursoBL As New documentoLibroDiarioBL
        Return recursoBL.ListaRecursosCostoLibroEntregable(compraBE)
    End Function

    Public Function ListaRecursosCostoInventarioEntregables(compraBE As documentocompra) As List(Of documentocompradetalle) Implements IContService.ListaRecursosCostoInventarioEntregables
        Dim costoBL As New documentocompraBL
        Return costoBL.ListaRecursosCostoInventarioEntregables(compraBE)
    End Function

    Public Function GetProyectosAll(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto) Implements IContService.GetProyectosAll
        Dim recursoBL As New recursoCostoBL
        Return recursoBL.GetProyectosAll(idEmpresa, idEstable)
    End Function

    Public Function CierreDeEntregables(fechaPeriodo As DateTime, idEmpresa As String, idestable As Integer) As List(Of recursoCostoDetalle) Implements IContService.CierreDeEntregables
        Dim recursoBL As New recursoCostoBL
        Return recursoBL.CierreDeEntregables(fechaPeriodo, idEmpresa, idestable)
    End Function

    Public Function GetListadoRecursosPorEntregable(idEntregable As Integer, fechaPeriodo As DateTime) As List(Of recursoCostoDetalle) Implements IContService.GetListadoRecursosPorEntregable
        Dim costoBL As New recursoCostoDetalleBL
        Return costoBL.GetListadoRecursosPorEntregable(idEntregable, fechaPeriodo)
    End Function

    Public Function GetRecuperarAporteExistencia(be As documento) As documentoLibroDiario Implements IContService.GetRecuperarAporteExistencia
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.GetRecuperarAporteExistencia(be)
    End Function

    Public Sub GrabaritemExistenciaInicio(nuevoarticulo As detalleitems, item As totalesAlmacen, inv As InventarioMovimiento) Implements IContService.GrabaritemExistenciaInicio
        Dim documentoBL As New documentoLibroDiarioBL
        documentoBL.GrabaritemExistenciaInicio(nuevoarticulo, item, inv)
    End Sub

    Public Function GetListaInicioExistencia(fechaInicio As Date, idempresa As String, almacen As Integer) As List(Of InventarioMovimiento) Implements IContService.GetListaInicioExistencia
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetListaInicioExistencia(fechaInicio, idempresa, almacen)
    End Function

    Public Sub EditarArticuloInicio(inv As InventarioMovimiento) Implements IContService.EditarArticuloInicio
        Dim invBL As New InventarioMovimientoBL
        invBL.EditarArticuloInicio(inv)
    End Sub

    Public Function ObtenerCajaUsuarioFull(empresa As String, idEstable As Integer) As List(Of cajaUsuario) Implements IContService.ObtenerCajaUsuarioFull
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.ObtenerCajaUsuarioFull(empresa, idEstable)
    End Function

    Public Function GetProductosXvencerMes(empresa As String, anio As Integer, mes As Integer, TipoExistencia As String, intIdAlmacen As Integer) As List(Of totalesAlmacen) Implements IContService.GetProductosXvencerMes
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetProductosXvencerMes(empresa, anio, mes, TipoExistencia, intIdAlmacen)
    End Function

    Public Function GetUbicarDetalleCompraLote(intIdDocumento As Integer) As List(Of documentocompradetalle) Implements IContService.GetUbicarDetalleCompraLote
        Dim documentoBL As New documentocompradetalleBL
        Return documentoBL.GetUbicarDetalleCompraLote(intIdDocumento)
    End Function

    Public Sub EditarCompra(documentoBE As documento) Implements IContService.EditarCompra
        Dim documentoBL As New documentocompraBL
        documentoBL.EditarCompra(documentoBE)
    End Sub

    Public Sub EliminarCompra(documentoBE As documento) Implements IContService.EliminarCompra
        Dim documentoBL As New documentocompraBL
        documentoBL.EliminarCompra(documentoBE)
    End Sub

    Public Sub EditarOtraEntrada(objDocumento As documento) Implements IContService.EditarOtraEntrada
        Dim documentoBL As New documentocompraBL
        documentoBL.EditarOtraEntrada(objDocumento)
    End Sub

    Public Sub EliminarEntradainv(documentoBE As documento) Implements IContService.EliminarEntradainv
        Dim documentoBL As New documentocompraBL
        documentoBL.EliminarEntradainv(documentoBE)
    End Sub

    Public Sub EditarOtraSalida(objDocumento As documento) Implements IContService.EditarOtraSalida
        Dim documentoBL As New documentocompraBL
        documentoBL.EditarOtraSalida(objDocumento)
    End Sub

    Public Sub EliminarSalidaInv(documentoBE As documento) Implements IContService.EliminarSalidaInv
        Dim documentoBL As New documentocompraBL
        documentoBL.EliminarSalidaInv(documentoBE)
    End Sub

    Public Sub EliminarVenta(documentoBE As documento) Implements IContService.EliminarVenta
        Dim documentoBL As New documentoventaAbarrotesBL
        documentoBL.EliminarVenta(documentoBE)
    End Sub

    Public Function GetUbicarArticuloLote(be As totalesAlmacen) As totalesAlmacen Implements IContService.GetUbicarArticuloLote
        Dim invBL As New totalesAlmacenBL
        Return invBL.GetUbicarArticuloLote(be)
    End Function

    Public Sub EditarArticuloLOTE(objInventario As totalesAlmacen) Implements IContService.EditarArticuloLOTE
        Dim invBL As New totalesAlmacenBL
        invBL.EditarArticuloLOTE(objInventario)
    End Sub

    Public Sub EliminarArticuloInicio(inv As InventarioMovimiento) Implements IContService.EliminarArticuloInicio
        Dim invBL As New totalesAlmacenBL
        invBL.EliminarArticuloInicio(inv)
    End Sub

    Public Function GetVentasDelDiaXTipoVenta(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasDelDiaXTipoVenta
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasDelDiaXTipoVenta(be)
    End Function

    Public Function GetComprasDelDiaxOperacion(be As documentocompra) As List(Of documentocompra) Implements IContService.GetComprasDelDiaxOperacion
        Dim compraBL As New documentocompraBL
        Return compraBL.GetComprasDelDiaxOperacion(be)
    End Function

    Public Function GetListarComprasPorAnioEmpresa(empresa As String, anio As String) As List(Of documentocompra) Implements IContService.GetListarComprasPorAnioEmpresa
        Dim compraBL As New documentocompraBL
        Return compraBL.GetListarComprasPorAnioEmpresa(empresa, anio)
    End Function

    Public Function GetCajasActivasTotalXdia(be As documentoCaja) As cajaUsuario Implements IContService.GetCajasActivasTotalXdia
        Dim cajausuarioBL As New CajaUsuarioBL
        Return cajausuarioBL.GetCajasActivasTotalXdia(be)
    End Function

    Public Function GetRentabilidad(be As InventarioMovimiento, fechaini As Date, fechafin As Date, tipo As String) As List(Of InventarioMovimiento) Implements IContService.GetRentabilidad
        Dim inventarioBL As New InventarioMovimientoBL
        Return inventarioBL.GetRentabilidad(be, fechaini, fechafin, tipo)
    End Function

    Public Function GetRentabilidadV2(be As InventarioMovimiento, fechaini As Date, fechafin As Date, tipo As String) As List(Of InventarioMovimiento) Implements IContService.GetRentabilidadV2
        Dim inventarioBL As New InventarioMovimientoBL
        Return inventarioBL.GetRentabilidadV2(be, fechaini, fechafin, tipo)
    End Function

    Public Function GetListarVentasPorAnio2(empresa As String, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasPorAnio2
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetListarVentasPorAnio2(empresa, strPeriodo)
    End Function


    Public Function GetProductosXvencerMesCount(empresa As String, anio As Integer, mes As Integer) As Integer Implements IContService.GetProductosXvencerMesCount
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetProductosXvencerMesCount(empresa, anio, mes)
    End Function

    Public Function GetProductosXvencerMesFull(empresa As String, anio As Integer, mes As Integer) As List(Of totalesAlmacen) Implements IContService.GetProductosXvencerMesFull
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetProductosXvencerMesFull(empresa, anio, mes)
    End Function

    Public Function GeDetalleCompraItemLote(codigoLote As Integer) As documentocompradetalle Implements IContService.GeDetalleCompraItemLote
        Dim compradetalleBL As New documentocompradetalleBL
        Return compradetalleBL.GeDetalleCompraItemLote(codigoLote)
    End Function

    Public Function GetLoteByID(codigoLote As Integer) As recursoCostoLote Implements IContService.GetLoteByID
        Dim loteBL As New recursoCostoLoteBL
        Return loteBL.GetLoteByID(codigoLote)
    End Function

    Public Function Grabar_Venta(objDocumento As documento) As Integer Implements IContService.Grabar_Venta
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.Grabar_Venta(objDocumento)
    End Function

    Public Sub EditarLote(recursoCostoLote As recursoCostoLote) Implements IContService.EditarLote
        Dim loteBL As New recursoCostoLoteBL
        loteBL.EditarLote(recursoCostoLote)
    End Sub

    Public Sub ProductosConexos(lista As List(Of totalesAlmacen)) Implements IContService.ProductosConexos
        Dim inventorySA As New totalesAlmacenBL
        inventorySA.ProductosConexos(lista)
    End Sub

    Public Function GetUbicarArticuloLoteVenta(be As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetUbicarArticuloLoteVenta
        Dim inventorySA As New totalesAlmacenBL
        Return inventorySA.GetUbicarArticuloLoteVenta(be)
    End Function

    Public Function ListProductsConexos(be As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.ListProductsConexos
        Dim inventorySA As New totalesAlmacenBL
        Return inventorySA.ListProductsConexos(be)
    End Function

    Public Sub CobrarVentaRapida(be As documento) Implements IContService.CobrarVentaRapida
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.CobrarVentaRapida(be)
    End Sub

    Public Sub CobrarVentaRapidaEspecal(be As documento) Implements IContService.CobrarVentaRapidaEspecal
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.CobrarVentaRapidaEspecal(be)
    End Sub

    Public Function ListaCompraDeServicios(compraBE As documentocompra, tipoCosteo As String) As List(Of documentocompradetalle) Implements IContService.ListaCompraDeServicios
        Dim recursoBL As New documentocompraBL
        Return recursoBL.ListaCompraDeServicios(compraBE, tipoCosteo)
    End Function

    Public Sub GrabarRecursoProduccion(be As List(Of recursoCostoDetalle)) Implements IContService.GrabarRecursoProduccion
        Dim recursocostodetalleBL As New recursoCostoDetalleBL
        recursocostodetalleBL.GrabarRecursoProduccion(be)
    End Sub

    Public Function ListaDeReconocimientos() As List(Of documentoLibroDiario) Implements IContService.ListaDeReconocimientos
        Dim documentoCompraBL As New documentoLibroDiarioBL
        Return documentoCompraBL.ListaDeReconocimientos()
    End Function

    Public Function GrabarReconocmientoIngreso(objDocumento As documento) As Object Implements IContService.GrabarReconocmientoIngreso
        Dim documentoBL As New documentoLibroDiarioBL
        Return documentoBL.GrabarReconocmientoIngreso(objDocumento)
    End Function

    Public Sub EnvioCostoGastoLibro(be As List(Of documentoLibroDiarioDetalle)) Implements IContService.EnvioCostoGastoLibro
        Dim invBL As New documentoLibroDiarioDetalleBL
        invBL.EnvioCostoGastoLibro(be)
    End Sub

    Public Function CuentasServicios(strEmpresa As String) As List(Of cuentaplanContableEmpresa) Implements IContService.CuentasServicios
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.CuentasServicios(strEmpresa)
    End Function

    Public Function GetListadoRecursosPorEntregableCosteado(idEntregable As Integer, fechaPeriodo As Date) As List(Of recursoCostoDetalle) Implements IContService.GetListadoRecursosPorEntregableCosteado
        Dim costoBL As New recursoCostoDetalleBL
        Return costoBL.GetListadoRecursosPorEntregableCosteado(idEntregable, fechaPeriodo)
    End Function

    Public Sub GrabarDetalleCosteoReal(be As List(Of recursoCostoDetalle), idEntregable As Integer, idDocumento As Integer, secuencia As Integer) Implements IContService.GrabarDetalleCosteoReal
        Dim documentoBL As New recursoCostoDetalleBL
        documentoBL.GrabarDetalleCosteoReal(be, idEntregable, idDocumento, secuencia)
    End Sub

    Public Function HistorialCosteo(idEntregable As Integer) As List(Of documentoLibroDiario) Implements IContService.HistorialCosteo
        Dim documentoCompraBL As New documentoLibroDiarioBL
        Return documentoCompraBL.HistorialCosteo(idEntregable)
    End Function

    Public Sub GrabarDocumentoProyecto(documento As documento, idEntregable As Integer, listaR As List(Of recursoCostoDetalle), estadoProy As String) Implements IContService.GrabarDocumentoProyecto
        Dim documentoBL As New documentoLibroDiarioBL
        documentoBL.GrabarDocumentoProyecto(documento, idEntregable, listaR, estadoProy)
    End Sub

    Public Sub EnvioDeServiciosAProduccion(be As List(Of documentocompradetalle)) Implements IContService.EnvioDeServiciosAProduccion
        Dim invBL As New documentocompradetalleBL
        invBL.EnvioDeServiciosAProduccion(be)
    End Sub

    Public Function ListarAsientosManualesSinCosteo(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle) Implements IContService.ListarAsientosManualesSinCosteo
        Dim recursoBL As New documentoLibroDiarioBL
        Return recursoBL.ListarAsientosManualesSinCosteo(compraBE)
    End Function

    Public Function ServiciosSinCosteo(compraBE As documentocompra) As List(Of documentocompradetalle) Implements IContService.ServiciosSinCosteo
        Dim recursoBL As New documentocompraBL
        Return recursoBL.ServiciosSinCosteo(compraBE)
    End Function

    Public Function CuentasCostoGastoSinModulo(strIdEmpresa As String) As List(Of cuentaplanContableEmpresa) Implements IContService.CuentasCostoGastoSinModulo
        Dim cuentaBL As New cuentaplanContableEmpresaBL
        Return cuentaBL.CuentasCostoGastoSinModulo(strIdEmpresa)
    End Function

    Public Function GetComprasPorAprobarPago(be As documentocompra) As List(Of documentocompra) Implements IContService.GetComprasPorAprobarPago
        Dim compraBL As New documentocompraBL
        Return compraBL.GetComprasPorAprobarPago(be)
    End Function

    Public Function GetCuentasPorPagarStatusCount(be As documentocompra) As Integer Implements IContService.GetCuentasPorPagarStatusCount
        Dim compraBL As New documentocompraBL
        Return compraBL.GetCuentasPorPagarStatusCount(be)
    End Function

    Public Sub StatusApruebaPagoFactura(be As documentocompra) Implements IContService.StatusApruebaPagoFactura
        Dim compraBL As New documentocompraBL
        compraBL.StatusApruebaPagoFactura(be)
    End Sub

    Public Function ListaDeReconocimientosxEntregable(idEntregable As Integer) As List(Of documentoLibroDiario) Implements IContService.ListaDeReconocimientosxEntregable
        Dim documentoCompraBL As New documentoLibroDiarioBL
        Return documentoCompraBL.ListaDeReconocimientosxEntregable(idEntregable)
    End Function


    Public Sub GrabarFacReconocimiento(be As documento) Implements IContService.GrabarFacReconocimiento
        Dim invBL As New documentoventaAbarrotesBL
        invBL.GrabarFacReconocimiento(be)
    End Sub

    Public Function GetAlertaIventarioSinStockConteo(be As totalesAlmacen) As Integer Implements IContService.GetAlertaIventarioSinStockConteo
        Dim invBL As New totalesAlmacenBL
        Return invBL.GetAlertaIventarioSinStockConteo(be)
    End Function

    Public Sub actualizarEstadoTransitoItem(documentocompradetalle As documentocompradetalle) Implements IContService.actualizarEstadoTransitoItem
        Dim invBL As New documentocompradetalleBL
        invBL.actualizarEstadoTransitoItem(documentocompradetalle)
    End Sub

    Public Function ObtenerMaxTabla(be As tabladetalle) As String Implements IContService.ObtenerMaxTabla
        Dim tablaBL As New tabladetalleBL
        Return tablaBL.ObtenerMaxTabla(be)
    End Function

    Public Sub CambiarStatusItem(be As tabladetalle) Implements IContService.CambiarStatusItem
        Dim tablaBL As New tabladetalleBL
        tablaBL.CambiarStatusItem(be)
    End Sub

    Public Function GetListPeriodos(be As cierreinventario) As List(Of cierreinventario) Implements IContService.GetListPeriodos
        Dim invBL As New cierreinventarioBL
        Return invBL.GetListPeriodos(be)
    End Function

    Public Function GetListAnios(be As cierreinventario) As List(Of cierreinventario) Implements IContService.GetListAnios
        Dim invBL As New cierreinventarioBL
        Return invBL.GetListAnios(be)
    End Function

    Public Function GetListMeses(be As cierreinventario) As List(Of cierreinventario) Implements IContService.GetListMeses
        Dim invBL As New cierreinventarioBL
        Return invBL.GetListMeses(be)
    End Function

    Public Function GetExistenciaTransitoByProveedor(be As documentocompra) As List(Of documentocompradetalle) Implements IContService.GetExistenciaTransitoByProveedor
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetExistenciaTransitoByProveedor(be)
    End Function

    Public Function GetListaTablaDetalleTodo(intIdTabla As Integer) As List(Of tabladetalle) Implements IContService.GetListaTablaDetalleTodo
        Dim tablaBL As New tabladetalleBL
        Return tablaBL.GetListaTablaDetalleTodo(intIdTabla)
    End Function

    Public Function ObtenerCuentasPorCobrarPorDetailsREC(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle) Implements IContService.ObtenerCuentasPorCobrarPorDetailsREC
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.ObtenerCuentasPorCobrarPorDetailsREC(strDocumentoAfectado)
    End Function

    Public Function SaveGroupCajaReconocimiento(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer Implements IContService.SaveGroupCajaReconocimiento
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaReconocimiento(objDocumentoBE, cajaUsuario)
    End Function

    Public Function GetItemsByDescripcion(be As detalleitems) As List(Of detalleitems) Implements IContService.GetItemsByDescripcion
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetItemsByDescripcion(be)
    End Function

    Public Sub GrabaritemExistenciaInicioExistente(nuevoarticulo As detalleitems, item As totalesAlmacen, inv As InventarioMovimiento) Implements IContService.GrabaritemExistenciaInicioExistente
        Dim itemBL As New documentoLibroDiarioBL
        itemBL.GrabaritemExistenciaInicioExistente(nuevoarticulo, item, inv)
    End Sub

    Public Sub CambiarEstadoAlmacen(almacen As almacen) Implements IContService.CambiarEstadoAlmacen
        Dim almacenbl As New almacenBL
        almacenbl.CambiarEstadoAlmacen(almacen)
    End Sub

    Public Function GrabarPercepcion(objDocumento As documento, nDocumentoNota As documento) As Integer Implements IContService.GrabarPercepcion
        Dim ventaBL As New documentocompraBL
        Return ventaBL.GrabarPercepcion(objDocumento, nDocumentoNota)
    End Function

    Public Function SaveRetencion(objDocumento As documento) As Integer Implements IContService.SaveRetencion
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.SaveRetencion(objDocumento)
    End Function

    Public Function GetListarPercepciones(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra) Implements IContService.GetListarPercepciones
        Dim documentoBL As New documentocompraBL
        Return documentoBL.GetListarPercepciones(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarRetenciones(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarRetenciones
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarRetenciones(intIdEstablec, strPeriodo)
    End Function

    Public Sub AnularCompra(documentoBE As documento) Implements IContService.AnularCompra
        Dim compraBL As New documentocompraBL
        compraBL.AnularCompra(documentoBE)
    End Sub

    Public Sub AnularOtrosPagos(be As documento) Implements IContService.AnularOtrosPagos
        Dim cajaBL As New documentoCajaBL
        cajaBL.AnularOtrosPagos(be)
    End Sub

    Public Function GetListaPersonasTrasnferenciasXconfirmar(be As documentocompra) As List(Of entidad) Implements IContService.GetListaPersonasTrasnferenciasXconfirmar
        Dim compraBL As New documentocompraBL
        Return compraBL.GetListaPersonasTrasnferenciasXconfirmar(be)
    End Function

    Public Sub AnularEntradainv(documentoBE As documento) Implements IContService.AnularEntradainv
        Dim compraBL As New documentocompraBL
        compraBL.AnularEntradainv(documentoBE)
    End Sub

    Public Sub AnularSalidaInv(documentoBE As documento) Implements IContService.AnularSalidaInv
        Dim compraBL As New documentocompraBL
        compraBL.AnularSalidaInv(documentoBE)
    End Sub

    Public Function GetListaTrasnferenciasPersonaXconfirmar(be As documentocompra) As List(Of documentocompra) Implements IContService.GetListaTrasnferenciasPersonaXconfirmar
        Dim compraBL As New documentocompraBL
        Return compraBL.GetListaTrasnferenciasPersonaXconfirmar(be)
    End Function

    Public Function ListaGuiasTransferenciasXEntidad(be As documentocompra) As List(Of documentoGuia) Implements IContService.ListaGuiasTransferenciasXEntidad
        Dim documentoGuiaBL As New documentoGuiaBL
        Return documentoGuiaBL.ListaGuiasTransferenciasXEntidad(be)
    End Function

    Public Function GetNumeracionCompra(be As documentocompra) As Integer Implements IContService.GetNumeracionCompra
        Dim compraBL As New documentocompraBL
        Return compraBL.GetNumeracionCompra(be)
    End Function

    Public Sub GrabarNotaCompra(be As documento) Implements IContService.GrabarNotaCompra
        Dim compraBL As New documentocompraBL
        compraBL.GrabarNotaCompra(be)
    End Sub

    Public Function GetNotasDeComprasPorPeriodo(be As documentocompra) As List(Of documentocompra) Implements IContService.GetNotasDeComprasPorPeriodo
        Dim compraBL As New documentocompraBL
        Return compraBL.GetNotasDeComprasPorPeriodo(be)
    End Function

    Public Sub AnularNotaDeCompra(documentoBE As documento) Implements IContService.AnularNotaDeCompra
        Dim compraBL As New documentocompraBL
        compraBL.AnularNotaDeCompra(documentoBE)
    End Sub

    Public Function GetMovimientosKardexByMesSustentado(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento) Implements IContService.GetMovimientosKardexByMesSustentado
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetMovimientosKardexByMesSustentado(be, cierre)
    End Function

    Public Function GetMovimientosKardexByArticuloSNAT(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento) Implements IContService.GetMovimientosKardexByArticuloSNAT
        Dim invBL As New InventarioMovimientoBL
        Return invBL.GetMovimientosKardexByArticuloSNAT(be, cierre)
    End Function

    Public Function Grabar_VentaList(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes) Implements IContService.Grabar_VentaList
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.Grabar_VentaList(listaDocumento)
    End Function

    Public Function GetListarNotaDeVentasPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarNotaDeVentasPeriodo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetListarNotaDeVentasPeriodo(intIdEstablec, strPeriodo)
    End Function

    Public Sub AnularNotaVenta(documentoBE As documento) Implements IContService.AnularNotaVenta
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.AnularNotaVenta(documentoBE)
    End Sub

    Public Function GetInventarioParaVentaAcumulado(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetInventarioParaVentaAcumulado
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetInventarioParaVentaAcumulado(objTotalBE)
    End Function

    Public Function GetInventarioParaVentaAcumuladoEspecial(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetInventarioParaVentaAcumuladoEspecial
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetInventarioParaVentaAcumuladoEspecial(objTotalBE)
    End Function

    Public Function GetProductsShopingOrOthers(objTotalBE As totalesAlmacen) As List(Of usp_GetProductsByEstable_Result) Implements IContService.GetProductsShopingOrOthers
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetProductsShopingOrOthers(objTotalBE)
    End Function

    Public Function GetInventarioParaVentaAcumuladoForma2(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetInventarioParaVentaAcumuladoForma2
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetInventarioParaVentaAcumuladoForma2(objTotalBE)
    End Function


    Public Function GetDetalleLoteXproducto(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetDetalleLoteXproducto
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetDetalleLoteXproducto(objTotalBE)
    End Function

    Public Function Grabar_VentaNota(objDocumento As documento) As Integer Implements IContService.Grabar_VentaNota
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.Grabar_VentaNota(objDocumento)
    End Function

    Public Function ResumenEntidadesFinancieras(cajaBE As cajaUsuario, listaPersona As List(Of Integer)) As List(Of documentoCaja) Implements IContService.ResumenEntidadesFinancieras
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ResumenEntidadesFinancieras(cajaBE, listaPersona)
    End Function

    Public Function ListaResumenXEntidad(listaidPersona As List(Of Integer), fechaInicio As DateTime, fechaFin As DateTime, tipo As String,
                             strEmpresa As String, idEstablec As Integer, intAnio As Integer,
                             intMes As Integer, intDia As Integer, IdEntidad As Integer) As documentoCaja Implements IContService.ListaResumenXEntidad
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.ListaResumenXEntidad(listaidPersona, fechaInicio, fechaFin, tipo, strEmpresa, idEstablec, intAnio, intMes, intDia, IdEntidad)
    End Function

    Public Function DocCajaUnitXDocumento(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja) Implements IContService.DocCajaUnitXDocumento
        Dim documentoventaBL As New documentoCajaBL
        Return documentoventaBL.DocCajaUnitXDocumento(cajaBE, listaPersona)
    End Function

    Public Function DocCajaXDocumento(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja) Implements IContService.DocCajaXDocumento
        Dim documentoventaBL As New documentoCajaBL
        Return documentoventaBL.DocCajaXDocumento(cajaBE, listaPersona)
    End Function

    Public Function DocCajaXItem(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle) Implements IContService.DocCajaXItem
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.DocCajaXItem(cajaBE, listaPersona)
    End Function

    Public Function ListadoCajaXEstado(caja As cajaUsuario) As List(Of cajaUsuario) Implements ServiceContract.IContService.ListadoCajaXEstado
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.ListadoCajaXEstado(caja)
    End Function

    Public Function DocCajaXResumenXID(cajaBE As documentoCaja) As documentoCaja Implements IContService.DocCajaXResumenXID
        Dim documentoventaBL As New documentoCajaBL
        Return documentoventaBL.DocCajaXResumenXID(cajaBE)
    End Function

    Public Function GenerarComprobanteVenta(objDocumento As documento) As Integer Implements IContService.GenerarComprobanteVenta
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GenerarComprobanteVenta(objDocumento)
    End Function

    Public Function GetPagoByComprobante(idDocumento As Integer) As List(Of documento) Implements IContService.GetPagoByComprobante
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetPagoByComprobante(idDocumento)
    End Function

    Public Function GetUbicarPagosComprobante(idDocumento As Integer) As List(Of documentoCajaDetalle) Implements IContService.GetUbicarPagosComprobante
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetUbicarPagosComprobante(idDocumento)
    End Function

    Public Sub GetActualizarImpresion(be As documentoventaAbarrotes) Implements IContService.GetActualizarImpresion
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.GetActualizarImpresion(be)
    End Sub

    Public Sub GrabarNotaCompraDirecta(be As documento) Implements IContService.GrabarNotaCompraDirecta
        Dim compraBL As New documentocompraBL
        compraBL.GrabarNotaCompraDirecta(be)
    End Sub

    Public Function Grabar_VentaEspecial(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes) Implements IContService.Grabar_VentaEspecial
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.Grabar_VentaEspecial(listaDocumento)
    End Function

    Public Sub GrabarCompraAdicionalLoteExistente(be As documento) Implements IContService.GrabarCompraAdicionalLoteExistente
        Dim compraBL As New documentocompraBL
        compraBL.GrabarCompraAdicionalLoteExistente(be)
    End Sub

    Public Function GetAlmacenesDistribuidosParaEmision(secuenciaCompra As Integer, idCompra As Integer) As List(Of documentoguiaDetalle) Implements IContService.GetAlmacenesDistribuidosParaEmision
        Dim guiaBL As New documentoguiaDetalleBL
        Return guiaBL.GetAlmacenesDistribuidosParaEmision(secuenciaCompra, idCompra)
    End Function

    Public Function GetInventarioGeneral(be As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetInventarioGeneral
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetInventarioGeneral(be)
    End Function

    Public Function GetTipoExistenciasByEmpresaConPrecios(empresa As String, tipo As String) As List(Of detalleitems) Implements IContService.GetTipoExistenciasByEmpresaConPrecios
        Dim precioBL As New detalleitemsBL
        Return precioBL.GetTipoExistenciasByEmpresaConPrecios(empresa, tipo)
    End Function

    Public Function GetExistenciasByempresaNombreFull(idempresa As String, nombre As String) As List(Of detalleitems) Implements IContService.GetExistenciasByempresaNombreFull
        Dim precioBL As New detalleitemsBL
        Return precioBL.GetExistenciasByempresaNombreFull(idempresa, nombre)
    End Function

    Public Function DocCajaXDocumentoVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja) Implements IContService.DocCajaXDocumentoVentas
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.DocCajaXDocumentoVentas(cajaBE, listaPersona)
    End Function

    Public Function DocCajaXDocumentoVentasElectronicas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja) Implements IContService.DocCajaXDocumentoVentasElectronicas
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.DocCajaXDocumentoVentasElectronicas(cajaBE, listaPersona)
    End Function

    Public Function DocCajaXItemVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle) Implements IContService.DocCajaXItemVentas
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.DocCajaXItemVentas(cajaBE, listaPersona)
    End Function

    Public Function DocCajaXItemVentasElectronicas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle) Implements IContService.DocCajaXItemVentasElectronicas
        Dim cajaBL As New documentoCajaDetalleBL
        Return cajaBL.DocCajaXItemVentasElectronicas(cajaBE, listaPersona)
    End Function

    Public Function GetDetalleLoteXproductoFullAlmacen(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetDetalleLoteXproductoFullAlmacen
        Dim almacenBL As New totalesAlmacenBL
        Return almacenBL.GetDetalleLoteXproductoFullAlmacen(objTotalBE)
    End Function

    Public Function GetDocumentosCompraByTipo(be As documentocompra) As List(Of documentocompra) Implements IContService.GetDocumentosCompraByTipo
        Dim almacenBL As New documentocompraBL
        Return almacenBL.GetDocumentosCompraByTipo(be)
    End Function

    Public Sub CobrarVentaJiuni(be As documento) Implements IContService.CobrarVentaJiuni
        Dim almacenBL As New documentoventaAbarrotesBL
        almacenBL.CobrarVentaJiuni(be)
    End Sub

    Public Sub CobrarVentaEspecial(be As documento) Implements IContService.CobrarVentaEspecial
        Dim almacenBL As New documentoventaAbarrotesBL
        almacenBL.CobrarVentaEspecial(be)
    End Sub

    Public Function Grabar_VentaEspecialSinLote(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes) Implements IContService.Grabar_VentaEspecialSinLote
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.Grabar_VentaEspecialSinLote(listaDocumento)
    End Function

    Public Function Grabar_VentaEspecialExistencia(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes) Implements IContService.Grabar_VentaEspecialExistencia
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.Grabar_VentaEspecialExistencia(listaDocumento)
    End Function

    Public Function Grabar_VentaNotaSinLote(objDocumento As documento) As Integer Implements IContService.Grabar_VentaNotaSinLote
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.Grabar_VentaNotaSinLote(objDocumento)
    End Function

    Public Function GetInventarioParaVentaAcumuladoCodigo(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetInventarioParaVentaAcumuladoCodigo
        Dim ivenarioBL As New totalesAlmacenBL
        Return ivenarioBL.GetInventarioParaVentaAcumuladoCodigo(objTotalBE)
    End Function

    Public Function GetInventarioParaVentaAcumuladoDolares(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetInventarioParaVentaAcumuladoDolares
        Dim productosBL As New totalesAlmacenBL
        Return productosBL.GetInventarioParaVentaAcumuladoDolares(objTotalBE)
    End Function

    Public Function BuscarFacturanoEnviadas(fecha As Date, tipoDoc As String, idEmpresa As String) As List(Of documentoventaAbarrotes) Implements IContService.BuscarFacturanoEnviadas
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarFacturanoEnviadas(fecha, tipoDoc, idEmpresa)
    End Function

    Public Function NotasCreditoBoleta(fecha As Date, tipoDoc As String, IdEmpresa As String) As List(Of documentoventaAbarrotes) Implements IContService.NotasCreditoBoleta
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.NotasCreditoBoleta(fecha, tipoDoc, IdEmpresa)
    End Function

    Public Sub ListaEnvioSunatResumen(lista As List(Of documentoventaAbarrotes), idNum As Integer, nroTicket As String) Implements IContService.ListaEnvioSunatResumen
        Dim documentoabarrotesbl As New documentoventaAbarrotesBL
        documentoabarrotesbl.ListaEnvioSunatResumen(lista, idNum, nroTicket)
    End Sub

    Public Sub ListaEnvioSunat(lista As List(Of documentoventaAbarrotes)) Implements IContService.ListaEnvioSunat
        Dim documentoabarrotesbl As New documentoventaAbarrotesBL
        documentoabarrotesbl.ListaEnvioSunat(lista)
    End Sub

    Public Function BuscarNotasXDocumento(idDoc As Integer) As List(Of documentoventaAbarrotes) Implements IContService.BuscarNotasXDocumento
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarNotasXDocumento(idDoc)
    End Function

    Public Function BuscarDocumentosFecha(fecha As Date, tipodoc As String) As List(Of documentoventaAbarrotes) Implements IContService.BuscarDocumentosFecha
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarDocumentosFecha(fecha, tipodoc)
    End Function

    Public Function GetUbicar_NotaXID(idDocumento As Integer) As documentoventaAbarrotes Implements IContService.GetUbicar_NotaXID
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetUbicar_NotaXID(idDocumento)
    End Function

    Public Sub UpdateEnvioSunat(doc As Integer) Implements IContService.UpdateEnvioSunat
        Dim documentoabarrotesbl As New documentoventaAbarrotesBL
        documentoabarrotesbl.UpdateEnvioSunat(doc)
    End Sub

    Public Sub CambiarEstadoItem(be As detalleitems) Implements IContService.CambiarEstadoItem
        Dim itemBL As New detalleitemsBL
        itemBL.CambiarEstadoItem(be)
    End Sub

    Public Function BuscarDocumentosAnuladosFecha(fecha As Date, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes) Implements IContService.BuscarDocumentosAnuladosFecha
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarDocumentosAnuladosFecha(fecha, tipodoc, ruc)
    End Function

    Public Sub ListaEnvioSunatAnulados(lista As List(Of documentoventaAbarrotes), nroTicket As String, idNum As Integer) Implements IContService.ListaEnvioSunatAnulados
        Dim documentoabarrotesbl As New documentoventaAbarrotesBL
        documentoabarrotesbl.ListaEnvioSunatAnulados(lista, nroTicket, idNum)
    End Sub

    Public Sub SaveOferta(be As oferta) Implements IContService.SaveOferta
        Dim ofertaBL As New ofertaBL
        ofertaBL.SaveOferta(be)
    End Sub

    Public Function OfertaSel(be As oferta) As oferta Implements IContService.OfertaSel
        Dim ofertaBL As New ofertaBL
        Return ofertaBL.OfertaSel(be)
    End Function

    Public Function OfertaSelAll(be As oferta) As List(Of oferta) Implements IContService.OfertaSelAll
        Dim ofertaBL As New ofertaBL
        Return ofertaBL.OfertaSelAll(be)
    End Function

    Public Sub PrepararEntregaVenta(be As documentoventaAbarrotes) Implements IContService.PrepararEntregaVenta
        Dim ventaBL As New documentoventaAbarrotesBL
        ventaBL.PrepararEntregaVenta(be)
    End Sub

    Public Function GetVentasStatusPreparacionAlmacen(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasStatusPreparacionAlmacen
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasStatusPreparacionAlmacen(be)
    End Function

    Public Function GrabarVentaSinIventario(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes) Implements IContService.GrabarVentaSinIventario
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarVentaSinIventario(listaDocumento)
    End Function

    Public Function Grabar_VentaNotaSinInventario(objDocumento As documento) As Integer Implements IContService.Grabar_VentaNotaSinInventario
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.Grabar_VentaNotaSinInventario(objDocumento)
    End Function

    Public Function GetListaItemsPorTipo(be As item) As List(Of item) Implements IContService.GetListaItemsPorTipo
        Dim itemBL As New itemBL
        Return itemBL.GetListaItemsPorTipo(be)
    End Function

    Public Sub actualizarPrecioCompra(be As detalleitems) Implements IContService.actualizarPrecioCompra
        Dim precioCompraBL As New detalleitemsBL
        precioCompraBL.actualizarPrecioCompra(be)
    End Sub

    Public Sub EliminarProductoSinInventario(be As detalleitems) Implements IContService.EliminarProductoSinInventario
        Dim precioCompraBL As New detalleitemsBL
        precioCompraBL.EliminarProductoSinInventario(be)
    End Sub

    Public Function GetBusquedaAvanzadaProductos(be As detalleitems, caso As String) As List(Of totalesAlmacen) Implements IContService.GetBusquedaAvanzadaProductos
        Dim precioCompraBL As New totalesAlmacenBL
        Return precioCompraBL.GetBusquedaAvanzadaProductos(be, caso)
    End Function

    Public Function GetProductosBusquedaPersonalizada(be As detalleitems, caso As String) As List(Of detalleitems) Implements IContService.GetProductosBusquedaPersonalizada
        Dim precioCompraBL As New detalleitemsBL
        Return precioCompraBL.GetProductosBusquedaPersonalizada(be, caso)
    End Function

    Public Function OfertaSelCodigo(be As oferta) As oferta Implements IContService.OfertaSelCodigo
        Dim ofertaBL As New ofertaBL
        Return ofertaBL.OfertaSelCodigo(be)
    End Function

    Public Sub UpdateFacturasXEstado(doc As Integer, estado As String) Implements IContService.UpdateFacturasXEstado
        Dim documentoabarrotesbl As New documentoventaAbarrotesBL
        documentoabarrotesbl.UpdateFacturasXEstado(doc, estado)
    End Sub

    Public Function BuscarFacturanoEnviadasPeriodo(fecha As Date, tipoDoc As String, idEmpresa As String) As List(Of documentoventaAbarrotes) Implements IContService.BuscarFacturanoEnviadasPeriodo
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarFacturanoEnviadasPeriodo(fecha, tipoDoc, idEmpresa)
    End Function

    Public Function BuscarBoletasAnuladas(fecha As Date, IdEmpresa As String) As List(Of documentoventaAbarrotes) Implements IContService.BuscarBoletasAnuladas
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarBoletasAnuladas(fecha, IdEmpresa)
    End Function

    Public Function TicketsXvalidarBajasBoletas(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.TicketsXvalidarBajasBoletas
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.TicketsXvalidarBajasBoletas(docVentaAbarrotes)
    End Function

    Public Function TicketsXvalidarNotasBoleta(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.TicketsXvalidarNotasBoleta
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.TicketsXvalidarNotasBoleta(docVentaAbarrotes)
    End Function

    Public Function TicketsXvalidar(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.TicketsXvalidar
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.TicketsXvalidar(docVentaAbarrotes)

    End Function

    Public Function TicketsXvalidarBajasFactura(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.TicketsXvalidarBajasFactura
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.TicketsXvalidarBajasFactura(docVentaAbarrotes)
    End Function

    Public Function FacturasPendientesSunat(docVentaAbarrotes As documentoventaAbarrotes) As Integer Implements IContService.FacturasPendientesSunat
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.FacturasPendientesSunat(docVentaAbarrotes)
    End Function

    Public Function NotasPendientesSunat(docVentaAbarrotes As documentoventaAbarrotes) As Integer Implements IContService.NotasPendientesSunat
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.NotasPendientesSunat(docVentaAbarrotes)
    End Function

    Public Function BoletasPendientesEnvio(docVentaAbarrotes As documentoventaAbarrotes) As Integer Implements IContService.BoletasPendientesEnvio
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BoletasPendientesEnvio(docVentaAbarrotes)
    End Function

    Public Function ResumenBoletasPendiente(docVentaAbarrotes As documentoventaAbarrotes) As Integer Implements IContService.ResumenBoletasPendiente
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.ResumenBoletasPendiente(docVentaAbarrotes)
    End Function

    Public Function FacturasBajasValidar(docVentaAbarrotes As documentoventaAbarrotes) As Integer Implements IContService.FacturasBajasValidar
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.FacturasBajasValidar(docVentaAbarrotes)
    End Function

    Public Function BoletasBajaValidar(docVentaAbarrotes As documentoventaAbarrotes) As Integer Implements IContService.BoletasBajaValidar
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BoletasBajaValidar(docVentaAbarrotes)
    End Function

    Public Function BoletasBaja(docVentaAbarrotes As documentoventaAbarrotes) As Integer Implements IContService.BoletasBaja
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BoletasBaja(docVentaAbarrotes)
    End Function

    Public Function FacturaBajasPendiente(docVentaAbarrotes As documentoventaAbarrotes) As Integer Implements IContService.FacturaBajasPendiente
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.FacturaBajasPendiente(docVentaAbarrotes)
    End Function

    Public Function BuscarBoletasXTicketSunatNotas(ticket As String) As List(Of documentoventaAbarrotes) Implements IContService.BuscarBoletasXTicketSunatNotas
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarBoletasXTicketSunatNotas(ticket)
    End Function

    Public Function BuscarBoletasXTicketSunat(ticket As String) As List(Of documentoventaAbarrotes) Implements IContService.BuscarBoletasXTicketSunat
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarBoletasXTicketSunat(ticket)
    End Function

    Public Sub ListaReenvioSunatResumen(lista As List(Of documentoventaAbarrotes), nroTicket As String) Implements IContService.ListaReenvioSunatResumen
        Dim documentoabarrotesbl As New documentoventaAbarrotesBL
        documentoabarrotesbl.ListaReenvioSunatResumen(lista, nroTicket)
    End Sub

    Public Sub ValidarEnviosSunat(lista As List(Of documentoventaAbarrotes)) Implements IContService.ValidarEnviosSunat
        Dim documentoabarrotesbl As New documentoventaAbarrotesBL
        documentoabarrotesbl.ValidarEnviosSunat(lista)
    End Sub

    Public Sub ListaReenvioSunatAnulados(lista As List(Of documentoventaAbarrotes), nroTicket As String) Implements IContService.ListaReenvioSunatAnulados
        Dim documentoabarrotesbl As New documentoventaAbarrotesBL
        documentoabarrotesbl.ListaReenvioSunatAnulados(lista, nroTicket)
    End Sub

    Public Function BuscarDocumentosAnuladosFechaTicket(tipodoc As String, ruc As String, ticket As String) As List(Of documentoventaAbarrotes) Implements IContService.BuscarDocumentosAnuladosFechaTicket
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarDocumentosAnuladosFechaTicket(tipodoc, ruc, ticket)
    End Function

    Public Function SaveVentaNotaCredito2Electronica(objDocumento As documento, nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer Implements IContService.SaveVentaNotaCredito2Electronica
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.SaveVentaNotaCredito2Electronica(objDocumento, nDocumentoNota, nDocumentoSaldoVenta)
    End Function

    Public Function GetRentabilidadPorComprobante(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetRentabilidadPorComprobante
        Dim inventarioBL As New InventarioMovimientoBL
        Return inventarioBL.GetRentabilidadPorComprobante(be)
    End Function

    Public Function GetPrecioPorProducto(idempresa As String, idProducto As Integer) As List(Of detalleitems) Implements IContService.GetPrecioPorProducto
        Dim inventarioBL As New detalleitemsBL
        Return inventarioBL.GetPrecioPorProducto(idempresa, idProducto)
    End Function

    Public Function GetProductsSistemaByEmpresa(be As detalleitems) As List(Of usp_GetProductsSistema_Result) Implements IContService.GetProductsSistemaByEmpresa
        Dim articulosBL As New detalleitemsBL
        Return articulosBL.GetProductsSistemaByEmpresa(be)
    End Function

    Public Function GrabarSalidaInventario(objDocumento As documento) As Integer Implements IContService.GrabarSalidaInventario
        Dim compraBL As New documentocompraBL
        Return compraBL.GrabarSalidaInventario(objDocumento)
    End Function

    Public Function GetArticulosSytem(empresa As String, search As String) As List(Of detalleitems) Implements IContService.GetArticulosSytem
        Dim articulosBL As New detalleitemsBL
        Return articulosBL.GetArticulosSytem(empresa, search)
    End Function

    Public Function GetListarVentasPeriodoXTipoAnulados(intIdEstablec As Integer, strPeriodo As String, tipo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasPeriodoXTipoAnulados
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPeriodoXTipoAnulados(intIdEstablec, strPeriodo, tipo)
    End Function

    Public Function GetListarVentasPeriodoXTipo(IDempresa As String, intIdEstablec As Integer, strPeriodo As String, tipo As String, TipoConsulta As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasPeriodoXTipo
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasPeriodoXTipo(IDempresa, intIdEstablec, strPeriodo, tipo, TipoConsulta)
    End Function

    Public Function UbicaEmpresaID(idDatoGeneral As String) As datosGenerales Implements ServiceContract.IContService.UbicaEmpresaID
        Dim establecBL As New datosGeneralesBL()
        Return establecBL.UbicaEmpresaID(idDatoGeneral)
    End Function

    Public Function InsertEmpresa(datoGeneralBE As Business.Entity.datosGenerales) As Integer Implements ServiceContract.IContService.InsertEmpresa
        Dim establecBL As New datosGeneralesBL()
        Return establecBL.InsertEmpresa(datoGeneralBE)
    End Function

    Public Function updateDatos(datoGeneralBE As Business.Entity.datosGenerales) As Integer Implements ServiceContract.IContService.updateDatos
        Dim establecBL As New datosGeneralesBL()
        Return establecBL.updateDatos(datoGeneralBE)
    End Function

    Public Function GetVentasPorFecha(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasPorFecha
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasPorFecha(be, opcion)
    End Function

    Public Function GetInventoryProductoID(idProducto As Integer, almacen As Integer) As usp_GetProductInventoryID_Result Implements IContService.GetInventoryProductoID
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetInventoryProductoID(idProducto, almacen)
    End Function

    Public Function GetVentasPorFechaConteo(be As documentoventaAbarrotes, opcion As String) As List(Of String) Implements IContService.GetVentasPorFechaConteo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasPorFechaConteo(be, opcion)
    End Function

    Public Function GetNotaVentasPorFecha(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes) Implements IContService.GetNotaVentasPorFecha
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetNotaVentasPorFecha(be, opcion)
    End Function

    Public Function GetVentasPorCriterio(be As documentoventaAbarrotes, criterio As String, valor As String) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasPorCriterio
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasPorCriterio(be, criterio, valor)
    End Function

    Public Function GetDetalleItemsXEmpresa(empresa As String, idEstable As Integer, tipo As String, search As String) As List(Of detalleitems) Implements IContService.GetDetalleItemsXEmpresa
        Dim ventaBL As New detalleitemsBL
        Return ventaBL.GetDetalleItemsXEmpresa(empresa, idEstable, tipo, search)
    End Function

    Public Function GetArticulosSinAlmacen(empresa As String, opcion As Byte) As List(Of detalleitems) Implements IContService.GetArticulosSinAlmacen
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetArticulosSinAlmacen(empresa, opcion)
    End Function

    Public Function GetArticulosSinAlmacenSearchText(empresa As String, search As String) As List(Of detalleitems) Implements IContService.GetArticulosSinAlmacenSearchText
        Dim productoBL As New detalleitemsBL
        Return productoBL.GetArticulosSinAlmacenSearchText(empresa, search)
    End Function

    Public Function GetListarAllVentasPorDIa(objDocumento As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasPorDIa
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasPorDIa(objDocumento)
    End Function

    Public Function GetDetalleLoteXproductoProf(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen) Implements IContService.GetDetalleLoteXproductoProf
        Dim inventarioBL As New totalesAlmacenBL
        Return inventarioBL.GetDetalleLoteXproductoProf(objTotalBE)
    End Function

    Public Function GetProductosSinAsignarPrecios(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosSinAsignarPrecios
        Dim preciosBL As New detalleitemsBL
        Return preciosBL.GetProductosSinAsignarPrecios(be)
    End Function

    Public Function GetStatusAprobacion(be As documentocompra) As List(Of documentocompra) Implements IContService.GetStatusAprobacion
        Dim compraBL As New documentocompraBL
        Return compraBL.GetStatusAprobacion(be)
    End Function

    Public Function GetStatusAprobacionList(be As documentocompra) As List(Of documentocompra) Implements IContService.GetStatusAprobacionList
        Dim compraBL As New documentocompraBL
        Return compraBL.GetStatusAprobacionList(be)
    End Function

    Public Sub ConfirmarListaRapida(lista As List(Of documento), compra As documento) Implements IContService.ConfirmarListaRapida
        Dim compraBL As New documentocompraBL
        compraBL.ConfirmarListaRapida(lista, compra)
    End Sub

    Public Sub RechazarCompraRapida(be As documento) Implements IContService.RechazarCompraRapida
        Dim compraBL As New documentocompraBL
        compraBL.RechazarCompraRapida(be)
    End Sub

    Public Function GetContadorCRapidaRecientes(be As documentocompra) As Integer Implements IContService.GetContadorCRapidaRecientes
        Dim compraBL As New documentocompraBL
        Return compraBL.GetContadorCRapidaRecientes(be)
    End Function

    Public Function GetCRapidaRecientes(be As documentocompra) As List(Of documentocompra) Implements IContService.GetCRapidaRecientes
        Dim compraBL As New documentocompraBL
        Return compraBL.GetCRapidaRecientes(be)
    End Function

    Public Function GetEscaneadasCRapidas(be As documentocompra) As List(Of documentocompra) Implements IContService.GetEscaneadasCRapidas
        Dim compraBL As New documentocompraBL
        Return compraBL.GetEscaneadasCRapidas(be)
    End Function

    Public Function GetEscaneadasCRapidasList(be As documentocompra) As List(Of documentocompra) Implements IContService.GetEscaneadasCRapidasList
        Dim compraBL As New documentocompraBL
        Return compraBL.GetEscaneadasCRapidasList(be)
    End Function

    Public Function GetEscaneadasCRapidasPeriodo(be As documentocompra) As List(Of documentocompra) Implements IContService.GetEscaneadasCRapidasPeriodo
        Dim compraBL As New documentocompraBL
        Return compraBL.GetEscaneadasCRapidasPeriodo(be)
    End Function

    Public Function GetConfigurationPay(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos) Implements IContService.GetConfigurationPay
        Dim compraBL As New estadosFinancierosConfiguracionPagosBL
        Return compraBL.GetConfigurationPay(Be)
    End Function

    Public Sub GrabarConfiguracionList(lista As List(Of estadosFinancierosConfiguracionPagos)) Implements IContService.GrabarConfiguracionList
        Dim compraBL As New estadosFinancierosConfiguracionPagosBL
        compraBL.GrabarConfiguracionList(lista)
    End Sub

    Public Function GetResumenXFormaPago(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetResumenXFormaPago
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetResumenXFormaPago(be)
    End Function

    Public Sub GrabarPedidoLogistica(objDocumento As documento) Implements IContService.GrabarPedidoLogistica
        Dim cajaBL As New documentocompraBL
        cajaBL.GrabarPedidoLogistica(objDocumento)
    End Sub

    Public Function GetAlertaTransferenciasConteo(be As documentocompra) As List(Of documentocompra) Implements IContService.GetAlertaTransferenciasConteo
        Dim compraBL As New documentocompraBL
        Return compraBL.GetAlertaTransferenciasConteo(be)
    End Function

    Public Function ListaGuiasTransferenciasXEntidadV2(be As documentocompra, tipoPerson As String) As List(Of documentoGuia) Implements IContService.ListaGuiasTransferenciasXEntidadV2
        Dim compraBL As New documentoGuiaBL
        Return compraBL.ListaGuiasTransferenciasXEntidadV2(be, tipoPerson)
    End Function

    Public Sub confirmarTrasnferenciaPedniente(compra As documentocompra) Implements IContService.confirmarTrasnferenciaPedniente
        Dim compraBL As New documentocompraBL
        compraBL.confirmarTrasnferenciaPedniente(compra)
    End Sub

    Public Function GetResumenAnualCuentasPagar(be As documentocompra) As List(Of documentocompra) Implements IContService.GetResumenAnualCuentasPagar
        Dim compraBL As New documentocompraBL
        Return compraBL.GetResumenAnualCuentasPagar(be)
    End Function

    Public Function AlertaPSE(Empresa As String) As documentoventaAbarrotes Implements IContService.AlertaPSE
        Dim inventarioBL As New documentoventaAbarrotesBL
        Return inventarioBL.AlertaPSE(Empresa)
    End Function

    Public Function BoletasPeriodo(fecha As Date, tipoDoc As String, ruc As String) As List(Of documentoventaAbarrotes) Implements IContService.BoletasPeriodo
        Dim inventarioBL As New documentoventaAbarrotesBL
        Return inventarioBL.BoletasPeriodo(fecha, tipoDoc, ruc)
    End Function

    Public Function NotasBoletasPeriodo(fecha As Date, tipoDoc As String, ruc As String) As List(Of documentoventaAbarrotes) Implements IContService.NotasBoletasPeriodo
        Dim inventarioBL As New documentoventaAbarrotesBL
        Return inventarioBL.NotasBoletasPeriodo(fecha, tipoDoc, ruc)
    End Function

    Public Function BoletasAnuladasPeriodo(fecha As Date, tipoDoc As String, ruc As String) As List(Of documentoventaAbarrotes) Implements IContService.BoletasAnuladasPeriodo
        Dim inventarioBL As New documentoventaAbarrotesBL
        Return inventarioBL.BoletasAnuladasPeriodo(fecha, tipoDoc, ruc)
    End Function

    Public Function FacturasAnuladasPeriodo(fecha As Date, tipoDoc As String, ruc As String) As List(Of documentoventaAbarrotes) Implements IContService.FacturasAnuladasPeriodo
        Dim inventarioBL As New documentoventaAbarrotesBL
        Return inventarioBL.FacturasAnuladasPeriodo(fecha, tipoDoc, ruc)
    End Function

    Public Function GetComprasPorPagarOpcion(be As documentocompra, opcion As String) As List(Of documentocompra) Implements IContService.GetComprasPorPagarOpcion
        Dim compraBL As New documentocompraBL
        Return compraBL.GetComprasPorPagarOpcion(be, opcion)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function GetPagosByDocumento(be As documentocompra) As List(Of documentocompradetalle) Implements IContService.GetPagosByDocumento
        Dim compraBL As New documentocompraBL
        Return compraBL.GetPagosByDocumento(be)
    End Function

    Public Function GetUbicarCompraPorID(idDocumento As Integer) As documentocompra Implements IContService.GetUbicarCompraPorID
        Dim compraBL As New documentocompraBL
        Return compraBL.GetUbicarCompraPorID(idDocumento)
    End Function

    Public Sub PagoDocCompras(objDocumento As documento) Implements IContService.PagoDocCompras
        Dim cajaBL As New documentoCajaBL
        cajaBL.PagoDocCompras(objDocumento)
    End Sub

    Public Function GetEscaneadasCRapidasListNC(be As documentocompra) As List(Of documentocompra) Implements IContService.GetEscaneadasCRapidasListNC
        Dim compraBL As New documentocompraBL
        Return compraBL.GetEscaneadasCRapidasListNC(be)
    End Function

    Public Function GetEscaneadasNotaComprasseriodo(be As documentocompra) As List(Of documentocompra) Implements IContService.GetEscaneadasNotaComprasseriodo
        Dim compraBL As New documentocompraBL
        Return compraBL.GetEscaneadasNotaComprasseriodo(be)
    End Function

    Public Function GetNotaCompraRecientes(be As documentocompra) As List(Of documentocompra) Implements IContService.GetNotaCompraRecientes
        Dim compraBL As New documentocompraBL
        Return compraBL.GetNotaCompraRecientes(be)
    End Function

    Public Function GetStatusAprobacionListNotaCompra(be As documentocompra) As List(Of documentocompra) Implements IContService.GetStatusAprobacionListNotaCompra
        Dim compraBL As New documentocompraBL
        Return compraBL.GetStatusAprobacionListNotaCompra(be)
    End Function

    Public Function GetEscaneadasConteoNotaCompra(be As documentocompra) As List(Of documentocompra) Implements IContService.GetEscaneadasConteoNotaCompra
        Dim compraBL As New documentocompraBL
        Return compraBL.GetEscaneadasConteoNotaCompra(be)
    End Function

    Public Sub ConfirmarNotaDeCompra(documentoNota As documento, compra As documento) Implements IContService.ConfirmarNotaDeCompra
        Dim compraBL As New documentocompraBL
        compraBL.ConfirmarNotaDeCompra(documentoNota, compra)
    End Sub

    Public Function GetAcumuladoCuentasPagarByAnio(be As documentocompra) As documentocompra Implements IContService.GetAcumuladoCuentasPagarByAnio
        Dim compraBL As New documentocompraBL
        Return compraBL.GetAcumuladoCuentasPagarByAnio(be)
    End Function

    Public Function GetResumenAnualCuentasCobrar(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetResumenAnualCuentasCobrar
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetResumenAnualCuentasCobrar(be)
    End Function

    Public Function GetAcumuladoCuentasCobrarByAnio(be As documentoventaAbarrotes) As documentoventaAbarrotes Implements IContService.GetAcumuladoCuentasCobrarByAnio
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetAcumuladoCuentasCobrarByAnio(be)
    End Function

    Public Function GetComprasPorCobrarOpcion(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes) Implements IContService.GetComprasPorCobrarOpcion
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetComprasPorCobrarOpcion(be, opcion)
    End Function

    Public Function GetVentaPorID(iDocuemnto As Integer) As documentoventaAbarrotes Implements IContService.GetVentaPorID
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetVentaPorID(iDocuemnto)
    End Function

    Public Function GetCobrosByDocumento(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet) Implements IContService.GetCobrosByDocumento
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetCobrosByDocumento(be)
    End Function

    Public Sub PagoDocVentas(objDocumento As documento) Implements IContService.PagoDocVentas
        Dim cajabL As New documentoCajaBL
        cajabL.PagoDocVentas(objDocumento)
    End Sub

    Public Sub EntidadAfiliacionBeneficioSave(be As EntidadAfiliacionBeneficio) Implements IContService.EntidadAfiliacionBeneficioSave
        Dim afiliacionBL As New EntidadAfiliacionBeneficioBL
        afiliacionBL.EntidadAfiliacionBeneficioSave(be)
    End Sub

    Public Sub RegisterClientBenefice(be As beneficio) Implements IContService.RegisterClientBenefice
        Dim beneficioBL As New beneficioBL
        beneficioBL.RegisterClientBenefice(be)
    End Sub

    Public Function EntidadAfiliacionBeneficioStatus(be As EntidadAfiliacionBeneficio) As List(Of EntidadAfiliacionBeneficio) Implements IContService.EntidadAfiliacionBeneficioStatus
        Dim afiliacionBL As New EntidadAfiliacionBeneficioBL
        Return afiliacionBL.EntidadAfiliacionBeneficioStatus(be)
    End Function

    Public Function BeneficioSelClienteProductions(be As beneficio) As beneficio Implements IContService.BeneficioSelClienteProductions
        Dim afiliacionBL As New beneficioBL
        Return afiliacionBL.BeneficioSelClienteProductions(be)
    End Function

    Public Function BeneficioListaClienteProductions(be As beneficio) As List(Of beneficio) Implements IContService.BeneficioListaClienteProductions
        Dim beneficioBL As New beneficioBL
        Return beneficioBL.BeneficioListaClienteProductions(be)
    End Function

    Public Function CatalogoDeClientesBeneficio(be As entidad) As List(Of entidad) Implements IContService.CatalogoDeClientesBeneficio
        Dim beneficioBL As New beneficioBL
        Return beneficioBL.CatalogoDeClientesBeneficio(be)
    End Function

    Public Sub ChangeStatusAfiliado(be As EntidadAfiliacionBeneficio) Implements IContService.ChangeStatusAfiliado
        Dim beneficioBL As New EntidadAfiliacionBeneficioBL
        beneficioBL.ChangeStatusAfiliado(be)
    End Sub

    Public Function GetEntidadAfiliacionConteo(be As EntidadAfiliacionBeneficio) As List(Of EntidadAfiliacionBeneficio) Implements IContService.GetEntidadAfiliacionConteo
        Dim entidadAfiliacion As New EntidadAfiliacionBeneficioBL
        Return entidadAfiliacion.GetEntidadAfiliacionConteo(be)
    End Function

    Public Function GetListDetalleSel(be As beneficio) As List(Of beneficioDetalle) Implements IContService.GetListDetalleSel
        Dim beneficioBL As New beneficioDetalleBL
        Return beneficioBL.GetListDetalleSel(be)
    End Function

    Public Function InsertItemServicio(ByVal ProductoBE As List(Of servicio)) As Integer Implements IContService.InsertItemServicio
        Dim ProductoBL As New servicioBL()
        Return ProductoBL.InsertItemServicio(ProductoBE)
    End Function

    Public Function InsertItemServicioSimple(ByVal ProductoBE As servicio) As Integer Implements IContService.InsertItemServicioSimple
        Dim ProductoBL As New servicioBL()
        Return ProductoBL.InsertItemServicioSimple(ProductoBE)
    End Function

    Public Function GetListaServicios(ByVal ProductoBE As servicio) As List(Of servicio) Implements IContService.GetListaServicios
        Dim itemBL As New servicioBL
        Return itemBL.GetListaServicios(ProductoBE)
    End Function

    Public Sub CambiarEstadoItemServicio(be As servicio) Implements ServiceContract.IContService.CambiarEstadoItemServicio
        Dim servicioBL As New servicioBL()
        servicioBL.CambiarEstadoItemServicio(be)
    End Sub

    Public Function GetServicioByEmpresaConPrecios(empresa As String, tipo As String) As List(Of servicio) Implements ServiceContract.IContService.GetServicioByEmpresaConPrecios
        Dim ProductoBL As New servicioBL()
        Return ProductoBL.GetServicioByEmpresaConPrecios(empresa, tipo)
    End Function

    Public Function GetServicioSinAlmacenSearchText(empresa As String, search As String) As List(Of servicio) Implements IContService.GetServicioSinAlmacenSearchText
        Dim itemBL As New servicioBL
        Return itemBL.GetServicioSinAlmacenSearchText(empresa, search)
    End Function

    Public Function GetUbicaServicioID(intIdProducto As Integer) As servicio Implements ServiceContract.IContService.GetUbicaServicioID
        Dim ProductoBL As New servicioBL()
        Return ProductoBL.GetUbicaServicioID(intIdProducto)
    End Function

    Public Function updateItemServicio(ByVal ProductoBE As servicio) As Integer Implements IContService.updateItemServicio
        Dim ProductoBL As New servicioBL()
        Return ProductoBL.updateItemServicio(ProductoBE)
    End Function

    Public Function GetListaItemServicioPorTipo(be As itemServicio) As List(Of itemServicio) Implements IContService.GetListaItemServicioPorTipo
        Dim itemBL As New itemServicioBL
        Return itemBL.GetListaItemServicioPorTipo(be)
    End Function

    Public Function UbicarCategoriaServicioPorID(intIdCategoria As Integer) As itemServicio Implements ServiceContract.IContService.UbicarCategoriaServicioPorID
        Dim ProductoBL As New itemServicioBL()
        Return ProductoBL.UbicarCategoriaServicioPorID(intIdCategoria)
    End Function

    Public Function GetServicioByEmpresaSinPrecios(empresa As String, tipo As String) As List(Of servicio) Implements IContService.GetServicioByEmpresaSinPrecios
        Dim servicioBL As New servicioBL
        Return servicioBL.GetServicioByEmpresaSinPrecios(empresa, tipo)
    End Function

    Public Function SaveInsumoServicio(nInsumo As Business.Entity.itemServicio) As Integer Implements ServiceContract.IContService.SaveInsumoServicio
        Dim InsumoBL As New itemServicioBL()
        Return InsumoBL.Insert(nInsumo)
    End Function

    Public Function GetDetalleItemsXEmpresaAll(empresa As String, estable As Integer, tipo As String) As List(Of detalleitems) Implements IContService.GetDetalleItemsXEmpresaAll
        Dim ventaBL As New detalleitemsBL
        Return ventaBL.GetDetalleItemsXEmpresaAll(empresa, estable, tipo)
    End Function

    Public Function GetBeneficiosSelTipo(be As beneficioProduccionConsumo) As List(Of beneficioProduccionConsumo) Implements IContService.GetBeneficiosSelTipo
        Dim beneficioBL As New beneficioProduccionConsumoBL
        Return beneficioBL.GetBeneficiosSelTipo(be)
    End Function

    Public Function BeneficioSelID(be As beneficioProduccionConsumo) As beneficioProduccionConsumo Implements IContService.BeneficioSelID
        Dim beneficioBL As New beneficioProduccionConsumoBL
        Return beneficioBL.BeneficioSelID(be)
    End Function

    Public Function BeneficioListaClienteProductionCupones(be As beneficio) As List(Of beneficio) Implements IContService.BeneficioListaClienteProductionCupones
        Dim beneficioBL As New beneficioBL
        Return beneficioBL.BeneficioListaClienteProductionCupones(be)
    End Function

    Public Sub RegisterClientBeneficeCupon(be As beneficio) Implements IContService.RegisterClientBeneficeCupon
        Dim beneficioBL As New beneficioBL
        beneficioBL.RegisterClientBeneficeCupon(be)
    End Sub

    Public Function BeneficioSelXID(be As beneficio) As beneficio Implements IContService.BeneficioSelXID
        Dim beneficioBL As New beneficioBL
        Return beneficioBL.BeneficioSelXID(be)
    End Function

    Public Function InsertActivoFijo(activosFijosBE As activosFijos) As Integer Implements IContService.InsertActivoFijo
        Dim beneficioBL As New activosFijosBL
        Return beneficioBL.Insert(activosFijosBE)
    End Function

    Public Function GetListar_activosFijosEmpresa(be As activosFijos) As List(Of activosFijos) Implements IContService.GetListar_activosFijosEmpresa
        Dim beneficioBL As New activosFijosBL
        Return beneficioBL.GetListar_activosFijosEmpresa(be)
    End Function

    Public Function ListaResumenXEntidadV2(listaidPersona As List(Of Integer), fechaInicio As Date, fechaFin As Date, strEmpresa As String, idEstablec As Integer, ListaCuentasFinancieras As List(Of Integer)) As documentoCaja Implements IContService.ListaResumenXEntidadV2
        Dim cajabl As New documentoCajaBL
        Return cajabl.ListaResumenXEntidadV2(listaidPersona, fechaInicio, fechaFin, strEmpresa, idEstablec, ListaCuentasFinancieras)
    End Function

    Public Function GetMovimientosByFormaPago(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja) Implements IContService.GetMovimientosByFormaPago
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosByFormaPago(cajaBE, listaPersona)
    End Function

    Public Function SaveAnticipo(be As documento) As documentoAnticipo Implements IContService.SaveAnticipo
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.SaveAnticipo(be)
    End Function

    Public Function GetEscaneadasAnticiposList(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.GetEscaneadasAnticiposList
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetEscaneadasAnticiposList(be)
    End Function

    Public Function GetAnticiposPeriodo(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.GetAnticiposPeriodo
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetAnticiposPeriodo(be)
    End Function

    Public Function ObtenerSaldoAnticipoPersona(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.ObtenerSaldoAnticipoPersona
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.ObtenerSaldoAnticipoPersona(be)
    End Function

    Public Function GetStatusAprobacionAnticipos(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.GetStatusAprobacionAnticipos
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetStatusAprobacionAnticipos(be)
    End Function

    Public Function GetStatusAprobacionAnticiposList(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.GetStatusAprobacionAnticiposList
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetStatusAprobacionAnticiposList(be)
    End Function

    Public Function GrabarVentaDocumentoGeneral(objDocumento As documento) As Integer Implements IContService.GrabarVentaDocumentoGeneral
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarVentaDocumentoGeneral(objDocumento)
    End Function

    Public Function ObtenerSaldoAnticipoV2(idanticipo As Integer) As documentoAnticipo Implements IContService.ObtenerSaldoAnticipoV2
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.ObtenerSaldoAnticipoV2(idanticipo)
    End Function

    Public Function GetANTReclamacionesPeriodo(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.GetANTReclamacionesPeriodo
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesPeriodo(be)
    End Function

    Public Sub GetChangeEstadoAnticipo(be As documentoAnticipo) Implements IContService.GetChangeEstadoAnticipo
        Dim anticipoBL As New documentoAnticipoBL
        anticipoBL.GetChangeEstadoAnticipo(be)
    End Sub

    Public Function GetANTReclamacionesPersona(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetANTReclamacionesPersona
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesPersona(be)
    End Function

    Public Function GetANTReclamacionesXDocumento(be As documentoventaAbarrotes) As documentoAnticipo Implements IContService.GetANTReclamacionesXDocumento
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesXDocumento(be)
    End Function

    Public Function GetANTReclamacionesPersonaAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetANTReclamacionesPersonaAll
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesPersonaAll(be)
    End Function

    Public Function GetMovimientosByCajaUsuario(be As documentoAnticipoConciliacion) As List(Of documentoAnticipoConciliacion) Implements IContService.GetMovimientosByCajaUsuario
        Dim anticipoBL As New DocumentoAnticipoConciliacionBL
        Return anticipoBL.GetMovimientosByCajaUsuario(be)
    End Function

    Public Function GetANTReclamacionesStatusAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetANTReclamacionesStatusAll
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesStatusAll(be)
    End Function

    Public Function GetMovimientosByDocumento(be As documentoAnticipoConciliacion) As List(Of documentoAnticipoConciliacion) Implements IContService.GetMovimientosByDocumento
        Dim anticipoBL As New DocumentoAnticipoConciliacionBL
        Return anticipoBL.GetMovimientosByDocumento(be)
    End Function

    Public Function GetStatusNotaCreditoCount(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetStatusNotaCreditoCount
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetStatusNotaCreditoCount(be)
    End Function

    Public Function GetANTReclamacionesStatus(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.GetANTReclamacionesStatus
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesStatus(be)
    End Function

    Public Sub CambiarEstadoNotaCreditoAnticipo(be As documentoventaAbarrotes) Implements IContService.CambiarEstadoNotaCreditoAnticipo
        Dim notaBL As New documentoventaAbarrotesBL
        notaBL.CambiarEstadoNotaCreditoAnticipo(be)
    End Sub

    Public Function GetANTReclamacionesStatusCount(be As documentoventaAbarrotes) As Integer Implements IContService.GetANTReclamacionesStatusCount
        Dim notaBL As New documentoAnticipoBL
        Return notaBL.GetANTReclamacionesStatusCount(be)
    End Function

    Public Function GetDevolucionesByDocumentoNota(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetDevolucionesByDocumentoNota
        Dim notaBL As New documentoAnticipoBL
        Return notaBL.GetDevolucionesByDocumentoNota(be)
    End Function

    Public Sub GrabarDocumentoCajaDevolucionAnt(be As documento) Implements IContService.GrabarDocumentoCajaDevolucionAnt
        Dim notaBL As New documentoventaAbarrotesBL
        notaBL.GrabarDocumentoCajaDevolucionAnt(be)
    End Sub

    Public Function GetDevolucionAntSeguimiento(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetDevolucionAntSeguimiento
        Dim notaBL As New documentoAnticipoBL
        Return notaBL.GetDevolucionAntSeguimiento(be)
    End Function

    Public Function GetConfigurationPayCaja(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos) Implements IContService.GetConfigurationPayCaja
        Dim notaBL As New estadosFinancierosConfiguracionPagosBL
        Return notaBL.GetConfigurationPayCaja(Be)
    End Function

    Public Sub EliminarPagoDevolucion(be As documento) Implements IContService.EliminarPagoDevolucion
        Dim notaBL As New documentoventaAbarrotesBL
        notaBL.EliminarPagoDevolucion(be)
    End Sub

    Public Function GetVentaID(be As documento) As documentoventaAbarrotes Implements IContService.GetVentaID
        Dim notaBL As New documentoventaAbarrotesBL
        Return notaBL.GetVentaID(be)
    End Function

    Public Function GetVentasFiltroComprobante(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasFiltroComprobante
        Dim notaBL As New documentoventaAbarrotesBL
        Return notaBL.GetVentasFiltroComprobante(be)
    End Function

    Public Function GetCuentasPorpagarProveedorPendientes(be As documentocompra) As List(Of documentocompra) Implements IContService.GetCuentasPorpagarProveedorPendientes
        Dim notaBL As New documentocompraBL
        Return notaBL.GetCuentasPorpagarProveedorPendientes(be)
    End Function

    Public Function GetCobroPorCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetCobroPorCliente
        Dim notaBL As New documentoventaAbarrotesBL
        Return notaBL.GetCobroPorCliente(be)
    End Function

    Public Function ObtenerCajaUsuarioDia(be As cajaUsuario) As List(Of cajaUsuario) Implements IContService.ObtenerCajaUsuarioDia
        Dim notaBL As New CajaUsuarioBL
        Return notaBL.ObtenerCajaUsuarioDia(be)
    End Function

    Public Function Test() As String Implements IContService.Test
        Dim notaBL As New empresaBL
        Return notaBL.Test
    End Function

    Public Function BeneficioSave(be As detalleitemequivalencia_beneficio) As detalleitemequivalencia_beneficio Implements IContService.BeneficioSave
        Dim beneficioBL As New detalleitemequivalencia_beneficioBL
        Return beneficioBL.BeneficioSave(be)
    End Function

    Public Function SaveConexo(be As detalleitems_conexo) As detalleitems_conexo Implements IContService.SaveConexo
        Dim productoBL As New detalleitems_conexoBL
        Return productoBL.SaveConexo(be)
    End Function

    Public Function RankingVentas(opcion As String, be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.RankingVentas
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.RankingVentas(opcion, be)
    End Function

    Public Function GetOperacionesCaja(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetOperacionesCaja
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetOperacionesCaja(be)
    End Function

    Public Function GetKardexCaja(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetKardexCaja
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetKardexCaja(be)
    End Function

    Public Function GetKardexCajaTramiteDoc(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetKardexCajaTramiteDoc
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetKardexCajaTramiteDoc(be)
    End Function

    Public Function AlertaEnvioPSE(Empresa As String) As documentoventaAbarrotes Implements IContService.AlertaEnvioPSE
        Dim inventarioBL As New documentoventaAbarrotesBL
        Return inventarioBL.AlertaEnvioPSE(Empresa)
    End Function

    Public Function DocumentosAnuladosPendientes(fecha As Date, ruc As String) As List(Of documentoventaAbarrotes) Implements IContService.DocumentosAnuladosPendientes
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.DocumentosAnuladosPendientes(fecha, ruc)
    End Function

    Public Function ListaCpePendientesDeEnvio(fecha As Date, idEmpresa As String) As List(Of documentoventaAbarrotes) Implements IContService.ListaCpePendientesDeEnvio
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.ListaCpePendientesDeEnvio(fecha, idEmpresa)
    End Function

    Public Function ConsultaStockItemV2(i As documentoventaAbarrotesDet) As List(Of usp_GetValidacionLotes_Result) Implements IContService.ConsultaStockItemV2
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.ConsultaStockItemV2(i)
    End Function

    Public Function ConsultaLotesDisponiblesAdmin(i As documentoventaAbarrotesDet) As List(Of recursoCostoLote) Implements IContService.ConsultaLotesDisponiblesAdmin
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.ConsultaLotesDisponiblesAdmin(i)
    End Function

    Public Function GetInventarioAcumulado(idEMpresa As String, idEstablecimiento As Integer) As List(Of totalesAlmacen) Implements IContService.GetInventarioAcumulado
        Dim entidadBL As New totalesAlmacenBL()
        Return entidadBL.GetInventarioAcumulado(idEMpresa, idEstablecimiento)
    End Function

    Public Function GetProductosWithInventarioAlmacen(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosWithInventarioAlmacen
        Dim entidadBL As New detalleitemsBL()
        Return entidadBL.GetProductosWithInventarioAlmacen(be)
    End Function

    Public Function GrabarInventarioEquivalencia(be As documento) As documento Implements IContService.GrabarInventarioEquivalencia
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.GrabarInventarioEquivalencia(be)
    End Function

    Public Function GrabarInventarioEquivalenciaTranferencia(be As documento) As documento Implements IContService.GrabarInventarioEquivalenciaTranferencia
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.GrabarInventarioEquivalenciaTranferencia(be)
    End Function

    Public Function GetTransferenciasPeriodo(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetTransferenciasPeriodo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetTransferenciasPeriodo(be)
    End Function

    Public Function GetMovimientosLote(be As InventarioMovimiento) As List(Of InventarioMovimiento) Implements IContService.GetMovimientosLote
        Dim inventarioBL As New InventarioMovimientoBL
        Return inventarioBL.GetMovimientosLote(be)
    End Function

    Public Function GetUbicar_InventarioMovimiento(idDocumento As Integer) As List(Of InventarioMovimiento) Implements IContService.GetUbicar_InventarioMovimiento
        Dim inventarioBL As New InventarioMovimientoBL
        Return inventarioBL.GetUbicar_InventarioMovimiento(idDocumento)
    End Function

    Public Sub editarTrasnferenciaItem(inventario As InventarioMovimiento) Implements IContService.editarTrasnferenciaItem
        Dim inventarioBL As New InventarioMovimientoBL
        inventarioBL.editarTrasnferenciaItem(inventario)
    End Sub

    Public Sub EliminarItemOperation(inventario As InventarioMovimiento) Implements IContService.EliminarItemOperation
        Dim inventarioBL As New InventarioMovimientoBL
        inventarioBL.EliminarItemOperation(inventario)
    End Sub

    Public Sub EditarValoresRentabilidadCompra(item As detalleitems) Implements IContService.EditarValoresRentabilidadCompra
        Dim inventarioBL As New detalleitemsBL
        inventarioBL.EditarValoresRentabilidadCompra(item)
    End Sub

    Public Sub EditarPropertycategoryProducts(lista As List(Of detalleitems), category_id As Integer) Implements IContService.EditarPropertycategoryProducts
        Dim itemBL As New itemBL
        itemBL.EditarPropertycategoryProducts(lista, category_id)
    End Sub

    Public Function GetProductosWithEquivalenciasSelCategory(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosWithEquivalenciasSelCategory
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetProductosWithEquivalenciasSelCategory(be)
    End Function

    Public Function detalleitemcatalogo_comisionSelCatalogo(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision Implements IContService.detalleitemcatalogo_comisionSelCatalogo
        Dim itemBL As New detalleitemcatalogo_comisionBL
        Return itemBL.detalleitemcatalogo_comisionSelCatalogo(be)
    End Function

    Public Function detalleitemcatalogo_comisionSelUnidadComercial(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision Implements IContService.detalleitemcatalogo_comisionSelUnidadComercial
        Dim itemBL As New detalleitemcatalogo_comisionBL
        Return itemBL.detalleitemcatalogo_comisionSelUnidadComercial(be)
    End Function

    Public Function detalleitemcatalogo_comisionList(be As detalleitemcatalogo_comision) As List(Of detalleitemcatalogo_comision) Implements IContService.detalleitemcatalogo_comisionList
        Dim itemBL As New detalleitemcatalogo_comisionBL
        Return itemBL.detalleitemcatalogo_comisionList(be)
    End Function

    Public Function detalleitemcatalogo_comisionSave(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision Implements IContService.detalleitemcatalogo_comisionSave
        Dim itemBL As New detalleitemcatalogo_comisionBL
        Return itemBL.detalleitemcatalogo_comisionSave(be)
    End Function

    Public Function detalleitemcatalogo_comisionJoinList(be As detalleitemcatalogo_comision) As List(Of detalleitemcatalogo_comision) Implements IContService.detalleitemcatalogo_comisionJoinList
        Dim itemBL As New detalleitemcatalogo_comisionBL
        Return itemBL.detalleitemcatalogo_comisionJoinList(be)
    End Function

    Public Function detalleitemcatalogo_comisiondetalleSave(be As detalleitemcatalogo_comisiondetalle) As detalleitemcatalogo_comisiondetalle Implements IContService.detalleitemcatalogo_comisiondetalleSave
        Dim itemBL As New detalleitemcatalogo_comisiondetalleBL
        Return itemBL.detalleitemcatalogo_comisiondetalleSave(be)
    End Function

    Public Function registrocomision_usuarios_detalleJoinList(be As registrocomision_usuarios) As List(Of registrocomision_usuarios_detalle) Implements IContService.registrocomision_usuarios_detalleJoinList
        Dim itemBL As New registrocomision_usuarios_detalleBL
        Return itemBL.registrocomision_usuarios_detalleJoinList(be)
    End Function

    Public Sub registrocomision_autorizacionSaveList(Listado As List(Of registrocomision_autorizacion)) Implements IContService.registrocomision_autorizacionSaveList
        Dim itemBL As New registrocomision_autorizacionBL
        itemBL.registrocomision_autorizacionSaveList(Listado)
    End Sub

    Public Sub ChangeStatusComisionRegistro(be As registrocomision_usuarios_detalle) Implements IContService.ChangeStatusComisionRegistro
        Dim itemBL As New registrocomision_usuarios_detalleBL
        itemBL.ChangeStatusComisionRegistro(be)
    End Sub

    Public Function registrocomision_autorizacionSelUsuario(be As registrocomision_usuarios_detalle) As List(Of registrocomision_autorizacion) Implements IContService.registrocomision_autorizacionSelUsuario
        Dim itemBL As New registrocomision_autorizacionBL
        Return itemBL.registrocomision_autorizacionSelUsuario(be)
    End Function

    Public Sub RegistrarPagosComnision(be As documento) Implements IContService.RegistrarPagosComnision
        Dim itemBL As New registrocomision_autorizacionBL
        itemBL.RegistrarPagosComnision(be)
    End Sub

    Public Function GrabarTransferencia(be As documento) As documento Implements IContService.GrabarTransferencia
        Dim itemBL As New documentoventaAbarrotesBL
        Return itemBL.GrabarTransferencia(be)
    End Function

    Public Function GetPlantillaTallas() As List(Of talla) Implements IContService.GetPlantillaTallas
        Dim itemBL As New tallaBL
        Return itemBL.GetPlantillaTallas()
    End Function

    Public Sub recursoCostoLoteTallaSave(be As recursoCostoLoteTalla) Implements IContService.recursoCostoLoteTallaSave
        Dim itemBL As New recursoCostoLoteTallaBL
        itemBL.recursoCostoLoteTallaSave(be)
    End Sub

    Public Sub recursoCostoLoteTallaSaveList(be As List(Of recursoCostoLoteTalla)) Implements IContService.recursoCostoLoteTallaSaveList
        Dim itemBL As New recursoCostoLoteTallaBL
        itemBL.recursoCostoLoteTallaSaveList(be)
    End Sub

    Public Function GetLotesSelVerificacion(be As recursoCostoLote) As List(Of recursoCostoLote) Implements IContService.GetLotesSelVerificacion
        Dim itemBL As New recursoCostoLoteBL
        Return itemBL.GetLotesSelVerificacion(be)
    End Function

    Public Function GetPlantillaTallaSelcategory(be As talla) As List(Of talla) Implements IContService.GetPlantillaTallaSelcategory
        Dim itemBL As New tallaBL
        Return itemBL.GetPlantillaTallaSelcategory(be)
    End Function

    Public Sub RegistrarItems(be As recursoCostoLote) Implements IContService.RegistrarItems
        Dim itemBL As New recursoCostoLoteTallaBL
        itemBL.RegistrarItems(be)
    End Sub

    Public Function GetInventarioSelCodigo(be As totalesAlmacenOthers) As List(Of totalesAlmacenOthers) Implements IContService.GetInventarioSelCodigo
        Dim itemBL As New totalesAlmacenOthersBL
        Return itemBL.GetInventarioSelCodigo(be)
    End Function

    Public Sub EditarImageUrlProducto(item As detalleitems) Implements IContService.EditarImageUrlProducto
        Dim itemBL As New detalleitemsBL
        itemBL.EditarImageUrlProducto(item)
    End Sub

    Public Function GetTransferenciaEnTransitoCount(be As documentoventaAbarrotes) As Integer Implements IContService.GetTransferenciaEnTransitoCount
        Dim itemBL As New documentoventaAbarrotesBL
        Return itemBL.GetTransferenciaEnTransitoCount(be)
    End Function

    Public Function GetTransferenciaEnTransito(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetTransferenciaEnTransito
        Dim itemBL As New documentoventaAbarrotesBL
        Return itemBL.GetTransferenciaEnTransito(be)
    End Function

    Public Sub ConfirmarTransferencia(be As documento) Implements IContService.ConfirmarTransferencia
        Dim itemBL As New documentoventaAbarrotesBL
        itemBL.ConfirmarTransferencia(be)
    End Sub

    Public Sub GuardarLoteDetalle(be As recursoCostoLote, lista As List(Of LoteDetalle)) Implements IContService.GuardarLoteDetalle
        Dim LoteDetalleBL As New LoteDetalleBL
        LoteDetalleBL.GuardarLoteDetalle(be, lista)
    End Sub

    Public Function GetProductsCodigoInterno(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductsCodigoInterno
        Dim LoteDetalleBL As New detalleitemsBL
        Return LoteDetalleBL.GetProductsCodigoInterno(be)
    End Function

    Public Function GetProductsCodigoInternoAlmacen(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductsCodigoInternoAlmacen
        Dim LoteDetalleBL As New detalleitemsBL
        Return LoteDetalleBL.GetProductsCodigoInternoAlmacen(be)
    End Function

    Public Function GetListaItemsPorTipoPadre(be As item) As List(Of item) Implements IContService.GetListaItemsPorTipoPadre
        Dim LoteDetalleBL As New itemBL
        Return LoteDetalleBL.GetListaItemsPorTipoPadre(be)
    End Function

    Public Function UpdateTipoCategoria(nInsumo As item) As Integer Implements IContService.UpdateTipoCategoria
        Dim LoteDetalleBL As New itemBL
        Return LoteDetalleBL.UpdateTipoCategoria(nInsumo)
    End Function

    Public Function GetProductosLoteDetalle(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosLoteDetalle
        Dim catalogoBL As New detalleitemsBL
        Return catalogoBL.GetProductosLoteDetalle(be)
    End Function

    Public Function GetProductosWithEquivalenciasParam(be As detalleitems, opcion As String) As List(Of detalleitems) Implements IContService.GetProductosWithEquivalenciasParam
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetProductosWithEquivalenciasParam(be, opcion)
    End Function

    Public Function GetProductosWithInventarioCodigos(be As detalleitems, opcion As String) As List(Of detalleitems) Implements IContService.GetProductosWithInventarioCodigos
        Dim catalogoBL As New detalleitemsBL
        Return catalogoBL.GetProductosWithInventarioCodigos(be, opcion)
    End Function

    Public Function GetProductosWithInventarioParam(be As detalleitems, opcion As String) As List(Of detalleitems) Implements IContService.GetProductosWithInventarioParam
        Dim catalogoBL As New detalleitemsBL
        Return catalogoBL.GetProductosWithInventarioParam(be, opcion)
    End Function

    Public Function ListaTotalItem(itemBE As item) As List(Of item) Implements IContService.ListaTotalItem
        Dim itemBL As New itemBL
        Return itemBL.ListaTotalItem(itemBE)
    End Function

    Public Function GetListaCategoriasItem(be As item) As List(Of item) Implements IContService.GetListaCategoriasItem
        Dim itemBL As New itemBL
        Return itemBL.GetListaCategoriasItem(be)
    End Function

    Public Function GetListaTablaDetalleTipos(strEstado As String) As System.Collections.Generic.List(Of Business.Entity.tabladetalle) Implements ServiceContract.IContService.GetListaTablaDetalleTipos
        Dim tablaBL As New tabladetalleBL
        Return tablaBL.GetListaTablaDetalleTipos(strEstado)
    End Function

    Public Function GetLotesExistentesDetalle(intIdAlmacen As Integer) As List(Of totalesAlmacen) Implements IContService.GetLotesExistentesDetalle
        Dim entidadBL As New totalesAlmacenBL()
        Return entidadBL.GetLotesExistentesDetalle(intIdAlmacen)
    End Function

    Public Function InsertCabezera(be As caracteristicaItem) As caracteristicaItem Implements IContService.InsertCabezera
        Dim caracteristicaItemBL As New caracteristicaItemBL
        Return caracteristicaItemBL.InsertCabezera(be)
    End Function

    Public Function listaCamposModelo(be As caracteristicaItem) As List(Of caracteristicaItem) Implements IContService.listaCamposModelo
        Dim caracteristicaItemBL As New caracteristicaItemBL
        Return caracteristicaItemBL.listaCamposModelo(be)
    End Function

    Public Function listaModelos(be As caracteristicaItem) As List(Of caracteristicaItem) Implements IContService.listaModelos

        Dim caracteristicaItemBL As New caracteristicaItemBL
        Return caracteristicaItemBL.listaModelos(be)

    End Function


    Public Sub GuardarcaracteristicaItem(be As List(Of caracteristicaItem)) Implements IContService.GuardarcaracteristicaItem
        Dim caracteristicaItemBL As New caracteristicaItemBL
        caracteristicaItemBL.GuardarcaracteristicaItem(be)
    End Sub

    Public Function GetListarTodasVentasProductosTipoDoc(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotesDet) Implements IContService.GetListarTodasVentasProductosTipoDoc
        Dim ventabl As New documentoventaAbarrotesBL
        Return ventabl.GetListarTodasVentasProductosTipoDoc(be, tipoConsulta)
    End Function
#Region "GUIA DE REMISION"

    Public Function SAVEGUIA(DOCUMENTOGUIA As documentoGuia) As documentoGuia Implements IContService.SAVEGUIA
        Dim LisGuia As New documentoGuiaBL
        Return LisGuia.SAVEGUIA(DOCUMENTOGUIA)

    End Function

    Public Function RegistrarGuiaRemision(BE As documento) As documento Implements IContService.RegistrarGuiaRemision
        Dim GUIABL As New documentoGuiaBL
        Return GUIABL.RegistrarGuiaRemision(BE)
    End Function
#End Region
#Region "UBIGEO"
    Public Function ListarGetUbigeos() As List(Of regiones) Implements IContService.ListarGetUbigeos
        Dim listarUbig As New ubigeoBL
        Return listarUbig.ListarGetUbigeos()
    End Function

#End Region

#Region "documentoguiaDetalle"

    Public Function ListarGuiaDetalle(be As documentoGuia) As List(Of documentoGuia) Implements IContService.ListarGuiaDetalle
        Dim LisGuiaDet As New documentoguiaDetalleBL
        Return LisGuiaDet.ListarGuiaDetalle(be)
    End Function

    Public Sub GrabarListaTallaColor(be As List(Of tabladetalle)) Implements IContService.GrabarListaTallaColor
        Dim tablaBL As New tabladetalleBL
        tablaBL.GrabarListaTallaColor(be)
    End Sub

    Public Function GetVentasXDistribuirSelCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasXDistribuirSelCliente
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasXDistribuirSelCliente(be)
    End Function

    Public Function GetDetalleVentaGuiaSelventa(be As documentoventaAbarrotesDet) As List(Of documentoventaAbarrotesDet) Implements IContService.GetDetalleVentaGuiaSelventa
        Dim ventaBL As New documentoventaAbarrotesDetBL
        Return ventaBL.GetDetalleVentaGuiaSelventa(be)
    End Function

    Public Function GetVentasXDistribuirSelDate(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasXDistribuirSelDate
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetVentasXDistribuirSelDate(be)
    End Function

    Public Function GetGuiaRemisionListSelDate(be As documentoGuia) As List(Of documentoGuia) Implements IContService.GetGuiaRemisionListSelDate
        Dim guiaBL As New documentoGuiaBL
        Return guiaBL.GetGuiaRemisionListSelDate(be)
    End Function

    Public Sub EliminatGuia(be As documento) Implements IContService.EliminatGuia
        Dim guiaBL As New documentoGuiaBL
        guiaBL.EliminatGuia(be)
    End Sub

    Public Function SaveCajaAperturaUsuarioPc(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer Implements IContService.SaveCajaAperturaUsuarioPc
        Dim documentoCajaBL As New documentoCajaBL
        Return documentoCajaBL.SaveCajaAperturaUsuarioPc(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Function

    Public Function ListBoxOpen(be As cajaUsuario) As List(Of cajaUsuario) Implements IContService.ListBoxOpen
        Dim CajaUsuarioBL As New CajaUsuarioBL
        Return CajaUsuarioBL.ListBoxOpen(be)
    End Function

#End Region

#Region "Restaurant"
    'Restaurant

    Public Function GetExistenciasXTipoExistencia(detalleitemsBE As detalleitems) As List(Of detalleitems) Implements IContService.GetExistenciasXTipoExistencia
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetExistenciasXTipoExistencia(detalleitemsBE)
    End Function

    Public Function SaveComposicionFull(listaComposicion As List(Of composicion)) As Integer Implements IContService.SaveComposicionFull
        Dim composicionBL As New composicionBL
        Return composicionBL.SaveComposicionFull(listaComposicion)
    End Function

    Public Function UpdateComposicionFull(composicionBE As composicion, listaComposicion As List(Of composicion)) Implements IContService.UpdateComposicionFull
        Dim composicionBL As New composicionBL
        Return composicionBL.UpdateComposicionFull(composicionBE, listaComposicion)
    End Function

    Public Function GetUbicarComposicion(composicionBE As composicion) As List(Of composicion) Implements IContService.GetUbicarComposicion
        Dim AlmacenBL As New composicionBL
        Return AlmacenBL.GetUbicarComposicion(composicionBE)
    End Function

    Public Function GetUbicarComposicionXId(composicionBE As composicion) As List(Of composicion) Implements IContService.GetUbicarComposicionXId
        Dim AlmacenBL As New composicionBL
        Return AlmacenBL.GetUbicarComposicionXId(composicionBE)
    End Function

    Public Function UpdatePedidoProforma(be As documento) As Integer Implements IContService.UpdatePedidoProforma
        Dim AlmacenBL As New documentoventaAbarrotesBL
        Return AlmacenBL.UpdatePedidoProforma(be)
    End Function

    Public Function GetVentasFiltroComprobanteCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasFiltroComprobanteCliente
        Dim AlmacenBL As New documentoventaAbarrotesBL
        Return AlmacenBL.GetVentasFiltroComprobanteCliente(be)
    End Function

    Public Function GetVentaxCobrarVenc(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes) Implements IContService.GetVentaxCobrarVenc
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetVentaxCobrarVenc(be, opcion)
    End Function

    Public Function GetResumenAnualCuentasVenc(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetResumenAnualCuentasVenc
        Dim compraBL As New documentoventaAbarrotesBL
        Return compraBL.GetResumenAnualCuentasVenc(be)
    End Function

    Public Function BuscarConfiguracionCreada(idemp As String, idestab As String, idconf As Integer) As Integer Implements IContService.BuscarConfiguracionCreada
        Dim compraBL As New estadosFinancierosConfiguracionPagosBL
        Return compraBL.BuscarConfiguracionCreada(idemp, idestab, idconf)
    End Function

    Public Function GetProductosWithEquivalencias(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosWithEquivalencias
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetProductosWithEquivalencias(be)
    End Function

    Public Function GrabarCompraEquivalencia(be As documento) As documento Implements IContService.GrabarCompraEquivalencia
        Dim compraBL As New documentocompraBL
        Return compraBL.GrabarCompraEquivalencia(be)
    End Function

    Public Function GetProductosEntransitoEquivalencia(be As documentocompra) As List(Of inventarioTransito) Implements IContService.GetProductosEntransitoEquivalencia
        Dim compraBL As New documentocompradetalleBL
        Return compraBL.GetProductosEntransitoEquivalencia(be)
    End Function

    Public Sub EnvioProductosEnTransitoRapido(listaEnvios As List(Of inventarioTransito)) Implements IContService.EnvioProductosEnTransitoRapido
        Dim compraBL As New documentocompradetalleBL
        compraBL.EnvioProductosEnTransitoRapido(listaEnvios)
    End Sub

    Public Sub RecepcionInventario(doc As documento) Implements IContService.RecepcionInventario
        Dim guiaBL As New documentoGuiaBL
        guiaBL.RecepcionInventario(doc)
    End Sub

    Public Function GrabarVentaEquivalencia(be As documento) As documento Implements IContService.GrabarVentaEquivalencia
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarVentaEquivalencia(be)
    End Function

    Public Function SaveEquivalencia(be As detalleitem_equivalencias) As detalleitem_equivalencias Implements IContService.SaveEquivalencia
        Dim equivalenciaBL As New detalleitem_equivalenciasBL
        Return equivalenciaBL.SaveEquivalencia(be)
    End Function

    Public Function EquivalenciaSelID(be As detalleitem_equivalencias) As detalleitem_equivalencias Implements IContService.EquivalenciaSelID
        Dim equivalenciaBL As New detalleitem_equivalenciasBL
        Return equivalenciaBL.EquivalenciaSelID(be)
    End Function

    Public Sub PrecioSave(be As configuracionPrecioProducto) Implements IContService.PrecioSave
        Dim precioBL As New ConfiguracionPrecioProductoBL
        precioBL.PrecioSave(be)
    End Sub

    Public Function PrecioEquivalenciaSave(be As detalleitemequivalencia_precios) As detalleitemequivalencia_precios Implements IContService.PrecioEquivalenciaSave
        Dim precioBL As New detalleitemequivalencia_preciosBL
        Return precioBL.PrecioEquivalenciaSave(be)
    End Function

    Public Function GetProductosWithEquivalenciasV2(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosWithEquivalenciasV2
        Dim productoBL As New detalleitemsBL
        Return productoBL.GetProductosWithEquivalenciasV2(be)
    End Function

    Public Function DetalleItemPrecioSave(obj As detalleitem_precios) As detalleitem_precios Implements IContService.DetalleItemPrecioSave
        Dim productoBL As New detalleitem_preciosBL
        Return productoBL.DetalleItemPrecioSave(obj)
    End Function

    Public Function GetMovimientosCajaCajero(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaCajero
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosCajaCajero(be)
    End Function

    Public Sub ChangeEstatusEquivalencia(obj As detalleitem_equivalencias) Implements IContService.ChangeEstatusEquivalencia
        Dim cajaBL As New detalleitem_equivalenciasBL
        cajaBL.ChangeEstatusEquivalencia(obj)
    End Sub

    Public Function GetListarNotaDeVentasDia(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetListarNotaDeVentasDia
        Dim ventabl As New documentoventaAbarrotesBL
        Return ventabl.GetListarNotaDeVentasDia(be)
    End Function

    Public Function GetListarVentasPeriodoXTipoAnuladosDia(intIdEstablec As Integer, fechaLab As Date, tipo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasPeriodoXTipoAnuladosDia
        Dim ventabl As New documentoventaAbarrotesBL
        Return ventabl.GetListarVentasPeriodoXTipoAnuladosDia(intIdEstablec, fechaLab, tipo)
    End Function

    Public Function UbicarCajeroIDUsuarioActiva(caja As cajaUsuario) As cajaUsuario Implements IContService.UbicarCajeroIDUsuarioActiva
        Dim ventabl As New CajaUsuarioBL
        Return ventabl.UbicarCajeroIDUsuarioActiva(caja)
    End Function

    Public Function GetMovimientosCajaCajeroUnidadNegocio(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaCajeroUnidadNegocio
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosCajaCajeroUnidadNegocio(be)
    End Function

    Public Function GetListarTodasVentas(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarTodasVentas
        Dim ventabl As New documentoventaAbarrotesBL
        Return ventabl.GetListarTodasVentas(be, tipoConsulta)
    End Function

    Public Function GetListarTodasVentasProductos(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotesDet) Implements IContService.GetListarTodasVentasProductos
        Dim ventabl As New documentoventaAbarrotesBL
        Return ventabl.GetListarTodasVentasProductos(be, tipoConsulta)
    End Function

    Public Function GetListarTodasVentasProductosAcumulado(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotesDet) Implements IContService.GetListarTodasVentasProductosAcumulado
        Dim ventabl As New documentoventaAbarrotesBL
        Return ventabl.GetListarTodasVentasProductosAcumulado(be, tipoConsulta)
    End Function

    Public Function CatalogoPrecioSave(be As detalleitemequivalencia_catalogos) As detalleitemequivalencia_catalogos Implements IContService.CatalogoPrecioSave
        Dim ventabl As New detalleitemequivalencia_catalogosBL
        Return ventabl.CatalogoPrecioSave(be)
    End Function

    Public Sub CatalogoPredeterminado(obj As detalleitemequivalencia_catalogos) Implements IContService.CatalogoPredeterminado
        Dim catalogoBL As New detalleitemequivalencia_catalogosBL
        catalogoBL.CatalogoPredeterminado(obj)
    End Sub

    Public Function GetProductosWithInventario(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosWithInventario
        Dim catalogoBL As New detalleitemsBL
        Return catalogoBL.GetProductosWithInventario(be)
    End Function

    Public Function GetCompraID(be As documento) As documentocompra Implements IContService.GetCompraID
        Dim compraBL As New documentocompraBL
        Return compraBL.GetCompraID(be)
    End Function

    Public Function GetListarTodasCompras(be As documentocompra, tipoConsulta As String) As List(Of documentocompra) Implements IContService.GetListarTodasCompras
        Dim compraBL As New documentocompraBL
        Return compraBL.GetListarTodasCompras(be, tipoConsulta)
    End Function

    Public Function GrabarAporteGeneral(be As documento) As documento Implements IContService.GrabarAporteGeneral
        Dim compraBL As New documentocompraBL
        Return compraBL.GrabarAporteGeneral(be)
    End Function

    Public Function GetProductosWithEquivalenciasEstablecimiento(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosWithEquivalenciasEstablecimiento
        Dim detalleBL As New detalleitemsBL
        Return detalleBL.GetProductosWithEquivalenciasEstablecimiento(be)
    End Function

    Public Function GetInventarioInicial(be As documentocompra) As List(Of documentocompra) Implements IContService.GetInventarioInicial
        Dim compraBL As New documentocompraBL
        Return compraBL.GetInventarioInicial(be)
    End Function

    Public Function GenerarNumeroXTipo(intIdEstablecimiento As Integer, strcodigoNumeracion As String, strTipo As String) As Integer Implements IContService.GenerarNumeroXTipo
        Dim ventaBL As New numeracionBoletasBL
        Return ventaBL.GenerarNumeroXTipo(intIdEstablecimiento, strcodigoNumeracion, strTipo)
    End Function

    Public Sub UpdateAnulacionEnviada(objDocumento As Integer, idNum As Integer, nroTicket As String) Implements IContService.UpdateAnulacionEnviada
        Dim pedidoBL As New documentoventaAbarrotesBL
        pedidoBL.UpdateAnulacionEnviada(objDocumento, idNum, nroTicket)
    End Sub

    Public Function BoletasAnuPendEnvio(fecha As Date, IdEmpresa As String) As List(Of documentoventaAbarrotes) Implements IContService.BoletasAnuPendEnvio
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BoletasAnuPendEnvio(fecha, IdEmpresa)
    End Function

    Public Function FacturasAnuPendientesEnv(fecha As Date, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes) Implements IContService.FacturasAnuPendientesEnv
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.FacturasAnuPendientesEnv(fecha, tipodoc, ruc)
    End Function

    Public Sub CerrarCajasActivas(be As List(Of cajaUsuario)) Implements IContService.CerrarCajasActivas
        Dim cajaBL As New CajaUsuarioBL()
        cajaBL.CerrarCajasActivas(be)
    End Sub

    Public Function ConfiguracionTieneCajasActivas(idConfiguracion As Integer) As Boolean Implements IContService.ConfiguracionTieneCajasActivas
        Dim cajaBL As New estadosFinancierosConfiguracionPagosBL()
        Return cajaBL.ConfiguracionTieneCajasActivas(idConfiguracion)
    End Function

    Public Function GetMovimientosCajaFullCajeros(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaFullCajeros
        Dim cajaBL As New documentoCajaBL()
        Return cajaBL.GetMovimientosCajaFullCajeros(be)
    End Function

    Public Function GetMovimientosCajaCajeroUnidadNegocioCajeros(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaCajeroUnidadNegocioCajeros
        Dim cajaBL As New documentoCajaBL()
        Return cajaBL.GetMovimientosCajaCajeroUnidadNegocioCajeros(be)
    End Function

    Public Function CajaUsuarioSelPeriodo(be As cajaUsuario) As List(Of cajaUsuario) Implements IContService.CajaUsuarioSelPeriodo
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.CajaUsuarioSelPeriodo(be)
    End Function

    Public Function GetVentasCriterio(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetVentasCriterio
        Dim cajaBL As New documentoventaAbarrotesBL
        Return cajaBL.GetVentasCriterio(be)
    End Function

    Public Function GetANTReclamacionesXDocumentoCompra(be As documentocompra) As documentoAnticipo Implements IContService.GetANTReclamacionesXDocumentoCompra
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesXDocumentoCompra(be)
    End Function

    Public Function HistorialDePagos(iNtPadre As Integer) As List(Of documentocompra) Implements IContService.HistorialDePagos
        Dim notaBL As New documentocompraBL
        Return notaBL.HistorialDePagos(iNtPadre)
    End Function

    Public Sub PagoCompensacionCompras(objDocumento As documento) Implements IContService.PagoCompensacionCompras
        Dim cajabL As New documentoCajaBL
        cajabL.PagoCompensacionCompras(objDocumento)
    End Sub

    Public Function GetConfigurationPaySaldo(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos) Implements IContService.GetConfigurationPaySaldo
        Dim compraBL As New estadosFinancierosConfiguracionPagosBL
        Return compraBL.GetConfigurationPaySaldo(Be)
    End Function

    Public Function GetAntReclamacionesProveedor(be As documentocompra) As List(Of documentoAnticipo) Implements IContService.GetAntReclamacionesProveedor
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetAntReclamacionesProveedor(be)
    End Function

    Public Function GetListarVentasNotasPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarVentasNotasPeriodo
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarVentasNotasPeriodo(intIdEstablec, strPeriodo)
    End Function

    Public Function GetComprasCriterio(be As documentocompra) As List(Of documentocompra) Implements IContService.GetComprasCriterio
        Dim documentoventaBL As New documentocompraBL
        Return documentoventaBL.GetComprasCriterio(be)
    End Function

    Public Sub EditarDocumentoVenta(be As documento) Implements IContService.EditarDocumentoVenta
        Dim documentoventaBL As New documentoventaAbarrotesBL
        documentoventaBL.EditarDocumentoVenta(be)
    End Sub

    Public Function GetProductsBarCode(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductsBarCode
        Dim productoBL As New detalleitemsBL
        Return productoBL.GetProductsBarCode(be)
    End Function

    Public Function ConteoNotasVenta(idDoc As Integer) As Integer Implements IContService.ConteoNotasVenta
        Dim doccumento As New documentoventaAbarrotesBL
        Return doccumento.ConteoNotasVenta(idDoc)
    End Function

    Public Function GetMovimientosFormaPagoCajero(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosFormaPagoCajero
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosFormaPagoCajero(be)
    End Function

    Public Function GetMovimientosCajaComprobanteVentas(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaComprobanteVentas
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosCajaComprobanteVentas(be)
    End Function

    Public Function GetMovimientosCajaCajeroDetalle(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaCajeroDetalle
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosCajaCajeroDetalle(be)
    End Function

    Public Function GetMovimientosFormaPagoCajeroDetalle(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosFormaPagoCajeroDetalle
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosFormaPagoCajeroDetalle(be)
    End Function

    Public Function GetProformaCode(be As documento) As documentoventaAbarrotes Implements IContService.GetProformaCode
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GetProformaCode(be)
    End Function

    Public Function CobrosxDocumentoImpresion(iNtPadre As Integer) As List(Of documentoventaAbarrotes) Implements IContService.CobrosxDocumentoImpresion
        Dim notaBL As New documentoventaAbarrotesBL
        Return notaBL.CobrosxDocumentoImpresion(iNtPadre)
    End Function

    Public Function BuscarNotasBoletasPeriodo(fecha As Date, tipoDoc As String, idEmpresa As String) As List(Of documentoventaAbarrotes) Implements IContService.BuscarNotasBoletasPeriodo
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.BuscarNotasBoletasPeriodo(fecha, tipoDoc, idEmpresa)
    End Function

    Public Function GetResumenCuentasXCobrarTerminos(strEmpresa As String, intIdEstablecimiento As Integer, FechaConsulta As Date, StrMoneda As String, estadocobro As String) As List(Of documentoventaAbarrotes) Implements IContService.GetResumenCuentasXCobrarTerminos
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.GetResumenCuentasXCobrarTerminos(strEmpresa, intIdEstablecimiento, FechaConsulta, StrMoneda, estadocobro)
    End Function

    Public Function GetCuentaCobrarSelCliente(strPeriodo As Date, StrMoneda As String, intIdCliente As Integer, terminos As String) As List(Of documentoventaAbarrotes) Implements IContService.GetCuentaCobrarSelCliente
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.GetCuentaCobrarSelCliente(strPeriodo, StrMoneda, intIdCliente, terminos)
    End Function

    Public Function GetListarCuotasDocumentoPagos(iddoc As Integer) As List(Of Cronograma) Implements IContService.GetListarCuotasDocumentoPagos
        Dim cronogramaBL As New CronogramaBL
        Return cronogramaBL.GetListarCuotasDocumentoPagos(iddoc)
    End Function

    Public Function AtributoEntidadSave(be As entidadAtributos) As entidadAtributos Implements IContService.AtributoEntidadSave
        Dim atributoBL As New entidadAtributosBL
        Return atributoBL.AtributoEntidadSave(be)
    End Function

    Public Function NotasActivas(idDoc As Integer) As Integer Implements IContService.NotasActivas
        Dim doccumento As New documentoventaAbarrotesBL
        Return doccumento.NotasActivas(idDoc)
    End Function

    Public Function GrabarCompraVinculada(be As documento) As documento Implements IContService.GrabarCompraVinculada
        Dim compraBL As New documentocompraBL
        Return compraBL.GrabarCompraVinculada(be)
    End Function

#End Region

#Region "HOTEL"
    Public Sub EliminarInfraestructuraXID(i As infraestructura) Implements IContService.EliminarInfraestructuraXID
        Dim infraestructuraBL As New infraestructuraBL
        infraestructuraBL.EliminarInfraestructuraXID(i)
    End Sub

    Public Function getListaInfraestructuraFull(infraestructuraBE As infraestructura) As List(Of infraestructura) Implements IContService.getListaInfraestructuraFull
        Dim composicionBL As New infraestructuraBL
        Return composicionBL.getListaInfraestructuraFull(infraestructuraBE)
    End Function

    Public Function getListaInfraestructura(infraestructuraBE As infraestructura) As List(Of infraestructura) Implements IContService.getListaInfraestructura
        Dim composicionBL As New infraestructuraBL
        Return composicionBL.getListaInfraestructura(infraestructuraBE)
    End Function

    Public Function getListaInfraestructuraxIDPadre(infraestructuraBE As infraestructura) As List(Of infraestructura) Implements IContService.getListaInfraestructuraxIDPadre
        Dim composicionBL As New infraestructuraBL
        Return composicionBL.getListaInfraestructuraxIDPadre(infraestructuraBE)
    End Function

    Public Sub EditarInfraestructuraEstado(i As infraestructura) Implements IContService.EditarInfraestructuraEstado
        Dim infraestructuraBL As New infraestructuraBL
        infraestructuraBL.EditarInfraestructuraEstado(i)
    End Sub

    Public Sub EliminarInfraestructuraFull(i As infraestructura) Implements IContService.EliminarInfraestructuraFull
        Dim infraestructuraBL As New infraestructuraBL
        infraestructuraBL.EliminarInfraestructuraFull(i)
    End Sub

    Public Function getListaComponente(componenteBE As componente) As List(Of componente) Implements IContService.getListaComponente
        Dim componenteBL As New componenteBL
        Return componenteBL.getListaComponente(componenteBE)
    End Function

    Public Function getInfraestructuraEstructura(infraestructurabe As infraestructura) As List(Of infraestructura) Implements IContService.getInfraestructuraEstructura
        Dim composicionBL As New infraestructuraBL
        Return composicionBL.getInfraestructuraEstructura(infraestructurabe)
    End Function

    Public Function getListaComponenteXTipo(componenteBE As componente) As List(Of componente) Implements IContService.getListaComponenteXTipo
        Dim componenteBL As New componenteBL
        Return componenteBL.getListaComponenteXTipo(componenteBE)
    End Function

    Public Function SaveComponenteFull(i As List(Of componente)) As Integer Implements IContService.SaveComponenteFull
        Dim infraestructuraBL As New componenteBL
        Return infraestructuraBL.SaveComponenteFull(i)
    End Function

    Public Function SaveComponente(i As componente) As Integer Implements IContService.SaveComponente
        Dim infraestructuraBL As New componenteBL
        Return infraestructuraBL.SaveComponente(i)
    End Function

    Public Sub EliminarDistribucionFull(i As distribucionInfraestructura) Implements IContService.EliminarDistribucionFull
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        distribucionInfraestructuraBL.EliminarDistribucionFull(i)
    End Sub

    Public Function getListaDistribucionInfraestructura(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getListaDistribucionInfraestructura
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.getListaDistribucionInfraestructura(distribucionInfraestructuraBE)
    End Function

    Public Function getListaComponenteXIdPadre(componenteBE As componente) As List(Of componente) Implements IContService.getListaComponenteXIdPadre
        Dim componenteBL As New componenteBL
        Return componenteBL.getListaComponenteXIdPadre(componenteBE)
    End Function

    Public Function SaveDistribucionInfraestructuraFull(distribucion As distribucionInfraestructura, listaDistribucionInfraestructura As List(Of distribucionInfraestructura)) As Integer Implements IContService.SaveDistribucionInfraestructuraFull
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.SaveDistribucionInfraestructuraFull(distribucion, listaDistribucionInfraestructura)
    End Function

    Public Function getDistribucionInfraestructura(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getDistribucionInfraestructura
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.getDistribucionInfraestructura(distribucionInfraestructuraBE)
    End Function

    Public Sub updateCategoriaXDistribucion(listaId As List(Of distribucionInfraestructura)) Implements IContService.updateCategoriaXDistribucion
        Dim notaBL As New distribucionInfraestructuraBL
        notaBL.updateCategoriaXDistribucion(listaId)
    End Sub

    Public Sub EditarNumeracion(i As distribucionInfraestructura) Implements IContService.EditarNumeracion
        Dim notaBL As New distribucionInfraestructuraBL
        notaBL.EditarNumeracion(i)
    End Sub

    Public Function GetUbicarCategoriaInfraestructura(categoriaInfraestructuraBE As categoriaInfraestructura) As List(Of categoriaInfraestructura) Implements IContService.GetUbicarCategoriaInfraestructura
        Dim categoriaInfraestructuraBL As New categoriaInfraestructuraBL
        Return categoriaInfraestructuraBL.GetUbicarCategoriaInfraestructura(categoriaInfraestructuraBE)
    End Function

    Public Function GetUbicartipoServicioInfraestructura(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura) Implements IContService.GetUbicartipoServicioInfraestructura
        Dim tipoServicioInfraestructuraBL As New tipoServicioInfraestructuraBL
        Return tipoServicioInfraestructuraBL.GetUbicartipoServicioInfraestructura(tipoServicioInfraestructuraBE)
    End Function

    Public Function GetUbicar_DocveNTAxIdDistribucion(documentoPedidoBE As documentoPedido) As List(Of documentoventaAbarrotesDet) Implements IContService.GetUbicar_DocveNTAxIdDistribucion
        Dim notaBL As New documentoPedidoDetBL
        Return notaBL.GetUbicar_DocveNTAxIdDistribucion(documentoPedidoBE)
    End Function

    Public Function GetUbicar_DocveNTAxIdCliente(documentoPedidoBE As documentoPedido) As List(Of documentoventaAbarrotesDet) Implements IContService.GetUbicar_DocveNTAxIdCliente
        Dim notaBL As New documentoPedidoDetBL
        Return notaBL.GetUbicar_DocveNTAxIdCliente(documentoPedidoBE)
    End Function
    Public Function getDistribucionInfraestructuraXtipo(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getDistribucionInfraestructuraXtipo
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.getDistribucionInfraestructuraXtipo(distribucion)
    End Function

    Public Function getInfraestructura(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getInfraestructura
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.getInfraestructura(distribucion)
    End Function

    Public Function getDistribucionInfraHospedado(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getDistribucionInfraHospedado
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.getDistribucionInfraHospedado(distribucion)
    End Function

    Public Function getDistribucionXReserva(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getDistribucionXReserva
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.getDistribucionXReserva(distribucionInfraestructuraBE)
    End Function
    Public Function updateDistribucionXRecepcion(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura) Implements IContService.updateDistribucionXRecepcion
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.updateDistribucionXRecepcion(listaID)
    End Function

    Public Function GetDistribucionXAgrupacion() As List(Of distribucionInfraestructura) Implements IContService.GetDistribucionXAgrupacion
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.GetDistribucionXAgrupacion()
    End Function

    Public Function GetDashboardDistribucion(documentoventaBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura) Implements IContService.GetDashboardDistribucion
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.GetDashboardDistribucion(documentoventaBE)
    End Function

    Public Function GetDashBoardXCliente(documentoBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura) Implements IContService.GetDashBoardXCliente
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.GetDashBoardXCliente(documentoBE)
    End Function

    Public Function GetDetalleHabitacion(documentoBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura) Implements IContService.GetDetalleHabitacion
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.GetDetalleHabitacion(documentoBE)
    End Function

    Public Function getDistribucionInfraestructuraXtipoInfra(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getDistribucionInfraestructuraXtipoInfra
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.getDistribucionInfraestructuraXtipoInfra(distribucion)
    End Function

    Public Function getDistribucionInfraestructuraXCategoria(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getDistribucionInfraestructuraXCategoria
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.getDistribucionInfraestructuraXCategoria(distribucion)
    End Function

    Public Function updateDistribucionxID(i As distribucionInfraestructura) As distribucionInfraestructura Implements IContService.updateDistribucionxID
        Dim beneficioBL As New distribucionInfraestructuraBL
        Return beneficioBL.updateDistribucionxID(i)
    End Function

    Public Function updateDistribucionXCondicion(i As distribucionInfraestructura) As distribucionInfraestructura Implements IContService.updateDistribucionXCondicion
        Dim beneficioBL As New distribucionInfraestructuraBL
        Return beneficioBL.updateDistribucionXCondicion(i)
    End Function

    Public Sub updateDistribucionMasivo(listaID As distribucionInfraestructura) Implements IContService.updateDistribucionMasivo
        Dim beneficioBL As New distribucionInfraestructuraBL
        beneficioBL.updateDistribucionMasivo(listaID)
    End Sub

    Public Function updateDistribucionRecepcionMasivo(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura) Implements IContService.updateDistribucionRecepcionMasivo
        Dim beneficioBL As New distribucionInfraestructuraBL
        Return beneficioBL.updateDistribucionRecepcionMasivo(listaID)
    End Function

    Public Sub updateDistribucioRecepciomMasivo(listaID As distribucionInfraestructura) Implements IContService.updateDistribucioRecepciomMasivo
        Dim beneficioBL As New distribucionInfraestructuraBL
        beneficioBL.updateDistribucioRecepciomMasivo(listaID)
    End Sub

    Public Function GetListarAllVentasPeriodoPendienteInfra(intIdEstablec As Integer, strPeriodo As String, listaIdDistribucion As List(Of String)) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasPeriodoPendienteInfra
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarAllVentasPeriodoPendienteInfra(intIdEstablec, strPeriodo, listaIdDistribucion)
    End Function

    Public Function GetListaVentaID(be As documento) As List(Of documentoventaAbarrotes) Implements IContService.GetListaVentaID
        Dim notaBL As New documentoventaAbarrotesBL
        Return notaBL.GetListaVentaID(be)
    End Function

    Public Function GetListarAllVentasXIdDistribucion(distribucionBE As distribucionInfraestructura) As List(Of documentoventaAbarrotes) Implements IContService.GetListarAllVentasXIdDistribucion
        Dim notaBL As New documentoventaAbarrotesBL
        Return notaBL.GetListarAllVentasXIdDistribucion(distribucionBE)
    End Function

    Public Function GetImprimirPedido(distribucionBE As documento) As List(Of documentoventaAbarrotesDet) Implements IContService.GetImprimirPedido
        Dim notaBL As New documentoventaAbarrotesBL
        Return notaBL.GetImprimirPedido(distribucionBE)
    End Function

    Public Function GetImprimirPrecuenta(distribucionBE As documento) As List(Of documentoventaAbarrotesDet) Implements IContService.GetImprimirPrecuenta
        Dim notaBL As New documentoventaAbarrotesBL
        Return notaBL.GetImprimirPrecuenta(distribucionBE)
    End Function

    Public Function GetUbicar_DocXInfraXAreaFull(documentoPedidoBE As documentoPedido) As List(Of documentoPedidoDet) Implements ServiceContract.IContService.GetUbicar_DocXInfraXAreaFull
        Dim documentoventaBL As New documentoPedidoDetBL
        Return documentoventaBL.GetUbicar_DocXInfraXAreaFull(documentoPedidoBE)
    End Function

    Public Sub EditarEstadoPedido(i As documentoPedidoDet) Implements IContService.EditarEstadoPedido
        Dim documentoPedidoDetBL As New documentoPedidoDetBL
        documentoPedidoDetBL.EditarEstadoPedido(i)
    End Sub

    Public Sub EditarEstadoPedidoMasivo(i As List(Of documentoPedidoDet)) Implements IContService.EditarEstadoPedidoMasivo
        Dim documentoPedidoDetBL As New documentoPedidoDetBL
        documentoPedidoDetBL.EditarEstadoPedidoMasivo(i)
    End Sub

    Public Sub EditarEstadoDocPedidoMasivo(i As distribucionInfraestructura) Implements IContService.EditarEstadoDocPedidoMasivo
        Dim documentoPedidoDetBL As New documentoPedidoDetBL
        documentoPedidoDetBL.EditarEstadoDocPedidoMasivo(i)
    End Sub

    Public Function getListaInfraestructuraFullPedido(infraestructuraBE As infraestructura) As List(Of infraestructura) Implements IContService.getListaInfraestructuraFullPedido
        Dim composicionBL As New infraestructuraBL
        Return composicionBL.getListaInfraestructuraFullPedido(infraestructuraBE)
    End Function

    Public Function listaAlertaCheckOn(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura) Implements IContService.listaAlertaCheckOn
        Dim notaBL As New ocupacionInfraestructuraBL
        Return notaBL.listaAlertaCheckOn(objOcupacion)
    End Function

    Public Sub EditarOcupacionInfra(i As ocupacionInfraestructura) Implements IContService.EditarOcupacionInfra
        Dim notaBL As New ocupacionInfraestructuraBL
        notaBL.EditarOcupacionInfra(i)
    End Sub

    Public Function listaOcupacionInfraestructura(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura) Implements IContService.listaOcupacionInfraestructura
        Dim notaBL As New ocupacionInfraestructuraBL
        Return notaBL.listaOcupacionInfraestructura(objOcupacion)
    End Function

    Public Function OcupacionInfra(objOcupacion As ocupacionInfraestructura) As ocupacionInfraestructura Implements IContService.OcupacionInfra
        Dim notaBL As New ocupacionInfraestructuraBL
        Return notaBL.OcupacionInfra(objOcupacion)
    End Function

    Public Function GetListaOcupacionInfra(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura) Implements IContService.GetListaOcupacionInfra
        Dim notaBL As New ocupacionInfraestructuraBL
        Return notaBL.GetListaOcupacionInfra(objOcupacion)
    End Function

    Public Function GetUbicarDistribucionTipoServicio(composicionBE As distribucionTipoServicio) As List(Of distribucionTipoServicio) Implements IContService.GetUbicarDistribucionTipoServicio
        Dim distribucionTipoServicioBL As New distribucionTipoServicioBL
        Return distribucionTipoServicioBL.GetUbicarDistribucionTipoServicio(composicionBE)
    End Function

    Public Function GetUbicartipoServicioInfraSinClasificacion(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura) Implements IContService.GetUbicartipoServicioInfraSinClasificacion
        Dim tipoServicioInfraestructuraBL As New tipoServicioInfraestructuraBL
        Return tipoServicioInfraestructuraBL.GetUbicartipoServicioInfraSinClasificacion(tipoServicioInfraestructuraBE)
    End Function

    Public Function GetUbicartipoServicioInfra(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura) Implements IContService.GetUbicartipoServicioInfra
        Dim tipoServicioInfraestructuraBL As New tipoServicioInfraestructuraBL
        Return tipoServicioInfraestructuraBL.GetUbicartipoServicioInfra(tipoServicioInfraestructuraBE)
    End Function

    Public Function GetUbicarCategoriaAndListaSubCategoria(categoriaInfraestructuraBE As categoriaInfraestructura) As List(Of categoriaInfraestructura) Implements IContService.GetUbicarCategoriaAndListaSubCategoria
        Dim categoriaInfraestructuraBL As New categoriaInfraestructuraBL
        Return categoriaInfraestructuraBL.GetUbicarCategoriaAndListaSubCategoria(categoriaInfraestructuraBE)
    End Function

    Public Function SaveCategoriaInfraestructura(objCategoria As categoriaInfraestructura) As Integer Implements IContService.SaveCategoriaInfraestructura
        Dim categoriaInfraestructuraBL As New categoriaInfraestructuraBL
        Return categoriaInfraestructuraBL.SaveCategoriaInfraestructura(objCategoria)
    End Function

    Public Function SaveTipoServicioInfraestructura(objCategoria As tipoServicioInfraestructura) As Integer Implements IContService.SaveTipoServicioInfraestructura
        Dim tipoServicioInfraestructuraBL As New tipoServicioInfraestructuraBL
        Return tipoServicioInfraestructuraBL.SaveTipoServicioInfraestructura(objCategoria)
    End Function

    Public Function Save_ListaDistribucionTipoServicio(ListaDistribucion As List(Of distribucionTipoServicio)) As Integer Implements IContService.Save_ListaDistribucionTipoServicio
        Dim distribucionTipoServicioBL As New distribucionTipoServicioBL
        Return distribucionTipoServicioBL.Save_ListaDistribucionTipoServicio(ListaDistribucion)
    End Function

    Public Function GetUbicarCategoriaInfraestructuraXID(categoriaInfraestructuraBE As categoriaInfraestructura) As categoriaInfraestructura Implements IContService.GetUbicarCategoriaInfraestructuraXID
        Dim categoriaInfraestructuraBL As New categoriaInfraestructuraBL
        Return categoriaInfraestructuraBL.GetUbicarCategoriaInfraestructuraXID(categoriaInfraestructuraBE)
    End Function

    Public Sub DeleteTipoServicioFull(ByVal ListaTipo As List(Of distribucionTipoServicio)) Implements IContService.DeleteTipoServicioFull
        Dim notaBL As New distribucionTipoServicioBL
        notaBL.DeleteTipoServicioFull(ListaTipo)
    End Sub

    Public Function Saveinfraestructura(i As infraestructura) As Integer Implements IContService.Saveinfraestructura
        Dim composicionBL As New infraestructuraBL
        Return composicionBL.Saveinfraestructura(i)
    End Function

    Public Function EditarNombreInfra(i As infraestructura) As infraestructura Implements IContService.EditarNombreInfra
        Dim infraestructuraBL As New infraestructuraBL
        Return infraestructuraBL.EditarNombreInfra(i)
    End Function

    Public Function GetProductosWithEquivalenciasXTipo(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosWithEquivalenciasXTipo
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetProductosWithEquivalenciasXTipo(be)
    End Function

    Public Function GetDistribucionInfraestructuraConPrecios(empresa As String, tipo As String) As List(Of distribucionInfraestructura) Implements IContService.GetDistribucionInfraestructuraConPrecios
        Dim beneficioBL As New distribucionInfraestructuraBL
        Return beneficioBL.GetDistribucionInfraestructuraConPrecios(empresa, tipo)
    End Function

    Public Function ListarPersonaBeneficioXHabitacion(personas As personaBeneficio) As List(Of personaBeneficio) Implements IContService.ListarPersonaBeneficioXHabitacion
        Dim personaBeneficioBL As New personaBeneficioBL
        Return personaBeneficioBL.ListarPersonaBeneficioXHabitacion(personas)
    End Function

    Public Function ListarHospedadosXCliente(personasBE As personaBeneficio) As List(Of personaBeneficio) Implements IContService.ListarHospedadosXCliente
        Dim personaBeneficioBL As New personaBeneficioBL
        Return personaBeneficioBL.ListarHospedadosXCliente(personasBE)
    End Function

    Public Function UbicarHospedadoPorRucNro(strEmpresa As String, strNroDoc As String) As personaBeneficio Implements IContService.UbicarHospedadoPorRucNro
        Dim personaBeneficioBL As New personaBeneficioBL
        Return personaBeneficioBL.UbicarHospedadoPorRucNro(strEmpresa, strNroDoc)
    End Function

    Public Function UbicarHospedadoPorID(PersonaBE As personaBeneficio) As personaBeneficio Implements IContService.UbicarHospedadoPorID
        Dim personaBeneficioBL As New personaBeneficioBL
        Return personaBeneficioBL.UbicarHospedadoPorID(PersonaBE)
    End Function

    Public Function ListarPersonaXHabXCliente(personas As personaBeneficio) As List(Of personaBeneficio) Implements IContService.ListarPersonaXHabXCliente
        Dim personaBeneficioBL As New personaBeneficioBL
        Return personaBeneficioBL.ListarPersonaXHabXCliente(personas)
    End Function

    Public Sub SavePersonaBeneficio(ListaobjPersona As List(Of personaBeneficio), idDocumento As Integer) Implements IContService.SavePersonaBeneficio
        Dim personaBeneficioBL As New personaBeneficioBL
        personaBeneficioBL.SavePersonaBeneficio(ListaobjPersona, idDocumento)
    End Sub

    Public Function ListarPersonaBeneficioXHabitacionActivo(personas As personaBeneficio) As List(Of personaBeneficio) Implements IContService.ListarPersonaBeneficioXHabitacionActivo
        Dim personaBeneficioBL As New personaBeneficioBL
        Return personaBeneficioBL.ListarPersonaBeneficioXHabitacionActivo(personas)
    End Function

    Public Function ListarPersonaBeneficio(personas As personaBeneficio) As List(Of personaBeneficio) Implements IContService.ListarPersonaBeneficio
        Dim personaBeneficioBL As New personaBeneficioBL
        Return personaBeneficioBL.ListarPersonaBeneficio(personas)
    End Function

    Public Function ListarPersonaFull(personas As personaBeneficio) As List(Of personaBeneficio) Implements IContService.ListarPersonaFull
        Dim personaBeneficioBL As New personaBeneficioBL
        Return personaBeneficioBL.ListarPersonaFull(personas)
    End Function

    Public Function GetUbicar_documentoventaAbarrotesXListaIdDocumento(docVentaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet) Implements ServiceContract.IContService.GetUbicar_documentoventaAbarrotesXListaIdDocumento
        Dim documentoventaBL As New documentoventaAbarrotesDetBL
        Return documentoventaBL.GetUbicar_documentoventaAbarrotesXListaIdDocumento(docVentaAbarrotesBE)
    End Function

    Public Function GetUbicar_ListaDocumento(docVentaAbarrotesBE As documentoventaAbarrotesDet) As documento Implements ServiceContract.IContService.GetUbicar_ListaDocumento
        Dim documentoventaBL As New documentoventaAbarrotesDetBL
        Return documentoventaBL.GetUbicar_ListaDocumento(docVentaAbarrotesBE)
    End Function

    Public Function ListaClienteActivo(i As entidad) As List(Of documentoventaAbarrotes) Implements ServiceContract.IContService.ListaClienteActivo
        Dim documentoventaAbarrotesBL As New documentoventaAbarrotesBL
        Return documentoventaAbarrotesBL.ListaClienteActivo(i)
    End Function

    Public Function UbicarEntidadPorRucNroxIdDistribucion(strEmpresa As String, strTipoEntidad As String, strNroDoc As String) As List(Of entidad) Implements IContService.UbicarEntidadPorRucNroxIdDistribucion
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.UbicarEntidadPorRucNroxIdDistribucion(strEmpresa, strTipoEntidad, strNroDoc)
    End Function

    Public Function GrabarVentaEquivalenciaXInfra(be As documento) As documento Implements IContService.GrabarVentaEquivalenciaXInfra
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarVentaEquivalenciaXInfra(be)
    End Function

    Public Function GrabarVentaEquivalenciaXListaDoc(be As List(Of documento)) As documento Implements IContService.GrabarVentaEquivalenciaXListaDoc
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarVentaEquivalenciaXListaDoc(be)
    End Function

    Public Function GrabarVentaEquivalenciaXPedido(be As documento) As documento Implements IContService.GrabarVentaEquivalenciaXPedido
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarVentaEquivalenciaXPedido(be)
    End Function

    Public Function GrabarVentaEquivalenciaXInfraMasivo(be As documento) As documento Implements IContService.GrabarVentaEquivalenciaXInfraMasivo
        Dim ventaBL As New documentoventaAbarrotesBL
        Return ventaBL.GrabarVentaEquivalenciaXInfraMasivo(be)
    End Function

    Public Function GetListaClientesAndHuesped(strEmpresa As String, strTipoEntidad As String) As List(Of entidad) Implements IContService.GetListaClientesAndHuesped
        Dim entidadBL As New entidadBL
        Return entidadBL.GetListaClientesAndHuesped(strEmpresa, strTipoEntidad)
    End Function

    Public Function GetListaPedidosXCliente(documentoVentaBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements ServiceContract.IContService.GetListaPedidosXCliente
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListaPedidosXCliente(documentoVentaBE)
    End Function

    Public Function GetAnticipoRecibidosStatusAllXCliente(be As documentoventaAbarrotes) As List(Of documentoAnticipo) Implements IContService.GetAnticipoRecibidosStatusAllXCliente
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetAnticipoRecibidosStatusAllXCliente(be)
    End Function

    Public Function GetUbicarClienteOrHuesped(entBE As entidad) As entidad Implements ServiceContract.IContService.GetUbicarClienteOrHuesped
        Dim EntidadBL As New entidadBL()
        Return EntidadBL.GetUbicarClienteOrHuesped(entBE)
    End Function

    Public Function GetProductosWithEquivalenciasXCat(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosWithEquivalenciasXCat
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetProductosWithEquivalenciasXCat(be)
    End Function

    Public Sub DeletePedidoRestaurant(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotes) Implements IContService.DeletePedidoRestaurant
        Dim ventaDetBL As New documentoventaAbarrotesDetBL
        ventaDetBL.DeletePedidoRestaurant(documentoventaAbarrotesDetBE)
    End Sub

    Public Sub DeleteItemVentaRestaurant(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet) Implements IContService.DeleteItemVentaRestaurant
        Dim ventaDetBL As New documentoventaAbarrotesDetBL
        ventaDetBL.DeleteItemVentaRestaurant(documentoventaAbarrotesDetBE)
    End Sub

    Public Sub updateMesa(ByVal InfraBE As distribucionInfraestructura) Implements IContService.updateMesa
        Dim ventaDetBL As New documentoventaAbarrotesDetBL
        ventaDetBL.updateMesa(InfraBE)
    End Sub

    Public Function GetANTReclamacionesPeriodoXCliente(be As documentoAnticipo) As List(Of documentoAnticipo) Implements IContService.GetANTReclamacionesPeriodoXCliente
        Dim anticipoBL As New documentoAnticipoBL
        Return anticipoBL.GetANTReclamacionesPeriodoXCliente(be)
    End Function

    Public Sub actualizarMarcaProducto(be As detalleitems) Implements IContService.actualizarMarcaProducto
        Dim itemBL As New detalleitemsBL
        itemBL.actualizarMarcaProducto(be)
    End Sub

    Public Function GetUbicarProductoXTipoExistencia(ByVal idEmpresa As String, idEstablec As Integer, strTipoExistencia As String) As List(Of detalleitems) Implements IContService.GetUbicarProductoXTipoExistencia
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetUbicarProductoXTipoExistencia(idEmpresa, idEstablec, strTipoExistencia)
    End Function

    Public Function GetUbicarProductoXMarca(ByVal detalleItemBE As detalleitems) As List(Of detalleitems) Implements IContService.GetUbicarProductoXMarca
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetUbicarProductoXMarca(detalleItemBE)
    End Function

    Public Sub CerrarCajasActivasPC(be As List(Of cajaUsuario)) Implements IContService.CerrarCajasActivasPC
        Dim ventaDetBL As New CajaUsuarioBL
        ventaDetBL.CerrarCajasActivasPC(be)
    End Sub

    Public Function GetProductosWithInventarioTipoAlmacen(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductosWithInventarioTipoAlmacen
        Dim itemBL As New detalleitemsBL
        Return itemBL.GetProductosWithInventarioTipoAlmacen(be)
    End Function

    Public Function UbicarCajeroIDUsuarioActivaPC(caja As cajaUsuario) As cajaUsuario Implements IContService.UbicarCajeroIDUsuarioActivaPC
        Dim itemBL As New CajaUsuarioBL
        Return itemBL.UbicarCajeroIDUsuarioActivaPC(caja)
    End Function

#End Region

#Region "TRANSPORTE"
    Public Function CargaAsientos(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios) Implements IContService.CargaAsientos
        Dim ventaBL As New VehiculoAsiento_PreciosBL
        Return ventaBL.CargaAsientos(be)
    End Function

    Public Function GetConsultarEnviosPorProgramacion(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios) Implements IContService.GetConsultarEnviosPorProgramacion
        Dim programaBL As New VehiculoAsiento_PreciosBL
        Return programaBL.GetConsultarEnviosPorProgramacion(be)
    End Function

    Public Function GetDistritosSelProvincia(provincia_id As String, region_id As String) As List(Of distritos) Implements IContService.GetDistritosSelProvincia
        Dim distritoBL As New distritosBL
        Return distritoBL.GetDistritosSelProvincia(provincia_id, region_id)
    End Function

    Public Function GetDistritosSelID(distrito_id As String) As distritos Implements IContService.GetDistritosSelID
        Dim distritoBL As New distritosBL
        Return distritoBL.GetDistritosSelID(distrito_id)
    End Function

    Public Sub ReenviarDocumentoEliminado(idDocumento As Integer, idPse As String) Implements IContService.ReenviarDocumentoEliminado
        Dim docBL As New documentoventaTransporteBL
        docBL.ReenviarDocumentoEliminado(idDocumento, idPse)
    End Sub

    Public Function GetEncomiendasSelAgenciaDestinoMes(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetEncomiendasSelAgenciaDestinoMes
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetEncomiendasSelAgenciaDestinoMes(be)
    End Function

    Public Function GetCiudadesPorEntregarOrigenFecha(be As documentoventaTransporte, opcion As String) As List(Of documentoventaTransporte) Implements IContService.GetCiudadesPorEntregarOrigenFecha
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetCiudadesPorEntregarOrigenFecha(be, opcion)
    End Function

    Public Function GetResumenVentasSelCajero(be As documentoCaja) As documentoCaja Implements IContService.GetResumenVentasSelCajero
        Dim cajaBL As New documentoventaTransporteBL
        Return cajaBL.GetResumenVentasSelCajero(be)
    End Function

    Public Function GetConsultaEncomiendasSelMes(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetConsultaEncomiendasSelMes
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetConsultaEncomiendasSelMes(be)
    End Function

    Public Function GetConsultaTransporteSelMes(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetConsultaTransporteSelMes
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetConsultaTransporteSelMes(be)
    End Function



    Public Function GetEncomiendasSelCajero(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetEncomiendasSelCajero
        Dim cajaBL As New documentoventaTransporteBL
        Return cajaBL.GetEncomiendasSelCajero(be)
    End Function

    Public Function BuscarDocumentosAnuladosPeriodoTrans(fecha As Date, tipodoc As String, ruc As String) As List(Of documentoventaTransporte) Implements IContService.BuscarDocumentosAnuladosPeriodoTrans
        Dim entidadBL As New documentoventaTransporteBL()
        Return entidadBL.BuscarDocumentosAnuladosPeriodoTrans(fecha, tipodoc, ruc)
    End Function

    Public Function BuscarDocumentosAnuladosFechaTrans(fecha As Date, tipodoc As String, ruc As String) As List(Of documentoventaTransporte) Implements IContService.BuscarDocumentosAnuladosFechaTrans
        Dim entidadBL As New documentoventaTransporteBL()
        Return entidadBL.BuscarDocumentosAnuladosFechaTrans(fecha, tipodoc, ruc)
    End Function

    Public Function BuscarFacturanoEnviadasTrans(fecha As Date, tipoDoc As String, idEmpresa As String) As List(Of documentoventaTransporte) Implements IContService.BuscarFacturanoEnviadasTrans
        Dim entidadBL As New documentoventaTransporteBL()
        Return entidadBL.BuscarFacturanoEnviadasTrans(fecha, tipoDoc, idEmpresa)
    End Function

    Public Function DocumentosAnuladosPendientesTransporte(fecha As Date, ruc As String) As List(Of documentoventaTransporte) Implements IContService.DocumentosAnuladosPendientesTransporte
        Dim entidadBL As New documentoventaTransporteBL()
        Return entidadBL.DocumentosAnuladosPendientesTransporte(fecha, ruc)
    End Function

    Public Function ListaCpePendientesDeEnvioTransporte(fecha As Date, idEmpresa As String) As List(Of documentoventaTransporte) Implements IContService.ListaCpePendientesDeEnvioTransporte
        Dim entidadBL As New documentoventaTransporteBL()
        Return entidadBL.ListaCpePendientesDeEnvioTransporte(fecha, idEmpresa)
    End Function

    Public Function BuscarFacturanoEnviadasPeriodoTrans(fecha As Date, tipoDoc As String, idEmpresa As String) As List(Of documentoventaTransporte) Implements IContService.BuscarFacturanoEnviadasPeriodoTrans
        Dim entidadBL As New documentoventaTransporteBL()
        Return entidadBL.BuscarFacturanoEnviadasPeriodoTrans(fecha, tipoDoc, idEmpresa)
    End Function

    Public Function BuscarBoletasAnuladasPeriodoTrans(fecha As Date, IdEmpresa As String) As List(Of documentoventaTransporte) Implements IContService.BuscarBoletasAnuladasPeriodoTrans
        Dim entidadBL As New documentoventaTransporteBL()
        Return entidadBL.BuscarBoletasAnuladasPeriodoTrans(fecha, IdEmpresa)
    End Function

    Public Function BuscarBoletasAnuladasTrans(fecha As Date, IdEmpresa As String) As List(Of documentoventaTransporte) Implements IContService.BuscarBoletasAnuladasTrans
        Dim entidadBL As New documentoventaTransporteBL()
        Return entidadBL.BuscarBoletasAnuladasTrans(fecha, IdEmpresa)
    End Function

    Public Sub ListaEnvioSunatAnuladosTrans(lista As List(Of documentoventaTransporte), nroTicket As String, idNum As Integer) Implements IContService.ListaEnvioSunatAnuladosTrans
        Dim documentoabarrotesbl As New documentoventaTransporteBL
        documentoabarrotesbl.ListaEnvioSunatAnuladosTrans(lista, nroTicket, idNum)
    End Sub

    Public Sub ListaEnvioSunatResumenTrans(lista As List(Of documentoventaTransporte), idNum As Integer, nroTicket As String) Implements IContService.ListaEnvioSunatResumenTrans
        Dim documentoabarrotesbl As New documentoventaTransporteBL
        documentoabarrotesbl.ListaEnvioSunatResumenTrans(lista, idNum, nroTicket)
    End Sub

    Public Function AlertaEnvioPSETrasporte(Empresa As String) As documentoventaTransporte Implements IContService.AlertaEnvioPSETrasporte
        Dim inventarioBL As New documentoventaTransporteBL
        Return inventarioBL.AlertaEnvioPSETrasporte(Empresa)
    End Function

    Public Function AlertaPSETrasporte(Empresa As String) As documentoventaTransporte Implements IContService.AlertaPSETrasporte
        Dim inventarioBL As New documentoventaTransporteBL
        Return inventarioBL.AlertaPSETrasporte(Empresa)
    End Function

    Public Function GetEncomiendasSelAgenciaDestino(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetEncomiendasSelAgenciaDestino
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetEncomiendasSelAgenciaDestino(be)
    End Function

    Public Function GetCiudadesPorEntregarOrigen(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetCiudadesPorEntregarOrigen
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetCiudadesPorEntregarOrigen(be)
    End Function

    Public Sub EliminarVentaEncomienda(documentoBE As documento) Implements IContService.EliminarVentaEncomienda
        Dim ventaBL As New documentoventaTransporteBL
        ventaBL.EliminarVentaEncomienda(documentoBE)
    End Sub
    Public Function GetEncomiendasSelEstadoEntregaConteo(be As documentoventaTransporte) As Integer Implements IContService.GetEncomiendasSelEstadoEntregaConteo
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetEncomiendasSelEstadoEntregaConteo(be)
    End Function

    Public Sub ActualizarRutaDestino(be As documentoventaTransporte) Implements IContService.ActualizarRutaDestino
        Dim ventaBL As New documentoventaTransporteBL
        ventaBL.ActualizarRutaDestino(be)
    End Sub

    Public Function GetTransporteDocXIDAnulacion(be As documentoventaTransporteDetalle) As documentoventaTransporte Implements IContService.GetTransporteDocXIDAnulacion
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetTransporteDocXIDAnulacion(be)
    End Function

    Public Function GetPasajeroXAsiwentoAnulacion(be As documentoventaTransporte) As documentoventaTransporte Implements IContService.GetPasajeroXAsiwentoAnulacion
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetPasajeroXAsiwentoAnulacion(be)
    End Function

    Public Function GetEncomiendasSelEstadoEntregaRDLC(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetEncomiendasSelEstadoEntregaRDLC
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetEncomiendasSelEstadoEntregaRDLC(be)
    End Function

    Public Function GetEncomiendasSelEstadoEntrega(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetEncomiendasSelEstadoEntrega
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetEncomiendasSelEstadoEntrega(be)
    End Function

    Public Sub ReEnviarFacturaElectronica(idDocumento As Integer, IdPse As String, estado As String) Implements IContService.ReEnviarFacturaElectronica
        Dim docBL As New documentoventaTransporteBL
        docBL.ReEnviarFacturaElectronica(idDocumento, IdPse, estado)
    End Sub

    Public Function DocumentoTransporteSelID(be As documentoventaTransporte) As documentoventaTransporte Implements IContService.DocumentoTransporteSelID
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.DocumentoTransporteSelID(be)
    End Function

    Public Function DocumentoTransporteSelIDVer2(be As documentoventaTransporte) As documentoventaTransporte Implements IContService.DocumentoTransporteSelIDVer2
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.DocumentoTransporteSelIDVer2(be)
    End Function

    Public Function DocumentoTransporteSelIDVehiculoXProg(be As documentoventaTransporte) As documentoventaTransporte Implements IContService.DocumentoTransporteSelIDVehiculoXProg
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.DocumentoTransporteSelIDVehiculoXProg(be)
    End Function

    Public Function DocumentoTransportePasajesSelID(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.DocumentoTransportePasajesSelID
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.DocumentoTransportePasajesSelID(be)
    End Function

    Public Function GetEncomiendasByProgramacion(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetEncomiendasByProgramacion
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.GetEncomiendasByProgramacion(be)
    End Function

    Public Sub UpdateFacturasXEstadoTrans(doc As Integer, estado As String) Implements IContService.UpdateFacturasXEstadoTrans
        Dim documentoabarrotesbl As New documentoventaTransporteBL
        documentoabarrotesbl.UpdateFacturasXEstadoTrans(doc, estado)
    End Sub

    Public Function DocumentoventaTransporteSave(objDocumento As documento) As Integer Implements IContService.DocumentoventaTransporteSave
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.DocumentoventaTransporteSave(objDocumento)
    End Function

    Public Function DocumentoventaTransporteReservacionSave(objDocumento As documento, idDocumentoREf As Integer) As Integer Implements IContService.DocumentoventaTransporteReservacionSave
        Dim ventaBL As New documentoventaTransporteBL
        Return ventaBL.DocumentoventaTransporteReservacionSave(objDocumento, idDocumentoREf)
    End Function

    Public Sub DocumentoTransporteReservacionEliminar(idDocumentoREf As Integer) Implements IContService.DocumentoTransporteReservacionEliminar
        Dim ventaBL As New documentoventaTransporteBL
        ventaBL.DocumentoTransporteReservacionEliminar(idDocumentoREf)
    End Sub

    Public Function DocumentoventaEncomiendaSave(objDocumento As documento) As Integer Implements IContService.DocumentoventaEncomiendaSave
        Dim programacionBL As New documentoventaTransporteBL
        Return programacionBL.DocumentoventaEncomiendaSave(objDocumento)
    End Function

    Public Function GetConsultaEncomiendasFecha(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetConsultaEncomiendasFecha
        Dim programacionBL As New documentoventaTransporteBL
        Return programacionBL.GetConsultaEncomiendasFecha(be)
    End Function

    Public Function GetConsultaTransporteFecha(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetConsultaTransporteFecha
        Dim programacionBL As New documentoventaTransporteBL
        Return programacionBL.GetConsultaTransporteFecha(be)
    End Function

    Public Function GetConsultaEncomiendasFechaProgramada(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetConsultaEncomiendasFechaProgramada
        Dim programacionBL As New documentoventaTransporteBL
        Return programacionBL.GetConsultaEncomiendasFechaProgramada(be)
    End Function

    Public Function GetMovimientosByProgramacion(be As documentoventaTransporte) As List(Of documentoventaTransporte) Implements IContService.GetMovimientosByProgramacion
        Dim programacionBL As New documentoventaTransporteBL
        Return programacionBL.GetMovimientosByProgramacion(be)
    End Function

    Public Sub ActualizarEntrega(lista As List(Of documentoventaTransporte), listaEncomiendas As List(Of rutaTareoEncomienda)) Implements IContService.ActualizarEntrega
        Dim ventaBL As New documentoventaTransporteBL
        ventaBL.ActualizarEntrega(lista, listaEncomiendas)
    End Sub

    Public Sub ActualizarPrecio(be As ruta_HorarioServicios) Implements IContService.ActualizarPrecio
        Dim rutaBL As New Ruta_HorarioServiciosBL
        rutaBL.ActualizarPrecio(be)
    End Sub

    Public Function GetProvinciasSelRegion(region As String) As List(Of provincias) Implements IContService.GetProvinciasSelRegion
        Dim provinciaBL As New provinciasBL
        Return provinciaBL.GetProvinciasSelRegion(region)
    End Function

    Public Function GetRegiones() As List(Of regiones) Implements IContService.GetRegiones
        Dim regionesBL As New regionesBL
        Return regionesBL.GetRegiones()
    End Function

    Public Function ListarUbigeosActivos() As List(Of regiones) Implements IContService.ListarUbigeosActivos
        Dim regionesBL As New regionesBL
        Return regionesBL.ListarUbigeosActivos()
    End Function

    Public Function GellAllRutas(be As rutas) As List(Of rutas) Implements IContService.GellAllRutas
        Dim rutasBL As New RutasBL
        Return rutasBL.GellAllRutas(be)
    End Function

    Public Sub InsertarRuta(be As rutas) Implements IContService.InsertarRuta
        Dim rutaBL As New RutasBL
        rutaBL.InsertarRuta(be)
    End Sub

    Public Function GetRutaSelCodigo(be As rutas) As rutas Implements IContService.GetRutaSelCodigo
        Dim rutaBL As New RutasBL
        Return rutaBL.GetRutaSelCodigo(be)
    End Function

    Public Function RutaSelID(be As rutas) As rutas Implements IContService.RutaSelID
        Dim rutaBL As New RutasBL
        Return rutaBL.RutaSelID(be)
    End Function

    Public Function GetProgramacionPorFechaLaboral(be As rutaProgramacionSalidas) As List(Of rutaProgramacionSalidas) Implements IContService.GetProgramacionPorFechaLaboral
        Dim programacionBL As New RutaProgramacionSalidasBL
        Return programacionBL.GetProgramacionPorFechaLaboral(be)
    End Function

    Public Function GetProgramacionEstatus(be As rutaProgramacionSalidas) As List(Of rutaProgramacionSalidas) Implements IContService.GetProgramacionEstatus
        Dim programaBL As New RutaProgramacionSalidasBL
        Return programaBL.GetProgramacionEstatus(be)
    End Function

    Public Function GetProgramacionSelRutaMostrador(ruta_id As Integer) As List(Of rutaProgramacionSalidas) Implements IContService.GetProgramacionSelRutaMostrador
        Dim activofijoBL As New RutaProgramacionSalidasBL
        Return activofijoBL.GetProgramacionSelRutaMostrador(ruta_id)
    End Function

    Public Function programacionSave(be As rutaProgramacionSalidas) As rutaProgramacionSalidas Implements IContService.programacionSave
        Dim rutaBL As New RutaProgramacionSalidasBL
        Return rutaBL.programacionSave(be)
    End Function

    Public Function programacionXBusXHorarioSave(be As rutaProgramacionSalidas, listaAsientoXBus As List(Of vehiculoAsiento_Precios)) As rutaProgramacionSalidas Implements IContService.programacionXBusXHorarioSave
        Dim rutaBL As New RutaProgramacionSalidasBL
        Return rutaBL.programacionXBusXHorarioSave(be, listaAsientoXBus)
    End Function

    Public Function programacionXBusXCambioPlacaSave(be As rutaProgramacionSalidas, listaAsientoXBus As List(Of vehiculoAsiento_Precios)) As rutaProgramacionSalidas Implements IContService.programacionXBusXCambioPlacaSave
        Dim rutaBL As New RutaProgramacionSalidasBL
        Return rutaBL.programacionXBusXCambioPlacaSave(be, listaAsientoXBus)
    End Function

    Public Function GetProgramacionSelRuta(ruta_id As Object) As List(Of rutaProgramacionSalidas) Implements IContService.GetProgramacionSelRuta
        Dim rutaBL As New RutaProgramacionSalidasBL
        Return rutaBL.GetProgramacionSelRuta(ruta_id)
    End Function

    Public Function ProgramacionSelRutasActivas(be As rutaProgramacionSalidas) As List(Of rutas) Implements IContService.ProgramacionSelRutasActivas
        Dim rutaBL As New RutaProgramacionSalidasBL
        Return rutaBL.ProgramacionSelRutasActivas(be)
    End Function

    Public Sub UpdateEstadoProgramacion(obj As rutaProgramacionSalidas) Implements IContService.UpdateEstadoProgramacion
        Dim programaBL As New RutaProgramacionSalidasBL
        programaBL.UpdateEstadoProgramacion(obj)
    End Sub

    Public Sub GrabarConsolidacion(obj As rutaTareoAutos, estadoProgramacion As Integer) Implements IContService.GrabarConsolidacion
        Dim consolidacionBL As New RutaProgramacionSalidasBL
        consolidacionBL.GrabarConsolidacion(obj, estadoProgramacion)
    End Sub

    Public Function ProgramacionSelID(be As rutaProgramacionSalidas) As rutaProgramacionSalidas Implements IContService.ProgramacionSelID
        Dim consolidacionBL As New RutaProgramacionSalidasBL
        Return consolidacionBL.ProgramacionSelID(be)
    End Function

    Public Function ProgramacionManifiestoSelID(be As rutaProgramacionSalidas) As rutaProgramacionSalidas Implements IContService.ProgramacionManifiestoSelID
        Dim rutaBL As New RutaProgramacionSalidasBL
        Return rutaBL.ProgramacionManifiestoSelID(be)
    End Function

    Public Function GetRutasHabilitadas(be As rutaTareoAutos) As List(Of rutaTareoAutos) Implements IContService.GetRutasHabilitadas
        Dim rutaBL As New RutaTareoAutosBL
        Return rutaBL.GetRutasHabilitadas(be)
    End Function

    Public Function RutaTareoAutoSave(be As rutaTareoAutos) As rutaTareoAutos Implements IContService.RutaTareoAutoSave
        Dim rutaBL As New RutaTareoAutosBL
        Return rutaBL.RutaTareoAutoSave(be)
    End Function

    Public Sub GetListaSaveTareo(be As List(Of rutaTareoAutos)) Implements IContService.GetListaSaveTareo
        Dim rutaBL As New RutaTareoAutosBL
        rutaBL.GetListaSaveTareo(be)
    End Sub

    Public Function GetAdministrarPrecios(be As rutaTareoAutos) As List(Of rutaTareoAutos) Implements IContService.GetAdministrarPrecios
        Dim rutaBL As New RutaTareoAutosBL
        Return rutaBL.GetAdministrarPrecios(be)
    End Function

    Public Function GetProgamacionEnCurso(be As rutaProgramacionSalidas) As List(Of vehiculoAsiento_Precios) Implements IContService.GetProgamacionEnCurso
        Dim consolidacionBL As New RutaTareoDetalleBL
        Return consolidacionBL.GetProgamacionEnCurso(be)
    End Function

    Public Function rutaTareoEncomiendaDetalleSelFechaV2(fecha As Date, origen As Integer, destino As Integer) As List(Of rutaTareoEncomiendaDetalle) Implements IContService.rutaTareoEncomiendaDetalleSelFechaV2
        Dim encomiendaBL As New rutaTareoEncomiendaDetalleBL
        Return encomiendaBL.rutaTareoEncomiendaDetalleSelFechaV2(fecha, origen, destino)
    End Function

    Public Function rutaTareoEncomiendaDetalleSelID(be As rutaTareoEncomiendaDetalle) As List(Of rutaTareoEncomiendaDetalle) Implements IContService.rutaTareoEncomiendaDetalleSelID
        Dim ventaBL As New rutaTareoEncomiendaDetalleBL
        Return ventaBL.rutaTareoEncomiendaDetalleSelID(be)
    End Function

    Public Function rutaTareoEncomiendaDetalleSelFecha(be As rutaTareoEncomienda) As List(Of rutaTareoEncomiendaDetalle) Implements IContService.rutaTareoEncomiendaDetalleSelFecha
        Dim ventaBL As New rutaTareoEncomiendaDetalleBL
        Return ventaBL.rutaTareoEncomiendaDetalleSelFecha(be)
    End Function

    Public Function GetTareoEncomiendasSelCiudadDestino(be As rutaTareoEncomienda) As List(Of rutaTareoEncomienda) Implements IContService.GetTareoEncomiendasSelCiudadDestino
        Dim ventaBL As New rutaTareoEncomiendaBL
        Return ventaBL.GetTareoEncomiendasSelCiudadDestino(be)
    End Function

    Public Function rutaTareoEncomiendaSelID(be As rutaTareoEncomienda) As rutaTareoEncomienda Implements IContService.rutaTareoEncomiendaSelID
        Dim encomiendaBL As New rutaTareoEncomiendaBL
        Return encomiendaBL.rutaTareoEncomiendaSelID(be)
    End Function

    Public Function GetServiciosVentaTransporte(be As ruta_HorarioServicios) As List(Of ruta_HorarioServicios) Implements IContService.GetServiciosVentaTransporte
        Dim ruta_HorarioServiciosBL As New Ruta_HorarioServiciosBL
        Return ruta_HorarioServiciosBL.GetServiciosVentaTransporte(be)
    End Function

    Public Function CerrarCajaUsuarioTrasnporte(nCajaUsuario As cajaUsuario) As cajaUsuario Implements IContService.CerrarCajaUsuarioTrasnporte
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.CerrarCajaUsuarioTrasnporte(nCajaUsuario)
    End Function

    Public Sub ChangeEstatusAgencia(obj As centrocosto) Implements IContService.ChangeEstatusAgencia
        Dim agenciaBL As New centrocostoBL
        agenciaBL.ChangeEstatusAgencia(obj)
    End Sub

    Public Sub CrearBackupDatabase() Implements IContService.CrearBackupDatabase
        Dim EMPRESABL As New empresaBL
        EMPRESABL.CrearBackupDatabase()
    End Sub

    Public Function GetListar_activosFijosSeriePlaca(be As activosFijos) As List(Of activosFijos) Implements IContService.GetListar_activosFijosSeriePlaca
        Dim rutaBL As New activosFijosBL
        Return rutaBL.GetListar_activosFijosSeriePlaca(be)
    End Function

    Public Function GetUbicar_activosFijosPorID(idActivo As Integer) As activosFijos Implements IContService.GetUbicar_activosFijosPorID
        Dim activofijoBL As New activosFijosBL
        Return activofijoBL.GetUbicar_activosFijosPorID(idActivo)
    End Function

    Public Function ModificarActivo(activosFijosBE As activosFijos) As activosFijos Implements IContService.ModificarActivo
        Dim activoBL As New activosFijosBL
        Return activoBL.ModificarActivo(activosFijosBE)
    End Function

    Public Sub PredeterminarAgencia(estableBE As centrocosto) Implements IContService.PredeterminarAgencia
        Dim cajaBL As New centrocostoBL
        cajaBL.PredeterminarAgencia(estableBE)
    End Sub

    Public Sub ChangeEstatusActivo(obj As activosFijos) Implements IContService.ChangeEstatusActivo
        Dim activoBL As New activosFijosBL
        activoBL.ChangeEstatusActivo(obj)
    End Sub

    Public Function InsertEstablecimientoSingle(estableBE As centrocosto) As Integer Implements IContService.InsertEstablecimientoSingle
        Dim activoBL As New centrocostoBL
        Return activoBL.InsertEstablecimientoSingle(estableBE)
    End Function

    Public Sub InsertServicioInfraestructuraDet(objDocumento As List(Of servicioInfraestructuraDet)) Implements IContService.InsertServicioInfraestructuraDet
        Dim activoBL As New ServicioInfraestructuraDetBL
        activoBL.InsertServicioInfraestructuraDet(objDocumento)
    End Sub

    Public Sub InsertServicioInfraestructuraSingle(objDocumento As servicioInfraestructuraDet) Implements IContService.InsertServicioInfraestructuraSingle
        Dim activoBL As New ServicioInfraestructuraDetBL
        activoBL.InsertServicioInfraestructuraSingle(objDocumento)
    End Sub

    Public Function GellAllServiciosInfraDet(IdServicio As Integer) As List(Of servicioInfraestructuraDet) Implements IContService.GellAllServiciosInfraDet
        Dim activoBL As New ServicioInfraestructuraDetBL
        Return activoBL.GellAllServiciosInfraDet(IdServicio)
    End Function

    Public Function GellAllServiciosInfraDetxID(IdServicio As Integer, IdServicioDet As Integer) As servicioInfraestructuraDet Implements IContService.GellAllServiciosInfraDetxID
        Dim activoBL As New ServicioInfraestructuraDetBL
        Return activoBL.GellAllServiciosInfraDetxID(IdServicio, IdServicioDet)
    End Function

    Public Function GellAllServiciosInfra() As List(Of servicioInfraestructura) Implements IContService.GellAllServiciosInfra
        Dim activoBL As New ServicioInfraestructuraBL
        Return activoBL.GellAllServiciosInfra()
    End Function

    Public Sub UpdateServicioInfraestructura(objDocumento As servicioInfraestructura) Implements IContService.UpdateServicioInfraestructura
        Dim activoBL As New ServicioInfraestructuraBL
        activoBL.UpdateServicioInfraestructura(objDocumento)
    End Sub

    Public Sub InsertServicioInfraestructura(objDocumento As servicioInfraestructura) Implements IContService.InsertServicioInfraestructura
        Dim activoBL As New ServicioInfraestructuraBL
        activoBL.InsertServicioInfraestructura(objDocumento)
    End Sub

    Public Function GetListar_activosFijos() As List(Of activosFijos) Implements IContService.GetListar_activosFijos
        Dim beneficioBL As New activosFijosBL
        Return beneficioBL.GetListar_activosFijos()
    End Function

    Public Function GetConfiguracion(configuracionBE As configuracionReserva) As List(Of configuracionReserva) Implements IContService.GetConfiguracion
        Dim beneficioBL As New configuracionReservaBL
        Return beneficioBL.GetConfiguracion(configuracionBE)
    End Function

    Public Function GetConfiguracionID(be As configuracionReserva) As configuracionReserva Implements IContService.GetConfiguracionID
        Dim beneficioBL As New configuracionReservaBL
        Return beneficioBL.GetConfiguracionID(be)
    End Function

    Public Function GetConfiguracionInsert(be As configuracionReserva) As configuracionReserva Implements IContService.GetConfiguracionInsert
        Dim beneficioBL As New configuracionReservaBL
        Return beneficioBL.GetConfiguracionInsert(be)
    End Function

    Public Function GetConfiguracionUpdate(be As configuracionReserva) As configuracionReserva Implements IContService.GetConfiguracionUpdate
        Dim beneficioBL As New configuracionReservaBL
        Return beneficioBL.GetConfiguracionUpdate(be)
    End Function

    Public Function GetListar_activosFijosConteoAsientos() As List(Of activosFijos) Implements IContService.GetListar_activosFijosConteoAsientos
        Dim beneficioBL As New activosFijosBL
        Return beneficioBL.GetListar_activosFijosConteoAsientos()
    End Function

    Public Function GetDistribucionAsignacionItem(distriBE As distribucionInfraestructura) As distribucionInfraestructura Implements IContService.GetDistribucionAsignacionItem
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.GetDistribucionAsignacionItem(distriBE)
    End Function

    Public Sub updateDistribucioTrasnportemMasivo(listaID As distribucionInfraestructura) Implements IContService.updateDistribucioTrasnportemMasivo
        Dim beneficioBL As New distribucionInfraestructuraBL
        beneficioBL.updateDistribucioTrasnportemMasivo(listaID)
    End Sub


    Public Function updateAsientoPrecioXaNULACIONID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios Implements IContService.updateAsientoPrecioXaNULACIONID
        Dim distribucionInfraestructuraBL As New VehiculoAsiento_PreciosBL
        Return distribucionInfraestructuraBL.updateAsientoPrecioXaNULACIONID(i)
    End Function

    Public Function GetConsultarProgramacionXbus(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios Implements IContService.GetConsultarProgramacionXbus
        Dim distribucionInfraestructuraBL As New VehiculoAsiento_PreciosBL
        Return distribucionInfraestructuraBL.GetConsultarProgramacionXbus(i)
    End Function

    Public Function GetConsultarProgramacionXbusAsientos(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios) Implements IContService.GetConsultarProgramacionXbusAsientos
        Dim distribucionInfraestructuraBL As New VehiculoAsiento_PreciosBL
        Return distribucionInfraestructuraBL.GetConsultarProgramacionXbusAsientos(be)
    End Function

    Public Function getInfraestructuraTransporteXProgramacion(distribucionBE As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios) Implements IContService.getInfraestructuraTransporteXProgramacion
        Dim distribucionInfraestructuraBL As New VehiculoAsiento_PreciosBL
        Return distribucionInfraestructuraBL.getInfraestructuraTransporteXProgramacion(distribucionBE)
    End Function

    Public Function updateAsientoTransportexID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios Implements IContService.updateAsientoTransportexID
        Dim distribucionInfraestructuraBL As New VehiculoAsiento_PreciosBL
        Return distribucionInfraestructuraBL.updateAsientoTransportexID(i)
    End Function

    Public Function updateAsientoTransportexIDxVerificaion(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios Implements IContService.updateAsientoTransportexIDxVerificaion
        Dim distribucionInfraestructuraBL As New VehiculoAsiento_PreciosBL
        Return distribucionInfraestructuraBL.updateAsientoTransportexIDxVerificaion(i)
    End Function

    Public Function updateAsientoTransporteConfirmacionxID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios Implements IContService.updateAsientoTransporteConfirmacionxID
        Dim distribucionInfraestructuraBL As New VehiculoAsiento_PreciosBL
        Return distribucionInfraestructuraBL.updateAsientoTransporteConfirmacionxID(i)
    End Function

    Public Function updateAsientoPrecioXall(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios Implements IContService.updateAsientoPrecioXall
        Dim distribucionInfraestructuraBL As New VehiculoAsiento_PreciosBL
        Return distribucionInfraestructuraBL.updateAsientoPrecioXall(i)
    End Function

    Public Function updateAsientoPrecioXID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios Implements IContService.updateAsientoPrecioXID
        Dim distribucionInfraestructuraBL As New VehiculoAsiento_PreciosBL
        Return distribucionInfraestructuraBL.updateAsientoPrecioXID(i)
    End Function

    Public Function getInfraestructuraTransporte(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getInfraestructuraTransporte
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.getInfraestructuraTransporte(distribucion)
    End Function

    Public Function updateDistribucionTransportexID(i As distribucionInfraestructura) As distribucionInfraestructura Implements IContService.updateDistribucionTransportexID
        Dim distribucionInfraestructuraBL As New distribucionInfraestructuraBL
        Return distribucionInfraestructuraBL.updateDistribucionTransportexID(i)
    End Function

    Public Function GetListaNegocioComercial() As List(Of negocioComercial) Implements IContService.GetListaNegocioComercial
        Dim distribucionInfraestructuraBL As New negocioComercialBL
        Return distribucionInfraestructuraBL.GetListaNegocioComercial()
    End Function

    Public Function GetListaNEgocioComercialXUnidOrg(negocioComercialBE As negocioComercial) As List(Of negocioComercial) Implements IContService.GetListaNEgocioComercialXUnidOrg
        Dim distribucionInfraestructuraBL As New negocioComercialBL
        Return distribucionInfraestructuraBL.GetListaNEgocioComercialXUnidOrg(negocioComercialBE)
    End Function

    Public Function GetListacentroCostosXNComercial(centroCostosXNComercialBE As centroCostosXNComercial) As List(Of centroCostosXNComercial) Implements IContService.GetListacentroCostosXNComercial
        Dim distribucionInfraestructuraBL As New centroCostosXNComercialBL
        Return distribucionInfraestructuraBL.GetListacentroCostosXNComercial(centroCostosXNComercialBE)
    End Function

    Public Function GetListaNegociosDisponibles(centroCostosXNComercialBE As centroCostosXNComercial) As centroCostosXNComercial Implements IContService.GetListaNegociosDisponibles
        Dim distribucionInfraestructuraBL As New centroCostosXNComercialBL
        Return distribucionInfraestructuraBL.GetListaNegociosDisponibles(centroCostosXNComercialBE)
    End Function

    Public Function GetInsertarcentroCostosXNComercial(centroCostosXNComercialBE As centroCostosXNComercial) As centroCostosXNComercial Implements IContService.GetInsertarcentroCostosXNComercial
        Dim distribucionInfraestructuraBL As New centroCostosXNComercialBL
        Return distribucionInfraestructuraBL.GetInsertarcentroCostosXNComercial(centroCostosXNComercialBE)
    End Function

    Public Function GetCentroCostosXNComercialUpdate(be As centroCostosXNComercial) As centroCostosXNComercial Implements IContService.GetCentroCostosXNComercialUpdate
        Dim distribucionInfraestructuraBL As New centroCostosXNComercialBL
        Return distribucionInfraestructuraBL.GetCentroCostosXNComercialUpdate(be)
    End Function

    Public Function GetMovimientosCajaCajeroTipoMoneda(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaCajeroTipoMoneda
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosCajaCajeroTipoMoneda(be)
    End Function

    Public Function GetMovimientosFormaPagoCajeroMoneda(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosFormaPagoCajeroMoneda
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosFormaPagoCajeroMoneda(be)
    End Function

    Public Function CajaUsuarioPeriodoSinRecocimiento(be As cajaUsuario) As List(Of cajaUsuario) Implements IContService.CajaUsuarioPeriodoSinRecocimiento
        Dim cajaBL As New CajaUsuarioBL
        Return cajaBL.CajaUsuarioPeriodoSinRecocimiento(be)
    End Function

    Public Sub ConfirmarEntregaDeDinero(idCierre As Integer, be As cajaUsuario, bl As List(Of estadosFinancierosConfiguracionPagos), userTransc As documentoCaja) Implements IContService.ConfirmarEntregaDeDinero
        Dim documentoCajaBL As New documentoCajaBL
        documentoCajaBL.ConfirmarEntregaDeDinero(idCierre, be, bl, userTransc)
    End Sub

    Public Function GetKardexCajaAdministracion(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetKardexCajaAdministracion
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetKardexCajaAdministracion(be)
    End Function

    Public Function GetKardexCajaTramiteDocAdministracion(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetKardexCajaTramiteDocAdministracion
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetKardexCajaTramiteDocAdministracion(be)
    End Function

    Public Function GetSaldoCuentasFinancieraCajeroActivo(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraCajeroActivo_Result) Implements IContService.GetSaldoCuentasFinancieraCajeroActivo
        Dim cuentaFinancieraBL As New estadosFinancierosBL
        Return cuentaFinancieraBL.GetSaldoCuentasFinancieraCajeroActivo(be)
    End Function

#End Region


    Public Function InsertCopyItemXIdEsblecimiento(ByVal itemBE As detalleitems) As detalleitems Implements IContService.InsertCopyItemXIdEsblecimiento
        Dim itemBL As New detalleitemsBL
        Return itemBL.InsertCopyItemXIdEsblecimiento(itemBE)
    End Function

    Public Sub EliminarPermisoNegocioCOmercial(be As centroCostosXNComercial) Implements IContService.EliminarPermisoNegocioCOmercial
        Dim itemBL As New centroCostosXNComercialBL
        itemBL.EliminarPermisoNegocioCOmercial(be)
    End Sub

    Public Function ListBoxClosedPending(be As cajaUsuario) As List(Of cajaUsuario) Implements IContService.ListBoxClosedPending
        Dim CajaUsuarioBL As New CajaUsuarioBL
        Return CajaUsuarioBL.ListBoxClosedPending(be)
    End Function

    Public Function ListBoxClosedPendingUser(be As cajaUsuario) As Integer Implements IContService.ListBoxClosedPendingUser
        Dim CajaUsuarioBL As New CajaUsuarioBL
        Return CajaUsuarioBL.ListBoxClosedPendingUser(be)
    End Function

    Public Function GetExisteCodeUnidadComercial(be As detalleitem_equivalencias) As Boolean Implements IContService.GetExisteCodeUnidadComercial
        Dim articuloBL As New detalleitem_equivalenciasBL
        Return articuloBL.GetExisteCodeUnidadComercial(be)
    End Function

    Public Function GetProductsCodeUnidadComercialAlmacen(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductsCodeUnidadComercialAlmacen
        Dim articuloBL As New detalleitemsBL
        Return articuloBL.GetProductsCodeUnidadComercialAlmacen(be)
    End Function

    Public Function GetProductsCodeUnidadComercial(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductsCodeUnidadComercial
        Dim articuloBL As New detalleitemsBL
        Return articuloBL.GetProductsCodeUnidadComercial(be)
    End Function

    Public Function GetProductsBarCodeAlmacen(be As detalleitems) As List(Of detalleitems) Implements IContService.GetProductsBarCodeAlmacen
        Dim productoBL As New detalleitemsBL
        Return productoBL.GetProductsBarCodeAlmacen(be)
    End Function

    Public Function ListPendingForUserWithImport(be As cajaUsuario) As List(Of cajaUsuario) Implements IContService.ListPendingForUserWithImport
        Dim CajaUsuarioBL As New CajaUsuarioBL
        Return CajaUsuarioBL.ListPendingForUserWithImport(be)
    End Function

    Public Function GetListaItemxEstable(itemBE As item) As System.Collections.Generic.List(Of Business.Entity.item) Implements ServiceContract.IContService.GetListaItemxEstable
        Dim TablaBL As New itemBL()
        Return TablaBL.GetListaItemxEstable(itemBE)
    End Function

    Public Function GetOrganizacion(be As organizacion) As List(Of organizacion) Implements ServiceContract.IContService.GetOrganizacion
        Dim TablaBL As New organizacionBL()
        Return TablaBL.GetOrganizacion(be)
    End Function

    Public Function GetProductoXAreaOperativaxID(be As ProductoXAreaOperativa) As List(Of ProductoXAreaOperativa) Implements ServiceContract.IContService.GetProductoXAreaOperativaxID
        Dim TablaBL As New productoxAreaOperativaBL()
        Return TablaBL.GetProductoXAreaOperativaxID(be)
    End Function

    Public Function GetInsertarProductoXAreaOperativaSingle(con As productoxAreaOperativa) As productoxAreaOperativa Implements ServiceContract.IContService.GetInsertarProductoXAreaOperativaSingle
        Dim TablaBL As New productoxAreaOperativaBL()
        Return TablaBL.GetInsertarProductoXAreaOperativaSingle(con)
    End Function

    Public Function GetListar_numeracionBoletasAll(numeracionBoletasBE As numeracionBoletas) As List(Of numeracionBoletas) Implements IContService.GetListar_numeracionBoletasAll
        Dim ventaBL As New numeracionBoletasBL
        Return ventaBL.GetListar_numeracionBoletasAll(numeracionBoletasBE)
    End Function

    Public Function GetListar_numeracionBoletasXCargo(numeracionBoletasBE As numeracionBoletas) As List(Of numeracionBoletas) Implements IContService.GetListar_numeracionBoletasXCargo
        Dim ventaBL As New numeracionBoletasBL
        Return ventaBL.GetListar_numeracionBoletasXCargo(numeracionBoletasBE)
    End Function

    Public Function SaveGroupCajaGeneralApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer Implements IContService.SaveGroupCajaGeneralApertura
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.SaveGroupCajaGeneralApertura(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Function

    Public Function SaveCajaAdministrativaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer Implements IContService.SaveCajaAdministrativaApertura
        Dim documentoCajaBL As New documentoCajaBL
        Return documentoCajaBL.SaveCajaAdministrativaApertura(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Function

    Public Function GetMovimientosCajaCajeroTipoMonedaAdmi(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaCajeroTipoMonedaAdmi
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosCajaCajeroTipoMonedaAdmi(be)
    End Function

    Public Function GetMovimientosCajaCajeroDetalleAdmi(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaCajeroDetalleAdmi
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosCajaCajeroDetalleAdmi(be)
    End Function

    Public Function GetMovimientosFormaPagoCajeroMonedaAdmi(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosFormaPagoCajeroMonedaAdmi
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosFormaPagoCajeroMonedaAdmi(be)
    End Function

    Public Function GetMovimientosFormaPagoCajeroDetalleAdmi(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosFormaPagoCajeroDetalleAdmi
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosFormaPagoCajeroDetalleAdmi(be)
    End Function

    Public Function GetMovimientosCajaComprobanteVentasAdmi(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaComprobanteVentasAdmi
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosCajaComprobanteVentasAdmi(be)
    End Function

    Public Function ObtenerCajaOnlinePOS(strIdEmpresa As String, intIdEstablecimiento As Integer, strMEs As String, strAnio As String, strEntidadFinanciera As String) As List(Of documentoCaja) Implements IContService.ObtenerCajaOnlinePOS
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnline(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlineConTramiteDocPOS(strIdEmpresa As String, intIdEstablecimiento As Integer, strMEs As String, strAnio As String, strEntidadFinanciera As String, listaEstado As List(Of String)) As List(Of documentoCaja) Implements IContService.ObtenerCajaOnlineConTramiteDocPOS
        Dim documentoBL As New documentoCajaBL
        Return documentoBL.ObtenerCajaOnlineConTramiteDocPOS(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, listaEstado)
    End Function

    Public Function ListBoxClosedPendingCount(be As cajaUsuario) As Integer Implements IContService.ListBoxClosedPendingCount
        Dim CajaUsuarioBL As New CajaUsuarioBL
        Return CajaUsuarioBL.ListBoxClosedPendingCount(be)
    End Function

#Region "ORGANIGRAMA"
    Public Function GetObtenerOrganizacion(strEmpresa As String) As List(Of organizacion) Implements IContService.GetObtenerOrganizacion
        Dim OrgandBL As New organizacionBL()
        Return OrgandBL.GetObtenerOrganizacion(strEmpresa)
    End Function

    Public Function SaveOrganizacion(OrganizacionBE As organizacion) As organizacion Implements IContService.SaveOrganizacion
        Dim SaveOrgBL As New organizacionBL()
        Return SaveOrgBL.SaveOrganizacion(OrganizacionBE)
    End Function

    Public Function GetObtenerParcialOrgani(strBE As organizacion) As List(Of organizacion) Implements IContService.GetObtenerParcialOrgani
        Dim OrgandBL As New organizacionBL()
        Return OrgandBL.GetObtenerParcialOrgani(strBE)
    End Function

    Public Sub ListOrgani(ByVal OrganizacionBE As List(Of organizacion)) Implements IContService.ListOrgani
        Dim OrgandBL As New organizacionBL()
        OrgandBL.ListOrgani(OrganizacionBE)
    End Sub
#End Region

#Region "CENTRO DE COSTOS"
    Public Function GetObtenerEstablecimiento(strEmpresa As String) As List(Of centrocosto) Implements IContService.GetObtenerEstablecimiento
        Dim centroBL As New centrocostoBL()
        Return centroBL.GetObtenerEstablecimiento(strEmpresa)
    End Function


    Public Function GetObtenerEstablecimiento2(strEmpresa As String) As List(Of centrocosto) Implements IContService.GetObtenerEstablecimiento2
        Dim centroBL2 As New centrocostoBL()
        Return centroBL2.GetObtenerEstablecimiento2(strEmpresa)
    End Function

    Public Function GetObtenerUnidadNegocio(IsEstablecimiento As Integer) As List(Of centrocosto) Implements IContService.GetObtenerUnidadNegocio
        Dim UnidadBL As New centrocostoBL()
        Return UnidadBL.GetObtenerUnidadNegocio(IsEstablecimiento)
    End Function

    Public Function InsertListaEstablecimiento(estableBE As centrocosto) As List(Of centrocosto) Implements IContService.InsertListaEstablecimiento
        Dim UnidadBL As New centrocostoBL()
        Return UnidadBL.InsertListaEstablecimiento(estableBE)
    End Function

    Public Function InsertListaEstablecimientoApoyo(estableBE As centrocosto) As List(Of centrocosto) Implements IContService.InsertListaEstablecimientoApoyo
        Dim UnidadBL As New centrocostoBL()
        Return UnidadBL.InsertListaEstablecimientoApoyo(estableBE)
    End Function


#End Region
#Region "JERARQUIA"
    Public Sub SaveJerarquia(JerarBe As List(Of jerarquia)) Implements IContService.SaveJerarquia
        Dim JERARbl As New JerarquiaBL()
        JERARbl.SaveJerarquia(JerarBe)
    End Sub

    Public Function GetObtenerJerar(Idorgani As Integer) As List(Of jerarquia) Implements IContService.GetObtenerJerar
        Dim JERARbl As New JerarquiaBL()
        Return JERARbl.GetObtenerJerar(Idorgani)
    End Function

#End Region

    Public Sub SavePerfilAnexo(ByVal PerfilAnexoBE As List(Of perfilAnexo)) Implements IContService.SavePerfilAnexo
        Dim CajaUsuarioBL As New perfilAnexoBL
        CajaUsuarioBL.SavePerfilAnexo(PerfilAnexoBE)
    End Sub

    Public Sub UpdatePerfilAnexoSingle(ByVal PerfilAnexoBE As perfilAnexo) Implements IContService.UpdatePerfilAnexoSingle
        Dim CajaUsuarioBL As New perfilAnexoBL
        CajaUsuarioBL.UpdatePerfilAnexoSingle(PerfilAnexoBE)
    End Sub

    Public Sub SavePerfilAnexoSingle(ByVal PerfilAnexoBE As perfilAnexo) Implements IContService.SavePerfilAnexoSingle
        Dim CajaUsuarioBL As New perfilAnexoBL
        CajaUsuarioBL.SavePerfilAnexoSingle(PerfilAnexoBE)
    End Sub

    Public Function GetObtenerPerfilAnexo(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo) Implements IContService.GetObtenerPerfilAnexo
        Dim CajaUsuarioBL As New perfilAnexoBL
        Return CajaUsuarioBL.GetObtenerPerfilAnexo(PerfilAnexoBE)
    End Function

    Public Function GetObtenerPerfilAnexoXID(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo) Implements IContService.GetObtenerPerfilAnexoXID
        Dim CajaUsuarioBL As New perfilAnexoBL
        Return CajaUsuarioBL.GetObtenerPerfilAnexoXID(PerfilAnexoBE)
    End Function

    Public Function GetObtenerPerfilIDestablecimiento(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo) Implements IContService.GetObtenerPerfilIDestablecimiento
        Dim CajaUsuarioBL As New perfilAnexoBL
        Return CajaUsuarioBL.GetObtenerPerfilIDestablecimiento(PerfilAnexoBE)
    End Function

    Public Function GetObtenerOrganigramaXPerfil(strBE As organizacion) As List(Of organizacion) Implements IContService.GetObtenerOrganigramaXPerfil
        Dim CajaUsuarioBL As New OrganizacionBL
        Return CajaUsuarioBL.GetObtenerOrganigramaXPerfil(strBE)
    End Function

    Public Function GetMovimientosCajaFullCajerosAdmi(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosCajaFullCajerosAdmi
        Dim CajaUsuarioBL As New documentoCajaBL
        Return CajaUsuarioBL.GetMovimientosCajaFullCajerosAdmi(be)
    End Function

    Public Function GetConfigurationPaySaldoCajero(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos) Implements IContService.GetConfigurationPaySaldoCajero
        Dim CajaUsuarioBL As New estadosFinancierosConfiguracionPagosBL
        Return CajaUsuarioBL.GetConfigurationPaySaldoCajero(Be)
    End Function

    Public Function HistorialCobrosCajeroAdmi(iNtPadre As Integer) As List(Of documentoCaja) Implements IContService.HistorialCobrosCajeroAdmi
        Dim CajaUsuarioBL As New documentoCajaBL
        Return CajaUsuarioBL.HistorialCobrosCajeroAdmi(iNtPadre)
    End Function

    Public Function GetMovimientosBancariosPendientes(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetMovimientosBancariosPendientes
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosBancariosPendientes(be)
    End Function

    Public Sub ConfirmacionDineroBancario(be As List(Of documentoCaja)) Implements IContService.ConfirmacionDineroBancario
        Dim documentoCajaBL As New documentoCajaBL
        documentoCajaBL.ConfirmacionDineroBancario(be)
    End Sub

    Public Function GetConfigurationPayBancarios(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos) Implements IContService.GetConfigurationPayBancarios
        Dim notaBL As New estadosFinancierosConfiguracionPagosBL
        Return notaBL.GetConfigurationPayBancarios(Be)
    End Function

    Public Function GetMovimientosEfectivoCajero(be As cajaUsuario) As List(Of documentoCaja) Implements IContService.GetMovimientosEfectivoCajero
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosEfectivoCajero(be)
    End Function

    Public Sub ConfirmacionBancaria(be As List(Of documentoCaja)) Implements IContService.ConfirmacionBancaria
        Dim cajaBL As New documentoCajaBL
        cajaBL.ConfirmacionBancaria(be)
    End Sub

    Public Function GetMovimientosBancariosConfirmados(be As documentoCaja) As List(Of documentoCaja) Implements IContService.GetMovimientosBancariosConfirmados
        Dim cajaBL As New documentoCajaBL
        Return cajaBL.GetMovimientosBancariosConfirmados(be)
    End Function

    Public Function ListarVentasTipoClientePeriodo(be As documentoventaAbarrotes, ListaTipo As List(Of String)) As List(Of documentoventaAbarrotes) Implements IContService.ListarVentasTipoClientePeriodo
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.ListarVentasTipoClientePeriodo(be, ListaTipo)
    End Function

    Public Function GetListarRegistroNotasVentas(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes) Implements IContService.GetListarRegistroNotasVentas
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetListarRegistroNotasVentas(intIdEstablec, strPeriodo)
    End Function

    Public Function GetBuscarComprobante(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes) Implements IContService.GetBuscarComprobante
        Dim documentoventaBL As New documentoventaAbarrotesBL
        Return documentoventaBL.GetBuscarComprobante(be)
    End Function

    Public Function UbicarCajaUsuarioXID(intIdCaja As Integer) As cajaUsuario Implements IContService.UbicarCajaUsuarioXID
        Dim documentoBL As New CajaUsuarioBL
        Return documentoBL.UbicarCajaUsuarioXID(intIdCaja)
    End Function

    Public Sub UpdateGuiaXEstado(doc As Integer, estado As String) Implements IContService.UpdateGuiaXEstado
        Dim documentoabarrotesbl As New documentoGuiaBL
        documentoabarrotesbl.UpdateGuiaXEstado(doc, estado)
    End Sub

    Public Function GetVentaIDGuia(be As documento) As documentoGuia Implements IContService.GetVentaIDGuia
        Dim notaBL As New documentoGuiaBL
        Return notaBL.GetVentaIDGuia(be)
    End Function

    Public Function GetREcuperarImpresion(be As documento) As documentoGuia Implements IContService.GetREcuperarImpresion
        Dim notaBL As New documentoGuiaBL
        Return notaBL.GetREcuperarImpresion(be)
    End Function

    Public Function ListaCpePendientes(fecha As Date, idEmpresa As String) As List(Of documentoventaAbarrotes) Implements IContService.ListaCpePendientes
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.ListaCpePendientes(fecha, idEmpresa)
    End Function

    Public Function AnuladosPendientesCPE(fecha As Date, ruc As String) As List(Of documentoventaAbarrotes) Implements IContService.AnuladosPendientesCPE
        Dim entidadBL As New documentoventaAbarrotesBL()
        Return entidadBL.AnuladosPendientesCPE(fecha, ruc)
    End Function

    Public Function ObtenerPersona(PersonaBE As Persona) As List(Of Persona) Implements IContService.ObtenerPersona
        Throw New NotImplementedException()
    End Function

    Public Function SavePLantillaInfra(infraestructuraBE As List(Of infraestructura)) As Integer Implements IContService.SavePLantillaInfra
        Throw New NotImplementedException()
    End Function

    Public Function SaveActivoInfra(infraestructuraBE As List(Of infraestructura)) As Integer Implements IContService.SaveActivoInfra
        Throw New NotImplementedException()
    End Function

    Public Function getCONTEOPlANTILLA(infraestructuraBE As infraestructura) As Integer Implements IContService.getCONTEOPlANTILLA
        Throw New NotImplementedException()
    End Function

    Public Function GetPlantillaActivo(plantillaActivoBE As PlantillaActivo) As List(Of PlantillaActivo) Implements IContService.GetPlantillaActivo
        Throw New NotImplementedException()
    End Function

    Public Function getDistribucionInfraestructuraPlantilla(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura) Implements IContService.getDistribucionInfraestructuraPlantilla
        Throw New NotImplementedException()
    End Function

    Public Function updateDistribucionNumeracion(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura) Implements IContService.updateDistribucionNumeracion
        Throw New NotImplementedException()
    End Function

    Public Function ListadoServicios(SERVCIOBE As servicio) As List(Of servicio) Implements IContService.ListadoServicios
        Throw New NotImplementedException()
    End Function


End Class