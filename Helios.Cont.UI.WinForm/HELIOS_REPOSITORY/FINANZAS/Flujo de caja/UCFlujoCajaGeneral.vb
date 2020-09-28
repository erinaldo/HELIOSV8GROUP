Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Windows.Forms.Grid
Public Class UCFlujoCajaGeneral
    Private listaMovimientos As List(Of documentoCaja)

#Region "Attributes"
    Public Property documentocajaSA As New DocumentoCajaSA
    Public Property cajaUsuaroSA As New cajaUsuarioSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFechaLaboral.Value = Date.Now
        txtFechaLaboral.BorderStyle = BorderStyle.None
        FormatoGrid()
    End Sub
#End Region

#Region "Formato GRID"
    Private Sub FormatoGrid()
        Me.gridGroupingControl1.Appearance.ColumnHeaderCell.Interior = New BrushInfo(GradientStyle.Vertical, Color.Black, Color.Black)
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = False
        Dim colorF As GridMetroColors = New GridMetroColors()
        colorF.HeaderColor.NormalColor = Color.Black
        colorF.HeaderColor.HoverColor = Color.Empty
        Me.gridGroupingControl1.SetMetroStyle(colorF)
        Me.gridGroupingControl1.AllowProportionalColumnSizing = True
        Me.gridGroupingControl1.DisplayVerticalLines = False
        Me.gridGroupingControl1.BrowseOnly = True
        Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Me.gridGroupingControl1.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        Me.gridGroupingControl1.TableOptions.ShowRowHeader = False
        Me.gridGroupingControl1.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(30, 30, 30))
        Dim captionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Me.gridGroupingControl1.Table.DefaultRecordRowHeight = 30
        Me.gridGroupingControl1.Table.DefaultColumnHeaderRowHeight = 35
        Me.gridGroupingControl1.Appearance.AnyCell.TextColor = Color.White
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Borders.Bottom = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Borders.Right = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyHeaderCell.Borders.Top = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.gridGroupingControl1.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.gridGroupingControl1.TableControl.MetroColorTable.ScrollerBackground = Color.FromArgb(45, 45, 45)
        Me.gridGroupingControl1.TableControl.MetroColorTable.ArrowNormal = Color.FromArgb(195, 195, 195)
        Me.gridGroupingControl1.TableControl.MetroColorTable.ArrowChecked = Color.FromArgb(94, 171, 222)
        Me.gridGroupingControl1.TableControl.MetroColorTable.ThumbNormal = Color.FromArgb(31, 31, 31)
        Me.gridGroupingControl1.TableControl.MetroColorTable.ThumbPushed = Color.FromArgb(94, 171, 222)
        Me.gridGroupingControl1.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled
    End Sub
#End Region

#Region "Methods"

    Public Sub GetEstablecimientos()
        Dim estableSA As New establecimientoSA
        Dim lista = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto = GEstableciento.IdEstablecimiento).ToList

        ComboUnidad.DataSource = lista
        ComboUnidad.ValueMember = "idCentroCosto"
        ComboUnidad.DisplayMember = "nombre"
        ComboUnidad.SelectedValue = GEstableciento.IdEstablecimiento
    End Sub

    Private Sub GetDetalleFujoGeneral()
        Dim dt As New DataTable
        dt.Columns.Add("tipooper")
        dt.Columns.Add("detalle")
        dt.Columns.Add("montosoles")
        ' dt.Columns.Add("action")
        If listaMovimientos IsNot Nothing Then
            If listaMovimientos.Count > 0 Then
                Dim ventaElec = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA).FirstOrDefault

                If ventaElec IsNot Nothing Then
                    'lblventaElectronica.Text = ventaElec.montoSoles.GetValueOrDefault
                    dt.Rows.Add("VENTA ELECTRONICA", "Ingreso", ventaElec.montoSoles.GetValueOrDefault)
                Else
                    'lblventaElectronica.Text = "0.00"
                    dt.Rows.Add("VENTA ELECTRONICA", "Ingreso", "0.00")
                End If

                Dim notaVenta = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA).FirstOrDefault

                If notaVenta IsNot Nothing Then
                    '            lblventaNotas.Text = notaVenta.montoSoles.GetValueOrDefault
                    dt.Rows.Add("NOTAS", "Ingreso", notaVenta.montoSoles.GetValueOrDefault)
                Else
                    'lblventaNotas.Text = "0.00"
                    dt.Rows.Add("NOTAS", "Ingreso", "0.00")
                End If


                Dim otrasEntradas = listaMovimientos.Where(Function(o) o.movimientoCaja = "OEC").FirstOrDefault
                If otrasEntradas IsNot Nothing Then
                    '   lblOtrasEntradasCaja.Text = otrasEntradas.montoSoles.GetValueOrDefault
                    dt.Rows.Add("OTROS INGRESOS DE CAJA", "Ingreso", otrasEntradas.montoSoles.GetValueOrDefault)
                Else
                    'lblOtrasEntradasCaja.Text = "0.00"
                    dt.Rows.Add("OTROS INGRESOS DE CAJA", "Ingreso", "0.00")
                End If

                Dim cobroClientes = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.CobroCliente).FirstOrDefault

                If cobroClientes IsNot Nothing Then
                    'lblPagosCobrados.Text = cobroClientes.montoSoles.GetValueOrDefault
                    dt.Rows.Add("COBROS A CLIENTES", "Ingreso", cobroClientes.montoSoles.GetValueOrDefault)
                Else
                    dt.Rows.Add("COBROS A CLIENTES", "Ingreso", "0.00")
                    'lblPagosCobrados.Text = "0.00"
                End If

                Dim especial = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.Otras_Entradas_Especial).FirstOrDefault

                If especial IsNot Nothing Then
                    'lblIngresoEspecial.Text = especial.montoSoles.GetValueOrDefault
                    dt.Rows.Add("INGRESO ESPECIAL", "Ingreso", especial.montoSoles.GetValueOrDefault)
                Else
                    dt.Rows.Add("INGRESO ESPECIAL", "Ingreso", "0.00")
                    'lblIngresoEspecial.Text = "0.00"
                End If


                'EGRESOS
                '---------------------------------------------------------------------------------

                Dim pagoProv = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.PagoProveedor).FirstOrDefault

                If pagoProv IsNot Nothing Then
                    'LabelPagoProveedor.Text = pagoProv.montoSoles.GetValueOrDefault
                    dt.Rows.Add("PAGO A PROVEEDORES", "Gasto", pagoProv.montoSoles.GetValueOrDefault * -1)
                Else
                    dt.Rows.Add("PAGO A PROVEEDORES", "Gasto", "0.00")
                    'LabelPagoProveedor.Text = "0.00"
                End If

                Dim otrosEgresos = listaMovimientos.Where(Function(o) o.movimientoCaja = "OSC").FirstOrDefault
                If otrosEgresos IsNot Nothing Then
                    'LabelOtrosEgresos.Text = otrosEgresos.montoSoles.GetValueOrDefault
                    dt.Rows.Add("OTROS GASTOS DE CAJA", "Gasto", otrosEgresos.montoSoles.GetValueOrDefault * -1)
                Else
                    dt.Rows.Add("OTROS GASTOS DE CAJA", "Gasto", "0.00")
                    'LabelOtrosEgresos.Text = "0.00"
                End If
            End If
        End If
        gridGroupingControl1.DataSource = dt
    End Sub

    Private Sub GetDetalleFujoGeneral(tipo As String)
        Dim dt As New DataTable
        dt.Columns.Add("tipooper")
        dt.Columns.Add("detalle")
        dt.Columns.Add("montosoles")
        ' dt.Columns.Add("action")
        If listaMovimientos IsNot Nothing Then
            If listaMovimientos.Count > 0 Then

                Select Case tipo
                    Case "INGRESO"
                        Dim ventaElec = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA).FirstOrDefault

                        If ventaElec IsNot Nothing Then
                            'lblventaElectronica.Text = ventaElec.montoSoles.GetValueOrDefault
                            dt.Rows.Add("VENTA ELECTRONICA", "Ingreso", ventaElec.montoSoles.GetValueOrDefault)
                        Else
                            'lblventaElectronica.Text = "0.00"
                            dt.Rows.Add("VENTA ELECTRONICA", "Ingreso", "0.00")
                        End If

                        Dim notaVenta = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA).FirstOrDefault

                        If notaVenta IsNot Nothing Then
                            '            lblventaNotas.Text = notaVenta.montoSoles.GetValueOrDefault
                            dt.Rows.Add("NOTAS", "Ingreso", notaVenta.montoSoles.GetValueOrDefault)
                        Else
                            'lblventaNotas.Text = "0.00"
                            dt.Rows.Add("NOTAS", "Ingreso", "0.00")
                        End If


                        Dim otrasEntradas = listaMovimientos.Where(Function(o) o.movimientoCaja = "OEC").FirstOrDefault
                        If otrasEntradas IsNot Nothing Then
                            '   lblOtrasEntradasCaja.Text = otrasEntradas.montoSoles.GetValueOrDefault
                            dt.Rows.Add("OTROS INGRESOS DE CAJA", "Ingreso", otrasEntradas.montoSoles.GetValueOrDefault)
                        Else
                            'lblOtrasEntradasCaja.Text = "0.00"
                            dt.Rows.Add("OTROS INGRESOS DE CAJA", "Ingreso", "0.00")
                        End If

                        Dim cobroClientes = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.CobroCliente).FirstOrDefault

                        If cobroClientes IsNot Nothing Then
                            'lblPagosCobrados.Text = cobroClientes.montoSoles.GetValueOrDefault
                            dt.Rows.Add("COBROS A CLIENTES", "Ingreso", cobroClientes.montoSoles.GetValueOrDefault)
                        Else
                            dt.Rows.Add("COBROS A CLIENTES", "Ingreso", "0.00")
                            'lblPagosCobrados.Text = "0.00"
                        End If

                        Dim especial = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.Otras_Entradas_Especial).FirstOrDefault

                        If especial IsNot Nothing Then
                            'lblIngresoEspecial.Text = especial.montoSoles.GetValueOrDefault
                            dt.Rows.Add("INGRESO ESPECIAL", "Ingreso", especial.montoSoles.GetValueOrDefault)
                        Else
                            dt.Rows.Add("INGRESO ESPECIAL", "Ingreso", "0.00")
                            'lblIngresoEspecial.Text = "0.00"
                        End If
                    Case "GASTO"
                        'EGRESOS
                        '---------------------------------------------------------------------------------

                        Dim pagoProv = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.PagoProveedor).FirstOrDefault

                        If pagoProv IsNot Nothing Then
                            'LabelPagoProveedor.Text = pagoProv.montoSoles.GetValueOrDefault
                            dt.Rows.Add("PAGO A PROVEEDORES", "Gasto", pagoProv.montoSoles.GetValueOrDefault)
                        Else
                            dt.Rows.Add("PAGO A PROVEEDORES", "Gasto", "0.00")
                            'LabelPagoProveedor.Text = "0.00"
                        End If

                        Dim otrosEgresos = listaMovimientos.Where(Function(o) o.movimientoCaja = "OSC").FirstOrDefault
                        If otrosEgresos IsNot Nothing Then
                            'LabelOtrosEgresos.Text = otrosEgresos.montoSoles.GetValueOrDefault
                            dt.Rows.Add("OTROS GASTOS DE CAJA", "Gasto", otrosEgresos.montoSoles.GetValueOrDefault)
                        Else
                            dt.Rows.Add("OTROS GASTOS DE CAJA", "Gasto", "0.00")
                            'LabelOtrosEgresos.Text = "0.00"
                        End If
                End Select

            End If
        End If
        gridGroupingControl1.DataSource = dt
    End Sub

    Private Sub GetMovimientosDeCaja(fecha As Date?)
        Dim tipoIngresos As New List(Of String)
        tipoIngresos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        tipoIngresos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        tipoIngresos.Add("OEC")
        tipoIngresos.Add(MovimientoCaja.CobroCliente)
        tipoIngresos.Add(MovimientoCaja.Otras_Entradas_Especial)

        Dim egresos As New List(Of String)
        egresos.Add(MovimientoCaja.PagoProveedor)
        egresos.Add("OSC")

        Try
            listaMovimientos = documentocajaSA.GetMovimientosCajaCajeroUnidadNegocio(
           New Business.Entity.cajaUsuario With
           {
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = ComboUnidad.SelectedValue,
           .fechaCierre = fecha
           })

            If listaMovimientos IsNot Nothing Or listaMovimientos.Count > 0 Then
                Dim ingresosTotal = listaMovimientos.Where(Function(o) tipoIngresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault

                Dim EgresosTotal = listaMovimientos.Where(Function(o) egresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault

                LabelTotalVentas.Text = $"S/{CDec(ingresosTotal).ToString("N2")}"
                LabelTotalGastos.Text = $"S/{CDec(EgresosTotal).ToString("N2")}"

                Dim saldo = ingresosTotal - EgresosTotal
                LabelTotalSaldo.Text = $"S/{CDec(saldo).ToString("N2")}"


                'LabelReclamacionClientes.Text = "0.00"
            Else
                'lblventaElectronica.Text = "0.00"
                'lblventaNotas.Text = "0.00"
                'lblOtrasEntradasCaja.Text = "0.00"
                'lblPagosCobrados.Text = "0.00"
                'lblIngresoEspecial.Text = "0.00"
                'LabelPagoProveedor.Text = "0.00"
                'LabelOtrosEgresos.Text = "0.00"
                'LabelReclamacionClientes.Text = "0.00"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub GetMovimientosDeCajaAllUsers(fecha As Date?)
    '    Dim dt As New DataTable
    '    Dim tipoIngresos As New List(Of String)
    '    tipoIngresos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
    '    tipoIngresos.Add(TIPO_VENTA.NOTA_DE_VENTA)
    '    tipoIngresos.Add("OEC")
    '    tipoIngresos.Add(MovimientoCaja.CobroCliente)
    '    tipoIngresos.Add(MovimientoCaja.Otras_Entradas_Especial)

    '    Dim egresos As New List(Of String)
    '    egresos.Add(MovimientoCaja.PagoProveedor)
    '    egresos.Add("OSC")

    '    Try
    '        Dim listaMovimientosXuser = documentocajaSA.GetMovimientosCajaCajeroUnidadNegocioCajeros(
    '       New Business.Entity.cajaUsuario With
    '       {
    '       .idEmpresa = Gempresas.IdEmpresaRuc,
    '       .idEstablecimiento = ComboUnidad.SelectedValue,
    '       .fechaCierre = fecha
    '       })

    '        If listaMovimientosXuser IsNot Nothing Or listaMovimientosXuser.Count > 0 Then

    '            Dim listaUsers = listaMovimientosXuser.Select(Function(u) u.idCajaUsuario).Distinct.ToList

    '            dt.Columns.Add("Usuario")
    '            dt.Columns.Add("Ingresos")
    '            dt.Columns.Add("Gastos")
    '            dt.Columns.Add("Saldo")

    '            For Each user In listaUsers
    '                Dim IngresosUsuario = listaMovimientosXuser.Where(Function(o) o.idCajaUsuario = user AndAlso tipoIngresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault
    '                Dim EgresosUsuario = listaMovimientosXuser.Where(Function(o) o.idCajaUsuario = user AndAlso egresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault

    '                Dim saldoXUsuario = IngresosUsuario - EgresosUsuario
    '                dt.Rows.Add(user, $"S/{CDec(IngresosUsuario).ToString("N2")}",
    '                             $"S/{CDec(EgresosUsuario).ToString("N2")}",
    '                             $"S/{CDec(saldoXUsuario).ToString("N2")}")

    '            Next
    '            GridUsuarioCaja.DataSource = dt

    '            'LabelReclamacionClientes.Text = "0.00"
    '        Else
    '            GridUsuarioCaja.DataSource = New DataTable
    '            'lblventaElectronica.Text = "0.00"
    '            'lblventaNotas.Text = "0.00"
    '            'lblOtrasEntradasCaja.Text = "0.00"
    '            'lblPagosCobrados.Text = "0.00"
    '            'lblIngresoEspecial.Text = "0.00"
    '            'LabelPagoProveedor.Text = "0.00"
    '            'LabelOtrosEgresos.Text = "0.00"
    '            'LabelReclamacionClientes.Text = "0.00"
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Function UsuarioValido() As cajaUsuario
    '    UsuarioValido = New cajaUsuario

    '    Dim codigoVendedor = TextCodigoVendedor.Text.Trim
    '    Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

    '    If usuarioSel IsNot Nothing Then
    '        Dim cajaUsuario = cajaUsuaroSA.UbicarCajeroIDUsuarioActiva(New Business.Entity.cajaUsuario With
    '                                                                   {.idPersona = usuarioSel.IDUsuario})

    '        If cajaUsuario IsNot Nothing Then
    '            UsuarioValido = cajaUsuario
    '        End If

    '    End If

    'End Function
#End Region

#Region "Chart"
    Private Sub InitializeChart()
        'Dim tipoIngresos As New List(Of String)
        'tipoIngresos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        'tipoIngresos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        'tipoIngresos.Add("OEC")
        'tipoIngresos.Add(MovimientoCaja.CobroCliente)
        'tipoIngresos.Add(MovimientoCaja.Otras_Entradas_Especial)

        'Dim egresos As New List(Of String)
        'egresos.Add(MovimientoCaja.PagoProveedor)
        'egresos.Add("OSC")



        Dim labels As String() = {"Venta Electronica", "Nota de venta", "Otros ingresos", "Cobro clientes", "Ingreso especial", "Pago proveedores", "Otros gastos"}
        Dim colors As Color() = New Color() {
            Color.FromArgb(12, 128, 64),
            Color.FromArgb(237, 31, 36),
            Color.FromArgb(243, 236, 25),
            Color.FromArgb(126, 40, 126),
            Color.FromArgb(56, 83, 164),
            Color.FromArgb(234, 85, 193),
            Color.FromArgb(228, 175, 63)}
        Dim data As List(Of Points) = New List(Of Points)()

        MappingDetalleDataChart(data)

        Me.chartControl1.Series.Clear()
        Dim series As ChartSeries = New ChartSeries("Series", ChartSeriesType.Column)
        Dim model As ChartDataBindModel = New ChartDataBindModel(data)
        model.YNames = New String() {"Quantity"}
        series.SeriesModel = model
        Me.chartControl1.Series.Add(series)

        For i As Integer = 0 To colors.Length - 1
            series.Styles(i).Interior = New BrushInfo(colors(i))
        Next

        Me.chartControl1.PrimaryXAxis.ForeColor = Color.White
        Me.chartControl1.PrimaryYAxis.ForeColor = Color.White
        Me.chartControl1.PrimaryXAxis.TickLabelsDrawingMode = ChartAxisTickLabelDrawingMode.UserMode
        Dim labelModel As ChartDataBindAxisLabelModel = New ChartDataBindAxisLabelModel(data)
        labelModel.LabelName = "Product"
        Me.chartControl1.PrimaryXAxis.LabelsImpl = labelModel
        series.PointsToolTipFormat = "Quantity:{4}"
        series.FancyToolTip.Visible = False
        series.FancyToolTip.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.chartControl1.PrimaryXAxis.LabelRotate = False
        Me.chartControl1.PrimaryXAxis.LabelRotateAngle = 45
        Me.chartControl1.ChartInterior = New BrushInfo(Color.FromArgb(15, 15, 16))
        Me.chartControl1.ShowLegend = False
        Me.chartControl1.TextAlignment = StringAlignment.Near
        Me.chartControl1.ForeColor = Color.White
        Me.chartControl1.ChartToolTip = "Quantity"
    End Sub

    Private Sub MappingDetalleDataChart(data As List(Of Points))
        Dim ventaElec = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA).FirstOrDefault

        If ventaElec IsNot Nothing Then
            'lblventaElectronica.Text = ventaElec.montoSoles.GetValueOrDefault
            'dt.Rows.Add("VENTA ELECTRONICA", "Ingreso", ventaElec.montoSoles.GetValueOrDefault)
            data.Add(New Points("Venta-E", ventaElec.montoSoles.GetValueOrDefault))
        Else
            'lblventaElectronica.Text = "0.00"
            'dt.Rows.Add("VENTA ELECTRONICA", "Ingreso", "0.00")
            data.Add(New Points("Venta-E", "0.00"))
        End If

        Dim notaVenta = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA).FirstOrDefault

        If notaVenta IsNot Nothing Then
            '            lblventaNotas.Text = notaVenta.montoSoles.GetValueOrDefault
            '  dt.Rows.Add("NOTAS", "Ingreso", notaVenta.montoSoles.GetValueOrDefault)
            data.Add(New Points("Notas", notaVenta.montoSoles.GetValueOrDefault))
        Else
            'lblventaNotas.Text = "0.00"
            '    dt.Rows.Add("NOTAS", "Ingreso", "0.00")
            data.Add(New Points("Notas", "0.00"))
        End If


        Dim otrasEntradas = listaMovimientos.Where(Function(o) o.movimientoCaja = "OEC").FirstOrDefault
        If otrasEntradas IsNot Nothing Then
            data.Add(New Points("OT-ingreso", otrasEntradas.montoSoles.GetValueOrDefault))
        Else
            'lblOtrasEntradasCaja.Text = "0.00"
            '    dt.Rows.Add("OTROS INGRESOS DE CAJA", "Ingreso", "0.00")
            data.Add(New Points("OT-ingreso", "0.00"))
        End If

        Dim cobroClientes = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.CobroCliente).FirstOrDefault

        If cobroClientes IsNot Nothing Then
            'lblPagosCobrados.Text = cobroClientes.montoSoles.GetValueOrDefault
            'dt.Rows.Add("COBROS A CLIENTES", "Ingreso", cobroClientes.montoSoles.GetValueOrDefault)
            data.Add(New Points("Cobros", cobroClientes.montoSoles.GetValueOrDefault))
        Else
            ' dt.Rows.Add("COBROS A CLIENTES", "Ingreso", "0.00")
            'lblPagosCobrados.Text = "0.00"
            data.Add(New Points("Cobros", "0.00"))
        End If

        Dim especial = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.Otras_Entradas_Especial).FirstOrDefault

        If especial IsNot Nothing Then
            'lblIngresoEspecial.Text = especial.montoSoles.GetValueOrDefault
            'dt.Rows.Add("INGRESO ESPECIAL", "Ingreso", especial.montoSoles.GetValueOrDefault)
            data.Add(New Points("Especial", especial.montoSoles.GetValueOrDefault))
        Else
            ' dt.Rows.Add("INGRESO ESPECIAL", "Ingreso", "0.00")
            'lblIngresoEspecial.Text = "0.00"
            data.Add(New Points("Especial", "0.00"))
        End If

        'EGRESOS
        '--------------------------------------------------------------------------------------

        Dim pagoProv = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.PagoProveedor).FirstOrDefault

        If pagoProv IsNot Nothing Then
            'LabelPagoProveedor.Text = pagoProv.montoSoles.GetValueOrDefault
            'dt.Rows.Add("PAGO A PROVEEDORES", "Gasto", pagoProv.montoSoles.GetValueOrDefault)
            data.Add(New Points("Pagos", pagoProv.montoSoles.GetValueOrDefault))
        Else
            data.Add(New Points("Pagos", "0.00"))
            'LabelPagoProveedor.Text = "0.00"
        End If

        Dim otrosEgresos = listaMovimientos.Where(Function(o) o.movimientoCaja = "OSC").FirstOrDefault
        If otrosEgresos IsNot Nothing Then
            'LabelOtrosEgresos.Text = otrosEgresos.montoSoles.GetValueOrDefault
            data.Add(New Points("OT-gasto", otrosEgresos.montoSoles.GetValueOrDefault))
        Else
            data.Add(New Points("OT-gasto", "0.00"))
            'LabelOtrosEgresos.Text = "0.00"
        End If

    End Sub

    Public Class Points
        Public Property Product As String
        Public Property Quantity As Double

        Public Sub New(ByVal x As String, ByVal y As Double)
            Me.Product = x
            Me.Quantity = y
        End Sub
    End Class
#End Region

#Region "Events"
    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        If ComboUnidad.Text.Trim.Length > 0 Then
            GetMovimientosDeCaja(txtFechaLaboral.Value)
            '   GetMovimientosDeCajaAllUsers(txtFechaLaboral.Value)
            GetDetalleFujoGeneral()
            InitializeChart()
        End If
    End Sub

    Private Sub LabelTotalVentas_Click(sender As Object, e As EventArgs) Handles LabelTotalVentas.Click
        GetDetalleFujoGeneral("INGRESO")
    End Sub

    Private Sub LabelTotalGastos_Click(sender As Object, e As EventArgs) Handles LabelTotalGastos.Click
        GetDetalleFujoGeneral("GASTO")
    End Sub

    Private Sub LabelTotalSaldo_Click(sender As Object, e As EventArgs) Handles LabelTotalSaldo.Click
        GetDetalleFujoGeneral()
    End Sub

    Private Sub pictureBox1_Click(sender As Object, e As EventArgs) Handles pictureBox1.Click
        chartControl1.Visible = False
        gridGroupingControl1.Visible = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        chartControl1.Visible = True
        gridGroupingControl1.Visible = False
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        '     GetMovimientosCajeros()
    End Sub



#End Region

End Class
