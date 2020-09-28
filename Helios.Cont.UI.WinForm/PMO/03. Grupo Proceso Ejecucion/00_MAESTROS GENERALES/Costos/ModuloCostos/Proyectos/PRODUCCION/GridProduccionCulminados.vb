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
Public Class GridProduccionCulminados
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFGDetetail(dgvCartera)
        GridCFGDetetail(dgEDT)
        CMBEstatus()
        GetProyectosGeneral(ProyectoGeneralSel.idCosto, TipoCosto.OP_CONTINUA_DE_BIENES)
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

    Public Sub GetProyectosGeneral(idProyectoGeneral As Integer, subtipo As String)
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
        For Each i In recursoSA.GetListaProyectosBySubTipo(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral, .subtipo = subtipo, .status = StatusCosto.Culminado})
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
#End Region

    Private Sub GridProduccionCulminados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvCartera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCartera.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvCartera.Table.CurrentRecord
        If Not IsNothing(r) Then
            GetPlaneamiento(CInt(r.GetValue("id")))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCartera_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCartera.TableControlCurrentCellCloseDropDown
        Dim recSA As New recursoCostoSA

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()

        recSA.EditarStatusCostoByID(New recursoCosto With {.idCosto = dgvCartera.Table.CurrentRecord.GetValue("id"),
                                                           .status = dgvCartera.Table.CurrentRecord.GetValue("Estado")})
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

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvCartera.Table.CurrentRecord) Then
            Dim f As New frmNuevoCosto
            f.UbicarCostoById(New recursoCosto With {.idCosto = Val(dgvCartera.Table.CurrentRecord.GetValue("id"))})
            f.Manipulacion = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.GradientPanel2.Visible = False
            f.ShowDialog()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        With frmNuevoCosto
            .IdProyectoGeneral = ProyectoGeneralSel.idCosto
            .cboTipo.Text = "HOJA DE COSTO"
            ' .cboSubtipo.Text = "HC - CONSTRUC. Y SIMILARES"
            .cboSubtipo.Enabled = True
            .GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
            .Manipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            GetProyectosGeneral(ProyectoGeneralSel.idCosto, TipoCosto.OP_CONTINUA_DE_BIENES)
        End With
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvCartera.Table.CurrentRecord
        Dim costosa As New recursoCostoSA
        If Not IsNothing(r) Then
            costosa.GetCulminarProduccion(New recursoCosto With {.idCosto = r.GetValue("id"), .status = CInt(StatusProductosTerminados.Pendiente)})
            MessageBox.Show("Sub proyecto abierto", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GetProyectosGeneral(ProyectoGeneralSel.idCosto, TipoCosto.OP_CONTINUA_DE_BIENES)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Cursor = Cursors.WaitCursor
        GetProyectosGeneral(ProyectoGeneralSel.idCosto, TipoCosto.OP_CONTINUA_DE_BIENES)
        Cursor = Cursors.Default
    End Sub
End Class