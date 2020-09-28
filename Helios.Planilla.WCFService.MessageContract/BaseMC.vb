Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class ItemRequest
    <MessageBodyMember()>
    Property TransactionData As TransactionDataBE
End Class
<MessageContract(IsWrapped:=True)>
Public Class ItemResponse
    <MessageBodyMember()> Property Rpta As Boolean
    <MessageBodyMember()> Property Mensajes As List(Of String)
End Class
