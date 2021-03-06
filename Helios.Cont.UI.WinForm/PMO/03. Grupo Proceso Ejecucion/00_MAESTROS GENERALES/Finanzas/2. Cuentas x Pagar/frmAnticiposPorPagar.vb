Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmAnticiposPorPagar
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
        FormatoGridPequeño(dgvPagosVarios2, True)
        FormatoGridPequeño(GridGroupingControl5, True)
        txtPeriodo2.Value = DateTime.Now
        UbicarFull()
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

    Private Sub UbicarFull()
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim documentoAnticipo As New List(Of documentoAnticipo)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo2.Value.Month)) & "/" & txtPeriodo2.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("igv", GetType(Decimal))
        dt.Columns.Add("importeTotal", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))

        documentoVenta = documentoVentaSA.UbicarVentaPorProveedorXperiodoFull(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, "VAO")
        documentoAnticipo = documentoAnticipoSA.ObtenerOtrosAportesXFinanzasFull(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, "AR")
        Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
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
                    Case 1
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.igv01
                dr(8) = i.bi01
                dr(9) = i.ImporteNacional
                dr(10) = i.tipoCambio
                dr(11) = i.ImporteExtranjero
                dr(12) = 0
                dr(13) = 0
                dr(14) = 0 'CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(15) = 0 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")

                'Select Case i.estadoPago
                '    Case TIPO_COMPRA.PAGO.PAGADO
                '        dr(14) = "Saldado"
                '    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                '        dr(14) = "Pendiente"
                'End Select
                dt.Rows.Add(dr)
            Next
            dgvPagosVarios2.DataSource = dt
            Me.dgvPagosVarios2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If

        Dim str2 As String
        If Not IsNothing(documentoAnticipo) Then
            For Each i In documentoAnticipo
                Dim dr As DataRow = dt.NewRow()
                str2 = Nothing
                str2 = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str2
                dr(2) = i.tipoMovimiento
                dr(3) = i.tipoDocumento
                dr(4) = i.numeroDoc
                dr(5) = i.numeroDoc
                Select Case i.Moneda
                    Case 1
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select

                dr(7) = i.importeMN
                dr(8) = 0.0
                dr(9) = i.importeMN
                dr(10) = i.TipoCambio
                dr(11) = i.importeME
                dr(12) = 0 'CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(13) = 0 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")
                dr(14) = 0 'CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(15) = 0 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")
                'Select Case i.estadopago
                '    Case TIPO_COMPRA.PAGO.PAGADO
                '        dr(14) = "Saldado"
                '    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                '        dr(14) = "Pendiente"
                'End Select
                dt.Rows.Add(dr)
            Next
            dgvPagosVarios2.DataSource = dt
            Me.dgvPagosVarios2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Private Sub UbicarVentaNroSerieAntPago(RucCliente As Integer)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo2.Value.Month)) & "/" & txtPeriodo2.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("igv", GetType(Decimal))
        dt.Columns.Add("importeTotal", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        documentoVenta = documentoVentaSA.UbicarVentaPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, "VAO")
        Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
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
                    Case 1
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                'dr(7) = i.importeTotal
                'dr(8) = i.tcDolLoc
                'dr(9) = i.importeUS
                'dr(10) = i.PagoSumaMN
                'dr(11) = i.PagoSumaME
                'dr(12) = CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.importeUS - i.PagoSumaME).ToString("N2")
                dr(7) = i.igv01
                dr(8) = i.bi01
                dr(9) = i.ImporteNacional
                dr(10) = i.tipoCambio
                dr(11) = i.ImporteExtranjero
                dr(12) = 0
                dr(13) = 0
                dr(14) = 0 'CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(15) = 0 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")

                'Select Case i.estadoPago
                '    Case TIPO_COMPRA.PAGO.PAGADO
                '        dr(14) = "Saldado"
                '    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                '        dr(14) = "Pendiente"
                'End Select
                dt.Rows.Add(dr)
            Next
            dgvPagosVarios2.DataSource = dt
            Me.dgvPagosVarios2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Private Sub UbicarVentaNroSerieAntPagoXFinanzas(RucCliente As Integer)
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim documentoAnticipo As New List(Of documentoAnticipo)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo2.Value.Month)) & "/" & txtPeriodo2.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("igv", GetType(Decimal))
        dt.Columns.Add("importeTotal", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))

        documentoAnticipo = documentoAnticipoSA.ObtenerOtrosAportesXFinanzas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, "AR")
        Dim str As String
        If Not IsNothing(documentoAnticipo) Then
            For Each i In documentoAnticipo
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoMovimiento
                dr(3) = i.tipoDocumento
                dr(4) = i.numeroDoc
                dr(5) = i.numeroDoc
                Select Case i.Moneda
                    Case 1
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.importeMN
                dr(8) = 0.0
                dr(9) = i.importeMN
                dr(10) = i.TipoCambio
                dr(11) = i.importeME
                dr(12) = 0 'i.PagoSumaMN
                dr(13) = 0 'i.PagoSumaME
                dr(14) = 0 'CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(15) = 0 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")

                'Select Case i.estadopago
                '    Case TIPO_COMPRA.PAGO.PAGADO
                '        dr(14) = "Saldado"
                '    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                '        dr(14) = "Pendiente"
                'End Select
                dt.Rows.Add(dr)
            Next
            dgvPagosVarios2.DataSource = dt
            Me.dgvPagosVarios2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Private Sub btnNuevoPagoAnticipo2Pagos(strMoneda As String, IDDocumentoCompra As Integer)
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
                    '  If TabDevolcionNota Is TabCuentasPagar.SelectedTab Then
                    .lblIdProveedor = txtCliente2.Tag
                    .lblNomProveedor = txtCliente2.Text
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento.Text = IDDocumentoCompra
                    .txtProveedor.Text = txtCliente2.Text
                    .txtProveedor.Tag = txtCliente2.Tag
                    '    .txtNroDocEntidad.Text = txtRuc2.Text
                    '      End If
                    '
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

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("serie")
                    .txtTipoCambio.Value = dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoCambio")
                    .lblTipoCambio.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("fecha")

                    Select Case dgvPagosVarios2.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select

                Case "EXT"
                    '  If TabDevolcionNota Is TabCuentasPagar.SelectedTab Then
                    .lblIdProveedor = CInt(txtCliente2.Tag)
                    .lblNomProveedor = txtCliente2.Text
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento.Text = IDDocumentoCompra
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = txtCliente2.Text
                    .txtProveedor.Tag = txtCliente2.Tag
                    '   .txtNroDocEntidad.Text = txtRuc2.Text
                    '   End If

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

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("serie")
                    .txtTipoCambio.Value = dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoCambio")
                    .lblTipoCambio.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("fecha")
                    Dim DSFS As String = dgvPagosVarios2.Table.CurrentRecord.GetValue("moneda")
                    Select Case dgvPagosVarios2.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select

            End Select

            If CDec(saldomn) <= 0 Then

                MessageBox.Show("El documento ya se encuentra pagado.")

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else

                .lblPerido.Text = PeriodoGeneral

                .getTableAnticiposPorTipoProveedor(txtCliente2.Tag)
                '.cboTipoDoc.Enabled = True
                '.cboTipoDoc.ReadOnly = False
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()

            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnNuevoPago2Pago(strMoneda As String, IDDocumentoCompra As Integer)
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

        'Select Case TipoCompra

        '    Case TIPO_VENTA.VENTA_NORMAL_CREDITO
        With frmPagos
            .dgvDetalleItems.Rows.Clear()
            .manipulacionEstado = ENTITY_ACTIONS.INSERT
            Select Case strMoneda
                Case "NAC"
                    ' If TabDevolcionNota Is TabCuentasPagar.SelectedTab Then
                    .lblIdProveedor = CStr(txtCliente2.Tag)
                    .lblNomProveedor = txtCliente2.Text
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = txtCliente2.Text
                    .txtProveedor.Tag = txtCliente2.Tag
                    .txtEntidad.Text = txtCliente2.Text
                    .txtEntidad.Tag = txtCliente2.Tag
                    .txtNroDocEntidad.Text = txtRuc2.Text
                    ' End If

                    'martin
                    Dim listaPago As List(Of documentoAnticipoDetalle)
                    listaPago = objLista2.ObtenerCuentasPagadasAnticipo(IDDocumentoCompra)

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)
                        If Not i.EstadoCobro = "PG" Then
                            detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

                            'martin
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
                                .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                           Nothing, cTotalmn, cTotalme,
                                                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                            End If
                        End If
                    Next
                    'txtImporteCompramn.Text = saldomn.ToString("N2")
                    'txtImporteComprame.Text = saldome.ToString("N2")

                    '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                    .txtSaldoPorPagar.DecimalValue = CStr(saldomn)
                    .lblDeudaPendienteme.Text = CStr(saldome)

                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = CStr(dgvPagosVarios2.Table.CurrentRecord.GetValue("numero"))
                    .txtSerieCompr.Text = CStr(dgvPagosVarios2.Table.CurrentRecord.GetValue("serie"))
                    .txtTipoCambio.DoubleValue = CDec(dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoCambio"))
                    .lblTipoCambio.Text = CStr(dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoCambio"))
                    .txtFechaComprobante.Text = CStr(dgvPagosVarios2.Table.CurrentRecord.GetValue("fecha"))

                    Select Case dgvPagosVarios2.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select

                Case "EXT"
                    '   If TabDevolcionNota Is TabCuentasPagar.SelectedTab Then
                    .lblIdProveedor = CStr(txtCliente2.Tag)
                    .lblNomProveedor = txtCliente2.Text
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = txtCliente2.Text
                    .txtProveedor.Tag = txtCliente2.Tag
                    .txtEntidad.Text = txtCliente2.Text
                    .txtEntidad.Tag = txtCliente2.Tag
                    .txtNroDocEntidad.Text = txtRuc2.Text
                    '     End If

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
                                .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                           Nothing, cTotalmn, cTotalme,
                                                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                            End If
                        End If
                    Next
                    'txtImporteCompramn.Text = saldomn.ToString("N2")
                    'txtImporteComprame.Text = saldome.ToString("N2")

                    '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                    .txtSaldoPorPagar.DecimalValue = CStr(saldomn)
                    .lblDeudaPendienteme.Text = CStr(saldome)

                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("serie")
                    .txtTipoCambio.DoubleValue = dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoCambio")
                    .lblTipoCambio.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = dgvPagosVarios2.Table.CurrentRecord.GetValue("fecha")
                    Dim DSFS As String = dgvPagosVarios2.Table.CurrentRecord.GetValue("moneda")
                    Select Case dgvPagosVarios2.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select

            End Select

            If CDec(saldomn) <= 0 Then
                '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                MessageBox.Show("El documento ya se encuentra pagado.")
                '   EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PAGADO)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                '    EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PENDIENTE_PAGO)

                'If .TieneCuentaFinanciera = True Then
                '.txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                '.txtFechaComprobante.Enabled = False
                .lblPerido.Text = PeriodoGeneral
                .cboTipoDoc.Enabled = True
                .cboTipoDoc.ReadOnly = False
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

    Public Sub CargarEntidadesXtipo2(strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor2.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor2.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Events"

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        If dgvPagosVarios2.Table.SelectedRecords.Count > 0 Then
            btnNuevoPago2Pago(dgvPagosVarios2.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios2.Table.CurrentRecord.GetValue("idDocumento"))
        End If
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvPagosVarios2.Table.SelectedRecords.Count > 0 Then
            If txtCliente2.Tag.Trim.Length > 0 Then
                With frmHistorial
                    .IdDocumentoCompra = dgvPagosVarios2.Table.CurrentRecord.GetValue("idDocumento")
                    .lbltipoanticipo.Text = "ANTICIPO"
                    .LoadHistorialCajasXcompra()

                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton26_Click(sender As Object, e As EventArgs) Handles ToolStripButton26.Click
        If Not IsNothing(Me.dgvPagosVarios2.Table.CurrentRecord) Then

            Dim fechaAnt = New Date(txtPeriodo2.Value.Year, CInt(txtPeriodo2.Value.Month), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtPeriodo2.Value.Year, .mes = CInt(txtPeriodo2.Value.Month)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If dgvPagosVarios2.Table.CurrentRecord.GetValue("moneda") = "NAC" Then

                btnNuevoPagoAnticipo2Pagos(dgvPagosVarios2.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios2.Table.CurrentRecord.GetValue("idDocumento"))
            Else
                MessageBox.Show("Solo Se puede Compensar Documentos en Soles")
            End If
        Else
            MessageBox.Show("Seleccione uan compra")
        End If
    End Sub

    Private Sub ButtonAdv16_Click(sender As Object, e As EventArgs) Handles ButtonAdv16.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCliente2.Text.Trim.Length > 0 Then
            If (cboTipoConsulta.Text = "POR FINANZAS") Then
                dgvPagosVarios2.Table.Records.DeleteAll()
                UbicarVentaNroSerieAntPagoXFinanzas(txtCliente2.Tag)
            ElseIf (cboTipoConsulta.Text = "POR VENTA") Then
                dgvPagosVarios2.Table.Records.DeleteAll()
                UbicarVentaNroSerieAntPago(txtCliente2.Tag)
            ElseIf (cboTipoConsulta.Text = "AMBOS") Then
                dgvPagosVarios2.Table.Records.DeleteAll()
                UbicarFull()
            End If
        Else
            MessageBox.Show("Seleccione un proveedor antes de realizar la tarea!")
        End If
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
            txtCliente2.Text = c.nombreCompleto
            txtCliente2.Tag = c.idEntidad
            txtRuc2.Text = c.nrodoc
            txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvPagosVarios2_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPagosVarios2.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvPagosVarios2.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvPagosVarios2_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvPagosVarios2.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvPagosVarios2)
    End Sub

    Private Sub dgvPagosVarios2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPagosVarios2.TableControlCellClick

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        With frmModalAnticipo
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub
#End Region
End Class