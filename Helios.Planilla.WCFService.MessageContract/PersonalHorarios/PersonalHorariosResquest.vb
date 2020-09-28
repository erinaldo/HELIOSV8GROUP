Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PersonalHorariosRequest
    Inherits ItemRequest
    <MessageBodyMember> Property Operacion As PersonalHorariosOperation
    <MessageBodyMember> Property PersonalHorarios As PersonalHorarios
    <MessageBodyMember> Property PersonalHorariosList As List(Of PersonalHorarios)
End Class
