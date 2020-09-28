Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Runtime.Serialization
Imports System.ServiceModel.Description
Friend Class ApplyCyclicDataContractSerializerOperationBehavior
    Inherits DataContractSerializerOperationBehavior
    Private ReadOnly _maxItemsInObjectGraph As Int32
    Private ReadOnly _ignoreExtensionDataObject As Boolean
    Private ReadOnly _preserveObjectReferences As Boolean

    Public Sub New(operationDescription As OperationDescription, maxItemsInObjectGraph As Int32, ignoreExtensionDataObject As Boolean, preserveObjectReferences As Boolean)
        MyBase.New(operationDescription)
        _maxItemsInObjectGraph = maxItemsInObjectGraph
        _ignoreExtensionDataObject = ignoreExtensionDataObject
        _preserveObjectReferences = preserveObjectReferences
    End Sub

    Public Overrides Function CreateSerializer(type As Type, name As [String], ns As [String], knownTypes As IList(Of Type)) As XmlObjectSerializer
        'dataContractSurrogate
        Return (New DataContractSerializer(type, name, ns, knownTypes, _maxItemsInObjectGraph, _ignoreExtensionDataObject, _
         _preserveObjectReferences, Nothing))
    End Function

    Public Overrides Function CreateSerializer(type As Type, name As XmlDictionaryString, ns As XmlDictionaryString, knownTypes As IList(Of Type)) As XmlObjectSerializer
        'dataContractSurrogate
        Return (New DataContractSerializer(type, name, ns, knownTypes, _maxItemsInObjectGraph, _ignoreExtensionDataObject, _
         _preserveObjectReferences, Nothing))
    End Function

End Class