Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms

Imports Syncfusion.ComponentModel
Imports Syncfusion.Diagnostics
Imports Syncfusion.Drawing
Imports Syncfusion.Styles
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Presentation.WinForm.RecursoCostoEF
Imports Helios.General


Public Class RecordObjectBinder
    Public Sub New(model As GridDataBoundGridModel)
        WireGridModel(model)
    End Sub

    Private Sub WireGridModel(model As GridModel)
        'model.QueryCellInfo += New GridQueryCellInfoEventHandler(AddressOf GridModelQueryCellInfo)
        AddHandler model.QueryCellInfo, AddressOf GridModelQueryCellInfo
        AddHandler model.SaveCellInfo, AddressOf GridModelSaveCellInfo
        'model.SaveCellInfo += New GridSaveCellInfoEventHandler(AddressOf GridModelSaveCellInfo)
    End Sub

    Private Sub GridModelQueryCellInfo(sender As Object, e As GridQueryCellInfoEventArgs)
        Dim ms As IGridModelSource = TryCast(sender, IGridModelSource)
        Dim gridModel As GridDataBoundGridModel = TryCast(ms.Model, GridDataBoundGridModel)
        Dim gridBinder As GridModelDataBinder = TryCast(gridModel.DataProvider, GridModelDataBinder)

        Dim fieldNum As Integer = gridBinder.ColIndexToField(e.ColIndex)
        Dim position As Integer = gridBinder.RowIndexToPosition(e.RowIndex)
        If position < 0 OrElse fieldNum < 0 Then
            ' row or column header
            Return
        End If

        ' Get record state information as position, listManager, childCount etc.
        Dim state As GridBoundRecordState = gridBinder.GetRecordStateAtRowIndex(e.RowIndex)

        ' Get level information with bound columns, layout, row/col to field mapping
        Dim level As GridHierarchyLevel = gridBinder.GetHierarchyLevel(state.LevelIndex)

        ' Adjust for wrapped rows when a record has several rows
        Dim fieldInCollection As Integer = level.RowFieldToField(state.RowIndexInRecord, fieldNum)

        ' Get the columns collection for the hierarchy level
        Dim columns As GridBoundColumnsCollection = level.InternalColumns

        If fieldInCollection >= 0 AndAlso fieldInCollection < columns.Count Then
            ' Get the column style for this field
            Dim columnStyle As GridBoundColumn = columns(fieldInCollection)
            If columnStyle IsNot Nothing Then
                ' Check if this is an unbound column (where mapping name did not match any Property in associated class)
                Dim pd As PropertyDescriptor = columnStyle.PropertyDescriptor
                'If pd Is Nothing Then
                If state.Position < state.Table.Count Then
                    ' Get the record object from the table for this record
                    Dim rowObject As Object = state.Table(state.Position)

                    ' Check for the IRecordObject interface
                    Dim recordObject As IRecordObject2 = TryCast(rowObject, IRecordObject2)
                    If recordObject IsNot Nothing Then
                        ' Get style info from IRecordObject
                        Dim mappingName As String = columnStyle.MappingName
                        Dim cse As New QueryColumnStyleEventArgs(e, state, level, columnStyle, mappingName)
                        recordObject.QueryCellInfo(cse)

                        ' Assign e.Handled = true if information was provided by QueryCellInfo call
                        e.Handled = cse.Handled

                        TraceUtil.TraceCurrentMethodInfo(cse)
                    End If
                End If
                'End If
            End If
        End If
    End Sub

    Private Sub GridModelSaveCellInfo(sender As Object, e As GridSaveCellInfoEventArgs)
        ' similar code here for saving style info
    End Sub

End Class

Public NotInheritable Class QueryColumnStyleEventArgs
    Inherits SyncfusionHandledEventArgs
    Private m_gridInfo As GridQueryCellInfoEventArgs
    Private m_state As GridBoundRecordState
    Private m_level As GridHierarchyLevel
    Private m_columnStyle As GridBoundColumn
    Private m_mappingName As String

    Friend Sub New(gridInfo As GridQueryCellInfoEventArgs, state As GridBoundRecordState, level As GridHierarchyLevel, columnStyle As GridBoundColumn, mappingName As String)
        Me.m_gridInfo = gridInfo
        Me.m_state = state
        Me.m_level = level
        Me.m_columnStyle = columnStyle
        Me.m_mappingName = mappingName
    End Sub

    <TraceProperty(True)> _
    Public ReadOnly Property GridInfo() As GridQueryCellInfoEventArgs
        Get
            Return m_gridInfo
        End Get
    End Property

    <TraceProperty(True)> _
    Public ReadOnly Property State() As GridBoundRecordState
        Get
            Return m_state
        End Get
    End Property

    <TraceProperty(True)> _
    Public ReadOnly Property Level() As GridHierarchyLevel
        Get
            Return m_level
        End Get
    End Property

    <TraceProperty(True)> _
    Public ReadOnly Property ColumnStyle() As GridBoundColumn
        Get
            Return m_columnStyle
        End Get
    End Property

    <TraceProperty(True)> _
    Public ReadOnly Property MappingName() As String
        Get
            Return m_mappingName
        End Get
    End Property
End Class

Public Interface IRecordObject2
    ''' <summary>
    ''' Method handler for the <see cref="GridModel.QueryCellInfo"/> event.
    ''' </summary>
    ''' <param name=" e">An <see cref="GridQueryCellInfoEventArgs"/> that contains the event data.</param>
    Sub QueryCellInfo(e As QueryColumnStyleEventArgs)


End Interface
Public Class RecursoCostoEF
    Implements IRecordObject2

    '-------------------------------------------------------------

    Private _parent As CustomersList
    Private _children As New CustomersList()
    Private custData As CustomerData
    Private inTxn As Boolean = False


    Private Structure CustomerData
        Friend id As String
        Friend firstName As String
        Friend lastName As String
        Friend director As String
        Friend fecinicio As Date?
        Friend fecfinal As Date?
        Friend tipo As String
    End Structure


    Public Sub New(ID As String)
        MyBase.New()
        Me.custData = New CustomerData()
        Me.custData.id = ID
        Me.custData.firstName = ""
        Me.custData.lastName = ""
        Me.custData.director = ""
        Me.custData.fecinicio = DateTime.Now
        Me.custData.fecfinal = DateTime.Now
        Me.custData.tipo = ""
    End Sub

    Public Property ID() As String
        Get
            Return Me.custData.id
        End Get
        Set(value As String)
            Me.custData.id = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return Me.custData.firstName
        End Get
        Set(value As String)
            Me.custData.firstName = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return Me.custData.lastName
        End Get
        Set(value As String)
            Me.custData.lastName = value
        End Set
    End Property

    Public Property Director() As String
        Get
            Return Me.custData.director
        End Get
        Set(value As String)
            Me.custData.director = value
        End Set
    End Property

    Public Property Inicio() As Date?
        Get
            Return Me.custData.fecinicio
        End Get
        Set(value As Date?)
            Me.custData.fecinicio = value
        End Set
    End Property

    Public Property Finaliza() As Date?
        Get
            Return Me.custData.fecfinal
        End Get
        Set(value As Date?)
            Me.custData.fecfinal = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return Me.custData.tipo
        End Get
        Set(value As String)
            Me.custData.tipo = value
        End Set
    End Property

    Public Property Children() As CustomersList
        Get
            Return _children
        End Get
        Set(value As CustomersList)
            _children = value
        End Set
    End Property

    Friend Property Parent() As CustomersList
        Get
            Return _parent
        End Get
        Set(value As CustomersList)
            _parent = value
        End Set
    End Property

    Private Sub OnCustomerChanged()
        If Not inTxn AndAlso Parent IsNot Nothing Then
            Parent.CustomerChanged(Me)
        End If
    End Sub

    Public Sub QueryCellInfo(e As QueryColumnStyleEventArgs) Implements IRecordObject2.QueryCellInfo
        Dim ce As GridQueryCellInfoEventArgs = e.GridInfo
        If e.MappingName = "FirstName" Then
            'ce.Style.CellValue = String.Format("{0}: {1} {2}", Me.ID, FirstName, LastName)
            If e.Level.LevelIndex = 0 Then
                ce.Style.BackColor = Color.FromArgb(&HFF, &HBF, &H34)
            ElseIf e.Level.LevelIndex = 1 Then
                ce.Style.BackColor = Color.FromArgb(192, 201, 219)
                ce.Style.CellValue = String.Format("{0}: {1} ", "EDT", FirstName)
            ElseIf e.Level.LevelIndex = 2 Then
                ce.Style.BackColor = Color.Crimson
                ce.Style.TextColor = Color.White
            End If
        ElseIf e.MappingName = "Unbound2" Then
            ce.Style.CellValue = e.State.Position.ToString()
        End If
    End Sub
End Class

Public Class CustomersList
    Inherits CollectionBase

    Private resetEvent As New ListChangedEventArgs(ListChangedType.Reset, -1)

    Public Sub LoadCustomers()
        Dim l As IList = DirectCast(Me, IList)
        Dim cust1 As RecursoCostoEF = ReadCustomer1()
        cust1.Children.Add(ReadCustomer3())
        cust1.Children.Add(ReadCustomer4())
        l.Add(cust1)
        Dim cust2 As RecursoCostoEF = ReadCustomer2()
        cust2.Children.Add(ReadCustomer5())
        cust2.Children.Add(ReadCustomer6())
        l.Add(cust2)
        OnListChanged(resetEvent)

    End Sub


    Public Sub GetPlaneamiento(be As recursoCosto)
        Dim costoSA As New recursoCostoSA
        '    Dim rec As New RecursoCostoEF
        'For Each i In costoSA.GetTareasByProyecto(New recursoCosto With {.idCosto = be.idCosto})

        Dim l As IList = DirectCast(Me, IList)
        Dim rec As RecursoCostoEF = ReadProyecto(be)
        l.Add(rec)
        For Each i In costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = be.idCosto})
            rec.Children.Add(ReadProcesos(i))
        Next
        OnListChanged(resetEvent)

    End Sub


    Default Public Property Item(index As Integer) As RecursoCostoEF
        Get
            Return DirectCast(List(index), RecursoCostoEF)
        End Get
        Set(value As RecursoCostoEF)
            List(index) = value
        End Set
    End Property

    Public Function Add(value As RecursoCostoEF) As Integer
        Return List.Add(value)
    End Function

    Public Function AddNew() As RecursoCostoEF
        Return DirectCast(DirectCast(Me, IBindingList).AddNew(), RecursoCostoEF)
    End Function


    Public Sub Remove(value As RecursoCostoEF)
        List.Remove(value)
    End Sub


    Protected Overridable Sub OnListChanged(ev As ListChangedEventArgs)
        RaiseEvent ListChanged(Me, ev)
    End Sub


    Protected Overrides Sub OnClear()
        For Each c As RecursoCostoEF In List
            c.Parent = Nothing
        Next
    End Sub

    Protected Overrides Sub OnClearComplete()
        OnListChanged(resetEvent)
    End Sub

    Protected Overrides Sub OnInsertComplete(index As Integer, value As Object)
        Dim c As RecursoCostoEF = DirectCast(value, RecursoCostoEF)
        c.Parent = Me
        OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
    End Sub

    Protected Overrides Sub OnRemoveComplete(index As Integer, value As Object)
        Dim c As RecursoCostoEF = DirectCast(value, RecursoCostoEF)
        c.Parent = Me
        OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
    End Sub

    Protected Overrides Sub OnSetComplete(index As Integer, oldValue As Object, newValue As Object)
        If oldValue <> newValue Then

            Dim oldcust As RecursoCostoEF = DirectCast(oldValue, RecursoCostoEF)
            Dim newcust As RecursoCostoEF = DirectCast(newValue, RecursoCostoEF)

            oldcust.Parent = Nothing
            newcust.Parent = Me


            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
        End If
    End Sub

    ' Called by Customer when it changes.
    Friend Sub CustomerChanged(cust As RecursoCostoEF)

        Dim index As Integer = List.IndexOf(cust)

        OnListChanged(New ListChangedEventArgs(ListChangedType.ItemChanged, index))
    End Sub


    ' Events.
    Public Event ListChanged As ListChangedEventHandler


    ' Worker functions to populate the list with data.

    Private Shared Function ReadProyecto(be As recursoCosto) As RecursoCostoEF
        Dim cust As New RecursoCostoEF(be.idCosto)
        cust.FirstName = be.nombreCosto
        Select Case be.status
            Case StatusCosto.Avance_Obra_Cartera
                cust.LastName = "En cartera"
            Case StatusCosto.Culminado
                cust.LastName = "Culminado"
            Case StatusCosto.Proceso
                cust.LastName = "En Proceso"
            Case StatusCosto.Suspendido
                cust.LastName = "Suspendido"
        End Select

        cust.Director = be.director
        cust.Inicio = FormatDateTime(be.inicio, DateFormat.ShortDate)
        cust.Finaliza = FormatDateTime(be.finaliza, DateFormat.ShortDate)
        cust.Tipo = "PY"
        Return cust
    End Function

    Private Shared Function ReadProcesos(be As recursoCosto) As RecursoCostoEF
        Dim tareaSA As New recursoCostoSA
        Dim cust As New RecursoCostoEF(be.idCosto)
        cust.FirstName = be.nombreCosto
        cust.LastName = be.status
        cust.Director = String.Empty
        cust.Inicio = Nothing
        cust.Finaliza = Nothing
        cust.Tipo = "PRC"
        cust.Children = New CustomersList
        For Each i In tareaSA.GetTareasByProyecto(New recursoCosto With {.idCosto = be.idCosto})
            cust.Children.Add(ReadTareas(i))
        Next


        Return cust
    End Function

    Private Shared Function ReadProcesoEX() As RecursoCostoEF
        Dim cust As New RecursoCostoEF("44")
        cust.FirstName = "JIU"
        cust.LastName = "PP"
        cust.Director = String.Empty
        cust.Inicio = Nothing
        cust.Finaliza = Nothing
        Return cust
    End Function


    Private Shared Function ReadTareas(be As recursoCosto) As RecursoCostoEF
        Dim cust As New RecursoCostoEF(be.idCosto)
        cust.FirstName = be.nombreCosto
        Select Case be.status
            Case StatusCosto.Avance_Obra_Cartera
                cust.LastName = "En cartera"
            Case StatusCosto.Culminado
                cust.LastName = "Culminado"
            Case StatusCosto.Proceso
                cust.LastName = "En Proceso"
            Case StatusCosto.Suspendido
                cust.LastName = "Suspendido"
        End Select
        cust.Director = be.director
        cust.Inicio = FormatDateTime(be.inicio, DateFormat.ShortDate)
        cust.Finaliza = FormatDateTime(be.finaliza, DateFormat.ShortDate)
        cust.Tipo = "ACT"
        Return cust
    End Function

    Private Shared Function ReadCustomer1() As RecursoCostoEF
        Dim cust As New RecursoCostoEF("536-45-1245")
        cust.FirstName = "Jo"
        cust.LastName = "Brown"
        Return cust
    End Function

    Private Shared Function ReadCustomer2() As RecursoCostoEF
        Dim cust As New RecursoCostoEF("246-12-5645")
        cust.FirstName = "Robert"
        cust.LastName = "Brown"
        Return cust
    End Function

    Private Shared Function ReadCustomer3() As RecursoCostoEF
        Dim cust As New RecursoCostoEF("537-45-1245")
        cust.FirstName = "Keith"
        cust.LastName = "Brown"
        Return cust
    End Function

    Private Shared Function ReadCustomer4() As RecursoCostoEF
        Dim cust As New RecursoCostoEF("247-12-5645")
        cust.FirstName = "Sven"
        cust.LastName = "Brown"
        Return cust
    End Function

    Private Shared Function ReadCustomer5() As RecursoCostoEF
        Dim cust As New RecursoCostoEF("538-45-1245")
        cust.FirstName = "Katie"
        cust.LastName = "Brown"
        Return cust
    End Function

    Private Shared Function ReadCustomer6() As RecursoCostoEF
        Dim cust As New RecursoCostoEF("248-12-5645")
        cust.FirstName = "Steve"
        cust.LastName = "Brown"
        Return cust
    End Function


End Class
