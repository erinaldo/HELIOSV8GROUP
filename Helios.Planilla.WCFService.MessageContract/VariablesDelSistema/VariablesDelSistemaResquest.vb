Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class VariablesDelSistemaRequest
    Inherits ItemRequest

    <MessageBodyMember> Property Operacion As VariablesDelSistemaOperation
    <MessageBodyMember> Property VariablesDelSistema As VariablesDelSistema
    <MessageBodyMember> Property VariablesDelSistemaList As List(Of VariablesDelSistema)

End Class