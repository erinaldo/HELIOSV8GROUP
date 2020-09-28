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
Public Class frmCrearPaquetesTrabajo
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFGDetetail(dgvCartera)
        GetProyectosGeneralesCMB()
        '   GetProyectosGeneral()
        CMBEstatus()
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

    Private Sub GetProyectosGeneralesCMB()
        Dim costoSA As New recursoCostoSA
        cboProyGeneral.DisplayMember = "nombreCosto"
        cboProyGeneral.ValueMember = "idCosto"
        cboProyGeneral.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})
    End Sub

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


        dgvCartera.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        'dgvCartera.ShowRowHeaders = False
    End Sub

    Public Sub GetProyectosGeneral(idProyectoGeneral As Integer)
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
        For Each i In recursoSA.GetListaProtectosByProyGeneral(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            dr(1) = i.nombreCosto
            dr(2) = i.codigo
            Select Case i.status
                Case StatusCosto.Avance_Obra_Cartera
                    dr(3) = "En cartera"
                Case StatusCosto.Culminado
                    dr(3) = "Culminado"
                Case StatusCosto.Proceso
                    dr(3) = "En Proceso"
                Case StatusCosto.Suspendido
                    dr(3) = "Suspendido"
            End Select

            dr(4) = i.inicio
            dr(5) = i.finaliza
            dr(6) = 0
            dr(7) = 0
            dr(8) = (i.status)
            dt.Rows.Add(dr)
        Next
        dgvCartera.DataSource = dt
    End Sub

    Private Sub frmCrearPaquetesTrabajo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub dgvCartera_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCartera.TableControlCurrentCellCloseDropDown
        Dim recSA As New recursoCostoSA

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        recSA.EditarStatusCostoByID(New recursoCosto With {.idCosto = dgvCartera.Table.CurrentRecord.GetValue("id"),
                                                           .status = dgvCartera.Table.CurrentRecord.GetValue("Estado")})

    End Sub

    Private Sub frmCrearPaquetesTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvCartera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCartera.TableControlCellClick

    End Sub

    Private Sub dgvCartera_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCartera.TableControlCellDoubleClick
      
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmNuevoCosto
            .IdProyectoGeneral = cboProyGeneral.SelectedValue
            .cboTipo.Text = "HOJA DE COSTO"
            .cboSubtipo.Text = "HC - CONSTRUC. Y SIMILARES"
            .cboSubtipo.Enabled = True
            .GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
            .Manipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            cboProyGeneral_SelectedIndexChanged(sender, e)
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        Me.Cursor = Cursors.WaitCursor
        GetProyectosGeneralesCMB()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub dgvCartera_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCartera.TableControlCurrentCellControlDoubleClick
        Me.Cursor = Cursors.WaitCursor
        'Dim f As New frmDireccionProyectos(dgvCartera.Table.CurrentRecord.GetValue("id"))
        'f.CaptionLabels(1).Text = cboProyGeneral.Text
        ''f.CaptionLabels(1).Size = New Size(400, 24)
        ''f.CaptionLabels(1).ForeColor = Color.Yellow
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        Dim f As New frmNuevoProyectoGeneral
        f.Manipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetProyectosGeneralesCMB()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub cboProyGeneral_Click(sender As Object, e As EventArgs) Handles cboProyGeneral.Click

    End Sub

    Private Sub cboProyGeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProyGeneral.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        GetProyectosGeneral(cboProyGeneral.SelectedValue)
        Me.Cursor = Cursors.Arrow
    End Sub
End Class