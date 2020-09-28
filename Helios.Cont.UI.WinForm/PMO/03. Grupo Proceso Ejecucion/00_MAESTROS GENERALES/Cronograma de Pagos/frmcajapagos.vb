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
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmcajapagos
    Inherits frmMaster

    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property lblTipoCambioOriginal() As Decimal
    Public Property listaPagosCompra As List(Of documentocompra)


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'GridCFG(dgvPagosVarios)
        'GridCFG2(GridGroupingControl1)
        'GetTableGridConcepto2()
        'GridCFG(dgvDistribucionME)
        ObtenerTablaGenerales()
        txtFechaTrans.Value = Date.Now
        'Me.WindowState = FormWindowState.Maximized
        'txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
        'txtPeriodo.Value = PeriodoGeneral
    End Sub

#Region "metodos"


    Public Function movimientos()
        Dim lista As New List(Of movimiento)


        For Each r As Record In dgvDiferencia.Table.Records
            Dim n As New movimiento
            n.monto = r.GetValue("difMNCajaMN")
            lista.Add(n)
        Next

        Return lista
    End Function


    'Public Class caja

    '    Public Property depositohijo() As String
    '    Public Property moneda() As String
    '    Public Property tipoDoc() As String
    '    Public Property bancoEntidad() As String
    '    Public Property txtNumOper() As String
    '    Public Property CuentaCorriente() As String
    '    Public Property DiferenciaMontos() As Decimal
    '    Public Property importe() As Decimal
    '    Public Property importeme() As Decimal
    '    Public Property tipocambio() As Decimal
    '    Public Property cuenta() As String

    'End Class


    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        cboEntidades.ValueMember = "codigoDetalle"
        cboEntidades.DisplayMember = "descripcion"
        cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
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

            For Each j In listaPagosCompra

                ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(j.importeUS, cboDepositoHijo.SelectedValue)

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
                    ' For Each i In listaPagosCompra

                    For Each i In ListadocumentoCajaEtalle
                        Dim dr As DataRow = dt.NewRow()
                        If (i.montoSoles > 0 And i.montoUsd > 0) Then
                            dr(0) = i.idDocumento
                            dr(1) = i.diferTipoCambio
                            dr(2) = i.montoSoles
                            dr(3) = i.montoUsd
                            dr(4) = j.tipocambio
                            sumatoriaMN = CDec(i.montoUsd * j.tipocambio).ToString("N2")
                            sumatoriaME = CDec(i.montoUsd)
                            dr(5) = sumatoriaMN
                            dr(6) = sumatoriaME
                            DifsumatoriaMN = CDec((j.tipocambio - i.diferTipoCambio) * i.montoUsd).ToString("N2")
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



            Next



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

                ' tipoCAmbio = CDec(txtImporteCompramn.Value / lblDeudaPendienteme.Text)
                tipoCAmbio = txtTipoCambio.Value
                dr(0) = 0
                dr(1) = txtTipoCambio.Value
                dr(2) = txtImporteCompramn.Value
                dr(3) = CDec(txtImporteCompramn.Value / (tipoCAmbio)).ToString("N2")
                dr(4) = txtTipoCambio.Value
                sumatoriaME = CDec(txtImporteCompramn.Value / tipoCAmbio).ToString("N2")
                sumatoriaMN = ((sumatoriaME) * txtTipoCambio.Value)


                dr(5) = sumatoriaMN
                dr(6) = sumatoriaME
                DifsumatoriaMN = CDec(sumatoriaMN - txtImporteCompramn.Value).ToString("N2")
                DifsumatoriaME = CDec(sumatoriaME - CDec(txtImporteCompramn.Value / tipoCAmbio)).ToString("N2")
                dr(7) = DifsumatoriaMN
                dr(8) = DifsumatoriaME

                dt.Rows.Add(dr)
                dgvDiferencia.DataSource = dt

                txtDiferenciaMontos.Value = DifsumatoriaMN
            Else
                For Each j In listaPagosCompra
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = 0
                    dr(1) = txtTipoCambio.Value
                    dr(2) = j.importeTotal
                    dr(3) = CDec(j.importeTotal / txtTipoCambio.Value).ToString("N2")
                    dr(4) = j.tipocambio
                    sumatoriaMN = CDec((CDec(j.importeTotal / txtTipoCambio.Value) * j.tipocambio))
                    sumatoriaME = CDec(j.importeTotal / txtTipoCambio.Value).ToString("N2")

                    dr(5) = sumatoriaMN
                    dr(6) = sumatoriaME
                    DifsumatoriaMN = CDec(sumatoriaMN - j.importeTotal).ToString("N2")
                    DifsumatoriaME = CDec(sumatoriaME - CDec(j.importeTotal / txtTipoCambio.Value)).ToString("N2")
                    dr(7) = DifsumatoriaMN
                    dr(8) = DifsumatoriaME

                    dt.Rows.Add(dr)
                    dgvDiferencia.DataSource = dt

                    txtDiferenciaMontos.Value = DifsumatoriaMN
                Next
            End If



        ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then


            For Each j In listaPagosCompra


                ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(j.importeUS, cboDepositoHijo.SelectedValue)

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
            Next
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
                nudDeudaPendienteme.Value = estadoSaldoBL.importeBalanceME
                nudDeudaPendientemn.Value = estadoSaldoBL.importeBalanceMN
                'btOperacion.Visible = True
                'txtTipoCambio.Value = TmpTipoCambioTransaccionVenta
                cboTipoDoc.SelectedValue = "001"
                Select Case cboMoneda.SelectedValue
                    Case 1
                        pnImpMEDisp.Location = New Point(170, 21)
                        pnImpMNDisp.Location = New Point(9, 21)
                        txtImporteComprame.Enabled = True
                        'txtImporteCompramn.Enabled = False
                        PictureBox5.Visible = False
                        pnDiferencia.Visible = False
                        'txtImporteCompramn.Value = 0.0
                        'txtImporteComprame.Value = 0.0
                        'txtDiferenciaMontos.Value = 0

                        Select Case tb19.ToggleState
                            Case ToggleButton2.ToggleButtonState.OFF 'dolares
                                'pnSaldoME.Visible = True
                                'pnSaldoMN.Visible = True
                                pnNacional.Location = New Point(420, 25)
                                pnExtranjero.Location = New Point(49, 25)
                                pnTipoCambio.Visible = True
                                pnExtranjero.Visible = True
                                pnDiferencia.Visible = True
                                pnDiferencia.Location = New Point(650, 25)
                                pnTipoCambio.Enabled = False
                                pnImpMEDisp.Visible = False
                                'pnTipoCambioCompra.Visible = True
                                pnTipoCambio.Visible = True
                                pnDiferencia.Visible = True
                                pnExtranjero.Visible = True
                                'colMN.Visible = False
                                'colSaldoMN.Visible = False
                                'colPagoMN.Visible = False
                                pnImpMNDisp.Visible = True
                                'colME.Visible = True
                                'colSaldoME.Visible = True
                                'colPagoME.Visible = True
                                'PanelDetallePagos.Enabled = True
                            Case ToggleButton2.ToggleButtonState.ON 'soles
                                'pnSaldoME.Visible = False
                                'pnNacional.Location = New Point(49, 25)
                                pnNacional.Location = New Point(5, 24)
                                pnExtranjero.Location = New Point(378, 24)
                                txtImporteCompramn.Enabled = True
                                pnTipoCambio.Visible = True
                                pnExtranjero.Visible = True
                                pnDiferencia.Visible = False
                                pnTipoCambio.Enabled = False
                                'txtTipoCambio.Value = TmpTipoCambio
                                pnImpMEDisp.Visible = False
                                'pnTipoCambioCompra.Visible = False
                                pnTipoCambio.Visible = False
                                pnDiferencia.Visible = False
                                pnExtranjero.Visible = False
                                ' colME.Visible = False
                                'colSaldoME.Visible = False
                                'colPagoME.Visible = False
                                'PanelDetallePagos.Enabled = True
                        End Select

                    Case 2
                        pnImpMEDisp.Location = New Point(9, 21)
                        pnImpMNDisp.Location = New Point(170, 21)
                        PictureBox5.Visible = True
                        pnDiferencia.Visible = True
                        'txtImporteCompramn.Value = 0.0
                        'txtImporteComprame.Value = 0.0
                        txtDiferenciaMontos.Value = 0
                        Select Case tb19.ToggleState
                            Case ToggleButton2.ToggleButtonState.OFF 'dolares
                                'pnSaldoMN.Visible = False
                                pnTipoCambio.Visible = True
                                pnExtranjero.Visible = True
                                pnDiferencia.Visible = True
                                pnExtranjero.Enabled = True
                                pnNacional.Enabled = False
                                pnExtranjero.Location = New Point(49, 25)
                                pnNacional.Location = New Point(430, 25)
                                pnDiferencia.Location = New Point(650, 25)
                                ' txtTipoCambio.Value = TmpTipoCambio
                                pnTipoCambio.Enabled = False
                                pnImpMNDisp.Visible = False
                                'pnTipoCambioCompra.Visible = True
                                pnTipoCambio.Visible = True
                                pnDiferencia.Visible = True
                                pnExtranjero.Visible = True
                                'PanelDetallePagos.Enabled = True
                                'colMN.Visible = False
                                ' colSaldoMN.Visible = False
                                ' colPagoMN.Visible = False
                                'colME.Visible = True
                                'colSaldoME.Visible = True
                                'colPagoME.Visible = True
                            Case ToggleButton2.ToggleButtonState.ON 'soles
                                'pnSaldoME.Visible = True
                                pnTipoCambio.Visible = True
                                pnExtranjero.Visible = True
                                pnDiferencia.Visible = True
                                pnNacional.Location = New Point(5, 24)
                                pnExtranjero.Location = New Point(378, 24)
                                pnDiferencia.Location = New Point(592, 24)
                                pnTipoCambio.Enabled = False
                                pnNacional.Enabled = True
                                pnExtranjero.Enabled = False
                                pnImpMEDisp.Visible = True
                                'pnTipoCambioCompra.Visible = True
                                pnDiferencia.Visible = True
                                pnExtranjero.Visible = True
                                ' colMN.Visible = True
                                'colSaldoMN.Visible = True
                                ' colPagoMN.Visible = True
                                'colME.Visible = False
                                'colSaldoME.Visible = False
                                'colPagoME.Visible = False
                                txtImporteCompramn.Enabled = True
                                ' PanelDetallePagos.Enabled = True
                        End Select
                End Select
            End If
        End If
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

    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try
            Me.cboDepositoHijo.DataSource =
                  estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = strBusqueda,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Me.cboDepositoHijo.DisplayMember = "descripcion"
            Me.cboDepositoHijo.ValueMember = "idestado"
            cboDepositoHijo.SelectedValue = -1
            cboDepositoHijo.Tag = 0

            cboMoneda.ValueMember = "codigoDetalle"
            cboMoneda.DisplayMember = "descripcion"
            cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            cboMoneda.SelectedValue = -1

        Catch ex As Exception

        End Try
    End Sub


#End Region

    Private Sub frmcajapagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click



        Select Case cboMoneda.SelectedValue
            Case 1
                If txtImporteCompramn.Value > nudDeudaPendientemn.Value Then
                    MessageBox.Show("El importe compra execede al monto de la cuenta financiera actual!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If Not txtNumOper.Text.Trim.Length > 0 Then
                        MessageBox.Show("Escriba un numero de Operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    If Not txtCuentaCorriente.Text.Trim.Length > 0 Then

                        MessageBox.Show("Escriba una cuenta corriente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Dim lista As New List(Of movimiento)

                    Dim n As New CajaInfo
                    n.depositohijo = cboDepositoHijo.SelectedValue
                    n.CajaNombre = cboDepositoHijo.Text
                    n.moneda = cboMoneda.SelectedValue
                    n.cuenta = txtCuentaOrigen.Text
                    n.tipoDoc = cboTipoDoc.SelectedValue
                    n.bancoEntidad = cboEntidades.SelectedValue
                    n.txtNumOper = txtNumOper.Text
                    n.CuentaCorriente = txtCuentaCorriente.Text
                    n.DiferenciaMontos = txtDiferenciaMontos.Value
                    n.importe = txtImporteCompramn.Value
                    n.importeme = txtImporteComprame.Value
                    n.tipocambio = txtTipoCambio.Value
                    n.fechatransferencia = txtFechaTrans.Value

                    Me.Tag = n


                    Close()
                End If
            Case 2
                If txtImporteComprame.Value > nudDeudaPendienteme.Value Then
                    MessageBox.Show("El importe compra execede al monto de la cuenta financiera actual!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else


                    If Not txtNumOper.Text.Trim.Length > 0 Then
                        MessageBox.Show("Escriba un numero de Operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    If Not txtCuentaCorriente.Text.Trim.Length > 0 Then

                        MessageBox.Show("Escriba una cuenta corriente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Dim lista As New List(Of movimiento)

                    Dim n As New CajaInfo
                    n.depositohijo = cboDepositoHijo.SelectedValue
                    n.moneda = cboMoneda.SelectedValue
                    n.cuenta = txtCuentaOrigen.Text
                    n.tipoDoc = cboTipoDoc.SelectedValue
                    n.bancoEntidad = cboEntidades.SelectedValue
                    n.txtNumOper = txtNumOper.Text
                    n.CuentaCorriente = txtCuentaCorriente.Text
                    n.DiferenciaMontos = txtDiferenciaMontos.Value
                    n.importe = txtImporteCompramn.Value
                    n.importeme = txtImporteComprame.Value
                    n.tipocambio = txtTipoCambio.Value
                    n.fechatransferencia = txtFechaTrans.Value

                    Me.Tag = n


                    Close()


                End If
        End Select

        

    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        'txtImporteComprame.Value = 0
        'txtImporteCompramn.Value = 0
        'txtTipoCambio.Value = 0
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

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click
        cboDepositoHijo.Tag = 1
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

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim value As Object = Me.cboDepositoHijo.SelectedValue
        ' txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        ' txtDescripcion.Clear()
        txtNumOper.Clear()
        'txtFondoME.Value = 0.0
        'txtFondoMN.Value = 0.0
        nudDeudaPendientemn.Value = 0
        nudDeudaPendienteme.Value = 0

        If (Me.cboDepositoHijo.Items.Count = 1) Then
            If IsNumeric(value) Then
                cargarDatosCuenta(CInt(value))
                '  CargarDiferenciasdeImporte()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

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
End Class