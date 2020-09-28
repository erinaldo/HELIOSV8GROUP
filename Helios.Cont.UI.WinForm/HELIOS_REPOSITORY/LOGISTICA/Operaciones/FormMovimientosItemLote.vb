Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Helios.Cont.WCFService.ServiceAccess
Imports System.Runtime.Serialization
Imports Syncfusion.Windows.Forms

Public Class FormMovimientosItemLote
    Private lista As List(Of InventarioMovimiento)
    Public Property CustomVenta As documentoventaAbarrotes

#Region "Constructors"
    Public Sub New(be As documentoventaAbarrotes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FormatoGrid(GridGroupingControl1)
        FormatoGrid2(dgvcompras)
        GetDetalleVenta(be)

        'Merge Cell based on the cell content.
        Me.dgvcompras.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation Or GridMergeCellsMode.MergeRowsInColumn
        Me.dgvcompras.TableDescriptor.Columns("iddocumento").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.RowsInColumn
        Me.dgvcompras.TableDescriptor.Columns("fecha").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.RowsInColumn
        'Me.dgvcompras.TableDescriptor.Columns("tipoOperacion").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.RowsInColumn
        'Me.dgvcompras.TableDescriptor.Columns("Comprobante").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.RowsInColumn
        Me.dgvcompras.TableDescriptor.Columns("numero").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.RowsInColumn

        'dgvcompras.TableDescriptor.SortedColumns.Add("iddocumento")
        ' AddHandler dgvcompras.TableModel.QueryCanMergeCells, AddressOf TableModel_QueryCanMergeCells
        GridGroupingControl1.TableModel.CellModels.Clear()
        GridGroupingControl1.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(GridGroupingControl1.TableModel))
        GridGroupingControl1.TableDescriptor.Columns("cantidad").Appearance.AnyRecordFieldCell.CellType = "LinkLabelCell"

        Me.dgvcompras.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(dgvcompras.TableModel))
        dgvcompras.TableDescriptor.Columns("numero").Appearance.AnyRecordFieldCell.CellType = "LinkLabelCell"
        BunifuFlatButton6.Enabled = True
    End Sub
#End Region

#Region "Class LinkLabel"
    Public Class LinkLabelCellModel
        Inherits GridStaticCellModel

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Sub New(ByVal grid As GridModel)
            MyBase.New(grid)
        End Sub

        Public Overrides Function CreateRenderer(ByVal control As GridControlBase) As GridCellRendererBase
            Return New LinkLabelCellRenderer(control, Me)
        End Function
    End Class

    Public Class LinkLabelCellRenderer
        Inherits GridStaticCellRenderer

        Private _isMouseDown As Boolean
        Private _drawHotLink As Boolean
        Private _hotColor As Color
        Private _visitedColor As Color
        Private _EXEname As String

        Public Sub New(ByVal grid As GridControlBase, ByVal cellModel As GridCellModelBase)
            MyBase.New(grid, cellModel)
            _isMouseDown = False
            _drawHotLink = False
            _hotColor = Color.Red
            _visitedColor = Color.Purple
            _EXEname = "iexplore.exe"
        End Sub

        Public Property VisitedLinkColor As Color
            Get
                Return _visitedColor
            End Get
            Set(ByVal value As Color)
                _visitedColor = value
            End Set
        End Property

        Public Property ActiveLinkColor As Color
            Get
                Return _hotColor
            End Get
            Set(ByVal value As Color)
                _hotColor = value
            End Set
        End Property

        Public Property EXEname As String
            Get
                Return _EXEname
            End Get
            Set(ByVal value As String)
                _EXEname = value
            End Set
        End Property

        Private Sub DrawLink(ByVal useHotColor As Boolean, ByVal rowIndex As Integer, ByVal colIndex As Integer)
            If useHotColor Then _drawHotLink = True
            Me.Grid.RefreshRange(GridRangeInfo.Cell(rowIndex, colIndex), GridRangeOptions.None)
            _drawHotLink = False
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(rowIndex, colIndex, e)
            DrawLink(True, rowIndex, colIndex)
            _isMouseDown = True
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(rowIndex, colIndex, e)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(New Point(e.X, e.Y), row, col)

            If row = rowIndex AndAlso col = colIndex Then
                Dim style As GridStyleInfo = Me.Grid.Model(row, col)
                style.TextColor = VisitedLinkColor
            End If

            DrawLink(False, rowIndex, colIndex)
            _isMouseDown = False
        End Sub

        Protected Overrides Sub OnCancelMode(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnCancelMode(rowIndex, colIndex)
            _isMouseDown = False
            _drawHotLink = False
        End Sub

        Protected Overrides Function OnGetCursor(ByVal rowIndex As Integer, ByVal colIndex As Integer) As System.Windows.Forms.Cursor
            Dim pt As Point = Me.Grid.PointToClient(Cursor.Position)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(pt, row, col)
            Return If((row = rowIndex AndAlso col = colIndex), Cursors.Hand, If((Me._isMouseDown), Cursors.No, MyBase.OnGetCursor(rowIndex, colIndex)))
        End Function

        Protected Overrides Function OnHitTest(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As MouseEventArgs, ByVal controller As IMouseController) As Integer
            If controller IsNot Nothing AndAlso controller.Name = "OleDataSource" Then Return 0
            Return 1
        End Function

        Protected Overrides Sub OnDraw(ByVal g As System.Drawing.Graphics, ByVal clientRectangle As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal style As Syncfusion.Windows.Forms.Grid.GridStyleInfo)
            style.Font.Underline = True

            If _drawHotLink Then
                style.TextColor = ActiveLinkColor
            End If

            MyBase.OnDraw(g, clientRectangle, rowIndex, colIndex, style)
        End Sub

        Protected Overrides Sub OnMouseHoverEnter(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnMouseHoverEnter(rowIndex, colIndex)
            DrawLink(True, rowIndex, colIndex)
        End Sub

        Protected Overrides Sub OnMouseHoverLeave(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.EventArgs)
            MyBase.OnMouseHoverLeave(rowIndex, colIndex, e)
            DrawLink(False, rowIndex, colIndex)
        End Sub
    End Class
#End Region

#Region "Methods"

    Private Sub EditarItemVentaMismoAlmacen(be As InventarioMovimiento)
        Dim inventario As New InventarioMovimiento
        Dim inventarioSA As New inventarioMovimientoSA

        inventario.idorigenDetalle = be.idorigenDetalle
        inventario.idDocumento = be.idDocumento
        inventario.fecha = CustomVenta.fechaDoc
        inventario.cantidad = be.cantidad
        inventario.nrolote = be.nrolote
        'inventario.precUnite = be.precUnite
        'inventario.monto = be.monto
        inventarioSA.editarTrasnferenciaItem(inventario)
        MessageBox.Show("Producto editado con exito!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub FormatoGrid(grid As GridGroupingControl)
        grid.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    End Sub

    Private Sub FormatoGrid2(grid As GridGroupingControl)
        grid.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = ColorTranslator.FromHtml("#FF97F4BB")
        grid.TableOptions.SelectionTextColor = Color.Black
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    End Sub

    Private Sub GetDetalleVenta(be As documentoventaAbarrotes)
        CustomVenta = be
        Dim inventarioSA As New inventarioMovimientoSA
        Dim dt As New DataTable
        dt.Columns.Add("secuencia")
        dt.Columns.Add("afectacion")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("pu")
        dt.Columns.Add("vv")
        dt.Columns.Add("iva")
        dt.Columns.Add("total")
        dt.Columns.Add("lote")
        Dim lista = inventarioSA.GetUbicar_InventarioMovimiento(be.idDocumento)

        For Each i In lista.Where(Function(o) o.tipoRegistro = "E").ToList 'be.documentoventaAbarrotesDet
            dt.Rows.Add(i.idorigenDetalle, i.destinoGravadoItem, i.idItem, i.descripcion, i.unidad, i.cantidad, 0, 0, 0, 0, i.nrolote)
        Next
        GridGroupingControl1.DataSource = dt
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim r As Record = GridGroupingControl1.Table.CurrentRecord
        If r IsNot Nothing Then
            GetDetalleLotes(r)
        End If
    End Sub

    Private Sub EliminarItemVenta(be As InventarioMovimiento)
        Dim inventarioSA As New inventarioMovimientoSA
        Dim obj As New InventarioMovimiento
        Try
            obj.idorigenDetalle = be.idorigenDetalle
            inventarioSA.EliminarItemOperation(obj)

            MessageBox.Show("Item eliminado correctamente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'obj.idInventario = be.idInventario

    End Sub

    Private Sub GetDetalleLotes(r As Record)
        Dim inventarioSA As New inventarioMovimientoSA
        lista = inventarioSA.GetMovimientosLote(New InventarioMovimiento With {.nrolote = r.GetValue("lote"), .fecha = CustomVenta.fechaDoc})

        Dim dt As New DataTable
        dt.Columns.Add("iddocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipoOperacion")
        dt.Columns.Add("Comprobante")
        dt.Columns.Add("numero")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("almacen")
        dt.Columns.Add("id")

        Dim tabla As String = String.Empty
        For Each i In lista.Where(Function(o) o.idDocumento <> CustomVenta.idDocumento).ToList
            Select Case i.tipoOperacion
                Case StatusTipoOperacion.TRANSFERENCIA_ENTRE_ALMACENES
                    tabla = "Transferencia entre almacenes"

                Case StatusTipoOperacion.COMPRA
                    tabla = "Compra"

                Case StatusTipoOperacion.OTRAS_ENTRADAS_A_ALMACEN
                    tabla = "Otra entrada"

                Case StatusTipoOperacion.OTRAS_SALIDAS_DE_ALMACEN
                    tabla = "Otra salida"
                Case StatusTipoOperacion.VENTA
                    tabla = "VEnta"
            End Select

            dt.Rows.Add(i.idDocumento, i.fecha, tabla, i.tipoDocAlmacen, i.numero, i.cantidad, i.NombreAlmacen, i.idorigenDetalle)
        Next
        dgvcompras.DataSource = dt
        dgvcompras.TableDescriptor.SortedColumns.Clear()
        dgvcompras.TableDescriptor.SortedColumns.Add("iddocumento")
        dgvcompras.Refresh()

        '    TextCantidadOrigen.Text = r.GetValue("cantidad")
        TextTotalSalidas.Text = lista.Where(Function(o) o.tipoRegistro = "S" And o.idDocumento <> CustomVenta.idDocumento).Sum(Function(o) o.cantidad).GetValueOrDefault

        Dim existeMovimientos = lista.Any(Function(o) o.tipoRegistro = "S" And o.idDocumento <> CustomVenta.idDocumento)

        If existeMovimientos Then
            TextRecomendacion.Text = ">=" & TextTotalSalidas.Text
            BunifuFlatButton1.Enabled = False
            Dim saldo = CDec(GridGroupingControl1.Table.CurrentRecord.GetValue("cantidad")) + CDec(TextTotalSalidas.Text)
            TextCantidadOrigen.Text = $"{saldo}/{TextCantidadOrigen.Text}"
        Else
            TextRecomendacion.Text = "Puede eliminar"
            BunifuFlatButton1.Enabled = True
        End If


        'Me.dgvcompras.TableDescriptor.Columns("iddocumento").Appearance.AnyRecordFieldCell.MergeCell = GridMergeCellDirection.Both
        'Me.dgvcompras.TableModel.Options.MergeCellsMode = GridMergeCellsMode.OnDemandCalculation

        ''Sets the range of cells.
        'Me.dgvcompras.TableModel.Options.MergeCellsLayout = GridMergeCellsLayout.Grid
    End Sub

    Private Sub dgvcompras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvcompras.TableControlCellClick

    End Sub

    Private Sub TableModel_QueryCanMergeCells(ByVal sender As Object, ByVal e As GridQueryCanMergeCellsEventArgs)

        ' Checking whether it is already merged cells
        If Not e.Result Then

            ' Sets merging for two columns with different data
            If e.Style1.CellIdentity.ColIndex = 1 Then
                e.Result = True
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCellClick
        Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        Dim obj As InventarioMovimiento
        If style3.Enabled Then
            If style3.TableCellIdentity.Column.Name = "cantidad" Then
                '       e.Inner.Cancel = True
                Dim disponible As Decimal = 0 ' Decimal.Parse(style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("disponible").ToString()) 'Decimal.Parse(r.GetValue("disponible"))
                'Dim value As String = style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                Dim cantidad = InputBox("Rango disponible de [0 - " & disponible & "]", "Cantidad", 0)

                If cantidad.ToString.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.GridGroupingControl1.TableModel(e.Inner.RowIndex, 4).CellValue = 0

                    Exit Sub
                End If

                If IsNumeric(cantidad) Then
                    'If cantidad > 0 Then
                    'If cantidad > disponible Then
                    '        MessageBox.Show("Ingrese un cantidad menor o igual a: " & disponible, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        Me.GridGroupingControl1.TableModel(e.Inner.RowIndex, 4).CellValue = 0

                    '    Else
                    Me.GridGroupingControl1.TableModel(e.Inner.RowIndex, 4).CellValue = Decimal.Parse(cantidad)

                    obj = New InventarioMovimiento
                    obj.idDocumento = CustomVenta.idDocumento
                    obj.fecha = CustomVenta.fechaDoc
                    obj.idorigenDetalle = Integer.Parse(GridGroupingControl1.Table.CurrentRecord.GetValue("secuencia"))
                    obj.nrolote = Integer.Parse(GridGroupingControl1.Table.CurrentRecord.GetValue("lote"))
                    obj.cantidad = Decimal.Parse(cantidad)
                    EditarItemVentaMismoAlmacen(obj)
                    'End If
                Else
                    'MessageBox.Show("Ingrese un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'Me.GridGroupingControl1.TableModel(e.Inner.RowIndex, 4).CellValue = 0
                    'Dim item = listaProductos.Where(Function(o) o.idInventario = value).SingleOrDefault
                    'item.cantidad = 0
                    'item.monto = 0
                End If


                'Else
                '    'Me.GridGroupingControl1.TableModel(e.Inner.RowIndex, 4).CellValue = 0
                '    'Dim item = listaProductos.Where(Function(o) o.idInventario = value).SingleOrDefault
                '    'item.cantidad = 0
                '    'item.monto = 0
                'End If

                'FormInventarioCanastaTotales = New FormInventarioCanastaTotales(cboalmacen.SelectedValue, nomproduct)
                'FormInventarioCanastaTotales.validaStocks = True
                'FormInventarioCanastaTotales.StartPosition = FormStartPosition.CenterScreen
                'FormInventarioCanastaTotales.Show(Me)
            End If

        End If
    End Sub

    Private Sub GridGroupingControl1_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridGroupingControl1.SelectedRecordsChanging
        If e.SelectedRecord IsNot Nothing Then
            Dim r As Record = e.SelectedRecord.Record
            If r IsNot Nothing Then
                TextCantidadOrigen.Text = r.GetValue("cantidad")
                TextTotalSalidas.Text = ""
                TextRecomendacion.Text = ""
            End If
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Dim r As Record = dgvcompras.Table.CurrentRecord
        If r IsNot Nothing Then
            EliminarItemVenta(New InventarioMovimiento With {.idorigenDetalle = Integer.Parse(r.GetValue("id"))})
        End If
    End Sub
#End Region

End Class