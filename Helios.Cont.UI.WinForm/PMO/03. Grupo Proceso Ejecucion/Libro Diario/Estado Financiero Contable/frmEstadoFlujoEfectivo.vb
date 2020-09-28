Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports System.ComponentModel
Imports Syncfusion.Windows.Forms.Tools
Public Class frmEstadoFlujoEfectivo
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvDetalleCajas)
        GridCFG(DgvFlujoEfectivo)
        Consulta()
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

#Region "Métodos"
    Sub Consulta()
        Me.Cursor = Cursors.WaitCursor
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New List(Of documentoCaja)
        Dim efsa As New EstadosFinancierosSA
        Dim dt As New DataTable
        dt.Columns.Add("tipooperacion")
        dt.Columns.Add("movimiento")
        dt.Columns.Add("total")


        caja = cajaSA.GetFlujoEfectivo()
        For Each i In caja
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.tipoOperacion
            dr(1) = If(i.tipoMovimiento = "PG", "Pagos", "Cobros")
            dr(2) = i.montoSoles
            dt.Rows.Add(dr)
        Next
        DgvFlujoEfectivo.DataSource = dt

        Dim obj = efsa.GetEstadoCajasTodos()
        lblTotalCajas.Text = CDec(obj.importeBalanceMN).ToString("N2")
        lblTotalEntradas.Text = caja.Where(Function(o) o.tipoMovimiento = "DC").Sum(Function(o) o.montoSoles).GetValueOrDefault
        lblTotalSalida.Text = caja.Where(Function(o) o.tipoMovimiento = "PG").Sum(Function(o) o.montoSoles).GetValueOrDefault


        'DETALLE DE AJAS
        Dim dtCajas As New DataTable()
        dtCajas.Columns.Add("ef")
        dtCajas.Columns.Add("moneda")
        dtCajas.Columns.Add("tipo")
        dtCajas.Columns.Add("ingreso")
        dtCajas.Columns.Add("salida")
        dtCajas.Columns.Add("saldo")

        For Each i In efsa.GetEstadoCajasTodosDetalle()
            Dim dr As DataRow = dtCajas.NewRow
            dr(0) = i.descripcion
            dr(1) = i.codigo
            Select Case i.tipo
                Case CuentaFinanciera.Banco
                    dr(2) = "Banco"
                Case CuentaFinanciera.Efectivo
                    dr(2) = "Efectivo"
                Case CuentaFinanciera.Tarjeta_Credito
                    dr(2) = "Tarj. crédito"
                Case CuentaFinanciera.Tarjeta_Debito
                    dr(2) = "Tarj. Débito"
            End Select

            dr(3) = i.Ingresos.GetValueOrDefault
            dr(4) = i.Salidas.GetValueOrDefault
            dr(5) = i.SaldoCaja.GetValueOrDefault
            dtCajas.Rows.Add(dr)
        Next
        dgvDetalleCajas.DataSource = dtCajas
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

    Private Sub frmEstadoFlujoEfectivo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmEstadoFlujoEfectivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles lblTotalCajas.Click

    End Sub
End Class