Imports Helios.Cont.Business.Entity

Public Class RutaTareoDetalleBL
    Inherits itemBL

    Public Function GetProgamacionEnCurso(be As rutaProgramacionSalidas) As List(Of vehiculoAsiento_Precios)
        Dim obj As vehiculoAsiento_Precios
        Dim con = (From tareo In HeliosData.rutaTareoDetalle
                   Join tar In HeliosData.rutaTareoAutos On tar.tareo_id Equals tareo.tareo_id
                   Join venta In HeliosData.documentoventaTransporte On tareo.documentoVenta_id Equals venta.idDocumento
                   Join serv In HeliosData.ruta_HorarioServicios On tareo.servicio_id Equals serv.codigoServicio
                   Join per In HeliosData.Persona On tareo.entidad_id Equals per.codigo
                   Join rut In HeliosData.rutas On tareo.ruta_id Equals rut.ruta_id
                   Where
                    CLng(tareo.programacion_id) = be.programacion_id
                   Order By
                    tareo.nroasiento
                   Select
                       tareo.tareo_id,
                       tar.tipoTareo,
                       CodigoPer = per.codigo,
                       tareo.programacion_id,
                       tareo.idVehiculo,
                       tareo.nroasiento,
                       venta.idDocumento,
                       venta.serie,
                       venta.numero,
                       serv.descripcionCorta,
                       per.nombreCompleto,
                       rut.ciudadDestino,
                       rut.ruta_id,
                       per.tipodoc,
                       venta.total,
                       DNI = per.idPersona,
                       serv.codigoServicio,
                       serv.descripcionLarga,
                       serv.costoEstimado).ToList

        GetProgamacionEnCurso = New List(Of vehiculoAsiento_Precios)
        For Each i In con
            obj = New vehiculoAsiento_Precios
            obj.idComponente = i.nroasiento
            'obj.idDistribucion = i.i
            obj.programacion_id = i.programacion_id
            obj.CustomrutaTareoAutos = New rutaTareoAutos With
            {
            .tareo_id = i.tareo_id,
            .tipoTareo = i.tipoTareo
            }
            obj.CustomPersona = New Persona With
            {
            .codigo = i.CodigoPer,
            .idPersona = i.DNI,
            .nombreCompleto = i.nombreCompleto
            }
            obj.CustomRuta = New rutas With
            {
            .ruta_id = i.ruta_id,
            .ciudadDestino = i.ciudadDestino
            }
            obj.CustomDocumentoVentaTransporte = New documentoventaTransporte With
            {
            .idDocumento = i.idDocumento,
            .serie = i.serie,
            .numero = i.numero,
            .total = i.total
            }
            obj.CustomRuta_HorarioServicios = New ruta_HorarioServicios With
            {
            .codigoServicio = i.codigoServicio,
            .descripcionLarga = i.descripcionLarga,
            .descripcionCorta = i.descripcionCorta,
            .costoEstimado = i.costoEstimado
            }
            GetProgamacionEnCurso.Add(obj)
        Next

    End Function



End Class
