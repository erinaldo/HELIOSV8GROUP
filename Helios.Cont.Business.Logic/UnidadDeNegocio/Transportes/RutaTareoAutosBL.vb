Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports Helios.General
Public Class RutaTareoAutosBL
    Inherits BaseBL

    Public Function GetRutasHabilitadas(be As rutaTareoAutos) As List(Of rutaTareoAutos)

        Dim con = (From t In HeliosData.rutaTareoAutos
                   Join hora In HeliosData.ruta_horarios On hora.ruta_id Equals t.ruta_id And hora.horario_id Equals t.horario_id
                   Where
                      CLng(t.estado) = be.estado
                   Select
                       t.tareo_id,
                      t.idVehiculo,
                      t.nroPlaca,
                      t.nroPasajeros,
                      t.nroTripulantes,
                      hora.ruta_id,
                      hora.rutas.ciudadOrigen,
                       hora.rutas.ciudadOrigenUbigeo,
                      hora.rutas.ciudadDestino,
                       hora.rutas.ciudadDestinoUbigeo,
                       hora.horario_id,
                      hora.dias,
                      hora.horaPartida,
                      hora.horaLlegada).ToList

        GetRutasHabilitadas = New List(Of rutaTareoAutos)
        For Each i In con
            GetRutasHabilitadas.Add(New rutaTareoAutos With
                                      {
                                      .tareo_id = i.tareo_id,
                                      .idVehiculo = i.idVehiculo,
                                      .nroPlaca = i.nroPlaca,
                                      .nroPasajeros = i.nroTripulantes = i.nroTripulantes,
                                      .customRuta = New rutas With
                                        {
                                        .ruta_id = i.ruta_id,
                                        .ciudadOrigen = i.ciudadOrigen,
                                        .ciudadOrigenUbigeo = i.ciudadOrigenUbigeo,
                                        .ciudadDestino = i.ciudadDestino,
                                        .ciudadDestinoUbigeo = i.ciudadDestinoUbigeo
                                        },
                                      .customruta_horarios = New ruta_horarios With
                                        {
                                        .horario_id = i.horario_id,
                                        .dias = i.dias,
                                        .horaPartida = i.horaPartida,
                                        .horaLlegada = i.horaLlegada
                                        }
                                      })
        Next
    End Function


    Public Function GetAdministrarPrecios(be As rutaTareoAutos) As List(Of rutaTareoAutos)

        Dim con = (From t In HeliosData.rutaTareoAutos
                   Join hora In HeliosData.ruta_horarios On hora.ruta_id Equals t.ruta_id And hora.horario_id Equals t.horario_id
                   Where
                      CLng(t.estado) = be.estado
                   Select
                       t.tareo_id,
                      t.idVehiculo,
                      t.nroPlaca,
                      t.nroPasajeros,
                      t.nroTripulantes,
                      hora.ruta_id,
                      hora.rutas.ciudadOrigen,
                      hora.rutas.ciudadDestino,
                       hora.horario_id,
                      hora.dias,
                      hora.horaPartida,
                      hora.horaLlegada).ToList

        GetAdministrarPrecios = New List(Of rutaTareoAutos)
        For Each i In con
            GetAdministrarPrecios.Add(New rutaTareoAutos With
                                      {
                                      .tareo_id = i.tareo_id,
                                      .idVehiculo = i.idVehiculo,
                                      .nroPlaca = i.nroPlaca,
                                      .nroPasajeros = i.nroTripulantes = i.nroTripulantes,
                                      .customRuta = New rutas With
                                        {
                                        .ruta_id = i.ruta_id,
                                        .ciudadOrigen = i.ciudadOrigen,
                                        .ciudadDestino = i.ciudadDestino
                                        },
                                      .customruta_horarios = New ruta_horarios With
                                        {
                                        .horario_id = i.horario_id,
                                        .dias = i.dias,
                                        .horaPartida = i.horaPartida,
                                        .horaLlegada = i.horaLlegada
                                        }
                                      })
        Next
    End Function

    Public Function RutaTareoAutoSave(be As rutaTareoAutos) As rutaTareoAutos
        Using ts As New TransactionScope
            HeliosData.rutaTareoAutos.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
            be.tareo_id = be.tareo_id
        End Using
        Return be
    End Function

    Public Sub GetListaSaveTareo(be As List(Of rutaTareoAutos))
        Using ts As New TransactionScope
            HeliosData.rutaTareoAutos.AddRange(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
