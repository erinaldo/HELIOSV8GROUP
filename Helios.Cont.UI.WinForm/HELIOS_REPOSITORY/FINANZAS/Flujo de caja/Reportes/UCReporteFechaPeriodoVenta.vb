Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Windows.Forms.Grid
Public Class UCReporteFechaPeriodoVenta
#Region "Attributes"
    Public ListaVentas As List(Of documentoventaAbarrotes)

    Public UCResumenVentasCustom As UCResumenVentasCustom
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

    Public Sub New(fecha As Date, idEstablecimiento As Integer, form As UCResumenVentasCustom)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCResumenVentasCustom = form
        FormatoGrid()
        GetListaVentasPorDia(fecha, idEstablecimiento)

    End Sub

    Public Sub New(periodo As String, form As UCResumenVentasCustom, idEstable As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCResumenVentasCustom = form
        FormatoGrid()
        GetListaVentasPorTipo(periodo, idEstable)
    End Sub

    Public Sub New(be As documentoventaAbarrotes, tipoConsulta As String, form As UCResumenVentasCustom)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCResumenVentasCustom = form
        FormatoGrid()
        Select Case tipoConsulta
            Case "PERIODO"
                GetListaVentasPorTipo(be.fechaPeriodo, be.idEstablecimiento, be.usuarioActualizacion)
            Case "DIA"
                GetListaVentasPorDia(be.fechaDoc, be.idEstablecimiento, be.usuarioActualizacion)
        End Select
    End Sub


#End Region

#Region "Methods"
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

    Private Sub SumatoriaGeneral()
        Dim ventasFull = ListaVentas.Sum(Function(o) o.ImporteNacional).GetValueOrDefault
        Dim ventasContado = ListaVentas.Where(Function(o) o.estadoCobro = TIPO_VENTA.PAGO.COBRADO).Sum(Function(o) o.ImporteNacional).GetValueOrDefault

        Dim ventasCredito = ListaVentas.Where(Function(o) o.estadoCobro <> TIPO_VENTA.PAGO.COBRADO).Sum(Function(o) o.ImporteNacional).GetValueOrDefault

        UCResumenVentasCustom.LabelTotalVentas.Text = $"S/{CDec(ventasFull).ToString("N2")}"
        UCResumenVentasCustom.LabelAlContado.Text = $"S/{CDec(ventasContado).ToString("N2")}"
        UCResumenVentasCustom.LabelAlCredito.Text = $"S/{CDec(ventasCredito).ToString("N2")}"
    End Sub

    Private Sub GetListaVentasPorTipo(period As String, idEstablecimiento As Integer)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
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
        Dim tipoDoc As String = String.Empty
        Select Case UCResumenVentasCustom.ComboComprobante.Text
            Case "-TODOS-"
                tipoDoc = "0"
            Case "FACTURA"
                tipoDoc = "01"
            Case "BOLETA"
                tipoDoc = "03"
            Case "NOTA"
                tipoDoc = "9907"
        End Select
        ListaVentas = DocumentoVentaSA.GetListarTodasVentas(New documentoventaAbarrotes With
                                                            {
                                                            .idEstablecimiento = idEstablecimiento,
                                                            .tipoDocumento = tipoDoc,
                                                            .fechaPeriodo = period
                                                            }, "PERIODO")
        For Each i As documentoventaAbarrotes In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.tipoDocumento
            dr(4) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(5) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(5) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(5) = i.numeroVenta
                Case "NTC"
                    dr(5) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(5) = i.numeroDoc
                Case Else
                    dr(5) = i.numeroVenta
            End Select

            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(6) = "-"
                Case Else
                    dr(6) = i.NombreEntidad
            End Select

            dr(7) = FormatNumber(i.ImporteNacional, 2)
            dr(8) = i.moneda

            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault
                dr(9) = vendedor.Full_Name ' i.usuarioActualizacion
            End If


            dr(10) = i.EnvioSunat
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorTipo(period As String, idEstablecimiento As Integer, IDUsuario As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
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
        ListaVentas = DocumentoVentaSA.GetListarTodasVentas(New documentoventaAbarrotes With {.idEstablecimiento = idEstablecimiento, .fechaPeriodo = period, .tipoDocumento = "1000"}, "PERIODO").Where(Function(o) o.usuarioActualizacion = IDUsuario).ToList
        For Each i As documentoventaAbarrotes In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.tipoDocumento
            dr(4) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(5) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(5) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(5) = i.numeroVenta
                Case "NTC"
                    dr(5) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(5) = i.numeroDoc
                Case Else
                    dr(5) = i.numeroVenta
            End Select

            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(6) = "-"
                Case Else
                    dr(6) = i.NombreEntidad
            End Select

            dr(7) = FormatNumber(i.ImporteNacional, 2)
            dr(8) = i.moneda

            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault
                dr(9) = vendedor.Full_Name ' i.usuarioActualizacion
            End If


            dr(10) = i.EnvioSunat
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorDia(fechaLaboral As Date, idEstable As Integer)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas del día - " & fechaLaboral)
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
        Dim tipoDoc As String = String.Empty
        Select Case UCResumenVentasCustom.ComboComprobante.Text
            Case "-TODOS-"
                tipoDoc = "0"
            Case "FACTURA"
                tipoDoc = "01"
            Case "BOLETA"
                tipoDoc = "03"
            Case "NOTA"
                tipoDoc = "9907"
        End Select

        ListaVentas = DocumentoVentaSA.GetListarTodasVentas(New documentoventaAbarrotes With
                                                            {
                                                            .idEstablecimiento = idEstable,
                                                            .tipoDocumento = tipoDoc,
                                                            .fechaDoc = fechaLaboral
                                                            }, "DIA")
        For Each i As documentoventaAbarrotes In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.tipoDocumento
            dr(4) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(5) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(5) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(5) = i.numeroVenta
                Case "NTC"
                    dr(5) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(5) = i.numeroDoc
                Case Else
                    dr(5) = i.numeroVenta
            End Select

            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(6) = "-"
                Case Else
                    dr(6) = i.NombreEntidad
            End Select

            dr(7) = FormatNumber(i.ImporteNacional, 2)
            dr(8) = i.moneda
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault
                dr(9) = vendedor.Full_Name ' i.usuarioActualizacion
            End If
            dr(10) = i.EnvioSunat

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorDia(fechaLaboral As Date, idEstable As Integer, IDUsuario As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas del día - " & fechaLaboral)
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
        ListaVentas = DocumentoVentaSA.GetListarTodasVentas(New documentoventaAbarrotes With {.idEstablecimiento = idEstable, .fechaDoc = fechaLaboral, .tipoDocumento = "1000"}, "DIA").Where(Function(o) o.usuarioActualizacion = IDUsuario).ToList
        For Each i As documentoventaAbarrotes In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.tipoDocumento
            dr(4) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(5) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(5) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(5) = i.numeroVenta
                Case "NTC"
                    dr(5) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(5) = i.numeroDoc
                Case Else
                    dr(5) = i.numeroVenta
            End Select

            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(6) = "-"
                Case Else
                    dr(6) = i.NombreEntidad
            End Select

            dr(7) = FormatNumber(i.ImporteNacional, 2)
            dr(8) = i.moneda
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault
                dr(9) = vendedor.Full_Name ' i.usuarioActualizacion
            End If
            dr(10) = i.EnvioSunat
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub
#End Region

#Region "Events"

#End Region
End Class
