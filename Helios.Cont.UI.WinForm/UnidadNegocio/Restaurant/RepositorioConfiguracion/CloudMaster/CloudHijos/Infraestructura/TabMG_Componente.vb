Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_Componente

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
        FormatoGridAvanzado(dgvCompras, True, False)
        GetTableDetalle()
    End Sub
#End Region

#Region "Methods"

    Private Sub CambiarStatusItem(Id As Integer, estado As String)
        Dim infraestructuraBE As New infraestructura
        Dim infraestructuraSA As New infraestructuraSA

        infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        infraestructuraBE.idInfraestructura = Id
        infraestructuraBE.estado = estado

        infraestructuraSA.EditarInfraestructuraEstado(infraestructuraBE)

    End Sub

    Private Sub CambiarStatusItem(estado As String)
        Dim infraestructuraBE As New infraestructura
        Dim infraestructuraSA As New infraestructuraSA

        infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        infraestructuraBE.estado = estado

        infraestructuraSA.EliminarInfraestructuraFull(infraestructuraBE)
        'PanelBody.Controls.Clear()
        MessageBoxAdv.Show("Se elimino exitosamente la infraestructura!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub GetTableDetalle()
        Dim componenteSA As New componenteSA
        Dim componenteBE As New componente
        Dim dt As New DataTable

        componenteBE.idEmpresa = Gempresas.IdEmpresaRuc
        componenteBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        With dt.Columns
            .Add("idComponente")
            .Add("idPadre")
            .Add("descripcionItem")
            .Add("tipo")
            .Add("estado")
        End With

        For Each i In componenteSA.getListaComponente(componenteBE) '.Where(Function(o) tables.Contains(o.idtabla)).ToList
            dt.Rows.Add(i.idComponente, i.idPadre, i.descripcionItem, i.usuarioActualizacion, i.estado)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableDescriptor.Columns("descripcionItem").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvCompras.TableDescriptor.Columns("descripcionItem").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
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

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        GetTableDetalle()
        Cursor = Cursors.Default
    End Sub

    Private Sub PonerInactivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PonerInactivoToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Desea dar de baja el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarStatusItem(Integer.Parse(r.GetValue("idtabla")), "AN")
                ButtonAdv1_Click(sender, e)
            End If
        Else
            MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
        End If
    End Sub

    Private Sub ActivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivarToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Desea dar de baja el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarStatusItem(Integer.Parse(r.GetValue("idtabla")), "A")
                ButtonAdv1_Click(sender, e)
            End If
        Else
            MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Desea dar de baja el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarStatusItem(Integer.Parse(r.GetValue("idtabla")), "E")
                ButtonAdv1_Click(sender, e)
            End If
        Else
            MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim f As New frmInfraestructuraModal
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
        GetTableDetalle()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        GetTableDetalle()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
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
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

    End Sub

    Private Sub GradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel1.Paint

    End Sub

#End Region

End Class
