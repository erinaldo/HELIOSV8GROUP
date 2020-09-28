Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class ControlDeAsistenciaSA

    ''' <summary>
    ''' Retorna la lista de todo el Concepto por tipo concepto
    ''' </summary>
    ''' <param name="item">Tipo concepto</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ControlDeAsistenciaSelxIDAsistencia(ByVal item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.Operacion = ControlDeAsistenciaOperation.ControlDeAsistenciaSelxIDAsistencia
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
        Return response.ControlDeAsistenciaList
    End Function
    Public Function ControlDeAsistenciaSelxIDPersonal_SP(ByVal item As ControlDeAsistencia) As List(Of usp_GetAsistenciaXtrabajador_Result)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.Operacion = ControlDeAsistenciaOperation.ControlDeAsistenciaSelxIDPersonal_SP
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
        Return response.GetAsistenciaXtrabajador
    End Function

    Public Function ControldeAsistenciaSelxPersonalDetalle(ByVal item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.Operacion = ControlDeAsistenciaOperation.ControldeAsistenciaSelxPersonalDetalle
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
        Return response.ControlDeAsistenciaList
    End Function

    Public Function ControlDeAsistenciaSelxIDPersonal(ByVal item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.Operacion = ControlDeAsistenciaOperation.ControlDeAsistenciaSelxIDPersonal
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
        Return response.ControlDeAsistenciaList
    End Function


    ''' <summary>
    ''' Retorna el Concepto por IDConcepto
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ControlDeAsistenciaSel(ByVal item As ControlDeAsistencia) As ControlDeAsistencia
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.Operacion = ControlDeAsistenciaOperation.ControlDeAsistenciaSel
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
        Return response.ControlDeAsistencia
    End Function


    Public Function ControlDeAsistenciaSelxPersonalFecha(ByVal item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.Operacion = ControlDeAsistenciaOperation.ControlDeAsistenciaSelxPersonalFecha
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
        Return response.ControlDeAsistenciaList
    End Function


    Public Function ControlDeAsistenciaSelxIDPersonalFecha(ByVal item As ControlDeAsistencia) As ControlDeAsistencia
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.Operacion = ControlDeAsistenciaOperation.ControlDeAsistenciaSelxIDPersonalFecha
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
        Return response.ControlDeAsistencia
    End Function

    Public Sub ControlDeAsistenciaSave(ByVal item As ControlDeAsistencia, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.TransactionData = log
        request.Operacion = ControlDeAsistenciaOperation.ControlDeAsistenciaSave
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
    End Sub

    Public Sub ControlDeAsistenciaDelete(ByVal item As ControlDeAsistencia, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.TransactionData = log
        request.Operacion = ControlDeAsistenciaOperation.ControlDeAsistenciaDelete
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
    End Sub

    Public Function ControlDeAsistenciaSelxSocio(item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Dim miServicio = GetServiceProxy()
        Dim request As New ControlDeAsistenciaRequest
        request.ControlDeAsistencia = item
        request.Operacion = ControlDeAsistenciaOperation.ControlDeAsistenciaSelxSocio
        Dim response = miServicio.SCO_ControlDeAsistencia(request)
        Return response.ControlDeAsistenciaList
    End Function
End Class
