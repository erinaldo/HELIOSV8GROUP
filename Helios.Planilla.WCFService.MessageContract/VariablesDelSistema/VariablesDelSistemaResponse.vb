Imports System.ServiceModel
Imports Helios.Planilla.Business.Entity

<MessageContract(IsWrapped:=True)>
Public Class VariablesDelSistemaResponse

    Inherits ItemResponse

    <MessageBodyMember()> Property VariablesDelSistema As VariablesDelSistema
    <MessageBodyMember()> Property VariablesDelSistemaList As List(Of VariablesDelSistema)

End Class
