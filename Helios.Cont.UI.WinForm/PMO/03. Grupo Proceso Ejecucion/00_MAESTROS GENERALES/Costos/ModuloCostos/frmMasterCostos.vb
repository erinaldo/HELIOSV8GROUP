Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Helios.Cont.Presentation.WinForm.RecursoCostoEF

Public Class frmMasterCostos
    Dim lbl As Label
    Dim lblCenter As Label
    Dim fedd As New FeedbackForm



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Normal
        GridCFGDetetail(grdRecursos)
        GridCFG(dgvCostos)
        GridCFG(dgvRecursosAsignados)
        'GetCountItemsNoAsignados()
        Me.GDBSource.Model.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
        CMBEstatus()
        lbl = New Label
        lbl.ForeColor = Color.White
        lbl.AutoSize = True
        lbl.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        cboCosto.Enabled = True
        cbotipo.Enabled = True
        lsvProceso.FullRowSelect = True
        lsvProceso.HideSelection = False
        cbotipo.SelectedIndex = -1

        'Me.dgtareas.Model.Options.ResizeColsBehavior = Me.dgtareas.Model.Options.ResizeColsBehavior Or GridResizeCellsBehavior.InsideGrid

        'Me.dgtareas.TableStyle.WrapText = False

        ''   Me.dgtareas.CurrentCell.MoveTo(Me.dgtareas.Model.Rows.HeaderCount + 1, 3)
        'Me.dgtareas.Binder.EnableAddNew = False
        'Me.dgtareas.Properties.BackgroundColor = SystemColors.Window

        ''   Me.dgtareas.BeginUpdate()
        'Me.dgtareas.CollapseAll()
        'Me.dgTareas.Model.QueryCellInfo += New GridQueryCellInfoEventHandler(Model_QueryCellInfo)


        'AddHandler dgTareas.Model.QueryCellInfo, AddressOf Model_QueryCellInfo
        'Me.dgTareas.CellToolTip.AutoPopDelay = 2000
        cbotipoRecurso.Enabled = True
        ConfigPlan()
    End Sub


    'Private Sub Model_QueryCellInfo(sender As Object, e As GridQueryCellInfoEventArgs)
    '    If e.ColIndex > 0 AndAlso e.RowIndex > Me.dgTareas.Model.Rows.HeaderCount Then
    '        e.Style.CellTipText = e.Style.Text
    '    End If
    'End Sub

#Region "Métodos"
    Sub CMBEstatus()
        Dim tablaSA As New tablaDetalleSA


        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("name")

        Dim dr As DataRow = dt.NewRow
        dr(0) = StatusCosto.Avance_Obra_Cartera
        dr(1) = "En cartera"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow
        dr1(0) = StatusCosto.Proceso
        dr1(1) = "En Proceso"
        dt.Rows.Add(dr1)

        Dim dr2 As DataRow = dt.NewRow
        dr2(0) = StatusCosto.Culminado
        dr2(1) = "Culminado"
        dt.Rows.Add(dr2)

        Dim dr3 As DataRow = dt.NewRow
        dr3(0) = StatusCosto.Suspendido
        dr3(1) = "Suspendido"
        dt.Rows.Add(dr3)

        '---------------------------------------------------------------------
        Dim dtTipo As New DataTable()
        dtTipo.Columns.Add("codigo", GetType(Integer))
        dtTipo.Columns.Add("descripcion")

        Dim drTipo As DataRow = dtTipo.NewRow
        drTipo(0) = CInt(TipoRecursoPlaneado.Inventario)
        drTipo(1) = "INVENTARIO"
        dtTipo.Rows.Add(drTipo)

        Dim drTipo2 As DataRow = dtTipo.NewRow
        drTipo2(0) = CInt(TipoRecursoPlaneado.ManoDeObra)
        drTipo2(1) = "MANO DE OBRA"
        dtTipo.Rows.Add(drTipo2)

        Dim drTipo3 As DataRow = dtTipo.NewRow
        drTipo3(0) = CInt(TipoRecursoPlaneado.ActivoInmovilizado)
        drTipo3(1) = "ACTIVO INMOVILIZADO"
        dtTipo.Rows.Add(drTipo3)

        Dim drTipo4 As DataRow = dtTipo.NewRow
        drTipo4(0) = CInt(TipoRecursoPlaneado.Terceros)
        drTipo4(1) = "TERCEROS"
        dtTipo.Rows.Add(drTipo4)
        '--------------------------------------------------------------------------



        Dim ggcStyle As GridTableCellStyleInfo = dgvCartera.TableDescriptor.Columns("Estado").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "ID"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

        Dim tabla As New List(Of tabladetalle)
        tabla = tablaSA.GetListaTablaDetalle(6, "1").OrderBy(Function(o) o.descripcion).ToList

        Dim ggcStyle2 As GridTableCellStyleInfo = grdRecursos.TableDescriptor.Columns("um").Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = tabla
        ggcStyle2.ValueMember = "codigoDetalle"
        ggcStyle2.DisplayMember = "descripcion"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive

        Dim ggcStyle22 As GridTableCellStyleInfo = dgvRQ.TableDescriptor.Columns("um").Appearance.AnyRecordFieldCell
        ggcStyle22.CellType = "ComboBox"
        ggcStyle22.DataSource = tabla
        ggcStyle22.ValueMember = "codigoDetalle"
        ggcStyle22.DisplayMember = "descripcion"
        ggcStyle22.DropDownStyle = GridDropDownStyle.Exclusive

        Dim ggcStyle3 As GridTableCellStyleInfo = grdRecursos.TableDescriptor.Columns("tipoRecurso").Appearance.AnyRecordFieldCell
        ggcStyle3.CellType = "ComboBox"
        ggcStyle3.DataSource = dtTipo
        ggcStyle3.ValueMember = "codigo"
        ggcStyle3.DisplayMember = "descripcion"
        ggcStyle3.DropDownStyle = GridDropDownStyle.Exclusive

        Dim ggcStyle33 As GridTableCellStyleInfo = dgvRQ.TableDescriptor.Columns("tipoRecurso").Appearance.AnyRecordFieldCell
        ggcStyle33.CellType = "ComboBox"
        ggcStyle33.DataSource = dtTipo
        ggcStyle33.ValueMember = "codigo"
        ggcStyle33.DisplayMember = "descripcion"
        ggcStyle33.DropDownStyle = GridDropDownStyle.Exclusive

        dgvCartera.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        'dgvCartera.ShowRowHeaders = False
    End Sub

    Sub GridCFGDetetail(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    'Dim listaCategoria As New List(Of item)
    'Private Sub CMBClasificacion()
    '    Dim categoriaSA As New itemSA

    '    listaCategoria = New List(Of item)

    '    listaCategoria = categoriaSA.GetListaPadre()

    'End Sub
    Sub GrabarRecurso()
        Dim recursoSA As New recursoCostoDetalleSA
        Dim obj As New recursoCostoDetalle

        obj = New recursoCostoDetalle
        obj.idCosto = dgvPlaneamiento.Table.CurrentRecord.GetValue("idActividad")
        obj.fechaRegistro = DateTime.Now

        Select Case cbotipoRecurso.Text
            Case "INVENTARIO"
                obj.iditem = TipoRecursoPlaneado.Inventario
                obj.um = "07"
            Case "MANO DE OBRA"
                obj.iditem = TipoRecursoPlaneado.ManoDeObra
                obj.um = "HH"
            Case "ACTIVOS INMOVILIZADOS"
                obj.iditem = TipoRecursoPlaneado.ActivoInmovilizado
                obj.um = "HM"
            Case "TERCEROS"
                obj.iditem = TipoRecursoPlaneado.Terceros
                obj.um = "07"
        End Select

        obj.destino = "1"
        obj.descripcion = txtCategoria.Text
        obj.cant = 0
        obj.puMN = 0
        obj.puME = 0
        obj.montoMN = 0
        obj.montoME = 0
        obj.documentoRef = Nothing
        obj.itemRef = Nothing
        obj.operacion = Nothing
        obj.procesado = Nothing
        obj.idProceso = Nothing
        obj.tipoCosto = "PL"
        recursoSA.GrabarDetalleRecursosByTarea(obj)
        GetRecursosAsignadosXTarea(New recursoCosto With {.idCosto = txtActividadActual.Tag})
    End Sub

#Region "Requerimientos"
    Sub GrabarRQ()
        Dim recursoSA As New recursoCostoDetalleSA
        Dim obj As New recursoCostoDetalle

        obj = New recursoCostoDetalle
        obj.fechaRegistro = DateTime.Now
        obj.idCosto = Val(txtProyecto.Tag)
        obj.fechaRegistro = DateTime.Now
        Select Case cboTipoRQ.Text
            Case "INVENTARIO"
                obj.iditem = TipoRecursoPlaneado.Inventario
                obj.um = "07"
            Case "MANO DE OBRA"
                obj.iditem = TipoRecursoPlaneado.ManoDeObra
                obj.um = "HH"
            Case "ACTIVOS INMOVILIZADOS"
                obj.iditem = TipoRecursoPlaneado.ActivoInmovilizado
                obj.um = "HM"
            Case "TERCEROS"
                obj.iditem = TipoRecursoPlaneado.Terceros
                obj.um = "07"
        End Select

        obj.destino = "1"
        obj.descripcion = txtRecursoRequerimiento.Text

        obj.cant = 0
        obj.puMN = 0
        obj.puME = 0
        obj.montoMN = 0
        obj.montoME = 0
        obj.documentoRef = Nothing
        obj.itemRef = Nothing
        obj.operacion = Nothing
        obj.procesado = Nothing
        obj.idProceso = Nothing
        obj.tipoCosto = "RQ"
        recursoSA.GrabarDetalleRecursosByTarea(obj)
        'GetRecursosAsignadosXTarea(New recursoCosto With {.idCosto = txtActividadActual.Tag})
    End Sub
#End Region
    Dim captionCoverCols As Integer

    Sub GetPlaneamiento2(intIdProyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim dt As New DataTable("Orders")

        dt.Columns.Add("idProceso")
        dt.Columns.Add("nomProceso")
        dt.Columns.Add("idActividad")
        dt.Columns.Add("nomActividad")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")
        dt.Columns.Add("costo")
        dt.Columns.Add("duracion")

        For Each i In costoSA.GetPlaneamientoActividades(New recursoCosto With {.idCosto = intIdProyecto})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.IdProceso
            dr(1) = i.NomProceso
            dr(2) = i.IdActividad
            If IsNothing(i.NomActividad) Then
                dr(3) = String.Empty
                dr(4) = String.Empty
                dr(5) = String.Empty
                dr(7) = String.Empty
            Else
                Dim ts As TimeSpan = Convert.ToDateTime(i.finaliza).Subtract(i.inicio)

                dr(3) = i.NomActividad
                dr(4) = i.inicio
                dr(5) = i.finaliza
                dr(6) = ts.Days & " días, " & ts.Hours = "Hrs."
            End If
            dr(6) = i.TotalMN
            dt.Rows.Add(dr)
        Next
        dgvPlaneamiento.DataSource = dt

    End Sub

    Sub ConfigPlan()
        Dim ordersDescriptor As GridTableDescriptor = Me.dgvPlaneamiento.TableDescriptor

        ' You can define a summary row and mark it hidden.
        ' In that summary row you can add a column and set it's mapping name (and DisplayColumn) to be Freight
        Dim summaryColumn1 As New GridSummaryColumnDescriptor("FreightAverage", SummaryType.DoubleAggregate, "costo", "{Sum:##,##00.00}")
        Dim summaryRow1 As New GridSummaryRowDescriptor()

        summaryRow1.Name = "Caption"
        summaryRow1.Visible = False
        summaryRow1.SummaryColumns.Add(summaryColumn1)
        ordersDescriptor.SummaryRows.Add(summaryRow1)

        ' This is a second row, not marked hidden and therefore shown at the end of the group.
        Dim summaryColumn2 As New GridSummaryColumnDescriptor("FreightTotal", SummaryType.DoubleAggregate, "costo", "{Sum:##,##00.00}")
        Dim summaryRow2 As New GridSummaryRowDescriptor()
        summaryRow2.Name = "Costo Proyecto"
        summaryRow2.Visible = True
        summaryRow2.SummaryColumns.Add(summaryColumn2)
        ordersDescriptor.SummaryRows.Add(summaryRow2)

        ' Here you define the summary row that should be used for displaying summaries in caption bar.
        ordersDescriptor.ChildGroupOptions.ShowCaptionSummaryCells = True
        ordersDescriptor.ChildGroupOptions.CaptionSummaryRow = "Caption"

        ' Let's you hide/show the second row in child groups.
        ordersDescriptor.ChildGroupOptions.ShowSummaries = False
        captionCoverCols = 2
        ' Move Freight column ahead 
        ' ordersDescriptor.VisibleColumns.LoadDefault();
        Dim count As Integer = ordersDescriptor.VisibleColumns.Count
        ' force populating VisibleColumns

        'aquidddddddddddddddddddddddd

        Me.dgvPlaneamiento.Appearance.GroupCaptionCell.BackColor = Me.dgvPlaneamiento.Appearance.RecordFieldCell.BackColor
        Me.dgvPlaneamiento.Appearance.GroupCaptionCell.Borders.Top = New GridBorder(GridBorderStyle.Standard)
        Me.dgvPlaneamiento.Appearance.GroupCaptionCell.CellType = "Static"

        Me.dgvPlaneamiento.TableOptions.CaptionRowHeight = Me.dgvPlaneamiento.TableOptions.RecordRowHeight

        Me.dgvPlaneamiento.ChildGroupOptions.ShowAddNewRecordBeforeDetails = False

        ' Specify group sort order behavoir when adding SortColumnDescriptor to GroupedColumns
        Me.dgvPlaneamiento.TableDescriptor.GroupedColumns.Clear()
        Dim gsd As New SortColumnDescriptor("nomProceso")

        ' specify your own Comparer
        'gsd.GroupSortOrderComparer = new ShipViaComparer(summaryColumn1.GetSummaryDescriptorName(), "Average");

        ' or specify a summary name and the property (values will be determined using reflection)
        gsd.SetGroupSummarySortOrder(summaryColumn1.GetSummaryDescriptorName(), "Sum")

        Me.dgvPlaneamiento.TableDescriptor.GroupedColumns.Add(gsd)
        ' this should always be true since changing one record can cause the whole group to move 
        ' to a different position.
        Me.dgvPlaneamiento.InvalidateAllWhenListChanged = True

        Me.dgvPlaneamiento.TableOptions.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvPlaneamiento.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvPlaneamiento.TopLevelGroupOptions.ShowCaption = False
        Me.dgvPlaneamiento.Appearance.AnySummaryCell.BackColor = Color.FromArgb(255, 231, 162)

        dgvPlaneamiento.ShowRowHeaders = True
    End Sub

    Sub GetPlaneamientoByProyecto(idProyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim dt As New DataTable("Orders")

        dt.Columns.Add("idProceso")
        dt.Columns.Add("nomProceso")
        dt.Columns.Add("idActividad")
        dt.Columns.Add("nomActividad")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")
        dt.Columns.Add("costo")
        dt.Columns.Add("duracion")

        For Each i In costoSA.GetPlaneamientoActividades(New recursoCosto With {.idCosto = idProyecto})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.IdProceso
            dr(1) = i.NomProceso
            dr(2) = i.IdActividad
            If IsNothing(i.NomActividad) Then
                dr(3) = String.Empty
                dr(4) = String.Empty
                dr(5) = String.Empty
                dr(7) = String.Empty
            Else
                'Dim fechaInicial As New DateTime(2009, 1, 1)

                Dim ts As TimeSpan = Convert.ToDateTime(i.finaliza).Subtract(i.inicio)


                dr(3) = i.NomActividad
                dr(4) = i.inicio
                dr(5) = i.finaliza
                dr(7) = ts.Days & " días, " & ts.Hours = "Hrs."
            End If

            dr(6) = i.TotalMN

            dt.Rows.Add(dr)
        Next
        dgvPlaneamiento.DataSource = dt


    End Sub

    'Sub GetProyectoSelec(be As recursoCosto)
    '    Dim customers As New CustomersList()
    '    customers.GetPlaneamiento(be)
    '    Dim binder As GridModelDataBinder = Me.dgTareas.Binder
    '    binder.SetDataBinding(customers, "")

    '    Dim childrenLevel As GridHierarchyLevel = Me.dgTareas.Binder.AddRelation("Children")
    '    childrenLevel.ShowHeaders = False
    '    Me.dgTareas.Binder.RootHierarchyLevel.ShowHeaders = True

    '    Dim rob As New RecordObjectBinder(TryCast(Me.dgTareas.Model, GridDataBoundGridModel))

    '    Dim rootLevel As GridHierarchyLevel = binder.RootHierarchyLevel

    '    Dim gbc As New GridBoundColumnsCollection(Me.dgTareas.Binder)
    '    Dim rgb1 As New GridBoundColumn()
    '    rgb1.MappingName = "ID"
    '    rgb1.HeaderText = "ID"
    '    rgb1.ReadOnly = True
    '    rgb1.Width = 0
    '    rgb1.Hidden = True
    '    Dim rgb2 As New GridBoundColumn()
    '    rgb2.MappingName = "FirstName"
    '    rgb2.HeaderText = "Proyecto plan"
    '    rgb2.ReadOnly = True
    '    rgb2.Width = 400
    '    Dim rgb3 As New GridBoundColumn()
    '    rgb3.MappingName = "LastName"
    '    rgb3.HeaderText = "Status"
    '    rgb3.ReadOnly = True
    '    Dim rgb4 As New GridBoundColumn()
    '    rgb4.MappingName = "Director"
    '    rgb4.HeaderText = "Líder"
    '    rgb4.ReadOnly = True
    '    Dim rgb5 As New GridBoundColumn()
    '    rgb5.MappingName = "Inicio"
    '    rgb5.ReadOnly = True
    '    Dim rgb6 As New GridBoundColumn()
    '    rgb6.MappingName = "Finaliza"
    '    rgb6.ReadOnly = True
    '    Dim rgb7 As New GridBoundColumn()
    '    rgb7.MappingName = "Tipo"
    '    rgb7.ReadOnly = True
    '    gbc.AddRange(New GridBoundColumn() {rgb1, rgb2, rgb3, rgb4, rgb5, rgb6, rgb7})

    '    rootLevel.GridBoundColumns = gbc
    '    childrenLevel.GridBoundColumns = DirectCast(gbc.Clone(), GridBoundColumnsCollection)
    '    'childrenLevel.RowStyle.BackColor = Color.MistyRose
    '    rootLevel.RowStyle.BackColor = SystemColors.Window
    '    'Me.dgTareas.DefaultRowHeight = 18
    '    'Me.dgTareas.DefaultColWidth = 70
    '    Me.dgTareas.Model.Properties.GridLineColor = System.Drawing.Color.Silver
    '    Me.dgTareas.Model.Options.DefaultGridBorderStyle = GridBorderStyle.Solid
    '    Me.dgTareas.ExpandAll()
    ''End Sub

    Private Function GetParentCosto() As DataTable
        Dim dt As New DataTable("ParentTable")


        dt.Columns.Add(New DataColumn("idProyecto"))
        dt.Columns.Add(New DataColumn("Proyecto"))
        dt.Columns.Add(New DataColumn("idpadre"))


        Dim dr As DataRow = dt.NewRow()
        dr(0) = txtProyecto.Tag
        dr(1) = txtProyecto.Text
        dr(2) = 0
        dt.Rows.Add(dr)

        Return dt
    End Function


    Dim level0 As GridHierarchyLevel
    Dim level1 As GridHierarchyLevel

    Sub CargarTareasPorProyecto()
        Dim parentTable As New DataTable
        Dim childTable As New DataTable

        parentTable = GetParentCosto()
        childTable = GetChildCosto(New recursoCosto With {.idCosto = txtProyecto.Tag})
        'Dim grandChildTable As DataTable = GetGrandChildTable()
        'Dim greatGrandChildTable As DataTable = GetGreatGrandChildTable()
        'Dim greatGreatGrandChildTable As DataTable = GetGreatGreatGrandChildTable()
        '  Me.dgtareas.Model.ClearCells(GridRangeInfo.Table(), True)
        Dim ds As New DataSet()

        'ds.Tables.AddRange(New DataTable() {parentTable, childTable, grandChildTable, greatGrandChildTable, greatGreatGrandChildTable})
        ds.Tables.AddRange(New DataTable() {parentTable, childTable})

        ds.Relations.Add(New DataRelation("ParentToChild", ds.Tables(0).Columns("idProyecto"), ds.Tables(1).Columns("idpadre")))
        'ds.Relations.Add(New DataRelation("ChildToGrandChild", ds.Tables(1).Columns("childID"), ds.Tables(2).Columns("ChildID")))
        'ds.Relations.Add(New DataRelation("GrandChildToGreatGrandChild", ds.Tables(2).Columns("grandChildID"), ds.Tables(3).Columns("GrandChildID")))
        'ds.Relations.Add(New DataRelation("GreatGrandChildToGreatGreatGrandChild", ds.Tables(3).Columns("greatGrandChildID"), ds.Tables(4).Columns("GreatGrandChildID")))

        'Me.dgTareas.DataSource = ds
        'Me.dgTareas.DataMember = parentTable.TableName
        'level0 = Me.dgTareas.Binder.RootHierarchyLevel
        'level1 = Me.dgTareas.Binder.AddRelation("ParentToChild")
        'level2 = Me.gridDataBoundGrid1.Binder.AddRelation("ChildToGrandChild")
        'level3 = Me.gridDataBoundGrid1.Binder.AddRelation("GrandChildToGreatGrandChild")
        'level4 = Me.gridDataBoundGrid1.Binder.AddRelation("GreatGrandChildToGreatGreatGrandChild")


        'Me.dgtareas.ExpandAll()
        '  Me.dgtareas.EndUpdate()
        'Me.dgTareas.Refresh()
    End Sub

    Private Function GetChildCosto(be As recursoCosto) As DataTable
        Dim dt As New DataTable("ChildCosto")
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New List(Of recursoCosto)


        recurso = recursoSA.GetTareasByProyecto(be)

        dt.Columns.Add(New DataColumn("idTarea"))
        dt.Columns.Add(New DataColumn("Tarea"))
        dt.Columns.Add(New DataColumn("idpadre"))

        For Each i In recurso
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idCosto
            dr(1) = i.nombreCosto
            dr(2) = i.idpadre
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Sub getProyectoByCodigo(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim personaSA As New PersonaSA
        Dim persona As New Persona

        recurso = recursoSA.GetProyectoByCodigoGenerado(be)
        If Not IsNothing(recurso) Then
            persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, recurso.director)

            If Not IsNothing(persona) Then
                lblDirector.Text = "Director: " & persona.nombreCompleto
            Else
                lblDirector.Text = String.Empty
            End If

            If Not IsNothing(recurso) Then
                txtProyecto.Text = recurso.nombreCosto
                txtProyecto.Tag = recurso.idCosto

                Select Case recurso.subtipo
                    Case TipoCosto.Proyecto
                        txtTipoContrato.Text = ""
                    Case TipoCosto.CONTRATOS_DE_CONSTRUCCION
                        txtTipoContrato.Text = "CONTRATOS DE CONSTRUCCION"
                    Case TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                        txtTipoContrato.Text = "CONTRATOS DE ARRENDAMIENTOS"
                    Case TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES
                        txtTipoContrato.Text = "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES"

                    Case TipoCosto.OrdenProduccion
                        txtTipoContrato.Text = ""

                    Case TipoCosto.OP_CONTINUA_DE_BIENES
                        txtTipoContrato.Text = "OP. CONTINUA DE BIENES"
                    Case TipoCosto.OP_CONTINUA_DE_SERVICIOS
                        txtTipoContrato.Text = "OP. CONTINUA DE SERVICIOS"
                    Case TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE
                        txtTipoContrato.Text = "OP. DE BIENES - CONTROL INDEPENDIENTE"
                    Case TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES
                        txtTipoContrato.Text = "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES"
                    Case TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE
                        txtTipoContrato.Text = "OP. DE SERVICIOS - CONTROL INDEPENDIENTE"
                End Select
                Select Case recurso.status
                    Case StatusCosto.Avance_Obra_Cartera
                        txtStatusProyectoGeneral.Text = "En cartera"
                    Case StatusCosto.Culminado
                        txtStatusProyectoGeneral.Text = "Culminado"
                    Case StatusCosto.Proceso
                        txtStatusProyectoGeneral.Text = "En proceso"
                    Case StatusCosto.Suspendido
                        txtStatusProyectoGeneral.Text = "Suspendido"
                End Select


                lblStatus.Text = recurso.status
                lblInicio.Text = recurso.inicio
                lblFinaliza.Text = recurso.finaliza
                ToolStrip4.Enabled = True

                GetPlaneamientoByProyecto(Val(txtProyecto.Tag))

                'If conteo = 0 Then
                '    GetProyectoSelec(New recursoCosto With {.idCosto = txtProyecto.Tag, .nombreCosto = txtProyecto.Text, .director = recurso.director,
                '                                      .inicio = recurso.inicio, .finaliza = recurso.finaliza})

                '    GetProyectoSelec(New recursoCosto With {.idCosto = txtProyecto.Tag, .nombreCosto = txtProyecto.Text, .director = recurso.director,
                '                                 .inicio = recurso.inicio, .finaliza = recurso.finaliza})
                '    conteo += 1
                'Else
                '    GetProyectoSelec(New recursoCosto With {.idCosto = txtProyecto.Tag, .nombreCosto = txtProyecto.Text, .director = recurso.director,
                '                                   .inicio = recurso.inicio, .finaliza = recurso.finaliza})
                'End If

                If recurso.status = StatusCosto.Proceso Then
                    ToolStrip4.Enabled = True
                Else
                    ToolStrip4.Enabled = False
                End If

                'CMBClasificacion()
            Else
                ToolStrip4.Enabled = False
                txtProyecto.Clear()
                txtTipoContrato.Clear()
                lblStatus.Text = String.Empty
                lblInicio.Text = String.Empty
                lblFinaliza.Text = String.Empty
            End If
        Else
            'dgTareas.DataSource = New List(Of RecursoCostoEF)
            grdRecursos.DataSource = New DataTable
            txtProyecto.Clear()
            txtTipoContrato.Clear()
            lblStatus.Text = String.Empty
            lblInicio.Text = String.Empty
            lblFinaliza.Text = String.Empty
            MsgBox("EL codigo de proyecto no existe, o no está en proceso", MsgBoxStyle.Exclamation, "Atención")
        End If


    End Sub

    Public Sub GetProyectosGeneral()
        Dim dt As New DataTable()
        Dim recursoSA As New recursoCostoSA

        dt.Columns.Add("id")
        dt.Columns.Add("nombreProyecto")
        dt.Columns.Add("codigo")
        dt.Columns.Add("status")
        dt.Columns.Add("Inicio")
        dt.Columns.Add("Finaliza")
        dt.Columns.Add("Duracion")
        dt.Columns.Add("Horas")
        dt.Columns.Add("Estado")
        For Each i In recursoSA.GetListaPryectosEnCarteraFull(New recursoCosto With {.tipo = "HC"})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            dr(1) = i.nombreCosto
            dr(2) = i.codigo
            dr(3) = i.status
            dr(4) = i.inicio
            dr(5) = i.finaliza
            dr(6) = 0
            dr(7) = 0
            dr(8) = (i.status)
            dt.Rows.Add(dr)
        Next
        dgvCartera.DataSource = dt
    End Sub

    Public Sub GetProcesos(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA
        lsvProceso.Items.Clear()
        For Each i In costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdCostoPadre})
            Dim n As New ListViewItem(i.idCosto)
            n.SubItems.Add(i.nombreCosto)
            n.SubItems.Add(i.status)
            lsvProceso.Items.Add(n)
        Next
    End Sub

#Region "GRId"
    Dim card As New GridCardView()
    Private Sub Settings()
        card.ShowCardCellBorders = True
        card.ApplyRoundedCorner = False
        card.BrowseOnly = True
        card.ShowCaption = True
        AutoFit()
    End Sub

    Private Sub AutoFit()
        Me.GDBSource.Model.ColWidths.ResizeToFit(GridRangeInfo.Table())
        Me.GDBSource.Refresh()
    End Sub


    Private Sub ComprobanteInfo(intIdDocumento As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        'dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.UbicarDocumentoCompra(intIdDocumento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "COMPRA"
            dr(1) = .fechaDoc
            dr(2) = .tipoDoc
            dr(3) = .serie & "-" & .numeroDoc
            dr(4) = entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto

            If .monedaDoc = "1" Then
                dr(5) = "NAC"
            ElseIf .monedaDoc = "2" Then
                dr(5) = "EXT"
            End If

            dr(6) = .tcDolLoc
            dr(7) = .importeTotal
            dr(8) = 0
            'dr(9) = IIf(.destino = "IC", "Incremento capital", "Saldo de inicio")
            dt.Rows.Add(dr)


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub

    Private Sub ComprobanteInfoLibroDiario(intIdDocumento As Integer)
        Dim compraSA As New documentoLibroDiarioSA
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        'dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.UbicarDocumentoLibroDiario(intIdDocumento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "LIBRO DIARIO"
            dr(1) = .fecha
            dr(2) = .tipoDoc
            dr(3) = .serie & "/" & .nroDoc
            dr(4) = String.Empty ' entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto

            If .moneda = "1" Then
                dr(5) = "NAC"
            ElseIf .moneda = "2" Then
                dr(5) = "EXT"
            End If

            dr(6) = .tipoCambio
            dr(7) = .importeMN
            dr(8) = 0
            'dr(9) = IIf(.destino = "IC", "Incremento capital", "Saldo de inicio")
            dt.Rows.Add(dr)


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub

    Private Sub ComprobanteInfoFinanzas(intIdDocumento As Integer)
        Dim compraSA As New DocumentoCajaSA
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable()
        dt.Columns.Add("Movimiento")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("NroDoc")
        dt.Columns.Add("entidad")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")
        'dt.Columns.Add("destino")
        'dt.Columns.Add("otros")

        With compraSA.GetUbicar_documentoCajaPorID(intIdDocumento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "CAJA"
            dr(1) = .fechaProceso
            dr(2) = .tipoDocPago
            dr(3) = .numeroDoc
            dr(4) = String.Empty ' entidadSA.UbicarEntidadPorID(.idProveedor).FirstOrDefault.nombreCompleto

            If .moneda = "1" Then
                dr(5) = "NAC"
            ElseIf .moneda = "2" Then
                dr(5) = "EXT"
            End If

            dr(6) = .tipoCambio
            dr(7) = .montoSoles
            dr(8) = 0
            'dr(9) = IIf(.destino = "IC", "Incremento capital", "Saldo de inicio")
            dt.Rows.Add(dr)


        End With
        GDBSource.DataSource = dt
        Me.GDBSource.BackColor = Color.White


        card.CaptionField = "Movimiento"
        card.CardSpacingWidth = 10
        card.CardSpacingHeight = 10
        card.MaxCardCols = 5
        card.CaptionHeight = 35
        card.CardBackColor = Color.Lavender
        card.WireGrid(Me.GDBSource)

        Settings()
    End Sub

#End Region

    Private Sub getElementosCosto(be As recursoCosto)
        Dim costoSA As New recursoCostoSA

        cboElementoCosto.DisplayMember = "nombreCosto"
        cboElementoCosto.ValueMember = "idCosto"
        cboElementoCosto.DataSource = costoSA.GetElementosCostoByCosto(be)

    End Sub

    Public Sub GetRecursosAsignadosXCosto(be As recursoCosto)
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)
        recurso = recursoSA.GetListadoRecursosByPadre(be)
        dgvRecursosAsignados.DataSource = recurso 'recursoSA.GetListadoRecursosByIdCosto(be)

        lblTotalCosto.Text = CDec(recurso.Sum(Function(o) o.montoMN)).ToString("N2")

    End Sub


    Public Sub GetRecursosAsignadosXTarea(be As recursoCosto)
        Dim dt As New DataTable
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)

        dt.Columns.Add("secuencia")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importetotal")
        dt.Columns.Add("pu")
        dt.Columns.Add("tipoRecurso")

        recurso = recursoSA.GetRecursosAsignadosByCosto(be)

        For Each i In recurso
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.descripcion
            dr(2) = i.um
            dr(3) = i.cant
            dr(4) = i.montoMN
            If i.cant > 0 Then
                dr(5) = Math.Round(CDec(i.montoMN) / CDec(i.cant), 2)
            Else
                dr(5) = 0
            End If
            dr(6) = i.iditem
            dt.Rows.Add(dr)
        Next

        grdRecursos.DataSource = dt 'recursoSA.GetListadoRecursosByIdCosto(be)

    End Sub

    Public Sub GetRecursosAsignadosPlaneado(be As recursoCostoDetalle)
        Dim dt As New DataTable
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)

        dt.Columns.Add("secuencia")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importetotal")
        dt.Columns.Add("pu")
        dt.Columns.Add("tipoRecurso")
        dt.Columns.Add("edt")

        recurso = recursoSA.GetRecursosAsignadosByTipoCosto(be)

        For Each i In recurso
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.descripcion
            dr(2) = i.um
            dr(3) = i.cant
            dr(4) = i.montoMN
            If i.cant > 0 Then
                dr(5) = Math.Round(CDec(i.montoMN) / CDec(i.cant), 2)
            Else
                dr(5) = 0
            End If
            dr(6) = i.iditem
            dr(7) = i.NomActividad & "-" & i.NombreProceso
            dt.Rows.Add(dr)
        Next

        dgvConsultaPlan.DataSource = dt 'recursoSA.GetListadoRecursosByIdCosto(be)

    End Sub

    Public Sub GetRequerimientosByProyecto(be As recursoCosto)
        Dim dt As New DataTable
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)

        dt.Columns.Add("secuencia")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("tipoRecurso")
        dt.Columns.Add("actividad")
        dt.Columns.Add("fecha")

        recurso = recursoSA.GetRecursosAsignadosByCosto(be)

        For Each i In recurso
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.descripcion
            dr(2) = i.um
            dr(3) = i.cant
            dr(4) = i.iditem
            dr(5) = i.idProceso
            dr(6) = i.fechaRegistro
            dt.Rows.Add(dr)
        Next

        dgvRQ.DataSource = dt 'recursoSA.GetListadoRecursosByIdCosto(be)

    End Sub

    Public Sub GetRecursosAsignadosByProceso(be As recursoCosto)
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)
        recurso = recursoSA.GetListadoRecursosByProceso(be)
        GridGroupingControl1.DataSource = recurso 'recursoSA.GetListadoRecursosByIdCosto(be)

    End Sub

    Function ValidaNotaByReferencia(intIdDocumentoPadre As Integer) As documentocompradetalle
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim compra As New documentocompradetalle
        compra = compraSA.GetUbicar_documentocompradetallePorID(intIdDocumentoPadre)

        Return compra
    End Function

    Sub GridCFG(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

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
        'GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub GetCostoByTipo(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA

        dgvCostos.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})

        Select Case be.subtipo
            Case TipoCosto.Proyecto
                Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Proyectos"
            Case TipoCosto.ActivoFijo
                Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Activos Fijos"
            Case TipoCosto.OrdenProduccion
                Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Orden de producción"
            Case TipoCosto.GastoAdministrativo
                Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Gasto Administrativo"
            Case TipoCosto.GastoVentas
                Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Gasto de ventas"
            Case TipoCosto.GastoFinanciero
                Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Gasto financiero"
        End Select

        dgvCostos.TopLevelGroupOptions.ShowCaption = True
        dgvCostos.TableDescriptor.Relations.Clear()
    End Sub



    Private Sub SumatoriabyCostoTipo(be As recursoCosto)
        Dim recursoSA As New recursoCostoDetalleSA
        bllTotalAcumulado.Text = CDec(recursoSA.GetSumByCosto(be)).ToString("N2")

    End Sub

#End Region

    Private Sub frmMasterCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelMenu.Visible = False
        txtCategoria.ForeColor = Color.Black
        txtCategoria.Tag = Nothing
        CBOConsultas.Enabled = True
        dgvCostos.ShowRowHeaders = False
        TabGeneral.Parent = Nothing
        '  Tab12.Parent = Nothing
        treeViewAdv2.LeftImageList = ImageList1
        treeViewAdv2.Nodes.Clear()

        Dim node As New TreeNodeAdv

        'node = New TreeNodeAdv
        'node.Tag = "Dashboard"
        'node.Text = "Dashboard"
        'node.Font = New Font("Tahoma", 8)
        'node.TextColor = Color.White
        'treeViewAdv2.Nodes.Add(node)

        'node = New TreeNodeAdv
        'node.Tag = "Repositorio"
        'node.Text = "Asignar Recursos"
        'node.Font = New Font("Tahoma", 8)
        'node.TextColor = Color.White
        'treeViewAdv2.Nodes.Add(node)


        'node = New TreeNodeAdv
        'node.Tag = "Elementos"
        'node.Text = "Organizar Procesos"
        'node.Font = New Font("Tahoma", 8)
        'node.TextColor = Color.White
        'treeViewAdv2.Nodes.Add(node)


        Dim nodeGereencia As New TreeNodeAdv
        nodeGereencia.Tag = "gerencia"
        nodeGereencia.Text = "Gerencia de proyectos"
        nodeGereencia.Font = New Font("Tahoma", 8)
        nodeGereencia.TextColor = Color.White
        treeViewAdv2.Nodes.Add(nodeGereencia)

        node = New TreeNodeAdv
        node.Tag = "proceso"
        node.Text = "En proceso"
        node.Font = New Font("Tahoma", 8)
        node.TextColor = Color.White
        nodeGereencia.Nodes.Add(node)

        node = New TreeNodeAdv
        node.Tag = "Suspendidos"
        node.Text = "Suspendidos"
        node.Font = New Font("Tahoma", 8)
        node.TextColor = Color.White
        nodeGereencia.Nodes.Add(node)

        node = New TreeNodeAdv
        node.Tag = "Culminados"
        node.Text = "Culminados"
        node.Font = New Font("Tahoma", 8)
        node.TextColor = Color.White
        nodeGereencia.Nodes.Add(node)

        node = New TreeNodeAdv
        node.Tag = "Cartera"
        node.Text = "En cartera"
        node.Font = New Font("Tahoma", 8)
        node.TextColor = Color.White
        nodeGereencia.Nodes.Add(node)

        node = New TreeNodeAdv
        node.Tag = "Plan"
        node.Text = "Planeamiento"
        node.Font = New Font("Tahoma", 8)
        node.TextColor = Color.White
        treeViewAdv2.Nodes.Add(node)

        node = New TreeNodeAdv
        node.Tag = "Produccion"
        node.Text = "Centro de Costos"
        node.Font = New Font("Tahoma", 8)
        node.TextColor = Color.White
        treeViewAdv2.Nodes.Add(node)

        For Each nodex As TreeNodeAdv In Me.treeViewAdv2.Nodes
            nodex.TextColor = Color.White
            nodex.Font = New Font("Tahoma", 8)
            nodex.LeftImageIndices = New Integer() {nodex.Index}
            'node.RightImageIndices = New Integer() {-1}
        Next nodex

        'treeViewAdv2.BackColor = Color.DarkRed
        treeViewAdv2.BackColor = Color.FromArgb(92, 184, 92)

        TabDashboard.Parent = Nothing
        TabGerencia.Parent = TabContol
        TabPlan.Parent = Nothing
        TabCentroGeneral.Parent = Nothing
        TabProcesos.Parent = Nothing

        lbl.AutoSize = False
        lbl.BackColor = Color.Transparent
        lbl.Dock = DockStyle.Fill
        lbl.ForeColor = Color.Yellow
        lbl.TextAlign = ContentAlignment.MiddleLeft
        'Me.treeViewAdv2.Nodes(3).CustomControl = lbl


        'lblCenter.AutoSize = False
        'lblCenter.BackColor = Color.Transparent
        'lblCenter.Dock = DockStyle.Fill
        'lblCenter.ForeColor = Color.Yellow
        'lblCenter.TextAlign = ContentAlignment.MiddleLeft
        'Me.treeViewAdv2.Nodes(1).CustomControl = lblCenter

    End Sub

    Private Sub SplitButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SplitButton1_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            bllTotalAcumulado.Text = "0.00"
            lblTotalCosto.Text = "0.00"
            dgvRecursosAsignados.DataSource = New List(Of recursoCostoDetalle)
            Select Case e.ClickedItem.Text
                Case "Nuevo proyecto"
                    Dim f As New frmNuevoCosto
                    f.cboTipo.Text = "HOJA DE COSTO"
                    f.cboSubtipo.Text = "PROYECTO"
                    f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                    f.Manipulacion = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case "Ver proyectos"
                    GradientPanel15.Visible = True

                    Label19.Text = "/ Proyectos"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.Proyecto})
            End Select
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SplitButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SplitButton3_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            bllTotalAcumulado.Text = "0.00"
            lblTotalCosto.Text = "0.00"
            dgvRecursosAsignados.DataSource = New List(Of recursoCostoDetalle)
            Select Case e.ClickedItem.Text
                Case "Nuevo activo"
                    Dim f As New frmNuevoCosto
                    f.cboTipo.Text = "HOJA DE COSTO"
                    f.cboSubtipo.Text = "ACTIVO FIJO"
                    f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                    f.Manipulacion = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case "Ver Activos"
                    GradientPanel15.Visible = True
                    Label19.Text = "/ Activos fijos"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.ActivoFijo})
            End Select
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "gerencia"
                GridCFGDetetail(dgvCartera)
                TabDashboard.Parent = Nothing
                TabCentroGeneral.Parent = Nothing
                TabProcesos.Parent = Nothing
                TabGerencia.Parent = TabContol
                TabPlan.Parent = Nothing

            Case "Plan"
                GridCFG(dgvConsultaPlan)
                GridCFGDetetail(grdRecursos)
                GridCFGDetetail(dgvPlaneamiento)
                GridCFGDetetail(dgvRQ)
                'GridCFGDetetail(dgvConsultaPlan)
                TabDashboard.Parent = Nothing
                TabCentroGeneral.Parent = Nothing
                TabProcesos.Parent = Nothing
                TabGerencia.Parent = Nothing
                TabPlan.Parent = TabContol
            Case "Repositorio"
                TabDashboard.Parent = Nothing
                TabCentroGeneral.Parent = Nothing
                TabProcesos.Parent = Nothing
                TabGerencia.Parent = Nothing
                TabPlan.Parent = Nothing
            Case "Produccion"
                GridCFG(dgvCostos)
                GridCFG(dgvRecursosAsignados)
                TabDashboard.Parent = Nothing
                TabProcesos.Parent = Nothing
                TabGerencia.Parent = Nothing
                TabPlan.Parent = Nothing
                TabCentroGeneral.Parent = TabContol
            Case "Dashboard"
                TabDashboard.Parent = Nothing
                TabCentroGeneral.Parent = Nothing
                TabProcesos.Parent = Nothing
                TabGerencia.Parent = Nothing
                TabPlan.Parent = Nothing
            Case "Elementos"
                GridCFG(GridGroupingControl1)
                TabGerencia.Parent = Nothing
                TabPlan.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabCentroGeneral.Parent = Nothing
                TabProcesos.Parent = TabContol

        End Select
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "gerencia"
                GetProyectosGeneral()

            Case "Repositorio"

            Case "Produccion"

            Case "Dashboard"

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCostos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCostos.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement
            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "inicio" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If

                If e.TableCellIdentity.Column.Name = "finaliza" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If

                e.Handled = True
            End If

        End If
    End Sub

    Private Sub dgvCostos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCostos.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor

        If Label19.Text.Contains("Gasto") Then
            GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
        Else
            ' getElementosCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
            GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
        End If

        ' GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue})
        '  sdfsd()

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SplitButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SplitButton2_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            bllTotalAcumulado.Text = "0.00"
            lblTotalCosto.Text = "0.00"
            dgvRecursosAsignados.DataSource = New List(Of recursoCostoDetalle)
            Select Case e.ClickedItem.Text
                Case "Nueva orden"
                    Dim f As New frmNuevoCosto
                    f.cboTipo.Text = "HOJA DE COSTO"
                    f.cboSubtipo.Text = "ORDEN DE PRODUCCION"
                    f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                    f.Manipulacion = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case "Listado de ordenes"
                    GradientPanel15.Visible = True
                    Label19.Text = "/ Ordenes de Producción"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OrdenProduccion})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.OrdenProduccion})
            End Select
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles btEdit.Click
        If TabContol.SelectedTab Is TabCentroGeneral Then
            If Not IsNothing(dgvCostos.Table.CurrentRecord) Then
                Dim f As New frmNuevoCosto
                f.UbicarCostoById(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                f.Manipulacion = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        ElseIf TabContol.SelectedTab Is TabProcesos Then
            If lsvProceso.SelectedItems.Count > 0 Then
                Dim f As New frmNuevoproceso
                f.IdCostoPadre = cboCosto.SelectedValue
                f.UbicarCosto(Val(lsvProceso.SelectedItems(0).SubItems(0).Text))
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar un proceso válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub SplitButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SplitButton4_DropDowItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            bllTotalAcumulado.Text = "0.00"
            lblTotalCosto.Text = "0.00"
            dgvRecursosAsignados.DataSource = New List(Of recursoCostoDetalle)
            Select Case e.ClickedItem.Text
                Case "Nuevo Gasto"
                    Dim f As New frmNuevoCosto

                    f.cboSubtipo.Items.Clear()
                    f.cboSubtipo.Items.Add("GASTO ADMINISTRATIVO")
                    f.cboSubtipo.Items.Add("GASTO DE VENTAS")
                    f.cboSubtipo.Items.Add("GASTO FINANCIERO")
                    f.cboTipo.Text = "HOJA DE GASTO"
                    f.cboSubtipo.Text = "GASTO ADMINISTRATIVO"
                    f.cboSubtipo.Enabled = True
                    f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "94"})
                    f.Manipulacion = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case "Gasto Administrativo"
                    GradientPanel15.Visible = False
                    Label19.Text = "/ Gasto Administrativo"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.GastoAdministrativo})
                Case "Gasto de ventas"
                    GradientPanel15.Visible = False
                    Label19.Text = "/ Gasto de ventas"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.GastoVentas})
                Case "Gasto financiero"
                    GradientPanel15.Visible = False
                    Label19.Text = "/ Gasto financiero"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.GastoFinanciero})
            End Select
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvRecursosAsignados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvRecursosAsignados.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvRecursosAsignados.Table.CurrentRecord) Then
            Select Case dgvRecursosAsignados.Table.CurrentRecord.GetValue("operacion")
                Case "02", "8"
                    ComprobanteInfo(Val(dgvRecursosAsignados.Table.CurrentRecord.GetValue("documentoRef")))
                Case "9923"
                    ComprobanteInfoLibroDiario(Val(dgvRecursosAsignados.Table.CurrentRecord.GetValue("documentoRef")))
                Case "1"
                    ComprobanteInfoFinanzas(Val(dgvRecursosAsignados.Table.CurrentRecord.GetValue("documentoRef")))
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboElementoCosto_Click(sender As Object, e As EventArgs) Handles cboElementoCosto.Click

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        'Me.Cursor = Cursors.WaitCursor
        'GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue})
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cbotipo_Click(sender As Object, e As EventArgs) Handles cbotipo.Click

    End Sub

    Public Sub GetCostoByTipoCMBServicios(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        cboCosto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})

        cboCosto.DisplayMember = "nombreCosto"
        cboCosto.ValueMember = "idCosto"
    End Sub

    Private Sub cbotipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotipo.SelectedIndexChanged
        cboCosto.DataSource = Nothing

        Dim codValue = cbotipo.Text
        '  If IsNumeric(codValue) Then
        Select Case codValue
            Case "PROYECTO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
            Case "ORDEN DE PRODUCCION"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OrdenProduccion})
            Case "ACTIVO FIJO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})
            Case "GASTO ADMINISTRATIVO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
            Case "GASTO DE VENTAS"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
            Case "GASTO FINANCIERO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})
        End Select
        'End If
        cboCosto.SelectedIndex = -1
    End Sub



    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        GetProcesos(cboCosto.SelectedValue)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btUpadte.Click
        Me.Cursor = Cursors.WaitCursor
        If TabContol.SelectedTab Is TabProcesos Then
            GetProcesos(cboCosto.SelectedValue)
        ElseIf TabContol.SelectedTab Is TabCentroGeneral Then
            bllTotalAcumulado.Text = "0.00"
            lblTotalCosto.Text = "0.00"
            dgvCostos.DataSource = New List(Of recursoCosto)
            dgvRecursosAsignados.DataSource = New List(Of recursoCostoDetalle)
            Select Case CBOConsultas.Text
                Case "CONTRATOS DE CONSTRUCCION"
                    GradientPanel15.Visible = True

                    Label19.Text = "/ Contratos de construcción"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.Proyecto})

                Case "ORDEN DE PRODUCCION"
                    GradientPanel15.Visible = True
                    Label19.Text = "/ Ordenes de Producción"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OrdenProduccion})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.OrdenProduccion})

                Case "ACTIVO FIJO"
                    GradientPanel15.Visible = True
                    Label19.Text = "/ Activos fijos"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.ActivoFijo})

                Case "GASTO ADMINISTRATIVO"
                    GradientPanel15.Visible = False
                    Label19.Text = "/ Gasto Administrativo"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.GastoAdministrativo})

                Case "GASTO DE VENTAS"
                    GradientPanel15.Visible = False
                    Label19.Text = "/ Gasto de ventas"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.GastoVentas})

                Case "GASTO FINANCIERO"
                    GradientPanel15.Visible = False
                    Label19.Text = "/ Gasto financiero"
                    GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})
                    If dgvCostos.Table.Records.Count > 0 Then
                        dgvCostos.Table.Records(0).SetCurrent()
                        dgvCostos.Table.Records(0).SetSelected(True)
                        GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    End If
                    SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.GastoFinanciero})

            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProceso.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If lsvProceso.SelectedItems.Count > 0 Then
            GetRecursosAsignadosByProceso(New recursoCosto With {.idCosto = lsvProceso.SelectedItems(0).SubItems(0).Text})
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub eliminarProceso(intIdCosto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim detSA As New recursoCostoDetalleSA
        Try
            Dim result = detSA.GetCountItemsByProceso(New recursoCosto With {.idCosto = intIdCosto})
            If result > 0 Then
                MessageBox.Show("No puede eliminar el proceso, contiene recursos asignados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            costoSA.EliminarCosto(New recursoCosto With {.idCosto = intIdCosto})
            MessageBox.Show("Proceso eliminado!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lsvProceso.Items.Remove(lsvProceso.SelectedItems(0))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto
        If TabContol.SelectedTab Is TabProcesos Then
            eliminarProceso(Val(lsvProceso.SelectedItems(0).SubItems(0).Text))
        ElseIf TabContol.SelectedTab Is TabCentroGeneral Then
            If Not IsNothing(dgvCostos.Table.CurrentRecord) Then
                If MessageBox.Show("Desea eliminar el costo seleccionado", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                    If Not IsNothing(costo) Then
                        If costo.status = StatusCosto.Culminado Then
                            MessageBox.Show("Debe quitar el cierre del costo, si desea eliminarlo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        Else
                            costoSA.EliminarCostoPadre(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                            dgvCostos.Table.CurrentRecord.Delete()
                            MessageBox.Show("Costo eliminado correctamente", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboCosto_Click(sender As Object, e As EventArgs) Handles cboCosto.Click

    End Sub
    Sub EliminarAssign()
        Dim obj As New recursoCostoDetalle
        Dim objSA As New recursoCostoDetalleSA

        obj = New recursoCostoDetalle
        obj.idProceso = Nothing
        obj.secuencia = CInt(GridGroupingControl1.Table.CurrentRecord.GetValue("secuencia"))
        objSA.CambioAsigancion(obj)
        If lsvProceso.SelectedItems.Count > 0 Then
            GetRecursosAsignadosByProceso(New recursoCosto With {.idCosto = lsvProceso.SelectedItems(0).SubItems(0).Text})
        End If
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(GridGroupingControl1.Table.CurrentRecord) Then
            Dim f As New frmModalCambioCosto(Val(lsvProceso.SelectedItems(0).SubItems(0).Text))
            f.IdSecuencia = GridGroupingControl1.Table.CurrentRecord.GetValue("secuencia")
            f.StartPosition = FormStartPosition.CenterParent
            f.cbotipo.Enabled = False
            f.ShowDialog()
            lsvProceso_SelectedIndexChanged(sender, e)
        Else
            MessageBox.Show("Debe seleccionar un item válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        If MessageBox.Show("Desea quitar la asignación del recurso seleccionado ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            EliminarAssign()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If cboCosto.Text.Trim.Length > 1 Then
            Dim f As New frmNuevoproceso()
            f.IdCostoPadre = cboCosto.SelectedValue
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar costo válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCosto.Select()
            cboCosto.DroppedDown = True
        End If

    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim asientoSA As New AsientoSA

        If Not IsNothing(dgvRecursosAsignados.Table.CurrentRecord) Then
            If MessageBox.Show("Va quitar la asignación del recurso seleccionado." & vbCrLf & _
                           "Nota: Se eliminarán todos los servicios asignados del comprobante", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                asientoSA.EliminarAsientoCostos(New asiento With {.idDocumento = Val(dgvRecursosAsignados.Table.CurrentRecord.GetValue("documentoRef")),
                                                                  .codigoLibro = dgvRecursosAsignados.Table.CurrentRecord.GetValue("operacion")})

                MessageBox.Show("Recursos liberados de asignación!." & vbCrLf & _
                                "Puede verificar en contabilidad, alertas de recursos x asignar.", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})

            End If
        Else
            MessageBox.Show("Debe seleccionar un recurso válido!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvCostos.Table.CurrentRecord) Then

            costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})

            Select Case costo.subtipo
                Case TipoCosto.Proyecto, _
                    TipoCosto.CONTRATOS_DE_CONSTRUCCION, _
                    TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS, _
                    TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES, _
                    TipoCosto.ActivoFijo
                    Select Case costo.status
                        Case StatusCosto.Culminado
                            MessageBox.Show("El costo seleccionado ya fue cerrado, intente en otra ocasión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        Case Else
                            Dim f As New frminfocierreCosto(Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto")))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                    End Select


                Case TipoCosto.OrdenProduccion, _
                    TipoCosto.OP_CONTINUA_DE_BIENES, _
                    TipoCosto.OP_CONTINUA_DE_SERVICIOS, _
                    TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE, _
                    TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES, _
                    TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE
                    Select Case costo.status
                        Case StatusCosto.Culminado
                            MessageBox.Show("El costo seleccionado ya fue cerrado, intente en otra ocasión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        Case Else
                            Dim f As New frminfocierreProduccion(Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto")))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                    End Select
            End Select


        Else
            MessageBox.Show("Debe indicar un costo para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto


        Try
            If Not IsNothing(dgvCostos.Table.CurrentRecord) Then

                Select Case CBOConsultas.Text
                    Case "CONTRATOS DE CONSTRUCCION"
                        If MessageBox.Show("Desea eliminar el cierre del costo? ", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            costo = New recursoCosto
                            costo.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))
                            costo.status = StatusCosto.Avance_Obra_Cartera

                            costoSA.GetEliminarCierreCosto(costo)
                            MessageBox.Show("Status de costo cambiado a en proceso y/o avance de obra", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case "ORDEN DE PRODUCCION"

                        If MessageBox.Show("Desea eliminar el cierre de la orden de producción? ", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            costo = New recursoCosto
                            costo.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))
                            costo.status = StatusCosto.Proceso

                            costoSA.GetEliminarCierreProduccion(costo)
                            MessageBox.Show("Status de la orden cambiado a en proceso y/o avance de obra", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Case "ACTIVO FIJO"


                End Select


            Else
                MessageBox.Show("Debe indicar un costo para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CBOConsultas_Click(sender As Object, e As EventArgs) Handles CBOConsultas.Click

    End Sub

    'Private Sub Model_QueryCellInfo(sender As Object, e As GridQueryCellInfoEventArgs)


    '    Dim model As GridModel = Me.dgTareas.Model

    '    Dim ColIndex As Integer = Me.dgTareas.Model.NameToColIndex("CheckBox")

    '    If e.RowIndex > 0 AndAlso e.ColIndex = ColIndex Then


    '        'Sets up a CheckBox control.

    '        e.Style.CellType = "CheckBox"

    '        e.Style.HorizontalAlignment = GridHorizontalAlignment.Center

    '        e.Style.VerticalAlignment = GridVerticalAlignment.Middle

    '        e.Style.CellValueType = GetType(Boolean)



    '        'Determines the Checked and Unchecked values of CheckBox.

    '        e.Style.CheckBoxOptions.CheckedValue = "True"

    '        e.Style.CheckBoxOptions.UncheckedValue = "False"

    '        e.Style.Enabled = True

    '        Dim keyColIndex As Integer = model.NameToColIndex("Product_ID")

    '        Dim key As String = model(e.RowIndex, keyColIndex).Text

    '        If key IsNot Nothing Then


    '            Dim value As Object = CheckBoxValues(key)



    '            'Displays the value in checkbox.

    '            If value IsNot Nothing Then

    '                e.Style.CellValue = value

    '            End If

    '        End If
    '    End If

    'End Sub

    Private Sub CBOConsultas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOConsultas.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        bllTotalAcumulado.Text = "0.00"
        lblTotalCosto.Text = "0.00"
        dgvCostos.DataSource = New List(Of recursoCosto)
        dgvRecursosAsignados.DataSource = New List(Of recursoCostoDetalle)
        Select Case CBOConsultas.Text
            Case "CONTRATOS DE CONSTRUCCION"
                GradientPanel15.Visible = True

                Label19.Text = "/ Contratos de construcción"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.CONTRATOS_DE_CONSTRUCCION})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.CONTRATOS_DE_CONSTRUCCION})

            Case "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES"

                GradientPanel15.Visible = True

                Label19.Text = "/ Contratos de servicios por valorizaciones o similares"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES})

            Case "CONTRATOS DE ARRENDAMIENTOS"

                GradientPanel15.Visible = True

                Label19.Text = "/ Contratos de arrendamintos"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS})


            Case "OP. CONTINUA DE BIENES"
                GradientPanel15.Visible = True
                Label19.Text = "/ Ordenes de Producción"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_CONTINUA_DE_BIENES})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.OP_CONTINUA_DE_BIENES})


            Case "OP. DE BIENES - CONTROL INDEPENDIENTE"
                GradientPanel15.Visible = True
                Label19.Text = "/ Ordenes de Producción"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE})

            Case "OP. CONTINUA DE SERVICIOS"
                GradientPanel15.Visible = True
                Label19.Text = "/ Ordenes de Producción"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_CONTINUA_DE_SERVICIOS})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.OP_CONTINUA_DE_SERVICIOS})

            Case "OP. DE SERVICIOS - CONTROL INDEPENDIENTE"
                GradientPanel15.Visible = True
                Label19.Text = "/ Ordenes de Producción"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE})

            Case "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES"
                GradientPanel15.Visible = True
                Label19.Text = "/ Ordenes de Producción"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES})

                'Case "ORDEN DE PRODUCCION"


            Case "ACTIVO FIJO"
                GradientPanel15.Visible = True
                Label19.Text = "/ Activos fijos"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.ActivoFijo})

            Case "GASTO ADMINISTRATIVO"
                GradientPanel15.Visible = False
                Label19.Text = "/ Gasto Administrativo"
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.GastoAdministrativo})

            Case "GASTO DE VENTAS"
                GradientPanel15.Visible = False
                Label19.Text = "/ Gasto de ventas"
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.GastoVentas})

            Case "GASTO FINANCIERO"
                GradientPanel15.Visible = False
                Label19.Text = "/ Gasto financiero"
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})
                If dgvCostos.Table.Records.Count > 0 Then
                    dgvCostos.Table.Records(0).SetCurrent()
                    dgvCostos.Table.Records(0).SetSelected(True)
                    GetRecursosAsignadosXCosto(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If
                SumatoriabyCostoTipo(New recursoCosto With {.subtipo = TipoCosto.GastoFinanciero})

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Select Case CBOConsultas.Text
            Case "CONTRATOS DE CONSTRUCCION"
                Dim f As New frmNuevoCosto
                f.cboTipo.Text = "HOJA DE COSTO"
                f.cboSubtipo.Text = "CONTRATOS DE CONSTRUCCION"
                f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                f.Manipulacion = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            Case "ORDEN DE PRODUCCION"

                With frmNuevoCosto
                    .cboTipo.Text = "HOJA DE COSTO"
                    .cboSubtipo.Text = "ORDEN DE PRODUCCION"
                    .GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                    .Manipulacion = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With


                'Dim f As New frmNuevoCosto
                'f.cboTipo.Text = "HOJA DE COSTO"
                'f.cboSubtipo.Text = "ORDEN DE PRODUCCION"
                'f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                'f.Manipulacion = ENTITY_ACTIONS.INSERT
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()

            Case "ACTIVO FIJO"
                Dim f As New frmNuevoCosto
                f.cboTipo.Text = "HOJA DE COSTO"
                f.cboSubtipo.Text = "ACTIVO FIJO"
                f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
                f.Manipulacion = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            Case "GASTO ADMINISTRATIVO", "GASTO DE VENTAS", "GASTO FINANCIERO"
                Dim f As New frmNuevoCosto
                f.cboSubtipo.Items.Clear()
                f.cboSubtipo.Items.Add("GASTO ADMINISTRATIVO")
                f.cboSubtipo.Items.Add("GASTO DE VENTAS")
                f.cboSubtipo.Items.Add("GASTO FINANCIERO")
                f.cboTipo.Text = "HOJA DE GASTO"
                f.cboSubtipo.Text = "GASTO ADMINISTRATIVO"
                f.cboSubtipo.Enabled = True
                f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "94"})
                f.Manipulacion = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

        End Select
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCodigoProyecto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoProyecto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCodigoProyecto.Text.Trim.Length > 0 Then
                getProyectoByCodigo(New recursoCosto With {.codigo = txtCodigoProyecto.Text.Trim})
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Dim conteo As Integer = 0

    Private Sub dgTareas_CellClick(sender As Object, e As GridCellClickEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If MetodosGenericos.GetCellValue(dgTareas, "Tipo") = "ACT" Then
        '    txtActividadActual.Text = MetodosGenericos.GetCellValue(dgTareas, "FirstName")
        '    txtActividadActual.Tag = MetodosGenericos.GetCellValue(dgTareas, "ID")
        '    GetRecursosAsignadosXTarea(New recursoCosto With {.idCosto = txtActividadActual.Tag})
        'Else
        '    grdRecursos.DataSource = New DataTable
        '    txtActividadActual.Text = String.Empty
        '    txtActividadActual.Tag = String.Empty
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown
        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        'Else
        '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '    Me.pcLikeCategoria.Size = New Size(241, 110)
        '    Me.pcLikeCategoria.ParentControl = Me.txtCategoria
        '    Me.pcLikeCategoria.ShowPopup(Point.Empty)
        '    Dim consulta = (From n In listaCategoria _
        '             Where n.descripcion.StartsWith(txtCategoria.Text)).ToList

        '    lsvCategoria.DataSource = consulta
        '    lsvCategoria.DisplayMember = "descripcion"
        '    lsvCategoria.ValueMember = "idItem"
        '    'e.Handled = True
        'End If

        ''  If Not Me.pcLikeCategoria.IsShowing() Then

        ''   End If

        ''    If Not Me.pcLikeCategoria.IsShowing() Then
        'If e.KeyCode = Keys.Down Then
        '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '    Me.pcLikeCategoria.Size = New Size(241, 110)
        '    Me.pcLikeCategoria.ParentControl = Me.txtCategoria
        '    Me.pcLikeCategoria.ShowPopup(Point.Empty)
        '    lsvCategoria.Focus()
        'End If
        ''   End If

        '' e.SuppressKeyPress = True
        'If e.KeyCode = Keys.Escape Then
        '    If Me.pcLikeCategoria.IsShowing() Then
        '        Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
        '    End If
        'End If
    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged
        'txtCategoria.ForeColor = Color.Black
        'txtCategoria.Tag = Nothing
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtCategoria.Text = lsvCategoria.Text
                txtCategoria.Tag = lsvCategoria.SelectedValue
                txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub grdRecursos_CellClick(sender As Object, e As GridCellClickEventArgs)

    End Sub

    Private Sub grdRecursos_CurrentCellEditingComplete(sender As Object, e As EventArgs)

    End Sub

    Private Sub grdRecursos_CurrentCellKeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            'Dim position As Integer = Me.grdRecursos.Binder.RowIndexToPosition(e.r)



        End If
    End Sub

    Private Sub grdRecursos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles grdRecursos.TableControlCellClick

    End Sub

    Private Sub grdRecursos_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles grdRecursos.TableControlCurrentCellCloseDropDown

        Dim recursoDet As New recursoCostoDetalle
        Dim recursoDetSA As New recursoCostoDetalleSA

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim r As Record = grdRecursos.Table.CurrentRecord
        If Not IsNothing(r) Then
            recursoDet = New recursoCostoDetalle
            recursoDet.secuencia = Val(r.GetValue("secuencia"))
            recursoDet.descripcion = r.GetValue("descripcion")
            recursoDet.um = r.GetValue("um")
            recursoDet.cant = CDec(r.GetValue("cantidad"))
            recursoDet.montoMN = CDec(r.GetValue("importetotal"))
            recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))

            recursoDetSA.EditarDetalleRecursoTareaBySecuencia(recursoDet)
        End If

    End Sub

    Private Sub grdRecursos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles grdRecursos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim recursoDet As New recursoCostoDetalle
        Dim recursoSA As New recursoCostoDetalleSA
        Dim colMonto As Decimal = 0
        If Not IsNothing(Me.grdRecursos.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 6
                    grdRecursos.TableControl.CurrentCell.EndEdit()
                    grdRecursos.TableControl.Table.TableDirty = True
                    grdRecursos.TableControl.Table.EndEdit()


                    Dim r As Record = grdRecursos.Table.CurrentRecord

                    colMonto = Math.Round(CDec(r.GetValue("cantidad")) * CDec(r.GetValue("pu")), 2)

                    recursoDet = New recursoCostoDetalle
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.montoMN = colMonto
                    r.SetValue("importetotal", colMonto)
                    recursoSA.EditarDetalleRecursoTareaBySecuencia(recursoDet)
                Case 3
                    grdRecursos.TableControl.CurrentCell.EndEdit()
                    grdRecursos.TableControl.Table.TableDirty = True
                    grdRecursos.TableControl.Table.EndEdit()


                    Dim r As Record = grdRecursos.Table.CurrentRecord

                    colMonto = Math.Round(CDec(r.GetValue("cantidad")) * CDec(r.GetValue("pu")), 2)

                    recursoDet = New recursoCostoDetalle
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.montoMN = colMonto
                    r.SetValue("importetotal", colMonto)
                    recursoSA.EditarDetalleRecursoTareaBySecuencia(recursoDet)
                Case 5
                    grdRecursos.TableControl.CurrentCell.EndEdit()
                    grdRecursos.TableControl.Table.TableDirty = True
                    grdRecursos.TableControl.Table.EndEdit()


                    Dim r As Record = grdRecursos.Table.CurrentRecord

                    colMonto = Math.Round(CDec(r.GetValue("cantidad")) * CDec(r.GetValue("pu")), 2)

                    recursoDet = New recursoCostoDetalle
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.montoMN = colMonto
                    r.SetValue("importetotal", colMonto)
                    recursoSA.EditarDetalleRecursoTareaBySecuencia(recursoDet)

            End Select
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim datos As List(Of item) = item.Instance()
        datos.Clear()

        Dim f As New frmNuevaClasificacion
        f.txtDescripcion.Text = txtCategoria.Text
        txtCategoria.Clear()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        'CMBClasificacion()
        If datos.Count > 0 Then
            txtCategoria.Text = datos(0).descripcion
            txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCategoria.Tag = CInt(datos(0).idItem)
        End If
    End Sub

    Private Sub ButtonAdv1_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        ' If txtCategoria.Text.Trim.Length > 0 Then
        If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
            'If txtCategoria.ForeColor = Color.Black Then
            '    MessageBox.Show("Verificar el ingreso correcto de la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtCategoria.Select()
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If
            GrabarRecurso()
            txtCategoria.Clear()
            txtCategoria.Focus()
            txtCategoria.Select()
        Else
            MessageBox.Show("Debe seleccionar una actividad para asignar un recurso", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If Not IsNothing(grdRecursos.Table.CurrentRecord) Then
            Dim costoSA As New recursoCostoDetalleSA

            costoSA.EliminarDetalleCostoPlan(New recursoCostoDetalle With {.secuencia = Val(grdRecursos.Table.CurrentRecord.GetValue("secuencia"))})
            grdRecursos.Table.CurrentRecord.Delete()
            MessageBox.Show("Recurso quitado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Debe seleccionar un recurso válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        'Select Case MetodosGenericos.GetCellValue(dgTareas, "Tipo")
        '    Case "PRC"
        '        If txtProyecto.Text.Trim.Length > 0 Then
        '            Dim f As New frmNuevoproceso
        '            'f.IdCostoPadre = cboCosto.SelectedValue
        '            f.UbicarCosto(Val(MetodosGenericos.GetCellValue(dgTareas, "ID")))
        '            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        '            f.StartPosition = FormStartPosition.CenterParent
        '            f.ShowDialog()
        '            GetProyectoSelec(New recursoCosto With {.idCosto = txtProyecto.Tag, .nombreCosto = txtProyecto.Text, .director = 0,
        '                                                    .inicio = lblInicio.Text, .finaliza = lblFinaliza.Text})
        '        Else
        '            MessageBox.Show("Debe seleccionar un proyecto válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End If

        '    Case "ACT"
        '        If txtProyecto.Text.Trim.Length > 0 Then
        '            Dim f As New frmTarea(MetodosGenericos.GetCellValue(dgTareas, "ID"))
        '            f.idProyecto = txtProyecto.Tag
        '            f.Manipulacion = ENTITY_ACTIONS.UPDATE
        '            f.StartPosition = FormStartPosition.CenterParent
        '            f.LimitarFechaPadre(Val(txtProyecto.Tag))
        '            f.ShowDialog()
        '            GetProyectoSelec(New recursoCosto With {.idCosto = txtProyecto.Tag, .nombreCosto = txtProyecto.Text, .director = 0,
        '                                                    .inicio = lblInicio.Text, .finaliza = lblFinaliza.Text})
        '        Else
        '            MessageBox.Show("Debe seleccionar un proyecto válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End If
        'End Select


    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        
    End Sub

    Private Sub NuevaTareaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NuevaTareaToolStripMenuItem.Click
        If txtProyecto.Text.Trim.Length > 0 Then


            If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
                Dim f As New frmTarea
                f.idProyecto = dgvPlaneamiento.Table.CurrentRecord.GetValue("idProceso")
                f.Manipulacion = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.LimitarFechaPadre(Val(txtProyecto.Tag))
                f.ShowDialog()
                GetPlaneamiento2(txtProyecto.Tag)

            End If
            'If MetodosGenericos.GetCellValue(dgTareas, "Tipo") = "PRC" Then
            '    Dim f As New frmTarea
            '    f.idProyecto = MetodosGenericos.GetCellValue(dgTareas, "ID") 'txtProyecto.Tag
            '    f.Manipulacion = ENTITY_ACTIONS.INSERT
            '    f.StartPosition = FormStartPosition.CenterParent
            '    f.LimitarFechaPadre(Val(txtProyecto.Tag))
            '    f.ShowDialog()
            '    GetProyectoSelec(New recursoCosto With {.idCosto = txtProyecto.Tag, .nombreCosto = txtProyecto.Text, .director = 0,
            '                                            .inicio = lblInicio.Text, .finaliza = lblFinaliza.Text})

            'Else
            '    MessageBox.Show("Debe seleccionar un proceso válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If

        Else
            MessageBox.Show("Debe seleccionar un proyecto válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub NuevoProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoProcesoToolStripMenuItem.Click
        Dim f As New frmNuevoproceso()
        f.IdCostoPadre = (txtProyecto.Tag) '= MetodosGenericos.GetCellValue(dgTareas, "ID")
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        GetPlaneamiento2(txtProyecto.Tag)
        'GetProyectoSelec(New recursoCosto With {.idCosto = txtProyecto.Tag, .nombreCosto = txtProyecto.Text, .director = 0,
        '                                              .inicio = lblInicio.Text, .finaliza = lblFinaliza.Text})
    End Sub

    Private Sub dgvCartera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCartera.TableControlCellClick

    End Sub

    Private Sub dgvCartera_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCartera.TableControlCurrentCellCloseDropDown
        Dim recSA As New recursoCostoSA

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        recSA.EditarStatusCostoByID(New recursoCosto With {.idCosto = dgvCartera.Table.CurrentRecord.GetValue("id"),
                                                           .status = dgvCartera.Table.CurrentRecord.GetValue("Estado")})

    End Sub

    Private Sub rbHojaCosto_CheckChanged(sender As Object, e As EventArgs) Handles rbHojaCosto.CheckChanged
        If rbHojaCosto.Checked = True Then
            Label29.Text = "Asignar recursos (Elmento del costo)"
            cboElemento.Visible = True
            GetCostoByTipoCMBServicios1(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
        End If
    End Sub

#Region "Proyectos"

    'Public Sub RegistrarItemsAsignados()
    '    Dim obj As New recursoCostoDetalle
    '    Dim Lista As New List(Of recursoCostoDetalle)
    '    Dim costoSA As New recursoCostoDetalleSA
    '    Dim codigoCosto As Integer
    '    Dim listaAsiento As New List(Of asiento)
    '    Dim objAsiento As New asiento
    '    Dim objMovimiento As New movimiento
    '    Dim recursoSA As New recursoCostoSA
    '    Dim recurso As New recursoCosto
    '    Dim objDetalleCompra As New documentocompradetalle
    '    Try

    '        Lista = New List(Of recursoCostoDetalle)
    '        listaAsiento = New List(Of asiento)

    '        If rbHojaCosto.Checked = True Then
    '            codigoCosto = cboElemento.SelectedValue
    '        ElseIf rbHojaGasto.Checked = True Then
    '            codigoCosto = cboCostoDestino.SelectedValue
    '        End If


    '        For Each i As SelectedRecord In dgvItemsNoasignados.Table.SelectedRecords

    '            objDetalleCompra = New documentocompradetalle

    '            Select Case i.Record.GetValue("TipoDoc")
    '                Case "07" 'NOTA DE CREDITO
    '                    objDetalleCompra = ValidaNotaByReferencia(dgvItemsNoasignados.Table.CurrentRecord.GetValue("idPadreDTCompra"))

    '                    If IsNothing(obj) Then
    '                        Throw New Exception("Debe asignar primero el comprobante padre!")
    '                    End If

    '                Case Else

    '            End Select


    '            objAsiento = New asiento
    '            objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
    '            objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
    '            objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
    '            objAsiento.idDocumentoRef = Nothing
    '            objAsiento.idAlmacen = 0
    '            objAsiento.nombreAlmacen = String.Empty
    '            objAsiento.idEntidad = String.Empty
    '            objAsiento.nombreEntidad = String.Empty
    '            objAsiento.tipoEntidad = String.Empty
    '            objAsiento.fechaProceso = DateTime.Now
    '            objAsiento.codigoLibro = "8"
    '            objAsiento.tipo = "D"
    '            objAsiento.tipoAsiento = "ACCA"
    '            objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
    '            objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


    '            objAsiento.glosa = "Ingreso a centro de costo"
    '            objAsiento.usuarioActualizacion = usuario.IDUsuario
    '            objAsiento.fechaActualizacion = DateTime.Now


    '            Select Case txtTipoCosto.Text
    '                Case TipoCosto.Proyecto
    '                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = cboElemento.SelectedValue})

    '                    Select Case i.Record.GetValue("TipoDoc")
    '                        Case "07" 'NOTA DE CREDITO

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = "791",
    '                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
    '                                .tipo = "D",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                            objMovimiento = New movimiento With {
    '                              .cuenta = recurso.codigo,
    '                              .descripcion = recurso.nombreCosto,
    '                              .tipo = "H",
    '                              .monto = CDec(i.Record.GetValue("montokardex")),
    '                              .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                              .usuarioActualizacion = usuario.IDUsuario,
    '                              .fechaActualizacion = DateTime.Now
    '                          }
    '                            objAsiento.movimiento.Add(objMovimiento)


    '                        Case Else

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = recurso.codigo,
    '                                .descripcion = recurso.nombreCosto,
    '                                .tipo = "D",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = "791",
    '                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
    '                                .tipo = "H",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                    End Select
    '                    listaAsiento.Add(objAsiento)

    '                Case TipoCosto.OrdenProduccion

    '                    Select Case i.Record.GetValue("TipoDoc")
    '                        Case "07" 'NOTA DE CREDITO

    '                            objMovimiento = New movimiento With {
    '                              .cuenta = "7111",
    '                              .descripcion = "PRODUCTOS MANUFACTURADOS",
    '                              .tipo = "D",
    '                              .monto = CDec(i.Record.GetValue("montokardex")),
    '                              .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                              .usuarioActualizacion = usuario.IDUsuario,
    '                              .fechaActualizacion = DateTime.Now
    '                          }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                            objMovimiento = New movimiento With {
    '                               .cuenta = "231",
    '                               .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
    '                               .tipo = "H",
    '                               .monto = CDec(i.Record.GetValue("montokardex")),
    '                               .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                               .usuarioActualizacion = usuario.IDUsuario,
    '                               .fechaActualizacion = DateTime.Now
    '                           }
    '                            objAsiento.movimiento.Add(objMovimiento)



    '                        Case Else

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = "231",
    '                                .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
    '                                .tipo = "D",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = "7111",
    '                                .descripcion = "PRODUCTOS MANUFACTURADOS",
    '                                .tipo = "H",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                    End Select

    '                    listaAsiento.Add(objAsiento)

    '                Case TipoCosto.ActivoFijo
    '                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = cboElemento.SelectedValue})
    '                    Select Case i.Record.GetValue("TipoDoc")
    '                        Case "07" 'NOTA DE CREDITO

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = "7225",
    '                                .descripcion = "EQUIPOS DIVERSOS",
    '                                .tipo = "D",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = recurso.codigo,
    '                                .descripcion = recurso.nombreCosto,
    '                                .tipo = "H",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)


    '                        Case Else

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = recurso.codigo,
    '                                .descripcion = recurso.nombreCosto,
    '                                .tipo = "D",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = "7225",
    '                                .descripcion = "EQUIPOS DIVERSOS",
    '                                .tipo = "H",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                    End Select

    '                    listaAsiento.Add(objAsiento)

    '                Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero
    '                    recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = cboCostoDestino.SelectedValue})


    '                    Select Case i.Record.GetValue("TipoDoc")
    '                        Case "07" 'NOTA DE CREDITO
    '                            objMovimiento = New movimiento With {
    '                                .cuenta = "791",
    '                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
    '                                .tipo = "D",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)


    '                            objMovimiento = New movimiento With {
    '                                .cuenta = recurso.codigo,
    '                                .descripcion = recurso.nombreCosto,
    '                                .tipo = "H",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                        Case Else

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = recurso.codigo,
    '                                .descripcion = recurso.nombreCosto,
    '                                .tipo = "D",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)

    '                            objMovimiento = New movimiento With {
    '                                .cuenta = "791",
    '                                .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
    '                                .tipo = "H",
    '                                .monto = CDec(i.Record.GetValue("montokardex")),
    '                                .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
    '                                .usuarioActualizacion = usuario.IDUsuario,
    '                                .fechaActualizacion = DateTime.Now
    '                            }
    '                            objAsiento.movimiento.Add(objMovimiento)
    '                    End Select



    '                    listaAsiento.Add(objAsiento)
    '            End Select



    '            Select Case i.Record.GetValue("TipoDoc")
    '                Case "07" 'NOTA DE CREDITO
    '                    obj = New recursoCostoDetalle With {
    '                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
    '                        .idCosto = codigoCosto,
    '                        .iditem = Val(i.Record.GetValue("idItem")),
    '                        .destino = i.Record.GetValue("destino"),
    '                        .descripcion = i.Record.GetValue("descripcionItem"),
    '                        .um = i.Record.GetValue("unidad1"),
    '                        .cant = CDec(i.Record.GetValue("monto1")),
    '                        .puMN = 0,
    '                        .puME = 0,
    '                        .montoMN = CDec(i.Record.GetValue("montokardex")) * -1,
    '                        .montoME = CDec(i.Record.GetValue("montokardexUS")) * -1,
    '                        .documentoRef = i.Record.GetValue("idDocumento"),
    '                        .itemRef = i.Record.GetValue("secuencia"),
    '                        .operacion = i.Record.GetValue("TipoOperacion"),
    '                        .idProceso = cboProceso.SelectedValue,
    '                        .procesado = "N",
    '                        .recursoCosto = New recursoCosto With
    '                                        {
    '                                            .subtipo = cboIdentCosto.Text
    '                                        }
    '                    }
    '                    Lista.Add(obj)

    '                Case Else


    '                    obj = New recursoCostoDetalle With {
    '                        .idCosto = codigoCosto,
    '                        .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
    '                        .iditem = Val(i.Record.GetValue("idItem")),
    '                        .destino = i.Record.GetValue("destino"),
    '                        .descripcion = i.Record.GetValue("descripcionItem"),
    '                        .um = i.Record.GetValue("unidad1"),
    '                        .cant = CDec(i.Record.GetValue("monto1")),
    '                        .puMN = 0,
    '                        .puME = 0,
    '                        .montoMN = CDec(i.Record.GetValue("montokardex")),
    '                        .montoME = CDec(i.Record.GetValue("montokardexUS")),
    '                        .documentoRef = i.Record.GetValue("idDocumento"),
    '                        .itemRef = i.Record.GetValue("secuencia"),
    '                        .operacion = i.Record.GetValue("TipoOperacion"),
    '                        .procesado = "N",
    '                        .idProceso = cboProceso.SelectedValue,
    '                    .recursoCosto = New recursoCosto With
    '                                    {
    '                    .subtipo = cboIdentCosto.Text
    '                                    }
    '                    }
    '                    Lista.Add(obj)
    '            End Select
    '        Next
    '        costoSA.GrabarDetalleRecursos(Lista, listaAsiento)
    '        'GetItemsNoAsignados()
    '        MessageBoxAdv.Show("Recursos asignados")
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try


    'End Sub

    Sub ComboProcesos1(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA

        cboProceso.DataSource = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdCostoPadre})
        cboProceso.ValueMember = "idCosto"
        cboProceso.DisplayMember = "nombreCosto"
    End Sub

    Public Sub GetCostoByTipoCMBServicios1(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        cboCostoDestino.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})

        cboCostoDestino.DisplayMember = "nombreCosto"
        cboCostoDestino.ValueMember = "idCosto"
    End Sub
#End Region

    Private Sub rbHojaGasto_CheckChanged(sender As Object, e As EventArgs) Handles rbHojaGasto.CheckChanged
        If rbHojaGasto.Checked = True Then
            Label29.Text = "Asignar recursos"
            cboElemento.Visible = False

        End If
    End Sub

    Private Sub cboCostoDestino_Click(sender As Object, e As EventArgs) Handles cboCostoDestino.Click

    End Sub

    Private Sub cboCostoDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCostoDestino.SelectedIndexChanged
        cboElemento.DataSource = Nothing
        cboProceso.DataSource = Nothing
        If cboCostoDestino.SelectedIndex > -1 Then
            If rbHojaCosto.Checked = True Then
                Dim recursoSA As New recursoCostoSA

                Dim codValue = cboCostoDestino.SelectedValue
                codValue = Val(codValue)

                If IsNumeric(codValue) Then
                    cboElemento.Visible = True

                    cboElemento.DisplayMember = "nombreCosto"
                    cboElemento.ValueMember = "idCosto"
                    cboElemento.DataSource = recursoSA.GetElementosCostoByCosto(New recursoCosto With {.idCosto = codValue})

                    ComboProcesos1(codValue)

                End If
            End If
        End If
        cboElemento.SelectedIndex = -1
        cboProceso.SelectedIndex = -1
    End Sub

    Private Sub GradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel2.Paint

    End Sub

    Private Sub ButtonAdv11_Click(sender As Object, e As EventArgs) Handles ButtonAdv11.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvItemsNoasignados.Table.Records.Count > 0 Then
            If dgvItemsNoasignados.Table.SelectedRecords.Count > 0 Then

                If cboCostoDestino.Text.Trim.Length > 0 Then
                    If cboProceso.Text.Trim.Length > 0 Then
                        '   RegistrarItemsAsignados()
                        'GetCountItemsNoAsignados()
                    Else
                        MessageBox.Show("Debe seleccionar el proceso de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe seleccionar el destino de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel40_Paint(sender As Object, e As PaintEventArgs) Handles Panel40.Paint

    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Me.Cursor = Cursors.WaitCursor
        With frmNuevoCosto
            .cboTipo.Text = "HOJA DE COSTO"
            .cboSubtipo.Text = "CONTRATOS DE CONSTRUCCION"
            .cboSubtipo.Enabled = True
            .GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
            .Manipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton9_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvCartera.Table.CurrentRecord) Then
            Dim f As New frmNuevoCosto
            f.UbicarCostoById(New recursoCosto With {.idCosto = Val(dgvCartera.Table.CurrentRecord.GetValue("id"))})
            f.Manipulacion = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto
        If Not IsNothing(dgvCartera.Table.CurrentRecord) Then
            If MessageBox.Show("Desea eliminar el costo seleccionado", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = Val(dgvCartera.Table.CurrentRecord.GetValue("id"))})
                If Not IsNothing(costo) Then
                    If costo.status = StatusCosto.Culminado Then
                        MessageBox.Show("Debe quitar el cierre del costo, si desea eliminarlo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Else
                        costoSA.EliminarCostoPadre(New recursoCosto With {.idCosto = Val(dgvCartera.Table.CurrentRecord.GetValue("id"))})
                        dgvCartera.Table.CurrentRecord.Delete()
                        MessageBox.Show("Costo eliminado correctamente", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Me.Cursor = Cursors.WaitCursor
        GetProyectosGeneral()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor

        If txtCodigoProyecto.Text.Trim.Length > 0 Then
            '    getProyectoByCodigo(New recursoCosto With {.codigo = txtCodigoProyecto.Text.Trim})
            GetPlaneamiento2(txtProyecto.Tag)
        Else
            txtCodigoProyecto.Focus()
            txtCodigoProyecto.SelectAll()
            MessageBox.Show("Debe ingresar un código de proyecto válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCodigoProyecto_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoProyecto.TextChanged

    End Sub

    Sub ConteoRecursos()
        Dim detSA As New recursoCostoDetalleSA
        lsvPlaneado.Items.Clear()

        For Each i In detSA.GetRecursoPlaneadoConteo(New recursoCosto With {.idCosto = Val(txtProyecto.Tag), .procesado = "PL"})
            Dim n As New ListViewItem(i.descripcion)
            n.SubItems.Add(i.cant)
            lsvPlaneado.Items.Add(n)
        Next

        lsvEjecutado.Items.Clear()
        For Each i In detSA.GetRecursoPlaneadoConteo(New recursoCosto With {.idCosto = Val(txtProyecto.Tag), .procesado = "RQ"})
            Dim n As New ListViewItem(i.descripcion)
            n.SubItems.Add(i.cant)
            lsvEjecutado.Items.Add(n)
        Next


    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA

        If TabControl1.SelectedIndex = 1 Then
            '  MsgBox("Correcto")
            Dim ggcStyle As GridTableCellStyleInfo = dgvRQ.TableDescriptor.Columns("actividad").Appearance.AnyRecordFieldCell
            ggcStyle.CellType = "ComboBox"
            ggcStyle.DataSource = costoSA.GetActividadProcesoByProyecto(New recursoCosto With {.idCosto = Val(txtProyecto.Tag)})
            ggcStyle.ValueMember = "idCosto"
            ggcStyle.DisplayMember = "nombreCosto"
            ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
            ConteoRecursos()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        ' If txtCategoria.Text.Trim.Length > 0 Then
        If txtProyecto.Text.Trim.Length > 0 Then
            'If txtCategoria.ForeColor = Color.Black Then
            '    MessageBox.Show("Verificar el ingreso correcto de la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtCategoria.Select()
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If
            GrabarRQ()
            ConteoRecursos()
            GetRequerimientosByProyecto(New recursoCosto With {.idCosto = txtProyecto.Tag})
            txtRecursoRequerimiento.Clear()
            txtRecursoRequerimiento.Focus()
            txtRecursoRequerimiento.Select()
        Else
            MessageBox.Show("Debe indicar un proyecto válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub dgvRQ_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvRQ.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            '    If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then


            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "fecha" Then
                    e.Style.Format = "dd/MM/yyyy h:mm:ss tt"
                End If
                e.Handled = True
            End If

            '  End If

        End If
    End Sub

    Private Sub dgvRQ_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvRQ.TableControlCellClick

    End Sub

    Private Sub dgvRQ_TableControlCurrentCellActivating(sender As Object, e As GridTableControlCurrentCellActivatingEventArgs) Handles dgvRQ.TableControlCurrentCellActivating

    End Sub

    Private Sub dgvRQ_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvRQ.TableControlCurrentCellCloseDropDown
        Dim recursoDet As New recursoCostoDetalle
        Dim recursoDetSA As New recursoCostoDetalleSA

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        Dim r As Record = dgvRQ.Table.CurrentRecord

        If Not IsNothing(r) Then
            recursoDet = New recursoCostoDetalle
            recursoDet.secuencia = Val(r.GetValue("secuencia"))
            recursoDet.descripcion = r.GetValue("descripcion")
            recursoDet.um = r.GetValue("um")
            recursoDet.cant = CDec(r.GetValue("cantidad"))
            recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))

            Dim f = r.GetValue("actividad")
            If f.ToString.Trim.Length > 0 Then
                recursoDet.idProceso = CInt(r.GetValue("actividad"))
            Else
                recursoDet.idProceso = Nothing
            End If

            Dim fec = r.GetValue("fecha")
            If IsDate(fec) Then
                r.SetValue("fecha", Convert.ToDateTime(fec))
                recursoDet.fechaRegistro = Convert.ToDateTime(fec)
            Else
                r.SetValue("fecha", DateTime.Now)
                recursoDet.fechaRegistro = DateTime.Now
            End If

            recursoDetSA.EditarRequerimeintoBySec(recursoDet)
        End If

   
    End Sub

    Private Sub dgvRQ_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvRQ.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim recursoDet As New recursoCostoDetalle
        Dim recursoSA As New recursoCostoDetalleSA
        Dim colMonto As Decimal = 0
        If Not IsNothing(Me.dgvRQ.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 5
                    dgvRQ.TableControl.CurrentCell.EndEdit()
                    dgvRQ.TableControl.Table.TableDirty = True
                    dgvRQ.TableControl.Table.EndEdit()


                    Dim r As Record = dgvRQ.Table.CurrentRecord

                    recursoDet = New recursoCostoDetalle
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    Dim f = r.GetValue("actividad")
                    If f.ToString.Trim.Length > 0 Then
                        recursoDet.idProceso = CInt(r.GetValue("actividad"))
                    Else
                        recursoDet.idProceso = Nothing
                    End If

                    Dim fec = r.GetValue("fecha")
                    If IsDate(fec) Then
                        r.SetValue("fecha", Convert.ToDateTime(fec))
                        recursoDet.fechaRegistro = Convert.ToDateTime(fec)
                    Else
                        r.SetValue("fecha", DateTime.Now)
                        recursoDet.fechaRegistro = DateTime.Now
                    End If

                    recursoSA.EditarRequerimeintoBySec(recursoDet)
                Case 3

                    dgvRQ.TableControl.CurrentCell.EndEdit()
                    dgvRQ.TableControl.Table.TableDirty = True
                    dgvRQ.TableControl.Table.EndEdit()


                    Dim r As Record = dgvRQ.Table.CurrentRecord

                    recursoDet = New recursoCostoDetalle
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    Dim f = r.GetValue("actividad")
                    If f.ToString.Trim.Length > 0 Then
                        recursoDet.idProceso = CInt(r.GetValue("actividad"))
                    Else
                        recursoDet.idProceso = Nothing
                    End If

                    Dim fec = r.GetValue("fecha")
                    If IsDate(fec) Then
                        r.SetValue("fecha", Convert.ToDateTime(fec))
                        recursoDet.fechaRegistro = Convert.ToDateTime(fec)
                    Else
                        r.SetValue("fecha", DateTime.Now)
                        recursoDet.fechaRegistro = DateTime.Now
                    End If

                    recursoSA.EditarRequerimeintoBySec(recursoDet)
                Case 6
                    dgvRQ.TableControl.CurrentCell.EndEdit()
                    dgvRQ.TableControl.Table.TableDirty = True
                    dgvRQ.TableControl.Table.EndEdit()


                    Dim r As Record = dgvRQ.Table.CurrentRecord

                    recursoDet = New recursoCostoDetalle
                    recursoDet.secuencia = Val(r.GetValue("secuencia"))
                    recursoDet.descripcion = r.GetValue("descripcion")
                    recursoDet.um = r.GetValue("um")
                    recursoDet.cant = CDec(r.GetValue("cantidad"))
                    recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                    Dim f = r.GetValue("actividad")
                    If f.ToString.Trim.Length > 0 Then
                        recursoDet.idProceso = CInt(r.GetValue("actividad"))
                    Else
                        recursoDet.idProceso = Nothing
                    End If

                    Dim fec = r.GetValue("fecha")
                    If IsDate(fec) Then
                        r.SetValue("fecha", Convert.ToDateTime(fec))
                        recursoDet.fechaRegistro = Convert.ToDateTime(fec)
                    Else
                        r.SetValue("fecha", DateTime.Now)
                        recursoDet.fechaRegistro = DateTime.Now
                    End If

                    recursoSA.EditarRequerimeintoBySec(recursoDet)
                Case 7
                    dgvRQ.TableControl.CurrentCell.EndEdit()
                    dgvRQ.TableControl.Table.TableDirty = True
                    dgvRQ.TableControl.Table.EndEdit()

                    Dim r As Record = dgvRQ.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        recursoDet = New recursoCostoDetalle
                        recursoDet.secuencia = Val(r.GetValue("secuencia"))
                        recursoDet.descripcion = r.GetValue("descripcion")
                        recursoDet.um = r.GetValue("um")
                        recursoDet.cant = CDec(r.GetValue("cantidad"))
                        recursoDet.iditem = CInt(r.GetValue("tipoRecurso"))
                        Dim f = r.GetValue("actividad")
                        If f.ToString.Trim.Length > 0 Then
                            recursoDet.idProceso = CInt(r.GetValue("actividad"))
                        Else
                            recursoDet.idProceso = Nothing
                        End If

                        Dim fec = r.GetValue("fecha")
                        If IsDate(fec) Then
                            r.SetValue("fecha", Convert.ToDateTime(fec))
                            recursoDet.fechaRegistro = Convert.ToDateTime(fec)
                        Else
                            r.SetValue("fecha", DateTime.Now)
                            recursoDet.fechaRegistro = DateTime.Now
                        End If

                        recursoSA.EditarRequerimeintoBySec(recursoDet)
                    End If

            End Select
        End If
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        Me.Cursor = Cursors.WaitCursor
        GetRequerimientosByProyecto(New recursoCosto With {.idCosto = txtProyecto.Tag})
        ConteoRecursos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If Not IsNothing(dgvRQ.Table.CurrentRecord) Then
            Dim costoSA As New recursoCostoDetalleSA

            costoSA.EliminarDetalleCostoPlan(New recursoCostoDetalle With {.secuencia = Val(dgvRQ.Table.CurrentRecord.GetValue("secuencia"))})
            dgvRQ.Table.CurrentRecord.Delete()
            ConteoRecursos()
            MessageBox.Show("Recurso quitado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Debe seleccionar un recurso válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Me.Cursor = Cursors.WaitCursor

        Select Case cboConsultarPlaneado.Text
            Case "INVENTARIO"
                GetRecursosAsignadosPlaneado(New recursoCostoDetalle With {.idCosto = txtProyecto.Tag, .tipoCosto = "PL", .iditem = TipoRecursoPlaneado.Inventario})
            Case "MANO DE OBRA"
                GetRecursosAsignadosPlaneado(New recursoCostoDetalle With {.idCosto = txtProyecto.Tag, .tipoCosto = "PL", .iditem = TipoRecursoPlaneado.ManoDeObra})
            Case "ACTIVOS INMOVILIZADOS"
                GetRecursosAsignadosPlaneado(New recursoCostoDetalle With {.idCosto = txtProyecto.Tag, .tipoCosto = "PL", .iditem = TipoRecursoPlaneado.ActivoInmovilizado})
            Case "TERCEROS"
                GetRecursosAsignadosPlaneado(New recursoCostoDetalle With {.idCosto = txtProyecto.Tag, .tipoCosto = "PL", .iditem = TipoRecursoPlaneado.Terceros})
        End Select


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvConsultaPlan_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvConsultaPlan.SelectedRecordsChanged
        If Not IsNothing(dgvConsultaPlan.Table.CurrentRecord) Then
            cboTipoRQ.Text = cboConsultarPlaneado.Text
            txtRecursoRequerimiento.Text = dgvConsultaPlan.Table.CurrentRecord.GetValue("descripcion")
            txtRecursoRequerimiento.Focus()
            txtRecursoRequerimiento.SelectAll()
        End If
    End Sub

    Private Sub dgvConsultaPlan_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvConsultaPlan.TableControlCellClick

    End Sub

    Private Sub dgvPlaneamiento_QueryCoveredRange(sender As Object, e As GridTableQueryCoveredRangeEventArgs)
        Dim thisTable As GridTable = Me.dgvPlaneamiento.Table
        If e.RowIndex < thisTable.DisplayElements.Count Then
            Dim el As Element = thisTable.DisplayElements(e.RowIndex)

            Select Case el.Kind
                Case DisplayElementKind.Caption
                    If True Then
                        ' Cover some cells of the caption bar (specified with captionCover)
                        Dim gs As IGridGroupOptionsSource = TryCast(el.ParentGroup, IGridGroupOptionsSource)
                        If gs IsNot Nothing AndAlso gs.GroupOptions.ShowCaptionSummaryCells Then
                            Dim startCol As Integer = el.GroupLevel + 1
                            If Not gs.GroupOptions.ShowCaptionPlusMinus Then
                                startCol -= 1
                            End If
                            If e.ColIndex >= startCol AndAlso e.ColIndex <= startCol + Me.captionCoverCols Then
                                e.Range = GridRangeInfo.Cells(e.RowIndex, startCol, e.RowIndex, startCol + Me.captionCoverCols)
                                e.Handled = True
                            End If
                        End If
                        Exit Select

                    End If
            End Select
        End If
    End Sub


    Private Sub EditarProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarProcesoToolStripMenuItem.Click
        If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
            If txtProyecto.Text.Trim.Length > 0 Then
                Dim f As New frmNuevoproceso
                'f.IdCostoPadre = cboCosto.SelectedValue
                f.UbicarCosto(Val(dgvPlaneamiento.Table.CurrentRecord.GetValue("idProceso")))
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GetPlaneamiento2(txtProyecto.Tag)
            Else
                MessageBox.Show("Debe seleccionar un proyecto válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un EDT. válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        
    End Sub

    Private Sub EditarActividadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarActividadToolStripMenuItem.Click
        If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
            If txtProyecto.Text.Trim.Length > 0 Then

                Dim nomacti = dgvPlaneamiento.Table.CurrentRecord.GetValue("nomActividad")
                If nomacti.ToString.Trim.Length > 0 Then
                    Dim f As New frmTarea(dgvPlaneamiento.Table.CurrentRecord.GetValue("idActividad"), txtProyecto.Tag)
                    f.idProyecto = txtProyecto.Tag
                    f.Manipulacion = ENTITY_ACTIONS.UPDATE
                    f.StartPosition = FormStartPosition.CenterParent
                    f.LimitarFechaPadre(Val(txtProyecto.Tag))
                    f.ShowDialog()
                    GetPlaneamiento2(txtProyecto.Tag)
                Else
                    MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

              
            Else
                MessageBox.Show("Debe seleccionar un proyecto válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar una actividad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub EliminarProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarProcesoToolStripMenuItem.Click
        If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
            Dim recursoSA As New recursoCostoSA
            Dim recursoDetalleSA As New recursoCostoDetalleSA
            Try
                If MessageBox.Show("Desea eliminar el proceso seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim codProceso As Integer = dgvPlaneamiento.Table.CurrentRecord.GetValue("idProceso")
                    recursoSA.EliminarProcesos(New recursoCosto With {.idCosto = codProceso})
                    GetPlaneamiento2(txtProyecto.Tag)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub EliminarActividadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarActividadToolStripMenuItem.Click
        If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
            Dim recursoSA As New recursoCostoSA
            Dim recursoDetalleSA As New recursoCostoDetalleSA
            Try
                Dim nomacti = dgvPlaneamiento.Table.CurrentRecord.GetValue("nomActividad")
                If nomacti.ToString.Trim.Length > 0 Then
                    If MessageBox.Show("Desea eliminar la actividad seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Dim codTarea As Integer = dgvPlaneamiento.Table.CurrentRecord.GetValue("idActividad")
                        recursoDetalleSA.EliminarCostoDetalleBySec(New recursoCostoDetalle With {.idCosto = codTarea})
                        GetPlaneamiento2(txtProyecto.Tag)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgvPlaneamiento_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPlaneamiento.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            '    If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then


            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "inicio" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If
                '  e.Handled = True
            End If

            If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
                If e.TableCellIdentity.Column.Name = "finaliza" Then
                    e.Style.Format = "dd/MM/yyyy"
                End If
                '  e.Handled = True
            End If

            '  End If

        End If
    End Sub

    Private Sub dgvPlaneamiento_TableControlCellClick_1(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPlaneamiento.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvPlaneamiento.Table.CurrentRecord) Then
            Dim actividad = dgvPlaneamiento.Table.CurrentRecord.GetValue("nomActividad")
            If actividad.ToString.Trim.Length > 0 Then
                txtActividadActual.Text = dgvPlaneamiento.Table.CurrentRecord.GetValue("nomActividad") ' MetodosGenericos.GetCellValue(dgTareas, "FirstName")
                txtActividadActual.Tag = dgvPlaneamiento.Table.CurrentRecord.GetValue("idActividad")
                GetRecursosAsignadosXTarea(New recursoCosto With {.idCosto = txtActividadActual.Tag})
            Else
                grdRecursos.DataSource = New DataTable
                txtActividadActual.Text = String.Empty
                txtActividadActual.Tag = String.Empty
            End If
        Else
            grdRecursos.DataSource = New DataTable
            txtActividadActual.Text = String.Empty
            txtActividadActual.Tag = String.Empty
        End If

        'If MetodosGenericos.GetCellValue(dgTareas, "Tipo") = "ACT" Then
        '    txtActividadActual.Text = MetodosGenericos.GetCellValue(dgTareas, "FirstName")
        '    txtActividadActual.Tag = MetodosGenericos.GetCellValue(dgTareas, "ID")
        '    GetRecursosAsignadosXTarea(New recursoCosto With {.idCosto = txtActividadActual.Tag})
        'Else
        '    grdRecursos.DataSource = New DataTable
        '    txtActividadActual.Text = String.Empty
        '    txtActividadActual.Tag = String.Empty
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub
End Class