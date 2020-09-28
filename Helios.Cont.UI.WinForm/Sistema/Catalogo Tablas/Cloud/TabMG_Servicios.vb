Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_Servicios

    Private itemSA As New servicioSA
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
        Dim objServicio As New servicio
        objServicio.idEmpresa = Gempresas.IdEmpresaRuc
        objServicio.idEstablecimiento = GEstableciento.IdEstablecimiento
        objServicio.tipo = "SP"

        Dim lista = itemSA.GetListaServicios(objServicio) '.Where(Function(o) o.estado = "A").ToList

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
        dt.Columns.Add("marca")

        For Each i In lista.OrderBy(Function(o) o.descripcion).ToList
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idServicio
            dr(1) = i.codigo
            dr(2) = i.descripcion
            dr(3) = i.unidadMedida
            dr(4) = i.categoria
            Select Case i.tipo
                Case 1
                    dr(5) = "1 - GRAVADO"
                Case 2
                    dr(5) = "2 - EXONERADO"
                Case 3
                    dr(5) = "3 - INAFECTO"
            End Select

            dr(6) = 0
            dr(7) = If(i.estado = "A", "Activo", "Inactivo")
            dr(8) = True
            dr(9) = i.idItemServicio

            dt.Rows.Add(dr)

            '            dt.Rows.Add(i.idServicio, i.codigo, i.descripcion, i.unidadMedida, If(i.idItemServicio IsNot Nothing, i.itemServicio.descripcion, String.Empty), i.tipoExist, 0,
            '                        If(i.estado = "A", "Activo", "Inactivo"), True,
            'If(i.customMarca IsNot Nothing, i.customMarca.descripcion, String.Empty))



        Next
        GridProductos.DataSource = dt


        GridProductos.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GridProductos.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        GridProductos.TableDescriptor.Columns("marca").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GridProductos.TableDescriptor.Columns("marca").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

    End Sub

    Private Sub GetProductos(textoFilter As String)
        'Dim lista = itemSA.GetExistenciasByEstablecimiento(GEstableciento.IdEstablecimiento).Where(Function(o) o.descripcionItem.Contains(textoFilter)).ToList '.Where(Function(o) o.estado = "A").ToList
        Dim NuevaDescripcion As String = String.Empty
        Dim delimitadores() As String = {" "}
        Dim vectoraux() As String
        vectoraux = textoFilter.Split(delimitadores, StringSplitOptions.None)

        'mostrar resultado
        For Each item As String In vectoraux
            NuevaDescripcion += item & "%"
        Next
        'Dim lista = itemSA.GetArticulosSytem(Gempresas.IdEmpresaRuc, NuevaDescripcion).ToList '.Where(Function(o) o.estado = "A").ToList


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
        dt.Columns.Add("marca")

        'For Each i In lista
        '    'dt.Rows.Add(i.codigodetalle, i.codigo, i.descripcionItem, i.unidad1, If(i.item IsNot Nothing, i.item.descripcion, String.Empty), i.tipoExistencia, i.origenProducto, If(i.estado = "A", "Activo", "Inactivo"), True, If(i.customMarca IsNot Nothing, i.customMarca.descripcion, String.Empty))
        '    dt.Rows.Add(i.codigodetalle,
        '                i.codigo,
        '                i.descripcionItem,
        '                i.unidad1,
        '                i.NomClasificacion,
        '                i.tipoExistencia,
        '                i.origenProducto,
        '                If(i.estado = "A", "Activo", "Inactivo"),
        '                True,
        '                i.NomMarca)
        'Next
        GridProductos.DataSource = dt
    End Sub

    Private Sub GetProductosContains(textoFilter As String)
        'Dim lista = itemSA.GetExistenciasByEstablecimiento(GEstableciento.IdEstablecimiento).Where(Function(o) o.descripcionItem.Contains(textoFilter)).ToList '.Where(Function(o) o.estado = "A").ToList

        'Dim dt As New DataTable
        'dt.Columns.Add("codigo")
        'dt.Columns.Add("codigobarra")
        'dt.Columns.Add("descripcion")
        'dt.Columns.Add("unidad")
        'dt.Columns.Add("categoria")
        'dt.Columns.Add("tipo")
        'dt.Columns.Add("impuesto")
        'dt.Columns.Add("estado")
        'dt.Columns.Add("selec", GetType(Boolean))
        'dt.Columns.Add("marca")

        'For Each i In lista
        '    dt.Rows.Add(i.codigodetalle, i.codigo, i.descripcionItem, i.unidad1, If(i.item IsNot Nothing, i.item.descripcion, String.Empty), i.tipoExistencia, i.origenProducto, If(i.estado = "A", "Activo", "Inactivo"), True, If(i.customMarca IsNot Nothing, i.customMarca.descripcion, String.Empty))
        '    'dt.Rows.Add(i.codigodetalle,
        '    '            i.codigo,
        '    '            i.descripcionItem,
        '    '            i.unidad1,
        '    '            i.NomClasificacion,
        '    '            i.tipoExistencia,
        '    '            i.origenProducto,
        '    '            If(i.estado = "A", "Activo", "Inactivo"),
        '    '            True,
        '    '            i.NomMarca)
        'Next
        'GridProductos.DataSource = dt
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
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_PRODUCTO_Botón___, AutorizacionRolList) Then
            Dim r As Record = GridProductos.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim f As New frmNuevoServicioCons(Val(r.GetValue("codigo")))
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
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TextBuscarProduct_Click(sender As Object, e As EventArgs) Handles TextBuscarProduct.Click

    End Sub

    Private Sub TextBuscarProduct_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBuscarProduct.KeyDown
        Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If TextBuscarProduct.Text.Trim.Length > 2 Then
                    e.SuppressKeyPress = True
                    Select Case ChFiltro2.Checked
                        Case True
                            GetProductosContains(TextBuscarProduct.Text.Trim)
                        Case False
                            GetProductos(TextBuscarProduct.Text.Trim)
                    End Select

                Else
                    TextBuscarProduct.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ESTADO_PRODUCTO_Botón___, AutorizacionRolList) Then
            Dim r As Record = GridProductos.Table.CurrentRecord
            If r IsNot Nothing Then
                CambiarEstado("I")
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub CambiarEstado(estado As String)
        Dim itemSA As New servicioSA
        itemSA.CambiarEstadoItemServicio(New servicio With
                                 {
                                 .idServicio = GridProductos.Table.CurrentRecord.GetValue("codigo"),
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
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ESTADO_PRODUCTO_Botón___, AutorizacionRolList) Then
            Dim r As Record = GridProductos.Table.CurrentRecord
            If r IsNot Nothing Then
                CambiarEstado("A")
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub EliminarProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarProductoToolStripMenuItem.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ESTADO_PRODUCTO_Botón___, AutorizacionRolList) Then
            Dim r As Record = GridProductos.Table.CurrentRecord
            If r IsNot Nothing Then
                If MessageBox.Show("Va a eliminar el producto, esta seguro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    EliminarProductoSinInventario(r)
                End If
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub EliminarProductoSinInventario(r As Record)
        Dim articuloSA As New servicioSA
        Try
            articuloSA.EliminarServicio(New servicio With {.idServicio = r.GetValue("codigo")})
            r.Delete()
            MessageBox.Show("Producto eliminado del sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region


End Class
