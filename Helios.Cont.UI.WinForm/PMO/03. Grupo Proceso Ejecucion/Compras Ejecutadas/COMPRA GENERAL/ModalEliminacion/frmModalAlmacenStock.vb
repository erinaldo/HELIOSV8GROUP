Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Microsoft
Imports Syncfusion.Grouping
Public Class frmModalAlmacenStock
    Inherits frmMaster

    Public Sub New(intIdItem As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG2(dgvKardexVal)
        GetInventarioValorizado(intIdItem)
    End Sub

#Region "Métodos"
    Sub GridCFG2(grid As GridGroupingControl)
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
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Private Sub GetInventarioValorizado(intIdItem As Integer)
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("idalmacen", GetType(Integer)))
        dt.Columns.Add(New DataColumn("almacen", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))


        For Each i As totalesAlmacen In totalesAlmacenSA.GetAlmacenesByProducto(intIdItem, Gempresas.IdEmpresaRuc)
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idAlmacen
            dr(1) = i.NomAlmacen
            dr(2) = strGravado
            dr(3) = i.descripcion
            dr(4) = i.tipoExistencia
            dr(5) = i.unidadMedida
            dr(6) = i.cantidad
            dr(7) = i.importeSoles
            dr(8) = i.idItem
            dr(9) = i.importeDolares
            dt.Rows.Add(dr)
        Next
        dgvKardexVal.DataSource = dt
    End Sub
#End Region

    Private Sub frmModalAlmacenStock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalAlmacenStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvKardexVal_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardexVal.TableControlCellClick

    End Sub

    Private Sub dgvKardexVal_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardexVal.TableControlCellDoubleClick
     
    End Sub

    Private Sub dgvKardexVal_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvKardexVal.TableControlCurrentCellControlDoubleClick
        Dim pumn As Decimal = 0
        Dim pume As Decimal = 0
        If MessageBox.Show("Confirmar almacén seleccionado ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            Dim n As New RecuperarCarteras
            datos.Clear()

            pumn = CDec(dgvKardexVal.Table.CurrentRecord.GetValue("importeSoles")) / CDec(dgvKardexVal.Table.CurrentRecord.GetValue("cantidad"))
            pume = CDec(dgvKardexVal.Table.CurrentRecord.GetValue("importeUS")) / CDec(dgvKardexVal.Table.CurrentRecord.GetValue("cantidad"))

            n.ID = dgvKardexVal.Table.CurrentRecord.GetValue("idalmacen")
            n.NomProceso = dgvKardexVal.Table.CurrentRecord.GetValue("almacen")
            n.PMmn = pumn
            n.PMme = pume
            n.Montomn = dgvKardexVal.Table.CurrentRecord.GetValue("cantidad")
            datos.Add(n)
            Dispose()
        End If
    End Sub
End Class