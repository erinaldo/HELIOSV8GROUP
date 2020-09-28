Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class AFPSA
    Public Function AFPSelAll(ByVal item As Afp) As List(Of Afp)
        Dim miServicio = GetServiceProxy()
        Dim request As New AFPRequest
        request.AFP = item
        request.Operacion = AFPOperation.AFPSelAll
        Dim response = miServicio.SCO_AFP(request)
        Return response.AFPList
    End Function

    Public Function AFPSelxID(ByVal item As Afp) As List(Of Afp)
        Dim miServicio = GetServiceProxy()
        Dim request As New AFPRequest
        request.AFP = item
        request.Operacion = AFPOperation.AFPSelxID
        Dim response = miServicio.SCO_AFP(request)
        Return response.AFPList
    End Function

    Public Function AFPSave(ByVal item As Afp) As List(Of Afp)
        Dim miServicio = GetServiceProxy()
        Dim request As New AFPRequest
        request.AFP = item
        request.Operacion = AFPOperation.AFPSave
        Dim response = miServicio.SCO_AFP(request)
        Return response.AFPList
    End Function

    Public Sub AFPDelete(ByVal item As Afp, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New AFPRequest
        request.AFP = item
        request.TransactionData = log
        request.Operacion = AFPOperation.AFPDelete
        Dim response = miServicio.SCO_AFP(request)
    End Sub

End Class
