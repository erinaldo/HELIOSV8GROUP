Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class BaseCollectionTG
    Inherits CollectionBase
    Implements IBindingList

    Private resetEvent As New ListChangedEventArgs(ListChangedType.Reset, -1)
    Private onListChanged1 As ListChangedEventHandler
    Property Parent As DocumentoBaseTG


    Public Shared Function ListaTablasGenerales() As BaseCollectionTG
        Dim tablaSA As New tablasa
        Dim ListaTablas As New BaseCollectionTG
        Dim cust1 As New DocumentoBaseTG
        For Each i In tablaSA.GetListaTabla()
            ListaTablas.Add(InsertAdd(i))
        Next
        Return ListaTablas
    End Function


    Private Shared Function InsertAdd(saldoBE As tabla) As DocumentoBaseTG
        Dim tablaDetalleSA As New tablaDetalleSA

        Dim cust As New DocumentoBaseTG(saldoBE.idtabla)
        cust.Descripcion = saldoBE.descripcion
        cust.Estado = saldoBE.estado

        cust.Children = New BaseCollectionTG
        For Each i In tablaDetalleSA.GetListaTablaDetalle(saldoBE.idtabla, "1")
            cust.Children.Add(InsertAddChildren(i))
        Next
        Return cust
    End Function

    Private Shared Function InsertAddChildren(saldoBE As tabladetalle) As DocumentoBaseTG
        Dim cust As New DocumentoBaseTG(saldoBE.codigoDetalle)
        cust.Descripcion = saldoBE.descripcion
        cust.Estado = saldoBE.estadodetalle
        Return cust
    End Function


    Public Sub LoadData()
        Dim l As IList = CType(Me, IList)
        OnListChanged(resetEvent)
    End Sub

    Default Public Property Item(ByVal index As Integer) As DocumentoBaseTG
        Get
            Return CType(List(index), DocumentoBaseTG)
        End Get
        Set(ByVal Value As DocumentoBaseTG)
            List(index) = Value
        End Set
    End Property

    Public Function Add(ByVal value As DocumentoBaseTG) As Integer

        Return List.Add(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As DocumentoBaseTG)
        List.Insert(index, value)
    End Sub

    'Public Sub MoveUPDown(ByVal index As Integer, ByVal value As UIActividad)
    '    List.Remove(value)
    '    List.Insert(index, value)
    '    value.Action = BaseBE.EntityAction.UPDATE
    'End Sub

    Public Sub Sort()
        'Dim aux As New UIActividad
        'For i = 0 To List.Count - 1
        '    If CType(List(i), UIActividad).Secuencia > CType(List(i + 1), UIActividad).Secuencia Then
        '        aux = CType(List(i), UIActividad)
        '        List.Item(i) = List.Item
        '        List.Item(i + 1) = aux
        '        ' List.Insert(i, CType(List(i + 1), UIActividad))
        '    End If
        'Next
    End Sub

    Public Sub EliminarRepetidos()

    End Sub

    Public Function AddNew2() As DocumentoBaseTG
        Return CType(CType(Me, IBindingList).AddNew(), DocumentoBaseTG)
    End Function

    Public Sub Remove(ByVal value As DocumentoBaseTG)
        List.Remove(value)
    End Sub

    Protected Overridable Sub OnListChanged(ByVal ev As ListChangedEventArgs)
        If (onListChanged1 IsNot Nothing) Then
            onListChanged1(Me, ev)
        End If
    End Sub

    Protected Overrides Sub OnClear()
        Dim c As DocumentoBaseTG
        For Each c In List
            c.Parent = Nothing
        Next c
    End Sub


    Protected Overrides Sub OnClearComplete()
        OnListChanged(resetEvent)
    End Sub


    Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
        Dim c As DocumentoBaseTG = CType(value, DocumentoBaseTG)
        c.Parent = Me
        OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
    End Sub


    Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
        Dim c As DocumentoBaseTG = CType(value, DocumentoBaseTG)
        c.Parent = Me
        OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
    End Sub


    Protected Overrides Sub OnSetComplete(ByVal index As Integer, ByVal oldValue As Object, ByVal newValue As Object)
        If oldValue <> newValue Then

            Dim oldcust As DocumentoBaseTG = CType(oldValue, DocumentoBaseTG)
            Dim newcust As DocumentoBaseTG = CType(newValue, DocumentoBaseTG)

            oldcust.Parent = Nothing
            newcust.Parent = Me

            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
        End If
    End Sub


    ' Called by Customer when it changes. 
    Friend Sub ActividadChanged(ByVal actividad As DocumentoBaseTG)
        Dim index As Integer = List.IndexOf(actividad)
        OnListChanged(New ListChangedEventArgs(ListChangedType.ItemChanged, index))
    End Sub


    ' Implements IBindingList. 

    ReadOnly Property AllowEdit() As Boolean Implements IBindingList.AllowEdit
        Get
            Return True
        End Get
    End Property

    ReadOnly Property AllowNew() As Boolean Implements IBindingList.AllowNew
        Get
            Return True
        End Get
    End Property

    ReadOnly Property AllowRemove() As Boolean Implements IBindingList.AllowRemove
        Get
            Return True
        End Get
    End Property

    ReadOnly Property SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
        Get
            Return True
        End Get
    End Property

    ReadOnly Property SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
        Get
            Return False
        End Get
    End Property

    ReadOnly Property SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
        Get
            Return False
        End Get
    End Property

    ' Events. 
    Public Event ListChanged As ListChangedEventHandler Implements IBindingList.ListChanged

    ' Methods. 
    Function AddNew() As Object Implements IBindingList.AddNew
        Dim c As New DocumentoBaseTG()
        List.Add(c)
        Return c
    End Function


    ' Unsupported properties. 

    ReadOnly Property IsSorted() As Boolean Implements IBindingList.IsSorted
        Get
            Throw New NotSupportedException()
        End Get
    End Property

    ReadOnly Property SortDirection() As ListSortDirection Implements IBindingList.SortDirection
        Get
            Throw New NotSupportedException()
        End Get
    End Property


    ReadOnly Property SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
        Get
            Throw New NotSupportedException()
        End Get
    End Property


    ' Unsupported Methods. 
    Sub AddIndex(ByVal prop As PropertyDescriptor) Implements IBindingList.AddIndex
        Throw New NotSupportedException()
    End Sub


    Sub ApplySort(ByVal prop As PropertyDescriptor, ByVal direction As ListSortDirection) Implements IBindingList.ApplySort
        Throw New NotSupportedException()
    End Sub


    Function Find(ByVal prop As PropertyDescriptor, ByVal key As Object) As Integer Implements IBindingList.Find
        Throw New NotSupportedException()
    End Function


    Sub RemoveIndex(ByVal prop As PropertyDescriptor) Implements IBindingList.RemoveIndex
        Throw New NotSupportedException()
    End Sub


    Sub RemoveSort() Implements IBindingList.RemoveSort
        Throw New NotSupportedException()
    End Sub

    Function IndexOf(value As DocumentoBaseTG)
        Return CType(Me, IList).IndexOf(value)
    End Function
End Class

<TypeConverter(GetType(ExpandableObjectConverter))>
Public Class DocumentoBaseTG
    Implements IEditableObject

    Private custData As CustomerData
#Region "Campos"

    Private BeginEditCalled As Boolean = False

    <Browsable(False)>
    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)>
    Property Parent As BaseCollectionTG

    Private _Children As BaseCollectionTG

    <Browsable(True)>
    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)>
    Public Property Children() As BaseCollectionTG
        Get
            Return _Children
        End Get
        Set(value As BaseCollectionTG)
            If Not [Object].ReferenceEquals(Children, value) Then
                _Children = value
            End If
        End Set
    End Property

    'Property Children As BaseCollectionTG
    '    Get
    '        Return _Children
    '    End Get
    '    Set(value As BaseCollectionTG)

    '        _Children = value
    '        _Children.Parent = Me
    '    End Set
    'End Property

    <Browsable(False)>
    Property Data As documentoCaja
    <Browsable(False)>
    Property BackupData As documentoCaja
    'Property inTxn As Boolean = False
    <Browsable(False)>
    Property Modified As Boolean = False
    <Browsable(False)>
    Property ForwardEditableObject As IEditableObject


    <Browsable(False)>
    ReadOnly Property IsBeginEditCalled As Boolean
        Get
            Return Me.BeginEditCalled
        End Get
    End Property
    <Browsable(False)>
    ReadOnly Property ShouldSerializeParent As Boolean
        Get
            Return False
        End Get
    End Property
    <Browsable(False)>
    ReadOnly Property ShouldSerializeChildren As Boolean
        Get
            Return Children IsNot Nothing AndAlso Children.Count > 0
        End Get
    End Property

    <Browsable(True)>
    Public Property IdTablaCodigo As String
        Get
            Return Me.custData.idTablaCodigo
        End Get
        Set(value As String)
            Me.custData.idTablaCodigo = value
            Me.OnActividadChanged()
        End Set
    End Property

    <Browsable(True)>
    Public Property Descripcion As String
        Get
            Return Me.custData.descripcion
        End Get
        Set(value As String)
            Me.custData.descripcion = value
            Me.OnActividadChanged()
        End Set
    End Property

    <Browsable(True)>
    Public Property Estado As String
        Get
            Return Me.custData.estado
        End Get
        Set(value As String)
            Me.custData.estado = value
            Me.OnActividadChanged()
        End Set
    End Property


#End Region

    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not BeginEditCalled Then
            Me.BackupData = Data
            BeginEditCalled = True
            If ForwardEditableObject IsNot Nothing Then
                ForwardEditableObject.BeginEdit()
            End If
            Modified = False
        End If
    End Sub

    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If BeginEditCalled Then
            Me.Data = BackupData
            BeginEditCalled = False
            If ForwardEditableObject IsNot Nothing Then
                ForwardEditableObject.CancelEdit()
            End If
            Modified = False
        End If
    End Sub

    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If BeginEditCalled Then
            BackupData = New documentoCaja()
            BeginEditCalled = False
            If Me.ForwardEditableObject IsNot Nothing Then
                Me.ForwardEditableObject.EndEdit()
            End If
            If Parent IsNot Nothing AndAlso Modified Then
                Parent.ActividadChanged(Parent.IndexOf(Me))
            End If
            Modified = False
        End If
    End Sub

    Public Sub New()
        'Me.Data = New Actividad
        'Me.Data.IDActividad = -1
        '' Me.Data.IDActividadPadre = -1
        'Me.Data.IDTipo = 1
        'Me.Data.DescripcionCorta = String.Empty
        'Me.Data.DescripcionLarga = String.Empty
        'Me.Data.FechaInicio = Date.Now
        'Me.Data.FechaFin = Date.Now
        'Me.Data.IDProyecto = 0
        'Me.Data.Duracion = 0
        'Me.Data.Secuencia = 0
        'Me.Data.Nivel = 2
        'Me.Data.Action = 1
        'Me.Data.Cantidad = 0
        'Me.Data.IDUnidadCantidad = ""
        'Me.Data.RendimientoEq = 0
        'Me.Data.RendimientoMo = 0


    End Sub

    Public Sub New(idTablaCodigo As String)
        Me.custData = New CustomerData()
        Me.custData.idTablaCodigo = idTablaCodigo
        Me.custData.descripcion = String.Empty
        Me.custData.estado = String.Empty
    End Sub

    Structure CustomerData
        Friend idTablaCodigo As String
        Friend descripcion As String
        Friend estado As String
    End Structure


    Public Sub New(item As documentoCaja)
        Me.Data = item
    End Sub

    Private Sub OnActividadChanged()
        If Not BeginEditCalled And (Parent IsNot Nothing) Then
            Parent.ActividadChanged(Me)
        End If
    End Sub
End Class

