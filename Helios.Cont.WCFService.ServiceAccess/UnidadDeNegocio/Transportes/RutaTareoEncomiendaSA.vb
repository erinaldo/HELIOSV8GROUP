Imports Helios.Cont.Business.Entity

Public Class RutaTareoEncomiendaSA
    Public Function GetTareoEncomiendasSelCiudadDestino(be As rutaTareoEncomienda) As List(Of rutaTareoEncomienda)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTareoEncomiendasSelCiudadDestino(be)
    End Function

    Public Function rutaTareoEncomiendaSelID(be As rutaTareoEncomienda) As rutaTareoEncomienda
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.rutaTareoEncomiendaSelID(be)
    End Function
End Class
