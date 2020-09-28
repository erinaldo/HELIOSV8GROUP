Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PlanillaGeneralResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property PlanillaGeneral As PlanillaGeneral
    <MessageBodyMember()> Property PlanillaGeneralList As List(Of PlanillaGeneral)

End Class
