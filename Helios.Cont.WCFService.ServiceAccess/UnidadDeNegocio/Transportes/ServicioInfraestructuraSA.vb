Imports Helios.Cont.Business.Entity
Public Class ServicioInfraestructuraSA
    Public Function GellAllServiciosInfra() As List(Of servicioInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GellAllServiciosInfra()
    End Function

    Public Sub UpdateServicioInfraestructura(objDocumento As servicioInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateServicioInfraestructura(objDocumento)
    End Sub

    Public Sub InsertServicioInfraestructura(objDocumento As servicioInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertServicioInfraestructura(objDocumento)
    End Sub
End Class
