Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Tools
Imports System.ComponentModel


Public Class frmMasterComprasGenerales
    Inherits frmMaster
    Dim colorx As New GridMetroColors()
    Dim lblCenter As Label


    Private IsExpanded As Boolean
    Private feedback As FeedbackForm = Nothing
    Private result As Double = 0.0


    Public Sub New()
        Me.WindowState = FormWindowState.Normal
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompras)
        GridCFG(dgvOrdenCompra)
        GridCFG(dgvOrdenServicio)
        GridCFG(dgvProveedor)
        GridCFG_Detracccion(dgvDetracciones)
        lblPeriodo.Text = "Período: " & PeriodoGeneral
        lblFechaContable.Text = PeriodoGeneral
        lblDiaLab.Text = DiaLaboral.Day
        txtAnio.Text = AnioGeneral
        txtAnioCompra.Text = AnioGeneral
        DateTimePickerAdv1.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)
        TabDashboard.TabVisible = False
        'Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        'UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")

        'InitializeChart()
        'ChartAppearance.ApplyChartStyles(Me.chartControl1)
        'Me.chartControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        'InitializeChartData()
        'ApplyChartStylesDefault(Me.ChartControl2)


        'PieFlujoEfectivo()
        'ApplyChartStylesPie(ChartControl3)
        Meses()
        GetCountDetracciones()
    End Sub

#Region "PROVEEDORES"

    Public Sub CargarEntidadesXtipoProveedor(strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub ElimnarProveedor()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        Dim entidad As New entidadSA
        Dim objEntidad As New entidad
        If Not IsNothing(Me.dgvProveedor.Table.CurrentRecord) Then

            With objEntidad
                .idEntidad = Me.dgvProveedor.Table.CurrentRecord.GetValue("idEntidad")
            End With

            entidad.DeleteEntidad(objEntidad)
            Me.dgvProveedor.Table.CurrentRecord.Delete()
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            lblEstado.Text = "Proveedor eliminada!"

        End If
    End Sub

    Private Sub ListaProveedores()
        Dim dt As New DataTable()
        Dim entidad As New entidadSA

        dt.Columns.Add("idEntidad")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("nroDoc")
        dt.Columns.Add("tipo")
        dt.Columns.Add("razon")
        dt.Columns.Add("direc")
        dt.Columns.Add("fono")
        dt.Columns.Add("estado")

        For Each i In entidad.GetEntidadesGenerales(TIPO_ENTIDAD.PROVEEDOR, Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEntidad
            Select Case i.tipoDoc
                Case "6"
                    dr(1) = "RUC"
                Case "1"
                    dr(1) = "DNI"
                Case "7"
                    dr(1) = "PASSAPORTE"
                Case "4"
                    dr(1) = "CARNET DE EXTRANJERIA"
            End Select

            dr(2) = i.nrodoc
            dr(3) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(4) = i.nombreCompleto
            dr(5) = i.direccion
            dr(6) = i.telefono
            dr(7) = IIf(i.estado = StatusEntidad.Activo, "Activo", "Inactivo")
            dt.Rows.Add(dr)
        Next
        dgvProveedor.DataSource = dt
    End Sub
#End Region

#Region "Charts"
    Public Shared Sub ApplyChartStylesPie(chart As ChartControl)

        '#Region "ApplyCustomPalette"
        '  chart.Skins = Skins.Metro
        '#End Region

        '#Region "Chart Appearance Customization"

        chart.BorderAppearance.SkinStyle = Syncfusion.Windows.Forms.Chart.ChartBorderSkinStyle.None
        chart.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        chart.ElementsSpacing = 0
        chart.Series(0).ConfigItems.PieItem.HeightByAreaDepth = False
        chart.Series(0).ConfigItems.PieItem.HeightCoeficient = 0.1F
        chart.Tilt = 90
        '#End Region

        '#Region "Legend Customization"
        For i As Integer = 0 To chart.Legend.Items.Length - 1
            chart.Legend.Items(i).Spacing = 2
            chart.Legend.ItemsSize = New Size(13, 13)
            chart.Legend.Items(i).TextAligment = Syncfusion.Windows.Forms.Chart.VerticalAlignment.Bottom
            chart.Legend.BackColor = Color.Transparent
            chart.LegendsPlacement = ChartPlacement.Outside
            chart.LegendAlignment = ChartAlignment.Center
            chart.LegendPosition = ChartDock.Bottom
            chart.Legend.Font = New Font("Segoe UI", 7.0F)
            chart.Legend.ForeColor = Color.DimGray
        Next
        '#End Region
    End Sub

    Private Sub PieFlujoEfectivo()
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim compraSA As New DocumentoCompraSA
        Dim lista As New List(Of documentocompra)
        Dim documentoCaja As New List(Of documentoCaja)
        Dim coNteo As Byte = 0


        lista = compraSA.GetTotalComprasByPeriodoProveedor(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                      .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                      .fechaContable = PeriodoGeneral})


        Dim series1 As New ChartSeries("Proveedor")

        For Each i In lista

            '   series1.Points.Add(coNteo, i.importeTotal)

            coNteo += 1
        Next

        'series1.Points.Add(0, 20)
        'series1.Points.Add(1, 28)
        'series1.Points.Add(2, 23)
        'series1.Points.Add(3, 10)
        'series1.Points.Add(4, 12)
        'series1.Points.Add(5, 3)
        'series1.Points.Add(6, 2)
        series1.Type = ChartSeriesType.Pie
        Me.ChartControl3.Series.Add(series1)
        series1.OptimizePiePointPositions = True

        For i As Integer = 0 To series1.Points.Count - 1
            series1.Styles(i).Border.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
            series1.Styles(i).Border.Color = Color.White
        Next

        If lista.Count > 0 Then

            Dim x As Integer = 0
            For Each i In lista
                'series1.Styles(x).Text = String.Format(i.nombreProveedor & " {0}", series1.Points(x).YValues(0))
                series1.Styles(x).Text = String.Format(i.nombreProveedor & "{0}", FormatCurrency(i.importeTotal, 2))
                x = x + 1

            Next

            'Dim importeNac As Decimal = series1.Points(0).YValues(0)
            'Dim importeEx As Decimal = series1.Points(1).YValues(0)
            'series1.Styles(0).Text = String.Format("Ingresos {0}", FormatCurrency(importeNac, 2))

            'series1.Styles(1).Text = String.Format("Egresos {0}", FormatCurrency(importeEx, 2))
            ''series1.Styles(2).Text = String.Format("Facilities {0}%", series1.Points(2).YValues(0))
            ''series1.Styles(3).Text = String.Format("Taxes {0}%", series1.Points(3).YValues(0))
            ''series1.Styles(4).Text = String.Format("Insurance{0}%", series1.Points(4).YValues(0))
            ''series1.Styles(5).Text = String.Format("Licenses {0}%", series1.Points(5).YValues(0))
            ''series1.Styles(6).Text = String.Format("Legal {0}%", series1.Points(6).YValues(0))

            series1.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.OutsideInColumn
            series1.Style.DisplayText = False
            series1.Style.Font.Size = 7.0F
            series1.ConfigItems.PieItem.AngleOffset = 60
            'series1.Style.Border.Color = Color.White
            'series1.Style.Border.DashStyle = DashStyle.Solid
            '  ChartControl3.Series3D = True
            ' Me.ChartControl3.Series(0).ConfigItems.PieItem.HeightCoeficient = 0.1

            ChartControl3.Series(0).ShowTicks = False
            ChartControl3.Series(0).Styles(0).Border.Color = Color.Transparent
            ChartControl3.Series(0).Styles(1).Border.Color = Color.Transparent
            ChartControl3.Series(0).ConfigItems.PieItem.DoughnutCoeficient = 0.5

            ChartControl3.Model.ColorModel.CustomColors = New Color() {Color.FromArgb(46, 198, 217),
                                                 Color.FromArgb(218, 106, 139),
                                                 Color.FromArgb(126, 40, 126),
                                                 Color.FromArgb(56, 83, 164),
                                                                       Color.Green}
            ChartControl3.Model.ColorModel.Palette = ChartColorPalette.Custom
            ChartControl3.ShowLegend = True
            ChartControl3.Series(0).OptimizePiePointPositions = True

        End If
    End Sub

    Protected Sub InitializeChartData()
        Dim compraSA As New DocumentoCompraSA
        Dim lista As New List(Of documentocompra)
        Dim series As New ChartSeries

        lista = compraSA.GetTatalResumenComprasXtipo(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                .fechaContable = PeriodoGeneral})

        series.Points.Clear()
        ChartControl2.Series.Clear()

        For Each i In lista
            series = New ChartSeries(i.tipoCompra, ChartSeriesType.Bar)
            '   series.Points.Add(i.CountCompras, i.importeTotal)

            Me.ChartControl2.Series.Add(series)
        Next

        'Dim series As New ChartSeries("Server 1", ChartSeriesType.Bar)
        'series.Points.Add(16, 225)
        'series.Points.Add(4, 325)
        'series.Points.Add(8, 275)
        'series.Points.Add(12, 320)

        'Dim series1 As New ChartSeries("Server 2", ChartSeriesType.Bar)
        'series1.Points.Add(16, 325)
        'series1.Points.Add(4, 300)
        'series1.Points.Add(8, 315)
        'series1.Points.Add(12, 300)

        'Me.chartControl1.Series.Add(series)
        'Me.chartControl1.Series.Add(series1)
    End Sub

    Public Shared Sub ApplyChartStylesDefault(chart As ChartControl)
        '#Region "ApplyCustomPalette"
        chart.Skins = Syncfusion.Windows.Forms.Chart.Skins.Metro
        '#End Region

        '#Region "Chart Appearance Customization"
        chart.BorderAppearance.SkinStyle = Syncfusion.Windows.Forms.Chart.ChartBorderSkinStyle.None
        chart.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        chart.ChartArea.PrimaryXAxis.HidePartialLabels = True
        chart.ElementsSpacing = 4

        '#End Region

        '#Region "Axes Customization"


        chart.PrimaryXAxis.RangePaddingType = ChartAxisRangePaddingType.Calculate
        'chart.PrimaryYAxis.RangePaddingType = ChartAxisRangePaddingType.Calculate;
        'chart.PrimaryXAxis.Title = "Server load(MBytes)"
        'chart.Text = "Peak Average Network Load"

        chart.PrimaryYAxis.RangeType = ChartAxisRangeType.[Set]
        'chart.PrimaryYAxis.Range = New MinMaxInfo(0, 20, 4)
        'chart.PrimaryYAxis.Title = "Peak Load Hours"


        '#End Region
        '#Region "Legend Customization"
        For i As Integer = 0 To chart.Legend.Items.Length - 1
            chart.Legend.Items(i).Spacing = 2
            chart.Legend.ItemsSize = New Size(13, 13)
            chart.Legend.Items(i).TextAligment = Syncfusion.Windows.Forms.Chart.VerticalAlignment.Bottom
            chart.Legend.BackColor = Color.Transparent
            chart.LegendsPlacement = ChartPlacement.Outside
            chart.LegendAlignment = ChartAlignment.Center
            chart.LegendPosition = ChartDock.Bottom
            chart.Legend.Font = New Font("Segoe UI", 8.25F)
        Next
        '#End Region
    End Sub

    Public Sub InitializeChart()
        Dim series As New ChartSeries
        Dim listaX As New List(Of documentocompra)
        ' Initialize ChartSeries
        Dim colors As Color() = New Color() {Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen}

        series = New ChartSeries("Compras")

        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoVentaSA As New documentoVentaAbarrotesSA

        Dim lista As New List(Of documentocompra)
        Dim listaVenta As New List(Of documentoventaAbarrotes)

        lista = documentoCompraSA.GetListarComprasPorAnio(GEstableciento.IdEstablecimiento, AnioGeneral)
        series.Points.Clear()
        chartControl1.Series.Clear()
        For Each i In lista
            Dim s = CDate(1 & "/" & i.fechaContable)
            '    series.Points.Add(CDate(s).Month, i.importeTotal)
            Select Case CDate(s).Month
                Case Val(MesGeneral)
                    lblGasto.Text = CDec(i.importeTotal).ToString("N2")
            End Select
        Next
        series.Type = ChartSeriesType.Column
        series.Text = series.Name

        Me.chartControl1.Series.Add(series)

        For i As Integer = 0 To colors.Length - 1
            series.Styles(i).Interior = New BrushInfo(colors(i))

        Next
        series.Style.Border.Color = Color.White
        series.Style.Border.DashStyle = DashStyle.Solid

        'listaVenta = documentoVentaSA.GetListarComprasPorAnio(GEstableciento.IdEstablecimiento, AnioGeneral)
        'dsfsd()
        'series = New ChartSeries("Compras")
        ''      Dim series2 As New ChartSeries("Ventas")
        'For Each i In listaVenta
        '    Dim s = CDate(1 & "/" & i.fechaPeriodo)
        '    series.Points.Add(CDate(s).Month, i.CountVentas)
        'Next

        Dim colors2 As Color() = New Color() {Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                              Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                              Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                              Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                              Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                              Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141)}
        For i As Integer = 0 To colors.Length - 1
            series.Styles(i).Interior = New BrushInfo(colors2(i))

        Next

        series.Type = ChartSeriesType.Column
        series.Text = series.Name
        series.Style.Border.Color = Color.White
        series.Style.Border.DashStyle = DashStyle.Solid
        Me.chartControl1.Series.Add(series)

        chartControl1.PrimaryXAxis.Range = New MinMaxInfo(0, 13, 1)

        chartControl1.Series3D = False
        Me.chartControl1.ColumnWidthMode = ChartColumnWidthMode.DefaultWidthMode

        lblComprasPeriodo.Text = documentoCompraSA.GetNumComprasXparameter(New documentocompra With {.idCentroCosto = GEstableciento.IdEstablecimiento, .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                                 .fechaContable = PeriodoGeneral, .fechaDoc = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)}, "PERIODO")


        lblComprasDia.Text = documentoCompraSA.GetNumComprasXparameter(New documentocompra With {.idCentroCosto = GEstableciento.IdEstablecimiento, .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                                 .fechaContable = PeriodoGeneral, .fechaDoc = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)}, "DIA")



        listaX = documentoCompraSA.GetSumaNotasXperiodo(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .fechaContable = PeriodoGeneral})

        For Each i In listaX
            Select Case i.tipoCompra
                Case TIPO_COMPRA.NOTA_CREDITO
                    lblSumNC.Text = CDbl(i.importeTotal).ToString("N2")
                Case TIPO_COMPRA.NOTA_DEBITO
                    lblSumNB.Text = CDbl(i.importeTotal).ToString("N2")
            End Select
        Next

    End Sub
#End Region

#Region "Métodos"

    Public Sub CambiarStatusEntidad(r As Record)
        Dim entidadSA As New entidadSA

        entidadSA.CambiarStatusEntidad(New entidad With {.idEntidad = Val(r.GetValue("idEntidad")),
                                                         .estado = StatusEntidad.Inactivo})

        MessageBox.Show("Proveedor se cambio a estado a inactivo!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ListaProveedores()
    End Sub

    Public Sub GetCountDetracciones()
        Dim compraSA As New DocumentoCompraSA

        Dim compra = compraSA.GetConteoDetracciones(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                   .fechaContable = String.Concat(cboMes.SelectedValue, "/", txtAnio.Text), .tieneDetraccion = "S"})
        lblCenter = New Label
        lblCenter.Text = compra

        'lblCenter = New Label
        'lblCenter.ForeColor = Color.White
        'lblCenter.AutoSize = True
        lblCenter.Font = New Font("Segoe UI", 10, FontStyle.Regular)

    End Sub

    Private Sub UpdateDataDetraccion(be As documentocompra)
        Dim compraSA As New DocumentoCompraSA
        Dim compra As New documentocompra

        compra = New documentocompra With {.idDocumento = be.idDocumento,
                                           .fechaConstancia = be.fechaConstancia,
                                           .nroConstancia = be.nroConstancia,
                                           .periodoTributo = be.periodoTributo
                                          }

        compraSA.UpdateDataDetraccion(compra)
        MessageBox.Show("data actualizada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub getDetracciones(be As documentocompra)
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("razon")
        dt.Columns.Add("importe")
        dt.Columns.Add("importeME")
        dt.Columns.Add("periodoTributo")
        dt.Columns.Add("fechaConstancia")
        dt.Columns.Add("nroConstancia")
        dt.Columns.Add("confirmar")

        For Each i In compraSA.GetListadoDetracciones(be)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.tipoDoc
            dr(3) = i.serie
            dr(4) = i.numeroDoc
            dr(5) = i.nombreProveedor
            dr(6) = i.importeTotal
            dr(7) = i.importeUS
            dr(8) = i.periodoTributo
            If IsNothing(i.periodoTributo) Then
                dr(9) = String.Empty
            Else
                dr(9) = i.fechaConstancia.GetValueOrDefault
            End If
            dr(10) = i.nroConstancia
            If Not IsNothing(i.nroConstancia) Then
                dr(11) = True
            Else
                dr(11) = False
            End If

            dt.Rows.Add(dr)
        Next
        dgvDetracciones.DataSource = dt

    End Sub

    Private Sub Meses()
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x
        cboMes.DisplayMember = "Mes"
        cboMes.ValueMember = "Codigo"
        cboMes.DataSource = listaMeses

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    Public Sub EliminarReciboHonorario(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        With objDocumento
            .idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
        End With
        documentoSA.DeleteReciboHonorario(objDocumento)
        Me.dgvCompras.Table.CurrentRecord.Delete()
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        lblEstado.Text = "Recibo Honorario eliminado!"
    End Sub
    Public Sub EliminarServicioPublico(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        With objDocumento
            .idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
        End With
        documentoSA.DeleteReciboHonorario(objDocumento)
        Me.dgvCompras.Table.CurrentRecord.Delete()
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        lblEstado.Text = "Recibo Publico eliminado!"
    End Sub
    Public Sub EliminarNota(intIdDocumentoNota As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        Dim notaCredito As documentocompra
        Try
            notaCredito = compraSA.UbicarDocumentoCompra(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaCredito.idPadre ' Compra
                .idDocumento = intIdDocumentoNota
            End With
            compraSA.EliminarNotaCreditoMetodoNuevo(objDocumento)
            Me.dgvCompras.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarNotaCreditoBonificacion(intIdDocumentoNota As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        Dim notaCredito As documentocompra
        Try
            notaCredito = compraSA.UbicarDocumentoCompra(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                ' .IdDocumentoAfectado = notaCredito.idPadre ' Compra
                .idDocumento = intIdDocumentoNota
            End With
            compraSA.EliminarNotaCreditoBonificacion(objDocumento)
            Me.dgvCompras.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub EliminarDebito(intIdDocumentoNota As Integer)
        Dim compraSA As New DocumentoCompraSA
        Dim objDocumento As New documento
        Dim notaDebito As documentocompra
        Try
            notaDebito = compraSA.UbicarDocumentoCompra(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaDebito.idPadre ' venta
                .idDocumento = intIdDocumentoNota
                .ImporteMN = dgvCompras.Table.CurrentRecord.GetValue("importeTotal")
                .ImporteME = dgvCompras.Table.CurrentRecord.GetValue("importeUS")
            End With
            compraSA.EliminarNotaDebitoMetodoNuevo(objDocumento)
            Me.dgvCompras.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub


    Sub ActualizarEstadoCompras(strEstado As String)
        Dim compraSA As New DocumentoCompraSA
        Dim listaCompras As New List(Of documentocompra)
        Dim obj As New documentocompra
        Try
            listaCompras = New List(Of documentocompra)
            For Each rec As SelectedRecord In dgvCompras.Table.SelectedRecords
                obj = New documentocompra
                obj.idDocumento = rec.Record.GetValue("idDocumento")
                obj.aprobado = strEstado
                listaCompras.Add(obj)

                Select Case strEstado
                    Case "S"
                        rec.Record.SetValue("Aprobado", "Aprobado")
                    Case Else
                        rec.Record.SetValue("Aprobado", "Pendiente")
                End Select

            Next
            compraSA.ListaComprasAutoriza(listaCompras)
            lblEstado.Text = "Tarea realizada con exito!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        GFichaUsuarios = New GFichaUsuario
        With frmFichaUsuarioCaja
            ModuloAppx = ModuloSistema.CAJA
            .lblNivel.Text = "Caja"
            .lblEstadoCaja.Visible = True
            '.GroupBox1.Visible = True
            '.GroupBox2.Visible = True
            '.GroupBox4.Visible = True
            '.cboMoneda.Visible = True
            .Timer1.Enabled = False
            .ManipulacionEstado = ENTITY_ACTIONS.DELETE
            .StartPosition = FormStartPosition.CenterParent
            '.UbicarUsuarioCaja(intIdDocumento, "COMPRA")
            .ShowDialog()
            If IsNothing(GFichaUsuarios.NombrePersona) Then
                Return False
            Else
                Return True
            End If
        End With

        Return True

    End Function

    Public Sub RemoveCompraCredito(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = "Jiuni"
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvCompras.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompras.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With
        documentoSA.DeleteDocumentoSL(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarCompraGeneral(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = usuario.IDUsuario
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvCompras.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompras.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With
        documentoSA.EliminarCompraGeneral(objDocumento)
    End Sub

    Public Sub RemoveCompraCreditoSingle(IntIdDocumento As Integer)

        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvCompras.Table.CurrentRecord.GetValue("tipoDoc")

                        Select Case Me.dgvCompras.Table.CurrentRecord.GetValue("tipoDoc")
                            Case "03", "02"
                                objNuevo.importeSoles = i.importe
                                objNuevo.importeDolares = i.importeUS
                            Case Else
                                Select Case i.destino
                                    Case "1"
                                        objNuevo.importeSoles = i.montokardex
                                        objNuevo.importeDolares = i.montokardexUS
                                    Case Else
                                        objNuevo.importeSoles = i.importe
                                        objNuevo.importeDolares = i.importeUS
                                End Select
                        End Select

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)
                    End If
                End If
            End If
        Next
        documentoSA.DeleteDocumento(objDocumento, ListaTotales)
    End Sub

    Public Sub RemoveCompraSimpleRetSL(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen

        With objDocumento
            .idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GFichaUsuarios) Then
                .usuarioActualizacion = Nothing
            Else
                .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            End If
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvCompras.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompras.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With

        documentoSA.DeleteDocumentoPagadoAlCredito(objDocumento)

    End Sub

    Public Sub RemoveCompraSL(IntIdDocumento As Integer)

        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen

        With objDocumento
            .idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvCompras.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompras.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With
        documentoSA.DeleteDocumentoPagadoSL(objDocumento)
    End Sub

    Public Sub EliminarCompraDirectaSinRecepcionSL(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .tipoDoc = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
        End With

        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvCompras.Table.CurrentRecord.GetValue("tipoDoc")

                        Select Case Me.dgvCompras.Table.CurrentRecord.GetValue("tipoDoc")
                            Case "03", "02"
                                objNuevo.importeSoles = i.importe
                                objNuevo.importeDolares = i.importeUS
                            Case Else
                                Select Case i.destino
                                    Case "1"
                                        objNuevo.importeSoles = i.montokardex
                                        objNuevo.importeDolares = i.montokardexUS
                                    Case Else
                                        objNuevo.importeSoles = i.importe
                                        objNuevo.importeDolares = i.importeUS
                                End Select
                        End Select

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)
                    End If
                End If
            End If
        Next

        documentoSA.DeleteCompraDirectaSinRecepcionSL(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarCompraDirectaSinRecepcionRecepSL(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = "Jiuni"
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvCompras.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvCompras.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With
        documentoSA.DeleteDocumentoSL(objDocumento, ListaTotales)
    End Sub



    Private Sub getTableComprasPorDiaCredito(intIdEstablecimiento As Integer)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String

        Select Case AutorizacionRolList(0).IDRol
            Case 1
                DocumentoCompra = DocumentoCompraSA.GetListarComprasPorDia_CONT_CREDITO(intIdEstablecimiento)
            Case 2
                DocumentoCompra = DocumentoCompraSA.GetListarComprasPorDia_CONT_CREDITO(intIdEstablecimiento, GFichaUsuarios.IdCajaUsuario)
        End Select

        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt

    End Sub



    Private Sub getTableComprasPorPeriodoCredito(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String

        Select Case AutorizacionRolList(0).IDRol
            Case 1
                DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CREDITO(intIdEstablecimiento, strPeriodo)
            Case 2
                DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CREDITO(intIdEstablecimiento, strPeriodo, GFichaUsuarios.IdCajaUsuario)
        End Select

        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt

    End Sub

    Private Sub getListarTodasLasComprasxDia(intIdEstablecimiento As Integer)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListAllComprasxDia(intIdEstablecimiento)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt

    End Sub
    Private Sub getListarTodasLasCompras(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListAllCompras(intIdEstablecimiento, strPeriodo)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt

    End Sub



    Private Sub getTableComprasPorDiaContado(intIdEstablecimiento As Integer)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))

        Dim str As String


        Select Case AutorizacionRolList(0).IDRol
            Case 1
                DocumentoCompra = DocumentoCompraSA.GetListarComprasPorDia_CONT_CONTADO(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Case 2
                DocumentoCompra = DocumentoCompraSA.GetListarComprasPorDia_CONT_CONTADO(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, GFichaUsuarios.IdCajaUsuario)
        End Select

        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            Select Case i.aprobado
                Case "S"
                    dr(17) = "Aprobado"
                Case Else
                    dr(17) = "Pendiente"
            End Select
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub getTableOrdenDeComprasPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String, tipoCompra As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)
        Dim MONEDAORDEN As Integer
        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("nombrePersona", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))


        'Select Case AutorizacionRolList(0).IDRol
        '    Case 1

        Select Case cboMonedaCobro.Text
            Case "NACIONAL"
                MONEDAORDEN = 1
            Case "EXTRANJERA"
                MONEDAORDEN = 2
        End Select

        DocumentoCompra = DocumentoCompraSA.GetListarOrdenComprasPorPeriodoGeneral(intIdEstablecimiento, strPeriodo, tipoCompra)
        '    Case 2
        'DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(intIdEstablecimiento, strPeriodo, GFichaUsuarios.IdCajaUsuario)
        'End Select

        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc

            dr(6) = i.NombreEntidad
            If i.tipoCompra = "BOFR" Then
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                dr(9) = CDec(0.0)
            Else
                dr(7) = i.importeTotal
                dr(8) = i.tcDolLoc
                dr(9) = i.importeUS
            End If



            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(10) = i.monedaDoc
            'dr(12) = i.usuarioActualizacion
            dr(11) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(12) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(12) = "Pendiente"
            End Select

            'Select Case i.aprobado
            '    Case "S"
            '        dr(15) = "Aprobado"
            '    Case Else
            '        dr(15) = "Pendiente"
            'End Select
            'dr(16) = i.Atraso
            dt.Rows.Add(dr)
        Next
        dgvOrdenCompra.DataSource = dt
        dgvOrdenCompra.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub getTableOrdenDeComprasPorFiltro(intIdEstablecimiento As Integer, strPeriodo As String, tipoCompra As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)
        Dim MONEDAORDEN As Integer
        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("nombrePersona", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))


        'Select Case AutorizacionRolList(0).IDRol
        '    Case 1

        Select Case cboMonedaCobro.Text
            Case "NACIONAL"
                MONEDAORDEN = 1
            Case "EXTRANJERA"
                MONEDAORDEN = 2
        End Select

        DocumentoCompra = DocumentoCompraSA.GetListarOrdenComprasPorFiltro(intIdEstablecimiento, strPeriodo, tipoCompra, txtCliente.Tag, MONEDAORDEN)
        '    Case 2
        'DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(intIdEstablecimiento, strPeriodo, GFichaUsuarios.IdCajaUsuario)
        'End Select

        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc

            dr(6) = i.NombreEntidad
            If i.tipoCompra = "BOFR" Then
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                dr(9) = CDec(0.0)
            Else
                dr(7) = i.importeTotal
                dr(8) = i.tcDolLoc
                dr(9) = i.importeUS
            End If



            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(10) = i.monedaDoc
            'dr(12) = i.usuarioActualizacion
            dr(11) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(12) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(12) = "Pendiente"
            End Select

            'Select Case i.aprobado
            '    Case "S"
            '        dr(15) = "Aprobado"
            '    Case Else
            '        dr(15) = "Pendiente"
            'End Select
            'dr(16) = i.Atraso
            dt.Rows.Add(dr)
        Next
        dgvOrdenCompra.DataSource = dt
        dgvOrdenCompra.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub getTableOrdenDeServiciosPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String))) '5


        dt.Columns.Add(New DataColumn("nombrePersona", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String))) '10
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoServicio", GetType(String))) '13

        'Select Case AutorizacionRolList(0).IDRol
        '    Case 1
        DocumentoCompra = DocumentoCompraSA.GetListarOrdenServiciosPorPeriodoGeneral(intIdEstablecimiento, strPeriodo)
        '    Case 2
        'DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(intIdEstablecimiento, strPeriodo, GFichaUsuarios.IdCajaUsuario)
        'End Select

        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc

            dr(6) = i.NombreEntidad
            If i.tipoCompra = "BOFR" Then
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                dr(9) = CDec(0.0)
            Else
                dr(7) = i.importeTotal
                dr(8) = i.tcDolLoc
                dr(9) = i.importeUS
            End If



            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(10) = i.monedaDoc
            'dr(12) = i.usuarioActualizacion
            dr(11) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(12) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(12) = "Pendiente"
            End Select
            dr(13) = i.usuarioActualizacion
            'Select Case i.aprobado
            '    Case "S"
            '        dr(15) = "Aprobado"
            '    Case Else
            '        dr(15) = "Pendiente"
            'End Select
            'dr(16) = i.Atraso
            dt.Rows.Add(dr)
        Next
        dgvOrdenServicio.DataSource = dt
        dgvOrdenServicio.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub getTableComprasPorPeriodoContado(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Período: " & strPeriodo & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add("detraccion")

        Select Case AutorizacionRolList(0).IDRol
            Case 1
                DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, strPeriodo)
            Case 2
                DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, strPeriodo, GFichaUsuarios.IdCajaUsuario)
            Case 3
                DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, strPeriodo, GFichaUsuarios.IdCajaUsuario)
        End Select

        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona

            If i.tipoCompra = "BOFR" Then
                dr(10) = CDec(0.0)
                dr(11) = CDec(0.0)
                dr(12) = CDec(0.0)
            Else
                dr(10) = i.importeTotal
                dr(11) = i.tcDolLoc
                dr(12) = i.importeUS
            End If



            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            Select Case i.aprobado
                Case "S"
                    dr(17) = "Aprobado"
                Case Else
                    dr(17) = "Pendiente"
            End Select
            dr(18) = i.Atraso
            dr(19) = If(i.tieneDetraccion = "S", "Si", "No")
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        dgvCompras.TopLevelGroupOptions.ShowCaption = True
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

    Sub GridCFG_Detracccion(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.None
        GGC.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub


#End Region




    Private Sub frmMasterComprasGenerales_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMasterComprasGenerales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EmpresaToolStripMenuItem.Text = "Empresa: " & Gempresas.NomEmpresa
        EstablecimientoToolStripMenuItem.Text = "Establecimiento: " & GEstableciento.NombreEstablecimiento

        dgvDetracciones.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        treeViewAdv2.LeftImageList = ImageList1

        For Each node As TreeNodeAdv In Me.treeViewAdv2.Nodes
            node.LeftImageIndices = New Integer() {node.Index}
            'node.RightImageIndices = New Integer() {-1}
        Next node

        treeViewAdv2.BackColor = Color.DimGray ' Color.FromArgb(41, 44, 51)

        TabPageAdv1.Parent = TabControlAdv1
        TabPageAdv2.Parent = Nothing
        TabDashboard.Parent = Nothing
        TabDetracción.Parent = Nothing
        TabOrdenCompra.Parent = Nothing
        TabOrdenServicio.Parent = Nothing

        lblCenter.AutoSize = False
        lblCenter.BackColor = Color.Transparent
        lblCenter.Dock = DockStyle.Fill
        lblCenter.ForeColor = Color.Yellow
        lblCenter.TextAlign = ContentAlignment.MiddleLeft
        Me.treeViewAdv2.Nodes(4).CustomControl = lblCenter

        'treeViewAdv2.SelectedNode
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor

        Select Case treeViewAdv2.SelectedNode.Text
            Case "Dashboard"
                'InitializeChart()
                'ChartAppearance.ApplyChartStyles(Me.chartControl1)
                'Me.chartControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

                'InitializeChartData()
                'ApplyChartStylesDefault(Me.ChartControl2)
            Case "Compras del período"
                'If rbPeriodo.Checked = True Then
                '    getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
                'ElseIf rbDia.Checked = True Then
                '    getTableComprasPorDiaContado(GEstableciento.IdEstablecimiento)
                'End If
            Case "Compras al contado"

                '    If AutorizacionRolSA.TienePermiso(ModuloAsegurable.REGISTRO_DE_COMPRAS, AutorizacionRolList) Then
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                If rbPeriodo.Checked = True Then
                    getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add("Compra al contado c/recep. exist.")
                    ListBox1.Items.Add("Compra al contado c/exist. transit.")
                    ' Tag = False

                ElseIf rbDia.Checked = True Then
                    getTableComprasPorDiaContado(GEstableciento.IdEstablecimiento)
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add("Compra al contado c/recep. exist.")
                    ListBox1.Items.Add("Compra al contado c/exist. transit.")
                    'Tag = False

                End If
                TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text
                'Else
                'MessageBoxAdv.Show("Usuario no autorizado")
                'End If



            Case "Compras al crédito"
                '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.REGISTRO_DE_COMPRAS, AutorizacionRolList) Then
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                If rbPeriodo.Checked = True Then
                    getTableComprasPorPeriodoCredito(GEstableciento.IdEstablecimiento, PeriodoGeneral)
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add("Compra al credito c/recep. exist.")
                    ListBox1.Items.Add("Compra al credito c/exist. transit.")
                    'Tag = False

                ElseIf rbDia.Checked = True Then
                    getTableComprasPorDiaCredito(GEstableciento.IdEstablecimiento)
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add("Compra al credito c/recep. exist.")
                    ListBox1.Items.Add("Compra al credito c/exist. transit.")
                    'Tag = False
                End If
                TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text
                'Else
                'MessageBoxAdv.Show("Usuario no autorizado")
                'End If


            Case "Proveedores"
                '  If AutorizacionRolSA.TienePermiso(ModuloAsegurable.PROVEEDORES, AutorizacionRolList) Then
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                ListaProveedores()
                ListBox1.Items.Clear()
                Tag = True
                'Else
                'MessageBoxAdv.Show("Usuario no autorizado")
                'End If


            Case "Todas las Compras"

                '    If AutorizacionRolSA.TienePermiso(ModuloAsegurable.REGISTRO_DE_COMPRAS, AutorizacionRolList) Then
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                If rbPeriodo.Checked = True Then
                    getListarTodasLasCompras(GEstableciento.IdEstablecimiento, PeriodoGeneral)
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add("Compra al credito c/recep. exist.")
                    ListBox1.Items.Add("Compra al credito c/exist. transit.")
                    ListBox1.Items.Add("Compra al contado c/recep. exist.")
                    ListBox1.Items.Add("Compra al contado c/exist. transit.")
                    ListBox1.Items.Add("Nuevo proveedor")
                    'Tag = False

                ElseIf rbDia.Checked = True Then
                    getListarTodasLasComprasxDia(GEstableciento.IdEstablecimiento)
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add("Compra al credito c/recep. exist.")
                    ListBox1.Items.Add("Compra al credito c/exist. transit.")
                    ListBox1.Items.Add("Compra al contado c/recep. exist.")
                    ListBox1.Items.Add("Compra al contado c/exist. transit.")
                    ListBox1.Items.Add("Nuevo proveedor")
                    'Tag = False

                End If
                TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text
                'Else
                'MessageBoxAdv.Show("Usuario no autorizado")
                'End If

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Compra de Existencias, Servicios y Activo Inmv."
                Dim f As New frmCompras
                f.WindowState = FormWindowState.Maximized
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.ShowDialog()
                Dim SaldoCaja As New UsuarioEstadoCaja
                SaldoCaja.GetSaldoActual(GFichaUsuarios)
                Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
            Case "Registro de Honorarios"
                Dim f As New frmReciboHonorarios
                f.WindowState = FormWindowState.Maximized
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.Show()

            Case "Compra de Servicios Públicos"
                Dim f As New frmServicioPublico
                f.WindowState = FormWindowState.Maximized
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.ShowDialog()
                Dim SaldoCaja As New UsuarioEstadoCaja
                SaldoCaja.GetSaldoActual(GFichaUsuarios)
                Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
            Case "Notas de Crédito"

                If Not IsNothing(GFichaUsuarios) Then
                    'Dim f As New frmCreditoCompra
                    'f.ShowDialog()
                    'Dim SaldoCaja As New UsuarioEstadoCaja
                    'SaldoCaja.GetSaldoActual(GFichaUsuarios)
                    'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                Else
                    lblEstado.Text = "Debe inciar una caja, para realizar està tarea!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If

            Case "Notas de Débito"
                If Not IsNothing(GFichaUsuarios) Then
                    'Dim f As New frmNotasDebito
                    'f.ShowDialog()
                    'Dim SaldoCaja As New UsuarioEstadoCaja
                    'SaldoCaja.GetSaldoActual(GFichaUsuarios)
                    'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                Else
                    lblEstado.Text = "Debe inciar una caja, para realizar està tarea!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            Case "Proveedores"
                With frmCrearENtidades
                    .CaptionLabels(0).Text = "Nuevo proveedor"
                    .strTipo = TIPO_ENTIDAD.PROVEEDOR
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '.intIdEntidad = Me.dgvProveedor.Table.CurrentRecord.GetValue("idEntidad")
                    '.UbicarEntidad(Me.dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
                ListBox1.Items.Clear()

            Case "Todas las Compras"

                ListBox1.Items.Clear()
                ListBox1.Items.Add("Nuevo proveedor")
                Me.PopupControlContainer2.ParentControl = Me.btOperacion
                Me.PopupControlContainer2.ShowPopup(Point.Empty)
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            Select Case ListBox1.Text
                Case "Compra al credito c/recep. exist."

                    '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.COMPRAS_AL_CREDITO_CON_RECEPCION, AutorizacionRolList) Then
                    Dim cierreSA As New CierreContableSA
                    Dim cierre As New cierrecontable
                    cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

                    If Not IsNothing(cierre) Then
                        'Select Case cierre.estado
                        '    Case "C"
                        '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
                        '        PanelError.Visible = True
                        '        Timer1.Enabled = True
                        '        TiempoEjecutar(10)
                        '    Case "A"
                        '        With frmCompraCreditoConRecepcion
                        '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        '            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        '            '     .lblPerido.Text = PeriodoGeneral
                        '            .StartPosition = FormStartPosition.CenterParent
                        '            .WindowState = FormWindowState.Maximized
                        '            .ShowDialog()
                        '        End With

                        'End Select
                    Else
                        'With frmCompraCreditoConRecepcion
                        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        '    ' .lblPerido.Text = PeriodoGeneral
                        '    .StartPosition = FormStartPosition.CenterParent
                        '    .WindowState = FormWindowState.Maximized
                        '    .ShowDialog()
                        'End With
                    End If
                    'Else
                    'MessageBoxAdv.Show("Usuario no autorizado")
                    'End If




                Case "Compra al credito c/exist. transit."

                    '    If AutorizacionRolSA.TienePermiso(ModuloAsegurable.COMPRAS_AL_CREDITO_SIN_RECEPCION, AutorizacionRolList) Then
                    Dim cierreSA As New CierreContableSA
                    Dim cierre As New cierrecontable
                    cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

                    If Not IsNothing(cierre) Then
                        'Select Case cierre.estado
                        '    Case "C"
                        '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
                        '        PanelError.Visible = True
                        '        Timer1.Enabled = True
                        '        TiempoEjecutar(10)
                        '    Case "A"
                        '        With frmCompraCreditoSinRecepcion
                        '            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        '            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        '            '   .lblPerido.Text = PeriodoGeneral
                        '            .StartPosition = FormStartPosition.CenterParent
                        '            .WindowState = FormWindowState.Maximized
                        '            .ShowDialog()
                        '        End With

                        'End Select
                    Else
                        'With frmCompraCreditoSinRecepcion
                        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        '    ' .lblPerido.Text = PeriodoGeneral
                        '    .StartPosition = FormStartPosition.CenterParent
                        '    .WindowState = FormWindowState.Maximized
                        '    .ShowDialog()
                        'End With
                    End If
                    'Else
                    'MessageBoxAdv.Show("Usuario no autorizado")
                    'End If


                Case "Compra al contado c/recep. exist."

                    '    If AutorizacionRolSA.TienePermiso(ModuloAsegurable.COMPRAS_AL_CONTADO_CON_RECEPCION, AutorizacionRolList) Then
                    Dim cierreSA As New CierreContableSA
                    Dim cierre As New cierrecontable
                    cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

                    If Not IsNothing(cierre) Then
                        'Select Case cierre.estado
                        '    Case "C"
                        '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
                        '        PanelError.Visible = True
                        '        Timer1.Enabled = True
                        '        TiempoEjecutar(10)
                        '    Case "A"


                        '        If IsNothing(GFichaUsuarios) Then
                        '            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        '            PanelError.Visible = True
                        '            Timer1.Enabled = True
                        '            TiempoEjecutar(10)
                        '        Else
                        '            If GFichaUsuarios.SaldoMN <= 0 Then
                        '                lblEstado.Text = "No puede realizar la compra, monto en caja insuficiente!"
                        '                PanelError.Visible = True
                        '                Timer1.Enabled = True
                        '                TiempoEjecutar(10)
                        '            Else
                        '                With frmCompraDirectaRecepcion
                        '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '                    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        '                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        '                    .lblPerido.Text = lblPeriodo.Text
                        '                    .StartPosition = FormStartPosition.CenterParent
                        '                    .WindowState = FormWindowState.Maximized
                        '                    .ShowDialog()
                        '                    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                        '                End With
                        '            End If

                        '        End If
                        '        'If .TieneCuentaFinanciera = True Then

                        '        'Else

                        '        'End If

                        'End Select
                    Else
                        ' MsgBox("")

                        If IsNothing(GFichaUsuarios) Then
                            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(5)
                        Else

                            If GFichaUsuarios.SaldoMN <= 0 Then
                                lblEstado.Text = "No puede realizar la compra, monto en caja insuficiente!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                            Else
                                'With frmCompraDirectaRecepcion
                                '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                                '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                                '    .lblPerido.Text = lblPeriodo.Text
                                '    .StartPosition = FormStartPosition.CenterParent
                                '    .WindowState = FormWindowState.Maximized
                                '    .ShowDialog()
                                '    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                                'End With
                            End If
                        End If
                    End If
                    'Else
                    'MessageBoxAdv.Show("Usuario no autorizado")
                    'End If

                Case "Compra al contado c/exist. transit."


                    '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.COMPRAS_AL_CONTADO_SIN_RECEPCION, AutorizacionRolList) Then
                    Dim cierreSA As New CierreContableSA
                    Dim cierre As New cierrecontable
                    cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

                    If Not IsNothing(cierre) Then
                        'Select Case cierre.estado
                        '    Case "C"
                        '        lblEstado.Text = "No puede realizar está operación, el periodo está cerrado!"
                        '        PanelError.Visible = True
                        '        Timer1.Enabled = True
                        '        TiempoEjecutar(10)
                        '    Case "A"

                        '        If IsNothing(GFichaUsuarios) Then
                        '            PanelError.Visible = True
                        '            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        '            Timer1.Enabled = True
                        '            TiempoEjecutar(5)
                        '        Else
                        '            If GFichaUsuarios.SaldoMN <= 0 Then
                        '                lblEstado.Text = "No puede realizar la compra, monto en caja insuficiente!"
                        '                PanelError.Visible = True
                        '                Timer1.Enabled = True
                        '                TiempoEjecutar(10)
                        '            Else
                        '                With frmCompraPagadaSinRecepcion
                        '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '                    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        '                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        '                    .lblPerido.Text = lblPeriodo.Text
                        '                    .StartPosition = FormStartPosition.CenterParent
                        '                    '  .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
                        '                    .WindowState = FormWindowState.Maximized
                        '                    .ShowDialog()
                        '                    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                        '                End With
                        '            End If

                        '        End If

                        'End Select
                    Else

                        If IsNothing(GFichaUsuarios) Then
                            PanelError.Visible = True
                            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            Timer1.Enabled = True
                            TiempoEjecutar(5)
                        Else
                            If GFichaUsuarios.SaldoMN <= 0 Then
                                lblEstado.Text = "No puede realizar la compra, monto en caja insuficiente!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                            Else
                                With frmCompraPagadaSinRecepcion
                                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                                    .lblPerido.Text = lblPeriodo.Text

                                    .StartPosition = FormStartPosition.CenterParent
                                    '  .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
                                    .WindowState = FormWindowState.Maximized
                                    .ShowDialog()
                                    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                                End With
                            End If

                        End If


                    End If
                    'Else
                    'MessageBoxAdv.Show("Usuario no autorizado")
                    'End If


                Case "Nuevo proveedor"
                    '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.PROVEEDORES, AutorizacionRolList) Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Nuevo proveedor"
                    f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    'Else
                    'MessageBoxAdv.Show("Usuario no autorizado")
                    'End If
            End Select
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.btOperacion.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If ListBox1.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Compras del período"
                Me.dgvCompras.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvCompras.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvCompras.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvCompras.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvCompras.OptimizeFilterPerformance = True
                Me.dgvCompras.ShowNavigationBar = True

                filter.WireGrid(dgvCompras)
                'Me.dgvVentasTicket.TopLevelGroupOptions.ShowFilterBar = False
            Case "Proveedores"


                Me.dgvProveedor.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvProveedor.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvProveedor.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvProveedor.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvProveedor.OptimizeFilterPerformance = True
                Me.dgvProveedor.ShowNavigationBar = True

                filter.WireGrid(dgvProveedor)
                'Me.dgvVentasTicket.TopLevelGroupOptions.ShowFilterBar = False
        End Select
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click


        Select Case treeViewAdv2.SelectedNode.Text
            Case "Compras del período"
                dgvCompras.TableDescriptor.GroupedColumns.Clear()
                If dgvCompras.ShowGroupDropArea = True Then
                    dgvCompras.ShowGroupDropArea = False
                Else
                    dgvCompras.ShowGroupDropArea = True
                End If
            Case "Proveedores"
                dgvProveedor.TableDescriptor.GroupedColumns.Clear()
                If dgvProveedor.ShowGroupDropArea = True Then
                    dgvProveedor.ShowGroupDropArea = False
                Else
                    dgvProveedor.ShowGroupDropArea = True
                End If
        End Select
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click

        Select Case treeViewAdv2.SelectedNode.Text
            Case "Compras del período"
                filter.ClearFilters(Me.dgvCompras)
                Me.dgvCompras.TopLevelGroupOptions.ShowFilterBar = False
            Case "Proveedores"
                filter.ClearFilters(Me.dgvProveedor)
                Me.dgvProveedor.TopLevelGroupOptions.ShowFilterBar = False
        End Select


    End Sub
    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()

    Private Sub dgvCompras_CategorizedRecords(sender As Object, e As TableEventArgs) Handles dgvCompras.CategorizedRecords
        LoadingAnimator.UnWire(Me.dgvCompras.TableControl)
    End Sub
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

            Me.dgvCompras.TableControl.Selections.Clear()
        End If
        If Not IsNothing(e.TableCellIdentity.Column) Then
            If e.TableCellIdentity.Column.Name = "Aprobado" Then
                If e.Style.CellValue.Equals("Aprobado") Then
                    'e.Style.BackColor = Color.White
                    'e.Style.TextColor = Color.YellowGreen
                Else
                    e.Style.BackColor = Color.FromArgb(255, 192, 192)
                End If
            End If
        End If
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
    Private Sub dgvCompras_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCompras.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCompras)
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        'Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Dashboard"
                'TabDashboard.Parent = TabControlAdv1
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabDetracción.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabOrdenServicio.Parent = Nothing
                'feedback = New FeedbackForm
                'feedback.Show()
                'bgWorker.RunWorkerAsync()

                'InitializeChart()
                'ChartAppearance.ApplyChartStyles(Me.chartControl1)
                'Me.chartControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

                'InitializeChartData()
                'ApplyChartStylesDefault(Me.ChartControl2)

            Case "Compras del período"
                GridCFG(dgvCompras)
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabDashboard.Parent = Nothing
                'btSelectAll.Visible = True
                TabDetracción.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabOrdenServicio.Parent = Nothing
                TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text

            Case "Proveedores"
                GridCFG(dgvProveedor)
                'btSelectAll.Visible = False
                TabPageAdv1.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabDetracción.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabOrdenServicio.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1

            Case "Todas las Compras"
                GridCFG(dgvCompras)
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabDetracción.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabOrdenServicio.Parent = Nothing
                TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text

            Case "Detracciones pend."
                GridCFG_Detracccion(dgvDetracciones)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabOrdenServicio.Parent = Nothing
                TabDetracción.Parent = TabControlAdv1

                Meses()
        End Select
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click


    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        'Me.Cursor = Cursors.WaitCursor
        LoadingAnimator.Wire(Me.dgvCompras.TableControl)
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Compras del período"
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabOrdenServicio.Parent = Nothing
                'btSelectAll.Visible = True
                'If rbPeriodo.Checked = True Then

                '    getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, PeriodoGeneral)

                '    'ListBox1.Items.Clear()
                '    'ListBox1.Items.Add("Compra al contado c/recep. exist.")
                '    'ListBox1.Items.Add("Compra al contado c/exist. transit.")
                '    ' Tag = False

                'ElseIf rbDia.Checked = True Then

                '    getTableComprasPorDiaContado(GEstableciento.IdEstablecimiento)
                '    'ListBox1.Items.Clear()
                '    'ListBox1.Items.Add("Compra al contado c/recep. exist.")
                '    'ListBox1.Items.Add("Compra al contado c/exist. transit.")
                '    'Tag = False


                'End If
                'TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text

                'Case "Compras al contado"
                '    If AutorizacionRolSA.TienePermiso(ModuloAsegurable.REGISTRO_DE_COMPRAS, AutorizacionRolList) Then
                '        TabPageAdv1.Parent = TabControlAdv1
                '        TabPageAdv2.Parent = Nothing
                '        If rbPeriodo.Checked = True Then

                '            getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
                '            ListBox1.Items.Clear()
                '            ListBox1.Items.Add("Compra al contado c/recep. exist.")
                '            ListBox1.Items.Add("Compra al contado c/exist. transit.")
                '            ' Tag = False

                '        ElseIf rbDia.Checked = True Then

                '            getTableComprasPorDiaContado(GEstableciento.IdEstablecimiento)
                '            ListBox1.Items.Clear()
                '            ListBox1.Items.Add("Compra al contado c/recep. exist.")
                '            ListBox1.Items.Add("Compra al contado c/exist. transit.")
                '            'Tag = False


                '        End If
                '        TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text
                '    Else
                '        MessageBox.Show("Usuario no autorizado")
                '    End If



                'Case "Compras al crédito"
                '    If AutorizacionRolSA.TienePermiso(ModuloAsegurable.REGISTRO_DE_COMPRAS, AutorizacionRolList) Then
                '        TabPageAdv1.Parent = TabControlAdv1
                '        TabPageAdv2.Parent = Nothing
                '        If rbPeriodo.Checked = True Then
                '            getTableComprasPorPeriodoCredito(GEstableciento.IdEstablecimiento, PeriodoGeneral)
                '            ListBox1.Items.Clear()
                '            ListBox1.Items.Add("Compra al credito c/recep. exist.")
                '            ListBox1.Items.Add("Compra al credito c/exist. transit.")
                '            'Tag = False

                '        ElseIf rbDia.Checked = True Then
                '            getTableComprasPorDiaCredito(GEstableciento.IdEstablecimiento)
                '            ListBox1.Items.Clear()
                '            ListBox1.Items.Add("Compra al credito c/recep. exist.")
                '            ListBox1.Items.Add("Compra al credito c/exist. transit.")
                '            'Tag = False
                '        End If
                '        TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text
                '    Else
                '        MessageBoxAdv.Show("Usuario no autorizado")
                '    End If

            Case "Proveedores"
                'btSelectAll.Visible = False
                '    If AutorizacionRolSA.TienePermiso(ModuloAsegurable.PROVEEDORES, AutorizacionRolList) Then
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabOrdenCompra.Parent = Nothing
                TabOrdenServicio.Parent = Nothing
                ListaProveedores()
                ListBox1.Items.Clear()
                'Else
                'MessageBoxAdv.Show("Usuario no autorizado")
                'End If

                'Tag = True

            Case "Todas las Compras"
                '   btSelectAll.Visible = True
                '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.REGISTRO_DE_COMPRAS, AutorizacionRolList) Then
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabOrdenCompra.Parent = Nothing
                TabOrdenServicio.Parent = Nothing

                If rbPeriodo.Checked = True Then
                    'getListarTodasLasCompras(GEstableciento.IdEstablecimiento, PeriodoGeneral)
                    ListBox1.Items.Clear()
                    'ListBox1.Items.Add("Compra al credito c/recep. exist.")
                    'ListBox1.Items.Add("Compra al credito c/exist. transit.")
                    'ListBox1.Items.Add("Compra al contado c/recep. exist.")
                    'ListBox1.Items.Add("Compra al contado c/exist. transit.")
                    ListBox1.Items.Add("Nuevo proveedor")
                    ' Tag = False

                ElseIf rbDia.Checked = True Then
                    getListarTodasLasComprasxDia(GEstableciento.IdEstablecimiento)
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add("Compra al credito c/recep. exist.")
                    ListBox1.Items.Add("Compra al credito c/exist. transit.")
                    ListBox1.Items.Add("Compra al contado c/recep. exist.")
                    ListBox1.Items.Add("Compra al contado c/exist. transit.")
                    ListBox1.Items.Add("Nuevo proveedor")
                    ' Tag = False

                End If
                TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text
                'Else
                'MessageBoxAdv.Show("Usuario no autorizado")
                'End If

            Case "Ordenes pendientes"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabOrdenCompra.Parent = TabControlAdv1
                TabOrdenServicio.Parent = Nothing
                getTableOrdenDeComprasPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_COMPRA.ORDEN_COMPRA)
                ToolStripButton7.Visible = True
                ToolStripButton17.Visible = False
                txtCliente.Clear()
                txtRuc.Clear()
            Case "Ordenes aprobados"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabOrdenCompra.Parent = TabControlAdv1
                TabOrdenServicio.Parent = Nothing
                'getTableOrdenDeServiciosPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
                getTableOrdenDeComprasPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_COMPRA.ORDEN_APROBADO)
                ToolStripButton7.Visible = False
                ToolStripButton17.Visible = True
                txtCliente.Clear()
                txtRuc.Clear()
        End Select
        '   Me.Cursor = Cursors.Arrow
        LoadingAnimator.UnWire(Me.dgvCompras.TableControl)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Sub LoadNodes()
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        GConfiguracion = New GConfiguracionModulo

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If dgvCompras.Table.Records.Count > 0 Then
                If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
                    Select Case Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra")
                        Case TIPO_COMPRA.COMPRA
                            Dim f As New frmEditcompra(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                            f.WindowState = FormWindowState.Normal
                            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                        Case TIPO_COMPRA.NOTA_DEBITO
                            Dim f As New frmViewNotaDebito(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()

                        Case TIPO_COMPRA.NOTA_CREDITO
                            Dim f As New frmViewNota(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                        Case TIPO_COMPRA.BONIFICACIONES_RECIBIDAS
                            Dim f As New frmNotaCreditoBonificaciones(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                            f.WindowState = FormWindowState.Maximized
                            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            f.ShowDialog()
                        Case TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                            Dim f As New frmReciboHonorarios(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                            f.WindowState = FormWindowState.Normal
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            f.ShowDialog()
                        Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO
                            Dim f As New frmServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                            f.WindowState = FormWindowState.Normal
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            f.ShowDialog()

                        Case TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO 'FALTA METODO ELIMINAR
                            Dim f As New frmCompraAnticipada(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                            f.WindowState = FormWindowState.Normal
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            f.ShowDialog()

                        Case TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA  'FALTA METODO ELIMINAR
                            Dim f As New frmCompraAnticipada(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                            f.WindowState = FormWindowState.Normal
                            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            f.ShowDialog()

                    End Select
                Else
                    MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            

        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv2 Then
            If dgvProveedor.Table.Records.Count > 0 Then
                If Not IsNothing(Me.dgvProveedor.Table.CurrentRecord) Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Editar proveedor"
                    f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.intIdEntidad = Me.dgvProveedor.Table.CurrentRecord.GetValue("idEntidad")
                    f.UbicarEntidad(Me.dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Else
                    MessageBox.Show("Debe seleccionar un proveedor!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
           
        End If
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        LoadingAnimator.Wire(Me.dgvCompras.TableControl)
        LoadNodes()
        LoadingAnimator.UnWire(Me.dgvCompras.TableControl)
    End Sub

    Sub ElimnarDocRadial()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        '  GFichaUsuarios = New GFichaUsuario
        If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
            If Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA Then

                Dim f As New frmModalCompraEliminacion(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                f.CaptionLabels(0).Text = "Eliminar Compra Nro. " & Me.dgvCompras.Table.CurrentRecord.GetValue("serie") & "-" & Me.dgvCompras.Table.CurrentRecord.GetValue("numeroDoc")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If f.Tag = "Eliminado" Then
                    Me.dgvCompras.Table.CurrentRecord.Delete()
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    lblEstado.Text = "Compra eliminada!"
                End If

                'EliminarCompraGeneral(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                'Me.dgvCompras.Table.CurrentRecord.Delete()
                'PanelError.Visible = True
                'Timer1.Enabled = True
                'TiempoEjecutar(10)
                'lblEstado.Text = "Compra eliminada!"

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS Then
                EliminarReciboHonorario(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO Then
                EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO Then
                EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA Then
                EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.NOTA_CREDITO Then
                EliminarNota(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.NOTA_DEBITO Then
                EliminarDebito(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.BONIFICACIONES_RECIBIDAS Then
                EliminarNotaCreditoBonificacion(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
            End If

            'If Not IsNothing(GFichaUsuarios) Then
            '    UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
            '    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
            'End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        '   If AutorizacionRolSA.TienePermiso(ModuloAsegurable.REGISTRO_DE_COMPRAS, AutorizacionRolList) Then
        'If MessageBox.Show("Desea eliminar el item seleccionado!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        Select Case treeViewAdv2.SelectedNode.Text
            Case "Compras del período"
                If dgvCompras.Table.Records.Count > 0 Then

                    If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                        If MessageBox.Show("Desea eliminar la compra seleccionada!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            ElimnarDocRadial()
                        End If
                    End If

                End If


            Case "Compras al contado"
                If dgvCompras.Table.Records.Count > 0 Then

                    If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                        If MessageBox.Show("Desea eliminar la compra seleccionada!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            ElimnarDocRadial()
                        End If
                    End If
                End If

            Case "Proveedores"
                'Dim documentoCompraSA As New DocumentoCompraSA
                'Dim documentoVentasSA As New documentoVentaAbarrotesSA
                'Dim SumComprasProveedor As Integer = 0

                If dgvProveedor.Table.Records.Count > 0 Then
                    If Not IsNothing(dgvProveedor.Table.CurrentRecord) Then
                        If MessageBox.Show("Cambiar a inactivo al proveedor seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            CambiarStatusEntidad(dgvProveedor.Table.CurrentRecord)
                        End If

                    End If

                End If


                'SumComprasProveedor = documentoCompraSA.UbicarCompraPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Me.dgvProveedor.Table.CurrentRecord.GetValue("nroDoc"), PeriodoGeneral).Count

                'If Not IsNothing(dgvProveedor.Table.CurrentRecord) Then

                'If (SumComprasProveedor = 0) Then
                'ElimnarProveedor()
                'Else
                'PanelError.Visible = True
                'Timer1.Enabled = True
                'TiempoEjecutar(10)
                'lblEstado.Text = "El proveedor tiene movimientos, error al eliminar!"
                'End If

                'End If
            Case "Todas las Compras"
                If dgvCompras.Table.Records.Count > 0 Then

                    If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                        If MessageBox.Show("Desea eliminar la compra seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            ElimnarDocRadial()
                        End If
                    End If

                End If


            Case TIPO_COMPRA.NOTA_CREDITO
                If dgvCompras.Table.Records.Count > 0 Then

                    If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                        If MessageBox.Show("Desea eliminar la nota de crédito seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            ElimnarDocRadial()
                        End If
                    End If

                End If


            Case TIPO_COMPRA.NOTA_DEBITO
                If dgvCompras.Table.Records.Count > 0 Then

                    If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                        If MessageBox.Show("Desea eliminar la nota de débito seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            ElimnarDocRadial()
                        End If
                    End If

                End If


            Case TIPO_COMPRA.BONIFICACIONES_RECIBIDAS
                If dgvCompras.Table.Records.Count > 0 Then

                    If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                        If MessageBox.Show("Desea eliminar la bonificacion?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            ElimnarDocRadial()
                        End If
                    End If

                End If


        End Select
        'End If
        'Else
        'MessageBoxAdv.Show("Usuario no autorizado")
        'End If


    End Sub

    Private Sub dgvProveedor_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvProveedor.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvProveedor.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvProveedor_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvProveedor.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvProveedor)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Dim documentoCompraSA As New DocumentoCompraDetalleSA


        If Not IsNothing(GFichaUsuarios) Then
            'Dim f As New frmCreditoCompra
            'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            'f.txtFecha.CustomFormat = "dd/MM/yyyy"
            'f.ShowDialog()
        Else
            lblEstado.Text = "Debe inciar una caja, para realizar està tarea!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
        'End If


        'With frmCreditoCompra  ' frmCredito
        '    '.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .StartPosition = FormStartPosition.CenterParent
        '    '    .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
        '    '.IdUsuarioCaja = Me.dgvCompra.Table.CurrentRecord.GetValue("usuarioActualizacion")
        '    '.TipoCompra = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
        '    '.IdCompraOrigen = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
        '    '.Moneda = Me.dgvCompra.Table.CurrentRecord.GetValue("monedaDoc")
        '    '.UbicarDetalle(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
        '    '     .UbicarCabeceraCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
        '    '.WindowState = FormWindowState.Maximized
        '    .txtFecha.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '    .txtFecha.CustomFormat = "dd/MM/yyyy"
        '    '.WindowState = FormWindowState.Maximized
        '    .ShowDialog()
        'End With
        '    End If
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs) Handles PanelError.Paint

    End Sub

    Private Sub btSelectAll_Click(sender As Object, e As EventArgs)
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Registro de compras"
                Me.dgvCompras.Table.SelectedRecords.Clear()
                Me.dgvCompras.Table.Records.SelectAll()
            Case "Proveedores"

        End Select


    End Sub

    Private Sub btAprobar_Click(sender As Object, e As EventArgs) Handles btAprobar.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvCompras.Table.SelectedRecords.Count > 0 Then
            ActualizarEstadoCompras("S")
        Else
            lblEstado.Text = "Debe seleccionar filas para realizar esta tarea!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btDeleSel_Click(sender As Object, e As EventArgs) Handles btDeleSel.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvCompras.Table.SelectedRecords.Count > 0 Then
            ActualizarEstadoCompras("N")
        Else
            lblEstado.Text = "Debe seleccionar filas para realizar esta tarea!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CompraDeExistenciasServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            Try
                Dim f As New frmCompras
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Normal
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.ShowDialog()
                GetCountDetracciones()

            Catch ex As Exception
                lblEstado.Text = ex.Message
            End Try
        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        'Dim SaldoCaja As New UsuarioEstadoCaja
        'SaldoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
    End Sub

    Private Sub RegistroDeHonorariosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            Dim f As New frmReciboHonorarios
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
            f.WindowState = FormWindowState.Normal
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.StartPosition = FormStartPosition.CenterParent
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.ShowDialog()
            GetCountDetracciones()
        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            Dim f As New frmServicioPublico
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.WindowState = FormWindowState.Normal
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            GetCountDetracciones()
        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        'Dim SaldoCaja As New UsuarioEstadoCaja
        'SaldoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click

    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        'If Not IsNothing(GFichaUsuarios) Then
        'Dim f As New frmNotasDebito
        'f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
        'f.FormBorderStyle = FormBorderStyle.FixedSingle
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'Dim SaldoCaja As New UsuarioEstadoCaja
        'SaldoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
        'Else
        'lblEstado.Text = "Debe inciar una caja, para realizar està tarea!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub DevolucionDeExistenciasErrorEnCostoOtrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionDeExistenciasErrorEnCostoOtrosToolStripMenuItem.Click
        'If Not IsNothing(GFichaUsuarios) Then
        'Dim f As New frmCreditoCompra
        'f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'Dim SaldoCaja As New UsuarioEstadoCaja
        'SaldoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
        'Else
        'lblEstado.Text = "Debe inciar una caja, para realizar està tarea!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub BonificacionesRecibidasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonificacionesRecibidasToolStripMenuItem.Click
        '  If Not IsNothing(GFichaUsuarios) Then
        Dim f As New frmNotaCreditoBonificaciones
        f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        'Dim SaldoCaja As New UsuarioEstadoCaja
        'SaldoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
        'Else
        'lblEstado.Text = "Debe inciar una caja, para realizar està tarea!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        With frmCrearENtidades
            .CaptionLabels(0).Text = "Nuevo proveedor"
            .strTipo = TIPO_ENTIDAD.PROVEEDOR
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '.intIdEntidad = Me.dgvProveedor.Table.CurrentRecord.GetValue("idEntidad")
            '.UbicarEntidad(Me.dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub dgvCompras_SortedItemsInGroup(sender As Object, e As GroupEventArgs) Handles dgvCompras.SortedItemsInGroup
        LoadingAnimator.UnWire(Me.dgvCompras.TableControl)
    End Sub

    Private Sub dgvCompras_SortingItemsInGroup(sender As Object, e As GroupEventArgs) Handles dgvCompras.SortingItemsInGroup
        LoadingAnimator.Wire(Me.dgvCompras.TableControl)
    End Sub

    Private Sub dgvCompras_CategorizingRecords(sender As Object, e As TableEventArgs) Handles dgvCompras.CategorizingRecords
        LoadingAnimator.Wire(Me.dgvCompras.TableControl)
    End Sub

    Private Sub dgvCompras_TableControlCurrentCellInitializeControlText(sender As Object, e As GridTableControlCurrentCellInitializeControlTextEventArgs) Handles dgvCompras.TableControlCurrentCellInitializeControlText
        LoadingAnimator.UnWire(Me.dgvCompras.TableControl)
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs)
        Dim f As New frmTablero
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub chartControl1_ChartFormatAxisLabel(sender As Object, e As Chart.ChartFormatAxisLabelEventArgs) Handles chartControl1.ChartFormatAxisLabel
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

    Private Sub frmMasterComprasGenerales_Shown(sender As Object, e As EventArgs) Handles Me.Shown


    End Sub

    Private Sub treeViewAdv2_NodeBackgroundPaint(sender As Object, e As Tools.TreeNodeAdvPaintBackgroundEventArgs) Handles treeViewAdv2.NodeBackgroundPaint
        'If e.Node.Index = 1 Or e.Node.Index = 2 Or e.Node.Index = 3 Or e.Node.Index = 4 Then
        '    Dim br As Syncfusion.Drawing.BrushInfo = New Syncfusion.Drawing.BrushInfo(Color.DarkGray)

        '    e.BrushInfo = br
        'End If
    End Sub

    Private Sub CompraAnticipadaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            Dim f As New frmCompraAnticipada
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.WindowState = FormWindowState.Normal
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            GetCountDetracciones()
        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub
    Dim rectY As Rectangle
    Private Sub ChartControl3_ChartAreaPaint(sender As Object, e As PaintEventArgs)
        For Each series As ChartSeries In Me.chartControl1.Series
            Dim rectX As RectangleF = Me.chartControl1.ChartArea.GetSeriesBounds(series)
            rectY = New Rectangle(Convert.ToInt16(rectX.X), Convert.ToInt16(rectX.Y), Convert.ToInt16(rectX.Width), Convert.ToInt16(rectX.Height))

            e.Graphics.DrawRectangle(New Pen(Color.DimGray, 1), rectY)
        Next
    End Sub

    Private Sub cboMes_Click(sender As Object, e As EventArgs) Handles cboMes.Click

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        getDetracciones(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                   .fechaContable = String.Concat(cboMes.SelectedValue, "/", txtAnio.Text), .tieneDetraccion = "S"})
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvDetracciones_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvDetracciones.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue
            Select Case valCheck
                Case "False" 'TRUE

                    Dim nroconst = Me.dgvDetracciones.TableModel(RowIndex, 11).CellValue ' dgvDetracciones.Table.CurrentRecord.GetValue("nroConstancia")
                    Dim periodotri = Me.dgvDetracciones.TableModel(RowIndex, 9).CellValue ' dgvDetracciones.Table.CurrentRecord.GetValue("periodoTributo")
                    Dim fechacons = Me.dgvDetracciones.TableModel(RowIndex, 10).CellValue ' dgvDetracciones.Table.CurrentRecord.GetValue("fechaConstancia")

                    obj.idDocumento = Me.dgvDetracciones.TableModel(RowIndex, 1).CellValue ' Val(dgvDetracciones.Table.CurrentRecord.GetValue("idDocumento"))

                    If IsDate(fechacons) Then
                        obj.fechaConstancia = CType(fechacons, DateTime)
                    Else
                        MessageBox.Show("Indicar la fecha de constancia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue = True
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If nroconst.ToString.Trim.Length > 0 Then
                        obj.nroConstancia = nroconst
                    Else
                        MessageBox.Show("Indicar el nro de constancia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue = True
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If periodotri.ToString.Trim.Length > 0 Then
                        obj.periodoTributo = periodotri
                    Else
                        MessageBox.Show("Indicar el periodo de detracción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue = True
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    UpdateDataDetraccion(obj)
                    'MessageBox.Show(True)
                Case Else ' FALSE
                    obj.idDocumento = Val(Me.dgvDetracciones.TableModel(RowIndex, 1).CellValue)
                    obj.fechaConstancia = Nothing
                    obj.nroConstancia = Nothing
                    obj.periodoTributo = Nothing
                    UpdateDataDetraccion(obj)

                    Me.dgvDetracciones.TableModel(RowIndex, 9).CellValue = Nothing
                    Me.dgvDetracciones.TableModel(RowIndex, 10).CellValue = Nothing
                    Me.dgvDetracciones.TableModel(RowIndex, 11).CellValue = Nothing
                    Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue = True
                    'MessageBox.Show(False)
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellAcceptedChanges(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvDetracciones.TableControlCurrentCellAcceptedChanges

    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellActivated(sender As Object, e As GridTableControlEventArgs) Handles dgvDetracciones.TableControlCurrentCellActivated

    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvDetracciones.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = e.TableControl.CurrentCell

        If cc.Renderer.StyleInfo.CellType = "CheckBox" Then
            Console.WriteLine(e.TableControl.Table.CurrentRecord.Info)
            Dim dr As DataRowView = e.TableControl.Table.CurrentRecord.GetData()
        End If

    End Sub

    Private Sub dgvCompras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCellClick

    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvDetracciones.TableControlCurrentCellChanging

    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellControlGotFocus(sender As Object, e As GridTableControlControlEventArgs) Handles dgvDetracciones.TableControlCurrentCellControlGotFocus

    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellControlKeyMessage(sender As Object, e As GridTableControlCurrentCellControlKeyMessageEventArgs) Handles dgvDetracciones.TableControlCurrentCellControlKeyMessage

    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellControlLostFocus(sender As Object, e As GridTableControlControlEventArgs) Handles dgvDetracciones.TableControlCurrentCellControlLostFocus

    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellInitializeControlText(sender As Object, e As GridTableControlCurrentCellInitializeControlTextEventArgs) Handles dgvDetracciones.TableControlCurrentCellInitializeControlText

    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvDetracciones.TableControlCurrentCellKeyDown

    End Sub

    Private Sub dgvDetracciones_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvDetracciones.TableControlCellClick

    End Sub

    Private Sub ToolStripButton4_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton4.Click


        If TabControlAdv1.SelectedTab Is TabOrdenCompra Then
            If Not IsNothing(Me.dgvOrdenCompra.Table.CurrentRecord) Then
                Select Case Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_COMPRA.ORDEN_APROBADO
                        'Dim f As New frmCompras(Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"), TIPO_COMPRA.ORDEN_APROBADO, Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("numeroDoc"))
                        'f.WindowState = FormWindowState.Normal
                        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        'f.ShowDialog()
                        'Case TIPO_COMPRA.ORDEN_SERVICIO
                        '    Dim f As New frmEditcompra(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        '    f.WindowState = FormWindowState.Normal
                        '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        '    f.ShowDialog()
                End Select
            Else
                MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf TabControlAdv1.SelectedTab Is TabOrdenServicio Then
            Dim Tipo As String
            If Not IsNothing(Me.dgvOrdenServicio.Table.CurrentRecord) Then
                Select Case Me.dgvOrdenServicio.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_COMPRA.ORDEN_SERVICIO_APROBADO
                        Tipo = Me.dgvOrdenServicio.Table.CurrentRecord.GetValue("tipoServicio")
                        Select Case Tipo
                            Case "SERVICIOS DIVERSOS"
                                'Dim f As New frmCompras(Me.dgvOrdenServicio.Table.CurrentRecord.GetValue("idDocumento"), TIPO_COMPRA.ORDEN_SERVICIO_APROBADO, Me.dgvOrdenServicio.Table.CurrentRecord.GetValue("numeroDoc"))
                                'f.WindowState = FormWindowState.Normal
                                'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                'f.ShowDialog()

                            Case "HONORARIOS"
                                Dim f As New frmReciboHonorarios(Me.dgvOrdenServicio.Table.CurrentRecord.GetValue("idDocumento"), TIPO_COMPRA.ORDEN_SERVICIO_APROBADO)
                                f.WindowState = FormWindowState.Normal
                                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                f.ShowDialog()

                            Case "SERVICIOS PUBLICOS"

                                Dim f As New frmServicioPublico(Me.dgvOrdenServicio.Table.CurrentRecord.GetValue("idDocumento"), TIPO_COMPRA.ORDEN_SERVICIO_APROBADO)
                                f.WindowState = FormWindowState.Normal
                                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                f.ShowDialog()

                        End Select



                End Select
            Else
                MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        End If
    End Sub

    Private Sub bgWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker.DoWork
        InitializeChart()
        ChartAppearance.ApplyChartStyles(Me.chartControl1)
        Me.chartControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        InitializeChartData()
        ApplyChartStylesDefault(Me.ChartControl2)
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        feedback.close()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim f As New frmOrdenCompras("ORDEN")
        f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
        f.strTipo = "ORDEN"
        f.WindowState = FormWindowState.Normal
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.ShowDialog()
        'ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtCliente
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipoProveedor(txtCliente.Text.Trim)
        End If
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then

                If TabOrdenCompra Is TabControlAdv1.SelectedTab Then
                    Me.txtCliente.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    txtCliente.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                End If


                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then

            If TabOrdenCompra Is TabControlAdv1.SelectedTab Then
                Me.lsvProveedor.Focus()
                'ElseIf TabPageDevolucion Is TabCuentasPagar.SelectedTab Then
                '    Me.txtBuscarProveedorPago.Focus()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Ordenes pendientes"
                getTableOrdenDeComprasPorFiltro(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_COMPRA.ORDEN_COMPRA)
            Case "Ordenes aprobados"
                getTableOrdenDeComprasPorFiltro(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_COMPRA.ORDEN_APROBADO)
        End Select
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(Me.dgvOrdenCompra.Table.CurrentRecord) Then
            If MessageBox.Show("Desea aprobar la orden seleccionada?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                UpdateDoc(Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                dgvOrdenCompra.Table.CurrentRecord.Delete()
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Sub UpdateDoc(intIdDocumento As Integer)
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        nRecurso = New documentocompra With {
        .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
        .idDocumento = intIdDocumento,
        .tipoCompra = TIPO_COMPRA.ORDEN_APROBADO}
        If (nRecursoSA.EstadoSoli(nRecurso)) Then
            'lblEstado.Text = " editado!"
            'lblEstado.Image = My.Resources.ok4
        Else
            'lblEstado.Text = "Error al grabar Cadena!"
            'lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        If TabControlAdv1.SelectedTab Is TabOrdenCompra Then
            If Not IsNothing(Me.dgvOrdenCompra.Table.CurrentRecord) Then
                Select Case Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_COMPRA.ORDEN_APROBADO
                        'Dim f As New frmCompras(Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"), TIPO_COMPRA.ORDEN_APROBADO, Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("numeroDoc"))
                        'f.WindowState = FormWindowState.Normal
                        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        'f.ShowDialog()
                End Select
            Else
                MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub

    Private Sub NotaDeCréditoEspecialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeCréditoEspecialToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmNotaCreditoEspecial
        f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
        f.Size = New Size(1100, 678)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NotaDeDébitoEspecialNuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeDébitoEspecialNuevoToolStripMenuItem.Click
        'Me.Cursor = Cursors.WaitCursor
        'Dim f As New frmNotaDebitoEspecial
        'f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Me.Cursor = Cursors.WaitCursor
        Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
        periodo = periodo & "/" & AnioGeneral
        getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, periodo)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AnulaciònDeGastoFinancierosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnulaciònDeGastoFinancierosToolStripMenuItem.Click
        'Dim f As New frmDevolucionDebito
        'f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmCambiarPeriodo2(New documentocompra With {.idDocumento = Val(r.GetValue("idDocumento"))})
            f.operacion = StatusTipoOperacion.COMPRA
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub ImportacionesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CompraDeExistenciasServiciosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CompraDeExistenciasServiciosToolStripMenuItem1.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            Try
                Dim f As New frmCompras
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Normal
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.ShowDialog()
                GetCountDetracciones()

            Catch ex As Exception
                lblEstado.Text = ex.Message
            End Try
        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CompraDeServiciosPúblicosToolStripMenuItem1.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            Dim f As New frmServicioPublico
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.WindowState = FormWindowState.Normal
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            GetCountDetracciones()
        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub RegistroDeHonorariosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegistroDeHonorariosToolStripMenuItem1.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            Dim f As New frmReciboHonorarios
            f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
            f.WindowState = FormWindowState.Normal
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.StartPosition = FormStartPosition.CenterParent
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.ShowDialog()
            GetCountDetracciones()
        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub CompraDeExistenciasServiciosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CompraDeExistenciasServiciosToolStripMenuItem2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then

                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmComprasContado
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Normal
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                        GetCountDetracciones()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CompraDeServiciosPúblicosToolStripMenuItem2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then

                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmServicioPublicoContado
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        .WindowState = FormWindowState.Normal
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        GetCountDetracciones()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RegistroDeHonorariosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RegistroDeHonorariosToolStripMenuItem2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            If cboMesCompra.Text.Trim.Length > 0 Then

                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmReciboHonorariosContado
                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        .WindowState = FormWindowState.Normal
                        .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        .StartPosition = FormStartPosition.CenterParent
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .ShowDialog()
                        GetCountDetracciones()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CompraAnticipadaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CompraAnticipadaToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    With frmCompraAnticipada

                        .lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                        .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        .WindowState = FormWindowState.Normal
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        GetCountDetracciones()
                    End With
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click

    End Sub
End Class