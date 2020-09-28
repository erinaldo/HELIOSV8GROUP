Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmReclamaciones

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim empresaPeriodoSA As New empresaCierreMensualSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(GridGroupingControl3)
        txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, 1)
        txtPeriodo.Value = DateTime.Now
    End Sub
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

    Private Sub btnNuevoPagoReclamaciones(strMoneda As String, IDDocumentoCompra As Integer)
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



        'PAGO RECLAMACIONES VENTA
        With frmModalPagos ' frmPagos
            .txtPeriodo.Value = New Date(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)
            .TipoPagoReclamacion = "VENTA"
            .dgvDetalleItems.Rows.Clear()
            .manipulacionEstado = ENTITY_ACTIONS.INSERT
            .CaptionLabels(0).Text = "PAGOS - " & TextBoxExt4.Text
            Select Case strMoneda
                Case "NAC"
                    'If TabPagoProveedor Is TabCuentasPagar.SelectedTab Then
                    .lblIdProveedor = CStr(TextBoxExt4.Tag)
                    .lblNomProveedor = TextBoxExt4.Text
                    .lblCuentaProveedor = "1213"
                    .lblIdDocumento.Text = CStr(IDDocumentoCompra)

                    .txtProveedor.Text = TextBoxExt4.Text
                    .txtProveedor.Tag = TextBoxExt4.Tag
                    .txtEntidad.Text = TextBoxExt4.Text
                    .txtEntidad.Tag = TextBoxExt4.Tag
                    .txtNroDocEntidad.Text = TextBoxExt3.Text
                    .txtTipoEntidad.Text = "CL"
                    'martin
                    'Dim listaPago As List(Of documentoAnticipoDetalle)
                    'listaPago = objLista2.ObtenerCuentasPagadasAnticipo(IDDocumentoCompra)

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
                        If i.bonificacion <> "S" Then
                            If Not i.EstadoCobro = "DC" Then
                                detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)

                                ''martin
                                'Dim consulta = (From c In listaPago
                                '                Where c.secuencia = i.secuencia).FirstOrDefault


                                'cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn - consulta.MontoPagadoSoles)
                                'cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme - consulta.MontoPagadoUSD)
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
                                                           Nothing, cTotalmn, (cTotalmn / TmpTipoCambioTransaccionVenta).ToString("N2"),
                                                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                                End If
                            End If
                        End If

                    Next

                    .lblDeudaPendienteme.Text = CStr(saldome)
                    .txtSaldoPorPagar.Text = CDec(saldomn)
                    .DigitalGauge2.Value = CDec(saldomn)
                    .lblMonedaCobro.Text = "NACIONAL"

                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("serie")
                    .txtTipoCambio.DoubleValue = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
                    .lblTipoCambio.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = (GridGroupingControl3.Table.CurrentRecord.GetValue("fecha"))

                    Select Case GridGroupingControl3.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select
                    .cargarDatosCompra(0)

                Case "EXT"

                    .lblIdProveedor = CStr(TextBoxExt4.Tag)
                    .lblNomProveedor = TextBoxExt4.Text
                    .lblCuentaProveedor = "1213"
                    .lblIdDocumento.Text = IDDocumentoCompra

                    .txtProveedor.Text = TextBoxExt4.Text
                    .txtProveedor.Tag = CStr(TextBoxExt4.Tag)
                    .txtEntidad.Text = TextBoxExt4.Text
                    .txtEntidad.Tag = TextBoxExt4.Tag
                    .txtNroDocEntidad.Text = TextBoxExt3.Text
                    .txtTipoEntidad.Text = "CL"


                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle
                    Dim tipoCambio As Decimal
                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("serie")
                    tipoCambio = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
                    .lblTipoCambio.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = (GridGroupingControl3.Table.CurrentRecord.GetValue("fecha"))
                    Dim DSFS As String = GridGroupingControl3.Table.CurrentRecord.GetValue("moneda")
                    Select Case GridGroupingControl3.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select



                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
                        If i.bonificacion <> "S" Then
                            If Not i.EstadoCobro = "DC" Then
                                detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
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
                        End If

                    Next

                    .lblDeudaPendienteme.Text = CDec(saldome)
                    .txtSaldoPorPagar.Text = CDec(saldome)
                    .DigitalGauge2.Value = CDec(saldome)
                    .lblMonedaCobro.Text = "EXTRANJERA"
                    .cargarDatosCompra(1)

            End Select

            If CDec(saldomn) <= 0 Then

                MessageBox.Show("El documento ya se encuentra pagado.")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else

                .lblPerido.Text = PeriodoGeneral
                .cboTipoDoc.Enabled = True
                .cboTipoDoc.ReadOnly = False
                .PanelDetallePagos.Enabled = False
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()

            End If
        End With




        'With frmCobros
        '    .TipoCobroReclamacion = "RECLAMACION"
        '    .dgvDetalleItems.Rows.Clear()
        '    .manipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .CaptionLabels(0).Text = "COBROS - " & TextBoxExt4.Text
        '    Select Case strMoneda
        '        Case "NAC"

        '            .lblIdProveedor = CStr(TextBoxExt4.Tag)
        '            .lblNomProveedor = TextBoxExt4.Text
        '            .lblCuentaProveedor = "1212"
        '            .lblIdDocumento.Text = CStr(IDDocumentoCompra)

        '            .txtProveedor.Text = TextBoxExt4.Text
        '            .txtProveedor.Tag = TextBoxExt4.Tag


        '            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
        '                If Not i.EstadoCobro = "DC" Then
        '                    detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
        '                    'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
        '                    'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
        '                    cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
        '                    cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
        '                    If cTotalmn < 0 Then
        '                        cTotalmn = 0
        '                    End If
        '                    If cTotalme < 0 Then
        '                        cTotalme = 0
        '                    End If
        '                    saldomn += cTotalmn
        '                    saldome += cTotalme
        '                    If cTotalmn > 0 Or cTotalme > 0 Then
        '                        .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
        '                                                   Nothing, cTotalmn, cTotalme,
        '                                                   "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
        '                    End If
        '                End If
        '            Next
        '            'txtImporteCompramn.Text = saldomn.ToString("N2")
        '            'txtImporteComprame.Text = saldome.ToString("N2")

        '            '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
        '            .lblDeudaPendiente.Text = CStr(CDec(saldomn))
        '            .lblDeudaPendienteme.Text = CStr(CDec(saldome))
        '            .btnSaldoCobro.Text = CDec(saldomn)
        '            .lblMonedaCobro.Text = "NACIONAL:"
        '            Dim tablaSA As New tablaDetalleSA
        '            Dim tablaBL As New tabladetalle

        '            tablaBL = tablaSA.GetUbicarTablaID(10, CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoDoc")))





        '            .txtComprobante.Text = tablaBL.descripcion
        '            .txtComprobante.Tag = tablaBL.codigoDetalle
        '            .txtNumeroCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("numero")
        '            .txtSerieCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("serie")

        '            .lblTipoCambio.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
        '            .txtFechaComprobante.Text = (GridGroupingControl3.Table.CurrentRecord.GetValue("fecha"))

        '            Select Case GridGroupingControl3.Table.CurrentRecord.GetValue("moneda")
        '                Case "NAC"
        '                    .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
        '                Case "EXT"
        '                    .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
        '            End Select

        '            .pnSaldoMN.Location = New Point(25, 45)
        '            .pnSaldoME.Location = New Point(25, 70)
        '            .pnColorME.BackColor = Color.White
        '            .pnColorMN.BackColor = Color.Yellow


        '        Case "EXT"

        '            .lblIdProveedor = CStr(TextBoxExt4.Tag)
        '            .lblNomProveedor = TextBoxExt4.Text
        '            .lblCuentaProveedor = "1212"
        '            .lblIdDocumento.Text = CStr(IDDocumentoCompra)
        '            'Nuevo Maykol correccion
        '            .txtProveedor.Text = TextBoxExt4.Text
        '            .txtProveedor.Tag = TextBoxExt4.Tag
        '            ' End If

        '            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
        '                If Not i.EstadoCobro = "DC" Then
        '                    detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)

        '                    cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
        '                    cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
        '                    If cTotalmn < 0 Then
        '                        cTotalmn = 0
        '                    End If
        '                    If cTotalme < 0 Then
        '                        cTotalme = 0
        '                    End If
        '                    saldomn += cTotalmn
        '                    saldome += cTotalme
        '                    If cTotalmn > 0 Or cTotalme > 0 Then
        '                        .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
        '                                                   Nothing, cTotalmn, cTotalme,
        '                                                   "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
        '                    End If
        '                End If
        '            Next

        '            .lblDeudaPendiente.Text = CStr(CDec(saldomn))
        '            .lblDeudaPendienteme.Text = CStr((saldome))
        '            .btnSaldoCobro.Text = CDec(saldome)
        '            .lblMonedaCobro.Text = "EXTRANJERA:"
        '            Dim tablaSA As New tablaDetalleSA
        '            Dim tablaBL As New tabladetalle

        '            tablaBL = tablaSA.GetUbicarTablaID(10, CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoDoc")))

        '            .txtComprobante.Text = tablaBL.descripcion
        '            .txtComprobante.Tag = tablaBL.codigoDetalle
        '            .txtNumeroCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("numero")
        '            .txtSerieCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("serie")

        '            .lblTipoCambio.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
        '            .txtFechaComprobante.Text = (GridGroupingControl3.Table.CurrentRecord.GetValue("fecha"))
        '            Dim DSFS As String = GridGroupingControl3.Table.CurrentRecord.GetValue("moneda")
        '            Select Case GridGroupingControl3.Table.CurrentRecord.GetValue("moneda")
        '                Case "NAC"
        '                    .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
        '                Case "EXT"
        '                    .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
        '            End Select

        '            .pnSaldoMN.Location = New Point(25, 70)
        '            .pnSaldoME.Location = New Point(25, 45)
        '            .pnColorME.BackColor = Color.Yellow
        '            .pnColorMN.BackColor = Color.White


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

        '        .cboTipoDocument.Enabled = True
        '        .cboTipoDocument.ReadOnly = False
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()

        '    End If
        'End With
        'End Select
        Me.Cursor = Cursors.Arrow
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

    Private Sub btnNuevoPagoAnticipoPagos(strMoneda As String, IDDocumentoCompra As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA
        Dim objLista2 As New documentoAnticipoDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA

        With FrmPagosConAnticipo
            '.dgvDetalleItems.Rows.Clear()
            .dgvDetalleItems.Table.Records.DeleteAll()
            .GridGroupingControl1.Table.Records.DeleteAll()
            .manipulacionEstado = ENTITY_ACTIONS.INSERT
            Select Case strMoneda
                Case "NAC"
                    '     If TabPagoProveedor Is TabCuentasPagar.SelectedTab Then
                    .lblIdProveedor = TextBoxExt4.Tag
                    .lblNomProveedor = TextBoxExt4.Text
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento.Text = IDDocumentoCompra
                    .txtProveedor.Text = TextBoxExt4.Text
                    .txtProveedor.Tag = TextBoxExt4.Tag
                    'ElseIf TabPageDevolucion Is TabCuentasPagar.SelectedTab Then
                    '.lblIdProveedor = txtcliDev.Tag
                    '.lblNomProveedor = txtcliDev.Text
                    '.lblCuentaProveedor = "4212"
                    '.lblIdDocumento.Text = IDDocumentoCompra
                    '.txtProveedor.Text = txtcliDev.Text
                    '.txtProveedor.Tag = txtcliDev.Tag
                    'End If

                    Dim listaPago As List(Of documentoAnticipoDetalle)
                    listaPago = objLista2.ObtenerCuentasPagadasAnticipo(IDDocumentoCompra)

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)
                        If Not i.EstadoCobro = "PG" Then
                            detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

                            Dim consulta = (From c In listaPago _
                                            Where c.secuencia = i.secuencia).FirstOrDefault

                            cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn - consulta.MontoPagadoSoles)
                            cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme - consulta.MontoPagadoUSD)


                            If cTotalmn < 0 Then
                                cTotalmn = 0
                            End If
                            If cTotalme < 0 Then
                                cTotalme = 0
                            End If
                            saldomn += cTotalmn
                            saldome += cTotalme
                            If cTotalmn > 0 Or cTotalme > 0 Then
                                '.dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                '                           Nothing, cTotalmn, cTotalme,
                                '                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)

                                .dgvDetalleItems.Table.AddNewRecord.SetCurrent()
                                .dgvDetalleItems.Table.AddNewRecord.BeginEdit()
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("id", i.idItem)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("descripcion", i.DetalleItem)
                                '.dgvDetalleItems.Table.CurrentRecord.SetValue("unidad", Nothing)
                                '.dgvDetalleItems.Table.CurrentRecord.SetValue("precUnit", Nothing)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("importeMN", cTotalmn)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("importeME", cTotalme)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("PagoMN", CDec(0.0))
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("PagoME", CDec(0.0))
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("SaldoMN", cTotalmn)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("SaldoME", cTotalme)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("estado", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                                .dgvDetalleItems.Table.AddNewRecord.EndEdit()

                            End If
                        End If
                    Next

                    .lblDeudaPendiente.Text = CStr(saldomn)
                    .lblDeudaPendienteme.Text = CStr(saldome)

                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("numero"))
                    .txtSerieCompr.Text = CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("serie"))
                    .txtTipoCambio.Value = CDec(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio"))
                    .lblTipoCambio.Text = CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio"))
                    .txtFechaComprobante.Text = CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("fecha"))

                    Select Case GridGroupingControl3.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select

                Case "EXT"
                    '  If TabPagoProveedor Is TabCuentasPagar.SelectedTab Then
                    .lblIdProveedor = CStr(TextBoxExt4.Tag)
                    .lblNomProveedor = TextBoxExt4.Text
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = TextBoxExt4.Text
                    .txtProveedor.Tag = TextBoxExt4.Tag
                    'ElseIf TabPageDevolucion Is TabCuentasPagar.SelectedTab Then
                    '.lblIdProveedor = CStr(txtcliDev.Tag)
                    '.lblNomProveedor = txtcliDev.Text
                    '.lblCuentaProveedor = "4212"
                    '.lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    '.txtProveedor.Text = txtcliDev.Text
                    '.txtProveedor.Tag = txtcliDev.Tag
                    'End If

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)
                        If Not i.EstadoCobro = "PG" Then
                            detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                            cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn)
                            cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme)
                            If cTotalmn < 0 Then
                                cTotalmn = 0
                            End If
                            If cTotalme < 0 Then
                                cTotalme = 0
                            End If
                            saldomn += cTotalmn
                            saldome += cTotalme
                            If cTotalmn > 0 Or cTotalme > 0 Then
                                '.dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                '                           Nothing, cTotalmn, cTotalme,
                                '                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)

                                .dgvDetalleItems.Table.AddNewRecord.SetCurrent()
                                .dgvDetalleItems.Table.AddNewRecord.BeginEdit()
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("id", i.idItem)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("descripcion", i.DetalleItem)
                                '.dgvDetalleItems.Table.CurrentRecord.SetValue("unidad", Nothing)
                                '.dgvDetalleItems.Table.CurrentRecord.SetValue("precUnit", Nothing)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("importeMN", cTotalmn)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("importeME", cTotalme)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("PagoMN", CDec(0.0))
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("PagoME", CDec(0.0))
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("SaldoMN", cTotalmn)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("SaldoME", cTotalme)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("estado", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                .dgvDetalleItems.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                                .dgvDetalleItems.Table.AddNewRecord.EndEdit()

                            End If
                        End If
                    Next

                    .lblDeudaPendiente.Text = CStr(saldomn)
                    .lblDeudaPendienteme.Text = CStr(saldome)

                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("serie")
                    .txtTipoCambio.Value = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
                    .lblTipoCambio.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("fecha")
                    Dim DSFS As String = GridGroupingControl3.Table.CurrentRecord.GetValue("moneda")
                    Select Case GridGroupingControl3.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select

            End Select

            If CDec(saldomn) <= 0 Then

                lblEstado.Text = "El documento ya se encuentra pagado."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else

                .lblPerido.Text = PeriodoGeneral

                .getTableAnticiposPorTipoProveedor(TextBoxExt4.Tag)
                '.cboTipoDoc.Enabled = True
                '.cboTipoDoc.ReadOnly = False
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()

            End If
        End With

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

    Private Sub UbicarVentaNroSerieExcedente(RucCliente As Integer, intMoneda As String)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

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

        documentoVenta = documentoVentaSA.UbicarExcedenteVentaPorClienteXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intMoneda)
        'documentoVenta = documentoVentaSA.UbicarVentaPorClienteXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intMoneda)

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
                dr(5) = i.numeroDocNormal
                Select Case i.moneda
                    Case 1
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN
                dr(11) = i.PagoSumaME
                dr(12) = CDec(SaldoPagosMN).ToString("N2")
                dr(13) = CDec(SaldoPagosME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                dt.Rows.Add(dr)
            Next
            GridGroupingControl3.DataSource = dt
            Me.GridGroupingControl3.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Private Sub devolverExcedente(strMoneda As String, IDDocumentoCompra As Integer)
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

        'Select Case TipoCompra

        '    Case TIPO_VENTA.VENTA_NORMAL_CREDITO
        With frmDevolucionAproveedor
            .dgvDetalleItems.Rows.Clear()
            ' .manipulacionEstado = ENTITY_ACTIONS.INSERT
            Select Case strMoneda
                Case "NAC"
                    'If TabPagoProveedor Is TabCuentasPagar.SelectedTab Then
                    '    .lblIdProveedor = CStr(txtCliente.Tag)
                    '    .lblNomProveedor = txtCliente.Text
                    '    .lblCuentaProveedor = "4212"
                    '    .lblIdDocumento = CStr(IDDocumentoCompra)
                    'ElseIf TabPageDevolucion Is TabCuentasPagar.SelectedTab Then


                    .lblIdProveedor = CStr(TextBoxExt4.Tag)
                    .lblNomProveedor = TextBoxExt4.Text
                    .txtProveedor.Tag = CStr(TextBoxExt4.Tag)
                    .txtProveedor.Text = TextBoxExt4.Text
                    .txtSerieCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("serie")
                    .txtNumeroCompr.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("numero")
                    .txtTipoCambio.Value = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
                    .lblTipoCambio.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio")
                    .manipulacionEstado = ENTITY_ACTIONS.INSERT
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento = CStr(IDDocumentoCompra)
                    ' End If

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)

                        cTotalmn = CDec(i.MontoDeudaSoles) - CDec(i.MontoPagadoSoles)
                        cTotalme = CDec(i.MontoDeudaUSD) - CDec(i.MontoPagadoUSD)
                        saldomn += cTotalmn
                        saldome += cTotalme
                        If cTotalmn > 0 Or cTotalme > 0 Then
                            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                       Nothing, cTotalmn, cTotalme,
                                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                        End If

                    Next

                    .lblDeudaPendiente.Text = CStr(CDec(saldomn))
                    .lblDeudaPendienteme.Text = CStr(CDec(saldome))

                    .txtSaldoPorPagar.Text = CStr(CDec(saldomn))

                Case Else

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
                .txtFechaComprobante.Text = (DateTime.Now).ToString  ' New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                '     .txtFechaComprobante.Enabled = False
                '  .lblPerido.Text = PeriodoGeneral
                .cboTipoDocumento.Enabled = True
                .cboTipoDocumento.ReadOnly = False
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
#End Region

#Region "Events"
    Private Sub txtPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles txtPeriodo.ValueChanged
        GridGroupingControl3.Table.Records.DeleteAll()
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.Cursor = Cursors.WaitCursor
        If TextBoxExt4.Text.Trim.Length > 0 Then

            'UbicarVentaNroSerieExcedente(TextBoxExt4.Tag)

            Select Case cboMonedaCobro.Text
                Case "NACIONAL"
                    UbicarVentaNroSerieExcedente(TextBoxExt4.Tag, "1")
                    'UbicarVentaNroSeriePago(txtBuscarProveedorPago.Tag, "1")
                Case "EXTRANJERA"
                    UbicarVentaNroSerieExcedente(TextBoxExt4.Tag, "2")
            End Select



        Else
            lblEstado.Text = "Seleccione un cliente antes de realizar la tarea!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        'If GridGroupingControl3.Table.SelectedRecords.Count > 0 Then
        '    devolverExcedente(GridGroupingControl3.Table.CurrentRecord.GetValue("moneda"), GridGroupingControl3.Table.CurrentRecord.GetValue("idDocumento"))
        'End If

        Dim fechaAnt = New Date(txtPeriodo.Value.Year, CInt(txtPeriodo.Value.Month), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If
        If GridGroupingControl3.Table.SelectedRecords.Count > 0 Then
            btnNuevoPagoReclamaciones(GridGroupingControl3.Table.CurrentRecord.GetValue("moneda"), GridGroupingControl3.Table.CurrentRecord.GetValue("idDocumento"))
        End If
    End Sub

    Private Sub GridGroupingControl3_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl3.TableControlCellClick

    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Me.Cursor = Cursors.WaitCursor
        If GridGroupingControl3.Table.SelectedRecords.Count > 0 Then
            If TextBoxExt4.Text.Trim.Length > 0 Then
                With frmHistorial
                    .IdDocumentoCompra = GridGroupingControl3.Table.CurrentRecord.GetValue("idDocumento")
                    '.LoadHistorialCajasXcompra()
                    .LoadHistorialCajasXcompra2("VENTA")
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Dim fechaAnt = New Date(txtPeriodo.Value.Year, CInt(txtPeriodo.Value.Month), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.GridGroupingControl3.Table.CurrentRecord) Then

            If GridGroupingControl3.Table.CurrentRecord.GetValue("estadoPago") = "Pendiente" Then

                If GridGroupingControl3.Table.CurrentRecord.GetValue("moneda") = "NAC" Then

                    With frmCompensacionDeDocumentos
                        .txtProveedor.Text = TextBoxExt4.Text
                        .txtProveedor.Tag = TextBoxExt4.Tag
                        .txtRuc.Text = TextBoxExt3.Text
                        .lblTipoEntidad.Text = "CL"
                        ' sdgfsdgsdg



                        Dim tablaSA As New tablaDetalleSA
                        Dim tablaBL As New tabladetalle

                        tablaBL = tablaSA.GetUbicarTablaID(10, CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoDoc")))

                        .txtComprobante.Text = tablaBL.descripcion
                        .txtComprobante.Tag = tablaBL.codigoDetalle
                        .txtNumeroCompr.Text = CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("numero"))
                        .txtSerieCompr.Text = CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("serie"))
                        .txtTipoCambio.Text = CDec(GridGroupingControl3.Table.CurrentRecord.GetValue("tipoCambio"))

                        .txtFechaComprobante.Text = CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("fecha"))
                        .lblIdDocumento.Text = GridGroupingControl3.Table.CurrentRecord.GetValue("idDocumento")

                        .txtImporteMN.Text = CDec(GridGroupingControl3.Table.CurrentRecord.GetValue("importeMN") - GridGroupingControl3.Table.CurrentRecord.GetValue("abonoMN"))
                        .txtImporteME.Text = CDec(GridGroupingControl3.Table.CurrentRecord.GetValue("importeME") - GridGroupingControl3.Table.CurrentRecord.GetValue("abonoME"))
                        .txtMoneda.Text = CStr(GridGroupingControl3.Table.CurrentRecord.GetValue("moneda"))

                        .btnNuevoCobro(GridGroupingControl3.Table.CurrentRecord.GetValue("moneda"), GridGroupingControl3.Table.CurrentRecord.GetValue("idDocumento"))
                        .Label8.Text = "VENTAS"
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

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
        f.CaptionLabels(0).Text = "Cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, entidad)
            'Dim c = CType(f.Tag, entidad)
            TextBoxExt4.Text = c.nombreCompleto
            TextBoxExt4.Tag = c.idEntidad
            TextBoxExt3.Text = c.nrodoc
            TextBoxExt3.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            TextBoxExt4.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridGroupingControl3_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridGroupingControl3.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            GridGroupingControl3.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub GridGroupingControl3_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles GridGroupingControl3.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, GridGroupingControl3)
    End Sub

#End Region


End Class