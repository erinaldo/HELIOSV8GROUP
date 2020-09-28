Imports Helios.Cont.Business.Entity

Public Class rutaTareoEncomiendaBL
    Inherits BaseBL

    Public Function rutaTareoEncomiendaSelID(be As rutaTareoEncomienda) As rutaTareoEncomienda
        Dim con = (From enc In HeliosData.rutaTareoEncomienda
                   Join per In HeliosData.Persona On New With {.Codigo = CInt(enc.tripulante1)} Equals New With {.Codigo = per.codigo}
                   Join act In HeliosData.activosFijos On New With {.IdActivo = enc.idVehiculo} Equals New With {.IdActivo = act.idActivo}
                   Where enc.tareo_id = be.tareo_id
                   Select
                      enc.tareo_id,
                      enc.fechaEnvio,
                      IdVehiculo = CType(enc.idVehiculo, Int32?),
                      act.nroSeriePlaca,
                       per.codigo,
                       per.idPersona,
                      per.nombreCompleto).FirstOrDefault

        rutaTareoEncomiendaSelID = New rutaTareoEncomienda
        If con IsNot Nothing Then
            rutaTareoEncomiendaSelID = New rutaTareoEncomienda With
            {
            .tareo_id = con.tareo_id,
            .fechaEnvio = con.fechaEnvio,
            .idVehiculo = con.IdVehiculo,
            .Matricula = con.nroSeriePlaca,
            .CustomPerson = New Persona With
            {
            .codigo = con.codigo,
            .idPersona = con.idPersona,
            .nombreCompleto = con.nombreCompleto
            }
            }
        End If

    End Function



    Public Function GetTareoEncomiendasSelCiudadDestino(be As rutaTareoEncomienda) As List(Of rutaTareoEncomienda)
        Return HeliosData.rutaTareoEncomienda.Where(Function(o) o.agenciaOrigen_id = be.agenciaOrigen_id And o.agenciaDestino_id = be.agenciaDestino_id).ToList
    End Function

End Class
