Imports Helios.Cont.Business.Entity
Public Class recursoCostoSA

    Public Function GetEntregablesXSubProy(idEmpresa As String, idEstable As Integer, idSubProy As Integer, periodo As String) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEntregablesXSubProy(idEmpresa, idEstable, idSubProy, periodo)
    End Function

    Public Function GetGastosTipoAll(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetGastosTipoAll(idEmpresa, idEstable)
    End Function

    Public Function CierreDeEntregables(fechaPeriodo As DateTime, idEmpresa As String, idEstable As Integer) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CierreDeEntregables(fechaPeriodo, idEmpresa, idEstable)
    End Function

    Public Function GetProyectosAll(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProyectosAll(idEmpresa, idEstable)
    End Function

    Public Function GetEntregablesXProyecto(idEmpresa As String, idEstable As Integer) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEntregablesXProyecto(idEmpresa, idEstable)
    End Function

    Public Sub GrabarProyectoGeneral(be As recursoCosto, besubproy As recursoCosto, listaentregable As List(Of recursoCosto))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarProyectoGeneral(be, besubproy, listaentregable)
    End Sub

    Public Sub GrabarSubProyectoConstruccion(idProyecto As Integer, besubproy As recursoCosto, listaentregable As List(Of recursoCosto))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarSubProyectoConstruccion(idProyecto, besubproy, listaentregable)
    End Sub

    Public Sub GrabarProyectoConstruccion(be As recursoCosto, besubproy As recursoCosto, listaentregable As List(Of recursoCosto), plan As List(Of cuentaplanContableEmpresa))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarProyectoConstruccion(be, besubproy, listaentregable, plan)
    End Sub

    Public Function GetListaSubProyectos(recurso As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaSubProyectos(recurso)
    End Function

    Public Sub GetCulminarProduccion(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetCulminarProduccion(be)
    End Sub

    Public Sub GetEliminarEnvioAalmacen(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetEliminarEnvioAalmacen(be)
    End Sub

    Public Sub GetEliminarProductosEnPlanta(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetEliminarProductosEnPlanta(be)
    End Sub

    Public Sub GetCerrarPresupuesto(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetCerrarPresupuesto(be)
    End Sub

    Public Sub CulminarOrdenProduccionParcial(Be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CulminarOrdenProduccionParcial(Be)
    End Sub

    Public Function GetNumRecursosEnPlanta(be As recursoCosto) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNumRecursosEnPlanta(be)
    End Function

    Public Function GetNumRecursosConEntregaParcial(be As recursoCosto) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetNumRecursosConEntregaParcial(be)
    End Function

    Public Function GetOrdenesDeProduccionInfo(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetOrdenesDeProduccionInfo(be)
    End Function

    Public Function GetProductosProducidosEnPlanta(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosProducidosEnPlanta(be)
    End Function

    Public Function GetCantidadEntregadaProduccion(be As recursoCosto) As recursoCosto
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCantidadEntregadaProduccion(be)
    End Function

    Public Sub GrabarCostoProducido(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCostoProducido(be)
    End Sub

    Public Sub GrabarProduccionParcial(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarProduccionParcial(be)
    End Sub

    Public Function GetListaProtectosByProyGeneral(recurso As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProtectosByProyGeneral(recurso)
    End Function

    Public Function GetListaProyectosBySubTipo(recurso As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaProyectosBySubTipo(recurso)
    End Function

    Public Function GetSumaTotalByProyecto(be As recursoCostoDetalle) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetSumaTotalByProyecto(be)
    End Function

    Public Function GetProductosTerminadosByProyecto(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosTerminadosByProyecto(be)
    End Function

    Public Sub GrabarEntregable(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarEntregable(be)
    End Sub

    Public Sub EditarEntregable(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarEntregable(be)
    End Sub

    Public Sub EliminarEntregable(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarEntregable(be)
    End Sub

    Public Sub GetOpenActividad(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetOpenActividad(be)
    End Sub

    Public Sub GetPendingActividad(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetPendingActividad(be)
    End Sub

    Public Function GetPlaneamientoKanban(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPlaneamientoKanban(be)
    End Function

    Public Sub GetUpdateSecuencia(be As List(Of recursoCosto))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetUpdateSecuencia(be)
    End Sub

    Public Sub GetUpdatefechaActual(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetUpdatefechaActual(be)
    End Sub

    Public Sub GetCierreActividad(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetCierreActividad(be)
    End Sub

    Public Sub GetUpdateCronograma(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetUpdateCronograma(be)
    End Sub

    Public Function GetPlaneamientoActividades(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPlaneamientoActividades(be)
    End Function

    Public Function GetPlaneamientoEDT_Produccion(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPlaneamientoEDT_Produccion(be)
    End Function

    Public Function GetActividadProcesoByProyecto(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetActividadProcesoByProyecto(be)
    End Function

    Public Sub EditarStatusCostoByID(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarStatusCostoByID(be)
    End Sub

    Public Sub GrabarTask(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarTask(be)
    End Sub

    Public Sub EditarCostoTarea(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarCostoTarea(be)
    End Sub

    Public Sub EliminarProcesos(i As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarProcesos(i)
    End Sub

    Public Function GetTareasByProyecto(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTareasByProyecto(be)
    End Function

    Public Function GetProyectoByCodigoGenerado(recurso As recursoCosto) As recursoCosto
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProyectoByCodigoGenerado(recurso)
    End Function

    Public Function GetListaPryectosEnCarteraFull(recurso As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaPryectosEnCarteraFull(recurso)
    End Function

    Public Sub GetCulminarCostoProduccion(be As recursoCosto, documento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetCulminarCostoProduccion(be, documento)
    End Sub

    Public Function GetProductosTerminadosByCosto(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosTerminadosByCosto(be)
    End Function

    Public Sub EliminarCostoPadre(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCostoPadre(be)
    End Sub

    Public Sub GetEliminarCierreProduccion(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetEliminarCierreProduccion(be)
    End Sub

    Public Sub GetEliminarCierreCosto(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetEliminarCierreCosto(be)
    End Sub

    Public Sub GetCulminarCosto(be As recursoCosto, documento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetCulminarCosto(be, documento)
    End Sub

    Public Function GetResporteItemsByProyecto(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetResporteItemsByProyecto(be)
    End Function

    Public Function GetResporteItemsByGastos(be As recursoCosto) As List(Of recursoCostoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetResporteItemsByGastos(be)
    End Function

    Public Function GetCostoCount(subTipoCosto As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCostoCount(subTipoCosto)
    End Function

    Public Function GetElementosCostoByCosto(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetElementosCostoByCosto(be)
    End Function

    Public Function GetProcesosByCosto(be As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProcesosByCosto(be)
    End Function

    Public Sub GrabarCosto(be As recursoCosto, plan As List(Of cuentaplanContableEmpresa), listaProcesos As List(Of recursoCosto))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCosto(be, plan, listaProcesos)
    End Sub

    Public Sub GrabarCostoOne(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarCostoOne(be)
    End Sub

    Public Sub EditarCosto(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarCosto(be)
    End Sub

    Public Sub EliminarCosto(be As recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCosto(be)
    End Sub

    Public Function GetListaRecursosXtipo(recurso As recursoCosto) As List(Of recursoCosto)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaRecursosXtipo(recurso)
    End Function

    Public Function GetCostoById(be As recursoCosto) As recursoCosto
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCostoById(be)
    End Function

End Class
