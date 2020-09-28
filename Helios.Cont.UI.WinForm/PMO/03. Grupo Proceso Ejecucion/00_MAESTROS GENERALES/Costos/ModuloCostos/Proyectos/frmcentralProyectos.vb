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
Public Class frmcentralProyectos
    Inherits frmMaster


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetProyectosGeneralesCMB()
        GridCFGDetetail(dgvCartera)
        GridCFGDetetail(dgvCostos)
        GridCFGDetetail(dgEDT)
        CMBEstatus()
        treeViewAdv2.BackColor = Color.DimGray
    End Sub

#Region "Métodos"

    Public Sub GrabarEDT(intIdProyecto As Integer)
        Dim costo As New recursoCosto
        Dim proceso As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        costo = New recursoCosto
        costo.idpadre = intIdProyecto
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
        'Dispose()
    End Sub

    Sub GetPlaneamiento(intIdProyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim listaCostos As New List(Of recursoCosto)
        Dim dt As New DataTable("Orders")

        dt.Columns.Add("id")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("nombreProyecto")
        dt.Columns.Add("Estado")

        listaCostos = New List(Of recursoCosto)
        listaCostos = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdProyecto})
        Dim listacostosSec = listaCostos.OrderBy(Function(o) o.secuenciaCosto).ToList()

        For Each i In listacostosSec
            dt.Rows.Add(i.idCosto, i.secuenciaCosto.GetValueOrDefault, i.nombreCosto, i.status)
        Next
        Me.dgEDT.TopLevelGroupOptions.CaptionText = dgvCartera.Table.CurrentRecord.GetValue("nombreProyecto")
        dgEDT.TopLevelGroupOptions.ShowCaption = True
        dgEDT.DataSource = dt
        'For Each i In costoSA.GetPlaneamientoActividades(New recursoCosto With {.idCosto = intIdProyecto})
        '    Dim dr As DataRow = dt.NewRow
        '    dr(0) = i.IdProceso
        '    dr(1) = i.NomProceso
        '    dr(2) = i.IdActividad
        '    If IsNothing(i.NomActividad) Then
        '        dr(3) = String.Empty
        '    Else
        '        dr(3) = i.NomActividad
        '    End If
        '    dt.Rows.Add(dr)
        'Next
        'dgvPlaneamiento.DataSource = dt
        'dgvPlaneamiento.Table.ExpandAllRecords()

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

        cboGastoGeneral.Items.Clear()
        cboGastoGeneral.Items.Add("GASTO ADMINISTRATIVO")
        cboGastoGeneral.Items.Add("GASTO DE VENTAS")
        cboGastoGeneral.Items.Add("GASTO FINANCIERO")
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
#End Region

    Private Sub dgvCartera_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCartera.TableControlCurrentCellCloseDropDown
        Dim recSA As New recursoCostoSA

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        recSA.EditarStatusCostoByID(New recursoCosto With {.idCosto = dgvCartera.Table.CurrentRecord.GetValue("id"),
                                                           .status = dgvCartera.Table.CurrentRecord.GetValue("Estado")})

    End Sub

    Private Sub frmcentralProyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabGerencia.Parent = Nothing
        TabPlan.Parent = Nothing
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        'Close()
    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim f As New frmNuevoProyectoGeneral
        f.Manipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetProyectosGeneralesCMB()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
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

    Private Sub cboProyGeneral_Click(sender As Object, e As EventArgs) Handles cboProyGeneral.Click

    End Sub

    Private Sub cboProyGeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProyGeneral.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        dgEDT.TopLevelGroupOptions.ShowCaption = False
        dgEDT.DataSource = New DataTable
        GetProyectosGeneral(cboProyGeneral.SelectedValue)
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub GradientPanel6_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel6.Paint

    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvCartera.Table.CurrentRecord
        If Not IsNothing(r) Then
            'Dim f As New frmDireccionProyectos(dgvCartera.Table.CurrentRecord.GetValue("id"))
            'f.CaptionLabels(1).Text = cboProyGeneral.Text
            ''f.CaptionLabels(1).Size = New Size(400, 24)
            ''f.CaptionLabels(1).ForeColor = Color.Yellow
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un sub proyecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
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
    End Sub

    Private Sub ComboBoxAdv3_Click(sender As Object, e As EventArgs) Handles cboGastoGeneral.Click

    End Sub

    Private Sub cboGastoGeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGastoGeneral.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        dgvCostos.DataSource = New List(Of recursoCosto)
        Select Case cboGastoGeneral.Text
            Case "GASTO ADMINISTRATIVO"
                GradientPanel15.Visible = False
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
            Case "GASTO DE VENTAS"
                GradientPanel15.Visible = False
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
            Case "GASTO FINANCIERO"
                GradientPanel15.Visible = False
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub GradientPanel9_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel9.Paint

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub GradientPanel16_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel16.Paint

    End Sub

    Private Sub Panel12_Paint(sender As Object, e As PaintEventArgs) Handles Panel12.Paint

    End Sub

    Private Sub GradientPanel11_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel11.Paint

    End Sub

    Private Sub dgvCartera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCartera.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvCartera.Table.CurrentRecord
        If Not IsNothing(r) Then
            GetPlaneamiento(CInt(r.GetValue("id")))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvCartera.Table.CurrentRecord
        If Not IsNothing(r) Then
            If txtNUevoEDT.Text.Trim.Length > 0 Then
                GrabarEDT(CInt(r.GetValue("id")))
                If Not IsNothing(r) Then
                    GetPlaneamiento(CInt(r.GetValue("id")))
                End If
            Else
                MessageBox.Show("Debe indicar el nombre del EDT", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Proyectos"
                TabGerencia.Parent = TabControlAdv1
                TabPlan.Parent = Nothing

            Case "Gastos"

                TabGerencia.Parent = Nothing
                TabPlan.Parent = TabControlAdv1

        End Select
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
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

    Private Sub GradientPanel7_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel7.Paint


    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

    End Sub
End Class