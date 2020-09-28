Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity
<MessageContract(IsWrapped:=True)>
Public Class TablaDetalleRequest
    Inherits ItemRequest

    <MessageBodyMember> Property Operacion As TablaDetalleOperation
    <MessageBodyMember> Property TabladetalleList As List(Of TablaDetalle)
    <MessageBodyMember> Property TablaDetalle As TablaDetalle
End Class
