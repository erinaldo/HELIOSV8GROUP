Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class ControlAsistenciaResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property ControlAsistencia As ControlAsistencia
    <MessageBodyMember()> Property ControlAsistenciaList As List(Of ControlAsistencia)

End Class
