Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class TablaDetalleResponse
    Inherits ItemResponse

    <MessageBodyMember()> Property TablaDetalleList As List(Of TablaDetalle)
    <MessageBodyMember()> Property TablaDetalle As TablaDetalle

End Class
