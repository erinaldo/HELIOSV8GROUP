Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class CargosSA

    Public Function CargosSelAll() As List(Of Cargos)
        Dim miServicio = GetServiceProxy()
        Dim request As New CargosRequest
        request.Operacion = CargosOperation.CargosSelAll
        Dim response = miServicio.SCO_Cargos(request)
        Return response.CargosList
    End Function

    Public Function CargosSelxID(ByVal item As Cargos) As Cargos
        Dim miServicio = GetServiceProxy()
        Dim request As New CargosRequest
        request.Cargos = item
        request.Operacion = CargosOperation.CargosSelxID
        Dim response = miServicio.SCO_Cargos(request)
        Return response.Cargos
    End Function

    Public Function CargosSel(ByVal item As Cargos) As Cargos
        Dim miServicio = GetServiceProxy()
        Dim request As New CargosRequest
        request.Cargos = item
        request.Operacion = CargosOperation.CargosSel
        Dim response = miServicio.SCO_Cargos(request)
        Return response.Cargos
    End Function

    Public Sub CargosSave(ByVal item As Cargos, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New CargosRequest
        request.Cargos = item
        request.TransactionData = log
        request.Operacion = CargosOperation.CargosSave
        Dim response = miServicio.SCO_Cargos(request)
    End Sub

    Public Sub CargosDelete(ByVal item As Cargos, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New CargosRequest
        request.Cargos = item
        request.TransactionData = log
        request.Operacion = CargosOperation.CargosDelete
        Dim response = miServicio.SCO_Cargos(request)
    End Sub

End Class
