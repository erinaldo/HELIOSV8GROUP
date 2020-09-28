Imports Helios.Cont.Business.Entity
Public Class recursoCostoDetalleSA

    Public Sub GrabarDetalleCosteoReal(be As List(Of recursoCostoDetalle), idEntregable As Integer, idDocumento As Integer, secuencia As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDetalleCosteoReal(be, idEntregable, idDocumento, secuencia)
    End Sub

    Public Function GetListadoRecursosPorEntregableCosteado(idEntregable As Integer, fechaPeriodo As DateTime) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoRecursosPorEntregableCosteado(idEntregable, fechaPeriodo)
    End Function

    Public Sub GrabarRecursoProduccion(be As List(Of recursoCostoDetalle))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarRecursoProduccion(be)
    End Sub

    Public Function GetListadoRecursosPorEntregable(idEntregable As Integer, fechaPeriodo As DateTime) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoRecursosPorEntregable(idEntregable, fechaPeriodo)
    End Function

    Public Sub GrabarDetalleRecursosLibro(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDetalleRecursosLibro(be, listaAsiento)
    End Sub

    Public Function GetListadoRecursosPorProyectoGeneral(be As recursoCosto) As List(Of usp_GetRecursosByProyectoGeneral_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoRecursosPorProyectoGeneral(be)
    End Function

    Public Sub GrabarDetalleRecursoFinanza(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDetalleRecursoFinanza(be, listaAsiento)
    End Sub

    Public Function GetListadoGastosConsolidados(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoGastosConsolidados(be)
    End Function

    Public Function GetRecursoPlaneadosPendientesAprobacion(be As recursoCostoDetalle) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRecursoPlaneadosPendientesAprobacion(be)
    End Function

    Public Function GetRecursoPlaneadoConteo(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRecursoPlaneadoConteo(be)
    End Function

    Public Function GetRecursosAsignadosByTipoCosto(be As recursoCostoDetalle) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRecursosAsignadosByTipoCosto(be)
    End Function

    Public Sub EditarRequerimeintoBySec(be As recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarRequerimeintoBySec(be)
    End Sub

    Public Sub EliminarDetalleCostoPlan(be As recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarDetalleCostoPlan(be)
    End Sub

    Public Sub EliminarCostoDetalleBySec(i As recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCostoDetalleBySec(i)
    End Sub

    Public Sub EditarDetalleRecursoTareaBySecuencia(be As recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarDetalleRecursoTareaBySecuencia(be)
    End Sub

    Public Sub GrabarDetalleRecursosByTarea(be As recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDetalleRecursosByTarea(be)
    End Sub

    Public Function GetReporteElmentoCostoAnual(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetReporteElmentoCostoAnual(be)
    End Function

    Public Function GetReporteElmentoCostoByProceso(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetReporteElmentoCostoByProceso(be)
    End Function

    Public Function GetSumaTotalElementoCosto(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaTotalElementoCosto(be)
    End Function

    Public Sub CambioAsigancion(be As recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambioAsigancion(be)
    End Sub

    Public Function GetSumaTotalImportesByCosto(be As recursoCosto) As recursoCosto
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaTotalImportesByCosto(be)
    End Function

    Public Function GetSumByCostoGastos(be As recursoCosto) As Double
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumByCostoGastos(be)
    End Function

    Public Function GetSumByCosto(be As recursoCosto) As Double
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumByCosto(be)
    End Function

    Public Function GetListadoRecursosByIdCosto(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoRecursosByIdCosto(be)
    End Function

    Public Function GetListadoRecursosByPadre(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoRecursosByPadre(be)
    End Function

    Public Function GetRecursosAsignadosByCosto(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRecursosAsignadosByCosto(be)
    End Function

    Public Function GetRecursosAsignadosByProceso(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRecursosAsignadosByProceso(be)
    End Function

    Public Function GetListadoRecursosByProceso(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListadoRecursosByProceso(be)
    End Function

    Public Function GetCountItemsByProceso(be As recursoCosto) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCountItemsByProceso(be)
    End Function

    Public Sub GrabarDetalleRecursos(be As List(Of recursoCostoDetalle), listaAsiento As List(Of asiento))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarDetalleRecursos(be, listaAsiento)
    End Sub

End Class
