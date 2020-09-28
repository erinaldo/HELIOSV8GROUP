Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmModalAnticipoOtor

#Region "Attributes"
    Inherits frmMaster
    Public ManipulacionEstado As String
    Public Property ListaAsientonTransito As New List(Of asiento)

#End Region

#Region "Constructors"
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "ANT", "ANTICIPOS", GEstableciento.IdEstablecimiento)
        ObtenerTablaGenerales()
        txtFechaComprobante.Value = Date.Now
        DockingInicio()
    End Sub
#End Region

#Region "Methods"
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

    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        cboEntidad.ValueMember = "codigoDetalle"
        cboEntidad.DisplayMember = "descripcion"
        cboEntidad.DataSource = tablaSA.GetListaTablaDetalle(3, "1")

        cbotipoOperacion.ValueMember = "codigoDetalle"
        cbotipoOperacion.DisplayMember = "descripcion"
        cbotipoOperacion.DataSource = tablaSA.GetListaTablaDetalleMotivo(12, "1", "104")
        'cbotipoOperacion.SelectedValue = -1


        cboMonedaCuenta.ValueMember = "codigoDetalle"
        cboMonedaCuenta.DisplayMember = "descripcion"
        cboMonedaCuenta.DataSource = tablaSA.GetListaTablaDetalle(4, "1")
        cboMonedaCuenta.SelectedValue = -1

    End Sub

    Private Sub cargarCtasFinan()
        If cboTipoCuenta.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")

            ListaDocPago(lista)
        ElseIf cboTipoCuenta.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")
            'lista.Add("005")
            'lista.Add("006")
            ListaDocPago(lista)

        ElseIf cboTipoCuenta.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo("TC")
            Dim lista As New List(Of String)
            lista.Add("001")

            ListaDocPago(lista)
        End If
    End Sub

    Public Sub ListaDocPago(listaCuenta As List(Of String))
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)

        tabla = tablaSA.GetListaTablaDetalle(1, "1")
        tabla = (From n In tabla _
                     Where listaCuenta.Contains(n.codigoDetalle) _
                    Select n).ToList
        cboTipoDocumento.DataSource = tabla
        cboTipoDocumento.ValueMember = "codigoDetalle"
        cboTipoDocumento.DisplayMember = "descripcion"
        cboTipoDocumento.SelectedValue = "001"
        'CargarDAtos()GR
    End Sub

    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros

        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)
        estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(idCaja, txtFechaComprobante.Value)
        If (Not IsNothing(estadoBL)) Then
            cboMonedaCuenta.SelectedValue = estadoBL.codigo
            txtCuentaOrigen.Text = estadoBL.cuenta
            lblDeudaPendienteme.Value = estadoSaldoBL.importeBalanceME
            lblDeudaPendientemn.Value = estadoSaldoBL.importeBalanceMN

            GroupBox5.Visible = True
            Select Case cboMonedaCuenta.SelectedValue
                Case 1
                    pnNacional.Location = New Point(53, 22)
                    pnExtranjero.Location = New Point(400, 22)
                    pnTipoCambio.Location = New Point(275, 22)
                    pnExtranjero.Visible = True
                    pnTipoCambio.Visible = True
                    pnNacional.Visible = True
                    pnImpMNDisp.Visible = True
                    pnImpMEDisp.Visible = False
                    'pnSaldoTotal.Visible = False
                    pnImpMEDisp.Location = New Point(170, 21)
                    pnImpMNDisp.Location = New Point(9, 21)
                    pnExtranjero.Enabled = False
                    pnNacional.Enabled = True
                    pnDiferencia.Visible = False
                    pnTipoCambio.Enabled = False
                    txtTipoCambio.Value = TmpTipoCambio
                    pnAODet.Enabled = True
                Case 2
                    pnDiferencia.Visible = True
                    pnImpMEDisp.Location = New Point(9, 21)
                    pnImpMNDisp.Location = New Point(170, 21)
                    pnExtranjero.Visible = True
                    pnTipoCambio.Visible = True
                    pnImpMNDisp.Visible = False
                    pnImpMEDisp.Visible = True
                    pnNacional.Location = New Point(400, 22)
                    pnExtranjero.Location = New Point(53, 22)
                    pnTipoCambio.Location = New Point(275, 22)
                    pnNacional.Visible = True
                    txtTipoCambio.Value = TmpTipoCambioTransaccionVenta
                    pnExtranjero.Enabled = True
                    pnNacional.Enabled = False
                    pnTipoCambio.Enabled = True
                    pnAODet.Enabled = True
            End Select



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
            cboDepositoHijo.Tag = 0

            cboMonedaCuenta.SelectedValue = -1

        Catch ex As Exception

        End Try
    End Sub

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

    Sub calculos()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value

        Select Case cboMonedaCuenta.SelectedValue
            Case 1
                If (txtImporteCompramn.Value <= lblDeudaPendientemn.Value) Then
                    If tcambio > 0 Then
                        Imn = txtImporteCompramn.Value
                        txtImporteComprame.Value = Math.Round(Imn / tcambio, 2)
                    End If
                Else
                    lblEstado.Text = "Debe ingresar un importe menor o igual!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtImporteCompramn.Value = 0.0
                    txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                End If
            Case 2
                If (txtImporteComprame.Value <= lblDeudaPendienteme.Value) Then
                    If tcambio > 0 Then
                        Imn = txtImporteCompramn.Value
                        txtImporteComprame.Value = Math.Round(Imn / tcambio, 2)
                    End If
                Else
                    lblEstado.Text = "Debe ingresar un importe menor o igual!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtImporteComprame.Value = 0.0
                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                End If
        End Select


    End Sub

    Sub CalculoDolares()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value

        Select Case cboMonedaCuenta.SelectedValue
            Case 1
                If (txtImporteCompramn.Value <= lblDeudaPendientemn.Value) Then
                    If tcambio > 0 Then
                        Imn = txtImporteComprame.Value
                        txtImporteCompramn.Value = Math.Round(Imn * tcambio, 2)
                    End If
                Else
                    lblEstado.Text = "Debe ingresar un importe menor o igual!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtImporteCompramn.Value = 0.0
                    txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                End If
            Case 2
                If (txtImporteComprame.Value <= lblDeudaPendienteme.Value) Then
                    If tcambio > 0 Then
                        Imn = txtImporteComprame.Value
                        txtImporteCompramn.Value = Math.Round(Imn * tcambio, 2)
                    End If
                Else
                    lblEstado.Text = "Debe ingresar un importe menor o igual!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtImporteComprame.Value = 0.0
                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                End If
        End Select


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
    Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        GFichaUsuarios = New GFichaUsuario
        Select Case ManipulacionEstado
            Case ENTITY_ACTIONS.INSERT

                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    With frmFichaUsuarioCaja
                        .txtDni.Enabled = True
                        ModuloAppx = ModuloSistema.CAJA
                        .lblNivel.Text = "Caja"
                        .lblEstadoCaja.Visible = True
                        '   .GroupBox1.Visible = True
                        '   .GroupBox2.Visible = True
                        '   .GroupBox4.Visible = True
                        '   .cboMoneda.Visible = True
                        .Timer1.Enabled = True
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        If IsNothing(GFichaUsuarios.NombrePersona) Then
                            Return False
                        Else
                            Return True
                        End If
                    End With

                End If
            Case ENTITY_ACTIONS.UPDATE
                With frmFichaUsuarioCaja
                    ModuloAppx = ModuloSistema.CAJA
                    .lblNivel.Text = "Caja"
                    .lblEstadoCaja.Visible = True
                    '    .GroupBox1.Visible = True
                    '    .GroupBox2.Visible = True
                    '   .GroupBox4.Visible = True
                    '   .cboMoneda.Visible = True
                    .Timer1.Enabled = False
                    .txtDni.Enabled = False
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .StartPosition = FormStartPosition.CenterParent
                    ' .UbicarUsuarioCaja(intIdDocumento, "ANTICIPOS")
                    .ShowDialog()
                    If IsNothing(GFichaUsuarios.NombrePersona) Then
                        Return False
                    Else
                        Return True
                    End If
                End With

        End Select
        Return True

    End Function
#End Region


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

    '                    'With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                    '    'txtIdEstableAlmacen.Text = .idCentroCosto
    '                    '    'txtEstableAlmacen.Text = .nombre
    '                    'End With
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
            .fechaProceso = txtFechaComprobante.Value
            idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = idNumeracion
            .idOrden = Nothing
            .tipoOperacion = cbotipoOperacion.SelectedValue
            .usuarioActualizacion = cboDepositoHijo.SelectedValue
            .fechaActualizacion = txtFechaComprobante.Value
        End With

        With ndocumentoAnticipo

            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoDocumento = "9901"
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .numeroDoc = idNumeracion
            .fechaDoc = txtFechaComprobante.Value
            .fechaPeriodo = PeriodoGeneral
            .tipoOperacion = cboTipoDocumento.SelectedValue
            .tipoAnticipo = "AO"
            .razonSocial = CInt(txtCliente2.Tag)
            .TipoCambio = txtTipoCambio.Value
            .Moneda = cboMonedaCuenta.SelectedValue
            .importeMN = txtImporteCompramn.Value
            .importeME = txtImporteComprame.Value
            '.idEntidadFinanciera = txtCajaOrigen.ValueMember
            '.idEntidadFinanciera = DirectCast(Me.cboEntidadFinanciera.SelectedItem, Categoria).Id
            .idEntidadFinanciera = cboDepositoHijo.SelectedValue
            .usuarioModificacion = cboDepositoHijo.SelectedValue
            .fechaActualizacion = txtFechaComprobante.Value
        End With
        ndocumento.documentoAnticipo = ndocumentoAnticipo

        With ndocumentoAnticipoDetalle
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .codigoOperacion = "104"
            .descripcion = "Anticipos Otorgados" & idNumeracion
            .importeMN = txtImporteCompramn.Value
            .importeME = txtImporteComprame.Value
            .usuarioModificacion = cboDepositoHijo.SelectedValue
            .fechaActualizacion = txtFechaComprobante.Value
        End With
        ndocumento.documentoAnticipo.documentoAnticipoDetalle.Add(ndocumentoAnticipoDetalle)
        ListaAsientonTransito.Add(GeneraraAsiento)
        ndocumento.asiento = ListaAsientonTransito
        DocCaja = ComprobanteCaja()

        documentoAnticipoSA.SaveAnticipoSL(ndocumento, DocCaja)
        lblEstado.Text = "Caja registrada correctamente!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        '    lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub

    Public Sub UpdateAnticipo()

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

        With ndocumento

            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .idDocumento = lblIdDocumento.Text
            .tipoDoc = "9901"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = 0 ' txtNumeroComp.Text
            .idOrden = Nothing
            .tipoOperacion = "104"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = txtFechaComprobante.Value
        End With

        With ndocumentoAnticipo
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento

            .tipoDocumento = "9901"
            .numeroDoc = IIf(IsNothing(GConfiguracion.ValorActual), 0, GConfiguracion.ValorActual)
            .fechaDoc = txtFechaComprobante.Value
            .fechaPeriodo = PeriodoGeneral
            .tipoOperacion = "104"
            .tipoAnticipo = "AO"
            .razonSocial = CInt(txtCliente2.Tag)
            .TipoCambio = txtTipoCambio.Value
            .Moneda = cboMonedaCuenta.SelectedValue
            .importeMN = txtImporteCompramn.Value
            .importeME = txtImporteComprame.Value
            '.idEntidadFinanciera = txtCajaOrigen.ValueMember
            .idEntidadFinanciera = cboDepositoHijo.SelectedValue
            .usuarioModificacion = cboDepositoHijo.SelectedValue
            .fechaActualizacion = txtFechaComprobante.Value
        End With
        ndocumento.documentoAnticipo = ndocumentoAnticipo

        'With ndocumentoAnticipoDetalle
        '    .idEmpresa = Gempresas.IdEmpresaRuc
        '    .idEstablecimiento = GEstableciento.IdEstablecimiento
        '    .codigoOperacion = "103"
        '    .descripcion = "Voucher contable " & "1"
        '    .importeMN = nudMonedaNacional.Value
        '    .importeME = nudMonedaExtranjero.Value
        '    .usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        '    .fechaActualizacion = Date.Now
        'End With
        'ListaDetalle.Add(ndocumentoAnticipoDetalle)
        'ndocumento.documentoAnticipo.documentoAnticipoDetalle = ListaDetalle

        ListaAsientonTransito.Add(GeneraraAsiento)
        ndocumento.asiento = ListaAsientonTransito
        DocCaja = ComprobanteCaja()

        documentoAnticipoSA.UpdateAnticipoSL(ndocumento, DocCaja)
        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

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

        nDocumentoCaja.fechaProceso = txtFechaComprobante.Value
        nDocumentoCaja.tipoDoc = "9901"
        nDocumentoCaja.nroDoc = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante) ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = cbotipoOperacion.SelectedValue
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        'objCaja.fechaProceso = txtfe.Value
        'objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = MovimientoCaja.SalidaDinero
        objCaja.IdProveedor = CInt(txtCliente2.Tag)
        objCaja.codigoLibro = "1"
        objCaja.codigoProveedor = CInt(txtCliente2.Tag)
        objCaja.TipoDocumentoPago = cboTipoDocumento.SelectedValue
        objCaja.tipoDocPago = cboTipoDocumento.SelectedValue
        objCaja.periodo = PeriodoGeneral
        objCaja.movimientoCaja = "AO"
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = IIf(cboMonedaCuenta.SelectedValue = 1, "1", "2") ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        'objCaja.tipoCambio = txtTipoCambio.Value
        'objCaja.montoSoles = CDec(nudMonedaNacional.Value)
        'objCaja.montoUsd = CDec(nudMonedaExtranjero.Value)

        If (txtDescripcion.Text.Length > 0) Then
            objCaja.glosa = txtDescripcion.Text
        Else
            objCaja.glosa = Glosa()
        End If

        If cboTipoDocumento.SelectedValue = "001" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = txtCuentaCorriente.Text
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = cboEntidad.SelectedValue
            objCaja.fechaProceso = txtFechaComprobante.Value
            objCaja.fechaCobro = Date.Now
            objCaja.entregado = "SI"

        ElseIf cboTipoDocumento.SelectedValue = "007" Then ' cheques
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaProceso = txtFechaEmision.Value
            objCaja.fechaCobro = txtFechaCobro.Value
            objCaja.entregado = "NO"
        ElseIf cboTipoDocumento.SelectedValue = "111" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaProceso = txtFechaEmision.Value
            objCaja.fechaCobro = txtFechaCobro.Value
            objCaja.entregado = "NO"
        ElseIf cboTipoDocumento.SelectedValue = "109" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaCobro = txtFechaComprobante.Value
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

        objCaja.tipoOperacion = "104"
        objCaja.entidadFinanciera = cboDepositoHijo.SelectedValue
        objCaja.usuarioModificacion = cboDepositoHijo.SelectedValue
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja


        Select Case cboMonedaCuenta.SelectedValue
            Case 1
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = txtFechaComprobante.Value
                objCajaDetalle.idItem = Nothing
                objCajaDetalle.DetalleItem = Nothing
                objCajaDetalle.montoSoles = CDec(txtImporteCompramn.Value) 'CDec(txtTotalmn.Text)
                objCajaDetalle.montoUsd = CDec(txtImporteComprame.Value) ' CDec(txtTotalme.Text)
                objCajaDetalle.entregado = "SI"
                objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
                objCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                objCajaDetalle.moneda = cboMonedaCuenta.SelectedValue
                objCajaDetalle.usuarioModificacion = cboDepositoHijo.SelectedValue
                objCajaDetalle.fechaModificacion = DateTime.Now
                ListaDetalle.Add(objCajaDetalle)
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle

            Case 2
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = txtFechaComprobante.Value
                objCajaDetalle.idItem = Nothing
                objCajaDetalle.DetalleItem = Nothing
                objCajaDetalle.montoSoles = CDec(txtImporteCompramn.Value) 'CDec(txtTotalmn.Text)
                objCajaDetalle.montoUsd = CDec(txtImporteComprame.Value) ' CDec(txtTotalme.Text)
                objCajaDetalle.entregado = "SI"
                objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
                objCajaDetalle.moneda = cboMonedaCuenta.SelectedValue
                objCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
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


    Public Function Glosa() As String
        Return "Por voucher contable " & txtCliente2.Text.Trim
    End Function

    Private Function GeneraraAsiento() As asiento
        Dim nAsiento As New asiento
        Dim movimiento As movimiento
        Try
            nAsiento = New asiento
            nAsiento.idDocumento = 0
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = txtCliente2.Tag
            nAsiento.nombreEntidad = txtCliente2.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            nAsiento.fechaProceso = txtFechaComprobante.Value
            nAsiento.codigoLibro = "1"
            nAsiento.periodo = PeriodoGeneral
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Finanzas
            nAsiento.importeMN = txtImporteCompramn.Value
            nAsiento.importeME = txtImporteComprame.Value
            nAsiento.glosa = Glosa()
            nAsiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.fechaActualizacion = DateTime.Now


            movimiento = New movimiento With {
                   .cuenta = "422",
                   .descripcion = "Anticipos por pagar",
                   .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
                   .monto = txtImporteCompramn.Value,
                   .montoUSD = txtImporteComprame.Value,
                   .fechaActualizacion = DateTime.Now,
                   .usuarioActualizacion = usuario.IDUsuario}
            nAsiento.movimiento.Add(movimiento)
            '.cuenta = "122"= txtCuenta.Text,
            movimiento = New movimiento With {
                .cuenta = txtCuentaOrigen.Text,
                .descripcion = cboDepositoHijo.Text,
                .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
                .monto = txtImporteCompramn.Value,
                .montoUSD = txtImporteComprame.Value,
                .fechaActualizacion = DateTime.Now,
                .usuarioActualizacion = usuario.IDUsuario}
            nAsiento.movimiento.Add(movimiento)

        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
        Return nAsiento
    End Function

    'Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)

    '    Dim DocCaja As New documento
    '    Dim documentoSA As New DocumentoSA
    '    Dim documentoAnticipoSA As New documentoAnticipoSA
    '    Dim ndocumento As New documento
    '    Dim ndocumentoAnticipo As New documentoAnticipo
    '    Dim objEntidad As New entidadSA
    '    Dim nEntidad As New entidad

    '    Dim objEntidadFinanciera As New EstadosFinancierosSA
    '    Dim nEntidadfinanciera As New estadosFinancieros


    '    Try
    '        'CABECERA COMPROBANTE
    '        With documentoAnticipoSA.UbicarDocumentoAnticipo(intIdDocumento)
    '            lblIdDocumento.Text = .idDocumento
    '            txtFechaComprobante.Value = .fechaDoc
    '            'txtNumero.Text = .numeroDoc
    '            cboMonedaCuenta.SelectedValue = .Moneda
    '            txtImporteCompramn.Value = .importeMN
    '            txtImporteComprame.Value = .importeME
    '            txtTipoCambio.Value = .TipoCambio

    '            'PROVEEDOR
    '            nEntidad = objEntidad.UbicarEntidadPorID(.razonSocial).First()
    '            txtRuc2.Text = nEntidad.nrodoc
    '            txtCuenta.Text = nEntidad.cuentaAsiento
    '            txtCliente2.Tag = nEntidad.idEntidad
    '            txtCliente2.Text = nEntidad.nombreCompleto

    '            'caja

    '            nEntidadfinanciera = objEntidadFinanciera.GetUbicar_estadosFinancierosPorID(.idEntidadFinanciera)
    '            txtCuentaOrigen.Text = nEntidadfinanciera.cuenta
    '            'txtCajaOrigen.ValueMember = nEntidadfinanciera.idestado
    '            'txtCajaOrigen.Text = nEntidadfinanciera.descripcion

    '        End With

    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try

    'End Sub

    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim alEFSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim establecimientoSA As New establecimientoSA
        Dim entidadsa As New entidadSA
        Try
            With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)

                'Select Case .tipoMovimiento
                '    Case MovimientoCaja.SalidaDinero
                '        lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                '    Case MovimientoCaja.EntradaDinero
                '        lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                'End Select

                lblIdDocumento.Text = .idDocumento
                txtFechaComprobante.Value = .fechaProceso
                Dim codigoDoc = .tipoDocPago

                cboMonedaCuenta.SelectedValue = .moneda



                Dim A As String
                A = 104
                cbotipoOperacion.SelectedValue = A
                Select Case .tipoOperacion
                    Case 17
                        cbotipoOperacion.Text = "APORTES"

                End Select

                Select Case .moneda
                    Case 1
                        cboMonedaCuenta.Text = "NACIONAL"
                    Case 2
                        cboMonedaCuenta.Text = "EXTRANJERO"
                End Select

                With alEFSA.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)
                    'txtEstablecimientoDestino.ValueMember = .idEstablecimiento
                    'txtEstablecimientoDestino.Text = establecimientoSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
                    'txtCajaOrigen.ValueMember = .idestado
                    'txtCajaOrigen.Text = .descripcion
                    Select Case .tipo
                        Case CuentaFinanciera.Banco
                            cboTipoCuenta.Text = "CUENTAS EN BANCO"
                        Case CuentaFinanciera.Efectivo
                            cboTipoCuenta.Text = "CUENTAS EN EFECTIVO"

                        Case CuentaFinanciera.Tarjeta_Credito
                            cboTipoCuenta.Text = "TARJETA DE CREDITO"
                    End Select

                    cboDepositoHijo.SelectedValue = .idestado
                    cargarDatosCuenta(cboDepositoHijo.SelectedValue)

                    txtCuenta.Text = .cuenta

                End With
                cboTipoDocumento.SelectedValue = codigoDoc
                Select Case codigoDoc
                    Case "001"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito

                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                            txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        End If

                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro

                    Case "007" 'cheques

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                            txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                    Case "111"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                            txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro

                    Case "109"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                            txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                End Select

                txtTipoCambio.Value = .tipoCambio
                txtImporteCompramn.Value = .montoSoles
                txtImporteComprame.Value = .montoUsd
                txtDescripcion.Text = .glosa

                With entidadsa.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, "PR", .codigoProveedor)
                    txtCliente2.Text = .nombreCompleto
                    txtRuc2.Text = .nrodoc
                End With

            End With

            'With documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento).First
            '    lblSecuenciaDetalle.Text = .secuencia
            'End With
            ' cboMovimiento.Enabled = False
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

#End Region

#Region "Events"
    Private Sub txtImporteCompramn_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteCompramn.ValueChanged
        Select Case cboMonedaCuenta.SelectedValue
            Case 1
                calculos()
            Case 2
                CalculoDolares()
        End Select
    End Sub

    Private Sub frmModalAnticipoOtor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtImporteCompramn.Select()
        End If
    End Sub

    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _cuenta As String

        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal cuenta As String)
            _name = name
            _id = id
            _cuenta = cuenta
        End Sub
        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property Cuenta() As String
            Get
                Return _cuenta
            End Get
            Set(ByVal value As String)
                _cuenta = value
            End Set
        End Property

    End Class

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs)
        cboDepositoHijo.Tag = 1
    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs)
        txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        txtImporteCompramn.Value = 0
        txtImporteComprame.Value = 0
        txtCliente2.Clear()
        txtRuc2.Clear()
        txtDescripcion.Clear()
        txtNumOper.Clear()
        cargarCtasFinan()
        pnAODet.Enabled = False
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim value As Object = Me.cboDepositoHijo.SelectedValue
        txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        txtImporteCompramn.Value = 0
        txtImporteComprame.Value = 0
        txtCliente2.Clear()
        txtRuc2.Clear()
        txtDescripcion.Clear()
        txtNumOper.Clear()

        If (cboDepositoHijo.Tag = 1) Then
            If IsNumeric(value) Then
                cargarDatosCuenta(CInt(value))
            Else
                'txtFondoEF.DecimalValue = 0
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        If cboTipoDocumento.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDocumento.SelectedValue = "109" Then 'EFECTIVO (que se genere un vocher de caja con los datos del comprobante que se está pagando) 
                pnEntidad.Visible = False
                pnFecha.Visible = False
                Label17.Text = "NRO. VOUCHER:"

            ElseIf cboTipoDocumento.SelectedValue = "007" Then ' CHEQUES
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            ElseIf cboTipoDocumento.SelectedValue = "001" Then ' DEPOSITO EN CUENTA 
                pnEntidad.Visible = True
                pnFecha.Visible = False
                Label17.Text = "NRO. OPERACIÓN:"

            ElseIf cboTipoDocumento.SelectedValue = "111" Then ' CHEQUE NO NEGOCIABLE 
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            End If
        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs)
        Dim documentoCajaSA As New DocumentoCajaSA
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not cboDepositoHijo.Text.Length > 0 Then
                lblEstado.Text = "Ingrese la entidad financiera."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboDepositoHijo.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not cbotipoOperacion.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cbotipoOperacion.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            Select Case cboMonedaCuenta.SelectedValue
                Case 1
                    If Not txtTipoCambio.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If Not txtImporteCompramn.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                Case 2

                    If Not txtImporteComprame.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If Not txtTipoCambio.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

            End Select

            If cboTipoDocumento.SelectedValue = "001" Then
                If Not cboTipoDocumento.Text.Length > 0 Then
                    lblEstado.Text = "Ingrese tipo documento."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    cboTipoDocumento.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

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


            ElseIf cboTipoDocumento.SelectedValue = "007" Then

            ElseIf cboTipoDocumento.SelectedValue = "109" Then
                If Not cboTipoDocumento.Text.Length > 0 Then
                    lblEstado.Text = "Ingrese tipo documento."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    cboTipoDocumento.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

            ElseIf cboTipoDocumento.SelectedValue = "111" Then

            End If

            If Not txtCliente2.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un proveedor."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtRuc2.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un proveedor valido."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If


            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                lblEstado.Text = "Proceso normal"
                '    lblEstado.Image = My.Resources.ok4

                Dim sumatoria As Decimal = documentoCajaSA.BuscarCajaOtrosMovimientosSingleME()
                If CDec(sumatoria >= txtImporteComprame.Value) Then
                    Grabar()
                Else
                    lblEstado.Text = "No debe exceder el monto permitido!" & " " & sumatoria
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtImporteComprame.Value = 0.0
                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                End If

                lblEstado.Image = My.Resources.ok4

                'Grabar()
            Else
                UpdateAnticipo()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
            Me.Cursor = Cursors.Arrow
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub nudMonedaNacional_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteCompramn.ValueChanged
    '    If (cboDepositoHijo.SelectedValue > 0) Then
    '        CargarEntidadesXtipo()
    '    Else
    '        lblEstado.Text = "Debe ingresar una cuenta destino!"
    '        PanelError.Visible = True
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End If
    '    'Select Case cboMonedaCuenta.SelectedValue
    '    '    Case 1
    '    '        calculos()
    '    '    Case 2
    '    '        CalculoDolares()
    '    'End Select
    'End Sub

    'Private Sub nudMonedaExtranjero_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteComprame.ValueChanged
    '    If (cboDepositoHijo.SelectedValue > 0) Then
    '        CargarEntidadesXtipo()
    '        If (txtImporteComprame.Value > 0) Then
    '            CargarTiposDeCambio()
    '        End If
    '        If (txtImporteComprame.Value > 0 And txtTipoCambio.Value > 0) Then
    '            CargarDiferenciasdeImporte()
    '        End If
    '    Else
    '        lblEstado.Text = "Debe ingresar una cuenta destino!"
    '        PanelError.Visible = True
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End If
    'End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
     
        If (cboDepositoHijo.SelectedValue > -1) Then
            Select Case cboMonedaCuenta.SelectedValue
                Case 2
                    'nudMonedaExtranjero_ValueChanged(sender, e)
            End Select

        End If
    End Sub

    Private Sub nudMonedaNacional_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteCompramn.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                If (txtImporteCompramn.Value <= lblDeudaPendientemn.Value And txtImporteCompramn.Value <> 0) Then
                    txtCliente2.Select()
                Else
                    lblEstado.Text = "Debe ingresar un importe menor o igual!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtImporteCompramn.Value = 0.0
                    txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                End If

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'txtImporteCompramn.Clear()
        End Try

    End Sub

    Private Sub nudMonedaExtranjero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteComprame.KeyDown
      
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                If (txtImporteComprame.Value <= lblDeudaPendienteme.Value And txtImporteComprame.Value <> 0) Then
                    txtTipoCambio.Select()
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                Else
                    lblEstado.Text = "Debe ingresar un importe menor o igual!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtImporteComprame.Value = 0.0
                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                End If

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'txtImporteCompramn.Clear()
        End Try

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim documentoCajaSA As New DocumentoCajaSA
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not cboDepositoHijo.Text.Length > 0 Then
                lblEstado.Text = "Ingrese la entidad financiera."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboDepositoHijo.Select()
                Exit Sub
            End If

            If Not cbotipoOperacion.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cbotipoOperacion.Select()
                Exit Sub
            End If
            Select Case cboMonedaCuenta.SelectedValue
                Case 1
                    If Not txtTipoCambio.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Exit Sub
                    End If

                    If Not txtImporteCompramn.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                        Exit Sub
                    End If

                Case 2

                    If Not txtImporteComprame.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                        Exit Sub
                    End If

                    If Not txtTipoCambio.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Exit Sub
                    End If

            End Select

            If cboTipoDocumento.SelectedValue = "001" Then
                If Not cboTipoDocumento.Text.Length > 0 Then
                    lblEstado.Text = "Ingrese tipo documento."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    cboTipoDocumento.Select()
                    Exit Sub
                End If

                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Select()
                    Exit Sub
                End If

                If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de cuenta."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtCuentaCorriente.Select()
                    Exit Sub
                End If


            ElseIf cboTipoDocumento.SelectedValue = "007" Then

            ElseIf cboTipoDocumento.SelectedValue = "109" Then
                If Not cboTipoDocumento.Text.Length > 0 Then
                    lblEstado.Text = "Ingrese tipo documento."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    cboTipoDocumento.Select()
                    Exit Sub
                End If

                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Select()
                    Exit Sub
                End If

            ElseIf cboTipoDocumento.SelectedValue = "111" Then

            End If

            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                lblEstado.Text = "Proceso normal"
                '    lblEstado.Image = My.Resources.ok4

                Dim sumatoria As Decimal = documentoCajaSA.BuscarCajaOtrosMovimientosSingleME()
                If CDec(sumatoria >= txtImporteComprame.Value) Then
                    Grabar()
                Else
                    lblEstado.Text = "No debe exceder el monto permitido!" & " " & sumatoria
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtImporteComprame.Value = 0.0
                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                End If

                lblEstado.Image = My.Resources.ok4

                'Grabar()
            Else
                UpdateAnticipo()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
            Me.Cursor = Cursors.Arrow
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumOper.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtDescripcion.Clear()
        End Try
    End Sub

    Private Sub txtNumOper_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumOper.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtCuentaCorriente.Select()
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
                Select Case cboMonedaCuenta.SelectedValue
                    Case 1
                        txtImporteCompramn.Select()
                        txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                    Case 2
                        txtImporteComprame.Select()
                        txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboTipoCuenta.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        txtImporteComprame.Value = 0
        txtImporteCompramn.Value = 0
        txtTipoCambio.Value = 0
        txtDiferenciaMontos.Value = 0
        txtNumOper.Clear()
        cboDepositoHijo.SelectedValue = -1
        cboMonedaCuenta.SelectedValue = -1
        txtCuentaCorriente.Clear()
        'nudDeudaPendienteme.Value = 0
        'nudDeudaPendientemn.Value = 0
        cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim value As Object = Me.cboDepositoHijo.SelectedValue

        If IsNumeric(value) Then
            txtImporteComprame.Value = 0
            txtImporteCompramn.Value = 0
            txtTipoCambio.Value = 0
            'txtDiferenciaMontos.Value = 0
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            cargarDatosCuenta(CInt(value))
        Else
            'txtFondoEF.DecimalValue = 0
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.PROVEEDOR)
        f.CaptionLabels(0).Text = "Proveedor"
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
#End Region

    
End Class