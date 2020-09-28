Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PeriodosResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property Periodos As Periodos
    <MessageBodyMember()> Property PeriodosList As List(Of Periodos)

End Class