Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid

Public Class frmMaestroGastos

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        StartPosition = FormStartPosition.CenterParent
        cboGastoGeneral.Items.Clear()
        cboGastoGeneral.Items.Add("GASTO ADMINISTRATIVO")
        cboGastoGeneral.Items.Add("GASTO DE VENTAS")
        cboGastoGeneral.Items.Add("GASTO FINANCIERO")
        GridCFG(dgvCostos)
        GridCFG(dgvGastos)

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral

        txtAnioCompra.Text = AnioGeneral

    End Sub
#End Region

#Region "Methods"




    Private Sub GetConsolidado(be As recursoCosto)
        Dim costoSA As New recursoCostoDetalleSA

        dgvGastos.DataSource = costoSA.GetListadoGastosConsolidados(be)

    End Sub


    Sub GridCFG(GGC As GridGroupingControl)
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

        grid.TableOptions.SelectionBackColor = Color.Gray
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub GetCostoByTipo(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA

        'dgvCostos.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
        '                                                                              .subtipo = be.subtipo})





        dgvCostos.TableDescriptor.GroupedColumns.Clear()


        Dim dt As New DataTable




        dt.Columns.Add("idCosto")
        dt.Columns.Add("nombreCosto")
        dt.Columns.Add("status")
        dt.Columns.Add("inicio")
        dt.Columns.Add("finaliza")
        dt.Columns.Add("detalle")
        dt.Columns.Add("subdetalle")
        dt.Columns.Add("codigo")


        For Each i In recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idCosto
            dr(1) = i.nombreCosto
            dr(2) = i.status
            dr(3) = i.inicio
            dr(4) = i.finaliza
            dr(5) = i.detalle
            dr(6) = i.subdetalle
            dr(7) = i.codigo


            dt.Rows.Add(dr)
        Next
        dgvCostos.DataSource = dt ' compraSA.ListaRe


        'Select Case be.subtipo
        '    Case TipoCosto.Proyecto
        '        Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Proyectos"
        '    Case TipoCosto.ActivoFijo
        '        Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Activos Fijos"
        '    Case TipoCosto.OrdenProduccion
        '        Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Orden de producción"
        '    Case TipoCosto.GastoAdministrativo
        '        Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Gasto Administrativo"
        '    Case TipoCosto.GastoVentas
        '        Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Gasto de ventas"
        '    Case TipoCosto.GastoFinanciero
        '        Me.dgvCostos.TopLevelGroupOptions.CaptionText = "Gasto financiero"
        'End Select

        'dgvCostos.TopLevelGroupOptions.ShowCaption = True
        'dgvCostos.TableDescriptor.Relations.Clear()

        'dgvCostos.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Dim f As New frmNuevoCosto
        f.Label19.Text = "Responsable"
        f.Label3.Text = "Centro de Gastos"
        f.txtInicio.Visible = False
        f.txtFinaliza.Visible = False
        f.Label7.Visible = False
        f.Label8.Visible = False
        f.cboSubtipo.Items.Clear()
        f.cboSubtipo.Items.Add("GASTO ADMINISTRATIVO")
        f.cboSubtipo.Items.Add("GASTO DE VENTAS")
        f.cboSubtipo.Items.Add("GASTO FINANCIERO")

        Select Case cboGastoGeneral.Text
            Case "GASTO ADMINISTRATIVO"
                f.cboTipo.Text = "HOJA DE GASTO"
                f.cboSubtipo.Text = "GASTO ADMINISTRATIVO"
                f.cboSubtipo.Enabled = True
                'f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "94"})
                f.txtCodigo.Text = "94"
            Case "GASTO DE VENTAS"
                f.cboTipo.Text = "HOJA DE GASTO"
                f.cboSubtipo.Text = "GASTO DE VENTAS"
                'f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "95"})
                f.txtCodigo.Text = "95"
            Case "GASTO FINANCIERO"
                f.cboTipo.Text = "HOJA DE GASTO"
                f.cboSubtipo.Text = "GASTO FINANCIERO"
                'f.GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "97"})
                f.txtCodigo.Text = "97"
        End Select

        f.Manipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        cboGastoGeneral_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cboGastoGeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGastoGeneral.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        dgvCostos.DataSource = New List(Of recursoCosto)
        Select Case cboGastoGeneral.Text
            Case "GASTO ADMINISTRATIVO"
                '
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
            Case "GASTO DE VENTAS"

                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
            Case "GASTO FINANCIERO"

                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub



    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim asientoSA As New AsientoSA

        If Not IsNothing(dgvGastos.Table.CurrentRecord) Then
            If MessageBox.Show("Va quitar la asignación del recurso seleccionado." & vbCrLf &
                           "Nota: Se eliminarán todos los servicios asignados del comprobante", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                asientoSA.EliminarAsientoCostos(New asiento With {.idDocumento = Val(dgvGastos.Table.CurrentRecord.GetValue("documentoRef")),
                                                                  .codigoLibro = dgvGastos.Table.CurrentRecord.GetValue("operacion")})

                MessageBox.Show("Recursos liberados de asignación!." & vbCrLf &
                                "Puede verificar en contabilidad, alertas de recursos x asignar.", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If Not IsNothing(dgvCostos.Table.CurrentRecord) Then
                    GetConsolidado(New recursoCosto With {.idCosto = Val(dgvCostos.Table.CurrentRecord.GetValue("idCosto"))})
                End If

            End If
        Else
            MessageBox.Show("Debe seleccionar un recurso válido!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCostos_SourceListListChangedCompleted(sender As Object, e As Syncfusion.Grouping.TableListChangedEventArgs)

    End Sub



    Private Sub GradientPanel20_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel20.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmMaestroGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

    Private Sub cboGastoGeneral_Click(sender As Object, e As EventArgs) Handles cboGastoGeneral.Click

    End Sub

    Private Sub dgvCostos_SelectedRecordsChanged(sender As Object, e As Syncfusion.Grouping.SelectedRecordsChangedEventArgs) Handles dgvCostos.SelectedRecordsChanged
        Cursor = Cursors.WaitCursor
        If Not IsNothing(e.SelectedRecord) Then
            GetConsolidado(New recursoCosto With {.idCosto = Val(e.SelectedRecord.Record.GetValue("idCosto"))})
        End If
        Cursor = Cursors.Arrow
    End Sub


    Private Sub dgvCostos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCostos.TableControlCellClick

    End Sub
End Class