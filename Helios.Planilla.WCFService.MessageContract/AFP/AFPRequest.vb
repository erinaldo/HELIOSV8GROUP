Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity
<MessageContract(IsWrapped:=True)>
Public Class AFPRequest
    Inherits ItemRequest

    <MessageBodyMember> Property Operacion As AFPOperation
    <MessageBodyMember> Property AFPList As List(Of Afp)
    <MessageBodyMember> Property AFP As Afp
End Class
