Imports Helios.Cont.Business.Entity
Public Class tipoServicioInfraestructuraSA

    Public Function GetUbicartipoServicioInfraestructura(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicartipoServicioInfraestructura(tipoServicioInfraestructuraBE)
    End Function

    Public Function GetUbicartipoServicioInfraSinClasificacion(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicartipoServicioInfraSinClasificacion(tipoServicioInfraestructuraBE)
    End Function

    Public Function GetUbicartipoServicioInfra(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicartipoServicioInfra(tipoServicioInfraestructuraBE)
    End Function

    Public Function SaveTipoServicioInfraestructura(objCategoria As tipoServicioInfraestructura) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveTipoServicioInfraestructura(objCategoria)
    End Function

End Class
