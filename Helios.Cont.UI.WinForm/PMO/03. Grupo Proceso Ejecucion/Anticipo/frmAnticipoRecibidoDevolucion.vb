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

Public Class frmAnticipoRecibidoDevolucion

    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property lblTipoCambioOriginal() As Decimal


    Public Property ListaAsientonTransito As New List(Of asiento)

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "ANT", "ANTICIPOS", GEstableciento.IdEstablecimiento)
        SetRenderer()
        ObtenerTablaGenerales()
        txtFechaTrans.Value = Date.Now
        DockingInicio()
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


    Public Sub CargarTiposDeCambio()
        Dim dt As New DataTable
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA

        dt.Columns.Add("TC", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))

        For Each i In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.diferTipoCambio
            dr(1) = i.montoUsd
            dr(2) = i.montoSoles

            dt.Rows.Add(dr)

        Next
        dgvTipoCambio.DataSource = dt
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

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("TC", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("TCCompra", GetType(Decimal))
        dt.Columns.Add("importeCompraMN", GetType(Decimal))
        dt.Columns.Add("importeCompraME", GetType(Decimal))
        dt.Columns.Add("difMNCajaMN", GetType(Decimal))
        dt.Columns.Add("difMNCajaME", GetType(Decimal))

        ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)

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

                dr(0) = i.idDocumento
                dr(1) = i.diferTipoCambio
                dr(2) = i.montoSoles
                dr(3) = i.montoUsd
                dr(4) = txtTipoCambio.Value
                sumatoriaMN = CDec(i.montoUsd * txtTipoCambio.Value).ToString("N2")
                sumatoriaME = CDec(i.montoUsd).ToString("N2")
                dr(5) = sumatoriaMN
                dr(6) = sumatoriaME
                DifsumatoriaMN = CDec((txtTipoCambio.Value - i.diferTipoCambio) * i.montoUsd).ToString("N2")
                DifsumatoriaME = CDec(i.montoUsd - sumatoriaME).ToString("N2")
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



    End Sub


    Private Sub DockingInicio()


        dockingManager1.DockControlInAutoHideMode(PopupControlContainer2, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 250)
        'Me.DockingClientPanel1.AutoScroll = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(PopupControlContainer2, "Diferencia T/C")

        dockingManager1.DockControlInAutoHideMode(PopupControlContainer3, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 250)
        'Me.DockingClientPanel1.AutoScroll = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(PopupControlContainer3, "Diferencia Pagos")
        'dockingManager1.CloseEnabled = False

    End Sub

    Public Sub CargarEntidadesXtipo()
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        Dim sumatoria As Decimal
        Try

            Select Case cboMoneda.SelectedValue
                Case 1
                    If (txtImporteCompramn.Value <= nudDeudaPendientemn.Value) Then
                        'lsvProveedor.Items.Clear()
                        'lsvProveedor.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
                        'lsvProveedor.Columns.Add("T/C", 40, HorizontalAlignment.Left) '1
                        'lsvProveedor.Columns.Add("Importe ME", 70, HorizontalAlignment.Left) '1
                        'lsvProveedor.Columns.Add("Importe MN", 70, HorizontalAlignment.Left) '1

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteCompramn.Value, cboDepositoHijo.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(i.diferTipoCambio)
                            n.SubItems.Add(i.montoUsd)
                            n.SubItems.Add(i.montoSoles)
                            'lsvProveedor.Items.Add(n)
                            sumatoria = CDec(i.montoUsd / i.diferTipoCambio).ToString("N2")
                        Next
                        txtImporteComprame.Value = sumatoria
                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual! "
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteCompramn.Value = 0.0
                        txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                    End If
                Case 2
                    If (txtImporteComprame.Value <= nudDeudaPendienteme.Value) Then
                        'lsvProveedor.Items.Clear()
                        'lsvProveedor.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
                        'lsvProveedor.Columns.Add("T/C", 40, HorizontalAlignment.Left) '1
                        'lsvProveedor.Columns.Add("Importe ME", 70, HorizontalAlignment.Left) '1
                        'lsvProveedor.Columns.Add("Importe MN", 70, HorizontalAlignment.Left) '1

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(i.diferTipoCambio)
                            n.SubItems.Add(i.montoUsd)
                            n.SubItems.Add(i.montoSoles)
                            'lsvProveedor.Items.Add(n)
                            sumatoria += i.montoSoles
                        Next


                        If (txtImporteComprame.Value > 0 And txtTipoCambio.Value > 0) Then
                            txtImporteCompramn.Value = CDec(txtImporteComprame.Value * txtTipoCambio.Value)
                        End If


                        'txtFondoMNDestino.Value = txtSaldoMN.Value
                        'txtFondoMEDestino.Value = txtFondoME.Value
                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteComprame.Value = 0.0
                        txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                        txtTipoCambio.Value = 0.0
                        txtImporteCompramn.Value = 0.0
                        txtDiferenciaMontos.Value = 0.0
                    End If
            End Select



        Catch ex As Exception

        End Try
    End Sub


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
    '                    End With
    '                Case "M"

    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

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

    Public Sub ObtenerSaldoAnticipo(idanticipo As Integer)
        Dim DocumentoAnticipoSL As New documentoAnticipo

        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim saldo As Decimal = CDec(0.0)
        Dim saldome As Decimal = CDec(0.0)

        DocumentoAnticipoSL = documentoAnticipoSA.SaldoAnticipo(idanticipo)


        saldo = DocumentoAnticipoSL.MontoDeudaSoles - DocumentoAnticipoSL.MontoPagadoSoles
        saldome = DocumentoAnticipoSL.MontoDeudaUSD - DocumentoAnticipoSL.MontoPagadoUSD
        lblDeudaPendiente.Text = saldo
        lblDeudaPendienteme.Text = saldome
        lblTipoCambio.Text = DocumentoAnticipoSL.TipoCambio

        'For Each i As documentoAnticipo In documentoAnticipoSA.SaldoAnticipo(idanticipo)
        '    Dim dr As DataRow = dt.NewRow()
        '    'str = Nothing
        '    'str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")

        '    Dim deuda As Decimal
        '    deuda = CDec(0)
        '    deuda = i.MontoDeudaSoles - i.MontoPagadoSoles

        '    If deuda > 0 Then

        '        dr(0) = i.idDocumento
        '        dr(1) = i.numeroDoc
        '        dr(2) = i.tipoAnticipo
        '        dr(3) = i.razonSocial
        '        dr(4) = i.TipoCambio
        '        dr(5) = i.MontoDeudaSoles
        '        dr(6) = i.MontoPagadoSoles
        '        dr(7) = i.MontoDeudaSoles - i.MontoPagadoSoles
        '        dr(8) = i.MontoDeudaUSD - i.MontoPagadoUSD
        '        dr(9) = CDec(0.0)
        '        dt.Rows.Add(dr)
        '    End If


        'Next
        'dgvAnticipos.DataSource = dt

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


    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros

        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)
        estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(idCaja, txtFechaTrans.Value)
        If (Not IsNothing(estadoBL)) Then
            cboMoneda.SelectedValue = estadoBL.codigo
            txtCuentaOrigen.Text = estadoBL.cuenta
            nudDeudaPendienteme.Value = estadoSaldoBL.importeBalanceME
            nudDeudaPendientemn.Value = estadoSaldoBL.importeBalanceMN

            Select Case cboMoneda.SelectedValue
                Case 1
                    pnNacional.Location = New Point(53, 22)
                    pnExtranjero.Location = New Point(400, 22)
                    pnTipoCambio.Location = New Point(275, 22)
                    pnExtranjero.Visible = True
                    pnTipoCambio.Visible = True
                    pnNacional.Visible = True
                    'pnSaldoTotal.Visible = False
                    pnImpMEDisp.Location = New Point(170, 21)
                    pnImpMNDisp.Location = New Point(9, 21)
                    pnExtranjero.Enabled = False
                    pnNacional.Enabled = True
                    pnDiferencia.Visible = False
                    pnTipoCambio.Enabled = False
                    txtTipoCambio.Value = TmpTipoCambio
                Case 2
                    pnDiferencia.Visible = True
                    pnImpMEDisp.Location = New Point(9, 21)
                    pnImpMNDisp.Location = New Point(170, 21)
                    pnExtranjero.Visible = True
                    pnTipoCambio.Visible = True
                    pnNacional.Location = New Point(400, 22)
                    pnExtranjero.Location = New Point(53, 22)
                    pnTipoCambio.Location = New Point(275, 22)
                    pnNacional.Visible = True
                    pnExtranjero.Enabled = True
                    pnNacional.Enabled = False
                    pnTipoCambio.Enabled = True

            End Select



        End If
    End Sub

    'Private Sub cargarDatosCuenta(idCaja As Integer)
    '    Dim estadoSA As New EstadosFinancierosSA
    '    Dim estadoBL As New estadosFinancieros
    '    Dim estadoSaldoBL As New estadosFinancieros

    '    estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
    '    estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(cboDepositoHijo.SelectedValue)
    '    If (Not IsNothing(estadoBL)) Then
    '        cboMoneda.SelectedValue = estadoBL.codigo
    '        txtCuentaOrigen.Text = estadoBL.cuenta
    '        nudDeudaPendienteme.Value = estadoSaldoBL.importeBalanceME
    '        nudDeudaPendientemn.Value = estadoSaldoBL.importeBalanceMN
    '        Select Case cboMoneda.SelectedValue
    '            Case 1
    '                'pnNacional.Location = New Point(49, 25)
    '                'pnExtranjero.Location = New Point(420, 25)
    '                'pnImpMEDisp.Location = New Point(170, 21)
    '                'pnImpMNDisp.Location = New Point(9, 21)
    '                'txtImporteComprame.Enabled = False
    '                'txtImporteCompramn.Enabled = True
    '                'PictureBox5.Visible = False
    '                '' pnDiferencia.Visible = False
    '                'txtImporteCompramn.Value = 0.0
    '                'txtImporteComprame.Value = 0.0
    '                'txtTipoCambio.Value = 0
    '                ''txtDiferenciaMontos.Value = 0

    '                pnNacional.Location = New Point(53, 22)
    '                pnExtranjero.Location = New Point(400, 22)
    '                pnTipoCambio.Location = New Point(275, 22)
    '                pnExtranjero.Visible = True
    '                pnTipoCambio.Visible = True
    '                pnNacional.Visible = True
    '                'pnSaldoTotal.Visible = False
    '                pnImpMEDisp.Location = New Point(170, 21)
    '                pnImpMNDisp.Location = New Point(9, 21)
    '                pnExtranjero.Enabled = False
    '                pnNacional.Enabled = True
    '                pnDiferencia.Visible = False
    '                pnTipoCambio.Enabled = False
    '                txtTipoCambio.Value = TmpTipoCambio


    '                'Select Case tb19.ToggleState
    '                '    Case ToggleButton2.ToggleButtonState.OFF 'dolares
    '                '        pnTipoCambio.Visible = True
    '                '        pnExtranjero.Visible = True
    '                '        'pnDiferencia.Visible = True
    '                '        'pnDiferencia.Location = New Point(650, 25)
    '                '        pnTipoCambio.Enabled = True
    '                '    Case ToggleButton2.ToggleButtonState.ON 'soles
    '                '        pnTipoCambio.Visible = True
    '                '        pnExtranjero.Visible = True
    '                '        ' pnDiferencia.Visible = False
    '                '        pnTipoCambio.Enabled = False
    '                '        txtTipoCambio.Value = lblTipoCambio.Text
    '                'End Select

    '            Case 2

    '                pnNacional.Location = New Point(53, 22)
    '                pnExtranjero.Location = New Point(400, 22)
    '                pnTipoCambio.Location = New Point(275, 22)
    '                pnExtranjero.Visible = True
    '                pnTipoCambio.Visible = True
    '                pnNacional.Visible = True
    '                'pnSaldoTotal.Visible = False
    '                pnImpMEDisp.Location = New Point(170, 21)
    '                pnImpMNDisp.Location = New Point(9, 21)
    '                pnExtranjero.Enabled = False
    '                pnNacional.Enabled = True
    '                pnDiferencia.Visible = False
    '                pnTipoCambio.Enabled = False
    '                txtTipoCambio.Value = TmpTipoCambio


    '                'pnExtranjero.Location = New Point(49, 25)
    '                'pnImpMEDisp.Location = New Point(9, 21)
    '                'pnImpMNDisp.Location = New Point(170, 21)
    '                'txtImporteComprame.Enabled = True
    '                'txtImporteCompramn.Enabled = False
    '                'PictureBox5.Visible = True
    '                ''pnDiferencia.Visible = True
    '                'txtImporteCompramn.Value = 0.0
    '                'txtImporteComprame.Value = 0.0
    '                'txtTipoCambio.Value = 0

    '                'txtDiferenciaMontos.Value = 0
    '                'Select Case tb19.ToggleState
    '                '    Case ToggleButton2.ToggleButtonState.OFF 'dolares
    '                '        pnTipoCambio.Visible = True
    '                '        pnExtranjero.Visible = True
    '                '        'pnDiferencia.Visible = True
    '                '        pnExtranjero.Enabled = True
    '                '        pnNacional.Location = New Point(430, 25)
    '                '        'pnDiferencia.Location = New Point(650, 25)
    '                '        txtTipoCambio.Value = lblTipoCambio.Text
    '                '        pnTipoCambio.Enabled = False
    '                '    Case ToggleButton2.ToggleButtonState.ON 'soles
    '                '        pnTipoCambio.Visible = True
    '                '        pnExtranjero.Visible = True
    '                '        'pnDiferencia.Visible = True
    '                '        pnNacional.Location = New Point(430, 25)
    '                '        'pnDiferencia.Location = New Point(650, 25)
    '                '        txtTipoCambio.Value = 0.0
    '                '        pnTipoCambio.Enabled = True
    '                'End Select
    '        End Select
    '    End If
    'End Sub

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



    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
    End Sub

    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        cbotipoOperacion.ValueMember = "codigoDetalle"
        cbotipoOperacion.DisplayMember = "descripcion"
        cbotipoOperacion.DataSource = tablaSA.GetListaTablaDetalle(12, "1")
        cbotipoOperacion.SelectedValue = -1

        cboEntidades.ValueMember = "codigoDetalle"
        cboEntidades.DisplayMember = "descripcion"
        cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
    End Sub





    Sub CalculoSoles()
        If cboMoneda.SelectedValue = 1 Then

            If CDec(txtImporteComprame.Value) > CDec(lblDeudaPendienteme.Text) Then
                MsgBox("El valor ingreso excede el valor permitido.", MsgBoxStyle.Information, String.Concat("Monto permitido ($.):", Space(2), lblDeudaPendienteme.Text))
                txtTipoCambio.Value = 0
                txtImporteCompramn.Value = 0
                txtImporteComprame.Value = 0
                Exit Sub

            End If
        End If
    End Sub

    Sub CalculoDolares()
        If cboMoneda.SelectedValue = 2 Then
            If txtTipoCambio.Value > 0 Then
                If CDec(txtImporteCompramn.Value) > CDec(lblDeudaPendiente.Text) Then
                    MsgBox("El valor ingreso excede el valor permitido.", MsgBoxStyle.Information, String.Concat("Monto permitido (S/.):", Space(2), lblDeudaPendiente.Text))
                    txtImporteCompramn.Value = 0
                    txtImporteComprame.Value = 0
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

    'Function asientoCaja(monedaExtrajera As Decimal, MontoMonedaExt As Decimal, MontoSoles As Decimal) As asiento
    '    Dim cuentaFinacieraSA As New EstadosFinancierosSA
    '    Dim nAsiento As New asiento
    '    Dim nDebe As New movimiento
    '    Dim nHaber As New movimiento
    '    Dim sumNegaticoCaja As Decimal
    '    Dim sumPositivoCaja As Decimal

    '    nAsiento = New asiento
    '    nAsiento.idDocumento = 0
    '    nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
    '    nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
    '    nAsiento.idEntidad = lblIdProveedor
    '    nAsiento.nombreEntidad = lblNomProveedor
    '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
    '    nAsiento.fechaProceso = txtFechaTrans.Value
    '    nAsiento.codigoLibro = "1"
    '    nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
    '    nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
    '    nAsiento.importeMN = txtImporteCompramn.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
    '    nAsiento.importeME = txtImporteComprame.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
    '    nAsiento.glosa = Glosa()
    '    nAsiento.usuarioActualizacion = usuario.IDUsuario
    '    nAsiento.fechaActualizacion = DateTime.Now

    '    For Each i As DataGridViewRow In dgvDetalleItems.Rows
    '        If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then

    '            Select Case cboMoneda.SelectedValue
    '                Case 1
    '                    If (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
    '                        nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        For Each r As Record In dgvDiferencia.Table.Records
    '                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
    '                                sumPositivoCaja += (CDec(r.GetValue("difMNCajaMN")))
    '                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(0.0, sumPositivoCaja, ASIENTO_CONTABLE.UBICACION.DEBE, lblCuentaProveedor, lblNomProveedor))
    '                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumPositivoCaja, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
    '                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
    '                                sumNegaticoCaja += (CDec(r.GetValue("difMNCajaMN") * -1))
    '                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumNegaticoCaja, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
    '                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(0.0, sumNegaticoCaja, ASIENTO_CONTABLE.UBICACION.HABER, lblCuentaProveedor, lblNomProveedor))
    '                            End If
    '                        Next
    '                    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
    '                        nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                    End If
    '                Case 2

    '                    If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
    '                        nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        For Each r As Record In dgvDiferencia.Table.Records
    '                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
    '                                sumPositivoCaja += (CDec(r.GetValue("difMNCajaMN")))
    '                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(0.0, sumPositivoCaja, ASIENTO_CONTABLE.UBICACION.DEBE, txtCuentaOrigen.Text, cboDepositoHijo.Text))
    '                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumPositivoCaja, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
    '                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
    '                                sumNegaticoCaja += (CDec(r.GetValue("difMNCajaMN") * -1))
    '                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumNegaticoCaja, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
    '                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(0.0, sumNegaticoCaja, ASIENTO_CONTABLE.UBICACION.HABER, txtCuentaOrigen.Text, cboDepositoHijo.Text))
    '                            End If
    '                        Next

    '                    ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
    '                        nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        For Each r As Record In dgvDiferencia.Table.Records
    '                            If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
    '                                sumPositivoCaja += (CDec(r.GetValue("difMNCajaMN")))
    '                                'cuentas Maykol de tratamiento de caja
    '                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(0.0, sumPositivoCaja, ASIENTO_CONTABLE.UBICACION.DEBE, txtCuentaOrigen.Text, cboDepositoHijo.Text))
    '                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumPositivoCaja, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
    '                            ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
    '                                sumNegaticoCaja += (CDec(r.GetValue("difMNCajaMN") * -1))
    '                                nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumNegaticoCaja, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
    '                                nAsiento.movimiento.Add(AS_HaberCajaDiferencia(0.0, sumNegaticoCaja, ASIENTO_CONTABLE.UBICACION.HABER, txtCuentaOrigen.Text, cboDepositoHijo.Text))
    '                            End If
    '                        Next
    '                    End If


    '            End Select
    '        End If
    '    Next
    '    Return nAsiento
    'End Function

    Public Sub Grabar()
        Dim DocCaja As New documento
        Dim documentoSA As New DocumentoSA
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim ndocumento As New documento
        Dim ndocumentoAnticipo As New documentoAnticipo
        Dim ndocumentoAnticipoDetalle As New documentoAnticipoDetalle
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        ListaAsientonTransito = New List(Of asiento)
        Dim ListaDetalle As New List(Of documentoAnticipoDetalle)
        Dim idNumeracion As Integer

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9901"
            .fechaProceso = DateTime.Now
            idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = idNumeracion
            .idOrden = Nothing
            .tipoOperacion = "104"
            .usuarioActualizacion = cboDepositoHijo.SelectedValue
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoAnticipo

            .codigoLibro = "1"
            .fechaPeriodo = PeriodoGeneral
            '   .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .movimiento = "DC"
            .tipoDocumento = "9901"
            .fechaDoc = DateTime.Now
            .tipoOperacion = "104"
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .numeroDoc = .IdNumeracion
            .Moneda = "1"
            .TipoCambio = txtTipoCambio.Value
            .importeMN = txtImporteCompramn.Value
            .importeME = txtImporteComprame.Value
            '.glosa = Glosa()
            .usuarioModificacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .codigoProveedor = CInt(txtProveedor.Tag)
        End With
        ndocumento.documentoAnticipo = ndocumentoAnticipo

        With ndocumentoAnticipoDetalle
           
            .fecha = txtFechaTrans.Value
            .idAnticipo = lblanticipo.Text
            .DetalleItem = "DEVOLUCION"
            .importeMN = CDec(txtImporteCompramn.Value)
            .montoSolesRef = CDec(txtImporteCompramn.Value)
            .importeME = CDec(txtImporteComprame.Value)
            .montoUsdRef = CDec(txtImporteComprame.Value)
            .entregado = "SI"
            .diferTipoCambio = txtTipoCambio.Value
            .estadoAnticipo = "0"
            '.documentoAfectado = lblIdDocumento.Text
            .usuarioModificacion = usuario.IDUsuario
            .fechaActualizacion = Date.Now
            ' .documentoAfectadodetalle = CDec(i.GetValue("iddocumentodet"))
        End With
        ListaDetalle.Add(ndocumentoAnticipoDetalle)
        'ListaAsientonTransito.Add(GeneraraAsiento)
        'ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentoAnticipo.documentoAnticipoDetalle = ListaDetalle
        DocCaja = ComprobanteCaja()

        documentoAnticipoSA.SaveAnticipoDevolucion(ndocumento, DocCaja)
        lblEstado.Text = "Caja registrada correctamente!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        '    lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub


    Function ComprobanteCaja() As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)


        ef = efSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)

        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If

        nDocumentoCaja.fechaProceso = DateTime.Now
        nDocumentoCaja.tipoDoc = "9901"
        nDocumentoCaja.nroDoc = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = cbotipoOperacion.SelectedValue
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        'objCaja.fechaProceso = txtfe.Value
        'objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = "PG"
        objCaja.IdProveedor = CInt(txtProveedor.Tag)
        objCaja.codigoLibro = "104"
        objCaja.codigoProveedor = CInt(txtProveedor.Tag)
        objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
        objCaja.tipoDocPago = cboTipoDoc.SelectedValue
        objCaja.periodo = PeriodoGeneral
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2") ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        'objCaja.tipoCambio = txtTipoCambio.Value
        'objCaja.montoSoles = CDec(nudMonedaNacional.Value)
        'objCaja.montoUsd = CDec(nudMonedaExtranjero.Value)
        If (txtDescripcion.Text.Length > 0) Then
            objCaja.glosa = txtDescripcion.Text
        Else
            objCaja.glosa = Glosa()
        End If

        If cboTipoDoc.SelectedValue = "001" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = cboEntidades.SelectedValue
            objCaja.fechaProceso = DateTime.Now
            objCaja.fechaCobro = Date.Now
            objCaja.entregado = "SI"

        ElseIf cboTipoDoc.SelectedValue = "007" Then ' cheques
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaProceso = txtFechaEmision.Value
            objCaja.fechaCobro = txtFechaCobro.Value
            objCaja.entregado = "NO"
        ElseIf cboTipoDoc.SelectedValue = "111" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaProceso = txtFechaEmision.Value
            objCaja.fechaCobro = txtFechaCobro.Value
            objCaja.entregado = "NO"
        ElseIf cboTipoDoc.SelectedValue = "109" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaCobro = DateTime.Now
            objCaja.fechaProceso = Date.Now
            objCaja.entregado = "NO"
        End If
        objCaja.tipoCambio = txtTipoCambio.Value
        objCaja.montoSoles = txtImporteCompramn.Value
        objCaja.montoUsd = txtImporteComprame.Value
       
        'objCaja.glosa = Glosa()
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        'End With

        objCaja.tipoOperacion = "AR"
        objCaja.entidadFinanciera = cboDepositoHijo.SelectedValue
        objCaja.usuarioModificacion = cboDepositoHijo.SelectedValue
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja


        Select Case cboMoneda.SelectedValue
            Case 1
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = DateTime.Now
                objCajaDetalle.idItem = Nothing
                objCajaDetalle.DetalleItem = Nothing
                objCajaDetalle.montoSoles = CDec(txtImporteCompramn.Value) 'CDec(txtTotalmn.Text)
                objCajaDetalle.montoUsd = CDec(txtImporteComprame.Value) ' CDec(txtTotalme.Text)
                objCajaDetalle.entregado = "SI"
                objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
                objCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                objCajaDetalle.moneda = cboMoneda.SelectedValue
                objCajaDetalle.usuarioModificacion = cboDepositoHijo.SelectedValue
                objCajaDetalle.fechaModificacion = DateTime.Now
                ListaDetalle.Add(objCajaDetalle)
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle

            Case 2
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = DateTime.Now
                objCajaDetalle.idItem = Nothing
                objCajaDetalle.DetalleItem = Nothing
                objCajaDetalle.montoSoles = CDec(txtImporteCompramn.Value) 'CDec(txtTotalmn.Text)
                objCajaDetalle.montoUsd = CDec(txtImporteComprame.Value) ' CDec(txtTotalme.Text)
                objCajaDetalle.entregado = "SI"
                objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
                objCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                objCajaDetalle.usuarioModificacion = cboDepositoHijo.SelectedValue
                objCajaDetalle.fechaModificacion = DateTime.Now
                ListaDetalle.Add(objCajaDetalle)
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle
            Case 2
        End Select
        '   nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)
        Return nDocumentoCaja
    End Function


    Function Glosa() As String
        Dim strGlosa As String = Nothing

        'With frmCuentasPorPagar
        strGlosa = "Por pagos con comprobante, en " & cboTipoDoc.Text & " con fecha: " & txtFechaTrans.Value

        'End With
        Return strGlosa
    End Function
#End Region

    Private Sub frmAnticipoRecibidoDevolucion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub frmAnticipoRecibidoDevolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dispose()
    End Sub

    Private Sub cboEntidades_KeyDown(sender As Object, e As KeyEventArgs) Handles cboEntidades.KeyDown
        e.Handled = True
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.pcEntidad.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Me.pcEntidad.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcEntidad_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcEntidad.BeforePopup
        Me.pcEntidad.BackColor = Color.White
    End Sub

    Private Sub pcEntidad_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcEntidad.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.cboEntidades.Focus()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.pcEntidad.Font = New Font("Tahoma", 8)
        Me.pcEntidad.Size = New Size(212, 139)
        Me.pcEntidad.ParentControl = Me.cboEntidades
        Me.pcEntidad.ShowPopup(Point.Empty)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor

        txtImporteComprame.Value = 0
        txtImporteCompramn.Value = 0
        txtTipoCambio.Value = 0
        'txtDiferenciaMontos.Value = 0
        txtNumOper.Clear()
        cboDepositoHijo.SelectedValue = -1
        cboMoneda.SelectedValue = -1
        txtCuentaCorriente.Clear()
        nudDeudaPendienteme.Value = 0
        nudDeudaPendientemn.Value = 0
        cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim value As Object = Me.cboDepositoHijo.SelectedValue

    '    txtImporteComprame.Value = 0
    '    txtImporteCompramn.Value = 0
    '    txtTipoCambio.Value = 0
    '    'txtDiferenciaMontos.Value = 0
    '    txtNumOper.Clear()
    '    cboMoneda.SelectedValue = -1
    '    txtCuentaCorriente.Clear()
    '    nudDeudaPendienteme.Value = 0
    '    nudDeudaPendientemn.Value = 0

    '    If IsNumeric(value) Then
    '        cargarDatosCuenta(CInt(value))
    '    Else
    '        'txtFondoEF.DecimalValue = 0
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Function GetSaldoEF() As GFichaUsuario
        Dim EFSA As New EstadosFinancierosSA
        Dim EF As New estadosFinancieros
        Dim gficha As New GFichaUsuario

        EF = EFSA.GetEstadoSaldoEF(New estadosFinancieros With {.idestado = cboDepositoHijo.SelectedValue})
        gficha.SaldoMN = EF.importeBalanceMN
        gficha.SaldoME = EF.importeBalanceME
        Return gficha

    End Function


    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
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
                            txtImporteCompramn.Select()
                            txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                        Case 2
                            txtImporteComprame.Select()
                            txtImporteComprame.Select(0, txtImporteCompramn.Text.Length)
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
                Me.txtTipoCambio.Value = lsvTipoCambio.SelectedItems(0).SubItems(1).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            'Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub


    
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
            Exit Sub
            MessageBox.Show("Escriba una Cuenta Corriente")
        End If

        If Not txtNumOper.Text.Trim.Length > 0 Then
            Exit Sub
            MessageBox.Show("Escriba un numero de operacion")
        End If

        If Not cbotipoOperacion.Text.Trim.Length > 0 Then
            Exit Sub
            MessageBox.Show("Seleccione un Tipo de operacion")
        End If

        If Not CDec(lblDeudaPendiente.Text) >= txtImporteCompramn.Value Then
            Exit Sub
            MessageBox.Show("El monto a devolver no debe ser mayor al Saldo")
        End If
        Grabar()
    End Sub




    Private Sub txtImporteCompramn_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteCompramn.ValueChanged


        'Dim tc As Decimal = CDec(0.0)
        'tc = CDec(lblTipoCambio.Text)
        'txtImporteComprame.Value = (txtImporteCompramn.Value / tc)

        If (cboDepositoHijo.SelectedValue > 0) Then
            CargarEntidadesXtipo()
        Else
            lblEstado.Text = "Debe ingresar una cuenta destino!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If


    End Sub

    'Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click
    '    cboDepositoHijo.Tag = 1
    'End Sub

    

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        If (cboDepositoHijo.SelectedValue > -1) Then
            Select Case cboMoneda.SelectedValue
                Case 2
                    txtImporteComprame_ValueChanged(sender, e)
            End Select

        End If
    End Sub

    Private Sub txtImporteComprame_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteComprame.ValueChanged
        If (cboDepositoHijo.SelectedValue > 0) Then
            CargarEntidadesXtipo()
            If (txtImporteComprame.Value > 0) Then
                CargarTiposDeCambio()
            End If
            If (txtImporteComprame.Value > 0 And txtTipoCambio.Value > 0) Then
                CargarDiferenciasdeImporte()
            End If
        Else
            lblEstado.Text = "Debe ingresar una cuenta destino!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click
        cboDepositoHijo.Tag = 1
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Dim value As Object = Me.cboDepositoHijo.SelectedValue
        txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        txtImporteCompramn.Value = 0
        txtImporteComprame.Value = 0
        'txtProveedor.Clear()
        'txtRuc.Clear()
        'txtDescripcion.Clear()
        'txtNumOper.Clear()

        If (cboDepositoHijo.Tag = 1) Then
            If IsNumeric(value) Then
                cargarDatosCuenta(CInt(value))
            Else
                'txtFondoEF.DecimalValue = 0
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class