Imports Helios.Cont.Business.Entity

Public Class VehiculoAsiento_PreciosSA
    Public Function CargaAsientos(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CargaAsientos(be)
    End Function

    Public Function GetConsultarEnviosPorProgramacion(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultarEnviosPorProgramacion(be)
    End Function

    Public Function getInfraestructuraTransporteXProgramacion(distribucionBE As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getInfraestructuraTransporteXProgramacion(distribucionBE)
    End Function

    Public Function updateAsientoTransportexID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateAsientoTransportexID(i)
    End Function

    Public Function updateAsientoTransportexIDxVerificaion(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateAsientoTransportexIDxVerificaion(i)
    End Function

    Public Function updateAsientoTransporteConfirmacionxID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateAsientoTransporteConfirmacionxID(i)
    End Function

    Public Function updateAsientoPrecioXall(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateAsientoPrecioXall(i)
    End Function

    Public Function updateAsientoPrecioXID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateAsientoPrecioXID(i)
    End Function

    Public Function updateAsientoPrecioXaNULACIONID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateAsientoPrecioXaNULACIONID(i)
    End Function

    Public Function GetConsultarProgramacionXbus(be As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultarProgramacionXbus(be)
    End Function

    Public Function GetConsultarProgramacionXbusAsientos(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConsultarProgramacionXbusAsientos(be)
    End Function
End Class
