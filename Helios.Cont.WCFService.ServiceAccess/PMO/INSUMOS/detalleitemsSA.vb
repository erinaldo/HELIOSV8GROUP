Imports Helios.Cont.Business.Entity
Public Class detalleitemsSA
    Public Function GetProductsCodeUnidadComercialAlmacen(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductsCodeUnidadComercialAlmacen(be)
    End Function
    Public Function GetProductsCodeUnidadComercial(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductsCodeUnidadComercial(be)
    End Function
    Public Function GetProductsCodigoInterno(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductsCodigoInterno(be)
    End Function

    Public Function GetProductsCodigoInternoAlmacen(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductsCodigoInternoAlmacen(be)
    End Function

    Public Function GetProductosLoteDetalle(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosLoteDetalle(be)
    End Function
    Public Function GetProductosWithEquivalenciasParam(be As detalleitems, opcion As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithEquivalenciasParam(be, opcion)
    End Function


    Public Function GetProductosWithInventarioCodigos(be As detalleitems, opcion As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithInventarioCodigos(be, opcion)
    End Function
    Public Function GetProductosWithInventarioParam(be As detalleitems, opcion As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithInventarioParam(be, opcion)
    End Function
    Public Function GetProductosWithEquivalenciasSelCategory(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithEquivalenciasSelCategory(be)
    End Function

    Public Sub EditarImageUrlProducto(item As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarImageUrlProducto(item)
    End Sub

    Public Function GetProductsBarCodeAlmacen(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductsBarCodeAlmacen(be)
    End Function
    Public Function GetProductsBarCode(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductsBarCode(be)
    End Function

    Public Sub EditarValoresRentabilidadCompra(item As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarValoresRentabilidadCompra(item)
    End Sub

    Public Function GetProductosWithInventarioAlmacen(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithInventarioAlmacen(be)
    End Function

    Public Function GetProductosWithEquivalenciasEstablecimiento(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithEquivalenciasEstablecimiento(be)
    End Function

    Public Function GetUbicaProductoID(intIdProducto As Integer) As detalleitems
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaProductoID(intIdProducto)
    End Function

    Public Function GetProductosWithInventario(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithInventario(be)
    End Function

    Public Function GetProductosWithInventarioTipoAlmacen(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithInventarioTipoAlmacen(be)
    End Function

    Public Function GetProductosWithEquivalenciasV2(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithEquivalenciasV2(be)
    End Function

    Public Function GetProductosWithEquivalencias(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithEquivalencias(be)
    End Function

    Public Function GetArticulosSinAlmacenSearchCodigo(empresa As String, search As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetArticulosSinAlmacenSearchCodigo(empresa, search)
    End Function

    Public Function GetDetalleItemsXEmpresaAll(empresa As String, estable As Integer, tipoex As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDetalleItemsXEmpresaAll(empresa, estable, tipoex)
    End Function

    Public Function GetProductosSinAsignarPrecios(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosSinAsignarPrecios(be)
    End Function

    Public Function GetArticulosSinAlmacenSearchText(empresa As String, search As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetArticulosSinAlmacenSearchText(empresa, search)
    End Function

    Public Function GetArticulosSinAlmacen(empresa As String, opcion As Byte) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetArticulosSinAlmacen(empresa, opcion)
    End Function

    Public Function GetDetalleItemsXEmpresa(empresa As String, idEstable As Integer, tipoex As String, search As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDetalleItemsXEmpresa(empresa, idEstable, tipoex, search)
    End Function

    Public Function GetArticulosSytem(empresa As String, search As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetArticulosSytem(empresa, search)
    End Function

    Public Function GetProductsSistemaByEmpresa(be As detalleitems) As List(Of usp_GetProductsSistema_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductsSistemaByEmpresa(be)
    End Function

    Public Function GetPrecioPorProducto(idempresa As String, idProducto As Integer) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPrecioPorProducto(idempresa, idProducto)
    End Function

    Public Function GetProductosBusquedaPersonalizada(be As detalleitems, caso As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosBusquedaPersonalizada(be, caso)
    End Function

    Public Sub EliminarProductoSinInventario(be As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarProductoSinInventario(be)
    End Sub

    Public Function GetExistenciasByempresaNombreFull(idempresa As String, nombre As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciasByempresaNombreFull(idempresa, nombre)
    End Function

    Public Function GetTipoExistenciasByEmpresaConPrecios(empresa As String, tipo As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTipoExistenciasByEmpresaConPrecios(empresa, tipo)
    End Function

    Public Function GetItemsByDescripcion(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetItemsByDescripcion(be)
    End Function

    Public Function SubProductosEntregables(idEntregable As Integer) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SubProductosEntregables(idEntregable)
    End Function

    Public Function GetExistenciasByempresaNombre(nombre As String, empresaID As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciasByempresaNombre(nombre, empresaID)
    End Function

    Public Function GetExistenciasByempresaCodigo(idempresa As String, idEstable As Integer, codigobarra As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciasByempresaCodigo(idempresa, idEstable, codigobarra)
    End Function


    Public Function GetUbicarProductoXcodigoBarra(ByVal idEmpresa As String, idEstablec As Integer, codigobarra As String) As detalleitems
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarProductosXcodigoBarra(idEmpresa, idEstablec, codigobarra)
    End Function


    Public Function GetExistenciasByempresa() As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciasByempresa()
    End Function

    Public Function GetTipoExistenciasByempresa(tipo As Integer) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTipoExistenciasByempresa(tipo)
    End Function

    Public Function GetExistenciaByCodeBar(intCodigoBar As String) As detalleitems
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciaByCodeBar(intCodigoBar)
    End Function

    Public Function GetExistenciasByEstablecimiento(intEstable As Integer) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciasByEstablecimiento(intEstable)
    End Function

    Public Function GetExistenciasByEstablecimientoEspecial(intEstable As Integer) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciasByEstablecimientoEspecial(intEstable)
    End Function

    Public Function GetUbicarProductoXIdHijo(ByVal idEmpresa As String, idEstablec As Integer, idItem As Integer, tipo As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarProductosXIdHijo(idEmpresa, idEstablec, idItem, tipo)
    End Function

    Public Function GetUbicarProductoXdescripcion2(ByVal idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String, strBusqueda As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarProductoXdescripcion2(idEmpresa, idEstablec, intIdCategoria, strTipoExistencia, strBusqueda)
    End Function

    Public Sub ListadoItemsDeInicio(ByVal list As List(Of detalleitems), documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListadoItemsDeInicio(list, documentoBE)
    End Sub

    Public Function ReviewProductos(ProductoBE As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ReviewProductos(ProductoBE)
    End Function

    Public Sub DeleteProductoAllReferences(ByVal ProductoBE As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteProductoAllReferences(ProductoBE)
    End Sub

    Public Function InsertItemDualTabla(ByVal ProductoBE As detalleitems) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertItemDualTabla(ProductoBE)
    End Function

    Public Function GetUbicarProductoXdescripcion(ByVal idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String, strBusqueda As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarProductoXdescripcion(idEmpresa, idEstablec, intIdCategoria, strTipoExistencia, strBusqueda)
    End Function

    Public Sub SaveProducto(nProducto As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveProducto(nProducto)
    End Sub

    Public Function InsertNuevaItems(nProducto As detalleitems) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertNuevaItems(nProducto)
    End Function

    Public Sub SaveListaProducto(nListaProducto As List(Of detalleitems))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveListaProducto(nListaProducto)
    End Sub

    Public Sub UpdateProducto(nProducto As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateProducto(nProducto)
    End Sub

    Public Sub DeleteProducto(nProducto As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteProducto(nProducto)
    End Sub

    Public Function GetUbicarDetalleItems(strempresa As String, intestablec As Integer, strNombre As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        'Dim miLista As New List(Of detalleitems)
        Return miServicio.GetUbicarDetalleItems(strempresa, intestablec, strNombre)
        'Return miLista
    End Function

    Public Function ListaProductosClasificados(intEstable As Integer, intIdCategoria As Integer) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As New List(Of detalleitems)
        miLista = miServicio.GetProductoClasificado(intEstable, intIdCategoria)
        Return miLista
    End Function

    Public Function GetUbicarDetalleItemTipoExistencia(ByVal idEmpresa As String, idEstablec As Integer, intIdCategoria As Integer, strTipoExistencia As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarDetalleItemTipoExistencia(idEmpresa, idEstablec, intIdCategoria, strTipoExistencia)
    End Function

    Public Sub CambiarEstadoItem(be As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarEstadoItem(be)
    End Sub

    Public Function InvocarProductoID(intIdProducto As Integer) As detalleitems
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaProductoID(intIdProducto)
    End Function

    Public Function InvocarProductoNombre(strNomProducto As String, strIdEmpresa As String, intIdEstable As Integer) As detalleitems
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaProductoNombre(strNomProducto, strIdEmpresa, intIdEstable)
    End Function

    Public Function InsertDetalle(ByVal itemBE As detalleitems) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertDetalle(itemBE)
    End Function

    Public Function GetUbicarProductoXNotificacion(ByVal idEmpresa As String, idEstablec As Integer, intIdItem As Integer) As detalleitems
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarProductoXNotificacion(idEmpresa, idEstablec, intIdItem)
    End Function

    Public Sub actualizarPrecioCompra(be As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.actualizarPrecioCompra(be)
    End Sub

#Region "REstaurant"

    Public Function GetProductosWithEquivalenciasXCat(be As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosWithEquivalenciasXCat(be)
    End Function

    Public Function GetUbicarProductoXMarca(ByVal detalleItemBE As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarProductoXMarca(detalleItemBE)
    End Function

    Public Sub actualizarMarcaProducto(be As detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.actualizarMarcaProducto(be)
    End Sub

    Public Function GetUbicarProductoXTipoExistencia(ByVal idEmpresa As String, idEstablec As Integer, strTipoExistencia As String) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarProductoXTipoExistencia(idEmpresa, idEstablec, strTipoExistencia)
    End Function

    Public Function GetExistenciasXTipoExistencia(detalleitemsBE As detalleitems) As List(Of detalleitems)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciasXTipoExistencia(detalleitemsBE)
    End Function

#End Region

    Public Function InsertCopyItemXIdEsblecimiento(ByVal itemBE As detalleitems) As detalleitems
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertCopyItemXIdEsblecimiento(itemBE)
    End Function

End Class
