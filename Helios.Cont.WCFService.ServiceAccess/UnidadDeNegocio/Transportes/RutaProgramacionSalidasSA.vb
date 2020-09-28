Imports Helios.Cont.Business.Entity

Public Class RutaProgramacionSalidasSA

    Public Function GetProgramacionPorFechaLaboral(be As rutaProgramacionSalidas) As List(Of rutaProgramacionSalidas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProgramacionPorFechaLaboral(be)
    End Function

    Public Function GetProgramacionEstatus(be As rutaProgramacionSalidas) As List(Of rutaProgramacionSalidas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProgramacionEstatus(be)
    End Function

    Public Function GetProgramacionSelRutaMostrador(ruta_id As Integer) As List(Of rutaProgramacionSalidas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProgramacionSelRutaMostrador(ruta_id)
    End Function

    Public Function programacionSave(be As rutaProgramacionSalidas) As rutaProgramacionSalidas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.programacionSave(be)
    End Function
    Public Function programacionXBusXHorarioSave(be As rutaProgramacionSalidas, listaAsientoXBus As List(Of vehiculoAsiento_Precios)) As rutaProgramacionSalidas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.programacionXBusXHorarioSave(be, listaAsientoXBus)
    End Function

    Public Function programacionXBusXCambioPlacaSave(be As rutaProgramacionSalidas, listaAsientoXBus As List(Of vehiculoAsiento_Precios)) As rutaProgramacionSalidas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.programacionXBusXCambioPlacaSave(be, listaAsientoXBus)
    End Function

    Public Function GetProgramacionSelRuta(ruta_id As Object) As List(Of rutaProgramacionSalidas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetProgramacionSelRuta(ruta_id)
    End Function


    ''' <summary>
    ''' Rutas activas para la venta de pasajes
    ''' </summary>
    ''' <param name="be"></param>
    ''' <returns></returns>
    Public Function ProgramacionSelRutasActivas(be As rutaProgramacionSalidas) As List(Of rutas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ProgramacionSelRutasActivas(be)
    End Function

    Public Sub UpdateEstadoProgramacion(obj As rutaProgramacionSalidas)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateEstadoProgramacion(obj)
    End Sub

    Public Sub GrabarConsolidacion(obj As rutaTareoAutos, estadoProgramacion As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarConsolidacion(obj, estadoProgramacion)
    End Sub

    Public Function ProgramacionSelID(be As rutaProgramacionSalidas) As rutaProgramacionSalidas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ProgramacionSelID(be)
    End Function

    Public Function ProgramacionManifiestoSelID(be As rutaProgramacionSalidas) As rutaProgramacionSalidas

        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ProgramacionManifiestoSelID(be)
    End Function

End Class
