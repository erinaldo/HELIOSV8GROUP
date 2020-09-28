Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PlantillaDetalleRequest
    Inherits ItemRequest
    <MessageBodyMember> Property Operacion As PlantillaDetalleOperation
    <MessageBodyMember> Property PlantillaDetalleList As List(Of PlantillaDetalle)
    <MessageBodyMember> Property PlantillaDetalle As PlantillaDetalle

End Class
