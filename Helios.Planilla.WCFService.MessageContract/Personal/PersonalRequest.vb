Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PersonalRequest
    Inherits ItemRequest
    <MessageBodyMember> Property Operacion As PersonalOperation
    <MessageBodyMember> Property Personal As Personal
    <MessageBodyMember> Property PersonalList As List(Of Personal)
End Class
