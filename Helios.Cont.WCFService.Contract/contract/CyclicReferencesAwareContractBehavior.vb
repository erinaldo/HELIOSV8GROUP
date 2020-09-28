Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Runtime.Serialization
Imports System.ServiceModel.Description
Imports System.Data.Objects


Public Class CyclicReferencesAwareContractBehavior
    Implements IContractBehavior


    Private Const maxItemsInObjectGraph As Int32 = &HFFFF
    Private Const ignoreExtensionDataObject As Boolean = False

    Private _on As Boolean

    Public Sub New([on] As Boolean)
        _on = [on]
    End Sub


#Region "IContractBehavior Members"

    Public Sub AddBindingParameters1(contractDescription As System.ServiceModel.Description.ContractDescription, endpoint As System.ServiceModel.Description.ServiceEndpoint, bindingParameters As System.ServiceModel.Channels.BindingParameterCollection) Implements System.ServiceModel.Description.IContractBehavior.AddBindingParameters

    End Sub

    Public Sub ApplyClientBehavior(contractDescription As System.ServiceModel.Description.ContractDescription, endpoint As System.ServiceModel.Description.ServiceEndpoint, clientRuntime As System.ServiceModel.Dispatcher.ClientRuntime) Implements System.ServiceModel.Description.IContractBehavior.ApplyClientBehavior
        ReplaceDataContractSerializerOperationBehaviors(contractDescription, _on)
    End Sub

    Public Sub ApplyDispatchBehavior(contractDescription As System.ServiceModel.Description.ContractDescription, endpoint As System.ServiceModel.Description.ServiceEndpoint, dispatchRuntime As System.ServiceModel.Dispatcher.DispatchRuntime) Implements System.ServiceModel.Description.IContractBehavior.ApplyDispatchBehavior
        ReplaceDataContractSerializerOperationBehaviors(contractDescription, _on)
    End Sub

    Friend Shared Sub ReplaceDataContractSerializerOperationBehaviors(contractDescription As ContractDescription, [on] As Boolean)
        For Each operation In contractDescription.Operations
            ReplaceDataContractSerializerOperationBehavior(operation, [on])
        Next
    End Sub

    Friend Shared Sub ReplaceDataContractSerializerOperationBehavior(operation As OperationDescription, [on] As Boolean)
        If operation.Behaviors.Remove(GetType(DataContractSerializerOperationBehavior)) OrElse operation.Behaviors.Remove(GetType(ApplyCyclicDataContractSerializerOperationBehavior)) Then
            operation.Behaviors.Add(New ApplyCyclicDataContractSerializerOperationBehavior(operation, maxItemsInObjectGraph, ignoreExtensionDataObject, [on]))
        End If
    End Sub

    Public Sub Validate(contractDescription As System.ServiceModel.Description.ContractDescription, endpoint As System.ServiceModel.Description.ServiceEndpoint) Implements System.ServiceModel.Description.IContractBehavior.Validate

    End Sub


    'Public Sub Validate(contractDescription As ContractDescription, endpoint As ServiceEndpoint)
    'End Sub

#End Region

   
End Class