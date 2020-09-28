Imports Helios.Cont.Business.Entity
Public Class cajaUsuarioRPTSA
    Public Function ResumenTransaccionesXusuarioCajaReporte(be As cajaUsuario) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenTransaccionesXusuarioCajaReporte(be)
    End Function
End Class
