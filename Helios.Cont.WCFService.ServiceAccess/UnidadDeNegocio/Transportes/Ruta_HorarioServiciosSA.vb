
Imports Helios.Cont.Business.Entity

Public Class Ruta_HorarioServiciosSA
    Public Function GetServiciosVentaTransporte(be As ruta_HorarioServicios) As List(Of ruta_HorarioServicios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetServiciosVentaTransporte(be)
    End Function

    Public Sub ActualizarPrecio(be As ruta_HorarioServicios)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActualizarPrecio(be)
    End Sub
End Class
