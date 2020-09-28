Imports System.Drawing.Drawing2D
Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms.Chart

Public Class frmTableroGeneral
#Region "Attributes"
    Public ResumenCaja As List(Of documentoCaja)
    Public ResumenCompras As List(Of documentocompra)
    Public cajaSA As New DocumentoCajaSA
    Public VentaSA As New documentoVentaAbarrotesSA
    Public CompraSA As New DocumentoCompraSA
    Public fso As FeedbackForm

    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of documentocompra),
                                          listaVenta As List(Of documentoventaAbarrotes))

    Friend Delegate Sub SetDataSourceDelegateLogistica(ByVal ResumenCompra As List(Of documentocompra))

    Friend Delegate Sub SetDataSourceDelegateComercial(ByVal ResumenVenta As List(Of documentoventaAbarrotes))

    Friend Delegate Sub SetDataSourceDelegateFinanzas(ByVal ResumenCaja As List(Of documentoCaja))

    Friend Delegate Sub SetDataSourceDelegateRentabilidad(ByVal listaInventario As List(Of InventarioMovimiento))

    Dim listaInventario As New List(Of InventarioMovimiento)
    Dim TotalMercaderia As Decimal = CDec(0.0)
    Dim TotalProductoTerminado As Decimal = CDec(0.0)
    Dim TotalSubProductosTerminados As Decimal = CDec(0.0)
#End Region

#Region "Variables thread"
    Private threadResuAnual As System.Threading.Thread
    Private threadLog As Thread
    Private threadVentas As Thread
    Private threadCaja As Thread
    Private threadRenta As Thread
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'REsumenVentasGastoByMes()
        'ChartAppearance_FujoCaja.ApplyChartStyles(chartControl1)
        txtFechaConsulta.Value = Date.Now
        LoadCombos()
        GetSaldoCajasActivas(1)

        chartControl1.Series.Clear()
        ThreadResumenAnual()
        ThreadLogistica()
        ThreadComercial()
        ThreadFinanzas()
        ThreadRentabilidad()
    End Sub



#End Region

#Region "Methods"

#Region "CharAnual"
    Private Sub ThreadResumenAnual()
        Try
            ProgressBar1.Visible = True
            ProgressBar1.Style = ProgressBarStyle.Marquee
            Dim empresa = Gempresas.IdEmpresaRuc
            Dim Anio = cboAnio.Text
            'Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() ConsultaAnual(empresa, Anio)))
            threadResuAnual = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() ConsultaAnual(empresa, Anio)))
            threadResuAnual.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ConsultaAnual(empresa As String, anio As String)
        Dim lista As New List(Of documentocompra)
        Dim listaVenta As New List(Of documentoventaAbarrotes)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoVentaSA As New documentoVentaAbarrotesSA

        lista = documentoCompraSA.GetListarComprasPorAnioEmpresa(empresa, anio)
        listaVenta = documentoVentaSA.GetListarVentasPorAnio2(empresa, anio)
        setDataSourceResumenAnual(lista, listaVenta)
    End Sub

    Public Sub REsumenVentasGastoByMes(ByVal lista As List(Of documentocompra),
                                          listaVenta As List(Of documentoventaAbarrotes))
        'Dim lista As New List(Of documentocompra)
        'Dim listaVenta As New List(Of documentoventaAbarrotes)
        'Dim documentoCompraSA As New DocumentoCompraSA
        'Dim documentoVentaSA As New documentoVentaAbarrotesSA

        chartControl1.Series.Clear()

        Dim series As New ChartSeries
        ' Initialize ChartSeries
        Dim colors As Color() = New Color() {Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                             Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                             Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                             Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                             Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                             Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141)}


        Dim colorsNC As Color() = New Color() {Color.FromArgb(48, 182, 125), Color.FromArgb(48, 182, 125),
                                             Color.FromArgb(48, 182, 125), Color.FromArgb(48, 182, 125),
                                             Color.FromArgb(48, 182, 125), Color.FromArgb(48, 182, 125),
                                             Color.FromArgb(48, 182, 125), Color.FromArgb(48, 182, 125),
                                             Color.FromArgb(48, 182, 125), Color.FromArgb(48, 182, 125),
                                             Color.FromArgb(48, 182, 125), Color.FromArgb(48, 182, 125)}



        series = New ChartSeries("Compras")

        '     lista = documentoCompraSA.GetListarComprasPorAnioEmpresa(Gempresas.IdEmpresaRuc, cboAnio.Text)

        series.Points.Clear()

        For Each i In lista
            Dim s = CDate(1 & "/" & i.fechaContable)
            series.Points.Add(CDate(s).Month, i.importeTotal.GetValueOrDefault)
        Next
        series.Type = ChartSeriesType.Column
        series.Text = series.Name
        Me.chartControl1.Series.Add(series)

        For i As Integer = 0 To colors.Length - 1
            series.Styles(i).Interior = New BrushInfo(colors(i))
        Next
        series.Style.Border.Color = Color.White
        series.Style.Border.DashStyle = DashStyle.Solid
        '----------------------------------------------------------------------------------------

        '    listaVenta = documentoVentaSA.GetListarVentasPorAnio(GEstableciento.IdEstablecimiento, cboAnio.Text)

        series = New ChartSeries("Ventas")
        series.Points.Clear()
        '      Dim series2 As New ChartSeries("Ventas")
        For Each i In listaVenta
            Dim s = CDate(1 & "/" & i.fechaPeriodo)
            series.Points.Add(CDate(s).Month, i.ImporteNacional.GetValueOrDefault)
        Next

        Dim colors2 As Color() = New Color() {Color.FromArgb(46, 198, 217), Color.FromArgb(46, 198, 217),
                                              Color.FromArgb(46, 198, 217), Color.FromArgb(46, 198, 217),
                                              Color.FromArgb(46, 198, 217), Color.FromArgb(46, 198, 217),
                                              Color.FromArgb(46, 198, 217), Color.FromArgb(46, 198, 217),
                                              Color.FromArgb(46, 198, 217), Color.FromArgb(46, 198, 217),
                                              Color.FromArgb(46, 198, 217), Color.FromArgb(46, 198, 217)}
        For i As Integer = 0 To colors2.Length - 1
            series.Styles(i).Interior = New BrushInfo(colors2(i))
        Next
        series.Style.Border.Color = Color.White
        series.Style.Border.DashStyle = DashStyle.Solid

        '-----------------------------------------------------------------------------------------------

        ''----------------------nota de credito-----------------------------------------------
        'series = New ChartSeries("NC. compras")
        'series.Points.Clear()
        'For Each i In lista.Where(Function(o) o.tipoCompra = TIPO_COMPRA.NOTA_CREDITO).ToList
        '    Dim s = CDate(1 & "/" & i.fechaContable)
        '    series.Points.Add(CDate(s).Month, i.importeTotal.GetValueOrDefault)
        'Next
        'series.Type = ChartSeriesType.Column
        'series.Text = series.Name
        'Me.chartControl1.Series.Add(series)

        'For i As Integer = 0 To colorsNC.Length - 1
        '    series.Styles(i).Interior = New BrushInfo(colorsNC(i))
        'Next
        '-----------------------------------------------------------------------------
        series.Type = ChartSeriesType.Column
        series.Text = series.Name
        series.Style.Border.Color = Color.White
        series.Style.Border.DashStyle = DashStyle.Solid
        Me.chartControl1.Series.Add(series)

        'chartControl1.ColumnDrawMode = ChartColumnDrawMode.ClusteredMode
        'chartControl1.PrimaryXAxis.RangeType = ChartAxisRangeType.[Set]
        chartControl1.PrimaryXAxis.Range = New MinMaxInfo(0, 13, 1)
        'ChartTemplate ct = new ChartTemplate(typeof(ChartControl));
        'ct.Load("Column_Square.xml");
        'ct.Apply(this.chartControl1);
        chartControl1.Series3D = False
        Me.chartControl1.ColumnWidthMode = ChartColumnWidthMode.DefaultWidthMode

        '   chartControl1.Palette = ChartColorPalette.None

    End Sub

    Private Sub setDataSourceResumenAnual(ByVal lista As List(Of documentocompra),
                                          listaVenta As List(Of documentoventaAbarrotes))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSourceResumenAnual)
            Invoke(deleg, New Object() {lista, listaVenta})
        Else
            REsumenVentasGastoByMes(lista, listaVenta)
            ChartAppearance_FujoCaja.ApplyChartStyles(chartControl1)
            ProgressBar1.Visible = False
        End If
    End Sub
#End Region

#Region "ChartLogistica"

    Private Sub ThreadLogistica()
        Try
            ProgressBar3.Visible = True
            ProgressBar3.Style = ProgressBarStyle.Marquee
            Dim empresa = Gempresas.IdEmpresaRuc
            Dim fecha = txtFechaConsulta.Value
            'Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetLogistia(empresa, fecha)))
            threadLog = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetLogistia(empresa, fecha)))
            threadLog.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetLogistia(empresa As String, fecha As DateTime)
        ResumenCompras = CompraSA.GetComprasDelDiaxOperacion(New documentocompra With {.idEmpresa = empresa, .fechaDoc = fecha})
        setDatasourceLogistica(ResumenCompras)
    End Sub

    Private Sub setDatasourceLogistica(ResumenCompras As List(Of documentocompra))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateLogistica(AddressOf setDatasourceLogistica)
            Invoke(deleg, New Object() {ResumenCompras})
        Else
            GetCompras(ResumenCompras)
            ProgressBar3.Visible = False
        End If
    End Sub

    Private Sub GetCompras(ResumenCompras As List(Of documentocompra))
        Dim obj As New documentocompra
        'ResumenCompras = CompraSA.GetComprasDelDiaxOperacion(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFechaConsulta.Value})

        obj = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.COMPRA).FirstOrDefault
        If obj IsNot Nothing Then
            lblCompraMercaderias.Text = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.COMPRA).FirstOrDefault.importeTotal.GetValueOrDefault.ToString("N2")
        Else
            lblCompraMercaderias.Text = "0.00"
        End If

        obj = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO).FirstOrDefault
        If obj IsNot Nothing Then
            lblCompraGastos.Text = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO).FirstOrDefault.importeTotal.GetValueOrDefault.ToString("N2")
        Else
            lblCompraGastos.Text = "0.00"
        End If

        obj = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS).FirstOrDefault
        If obj IsNot Nothing Then
            lblComprareciboHonorarios.Text = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS).FirstOrDefault.importeTotal.GetValueOrDefault.ToString("N2")
        Else
            lblComprareciboHonorarios.Text = "0.00"
        End If

        obj = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.NOTA_CREDITO).FirstOrDefault
        If obj IsNot Nothing Then
            lblNCcompra.Text = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.NOTA_CREDITO).FirstOrDefault.importeTotal.GetValueOrDefault.ToString("N2")
        Else
            lblNCcompra.Text = "0.00"
        End If

        obj = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.NOTA_DEBITO).FirstOrDefault
        If obj IsNot Nothing Then
            lblNDcompra.Text = ResumenCompras.Where(Function(o) o.tipoCompra = TIPO_COMPRA.NOTA_DEBITO).FirstOrDefault.importeTotal.GetValueOrDefault.ToString("N2")
        Else
            lblNDcompra.Text = "0.00"
        End If

        CalculoTotalCompras()
    End Sub
#End Region

#Region "ChartComercial"

    Private Sub ThreadComercial()
        Try
            ProgressBar4.Visible = True
            ProgressBar4.Style = ProgressBarStyle.Marquee
            Dim empresa = Gempresas.IdEmpresaRuc
            Dim fecha = txtFechaConsulta.Value
            'Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetComercial(empresa, fecha)))
            threadVentas = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetComercial(empresa, fecha)))
            threadVentas.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetComercial(empresa As String, fecha As DateTime)
        Dim lisatVentas = VentaSA.GetVentasDelDiaXTipoVenta(New documentoventaAbarrotes With {.idEmpresa = empresa, .fechaDoc = fecha})
        setDatasourceComercial(lisatVentas)
    End Sub

    Private Sub setDatasourceComercial(ResumenVentas As List(Of documentoventaAbarrotes))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateComercial(AddressOf setDatasourceComercial)
            Invoke(deleg, New Object() {ResumenVentas})
        Else
            GetVentas(ResumenVentas)
            ProgressBar4.Visible = False
        End If
    End Sub

    Private Sub GetVentas(listaVentas As List(Of documentoventaAbarrotes))
        Dim obj As New documentoventaAbarrotes
        'Dim listaVentas = VentaSA.GetVentasDelDiaXTipoVenta(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaDoc = txtFechaConsulta.Value})

        obj = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET).FirstOrDefault
        If obj IsNot Nothing Then
            lblventaTicket.Text = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET).FirstOrDefault.ImporteNacional.GetValueOrDefault.ToString("N2")
        Else
            lblventaTicket.Text = "0.00"
        End If

        obj = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA).FirstOrDefault
        If obj IsNot Nothing Then
            lblventaTicketDirecto.Text = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA).FirstOrDefault.ImporteNacional.GetValueOrDefault.ToString("N2")
        Else
            lblventaTicketDirecto.Text = "0.00"
        End If

        obj = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_GENERAL).FirstOrDefault
        If obj IsNot Nothing Then
            lblVentaGcredito.Text = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_GENERAL).FirstOrDefault.ImporteNacional.GetValueOrDefault.ToString("N2")
        Else
            lblVentaGcredito.Text = "0.00"
        End If

        obj = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_GENERAL).FirstOrDefault
        If obj IsNot Nothing Then
            lblVentaGcontado.Text = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_GENERAL).FirstOrDefault.ImporteNacional.GetValueOrDefault.ToString("N2")
        Else
            lblVentaGcontado.Text = "0.00"
        End If

        obj = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_NOTA_CREDITO).FirstOrDefault
        If obj IsNot Nothing Then
            lblNCventa.Text = listaVentas.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_NOTA_CREDITO).FirstOrDefault.ImporteNacional.GetValueOrDefault.ToString("N2")
        Else
            lblNCventa.Text = "0.00"
        End If

        obj = listaVentas.Where(Function(o) o.tipoVenta = TIPO_COMPRA.NOTA_CREDITO).FirstOrDefault
        If obj IsNot Nothing Then
            lblNCventa.Text = listaVentas.Where(Function(o) o.tipoVenta = TIPO_COMPRA.NOTA_CREDITO).FirstOrDefault.ImporteNacional.GetValueOrDefault.ToString("N2")
        Else
            lblNCventa.Text = "0.00"
        End If

        obj = listaVentas.Where(Function(o) o.tipoVenta = TIPO_COMPRA.NOTA_DEBITO).FirstOrDefault
        If obj IsNot Nothing Then
            lblNDventa.Text = listaVentas.Where(Function(o) o.tipoVenta = TIPO_COMPRA.NOTA_DEBITO).FirstOrDefault.ImporteNacional.GetValueOrDefault.ToString("N2")
        Else
            lblNDventa.Text = "0.00"
        End If

        calculoTotalVentas()
    End Sub
#End Region

#Region "ChartFinanzas"

    Private Sub ThreadFinanzas()
        Try
            ProgressBar2.Visible = True
            ProgressBar2.Style = ProgressBarStyle.Marquee
            Dim empresa = Gempresas.IdEmpresaRuc
            Dim fecha = txtFechaConsulta.Value
            'Dim threadCaja As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetFinanzas(empresa, fecha)))
            threadCaja = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetFinanzas(empresa, fecha)))
            threadCaja.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetFinanzas(empresa As String, fecha As DateTime)
        Dim Lista = cajaSA.GetFlujoEfectivoByDia(New documentoCaja With {.idEmpresa = empresa, .fechaProceso = fecha})
        setDatasourceFinanzas(Lista)
    End Sub

    Private Sub setDatasourceFinanzas(ResumenCaja As List(Of documentoCaja))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateFinanzas(AddressOf setDatasourceFinanzas)
            Invoke(deleg, New Object() {ResumenCaja})
        Else
            GetMovimientosCaja(ResumenCaja)
            ProgressBar2.Visible = False
        End If
    End Sub

    Private Sub GetMovimientosCaja(ResumenCaja As List(Of documentoCaja))
        Dim obj As New documentoCaja
        'ResumenCaja = New List(Of documentoCaja)
        'ResumenCaja = cajaSA.GetFlujoEfectivoByDia(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaProceso = txtFechaConsulta.Value})

        'Finanzas

        obj = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.ANTICIPOS_RECIBIDOS).FirstOrDefault
        If obj IsNot Nothing Then
            lblMontoAntRec.Text = obj.montoSoles.GetValueOrDefault.ToString("N2")
        Else
            lblMontoAntRec.Text = "0.00"
        End If

        obj = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.ANTICIPOS_OTORGADOS).FirstOrDefault
        If obj IsNot Nothing Then
            lblMontoAntOtor.Text = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.ANTICIPOS_OTORGADOS).FirstOrDefault.montoSoles.GetValueOrDefault.ToString("N2")
        Else
            lblMontoAntOtor.Text = "0.00"
        End If


        obj = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO).FirstOrDefault
        If obj IsNot Nothing Then
            lblMontoIngresos.Text = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO).FirstOrDefault.montoSoles.GetValueOrDefault().ToString("N2")
        Else
            lblMontoIngresos.Text = "0.00"
        End If

        obj = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO).FirstOrDefault
        If obj IsNot Nothing Then
            lblMontoSalida.Text = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO).FirstOrDefault.montoSoles.GetValueOrDefault.ToString("N2")
        Else
            lblMontoSalida.Text = "0.00"
        End If

        obj = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.APORTES).FirstOrDefault
        If obj IsNot Nothing Then
            lblMontoAporte.Text = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.APORTES).FirstOrDefault.montoSoles.GetValueOrDefault.ToString("N2")
        Else
            lblMontoAporte.Text = "0.00"
        End If

        lblMontoPlanilla.Text = "0.00"

        obj = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES).FirstOrDefault
        If obj IsNot Nothing Then
            lblMontoCobros.Text = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES).FirstOrDefault.montoSoles.GetValueOrDefault.ToString("N2")
        Else
            lblMontoCobros.Text = "0.00"
        End If

        obj = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.PAGO_A_PROVEEDORES).FirstOrDefault
        If obj IsNot Nothing Then
            lblMontoPagos.Text = ResumenCaja.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.PAGO_A_PROVEEDORES).FirstOrDefault.montoSoles.GetValueOrDefault.ToString("N2")
        Else
            lblMontoPagos.Text = "0.00"
        End If

        lblMontoPrestamosRec.Text = "0.00"
        lblMontoPrestamosOtor.Text = "0.00"

        obj = ResumenCaja.Where(Function(o) o.tipoOperacion = "9922").FirstOrDefault
        If obj IsNot Nothing Then
            lblReclamacionesProv.Text = ResumenCaja.Where(Function(o) o.tipoOperacion = "9922").FirstOrDefault.montoSoles.GetValueOrDefault.ToString("N2")
        Else
            lblReclamacionesProv.Text = "0.00"
        End If

        obj = ResumenCaja.Where(Function(o) o.tipoOperacion = "9920").FirstOrDefault
        If obj IsNot Nothing Then
            lblReclamacionesCli.Text = ResumenCaja.Where(Function(o) o.tipoOperacion = "9920").FirstOrDefault.montoSoles.GetValueOrDefault.ToString("N2")
        Else
            lblReclamacionesCli.Text = "0.00"
        End If

        CalculoTotalesCaja()
    End Sub

    Private Sub CalculoTotalesCaja()
        lblTotalIngresosCaja.Text = CDec(lblMontoAntRec.Text) + CDec(lblMontoIngresos.Text) + CDec(lblMontoAporte.Text) + CDec(lblMontoCobros.Text) + CDec(lblMontoPrestamosRec.Text) + CDec(lblReclamacionesProv.Text)
        lblTotalIngresosCaja.Text = CDec(lblTotalIngresosCaja.Text).ToString("N2")

        lblTotalEgresosCaja.Text = CDec(lblMontoAntOtor.Text) + CDec(lblMontoSalida.Text) + CDec(lblMontoPlanilla.Text) + CDec(lblMontoPagos.Text) + CDec(lblMontoPrestamosOtor.Text) + CDec(lblReclamacionesCli.Text)
        lblTotalEgresosCaja.Text = CDec(lblTotalEgresosCaja.Text).ToString("N2")

        lblTotalEncaja.Text = CDec(lblTotalCajasActiva.Text) + CDec(lblTotalIngresosCaja.Text) - CDec(lblTotalEgresosCaja.Text)
        lblTotalEncaja.Text = CDec(lblTotalEncaja.Text).ToString("N2")

        '------------------------------------------------------------------------------------------------------------
        Dim sumatotalCaja = CDec(lblTotalIngresosCaja.Text) + CDec(lblTotalEgresosCaja.Text)
        If CDec(lblMontoAntRec.Text) > 0 Then
            pbAnticiRecibidos.Value = FormatNumber((CDec(lblMontoAntRec.Text) / sumatotalCaja) * 100, 2)
        Else
            pbAnticiRecibidos.Value = 0
        End If

        If CDec(lblMontoIngresos.Text) > 0 Then
            pbOtrosIngresos.Value = FormatNumber((CDec(lblMontoIngresos.Text) / sumatotalCaja) * 100, 2)
        Else
            pbOtrosIngresos.Value = 0
        End If

        If CDec(lblMontoAporte.Text) > 0 Then
            pbAportes.Value = FormatNumber((CDec(lblMontoAporte.Text) / sumatotalCaja) * 100, 2)
        Else
            pbAportes.Value = 0
        End If

        If CDec(lblMontoCobros.Text) > 0 Then
            pbCuentasCobradas.Value = FormatNumber((CDec(lblMontoCobros.Text) / sumatotalCaja) * 100, 2)
        Else
            pbCuentasCobradas.Value = 0
        End If

        If CDec(lblMontoPrestamosRec.Text) > 0 Then
            pbPrestamoRecibido.Value = FormatNumber((CDec(lblMontoPrestamosRec.Text) / sumatotalCaja) * 100, 2)
        Else
            pbPrestamoRecibido.Value = 0
        End If
        '-----------------------------------------------------------------------------------------------------------
        If CDec(lblMontoAntOtor.Text) > 0 Then
            pbAnticiOtorgados.Value = FormatNumber((CDec(lblMontoAntOtor.Text) / sumatotalCaja) * 100, 2)
        Else
            pbAnticiOtorgados.Value = 0
        End If

        If CDec(lblMontoSalida.Text) > 0 Then
            pbOtrasSalidas.Value = FormatNumber((CDec(lblMontoSalida.Text) / sumatotalCaja) * 100, 2)
        Else
            pbOtrasSalidas.Value = 0
        End If

        If CDec(lblMontoPlanilla.Text) > 0 Then
            pbPlanilla.Value = FormatNumber((CDec(lblMontoPlanilla.Text) / sumatotalCaja) * 100, 2)
        Else
            pbPlanilla.Value = 0
        End If

        If CDec(lblMontoPagos.Text) > 0 Then
            pbPagoProveedores.Value = FormatNumber((CDec(lblMontoPagos.Text) / sumatotalCaja) * 100, 2)
        Else
            pbPagoProveedores.Value = 0
        End If

        If CDec(lblMontoPrestamosOtor.Text) > 0 Then
            pbPrestamoOtorgado.Value = FormatNumber((CDec(lblMontoPrestamosOtor.Text) / sumatotalCaja) * 100, 2)
        Else
            pbPrestamoOtorgado.Value = 0
        End If

        If CDec(lblReclamacionesProv.Text) > 0 Then
            ProgressBarAdv9.Value = FormatNumber((CDec(lblReclamacionesProv.Text) / sumatotalCaja) * 100, 2)
        Else
            ProgressBarAdv9.Value = 0
        End If

        If CDec(lblReclamacionesCli.Text) > 0 Then
            ProgressBarAdv8.Value = FormatNumber((CDec(lblReclamacionesCli.Text) / sumatotalCaja) * 100, 2)
        Else
            ProgressBarAdv8.Value = 0
        End If
    End Sub
#End Region

#Region "ChartRentabilidad"

    Private Sub ThreadRentabilidad()
        Try
            ProgressBar5.Visible = True
            ProgressBar5.Style = ProgressBarStyle.Marquee
            Dim fecha = txtFechaConsulta.Value
            ' Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetRentabilidad(fecha)))
            threadRenta = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetRentabilidad(fecha)))
            threadRenta.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetRentabilidad(fecha As DateTime)
        Dim NuevaListaInventario As New List(Of InventarioMovimiento)
        Dim cierreSA As New CierreInventarioSA
        Dim cierre As New cierreinventario
        Dim listaCierre As New List(Of cierreinventario)
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim producto As String = Nothing
        Dim codigoLotex As Integer = 0
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim almacenSA As New almacenSA
        Dim documentosa As New documentoVentaAbarrotesSA
        Dim listaInventario2 As New List(Of InventarioMovimiento)
        '-----------------------------------------------------------------------------------------------------
        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m

        Dim almacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        '    ListaCurar = New List(Of totalesAlmacen)

        NuevaListaInventario = New List(Of InventarioMovimiento)
        Dim costoSalida As Decimal = 0
        For Each al In almacenes

            listaInventario = inventario.GetRentabilidad(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(fecha.Year, fecha.Month, 1)}, fecha, fecha, "Dia")

            ImporteSaldo = 0
            canSaldo = 0
            For Each i As InventarioMovimiento In listaInventario
                costoSalida = 0
                cantidadDeficit = 0
                importeDeficit = 0

                Select Case i.tipoRegistro
                    Case "E", "EA", "EC"
                        If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
                            If i.tipoOperacion = 9916 Then
                                productoCache = i.nombreItem
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += CDec(i.monto)
                                costoSalida = CDec(i.monto)
                            Else
                                productoCache = i.nombreItem
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += CDec(i.monto)
                            End If


                        Else
                            cantidadDeficit = canSaldo
                            importeDeficit = ImporteSaldo

                            canSaldo = 0
                            ImporteSaldo = 0

                            'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                            canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                            ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
                            canSaldo = CDec(i.cantidad) + canSaldo
                            ImporteSaldo = CDec(i.monto) + ImporteSaldo

                        End If
                        If canSaldo > 0 Then
                            precUnit = ImporteSaldo / canSaldo
                        Else
                            precUnit = 0
                        End If
                        pmAcumnulado = precUnit
                    Case "S", "D"
                        Dim co As Decimal = 0
                        co = CDec(i.cantidad) * pmAcumnulado

                        If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
                            productoCache = i.nombreItem
                            'canSaldo += CDec(i.cantidad)

                            Select Case i.tipoOperacion
                                Case "9913"
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo = ImporteSaldo

                                Case "9914"
                                    canSaldo = canSaldo
                                    ImporteSaldo += i.monto

                                Case "9916"
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo += i.monto

                                    costoSalida = i.monto * -1

                                Case StatusTipoOperacion.REVERSIONES
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo += i.monto

                                Case Else
                                    canSaldo += CDec(i.cantidad)
                                    ImporteSaldo += co

                                    costoSalida = co * -1
                            End Select

                        Else
                            cantidadDeficit = canSaldo
                            importeDeficit = ImporteSaldo

                            canSaldo = 0
                            ImporteSaldo = 0
                            'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                            canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
                            ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault

                            canSaldo += CDec(i.cantidad)
                            ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                        End If

                        If canSaldo > 0 Then
                            precUnit = ImporteSaldo / canSaldo
                        Else
                            precUnit = 0
                        End If

                        pmAcumnulado = precUnit
                End Select

                producto = i.idItem
                codigoLotex = i.customLote.codigoLote
                productoCache = i.nombreItem

                NuevaListaInventario.Add(New InventarioMovimiento With
                                         {
                                         .idEmpresa = Gempresas.IdEmpresaRuc,
                                         .idDocumentoRef = i.idDocumento,
                                         .tipoOperacion = i.tipoOperacion,
                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                         .NombreAlmacen = al.descripcionAlmacen,
                                         .NombrePresentacion = GEstableciento.NombreEstablecimiento,
                                         .idAlmacen = i.idAlmacen,
                                         .fecha = i.fecha,
                                         .idItem = i.idItem,
                                         .descripcion = i.nombreItem,
                                         .tipoExistencia = i.tipoProducto,
                                         .unidad = i.unidad,
                                         .CantSaldo = canSaldo,
                                         .saldoMonto = ImporteSaldo,
                                         .monto = costoSalida,
                                         .nrolote = codigoLotex = i.customLote.codigoLote,
                                         .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault,
                                         .rentabilidad = i.ValorDeVenta.GetValueOrDefault - costoSalida})
            Next
        Next

        listaInventario2 = documentosa.getListaServiosXVenta(New InventarioMovimiento With {.fecha = New DateTime(fecha.Year, fecha.Month, 1)}, txtFechaConsulta.Value, txtFechaConsulta.Value, "Dia")

        If (Not IsNothing(listaInventario2)) Then
            For Each i As InventarioMovimiento In listaInventario2
                NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                            .idDocumentoRef = i.idDocumento,
                                            .tipoOperacion = i.tipoOperacion,
                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                            .NombreAlmacen = Nothing,
                                            .NombrePresentacion = GEstableciento.NombreEstablecimiento,
                                            .idAlmacen = i.idAlmacen,
                                            .fecha = New Date(fecha.Year, fecha.Month, fecha.Day),
                                            .idItem = i.idItem,
                                            .descripcion = i.nombreItem,
                                            .tipoExistencia = i.tipoExistencia,
                                            .unidad = i.unidad,
                                            .CantSaldo = canSaldo,
                                            .saldoMonto = ImporteSaldo,
                                            .monto = costoSalida,
                                            .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault})
            Next
        End If

        setDatasourceRentabilidad(NuevaListaInventario)
    End Sub

    Private Sub setDatasourceRentabilidad(listaInventario As List(Of InventarioMovimiento))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateRentabilidad(AddressOf setDatasourceRentabilidad)
            Invoke(deleg, New Object() {listaInventario})
        Else
            GetRentabilidadDelDia(listaInventario)
            ChartAppearance.ApplyChartStylesPie(Me.ChartControl3)
            ProgressBar5.Visible = False
        End If
    End Sub

    'Private Sub GetCostoVenta(fecha As DateTime)
    '    Dim NuevaListaInventario As New List(Of InventarioMovimiento)
    '    Dim cierreSA As New CierreInventarioSA
    '    Dim cierre As New cierreinventario
    '    Dim listaCierre As New List(Of cierreinventario)
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim listaInventario As New List(Of InventarioMovimiento)
    '    Dim producto As String = Nothing
    '    Dim codigoLotex As Integer = 0
    '    Dim cantidadDeficit As Decimal = 0
    '    Dim importeDeficit As Decimal = 0
    '    Dim productoCache As String = Nothing
    '    Dim almacenSA As New almacenSA
    '    Dim documentosa As New documentoVentaAbarrotesSA
    '    Dim listaInventario2 As New List(Of InventarioMovimiento)
    '    '-----------------------------------------------------------------------------------------------------
    '    ImporteSaldo = 0
    '    canSaldo = 0
    '    '''''''''''''''m

    '    Dim almacenes = almacenSA.GetListar_almacenExceptAVEmpresa(Gempresas.IdEmpresaRuc)
    '    '    ListaCurar = New List(Of totalesAlmacen)

    '    NuevaListaInventario = New List(Of InventarioMovimiento)
    '    Dim costoSalida As Decimal = 0
    '    For Each al In almacenes

    '        listaInventario = inventario.GetRentabilidad(New InventarioMovimiento With {.idAlmacen = al.idAlmacen, .fecha = New DateTime(fecha.Year, fecha.Month, 1)}, fecha, fecha, "Dia")

    '        ImporteSaldo = 0
    '        canSaldo = 0
    '        For Each i As InventarioMovimiento In listaInventario
    '            costoSalida = 0
    '            cantidadDeficit = 0
    '            importeDeficit = 0

    '            Select Case i.tipoRegistro
    '                Case "E", "EA", "EC"
    '                    If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
    '                        If i.tipoOperacion = 9916 Then
    '                            productoCache = i.nombreItem
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo += CDec(i.monto)
    '                            costoSalida = CDec(i.monto)
    '                        Else
    '                            productoCache = i.nombreItem
    '                            canSaldo += CDec(i.cantidad)
    '                            ImporteSaldo += CDec(i.monto)
    '                        End If


    '                    Else
    '                        cantidadDeficit = canSaldo
    '                        importeDeficit = ImporteSaldo

    '                        canSaldo = 0
    '                        ImporteSaldo = 0

    '                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
    '                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
    '                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault
    '                        canSaldo = CDec(i.cantidad) + canSaldo
    '                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

    '                    End If
    '                    If canSaldo > 0 Then
    '                        precUnit = ImporteSaldo / canSaldo
    '                    Else
    '                        precUnit = 0
    '                    End If
    '                    pmAcumnulado = precUnit
    '                Case "S", "D"
    '                    Dim co As Decimal = 0
    '                    co = CDec(i.cantidad) * pmAcumnulado

    '                    If producto = i.idItem AndAlso codigoLotex = i.customLote.codigoLote Then
    '                        productoCache = i.nombreItem
    '                        'canSaldo += CDec(i.cantidad)

    '                        Select Case i.tipoOperacion
    '                            Case "9913"
    '                                canSaldo += CDec(i.cantidad)
    '                                ImporteSaldo = ImporteSaldo

    '                            Case "9914"
    '                                canSaldo = canSaldo
    '                                ImporteSaldo += i.monto

    '                            Case "9916"
    '                                canSaldo += CDec(i.cantidad)
    '                                ImporteSaldo += i.monto

    '                                costoSalida = i.monto * -1

    '                            Case StatusTipoOperacion.REVERSIONES
    '                                canSaldo += CDec(i.cantidad)
    '                                ImporteSaldo += i.monto

    '                            Case Else
    '                                canSaldo += CDec(i.cantidad)
    '                                ImporteSaldo += co

    '                                costoSalida = co * -1
    '                        End Select

    '                    Else
    '                        cantidadDeficit = canSaldo
    '                        importeDeficit = ImporteSaldo

    '                        canSaldo = 0
    '                        ImporteSaldo = 0
    '                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
    '                        canSaldo = canSaldo + i.cantidad2.GetValueOrDefault
    '                        ImporteSaldo = ImporteSaldo + i.montoOther.GetValueOrDefault

    '                        canSaldo += CDec(i.cantidad)
    '                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
    '                    End If

    '                    If canSaldo > 0 Then
    '                        precUnit = ImporteSaldo / canSaldo
    '                    Else
    '                        precUnit = 0
    '                    End If

    '                    pmAcumnulado = precUnit
    '            End Select

    '            producto = i.idItem
    '            codigoLotex = i.customLote.codigoLote
    '            productoCache = i.nombreItem

    '            NuevaListaInventario.Add(New InventarioMovimiento With
    '                                     {
    '                                     .idEmpresa = Gempresas.IdEmpresaRuc,
    '                                     .idDocumentoRef = i.idDocumento,
    '                                     .tipoOperacion = i.tipoOperacion,
    '                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
    '                                     .NombreAlmacen = al.descripcionAlmacen,
    '                                     .NombrePresentacion = GEstableciento.NombreEstablecimiento,
    '                                     .idAlmacen = i.idAlmacen,
    '                                     .fecha = i.fecha,
    '                                     .idItem = i.idItem,
    '                                     .descripcion = i.nombreItem,
    '                                     .tipoExistencia = i.tipoProducto,
    '                                     .unidad = i.unidad,
    '                                     .CantSaldo = canSaldo,
    '                                     .saldoMonto = ImporteSaldo,
    '                                     .monto = costoSalida,
    '                                     .nrolote = codigoLotex = i.customLote.codigoLote,
    '                                     .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault,
    '                                     .rentabilidad = i.ValorDeVenta.GetValueOrDefault - costoSalida})
    '        Next
    '    Next

    '    listaInventario2 = documentosa.getListaServiosXVenta(New InventarioMovimiento With {.fecha = New DateTime(fecha.Year, fecha.Month, 1)}, txtFechaConsulta.Value, txtFechaConsulta.Value, "Dia")

    '    If (Not IsNothing(listaInventario2)) Then
    '        For Each i As InventarioMovimiento In listaInventario2
    '            NuevaListaInventario.Add(New InventarioMovimiento With {.idEmpresa = Gempresas.IdEmpresaRuc,
    '                                        .idDocumentoRef = i.idDocumento,
    '                                        .tipoOperacion = i.tipoOperacion,
    '                                        .idEstablecimiento = GEstableciento.IdEstablecimiento,
    '                                        .NombreAlmacen = Nothing,
    '                                        .NombrePresentacion = GEstableciento.NombreEstablecimiento,
    '                                        .idAlmacen = i.idAlmacen,
    '                                        .fecha = New Date(fecha.Year, fecha.Month, fecha.Day),
    '                                        .idItem = i.idItem,
    '                                        .descripcion = i.nombreItem,
    '                                        .tipoExistencia = i.tipoExistencia,
    '                                        .unidad = i.unidad,
    '                                        .CantSaldo = canSaldo,
    '                                        .saldoMonto = ImporteSaldo,
    '                                        .monto = costoSalida,
    '                                        .ValorDeVenta = i.ValorDeVenta.GetValueOrDefault})
    '        Next
    '    End If
    '    'GetRentabilidadDelDia(NuevaListaInventario)fsdfd
    'End Sub

    Private Sub GetRentabilidadDelDia(lista As List(Of InventarioMovimiento))
        Dim listaTipoExistencia As New List(Of String)
        listaTipoExistencia.Add(TipoExistencia.Mercaderia)
        listaTipoExistencia.Add(TipoExistencia.ProductoTerminado)
        listaTipoExistencia.Add(TipoExistencia.SubProductosDesechos)
        listaTipoExistencia.Add(TipoExistencia.ServicioGasto)

        TotalMercaderia = CDec(0.0)
        TotalProductoTerminado = CDec(0.0)
        TotalSubProductosTerminados = CDec(0.0)


        Dim condicion As New List(Of String)
        condicion.Add(StatusTipoOperacion.VENTA)
        condicion.Add(StatusTipoOperacion.NC_DEVOLUCION_DE_EXISTENCIAS)
        Dim consulta = (From n In lista
                        Where condicion.Contains(n.tipoOperacion) _
                        And listaTipoExistencia.Contains(n.tipoExistencia)).ToList

        '  listaInventario = consulta


        Dim sumaTotales = Aggregate n In consulta
                              Where n.fecha.Value.Year = txtFechaConsulta.Value.Year And
                                  n.fecha.Value.Month = txtFechaConsulta.Value.Month And
                                  n.fecha.Value.Day = txtFechaConsulta.Value.Day
                          Into SumaCostoVenta = Sum(n.monto),
                              SumaValorVenta = Sum(n.ValorDeVenta)


        ChartControl3.Series.Clear()
        'ChartControl3.ShowLegend = True
        PieFlujoEfectivo(sumaTotales.SumaCostoVenta.GetValueOrDefault, sumaTotales.SumaValorVenta.GetValueOrDefault)
    End Sub
#End Region

    Private Sub PieFlujoEfectivo(MontoCostoVenta As Decimal, MontoValorventa As Decimal)
        Dim coNteo As Byte = 0
        Dim series1 As New ChartSeries("Ventas")

        series1.Points.Add(0, MontoCostoVenta)
        series1.Points.Add(1, MontoValorventa)
        series1.Points.Add(2, MontoValorventa - MontoCostoVenta)

        series1.Type = ChartSeriesType.Pie
        Me.ChartControl3.Series.Add(series1)
        series1.OptimizePiePointPositions = True

        For i As Integer = 0 To series1.Points.Count - 1
            series1.Styles(i).Border.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
            series1.Styles(i).Border.Color = Color.White
        Next

        'If documentoCaja.Count > 0 Then
        Dim importeNac As Decimal = series1.Points(0).YValues(0)
        Dim importeEx As Decimal = series1.Points(1).YValues(0)
        series1.Styles(0).Text = String.Format("Costo venta {0}", (importeNac))
        series1.Styles(1).Text = String.Format("Valor venta {0}", (importeEx))
        series1.Styles(2).Text = String.Format("Rentabilidad {0}", importeEx - importeNac)
        'series1.Styles(3).Text = String.Format("Taxes {0}%", series1.Points(3).YValues(0))
        'series1.Styles(4).Text = String.Format("Insurance{0}%", series1.Points(4).YValues(0))
        'series1.Styles(5).Text = String.Format("Licenses {0}%", series1.Points(5).YValues(0))
        'series1.Styles(6).Text = String.Format("Legal {0}%", series1.Points(6).YValues(0))

        series1.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.OutsideInColumn
        series1.Style.DisplayText = False
        series1.Style.Font.Size = 8.0F
        series1.ConfigItems.PieItem.AngleOffset = 60
        'series1.Style.Border.Color = Color.White
        'series1.Style.Border.DashStyle = DashStyle.Solid
        '  ChartControl3.Series3D = True
        ' Me.ChartControl3.Series(0).ConfigItems.PieItem.HeightCoeficient = 0.1

        ChartControl3.Series(0).ShowTicks = False
        ChartControl3.Series(0).Styles(0).Border.Color = Color.Transparent
        ChartControl3.Series(0).Styles(1).Border.Color = Color.Transparent
        ChartControl3.Series(0).Styles(2).Border.Color = Color.Transparent
        ChartControl3.Series(0).ConfigItems.PieItem.DoughnutCoeficient = 0.6

        ChartControl3.Model.ColorModel.CustomColors = New Color() {Color.FromArgb(46, 198, 217),
                                             Color.FromArgb(218, 106, 139),
                                             Color.FromArgb(48, 182, 125),
                                             Color.FromArgb(56, 83, 164)}
        ChartControl3.Model.ColorModel.Palette = ChartColorPalette.Custom
        ChartControl3.ShowLegend = True
        ChartControl3.Series(0).OptimizePiePointPositions = True

        'End If
    End Sub

    Private Sub GetSaldoCajasActivas(caso As Integer)
        Dim cajausuarioSA As New cajaUsuarioSA

        Dim obj = cajausuarioSA.GetCajasActivasTotalXdia(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaProceso = txtFechaConsulta.Value, .estado = caso})
        If obj IsNot Nothing Then
            lblTotalCajasActiva.Text = obj.fondoMN.GetValueOrDefault
        Else
            lblTotalCajasActiva.Text = "0.00"
        End If
    End Sub

    Private Sub LoadCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year
    End Sub

    Private Sub CalculoTotalCompras()
        lblTotalCompras.Text = CDec(lblCompraMercaderias.Text) + CDec(lblCompraGastos.Text) + CDec(lblComprareciboHonorarios.Text) - CDec(lblNCcompra.Text) + CDec(lblNDcompra.Text)
        lblTotalCompras.Text = CDec(lblTotalCompras.Text).ToString("N2")

        Dim sumaCompras = CDec(lblCompraMercaderias.Text) + CDec(lblCompraGastos.Text) + CDec(lblComprareciboHonorarios.Text) + CDec(lblNCcompra.Text) + CDec(lblNDcompra.Text)
        If CDec(lblCompraMercaderias.Text) > 0 Then
            ProgressBarAdv1.Value = FormatNumber((CDec(lblCompraMercaderias.Text) / sumaCompras) * 100, 2)
        Else
            ProgressBarAdv1.Value = 0
        End If

        If CDec(lblCompraGastos.Text) > 0 Then
            ProgressBarAdv2.Value = FormatNumber((CDec(lblCompraGastos.Text) / sumaCompras) * 100, 2)
        Else
            ProgressBarAdv2.Value = 0
        End If

        If CDec(lblComprareciboHonorarios.Text) > 0 Then
            ProgressBarAdv3.Value = FormatNumber((CDec(lblComprareciboHonorarios.Text) / sumaCompras) * 100, 2)
        Else
            ProgressBarAdv3.Value = 0
        End If

        If CDec(lblNCcompra.Text) > 0 Then
            pbNotaCreditoCompra.Value = FormatNumber((CDec(lblNCcompra.Text) / sumaCompras) * 100, 2)
        Else
            pbNotaCreditoCompra.Value = 0
        End If

        If CDec(lblNDcompra.Text) > 0 Then
            pbNotaDebitoCompra.Value = FormatNumber((CDec(lblNDcompra.Text) / sumaCompras) * 100, 2)
        Else
            pbNotaDebitoCompra.Value = 0
        End If
    End Sub

    Private Sub calculoTotalVentas()
        lblTotalVentas.Text = CDec(lblventaTicket.Text) + CDec(lblventaTicketDirecto.Text) + CDec(lblVentaGcredito.Text) + CDec(lblVentaGcontado.Text) - CDec(lblNCventa.Text) + CDec(lblNDventa.Text)
        lblTotalVentas.Text = CDec(lblTotalVentas.Text).ToString("N2")

        Dim sumaVentas = CDec(lblventaTicket.Text) + CDec(lblventaTicketDirecto.Text) + CDec(lblVentaGcredito.Text) + CDec(lblVentaGcontado.Text) + CDec(lblNCventa.Text) + CDec(lblNDventa.Text)
        If CDec(lblventaTicket.Text) > 0 Then
            ProgressBarAdv6.Value = FormatNumber((CDec(lblventaTicket.Text) / sumaVentas) * 100, 2)
        Else
            ProgressBarAdv6.Value = 0
        End If

        If CDec(lblventaTicketDirecto.Text) > 0 Then
            ProgressBarAdv5.Value = FormatNumber((CDec(lblventaTicketDirecto.Text) / sumaVentas) * 100, 2)
        Else
            ProgressBarAdv5.Value = 0
        End If

        If CDec(lblVentaGcredito.Text) > 0 Then
            ProgressBarAdv4.Value = FormatNumber((CDec(lblVentaGcredito.Text) / sumaVentas) * 100, 2)
        Else
            ProgressBarAdv4.Value = 0
        End If

        If CDec(lblVentaGcontado.Text) > 0 Then
            ProgressBarAdv7.Value = FormatNumber((CDec(lblVentaGcontado.Text) / sumaVentas) * 100, 2)
        Else
            ProgressBarAdv7.Value = 0
        End If

        If CDec(lblNCventa.Text) > 0 Then
            ProgressBarAdv10.Value = FormatNumber((CDec(lblNCventa.Text) / sumaVentas) * 100, 2)
        Else
            ProgressBarAdv10.Value = 0
        End If

        If CDec(lblNDventa.Text) > 0 Then
            ProgressBarAdv11.Value = FormatNumber((CDec(lblNDventa.Text) / sumaVentas) * 100, 2)
        Else
            ProgressBarAdv11.Value = 0
        End If
    End Sub

#End Region

#Region "Events"
    Private Sub chartControl1_ChartFormatAxisLabel(sender As Object, e As ChartFormatAxisLabelEventArgs) Handles chartControl1.ChartFormatAxisLabel
        If e.AxisOrientation = ChartOrientation.Horizontal Then
            If e.Value = 1 Then
                e.Label = "Ene"
            ElseIf e.Value = 2 Then
                e.Label = "Feb"
            ElseIf e.Value = 3 Then
                e.Label = "Mar"
            ElseIf e.Value = 4 Then
                e.Label = "Abr"
            ElseIf e.Value = 5 Then
                e.Label = "May"
            ElseIf e.Value = 6 Then
                e.Label = "Jun"
            ElseIf e.Value = 7 Then
                e.Label = "Jul"
            ElseIf e.Value = 8 Then
                e.Label = "Ago"
            ElseIf e.Value = 9 Then
                e.Label = "Set"
            ElseIf e.Value = 10 Then
                e.Label = "Oct"
            ElseIf e.Value = 11 Then
                e.Label = "Nov"
            ElseIf e.Value = 12 Then
                e.Label = "Dic"
            Else
                e.Label = ""
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            ThreadResumenAnual()
            ThreadLogistica()
            ThreadComercial()
            ThreadFinanzas()
            ThreadRentabilidad()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmTableroGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Cursor = Cursors.WaitCursor
        ThreadResumenAnual()
        Cursor = Cursors.Default
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Cursor = Cursors.WaitCursor
        ThreadFinanzas()
        Cursor = Cursors.Default
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Cursor = Cursors.WaitCursor
        ThreadComercial()
        Cursor = Cursors.Default
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Cursor = Cursors.WaitCursor
        ThreadLogistica()
        Cursor = Cursors.Default
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        ThreadRentabilidad()
    End Sub

    Private Sub ComboBoxAdv1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv1.SelectedValueChanged
        'If ComboBoxAdv1.Text.Trim.Length > 0 Then
        '    If ComboBoxAdv1.Text = "Cajas Acumuladas" Then
        '        GetSaldoCajasActivas(2)
        '    ElseIf ComboBoxAdv1.Text = "Cajas del día" Then

        'End If
        'End If
    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv1.Click

    End Sub

    Private Sub frmTableroGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        threadResuAnual.Abort()
        threadLog.Abort()
        threadVentas.Abort()
        threadCaja.Abort()
        threadRenta.Abort()
    End Sub
#End Region

End Class