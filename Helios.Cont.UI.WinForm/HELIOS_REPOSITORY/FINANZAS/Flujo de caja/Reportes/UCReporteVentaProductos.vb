Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Windows.Forms.Grid
Public Class UCReporteVentaProductos
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

                Select Case be.tipoDocumento
                    Case "-TODOS-"
                        GetListaVentasPorTipo(be.fechaPeriodo, be.idEstablecimiento, be.usuarioActualizacion)

                    Case "FACTURA"
                        GetListarTodasVentasProductosTipoDoc(be.fechaPeriodo, be.idEstablecimiento, be.usuarioActualizacion, "01")
                    Case "BOLETA"
                        GetListarTodasVentasProductosTipoDoc(be.fechaPeriodo, be.idEstablecimiento, be.usuarioActualizacion, "03")
                    Case "NOTA"
                        GetListarTodasVentasProductosTipoDoc(be.fechaPeriodo, be.idEstablecimiento, be.usuarioActualizacion, "9907")

                End Select


            Case "DIA"

                Select Case be.tipoDocumento


                    Case "-TODOS-"
                        GetListaVentasPorDia(be.fechaDoc, be.idEstablecimiento, be.usuarioActualizacion)

                    Case "FACTURA"
                        GetListaVentasPorDiaTipoDoc(be.fechaDoc, be.idEstablecimiento, be.usuarioActualizacion, "01")
                    Case "BOLETA"
                        GetListaVentasPorDiaTipoDoc(be.fechaDoc, be.idEstablecimiento, be.usuarioActualizacion, "03")
                    Case "NOTA"
                        GetListaVentasPorDiaTipoDoc(be.fechaDoc, be.idEstablecimiento, be.usuarioActualizacion, "9907")
                End Select

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
        '   Me.dgPedidos.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled
    End Sub
#End Region

#Region "Methods"
    Private Sub SumatoriaGeneral()
        Dim ventasFull = ListaVentas.Sum(Function(o) o.importeMN).GetValueOrDefault

        UCResumenVentasCustom.LabelTotalVentas.Text = $"S/{CDec(ventasFull).ToString("N2")}"
        UCResumenVentasCustom.LabelAlContado.Text = "S/0.00"
        UCResumenVentasCustom.LabelAlCredito.Text = "S/0.00"

        Dim ventasStock = ListaVentas.Where(Function(o) o.estadoMovimiento = "True").Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim ventasSinStock = ListaVentas.Where(Function(o) o.estadoMovimiento = "False").Sum(Function(o) o.importeMN).GetValueOrDefault

        UCResumenVentasCustom.LabelTotalConStock.Text = ventasStock.ToString("N2")
        UCResumenVentasCustom.LabelTotalSinStock.Text = ventasSinStock.ToString("N2")
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

    'sdfsd
    Private Sub GetListaVentasPorDiaTipoDoc(fechaLaboral As Date, idEstable As Integer, IDUsuario As String, tipoDoc As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas del día - " & fechaLaboral)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        dt.Columns.Add(New DataColumn("nomDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("docClie", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("afectacion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("valorventa", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("iva", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("preciounitario", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("AfectaStock", GetType(String)))

        Dim str As String
        ListaVentas = DocumentoVentaSA.GetListarTodasVentasProductosTipoDoc(New documentoventaAbarrotes With {.idEstablecimiento = idEstable, .fechaDoc = fechaLaboral, .tipoDocumento = tipoDoc}, "DIA")

        For Each i As documentoventaAbarrotesDet In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.documentoventaAbarrotes.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.documentoventaAbarrotes.idDocumento


            If i.documentoventaAbarrotes.tipoDocumento = "01" Then
                dr(1) = "FACTURA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "03" Then
                dr(1) = "BOLETA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "07" Then
                dr(1) = "NOTA CREDITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "08" Then
                dr(1) = "NOTA DEBITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "9907" Then
                dr(1) = "NOTA VENTA"

            End If



            dr(2) = i.documentoventaAbarrotes.serieVenta
            dr(3) = i.documentoventaAbarrotes.numeroVenta

            dr(4) = i.documentoventaAbarrotes.NroDocEntidad


            dr(5) = i.documentoventaAbarrotes.NombreEntidad



            dr(6) = i.documentoventaAbarrotes.tipoVenta
            dr(7) = str
            dr(8) = i.documentoventaAbarrotes.tipoDocumento
            dr(9) = i.nombreItem
            dr(10) = i.destino
            dr(11) = i.monto1
            dr(12) = i.unidad1
            dr(13) = i.montokardex
            dr(14) = i.montoIgv
            If i.importeMN > 0 Then
                dr(15) = (i.importeMN / i.monto1)
            Else
                dr(15) = 0
            End If
            dr(16) = i.importeMN
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault
                dr(17) = vendedor.Full_Name
            End If
            dr(18) = If(i.estadoMovimiento = "True", "SI", "NO")
            dt.Rows.Add(dr)
        Next


        'For Each i As documentoventaAbarrotesDet In ListaVentas
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.documentoventaAbarrotes.fechaDoc).ToString("dd-MMM hh:mm tt ")
        '    dr(0) = i.documentoventaAbarrotes.idDocumento
        '    dr(1) = i.documentoventaAbarrotes.tipoVenta
        '    dr(2) = str
        '    dr(3) = i.documentoventaAbarrotes.tipoDocumento
        '    dr(4) = i.nombreItem
        '    dr(5) = i.destino
        '    dr(6) = i.monto1
        '    dr(7) = i.unidad1
        '    dr(8) = i.montokardex
        '    dr(9) = i.montoIgv

        '    If i.importeMN > 0 Then
        '        dr(10) = (i.importeMN / i.monto1)
        '    Else

        '        dr(10) = 0
        '    End If
        '    dr(11) = i.importeMN
        '    If UsuariosList IsNot Nothing Then
        '        Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault
        '        dr(12) = vendedor.Full_Name
        '    End If
        '    dr(13) = If(i.estadoMovimiento = "True", "SI", "NO")
        '    dt.Rows.Add(dr)
        'Next
        setDatasource(dt)
    End Sub


    Private Sub GetListarTodasVentasProductosTipoDoc(period As String, idEstablecimiento As Integer, IDUsuario As String, tipoDoc As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        dt.Columns.Add(New DataColumn("nomDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("docClie", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("afectacion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("valorventa", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("iva", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("preciounitario", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("AfectaStock", GetType(String)))
        Dim str As String
        ListaVentas = DocumentoVentaSA.GetListarTodasVentasProductosTipoDoc(New documentoventaAbarrotes With {.idEstablecimiento = idEstablecimiento, .fechaPeriodo = period, .tipoDocumento = tipoDoc}, "PERIODO")

        For Each i As documentoventaAbarrotesDet In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.documentoventaAbarrotes.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.documentoventaAbarrotes.idDocumento


            If i.documentoventaAbarrotes.tipoDocumento = "01" Then
                dr(1) = "FACTURA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "03" Then
                dr(1) = "BOLETA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "07" Then
                dr(1) = "NOTA CREDITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "08" Then
                dr(1) = "NOTA DEBITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "9907" Then
                dr(1) = "NOTA VENTA"

            End If



            dr(2) = i.documentoventaAbarrotes.serieVenta
            dr(3) = i.documentoventaAbarrotes.numeroVenta

            dr(4) = i.documentoventaAbarrotes.NroDocEntidad


            dr(5) = i.documentoventaAbarrotes.NombreEntidad



            dr(6) = i.documentoventaAbarrotes.tipoVenta
            dr(7) = str
            dr(8) = i.documentoventaAbarrotes.tipoDocumento
            dr(9) = i.nombreItem
            dr(10) = i.destino
            dr(11) = i.monto1
            dr(12) = i.unidad1
            dr(13) = i.montokardex
            dr(14) = i.montoIgv
            If i.importeMN > 0 Then
                dr(15) = (i.importeMN / i.monto1)
            Else
                dr(15) = 0
            End If
            dr(16) = i.importeMN
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault
                dr(17) = vendedor.Full_Name
            End If
            dr(18) = If(i.estadoMovimiento = "True", "SI", "NO")
            dt.Rows.Add(dr)
        Next

        'For Each i As documentoventaAbarrotesDet In ListaVentas
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.documentoventaAbarrotes.fechaDoc).ToString("dd-MMM hh:mm tt ")
        '    dr(0) = i.documentoventaAbarrotes.idDocumento

        '    If i.documentoventaAbarrotes.tipoDocumento = "01" Then
        '        dr(1) = "FACTURA"
        '    ElseIf i.documentoventaAbarrotes.tipoDocumento = "03" Then
        '        dr(1) = "BOLETA"
        '    ElseIf i.documentoventaAbarrotes.tipoDocumento = "07" Then
        '        dr(1) = "NOTA CREDITO"
        '    ElseIf i.documentoventaAbarrotes.tipoDocumento = "08" Then
        '        dr(1) = "NOTA DEBITO"
        '    ElseIf i.documentoventaAbarrotes.tipoDocumento = "9907" Then
        '        dr(1) = "NOTA"

        '    End If


        '    dr(2) = i.documentoventaAbarrotes.tipoVenta
        '    dr(3) = str
        '    dr(4) = i.documentoventaAbarrotes.tipoDocumento
        '    dr(5) = i.nombreItem
        '    dr(6) = i.destino
        '    dr(7) = i.monto1
        '    dr(8) = i.unidad1
        '    dr(9) = i.montokardex
        '    dr(10) = i.montoIgv
        '    If i.importeMN > 0 Then
        '        dr(11) = (i.importeMN / i.monto1)
        '    Else

        '        dr(11) = 0
        '    End If
        '    dr(12) = i.importeMN
        '    If UsuariosList IsNot Nothing Then
        '        Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault
        '        dr(13) = vendedor.Full_Name
        '    End If
        '    dr(14) = If(i.estadoMovimiento = "True", "SI", "NO")
        '    dt.Rows.Add(dr)
        'Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorTipo(period As String, idEstablecimiento As Integer, IDUsuario As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))


        dt.Columns.Add(New DataColumn("nomDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))


        dt.Columns.Add(New DataColumn("docClie", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("afectacion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("valorventa", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("iva", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("preciounitario", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("AfectaStock", GetType(String)))
        Dim str As String
        ListaVentas = DocumentoVentaSA.GetListarTodasVentasProductos(New documentoventaAbarrotes With {.idEstablecimiento = idEstablecimiento, .fechaPeriodo = period}, "PERIODO")
        For Each i As documentoventaAbarrotesDet In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.documentoventaAbarrotes.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.documentoventaAbarrotes.idDocumento


            If i.documentoventaAbarrotes.tipoDocumento = "01" Then
                dr(1) = "FACTURA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "03" Then
                dr(1) = "BOLETA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "07" Then
                dr(1) = "NOTA CREDITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "08" Then
                dr(1) = "NOTA DEBITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "9907" Then
                dr(1) = "NOTA VENTA"

            End If



            dr(2) = i.documentoventaAbarrotes.serieVenta
            dr(3) = i.documentoventaAbarrotes.numeroVenta

            dr(4) = i.documentoventaAbarrotes.NroDocEntidad


            dr(5) = i.documentoventaAbarrotes.NombreEntidad



            dr(6) = i.documentoventaAbarrotes.tipoVenta
            dr(7) = str
            dr(8) = i.documentoventaAbarrotes.tipoDocumento
            dr(9) = i.nombreItem
            dr(10) = i.destino
            dr(11) = i.monto1
            dr(12) = i.unidad1
            dr(13) = i.montokardex
            dr(14) = i.montoIgv
            If i.importeMN > 0 Then
                dr(15) = (i.importeMN / i.monto1)
            Else
                dr(15) = 0
            End If
            dr(16) = i.importeMN
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault
                dr(17) = vendedor.Full_Name
            End If
            dr(18) = If(i.estadoMovimiento = "True", "SI", "NO")
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorDia(fechaLaboral As Date, idEstable As Integer, IDUsuario As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas del día - " & fechaLaboral)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        dt.Columns.Add(New DataColumn("nomDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("docClie", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("afectacion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))
        dt.Columns.Add(New DataColumn("valorventa", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("iva", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("preciounitario", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("AfectaStock", GetType(String)))

        Dim str As String
        ListaVentas = DocumentoVentaSA.GetListarTodasVentasProductos(New documentoventaAbarrotes With {.idEstablecimiento = idEstable, .fechaDoc = fechaLaboral}, "DIA")

        For Each i As documentoventaAbarrotesDet In ListaVentas
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.documentoventaAbarrotes.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.documentoventaAbarrotes.idDocumento


            If i.documentoventaAbarrotes.tipoDocumento = "01" Then
                dr(1) = "FACTURA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "03" Then
                dr(1) = "BOLETA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "07" Then
                dr(1) = "NOTA CREDITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "08" Then
                dr(1) = "NOTA DEBITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "9907" Then
                dr(1) = "NOTA VENTA"

            End If



            dr(2) = i.documentoventaAbarrotes.serieVenta
            dr(3) = i.documentoventaAbarrotes.numeroVenta

            dr(4) = i.documentoventaAbarrotes.NroDocEntidad


            dr(5) = i.documentoventaAbarrotes.NombreEntidad



            dr(6) = i.documentoventaAbarrotes.tipoVenta
            dr(7) = str
            dr(8) = i.documentoventaAbarrotes.tipoDocumento
            dr(9) = i.nombreItem
            dr(10) = i.destino
            dr(11) = i.monto1
            dr(12) = i.unidad1
            dr(13) = i.montokardex
            dr(14) = i.montoIgv
            If i.importeMN > 0 Then
                dr(15) = (i.importeMN / i.monto1)
            Else
                dr(15) = 0
            End If
            dr(16) = i.importeMN
            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault
                dr(17) = vendedor.Full_Name
            End If
            dr(18) = If(i.estadoMovimiento = "True", "SI", "NO")
            dt.Rows.Add(dr)
        Next


        'For Each i As documentoventaAbarrotesDet In ListaVentas
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.documentoventaAbarrotes.fechaDoc).ToString("dd-MMM hh:mm tt ")
        '    dr(0) = i.documentoventaAbarrotes.idDocumento

        '    If i.documentoventaAbarrotes.tipoDocumento = "01" Then
        '        dr(1) = "FACTURA"
        '    ElseIf i.documentoventaAbarrotes.tipoDocumento = "03" Then
        '        dr(1) = "BOLETA"
        '    ElseIf i.documentoventaAbarrotes.tipoDocumento = "07" Then
        '        dr(1) = "NOTA CREDITO"
        '    ElseIf i.documentoventaAbarrotes.tipoDocumento = "08" Then
        '        dr(1) = "NOTA DEBITO"
        '    ElseIf i.documentoventaAbarrotes.tipoDocumento = "9907" Then
        '        dr(1) = "NOTA"

        '    End If


        '    dr(2) = i.documentoventaAbarrotes.tipoVenta
        '    dr(3) = str
        '    dr(4) = i.documentoventaAbarrotes.tipoDocumento
        '    dr(5) = i.nombreItem
        '    dr(6) = i.destino
        '    dr(7) = i.monto1
        '    dr(8) = i.unidad1
        '    dr(8) = i.montokardex
        '    dr(9) = i.montoIgv
        '    If i.importeMN > 0 Then
        '        dr(10) = (i.importeMN / i.monto1)
        '    Else
        '        dr(10) = 0
        '    End If
        '    dr(11) = i.importeMN
        '    If UsuariosList IsNot Nothing Then
        '        Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault
        '        dr(12) = vendedor.Full_Name
        '    End If
        '    dr(13) = If(i.estadoMovimiento = "True", "SI", "NO")
        '    dt.Rows.Add(dr)
        'Next
        setDatasource(dt)
    End Sub
#End Region

#Region "Events"

#End Region
End Class
