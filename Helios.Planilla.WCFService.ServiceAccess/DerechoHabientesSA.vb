Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class DerechoHabientesSA
    Public Function DerechoHabientesSelxBuscado(ByVal item As DerechoHabientes) As List(Of DerechoHabientes)
        Dim miServicio = GetServiceProxy()
        Dim request As New DerechoHabientesRequest
        request.DerechoHabientes = item
        request.Operacion = DerechoHabientesOperation.DerechoHabientesSelxBuscado
        Dim response = miServicio.SCO_DerechoHabientes(request)
        Return response.DerechoHabientesList
    End Function

    Public Function DerechoHabientesSel(ByVal item As DerechoHabientes) As DerechoHabientes
        Dim miServicio = GetServiceProxy()
        Dim request As New DerechoHabientesRequest
        request.DerechoHabientes = item
        request.Operacion = DerechoHabientesOperation.DerechoHabientesSel
        Dim response = miServicio.SCO_DerechoHabientes(request)
        Return response.DerechoHabientes
    End Function

    Public Sub DerechoHabientesSave(ByVal item As DerechoHabientes, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New DerechoHabientesRequest
        request.DerechoHabientes = item
        request.TransactionData = log
        request.Operacion = DerechoHabientesOperation.DerechoHabientesSave
        Dim response = miServicio.SCO_DerechoHabientes(request)
    End Sub

    Public Sub DerechoHabientesDelete(ByVal item As DerechoHabientes, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New DerechoHabientesRequest
        request.DerechoHabientes = item
        request.TransactionData = log
        request.Operacion = DerechoHabientesOperation.DerechoHabientesDelete
        Dim response = miServicio.SCO_DerechoHabientes(request)
    End Sub

End Class
