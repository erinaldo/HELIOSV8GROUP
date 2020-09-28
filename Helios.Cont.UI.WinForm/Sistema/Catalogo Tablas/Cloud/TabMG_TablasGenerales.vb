Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_TablasGenerales

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCompras, True, False, 9.0F)
        OrdenamientoGrid(dgvCompras, True)
        GradientPanel11.Visible = True
        Getcombos()
    End Sub
#End Region

#Region "Methods"
    Private Sub CambiarStatusItem(idtabla As Integer, codigo As String, status As String)
        Dim tablaSA As New tablaDetalleSA

        tablaSA.CambiarStatusItem(New Business.Entity.tabladetalle With {.idtabla = idtabla, .codigoDetalle = codigo, .estadodetalle = status})
    End Sub

    Private Sub GetTableDetalle(idtabla As Integer)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        ' Dim tables() As String = {"1", "2", "6", "10", "14", ""}

        With dt.Columns
            .Add("idtabla")
            .Add("codigoDetalle")
            .Add("codigoDetalle2")
            .Add("descripcion")
            .Add("estado")
        End With

        For Each i In tablaSA.GetListaTablaDetalleTodo(idtabla) '.Where(Function(o) tables.Contains(o.idtabla)).ToList
            dt.Rows.Add(i.idtabla, i.codigoDetalle, i.codigoDetalle2, i.descripcion, i.estadodetalle)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvCompras.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub Getcombos()
        Dim tablaSA As New TablaSA
        Dim tables() As String = {"1", "2", "6", "10", "14", ""}
        cboTablas.DisplayMember = "descripcion"
        cboTablas.ValueMember = "idtabla"
        cboTablas.DataSource = tablaSA.GetListaTabla.Where(Function(o) tables.Contains(o.idtabla)).ToList
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
#End Region

#Region "Events"
    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompras.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvCompras.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvCompras_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCompras.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCompras)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        GetTableDetalle(Integer.Parse(cboTablas.SelectedValue.ToString()))
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
            dgvCompras.TopLevelGroupOptions.ShowFilterBar = True
            dgvCompras.NestedTableGroupOptions.ShowFilterBar = True
            dgvCompras.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvCompras.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvCompras.OptimizeFilterPerformance = True
            dgvCompras.ShowNavigationBar = True
            filter.WireGrid(dgvCompras)
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgvCompras)
            dgvCompras.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        Try
            If r IsNot Nothing Then
                Dim f As New frmNuevoitemTabladetalle(Integer.Parse(r.GetValue("idtabla")), r.GetValue("codigoDetalle"))
                f.cboCuentaPadre.Enabled = False
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
            End If
        Catch ex As Exception
            MsgBox(ex.message)
        End Try

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub

    Private Sub PonerInactivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PonerInactivoToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Desea dar de baja el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarStatusItem(Integer.Parse(r.GetValue("idtabla")), r.GetValue("codigoDetalle").ToString(), "0")
                ButtonAdv1_Click(sender, e)
            End If
        Else
            MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
        End If
    End Sub

    Private Sub ActivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivarToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Desea activar el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarStatusItem(Integer.Parse(r.GetValue("idtabla")), r.GetValue("codigoDetalle").ToString(), "1")
                ButtonAdv1_Click(sender, e)
            End If
        Else
            MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
        End If
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

    End Sub

#End Region

End Class
