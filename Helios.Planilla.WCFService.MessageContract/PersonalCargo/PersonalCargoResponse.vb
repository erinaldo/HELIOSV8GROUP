Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PersonalCargoResponse
    Inherits ItemResponse

    <MessageBodyMember()> Property PersonalCargo As PersonalCargo
    <MessageBodyMember()> Property PersonalCargoList As List(Of PersonalCargo)

End Class
