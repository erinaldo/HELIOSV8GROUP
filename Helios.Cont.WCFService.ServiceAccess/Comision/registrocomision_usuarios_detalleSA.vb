Imports Helios.Cont.Business.Entity
Public Class registrocomision_usuarios_detalleSA
    Public Function registrocomision_usuarios_detalleJoinList(be As registrocomision_usuarios) As List(Of registrocomision_usuarios_detalle)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.registrocomision_usuarios_detalleJoinList(be)
    End Function

    Public Sub ChangeStatusComisionRegistro(be As registrocomision_usuarios_detalle)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ChangeStatusComisionRegistro(be)
    End Sub
End Class
