Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class ConceptoRequest
    Inherits ItemRequest

    <MessageBodyMember> Property Operacion As ConceptoOperation
    <MessageBodyMember> Property Concepto As Concepto
    <MessageBodyMember> Property ConceptoList As List(Of Concepto)

End Class