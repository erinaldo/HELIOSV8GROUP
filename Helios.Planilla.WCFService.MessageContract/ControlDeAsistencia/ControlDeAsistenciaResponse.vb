Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class ControlDeAsistenciaResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property ControlDeAsistencia As ControlDeAsistencia
    <MessageBodyMember()> Property ControlDeAsistenciaList As List(Of ControlDeAsistencia)
    <MessageBodyMember()> Property GetAsistenciaXtrabajador As List(Of usp_GetAsistenciaXtrabajador_Result)
End Class
