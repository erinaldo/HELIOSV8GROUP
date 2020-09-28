Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class PersonalConceptosSA

    Public Function PersonalConceptosXIDAU(ByVal item As PersonalConceptos) As PersonalConceptos
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalConceptosRequest
        request.PersonalConceptos = item
        request.Operacion = PersonalConceptosOperation.PersonalConceptosXIDAU
        Dim response = miServicio.SCO_PersonalConceptos(request)
        Return response.PersonalConceptos
    End Function

    Public Function PersonalConceptosSelxBuscado(ByVal item As PersonalConceptos) As List(Of PersonalConceptos)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalConceptosRequest
        request.PersonalConceptos = item
        request.Operacion = PersonalConceptosOperation.PersonalConceptosSelxBuscado
        Dim response = miServicio.SCO_PersonalConceptos(request)
        Return response.PersonalConceptosList
    End Function

    Public Function PersonalConceptosSel(ByVal item As PersonalConceptos) As PersonalConceptos
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalConceptosRequest
        request.PersonalConceptos = item
        request.Operacion = PersonalConceptosOperation.PersonalConceptosSel
        Dim response = miServicio.SCO_PersonalConceptos(request)
        Return response.PersonalConceptos
    End Function

    Public Function PersonalConceptosSelxCargo(ByVal item As PersonalConceptos) As List(Of PersonalConceptos)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalConceptosRequest
        request.PersonalConceptos = item
        request.Operacion = PersonalConceptosOperation.PersonalConceptosSelxCargo
        Dim response = miServicio.SCO_PersonalConceptos(request)
        Return response.PersonalConceptosList
    End Function

    Public Sub PersonalConceptosSave(ByVal item As PersonalConceptos, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalConceptosRequest
        request.PersonalConceptos = item
        request.TransactionData = log
        request.Operacion = PersonalConceptosOperation.PersonalConceptosSave
        Dim response = miServicio.SCO_PersonalConceptos(request)
    End Sub

    Public Sub PersonalConceptosSaveLista(ByVal item As List(Of PersonalConceptos), log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalConceptosRequest
        request.PersonalConceptosList = item
        request.TransactionData = log
        request.Operacion = PersonalConceptosOperation.PersonalConceptosSaveLista
        Dim response = miServicio.SCO_PersonalConceptos(request)
        ' Return response
    End Sub

    Public Sub PersonalConceptosDelete(ByVal item As PersonalConceptos, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PersonalConceptosRequest
        request.PersonalConceptos = item
        request.TransactionData = log
        request.Operacion = PersonalConceptosOperation.PersonalConceptosDelete
        Dim response = miServicio.SCO_PersonalConceptos(request)
    End Sub

End Class
