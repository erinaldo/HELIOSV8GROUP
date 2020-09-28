Imports Helios.Cont.Business.Entity
Public Class documentoAnticipoSA

    Public Function ObtenerSaldoReclamacion(idanticipo As Integer) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerSaldoReclamacion(idanticipo)
    End Function

    Public Function GetReclamacionesStatusVenta(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetReclamacionesStatusVenta(be)
    End Function

    Public Function GetCompromisoXDocumento(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCompromisoXDocumento(be)
    End Function

    Public Function GetReclamacionesStatusCompras(be As documentocompra) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetReclamacionesStatusCompras(be)
    End Function

    Public Function ObtenerSaldoReclamacionCobro(idanticipo As Integer) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerSaldoReclamacionCobro(idanticipo)
    End Function

    Public Function GetAnticiposOtorgadosStatusAll(be As documentocompra) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAnticiposOtorgadosStatusAll(be)
    End Function

    Public Function ObtenerSaldoAnticipoV2Compra(idanticipo As Integer) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerSaldoAnticipoV2Compra(idanticipo)
    End Function

    Public Function GetAnticipoRecibidosStatusAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAnticipoRecibidosStatusAll(be)
    End Function

    Public Function GetANTReclamacionesStatusCompra(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesStatusCompra(be)
    End Function

    Public Function GetDevolucionAntSeguimientoCompra(be As documentocompra) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDevolucionAntSeguimientoCompra(be)
    End Function

    Public Function GetANTReclamacionesPeriodoCompra(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesPeriodoCompra(be)
    End Function

    Public Function GetDevolucionesByDocumentoNotaCompra(be As documentocompra) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDevolucionesByDocumentoNotaCompra(be)
    End Function

    Public Function GetDevolucionVentaSeguimiento(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDevolucionVentaSeguimiento(be)
    End Function

    Public Function GetDevolucionCompraSeguimiento(be As documentocompra) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDevolucionCompraSeguimiento(be)
    End Function

    Public Function GetDevolucionAntSeguimiento(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDevolucionAntSeguimiento(be)
    End Function

    Public Function GetANTReclamacionesXDocumentoCompra(be As documentocompra) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesXDocumentoCompra(be)
    End Function

    Public Function GetAntReclamacionesProveedor(be As documentocompra) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAntReclamacionesProveedor(be)
    End Function

    Public Function GetDevolucionesByDocumentoNota(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDevolucionesByDocumentoNota(be)
    End Function

    Public Function GetANTReclamacionesStatusCount(be As documentoventaAbarrotes) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesStatusCount(be)
    End Function

    Public Function GetStatusNotaCreditoCount(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetStatusNotaCreditoCount(be)
    End Function

    Public Function GetANTReclamacionesStatusAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesStatusAll(be)
    End Function

    Public Function GetANTReclamacionesXDocumento(be As documentoventaAbarrotes) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesXDocumento(be)
    End Function

    Public Function GetANTReclamacionesPersona(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesPersona(be)
    End Function

    Public Function GetANTReclamacionesPersonaAll(be As documentoventaAbarrotes) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesPersonaAll(be)
    End Function

    Public Sub GetChangeEstadoAnticipo(be As documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetChangeEstadoAnticipo(be)
    End Sub

    Public Function GetANTReclamacionesPeriodo(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesPeriodo(be)
    End Function

    Public Function GetANTReclamacionesStatus(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesStatus(be)
    End Function

    Public Function ObtenerSaldoAnticipoV2(idanticipo As Integer) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerSaldoAnticipoV2(idanticipo)
    End Function

    Public Function GetStatusAprobacionAnticiposList(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetStatusAprobacionAnticiposList(be)
    End Function

    Public Function GetStatusAprobacionAnticipos(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetStatusAprobacionAnticipos(be)
    End Function

    Public Function ObtenerSaldoAnticipoPersona(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerSaldoAnticipoPersona(be)
    End Function

    Public Function GetAnticiposPeriodo(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAnticiposPeriodo(be)
    End Function

    Public Function GetEscaneadasAnticiposList(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEscaneadasAnticiposList(be)
    End Function

    Public Function SaveAnticipoDevolucion(nDocumento As documento, nDocCaja As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveAnticipoDevolucion(nDocumento, nDocCaja)
    End Function

    Public Function SaveAnticipo(be As documento) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveAnticipo(be)
    End Function

    Public Function SaldoAnticipo(idanticipo As Integer) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerSaldoAnticipo(idanticipo)
    End Function


    Public Function getTableAnticiposPorTipoProvee(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String, idproveedor As Integer) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getTableAnticiposTipoPersonal(strIdEmpresa, intIdEstablecimiento, strPeriodo, tipo, idproveedor)
    End Function

    Public Function ListadoAnticiposDetalleHijos(intIdDocumento As Integer) As List(Of documentoAnticipoDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoAnticiposDetalleHijos(intIdDocumento)
    End Function

    Public Function ListadoComprobatenAnticipos(iNtPadre As Integer) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoComprobanteAnticipo(iNtPadre)
    End Function


    Public Function getTableAnticiposMontoActual(idproveedor As Integer, tipo As String) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerAnticiposMontoActual(idproveedor, tipo)
    End Function

    Public Function getTableAnticiposPorPeriodoTipo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getTableAnticiposPorPeriodoTipo(strIdEmpresa, intIdEstablecimiento, strPeriodo, tipo)
    End Function

    Public Function UbicarAnticipoPorProveedorNroVoucher(intIdProveedor As Integer) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarAnticipoPorProveedorNroVoucher(intIdProveedor)
    End Function

    Public Function getTableAnticiposPorPeriodo(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getTableAnticiposPorPeriodo(strIdEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Public Function SaveAnticipoSL(nDocumento As documento, nDocCaja As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveAnticipoSL(nDocumento, nDocCaja)
    End Function

    Public Sub UpdateAnticipoSL(nDocumento As documento, nDocCaja As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateAnticipoSL(nDocumento, nDocCaja)
    End Sub

    Public Function UbicarDocumentoAnticipo(idDocumento As Integer) As documentoAnticipo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarDocumentoAnticipo(idDocumento)
    End Function

    Public Function ObtenerOtrosAportesXFinanzas(strEmpresa As String, intIdEstablecimiento As Integer, strRuc As String, strPeriodo As String, tipo As String) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerOtrosAportesXFinanzas(strEmpresa, intIdEstablecimiento, strRuc, strPeriodo, tipo)
    End Function

    Public Function ObtenerOtrosAportesXFinanzasFull(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String, tipo As String) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerOtrosAportesXFinanzasFull(strEmpresa, intIdEstablecimiento, strPeriodo, tipo)
    End Function

#Region "Restaurant"
    Public Function GetANTReclamacionesPeriodoXCliente(be As documentoAnticipo) As List(Of documentoAnticipo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetANTReclamacionesPeriodoXCliente(be)
    End Function
#End Region

End Class
