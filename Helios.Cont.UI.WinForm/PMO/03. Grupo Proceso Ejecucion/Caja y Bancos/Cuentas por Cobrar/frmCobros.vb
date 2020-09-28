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

Public Class frmCobros
    Inherits frmMaster
    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property TipoCobroReclamacion() As String
    Public fecha As DateTime

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        '''''
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ConfiguracionInicio()
        SetRenderer() '  SetRenderer()
        ObtenerTablaGenerales()
        cboTipo.SelectedIndex = -1
        txtFechaTrans.Value = Date.Now
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

    Sub ConfiguracionInicio()
      
        'configurando docking manager
        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.DockControlInAutoHideMode(gpVSBehavior, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 350)
        dockingManager1.SetDockLabel(gpVSBehavior, "DATOS DE COMPROBANTE")
        dockingManager1.CloseEnabled = False
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

    Public Sub CargarEntidadesXtipo()
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        Dim sumatoriaMN As Decimal
        Dim sumatoriaME As Decimal
        Try

            Select Case cboMoneda.SelectedValue
                Case 1
                    If (txtImporteCompramn.Value <= nudDeudaPendientemn.Value) Then
                        lsvTipoCambio.Items.Clear()
                        lsvTipoCambio.Columns.Clear()

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteCompramn.Value, cboDepositoHijo.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(CDec(i.diferTipoCambio).ToString("N2"))
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
                                txtDiferenciaMontos.Value = txtImporteCompramn.Value - sumatoriaMN
                            Case 2
                                txtDiferenciaMontos.Value = txtImporteComprame.Value - sumatoriaME
                        End Select

                        'txtImporteCompramn.Value = sumatoria
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
                        lsvTipoCambio.Items.Clear()

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)
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
                                txtDiferenciaMontos.Value = txtImporteComprame.Value - sumatoriaME
                            Case 2
                                txtDiferenciaMontos.Value = txtImporteCompramn.Value - sumatoriaMN
                        End Select

                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteComprame.Value = 0.0
                        txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
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

        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
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

    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros



        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
        '  estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(cboDepositoHijo.SelectedValue, txtFechaTrans.Value)
        estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(cboDepositoHijo.SelectedValue, New Date(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1))

        If (Not IsNothing(estadoBL)) Then
            cboMoneda.SelectedValue = estadoBL.codigo
            txtCuentaOrigen.Text = estadoBL.cuenta
            nudDeudaPendienteme.Value = estadoSaldoBL.importeBalanceME
            nudDeudaPendientemn.Value = estadoSaldoBL.importeBalanceMN



            Select Case cboMoneda.SelectedValue
                Case 1


                    pnImpMEDisp.Location = New Point(190, 21)
                    pnImpMNDisp.Location = New Point(9, 21)

                    pnImpMEDisp.Visible = False
                    pnImpMNDisp.Visible = True

                    GroupBox5.Visible = True

                    txtImporteCompramn.Value = 0.0
                    txtImporteComprame.Value = 0.0
                    txtTipoCambio.Value = 0
                    txtDiferenciaMontos.Value = 0

                    Select Case tb19.ToggleState
                        Case ToggleButton2.ToggleButtonState.OFF 'dolares
                            pnTipoCambio.Visible = True
                            pnExtranjero.Visible = True
                            pnDiferencia.Visible = True
                            pnNacional.Visible = True
                            pnTipoCambio.Enabled = False
                            pnExtranjero.Enabled = True
                            pnTipoCambio.Location = New Point(220, 23)
                            pnNacional.Location = New Point(340, 23)
                            pnExtranjero.Location = New Point(20, 23)
                            pnDiferencia.Location = New Point(540, 23)
                            PictureBox5.Visible = True
                            pnNacional.Enabled = False
                            txtTipoCambio.Value = TmpTipoCambioTransaccionVenta
                            pnContenedorCobro.Enabled = True

                            colPagoME.Visible = True
                            colME.Visible = True
                            colSaldoME.Visible = True

                            colMN.Visible = False
                            colSaldoMN.Visible = False
                            colPagoMN.Visible = False


                        Case ToggleButton2.ToggleButtonState.ON 'soles
                            pnNacional.Visible = True
                            pnTipoCambio.Visible = False
                            pnExtranjero.Visible = False
                            pnDiferencia.Visible = False
                            pnTipoCambio.Location = New Point(280, 23)
                            pnNacional.Location = New Point(50, 23)
                            pnExtranjero.Location = New Point(420, 23)
                            txtTipoCambio.Value = lblTipoCambio.Text
                            pnContenedorCobro.Enabled = True
                            pnNacional.Enabled = True
                            pnExtranjero.Enabled = False
                            pnSaldoME.Visible = False
                            txtTipoCambio.Value = TmpTipoCambio
                            pnContenedorCobro.Enabled = True

                            colPagoME.Visible = False
                            colME.Visible = False
                            colSaldoME.Visible = False

                            colMN.Visible = True
                            colSaldoMN.Visible = True
                            colPagoMN.Visible = True

                    End Select

                Case 2

                    pnTipoCambio.Location = New Point(280, 23)
                    pnImpMEDisp.Location = New Point(9, 21)
                    pnImpMNDisp.Location = New Point(190, 21)

                    pnImpMEDisp.Visible = True
                    pnImpMNDisp.Visible = False

                    GroupBox5.Visible = True

                    txtImporteCompramn.Value = 0.0
                    txtImporteComprame.Value = 0.0
                    txtTipoCambio.Value = 0
                    txtDiferenciaMontos.Value = 0

              

                    Select Case tb19.ToggleState
                        Case ToggleButton2.ToggleButtonState.OFF 'dolares
                            pnTipoCambio.Visible = False
                            pnExtranjero.Visible = True
                            pnNacional.Visible = True
                            pnDiferencia.Visible = False
                            pnNacional.Visible = False

                            pnNacional.Location = New Point(420, 23)
                            pnExtranjero.Location = New Point(50, 23)
                            pnDiferencia.Location = New Point(650, 25)

                            txtTipoCambio.Value = lblTipoCambio.Text
                            pnSaldoME.Visible = True
                            pnContenedorCobro.Enabled = True
                            txtTipoCambio.Value = TmpTipoCambio

                            colPagoME.Visible = True
                            colME.Visible = True
                            colSaldoME.Visible = True

                            colMN.Visible = False
                            colSaldoMN.Visible = False
                            colPagoMN.Visible = False

                        Case ToggleButton2.ToggleButtonState.ON 'soles

                            pnNacional.Location = New Point(50, 23)
                            pnExtranjero.Location = New Point(420, 23)
                            pnDiferencia.Location = New Point(580, 23)

                            pnTipoCambio.Visible = True
                            pnExtranjero.Visible = True
                            pnDiferencia.Visible = False
                            txtTipoCambio.Value = 0.0
                            pnTipoCambio.Enabled = False
                            pnExtranjero.Enabled = False
                            pnNacional.Enabled = True
                            pnSaldoME.Visible = True
                            pnContenedorCobro.Enabled = True
                            txtTipoCambio.Value = TmpTipoCambioTransaccionCompra

                            colPagoME.Visible = False
                            colME.Visible = False
                            colSaldoME.Visible = False

                            colMN.Visible = True
                            colSaldoMN.Visible = True
                            colPagoMN.Visible = True

                    End Select
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
                cboMoneda.SelectedValue = .moneda
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

        cboEntidades.ValueMember = "codigoDetalle"
        cboEntidades.DisplayMember = "descripcion"
        cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
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
              .usuarioActualizacion = usuario.idUsuario}

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
        nAsiento.periodo = String.format("{0:00}", txtPeriodo.value.month) & "/" & txtPeriodo.value.year
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFechaTrans.Value
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



                nAsiento.movimiento.Add(AS_HaberClienteReclamacion(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                nAsiento.movimiento.Add(AS_DebeCajaReclamacion("1629", "OTRAS", dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))



            End If
        Next

        Select Case cboMoneda.SelectedValue
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
        nAsiento.periodo = String.format("{0:00}", txtPeriodo.value.month) & "/" & txtPeriodo.value.year
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFechaTrans.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        nAsiento.importeMN = txtImporteCompramn.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtImporteComprame.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = usuario.idUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then



                nAsiento.movimiento.Add(AS_HaberCliente(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                nAsiento.movimiento.Add(AS_DebeCaja(lblCuentaProveedor, lblNomProveedor, dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))


            End If
        Next

        Select Case cboMoneda.SelectedValue
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
        Try

            With ndocumento
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                .tipoDoc = "9901"
                .fechaProceso = txtFechaTrans.Value
                .nroDoc = txtNumeroCompr.Text.Trim
                .idOrden = Nothing
                .moneda = cboMoneda.SelectedValue
                .idEntidad = CInt(txtEntidad.Tag)
                .entidad = txtEntidad.Text
                .nrodocEntidad = txtNroDocEntidad.Text
                .tipoEntidad = txtTipoEntidad.Text
                .tipoOperacion = "9922"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = txtFechaTrans.Value
            End With

            With ndocumentoCaja
                .movimientoCaja = MovimientoCaja.CobroCliente
                .codigoLibro = "1"
                .periodo = String.format("{0:00}", txtPeriodo.value.month) & "/" & txtPeriodo.value.year
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = MovimientoCaja.EntradaDinero
                .codigoProveedor = lblIdProveedor
                .tipoOperacion = "9922"
                .moneda = cboMoneda.SelectedValue
                .fechaProceso = fecha
                .fechaCobro = fecha
                .tipoDocPago = "9901"
                .formapago = cboTipoDoc.SelectedValue
                If cboTipoDoc.SelectedValue = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "005" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "006" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
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
                .entidadFinanciera = cboDepositoHijo.SelectedValue
                .tipoCambio = txtTipoCambio.Value
                .montoSoles = txtImporteCompramn.Value
                .montoUsd = txtImporteComprame.Value
                .glosa = Glosa()
                .usuarioModificacion = usuario.IDUsuario
                .fechaModificacion = txtFechaTrans.Value
                .DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
            End With

            ndocumento.documentoCaja = ndocumentoCaja


            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
                    ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                    ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

                    Select Case cboMoneda.SelectedValue
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
                    ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                    ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                    ndocumentoCajaDetalle.fechaModificacion = txtFechaTrans.Value
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
            lblEstado.Image = My.Resources.ok4
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
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

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
                .fechaProceso = txtFechaTrans.Value
                .nroDoc = txtNumeroCompr.Text.Trim
                .idOrden = Nothing
                .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
                .idEntidad = CInt(txtEntidad.Tag)
                .entidad = txtEntidad.Text
                .tipoEntidad = "CL"
                .nrodocEntidad = txtNroDocEntidad.Text
                .tipoOperacion = "9908"
                .usuarioActualizacion = usuario.idUsuario
                .fechaActualizacion = txtFechaTrans.Value
            End With

            With ndocumentoCaja
                .movimientoCaja = MovimientoCaja.CobroCliente
                .codigoLibro = "1"
                .periodo = String.format("{0:00}", txtPeriodo.value.month) & "/" & txtPeriodo.value.year
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = MovimientoCaja.EntradaDinero
                .codigoProveedor = lblIdProveedor
                .tipoOperacion = "9908"
                .moneda = cboMoneda.SelectedValue
                .fechaProceso = fecha
                .fechaCobro = fecha
                .tipoDocPago = "9901"
                .formapago = cboTipoDoc.SelectedValue
                If cboTipoDoc.SelectedValue = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "005" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = txtFechaEmision.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "006" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
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
                .entidadFinanciera = cboDepositoHijo.SelectedValue
                .tipoCambio = txtTipoCambio.Value
                .montoSoles = txtImporteCompramn.Value
                .montoUsd = txtImporteComprame.Value
                .glosa = Glosa()
                .usuarioModificacion = usuario.IDUsuario
                .fechaModificacion = txtFechaTrans.Value
                .DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
            End With

            ndocumento.documentoCaja = ndocumentoCaja


            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
                    ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                    ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

                    Select Case cboMoneda.SelectedValue
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
                    ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                    ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                    ndocumentoCajaDetalle.fechaModificacion = txtFechaTrans.Value
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
            lblEstado.Image = My.Resources.ok4
            Dispose()
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

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        txtImporteComprame.Value = 0
        txtImporteCompramn.Value = 0
        txtTipoCambio.Value = 0
        txtDiferenciaMontos.Value = 0
        txtNumOper.Clear()
        cboDepositoHijo.SelectedValue = -1
        cboMoneda.SelectedValue = -1
        txtCuentaCorriente.Clear()
        nudDeudaPendienteme.Value = 0
        nudDeudaPendientemn.Value = 0
        cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim value As Object = Me.cboDepositoHijo.SelectedValue

        If IsNumeric(value) Then
            txtImporteComprame.Value = 0
            txtImporteCompramn.Value = 0
            txtTipoCambio.Value = 0
            txtDiferenciaMontos.Value = 0
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            cargarDatosCuenta(CInt(value))
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

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click
        Tag = 1
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
                If nudDeudaPendienteme.Text.Trim.Length > 0 Then
                    Me.PopupControlContainer3.ParentControl = Me.txtImporteCompramn
                    Me.PopupControlContainer3.ShowPopup(Point.Empty)
                    CargarDiferenciasdeImporte()
                End If
            Case 2
                If nudDeudaPendienteme.Text.Trim.Length > 0 Then
                    If Not Me.PopupControlContainer3.IsShowing() Then
                        ' Let the popup align around the source textBox.
                        Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
                        ' Passing Point.Empty will align it automatically around the above ParentControl.
                        Me.PopupControlContainer1.ShowPopup(Point.Empty)
                    End If
                    Me.PopupControlContainer3.ParentControl = Me.txtImporteComprame
                    Me.PopupControlContainer3.ShowPopup(Point.Empty)
                    CargarDiferenciasdeImporte()
                End If
        End Select
    End Sub

    Private Sub txtImporteCompramn_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteCompramn.ValueChanged
        Select Case cboMoneda.SelectedValue
            Case 1

                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    'ME - ME
                    If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        If txtTipoCambio.Value > 0 Then
                            txtImporteComprame.Value = txtImporteCompramn.Value / txtTipoCambio.Value
                            'pnDiferencia.Visible = True
                            CalculoSoles()
                            CalculoGRID()
                        End If
                        'MN - ME
                    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        'pnDiferencia.Visible = True
                        'CalculoSoles()
                        If txtTipoCambio.Value > 0 Then
                            CalculoGRID()
                            CargarDiferenciasdeImporte()
                        End If


                        'mn - mn
                    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
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
                        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
                            CalculoGRID()
                        End If

                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    CalculoGRID()
                End If

            Case 2

                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    'ME - ME
                    If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        If txtTipoCambio.Value > 0 Then
                            txtImporteComprame.Value = txtImporteCompramn.Value / txtTipoCambio.Value
                            'pnDiferencia.Visible = True
                            CalculoSoles()
                            CalculoGRID()
                        End If
                        'MN - ME
                    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                        'pnDiferencia.Visible = True
                        'CalculoSoles()
                        If txtTipoCambio.Value > 0 Then
                            CalculoGRID()
                        End If


                        'mn - mn
                    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
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
                    ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
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

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        If (cboDepositoHijo.SelectedValue > -1) Then
            Select Case cboMoneda.SelectedValue
                Case 1
                    txtImporteCompramn_ValueChanged(sender, e)
                Case 2
                    txtImporteComprame_ValueChanged(sender, e)
            End Select

        End If
    End Sub

    Private Sub txtImporteComprame_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteComprame.ValueChanged
        Select Case cboMoneda.SelectedValue
            Case 2
                If (CDec(txtImporteComprame.Value <= CDec(btnSaldoCobro.Text))) Then
                    If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                        'ME - ME
                        If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
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
                        ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                            If txtTipoCambio.Value > 0 Then
                                txtImporteComprame.Value = txtImporteCompramn.Value / txtTipoCambio.Value
                                'pnDiferencia.Visible = True
                                CalculoSoles()
                                CalculoGRID()
                            End If
                            'MN - MN
                        ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
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
                        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then

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
                        If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
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
                        ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
                            If txtTipoCambio.Value > 0 Then
                                txtImporteCompramn.Value = CDec(txtImporteComprame.Value * txtTipoCambio.Value)
                                CalculoSoles()
                                CalculoGRID()
                            End If
                            'MN - MN
                        ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
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
                        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then

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
        If txtImporteCompramn.Value > 0 Then

            If Not cboDepositoHijo.Text.Length > 0 Then
                lblEstado.Text = "Ingrese la entidad financiera."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboDepositoHijo.Select()
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

                If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de cuenta."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtCuentaCorriente.Select()
                    Exit Sub
                End If

            ElseIf cboTipoDoc.SelectedValue = "005" Then

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

            ElseIf cboTipoDoc.SelectedValue = "006" Then

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

            If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                If TipoCobroReclamacion = "RECLAMACION" Then
                    GrabarReclamacion()
                Else
                    Grabar()
                End If



            ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                '   Editar()
            End If
        Else
            lblEstado.Text = "Ingresar el importe a pagar!"
            'lblEstado.Image = My.Resources.warning2
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If Not Me.PopupControlContainer1.IsShowing() Then
            ' Let the popup align around the source textBox.
            Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
            ' Passing Point.Empty will align it automatically around the above ParentControl.
            Me.PopupControlContainer1.ShowPopup(Point.Empty)
        End If

        If nudDeudaPendienteme.Text.Trim.Length > 0 Then
            Me.PopupControlContainer1.ParentControl = Me.txtTipoCambio
            Me.PopupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo()
        End If
    End Sub

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

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dispose()
    End Sub

 
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GradientPanel6_Enter(sender As Object, e As EventArgs) Handles GradientPanel6.Enter

    End Sub

    Private Sub frmCobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub
End Class