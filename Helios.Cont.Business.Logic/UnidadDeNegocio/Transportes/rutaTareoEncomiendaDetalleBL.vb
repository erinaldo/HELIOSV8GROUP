Imports Helios.Cont.Business.Entity

Public Class rutaTareoEncomiendaDetalleBL
    Inherits BaseBL

    Public Function rutaTareoEncomiendaDetalleSelFechaV2(fecha As Date, origen As Integer, destino As Integer) As List(Of rutaTareoEncomiendaDetalle)
        '    Return HeliosData.rutaTareoEncomiendaDetalle.Where(Function(o) o.tareo_id = be.tareo_id).ToList
        Dim obj As rutaTareoEncomiendaDetalle
        Dim con = (From n In HeliosData.rutaTareoEncomiendaDetalle
                   Join venta In HeliosData.documentoventaTransporte On venta.idDocumento Equals n.venta_id
                   Where
                        n.rutaTareoEncomienda.fechaEnvio.Value.Year = fecha.Year And
                       n.rutaTareoEncomienda.fechaEnvio.Value.Month = fecha.Month And
                       n.rutaTareoEncomienda.fechaEnvio.Value.Day = fecha.Day And
                       n.rutaTareoEncomienda.agenciaOrigen_id = origen And
                       n.rutaTareoEncomienda.agenciaDestino_id = destino
                   Select
                       venta.comprador,
                       venta.idDocumento,
                       venta.tipoDocumento,
                       venta.serie,
                       venta.numero,
                      n.tareo_id,
                      n.remitente,
                      n.consignado,
                      n.cantidad,
                      n.contenido,
                      n.costo,
                      n.tipo,
                       n.rutaTareoEncomienda.idVehiculo,
                       n.rutaTareoEncomienda.tripulante1).ToList

        rutaTareoEncomiendaDetalleSelFechaV2 = New List(Of rutaTareoEncomiendaDetalle)
        For Each i In con
            obj = New rutaTareoEncomiendaDetalle With
            {
            .tareo_id = i.tareo_id,
            .remitente = i.remitente,
            .consignado = i.consignado,
            .cantidad = i.cantidad,
            .contenido = i.contenido,
            .costo = i.costo,
            .tipo = i.tipo,
            .CustomVenta = New documentoventaTransporte With
            {
            .comprador = i.comprador,
            .idDocumento = i.idDocumento,
            .tipoDocumento = i.tipoDocumento,
            .serie = i.serie,
            .numero = i.numero
            },
            .rutaTareoEncomienda = New rutaTareoEncomienda With
            {
            .idVehiculo = i.idVehiculo,
            .tripulante1 = i.tripulante1
            }
            }
            rutaTareoEncomiendaDetalleSelFechaV2.Add(obj)
        Next
    End Function

    Public Function rutaTareoEncomiendaDetalleSelID(be As rutaTareoEncomiendaDetalle) As List(Of rutaTareoEncomiendaDetalle)
        '    Return HeliosData.rutaTareoEncomiendaDetalle.Where(Function(o) o.tareo_id = be.tareo_id).ToList
        Dim obj As rutaTareoEncomiendaDetalle
        Dim con = (From n In HeliosData.rutaTareoEncomiendaDetalle
                   Join venta In HeliosData.documentoventaTransporte On venta.idDocumento Equals n.venta_id
                   Where n.tareo_id = be.tareo_id
                   Select
                       venta.fechadoc,
                       venta.comprador,
                       venta.idDocumento,
                       venta.tipoDocumento,
                       venta.serie,
                       venta.numero,
                      n.tareo_id,
                      n.remitente,
                      n.consignado,
                      n.cantidad,
                      n.contenido,
                      n.costo,
                      n.tipo).ToList

        rutaTareoEncomiendaDetalleSelID = New List(Of rutaTareoEncomiendaDetalle)
        For Each i In con
            obj = New rutaTareoEncomiendaDetalle With
            {
            .tareo_id = i.tareo_id,
            .remitente = i.remitente,
            .consignado = i.consignado,
            .cantidad = i.cantidad,
            .contenido = i.contenido,
            .costo = i.costo,
            .tipo = i.tipo,
            .CustomVenta = New documentoventaTransporte With
            {
            .fechadoc = i.fechadoc,
            .comprador = i.comprador,
            .idDocumento = i.idDocumento,
            .tipoDocumento = i.tipoDocumento,
            .serie = i.serie,
            .numero = i.numero
            }
            }
            rutaTareoEncomiendaDetalleSelID.Add(obj)
        Next
    End Function

    Public Function rutaTareoEncomiendaDetalleSelFecha(be As rutaTareoEncomienda) As List(Of rutaTareoEncomiendaDetalle)
        '    Return HeliosData.rutaTareoEncomiendaDetalle.Where(Function(o) o.tareo_id = be.tareo_id).ToList
        ' n.rutaTareoEncomienda.tripulante1 = be.tripulante1 And
        Dim obj As rutaTareoEncomiendaDetalle
        Dim con = (From n In HeliosData.rutaTareoEncomiendaDetalle
                   Join venta In HeliosData.documentoventaTransporte On venta.idDocumento Equals n.venta_id
                   Where
                        n.rutaTareoEncomienda.fechaEnvio.Value.Year = be.fechaEnvio.Value.Year And
                       n.rutaTareoEncomienda.fechaEnvio.Value.Month = be.fechaEnvio.Value.Month And
                       n.rutaTareoEncomienda.fechaEnvio.Value.Day = be.fechaEnvio.Value.Day And
                       n.rutaTareoEncomienda.agenciaOrigen_id = be.agenciaOrigen_id And
                       n.rutaTareoEncomienda.agenciaDestino_id = be.agenciaDestino_id
                   Select
                       venta.comprador,
                       venta.idDocumento,
                       venta.tipoDocumento,
                       venta.serie,
                       venta.numero,
                      n.tareo_id,
                      n.remitente,
                      n.consignado,
                      n.cantidad,
                      n.contenido,
                      n.costo,
                      n.tipo,
                       n.rutaTareoEncomienda.idVehiculo,
                       n.rutaTareoEncomienda.tripulante1).ToList

        rutaTareoEncomiendaDetalleSelFecha = New List(Of rutaTareoEncomiendaDetalle)
        For Each i In con
            obj = New rutaTareoEncomiendaDetalle With
            {
            .tareo_id = i.tareo_id,
            .remitente = i.remitente,
            .consignado = i.consignado,
            .cantidad = i.cantidad,
            .contenido = i.contenido,
            .costo = i.costo,
            .tipo = i.tipo,
            .CustomVenta = New documentoventaTransporte With
            {
            .comprador = i.comprador,
            .idDocumento = i.idDocumento,
            .tipoDocumento = i.tipoDocumento,
            .serie = i.serie,
            .numero = i.numero
            },
            .rutaTareoEncomienda = New rutaTareoEncomienda With
            {
            .idVehiculo = i.idVehiculo,
            .tripulante1 = i.tripulante1
            }
            }
            rutaTareoEncomiendaDetalleSelFecha.Add(obj)
        Next
    End Function




End Class
