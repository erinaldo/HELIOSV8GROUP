Imports Helios.Cont.Business.Entity
Public Class distribucionInfraestructuraSA

    Public Sub EliminarDistribucionFull(i As distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarDistribucionFull(i)
    End Sub

    Public Function getListaDistribucionInfraestructura(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaDistribucionInfraestructura(distribucionInfraestructuraBE)
    End Function

    Public Function SaveDistribucionInfraestructuraFull(distribucion As distribucionInfraestructura, listaDistribucionInfraestructura As List(Of distribucionInfraestructura)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveDistribucionInfraestructuraFull(distribucion, listaDistribucionInfraestructura)
    End Function

    Public Function getDistribucionInfraestructura(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getDistribucionInfraestructura(distribucionInfraestructuraBE)
    End Function

    Public Sub updateCategoriaXDistribucion(listaId As List(Of distribucionInfraestructura))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.updateCategoriaXDistribucion(listaId)
    End Sub

    Public Sub EditarNumeracion(i As distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarNumeracion(i)
    End Sub

    Public Function getDistribucionInfraestructuraXtipo(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getDistribucionInfraestructuraXtipo(distribucion)
    End Function

    Public Function getInfraestructura(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getInfraestructura(distribucion)
    End Function

    Public Function getDistribucionInfraHospedado(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getDistribucionInfraHospedado(distribucion)
    End Function

    Public Function getDistribucionXReserva(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getDistribucionXReserva(distribucionInfraestructuraBE)
    End Function

    Public Function updateDistribucionXRecepcion(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateDistribucionXRecepcion(listaID)
    End Function

    Public Function GetDistribucionXAgrupacion() As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDistribucionXAgrupacion()
    End Function

    Public Function GetDashboardDistribucion(documentoventaBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDashboardDistribucion(documentoventaBE)
    End Function

    Public Function GetDashBoardXCliente(documentoBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDashBoardXCliente(documentoBE)
    End Function

    Public Function GetDetalleHabitacion(documentoBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDetalleHabitacion(documentoBE)
    End Function

    Public Function getDistribucionInfraestructuraXtipoInfra(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getDistribucionInfraestructuraXtipoInfra(distribucion)
    End Function

    Public Function getDistribucionInfraestructuraXCategoria(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getDistribucionInfraestructuraXCategoria(distribucion)
    End Function

    Public Function updateDistribucionxID(i As distribucionInfraestructura) As distribucionInfraestructura
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateDistribucionxID(i)
    End Function

    Public Function updateDistribucionXCondicion(i As distribucionInfraestructura) As distribucionInfraestructura
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateDistribucionXCondicion(i)
    End Function

    Public Sub updateDistribucionMasivo(listaID As distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.updateDistribucionMasivo(listaID)
    End Sub

    Public Function updateDistribucionRecepcionMasivo(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateDistribucionRecepcionMasivo(listaID)
    End Function

    Public Sub updateDistribucioRecepciomMasivo(listaID As distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.updateDistribucioRecepciomMasivo(listaID)
    End Sub


    Public Function GetDistribucionInfraestructuraConPrecios(empresa As String, tipo As String) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDistribucionInfraestructuraConPrecios(empresa, tipo)
    End Function

    Public Sub updateDistribucioTrasnportemMasivo(listaID As distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.updateDistribucioTrasnportemMasivo(listaID)
    End Sub

    Public Function getInfraestructuraTransporte(distribucion As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getInfraestructuraTransporte(distribucion)
    End Function

    Public Function GetDistribucionAsignacionItem(distriBE As distribucionInfraestructura) As distribucionInfraestructura
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetDistribucionAsignacionItem(distriBE)
    End Function

    Public Function updateDistribucionTransportexID(i As distribucionInfraestructura) As distribucionInfraestructura
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateDistribucionTransportexID(i)
    End Function

    Public Function getDistribucionInfraestructuraPlantilla(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getDistribucionInfraestructuraPlantilla(distribucionInfraestructuraBE)
    End Function

    Public Function updateDistribucionNumeracion(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateDistribucionNumeracion(listaID)
    End Function

End Class
