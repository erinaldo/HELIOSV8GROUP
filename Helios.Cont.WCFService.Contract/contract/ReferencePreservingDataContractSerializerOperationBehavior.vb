Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Runtime.Serialization
Imports System.ServiceModel.Description

Public Class ReferencePreservingDataContractSerializerOperationBehavior
    Inherits DataContractSerializerOperationBehavior
#Region "Ctor"
    Public Sub New(operationDescription As OperationDescription)
        MyBase.New(operationDescription)
    End Sub
#End Region

#Region "Public Methods"

    Public Overrides Function CreateSerializer(type As Type, name As XmlDictionaryString, ns As XmlDictionaryString, knownTypes As IList(Of Type)) As XmlObjectSerializer
        'maxItemsInObjectGraph
        'ignoreExtensionDataObject
        'preserveObjectReferences
        'dataContractSurrogate
        Return New DataContractSerializer(type, name, ns, knownTypes, 2147483646, False, _
         True, Nothing)
    End Function
#End Region
End Class