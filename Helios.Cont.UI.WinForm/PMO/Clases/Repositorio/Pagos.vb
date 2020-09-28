Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class BaseCollection
    Inherits CollectionBase
    Implements IBindingList

    Private resetEvent As New ListChangedEventArgs(ListChangedType.Reset, -1)
    Private onListChanged1 As ListChangedEventHandler
    Property Parent As DocumentoBase
  

    Public Shared Function ListaPagosXproveedor(intIdProveedor As Integer) As BaseCollection
        Dim PagosSA As New saldoInicioSA
        Dim ListaPagos As New BaseCollection()
        Dim cust1 As New DocumentoBase
        For Each i In PagosSA.SaldosXpagarXproveedor(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, intIdProveedor)
            ListaPagos.Add(InsertAdd(i))
        Next
        Return ListaPagos
    End Function


    Public Shared Function ListaPagosXNotasXidDocumento(intIdCompra As Integer) As BaseCollection
        Dim documentocompraSA As New DocumentoCompraSA
        Dim movimientostr As String = Nothing
        Dim ListaPagos As New BaseCollection()
        For Each i In documentocompraSA.ListarNotasXidCompra(intIdCompra) ', TIPO_COMPRA.NOTA_CREDITO)
            ListaPagos.Add(InsertAddNotas(i))
        Next
        Return ListaPagos
    End Function

    


    Private Shared Function InsertAddNotas(saldoBE As documentocompra) As DocumentoBase
        Dim documentoCajaSA As New DocumentoCajaDetalleSA
        'Dim cust As New DocumentoBase(saldoBE.idDocumento)
        Dim cust As New DocumentoBase
        Select Case saldoBE.tipoDoc
            Case "08"
                cust = New DocumentoBase("NOTA DE DEBITO")
            Case "07"
                cust = New DocumentoBase("NOTA DE CREDITO")
        End Select

        cust.IdDocumento = saldoBE.idDocumento
        cust.Fecha = saldoBE.fechaDoc
        cust.TipoDoc = saldoBE.tipoDoc
        cust.NumeroDoc = saldoBE.numeroDoc
        cust.Moneda = "NAC"
        cust.TipoCambio = saldoBE.tcDolLoc
        cust.ImporteMN = saldoBE.importeTotal
        cust.ImporteME = saldoBE.importeUS
        Select Case saldoBE.estadoPago
            Case Nota_Credito.DINERO_ENTREGADO
                cust.EstadoPago = "Devoluvión procesada"
            Case Nota_Credito.DINERO_PENDIENTE_DE_ENTREGA
                cust.EstadoPago = "Pendiente de entrega"
            Case Nota_Credito.PROCESADO_SIN_MOVIMIENTOS
                cust.EstadoPago = "Proceso normal"
        End Select
        cust.Children = New BaseCollection
        For Each i In documentoCajaSA.GetUbicar_DetalleXdocumentoAfectado(saldoBE.idDocumento)
            cust.Children.Add(InsertAddChildren(i))
        Next
        Return cust
    End Function


    Private Shared Function InsertAdd(saldoBE As saldoInicio) As DocumentoBase
        Dim documentoCajaSA As New DocumentoCajaDetalleSA
        Dim cust As New DocumentoBase(saldoBE.idDocumento)
        cust.Fecha = saldoBE.fechaDoc
        cust.TipoDoc = saldoBE.tipoDoc
        cust.NumeroDoc = saldoBE.numeroDoc
        cust.TipoCambio = 3.0
        cust.ImporteMN = saldoBE.importeTotal
        cust.ImporteME = saldoBE.importeUS

        For Each i In documentoCajaSA.GetUbicar_DetalleXdocumentoAfectado(saldoBE.idDocumento)
            cust.Children = New BaseCollection
            cust.Children.Add(InsertAddChildren(i))
        Next
        Return cust
    End Function

    Private Shared Function InsertAddChildren(saldoBE As documentoCajaDetalle) As DocumentoBase
        Dim cust As New DocumentoBase("PAGO")
        cust.IdDocumento = saldoBE.idDocumento
        cust.Fecha = saldoBE.fechaDoc
        '      cust.Operacion = "PAGOS"
        cust.TipoDoc = saldoBE.tipoDocumento
        cust.NumeroDoc = saldoBE.numeroDoc
        cust.Moneda = "NAC"
        cust.TipoCambio = saldoBE.tipoCambioTransacc
        cust.ImporteMN = saldoBE.montoSoles
        cust.ImporteME = saldoBE.montoUsd
        Select Case saldoBE.entregado
            Case "SI"
                cust.EstadoPago = "Entregado"
            Case Else
                cust.EstadoPago = "Pendiente"
        End Select
        Return cust
    End Function


    Public Shared Function CreateCustomers() As BaseCollection
        Dim customers As New BaseCollection()
        Dim cust1 As New DocumentoBase
        cust1 = ReadCustomer1()
        cust1.Children = New BaseCollection
        cust1.Children.Add(ReadCustomer3())
        cust1.Children.Add(ReadCustomer4())
        customers.Add(cust1)
        Dim cust2 As DocumentoBase = ReadCustomer2()
        cust2.Children = New BaseCollection
        cust2.Children.Add(ReadCustomer5())
        cust2.Children.Add(ReadCustomer6())
        customers.Add(cust2)
        Return customers
    End Function

    Private Shared Function ReadCustomer1() As DocumentoBase
        Dim cust As New DocumentoBase(536)
        '  cust.Fecha = DateTime.Now.Date
        cust.TipoDoc = "VOU"
        cust.NumeroDoc = "001"
        cust.TipoDoc = 3.0
        cust.ImporteMN = 100
        cust.ImporteME = 30
        Return cust
    End Function

    Private Shared Function ReadCustomer2() As DocumentoBase
        Dim cust As New DocumentoBase(537)
        '   cust.Fecha = DateTime.Now
        cust.TipoDoc = "VOU"
        cust.NumeroDoc = "002"
        cust.TipoDoc = 3.0
        cust.ImporteMN = 1000
        cust.ImporteME = 100
        Return cust
    End Function

    Private Shared Function ReadCustomer3() As DocumentoBase
        Dim cust As New DocumentoBase(538)
        '    cust.Fecha = DateTime.Now
        cust.TipoDoc = "VOU"
        cust.NumeroDoc = "003"
        cust.TipoDoc = 3.0
        cust.ImporteMN = 100
        cust.ImporteME = 30
        Return cust
    End Function

    Private Shared Function ReadCustomer4() As DocumentoBase
        Dim cust As New DocumentoBase(539)
        '  cust.Fecha = DateTime.Now
        cust.TipoDoc = "VOU"
        cust.NumeroDoc = "004"
        cust.TipoDoc = 3.0
        cust.ImporteMN = 80
        cust.ImporteME = 10
        Return cust
    End Function

    Private Shared Function ReadCustomer5() As DocumentoBase
        Dim cust As New DocumentoBase(540)
        '  cust.Fecha = DateTime.Now
        cust.TipoDoc = "VOU"
        cust.NumeroDoc = "005"
        cust.TipoDoc = 3.0
        cust.ImporteMN = 400
        cust.ImporteME = 250
        Return cust
    End Function

    Private Shared Function ReadCustomer6() As DocumentoBase
        Dim cust As New DocumentoBase(541)
        '      cust.Fecha = DateTime.Now
        cust.TipoDoc = "VOU"
        cust.NumeroDoc = "006"
        cust.TipoDoc = 3.0
        cust.ImporteMN = 700
        cust.ImporteME = 300
        Return cust
    End Function


    Public Sub LoadData()
        Dim l As IList = CType(Me, IList)
        OnListChanged(resetEvent)
    End Sub

    Default Public Property Item(ByVal index As Integer) As DocumentoBase
        Get
            Return CType(List(index), DocumentoBase)
        End Get
        Set(ByVal Value As DocumentoBase)
            List(index) = Value
        End Set
    End Property

    Public Function Add(ByVal value As DocumentoBase) As Integer

        Return List.Add(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As DocumentoBase)
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

    Public Function AddNew2() As DocumentoBase
        Return CType(CType(Me, IBindingList).AddNew(), DocumentoBase)
    End Function

    Public Sub Remove(ByVal value As DocumentoBase)
        List.Remove(value)
    End Sub

    Protected Overridable Sub OnListChanged(ByVal ev As ListChangedEventArgs)
        If (onListChanged1 IsNot Nothing) Then
            onListChanged1(Me, ev)
        End If
    End Sub

    Protected Overrides Sub OnClear()
        Dim c As DocumentoBase
        For Each c In List
            c.Parent = Nothing
        Next c
    End Sub


    Protected Overrides Sub OnClearComplete()
        OnListChanged(resetEvent)
    End Sub


    Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
        Dim c As DocumentoBase = CType(value, DocumentoBase)
        c.Parent = Me
        OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
    End Sub


    Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
        Dim c As DocumentoBase = CType(value, DocumentoBase)
        c.Parent = Me
        OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
    End Sub


    Protected Overrides Sub OnSetComplete(ByVal index As Integer, ByVal oldValue As Object, ByVal newValue As Object)
        If oldValue <> newValue Then

            Dim oldcust As DocumentoBase = CType(oldValue, DocumentoBase)
            Dim newcust As DocumentoBase = CType(newValue, DocumentoBase)

            oldcust.Parent = Nothing
            newcust.Parent = Me

            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
        End If
    End Sub


    ' Called by Customer when it changes. 
    Friend Sub ActividadChanged(ByVal actividad As DocumentoBase)
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
        Dim c As New DocumentoBase()
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

    Function IndexOf(value As DocumentoBase)
        Return CType(Me, IList).IndexOf(value)
    End Function
End Class

<TypeConverter(GetType(ExpandableObjectConverter))>
Public Class DocumentoBase
    Implements IEditableObject

    Private custData As CustomerData
#Region "Campos"

    Private BeginEditCalled As Boolean = False

    <Browsable(False)>
    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)>
    Property Parent As BaseCollection

    Private _Children As BaseCollection

    <Browsable(True)>
    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)>
    Public Property Children() As BaseCollection
        Get
            Return _Children
        End Get
        Set(value As BaseCollection)
            If Not [Object].ReferenceEquals(Children, value) Then
                _Children = value
            End If
        End Set
    End Property

    'Property Children As BaseCollection
    '    Get
    '        Return _Children
    '    End Get
    '    Set(value As BaseCollection)

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
    Public Property Operacion As String
        Get
            Return Me.custData.operacion
        End Get
        Set(value As String)
            Me.custData.operacion = value
            Me.OnActividadChanged()
        End Set
    End Property

    <Browsable(True)>
    Public Property IdDocumento As Integer
        Get
            Return Me.custData.idDocumento
        End Get
        Set(value As Integer)
            Me.custData.idDocumento = value
            Me.OnActividadChanged()
        End Set
    End Property

    <Browsable(True)>
    Public Property Fecha As DateTime
        Get
            Return Me.custData.fecha
        End Get
        Set(value As DateTime)
            Me.custData.fecha = value
            Me.OnActividadChanged()
        End Set
    End Property

    '<Browsable(True)>
    'Public Property Action As Int32
    '    Get
    '        Return Me.Data.Action
    '    End Get
    '    Set(value As Int32)
    '        Me.Data.Action = value
    '        Me.OnActividadChanged()
    '    End Set
    'End Property


    <Browsable(True)>
        Public Property TipoDoc() As String
        Get
            Return Me.custData.tipoDocumento
        End Get
        Set(value As String)
            If TipoDoc <> value Then
                Me.custData.tipoDocumento = value
                Me.OnActividadChanged()
            End If
        End Set
    End Property

    <Browsable(True)>
    Public Property NumeroDoc As String
        Get
            Return Me.custData.numDoc
        End Get
        Set(value As String)
            If NumeroDoc <> value Then
                Me.custData.numDoc = value
                Me.OnActividadChanged()
            End If
        End Set
    End Property

    <Browsable(True)>
    Public Property Moneda As String
        Get
            Return Me.custData.moneda
        End Get
        Set(value As String)
            If Moneda <> value Then
                Me.custData.moneda = value
                Me.OnActividadChanged()
            End If
        End Set
    End Property

    <Browsable(True)>
    Public Property TipoCambio As Decimal?
        Get
            Return Me.custData.tipoCambio
        End Get
        Set(value As Decimal?)
            Me.custData.tipoCambio = value
            Me.OnActividadChanged()
        End Set
    End Property

    <Browsable(True)>
    Public Property ImporteMN As Decimal?
        Get
            Return Me.custData.importeMN
        End Get
        Set(value As Decimal?)
            Me.custData.importeMN = value
            Me.OnActividadChanged()
        End Set
    End Property

    <Browsable(True)>
    Public Property ImporteME As Decimal?
        Get
            Return Me.custData.importeME
        End Get
        Set(value As Decimal?)
            Me.custData.importeME = value
            Me.OnActividadChanged()
        End Set
    End Property


    <Browsable(True)>
    Public Property EstadoPago As String
        Get
            Return Me.custData.estadoPago
        End Get
        Set(value As String)
            Me.custData.estadoPago = value
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

    Public Sub New(Operacion As String)
        Me.custData = New CustomerData()
        Me.custData.operacion = Operacion
        Me.custData.idDocumento = 0
        Me.custData.fecha = Nothing
        Me.custData.tipoDocumento = String.Empty
        Me.custData.numDoc = String.Empty
        Me.custData.moneda = String.Empty
        Me.custData.tipoCambio = 0
        Me.custData.importeMN = 0
        Me.custData.importeME = 0
        Me.custData.estadoPago = String.Empty
    End Sub

    Structure CustomerData
        Friend operacion As String
        Friend idDocumento As Integer
        Friend fecha As DateTime
        Friend tipoDocumento As String
        Friend numDoc As String
        Friend moneda As String
        Friend tipoCambio As Decimal
        Friend importeMN As Decimal
        Friend importeME As Decimal
        Friend estadoPago As String
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
