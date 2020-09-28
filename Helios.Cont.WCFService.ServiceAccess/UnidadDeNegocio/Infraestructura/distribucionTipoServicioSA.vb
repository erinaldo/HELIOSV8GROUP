Imports Helios.Cont.Business.Entity
Public Class distribucionTipoServicioSA

    Public Function GetUbicarDistribucionTipoServicio(composicionBE As distribucionTipoServicio) As List(Of distribucionTipoServicio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarDistribucionTipoServicio(composicionBE)
    End Function

    Public Function Save_ListaDistribucionTipoServicio(ListaDistribucion As List(Of distribucionTipoServicio)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Save_ListaDistribucionTipoServicio(ListaDistribucion)
    End Function

    Public Sub DeleteTipoServicioFull(ByVal ListaTipo As List(Of distribucionTipoServicio))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteTipoServicioFull(ListaTipo)
    End Sub

End Class
