Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Public Class UCVentaProductosAcumulado
#Region "Attributes"
    Public ListaVentas As List(Of documentoventaAbarrotesDet)
    Public UCResumenVentasCustom As UCResumenVentasCustom
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructors"
    Public Sub New(be As documentoventaAbarrotes, tipoConsulta As String, form As UCResumenVentasCustom)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid()
        UCResumenVentasCustom = form
        Select Case tipoConsulta
            Case "PERIODO"
                GetListaVentasPorTipo(be.fechaPeriodo, be.idEstablecimiento, be.usuarioActualizacion)
            Case "DIA"
                GetListaVentasPorDia(be.fechaDoc, be.idEstablecimiento, be.usuarioActualizacion)
        End Select
    End Sub
#End Region

#Region "Formato GRID"
    Private Sub FormatoGrid()
        Me.dgPedidos.Appearance.ColumnHeaderCell.Interior = New BrushInfo(GradientStyle.Vertical, Color.Black, Color.Black)
        Me.dgPedidos.TopLevelGroupOptions.ShowCaption = False
        Dim colorF As GridMetroColors = New GridMetroColors()
        colorF.HeaderColor.NormalColor = Color.Black
        colorF.HeaderColor.HoverColor = Color.Empty
        Me.dgPedidos.SetMetroStyle(colorF)
        Me.dgPedidos.AllowProportionalColumnSizing = False
        Me.dgPedidos.DisplayVerticalLines = False
        Me.dgPedidos.BrowseOnly = True
        Me.dgPedidos.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        Me.dgPedidos.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        Me.dgPedidos.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Me.dgPedidos.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        Me.dgPedidos.TableOptions.ShowRowHeader = False
        Me.dgPedidos.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(30, 30, 30))
        Dim captionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Me.dgPedidos.Table.DefaultRecordRowHeight = 30
        Me.dgPedidos.Table.DefaultColumnHeaderRowHeight = 35
        Me.dgPedidos.Appearance.AnyCell.TextColor = Color.White
        Me.dgPedidos.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        Me.dgPedidos.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        Me.dgPedidos.TableDescriptor.Appearance.AnyCell.Borders.Bottom = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.dgPedidos.TableDescriptor.Appearance.AnyCell.Borders.Right = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.dgPedidos.TableDescriptor.Appearance.AnyHeaderCell.Borders.Top = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.dgPedidos.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.dgPedidos.TableControl.MetroColorTable.ScrollerBackground = Color.FromArgb(45, 45, 45)
        Me.dgPedidos.TableControl.MetroColorTable.ArrowNormal = Color.FromArgb(195, 195, 195)
        Me.dgPedidos.TableControl.MetroColorTable.ArrowChecked = Color.FromArgb(94, 171, 222)
        Me.dgPedidos.TableControl.MetroColorTable.ThumbNormal = Color.FromArgb(31, 31, 31)
        Me.dgPedidos.TableControl.MetroColorTable.ThumbPushed = Color.FromArgb(94, 171, 222)
        Me.dgPedidos.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled
    End Sub
#End Region

#Region "Methods"
    Private Sub SumatoriaGeneral()
        Dim ventasFull = ListaVentas.Sum(Function(o) o.importeMN).GetValueOrDefault

        UCResumenVentasCustom.LabelTotalVentas.Text = $"S/{CDec(ventasFull).ToString("N2")}"
        UCResumenVentasCustom.LabelAlContado.Text = "S/0.00"
        UCResumenVentasCustom.LabelAlCredito.Text = "S/0.00"
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            UCResumenVentasCustom.PictureLoad.Visible = False
            SumatoriaGeneral()
        End If
    End Sub

    Private Sub GetListaVentasPorTipo(period As String, idEstablecimiento As Integer, IDUsuario As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("afectacion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))

        ListaVentas = DocumentoVentaSA.GetListarTodasVentasProductosAcumulado(New documentoventaAbarrotes With {.idEstablecimiento = idEstablecimiento, .fechaPeriodo = period}, "PERIODO")
        For Each i As documentoventaAbarrotesDet In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.nombreItem
            dr(1) = i.destino
            dr(2) = i.monto1
            dr(3) = "-"
            dr(4) = i.importeMN
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorDia(fechaLaboral As Date, idEstable As Integer, IDUsuario As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas del día - " & fechaLaboral)
        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("afectacion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))


        ListaVentas = DocumentoVentaSA.GetListarTodasVentasProductosAcumulado(New documentoventaAbarrotes With {.idEstablecimiento = idEstable, .fechaDoc = fechaLaboral}, "DIA")
        For Each i As documentoventaAbarrotesDet In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.nombreItem
            dr(1) = i.destino
            dr(2) = i.monto1
            dr(3) = "-"
            dr(4) = i.importeMN
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub
#End Region
End Class
