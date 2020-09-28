Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmPagos
    Inherits frmMaster
    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property lblTipoCambioOriginal() As Decimal
    Public Property TipoPagoReclamacion() As String
    Public Property ListaPagosDolares As New List(Of movimientocajaextranjera)
    Public Property empresaPeriodoSA As New empresaCierreMensualSA

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        SetRenderer()
        ObtenerTablaGenerales()
        DockingInicio()
        GridCFG(dgvDistribucionME)
        ListaPagosDolares = New List(Of movimientocajaextranjera)
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral
        txtAnioCompra.Text = AnioGeneral
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean
        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            PanelError.Visible = False
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

#Region "VALIDA USUARIO CAJA"
    'Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
    '    Dim efSA As New EstadosFinancierosSA
    '    Dim ef As New estadosFinancieros
    '    Dim estableSA As New establecimientoSA

    '    GFichaUsuarios = New GFichaUsuarioa
    '    Select Case ManipulacionEstado
    '        Case ENTITY_ACTIONS.INSERT

    '            If IsNothing(GFichaUsuarios.NombrePersona) Then
    '                With frmFichaUsuarioCaja
    '                    ModuloAppx = ModuloSistema.CAJA
    '                    .lblNivel.Text = "Caja"
    '                    .lblEstadoCaja.Visible = True
    '                    .GroupBox1.Visible = True
    '                    .GroupBox2.Visible = True
    '                    .GroupBox4.Visible = True
    '                    .cboMoneda.Visible = True
    '                    .Timer1.Enabled = True
    '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                    If IsNothing(GFichaUsuarios.NombrePersona) Then
    '                        Return False
    '                    Else
    '                        Return True
    '                    End If
    '                End With

    '            End If
    '        Case ENTITY_ACTIONS.UPDATE
    '            With frmFichaUsuarioCaja
    '                ModuloAppx = ModuloSistema.CAJA
    '                .lblNivel.Text = "Caja"
    '                .lblEstadoCaja.Visible = True
    '                .GroupBox1.Visible = True
    '                .GroupBox2.Visible = True
    '                .GroupBox4.Visible = True
    '                .cboMoneda.Visible = True
    '                .Timer1.Enabled = False
    '                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
    '                .StartPosition = FormStartPosition.CenterParent
    '                .UbicarUsuarioCaja(intIdDocumento, "CUENTAS_POR_PAGAR")
    '                .ShowDialog()
    '                If IsNothing(GFichaUsuarios.NombrePersona) Then
    '                    Return False
    '                Else
    '                    Return True
    '                End If
    '            End With

    '    End Select
    '    Return True

    'End Function
#End Region

#Region "Métodos"

    Sub ConfiguracionInicio()

        'configurando docking manager
        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.DockControlInAutoHideMode(gpVSBehavior, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 350)
        dockingManager1.SetDockLabel(gpVSBehavior, "DATOS DE COMPROBANTE")
        dockingManager1.CloseEnabled = False
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
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub DockingInicio()
        'dockingManager1.DockControlInAutoHideMode(PopupControlContainer3, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 300)
        ''Me.DockingClientPanel1.AutoScroll = True
        ''Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        'dockingManager1.SetDockLabel(PopupControlContainer3, "Diferencia General")

        dockingManager1.DockControlInAutoHideMode(Panel1, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 500)
        dockingManager1.SetDockLabel(Panel1, "Detalle de Pago")
    End Sub

    Private Sub cargarCtasFinan()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo("TC")
            Dim lista As New List(Of String)
            lista.Add("001")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        End If
    End Sub

    Public Sub cargarDatosCompra(datosPago As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros

        If (manipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
        ElseIf (manipulacionEstado = ENTITY_ACTIONS.INSERT) Then
          
            If (Not IsNothing(estadoBL)) Then
                Select Case datosPago
                    Case 1 'dolares
                        pnColorMN.BackColor = Color.Transparent
                        pnColorME.BackColor = Color.Yellow
                        pnSaldoME.Location = New Point(22, 45)
                        pnSaldoMN.Location = New Point(22, 75)
                        pnSaldoME.Visible = True
                        pnSaldoMN.Visible = True
                    Case 0 'soles
                        pnColorMN.BackColor = Color.Yellow
                        pnColorME.BackColor = Color.Transparent
                        pnSaldoME.Location = New Point(22, 75)
                        pnSaldoMN.Location = New Point(22, 45)
                        pnSaldoME.Visible = True
                        pnSaldoMN.Visible = True
                End Select
            End If
        End If
    End Sub

    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros


        If (manipulacionEstado = ENTITY_ACTIONS.UPDATE) Then

        Else
            estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
            estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(cboDepositoHijo.SelectedValue, New Date(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1))
            If (Not IsNothing(estadoBL)) Then
                cboMoneda.SelectedValue = estadoBL.codigo
                txtCuentaOrigen.Text = estadoBL.cuenta
                SaldoEFME.DoubleValue = estadoSaldoBL.importeBalanceME
                SaldoEFMN.DoubleValue = estadoSaldoBL.importeBalanceMN
                ButtonAdv5.Visible = True
                txtTipoCambio.DoubleValue = TmpTipoCambioTransaccionVenta
                cboTipoDoc.SelectedValue = "001"
                Select Case cboMoneda.SelectedValue
                    Case 1
                        'pnImpMEDisp.Location = New Point(170, 21)
                        'pnImpMNDisp.Location = New Point(9, 21)
                        txtPagoME.Enabled = True
                        txtPagoMN.Enabled = False
                        PictureBox5.Visible = False
                        pnDiferencia.Visible = False
                        txtPagoMN.Value = 0.0
                        txtPagoME.Value = 0.0
                        txtDiferenciaMontos.Value = 0

                        Select Case tb19.ToggleState
                            Case ToggleButton2.ToggleButtonState.OFF 'dolares
                                'pnSaldoME.Visible = True
                                'pnSaldoMN.Visible = True
                                'pnNacional.Location = New Point(420, 25)
                                'pnExtranjero.Location = New Point(49, 25)
                                'pnTipoCambio.Visible = True
                                'pnExtranjero.Visible = True
                                'pnDiferencia.Visible = True
                                'pnDiferencia.Location = New Point(650, 25)
                                'pnTipoCambio.Enabled = False
                                ''    pnImpMEDisp.Visible = False
                                'pnTipoCambioCompra.Visible = True
                                'pnTipoCambio.Visible = True
                                'pnDiferencia.Visible = True
                                'pnExtranjero.Visible = True
                                colMN.Visible = False
                                colSaldoMN.Visible = False
                                colPagoMN.Visible = False
                                '  pnImpMNDisp.Visible = True
                                colME.Visible = True
                                colSaldoME.Visible = True
                                colPagoME.Visible = True
                                PanelDetallePagos.Enabled = True
                            Case ToggleButton2.ToggleButtonState.ON 'soles
                                'pnSaldoME.Visible = False
                                'pnNacional.Location = New Point(49, 25)
                                'pnExtranjero.Location = New Point(420, 25)
                                txtPagoMN.Enabled = True
                                'pnTipoCambio.Visible = True
                                'pnExtranjero.Visible = True
                                'pnDiferencia.Visible = False
                                'pnTipoCambio.Enabled = False
                                txtTipoCambio.DoubleValue = lblTipoCambio.Text
                                ''     pnImpMEDisp.Visible = False
                                'pnTipoCambioCompra.Visible = False
                                'pnTipoCambio.Visible = False
                                'pnDiferencia.Visible = False
                                'pnExtranjero.Visible = False
                                colME.Visible = False
                                colSaldoME.Visible = False
                                colPagoME.Visible = False
                                PanelDetallePagos.Enabled = True
                        End Select

                    Case 2
                        'pnImpMEDisp.Location = New Point(9, 21)
                        'pnImpMNDisp.Location = New Point(170, 21)
                        PictureBox5.Visible = True
                        pnDiferencia.Visible = True
                        txtPagoMN.Value = 0.0
                        txtPagoME.Value = 0.0
                        txtDiferenciaMontos.Value = 0
                        Select Case tb19.ToggleState
                            Case ToggleButton2.ToggleButtonState.OFF 'dolares
                                pnSaldoMN.Visible = False
                                pnTipoCambio.Visible = True
                                pnExtranjero.Visible = True
                                pnDiferencia.Visible = True
                                pnExtranjero.Enabled = True
                                pnNacional.Enabled = False
                                'pnExtranjero.Location = New Point(49, 25)
                                'pnNacional.Location = New Point(430, 25)
                                'pnDiferencia.Location = New Point(650, 25)
                                txtTipoCambio.DoubleValue = lblTipoCambio.Text
                                pnTipoCambio.Enabled = False
                                '       pnImpMNDisp.Visible = False
                                pnTipoCambioCompra.Visible = True
                                pnTipoCambio.Visible = True
                                pnDiferencia.Visible = True
                                pnExtranjero.Visible = True
                                PanelDetallePagos.Enabled = True
                                colMN.Visible = False
                                colSaldoMN.Visible = False
                                colPagoMN.Visible = False
                                colME.Visible = True
                                colSaldoME.Visible = True
                                colPagoME.Visible = True
                            Case ToggleButton2.ToggleButtonState.ON 'soles
                                pnSaldoME.Visible = True
                                pnTipoCambio.Visible = True
                                pnExtranjero.Visible = True
                                pnDiferencia.Visible = True
                                'pnNacional.Location = New Point(49, 25)
                                'pnExtranjero.Location = New Point(430, 25)
                                'pnDiferencia.Location = New Point(650, 25)
                                pnTipoCambio.Enabled = False
                                pnNacional.Enabled = True
                                pnExtranjero.Enabled = False
                                '      pnImpMEDisp.Visible = True
                                pnTipoCambioCompra.Visible = True
                                pnDiferencia.Visible = True
                                pnExtranjero.Visible = True
                                colMN.Visible = True
                                colSaldoMN.Visible = True
                                colPagoMN.Visible = True
                                colME.Visible = False
                                colSaldoME.Visible = False
                                colPagoME.Visible = False
                                txtPagoMN.Enabled = True
                                PanelDetallePagos.Enabled = True
                        End Select
                End Select
            End If
        End If
    End Sub

    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try
            Me.cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = strBusqueda,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Me.cboDepositoHijo.DisplayMember = "descripcion"
            Me.cboDepositoHijo.ValueMember = "idestado"
            cboDepositoHijo.SelectedValue = -1

            cboMoneda.ValueMember = "codigoDetalle"
            cboMoneda.DisplayMember = "descripcion"
            cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            cboMoneda.SelectedValue = -1

        Catch ex As Exception

        End Try
    End Sub


    Public Sub ListaDocPago(listaCuenta As List(Of String))
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)

        tabla = tablaSA.GetListaTablaDetalle(1, "1")
        tabla = (From n In tabla _
                     Where listaCuenta.Contains(n.codigoDetalle) _
                    Select n).ToList
        cboTipoDoc.DataSource = tabla
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.SelectedValue = "001"

    End Sub

    Public Sub UbicarDocumento(intIdDocumento As Integer, importeMN As Decimal, importeUS As Decimal)
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim alEFSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim establecimientoSA As New establecimientoSA
        Dim itemSA As New detalleitemsSA
        Dim entidadSA As New entidadSA

        Try
            PanelDetallePagos.Enabled = False
            DockingClientPanel1.Enabled = False
            With documentoCajaSA.ObtenerCajaDetallePorId(intIdDocumento)
                Dim fechaPeriodo = GetPeriodoConvertirToDate(.periodo)
                txtPeriodo.Value = fechaPeriodo
                lblIdDocumento.Text = .idDocumento
                cboMesCompra.SelectedValue = String.Format("{0:00}", .fechaProceso.Value.Month)
                txtDia.Value = New Date(.fechaProceso.Value.Year, .fechaProceso.Value.Month, .fechaProceso.Value.Day)
                txtAnioCompra.Text = .fechaProceso.Value.Year
                Dim codigoDoc = .tipoDocPago

                cboMoneda.SelectedValue = .moneda

                Select Case .tipoOperacion
                    Case StatusTipoOperacion.VENTA, StatusTipoOperacion.COBRO_A_CLIENTES
                        Dim venta = VentaSA.GetUbicar_documentoventaAbarrotesPorID(.IdProveedor)
                        If venta IsNot Nothing Then
                            txtNumeroCompr.Text = venta.numeroVenta
                            txtSerieCompr.Text = venta.serieVenta
                            txtFechaComprobante.Text = venta.fechaDoc
                            lblTipoCambio.Text = venta.tipoCambio
                            'lblDeudaPendiente.Text = importeMN
                            'lblDeudaPendienteme.Text = importeUS

                            Select Case venta.moneda
                                Case 1
                                    tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                                Case 2
                                    tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End Select
                        End If

                    Case StatusTipoOperacion.COMPRA, StatusTipoOperacion.PAGO_A_PROVEEDORES
                        With documentoVentaSA.UbicarDocumentoCompra(.IdProveedor)
                            txtNumeroCompr.Text = .numeroDoc
                            txtSerieCompr.Text = .serie
                            txtFechaComprobante.Text = .fechaDoc
                            lblTipoCambio.Text = .tcDolLoc
                            'lblDeudaPendiente.Text = importeMN
                            'lblDeudaPendienteme.Text = importeUS

                            Select Case .monedaDoc
                                Case 1
                                    tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                                Case 2
                                    tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                            End Select

                        End With
                End Select

                With entidadSA.UbicarEntidadPorID(.codigoProveedor).First
                    txtProveedor.Text = .nombreCompleto
                    txtProveedor.Tag = .idEntidad
                    lblCuentaProveedor = .cuentaAsiento

                    txtEntidad.Text = .nombreCompleto
                    txtEntidad.Tag = .idEntidad
                    txtNroDocEntidad.Text = .nrodoc
                    txtTipoEntidad.Text = .tipoEntidad
                End With

                Select Case .moneda
                    Case 1
                        cboMoneda.Text = "NACIONAL"
                    Case 2
                        cboMoneda.Text = "EXTRANJERO"
                End Select

                With alEFSA.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)

                    Select Case .tipo
                        Case CuentaFinanciera.Banco
                            cboTipo.Text = "CUENTAS EN BANCO"
                        Case CuentaFinanciera.Efectivo
                            cboTipo.Text = "CUENTAS EN EFECTIVO"

                        Case CuentaFinanciera.Tarjeta_Credito
                            cboTipo.Text = "TARJETA DE CREDITO"
                    End Select

                    cboDepositoHijo.SelectedValue = .idestado
                    cargarDatosCuenta(cboDepositoHijo.SelectedValue)

                    txtCuentaOrigen.Text = .cuenta

                End With
                cboTipoDoc.SelectedValue = codigoDoc
                Select Case codigoDoc
                    Case "001"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito

                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidades.SelectedValue = .bancoEntidad
                        End If

                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro

                    Case "007" 'cheques

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidades.SelectedValue = .bancoEntidad
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                    Case "111"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidades.SelectedValue = .bancoEntidad
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro

                    Case "109"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidades.SelectedValue = .bancoEntidad
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                End Select

                txtTipoCambio.DoubleValue = .tipoCambio
                txtPagoMN.Value = .montoSoles
                txtPagoME.Value = importeUS
            End With

            dgvDetalleItems.Rows.Clear()
            For Each i In documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento)
                dgvDetalleItems.Rows.Add(i.secuencia, i.DetalleItem, itemSA.InvocarProductoID(i.idItem).unidad1, "0.00", i.montoSoles, i.montoUsd, "0.00", "0.00", "0.00", "0.00",
                                         Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE)
            Next
            CalculoGRID()

            ButtonAdv5.Visible = False

        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub

    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
    End Sub

    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        cboEntidades.ValueMember = "codigoDetalle"
        cboEntidades.DisplayMember = "descripcion"
        cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
    End Sub

    Sub CalculoGRID()
        Dim valDolares As Decimal = 0
        Dim nudvalueImporte As Decimal = txtPagoMN.Value
        Dim nudSaldo As Decimal = nudvalueImporte
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0
        Dim montoMN As Decimal = 0
        If (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
            If (CDec(txtPagoMN.Value <= txtSaldoPorPagar.DecimalValue)) Then
                If (txtPagoMN.Value > 0) Then

                    montoMN = Math.Round(CDec(txtPagoMN.Value), 2)

                    valDolares = montoMN / txtTipoCambio.DoubleValue
                    txtPagoME.Value = CDec(valDolares)

                    For Each i As DataGridViewRow In dgvDetalleItems.Rows
                        cSaldo = CDec(i.Cells(4).Value) - nudSaldo
                        cSaldoex = CDec(i.Cells(5).Value) - valDolares
                        'If CDec(i.Cells(4).Value) = "" Then
                        If cSaldo >= 0 Then
                            i.Cells(6).Value = CDec(nudSaldo)
                            i.Cells(8).Value = CDec(cSaldo)
                            '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                            '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                            nudSaldo = 0
                        Else
                            i.Cells(6).Value = CDec(i.Cells(4).Value)
                            i.Cells(8).Value = "0.00"
                            '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                            '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                            nudSaldo = cSaldo * -1
                        End If

                        If cSaldoex >= 0 Then
                            i.Cells(7).Value = CDec(valDolares)
                            i.Cells(9).Value = CDec(cSaldoex)
                            '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                            '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                            valDolares = 0
                        Else
                            i.Cells(7).Value = CDec(i.Cells(5).Value)
                            i.Cells(9).Value = "0.00"
                            '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                            '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                            valDolares = cSaldoex * -1
                        End If

                    Next
                End If

            Else
                txtPagoME.Value = 0
                txtPagoMN.Value = 0
                txtDiferenciaMontos.Value = 0
                lblEstado.Text = "Ingreso del importe no debe exceder S/." & txtSaldoPorPagar.DecimalValue
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtPagoMN.Select()
                txtPagoMN.Select(0, txtPagoMN.Text.Length)

            End If

            ' COMPRA MONEDA EXTRAJERA  Y PAGO MONEDA EXTRANJERA
        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
            valDolares = txtPagoME.Value
            'txtImporteComprame.Value = valDolares

            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                cSaldo = CDec(i.Cells(4).Value) - nudSaldo
                cSaldoex = CDec(i.Cells(5).Value) - valDolares
                'If CDec(i.Cells(4).Value) = "" Then
                If cSaldo >= 0 Then
                    i.Cells(6).Value = nudSaldo
                    i.Cells(8).Value = cSaldo
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    nudSaldo = 0
                Else
                    i.Cells(6).Value = i.Cells(4).Value
                    i.Cells(8).Value = "0.00"
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    nudSaldo = cSaldo * -1
                End If

                If cSaldoex >= 0 Then
                    i.Cells(7).Value = valDolares
                    i.Cells(9).Value = cSaldoex
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    valDolares = 0
                Else
                    i.Cells(7).Value = i.Cells(5).Value
                    i.Cells(9).Value = "0.00"
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    valDolares = cSaldoex * -1
                End If

            Next
            CargarDiferenciasdeImporte()
            CargarMovimientosDetallado(lblIdDocumento.Text)

            ' compra moneda nacional pago en moneda extrajera

        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
            If (txtTipoCambio.DoubleValue > 0) Then
                Dim precioME As Decimal = 0
                Dim precio As Decimal = 0
                Dim parteDecimal As Decimal = 0
                Dim sumatoriaPagoME As Decimal = 0
                If ((txtPagoMN.Value) <= txtSaldoPorPagar.DecimalValue) Then

                    montoMN = Math.Round(CDec(txtPagoMN.Value), 2)

                    valDolares = montoMN / txtTipoCambio.DoubleValue
                    txtPagoME.Value = valDolares
                    txtPagoMN.Value = montoMN
                    If (valDolares <= SaldoEFME.DoubleValue) Then



                        If (txtPagoMN.Value > 0) Then


                            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                                cSaldo = CDec(i.Cells(4).Value) - nudSaldo
                                cSaldoex = CDec(i.Cells(5).Value) - valDolares
                                'If CDec(i.Cells(4).Value) = "" Then
                                If cSaldo >= 0 Then
                                    i.Cells(6).Value = CDec(nudSaldo)
                                    i.Cells(8).Value = CDec(cSaldo)
                                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                                    '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                                    nudSaldo = 0
                                Else
                                    i.Cells(6).Value = CDec(i.Cells(4).Value)
                                    i.Cells(8).Value = "0.00"
                                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                                    '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                                    nudSaldo = cSaldo * -1
                                End If

                                If cSaldoex >= 0 Then
                                    i.Cells(7).Value = CDec(i.Cells(6).Value / txtTipoCambio.DoubleValue).ToString("N2")
                                    i.Cells(9).Value = CDec(i.Cells(5).Value - i.Cells(7).Value)
                                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                                    '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                                    valDolares = 0
                                Else
                                    i.Cells(7).Value = CDec(i.Cells(6).Value / txtTipoCambio.DoubleValue).ToString("N2")
                                    i.Cells(9).Value = "0.00"
                                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                                    '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                                    valDolares = cSaldoex * -1
                                End If

                            Next

                            CargarDiferenciasdeImporte()
                            CargarMovimientosDetallado(lblIdDocumento.Text)
                        End If
                    Else
                        txtPagoME.Value = 0
                        txtPagoMN.Value = 0
                        txtDiferenciaMontos.Value = 0
                        lblEstado.Text = "Ingreso del importe ME no debe exceder S/." & SaldoEFME.DoubleValue
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtPagoMN.Select()
                        txtPagoMN.Select(0, txtPagoMN.Text.Length)
                    End If
                Else
                    txtPagoME.Value = 0
                    txtTipoCambio.DoubleValue = 0
                    txtPagoMN.Value = 0
                    txtDiferenciaMontos.Value = 0
                    lblEstado.Text = "Ingreso del importe no debe exceder S/." & txtSaldoPorPagar.DecimalValue
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtPagoME.Select()
                    txtPagoME.Select(0, txtPagoME.Text.Length)
                End If
            Else
                txtTipoCambio.Select()
                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
            End If

        Else
            ' compra moneda extranjera  pago en moneda nacional
            If (txtTipoCambio.DoubleValue > 0) Then


                If (manipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
                    valDolares = txtPagoMN.Value / txtTipoCambio.DoubleValue
                Else
                    valDolares = txtPagoMN.Value / txtTipoCambio.DoubleValue
                    txtPagoME.Value = valDolares
                End If



                If CDec(txtPagoME.Value <= lblDeudaPendienteme.Text) Then
                    For Each i As DataGridViewRow In dgvDetalleItems.Rows
                        cSaldo = CDec(i.Cells(4).Value) - nudSaldo
                        cSaldoex = CDec(i.Cells(5).Value) - valDolares
                        'If CDec(i.Cells(4).Value) = "" Then


                        If cSaldoex >= 0 Then
                            i.Cells(7).Value = valDolares 'valDolares
                            i.Cells(9).Value = cSaldoex
                            '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                            '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                            valDolares = 0
                        Else
                            i.Cells(7).Value = CDec(i.Cells(5).Value) ' i.Cells(5).Value
                            i.Cells(9).Value = "0.00"
                            '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                            '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                            valDolares = cSaldoex * -1
                        End If


                        If cSaldo >= 0 Then
                            i.Cells(6).Value = CDec(i.Cells(7).Value * txtTipoCambio.DoubleValue)  'nudSaldo
                            i.Cells(8).Value = CDec(i.Cells(4).Value - i.Cells(6).Value)
                            '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                            '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                            nudSaldo = 0
                        Else
                            i.Cells(6).Value = CDec(i.Cells(5).Value * txtTipoCambio.DoubleValue)
                            i.Cells(8).Value = CDec(i.Cells(4).Value - i.Cells(6).Value)
                            '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                            '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                            nudSaldo = cSaldo * -1
                        End If


                    Next

                    CargarDiferenciasdeImporte()
                    CargarMovimientosDetallado(lblIdDocumento.Text)
                Else
                    txtPagoME.Value = 0
                    txtTipoCambio.DoubleValue = 0
                    txtPagoMN.Value = 0
                    txtDiferenciaMontos.Value = 0
                    lblEstado.Text = "Ingreso del importe no debe exceder $." & lblDeudaPendienteme.Text
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtPagoMN.Select()
                    txtPagoMN.Select(0, txtPagoMN.Text.Length)

                    Exit Sub
                End If
            Else
                lblEstado.Text = "Ingrese un tipo cambio"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtTipoCambio.Focus()
                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                Exit Sub
            End If

        End If

    End Sub

    Sub CalculoGRIDExtrajero()
        Dim valSoles As Decimal = 0
        Dim nudvalueImporte As Decimal = txtPagoME.Value
        Dim nudSaldo As Decimal = nudvalueImporte
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0
        Dim cMonedaNac As Decimal = 0
        Dim cMonedaExt As Decimal = 0

        If (txtTipoCambio.DoubleValue > 0) Then
            valSoles = CDec(txtPagoMN.Value)

            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                cSaldo = CDec(i.Cells(5).Value) - nudSaldo
                cSaldoex = CDec(i.Cells(4).Value) - valSoles
                'If CDec(i.Cells(4).Value) = "" Then
                If cSaldo >= 0 Then
                    i.Cells(7).Value = nudSaldo
                    i.Cells(9).Value = cSaldo
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    nudSaldo = 0
                Else
                    i.Cells(7).Value = (CDec(i.Cells(5).Value))
                    i.Cells(9).Value = "0.00"
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    nudSaldo = cSaldo * -1
                End If


                If cSaldoex >= 0 Then
                    i.Cells(6).Value = valSoles
                    i.Cells(8).Value = cSaldoex
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    valSoles = 0
                Else
                    i.Cells(6).Value = i.Cells(4).Value
                    i.Cells(8).Value = "0.00"
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    valSoles = cSaldoex * -1
                End If
                cMonedaNac += CDec(i.Cells(6).Value)
                cMonedaExt += CDec(i.Cells(7).Value)
            Next

        Else
            lblEstado.Text = "Ingrese un tipo cambio"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtTipoCambio.Focus()
            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
            Exit Sub
        End If

    End Sub

    Sub CalculoSoles()
        If cboMoneda.SelectedValue = 1 Then

            If CDec(txtPagoME.Value) > CDec(lblDeudaPendienteme.Text) Then
                MsgBox("El valor ingreso excede el valor permitido.", MsgBoxStyle.Information, String.Concat("Monto permitido ($.):", Space(2), lblDeudaPendienteme.Text))
                txtTipoCambio.DoubleValue = 0
                txtPagoMN.Value = 0
                txtPagoME.Value = 0
                Exit Sub

            End If
        End If
    End Sub

    Sub CalculoDolares()
        If cboMoneda.SelectedValue = 2 Then
            If txtTipoCambio.DoubleValue > 0 Then
                If CDec(txtPagoMN.Value) > CDec(txtSaldoPorPagar.DecimalValue) Then
                    MsgBox("El valor ingreso excede el valor permitido.", MsgBoxStyle.Information, String.Concat("Monto permitido (S/.):", Space(2), txtSaldoPorPagar.DecimalValue))
                    txtPagoMN.Value = 0
                    txtPagoME.Value = 0
                    Exit Sub
                End If
            End If
        End If
    End Sub

#End Region

#Region "Manipulación data"

    Public Function AS_DebeCajaDiferencia(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal, asientoDestino As String) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = asientoDestino,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_HaberCajaDiferencia(cMonto As Decimal, cMontoUS As Decimal, asientoDestino As String, cuenta As String, descripcion As String) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = cuenta,
      .descripcion = descripcion,
      .tipo = asientoDestino,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento

    End Function

    Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = cboDepositoHijo.SelectedValue}
        Return nMovimiento
    End Function

    Public Function AS_HaberCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberClienteReclamacion(cuentas As String, cdescrupcon As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = cuentas,
      .descripcion = cdescrupcon,
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento


    End Function



    Public Function AS_DebeCajaReclamacion(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function


    Public Function AS_HaberCliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = lblCuentaProveedor,
      .descripcion = lblNomProveedor,
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberClienteTratamiento(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = lblCuentaProveedor,
      .descripcion = lblNomProveedor,
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento

    End Function


    Function asientoCajaReclamacion(monedaExtrajera As Decimal, MontoMonedaExt As Decimal, MontoSoles As Decimal) As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.periodo = String.format("{0:00}", txtPeriodo.value.month) & "/" & txtPeriodo.value.year
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        'correccin asientos
        nAsiento.importeMN = txtPagoME.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtPagoME.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = GlosaReclamacion()
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then

                Select Case cboMoneda.SelectedValue
                    Case 1
                        If (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then

                            If TipoPagoReclamacion = "VENTA" Then
                                nAsiento.movimiento.Add(AS_HaberClienteReclamacion(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                                nAsiento.movimiento.Add(AS_DebeCajaReclamacion("461", lblNomProveedor, dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))

                            Else

                                nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                                nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                            End If


                        ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                            If TipoPagoReclamacion = "VENTA" Then
                                nAsiento.movimiento.Add(AS_HaberClienteReclamacion(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                                nAsiento.movimiento.Add(AS_DebeCajaReclamacion("461", lblNomProveedor, dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))

                            Else
                                nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                                nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                            End If
                        End If
                    Case 2
                        If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then

                            If TipoPagoReclamacion = "VENTA" Then
                                nAsiento.movimiento.Add(AS_HaberClienteReclamacion(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                                nAsiento.movimiento.Add(AS_DebeCajaReclamacion("461", lblNomProveedor, dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))

                            Else
                                nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                                nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                            End If
                        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                            If TipoPagoReclamacion = "VENTA" Then
                                nAsiento.movimiento.Add(AS_HaberClienteReclamacion(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                                nAsiento.movimiento.Add(AS_DebeCajaReclamacion("461", lblNomProveedor, dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))

                            Else
                                nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                                nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                            End If
                        End If


                End Select
            End If
        Next


        For Each r As Record In dgvDiferencia.Table.Records
            Select Case cboMoneda.SelectedValue
                Case 1 '    nacional
                    Select Case tb19.ToggleState
                        Case ToggleButton2.ToggleButtonState.OFF 'dolares

                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                sumaAsientocajaMN = r.GetValue("difMNCajaMN")
                                'cuentas Maykol de tratamiento de caja
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, "4212", lblNomProveedor))
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1)
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, "4212", lblNomProveedor))
                            End If

                        Case ToggleButton2.ToggleButtonState.ON 'soles
                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                sumaAsientocajaMN = CDec(r.GetValue("difMNCajaMN"))
                                'cuentas Maykol de tratamiento de caja
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1)
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                            End If
                    End Select

                Case 2 ' extranjero
                    Select Case tb19.ToggleState
                        Case ToggleButton2.ToggleButtonState.OFF 'dolares
                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN"))).ToString("N2")
                                'cuentas Maykol de tratamiento de caja
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1).ToString("N2")
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                            End If
                        Case ToggleButton2.ToggleButtonState.ON 'soles
                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN"))).ToString("N2")
                                'cuentas Maykol de tratamiento de caja
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1).ToString("N2")
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                            End If
                    End Select
            End Select

        Next

        Return nAsiento
    End Function



    Function asientoCaja(monedaExtrajera As Decimal, MontoMonedaExt As Decimal, MontoSoles As Decimal) As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = String.format("{0:00}", txtPeriodo.value.month) & "/" & txtPeriodo.value.year
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        'correccin asientos
        nAsiento.importeMN = txtPagoME.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtPagoME.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then

                Select Case cboMoneda.SelectedValue
                    Case 1
                        If (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then



                            nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))



                        ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then

                            nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))

                        End If
                    Case 2
                        If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then


                            nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))

                        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then

                            nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))

                        End If


                End Select
            End If
        Next


        For Each r As Record In dgvDiferencia.Table.Records
            Select Case cboMoneda.SelectedValue
                Case 1 '    nacional
                    Select Case tb19.ToggleState
                        Case ToggleButton2.ToggleButtonState.OFF 'dolares

                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                sumaAsientocajaMN = r.GetValue("difMNCajaMN")
                                'cuentas Maykol de tratamiento de caja
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, "4212", lblNomProveedor))
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1)
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, "4212", lblNomProveedor))
                            End If

                        Case ToggleButton2.ToggleButtonState.ON 'soles
                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                sumaAsientocajaMN = CDec(r.GetValue("difMNCajaMN"))
                                'cuentas Maykol de tratamiento de caja
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1)
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                            End If
                    End Select

                Case 2 ' extranjero
                    Select Case tb19.ToggleState
                        Case ToggleButton2.ToggleButtonState.OFF 'dolares
                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN"))).ToString("N2")
                                'cuentas Maykol de tratamiento de caja
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1).ToString("N2")
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                            End If
                        Case ToggleButton2.ToggleButtonState.ON 'soles
                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN"))).ToString("N2")
                                'cuentas Maykol de tratamiento de caja
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1).ToString("N2")
                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, txtCuentaOrigen.Text, cboDepositoHijo.Text))
                            End If
                    End Select
            End Select

        Next

        Return nAsiento
    End Function

    Public Sub GrabarReclamacion()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim ListadocumentoCajaDetalle2 As New List(Of documentoCajaDetalle)
        Dim ndocumentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim SaldoMonedaExt As Decimal = 0
        Dim MontoMonedaExt As Decimal = 0
        Dim MontoSoles As Decimal = 0
        Dim entidadSA As New entidadSA
        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Try
            With ndocumento
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                .tipoDoc = "9901"
                .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .nroDoc = txtNumeroCompr.Text.Trim
                .idOrden = Nothing
                .tipoOperacion = "9920"
                .moneda = cboMoneda.SelectedValue
                .idEntidad = Val(txtEntidad.Tag)
                .entidad = txtEntidad.Text
                .tipoEntidad = txtTipoEntidad.Text
                .nrodocEntidad = txtNroDocEntidad.Text
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            End With

            With ndocumentoCaja
                .codigoLibro = "1"
                .tipoOperacion = "9920"
                .periodo = String.format("{0:00}", txtPeriodo.value.month) & "/" & txtPeriodo.value.year
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                .tipoDocPago = "9901"
                .formapago = cboTipoDoc.SelectedValue
                If cboTipoDoc.SelectedValue = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "SI"
                    '.ctaIntebancaria = txtCtaInterbancaria.Text
                ElseIf cboTipoDoc.SelectedValue = "007" Then ' cheques
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = txtFechaCobro.Value
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "111" Then
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = txtFechaCobro.Value
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "109" Then
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaProceso = txtFechaCobro.Value
                    .entregado = "NO"
                End If
                .moneda = cboMoneda.SelectedValue
                .entidadFinanciera = cboDepositoHijo.SelectedValue
                .tipoCambio = CDec(txtTipoCambio.DoubleValue).ToString("N3")
                .montoSoles = txtPagoMN.Value
                .montoUsd = txtPagoME.Value
                .glosa = Glosa()
                .usuarioModificacion = cboDepositoHijo.SelectedValue
                .fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .DeudaEvalMN = CDec(txtSaldoPorPagar.DecimalValue)
                .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
                .codigoProveedor = CInt(txtProveedor.Tag)
            End With

            ndocumento.documentoCaja = ndocumentoCaja
            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                    ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

                    Select Case cboMoneda.SelectedValue
                        Case 1
                            ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())

                        Case 2

                            ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())

                            'Select Case tb19.ToggleState
                            '    Case ToggleButton2.ToggleButtonState.OFF 'dolares
                            '        ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.DoubleValue).ToString("N2")
                            '        ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            '        ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                            '    Case ToggleButton2.ToggleButtonState.ON 'soles
                            '        ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            '        ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            '        ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                            'End Select
                    End Select



                    ndocumentoCajaDetalle.entregado = "SI"
                    ndocumentoCajaDetalle.tipoCambioTransacc = CDec(txtTipoCambio.DoubleValue).ToString("N3")

                    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                    ndocumentoCajaDetalle.usuarioModificacion = CStr(cboDepositoHijo.SelectedValue)
                    ndocumentoCajaDetalle.fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    ndocumentoCajaDetalle.idCajaPadre = cboDepositoHijo.SelectedValue
                    ndocumentoCajaDetalle.documentoAfectadodetalle = dgvDetalleItems.Rows(i.Index).Cells(11).Value()

                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)


                    SaldoMonedaExt += CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                    MontoMonedaExt += CDec(dgvDetalleItems.Rows(i.Index).Cells(5).Value())
                    MontoSoles += CDec(dgvDetalleItems.Rows(i.Index).Cells(8).Value())
                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cboTipoDoc.SelectedValue
                Case "109", "003", "001"
                    asiento = asientoCajaReclamacion(SaldoMonedaExt, MontoMonedaExt, MontoSoles)
                    ListaAsiento.Add(asiento)
                    ndocumento.asiento = ListaAsiento
                Case "007", "111"
                    cajaUsarioBE = Nothing
            End Select

            Select Case cboMoneda.SelectedValue
                Case 2
                    ndocumento.documentoCaja.movimientocajaextranjera = ListaPagosDolares
            End Select


            'ListadocumentoCajaDetalle2 = ndocumentoCajaDetalleSA.ConsultaMovimientoME(cboDepositoHijo.SelectedValue)




            n.IdAlmacen = documentoCajaSA.SaveGroupCajaVentasME(ndocumento, Nothing)




            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
            '    lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub


    Public Sub Grabar()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim ListadocumentoCajaDetalle2 As New List(Of documentoCajaDetalle)
        Dim ndocumentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim SaldoMonedaExt As Decimal = 0
        Dim MontoMonedaExt As Decimal = 0
        Dim MontoSoles As Decimal = 0
        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Try

            With ndocumento
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                .tipoDoc = "9901"
                .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .nroDoc = txtNumeroCompr.Text.Trim
                .idOrden = Nothing
                .moneda = cboMoneda.SelectedValue
                .idEntidad = Val(txtEntidad.Tag)
                .entidad = txtEntidad.Text
                .tipoEntidad = "PR"
                .nrodocEntidad = txtNroDocEntidad.Text
                .tipoOperacion = "9907"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            End With

            With ndocumentoCaja
                .codigoLibro = "1"
                .tipoOperacion = "9907"
                .periodo = String.format("{0:00}", txtPeriodo.value.month) & "/" & txtPeriodo.value.year
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                .tipoDocPago = "9901"
                .formapago = cboTipoDoc.SelectedValue
                If cboTipoDoc.SelectedValue = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "SI"
                    '.ctaIntebancaria = txtCtaInterbancaria.Text
                ElseIf cboTipoDoc.SelectedValue = "007" Then ' cheques
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "111" Then
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "109" Then
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "NO"
                End If
                .moneda = cboMoneda.SelectedValue
                .entidadFinanciera = cboDepositoHijo.SelectedValue
                .tipoCambio = CDec(txtTipoCambio.DoubleValue).ToString("N3")
                .montoSoles = txtPagoMN.Value
                .montoUsd = txtPagoME.Value
                .glosa = Glosa()
                .usuarioModificacion = cboDepositoHijo.SelectedValue
                .fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .DeudaEvalMN = CDec(txtSaldoPorPagar.DecimalValue)
                .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
                .codigoProveedor = CInt(txtProveedor.Tag)
            End With

            ndocumento.documentoCaja = ndocumentoCaja
            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                    ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

                    Select Case cboMoneda.SelectedValue
                        Case 1
                            ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())

                        Case 2

                            ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())

                            'Select Case tb19.ToggleState
                            '    Case ToggleButton2.ToggleButtonState.OFF 'dolares
                            '        ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.DoubleValue).ToString("N2")
                            '        ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            '        ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                            '    Case ToggleButton2.ToggleButtonState.ON 'soles
                            '        ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            '        ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            '        ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                            'End Select
                    End Select



                    ndocumentoCajaDetalle.entregado = "SI"
                    ndocumentoCajaDetalle.tipoCambioTransacc = CDec(txtTipoCambio.DoubleValue).ToString("N3")

                    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                    ndocumentoCajaDetalle.usuarioModificacion = CStr(cboDepositoHijo.SelectedValue)
                    ndocumentoCajaDetalle.fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    ndocumentoCajaDetalle.idCajaPadre = cboDepositoHijo.SelectedValue
                    ndocumentoCajaDetalle.documentoAfectadodetalle = dgvDetalleItems.Rows(i.Index).Cells(11).Value()

                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)


                    SaldoMonedaExt += CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                    MontoMonedaExt += CDec(dgvDetalleItems.Rows(i.Index).Cells(5).Value())
                    MontoSoles += CDec(dgvDetalleItems.Rows(i.Index).Cells(8).Value())
                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cboTipoDoc.SelectedValue
                Case "109", "003", "001"
                    asiento = asientoCaja(SaldoMonedaExt, MontoMonedaExt, MontoSoles)
                    ListaAsiento.Add(asiento)
                    ndocumento.asiento = ListaAsiento
                Case "007", "111"
                    cajaUsarioBE = Nothing
            End Select

            Select Case cboMoneda.SelectedValue
                Case 2
                    ndocumento.documentoCaja.movimientocajaextranjera = ListaPagosDolares
            End Select
            'ListadocumentoCajaDetalle2 = ndocumentoCajaDetalleSA.ConsultaMovimientoME(cboDepositoHijo.SelectedValue)
            n.IdAlmacen = documentoCajaSA.SaveGroupCajaME(ndocumento, cajaUsarioBE, ListadocumentoCajaDetalle2)

            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
            '    lblEstado.Image = My.Resources.ok4
            Close()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    'Public Sub Editar()
    '    Dim documentoSA As New DocumentoSA
    '    Dim documentoCajaSA As New DocumentoCajaSA
    '    Dim ndocumento As New documento
    '    Dim ndocumentoCaja As New documentoCaja
    '    Dim ndocumentoCajaDetalle As New documentoCajaDetalle
    '    Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
    '    Dim asiento As New asiento
    '    Dim ListaAsiento As New List(Of asiento)
    '    Try
    '        With ndocumento
    '            .idDocumento = lbldDocCaja.Text
    '            .idEmpresa = Gempresas.IdEmpresaRuc
    '            .idCentroCosto = GEstableciento.IdEstablecimiento
    '            .idProyecto = GProyectos.IdProyectoActividad
    '            .tipoDoc = txtIdComprobante.Text
    '            .fechaProceso = txtFechaComprobante.Value
    '            .nroDoc = txtNumeroComp.Text
    '            .idOrden = Nothing
    '            .tipoOperacion = "01"
    '            .usuarioActualizacion = "Jiuni"
    '            .fechaActualizacion = DateTime.Now
    '        End With

    '        With ndocumentoCaja
    '            .idDocumento = lbldDocCaja.Text
    '            .idEmpresa = Gempresas.IdEmpresaRuc
    '            .idEstablecimiento = GEstableciento.IdEstablecimiento
    '            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
    '            .codigoProveedor = lblIdProveedor.Text
    '            .fechaProceso = txtFechaComprobante.Value
    '            .fechaCobro = txtFechaComprobante.Value
    '            .tipoDocPago = txtIdComprobante.Text
    '            .numeroDoc = txtNumeroComp.Text
    '            .monedaObligacion = IIf(rbNac.Checked = True, "1", "2")
    '            .moneda = IIf(rbNac.Checked = True, "1", "2")
    '            .entidadFinanciera = txtIdCaja.Text
    '            .numeroOperacion = txtNumeroComp.Text
    '            .tipoCambio = nudTipoCambio.Value
    '            .montoSoles = nudImporteNac.Value
    '            .montoUsd = nudImporteExt.Value
    '            .montoItf = 0
    '            .montoItfusd = 0
    '            .glosa = Glosa()
    '            .entregado = "SI"
    '            .usuarioModificacion = "Jiuni"
    '            .fechaModificacion = DateTime.Now
    '        End With

    '        ndocumento.documentoCaja = ndocumentoCaja

    '        For Each i As DataGridViewRow In dgvDetalleItems.Rows
    '            ndocumentoCajaDetalle = New documentoCajaDetalle
    '            ndocumentoCajaDetalle.idDocumento = lbldDocCaja.Text
    '            ndocumentoCajaDetalle.secuencia = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
    '            ndocumentoCajaDetalle.fecha = txtFechaComprobante.Value
    '            ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
    '            ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()
    '            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
    '            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
    '            ndocumentoCajaDetalle.montoItf = 0 'dgvDetalleItems.Rows(i).Cells(3).Value()
    '            ndocumentoCajaDetalle.montoItfusd = 0 ' dgvDetalleItems.Rows(i).Cells(4).Value()
    '            ndocumentoCajaDetalle.entregado = "SI"
    '            '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
    '            ndocumentoCajaDetalle.difMN = 0
    '            ndocumentoCajaDetalle.difME = 0
    '            ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
    '            ndocumentoCajaDetalle.Action = Business.Entity.BaseBE.EntityAction.UPDATE
    '            ndocumentoCajaDetalle.usuarioModificacion = "Jiuni"
    '            ndocumentoCajaDetalle.fechaModificacion = Date.Now
    '            ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
    '        Next
    '        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
    '        asiento = asientoCaja()
    '        ListaAsiento.Add(asiento)
    '        ndocumento.asiento = ListaAsiento
    '        documentoCajaSA.EditarGroupCaja(ndocumento)
    '        lblEstado.Text = "Transacción realizada con éxito!"
    '        lblEstado.Image = My.Resources.ok4
    '        Dispose()
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        lblEstado.Image = My.Resources.warning2
    '    End Try
    'End Sub

    Function Glosa() As String
        Dim strGlosa As String = Nothing
        strGlosa = "Por pagos con comprobante, en " & cboTipoDoc.Text & " con fecha: " & New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        Return strGlosa
    End Function
    Function GlosaReclamacion() As String
        Dim strGlosa As String = Nothing
        strGlosa = "Por pagos de reclamación, en " & cboTipoDoc.Text & " con fecha: " & New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        Return strGlosa
    End Function
#End Region

    Private Sub frmPagos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub txtImporteCompramn_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtPagoMN.ValueChanged
        If (tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
        ElseIf (tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
            If (CDec(txtPagoMN.Value <= SaldoEFMN.DoubleValue) And txtPagoMN.Value <> 0) Then
                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    'ME - ME
                    If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        If txtTipoCambio.DoubleValue > 0 Then
                            txtPagoME.Value = txtPagoMN.Value / txtTipoCambio.DoubleValue
                            pnDiferencia.Visible = True
                            '   CalculoSoles()
                            CalculoGRID()
                        End If
                        'MN - ME
                    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        pnDiferencia.Visible = True
                        CalculoGRID()
                    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                        CalculoGRID()
                        'ME - MN
                    ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                        CalculoGRID()
                    End If
                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    CalculoGRID()
                End If
            ElseIf (txtPagoMN.Value <> 0) Then
                lblEstado.Text = "no debe exceder el monto permitido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtPagoMN.Value = 0.0
            End If
        End If

    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs)
        If (cboDepositoHijo.SelectedValue > -1) Then
            Select Case cboMoneda.SelectedValue
                Case 1
                    txtImporteCompramn_ValueChanged(sender, e)
                Case 2
                    txtImporteComprame_ValueChanged(sender, e)
            End Select
        End If
    End Sub

    Private Sub cboEntidades_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub pcEntidad_CloseUp(sender As Object, e As PopupClosedEventArgs)
        If e.PopupCloseType = PopupCloseType.Done Then
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.cboEntidades.Focus()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        txtPagoME.Value = 0
        txtPagoMN.Value = 0
        txtTipoCambio.DoubleValue = 0
        txtDiferenciaMontos.Value = 0
        txtNumOper.Clear()
        cboDepositoHijo.SelectedValue = -1
        cboMoneda.SelectedValue = -1
        txtCuentaCorriente.Clear()
        SaldoEFME.DoubleValue = 0
        SaldoEFMN.DoubleValue = 0
        cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim value As Object = Me.cboDepositoHijo.SelectedValue
        If (Me.cboDepositoHijo.Items.Count > 0) Then
            If IsNumeric(value) Then
                cargarDatosCuenta(CInt(value))
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtImporteComprame_ValueChanged(sender As Object, e As EventArgs) Handles txtPagoME.ValueChanged
        If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
            If (CDec(txtPagoME.Value <= SaldoEFME.DoubleValue)) Then
                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    'ME - ME
                    If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        If (txtPagoME.Value <= lblDeudaPendienteme.Text And txtPagoME.Value > 0) Then
                            If txtTipoCambio.DoubleValue > 0 Then
                                txtPagoMN.Value = txtPagoME.Value * txtTipoCambio.DoubleValue
                                pnDiferencia.Visible = True
                                'CargarDiferenciasdeImporte()
                                'CalculoDolares()
                                CalculoGRID()
                            Else
                                txtTipoCambio.DoubleValue = 0
                                lblEstado.Text = "Ingrese el tipo de cambio."
                                Timer1.Enabled = True
                                PanelError.Visible = True
                                TiempoEjecutar(10)
                                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            End If
                        ElseIf (txtPagoME.Value <> 0) Then
                            txtPagoMN.Value = 0
                            txtDiferenciaMontos.Value = 0
                            txtPagoME.Value = 0
                            lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)
                            txtPagoME.Select(0, txtPagoME.Text.Length)
                        End If
                        'MN - ME
                    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        If txtTipoCambio.DoubleValue > 0 Then
                            txtPagoME.Value = txtPagoMN.Value / txtTipoCambio.DoubleValue
                            pnDiferencia.Visible = True
                            CalculoSoles()
                            CalculoGRID()
                        End If
                        'MN - MN
                    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                        If txtTipoCambio.DoubleValue > 0 Then
                            If (txtPagoME.Value <= lblDeudaPendienteme.Text) Then
                                txtPagoMN.Value = txtPagoME.Value * txtTipoCambio.DoubleValue
                                pnDiferencia.Visible = True
                                'CalculoDolares()
                                CalculoGRID()
                            Else
                                txtPagoME.Value = 0
                                txtTipoCambio.DoubleValue = 0
                                txtPagoMN.Value = 0
                                txtDiferenciaMontos.Value = 0
                                lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                                Timer1.Enabled = True
                                PanelError.Visible = True
                                TiempoEjecutar(10)
                                txtPagoME.Select(0, txtPagoME.Text.Length)
                            End If
                        Else
                            lblEstado.Text = "Ingrese el tipo de cambio."
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)
                            txtTipoCambio.DoubleValue = 0
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        End If

                        'ME - MN
                    ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then

                        If txtTipoCambio.DoubleValue > 0 Then
                            txtPagoMN.Value = txtPagoME.Value * txtTipoCambio.DoubleValue
                            If (txtPagoMN.Value <= txtSaldoPorPagar.DecimalValue) Then
                                pnDiferencia.Visible = True
                                'CalculoDolares()
                                CalculoGRID()
                            Else
                                txtTipoCambio.DoubleValue = 0
                                txtPagoMN.Value = 0
                                txtPagoME.Value = 0
                                txtDiferenciaMontos.Value = 0
                                lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                                Timer1.Enabled = True
                                PanelError.Visible = True
                                TiempoEjecutar(10)
                                txtPagoMN.Select(0, txtPagoMN.Text.Length)

                            End If
                        Else
                            txtTipoCambio.DoubleValue = 0
                            lblEstado.Text = "Ingrese el tipo de cambio."
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        End If

                    End If
                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    CalculoGRID()
                End If
            Else
                txtPagoME.Value = 0
                lblEstado.Text = "La moneda no debe exceder al monto disponible de la cuenta."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then

            If txtTipoCambio.DoubleValue > 0 Then
                txtPagoMN.Value = txtPagoME.Value * txtTipoCambio.DoubleValue


                If (txtPagoMN.Value <= SaldoEFMN.DoubleValue) Then
                    If (txtPagoMN.Value <= SaldoEFMN.DoubleValue) Then
                        pnDiferencia.Visible = True
                        'CalculoDolares()
                        CalculoGRID()
                    Else
                        lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                        txtPagoMN.Value = 0
                        txtPagoME.Value = 0
                        txtDiferenciaMontos.Value = 0
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                    End If

                Else
                    'txtTipoCambio.DoubleValue = 0
                    txtPagoMN.Value = 0
                    txtPagoME.Value = 0
                    txtDiferenciaMontos.Value = 0
                    lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtPagoMN.Select(0, txtPagoMN.Text.Length)

                End If
            Else
                txtTipoCambio.DoubleValue = 0
                lblEstado.Text = "Ingrese el tipo de cambio."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
            End If
        End If
        'End Select
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs)

    End Sub
    Function GetSaldoEF() As GFichaUsuario
        Dim EFSA As New EstadosFinancierosSA
        Dim EF As New estadosFinancieros
        Dim gficha As New GFichaUsuario

        EF = EFSA.GetEstadoSaldoEF(New estadosFinancieros With {.idestado = cboDepositoHijo.SelectedValue})
        gficha.SaldoMN = EF.importeBalanceMN
        gficha.SaldoME = EF.importeBalanceME
        Return gficha

    End Function

    Private Sub txtImporteCompramn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPagoMN.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If (CDec(txtPagoMN.Value <= SaldoEFMN.DoubleValue) And txtPagoMN.Value > 0) Then
                    txtTipoCambio.Select()
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                Else
                    txtPagoMN.Select()
                    txtPagoMN.Select(0, txtTipoCambio.Text.Length)
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'txtImporteCompramn.Clear()
        End Try
    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If cboTipoDoc.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDoc.SelectedValue = "109" Then 'EFECTIVO (que se genere un vocher de caja con los datos del comprobante que se está pagando) 
                pnEntidad.Visible = False
                pnFecha.Visible = False
                Label17.Text = "NRO. VOUCHER:"

            ElseIf cboTipoDoc.SelectedValue = "007" Then ' CHEQUES
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            ElseIf cboTipoDoc.SelectedValue = "001" Then ' DEPOSITO EN CUENTA 
                pnEntidad.Visible = True
                pnFecha.Visible = False
                Label17.Text = "NRO. OPERACIÓN:"

            ElseIf cboTipoDoc.SelectedValue = "111" Then ' CHEQUE NO NEGOCIABLE 
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            End If
        End If
    End Sub

    Private Sub txtNumOper_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumOper.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtNumOper.Text.Trim.Length > 0 Then
                    txtCuentaCorriente.Select()

                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumOper.Clear()
        End Try
    End Sub

    Private Sub txtCuentaCorriente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuentaCorriente.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtCuentaCorriente.Text.Trim.Length > 0 Then

                    Select Case cboMoneda.SelectedValue
                        Case 1
                            Select Case tb19.ToggleState
                                Case ToggleButton2.ToggleButtonState.OFF 'dolares
                                    txtPagoME.Select()
                                    txtPagoME.Select(0, txtPagoMN.Text.Length)
                                Case ToggleButton2.ToggleButtonState.ON 'soles
                                    txtPagoMN.Select()
                                    txtPagoMN.Select(0, txtPagoMN.Text.Length)

                            End Select
                        Case 2

                            Select Case tb19.ToggleState
                                Case ToggleButton2.ToggleButtonState.OFF 'dolares
                                    txtPagoME.Select()
                                    txtPagoME.Select(0, txtPagoMN.Text.Length)
                                Case ToggleButton2.ToggleButtonState.ON 'soles
                                    txtPagoMN.Select()
                                    txtPagoMN.Select(0, txtPagoMN.Text.Length)
                            End Select
                    End Select

                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtCuentaCorriente.Clear()
        End Try
    End Sub

    Private Sub PopupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvTipoCambio.SelectedItems.Count > 0 Then
                Me.txtTipoCambio.DoubleValue = lsvTipoCambio.SelectedItems(0).SubItems(1).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            'Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If Not Me.PopupControlContainer1.IsShowing() Then
            ' Let the popup align around the source textBox.
            Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
            ' Passing Point.Empty will align it automatically around the above ParentControl.
            Me.PopupControlContainer1.ShowPopup(Point.Empty)
        End If

        If SaldoEFME.Text.Trim.Length > 0 Then
            Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
            Me.PopupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo()
        End If

    End Sub

    Public Sub CargarEntidadesXtipo()
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        Dim sumatoriaMN As Decimal
        Dim sumatoriaME As Decimal
        Try

            Select Case cboMoneda.SelectedValue
                Case 1
                    If (txtPagoMN.Value <= SaldoEFMN.DoubleValue) Then
                        lsvTipoCambio.Items.Clear()
                        lsvTipoCambio.Columns.Clear()

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtPagoMN.Value, cboDepositoHijo.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(CDec(i.diferTipoCambio))
                            n.SubItems.Add(CDec(i.montoUsd).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoSoles).ToString("N2"))
                            lsvTipoCambio.Items.Add(n)
                            sumatoriaMN += i.montoSoles
                            sumatoriaME += i.montoUsd
                        Next

                        Dim z As New ListViewItem("Total")
                        z.SubItems.Add("")
                        z.SubItems.Add("--------------")
                        z.SubItems.Add("--------------")
                        lsvTipoCambio.Items.Add(z)

                        Dim X As New ListViewItem("Total")
                        X.SubItems.Add("Total:")
                        X.SubItems.Add(CDec(sumatoriaME))
                        X.SubItems.Add(CDec(sumatoriaMN))

                        lsvTipoCambio.Items.Add(X)
                        Select Case cboMoneda.SelectedValue
                            Case 1
                                txtDiferenciaMontos.Value = txtPagoMN.Value - sumatoriaMN
                            Case 2
                                txtDiferenciaMontos.Value = txtPagoME.Value - sumatoriaME
                        End Select

                        'txtImporteCompramn.Value = sumatoria
                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual! "
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtPagoMN.Value = 0.0
                        txtPagoMN.Select(0, txtPagoMN.Text.Length)
                    End If
                Case 2
                    If (txtPagoME.Value <= SaldoEFME.DoubleValue) Then
                        lsvTipoCambio.Items.Clear()

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtPagoME.Value, cboDepositoHijo.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(CDec(i.diferTipoCambio))
                            n.SubItems.Add(CDec(i.montoUsd).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoSoles).ToString("N2"))
                            lsvTipoCambio.Items.Add(n)
                            sumatoriaMN += i.montoSoles
                            sumatoriaME += i.montoUsd
                        Next


                        Dim z As New ListViewItem("Total")
                        z.SubItems.Add("")
                        z.SubItems.Add("--------------")
                        z.SubItems.Add("--------------")
                        lsvTipoCambio.Items.Add(z)

                        Dim X As New ListViewItem("Total")
                        X.SubItems.Add("TOTAL")
                        X.SubItems.Add(CDec(sumatoriaME))
                        X.SubItems.Add(CDec(sumatoriaMN))
                        lsvTipoCambio.Items.Add(X)
                        Select Case cboMoneda.SelectedValue
                            Case 1
                                txtDiferenciaMontos.Value = txtPagoME.Value - sumatoriaME
                            Case 2
                                txtDiferenciaMontos.Value = txtPagoMN.Value - sumatoriaMN
                        End Select

                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtPagoME.Value = 0.0
                        txtPagoME.Select(0, txtPagoME.Text.Length)
                    End If
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarDiferenciasdeImporte()
        Dim dt As New DataTable
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        Dim ListadocumentoCajaEtalle As New List(Of documentoCajaDetalle)
        Dim sumatoriaMN As Decimal
        Dim sumatoriaME As Decimal
        Dim DifsumatoriaMN As Decimal
        Dim DifsumatoriaME As Decimal
        Dim diferenciaCaja As Decimal


        Dim ListadocumentoCajaEtalle2 As New List(Of documentoCajaDetalle)

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("TC", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("TCCompra", GetType(Decimal))
        dt.Columns.Add("importeCompraMN", GetType(Decimal))
        dt.Columns.Add("importeCompraME", GetType(Decimal))
        dt.Columns.Add("difMNCajaMN", GetType(Decimal))
        dt.Columns.Add("difMNCajaME", GetType(Decimal))

        If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
            ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtPagoME.Value, cboDepositoHijo.SelectedValue)

            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

            Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
            gridStackedHeaderRowDescriptor1.Name = "Row1"

            Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
            gridStackedHeaderRowDescriptor1.Name = "Row2"

            ' Create an object for GridStackedHeaderDescriptor
            Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
            Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
            Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
            Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

            gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
            gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
            gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

            gridStackedHeaderDescriptor1.HeaderText = "CAJA Y BANCOS - " & cboDepositoHijo.Text

            gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

            gridStackedHeaderDescriptor2.HeaderText = "CUENTAS POR PAGAR"
            gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

            gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
            gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

            gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CAJA"
            gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

            gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
                                                                    New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
                                                                     New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
                                                                           New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})


            gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
                                                                    New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
                                                                           New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

            gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
                                                                    New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})

            gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
            gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
            gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
            gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)
            Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True

            If Not IsNothing(ListadocumentoCajaEtalle) Then

                For Each i In ListadocumentoCajaEtalle
                    Dim dr As DataRow = dt.NewRow()
                    If (i.montoSoles > 0 And i.montoUsd > 0) Then
                        dr(0) = i.idDocumento
                        dr(1) = i.diferTipoCambio
                        dr(2) = i.montoSoles
                        dr(3) = i.montoUsd
                        dr(4) = lblTipoCambio.Text
                        sumatoriaMN = CDec(i.montoUsd * lblTipoCambio.Text).ToString("N2")
                        sumatoriaME = CDec(i.montoUsd)
                        dr(5) = sumatoriaMN
                        dr(6) = sumatoriaME
                        DifsumatoriaMN = CDec((lblTipoCambio.Text - i.diferTipoCambio) * i.montoUsd).ToString("N2")
                        DifsumatoriaME = CDec(i.montoUsd - sumatoriaME)
                        dr(7) = DifsumatoriaMN
                        dr(8) = DifsumatoriaME

                        diferenciaCaja += DifsumatoriaMN

                        dt.Rows.Add(dr)
                    End If

                Next
                dgvDiferencia.DataSource = dt
                Me.dgvDiferencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
                'txtImporteCompramn.Value = sumatoriaMN
                txtDiferenciaMontos.Value = diferenciaCaja

            Else
            End If
        ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
            'ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)

            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

            Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
            gridStackedHeaderRowDescriptor1.Name = "Row1"

            Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
            gridStackedHeaderRowDescriptor1.Name = "Row2"

            ' Create an object for GridStackedHeaderDescriptor
            Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
            Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
            Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
            Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

            gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
            gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
            gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

            gridStackedHeaderDescriptor1.HeaderText = "CUENTAS POR PAGAR"
            gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

            gridStackedHeaderDescriptor2.HeaderText = "FACTURA DE COMPRA"
            gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

            gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
            gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

            gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CUENTAS POR PAGAR"
            gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

            gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
                                                                    New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
                                                                     New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
                                                                           New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})


            gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
                                                                    New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
                                                                           New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

            gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
                                                                    New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})


            gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
            gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
            gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
            gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)

            ' Display Stacked Headers 
            Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True



            If (manipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
                Dim tipoCAmbio As Decimal
                Dim dr As DataRow = dt.NewRow()

                tipoCAmbio = CDec(txtPagoMN.Value / lblDeudaPendienteme.Text)

                dr(0) = 0
                dr(1) = txtTipoCambio.DoubleValue
                dr(2) = txtPagoMN.Value
                dr(3) = CDec(txtPagoMN.Value / (tipoCAmbio)).ToString("N2")
                dr(4) = lblTipoCambio.Text
                sumatoriaME = CDec(txtPagoMN.Value / tipoCAmbio).ToString("N2")
                sumatoriaMN = ((sumatoriaME) * lblTipoCambio.Text)


                dr(5) = sumatoriaMN
                dr(6) = sumatoriaME
                DifsumatoriaMN = CDec(sumatoriaMN - txtPagoMN.Value).ToString("N2")
                DifsumatoriaME = CDec(sumatoriaME - CDec(txtPagoMN.Value / tipoCAmbio)).ToString("N2")
                dr(7) = DifsumatoriaMN
                dr(8) = DifsumatoriaME

                dt.Rows.Add(dr)
                dgvDiferencia.DataSource = dt

                txtDiferenciaMontos.Value = DifsumatoriaMN
            Else
                Dim dr As DataRow = dt.NewRow()
                dr(0) = 0
                dr(1) = txtTipoCambio.DoubleValue
                dr(2) = txtPagoMN.Value
                dr(3) = CDec(txtPagoMN.Value / txtTipoCambio.DoubleValue).ToString("N2")
                dr(4) = lblTipoCambio.Text
                sumatoriaMN = CDec((CDec(txtPagoMN.Value / txtTipoCambio.DoubleValue) * lblTipoCambio.Text))
                sumatoriaME = CDec(txtPagoMN.Value / txtTipoCambio.DoubleValue).ToString("N2")

                dr(5) = sumatoriaMN
                dr(6) = sumatoriaME
                DifsumatoriaMN = CDec(sumatoriaMN - txtPagoMN.Value).ToString("N2")
                DifsumatoriaME = CDec(sumatoriaME - CDec(txtPagoMN.Value / txtTipoCambio.DoubleValue)).ToString("N2")
                dr(7) = DifsumatoriaMN
                dr(8) = DifsumatoriaME

                dt.Rows.Add(dr)
                dgvDiferencia.DataSource = dt

                txtDiferenciaMontos.Value = DifsumatoriaMN
            End If



        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
            ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtPagoME.Value, cboDepositoHijo.SelectedValue)

            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

            Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
            gridStackedHeaderRowDescriptor1.Name = "Row1"

            Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
            gridStackedHeaderRowDescriptor1.Name = "Row2"

            ' Create an object for GridStackedHeaderDescriptor
            Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
            Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
            Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
            Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

            gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
            gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
            gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

            gridStackedHeaderDescriptor1.HeaderText = "CAJA Y BANCOS"
            gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

            gridStackedHeaderDescriptor2.HeaderText = "CUENTAS POR PAGAR"
            gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

            gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
            gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

            gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CAJA"
            gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

            gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
                                                                    New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
                                                                     New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
                                                                           New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})

            gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
                                                                    New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
                                                                           New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

            gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
                                                                    New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})


            gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
            gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
            gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
            gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
            Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)

            ' Display Stacked Headers 
            Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True

            If Not IsNothing(ListadocumentoCajaEtalle) Then

                For Each i In ListadocumentoCajaEtalle
                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.idDocumento
                    dr(1) = i.diferTipoCambio
                    dr(2) = i.montoSoles
                    dr(3) = i.montoUsd
                    dr(4) = txtTipoCambio.DoubleValue
                    sumatoriaMN = CDec((i.montoUsd * txtTipoCambio.DoubleValue)).ToString("N2")
                    sumatoriaME = i.montoUsd
                    dr(5) = sumatoriaMN
                    dr(6) = sumatoriaME

                    DifsumatoriaMN = CDec((txtTipoCambio.Text - i.diferTipoCambio) * i.montoUsd).ToString("N2")
                    DifsumatoriaME = CDec(sumatoriaME - i.montoUsd)
                    dr(7) = DifsumatoriaMN
                    dr(8) = DifsumatoriaME

                    diferenciaCaja += DifsumatoriaMN

                    dt.Rows.Add(dr)

                Next
                dgvDiferencia.DataSource = dt
                Me.dgvDiferencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
                'txtImporteCompramn.Value = sumatoriaMN
                txtDiferenciaMontos.Value = diferenciaCaja
            Else
            End If
        End If

    End Sub

    Public Sub CargarMovimientosDetallado(intIdDocumento As Integer)
        Dim dt As New DataTable
        Dim DocumentoCajaDetalleSA As New DocumentoCompraDetalleSA
        Dim ListadocumentoCajaEtalle As New List(Of documentoCajaDetalle)
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        Dim saldoME As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim listadocumento As New List(Of documentoCajaDetalle)
        Dim docuem As New documentoCajaDetalle
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)

        dt.Columns.Add("idDocumento", GetType(Integer)) '1
        dt.Columns.Add("item", GetType(String)) '2
        dt.Columns.Add("importeMN", GetType(Decimal)) '3
        dt.Columns.Add("importeME", GetType(Decimal)) '4
        dt.Columns.Add("TC", GetType(Decimal)) '5
        dt.Columns.Add("pagoMN", GetType(Decimal)) '6
        dt.Columns.Add("pagoME", GetType(Decimal)) '7
        dt.Columns.Add("saldoMN", GetType(Decimal)) '8
        dt.Columns.Add("saldoME", GetType(Decimal)) '9


        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

                Select Case cboMoneda.SelectedValue
                    Case 1
                        ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                        ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                    Case 2
                        Select Case tb19.ToggleState
                            Case ToggleButton2.ToggleButtonState.OFF 'dolares
                                ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.DoubleValue).ToString("N2")
                                ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            Case ToggleButton2.ToggleButtonState.ON 'soles
                                ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                                ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                        End Select
                End Select

                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.DoubleValue
                ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                ndocumentoCajaDetalle.usuarioModificacion = CStr(cboDepositoHijo.SelectedValue)
                ndocumentoCajaDetalle.fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                ndocumentoCajaDetalle.idCajaPadre = cboDepositoHijo.SelectedValue
                ndocumentoCajaDetalle.documentoAfectadodetalle = dgvDetalleItems.Rows(i.Index).Cells(11).Value()
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
            End If
        Next

        dgvDistribucionME.Table.Records.DeleteAll()
        ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtPagoME.Value, cboDepositoHijo.SelectedValue)

        For Each i In ListadocumentoCajaDetalle

            Dim consultaCaja = (From c In ListadocumentoCajaEtalle
                                 Order By c.fecha).ToList
            For Each item In consultaCaja

                Dim Salidas = (Aggregate n In listadocumento _
                           Where n.documentoAfectado = item.idDocumento _
                           Into sumMN = Sum(n.montoSoles), sumME = Sum(n.montoUsd))

                Select Case i.moneda
                    Case 2
                        saldoME = i.montoUsd
                        saldoMN = i.montoSoles
                        If (saldoME > 0) Then
                            Dim dr As DataRow = dt.NewRow()
                            dr(0) = i.idItem
                            dr(1) = i.DetalleItem
                            If ((item.montoUsd - Salidas.sumME.GetValueOrDefault) >= i.montoUsd And i.montoUsd = 0) Then
                                dr(2) = i.montoSoles
                                dr(3) = i.montoUsd
                                dr(4) = item.diferTipoCambio
                                dr(5) = i.ImporteNacional
                                dr(6) = i.montoUsd
                                dr(7) = CDec(i.montoSoles - i.montoSoles).ToString("N2")
                                dr(8) = CDec(i.montoUsd - i.montoUsd).ToString("N2")
                                saldoME = item.montoUsd - i.montoUsd
                                saldoMN = item.montoSoles - i.montoSoles
                                i.montoUsd = saldoME
                                i.montoSoles = saldoMN
                                dt.Rows.Add(dr)
                            ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) <= i.montoUsd And i.montoUsd = 0) Then
                                dr(2) = i.montoSoles
                                dr(3) = i.montoUsd
                                dr(4) = item.diferTipoCambio
                                dr(5) = i.montoSoles
                                dr(6) = i.montoUsd
                                dr(7) = CDec(i.montoSoles - i.montoSoles).ToString("N2")
                                dr(8) = CDec(i.montoUsd - i.montoUsd).ToString("N2")
                                saldoME = item.montoUsd - i.montoUsd
                                saldoMN = item.montoSoles - i.montoSoles
                                i.montoUsd = saldoME
                                i.montoSoles = saldoMN
                                dt.Rows.Add(dr)
                            ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) < i.montoUsd And i.montoUsd > 0 And (item.montoUsd - Salidas.sumME.GetValueOrDefault) > 0) Then
                                dr(2) = i.montoSoles
                                dr(3) = i.montoUsd
                                dr(4) = item.diferTipoCambio
                                dr(5) = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * item.diferTipoCambio), 2)
                                dr(6) = (item.montoUsd - Salidas.sumME.GetValueOrDefault)
                                dr(7) = CDec(i.montoSoles - dr(5)).ToString("N2")
                                dr(8) = CDec(i.montoUsd - dr(6)).ToString("N2")
                                saldoME = saldoME - dr(6)
                                saldoMN = saldoMN - dr(5)
                                i.montoUsd = saldoME
                                i.montoSoles = saldoMN
                                docuem = New documentoCajaDetalle
                                docuem.documentoAfectado = item.idDocumento
                                docuem.montoSoles = dr(5)
                                docuem.montoUsd = dr(6)
                                listadocumento.Add(docuem)
                                dt.Rows.Add(dr)
                            ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd > 0) Then
                                dr(2) = i.montoSoles
                                dr(3) = i.montoUsd
                                dr(4) = item.diferTipoCambio
                                dr(5) = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
                                dr(6) = i.montoUsd
                                dr(7) = CDec(i.montoSoles - dr(5)).ToString("N2")
                                dr(8) = CDec(i.montoUsd - dr(6)).ToString("N2")
                                saldoME = saldoME - i.montoUsd
                                saldoMN = saldoMN - i.montoSoles
                                i.montoUsd = saldoME
                                i.montoSoles = saldoMN
                                docuem = New documentoCajaDetalle
                                docuem.documentoAfectado = item.idDocumento
                                docuem.montoSoles = dr(5)
                                docuem.montoUsd = dr(6)
                                listadocumento.Add(docuem)
                                dt.Rows.Add(dr)
                            ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd < 0) Then
                                dr(2) = i.montoSoles
                                dr(3) = i.montoUsd
                                dr(4) = item.diferTipoCambio
                                dr(5) = Math.Round(CDec((i.montoUsd * -1) * item.diferTipoCambio), 2)
                                dr(6) = Math.Round(CDec(i.montoUsd * -1), 2)
                                dr(7) = CDec(i.montoSoles - dr(5)).ToString("N2")
                                dr(8) = CDec(i.montoUsd - dr(6)).ToString("N2")
                                saldoME = item.montoUsd - i.montoUsd
                                saldoMN = item.montoSoles - i.montoSoles
                                i.montoUsd = saldoME
                                i.montoSoles = saldoMN
                                docuem = New documentoCajaDetalle
                                docuem.documentoAfectado = item.idDocumento
                                docuem.montoSoles = dr(5)
                                docuem.montoUsd = dr(6)
                                listadocumento.Add(docuem)
                                dt.Rows.Add(dr)
                            ElseIf ((item.montoUsd - Salidas.sumME) = i.montoUsd And i.montoUsd > 0) Then
                                dr(2) = i.montoSoles
                                dr(3) = i.montoUsd
                                dr(4) = item.diferTipoCambio
                                dr(5) = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
                                dr(6) = i.montoUsd
                                dr(7) = CDec(i.montoSoles - dr(5)).ToString("N2")
                                dr(8) = CDec(i.montoUsd - dr(6)).ToString("N2")
                                saldoME = saldoME - i.montoUsd
                                saldoMN = saldoMN - i.montoSoles
                                i.montoUsd = saldoME
                                i.montoSoles = saldoMN
                                docuem = New documentoCajaDetalle
                                docuem.documentoAfectado = item.idDocumento
                                docuem.montoSoles = dr(5)
                                docuem.montoUsd = dr(6)
                                listadocumento.Add(docuem)
                                dt.Rows.Add(dr)
                            End If

                        End If
                End Select


            Next

        Next

        dgvDistribucionME.DataSource = dt


    End Sub

    Private Sub txtImporteComprame_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPagoME.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtPagoME.Text.Trim.Length > 0 And txtPagoME.Value > 0 Then
                    txtTipoCambio.Select()
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                Else
                    txtPagoME.Select()
                    txtPagoME.Select(0, txtTipoCambio.Text.Length)
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumOper.Clear()
        End Try
    End Sub

    Private Sub txtTipoCambio_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case cboMoneda.SelectedValue
                    Case 1
                        'txtImporteCompramn.Value = 0
                        txtPagoMN.Select()
                        txtPagoMN.Select(0, txtPagoMN.Text.Length)
                    Case 2
                        'txtImporteComprame.Value = 0
                        txtPagoME.Select()
                        txtPagoME.Select(0, txtPagoME.Text.Length)
                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumOper.Clear()
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Select Case cboMoneda.SelectedValue
            Case 1
                If Not Me.PopupControlContainer3.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer1.ShowPopup(Point.Empty)
                End If
                If SaldoEFME.Text.Trim.Length > 0 Then
                    Me.PopupControlContainer3.ParentControl = Me.txtPagoMN
                    Me.PopupControlContainer3.ShowPopup(Point.Empty)
                    CargarDiferenciasdeImporte()
                End If
            Case 2
                If SaldoEFME.Text.Trim.Length > 0 Then
                    If Not Me.PopupControlContainer3.IsShowing() Then
                        ' Let the popup align around the source textBox.
                        Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
                        ' Passing Point.Empty will align it automatically around the above ParentControl.
                        Me.PopupControlContainer1.ShowPopup(Point.Empty)
                    End If
                    Me.PopupControlContainer3.ParentControl = Me.txtPagoME
                    Me.PopupControlContainer3.ShowPopup(Point.Empty)
                    CargarDiferenciasdeImporte()
                End If
        End Select

    End Sub


    Private Sub cboDepositoHijo_MouseClick(sender As Object, e As MouseEventArgs) Handles cboDepositoHijo.MouseClick
        If (cboDepositoHijo.Items.Count = 0) Then
            cargarCtasFinanLoad()
        End If
    End Sub

    Private Sub cargarCtasFinanLoad()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo("TC")
            Dim lista As New List(Of String)
            lista.Add("001")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        End If
    End Sub



    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim FichaEFSaldo As New GFichaUsuario

        Try
            If txtPagoMN.Value > 0 Then

                Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = txtPeriodo.Value.Year, .mes = txtPeriodo.Value.Month})
                If Not IsNothing(valida) Then
                    If valida = True Then
                        MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If


                If Not cboDepositoHijo.Text.Length > 0 Then
                    lblEstado.Text = "Ingrese la entidad financiera."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    cboDepositoHijo.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If cboTipoDoc.SelectedValue = "001" Then

                    If Not txtNumOper.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de operación."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtNumOper.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de cuenta."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtCuentaCorriente.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                ElseIf cboTipoDoc.SelectedValue = "003" Then

                    If Not txtNumOper.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de operación."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtNumOper.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                ElseIf cboTipoDoc.SelectedValue = "007" Then

                ElseIf cboTipoDoc.SelectedValue = "109" Then
                    If Not txtNumeroCompr.Text.Length > 0 Then
                        lblEstado.Text = "Ingrese el numero de voucher"
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                ElseIf cboTipoDoc.SelectedValue = "111" Then

                ElseIf cboTipoDoc.SelectedValue = "007" Then
                    If Not txtNumeroCompr.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número del tipo de documento."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                Else
                    If Not txtNumeroCompr.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número del tipo de documento."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtNumeroCompr.Focus()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                End If

                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    'obteniendo saldo  de la entidad financiera seleccionada
                    Select Case cboMoneda.SelectedValue
                        Case 1
                            If txtPagoMN.Value > SaldoEFMN.DoubleValue Then
                                Throw New Exception("El importe compra execede al monto de la cuenta financiera actual!")
                            Else

                                If TipoPagoReclamacion = "VENTA" Then

                                    GrabarReclamacion()
                                Else
                                    'PAGO COMPRA NORMAL
                                    Grabar()
                                End If



                            End If
                        Case 2
                            If txtPagoME.Value > SaldoEFME.DoubleValue Then
                                Throw New Exception("El importe compra execede al monto de la cuenta financiera actual!")
                            Else
                                If TipoPagoReclamacion = "VENTA" Then

                                    GrabarReclamacion()
                                Else
                                    'PAGO COMPRA NORMAL
                                    Grabar()
                                End If

                            End If
                    End Select

                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    '   Editar()
                End If
            Else
                lblEstado.Text = "Ingresar el importe a pagar!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()

        Dim estado As New estadosFinancieros
        Dim estadoSA As New EstadosFinancierosSA

        If cboMoneda.SelectedValue = "1" Then

        Else
            estado = estadoSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)

            Dim f As New frmCajaEntranjera(estado)
            f.txtCuenta.Text = estado.descripcion
            f.txtCuenta.Tag = estado.idestado
            f.txtDeuda.DoubleValue = txtSaldoPorPagar.DecimalValue
            If lblMonedaCobro.Text = "NACIONAL" Then
                f.cboPago.Text = "NACIONAL"
            Else
                f.cboPago.Text = "EXTRANJERO"
            End If
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, List(Of movimientocajaextranjera))
                ListaPagosDolares = c
            End If
            If datos.Count > 0 Then
                txtTipoCambio.DoubleValue = datos(0).TasaIva
                txtPagoMN.Value = datos(0).Montomn
                txtPagoME.Value = datos(0).Montome
            End If
        End If



    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        If cboMoneda.SelectedValue = "1" Then
            LinkLabel1.Enabled = False
        Else
            LinkLabel1.Enabled = True
        End If
    End Sub

    Private Sub cboMesCompra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedIndexChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            txtDia.Value = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
            If IsNumeric(cboDepositoHijo.SelectedValue) Then
                cargarDatosCuenta(CInt(cboDepositoHijo.SelectedValue))
            End If
        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            txtDia.Value = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
            If IsNumeric(cboDepositoHijo.SelectedValue) Then
                cargarDatosCuenta(CInt(cboDepositoHijo.SelectedValue))
            End If
        End If
    End Sub

    Private Sub txtDia_ValueChanged(sender As Object, e As EventArgs) Handles txtDia.ValueChanged
        If IsNumeric(cboDepositoHijo.SelectedValue) Then
            cargarDatosCuenta(CInt(cboDepositoHijo.SelectedValue))
        End If
    End Sub

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click

    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub
End Class