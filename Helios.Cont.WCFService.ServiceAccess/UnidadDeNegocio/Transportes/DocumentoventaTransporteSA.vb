Imports Helios.Cont.Business.Entity

Public Class DocumentoventaTransporteSA

    Public Sub UpdateAnulacionEnviada(objDocumento As Integer, idNum As Integer, nroTicket As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateAnulacionEnviada(objDocumento, idNum, nroTicket)
    End Sub

    Public Sub ReenviarDocumentoEliminado(idDocumento As Integer, idPse As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ReenviarDocumentoEliminado(idDocumento, idPse)
    End Sub

    Public Function GetEncomiendasSelAgenciaDestinoMes(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEncomiendasSelAgenciaDestinoMes(be)
    End Function

    Public Function GetCiudadesPorEntregarOrigenFecha(be As documentoventaTransporte, opcion As String) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCiudadesPorEntregarOrigenFecha(be, opcion)
    End Function

    Public Function GetResumenVentasSelCajero(be As documentoCaja) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetResumenVentasSelCajero(be)
    End Function

    Public Function GetConsultaEncomiendasSelMes(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultaEncomiendasSelMes(be)
    End Function

    Public Function GetConsultaTransporteSelMes(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultaTransporteSelMes(be)
    End Function

    Public Function GetEncomiendasSelCajero(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEncomiendasSelCajero(be)
    End Function


    Public Function BuscarDocumentosAnuladosPeriodoTrans(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarDocumentosAnuladosPeriodoTrans(fecha, tipodoc, ruc)
    End Function

    Public Function BuscarDocumentosAnuladosFechaTrans(fecha As DateTime, tipodoc As String, ruc As String) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarDocumentosAnuladosFechaTrans(fecha, tipodoc, ruc)
    End Function

    Public Function BuscarFacturanoEnviadasTrans(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarFacturanoEnviadasTrans(fecha, tipoDoc, idEmpresa)
    End Function

    Public Function DocumentosAnuladosPendientesTransporte(fecha As DateTime, ruc As String) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentosAnuladosPendientesTransporte(fecha, ruc)
    End Function

    Public Function ListaCpePendientesDeEnvioTransporte(fecha As DateTime, idEmpresa As String) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaCpePendientesDeEnvioTransporte(fecha, idEmpresa)
    End Function

    Public Function BuscarFacturanoEnviadasPeriodoTrans(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarFacturanoEnviadasPeriodoTrans(fecha, tipoDoc, idEmpresa)
    End Function


    Public Function BuscarBoletasAnuladasPeriodoTrans(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarBoletasAnuladasPeriodoTrans(fecha, IdEmpresa)
    End Function

    Public Function BuscarBoletasAnuladasTrans(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarBoletasAnuladasTrans(fecha, IdEmpresa)
    End Function

    Public Sub ListaEnvioSunatAnuladosTrans(lista As List(Of documentoventaTransporte), nroticket As String, idNum As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListaEnvioSunatAnuladosTrans(lista, nroticket, idNum)
    End Sub


    Public Sub ListaEnvioSunatResumenTrans(lista As List(Of documentoventaTransporte), idNum As Integer, nroTicket As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ListaEnvioSunatResumenTrans(lista, idNum, nroTicket)
    End Sub


    Public Function AlertaEnvioPSETrasporte(Empresa As String) As documentoventaTransporte
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.AlertaEnvioPSETrasporte(Empresa)
    End Function


    Public Function AlertaPSETrasporte(Empresa As String) As documentoventaTransporte
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.AlertaPSETrasporte(Empresa)
    End Function

    Function GetEncomiendasSelAgenciaDestino(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEncomiendasSelAgenciaDestino(be)
    End Function

    Function GetCiudadesPorEntregarOrigen(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCiudadesPorEntregarOrigen(be)
    End Function


    Public Sub EliminarVentaEncomienda(documentoBE As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarVentaEncomienda(documentoBE)
    End Sub

    Public Function GetEncomiendasSelEstadoEntregaConteo(be As documentoventaTransporte) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEncomiendasSelEstadoEntregaConteo(be)
    End Function

    Public Sub ActualizarRutaDestino(obj As documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActualizarRutaDestino(obj)
    End Sub

    Public Function GetTransporteDocXIDAnulacion(be As documentoventaTransporteDetalle) As documentoventaTransporte
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTransporteDocXIDAnulacion(be)
    End Function

    Public Function GetPasajeroXAsiwentoAnulacion(be As documentoventaTransporte) As documentoventaTransporte
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetPasajeroXAsiwentoAnulacion(be)
    End Function

    Public Function GetEncomiendasSelEstadoEntregaRDLC(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEncomiendasSelEstadoEntregaRDLC(be)
    End Function

    Public Function GetEncomiendasSelEstadoEntrega(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEncomiendasSelEstadoEntrega(be)
    End Function


    Public Sub ReEnviarFacturaElectronica(idDocumento As Integer, IdPse As String, estado As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ReEnviarFacturaElectronica(idDocumento, IdPse, estado)
    End Sub

    Public Function DocumentoTransporteSelID(be As documentoventaTransporte) As documentoventaTransporte
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoTransporteSelID(be)
    End Function

    Public Function DocumentoTransporteSelIDVer2(be As documentoventaTransporte) As documentoventaTransporte
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoTransporteSelIDVer2(be)
    End Function

    Public Function DocumentoTransporteSelIDVehiculoXProg(be As documentoventaTransporte) As documentoventaTransporte
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoTransporteSelIDVehiculoXProg(be)
    End Function

    Public Function DocumentoTransportePasajesSelID(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoTransportePasajesSelID(be)
    End Function

    Public Function GetEncomiendasByProgramacion(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEncomiendasByProgramacion(be)
    End Function

    Public Sub UpdateFacturasXEstadoTrans(iddoc As Integer, estado As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateFacturasXEstadoTrans(iddoc, estado)
    End Sub

    Public Function DocumentoventaTransporteSave(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoventaTransporteSave(objDocumento)
    End Function

    Public Function DocumentoventaTransporteReservacionSave(objDocumento As documento, idDocumentoREf As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoventaTransporteReservacionSave(objDocumento, idDocumentoREf)
    End Function

    Public Sub DocumentoTransporteReservacionEliminar(idDocumentoREf As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DocumentoTransporteReservacionEliminar(idDocumentoREf)
    End Sub

    Public Function DocumentoventaEncomiendaSave(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocumentoventaEncomiendaSave(objDocumento)
    End Function

    Public Function GetConsultaEncomiendasFecha(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultaEncomiendasFecha(be)
    End Function

    Public Function GetConsultaTransporteFecha(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultaTransporteFecha(be)
    End Function

    Public Function GetConsultaEncomiendasFechaProgramada(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultaEncomiendasFechaProgramada(be)
    End Function

    Public Function GetMovimientosByProgramacion(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosByProgramacion(be)
    End Function

    Public Sub ActualizarEntrega(lista As List(Of documentoventaTransporte), listaEncomiendas As List(Of rutaTareoEncomienda))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActualizarEntrega(lista, listaEncomiendas)
    End Sub



End Class
