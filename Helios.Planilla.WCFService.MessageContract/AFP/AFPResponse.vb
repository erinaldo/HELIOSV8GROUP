Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class AFPResponse
    Inherits ItemResponse

    <MessageBodyMember()> Property AFPList As List(Of Afp)
    <MessageBodyMember()> Property AFP As Afp

End Class
