Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class RutasBL
    Inherits BaseBL

    Public Function GellAllRutas(be As rutas) As List(Of rutas)
        'Return HeliosData.rutas.Where(Function(o) o.estado = be.estado).ToList
        Dim obj As New rutas
        Dim listaHorarios As New List(Of ruta_horarios)
        Dim con = (From n In HeliosData.rutas.Include("ruta_horarios")
                   Where n.estado = be.estado).ToList


        GellAllRutas = New List(Of rutas)
        For Each i In con

            listaHorarios = New List(Of ruta_horarios)
            For Each x In i.ruta_horarios
                listaHorarios.Add(New ruta_horarios With
                           {
                           .ruta_id = i.ruta_id,
                           .horario_id = x.horario_id,
                           .dias = x.dias,
                           .horaPartida = x.horaPartida,
                           .horaPartidaTolerancia = x.horaPartidaTolerancia,
                           .horaLlegada = x.horaLlegada,
                           .horaLlegadaTolerancia = x.horaLlegadaTolerancia,
                           .usuarioActualizacion = i.usuarioActualizacion,
                           .fechaActualizacion = i.fechaActualizacion
                          })
            Next

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
            GellAllRutas.Add(obj)
        Next

    End Function

    Public Function RutaSelID(be As rutas) As rutas
        Dim listaHorarios As New List(Of ruta_horarios)
        Dim con = (From n In HeliosData.rutas.Include("ruta_horarios")
                   Where n.ruta_id = be.ruta_id).SingleOrDefault

        For Each i In con.ruta_horarios
            listaHorarios.Add(New ruta_horarios With
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
                              })
        Next

        Dim obj As New rutas With
        {
        .ruta_id = con.ruta_id,
        .codigo = con.codigo,
        .km = con.km,
        .ciudadOrigen = con.ciudadOrigen,
        .ciudadOrigenUbigeo = con.ciudadOrigenUbigeo,
        .ciudadOrigenDomicilio = con.ciudadOrigenDomicilio,
        .ciudadDestino = con.ciudadDestino,
        .ciudadDestinoUbigeo = con.ciudadDestinoUbigeo,
        .ciudadDestinoDomicilio = con.ciudadDestinoDomicilio,
        .idpadre = con.idpadre,
        .estado = con.estado,
        .usuarioActualizacion = con.usuarioActualizacion,
        .fechaActualizacion = con.fechaActualizacion,
        .ruta_horarios = listaHorarios
        }


        Return obj
    End Function

    Public Function GetRutaSelCodigo(be As rutas) As rutas
        Dim listaHorarios As New List(Of ruta_horarios)
        Dim con = (From n In HeliosData.rutas.Include("ruta_horarios")
                   Where n.codigo = be.codigo).SingleOrDefault


        For Each i In con.ruta_horarios
            listaHorarios.Add(New ruta_horarios With
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
                              })
        Next

        Dim obj As New rutas With
        {
        .ruta_id = con.ruta_id,
        .codigo = con.codigo,
        .km = con.km,
        .ciudadOrigen = con.ciudadOrigen,
        .ciudadOrigenDomicilio = con.ciudadOrigenDomicilio,
        .ciudadDestino = con.ciudadDestino,
        .ciudadDestinoDomicilio = con.ciudadDestinoDomicilio,
        .idpadre = con.idpadre,
        .estado = con.estado,
        .usuarioActualizacion = con.usuarioActualizacion,
        .fechaActualizacion = con.fechaActualizacion,
        .ruta_horarios = listaHorarios
        }


        Return obj 'HeliosData.rutas.Where(Function(o) o.codigo = be.codigo).SingleOrDefault
    End Function

    Public Sub InsertarRuta(be As rutas)
        Try
            Using ts As New TransactionScope
                'Dim existe = HeliosData.rutas.Any(Function(o) o.codigo = be.codigo)
                'If existe Then
                '    Throw New Exception("El código asignado no esta disponible, ingrese otro")
                'End If
                'HeliosData.rutas.Add(be)
                Dim rut = Insert(be)
                'For Each i In be.ruta_horarios
                '    i.ruta_id = rut.ruta_id
                '    Dim horarioING = InsertRutaHorario(i)
                '    For Each ser In i.ruta_HorarioServicios
                '        ser.ruta_id = rut.ruta_id
                '        ser.horario_id = horarioING.horario_id
                '        InsertRutaHorarioServicio(ser)
                '    Next
                'Next

                For Each ITEM In be.ListaSubRutas
                    ITEM.idpadre = rut.ruta_id
                    Insert(ITEM)
                Next

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function Insert(be As rutas) As rutas
        Using ts As New TransactionScope
            Dim obj As New rutas With
            {
            .codigo = be.codigo,
            .km = be.km,
            .ciudadOrigen = be.ciudadOrigen,
            .ciudadOrigenDomicilio = be.ciudadOrigenDomicilio,
            .ciudadDestino = be.ciudadDestino,
            .ciudadOrigenUbigeo = be.ciudadOrigenUbigeo,
            .ciudadDestinoUbigeo = be.ciudadDestinoUbigeo,
            .ciudadDestinoDomicilio = be.ciudadDestinoDomicilio,
            .idpadre = be.idpadre,
            .estado = be.estado,
            .usuarioActualizacion = be.usuarioActualizacion,
            .fechaActualizacion = be.fechaActualizacion
            }
            HeliosData.rutas.Add(obj)
            HeliosData.SaveChanges()
            ts.Complete()
            obj.ruta_id = obj.ruta_id
            Return obj
        End Using
    End Function

    Function InsertRutaHorario(be As ruta_horarios) As ruta_horarios
        Using ts As New TransactionScope
            Dim obj As New ruta_horarios With
            {
            .ruta_id = be.ruta_id,
            .dias = be.dias,
            .horaPartida = be.horaPartida,
            .horaPartidaTolerancia = be.horaPartidaTolerancia,
            .horaLlegada = be.horaLlegada,
            .horaLlegadaTolerancia = be.horaLlegadaTolerancia,
            .usuarioActualizacion = be.usuarioActualizacion,
            .fechaActualizacion = be.fechaActualizacion
            }
            HeliosData.ruta_horarios.Add(obj)
            HeliosData.SaveChanges()
            ts.Complete()
            obj.horario_id = obj.horario_id
            Return obj
        End Using
    End Function

    Sub InsertRutaHorarioServicio(be As ruta_HorarioServicios)
        Using ts As New TransactionScope
            Dim obj As New ruta_HorarioServicios With
            {
            .ruta_id = be.ruta_id,
            .horario_id = be.horario_id,
            .codigoServicio = be.codigoServicio,
            .tipoServicio = be.tipoServicio,
            .descripcionCorta = be.descripcionCorta,
            .descripcionLarga = be.descripcionLarga,
            .costoEstimado = be.costoEstimado,
            .capacidad = be.capacidad,
            .usuarioActualizacion = be.usuarioActualizacion,
            .fechaActualizacion = be.fechaActualizacion
            }
            HeliosData.ruta_HorarioServicios.Add(obj)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
