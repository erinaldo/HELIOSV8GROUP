Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class UCResumenVentas
    Private listaMovimientos As List(Of documentoCaja)
    Private listaMovimientosOperaciones As List(Of documentoCaja)
    Private listaMovimientosFormaPago As List(Of documentoCaja)
    Private usuarioActivo As cajaUsuario
    Private listaFormaPagoDetalleOperaciones As List(Of documentoCaja)

    Public Property FormPurchase As FormCierreXUsuario
    Public Property FormPurchase2 As FormTablaPrincipalCaja
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
        FormatoGridBlack(GridFormaPago, True)
        FormatoGridBlack(GridComprobantes, True)
        FormatoGridBlack(GridFjloCajaDetalle, True)
        FormatoGridBlack(GridFormaPagoDetalle, True)
        txtFechaLaboral.BorderColor = Color.FromArgb(209, 211, 212)

    End Sub

    Public Sub New(FormTablaPrincipalCaja As FormTablaPrincipalCaja)

        ' This call is required by the designer.
        InitializeComponent()

        txtFechaLaboral.Value = Date.Now
        txtFechaLaboral.BorderStyle = BorderStyle.None
        FormatoGrid()
        FormatoGridBlack(GridFormaPago, True)
        FormatoGridBlack(GridComprobantes, True)
        FormatoGridBlack(GridFjloCajaDetalle, True)
        FormatoGridBlack(GridFormaPagoDetalle, True)
        txtFechaLaboral.BorderColor = Color.FromArgb(209, 211, 212)

        FormPurchase2 = FormTablaPrincipalCaja
        ' Ay initialization after the InitializeComponent() call.

    End Sub



    Public Sub New(codigo As String, FormCierreXUsuario As FormCierreXUsuario)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFechaLaboral.Value = Date.Now
        txtFechaLaboral.BorderStyle = BorderStyle.None
        FormatoGrid()
        FormatoGridBlack(GridFormaPago, True)
        FormatoGridBlack(GridComprobantes, True)
        FormatoGridBlack(GridFjloCajaDetalle, True)
        FormatoGridBlack(GridFormaPagoDetalle, True)
        txtFechaLaboral.BorderColor = Color.FromArgb(209, 211, 212)

        TextCodigoVendedor.Text = codigo
        FormPurchase = FormCierreXUsuario

        CargarCierreXUsuario()


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

    Public Sub CargarCierreXUsuario()

        If TextCodigoVendedor.Text.Trim.Length > 0 Then
            'If e.KeyCode = Keys.Enter Then

            LabelFondoInicio.Text = "0.00"
            LabelFondoInicioUSD.Text = "0.00"

            Cursor = Cursors.WaitCursor
            'e.SuppressKeyPress = True

            If GconfigCaja = "1" Then
                usuarioActivo = UsuarioValido()
            ElseIf GconfigCaja = "2" Then
                usuarioActivo = UsuarioValidoPC()
            End If




            If usuarioActivo IsNot Nothing Then

                If usuarioActivo.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

                    GetFondoInicio(usuarioActivo.idcajaUsuario)
                    GetMovimientosDeCajaAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetMovimientosDeCajaDetalleOperacionesAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetMovimientosDeCajaFormaPagoAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetFormaPagoDetalleAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetDetalleComprobantesVendidosAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetDetalleFujoGeneral()
                    GetDetallFormaPago()
                    InitializeChart()
                    BunifuThinButton21.Visible = True
                    LabelUser.Visible = True
                    LabelUser.Text = $"{"Usuario"}-{usuarioActivo.NombrePersona}"

                ElseIf usuarioActivo.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

                    GetFondoInicio(usuarioActivo.idcajaUsuario)
                    GetMovimientosDeCaja(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetMovimientosDeCajaDetalleOperaciones(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetMovimientosDeCajaFormaPago(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetFormaPagoDetalle(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetDetalleComprobantesVendidos(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetDetalleFujoGeneral()
                    GetDetallFormaPago()
                    InitializeChart()
                    BunifuThinButton21.Visible = True
                    LabelUser.Visible = True
                    LabelUser.Text = $"{"Usuario"}-{usuarioActivo.NombrePersona}"
                End If




            Else
                    MessageBox.Show("El usuario no registra un acaja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LabelUser.Visible = False
                BunifuThinButton21.Visible = False
                gridGroupingControl1.DataSource = New DataTable
            End If
            Cursor = Cursors.Default
            'End If
        End If

    End Sub


    Private Sub GetDetalleFujoGeneral()
        Dim dt As New DataTable
        dt.Columns.Add("tipooper")
        dt.Columns.Add("detalle")
        dt.Columns.Add("montosoles")
        ' dt.Columns.Add("action")
        If CDec(LabelFondoInicio.Text) > 0 Then
            dt.Rows.Add("FONDO DE INICIO", "Ingreso", CDec(LabelFondoInicio.Text))
        End If

        If CDec(LabelFondoInicioUSD.Text) > 0 Then
            dt.Rows.Add("FONDO DE INICIO USD", "Ingreso", CDec(LabelFondoInicioUSD.Text))
        End If

        If listaMovimientos IsNot Nothing Then
            If listaMovimientos.Count > 0 Then
                Dim ventaElec = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA And o.moneda = "1").FirstOrDefault
                Dim ventaElecME = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA And o.moneda = "2").FirstOrDefault

                If ventaElec IsNot Nothing Then
                    'lblventaElectronica.Text = ventaElec.montoSoles.GetValueOrDefault
                    dt.Rows.Add("VENTA ELECTRONICA PEN", "Ingreso", ventaElec.montoSoles.GetValueOrDefault)
                Else
                    'lblventaElectronica.Text = "0.00"
                    dt.Rows.Add("VENTA ELECTRONICA PEN", "Ingreso", "0.00")
                End If

                If ventaElecME IsNot Nothing Then
                    'lblventaElectronica.Text = ventaElec.montoSoles.GetValueOrDefault
                    dt.Rows.Add("VENTA ELECTRONICA USD", "Ingreso", ventaElecME.montoUsd.GetValueOrDefault)
                Else
                    'lblventaElectronica.Text = "0.00"
                    dt.Rows.Add("VENTA ELECTRONICA USD", "Ingreso", "0.00")
                End If


                Dim notaVenta = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA And o.moneda = "1").FirstOrDefault
                Dim notaVentaME = listaMovimientos.Where(Function(o) o.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA And o.moneda = "2").FirstOrDefault

                If notaVenta IsNot Nothing Then
                    '            lblventaNotas.Text = notaVenta.montoSoles.GetValueOrDefault
                    dt.Rows.Add("NOTAS PEN", "Ingreso", notaVenta.montoSoles.GetValueOrDefault)
                Else
                    'lblventaNotas.Text = "0.00"
                    dt.Rows.Add("NOTAS PEN", "Ingreso", "0.00")
                End If
                If notaVentaME IsNot Nothing Then
                    '            lblventaNotas.Text = notaVenta.montoSoles.GetValueOrDefault
                    dt.Rows.Add("NOTAS USD", "Ingreso", notaVentaME.montoUsd.GetValueOrDefault)
                Else
                    'lblventaNotas.Text = "0.00"
                    dt.Rows.Add("NOTAS USD", "Ingreso", "0.00")
                End If

                Dim otrasEntradas = listaMovimientos.Where(Function(o) o.movimientoCaja = "OEC" And o.moneda = "1").FirstOrDefault
                Dim otrasEntradasME = listaMovimientos.Where(Function(o) o.movimientoCaja = "OEC" And o.moneda = "2").FirstOrDefault

                If otrasEntradas IsNot Nothing Then
                    '   lblOtrasEntradasCaja.Text = otrasEntradas.montoSoles.GetValueOrDefault
                    dt.Rows.Add("OTROS INGRESOS DE CAJA", "Ingreso", otrasEntradas.montoSoles.GetValueOrDefault)
                Else
                    'lblOtrasEntradasCaja.Text = "0.00"
                    dt.Rows.Add("OTROS INGRESOS DE CAJA", "Ingreso", "0.00")
                End If

                If otrasEntradasME IsNot Nothing Then
                    '   lblOtrasEntradasCaja.Text = otrasEntradas.montoSoles.GetValueOrDefault
                    dt.Rows.Add("OTROS INGRESOS DE CAJA USD", "Ingreso", otrasEntradasME.montoUsd.GetValueOrDefault)
                Else
                    'lblOtrasEntradasCaja.Text = "0.00"
                    dt.Rows.Add("OTROS INGRESOS DE CAJA USD", "Ingreso", "0.00")
                End If

                Dim cobroClientes = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.CobroCliente And o.moneda = "1").FirstOrDefault
                Dim cobroClientesME = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.CobroCliente And o.moneda = "2").FirstOrDefault

                If cobroClientes IsNot Nothing Then
                    'lblPagosCobrados.Text = cobroClientes.montoSoles.GetValueOrDefault
                    dt.Rows.Add("COBROS A CLIENTES", "Ingreso", cobroClientes.montoSoles.GetValueOrDefault)
                Else
                    dt.Rows.Add("COBROS A CLIENTES", "Ingreso", "0.00")
                    'lblPagosCobrados.Text = "0.00"
                End If

                If cobroClientesME IsNot Nothing Then
                    'lblPagosCobrados.Text = cobroClientes.montoSoles.GetValueOrDefault
                    dt.Rows.Add("COBROS A CLIENTES USD", "Ingreso", cobroClientesME.montoUsd.GetValueOrDefault)
                Else
                    dt.Rows.Add("COBROS A CLIENTES USD", "Ingreso", "0.00")
                    'lblPagosCobrados.Text = "0.00"
                End If

                Dim especial = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.Otras_Entradas_Especial And o.moneda = "1").FirstOrDefault
                Dim especialME = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.Otras_Entradas_Especial And o.moneda = "2").FirstOrDefault

                If especial IsNot Nothing Then
                    'lblIngresoEspecial.Text = especial.montoSoles.GetValueOrDefault
                    dt.Rows.Add("INGRESO ESPECIAL", "Ingreso", especial.montoSoles.GetValueOrDefault)
                Else
                    dt.Rows.Add("INGRESO ESPECIAL", "Ingreso", "0.00")
                    'lblIngresoEspecial.Text = "0.00"
                End If

                If especialME IsNot Nothing Then
                    'lblIngresoEspecial.Text = especial.montoSoles.GetValueOrDefault
                    dt.Rows.Add("INGRESO ESPECIAL USD", "Ingreso", especialME.montoUsd.GetValueOrDefault)
                Else
                    dt.Rows.Add("INGRESO ESPECIAL USD", "Ingreso", "0.00")
                    'lblIngresoEspecial.Text = "0.00"
                End If

                'EGRESOS
                '---------------------------------------------------------------------------------

                Dim pagoProv = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.PagoProveedor And o.moneda = "1").FirstOrDefault
                Dim pagoProvME = listaMovimientos.Where(Function(o) o.movimientoCaja = MovimientoCaja.PagoProveedor And o.moneda = "2").FirstOrDefault

                If pagoProv IsNot Nothing Then
                    'LabelPagoProveedor.Text = pagoProv.montoSoles.GetValueOrDefault
                    dt.Rows.Add("PAGO A PROVEEDORES", "Gasto", pagoProv.montoSoles.GetValueOrDefault * -1)
                Else
                    dt.Rows.Add("PAGO A PROVEEDORES", "Gasto", "0.00")
                    'LabelPagoProveedor.Text = "0.00"
                End If

                If pagoProvME IsNot Nothing Then
                    'LabelPagoProveedor.Text = pagoProv.montoSoles.GetValueOrDefault
                    dt.Rows.Add("PAGO A PROVEEDORES USD", "Gasto", pagoProvME.montoUsd.GetValueOrDefault * -1)
                Else
                    dt.Rows.Add("PAGO A PROVEEDORES USD", "Gasto", "0.00")
                    'LabelPagoProveedor.Text = "0.00"
                End If

                Dim otrosEgresos = listaMovimientos.Where(Function(o) o.movimientoCaja = "OSC" And o.moneda = "1").FirstOrDefault
                Dim otrosEgresosME = listaMovimientos.Where(Function(o) o.movimientoCaja = "OSC" And o.moneda = "2").FirstOrDefault

                If otrosEgresos IsNot Nothing Then
                    'LabelOtrosEgresos.Text = otrosEgresos.montoSoles.GetValueOrDefault
                    dt.Rows.Add("OTROS GASTOS DE CAJA", "Gasto", otrosEgresos.montoSoles.GetValueOrDefault * -1)
                Else
                    dt.Rows.Add("OTROS GASTOS DE CAJA", "Gasto", "0.00")
                    'LabelOtrosEgresos.Text = "0.00"
                End If

                If otrosEgresosME IsNot Nothing Then
                    'LabelOtrosEgresos.Text = otrosEgresos.montoSoles.GetValueOrDefault
                    dt.Rows.Add("OTROS GASTOS DE CAJA USD", "Gasto", otrosEgresosME.montoUsd.GetValueOrDefault * -1)
                Else
                    dt.Rows.Add("OTROS GASTOS DE CAJA USD", "Gasto", "0.00")
                    'LabelOtrosEgresos.Text = "0.00"
                End If

            End If
        End If
        gridGroupingControl1.DataSource = dt
    End Sub

    Private Sub GetDetallFormaPago()

        Dim ingresos As Decimal = 0
        Dim salidas As Decimal = 0

        Dim dt As New DataTable
        dt.Columns.Add("formapago")
        dt.Columns.Add("importe")
        dt.Columns.Add("salidas")
        dt.Columns.Add("saldo")

        If CDec(LabelFondoInicio.Text) > 0 Then
            dt.Rows.Add("FONDO DE INICIO", CDec(LabelFondoInicio.Text))
        End If

        If CDec(LabelFondoInicioUSD.Text) > 0 Then
            dt.Rows.Add("FONDO DE INICIO USD", CDec(LabelFondoInicioUSD.Text))
        End If

        If listaMovimientosFormaPago IsNot Nothing Then
            If listaMovimientosFormaPago.Count > 0 Then
                Dim FORMA_EFECTIVO = listaMovimientosFormaPago.Where(Function(o) o.formapago = "109" And o.moneda = "1").ToList
                Dim FORMA_EFECTIVOUSD = listaMovimientosFormaPago.Where(Function(o) o.formapago = "109" And o.moneda = "2").ToList
                If FORMA_EFECTIVO IsNot Nothing Then
                    For Each i In FORMA_EFECTIVO
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoSoles.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoSoles.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("EFECTIVO", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    'lblventaElectronica.Text = "0.00"
                    dt.Rows.Add("EFECTIVO", "0.00")
                End If

                If FORMA_EFECTIVOUSD IsNot Nothing Then
                    For Each i In FORMA_EFECTIVOUSD
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoUsd.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoUsd.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("EFECTIVO USD", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    'lblventaElectronica.Text = "0.00"
                    dt.Rows.Add("EFECTIVO USD", "0.00")
                End If


                Dim DEPOSITO_CUENTA = listaMovimientosFormaPago.Where(Function(o) o.formapago = "001" And o.moneda = "1").ToList
                Dim DEPOSITO_CUENTAUSD = listaMovimientosFormaPago.Where(Function(o) o.formapago = "001" And o.moneda = "2").ToList

                If DEPOSITO_CUENTA IsNot Nothing Then
                    For Each i In DEPOSITO_CUENTA
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoSoles.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoSoles.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("DEPOSITO EN CUENTA", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    'lblventaNotas.Text = "0.00"
                    dt.Rows.Add("DEPOSITO EN CUENTA", "0.00")
                End If

                If DEPOSITO_CUENTAUSD IsNot Nothing Then
                    For Each i In DEPOSITO_CUENTAUSD
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoUsd.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoUsd.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("DEPOSITO EN CUENTA USD", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    'lblventaNotas.Text = "0.00"
                    dt.Rows.Add("DEPOSITO EN CUENTA USD", "0.00")
                End If


                Dim ORDEN_PAGO = listaMovimientosFormaPago.Where(Function(o) o.formapago = "004" And o.moneda = "1").ToList
                Dim ORDEN_PAGOUSD = listaMovimientosFormaPago.Where(Function(o) o.formapago = "004" And o.moneda = "2").ToList
                If ORDEN_PAGO IsNot Nothing Then
                    For Each i In ORDEN_PAGO
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoSoles.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoSoles.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("ORDEN DE PAGO", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    'lblOtrasEntradasCaja.Text = "0.00"
                    dt.Rows.Add("ORDEN DE PAGO", "0.00")
                End If

                If ORDEN_PAGOUSD IsNot Nothing Then
                    For Each i In ORDEN_PAGOUSD
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoUsd.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoUsd.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("ORDEN DE PAGO USD", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    'lblOtrasEntradasCaja.Text = "0.00"
                    dt.Rows.Add("ORDEN DE PAGO USD", "0.00")
                End If

                Dim TARJETA_DEBITO = listaMovimientosFormaPago.Where(Function(o) o.formapago = "005" And o.moneda = "1").ToList
                Dim TARJETA_DEBITOUSD = listaMovimientosFormaPago.Where(Function(o) o.formapago = "005" And o.moneda = "2").ToList
                If TARJETA_DEBITO IsNot Nothing Then
                    For Each i In TARJETA_DEBITO
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoSoles.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoSoles.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("TARJETA DE DEBITO", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    dt.Rows.Add("TARJETA DE DEBITO", "0.00")
                    'lblPagosCobrados.Text = "0.00"
                End If

                If TARJETA_DEBITOUSD IsNot Nothing Then
                    For Each i In TARJETA_DEBITOUSD
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoUsd.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoUsd.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("TARJETA DE DEBITO USD", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    dt.Rows.Add("TARJETA DE DEBITO USD", "0.00")
                    'lblPagosCobrados.Text = "0.00"
                End If

                Dim TARJETA_CREDITO = listaMovimientosFormaPago.Where(Function(o) o.formapago = "006" And o.moneda = "1").ToList
                Dim TARJETA_CREDITOUSD = listaMovimientosFormaPago.Where(Function(o) o.formapago = "006" And o.moneda = "2").ToList

                If TARJETA_CREDITO IsNot Nothing Then
                    For Each i In TARJETA_CREDITO
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoSoles.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoSoles.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("TARJETA DE CREDITO", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    dt.Rows.Add("TARJETA DE CREDITO", "0.00")
                    'lblIngresoEspecial.Text = "0.00"
                End If

                If TARJETA_CREDITOUSD IsNot Nothing Then
                    For Each i In TARJETA_CREDITOUSD
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoUsd.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoUsd.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("TARJETA DE CREDITO USD", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    dt.Rows.Add("TARJETA DE CREDITO USD", "0.00")
                    'lblIngresoEspecial.Text = "0.00"
                End If

                Dim CHEQUE = listaMovimientosFormaPago.Where(Function(o) o.formapago = "007" And o.moneda = "1").ToList
                Dim CHEQUEUSD = listaMovimientosFormaPago.Where(Function(o) o.formapago = "007" And o.moneda = "2").ToList
                If CHEQUE IsNot Nothing Then
                    For Each i In CHEQUE
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoSoles.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoSoles.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("CHEQUES", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    dt.Rows.Add("CHEQUES", "0.00")
                    'lblIngresoEspecial.Text = "0.00"
                End If

                If CHEQUEUSD IsNot Nothing Then
                    For Each i In CHEQUEUSD
                        Select Case i.tipoMovimiento
                            Case "PG"
                                salidas = i.montoUsd.GetValueOrDefault '* -1
                            Case "DC"
                                ingresos = i.montoUsd.GetValueOrDefault
                        End Select
                    Next
                    dt.Rows.Add("CHEQUES USD", ingresos, salidas, ingresos - salidas)
                    salidas = 0
                    ingresos = 0
                Else
                    dt.Rows.Add("CHEQUES USD", "0.00")
                    'lblIngresoEspecial.Text = "0.00"
                End If

                'EGRESOS
                '---------------------------------------------------------------------------------


            End If
        End If
        GridFormaPago.DataSource = dt
    End Sub


    Private Sub GetDetalleComprobantesVendidosAdmi(IDCajaUsuario As Integer, fecha As Date?)

        Dim efectivo As Decimal = 0
        Dim tarjeta As Decimal = 0
        Dim cheque As Decimal = 0
        Dim Depositos As Decimal = 0

        Dim dt As New DataTable
        dt.Columns.Add("comprobante")
        dt.Columns.Add("numero")
        dt.Columns.Add("efectivo")
        dt.Columns.Add("tarjeta")
        dt.Columns.Add("cheque")
        dt.Columns.Add("cta")
        dt.Columns.Add("total")
        dt.Columns.Add("porCobrar")


        Dim listaComprobantes = documentocajaSA.GetMovimientosCajaComprobanteVentasAdmi(
           New Business.Entity.cajaUsuario With
           {
           .idcajaUsuario = IDCajaUsuario,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .fechaCierre = fecha
           })

        If listaComprobantes IsNot Nothing Then
            If listaComprobantes.Count > 0 Then

                Dim listaDocs = (From n In listaComprobantes
                                 Select n.idDocumento, n.tipoDocPago, n.NumeroDocumento, n.ImporteDesembolsado, n.ImporteDesembolsadoME, n.moneda).Distinct.ToList

                For Each i In listaDocs

                    If i.moneda = "1" Then
                        Dim VentaConPagosRelacionados = listaComprobantes.Where(Function(o) o.idDocumento = i.idDocumento).ToList
                        For Each doc In VentaConPagosRelacionados
                            Select Case doc.formapago
                                Case "109"
                                    efectivo = doc.montoSoles.GetValueOrDefault
                                Case "005", "006"
                                    tarjeta = doc.montoSoles.GetValueOrDefault
                                Case "007" 'CHEQUE
                                    cheque = doc.montoSoles.GetValueOrDefault
                                Case "001" 'DEPOSITO EN CUENTA
                                    Depositos = doc.montoSoles.GetValueOrDefault
                            End Select
                        Next
                        Dim sumaPagos = efectivo + tarjeta + cheque + Depositos
                        Dim saldoPorCobrar = i.ImporteDesembolsado - sumaPagos
                        dt.Rows.Add(i.NumeroDocumento, i.ImporteDesembolsado, efectivo, tarjeta, cheque, Depositos, sumaPagos, saldoPorCobrar)
                        efectivo = 0
                        tarjeta = 0
                        cheque = 0
                        Depositos = 0
                        sumaPagos = 0
                        saldoPorCobrar = 0
                    ElseIf i.moneda = "2" Then
                        Dim VentaConPagosRelacionados = listaComprobantes.Where(Function(o) o.idDocumento = i.idDocumento).ToList
                        For Each doc In VentaConPagosRelacionados
                            Select Case doc.formapago
                                Case "109"
                                    efectivo = doc.montoUsd.GetValueOrDefault
                                Case "005", "006"
                                    tarjeta = doc.montoUsd.GetValueOrDefault
                                Case "007" 'CHEQUE
                                    cheque = doc.montoUsd.GetValueOrDefault
                                Case "001" 'DEPOSITO EN CUENTA
                                    Depositos = doc.montoUsd.GetValueOrDefault
                            End Select
                        Next
                        Dim sumaPagos = efectivo + tarjeta + cheque + Depositos
                        Dim saldoPorCobrar = i.ImporteDesembolsadoME - sumaPagos
                        dt.Rows.Add(i.NumeroDocumento, i.ImporteDesembolsadoME, efectivo, tarjeta, cheque, Depositos, sumaPagos, saldoPorCobrar)
                        efectivo = 0
                        tarjeta = 0
                        cheque = 0
                        Depositos = 0
                        sumaPagos = 0
                        saldoPorCobrar = 0
                    End If


                Next
            End If
        End If
        GridComprobantes.DataSource = dt
    End Sub

    Private Sub GetDetalleComprobantesVendidos(IDCajaUsuario As Integer, fecha As Date?)

        Dim efectivo As Decimal = 0
        Dim tarjeta As Decimal = 0
        Dim cheque As Decimal = 0
        Dim Depositos As Decimal = 0

        Dim dt As New DataTable
        dt.Columns.Add("comprobante")
        dt.Columns.Add("numero")
        dt.Columns.Add("efectivo")
        dt.Columns.Add("tarjeta")
        dt.Columns.Add("cheque")
        dt.Columns.Add("cta")
        dt.Columns.Add("total")
        dt.Columns.Add("porCobrar")


        Dim listaComprobantes = documentocajaSA.GetMovimientosCajaComprobanteVentas(
           New Business.Entity.cajaUsuario With
           {
           .IDCajaUsuario = IDCajaUsuario,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .fechaCierre = fecha
           })

        If listaComprobantes IsNot Nothing Then
            If listaComprobantes.Count > 0 Then

                Dim listaDocs = (From n In listaComprobantes
                                 Select n.idDocumento, n.tipoDocPago, n.NumeroDocumento, n.ImporteDesembolsado, n.ImporteDesembolsadoME, n.moneda).Distinct.ToList

                For Each i In listaDocs

                    If i.moneda = "1" Then
                        Dim VentaConPagosRelacionados = listaComprobantes.Where(Function(o) o.idDocumento = i.idDocumento).ToList
                        For Each doc In VentaConPagosRelacionados
                            Select Case doc.formapago
                                Case "109"
                                    efectivo = doc.montoSoles.GetValueOrDefault
                                Case "005", "006"
                                    tarjeta = doc.montoSoles.GetValueOrDefault
                                Case "007" 'CHEQUE
                                    cheque = doc.montoSoles.GetValueOrDefault
                                Case "001" 'DEPOSITO EN CUENTA
                                    Depositos = doc.montoSoles.GetValueOrDefault
                            End Select
                        Next
                        Dim sumaPagos = efectivo + tarjeta + cheque + Depositos
                        Dim saldoPorCobrar = i.ImporteDesembolsado - sumaPagos
                        dt.Rows.Add(i.NumeroDocumento, i.ImporteDesembolsado, efectivo, tarjeta, cheque, Depositos, sumaPagos, saldoPorCobrar)
                        efectivo = 0
                        tarjeta = 0
                        cheque = 0
                        Depositos = 0
                        sumaPagos = 0
                        saldoPorCobrar = 0
                    ElseIf i.moneda = "2" Then
                        Dim VentaConPagosRelacionados = listaComprobantes.Where(Function(o) o.idDocumento = i.idDocumento).ToList
                        For Each doc In VentaConPagosRelacionados
                            Select Case doc.formapago
                                Case "109"
                                    efectivo = doc.montoUsd.GetValueOrDefault
                                Case "005", "006"
                                    tarjeta = doc.montoUsd.GetValueOrDefault
                                Case "007" 'CHEQUE
                                    cheque = doc.montoUsd.GetValueOrDefault
                                Case "001" 'DEPOSITO EN CUENTA
                                    Depositos = doc.montoUsd.GetValueOrDefault
                            End Select
                        Next
                        Dim sumaPagos = efectivo + tarjeta + cheque + Depositos
                        Dim saldoPorCobrar = i.ImporteDesembolsadoME - sumaPagos
                        dt.Rows.Add(i.NumeroDocumento, i.ImporteDesembolsadoME, efectivo, tarjeta, cheque, Depositos, sumaPagos, saldoPorCobrar)
                        efectivo = 0
                        tarjeta = 0
                        cheque = 0
                        Depositos = 0
                        sumaPagos = 0
                        saldoPorCobrar = 0
                    End If


                Next
            End If
        End If
        GridComprobantes.DataSource = dt


        ReporteDeCobros()

    End Sub

    Public Sub ReporteDeCobros()

        Dim totalventa As Decimal = 0
        Dim totalEfectivo As Decimal = 0
        Dim totalTarjeta As Decimal = 0
        Dim cuenta As Decimal = 0

        For Each r As Record In GridComprobantes.Table.Records

            totalventa += CDec(r.GetValue("numero"))
            totalEfectivo += CDec(r.GetValue("efectivo"))
            totalTarjeta += CDec(r.GetValue("tarjeta"))
            cuenta += CDec(r.GetValue("cta"))

        Next
        lblMasterTotalVenta.Text = totalventa
        lblMasterEfectivo.Text = totalEfectivo
        lblMasterDeposito.Text = totalTarjeta + cuenta
        lblMasterTarjeta.Text = cuenta

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


    Private Sub GetMovimientosDeCajaFormaPagoAdmi(IDCajaUsuario As Integer, fecha As Date?)

        Try


            listaMovimientosFormaPago = documentocajaSA.GetMovimientosFormaPagoCajeroMonedaAdmi(
         New Business.Entity.cajaUsuario With
         {
         .idcajaUsuario = IDCajaUsuario,
         .idEmpresa = Gempresas.IdEmpresaRuc,
         .idEstablecimiento = GEstableciento.IdEstablecimiento,
         .fechaCierre = fecha
         })

            ' listaMovimientosFormaPago = documentocajaSA.GetMovimientosFormaPagoCajero(
            'New Business.Entity.cajaUsuario With
            '{
            '.idcajaUsuario = IDCajaUsuario,
            '.idEmpresa = Gempresas.IdEmpresaRuc,
            '.idEstablecimiento = GEstableciento.IdEstablecimiento,
            '.fechaCierre = fecha
            '})

            'If listaMovimientos IsNot Nothing Or listaMovimientos.Count > 0 Then
            '    Dim ingresosTotal = listaMovimientos.Where(Function(o) tipoIngresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault

            '    Dim EgresosTotal = listaMovimientos.Where(Function(o) egresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault

            '    LabelTotalVentas.Text = $"S/{CDec(ingresosTotal).ToString("N2")}"
            '    LabelTotalGastos.Text = $"S/{CDec(EgresosTotal).ToString("N2")}"

            '    Dim saldo = (CDec(LabelFondoInicio.Text) + ingresosTotal) - EgresosTotal
            '    LabelTotalSaldo.Text = $"S/{CDec(saldo).ToString("N2")}"


            '    'LabelReclamacionClientes.Text = "0.00"
            'Else
            '    'lblventaElectronica.Text = "0.00"
            '    'lblventaNotas.Text = "0.00"
            '    'lblOtrasEntradasCaja.Text = "0.00"
            '    'lblPagosCobrados.Text = "0.00"
            '    'lblIngresoEspecial.Text = "0.00"
            '    'LabelPagoProveedor.Text = "0.00"
            '    'LabelOtrosEgresos.Text = "0.00"
            '    'LabelReclamacionClientes.Text = "0.00"
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetMovimientosDeCajaFormaPago(IDCajaUsuario As Integer, fecha As Date?)

        Try


            listaMovimientosFormaPago = documentocajaSA.GetMovimientosFormaPagoCajeroMoneda(
         New Business.Entity.cajaUsuario With
         {
         .IDCajaUsuario = IDCajaUsuario,
         .idEmpresa = Gempresas.IdEmpresaRuc,
         .idEstablecimiento = GEstableciento.IdEstablecimiento,
         .fechaCierre = fecha
         })

            ' listaMovimientosFormaPago = documentocajaSA.GetMovimientosFormaPagoCajero(
            'New Business.Entity.cajaUsuario With
            '{
            '.idcajaUsuario = IDCajaUsuario,
            '.idEmpresa = Gempresas.IdEmpresaRuc,
            '.idEstablecimiento = GEstableciento.IdEstablecimiento,
            '.fechaCierre = fecha
            '})

            'If listaMovimientos IsNot Nothing Or listaMovimientos.Count > 0 Then
            '    Dim ingresosTotal = listaMovimientos.Where(Function(o) tipoIngresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault

            '    Dim EgresosTotal = listaMovimientos.Where(Function(o) egresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault

            '    LabelTotalVentas.Text = $"S/{CDec(ingresosTotal).ToString("N2")}"
            '    LabelTotalGastos.Text = $"S/{CDec(EgresosTotal).ToString("N2")}"

            '    Dim saldo = (CDec(LabelFondoInicio.Text) + ingresosTotal) - EgresosTotal
            '    LabelTotalSaldo.Text = $"S/{CDec(saldo).ToString("N2")}"


            '    'LabelReclamacionClientes.Text = "0.00"
            'Else
            '    'lblventaElectronica.Text = "0.00"
            '    'lblventaNotas.Text = "0.00"
            '    'lblOtrasEntradasCaja.Text = "0.00"
            '    'lblPagosCobrados.Text = "0.00"
            '    'lblIngresoEspecial.Text = "0.00"
            '    'LabelPagoProveedor.Text = "0.00"
            '    'LabelOtrosEgresos.Text = "0.00"
            '    'LabelReclamacionClientes.Text = "0.00"
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub GetMovimientosDeCajaAdmi(IDCajaUsuario As Integer, fecha As Date?)
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
            ' listaMovimientos = documentocajaSA.GetMovimientosCajaCajero(
            'New Business.Entity.cajaUsuario With
            '{
            '.idcajaUsuario = IDCajaUsuario,
            '.idEmpresa = Gempresas.IdEmpresaRuc,
            '.idEstablecimiento = GEstableciento.IdEstablecimiento,
            '.fechaCierre = fecha
            '})


            listaMovimientos = documentocajaSA.GetMovimientosCajaCajeroTipoMonedaAdmi(
           New Business.Entity.cajaUsuario With
           {
           .idcajaUsuario = IDCajaUsuario,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .fechaCierre = fecha
           })

            If listaMovimientos IsNot Nothing Or listaMovimientos.Count > 0 Then
                Dim ingresosTotal = listaMovimientos.Where(Function(o) tipoIngresos.Contains(o.movimientoCaja) And o.moneda = "1").Sum(Function(o) o.montoSoles).GetValueOrDefault
                Dim ingresosTotalME = listaMovimientos.Where(Function(o) tipoIngresos.Contains(o.movimientoCaja) And o.moneda = "2").Sum(Function(o) o.montoUsd).GetValueOrDefault

                Dim EgresosTotal = listaMovimientos.Where(Function(o) egresos.Contains(o.movimientoCaja) And o.moneda = "1").Sum(Function(o) o.montoSoles).GetValueOrDefault
                Dim EgresosTotalME = listaMovimientos.Where(Function(o) egresos.Contains(o.movimientoCaja) And o.moneda = "2").Sum(Function(o) o.montoUsd).GetValueOrDefault

                LabelTotalVentas.Text = $"S/{CDec(ingresosTotal).ToString("N2")}"
                LabelTotalGastos.Text = $"S/{CDec(EgresosTotal).ToString("N2")}"
                LabelTotalVentasUSD.Text = $"${CDec(ingresosTotalME).ToString("N2")}"
                LabelTotalGastosUSD.Text = $"${CDec(EgresosTotalME).ToString("N2")}"

                Dim saldo = (CDec(LabelFondoInicio.Text) + ingresosTotal) - EgresosTotal
                LabelTotalSaldo.Text = $"S/{CDec(saldo).ToString("N2")}"

                'LabelFondoInicio.Text = $"S/{CDec(LabelFondoInicio.Text).ToString("N2")}"


                Dim saldoME = (CDec(LabelFondoInicioUSD.Text) + ingresosTotalME) - EgresosTotalME
                LabelTotalSaldoUSD.Text = $"${CDec(saldoME).ToString("N2")}"

                'LabelFondoInicioUSD.Text = $"${CDec(LabelFondoInicioUSD.Text).ToString("N2")}"

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

    Private Sub GetMovimientosDeCaja(IDCajaUsuario As Integer, fecha As Date?)
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
            ' listaMovimientos = documentocajaSA.GetMovimientosCajaCajero(
            'New Business.Entity.cajaUsuario With
            '{
            '.idcajaUsuario = IDCajaUsuario,
            '.idEmpresa = Gempresas.IdEmpresaRuc,
            '.idEstablecimiento = GEstableciento.IdEstablecimiento,
            '.fechaCierre = fecha
            '})


            listaMovimientos = documentocajaSA.GetMovimientosCajaCajeroTipoMoneda(
           New Business.Entity.cajaUsuario With
           {
           .IDCajaUsuario = IDCajaUsuario,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .fechaCierre = fecha
           })

            If listaMovimientos IsNot Nothing Or listaMovimientos.Count > 0 Then
                Dim ingresosTotal = listaMovimientos.Where(Function(o) tipoIngresos.Contains(o.movimientoCaja) And o.moneda = "1").Sum(Function(o) o.montoSoles).GetValueOrDefault
                Dim ingresosTotalME = listaMovimientos.Where(Function(o) tipoIngresos.Contains(o.movimientoCaja) And o.moneda = "2").Sum(Function(o) o.montoUsd).GetValueOrDefault

                Dim EgresosTotal = listaMovimientos.Where(Function(o) egresos.Contains(o.movimientoCaja) And o.moneda = "1").Sum(Function(o) o.montoSoles).GetValueOrDefault
                Dim EgresosTotalME = listaMovimientos.Where(Function(o) egresos.Contains(o.movimientoCaja) And o.moneda = "2").Sum(Function(o) o.montoUsd).GetValueOrDefault

                LabelTotalVentas.Text = $"S/{CDec(ingresosTotal).ToString("N2")}"
                LabelTotalGastos.Text = $"S/{CDec(EgresosTotal).ToString("N2")}"
                LabelTotalVentasUSD.Text = $"${CDec(ingresosTotalME).ToString("N2")}"
                LabelTotalGastosUSD.Text = $"${CDec(EgresosTotalME).ToString("N2")}"

                Dim saldo = (CDec(LabelFondoInicio.Text) + ingresosTotal) - EgresosTotal
                LabelTotalSaldo.Text = $"S/{CDec(saldo).ToString("N2")}"

                'LabelFondoInicio.Text = $"S/{CDec(LabelFondoInicio.Text).ToString("N2")}"


                Dim saldoME = (CDec(LabelFondoInicioUSD.Text) + ingresosTotalME) - EgresosTotalME
                LabelTotalSaldoUSD.Text = $"${CDec(saldoME).ToString("N2")}"

                'LabelFondoInicioUSD.Text = $"${CDec(LabelFondoInicioUSD.Text).ToString("N2")}"

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


    Private Sub GetMovimientosDeCajaDetalleOperacionesAdmi(IDCajaUsuario As Integer, fecha As Date?)
        'Dim tipoIngresos As New List(Of String)
        'tipoIngresos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        'tipoIngresos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        'tipoIngresos.Add("OEC")
        'tipoIngresos.Add(MovimientoCaja.CobroCliente)
        'tipoIngresos.Add(MovimientoCaja.Otras_Entradas_Especial)

        'Dim egresos As New List(Of String)
        'egresos.Add(MovimientoCaja.PagoProveedor)
        'egresos.Add("OSC")



        Try
            listaMovimientosOperaciones = documentocajaSA.GetMovimientosCajaCajeroDetalleAdmi(
           New Business.Entity.cajaUsuario With
           {
           .idcajaUsuario = IDCajaUsuario,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .fechaCierre = fecha
           })


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetMovimientosDeCajaDetalleOperaciones(IDCajaUsuario As Integer, fecha As Date?)
        'Dim tipoIngresos As New List(Of String)
        'tipoIngresos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        'tipoIngresos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        'tipoIngresos.Add("OEC")
        'tipoIngresos.Add(MovimientoCaja.CobroCliente)
        'tipoIngresos.Add(MovimientoCaja.Otras_Entradas_Especial)

        'Dim egresos As New List(Of String)
        'egresos.Add(MovimientoCaja.PagoProveedor)
        'egresos.Add("OSC")



        Try
            listaMovimientosOperaciones = documentocajaSA.GetMovimientosCajaCajeroDetalle(
           New Business.Entity.cajaUsuario With
           {
           .IDCajaUsuario = IDCajaUsuario,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .fechaCierre = fecha
           })


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetFormaPagoDetalleAdmi(IDCajaUsuario As Integer, fecha As Date?)
        'Dim tipoIngresos As New List(Of String)
        'tipoIngresos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        'tipoIngresos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        'tipoIngresos.Add("OEC")
        'tipoIngresos.Add(MovimientoCaja.CobroCliente)
        'tipoIngresos.Add(MovimientoCaja.Otras_Entradas_Especial)

        'Dim egresos As New List(Of String)
        'egresos.Add(MovimientoCaja.PagoProveedor)
        'egresos.Add("OSC")



        Try
            listaFormaPagoDetalleOperaciones = documentocajaSA.GetMovimientosFormaPagoCajeroDetalleAdmi(
           New Business.Entity.cajaUsuario With
           {
           .idcajaUsuario = IDCajaUsuario,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .fechaCierre = fecha
           })


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetFormaPagoDetalle(IDCajaUsuario As Integer, fecha As Date?)
        'Dim tipoIngresos As New List(Of String)
        'tipoIngresos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        'tipoIngresos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        'tipoIngresos.Add("OEC")
        'tipoIngresos.Add(MovimientoCaja.CobroCliente)
        'tipoIngresos.Add(MovimientoCaja.Otras_Entradas_Especial)

        'Dim egresos As New List(Of String)
        'egresos.Add(MovimientoCaja.PagoProveedor)
        'egresos.Add("OSC")



        Try
            listaFormaPagoDetalleOperaciones = documentocajaSA.GetMovimientosFormaPagoCajeroDetalle(
           New Business.Entity.cajaUsuario With
           {
           .IDCajaUsuario = IDCajaUsuario,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .fechaCierre = fecha
           })


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function UsuarioValidoPC() As cajaUsuario
        UsuarioValidoPC = New cajaUsuario
        UsuarioValidoPC = Nothing
        'Dim codigoVendedor = TextCodigoVendedor.Text.Trim
        'Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor And o.IDUsuario = usuario.IDUsuario).SingleOrDefault

        Dim shostname As String
        shostname = System.Net.Dns.GetHostName

        If usuario IsNot Nothing Then



            Dim cajaUsuario = cajaUsuaroSA.UbicarCajeroIDUsuarioActivaPC(New Business.Entity.cajaUsuario With
                                                                       {.idPersona = usuario.IDUsuario,
                                                                       .IDRol = usuario.IDRol,
                                                                       .tipoCaja = usuario.tipoCaja,
                                                                       .namepc = shostname,
                                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento})



            If cajaUsuario IsNot Nothing Then
                UsuarioValidoPC = cajaUsuario
            Else
                MessageBox.Show("No tiene una Caja activa en esta maquina para cerrar")
            End If







        End If

    End Function

    Private Function UsuarioValido() As cajaUsuario
        UsuarioValido = New cajaUsuario
        UsuarioValido = Nothing
        Dim codigoVendedor = TextCodigoVendedor.Text.Trim
        Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

        If usuarioSel IsNot Nothing Then
            Dim cajaUsuario = cajaUsuaroSA.UbicarCajeroIDUsuarioActiva(New Business.Entity.cajaUsuario With
                                                                       {.idPersona = usuarioSel.IDUsuario,
                                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento})

            If cajaUsuario IsNot Nothing Then
                UsuarioValido = cajaUsuario
            End If

        End If

    End Function
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





        If TextCodigoVendedor.Text.Trim.Length > 0 Then
            usuarioActivo = UsuarioValido()
            If usuarioActivo IsNot Nothing Then

                If usuarioActivo.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

                    GetFondoInicio(usuarioActivo.idcajaUsuario)
                    GetMovimientosDeCajaAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetMovimientosDeCajaDetalleOperacionesAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetMovimientosDeCajaFormaPagoAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetFormaPagoDetalleAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetDetalleComprobantesVendidosAdmi(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetDetalleFujoGeneral()
                    GetDetallFormaPago()
                    InitializeChart()
                    BunifuThinButton21.Visible = True
                    LabelUser.Visible = True
                    LabelUser.Text = $"{"Usuario"}-{usuarioActivo.NombrePersona}"

                ElseIf usuarioActivo.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then


                    GetFondoInicio(usuarioActivo.idcajaUsuario)
                    GetMovimientosDeCaja(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetMovimientosDeCajaDetalleOperaciones(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetMovimientosDeCajaFormaPago(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetFormaPagoDetalle(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetDetalleComprobantesVendidos(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                    GetDetalleFujoGeneral()
                    GetDetallFormaPago()
                    InitializeChart()
                    BunifuThinButton21.Visible = True
                    LabelUser.Visible = True
                    LabelUser.Text = $"{"Usuario"}-{usuarioActivo.NombrePersona}"
                End If


            Else
                LabelUser.Visible = False
                BunifuThinButton21.Visible = False
                gridGroupingControl1.DataSource = New DataTable
            End If
        End If

    End Sub

    Private Sub GetFondoInicio(idcajaUsuario As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioDetalleSA

        Dim detalle = cajaUsuarioSA.ListaDetallePorCaja(idcajaUsuario)

        Dim IniSoles = (From i In detalle Where i.moneda = "1").ToList
        Dim IniDolares = (From i In detalle Where i.moneda = "2").ToList



        If IniSoles.Count > 0 Then
            'LabelFondoInicio.Text = $"S/{detalle.Sum(Function(o) o.importeMN).GetValueOrDefault}"
            LabelFondoInicio.Text = IniSoles.Sum(Function(o) o.importeMN).GetValueOrDefault
        Else
            LabelFondoInicio.Text = "0.00"
        End If

        If IniDolares.Count > 0 Then
            'LabelFondoInicio.Text = $"S/{detalle.Sum(Function(o) o.importeMN).GetValueOrDefault}"
            LabelFondoInicioUSD.Text = IniDolares.Sum(Function(o) o.importeME).GetValueOrDefault
        Else
            LabelFondoInicioUSD.Text = "0.00"
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
        '  Label5.Text = "Resumen general de caja"
        chartControl1.Visible = False
        gridGroupingControl1.Visible = True
        GridFjloCajaDetalle.Visible = True
        GridFormaPago.Visible = False
        GridComprobantes.Visible = False
        GridFormaPagoDetalle.Visible = False
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        '   Label5.Text = "Diagrama de flujo"
        chartControl1.Visible = True
        GridFormaPago.Visible = False
        GridFjloCajaDetalle.Visible = False
        gridGroupingControl1.Visible = False
        GridComprobantes.Visible = False
        GridFormaPagoDetalle.Visible = False
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        If usuarioActivo IsNot Nothing Then
            If MessageBox.Show("Cerrar caja activa ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If GconfigCaja = "1" Then
                    GrabarCierre()
                ElseIf GconfigCaja = "2" Then
                    GrabarCierrePC()

                    If FormPurchase2 IsNot Nothing Then
                        FormPurchase2.CargarAlertaArqueo()
                    End If
                End If



            End If
        End If
    End Sub







    Private Sub GrabarCierrePC()
        Dim be As cajaUsuario
        Dim cajaSA As New cajaUsuarioSA
        Dim lista As New List(Of cajaUsuario)

        be = New cajaUsuario

        With be
            .namepc = usuarioActivo.namepc
            .idcajaUsuario = usuarioActivo.idcajaUsuario
            .fechaCierre = Date.Now
            .enUso = "N"
            .estadoCaja = "C"
            If usuario.tipoCaja = "ADM" Then  ' no tiene arqueo
                .idPadre = usuarioActivo.idcajaUsuario
            End If
            .otrosEgresosMN = 0 ' nudImporteEgresosmn.Value
            .otrosEgresosME = 0 ' nudImporteEgresosme.Value
            .ingresoAdicMN = 0 ' nudIngresoMN.Value
            .ingresoAdicME = 0 'nudIngresoME.Value
            .idCajaCierre = 0 ' txtCajaDestino.ValueMember
        End With
        lista.Add(be)

        cajaSA.CerrarCajasActivasPC(lista)

        MessageBox.Show("Caja cerrada con éxito!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        BunifuThinButton21.Visible = False
        LabelTotalVentas.Text = "S/0.00"
        LabelTotalGastos.Text = "S/0.00"
        LabelTotalSaldo.Text = "S/0.00"
        gridGroupingControl1.DataSource = New DataTable
        LabelUser.Visible = False
        LabelUser.Text = ""

        ListaCajasActivas = cajaSA.ListadoCajaXEstado(New cajaUsuario With {
                                                           .idEmpresa = Gempresas.IdEmpresaRuc,
                                                           .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                           .estadoCaja = "A"
                                                           })



        FormCierreXUsuario.CerrarFormulario()
    End Sub

    Private Sub GrabarCierre()
        Dim be As cajaUsuario
        Dim cajaSA As New cajaUsuarioSA
        Dim lista As New List(Of cajaUsuario)

        be = New cajaUsuario
        With be
            .idcajaUsuario = usuarioActivo.idcajaUsuario
            .fechaCierre = Date.Now
            .enUso = "N"
            .estadoCaja = "C"
            .otrosEgresosMN = 0 ' nudImporteEgresosmn.Value
            .otrosEgresosME = 0 ' nudImporteEgresosme.Value
            .ingresoAdicMN = 0 ' nudIngresoMN.Value
            .ingresoAdicME = 0 'nudIngresoME.Value
            .idCajaCierre = 0 ' txtCajaDestino.ValueMember
        End With
        lista.Add(be)

        cajaSA.CerrarCajasActivas(lista)

        MessageBox.Show("Caja cerrada con éxito!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        BunifuThinButton21.Visible = False
        LabelTotalVentas.Text = "S/0.00"
        LabelTotalGastos.Text = "S/0.00"
        LabelTotalSaldo.Text = "S/0.00"
        gridGroupingControl1.DataSource = New DataTable
        LabelUser.Visible = False
        LabelUser.Text = ""

        ListaCajasActivas = cajaSA.ListadoCajaXEstado(New cajaUsuario With {
                                                           .idEmpresa = Gempresas.IdEmpresaRuc,
                                                           .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                           .estadoCaja = "A"
                                                           })
    End Sub

    Private Sub TextCodigoVendedor_TextChanged(sender As Object, e As EventArgs) Handles TextCodigoVendedor.TextChanged

    End Sub

    Private Sub TextCodigoVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigoVendedor.KeyDown
        Try

            If TextCodigoVendedor.Text.Trim.Length > 0 Then
                If e.KeyCode = Keys.Enter Then

                    LabelFondoInicio.Text = "0.00"
                    LabelFondoInicioUSD.Text = "0.00"

                    Cursor = Cursors.WaitCursor
                    e.SuppressKeyPress = True

                    If GconfigCaja = "1" Then
                        usuarioActivo = UsuarioValido()
                    ElseIf GconfigCaja = "2" Then
                        usuarioActivo = UsuarioValidoPC()
                    End If

                    If usuarioActivo IsNot Nothing Then
                        GetFondoInicio(usuarioActivo.idcajaUsuario)
                        GetMovimientosDeCaja(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                        GetMovimientosDeCajaDetalleOperaciones(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                        GetMovimientosDeCajaFormaPago(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                        GetFormaPagoDetalle(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                        GetDetalleComprobantesVendidos(usuarioActivo.idcajaUsuario, txtFechaLaboral.Value)
                        GetDetalleFujoGeneral()
                        GetDetallFormaPago()
                        InitializeChart()
                        BunifuThinButton21.Visible = True
                        LabelUser.Visible = True
                        LabelUser.Text = $"{"Usuario"}-{usuarioActivo.NombrePersona}"
                    Else
                        MessageBox.Show("El usuario no registra un acaja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        LabelUser.Visible = False
                        BunifuThinButton21.Visible = False
                        gridGroupingControl1.DataSource = New DataTable
                    End If
                    Cursor = Cursors.Default
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles pictureBox2.Click

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        '     Label5.Text = "Reporte por forma de pago"
        chartControl1.Visible = False
        gridGroupingControl1.Visible = False
        GridFjloCajaDetalle.Visible = False
        GridFormaPago.Visible = True
        GridComprobantes.Visible = False
        GridFormaPagoDetalle.Visible = True
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        '    Label5.Text = "Reporte de comprobantes de venta"
        chartControl1.Visible = False
        gridGroupingControl1.Visible = False
        GridFjloCajaDetalle.Visible = False
        GridFormaPago.Visible = False
        GridComprobantes.Visible = True
        GridFormaPagoDetalle.Visible = False
    End Sub

    Private Sub GridGroupingControl2_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles GridFjloCajaDetalle.TableControlCellClick

    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick
        Dim movimientos As List(Of documentoCaja) = Nothing
        If gridGroupingControl1.Table.CurrentRecord Is Nothing Then Exit Sub
        Dim operacion = gridGroupingControl1.Table.CurrentRecord.GetValue("tipooper")
        Dim formaPago As String = String.Empty

        Dim dt As New DataTable
        dt.Columns.Add("idDoc")
        dt.Columns.Add("Comprobante")
        dt.Columns.Add("importe")
        dt.Columns.Add("formapago")

        Select Case operacion
            Case "VENTA ELECTRONICA PEN"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA And o.moneda = "1").ToList
            Case "VENTA ELECTRONICA USD"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA And o.moneda = "2").ToList
            Case "NOTAS PEN"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA And o.moneda = "1").ToList
            Case "NOTAS USD"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA And o.moneda = "2").ToList
            Case "OTROS INGRESOS DE CAJA"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = "OEC" And o.moneda = "1").ToList
            Case "OTROS INGRESOS DE CAJA USD"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = "OEC" And o.moneda = "2").ToList
            Case "COBROS A CLIENTES"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = MovimientoCaja.CobroCliente And o.moneda = "1").ToList
            Case "COBROS A CLIENTES USD"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = MovimientoCaja.CobroCliente And o.moneda = "2").ToList
            Case "INGRESO ESPECIAL"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = MovimientoCaja.Otras_Entradas_Especial And o.moneda = "1").ToList
            Case "INGRESO ESPECIAL USD"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = MovimientoCaja.Otras_Entradas_Especial And o.moneda = "2").ToList
            Case "PAGO A PROVEEDORES"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = MovimientoCaja.PagoProveedor And o.moneda = "1").ToList
            Case "PAGO A PROVEEDORES USD"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = MovimientoCaja.PagoProveedor And o.moneda = "2").ToList
            Case "OTROS GASTOS DE CAJA"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = "OSC" And o.moneda = "1").ToList
            Case "OTROS GASTOS DE CAJA USD"
                movimientos = listaMovimientosOperaciones.Where(Function(o) o.movimientoCaja = "OSC" And o.moneda = "2").ToList
        End Select
        If movimientos IsNot Nothing Or movimientos.Count > 0 Then
            For Each i In movimientos
                Select Case i.formapago
                    Case "109"
                        formaPago = "EFECTIVO"
                    Case "001"
                        formaPago = "DEPOSITO EN CUENTA"
                    Case "004"
                        formaPago = "ORDEN DE PAGO"
                    Case "005"
                        formaPago = "TARJETA DE DEBITO"
                    Case "006"
                        formaPago = "TARJETA DE CREDITO"
                    Case "007"
                        formaPago = "CHEQUES"
                End Select
                If i.moneda = "1" Then
                    dt.Rows.Add(i.idcosto, i.NumeroDocumento, i.montoSoles, formaPago)
                ElseIf i.moneda = "2" Then
                    dt.Rows.Add(i.idcosto, i.NumeroDocumento, i.montoUsd, formaPago)
                End If

            Next
        End If
        GridFjloCajaDetalle.DataSource = dt
    End Sub

    Private Sub GridFormaPago_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles GridFormaPago.TableControlCellClick
        Dim movimientos As List(Of documentoCaja) = Nothing
        If GridFormaPago.Table.CurrentRecord IsNot Nothing Then
            Dim formaPago = GridFormaPago.Table.CurrentRecord.GetValue("formapago")
            Dim tipomov As String = String.Empty

            Dim dt As New DataTable
            dt.Columns.Add("ef")
            dt.Columns.Add("nrocuenta")
            dt.Columns.Add("forma")
            dt.Columns.Add("monto")

            Select Case formaPago
                Case "EFECTIVO"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "109" And o.moneda = "1").ToList
                Case "EFECTIVO USD"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "109" And o.moneda = "2").ToList
                Case "DEPOSITO EN CUENTA"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "001" And o.moneda = "1").ToList
                Case "DEPOSITO EN CUENTA USD"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "001" And o.moneda = "2").ToList
                Case "ORDEN DE PAGO"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "004" And o.moneda = "1").ToList
                Case "ORDEN DE PAGO USD"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "004" And o.moneda = "2").ToList
                Case "TARJETA DE DEBITO"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "005" And o.moneda = "1").ToList
                Case "TARJETA DE DEBITO USD"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "005" And o.moneda = "2").ToList
                Case "TARJETA DE CREDITO"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "006" And o.moneda = "1").ToList
                Case "TARJETA DE CREDITO USD"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "006" And o.moneda = "2").ToList
                Case "CHEQUES"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "007" And o.moneda = "1").ToList
                Case "CHEQUES USD"
                    movimientos = listaFormaPagoDetalleOperaciones.Where(Function(o) o.formapago = "007" And o.moneda = "2").ToList
            End Select
            If movimientos IsNot Nothing Or movimientos.Count > 0 Then
                For Each i In movimientos
                    Select Case i.tipoMovimiento
                        Case "PG"
                            tipomov = "Gasto"
                            If i.moneda = "1" Then
                                dt.Rows.Add(i.entidadFinanciera, i.ctaCorrienteDeposito, tipomov, i.montoSoles * -1)
                            ElseIf i.moneda = "2" Then
                                dt.Rows.Add(i.entidadFinanciera, i.ctaCorrienteDeposito, tipomov, i.montoUsd * -1)
                            End If

                        Case "DC"
                            tipomov = "Ingreso"
                            If i.moneda = "1" Then
                                dt.Rows.Add(i.entidadFinanciera, i.ctaCorrienteDeposito, tipomov, i.montoSoles)
                            ElseIf i.moneda = "2" Then
                                dt.Rows.Add(i.entidadFinanciera, i.ctaCorrienteDeposito, tipomov, i.montoUsd)
                            End If
                    End Select
                Next
            End If
            GridFormaPagoDetalle.DataSource = dt
        End If

    End Sub

    Private Sub UCResumenVentas_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextCodigoVendedor.Select()
        TextCodigoVendedor.SelectAll()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

#End Region

End Class
