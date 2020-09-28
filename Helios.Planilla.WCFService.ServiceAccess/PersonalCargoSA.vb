Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract
Public Class PersonalCargoSA

    Public Function PersonalCargoSelxAll(ByVal item As PersonalCargo) As List(Of PersonalCargo)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalCargoRequest
        request.PersonalCargo = item
        request.Operacion = PersonalCargoOperation.PersonalCargoSelxAll
        Dim response = miServicio.SCO_PersonalCargo(request)
        Return response.PersonalCargoList
    End Function

    Public Function PersonalCargoSel(ByVal item As PersonalCargo) As List(Of PersonalCargo)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalCargoRequest
        request.PersonalCargo = item
        request.Operacion = PersonalCargoOperation.PersonalCargoSel
        Dim response = miServicio.SCO_PersonalCargo(request)
        Return response.PersonalCargoList
    End Function

    Public Function PersonalCargoSelxID(ByVal item As PersonalCargo) As PersonalCargo
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalCargoRequest
        request.PersonalCargo = item
        request.Operacion = PersonalCargoOperation.PersonalCargoSelxID
        Dim response = miServicio.SCO_PersonalCargo(request)
        Return response.PersonalCargo
    End Function

    Public Function PersonalCargoSelxCargo(ByVal item As PersonalCargo) As PersonalCargo
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalCargoRequest
        request.PersonalCargo = item
        request.Operacion = PersonalCargoOperation.PersonalCargoSelxCargo
        Dim response = miServicio.SCO_PersonalCargo(request)
        Return response.PersonalCargo
    End Function

    Public Sub PersonalCargoSave(ByVal item As PersonalCargo, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalCargoRequest
        request.PersonalCargo = item
        request.TransactionData = log
        request.Operacion = PersonalCargoOperation.PersonalCargoSave
        Dim response = miServicio.SCO_PersonalCargo(request)
    End Sub


End Class
