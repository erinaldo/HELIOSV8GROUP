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

Public Class frmDashBoard
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
        SumaTotales()
    End Sub

    Sub SumaTotales() 'GetSumaCuentasXpagar GetSumaCuentasXCobrar
        Dim docCajaSA As New DocumentoCajaSA
        Dim docCaja As New documentoCaja

        Dim CompraSA As New DocumentoCompraSA
        Dim Compra As New documentocompra

        Dim VeNtaSA As New documentoVentaAbarrotesSA
        Dim VeNta As New documentoventaAbarrotes

        docCaja = docCajaSA.SumaxTipoEF("EF", TIPO_VENTA.PAGO.COBRADO)

        lblEfectivo.Text = "Cuentas en Efectivo" & vbCrLf & docCaja.montoSoles

        docCaja = docCajaSA.SumaxTipoEF("BC", TIPO_VENTA.PAGO.COBRADO)
        lblTarjeta.Text = "Cuentas en Banco" & vbCrLf & docCaja.montoSoles

        Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "30")

        Label26.Text = FormatNumber(Compra.Monto30mn, 2)

        ' Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "60")

        Label24.Text = FormatNumber(Compra.Monto60mn, 2)

        '  Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "90")

        Label22.Text = FormatNumber(Compra.Monto90mn, 2)

        '   Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "90+")

        Label12.Text = FormatNumber(Compra.Monto90Masmn, 2)

        Label11.Text = "S/." & FormatNumber(CDec(Label26.Text) + CDec(Label24.Text) + CDec(Label22.Text) + CDec(Label12.Text), 2)

        '--------------------------------------------------------------------------------
        VeNta = VeNtaSA.GetSumaCuentasXCobrar(GEstableciento.IdEstablecimiento, 30)

        Label17.Text = FormatNumber(VeNta.Monto30mn, 2)

        ' Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "60")

        Label18.Text = FormatNumber(VeNta.Monto60mn, 2)

        '  Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "90")

        Label19.Text = FormatNumber(VeNta.Monto90mn, 2)

        '   Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "90+")

        '  Label4.Text = FormatNumber(Compra.Monto90Masmn, 2)


     
    End Sub

    Private Sub PieFlujoEfectivo()
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCaja As New List(Of documentoCaja)
        Dim coNteo As Byte = 0
        documentoCaja = documentoCajaSA.SumaxINgresosEgresos(" ")

        Dim series1 As New ChartSeries("Market")

        For Each i In documentoCaja

            Select Case i.tipoMovimiento

                Case "DC"

                 '   series1.Points.Add(CDate(coNteo), i.montoSoles)

                Case "PG"
                    '     series1.Points.Add(coNteo, i.montoSoles)

            End Select


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

        If documentoCaja.Count > 0 Then

            Dim importeNac As Decimal = series1.Points(0).YValues(0)
            Dim importeEx As Decimal = series1.Points(1).YValues(0)
            series1.Styles(0).Text = String.Format("Ingresos {0}", FormatCurrency(importeNac, 2))

            series1.Styles(1).Text = String.Format("Egresos {0}", FormatCurrency(importeEx, 2))
            'series1.Styles(2).Text = String.Format("Facilities {0}%", series1.Points(2).YValues(0))
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
            ChartControl3.Series(0).ConfigItems.PieItem.DoughnutCoeficient = 0.6

            ChartControl3.Model.ColorModel.CustomColors = New Color() {Color.FromArgb(46, 198, 217),
                                                 Color.FromArgb(218, 106, 139),
                                                 Color.FromArgb(126, 40, 126),
                                                 Color.FromArgb(56, 83, 164)}
            ChartControl3.Model.ColorModel.Palette = ChartColorPalette.Custom
            ChartControl3.ShowLegend = True
            ChartControl3.Series(0).OptimizePiePointPositions = True
        End If
    End Sub

    Public Class Points
        Public Property Product() As String
            Get
                Return m_Product
            End Get
            Set(value As String)
                m_Product = value
            End Set
        End Property
        Private m_Product As String
        Public Property Quantity() As Double
            Get
                Return m_Quantity
            End Get
            Set(value As Double)
                m_Quantity = value
            End Set
        End Property
        Private m_Quantity As Double

        Public Sub New(x As String, y As Double)
            Me.Product = x
            Me.Quantity = y
        End Sub
    End Class

    Private Sub InitializeChart2()

        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)

        documentoVenta = documentoVentaSA.GetListarVentasPorCategoria(GEstableciento.IdEstablecimiento, PeriodoGeneral)


        '  Dim labels As String() = {"Tablet", "Desktop", "Hybrid", "Laptop", "Smartphone"}
        Dim colors As Color() = New Color() {Color.FromArgb(12, 128, 64),
                                             Color.FromArgb(237, 31, 36),
                                             Color.FromArgb(243, 236, 25),
                                             Color.FromArgb(126, 40, 126),
                                             Color.FromArgb(56, 83, 164)}
        Dim data As New List(Of Points)()
        '  Dim r As New Random()
        'For i As Integer = 0 To labels.Length - 1
        '    data.Add(New Points(labels(i), r.[Next](1000, 10000)))
        'Next
        For Each i In documentoVenta
            data.Add(New Points(i.nombrePedido, i.Quantity))
        Next

        Me.ChartControl2.Series.Clear()
        Dim series As New ChartSeries("Series", ChartSeriesType.Column)

        Dim model As New ChartDataBindModel(data)
        model.YNames = New String() {"Quantity"}
        series.SeriesModel = model
        Me.ChartControl2.Series.Add(series)

        For i As Integer = 0 To colors.Length - 1
            series.Styles(i).Interior = New BrushInfo(colors(i))

        Next

        Me.ChartControl2.PrimaryXAxis.ForeColor = Color.Black
        Me.ChartControl2.PrimaryYAxis.ForeColor = Color.Black
        Me.ChartControl2.PrimaryXAxis.TickLabelsDrawingMode = ChartAxisTickLabelDrawingMode.UserMode
        Dim labelModel As New ChartDataBindAxisLabelModel(data)
        labelModel.LabelName = "Product"
        Me.ChartControl2.PrimaryXAxis.LabelsImpl = labelModel
        series.PointsToolTipFormat = "Quantity:{4}"
        series.FancyToolTip.Visible = False
        series.FancyToolTip.BackColor = System.Drawing.Color.DeepSkyBlue

        series.Style.Border.Color = Color.White
        series.Style.Border.DashStyle = DashStyle.Solid
        '   series.Style.Border.Width = 3

        Me.ChartControl2.PrimaryXAxis.LabelRotate = False
        Me.ChartControl2.PrimaryXAxis.LabelRotateAngle = 45
        Me.ChartControl2.ChartInterior = New BrushInfo(Color.White) 'New BrushInfo(Color.FromArgb(15, 15, 16))
        Me.ChartControl2.ShowLegend = False
        Me.ChartControl2.TextAlignment = StringAlignment.Near
        Me.ChartControl2.ForeColor = Color.Black
        Me.ChartControl2.ChartToolTip = "Quantity"

        ChartControl2.PrimaryXAxis.LabelRotate = True
        ChartControl2.PrimaryXAxis.LabelRotateAngle = 15
        ChartControl2.PrimaryXAxis.Font = New Font("Segoe UI", 7)


        For i As Integer = 0 To ChartControl2.Legend.Items.Length - 1
            Me.chartControl1.Series(i).ShowTicks = False
            Me.chartControl1.Series(i).Styles(0).Border.Color = Color.Transparent
        Next

        
        '  Me.chartControl1.Series(0).Styles(6).Border.Color = Color.Transparent
        'ChartControl2.PrimaryXAxis.Labels(1).Font = New Font("Segoe UI", 7)
        'ChartControl2.PrimaryXAxis.Labels(2).Font = New Font("Segoe UI", 7)
        'ChartControl2.PrimaryXAxis.Labels(3).Font = New Font("Segoe UI", 7)
        '    ChartControl2.Font = New Font("Segoe UI", 7)
    End Sub

    Dim sparkline As SparkLine(,) = New SparkLine(15, 1) {}

    Private Sub ListaVeNtasANio()

        gridControl1(0, 1).Text = "Tipo venta"
        gridControl1(0, 2).Text = "Ene"
        gridControl1(0, 3).Text = "Feb"
        gridControl1(0, 4).Text = "Mar"
        gridControl1(0, 5).Text = "Abr"
        gridControl1(0, 6).Text = "May"
        gridControl1(0, 7).Text = "Jun"
        gridControl1(0, 8).Text = "Jul"
        gridControl1(0, 9).Text = "Ago"
        gridControl1(0, 10).Text = "Set"
        gridControl1(0, 11).Text = "Oct"
        gridControl1(0, 12).Text = "Nov"
        gridControl1(0, 13).Text = "Dic"

        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)


        documentoVenta = documentoVentaSA.GetVentasAnuales(GEstableciento.IdEstablecimiento, PeriodoGeneral)

        For i As Integer = 0 To documentoVenta.Count - 1

            For j As Integer = 0 To 4
                Select Case documentoVenta(i).tipoVenta
                    Case TIPO_VENTA.VENTA_NORMAL_CREDITO
                        Me.gridControl1(i + 1, 1).CellValue = "Venta normal al credito"

                    Case TIPO_VENTA.VENTA_NORMAL_CONTADO
                        Me.gridControl1(i + 1, 1).CellValue = "Venta normal al contado"

                    Case TIPO_VENTA.VENTA_AL_TICKET
                        Me.gridControl1(i + 1, 1).CellValue = "Venta c/ticket al credito"

                    Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
                        Me.gridControl1(i + 1, 1).CellValue = "Venta c/ticket al contado"
                End Select
                ' Me.gridControl1(i + 2, 1).CellValue = documentoVenta(i).tipoVenta
                Select Case documentoVenta(i).fechaPeriodo
                    Case "01/" & AnioGeneral
                        Me.gridControl1(i + 1, 2).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)

                    Case "02/" & AnioGeneral
                        Me.gridControl1(i + 1, 3).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "03/" & AnioGeneral
                        Me.gridControl1(i + 1, 4).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "04/" & AnioGeneral
                        Me.gridControl1(i + 1, 5).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "05/" & AnioGeneral
                        Me.gridControl1(i + 1, 6).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "06/" & AnioGeneral
                        Me.gridControl1(i + 1, 7).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "07/" & AnioGeneral
                        Me.gridControl1(i + 1, 8).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "08/" & AnioGeneral
                        Me.gridControl1(i + 1, 9).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "09/" & AnioGeneral
                        Me.gridControl1(i + 1, 10).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "10/" & AnioGeneral
                        Me.gridControl1(i + 1, 11).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "11/" & AnioGeneral
                        Me.gridControl1(i + 1, 12).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                    Case "12/" & AnioGeneral
                        Me.gridControl1(i + 1, 13).CellValue = FormatNumber(documentoVenta(i).ImporteNacional, 2)
                End Select

            Next

            'For j As Integer = 0 To 9
            '    Me.gridControl1(i + 2, j + 1).CellValue = documentoVenta(i).ImporteNacional

            'Next
            'For ii As Integer = 0 To 4
            '    For j As Integer = 0 To 0
            '        sparkline(ii, j) = New SparkLine()
            '    Next
            'Next
        Next
        gridControl1.ReadOnly = True
    End Sub

    Public Sub InitializeChart()
        Dim series As New ChartSeries
        ' Initialize ChartSeries
        Dim colors As Color() = New Color() {Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen, Color.YellowGreen}

        series = New ChartSeries("Compras")

        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoVentaSA As New documentoVentaAbarrotesSA

        Dim lista As New List(Of documentocompra)
        Dim listaVenta As New List(Of documentoventaAbarrotes)

        lista = documentoCompraSA.GetListarComprasPorAnio(GEstableciento.IdEstablecimiento, AnioGeneral)

        For Each i In lista
            Dim s = CDate(1 & "/" & i.fechaContable)
            series.Points.Add(CDate(s).Month, i.CountCompras)
        Next
        series.Type = ChartSeriesType.Column
        series.Text = series.Name
        Me.chartControl1.Series.Add(series)

        For i As Integer = 0 To colors.Length - 1
            series.Styles(i).Interior = New BrushInfo(colors(i))

        Next
        series.Style.Border.Color = Color.White
        series.Style.Border.DashStyle = DashStyle.Solid

        listaVenta = documentoVentaSA.GetListarVentasPorAnio(GEstableciento.IdEstablecimiento, AnioGeneral)

        series = New ChartSeries("Ventas")
        '      Dim series2 As New ChartSeries("Ventas")
        For Each i In listaVenta
            Dim s = CDate(1 & "/" & i.fechaPeriodo)
            series.Points.Add(CDate(s).Month, i.CountVentas)
        Next

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

    Private Sub frmDashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      
    End Sub

    Private Sub frmDashBoard_Click(sender As Object, e As EventArgs) Handles MyBase.Click

    End Sub

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

    Private Sub gridControl1_PrepareViewStyleInfo(sender As Object, e As GridPrepareViewStyleInfoEventArgs) Handles gridControl1.PrepareViewStyleInfo
        'Dim sourceItem As Double() = New Double(13) {}
        'Try

        '    If e.ColIndex > 13 AndAlso e.RowIndex > 0 AndAlso e.RowIndex <= 14 Then
        '        For j As Integer = 0 To 13
        '            If IsNumeric(Me.gridControl1(e.RowIndex, j + 1).CellValue) Then
        '                sourceItem(j) = Convert.ToDouble(Me.gridControl1(e.RowIndex, j + 1).CellValue)
        '            End If
        '        Next


        '        Me.sparkline(e.RowIndex - 1, e.ColIndex - 12).Source = sourceItem
        '        e.Style.CellType = "Control"

        '        e.Style.Control = Me.sparkline(e.RowIndex - 1, e.ColIndex - 12)
        '    End If
        'Catch ex As Exception
        '    '  MsgBox(ex.Message)
        'End Try
       
    End Sub

    Private Sub frmDashBoard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Cursor = Cursors.WaitCursor
        InitializeChart()
        ChartAppearance.ApplyChartStyles(Me.chartControl1)

        InitializeChart2()
        PieFlujoEfectivo()
        ChartAppearance.ApplyChartStylesPie(Me.ChartControl3)
        'chartControl1.Palette = ChartColorPalette.Custom
        'chartControl1.CustomPalette = New Color() {Color.DarkRed, Color.YellowGreen}
        Me.chartControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ListaVeNtasANio()
        'Label30.Text = "Flujo de Efectivo " & PeriodoGeneral
        'Label4.Text = "Resúmen de ventas - período " & PeriodoGeneral
        Me.Cursor = Cursors.Arrow
    End Sub
End Class