Imports Helios.Cont.Business.Entity
Public Class DocumentoCompraDetalleSA

    Public Function GetProductosEntransitoEquivalencia(be As documentocompra) As List(Of inventarioTransito)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProductosEntransitoEquivalencia(be)
    End Function

    Public Sub EnvioDeServiciosAProduccion(i As List(Of documentocompradetalle))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EnvioDeServiciosAProduccion(i)
    End Sub

    Public Function GeDetalleCompraItemLote(codigoLote As Integer) As documentocompradetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GeDetalleCompraItemLote(codigoLote)
    End Function

    Public Function GetUbicarDetalleCompraLote(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarDetalleCompraLote(intIdDocumento)
    End Function

    Public Function SumaNotasFinancierasDefault(intIdSecuencia As Integer) As documentocompradetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaNotasFinancierasDefault(intIdSecuencia)
    End Function

    Public Function ListadoNotasDetalleHijos(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoNotasDetalleHijos(intIdDocumento)
    End Function

    Public Function SumaNotasXidPadreItemOpcionDefault(intIdSecuencia As Integer) As documentocompradetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaNotasXidPadreItemOpcionDefault(intIdSecuencia)
    End Function

    Public Function ListaServiciosOtrosAnticipado() As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaServiciosOtrosAnticipado()
    End Function

    Public Function GetCountItemsNoAsignados(compraBE As documentocompra) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCountItemsNoAsignados(compraBE)
    End Function

    Public Function GetUbicar_PorDocumento(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_PorDocumento(intIdDocumento)
    End Function

    Public Function ListaTotalXCompraDetalleAll(listaidPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String, strEmpresa As String, idEstablec As Integer, intAnio As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaTotalXCompraDetalleAll(listaidPersona, fechaInicio, fechaFin, periodo, tipo, strEmpresa, idEstablec, intAnio)
    End Function

    Public Function ListaComprasPorveedorOrArticulo(strEmpresa As String, intIdEstable As Integer, fecInic As DateTime, fecHasta As DateTime, idProv As Integer, tipo As String, nombreitem As String) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaComprasPorveedorOrArticulo(strEmpresa, intIdEstable, fecInic, fecHasta, idProv, tipo, nombreitem)
    End Function

    Public Sub QuitarAsignacionRecurso(i As documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.QuitarAsignacionRecurso(i)
    End Sub

    Public Sub UpdateCostoItem(i As documentocompradetalle, documento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateCostoItem(i, documento)
    End Sub

    Public Sub UpdateCostoItemSingle(i As documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateCostoItemSingle(i)
    End Sub

    Public Function ListaRecursoAsignadoByIdCostoSingle(i As documentocompradetalle, doccompra As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursoAsignadoByIdCostoSingle(i, doccompra)
    End Function

    Public Function ListaRecursoAsignadoByIdCosto(i As documentocompradetalle, doccompra As documentocompra) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursoAsignadoByIdCosto(i, doccompra)
    End Function

    Public Function UbicarDetalleCompraEval(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDetalleCompraEval(intIdDocumento)
    End Function

    Public Function SP_UbicarDetalleCompraControl(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SP_UbicarDetalleCompraControl(intIdDocumento)
    End Function

    Public Function GetUbicar_documentocompradetallePorCompraEx(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentocompradetallePorCompraEx(intIdDocumento)
    End Function

    Public Function ListaComprasXporveedor(fecInic As DateTime, fecHasta As DateTime, idProv As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaComprasXporveedor(fecInic, fecHasta, idProv)
    End Function

    Public Function SumaNotasXidPadreItem(intIdSecuencia As Integer) As documentocompradetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaNotasXidPadreItem(intIdSecuencia)
    End Function

    Public Function GetUbicar_documentocompradetallePorCompraSL(strSerie As String, strNroDoc As String, strSitucion As String, intIdProveedor As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentocompradetallePorCompraSL(strSerie, strNroDoc, strSitucion, intIdProveedor)
    End Function

    Public Function UltimasOtrasSalidasPorFecha(strEmpresa As String, intIdEstablecimiento As Integer, intCuota As Integer, intAlnacenConsulta As Integer, IntIdItem As String) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UltimasOtrasSalidasPorFecha(strEmpresa, intIdEstablecimiento, intCuota, intAlnacenConsulta, IntIdItem)
    End Function

    Public Function UbicarDocumentoCompraDetalle(intIdDocumento As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoCompraDetalle(intIdDocumento)
    End Function

    Public Function UltimasEntradasPorFecha(strEmpresa As String, intIdEstablecimiento As Integer, intAlnacenConsulta As Integer, IntIdItem As String) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UltimasEntradasPorFecha(strEmpresa, intIdEstablecimiento, intAlnacenConsulta, IntIdItem)
    End Function

    Public Sub DeleteCompraDetalle(nDocumento As documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteCompraDetalle(nDocumento)
    End Sub

    Public Function GetUbicar_documentocompradetallePorID(Secuencia As Integer) As documentocompradetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentocompradetallePorID(Secuencia)
    End Function

    Public Function TieneItemsEnAV(intIdDocumento As Integer) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.TieneItemsEnAV(intIdDocumento)
    End Function

    Public Function SumatoriaImportesCompra(intIdDocumento As Integer) As documentocompradetalle
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumatoriaImportesCompra(intIdDocumento)
    End Function

    Public Function GetUbicar_documentocompradetallePorItem(strNombreItem As String, strSitucion As String) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentocompradetallePorItem(strNombreItem, strSitucion)
    End Function

    Public Function GetUbicar_documentocompradetallePorCompra(strSerie As String, strNroDoc As String, strSitucion As String) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentocompradetallePorCompra(strSerie, strNroDoc, strSitucion)
    End Function

    Public Function UbicarDocumentoCompraDetalleSituacion(intIdDocumento As Integer, srtsituacion As String) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoCompraDetalleSituacion(intIdDocumento, srtsituacion)
    End Function

    Public Function GetUbicar_proveedorPorIdItem(stridEmpresa As String, intIdEstablec As Integer, intIdItem As Integer) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_proveedorPorIdItem(stridEmpresa, intIdEstablec, intIdItem)
    End Function

    Public Function GetUbicar_OrdenCompraHistorial(idDocumento As Integer, situacion As String) As List(Of documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_OrdenCompraHistorial(idDocumento, situacion)
    End Function

    Public Sub UpdateFullDocOrden(ByVal idDocumento As Integer, ByVal strSituacion As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateFullDocOrden(idDocumento, strSituacion)
    End Sub

    Public Sub actualizarEstadoTransitoItem(documentocompradetalle As documentocompradetalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.actualizarEstadoTransitoItem(documentocompradetalle)
    End Sub

    Public Sub EnvioProductosEnTransitoRapido(listaEnvios As List(Of inventarioTransito))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EnvioProductosEnTransitoRapido(listaEnvios)
    End Sub
End Class
