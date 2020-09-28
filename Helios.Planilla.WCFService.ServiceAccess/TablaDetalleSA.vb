Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract
Public Class TablaDetalleSA
    Public Sub TablaDetalleSaveAll(ByVal item As TablaDetalle, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New TablaDetalleRequest
        request.TablaDetalle = item
        request.TransactionData = log
        request.Operacion = TablaDetalleOperation.TablaDetalleSelxTabla
        Dim response = miServicio.SCO_TablaDetalle(request)

    End Sub

    Public Function TablaDetalleSelxTabla(ByVal item As TablaDetalle) As List(Of TablaDetalle)
        Dim miServicio = GetServiceProxy()
        Dim request As New TablaDetalleRequest
        request.TablaDetalle = item
        request.Operacion = TablaDetalleOperation.TablaDetalleSelxTabla
        Dim response = miServicio.SCO_TablaDetalle(request)
        Return response.TablaDetalleList
    End Function

    Public Function TablaDetalleDepartamentos() As List(Of TablaDetalle)
        Dim miServicio = GetServiceProxy()
        Dim request As New TablaDetalleRequest
        request.Operacion = TablaDetalleOperation.TablaDetalleDepartamentos
        Dim response = miServicio.SCO_TablaDetalle(request)
        Return response.TablaDetalleList
    End Function

    Public Function TablaDetalleProvincia(ByVal item As TablaDetalle) As List(Of TablaDetalle)
        Dim miServicio = GetServiceProxy()
        Dim request As New TablaDetalleRequest
        request.TablaDetalle = item
        request.Operacion = TablaDetalleOperation.TablaDetalleProvincia
        Dim response = miServicio.SCO_TablaDetalle(request)
        Return response.TablaDetalleList
    End Function

    Public Function TablaDetalleDistrito(ByVal item As TablaDetalle) As List(Of TablaDetalle)
        Dim miServicio = GetServiceProxy()
        Dim request As New TablaDetalleRequest
        request.TablaDetalle = item
        request.Operacion = TablaDetalleOperation.TablaDetalleDistrito
        Dim response = miServicio.SCO_TablaDetalle(request)
        Return response.TablaDetalleList
    End Function

End Class
