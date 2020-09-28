Imports Helios.Cont.Business.Entity

Public Class RutaTareoAutoSA

    Public Function GetRutasHabilitadas(be As rutaTareoAutos) As List(Of rutaTareoAutos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetRutasHabilitadas(be)
    End Function

    Public Function RutaTareoAutoSave(be As rutaTareoAutos) As rutaTareoAutos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RutaTareoAutoSave(be)
    End Function

    Public Sub GetListaSaveTareo(be As List(Of rutaTareoAutos))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetListaSaveTareo(be)
    End Sub

    Public Function GetAdministrarPrecios(be As rutaTareoAutos) As List(Of rutaTareoAutos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetAdministrarPrecios(be)
    End Function

End Class
