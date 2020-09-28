Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmMaestroConceptos

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GridCFGDetetail(dgIngresos)
        GridCFGDetetail(dgAporteEmp)
        GridCFGDetetail(dgAporteTrab)
        GridCFGDetetail(dgDescuentos)
        GridCFGDetetail(dgTotales)
        GridCFGDetetail(dgValGeneral)
        GradientPanel8.Visible = True
    End Sub

#Region "Métodos"
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

    Public Sub CargarDatos(cargo As String)
        Dim servicio As New ConceptoSA
        Dim listaConceptoIngresos = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = "01", .TipoPlanilla = cargo})
        Dim listaConceptoDescuestos = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = "02", .TipoPlanilla = cargo})
        Dim listaConceptoAportes_T = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = "03", .TipoPlanilla = cargo})
        Dim listaConceptoAportes_E = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = "04", .TipoPlanilla = cargo})
        Dim listaConceptoTotales = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = "05", .TipoPlanilla = cargo})
        Dim listaConceptoGenerales = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = "06", .TipoPlanilla = cargo})


        dgIngresos.DataSource = listaConceptoIngresos
        dgDescuentos.DataSource = listaConceptoDescuestos
        dgAporteTrab.DataSource = listaConceptoAportes_T
        dgAporteEmp.DataSource = listaConceptoAportes_E
        dgTotales.DataSource = listaConceptoTotales
        dgValGeneral.DataSource = listaConceptoGenerales



    End Sub
#End Region

    Private Sub frmMaestroConceptos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Listados As New TablaDetalleSA
        Dim lstTipoPlanilla = Listados.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1021})

        ' Dim cargoSA As New Helios.Planilla.WCFService.ServiceAccess.CargosSA
        cboTipoPlanilla.DataSource = lstTipoPlanilla ' cargoSA.CargosSelAll()
        cboTipoPlanilla.ValueMember = "IDTablaDetalle"
        cboTipoPlanilla.DisplayMember = "DescripcionLarga"

        TabConceptos.ActiveTabColor = Color.FromArgb(72, 140, 221)
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Dim selCondepto As Int32 = 0

        If TabConceptos.SelectedTab Is TabIngresos Then
            selCondepto = 1
        ElseIf TabConceptos.SelectedTab Is TabDescuentos Then
            selCondepto = 2
        ElseIf TabConceptos.SelectedTab Is tabAportesEmp Then
            selCondepto = 4
        ElseIf TabConceptos.SelectedTab Is tabAportesTrab Then
            selCondepto = 3
        End If

        Dim frm As New frmNuevoConceptoPlanilla
        frm.StartPosition = FormStartPosition.CenterParent
        SelConcepto = Nothing
        frm.cboTipoPlanilla.SelectedValue = cboTipoPlanilla.SelectedValue
        frm.cboTipoConcepto.SelectedValue = Convert.ToInt32(selCondepto)
        frm.ShowDialog(Me)

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        CargarDatos(String.Format("{0:00}", cboTipoPlanilla.SelectedValue))
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

    End Sub

    Private Sub cboTipoPlanilla_Click(sender As Object, e As EventArgs) Handles cboTipoPlanilla.Click

    End Sub

    Private Sub cboTipoPlanilla_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoPlanilla.SelectedValueChanged
        Dim codigo = cboTipoPlanilla.SelectedValue
        If IsNumeric(codigo) Then
            If codigo.ToString.Trim.Length > 0 Then
                CargarDatos(String.Format("{0:00}", cboTipoPlanilla.SelectedValue))
            End If
        End If
    End Sub

    Private Sub TabConceptos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabConceptos.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

    End Sub
End Class