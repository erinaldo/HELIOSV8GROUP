Imports Helios.Cont.Business.Entity
Public Class notificacionAlmacenSA

    Function GetUbicarNotificacion(strIdEmpresa As String, intIdEstablecimiento As Integer, strEstado As String) As List(Of notificacionAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarNotificacion(strIdEmpresa, intIdEstablecimiento, strEstado)
    End Function

    Function GetUbicarNotificacionCaja(strIdEmpresa As String, intIdEstablecimiento As Integer, strEstado As String) As List(Of notificacionAlmacen)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarNotificacionCaja(strIdEmpresa, intIdEstablecimiento, strEstado)
    End Function

    Function GetUbicarNotificacionConteo(strIdEmpresa As String, intIdEstablecimiento As Integer, strSituacioN As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarNotificacionConteo(strIdEmpresa, intIdEstablecimiento, strSituacioN)
    End Function

    Public Sub DeleteNotificacion(intIdDocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteNotificacion(intIdDocumento)
    End Sub

End Class
