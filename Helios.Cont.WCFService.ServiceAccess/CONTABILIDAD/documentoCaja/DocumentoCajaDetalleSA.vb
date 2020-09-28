Imports Helios.Cont.Business.Entity
Public Class DocumentoCajaDetalleSA

    Public Function ObtenerCuentasPorCobrarPorDetailsREC(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorCobrarPorDetailsREC(strDocumentoAfectado)
    End Function

    Public Function ObtenerAnticipoDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerAnticipoDetails(strDocumentoAfectado)
    End Function

    Public Function ObtenerCuentasPorPagarAsientoDetails(lista As List(Of documentoLibroDiarioDetalle)) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorPagarAsientoDetails(lista)
    End Function

    Public Function ObtenerCuentasPorPagarDocumentoDetailsME(lista As List(Of documentocompra)) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorPagarDocumentoDetailsME(lista)
    End Function

    Public Function ObtenerPagosDetailsAsientoManual(idprov As Integer, strperiodo As String, tipop As String, modulo As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPagosDetailsAsientoManual(idprov, strperiodo, tipop, modulo)
    End Function

    Public Function ConsultaMovimientosPorCajaYTipoExistencia(idCaja As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConsultaMovimientosPorCajaYTipoExistencia(idCaja)
    End Function

    Public Function ObtenerCuentasPorPagarDocumentoDetails(lista As List(Of documentocompra)) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorPagarDocumentoDetails(lista)
    End Function

    Public Function ConsultaMovimientosPorCajaxEstadoFinanciero(idCaja As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConsultaMovimientosPorCajaxEstadoFinanciero(idCaja)
    End Function

   
    Public Function ObtenerCuentasPorCobrarTodoDetails(idclie As Integer, strperiodo As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorCobrarTodoDetails(idclie, strperiodo)
    End Function

    Public Function ObtenerCuentasPorPagarTodDetails(idprov As Integer, strperiodo As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorPagarTodoDetails(idprov, strperiodo)
    End Function

    Public Function PrestamoSinConfirmarDetalle(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.PrestamoSinConfirmarDetalle(strDocumentoAfectado)
    End Function

    Public Function PrestamoListaDetalle(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.PrestamoListaDetalle(strDocumentoAfectado)
    End Function

    Public Function ListarPrestamosPorPagarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoPrestamoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPrestamosPorCobrarPorDetails(strDocumentoAfectado)
    End Function


    Public Function ObtenerCuentasPorPagarBySecuencia(strItemAfectado As Integer) As documentoCajaDetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorPagarBySecuencia(strItemAfectado)
    End Function

    Public Function ObtenerPrestamosPorPagarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrestamosPorCobrarPorDetails(strDocumentoAfectado)
    End Function

    Public Function ReporteCuentasPorCobrarPorCliente(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ReporteCuentasPorCobrarPorCliente(fecINic, fecHAsta, idProv, MetodoPago)
    End Function

    Public Function ReportePagosDetalladoPorCliente(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ReportePagosDetalladoPorCliente(fecINic, fecHAsta, idProv, MetodoPago)
    End Function

    Public Function ReporteCuentasPorPagarPorProveedor(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ReporteCuentasPorPagarPorProveedor(fecINic, fecHAsta, idProv, MetodoPago)
    End Function

    Public Function ReportePagosDetalladoPorProveedor(fecINic As DateTime, fecHAsta As DateTime, idProv As Integer, MetodoPago As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ReportePagosDetalladoPorProveedor(fecINic, fecHAsta, idProv, MetodoPago)
    End Function

    Public Function ObtenerCuentasPorPagarPorDetailsVentas(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorPagarPorDetailsVentas(strDocumentoAfectado)
    End Function
    Public Function ConsultaEstadoPago(intIDDOcumentoCompra As Integer) As documentoCajaDetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConsultaEstadoPago(intIDDOcumentoCompra)
    End Function

    Public Function GetUbicar_DetalleXdocumentoAfectado(docAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_DetalleXdocumentoAfectado(docAfectado)
    End Function

    Public Function ObtenerHistorialPagoPrestamoXCuota(intIdCuota As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerHistorialPagoPrestamoXCuota(intIdCuota)
    End Function

    Public Function ObtenerPagosAcumPrestamos(strDocumentoAfectado As Integer, srtTipoCobro As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPagosAcumPrestamos(strDocumentoAfectado, srtTipoCobro)
    End Function

    Public Function ObtenerPagosPorPeriodo(strPeriodo As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPagosPorPeriodo(strPeriodo)
    End Function

    Function ObtenerHistorialPagosPorIdPago(intIdDocumentoPago As Integer) As documentoCajaDetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerHistorialPagosPorIdPago(intIdDocumentoPago)
    End Function

    Public Function ObtenerPagosPorPeriodoporEstablecimiento(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPagosPorPeriodoporEstablecimiento(intIdEstablecimiento, strPeriodo)
    End Function

    Public Function UbicarUltimaFechaPago(intIdDocumento As Integer) As DateTime
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarUltimaFechaPago(intIdDocumento)
    End Function

    Public Function RecuperarIDCompra(intIdDocumentoCompra As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RecuperarIDCompra(intIdDocumentoCompra)
    End Function

    Public Function GetUbicar_DetallePorIdDocumento(intIdDocumento As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_DetallePorIdDocumento(intIdDocumento)
    End Function

    Public Function SumaCobroPorDocumento(intIdEstable As Integer, strTipoDoc As String,
                                          strFiltro As String) As documentoCajaDetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaCobroPorDocumento(intIdEstable, strTipoDoc, strFiltro)
    End Function

    Public Function SumaCobroPorDocumentoPagos(intIdEstable As Integer, strTipoDoc As String,
                                       strFiltro As String, strSerie As String) As documentoCajaDetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaCobroPorDocumentoPagos(intIdEstable, strTipoDoc, strFiltro, strSerie)
    End Function

    Public Function SumaCobroPorCliente(intIdEstable As Integer, strFiltro As String, strPeriodo As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaCobroPorCliente(intIdEstable, strFiltro, strPeriodo)
    End Function

    Public Function SumaCobroPorModulo(intIdEstable As Integer, strFiltro As String, strPeriodo As String, strTipoModuloVenta As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaCobroPorModulo(intIdEstable, strFiltro, strPeriodo, strTipoModuloVenta)
    End Function

    Public Function SumaPagosPorProveedor(intIdEstable As Integer, strFiltro As String, strPeriodo As String) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaPagosPorProveedor(intIdEstable, strFiltro, strPeriodo)
    End Function
    Public Function SumaPagosPorIdDocumentoCompra(intIdDocumento As Integer) As documentoCajaDetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaPagosPorIdDocumentoCompra(intIdDocumento)
    End Function

    Public Function ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado)
    End Function

    Public Function ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado)
    End Function

    Public Function ObtenerCuentasPorPagarPorDetailsME(strDocumentoAfectado As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuentasPorPagarPorDetailsME(strDocumentoAfectado)
    End Function

    Public Function ObtenerHistorialPagos(intIdDocumentoCompra As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerHistorialPagos(intIdDocumentoCompra)
    End Function

    Public Function ObtenerPagosDelDia() As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPagosDelDia()
    End Function

    Public Function ObtenerPagosDelDiaPorEstablecimiento(intIdEstablecimiento As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPagosDelDiaPorEstablecimiento(intIdEstablecimiento)
    End Function

    Public Function ObtenerCajaDetalleME(ByVal montoUSD As Decimal, intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaDetalleME(montoUSD, intEntidadFinanciera)
    End Function

    Public Function ObtenerCajaDetalle(ByVal montoUSD As Decimal, intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaDetalle(montoUSD, intEntidadFinanciera)
    End Function

    Public Function ConsultaMovimientoME(intEntidadFinanciera As Integer) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConsultaMovimientoME(intEntidadFinanciera)
    End Function

    Public Function ConsultaCajaXEmpresa(strEmpresa As String) As documentoCajaDetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConsultaCajaXEmpresa(strEmpresa)
    End Function

    Public Function DocCajaXItem(cajaBE As documentoCaja, listaPersona As List(Of Integer)) As List(Of documentoCajaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocCajaXItem(cajaBE, listaPersona)
    End Function

End Class
