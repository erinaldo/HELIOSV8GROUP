Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class PersonalConceptosResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property PersonalConceptos As PersonalConceptos
    <MessageBodyMember()> Property PersonalConceptosList As List(Of PersonalConceptos)

End Class
