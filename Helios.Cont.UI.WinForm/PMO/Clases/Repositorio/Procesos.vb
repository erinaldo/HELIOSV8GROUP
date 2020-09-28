Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class Procesos
    Inherits CollectionBase
    Implements IBindingList

    Private resetEvent As New ListChangedEventArgs(ListChangedType.Reset, -1)
    Private onListChanged1 As ListChangedEventHandler
    Property Parent As DocumentoBaseTG

    Public Sub AddIndex([property] As PropertyDescriptor) Implements IBindingList.AddIndex

    End Sub

    Public Function AddNew() As Object Implements IBindingList.AddNew

    End Function

    Public ReadOnly Property AllowEdit As Boolean Implements IBindingList.AllowEdit
        Get

        End Get
    End Property

    Public ReadOnly Property AllowNew As Boolean Implements IBindingList.AllowNew
        Get

        End Get
    End Property

    Public ReadOnly Property AllowRemove As Boolean Implements IBindingList.AllowRemove
        Get

        End Get
    End Property

    Public Sub ApplySort([property] As PropertyDescriptor, direction As ListSortDirection) Implements IBindingList.ApplySort

    End Sub

    Public Function Find([property] As PropertyDescriptor, key As Object) As Integer Implements IBindingList.Find

    End Function

    Public ReadOnly Property IsSorted As Boolean Implements IBindingList.IsSorted
        Get

        End Get
    End Property

    Public Event ListChanged(sender As Object, e As ListChangedEventArgs) Implements IBindingList.ListChanged

    Public Sub RemoveIndex([property] As PropertyDescriptor) Implements IBindingList.RemoveIndex

    End Sub

    Public Sub RemoveSort() Implements IBindingList.RemoveSort

    End Sub

    Public ReadOnly Property SortDirection As ListSortDirection Implements IBindingList.SortDirection
        Get

        End Get
    End Property

    Public ReadOnly Property SortProperty As PropertyDescriptor Implements IBindingList.SortProperty
        Get

        End Get
    End Property

    Public ReadOnly Property SupportsChangeNotification As Boolean Implements IBindingList.SupportsChangeNotification
        Get

        End Get
    End Property

    Public ReadOnly Property SupportsSearching As Boolean Implements IBindingList.SupportsSearching
        Get

        End Get
    End Property

    Public ReadOnly Property SupportsSorting As Boolean Implements IBindingList.SupportsSorting
        Get

        End Get
    End Property
End Class
