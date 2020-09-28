Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PersonalResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property Personal As Personal
    <MessageBodyMember()> Property PersonalList As List(Of Personal)

End Class