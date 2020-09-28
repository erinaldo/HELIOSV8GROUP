Imports Helios.Cont.Business.Entity
Public Class configuracionReservaSA

    Public Function GetConfiguracion(configuracionBE As configuracionReserva) As List(Of configuracionReserva)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConfiguracion(configuracionBE)
    End Function

    Public Function GetConfiguracionID(be As configuracionReserva) As configuracionReserva
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConfiguracionID(be)
    End Function

    Public Function GetConfiguracionInsert(be As configuracionReserva) As configuracionReserva
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConfiguracionInsert(be)
    End Function

    Public Function GetConfiguracionUpdate(be As configuracionReserva) As configuracionReserva
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConfiguracionUpdate(be)
    End Function

End Class
