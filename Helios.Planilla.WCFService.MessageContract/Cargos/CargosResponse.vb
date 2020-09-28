Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class CargosResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property Cargos As Cargos
    <MessageBodyMember()> Property CargosList As List(Of Cargos)

End Class