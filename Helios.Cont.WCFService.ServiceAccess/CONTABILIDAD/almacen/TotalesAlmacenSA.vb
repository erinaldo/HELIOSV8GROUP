Imports Helios.Cont.Business.Entity
Public Class TotalesAlmacenSA

    Public Function GetLotesExistentesDetalle(intIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetLotesExistentesDetalle(intIdAlmacen)
    End Function
    Public Function GetBusquedaAvanzadaProductosSinAlmacen(be As detalleitems, caso As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetBusquedaAvanzadaProductosSinAlmacen(be, caso)
    End Function

    Public Function GetInventarioAcumulado(idEMpresa As String, idEstablecimiento As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventarioAcumulado(idEMpresa, idEstablecimiento)
    End Function

    Public Function GetDetalleLoteXproductoProf(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDetalleLoteXproductoProf(objTotalBE)
    End Function

    Public Function GetBusquedaAvanzadaProductos(be As detalleitems, caso As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetBusquedaAvanzadaProductos(be, caso)
    End Function

    Public Function GetInventarioParaVentaAcumuladoDolares(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventarioParaVentaAcumuladoDolares(objTotalBE)
    End Function

    Public Function GetInventarioParaVentaAcumuladoCodigo(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventarioParaVentaAcumuladoCodigo(objTotalBE)
    End Function

    Public Function GetDetalleLoteXproductoFullAlmacen(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDetalleLoteXproductoFullAlmacen(objTotalBE)
    End Function

    Public Function GetInventarioGeneral(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventarioGeneral(be)
    End Function

    Public Function GetDetalleLoteXproducto(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDetalleLoteXproducto(objTotalBE)
    End Function

    Public Function GetInventarioParaVentaAcumulado(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventarioParaVentaAcumulado(objTotalBE)
    End Function

    Public Function GetInventarioParaVentaAcumuladoEspecial(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventarioParaVentaAcumuladoEspecial(objTotalBE)
    End Function

    Public Function GetProductsShopingOrOthers(objTotalBE As totalesAlmacen) As List(Of usp_GetProductsByEstable_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductsShopingOrOthers(objTotalBE)
    End Function

    Public Function GetInventarioParaVentaAcumuladoForma2(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetInventarioParaVentaAcumuladoForma2(objTotalBE)
    End Function


    Public Function GetAlertaIventarioSinStockConteo(be As totalesAlmacen) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAlertaIventarioSinStockConteo(be)
    End Function

    Public Function ListProductsConexos(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListProductsConexos(be)
    End Function

    Public Function GetUbicarArticuloLoteVenta(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarArticuloLoteVenta(be)
    End Function

    Public Function GetProductosXvencerMesFull(empresa As String, anio As Integer, mes As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosXvencerMesFull(empresa, anio, mes)
    End Function

    Public Function GetUbicarArticuloLote(be As totalesAlmacen) As totalesAlmacen
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarArticuloLote(be)
    End Function

    Public Function GetProductosXvencerMesCount(empresa As String, anio As Integer, mes As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosXvencerMesCount(empresa, anio, mes)
    End Function

    Public Function GetProductosXvencerMes(empresa As String, anio As Integer, mes As Integer, TipoExistencia As String, intIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosXvencerMes(empresa, anio, mes, TipoExistencia, intIdAlmacen)
    End Function

    Public Function ObtenerCanDisponibleProduct(bt As totalesAlmacen) As totalesAlmacen
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCanDisponibleProduct(bt)
    End Function

    Public Sub GetCurarKardexCaberas(be As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetCurarKardexCaberas(be)
    End Sub

    Public Sub GetChangeStatusArticulo(Be As totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetChangeStatusArticulo(Be)
    End Sub

    Public Sub ProductosConexos(lista As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ProductosConexos(lista)
    End Sub

    Public Function GetListadoProductosByAlmacen(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoProductosByAlmacen(be)
    End Function

    Public Function GetFilterArticulosStartWith(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetFilterArticulosStartWith(be)
    End Function

    Public Function GetProductosPorAlmacen(intIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosPorAlmacen(intIdAlmacen)
    End Function

    Public Function GetUbicar_EstadoCuenta20(idEmpresa As String, periodo As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_EstadoCuenta20(idEmpresa, periodo)
    End Function

    Public Function GetListadoProductosParaVentaXproductoEmpresa(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoProductosParaVentaXproductoEmpresa(objTotalBE)
    End Function

    Public Sub EditarArticuloLOTE(objInventario As totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarArticuloLOTE(objInventario)
    End Sub

    Public Function GetListadoProductosParaVentaXproductoEmpresaFull(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoProductosParaVentaXproductoEmpresaFull(objTotalBE)
    End Function

    Public Function GetProductoPorAlmacenTipoExByCodigoBarra(intIdAlmacen As Integer, strTipoEx As String, CodBarra As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductoPorAlmacenTipoExByCodigoBarra(intIdAlmacen, strTipoEx, CodBarra)
    End Function

    Public Function GetProductosByAlmacenCodigo(intIdAlmacen As Integer, Optional ByVal CodigoBarra As String = Nothing) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosByAlmacenCodigo(intIdAlmacen, CodigoBarra)
    End Function

    Public Function GetUbicar_totalesAlmacenPorID(idMovimiento As Integer) As totalesAlmacen
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_totalesAlmacenPorID(idMovimiento)
    End Function

    Public Function GetProductosParecidosRequeridos(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosParecidosRequeridos(be)
    End Function

    Public Function GetAlmacenesByProducto(intIdItem As Integer, strIdEmpresa As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAlmacenesByProducto(intIdItem, strIdEmpresa)
    End Function

    Public Sub ActulizarCantidadesByItem(be As totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActulizarCantidadesByItem(be)
    End Sub

    Public Function GetListaProductosByEstablecimiento(IntIdEstablecimiento As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProductosByEstablecimiento(IntIdEstablecimiento)
    End Function

    Public Function GetAlertaIventarioMinimo(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAlertaIventarioMinimo(be)
    End Function

    Public Function GetAlertaIventarioMinimoConteo(be As totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAlertaIventarioMinimoConteo(be)
    End Function

    Public Function GetStockAlmacenesBytem(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetStockAlmacenesBytem(be)
    End Function

    Public Function GetProductoPorAlmacenItem(intIdAlmacen As Integer, strTipoEx As String, idItem As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductoPorAlmacenItem(intIdAlmacen, strTipoEx, idItem)
    End Function

    Public Function GetProductosByAlmacen(almacenBE As almacen, Optional ByVal TipoExistencia As String = Nothing) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosByAlmacen(almacenBE, TipoExistencia)
    End Function

    Public Function ProductosMayoresStock(tot As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ProductosMayoresStock(tot)
    End Function

    Public Function ProductosMenoresStock(tot As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ProductosMenoresStock(tot)
    End Function

    Public Function NumProductosSinListaPrecio(tot As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.NumProductosSinListaPrecio(tot)
    End Function

    Public Function ObtenerAlertaDePrecio(productoBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerAlertaDePrecio(productoBE)
    End Function

    Public Function ObtenerAlertaDePrecioConteo(ByVal productoBE As totalesAlmacen) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerAlertaDePrecioConteo(productoBE)
    End Function

    Public Sub UpdateTotalesAlmacen(ByVal listadoAlmacenBE As List(Of totalesAlmacen), ByVal objDocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateTotalesAlmacen(listadoAlmacenBE, objDocumento)
    End Sub

    Public Function UpdateTotalesAlmacen2(ByVal listadoAlmacenBE As List(Of totalesAlmacen), ByVal objDocumento As Integer) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateTotalesAlmacen2(listadoAlmacenBE, objDocumento)
    End Function


    Public Function ObtenerCanastaDeVentaPorProducto(ByVal intIdAlmacen As Integer, ByVal strTipoExistencia As String,
                                                   strFiltroProducto As String) As List(Of totalesAlmacen)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCanastaDeVentaPorProducto(intIdAlmacen, strTipoExistencia, strFiltroProducto)
    End Function

    Function ObtenerCanastaDeVenta(ByVal intIdAlmacen As Integer, ByVal strTipoExistencia As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCanastaDeVenta(intIdAlmacen, strTipoExistencia)
    End Function

    Public Function GetListaProductosPorAlmacen(intIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProductosPorAlmacen(intIdAlmacen)
    End Function

    Public Function GetListaProductosPorAlmacenPorCategoria(intIdAlmacen As Integer, intCategoria As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProductosPorAlmacenPorCategoria(intIdAlmacen, intCategoria)
    End Function

    Public Function GetListaProductosPorAlmacenSinCategoria(intIdAlmacen As Integer, intCategoria As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProductosPorAlmacenSinCategoria(intIdAlmacen, intCategoria)
    End Function

    Public Function GetProductoPorTipoExistencia(intIdAlmacen As Integer, strTipoEx As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductoPorTipoExistencia(intIdAlmacen, strTipoEx)
    End Function

    Public Function GetProductosXempresa(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosXempresa(be)
    End Function

    Public Function GetUbicarProductoTAlmacen(intIdAlmacen As Integer, intIdItem As Integer) As totalesAlmacen
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarProductoTAlmacen(intIdAlmacen, intIdItem)
    End Function

    Public Sub GetChangeStatusArticuloRange(listaInventario As List(Of totalesAlmacen))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetChangeStatusArticuloRange(listaInventario)
    End Sub

    Public Function GetListaProductosTAPorProducto(intIdAlmacen As Integer, strBusqueda As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProductosTAPorProducto(intIdAlmacen, strBusqueda)
    End Function



    Public Function GetProductoPorAlmacenTipoExTodo(intIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductoPorAlmacenTipoExTodo(intIdAlmacen)
    End Function



    Public Function GetProductoPorAlmacenTipoEx(intIdAlmacen As Integer, strTipoEx As String, strBusqueda As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductoPorAlmacenTipoEx(intIdAlmacen, strTipoEx, strBusqueda)
    End Function

    Public Function GetListadoProductosParaVentaXbarCode(objTotalBE As totalesAlmacen) As totalesAlmacen
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoProductosParaVentaXbarCode(objTotalBE)
    End Function

    Public Function GetListadoProductosParaVentaXproducto(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoProductosParaVentaXproducto(objTotalBE)
    End Function

    Public Function GetUbicarTotalesAlmacen(strIdEmpresa As String, intIdEstablecimiento As Integer, strIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarTotalesAlmacen(strIdEmpresa, intIdEstablecimiento, strIdAlmacen)
    End Function

    Public Function GetListaProductosTAPorProductoByTake(intIdAlmacen As Integer, strBusqueda As String) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProductosTAPorProductoByTake(intIdAlmacen, strBusqueda)
    End Function

    Public Function GetNotificacionAlmacen() As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNotificacionAlmacen()
    End Function

    Public Function GetListadoProductosParaVentaXproductoXAlmacen(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoProductosParaVentaXproductoXAlmacen(objTotalBE)
    End Function

    Public Function GetListadoProductosParaVentaXproductoXAlmacenFull(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoProductosParaVentaXproductoXAlmacenFull(objTotalBE)
    End Function

#Region "MARTIN"
    Public Function GetListaProductosPorItems(intIdAlmacen As Integer, intitem As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProductosPorItems(intIdAlmacen, intitem)
    End Function


    Public Function GetListaAlmacenDetalle(idempresa As String, idestablecimiento As Integer) As List(Of totalesAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaAlmacenDet(idempresa, idestablecimiento)
    End Function

    Public Function GetListaItemsProd(intempre As String, idestabl As Integer) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProdItems(intempre, idestabl)
    End Function

#End Region
End Class
