Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports System.ComponentModel
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing
Imports System.Drawing.Drawing2D

Public Class frmTableroPorDia
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvDetalleCajas)
        GridCFG(DgvFlujoEfectivo)

        InitializeChart()
        ChartAppearance.ApplyChartStyles(Me.chartControl1)
        txtFecha.Value = New DateTime(AnioGeneral, MesGeneral, DiaLaboral.Day)
        WindowState = FormWindowState.Maximized
    End Sub

#Region "Métodos"

    Public Sub InitializeChart()
        Dim series As New ChartSeries
        ' Initialize ChartSeries
        Dim colors As Color() = New Color() {Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                            Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                            Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                            Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                            Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141),
                                            Color.FromArgb(220, 108, 141), Color.FromArgb(220, 108, 141)}

        series = New ChartSeries("Compras")

        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoVentaSA As New documentoVentaAbarrotesSA

        Dim lista As New List(Of documentocompra)
        Dim listaVenta As New List(Of documentoventaAbarrotes)

        lista = documentoCompraSA.GetListarComprasPorAnio(GEstableciento.IdEstablecimiento, AnioGeneral)

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

        listaVenta = documentoVentaSA.GetListarVentasPorAnio(GEstableciento.IdEstablecimiento, AnioGeneral)

        series = New ChartSeries("Ventas")
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

    Sub Consulta()
        Me.Cursor = Cursors.WaitCursor
        Dim compraSA As New DocumentoCompraSA
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New List(Of documentoCaja)
        Dim efsa As New EstadosFinancierosSA
        Dim dt As New DataTable
        dt.Columns.Add("tipooperacion")
        dt.Columns.Add("movimiento")
        dt.Columns.Add("total")
        dt.Columns.Add("empresa")
        dt.Columns.Add("estable")

        If CheckBox1.Checked = True Then
            caja = cajaSA.GetFlujoEfectivoByDiaAllEmpresa(New documentoCaja With {.fechaProceso = txtFecha.Value})
        Else
            caja = cajaSA.GetFlujoEfectivoByDia(New documentoCaja With {.fechaProceso = txtFecha.Value})
        End If

        For Each i In caja
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.tipoOperacion
            dr(1) = If(i.tipoMovimiento = "PG", "Pagos", "Cobros")
            dr(2) = i.montoSoles
            dr(3) = i.NomCortoEmpresa
            dr(4) = i.NomCortoEstablecimiento
            dt.Rows.Add(dr)
        Next
        DgvFlujoEfectivo.DataSource = dt


        If CheckBox1.Checked = True Then
            Dim obj = efsa.GetEstadoCajasTodosByDiaAllEmpresa(New documentoCaja With {.fechaProceso = txtFecha.Value})
            lblTotalCajas.Text = CDec(obj.importeBalanceMN).ToString("N2")
            lblTotalEntradas.Text = caja.Where(Function(o) o.tipoMovimiento = "DC").Sum(Function(o) o.montoSoles).GetValueOrDefault
            lblTotalSalida.Text = caja.Where(Function(o) o.tipoMovimiento = "PG").Sum(Function(o) o.montoSoles).GetValueOrDefault


        Else
            Dim obj = efsa.GetEstadoCajasTodosByDia(New documentoCaja With {.fechaProceso = txtFecha.Value})
            lblTotalCajas.Text = CDec(obj.importeBalanceMN).ToString("N2")
            lblTotalEntradas.Text = caja.Where(Function(o) o.tipoMovimiento = "DC").Sum(Function(o) o.montoSoles).GetValueOrDefault
            lblTotalSalida.Text = caja.Where(Function(o) o.tipoMovimiento = "PG").Sum(Function(o) o.montoSoles).GetValueOrDefault

        End If

     

        'DETALLE DE CAJAS
        Dim dtCajas As New DataTable()
        dtCajas.Columns.Add("ef")
        dtCajas.Columns.Add("moneda")
        dtCajas.Columns.Add("tipo")
        dtCajas.Columns.Add("ingreso")
        dtCajas.Columns.Add("salida")
        dtCajas.Columns.Add("saldo")
        dtCajas.Columns.Add("empresa")

        Dim listaEF As New List(Of estadosFinancieros)
        If CheckBox1.Checked = True Then
            listaEF = efsa.GetEstadoCajasTodosDetalleByDiaAllEmpresa(New documentoCaja With {.fechaProceso = txtFecha.Value})
        Else
            listaEF = efsa.GetEstadoCajasTodosDetalleByDia(New documentoCaja With {.fechaProceso = txtFecha.Value})
        End If

        For Each i In listaEF
            Dim dr As DataRow = dtCajas.NewRow
            dr(0) = i.descripcion
            dr(1) = i.codigo
            Select Case i.tipo
                Case CuentaFinanciera.Banco
                    dr(2) = "Banco"
                Case CuentaFinanciera.Efectivo
                    dr(2) = "Efectivo"
                Case CuentaFinanciera.Tarjeta_Credito
                    dr(2) = "Tarj. crédito"
                Case CuentaFinanciera.Tarjeta_Debito
                    dr(2) = "Tarj. Débito"
            End Select

            dr(3) = i.Ingresos.GetValueOrDefault
            dr(4) = i.Salidas.GetValueOrDefault
            dr(5) = i.SaldoCaja.GetValueOrDefault
            dr(6) = i.NomCortoEmpresa
            dtCajas.Rows.Add(dr)
        Next
        dgvDetalleCajas.DataSource = dtCajas
        dgvDetalleCajas.TableDescriptor.GroupedColumns.Clear()
        dgvDetalleCajas.TableDescriptor.GroupedColumns.Add("empresa")

        If CheckBox1.Checked = True Then
            lblComprasDelDia.Text = CDec(compraSA.GetSumaComprasDelDiaAllEmpresa(New documentocompra With {.fechaDoc = txtFecha.Value}).importeTotal.GetValueOrDefault).ToString("N2")
            lblVentasDelDia.Text = CDec(ventaSA.GetSumaVentasDelDiaAllEmpresa(New documentoventaAbarrotes With {.fechaDoc = txtFecha.Value}).ImporteNacional.GetValueOrDefault).ToString("N2")
        Else
            lblComprasDelDia.Text = CDec(compraSA.GetSumaComprasDelDia(New documentocompra With {.fechaDoc = txtFecha.Value}).importeTotal.GetValueOrDefault).ToString("N2")
            lblVentasDelDia.Text = CDec(ventaSA.GetSumaVentasDelDia(New documentoventaAbarrotes With {.fechaDoc = txtFecha.Value}).ImporteNacional.GetValueOrDefault).ToString("N2")
        End If

        

        Me.Cursor = Cursors.Arrow
    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

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

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim canSaldo As Decimal = 0
    Dim precUnit As Decimal = 0
    Dim pmAcumnulado As Decimal = 0
    Private Sub GetKardexByDiaCV()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim sumaCostoVenta As Decimal = 0

        '-----------------------------------------------------------------------------------------------------

        ''Dim dt As New DataTable("kárdex - Año " & txtPeriodo.Value.Year)
        ''dt.Columns.Add(New DataColumn("Movimiento", GetType(String))) '0
        ''dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
        ''dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String))) '2
        ''dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        ''dt.Columns.Add(New DataColumn("marca", GetType(String)))
        ' ''lower case p
        ''dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        ''dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        ''dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        ''dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        ''dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        ''dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal))) '.PM
        ''dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        ''dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))

        ''Dim str As String

        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m

        Select Case cboFechaFiltroKardex.Text
            Case "FECHA LABORAL"
                listaInventario = inventario.GetKardexByDiaLaboral_1(New InventarioMovimiento With {.fechaLaboral = txtFecha.Value})
            Case "FECHA DOCUMENTO"
                listaInventario = inventario.GetKardexByDia(New InventarioMovimiento With {.fecha = txtFecha.Value})

        End Select

        For Each i As InventarioMovimiento In listaInventario
            cantidadDeficit = 0
            importeDeficit = 0
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If

                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If

                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then
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

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If

                    Select Case i.tipoOperacion
                        Case "9913"
                            'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            'dr(11) = (0)
                            'dr(12) = 0.0

                        Case "9914"
                            'dr(10) = 0.0
                            'dr(11) = (0)
                            'dr(12) = i.monto * -1

                        Case "9916"
                            'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            'dr(11) = (0)
                            'dr(12) = i.monto * -1

                        Case Else
                            If i.tipoOperacion = "01" Then
                                Dim valCap = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1
                                sumaCostoVenta += valCap
                            End If
                            'dr(12) =  '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    'dr(13) = (FormatNumber(canSaldo, 4))
                    'dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    'dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select

            producto = i.idItem
            productoCache = i.nombreItem

        Next
        lblCostoVentaDia.Text = sumaCostoVenta.ToString("N2")
        'MessageBox.Show("Costo de Ventas." & vbCrLf & _
        '                   "Año -" & AnioGeneral & vbCrLf & sumaCostoVenta.ToString("N2"), "Resúmen Anual", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub GetKardexByDiaLaboralCV()
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim listaInventario As New List(Of InventarioMovimiento)
        'Dim canSaldo As Decimal = 0
        'Dim ImporteSaldo As Decimal = 0
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim productoCache As String = Nothing
        Dim sumaCostoVenta As Decimal = 0


        ImporteSaldo = 0
        canSaldo = 0
        '''''''''''''''m

        Select Case cboFechaFiltroKardex.Text
            Case "FECHA LABORAL"
                listaInventario = inventario.GetKardexByDiaLaboral_1(New InventarioMovimiento With {.fechaLaboral = txtFecha.Value})
            Case "FECHA DOCUMENTO"
                listaInventario = inventario.GetKardexByDia(New InventarioMovimiento With {.fecha = txtFecha.Value})

        End Select

        For Each i As InventarioMovimiento In listaInventario
            cantidadDeficit = 0
            importeDeficit = 0
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    If producto = i.idItem Then
                        productoCache = i.nombreItem
                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec(i.monto)
                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0

                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual
                        canSaldo = CDec(i.cantidad) + canSaldo
                        ImporteSaldo = CDec(i.monto) + ImporteSaldo

                    End If

                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If

                    pmAcumnulado = precUnit
                Case "S", "D"
                    Dim co As Decimal = 0
                    co = Math.Round(CDec(i.cantidad) * pmAcumnulado, 6)

                    If producto = i.idItem Then
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

                            Case Else
                                canSaldo += CDec(i.cantidad)
                                ImporteSaldo += co
                        End Select

                    Else
                        cantidadDeficit = canSaldo
                        importeDeficit = ImporteSaldo

                        canSaldo = 0
                        ImporteSaldo = 0
                        'ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.idItem, dt)
                        canSaldo = canSaldo + saldoCantidadAnual
                        ImporteSaldo = ImporteSaldo + saldoImporteAnual

                        canSaldo += CDec(i.cantidad)
                        ImporteSaldo += CDec((i.cantidad * pmAcumnulado))
                    End If

                    Select Case i.tipoOperacion
                        Case "9913"
                            'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            'dr(11) = (0)
                            'dr(12) = 0.0

                        Case "9914"
                            'dr(10) = 0.0
                            'dr(11) = (0)
                            'dr(12) = i.monto * -1

                        Case "9916"
                            'dr(10) = (FormatNumber(i.cantidad, 4)) * -1
                            'dr(11) = (0)
                            'dr(12) = i.monto * -1

                        Case Else
                            If i.tipoOperacion = "01" Then
                                Dim valCap = (Math.Round(CDec(i.cantidad) * pmAcumnulado, 4)) * -1
                                sumaCostoVenta += valCap
                            End If
                            'dr(12) =  '(Math.Round(CDec(i.cantidad) * pmAcumnulado, 4))
                    End Select
                    'dr(13) = (FormatNumber(canSaldo, 4))
                    'dr(14) = (FormatNumber(ImporteSaldo, 4))
                    If canSaldo > 0 Then
                        precUnit = Math.Round(ImporteSaldo / canSaldo, 4)
                    Else
                        precUnit = 0
                    End If
                    'dr(15) = precUnit
                    pmAcumnulado = precUnit
            End Select

            producto = i.idItem
            productoCache = i.nombreItem

        Next
        lblCostoVentaDia.Text = sumaCostoVenta.ToString("N2")
        'MessageBox.Show("Costo de Ventas." & vbCrLf & _
        '                   "Año -" & AnioGeneral & vbCrLf & sumaCostoVenta.ToString("N2"), "Resúmen Anual", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region

    Private Sub frmTableroPorDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label7.Text = "Compras vs Ventas, período: " & PeriodoGeneral
        Label2.Text = "Balance General del día (saldo en caja) " & txtFecha.Value.Date
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        Consulta()
        If cboFechaFiltroKardex.Text = "FECHA DOCUMENTO" Then
            GetKardexByDiaCV()
        Else
            GetKardexByDiaLaboralCV()
        End If
        lblRentabilidadDia.Text = CDec(CDec(lblVentasDelDia.Text) - CDec(lblCostoVentaDia.Text)).ToString("N2")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub lblComprasDelDia_Click(sender As Object, e As EventArgs) Handles lblComprasDelDia.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New ResumenComprasVentas(txtFecha.Value)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboFechaFiltroKardex_Click(sender As Object, e As EventArgs) Handles cboFechaFiltroKardex.Click

    End Sub

    Private Sub cboFechaFiltroKardex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFechaFiltroKardex.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cboFechaFiltroKardex.Text = "FECHA DOCUMENTO" Then
            GetKardexByDiaCV()
        Else
            GetKardexByDiaLaboralCV()
        End If
        lblRentabilidadDia.Text = CDec(CDec(lblVentasDelDia.Text) - CDec(lblCostoVentaDia.Text)).ToString("N2")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblVentasDelDia_Click(sender As Object, e As EventArgs) Handles lblVentasDelDia.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmResumenVentasFecha(txtFecha.Value)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class