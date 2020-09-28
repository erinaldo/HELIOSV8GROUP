Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PlantillaRequest
    Inherits ItemRequest
    <MessageBodyMember> Property Operacion As PlantillaOperation
    <MessageBodyMember> Property ListaPlantilla As List(Of Plantilla)
    <MessageBodyMember> Property Plantilla As Plantilla

End Class




