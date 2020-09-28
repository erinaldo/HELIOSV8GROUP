Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmCobrosGeneral
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCobranzaCli)
        GridCFG(dgvExcedente)
        GridCFG2(GridGroupingControl1)
        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
    End Sub


#Region "Métodos Cobranza a Clientes"
    Dim colorx As New GridMetroColors()
    Sub GridCFG2(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = True
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
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

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

        '    Case TIPO_VENTA.VENTA_NORMAL_CREDITO
        With frmCobros
            .dgvDetalleItems.Rows.Clear()
            .manipulacionEstado = ENTITY_ACTIONS.INSERT
            Select Case strMoneda
                Case "NAC"
                    If TabPageCobranzaCli Is TabControlAdv1.SelectedTab Then
                        .lblIdProveedor = txtCliente.Tag
                        .lblNomProveedor = txtCliente.Text
                        .lblCuentaProveedor = "1212"
                        .lblIdDocumento.Text = IDDocumentoCompra
                        'Nuevo Maykol correccion
                        .txtProveedor.Text = txtCliente.Text
                        .txtProveedor.Tag = txtCliente.Tag
                    ElseIf TabPageDevolucion Is TabControlAdv1.SelectedTab Then
                        .lblIdProveedor = txtcliDev.Tag
                        .lblNomProveedor = txtcliDev.Text
                        .lblCuentaProveedor = "1212"
                        .lblIdDocumento.Text = IDDocumentoCompra
                        'Nuevo Maykol correccion
                        .txtProveedor.Text = txtCliente.Text
                        .txtProveedor.Tag = txtCliente.Tag
                    End If

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
                        If Not i.EstadoCobro = "DC" Then
                            detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                            'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                            'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                            cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN
                            cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME
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
                    .lblDeudaPendiente.Text = CDec(saldomn)
                    .lblDeudaPendienteme.Text = CDec(saldome)

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
                    If TabPageCobranzaCli Is TabControlAdv1.SelectedTab Then
                        .lblIdProveedor = txtCliente.Tag
                        .lblNomProveedor = txtCliente.Text
                        .lblCuentaProveedor = "1212"
                        .lblIdDocumento.Text = IDDocumentoCompra
                        'Nuevo Maykol correccion
                        .txtProveedor.Text = txtCliente.Text
                        .txtProveedor.Tag = txtCliente.Tag
                    ElseIf TabPageDevolucion Is TabControlAdv1.SelectedTab Then
                        .lblIdProveedor = txtcliDev.Tag
                        .lblNomProveedor = txtcliDev.Text
                        .lblCuentaProveedor = "1212"
                        .lblIdDocumento.Text = IDDocumentoCompra
                        'Nuevo Maykol correccion
                        .txtProveedor.Text = txtCliente.Text
                        .txtProveedor.Tag = txtCliente.Tag
                    End If

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
                        If Not i.EstadoCobro = "DC" Then
                            detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                            'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                            'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                            cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN
                            cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME
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
                    .lblDeudaPendiente.Text = CDec(saldomn)
                    .lblDeudaPendienteme.Text = CDec(saldome)

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
        With frmDevolucionAcliente
            .dgvDetalleItems.Rows.Clear()
            ' .manipulacionEstado = ENTITY_ACTIONS.INSERT
            Select Case strMoneda
                Case "NAC"
                    If TabPageCobranzaCli Is TabControlAdv1.SelectedTab Then
                        .lblIdProveedor = txtCliente.Tag
                        .lblNomProveedor = txtCliente.Text
                        .lblCuentaProveedor = "1212"
                        .lblIdDocumento.Text = IDDocumentoCompra
                    ElseIf TabPageDevolucion Is TabControlAdv1.SelectedTab Then
                        .lblIdProveedor = txtcliDev.Tag
                        .lblNomProveedor = txtcliDev.Text
                        .lblCuentaProveedor = "1212"
                        .lblIdDocumento.Text = IDDocumentoCompra
                    End If

                    For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)

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

                    .lblDeudaPendiente.Text = CDec(saldomn)
                    .lblDeudaPendienteme.Text = CDec(saldome)
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
                .txtFechaComprobante.Value = DateTime.Now ' New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                '     .txtFechaComprobante.Enabled = False
                '  .lblPerido.Text = PeriodoGeneral
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

    Sub GridCFG(GGC As GridGroupingControl)
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
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Function GetParentTable(RucCliente As Integer) As DataTable
        Dim dt As New DataTable("ParentTable")
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt = New DataTable("ParentTable")

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
        dt.Columns.Add("estadoPago", GetType(String))

        documentoVenta = documentoVentaSA.UbicarVentaPorClienteXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, "1")
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
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(10) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(10) = "Pendiente"
                End Select
                dt.Rows.Add(dr)
            Next
        End If
        Return dt
    End Function

    Private Function GetChildTable() As DataTable
        Dim dt As New DataTable("ChildTable")
        dt = New DataTable("ChildTable")

        Dim cajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Item", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo Doc.", GetType(String)))
        dt.Columns.Add(New DataColumn("Número", GetType(String)))
        dt.Columns.Add(New DataColumn("Monto mn.", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("T/c", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Monto me.", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ref", GetType(Integer)))
        'upper case P
        For Each x As documentoCajaDetalle In cajaSA.ListarDetallePagosXcodigoLibro(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .codigoLibro = "9908"})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = x.DetalleItem
            dr(1) = x.tipoDocumento
            dr(2) = x.numeroDoc
            dr(3) = x.montoSoles
            dr(4) = x.tipoCambioTransacc
            dr(5) = x.montoUsd
            dr(6) = x.documentoAfectado
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Dim parentTable As New DataTable
    Dim childTable As New DataTable

    Public Sub CargarEntidadesXtipo(strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
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

    Private Sub UbicarVentaNroSerie(RucCliente As Integer)
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

        documentoVenta = documentoVentaSA.UbicarVentaPorClienteXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, "1")
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
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN
                dr(11) = i.PagoSumaME
                dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                dt.Rows.Add(dr)
            Next
            dgvCobranzaCli.DataSource = dt
            Me.dgvCobranzaCli.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Private Sub UbicarVentaNroSerieExcedente(RucCliente As Integer)
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
        dt.Columns.Add("estadoPago", GetType(String))

        '    documentoVenta = documentoVentaSA.UbicarExcedenteVentaPorClienteXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo)
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
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN
                dr(11) = i.PagoSumaME
                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(12) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(12) = "Pendiente"
                End Select

                dt.Rows.Add(dr)
            Next
            dgvExcedente.DataSource = dt
            Me.dgvExcedente.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub
#End Region

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

    Private Sub frmCobrosGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then

                If TabPageCobranzaCli Is TabControlAdv1.SelectedTab Then
                    Me.txtCliente.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    txtCliente.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text

                ElseIf TabPageDevolucion Is TabControlAdv1.SelectedTab Then
                    Me.txtcliDev.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    txtcliDev.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    txtRucDev.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text


                    'ElseIf TabPageCronograma Is TabControlAdv1.SelectedTab Then
                    '    TxtCronoProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    '    TxtCronoProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    '    txtRuccrono.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text

                End If


                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then

            If TabPageCobranzaCli Is TabControlAdv1.SelectedTab Then
                Me.txtCliente.Focus()
            ElseIf TabPageDevolucion Is TabControlAdv1.SelectedTab Then
                Me.txtcliDev.Focus()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub


    Private Sub frmCobrosGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        treeViewAdv2.BackColor = Color.MediumSeaGreen
        TabPageCobranzaCli.Parent = TabControlAdv1
        TabPageDevolucion.Parent = Nothing
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtCliente
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(txtCliente.Text.Trim)
        End If
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCliente.Text.Trim.Length > 0 Then
            UbicarVentaNroSerie(txtCliente.Tag)
        Else
            lblEstado.Text = "Seleccione un cliente antes de realizar la tarea!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then
            btnNuevoPago(dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda"), dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))
        End If
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then
            If txtCliente.Tag.Trim.Length > 0 Then
                With frmHistorial
                    .IdDocumentoCompra = dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento")
                    .LoadHistorialCajasXcompra()
                    ' .HistorialCompra(IDDocumentoCompra)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "cliente"
                TabPageCobranzaCli.Parent = TabControlAdv1
                TabPageDevolucion.Parent = Nothing
            Case "reclamaciones"
                TabPageCobranzaCli.Parent = Nothing
                TabPageDevolucion.Parent = TabControlAdv1
        End Select
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub dgvCobranzaCli_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCobranzaCli.QueryCellStyleInfo
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

    Private Sub dgvCobranzaCli_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCobranzaCli.TableControlCellClick

    End Sub
End Class