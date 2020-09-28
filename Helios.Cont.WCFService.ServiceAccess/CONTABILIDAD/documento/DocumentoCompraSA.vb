Imports Helios.Cont.Business.Entity
Public Class DocumentoCompraSA

#Region "DEPURADO"
    Public Function GetListarComprasPorDia_CONT(documentocompraBE As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorDia_CONT(documentocompraBE)
    End Function

    Public Function GetListarComprasPorDia_CONT_CONTADO(documentocompraBE As documentocompra, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorDia_CONT_CONTADO(documentocompraBE, UsuarioCaja)
    End Function

    Public Function GetListarComprasPorPeriodoGeneral_CONT_CONTADO(documentocompraBE As documentocompra, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(documentocompraBE, strPeriodo, UsuarioCaja)
    End Function

#End Region

    Public Function GetListarComprasPorDia_CONT_CREDITO(intIdEstablecimiento As Integer, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorDia_CONT_CREDITO(intIdEstablecimiento, UsuarioCaja)
    End Function

    Public Function GetComprasCriterio(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetComprasCriterio(be)
    End Function

    Public Function GrabarReclamacionCompromisoCobro(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarReclamacionCompromisoCobro(objDocumento)
    End Function

    Function GetCuentasCobrarReclamacionesSoloProveedor(parametro As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasCobrarReclamacionesSoloProveedor(parametro)
    End Function

    Function GetCuentasCobrarReclamacionesProveedor(parametro As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasCobrarReclamacionesProveedor(parametro)
    End Function

    Public Function GrabarCompraDocumentoGeneral(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarCompraDocumentoGeneral(objDocumento)
    End Function

    Public Function DocumentoCompraAfectadoNC(be As documentocompra) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoCompraAfectadoNC(be)
    End Function

    Public Function SaveNotaCreditoCompraFE(objDocumento As documento,
                                      nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveNotaCreditoCompraFE(objDocumento, nDocumentoNota, nDocumentoSaldoVenta)
    End Function


    Public Function GetInventarioInicial(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventarioInicial(be)
    End Function

    Public Sub GrabarDocumentoCajaDevolucionCobro(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDocumentoCajaDevolucionCobro(be)
    End Sub

    Public Function HistorialDePagos(iNtPadre As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.HistorialDePagos(iNtPadre)
    End Function

    Public Function GrabarAporteGeneral(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarAporteGeneral(be)
    End Function

    Public Function GetListarTodasCompras(be As documentocompra, tipoConsulta As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarTodasCompras(be, tipoConsulta)
    End Function

    Public Function GetCompraID(be As documento) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCompraID(be)
    End Function

    Public Function GrabarCompraVinculada(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarCompraVinculada(be)
    End Function

    Public Function GrabarCompraEquivalencia(be As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarCompraEquivalencia(be)
    End Function

    Public Function GetCuentasPorpagarProveedorPendientes(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasPorpagarProveedorPendientes(be)
    End Function

    Public Function GetAcumuladoCuentasPagarByAnio(be As documentocompra) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAcumuladoCuentasPagarByAnio(be)
    End Function

    Public Function GetEscaneadasConteoNotaCompra(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEscaneadasConteoNotaCompra(be)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="be">IdDocumento|Estado Pago</param>
    ''' <returns></returns>
    Public Function GetPagosByDocumento(be As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPagosByDocumento(be)
    End Function

    ''' <summary>
    ''' Ubicar DocumentoCompra Incluido proveedor 
    ''' </summary>
    ''' <param name="idDocumento"></param>
    ''' <returns></returns>
    Public Function GetUbicarCompraPorID(idDocumento As Integer) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarCompraPorID(idDocumento)
    End Function


    ''' <summary>
    ''' Registro de notas de compras por periodo
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function GetNotasDeComprasPorPeriodo(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNotasDeComprasPorPeriodo(be)
    End Function

    ''' <summary>
    ''' Contabilizar cuentas por pagar anual
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function GetResumenAnualCuentasPagar(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetResumenAnualCuentasPagar(be)
    End Function

    Public Function GetStatusAprobacionListNotaCompra(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetStatusAprobacionListNotaCompra(be)
    End Function

    Public Function GetEscaneadasNotaComprasseriodo(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEscaneadasNotaComprasseriodo(be)
    End Function

    Public Function GetEscaneadasCRapidasListNC(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEscaneadasCRapidasListNC(be)
    End Function

    Public Function GetNotaCompraRecientes(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNotaCompraRecientes(be)
    End Function

    Public Function GetComprasPorPagarOpcion(be As documentocompra, opcion As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetComprasPorPagarOpcion(be, opcion)
    End Function

    Public Function GetAlertaTransferenciasConteo(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAlertaTransferenciasConteo(be)
    End Function

    Public Sub GrabarPedidoLogistica(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarPedidoLogistica(objDocumento)
    End Sub

    Public Function GetEscaneadasCRapidasPeriodo(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEscaneadasCRapidasPeriodo(be)
    End Function

    Public Function GetEscaneadasCRapidasList(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEscaneadasCRapidasList(be)
    End Function

    Public Function GetEscaneadasCRapidas(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEscaneadasCRapidas(be)
    End Function

    Public Function GetCRapidaRecientes(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCRapidaRecientes(be)
    End Function

    Public Sub RechazarCompraRapida(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.RechazarCompraRapida(be)
    End Sub

    Public Function GetContadorCRapidaRecientes(be As documentocompra) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetContadorCRapidaRecientes(be)
    End Function

    Public Function GetStatusAprobacionList(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetStatusAprobacionList(be)
    End Function

    Public Function GetStatusAprobacion(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetStatusAprobacion(be)
    End Function

    Public Function GrabarSalidaInventario(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarSalidaInventario(objDocumento)
    End Function

    Public Function GetDocumentosCompraByTipo(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDocumentosCompraByTipo(be)
    End Function

    Public Sub GrabarCompraAdicionalLoteExistente(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCompraAdicionalLoteExistente(be)
    End Sub

    Public Sub GrabarNotaCompraDirecta(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarNotaCompraDirecta(be)
    End Sub

    Public Sub AnularNotaDeCompra(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.AnularNotaDeCompra(documentoBE)
    End Sub

    Public Function GetListaTrasnferenciasPersonaXconfirmar(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaTrasnferenciasPersonaXconfirmar(be)
    End Function

    Public Function GetListaPersonasTrasnferenciasXconfirmar(be As documentocompra) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaPersonasTrasnferenciasXconfirmar(be)
    End Function

    Public Sub ConfirmarListaRapida(lista As List(Of documento), compra As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmarListaRapida(lista, compra)
    End Sub

    Public Sub AnularSalidaInv(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.AnularSalidaInv(documentoBE)
    End Sub

    Public Sub AnularEntradainv(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.AnularEntradainv(documentoBE)
    End Sub

    Public Sub AnularCompra(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.AnularCompra(documentoBE)
    End Sub

    Public Function GetCuentasPorPagarStatusCount(be As documentocompra) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasPorPagarStatusCount(be)
    End Function

    Public Function GetListarPercepciones(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarPercepciones(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GrabarPercepcion(objDocumento As documento, nDocumentoNota As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarPercepcion(objDocumento, nDocumentoNota)
    End Function

    Public Function GetComprasPorAprobarPago(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetComprasPorAprobarPago(be)
    End Function

    Public Function ServiciosSinCosteo(compraBE As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ServiciosSinCosteo(compraBE)
    End Function

    Public Function ListaCompraDeServicios(compraBE As documentocompra, tipoCosteo As String) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaCompraDeServicios(compraBE, tipoCosteo)
    End Function

    Public Function SaveEntradasProduccion(objDocumento As documento, idEntregable As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveEntradasProduccion(objDocumento, idEntregable)
    End Function

    Public Function GetNumeracionCompra(be As documentocompra) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNumeracionCompra(be)
    End Function

    Public Function EnvioDeProductosTerminados(periodo As String, idEntregable As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.EnvioDeProductosTerminados(periodo, idEntregable)
    End Function

    Public Function ListaRecursosGastoEntregable(compraBE As documentocompra, idEntregable As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosGastoEntregable(compraBE, idEntregable)
    End Function

    Public Sub StatusApruebaPagoFactura(be As documentocompra)
        Dim servicio = General.GetHeliosProxy()
        servicio.StatusApruebaPagoFactura(be)
    End Sub

    Public Sub GrabarSalidaProduccion(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarSalidaProduccion(objDocumento)
    End Sub

    Public Function SaveOtrasSalidasProduccion(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveOtrasSalidasProduccion(objDocumento)
    End Function

    Public Function CompensacionDocCompraAnticipo(objDocumento As documento, objDoc As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CompensacionDocCompraAnticipo(objDocumento, objDoc)
    End Function

    Public Function GetListarComprasPorAnioEmpresa(empresa As String, anio As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorAnioEmpresa(empresa, anio)
    End Function

    Public Function GetComprasDelDiaxOperacion(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetComprasDelDiaxOperacion(be)
    End Function

    Public Sub EliminarSalidaInv(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarSalidaInv(documentoBE)
    End Sub

    Public Sub EditarOtraSalida(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarOtraSalida(objDocumento)
    End Sub

    Public Sub EliminarEntradainv(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarEntradainv(documentoBE)
    End Sub

    Public Sub EliminarCompra(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCompra(documentoBE)
    End Sub

    Public Sub EditarOtraEntrada(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarOtraEntrada(objDocumento)
    End Sub

    Public Sub EditarCompra(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarCompra(documentoBE)
    End Sub

    Public Function ListaRecursosCostoInventarioEntregables(compraBE As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosCostoInventarioEntregables(compraBE)
    End Function

    Public Sub GrabarNotaCompra(be As documento)
        Dim servicio = General.GetHeliosProxy()
        servicio.GrabarNotaCompra(be)
    End Sub

    Public Function ListaRecursosCostoEntregable(compraBE As documentocompra, idEntregable As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosCostoEntregable(compraBE, idEntregable)
    End Function

    Public Function GetCobrosPendienteXcliente(idEntidad As Integer, anio As Integer) As List(Of usp_GetCuentasXcobrarXclienteAnual_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCobrosPendienteXcliente(idEntidad, anio)
    End Function

    Public Function GetClientesXcobrar(anio As Integer, empresa As String) As List(Of usp_GetClientesXcobrar_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetClientesXcobrar(anio, empresa)
    End Function

    Public Sub EliminarAsigancionDeAsientoInventario(be As documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarAsigancionDeAsientoInventario(be)
    End Sub

    Public Sub GetDetraccionChangeStateByDocumento(be As documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetDetraccionChangeStateByDocumento(be)
    End Sub

    Public Function GetConsultaCuentasPorpagarFiltro(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultaCuentasPorpagarFiltro(be)
    End Function


    ''' <summary>
    ''' Proveedores por pagar por año
    ''' </summary>
    ''' <param name="anio">Ingresar el año a consultar</param>
    ''' <param name="empresa">Identificar a la empresa</param>
    ''' <returns></returns>
    Public Function GetProveedoresXpagar(anio As Integer, empresa As String) As List(Of usp_GetProveedoresXpagar_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProveedoresXpagar(anio, empresa)
    End Function

    ''' <summary>
    ''' Comprobantes pendientes de pago de proveedores
    ''' </summary>
    ''' <param name="idEntidad">Codigo proveedor</param>
    ''' <param name="anio">año a consultar deudas</param>
    ''' <returns></returns>
    Public Function GetPagosPendienteXproveedor(idEntidad As Integer, anio As Integer) As List(Of usp_GetCuentasXpagarXproveedorAnual_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPagosPendienteXproveedor(idEntidad, anio)
    End Function

    Public Function GetTransferenciasByEmpresa(intIdEstablecimiento As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTransferenciasByEmpresa(intIdEstablecimiento)
    End Function

    Public Function TieneProveedoresApertura(be As documentocompra) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TieneProveedoresApertura(be)
    End Function

    Public Function GetTieneArticulosEnTransitoCompra(be As documentocompra) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTieneArticulosEnTransitoCompra(be)
    End Function

    Public Function CompraEsvalida(nDOcumento As documentocompra) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CompraEsvalida(nDOcumento)
    End Function

    Public Function GetExistenComprasSuperiores(be As documentocompra) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenComprasSuperiores(be)
    End Function

    Public Function SaveReversionOtraSalida(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveReversionOtraSalida(objDocumento, nDocumentoCaja, nDocumentoSaldoVenta)
    End Function

    Public Function SaveReversionOtraEntrada(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveReversionOtraEntrada(objDocumento, nDocumentoCaja, nDocumentoSaldoVenta)
    End Function

    Public Sub confirmarTrasnferenciaPedniente(compra As documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.confirmarTrasnferenciaPedniente(compra)
    End Sub

    Public Function GetCambiosDeArticulo(be As documentocompra) As List(Of documentocompra)
        Dim servicio = General.GetHeliosProxy()
        Return servicio.GetCambiosDeArticulo(be)
    End Function

    Public Function GrabarCambioArticulo(objDocumento As documento, art As detalleitems) As Integer
        Dim servicio = General.GetHeliosProxy()
        Return servicio.GrabarCambioArticulo(objDocumento, art)
    End Function

    Public Function GetComprasObservadas(be As documentocompra) As List(Of documentocompra)
        Dim servicio = General.GetHeliosProxy()
        Return servicio.GetComprasObservadas(be)
    End Function

    Public Sub GetChangeState(be As documentocompra)
        Dim servicio = General.GetHeliosProxy()
        servicio.GetChangeState(be)
    End Sub

    Public Function GenerarTXTcompras(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GenerarTXTcompras(intIdEstablecimiento, strPeriodo, UsuarioCaja)
    End Function

    Public Function GetConsultaCuentasPorpagarAnt(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultaCuentasPorpagarAnt(be)
    End Function

    Public Function UbicarComprasXCompensar(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarComprasXCompensar(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function CompensacionDocumentos(objDocumento As documento, objDoc As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CompensacionDocumentos(objDocumento, objDoc)
    End Function

    Public Function GetArticulosCompradosByPeriodo(be As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetArticulosCompradosByPeriodo(be)
    End Function

    Public Sub CambiarPeriodoCompra(be As documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarPeriodoCompra(be)
    End Sub

    Public Function SaveCompraNotaDevolucionGasto(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraNotaDevolucionGasto(objDocumento, nDocumentoCaja, nDocumentoSaldoVenta)
    End Function

    Public Function ListadoComprobateNotasXidPadre(iNtPadre As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoComprobateNotasXidPadre(iNtPadre)
    End Function


    Public Sub GetEliminarCierreParcialTotal(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetEliminarCierreParcialTotal(be)
    End Sub

    Public Sub GetEliminarCierreTotal(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetEliminarCierreTotal(be)
    End Sub

    Public Sub GrabarCambioTipoInventario(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCambioTipoInventario(objDocumento)
    End Sub

    Public Sub GrabarRetornoProductosTerminados(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarRetornoProductosTerminados(objDocumento)
    End Sub

    Public Function GetConsultaCuentasPorpagarTodosProveedores(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultaCuentasPorpagarTodosProveedores(be)
    End Function

    Public Function GetConsultaCuentasPorpagar(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultaCuentasPorpagar(be)
    End Function

    Public Function ListaRecursosCostoInventario(compraBE As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosCostoInventario(compraBE)
    End Function

    Public Function UbicarTodosPagosPendienteMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarTodosPagosPendienteMNME(strEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetSumaComprasDelDia(be As documentocompra) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaComprasDelDia(be)
    End Function

    Public Function GetSumaComprasDelDiaAllEmpresa(be As documentocompra) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaComprasDelDiaAllEmpresa(be)
    End Function

    Public Function CobrosGeneralesAsiento() As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CobrosGeneralesAsientos()
    End Function

    Public Function DeudasGeneralesAsiento() As List(Of documentoLibroDiarioDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DeudasGeneralesAsiento()
    End Function

    Public Function DeudasGenerales() As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DeudasGenerales()
    End Function


    Public Function UbicarCuentasXPagarComerciales() As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCuentasXPagarComerciales()
    End Function

    Public Function UbicarPagosProveedorPendienteMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosPorProveedorPendienteMNME(strEmpresa, intIdEstablecimiento, strRuc)
    End Function

    Public Function UbicarPagosProveedorPendiente(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strMoneda As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosPorProveedorPendiente(strEmpresa, intIdEstablecimiento, strRuc, strMoneda)
    End Function

    Public Function UbicarPagosPorTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosPorTodo(strEmpresa, intIdEstablecimiento, strMoneda)
    End Function


    Public Function UbicarPagosPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMoneda As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strPeriodo, strMoneda)
    End Function

    Public Function UbicarPagosPorProveedorTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String, idprov As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosPorProveedorTodo(strEmpresa, intIdEstablecimiento, strMoneda, idprov, strPeriodo)
    End Function

    Public Function UbicarPagosPorProveedor(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPagosPorProveedor(strEmpresa, intIdEstablecimiento, strMoneda)
    End Function

    Public Function GrabarProduccion(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarProduccion(objDocumento)
    End Function

    Public Function GetAlertaMovimientosAlmacen() As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAlertaMovimientosAlmacen()
    End Function

    Public Function GetReporteMovAlmcenByEntradaSalida(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetReporteMovAlmcenByEntradaSalida(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetReporteTransferenciaAlmacen(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetReporteTransferenciaAlmacen(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function UbicarCompraPorProveedorXperiodoAnt(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCompraPorProveedorXperiodoAnt(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function UbicarPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, tipo)
    End Function

    Public Function UbicarCompraPorProveedorXperiodoAntFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCompraPorProveedorXperiodoAntFull(strEmpresa, intIdEstablecimiento, strPeriodo, tipo)
    End Function

    Public Function ListaTotalXCompraTransito(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaTotalXCompraTransito(listaidPersona, fechaInicio, fechaFin, periodo, tipo)
    End Function

    Public Function ListaCompraAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaCompraAll(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio)
    End Function

    Public Function GetListarComprasTransitoInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasTransitoInfGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function

    Public Function GetListarTransferenciaInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarTransferenciaInfGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function

    Public Function GetListarComprasTransitoInfGeneralRecepcion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasTransitoInfGeneralRecepcion(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function

    Public Function GetListarComprasPorPeriodoGeneralInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoGeneralInfGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function


    Public Function ListaTotalXCompra(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaTotalXCompra(listaidPersona, fechaInicio, fechaFin, periodo, tipo)
    End Function

    Public Function ListaTotalXCompraAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaTotalXCompraAll(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio, intMes, intDia)
    End Function

    Public Function GetCountExistenciaTransito(be As documentocompra) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCountExistenciaTransito(be)
    End Function

    Public Function GetExistenciaTransito(be As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciaTransito(be)
    End Function

    Public Function GetComprasDeApertura(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetComprasDeApertura(be)
    End Function

    Public Function GetCuentasPorPagarInicio(be As documentocompra) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasPorPagarInicio(be)
    End Function

    Public Function GetConteoDetracciones(be As documentocompra) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConteoDetracciones(be)
    End Function

    Public Sub UpdateDataDetraccion(be As documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateDataDetraccion(be)
    End Sub

    Public Function GetListadoDetracciones(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoDetracciones(be)
    End Function

    Public Function GetNumFinanzasSinAsiento(be As documentoCaja) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNumFinanzasSinAsiento(be)
    End Function

    Public Function GetInventariosSinAsiento(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventariosSinAsiento(be)
    End Function

    Public Function GetFinanzasSinAsiento(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetFinanzasSinAsiento(be)
    End Function

    Public Function GetNumAlertasInventariosSinAsiento(be As documentocompra) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNumAlertasInventariosSinAsiento(be)
    End Function

    Public Function GetTotalComprasByPeriodoProveedor(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTotalComprasByPeriodoProveedor(be)
    End Function

    Public Function GetSumaNotasXperiodo(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaNotasXperiodo(be)
    End Function

    Public Function GetTatalResumenComprasXtipo(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTatalResumenComprasXtipo(be)
    End Function

    Public Function GetNumComprasXparameter(be As documentocompra, caso As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNumComprasXparameter(be, caso)
    End Function

    Public Function ListadoComprobantesPorORP(compraBE As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoComprobantesPorORP(compraBE)
    End Function

    Public Function GrabarProductosTerminados(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarProductosTerminados(objDocumento)
    End Function

    Public Function ListaRecursosCosto(compraBE As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosCosto(compraBE)
    End Function

    Public Sub CerrarTipoCambioDolaresPeriodo(lista As List(Of documentocompra))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CerrarTipoCambioDolaresPeriodo(lista)
    End Sub

    Public Function CerrarComprasMonedaExtranjera(compraBE As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CerrarComprasMonedaExtranjera(compraBE)
    End Function

    Public Function UbicarExcedenteCompraPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As String, intmoneda As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarExcedenteCompraPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, intmoneda)
    End Function

    Public Function GrabarNotaDebito(objDocumento As documento, nDocumentoNota As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarNotaDebito(objDocumento, nDocumentoNota)
    End Function

    Public Sub DeleteReciboHonorario(nDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteReciboHonorario(nDocumento)
    End Sub

    Public Sub UpdateReciboHonorario(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateReciboHonorario(objDocumento)
    End Sub

    Public Sub EliminarNotaCreditoMetodoNuevo(obj As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarNotaCreditoMetodoNuevo(obj)
    End Sub

    Public Sub EliminarNotaCreditoBonificacion(obj As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarNotaCreditoBonificacion(obj)
    End Sub

    Public Sub EliminarNotaDebitoMetodoNuevo(obj As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarNotaDebitoMetodoNuevo(obj)
    End Sub

    Public Sub ListaComprasAutoriza(objListaCompras As List(Of documentocompra))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListaComprasAutoriza(objListaCompras)
    End Sub

    Public Function GetListAllComprasxDia(intIdEstablecimiento As Integer, Optional Dia As DateTime = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListAllComprasxDia(intIdEstablecimiento, Dia)
    End Function





    Public Function GetListAllCompras(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListAllCompras(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetSumaCuentasXpagar(intIdEstable As Integer, strPeriodo As String) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaCuentasXpagar(intIdEstable, strPeriodo)
    End Function

    Public Function GetCuentasXpagarPorFechaVencimiento(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, caso As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasXpagarPorFechaVencimiento(strEmpresa, intIdEstablecimiento, strRuc, caso)
    End Function

    Public Function GetCuentasXpagarPorFechaPeriodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCuentasXpagarPorFechaPeriodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

#Region "SOLICITUDES"

#Region "ORDENES"

    Public Function GetListarOrdenCompraPorDia(intIdEmpresa As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarOrdenCompraPorDia(intIdEmpresa)
    End Function

    Public Function GetListarOrdenServicioPorDia(intIdEmpresa As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarOrdenServicioPorDia(intIdEmpresa)
    End Function

    Public Function GetListarOrdenServicio(intIdEmpresa As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarOrdenServicio(intIdEmpresa)
    End Function

    Public Function GetListarOrdenCompra(intIdEmpresa As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarOrdenCompra(intIdEmpresa)
    End Function
#End Region

    Public Function GrabarOrdenes(objDocumento As documento, objOtroDoc As documentoOtrosDatos) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarOrdenes(objDocumento, objOtroDoc)
    End Function

    Public Function UpdateDoc(ByVal be As documentocompra) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateDoc(be)
        Return True
    End Function

    Public Function UpdateOrdenCompra(ByVal be As documentocompradetalle, tipodoc As String) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateOrdenCompra(be, tipodoc)
        Return True
    End Function

    Public Function SaveDocumentoCompraSolicitud(nDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveDocumentoCompraSolicitud(nDocumento)
    End Function

    Public Function EstadoSoli(ByVal be As documentocompra) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EstadoSoli(be)
        Return True
    End Function

    Public Function GetListarSolicitudesCompra(intIdEmpresa As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarSolicitudesCompra(intIdEmpresa)
    End Function

    Public Function GetListarSolicitudesCompraDia(intIdEmpresa As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarSolicitudesCompraDia(intIdEmpresa)
    End Function
#End Region

    Public Function GetListarComprasPorPeriodoGeneralCentral(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoGeneralCentral(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarOrdenComprasPorPeriodoGeneral(intIdEstablecimiento As Integer, strPeriodo As String, tipoOrden As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarOrdenComprasPorPeriodoGeneral(intIdEstablecimiento, strPeriodo, tipoOrden)
    End Function

    Public Function GetListarOrdenServiciosPorPeriodoGeneral(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarOrdenServiciosPorPeriodoGeneral(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarComprasPorAnio(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorAnio(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarComprasPorANioGeNeral(intIdEstablecimiento As Integer, strANio As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorANioGeNeral(intIdEstablecimiento, strANio)
    End Function

    Public Function ListarNotasXidCompra(intIDoCumento As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarNotasXidCompra(intIDoCumento)
    End Function

    Public Function GetListarOrdenComprasPorFiltro(intIdEstablecimiento As Integer, strPeriodo As String, tipoOrden As String, intproveedor As Integer, moneda As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarOrdenComprasPorFiltro(intIdEstablecimiento, strPeriodo, tipoOrden, intproveedor, moneda)
    End Function


    Public Sub EditarEstadoCompra(intIdDocumento As Integer, strEstadoPago As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarEstadoCompra(intIdDocumento, strEstadoPago)
    End Sub

    Public Function UbicarCompraPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCompraPorProveedorXperiodo(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function UbicarCompraPorProveedorXperiodo2(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, strMoneda As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCompraPorProveedorXperiodo2(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, strMoneda)
    End Function

    Public Function TieneNotasCD(intIdDocumentoCompra As Integer) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TieneNotasCD(intIdDocumentoCompra)
    End Function

    Public Function SaveCompraAlCreditoConRecep(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), listaPrecio As List(Of listadoPrecios), Optional nDocumentoTributo As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraAlCreditoConRecep(objDocumento, objTotalesAlmacen, listaPrecio, nDocumentoTributo)
    End Function

    Public Sub GrabarCuetasPorPagarApertura(be As List(Of documento))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCuetasPorPagarApertura(be)
    End Sub

    Public Function SaveCompraNuevoMetodo(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraNuevoMetodo(objDocumento)
    End Function

    Public Function SaveCompraNuevoMetodoContado(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraNuevoMetodoContado(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveCompraNuevoMetodoOrden(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objOtrosDatos As documentoOtrosDatos) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraNuevoMetodoOrden(objDocumento, objTotalesAlmacen, objOtrosDatos)
    End Function

    Public Sub ActualualizarCompraSingle(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActualualizarCompraSingle(objDocumento)
    End Sub

    Public Function GrabarBonificaciones(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarBonificaciones(objDocumento, objTotalesAlmacen)
    End Function

    Public Function SaveRegistroHonorarios(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveRegistroHonorarios(objDocumento)
    End Function

    Public Function SaveRegistroCompraAnticipada(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveRegistroCompraAnticipada(objDocumento)
    End Function

    Public Sub UpdateCompraAlCreditoCnRecep(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen),
                               Optional nDocumentoTributo As documento = Nothing)

        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateCompraAlCreditoCnRecep(objDocumento, listaTotales, objDeleteTotales, nDocumentoTributo)
    End Sub

    Public Sub EliminarDocNotasRef(intIdDocumentoPadre As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarDocNotasRef(intIdDocumentoPadre)
    End Sub

    Public Function GetListarComprasPorProveedorCaja(intIdEstable As Integer, intIdProveedor As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorProveedorCaja(intIdEstable, intIdProveedor, strPeriodo)
    End Function

    Public Function GetListarComprasNotaCreditoPorProveedorCaja(intIdEstable As Integer, intIdProveedor As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasNotaCreditoPorProveedorCaja(intIdEstable, intIdProveedor, strPeriodo)
    End Function

    Public Function UbicarCompraPorProveedor(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCompraPorProveedor(strEmpresa, intIdEstablecimiento, intIdProveedor)
    End Function

    Public Function UbicarCompraPorProveedorSerie(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer, strSerie As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCompraPorProveedorSerie(strEmpresa, intIdEstablecimiento, intIdProveedor, strSerie)
    End Function


#Region "APORTES"
    Public Function SaveAporteExistencia(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveAporteExistencia(objDocumento, objTotalesAlmacen)
    End Function

    Public Function GetListarAportesPorPeriodo(strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAportesPorPeriodo(strPeriodo)
    End Function

    Public Sub UpdateAporteExistencia(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateAporteExistencia(objDocumento, listaTotales, objDeleteTotales)
    End Sub
#End Region

    Public Function SaveCompraNotaCredito(objDocumento As documento, nListaTotalesAlmacen As List(Of totalesAlmacen), nDocumentoNota As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraNotaCredito(objDocumento, nListaTotalesAlmacen, nDocumentoNota)
    End Function

    Public Function SaveCompraNotaCredito2(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraNotaCredito2(objDocumento, nDocumentoCaja, nDocumentoSaldoVenta)
    End Function

    Public Function SaveCompraNotaDebito(objDocumento As documento, nListaTotalesAlmacen As List(Of totalesAlmacen), nDocumentoNota As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraNotaDebito(objDocumento, nListaTotalesAlmacen, nDocumentoNota)
    End Function

    Public Function GetListarComprasPorProveedor(strIdEmpresa As String, intIdEstable As Integer, intIdProveedor As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorProveedor(strIdEmpresa, intIdEstable, intIdProveedor)
    End Function

    Public Sub ConfirmarNotaDeCompra(documentoNota As documento, compra As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmarNotaDeCompra(documentoNota, compra)
    End Sub

    Public Function UbicarDocumentoCompra(intIdDocumento As Integer) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoCompra(intIdDocumento)
    End Function

    Public Function SaveDocumentoCompra(nDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), Optional nDocumentoTributo As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveDocumentoCompra(nDocumento, objTotalesAlmacen, nDocumentoTributo)
    End Function

#Region "COMPRA DIRECTA SIN RECEPCION"

    Public Function SaveCompraDirectaSinRecepcion(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objDocumentoCaja As documento, cajaUsuario As cajaUsuario, Optional nDocumentoTributo As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraDirectaSinRecepcion(objDocumento, objTotalesAlmacen, objDocumentoCaja, cajaUsuario, nDocumentoTributo)
    End Function

    Function UpdateCompraDirectaSinRecepcion(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen),
                                      objDocumentoCaja As documento,
                                      nCajaUsuarioMontos As cajaUsuario, nCajaUsuarioEliminar As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateCompraDirectaSinRecepcion(objDocumento, listaTotales, objDeleteTotales, objDocumentoCaja, nCajaUsuarioMontos, nCajaUsuarioEliminar)
    End Function
#End Region

    Public Function SaveDocumentoCompraPagada(nDocumento As documento, nDocCaja As documento, nListaTotal As List(Of totalesAlmacen),
                                              cajaUsuario As cajaUsuario, objListaPrecio As List(Of listadoPrecios), Optional nDocumentoTributo As documento = Nothing) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCompraPagada(nDocumento, nDocCaja, nListaTotal, cajaUsuario, objListaPrecio, nDocumentoTributo)
    End Function

    Public Function SaveOtrasEntradas(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen),
                                       nListaOrigenAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveOtrasEntradas(objDocumento, objTotalesAlmacen, nListaOrigenAlmacen)
    End Function

    Public Sub GrabarTransferenciaAlmacenes(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarTransferenciaAlmacenes(objDocumento)
    End Sub

    Public Function SaveOtrasEntradasDefault(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveOtrasEntradasDefault(objDocumento, objTotalesAlmacen)
    End Function

    Public Sub UpdateDocumentoCompra(nDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen),
                                     Optional nDocumentoTributo As Business.Entity.documento = Nothing)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateDocumentoCompra(nDocumento, listaTotales, objDeleteTotales, nDocumentoTributo)
    End Sub

    Public Sub UpdateDocumentoCompraPagada(nDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento,
                                           nCajaUsuarioMontos As cajaUsuario, nCajaUsuarioEliminar As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateDocumentoCompraPagada(nDocumento, listaTotales, objDeleteTotales, objDocumentoCaja, nCajaUsuarioMontos, nCajaUsuarioEliminar)
    End Sub

    Public Sub UpdateOtrasEntradas(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateOtrasEntradas(objDocumento, listaTotales, objDeleteTotales)
    End Sub

    Public Function GetListarComprasPorPeriodo(intIdProyecto As Integer, strPeriodo As String, strTipoCompra As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodo(intIdProyecto, strPeriodo, strTipoCompra)
    End Function

    Public Function GetListarComprasPorPeriodoGeneral(intIdProyecto As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoGeneral(intIdProyecto, strPeriodo)
    End Function

    Public Function GetListarComprasPorPeriodoGeneral_CONT(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoGeneral_CONT(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarComprasPorPeriodoGeneral_CONT_CREDITO(intIdEstablecimiento As Integer, strPeriodo As String, Optional strIdCajaUsuario As String = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoGeneral_CONT_CREDITO(intIdEstablecimiento, strPeriodo, strIdCajaUsuario)
    End Function



    Public Function GetListarComprasPorPeriodoGeneralTransferencia(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoGeneralTransferencia(intIdEstablecimiento, strPeriodo, UsuarioCaja)
    End Function

    Public Function GetListarNotasPorIdCompraPadre(intIDocumentoPadre As Integer, strTipoNota As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarNotasPorIdCompraPadre(intIDocumentoPadre, strTipoNota)
    End Function

    Public Function GetListarComprasPorPeriodoCambioGeneral(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoCambioGeneral(intIdEstablecimiento, strPeriodo, UsuarioCaja)
    End Function

    Public Function ValidarEstadoManipulacion(intIdDocumentoCompra As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ValidarEstadoManipulacion(intIdDocumentoCompra)
    End Function

    Public Function GetListarPorPeriodoEntradas(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strTipoCompra As String, strTipoConsulta As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarPorPeriodoEntradas(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoCompra, strTipoConsulta)
    End Function

    Public Function GetListarPorPeriodoEntradasTransferencia(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strTipoCompra As String, strTipoConsulta As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarPorPeriodoEntradasTransferencia(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoCompra, strTipoConsulta)
    End Function

    Public Function GetListarMvimientosAlmacenPorDia(intIdEmpresa As String, intIdEstablecimiento As Integer, strTipoCompra As String, tipoConsulta As String, Optional fecha As DateTime = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarMvimientosAlmacenPorDia(intIdEmpresa, intIdEstablecimiento, strTipoCompra, tipoConsulta, fecha)
    End Function

    Public Function GetListarAportesPorMes(intIdEstablecimiento As Integer, ByVal strPeriodo As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAportesPorMes(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetListarAportesPorDia(intIdEstablecimiento As Integer) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAportesPorDia(intIdEstablecimiento)
    End Function

    Public Function GetListarAportesPorRango(ByVal desde As Date, ByVal hasta As Date) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAportesPorRango(desde, hasta)
    End Function

    Public Function UbicarCompraPorSerieNro(strEmpresa As String, intIdEstablecimiento As Integer, strSerie As String, strNumero As String, strRuc As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCompraPorSerieNro(strEmpresa, intIdEstablecimiento, strSerie, strNumero, strRuc)
    End Function

    Public Function UbicarNCreditoPorSerieNro(strEmpresa As String, intIdEstablecimiento As Integer, strSerie As String, strNumero As String, strRuc As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarNCreditoPorSerieNro(strEmpresa, intIdEstablecimiento, strSerie, strNumero, strRuc)
    End Function



    Public Function GetListarComprasPorRango_CONT(ByVal desde As Date, ByVal hasta As Date) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorRango_CONT(desde, hasta)
    End Function

    Public Function GetListarComprasPorMes_CONT(ByVal año As Integer, ByVal mes As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorMes_CONT(año, mes)
    End Function

    Public Function GrabarOrdenesServicio(objDocumento As documento, objOtroDoc As documentoOtrosDatos) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarOrdenesServicio(objDocumento, objOtroDoc)
    End Function

    Public Function GetListarOrdenCompraNoAprobadoSL(intIdEmpresa As String, ByVal intidEstablecimiento As Integer, ByVal EstadoOrden As String, ByVal strTipoSituacion As String) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarOrdenCompraNoAprobadoSL(intIdEmpresa, intidEstablecimiento, EstadoOrden, strTipoSituacion)
    End Function

    Public Function GetListarComprasPorPeriodoGeneralTransferenciaSC(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarComprasPorPeriodoGeneralTransferenciaSC(intIdEstablecimiento, strPeriodo, UsuarioCaja)
    End Function

    Public Function GetListarTransferenciaRecepcionInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarTransferenciaRecepcionInfGeneral(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function

    Public Function GetListaSumatoriaCompras(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As documentocompra
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaSumatoriaCompras(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio)
    End Function

End Class
