Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Public Class frmcatalogoCuentas
    Inherits frmMaster

    Private cuentaContableSA As New cuentaplanContableEmpresaSA

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        '    Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(GridGroupingControl2)
        ObtenerCuentasEmpresa()
    End Sub

#Region "métodos"
    Dim colorx As New GridMetroColors()

    Sub GridCFG(GGC As GridGroupingControl)
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
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Sub ObtenerCuentasEmpresa()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dt As New DataTable()

        dt.Columns.Add("nro")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("tipo")

        For Each i In cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.cuenta
            dr(1) = i.descripcion
            dr(2) = "S"
            dt.Rows.Add(dr)
        Next
        'GridGroupingControl2.DataSource = dt


        Dim pager1 = New Pager() With {.PageSize = 50 _
}
        pager1.Wire(GridGroupingControl2, dt)
        ' dt is a DataTable object
        'GridGroupingControl2.TopLevelGroupOptions.ShowFilterBar = True
        'For Each col In _GridGroupingControl2.TableDescriptor.Columns
        '    col.AllowFilter = True
        'Next
    End Sub

    Sub EliminarCuenta(cuentaBE As cuentaplanContableEmpresa)
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        cuentaSA.EliminarCuenta(cuentaBE)
    End Sub

#End Region

    Private Sub frmcatalogoCuentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    

    Private Sub frmcatalogoCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerCuentasEmpresa()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmNuevaCuentaContable
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(GridGroupingControl2.Table.CurrentRecord) Then
            Dim f As New frmNuevaCuentaContable(GridGroupingControl2.Table.CurrentRecord.GetValue("nro"))
            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            f.CaptionLabels(0).Text = "Editar Cuenta"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(GridGroupingControl2.Table.CurrentRecord) Then
            Dim row As Record = GridGroupingControl2.Table.CurrentRecord
            If MessageBoxAdv.Show("Desea eliminar la cuenta seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                EliminarCuenta(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = row.GetValue("nro")})
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
    Private Sub GridGroupingControl2_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridGroupingControl2.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.GridGroupingControl2.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub GridGroupingControl2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl2.TableControlCellClick

    End Sub
    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub
    Private Sub GridGroupingControl2_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles GridGroupingControl2.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, GridGroupingControl2)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If GridGroupingControl2.TopLevelGroupOptions.ShowFilterBar = True Then
            GridGroupingControl2.TopLevelGroupOptions.ShowFilterBar = False
        Else
            GridGroupingControl2.TopLevelGroupOptions.ShowFilterBar = True
            For Each col In _GridGroupingControl2.TableDescriptor.Columns
                col.AllowFilter = True
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As Record = GridGroupingControl2.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim cuenta = cuentaContableSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, r.GetValue("nro"))
            Tag = cuenta
            Close()
        Else
            MessageBox.Show("Debe seleccionar una cuenta válida", "Seleccionar cuenta contable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtFiltrocuenta_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrocuenta.TextChanged

    End Sub

    Private Sub txtFiltrocuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrocuenta.KeyDown

    End Sub
End Class