Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class CargosRequest
    Inherits ItemRequest
    <MessageBodyMember> Property Operacion As CargosOperation
    <MessageBodyMember> Property Cargos As Cargos
    <MessageBodyMember> Property CargosList As List(Of Cargos)
End Class
