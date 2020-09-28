Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmMaestrotrabajadores

    Public Property PersonalCargoSA As New PersonalCargoSA

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GridCFGDetetail(dgvPersonal)
        General.FormatoGridPequeño(dgvCargosPersonal, True)
        CargarPersonalDGV()
        CMBCargos()
    End Sub

#Region "Métodos"
    Sub CMBCargos()
        Dim cargoSA As New Helios.Planilla.WCFService.ServiceAccess.CargosSA
        cboCargo.DataSource = cargoSA.CargosSelAll()
        cboCargo.ValueMember = "IDCargo"
        cboCargo.DisplayMember = "DescripcionCorta"
        cboCargo.Visible = True
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

    Public Sub CargarPersonalDGV()
        Dim servicio As New PersonalSA
        Dim dt As New DataTable

        Dim listaPersonal = servicio.PersonalSelxEstado(New Personal With {.Estado = "01"})
        dgvPersonal.DataSource = listaPersonal
        dgvPersonal.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub
#End Region

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Dim f As New frmNuevoTrabajador
        f.Action = Entity.EntityState.Added
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dim r As Record = dgvPersonal.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmNuevoTrabajador(Val(r.GetValue("IDPersonal")))
            f.Action = Entity.EntityState.Modified
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un personal", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim r As Record = dgvPersonal.Table.CurrentRecord
        If Not IsNothing(r) Then
            'Dim f As New frmHorariosPersonal(Int32.Parse(r.GetValue("IDPersonal")))
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Dim r As Record = dgvPersonal.Table.CurrentRecord
        If r IsNot Nothing Then
            AgregarPersonalCargo(r)
            LoadCargosPersonal(r)
        Else
            MessageBox.Show("Debe seleccionar un trabajador", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub LoadCargosPersonal(r As Record)
        Dim dt As New DataTable
        dt.Columns.Add("Idcargo").Caption = "ID"
        dt.Columns.Add("cargo").Caption = "Cargo"
        dt.Columns.Add("status").Caption = "Estado"
        dt.Columns.Add("horas").Caption = "Horas"

        For Each i In PersonalCargoSA.PersonalCargoSel(New PersonalCargo With {.IDPersonal = Integer.Parse(r.GetValue("IDPersonal")), .status = PersonalCargo.EntityStatus.Activo})
            dt.Rows.Add(i.IDCargo,
                        i.DescripcionLarga,
                        i.status, 0)
        Next
        dgvCargosPersonal.DataSource = dt
    End Sub

    Private Sub AgregarPersonalCargo(r As Record)
        PersonalCargoSA.PersonalCargoSave(New PersonalCargo With
                                          {
                                          .Action = BaseBE.EntityAction.INSERT,
                                          .IDCargo = cboCargo.SelectedValue,
                                          .DescripcionLarga = cboCargo.Text,
                                          .IDPersonal = Integer.Parse(r.GetValue("IDPersonal")),
                                          .status = 1
                                          }, UserManager.TransactionData)
    End Sub

    Private Sub dgvPersonal_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvPersonal.SelectedRecordsChanged
        If e.SelectedRecord IsNot Nothing Then
            LoadCargosPersonal(e.SelectedRecord.Record)
        End If
    End Sub

    Private Sub dgvCargosPersonal_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCargosPersonal.TableControlCellClick

    End Sub

    Private Sub dgvCargosPersonal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvCargosPersonal.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvPersonal.Table.CurrentRecord
        Try
            If e.Inner.ColIndex = 5 Then
                Dim codigoCargo = Integer.Parse(dgvCargosPersonal.TableModel(e.Inner.RowIndex, 1).CellValue)
                Dim f As New frmHorariosPersonal(Integer.Parse(r.GetValue("IDPersonal")), codigoCargo)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            ElseIf e.Inner.ColIndex = 6 Then
                Dim codigoCargo = Integer.Parse(dgvCargosPersonal.TableModel(e.Inner.RowIndex, 1).CellValue)
                Dim f As New frmConceptoPersonal(Integer.Parse(r.GetValue("IDPersonal")), codigoCargo)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                'diMsgBox("editar")
            ElseIf e.Inner.ColIndex = 21 Then

            ElseIf e.Inner.ColIndex = 22 Then

            ElseIf e.Inner.ColIndex = 23 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvPersonal_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPersonal.TableControlCellClick

    End Sub

    Private Sub dgvCargosPersonal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvCargosPersonal.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 5 Then
                e.Inner.Style.Description = "Horarios"
                Dim sButtonText As String = "Horarios" 'e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
            If e.Inner.ColIndex = 6 Then
                e.Inner.Style.Description = "Conceptos"
                Dim sButtonText As String = "Conceptos" ' e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(1), irect)
            End If

        End If
    End Sub

    Private Sub dgvCargosPersonal_TableControlPrepareViewStyleInfo(sender As Object, e As GridTableControlPrepareViewStyleInfoEventArgs) Handles dgvCargosPersonal.TableControlPrepareViewStyleInfo
        If (e.Inner.ColIndex = 5) Then
            e.Inner.Style.CellTipText = "Horarios"
        ElseIf e.Inner.ColIndex = 6 Then
            e.Inner.Style.CellTipText = "Conceptos"
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        CargarPersonalDGV()
    End Sub

    Private Sub frmMaestrotrabajadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class