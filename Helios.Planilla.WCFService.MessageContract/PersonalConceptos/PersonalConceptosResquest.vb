Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PersonalConceptosRequest
    Inherits ItemRequest

    <MessageBodyMember> Property Operacion As PersonalConceptosOperation
    <MessageBodyMember> Property PersonalConceptos As PersonalConceptos
    <MessageBodyMember> Property PersonalConceptosList As List(Of PersonalConceptos)

End Class
