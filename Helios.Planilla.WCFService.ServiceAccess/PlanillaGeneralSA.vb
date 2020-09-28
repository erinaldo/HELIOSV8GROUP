Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class PlanillaGeneralSA
    Public Function PlanillaGeneralSelxID(ByVal item As PlanillaGeneral) As PlanillaGeneral
        Dim miServicio = GetServiceProxy()
        Dim request As New PlanillaGeneralRequest
        request.PlanillaGeneral = item
        request.Operacion = PlanillaGeneralOperation.PlanillaGeneralSelxID
        Dim response = miServicio.SCO_PlanillaGeneral(request)
        Return response.PlanillaGeneral
    End Function

    Public Function PlanillaGeneralSelXPeriodo(ByVal item As PlanillaGeneral) As List(Of PlanillaGeneral)
        Dim miServicio = GetServiceProxy()
        Dim request As New PlanillaGeneralRequest
        request.PlanillaGeneral = item
        request.Operacion = PlanillaGeneralOperation.PlanillaGeneralSelXPeriodo
        Dim response = miServicio.SCO_PlanillaGeneral(request)
        Return response.PlanillaGeneralList
    End Function

    Public Function PlanillaGeneralSelxPersonalTipoConcepto(ByVal item As PlanillaGeneral) As List(Of PlanillaGeneral)
        Dim miServicio = GetServiceProxy()
        Dim request As New PlanillaGeneralRequest
        request.PlanillaGeneral = item
        request.Operacion = PlanillaGeneralOperation.PlanillaGeneralSelxPersonalTipoConcepto
        Dim response = miServicio.SCO_PlanillaGeneral(request)
        Return response.PlanillaGeneralList
    End Function

    ''' <summary>
    ''' Retorna el personal por IDPersonal
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PlanillaGeneralSel(ByVal item As PlanillaGeneral) As PlanillaGeneral
        Dim miServicio = GetServiceProxy()
        Dim request As New PlanillaGeneralRequest
        request.PlanillaGeneral = item
        request.Operacion = PlanillaGeneralOperation.PlanillaGeneralSel
        Dim response = miServicio.SCO_PlanillaGeneral(request)
        Return response.PlanillaGeneral
    End Function

    Public Sub PlanillaGeneralSave(ByVal item As PlanillaGeneral, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PlanillaGeneralRequest
        request.PlanillaGeneral = item
        request.TransactionData = log
        request.Operacion = PlanillaGeneralOperation.PlanillaGeneralSave
        Dim response = miServicio.SCO_PlanillaGeneral(request)
    End Sub

    Public Sub PlanillaGeneralDelete(ByVal item As PlanillaGeneral, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PlanillaGeneralRequest
        request.PlanillaGeneral = item
        request.TransactionData = log
        request.Operacion = PlanillaGeneralOperation.PlanillaGeneralDelete
        Dim response = miServicio.SCO_PlanillaGeneral(request)
    End Sub
End Class
