Imports Helios.Cont.Business.Entity

Public Class RutaTareoEncomiendaDetalleSA

    Public Function rutaTareoEncomiendaDetalleSelFechaV2(fecha As Date, origen As Integer, destino As Integer) As List(Of rutaTareoEncomiendaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.rutaTareoEncomiendaDetalleSelFechaV2(fecha, origen, destino)
    End Function

    Public Function rutaTareoEncomiendaDetalleSelID(be As rutaTareoEncomiendaDetalle) As List(Of rutaTareoEncomiendaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.rutaTareoEncomiendaDetalleSelID(be)
    End Function

    Public Function rutaTareoEncomiendaDetalleSelFecha(be As rutaTareoEncomienda) As List(Of rutaTareoEncomiendaDetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.rutaTareoEncomiendaDetalleSelFecha(be)
    End Function


End Class
