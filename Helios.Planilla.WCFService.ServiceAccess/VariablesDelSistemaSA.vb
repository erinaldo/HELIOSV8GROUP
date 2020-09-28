Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract

Public Class VariablesDelSistemaSA

    Public Function VariablesDelSistemaSelxID(ByVal item As VariablesDelSistema) As List(Of VariablesDelSistema)
        Dim miServicio = GetServiceProxy()
        Dim request As New VariablesDelSistemaRequest
        request.VariablesDelSistema = item
        request.Operacion = VariablesDelSistemaOperation.VariablesDelSistemaSelxTipoConcepto
        Dim response = miServicio.SCO_VariablesDelSistema(request)
        Return response.VariablesDelSistemaList
    End Function

    Public Function VariablesDelSistemaSel(ByVal item As VariablesDelSistema) As VariablesDelSistema
        Dim miServicio = GetServiceProxy()
        Dim request As New VariablesDelSistemaRequest
        request.VariablesDelSistema = item
        request.Operacion = VariablesDelSistemaOperation.VariablesDelSistemaSel
        Dim response = miServicio.SCO_VariablesDelSistema(request)
        Return response.VariablesDelSistema
    End Function
End Class
