Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCReporteFechaPeriodoCompra
#Region "Attributes"
    Dim filter As New GridExcelFilter()
    Public ListaCompras As List(Of documentocompra)
    Public UCReporteCompras As UCReporteCompras
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
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

#Region "Constructors"
    Public Sub New(fecha As Date, idEstablecimiento As Integer, form As UCReporteCompras)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCReporteCompras = form
        FormatoGrid()
        GetListaComprasPorDia(fecha, idEstablecimiento)
        HabilitarFiltrosExcel()
    End Sub

    Public Sub New(periodo As String, form As UCReporteCompras, idEstable As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCReporteCompras = form
        FormatoGrid()
        GetListaComprasPorTipo(periodo, idEstable)
        HabilitarFiltrosExcel()
    End Sub

    Public Sub New(be As documentocompra, tipoConsulta As String, form As UCReporteCompras)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCReporteCompras = form
        FormatoGrid()
        Select Case tipoConsulta
            Case "PERIODO"
                GetListaComprasPorTipo(be.fechaContable, be.idCentroCosto, be.usuarioActualizacion)
            Case "DIA"
                GetListaComprasPorDia(be.fechaDoc, be.idCentroCosto, be.usuarioActualizacion)
        End Select
        HabilitarFiltrosExcel()
    End Sub
#End Region

#Region "Methods"
    Private Sub HabilitarFiltrosExcel()
        dgPedidos.TopLevelGroupOptions.ShowFilterBar = True
        dgPedidos.NestedTableGroupOptions.ShowFilterBar = True
        dgPedidos.ChildGroupOptions.ShowFilterBar = True
        For Each col As GridColumnDescriptor In dgPedidos.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        filter.AllowResize = True
        filter.AllowFilterByColor = True
        filter.EnableDateFilter = True
        filter.EnableNumberFilter = True

        dgPedidos.OptimizeFilterPerformance = True
        dgPedidos.ShowNavigationBar = True
        filter.WireGrid(dgPedidos)
    End Sub

    Private Sub GetListaComprasPorTipo(period As String, idEstablecimiento As Integer)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))

        Dim str As String
        ListaCompras = DocumentoCompraSA.GetListarTodasCompras(New documentocompra With {.idCentroCosto = idEstablecimiento, .fechaContable = period}, "PERIODO")
        For Each i As documentocompra In ListaCompras
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(6) = "-"
                Case Else
                    dr(6) = i.NombreEntidad
            End Select

            dr(7) = FormatNumber(i.importeTotal, 2)
            dr(8) = i.monedaDoc
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault
                dr(9) = vendedor.Full_Name ' i.usuarioActualizacion
            End If
            dr(10) = "-"
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaComprasPorTipo(period As String, idEstablecimiento As Integer, IDUsuario As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))

        Dim str As String
        ListaCompras = DocumentoCompraSA.GetListarTodasCompras(New documentocompra With {.idCentroCosto = idEstablecimiento, .fechaContable = period}, "PERIODO").Where(Function(o) o.usuarioActualizacion = IDUsuario).ToList
        For Each i As documentocompra In ListaCompras
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(6) = "-"
                Case Else
                    dr(6) = i.NombreEntidad
            End Select

            dr(7) = FormatNumber(i.importeTotal, 2)
            dr(8) = i.monedaDoc
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault
                dr(9) = vendedor.Full_Name ' i.usuarioActualizacion
            End If
            dr(10) = "-"
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaComprasPorDia(fechaLaboral As Date, idEstable As Integer, IDUsuario As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras del día - " & fechaLaboral)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))

        Dim str As String
        ListaCompras = DocumentoCompraSA.GetListarTodasCompras(New documentocompra With {.idCentroCosto = idEstable, .fechaDoc = fechaLaboral}, "DIA").Where(Function(o) o.usuarioActualizacion = IDUsuario).ToList
        For Each i As documentocompra In ListaCompras
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(6) = "-"
                Case Else
                    dr(6) = i.NombreEntidad
            End Select

            dr(7) = FormatNumber(i.importeTotal, 2)
            dr(8) = i.monedaDoc
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault
                dr(9) = vendedor.Full_Name ' i.usuarioActualizacion
            End If
            dr(10) = "-"
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaComprasPorDia(fechaLaboral As Date, idEstable As Integer)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras del día - " & fechaLaboral)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))

        Dim str As String
        ListaCompras = DocumentoCompraSA.GetListarTodasCompras(New documentocompra With {.idCentroCosto = idEstable, .fechaDoc = fechaLaboral}, "DIA")
        For Each i As documentocompra In ListaCompras
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(6) = "-"
                Case Else
                    dr(6) = i.NombreEntidad
            End Select

            dr(7) = FormatNumber(i.importeTotal, 2)
            dr(8) = i.monedaDoc
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault
                dr(9) = vendedor.Full_Name ' i.usuarioActualizacion
            End If
            dr(10) = "-"
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            UCReporteCompras.PictureLoad.Visible = False
            SumatoriaGeneral()
        End If
    End Sub

    Private Sub SumatoriaGeneral()
        Dim ventasFull = ListaCompras.Sum(Function(o) o.importeTotal).GetValueOrDefault
        Dim ventasContado = ListaCompras.Where(Function(o) o.estadoPago = TIPO_COMPRA.PAGO.PAGADO).Sum(Function(o) o.importeTotal).GetValueOrDefault

        Dim ventasCredito = ListaCompras.Where(Function(o) o.estadoPago <> TIPO_COMPRA.PAGO.PAGADO).Sum(Function(o) o.importeTotal).GetValueOrDefault

        UCReporteCompras.LabelTotalVentas.Text = $"S/{CDec(ventasFull).ToString("N2")}"
        UCReporteCompras.LabelAlContado.Text = $"S/{CDec(ventasContado).ToString("N2")}"
        UCReporteCompras.LabelAlCredito.Text = $"S/{CDec(ventasCredito).ToString("N2")}"
    End Sub
#End Region

End Class
