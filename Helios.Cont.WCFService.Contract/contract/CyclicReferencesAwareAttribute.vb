Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Runtime.Serialization
Imports System.ServiceModel.Description

<AttributeUsage(AttributeTargets.[Interface] Or AttributeTargets.Method)> _
Public Class CyclicReferencesAwareAttribute
    Inherits Attribute
    Implements IContractBehavior
    Implements IOperationBehavior


    Private ReadOnly _on As Boolean = True

    Public Sub New([on] As Boolean)
        _on = [on]
    End Sub

    Public ReadOnly Property [On]() As Boolean
        Get
            Return (_on)
        End Get
    End Property

#Region "IContractBehavior Members"

    Public Sub AddBindingParameters(contractDescription As System.ServiceModel.Description.ContractDescription, endpoint As System.ServiceModel.Description.ServiceEndpoint, bindingParameters As System.ServiceModel.Channels.BindingParameterCollection) Implements System.ServiceModel.Description.IContractBehavior.AddBindingParameters
    End Sub

    Public Sub ApplyClientBehavior(contractDescription As System.ServiceModel.Description.ContractDescription, endpoint As System.ServiceModel.Description.ServiceEndpoint, clientRuntime As System.ServiceModel.Dispatcher.ClientRuntime) Implements System.ServiceModel.Description.IContractBehavior.ApplyClientBehavior
        CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehaviors(contractDescription, [On])
    End Sub

    Public Sub ApplyDispatchBehavior(contractDescription As System.ServiceModel.Description.ContractDescription, endpoint As System.ServiceModel.Description.ServiceEndpoint, dispatchRuntime As System.ServiceModel.Dispatcher.DispatchRuntime) Implements System.ServiceModel.Description.IContractBehavior.ApplyDispatchBehavior
        CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehaviors(contractDescription, [On])
    End Sub

    Public Sub Validate(contractDescription As System.ServiceModel.Description.ContractDescription, endpoint As System.ServiceModel.Description.ServiceEndpoint) Implements System.ServiceModel.Description.IContractBehavior.Validate
    End Sub

#End Region

#Region "IOperationBehavior Members"
    Public Sub AddBindingParameters1(operationDescription As System.ServiceModel.Description.OperationDescription, bindingParameters As System.ServiceModel.Channels.BindingParameterCollection) Implements System.ServiceModel.Description.IOperationBehavior.AddBindingParameters
    End Sub

    Public Sub ApplyClientBehavior1(operationDescription As System.ServiceModel.Description.OperationDescription, clientOperation As System.ServiceModel.Dispatcher.ClientOperation) Implements System.ServiceModel.Description.IOperationBehavior.ApplyClientBehavior
        CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehavior(operationDescription, [On])
    End Sub

    Public Sub ApplyDispatchBehavior1(operationDescription As System.ServiceModel.Description.OperationDescription, dispatchOperation As System.ServiceModel.Dispatcher.DispatchOperation) Implements System.ServiceModel.Description.IOperationBehavior.ApplyDispatchBehavior
        CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehavior(operationDescription, [On])
    End Sub

    Public Sub Validate1(operationDescription As System.ServiceModel.Description.OperationDescription) Implements System.ServiceModel.Description.IOperationBehavior.Validate
    End Sub
#End Region


  
End Class