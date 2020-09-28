Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PlanillaGeneralRequest
    Inherits ItemRequest
    <MessageBodyMember> Property Operacion As PlanillaGeneralOperation
    <MessageBodyMember> Property PlanillaGeneral As PlanillaGeneral
    <MessageBodyMember> Property PlanillaGeneralList As List(Of PlanillaGeneral)
End Class
