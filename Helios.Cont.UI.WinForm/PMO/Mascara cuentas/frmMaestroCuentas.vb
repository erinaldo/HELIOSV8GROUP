Imports Syncfusion.Windows.Forms
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports TreeGridHelper
Public Class frmMaestroCuentas
    Inherits frmMaster

#Region "Métodos"
    Private Sub LlenargrdProyectos()
        Dim acceso As New cuentaMascaraSA()
        Dim listaCuentas As New List(Of cuentaMascara)
        Dim listaTablaDetalleUnidades As New List(Of tabladetalle)
        Me.dgvCuentas.ShowTreeLines = True
        listaCuentas = acceso.UbicarEmpresaXmodulo(Gempresas.IdEmpresaRuc, "COMPRA")
        Me.dgvCuentas.BeginUpdate()
        Me.dgvCuentas.Binder.SetDataBinding(listaCuentas, "")
        Dim childrenLevel As GridHierarchyLevel = Me.dgvCuentas.Binder.AddRelation("Children")
        'Se regula la cantidad de nieveles a mostrar, por defecto es 1
        For index = 1 To 5
            Me.dgvCuentas.Binder.AddRelation("Children")
        Next

        'childrenLevel.ShowHeaders = False
        Me.dgvCuentas.Binder.RootHierarchyLevel.ShowHeaders = True
        Me.dgvCuentas.ExpandAll()
        Me.dgvCuentas.EndUpdate()



        '    Dim dt = listaCuentas.ToDataTable("Proyectos")
        'Dim cboCellUnidad As GridStyleInfo = Me.dgvCuentas.Model.ColStyles("IDUnidadCantidad")
        'cboCellUnidad.DataSource = listaTablaDetalleUnidades
        'cboCellUnidad.DisplayMember = "DescripcionCorta"
        'cboCellUnidad.ValueMember = "IDTablaDetalle"
        'cboCellUnidad.DropDownStyle = GridDropDownStyle.Exclusive
        'cboCellUnidad.CellType = "ComboBox"


        'Me.grdActividades.BeginUpdate()
        'Me.grdActividades.Binder.SetDataBinding(ListaActividades, "")
        'Dim childrenLevel As GridHierarchyLevel = Me.grdActividades.Binder.AddRelation("Children")
        ''Se regula la cantidad de nieveles a mostrar, por defecto es 1
        'For index = 1 To cantNiveles
        '    Me.grdActividades.Binder.AddRelation("Children")
        'Next

        'childrenLevel.ShowHeaders = False
        'Me.grdActividades.Binder.RootHierarchyLevel.ShowHeaders = True
        'Me.grdActividades.ExpandAll()
        'Me.grdActividades.EndUpdate()

        'dgvCuentas.Binder.InternalColumns("id").Hidden = True
        'dgvCuentas.Binder.InternalColumns("UsuarioModificacion").Hidden = True
        'dgvCuentas.Binder.InternalColumns("FechaModificacion").Hidden = True
        'dgvCuentas.Binder.InternalColumns("Action").Hidden = True
        'dgvCuentas.Binder.InternalColumns("CustomID").Hidden = True

        'Dim cboDescCorta As GridStyleInfo = Me.dgvCuentas.Model.ColStyles("DescripcionCorta")
        'cboDescCorta.CellType = GridCellTypeName.OriginalTextBox
        'cboDescCorta.CharacterCasing = CharacterCasing.Upper

        'dgvCuentas.Binder.InternalColumns("IDProyecto").Hidden = True
        'dgvCuentas.Binder.InternalColumns("IDProyectoPadre").Hidden = True
        'dgvCuentas.Binder.InternalColumns("IDEmpresa").Hidden = True
        'dgvCuentas.Binder.InternalColumns("IDContratista").Hidden = True
        'dgvCuentas.Binder.InternalColumns("DescripcionLarga").Hidden = True
        'dgvCuentas.Binder.InternalColumns("VersionOficial").Hidden = True
        'dgvCuentas.Binder.InternalColumns("Actividad").Hidden = True
        'dgvCuentas.Binder.InternalColumns("ProyectoAtributoValor").Hidden = True
        'dgvCuentas.Binder.InternalColumns("ProyectoVersionamiento").Hidden = True
        'dgvCuentas.Binder.InternalColumns("NivelAnalisis").Hidden = True
        'dgvCuentas.Binder.InternalColumns("ProyectoConcepto").Hidden = True
        'dgvCuentas.Binder.InternalColumns("SimboloMoneda").Hidden = True


        'dgvCuentas.Binder.InternalColumns("IDProyecto").HeaderText = "ID"
        'dgvCuentas.Binder.InternalColumns("DescripcionCorta").HeaderText = "Descripción"
        'dgvCuentas.Binder.InternalColumns("IDClaseProyecto").HeaderText = "Clase de Proyecto"
        'dgvCuentas.Binder.InternalColumns("TipoMoneda").HeaderText = "Moneda"
        'dgvCuentas.Binder.InternalColumns("FechaInicio").HeaderText = "Fecha de Inicio"
        'dgvCuentas.Binder.InternalColumns("FechaFin").HeaderText = "Fecha de Fin"

        dgvCuentas.Refresh()
    End Sub
    Dim treeGrid As TreeGridHelper.TreeGridHelper
    Dim accessor As SelfReferenceDataSourceAccessor
    Private Sub llenarProductos()
        Dim productoSA As New detalleitemsSA
        Dim dt As New DataTable()
        dt.Columns.Add("codigodetalle", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("descripcionItem", GetType(String))
        dt.Columns.Add("idItem", GetType(Integer))

        dt.Rows.Add("A01", "1", "JABON", -1)
        dt.Rows.Add("B01", "2", "JABON NOVEA", 1)
        dt.Rows.Add("C01", "2", "JABON DE MIEL", 1)

        dt.Rows.Add("A01", "3", "JABON", 1)
        dt.Rows.Add("B01", "4", "JABON NOVEA", 3)
        dt.Rows.Add("C01", "5", "JABON DE MIEL", 3)
        'For Each i In productoSA.ListaProductosClasificados(GEstableciento.IdEstablecimiento, "14198")
        '    Dim dr As DataRow = dt.NewRow()
        '    dr(0) = i.codigodetalle
        '    dr(1) = i.cuenta
        '    dr(2) = i.descripcionItem
        '    dr(3) = i.idItem
        '    dt.Rows.Add(dr)
        'Next

        Me.dgvItems.DataSource = dt
        Me.dgvItems.TableModel.Options.ActivateCurrentCellBehavior = GridCellActivateAction.None
        Me.dgvItems.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        Me.dgvItems.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        Me.dgvItems.TableOptions.ShowRowHeader = False

        Me.treeGrid = New TreeGridHelper.TreeGridHelper()


        Me.treeGrid.ColorCodeSiblings = False
        'dont show colors
        Me.accessor = Me.treeGrid.WireSelfReferenceGrid(Me.dgvItems, dt, "idItem", "cuenta", "codigodetalle")

        'allow editing type properties
        treeGrid.EditingEnabled = True
        Me.dgvItems.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.None
        Me.dgvItems.TableModel.Options.ActivateCurrentCellBehavior = GridCellActivateAction.ClickOnCell
        treeGrid.CollapseAll()
        '       treeGrid.ExpandAll()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region


#Region "Metodos Auxiliares Grid"

    ''' <summary>
    ''' Permite obtener el valor de un columna especifica de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    '''  <param name="RowIndex"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function GetCellValue(Grid As GridDataBoundGrid, ColumnId As String, RowIndex As Integer) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).FormattedText
        Return CellText
    End Function



    ''' <summary>
    ''' Permite obtener el valor de un columna especifica de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function GetCellValue(Grid As GridDataBoundGrid, ColumnId As String) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).FormattedText
        Return CellText
    End Function

    Private Function GetCellMemberValue(Grid As GridDataBoundGrid, ColumnId As String) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).CellValue
        Return CellText
    End Function

    Private Sub SetCellMemberValue(Grid As GridDataBoundGrid, ColumnId As String, value As String)
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Grid.Item(RowIndex, ColIndex).Text = value
        Grid.Item(RowIndex, ColIndex).CellValue = value


    End Sub

    ''' <summary>
    ''' Permite obtener el index de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Private Function GetSelectedRow(Grid As GridDataBoundGrid) As Integer
        Dim SelectedRow = Grid.Selections.GetSelectedRows(True, False)
        Return Grid.Binder.CurrentRowIndex()
    End Function

    ''' <summary>
    ''' Permite obtener el index de la columna pasada por parametros
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Private Function GetColIndexById(Grid As GridDataBoundGrid, ColumnId As String) As Integer
        Dim ColIndex As Integer
        ColIndex = Grid.NameToColIndex(ColumnId)

        Return ColIndex
    End Function
#End Region


    Private Sub frmMaestroCuentas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LlenargrdProyectos()
        llenarProductos()
        AddHandler Me.dgvCuentas.Model.QueryCellInfo, AddressOf Model_QueryCellInfo
    End Sub

    Private Sub dgvCuentas_CellClick(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs) Handles dgvCuentas.CellClick

    End Sub

    Private Sub Model_QueryCellInfo(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridQueryCellInfoEventArgs)
        'Apply Readonly to cell(3,3)
        If e.ColIndex = 4 Then
            e.Style.BackColor = Color.Yellow
            e.Style.ReadOnly = True
        End If

        'Private Sub Model_QueryCellInfo(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridQueryCellInfoEventArgs)
        '    'Apply Readonly to cell(3,3)
        '    If e.RowIndex = 3 AndAlso e.ColIndex = 3 Then
        '        e.Style.BackColor = Color.Yellow
        '        e.Style.ReadOnly = True
        '    End If

        '    ' Apply ReadOnly to Row 4
        '    If e.RowIndex = 4 Then
        '        e.Style.BackColor = Color.Blue
        '        e.Style.ReadOnly = True
        '    End If

        '    ' Apply ReadOnly to Column 4
        '    If e.ColIndex = 4 Then
        '        e.Style.BackColor = Color.Aqua
        '        e.Style.ReadOnly = True
        '    End If

        '    '     // Apply ReadOnly to Range of cells
        '    If (e.RowIndex = 1 OrElse e.RowIndex = 2) AndAlso (e.ColIndex = 1 OrElse e.ColIndex = 2) Then
        '        e.Style.BackColor = Color.Red
        '        e.Style.ReadOnly = True
        '    End If

    End Sub

End Class