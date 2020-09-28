Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class ConceptoSA

    ''' <summary>
    ''' Retorna la lista de todo el Concepto por tipo concepto
    ''' </summary>
    ''' <param name="item">Tipo concepto</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConceptoSelxTipoConcepto(ByVal item As Concepto) As List(Of Concepto)
        Dim miServicio = GetServiceProxy()
        Dim request As New ConceptoRequest
        request.Concepto = item
        request.Operacion = ConceptoOperation.ConceptoSelxTipoConcepto
        Dim response = miServicio.SCO_Concepto(request)
        Return response.ConceptoList
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="item">Tipo concepto, Cargo{Tipo Planilla}</param>
    ''' <returns></returns>
    Public Function ConceptoSelxCargo(ByVal item As Concepto) As List(Of Concepto)
        Dim miServicio = GetServiceProxy()
        Dim request As New ConceptoRequest
        request.Concepto = item
        request.Operacion = ConceptoOperation.ConceptoSelxCargo
        Dim response = miServicio.SCO_Concepto(request)
        Return response.ConceptoList
    End Function

    Public Function ConceptoSelxActivo(ByVal item As Concepto) As List(Of Concepto)
        Dim miServicio = GetServiceProxy()
        Dim request As New ConceptoRequest
        request.Concepto = item
        request.Operacion = ConceptoOperation.ConceptoSelxActivo
        Dim response = miServicio.SCO_Concepto(request)
        Return response.ConceptoList
    End Function

    ''' <summary>
    ''' Retorna el Concepto por IDConcepto
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConceptoSel(ByVal item As Concepto) As Concepto
        Dim miServicio = GetServiceProxy()
        Dim request As New ConceptoRequest
        request.Concepto = item
        request.Operacion = ConceptoOperation.ConceptoSel
        Dim response = miServicio.SCO_Concepto(request)
        Return response.Concepto
    End Function

    Public Function ConceptoSelxID(ByVal item As Concepto) As Concepto
        Dim miServicio = GetServiceProxy()
        Dim request As New ConceptoRequest
        request.Concepto = item
        request.Operacion = ConceptoOperation.ConceptoSelxID
        Dim response = miServicio.SCO_Concepto(request)
        Return response.Concepto
    End Function

    Public Sub ConceptoSave(ByVal item As Concepto, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New ConceptoRequest
        request.Concepto = item
        request.TransactionData = log
        request.Operacion = ConceptoOperation.ConceptoSave
        Dim response = miServicio.SCO_Concepto(request)
    End Sub

    Public Sub ConceptoDelete(ByVal item As Concepto, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New ConceptoRequest
        request.Concepto = item
        request.TransactionData = log
        request.Operacion = ConceptoOperation.ConceptoDelete
        Dim response = miServicio.SCO_Concepto(request)
    End Sub
End Class