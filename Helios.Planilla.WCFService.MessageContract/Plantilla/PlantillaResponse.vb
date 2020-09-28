Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PlantillaResponse
    Inherits ItemResponse

    <MessageBodyMember()> Property ListaPlantilla As List(Of Plantilla)
    <MessageBodyMember()> Property Plantilla As Plantilla

End Class