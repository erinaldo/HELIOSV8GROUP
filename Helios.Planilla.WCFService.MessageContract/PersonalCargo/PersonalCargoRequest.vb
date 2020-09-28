Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PersonalCargoRequest
    Inherits ItemRequest

    <MessageBodyMember> Property Operacion As PersonalCargoOperation
    <MessageBodyMember> Property PersonalCargo As PersonalCargo
    <MessageBodyMember> Property PersonalCargoList As List(Of PersonalCargo)
End Class
