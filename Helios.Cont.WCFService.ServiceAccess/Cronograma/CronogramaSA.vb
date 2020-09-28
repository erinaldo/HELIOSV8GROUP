Imports Helios.Cont.Business.Entity
Public Class CronogramaSA
    Public Function GetListarCuotasDocumentoPagos(iddoc As Integer) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarCuotasDocumentoPagos(iddoc)
    End Function

    Public Function GetListarCuotasDocumento(idDocumento As Integer) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarCuotasDocumento(idDocumento)
    End Function

    Public Sub DeleteCronoDocumento(ByVal cronograma As List(Of Cronograma))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteCronoDocumento(cronograma)
    End Sub

    Public Function GetListarCronogramaDpcumento(idDocumento As Integer) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarCronogramaDpcumento(idDocumento)
    End Function


    Public Function GetCronogramaCobroFecha(TipoProg As String, FechaInicio As Date, FechaFin As Date) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaCobroFecha(TipoProg, FechaInicio, FechaFin)
    End Function

    Public Function ConteoVentasNoNegociados() As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConteoVentasNoNegociados()
    End Function

    Public Function ConteoDeNoNegociados() As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConteoDeNoNegociados()
    End Function


    Public Function ConteoDeAsientosNoNegociadosCobro() As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConteoDeAsientosNoNegociadosCobro()
    End Function

    Public Function ConteoDeAsientosNoNegociados() As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConteoDeAsientosNoNegociados()
    End Function


    Public Function ConteoVencidosCobroCronograma() As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConteoVencidosCobroCronograma()
    End Function

    Public Function ConteoVencidosCronograma() As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ConteoVencidosCronograma()
    End Function

    Public Function GetListarCobrosPorMes(tipoProg As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarCobrosPorMes(tipoProg)
    End Function

    Public Function GetListarPagosPorMes(tipoProg As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarPagosPorMes(tipoProg)
    End Function


    Public Function UbicarCronogramaVencidosCobro(TipoProg As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCronogramaVencidosCobro(TipoProg)
    End Function


    Public Function UbicarCronogramaVencidos(TipoProg As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCronogramaVencidos(TipoProg)
    End Function

    Public Function GetCronogramaTrabajo(mes As Integer, tipoMoneda As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaTrabajo(mes, tipoMoneda)
    End Function


    Public Function UbicarCronogramaPorEntidadCobro(idprov As Integer, tipoprov As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCronogramaPorEntidadCobro(idprov, tipoprov)
    End Function

    Public Function UbicarCronogramaPorEntidad(idprov As Integer, tipoprov As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCronogramaPorEntidad(idprov, tipoprov)
    End Function

    Public Function UbicarCronogramaFecha(TipoProg As String, FechaInicio As Date, FechaFin As Date) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCronogramaFecha(TipoProg, FechaInicio, FechaFin)
    End Function

    Public Function GetCronogramaDetalleTipoAsiento(idprov As Integer, tipo As String, tipoEstado As String, fechaprog As DateTime, tipomoneda As String, fechaven As DateTime) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaDetalleTipoAsiento(idprov, tipo, tipoEstado, fechaprog, tipomoneda, fechaven)
    End Function

    Public Function GetCronogramaPagoCobroHistorial(TipoProg As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaPagoCobroHistorial(TipoProg)
    End Function

    Public Function GetCronogramaDetalleTipoCobros(idprov As Integer, tipo As String, tipoEstado As String, fechaprog As DateTime, tipomoneda As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaDetalleTipoCobros(idprov, tipo, tipoEstado, fechaprog, tipomoneda)
    End Function

    Public Function GetCronogramaDetalleCobro(fechaprog As DateTime, fechaVen As DateTime) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaDetalleCobro(fechaprog, fechaVen)
    End Function

    Public Function GetCronogramaPagoCobro(TipoProg As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaPagoCobro(TipoProg)
    End Function

    Public Sub EliminarPagoProgramado(idDocumento As Integer, estado As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPagoProgramado(idDocumento, estado)
    End Sub

    Public Function GetPagosxProgramacion(idprov As Integer, tipo As String, tipoEstado As String, mes As Integer) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPagosxProgramacion(idprov, tipo, tipoEstado, mes)
    End Function

    Public Sub ActualizarEstadoLista(objDocumento As List(Of Cronograma))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateEstadoCronogramaLista(objDocumento)
    End Sub

    Public Function GetCronogramaDetalleTipo(idprov As Integer, tipo As String, tipoEstado As String, fechaprog As DateTime, tipomoneda As String, fechaVen As DateTime) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaDetalleTipo(idprov, tipo, tipoEstado, fechaprog, tipomoneda, fechaVen)
    End Function

    Public Function GetCronogramaDetalleTipoMes(idprov As Integer, tipo As String, tipoEstado As String, mes As Integer, tipoProg As String, tipoMoneda As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaDetalleTipoMes(idprov, tipo, tipoEstado, mes, tipoProg, tipoMoneda)
    End Function

    Public Function GetCronogramaTipoAsientoMes(idprov As Integer, tipo As String, tipoEstado As String, mes As Integer, tipoProg As String, tipoMoneda As String) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaTipoAsientoMes(idprov, tipo, tipoEstado, mes, tipoProg, tipoMoneda)
    End Function

    Public Function GetCronogramaDetalleAsiento(fechaprog As DateTime) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaDetalleAsiento(fechaprog)
    End Function


    Public Function GetCronogramaDetalle(fechaprog As DateTime, fechaVen As DateTime) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaDetalle(fechaprog, fechaVen)
    End Function

    Public Sub ActualizarEstadoDeleteCobro(objDocumento As Cronograma, iddoc As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateEstadoCronogramaDeleteCobro(objDocumento, iddoc)
    End Sub

    Public Sub ActualizarEstadoDelete(objDocumento As Cronograma, iddoc As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateEstadoCronogramaDelete(objDocumento, iddoc)
    End Sub

    Public Sub ActualizarEstado(objDocumento As Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateEstadoCronograma(objDocumento)
    End Sub


    Public Function GetCronogramaPendiente() As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaPendiente()
    End Function

    Public Sub ActualizarCronogramaHijo(objDocumento As Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateCronogramaHijo(objDocumento)
    End Sub




    Public Sub ActualizarGastoModulo(objDocumento As documentoLibroDiario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateGastoModulo(objDocumento)
    End Sub



    Public Sub DeleteHijoCronograma(ByVal intIdDocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteHijoCronograma(intIdDocumento)
    End Sub



    Public Function GetCronogramaTipo(fechaprog As DateTime, tipoprog As String, fechaVen As DateTime) As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronogramaTipo(fechaprog, tipoprog, fechaVen)
    End Function



    Public Function GetCronograma() As List(Of Cronograma)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCronograma()
    End Function



    Public Sub InsetCronograma(objDocument As IList(Of Cronograma))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertCronograma(objDocument)
    End Sub
End Class
