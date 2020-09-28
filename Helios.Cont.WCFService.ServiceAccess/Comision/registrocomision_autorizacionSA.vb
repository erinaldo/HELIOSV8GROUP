Imports Helios.Cont.Business.Entity
Public Class registrocomision_autorizacionSA

    Public Sub registrocomision_autorizacionSaveList(lista As List(Of registrocomision_autorizacion))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.registrocomision_autorizacionSaveList(lista)
    End Sub

    Public Function registrocomision_autorizacionSelUsuario(be As registrocomision_usuarios_detalle) As List(Of registrocomision_autorizacion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.registrocomision_autorizacionSelUsuario(be)
    End Function

    Public Sub RegistrarPagosComnision(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.RegistrarPagosComnision(be)
    End Sub

End Class
