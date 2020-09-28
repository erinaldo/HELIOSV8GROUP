Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class DerechoHabientesRequest
    Inherits ItemRequest

    <MessageBodyMember> Property Operacion As DerechoHabientesOperation
    <MessageBodyMember> Property DerechoHabientes As DerechoHabientes
    <MessageBodyMember> Property DerechoHabientesList As List(Of DerechoHabientes)

End Class

