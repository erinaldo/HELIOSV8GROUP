Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports Helios.Cont.Business.Entity
Imports JNetFx.Framework.Data.WCFService
Imports System.ServiceModel.Web

<ServiceContract()>
Public Interface IContService
    Inherits IServiceBase

#Region "DEPURADO"


#Region "COMPRAS"
    <OperationContract()>
    Function GetListarComprasPorDia_CONT(documentocompraBE As documentocompra) As List(Of documentocompra)


    <OperationContract()>
    Function GetListarComprasPorDia_CONT_CONTADO(documentocompraBE As documentocompra, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)


#End Region

#Region "FINANZAS"
    <OperationContract()>
    Function ObtenerEstadosFinancierosPorEstablecimiento(estadoFinancieroBE As estadosFinancieros) As List(Of estadosFinancieros)
#End Region

#End Region

    <OperationContract()>
    Function GetListarComprasPorDia_CONT_CREDITO(intIdEstablecimiento As Integer, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)



#Region "ORGANIGRAMA"
    <OperationContract()>
    Function GetObtenerOrganizacion(strEmpresa As String) As List(Of organizacion)

    <OperationContract()>
    Function SaveOrganizacion(ByVal OrganizacionBE As organizacion) As organizacion

    <OperationContract()>
    Function GetObtenerParcialOrgani(strBE As organizacion) As List(Of organizacion)

    <OperationContract()>
    Sub ListOrgani(ByVal OrganizacionBE As List(Of organizacion))
#End Region

#Region "CENTRO DE COSTOS"
    <OperationContract()>
    Function GetObtenerEstablecimiento(strEmpresa As String) As List(Of centrocosto)

    <OperationContract()>
    Function GetObtenerEstablecimiento2(strEmpresa As String) As List(Of centrocosto)

    <OperationContract()>
    Function GetObtenerUnidadNegocio(IsEstablecimiento As Integer) As List(Of centrocosto)

    <OperationContract()>
    Function InsertListaEstablecimiento(estableBE As centrocosto) As List(Of centrocosto)

    <OperationContract()>
    Function InsertListaEstablecimientoApoyo(estableBE As centrocosto) As List(Of centrocosto)
#End Region

#Region "JERARQUIA"
    <OperationContract()>
    Sub SaveJerarquia(ByVal JerarBe As List(Of jerarquia))

    <OperationContract()>
    Function GetObtenerJerar(Idorgani As Integer) As List(Of jerarquia)

#End Region

    <OperationContract()>
    Function GetProductsCodeUnidadComercialAlmacen(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GetProductsCodeUnidadComercial(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GetExisteCodeUnidadComercial(be As detalleitem_equivalencias) As Boolean

    <OperationContract()>
    Sub ConfirmarEntregaDeDinero(idCierre As Integer, be As cajaUsuario, bl As List(Of estadosFinancierosConfiguracionPagos), userTransc As documentoCaja)

    <OperationContract()>
    Sub ConfirmacionDineroBancario(be As List(Of documentoCaja))



    <OperationContract()>
    Function ListBoxOpen(be As cajaUsuario) As List(Of cajaUsuario)

    <OperationContract()>
    Function ListBoxClosedPending(be As cajaUsuario) As List(Of cajaUsuario)

    <OperationContract()>
    Function ListBoxClosedPendingCount(be As cajaUsuario) As Integer


    <OperationContract()>
    Function ListPendingForUserWithImport(be As cajaUsuario) As List(Of cajaUsuario)


    <OperationContract()>
    Function ListBoxClosedPendingUser(be As cajaUsuario) As Integer

    <OperationContract()>
    Sub EliminatGuia(be As documento)

    <OperationContract()>
    Function GetGuiaRemisionListSelDate(be As documentoGuia) As List(Of documentoGuia)

    <OperationContract()>
    Function GetVentasXDistribuirSelDate(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetDetalleVentaGuiaSelventa(be As documentoventaAbarrotesDet) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetVentasXDistribuirSelCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub GrabarListaDeItemTipo(lista As List(Of item))

    <OperationContract()>
    Sub GrabarListaTallaColor(be As List(Of tabladetalle))

    <OperationContract()>
    Function GetListarTodasVentasProductosTipoDoc(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Sub GuardarcaracteristicaItem(be As List(Of caracteristicaItem))

    <OperationContract()>
    Function listaModelos(be As caracteristicaItem) As List(Of caracteristicaItem)

    <OperationContract()>
    Function listaCamposModelo(be As caracteristicaItem) As List(Of caracteristicaItem)

    <OperationContract()>
    Function InsertCabezera(be As caracteristicaItem) As caracteristicaItem

    <OperationContract()>
    Function GetLotesExistentesDetalle(intIdAlmacen As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListaTablaDetalleTipos(strEstado As String) As List(Of tabladetalle)

    <OperationContract()>
    Function GetListaCategoriasItem(be As item) As List(Of item)

    <OperationContract()>
    Function ListaTotalItem(itemBE As item) As List(Of item)

    <OperationContract()>
    Function GetProductosWithInventarioParam(be As detalleitems, opcion As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetProductosWithInventarioCodigos(be As detalleitems, opcion As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetProductosWithEquivalenciasParam(be As detalleitems, opcion As String) As List(Of detalleitems)

    <OperationContract()>
    Sub GuardarLoteDetalle(be As recursoCostoLote, lista As List(Of LoteDetalle))

    <OperationContract()>
    Function GetProductosLoteDetalle(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Sub ConfirmarTransferencia(be As documento)

    <OperationContract()>
    Function GetTransferenciaEnTransitoCount(be As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function GetTransferenciaEnTransito(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub EditarImageUrlProducto(item As detalleitems)

    <OperationContract()>
    Function GetInventarioSelCodigo(be As totalesAlmacenOthers) As List(Of totalesAlmacenOthers)

    <OperationContract()>
    Sub RegistrarItems(be As recursoCostoLote)

    <OperationContract()>
    Function GetPlantillaTallaSelcategory(be As talla) As List(Of talla)

    <OperationContract()>
    Function GetLotesSelVerificacion(be As recursoCostoLote) As List(Of recursoCostoLote)

    <OperationContract()>
    Function GetPlantillaTallas() As List(Of talla)

    <OperationContract()>
    Sub recursoCostoLoteTallaSave(be As recursoCostoLoteTalla)

    <OperationContract()>
    Sub recursoCostoLoteTallaSaveList(be As List(Of recursoCostoLoteTalla))

    <OperationContract()>
    Function GrabarTransferencia(be As documento) As documento

    <OperationContract()>
    Sub RegistrarPagosComnision(be As documento)

    <OperationContract()>
    Function registrocomision_autorizacionSelUsuario(be As registrocomision_usuarios_detalle) As List(Of registrocomision_autorizacion)

    <OperationContract()>
    Sub ChangeStatusComisionRegistro(be As registrocomision_usuarios_detalle)

    <OperationContract()>
    Sub registrocomision_autorizacionSaveList(Listado As List(Of registrocomision_autorizacion))

    <OperationContract()>
    Function registrocomision_usuarios_detalleJoinList(be As registrocomision_usuarios) As List(Of registrocomision_usuarios_detalle)

    <OperationContract()>
    Function detalleitemcatalogo_comisiondetalleSave(be As detalleitemcatalogo_comisiondetalle) As detalleitemcatalogo_comisiondetalle

    <OperationContract()>
    Function detalleitemcatalogo_comisionJoinList(be As detalleitemcatalogo_comision) As List(Of detalleitemcatalogo_comision)

    <OperationContract()>
    Function detalleitemcatalogo_comisionSave(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision

    <OperationContract()>
    Function detalleitemcatalogo_comisionSelCatalogo(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision

    <OperationContract()>
    Function detalleitemcatalogo_comisionSelUnidadComercial(be As detalleitemcatalogo_comision) As detalleitemcatalogo_comision

    <OperationContract()>
    Function detalleitemcatalogo_comisionList(be As detalleitemcatalogo_comision) As List(Of detalleitemcatalogo_comision)

    <OperationContract()>
    Function GetProductosWithEquivalenciasSelCategory(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Sub EditarPropertycategoryProducts(lista As List(Of detalleitems), category_id As Integer)

    <OperationContract()>
    Sub EditarValoresRentabilidadCompra(item As detalleitems)

    <OperationContract()>
    Sub EliminarItemOperation(inventario As InventarioMovimiento)

    <OperationContract()>
    Function GetUbicar_InventarioMovimiento(idDocumento As Integer) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetMovimientosLote(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetTransferenciasPeriodo(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GrabarInventarioEquivalencia(be As documento) As documento

    <OperationContract()>
    Function GrabarInventarioEquivalenciaTranferencia(be As documento) As documento

    <OperationContract()>
    Function GetProductosWithInventarioAlmacen(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GetInventarioAcumulado(idEMpresa As String, idEstablecimiento As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function ConsultaLotesDisponiblesAdmin(i As documentoventaAbarrotesDet) As List(Of recursoCostoLote)

    <OperationContract()>
    Function ConsultaStockItemV2(i As documentoventaAbarrotesDet) As List(Of usp_GetValidacionLotes_Result)

    <OperationContract()>
    Function ListaCpePendientesDeEnvio(fecha As DateTime, idEmpresa As String) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function ListaCpePendientes(fecha As DateTime, idEmpresa As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function AlertaEnvioPSE(Empresa As String) As documentoventaAbarrotes

    <OperationContract()>
    Function DocumentosAnuladosPendientes(fecha As DateTime, ruc As String) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function AnuladosPendientesCPE(fecha As DateTime, ruc As String) As List(Of documentoventaAbarrotes)



    <OperationContract()>
    Function GetKardexCaja(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function GetKardexCajaAdministracion(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function GetKardexCajaTramiteDoc(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function GetKardexCajaTramiteDocAdministracion(be As documentoCaja) As List(Of documentoCaja)


    <OperationContract()>
    Function GetOperacionesCaja(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function RankingVentas(opcion As String, be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function SaveConexo(be As detalleitems_conexo) As detalleitems_conexo

    <OperationContract()>
    Function BeneficioSave(be As detalleitemequivalencia_beneficio) As detalleitemequivalencia_beneficio

    <OperationContract()>
    Function AtributoEntidadSave(be As entidadAtributos) As entidadAtributos

    <OperationContract()>
    Function GetListarCuotasDocumentoPagos(iddoc As Integer) As List(Of Cronograma)

    <OperationContract()>
    Function GetCuentaCobrarSelCliente(strPeriodo As DateTime, StrMoneda As String, intIdCliente As Integer, terminos As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetResumenCuentasXCobrarTerminos(strEmpresa As String, intIdEstablecimiento As Integer, FechaConsulta As DateTime, StrMoneda As String, estadocobro As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetProformaCode(be As documento) As documentoventaAbarrotes

    <OperationContract()>
    Function BuscarNotasBoletasPeriodo(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetMovimientosFormaPagoCajeroDetalle(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosFormaPagoCajeroDetalleAdmi(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosCajaCajeroDetalle(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosCajaCajeroDetalleAdmi(be As cajaUsuario) As List(Of documentoCaja)


    <OperationContract()>
    Function GetMovimientosCajaComprobanteVentas(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosCajaComprobanteVentasAdmi(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosFormaPagoCajero(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosFormaPagoCajeroMoneda(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosFormaPagoCajeroMonedaAdmi(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetProductsBarCode(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GetProductsBarCodeAlmacen(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GetProductsCodigoInterno(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GetProductsCodigoInternoAlmacen(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Sub EditarDocumentoVenta(be As documento)

    <OperationContract()>
    Function ConteoNotasVenta(idDoc As Integer) As Integer

    <OperationContract()>
    Function NotasActivas(idDoc As Integer) As Integer


    <OperationContract()>
    Function GetComprasCriterio(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function ObtenerSaldoReclamacion(idanticipo As Integer) As documentoAnticipo

    <OperationContract()>
    Function GrabarReclamacionCompromiso(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetReclamacionesXClientes(parametro As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetCuentasPagarReclamacionesClientes(parametro As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetReclamacionesStatusCompras(be As documentocompra) As List(Of documentoAnticipo)

    <OperationContract()>
    Sub CambiarEstadoRecCompra(be As documentocompra)

    <OperationContract()>
    Function GetReclamacionesStatusVenta(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GrabarReclamacionCompromisoCobro(objDocumento As documento) As Integer

    <OperationContract()>
    Function ObtenerSaldoReclamacionCobro(idanticipo As Integer) As documentoAnticipo

    <OperationContract()>
    Function GetCuentasCobrarReclamacionesSoloProveedor(parametro As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetCuentasCobrarReclamacionesProveedor(parametro As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetCompromisoXDocumento(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Function ObtenerSaldoAnticipoV2Compra(idanticipo As Integer) As documentoAnticipo


    <OperationContract()>
    Function GetPaySaldoCaja(Be As estadosFinancierosConfiguracionPagos) As estadosFinancierosConfiguracionPagos

    <OperationContract()>
    Function GetAnticiposOtorgadosStatusAll(be As documentocompra) As List(Of documentoAnticipo)

    <OperationContract()>
    Function DocumentoAfectadoNC(be As documentoventaAbarrotes) As documentoventaAbarrotes

    <OperationContract()>
    Function GetAnticipoRecibidosStatusAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Sub CambiarEstadoNotaCreditoAnticipoCompra(be As documentocompra)

    <OperationContract()>
    Function GrabarCompraDocumentoGeneral(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetANTReclamacionesStatusCompra(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetANTReclamacionesPeriodoCompra(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function DocumentoCompraAfectadoNC(be As documentocompra) As documentocompra

    <OperationContract()>
    Function SaveNotaCreditoCompraFE(objDocumento As documento,
                                         nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer

    <OperationContract()>
    Sub PagoCompensacionVentas(objDocumento As documento)

    <OperationContract()>
    Function HistorialDeCobranza(iNtPadre As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub GrabarDocumentoCajaDevolucionAntOtor(be As documento)

    <OperationContract()>
    Function GetDevolucionAntSeguimientoCompra(be As documentocompra) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetDevolucionesByDocumentoNotaCompra(be As documentocompra) As List(Of documentoAnticipo)

    <OperationContract()>
    Sub GrabarDocumentoCajaDevolucionCobro(be As documento)

    <OperationContract()>
    Function GetDevolucionVentaSeguimiento(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetANTReclamacionesXDocumentoCompra(be As documentocompra) As documentoAnticipo

    <OperationContract()>
    Sub editarTrasnferenciaItem(inventario As InventarioMovimiento)

    <OperationContract()>
    Function GetDevolucionCompraSeguimiento(be As documentocompra) As List(Of documentoAnticipo)

    <OperationContract()>
    Sub PagoCompensacionCompras(objDocumento As documento)

    <OperationContract()>
    Function HistorialDePagos(iNtPadre As Integer) As List(Of documentocompra)

    <OperationContract()>
    Function GetVentasCriterio(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function CajaUsuarioSelPeriodo(be As cajaUsuario) As List(Of cajaUsuario)


    <OperationContract()>
    Function CajaUsuarioPeriodoSinRecocimiento(be As cajaUsuario) As List(Of cajaUsuario)

    <OperationContract()>
    Function GetMovimientosCajaCajeroUnidadNegocioCajeros(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosCajaFullCajeros(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosCajaFullCajerosAdmi(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function ConfiguracionTieneCajasActivas(idConfiguracion As Integer) As Boolean

    <OperationContract()>
    Sub CerrarCajasActivas(be As List(Of cajaUsuario))

    <OperationContract()>
    Sub CerrarCajasActivasPC(be As List(Of cajaUsuario))


    <OperationContract()>
    Function FacturasAnuPendientesEnv(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function BoletasAnuPendEnvio(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub UpdateAnulacionEnviada(objDocumento As Integer, idNum As Integer, nroTicket As String)

    <OperationContract()>
    Function GenerarNumeroXTipo(intIdEstablecimiento As Integer, strcodigoNumeracion As String, strTipo As String) As Integer

    <OperationContract()>
    Function GetInventarioInicial(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetProductosWithEquivalenciasEstablecimiento(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GrabarAporteGeneral(be As documento) As documento

    <OperationContract()>
    Function GetListarTodasCompras(be As documentocompra, tipoConsulta As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetCompraID(be As documento) As documentocompra

    <OperationContract()>
    Function GetProductosWithInventario(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GetProductosWithInventarioTipoAlmacen(be As detalleitems) As List(Of detalleitems)



    <OperationContract()>
    Function CatalogoPrecioSave(be As detalleitemequivalencia_catalogos) As detalleitemequivalencia_catalogos

    <OperationContract()>
    Function GetListarTodasVentasProductosAcumulado(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Sub CatalogoPredeterminado(obj As detalleitemequivalencia_catalogos)

    <OperationContract()>
    Function GetListarTodasVentasProductos(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetListarTodasVentas(be As documentoventaAbarrotes, tipoConsulta As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetMovimientosCajaCajeroUnidadNegocio(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function UbicarCajeroIDUsuarioActiva(caja As cajaUsuario) As cajaUsuario

    <OperationContract()>
    Function UbicarCajeroIDUsuarioActivaPC(caja As cajaUsuario) As cajaUsuario


    <OperationContract()>
    Function GetListarNotaDeVentasDia(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasPeriodoXTipoAnuladosDia(intIdEstablec As Integer, fechaLab As Date, tipo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetMovimientosCajaCajero(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosCajaCajeroTipoMoneda(be As cajaUsuario) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientosEfectivoCajero(be As cajaUsuario) As List(Of documentoCaja)


    <OperationContract()>
    Function GetMovimientosCajaCajeroTipoMonedaAdmi(be As cajaUsuario) As List(Of documentoCaja)


    <OperationContract()>
    Function GetMovimientosBancariosPendientes(be As documentoCaja) As List(Of documentoCaja)


    <OperationContract()>
    Function GetMovimientosBancariosConfirmados(be As documentoCaja) As List(Of documentoCaja)


    <OperationContract()>
    Function GetProductosWithEquivalenciasV2(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function DetalleItemPrecioSave(obj As detalleitem_precios) As detalleitem_precios

    <OperationContract()>
    Function PrecioEquivalenciaSave(be As detalleitemequivalencia_precios) As detalleitemequivalencia_precios

    <OperationContract()>
    Sub ChangeEstatusEquivalencia(obj As detalleitem_equivalencias)

    <OperationContract()>
    Sub PrecioSave(be As configuracionPrecioProducto)

    <OperationContract()>
    Function EquivalenciaSelID(be As detalleitem_equivalencias) As detalleitem_equivalencias

    <OperationContract()>
    Function SaveEquivalencia(be As detalleitem_equivalencias) As detalleitem_equivalencias

    <OperationContract()>
    Function GrabarVentaEquivalencia(be As documento) As documento

    <OperationContract()>
    Function GetProductosEntransitoEquivalencia(be As documentocompra) As List(Of inventarioTransito)

    <OperationContract()>
    Function GrabarCompraEquivalencia(be As documento) As documento

    <OperationContract()>
    Function GrabarCompraVinculada(be As documento) As documento

    <OperationContract()>
    Function GetProductosWithEquivalencias(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Sub updatePredeterminado(datoGeneralBE As datosGenerales)

    <OperationContract()>
    Function BuscarConfiguracionCreada(idemp As String, idestab As String, idconf As Integer) As Integer

    <OperationContract()>
    Function GetVentasFiltroComprobanteCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function UpdatePedidoProforma(be As documento) As Integer

    <OperationContract()>
    Function Test() As String

    <OperationContract()>
    Function ObtenerCajaUsuarioDia(be As cajaUsuario) As List(Of cajaUsuario)

    <OperationContract()>
    Function GetCobroPorCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetCuentasPorpagarProveedorPendientes(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetVentasFiltroComprobante(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetVentaID(be As documento) As documentoventaAbarrotes

    <OperationContract()>
    Function GetVentaIDGuia(be As documento) As documentoGuia

    <OperationContract()>
    Function GetREcuperarImpresion(be As documento) As documentoGuia


    <OperationContract()>
    Sub EliminarPagoDevolucion(be As documento)

    <OperationContract()>
    Function GetMovimientosKardexByExistencia(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)

    <OperationContract()>
    Sub ConfirmarPagoTarjeta(iddoc As Integer, fecha As DateTime)

    <OperationContract()>
    Function GetPagosTarjetaxConfirmar(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function SaveNotaCreditoFE(objDocumento As documento,
                                         nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer

    <OperationContract()>
    Function GetDevolucionAntSeguimiento(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Sub GrabarDocumentoCajaDevolucionAnt(be As documento)

    <OperationContract()>
    Function GetDevolucionesByDocumentoNota(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Sub RecepcionInventario(doc As documento)

    <OperationContract()>
    Function GetANTReclamacionesStatusCount(be As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Sub CambiarEstadoNotaCreditoAnticipo(be As documentoventaAbarrotes)

    <OperationContract()>
    Function GetStatusNotaCreditoCount(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetMovimientosByDocumento(be As documentoAnticipoConciliacion) As List(Of documentoAnticipoConciliacion)

    <OperationContract()>
    Function GetANTReclamacionesStatusAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetMovimientosByCajaUsuario(be As documentoAnticipoConciliacion) As List(Of documentoAnticipoConciliacion)

    <OperationContract()>
    Function GetANTReclamacionesXDocumento(be As documentoventaAbarrotes) As documentoAnticipo

    <OperationContract()>
    Function GetANTReclamacionesPersonaAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetANTReclamacionesPersona(be As documentoventaAbarrotes) As List(Of documentoAnticipo)

    <OperationContract()>
    Sub GetChangeEstadoAnticipo(be As documentoAnticipo)

    <OperationContract()>
    Function GetANTReclamacionesStatus(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetANTReclamacionesPeriodo(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function ObtenerSaldoAnticipoV2(idanticipo As Integer) As documentoAnticipo

    <OperationContract()>
    Function GrabarVentaDocumentoGeneral(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetStatusAprobacionAnticiposList(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetStatusAprobacionAnticipos(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function ObtenerSaldoAnticipoPersona(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetAnticiposPeriodo(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetEscaneadasAnticiposList(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function SaveAnticipo(be As documento) As documentoAnticipo

    <OperationContract()>
    Function GetMovimientosByFormaPago(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)

    <OperationContract()>
    Function ListaResumenXEntidadV2(listaidPersona As List(Of Integer), fechaInicio As DateTime, fechaFin As DateTime, strEmpresa As String, idEstablec As Integer, ListaCuentasFinancieras As List(Of Integer)) As documentoCaja

    <OperationContract()>
    Function GetListar_activosFijosEmpresa(be As activosFijos) As List(Of activosFijos)

    <OperationContract()>
    Function InsertActivoFijo(ByVal activosFijosBE As activosFijos) As Integer

    <OperationContract()>
    Function BeneficioSelXID(be As beneficio) As beneficio

    <OperationContract()>
    Sub RegisterClientBeneficeCupon(be As beneficio)

    <OperationContract()>
    Function BeneficioListaClienteProductionCupones(be As beneficio) As List(Of beneficio)

    <OperationContract()>
    Function BeneficioSelID(be As beneficioProduccionConsumo) As beneficioProduccionConsumo

    <OperationContract()>
    Function GetBeneficiosSelTipo(be As beneficioProduccionConsumo) As List(Of beneficioProduccionConsumo)

    <OperationContract()>
    Function GetBusquedaAvanzadaProductosSinAlmacen(be As detalleitems, caso As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetArticulosSinAlmacenSearchCodigo(empresa As String, search As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetListDetalleSel(be As beneficio) As List(Of beneficioDetalle)

    <OperationContract()>
    Function GetEntidadAfiliacionConteo(be As EntidadAfiliacionBeneficio) As List(Of EntidadAfiliacionBeneficio)

    <OperationContract()>
    Sub ChangeStatusAfiliado(be As EntidadAfiliacionBeneficio)

    <OperationContract()>
    Function CatalogoDeClientesBeneficio(be As entidad) As List(Of entidad)

    <OperationContract()>
    Function BeneficioListaClienteProductions(be As beneficio) As List(Of beneficio)

    <OperationContract()>
    Function BeneficioSelClienteProductions(be As beneficio) As beneficio

    <OperationContract()>
    Function EntidadAfiliacionBeneficioStatus(be As EntidadAfiliacionBeneficio) As List(Of EntidadAfiliacionBeneficio)

    <OperationContract()>
    Sub RegisterClientBenefice(be As beneficio)

    <OperationContract()>
    Sub EntidadAfiliacionBeneficioSave(be As EntidadAfiliacionBeneficio)

    <OperationContract()>
    Sub PagoDocVentas(objDocumento As documento)

    <OperationContract()>
    Function GetCobrosByDocumento(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetVentaPorID(iDocuemnto As Integer) As documentoventaAbarrotes

    <OperationContract()>
    Function GetComprasPorCobrarOpcion(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetVentaxCobrarVenc(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetAcumuladoCuentasCobrarByAnio(be As documentoventaAbarrotes) As documentoventaAbarrotes

    <OperationContract()>
    Function GetResumenAnualCuentasCobrar(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetResumenAnualCuentasVenc(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetAcumuladoCuentasPagarByAnio(be As documentocompra) As documentocompra

    <OperationContract()>
    Sub ConfirmarNotaDeCompra(documentoNota As documento, compra As documento)

    <OperationContract()>
    Function GetEscaneadasConteoNotaCompra(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetStatusAprobacionListNotaCompra(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetNotaCompraRecientes(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetEscaneadasNotaComprasseriodo(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetEscaneadasCRapidasListNC(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Sub EliminarImpresion(datoGeneralBE As datosGenerales)

    <OperationContract()>
    Sub PagoDocCompras(objDocumento As documento)

    <OperationContract()>
    Function GetComprasPorPagarOpcion(be As documentocompra, opcion As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetPagosByDocumento(be As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetResumenAnualCuentasPagar(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function ListaGuiasTransferenciasXEntidadV2(be As documentocompra, tipoPerson As String) As List(Of documentoGuia)

    <OperationContract()>
    Function GetAlertaTransferenciasConteo(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Sub EnvioProductosEnTransitoRapido(listaEnvios As List(Of inventarioTransito))

    <OperationContract()>
    Sub GrabarPedidoLogistica(objDocumento As documento)

    <OperationContract()>
    Function GetResumenXFormaPago(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Sub GrabarConfiguracionList(lista As List(Of estadosFinancierosConfiguracionPagos))

    <OperationContract()>
    Function GetConfigurationPay(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)

    <OperationContract()>
    Function GetConfigurationPayCaja(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)


    <OperationContract()>
    Function GetConfigurationPayBancarios(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)



    <OperationContract()>
    Function GetEscaneadasCRapidasPeriodo(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetEscaneadasCRapidasList(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetEscaneadasCRapidas(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetCRapidaRecientes(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetContadorCRapidaRecientes(be As documentocompra) As Integer

    <OperationContract()>
    Sub RechazarCompraRapida(be As documento)

    <OperationContract()>
    Function GetStatusAprobacionList(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetStatusAprobacion(be As documentocompra) As List(Of documentocompra)


    <OperationContract()>
    Function ListarVentasTipoClientePeriodo(be As documentoventaAbarrotes, ListaTipo As List(Of String)) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetListarRegistroVentasXTipo(intIdEstablec As Integer, strPeriodo As String, ListaTipo As List(Of String)) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetBuscarComprobante(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function AlertaPSE(Empresa As String) As documentoventaAbarrotes

    <OperationContract()>
    Function BoletasPeriodo(fecha As DateTime, tipoDoc As String, ruc As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function NotasBoletasPeriodo(fecha As DateTime, tipoDoc As String, ruc As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function BoletasAnuladasPeriodo(fecha As DateTime, tipoDoc As String, ruc As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function FacturasAnuladasPeriodo(fecha As DateTime, tipoDoc As String, ruc As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetProductosSinAsignarPrecios(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GetDetalleItemsXEmpresaAll(empresa As String, estable As Integer, tipo As String) As List(Of detalleitems)

    <OperationContract()>
    Function UbicaEmpresaFull(datosgerales As datosGenerales) As List(Of datosGenerales)

    <OperationContract()>
    Function GetListarRegistroVentas(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarRegistroNotasVentas(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetDetalleLoteXproductoProf(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetArticulosSinAlmacenSearchText(empresa As String, search As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetArticulosSinAlmacen(empresa As String, opcion As Byte) As List(Of detalleitems)

    <OperationContract()>
    Function GetDetalleItemsXEmpresa(empresa As String, idEstable As Integer, tipo As String, search As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetVentasPorCriterio(be As documentoventaAbarrotes, criterio As String, valor As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetNotaVentasPorFecha(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetVentasPorFechaConteo(be As documentoventaAbarrotes, opcion As String) As List(Of String)

    <OperationContract()>
    Function GetInventoryProductoID(idProducto As Integer, almacen As Integer) As usp_GetProductInventoryID_Result

    <OperationContract()>
    Function GetVentasPorFecha(be As documentoventaAbarrotes, opcion As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetArticulosSytem(empresa As String, search As String) As List(Of detalleitems)

    <OperationContract()>
    Function GrabarSalidaInventario(objDocumento As documento) As Integer

    <OperationContract()>
    Sub ConfirmarListaRapida(lista As List(Of documento), compra As documento)

    <OperationContract()>
    Function GetProductsSistemaByEmpresa(be As detalleitems) As List(Of usp_GetProductsSistema_Result)

    <OperationContract()>
    Function GetPrecioPorProducto(idempresa As String, idProducto As Integer) As List(Of detalleitems)

    <OperationContract()>
    Function GetRentabilidadPorComprobante(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function TicketsXvalidarBajasFactura(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function SaveVentaNotaCredito2Electronica(objDocumento As documento,
                                         nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer

    <OperationContract()>
    Function OfertaSelCodigo(be As oferta) As oferta

    <OperationContract()>
    Function FacturasPendientesSunat(docVentaAbarrotes As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function FacturaBajasPendiente(docVentaAbarrotes As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function BoletasBaja(docVentaAbarrotes As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function BoletasBajaValidar(docVentaAbarrotes As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function FacturasBajasValidar(docVentaAbarrotes As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function BoletasPendientesEnvio(docVentaAbarrotes As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function ResumenBoletasPendiente(docVentaAbarrotes As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function NotasPendientesSunat(docVentaAbarrotes As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function TicketsXvalidar(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function TicketsXvalidarBajasBoletas(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function TicketsXvalidarNotasBoleta(docVentaAbarrotes As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetProductosBusquedaPersonalizada(be As detalleitems, caso As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetBusquedaAvanzadaProductos(be As detalleitems, caso As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Sub EliminarProductoSinInventario(be As detalleitems)


    <OperationContract()>
    Function GetListaItemsPorTipoPadre(be As item) As List(Of item)

    <OperationContract()>
    Function GetListaItemsPorTipo(be As item) As List(Of item)

    <OperationContract()>
    Function Grabar_VentaNotaSinInventario(objDocumento As documento) As Integer

    <OperationContract()>
    Function GrabarVentaSinIventario(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub SaveOferta(be As oferta)

    <OperationContract()>
    Function OfertaSel(be As oferta) As oferta

    <OperationContract()>
    Function OfertaSelAll(be As oferta) As List(Of oferta)

    <OperationContract()>
    Function GetInventarioParaVentaAcumuladoCodigo(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetInventarioParaVentaAcumuladoDolares(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function Grabar_VentaNotaSinLote(objDocumento As documento) As Integer

    <OperationContract()>
    Function BuscarFacturanoEnviadas(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub UpdateFacturasXEstado(doc As Integer, estado As String)

    <OperationContract()>
    Sub UpdateGuiaXEstado(doc As Integer, estado As String)



    <OperationContract()>
    Function BuscarBoletasAnuladas(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function BuscarBoletasXTicketSunatNotas(ticket As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub ValidarEnviosSunat(lista As List(Of documentoventaAbarrotes))

    <OperationContract()>
    Sub ListaReenvioSunatAnulados(lista As List(Of documentoventaAbarrotes), nroTicket As String)

    <OperationContract()>
    Function BuscarDocumentosAnuladosFechaTicket(tipodoc As String, ruc As String, ticket As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function BuscarFacturanoEnviadasPeriodo(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function BuscarBoletasXTicketSunat(ticket As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub ListaReenvioSunatResumen(lista As List(Of documentoventaAbarrotes), nroTicket As String)

    <OperationContract()>
    Function GetVentasStatusPreparacionAlmacen(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub PrepararEntregaVenta(documentoventaAbarrotes As documentoventaAbarrotes)

    <OperationContract()>
    Function NotasCreditoBoleta(fecha As DateTime, tipoDoc As String, IdEmpresa As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function BuscarNotasXDocumento(idDoc As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function BuscarDocumentosFecha(fecha As DateTime, tipodoc As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetUbicar_NotaXID(idDocumento As Integer) As documentoventaAbarrotes

    <OperationContract()>
    Sub UpdateEnvioSunat(doc As Integer)

    <OperationContract()>
    Sub ListaEnvioSunatAnulados(lista As List(Of documentoventaAbarrotes), nroTicket As String, idNum As Integer)

    <OperationContract()>
    Function BuscarDocumentosAnuladosFecha(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub ListaEnvioSunat(lista As List(Of documentoventaAbarrotes))

    <OperationContract()>
    Sub ListaEnvioSunatResumen(lista As List(Of documentoventaAbarrotes), idNum As Integer, nroTicket As String)

    <OperationContract()>
    Function Grabar_VentaEspecialSinLote(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function Grabar_VentaEspecialExistencia(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub CobrarVentaJiuni(be As documento)

    <OperationContract()>
    Sub CobrarVentaEspecial(be As documento)

    <OperationContract()>
    Function GetDocumentosCompraByTipo(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetDetalleLoteXproductoFullAlmacen(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function DocCajaXDocumentoVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)

    <OperationContract()>
    Function DocCajaXDocumentoVentasElectronicas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)

    <OperationContract()>
    Function DocCajaUnitXDocumento(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)

    <OperationContract()>
    Function DocCajaXItemVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function DocCajaXItemVentasElectronicas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function GetExistenciasByempresaNombreFull(idempresa As String, nombre As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetTipoExistenciasByEmpresaConPrecios(empresa As String, tipo As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetInventarioGeneral(be As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetAlmacenesDistribuidosParaEmision(secuenciaCompra As Integer, idCompra As Integer) As List(Of documentoguiaDetalle)

    <OperationContract()>
    Sub GrabarCompraAdicionalLoteExistente(be As documento)

    <OperationContract()>
    Function Grabar_VentaEspecial(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub GrabarNotaCompraDirecta(be As documento)

    <OperationContract()>
    Sub GetActualizarImpresion(be As documentoventaAbarrotes)

    <OperationContract()>
    Function GetUbicarPagosComprobante(idDocumento As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function GetPagoByComprobante(idDocumento As Integer) As List(Of documento)

    <OperationContract()>
    Function GenerarComprobanteVenta(objDocumento As documento) As Integer

    <OperationContract()>
    Function Grabar_VentaNota(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetDetalleLoteXproducto(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetInventarioParaVentaAcumulado(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetInventarioParaVentaAcumuladoForma2(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetInventarioParaVentaAcumuladoEspecial(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetProductsShopingOrOthers(objTotalBE As totalesAlmacen) As List(Of usp_GetProductsByEstable_Result)

    <OperationContract()>
    Sub AnularNotaVenta(documentoBE As documento)

    <OperationContract()>
    Function GetListarNotaDeVentasPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetMovimientosKardexByArticuloSNAT(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetMovimientosKardexByMesSustentado(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)

    <OperationContract()>
    Sub AnularNotaDeCompra(documentoBE As documento)

    <OperationContract()>
    Sub confirmarTrasnferenciaPedniente(compra As documentocompra)

    <OperationContract()>
    Function GetNotasDeComprasPorPeriodo(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function ListaGuiasTransferenciasXEntidad(be As documentocompra) As List(Of documentoGuia)

    <OperationContract()>
    Function GetListaTrasnferenciasPersonaXconfirmar(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Sub AnularSalidaInv(documentoBE As documento)

    <OperationContract()>
    Sub AnularEntradainv(documentoBE As documento)

    <OperationContract()>
    Function GetListaPersonasTrasnferenciasXconfirmar(be As documentocompra) As List(Of entidad)

    <OperationContract()>
    Sub AnularCompra(documentoBE As documento)

    <OperationContract()>
    Sub AnularOtrosPagos(be As documento)

    <OperationContract()>
    Sub GrabaritemExistenciaInicioExistente(nuevoarticulo As detalleitems, item As totalesAlmacen, inv As InventarioMovimiento)

    <OperationContract()>
    Function GetListaTablaDetalleTodo(intIdTabla As Integer) As List(Of tabladetalle)

    <OperationContract()>
    Function GetListAnios(be As cierreinventario) As List(Of cierreinventario)

    <OperationContract()>
    Function GetListMeses(be As cierreinventario) As List(Of cierreinventario)

    <OperationContract()>
    Function GetListPeriodos(be As cierreinventario) As List(Of cierreinventario)

    <OperationContract()>
    Sub CambiarStatusItem(be As tabladetalle)

    <OperationContract()>
    Function ObtenerMaxTabla(be As tabladetalle) As String

    <OperationContract()>
    Function GetAlertaIventarioSinStockConteo(be As totalesAlmacen) As Integer

    <OperationContract()>
    Function GetCuentasPorPagarStatusCount(be As documentocompra) As Integer

    <OperationContract()>
    Function GetListarPercepciones(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Sub actualizarPrecioCompra(be As detalleitems)

    <OperationContract()>
    Function GrabarPercepcion(objDocumento As documento, nDocumentoNota As documento) As Integer

    <OperationContract()>
    Sub CambiarEstadoItem(be As detalleitems)

    <OperationContract()>
    Function ListaDeReconocimientosxEntregable(idEntregable As Integer) As List(Of documentoLibroDiario)

    <OperationContract()>
    Function GetComprasPorAprobarPago(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Sub CobrarVentaRapida(be As documento)

    <OperationContract()>
    Sub CobrarVentaRapidaEspecal(be As documento)

    <OperationContract()>
    Sub GrabarFacReconocimiento(be As documento)

    <OperationContract()>
    Function GetListarRetenciones(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function SaveRetencion(objDocumento As documento) As Integer

    <OperationContract()>
    Function ListProductsConexos(be As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetUbicarArticuloLoteVenta(be As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetNumeracionCompra(be As documentocompra) As Integer

    <OperationContract()>
    Function Grabar_Venta(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetLoteByID(codigoLote As Integer) As recursoCostoLote

    <OperationContract()>
    Function UbicarAnticiposProveedor(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentoCaja)

    <OperationContract()>
    Function GetUbicar_documentoAnticipoPorID(intIdDocumento As Integer) As documentoCaja

    <OperationContract()>
    Sub CambiarEstadoAlmacen(almacen As almacen)

    <OperationContract()>
    Function SaveGroupCajaReconocimiento(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer

    <OperationContract()>
    Function GastosFinanzas(documentoCaja As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Sub EditarLote(recursoCostoLote As recursoCostoLote)

    <OperationContract()>
    Function ObtenerCuentasPorCobrarPorDetailsREC(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerAnticipoDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function GetItemsByDescripcion(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function GeDetalleCompraItemLote(codigoLote As Integer) As documentocompradetalle

    <OperationContract()>
    Sub EnvioDeServiciosAProduccion(be As List(Of documentocompradetalle))

    <OperationContract()>
    Function GetListarVentasPorAnio2(empresa As String, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function getListaServiosXVenta(be As InventarioMovimiento, fechaini As DateTime, fechafin As DateTime, tipo As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Sub StatusApruebaPagoFactura(be As documentocompra)

    <OperationContract()>
    Function GetRentabilidad(be As InventarioMovimiento, fechaini As DateTime, fechafin As DateTime, tipo As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetRentabilidadV2(be As InventarioMovimiento, fechaini As DateTime, fechafin As DateTime, tipo As String) As List(Of InventarioMovimiento)


    <OperationContract()>
    Function GetCajasActivasTotalXdia(be As documentoCaja) As cajaUsuario

    <OperationContract()>
    Function GetComprasDelDiaxOperacion(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Sub ProductosConexos(lista As List(Of totalesAlmacen))

    <OperationContract()>
    Function GetVentasDelDiaXTipoVenta(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetUbicarArticuloLote(be As totalesAlmacen) As totalesAlmacen

    <OperationContract()>
    Sub EliminarVenta(documentoBE As documento)

    <OperationContract()>
    Sub EliminarSalidaInv(documentoBE As documento)

    <OperationContract()>
    Sub EditarOtraSalida(objDocumento As documento)

    <OperationContract()>
    Sub EditarOtraEntrada(objDocumento As documento)

    <OperationContract()>
    Sub EliminarEntradainv(documentoBE As documento)

    <OperationContract()>
    Sub EliminarCompra(documentoBE As documento)

    <OperationContract()>
    Sub EditarCompra(documentoBE As documento)

    <OperationContract()>
    Sub GrabarNotaCompra(be As documento)

    <OperationContract()>
    Function GetProductosXvencerMes(empresa As String, anio As Integer, mes As Integer, TipoExistencia As String,
                                           intIdAlmacen As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetProductosXvencerMesFull(empresa As String, anio As Integer, mes As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetProductosXvencerMesCount(empresa As String, anio As Integer, mes As Integer) As Integer

    <OperationContract()>
    Function GetRecuperarAporteExistencia(be As documento) As documentoLibroDiario

    <OperationContract()>
    Function ListaRecursosGastoLibroEntregable(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function ListaDeReconocimientos() As List(Of documentoLibroDiario)

    <OperationContract()>
    Function GrabarReconocmientoIngreso(objDocumento As documento)

    <OperationContract()>
    Sub EnvioCostoGastoLibro(be As List(Of documentoLibroDiarioDetalle))

    <OperationContract()>
    Function HistorialCosteo(idEntregable As Integer) As List(Of documentoLibroDiario)

    <OperationContract()>
    Sub GrabarDocumentoProyecto(documento As documento, idEntregable As Integer, listaR As List(Of recursoCostoDetalle), estadoProy As String)

    <OperationContract()>
    Function ListarAsientosManualesSinCosteo(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Sub EditarV00(configBE As configuracionInicio)

    <OperationContract()>
    Sub GrabarClienteSoftPack(be As clientesSoftPack, empresaBE As empresa, listaCentoCosto As List(Of centrocosto))

    <OperationContract()>
    Function GeTipoCambioXfecha(idEmpresa As String, fecha As Date, intIdEstablecimiento As Integer) As tipoCambio

    <OperationContract()>
    Function GetEmpresasClientes(rucCliente As String) As List(Of clientesSoftPack)

    <OperationContract()>
    Function GetProductoClientesXID(ClienteID As String) As clientesSoftPack


    <OperationContract()>
    Function GetCuentasFinancierasEmpresaXtipoFecha(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipoFecha_Result)

    <OperationContract()>
    Function ListaRecursosCostoEntregable(compraBE As documentocompra, idEntregable As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function ListaRecursosCostoInventarioEntregables(compraBE As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetCobrosPendienteXcliente(idEntidad As Integer, anio As Integer) As List(Of usp_GetCuentasXcobrarXclienteAnual_Result)

    <OperationContract()>
    Function GetClientesXcobrar(anio As Integer, empresa As String) As List(Of usp_GetClientesXcobrar_Result)

    <OperationContract()>
    Function GetConsultaCuentasPorpagarFiltro(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Sub EditarArticuloLOTE(objInventario As totalesAlmacen)

    <OperationContract()>
    Sub EliminarAsigancionDeAsientoInventario(be As documentocompra)

    <OperationContract()>
    Sub ReingresarAsientoContable(objAsiento As asiento)

    <OperationContract()>
    Function ObtenerCanDisponibleProduct(bt As totalesAlmacen) As totalesAlmacen

    <OperationContract()>
    Function GetEmpresasXcliente(idclientespk As Integer) As List(Of empresa)

    <OperationContract()>
    Sub EditarActividadGym(be As actividadPersonal)

    <OperationContract()>
    Function GetUbicarActividadGYMDetalle(idActividad As Integer) As List(Of clasehorarios)

    <OperationContract()>
    Function LoadEstructuraLibroDiario(strEmpresa As String, strPeriodo As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function CuentasServicios(strEmpresa As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function CuentasCostoGastoSinModulo(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Sub GetDetraccionChangeStateByDocumento(be As documentocompra)

    <OperationContract()>
    Function TxtPleLibroDiario(periodo As String, idempresa As String) As List(Of usp_PleLibroDiario_Result)

    <OperationContract()>
    Sub GrabarActividadPersonalGym(be As actividadPersonal)

    <OperationContract()>
    Function GetMembresiasContratadasXSocio(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)

    <OperationContract()>
    Function GetActividadesEmpresa(be As actividadPersonal) As List(Of actividadPersonal)

    <OperationContract()>
    Function GetUbicarActividadGYM(idActividad As Integer) As actividadPersonal

    <OperationContract()>
    Function GetUbicaCierreResultado(strIdEmpresa As String, anioPeriodo As String, mesPeriodo As String) As List(Of cierreResultados)

    <OperationContract()>
    Function GetPagosPendienteXproveedor(idEntidad As Integer, anio As Integer) As List(Of usp_GetCuentasXpagarXproveedorAnual_Result)

    <OperationContract()>
    Function GetUbicaCierrePorPeriodo(strIdEmpresa As String, periodo As String) As cierreResultados

    <OperationContract()>
    Function GetProveedoresXpagar(anio As Integer, empresa As String) As List(Of usp_GetProveedoresXpagar_Result)

    <OperationContract()>
    Function GetMembresiasPorStatusMembresiaXfechaConteo(be As Entidadmembresia_Gym) As Integer

    <OperationContract()>
    Sub GetMembresiasVencidasDelDia(be As List(Of Entidadmembresia_Gym))

    <OperationContract()>
    Function GetMembresiasPorStatusMembresiaXfecha(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)

    <OperationContract()>
    Function GetMembresiaActivaXSocio(be As Entidadmembresia_Gym) As Entidadmembresia_Gym

    <OperationContract()>
    Function CuentaVentasNetasMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Sub actualizarEstadoTransitoItem(documentocompradetalle As documentocompradetalle)

    <OperationContract()>
    Function CuentaOtrosIngresoMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Function CuentaCostoVentaMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Function CuentaUtilidadOperativaMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Function GetRegistroMembresiasByEmpresa(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)

    <OperationContract()>
    Function CuentaVentasNetas2Mensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Sub EliminarPagoMembresia(ByVal documentoBE As documento)

    <OperationContract()>
    Sub EditarMovimientosContablesByAsiento(movimiento As movimiento)

    <OperationContract()>
    Function GrabarPagoMembresia(objDocumentoBE As documento) As Integer

    <OperationContract()>
    Sub EliminarPrecio(configuracionPrecioProducto As configuracionPrecioProducto)

    <OperationContract()>
    Function GetCuentasFinancierasEmpresaXtipo(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipo_Result)

    <OperationContract()>
    Function GetCuentasFinancierasEmpresaXtipoXidCaja(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraEmpresaXtipoXIdCaja_Result)


    <OperationContract()>
    Function GetSaldoCuentasFinancieraCajeroActivo(be As estadosFinancieros) As List(Of GetSaldoCuentasFinancieraCajeroActivo_Result)

    <OperationContract()>
    Function GetDocumentoCajaMembresiaByDocumento(iddocumento As Integer) As Entidadmembresia_Gym

    <OperationContract()>
    Function GetMembresiasByStatus(be As membresia_Gym) As List(Of membresia_Gym)

    <OperationContract()>
    Function GetMaximoMinimoFechaCongelamiento(be As membresia_congelamiento) As membresia_congelamiento

    <OperationContract()>
    Function ObtenerCajaOnlineMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As List(Of documentoCaja)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta41Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta423433Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta42Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta43Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta12Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Sub GetEliminarMembresia(be As Entidadmembresia_Gym)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta13Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Sub GetCambiarEstado(membresia_Gym As membresia_Gym)

    <OperationContract()>
    Function GetListaEstadoCuenta46Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta46Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoXCuentaPasivoMensual(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta132Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta122Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoXCuentaActivoMensual(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta123133Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta14Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta16Mensual(strEmpresa As String, intIdEstablecimiento As Integer, PeriodoCont As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta16Anual(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta16Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta1413Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta30al38Mensual(strEmpresa As String, intIdEstablecimiento As Integer, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta422Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta432Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoXCuentaActivoInversoMensual(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta11y18Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta40Mensual(strEmpresa As String, intIdEstablecimiento As Integer, tipo As String, FechaInicio As Date, FechaFin As Date) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function CuentaEntregaRendirMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Function CuentaAnticiposMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Sub GrabaritemExistenciaInicio(nuevoarticulo As detalleitems, item As totalesAlmacen, inv As InventarioMovimiento)

    <OperationContract()>
    Function GetListaInicioExistencia(fechaInicio As Date, idempresa As String, almacen As Integer) As List(Of InventarioMovimiento)

    <OperationContract()>
    Sub EliminarArticuloInicio(inv As InventarioMovimiento)

    <OperationContract()>
    Function CuentaCobroComercialMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Sub GetChangeStatusArticuloRange(listaInventario As List(Of totalesAlmacen))

    <OperationContract()>
    Function CuentaPagoLetrasMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Function CuentaPagoComercialRelMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Function CuentaPagoComercialMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As movimiento

    <OperationContract()>
    Function BalanceGeneralMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As List(Of movimiento)

    <OperationContract()>
    Sub EditarArticuloInicio(inv As InventarioMovimiento)

    <OperationContract()>
    Sub GrabarGrupoCongelamiento(be As List(Of membresia_congelamiento))

    <OperationContract()>
    Function GetSumaCongelamientoByPeriodo(be As membresia_congelamiento) As List(Of membresia_congelamiento)

    <OperationContract()>
    Sub EliminarCongelamiento(idcongelamiento As Integer)

    <OperationContract()>
    Sub GrabarCongelamiento(be As membresia_congelamiento)

    <OperationContract()>
    Function Grabar_VentaList(listaDocumento As List(Of documento)) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetMembresiasPorVencerPeriodo(entidadmembresia_Gym As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)

    <OperationContract()>
    Function GetCongelamientoByDocumento(idDocumento As Integer) As List(Of membresia_congelamiento)

    <OperationContract()>
    Function GetMembresiasPorVencer(entidadmembresia_Gym As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)

    <OperationContract()>
    Function UbicarMembresia(id As Integer) As membresia_Gym

    <OperationContract()>
    Function GetRegistroMembresiasByPeriodo(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)

    <OperationContract()>
    Sub EditarMembresia(be As membresia_Gym)

    <OperationContract()>
    Function GetUbicarDocumentoMembresia(idDocumento As Integer) As Entidadmembresia_Gym

    <OperationContract()>
    Function GetTransferenciasByEmpresa(intIdEstablecimiento As Integer) As List(Of documentocompra)

    <OperationContract()>
    Sub GetConfirmarInicio(be As Entidadmembresia_Gym, isEnabled As Boolean)

    <OperationContract()>
    Sub GrabarMembresia(be As membresia_Gym)

    <OperationContract()>
    Function TieneClientesApertura(be As documentoventaAbarrotes) As Boolean

    <OperationContract()>
    Function StockEliminarNotaVenta(idDocVenta As Integer) As Integer


    <OperationContract()>
    Function ObtenerCajaOnlineAnual(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMembresias() As List(Of membresia_Gym)

    <OperationContract()>
    Function GetUbicar_EstadoXCuentaActivoInverso(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Sub GrabarClienteMembresia(documento As documento)

    <OperationContract()>
    Function TieneProveedoresApertura(be As documentocompra) As Boolean

    <OperationContract()>
    Function TienenAperturaInventario(be As documentoLibroDiario) As Boolean

    <OperationContract()>
    Sub InsertarNumeracionInicio(lista As List(Of numeracionBoletas), listaCentroCostos As List(Of centrocosto))

    <OperationContract()>
    Sub InsertarNumeracionXUnidOrg(lista As List(Of numeracionBoletas))

    <OperationContract()>
    Function GetTieneArticulosEnTransitoCompra(be As documentocompra) As Boolean

    <OperationContract()>
    Function GetEstadoCajasTodosDetalleByMensual(be As documentoCaja, periodoAnt As String) As List(Of estadosFinancieros)

    <OperationContract()>
    Function CompraEsvalida(nDOcumento As documentocompra) As Boolean

    <OperationContract()>
    Sub EliminarPedidos(ByVal documentoBE As documento)

    <OperationContract()>
    Sub EliminarCompensacion(ByVal idDocumentoOrigen As Integer)

    <OperationContract()>
    Function GetListaEstadoCuenta422(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function ListaRecursosCostoLibroEntregable(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta432(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function UpdateCotizacion(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetMovimientosKardexByMesAllAlmacen(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Sub CerrarByPeriodo(doc As documento)

    <OperationContract()>
    Function GetExistenComprasSuperiores(be As documentocompra) As Integer

    <OperationContract()>
    Sub GrabarDetalleRecursosLibro(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento))

    <OperationContract()>
    Function GetListadoRecursosPorEntregable(idEntregable As Integer, fechaPeriodo As DateTime) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Sub GrabarRecursoProduccion(be As List(Of recursoCostoDetalle))

    <OperationContract()>
    Function GetListadoRecursosPorEntregableCosteado(idEntregable As Integer, fechaPeriodo As DateTime) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Sub GrabarDetalleCosteoReal(be As List(Of recursoCostoDetalle), idEntregable As Integer, idDocumento As Integer, secuencia As Integer)

    <OperationContract()>
    Function SaveReversionOtraSalida(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer

    <OperationContract()>
    Function SaveReversionOtraEntrada(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer

    <OperationContract()>
    Function GetHojaTrabajoXmodulo(be As asiento) As List(Of usp_HojaTrabajoXmodulo_Result)

    <OperationContract()>
    Function GetHojaTrabajCompras(be As asiento) As List(Of usp_HojaTrabajoCompras_Result)

    <OperationContract()>
    Sub GetCurarKardexCaberas(be As List(Of totalesAlmacen))

    <OperationContract()>
    Sub GetChangeStatusArticulo(Be As totalesAlmacen)

    <OperationContract()>
    Function ListaRecursosCostoLibro(compraBE As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetCambiosDeArticulo(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GrabarCambioArticulo(objDocumento As documento, art As detalleitems) As Integer

    <OperationContract()>
    Function GetComprasObservadas(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Sub GetChangeState(be As documentocompra)

    <OperationContract()>
    Function GenerarTXTventa(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GenerarTXTcompras(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)

    <OperationContract()>
    Sub CambiarPeriodoCaja(be As documentoCaja)

    <OperationContract()>
    Function GetUbicar_documentoCajaID(intIdDocumento As Integer) As documentoCaja

    <OperationContract()>
    Function GetListadoProductosByAlmacen(be As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetFilterArticulosStartWith(be As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Sub EliminarCierre(be As empresaCierreMensual)

    <OperationContract()>
    Sub GrabarCierrePeriodo(be As empresaCierreMensual, documento As documento)

    <OperationContract()>
    Function GetCierresByEmpresa(be As empresaCierreMensual) As List(Of empresaCierreMensual)

    <OperationContract()>
    Function EstadoMesCerrado(be As empresaCierreMensual) As Boolean

    <OperationContract()>
    Function GetUbicar_empresaPeriodoPorID(idempresa As String, periodo As String, idCentroCostos As Integer) As empresaPeriodo

    <OperationContract()>
    Function GetCierreContablePeriodo(be As asiento, periodoAnt As String) As List(Of movimiento)

    <OperationContract()>
    Function TxtPleLibroDiarioV2(idempresa As String, anio As String, mes As String) As List(Of movimiento)

    <OperationContract()>
    Sub GrabarSubProyectoConstruccion(idProyecto As Integer, besub As recursoCosto, listaentregable As List(Of recursoCosto))

    <OperationContract()>
    Sub GrabarProyectoGeneral(be As recursoCosto, besub As recursoCosto, listaentregable As List(Of recursoCosto))

    <OperationContract()>
    Function GetEntregablesXProyecto(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto)

    <OperationContract()>
    Function GetProyectosAll(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto)

    <OperationContract()>
    Function CierreDeEntregables(fechaPeriodo As DateTime, idEmpresa As String, idestable As Integer) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetGastosTipoAll(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto)

    <OperationContract()>
    Function GetEntregablesXSubProy(idEmpresa As String, idEstable As Integer, idSubProy As Integer, periodo As String) As List(Of recursoCosto)

    <OperationContract()>
    Function EnvioDeProductosTerminados(periodo As String, idEntregable As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function ListaCompraDeServicios(compraBE As documentocompra, tipoCosteo As String) As List(Of documentocompradetalle)

    <OperationContract()>
    Function ServiciosSinCosteo(compraBE As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function SaveEntradasProduccion(objDocumento As documento, idEntregable As Integer) As Integer

    <OperationContract()>
    Function GetListaSubProyectos(recurso As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Sub GrabarProyectoConstruccion(be As recursoCosto, besub As recursoCosto, listaentregable As List(Of recursoCosto), plan As List(Of cuentaplanContableEmpresa))

    <OperationContract()>
    Function GetMovimientosKardexByArticulo(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetMovimientosKardexByMes(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetResumenLibroDiarioByPeriodo(be As asiento) As List(Of asiento)

    <OperationContract()>
    Sub ActualizarDocumentoLibroDiarioASM(objLibro As documento)

    <OperationContract()>
    Function GetListadoRecursosPorProyectoGeneral(be As recursoCosto) As List(Of usp_GetRecursosByProyectoGeneral_Result)

    <OperationContract()>
    Sub GrabarDetalleRecursoFinanza(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento))

    <OperationContract()>
    Function UbicarVentaPorCompensar(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, intmoneda As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListadoGastosConsolidados(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetExistenciaTransitoByCompra(be As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetExistenciaTransitoByProveedor(be As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function SumaNotasXidPadreItemVentaOpcionDefault(intIdSecuencia As Integer) As documentoventaAbarrotesDet

    <OperationContract()>
    Function CompensacionDocumentosVenta(objDocumento As documento, objDoc As documento) As Integer

    <OperationContract()>
    Function ListadoNotasVentaDetalleHijos(intIdDocumento As Integer) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function ListadoComprobateVentaNotasXidPadre(iNtPadre As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function UbicarVentaPorClienteXperiodo2Ant(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As String, intmoneda As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetConsultaCuentasPorpagarAnt(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetVentasByFecha(intIdEstablec As Integer, fecha As Date) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetArticulosCompradosByPeriodo(be As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetProductosPorAlmacen(intIdAlmacen As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetKardexByAnioAlmacenAll(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetCostoVentaMensual(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetListado_cierreCostoVenta(cierreBE As cierreCostoVenta) As List(Of cierreCostoVenta)

    <OperationContract()> _
 _
    Sub GrabarListaCierreCostoVenta(lista As List(Of cierreCostoVenta), objDocumento As documento)

    <OperationContract()>
    Function CompensacionDocumentos(objDocumento As documento, objDoc As documento) As Integer

    <OperationContract()>
    Function UbicarComprasXCompensar(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Sub EditarEmpresa(be As empresa, listaCierre As List(Of empresaCierreMensual))

    <OperationContract()>
    Sub CambiarPeriodoLibroDiario(be As documentoLibroDiario)

    <OperationContract()>
    Sub CambiarPeriodoVenta(be As documentoventaAbarrotes)

    <OperationContract()>
    Sub CambiarPeriodoCompra(be As documentocompra)

    <OperationContract()>
    Function SaveCompraNotaDevolucionGasto(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer

    <OperationContract()>
    Function GetSelXtipoExistenciaVenta(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ListadoNotasDetalleHijos(intIdDocumento As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function SumaNotasFinancierasDefault(intIdSecuencia As Integer) As documentocompradetalle

    <OperationContract()>
    Function ListadoComprobateNotasXidPadre(iNtPadre As Integer) As List(Of documentocompra)

    <OperationContract()>
    Sub GetCulminarProduccion(be As recursoCosto)

    <OperationContract()>
    Sub GetEliminarEnvioAalmacen(be As recursoCosto)

    <OperationContract()>
    Sub GetEliminarProductosEnPlanta(be As recursoCosto)

    <OperationContract()>
    Sub GetEliminarCierreParcialTotal(be As recursoCosto)

    <OperationContract()>
    Sub CulminarOrdenProduccionParcial(Be As recursoCosto)

    <OperationContract()>
    Function GetNumRecursosEnPlanta(be As recursoCosto) As Integer

    <OperationContract()>
    Function GetNumRecursosConEntregaParcial(be As recursoCosto) As Integer

    <OperationContract()>
    Sub GetEliminarCierreTotal(be As recursoCosto)

    <OperationContract()>
    Sub GrabarCambioTipoInventario(objDocumento As documento)

    <OperationContract()>
    Sub GrabarRetornoProductosTerminados(objDocumento As documento)

    <OperationContract()>
    Sub GetCerrarPresupuesto(be As recursoCosto)

    <OperationContract()>
    Function GetOrdenesDeProduccionInfo(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function UbicarTodosVentaPorClienteMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Sub DeleteCronoDocumento(ByVal cronograma As List(Of Cronograma))

    <OperationContract()>
    Function GetListarCronogramaDpcumento(idDocumento As Integer) As List(Of Cronograma)

    <OperationContract()>
    Function GetCronogramaCobroFecha(TipoProg As String, FechaInicio As Date, FechaFin As Date) As List(Of Cronograma)

    <OperationContract()>
    Function ConteoVentasNoNegociados() As Integer

    <OperationContract()>
    Function ConteoDeAsientosNoNegociadosCobro() As Integer


    <OperationContract()>
    Function ConteoVencidosCobroCronograma() As Integer

    <OperationContract()>
    Function GetListarCobrosPorMes(tipoProg As String) As List(Of Cronograma)

    <OperationContract()>
    Function UbicarCronogramaVencidosCobro(TipoProg As String) As List(Of Cronograma)

    <OperationContract()>
    Function UbicarCronogramaPorEntidadCobro(idprov As Integer, tipoprov As String) As List(Of Cronograma)


    <OperationContract()>
    Function UbicarCobrosPorAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function UbicarCobrosPorAsientoManualRazon(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, moneda As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function UbicarPagosPorAsientoManualRazon(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, moneda As String) As List(Of documentoLibroDiarioDetalle)


    <OperationContract()>
    Function GetProductosProducidosEnPlanta(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GetCantidadEntregadaProduccion(be As recursoCosto) As recursoCosto

    <OperationContract()>
    Sub GrabarCostoProducido(be As recursoCosto)

    <OperationContract()>
    Sub GrabarProduccionParcial(be As recursoCosto)

    <OperationContract()>
    Function UbicarTodoPagosAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function UbicarTodosPagosPendienteMNME(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentocompra)

    <OperationContract()>
    Function ConteoDeNoNegociados() As Integer

    <OperationContract()>
    Function ConteoDeAsientosNoNegociados() As Integer

    <OperationContract()>
    Function ConteoVencidosCronograma() As Integer


    <OperationContract()>
    Function UbicarCronogramaPorEntidad(idprov As Integer, tipoprov As String) As List(Of Cronograma)

    <OperationContract()>
    Function GetCronogramaDetalleTipoMes(idprov As Integer, tipo As String, tipoEstado As String, mes As Integer, tipoProg As String, tipoMoneda As String) As List(Of Cronograma)

    <OperationContract()>
    Function GetCronogramaTipoAsientoMes(idprov As Integer, tipo As String, tipoEstado As String, mes As Integer, tipoProg As String, tipoMoneda As String) As List(Of Cronograma)


    <OperationContract()>
    Function GetListarPagosPorMes(tipoProg As String) As List(Of Cronograma)

    <OperationContract()>
    Function UbicarCronogramaVencidos(TipoProg As String) As List(Of Cronograma)

    <OperationContract()>
    Function GetCronogramaTrabajo(fechaprog As String, mes As Integer) As List(Of Cronograma)

    <OperationContract()>
    Function UbicarCronogramaFecha(TipoProg As String, FechaInicio As Date, FechaFin As Date) As List(Of Cronograma)

    <OperationContract()>
    Function GetListaProtectosByProyGeneral(recurso As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GetListaProyectosBySubTipo(recurso As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GetKardexByAnioDiaLaboralLote(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Sub EditarConfiguracionGeneral(configBE As configuracionInicio)

    <OperationContract()>
    Function GetLotes() As List(Of recursoCostoLote)

    <OperationContract()>
    Function ExisteCodigoLote(lote As String) As Boolean

    <OperationContract()>
    Function GetUbicar_EstadoCuenta20(idEmpresa As String, periodo As String) As List(Of totalesAlmacen)


    <OperationContract()>
    Function GetListaEstadoCuenta11y18(strEmpresa As String, intIdEstablecimiento As Integer, tipoCuenta As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta40(strEmpresa As String, intIdEstablecimiento As Integer, tipo As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta30al38(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta20al28(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta1413(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta16(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta14(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta123133(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoXCuentaActivo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta122(strEmpresa As String, intIdEstablecimiento As Integer, tipoAnticipo As String, cuenta As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoXCuentaPasivo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetItemsNoAsignadosFinanzas(documentoCaja As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function ListaTotalXCaja(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentoCaja

    <OperationContract()>
    Function ObtenerCajaOnlineXUsuario(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strperiodo As String, ByVal strEntidadFinanciera As String, listasuarios As List(Of String), tipo As String, fechainicio As DateTime, fechaFin As DateTime, intAnio As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Function ResumenCiereCaja(strEmpresa As String, intIdEstablecimiento As Integer, intIdCaja As Integer, estado As String) As List(Of documentoCaja)


    <OperationContract()>
    Function GetUbicar_EstadoCuenta13(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta12(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta43(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetListaEstadoCuenta42(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta423433(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetUbicar_EstadoCuenta41(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)


    <OperationContract()>
    Function CuentaUtilidadOperativa(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function CuentaOtrosIngreso(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function CuentaCostoVenta(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function CuentaVentasNetas2(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function CuentaVentasNetas(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function GetKardexByDiaLaboral_1(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetKardexByDia(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetKardexByAnioDiaLaboral(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ListaRecursosCostoInventario(compraBE As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function CuentaEntregaRendir(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function CuentaAnticipos(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function CuentaCobroComercial(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function CuentaPagoLetras(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function CuentaPagoComercialRel(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function CuentaPagoComercial(asientoBE As asiento) As movimiento

    <OperationContract()>
    Function GetEstadoCajasTodosByDia(be As documentoCaja) As estadosFinancieros

    <OperationContract()>
    Function GetEstadoCajasTodosByDiaAllEmpresa(be As documentoCaja) As estadosFinancieros


    <OperationContract()>
    Function GetSumaComprasDelDia(be As documentocompra) As documentocompra

    <OperationContract()>
    Function GetSumaComprasDelDiaAllEmpresa(be As documentocompra) As documentocompra

    <OperationContract()>
    Function GetSumaVentasDelDia(be As documentoventaAbarrotes) As documentoventaAbarrotes

    <OperationContract()>
    Function GetSumaVentasDelDiaAllEmpresa(be As documentoventaAbarrotes) As documentoventaAbarrotes

    <OperationContract()>
    Function GetEstadoCajasTodosDetalleByDia(be As documentoCaja) As List(Of estadosFinancieros)

    <OperationContract()>
    Function GetEstadoCajasTodosDetalleByDiaAllEmpresa(be As documentoCaja) As List(Of estadosFinancieros)

    <OperationContract()>
    Function GetFlujoEfectivoByDia(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function GetFlujoEfectivoByDiaAllEmpresa(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function CobrosGeneralesAsientos() As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function SumaNotasXidPadreItemOpcionDefault(intIdSecuencia As Integer) As documentocompradetalle

    <OperationContract()>
    Function GetProductoPorAlmacenTipoExByCodigoBarra(intIdAlmacen As Integer, strTipoEx As String, CodBarra As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetMovimientosDetalleByDepodito(be As movimientocajaextranjera) As List(Of movimientocajaextranjera)

    <OperationContract()>
    Function GetDepositosExtranjeros(be As estadosFinancieros) As List(Of documentoCaja)

    <OperationContract()>
    Function CobrosGenerales() As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetCronogramaDetalleAsiento(fechaprog As DateTime) As List(Of Cronograma)

    <OperationContract()>
    Function DeudasGeneralesAsiento() As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetCronogramaDetalleTipoCobros(idprov As Integer, tipo As String, tipoEstado As String, fechaprog As DateTime, tipomoneda As String) As List(Of Cronograma)

    <OperationContract()>
    Function GetCronogramaDetalleCobro(fechaprog As DateTime, fechaVen As DateTime) As List(Of Cronograma)

    <OperationContract()>
    Function GetCronogramaDetalleTipoAsiento(idprov As Integer, tipo As String, tipoEstado As String, fechaprog As DateTime, tipomoneda As String, fechaven As DateTime) As List(Of Cronograma)

    <OperationContract()>
    Function GetCronogramaPagoCobro(TipoProg As String) As List(Of Cronograma)

    <OperationContract()>
    Function GetCronogramaPagoCobroHistorial(TipoProg As String) As List(Of Cronograma)

    <OperationContract()>
    Function ObtenerCuentasPorPagarAsientoDetails(lista As List(Of documentoLibroDiarioDetalle)) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function UbicarPagosPorAsientoManualMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetSaldosCajaEntranjera(be As estadosFinancieros) As List(Of documentoCaja)

    <OperationContract()>
    Function GetEntidadesGenerales(tipo As String, strIdEmpresa As String) As List(Of entidad)

    <OperationContract()>
    Function GetUbicarEntPorID(strEmpresa As String, intIdEntidad As Integer) As entidad


    <OperationContract()>
    Sub CambiarStatusEntidad(ByVal entidadBE As entidad)

    <OperationContract()>
    Sub GrabarVentaMultiEmpresa(listadoDocVenta As List(Of documento))

    <OperationContract()>
    Function GetCuentasFinancierasByEmpresa(ByVal idEmpresa As String, ByVal strTipo As String) As List(Of estadosFinancieros)

    <OperationContract()>
    Function GetPreciosproductoMaxFecha(intIdItem As Integer, CodPrecio As Integer) As configuracionPrecioProducto

    <OperationContract()>
    Function GetPlantillaByIdPadre(be As articuloplantilla) As List(Of articuloplantilla)

    <OperationContract()>
    Function GetPlantillaPadre(be As detalleitems) As List(Of articuloplantilla)

    <OperationContract()>
    Sub InsertPlantillaArticulo(be As articuloplantilla)

    <OperationContract()>
    Sub EditarPlantillaArticulo(be As articuloplantilla)

    <OperationContract()>
    Sub EliminarPlantillaArticulo(be As articuloplantilla)

    <OperationContract()>
    Sub EliminarConsumoDirecto(ByVal documentoBE As documento)

    <OperationContract()>
    Function GetPlantillaByArticulo(be As detalleitems) As List(Of articuloplantilla)

    <OperationContract()>
    Sub GetSaveConsumo(doc As documento, lista As List(Of documentoconsumodirecto))

    <OperationContract()>
    Function UbicarDetallePinturas(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetSumaBySecuencia(be As documentoconsumodirecto) As Decimal

    <OperationContract()>
    Function GetConsumoByidDocumento(be As documentoconsumodirecto) As List(Of documentoconsumodirecto)

    <OperationContract()>
    Sub ConfirmarVentaTicketConsumoDirecto(objDocumento As documento)

    <OperationContract()>
    Function SaveVentaPSPinturas(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetSumaTotalByProyecto(be As recursoCostoDetalle) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetProductosTerminadosByProyecto(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Sub EliminarEntregable(be As recursoCosto)

    <OperationContract()>
    Sub GrabarEntregable(be As recursoCosto)

    <OperationContract()>
    Sub EditarEntregable(be As recursoCosto)

    <OperationContract()>
    Sub GetOpenActividad(be As recursoCosto)

    <OperationContract()>
    Sub GetPendingActividad(be As recursoCosto)

    <OperationContract()>
    Function GetPlaneamientoKanban(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Sub GetUpdateSecuencia(be As List(Of recursoCosto))

    <OperationContract()>
    Sub GetCierreActividad(be As recursoCosto)

    <OperationContract()>
    Sub GetUpdatefechaActual(be As recursoCosto)

    <OperationContract()>
    Sub GetUpdateCronograma(be As recursoCosto)

    <OperationContract()>
    Function GetPlaneamientoActividades(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GetPlaneamientoEDT_Produccion(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GrabarProduccion(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetUbicar_totalesAlmacenPorID(idMovimiento As Integer) As totalesAlmacen

    <OperationContract()>
    Function GetProductosParecidosRequeridos(be As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetRecursoPlaneadosPendientesAprobacion(be As recursoCostoDetalle) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetRecursoPlaneadoConteo(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetRecursosAsignadosByTipoCosto(be As recursoCostoDetalle) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Sub EditarRequerimeintoBySec(be As recursoCostoDetalle)

    <OperationContract()>
    Function GetActividadProcesoByProyecto(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Sub EditarStatusCostoByID(be As recursoCosto)

    <OperationContract()>
    Sub EditarCostoTarea(be As recursoCosto)

    <OperationContract()>
    Sub EliminarProcesos(i As recursoCosto)

    <OperationContract()>
    Sub EliminarCostoDetalleBySec(i As recursoCostoDetalle)

    <OperationContract()>
    Sub EliminarDetalleCostoPlan(be As recursoCostoDetalle)

    <OperationContract()>
    Sub EditarDetalleRecursoTareaBySecuencia(be As recursoCostoDetalle)

    <OperationContract()>
    Function GetRecursosAsignadosByCosto(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetRecursosAsignadosByProceso(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Sub GrabarDetalleRecursosByTarea(be As recursoCostoDetalle)

    <OperationContract()>
    Function GetTareasByProyecto(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Sub GrabarTask(be As recursoCosto)

    <OperationContract()>
    Function GetProyectoByCodigoGenerado(recurso As recursoCosto) As recursoCosto

    <OperationContract()>
    Function GetListaPryectosEnCarteraFull(recurso As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GetConsultaCuentasPorpagar(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetConsultaCuentasPorpagarTodosProveedores(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetAntReclamacionesProveedor(be As documentocompra) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetConfigurationPaySaldo(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)

    <OperationContract()>
    Function GetConfigurationPaySaldoCajero(Be As estadosFinancierosConfiguracionPagos) As List(Of estadosFinancierosConfiguracionPagos)

    <OperationContract()>
    Function GetReporteElmentoCostoAnual(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetReporteElmentoCostoByProceso(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Sub GetCulminarCostoProduccion(be As recursoCosto, documento As documento)

    <OperationContract()>
    Function GetProductosTerminadosByCosto(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GetEstadoCajasTodosDetalle() As List(Of estadosFinancieros)

    <OperationContract()>
    Function GetEstadoCajasTodos() As estadosFinancieros

    <OperationContract()>
    Function GetFlujoEfectivo() As List(Of documentoCaja)

    <OperationContract()>
    Sub EliminarCostoPadre(be As recursoCosto)

    <OperationContract()>
    Sub GetEliminarCierreProduccion(be As recursoCosto)

    <OperationContract()>
    Function GetSumaTotalElementoCosto(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Sub GetEliminarCierreCosto(be As recursoCosto)

    <OperationContract()>
    Sub GetCulminarCosto(be As recursoCosto, documento As documento)

    <OperationContract()>
    Function GetSumaTotalImportesByCosto(be As recursoCosto) As recursoCosto

    <OperationContract()>
    Sub EliminarAsientoCostos(be As asiento)

    <OperationContract()>
    Sub CambioAsigancion(be As recursoCostoDetalle)

    <OperationContract()>
    Function GetCountItemsByProceso(be As recursoCosto) As Integer

    <OperationContract()>
    Function GetProcesosByCosto(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GetListadoRecursosByPadre(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetListadoRecursosByProceso(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetAlmacenesByProducto(intIdItem As Integer, strIdEmpresa As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetKardexByAnio(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetKardexByfechaDocumentoLote(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetAlertaMovimientosAlmacen() As List(Of documentocompra)

    <OperationContract()>
    Sub ActulizarCantidadesByItem(be As totalesAlmacen)

    <OperationContract()>
    Function GetArticulosVendidosByDia(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetListarAllVentasPorCliente(objDocumento As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetArticulosVendidosByMes(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Sub GetConfirmarAlertaventa(be As documentoventaAbarrotes)

    <OperationContract()>
    Function ListadoventasObservadasChild(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetMovimientoXusuarioInfo(intUsuario As Integer, fechaActual As Date) As List(Of documentoCaja)

    <OperationContract()>
    Function UbicarDocCajaXIdEntidadOrigen(intEntidadFinan As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer

    <OperationContract()>
    Function ObtenerMovimientosPorPeriodoFinanzas(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerMovimientosPorPeriodoFinanzasXiDCaja(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, idCaja As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Function ListaReversionXDoc(strEmpresa As String, intIdEstablecimiento As Integer, idDocumento As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerMovimientosPorPeriodoFinanzasInforGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, intAnio As Integer, intMes As Integer, strMovimiento As String, tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentoCaja)

    <OperationContract()>
    Function SaveGroupCajaReversiones(objDocumentoBE As documento) As Integer

    <OperationContract()>
    Sub updateEstadoCaja(idDocumento As Integer, estado As String)


    <OperationContract()>
    Sub ConfirmacionBancaria(be As List(Of documentoCaja))

    <OperationContract()>
    Function ObtenerMovCajaReversion(strEmpresa As String, anio As Integer, mes As Integer) As List(Of documentoCaja)


    <OperationContract()>
    Function ObtenerHistorialReversion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, tipoEstado As List(Of String)) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerAnticiposConDevolucion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, listaMovimiento As List(Of String), tipoEstado As List(Of String), listaTransac As List(Of String)) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerMovCajaDevolucion(strEmpresa As String, anio As Integer, mes As Integer, tipo As List(Of String), listaEstado As List(Of String), listaMov As List(Of String)) As List(Of documentoCaja)

    <OperationContract()>
    Function GetMovimientoXusuarioInfoDetalle(intUsuario As Integer, fechaActual As Date) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function GetReporteListaGeneralPrecios() As List(Of configuracionPrecioProducto)

    <OperationContract()>
    Function GetReporteMovAlmcenByEntradaSalida(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetReporteTransferenciaAlmacen(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListaProductosByEstablecimiento(IntIdEstablecimiento As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetPreciosItems() As List(Of configuracionPrecioProducto)

    <OperationContract()>
    Sub DeleteTC(ByVal tipoCambioBE As tipoCambio)

    <OperationContract()>
    Function GetListar_tipoCambioByPeriodo(idempresa As String, mes As Integer, anio As Integer, intIdEstablecimiento As Integer) As List(Of tipoCambio)

    <OperationContract()>
    Function GetExistenciasByempresa() As List(Of detalleitems)

    <OperationContract()>
    Function GetTipoExistenciasByempresa(tipo As Integer) As List(Of detalleitems)

    <OperationContract()>
    Function GetExistenciasByempresaCodigo(idempresa As String, idEstable As Integer, codigobarra As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetExistenciasByempresaNombre(nombre As String, empresaID As String) As List(Of detalleitems)

    <OperationContract()>
    Function SubProductosEntregables(idEntregable As Integer) As List(Of detalleitems)


    <OperationContract()>
    Function GetResporteItemsByGastos(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetResporteItemsByProyecto(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Function GetExistenciaByCodeBar(intCodigoBar As String) As detalleitems

    <OperationContract()>
    Function GetRentabilidadPorPeriodo(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetRentabilidadPorDia(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetAlertaIventarioMinimo(be As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetAlertaIventarioMinimoConteo(be As totalesAlmacen) As Integer

    <OperationContract()>
    Function GetVentasPeriodoByClienteConteo(be As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function SaveVentaCobrada(objDocumento As documento) As Integer

    <OperationContract()>
    Function GrabarCotizacion(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetProveedoresEnTransito(be As documentocompra) As List(Of entidad)

    <OperationContract()>
    Function ObtenerCuentasPorPagarBySecuencia(strItemAfectado As Integer) As documentoCajaDetalle

    <OperationContract()>
    Function GetStockAlmacenesBytem(be As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetExistenciasByEstablecimiento(intEstable As Integer) As List(Of detalleitems)

    <OperationContract()>
    Function GetExistenciasByEstablecimientoEspecial(intEstable As Integer) As List(Of detalleitems)

    <OperationContract()>
    Function GetKardexByPerido(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetKardexPeridoByExistencia(be As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetEsAlmacenVirtual(intIdAlmacen As Integer) As Boolean

    <OperationContract()>
    Sub GrabarEnvioTransito(be As documento)

    <OperationContract()>
    Function GetCountExistenciaTransito(be As documentocompra) As Integer

    <OperationContract()>
    Function GetProductosByAlmacen(almacenBE As almacen, Optional ByVal TipoExistencia As String = Nothing) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetProductosByAlmacenCodigo(intIdAlmacen As Integer, Optional ByVal CodigoBarra As String = Nothing) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetComprobantesEnTransito(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetExistenciaTransito(be As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetExistenciasInicio(be As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetventasDeApertura(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetComprasDeApertura(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetSumaInicioExistencias(be As documentoLibroDiario) As documentoLibroDiario

    <OperationContract()>
    Function GetCuentasPorCobrarInicio(be As documentoventaAbarrotes) As documentoventaAbarrotes

    <OperationContract()>
    Function GetCuentasPorPagarInicio(be As documentocompra) As documentocompra

    <OperationContract()>
    Function GetCuentasByTipoDeAporteInicio(be As estadosFinancieros) As List(Of estadosFinancieros)

    <OperationContract()>
    Function ListadoEstadosFinanConteo(strIdEmpresa As String, intEstablec As Integer) As Integer

    <OperationContract()>
    Function GetSumaCuentasByTipo(be As estadosFinancieros) As List(Of estadosFinancieros)

    <OperationContract()>
    Function GetCuentasAperturaEmpresa(be As documentoLibroDiario) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GetConteoDetracciones(be As documentocompra) As Integer

    <OperationContract()>
    Sub UpdateDataDetraccion(be As documentocompra)

    <OperationContract()>
    Function GetListadoDetracciones(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetElementosCostoByCosto(be As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GetCostoCount(subTipoCosto As String) As Integer

    <OperationContract()>
    Function ObtenerMaxCuentabyCuenta(be As cuentaplanContableEmpresa) As cuentaplanContableEmpresa

    <OperationContract()>
    Function GetSumByCostoGastos(be As recursoCosto) As Double

    <OperationContract()>
    Function GetSumByCosto(be As recursoCosto) As Double

    <OperationContract()>
    Function ListadoventasObservadasConteo(be As documentoventaAbarrotes) As Integer

    <OperationContract()>
    Function ListadoventasObservadas(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetVentasNotificadasAtendCompras(intIdDocumento As Integer) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function ObtenerDesembolsoApto(idempresa As String, tipo As String) As List(Of prestamos)

    <OperationContract()>
    Sub GrabarListaAsientosXConciliar(be As List(Of asiento))

    <OperationContract()>
    Function GetListaTablaDetalleMotivo(intIdTabla As Integer, strEstado As String, codigo As String) As List(Of tabladetalle)


    <OperationContract()>
    Function GetUbicarTablaexistenciaCambioInventario() As List(Of tabladetalle)


    <OperationContract()>
    Function GetListaTablaDetalleXusuario(intIdTabla As Integer, strEstado As String, listaoperacion As List(Of String)) As List(Of tabladetalle)


    <OperationContract()>
    Function GetPantillasGeneral(tipoOper As String) As List(Of asientoContablePlantilla)

    <OperationContract()>
    Function GetListadoRecursosByIdCosto(be As recursoCosto) As List(Of recursoCostoDetalle)

    <OperationContract()>
    Sub GrabarDetalleRecursos(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento))

    <OperationContract()>
    Sub GrabarCosto(be As recursoCosto, plan As List(Of cuentaplanContableEmpresa), listaProcesos As List(Of recursoCosto))

    <OperationContract()>
    Sub GrabarCostoOne(be As recursoCosto)

    <OperationContract()>
    Sub EditarCosto(be As recursoCosto)

    <OperationContract()>
    Sub EliminarCosto(be As recursoCosto)

    <OperationContract()>
    Function GetListaRecursosXtipo(recurso As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function GetCostoById(be As recursoCosto) As recursoCosto

    <OperationContract()>
    Function GetNumFinanzasSinAsiento(be As documentoCaja) As Integer

    <OperationContract()>
    Function GetInventariosSinAsiento(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetFinanzasSinAsiento(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function GetNumAlertasInventariosSinAsiento(be As documentocompra) As Integer

    <OperationContract()>
    Function ObtenerCajaUsuarioFull(empresa As String, idEstable As Integer) As List(Of cajaUsuario)

    <OperationContract()>
    Function ListadoCajaAsigConteo(strEmpresa As String, intIdEstablecimiento As Integer) As Integer

    <OperationContract()>
    Function ListadoCajaFullConteo(strEmpresa As String, intIdEstablecimiento As Integer) As Integer

    <OperationContract()>
    Function VerificarCajaEstadoXUsuario(idPersona As String) As Boolean


    <OperationContract()>
    Function ObtenerCajaUsuarioFullEstado() As List(Of cajaUsuario)

    <OperationContract()>
    Function ObtenerCajaUsuarioFullXpersona(strEmpresa As String, idEstablec As Integer, periodo As String, idPersonal As Integer) As List(Of cajaUsuario)


    <OperationContract()>
    Function UbicarConteoVentaCompra(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As documento

    <OperationContract()>
    Function GetTotalComprasByPeriodoProveedor(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetProductoPorAlmacenTipoExTodo(intIdAlmacen As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetSumaNotasXperiodo(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetTatalResumenComprasXtipo(be As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GetNumComprasXparameter(be As documentocompra, caso As String) As Integer

    <OperationContract()>
    Sub GrabarGrupoDetalle(be As recursoCosto)

    <OperationContract()>
    Function GetCountItemsNoAsignados(compraBE As documentocompra) As Integer

    <OperationContract()>
    Function ObtenerGastosEmpresa(recursoBE As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Sub EliminarComprobanteORPByCosto(ByVal documentoBE As documento)

    <OperationContract()>
    Function ListadoComprobantesPorORP(compraBE As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function GrabarProductosTerminados(objDocumento As documento) As Integer

    <OperationContract()>
    Function SumatoriaXcosto(recursoBE As recursoCosto) As documentocompradetalle

    <OperationContract()>
    Sub QuitarAsignacionRecurso(i As documentocompradetalle)

    <OperationContract()>
    Sub CulminarCosto(r As recursoCosto, documento As documento)

    <OperationContract()>
    Function ListaRecursoAsignadoByIdCosto(i As documentocompradetalle, doccompra As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function ListaRecursoAsignadoByIdCostoSingle(i As documentocompradetalle, doccompra As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Sub UpdateCostoItem(i As documentocompradetalle, documento As documento)

    <OperationContract()>
    Sub UpdateCostoItemSingle(i As documentocompradetalle)

    <OperationContract()>
    Function ObtenerCostoById(recursoBE As recursoCosto) As recursoCosto

    <OperationContract()>
    Function ListaRecursosCosto(compraBE As documentocompra) As List(Of documentocompradetalle)

    <OperationContract()>
    Function ObtenerCostosPorSubTipo(recursoBE As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function ObtenerCostosPorSubTipoPorStatus(recursoBE As recursoCosto, Optional listaStatus As List(Of String) = Nothing) As List(Of recursoCosto)

    <OperationContract()>
    Function ObtenerCostosPorTipo(recursoBE As recursoCosto) As List(Of recursoCosto)

    <OperationContract()>
    Function BalanceGeneralAnual(asientoBE As asiento) As List(Of movimiento)

    <OperationContract()>
    Sub CerrarTipoCambioDolaresPeriodo(lista As List(Of documentocompra))

    <OperationContract()>
    Function CerrarComprasMonedaExtranjera(compraBE As documentocompra) As List(Of documentocompra)

    <OperationContract()>
    Function CuentaExistenteEnBD(cuentaBE As cuentaplanContableEmpresa) As Boolean

    <OperationContract()>
    Sub InsertarListaDeCuentas(ListaCuentas As List(Of cuentaplanContableEmpresa))

    <OperationContract()>
    Function GetListadoPagosPorUsuario(be As Cronograma) As List(Of Cronograma)

    <OperationContract()>
    Sub GrabarRecepcionDePagos(be As List(Of Cronograma))

    <OperationContract()>
    Sub EditarRecepcionDePagos(be As List(Of Cronograma))

    <OperationContract()>
    Sub EliminarItemCronograma(be As Cronograma)

    <OperationContract()>
    Sub DeleteItemVenta(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetListar_almaPuntoUbi(intIdEstablecimiento As Integer) As List(Of almacen)

    <OperationContract()>
    Sub EditarCajaUsuarioNuevo(objCajaUsuarioBE As cajaUsuario)

    <OperationContract()>
    Function ResumenDetailVenta(be As cajaUsuario) As List(Of cajaUsuariodetalle)

    <OperationContract()>
    Function LoadCuentasActInmov(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function InsertarMarcaHijo(nTabDet As item) As Integer

    <OperationContract()>
    Function GetProductoPorAlmacenItem(intIdAlmacen As Integer, strTipoEx As String, iditem As Integer) As List(Of totalesAlmacen)


    <OperationContract()>
    Function GetListar_almacenesTipo(intIdEstablecimiento As Integer, tipo As String) As List(Of almacen)

    <OperationContract()>
    Function GetListar_almacenesTipobyEmpresa(almacenBE As almacen) As List(Of almacen)

    <OperationContract()>
    Function GetUbicarProductosXIdHijo(ByVal idEmpresa As String, idEstablec As Integer, iditem As Integer, tipo As String) As List(Of detalleitems)


    <OperationContract()>
    Function GetUbicarProductosXcodigoBarra(ByVal idEmpresa As String, idEstablec As Integer, codigobarra As String) As detalleitems

    <OperationContract()>
    Function ListaIdPadre() As List(Of item)

    <OperationContract()>
    Function ListarPadreHijos(idpadre As Integer) As List(Of item)

    <OperationContract()>
    Function ProductosMayoresStock(tot As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function ResumenTransaccionesXusuarioCaja(be As cajaUsuario) As List(Of cajaUsuario)

    <OperationContract()>
    Function ResumenTransaccionesXusuarioCajaPago(be As cajaUsuario) As List(Of cajaUsuario)

    <OperationContract()>
    Function usp_ResumenTransaccionesXusuarioCajaXCierre(be As cajaUsuario) As List(Of cajaUsuario)

    <OperationContract()>
    Function ProductosMenoresStock(tot As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function VentasCantidadStock(cantidad As String, fechaini As Date, fechafin As Date, mayor As Decimal, menor As Decimal) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Sub EliminarVentaGeneralPV(ByVal documentoBE As documento)

    <OperationContract()>
    Sub EliminarVentaTicketDirecta(ByVal documentoBE As documento)

    <OperationContract()>
    Function GetListarAllNotasPedido(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarCotizaciones(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetConteoPedidos(intIdEstablec As Integer, strPeriodo As String) As Integer

    <OperationContract()>
    Function ObtenerTipoCambioXfecha(idempresa As String, fecha As Date, intIdEstablecimiento As Integer) As tipoCambio

    <OperationContract()>
    Function SP_UbicarDetalleCompraControl(intIdDocumento As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function ReporteSaldoInicioXperiodoHojaTrabajo(intAnio As Integer, intMes As Integer, idEmpresa As String) As List(Of cierrecontable)

    <OperationContract()>
    Function ListarCuentasPorPadreDescrip(strEmpresa As String, strCuentaPadre As String) As List(Of cuentaplanContableEmpresa)


    <OperationContract()>
    Function UbicarClientePoID(ByVal strNroPersona As String) As entidad

    <OperationContract()>
    Function UbicarClienteXID(ByVal entidadBE As entidad) As entidad

    <OperationContract()>
    Function ListadoServiciosPadreTipo(ByVal tipo As String) As List(Of servicio)

    <OperationContract()>
    Function NumProductosSinListaPrecio(tot As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function SaveVentaTicketPS(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer

    <OperationContract()>
    Function UpdateVentaPS(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer


    <OperationContract()>
    Function ListarDetallexCuenta(strPeriodo As String, intMes As String, cuenta As String) As List(Of movimiento)

    <OperationContract()>
    Function ObtenerProdXAlmacenesXMesAllXExisten(ByVal idAlmacen As String, ByVal periodo As Integer, ByVal mes As String, ByVal tipo As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Sub GrabarPrecioGeneral(listaPrecio As configuracionPrecio)

    <OperationContract()>
    Sub UpdatePrecioGeneral(listaPrecio As configuracionPrecio)

    <OperationContract()>
    Sub DeletePrecioGeneral(listaPrecio As configuracionPrecio)

    <OperationContract()>
    Function ObtenerAlertaDePrecio(productoBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function ObtenerAlertaDePrecioConteo(ByVal productoBE As totalesAlmacen) As Integer

    <OperationContract()>
    Function ListadoServiciosHijosXIdTipo(servicioBE As servicio) As List(Of servicio)

    <OperationContract()>
    Function GrabarServicioPadre(servicioBE As servicio) As Integer

    <OperationContract()>
    Sub EliminarServicioPadreHijo(servicioBE As servicio)

    <OperationContract()>
    Sub UpdateCantMaxMin(ByVal totalesALmacenBE As totalesAlmacen)

    <OperationContract()>
    Sub EditarServicioPadre(ByVal servicioBE As servicio)

    <OperationContract()>
    Function GetUbicar_documentocompradetallePorCompraEx(intIdDocumento As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function MostrarPagosVariosCP(intIdDocumentoPadre As Integer) As List(Of documentoLibroDiario)

    <OperationContract()>
    Function GrabarAjustes(objDocumento As documento) As Integer

    <OperationContract()>
    Function ReporteSaldoInicioXperiodo(intAnio As Integer, intMes As Integer) As List(Of cierrecontable)

    <OperationContract()>
    Function BuscarCuentasBalance(strPeriodo As Integer) As List(Of movimiento)

    <OperationContract()>
    Sub ListadoItemsDeInicio(ByVal list As List(Of detalleitems), documentoBE As documento)

    <OperationContract()>
    Sub InsertGrupoEntidad(list As List(Of entidad))

    <OperationContract()>
    Sub DeleteLibroDiario(ByVal intIdDocumento As Integer)

    <OperationContract()>
    Function UbicarDocumentoLibroDiario(intIdDocumento As Integer) As documentoLibroDiario

    <OperationContract()>
    Sub ActualizarDocumentoLibroDiario(objLibro As documento)

    <OperationContract()>
    Sub EliminarCierreContable(cierreBE As cierrecontable)

    <OperationContract()>
    Function GetEstadoSaldoEF(EF As estadosFinancieros) As estadosFinancieros

    <OperationContract()>
    Sub EliminarCierreCaja(cierreBE As cierreCaja)

    <OperationContract()>
    Function GetListado_cierreCajasPorPeriodo(cierreBE As cierreCaja) As List(Of cierreCaja)

    <OperationContract()>
    Sub EliminarCierreInventario(cierreBE As cierreinventario)

    <OperationContract()>
    Function MostrarCierreInvPorPeriodo(inventarioMov As InventarioMovimiento) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function UbicarExcedenteCompraPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As String, intmoneda As String) As List(Of documentocompra)

    <OperationContract()>
    Function ListaDeCajasPorCerrar(be As documentoCaja) As List(Of documentoCaja)

    <OperationContract()>
    Function CajaTienePeriodoCerrado(strEmpresa As String, strperiodo As String, intIdEstaclecimiento As Integer) As Boolean

    <OperationContract()>
    Function PeriodoInventarioCerrado(strempresa As String, strPeriodo As String) As Boolean

    <OperationContract()>
    Function ObtenerPeriodosCerrados(cierreBE As cierreinventario) As List(Of cierreinventario)

    <OperationContract()>
    Function GetListado_cierreinventarioPorPeriodo(cierreBE As cierreinventario) As List(Of cierreinventario)

    <OperationContract()>
    Function RecuperarCierreCajaXEF(intAnio As Integer, intMes As Integer, intIdEF As Integer) As cierreCaja


#Region "Servicios"
    <OperationContract()>
    Function GrabarServicio(servicioBE As servicio) As Integer

    <OperationContract()>
    Sub EliminarServicio(servicioBE As servicio)



    <OperationContract()>
    Function ListadoServiciosHijos() As List(Of servicio)

    <OperationContract()>
    Function ListadoServiciosHijosXtipo(servicioBE As servicio) As List(Of servicio)

    <OperationContract()>
    Function UbicarServicioPorId(servicioBE As servicio) As servicio
#End Region

    <OperationContract()>
    Sub EliminarNotaCreditoMetodoVenta(obj As documento)

    <OperationContract()>
    Sub EliminarNotaDebitoVenta(obj As documento)

    <OperationContract()>
    Function UbicarExcedenteVentaPorClienteXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As String, intmoneda As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function ListarDetallePagosXcodigoLibro(caja As documentoCaja) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function UbicarVentaPorClienteXperiodo2(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer, strPeriodo As DateTime, intmoneda As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetCuentasXPagarTodoClientes(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As DateTime, intmoneda As String, estadocobro As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function SaveVentaNotaCredito2(objDocumento As documento,
                                         nDocumentoNota As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer

    <OperationContract()>
    Function SaveVentaNotaDebito(objDocumento As documento) As Integer

    <OperationContract()>
    Function RecuperarCierre(intAnio As Integer, intMes As Integer, intIdItem As Integer) As cierreinventario

    <OperationContract()>
    Function GetListarCuotasDocumento(idDocumento As Integer) As List(Of Cronograma)

    '<OperationContract()> _
    'Function RecuperarCierreListado(intAnio As Integer, intMes As Integer, intIdItem As Integer) As List(Of cierreinventario)

    <OperationContract()>
    Function ObtenerKardexRangoFecha(ByVal idAlmacen As String, fecDesde As Date, fecHasta As Date) As List(Of InventarioMovimiento)

    <OperationContract()>
    Sub CerrarInventario(lista As List(Of cierreinventario))

    <OperationContract()>
    Function GrabarVentaGeneral(objDocumento As documento) As List(Of totalesAlmacen)

    <OperationContract()>
    Sub GrabarCuetasPorCobrarApertura(be As List(Of documento))

    <OperationContract()>
    Function GrabarNotaDebito(objDocumento As documento, nDocumentoNota As documento) As Integer

    <OperationContract()>
    Sub DeleteReciboHonorario(nDocumento As documento)

    <OperationContract()>
    Sub UpdateReciboHonorario(objDocumento As documento)

    <OperationContract()>
    Function ListarCuentasServiciosPublicos(ByVal strIdEmpresa As String) As List(Of mascaraGastosEmpresa)

    <OperationContract()>
    Sub EliminarNotaCreditoMetodoNuevo(obj As documento)

    <OperationContract()>
    Sub EliminarNotaCreditoBonificacion(obj As documento)

    <OperationContract()>
    Sub EliminarNotaDebitoMetodoNuevo(obj As documento)

    <OperationContract()>
    Function BuscarCuentasFull(strPeriodo As Integer) As List(Of movimiento)

    <OperationContract()>
    Function ValidarPrecioExistente(intIdProducto As Integer) As listadoPrecios

    <OperationContract()>
    Sub ListaComprasAutoriza(objListaCompras As List(Of documentocompra))

    <OperationContract()>
    Function CambiarTipoCambio(ByVal tipoCambioBE As tipoCambio) As Integer

    <OperationContract()>
    Sub EliminarCompraGeneral(ByVal documentoBE As documento)

    <OperationContract()>
    Function ValidarUsuarioAbierto(intIdUsuario As Integer) As cajaUsuario

    <OperationContract()>
    Function InsertarMarca(nTabDet As tabladetalle) As Integer

    <OperationContract()>
    Function GetUbicarTablaexistencia() As List(Of tabladetalle)

    <OperationContract()>
    Function GetListarAllVentasxDia(intIdEstablec As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasNormalPorDia(intIdEstablec As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasNormalPorDiaCredito(intIdEstablec As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function UbicarAsientoPorPeriodoXcodigo(srtFechaMes As Date, srtFechaAnio As Date, strAprobado As String, strCodigo As String) As List(Of asiento)

    <OperationContract()>
    Function GetListAllComprasxDia(intIdEstablecimiento As Integer, Optional Dia As DateTime = Nothing) As List(Of documentocompra)




#Region "CAJAS LISTADO PARENT"

    <OperationContract()>
    Function GetVentasPeriodoByCliente(be As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarAllVentasPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarAllVentasPeriodoPendiente(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarAllVentasPeriodoPendienteEspecial(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarAllVentasPeriodoXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarAllVentasDiaXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarAllCotizacionXPeriodoXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarAllCotizacionXDiaXUsuario(documentoventaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)



    <OperationContract()>
    Function GetListarVentasNormalPorPeriodoCredito(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function SaveVentaNormalServicioCredito(objDocumento As documento) As Integer


    <OperationContract()>
    Sub UpdateVentaNormalServicioCredito(objDocumento As documento)

    <OperationContract()>
    Function ListadoComprobaNtesXidPadre(iNtPadre As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Function HistorialCobrosCajeroAdmi(iNtPadre As Integer) As List(Of documentoCaja)



    <OperationContract()>
    Function ListadoCajaDetalleHijos(intIdDocumento As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Sub ElimiNarPagoCompra(ByVal documentoBE As documento)
#End Region


    <OperationContract()>
    Function OntenerListadoVentasAbarrotesDia(strEmpresa As String, intIdEstablecimiento As Integer, day As Date) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function ObtenerMarcaPorAlmacenesPorMes(ByVal idAlmacen As String, ByVal marca As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)


    <OperationContract()>
    Function ObtenerMarcaPorAlmacenes(ByVal idAlmacen As String, ByVal marca As String) As List(Of InventarioMovimiento)


    <OperationContract()>
    Function ObtenerMarcaPorAlmacenesPorAnio(ByVal idAlmacen As String, ByVal marca As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function getTableAnticiposPorPeriodoTipo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoAnticipo)


#Region "REPORTES"

#Region "VENTAS"

    <OperationContract()>
    Function OntenerListadoVentasAbarrotesPorMes(strEmpresa As String, intIdEstablecimiento As Integer,
                                              intmes As String, anio As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function OntenerVentasAnuales(intIdEstablecimiento As Integer, anio As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function OntenerCobrosVentaMes(intIdEstablecimiento As Integer, anio As String) As List(Of documentoCaja)

    <OperationContract()>
    Function LidtadoNotasXCliente(fecINic As DateTime, fecHasta As DateTime, idProv As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function ListadoVentaClienteOrAnticulo(strIdEmpresa As String, intEstablec As Integer, idclie As Integer, nameArt As String, fecINic As DateTime, fecHasta As DateTime, tipo As String) As List(Of documentoventaAbarrotesDet)


    <OperationContract()>
    Function ListadoVentaClienteArticulo(idclie As Integer, nameArt As String, fecINic As DateTime, fecHasta As DateTime) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function ReporteCuentasPorCobrarPorCliente(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ReportePagosDetalladoPorCliente(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)
#End Region



    <OperationContract()>
    Function UbicarAnticipoPorProveedorNroVoucher(intIdProveedor As Integer) As documentoAnticipo

    <OperationContract()>
    Function ObtenerCajaPagoPorVentaSL(ByVal idDocumentoVenta As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Sub ConfirmarVentaTicketSL(objDocumento As documento, objDocumentoCaja As documento,
                                    objTotalesAlmacen As List(Of totalesAlmacen), cajaUsuario As cajaUsuario, ndocAnticipoDetalle As documentoAnticipoDetalle,
                                      cajaUsuarioAporte As documento, objDocCajaDetalle As List(Of documentoCajaDetalle))


    <OperationContract()>
    Function ReportePagosDetalladoPorProveedor(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ReporteCuentasPorPagarPorProveedor(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)


    <OperationContract()>
    Function ListaComprasXporveedor(fecInic As DateTime, fecHasta As DateTime, idProv As Integer) As List(Of documentocompradetalle)


    <OperationContract()>
    Function GetListarPagosPorANioReporte(ANio As Integer, strTipoMov As String) As List(Of documentoCaja)

    <OperationContract()>
    Function GetListarComprasPorANioReporte(intIdEstablecimiento As Integer, ANio As Integer) As List(Of documentocompra)

    <OperationContract()>
    Function LidtadoNotasXempresa(fecINic As DateTime, fecHasta As DateTime, idProv As Integer) As List(Of documentocompra)
#End Region

    <OperationContract()>
    Function ResumenTransaccionesUsuarios(intIdUserCaja As Integer, strTipoMov As String) As documentoCaja

    <OperationContract()>
    Function ResumenTransaccionesxUsuarioDEP(intIdUserCaja As Integer) As documentoCaja

    <OperationContract()>
    Function GetSaldoCuentaFinancieraXusuario(documentoBE As documentoCaja) As documentoCaja

    <OperationContract()>
    Function ResumenTransaccionesFullUsers(intIdPadre As Integer, strTipoMov As String) As List(Of documentoCaja)



    <OperationContract()>
    Function GetVentasAnuales(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetSumaCuentasXCobrar(intIdEstable As Integer, intNumero As Integer) As documentoventaAbarrotes

    <OperationContract()>
    Function GetListarVentasPorCategoria(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    '<OperationContract()> _
    'Function SaveVentaNormalServicio(objDocumento As documento, objDocumentoCaja As documento) As Integer

    '<OperationContract()> _
    'Sub UpdateVentaNormalServicio(objDocumento As documento, objDocumentoCaja As documento)


    '<OperationContract()> _
    'Sub DeleteVentaNormalServicio(ByVal documentoBE As documento)

    <OperationContract()>
    Function SumaxTipoEF(strTipo As String, strTipoMov As String) As documentoCaja

    <OperationContract()>
    Function SumaxINgresosEgresos(strTipoMov As String) As List(Of documentoCaja)

    <OperationContract()>
    Function SumaxINgresosEgresosAnual() As List(Of documentoCaja)

    <OperationContract()>
    Function GetSumaCuentasXpagar(intIdEstable As Integer, strPeriodo As String) As documentocompra

    <OperationContract()>
    Function GetCuentasXpagarPorFechaVencimiento(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, caso As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetCuentasXpagarPorFechaPeriodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarVentasPorAnio(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

#Region "Anticipos"
    <OperationContract()>
    Function getTableAnticiposPorPeriodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoAnticipo)

    <OperationContract()>
    Function SaveAnticipoSL(objDocumento As documento, objDocumentoCaja As documento) As Integer

    <OperationContract()>
    Sub UpdateAnticipoSL(objDocumento As documento, objDocumentoCaja As documento)

    <OperationContract()>
    Function UbicarDocumentoAnticipo(intidDocumento As Integer) As documentoAnticipo

    <OperationContract()>
    Function ObtenerOtrosAportesXFinanzas(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipo As String) As List(Of documentoAnticipo)

    <OperationContract()>
    Function ObtenerOtrosAportesXFinanzasFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoAnticipo)


    <OperationContract()>
    Sub DeleteAnticipoSL(nDocumento As documento)

#End Region

#Region "LIBROS CONTABLES"
    <OperationContract()>
    Function SaveVentaNormalAlContado(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objDocumentoCaja As documento) As Integer

    <OperationContract()>
    Sub ActualizarAsientoDetalleXidAsiento(objAsiento As asiento)

    <OperationContract()>
    Sub ActualizarEstadoAprobado(ByVal asientos As List(Of asiento))

    <OperationContract()>
    Function GetUbicar_documentoLibroDiarioDetallePorIDDocumento(idDoc As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function GrabarLibro(documento As documento) As Integer

    <OperationContract()>
    Function ListaLibroContable(libroBE As documentoLibroDiario) As List(Of documentoLibroDiario)

    <OperationContract()>
    Function UbicarMovimientosXidDocumento(intIdAsiento As Integer) As List(Of movimiento)


    '    <OperationContract()> _
    '<CyclicReferencesAware(True)>
    '    Sub UpdateVentaNormalContado(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento)

#End Region

#Region "Empresa"
    <OperationContract()>
    Sub InsertarEmpresa(empresaBE As empresa, ListaMascaraContable2 As List(Of mascaraContable2), ListaCuentaMascara As List(Of cuentaMascara), ListamascaraGastosEmpresa As List(Of mascaraGastosEmpresa), ListacuentaplanContableEmpresa As List(Of cuentaplanContableEmpresa))

#End Region

#Region "TIPO CAMBIO"
    <OperationContract()>
    Function GetListaTipoCambioMaxFecha(idEmpresa As String, intIdEstablecimiento As Integer) As tipoCambio

    <OperationContract()>
    Function InsertTC(ByVal tipoCambioBE As tipoCambio) As Integer

    <OperationContract()>
    Sub EditarTC(ByVal tipoCambioBE As tipoCambio)

    <OperationContract()>
    Function GetListar_tipoCambio() As List(Of tipoCambio)

#End Region

#Region "CONFIGURACION DE INICIO POR EMPRESA"
    <OperationContract()>
    Sub InsertConfigInicio(configBE As configuracionInicio)

    <OperationContract()>
    Sub EditarConfigInicio(configBE As configuracionInicio)

    <OperationContract()>
    Sub EliminarConfigInicio(configBE As configuracionInicio)

    <OperationContract()>
    Function ObtenerConfigXempresa(strIdEmpresa As String, intIdEstaclecimiento As Integer) As configuracionInicio

#End Region

#Region "MASCARA CUENTAS POR MODULO"
    <OperationContract()>
    Function UbicarCuentaXmoduloXitem(strEmpresa As String, strParametro As String, strTipoItem As String, strModulo As String) As cuentaMascara

    <OperationContract()>
    Function UbicarEmpresaXmodulo(strEmpresa As String, strModulo As String) As List(Of cuentaMascara)
#End Region

#Region "MOVIMIENTOS"
    <OperationContract()>
    Function UbicarAsientoXidDocumento(intIdDocumento As Integer) As List(Of movimiento)

    <OperationContract()>
    Function RecuperarEstadoCierrePeriodo(strEmpresa As String, intIdEstablec As Integer, strPeriodo As String) As cierrecontable

    <OperationContract()> _
 _
    Sub AperturarPeriodo(strEmpresa As String, intIdEstablec As Integer, strPeriodo As String)

    <OperationContract()> _
 _
    Sub GrabarListaCierreCaja(lista As List(Of cierreCaja))

    <OperationContract()>
    Function GetObtenerCierreCajasModulos(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, intIdUser As String) As List(Of documentoCaja)

    <OperationContract()> _
 _
    Function GetObetnerCierrePorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer, anio As Integer, mes As String) As List(Of movimiento)

    <OperationContract()> _
 _
    Sub GrabarListaAsientos(lista As List(Of cierrecontable), asiento As asiento, documento As documento)

    <OperationContract()>
    Sub GrabarListaAsientosCierre(lista As List(Of cierrecontable))

    <OperationContract()> _
 _
    Sub UpdateListaAsientos(lista As List(Of cierrecontable))

    <OperationContract()> _
 _
    Function CierreCerrado(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As Boolean

    <OperationContract()>
    Function GetCargarCierrePorPeriodo(idEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of cierrecontable)
#End Region


#Region "SOLICITUDES"

#Region "ORDENES"

    <OperationContract()>
    Function GetUbicar_documentocompradetallePorCompraSL(strSerie As String, strNroDoc As String, strSitucion As String, intIdProveedor As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function SumaNotasXidPadreItem(intIdSecuencia As Integer) As documentocompradetalle

    <OperationContract()>
    Function SumaNotasXidPadreItemVentas(intIdSecuencia As Integer) As documentoventaAbarrotesDet

#Region "DOCUMENTO DATOS EXTRAS"
    <OperationContract()>
    Function UbicarDocumentoOtros(intIdDocumento As Integer) As documentoOtrosDatos

    <OperationContract()>
    Function UbicarDocumentoOtrosReferencia(intIdDocumento As Integer) As documentoOtrosDatos

    <OperationContract()>
    Sub UpdateDocOtros(idSolc As documentoOtrosDatos)

    <OperationContract()>
    Sub GrabarDatosEntregaOrdenesFull(ByVal documentoOtrosDatosBE As List(Of documentoOtrosDatos), intIdDocumento As Integer)

    <OperationContract()>
    Function UbicarDocumentoOtrosHistorialEntrega(intIdDocumento As Integer) As List(Of documentoOtrosDatos)

    <OperationContract()>
    Function DeleteSingleOC(intIdDocumento As Integer) As Boolean

    <OperationContract()>
    Sub GrabarDatosEntregaOrdenes(ByVal documentoOtrosDatosBE As documentoOtrosDatos, ByVal documentoCompraDeatlle As documentocompradetalle)

    <OperationContract()>
    Sub GrabarDatosEntregaOrdeneCompra(ByVal documentoOtrosDatosBE As documentoOtrosDatos, ByVal intidDocumento As Integer)

#End Region

    <OperationContract()>
    Function GetListarOrdenCompraPorDia(intIdEmpresa As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarOrdenServicioPorDia(intIdEmpresa As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarOrdenServicio(intIdEmpresa As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarOrdenCompra(intIdEmpresa As String) As List(Of documentocompra)
#End Region

    <OperationContract()> _
 _
    Function ObtenerPersona(PersonaBE As Persona) As List(Of Persona)

    <OperationContract()> _
 _
    Sub UpdateDoc(idSolc As documentocompra)

    <OperationContract()> _
 _
    Sub UpdateOrdenCompra(idSolc As documentocompradetalle, strTipoDoc As String)

    <OperationContract()> _
 _
    Function SaveDocumentoCompraSolicitud(nDocumento As documento) As Integer

    <OperationContract()>
    Function GrabarOrdenes(objDocumento As documento, objOtroDoc As documentoOtrosDatos) As Integer

    <OperationContract()> _
 _
    Sub EstadoSoli(idSolc As documentocompra)

    <OperationContract()>
    Function GetListarSolicitudesCompra(intIdEmpresa As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarSolicitudesCompraDia(intIdEmpresa As String) As List(Of documentocompra)

#End Region
#Region "CONFIGURACION DEL SISTEMA"
    <OperationContract()>
    Function TieneConfiguracionComprobante(strIdEmpresa As String, strIdModulo As String) As Boolean

    <OperationContract()>
    Function UbicarModuloPorCodigo(strIdModulo As String) As moduloApp

    <OperationContract()>
    Function UbicarConfiguracionPorID(intIdConfig As Integer) As moduloConfiguracion

    <OperationContract()>
    Function UbicarConfiguracionPorEmpresaModulo(strIdModulo As String, strIdEmpresa As String, intIdEstablecimiento As Integer) As moduloConfiguracion

    <OperationContract()>
    Function ListaModulos() As List(Of moduloApp)

    <OperationContract()>
    Function ListaModulosConfigurados(moduloConfiguracionBE As moduloConfiguracion) As List(Of moduloConfiguracion)

    <OperationContract()>
    Function GrabarConfigSistema(objConfiguracion As moduloConfiguracion) As Integer

    <OperationContract()>
    Function UpdateConfigSistema(objConfiguracion As moduloConfiguracion) As Integer

    <OperationContract()>
    Sub EliminarConfigSistema(objConfiguracion As moduloConfiguracion)

#End Region

#Region "TRIBUTOS OBLIGACIONES"
    <OperationContract()>
    Function UbicarDetallePorTributo(intIdDocumento As Integer) As List(Of documentoObligacionDetalle)

    <OperationContract()>
    Function ExistenDatosDetalleObligacion(intIdDocumentoOrigen As Integer) As Boolean

    <OperationContract()> _
 _
    Function SaveObligacion(objDocumento As documento, intIdDocumentoOrigen As Integer) As Integer

    <OperationContract()> _
 _
    Sub UpdateTributo(objDocumento As documento, intIdDocumentoOrigen As Integer)

    <OperationContract()>
    Function UbicarDocumentoObligacion(intIdDocumento As Integer) As documentoObligacionTributaria

    <OperationContract()>
    Function ListadoTributoPorIdDocumentoOrigen(intIdDocumentoOrigen As Integer) As List(Of documentoObligacionTributaria)

    <OperationContract()>
    Function UbicarTributoPorIdDocumentoCompra(intIdDocumento As Integer) As documentoObligacionTributaria

    <OperationContract()>
    Sub EliminarObligacion(intIdDocumento As Integer)

    <OperationContract()>
    Sub EliminarObligacionPercepcion(intIdDocumento As Integer, intIdDocumentoTributo As Integer)

#End Region

#Region "Reportes"
    <OperationContract()>
    Function GetListarComprasPorAnio(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorAnioEmpresa(empresa As String, anio As String) As List(Of documentocompra)

    <OperationContract()>
    Function CompensacionDocCompraAnticipo(objDocumento As documento, objDoc As documento) As Integer

    <OperationContract()>
    Function SaveOtrasSalidasProduccion(objDocumento As documento) As Integer

    <OperationContract()>
    Sub GrabarSalidaProduccion(objDocumento As documento)

    <OperationContract()>
    Function ListaRecursosGastoEntregable(compraBE As documentocompra, idEntregable As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetListarComprasPorANioGeNeral(intIdEstablecimiento As Integer, strANio As String) As List(Of documentocompra)


    <OperationContract()>
    Function GetListarComprasPorDiaReporte(intIdEstablecimiento As Integer, fechaDia As Date) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorPeriodoReporte(intIdEstablecimiento As Integer,
                                              strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarMvimientosCajaPorDiaReporte(intIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Function GetListarMvimientosCajaPorPeriodoReporte(strEmpresa As String, intIdEstablecimiento As Integer,
                                              strPeriodo As String) As List(Of documentoCaja)

    <OperationContract()>
    Function GetListarMvimientosAlmacenPorDiaReporte(intIdEstablecimiento As Integer, strTipoCompra As String) As List(Of documentocompra)

    <OperationContract()>
    Function OntenerListadoComprasPorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer,
                                              strPeriodo As String) As List(Of documentocompra)
    <OperationContract()>
    Function ObtenerAsientosPorPeriodoFullReporte() As List(Of asiento)

    <OperationContract()>
    Function UbicarReporteAsientoPorDocumento(intIdDocumento As Integer) As List(Of asiento)

    <OperationContract()>
    Function UbicarReporteAsientoPorEntidad(intidEntidad As Integer) As List(Of asiento)

    <OperationContract()>
    Function UbicarReporteAsientoPorTipo(srtidTipo As String) As List(Of asiento)

    <OperationContract()>
    Function UbicarReporteAsientoPorFecha(srtFechaInicio As Date, srtFechaHasta As Date, srtidTipo As String) As List(Of asiento)

    <OperationContract()>
    Function UbicarReporteAsientoPorPeriodo(srtFechaAnio As String, srtFechaMes As String) As List(Of asiento)

    <OperationContract()>
    Function UbicarReporteAsientosPorPeriodoFull(srtFechaAnio As Integer) As List(Of asiento)

    <OperationContract()>
    Function UbicarReporteAsientoPorAcumulado(dtpDesdeAnio As Date, dtphastaAnio As Date) As List(Of asiento)

    <OperationContract()>
    Function BuscarHojaTrabajoFinalFullReporte(strPeriodo As Integer) As List(Of movimiento)

    <OperationContract()>
    Function BuscarHojaTrabajoFinalPorMesReporte(strPeriodo As String, intMes As String) As List(Of movimiento)

    <OperationContract()>
    Function BuscarHojaTrabajoFinalPorAcumuladoReporte(strFechaDesde As Date, strFechaHasta As Date) As List(Of movimiento)

    <OperationContract()>
    Function GetUbicarMovimientoLibroMayorFullMensual(strPeriodo As List(Of String), periodo As String, mesPer As String) As List(Of movimiento)

    <OperationContract()>
    Function GetUbicarMovimientoLibroMayorFull(strPeriodo As List(Of String), periodo As String) As List(Of movimiento)

    <OperationContract()>
    Function GetUbicarMovimientoLibroMayorPorIdDocumento(strCuenta As String) As List(Of movimiento)

    <OperationContract()>
    Function BuscarInformePorClaseReporte(strCuenta As String, anio As String) As List(Of movimiento)

    <OperationContract()>
    Function BuscarInformePorClaseAcumuladoReporte(strFechaDesde As Date, strFechaHasta As Date, strCuenta As String) As List(Of movimiento)

    <OperationContract()>
    Function BuscarInformePorClaseMesReporte(strPeriodo As String, intMes As String, strCuenta As String) As List(Of movimiento)

    <OperationContract()>
    Function BuscarInformePorCuentaContableReporte(strCuenta As String, strRazonSocial As String) As List(Of movimiento)

    'martin
    <OperationContract()>
    Function OntenerListadoComprasPorEmpresa(strEmpresa As String,
                                              strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function OntenerListadoComprasConBonificacion(strEmpresa As String, intIdEstablecimiento As Integer,
                                              strPeriodo As String) As List(Of documentocompradetalle)


    <OperationContract()>
    Function OntenerListadoComprasPorProveedor(strEmpresa As String, intIdProveedor As Integer,
                                              strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function OntenerListadoComprasPorProveedorEstablec(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer,
                                              strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function OntenerListadoVentasAbarrotes(strEmpresa As String, intIdEstablecimiento As Integer,
                                              strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function OntenerListadoVentasAbarrotesPorDia(strEmpresa As String, intIdEstablecimiento As Integer,
                                              strTipoCompra As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function OntenerListadoVentasAbarrotesEmpresa(strEmpresa As String,
                                              strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function OntenerListadoVentasAbarrotesPorCliente(strEmpresa As String, intIdEstablecimiento As Integer,
                                              strPeriodo As String, intIDcliente As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function OntenerListadoComprasPorAportacionesPorDia(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentocompra)

    <OperationContract()>
    Function OntenerListadoComprasPorAportaciones(strEmpresa As String, intIdEstablecimiento As Integer,
                                              strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function OntenerListadoComprasAportacionesPorEmpresa(strEmpresa As String,
                                              strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function OntenerListadoComprasAportacionesProveedor(strEmpresa As String, intIdProveedor As Integer,
                                              strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function OntenerListadoComprasAportacionesPorProveedorEstablec(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer,
                                              strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function ObtenerProdPorAlmacenesPeriodoRPT(ByVal idAlmacen As String, ByVal strItem As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerKardexPorAlmacenAnio(ByVal idAlmacen As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerKardexPorAlmacenMes(ByVal idAlmacen As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ReporteKardexPorProducto(ByVal idAlmacen As String, iNtProducto As Integer, ByVal fecDesde As DateTime, ByVal fecHasta As DateTime) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerKardexPorAlmacenDia(ByVal idAlmacen As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerProdPorAlmacenesPorAnio(ByVal idAlmacen As String, ByVal strItem As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerProdPorAlmacenesPorAnioAll(ByVal idAlmacen As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerProdPorAlmacenesDiaRPT(ByVal idAlmacen As String, ByVal strItem As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerProrAlmacenesPeriodoRPT(intIdAlmacen As Integer, strTipoEx As Integer, strBusqueda As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function ObtenerCajaOnlineRPT(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlineAcumuladoRPT(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlineDiaRPT(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)

    'Cajas

    <OperationContract()>
    Function ResumenTransaccionesXusuarioCajaReporte(be As cajaUsuario) As List(Of cajaUsuario)
#End Region

#Region "APORTES" '
    <OperationContract()> _
 _
    Function SaveAporteExistencia(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer

    <OperationContract()>
    Function GetListarAportesPorPeriodo(strPeriodo As String) As List(Of documentocompra)

    <OperationContract()> _
 _
    Sub DeleteAporte(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
#End Region

#Region "PERIODOS POR EMPRESA"
    <OperationContract()>
    Function GetListar_empresaPeriodo(empresaPeriodoBE As empresaPeriodo) As List(Of empresaPeriodo)

    <OperationContract()>
    Function InsertarPeriodo(ByVal empresaPeriodoBE As empresaPeriodo) As Integer

#End Region

#Region "USUARIOS CAJA"
    <OperationContract()> _
 _
    Function CerrarCajaUsuario(nCajaUsuario As cajaUsuario, nDocumento As documento) As cajaUsuario

    <OperationContract()> _
 _
    Sub AperturarCajaUsuario(nCajaUsuario As cajaUsuario, nDocumento As documento)

    <OperationContract()> _
 _
    Sub EliminarCajaUsuarioFull(ByVal cajaUsuarioBE As cajaUsuario)

    <OperationContract()>
    Function UbicarCajaUsuarioPorID(intIdCajaUsuario As Integer) As cajaUsuario

    <OperationContract()>
    Function UbicarCajaUsuarioAbierto(intIdCajaUsuario As Integer, strEstado As String) As cajaUsuario

    <OperationContract()>
    Function ListaDetallePorCaja(intIdCajaUsuario As Integer) As List(Of cajaUsuariodetalle)

    <OperationContract()>
    Function ListaDetalleUsuarioXUsuario(be As cajaUsuario) As List(Of cajaUsuariodetalle)

    <OperationContract()>
    Function UbicarCajaAsignadaUser(strNumDocUser As String, strEstadoCaja As String, InUso As String,
                                    strClave As String) As cajaUsuario


    <OperationContract()>
    Function ListaDetalleUsuarioXEntidades(be As cajaUsuario) As List(Of cajaUsuariodetalle)

    <OperationContract()>
    Function InsertUsuarioCaja(cajaUsuarioBE As cajaUsuario) As Integer

    <OperationContract()>
    Sub EditarUsuarioCaja(cajaUsuarioBE As cajaUsuario)

    <OperationContract()>
    Sub EliminarUsuarioCaja(cajaUsuarioBE As cajaUsuario)

    <OperationContract()>
    Function ListarPorCaja(intIdCaja As Integer) As List(Of cajaUsuario)

    <OperationContract()>
    Function ListarPorCajaPorPeriodo(intIdCaja As Integer, strPeriodo As String) As List(Of cajaUsuario)

    <OperationContract()>
    Function ListaCajasHabilitadas(strIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of cajaUsuario)

    <OperationContract()>
    Function UbicarCajasHijasXpadre(iNtIdPadre As Integer) As List(Of cajaUsuario)

    <OperationContract()>
    Function UbicarCajasHijasFull(ListadoPadres As List(Of Integer)) As List(Of cajaUsuario)

    <OperationContract()>
    Sub CerrarAbrirCajaSubUsuario(nCajaUsuario As cajaUsuario)

    <OperationContract()>
    Sub HabilitarUsoDeCajaUser(ByVal cajaUsuarioBE As cajaUsuario)

    <OperationContract()>
    Function GetListAllCompras(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
#End Region

#Region "ASIENTOS CONTABLES"
    <OperationContract()>
    Sub DeletePorIdAsiento(ByVal intIdAsiento As Integer)

    <OperationContract()>
    Function UbicarAsientoPorIDAsiento(intIdAsiento As Integer) As asiento

    <OperationContract()>
    Sub UpdateGroupCajaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario))


    <OperationContract()>
    Function ValidarCajaXUsuario(intIdPersona As Integer) As cajaUsuario

    <OperationContract()>
    Function ObtenerCajaUser(ByVal intIdCaja As Integer) As cajaUsuario

    <OperationContract()>
    Function UbicarCajaUsuarioXID(ByVal intIdCaja As Integer) As cajaUsuario

    <OperationContract()>
    Function UbicarCajaXPersona(intPersona As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer

    <OperationContract()>
    Function UbicarCajaXIdEntidadOrigen(intEntidadFinan As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer

    <OperationContract()>
    Function UbicarAsientoPorDocumento(intIdDocumento As Integer) As List(Of asiento)

    <OperationContract()>
    Function UbicarAsientoPorEntidad(intidEntidad As Integer) As List(Of asiento)

    <OperationContract()>
    Function UbicarAsientoPorTipo(srtidTipo As String) As List(Of asiento)

    <OperationContract()>
    Function UbicarAsientoPorFecha(srtFechaInicio As Date, srtFechaHasta As Date, srtidTipo As String) As List(Of asiento)

    <OperationContract()>
    Function UbicarAsientoPorPeriodo(srtFechaMes As Date, srtFechaAnio As Date, strAprobado As String) As List(Of asiento)

    <OperationContract()>
    Function UbicarMovimientoPorAsiento(intIdAsiento As Integer) As List(Of movimiento)

    <OperationContract()>
    Function BuscarMovimientosFull(strPeriodo As Integer) As List(Of movimiento)

    <OperationContract()>
    Function BuscarMovimientosPorMes(strPeriodo As Integer, intMes As Integer) As List(Of movimiento)

    <OperationContract()>
    Function BuscarMovimientosPorAcumulado(strFechaDesde As Date, strFechaHasta As Date) As List(Of movimiento)

    <OperationContract()>
    Function GetUbicarMovimiento(strCuenta As String) As List(Of movimiento)

    <OperationContract()>
    Function GetUbicarDocumentoDetallePorIdDocumento(strCuenta As String) As List(Of movimiento)

#End Region

#Region "CAJA ONLINE"
    <OperationContract()>
    Function ConsultaEstadoPago(intIDDOcumentoCompra As Integer) As documentoCajaDetalle

    <OperationContract()>
    Function VerificarConciliarCheque(objDocCaja As documentoCaja) As Boolean

    <OperationContract()> _
 _
    Sub ConciliarCheque(objDocCaja As documentoCaja, objDocumentoBE As documento, cajaUsuario As cajaUsuario)

    <OperationContract()> _
 _
    Function ListaChequesPorProveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String) As List(Of documentoCaja)

    <OperationContract()>
    Function ListaChequesPendientesXProveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String) As Integer

    <OperationContract()>
    Function ListaComprasPendientesXproveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer) As Integer

    <OperationContract()>
    Sub EditarEstadoCompra(intIdDocumento As Integer, strEstadoPago As String)


    <OperationContract()>
    Function GetListarComprasPorProveedorCaja(intIdEstable As Integer, intIdProveedor As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasNotaCreditoPorProveedorCaja(intIdEstable As Integer, intIdProveedor As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function ObtenerCajasMovimientosPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCaja)

    <OperationContract()>
    Function UbicarUltimaFechaPago(intIdDocumento As Integer) As DateTime

    <OperationContract()>
    Function ObtenerMovimientosPorPeriodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerMovimientosPorDia(strIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoCaja)

    <OperationContract()> _
 _
    Sub EliminarTransferenciaCaja(ByVal documentoBE As documento)

    <OperationContract()> _
 _
    Sub EliminarOtrosMovimientosCaja(ByVal documentoBE As documento)

#Region "DOCUMENTO CAJA"
    <OperationContract()>
    Function ObtenerPagosPorPeriodo(strPeriodo As String) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerPagosPorPeriodoporEstablecimiento(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerCajaOnline(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlinePOS(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlineXIdCaja(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strperiodo As String, ByVal strEntidadFinanciera As String, idCaja As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlineConTramiteDoc(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlineConTramiteDocPOS(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlineXDocumento(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlineXDocumentoConTramiteDoc(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlineXDocumentoXId(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, idCaja As Integer) As List(Of documentoCaja)


    <OperationContract()>
    Function GetUbicar_documentoCajaPorID(idDocumento As Integer) As documentoCaja


    <OperationContract()>
    Function RecuperarIDCompra(intIdDocumentoCompra As Integer) As Integer

    <OperationContract()>
    Function GetUbicar_DetallePorIdDocumento(intIdDocumento As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function GetUbicar_DetalleXdocumentoAfectado(docAfectado As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()> _
 _
    Sub EditarGroupCaja(objDocumentoBE As documento)

#End Region

    <OperationContract()>
    Function SumaCobroPorDocumento(intIdEstable As Integer, strTipoDoc As String,
                                          strFiltro As String) As documentoCajaDetalle

    <OperationContract()>
    Function SumaCobroPorDocumentoPagos(intIdEstable As Integer, strTipoDoc As String,
                                       strFiltro As String, strSerie As String) As documentoCajaDetalle

    <OperationContract()>
    Function SumaCobroPorCliente(intIdEstable As Integer, strFiltro As String, strPeriodo As String) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function SumaCobroPorModulo(intIdEstable As Integer, strFiltro As String, strPeriodo As String, strTipoModuloVenta As String) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function SumaPagosPorProveedor(intIdEstable As Integer, strFiltro As String, strPeriodo As String) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function SumaPagosPorIdDocumentoCompra(intIdDocumento As Integer) As documentoCajaDetalle

    <OperationContract()> _
 _
    Function SaveGroupCajaNotas(objDocumentoBE As documento) As Integer

    <OperationContract()> _
 _
    Function SaveGroupCaja(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer

    <OperationContract()> _
 _
    Function SaveGroupCajaVentas(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer

    <OperationContract()>
    Function GrabarExcedenteCompra(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer

    <OperationContract()>
    Function GrabarExcedenteVenta(objDocumentoBE As documento) As Integer

    <OperationContract()> _
 _
    Function SaveGroupCajaPrestamo(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer

    <OperationContract()> _
 _
    Function SaveGroupCajaNotacredito(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer

    <OperationContract()> _
 _
    Function SaveGroupCajaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer


    <OperationContract()> _
 _
    Function SaveGroupCajaGeneralApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer


    <OperationContract()> _
 _
    Function SaveCajaAperturaUsuarioPc(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer

    <OperationContract()> _
 _
    Function SaveCajaAdministrativaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer


    <OperationContract()> _
 _
    Sub SaveGroupCajaOtrosMovimientos(objDocumentoBE As documento)

    <OperationContract()> _
 _
    Function SaveGroupCajaOtrosMovimientosSingle(objDocumentoBE As documento) As Integer

    <OperationContract()> _
 _
    Sub UpdateGroupCajaOtrosMovimientosSingle(objDocumentoBE As documento)

    <OperationContract()> _
 _
    Sub SaveCajaExcedente(objDocumentoBE As documento)

    <OperationContract()>
    Function ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerCuentasPorPagarPorDetailsME(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerCuentasPorPagarPorDetailsVentas(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerHistorialPagos(intIdDocumentoCompra As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerHistorialPagosPorIdPago(intIdDocumentoPago As Integer) As documentoCajaDetalle

    <OperationContract()>
    Function ObtenerPagosDelDia() As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerPagosDelDiaPorEstablecimiento(intIdEstablecimiento As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Sub EliminarDocumentoCaja(ByVal documentoBE As documento)

    <OperationContract()>
    Sub EliminarPagoPrestamo(ByVal documentoBE As documento)

    <OperationContract()>
    Function ObtenerCajaDetalleME(ByVal montoUSD As Decimal, intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerCajaDetalle(ByVal montoUSD As Decimal, intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle)

#End Region

#Region "PRESTAMOS"
    <OperationContract()>
    Function PrestamoEstadoAprobado(intCodigo As Integer) As Boolean

    <OperationContract()>
    Function ObtenerPrestamosXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String, strTipoPrestamo As String) As List(Of prestamos)

    <OperationContract()>
    Function ObtenerHistorialPagoPrestamoXCuota(intIdCuota As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function UbicarPrestamoXcodigoSingle(intIdDocumento As Integer) As prestamos

    <OperationContract()>
    Function ObtenerPagosAcumPrestamos(strDocumentoAfectado As Integer, srtTipoCobro As String) As List(Of documentoCajaDetalle)

    '<OperationContract()> _
    'Function ListadoPrestamosPendientes(strEmpresa As String, intIdEstablecimiento As Integer, intIdBeneficiario As Integer, strPeriodo As String, strTipoMovimiento As String) As List(Of documentoPrestamos)

    <OperationContract()>
    Function UbicarPrestamoXcodigo(intCodigo As Integer) As prestamos

    <OperationContract()>
    Function ObtenerPrestamos(ByVal strIdEmpresa As String, ByVal strEstado As String, strTipoPrestamo As String) As List(Of prestamos)

    <OperationContract()>
    Function SavePrePrestamo(prestamosBE As prestamos) As Integer

    <OperationContract()>
    Sub EditarPrePrestamo(prestamosBE As prestamos)

    <OperationContract()>
    Sub EliminarPrePrestamo(prestamosBE As prestamos)

    <OperationContract()>
    Sub EliminarPrestamoAprobado(prestamosBE As prestamos)

    <OperationContract()>
    Function UbicarPrestamoXcodigoDefault(intCodigo As Integer) As prestamos

    <OperationContract()> _
 _
    Sub InsertPrestamoOtorgado(documentoBE As documento, listaDocumentos As List(Of documentoPrestamos), listaDetalle As List(Of documentoPrestamoDetalle))

#End Region

#Region "NUMERACION BOLETA"
    <OperationContract()>
    Function ObtenerDocumentoPorEstablecimiento(intIdEstablecimiento As Integer, ByVal strSerie As String,
                                                 strcodigoNumeracion As String, strTipo As String) As numeracionBoletas


#Region "EMPRESA SERIE"
    <OperationContract()>
    Function obtenerSeriePorEEmpresa(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer) As List(Of EmpresaSeries)

    <OperationContract()>
    Sub InsertEmpresaSerie(ByVal EmpresaSeriesBE As EmpresaSeries)

    <OperationContract()>
    Sub EditarEmpresaSerie(ByVal EmpresaSeriesBE As EmpresaSeries)

    <OperationContract()>
    Sub DeleteEmpresaSerie(ByVal EmpresaSeriesBE As EmpresaSeries)

#End Region
    <OperationContract()>
    Function ObtenerAncladosPorComprobante(strIdEmpresa As String, intIdEstablecimiento As Integer, strComprobante As String) As List(Of numeracionBoletas)

    '<OperationContract()> _
    'Function ObtenerNumeracionPredterminada(strIdEmpresa As String, intIdEstablecimiento As Integer, strComprobante As String, strTipoDoc As String) As numeracionBoletas

    <OperationContract()>
    Function ObtenerNumeracionPredterminada(strIdEmpresa As String, intIdEstablecimiento As Integer, strTipoDoc As String) As numeracionBoletas

    <OperationContract()>
    Function ObtenerNumeracionEES(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strSerie As String) As List(Of numeracionBoletas)

    <OperationContract()>
    Function InsertNumBoletas(ByVal numeracionBoletasBE As numeracionBoletas) As Integer

    <OperationContract()>
    Function InsertNumeracionXAreaOperativa(ByVal numeracionBoletasBE As distribucionNumeracionAO) As Integer

    <OperationContract()>
    Function InsertAreaOperativaNumeracion(ByVal numeracionBoletasBE As distribucionNumeracionAO) As Integer

    <OperationContract()>
    Function InsertListaNumeracionAo(conItem As List(Of distribucionNumeracionAO)) As Integer

    <OperationContract()>
    Function ObtenerSeriesPorModulo(intIdEstablecimiento As Integer, strModulo As String) As List(Of numeracionBoletas)

    <OperationContract()>
    Sub EditarNumBoletas(ByVal numeracionBoletasBE As numeracionBoletas)

    <OperationContract()>
    Sub EliminarNumBoletas(ByVal numeracionBoletasBE As numeracionBoletas)

    <OperationContract()>
    Sub UpdatePredeterminadoAll(nNumeracionBE As numeracionBoletas)

    <OperationContract()>
    Function GetTieneConfiguracion(strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strSerie As String) As Boolean

    <OperationContract()>
    Function GetUbicar_numeracionBoletasPorID(IdEnumeracion As Integer) As numeracionBoletas

    <OperationContract()>
    Function GetUbicar_numeracionBoletasXUnidadNegocio(numeracionBoletasBE As numeracionBoletas) As numeracionBoletas

    <OperationContract()>
    Function NumeracionBoletasSelV2(intIdEstablecimiento As Integer,
                                         strcodigoNumeracion As String, strTipo As String, idCargo As Integer) As numeracionBoletas
#End Region

#Region "ESTADOS FINANCIEROS"
    <OperationContract()>
    Function ObtenerEFPorCuentaFinanciera(estadosFinancierosBE As estadosFinancieros) As List(Of estadosFinancieros)

    <OperationContract()>
    Function ObtenerEstadosFinancierosPorTipo(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String) As List(Of estadosFinancieros)

    <OperationContract()>
    Sub DeleteEF(ByVal estadosFinancierosBE As estadosFinancieros)

    <OperationContract()>
    Function InsertEF(ByVal estadosFinancierosBE As estadosFinancieros) As Integer

    <OperationContract()>
    Function InsertEFDoc(ByVal estadosFinancierosBE As estadosFinancieros, docume As documento) As Integer

    <OperationContract()>
    Function GrabarEFApertura(ByVal estadosFinancierosBE As estadosFinancieros, docume As documento) As Integer

    <OperationContract()>
    Sub UpdateEF(ByVal estadosFinancierosBE As estadosFinancieros)

    <OperationContract()>
    Sub UpdateEFDoc(ByVal estadosFinancierosBE As estadosFinancieros, Optional docume As documento = Nothing)

    <OperationContract()>
    Sub DeleteEntidadFinancieraReferencia(ByVal estadosFinancierosBE As estadosFinancieros)

    <OperationContract()>
    Function ObtenerEstadosFinancierosPorMoneda(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, ByVal strMoneda As String) As List(Of estadosFinancieros)

    <OperationContract()>
    Function GetUbicar_estadosFinancierosPorID(idestado As Integer) As estadosFinancieros

    <OperationContract()>
    Function ObtenerEstadosFinancierosPredeterminado(intIdEstablecimiento As Integer) As estadosFinancieros

    <OperationContract()>
    Function ObtenerEstadosFinancierosPorCodigo(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strCodigo As Integer) As estadosFinancieros

    <OperationContract()>
    Function GetEstadoSaldoEFME(idestado As Integer, fechaProceso As DateTime) As estadosFinancieros

    <OperationContract()>
    Function ObtenerEFPorCuentaFinancieraDestino(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, cuentaOrigen As Integer, tipoMo As Integer) As List(Of estadosFinancieros)

    <OperationContract()>
    Function GetEstadoCajasInformacionGeneral(be As documentoCaja, listaPersona As List(Of String), tipo As String, fechaIncio As DateTime, fechaFin As DateTime, intAnio As Integer, intMes As Integer, strEmpresa As String, idEstablec As Integer, intDia As Integer) As List(Of estadosFinancieros)


#End Region

#Region "ALMACÉN"

    <OperationContract()>
    Function GetUbicar_proveedorPorIdItem(stridEmpresa As String, intIdEstablec As Integer, intIdItem As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetUbicar_OrdenCompraHistorial(idDocumento As Integer, situacion As String) As List(Of documentocompradetalle)

    <OperationContract()>
    Sub UpdateFullDocOrden(ByVal idDocumento As Integer, ByVal strSituacion As String)


#Region "NUEVO METODO DE PRECIOS"
    <OperationContract()>
    Function ListarPreciosXproductoMaxFecha(ByVal intIdAlmacen As Integer, intIdItem As Integer) As List(Of configuracionPrecioProducto)

    <OperationContract()>
    Sub GrabarListadoPrecios(listaProductos As List(Of configuracionPrecioProducto))

    <OperationContract()>
    Sub GrabarPrecio(Producto As List(Of configuracionPrecioProducto))

    <OperationContract()>
    Function ListadoPrecios() As List(Of configuracionPrecio)

    <OperationContract()>
    Function EncontrarPrecioXitem(configBE As configuracionPrecio) As configuracionPrecio
#End Region

#Region "LISTADO DE PRECIOS"
    <OperationContract()>
    Sub DeleteProductoAllReferences(ByVal ProductoBE As detalleitems)

    <OperationContract()>
    Function UbicarPVxItem(ByVal intIdAlmacen As Integer, intIdItem As Integer) As listadoPrecios

    <OperationContract()>
    Function UbicarPVxListadoItems(ByVal intIdAlmacen As Integer) As List(Of listadoPrecios)

    <OperationContract()>
    Function InsertarPrecioVV(ByVal listadoPreciosBE As listadoPrecios) As Integer

    <OperationContract()>
    Function PrecioVentaXitemXiva(ByVal intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As listadoPrecios

    <OperationContract()>
    Function UbicarVentaPorItem(ByVal intIdAlmacen As Integer, intIdItem As Integer) As listadoPrecios

    <OperationContract()>
    Function UbicarVentaPorItemCSIVA(ByVal intIdAlmacen As Integer, intIdItem As Integer) As List(Of listadoPrecios)

    <OperationContract()>
    Function UbicarVentaPorItemCSIVASL(ByVal intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As listadoPrecios

    <OperationContract()>
    Function UbicarPrecioNuevo(ByVal intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As Decimal

    <OperationContract()>
    Function ObtenerPrecioPorItem(intIdAlmacen As Integer, intIdItem As Integer) As List(Of listadoPrecios)

    <OperationContract()>
    Function ObtenerPrecioPorItemSL(intIdAlmacen As Integer, intIdItem As Integer, strTipoIVA As String) As List(Of listadoPrecios)

    <OperationContract()>
    Function ObtenerPrecioPorIdAlmacen(intIdAlmacen As Integer) As List(Of listadoPrecios)

    <OperationContract()>
    Sub InsertListadoPrecio(ByVal listadoPreciosBE As listadoPrecios)

    <OperationContract()>
    Sub InsertListadoPrecioSL(ByVal listadoPreciosBE As List(Of listadoPrecios))

    <OperationContract()>
    Sub EditarListadoPrecio(ByVal listadoPreciosBE As listadoPrecios)

    <OperationContract()>
    Sub EliminarListadoPrecio(ByVal listadoPreciosBE As listadoPrecios)

    <OperationContract()>
    Function UltimasEntradasPorFecha(strEmpresa As String, intIdEstablecimiento As Integer, intAlnacenConsulta As Integer, IntIdItem As String) As List(Of documentocompradetalle)


#End Region

    <OperationContract()>
    Function ObtenerCanastaDeVenta(ByVal intIdAlmacen As Integer, ByVal strTipoExistencia As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function ObtenerCanastaDeVentaPorProducto(ByVal intIdAlmacen As Integer, ByVal strTipoExistencia As String,
                                                   strFiltroProducto As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetUbicar_InventarioMovimientoCompra(idDocumento As Integer, strTipoRegistro As String) As InventarioMovimiento

    <OperationContract()>
    Function GetMovimientosKardexByMesAllAlmacenXusuario(be As InventarioMovimiento, listaUsuario As List(Of String), tipo As String, periodo As String, fechainicio As DateTime, fechaFin As DateTime) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetMovimientosKardexByMesXusuario(be As InventarioMovimiento, listaUsuario As List(Of String), tipo As String, periodo As String, fechainicio As DateTime, fechaFin As DateTime) As List(Of InventarioMovimiento)


    <OperationContract()>
    Function GetUbicarProductoTAlmacen(intIdAlmacen As Integer, intIdItem As Integer) As totalesAlmacen

    <OperationContract()>
    Function ObtenerProdPorAlmacenes(ByVal idAlmacen As String, ByVal strItem As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerProdPorAlmacenesXdiaAll(ByVal idAlmacen As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerItemsPorAlmacen(ByVal idAlmacen As Integer) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetListaProductosPorAlmacen(intIdAlmacen As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListaProductosPorAlmacenPorCategoria(intIdAlmacen As Integer, intCategoria As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListaProductosPorAlmacenSinCategoria(intIdAlmacen As Integer, intCategoria As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetUbicarProductoXdescripcion2(ByVal idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String, strBusqueda As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetProductoPorTipoExistencia(intIdAlmacen As Integer, strTipoEx As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetProductosXempresa(be As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListaProductosTAPorProducto(intIdAlmacen As Integer, strBusqueda As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListaProductosTAPorProductoByTake(intIdAlmacen As Integer, strBusqueda As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetNotificacionAlmacen() As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetProductoPorAlmacenTipoEx(intIdAlmacen As Integer, strTipoEx As String, strBusqueda As String) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListadoProductosParaVentaXbarCode(objTotalBE As totalesAlmacen) As totalesAlmacen

    <OperationContract()>
    Function GetListadoProductosParaVentaXproducto(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListadoProductosParaVentaXproductoEmpresa(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListadoProductosParaVentaXproductoEmpresaFull(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)


    <OperationContract()>
    Function GetListadoProductosParaVentaXproductoXAlmacen(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListadoProductosParaVentaXproductoXAlmacenFull(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)


    <OperationContract()>
    Function GetUbicarTotalesAlmacen(strIdEmpresa As String, intIdEstablecimiento As Integer, strIdAlmacen As Integer) As List(Of totalesAlmacen)

    <OperationContract()> _
 _
    Function ObtenerProductosEnTransito(ByVal strIdEmpresa As String, ByVal strIdEstablecimiento As String, ByVal strTipoAlmacen As String, ByVal Mes As String, ByVal Anio As String, ByVal strTipoProducto As String) As List(Of InventarioMovimiento)

    <OperationContract()> _
 _
    Function ObtenerProductosEnTransitoPorDocumento(ByVal strIdEmpresa As String, ByVal strIdEstablecimiento As String, ByVal strTipoAlmacen As String, ByVal Mes As String, ByVal Anio As String, ByVal strTipoProducto As String,
                                                          strNumDocCompra As String) As List(Of InventarioMovimiento)

    <OperationContract()> _
 _
    Function GetListar_almacenExceptAV(almacenBE As almacen) As List(Of almacen)

    <OperationContract()>
    Function GetListar_almacenALL(idEmpresa As String) As List(Of almacen)

    <OperationContract()>
    Function GetListar_almacenes(intIdEstablecimiento As Integer) As List(Of almacen)

    <OperationContract()>
    Function GetUbicar_almacenPredeterminado(intIdEstablecimiento As Integer) As almacen

    <OperationContract()> _
 _
    Sub InsertItemsEnTransito(ByVal objSalida As List(Of InventarioMovimiento),
                              ByVal objEntrada As List(Of InventarioMovimiento),
                              ByVal listaAsiento As List(Of asiento),
                              ByVal objTotalesAlmacen As List(Of totalesAlmacen), documento As documento, totalesAlmAV As List(Of Business.Entity.totalesAlmacen))

    <OperationContract()> _
 _
    Sub InsertItemsEnTransitoSL(ByVal objSalida As List(Of InventarioMovimiento),
                              ByVal objEntrada As List(Of InventarioMovimiento),
                              ByVal listaAsiento As List(Of asiento),
                              ByVal objTotalesAlmacen As List(Of totalesAlmacen), documento As documento, totalesAlmAV As List(Of Business.Entity.totalesAlmacen),
                              ByVal objListaPrecios As List(Of listadoPrecios))



    <OperationContract()>
    Function GetUbicar_almacenPorID(idAlmacen As Integer) As almacen

    <OperationContract()>
    Function GetUbicar_almacenVirtual(intIdEstablecimiento As Integer) As almacen

    <OperationContract()> _
 _
    Sub InsertNuevaAlmacen(lista As almacen)

    <OperationContract()> _
 _
    Sub UpdateNuevaAlmacen(lista As almacen)

    <OperationContract()> _
 _
    Sub DeleteNuevoAlmacen(ByVal almacenBE As almacen)

    <OperationContract()>
    Function GetEsAlmacenVirtualXFull(strIdempresa As String, intIdEstblec As Integer, intTipo As String) As almacen

    <OperationContract()>
    Function GetListar_almacenPorUsuario(idEmpresa As String, idEstable As Integer, listaPersona As List(Of String), intAnio As Integer, intMes As Integer, fechaInicio As DateTime, fechaFin As DateTime, tipo As String, intDia As Integer) As List(Of almacen)


#End Region

#Region "MASCARA CONTABLE GASTOS"
    <OperationContract()>
    Function ObtenerMascaraGastos(ByVal strIdEmpresa As String, ByVal strCuentaPadre As String) As List(Of mascaraGastosEmpresa)

#End Region

#Region "MASCARA CONTABLE2"
    <OperationContract()>
    Function ObtenerMascaraExistencias(ByVal strIdEmpresa As String, ByVal strTipoExistencia As String) As List(Of mascaraContableExistencia)

    <OperationContract()>
    Function ObtenerMascaraContableMercaderia(strEmpresa As String, InitCuenta As String) As IList(Of mascaraContable2)

    <OperationContract()>
    Function GetUbicar_mascaraContable2PorEmpresa(strIEmpresa As String, strCuenta As String) As mascaraContable2

    <OperationContract()> _
 _
    Function GetUbicar_mascaraContableExistenciaPorEmpresaCF(idEmpresa As String, strCuenta As String, strTipoEx As String) As mascaraContableExistencia

    <OperationContract()>
    Function ObtenerMascaraContable2PorEmpresa(strIdEmpresa As String) As List(Of mascaraContable2)

    <OperationContract()>
    Function ObtenerMascaraContable2PorItems(strIdEmpresa As String) As List(Of mascaraContable2)

    <OperationContract()> _
 _
    Function UpdateMascaraContable2(ByVal mascaraContable2BE As mascaraContable2) As String

    <OperationContract()> _
 _
    Function InsertarMascaraSingle(ByVal mascaraContable2BE As mascaraContable2) As Integer

#End Region

#Region "VENTAS"

#Region "NOTA CREDITO"
    <OperationContract()>
    Function GetListarNotasPorIdVentaPadre(intIDoCumento As Integer, strTipoNota As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function ListarNotasXidCompra(intIDoCumento As Integer) As List(Of documentocompra)


    <OperationContract()> _
 _
    Function SaveCompraNotaCreditoVenta(objDocumento As documento, nListaTotalesAlmacen As List(Of totalesAlmacen),
                                        nDocumentoNota As documento) As Integer

#End Region

    <OperationContract()>
    Sub UpdateVentaNormalContado(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento)

    <OperationContract()>
    Function DocumentoCanceladoVenta(intIdDocumento As Integer) As String

    <OperationContract()>
    Function GetListarVentasPorDiaEstablecimiento(be As documentoventaAbarrotes, Optional UsuarioCaja As String = Nothing) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasPorPeriodoCobrados(intIdEstablec As Integer, strPeriodo As String, strTipoVenta As String) As List(Of documentoventaAbarrotes)

#Region "RENTABILIDAD"
    <OperationContract()>
    Function GetAnalisiRentabilidad(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strPeriodo As String) As List(Of documentoventaAbarrotesDet)

#End Region
    <OperationContract()> _
 _
    Function SaveVentaDirectaTicket(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen),
                                          objDocumentoCaja As documento, cajaUsuario As cajaUsuario) As Integer

    <OperationContract()>
    Function GetUbicar_documentoventaAbarrotesPorID(idDocumento As Integer) As documentoventaAbarrotes

    <OperationContract()> _
 _
    Function SaveVentaTicket(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer

    <OperationContract()> _
 _
    Function SaveVentaNormalAlCredito(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer


    'agre martin
    <OperationContract()>
    <CyclicReferencesAware(True)>
    Function SaveVentaNormalServicio(objDocumento As documento, objDocumentoCaja As documento) As Integer
    'agre



    'agre martin
    <OperationContract()>
    <CyclicReferencesAware(True)>
    Sub DeleteVentaNormalServicio(ByVal documentoBE As documento)

    <OperationContract()>
    Sub DeleteSingleVariable(ByVal intIdDocumento As Integer)

    'agre
    <OperationContract()> _
 _
    Function SaveVentaALCredito(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer

    <OperationContract()> _
 _
    Function SaveVentaPagada(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objDocumentoCaja As documento, cajaUsuario As cajaUsuario) As Integer

    <OperationContract()> _
 _
    Function SaveOtrasSalidas(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer

    <OperationContract()>
    Function GetListarVentasPorPeriodo(intIdProyecto As Integer, strPeriodo As String, strTipoVenta As String, Optional UsuarioCaja As String = Nothing) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasNormalPorPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasPorPeriodo_CONT(strPeriodo As String, strTipoVenta As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasPorPeriodoGeneral(intIdProyecto As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasPorPeriodoGeneral_CONT(strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetObtenerVentaPorNumero(intIdEstablecimiento As Integer, strPeriodo As String, strTipoVenta As String,
                                             strTipoDoc As String, strSerie As String, strNumDoc As String) As documentoventaAbarrotes

    <OperationContract()>
    Function GetObtenerVentaPorNumeroComprobante(ntIdEstablecimiento As Integer, strPeriodo As String, strTipoVenta As String,
                                             strTipoDoc As String, strNumDoc As String) As documentoventaAbarrotes

    <OperationContract()>
    Function GetListarAllVentasPorCajaAbierta(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetListarAllVentasPorUsuarioGeneral(intIdPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetListarAllVentasDetallado(idDocumento As Integer, tipoexistencia As String) As List(Of documentoventaAbarrotesDet)


    <OperationContract()>
    Function GetUbicar_documentoventaAbarrotesDetPorIDocumento(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function usp_EditarDetalleVenta(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function Get_EditarDetalleVentaSinLote(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)


    <OperationContract()>
    Function GetUbicar_documentoventaAbarrotesDetPorID(Secuencia As Integer) As documentoventaAbarrotesDet

    <OperationContract()> _
 _
    Sub ConfirmarVentaTicket(objDocumento As documento, objDocumentoCaja As documento,
                                     objTotalesAlmacen As List(Of totalesAlmacen), cajaUsuario As cajaUsuario)

    '    <OperationContract()> _
    ' _
    '    Sub UpdateVentaNormalContado(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento)

    <OperationContract()>
    Function SaveRegistroHonorariosVenta(objDocumento As documento) As Integer


#End Region

#Region "GUIAS DE REMISION"
    <OperationContract()>
    Function UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento As Integer) As documentoguiaDetalle

    <OperationContract()>
    Function UbicarGuiaPorIdDocumento(intIdDocumento As Integer) As documentoGuia

    <OperationContract()>
    Function ListaGuiasPorCompraConEntidad(intIdDocumentoCompra As Integer) As List(Of documentoGuia)

    <OperationContract()>
    Function ListaGuiasPorCompra(intIdDocumentoCompra As Integer) As List(Of documentoGuia)

    <OperationContract()>
    Function ListaGuiasPorCompraSinEntidad(intIdDocumentoCompra As Integer) As List(Of documentoGuia)

    <OperationContract()>
    Function UbicarDocumentoGuiaDetalle(intIdDocumento As Integer) As List(Of documentoguiaDetalle)
#End Region

#Region "Notificacion"
    <OperationContract()>
    Function GetUbicarNotificacion(strIdEmpresa As String, intIdEstablecimiento As Integer, strEstado As String) As List(Of notificacionAlmacen)

    <OperationContract()>
    Function GetUbicarNotificacionCaja(strIdEmpresa As String, intIdEstablecimiento As Integer, strEstado As String) As List(Of notificacionAlmacen)

    <OperationContract()>
    Function GetUbicarNotificacionConteo(strIdEmpresa As String, intIdEstablecimiento As Integer, strSituacioN As String) As Integer

    <OperationContract()> _
 _
    Sub DeleteNotificacion(intIdDocumento As Integer)

#End Region

#Region "COMPRAS"

    <OperationContract()>
    Function UltimasOtrasSalidasPorFecha(strEmpresa As String, intIdEstablecimiento As Integer, intCuota As Integer, intAlnacenConsulta As Integer, IntIdItem As String) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetUbicar_documentocompradetallePorCompraNotificacion(strSerie As String, strNroDoc As String) As List(Of documentocompradetalle)


    <OperationContract()>
    Function GetUbicar_documentocompradetallePorCompra(strSerie As String, strNroDoc As String, strSitucion As String) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetUbicar_documentocompradetallePorItem(strNombreItem As String, strSitucion As String) As List(Of documentocompradetalle)

    <OperationContract()>
    Function SumatoriaImportesCompra(intIdDocumento As Integer) As documentocompradetalle

    <OperationContract()>
    Function TieneItemsEnAV(intIdDocumento As Integer) As Boolean

    <OperationContract()>
    Function UbicarCompraPorProveedor(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer) As List(Of documentocompra)

    <OperationContract()> _
 _
    Function UbicarCompraPorProveedorSerie(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer, strSerie As String) As List(Of documentocompra)

    <OperationContract()>
    Function ValidarEstadoManipulacion(intIdDocumentoCompra As Integer) As Integer

    <OperationContract()> _
 _
    Function SaveCompraNotaCredito(objDocumento As documento, nListaTotalesAlmacen As List(Of totalesAlmacen), nDocumentoNota As documento) As Integer

    <OperationContract()>
    Function SaveCompraNotaCredito2(objDocumento As documento, nDocumentoCaja As documento, Optional nDocumentoSaldoVenta As documento = Nothing) As Integer

    <OperationContract()>
    Function TieneNotasCD(intIdDocumentoCompra As Integer) As Boolean

    <OperationContract()> _
 _
    Function SaveCompraNotaDebito(objDocumento As documento, nListaTotalesAlmacen As List(Of totalesAlmacen), nDocumentoNota As documento) As Integer


    <OperationContract()>
    Function GetListarComprasPorProveedor(strIdEmpresa As String, intIdEstable As Integer, intIdProveedor As Integer) As List(Of documentocompra)

    <OperationContract()>
    Function GetUbicar_documentocompradetallePorID(Secuencia As Integer) As documentocompradetalle

    <OperationContract()> _
 _
    Function SaveDocumentoCompra(nDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), Optional nDocumentoTributo As documento = Nothing) As Integer

    <OperationContract()> _
 _
    Function SaveCompraAlCreditoConRecep(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), listaPrecios As List(Of listadoPrecios), Optional nDocumentoTributo As documento = Nothing) As Integer

    <OperationContract()>
    Function SaveCompraNuevoMetodo(objDocumento As documento) As Integer

    <OperationContract()>
    Function SaveCompraNuevoMetodoContado(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer


    <OperationContract()>
    Function SaveCompraNuevoMetodoOrden(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objOtrosDatos As documentoOtrosDatos) As Integer

    <OperationContract()>
    Sub GrabarCuetasPorPagarApertura(be As List(Of documento))

    <OperationContract()>
    Sub ActualualizarCompraSingle(objDocumento As documento)

    <OperationContract()>
    Function UbicarDetalleCompraEval(intIdDocumento As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GrabarBonificaciones(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer

    <OperationContract()>
    Function SaveRegistroHonorarios(objDocumento As documento) As Integer

    <OperationContract()>
    Function SaveRegistroCompraAnticipada(objDocumento As documento) As Integer

    <OperationContract()> _
 _
    Sub UpdateCompraAlCreditoCnRecep(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen),
                                Optional nDocumentoTributo As documento = Nothing)

    <OperationContract()>
    Function UbicarDocumentoCompraDetalleSituacion(intIdDocumento As Integer, strSituacion As String) As List(Of documentocompradetalle)
#Region "COMPRA DIRECTA SIN RECEPCION"
    <OperationContract()> _
 _
    Function UbicarCompraPorSerieNro(strEmpresa As String, intIdEstablecimiento As Integer, strSerie As String, strNumero As String, strRuc As String) As List(Of documentocompra)

    <OperationContract()>
    Function UbicarCompraPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function UbicarCompraPorProveedorXperiodo2(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, strMoneda As String) As List(Of documentocompra)

    <OperationContract()>
    Function UbicarVentaPorClienteXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()> _
 _
    Function UbicarNCreditoPorSerieNro(strEmpresa As String, intIdEstablecimiento As Integer, strSerie As String, strNumero As String, strRuc As String) As List(Of documentocompra)

    <OperationContract()> _
 _
    Function SaveCompraDirectaSinRecepcion(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), objDocumentoCaja As documento, cajaUsuario As cajaUsuario, Optional nDocumentoTributo As documento = Nothing) As Integer

    <OperationContract()> _
 _
    Function UpdateCompraDirectaSinRecepcion(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen),
                                       objDocumentoCaja As documento,
                                       nCajaUsuarioMontos As cajaUsuario, nCajaUsuarioEliminar As cajaUsuario)


    <OperationContract()> _
 _
    Sub DeleteCompraDirectaSinRecepcion(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub DeleteCompraDirectaSinRecepcionSL(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub DeleteCompraCreditoConRecepcionSL(ByVal documentoBE As documento)
#End Region



    <OperationContract()>
    Function SaveCompraPagada(objDocumento As documento, objDocumentoCaja As documento, objTotalesAlmacen As List(Of totalesAlmacen), cajaUsuario As cajaUsuario, objListaPrecio As List(Of listadoPrecios), Optional nDocumentoTributo As documento = Nothing) As Integer

    <OperationContract()>
    Function SaveOtrasEntradas(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen), nListaOrigenAlmacen As List(Of totalesAlmacen)) As Integer

    <OperationContract()>
    Sub GrabarTransferenciaAlmacenes(objDocumento As documento)

    <OperationContract()>
    Function SaveOtrasEntradasDefault(objDocumento As documento, objTotalesAlmacen As List(Of totalesAlmacen)) As Integer

    <OperationContract()> _
 _
    Sub UpdateDocumentoCompra(nDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), Optional nDocumentoTributo As documento = Nothing)

    <OperationContract()> _
 _
    Sub UpdateAporteExistencia(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub UpdateDocumentoCompraPagada(nDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento,
                                    nCajaUsuarioMontos As cajaUsuario, nCajaUsuarioEliminar As cajaUsuario)

    <OperationContract()> _
 _
    Sub UpdateOtrasEntradas(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub UpdateOtrasSalidas(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub UpdateVentaTicket(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub UpdateVentaNormal(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))


    <OperationContract()>
    <CyclicReferencesAware(True)>
    Sub UpdateVentaNormalServicio(objDocumento As documento, objDocumentoCaja As documento)



    <OperationContract()> _
 _
    Function UpdateVentaALCredito(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Function UpdateVentaPagada(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento,
                               nCajaUsuarioMontos As cajaUsuario, nCajaUsuarioEliminar As cajaUsuario)

    <OperationContract()> _
 _
    Function UpdateVentaDirecta(objDocumento As documento, listaTotales As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen), objDocumentoCaja As documento,
                                nCajaUsuarioMontos As cajaUsuario, nCajaUsuarioEliminar As cajaUsuario)

    <OperationContract()> _
 _
    Sub DeleteDocumento(nDocumento As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub DeleteDocumentoSL(nDocumento As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub EliminarDocNotasRef(intIdDocumentoPadre As Integer)

    <OperationContract()> _
 _
    Sub DeleteDocumentoPagadoSL(nDocumento As documento)

    <OperationContract()> _
 _
    Sub DeleteDocumentoPagadoAlCredito(nDocumento As documento)

    <OperationContract()> _
 _
    Function DeleteUsuarioCajaSL(nDocumento As documento) As String

    <OperationContract()> _
 _
    Sub DeleteDocumentoPagado(nDocumento As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub DeleteOtrasEntradas(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()> _
 _
    Sub DeleteOtrasSalidasDeAlmacen(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()>
    Sub DeleteOtrasTransAlmacenOE(ByVal documentoBE As documento, ListaOrigen As List(Of totalesAlmacen),
                                             ListaDestino As List(Of totalesAlmacen))

    <OperationContract()>
    Sub DeleteOtrasTransAlmacenOESL(ByVal documentoBE As documento)

    <OperationContract()>
    Sub DeleteOtrasSalidas(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))


    <OperationContract()>
    Sub DeleteNotas(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()>
    Sub DeleteNotasDebito(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))


    <OperationContract()>
    Sub DeleteVentaTicket(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()>
    Sub DeleteVentaTicketXitem(ByVal documentoBE As documento, objTotalBorrar As totalesAlmacen)

    <OperationContract()>
    Sub DeleteVentaNormalAlCredito(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()>
    Sub DeleteVentaTicketCobrado(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))

    <OperationContract()>
    Sub DeleteCompraDetalle(nDocumento As documentocompradetalle)

    <OperationContract()>
    Function UbicarDocumento(intIdDocumento As Integer) As documento

    <OperationContract()>
    Function UbicarDocumentoCompra(intIdDocumento As Integer) As documentocompra

    <OperationContract()>
    Function GetUbicarCompraPorID(idDocumento As Integer) As documentocompra

    <OperationContract()>
    Function GetUbicarDetalleCompraLote(intIdDocumento As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function UbicarDocumentoCompraDetalle(intIdDocumento As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function GetListarComprasPorPeriodo(intIdProyecto As Integer, strPeriodo As String, strTipoCompra As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarPorPeriodoEntradas(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strTipoCompra As String, strTipoConsulta As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarPorPeriodoEntradasTransferencia(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strTipoCompra As String, strTipoConsulta As String) As List(Of documentocompra)


    <OperationContract()>
    Function GetListarMvimientosAlmacenPorDia(intIdEmpresa As String, intIdEstablecimiento As Integer, strTipoCompra As String, tipoConsulta As String, Optional fecha As DateTime = Nothing) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorPeriodoGeneral(intIdProyecto As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorPeriodoGeneral_CONT(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorPeriodoGeneral_CONT_CREDITO(intIdEstablecimiento As Integer, strPeriodo As String, Optional strIdCajaUsuario As String = Nothing) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorPeriodoGeneral_CONT_CONTADO(documentocompraBE As documentocompra, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorPeriodoGeneralTransferencia(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)


    <OperationContract()>
    Function GetListarComprasPorPeriodoGeneralCentral(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarOrdenComprasPorPeriodoGeneral(intIdEstablecimiento As Integer, strPeriodo As String, tipoOrden As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarOrdenComprasPorFiltro(intIdEstablecimiento As Integer, strPeriodo As String, tipoOrden As String, intproveedor As Integer, moneda As Integer) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarOrdenServiciosPorPeriodoGeneral(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorPeriodoCambioGeneral(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarNotasPorIdCompraPadre(intIDocumentoPadre As Integer, strTipoNota As String) As List(Of documentocompra)
#End Region


#Region "Empresa"
    <OperationContract()>
    Function GetListaEmpresas() As List(Of empresa)

    <OperationContract()>
    Function GetUbicaEmpresaRuc(strIdEmpresa As String) As empresa

    <OperationContract()>
    Function GetUbicarSerieEmpresa(intIDEstablecimiento As Integer, strComprobante As String, strSerie As String) As EmpresaSeries
#End Region

#Region "EStablecimiento"
    <OperationContract()>
    Function GetListaEstablecimientos(srtEmpresa As String) As List(Of centrocosto)

    <OperationContract()>
    Function GetUbicaEstablecimientoID(intIdEstable As Integer) As centrocosto

    <OperationContract()>
    Function InsertEstablecimiento(estableBE As centrocosto) As Integer
#End Region

    <OperationContract()>
    Function AsientoGetAll() As List(Of asiento)

    <OperationContract()>
    Sub AsientoSaveByGroup(lista As List(Of asiento))

#Region "PLAN CONTABLE"
    <OperationContract()>
    Function ListarCuentasPorPadre(strEmpresa As String, strCuentaPadre As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function ObtenerCuentaPorID(strEmpresa As String, strCuenta As String) As cuentaplanContableEmpresa

    <OperationContract()>
    Function ObtenerCuentasConf(strEmpresa As String, strCuenta As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function ObtenerCuentasPorEmpresaEscalable(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function ObtenerCuentasPorEmpresaEscalableV2(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Sub GrabarCuenta(cuenta As cuentaplanContableEmpresa)

    <OperationContract()>
    Sub EliminarCuenta(ByVal cuentaBE As cuentaplanContableEmpresa)

    <OperationContract()>
    Sub EditarCuenta(ByVal cuentaBE As cuentaplanContableEmpresa)

    <OperationContract()>
    Function ObtenerCuentasPorEmpresa(strEmpresa As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function LoadCuentasGastos(strEmpresa As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function LoadCuentasGastosPadre(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function LoadCuentasPagoHonorarios(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)

    <OperationContract()>
    Function LoadCuentasServicios(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)

#End Region

#Region "PERSONA"
    <OperationContract()> _
 _
    Function InsertPersona(nPersona As Persona) As Persona

    <OperationContract()> _
 _
    Sub UpdatePersona(nPersona As Persona)

    <OperationContract()> _
 _
    Sub DeletePersona(nPersona As Persona)

    <OperationContract()> _
 _
    Function ObtenerPersonaNumDoc(strEmpresa As String, strNumDoc As String) As Persona

    <OperationContract()> _
 _
    Function ObtenerPersonaPorNombres(ByVal strIDEmpresa As String, ByVal strNombres As String) As List(Of Persona)

    <OperationContract()>
    Function ObtenerPersonaNumDocPorNivel(ByVal strIDEmpresa As String, ByVal strNumDoc As String, strNivel As String) As Persona
#End Region

#Region "RECURSOS"
    <OperationContract()> _
 _
    Function GetListaInsumosPorProyecto(intIDProyecto As Integer, strTipoRecurso As String) As List(Of actividadRecurso)

    <OperationContract()> _
 _
    Sub UpdateCotizacionFinal(nListaRecurso As List(Of actividadRecurso))

    <OperationContract()> _
 _
    Sub SaveListaRecurso(nListaRecurso As List(Of actividadRecurso), nListaRecursoGasto As List(Of actividadRecurso), nListaRecursoEDT As List(Of Actividades), nLiquidacion As List(Of totalesLiquidacion))

    <OperationContract()> _
 _
    Sub InsertCotizacionFinal(nProyecto As List(Of actividadRecurso))

    <OperationContract()> _
 _
    Function SaveRecursoIniciacion(nRecurso As actividadRecurso, nLiquidacion As totalesLiquidacion) As Integer

    <OperationContract()> _
 _
    Function SaveRecurso(nRecurso As actividadRecurso, nLiquidacion As totalesLiquidacion) As Integer

    <OperationContract()> _
 _
    Function SaveRecursoCotizacion(nRecurso As actividadRecurso, nLiquidacion As totalesLiquidacion) As Integer

    <OperationContract()> _
 _
    Sub UpdateRecursoCotizacion(nRecurso As actividadRecurso, nRecursoDelete As totalesLiquidacion, nLiquidacion As totalesLiquidacion)

    <OperationContract()> _
 _
    Sub UpdateRecursoIniciacion(nRecurso As actividadRecurso, nRecursoDelete As totalesLiquidacion, nLiquidacion As totalesLiquidacion)

    <OperationContract()> _
 _
    Sub UpdateRecurso(nRecurso As actividadRecurso, nRecursoDelete As totalesLiquidacion, nLiquidacion As totalesLiquidacion)

    <OperationContract()> _
 _
    Sub DeleteRecurso(nRecurso As actividadRecurso)

    <OperationContract()> _
 _
    Function ListaRecursosCotizacionGasto(intIDProyecto As Integer, strSustento As String, strTipoPlan As String) As List(Of actividadRecurso)

    <OperationContract()> _
 _
    Function GetConteoActividadRecursos(intIDProyecto As Integer) As Integer


    <OperationContract()> _
 _
    Function ListaRecursosCotizacionGastoFinal(intIDProyecto As Integer, strTipoRecurso As String, strSustentado As String) As List(Of actividadRecurso)

    <OperationContract()> _
 _
    Function ListaRecursosGastosFinal(intIDProyecto As Integer, strTipoRecurso As String, strSustentado As String) As List(Of actividadRecurso)

    <OperationContract()> _
 _
    Function GetListaGastoPlaneacion(intIDProyecto As Integer, strTipoRecurso As String, intIDActividad As Integer) As List(Of actividadRecurso)

    <OperationContract()> _
 _
    Function GetListaGPlaneacionIngreso(intIDProyecto As Integer, strTipoRecurso As String, intIDActividad As Integer) As List(Of actividadRecurso)

    <OperationContract()> _
 _
    Function ListaRecursosGastoPreliminar(intIDProyecto As Integer, strTipoRecurso As String, strTipoPresupuesto As String, strTipoPlan As String) As List(Of actividadRecurso)

    <OperationContract()>
    Function GetUbicaRecursoID(intIdRecurso As Integer) As actividadRecurso

    <OperationContract()>
    Function GetUbicaCotizacionbRecursoID(intIdRecurso As Integer) As actividadRecurso

#End Region


#Region "PROYECTOS"
    <OperationContract()> _
 _
    Sub SaveProyecto(nProyecto As ProyectoPlaneacion)

    <OperationContract()>
    Sub EditarProyecto(nProyecto As ProyectoPlaneacion)

    '<OperationContract()>
    'Sub EditarProyectoModoTrabajo(nProyecto As ProyectoPlaneacion)

    <OperationContract()>
    Sub DeleteProyecto(nProyecto As ProyectoPlaneacion)

    <OperationContract()>
    Function GetListaProyectos(intIdEstable As Integer) As List(Of ProyectoPlaneacion)

    <OperationContract()>
    Function GetUbicaProyecto(intIdProyecto As Integer) As ProyectoPlaneacion

    <OperationContract()>
    Function UpdateModoTrabajo(nProyecto As ProyectoPlaneacion, ByVal IdActividadMTAnt As Integer, ByVal EstadoMTAnt As String) As Boolean

    <OperationContract()>
    Sub EditarProyectoModoTrabajo(nProyecto As ProyectoPlaneacion)
#End Region

#Region "Entidades"
    <OperationContract()>
    Function UbicarEntidadPorRucNro(strEmpresa As String, strTipoEntidad As String, strNroDoc As String) As entidad

    <OperationContract()>
    Function UbicarEntidadVarios(ByVal strtipo As String, ByVal strEmpresa As String, ByVal strBusqueda As String, idEstablecimiento As Integer) As entidad

    <OperationContract()>
    Function SaveEntidad(nEntidad As entidad) As Integer

    <OperationContract()>
    Function GrabarSocioGym(ByVal entidadBE As entidad) As Integer

    <OperationContract()>
    Sub UpdateEntidad(nEntidad As entidad)

    <OperationContract()>
    Sub DeleteEntidad(nEntidad As entidad)

    <OperationContract()>
    Function GetListarEntidad(EntidadBE As entidad) As List(Of entidad)

    <OperationContract()>
    Function GetUbicarEntidadPorID(intIdEntidad As Integer) As List(Of entidad)

    <OperationContract()>
    Function ListarEntidadesPorNombres(strtipo As String, strEmpresa As String, strBusqueda As String) As List(Of entidad)

    <OperationContract()>
    Function ListarEntidadesPorRuc(strtipo As String, strEmpresa As String, strBusqueda As String) As List(Of entidad)

#End Region

#Region "TRABAJADOR"
    <OperationContract()>
    Function ObtenerTrabPorDNIExcel(strCodTrab As String, intEstable As Integer) As Integer

    <OperationContract()>
    Sub SaveTrabajador(nTrab As Trabajador_PL)

    <OperationContract()>
    Sub EliminarTrabajador(nTrab As Trabajador_PL)

    <OperationContract()>
    Sub UpdateTrabajador(nTrab As Trabajador_PL)

    <OperationContract()>
    Function GetListaTrabPorEmpresa(strIDEmpresa As String) As List(Of Trabajador_PL)

    <OperationContract()>
    Function GetListaTrabPorEstable(intIdEstable As Integer) As List(Of Trabajador_PL)

    <OperationContract()>
    Function GetUbicaTrab(strCodTrab As String, intEstable As Integer) As Trabajador_PL
#End Region

#Region "INSUMOS"
    <OperationContract()>
    Function ReviewProductos(ProductoBE As detalleitems) As List(Of detalleitems)



    <OperationContract()>
    Function UpdateTipoCategoria(nInsumo As item) As Integer

    <OperationContract()>
    Function SaveInsumo(nInsumo As item) As Integer

    <OperationContract()>
    Function InsertMultiplePresentacion(nInsumo As item) As Integer


    <OperationContract()>
    Function SaveInsumoSL(nInsumo As item) As item

    <OperationContract()>
    Sub UpdateInsumo(nInsumo As item)

    <OperationContract()>
    Function DeleteInsumoSL(nInsumo As item) As Boolean

    <OperationContract()>
    Sub DeleteInsumo(nInsumo As item)

    <OperationContract()>
    Sub InsumoSaveByGroup(lista As List(Of item))

    <OperationContract()>
    Sub UpdateCategoriaFull(lista As List(Of item))

    <OperationContract()> _
 _
    Sub GrabarProductosExcel(ByVal insumos As List(Of item))

    <OperationContract()>
    Sub InsumoSaveByGroupExcel(lista As List(Of item))

    <OperationContract()>
    Function ListaClasificacion(intEstable As Integer) As List(Of item)

    <OperationContract()>
    Function GetListaItemID(strDescripcion As String) As String

    <OperationContract()>
    Function GetListaItemPorEstable(strEstable As Integer, strIdEmpresa As String) As List(Of item)

    <OperationContract()>
    Function GetListaItemPorEstableLike(strEstable As Integer, strLike As String) As List(Of item)

    <OperationContract()>
    Function InsertarItemClasificaion(nTabDet As item) As Integer

    <OperationContract()>
    Function ObtenerItemsFull() As IList

    <OperationContract()>
    Function GetUbicarItemID(intIdTablaDep As String) As item

    <OperationContract()>
    Function UbicarCategoriaPorID(intIdCategoria As Integer) As item

    <OperationContract()>
    Function GetUbicaCategoriaItem_Utilidad(ByVal strIdEmpresa As String, ByVal intIdEstable As Integer, intIdItem As Integer) As Decimal

    <OperationContract()>
    Function GetListaItemPorEmpresa(strIdEmpresa As String, intIdEstablec As Integer) As List(Of item)

#Region "PRODUCTO"
    <OperationContract()>
    Sub SaveProducto(nProducto As detalleitems)

    <OperationContract()>
    Function InsertNuevaItems(nProducto As detalleitems) As Integer

    <OperationContract()>
    Function InsertItemDualTabla(ByVal ProductoBE As detalleitems) As Integer

    <OperationContract()>
    Sub SaveListaProducto(nListaProducto As List(Of detalleitems))

    <OperationContract()>
    Sub UpdateProducto(nProducto As detalleitems)

    <OperationContract()>
    Sub DeleteProducto(nProducto As detalleitems)

    <OperationContract()>
    Function GetProductoClasificado(intEstable As Integer, intClasificacion As Integer) As List(Of detalleitems)

    <OperationContract()>
    Function GetUbicarDetalleItemTipoExistencia(ByVal idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetUbicarDetalleItems(strempresa As String, intestablec As Integer, strNombre As String) As Integer

    <OperationContract()>
    Function GetUbicaProductoID(intIdProducto As Integer) As detalleitems

    <OperationContract()>
    Function GetUbicaProductoNombre(strNomProducto As String, strIdEmpresa As String, intIdEstable As Integer) As detalleitems

    <OperationContract()>
    Function InsertDetalle(ByVal itemBE As detalleitems) As Integer

    <OperationContract()>
    Function GetUbicarProductoXNotificacion(ByVal idEmpresa As String, idEstablec As Integer, intIdItem As Integer) As detalleitems

#End Region

#End Region

#Region "TABLA GENERAL"
    <OperationContract()>
    Function GetListaTabla() As List(Of tabla)

    <OperationContract()>
    Function GetListaTablaID(strDescripcion As String) As String

    <OperationContract()>
    Function GetUbicarTablaID(intIdTabla As Integer, strCodigo As String) As tabladetalle

    <OperationContract()>
    Function GetListaTablaDetalle(intIdTabla As Integer, strEstado As String) As List(Of tabladetalle)

    <OperationContract()> _
 _
    Function GetUbicarTablaNombre(strNombreTabla As String) As List(Of tabladetalle)

    <OperationContract()>
    Function ObtenerTablaFull() As IList

    <OperationContract()>
    Function ObtenerTablaMaximo() As Integer
#End Region

#Region "ACTIVIDAD"
    <OperationContract()> _
 _
    Sub GrabarActividadEquipo(nLista As List(Of Actividades), nProyecto As ProyectoPlaneacion)

    <OperationContract()> _
 _
    Sub UpdateIdPadreActividad(nLista As List(Of Actividades))


    <OperationContract()>
    Sub ProyectoActividadGrabarTodo(nActividad As Actividades)

    <OperationContract()> _
 _
    Function GetUbicarListaEDT(intIdProyecto As Integer, intIdPadre As Integer, strModulo As String) As List(Of Actividades)

    <OperationContract()> _
 _
    Function UbicaProyectoActividad(intProyecto As Integer, strModulo As String) As Actividades

    <OperationContract()>
    Function InsertarEDT(nActividad As Actividades) As Integer

    <OperationContract()>
    Sub GrabarActividadListaEDT(ByVal intIDProyecto As Integer, ByVal intIDEstable As Integer, ByVal srtTipoPlan As String)

    <OperationContract()>
    Sub EditarEDT(nActividad As Actividades)

    <OperationContract()>
    Sub DeleteEDT(nActividad As Actividades)

    <OperationContract()> _
 _
    Function UbicaEDT(intIdActividad As Integer) As Actividades

    <OperationContract()> _
 _
    Function GetUbicarMontoContractual(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) As List(Of Actividades)

    <OperationContract()> _
 _
    Function ListaEDT(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) As List(Of Actividades)

    <OperationContract()> _
 _
    Function GetListaActividadPorProyecto(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) As List(Of Actividades)

    <OperationContract()> _
 _
    Function GetBusquedaActividadGeneralPorEstado(intIDProyecto As Integer, strTipoRecurso As String, strEstado As String, strFlag As String) As List(Of Actividades)

    <OperationContract()> _
 _
    Function GetUbicarActividadPorModulo(intIdProyecto As Integer, strModulo As String) As List(Of Actividades)

    <OperationContract()> _
 _
    Function GetUbicarActividadPorModuloOcupa(intIdProyecto As Integer, strModulo As String) As List(Of Actividades)

#End Region



#Region "TABLA DETALLE"

    <OperationContract()>
    Function InsertarTablaDetalle(nTabDet As tabladetalle) As Integer

    <OperationContract()>
    Sub EditarTablaDetalle(nTabDet As tabladetalle)


    <OperationContract()>
    Sub DeleteTablaDetalle(nTabDet As tabladetalle)


#End Region

#Region "INGRESO SUNAT"

    <OperationContract()> _
 _
    Function GetUbicarIdPadre(intIdPadre As Integer) As List(Of ingresoSunat)

    <OperationContract()>
    Function InsertarIngresoSunat(nCodSunat As ingresoSunat) As Integer

    <OperationContract()>
    Sub EditarIngresoSunat(nCodSunatt As ingresoSunat)


    <OperationContract()>
    Sub DeleteIngresoSunat(nCodSunat As ingresoSunat)

#End Region

#Region "OCUPACION"

    <OperationContract()> _
 _
    Function GetUbicarOcupacion(idEstable As Integer) As List(Of ocupacion)

    <OperationContract()>
    Function InsertarOcupacion(idEstable As ocupacion) As Integer

    <OperationContract()>
    Sub EditarOcupacion(idEstable As ocupacion)

    <OperationContract()>
    Sub DeleteOcupacion(idEstable As ocupacion)

    <OperationContract()> _
 _
    Function GetUbicarOcupacionPorID(intCodOcupacion As Integer) As ocupacion

    <OperationContract()> _
 _
    Function GetUbicarOcupacionPorNombre(strNombre As String, intIdEstable As Integer) As ocupacion

#End Region

#Region "LIQUIDACION"
    <OperationContract()>
    Function GetUbicaLiquidacionID(nLiquidacion As totalesLiquidacion) As totalesLiquidacion

    <OperationContract()>
    Function GetListaLiquidacionPreliminar(intIdProyecto As Integer, strTipoPlan As String) As List(Of totalesLiquidacion)

    <OperationContract()>
    Sub GetEliminarLiquidacion(nLiquidacion As totalesLiquidacion)


#End Region

#Region "MARTIN"
    <OperationContract()>
    Function GetListaProductosPorItems(intIdAlmacen As Integer, intitem As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function GetListaAlmacenDet(idEmpresa As String, idEstablecimiento As Integer) As List(Of totalesAlmacen)

    <OperationContract()>
    Function OntenerListadoProductoEstablec(strEmpresa As String, intIdEstablecimiento As Integer, ByVal idAlmacen As String,
                                  ByVal desde As Date, ByVal hasta As Date) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function OntenerListadoProductoAlmacen(strEmpresa As String, intIdEstablecimiento As Integer, ByVal idAlmacen As String, ByVal strItem As String,
                                  ByVal desde As Date, ByVal hasta As Date) As List(Of InventarioMovimiento)


    <OperationContract()>
    Function GetUbicarGuiaRemision(stremp As String, periodo As String) As List(Of documentoguiaDetalle)


    <OperationContract()>
    Function GetListaProdItems(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of item)

    <OperationContract()>
    Sub UpdateTotalesAlmacen(ByVal listadoAlmacenBE As List(Of totalesAlmacen), ByVal objDocumento As Integer)

    <OperationContract()>
    Function UpdateTotalesAlmacen2(ByVal listadoAlmacenBE As List(Of totalesAlmacen), ByVal objDocumento As Integer) As Boolean

    <OperationContract()>
    Function ObtenerCajaOnlinePorDia(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlinePorRango(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEntidadFinanciera As String, desde As Date, hasta As Date) As List(Of documentoCaja)

    <OperationContract()>
    Function BuscarCajaOtrosMovimientosSingleME() As Decimal

    <OperationContract()>
    Function SaveGroupCajaOtrosMovimientosSingleME(objDocumentoBE As documento) As Integer

    <OperationContract()>
    Sub SaveGroupCajaOtrosMovimientosME(objDocumentoBE As documento)

    <OperationContract()>
    Function ObtenerCajaOnlineME(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaOnlineSaldosME(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)

    <OperationContract()>
    Function ObtenerCajaDetallePorId(ByVal idDocumentoVenta As Integer) As documentoCaja


    <OperationContract()> _
 _
    Function SaveGroupCajaME(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer


    <OperationContract()> _
 _
    Function SaveGroupCajaDocsME(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer

    <OperationContract()>
    Function ConsultaCajaXEmpresa(strEmpresa As String) As documentoCajaDetalle

    <OperationContract()>
    Function ConsultaMovimientoME(intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function SaveGroupCajaVentasME(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer

    <OperationContract()>
    Function GetListarAportesPorDia(intIdEstablecimiento As Integer) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarAportesPorMes(intIdEstablecimiento As Integer, ByVal strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarAportesPorRango(ByVal desde As Date, ByVal hasta As Date) As List(Of documentocompra)

    <OperationContract()>
    Function ObtenerProdPorAlmacenesPorMes(ByVal idAlmacen As String, ByVal strItem As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerProdPorAlmacenesPorMesAll(ByVal idAlmacen As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function ObtenerProdPorAlmacenesPorRango(ByVal idAlmacen As String, ByVal strItem As String, ByVal desde As Date, ByVal hasta As Date) As List(Of InventarioMovimiento)

    <OperationContract()>
    Function GetListarComprasPorMes_CONT(ByVal año As Integer, ByVal mes As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorRango_CONT(ByVal desde As Date, ByVal hasta As Date) As List(Of documentocompra)

    <OperationContract()>
    Function GrabarOrdenesServicio(objDocumento As documento, objOtroDoc As documentoOtrosDatos) As Integer

    <OperationContract()>
    Function GetListarOrdenCompraNoAprobadoSL(intIdEmpresa As String, ByVal intidEstablecimiento As Integer, ByVal EstadoOrden As String, ByVal strTipoSituacion As String) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarComprasPorPeriodoGeneralTransferenciaSC(intIdEstablecimiento As Integer, strPeriodo As String, Optional UsuarioCaja As String = Nothing) As List(Of documentocompra)

    <OperationContract()>
    Function ListaGuiasPorCompraSinNumeracion(intIdEstablecimiento As Integer, srtPeriodo As String, strIdEmpresarial As String) As List(Of documentoGuia)


#End Region

#Region "MARCARA CONTABLE EXISTENCIA"
    <OperationContract()> _
 _
    Function InsertMascaraContableExistenciaSingle(ByVal mascaraContableExistenciaBE As mascaraContableExistencia) As String

    <OperationContract()> _
 _
    Function UpdateMascaraContableExistenciaSingle(ByVal mascaraContableExistenciaBE As mascaraContableExistencia) As String
#End Region

#Region "SALDOS DE INICIO"
    <OperationContract()>
    Function SaldosXpagarXproveedor(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, intIdProveedor As Integer) As List(Of saldoInicio)

    <OperationContract()>
    Function ListadoDetalleSaldoXidDocumento(intIdDocumento As Integer) As List(Of saldoInicioDetalle)

    <OperationContract()>
    Function UbicarSaldoXidDocumento(intIdDocumento As Integer) As saldoInicio

    <OperationContract()> _
 _
    Function InsertarSaldos(documentoBE As documento) As Integer

    <OperationContract()> _
 _
    Sub DeleteSaldoAporte(ByVal documentoBE As documento, ListaItemsAeliminar As List(Of totalesAlmacen))

    <OperationContract()>
    Function ListadoMercaderiaXidDocumento(intIdDocumento As Integer) As List(Of saldoInicioDetalle)

    <OperationContract()>
    Function ListadoSaldosXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of saldoInicio)

    <OperationContract()> _
 _
    Function InsertarAporteInicio(documentoBE As documento, listaProductosAlmacen As List(Of totalesAlmacen)) As Integer

    <OperationContract()>
    Function BuscarEntidadXdescripcion(strEmpresa As String, strTipoEntidad As String, strBusqueda As String) As List(Of entidad)

    <OperationContract()>
    Function GetUbicarProductoXdescripcion(ByVal idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String, strBusqueda As String) As List(Of detalleitems)

    <OperationContract()>
    Function ObtenerEstadosFinancierosPorMonedaXdescripcion(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, strBusqueda As String) As List(Of estadosFinancieros)

    'agre martin

    <OperationContract()>
    Function ObtenerEstadosFinancierosPorTipo1(ByVal intIdEstablecimiento As Integer, ByVal strTipo As String, strBusqueda As String) As List(Of estadosFinancieros)
    'agre

    <OperationContract()>
    Function ObtenerPersonaNumDocPorNivelxDescripcion(ByVal strIDEmpresa As String, strNivel As String, strbusqueda As String) As List(Of Persona)
#End Region


    <OperationContract()>
    Function UbicarEntidadPorId(strEmpresa As String, strTipoEntidad As String, idEntidad As Integer) As entidad

    <OperationContract()>
    Function RptPagosPrestamoFecha(fechaini As Date, fechafin As Date) As List(Of documentoCaja)


    <OperationContract()>
    Function RptPrestamosOtorgados(idBenef As Integer) As List(Of prestamos)

    <OperationContract()>
    Function ObtenerPrestamosPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)


    <OperationContract()>
    Function ObtenerPrestamosEmitidosXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String, strTipoPrestamo As String) As List(Of prestamos)


    <OperationContract()>
    Function ObtenerPrestamosEmitidos(ByVal strIdEmpresa As String, ByVal strEstado As String, strTipoPrestamo As String) As List(Of prestamos)

    <OperationContract()>
    Function ObtenerPrestamoAprobadoDesembolsado(idBenef As Integer, tipo As String, tipoProv As String) As List(Of prestamos)

    <OperationContract()>
    Function ObtenerPrestamoAprobadoBeneficiario(idBenef As Integer, tipo As String, tipoProv As String) As List(Of prestamos)

    <OperationContract()> _
 _
    Sub ActualizarFechaPrestamo(documentoBE As prestamos, listaDocumentos As List(Of documentoPrestamos))

    <OperationContract()>
    Function SaveDesembolso(objDocumentoBE As documento, documentoBE As prestamos, listaDocumentos As List(Of documentoPrestamos)) As Integer

    <OperationContract()>
    Function RptPrestamosMayorMenor(inicio As Decimal, fin As Decimal) As List(Of prestamos)

    <OperationContract()>
    Function ListadoFechasCuotas(idDoc As Integer) As List(Of documentoPrestamos)

    <OperationContract()> _
 _
    Sub InsertPrestamoRecibido(documentoBE As documento, prestamo As prestamos, listaDocumentos As List(Of documentoPrestamos), listaDetalle As List(Of documentoPrestamoDetalle))

    <OperationContract()> _
 _
    Function SaveIngresoDesembolso(objDocumentoBE As documento, documentoBE As prestamos) As Integer



    <OperationContract()>
    Function ObtenerCuentasPorPagarAnticipoDetails(strDocumentoAfectado As Integer) As List(Of documentoAnticipoDetalle)

    <OperationContract()>
    Function UbicarCompraPorProveedorXperiodoAnt(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentocompra)

    <OperationContract()>
    Function UbicarPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipo As String) As List(Of documentocompra)

    <OperationContract()>
    Function UbicarCompraPorProveedorXperiodoAntFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentocompra)

    <OperationContract()>
    Function ListaTotalXCompra(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentocompra)

    <OperationContract()>
    Function ListaTotalXCompraAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentocompra


    <OperationContract()>
    Function ListaTotalXCompraTransito(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentocompra)

    <OperationContract()>
    Function ListaCompraAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As documentocompra



    <OperationContract()>
    Function GetListarComprasTransitoInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)

    <OperationContract()>
    Function GetListarTransferenciaInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)


    <OperationContract()>
    Function GetListarComprasTransitoInfGeneralRecepcion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)


    <OperationContract()>
    Function GetListarComprasPorPeriodoGeneralInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)


    <OperationContract()>
    Function ObtenerAnticiposMontoActual(idproveedor As Integer, tipo As String) As List(Of documentoAnticipo)

    <OperationContract()> _
 _
    Function SaveGroupAnticipo(objDocumentoBE As documento) As Integer


    <OperationContract()>
    Function ListadoComprobanteAnticipo(iNtPadre As Integer) As List(Of documentoAnticipo)

    <OperationContract()>
    Function ListadoAnticiposDetalleHijos(intIdDocumento As Integer) As List(Of documentoAnticipoDetalle)


    <OperationContract()>
    Sub ElimiNarCobroAnticipoVenta(ByVal documentoBE As documento)


    <OperationContract()>
    Sub ElimiNarPagoAnticipoCompra(ByVal documentoBE As documento)


    <OperationContract()>
    Function getTableAnticiposTipoPersonal(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String, idproveedor As Integer) As List(Of documentoAnticipo)

    <OperationContract()>
    Function ListadoAnticiposDetalle(idAnticipo As String) As List(Of documentoAnticipoDetalle)


    <OperationContract()>
    Function ObtenerSaldoAnticipo(idanticipo As Integer) As documentoAnticipo


    <OperationContract()>
    Function SaveAnticipoDevolucion(objDocumento As documento, objDocumentoCaja As documento) As Integer

    <OperationContract()>
    Function GetListarAllVentasAnuladas(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetEstadoSaldoXEFME(idestado As Integer) As estadosFinancieros

    <OperationContract()>
    Function ListadoMontosCuentas(idDoc As Integer) As List(Of documentoPrestamoDetalle)

    <OperationContract()>
    Function ListarPrestamosPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle)

    <OperationContract()>
    Sub UpdateConfirmarPrestamo(idDocumento As Integer)

    <OperationContract()>
    Function PrestamoListaDetalle(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle)

    <OperationContract()>
    Sub UpdateServicio(ByVal servicioBE As servicio)

    <OperationContract()>
    Function GrabarNewServicio(servicioBE As servicio) As Integer

    <OperationContract()>
    Function PrestamoSinConfirmarDetalle(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle)

    <OperationContract()>
    Function ObtenerTodoCuotasVencidas(tipo As String) As List(Of prestamos)

    <OperationContract()>
    Function ObtenerPrestamosRecibidoXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String, strTipoPrestamo As String) As List(Of prestamos)

    <OperationContract()>
    Function ObtenerPrestamoPagoCobro(periodo As String, tipo As String) As List(Of prestamos)

    <OperationContract()>
    Function ObtenerCuotasVencidas(idBenef As Integer, tipo As String) As List(Of prestamos)



    <OperationContract()>
    Function LoadCuentasConceptos(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)


    <OperationContract()>
    Function GrabarConceptoPrestamo(servicioBE As servicio) As Integer

    <OperationContract()>
    Sub EditarConceptoPrestamo(ByVal servicioBE As servicio)


    <OperationContract()>
    Function ListadoComprobantexPagoPrestamo(iNtPadre As Integer) As List(Of documentoCaja)

    <OperationContract()>
    Function ListadoCajaDetallePagoPrestamo(intIdDocumento As Integer) As List(Of documentoCajaDetalle)


    <OperationContract()>
    Function UbicarConceptosPrestamos(codigo As String, tipoPrestamo As String) As List(Of servicio)

    <OperationContract()>
    Function GrabarTipoPrestamoPadre(servicioBE As servicio, detalle As List(Of servicio)) As Integer


    <OperationContract()>
    Sub EditarTipoPrestamo(ByVal servicioBE As servicio)


    <OperationContract()>
    Sub UpdateEstadoCronograma(be As Cronograma)


    <OperationContract()>
    Function GetCronogramaPendiente() As List(Of Cronograma)


    <OperationContract()>
    Sub UpdateCronogramaHijo(be As Cronograma)


    <OperationContract()>
    Sub UpdateGastoModulo(be As documentoLibroDiario)


    <OperationContract()>
    Sub DeleteHijoCronograma(ByVal intIdCronograma As Integer)


    <OperationContract()>
    Function GetCronograma() As List(Of Cronograma)

    <OperationContract()>
    Sub InsertCronograma(lista As List(Of Cronograma))

    <OperationContract()>
    Function ObtenerCuentasPorPagarTodoDetails(idProv As Integer, strperiodo As String) As List(Of documentoCajaDetalle)


    <OperationContract()>
    Function UbicarCobrosModulo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, strPeriodo As String) As List(Of documentoLibroDiarioDetalle)


    <OperationContract()>
    Function UbicarCobrosModuloTodo(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)


    <OperationContract()>
    Function UbicarCobrosModuloTodoProveedor(strEmpresa As String, intIdEstablecimiento As Integer, idprov As Integer) As List(Of documentoLibroDiarioDetalle)


    <OperationContract()>
    Function UbicarCobrosPorClienteTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String, idprov As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function UbicarCobrosPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMoneda As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function UbicarCobrosPorTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function UbicarPagosModulo(strEmpresa As String, intIdEstablecimiento As Integer, cuenta As String, strPeriodo As String) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function UbicarPagosModuloTodo(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoLibroDiarioDetalle)


    <OperationContract()>
    Function UbicarPagosModuloTodoProveedor(strEmpresa As String, intIdEstablecimiento As Integer, idprov As Integer) As List(Of documentoLibroDiarioDetalle)

    <OperationContract()>
    Function UbicarPagosPorProveedor(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String) As List(Of documentocompra)

    <OperationContract()>
    Function UbicarPagosPorProveedorTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String, idprov As Integer, strPeriodo As String) As List(Of documentocompra)


    <OperationContract()>
    Function UbicarPagosPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMoneda As String) As List(Of documentocompra)


    <OperationContract()>
    Function UbicarPagosPorTodo(strEmpresa As String, intIdEstablecimiento As Integer, strMoneda As String) As List(Of documentocompra)


    <OperationContract()>
    Function ListarGastosModulo(tipo As String, periodo As String) As List(Of documentoLibroDiario)

    <OperationContract()>
    Function SaveGastosXModulo(objDocumento As documento)


    <OperationContract()>
    Function UbicarDocumentoModuloDetalle(intIdDocumento As Integer) As List(Of documentoLibroDiarioDetalle)


    <OperationContract()>
    Function UbicarGastosModulo(iddoc As Integer) As documentoLibroDiario


    <OperationContract()>
    Sub UpdateEstadoCronogramaDelete(be As Cronograma, iddocumento As Integer)


    <OperationContract()>
    Function ObtenerCuentasPorCobrarTodoDetails(idclie As Integer, strperiodo As String) As List(Of documentoCajaDetalle)


    <OperationContract()>
    Sub UpdateEstadoCronogramaDeleteCobro(be As Cronograma, iddocumento As Integer)


    <OperationContract()>
    Function GetCronogramaDetalle(fechaprog As DateTime, fechaVen As DateTime) As List(Of Cronograma)

    <OperationContract()>
    Function GetCronogramaDetalleTipo(idprov As Integer, tipo As String, tipoestado As String, fechaprog As DateTime, tipomoneda As String, fechavenc As DateTime) As List(Of Cronograma)

    <OperationContract()>
    Sub UpdateEstadoCronogramaLista(be As List(Of Cronograma))


    <OperationContract()>
    Function GetCronogramaTipo(fechaprog As DateTime, tipoprog As String, fechaVen As DateTime) As List(Of Cronograma)


    <OperationContract()>
    Function ObtenerCuentasPorPagarDocumentoDetails(list As List(Of documentocompra)) As List(Of documentoCajaDetalle)


    <OperationContract()>
    Function ConsultaMovimientosPorCajaYTipoExistencia(idCaja As Integer) As List(Of documentoCajaDetalle)


    <OperationContract()>
    Function ConsultaMovimientosPorCajaxEstadoFinanciero(idCaja As Integer) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ListacajausuarioXCuentasXcobrar(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function ListacajausuarioXCuentasXCompra(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)


    <OperationContract()>
    Function ListacajausuarioXDetalleAcumulado(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotesDet)


    <OperationContract()>
    Function ObtenerCuentasPorPagarDocumentoDetailsME(list As List(Of documentocompra)) As List(Of documentoCajaDetalle)

    <OperationContract()>
    Function ObtenerPagosDetailsAsientoManual(idProv As Integer, strperiodo As String, tipop As String, modulo As String) As List(Of documentoCajaDetalle)

    <OperationContract()> _
 _
    Function SaveGroupCajaMEAsiento(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer


    <OperationContract()>
    Function UbicarPagosPorProveedorPendiente(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strMoneda As String) As List(Of documentocompra)

    <OperationContract()>
    Sub EliminarPagoProgramado(iddocuemnto As Integer, estado As String)


    <OperationContract()>
    Function GetPagosxProgramacion(idprov As Integer, tipo As String, tipoestado As String, mes As Integer) As List(Of Cronograma)

    <OperationContract()>
    Function UbicarPagosPorProveedorPendienteMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String) As List(Of documentocompra)

    <OperationContract()>
    Function ListaServiciosOtrosAnticipado() As List(Of documentocompradetalle)


    <OperationContract()>
    Function UbicarCuentaCobrarComercial(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function UbicarCuentasXPagarComerciales() As List(Of documentocompra)

    <OperationContract()>
    Function DeudasGenerales() As List(Of documentocompra)

    <OperationContract()>
    Function UbicarVentaPorClienteMNME(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As Integer) As List(Of documentoventaAbarrotes)

#Region "GUIA DE REMISION"
    <OperationContract()>
    Function SaveVentaCobradaContado(objDocumento As documento) As Integer

    <OperationContract()>
    Function GrabarVentaGeneralCredito(objDocumento As documento) As Integer

    <OperationContract()>
    Function ListaTotalXVenta(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As Integer, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentoventaAbarrotes

    <OperationContract()>
    Function GetListarTransferenciaRecepcionInfGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As List(Of String), tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentocompra)

    <OperationContract()>
    Function GetListaSumatoriaCompras(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As documentocompra


    <OperationContract()>
    Function GetListarAllVentasInformeGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime, pago As String) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetListarAllVentasGeneralAprobado(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetConteoPedidosAprobado(intIdEstablec As Integer, strPeriodo As String, strTipo As String) As Integer

    <OperationContract()>
    Function UbicarVentaPorProveedorXperiodo(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function UbicarVentaPorProveedorXperiodoFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoventaAbarrotes)


    <OperationContract()>
    Function GetListarAllVentasGeneralesPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarAllVentasEntregablesDeMercaderia(intIdEstablec As Integer, strPeriodo As String, stridDocumento As Integer) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function SaveGuiaRemisionEntregado(objDocumento As documento) As Integer

    <OperationContract()>
    Function UbicarGuiaDetallePorIdDocumentoguia(intIdDocumento As Integer) As List(Of documentoguiaDetalle)


    <OperationContract()>
    Sub SaveGuiaRemisionCondicion(objDocumento As List(Of documentoguiaDetalleCondicion), objDocumentoDet As List(Of documentoguiaDetalle))

    <OperationContract()>
    Function listarUbigeo() As List(Of ubigeo)

    <OperationContract()>
    Function UbicarDocumentoGuiaDetCondicionFull(intIdDocumento As Integer) As List(Of documentoguiaDetalleCondicion)

    <OperationContract()>
    Function UbicarGuiaPendiente() As List(Of documentoGuia)

    <OperationContract()>
    Function GetUbicar_PorDocumento(intIdDocumento As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function ListaTotalXCompraDetalleAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As List(Of documentocompradetalle)

    <OperationContract()>
    Function ListaComprasPorveedorOrArticulo(strEmpresa As String, intIdEstable As Integer, fecInic As DateTime, fecHasta As DateTime, idProv As Integer, tipo As String, nombreitem As String) As List(Of documentocompradetalle)


    <OperationContract()>
    Sub updateDocumentoTransferencia(objdocumento As documentoGuia)

    <OperationContract()>
    Sub SaveGuiaRemisionCondicionTransferenciaAlmacenSC(objDocumento As List(Of documentoguiaDetalleCondicion), objDocumentoDet As List(Of documentoguiaDetalle), objListaAsiento As documento)


#End Region

    <OperationContract()>
    Function ResumenEntidadesFinancieras(cajaBE As cajaUsuario, listaPersona As List(Of Integer)) As List(Of documentoCaja)

    <OperationContract()>
    Function ListaResumenXEntidad(listaidPersona As List(Of Integer), fechaInicio As DateTime, fechaFin As DateTime, tipo As String,
                             strEmpresa As String, idEstablec As Integer, intAnio As Integer,
                             intMes As Integer, intDia As Integer, IdEntidad As Integer) As documentoCaja

    <OperationContract()>
    Function DocCajaXDocumento(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)

    <OperationContract()>
    Function DocCajaXItem(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)


    <OperationContract()>
    Function ListadoCajaXEstado(caja As cajaUsuario) As List(Of cajaUsuario)


    <OperationContract()>
    Function DocCajaXResumenXID(cajaBE As documentoCaja) As documentoCaja

    <OperationContract()>
    Function GetListarVentasPeriodoXTipoAnulados(intIdEstablec As Integer, strPeriodo As String, tipo As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasPeriodoXTipo(IDempresa As String, intIdEstablec As Integer, strPeriodo As String, tipo As String, TipoConsulta As String) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarVentasNotasPeriodo(intIdEstablec As Integer, strPeriodo As String) As List(Of documentoventaAbarrotes)



    '<WebInvoke(BodyStyle:=WebMessageBodyStyle.Wrapped,
    '           Method:="GET",
    '           RequestFormat:=WebMessageFormat.Json,
    '           ResponseFormat:=WebMessageFormat.Json,
    '           UriTemplate:="/EmpresaSelID/{idDatoGeneral}")>
    <OperationContract()>
    Function UbicaEmpresaID(idDatoGeneral As String) As datosGenerales


    <OperationContract()>
    Function InsertEmpresa(datoGeneralBE As datosGenerales) As Integer

    <OperationContract()>
    Function updateDatos(datoGeneralBE As datosGenerales) As Integer

    <OperationContract()>
    Function GetListarAllVentasPorDIa(objDocumento As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function InsertItemServicio(ByVal ProductoBE As List(Of servicio)) As Integer

    <OperationContract()>
    Function InsertItemServicioSimple(ByVal ProductoBE As servicio) As Integer

    <OperationContract()>
    Function GetListaServicios(ByVal ProductoBE As servicio) As List(Of servicio)

    <OperationContract()>
    Sub CambiarEstadoItemServicio(be As servicio)

    <OperationContract()>
    Function GetServicioByEmpresaConPrecios(empresa As String, tipo As String) As List(Of servicio)

    <OperationContract()>
    Function GetServicioSinAlmacenSearchText(empresa As String, search As String) As List(Of servicio)

    <OperationContract()>
    Function GetUbicaServicioID(intIdProducto As Integer) As servicio

    <OperationContract()>
    Function updateItemServicio(ByVal ProductoBE As servicio) As Integer

    <OperationContract()>
    Function GetListaItemServicioPorTipo(be As itemServicio) As List(Of itemServicio)

    <OperationContract()>
    Function UbicarCategoriaServicioPorID(intIdCategoria As Integer) As itemServicio

    <OperationContract()>
    Function GetServicioByEmpresaSinPrecios(empresa As String, tipo As String) As List(Of servicio)

    <OperationContract()>
    Function SaveInsumoServicio(nInsumo As itemServicio) As Integer

    <OperationContract()>
    Function CobrosxDocumentoImpresion(iNtPadre As Integer) As List(Of documentoventaAbarrotes)


#Region "GUIA DE REMISION"

    <OperationContract()>
    Function RegistrarGuiaRemision(BE As documento) As documento

    <OperationContract()>
    Function SAVEGUIA(ByVal DOCUMENTOGUIA As documentoGuia) As documentoGuia
#End Region

#Region "documentoguiadetalle"
    <OperationContract()>
    Function ListarGuiaDetalle(be As documentoGuia) As List(Of documentoGuia)
#End Region

#Region "UBIGEO"
    <OperationContract()>
    Function ListarGetUbigeos() As List(Of regiones)
#End Region

#Region "Restaurant"
    'Restaurant
    <OperationContract()>
    Function GetExistenciasXTipoExistencia(detalleitemsBE As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Function SaveComposicionFull(listaComposicion As List(Of composicion)) As Integer

    <OperationContract()>
    Function UpdateComposicionFull(composicionBE As composicion, listaComposicion As List(Of composicion))

    <OperationContract()>
    Function GetUbicarComposicion(composicionBE As composicion) As List(Of composicion)

    <OperationContract()>
    Function GetUbicarComposicionXId(composicionBE As composicion) As List(Of composicion)

#End Region

#Region "HOTEL"
    <OperationContract()>
    Sub EliminarInfraestructuraXID(i As infraestructura)

    <OperationContract()>
    Function getListaInfraestructuraFull(infraestructuraBE As infraestructura) As List(Of infraestructura)


    <OperationContract()>
    Function getListaInfraestructura(infraestructuraBE As infraestructura) As List(Of infraestructura)

    <OperationContract()>
    Function getListaInfraestructuraxIDPadre(infraestructuraBE As infraestructura) As List(Of infraestructura)

    <OperationContract()>
    Sub EditarInfraestructuraEstado(i As infraestructura)

    <OperationContract()>
    Sub EliminarInfraestructuraFull(i As infraestructura)

    <OperationContract()>
    Function getListaComponente(componenteBE As componente) As List(Of componente)

    <OperationContract()>
    Function getInfraestructuraEstructura(infraestructurabe As infraestructura) As List(Of infraestructura)

    <OperationContract()>
    Function getListaComponenteXTipo(componenteBE As componente) As List(Of componente)

    <OperationContract()>
    Function SaveComponenteFull(i As List(Of componente)) As Integer

    <OperationContract()>
    Function SaveComponente(i As componente) As Integer

    <OperationContract()>
    Sub EliminarDistribucionFull(i As distribucionInfraestructura)

    <OperationContract()>
    Function getListaDistribucionInfraestructura(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function getListaComponenteXIdPadre(componenteBE As componente) As List(Of componente)

    <OperationContract()>
    Function getDistribucionInfraestructura(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Sub updateCategoriaXDistribucion(listaId As List(Of distribucionInfraestructura))

    <OperationContract()>
    Sub EditarNumeracion(i As distribucionInfraestructura)

    <OperationContract()>
    Function SaveDistribucionInfraestructuraFull(distribucion As distribucionInfraestructura, listaDistribucionInfraestructura As List(Of distribucionInfraestructura)) As Integer

    <OperationContract()>
    Function GetUbicarCategoriaInfraestructura(categoriaInfraestructuraBE As categoriaInfraestructura) As List(Of categoriaInfraestructura)

    <OperationContract()>
    Function GetUbicartipoServicioInfraestructura(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura)

    <OperationContract()>
    Function GetUbicar_DocveNTAxIdDistribucion(documentoPedidoBE As documentoPedido) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetUbicar_DocveNTAxIdCliente(documentoPedidoBE As documentoPedido) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function getDistribucionInfraestructuraXtipo(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function getInfraestructura(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function getDistribucionInfraHospedado(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function getDistribucionXReserva(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function updateDistribucionXRecepcion(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function GetDistribucionXAgrupacion() As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function GetDashboardDistribucion(documentoventaBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function GetDashBoardXCliente(documentoBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function GetDetalleHabitacion(documentoBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function getDistribucionInfraestructuraXtipoInfra(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function getDistribucionInfraestructuraXCategoria(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)


    <OperationContract()>
    Function updateDistribucionxID(i As distribucionInfraestructura) As distribucionInfraestructura

    <OperationContract()>
    Function updateDistribucionXCondicion(i As distribucionInfraestructura) As distribucionInfraestructura

    <OperationContract()>
    Sub updateDistribucionMasivo(listaID As distribucionInfraestructura)

    <OperationContract()>
    Function updateDistribucionRecepcionMasivo(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Sub updateDistribucioRecepciomMasivo(listaID As distribucionInfraestructura)


    <OperationContract()>
    Function GetListarAllVentasPeriodoPendienteInfra(intIdEstablec As Integer, strPeriodo As String, listaIdDistribucion As List(Of String)) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListaVentaID(be As documento) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetListarAllVentasXIdDistribucion(distribucionBE As distribucionInfraestructura) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetImprimirPedido(distribucionBE As documento) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetImprimirPrecuenta(distribucionBE As documento) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetUbicar_DocXInfraXAreaFull(documentoPedidoBE As documentoPedido) As List(Of documentoPedidoDet)

    <OperationContract()>
    Sub EditarEstadoPedido(i As documentoPedidoDet)

    <OperationContract()>
    Sub EditarEstadoPedidoMasivo(i As List(Of documentoPedidoDet))

    <OperationContract()>
    Sub EditarEstadoDocPedidoMasivo(i As distribucionInfraestructura)

    <OperationContract()>
    Function getListaInfraestructuraFullPedido(infraestructuraBE As infraestructura) As List(Of infraestructura)

    <OperationContract()>
    Function listaAlertaCheckOn(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura)

    <OperationContract()>
    Sub EditarOcupacionInfra(i As ocupacionInfraestructura)

    <OperationContract()>
    Function listaOcupacionInfraestructura(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura)

    <OperationContract()>
    Function OcupacionInfra(objOcupacion As ocupacionInfraestructura) As ocupacionInfraestructura

    <OperationContract()>
    Function GetListaOcupacionInfra(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura)

    <OperationContract()>
    Function GetUbicarDistribucionTipoServicio(composicionBE As distribucionTipoServicio) As List(Of distribucionTipoServicio)

    <OperationContract()>
    Function GetUbicartipoServicioInfraSinClasificacion(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura)

    <OperationContract()>
    Function GetUbicartipoServicioInfra(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura)

    <OperationContract()>
    Function GetUbicarCategoriaAndListaSubCategoria(categoriaInfraestructuraBE As categoriaInfraestructura) As List(Of categoriaInfraestructura)


    <OperationContract()>
    Function SaveCategoriaInfraestructura(objCategoria As categoriaInfraestructura) As Integer


    <OperationContract()>
    Function SaveTipoServicioInfraestructura(objCategoria As tipoServicioInfraestructura) As Integer

    <OperationContract()>
    Function Save_ListaDistribucionTipoServicio(ListaDistribucion As List(Of distribucionTipoServicio)) As Integer

    <OperationContract()>
    Function GetUbicarCategoriaInfraestructuraXID(categoriaInfraestructuraBE As categoriaInfraestructura) As categoriaInfraestructura

    <OperationContract()>
    Sub DeleteTipoServicioFull(ByVal ListaTipo As List(Of distribucionTipoServicio))

    <OperationContract()>
    Function Saveinfraestructura(i As infraestructura) As Integer

    <OperationContract()>
    Function EditarNombreInfra(i As infraestructura) As infraestructura

    <OperationContract()>
    Function GetProductosWithEquivalenciasXTipo(be As detalleitems) As List(Of detalleitems)


    <OperationContract()>
    Function GetDistribucionInfraestructuraConPrecios(empresa As String, tipo As String) As List(Of distribucionInfraestructura)


    <OperationContract()>
    Function ListarPersonaBeneficioXHabitacion(personas As personaBeneficio) As List(Of personaBeneficio)

    <OperationContract()>
    Function ListarHospedadosXCliente(personasBE As personaBeneficio) As List(Of personaBeneficio)

    <OperationContract()>
    Function UbicarHospedadoPorRucNro(strEmpresa As String, strNroDoc As String) As personaBeneficio

    <OperationContract()>
    Function UbicarHospedadoPorID(PersonaBE As personaBeneficio) As personaBeneficio

    <OperationContract()>
    Function ListarPersonaXHabXCliente(personas As personaBeneficio) As List(Of personaBeneficio)

    <OperationContract()>
    Sub SavePersonaBeneficio(ListaobjPersona As List(Of personaBeneficio), idDocumento As Integer)

    <OperationContract()>
    Function ListarPersonaBeneficioXHabitacionActivo(personas As personaBeneficio) As List(Of personaBeneficio)

    <OperationContract()>
    Function ListarPersonaBeneficio(personas As personaBeneficio) As List(Of personaBeneficio)

    <OperationContract()>
    Function ListarPersonaFull(personas As personaBeneficio) As List(Of personaBeneficio)

    <OperationContract()>
    Function GetUbicar_documentoventaAbarrotesXListaIdDocumento(docVentaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)

    <OperationContract()>
    Function GetUbicar_ListaDocumento(docVentaAbarrotesBE As documentoventaAbarrotesDet) As documento

    <OperationContract()>
    Function ListaClienteActivo(i As entidad) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function UbicarEntidadPorRucNroxIdDistribucion(strEmpresa As String, strTipoEntidad As String, strNroDoc As String) As List(Of entidad)

    <OperationContract()>
    Function GrabarVentaEquivalenciaXInfra(be As documento) As documento

    <OperationContract()>
    Function GrabarVentaEquivalenciaXListaDoc(be As List(Of documento)) As documento

    <OperationContract()>
    Function GrabarVentaEquivalenciaXPedido(be As documento) As documento

    <OperationContract()>
    Function GrabarVentaEquivalenciaXInfraMasivo(be As documento) As documento

    <OperationContract()>
    Function GetListaClientesAndHuesped(strEmpresa As String, strTipoEntidad As String) As List(Of entidad)

    <OperationContract()>
    Function GetListaPedidosXCliente(documentoVentaBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)

    <OperationContract()>
    Function GetANTReclamacionesPeriodoXCliente(be As documentoAnticipo) As List(Of documentoAnticipo)

    <OperationContract()>
    Function GetAnticipoRecibidosStatusAllXCliente(be As documentoventaAbarrotes) As List(Of documentoAnticipo)


    <OperationContract()>
    Function GetUbicarClienteOrHuesped(entBE As entidad) As entidad

    <OperationContract()>
    Function GetProductosWithEquivalenciasXCat(be As detalleitems) As List(Of detalleitems)

    <OperationContract()>
    Sub DeletePedidoRestaurant(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotes)

    <OperationContract()>
    Sub DeleteItemVentaRestaurant(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet)

    <OperationContract()>
    Sub updateMesa(ByVal InfraBE As distribucionInfraestructura)

    <OperationContract()>
    Sub actualizarMarcaProducto(be As detalleitems)

    <OperationContract()>
    Function GetUbicarProductoXTipoExistencia(ByVal idEmpresa As String, idEstablec As Integer, strTipoExistencia As String) As List(Of detalleitems)

    <OperationContract()>
    Function GetUbicarProductoXMarca(ByVal detalleItemBE As detalleitems) As List(Of detalleitems)


#End Region

#Region "TRANSPORTE"
    <OperationContract()>
    Function CargaAsientos(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)

    <OperationContract()>
    Function GetConsultarEnviosPorProgramacion(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)

    <OperationContract()>
    Function GetDistritosSelProvincia(provincia_id As String, region_id As String) As List(Of distritos)

    <OperationContract()>
    Function GetDistritosSelID(distrito_id As String) As distritos

    <OperationContract()>
    Sub ReenviarDocumentoEliminado(idDocumento As Integer, idPse As String)

    <OperationContract()>
    Function GetEncomiendasSelAgenciaDestinoMes(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function GetCiudadesPorEntregarOrigenFecha(be As documentoventaTransporte, opcion As String) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function GetResumenVentasSelCajero(be As documentoCaja) As documentoCaja

    <OperationContract()>
    Function GetConsultaEncomiendasSelMes(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function GetConsultaTransporteSelMes(be As documentoventaTransporte) As List(Of documentoventaTransporte)


    <OperationContract()>
    Function GetEncomiendasSelCajero(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function BuscarDocumentosAnuladosPeriodoTrans(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function BuscarDocumentosAnuladosFechaTrans(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function BuscarFacturanoEnviadasTrans(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function DocumentosAnuladosPendientesTransporte(fecha As DateTime, ruc As String) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function ListaCpePendientesDeEnvioTransporte(fecha As DateTime, idEmpresa As String) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function BuscarFacturanoEnviadasPeriodoTrans(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function BuscarBoletasAnuladasPeriodoTrans(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function BuscarBoletasAnuladasTrans(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaTransporte)

    <OperationContract()>
    Sub ListaEnvioSunatAnuladosTrans(lista As List(Of documentoventaTransporte), nroTicket As String, idNum As Integer)

    <OperationContract()>
    Sub ListaEnvioSunatResumenTrans(lista As List(Of documentoventaTransporte), idNum As Integer, nroTicket As String)

    <OperationContract()>
    Function AlertaEnvioPSETrasporte(Empresa As String) As documentoventaTransporte

    <OperationContract()>
    Function AlertaPSETrasporte(Empresa As String) As documentoventaTransporte

    <OperationContract()>
    Function GetEncomiendasSelAgenciaDestino(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function GetCiudadesPorEntregarOrigen(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Sub EliminarVentaEncomienda(documentoBE As documento)

    <OperationContract()>
    Function GetEncomiendasSelEstadoEntregaConteo(be As documentoventaTransporte) As Integer


    <OperationContract()>
    Sub ActualizarRutaDestino(be As documentoventaTransporte)

    <OperationContract()>
    Function GetTransporteDocXIDAnulacion(be As documentoventaTransporteDetalle) As documentoventaTransporte

    <OperationContract()>
    Function GetPasajeroXAsiwentoAnulacion(be As documentoventaTransporte) As documentoventaTransporte

    <OperationContract()>
    Function GetEncomiendasSelEstadoEntregaRDLC(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function GetEncomiendasSelEstadoEntrega(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Sub ReEnviarFacturaElectronica(idDocumento As Integer, IdPse As String, estado As String)

    <OperationContract()>
    Function DocumentoTransporteSelID(be As documentoventaTransporte) As documentoventaTransporte

    <OperationContract()>
    Function DocumentoTransporteSelIDVer2(be As documentoventaTransporte) As documentoventaTransporte

    <OperationContract()>
    Function DocumentoTransporteSelIDVehiculoXProg(be As documentoventaTransporte) As documentoventaTransporte

    <OperationContract()>
    Function DocumentoTransportePasajesSelID(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function GetEncomiendasByProgramacion(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Sub UpdateFacturasXEstadoTrans(doc As Integer, estado As String)

    <OperationContract()>
    Function DocumentoventaTransporteSave(objDocumento As documento) As Integer

    <OperationContract()>
    Function DocumentoventaTransporteReservacionSave(objDocumento As documento, idDocumentoREf As Integer) As Integer

    <OperationContract()>
    Sub DocumentoTransporteReservacionEliminar(idDocumentoREf As Integer)

    <OperationContract()>
    Function DocumentoventaEncomiendaSave(objDocumento As documento) As Integer

    <OperationContract()>
    Function GetConsultaEncomiendasFecha(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function GetConsultaTransporteFecha(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function GetConsultaEncomiendasFechaProgramada(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Function GetMovimientosByProgramacion(be As documentoventaTransporte) As List(Of documentoventaTransporte)

    <OperationContract()>
    Sub ActualizarEntrega(lista As List(Of documentoventaTransporte), listaEncomiendas As List(Of rutaTareoEncomienda))

    <OperationContract()>
    Sub ActualizarPrecio(be As ruta_HorarioServicios)

    <OperationContract()>
    Function GetProvinciasSelRegion(region As String) As List(Of provincias)

    <OperationContract()>
    Function GetRegiones() As List(Of regiones)

    <OperationContract()>
    Function ListarUbigeosActivos() As List(Of regiones)

    <OperationContract()>
    Function GetServiciosVentaTransporte(be As ruta_HorarioServicios) As List(Of ruta_HorarioServicios)

    <OperationContract()>
    Function GellAllRutas(be As rutas) As List(Of rutas)

    <OperationContract()>
    Sub InsertarRuta(be As rutas)

    <OperationContract()>
    Function GetRutaSelCodigo(be As rutas) As rutas

    <OperationContract()>
    Function RutaSelID(be As rutas) As rutas

    <OperationContract()>
    Function GetProgramacionPorFechaLaboral(be As rutaProgramacionSalidas) As List(Of rutaProgramacionSalidas)

    <OperationContract()>
    Function GetProgramacionEstatus(be As rutaProgramacionSalidas) As List(Of rutaProgramacionSalidas)

    Function GetProgramacionSelRutaMostrador(ruta_id As Integer) As List(Of rutaProgramacionSalidas)

    <OperationContract()>
    Function programacionSave(be As rutaProgramacionSalidas) As rutaProgramacionSalidas

    <OperationContract()>
    Function programacionXBusXHorarioSave(be As rutaProgramacionSalidas, listaAsientoXBus As List(Of vehiculoAsiento_Precios)) As rutaProgramacionSalidas

    <OperationContract()>
    Function programacionXBusXCambioPlacaSave(be As rutaProgramacionSalidas, listaAsientoXBus As List(Of vehiculoAsiento_Precios)) As rutaProgramacionSalidas

    <OperationContract()>
    Function GetProgramacionSelRuta(ruta_id) As List(Of rutaProgramacionSalidas)

    <OperationContract()>
    Function ProgramacionSelRutasActivas(be As rutaProgramacionSalidas) As List(Of rutas)

    <OperationContract()>
    Sub UpdateEstadoProgramacion(obj As rutaProgramacionSalidas)

    <OperationContract()>
    Sub GrabarConsolidacion(obj As rutaTareoAutos, estadoProgramacion As Integer)

    Function ProgramacionSelID(be As rutaProgramacionSalidas) As rutaProgramacionSalidas

    <OperationContract()>
    Function ProgramacionManifiestoSelID(be As rutaProgramacionSalidas) As rutaProgramacionSalidas

    <OperationContract()>
    Function GetRutasHabilitadas(be As rutaTareoAutos) As List(Of rutaTareoAutos)

    <OperationContract()>
    Function RutaTareoAutoSave(be As rutaTareoAutos) As rutaTareoAutos

    <OperationContract()>
    Sub GetListaSaveTareo(be As List(Of rutaTareoAutos))

    <OperationContract()>
    Function GetAdministrarPrecios(be As rutaTareoAutos) As List(Of rutaTareoAutos)

    <OperationContract()>
    Function GetProgamacionEnCurso(be As rutaProgramacionSalidas) As List(Of vehiculoAsiento_Precios)

    <OperationContract()>
    Function rutaTareoEncomiendaDetalleSelFechaV2(fecha As Date, origen As Integer, destino As Integer) As List(Of rutaTareoEncomiendaDetalle)

    <OperationContract()>
    Function rutaTareoEncomiendaDetalleSelID(be As rutaTareoEncomiendaDetalle) As List(Of rutaTareoEncomiendaDetalle)

    <OperationContract()>
    Function rutaTareoEncomiendaDetalleSelFecha(be As rutaTareoEncomienda) As List(Of rutaTareoEncomiendaDetalle)

    <OperationContract()>
    Function GetTareoEncomiendasSelCiudadDestino(be As rutaTareoEncomienda) As List(Of rutaTareoEncomienda)

    <OperationContract()>
    Function rutaTareoEncomiendaSelID(be As rutaTareoEncomienda) As rutaTareoEncomienda

    <OperationContract()>
    Function CerrarCajaUsuarioTrasnporte(nCajaUsuario As cajaUsuario) As cajaUsuario

    <OperationContract()>
    Sub ChangeEstatusAgencia(obj As centrocosto)

    <OperationContract()>
    Sub CrearBackupDatabase()

    <OperationContract()>
    Function GetListar_activosFijosSeriePlaca(be As activosFijos) As List(Of activosFijos)

    <OperationContract()>
    Function GetUbicar_activosFijosPorID(idActivo As Integer) As activosFijos

    <OperationContract()>
    Function ModificarActivo(ByVal activosFijosBE As activosFijos) As activosFijos

    <OperationContract()>
    Sub PredeterminarAgencia(estableBE As centrocosto)

    <OperationContract()>
    Sub ChangeEstatusActivo(obj As activosFijos)

    <OperationContract()>
    Function InsertEstablecimientoSingle(estableBE As centrocosto) As Integer

    <OperationContract()>
    Sub InsertServicioInfraestructuraDet(objDocumento As List(Of servicioInfraestructuraDet))

    <OperationContract()>
    Sub InsertServicioInfraestructuraSingle(objDocumento As servicioInfraestructuraDet)

    <OperationContract()>
    Function GellAllServiciosInfraDet(IdServicio As Integer) As List(Of servicioInfraestructuraDet)

    <OperationContract()>
    Function GellAllServiciosInfraDetxID(IdServicio As Integer, IdServicioDet As Integer) As servicioInfraestructuraDet

    <OperationContract()>
    Function GellAllServiciosInfra() As List(Of servicioInfraestructura)

    <OperationContract()>
    Sub UpdateServicioInfraestructura(objDocumento As servicioInfraestructura)

    <OperationContract()>
    Sub InsertServicioInfraestructura(objDocumento As servicioInfraestructura)

    <OperationContract()>
    Function GetListar_activosFijos() As List(Of activosFijos)

    <OperationContract()>
    Function GetConfiguracion(configuracionBE As configuracionReserva) As List(Of configuracionReserva)

    <OperationContract()>
    Function GetConfiguracionID(be As configuracionReserva) As configuracionReserva

    <OperationContract()>
    Function GetConfiguracionInsert(be As configuracionReserva) As configuracionReserva

    <OperationContract()>
    Function GetConfiguracionUpdate(be As configuracionReserva) As configuracionReserva

    <OperationContract()>
    Function GetListar_activosFijosConteoAsientos() As List(Of activosFijos)

    <OperationContract()>
    Function GetDistribucionAsignacionItem(distriBE As distribucionInfraestructura) As distribucionInfraestructura

    <OperationContract()>
    Sub updateDistribucioTrasnportemMasivo(listaID As distribucionInfraestructura)

    <OperationContract()>
    Function updateAsientoPrecioXaNULACIONID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios

    <OperationContract()>
    Function GetConsultarProgramacionXbus(be As vehiculoAsiento_Precios) As vehiculoAsiento_Precios

    <OperationContract()>
    Function GetConsultarProgramacionXbusAsientos(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)

    <OperationContract()>
    Function getInfraestructuraTransporteXProgramacion(distribucionBE As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)

    <OperationContract()>
    Function updateAsientoTransportexID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios

    <OperationContract()>
    Function updateAsientoTransportexIDxVerificaion(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios

    <OperationContract()>
    Function updateAsientoTransporteConfirmacionxID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios

    <OperationContract()>
    Function updateAsientoPrecioXall(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios

    <OperationContract()>
    Function updateAsientoPrecioXID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios

    <OperationContract()>
    Function getInfraestructuraTransporte(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function updateDistribucionTransportexID(i As distribucionInfraestructura) As distribucionInfraestructura

    <OperationContract()>
    Function GetListaNegocioComercial() As List(Of negocioComercial)

    <OperationContract()>
    Function GetListaNEgocioComercialXUnidOrg(negocioComercialBE As negocioComercial) As List(Of negocioComercial)

    <OperationContract()>
    Function GetListacentroCostosXNComercial(centroCostosXNComercialBE As centroCostosXNComercial) As List(Of centroCostosXNComercial)

    <OperationContract()>
    Function GetListaNegociosDisponibles(centroCostosXNComercialBE As centroCostosXNComercial) As centroCostosXNComercial

    <OperationContract()>
    Function GetInsertarcentroCostosXNComercial(centroCostosXNComercialBE As centroCostosXNComercial) As centroCostosXNComercial

    <OperationContract()>
    Function GetCentroCostosXNComercialUpdate(be As centroCostosXNComercial) As centroCostosXNComercial

    <OperationContract()>
    Sub EliminarPermisoNegocioCOmercial(ByVal be As centroCostosXNComercial)


#End Region

    <OperationContract()>
    Function InsertCopyItemXIdEsblecimiento(ByVal itemBE As detalleitems) As detalleitems

    <OperationContract()>
    Function GetListaItemxEstable(itemBE As item) As List(Of item)

    <OperationContract()>
    Function GetOrganizacion(be As organizacion) As List(Of organizacion)

    <OperationContract()>
    Function GetProductoXAreaOperativaxID(be As productoxAreaOperativa) As List(Of productoxAreaOperativa)

    <OperationContract()>
    Function GetInsertarProductoXAreaOperativaSingle(con As productoxAreaOperativa) As productoxAreaOperativa

    <OperationContract()>
    Function GetListar_numeracionBoletasAll(numeracionBoletasBE As numeracionBoletas) As List(Of numeracionBoletas)

    <OperationContract()>
    Function GetListar_numeracionBoletasXCargo(numeracionBoletasBE As numeracionBoletas) As List(Of numeracionBoletas)

    <OperationContract()>
    Sub SavePerfilAnexo(ByVal PerfilAnexoBE As List(Of perfilAnexo))

    <OperationContract()>
    Sub UpdatePerfilAnexoSingle(ByVal PerfilAnexoBE As perfilAnexo)

    <OperationContract()>
    Sub SavePerfilAnexoSingle(ByVal PerfilAnexoBE As perfilAnexo)

    <OperationContract()>
    Function GetObtenerPerfilAnexo(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo)

    <OperationContract()>
    Function GetObtenerPerfilAnexoXID(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo)

    <OperationContract()>
    Function GetObtenerPerfilIDestablecimiento(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo)

    <OperationContract()>
    Function GetObtenerOrganigramaXPerfil(strBE As organizacion) As List(Of organizacion)



    'TRANSPORTE
    <OperationContract()>
    Function SavePLantillaInfra(infraestructuraBE As List(Of infraestructura)) As Integer

    <OperationContract()>
    Function SaveActivoInfra(infraestructuraBE As List(Of infraestructura)) As Integer

    <OperationContract()>
    Function getCONTEOPlANTILLA(infraestructuraBE As infraestructura) As Integer

    <OperationContract()>
    Function GetPlantillaActivo(plantillaActivoBE As PlantillaActivo) As List(Of PlantillaActivo)

    <OperationContract()>
    Function getDistribucionInfraestructuraPlantilla(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function updateDistribucionNumeracion(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura)

    <OperationContract()>
    Function ListadoServicios(SERVCIOBE As servicio) As List(Of servicio)

End Interface
