Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_Infraestructura

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
    Private Sub CambiarStatusItem(Id As Integer, estado As String)
        Dim infraestructuraBE As New infraestructura
        Dim infraestructuraSA As New infraestructuraSA

        infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        infraestructuraBE.idInfraestructura = Id
        infraestructuraBE.estado = estado

        infraestructuraSA.EditarInfraestructuraEstado(infraestructuraBE)

    End Sub

    Private Sub GetTableDetalle()
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim dt As New DataTable
        ' Dim tables() As String = {"1", "2", "6", "10", "14", ""}

        infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        infraestructuraBE.estado = "A"

        With dt.Columns
            .Add("idtabla")
            .Add("bloque")
            .Add("segmento")
            .Add("piso")
            .Add("estado")
        End With

        For Each i In infraestructuraSA.getInfraestructuraEstructura(New infraestructura With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento}).ToList  '.Where(Function(o) tables.Contains(o.idtabla)).ToList
            dt.Rows.Add(i.idInfraestructura, i.Bloque, i.Sector, i.Piso, i.estado)
        Next

        dgvCompras.DataSource = dt
        dgvCompras.TableDescriptor.Columns("piso").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvCompras.TableDescriptor.Columns("piso").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
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


    Private Sub PonerInactivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PonerInactivoToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Desea dar de baja el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarStatusItem(Integer.Parse(r.GetValue("idtabla")), "AN")
                'ButtonAdv1_Click(sender, e)
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
                'ButtonAdv1_Click(sender, e)
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
                'ButtonAdv1_Click(sender, e)
            End If
        Else
            MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
        End If
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs)
        Dim f As New frmInfraestructura
        f.PictureBox2.Visible = False
        f.PictureBox3.Visible = False
        f.pxSector.Visible = False
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try

            Dim infraestructuraBE As New infraestructura
            Dim infraestructuraSA As New infraestructuraSA
            Dim conteoInfraestructura As Integer = 0

            'infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            'infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            'infraestructuraBE.estado = "A"
            'conteoInfraestructura = infraestructuraSA.getInfraestructuraCount(infraestructuraBE)

            'If (conteoInfraestructura = 0) Then
            Dim f As New frmInfraestructura
            f.StartPosition = FormStartPosition.CenterScreen
            f.ShowDialog()
            GetTableDetalle()
            'Else
            '    MessageBoxAdv.Show("Existe una infraestructura existente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Cursor = Cursors.WaitCursor
        GetTableDetalle()
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If MessageBox.Show("Desea Eliminar toda la infraestructura?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CambiarStatusItem("E")
            GetTableDetalle()
        End If
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

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dim f As New frmInfraestructura
        'f.PictureBox2.Visible = False
        'f.PictureBox3.Visible = False
        'f.pxSector.Visible = False
        'f.Panel19.Visible = False
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetTableDetalle()
    End Sub

#End Region

End Class
