Imports Helios.Cont.Business.Entity
Imports ContSA = Helios.Cont.WCFService.ServiceAccess
Imports SegSA = Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Helios.Cont.WCFService.ServiceAccess

Public Class UCHistorialCajaUsuario
    Public listaMovimientos As List(Of documentoCaja)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid()
        GradientPanel1.Visible = False
        TextAnio.DecimalValue = Date.Now.Year
        'GetCombosLoad()
    End Sub

#Region "Formato GRID"
    Public Sub FormatoGrid()
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

    Private Sub GetCombosLoad()
        ComboUsuarios.DataSource = UsuariosList.Where(Function(O) O.TipoDocumento <> "SUPER").ToList
        ComboUsuarios.DisplayMember = "Full_Name"
        ComboUsuarios.ValueMember = "IDUsuario"

        cboMesCompra.DataSource = General.ListaDeMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.SelectedValue = String.Format("{0:00}", Date.Now.Month)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        CajaUsuarioSelUsuario(Integer.Parse(ComboUsuarios.SelectedValue))
        Cursor = Cursors.Default
    End Sub

    Private Sub CajaUsuarioSelUsuario(idPerson As Integer)
        Dim periodo = $"{String.Format("{0:00}", cboMesCompra.SelectedValue)}/{TextAnio.DecimalValue}"
        Dim cajaUsuarioSA As New ContSA.cajaUsuarioSA
        Dim listado = cajaUsuarioSA.CajaUsuarioSelPeriodo(New cajaUsuario With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .fechaRegistro = GetPeriodoConvertirToDate(periodo),
                                                          .idPersona = idPerson
                                                          }).OrderByDescending(Function(o) o.fechaRegistro).ToList


        ListViewHistorialCajas.Items.Clear()
        For Each i In listado
            Dim n As New ListViewItem(i.idcajaUsuario)
            n.SubItems.Add(i.fechaRegistro.GetValueOrDefault)
            n.SubItems.Add(i.fechaCierre.GetValueOrDefault)
            n.SubItems.Add(If(i.fechaCierre.HasValue, "CERRADO", "ABIERTO"))
            n.SubItems.Add("0.00")
            n.SubItems.Add("0.00")
            ListViewHistorialCajas.Items.Add(n)
        Next
        ListViewHistorialCajas.Refresh()
    End Sub

    Private Sub ComboUsuarios_Click(sender As Object, e As EventArgs) Handles ComboUsuarios.Click

    End Sub

    Private Sub ListViewHistorialCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewHistorialCajas.SelectedIndexChanged

    End Sub

    Private Sub ListViewHistorialCajas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewHistorialCajas.MouseDoubleClick
        Cursor = Cursors.WaitCursor
        If ListViewHistorialCajas.SelectedItems.Count > 0 Then
            Dim fecha = Date.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(1).Text)
            GetFondoInicio(Integer.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(0).Text))
            GetDetalleMovimientos(Integer.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(0).Text), fecha)
            GetDetalleFujoGeneral()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GetFondoInicio(idcajausuario As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioDetalleSA

        Dim detalle = cajaUsuarioSA.ListaDetallePorCaja(idcajausuario)

        Dim IniSoles = (From i In detalle Where i.moneda = "1").ToList
        Dim IniDolares = (From i In detalle Where i.moneda = "2").ToList

        If IniSoles.Count > 0 Then
            'LabelFondoInicio.Text = detalle.Sum(Function(o) o.importeMN).GetValueOrDefault
            LabelFondoInicio.Text = IniSoles.Sum(Function(o) o.importeMN).GetValueOrDefault
        Else
            LabelFondoInicio.Text = "0.00"
        End If


        If IniDolares.Count > 0 Then
            'LabelFondoInicio.Text = detalle.Sum(Function(o) o.importeMN).GetValueOrDefault
            LabelFondoInicioUSD.Text = IniDolares.Sum(Function(o) o.importeME).GetValueOrDefault
        Else
            LabelFondoInicioUSD.Text = "0.00"
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
        Else
            dt.Rows.Add("FONDO DE INICIO", "Ingreso", "0.00")
        End If

        If CDec(LabelFondoInicioUSD.Text) > 0 Then
            dt.Rows.Add("FONDO DE INICIO USD", "Ingreso", CDec(LabelFondoInicioUSD.Text))
        Else
            dt.Rows.Add("FONDO DE INICIO USD", "Ingreso", "0.00")
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
                    dt.Rows.Add("OTROS INGRESOS DE CAJA PEN", "Ingreso", otrasEntradas.montoSoles.GetValueOrDefault)
                Else
                    'lblOtrasEntradasCaja.Text = "0.00"
                    dt.Rows.Add("OTROS INGRESOS DE CAJA PEN", "Ingreso", "0.00")
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

    Private Sub GetDetalleMovimientos(IdCajaUsuario As Integer, fecha As Date)
        Dim documentocajaSA As New ContSA.DocumentoCajaSA
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
            '.idcajaUsuario = IdCajaUsuario,
            '.idEmpresa = Gempresas.IdEmpresaRuc,
            '.idEstablecimiento = GEstableciento.IdEstablecimiento,
            '.fechaCierre = fecha
            '})


            Dim sa As New ContSA.cajaUsuarioSA
            Dim CajaUser = sa.UbicarCajaUsuarioXID(IdCajaUsuario)

            If CajaUser.tipoCaja = Tipo_Caja.GENERAL Then
                listaMovimientos = documentocajaSA.GetMovimientosCajaCajeroTipoMonedaAdmi(
                   New Business.Entity.cajaUsuario With
                   {
                   .IdCajaUsuario = IdCajaUsuario,
                   .idEmpresa = Gempresas.IdEmpresaRuc,
                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                   .fechaCierre = fecha
                   })
            Else
                listaMovimientos = documentocajaSA.GetMovimientosCajaCajeroTipoMoneda(
                  New Business.Entity.cajaUsuario With
                  {
                  .IdCajaUsuario = IdCajaUsuario,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaCierre = fecha
                  })
            End If






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
                Dim saldoME = (CDec(LabelFondoInicioUSD.Text) + ingresosTotalME) - EgresosTotalME
                LabelTotalSaldo.Text = $"S/{CDec(saldo).ToString("N2")}"
                LabelTotalSaldoUSD.Text = $"${CDec(saldoME).ToString("N2")}"

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

    Private Sub UCHistorialCajaUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LabelTotalSaldo_Click(sender As Object, e As EventArgs) Handles LabelTotalSaldo.Click

    End Sub

    Private Sub LabelTotalGastos_Click(sender As Object, e As EventArgs) Handles LabelTotalGastos.Click

    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GetCombosLoad()
    End Sub
End Class
