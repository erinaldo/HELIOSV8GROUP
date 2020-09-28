Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmCobrosModal
    Inherits frmMaster
    Dim Alert As Alert
    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property TipoCobroReclamacion() As String
    Public fecha As DateTime
    Public Property frmSeleccionCuentaFinanciera As frmSeleccionCuentaFinanciera
    Public Property empresaPeriodoSA As New empresaCierreMensualSA

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        '''''
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ConfiguracionInicio()
        SetRenderer() '  SetRenderer()
        ObtenerTablaGenerales()
        LoadComboFechas()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
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

#Region "VALIDA USUARIO CAJA"
    'Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
    '    Dim efSA As New EstadosFinancierosSA
    '    Dim ef As New estadosFinancieros
    '    Dim estableSA As New establecimientoSA

    '    GFichaUsuarios = New GFichaUsuario
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

    Private Sub LoadComboFechas()
        Dim empresaAnioSA As New empresaPeriodoSA

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

    End Sub

    Sub ConfiguracionInicio()

        'configurando docking manager
        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        'Me.DockingClientPanel1.AutoScroll = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'dockingManager1.DockControlInAutoHideMode(gpVSBehavior, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 350)
        'dockingManager1.SetDockLabel(gpVSBehavior, "DATOS DE COMPROBANTE")
        'dockingManager1.CloseEnabled = False
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

        If (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
            ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, txtCF_name.tag)

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

            gridStackedHeaderDescriptor1.HeaderText = "CAJA Y BANCOS - " & txtCF_name.Text

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
                Next
                dgvDiferencia.DataSource = dt
                Me.dgvDiferencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
                'txtImporteCompramn.Value = sumatoriaMN
                txtDiferenciaMontos.Value = diferenciaCaja

            Else
            End If
        ElseIf (txtCF_moneda.tag = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
            'ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, txtCF_name.tag)

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

            Dim dr As DataRow = dt.NewRow()
            dr(0) = 0
            dr(1) = txtTipoCambio.Value
            dr(2) = txtImporteCompramn.Value
            dr(3) = CDec(txtImporteCompramn.Value / txtTipoCambio.Value).ToString("N2")
            dr(4) = lblTipoCambio.Text
            sumatoriaMN = CDec((CDec(txtImporteCompramn.Value / txtTipoCambio.Value) * lblTipoCambio.Text)).ToString("N2")
            sumatoriaME = CDec(txtImporteCompramn.Value / txtTipoCambio.Value).ToString("N2")

            dr(5) = sumatoriaMN
            dr(6) = sumatoriaME
            DifsumatoriaMN = CDec(txtImporteCompramn.Value - sumatoriaMN).ToString("N2")
            DifsumatoriaME = CDec(CDec(txtImporteCompramn.Value / txtTipoCambio.Value) - sumatoriaME).ToString("N2")
            dr(7) = DifsumatoriaMN
            dr(8) = DifsumatoriaME

            dt.Rows.Add(dr)
            dgvDiferencia.DataSource = dt

            txtDiferenciaMontos.Value = DifsumatoriaMN

        ElseIf (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
            ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, txtCF_name.tag)

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
                    dr(4) = txtTipoCambio.Value
                    sumatoriaMN = CDec((i.montoUsd * txtTipoCambio.Value)).ToString("N2")
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

    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim itemSA As New detalleitemsSA

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim estadoF As New EstadosFinancierosSA
        Try
            With documentoSA.UbicarDocumento(intIdDocumento)

                lbldDocCaja.Text = .idDocumento
                txtFechaComprobante.Text = .fechaProceso
                txtNumeroCompr.Text = .nroDoc
                cboTipoDoc.SelectedValue = .tipoDoc
            End With

            With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)
                txtCF_moneda.tag = .moneda
                txtTipoCambio.Value = .tipoCambio
                txtImporteCompramn.Value = .montoSoles
                txtImporteComprame.Value = .montoUsd

                With entidadSA.UbicarEntidadPorID(.codigoProveedor).First
                    lblNomProveedor = .nombreCompleto
                    lblIdProveedor = .idEntidad
                    lblCuentaProveedor = .cuentaAsiento
                End With
            End With
            dgvDetalleItems.Rows.Clear()
            For Each i In documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento)
                dgvDetalleItems.Rows.Add(i.secuencia, i.DetalleItem, itemSA.InvocarProductoID(i.idItem).unidad1, "0.00", CDec(i.montoSoles), CDec(i.montoUsd), "0.00", "0.00", "0.00", "0.00",
                                         Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
    End Sub
    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(1, "1")
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.SelectedValue = "109"
    End Sub

    Sub CalculoGRID()
        Dim valDolares As Decimal = 0
        Dim nudvalueImporte As Decimal = txtImporteCompramn.Value
        Dim nudSaldo As Decimal = nudvalueImporte
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0


        valDolares = Math.Round(txtImporteCompramn.Value / txtTipoCambio.Value, 2)
        txtImporteComprame.Value = valDolares

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

    End Sub

    Sub CalculoGRIDExtrajero()
        Dim valSoles As Decimal = 0
        Dim nudvalueImporte As Decimal = txtImporteComprame.Value
        Dim nudSaldo As Decimal = nudvalueImporte
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0
        Dim cMonedaNac As Decimal = 0
        Dim cMonedaExt As Decimal = 0

        If (txtTipoCambio.Value > 0) Then
            valSoles = CDec(txtImporteCompramn.Value)
            'valSoles = Math.Round(txtImporteComprame.Value * txtTipoCambio.Value, 2)
            'txtImporteCompramn.Value = valSoles

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
            'lblSaldoFinal.Text = CDec(cMonedaNac)
            'lblSaldoFinalme.Text = CDec(cMonedaExt)
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


#End Region

#Region "Manipulación data"
    Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
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

    Public Function AS_DebeCajaReclamacion(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
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

    Public Function AS_HaberCliente(cuentas As String, cdescrupcon As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = cuentas,
      .descripcion = cdescrupcon,
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
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
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
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


    Function asientoCajaReclamacion() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        nAsiento.importeMN = txtImporteCompramn.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtImporteComprame.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then



                nAsiento.movimiento.Add(AS_HaberClienteReclamacion(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(txtCF_name.tag).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                nAsiento.movimiento.Add(AS_DebeCajaReclamacion("1629", "OTRAS", dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))



            End If
        Next

        Select Case txtCF_moneda.tag
            Case 1
                Select Case tb19.ToggleState
                    Case ToggleButton2.ToggleButtonState.OFF 'soles

                        For Each r As Record In dgvDiferencia.Table.Records

                            Select Case tb19.ToggleState
                                Case ToggleButton2.ToggleButtonState.OFF 'dolares
                                    If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                        sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN"))).ToString("N2")
                                        'cuentas Maykol de tratamiento de caja
                                        nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, "776", "Por la utlidad de las diferencias de tipo de cambio"))
                                        nAsiento.movimiento.Add(AS_DebeCajaDiferencia(lblCuentaProveedor, lblNomProveedor, sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                                    ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                        sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1).ToString("N2")
                                        nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                        nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, lblCuentaProveedor, lblNomProveedor))
                                    End If
                            End Select
                        Next
                End Select
        End Select

        Return nAsiento
    End Function


    Function asientoCaja() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        nAsiento.importeMN = txtImporteCompramn.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtImporteComprame.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then



                nAsiento.movimiento.Add(AS_HaberCliente(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(txtCF_name.tag).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                nAsiento.movimiento.Add(AS_DebeCaja(lblCuentaProveedor, lblNomProveedor, dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))


            End If
        Next

        Select Case txtCF_moneda.tag
            Case 1
                Select Case tb19.ToggleState
                    Case ToggleButton2.ToggleButtonState.OFF 'soles

                        For Each r As Record In dgvDiferencia.Table.Records

                            Select Case tb19.ToggleState
                                Case ToggleButton2.ToggleButtonState.OFF 'dolares
                                    If (CDec(r.GetValue("difMNCajaMN") > 0)) Then
                                        sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN"))).ToString("N2")
                                        'cuentas Maykol de tratamiento de caja
                                        nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, "776", "Por la utlidad de las diferencias de tipo de cambio"))
                                        nAsiento.movimiento.Add(AS_DebeCajaDiferencia(lblCuentaProveedor, lblNomProveedor, sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                                    ElseIf (CDec(r.GetValue("difMNCajaMN") < 0)) Then
                                        sumaAsientocajaMN = CDec((r.GetValue("difMNCajaMN")) * -1).ToString("N2")
                                        nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                                        nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, lblCuentaProveedor, lblNomProveedor))
                                    End If
                            End Select
                        Next
                End Select
        End Select

        Return nAsiento
    End Function

    Public Sub GrabarReclamacion()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ListadocumentoCajaDetalle2 As New List(Of documentoCajaDetalle)
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()

        With ndocumento
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "9901"
            .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .nroDoc = txtNumeroCompr.Text.Trim
            .idOrden = Nothing
            .moneda = txtCF_moneda.tag
            .idEntidad = CInt(txtEntidad.Tag)
            .entidad = txtEntidad.Text
            .nrodocEntidad = txtNroDocEntidad.Text
            .tipoEntidad = txtTipoEntidad.Text
            .tipoOperacion = "9922"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now ' New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        End With

        With ndocumentoCaja
            .estado = "1"
            .movimientoCaja = MovimientoCaja.CobroCliente
            .codigoLibro = "1"
            .periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = MovimientoCaja.EntradaDinero
            .codigoProveedor = lblIdProveedor
            .tipoOperacion = "9922"
            .moneda = txtCF_moneda.Tag
            .fechaProceso = fecha
            .fechaCobro = fecha
            .tipoDocPago = "9901"
            .formapago = cboTipoDoc.SelectedValue
            If cboTipoDoc.SelectedValue = "001" Then
                .numeroDoc = Nothing
                .numeroOperacion = txtNumOper.Text.Trim
                '   .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                .ctaIntebancaria = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = Date.Now
                .entregado = "SI"
            ElseIf cboTipoDoc.SelectedValue = "003" Then
                .numeroDoc = Nothing
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = Date.Now
                .entregado = "SI"
            ElseIf cboTipoDoc.SelectedValue = "005" Then
                .numeroDoc = Nothing
                .numeroOperacion = txtNumOper.Text.Trim
                '     .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                .ctaIntebancaria = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = Date.Now
                .entregado = "SI"
            ElseIf cboTipoDoc.SelectedValue = "006" Then
                .numeroDoc = Nothing
                .numeroOperacion = txtNumOper.Text.Trim
                '     .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                .ctaIntebancaria = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = Date.Now
                .entregado = "SI"
            ElseIf cboTipoDoc.SelectedValue = "007" Then ' cheques
                .numeroDoc = Nothing
                .numeroOperacion = Nothing
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDoc.SelectedValue = "111" Then
                .numeroDoc = Nothing
                .numeroOperacion = Nothing
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDoc.SelectedValue = "109" Then
                .numeroDoc = txtNumeroCompr.Text.Trim
                .numeroOperacion = Nothing
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaCobro = Date.Now
                .fechaProceso = Date.Now
                .entregado = "NO"
            End If
            .entidadFinanciera = txtCF_name.Tag
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtImporteCompramn.Value
            .montoUsd = txtImporteComprame.Value
            .glosa = Glosa()
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = DateTime.Now ' New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .DeudaEvalMN = CDec(lblDeudaPendiente.Text)
            .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
        End With

        ndocumento.documentoCaja = ndocumentoCaja


        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

                Select Case txtCF_moneda.tag
                    Case 1
                        ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                        ndocumentoCajaDetalle.montoSolesTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                        ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                        ndocumentoCajaDetalle.montoUsdTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                    Case 2
                        'ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.Value).ToString("N2")
                        'ndocumentoCajaDetalle.montoSolesTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.Value).ToString("N2")
                        'ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                        'ndocumentoCajaDetalle.montoUsdTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                        ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                        ndocumentoCajaDetalle.montoSolesTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                        ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                        ndocumentoCajaDetalle.montoUsdTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                End Select


                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                ndocumentoCajaDetalle.moneda = txtCF_moneda.tag
                ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = DateTime.Now ' New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                ndocumentoCajaDetalle.documentoAfectadodetalle = dgvDetalleItems.Rows(i.Index).Cells(11).Value()
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
            End If
        Next
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
        Select Case cboTipoDoc.SelectedValue
            Case "109", "003", "001"

                asiento = asientoCajaReclamacion()
                ListaAsiento.Add(asiento)
                ndocumento.asiento = ListaAsiento
            Case "007"
                '   cajaUsarioBE = Nothing
        End Select

        n.IdAlmacen = documentoCajaSA.SaveGroupCajaME(ndocumento, Nothing, ListadocumentoCajaDetalle2)
        datos.Add(n)
        lblEstado.Text = "Transacción realizada con éxito!"
        Dispose()
    End Sub

    Public Sub GrabarReconocimiento()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Dim idCaja As Integer
        Try

            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 3, 4
                    idCaja = GFichaUsuarios.IdCajaUsuario
                Case Else
                    idCaja = 0
            End Select

            With ndocumento
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                .tipoDoc = "9901"
                .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .nroDoc = txtNumeroCompr.Text.Trim
                .idOrden = Nothing
                .moneda = IIf(txtCF_moneda.Tag = 1, "1", "2")
                .idEntidad = CInt(txtEntidad.Tag)
                .entidad = txtEntidad.Text
                .tipoEntidad = "CL"
                .nrodocEntidad = txtNroDocEntidad.Text
                .tipoOperacion = "9908"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            End With

            With ndocumentoCaja
                .estado = "1"
                .movimientoCaja = MovimientoCaja.CobroCliente
                .codigoLibro = "1"
                .periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = MovimientoCaja.EntradaDinero
                .codigoProveedor = lblIdProveedor
                .tipoOperacion = "9908"
                .moneda = txtCF_moneda.Tag
                .fechaProceso = fecha
                .fechaCobro = fecha
                .tipoDocPago = "9901"
                .formapago = cboTipoDoc.SelectedValue
                If cboTipoDoc.SelectedValue = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    '  .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = Nothing
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "005" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    ' .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "006" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    '  .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "007" Then ' cheques
                    .numeroDoc = Nothing
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = txtFechaCobro.Value
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "111" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = txtFechaCobro.Value
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "109" Then
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaCobro = Date.Now
                    .fechaProceso = Date.Now
                    .entregado = "NO"
                End If
                .entidadFinanciera = txtCF_name.Tag
                .tipoCambio = txtTipoCambio.Value
                .montoSoles = txtImporteCompramn.Value
                .montoUsd = txtImporteComprame.Value
                .glosa = Glosa()
                .idCajaUsuario = idCaja
                .usuarioModificacion = usuario.IDUsuario
                .fechaModificacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
            End With

            ndocumento.documentoCaja = ndocumentoCaja


            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                    ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

                    Select Case txtCF_moneda.Tag
                        Case 1
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoSolesTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            ndocumentoCajaDetalle.montoUsdTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                        Case 2
                            'ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.Value).ToString("N2")
                            'ndocumentoCajaDetalle.montoSolesTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.Value).ToString("N2")
                            'ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            'ndocumentoCajaDetalle.montoUsdTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoSolesTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            ndocumentoCajaDetalle.montoUsdTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                    End Select


                    ndocumentoCajaDetalle.entregado = "SI"
                    ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                    ndocumentoCajaDetalle.moneda = txtCF_moneda.Tag
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                    ndocumentoCajaDetalle.idCajaUsuario = idCaja
                    ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                    ndocumentoCajaDetalle.fechaModificacion = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    ndocumentoCajaDetalle.documentoAfectadodetalle = dgvDetalleItems.Rows(i.Index).Cells(11).Value()
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cboTipoDoc.SelectedValue
                Case "109", "003", "001"
                    asiento = asientoCaja()
                    ListaAsiento.Add(asiento)
                    ndocumento.asiento = ListaAsiento
                Case "007"
                    '   cajaUsarioBE = Nothing
            End Select

            n.IdAlmacen = documentoCajaSA.SaveGroupCajaReconocimiento(ndocumento, Nothing)
            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
            '   lblEstado.Image = My.Resources.ok4
            Alert = New Alert("Pago registrado", alertType.success)
            Alert.TopMost = True
            Alert.Show()
            Close()
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
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Dim idCaja As Integer
        'Try

        'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
        '        Case 3, 4
        idCaja = GFichaUsuarios.IdCajaUsuario
        '    Case Else
        '        idCaja = 0
        'End Select

        With ndocumento
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                .tipoDoc = "9901"
            .fechaProceso = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            .nroDoc = txtNumeroCompr.Text.Trim
                .idOrden = Nothing
                .moneda = IIf(txtCF_moneda.Tag = 1, "1", "2")
                .idEntidad = CInt(txtEntidad.Tag)
                .entidad = txtEntidad.Text
                .tipoEntidad = "CL"
                .nrodocEntidad = txtNroDocEntidad.Text
                .tipoOperacion = "9908"
                .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now ' New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        End With

        With ndocumentoCaja
            .estado = "1"
            .movimientoCaja = MovimientoCaja.CobroCliente
            .codigoLibro = "1"
            .periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = MovimientoCaja.EntradaDinero
            .codigoProveedor = lblIdProveedor
            .tipoOperacion = "9908"
            .moneda = txtCF_moneda.Tag
            .fechaProceso = fecha
            .fechaCobro = fecha
            .tipoDocPago = "9901"
            .formapago = cboTipoDoc.SelectedValue
            If cboTipoDoc.SelectedValue = "001" Then
                .numeroDoc = Nothing
                .numeroOperacion = txtNumOper.Text.Trim
                '     .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                .ctaIntebancaria = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = Date.Now
                .entregado = "SI"
            ElseIf cboTipoDoc.SelectedValue = "003" Then
                .numeroDoc = Nothing
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = Date.Now
                .entregado = "SI"
            ElseIf cboTipoDoc.SelectedValue = "005" Then
                .numeroDoc = Nothing
                .numeroOperacion = txtNumOper.Text.Trim
                '   .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                .ctaIntebancaria = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = Date.Now
                .entregado = "SI"
            ElseIf cboTipoDoc.SelectedValue = "006" Then
                .numeroDoc = Nothing
                .numeroOperacion = txtNumOper.Text.Trim
                '    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                .ctaIntebancaria = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = Date.Now
                .entregado = "SI"
            ElseIf cboTipoDoc.SelectedValue = "007" Then ' cheques
                .numeroDoc = Nothing
                .numeroOperacion = Nothing
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDoc.SelectedValue = "111" Then
                .numeroDoc = Nothing
                .numeroOperacion = Nothing
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDoc.SelectedValue = "109" Then
                .numeroDoc = txtNumeroCompr.Text.Trim
                .numeroOperacion = Nothing
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaCobro = Date.Now
                .fechaProceso = Date.Now
                .entregado = "NO"
            End If
            .entidadFinanciera = txtCF_name.Tag
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtImporteCompramn.Value
            .montoUsd = txtImporteComprame.Value
            .glosa = Glosa()
            .idCajaUsuario = idCaja
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = DateTime.Now
            .DeudaEvalMN = CDec(lblDeudaPendiente.Text)
            .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
        End With

        ndocumento.documentoCaja = ndocumentoCaja


            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), TxtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                    ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

                    Select Case txtCF_moneda.Tag
                        Case 1
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoSolesTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            ndocumentoCajaDetalle.montoUsdTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                        Case 2
                            'ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.Value).ToString("N2")
                            'ndocumentoCajaDetalle.montoSolesTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.Value).ToString("N2")
                            'ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            'ndocumentoCajaDetalle.montoUsdTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoSolesTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                            ndocumentoCajaDetalle.montoUsdTransacc = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                    End Select


                    ndocumentoCajaDetalle.entregado = "SI"
                    ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
                    ndocumentoCajaDetalle.moneda = txtCF_moneda.Tag
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                    ndocumentoCajaDetalle.idCajaUsuario = idCaja
                    ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = DateTime.Now ' New DateTime(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), txtDia.Text, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                ndocumentoCajaDetalle.documentoAfectadodetalle = dgvDetalleItems.Rows(i.Index).Cells(11).Value()
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cboTipoDoc.SelectedValue
                Case "109", "003", "001"
                    asiento = asientoCaja()
                    ListaAsiento.Add(asiento)
                    ndocumento.asiento = ListaAsiento
                Case "007"
                    '   cajaUsarioBE = Nothing
            End Select

            n.IdAlmacen = documentoCajaSA.SaveGroupCajaVentasME(ndocumento, Nothing)
            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
        '   lblEstado.Image = My.Resources.ok4
        Alert = New Alert("Pago registrado", alertType.success)
            Alert.TopMost = True
            Alert.Show()
            Close()
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    '   lblEstado.Image = My.Resources.warning2
        'End Try
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

        'With frmCuentasPorPagar
        strGlosa = "Por pagos con comprobante, en " & cboTipoDoc.Text & " con fecha: " & fecha

        'End With
        Return strGlosa
    End Function
#End Region

    Private Sub frmCobros_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        txtImporteComprame.Value = 0
        txtImporteCompramn.Value = 0
        txtTipoCambio.Value = 0
        txtDiferenciaMontos.Value = 0
        txtNumOper.Clear()
        txtCF_name.Tag = Nothing
        txtCF_moneda.Tag = Nothing
        'txtCuentaCorriente.Clear()
        'nudDeudaPendienteme.Value = 0
        'nudDeudaPendientemn.Value = 0
        'cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim value As Object = Me.txtCF_name.tag

        If IsNumeric(value) Then
            txtImporteComprame.Value = 0
            txtImporteCompramn.Value = 0
            txtTipoCambio.Value = 0
            txtDiferenciaMontos.Value = 0
            txtNumOper.Clear()
            'txtCuentaCorriente.Clear()
            'cargarDatosCuenta(CInt(value))
        Else
            'txtFondoEF.DecimalValue = 0
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)
        'Me.pcEntidad.Font = New Font("Tahoma", 8)
        'Me.pcEntidad.Size = New Size(212, 139)
        'Me.pcEntidad.ParentControl = Me.cboEntidades
        'Me.pcEntidad.ShowPopup(Point.Empty)
    End Sub

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs)
        Tag = 1
    End Sub

    'Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
    '    Select Case txtCF_moneda.tag
    '        Case 1
    '            If Not Me.PopupControlContainer3.IsShowing() Then
    '                ' Let the popup align around the source textBox.
    '                Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
    '                ' Passing Point.Empty will align it automatically around the above ParentControl.
    '                Me.PopupControlContainer1.ShowPopup(Point.Empty)
    '            End If
    '            If nudDeudaPendienteme.Text.Trim.Length > 0 Then
    '                Me.PopupControlContainer3.ParentControl = Me.txtImporteCompramn
    '                Me.PopupControlContainer3.ShowPopup(Point.Empty)
    '                CargarDiferenciasdeImporte()
    '            End If
    '        Case 2
    '            If nudDeudaPendienteme.Text.Trim.Length > 0 Then
    '                If Not Me.PopupControlContainer3.IsShowing() Then
    '                    ' Let the popup align around the source textBox.
    '                    Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
    '                    ' Passing Point.Empty will align it automatically around the above ParentControl.
    '                    Me.PopupControlContainer1.ShowPopup(Point.Empty)
    '                End If
    '                Me.PopupControlContainer3.ParentControl = Me.txtImporteComprame
    '                Me.PopupControlContainer3.ShowPopup(Point.Empty)
    '                CargarDiferenciasdeImporte()
    '            End If
    '    End Select
    'End Sub

    Private Sub txtImporteCompramn_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteCompramn.ValueChanged
        Select Case txtCF_moneda.tag
            Case 1

                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    'ME - ME
                    If (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        If txtTipoCambio.Value > 0 Then
                            txtImporteComprame.Value = txtImporteCompramn.Value / txtTipoCambio.Value
                            'pnDiferencia.Visible = True
                            CalculoSoles()
                            CalculoGRID()
                        End If
                        'MN - ME
                    ElseIf (txtCF_moneda.tag = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        'pnDiferencia.Visible = True
                        'CalculoSoles()
                        If txtTipoCambio.Value > 0 Then
                            CalculoGRID()
                            CargarDiferenciasdeImporte()
                        End If


                        'mn - mn
                    ElseIf (txtCF_moneda.tag = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                        If (txtImporteCompramn.Value > 0) Then
                            If (txtImporteCompramn.Value <= CDec(lblDeudaPendiente.Text)) Then
                                If txtTipoCambio.Value > 0 Then
                                    CalculoGRID()
                                End If
                            Else

                                lblEstado.Text = "Ingrese un importe correcto."
                                Timer1.Enabled = True
                                PanelError.Visible = True
                                TiempoEjecutar(10)
                                txtImporteCompramn.Value = 0
                            End If

                        End If
                        'ME - MN
                    ElseIf (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                        CalculoGRID()
                    End If

                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    CalculoGRID()
                End If

            Case 2

                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    'ME - ME
                    If (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        If txtTipoCambio.Value > 0 Then
                            txtImporteComprame.Value = txtImporteCompramn.Value / txtTipoCambio.Value
                            'pnDiferencia.Visible = True
                            CalculoSoles()
                            CalculoGRID()
                        End If
                        'MN - ME
                    ElseIf (txtCF_moneda.tag = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        'pnDiferencia.Visible = True
                        'CalculoSoles()
                        If txtTipoCambio.Value > 0 Then
                            CalculoGRID()
                        End If


                        'mn - mn
                    ElseIf (txtCF_moneda.tag = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                        If (txtImporteCompramn.Value > 0) Then
                            If (txtImporteCompramn.Value <= CDec(lblDeudaPendiente.Text)) Then
                                CalculoGRID()
                            Else

                                lblEstado.Text = "Ingrese un importe correcto."
                                Timer1.Enabled = True
                                PanelError.Visible = True
                                TiempoEjecutar(10)
                                txtImporteCompramn.Value = 0
                            End If

                        End If
                        'ME - MN
                    ElseIf (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                        If txtTipoCambio.Value > 0 Then
                            txtImporteComprame.Value = CDec(txtImporteCompramn.Value / txtTipoCambio.Value)
                            CalculoGRID()
                        End If

                    End If

                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    CalculoGRID()
                End If

        End Select
    End Sub

    Sub CalculoSoles()
        If txtCF_moneda.tag = 1 Then

            If CDec(txtImporteComprame.Value) > CDec(lblDeudaPendienteme.Text) Then
                MsgBox("El valor ingreso excede el valor permitido.", MsgBoxStyle.Information, String.Concat("Monto permitido ($.):", Space(2), lblDeudaPendienteme.Text))
                txtTipoCambio.Value = 0
                txtImporteCompramn.Value = 0
                txtImporteComprame.Value = 0
                Exit Sub

            End If
        End If
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        If (txtCF_name.tag > -1) Then
            Select Case txtCF_moneda.tag
                Case 1
                    txtImporteCompramn_ValueChanged(sender, e)
                Case 2
                    txtImporteComprame_ValueChanged(sender, e)
            End Select

        End If
    End Sub

    Private Sub txtImporteComprame_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteComprame.ValueChanged
        Select Case txtCF_moneda.tag
            Case 2
                If (CDec(txtImporteComprame.Value <= CDec(btnSaldoCobro.Text))) Then
                    If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                        'ME - ME
                        If (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                            If (txtImporteComprame.Value > 0) Then

                                If (txtImporteComprame.Value <= lblDeudaPendienteme.Text) Then
                                    If txtTipoCambio.Value > 0 Then

                                        txtImporteCompramn.Value = txtImporteComprame.Value * txtTipoCambio.Value
                                        'pnDiferencia.Visible = True
                                        'CargarDiferenciasdeImporte()
                                        'CalculoDolares()
                                        CalculoGRID()
                                    Else
                                        lblEstado.Text = "Ingrese el tipo de cambio."
                                        Timer1.Enabled = True
                                        PanelError.Visible = True
                                        TiempoEjecutar(10)
                                        'txtTipoCambio.Value = 0
                                        'txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                    End If
                                Else
                                    lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                                    Timer1.Enabled = True
                                    PanelError.Visible = True
                                    TiempoEjecutar(10)
                                    txtImporteComprame.Value = 0
                                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                                    txtImporteCompramn.Value = 0
                                    txtDiferenciaMontos.Value = 0
                                End If
                            End If
                            'MN - ME
                        ElseIf (txtCF_moneda.tag = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                            If txtTipoCambio.Value > 0 Then
                                txtImporteComprame.Value = txtImporteCompramn.Value / txtTipoCambio.Value
                                'pnDiferencia.Visible = True
                                CalculoSoles()
                                CalculoGRID()
                            End If
                            'MN - MN
                        ElseIf (txtCF_moneda.tag = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                            If txtTipoCambio.Value > 0 Then
                                If (txtImporteComprame.Value <= lblDeudaPendienteme.Text) Then
                                    txtImporteCompramn.Value = txtImporteComprame.Value * txtTipoCambio.Value
                                    'pnDiferencia.Visible = True
                                    'CalculoDolares()
                                    CalculoGRID()
                                Else
                                    lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                                    Timer1.Enabled = True
                                    PanelError.Visible = True
                                    TiempoEjecutar(10)
                                    txtImporteComprame.Value = 0
                                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                                    txtTipoCambio.Value = 0
                                    txtImporteCompramn.Value = 0
                                    txtDiferenciaMontos.Value = 0
                                End If
                            Else
                                lblEstado.Text = "Ingrese el tipo de cambio."
                                Timer1.Enabled = True
                                PanelError.Visible = True
                                TiempoEjecutar(10)
                                'txtTipoCambio.Value = 0
                                'txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            End If

                            'ME - MN
                        ElseIf (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then

                            'If txtTipoCambio.Value > 0 Then

                            '    If (txtImporteCompramn.Value <= lblDeudaPendiente.Text) Then
                            '        'pnDiferencia.Visible = True
                            '        'CalculoDolares()
                            '        CalculoGRID()
                            '    Else
                            '        lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                            '        Timer1.Enabled = True
                            '        PanelError.Visible = True
                            '        TiempoEjecutar(10)
                            '        txtImporteCompramn.Value = 0
                            '        txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                            '        txtTipoCambio.Value = 0
                            '        txtImporteComprame.Value = 0
                            '        txtDiferenciaMontos.Value = 0
                            '    End If
                            'Else
                            '    lblEstado.Text = "Ingrese el tipo de cambio."
                            '    Timer1.Enabled = True
                            '    PanelError.Visible = True
                            '    TiempoEjecutar(10)
                            '    txtTipoCambio.Value = 0
                            '    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            'End If

                        End If
                    ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                        CalculoGRID()
                    End If
                Else
                    lblEstado.Text = "La moneda no debe exceder al monto disponible."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtImporteComprame.Value = 0
                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                End If

            Case 1
                If (CDec(txtImporteComprame.Value <= CDec(btnSaldoCobro.Text))) Then
                    If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                        'ME - ME
                        If (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                            If (txtImporteComprame.Value > 0) Then

                                If (txtImporteComprame.Value <= lblDeudaPendienteme.Text) Then
                                    If txtTipoCambio.Value > 0 Then

                                        txtImporteCompramn.Value = txtImporteComprame.Value * txtTipoCambio.Value
                                        'pnDiferencia.Visible = True
                                        'CargarDiferenciasdeImporte()
                                        'CalculoDolares()
                                        CalculoGRID()
                                    Else
                                        lblEstado.Text = "Ingrese el tipo de cambio."
                                        Timer1.Enabled = True
                                        PanelError.Visible = True
                                        TiempoEjecutar(10)
                                        'txtTipoCambio.Value = 0
                                        'txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                    End If
                                Else
                                    lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                                    Timer1.Enabled = True
                                    PanelError.Visible = True
                                    TiempoEjecutar(10)
                                    txtImporteComprame.Value = 0
                                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                                    txtImporteCompramn.Value = 0
                                    txtDiferenciaMontos.Value = 0
                                End If
                            End If
                            'MN - ME
                        ElseIf (txtCF_moneda.tag = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                            If txtTipoCambio.Value > 0 Then
                                txtImporteCompramn.Value = CDec(txtImporteComprame.Value * txtTipoCambio.Value)
                                CalculoSoles()
                                CalculoGRID()
                            End If
                            'MN - MN
                        ElseIf (txtCF_moneda.tag = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                            'If txtTipoCambio.Value > 0 Then
                            '    If (txtImporteComprame.Value <= lblDeudaPendienteme.Text) Then
                            '        txtImporteCompramn.Value = txtImporteComprame.Value * txtTipoCambio.Value
                            '        'pnDiferencia.Visible = True
                            '        'CalculoDolares()
                            '        CalculoGRID()
                            '    Else
                            '        lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                            '        Timer1.Enabled = True
                            '        PanelError.Visible = True
                            '        TiempoEjecutar(10)
                            '        txtImporteComprame.Value = 0
                            '        txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                            '        txtTipoCambio.Value = 0
                            '        txtImporteCompramn.Value = 0
                            '        txtDiferenciaMontos.Value = 0
                            '    End If
                            'Else
                            '    lblEstado.Text = "Ingrese el tipo de cambio."
                            '    Timer1.Enabled = True
                            '    PanelError.Visible = True
                            '    TiempoEjecutar(10)
                            'txtTipoCambio.Value = 0
                            'txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            'End If

                            'ME - MN
                        ElseIf (txtCF_moneda.tag = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then

                            If txtTipoCambio.Value > 0 Then
                                txtImporteCompramn.Value = txtImporteComprame.Value * txtTipoCambio.Value
                                If (txtImporteCompramn.Value <= lblDeudaPendiente.Text) Then
                                    'pnDiferencia.Visible = True
                                    'CalculoDolares()
                                    CalculoGRID()
                                Else
                                    lblEstado.Text = "La moneda no debe exceder al monto de la factura."
                                    Timer1.Enabled = True
                                    PanelError.Visible = True
                                    TiempoEjecutar(10)
                                    txtImporteCompramn.Value = 0
                                    txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                                    txtTipoCambio.Value = 0
                                    txtImporteComprame.Value = 0
                                    txtDiferenciaMontos.Value = 0
                                End If
                            Else
                                lblEstado.Text = "Ingrese el tipo de cambio."
                                Timer1.Enabled = True
                                PanelError.Visible = True
                                TiempoEjecutar(10)
                                txtTipoCambio.Value = 0
                                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            End If

                        End If
                    ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                        CalculoGRID()
                    End If
                Else
                    lblEstado.Text = "La moneda no debe exceder al monto disponible."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtImporteComprame.Value = 0
                    txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                End If

        End Select
    End Sub

    Private Sub txtNumOper_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumOper.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtNumOper.Text.Trim.Length > 0 Then
                    '    txtCuentaCorriente.Select()
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumOper.Clear()
        End Try
    End Sub

    Private Sub txtImporteCompramn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteCompramn.KeyDown
        'Try
        '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        '        e.SuppressKeyPress = True
        '        If (CDec(txtImporteCompramn.Value <= nudDeudaPendientemn.Value) And txtImporteCompramn.Value > 0) Then
        '            txtTipoCambio.Select()
        '            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
        '        Else
        '            txtImporteCompramn.Select()
        '            txtImporteCompramn.Select(0, txtTipoCambio.Text.Length)
        '        End If
        '    End If
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    'txtImporteCompramn.Clear()
        'End Try

    End Sub


    Private Sub txtImporteComprame_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteComprame.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                Select Case tb19.ToggleState
                    Case ToggleButton2.ToggleButtonState.OFF 'dolares

                    Case ToggleButton2.ToggleButtonState.ON 'soles
                        If txtImporteComprame.Text.Trim.Length > 0 And txtImporteComprame.Value > 0 Then
                            txtTipoCambio.Select()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Else
                            txtImporteComprame.Select()
                            txtImporteComprame.Select(0, txtTipoCambio.Text.Length)
                        End If
                End Select


            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumOper.Clear()
        End Try
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

        If TxtDia.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar la fecha de registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtDia.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If txtImporteCompramn.Value > 0 Then

            If Not txtCF_name.Text.Length > 0 Then
                lblEstado.Text = "Ingrese la entidad financiera."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                'cboDepositoHijo.Select()
                Exit Sub
            End If

            If cboTipoDoc.SelectedValue = "001" Then
                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Select()
                    Exit Sub
                End If

                'If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                '    lblEstado.Text = "Ingrese el número de cuenta."
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    'txtCuentaCorriente.Select()
                '    Exit Sub
                'End If

            ElseIf cboTipoDoc.SelectedValue = "005" Then

                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Select()
                    Exit Sub
                End If

            ElseIf cboTipoDoc.SelectedValue = "006" Then

                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Select()
                    Exit Sub
                End If


            ElseIf cboTipoDoc.SelectedValue = "003" Then
                'If Not txtFechaEmision.Value >= Date.Now Then
                '    lblEstado.Text = "Ingrese la fecha de emisión."
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If

                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Select()
                    Exit Sub
                End If

                If Not cboTipoDoc.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de cuenta interbancaria."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    'txtCtaInterbancaria.Select()
                    Exit Sub
                End If

                'If Not cboEntidades.SelectedValue > 0 Then
                '    lblEstado.Text = "Ingrese una entidad."
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If


            ElseIf cboTipoDoc.SelectedValue = "007" Then
                'If Not txtFechaEmision.Value >= Date.Now Then
                '    lblEstado.Text = "Ingrese la fecha de emisión."
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If

                'If Not txtFechaCobro.Value >= Date.Now Then
                '    lblEstado.Text = "Ingrese la fecha de cobro."
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If
            ElseIf cboTipoDoc.SelectedValue = "109" Then
                'If Not txtNumero.Text.Length > 0 Then
                '    lblEstado.Text = "Ingrese el numero de voucher"
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If

            ElseIf cboTipoDoc.SelectedValue = "111" Then
                'If Not txtFechaEmision.Value >= Date.Now Then
                '    lblEstado.Text = "Ingrese la fecha de emisión."
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If

                'If Not txtFechaCobro.Value >= Date.Now Then
                '    lblEstado.Text = "Ingrese la fecha de cobro."
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If
            ElseIf cboTipoDoc.SelectedValue = "007" Then
                'If Not txtNumero.Text.Trim.Length > 0 Then
                '    lblEstado.Text = "Ingrese el número del tipo de documento."
                '    ' lblEstado.Image = My.Resources.warning2
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If
            Else
                'If Not txtNumero.Text.Trim.Length > 0 Then
                '    lblEstado.Text = "Ingrese el número del tipo de documento."
                '    'lblEstado.Image = My.Resources.warning2
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    txtNumero.Focus()
                '    Exit Sub
                'End If
                'If Not txtNumOper.Text.Trim.Length > 0 Then
                '    lblEstado.Text = "Ingrese el número de operación de la transacción."
                '    'lblEstado.Image = My.Resources.warning2
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    txtNumOper.Focus()
                '    Exit Sub
                'End If
                'If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                '    lblEstado.Text = "Ingrese el número de cta. corriente del banco."
                '    '.Image = My.Resources.warning2
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                '    txtCuentaCorriente.Focus()
                '    Exit Sub
                'End If
            End If

            Try
                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    'Dim fechaAnt = New Date(txtPeriodo.Value.Year, CInt(txtPeriodo.Value.Month), 1)
                    'fechaAnt = fechaAnt.AddMonths(-1)
                    'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                    'If periodoAnteriorEstaCerrado = False Then
                    '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "-" & fechaAnt.Year)
                    '    Cursor = Cursors.Default
                    '    Exit Sub
                    'End If

                    'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
                    'If Not IsNothing(valida) Then
                    '    If valida = True Then
                    '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '        Me.Cursor = Cursors.Default
                    '        Exit Sub
                    '    End If
                    'End If


                    If TipoCobroReclamacion = "RECLAMACION" Then
                        GrabarReclamacion()
                    Else


                        If lblTipoDocPago.Text = "NORMAL" Then

                            Grabar()
                        ElseIf lblTipoDocPago.Text = "VREC" Then
                            GrabarReconocimiento()
                        End If
                    End If



                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    '   Editar()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Veridicar período")
            End Try
        Else
            lblEstado.Text = "Ingresar el importe a pagar!"
            'lblEstado.Image = My.Resources.warning2
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If
    End Sub

    'Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
    '    If Not Me.PopupControlContainer1.IsShowing() Then
    '        ' Let the popup align around the source textBox.
    '        Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
    '        ' Passing Point.Empty will align it automatically around the above ParentControl.
    '        Me.PopupControlContainer1.ShowPopup(Point.Empty)
    '    End If

    '    If nudDeudaPendienteme.Text.Trim.Length > 0 Then
    '        Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
    '        Me.PopupControlContainer1.ShowPopup(Point.Empty)
    '        CargarEntidadesXtipo()
    '    End If
    'End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If cboTipoDoc.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            '   txtCuentaCorriente.Clear()
            If cboTipoDoc.SelectedValue = "109" Then 'EFECTIVO (que se genere un vocher de caja con los datos del comprobante que se está pagando) 
                '  pnEntidad.Visible = False
                pnFecha.Visible = False
                Label17.Text = "NRO. VOUCHER:"

            ElseIf cboTipoDoc.SelectedValue = "007" Then ' CHEQUES
                '      pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            ElseIf cboTipoDoc.SelectedValue = "001" Then ' DEPOSITO EN CUENTA 
                '     pnEntidad.Visible = True
                pnFecha.Visible = False
                Label17.Text = "NRO. OPERACIÓN:"

            ElseIf cboTipoDoc.SelectedValue = "111" Then ' CHEQUE NO NEGOCIABLE 
                '    pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            End If
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dispose()
    End Sub



    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If TxtDia.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar la fecha de registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtDia.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim fechaActual As DateTime = Format(Now, cboAnio.Text & "-" & cboMesCompra.SelectedValue & "-" & TxtDia.Text)
        frmSeleccionCuentaFinanciera = New frmSeleccionCuentaFinanciera
        'frmSeleccionCuentaFinanciera.txtPeriodo.Value = txtPeriodo.Value
        frmSeleccionCuentaFinanciera.txtPeriodo.Value = fechaActual
        frmSeleccionCuentaFinanciera.GetCuentasFinancieras("CUENTAS EN EFECTIVO")
        frmSeleccionCuentaFinanciera.StartPosition = FormStartPosition.CenterParent
        frmSeleccionCuentaFinanciera.ShowDialog()
        If frmSeleccionCuentaFinanciera.Tag IsNot Nothing Then
            txtImporteCompramn.Value = 0
            txtImporteComprame.Value = 0
            'txtTipoCambio.Value = 0
            txtNumOper.Clear()
            'txtCuentaCorriente.Clear()
            SaldoEFME.DoubleValue = 0
            SaldoEFMN.DoubleValue = 0

            Dim c = CType(frmSeleccionCuentaFinanciera.Tag, estadosFinancieros)
            Select Case c.tipo
                Case "EF"
                    txtCF_tipo.Tag = c.tipo
                    txtCF_tipo.Text = "CUENTA EN EFECTIVO"
                Case "BC"
                    txtCF_tipo.Tag = c.tipo
                    txtCF_tipo.Text = "CUENTAS EN BANCO"
                Case "TC"
                    txtCF_tipo.Tag = c.tipo
                    txtCF_tipo.Text = "TARJETA DE CREDITO"
            End Select
            txtCF_name.Text = c.descripcion
            txtCF_name.Tag = c.idestado

            Select Case c.codigo
                Case 1
                    txtCF_moneda.Text = "NACIONAL"
                    txtCF_moneda.Tag = 1
                Case 2
                    txtCF_moneda.Text = "EXTRANJERA"
                    txtCF_moneda.Tag = 2
            End Select

            txtCF_cuentaContable.Text = c.cuenta
            SaldoEFMN.DoubleValue = c.importeBalanceMN.GetValueOrDefault
            SaldoEFME.DoubleValue = 0
            pnContenedorCobro.Enabled = True
            'cargarCtasFinan()
        End If
    End Sub

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            If Not IsNothing(cboMesCompra.SelectedValue) Then
                txtPeriodo.Value = GetPeriodoConvertirToDate(cboMesCompra.SelectedValue & "/" & cboAnio.Text)
                If TxtDia.Text.Trim.Length > 0 Then
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                Else
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                    TxtDia.Clear()
                End If
                TxtDia_TextChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        cboAnio_SelectedValueChanged(sender, e)
    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then
            txtCF_tipo.Clear()
            txtCF_name.Clear()
            txtCF_moneda.Clear()
            txtCF_cuentaContable.Clear()
            SaldoEFMN.DoubleValue = 0
            SaldoEFME.DoubleValue = 0
        End If
    End Sub

    Private Sub frmCobrosModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DigitalGauge2.ForeColor = Color.Black
    End Sub
End Class