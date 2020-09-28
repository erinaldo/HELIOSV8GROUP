Imports Helios.Cont.Business.Entity
Public Class inventarioMovimientoSA

    Public Sub EliminarItemOperation(inventario As InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarItemOperation(inventario)
    End Sub

    Public Function GetUbicar_InventarioMovimiento(idDocumento As Integer) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_InventarioMovimiento(idDocumento)
    End Function

    Public Function GetMovimientosLote(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosLote(be)
    End Function

    Public Function GetMovimientosKardexByExistencia(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosKardexByExistencia(be, cierre)
    End Function

    Public Function GetRentabilidadPorComprobante(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRentabilidadPorComprobante(be)
    End Function

    Public Function GetMovimientosKardexByMesSustentado(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosKardexByMesSustentado(be, cierre)
    End Function

    Public Function GetRentabilidad(be As InventarioMovimiento, fechaini As Date, fechafin As Date, tipo As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRentabilidad(be, fechaini, fechafin, tipo)
    End Function

    Public Function GetRentabilidadV2(be As InventarioMovimiento, fechaini As Date, fechafin As Date, tipo As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRentabilidadV2(be, fechaini, fechafin, tipo)
    End Function

    Public Function GetListaInicioExistencia(fechaInicio As Date, idempresa As String, almacen As Integer) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaInicioExistencia(fechaInicio, idempresa, almacen)
    End Function

    Public Function GetMovimientosKardexByMesAllAlmacen(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosKardexByMesAllAlmacen(be)
    End Function

    Public Function GetMovimientosKardexByArticulo(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosKardexByArticulo(be, cierre)
    End Function

    Public Function GetMovimientosKardexByArticuloSNAT(be As InventarioMovimiento, cierre As cierreinventario) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosKardexByArticuloSNAT(be, cierre)
    End Function

    Public Function GetMovimientosKardexByMes(be As InventarioMovimiento, cierre As cierreinventario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosKardexByMes(be, cierre)
    End Function

    Public Function GetExistenciaTransitoByCompra(be As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciaTransitoByCompra(be)
    End Function

    Public Function GetExistenciaTransitoByProveedor(be As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetExistenciaTransitoByProveedor(be)
    End Function

    Public Function GetComprobantesEnTransito(be As documentocompra) As List(Of documentocompra)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetComprobantesEnTransito(be)
    End Function

    Public Function GetCostoVentaMensual(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCostoVentaMensual(be)
    End Function

    Public Function GetKardexByAnioAlmacenAll(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexByAnioAlmacenAll(be)
    End Function

    Public Function GetSelXtipoExistenciaVenta(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSelXtipoExistenciaVenta(be)
    End Function

    Public Function GetKardexByfechaDocumentoLote(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexByfechaDocumentoLote(be)
    End Function

    Public Function GetKardexByDiaLaboral_1(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexByDiaLaboral_1(be)
    End Function

    Public Function GetKardexByDia(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexByDia(be)
    End Function

    Public Function GetKardexByAnioDiaLaboral(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexByAnioDiaLaboral(be)
    End Function

    Public Function GetKardexByAnioDiaLaboralLote(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexByAnioDiaLaboralLote(be)
    End Function

    Public Function GetProveedoresEnTransito(be As documentocompra) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProveedoresEnTransito(be)
    End Function

    Public Function GetKardexPeridoByExistencia(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexPeridoByExistencia(be)
    End Function

    Public Sub GrabarEnvioTransito(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarEnvioTransito(be)
    End Sub

    Public Function GetKardexByPerido(be As InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexByPerido(be)
    End Function

    Public Function GetKardexByAnio(be As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetKardexByAnio(be)
    End Function

    Public Function ObtenerProdXAlmacenesXMesAllXExist(ByVal idAlmacen As String, ByVal periodo As Integer, ByVal mes As String, ByVal tipo As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdXAlmacenesXMesAllXExisten(idAlmacen, periodo, mes, tipo)
    End Function

    Public Function MostrarCierreInvPorPeriodo(inventarioMov As InventarioMovimiento) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.MostrarCierreInvPorPeriodo(inventarioMov)
    End Function

    Public Function ObtenerMarcaPorAlmacenesPorAnio(ByVal idAlmacen As String, ByVal marca As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMarcaPorAlmacenesPorAnio(idAlmacen, marca, Anio)
    End Function

    Public Sub editarTrasnferenciaItem(inventario As InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.editarTrasnferenciaItem(inventario)
    End Sub

    Public Function ObtenerMarcaPorAlmacenes(ByVal idAlmacen As String, ByVal marca As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMarcaPorAlmacenes(idAlmacen, marca)
    End Function


    Function ObtenerMarcaPorAlmacenesPorMes(ByVal idAlmacen As String, ByVal marca As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMarcaPorAlmacenesPorMes(idAlmacen, marca, periodo, mes)
    End Function

    Public Function ObtenerKardexRangoFecha(ByVal idAlmacen As String, fecDesde As Date, fecHasta As Date) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerKardexRangoFecha(idAlmacen, fecDesde, fecHasta)
    End Function

    Public Function ObtenerProdPorAlmacenesPorMesAll(ByVal idAlmacen As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdPorAlmacenesPorMesAll(idAlmacen, periodo, mes)
    End Function

    Function ObtenerProdPorAlmacenesXdiaAll(ByVal idAlmacen As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdPorAlmacenesXdiaAll(idAlmacen)
    End Function

    Public Function ObtenerProdPorAlmacenesPorAnio(ByVal idAlmacen As String, ByVal strItem As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdPorAlmacenesPorAnio(idAlmacen, strItem, Anio)
    End Function

    Public Function ObtenerProdPorAlmacenesPorAnioAll(ByVal idAlmacen As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdPorAlmacenesPorAnioAll(idAlmacen, Anio)
    End Function

    Public Function GetMovimientosKardexByMesAllAlmacenXusuario(be As InventarioMovimiento, listaUsuario As List(Of String), tipo As String, periodo As String, fechainicio As DateTime, fechaFin As DateTime) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosKardexByMesAllAlmacenXusuario(be, listaUsuario, tipo, periodo, fechainicio, fechaFin)
    End Function

    Public Function GetMovimientosKardexByMesXusuario(be As InventarioMovimiento, listaUsuario As List(Of String), tipo As String, periodo As String, fechainicio As DateTime, fechaFin As DateTime) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosKardexByMesXusuario(be, listaUsuario, tipo, periodo, fechainicio, fechaFin)
    End Function

    Public Function GetUbicar_InventarioMovimientoCompra(idDocumento As Integer, strTipoRegistro As String) As InventarioMovimiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_InventarioMovimientoCompra(idDocumento, strTipoRegistro)
    End Function

    Public Function ObtenerProdPorAlmacenes(ByVal idAlmacen As String, ByVal strItem As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdPorAlmacenes(idAlmacen, strItem)
    End Function

    Public Function ObtenerItemsPorAlmacen(ByVal idAlmacen As Integer) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerItemsPorAlmacen(idAlmacen)
    End Function

    Function ObtenerProductosEnTransito(ByVal strIdEmpresa As String, ByVal strIdEstablecimiento As String, ByVal strTipoAlmacen As String, ByVal Mes As String, ByVal Anio As String, ByVal strTipoProducto As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProductosEnTransito(strIdEmpresa, strIdEstablecimiento, strTipoAlmacen, Mes, Anio, strTipoProducto)
    End Function

    Public Function ObtenerProductosEnTransitoPorDocumento(ByVal strIdEmpresa As String, ByVal strIdEstablecimiento As String, ByVal strTipoAlmacen As String, ByVal Mes As String, ByVal Anio As String, ByVal strTipoProducto As String,
                                                         strNumDocCompra As String) As List(Of InventarioMovimiento)

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProductosEnTransitoPorDocumento(strIdEmpresa, strIdEstablecimiento, strTipoAlmacen, Mes, Anio, strTipoProducto, strNumDocCompra)
    End Function

    Public Sub InsertItemsEnTransito(ByVal objSalida As List(Of InventarioMovimiento),
                             ByVal objEntrada As List(Of InventarioMovimiento),
                             ByVal listaAsiento As List(Of asiento),
                             ByVal objTotalesAlmacen As List(Of totalesAlmacen),
                             documento As documento, totalesAlmAV As List(Of Business.Entity.totalesAlmacen))

        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertItemsEnTransito(objSalida, objEntrada, listaAsiento, objTotalesAlmacen, documento, totalesAlmAV)

    End Sub

    Public Sub InsertItemsEnTransitoSL(ByVal objSalida As List(Of InventarioMovimiento),
                            ByVal objEntrada As List(Of InventarioMovimiento),
                            ByVal listaAsiento As List(Of asiento),
                            ByVal objTotalesAlmacen As List(Of totalesAlmacen),
                            documento As documento, totalesAlmAV As List(Of Business.Entity.totalesAlmacen),
                            ByVal objListaPrecios As List(Of listadoPrecios))

        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertItemsEnTransitoSL(objSalida, objEntrada, listaAsiento, objTotalesAlmacen, documento, totalesAlmAV, objListaPrecios)

    End Sub

    Public Function ObtenerProductosalmacenEstablec(strEmpresa As String, intIdEstablecimiento As Integer, ByVal idAlmacen As String,
                                  ByVal desde As Date, ByVal hasta As Date) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoProductoEstablec(strEmpresa, intIdEstablecimiento, idAlmacen, desde, hasta)
    End Function

    Public Function ObtenerProductosalmacen(strEmpresa As String, intIdEstablecimiento As Integer, ByVal idAlmacen As String, ByVal strItem As String,
                                  ByVal desde As Date, ByVal hasta As Date) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OntenerListadoProductoAlmacen(strEmpresa, intIdEstablecimiento, idAlmacen, strItem, desde, hasta)
    End Function


    Function ObtenerProdPorAlmacenesPorMes(ByVal idAlmacen As String, ByVal strItem As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdPorAlmacenesPorMes(idAlmacen, strItem, periodo, mes)
    End Function


    Function ObtenerProdPorAlmacenesPorRango(ByVal idAlmacen As String, ByVal strItem As String, ByVal desde As Date, ByVal hasta As Date) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdPorAlmacenesPorRango(idAlmacen, strItem, desde, hasta)
    End Function

    Public Sub EditarArticuloInicio(inv As InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarArticuloInicio(inv)
    End Sub

    Public Sub EliminarArticuloInicio(inv As InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarArticuloInicio(inv)
    End Sub
End Class
