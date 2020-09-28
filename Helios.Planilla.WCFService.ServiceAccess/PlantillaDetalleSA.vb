Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract
Public Class PlantillaDetalleSA
    Public Function PlantillaDetalleSelxPlantillaV2(ByVal item As PlantillaDetalle) As List(Of PlantillaDetalle)
        Dim miServicio = GetServiceProxy()
        Dim request As New PlantillaDetalleRequest
        request.PlantillaDetalle = item
        request.Operacion = PlantillaDetalleOperation.PlantillaDetalleSelxPlantillaV2
        Dim response = miServicio.SCO_PlantillaDetalle(request)
        Return response.PlantillaDetalleList
    End Function

    Public Function PlantillaDetalleSelxPlantillaxConcepto(ByVal item As PlantillaDetalle) As PlantillaDetalle
        Dim miServicio = GetServiceProxy()
        Dim request As New PlantillaDetalleRequest
        request.PlantillaDetalle = item
        request.Operacion = PlantillaDetalleOperation.PlantillaDetalleSelxPlantillaxConcepto
        Dim response = miServicio.SCO_PlantillaDetalle(request)
        Return response.PlantillaDetalle
    End Function

    Public Sub PlantillaDetalleSave(ByVal item As PlantillaDetalle, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PlantillaDetalleRequest
        request.PlantillaDetalle = item
        request.TransactionData = log
        request.Operacion = PlantillaDetalleOperation.PlantillaDetalleSave
        Dim response = miServicio.SCO_PlantillaDetalle(request)
    End Sub

End Class
