Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class PersonalSA
    ''' <summary>
    ''' Retorna la lista de todo el personal por estado
    ''' </summary>
    ''' <param name="item">Estado</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PersonalSelxEstado(ByVal item As Personal) As List(Of Personal)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalRequest
        request.Personal = item
        request.Operacion = PersonalOperation.PersonalSelxEstado
        Dim response = miServicio.SCO_Personal(request)
        Return response.PersonalList
    End Function

    Public Function PersonalSelStartwithNombres(ByVal item As Personal) As List(Of Personal)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalRequest
        request.Personal = item
        request.Operacion = PersonalOperation.PersonalSelStartwithNombres
        Dim response = miServicio.SCO_Personal(request)
        Return response.PersonalList
    End Function

    Public Function PersonalSelxID(ByVal item As Personal) As Personal
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalRequest
        request.Personal = item
        request.Operacion = PersonalOperation.PersonalSelxID
        Dim response = miServicio.SCO_Personal(request)
        Return response.Personal
    End Function
    Public Function PersonalSelxDNI(ByVal item As Personal) As Personal
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalRequest
        request.Personal = item
        request.Operacion = PersonalOperation.PersonalSelxDNI
        Dim response = miServicio.SCO_Personal(request)
        Return response.Personal
    End Function
    ''' <summary>
    ''' Retorna el personal por IDPersonal
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PersonalSel(ByVal item As Personal) As Personal
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalRequest
        request.Personal = item
        request.Operacion = PersonalOperation.PersonalSel
        Dim response = miServicio.SCO_Personal(request)
        Return response.Personal
    End Function

    Public Sub PersonalSave(ByVal item As Personal, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalRequest
        request.Personal = item
        request.TransactionData = log
        request.Operacion = PersonalOperation.PersonalSave
        Dim response = miServicio.SCO_Personal(request)
    End Sub

    Public Sub PersonalDelete(ByVal item As Personal, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalRequest
        request.Personal = item
        request.TransactionData = log
        request.Operacion = PersonalOperation.PersonalDelete
        Dim response = miServicio.SCO_Personal(request)
    End Sub
End Class
