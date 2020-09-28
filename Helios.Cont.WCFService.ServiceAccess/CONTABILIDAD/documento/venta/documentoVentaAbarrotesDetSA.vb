Imports Helios.Cont.Business.Entity
Public Class documentoVentaAbarrotesDetSA
    Public Function GetDetalleVentaGuiaSelventa(be As documentoventaAbarrotesDet) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDetalleVentaGuiaSelventa(be)
    End Function
    Public Function SumaNotasXidPadreItemVentaOpcionDefault(intIdSecuencia As Integer) As documentoventaAbarrotesDet
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaNotasXidPadreItemVentaOpcionDefault(intIdSecuencia)
    End Function

    Public Function ListadoNotasVentaDetalleHijos(intIdDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoNotasVentaDetalleHijos(intIdDocumento)
    End Function

    Public Function UbicarDetallePinturas(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDetallePinturas(intidDocumento)
    End Function

    Public Function GetVentasNotificadasAtendCompras(intIdDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentasNotificadasAtendCompras(intIdDocumento)
    End Function

    Public Sub DeleteItemVenta(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteItemVenta(documentoventaAbarrotesDetBE)
    End Sub

    Public Function GetListarAllVentasPorCajaAbierta(intIdPersona As Integer, fechaInicio As DateTime, fechaFin As DateTime) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasPorCajaAbierta(intIdPersona, fechaInicio, fechaFin)
    End Function

    Public Function GetListarAllVentasPorUsuarioGeneral(intIdPersona As List(Of String), fechaInicio As DateTime, fechaFin As DateTime, periodo As String, tipo As String) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasPorUsuarioGeneral(intIdPersona, fechaInicio, fechaFin, periodo, tipo)
    End Function

    Public Function GetListarAllVentasDetallado(idDocumento As Integer, tipoexistencia As String) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasDetallado(idDocumento, tipoexistencia)
    End Function

    Public Function usp_EditarDetalleVenta(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.usp_EditarDetalleVenta(intidDocumento)
    End Function

    Public Function Get_EditarDetalleVentaSinLote(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Get_EditarDetalleVentaSinLote(intidDocumento)
    End Function


    Public Function GetUbicar_documentoventaAbarrotesDetPorIDocumento(intidDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intidDocumento)
    End Function

    Public Function GetAnalisiRentabilidad(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strPeriodo As String) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAnalisiRentabilidad(strIdEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function GetUbicar_documentoventaAbarrotesDetPorID(Secuencia As Integer) As documentoventaAbarrotesDet
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentoventaAbarrotesDetPorID(Secuencia)
    End Function

    Public Function SumaNotasXidPadreItemVentas(intIdSecuencia As Integer) As documentoventaAbarrotesDet
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SumaNotasXidPadreItemVentas(intIdSecuencia)
    End Function

    Public Function GetListarAllVentasEntregablesDeMercaderia(intIdEstablec As Integer, strPeriodo As String, stridDocumento As Integer) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListarAllVentasEntregablesDeMercaderia(intIdEstablec, strPeriodo, stridDocumento)
    End Function


#Region "Restaurant"
    Public Sub DeletePedidoRestaurant(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotes)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeletePedidoRestaurant(documentoventaAbarrotesDetBE)
    End Sub

    Public Sub DeleteItemVentaRestaurant(ByVal documentoventaAbarrotesDetBE As documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteItemVentaRestaurant(documentoventaAbarrotesDetBE)
    End Sub

    Public Function GetUbicar_documentoventaAbarrotesXListaIdDocumento(docVentaAbarrotesBE As documentoventaAbarrotes) As List(Of documentoventaAbarrotesDet)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_documentoventaAbarrotesXListaIdDocumento(docVentaAbarrotesBE)
    End Function

    Public Function GetUbicar_ListaDocumento(docVentaAbarrotesBE As documentoventaAbarrotesDet) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_ListaDocumento(docVentaAbarrotesBE)
    End Function

    Public Sub updateMesa(ByVal InfraBE As distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.updateMesa(InfraBE)
    End Sub

#End Region

End Class
