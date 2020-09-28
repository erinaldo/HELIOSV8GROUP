Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_ProductosEspecial

    Private itemSA As New detalleitemsSA
    Dim filter As New GridExcelFilter()

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridProductos, False, False)
        GetProductos()
    End Sub
#End Region

#Region "MEthods"
    Private Sub GetProductos()
        Dim lista = itemSA.GetExistenciasByEstablecimientoEspecial(GEstableciento.IdEstablecimiento) '.Where(Function(o) o.estado = "A").ToList

        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("codigobarra")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("unidad")
        dt.Columns.Add("categoria")
        dt.Columns.Add("tipo")
        dt.Columns.Add("impuesto")
        dt.Columns.Add("estado")
        dt.Columns.Add("selec", GetType(Boolean))

        For Each i In lista
            dt.Rows.Add(i.codigodetalle, i.codigo, i.descripcionItem, i.unidad1, If(i.item IsNot Nothing, i.item.descripcion, String.Empty), i.tipoExistencia, i.origenProducto,
                        If(i.estado = "A", "Activo", "Inactivo"), True)
        Next
        GridProductos.DataSource = dt


        GridProductos.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GridProductos.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

    End Sub

    Private Sub GetProductos(textoFilter As String)
        Dim lista = itemSA.GetExistenciasByEstablecimiento(GEstableciento.IdEstablecimiento).Where(Function(o) o.descripcionItem.Contains(textoFilter)).ToList '.Where(Function(o) o.estado = "A").ToList

        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("codigobarra")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("unidad")
        dt.Columns.Add("categoria")
        dt.Columns.Add("tipo")
        dt.Columns.Add("impuesto")
        dt.Columns.Add("estado")
        dt.Columns.Add("selec", GetType(Boolean))

        For Each i In lista
            dt.Rows.Add(i.codigodetalle, i.codigo, i.descripcionItem, i.unidad1, If(i.item IsNot Nothing, i.item.descripcion, String.Empty), i.tipoExistencia, i.origenProducto, If(i.estado = "A", "Activo", "Inactivo"), True)
        Next
        GridProductos.DataSource = dt
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
            GridProductos.TopLevelGroupOptions.ShowFilterBar = True
            GridProductos.NestedTableGroupOptions.ShowFilterBar = True
            GridProductos.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In GridProductos.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            GridProductos.OptimizeFilterPerformance = True
            GridProductos.ShowNavigationBar = True
            filter.WireGrid(GridProductos)
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(GridProductos)
            GridProductos.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = GridProductos.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New frmNuevaExistenciaEspecial(Val(r.GetValue("codigo")))
            f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            If TextBuscarProduct.Text.Trim.Length > 0 Then

                GetProductos(TextBuscarProduct.Text)
            Else

                GetProductos()

            End If

        Else
            MessageBox.Show("Seleccione un producto válido", "Seleccinar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TextBuscarProduct_Click(sender As Object, e As EventArgs) Handles TextBuscarProduct.Click

    End Sub

    Private Sub TextBuscarProduct_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBuscarProduct.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            If TextBuscarProduct.Text.Trim.Length > 0 Then
                e.SuppressKeyPress = True
                GetProductos(TextBuscarProduct.Text.Trim)
            Else
                TextBuscarProduct.Select()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        Dim listaRecords As New List(Of Record)
        For Each i In GridProductos.Table.Records
            If i.GetValue("selec") = True Then
                listaRecords.Add(i)
            End If
        Next

        If listaRecords.Count > 0 Then
            Dim f As New FormImportarProductos(listaRecords)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
    End Sub

    Private Sub SeleccinarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccinarTodoToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        For Each i In GridProductos.Table.Records
            i.SetValue("selec", True)
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub QuitarSelecciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarSelecciónToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        For Each i In GridProductos.Table.Records
            i.SetValue("selec", False)
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub PonerInactivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PonerInactivoToolStripMenuItem.Click
        Dim r As Record = GridProductos.Table.CurrentRecord
        If r IsNot Nothing Then
            CambiarEstado("I")
        End If

    End Sub

    Private Sub CambiarEstado(estado As String)
        Dim itemSA As New detalleitemsSA
        itemSA.CambiarEstadoItem(New detalleitems With
                                 {
                                 .codigodetalle = GridProductos.Table.CurrentRecord.GetValue("codigo"),
                                 .estado = estado
                                 })
        If estado = "A" Then
            GridProductos.Table.CurrentRecord.SetValue("estado", "Activo")
        Else
            GridProductos.Table.CurrentRecord.SetValue("estado", "Inactivo")
        End If
        MessageBox.Show("El producto cambio de estado", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ActivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivarToolStripMenuItem.Click
        Dim r As Record = GridProductos.Table.CurrentRecord
        If r IsNot Nothing Then
            CambiarEstado("A")
        End If
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

    End Sub
#End Region


End Class
