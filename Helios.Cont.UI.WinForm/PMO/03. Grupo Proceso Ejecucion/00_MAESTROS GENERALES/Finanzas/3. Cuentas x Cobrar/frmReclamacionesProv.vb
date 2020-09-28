Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmReclamacionesProv

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvExcedente)
        txtPeriodoDev.Value = New DateTime(AnioGeneral, MesGeneral, 1)
    End Sub
#End Region

#Region "Methods"
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

    Private Sub devolverExcedente(strMoneda As String, IDDocumentoCompra As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentocompradetalle
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        With frmCobrosModal
            .txtPeriodo.Value = New Date(txtPeriodoDev.Value.Year, txtPeriodoDev.Value.Month, 1)
            .TipoCobroReclamacion = "RECLAMACION"
            .dgvDetalleItems.Rows.Clear()
            .manipulacionEstado = ENTITY_ACTIONS.INSERT
            .CaptionLabels(0).Text = "COBROS - " & txtcliDev.Text
            Select Case strMoneda
                Case "NAC"
                    'If TabPageCobranzaCli Is TabCuentasCobrar.SelectedTab Then
                    .lblIdProveedor = CStr(txtcliDev.Tag)
                    .lblNomProveedor = txtcliDev.Text
                    .lblCuentaProveedor = "1213"
                    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = txtcliDev.Text
                    .txtProveedor.Tag = txtcliDev.Tag
                    .txtEntidad.Tag = txtcliDev.Tag
                    .txtEntidad.Text = txtcliDev.Text
                    .txtNroDocEntidad.Text = txtRucDev.Text
                    .txtTipoEntidad.Text = "PR"
                    'ElseIf TabPageDevolucion Is TabCuentasCobrar.SelectedTab Then
                    '    .lblIdProveedor = CStr(txtcliDev.Tag)
                    '    .lblNomProveedor = txtcliDev.Text
                    '    .lblCuentaProveedor = "1212"
                    '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    '    'Nuevo Maykol correccion
                    '    .txtProveedor.Text = txtCliente.Text
                    '    .txtProveedor.Tag = txtCliente.Tag
                    'End If

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)
                        If Not i.EstadoCobro = "PG" Then
                            detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                            'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                            'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                            cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                            cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
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
                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvExcedente.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = dgvExcedente.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = dgvExcedente.Table.CurrentRecord.GetValue("serie")

                    .lblTipoCambio.Text = dgvExcedente.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = (dgvExcedente.Table.CurrentRecord.GetValue("fecha"))

                    Select Case dgvExcedente.Table.CurrentRecord.GetValue("moneda")
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
                    .lblIdProveedor = CStr(txtcliDev.Tag)
                    .lblNomProveedor = txtcliDev.Text
                    .lblCuentaProveedor = "1213"
                    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = txtcliDev.Text
                    .txtProveedor.Tag = txtcliDev.Tag
                    .txtEntidad.Tag = txtcliDev.Tag
                    .txtEntidad.Text = txtcliDev.Text
                    .txtNroDocEntidad.Text = txtRucDev.Text
                    .txtTipoEntidad.Text = "PR"
                    'ElseIf TabPageDevolucion Is TabCuentasCobrar.SelectedTab Then
                    '    .lblIdProveedor = CStr(txtcliDev.Tag)
                    '    .lblNomProveedor = txtcliDev.Text
                    '    .lblCuentaProveedor = "1212"
                    '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    '    'Nuevo Maykol correccion
                    '    .txtProveedor.Text = txtCliente.Text
                    '    .txtProveedor.Tag = txtCliente.Tag
                    'End If

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)
                        If Not i.EstadoCobro = "PG" Then
                            detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                            'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                            'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                            cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                            cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
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
                    .DigitalGauge2.Value = CDec(saldome)
                    .lblMonedaCobro.Text = "EXTRANJERA:"
                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvExcedente.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = dgvExcedente.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = dgvExcedente.Table.CurrentRecord.GetValue("serie")

                    .lblTipoCambio.Text = dgvExcedente.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = (dgvExcedente.Table.CurrentRecord.GetValue("fecha"))
                    Dim DSFS As String = dgvExcedente.Table.CurrentRecord.GetValue("moneda")
                    Select Case dgvExcedente.Table.CurrentRecord.GetValue("moneda")
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






        'With frmDevolucionAproveedor
        '    .dgvDetalleItems.Rows.Clear()
        '    ' .manipulacionEstado = ENTITY_ACTIONS.INSERT
        '    Select Case strMoneda
        '        Case "NAC"
        '            'If TabPagoProveedor Is TabCuentasPagar.SelectedTab Then
        '            '    .lblIdProveedor = CStr(txtCliente.Tag)
        '            '    .lblNomProveedor = txtCliente.Text
        '            '    .lblCuentaProveedor = "4212"
        '            '    .lblIdDocumento = CStr(IDDocumentoCompra)
        '            'ElseIf TabPageDevolucion Is TabCuentasPagar.SelectedTab Then


        '            .lblIdProveedor = CStr(txtcliDev.Tag)
        '            .lblNomProveedor = txtcliDev.Text
        '            .txtProveedor.Tag = CStr(txtcliDev.Tag)
        '            .txtProveedor.Text = txtcliDev.Text
        '            .txtSerieCompr.Text = dgvExcedente.Table.CurrentRecord.GetValue("serie")
        '            .txtNumeroCompr.Text = dgvExcedente.Table.CurrentRecord.GetValue("numero")
        '            .txtTipoCambio.Value = dgvExcedente.Table.CurrentRecord.GetValue("tipoCambio")
        '            .lblTipoCambio.Text = dgvExcedente.Table.CurrentRecord.GetValue("tipoCambio")
        '            .manipulacionEstado = ENTITY_ACTIONS.INSERT
        '            .lblCuentaProveedor = "4213"
        '            .lblIdDocumento = CStr(IDDocumentoCompra)
        '            ' End If

        '            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)

        '                If Not i.EstadoCobro = "PG" Then
        '                    detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)


        '                    cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn)
        '                    cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme)

        '                    saldomn += cTotalmn
        '                    saldome += cTotalme
        '                    If cTotalmn > 0 Or cTotalme > 0 Then
        '                        .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
        '                                                   Nothing, cTotalmn, (cTotalmn / TmpTipoCambioTransaccionVenta).ToString("N2"),
        '                                                   "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
        '                    End If
        '                End If
        '            Next

        '            .lblDeudaPendiente.Text = CStr(CDec(saldomn))
        '            .lblDeudaPendienteme.Text = CStr(CDec(saldome))

        '            .txtSaldoPorPagar.Text = CStr(CDec(saldomn))

        '        Case Else

        '    End Select

        '    If CDec(saldomn) <= 0 Then
        '        '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
        '        lblEstado.Text = "El documento ya se encuentra pagado."
        '        Timer1.Enabled = True
        '        PanelError.Visible = True
        '        TiempoEjecutar(10)
        '        '   EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PAGADO)
        '        Me.Cursor = Cursors.Arrow
        '        Exit Sub
        '    Else
        '        '    EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PENDIENTE_PAGO)

        '        'If .TieneCuentaFinanciera = True Then
        '        .txtFechaComprobante.Text = (DateTime.Now).ToString  ' New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        '        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '        '     .txtFechaComprobante.Enabled = False
        '        '  .lblPerido.Text = PeriodoGeneral
        '        .cboTipoDocumento.Enabled = True
        '        .cboTipoDocumento.ReadOnly = False
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '        'Else
        '        '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
        '        '    Timer1.Enabled = True
        '        '    PanelError.Visible = True
        '        '    TiempoEjecutar(10)
        '        'End If
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub UbicarCompraNroSerieExcedente(RucCliente As Integer, intmoneda As String)
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoVenta As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodoDev.Value.Month)) & "/" & txtPeriodoDev.Value.Year

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


        documentoVenta = documentoVentaSA.UbicarExcedenteCompraPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intmoneda)
        Dim str As String
        If Not IsNothing(documentoVenta) Then

            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In documentoVenta
                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.importeTotal - i.PagoSumaMN
                SaldoPagosME = i.importeUS - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN - i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME - i.PagoNotaCreditoME + i.PagoNotaDebitoME

                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoCompra
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.importeTotal
                dr(8) = i.tcDolLoc
                dr(9) = i.importeUS
                dr(10) = i.PagoSumaMN
                dr(11) = i.PagoSumaME
                dr(12) = SaldoPagosMN ' i.SaldoComprobanteDocumentoCompraMN '  CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(13) = SaldoPagosME
                Select Case i.estadoPago
                    Case "PG"
                        dr(14) = "Saldado"
                    Case "DC"
                        dr(14) = "Saldado"
                    Case "PN"
                        dr(14) = "Pendiente"
                End Select

                dt.Rows.Add(dr)
            Next
            dgvExcedente.DataSource = dt
            Me.dgvExcedente.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
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
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

#End Region

#Region "Events"
    Private Sub txtPeriodoDev_ValueChanged(sender As Object, e As EventArgs) Handles txtPeriodoDev.ValueChanged
        dgvExcedente.Table.Records.DeleteAll()
    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        If dgvExcedente.Table.SelectedRecords.Count > 0 Then

            Dim fechaAnt = New Date(txtPeriodoDev.Value.Year, CInt(txtPeriodoDev.Value.Month), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtPeriodoDev.Value.Year, .mes = CInt(txtPeriodoDev.Value.Month)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            'If IsNothing(GFichaUsuarios) Then
            '    lblEstado.Text = "Debe asignar una caja válida!"
            '    PanelError.Visible = True
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            'Else

            If dgvExcedente.Table.CurrentRecord.GetValue("estadoPago") = "Pendiente" Then

                devolverExcedente(dgvExcedente.Table.CurrentRecord.GetValue("moneda"), dgvExcedente.Table.CurrentRecord.GetValue("idDocumento"))
            Else
                MessageBox.Show("El Documento esta cancelado")
            End If
            'End If
        End If
    End Sub

    Private Sub ToolStripButton21_Click(sender As Object, e As EventArgs) Handles ToolStripButton21.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvExcedente.Table.SelectedRecords.Count > 0 Then
            If txtcliDev.Text.Trim.Length > 0 Then
                With frmHistorial
                    .IdDocumentoCompra = dgvExcedente.Table.CurrentRecord.GetValue("idDocumento")
                    .LoadHistorialCajasXcompra()
                    ' .HistorialCompra(IDDocumentoCompra)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        If Not IsNothing(Me.dgvExcedente.Table.CurrentRecord) Then

            Dim fechaAnt = New Date(txtPeriodoDev.Value.Year, CInt(txtPeriodoDev.Value.Month), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If


            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtPeriodoDev.Value.Year, .mes = CInt(txtPeriodoDev.Value.Month)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If dgvExcedente.Table.CurrentRecord.GetValue("estadoPago") = "Pendiente" Then

                If dgvExcedente.Table.CurrentRecord.GetValue("moneda") = "NAC" Then

                    With frmCompensacionDeDocumentos
                        .txtProveedor.Text = txtcliDev.Text
                        .txtProveedor.Tag = txtcliDev.Tag
                        .txtRuc.Text = txtRucDev.Text
                        .lblTipoEntidad.Text = "PR"
                        ' sdgfsdgsdg



                        Dim tablaSA As New tablaDetalleSA
                        Dim tablaBL As New tabladetalle

                        tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvExcedente.Table.CurrentRecord.GetValue("tipoDoc")))

                        .txtComprobante.Text = tablaBL.descripcion
                        .txtComprobante.Tag = tablaBL.codigoDetalle
                        .txtNumeroCompr.Text = CStr(dgvExcedente.Table.CurrentRecord.GetValue("numero"))
                        .txtSerieCompr.Text = CStr(dgvExcedente.Table.CurrentRecord.GetValue("serie"))
                        .txtTipoCambio.Text = CDec(dgvExcedente.Table.CurrentRecord.GetValue("tipoCambio"))

                        .txtFechaComprobante.Text = CStr(dgvExcedente.Table.CurrentRecord.GetValue("fecha"))
                        .lblIdDocumento.Text = dgvExcedente.Table.CurrentRecord.GetValue("idDocumento")

                        .txtImporteMN.Text = CDec(dgvExcedente.Table.CurrentRecord.GetValue("importeMN") - dgvExcedente.Table.CurrentRecord.GetValue("abonoMN"))
                        .txtImporteME.Text = CDec(dgvExcedente.Table.CurrentRecord.GetValue("importeME") - dgvExcedente.Table.CurrentRecord.GetValue("abonoME"))
                        .txtMoneda.Text = CStr(dgvExcedente.Table.CurrentRecord.GetValue("moneda"))

                        .btnNuevoPago(dgvExcedente.Table.CurrentRecord.GetValue("moneda"), dgvExcedente.Table.CurrentRecord.GetValue("idDocumento"))

                        'Select Case dgvPagosVarios.Table.CurrentRecord.GetValue("moneda")
                        '    Case "NAC"
                        '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        '    Case "EXT"
                        '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                        'End Select


                        .ShowDialog()
                    End With



                    'btnNuevoPagoAnticipoPagos(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))
                Else
                    MessageBox.Show("Solo Se puede Compensar Documentos en Soles")
                End If


            Else
                MessageBox.Show("El Documento esta cancelado")
            End If
        Else
            MessageBox.Show("Seleccione uan compra")
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If txtcliDev.Text.Trim.Length > 0 Then
            'UbicarCompraNroSerieExcedente(txtcliDev.Tag)


            Select Case cboMonedaProveedor.Text
                Case "NACIONAL"
                    UbicarCompraNroSerieExcedente(txtcliDev.Tag, "1")
                Case "EXTRANJERA"
                    UbicarCompraNroSerieExcedente(txtcliDev.Tag, "2")
            End Select


        Else
            lblEstado.Text = "Seleccione un proveedor antes de realizar la tarea!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.PROVEEDOR)
        f.CaptionLabels(0).Text = "Proveedor"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, entidad)
            'Dim c = CType(f.Tag, entidad)
            txtcliDev.Text = c.nombreCompleto
            txtcliDev.Tag = c.idEntidad
            txtRucDev.Text = c.nrodoc
            txtRucDev.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtcliDev.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvExcedente_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvExcedente.TableControlCellClick

    End Sub

    Private Sub dgvExcedente_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvExcedente.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvExcedente.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvExcedente_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvExcedente.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvExcedente)
    End Sub


#End Region


   
End Class