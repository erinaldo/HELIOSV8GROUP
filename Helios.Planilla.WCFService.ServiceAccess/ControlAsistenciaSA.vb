Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class ControlAsistenciaSA

    ''' <summary>
    ''' Retorna la lista de todo el Concepto por tipo concepto
    ''' </summary>
    ''' <param name="item">Tipo concepto</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ControlAsistenciaSelxIDPersonal(ByVal item As ControlAsistencia) As List(Of ControlAsistencia)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlAsistenciaRequest
        request.ControlAsistencia = item
        request.Operacion = ControlAsistenciaOperation.ControlAsistenciaSelxIDPersonal
        Dim response = miServicio.SCO_ControlAsistencia(request)
        Return response.ControlAsistenciaList
    End Function

    Public Function ControlAsistenciaSelxID(ByVal item As ControlAsistencia) As List(Of ControlAsistencia)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlAsistenciaRequest
        request.ControlAsistencia = item
        request.Operacion = ControlAsistenciaOperation.ControlAsistenciaSelxID
        Dim response = miServicio.SCO_ControlAsistencia(request)
        Return response.ControlAsistenciaList
    End Function

    Public Function ControlAsistenciaSelxIDPersonalFecha(ByVal item As ControlAsistencia) As List(Of ControlAsistencia)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlAsistenciaRequest
        request.ControlAsistencia = item
        request.Operacion = ControlAsistenciaOperation.ControlAsistenciaSelxIDPersonalFecha
        Dim response = miServicio.SCO_ControlAsistencia(request)
        Return response.ControlAsistenciaList
    End Function

    ''' <summary>
    ''' Retorna el Concepto por IDConcepto
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ControlAsistenciaSel(ByVal item As ControlAsistencia) As ControlAsistencia
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlAsistenciaRequest
        request.ControlAsistencia = item
        request.Operacion = ControlAsistenciaOperation.ControlAsistenciaSel
        Dim response = miServicio.SCO_ControlAsistencia(request)
        Return response.ControlAsistencia
    End Function

    Public Sub ControlAsistenciaSave(ByVal item As ControlAsistencia, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlAsistenciaRequest
        request.ControlAsistencia = item
        request.TransactionData = log
        request.Operacion = ControlAsistenciaOperation.ControlAsistenciaSave
        Dim response = miServicio.SCO_ControlAsistencia(request)
    End Sub

    Public Sub ControlAsistenciaDelete(ByVal item As ControlAsistencia, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlAsistenciaRequest
        request.ControlAsistencia = item
        request.TransactionData = log
        request.Operacion = ControlAsistenciaOperation.ControlAsistenciaDelete
        Dim response = miServicio.SCO_ControlAsistencia(request)
    End Sub
End Class
