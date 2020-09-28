Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class ControlAsistenciaRequest
    Inherits ItemRequest

    <MessageBodyMember> Property Operacion As ControlAsistenciaOperation
    <MessageBodyMember> Property ControlAsistencia As ControlAsistencia
    <MessageBodyMember> Property ControlAsistenciaList As List(Of ControlAsistencia)

End Class