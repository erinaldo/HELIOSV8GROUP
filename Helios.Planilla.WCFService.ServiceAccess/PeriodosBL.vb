Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class PeriodosBL

    Public Function PeriodosSelxID(ByVal item As Periodos) As Periodos
        Dim miServicio = GetServiceProxy()
        Dim request As New PeriodosRequest
        request.Periodos = item
        request.Operacion = PeriodosOperation.PeriodosSelxID
        Dim response = miServicio.SCO_Periodos(request)
        Return response.Periodos
    End Function

    ''' <summary>
    ''' Retorna el Periodos por IDPeriodos
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PeriodosSel(ByVal item As Periodos) As Periodos
        Dim miServicio = GetServiceProxy()
        Dim request As New PeriodosRequest
        request.Periodos = item
        request.Operacion = PeriodosOperation.PeriodosSel
        Dim response = miServicio.SCO_Periodos(request)
        Return response.Periodos
    End Function

    Public Sub PeriodosSave(ByVal item As Periodos, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PeriodosRequest
        request.Periodos = item
        request.TransactionData = log
        request.Operacion = PeriodosOperation.PeriodosSave
        Dim response = miServicio.SCO_Periodos(request)
    End Sub

    Public Sub PeriodosDelete(ByVal item As Periodos, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PeriodosRequest
        request.Periodos = item
        request.TransactionData = log
        request.Operacion = PeriodosOperation.PeriodosDelete
        Dim response = miServicio.SCO_Periodos(request)
    End Sub
End Class
