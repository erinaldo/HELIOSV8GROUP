Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PlantillaDetalleResponse
    Inherits ItemResponse

    <MessageBodyMember()> Property PlantillaDetalleList As List(Of PlantillaDetalle)
    <MessageBodyMember()> Property PlantillaDetalle As PlantillaDetalle

End Class