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
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing

Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmPresupuestoMaestro
    Inherits frmMaster

#Region "Métodos"
    Public Sub GrabarEDT()
        Dim costo As New recursoCosto
        Dim proceso As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        costo = New recursoCosto
        costo.idpadre = cboProductoTerminado.SelectedValue
        costo.tipo = "PRC"
        costo.subtipo = "PRC"
        costo.nombreCosto = txtNUevoEDT.Text.Trim
        costo.codigo = String.Empty
        costo.detalle = txtNUevoEDT.Text.Trim
        costo.subdetalle = String.Empty
        costo.inicio = Nothing
        costo.finaliza = Nothing
        costo.procesado = "N"
        costo.usuarioActualizacion = usuario.IDUsuario
        costo.fechaActualizacion = DateTime.Now

        recursoSA.GrabarCostoOne(costo)
        MessageBox.Show("EDT grabado!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtNUevoEDT.Clear()
        txtNUevoEDT.Select()
        GetEstimacionEDT()
        'Dispose()
    End Sub

    Sub GetEntregables()
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)


        costo = costoSA.GetProductosTerminadosByProyecto(New recursoCosto With {.idCosto = cboSubProyecto.SelectedValue})
        cboProductoTerminado.DisplayMember = "nombreCosto"
        cboProductoTerminado.ValueMember = "idCosto"
        cboProductoTerminado.DataSource = costo
        'For Each i In costo
        '    dt.Rows.Add(i.idCosto, i.secuenciaCosto, i.nombreCosto, i.finaliza.GetValueOrDefault, i.finalizaActual.GetValueOrDefault, _
        '                i.tipoExistencia, i.UnidadMedida, i.cantidad, 0, 0, i.cantidad, i.costoCierre.GetValueOrDefault, 0, 0)
        'Next
        'dgvEntregables.DataSource = dt
    End Sub

    Public Sub GetRecursosAsignadosXTarea(be As recursoCosto)
        Dim dt As New DataTable
        Dim recursoSA As New recursoCostoDetalleSA
        Dim recurso As New List(Of recursoCostoDetalle)

        grdRecursos.TableDescriptor.Columns("tipocosto").Width = 0

        dt.Columns.Add("secuencia")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importetotal")
        dt.Columns.Add("pu")
        dt.Columns.Add("tipoRecurso")
        dt.Columns.Add("tipocosto")

        recurso = recursoSA.GetRecursosAsignadosByProceso(be)

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
            dr(7) = If(i.tipoCosto = "RL", "Real", "Planeado")
            dt.Rows.Add(dr)
        Next

        grdRecursos.DataSource = dt 'recursoSA.GetListadoRecursosByIdCosto(be)
        grdRecursos.TableDescriptor.GroupedColumns.Clear()
        grdRecursos.TableDescriptor.GroupedColumns.Add("tipocosto")
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

    Sub GetEstimacionEDT()
        Dim costoSA As New recursoCostoSA
        Dim listaCosto As New List(Of recursoCosto)
        Dim dt As New DataTable("Orders")

        dt.Columns.Add("idProceso")
        dt.Columns.Add("nomProceso")
        dt.Columns.Add("idActividad")
        dt.Columns.Add("nomActividad")
        dt.Columns.Add("costo")
        dt.Columns.Add("costoReal")
        dt.Columns.Add("sec")


        listaCosto = costoSA.GetPlaneamientoEDT_Produccion(New recursoCosto With {.idCosto = cboProductoTerminado.SelectedValue})
        Dim listaCosto2 = (From n In listaCosto _
                          Order By n.SecuenciaTrabajoProceso Ascending, n.secuenciaCosto Ascending).ToList


        For Each i In listaCosto2
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.IdProceso
            dr(1) = i.NomProceso
            dr(2) = 0 'i.IdActividad
            If IsNothing(i.NomActividad) Then
                dr(3) = String.Empty
            Else
                dr(3) = i.NomActividad
            End If
            dr(4) = i.CostoPresupuesto
            dr(5) = i.CostoReal
            dr(6) = i.secuenciaCosto
            dt.Rows.Add(dr)
        Next
        dgvEstimacionRec.DataSource = dt
        Me.dgvEstimacionRec.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation Or GridMergeCellsMode.MergeRowsInColumn
        Me.dgvEstimacionRec.TableDescriptor.Columns("nomProceso").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.RowsInColumn
        'Me.dgvEstimacionRec.TableDescriptor.Columns("nomProceso").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.Both
        'Me.dgvEstimacionRec.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation
        ''Sets the range of cells.
        'Me.dgvEstimacionRec.TableModel.Options.MergeCellsLayout = GridMergeCellsLayout.Grid
    End Sub

    Sub CMBEstatus()
        Dim tablaSA As New tablaDetalleSA

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


        Dim tabla As New List(Of tabladetalle)
        tabla = tablaSA.GetListaTablaDetalle(6, "1").OrderBy(Function(o) o.descripcion).ToList

        Dim ggcStyle2 As GridTableCellStyleInfo = grdRecursos.TableDescriptor.Columns("um").Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = tabla
        ggcStyle2.ValueMember = "codigoDetalle"
        ggcStyle2.DisplayMember = "descripcion"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive


        Dim ggcStyle3 As GridTableCellStyleInfo = grdRecursos.TableDescriptor.Columns("tipoRecurso").Appearance.AnyRecordFieldCell
        ggcStyle3.CellType = "ComboBox"
        ggcStyle3.DataSource = dtTipo
        ggcStyle3.ValueMember = "codigo"
        ggcStyle3.DisplayMember = "descripcion"
        ggcStyle3.DropDownStyle = GridDropDownStyle.Exclusive


    End Sub

    Public Sub GetSubProyectos(idProyectoGeneral As Integer)
        Dim dt As New DataTable()
        Dim recursoSA As New recursoCostoSA
        'idCosto
        'nombreCosto
        cboSubProyecto.DisplayMember = "nombreCosto"
        cboSubProyecto.ValueMember = "idCosto"
        cboSubProyecto.DataSource = recursoSA.GetListaProyectosBySubTipo(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral, .subtipo = TipoCosto.OP_CONTINUA_DE_BIENES,
                                                                                                .status = StatusProductosTerminados.Pendiente})

        ''cboSubProyecto.DisplayMember = "nombreCosto"
        ''cboSubProyecto.ValueMember = "idCosto"
        ''cboSubProyecto.DataSource = recursoSA.GetListaProtectosByProyGeneral(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral})
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvEstimacionRec)
        GridCFGDetetail(grdRecursos)
        GetSubProyectos(ProyectoGeneralSel.idCosto)
    End Sub

    Private Sub frmPresupuestoMaestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        CMBEstatus()
        grdRecursos.DataSource = New DataTable
        GetEstimacionEDT()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim costo As New recursoCosto
        Dim costoSA As New recursoCostoSA

        'Validando el presupuesto del producto terminado
        costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboProductoTerminado.SelectedValue})

        Select Case costo.presupuesto
            Case StatusPresupestoProyecto.Abierto
                Dim prodTerminado = cboProductoTerminado.Text
                If prodTerminado.ToString.Trim.Length > 0 Then
                    Dim r As Record = dgvEstimacionRec.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        Dim f As New frmPresupuestoProduccion(Val(r.GetValue("idProceso")), cboSubProyecto.SelectedValue, cboProductoTerminado.SelectedValue)
                        f.txtActividadActual.Text = r.GetValue("nomProceso")
                        f.txtActividadActual.Tag = r.GetValue("idProceso")
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                    Else
                        MessageBox.Show("Debe identificar el EDT", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe identificar el producto terminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case StatusPresupestoProyecto.Cerrado
                MessageBox.Show("Debe Abrir el presupuesto del producto terminado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '   Exit Sub
        End Select





        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEstimacionRec_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEstimacionRec.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvEstimacionRec.Table.CurrentRecord

        If Not IsNothing(r) Then
            Dim actividad = dgvEstimacionRec.Table.CurrentRecord.GetValue("nomActividad")
            'If actividad.ToString.Trim.Length > 0 Then
            CMBEstatus()
            grdRecursos.DataSource = New DataTable
            GetRecursosAsignadosXTarea(New recursoCosto With {.IdProceso = Val(r.GetValue("idProceso"))})
            grdRecursos.Table.ExpandAllRecords()
            'Else
            '    grdRecursos.DataSource = New DataTable
            'End If
        Else
            grdRecursos.DataSource = New DataTable
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If Not IsNothing(grdRecursos.Table.CurrentRecord) Then
            Dim costoSA As New recursoCostoDetalleSA

            costoSA.EliminarDetalleCostoPlan(New recursoCostoDetalle With {.secuencia = Val(grdRecursos.Table.CurrentRecord.GetValue("secuencia"))})
            grdRecursos.Table.CurrentRecord.Delete()
            MessageBox.Show("Recurso quitado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Debe seleccionar un recurso válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                Case 7
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
                Case 4
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

            End Select
        End If
    End Sub

    Private Sub cboSubProyecto_Click(sender As Object, e As EventArgs) Handles cboSubProyecto.Click

    End Sub

    Private Sub cboSubProyecto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubProyecto.SelectedIndexChanged
        dgvEstimacionRec.DataSource = New DataTable

        GetEntregables()
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        Me.Cursor = Cursors.WaitCursor
        ' Dim r As Record = dgvCartera.Table.CurrentRecord
        'If Not IsNothing(r) Then

        Dim prodTerminado = cboProductoTerminado.Text
        If prodTerminado.ToString.Trim.Length > 0 Then
            If txtNUevoEDT.Text.Trim.Length > 0 Then
                GrabarEDT()
                'If Not IsNothing(r) Then
                '    GetPlaneamiento(CInt(r.GetValue("id")))
                'End If
            Else
                MessageBox.Show("Debe indicar el nombre del EDT", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe indicar el producto terminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboProductoTerminado_Click(sender As Object, e As EventArgs) Handles cboProductoTerminado.Click

    End Sub

    Private Sub cboProductoTerminado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboProductoTerminado.SelectedValueChanged
        grdRecursos.DataSource = New DataTable
        dgvEstimacionRec.DataSource = New DataTable
        'Me.Cursor = Cursors.WaitCursor
        'Dim codProdTer = cboProductoTerminado.SelectedValue
        'If Not IsNothing(codProdTer) Then
        '    If IsNumeric(codProdTer) Then
        '        CMBEstatus()
        '        grdRecursos.DataSource = New DataTable
        '        GetEstimacionEDT()
        '    End If
        'End If
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub GradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel2.Paint

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

    End Sub
End Class