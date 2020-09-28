Imports Helios.Cont.Business.Entity
Public Class DocumentoCajaSA

    ''' <summary>
    ''' Anular operaciones: Otras entradas y salidas de caja
    ''' </summary>
    ''' <param name="be"></param>
    Public Sub AnularOtrosPagos(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.AnularOtrosPagos(be)
    End Sub

    Public Sub ConfirmacionDineroBancario(be As List(Of documentoCaja))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmacionDineroBancario(be)
    End Sub

    Public Sub ConfirmarEntregaDeDinero(idCierre As Integer, be As cajaUsuario, bl As List(Of estadosFinancierosConfiguracionPagos), userTransc As documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmarEntregaDeDinero(idCierre, be, bl, userTransc)
    End Sub
    Public Function GetKardexCaja(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexCaja(be)
    End Function


    Public Function GetKardexCajaAdministracion(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexCajaAdministracion(be)
    End Function

    Public Function GetKardexCajaTramiteDocAdministracion(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexCajaTramiteDocAdministracion(be)
    End Function
    Public Function GetKardexCajaTramiteDoc(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexCajaTramiteDoc(be)
    End Function

    Public Function GetOperacionesCaja(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetOperacionesCaja(be)
    End Function

    Public Function GetMovimientosFormaPagoCajeroDetalle(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosFormaPagoCajeroDetalle(be)
    End Function

    Public Function GetMovimientosFormaPagoCajeroDetalleAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosFormaPagoCajeroDetalleAdmi(be)
    End Function

    Public Function GetMovimientosCajaCajeroDetalleAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaCajeroDetalleAdmi(be)
    End Function
    Public Function GetMovimientosCajaCajeroDetalle(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaCajeroDetalle(be)
    End Function

    Public Function GetMovimientosCajaComprobanteVentas(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaComprobanteVentas(be)
    End Function

    Public Function GetMovimientosCajaComprobanteVentasAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaComprobanteVentasAdmi(be)
    End Function

    Public Function GetMovimientosFormaPagoCajeroMonedaAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosFormaPagoCajeroMonedaAdmi(be)
    End Function
    Public Function GetMovimientosFormaPagoCajeroMoneda(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosFormaPagoCajeroMoneda(be)
    End Function
    Public Function GetMovimientosFormaPagoCajero(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosFormaPagoCajero(be)
    End Function

    Public Sub PagoCompensacionVentas(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.PagoCompensacionVentas(objDocumento)
    End Sub


    Public Sub PagoCompensacionCompras(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.PagoCompensacionCompras(objDocumento)
    End Sub

    Public Function GetMovimientosCajaCajeroUnidadNegocioCajeros(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaCajeroUnidadNegocioCajeros(be)
    End Function

    Public Function GetMovimientosCajaFullCajeros(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaFullCajeros(be)
    End Function

    Public Function GetMovimientosCajaFullCajerosAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaFullCajerosAdmi(be)
    End Function

    ''' <summary>
    ''' Resumen de ingresos y egresos por cajero y por dia
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function GetMovimientosCajaCajero(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaCajero(be)
    End Function


    Public Function GetMovimientosBancariosConfirmados(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosBancariosConfirmados(be)
    End Function
    Public Function GetMovimientosBancariosPendientes(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosBancariosPendientes(be)
    End Function
    Public Function GetMovimientosCajaCajeroTipoMonedaAdmi(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaCajeroTipoMonedaAdmi(be)
    End Function


    Public Function GetMovimientosEfectivoCajero(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosEfectivoCajero(be)
    End Function

    Public Function GetMovimientosCajaCajeroTipoMoneda(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaCajeroTipoMoneda(be)
    End Function
    Public Function GetMovimientosCajaCajeroUnidadNegocio(be As cajaUsuario) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosCajaCajeroUnidadNegocio(be)
    End Function

    Public Sub ConfirmarPagoTarjeta(iddoc As Integer, fecha As DateTime)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmarPagoTarjeta(iddoc, fecha)
    End Sub

    Public Function GetPagosTarjetaxConfirmar(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPagosTarjetaxConfirmar(be)
    End Function

    Public Function GetMovimientosByFormaPago(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosByFormaPago(cajaBE, listaPersona)
    End Function

    Public Function ListaResumenXEntidadV2(listaidPersona As List(Of Integer), fechaInicio As Date, fechaFin As Date, strEmpresa As String, idEstablec As Integer, ListaCuentasFinancieras As List(Of Integer)) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaResumenXEntidadV2(listaidPersona, fechaInicio, fechaFin, strEmpresa, idEstablec, ListaCuentasFinancieras)
    End Function

    Public Sub PagoDocVentas(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.PagoDocVentas(objDocumento)
    End Sub

    Public Sub PagoDocCompras(objDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.PagoDocCompras(objDocumento)
    End Sub

    Public Function GetResumenXFormaPago(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetResumenXFormaPago(be)
    End Function

    Public Function DocCajaXItemVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocCajaXItemVentas(cajaBE, listaPersona)
    End Function

    Public Function DocCajaXItemVentasElectronicas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocCajaXItemVentasElectronicas(cajaBE, listaPersona)
    End Function

    Public Function DocCajaUnitXDocumento(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocCajaUnitXDocumento(cajaBE, listaPersona)
    End Function

    Public Function DocCajaXDocumentoVentas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocCajaXDocumentoVentas(cajaBE, listaPersona)
    End Function

    Public Function DocCajaXDocumentoVentasElectronicas(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocCajaXDocumentoVentasElectronicas(cajaBE, listaPersona)
    End Function

    Public Function GetUbicarPagosComprobante(idDocumento As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarPagosComprobante(idDocumento)
    End Function

    Public Function GetPagoByComprobante(idDocumento As Integer) As List(Of documento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPagoByComprobante(idDocumento)
    End Function

    Public Function SaveGroupCajaReconocimiento(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaReconocimiento(objDocumentoBE, cajaUsuario)
    End Function

    Public Function GastosFinanzas(documentoCaja As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GastosFinanzas(documentoCaja)
    End Function

    Public Function GetUbicar_documentoAnticipoPorID(intIdDocumento As Integer) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentoAnticipoPorID(intIdDocumento)
    End Function


    Public Function UbicarAnticiposProveedor(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarAnticiposProveedor(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo)
    End Function

    Public Function GrabarPagoMembresia(objDocumentoBE As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarPagoMembresia(objDocumentoBE)
    End Function

    Public Function ObtenerCajaOnlineMensual(anioPeriodo As String, mesPeriodo As String, idEmpresa As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineMensual(anioPeriodo, mesPeriodo, idEmpresa)
    End Function

    Public Function ObtenerCajaOnlineAnual(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineAnual(strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetUbicar_documentoCajaID(intIdDocumento As Integer) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentoCajaID(intIdDocumento)
    End Function

    Public Sub CambiarPeriodoCaja(be As documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarPeriodoCaja(be)
    End Sub

    Public Function GetFlujoEfectivoByDia(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetFlujoEfectivoByDia(be)
    End Function

    Public Function GetFlujoEfectivoByDiaAllEmpresa(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetFlujoEfectivoByDiaAllEmpresa(be)
    End Function

    Public Function GetDepositosExtranjeros(be As estadosFinancieros) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDepositosExtranjeros(be)
    End Function

    Public Function GetSaldosCajaEntranjera(be As estadosFinancieros) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSaldosCajaEntranjera(be)
    End Function

    Public Function SaveGroupCajaMEAsiento(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaMEAsiento(objDocumentoBE, cajaUsuario, listaDetalle)
    End Function

    Public Function GetFlujoEfectivo() As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetFlujoEfectivo()
    End Function

    Public Function ListadoCajaDetallePagoPrestamo(intIdDocumento As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoCajaDetallePagoPrestamo(intIdDocumento)
    End Function


    Public Function ListadoComprobantesPagoPrestamos(iNtPadre As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoComprobantexPagoPrestamo(iNtPadre)
    End Function


    Public Function GetMovimientoXusuarioInfo(intUsuario As Integer, fechaActual As Date) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientoXusuarioInfo(intUsuario, fechaActual)
    End Function

    Public Function GetMovimientoXusuarioInfoDetalle(intUsuario As Integer, fechaActual As Date) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientoXusuarioInfoDetalle(intUsuario, fechaActual)
    End Function

    Public Function ListadoAnticiposDetalle(intIdDocumento As String) As List(Of documentoAnticipoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoAnticiposDetalle(intIdDocumento)
    End Function

    Public Function SaveGroupAnticipo(objDocumentoBE As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupAnticipo(objDocumentoBE)
    End Function

    Public Function SaveIngresoDesembolso(objDocumentoBE As documento, documentoBE As prestamos) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveIngresoDesembolso(objDocumentoBE, documentoBE)
    End Function

    Public Function SaveDesembolso(objDocumentoBE As documento, documentoBE As prestamos, listaDocumentos As List(Of documentoPrestamos)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveDesembolso(objDocumentoBE, documentoBE, listaDocumentos)
    End Function

    Public Function RptPagosPrestamos(ByVal inicio As Date, ByVal fin As Date) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RptPagosPrestamoFecha(inicio, fin)
    End Function


    Public Function ListaDeCajasPorCerrar(be As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaDeCajasPorCerrar(be)
    End Function

    Public Function ListarDetallePagosXcodigoLibro(caja As documentoCaja) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarDetallePagosXcodigoLibro(caja)
    End Function

    Public Function HistorialCobrosCajeroAdmi(iNtPadre As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.HistorialCobrosCajeroAdmi(iNtPadre)
    End Function

    Public Function ListadoComprobaNtesXidPadre(iNtPadre As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoComprobaNtesXidPadre(iNtPadre)
    End Function

    Public Function ListadoCajaDetalleHijos(intIdDocumento As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoCajaDetalleHijos(intIdDocumento)
    End Function

    Public Function ResumenTransaccionesUsuarios(intIdUserCaja As Integer, strTipoMov As String) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenTransaccionesUsuarios(intIdUserCaja, strTipoMov)
    End Function

    Public Function GetSaldoCuentaFinancieraXusuario(documentoBE As documentoCaja) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSaldoCuentaFinancieraXusuario(documentoBE)
    End Function

    Public Function ResumenTransaccionesxUsuarioDEP(intIdUserCaja As Integer) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenTransaccionesxUsuarioDEP(intIdUserCaja)
    End Function

    Public Function ResumenTransaccionesFullUsers(intIdPadre As Integer, strTipoMov As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenTransaccionesFullUsers(intIdPadre, strTipoMov)
    End Function

    Public Function OntenerVentaCobrosMes(intIdEstablecimiento As String, anio As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerCobrosVentaMes(intIdEstablecimiento, anio)
    End Function

    Public Function ObtenerCajaPagoPorVentaSL(ByVal idDocumentoVenta As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaPagoPorVentaSL(idDocumentoVenta)
    End Function

    Public Function GetListarPagosPorANioReporte(ANio As Integer, strTipoMov As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarPagosPorANioReporte(ANio, strTipoMov)
    End Function

    Public Function SumaxTipoEF(strTipo As String, strTipoMov As String) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaxTipoEF(strTipo, strTipoMov)
    End Function

    Public Function SumaxINgresosEgresos(strTipoMov As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaxINgresosEgresos(strTipoMov)
    End Function

    Public Function SumaxINgresosEgresosAnual() As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaxINgresosEgresosAnual()
    End Function

    Public Function ListaComprasPendientesXproveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaComprasPendientesXproveedor(intIdEstablecimiento, intIdProveedor)
    End Function

    Public Function SaveGroupCajaNotas(objDocumentoBE As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaNotas(objDocumentoBE)
    End Function

    Public Function SaveGroupCajaVentas(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaVentas(objDocumentoBE, cajaUsuario)
    End Function

    Public Function GrabarExcedenteCompra(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarExcedenteCompra(objDocumentoBE, cajaUsuario)
    End Function

    Public Function GrabarExcedenteVenta(objDocumentoBE As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GrabarExcedenteVenta(objDocumentoBE)
    End Function

    Public Function ListaChequesPendientesXProveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaChequesPendientesXProveedor(intIdEstablecimiento, intIdProveedor, strPeriodo)
    End Function

    Public Function GetObtenerCierreCajasModulos(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, intIdUser As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetObtenerCierreCajasModulos(strEmpresa, intIdEstablecimiento, strPeriodo, intIdUser)
    End Function

    Public Sub ConciliarCheque(objDocCaja As documentoCaja, objDocumentoBE As documento, cajaUsuario As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConciliarCheque(objDocCaja, objDocumentoBE, cajaUsuario)
    End Sub

    Public Function VerificarConciliarCheque(objDocCaja As documentoCaja) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.VerificarConciliarCheque(objDocCaja)
    End Function

    Public Function ListaChequesPorProveedor(intIdEstablecimiento As Integer, intIdProveedor As Integer, strPeriodo As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaChequesPorProveedor(intIdEstablecimiento, intIdProveedor, strPeriodo)
    End Function

    Public Function ObtenerCajasMovimientosPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajasMovimientosPorPeriodo(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function ObtenerCajaOnline(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnline(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlinePOS(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlinePOS(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlineConTramiteDoc(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineConTramiteDoc(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, listaEstado)
    End Function

    Public Function ObtenerCajaOnlineConTramiteDocPOS(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineConTramiteDocPOS(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, listaEstado)
    End Function

    Public Function ObtenerCajaOnlineXDocumento(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineXDocumento(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, listaEstado)
    End Function

    Public Function ObtenerCajaOnlineXDocumentoConTramiteDoc(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, ByVal listaEstado As List(Of String)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineXDocumentoConTramiteDoc(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, listaEstado)
    End Function

    Public Function ObtenerCajaOnlineXDocumentoXId(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String, idCaja As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineXDocumentoXId(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera, idCaja)
    End Function

    Public Function ObtenerCajaOnlineXIdCaja(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strperiodo As String, ByVal strEntidadFinanciera As String, idCaja As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineXIdCaja(strIdEmpresa, intIdEstablecimiento, strperiodo, strEntidadFinanciera, idCaja)
    End Function

    Public Function ObtenerMovimientosPorPeriodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMovimientosPorPeriodo(strIdEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function ObtenerMovimientosPorDia(strIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMovimientosPorDia(strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function GetItemsNoAsignadosFinanzas(documentoCaja As documentoCaja) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetItemsNoAsignadosFinanzas(documentoCaja)
    End Function

    Public Function ListaTotalXCaja(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer, intMes As Integer, intDia As Integer) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaTotalXCaja(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio, intMes, intDia)
    End Function

    Public Function ResumenCiereCaja(strEmpresa As String, intIdEstablecimiento As Integer, intIdCaja As Integer, estado As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenCiereCaja(strEmpresa, intIdEstablecimiento, intIdCaja, estado)
    End Function

    Public Function ObtenerCajaOnlineXUsuario(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strperiodo As String, ByVal strEntidadFinanciera As String, listasuarios As List(Of String), tipo As String, fechainicio As DateTime, fechaFin As DateTime, intAnio As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineXUsuario(strIdEmpresa, intIdEstablecimiento, strperiodo, strEntidadFinanciera, listasuarios, tipo, fechainicio, fechaFin, intAnio)
    End Function

    Public Function GetUbicar_documentoCajaPorID(idDocumento As Integer) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentoCajaPorID(idDocumento)
    End Function

    Public Function SaveGroupCaja(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCaja(objDocumentoBE, cajaUsuario)
    End Function

    Public Function SaveGroupCajaPrestamo(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaPrestamo(objDocumentoBE, cajaUsuario)
    End Function

    Public Function SaveGroupCajaNotacredito(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaNotacredito(objDocumentoBE, cajaUsuario)
    End Function

    Public Function SaveCajaAdministrativaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCajaAdministrativaApertura(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Function
    Public Function SaveCajaAperturaUsuarioPc(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveCajaAperturaUsuarioPc(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Function
    Public Function SaveGroupCajaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaApertura(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Function

    Public Function SaveGroupCajaGeneralApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaGeneralApertura(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Function


    Public Sub UpdateGroupCajaApertura(objDocumentoBE As documento, objCajaUsuarioBE As cajaUsuario, listaSubUsers As List(Of cajaUsuario))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateGroupCajaApertura(objDocumentoBE, objCajaUsuarioBE, listaSubUsers)
    End Sub

    Public Sub SaveGroupCajaOtrosMovimientos(objDocumentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveGroupCajaOtrosMovimientos(objDocumentoBE)
    End Sub

    Public Function SaveGroupCajaOtrosMovimientosSingle(objDocumentoBE As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaOtrosMovimientosSingle(objDocumentoBE)
    End Function

    Public Sub UpdateGroupCajaOtrosMovimientosSingle(objDocumentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateGroupCajaOtrosMovimientosSingle(objDocumentoBE)
    End Sub

    Public Sub SaveCajaExcedente(objDocumentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveCajaExcedente(objDocumentoBE)
    End Sub

    Public Sub EditarGroupCaja(objDocumentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarGroupCaja(objDocumentoBE)
    End Sub


    Public Function ObtenerCajaOnlinePorDia(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlinePorDia(strIdEmpresa, intIdEstablecimiento, strEntidadFinanciera)
    End Function


    Public Function ObtenerCajaOnlinePorRango(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEntidadFinanciera As String, desde As Date, hasta As Date) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlinePorRango(strIdEmpresa, intIdEstablecimiento, strEntidadFinanciera, desde, hasta)
    End Function

    Public Function BuscarCajaOtrosMovimientosSingleME() As Decimal
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarCajaOtrosMovimientosSingleME()
    End Function

    Public Function SaveGroupCajaOtrosMovimientosSingleME(objDocumentoBE As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaOtrosMovimientosSingleME(objDocumentoBE)
    End Function

    Public Sub SaveGroupCajaOtrosMovimientosME(objDocumentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveGroupCajaOtrosMovimientosME(objDocumentoBE)
    End Sub

    Public Function ObtenerCajaOnlineME(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineME(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function ObtenerCajaOnlineSaldosME(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strMEs As String, ByVal strAnio As String, ByVal strEntidadFinanciera As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaOnlineSaldosME(strIdEmpresa, intIdEstablecimiento, strMEs, strAnio, strEntidadFinanciera)
    End Function

    Public Function SaveGroupCajaME(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaME(objDocumentoBE, cajaUsuario, listaDetalle)
    End Function

    Public Function SaveGroupCajaDocsME(objDocumentoBE As documento, cajaUsuario As cajaUsuario, listaDetalle As List(Of documentoCajaDetalle)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaDocsME(objDocumentoBE, cajaUsuario, listaDetalle)
    End Function

    Public Function SaveGroupCajaVentasME(objDocumentoBE As documento, cajaUsuario As cajaUsuario) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaVentasME(objDocumentoBE, cajaUsuario)
    End Function

    Public Function ObtenerCajaDetallePorId(ByVal idDocumentoVenta As Integer) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaDetallePorId(idDocumentoVenta)
    End Function

    Public Function UbicarDocCajaXIdEntidadOrigen(intEntidadFinan As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocCajaXIdEntidadOrigen(intEntidadFinan, intEstablecimiento, strEmpresa)
    End Function

    Public Function ObtenerMovimientosPorPeriodoFinanzas(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMovimientosPorPeriodoFinanzas(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento)
    End Function

    Public Function ObtenerMovimientosPorPeriodoFinanzasXiDCaja(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, idCaja As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMovimientosPorPeriodoFinanzasXiDCaja(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, idCaja)
    End Function

    Public Function ListaReversionXDoc(strEmpresa As String, intIdEstablecimiento As Integer, idDocumento As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaReversionXDoc(strEmpresa, intIdEstablecimiento, idDocumento)
    End Function


    Public Function ObtenerMovimientosPorPeriodoFinanzasInforGeneral(strIdEmpresa As String, intIdEstablecimiento As Integer, intAnio As Integer, intMes As Integer, strMovimiento As String, tipo As String, listaUsuario As List(Of String), fechainicio As DateTime, fechaFin As DateTime) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMovimientosPorPeriodoFinanzasInforGeneral(strIdEmpresa, intIdEstablecimiento, intAnio, intMes, strMovimiento, tipo, listaUsuario, fechainicio, fechaFin)
    End Function

    Public Function SaveGroupCajaReversiones(objDocumentoBE As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGroupCajaReversiones(objDocumentoBE)
    End Function

    Public Sub updateEstadoCaja(idDocumento As Integer, estado As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.updateEstadoCaja(idDocumento, estado)
    End Sub

    Public Sub ConfirmacionBancaria(be As List(Of documentoCaja))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ConfirmacionBancaria(be)
    End Sub

    Public Function ObtenerMovCajaReversion(strEmpresa As String, anio As Integer, mes As Integer) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMovCajaReversion(strEmpresa, anio, mes)
    End Function

    Public Function ObtenerMovCajaDevolucion(strEmpresa As String, anio As Integer, mes As Integer, tipo As List(Of String), listaEstado As List(Of String), listaMov As List(Of String)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMovCajaDevolucion(strEmpresa, anio, mes, tipo, listaEstado, listaMov)
    End Function

    Public Function ObtenerAnticiposConDevolucion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, listaMovimiento As List(Of String), tipoEstado As List(Of String), listaTransac As List(Of String)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerAnticiposConDevolucion(strIdEmpresa, intIdEstablecimiento, strPeriodo, listaMovimiento, tipoEstado, listaTransac)
    End Function

    Public Function ObtenerHistorialReversion(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, tipoEstado As List(Of String)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerHistorialReversion(strIdEmpresa, intIdEstablecimiento, strPeriodo, strMovimiento, tipoEstado)
    End Function

    Public Function ResumenEntidadesFinancieras(cajaBE As cajaUsuario, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenEntidadesFinancieras(cajaBE, listaPersona)
    End Function

    Public Function ListaResumenXEntidad(listaidPersona As List(Of Integer), fechaInicio As DateTime, fechaFin As DateTime, tipo As String,
                            strEmpresa As String, idEstablec As Integer, intAnio As Integer,
                            intMes As Integer, intDia As Integer, IdEntidad As Integer) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaResumenXEntidad(listaidPersona, fechaInicio, fechaFin, tipo, strEmpresa, idEstablec, intAnio, intMes, intDia, IdEntidad)
    End Function

    Public Function DocCajaXDocumento(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocCajaXDocumento(cajaBE, listaPersona)
    End Function

    Public Function DocCajaXResumenXID(cajaBE As documentoCaja) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocCajaXResumenXID(cajaBE)
    End Function

End Class
