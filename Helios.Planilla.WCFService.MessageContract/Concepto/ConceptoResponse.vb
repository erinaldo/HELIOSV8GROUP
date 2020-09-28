Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class ConceptoResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property Concepto As Concepto
    <MessageBodyMember()> Property ConceptoList As List(Of Concepto)

End Class
