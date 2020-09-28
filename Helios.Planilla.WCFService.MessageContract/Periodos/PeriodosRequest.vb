Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PeriodosRequest
    Inherits ItemRequest
    <MessageBodyMember> Property Operacion As CargosOperation
    <MessageBodyMember> Property Periodos As Periodos
    <MessageBodyMember> Property PeriodosList As List(Of Periodos)
End Class
