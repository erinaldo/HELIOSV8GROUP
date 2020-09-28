Imports Helios.Cont.Business.Entity
Public Class cajaUsuarioDetalleSA

    Public Function ListaDetallePorCaja(intIdCajaUsuario As Integer) As List(Of cajaUsuariodetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaDetallePorCaja(intIdCajaUsuario)
    End Function

    Public Function ListaDetalleUsuarioXUsuario(be As cajaUsuario) As List(Of cajaUsuariodetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaDetalleUsuarioXUsuario(be)
    End Function

    Public Function ResumenDetailVenta(be As cajaUsuario) As List(Of cajaUsuariodetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenDetailVenta(be)
    End Function

    Public Function ListaDetalleUsuarioXEntidades(be As cajaUsuario) As List(Of cajaUsuariodetalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaDetalleUsuarioXEntidades(be)
    End Function

End Class

