Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabFN_CuentasCobrar
    Private empresaPeriodoSA As New empresaCierreMensualSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridPequeño(dgvCobranzaCli, True, 9.0F)
        txtPeriodo.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
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

#Region "Methods"
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

    Private Sub GetCuentasXPagarTodoClientes(intMoneda As String)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        Dim strPeriodo = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))

        dt.Columns.Add("idCliente")
        dt.Columns.Add("cliente")
        dt.Columns.Add("nroDocEntidad")

        documentoVenta = documentoVentaSA.GetCuentasXPagarTodoClientes(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, intMoneda, TIPO_VENTA.PAGO.PENDIENTE_PAGO)
        Dim str As String
        If Not IsNothing(documentoVenta) Then


            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In documentoVenta


                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.ImporteNacional - i.PagoSumaMN
                SaldoPagosME = i.ImporteExtranjero - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN - i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME - i.PagoNotaCreditoME + i.PagoNotaDebitoME





                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                Select Case i.tipoVenta
                    Case TIPO_VENTA.NOTA_DE_VENTA
                        dr(2) = "NOTA DE VENTA"
                    Case "VPOS"
                        dr(2) = "VENTA"
                    Case Else
                        dr(2) = i.tipoVenta
                End Select

                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.moneda
                    Case CStr(1)
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME
                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")
                dr(12) = CDec(SaldoPagosMN).ToString("N2")
                dr(13) = CDec(SaldoPagosME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select




                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select
                dr(15) = (i.idCliente)
                dr(16) = (i.NombreEntidad)
                dr(17) = (i.NroDocEntidad)
                dt.Rows.Add(dr)
            Next
            dgvCobranzaCli.DataSource = dt
            Me.dgvCobranzaCli.TableOptions.ListBoxSelectionMode = SelectionMode.One

            Select Case cboMonedaCobro.Text
                Case "NACIONAL"
                    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


        Else

        End If
    End Sub

    Private Sub btnNuevoPago(strMoneda As String, IDDocumentoCompra As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0
        Dim detalle As New documentoventaAbarrotesDet
        Dim detalleSA As New documentoVentaAbarrotesDetSA

        'Select Case TipoCompra
        Dim rec As Record = dgvCobranzaCli.Table.CurrentRecord
        '    Case TIPO_VENTA.VENTA_NORMAL_CREDITO
        With frmCobrosModal
            .txtTipoCambio.Value = TmpTipoCambio
            .txtPeriodo.Value = New Date(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)
            .dgvDetalleItems.Rows.Clear()
            .manipulacionEstado = ENTITY_ACTIONS.INSERT
            .CaptionLabels(0).Text = "COBROS - " & rec.GetValue("cliente") ' txtCliente.Text
            Select Case strMoneda
                Case "NAC"
                    'If TabPageCobranzaCli Is TabCuentasCobrar.SelectedTab Then
                    .lblIdProveedor = rec.GetValue("idCliente")
                    .lblNomProveedor = rec.GetValue("cliente")
                    .lblCuentaProveedor = "1213"
                    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = rec.GetValue("cliente")
                    .txtProveedor.Tag = rec.GetValue("idCliente")
                    .txtEntidad.Text = rec.GetValue("cliente")
                    .txtEntidad.Tag = rec.GetValue("idCliente")
                    .txtNroDocEntidad.Text = rec.GetValue("nroDocEntidad")
                    .txtTipoEntidad.Text = "CL"
                    'ElseIf TabPageDevolucion Is TabCuentasCobrar.SelectedTab Then
                    '    .lblIdProveedor = CStr(txtcliDev.Tag)
                    '    .lblNomProveedor = txtcliDev.Text
                    '    .lblCuentaProveedor = "1212"
                    '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    '    'Nuevo Maykol correccion
                    '    .txtProveedor.Text = txtCliente.Text
                    '    .txtProveedor.Tag = txtCliente.Tag
                    'End If

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
                        If Not i.EstadoCobro = "DC" Then
                            detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                            'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                            'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                            cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                            cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
                            If cTotalmn < 0 Then
                                cTotalmn = 0
                            End If
                            If cTotalme < 0 Then
                                cTotalme = 0
                            End If
                            saldomn += cTotalmn
                            saldome += cTotalme
                            If cTotalmn > 0 Or cTotalme > 0 Then
                                .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                           Nothing, cTotalmn, cTotalme,
                                                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                            End If
                        End If
                    Next
                    'txtImporteCompramn.Text = saldomn.ToString("N2")
                    'txtImporteComprame.Text = saldome.ToString("N2")

                    '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                    .lblDeudaPendiente.Text = CStr(CDec(saldomn))
                    .lblDeudaPendienteme.Text = CStr(CDec(saldome))
                    .btnSaldoCobro.Text = CDec(saldomn)
                    .DigitalGauge2.Value = CDec(saldomn)
                    .lblMonedaCobro.Text = "NACIONAL:"
                    .lblMonedaCobro.Tag = 1
                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("serie")

                    .lblTipoCambio.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = (dgvCobranzaCli.Table.CurrentRecord.GetValue("fecha"))

                    Select Case dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select

                    .pnSaldoMN.Location = New Point(25, 45)
                    .pnSaldoME.Location = New Point(25, 70)
                    .pnColorME.BackColor = Color.White
                    .pnColorMN.BackColor = Color.Yellow


                Case "EXT"
                    'If TabPageCobranzaCli Is TabCuentasCobrar.SelectedTab Then
                    .lblIdProveedor = rec.GetValue("idCliente")
                    .lblNomProveedor = rec.GetValue("cliente")
                    .lblCuentaProveedor = "1213"
                    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = rec.GetValue("cliente")
                    .txtProveedor.Tag = rec.GetValue("idCliente")
                    .txtEntidad.Text = rec.GetValue("cliente")
                    .txtEntidad.Tag = rec.GetValue("idCliente")
                    .txtNroDocEntidad.Text = rec.GetValue("nroDocEntidad")
                    .txtTipoEntidad.Text = "CL"
                    'ElseIf TabPageDevolucion Is TabCuentasCobrar.SelectedTab Then
                    '    .lblIdProveedor = CStr(txtcliDev.Tag)
                    '    .lblNomProveedor = txtcliDev.Text
                    '    .lblCuentaProveedor = "1212"
                    '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    '    'Nuevo Maykol correccion
                    '    .txtProveedor.Text = txtCliente.Text
                    '    .txtProveedor.Tag = txtCliente.Tag
                    'End If

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
                        If Not i.EstadoCobro = "DC" Then
                            detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                            'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                            'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                            cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                            cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
                            If cTotalmn < 0 Then
                                cTotalmn = 0
                            End If
                            If cTotalme < 0 Then
                                cTotalme = 0
                            End If
                            saldomn += cTotalmn
                            saldome += cTotalme
                            If cTotalmn > 0 Or cTotalme > 0 Then
                                .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                           Nothing, cTotalmn, cTotalme,
                                                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                            End If
                        End If
                    Next
                    'txtImporteCompramn.Text = saldomn.ToString("N2")
                    'txtImporteComprame.Text = saldome.ToString("N2")

                    '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                    .lblDeudaPendiente.Text = CStr(CDec(saldomn))
                    .lblDeudaPendienteme.Text = CStr((saldome))
                    .btnSaldoCobro.Text = CDec(saldome)
                    .lblMonedaCobro.Text = "EXTRANJERA:"
                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("serie")

                    .lblTipoCambio.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = (dgvCobranzaCli.Table.CurrentRecord.GetValue("fecha"))
                    Dim DSFS As String = dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")
                    Select Case dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select

                    .pnSaldoMN.Location = New Point(25, 70)
                    .pnSaldoME.Location = New Point(25, 45)
                    .pnColorME.BackColor = Color.Yellow
                    .pnColorMN.BackColor = Color.White


            End Select

            If CDec(saldomn) <= 0 Then
                '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                lblEstado.Text = "El documento ya se encuentra pagado."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                '   EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PAGADO)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                '    EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PENDIENTE_PAGO)

                'If .TieneCuentaFinanciera = True Then
                '.txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                '.txtFechaComprobante.Enabled = False
                '.lblPerido.Text = PeriodoGeneral
                .cboTipoDocument.Enabled = True
                .cboTipoDocument.ReadOnly = False
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                'Else
                '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                'End If
            End If
        End With
        'End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub UbicarVentaNroSerie(RucCliente As Integer, intMoneda As String)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        Dim strPeriodo = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))

        dt.Columns.Add("idCliente")
        dt.Columns.Add("cliente")
        dt.Columns.Add("nroDocEntidad")

        documentoVenta = documentoVentaSA.UbicarVentaPorClienteXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intMoneda)
        Dim str As String
        If Not IsNothing(documentoVenta) Then


            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In documentoVenta


                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.ImporteNacional - i.PagoSumaMN
                SaldoPagosME = i.ImporteExtranjero - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN - i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME - i.PagoNotaCreditoME + i.PagoNotaDebitoME





                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.moneda
                    Case CStr(1)
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME
                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")
                dr(12) = CDec(SaldoPagosMN).ToString("N2")
                dr(13) = CDec(SaldoPagosME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select




                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select
                dr(15) = i.idCliente
                dr(16) = i.NombreEntidad
                dr(17) = i.NroDocEntidad
                'dt.Rows.Add(i.idCliente)
                'dt.Rows.Add(i.NombreEntidad)
                'dt.Rows.Add(i.NroDocEntidad)
                dt.Rows.Add(dr)
            Next
            dgvCobranzaCli.DataSource = dt
            Me.dgvCobranzaCli.TableOptions.ListBoxSelectionMode = SelectionMode.One

            Select Case cboMonedaCobro.Text
                Case "NACIONAL"
                    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


        Else

        End If
    End Sub
#End Region

#Region "Events"
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then

                'Dim fechaAnt = New Date(txtPeriodo.Value.Year, CInt(txtPeriodo.Value.Month), 1)
                'fechaAnt = fechaAnt.AddMonths(-1)
                'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                'If periodoAnteriorEstaCerrado = False Then
                '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                '    Cursor = Cursors.Default
                '    Exit Sub
                'End If

                'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc,.anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
                'If Not IsNothing(valida) Then
                '    If valida = True Then
                '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Me.Cursor = Cursors.Default
                '        Exit Sub
                '    End If
                'End If
                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                    btnNuevoPago(dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda"), dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))

                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If



            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then
            '   If txtCliente.Text.Trim.Length > 0 Then
            With frmHistorial
                .IdDocumentoCompra = dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento")
                '.LoadHistorialCajasXcompra()
                .LoadHistorialCajasXcompra2("VENTA")
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
            ' End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            GetCuentasXPagarTodoClientes("1")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
        f.CaptionLabels(0).Text = "Cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, entidad)
            'Dim c = CType(f.Tag, entidad)
            txtCliente.Text = c.nombreCompleto
            txtCliente.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            If txtCliente.Text.Trim.Length > 0 Then
                Select Case cboMonedaCobro.Text
                    Case "NACIONAL"
                        UbicarVentaNroSerie(Integer.Parse(txtCliente.Tag), "1")
                    'UbicarVentaNroSeriePago(txtBuscarProveedorPago.Tag, "1")
                    Case "EXTRANJERA"
                        UbicarVentaNroSerie(txtCliente.Tag, "2")
                End Select
            Else
                lblEstado.Text = "Seleccione un cliente antes de realizar la tarea!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub txtPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles txtPeriodo.ValueChanged
        dgvCobranzaCli.Table.Records.DeleteAll()
    End Sub

    Private Sub dgvCobranzaCli_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCobranzaCli.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvCobranzaCli.TableControl.Selections.Clear()
        End If
        If Not IsNothing(e.TableCellIdentity.Column) Then
            If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
                'Checks for the column name when the cellvalue is greater than 5.
                If e.TableCellIdentity.Column.MappingName = "estadoPago" AndAlso ((e.Style.CellValue)) = "Saldado" Then
                    e.Style.BackColor = Color.FromArgb(92, 184, 92)
                    e.Style.TextColor = Color.White
                ElseIf e.TableCellIdentity.Column.MappingName = "estadoPago" AndAlso ((e.Style.CellValue)) = "Pendiente" Then
                    e.Style.BackColor = Color.FromArgb(183, 16, 0)
                    e.Style.TextColor = Color.White
                End If
                'If e.TableCellIdentity.Column.MappingName = "importeMN" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '    e.Style.BackColor = Color.LightYellow
                '    e.Style.Format = "S/.##.00"
                'End If
                'If e.TableCellIdentity.Column.MappingName = "almacenDestino" Then
                '    e.Style.BackColor = Color.LightYellow
                'End If
            End If
        End If
    End Sub

    Private Sub dgvCobranzaCli_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCobranzaCli.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCobranzaCli)
    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
            dgvCobranzaCli.TopLevelGroupOptions.ShowFilterBar = True
            dgvCobranzaCli.NestedTableGroupOptions.ShowFilterBar = True
            dgvCobranzaCli.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvCobranzaCli.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvCobranzaCli.OptimizeFilterPerformance = True
            dgvCobranzaCli.ShowNavigationBar = True
            filter.WireGrid(dgvCobranzaCli)
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgvCobranzaCli)
            dgvCobranzaCli.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub
#End Region

End Class
