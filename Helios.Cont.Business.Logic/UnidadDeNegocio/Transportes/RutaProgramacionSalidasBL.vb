Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class RutaProgramacionSalidasBL
    Inherits BaseBL

    Public Function GetProgramacionPorFechaLaboral(be As rutaProgramacionSalidas) As List(Of rutaProgramacionSalidas)
        Dim lista As New List(Of String)
        lista.Add(General.Transporte.ProgramacionEstado.VentaCerrada)
        lista.Add(General.Transporte.ProgramacionEstado.VentaEnMostrador)
        lista.Add(General.Transporte.ProgramacionEstado.ZonaEmbarque)

        Dim con = (From prog In HeliosData.rutaProgramacionSalidas
                   Join r In HeliosData.rutas On New With {.Ruta_id = CInt(prog.ruta_id)} Equals New With {.Ruta_id = r.ruta_id}
                   Join hora In HeliosData.ruta_horarios On hora.ruta_id Equals r.ruta_id
                   Join bus In HeliosData.activosFijos On bus.idActivo Equals CInt(prog.idActivo)
                   Where
                       lista.Contains(prog.estado) And
                       prog.fechaProgramacion.Value.Year = be.fechaProgramacion.Value.Year And
                       prog.fechaProgramacion.Value.Month = be.fechaProgramacion.Value.Month And
                       prog.fechaProgramacion.Value.Day = be.fechaProgramacion.Value.Day
                   Select
                       EstadoProg = prog.estado,
                       hora.horario_id,
                       prog.tipo,
                       prog.programacion_id,
                       Ruta_id = CType(r.ruta_id, Int32?),
                       r.ciudadOrigen,
                       r.ciudadDestino,
                       r.km,
                       r.estado,
                       r.ciudadOrigenUbigeo,
                       r.ciudadDestinoUbigeo,
                       bus.idActivo,
                       bus.descripcionItem,
                       bus.nroSeriePlaca,
                       prog.fechaProgramacion,
                       prog.manifiesto
                       ).ToList

        GetProgramacionPorFechaLaboral = New List(Of rutaProgramacionSalidas)
        For Each i In con
            GetProgramacionPorFechaLaboral.Add(New rutaProgramacionSalidas With
                                       {
                                       .estado = i.EstadoProg,
                                       .tipo = i.tipo,
                                       .fechaProgramacion = i.fechaProgramacion,
                                       .programacion_id = i.programacion_id,
                                       .ruta_id = i.Ruta_id,
                                       .idActivo = i.idActivo,
                                       .nombreBus = i.descripcionItem,
                                       .manifiesto = i.manifiesto,
                                       .nroPlcaBus = i.nroSeriePlaca,
                                       .CustomRutas = New rutas With
                                            {
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .ciudadDestino = i.ciudadDestino,
                                            .ciudadOrigenUbigeo = i.ciudadOrigenUbigeo,
                                            .ciudadDestinoUbigeo = i.ciudadDestinoUbigeo,
                                            .km = i.km,
                                            .estado = i.estado,
                                            .CustomRuta_horarios = New ruta_horarios With
                                               {
                                               .horario_id = i.horario_id
                                               }
                                            }
                                       })
        Next

    End Function

    'And
    '                   prog.fechaProgramacion.Value.Year = be.fechaProgramacion.Value.Year And
    '                   prog.fechaProgramacion.Value.Month = be.fechaProgramacion.Value.Month And
    '                   prog.fechaProgramacion.Value.Day = be.fechaProgramacion.Value.Day

    Public Function GetProgramacionEstatus(be As rutaProgramacionSalidas) As List(Of rutaProgramacionSalidas)
        'Dim con = (From prog In HeliosData.rutaProgramacionSalidas
        '           Join r In HeliosData.rutas On New With {.Ruta_id = CInt(prog.ruta_id)} Equals New With {.Ruta_id = r.ruta_id}
        '           Where prog.estado = be.estado
        '           Select
        '             prog.programacion_id,
        '             Ruta_id = CType(r.ruta_id, Int32?),
        '             r.ciudadOrigen,
        '             r.ciudadDestino,
        '             r.km,
        '             r.estado,
        '             prog.fechaProgramacion,
        '             Ventas = ((Aggregate t1 In
        '               (From VehiculoAsiento_Precios In HeliosData.vehiculoAsiento_Precios
        '                Where
        '                 VehiculoAsiento_Precios.programacion_id = prog.programacion_id And
        '                 CLng(VehiculoAsiento_Precios.estado) = 1
        '                Select New With {
        '                 VehiculoAsiento_Precios
        '               }) Into Count())),
        '               Reservas = ((Aggregate t1 In
        '               (From VehiculoAsiento_Precios In HeliosData.vehiculoAsiento_Precios
        '                Where
        '                 VehiculoAsiento_Precios.programacion_id = prog.programacion_id And
        '                 CLng(VehiculoAsiento_Precios.estado) = 2
        '                Select New With {
        '                 VehiculoAsiento_Precios
        '               }) Into Count()))).ToList

        Dim con = (From prog In HeliosData.rutaProgramacionSalidas
                   Join r In HeliosData.rutas On New With {.Ruta_id = CInt(prog.ruta_id)} Equals New With {.Ruta_id = r.ruta_id}
                   Where prog.estado = be.estado
                   Select
                     prog.programacion_id,
                     Ruta_id = CType(r.ruta_id, Int32?),
                     r.ciudadOrigen,
                     r.ciudadDestino,
                     r.km,
                     r.estado,
                     prog.fechaProgramacion).ToList

        GetProgramacionEstatus = New List(Of rutaProgramacionSalidas)
        For Each i In con
            GetProgramacionEstatus.Add(New rutaProgramacionSalidas With
                                       {
                                       .fechaProgramacion = i.fechaProgramacion,
                                       .programacion_id = i.programacion_id,
                                       .ruta_id = i.Ruta_id,
                                       .CustomRutas = New rutas With
                                            {
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .ciudadDestino = i.ciudadDestino,
                                            .km = i.km,
                                            .estado = i.estado
                                            }
                                                                        })
        Next

    End Function

    Public Function GetProgramacionSelRuta(ruta_id As Integer) As List(Of rutaProgramacionSalidas)
        Return HeliosData.rutaProgramacionSalidas.Where(Function(o) o.ruta_id = ruta_id).ToList
    End Function

    Public Function GetProgramacionSelRutaMostrador(ruta_id As Integer) As List(Of rutaProgramacionSalidas)
        Dim lista As New List(Of String)
        'lista.Add(General.Transporte.ProgramacionEstado.VehiculoAsignadoEnCurso)
        lista.Add(General.Transporte.ProgramacionEstado.VentaCerrada)
        lista.Add(General.Transporte.ProgramacionEstado.VentaEnMostrador)
        lista.Add(General.Transporte.ProgramacionEstado.ZonaEmbarque)

        Return HeliosData.rutaProgramacionSalidas.Where(Function(o) o.ruta_id = ruta_id And lista.Contains(o.estado)).ToList
    End Function

    Public Function programacionSave(be As rutaProgramacionSalidas) As rutaProgramacionSalidas
        Using ts As New TransactionScope()
            HeliosData.rutaProgramacionSalidas.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
            be.programacion_id = be.programacion_id
        End Using
        Return be
    End Function

    Public Function programacionXBusXHorarioSave(be As rutaProgramacionSalidas, listaAsientoXBus As List(Of vehiculoAsiento_Precios)) As rutaProgramacionSalidas
        Try

            Dim vehiculoASiento As New vehiculoAsiento_Precios

            Using ts As New TransactionScope()

                Dim prog = HeliosData.rutaProgramacionSalidas.Where(Function(o) o.fechaProgramacion = be.fechaProgramacion And o.idActivo = be.idActivo And o.estado = 1).Count

                If ((prog) = 0) Then

                    HeliosData.rutaProgramacionSalidas.Add(be)
                    HeliosData.SaveChanges()
                    be.programacion_id = be.programacion_id

                    For Each asientoRuta In listaAsientoXBus
                        vehiculoASiento = New vehiculoAsiento_Precios With
          {
          .[ruta_id] = asientoRuta.ruta_id,
          .[horario_id] = asientoRuta.horario_id,
          .[codigoServicio] = asientoRuta.codigoServicio,
           .[idDistribucion] = asientoRuta.idDistribucion,
          .[idComponente] = asientoRuta.idComponente,
          .[idEmpresa] = asientoRuta.idEmpresa,
          .[idEstablecimiento] = asientoRuta.idEstablecimiento,
          .[programacion_id] = be.programacion_id,
          .[tareo_id] = asientoRuta.tareo_id,
           .[idDocumentoVenta] = asientoRuta.idDocumentoVenta,
          .[idActivo] = asientoRuta.idActivo,
          .[vence] = asientoRuta.vence,
          .[numeracion] = asientoRuta.numeracion,
          .[estado] = asientoRuta.estado,
          .idItem = asientoRuta.idItem,
          .descripcionItem = asientoRuta.descripcionItem,
          .destino = asientoRuta.destino,
           .precioAsientoMN = asientoRuta.precioAsientoMN,
           .precioAsientoME = asientoRuta.precioAsientoME,
            .moneda = asientoRuta.moneda,
            .origen = asientoRuta.origen,
           .[usuarioActualizacion] = asientoRuta.usuarioActualizacion,
          .[fechaActualizacion] = asientoRuta.fechaActualizacion
          }
                        HeliosData.vehiculoAsiento_Precios.Add(vehiculoASiento)
                        HeliosData.SaveChanges()
                    Next

                    ts.Complete()
                Else
                    Throw New Exception("Ya existe una salida con el mismo horario")
                End If

            End Using
            Return be

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function programacionXBusXCambioPlacaSave(be As rutaProgramacionSalidas, listaAsientoXBus As List(Of vehiculoAsiento_Precios)) As rutaProgramacionSalidas
        Try
            Dim documentoventaTransporteBL As New documentoventaTransporteBL
            Dim vehiculoASiento As New vehiculoAsiento_Precios

            Using ts As New TransactionScope()
                HeliosData.rutaProgramacionSalidas.Add(be)
                HeliosData.SaveChanges()
                be.programacion_id = be.programacion_id

                For Each asientoRuta In listaAsientoXBus
                    vehiculoASiento = New vehiculoAsiento_Precios With
      {
      .[ruta_id] = asientoRuta.ruta_id,
      .[horario_id] = asientoRuta.horario_id,
      .[codigoServicio] = asientoRuta.codigoServicio,
       .[idDistribucion] = asientoRuta.idDistribucion,
      .[idComponente] = asientoRuta.idComponente,
      .[idEmpresa] = asientoRuta.idEmpresa,
      .[idEstablecimiento] = asientoRuta.idEstablecimiento,
      .[programacion_id] = be.programacion_id,
      .[tareo_id] = asientoRuta.tareo_id,
       .[idDocumentoVenta] = asientoRuta.idDocumentoVenta,
      .[idActivo] = asientoRuta.idActivo,
      .[vence] = asientoRuta.vence,
      .[numeracion] = asientoRuta.numeracion,
      .[estado] = asientoRuta.estado,
       .precioAsientoMN = asientoRuta.precioAsientoMN,
       .precioAsientoME = asientoRuta.precioAsientoME,
        .moneda = asientoRuta.moneda,
        .origen = asientoRuta.origen,
        .destino = asientoRuta.destino,
        .idItem = asientoRuta.idItem,
        .descripcionItem = asientoRuta.descripcionItem,
       .[usuarioActualizacion] = asientoRuta.usuarioActualizacion,
      .[fechaActualizacion] = asientoRuta.fechaActualizacion
      }
                    HeliosData.vehiculoAsiento_Precios.Add(vehiculoASiento)
                    HeliosData.SaveChanges()

                    vehiculoASiento.precio_id = vehiculoASiento.precio_id

                    documentoventaTransporteBL.UpdateProgramacionXCAmbioPlaca(be, vehiculoASiento)

                Next


                Dim prog = HeliosData.rutaProgramacionSalidas.Where(Function(o) o.programacion_id = be.nroProgramcionAnterior).SingleOrDefault

                prog.estado = 6
                HeliosData.SaveChanges()

                ts.Complete()

            End Using
            Return be

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ProgramacionSelRutasActivas(be As rutaProgramacionSalidas) As List(Of rutas)
        Dim obj As New rutas
        Dim listaHorarios As List(Of ruta_horarios)

        Dim consulta = (From prog In HeliosData.rutaProgramacionSalidas
                        Join rut In HeliosData.rutas On New With {.Ruta_id = CInt(prog.ruta_id)} Equals New With {.Ruta_id = rut.ruta_id}
                        Group Join hor In HeliosData.ruta_horarios On New With {rut.ruta_id} Equals New With {hor.ruta_id} Into hor_join = Group
                        From hor In hor_join.DefaultIfEmpty()
                        Where prog.estado = be.estado
                        Select
                            rut.ruta_id,
                            rut.codigo,
                            rut.km,
                            rut.ciudadOrigen,
                            rut.ciudadOrigenUbigeo,
                            rut.ciudadOrigenDomicilio,
                            rut.ciudadDestino,
                            rut.ciudadDestinoUbigeo,
                            rut.ciudadDestinoDomicilio,
                            rut.idpadre,
                            rut.estado,
                            rut.usuarioActualizacion,
                            rut.fechaActualizacion,
                            hor.horario_id,
                            hor.dias,
                            hor.horaPartida,
                            hor.horaPartidaTolerancia,
                            hor.horaLlegada,
                            hor.horaLlegadaTolerancia).Distinct.ToList

        'Dim con = (From n In HeliosData.rutaProgramacionSalidas
        '           Join ruta In HeliosData.rutas.Include("ruta_horarios") On ruta.ruta_id Equals n.ruta_id
        '           Where ruta.estado = be.estado
        '           Select New With {
        '               ruta.ruta_id,
        '               ruta.codigo,
        '               ruta.km,
        '               ruta.ciudadOrigen,
        '               ruta.ciudadOrigenUbigeo,
        '               ruta.ciudadOrigenDomicilio,
        '               ruta.ciudadDestino,
        '               ruta.ciudadDestinoUbigeo,
        '               ruta.ciudadDestinoDomicilio,
        '               ruta.idpadre,
        '               .EstadoRuta = ruta.estado,
        '               ruta.usuarioActualizacion,
        '               ruta.fechaActualizacion,
        '               ruta.ruta_horarios
        '               }).Distinct.ToList

        ProgramacionSelRutasActivas = New List(Of rutas)
        For Each i In consulta
            listaHorarios = New List(Of ruta_horarios)
            '     For Each x In i.ruta_horarios
            '    listaHorarios.Add(New ruta_horarios With
            '               {
            '               .ruta_id = i.ruta_id,
            '               .horario_id = x.horario_id,
            '               .dias = x.dias,
            '               .horaPartida = x.horaPartida,
            '               .horaPartidaTolerancia = x.horaPartidaTolerancia,
            '               .horaLlegada = x.horaLlegada,
            '               .horaLlegadaTolerancia = x.horaLlegadaTolerancia,
            '               .usuarioActualizacion = i.usuarioActualizacion,
            '               .fechaActualizacion = i.fechaActualizacion
            '              })
            'Next

            Dim horario As New ruta_horarios With
                           {
                           .ruta_id = i.ruta_id,
                           .horario_id = i.horario_id,
                           .dias = i.dias,
                           .horaPartida = i.horaPartida,
                           .horaPartidaTolerancia = i.horaPartidaTolerancia,
                           .horaLlegada = i.horaLlegada,
                           .horaLlegadaTolerancia = i.horaLlegadaTolerancia,
                           .usuarioActualizacion = i.usuarioActualizacion,
                           .fechaActualizacion = i.fechaActualizacion
                          }
            listaHorarios.Add(horario)

            obj = New rutas With
                {
                .ruta_id = i.ruta_id,
                .codigo = i.codigo,
                .km = i.km,
                .ciudadOrigen = i.ciudadOrigen,
                .ciudadOrigenUbigeo = i.ciudadOrigenUbigeo,
                .ciudadOrigenDomicilio = i.ciudadOrigenDomicilio,
                .ciudadDestino = i.ciudadDestino,
                .ciudadDestinoUbigeo = i.ciudadDestinoUbigeo,
                .ciudadDestinoDomicilio = i.ciudadDestinoDomicilio,
                .idpadre = i.idpadre,
                .estado = i.estado,
                .usuarioActualizacion = i.usuarioActualizacion,
                .fechaActualizacion = i.fechaActualizacion,
                .ruta_horarios = listaHorarios
            }
            '.CustomRuta_horarios = New ruta_horarios With
            '           {
            '           .ruta_id = i.ruta_id,
            '           .horario_id = i.horario_id,
            '           .dias = i.dias,
            '           .horaPartida = i.horaPartida,
            '           .horaPartidaTolerancia = i.horaPartidaTolerancia,
            '           .horaLlegada = i.horaLlegada,
            '           .horaLlegadaTolerancia = i.horaLlegadaTolerancia,
            '           .usuarioActualizacion = i.usuarioActualizacion,
            '           .fechaActualizacion = i.fechaActualizacion
            '          }

            ProgramacionSelRutasActivas.Add(obj)
        Next



    End Function

    Public Function ProgramacionSelID(be As rutaProgramacionSalidas) As rutaProgramacionSalidas

        Dim listaHorarios As List(Of ruta_horarios)

        Dim consulta = (From prog In HeliosData.rutaProgramacionSalidas
                        Join rut In HeliosData.rutas On New With {.Ruta_id = CInt(prog.ruta_id)} Equals New With {.Ruta_id = rut.ruta_id}
                        Group Join hor In HeliosData.ruta_horarios On New With {rut.ruta_id} Equals New With {hor.ruta_id} Into hor_join = Group
                        From hor In hor_join.DefaultIfEmpty()
                        Where prog.programacion_id = be.programacion_id
                        Select
                            prog.programacion_id,
                            prog.fechaProgramacion,
                            Tipoprog = prog.tipo,
                            rut.ruta_id,
                            rut.codigo,
                            rut.km,
                            rut.ciudadOrigen,
                            rut.ciudadOrigenUbigeo,
                            rut.ciudadOrigenDomicilio,
                            rut.ciudadDestino,
                            rut.ciudadDestinoUbigeo,
                            rut.ciudadDestinoDomicilio,
                            rut.idpadre,
                            rut.estado,
                            rut.usuarioActualizacion,
                            rut.fechaActualizacion,
                            hor.horario_id,
                            hor.dias,
                            hor.horaPartida,
                            hor.horaPartidaTolerancia,
                            hor.horaLlegada,
                            hor.horaLlegadaTolerancia).SingleOrDefault


        listaHorarios = New List(Of ruta_horarios)

        Dim horario As New ruta_horarios With
                           {
                           .ruta_id = consulta.ruta_id,
                           .horario_id = consulta.horario_id,
                           .dias = consulta.dias,
                           .horaPartida = consulta.horaPartida,
                           .horaPartidaTolerancia = consulta.horaPartidaTolerancia,
                           .horaLlegada = consulta.horaLlegada,
                           .horaLlegadaTolerancia = consulta.horaLlegadaTolerancia,
                           .usuarioActualizacion = consulta.usuarioActualizacion,
                           .fechaActualizacion = consulta.fechaActualizacion
                          }
        listaHorarios.Add(horario)

        Dim objRuta = New rutas With
                {
                .ruta_id = consulta.ruta_id,
                .codigo = consulta.codigo,
                .km = consulta.km,
                .ciudadOrigen = consulta.ciudadOrigen,
                .ciudadOrigenUbigeo = consulta.ciudadOrigenUbigeo,
                .ciudadOrigenDomicilio = consulta.ciudadOrigenDomicilio,
                .ciudadDestino = consulta.ciudadDestino,
                .ciudadDestinoUbigeo = consulta.ciudadDestinoUbigeo,
                .ciudadDestinoDomicilio = consulta.ciudadDestinoDomicilio,
                .idpadre = consulta.idpadre,
                .estado = consulta.estado,
                .usuarioActualizacion = consulta.usuarioActualizacion,
                .fechaActualizacion = consulta.fechaActualizacion,
                .ruta_horarios = listaHorarios
            }

        ProgramacionSelID = New rutaProgramacionSalidas
        ProgramacionSelID.programacion_id = consulta.programacion_id
        ProgramacionSelID.tipo = consulta.Tipoprog
        ProgramacionSelID.fechaProgramacion = consulta.fechaProgramacion
        ProgramacionSelID.CustomRutas = objRuta



    End Function


    Public Function ProgramacionManifiestoSelID(be As rutaProgramacionSalidas) As rutaProgramacionSalidas

        Dim listaHorarios As List(Of ruta_horarios)

        Dim consulta = (From prog In HeliosData.rutaProgramacionSalidas
                        Join rut In HeliosData.rutas On New With {.Ruta_id = CInt(prog.ruta_id)} Equals New With {.Ruta_id = rut.ruta_id}
                        Group Join hor In HeliosData.ruta_horarios On New With {rut.ruta_id} Equals New With {hor.ruta_id} Into hor_join = Group
                        From hor In hor_join.DefaultIfEmpty()
                        Where prog.programacion_id = be.programacion_id
                        Select
                            prog.programacion_id,
                            prog.fechaProgramacion,
                            Tipoprog = prog.tipo,
                            rut.ruta_id,
                            rut.codigo,
                            rut.km,
                            rut.ciudadOrigen,
                            rut.ciudadOrigenUbigeo,
                            rut.ciudadOrigenDomicilio,
                            rut.ciudadDestino,
                            rut.ciudadDestinoUbigeo,
                            rut.ciudadDestinoDomicilio,
                            rut.idpadre,
                            rut.estado,
                            rut.usuarioActualizacion,
                            rut.fechaActualizacion,
                            hor.horario_id,
                            hor.dias,
                            hor.horaPartida,
                            hor.horaPartidaTolerancia,
                            hor.horaLlegada,
                            hor.horaLlegadaTolerancia).SingleOrDefault


        listaHorarios = New List(Of ruta_horarios)

        Dim horario As New ruta_horarios With
                           {
                           .ruta_id = consulta.ruta_id,
                           .horario_id = consulta.horario_id,
                           .dias = consulta.dias,
                           .horaPartida = consulta.horaPartida,
                           .horaPartidaTolerancia = consulta.horaPartidaTolerancia,
                           .horaLlegada = consulta.horaLlegada,
                           .horaLlegadaTolerancia = consulta.horaLlegadaTolerancia,
                           .usuarioActualizacion = consulta.usuarioActualizacion,
                           .fechaActualizacion = consulta.fechaActualizacion
                          }
        listaHorarios.Add(horario)

        Dim objRuta = New rutas With
                {
                .ruta_id = consulta.ruta_id,
                .codigo = consulta.codigo,
                .km = consulta.km,
                .ciudadOrigen = consulta.ciudadOrigen,
                .ciudadOrigenUbigeo = consulta.ciudadOrigenUbigeo,
                .ciudadOrigenDomicilio = consulta.ciudadOrigenDomicilio,
                .ciudadDestino = consulta.ciudadDestino,
                .ciudadDestinoUbigeo = consulta.ciudadDestinoUbigeo,
                .ciudadDestinoDomicilio = consulta.ciudadDestinoDomicilio,
                .idpadre = consulta.idpadre,
                .estado = consulta.estado,
                .usuarioActualizacion = consulta.usuarioActualizacion,
                .fechaActualizacion = consulta.fechaActualizacion,
                .ruta_horarios = listaHorarios
            }

        ProgramacionManifiestoSelID = New rutaProgramacionSalidas
        ProgramacionManifiestoSelID.programacion_id = consulta.programacion_id
        ProgramacionManifiestoSelID.tipo = consulta.Tipoprog
        ProgramacionManifiestoSelID.fechaProgramacion = consulta.fechaProgramacion
        ProgramacionManifiestoSelID.CustomRutas = objRuta



    End Function

    Public Sub UpdateEstadoProgramacion(obj As rutaProgramacionSalidas)
        Using ts As New TransactionScope()

            Dim prog = HeliosData.rutaProgramacionSalidas.Where(Function(o) o.programacion_id = obj.programacion_id).SingleOrDefault

            prog.estado = obj.estado
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarConsolidacion(obj As rutaTareoAutos, estadoProgramacion As Integer)
        Using ts As New TransactionScope()
            Dim prog = HeliosData.rutaProgramacionSalidas.Where(Function(o) o.programacion_id = obj.programacion_id).SingleOrDefault

            prog.estado = estadoProgramacion ' General.Transporte.ProgramacionEstado.VehiculoAsignadoEnCurso
            HeliosData.rutaTareoAutos.Add(obj)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class
