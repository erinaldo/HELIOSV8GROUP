Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabFN_CuentasPagar

#Region "Fields"
    Private empresaPeriodoSA As New empresaCierreMensualSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridPequeño(dgvPagosVarios, True)
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

    Private Sub UbicarVentaNroSeriePago(RucCliente As Integer, intMoneda As String)
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoVenta As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        '      Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

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
        dt.Columns.Add("montoProg", GetType(Integer))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("proveedor", GetType(String))
        dt.Columns.Add("nrodocEntidad", GetType(String))

        '.fechaContable = strPeriodo,
        documentoVenta = documentoVentaSA.GetConsultaCuentasPorpagar(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                               .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                               .idProveedor = RucCliente,
                                                                                               .fechaDoc = strPeriodo,
                                                                                               .monedaDoc = intMoneda})

        'documentoVenta = documentoVentaSA.UbicarCompraPorProveedorXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intMoneda)
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

                'If SaldoPagosMN < 0 Then
                '    SaldoPagosMN = 0
                'End If

                'If SaldoPagosME < 0 Then
                '    SaldoPagosME = 0
                'End If

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

                        'dr(10) = i.ImportePagoMN
                        'dr(11) = i.ImportePagoME
                        'dr(12) = CDec(i.importeTotal - i.ImportePagoMN).ToString("N2")
                        'dr(13) = CDec(i.importeUS - i.ImportePagoME).ToString("N2")
                    Case Else
                        dr(6) = "EXT"


                End Select
                dr(7) = CDec(i.importeTotal).ToString("N2") '- CDec(i.PagoNotaCreditoMN).ToString("N2") + CDec(i.PagoNotaDebitoMN).ToString("N2")
                dr(8) = i.tcDolLoc
                dr(9) = CDec(i.importeUS.GetValueOrDefault).ToString("N2") '- CDec(i.PagoNotaCreditoME).ToString("N2") + CDec(i.PagoNotaDebitoME).ToString("N2")
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN '+ i.PagoNotaDebitoMN '  CDec(i.PagoSumaMN).ToString("N2")
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME '+ i.PagoNotaDebitoME ' CDec(i.PagoSumaME).ToString("N2")
                dr(12) = SaldoPagosMN ' i.SaldoComprobanteDocumentoCompraMN '  CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(13) = SaldoPagosME ' i.SaldoComprobanteDocumentoCompraME 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")
                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                dr(15) = i.conteoCuotas
                dr(16) = i.idProveedor
                dr(17) = i.NombreEntidad
                dr(18) = i.NroDocEntidad
                dt.Rows.Add(dr)
            Next

            Select Case cboMonedaProveedor.Text
                Case "NACIONAL"
                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 70

                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


            dgvPagosVarios.DataSource = dt
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvPagosVarios.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Private Sub GetCuentasXPagarProveedoresPeriodo(intMoneda As String)
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoVenta As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        '      Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

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
        dt.Columns.Add("montoProg", GetType(Integer))

        dt.Columns.Add("idProveedor", GetType(String))
        dt.Columns.Add("proveedor", GetType(String))
        dt.Columns.Add("nrodocEntidad", GetType(String))



        '.fechaContable = strPeriodo,
        documentoVenta = documentoVentaSA.GetConsultaCuentasPorpagarTodosProveedores(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                               .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                               .fechaDoc = strPeriodo,
                                                                                               .monedaDoc = intMoneda})

        'documentoVenta = documentoVentaSA.UbicarCompraPorProveedorXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intMoneda)
        Dim str As String
        If Not IsNothing(documentoVenta) Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In documentoVenta.OrderBy(Function(o) o.NombreEntidad).ToList
                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.importeTotal - i.PagoSumaMN
                SaldoPagosME = i.importeUS - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN - i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME - i.PagoNotaCreditoME + i.PagoNotaDebitoME

                'If SaldoPagosMN < 0 Then
                '    SaldoPagosMN = 0
                'End If

                'If SaldoPagosME < 0 Then
                '    SaldoPagosME = 0
                'End If

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

                        'dr(10) = i.ImportePagoMN
                        'dr(11) = i.ImportePagoME
                        'dr(12) = CDec(i.importeTotal - i.ImportePagoMN).ToString("N2")
                        'dr(13) = CDec(i.importeUS - i.ImportePagoME).ToString("N2")
                    Case Else
                        dr(6) = "EXT"


                End Select
                dr(7) = CDec(i.importeTotal).ToString("N2") '- CDec(i.PagoNotaCreditoMN).ToString("N2") + CDec(i.PagoNotaDebitoMN).ToString("N2")
                dr(8) = i.tcDolLoc
                dr(9) = CDec(i.importeUS.GetValueOrDefault).ToString("N2") '- CDec(i.PagoNotaCreditoME).ToString("N2") + CDec(i.PagoNotaDebitoME).ToString("N2")
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN '+ i.PagoNotaDebitoMN '  CDec(i.PagoSumaMN).ToString("N2")
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME '+ i.PagoNotaDebitoME ' CDec(i.PagoSumaME).ToString("N2")
                dr(12) = SaldoPagosMN ' i.SaldoComprobanteDocumentoCompraMN '  CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(13) = SaldoPagosME ' i.SaldoComprobanteDocumentoCompraME 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")
                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                dr(15) = i.conteoCuotas

                dr(16) = i.idProveedor
                dr(17) = i.NombreEntidad
                dr(18) = i.NroDocEntidad
                dt.Rows.Add(dr)
            Next

            Select Case cboMonedaProveedor.Text
                Case "NACIONAL"
                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 70

                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


            dgvPagosVarios.DataSource = dt
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            Me.dgvPagosVarios.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Private Sub btnNuevoPagoPago(strMoneda As String, IDDocumentoCompra As Integer)
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

        Dim rec As Record = dgvPagosVarios.Table.CurrentRecord

        With frmModalPagos
            .txtTipoCambio.DoubleValue = TmpTipoCambio
            .dgvDetalleItems.Rows.Clear()
            .manipulacionEstado = ENTITY_ACTIONS.INSERT
            .CaptionLabels(0).Text = "PAGOS - " & rec.GetValue("proveedor") ' txtBuscarProveedorPago.Text
            '  .Text = "Cuentas X Pagar"
            Select Case strMoneda
                Case "NAC"
                    .txtPeriodo.Value = New Date(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)
                    .lblIdProveedor = rec.GetValue("idProveedor") ' txtBuscarProveedorPago.Tag
                    .lblNomProveedor = rec.GetValue("proveedor") ' txtBuscarProveedorPago.Text
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento.Text = IDDocumentoCompra
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = rec.GetValue("proveedor") 'txtBuscarProveedorPago.Text
                    .txtProveedor.Tag = rec.GetValue("idProveedor") '  txtBuscarProveedorPago.Tag
                    .txtEntidad.Text = rec.GetValue("proveedor")
                    .txtEntidad.Tag = rec.GetValue("idProveedor") ' txtBuscarProveedorPago.Tag
                    .txtNroDocEntidad.Text = rec.GetValue("nrodocEntidad") 'txtRucPago.Text
                    .txtTipoEntidad.Text = "PR"
                    'ElseIf TabPageDevolucion Is TabCuentasPagar.SelectedTab Then
                    '    .lblIdProveedor = txtcliDev.Tag
                    '    .lblNomProveedor = txtcliDev.Text
                    '    .lblCuentaProveedor = "4212"
                    '    .lblIdDocumento.Text = IDDocumentoCompra
                    '    .txtProveedor.Text = txtcliDev.Text
                    '    .txtProveedor.Tag = txtcliDev.Tag
                    'End If

                    'martin
                    Dim listaPago As List(Of documentoAnticipoDetalle)
                    listaPago = objLista2.ObtenerCuentasPagadasAnticipo(IDDocumentoCompra)

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)
                        If i.bonificacion <> "S" Then
                            If Not i.EstadoCobro = "PG" Then
                                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

                                'martin
                                Dim consulta = (From c In listaPago
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



                                    'Dim dr As DataRow = .DT.NewRow()

                                    'dr(0) = CDec(i.idItem)
                                    'dr(1) = i.DetalleItem
                                    'dr(2) = Nothing
                                    'dr(3) = 0
                                    'dr(4) = cTotalmn
                                    'dr(5) = cTotalme
                                    'dr(6) = 0
                                    'dr(7) = 0
                                    'dr(8) = 0
                                    'dr(9) = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT
                                    'dr(10) = i.secuencia
                                    '.DT.Rows.Add(dr)
                                    '.dgvPagos.DataSource = .DT

                                    '.dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                    '                          Nothing, cTotalmn, cTotalme,
                                    '                          "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)

                                    .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                           Nothing, cTotalmn, (cTotalmn / TmpTipoCambioTransaccionVenta).ToString("N2"),
                                                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                                End If
                            End If
                        End If

                    Next
                    'txtImporteCompramn.Text = saldomn.ToString("N2")
                    'txtImporteComprame.Text = saldome.ToString("N2")

                    '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                    '.lblDeudaPendienteme.Text = CStr(saldome)
                    '.txtSaldoPorPagar.Text = CDec(saldomn)
                    '.lblMonedaCobro.Text = "NACIONAL"

                    .lblDeudaPendienteme.Text = CStr(saldome)
                    .txtSaldoPorPagar.Text = CDec(saldomn)
                    .DigitalGauge2.Value = CDec(saldomn)
                    .lblMonedaCobro.Text = "NACIONAL"
                    .lblMonedaCobro.Tag = 1


                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle

                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvPagosVarios.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = dgvPagosVarios.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = dgvPagosVarios.Table.CurrentRecord.GetValue("serie")
                    .txtTipoCambio.DoubleValue = dgvPagosVarios.Table.CurrentRecord.GetValue("tipoCambio")
                    .lblTipoCambio.Text = dgvPagosVarios.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = dgvPagosVarios.Table.CurrentRecord.GetValue("fecha")

                    Select Case dgvPagosVarios.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select
                    .cargarDatosCompra(0)

                Case "EXT"
                    .txtPeriodo.Value = New Date(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)
                    .lblIdProveedor = CInt(rec.GetValue("idProveedor"))
                    .lblNomProveedor = rec.GetValue("proveedor")
                    .lblCuentaProveedor = "4212"
                    .lblIdDocumento.Text = IDDocumentoCompra
                    'Nuevo Maykol correccion
                    .txtProveedor.Text = rec.GetValue("proveedor") 'txtBuscarProveedorPago.Text
                    .txtProveedor.Tag = rec.GetValue("idProveedor") '  txtBuscarProveedorPago.Tag
                    .txtEntidad.Text = rec.GetValue("proveedor")
                    .txtEntidad.Tag = rec.GetValue("idProveedor") ' txtBuscarProveedorPago.Tag
                    .txtNroDocEntidad.Text = rec.GetValue("nrodocEntidad") 'txtRucPago.Text
                    .txtTipoEntidad.Text = "PR"
                    'ElseIf TabPageDevolucion Is TabCuentasPagar.SelectedTab Then
                    '    .lblIdProveedor = txtcliDev.Tag
                    '    .lblNomProveedor = txtcliDev.Text
                    '    .lblCuentaProveedor = "4212"
                    '    .lblIdDocumento.Text = IDDocumentoCompra
                    '    .txtProveedor.Text = txtcliDev.Text
                    '    .txtProveedor.Tag = txtcliDev.Tag
                    'End If


                    Dim tablaSA As New tablaDetalleSA
                    Dim tablaBL As New tabladetalle
                    Dim tipoCambio As Decimal
                    tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvPagosVarios.Table.CurrentRecord.GetValue("tipoDoc")))

                    .txtComprobante.Text = tablaBL.descripcion
                    .txtComprobante.Tag = tablaBL.codigoDetalle
                    .txtNumeroCompr.Text = dgvPagosVarios.Table.CurrentRecord.GetValue("numero")
                    .txtSerieCompr.Text = dgvPagosVarios.Table.CurrentRecord.GetValue("serie")
                    tipoCambio = dgvPagosVarios.Table.CurrentRecord.GetValue("tipoCambio")
                    .lblTipoCambio.Text = dgvPagosVarios.Table.CurrentRecord.GetValue("tipoCambio")
                    .txtFechaComprobante.Text = dgvPagosVarios.Table.CurrentRecord.GetValue("fecha")
                    Dim DSFS As String = dgvPagosVarios.Table.CurrentRecord.GetValue("moneda")
                    Select Case dgvPagosVarios.Table.CurrentRecord.GetValue("moneda")
                        Case "NAC"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        Case "EXT"
                            .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    End Select



                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetailsME(IDDocumentoCompra)
                        If i.bonificacion <> "S" Then
                            If Not i.EstadoCobro = "PG" Then
                                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                                cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme)
                                cTotalmn = CDec(CDec(cTotalme * tipoCambio).ToString("N2"))
                                If cTotalmn < 0 Then
                                    cTotalmn = 0
                                End If
                                If cTotalme < 0 Then
                                    cTotalme = 0
                                End If
                                saldomn += cTotalmn
                                saldome += cTotalme
                                If cTotalmn > 0 Or cTotalme > 0 Then

                                    'Dim dr As DataRow = .DT.NewRow()

                                    'dr(0) = CDec(i.idItem)
                                    'dr(1) = i.DetalleItem
                                    'dr(2) = Nothing
                                    'dr(3) = 0
                                    'dr(4) = cTotalmn
                                    'dr(5) = cTotalme
                                    'dr(6) = 0
                                    'dr(7) = 0
                                    'dr(8) = 0
                                    'dr(9) = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT
                                    'dr(10) = i.secuencia
                                    '.DT.Rows.Add(dr)
                                    '.dgvPagos.DataSource = .DT

                                    '.dgvPagos.DataSource = .UbicarCajasHijas()
                                    '.dgvPagos.Table.AddNewRecord.SetCurrent()
                                    '.dgvPagos.Table.AddNewRecord.BeginEdit()
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colId", CDec(i.idItem))
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colNameItem", i.DetalleItem)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colum", Nothing)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("ColPrecUnit", 0)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colMN", cTotalmn)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colME", cTotalme)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colPagoMN", 0)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colPagoME", 0)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colSaldoMN", 0)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colSaldoME", 0)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colEstado", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                    '.dgvPagos.Table.CurrentRecord.SetValue("colSecuencia", i.secuencia)
                                    '.dgvPagos.Table.AddNewRecord.EndEdit()


                                    .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                               Nothing, cTotalmn, cTotalme,
                                                               "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                                End If
                            End If
                        End If

                    Next

                    'txtImporteCompramn.Text = saldomn.ToString("N2")
                    'txtImporteComprame.Text = saldome.ToString("N2")
                    '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                    .lblDeudaPendienteme.Text = CDec(saldome)
                    .txtSaldoPorPagar.Text = CDec(saldome)
                    .lblMonedaCobro.Text = "EXTRANJERA"
                    .cargarDatosCompra(1)

            End Select

            If CDec(saldomn) <= 0 Then
                '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                MessageBox.Show("El documento ya se encuentra pagado.")
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
                .PanelDetallePagos.Enabled = False
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
    Private Sub dgvCobranzaCli_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPagosVarios.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvPagosVarios.TableControl.Selections.Clear()
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

    Private Sub dgvCobranzaCli_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvPagosVarios.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvPagosVarios)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        If Not IsNothing(Me.dgvPagosVarios.Table.CurrentRecord) Then

            'Dim fechaAnt = New Date(txtPeriodo.Value.Year, CInt(txtPeriodo.Value.Month), 1)
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Me.Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If

            If dgvPagosVarios.Table.SelectedRecords.Count > 0 Then

                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                    btnNuevoPagoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))

                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsNothing(Me.dgvPagosVarios.Table.CurrentRecord) Then
                If dgvPagosVarios.Table.SelectedRecords.Count > 0 Then
                    'If txtBuscarProveedorPago.Text.Trim.Length > 0 Then
                    With frmHistorial
                        .IdDocumentoCompra = dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento")
                        .lbltipoanticipo.Text = "ANTICIPO"
                        .LoadHistorialCajasXcompra()
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                    'End If
                End If
            Else
                MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        GetCuentasXPagarProveedoresPeriodo("1")
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
            txtBuscarProveedorPago.Text = c.nombreCompleto
            txtBuscarProveedorPago.Tag = c.idEntidad
            txtRucPago.Text = c.nrodoc
            txtRucPago.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtBuscarProveedorPago.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

            If txtBuscarProveedorPago.Text.Trim.Length > 0 Then
                Select Case cboMonedaProveedor.Text
                    Case "NACIONAL"
                        UbicarVentaNroSeriePago(txtBuscarProveedorPago.Tag, "1")

                    Case "EXTRANJERA"
                        UbicarVentaNroSeriePago(txtBuscarProveedorPago.Tag, "2")
                End Select
            Else
                MessageBox.Show("Seleccione un proveedor antes de realizar la tarea!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub txtPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles txtPeriodo.ValueChanged
        dgvPagosVarios.Table.Records.DeleteAll()
    End Sub
#End Region

End Class
