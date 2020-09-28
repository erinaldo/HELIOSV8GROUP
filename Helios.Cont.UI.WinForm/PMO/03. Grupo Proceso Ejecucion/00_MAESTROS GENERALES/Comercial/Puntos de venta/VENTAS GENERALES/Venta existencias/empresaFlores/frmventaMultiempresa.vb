Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmventaMultiempresa
    Inherits frmMaster

    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Dim time As Integer = 0
    Public Property TieneCotizacionInfo() As Boolean
    Public Property IdDocumentoCotizacion() As Integer?
    Public Property ListadoProveedores As New List(Of entidad)
    Public Property listaServicio As New List(Of servicio)
    Dim saldoMN As Decimal
    Dim lblNumeroDoc As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Docking()
        GridCFG2(gridGroupingControl1)
        GridCFG(GridGroupingControl2)
        GridCFG(dgvCompra)
        GridCFGPagos(dgvPago1)
        GridCFGPagos(dgvPagos)
        Loadcontroles()
        configuracionInicio()
        GetTableGrid()
        cboServicio.SelectedValue = -1
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT1", Me.Text, GEstableciento.IdEstablecimiento)
        IdDocumentoCotizacion = Nothing
        CargarCajasTipo(usuario.IDUsuario)
        dgvPagos.DataSource = UbicarCajasHijas()
        dgvPago1.DataSource = UbicarCajasHijas()
        txtFiltrar.Select()
        dgvCompra.TableDescriptor.Columns("codBarra").ReadOnly = False
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean
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

    Sub GridCFGPagos(GGC As GridGroupingControl)
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
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways

        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None

        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left
        GGC.WantTabKey = True
        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

#Region "Cajas"

    Sub LimpiarlsvPagos(empresa As String)
        For Each i As ListViewItem In lsvPagosRegistrados.Items
            If i.SubItems(6).Text = empresa Then
                i.Remove()
            End If
        Next
    End Sub

    Sub AddSubitemPago(i As Record, valMN As Double, venta As Record)
        Dim oreg As New ListViewItem
        Dim tipoCambio As Decimal

        oreg = lsvPagosRegistrados.Items.Add(i.GetValue("pago"))
        oreg.SubItems.Add(i.GetValue("ef"))
        oreg.SubItems.Add(venta.GetValue("idProducto"))
        oreg.SubItems.Add(venta.GetValue("item"))
        oreg.SubItems.Add(valMN)
        tipoCambio = i.GetValue("tipocambio")
        'total = valMN / tipoCambi
        If (tipoCambio = 0) Then
            oreg.SubItems.Add((CDec(valMN / TmpTipoCambio)))
        Else

            oreg.SubItems.Add((CDec(valMN / tipoCambio)))
        End If
        'oreg.SubItems.Add(venta.GetValue("empresa"))
        'oreg.SubItems.Add(venta.GetValue("estable"))
        oreg.SubItems.Add(i.GetValue("empresa"))
        oreg.SubItems.Add(i.GetValue("estable")) ' establecimiento caja
        oreg.SubItems.Add(i.GetValue("idEntidad"))
        oreg.SubItems.Add(i.GetValue("moneda"))
        oreg.SubItems.Add(i.GetValue("tipocambio"))
        oreg.SubItems.Add(venta.GetValue("estable")) 'establecimiento venta
    End Sub

    Sub CalculosSubpago(r As Record) 'row de pagos de cuentas financieras
        Dim pago As Decimal = CType((r.GetValue("montoMN")), Decimal)
        'Dim pagoME As Double = CType(r.GetValue("montoME"), Double)
        'Dim pagoME As Double
        'Dim valVenta As Double = 0
        Dim saldo As Double = 0
        'Dim saldoME As Double = 0

        Dim saldoPago As Double = 0
        'Dim saldoPagoME As Double = 0

        For Each i In dgvCompra.Table.Records
            Dim saldoGeneral As Double = i.GetValue("pagado") '+ saldoPago
            'Dim saldoGeneralME As Double = i.GetValue("pagadoME") '+ saldoPago

            If i.GetValue("estado") = "NO" Then

                If pago <= 0 Then
                    i.SetValue("estado", "NO")
                    i.SetValue("pagado", CType(i.GetValue("totalmn"), Double))
                    'i.SetValue("pagadoME", CType(i.GetValue("totalme"), Double))
                    Exit For
                End If

                If saldoGeneral >= pago Then
                    If saldoGeneral > 0 Then
                        AddSubitemPago(r, pago, i)
                    End If

                Else
                    If saldoGeneral > 0 Then
                        AddSubitemPago(r, saldoGeneral, i)
                    End If

                End If

                If pago >= saldoGeneral Then
                    i.SetValue("estado", "SI")
                    'pago = pago - saldoGeneral
                Else
                    i.SetValue("estado", "NO")
                    'pago = pago - saldoGeneral
                End If

                saldoPago = saldoGeneral - pago
                'saldoPagoME = saldoGeneralME - pagoME

                saldo = saldoGeneral - pago
                'saldoME = saldoGeneralME - pagoME

                If saldo <= 0 Then
                    'i.SetValue("estado", "SI")
                    i.SetValue("pagado", 0)
                    'i.SetValue("pagadoME", 0)
                Else
                    'i.SetValue("estado", "NO")
                    If saldo.ToString.Length > 3 Then
                        i.SetValue("pagado", (saldo))
                        'i.SetValue("pagadoME", Math.Round(saldoME, 2))
                    Else
                        i.SetValue("pagado", saldo)
                        'i.SetValue("pagadoME", saldoME)
                    End If
                End If

                pago = pago - saldoGeneral
                'pagoME = (pago * txtTipoCambio.Value)
            End If
        Next
    End Sub
    Sub CalculoPagos()
        For Each i In dgvCompra.Table.Records
            If i.GetValue("empresa") = "20111444444" Then
                i.SetValue("estado", "NO")
                i.SetValue("pagado", i.GetValue("totalmn"))
            End If
        Next

        For Each i As Record In dgvPagos.Table.Records
            '  If i.GetValue("empresa") = "20111444444" Then
            If CDbl(i.GetValue("montoMN")) > 0 Then
                CalculosSubpago(i)
            End If
            '    End If

        Next

    End Sub

    Sub CalculoPagosE1()
        For Each i In dgvCompra.Table.Records
            If i.GetValue("empresa") = "20392657020" Then
                i.SetValue("estado", "NO")
                i.SetValue("pagado", i.GetValue("totalmn"))
            End If
        Next

        For Each i As Record In dgvPago1.Table.Records
            '   If i.GetValue("empresa") = "20392657020" Then
            If CDbl(i.GetValue("montoMN")) > 0 Then
                CalculosSubpago(i)
                'End If
            End If
        Next

    End Sub

    Public Function UbicarCajasHijas() As DataTable

        Dim dt As New DataTable
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("ef")
        dt.Columns.Add("pago")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("montoMN", GetType(Double))
        dt.Columns.Add("montoME", GetType(Double))
        dt.Columns.Add("total", GetType(Double))
        dt.Columns.Add("importePendiente", GetType(Decimal))
        dt.Columns.Add("vueltoMN", GetType(Decimal))
        dt.Columns.Add("vueltoME", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("estable", GetType(Integer))

        Return dt
    End Function

    Sub GridPago(cajaBE As cajaUsuario)

        Dim cuentaUsuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim contador As Integer = 0
        Dim saldooagado As Integer = 0
        Dim contadorMon As Integer = 0
        For Each i In dgvPagos.Table.Records
            If (i.GetValue("idEntidad") = cajaBE.idEntidad) Then
                contador += 1
            End If
            If (dgvPagos.Table.Records.Count > 1) Then
                If (i.GetValue("saldo") = 0) Then
                    saldooagado = 1
                End If
            End If
            If (i.GetValue("moneda") = "EXTRANJERO") Then
                contadorMon = 1
            End If

        Next

        If (contador = 0) Then


            If Not IsNothing(cajaBE) Then
                If (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0) '5
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                    If (contadorMon = 1) Then
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 90
                    Else
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 0
                    End If

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50
                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 90

                    If (contadorMon = 1) Then
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 90
                    Else
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 0
                    End If




                    Me.dgvPagos.Table.AddNewRecord.EndEdit()

                ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Banco) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "BANCO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    If (contadorMon = 1) Then
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 90
                    Else
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 0
                    End If
                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Banco) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "BANCO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50
                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 90
                    If (contadorMon = 1) Then
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90
                    Else
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 0
                    End If

                    'Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

                    'Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                    'Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    'Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    If (contadorMon = 1) Then
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90
                    Else
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 0
                    End If
                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50
                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 90
                    If (contadorMon = 1) Then
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 90
                    Else
                        Me.dgvPagos.TableDescriptor.Columns("saldo").Width = 0
                    End If



                    Me.dgvPagos.Table.AddNewRecord.EndEdit()

                End If
            End If


            'If (saldooagado = 0) Then


            'Else
            '    PanelError.Visible = True
            '    lblEstado.Text = "Ya realizo todo el pago!"
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            'End If

        Else
            PanelError.Visible = True
            lblEstado.Text = "ya existe una entidad financiera!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If


    End Sub

    Sub GridPago1(cajaBE As cajaUsuario, dgvPagos As GridGroupingControl)

        Dim cuentaUsuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim contador As Integer = 0
        Dim saldooagado As Integer = 0
        Dim contadorMon As Integer = 0
        For Each i In dgvPago1.Table.Records
            If (i.GetValue("idEntidad") = cajaBE.idEntidad) Then
                contador += 1
            End If
            If (dgvPago1.Table.Records.Count > 1) Then
                If (i.GetValue("saldo") = 0) Then
                    saldooagado = 1
                End If
            End If
            If (i.GetValue("moneda") = "EXTRANJERO") Then
                contadorMon = 1
            End If

        Next

        If (contador = 0) Then


            If Not IsNothing(cajaBE) Then
                If (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPago1.Table.AddNewRecord.SetCurrent()
                    Me.dgvPago1.Table.AddNewRecord.BeginEdit()
                    Me.dgvPago1.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPago1.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPago1.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0) '5
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPago1.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 0
                    If (contadorMon = 1) Then
                        Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 50
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 90
                    Else
                        Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 0
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 0
                    End If

                    Me.dgvPago1.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPago1.Table.AddNewRecord.SetCurrent()
                    Me.dgvPago1.Table.AddNewRecord.BeginEdit()
                    Me.dgvPago1.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPago1.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPago1.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPago1.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 50
                    Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                    Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 90

                    If (contadorMon = 1) Then
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 50
                        Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 90
                    Else
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 0
                    End If




                    Me.dgvPago1.Table.AddNewRecord.EndEdit()

                ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Banco) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPago1.Table.AddNewRecord.SetCurrent()
                    Me.dgvPago1.Table.AddNewRecord.BeginEdit()
                    Me.dgvPago1.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPago1.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPago1.Table.CurrentRecord.SetValue("pago", "BANCO")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPago1.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    If (contadorMon = 1) Then
                        Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 50
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 90
                    Else
                        Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 0
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 0
                    End If
                    Me.dgvPago1.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Banco) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPago1.Table.AddNewRecord.SetCurrent()
                    Me.dgvPago1.Table.AddNewRecord.BeginEdit()
                    Me.dgvPago1.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPago1.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPago1.Table.CurrentRecord.SetValue("pago", "BANCO")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPago1.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 50
                    Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                    Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 90
                    If (contadorMon = 1) Then
                        Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 90
                    Else
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 0
                    End If

                    'Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 50

                    'Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                    'Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                    'Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 90

                    Me.dgvPago1.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPago1.Table.AddNewRecord.SetCurrent()
                    Me.dgvPago1.Table.AddNewRecord.BeginEdit()
                    Me.dgvPago1.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPago1.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPago1.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPago1.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    If (contadorMon = 1) Then
                        Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 90
                    Else
                        Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 0
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 0
                    End If
                    Me.dgvPago1.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPago1.Table.AddNewRecord.SetCurrent()
                    Me.dgvPago1.Table.AddNewRecord.BeginEdit()
                    Me.dgvPago1.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPago1.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPago1.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPago1.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPago1.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("empresa", cajaBE.idEmpresa) '10
                    Me.dgvPago1.Table.CurrentRecord.SetValue("estable", cajaBE.idEstablecimiento) '10
                    Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 50
                    Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                    Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 90
                    If (contadorMon = 1) Then
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 50
                        Me.dgvPago1.TableDescriptor.Columns("montoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("tipocambio").Width = 90
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 90
                    Else
                        Me.dgvPago1.TableDescriptor.Columns("saldo").Width = 0
                    End If



                    Me.dgvPago1.Table.AddNewRecord.EndEdit()

                End If
            End If


            'If (saldooagado = 0) Then


            'Else
            '    PanelError.Visible = True
            '    lblEstado.Text = "Ya realizo todo el pago!"
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            'End If

        Else
            PanelError.Visible = True
            lblEstado.Text = "ya existe una entidad financiera!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If


    End Sub
#End Region


    ''' <summary>
    ''' Listado de Cajas Habilitadas por el usuario
    ''' </summary>
    ''' <remarks></remarks>
    Dim cajausuario As New List(Of cajaUsuario)
    Public Sub CargarCajasTipo(idpersona As Integer)
        Dim cajausuariosa As New cajaUsuarioSA
        Dim cuentaUsuarioDetalleSA As New cajaUsuarioSA

        Try
            Dim idCajaUsuario = cuentaUsuarioDetalleSA.UbicarUsuarioAbierto(usuario.IDUsuario).idcajaUsuario

            cajausuario = cajausuariosa.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = idCajaUsuario, .idPersona = idpersona})

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarPrecios()
        Dim precioSA As New ConfiguracionPrecioSA
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("cboprecio").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = precioSA.ListadoPrecios()
        ggcStyle.ValueMember = "idPrecio"
        ggcStyle.DisplayMember = "precio"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Public Sub UbicarDocumentoCotizacionDetails(intIdDocumento As Integer)
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0

        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA

        For Each i In objDocCompraDet.usp_EditarDetalleVenta(intIdDocumento)
            colBI = 0
            colBIme = 0

            Igv = 0
            IgvME = 0

            Select Case i.destino
                Case "1"
                    colBI = CDec(i.importeMN) / 1.18
                    colBIme = CDec(i.importeME) / 1.18

                    Igv = colBI * (TmpIGV / 100)
                    IgvME = colBIme * (TmpIGV / 100)

                Case "2"
                    colBI = i.importeMN
                    colBIme = i.importeME

                    Igv = 0
                    IgvME = 0
            End Select



            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", i.stock)

            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        TotalTalesXcolumna()
    End Sub

    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal

        Public Property BaseMN2() As Decimal
        Public Property BaseME2() As Decimal

        Public Property BaseMN3() As Decimal
        Public Property BaseME3() As Decimal

        Public Property IgvMN() As Decimal
        Public Property IgvME() As Decimal
        Public Property TotalMN() As Decimal
        Public Property TotalME() As Decimal

        Public Property base1() As Decimal
        Public Property base1me() As Decimal
        Public Property base2() As Decimal
        Public Property base2me() As Decimal
        Public Property MontoIgv1() As Decimal
        Public Property MontoIgv1me() As Decimal
        Public Property MontoIgv2() As Decimal
        Public Property MontoIgv2me() As Decimal

        Public Property PercepcionMN() As Decimal
        Public Property PercepcionME() As Decimal

        Public Sub New()
            BaseMN = 0
            BaseME = 0
            BaseMN2 = 0
            BaseME2 = 0
            BaseMN3 = 0
            BaseME3 = 0
            IgvMN = 0
            IgvME = 0
            TotalMN = 0
            TotalME = 0
            base1 = 0
            base1me = 0
            base2 = 0
            base2me = 0
            MontoIgv1 = 0
            MontoIgv1me = 0
            MontoIgv2 = 0
            MontoIgv2me = 0
            PercepcionMN = 0
            PercepcionME = 0
        End Sub


    End Class

    Public Function TieneCuentaFinanciera() As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA
        Dim valBool As Boolean = False

        GFichaUsuarios = New GFichaUsuario

        If IsNothing(GFichaUsuarios.NombrePersona) Then
            With frmFichaUsuarioCaja
                ModuloAppx = ModuloSistema.CAJA
                .lblNivel.Text = "Caja"
                .lblEstadoCaja.Visible = True
                '.GroupBox1.Visible = True
                '.GroupBox2.Visible = True
                '.GroupBox4.Visible = True
                '.cboMoneda.Visible = True
                .Timer1.Enabled = True
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    valBool = False
                    '   Return False
                Else
                    valBool = True
                    '   Return True
                End If
            End With
        End If
        Return valBool
    End Function

    Private Sub Docking()

        ' Me.dockingManager1.DockControl(Me.PanelMontos, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 152)

        Me.dockingManager1.DockControlInAutoHideMode(Me.PanelCanasta, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 460)
        'dockingManager1.DockControlInAutoHideMode(PanelCanasta, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        Me.dockingManager1.DockControl(Me.Panel5, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)
        dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        dockingManager1.DockControlInAutoHideMode(PanelPagos, Syncfusion.Windows.Forms.Tools.DockingStyle.Top, 120)

        DockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        dockingManager1.SetDockLabel(PanelCanasta, "Canasta de Inventario")
        dockingManager1.SetDockLabel(Panel5, "Servicios")
        dockingManager1.SetDockLabel(PanelPagos, "Resumen pagos")
        '    dockingManager1.SetDockLabel(PanelMontos, "Importes del Comprobante")
        dockingManager1.CloseEnabled = False
    End Sub

    Sub ConfiguracionInicio()
        'Me.WindowState = FormWindowState.Maximized
        TotalesXcanbeceras = New TotalesXcanbecera()
        Dim almacenSA As New almacenSA
        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen

        'If Not IsNothing(GFichaUsuarios) Then
        '    ToolStripButton1.Image = ImageListAdv1.Images(1)
        '    dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'Else
        dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'ToolStripButton1.Image = ImageListAdv1.Images(0)
        'GFichaUsuarios = Nothing
        'End If

        'confgiurando variables generales
        '   txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        lblPerido.Text = PeriodoGeneral
        txtTipoCambio.DecimalValue = TmpTipoCambio

        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Dim colorx As New GridMetroColors()
#Region "Métodos"
    Public Sub GetExistenciaByCodigoBar(CodigoBarra As String)
        Dim totalSA As New TotalesAlmacenSA
        'Dim existenciaSA As New detalleitemsSA
        'Dim existencia As New detalleitems

        'existencia = existenciaSA.GetExistenciaByCodeBar(CodigoBarra)
        Dim lista = totalSA.GetProductosByAlmacenCodigo(0, CodigoBarra)


        GetListaProductosEmpresaByCodigoBarra(lista)

        If gridGroupingControl1.Table.Records.Count > 0 Then
            gridGroupingControl1.Table.Records(0).SetCurrent()
            gridGroupingControl1.Table.Records(0).SetSelected(True)


            UbicarUltimosPreciosXproducto(gridGroupingControl1.Table.Records(0))

            If GridGroupingControl2.Table.Records.Count > 0 Then
                GridGroupingControl2.Table.Records(0).SetCurrent()
                GridGroupingControl2.Table.Records(0).SetSelected(True)

                If ChDirecto.Checked = True Then
                    AgregarAcanasta(gridGroupingControl1.Table.CurrentRecord)
                End If

            End If

        End If


        'If Not IsNothing(existencia) Then
        '    txtProdFind.Text = existencia.descripcionItem
        '    txtProdFind.Tag = existencia.codigodetalle

        '    'ObtenerExistenciaByCode(CboAlmacen.SelectedValue, existencia.codigodetalle)
        '    If gridGroupingControl1.Table.Records.Count > 0 Then
        '        gridGroupingControl1.Table.Records(0).SetCurrent()
        '        gridGroupingControl1.Table.Records(0).SetSelected(True)

        '        UbicarUltimosPreciosXproducto(gridGroupingControl1.Table.Records(0))

        '    End If
        '    txtBarCode.Clear()
        '    txtBarCode.Select()
        '    'UbicarUltimosPreciosXproductoBarCode(existencia.codigodetalle)
        'Else
        '    'MessageBox.Show("No se encontro un artículo con este código!")
        'End If
    End Sub

    Public Sub UbicarUltimosPreciosXproductoBarCode(intIdItem As Integer)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdItem)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl2.DataSource = dt
        GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub UbicarUltimosPreciosXproducto(r As Record)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl2.DataSource = dt
        GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub UbicarUltimosPreciosServicio(intIdServicio As Integer)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdServicio)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        dgvPreciosServicio.DataSource = dt
        dgvPreciosServicio.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle

        Try
            DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            If Not IsNothing(DocumentoGuia) Then
                With DocumentoGuia
                    txtSerieGuia.Text = .Serie
                    txtNumeroGuia.Text = .Numero
                End With
            End If

            'CABECERA COMPROBANTE
            With objDocCompra.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
                txtFecha.Value = .fechaDoc
                PeriodoGeneral = .fechaPeriodo
                cboTipoDoc.SelectedValue = .tipoDocumento
                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

                        cboMoneda.SelectedValue = 1
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                        cboMoneda.SelectedValue = 2
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idCliente).FirstOrDefault
                If Not IsNothing(nEntidad) Then
                    txtRuc.Text = nEntidad.nrodoc
                    txtCliente2.Tag = nEntidad.idEntidad
                    txtCliente2.Text = nEntidad.nombreCompleto
                Else

                End If

                TXTcOMPRADOR.Text = .nombrePedido

                txtTipoCambio.DecimalValue = .tipoCambio
                txtIva.DoubleValue = .tasaIgv / 100
                '       txtGlosa.Text = .glosa
            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            PanelCanasta.Visible = False
            Panel5.Visible = False
            For Each i In objDocCompraDet.usp_EditarDetalleVenta(intIdDocumento)

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", i.stock)

                'Select Case i.estadoPago
                '    Case TIPO_VENTA.PAGO.COBRADO
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
                '    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
                'End Select

                'Select Case i.bonificacion
                '    Case "S"
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", True)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "S")
                '    Case "N"
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                'End Select

                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            btGrabar.Enabled = False
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub


    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        grid.TableOptions.SelectionBackColor = Color.Gray
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFG2(GGC As GridGroupingControl)
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

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim almacenSA As New almacenSA
        Dim entidadSA As New entidadSA
        Dim servicioSA As New servicioSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0


        'listaServicio.Clear()
        'listaServicio = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = Nothing, .idPadre = 1015})
        'cboServicio.DisplayMember = "descripcion"
        'cboServicio.ValueMember = "idServicio"
        'cboServicio.DataSource = listaServicio


        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetUbicarTablaexistencia

        'ListadoProveedores = New List(Of entidad)
        'ListadoProveedores = entidadSA.ObtenerListaEntidad(TIPO_ENTIDAD.CLIENTE, Gempresas.IdEmpresaRuc)

    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idProducto", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("um", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("vcmn", GetType(Decimal))
        dt.Columns.Add("pcmn", GetType(Decimal))
        dt.Columns.Add("totalmn", GetType(Decimal))
        dt.Columns.Add("vcme", GetType(Decimal))
        dt.Columns.Add("pcme", GetType(Decimal))
        dt.Columns.Add("totalme", GetType(Decimal))
        dt.Columns.Add("igvmn", GetType(Decimal))
        dt.Columns.Add("igvme", GetType(Decimal))

        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("marca", GetType(String))
        dt.Columns.Add("almacen", GetType(String))
        dt.Columns.Add("caja", GetType(String))

        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("chPago", GetType(Boolean))
        dt.Columns.Add("valPago", GetType(String))

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))
        dt.Columns.Add("presentacion", GetType(String))

        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("puKardex", GetType(Decimal))
        dt.Columns.Add("pukardeme", GetType(Decimal))
        dt.Columns.Add("canDisponible", GetType(Decimal))
        dt.Columns.Add("costoMN", GetType(Decimal))
        dt.Columns.Add("costoME", GetType(Decimal))
        dt.Columns.Add("tipoPrecio", GetType(String))
        dt.Columns.Add("cat", GetType(Integer))
        dt.Columns.Add("codBarra", GetType(String))
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("cboprecio", GetType(String))
        dt.Columns.Add("pagado")
        dt.Columns.Add("estado")
        dt.Columns.Add("estable")
        dgvCompra.DataSource = dt
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtCliente2.Text = .nombreCompleto
                txtCliente2.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
                txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            txtCliente2.Clear()
            '  txtCuenta.Clear()
            txtRuc.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub

    Sub TotalTalesXcolumna()
        Dim totalpercepMN As Decimal = 0
        Dim totalpercepME As Decimal = 0

        'VC01
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        'VC02
        Dim totalVC2 As Decimal = 0
        Dim totalVCme2 As Decimal = 0

        'VC03
        Dim totalVC3 As Decimal = 0
        Dim totalVCme3 As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        For Each r As Record In dgvCompra.Table.Records
            totalpercepMN += CDec(r.GetValue("percepcionMN"))
            totalpercepME += CDec(r.GetValue("percepcionME"))

            'If r.GetValue("valBonif") = "S" Then
            '    totalDesc += CDec(r.GetValue("igvmn"))
            '    totalDescme += CDec(r.GetValue("igvme"))
            'Else

            Select Case r.GetValue("gravado")
                Case OperacionGravada.Grabado
                    totalVC += CDec(r.GetValue("vcmn"))
                    totalVCme += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Exonerado
                    totalVC2 += CDec(r.GetValue("vcmn"))
                    totalVCme2 += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Inafecto
                    totalVC3 += CDec(r.GetValue("vcmn"))
                    totalVCme3 += CDec(r.GetValue("vcme"))
            End Select



            totalIVA += CDec(r.GetValue("igvmn"))
            totalIVAme += CDec(r.GetValue("igvme"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))
            'End If

            Select Case r.GetValue("gravado")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    igv1 += CDec(r.GetValue("igvmn"))
                    igv1me += CDec(r.GetValue("igvme"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    igv2 += CDec(r.GetValue("igvmn"))
                    igv2me += CDec(r.GetValue("igvme"))
            End Select




        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.PercepcionMN = totalpercepMN
        TotalesXcanbeceras.PercepcionME = totalpercepME

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.BaseMN2 = totalVC2
        TotalesXcanbeceras.BaseME2 = totalVCme2

        TotalesXcanbeceras.BaseMN3 = totalVC3
        TotalesXcanbeceras.BaseME3 = totalVCme3

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        '****************************************************
        If cboMoneda.SelectedValue = 1 Then
            txtTotalBase3.DecimalValue = totalVC3
            txtTotalBase2.DecimalValue = totalVC2
            txtTotalBase.DecimalValue = totalVC
            txtTotalIva.Text = (CDec(totalIVA))
            'Label4.Text = Decimal.Round(totalIVA)
            'Button1.Text = (CDec(totalIVA))
            txtTotalPagar.DecimalValue = total
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        Else
            txtTotalBase3.DecimalValue = totalVCme3
            txtTotalBase2.DecimalValue = totalVCme2
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar.DecimalValue = totalme
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        End If


    End Sub

    Sub TotalTalesXcolumnaByEmpresa(empresa As String)
        Dim totalpercepMN As Decimal = 0
        Dim totalpercepME As Decimal = 0

        'VC01
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        'VC02
        Dim totalVC2 As Decimal = 0
        Dim totalVCme2 As Decimal = 0

        'VC03
        Dim totalVC3 As Decimal = 0
        Dim totalVCme3 As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        For Each r As Record In dgvCompra.Table.Records

            If r.GetValue("empresa") = empresa Then
                totalpercepMN += CDec(r.GetValue("percepcionMN"))
                totalpercepME += CDec(r.GetValue("percepcionME"))


                Select Case r.GetValue("gravado")
                    Case OperacionGravada.Grabado
                        totalVC += CDec(r.GetValue("vcmn"))
                        totalVCme += CDec(r.GetValue("vcme"))

                    Case OperacionGravada.Exonerado
                        totalVC2 += CDec(r.GetValue("vcmn"))
                        totalVCme2 += CDec(r.GetValue("vcme"))

                    Case OperacionGravada.Inafecto
                        totalVC3 += CDec(r.GetValue("vcmn"))
                        totalVCme3 += CDec(r.GetValue("vcme"))
                End Select

                totalIVA += CDec(r.GetValue("igvmn"))
                totalIVAme += CDec(r.GetValue("igvme"))

                total += CDec(r.GetValue("totalmn"))
                totalme += CDec(r.GetValue("totalme"))

                Select Case r.GetValue("gravado")
                    Case "1"
                        bs1 += CDec(r.GetValue("vcmn"))
                        bs1me += CDec(r.GetValue("vcme"))

                        igv1 += CDec(r.GetValue("igvmn"))
                        igv1me += CDec(r.GetValue("igvme"))
                    Case "2"
                        bs2 += CDec(r.GetValue("vcmn"))
                        bs2me += CDec(r.GetValue("vcme"))

                        igv2 += CDec(r.GetValue("igvmn"))
                        igv2me += CDec(r.GetValue("igvme"))
                End Select

            End If
        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.PercepcionMN = totalpercepMN
        TotalesXcanbeceras.PercepcionME = totalpercepME

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.BaseMN2 = totalVC2
        TotalesXcanbeceras.BaseME2 = totalVCme2

        TotalesXcanbeceras.BaseMN3 = totalVC3
        TotalesXcanbeceras.BaseME3 = totalVCme3

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        '****************************************************
        If cboMoneda.SelectedValue = 1 Then

            Select Case empresa
                Case "20392657020"
                    txtTotalBase3.DecimalValue = totalVC3
                    txtTotalBase2.DecimalValue = totalVC2
                    txtTotalBase.DecimalValue = totalVC
                    txtTotalIva.Text = (CDec(totalIVA))
                  
                    txtTotalPagar.DecimalValue = total
                    lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN
                Case "20111444444"

                    txtInafectaE1.DecimalValue = totalVC3
                    txtExoE1.DecimalValue = totalVC2
                    txtOperGravE1.DecimalValue = totalVC
                    txtIvaE1.Text = (CDec(totalIVA))
              
                    txtTotalE1.DecimalValue = total
                    '  lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN
            End Select

          

        Else
            txtTotalBase3.DecimalValue = totalVCme3
            txtTotalBase2.DecimalValue = totalVCme2
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar.DecimalValue = totalme
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        End If


    End Sub

    Sub CalculosByEmpresa(empresa As String)
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0

        Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Select Case strTipoExistencia
            Case "GS"
                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
                totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

                If colDestinoGravado = 1 Then
                    Dim iva As Decimal = TmpIGV / 100
                    colBI = (totalMN / (iva + 1))
                    colBIme = (totalME / (iva + 1))

                    Dim iv As Decimal = 0
                    Dim iv2 As Decimal = 0
                    iv = totalMN / (iva + 1)
                    iv2 = totalME / (iva + 1)

                    Igv = iv * (iva)
                    IgvME = iv2 * (iva)
                Else

                    colBI = 0
                    colBIme = 0
                    Igv = 0
                    IgvME = 0

                End If

                '****************************************************************

                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                If colcantidad > 0 Then



                    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                Else

                End If

                Select Case colDestinoGravado
                    Case 1
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    Case 2
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                End Select
                TotalTalesXcolumnaByEmpresa(Me.dgvCompra.Table.CurrentRecord.GetValue("empresa"))
            Case Else
                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = colcantidad * colPrecUnitAlmacen
                    colCostoME = colcantidad * colPrecUnitUSAlmacen

                    totalMN = colcantidad * colPrecUnit
                    totalME = colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    Dim iva As Decimal = TmpIGV / 100

                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then

                        colBI = (totalMN / (iva + 1))
                        colBIme = (totalME / (iva + 1))

                        Dim iv As Decimal = 0
                        Dim iv2 As Decimal = 0
                        iv = totalMN / (iva + 1)
                        iv2 = totalME / (iva + 1)

                        Igv = iv * (iva)
                        IgvME = iv2 * (iva)

                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If

                    Select Case colDestinoGravado
                        Case 1
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumnaByEmpresa(Me.dgvCompra.Table.CurrentRecord.GetValue("empresa"))
                Else
                    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    txtTotalBase.Text = 0.0
                    txtTotalBase2.Text = 0.0
                    txtTotalIva.Text = 0.0
                    lblTotalPercepcion.Text = 0.0
                    txtTotalPagar.Text = 0.0
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select
    End Sub


    Sub Calculos()
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0

        Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Select Case strTipoExistencia
            Case "GS"
                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
                totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

                If colDestinoGravado = 1 Then
                    Dim iva As Decimal = TmpIGV / 100
                    colBI = (totalMN / (iva + 1))
                    colBIme = (totalME / (iva + 1))

                    Dim iv As Decimal = 0
                    Dim iv2 As Decimal = 0
                    iv = totalMN / (iva + 1)
                    iv2 = totalME / (iva + 1)

                    Igv = iv * (iva)
                    IgvME = iv2 * (iva)
                Else

                    colBI = 0
                    colBIme = 0
                    Igv = 0
                    IgvME = 0

                End If

                '****************************************************************

                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                If colcantidad > 0 Then



                    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                Else

                End If

                Select Case colDestinoGravado
                    Case 1
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    Case 2
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                End Select
                TotalTalesXcolumna()
            Case Else
                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = colcantidad * colPrecUnitAlmacen
                    colCostoME = colcantidad * colPrecUnitUSAlmacen

                    totalMN = colcantidad * colPrecUnit
                    totalME = colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    Dim iva As Decimal = TmpIGV / 100

                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then

                        colBI = (totalMN / (iva + 1))
                        colBIme = (totalME / (iva + 1))

                        Dim iv As Decimal = 0
                        Dim iv2 As Decimal = 0
                        iv = totalMN / (iva + 1)
                        iv2 = totalME / (iva + 1)

                        Igv = iv * (iva)
                        IgvME = iv2 * (iva)

                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If

                    Select Case colDestinoGravado
                        Case 1
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                Else
                    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    txtTotalBase.Text = 0.0
                    txtTotalBase2.Text = 0.0
                    txtTotalIva.Text = 0.0
                    lblTotalPercepcion.Text = 0.0
                    txtTotalPagar.Text = 0.0
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select
    End Sub

    Sub CalculosGasto()
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0

        Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Select Case strTipoExistencia
            Case "GS"
                VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                VCme = VC / txtTipoCambio.DecimalValue

                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                colCostoMN = colcantidad * colPrecUnitAlmacen
                colCostoME = colcantidad * colPrecUnitUSAlmacen

                totalMN = colcantidad * colPrecUnit
                totalME = colcantidad * colPrecUnitme

                If colDestinoGravado = 1 Then
                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                Else
                    valPercepMN = 0
                    valPercepME = 0

                End If

                '****************************************************************
                colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                If colcantidad > 0 AndAlso VC > 0 Then
                    Igv = VC * (TmpIGV / 100)
                    IgvME = VCme * (TmpIGV / 100)

                    colBI = VC + Igv + valPercepMN
                    colBIme = VCme + IgvME + valPercepMN

                    colPrecUnit = VC / colcantidad
                    colPrecUnitme = VCme / colcantidad
                ElseIf colcantidad = 0 Then
                    Igv = VC * (TmpIGV / 100)
                    IgvME = VCme * (TmpIGV / 100)
                    colBI = VC + Igv + valPercepMN
                    colBIme = VCme + IgvME + valPercepME
                    colPrecUnit = 0
                    colPrecUnitme = 0
                Else
                    colPrecUnit = 0
                    colPrecUnitme = 0

                    colBI = 0
                    colBIme = 0
                    Igv = 0
                    IgvME = 0
                End If

                Select Case colDestinoGravado
                    Case 1
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                    Case 2
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                End Select
                TotalTalesXcolumna()
            Case Else
                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                    VCme = VC / txtTipoCambio.DecimalValue

                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = colcantidad * colPrecUnitAlmacen
                    colCostoME = colcantidad * colPrecUnitUSAlmacen

                    totalMN = colcantidad * colPrecUnit
                    totalME = colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 AndAlso VC > 0 Then
                        Igv = VC * (TmpIGV / 100)
                        IgvME = VCme * (TmpIGV / 100)

                        colBI = VC + Igv + valPercepMN
                        colBIme = VCme + IgvME + valPercepMN

                        colPrecUnit = VC / colcantidad
                        colPrecUnitme = VCme / colcantidad
                    ElseIf colcantidad = 0 Then
                        Igv = VC * (TmpIGV / 100)
                        IgvME = VCme * (TmpIGV / 100)
                        colBI = VC + Igv + valPercepMN
                        colBIme = VCme + IgvME + valPercepME
                        colPrecUnit = 0
                        colPrecUnitme = 0
                    Else
                        colPrecUnit = 0
                        colPrecUnitme = 0

                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If

                    Select Case colDestinoGravado
                        Case 1
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                        Case 2
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                    End Select
                    TotalTalesXcolumna()
                Else
                    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    txtTotalBase.Text = 0.0
                    txtTotalBase2.Text = 0.0
                    txtTotalIva.Text = 0.0
                    lblTotalPercepcion.Text = 0.0
                    txtTotalPagar.Text = 0.0
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select
    End Sub

    'Sub CalculosRecorrido()
    '    Dim colcantidad As Decimal = 0
    '    Dim cantidadDisponible As Decimal = 0
    '    Dim Igv As Decimal = 0
    '    Dim IgvME As Decimal = 0
    '    Dim totalMN As Decimal = 0
    '    Dim totalME As Decimal = 0
    '    Dim colBI As Decimal = 0
    '    Dim colBIme As Decimal = 0
    '    Dim colPrecUnit As Decimal = 0
    '    Dim colPrecUnitme As Decimal = 0
    '    Dim colDestinoGravado As Integer
    '    Dim colBonifica As String = Nothing

    '    Dim valPercepMN As Decimal = 0
    '    Dim valPercepME As Decimal = 0

    '    Dim colCostoMN As Decimal = 0
    '    Dim colCostoME As Decimal = 0
    '    Dim colPrecUnitAlmacen As Decimal = 0
    '    Dim colPrecUnitUSAlmacen As Decimal = 0


    '    For Each r As Record In dgvCompra.Table.Records

    '        colcantidad = 0
    '        cantidadDisponible = 0
    '        Igv = 0
    '        IgvME = 0
    '        totalMN = 0
    '        totalME = 0
    '        colBI = 0
    '        colBIme = 0
    '        colPrecUnit = 0
    '        colPrecUnitme = 0
    '        colDestinoGravado = 0
    '        colBonifica = Nothing
    '        valPercepMN = 0
    '        valPercepME = 0
    '        colCostoMN = 0
    '        colCostoME = 0
    '        colPrecUnitAlmacen = 0
    '        colPrecUnitUSAlmacen = 0


    '        'ASIGNANDO VARIABLES 

    '        colcantidad = r.GetValue("cantidad")
    '        cantidadDisponible = r.GetValue("canDisponible")
    '        colPrecUnitAlmacen = r.GetValue("puKardex")
    '        colPrecUnitUSAlmacen = r.GetValue("pukardeme")
    '        colPrecUnit = r.GetValue("pumn")
    '        colPrecUnitme = r.GetValue("pume")
    '        colDestinoGravado = r.GetValue("gravado")

    '        colCostoMN = colcantidad * colPrecUnitAlmacen
    '        colCostoME = colcantidad * colPrecUnitUSAlmacen

    '        totalMN = colcantidad * colPrecUnit
    '        totalME = colcantidad * colPrecUnitme

    '        '----------------------------------------------------------------------------------

    '        If colDestinoGravado = 1 Then
    '            valPercepMN = r.GetValue("percepcionMN")
    '            valPercepME = r.GetValue("percepcionME")
    '        Else
    '            valPercepMN = 0
    '            valPercepME = 0

    '        End If

    '        '****************************************************************
    '        colBonifica = r.GetValue("chBonif")
    '        r.SetValue("cantidad", colcantidad)
    '        If colcantidad > 0 Then

    '            colBI = totalMN / 1.18
    '            colBIme = totalME / 1.18

    '            Igv = colBI * (TmpIGV / 100)
    '            IgvME = colBIme * (TmpIGV / 100)

    '            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
    '            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

    '        Else
    '            colBI = 0
    '            colBIme = 0
    '            Igv = 0
    '            IgvME = 0
    '        End If

    '        Select Case colDestinoGravado
    '            Case 1
    '                r.SetValue("vcmn", colBI)
    '                r.SetValue("vcme", colBIme)
    '                r.SetValue("pumn", colPrecUnit)
    '                r.SetValue("pume", colPrecUnitme)
    '                r.SetValue("totalmn", totalMN)
    '                r.SetValue("totalme", totalME)
    '                r.SetValue("igvmn", Igv)
    '                r.SetValue("igvme", IgvME)
    '                r.SetValue("percepcionMN", 0)
    '                r.SetValue("percepcionME", 0)
    '                r.SetValue("costoMN", colCostoMN)
    '                r.SetValue("costoME", colCostoME)
    '            Case 2
    '                r.SetValue("vcmn", totalMN)
    '                r.SetValue("vcme", totalME)
    '                r.SetValue("pumn", colPrecUnit)
    '                r.SetValue("pume", colPrecUnitme)
    '                r.SetValue("totalmn", totalMN)
    '                r.SetValue("totalme", totalME)
    '                r.SetValue("igvmn", 0)
    '                r.SetValue("igvme", 0)
    '                r.SetValue("percepcionMN", 0)
    '                r.SetValue("percepcionME", 0)
    '                r.SetValue("costoMN", colCostoMN)
    '                r.SetValue("costoME", colCostoME)
    '        End Select

    '    Next

    '    TotalTalesXcolumna()
    'End Sub

    Dim precioSA As New ListadoPrecioSA
    Dim precio As New listadoPrecios
    'Public Sub CargaPrecios(intIdAlmacen As Integer, intIdItem As Integer)
    '    precio = precioSA.UbicarVentaPorItem(intIdAlmacen, intIdItem)

    '    lblMenor.Value = precio.pvmenor.GetValueOrDefault
    '    lblMenorME.Value = precio.pvmenorme.GetValueOrDefault
    '    ' lblDscto.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(2).Text
    '    ' lblDsctoME.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(3).Text

    '    lblMayor.Value = precio.pvmayor.GetValueOrDefault
    '    lblMayorME.Value = precio.pvmayorme.GetValueOrDefault
    '    ' lblDscto.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(6).Text
    '    ' lblDsctoME.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(7).Text

    '    lblGMayor.Value = precio.pvgranmayor.GetValueOrDefault
    '    lblGMayorME.Value = precio.pvgranmayorme.GetValueOrDefault
    '    ' lblDscto.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(10).Text
    '    ' lblDsctoME.Text = frmCanastaPedidos.lsvDetalle.SelectedItems(0).SubItems(11).Text
    '    '     nudCantidad_MouseClick(sender, e)
    'End Sub

    'Private Sub ConfiguracionVenta()
    '    If CDec(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenor")) = 0 Then
    '        lblEstado.Text = "El producto no tiene configurado un precio.!!"
    '    Else
    '        CargaPrecios(txtAlmacen.Tag, Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))
    '        txtFiltrar.Clear()
    '        txtFiltrar.Focus()
    '    End If
    'End Sub

    Public Sub AgregarAcanasta(r As Record)
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        'If rbMenor.Checked = True Then
        '    valTipoVenta = "MN"
        valPUmn = Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciomn")
        valPUme = Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciome")
        'ElseIf rbMayor.Checked = True Then
        '    valTipoVenta = "MY"
        '    valPUmn = lblMayor.Value ' .Cells(14).Value
        '    valPUme = lblMayorME.Value ' .Cells(15).Value
        'ElseIf rbgmayor.Checked = True Then
        '    valTipoVenta = "GMY"
        '    valPUmn = lblGMayor.Value ' .Cells(14).Value
        '    valPUme = lblGMayorME.Value '.Cells(15).Value
        'End If
        With productoSA.InvocarProductoID(r.GetValue("idItem"))
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", r.GetValue("destino"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", r.GetValue("idItem"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", r.GetValue("unidad"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", r.GetValue("cantidad"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "01")
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", r.GetValue("puKardexmn"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", r.GetValue("puKardexme"))

            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            '   If .tipoExistencia <> "GS" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", r.GetValue("idalmacen"))
            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
            '   End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Me.GridGroupingControl2.Table.CurrentRecord.GetValue("idPrecio"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

            Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)
            Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", gridGroupingControl1.Table.CurrentRecord.GetValue("idEmpresa"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
            Me.dgvCompra.Table.CurrentRecord.SetValue("estable", Val(r.GetValue("estable")))
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With


        Dim c = listaEstablecimientoCanasta.Where(Function(o) o.idCentroCosto = Val(r.GetValue("estable"))).FirstOrDefault()
        If IsNothing(c) Then
            listaEstablecimientoCanasta.Add(New centrocosto With {.idCentroCosto = Val(r.GetValue("estable")),
                                                                  .idEmpresa = r.GetValue("idEmpresa")})
        End If


        txtBarCode.Select()
        txtBarCode.SelectAll()

        '    dgvNuevoDoc.Rows.Add(0, Me.gridGroupingControl1.Table.CurrentRecord.GetValue("destino"),
        '                                Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"),
        '                                Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion"),
        '                                Me.gridGroupingControl1.Table.CurrentRecord.GetValue("unidad"),
        '                                CDec(txtCantidad.Text),
        '                                Me.gridGroupingControl1.Table.CurrentRecord.GetValue("puKardexmn"),
        '                                Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"),
        '                                valPUmn,
        '                                valPUme,
        '                                CDec(lblTotalMN.Text),
        '                                CDec(lblTotalME.Text),
        '                                0,
        '                                0,
        '                                0,
        '                                0,
        '                                0,
        '                                0,
        '                                0,
        '                                0,
        '                                0,
        '                                0,
        '                                Business.Entity.BaseBE.EntityAction.INSERT,
        '                                txtExistencia.Tag,
        '                                txtAlmacen.Tag,
        '                                Nothing,
        '                                GEstableciento.IdEstablecimiento,
        '                                Nothing,
        '                                Me.gridGroupingControl1.Table.CurrentRecord.GetValue("puKardexme"),
        '                                Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idPres"),
        '                                Nothing,
        '                                Me.gridGroupingControl1.Table.CurrentRecord.GetValue("presentacion"),
        '                                valTipoVenta,
        '                                0,
        '                                0)
        '    Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub AgregarAcanastaServicio()
        Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim tasaIva As Decimal = TmpIGV / 100
        Dim productoSA As New detalleitemsSA


        Select Case cboMoneda.SelectedValue
            Case 1
                valPUmn = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciomn")
                valPUme = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciome")

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                If cboDestino.Text = "2-Exonerado" Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "2")
                Else
                    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
                End If

                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", cboServicio.SelectedValue)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", cboServicio.Text)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", "07")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", 0)
                If cboDestino.Text = "2-Exonerado" Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", valPUmn)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)

                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                Else
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", (valPUmn / (tasaIva + 1)))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0)

                    Dim iv As Decimal = 0
                    iv = valPUmn / (tasaIva + 1)

                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", (iv * tasaIva))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", iv * tasaIva)
                End If
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", valPUmn)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", valPUme)

                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "GS")
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

                Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", 0)

                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                '   If .tipoExistencia <> "GS" Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", 0)
                'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                '   End If
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", String.Empty)

                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("idPrecio"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("cat", cboServicio.SelectedValue)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()

                dgvCompra.TableControl.CurrentCell.EndEdit()
                dgvCompra.TableControl.Table.TableDirty = True
                dgvCompra.TableControl.Table.EndEdit()
            Case 2

                valPUmn = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciomn")
                valPUme = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciome")

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                If cboDestino.Text = "2-Exonerado" Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "2")
                Else
                    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
                End If

                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", cboServicio.SelectedValue)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", cboServicio.Text)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", "07")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", 0)
                If cboDestino.Text = "2-Exonerado" Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", valPUmn)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)

                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                Else
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", (valPUmn / (tasaIva + 1)))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", (valPUme / (tasaIva + 1)))

                    Dim iv As Decimal = 0
                    iv = valPUmn / (tasaIva + 1)

                    Dim ivme As Decimal = 0
                    ivme = (valPUme / (tasaIva + 1))

                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", (iv * tasaIva))
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", ivme * tasaIva)
                End If
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", valPUmn)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", valPUme)

                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "GS")
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

                Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", 0)

                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                '   If .tipoExistencia <> "GS" Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", 0)
                'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                '   End If
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", String.Empty)

                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("idPrecio"))
                Me.dgvCompra.Table.CurrentRecord.SetValue("cat", cboServicio.SelectedValue)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()

                dgvCompra.TableControl.CurrentCell.EndEdit()
                dgvCompra.TableControl.Table.TableDirty = True
                dgvCompra.TableControl.Table.EndEdit()


        End Select

        TotalTalesXcolumna()
    End Sub

    Private Sub AceptarPrecioProducto(intDisponible As Decimal)
        'If txtCantidad.Text.Trim.Length > 0 Then
        '    If txtCantidad.Text = "." Then
        '        MsgBox("La cantidad debe ser un número válido.", MsgBoxStyle.Information, "Atención!")
        '        txtCantidad.Clear()
        '        txtCantidad.Focus()
        '    Else
        '        If txtCantidad.Text > 0 Then
        '            If CDec(txtCantidad.Text) > intDisponible Then
        '                MsgBox("No hay suficiente cantidad pra realizar la venta, " & vbCrLf & "Verifique la cantidad en su inventario!", MsgBoxStyle.Information, "Atención!")
        '                txtCantidad.Focus()
        '                txtCantidad.Select(0, txtCantidad.Text.Length)
        '            Else
        AgregarAcanasta(gridGroupingControl1.Table.CurrentRecord)
        '  End If

        '        Else
        'MsgBox("La cantidad debe ser mayor a cero.", MsgBoxStyle.Information, "Atención")
        'txtCantidad.Focus()
        'txtCantidad.Select(0, txtCantidad.Text.Length)
        '        End If
        '    End If
        'Else
        'MsgBox("La cantidad debe ser un número válido.", MsgBoxStyle.Information, "Atención!")
        'txtCantidad.Focus()
        'End If
    End Sub

    'Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
    '    Dim CanastaSA As New TotalesAlmacenSA
    '    Dim listaSA As New ListadoPrecioSA
    '    Dim lista As New listadoPrecios

    '    Dim dt As New DataTable()
    '    Try
    '        dt.Columns.Add("destino", GetType(String))
    '        dt.Columns.Add("idItem", GetType(Integer))
    '        dt.Columns.Add("descripcion", GetType(String))
    '        dt.Columns.Add("unidad", GetType(String))
    '        dt.Columns.Add("idPres", GetType(String))
    '        dt.Columns.Add("presentacion", GetType(String))
    '        dt.Columns.Add("cantidad", GetType(Decimal))
    '        dt.Columns.Add("puKardexmn", GetType(Decimal))
    '        dt.Columns.Add("puKardexme", GetType(Decimal))
    '        dt.Columns.Add("importeMn", GetType(Decimal))
    '        dt.Columns.Add("importeME", GetType(Decimal))
    '        dt.Columns.Add("pvmenor", GetType(Decimal))
    '        dt.Columns.Add("pvmenorme", GetType(Decimal))
    '        dt.Columns.Add("pvmayor", GetType(Decimal))
    '        dt.Columns.Add("pvmayorme", GetType(Decimal))
    '        dt.Columns.Add("pvGmayor", GetType(Decimal))
    '        dt.Columns.Add("pvGmayorme", GetType(Decimal))

    '        'ListView1.Items.Clear()
    '        Dim cprecioVentaFinalMenorMN As Decimal = 0
    '        Dim cprecioVentaFinalMenorME As Decimal = 0
    '        Dim cmontoDsctounitMenorMN As Decimal = 0
    '        Dim cmontoDsctounitMenorME As Decimal = 0
    '        Dim cprecioVentaFinalMayorMN As Decimal = 0
    '        Dim cprecioVentaFinalGMayorMN As Decimal = 0
    '        Dim cprecioVentaFinalMayorME As Decimal = 0
    '        Dim cprecioVentaFinalGMayorME As Decimal = 0
    '        Dim cdetalleMenor As String = Nothing
    '        Dim cdetalleMayor As String = Nothing
    '        Dim cdetalleGMayor As String = Nothing
    '        For Each i As totalesAlmacen In CanastaSA.ObtenerCanastaDeVentaPorProducto(IntIdAlmacen, strTipoExistencia, strProducto)
    '            If CDec(i.cantidad) > 0 Then
    '                Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
    '                Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

    '                lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui
    '                '    Case "NIVA"
    '                'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "NIVA")
    '                'End Select

    '                If Not IsNothing(lista) Then
    '                    With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
    '                        cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
    '                        cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
    '                        cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
    '                        cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
    '                        cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
    '                        cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
    '                        cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
    '                        cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)
    '                        'cdetalleMenor = .detalleMenor
    '                        'cdetalleMayor = .detalleMayor
    '                        'cdetalleGMayor = .detalleGMayor
    '                    End With
    '                Else
    '                    lblEstado.Text = "EL producto no contiene una configuración de precio.!"
    '                    lblEstado.Image = My.Resources.warning2
    '                End If

    '                Dim dr As DataRow = dt.NewRow()
    '                dr(0) = i.origenRecaudo
    '                dr(1) = i.idItem
    '                dr(2) = i.descripcion
    '                dr(3) = i.unidadMedida
    '                dr(4) = i.Presentacion
    '                dr(5) = i.NombrePresentacion
    '                dr(6) = i.cantidad
    '                dr(7) = valPrecUnitario
    '                dr(8) = valPrecUnitarioUS
    '                dr(9) = i.importeSoles
    '                dr(10) = i.importeDolares

    '                dr(11) = cprecioVentaFinalMenorMN
    '                dr(12) = cprecioVentaFinalMenorME
    '                dr(13) = cprecioVentaFinalMayorMN
    '                dr(14) = cprecioVentaFinalMayorME
    '                dr(15) = cprecioVentaFinalGMayorMN
    '                dr(16) = cprecioVentaFinalGMayorME
    '                dt.Rows.Add(dr)
    '            End If
    '        Next
    '        gridGroupingControl1.DataSource = dt
    '        gridGroupingControl1.TableDescriptor.Relations.Clear()
    '        gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '        gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '        'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
    '        gridGroupingControl1.GroupDropPanel.Visible = True
    '        gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Sub CargarPrecioXproducto(intIdAlmacen As Integer, intIdItem As Integer)
    '    Dim lista As New List(Of listadoPrecios)
    '    Dim listaPrecioSA As New ListadoPrecioSA

    '    lista = listaPrecioSA.PrecioVentaXitemXiva(intIdAlmacen, intIdItem, Nothing) ' no funciona aqui

    'End Sub


    Private Sub ObtenerCanastaVentaFiltroEmpresa(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))

            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))
            dt.Columns.Add("estable")
            'ListView1.Items.Clear()
            Dim cprecioVentaFinalMenorMN As Decimal = 0
            Dim cprecioVentaFinalMenorME As Decimal = 0
            Dim cmontoDsctounitMenorMN As Decimal = 0
            Dim cmontoDsctounitMenorME As Decimal = 0
            Dim cprecioVentaFinalMayorMN As Decimal = 0
            Dim cprecioVentaFinalGMayorMN As Decimal = 0
            Dim cprecioVentaFinalMayorME As Decimal = 0
            Dim cprecioVentaFinalGMayorME As Decimal = 0
            Dim cdetalleMenor As String = Nothing
            Dim cdetalleMayor As String = Nothing
            Dim cdetalleGMayor As String = Nothing

            For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproductoEmpresa(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = ""})
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

                    'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui


                    'If Not IsNothing(lista) Then
                    '    With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
                    '        cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
                    '        cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
                    '        cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
                    '        cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
                    '        cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
                    '        cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
                    '        cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
                    '        cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)
                    '        'cdetalleMenor = .detalleMenor
                    '        'cdetalleMayor = .detalleMayor
                    '        'cdetalleGMayor = .detalleGMayor
                    '    End With
                    'Else
                    '    lblEstado.Text = "EL producto no contiene una configuración de precio.!"
                    '    lblEstado.Image = My.Resources.warning2
                    'End If

                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.idEmpresa

                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares

                    dr(12) = cprecioVentaFinalMenorMN
                    dr(13) = cprecioVentaFinalMenorME
                    dr(14) = cprecioVentaFinalMayorMN
                    dr(15) = cprecioVentaFinalMayorME
                    dr(16) = cprecioVentaFinalGMayorMN
                    dr(17) = cprecioVentaFinalGMayorME
                    dr(18) = i.idAlmacen
                    dr(19) = i.NomAlmacen
                    dr(20) = i.idEstablecimiento
                    dt.Rows.Add(dr)
                End If
            Next
            gridGroupingControl1.DataSource = dt
            gridGroupingControl1.TableDescriptor.Relations.Clear()
            gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            gridGroupingControl1.GroupDropPanel.Visible = True
            gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub GetListaProductosEmpresaByCodigoBarra(lista As List(Of totalesAlmacen))
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))

            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))
            dt.Columns.Add("estable")
            'ListView1.Items.Clear()
            Dim cprecioVentaFinalMenorMN As Decimal = 0
            Dim cprecioVentaFinalMenorME As Decimal = 0
            Dim cmontoDsctounitMenorMN As Decimal = 0
            Dim cmontoDsctounitMenorME As Decimal = 0
            Dim cprecioVentaFinalMayorMN As Decimal = 0
            Dim cprecioVentaFinalGMayorMN As Decimal = 0
            Dim cprecioVentaFinalMayorME As Decimal = 0
            Dim cprecioVentaFinalGMayorME As Decimal = 0
            Dim cdetalleMenor As String = Nothing
            Dim cdetalleMayor As String = Nothing
            Dim cdetalleGMayor As String = Nothing

            For Each i As totalesAlmacen In lista
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

                    'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui


                    'If Not IsNothing(lista) Then
                    '    With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
                    '        cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
                    '        cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
                    '        cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
                    '        cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
                    '        cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
                    '        cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
                    '        cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
                    '        cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)
                    '        'cdetalleMenor = .detalleMenor
                    '        'cdetalleMayor = .detalleMayor
                    '        'cdetalleGMayor = .detalleGMayor
                    '    End With
                    'Else
                    '    lblEstado.Text = "EL producto no contiene una configuración de precio.!"
                    '    lblEstado.Image = My.Resources.warning2
                    'End If

                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.idEmpresa

                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares

                    dr(12) = cprecioVentaFinalMenorMN
                    dr(13) = cprecioVentaFinalMenorME
                    dr(14) = cprecioVentaFinalMayorMN
                    dr(15) = cprecioVentaFinalMayorME
                    dr(16) = cprecioVentaFinalGMayorMN
                    dr(17) = cprecioVentaFinalGMayorME
                    dr(18) = i.idAlmacen
                    dr(19) = i.NomAlmacen
                    dr(20) = i.idEstablecimiento
                    dt.Rows.Add(dr)
                End If
            Next
            gridGroupingControl1.DataSource = dt
            gridGroupingControl1.TableDescriptor.Relations.Clear()
            gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            gridGroupingControl1.GroupDropPanel.Visible = True
            gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))

            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))
            dt.Columns.Add("estable")

            'ListView1.Items.Clear()
            Dim cprecioVentaFinalMenorMN As Decimal = 0
            Dim cprecioVentaFinalMenorME As Decimal = 0
            Dim cmontoDsctounitMenorMN As Decimal = 0
            Dim cmontoDsctounitMenorME As Decimal = 0
            Dim cprecioVentaFinalMayorMN As Decimal = 0
            Dim cprecioVentaFinalGMayorMN As Decimal = 0
            Dim cprecioVentaFinalMayorME As Decimal = 0
            Dim cprecioVentaFinalGMayorME As Decimal = 0
            Dim cdetalleMenor As String = Nothing
            Dim cdetalleMayor As String = Nothing
            Dim cdetalleGMayor As String = Nothing

            For Each i As totalesAlmacen In CanastaSA.GetListadoProductosParaVentaXproducto(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = ""})
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

                    'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui


                    'If Not IsNothing(lista) Then
                    '    With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
                    '        cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
                    '        cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
                    '        cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
                    '        cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
                    '        cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
                    '        cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
                    '        cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
                    '        cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)
                    '        'cdetalleMenor = .detalleMenor
                    '        'cdetalleMayor = .detalleMayor
                    '        'cdetalleGMayor = .detalleGMayor
                    '    End With
                    'Else
                    '    lblEstado.Text = "EL producto no contiene una configuración de precio.!"
                    '    lblEstado.Image = My.Resources.warning2
                    'End If

                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.idEmpresa

                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares

                    dr(12) = cprecioVentaFinalMenorMN
                    dr(13) = cprecioVentaFinalMenorME
                    dr(14) = cprecioVentaFinalMayorMN
                    dr(15) = cprecioVentaFinalMayorME
                    dr(16) = cprecioVentaFinalGMayorMN
                    dr(17) = cprecioVentaFinalGMayorME
                    dr(18) = i.idAlmacen
                    dr(19) = i.NomAlmacen
                    dr(20) = i.idEstablecimiento
                    dt.Rows.Add(dr)
                End If
            Next
            gridGroupingControl1.DataSource = dt
            gridGroupingControl1.TableDescriptor.Relations.Clear()
            gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            gridGroupingControl1.GroupDropPanel.Visible = True
            gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerExistenciaByCode(IntIdAlmacen As Integer, intIdExistencia As Integer)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim i As New totalesAlmacen
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))

            'ListView1.Items.Clear()
            Dim cprecioVentaFinalMenorMN As Decimal = 0
            Dim cprecioVentaFinalMenorME As Decimal = 0
            Dim cmontoDsctounitMenorMN As Decimal = 0
            Dim cmontoDsctounitMenorME As Decimal = 0
            Dim cprecioVentaFinalMayorMN As Decimal = 0
            Dim cprecioVentaFinalGMayorMN As Decimal = 0
            Dim cprecioVentaFinalMayorME As Decimal = 0
            Dim cprecioVentaFinalGMayorME As Decimal = 0
            Dim cdetalleMenor As String = Nothing
            Dim cdetalleMayor As String = Nothing
            Dim cdetalleGMayor As String = Nothing

            i = CanastaSA.GetListadoProductosParaVentaXbarCode(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .idItem = intIdExistencia})

            If Not IsNothing(i) Then
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.origenRecaudo
                    dr(1) = i.idItem
                    dr(2) = i.descripcion
                    dr(3) = i.unidadMedida
                    dr(4) = i.Presentacion
                    dr(5) = i.NombrePresentacion
                    dr(6) = i.cantidad
                    dr(7) = valPrecUnitario
                    dr(8) = valPrecUnitarioUS
                    dr(9) = i.importeSoles
                    dr(10) = i.importeDolares

                    dr(11) = cprecioVentaFinalMenorMN
                    dr(12) = cprecioVentaFinalMenorME
                    dr(13) = cprecioVentaFinalMayorMN
                    dr(14) = cprecioVentaFinalMayorME
                    dr(15) = cprecioVentaFinalGMayorMN
                    dr(16) = cprecioVentaFinalGMayorME
                    dt.Rows.Add(dr)
                End If
            End If

            gridGroupingControl1.DataSource = dt
            gridGroupingControl1.TableDescriptor.Relations.Clear()
            gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            gridGroupingControl1.GroupDropPanel.Visible = True
            gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub


    Public Function AS_CAJA(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = GFichaUsuarios.IdCajaDestino,
              .descripcion = GFichaUsuarios.NomCajaDestinb,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal, empresa As String) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = empresa
        nAsiento.idCentroCostos = 1
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente2.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        'nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Function AsientoTransitoEstablecimiento(cMonto As Decimal, cMontoUS As Decimal, empresa As String, estable As Integer) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = empresa
        nAsiento.idCentroCostos = estable
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente2.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        'nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS, "") ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        nMovimiento.cuenta = "69112"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        nMovimiento.cuenta = "20111"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub


    Function ListaDocumentoCajaE1(empresa As String) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        For Each i In dgvPago1.Table.Records
            If i.GetValue("empresa") = empresa Then
                If CDbl(i.GetValue("montoMN") > 0) Then
                    nDocumentoCaja = New documento
                    'DOCUMENTO
                    nDocumentoCaja.idDocumento = CInt(Me.Tag)
                    nDocumentoCaja.idEmpresa = empresa
                    nDocumentoCaja.idCentroCosto = 1
                    nDocumentoCaja.tipoDoc = GConfiguracion.TipoComprobante
                    nDocumentoCaja.fechaProceso = txtFecha.Value
                    nDocumentoCaja.nroDoc = GConfiguracion.Serie
                    nDocumentoCaja.idOrden = Nothing
                    nDocumentoCaja.tipoOperacion = "01"
                    nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                    nDocumentoCaja.fechaActualizacion = DateTime.Now

                    'DOCUMENTO CAJA
                    objCaja = New documentoCaja
                    objCaja.idDocumento = 0
                    objCaja.periodo = PeriodoGeneral
                    If txtCliente.Text.Trim.Length > 0 Then
                        objCaja.codigoProveedor = lblNumeroDoc
                    End If
                    objCaja.idEmpresa = empresa
                    objCaja.idEstablecimiento = 1
                    objCaja.fechaProceso = txtFecha.Value
                    objCaja.fechaCobro = txtFecha.Value
                    objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                    If txtCliente.Text.Trim.Length > 0 Then
                        objCaja.IdProveedor = txtCliente.Tag
                    End If
                    objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
                    objCaja.codigoLibro = "01"
                    objCaja.tipoDocPago = cboTipoDoc.SelectedValue
                    objCaja.NumeroDocumento = GConfiguracion.Serie
                    objCaja.numeroOperacion = i.GetValue("numOper")

                    objCaja.montoSoles = CDec(i.GetValue("montoMN"))
                    Select Case i.GetValue("moneda")
                        Case "NACIONAL"
                            objCaja.moneda = 1
                            objCaja.tipoCambio = TmpTipoCambio
                            objCaja.montoUsd = CDec(objCaja.montoSoles * TmpTipoCambio)
                        Case "EXTRANJERO"
                            objCaja.moneda = 2
                            objCaja.tipoCambio = i.GetValue("tipocambio")
                            objCaja.montoUsd = CDec(i.GetValue("montoME"))
                    End Select


                    objCaja.estado = "P"
                    objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumeroGuia.Text & " fecha: " & txtFecha.Value
                    objCaja.entregado = "SI"

                    objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                    objCaja.usuarioModificacion = usuario.IDUsuario
                    objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))
                    objCaja.NombreEntidad = (i.GetValue("ef"))
                    objCaja.fechaModificacion = DateTime.Now

                    'vuelto ticket
                    'vueltoMN = CDec(i.GetValue("vueltoMN"))
                    'vueltoME = CDec(i.GetValue("vueltoME"))

                    nDocumentoCaja.documentoCaja = objCaja
                    ListaDoc.Add(nDocumentoCaja)
                    ListaDetalleCaja(nDocumentoCaja.documentoCaja, empresa)
                    asientoDocumento(nDocumentoCaja.documentoCaja, empresa)
                End If
            End If

        Next

        Return ListaDoc
    End Function


    Function ListadoCajaPagos() As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)


        For Each i In dgvPago1.Table.Records
            If CDbl(i.GetValue("montoMN") > 0) Then

                nDocumentoCaja = New documento
                nDocumentoCaja.idDocumento = CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = i.GetValue("empresa")
                nDocumentoCaja.idCentroCosto = i.GetValue("estable")
                nDocumentoCaja.tipoDoc = GConfiguracion.TipoComprobante
                nDocumentoCaja.fechaProceso = txtFecha.Value
                nDocumentoCaja.nroDoc = GConfiguracion.Serie
                nDocumentoCaja.idOrden = Nothing
                nDocumentoCaja.tipoOperacion = "01"
                nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now

                '   documento CAJA
                objCaja = New documentoCaja
                objCaja.idDocumento = 0
                objCaja.periodo = PeriodoGeneral
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.codigoProveedor = lblNumeroDoc
                End If
                objCaja.idEmpresa = i.GetValue("empresa")
                objCaja.idEstablecimiento = i.GetValue("estable")
                objCaja.fechaProceso = txtFecha.Value
                objCaja.fechaCobro = txtFecha.Value
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.IdProveedor = txtCliente.Tag
                End If
                objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
                objCaja.codigoLibro = "01"
                objCaja.tipoDocPago = cboTipoDoc.SelectedValue
                objCaja.NumeroDocumento = GConfiguracion.Serie
                objCaja.numeroOperacion = i.GetValue("numOper")

                objCaja.montoSoles = CDec(i.GetValue("montoMN"))
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        objCaja.moneda = 1
                        objCaja.tipoCambio = TmpTipoCambio
                        objCaja.montoUsd = CDec(objCaja.montoSoles * TmpTipoCambio)
                    Case "EXTRANJERO"
                        objCaja.moneda = 2
                        objCaja.tipoCambio = i.GetValue("tipocambio")
                        objCaja.montoUsd = CDec(i.GetValue("montoME"))
                End Select


                objCaja.estado = "P"
                objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumeroGuia.Text & " fecha: " & txtFecha.Value
                objCaja.entregado = "SI"

                objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                objCaja.usuarioModificacion = usuario.IDUsuario
                objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))
                objCaja.NombreEntidad = (i.GetValue("ef"))
                objCaja.fechaModificacion = DateTime.Now
                'vuelto ticket
                'vueltoMN = CDec(i.GetValue("vueltoMN"))
                'vueltoME = CDec(i.GetValue("vueltoME"))

                nDocumentoCaja.documentoCaja = objCaja
                ListaDoc.Add(nDocumentoCaja)
                DetallePagosCajaByIdEntidad(nDocumentoCaja)
                asientoDocumento(nDocumentoCaja.documentoCaja, i.GetValue("empresa"))
            End If
        Next


        For Each i In dgvPagos.Table.Records
            If CDbl(i.GetValue("montoMN") > 0) Then
                nDocumentoCaja = New documento
                nDocumentoCaja.idDocumento = CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = i.GetValue("empresa")
                nDocumentoCaja.idCentroCosto = i.GetValue("estable")
                nDocumentoCaja.tipoDoc = GConfiguracion.TipoComprobante
                nDocumentoCaja.fechaProceso = txtFecha.Value
                nDocumentoCaja.nroDoc = GConfiguracion.Serie
                nDocumentoCaja.idOrden = Nothing
                nDocumentoCaja.tipoOperacion = "01"
                nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now

                'documento CAJA
                objCaja = New documentoCaja
                objCaja.idDocumento = 0
                objCaja.periodo = PeriodoGeneral
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.codigoProveedor = lblNumeroDoc
                End If
                objCaja.idEmpresa = i.GetValue("empresa")
                objCaja.idEstablecimiento = i.GetValue("estable")
                objCaja.fechaProceso = txtFecha.Value
                objCaja.fechaCobro = txtFecha.Value
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                If txtCliente.Text.Trim.Length > 0 Then
                    objCaja.IdProveedor = txtCliente.Tag
                End If
                objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
                objCaja.codigoLibro = "01"
                objCaja.tipoDocPago = cboTipoDoc.SelectedValue
                objCaja.NumeroDocumento = GConfiguracion.Serie
                objCaja.numeroOperacion = i.GetValue("numOper")

                objCaja.montoSoles = CDec(i.GetValue("montoMN"))
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        objCaja.moneda = 1
                        objCaja.tipoCambio = TmpTipoCambio
                        objCaja.montoUsd = CDec(objCaja.montoSoles * TmpTipoCambio)
                    Case "EXTRANJERO"
                        objCaja.moneda = 2
                        objCaja.tipoCambio = i.GetValue("tipocambio")
                        objCaja.montoUsd = CDec(i.GetValue("montoME"))
                End Select


                objCaja.estado = "P"
                objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumeroGuia.Text & " fecha: " & txtFecha.Value
                objCaja.entregado = "SI"

                objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                objCaja.usuarioModificacion = usuario.IDUsuario
                objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))
                objCaja.NombreEntidad = (i.GetValue("ef"))
                objCaja.fechaModificacion = DateTime.Now

                'vuelto ticket
                'vueltoMN = CDec(i.GetValue("vueltoMN"))
                'vueltoME = CDec(i.GetValue("vueltoME"))

                nDocumentoCaja.documentoCaja = objCaja
                ListaDoc.Add(nDocumentoCaja)
                DetallePagosCajaByIdEntidad(nDocumentoCaja)
                asientoDocumento(nDocumentoCaja.documentoCaja, i.GetValue("empresa"))
            End If

        Next


        Return ListaDoc
    End Function

    Function ListaPagosEstablecimiento(empresa As String, estable As Integer) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        'For Each i In listaEstablecimientoCanasta
        '    If i.idEmpresa = empresa And i.idCentroCosto = estable Then
        '        nDocumentoCaja = New documento
        '        'DOCUMENTO
        '        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        '        nDocumentoCaja.idEmpresa = empresa
        '        nDocumentoCaja.idCentroCosto = estable
        '        nDocumentoCaja.tipoDoc = GConfiguracion2.TipoComprobante
        '        nDocumentoCaja.fechaProceso = txtFecha.Value
        '        nDocumentoCaja.nroDoc = GConfiguracion2.Serie
        '        nDocumentoCaja.idOrden = Nothing
        '        nDocumentoCaja.tipoOperacion = "01"
        '        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        '        nDocumentoCaja.fechaActualizacion = DateTime.Now

        '        'DOCUMENTO CAJA
        '        objCaja = New documentoCaja
        '        objCaja.idDocumento = 0
        '        objCaja.periodo = PeriodoGeneral
        '        If txtCliente.Text.Trim.Length > 0 Then
        '            objCaja.codigoProveedor = lblNumeroDoc
        '        End If
        '        objCaja.idEmpresa = empresa
        '        objCaja.idEstablecimiento = estable
        '        objCaja.fechaProceso = txtFecha.Value
        '        objCaja.fechaCobro = txtFecha.Value
        '        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        '        If txtCliente.Text.Trim.Length > 0 Then
        '            objCaja.IdProveedor = txtCliente.Tag
        '        End If
        '        objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
        '        objCaja.codigoLibro = "01"
        '        objCaja.tipoDocPago = cboTipoDoc.SelectedValue
        '        objCaja.NumeroDocumento = GConfiguracion2.Serie
        '        objCaja.numeroOperacion = "-"

        '        'objCaja.montoSoles = CDec(i.s)
        '        'Select Case i.GetValue("moneda")
        '        '    Case "NACIONAL"
        '        '        objCaja.moneda = 1
        '        '        objCaja.tipoCambio = TmpTipoCambio
        '        '        objCaja.montoUsd = CDec(objCaja.montoSoles * TmpTipoCambio)
        '        '    Case "EXTRANJERO"
        '        '        objCaja.moneda = 2
        '        '        objCaja.tipoCambio = i.GetValue("tipocambio")
        '        '        objCaja.montoUsd = CDec(i.GetValue("montoME"))
        '        'End Select


        '        objCaja.estado = "P"
        '        objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumeroGuia.Text & " fecha: " & txtFecha.Value
        '        objCaja.entregado = "SI"

        '        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        '        objCaja.usuarioModificacion = usuario.IDUsuario
        '        ''objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))
        '        ''objCaja.NombreEntidad = (i.GetValue("ef"))
        '        objCaja.fechaModificacion = DateTime.Now
        '    End If


        '    nDocumentoCaja.documentoCaja = objCaja
        '    ListaDoc.Add(nDocumentoCaja)
        '    ListaDetalleCajaEstableciiento(nDocumentoCaja.documentoCaja, empresa, estable)
        '    asientoDocumentoEstable(nDocumentoCaja.documentoCaja, empresa, estable)
        'Next

        For Each i In dgvPago1.Table.Records
            If i.GetValue("empresa") = empresa And i.GetValue("estable") = estable Then
                If CDbl(i.GetValue("montoMN") > 0) Then

                    nDocumentoCaja = New documento

                    nDocumentoCaja.idDocumento = CInt(Me.Tag)
                    nDocumentoCaja.idEmpresa = empresa
                    nDocumentoCaja.idCentroCosto = i.GetValue("estable")
                    nDocumentoCaja.tipoDoc = GConfiguracion.TipoComprobante
                    nDocumentoCaja.fechaProceso = txtFecha.Value
                    nDocumentoCaja.nroDoc = GConfiguracion.Serie
                    nDocumentoCaja.idOrden = Nothing
                    nDocumentoCaja.tipoOperacion = "01"
                    nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                    nDocumentoCaja.fechaActualizacion = DateTime.Now

                    '   documento CAJA
                    objCaja = New documentoCaja
                    objCaja.idDocumento = 0
                    objCaja.periodo = PeriodoGeneral
                    If txtCliente.Text.Trim.Length > 0 Then
                        objCaja.codigoProveedor = lblNumeroDoc
                    End If
                    objCaja.idEmpresa = empresa
                    objCaja.idEstablecimiento = estable
                    objCaja.fechaProceso = txtFecha.Value
                    objCaja.fechaCobro = txtFecha.Value
                    objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                    If txtCliente.Text.Trim.Length > 0 Then
                        objCaja.IdProveedor = txtCliente.Tag
                    End If
                    objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
                    objCaja.codigoLibro = "01"
                    objCaja.tipoDocPago = cboTipoDoc.SelectedValue
                    objCaja.NumeroDocumento = GConfiguracion.Serie
                    objCaja.numeroOperacion = i.GetValue("numOper")

                    objCaja.montoSoles = CDec(i.GetValue("montoMN"))
                    Select Case i.GetValue("moneda")
                        Case "NACIONAL"
                            objCaja.moneda = 1
                            objCaja.tipoCambio = TmpTipoCambio
                            objCaja.montoUsd = CDec(objCaja.montoSoles * TmpTipoCambio)
                        Case "EXTRANJERO"
                            objCaja.moneda = 2
                            objCaja.tipoCambio = i.GetValue("tipocambio")
                            objCaja.montoUsd = CDec(i.GetValue("montoME"))
                    End Select


                    objCaja.estado = "P"
                    objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumeroGuia.Text & " fecha: " & txtFecha.Value
                    objCaja.entregado = "SI"

                    objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                    objCaja.usuarioModificacion = usuario.IDUsuario
                    objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))
                    objCaja.NombreEntidad = (i.GetValue("ef"))
                    objCaja.fechaModificacion = DateTime.Now
                    'vuelto ticket
                    'vueltoMN = CDec(i.GetValue("vueltoMN"))
                    'vueltoME = CDec(i.GetValue("vueltoME"))

                    nDocumentoCaja.documentoCaja = objCaja
                    ListaDoc.Add(nDocumentoCaja)
                    ListaDetalleCajaEstableciiento(nDocumentoCaja.documentoCaja, empresa, estable)
                    asientoDocumentoEstable(nDocumentoCaja.documentoCaja, empresa, estable)
                End If
            End If

        Next


        For Each i In dgvPagos.Table.Records
            If i.GetValue("empresa") = empresa And i.GetValue("estable") = estable Then
                If CDbl(i.GetValue("montoMN") > 0) Then
                    nDocumentoCaja = New documento

                    nDocumentoCaja.idDocumento = CInt(Me.Tag)
                    nDocumentoCaja.idEmpresa = empresa
                    nDocumentoCaja.idCentroCosto = i.GetValue("estable")
                    nDocumentoCaja.tipoDoc = GConfiguracion.TipoComprobante
                    nDocumentoCaja.fechaProceso = txtFecha.Value
                    nDocumentoCaja.nroDoc = GConfiguracion.Serie
                    nDocumentoCaja.idOrden = Nothing
                    nDocumentoCaja.tipoOperacion = "01"
                    nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                    nDocumentoCaja.fechaActualizacion = DateTime.Now

                    'documento CAJA
                    objCaja = New documentoCaja
                    objCaja.idDocumento = 0
                    objCaja.periodo = PeriodoGeneral
                    If txtCliente.Text.Trim.Length > 0 Then
                        objCaja.codigoProveedor = lblNumeroDoc
                    End If
                    objCaja.idEmpresa = empresa
                    objCaja.idEstablecimiento = estable
                    objCaja.fechaProceso = txtFecha.Value
                    objCaja.fechaCobro = txtFecha.Value
                    objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                    If txtCliente.Text.Trim.Length > 0 Then
                        objCaja.IdProveedor = txtCliente.Tag
                    End If
                    objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
                    objCaja.codigoLibro = "01"
                    objCaja.tipoDocPago = cboTipoDoc.SelectedValue
                    objCaja.NumeroDocumento = GConfiguracion.Serie
                    objCaja.numeroOperacion = i.GetValue("numOper")

                    objCaja.montoSoles = CDec(i.GetValue("montoMN"))
                    Select Case i.GetValue("moneda")
                        Case "NACIONAL"
                            objCaja.moneda = 1
                            objCaja.tipoCambio = TmpTipoCambio
                            objCaja.montoUsd = CDec(objCaja.montoSoles * TmpTipoCambio)
                        Case "EXTRANJERO"
                            objCaja.moneda = 2
                            objCaja.tipoCambio = i.GetValue("tipocambio")
                            objCaja.montoUsd = CDec(i.GetValue("montoME"))
                    End Select


                    objCaja.estado = "P"
                    objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumeroGuia.Text & " fecha: " & txtFecha.Value
                    objCaja.entregado = "SI"

                    objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                    objCaja.usuarioModificacion = usuario.IDUsuario
                    objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))
                    objCaja.NombreEntidad = (i.GetValue("ef"))
                    objCaja.fechaModificacion = DateTime.Now

                    'vuelto ticket
                    'vueltoMN = CDec(i.GetValue("vueltoMN"))
                    'vueltoME = CDec(i.GetValue("vueltoME"))

                    nDocumentoCaja.documentoCaja = objCaja
                    ListaDoc.Add(nDocumentoCaja)
                    ListaDetalleCajaEstableciiento(nDocumentoCaja.documentoCaja, empresa, estable)
                    asientoDocumentoEstable(nDocumentoCaja.documentoCaja, empresa, estable)
                End If
            End If

        Next


        Return ListaDoc
    End Function

    Function ListaDocumentoCaja(empresa As String) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        For Each i In dgvPagos.Table.Records
            If i.GetValue("empresa") = empresa Then
                If CDbl(i.GetValue("montoMN") > 0) Then
                    nDocumentoCaja = New documento
                    'DOCUMENTO
                    nDocumentoCaja.idDocumento = CInt(Me.Tag)
                    nDocumentoCaja.idEmpresa = empresa
                    nDocumentoCaja.idCentroCosto = 1
                    nDocumentoCaja.tipoDoc = GConfiguracion.TipoComprobante
                    nDocumentoCaja.fechaProceso = txtFecha.Value
                    nDocumentoCaja.nroDoc = GConfiguracion.Serie
                    nDocumentoCaja.idOrden = Nothing
                    nDocumentoCaja.tipoOperacion = "01"
                    nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
                    nDocumentoCaja.fechaActualizacion = DateTime.Now

                    'DOCUMENTO CAJA
                    objCaja = New documentoCaja
                    objCaja.idDocumento = 0
                    objCaja.periodo = PeriodoGeneral
                    If txtCliente.Text.Trim.Length > 0 Then
                        objCaja.codigoProveedor = lblNumeroDoc
                    End If
                    objCaja.idEmpresa = empresa
                    objCaja.idEstablecimiento = 1
                    objCaja.fechaProceso = txtFecha.Value
                    objCaja.fechaCobro = txtFecha.Value
                    objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                    If txtCliente.Text.Trim.Length > 0 Then
                        objCaja.IdProveedor = txtCliente.Tag
                    End If
                    objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
                    objCaja.codigoLibro = "01"
                    objCaja.tipoDocPago = cboTipoDoc.SelectedValue
                    objCaja.NumeroDocumento = GConfiguracion.Serie
                    objCaja.numeroOperacion = i.GetValue("numOper")

                    objCaja.montoSoles = CDec(i.GetValue("montoMN"))
                    Select Case i.GetValue("moneda")
                        Case "NACIONAL"
                            objCaja.moneda = 1
                            objCaja.tipoCambio = TmpTipoCambio
                            objCaja.montoUsd = CDec(objCaja.montoSoles * TmpTipoCambio)
                        Case "EXTRANJERO"
                            objCaja.moneda = 2
                            objCaja.tipoCambio = i.GetValue("tipocambio")
                            objCaja.montoUsd = CDec(i.GetValue("montoME"))
                    End Select


                    objCaja.estado = "P"
                    objCaja.glosa = "Por ventas directa " & "nro. " & "-" & txtNumeroGuia.Text & " fecha: " & txtFecha.Value
                    objCaja.entregado = "SI"

                    objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                    objCaja.usuarioModificacion = usuario.IDUsuario
                    objCaja.entidadFinanciera = CInt(i.GetValue("idEntidad"))
                    objCaja.NombreEntidad = (i.GetValue("ef"))
                    objCaja.fechaModificacion = DateTime.Now

                    'vuelto ticket
                    'vueltoMN = CDec(i.GetValue("vueltoMN"))
                    'vueltoME = CDec(i.GetValue("vueltoME"))

                    nDocumentoCaja.documentoCaja = objCaja
                    ListaDoc.Add(nDocumentoCaja)
                    ListaDetalleCaja(nDocumentoCaja.documentoCaja, empresa)
                    asientoDocumento(nDocumentoCaja.documentoCaja, empresa)
                End If
            End If
            
        Next

        Return ListaDoc
    End Function


    Sub asientoDocumento(doc As documentoCaja, empresa As String)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros


        ef = efSA.GetUbicar_estadosFinancierosPorID(doc.entidadFinanciera)

        asiento = AsientoTransito(doc.montoSoles, doc.montoUsd, empresa)

        ListaAsientonTransito.Add(asiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = TXTcOMPRADOR.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

    End Sub

    Sub asientoDocumentoEstable(doc As documentoCaja, empresa As String, estable As Integer)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros


        ef = efSA.GetUbicar_estadosFinancierosPorID(doc.entidadFinanciera)

        asiento = AsientoTransitoEstablecimiento(doc.montoSoles, doc.montoUsd, empresa, estable)

        ListaAsientonTransito.Add(asiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = TXTcOMPRADOR.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

    End Sub


    Private Sub ListaDetalleCaja(doc As documentoCaja, empresa As String)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As ListViewItem In lsvPagosRegistrados.Items
            If i.SubItems(6).Text = empresa Then
                If doc.NombreEntidad = i.SubItems(1).Text Then
                    obj = New documentoCajaDetalle
                    obj.fecha = Date.Now
                    obj.idItem = CInt(i.SubItems(2).Text)
                    obj.DetalleItem = i.SubItems(3).Text
                    obj.montoSoles = CDbl(i.SubItems(4).Text)
                    obj.montoUsd = CDbl(i.SubItems(5).Text)

                    Select Case doc.moneda
                        Case 1
                            obj.diferTipoCambio = TmpTipoCambio
                            obj.tipoCambioTransacc = TmpTipoCambio
                        Case 2
                            obj.diferTipoCambio = doc.tipoCambio
                            obj.tipoCambioTransacc = doc.tipoCambio
                    End Select


                    obj.entregado = "SI"
                    obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                    obj.usuarioModificacion = usuario.IDUsuario
                    obj.documentoAfectado = CInt(Me.Tag)
                    obj.fechaModificacion = DateTime.Now
                    lista.Add(obj)
                End If
            End If
            
        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Private Sub ListaDetalleCajaEstableciiento(doc As documentoCaja, empresa As String, estable As Integer)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As ListViewItem In lsvPagosRegistrados.Items
            If i.SubItems(6).Text = empresa And i.SubItems(7).Text = estable Then
                If doc.NombreEntidad = i.SubItems(1).Text Then
                    obj = New documentoCajaDetalle
                    obj.fecha = Date.Now
                    obj.idItem = CInt(i.SubItems(2).Text)
                    obj.DetalleItem = i.SubItems(3).Text
                    obj.montoSoles = CDbl(i.SubItems(4).Text)
                    obj.montoUsd = CDbl(i.SubItems(5).Text)

                    Select Case doc.moneda
                        Case 1
                            obj.diferTipoCambio = TmpTipoCambio
                            obj.tipoCambioTransacc = TmpTipoCambio
                        Case 2
                            obj.diferTipoCambio = doc.tipoCambio
                            obj.tipoCambioTransacc = doc.tipoCambio
                    End Select


                    obj.entregado = "SI"
                    obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                    obj.usuarioModificacion = usuario.IDUsuario
                    obj.documentoAfectado = CInt(Me.Tag)
                    obj.fechaModificacion = DateTime.Now
                    lista.Add(obj)
                End If
            End If

        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Private Sub DetallePagosCajaByIdEntidad(doc As documento)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As ListViewItem In lsvPagosRegistrados.Items

            If doc.documentoCaja.NombreEntidad = i.SubItems(1).Text Then
                obj = New documentoCajaDetalle
                doc.idEstablecimientoTransaccion = Val(i.SubItems(11).Text)
                obj.idEstablecimientoTransaccion = Val(i.SubItems(11).Text)
                obj.fecha = Date.Now
                obj.idItem = CInt(i.SubItems(2).Text)
                obj.DetalleItem = i.SubItems(3).Text
                obj.montoSoles = CDbl(i.SubItems(4).Text)
                obj.montoUsd = CDbl(i.SubItems(5).Text)

                Select Case doc.documentoCaja.moneda
                    Case 1
                        obj.diferTipoCambio = TmpTipoCambio
                        obj.tipoCambioTransacc = TmpTipoCambio
                    Case 2
                        obj.diferTipoCambio = doc.documentoCaja.tipoCambio
                        obj.tipoCambioTransacc = doc.documentoCaja.tipoCambio
                End Select


                obj.entregado = "SI"
                obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                obj.usuarioModificacion = usuario.IDUsuario
                obj.documentoAfectado = CInt(Me.Tag)
                obj.fechaModificacion = DateTime.Now
                lista.Add(obj)
            End If
        Next
        doc.documentoCaja.documentoCajaDetalle = lista
    End Sub

    Sub AsientoVenta(listadoExistencias As List(Of documentoventaAbarrotesDet), empresa As String)
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoExistencias _
                         Into totalMN = Sum(n.importeMN),
                         TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente2.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = ""
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = usuario.IDUsuario
        Else
            nAsiento.usuarioActualizacion = usuario.IDUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)



        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoExistencias _
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoExistencias
            If i.IdEmpresa = empresa Then
                nMovimiento = New movimiento
                nMovimiento.cuenta = "70111"
                nMovimiento.descripcion = i.DetalleItem
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                nMovimiento.monto = CDec(i.montokardex)
                nMovimiento.montoUSD = CDec(i.montokardexUS)
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
                nAsiento.movimiento.Add(nMovimiento)
            End If
            '     MV_Item_Transito(i.DetalleItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)
            
        Next
        'For Each r As Record In dgvCompra.Table.Records
        '    MV_Item_Transito(r.GetValue("item"), r.GetValue("costoMN"), r.GetValue("costoME"), r.GetValue("tipoExistencia"))
        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "70111"
        '    nMovimiento.descripcion = r.GetValue("item")
        '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        '    nMovimiento.monto = CDec(r.GetValue("vcmn"))
        '    nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    nMovimiento.usuarioActualizacion = "Jiuni"
        '    nAsiento.movimiento.Add(nMovimiento)
        'Next

    End Sub

    Sub AsientoVenta_Multi(listadoExistencias As List(Of documentoventaAbarrotesDet), empresa As String, estable As Integer)
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoExistencias _
                         Into totalMN = Sum(n.importeMN),
                         TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = empresa
        nAsiento.idCentroCostos = estable
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente2.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = ""
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = usuario.IDUsuario
        Else
            nAsiento.usuarioActualizacion = usuario.IDUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)



        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoExistencias _
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoExistencias
            If i.IdEmpresa = empresa And i.IdEstablecimiento = estable Then
                nMovimiento = New movimiento
                nMovimiento.cuenta = "70111"
                nMovimiento.descripcion = i.DetalleItem
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                nMovimiento.monto = CDec(i.montokardex)
                nMovimiento.montoUSD = CDec(i.montokardexUS)
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
                nAsiento.movimiento.Add(nMovimiento)
            End If
            '     MV_Item_Transito(i.DetalleItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)

        Next
        'For Each r As Record In dgvCompra.Table.Records
        '    MV_Item_Transito(r.GetValue("item"), r.GetValue("costoMN"), r.GetValue("costoME"), r.GetValue("tipoExistencia"))
        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "70111"
        '    nMovimiento.descripcion = r.GetValue("item")
        '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        '    nMovimiento.monto = CDec(r.GetValue("vcmn"))
        '    nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    nMovimiento.usuarioActualizacion = "Jiuni"
        '    nAsiento.movimiento.Add(nMovimiento)
        'Next

    End Sub

    Function AsientoVentaByDocumento(listadoExistencias As List(Of documentoventaAbarrotesDet), empresa As String, estable As Integer) As List(Of asiento)
        Dim listaRetorno As New List(Of asiento)
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento
        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0

        listaRetorno = New List(Of asiento)

        Dim SumaCliente = Aggregate n In listadoExistencias _
                         Into totalMN = Sum(n.importeMN),
                         TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = empresa
        nAsiento.idCentroCostos = estable
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente2.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "Venta Directa"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = usuario.IDUsuario
        Else
            nAsiento.usuarioActualizacion = usuario.IDUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)



        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoExistencias _
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoExistencias
            'If i.IdEmpresa = empresa And i.IdEstablecimiento = estable Then
            nMovimiento = New movimiento
            nMovimiento.cuenta = "70111"
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = "Jiuni"
            nAsiento.movimiento.Add(nMovimiento)
            'End If
            '     MV_Item_Transito(i.DetalleItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)

        Next
        'For Each r As Record In dgvCompra.Table.Records
        '    MV_Item_Transito(r.GetValue("item"), r.GetValue("costoMN"), r.GetValue("costoME"), r.GetValue("tipoExistencia"))
        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "70111"
        '    nMovimiento.descripcion = r.GetValue("item")
        '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        '    nMovimiento.monto = CDec(r.GetValue("vcmn"))
        '    nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    nMovimiento.usuarioActualizacion = "Jiuni"
        '    nAsiento.movimiento.Add(nMovimiento)
        'Next
        listaRetorno.Add(nAsiento)
        Return listaRetorno
    End Function

    Sub AsientoVentaServicios(listadoServicios As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoServicios _
                    Into totalMN = Sum(n.importeMN),
                    TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente2.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        'nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = "Jiuni"
        Else
            nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoServicios _
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoServicios
            nMovimiento = New movimiento
            nMovimiento.cuenta = i.idItem
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = "Jiuni"
            nAsiento.movimiento.Add(nMovimiento)
        Next
        'For Each r As Record In dgvCompra.Table.Records
        '    MV_Item_Transito(r.GetValue("item"), r.GetValue("costoMN"), r.GetValue("costoME"), r.GetValue("tipoExistencia"))
        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "70111"
        '    nMovimiento.descripcion = r.GetValue("item")
        '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        '    nMovimiento.monto = CDec(r.GetValue("vcmn"))
        '    nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    nMovimiento.usuarioActualizacion = "Jiuni"
        '    nAsiento.movimiento.Add(nMovimiento)
        'Next

    End Sub

    Public Function AS_Cliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1212",
              .descripcion = txtCliente2.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub Grabar2()
        Dim lista As New List(Of documento)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim listaComprobantesCaja As New List(Of documento)
        Dim DocCaja As New documento

        Dim c = listaEstablecimientoCanasta.Distinct.ToList
        lista = New List(Of documento)

        Dim listadoPagos = ListadoCajaPagos()
        For Each i In c
            DocCaja = New documento
            DocCaja = GrabarEstablecimiento1(i.idEmpresa, i.idCentroCosto)

            'Dim pagoestable = listadoPagos.Where(Function(o) o.idEstablecimientoTransaccion = DocCaja.idCentroCosto).ToList
            'DocCaja.ListaCustomDocumento = pagoestable

            lista.Add(DocCaja)
        Next
        lista(0).ListaCustomDocumento = listadoPagos



        'DocCaja.ListaCustomDocumento = ListadoCajaPagos()
        ventaSA.GrabarVentaMultiEmpresa(lista)
        MessageBox.Show("Venta grabada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Public Sub Grabar()
        Dim lista As New List(Of documento)
        Dim ventaSA As New documentoVentaAbarrotesSA

        Dim c = listaEstablecimientoCanasta.Distinct.ToList

        lista = New List(Of documento)
        lista.Add(GrabarEmpresa1)
        lista.Add(GrabarEmpresa2)

        ventaSA.GrabarVentaMultiEmpresa(lista)
        MessageBox.Show("Venta grabada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Function GrabarEmpresa1() As documento
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)


        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.TieneCotizacion = TieneCotizacionInfo
        ndocumento.idEmpresa = "20392657020"
        ndocumento.idCentroCosto = 1
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.tipoOperacion = "01"
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        nDocumentoVenta = New documentoventaAbarrotes With {
            .IdDocumentoCotizacion = IdDocumentoCotizacion,
                  .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = "20392657020",
                  .idEstablecimiento = 1,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = PeriodoGeneral,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = Nothing,
                  .nombrePedido = TXTcOMPRADOR.Text.Trim,
                  .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2"),
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO,
                  .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                  .glosa = "Venta",
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("empresa") = "20392657020" Then
                objDocumentoVentaDet = New documentoventaAbarrotesDet
                Select Case r.GetValue("valPago")
                    Case "Pagado"
                        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                    Case Else
                        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End Select
                objDocumentoVentaDet.IdEmpresa = "20392657020"
                objDocumentoVentaDet.IdEstablecimiento = 1 ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
                objDocumentoVentaDet.FechaDoc = txtFecha.Value
                objDocumentoVentaDet.Serie = GConfiguracion.Serie
                objDocumentoVentaDet.NumDoc = Nothing
                objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
                If r.GetValue("tipoExistencia") = "GS" Then
                    objDocumentoVentaDet.idAlmacenOrigen = Nothing
                    objDocumentoVentaDet.tipoVenta = Nothing
                Else
                    objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                    objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
                End If
                objDocumentoVentaDet.establecimientoOrigen = 1
                objDocumentoVentaDet.cuentaOrigen = Nothing
                objDocumentoVentaDet.idItem = r.GetValue("idProducto")
                objDocumentoVentaDet.DetalleItem = r.GetValue("item")
                objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
                objDocumentoVentaDet.destino = r.GetValue("gravado")
                objDocumentoVentaDet.unidad1 = r.GetValue("um")
                If CDec(r.GetValue("cantidad")) <= 0 Then
                    Throw New Exception("Debe ingresar un cantidad mayor a cero.")

                End If

                If CDec(r.GetValue("totalmn")) <= 0 Then
                    Throw New Exception("El importe de venta debe ser mayor a cero.")

                End If

                objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
                objDocumentoVentaDet.unidad2 = Nothing
                objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
                objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
                objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
                objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
                objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
                objDocumentoVentaDet.descuentoMN = 0
                objDocumentoVentaDet.descuentoME = 0

                objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
                objDocumentoVentaDet.montoIsc = 0
                objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
                objDocumentoVentaDet.otrosTributos = 0
                '**********************************************************************************
                objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
                objDocumentoVentaDet.montoIscUS = 0
                objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
                objDocumentoVentaDet.otrosTributosUS = 0
                '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
                objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
                '**********************************************************************************
                objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
                objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
                objDocumentoVentaDet.fechaVcto = Nothing

                objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value())
                objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value())

                Dim cat = r.GetValue("cat")
                If Not IsNothing(cat) Then
                    If cat.ToString.Trim.Length > 0 Then
                        objDocumentoVentaDet.categoria = r.GetValue("cat")
                    Else
                        objDocumentoVentaDet.categoria = Nothing
                    End If
                Else
                    objDocumentoVentaDet.categoria = Nothing
                End If


                objDocumentoVentaDet.preEvento = Nothing
                objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoVentaDet.fechaModificacion = Date.Now

                objDocumentoVentaDet.Glosa = "Venta" ' txtGlosa.Text.Trim
                ListaDetalle.Add(objDocumentoVentaDet)
            End If
           
        Next
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle


        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle _
                                                               Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        If listaExistencias.Count > 0 Then
            AsientoVenta(listaExistencias, "20392657020")
        End If

        ndocumento.ListaCustomDocumento = ListaDocumentoCajaE1("20392657020")

        Return ndocumento

        'If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
        '    Dim listaTotalAlmacen As Integer = VentaSA.SaveVentaTicketPS(ndocumento, Nothing)

        '    If (Not IsNothing(listaTotalAlmacen)) Then
        '        lblEstado.Text = "venta registrada!"
        '        Dim strNumDoc As String = Convert.ToInt32(docVentaSA.GetUbicar_documentoventaAbarrotesPorID(listaTotalAlmacen).numeroDoc)
        '        Dim statusForm As New frmMensajeCodigoVenta
        '        statusForm.StartPosition = FormStartPosition.CenterScreen
        '        statusForm.lblMensaje.Text = strNumDoc '.Replace("0", "")
        '        statusForm.ShowDialog()
        '        Dispose()
        '    Else
        '        lblEstado.Text = "Excedio la cantidad de venta"
        '        PanelError.Visible = True
        '        Timer1.Enabled = True
        '        TiempoEjecutar(10)
        '        '  limpiarCajas()
        '    End If
        'Else
        '    Throw New Exception("Debe verificar que las celdas estan completas!")
        'End If

    End Function

    Function GrabarEstablecimiento1(empresa As String, estable As Integer) As documento
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.TieneCotizacion = TieneCotizacionInfo
        ndocumento.idEmpresa = empresa
        ndocumento.idCentroCosto = estable
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.tipoOperacion = "01"
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        nDocumentoVenta = New documentoventaAbarrotes With {
            .IdDocumentoCotizacion = IdDocumentoCotizacion,
           .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = empresa,
                  .idEstablecimiento = estable,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = PeriodoGeneral,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = Nothing,
                  .nombrePedido = TXTcOMPRADOR.Text.Trim,
                  .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2"),
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA,
                  .estadoCobro = TIPO_VENTA.PAGO.COBRADO,
                  .glosa = "Venta",
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        Dim baseimponible As Decimal = 0
        Dim baseimponibleME As Decimal = 0
        Dim IGV As Decimal = 0
        Dim IGVME As Decimal = 0

        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("empresa") = empresa And r.GetValue("estable") = estable Then

                baseimponible += CDec(r.GetValue("vcmn"))
                baseimponibleME += CDec(r.GetValue("vcme"))
                IGV += CDec(r.GetValue("igvmn"))
                IGVME += CDec(r.GetValue("igvme"))

                objDocumentoVentaDet = New documentoventaAbarrotesDet
                Select Case r.GetValue("valPago")
                    Case "Pagado"
                        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                    Case Else
                        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End Select
                objDocumentoVentaDet.IdEmpresa = empresa
                objDocumentoVentaDet.IdEstablecimiento = estable  ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
                objDocumentoVentaDet.FechaDoc = txtFecha.Value
                objDocumentoVentaDet.Serie = GConfiguracion.Serie
                objDocumentoVentaDet.NumDoc = Nothing
                objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
                If r.GetValue("tipoExistencia") = "GS" Then
                    objDocumentoVentaDet.idAlmacenOrigen = Nothing
                    objDocumentoVentaDet.tipoVenta = Nothing
                Else
                    objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                    objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
                End If
                objDocumentoVentaDet.establecimientoOrigen = estable
                objDocumentoVentaDet.cuentaOrigen = Nothing
                objDocumentoVentaDet.idItem = r.GetValue("idProducto")
                objDocumentoVentaDet.DetalleItem = r.GetValue("item")
                objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
                objDocumentoVentaDet.destino = r.GetValue("gravado")
                objDocumentoVentaDet.unidad1 = r.GetValue("um")
                If CDec(r.GetValue("cantidad")) <= 0 Then
                    Throw New Exception("Debe ingresar un cantidad mayor a cero.")

                End If

                If CDec(r.GetValue("totalmn")) <= 0 Then
                    Throw New Exception("El importe de venta debe ser mayor a cero.")

                End If

                objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
                objDocumentoVentaDet.unidad2 = Nothing
                objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
                objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
                objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
                objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
                objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
                objDocumentoVentaDet.descuentoMN = 0
                objDocumentoVentaDet.descuentoME = 0

                objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
                objDocumentoVentaDet.montoIsc = 0
                objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
                objDocumentoVentaDet.otrosTributos = 0
                '**********************************************************************************
                objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
                objDocumentoVentaDet.montoIscUS = 0
                objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
                objDocumentoVentaDet.otrosTributosUS = 0
                '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
                objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
                '**********************************************************************************
                objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
                objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
                objDocumentoVentaDet.fechaVcto = Nothing

                objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value())
                objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value())

                Dim cat = r.GetValue("cat")
                If Not IsNothing(cat) Then
                    If cat.ToString.Trim.Length > 0 Then
                        objDocumentoVentaDet.categoria = r.GetValue("cat")
                    Else
                        objDocumentoVentaDet.categoria = Nothing
                    End If
                Else
                    objDocumentoVentaDet.categoria = Nothing
                End If


                objDocumentoVentaDet.preEvento = Nothing
                objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoVentaDet.fechaModificacion = Date.Now

                objDocumentoVentaDet.Glosa = "Venta" ' txtGlosa.Text.Trim
                ListaDetalle.Add(objDocumentoVentaDet)
            End If

        Next

        ndocumento.documentoventaAbarrotes.bi01 = baseimponible
        ndocumento.documentoventaAbarrotes.bi02 = 0
        ndocumento.documentoventaAbarrotes.igv01 = IGV
        ndocumento.documentoventaAbarrotes.igv02 = 0
        ndocumento.documentoventaAbarrotes.bi01us = baseimponibleME
        ndocumento.documentoventaAbarrotes.bi02us = 0
        ndocumento.documentoventaAbarrotes.igv01us = IGVME
        ndocumento.documentoventaAbarrotes.igv02us = 0
        ndocumento.documentoventaAbarrotes.ImporteNacional = baseimponible + IGV
        ndocumento.documentoventaAbarrotes.ImporteExtranjero = baseimponibleME + IGVME

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle


        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle _
                                                               Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        If listaExistencias.Count > 0 Then
            ndocumento.asiento = AsientoVentaByDocumento(listaExistencias, empresa, estable)
        End If

        'ndocumento.ListaCustomDocumento = ListaPagosEstablecimiento(empresa, estable)

        Return ndocumento

        'If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
        '    Dim listaTotalAlmacen As Integer = VentaSA.SaveVentaTicketPS(ndocumento, Nothing)

        '    If (Not IsNothing(listaTotalAlmacen)) Then
        '        lblEstado.Text = "venta registrada!"
        '        Dim strNumDoc As String = Convert.ToInt32(docVentaSA.GetUbicar_documentoventaAbarrotesPorID(listaTotalAlmacen).numeroDoc)
        '        Dim statusForm As New frmMensajeCodigoVenta
        '        statusForm.StartPosition = FormStartPosition.CenterScreen
        '        statusForm.lblMensaje.Text = strNumDoc '.Replace("0", "")
        '        statusForm.ShowDialog()
        '        Dispose()
        '    Else
        '        lblEstado.Text = "Excedio la cantidad de venta"
        '        PanelError.Visible = True
        '        Timer1.Enabled = True
        '        TiempoEjecutar(10)
        '        '  limpiarCajas()
        '    End If
        'Else
        '    Throw New Exception("Debe verificar que las celdas estan completas!")
        'End If

    End Function

    Function GrabarEmpresa2() As documento
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)


        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.TieneCotizacion = TieneCotizacionInfo
        ndocumento.idEmpresa = "20111444444"
        ndocumento.idCentroCosto = 1
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.tipoOperacion = "01"
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        nDocumentoVenta = New documentoventaAbarrotes With {
            .IdDocumentoCotizacion = IdDocumentoCotizacion,
                  .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = "20111444444",
                  .idEstablecimiento = 1,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = PeriodoGeneral,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = Nothing,
                  .nombrePedido = TXTcOMPRADOR.Text.Trim,
                  .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2"),
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO,
                  .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                  .glosa = "Venta",
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("empresa") = "20111444444" Then
                objDocumentoVentaDet = New documentoventaAbarrotesDet
                Select Case r.GetValue("valPago")
                    Case "Pagado"
                        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                    Case Else
                        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End Select
                objDocumentoVentaDet.IdEmpresa = "20111444444"
                objDocumentoVentaDet.IdEstablecimiento = 1 ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
                objDocumentoVentaDet.FechaDoc = txtFecha.Value
                objDocumentoVentaDet.Serie = GConfiguracion.Serie
                objDocumentoVentaDet.NumDoc = Nothing
                objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
                If r.GetValue("tipoExistencia") = "GS" Then
                    objDocumentoVentaDet.idAlmacenOrigen = Nothing
                    objDocumentoVentaDet.tipoVenta = Nothing
                Else
                    objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                    objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
                End If
                objDocumentoVentaDet.establecimientoOrigen = 1
                objDocumentoVentaDet.cuentaOrigen = Nothing
                objDocumentoVentaDet.idItem = r.GetValue("idProducto")
                objDocumentoVentaDet.DetalleItem = r.GetValue("item")
                objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
                objDocumentoVentaDet.destino = r.GetValue("gravado")
                objDocumentoVentaDet.unidad1 = r.GetValue("um")
                If CDec(r.GetValue("cantidad")) <= 0 Then
                    Throw New Exception("Debe ingresar un cantidad mayor a cero.")

                End If

                If CDec(r.GetValue("totalmn")) <= 0 Then
                    Throw New Exception("El importe de venta debe ser mayor a cero.")

                End If

                objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
                objDocumentoVentaDet.unidad2 = Nothing
                objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
                objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
                objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
                objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
                objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
                objDocumentoVentaDet.descuentoMN = 0
                objDocumentoVentaDet.descuentoME = 0

                objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
                objDocumentoVentaDet.montoIsc = 0
                objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
                objDocumentoVentaDet.otrosTributos = 0
                '**********************************************************************************
                objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
                objDocumentoVentaDet.montoIscUS = 0
                objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
                objDocumentoVentaDet.otrosTributosUS = 0
                '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
                objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
                '**********************************************************************************
                objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
                objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
                objDocumentoVentaDet.fechaVcto = Nothing

                objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value())
                objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value())

                Dim cat = r.GetValue("cat")
                If Not IsNothing(cat) Then
                    If cat.ToString.Trim.Length > 0 Then
                        objDocumentoVentaDet.categoria = r.GetValue("cat")
                    Else
                        objDocumentoVentaDet.categoria = Nothing
                    End If
                Else
                    objDocumentoVentaDet.categoria = Nothing
                End If


                objDocumentoVentaDet.preEvento = Nothing
                objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoVentaDet.fechaModificacion = Date.Now

                objDocumentoVentaDet.Glosa = "Venta" ' txtGlosa.Text.Trim
                ListaDetalle.Add(objDocumentoVentaDet)
            End If

        Next
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle


        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle _
                                                               Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        If listaExistencias.Count > 0 Then
            AsientoVenta(listaExistencias, "20111444444")
        End If

        ndocumento.ListaCustomDocumento = ListaDocumentoCaja("20111444444")

        Return ndocumento

        'If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
        '    Dim listaTotalAlmacen As Integer = VentaSA.SaveVentaTicketPS(ndocumento, Nothing)

        '    If (Not IsNothing(listaTotalAlmacen)) Then
        '        lblEstado.Text = "venta registrada!"
        '        Dim strNumDoc As String = Convert.ToInt32(docVentaSA.GetUbicar_documentoventaAbarrotesPorID(listaTotalAlmacen).numeroDoc)
        '        Dim statusForm As New frmMensajeCodigoVenta
        '        statusForm.StartPosition = FormStartPosition.CenterScreen
        '        statusForm.lblMensaje.Text = strNumDoc '.Replace("0", "")
        '        statusForm.ShowDialog()
        '        Dispose()
        '    Else
        '        lblEstado.Text = "Excedio la cantidad de venta"
        '        PanelError.Visible = True
        '        Timer1.Enabled = True
        '        TiempoEjecutar(10)
        '        '  limpiarCajas()
        '    End If
        'Else
        '    Throw New Exception("Debe verificar que las celdas estan completas!")
        'End If

    End Function

    'Sub UpdateVenta()
    '    Dim VentaSA As New documentoVentaAbarrotesSA
    '    Dim ndocumento As New documento()
    '    Dim DocCaja As New documento

    '    Dim ListaTotales As New List(Of totalesAlmacen)
    '    Dim ListaDeleteEO As New List(Of totalesAlmacen)

    '    Dim nDocumentoVenta As New documentoventaAbarrotes()
    '    Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
    '    Dim entidadSA As New entidadSA
    '    Dim entidad As New entidad

    '    Dim asientoSA As New AsientoSA
    '    ' Dim ListaAsiento As New List(Of asiento)
    '    Dim nAsiento As New asiento
    '    Dim nMovimiento As New movimiento

    '    Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
    '    With ndocumento
    '        .Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        .idDocumento = lblIdDocumento.Text
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idCentroCosto = GEstableciento.IdEstablecimiento
    '        If IsNothing(GProyectos) Then
    '        Else
    '            .idProyecto = GProyectos.IdProyectoActividad
    '        End If
    '        .tipoDoc = GConfiguracion.TipoComprobante
    '        .fechaProceso = fecha
    '        .nroDoc = txtSerie & "-" & NumeroComprobante
    '        .idOrden = Nothing ' Me.IdOrden
    '        .tipoOperacion = "01"
    '        .usuarioActualizacion = "NN"
    '        .fechaActualizacion = DateTime.Now
    '    End With

    '    With nDocumentoVenta
    '        .idDocumento = lblIdDocumento.Text
    '        If IsNothing(GProyectos) Then
    '        Else
    '            .idPadre = GProyectos.IdProyectoActividad
    '        End If
    '        .TipoDocNumeracion = Nothing
    '        .codigoLibro = "8"
    '        .tipoDocumento = txtIdComprobante
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idEstablecimiento = GEstableciento.IdEstablecimiento
    '        .fechaDoc = fecha ' PERIODO
    '        .fechaPeriodo = PeriodoGeneral
    '        .serie = txtSerie
    '        .numeroDoc = NumeroComprobante
    '        .nombrePedido = txtCliente.Text
    '        ' .nombrePedido = txtPedidoRef.Text
    '        .moneda = IIf(cboMoneda.SelectedValue, "1", "2")
    '        .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
    '        .tipoCambio = txtTipoCambio.Value

    '        '****************** DESTINO EN SOLES ************************************************************************
    '        .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
    '        .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))

    '        .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
    '        .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))

    '        .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
    '        .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))

    '        .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
    '        .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))

    '        '****************************************************************************************************************

    '        '****************** DESTINO EN DOLARES ************************************************************************
    '        .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
    '        .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))

    '        .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
    '        .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))

    '        .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
    '        .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))

    '        .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
    '        .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))

    '        '****************************************************************************************************************
    '        .ImporteNacional = IIf(txtTotalPedidomn.Text = 0 Or txtTotalPedidomn.Text = "0.00", CDec(0.0), CDec(txtTotalPedidomn.Text))
    '        .ImporteExtranjero = IIf(txtTotalPedidome.Text = 0 Or txtTotalPedidome.Text = "0.00", CDec(0.0), CDec(txtTotalPedidome.Text))

    '        .tipoVenta = TIPO_VENTA.VENTA_AL_TICKET
    '        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
    '        .glosa = GlosaVenta()
    '        '    .RE = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
    '        ' = TIPO_VENTA.VENTA_PAGADA
    '        ' .DocumentoSustentado = "S"
    '        .usuarioActualizacion = "Jiuni"
    '        .fechaActualizacion = DateTime.Now
    '    End With
    '    ndocumento.documentoventaAbarrotes = nDocumentoVenta

    '    For Each i As DataGridViewRow In dgvNuevoDoc.Rows

    '        Dim almacenSA As New almacenSA
    '        objDocumentoVentaDet = New documentoventaAbarrotesDet
    '        objDocumentoVentaDet.idDocumento = lblIdDocumento.Text
    '        objDocumentoVentaDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
    '        objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
    '        objDocumentoVentaDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
    '        objDocumentoVentaDet.FechaDoc = fecha

    '        objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
    '        objDocumentoVentaDet.idAlmacenOrigen = CDec(dgvNuevoDoc.Rows(i.Index).Cells(24).Value())
    '        objDocumentoVentaDet.establecimientoOrigen = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
    '        objDocumentoVentaDet.cuentaOrigen = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
    '        objDocumentoVentaDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
    '        objDocumentoVentaDet.DetalleItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
    '        objDocumentoVentaDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
    '        objDocumentoVentaDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
    '        objDocumentoVentaDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim
    '        objDocumentoVentaDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())
    '        objDocumentoVentaDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(29).Value()
    '        objDocumentoVentaDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(31).Value()
    '        objDocumentoVentaDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
    '        objDocumentoVentaDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
    '        objDocumentoVentaDet.importeMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
    '        objDocumentoVentaDet.importeME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
    '        objDocumentoVentaDet.descuentoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(12).Value())
    '        objDocumentoVentaDet.descuentoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value())

    '        objDocumentoVentaDet.montokardex = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value())
    '        objDocumentoVentaDet.montoIsc = CDec(dgvNuevoDoc.Rows(i.Index).Cells(15).Value())
    '        objDocumentoVentaDet.montoIgv = CDec(dgvNuevoDoc.Rows(i.Index).Cells(16).Value())
    '        objDocumentoVentaDet.otrosTributos = CDec(dgvNuevoDoc.Rows(i.Index).Cells(17).Value())
    '        '**********************************************************************************
    '        objDocumentoVentaDet.montokardexUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value())
    '        objDocumentoVentaDet.montoIscUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(19).Value())
    '        objDocumentoVentaDet.montoIgvUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(20).Value())
    '        objDocumentoVentaDet.otrosTributosUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(21).Value())
    '        '  objDocumentoVentaDet.PreEvento = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
    '        objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
    '        '**********************************************************************************
    '        objDocumentoVentaDet.importeMNK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value())
    '        objDocumentoVentaDet.importeMEK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value())
    '        objDocumentoVentaDet.fechaVcto = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()), Nothing, CDate(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))

    '        objDocumentoVentaDet.salidaCostoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value()) ' CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())
    '        objDocumentoVentaDet.salidaCostoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value()) 'CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())

    '        objDocumentoVentaDet.preEvento = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(27).Value()), Nothing, dgvNuevoDoc.Rows(i.Index).Cells(27).Value())
    '        objDocumentoVentaDet.usuarioModificacion = "Jiuni"
    '        objDocumentoVentaDet.fechaModificacion = Date.Now
    '        objDocumentoVentaDet.tipoVenta = dgvNuevoDoc.Rows(i.Index).Cells(32).Value()
    '        If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
    '            objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
    '        ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
    '            objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
    '            objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
    '        End If

    '        objDocumentoVentaDet.Glosa = GlosaVenta()

    '        ListaDetalle.Add(objDocumentoVentaDet)
    '        '   End If
    '    Next

    '    ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
    '    'TOTALES ALMACEN
    '    ListaTotales = ListaTotalesAlmacen()
    '    ListaDeleteEO = ListaDeleteTotales()
    '    'DocCaja = ComprobanteCaja()

    '    VentaSA.UpdateVentaTicket(ndocumento, ListaTotales, ListaDeleteEO)
    '    lblEstado.Text = "venta modificada!"
    '    lblEstado.Image = My.Resources.ok4

    '    Dispose()
    'End Sub

    Private Sub AsientoItemPagado()
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim cajaSa As New EstadosFinancierosSA
        Try
            nAsiento = New asiento
            nAsiento.idDocumento = 0
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = CInt(txtCliente2.Tag)
            nAsiento.nombreEntidad = txtCliente2.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nAsiento.fechaProceso = txtFecha.Value
            nAsiento.codigoLibro = "14"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
            nAsiento.importeMN = TotalesXcanbeceras.TotalMN
            nAsiento.importeME = TotalesXcanbeceras.TotalME
            nAsiento.glosa = "Venta"
            nAsiento.usuarioActualizacion = "jiuni"
            nAsiento.fechaActualizacion = DateTime.Now

            For Each r As Record In dgvCompra.Table.Records
                nMovimiento = New movimiento
                nMovimiento.cuenta = cajaSa.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino).cuenta
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "1212"
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
                nAsiento.movimiento.Add(nMovimiento)
            Next
            ListaAsientonTransito.Add(nAsiento)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .idEntidad = CInt(txtCliente2.Tag)
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tipoCambio = txtTipoCambio.DecimalValue
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalMN
            .glosa = "Venta"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("tipoExistencia") <> "GS" Then
                '     If r.GetValue("almacen") <> idAlmacenVirtual Then
                documentoguiaDetalle = New documentoguiaDetalle
                If txtSerieGuia.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                Else
                    Throw New Exception("Ingrese número de serie de la guía!")
                End If
                If txtNumeroGuia.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                Else
                    Throw New Exception("Ingrese el nùmero de la guía!")
                End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.GetValue("idProducto")
                documentoguiaDetalle.descripcionItem = r.GetValue("item")
                documentoguiaDetalle.destino = r.GetValue("gravado")
                documentoguiaDetalle.unidadMedida = r.GetValue("um")
                documentoguiaDetalle.cantidad = CDec(r.GetValue("cantidad"))
                documentoguiaDetalle.precioUnitario = CDec(r.GetValue("pumn"))
                documentoguiaDetalle.precioUnitarioUS = CDec(r.GetValue("pume"))
                documentoguiaDetalle.importeMN = CDec(r.GetValue("totalmn"))
                documentoguiaDetalle.importeME = CDec(r.GetValue("totalme"))
                documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

#End Region

    Private Sub frmventaMultiempresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    Dim listaEstablecimientoCanasta As New List(Of centrocosto)
    Private Sub frmventaMultiempresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0 ' 65
        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0 '65
        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        CargarPrecios()
    End Sub

    Private Sub gridGroupingControl1_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles gridGroupingControl1.SelectedRecordsChanged
        Me.Cursor = Cursors.WaitCursor
        GridGroupingControl2.Table.Records.DeleteAll()
        If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
            UbicarUltimosPreciosXproducto(Me.gridGroupingControl1.Table.CurrentRecord)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
                    lblProducto.Text = String.Empty
                    AceptarPrecioProducto(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"))
                    If dgvCompra.Table.Records.Count > 0 Then
                        ' CalculosRecorrido()
                    End If
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()

            Dim c = listaEstablecimientoCanasta.Where(Function(o) o.idCentroCosto = Val(dgvCompra.Table.CurrentRecord.GetValue("estable"))).FirstOrDefault()
            If IsNothing(c) Then
                'listaEstablecimientoCanasta.Add(New centrocosto With {.idCentroCosto = Val(r.GetValue("estable"))})
            Else
                listaEstablecimientoCanasta.Remove(c)
            End If



        End If
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        'If e.PopupCloseType = PopupCloseType.Done Then
        '    If lsvProveedor.SelectedItems.Count > 0 Then
        '        Me.txtCliente.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
        '        txtCliente.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
        '        txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
        '        ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

        '        If TXTcOMPRADOR.Text.Trim.Length > 0 AndAlso txtCliente.Text.Trim.Length > 0 Then
        '            txtGlosa.Text = "Por " & cboTipoDoc.Text & Space(1) & Space(1) & "del comprador " & TXTcOMPRADOR.Text.Trim
        '        End If

        '        txtSerieGuia.Select()
        '        txtSerieGuia.SelectAll()
        '    End If
        'End If
        '' Set focus back to textbox.
        'If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '    Me.txtCliente.Focus()
        'End If

        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                txtCliente2.Text = lsvProveedor.Text
                txtCliente2.Tag = lsvProveedor.SelectedValue
                txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                Dim con = (ListadoProveedores.Where(Function(s) s.idEntidad = CInt(txtCliente2.Tag))).FirstOrDefault()

                If con IsNot Nothing Then
                    txtRuc.Text = con.nrodoc
                End If
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCliente2.Focus()
        End If
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumeroGuia.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerieGuia.Clear()
        End Try
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As EventArgs) Handles txtSerieGuia.LostFocus
        Try
            If txtSerieGuia.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerieGuia.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1)) = True Then

                        If Len(txtSerieGuia.Text) <= 2 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1))

                        ElseIf Len(txtSerieGuia.Text) <= 3 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 2))

                        ElseIf Len(txtSerieGuia.Text) <= 4 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 3))

                        ElseIf Len(txtSerieGuia.Text) <= 5 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 4))

                        End If
                    End If
                Else

                    txtSerieGuia.Select()
                    txtSerieGuia.Focus()
                    txtSerieGuia.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerieGuia.Select()
                txtSerieGuia.Focus()
                txtSerieGuia.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtSerieGuia.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumeroGuia.Clear()
        End Try
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As EventArgs) Handles txtNumeroGuia.LostFocus
        Try
            If txtNumeroGuia.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumeroGuia.Select()
            txtNumeroGuia.Focus()
            txtNumeroGuia.Clear()
            lblEstado.Text = "Error de formato verifique el ingreso!"
        End Try
    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb19.ButtonStateChanged
        If Not IsNothing(TotalesXcanbeceras) Then
            If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                cboMoneda.SelectedValue = 2
            ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                cboMoneda.SelectedValue = 1
            End If
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFiltrar_Click(sender As Object, e As EventArgs) Handles txtFiltrar.Click
        txtFiltrar.SelectAll()
    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltrar.Text.Trim.Length > 0 Then
                ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)


                If chempresa.Checked = True Then
                    ObtenerCanastaVentaFiltro(0, cboTipoExistencia.SelectedValue, txtFiltrar.Text.Trim)

                ElseIf chempresa.Checked = False Then

                    ObtenerCanastaVentaFiltroEmpresa(0, cboTipoExistencia.SelectedValue, txtFiltrar.Text.Trim)
                End If

                lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count
            Else
                lblEstado.Text = "Digitar un producto válido!"
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvCompra.KeyPress
        'If e.KeyChar = Convert.ToChar(Keys.Enter) Then
        '    'Como se sabe los lectores de barra al final mandan un {ENTER}
        '    'por eso una vez que lo envía aqui se haces la función que deseas realizar
        '    MessageBox.Show("ds")
        'Else
        '    'e.Handled = True

        'End If
    End Sub

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chPago" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chBonif" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        'e.Style.BackColor = Color.Yellow
                        'e.Style.TextColor = Color.Black
                        e.Style.[ReadOnly] = True
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "totalmn")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "item")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                End Select
            End If


        End If

    End Sub

    Public Sub GetExistenciaByCodigoBarRows(CodigoBarra As String)
        Dim totalSA As New TotalesAlmacenSA
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance
        datos.Clear()
        Dim existenciaSA As New detalleitemsSA
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        'Dim existencia As New detalleitems

        'existencia = existenciaSA.GetExistenciaByCodeBar(CodigoBarra)
        Dim lista = totalSA.GetProductosByAlmacenCodigo(0, CodigoBarra)

        If lista.Count > 0 Then
            Dim f As New frmSeleccionArticulosVenta(lista, CodigoBarra)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim r = CType(f.Tag, Record)

                If datos.Count > 0 Then
                    Dim precio = datos(0).Precio
                    valPUmn = precio.precioMN
                    valPUme = precio.precioME

                    With existenciaSA.InvocarProductoID(r.GetValue("idItem"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", r.GetValue("destino"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", r.GetValue("idItem"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("um", r.GetValue("unidad"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", r.GetValue("cantidad"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "01")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

                        Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", r.GetValue("puKardexmn"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", r.GetValue("puKardexme"))

                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                        '   If .tipoExistencia <> "GS" Then
                        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", r.GetValue("idalmacen"))
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                        '   End If
                        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", r.GetValue("almacen"))

                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", precio.idPrecio)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem.GetValueOrDefault)

                        Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", r.GetValue("idEmpresa"))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pagado", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("estado", "NO")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("estable", Val(r.GetValue("estable")))


                        listaEstablecimientoCanasta.Add(New centrocosto With {.idCentroCosto = Val(r.GetValue("estable")),
                                                                  .idEmpresa = r.GetValue("idEmpresa")})

                    End With

                End If

            End If
        Else
            MessageBox.Show("Código no encontrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

            Select Case ColIndex
                Case 1 ' CODIGO BARRA
                    e.TableControl.CurrentCell.EndEdit()
                    e.TableControl.Table.TableDirty = True
                    e.TableControl.Table.EndEdit()

                    Me.Cursor = Cursors.WaitCursor
                    'Dim RowIndex As Integer = e.TableControl.CurrentCell.RowIndex
                    'Dim x = Me.dgvCompra.TableModel(RowIndex, 1).CellValue
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim codBarra = r.GetValue("codBarra")
                    If Not IsNothing(codBarra) Then
                        If codBarra.ToString.Trim.Length > 0 Then
                            GetExistenciaByCodigoBarRows(codBarra)
                        End If
                    End If
                    Me.Cursor = Cursors.Arrow
                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                        If Not IsNothing(precio) Then
                            r.SetValue("pumn", precio.precioMN)
                            r.SetValue("pume", precio.precioME)
                            CalculosByEmpresa(r.GetValue("empresa"))
                        Else
                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            r.SetValue("pumn", 0)
                            r.SetValue("pume", 0)
                            CalculosByEmpresa(r.GetValue("empresa"))
                        End If


                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"

                    'Case Else
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        CalculosByEmpresa(r.GetValue("empresa"))
                    End If

                    'End Select
                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then
                        CalculosByEmpresa(r.GetValue("empresa"))
                    End If
                    'Case 5 'VALOR DE VENTA
                    '    Select Case strTipoEx
                    '        Case "GS"
                    '            CalculosGasto()
                    '        Case Else

                    '    End Select

            End Select
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor

        UbicarUltimosPreciosXproducto(Me.gridGroupingControl1.Table.CurrentRecord)

        'If gridGroupingControl1.Table.SelectedRecords.Count > 0 Then
        '    Dim f As New frmInsertarPrecio
        '    f.txtid.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))
        '    f.txtDescripcion.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion"))
        '    f.txtxmenor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenor"))
        '    f.txtxmayor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmayor"))
        '    f.txtxgranmayor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvGmayor"))
        '    f.txtalmacen.Text = txtAlmacen.Tag
        '    f.txtxmenorme.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenorme"))
        '    f.txtxmayorme.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmayorme"))
        '    f.txtxgranmayorme.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvGmayorme"))
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            'If Not txtCliente.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingresar un cliente válido"

            '    Timer1.Enabled = True
            '    PanelError.Visible = True
            '    TiempoEjecutar(10)

            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'Else
            '    lblEstado.Text = "Done cliente"

            'End If

            If (chIdentificacion.Checked = True) Then
                If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar el nombre de comprador"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done comprador"
                End If
            Else
                If Not txtCliente2.Text.Trim.Length > 0 Then

                    MessageBox.Show("Ingrese el proveedor de la compra", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCliente2.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                If txtCliente2.Text.Trim.Length > 0 Then
                    If txtCliente2.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del proveedor", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtCliente2.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If
            End If

            '***********************************************************************
            If dgvCompra.Table.Records.Count > 0 Then
                Me.lblEstado.Text = "Done!"
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    If MessageBox.Show("Está seguro de guardar la venta con fecha:" & vbCrLf & txtFecha.Value.Date, "Validar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Grabar2()
                    End If
                Else
                    'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    'If Filas > 0 Then
                    '    UpdateCompra()
                    'Else

                    '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)

                    'End If


                End If
            Else

                Me.lblEstado.Text = "Ingrese items a la canasta de venta!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

            ListaAsientonTransito = New List(Of asiento)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

        'Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
        '    UbicarUltimosPreciosXproducto(Me.gridGroupingControl1.Table.CurrentRecord)
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("item", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("um", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "01")
        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", Nothing)

        Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", Nothing)

        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
        '   If .tipoExistencia <> "GS" Then
        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", Nothing)
        'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
        '   End If
        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", Nothing)

        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", Nothing)

        Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", Nothing)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
        Me.dgvCompra.Table.AddNewRecord.EndEdit()
        'If IsNothing(GFichaUsuarios) Then
        '    If TieneCuentaFinanciera() = True Then
        '        ToolStripButton1.Image = ImageListAdv1.Images(1)
        '        dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        '        MessageBoxAdv.Show("Usuario iniciado!")
        '    Else

        '    End If
        'Else

        'End If
    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub
    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvCompra.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex
        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            If IsNothing(GFichaUsuarios) Then
                lblEstado.Text = "Debe iniciar una caja, antes de realizar esta operación.!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                'Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = False
                Exit Sub
            Else
                If style.Enabled Then
                    Dim column As Integer = Me.dgvCompra.TableModel.NameToColIndex("chPago")
                    ' Console.WriteLine("CheckBoxClicked")
                    '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                    If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                        chk = CBool(Me.dgvCompra.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                        e.TableControl.BeginUpdate()

                        e.TableControl.EndUpdate(True)
                    End If
                    If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                        Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        Dim curStatus As Boolean = Boolean.Parse(style.Text)
                        e.TableControl.BeginUpdate()

                        If curStatus Then
                            '   CheckBoxValue = False
                        End If
                        If curStatus = True Then
                            Dim RowIndex As Integer = e.Inner.RowIndex
                            Dim ColIndex As Integer = e.Inner.ColIndex

                            Me.dgvCompra.TableModel(RowIndex, 19).CellValue = "No Pagado"

                        Else
                            Dim RowIndex As Integer = e.Inner.RowIndex
                            Dim ColIndex As Integer = e.Inner.ColIndex

                            Me.dgvCompra.TableModel(RowIndex, 19).CellValue = "Pagado"



                        End If
                        e.TableControl.EndUpdate()
                        If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                        ElseIf Not ht.Contains(curStatus) Then
                        End If
                        ht.Clear()
                    End If
                End If
            End If


            Me.dgvCompra.TableControl.Refresh()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click

        If txtServicio.Text.Trim.Length > 0 Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Select Case cboDestino.Text
                Case "1-Gravado"
                    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
                Case "2-Exonerado"
                    Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "2")
            End Select

            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", txtCuenta.Text.Trim)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", txtServicio.Text.Trim)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", "09")
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "GS")
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            '   If .tipoExistencia <> "GS" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", String.Empty)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
            '   End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", String.Empty)

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Nothing)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", cboServicio.SelectedValue)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Else
            MessageBox.Show("Debe indicar el servicio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtServicio.Select()
        End If
    End Sub

    Private Sub cboServicio_Click(sender As Object, e As EventArgs) Handles cboServicio.Click

    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicio.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim servicioSA As New servicioSA
        Dim servicio As New servicio
        If cboServicio.SelectedIndex > -1 Then
            If Not IsNothing(cboServicio.SelectedValue) Then
                Dim codValue = cboServicio.SelectedValue
                'servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
                'txtCuenta.Text = servicio.cuenta
                If IsNumeric(codValue) Then
                    UbicarUltimosPreciosServicio(cboServicio.SelectedValue)

                    Dim consulta = (From a In listaServicio Where a.idServicio = cboServicio.SelectedValue).FirstOrDefault
                    txtCuenta.Text = consulta.cuenta
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub
    Private Sub ValidarItemsDuplicados(intIdItem As Integer)
        Dim colIdItem As Integer

        colIdItem = intIdItem

        For Each i In dgvCompra.Table.Records
            If colIdItem = i.GetValue("idProducto") Then
                Throw New Exception("El artículo " & i.GetValue("item") & ", ya se encuentra en la canasta. Ingrese otro")
            End If
        Next
    End Sub
    Private Sub GridGroupingControl2_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles GridGroupingControl2.TableControlCurrentCellControlDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then

                ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
                lblProducto.Text = String.Empty
                AceptarPrecioProducto(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"))
            End If
            '    txtBarCode.Select()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub


    Sub limpiarCajas()
        txtFiltrar.Clear()
        gridGroupingControl1.Table.Records.DeleteAll()
        GridGroupingControl2.Table.Records.DeleteAll()
        dgvCompra.Table.Records.DeleteAll()
    End Sub

    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarCode.KeyDown

    End Sub

    Private Sub txtBarCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarCode.KeyPress
        Me.Cursor = Cursors.WaitCursor
        If Char.IsDigit(e.KeyChar) Then
            txtBarCode.Select(txtBarCode.Text.Length, 0)
            e.Handled = False
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            'Como se sabe los lectores de barra al final mandan un {ENTER}
            'por eso una vez que lo envía aqui se haces la función que deseas realizar
            If txtBarCode.Text.Trim.Length > 0 Then
                GetExistenciaByCodigoBar(txtBarCode.Text.Trim)

            End If
        Else
            '  e.Handled = True

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBarCode_TextChanged(sender As Object, e As EventArgs) Handles txtBarCode.TextChanged

    End Sub

    Private Sub GridGroupingControl2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl2.TableControlCellClick

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub dgvPreciosServicio_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPreciosServicio.TableControlCellClick

    End Sub

    Private Sub dgvPreciosServicio_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvPreciosServicio.TableControlCurrentCellControlDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsNothing(Me.dgvPreciosServicio.Table.CurrentRecord) Then

                ' ValidarItemsDuplicados(Val(dgvPreciosServicio.Table.CurrentRecord.GetValue("idItem")))
                txtServicio.Text = String.Empty
                AgregarAcanastaServicio()
            End If
            '    txtBarCode.Select()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub chIdentificacion_CheckedChanged(sender As Object, e As EventArgs) Handles chIdentificacion.CheckedChanged
        Dim entidadSA As New entidadSA
        If chIdentificacion.Checked = True Then
            txtCliente2.Visible = False
            txtRuc2.Visible = False
            PictureBox2.Visible = False
            lblCliente.Visible = False
            TXTcOMPRADOR.Visible = True

        Else
            txtCliente2.Visible = True
            txtRuc2.Visible = True
            PictureBox2.Visible = True
            lblCliente.Visible = True
            TXTcOMPRADOR.Visible = False
            ListadoProveedores = New List(Of entidad)
            ListadoProveedores = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        End If
    End Sub

    'Private Sub TextBoxExt3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente2.KeyDown
    '    If e.Alt Then
    '        If e.KeyCode = Keys.Down Then
    '            If Not Me.popupControlContainer1.IsShowing() Then
    '                ' Let the popup align around the source textBox.
    '                Me.popupControlContainer1.ParentControl = Me.txtCliente
    '                ' Passing Point.Empty will align it automatically around the above ParentControl.
    '                Me.popupControlContainer1.ShowPopup(Point.Empty)

    '                e.Handled = True
    '            End If
    '        End If
    '    End If
    '    '' Escape should close the popup.
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.popupControlContainer1.IsShowing() Then
    '            Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        If txtCliente.Text.Trim.Length > 0 Then
    '            Me.popupControlContainer1.ParentControl = Me.txtCliente
    '            Me.popupControlContainer1.ShowPopup(Point.Empty)
    '            CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente.Text.Trim)
    '        End If
    '    End If
    'End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        If Not IsNothing(TotalesXcanbeceras) Then
            If cboMoneda.SelectedValue = 2 Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                cboMoneda.SelectedValue = 2
            Else
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                cboMoneda.SelectedValue = 1
            End If
        End If
    End Sub

    Private Sub txtCliente2_TextChanged(sender As Object, e As EventArgs) Handles txtCliente2.TextChanged
        txtCliente2.ForeColor = Color.Black
        txtCliente2.Tag = Nothing
    End Sub

    Private Sub txtCliente2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente2.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(241, 110)
            Me.popupControlContainer1.ParentControl = Me.txtCliente2
            Me.popupControlContainer1.ShowPopup(Point.Empty)

            Dim con = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtCliente2.Text))).ToList()

            lsvProveedor.DataSource = con
            lsvProveedor.DisplayMember = "nombreCompleto"
            lsvProveedor.ValueMember = "idEntidad"

            'txtCliente.DataSource = CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente.Text.Trim)
            'txtCliente.DisplayMember = "nombreCompleto"
            'txtCliente.ValueMember = "idEntidad"
        End If
        If e.KeyCode = Keys.Down Then
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(241, 110)
            Me.popupControlContainer1.ParentControl = Me.txtCliente2
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            txtCliente2.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If


        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.txtCliente2
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.popupControlContainer1.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCliente2.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.txtCliente2
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente2.Text.Trim)
            End If
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            ListadoProveedores.Add(c)
            txtCliente2.Text = c.nombreCompleto
            txtCliente2.Tag = c.idEntidad
            txtRuc2.Text = c.nrodoc
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub txtRuc2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc2.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        txtFiltrar.Clear()
        gridGroupingControl1.Table.Records.DeleteAll()
        GridGroupingControl2.Table.Records.DeleteAll()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub gridGroupingControl1_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellDoubleClick
        Try
            If GridGroupingControl2.Table.Records.Count > 0 Then
                GridGroupingControl2.Table.Records(0).SetCurrent()
                GridGroupingControl2.Table.Records(0).SetSelected(True)


                '  ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
                AgregarAcanasta(gridGroupingControl1.Table.CurrentRecord)

            Else

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Efectivo And a.moneda = TipoMoneda.Nacional _
                      And a.idEmpresa = "20111444444").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago(cajaBE)
        Else
            PanelError.Visible = True
            lblEstado.Text = "No se asigno la cuenta elegida!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click

    End Sub

    Private Sub dgvPagos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPagos.QueryCellStyleInfo

        '************************** use usa para cambiar todo la fila el color *******************************

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Or e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement
            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record) Then
                Dim r As Record = el.GetRecord
                Dim value As Object = r.GetValue("pago")
                Dim moneda As Object = r.GetValue("moneda")

                Select Case value

                    Case "EFECTIVO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF2E8B57")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "BANCO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF212121")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF484747")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "TARJETA CREDITO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFD28306")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFB67208")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select

                End Select

            End If

        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
            'If (Not IsNothing(str)) Then

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "importePendiente")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("importePendiente")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If


            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "saldo")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("saldo")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoMN")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoMN")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoME")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoME")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "tipocambio")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("tipocambio")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    'e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    'e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"



                End If
            End If
        End If
    End Sub

    Private Sub dgvPagos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPagos.TableControlCellClick

    End Sub

    Private Sub dgvPagos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPagos.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim sumaPagos As Double = 0
        'Dim sumaPagosME As Double = 0
        'Dim sumatotal As Double = 0
        'Dim numerOper As String
        'Dim CobroMN As Decimal
        'Dim CobroME As Decimal
        'Dim importeIngreso As Decimal
        'Dim tipoCambio As Decimal
        'Dim calculoSaldoME As Decimal
        'Dim entidadSA As New EstadosFinancierosSA
        'Dim sumaPagosd As Decimal = 0
        'Dim saldo As Decimal = 0
        'Try
        '    If Not IsNothing(Me.dgvPagos.Table.CurrentRecord) Then
        '        Select Case ColIndex

        '            Case 4 ' importe recibido
        '                If (dgvPagos.Table.CurrentRecord.GetValue("importePendiente") > 0) Then
        '                    For Each c In dgvPagos.Table.Records
        '                        c.SetValue("vueltoMN", 0)
        '                        c.SetValue("vueltoME", 0)

        '                        c.SetValue("montoMN", 0)
        '                        c.SetValue("montoME", 0)
        '                    Next

        '                    saldo = txtTotalPagar.DecimalValue

        '                    For Each c In dgvPagos.Table.Records

        '                        If (c.GetValue("moneda") = "NACIONAL") Then
        '                            sumaPagosd = 0
        '                            sumaPagosME = 0

        '                            Dim sumaPagosMExx As Decimal = sumaPagosME * TmpTipoCambioTransaccionCompra

        '                            importeIngreso = c.GetValue("importePendiente") ' sumaPagosd ' importe recibido
        '                            saldo = saldo - importeIngreso
        '                            If saldo < 0 Then
        '                                c.SetValue("vueltoMN", saldo * -1)
        '                                c.SetValue("vueltoME", 0.0)
        '                                c.SetValue("saldo", 0)
        '                            Else
        '                                c.SetValue("vueltoMN", 0.0)
        '                                c.SetValue("vueltoME", 0.0)
        '                                c.SetValue("saldo", saldo)
        '                            End If

        '                            If saldo > 0 Then
        '                                c.SetValue("montoMN", importeIngreso)
        '                                c.SetValue("montoME", 0.0)
        '                            Else
        '                                c.SetValue("montoMN", importeIngreso + saldo)
        '                                c.SetValue("montoME", 0.0)
        '                            End If

        '                        Else

        '                            '----------------------------------------------------------------------
        '                            'DOLARES---------------------------------------------------------------

        '                            sumaPagosd = 0
        '                            sumaPagosME = 0

        '                            Dim sumaPagosMExx As Decimal = sumaPagosME * TmpTipoCambioTransaccionCompra

        '                            importeIngreso = c.GetValue("importePendiente") ' IMPORTE EN DOLARES RECIBIDO

        '                            Dim importeME = importeIngreso * TmpTipoCambioTransaccionCompra
        '                            'Dim cargo = txtTotalPagar.DecimalValue - (sumaPagosMExx + sumaPagosd)
        '                            saldo = saldo - importeME '(sumaPagosMExx + sumaPagosd)
        '                            If saldo < 0 Then
        '                                c.SetValue("vueltoMN", saldo * -1)
        '                                c.SetValue("vueltoME", 0.0)
        '                                c.SetValue("saldo", 0)
        '                            Else
        '                                c.SetValue("vueltoMN", 0.0)
        '                                c.SetValue("vueltoME", 0.0)
        '                                c.SetValue("saldo", saldo)
        '                            End If

        '                            If saldo > 0 Then
        '                                c.SetValue("montoMN", importeME)
        '                                c.SetValue("montoME", importeIngreso)
        '                            Else
        '                                c.SetValue("montoMN", importeME + saldo)
        '                                c.SetValue("montoME", importeIngreso)
        '                            End If

        '                        End If
        '                    Next

        '                    LimpiarlsvPagos("20111444444")
        '                    LimpiarlsvPagos("20392657020")
        '                    CalculoPagos()
        '                End If

        '            Case 5 ' moneda nacional
        '                CobroMN = dgvPagos.Table.CurrentRecord.GetValue("montoMN")
        '                importeIngreso = dgvPagos.Table.CurrentRecord.GetValue("importePendiente")

        '                If (CobroMN > 0) Then
        '                    If (importeIngreso > 0) Then
        '                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                        saldoMN = 0
        '                        For Each i In dgvPagos.Table.Records
        '                            If (i.GetValue("saldo") <> 0) Then
        '                                saldoMN = i.GetValue("saldo")
        '                            End If

        '                        Next
        '                        If (saldoMN = 0) Then
        '                            numerOper = txtTotalE1.Text
        '                        Else
        '                            numerOper = saldoMN
        '                        End If



        '                        If (dgvPagos.Table.CurrentRecord.GetValue("moneda") = "EXTRANJERO") Then

        '                            CobroME = CDec(CobroMN / dgvPagos.Table.CurrentRecord.GetValue("tipocambio")).ToString("N2")

        '                            If (CobroME <> 0 And CobroMN <> 0) Then
        '                                If (CobroME <= importeIngreso) Then
        '                                    If (CobroMN <= numerOper) Then
        '                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
        '                                        tipoCambio = dgvPagos.Table.CurrentRecord.GetValue("tipocambio")
        '                                        If (numerOper <= CobroMN) Then
        '                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
        '                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
        '                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", (0.0))
        '                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroME))
        '                                        Else

        '                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
        '                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroME))
        '                                            If (numerOper > CobroMN) Then
        '                                                dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
        '                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
        '                                            Else
        '                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
        '                                                dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
        '                                            End If

        '                                        End If
        '                                        LimpiarlsvPagos("20111444444")
        '                                        LimpiarlsvPagos("20392657020")
        '                                        'lsvPagosRegistrados.Items.Clear()
        '                                        CalculoPagos()
        '                                    Else

        '                                        If (CobroMN > numerOper) Then
        '                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
        '                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
        '                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
        '                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
        '                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
        '                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                                            PanelError.Visible = True
        '                                            lblEstado.Text = "No debe exceder el monto permitido!"
        '                                            Timer1.Enabled = True
        '                                            TiempoEjecutar(10)
        '                                        Else
        '                                            dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
        '                                            tipoCambio = dgvPagos.Table.CurrentRecord.GetValue("tipocambio")
        '                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
        '                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
        '                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", (0.0))
        '                                        End If


        '                                        'lsvPagosRegistrados.Items.Clear()
        '                                        'CalculoPagos()
        '                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
        '                                        'dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
        '                                        ''dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
        '                                        'dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
        '                                        'dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
        '                                        'dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                                        'PanelError.Visible = True
        '                                        'lblEstado.Text = "No debe exceder el monto permitido!"
        '                                        'Timer1.Enabled = True
        '                                        'TiempoEjecutar(10)
        '                                    End If
        '                                Else
        '                                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                                    PanelError.Visible = True
        '                                    lblEstado.Text = "No debe exceder el monto permitido!"
        '                                    Timer1.Enabled = True
        '                                    TiempoEjecutar(10)
        '                                End If



        '                            Else
        '                                calculoSaldoME = CDec(CobroMN / TmpTipoCambioTransaccionCompra)

        '                                If (calculoSaldoME <= importeIngreso) Then


        '                                    If (CobroMN <= numerOper) Then
        '                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
        '                                        'dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
        '                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (0))
        '                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", CDec(CobroMN / TmpTipoCambioTransaccionCompra).ToString("N2"))
        '                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra).ToString("N2")) * TmpTipoCambioTransaccionCompra)
        '                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra).ToString("N2")) '((importeIngreso - CobroMN) / TmpTipoCambio).ToString("N2"))
        '                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN).ToString("N2"))
        '                                        LimpiarlsvPagos("20111444444")
        '                                        LimpiarlsvPagos("20392657020")
        '                                        'lsvPagosRegistrados.Items.Clear()
        '                                        CalculoPagos()
        '                                    Else
        '                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
        '                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
        '                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
        '                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
        '                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                                        PanelError.Visible = True
        '                                        lblEstado.Text = "No debe exceder el monto permitido!"
        '                                        Timer1.Enabled = True
        '                                        TiempoEjecutar(10)
        '                                    End If
        '                                Else
        '                                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                                    PanelError.Visible = True
        '                                    lblEstado.Text = "No debe exceder el monto permitido!"
        '                                    Timer1.Enabled = True
        '                                    TiempoEjecutar(10)
        '                                End If

        '                            End If

        '                        Else

        '                            If (CobroMN <= importeIngreso) Then
        '                                If (CobroMN <= numerOper) Then
        '                                    'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
        '                                    'dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
        '                                    'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (0))
        '                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", (0))
        '                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CobroMN).ToString("N2"))
        '                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0) '((importeIngreso - CobroMN) / TmpTipoCambio).ToString("N2"))
        '                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN).ToString("N2"))
        '                                    LimpiarlsvPagos("20111444444")
        '                                    LimpiarlsvPagos("20392657020")
        '                                    'lsvPagosRegistrados.Items.Clear()
        '                                    CalculoPagos()
        '                                Else
        '                                    'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
        '                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                                    PanelError.Visible = True
        '                                    lblEstado.Text = "No debe exceder el monto permitido!"
        '                                    Timer1.Enabled = True
        '                                    TiempoEjecutar(10)
        '                                End If
        '                            Else
        '                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
        '                                dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
        '                                dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
        '                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
        '                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
        '                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                                PanelError.Visible = True
        '                                lblEstado.Text = "No debe exceder el monto permitido!"
        '                                Timer1.Enabled = True
        '                                TiempoEjecutar(10)
        '                            End If

        '                        End If
        '                    Else
        '                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
        '                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
        '                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
        '                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
        '                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
        '                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                        PanelError.Visible = True
        '                        lblEstado.Text = "debe ingresar monto recibido!"
        '                        Timer1.Enabled = True
        '                        TiempoEjecutar(10)

        '                    End If
        '                Else
        '                    'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
        '                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
        '                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
        '                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
        '                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
        '                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
        '                    PanelError.Visible = True
        '                    lblEstado.Text = "El importe no debe ser negativo!"
        '                    Timer1.Enabled = True
        '                    TiempoEjecutar(10)
        '                End If


        '            Case 7

        '        End Select
        '    End If
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End Try


        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim sumaPagos As Double = 0
        Dim sumaPagosME As Double = 0
        Dim sumatotal As Double = 0
        Dim numerOper As String
        Dim CobroMN As Decimal
        Dim CobroME As Decimal
        Dim importeIngreso As Decimal
        Dim tipoCambio As Decimal
        Dim calculoSaldoME As Decimal
        Dim entidadSA As New EstadosFinancierosSA
        Dim sumaPagosd As Decimal = 0
        Dim saldo As Decimal = 0
        Try
            If Not IsNothing(Me.dgvPagos.Table.CurrentRecord) Then
                Select Case ColIndex

                    Case 4 ' importe recibido
                        If (dgvPagos.Table.CurrentRecord.GetValue("importePendiente") > 0) Then

                            For Each c In dgvPagos.Table.Records
                                c.SetValue("vueltoMN", 0)
                                c.SetValue("vueltoME", 0)

                                c.SetValue("montoMN", 0)
                                c.SetValue("montoME", 0)
                            Next

                            saldo = txtTotalE1.DecimalValue

                            For Each c In dgvPagos.Table.Records

                                If (c.GetValue("moneda") = "NACIONAL") Then
                                    sumaPagosd = 0
                                    sumaPagosME = 0

                                    Dim sumaPagosMExx As Decimal = sumaPagosME * TmpTipoCambioTransaccionCompra

                                    importeIngreso = c.GetValue("importePendiente") ' sumaPagosd ' importe recibido
                                    saldo = saldo - importeIngreso
                                    If saldo < 0 Then
                                        c.SetValue("vueltoMN", saldo * -1)
                                        c.SetValue("vueltoME", 0.0)
                                        c.SetValue("saldo", 0)
                                    Else
                                        c.SetValue("vueltoMN", 0.0)
                                        c.SetValue("vueltoME", 0.0)
                                        c.SetValue("saldo", saldo)
                                    End If

                                    If saldo > 0 Then
                                        c.SetValue("montoMN", importeIngreso)
                                        c.SetValue("montoME", 0.0)
                                    Else
                                        c.SetValue("montoMN", importeIngreso + saldo)
                                        c.SetValue("montoME", 0.0)
                                    End If

                                Else

                                    '----------------------------------------------------------------------
                                    'DOLARES---------------------------------------------------------------

                                    sumaPagosd = 0
                                    sumaPagosME = 0

                                    Dim sumaPagosMExx As Decimal = sumaPagosME * TmpTipoCambioTransaccionCompra

                                    importeIngreso = c.GetValue("importePendiente") ' IMPORTE EN DOLARES RECIBIDO

                                    Dim importeME = importeIngreso * TmpTipoCambioTransaccionCompra
                                    'Dim cargo = txtTotalPagar.DecimalValue - (sumaPagosMExx + sumaPagosd)
                                    saldo = saldo - importeME '(sumaPagosMExx + sumaPagosd)
                                    If saldo < 0 Then
                                        c.SetValue("vueltoMN", saldo * -1)
                                        c.SetValue("vueltoME", 0.0)
                                        c.SetValue("saldo", 0)
                                    Else
                                        c.SetValue("vueltoMN", 0.0)
                                        c.SetValue("vueltoME", 0.0)
                                        c.SetValue("saldo", saldo)
                                    End If

                                    If saldo > 0 Then
                                        c.SetValue("montoMN", importeME)
                                        c.SetValue("montoME", importeIngreso)
                                    Else
                                        c.SetValue("montoMN", importeME + saldo)
                                        c.SetValue("montoME", importeIngreso)
                                    End If

                                End If
                            Next

                            LimpiarlsvPagos("20111444444")
                            'LimpiarlsvPagos("20392657020")
                            CalculoPagos()

                        Else
                            dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                            PanelError.Visible = True
                            lblEstado.Text = "el monto no debe ser negativo!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)

                        End If
                        'End If

                    Case 5 ' moneda nacional
                        CobroMN = dgvPagos.Table.CurrentRecord.GetValue("montoMN")
                        importeIngreso = dgvPagos.Table.CurrentRecord.GetValue("importePendiente")

                        If (CobroMN > 0) Then
                            If (importeIngreso > 0) Then
                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                saldoMN = 0
                                For Each i In dgvPagos.Table.Records
                                    If (i.GetValue("saldo") <> 0) Then
                                        saldoMN = i.GetValue("saldo")
                                    End If

                                Next
                                If (saldoMN = 0) Then
                                    numerOper = txtTotalPagar.Text
                                Else
                                    numerOper = saldoMN
                                End If



                                If (dgvPagos.Table.CurrentRecord.GetValue("moneda") = "EXTRANJERO") Then

                                    CobroME = CDec(CobroMN / dgvPagos.Table.CurrentRecord.GetValue("tipocambio")).ToString("N2")

                                    If (CobroME <> 0 And CobroMN <> 0) Then
                                        If (CobroME <= importeIngreso) Then
                                            If (CobroMN <= numerOper) Then
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
                                                tipoCambio = dgvPagos.Table.CurrentRecord.GetValue("tipocambio")
                                                If (numerOper <= CobroMN) Then
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", (0.0))
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroME))
                                                Else

                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroME))
                                                    If (numerOper > CobroMN) Then
                                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
                                                    Else
                                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
                                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                    End If

                                                End If
                                                LimpiarlsvPagos("20111444444")
                                                'LimpiarlsvPagos("20392657020")
                                                'lsvPagosRegistrados.Items.Clear()
                                                CalculoPagos()
                                            Else

                                                If (CobroMN > numerOper) Then
                                                    'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                    PanelError.Visible = True
                                                    lblEstado.Text = "No debe exceder el monto permitido!"
                                                    Timer1.Enabled = True
                                                    TiempoEjecutar(10)
                                                Else
                                                    dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
                                                    tipoCambio = dgvPagos.Table.CurrentRecord.GetValue("tipocambio")
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", (0.0))
                                                End If


                                                'lsvPagosRegistrados.Items.Clear()
                                                'CalculoPagos()
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                                'dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                ''dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                'dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                'dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                'dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                'PanelError.Visible = True
                                                'lblEstado.Text = "No debe exceder el monto permitido!"
                                                'Timer1.Enabled = True
                                                'TiempoEjecutar(10)
                                            End If
                                        Else
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            PanelError.Visible = True
                                            lblEstado.Text = "No debe exceder el monto permitido!"
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If



                                    Else
                                        calculoSaldoME = CDec(CobroMN / TmpTipoCambioTransaccionCompra)

                                        If (calculoSaldoME <= importeIngreso) Then


                                            If (CobroMN <= numerOper) Then
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
                                                'dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (0))
                                                dgvPagos.Table.CurrentRecord.SetValue("montoME", CDec(CobroMN / TmpTipoCambioTransaccionCompra).ToString("N2"))
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra).ToString("N2")) * TmpTipoCambioTransaccionCompra)
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra).ToString("N2")) '((importeIngreso - CobroMN) / TmpTipoCambio).ToString("N2"))
                                                dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN).ToString("N2"))
                                                LimpiarlsvPagos("20111444444")
                                                'LimpiarlsvPagos("20392657020")
                                                'lsvPagosRegistrados.Items.Clear()
                                                CalculoPagos()
                                            Else
                                                dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                PanelError.Visible = True
                                                lblEstado.Text = "No debe exceder el monto permitido!"
                                                Timer1.Enabled = True
                                                TiempoEjecutar(10)
                                            End If
                                        Else
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            PanelError.Visible = True
                                            lblEstado.Text = "No debe exceder el monto permitido!"
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If

                                    End If

                                Else

                                    If (CobroMN <= importeIngreso) Then
                                        If (CobroMN <= numerOper) Then
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
                                            'dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (0))
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", (0))
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CobroMN).ToString("N2"))
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0) '((importeIngreso - CobroMN) / TmpTipoCambio).ToString("N2"))
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN).ToString("N2"))

                                            LimpiarlsvPagos("20111444444")
                                            'LimpiarlsvPagos("20392657020")
                                            'lsvPagosRegistrados.Items.Clear()
                                            CalculoPagos()
                                        Else
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            PanelError.Visible = True
                                            lblEstado.Text = "No debe exceder el monto permitido!"
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If
                                    Else
                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                        PanelError.Visible = True
                                        lblEstado.Text = "No debe exceder el monto permitido!"
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                    End If

                                End If
                            Else
                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                PanelError.Visible = True
                                lblEstado.Text = "debe ingresar monto recibido!"
                                Timer1.Enabled = True
                                TiempoEjecutar(10)

                            End If
                        Else
                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                            PanelError.Visible = True
                            lblEstado.Text = "El importe no debe ser negativo!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If


                    Case 7

                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub lsvPagosRegistrados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvPagosRegistrados.SelectedIndexChanged

    End Sub

    Private Sub PictureBox22_Click(sender As Object, e As EventArgs) Handles PictureBox22.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Efectivo And a.moneda = TipoMoneda.Nacional _
                    And a.idEmpresa = "20392657020").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago1(cajaBE, dgvPago1)
        Else
            PanelError.Visible = True
            lblEstado.Text = "No se asigno la cuenta elegida!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub dgvPago1_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPago1.QueryCellStyleInfo

        '************************** use usa para cambiar todo la fila el color *******************************

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Or e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement
            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record) Then
                Dim r As Record = el.GetRecord
                Dim value As Object = r.GetValue("pago")
                Dim moneda As Object = r.GetValue("moneda")

                Select Case value

                    Case "EFECTIVO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFD01212")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF2E8B57")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "BANCO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF212121")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FF484747")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select


                    Case "TARJETA CREDITO"
                        Select Case moneda
                            Case "NACIONAL"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFD28306")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                            Case "EXTRANJERO"
                                e.Style.BackColor = ColorTranslator.FromHtml("#FFB67208")
                                e.Style.TextColor = Color.White
                                e.Style.Font.Bold = True
                                e.Style.Font.Size = 10
                                e.Style.Font.Facename = "Arial"
                        End Select

                End Select

            End If

        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue
            'If (Not IsNothing(str)) Then

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "importePendiente")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("importePendiente")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If


            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "saldo")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("saldo")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoMN")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoMN")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoME")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("montoME")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"

                End If
            End If

            If (e.TableCellIdentity.RowIndex > -1) Then

                If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "tipocambio")) Then
                    Dim r As Record = el.GetRecord
                    Dim str As Object = r.GetValue("tipocambio")

                    'Dim str = Me.dgvPagos.TableModel(e.TableCellIdentity.RowIndex, 2).CellValue

                    'e.Style.BackColor = Color.FromArgb(255, 255, 128)
                    'e.Style.TextColor = Color.Black
                    e.Style.Font.Bold = True
                    e.Style.Font.Size = 10
                    e.Style.Font.Facename = "Arial"
                    'e.Style.Font.FontStyle = "Arial"



                End If
            End If
        End If
    End Sub

    Private Sub dgvPago1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPago1.TableControlCellClick

    End Sub

    Private Sub dgvPago1_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPago1.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim sumaPagos As Double = 0
        Dim sumaPagosME As Double = 0
        Dim sumatotal As Double = 0
        Dim numerOper As String
        Dim CobroMN As Decimal
        Dim CobroME As Decimal
        Dim importeIngreso As Decimal
        Dim tipoCambio As Decimal
        Dim calculoSaldoME As Decimal
        Dim entidadSA As New EstadosFinancierosSA
        Dim sumaPagosd As Decimal = 0
        Dim saldo As Decimal = 0
        Try
            If Not IsNothing(Me.dgvPago1.Table.CurrentRecord) Then
                Select Case ColIndex

                    Case 4 ' importe recibido
                        If (dgvPago1.Table.CurrentRecord.GetValue("importePendiente") > 0) Then

                            For Each c In dgvPago1.Table.Records
                                c.SetValue("vueltoMN", 0)
                                c.SetValue("vueltoME", 0)

                                c.SetValue("montoMN", 0)
                                c.SetValue("montoME", 0)
                            Next

                            saldo = txtTotalPagar.DecimalValue

                            For Each c In dgvPago1.Table.Records

                                If (c.GetValue("moneda") = "NACIONAL") Then
                                    sumaPagosd = 0
                                    sumaPagosME = 0

                                    Dim sumaPagosMExx As Decimal = sumaPagosME * TmpTipoCambioTransaccionCompra

                                    importeIngreso = c.GetValue("importePendiente") ' sumaPagosd ' importe recibido
                                    saldo = saldo - importeIngreso
                                    If saldo < 0 Then
                                        c.SetValue("vueltoMN", saldo * -1)
                                        c.SetValue("vueltoME", 0.0)
                                        c.SetValue("saldo", 0)
                                    Else
                                        c.SetValue("vueltoMN", 0.0)
                                        c.SetValue("vueltoME", 0.0)
                                        c.SetValue("saldo", saldo)
                                    End If

                                    If saldo > 0 Then
                                        c.SetValue("montoMN", importeIngreso)
                                        c.SetValue("montoME", 0.0)
                                    Else
                                        c.SetValue("montoMN", importeIngreso + saldo)
                                        c.SetValue("montoME", 0.0)
                                    End If

                                Else

                                    '----------------------------------------------------------------------
                                    'DOLARES---------------------------------------------------------------

                                    sumaPagosd = 0
                                    sumaPagosME = 0
                                   
                                    Dim sumaPagosMExx As Decimal = sumaPagosME * TmpTipoCambioTransaccionCompra

                                    importeIngreso = c.GetValue("importePendiente") ' IMPORTE EN DOLARES RECIBIDO

                                    Dim importeME = importeIngreso * TmpTipoCambioTransaccionCompra
                                    'Dim cargo = txtTotalPagar.DecimalValue - (sumaPagosMExx + sumaPagosd)
                                    saldo = saldo - importeME '(sumaPagosMExx + sumaPagosd)
                                    If saldo < 0 Then
                                        c.SetValue("vueltoMN", saldo * -1)
                                        c.SetValue("vueltoME", 0.0)
                                        c.SetValue("saldo", 0)
                                    Else
                                        c.SetValue("vueltoMN", 0.0)
                                        c.SetValue("vueltoME", 0.0)
                                        c.SetValue("saldo", saldo)
                                    End If

                                    If saldo > 0 Then
                                        c.SetValue("montoMN", importeME)
                                        c.SetValue("montoME", importeIngreso)
                                    Else
                                        c.SetValue("montoMN", importeME + saldo)
                                        c.SetValue("montoME", importeIngreso)
                                    End If

                                End If
                            Next

                            'LimpiarlsvPagos("20111444444")
                            LimpiarlsvPagos("20392657020")
                            CalculoPagosE1()

                        Else
                            dgvPago1.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                            'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                            PanelError.Visible = True
                            lblEstado.Text = "el monto no debe ser negativo!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)

                        End If
                        'End If

                    Case 5 ' moneda nacional
                        CobroMN = dgvPago1.Table.CurrentRecord.GetValue("montoMN")
                        importeIngreso = dgvPago1.Table.CurrentRecord.GetValue("importePendiente")

                        If (CobroMN > 0) Then
                            If (importeIngreso > 0) Then
                                dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                                saldoMN = 0
                                For Each i In dgvPago1.Table.Records
                                    If (i.GetValue("saldo") <> 0) Then
                                        saldoMN = i.GetValue("saldo")
                                    End If

                                Next
                                If (saldoMN = 0) Then
                                    numerOper = txtTotalPagar.Text
                                Else
                                    numerOper = saldoMN
                                End If



                                If (dgvPago1.Table.CurrentRecord.GetValue("moneda") = "EXTRANJERO") Then

                                    CobroME = CDec(CobroMN / dgvPago1.Table.CurrentRecord.GetValue("tipocambio")).ToString("N2")

                                    If (CobroME <> 0 And CobroMN <> 0) Then
                                        If (CobroME <= importeIngreso) Then
                                            If (CobroMN <= numerOper) Then
                                                'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
                                                tipoCambio = dgvPago1.Table.CurrentRecord.GetValue("tipocambio")
                                                If (numerOper <= CobroMN) Then
                                                    dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
                                                    dgvPago1.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPago1.Table.CurrentRecord.SetValue("saldo", (0.0))
                                                    dgvPago1.Table.CurrentRecord.SetValue("montoME", (CobroME))
                                                Else

                                                    dgvPago1.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPago1.Table.CurrentRecord.SetValue("montoME", (CobroME))
                                                    If (numerOper > CobroMN) Then
                                                        dgvPago1.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                        dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
                                                    Else
                                                        dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
                                                        dgvPago1.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                    End If

                                                End If
                                                'LimpiarlsvPagos("20111444444")
                                                LimpiarlsvPagos("20392657020")
                                                'lsvPagosRegistrados.Items.Clear()
                                                CalculoPagosE1()
                                            Else

                                                If (CobroMN > numerOper) Then
                                                    'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                                    dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                    dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                    dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                    dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                    dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                    PanelError.Visible = True
                                                    lblEstado.Text = "No debe exceder el monto permitido!"
                                                    Timer1.Enabled = True
                                                    TiempoEjecutar(10)
                                                Else
                                                    dgvPago1.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
                                                    tipoCambio = dgvPago1.Table.CurrentRecord.GetValue("tipocambio")
                                                    dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio).ToString("N2"))
                                                    dgvPago1.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPago1.Table.CurrentRecord.SetValue("saldo", (0.0))
                                                End If


                                                'lsvPagosRegistrados.Items.Clear()
                                                'CalculoPagos()
                                                'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                                'dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                ''dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                'dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                'dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                'dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                'PanelError.Visible = True
                                                'lblEstado.Text = "No debe exceder el monto permitido!"
                                                'Timer1.Enabled = True
                                                'TiempoEjecutar(10)
                                            End If
                                        Else
                                            dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            PanelError.Visible = True
                                            lblEstado.Text = "No debe exceder el monto permitido!"
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If



                                    Else
                                        calculoSaldoME = CDec(CobroMN / TmpTipoCambioTransaccionCompra)

                                        If (calculoSaldoME <= importeIngreso) Then


                                            If (CobroMN <= numerOper) Then
                                                'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
                                                'dgvPago1.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
                                                'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", (0))
                                                dgvPago1.Table.CurrentRecord.SetValue("montoME", CDec(CobroMN / TmpTipoCambioTransaccionCompra).ToString("N2"))
                                                dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra).ToString("N2")) * TmpTipoCambioTransaccionCompra)
                                                dgvPago1.Table.CurrentRecord.SetValue("vueltoME", importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra).ToString("N2")) '((importeIngreso - CobroMN) / TmpTipoCambio).ToString("N2"))
                                                dgvPago1.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN).ToString("N2"))
                                                'LimpiarlsvPagos("20111444444")
                                                LimpiarlsvPagos("20392657020")
                                                'lsvPagosRegistrados.Items.Clear()
                                                CalculoPagosE1()
                                            Else
                                                dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                PanelError.Visible = True
                                                lblEstado.Text = "No debe exceder el monto permitido!"
                                                Timer1.Enabled = True
                                                TiempoEjecutar(10)
                                            End If
                                        Else
                                            dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            PanelError.Visible = True
                                            lblEstado.Text = "No debe exceder el monto permitido!"
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If

                                    End If

                                Else

                                    If (CobroMN <= importeIngreso) Then
                                        If (CobroMN <= numerOper) Then
                                            'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
                                            'dgvPago1.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
                                            'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", (0))
                                            dgvPago1.Table.CurrentRecord.SetValue("montoME", (0))
                                            dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CobroMN).ToString("N2"))
                                            dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0) '((importeIngreso - CobroMN) / TmpTipoCambio).ToString("N2"))
                                            dgvPago1.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN).ToString("N2"))

                                            'LimpiarlsvPagos("20111444444")
                                            LimpiarlsvPagos("20392657020")
                                            'lsvPagosRegistrados.Items.Clear()
                                            CalculoPagosE1()
                                        Else
                                            'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            PanelError.Visible = True
                                            lblEstado.Text = "No debe exceder el monto permitido!"
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If
                                    Else
                                        'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                        dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                        dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                                        dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                        dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                        dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                                        PanelError.Visible = True
                                        lblEstado.Text = "No debe exceder el monto permitido!"
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                    End If

                                End If
                            Else
                                'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                                dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                                PanelError.Visible = True
                                lblEstado.Text = "debe ingresar monto recibido!"
                                Timer1.Enabled = True
                                TiempoEjecutar(10)

                            End If
                        Else
                            'dgvPago1.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("montoMN", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("montoME", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                            dgvPago1.Table.CurrentRecord.SetValue("saldo", 0.0)
                            PanelError.Visible = True
                            lblEstado.Text = "El importe no debe ser negativo!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If


                    Case 7

                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Sub configuracionModulo2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.NomModulo = strNomModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        'If cboTipoDoc.Text = "TICKET BOLETA" Then
    '                        '    GConfiguracion2.TipoComprobante = .tipo
    '                        '    GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        '    GConfiguracion2.Serie = .serie
    '                        '    GConfiguracion2.ValorActual = .valorInicial
    '                        '    'txtSerie.Text = .serie
    '                        '    '    txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        'End If


    '                        'If cboTipoDoc.Text = "TICKET FACTURA" Then
    '                        GConfiguracion2.TipoComprobante = .tipo1
    '                        GConfiguracion2.NombreComprobante = "" ' TablaSA.GetUbicarTablaID(10, .tipo1).descripcion
    '                        GConfiguracion2.Serie = .serie1
    '                        GConfiguracion2.ValorActual = .valorInicial1
    '                        'txtSerie.Text = .serie1
    '                        '  txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        'End If
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion2.IdAlmacen = .idAlmacen
    '                    GConfiguracion2.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    'With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                    '    'txtIdEstableAlmacen.Text = .idCentroCosto
    '                    '    'txtEstableAlmacen.Text = .nombre
    '                    'End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion2.IDCaja = .idestado
    '                    GConfiguracion2.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub
    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If cboTipoDoc.Text = "TICKET BOLETA" Then
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
        Else
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If listaEstablecimientoCanasta.Count > 0 Then
                Dim c = listaEstablecimientoCanasta.Where(Function(o) o.idCentroCosto = Val(dgvCompra.Table.CurrentRecord.GetValue("estable"))).FirstOrDefault()
                If IsNothing(c) Then
                    'listaEstablecimientoCanasta.Add(New centrocosto With {.idCentroCosto = Val(r.GetValue("estable"))})
                Else
                    listaEstablecimientoCanasta.Remove(c)
                End If
            End If
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub PictureBox24_Click(sender As Object, e As EventArgs) Handles PictureBox24.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Efectivo And a.moneda = TipoMoneda.Extranjero _
                   And a.idEmpresa = "20392657020").FirstOrDefault
        If Not IsNothing(cajaBE) Then
            GridPago1(cajaBE, dgvPago1)
        Else
            PanelError.Visible = True
            lblEstado.Text = "ya existe una entidad financiera!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox23_Click(sender As Object, e As EventArgs) Handles PictureBox23.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Banco And a.moneda = TipoMoneda.Nacional _
                 And a.idEmpresa = "20392657020").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago1(cajaBE, dgvPago1)
        Else
            PanelError.Visible = True
            lblEstado.Text = "ya existe una entidad financiera!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

    End Sub

    Private Sub PictureBox21_Click(sender As Object, e As EventArgs) Handles PictureBox21.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Banco And a.moneda = TipoMoneda.Extranjero _
               And a.idEmpresa = "20392657020").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago1(cajaBE, dgvPago1)
        Else
            PanelError.Visible = True
            lblEstado.Text = "ya existe una entidad financiera!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox20_Click(sender As Object, e As EventArgs) Handles PictureBox20.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Tarjeta_Credito And a.moneda = TipoMoneda.Nacional _
             And a.idEmpresa = "20392657020").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago1(cajaBE, dgvPago1)
        Else
            PanelError.Visible = True
            lblEstado.Text = "ya existe una entidad financiera!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox19_Click(sender As Object, e As EventArgs) Handles PictureBox19.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Tarjeta_Credito And a.moneda = TipoMoneda.Extranjero _
            And a.idEmpresa = "20392657020").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago1(cajaBE, dgvPago1)
        Else
            PanelError.Visible = True
            lblEstado.Text = "ya existe una entidad financiera!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Efectivo And a.moneda = TipoMoneda.Extranjero _
                     And a.idEmpresa = "20111444444").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago(cajaBE)
        Else
            PanelError.Visible = True
            lblEstado.Text = "No se asigno la cuenta elegida!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Banco And a.moneda = TipoMoneda.Nacional _
                      And a.idEmpresa = "20111444444").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago(cajaBE)
        Else
            PanelError.Visible = True
            lblEstado.Text = "No se asigno la cuenta elegida!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Banco And a.moneda = TipoMoneda.Extranjero _
                      And a.idEmpresa = "20111444444").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago(cajaBE)
        Else
            PanelError.Visible = True
            lblEstado.Text = "No se asigno la cuenta elegida!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Tarjeta_Credito And a.moneda = TipoMoneda.Nacional _
                    And a.idEmpresa = "20111444444").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago(cajaBE)
        Else
            PanelError.Visible = True
            lblEstado.Text = "No se asigno la cuenta elegida!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Tarjeta_Credito And a.moneda = TipoMoneda.Extranjero _
                    And a.idEmpresa = "20111444444").FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago(cajaBE)
        Else
            PanelError.Visible = True
            lblEstado.Text = "No se asigno la cuenta elegida!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click

    End Sub

    Private Sub PictureBox18_Click(sender As Object, e As EventArgs) Handles PictureBox18.Click
        Dim r As Record = dgvPago1.Table.CurrentRecord
        If Not IsNothing(r) Then
            dgvPago1.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim r As Record = dgvPagos.Table.CurrentRecord
        If Not IsNothing(r) Then
            dgvPagos.Table.CurrentRecord.Delete()
        End If
    End Sub
End Class