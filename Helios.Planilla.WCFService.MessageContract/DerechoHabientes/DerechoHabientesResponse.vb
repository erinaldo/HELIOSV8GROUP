Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class DerechoHabientesResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property DerechoHabientes As DerechoHabientes
    <MessageBodyMember()> Property DerechoHabientesList As List(Of DerechoHabientes)

End Class