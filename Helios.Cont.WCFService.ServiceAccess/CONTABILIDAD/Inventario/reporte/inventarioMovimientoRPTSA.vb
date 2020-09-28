Imports Helios.Cont.Business.Entity
Public Class inventarioMovimientoRPTSA
    Public Function ObtenerProdPorAlmacenesPeriodoRPT(ByVal idAlmacen As String, ByVal strItem As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdPorAlmacenesPeriodoRPT(idAlmacen, strItem, periodo, mes)
    End Function

    Public Function ObtenerProdPorAlmacenesDiaRPT(ByVal idAlmacen As String, ByVal strItem As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerProdPorAlmacenesDiaRPT(idAlmacen, strItem)
    End Function

    Public Function ObtenerKardexPorAlmacenAnio(ByVal idAlmacen As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerKardexPorAlmacenAnio(idAlmacen, Anio)
    End Function

    Public Function ReporteKardexPorProducto(ByVal idAlmacen As String, iNtProducto As Integer, ByVal fecDesde As DateTime, ByVal fecHasta As DateTime) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ReporteKardexPorProducto(idAlmacen, iNtProducto, fecDesde, fecHasta)
    End Function

    Public Function ObtenerKardexPorAlmacenMes(ByVal idAlmacen As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerKardexPorAlmacenMes(idAlmacen, periodo, mes)
    End Function

    Public Function ObtenerKardexPorAlmacenDia(ByVal idAlmacen As String) As List(Of InventarioMovimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerKardexPorAlmacenDia(idAlmacen)
    End Function


End Class
