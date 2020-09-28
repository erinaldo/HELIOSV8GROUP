Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class PersonalHorariosSA

    Public Function PersonalHorariosSelxIDPersonal(ByVal item As PersonalHorarios) As List(Of PersonalHorarios)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalHorariosRequest
        request.PersonalHorarios = item
        request.Operacion = PersonalHorariosOperation.PersonalHorariosSelxIDPersonal
        Dim response = miServicio.SCO_PersonalHorarios(request)
        Return response.PersonalHorariosList
    End Function

    Public Function PersonalHorariosSelxCargo(ByVal item As PersonalHorarios) As List(Of PersonalHorarios)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalHorariosRequest
        request.PersonalHorarios = item
        request.Operacion = PersonalHorariosOperation.PersonalHorariosSelxCargo
        Dim response = miServicio.SCO_PersonalHorarios(request)
        Return response.PersonalHorariosList
    End Function

    Public Function PersonalHorariosSel(ByVal item As PersonalHorarios) As PersonalHorarios
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalHorariosRequest
        request.PersonalHorarios = item
        request.Operacion = PersonalHorariosOperation.PersonalHorariosSel
        Dim response = miServicio.SCO_PersonalHorarios(request)
        Return response.PersonalHorarios
    End Function

    Public Function PersonalHorariosSelxID(ByVal item As PersonalHorarios) As PersonalHorarios
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalHorariosRequest
        request.PersonalHorarios = item
        request.Operacion = PersonalHorariosOperation.PersonalHorariosSelxID
        Dim response = miServicio.SCO_PersonalHorarios(request)
        Return response.PersonalHorarios
    End Function

    Public Function PersonalHorariosSelxIDPersonalDiaSemana(ByVal item As PersonalHorarios) As PersonalHorarios
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalHorariosRequest
        request.PersonalHorarios = item
        request.Operacion = PersonalHorariosOperation.PersonalHorariosSelxIDPersonalDiaSemana
        Dim response = miServicio.SCO_PersonalHorarios(request)
        Return response.PersonalHorarios
    End Function

    Public Sub PersonalHorariosSave(ByVal item As PersonalHorarios, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalHorariosRequest
        request.PersonalHorarios = item
        request.TransactionData = log
        request.Operacion = PersonalHorariosOperation.PersonalHorariosSave
        Dim response = miServicio.SCO_PersonalHorarios(request)
    End Sub

    Public Sub PersonalHorariosSaveLista(ByVal item As List(Of PersonalHorarios), log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalHorariosRequest
        request.PersonalHorariosList = item
        request.TransactionData = log
        request.Operacion = PersonalHorariosOperation.PersonalHorariosSaveLista
        Dim response = miServicio.SCO_PersonalHorarios(request)
    End Sub

    Public Sub PersonalHorariosDelete(ByVal item As PersonalHorarios, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalHorariosRequest
        request.PersonalHorarios = item
        request.TransactionData = log
        request.Operacion = PersonalHorariosOperation.PersonalHorariosDelete
        Dim response = miServicio.SCO_PersonalHorarios(request)
    End Sub

End Class
