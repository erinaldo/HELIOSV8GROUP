Imports Helios.Cont.Business.Entity

Public Class documentoAnticipoConciliacionSA
    Public Function GetMovimientosByCajaUsuario(be As documentoAnticipoConciliacion) As List(Of documentoAnticipoConciliacion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosByCajaUsuario(be)
    End Function

    Public Function GetMovimientosByDocumento(be As documentoAnticipoConciliacion) As List(Of documentoAnticipoConciliacion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosByDocumento(be)
    End Function
End Class
