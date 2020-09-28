Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmTablasGenerales
    Inherits frmMaster
    Public lblAlerta As New Label
    Public lblSinAsignar As New Label
    Public lblCantServ As New Label


    Public Sub New()



        Me.WindowState = FormWindowState.Maximized
        ' This call is required by the designer.
        InitializeComponent()
        lblAlerta = New Label
        lblSinAsignar = New Label
        lsvTipoCambio.Visible = True
        'cboMercaderia.SelectedIndex = -1
        ' Add any initialization after the InitializeComponent() call.
        GridCFGKardex(dgvDetracciones)
        GridCFGKardex(dgvExistencias)
        GridCFGKardex(dgvServicio)
        GridCFGKardex(GridGroupingControl2)
        GridCFGKardex(dgvPreciosServicio)
        GridCFGKardex(dgvPrecios)
        GridCFGKardex(dgvAlertas)
        GridCFGKardex(GridGroupingControl1)
        GridCFGKardex(dgvHistorialAlertas)

        MasterPrecios()
        ConteoproductosSinPrecio()
        ListarPrecioAlertasConteo()
        ConteoServicios()
        lblPeriodo.Text = "Periodo: " & PeriodoGeneral
        LoadNodes()



    End Sub

#Region "Métodos"
    Private Sub MasterPrecios()
        Dim precioSA As New ConfiguracionPrecioSA

        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tasa")
        dt.Columns.Add("confirmar")

        For Each i In precioSA.ListadoPrecios()
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idPrecio
            dr(1) = i.precio
            dr(2) = i.tasaPorcentaje
            dr(3) = i.activo
            dt.Rows.Add(dr)
        Next
        dgvDetracciones.DataSource = dt


    End Sub

    Public Sub ConteoServicios()
        Dim servicioSA As New servicioSA
        Dim totales As New List(Of servicio)

        totales = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = Nothing, .idPadre = 1015})

        Me.lblCantServ.Text = totales.Count
        lblCantServ.AutoSize = False
        lblCantServ.BackColor = Color.Transparent
        lblCantServ.Dock = DockStyle.Fill
        lblCantServ.ForeColor = Color.Yellow
        lblCantServ.TextAlign = ContentAlignment.MiddleLeft




    End Sub

    Public Sub ConteoproductosSinPrecio()
        Dim totalesSA As New TotalesAlmacenSA
        Dim totales As New List(Of totalesAlmacen)

        totales = totalesSA.NumProductosSinListaPrecio(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento})

        Me.lblSinAsignar.Text = totales.Count
        lblSinAsignar.AutoSize = False
        lblSinAsignar.BackColor = Color.Transparent
        lblSinAsignar.Dock = DockStyle.Fill
        lblSinAsignar.ForeColor = Color.Yellow
        lblSinAsignar.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Sub ListarPrecioAlertasConteo()
        Dim TotalesAlmacenSA As New TotalesAlmacenSA

        Me.lblAlerta.Text = TotalesAlmacenSA.ObtenerAlertaDePrecioConteo(New totalesAlmacen With {.idAlmacen = 0})
        lblAlerta.AutoSize = False
        lblAlerta.BackColor = Color.Transparent
        lblAlerta.Dock = DockStyle.Fill
        lblAlerta.ForeColor = Color.Yellow
        lblAlerta.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Private Sub ListaTablasGenerales()
        Dim customers As New BaseCollectionTG
        customers = BaseCollectionTG.ListaTablasGenerales()
        Me.GDB.Binder.SetDataBinding(customers, "")

        Dim childrenLevel As GridHierarchyLevel

        childrenLevel = Me.GDB.Binder.AddRelation("Children")

        If IsNothing(childrenLevel) Then
            'childrenLevel = Me.GDB.Binder.AddRelation("Children")
            'childrenLevel.ShowHeaders = False
        ElseIf childrenLevel.ShowHeaders = False Then

        ElseIf childrenLevel.ShowHeaders = True Then
            childrenLevel.ShowHeaders = False
            childrenLevel.RowStyle.BackColor = SystemColors.Window
        End If
        Me.GDB.Binder.RootHierarchyLevel.ShowHeaders = True


        Dim rootLevel As GridHierarchyLevel = Me.GDB.Binder.RootHierarchyLevel
        rootLevel.RowStyle.BackColor = SystemColors.Window
        Me.GDB.DefaultRowHeight = 18
        Me.GDB.DefaultColWidth = 70
        GDB.ShowTreeLines = True
        GDB.GridBoundColumns("Descripcion").Width = 250
        GDB.GridBoundColumns("Descripcion").HeaderText = "Descripción"
        'childrenLevel.ShowHeaders = False
        'Me.GDB.Binder.RootHierarchyLevel.ShowHeaders = True
        GDB.Refresh()
    End Sub

    Private Function getChildCaja() As DataTable
        Dim objLista As New ConfiguracionPrecioProductoSA()

        Dim dt As New DataTable("Precios establecidos")
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("precioMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precioME", GetType(Decimal)))

        For Each i As configuracionPrecioProducto In objLista.GetPreciosItems
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idproducto
            dr(1) = i.fecha
            dr(2) = i.descripcion
            dr(3) = i.precioMN
            dr(4) = i.precioME
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Function getParentNombre(nombre As String) As DataTable
        Dim itemSA As New detalleitemsSA

        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        For Each i In itemSA.GetExistenciasByempresaNombre(nombre, Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = i.codigo & "   " & "-" & "   " & i.descripcionItem
            dr(2) = i.NomClasificacion
            dr(3) = i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.codigo
            dt.Rows.Add(dr)
        Next



        Return dt
    End Function


    Private Function getParentCodigo(codigobarra As String) As DataTable
        Dim itemSA As New detalleitemsSA

        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        For Each i In itemSA.GetExistenciasByempresaCodigo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, codigobarra)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = i.codigo & "   " & "-" & "   " & i.descripcionItem
            dr(2) = i.NomClasificacion
            dr(3) = i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.codigo
            dt.Rows.Add(dr)
        Next



        Return dt
    End Function


    Private Function getParent(tipo As Integer) As DataTable
        Dim itemSA As New detalleitemsSA

        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoBarra", GetType(String)))

        For Each i In itemSA.GetTipoExistenciasByempresa(tipo)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigodetalle
            dr(1) = i.descripcionItem
            'dr(1) = (i.codigo & "   " & "-" & "   " & i.descripcionItem)
            dr(2) = i.NomClasificacion
            dr(3) = i.NomMarca
            dr(4) = i.origenProducto
            dr(5) = i.tipoExistencia
            dr(6) = i.codigo
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Function getParentServicio() As DataTable
        Dim servicioSA As New servicioSA

        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))

        For Each i In servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = Nothing, .idPadre = 1015})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idServicio
            dr(1) = i.descripcion
            dr(2) = i.cuenta
            dr(3) = i.observaciones
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Function getParentproductosTerminados() As DataTable
        Dim servicioSA As New servicioSA

        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))

        For Each i In servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = Nothing, .idPadre = 1015})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idServicio
            dr(1) = i.descripcion
            dr(2) = i.cuenta
            dr(3) = i.observaciones
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Dim parentTable As New DataTable
    Dim ChildTable As New DataTable
    Dim parentTable2 As New DataTable
    Dim ChildTable2 As New DataTable


    Public Sub GetServiciosWithprecios()
        Dim dSet As New DataSet()
        parentTable2 = New DataTable
        ChildTable2 = New DataTable

        parentTable2 = getParentServicio()
        'ChildTable2 = getChildCaja()
        'dSet.Tables.AddRange(New DataTable() {parentTable2, ChildTable2})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable2.Columns("idItem")
        'Dim childColumn As DataColumn = ChildTable2.Columns("idItem")
        'dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvServicio.DataSource = parentTable2
        Me.dgvServicio.Engine.BindToCurrencyManager = False

        Me.dgvServicio.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvServicio.TopLevelGroupOptions.ShowCaption = False
    End Sub

    Public Sub GetProductosTerminadosWithprecios()
        Dim dSet As New DataSet()
        parentTable2 = New DataTable
        ChildTable2 = New DataTable

        parentTable2 = getParentServicio()
        'ChildTable2 = getChildCaja()
        'dSet.Tables.AddRange(New DataTable() {parentTable2, ChildTable2})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable2.Columns("idItem")
        'Dim childColumn As DataColumn = ChildTable2.Columns("idItem")
        'dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvServicio.DataSource = parentTable2
        Me.dgvServicio.Engine.BindToCurrencyManager = False

        Me.dgvServicio.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvServicio.TopLevelGroupOptions.ShowCaption = False
    End Sub

    Public Sub GetSubprodcutossWithprecios()
        Dim dSet As New DataSet()
        parentTable2 = New DataTable
        ChildTable2 = New DataTable

        parentTable2 = getParentServicio()
        'ChildTable2 = getChildCaja()
        'dSet.Tables.AddRange(New DataTable() {parentTable2, ChildTable2})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable2.Columns("idItem")
        'Dim childColumn As DataColumn = ChildTable2.Columns("idItem")
        'dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvServicio.DataSource = parentTable2
        Me.dgvServicio.Engine.BindToCurrencyManager = False

        Me.dgvServicio.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvServicio.TopLevelGroupOptions.ShowCaption = False
    End Sub


    Public Sub GetExistenciasNombre(nombre As String)
        parentTable = New DataTable
        ChildTable = New DataTable
        Dim dSet As New DataSet()
        parentTable = getParentNombre(nombre)
        'ChildTable = getChildCaja()
        'dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        'Dim parentColumn As DataColumn = parentTable.Columns("idItem")
        'Dim childColumn As DataColumn = ChildTable.Columns("idItem")
        'dSet.Relations.Add("ParentToChild", parentColumn, childColumn)
        If Not parentTable.Rows.Count > 0 Then

            MessageBox.Show("El nombre del producto ingresado no existe", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow

        End If

        Me.dgvExistencias.DataSource = parentTable
        Me.dgvExistencias.Engine.BindToCurrencyManager = False

        Me.dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvExistencias.TopLevelGroupOptions.ShowCaption = False




    End Sub


    Public Sub GetExistenciasCodigoBarra(codigobarra As String)
        parentTable = New DataTable
        ChildTable = New DataTable
        Dim dSet As New DataSet()
        parentTable = getParentCodigo(codigobarra)
        'ChildTable = getChildCaja()
        'dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        'Dim parentColumn As DataColumn = parentTable.Columns("idItem")
        'Dim childColumn As DataColumn = ChildTable.Columns("idItem")
        'dSet.Relations.Add("ParentToChild", parentColumn, childColumn)
        If Not parentTable.Rows.Count > 0 Then

            MessageBox.Show("El codigo ingresado no Existe", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow

        End If

        Me.dgvExistencias.DataSource = parentTable
        Me.dgvExistencias.Engine.BindToCurrencyManager = False

        Me.dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvExistencias.TopLevelGroupOptions.ShowCaption = False




    End Sub

    Public Sub GetExistenciasWithPrecios(tipo As Integer)
        parentTable = New DataTable
        ChildTable = New DataTable
        Dim dSet As New DataSet()
        parentTable = getParent(tipo)
        'ChildTable = getChildCaja()
        'dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        'Dim parentColumn As DataColumn = parentTable.Columns("idItem")
        'Dim childColumn As DataColumn = ChildTable.Columns("idItem")
        'dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvExistencias.DataSource = parentTable
        Me.dgvExistencias.Engine.BindToCurrencyManager = False

        Me.dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvExistencias.TopLevelGroupOptions.ShowCaption = False


    End Sub


    'Private Sub ListadoExistencias()
    '    Dim itemSA As New detalleitemsSA
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("idItem")
    '    dt.Columns.Add("descripcion")
    '    dt.Columns.Add("clasificacion")
    '    dt.Columns.Add("marca")
    '    dt.Columns.Add("gravado")
    '    dt.Columns.Add("tipoExistencia")

    '    For Each i In itemSA.GetExistenciasByempresa()
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.codigodetalle
    '        dr(1) = i.descripcionItem
    '        dr(2) = i.NomClasificacion
    '        dr(3) = i.NomMarca
    '        dr(4) = i.origenProducto
    '        dr(5) = i.tipoExistencia
    '        dt.Rows.Add(dr)
    '    Next
    '    dgvExistencias.DataSource = dt
    'End Sub

    Sub GridCFGKardex(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True
        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub
#End Region

    Private Sub frmTablasGenerales_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    Sub LoadNodes()

        treeViewAdv2.Nodes.Clear()

        Dim tablaSA As New TablaSA
        Dim n As New TreeNodeAdv
        Dim n1 As New TreeNodeAdv

        n = New TreeNodeAdv
        n.Text = "Lista de precios - inventario"
        n.Tag = "Lista de mercaderia"
        treeViewAdv2.Nodes.Add(n)

        n = New TreeNodeAdv
        n.Text = "Lista de servicios"
        n.Tag = "Lista de servicios"
        treeViewAdv2.Nodes.Add(n)

        'n = New TreeNodeAdv
        'n.Text = "Tablas Generales"
        'n.Tag = "Tablas"

        'For Each i In tablaSA.GetListaTabla()
        '    n1 = New TreeNodeAdv
        '    n1.Text = i.descripcion
        '    n1.Tag = i.idtabla
        '    n.Nodes.Add(n1)
        'Next

        'treeViewAdv2.Nodes.Add(n)


        'n = New TreeNodeAdv
        'n.Text = "Gestión tipo cambio"
        'n.Tag = "tipo cambio"
        'treeViewAdv2.Nodes.Add(n)


        n = New TreeNodeAdv
        n.Text = "Sin Asignar"
        n.Tag = "Sin Asignar"
        treeViewAdv2.Nodes.Add(n)

        n = New TreeNodeAdv
        n.Text = "Alertas"
        n.Tag = "Alertas"
        treeViewAdv2.Nodes.Add(n)

      

        'n = New TreeNodeAdv
        'n.Text = "Lista de productos terminados"
        'n.Tag = "Lista de productos terminados"
        'treeViewAdv2.Nodes.Add(n)

        'n = New TreeNodeAdv
        'n.Text = "Lista de subproductos - desechos y desperdicios"
        'n.Tag = "Lista de subproductos - desechos y desperdicios"
        'treeViewAdv2.Nodes.Add(n)

        n = New TreeNodeAdv
        n.Text = "Gestión Precios"
        n.Tag = "Precios"
        treeViewAdv2.Nodes.Add(n)


    End Sub
    Private Sub frmTablasGenerales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        treeViewAdv2.BackColor = Color.OrangeRed ' Color.MediumSeaGreen
        TabPage2.Parent = TabControl
        TabPage1.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabAlertas.Parent = Nothing
        TabSinAsignar.Parent = Nothing
        TabPrecios.Parent = Nothing
        Me.treeViewAdv2.Nodes(1).CustomControl = lblSinAsignar
        Me.treeViewAdv2.Nodes(2).CustomControl = lblAlerta
        Me.treeViewAdv2.Nodes(3).CustomControl = lblCantServ

        treeViewAdv2.Select()
    End Sub

    Private Sub GDB_CellClick(sender As Object, e As GridCellClickEventArgs) Handles GDB.CellClick

    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Tablas"
                TabPage1.Parent = TabControl
                TabPage2.Parent = Nothing
                TabPage3.Parent = Nothing
                TabPage4.Parent = Nothing
                TabAlertas.Parent = Nothing
                TabSinAsignar.Parent = Nothing
                TabPrecios.Parent = Nothing
                'TabProductosTerminados.Parent = Nothing
                'TabSubproductos.Parent = Nothing
            Case "Lista de mercaderia"
                btActualizar.Visible = True
                btEliminar.Visible = True
                btnEditar.Visible = True
                tsmMercaderia.Visible = False
                AsignarPrecioToolStripMenuItem.Visible = True
                NuevoServicioToolStripMenuItem.Visible = False
                tsmProducto.Visible = False
                tsmSubproductos.Visible = False
                GridCFGKardex(dgvExistencias)
                TabPage1.Parent = Nothing
                TabPage3.Parent = Nothing
                TabPage4.Parent = Nothing
                TabAlertas.Parent = Nothing
                TabSinAsignar.Parent = Nothing
                TabPrecios.Parent = Nothing
                TabPage2.Parent = TabControl
                'TabProductosTerminados.Parent = Nothing
                'TabSubproductos.Parent = Nothing
            Case "tipo cambio"
                TabPage1.Parent = Nothing
                TabPage3.Parent = TabControl
                TabPage2.Parent = Nothing
                TabPage4.Parent = Nothing
                TabAlertas.Parent = Nothing
                TabSinAsignar.Parent = Nothing
                TabPrecios.Parent = Nothing
                'TabProductosTerminados.Parent = Nothing
                'TabSubproductos.Parent = Nothing
            Case "Alertas"
                btActualizar.Visible = True
                btEliminar.Visible = False
                btnEditar.Visible = False

                tsmMercaderia.Visible = False
                AsignarPrecioToolStripMenuItem.Visible = True
                NuevoServicioToolStripMenuItem.Visible = False
                TabPage1.Parent = Nothing
                TabPage3.Parent = Nothing
                TabPage2.Parent = Nothing
                TabPage4.Parent = Nothing
                TabPrecios.Parent = Nothing
                TabAlertas.Parent = TabControl
                TabSinAsignar.Parent = Nothing
                'TabProductosTerminados.Parent = Nothing
                'TabSubproductos.Parent = Nothing
            Case "Sin Asignar"
                btActualizar.Visible = True
                btEliminar.Visible = False
                btnEditar.Visible = False
                tsmMercaderia.Visible = False
                AsignarPrecioToolStripMenuItem.Visible = True
                NuevoServicioToolStripMenuItem.Visible = False
                tsmProducto.Visible = False
                tsmSubproductos.Visible = False
                TabPage1.Parent = Nothing
                TabPage3.Parent = Nothing
                TabPage4.Parent = Nothing
                TabPage2.Parent = Nothing
                TabAlertas.Parent = Nothing
                TabPrecios.Parent = Nothing
                TabSinAsignar.Parent = TabControl
                'TabProductosTerminados.Parent = Nothing
                'TabSubproductos.Parent = Nothing
            Case "Lista de servicios"
                GridCFGKardex(dgvServicio)
                btActualizar.Visible = True
                btEliminar.Visible = True
                btnEditar.Visible = True
                tsmMercaderia.Visible = False
                AsignarPrecioToolStripMenuItem.Visible = True
                NuevoServicioToolStripMenuItem.Visible = True
                tsmProducto.Visible = False
                tsmSubproductos.Visible = False
                TabPage1.Parent = Nothing
                TabPage3.Parent = Nothing
                TabPage4.Parent = TabControl
                TabPage2.Parent = Nothing
                TabAlertas.Parent = Nothing
                TabSinAsignar.Parent = Nothing
                TabPrecios.Parent = Nothing
                'TabProductosTerminados.Parent = Nothing
                'TabSubproductos.Parent = Nothing
            Case "Precios"
                GridCFGKardex(dgvDetracciones)
                btActualizar.Visible = True
                btEliminar.Visible = True
                btnEditar.Visible = True
                tsmMercaderia.Visible = False
                AsignarPrecioToolStripMenuItem.Visible = True
                NuevoServicioToolStripMenuItem.Visible = True
                tsmProducto.Visible = False
                tsmSubproductos.Visible = False
                TabPage1.Parent = Nothing
                TabPage3.Parent = Nothing
                TabPage4.Parent = Nothing
                TabPage2.Parent = Nothing
                TabAlertas.Parent = Nothing
                TabSinAsignar.Parent = Nothing
                TabPrecios.Parent = TabControl
                'TabProductosTerminados.Parent = Nothing
                'TabSubproductos.Parent = Nothing

                'Case "Lista de productos terminados"
                '    GridCFGKardex(dgvPreciosProductoTerminado)
                '    btActualizar.Visible = True
                '    btEliminar.Visible = True
                '    btnEditar.Visible = True
                '    tsmMercaderia.Visible = False
                '    NuevoServicioToolStripMenuItem.Visible = False
                '    tsmProducto.Visible = True
                '    tsmSubproductos.Visible = False
                '    AsignarPrecioToolStripMenuItem.Visible = True
                '    TabPage1.Parent = Nothing
                '    TabPage3.Parent = Nothing
                '    TabPage4.Parent = Nothing
                '    TabPage2.Parent = Nothing
                '    TabAlertas.Parent = Nothing
                '    TabSinAsignar.Parent = Nothing
                '    TabPrecios.Parent = Nothing
                '    TabProductosTerminados.Parent = TabControl
                '    TabSubproductos.Parent = Nothing

                'Case "Lista de subproductos - desechos y desperdicios"
                '    GridCFGKardex(dgvSubproductos)
                '    btActualizar.Visible = True
                '    btEliminar.Visible = True
                '    btnEditar.Visible = True
                '    tsmMercaderia.Visible = False
                '    tsmSubproductos.Visible = True
                '    AsignarPrecioToolStripMenuItem.Visible = True
                '    NuevoServicioToolStripMenuItem.Visible = False
                '    tsmProducto.Visible = False
                '    TabPage1.Parent = Nothing
                '    TabPage3.Parent = Nothing
                '    TabPage4.Parent = Nothing
                '    TabPage2.Parent = Nothing
                '    TabAlertas.Parent = Nothing
                '    TabSinAsignar.Parent = Nothing
                '    TabPrecios.Parent = Nothing
                '    TabProductosTerminados.Parent = Nothing
                '    TabSubproductos.Parent = TabControl



        End Select

    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Tablas"
                TabPage1.Parent = TabControl
                TabPage2.Parent = Nothing
                TabPrecios.Parent = Nothing
                ListaTablasGenerales()
            Case "Lista de mercaderia"
                TabPage1.Parent = Nothing
                TabPrecios.Parent = Nothing
                TabPage2.Parent = TabControl

            Case "tipo cambio"

                LoadTipoCambio()

            Case "Alertas"
                ListarPrecioAlertas()
            Case "Sin Asignar"
                LoadProductosXalmacenSinAsignar()

            Case "Lista de servicios"
                GetServiciosWithprecios()

            Case "Precios"
                MasterPrecios()

            Case "Lista de productos terminados"
                'GetServiciosWithprecios()()

            Case "Lista de subproductos - desechos y desperdicios"
                'GetServiciosWithprecios()()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub
    Sub LoadProductosXalmacenSinAsignar()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacen As New List(Of totalesAlmacen)
        Dim dt As New DataTable()
        '  Dim codigo As Integer = cboAlmacen.SelectedValue

        dt.Columns.Add("idItem")
        dt.Columns.Add("item")
        dt.Columns.Add("destino")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("unidad")
        dt.Columns.Add("stock")
        dt.Columns.Add("btnUltimasEntradas")
        dt.Columns.Add("almacen") 'idalmacen
        dt.Columns.Add("idalmacen")
        totalesAlmacen = totalesAlmacenSA.NumProductosSinListaPrecio(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento})

        Me.lblSinAsignar.Text = totalesAlmacen.Count

        For Each i In totalesAlmacen
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.descripcion
            dr(2) = i.origenRecaudo
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = "ultimas"
            dr(7) = i.NomAlmacen
            dr(8) = i.idAlmacen
            dt.Rows.Add(dr)
        Next
        dgvPrecios.DataSource = dt
        Me.dgvPrecios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Sub ListarPrecioAlertas()
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Dim TotalesAlmacen As New List(Of totalesAlmacen)
        Dim dt As New DataTable()

        dt.Columns.Add("idalmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("idAlerta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("fechaInicio")
        dt.Columns.Add("fechaFin")

        TotalesAlmacen = TotalesAlmacenSA.ObtenerAlertaDePrecio(New totalesAlmacen With {.idAlmacen = 0})
        Me.lblAlerta.Text = TotalesAlmacen.Count
        For Each i In TotalesAlmacen
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAlmacen
            dr(1) = i.NomAlmacen
            dr(2) = i.idItem
            dr(3) = i.descripcion
            dr(4) = i.FechaUltimoPrecioKardex  'fecha inventario
            dr(5) = i.FechaUltimoPrecioConfigurado  ' fecha config precio
            dt.Rows.Add(dr)
        Next
        dgvAlertas.DataSource = dt
        Me.dgvAlertas.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Sub LoadTipoCambio()
        Dim tipocambioSA As New tipoCambioSA

        lsvTipoCambio.Items.Clear()
        Dim anio = CInt(AnioGeneral)
        Dim mes = CInt(MesGeneral)
        For Each t As tipoCambio In tipocambioSA.GetListar_tipoCambioByPeriodo(Gempresas.IdEmpresaRuc, mes, anio, GEstableciento.IdEstablecimiento)
            Dim n As New ListViewItem
            n.UseItemStyleForSubItems = False
            n.Text = 100
            n.SubItems.Add(CDate(t.fechaIgv).Date)
            n.SubItems.Add(t.compra)
            With n.SubItems.Add(t.venta)
                .ForeColor = Color.DarkRed
            End With
            lsvTipoCambio.Items.Add(n)
        Next
        lsvTipoCambio.Refresh()
    End Sub

    Private Sub CompraDeExistenciasServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmMercaderia.Click
        Dim detalleItemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '.cboIgv.Enabled = False
                '.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .Precios = True
            .IdAlmacenPrecio = TmpIdAlmacen
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControl.SelectedTab Is TabPage2 Then
            If Not IsNothing(Me.dgvExistencias.Table.CurrentRecord) Then
                Dim detalleItemSA As New detalleitemsSA
                Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                datos.Clear()


                Dim f As New frmNuevaExistencia
                f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
                '.cboTipoExistencia.SelectedValue = "01"
                f.Precios = True
                f.IdAlmacenPrecio = TmpIdAlmacen

                ' .cboTipoExistencia.Text = cboTipoExistencia.Text
                f.UCNuenExistencia.UbicarProducto(Me.dgvExistencias.Table.CurrentRecord.GetValue("idItem"))


                ' f.txtCodigoBarra.Text = Me.dgvExistencias.Table.CurrentRecord.GetValue("codigoBarra")




                f.UCNuenExistencia.txtCodigoBarra.ReadOnly = False
                'f.nudCantMax.Value = Me.dgvExistencias.Table.CurrentRecord.GetValue("cantmax")
                'f.nudCantMin.Value = Me.dgvExistencias.Table.CurrentRecord.GetValue("cantmin")
                f.UCNuenExistencia.Label7.Visible = False
                f.UCNuenExistencia.cboTipoExistencia.Visible = False
                f.Label2.Visible = False
                f.UCNuenExistencia.cboIgv.Visible = False
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                ToolStripButton2_Click(sender, e)

            Else
                MessageBox.Show("Debe seleccionar un item válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If



        ElseIf TabControl.SelectedTab Is TabPage4 Then

            If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then
                Dim detalleItemSA As New detalleitemsSA
                Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                datos.Clear()

                Dim f As New frmNewServicio("SERVICIOS")
                f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
                'f.UbicarProducto(Me.dgvServicio.Table.CurrentRecord.GetValue("idItem"))
                f.lblidservicio.Text = Me.dgvServicio.Table.CurrentRecord.GetValue("idItem")
                f.txtDescripcion.Text = Me.dgvServicio.Table.CurrentRecord.GetValue("descripcion")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GetServiciosWithprecios()
            Else
                MessageBox.Show("Debe seleccionar un item válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btActualizar.Click
        Me.Cursor = Cursors.WaitCursor
        ConteoproductosSinPrecio()
        ListarPrecioAlertasConteo()
        ConteoServicios()
        If TabControl.SelectedTab Is TabPage2 Then
            Select Case cboMercaderia.Text
                Case "MERCADERIA"
                    GetExistenciasWithPrecios(TipoExistencia.Mercaderia)
                    tsmMercaderia.Visible = False
                    tsmProducto.Visible = False
                    tsmSubproductos.Visible = False
                Case "PRODUCTOS TERMINADOS"
                    GetExistenciasWithPrecios(TipoExistencia.ProductoTerminado)
                    tsmMercaderia.Visible = False
                    tsmProducto.Visible = True
                    tsmSubproductos.Visible = False
                Case "SUBPRODUCTOS - DESECHOS Y DESPERDICIOS"
                    GetExistenciasWithPrecios(TipoExistencia.SubProductosDesechos)
                    tsmMercaderia.Visible = False
                    tsmProducto.Visible = False
                    tsmSubproductos.Visible = True
            End Select
        ElseIf TabControl.SelectedTab Is TabPage1 Then
            ListaTablasGenerales()
        ElseIf TabControl.SelectedTab Is TabPage3 Then
            LoadTipoCambio()

        ElseIf TabControl.SelectedTab Is TabAlertas Then
            ListarPrecioAlertas()

        ElseIf TabControl.SelectedTab Is TabSinAsignar Then
            LoadProductosXalmacenSinAsignar()

        ElseIf TabControl.SelectedTab Is TabPage4 Then
            GetServiciosWithprecios()

        ElseIf TabControl.SelectedTab Is TabPrecios Then
            MasterPrecios()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        Me.dgvExistencias.TopLevelGroupOptions.ShowFilterBar = True
        Me.dgvExistencias.NestedTableGroupOptions.ShowFilterBar = True
        Me.dgvExistencias.ChildGroupOptions.ShowFilterBar = True

        For Each col As GridColumnDescriptor In Me.dgvExistencias.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        Filter.AllowResize = True
        Filter.AllowFilterByColor = True
        Filter.EnableDateFilter = True
        Filter.EnableNumberFilter = True

        'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
        'For Each col As GridColumnDescriptor In td.Columns
        '    col.AllowFilter = True
        'Next

        Me.dgvExistencias.OptimizeFilterPerformance = True
        Me.dgvExistencias.ShowNavigationBar = True

        Filter.WireGrid(dgvExistencias)
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        filter.ClearFilters(Me.dgvExistencias)
        Me.dgvExistencias.TopLevelGroupOptions.ShowFilterBar = False
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        dgvExistencias.TableDescriptor.GroupedColumns.Clear()
        If dgvExistencias.ShowGroupDropArea = True Then
            dgvExistencias.ShowGroupDropArea = False
        Else
            dgvExistencias.ShowGroupDropArea = True
        End If
    End Sub
    Public Sub eliminarServ(idserv As Integer)
        Dim tipoSA As New servicioSA
        Dim obj As New servicio

        obj.idServicio = idserv

        tipoSA.EliminarServicio(obj)

    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Dim tipoSA As New tipoCambioSA
        Dim tipo As New servicioSA
        Me.Cursor = Cursors.WaitCursor
        If TabControl.SelectedTab Is TabPage2 Then

        ElseIf TabControl.SelectedTab Is TabPage1 Then

        ElseIf TabControl.SelectedTab Is TabPage3 Then

            If lsvTipoCambio.SelectedItems.Count > 0 Then

                If MessageBox.Show("Desea eliminar el registro seleccionado ?", "Atención", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    tipoSA.DeleteTC(New tipoCambio With {.fechaIgv = lsvTipoCambio.SelectedItems(0).SubItems(1).Text,
                                                     .idRegulador = 100})

                    LoadTipoCambio()
                    MessageBox.Show("Tipo de cambio eliminado!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                MessageBox.Show("Seleccione un tipo de cambio válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        ElseIf TabControl.SelectedTab Is TabPage4 Then
            If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then
                If MessageBox.Show("Desea eliminar el servicio ?", "Atención", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    eliminarServ(CInt(Me.dgvServicio.Table.CurrentRecord.GetValue("idItem")))

                    GetServiciosWithprecios()
                    MessageBox.Show("Servicio eliminado!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                MessageBox.Show("Debe seleccionar un item válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)


            End If


        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevoTipoDeCambioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoTipoDeCambioToolStripMenuItem.Click
        With frmTipoCambio
            .txtFechaIgv.Value = DateTime.Now.Date
            .StartPosition = FormStartPosition.CenterParent
            .nudTipoCambioCompra.Value = 0
            .nudTipoCambio.Value = 0
            .ShowDialog()
            TabPage2.Parent = Nothing
            TabPage1.Parent = Nothing
            TabPage3.Parent = TabControl
            LoadTipoCambio()
        End With
    End Sub
    Public Sub UbicarUltimosPreciosXproducto_Alertas(r As Record)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(r.GetValue("idalmacen"), r.GetValue("idAlerta"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "1", "CON IVA", "SIN IVA")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        dgvHistorialAlertas.DataSource = dt

    End Sub

    Public Sub UbicarUltimosPreciosServicio(intIdItem As Integer)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdItem)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "1", "CON IVA", "SIN IVA")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        dgvPreciosServicio.DataSource = dt

    End Sub

    Public Sub UbicarUltimosPreciosExistencias(intIdItem As Integer)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdItem)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "1", "CON IVA", "SIN IVA")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl2.DataSource = dt

    End Sub

    Private Sub dgvAlertas_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvAlertas.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        dgvHistorialAlertas.Table.Records.DeleteAll()
        If Not IsNothing(dgvAlertas.Table.CurrentRecord) Then
            UbicarUltimosPreciosXproducto_Alertas(dgvAlertas.Table.CurrentRecord)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvAlertas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAlertas.TableControlCellClick

    End Sub

    Private Sub dgvPrecios_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvPrecios.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        GridGroupingControl1.Table.Records.DeleteAll()
        If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
            UbicarUltimosPreciosXproducto(dgvPrecios.Table.CurrentRecord)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Public Sub UbicarUltimosPreciosXproducto(r As Record)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(r.GetValue("idalmacen"), r.GetValue("idItem"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "1", "CON IVA", "SIN IVA")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt

    End Sub
    Private Sub dgvPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPrecios.TableControlCellClick

    End Sub

    Private Sub AsignarPrecioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarPrecioToolStripMenuItem.Click
        If TabControl.SelectedTab Is TabAlertas Then
            If Not IsNothing(dgvAlertas.Table.CurrentRecord) Then
                Dim f As New frmNuevoPrecio
                Dim prodSA As New detalleitemsSA
                'f.txtAlmacen.Text = cboAlmacen.Text
                'f.txtAlmacen.Tag = cboAlmacen.SelectedValue
                'f.txtAlmacen.Text = dgvAlertas.Table.CurrentRecord.GetValue("almacen")
                'f.txtAlmacen.Tag = dgvAlertas.Table.CurrentRecord.GetValue("idalmacen")
                f.txtProducto.Tag = dgvAlertas.Table.CurrentRecord.GetValue("idAlerta")
                f.txtProducto.Text = dgvAlertas.Table.CurrentRecord.GetValue("descripcion")
                f.txtGrav.Text = prodSA.InvocarProductoID(CInt(dgvAlertas.Table.CurrentRecord.GetValue("idAlerta"))).origenProducto
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                ListarPrecioAlertasConteo()
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf TabControl.SelectedTab Is TabSinAsignar Then
            If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
                Dim f As New frmNuevoPrecio
                'f.txtAlmacen.Text = cboAlmacen.Text
                'f.txtAlmacen.Tag = cboAlmacen.SelectedValue
                'f.txtAlmacen.Text = dgvPrecios.Table.CurrentRecord.GetValue("almacen")
                'f.txtAlmacen.Tag = dgvPrecios.Table.CurrentRecord.GetValue("idalmacen")
                f.txtProducto.Tag = dgvPrecios.Table.CurrentRecord.GetValue("idItem")
                f.txtProducto.Text = dgvPrecios.Table.CurrentRecord.GetValue("item")
                f.txtGrav.Text = dgvPrecios.Table.CurrentRecord.GetValue("destino")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                ConteoproductosSinPrecio()
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf TabControl.SelectedTab Is TabPage2 Then
            If Not IsNothing(dgvExistencias.Table.CurrentRecord) Then
                Dim f As New frmNuevoPrecio

                f.txtProducto.Tag = dgvExistencias.Table.CurrentRecord.GetValue("idItem")
                f.txtProducto.Text = dgvExistencias.Table.CurrentRecord.GetValue("descripcion")
                f.txtGrav.Text = dgvExistencias.Table.CurrentRecord.GetValue("gravado")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar un artículo y/o servicio", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf TabControl.SelectedTab Is TabPage4 Then
            If Not IsNothing(dgvServicio.Table.CurrentRecord) Then
                Dim f As New frmNuevoPrecio

                f.txtProducto.Tag = dgvServicio.Table.CurrentRecord.GetValue("idItem")
                f.txtProducto.Text = dgvServicio.Table.CurrentRecord.GetValue("descripcion")
                f.txtGrav.Text = "2"
                f.ChReferencia.Enabled = False
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar un servicio", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
    End Sub

    Private Sub dgvServicio_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvServicio.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        dgvPreciosServicio.Table.Records.DeleteAll()
        If Not IsNothing(dgvServicio.Table.CurrentRecord) Then
            UbicarUltimosPreciosServicio(dgvServicio.Table.CurrentRecord.GetValue("idItem"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvServicio_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvServicio.TableControlCellClick

    End Sub

    Private Sub dgvExistencias_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvExistencias.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        GridGroupingControl2.Table.Records.DeleteAll()
        If Not IsNothing(dgvExistencias.Table.CurrentRecord) Then
            UbicarUltimosPreciosExistencias(dgvExistencias.Table.CurrentRecord.GetValue("idItem"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvExistencias_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvExistencias.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        GridGroupingControl2.Table.Records.DeleteAll()
        If Not IsNothing(dgvExistencias.Table.CurrentRecord) Then
            UbicarUltimosPreciosExistencias(dgvExistencias.Table.CurrentRecord.GetValue("idItem"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevoServicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoServicioToolStripMenuItem.Click

        ' Dim detalleItemSA As New detalleitemsSA
        'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        'datos.Clear()
        'With frmNewServicio
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With

        Dim f As New frmNewServicio("SERVICIOS")
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetServiciosWithprecios()
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click

    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmProducto.Click
        Dim detalleItemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '.cboIgv.Enabled = False
                '.cboIgv.Text = "2 - EXONERADO"
                '.cboTipoExistencia.Enabled = False
                '.cboUnidades.SelectedIndex = -1
                '.cboUnidades.Enabled = True
            Else

            End If
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            '   .cboTipoExistencia.SelectedValue = "02"
            .Precios = True
            .IdAlmacenPrecio = TmpIdAlmacen
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub cboMercaderia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMercaderia.SelectedIndexChanged
        Select Case cboMercaderia.Text
            Case "MERCADERIA"
                GetExistenciasWithPrecios(TipoExistencia.Mercaderia)
                tsmMercaderia.Visible = False
                tsmProducto.Visible = False
                tsmSubproductos.Visible = False
            Case "PRODUCTOS TERMINADOS"
                GetExistenciasWithPrecios(TipoExistencia.ProductoTerminado)
                tsmMercaderia.Visible = False
                tsmProducto.Visible = True
                tsmSubproductos.Visible = False
            Case "SUBPRODUCTOS - DESECHOS Y DESPERDICIOS"
                GetExistenciasWithPrecios(TipoExistencia.SubProductosDesechos)
                tsmMercaderia.Visible = False
                tsmProducto.Visible = False
                tsmSubproductos.Visible = True
        End Select
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub tsmSubproductos_Click(sender As Object, e As EventArgs) Handles tsmSubproductos.Click
        Dim detalleItemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '.cboIgv.Enabled = False
                '.cboIgv.Text = "2 - EXONERADO"
                '.cboTipoExistencia.Enabled = False
                '.cboUnidades.SelectedIndex = -1
                '.cboUnidades.Enabled = True
            Else

            End If
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            '  .cboTipoExistencia.SelectedValue = "06"
            .Precios = True
            .IdAlmacenPrecio = TmpIdAlmacen
            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub cboMercaderia_Click(sender As Object, e As EventArgs) Handles cboMercaderia.Click

    End Sub

    Private Sub txtCodigoBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoBarra.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Not txtCodigoBarra.Text.Trim.Length > 0 Then

                MessageBox.Show("Ingrese un Codigo para Buscar", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            GetExistenciasCodigoBarra(txtCodigoBarra.Text)




        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub txtCodigoBarra_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoBarra.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Not txtBuscarProducto.Text.Trim.Length > 0 Then

                MessageBox.Show("Ingrese un Nombre para Buscar", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            GetExistenciasNombre(txtBuscarProducto.Text)




        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscarProducto.KeyPress

    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDeServiciosPúblicosToolStripMenuItem.Click

    End Sub
End Class