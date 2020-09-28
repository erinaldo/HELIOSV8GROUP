Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports System.ComponentModel
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmMasterCajas
    Inherits frmMaster

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCajasAssig) ' modelo de los datagrid 
        GridCFG(dgvEF)
        GridCFG(dgvUsuarios)
        GridCFG(dgvMovAdic)
        GridCFG(dgvAnticipos)
        GridCFGKardex(dgvKardex2)
        OptimizeGrid(dgvKardex2)
        GridCFG(dgvEntidadFinanciera)
        GridCFGKardex(dgvKardexME)
        GridCFGKardex(dgvReporteCaja)
        CargarDatosInformativos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)
        lblPeriodo.Text = "Período: " & PeriodoGeneral

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
    Dim utilidadMN As Decimal = 0
    Dim utilidadME As Decimal = 0

#Region "METODOS KARDEX"
    Dim SaldoSoles As Decimal = 0
    Dim SaldoUSD As Decimal = 0

    Dim SaldoSolesNN As Decimal = 0
    Dim SaldoUSDNN As Decimal = 0

    Dim SaldoSolesNN1 As Decimal = 0
    Dim SaldoUSDNN1 As Decimal = 0

    Dim ListaEstadoFinancierosMaster As New List(Of estadosFinancieros)
    Dim ListaEstadosFiancieros As New List(Of estadosFinancieros)
    Dim ListaEstadosFiancierosME As New List(Of estadosFinancieros)

    Private Sub OptimizeGrid(gridGroupingControl As GridGroupingControl)
        ' Couple settings to perform better:
        gridGroupingControl.Engine.CounterLogic = EngineCounters.FilteredRecords
        gridGroupingControl.Engine.AllowedOptimizations = EngineOptimizations.DisableCounters Or EngineOptimizations.RecordsAsDisplayElements Or EngineOptimizations.VirtualMode
        gridGroupingControl.TableOptions.VerticalPixelScroll = False
        gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthStrategy = GridColumnsMaxLengthStrategy.FirstNRecords
        gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthFirstNRecords = 100
    End Sub

    Sub GridCFGKardex(GGC As GridGroupingControl)
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
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left
        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Private Sub GetTableXperiodo(intIdCaja As Integer, Periodo As String)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing

        Dim dt As New DataTable("Movimientos período - " & PeriodoGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0

        Select Case txtMonedaKardex.Text

            Case "NACIONAL"
                dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer))) '0
                dt.Columns.Add(New DataColumn("fecha", GetType(String))) '1
                'lower case p
                dt.Columns.Add(New DataColumn("UsuarioCaja", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoUsuario", GetType(String))) '3
                dt.Columns.Add(New DataColumn("mov", GetType(String)))
                dt.Columns.Add(New DataColumn("item", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoDoc", GetType(String))) '6
                dt.Columns.Add(New DataColumn("numero", GetType(String)))
                dt.Columns.Add(New DataColumn("moneda", GetType(String))) '8
                dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("entradaMN", GetType(Decimal))) '10
                dt.Columns.Add(New DataColumn("entradaME", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("salidaMN", GetType(Decimal))) '12
                dt.Columns.Add(New DataColumn("salidaME", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal))) '14
                dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))

                dgvKardex2.Table.TableDescriptor.Columns("moneda").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("tipoCambio").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("entradaME").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("salidaME").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("saldoME").Width = 0

                ImporteSaldo = 0
                ImporteSaldoME = 0
                'canSaldo = 0

                For Each i In documentoCajaSA.ObtenerCajaOnline(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, String.Format("{0:00}", CInt(txtPeriodo.Value.Month)), txtPeriodo.Value.Year, intIdCaja)
                    importeDeficit = 0
                    importeDeficitme = 0

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.idDocumento
                    dr(1) = i.fechaCobro
                    dr(2) = i.dni
                    dr(3) = i.tipousuario
                    Select Case i.tipoMovimiento
                        Case "DC"

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo += CDec(i.montoSoles)
                                ImporteSaldoME += CDec(i.montoUsd)
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0

                                ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.IdEntidadFinanciera, dt)

                                'ImporteSaldo = ImporteSaldo + saldoImporteAnual
                                'ImporteSaldoME = ImporteSaldoME + saldoImporteAnualME
                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo = CDec(i.montoSoles) + ImporteSaldo
                                ImporteSaldoME = CDec(i.montoUsd) + ImporteSaldoME
                            End If

                            dr(10) = i.montoSoles
                            dr(11) = i.montoUsd
                            dr(12) = 0
                            dr(13) = 0
                            dr(14) = ImporteSaldo
                            dr(15) = ImporteSaldoME

                            dr(4) = "ENTRADA"

                        Case "PG"
                            Dim co As Decimal = 0
                            Dim come As Decimal = 0
                            co = i.montoSoles
                            come = i.montoUsd

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo -= co
                                ImporteSaldoME -= come
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.IdEntidadFinanciera, dt)

                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo -= CDec(i.montoSoles)
                                ImporteSaldoME -= CDec(i.montoUsd)
                            End If
                            dr(10) = 0
                            dr(11) = 0
                            dr(12) = i.montoSoles
                            dr(13) = i.montoUsd
                            dr(14) = ImporteSaldo
                            dr(15) = ImporteSaldoME
                            dr(4) = "SALIDA"

                    End Select
                    dr(5) = i.DetalleItem
                    dr(6) = i.tipoDocPago
                    dr(7) = i.NumeroDocumento
                    dr(8) = i.moneda

                    If (Not IsNothing(i.tipoCambio)) Then
                        dr(9) = i.tipoCambio
                    Else
                        dr(9) = i.difTipoCambio
                    End If
                    producto = i.IdEntidadFinanciera
                    productoCache = i.NombreCaja
                    dt.Rows.Add(dr)
                Next
                dgvKardex2.DataSource = dt
            Case "EXTRANJERA"
                dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
                dt.Columns.Add(New DataColumn("fecha", GetType(String)))
                'lower case p
                dt.Columns.Add(New DataColumn("UsuarioCaja", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoUsuario", GetType(String)))
                dt.Columns.Add(New DataColumn("mov", GetType(String)))
                dt.Columns.Add(New DataColumn("item", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
                dt.Columns.Add(New DataColumn("numero", GetType(String)))
                dt.Columns.Add(New DataColumn("moneda", GetType(String)))
                dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("entradaMN", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("entradaME", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("salidaMN", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("salidaME", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))

                dgvKardex2.Table.TableDescriptor.Columns("moneda").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("tipoCambio").Width = 80
                dgvKardex2.Table.TableDescriptor.Columns("entradaME").Width = 90
                dgvKardex2.Table.TableDescriptor.Columns("salidaME").Width = 90
                dgvKardex2.Table.TableDescriptor.Columns("saldoME").Width = 90


                ImporteSaldo = 0
                ImporteSaldoME = 0
                'canSaldo = 0

                For Each i In documentoCajaSA.ObtenerCajaOnline(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, String.Format("{0:00}", CInt(txtPeriodo.Value.Month)), txtPeriodo.Value.Year, intIdCaja)
                    importeDeficit = 0
                    importeDeficitme = 0

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.idDocumento
                    dr(1) = i.fechaCobro
                    dr(2) = i.dni
                    dr(3) = i.tipousuario
                    Select Case i.tipoMovimiento
                        Case "DC"

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo += CDec(i.montoSoles)
                                ImporteSaldoME += CDec(i.montoUsd)
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0

                                ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.IdEntidadFinanciera, dt)

                                'ImporteSaldo = ImporteSaldo + saldoImporteAnual
                                'ImporteSaldoME = ImporteSaldoME + saldoImporteAnualME
                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo = CDec(i.montoSoles) + ImporteSaldo
                                ImporteSaldoME = CDec(i.montoUsd) + ImporteSaldoME
                            End If

                            dr(10) = i.montoSoles
                            dr(11) = i.montoUsd
                            dr(12) = 0
                            dr(13) = 0
                            dr(14) = ImporteSaldo
                            dr(15) = ImporteSaldoME

                            dr(4) = "ENTRADA"

                        Case "PG"
                            Dim co As Decimal = 0
                            Dim come As Decimal = 0
                            co = i.montoSoles
                            come = i.montoUsd

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo -= co
                                ImporteSaldoME -= come
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.IdEntidadFinanciera, dt)

                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo -= CDec(i.montoSoles)
                                ImporteSaldoME -= CDec(i.montoUsd)
                            End If
                            dr(10) = 0
                            dr(11) = 0
                            dr(12) = i.montoSoles
                            dr(13) = i.montoUsd
                            dr(14) = ImporteSaldo
                            dr(15) = ImporteSaldoME
                            dr(4) = "SALIDA"

                    End Select
                    dr(5) = i.DetalleItem
                    dr(6) = i.tipoDocPago
                    dr(7) = i.NumeroDocumento
                    dr(8) = i.moneda

                    If (Not IsNothing(i.tipoCambio)) Then
                        dr(9) = i.tipoCambio
                    Else
                        dr(9) = i.difTipoCambio
                    End If
                    producto = i.IdEntidadFinanciera
                    productoCache = i.NombreCaja
                    dt.Rows.Add(dr)
                Next
                dgvKardex2.DataSource = dt
        End Select






    End Sub

    Private Sub GetTableXperiodoME(intIdCaja As Integer, Periodo As String)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing

        Dim dt As New DataTable("Movimientos período - " & PeriodoGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        'lower case p

        dt.Columns.Add(New DataColumn("tipoOperacion", GetType(String))) '1
        dt.Columns.Add(New DataColumn("fechaEntradaME", GetType(String))) '2
        dt.Columns.Add(New DataColumn("entradaME", GetType(Decimal))) '3
        dt.Columns.Add(New DataColumn("salidaME", GetType(Decimal))) '4
        dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal))) '5
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal))) '6
        dt.Columns.Add(New DataColumn("fechaEntradaMN", GetType(String))) '7
        dt.Columns.Add(New DataColumn("entradaMN", GetType(Decimal))) '8
        dt.Columns.Add(New DataColumn("salidaMN", GetType(Decimal))) '9
        dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal))) '10
        dt.Columns.Add(New DataColumn("ajustesME", GetType(Decimal))) '11
        dt.Columns.Add(New DataColumn("tcOtros", GetType(Decimal))) '12
        dt.Columns.Add(New DataColumn("fechaOtros", GetType(String))) '13
        dt.Columns.Add(New DataColumn("importeOtros", GetType(Decimal))) '14
        dt.Columns.Add(New DataColumn("diferenciaTC", GetType(Decimal))) '15
        dt.Columns.Add(New DataColumn("importeDif", GetType(Decimal))) '16


        ImporteSaldo = 0
        ImporteSaldoME = 0
        'canSaldo = 0

        For Each i In documentoCajaSA.ObtenerCajaOnlineME(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, String.Format("{0:00}", CInt(txtPeriodoME.Value.Month)), txtPeriodoME.Value.Year, intIdCaja)
            importeDeficit = 0
            importeDeficitme = 0

            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            'dr(1) = i.fechaCobro
            'dr(2) = i.dni
            'dr(3) = i.tipousuario
            If (i.tipoMovimiento = "DC") Then
                If producto = i.IdEntidadFinanciera Then
                    productoCache = i.NombreCaja
                    ImporteSaldo += CDec(i.montoSoles)
                    ImporteSaldoME += CDec(i.montoUsd)
                Else
                    importeDeficit = ImporteSaldo
                    importeDeficitme = ImporteSaldoME

                    ImporteSaldo = 0
                    ImporteSaldoME = 0

                    ObtenerSaldoInicioXmesME(txtPeriodoME.Value.Year, txtPeriodoME.Value.Month, i.IdEntidadFinanciera, dt)

                    'ImporteSaldo = ImporteSaldo + saldoImporteAnual
                    'ImporteSaldoME = ImporteSaldoME + saldoImporteAnualME
                    ImporteSaldo = saldoImporteAnual
                    ImporteSaldoME = saldoImporteAnualME

                    ImporteSaldo = CDec(i.montoSoles) + ImporteSaldo
                    ImporteSaldoME = CDec(i.montoUsd) + ImporteSaldoME
                End If


                dr(1) = "ENTRADA"
                dr(2) = i.fechaCobro
                dr(3) = i.montoUsd
                dr(4) = 0
                dr(5) = ImporteSaldoME
                dr(6) = i.tipoCambio
                dr(7) = i.fechaCobro
                dr(8) = i.montoSoles
                dr(9) = 0
                dr(10) = ImporteSaldo
                dr(11) = 0
                dr(12) = 0
                dr(13) = 0
                dr(14) = 0
                dr(15) = 0
                dr(16) = 0

            ElseIf (i.tipoMovimiento = "PG" Or i.tipoMovimiento = "ANT-C") Then
                Dim co As Decimal = 0
                Dim come As Decimal = 0
                co = i.montoSoles
                come = i.montoUsd

                If producto = i.IdEntidadFinanciera Then
                    productoCache = i.NombreCaja
                    ImporteSaldo -= co
                    ImporteSaldoME -= come
                Else
                    importeDeficit = ImporteSaldo
                    importeDeficitme = ImporteSaldoME

                    ImporteSaldo = 0
                    ImporteSaldoME = 0
                    ObtenerSaldoInicioXmesME(txtPeriodoME.Value.Year, txtPeriodoME.Value.Month, i.IdEntidadFinanciera, dt)

                    ImporteSaldo = saldoImporteAnual
                    ImporteSaldoME = saldoImporteAnualME

                    ImporteSaldo -= CDec(i.montoSoles)
                    ImporteSaldoME -= CDec(i.montoUsd)
                End If

                dr(1) = "SALIDA" 'i.tipoDocPago
                dr(2) = i.fechaCobro
                dr(3) = 0
                dr(4) = i.montoUsd
                dr(5) = ImporteSaldoME
                dr(6) = i.tipoCambio
                dr(7) = i.fechaCobro
                dr(8) = 0
                dr(9) = i.montoSoles
                dr(10) = ImporteSaldo
                dr(11) = 0
                dr(12) = 0
                dr(13) = 0
                dr(14) = 0
                dr(15) = 0
                dr(16) = 0


                'dr(12) = CDec(i.difTipoCambio)
                'dr(13) = i.fechaProceso
                'dr(14) = CDec(i.saldoMN)
                'dr(15) = CDec(i.difTipoCambio - i.tipoCambio)
                'dr(16) = CDec(i.saldoMN - i.montoSoles)
                'CDec(i.saldoMN - i.montoSoles)

            End If

            'dr(6) = i.tipoCambio

            producto = i.IdEntidadFinanciera
            productoCache = i.NombreCaja

            dt.Rows.Add(dr)

        Next
        ObtenerEncabezadosME(dt)
        ObtenerSaldoFinXmes(intIdCaja, dt)
        dgvKardexME.DataSource = dt
    End Sub

    'Dim saldoCantidadAnual As Decimal = 0
    Dim saldoImporteAnual As Decimal = 0
    Dim saldoImporteAnualME As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim ImporteSaldoME As Decimal = 0
    Dim canSaldo As Decimal = 0
    Public Sub ObtenerSaldoInicioXmes(intAnio As Integer, intMEs As Integer, intCodigoEntidad As Integer, dt As DataTable)
        Dim cierreSA As New CierreCajaSA
        Dim cierre As New cierreCaja

        cierre = cierreSA.RecuperarCierreCajaXEF(intAnio, intMEs, intCodigoEntidad)

        If Not IsNothing(cierre) Then
            '  saldoCantidadAnual = cierre.cantidad
            saldoImporteAnual = cierre.montoMN
            saldoImporteAnualME = cierre.montoME
        Else
            'saldoCantidadAnual = 0
            saldoImporteAnual = 0
            saldoImporteAnualME = 0
        End If

        Dim dr As DataRow = dt.NewRow
        dr(0) = 0
        dr(1) = ""
        dr(2) = ""

        dr(3) = ""
        dr(4) = ""
        Select Case intMEs
            Case 1
                dr(5) = "Saldo: Mes-" & 12
            Case Else
                dr(5) = "Saldo: Mes-" & intMEs - 1
        End Select
        dr(6) = ""

        dr(7) = ("")
        dr(8) = ("")
        dr(9) = (0)

        dr(10) = (0)
        dr(11) = (0)
        dr(12) = (0)

        dr(13) = (0)
        dr(14) = (saldoImporteAnual)
        dr(15) = (saldoImporteAnualME)

        'If saldoCantidadAnual > 0 Then
        '    dr(15) = Math.Round(saldoImporteAnual / saldoCantidadAnual, 6)
        '    pmAcumnulado = Math.Round(saldoImporteAnual / saldoCantidadAnual, 6)
        'Else
        '    dr(15) = 0
        '    pmAcumnulado = 0
        'End If
        '      ImporteSaldo = saldoImporteAnual
        dt.Rows.Add(dr)

    End Sub

    Public Sub ObtenerEncabezadosME(dt As DataTable)
        Dim documentoCajaSA As New DocumentoCajaSA

        Dim dr As DataRow = dt.NewRow
        dr(0) = 0
        dr(1) = ""
        dr(2) = "Saldos:"

        dr(3) = 0
        dr(5) = 0
        dr(6) = 0

        dr(7) = "Saldos:"
        dr(8) = 0
        dr(9) = 0

        dr(10) = 0
        dr(11) = 0
        dr(12) = (0)

        dt.Rows.Add(dr)

    End Sub

    Public Sub ObtenerSaldoFinXmes(intIdCaja As Integer, dt As DataTable)
        Dim documentoCajaSA As New DocumentoCajaSA

        For Each i In documentoCajaSA.ObtenerCajaOnlineSaldosME(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, String.Format("{0:00}", CInt(txtPeriodoME.Value.Month)), txtPeriodoME.Value.Year, intIdCaja)
            Dim dr As DataRow = dt.NewRow
            dr(0) = 0
            dr(1) = ""
            dr(2) = ""

            dr(3) = 0
            dr(4) = 0
            dr(5) = i.montoUsd
            dr(6) = 0

            dr(7) = 0
            dr(8) = 0
            dr(9) = 0



            If (Not IsNothing(i.tipoCambio)) Then
                dr(10) = CDec(i.montoUsd * i.tipoCambio)
            Else
                dr(10) = CDec(i.montoUsd * i.difTipoCambio)
            End If

            dr(11) = 0
            dr(12) = (0)

            'dr(13) = (0)
            'dr(14) = (0)
            'dr(15) = (0)
            dt.Rows.Add(dr)
        Next
    End Sub

    Public Sub ObtenerSaldoInicioXmesME(intAnio As Integer, intMEs As Integer, intCodigoEntidad As Integer, dt As DataTable)
        Dim cierreSA As New CierreCajaSA
        Dim cierre As New cierreCaja

        cierre = cierreSA.RecuperarCierreCajaXEF(intAnio, intMEs, intCodigoEntidad)

        If Not IsNothing(cierre) Then
            '  saldoCantidadAnual = cierre.cantidad
            saldoImporteAnual = cierre.montoMN
            saldoImporteAnualME = cierre.montoME
        Else
            'saldoCantidadAnual = 0
            saldoImporteAnual = 0
            saldoImporteAnualME = 0
        End If

        Dim dr As DataRow = dt.NewRow
        dr(0) = (saldoImporteAnualME)

        dr(1) = ""
        Select Case intMEs
            Case 1
                dr(2) = "Saldo: Mes-" & 12
            Case Else
                dr(2) = "Saldo: Mes-" & intMEs - 1
        End Select


        dr(3) = (0)
        'dr(4) = ""
        dr(4) = (0)
        dr(5) = (0)
        dr(6) = (0)
        Select Case intMEs
            Case 1
                dr(7) = "Saldo: Mes-" & 12
            Case Else
                dr(7) = "Saldo: Mes-" & intMEs - 1
        End Select
        'dr(8) = ""
        dr(8) = 0
        dr(9) = (0)
        dr(10) = (0)
        dr(11) = (saldoImporteAnual)

        dt.Rows.Add(dr)

    End Sub

#End Region

#Region "Métodos"

    'Sub cargarIngresoArbol(condicion As Boolean)
    '    tsbAnticipoRecibido.Visible = condicion
    '    tsbAnticiposOtor.Visible = condicion
    '    tsbAsignacion.Visible = condicion
    '    tsbCajaUsuario.Visible = condicion
    '    tsbCobrar.Visible = condicion
    '    tsbEntidades.Visible = condicion
    '    tsbEntradaCaja.Visible = condicion
    '    tsbPagar.Visible = condicion
    '    tsbPrestamosOtor.Visible = condicion
    '    tsbPrestamosRecibidos.Visible = condicion
    '    tsbSalidaCaja.Visible = condicion
    '    tsbTranferencias.Visible = condicion
    'End Sub


    Public Sub CargarDatosInformativos(strEmpresa, intIdEstablecimiento, strPeriodo)
        Dim docuemntoSA As New DocumentoSA
        Dim lista As New documento
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim conteoCajaActiva As Integer
        Dim entidadSA As New EstadosFinancierosSA

        'dashboard
        Dim conteoCaja As Integer
        Dim conteoEfectivo As Integer
        Dim conetoBanco As Integer
        Dim conteoTarjeta As Integer
        Dim conteoEntidades As Integer

        lblFechaContable.Text = PeriodoGeneral
        lblDiaLab.Text = DiaLaboral.Day

        Try
            lista = docuemntoSA.UbicarConteoVentaCompra(strEmpresa, intIdEstablecimiento, strPeriodo)
            For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFull(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
                If (i.estadoCaja = "A") Then
                    conteoCajaActiva += 1
                End If
                conteoCaja += 1
            Next

            For Each i In entidadSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                If (i.tipo = "BC") Then
                    conetoBanco += 1
                ElseIf (i.tipo = "TC") Then
                    conteoTarjeta += 1
                ElseIf (i.tipo = "EF") Then
                    conteoEfectivo += 1
                End If
                conteoEntidades += 1
            Next

            If (conetoBanco > 0) Then
                lblSumBanco.Text = conetoBanco
            Else
                lblSumBanco.Text = 0
            End If

            If (conteoTarjeta > 0) Then

                lblSumTC.Text = conteoTarjeta
            Else
                lblSumTC.Text = 0
            End If

            If (conteoEfectivo > 0) Then
                lblSumeEfectivo.Text = conteoEfectivo
            Else
                lblSumeEfectivo.Text = 0
            End If

            If (conteoEntidades > 0) Then
                lblEntidades.Text = conteoEntidades
            Else
                lblEntidades.Text = 0
            End If

            If (Not IsNothing(lista.idDocumento)) Then
                lblCobros.Text = lista.idDocumento
            Else
                lblCobros.Text = 0
            End If

            If (conteoCaja > 0) Then
                lblUsuario.Text = conteoCaja
            Else
                lblUsuario.Text = 0
            End If

            If (conteoCajaActiva > 0) Then
                lblAsignacion.Text = conteoCajaActiva
            Else
                lblAsignacion.Text = 0
            End If

            If (Not IsNothing(lista.nroDoc)) Then
                lblPagos.Text = lista.nroDoc
            Else
                lblPagos.Text = 0
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarCajasTipo(strBusqueda As String, tiping As String)
        Dim estadoSA As New EstadosFinancierosSA

        Try
            ListaEstadosFiancieros = estadoSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, tiping, strBusqueda)
            Me.cboEntidadFinanciera.DataSource = ListaEstadosFiancieros
            Me.cboEntidadFinanciera.DisplayMember = "descripcion"
            Me.cboEntidadFinanciera.ValueMember = "idestado"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub getTableAnticiposPorPeriodoTipoOtorgado()
        Dim DocumentoAnticipoSL As New documentoAnticipo
        Dim dt As New DataTable("Aportes de Proveedor - período " & PeriodoGeneral & " ")
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()

        Dim str As String

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoAnticipo", GetType(String)))

        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("idEntidadFinanciera", GetType(String)))



        For Each i As documentoAnticipo In documentoAnticipoSA.getTableAnticiposPorPeriodoTipo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, "AO")
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.tipoDocumento
                Case "9901"
                    dr(1) = "VOUCHER CONTABLE"
            End Select
            dr(2) = i.numeroDoc
            dr(3) = str
            Select Case i.tipoOperacion
                Case "103"
                    dr(4) = "ANTICIPO RECIBIDO"
            End Select
            dr(5) = i.tipoAnticipo
            dr(6) = i.NombreEntidad
            dr(7) = i.TipoCambio
            dr(8) = i.importeMN
            dr(9) = i.importeME
            dr(10) = i.NombreEstadoFinanciero
            dt.Rows.Add(dr)
        Next
        dgvAnticipos.DataSource = dt

    End Sub

    Private Sub getTableAnticiposPorPeriodoTipoRecibido()
        Dim DocumentoAnticipoSL As New documentoAnticipo
        Dim dt As New DataTable("Aportes de Proveedor - período " & PeriodoGeneral & " ")
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()

        Dim str As String

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoAnticipo", GetType(String)))

        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("idEntidadFinanciera", GetType(String)))



        For Each i As documentoAnticipo In documentoAnticipoSA.getTableAnticiposPorPeriodoTipo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, "AR")
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.tipoDocumento
                Case "9901"
                    dr(1) = "VOUCHER CONTABLE"
            End Select
            dr(2) = i.numeroDoc
            dr(3) = str
            Select Case i.tipoOperacion
                Case "103"
                    dr(4) = "ANTICIPO RECIBIDO"
            End Select
            dr(5) = i.tipoAnticipo
            dr(6) = i.NombreEntidad
            dr(7) = i.TipoCambio
            dr(8) = i.importeMN
            dr(9) = i.importeME
            dr(10) = i.NombreEstadoFinanciero
            dt.Rows.Add(dr)
        Next
        dgvAnticipos.DataSource = dt

    End Sub


    Private Sub getTableAnticiposPorPeriodo()
        Dim DocumentoAnticipoSL As New documentoAnticipo
        Dim dt As New DataTable("Aportes de Proveedor - período " & PeriodoGeneral & " ")
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()

        Dim str As String

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoAnticipo", GetType(String)))

        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("idEntidadFinanciera", GetType(String)))



        For Each i As documentoAnticipo In documentoAnticipoSA.getTableAnticiposPorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.tipoDocumento
                Case "9901"
                    dr(1) = "VOUCHER CONTABLE"
            End Select
            dr(2) = i.numeroDoc
            dr(3) = str
            Select Case i.tipoOperacion
                Case "103"
                    dr(4) = "ANTICIPO RECIBIDO"
            End Select
            dr(5) = i.tipoAnticipo
            dr(6) = i.NombreEntidad
            dr(7) = i.TipoCambio
            dr(8) = i.importeMN
            dr(9) = i.importeME
            dr(10) = i.NombreEstadoFinanciero
            dt.Rows.Add(dr)
        Next
        dgvAnticipos.DataSource = dt

    End Sub

    Public Property ListadoPadre As List(Of Integer)
    Private Function GetChildTable() As DataTable
        Dim cajaSa As New cajaUsuarioSA
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

        Dim dt As New DataTable("ChildTable")
        dt = New DataTable("ChildTable")

        dt.Columns.Add(New DataColumn("idcajaUsuario", GetType(Integer)))
        'lower case c
        dt.Columns.Add(New DataColumn("Usuario", GetType(String)))
        dt.Columns.Add(New DataColumn("Importe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Estado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        'upper case P
        Dim user As New Usuario

        For Each x As cajaUsuario In cajaSa.UbicarCajasHijasFull(ListadoPadre)
            user = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = x.idPersona})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = x.idcajaUsuario
            dr(1) = user.Nombres & ", " & user.ApellidoPaterno & " " & user.ApellidoMaterno
            dr(2) = x.fondoMN
            dr(3) = x.estadoCaja
            dr(4) = x.idPadre
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Function GetParentTable() As DataTable
        Dim dt As New DataTable("ParentTable")
        Dim cajaSa As New cajaUsuarioSA
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

        dt = New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idcajaUsuario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaRegistro", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("NombreCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NombrePersona", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreCajaDestino", GetType(String)))
        dt.Columns.Add(New DataColumn("fondoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fondoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("pass", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCaja", GetType(String)))



        Dim Str As String = Nothing
        Dim user As New Usuario
        ListadoPadre = New List(Of Integer)()
        For Each i As cajaUsuario In cajaSa.ListaCajasHabilitadas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            user = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = i.idPersona})

            Dim dr As DataRow = dt.NewRow()
            Str = Nothing
            Str = CDate(i.fechaRegistro).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idcajaUsuario
            dr(1) = Str
            dr(2) = i.NombreCajaOrigen
            dr(3) = user.Nombres & ", " & user.ApellidoPaterno & " " & user.ApellidoMaterno
            dr(4) = String.Empty
            dr(5) = i.fondoMN
            dr(6) = i.fondoME
            dr(7) = i.idcajaUsuario
            dr(8) = i.estadoCaja
            dt.Rows.Add(dr)

            ListadoPadre.Add(i.idcajaUsuario)
        Next

        Return dt
    End Function
    Dim parentToChildRelationDescriptor As New GridRelationDescriptor()
    Dim parentTable As New DataTable
    Dim childTable As New DataTable
    Private Sub LoadCajas()

        Dim dSet As New DataSet()
        parentTable = GetParentTable()
        If parentTable.Rows.Count > 0 Then
            childTable = GetChildTable()
            If childTable.Rows.Count > 0 Then
                dSet.Tables.AddRange(New DataTable() {parentTable, childTable})

                'setup the relations
                Dim parentColumn As DataColumn = parentTable.Columns("idcajaUsuario")
                Dim childColumn As DataColumn = childTable.Columns("idPadre")
                dSet.Relations.Add("ParentToChild", parentColumn, childColumn)
            End If
        End If

        Me.dgvCajasAssig.DataSource = parentTable
        Me.dgvCajasAssig.Engine.BindToCurrencyManager = False

        'Me.dgvCajasAssig.GridVisualStyles = GridVisualStyles.Metro
        'Me.dgvCajasAssig.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.dgvCajasAssig.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvCajasAssig.TopLevelGroupOptions.ShowCaption = False

        'dgvCajasAssig.TableDescriptor.Relations.Clear()
        'parentToChildRelationDescriptor.RelationKeys.Clear()
        'Me.dgvCajasAssig.Engine.SourceListSet.Clear()
        ''parentToChildRelationDescriptor = New GridRelationDescriptor()

        'parentToChildRelationDescriptor.ChildTableName = "MyChildTable"
        '' same as SourceListSetEntry.Name for childTable (see below)
        'parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails
        'parentToChildRelationDescriptor.RelationKeys.Add("idcajaUsuario", "idPadre")

        ' Add relation to ParentTable 

        'dgvCajasAssig.TableDescriptor.Relations.Add(parentToChildRelationDescriptor)
        ''parentToChildRelationDescriptor.ChildTableDescriptor.Columns.Clear()

        'Me.dgvCajasAssig.Engine.SourceListSet.Add("MyParentTable", parentTable)
        'Me.dgvCajasAssig.Engine.SourceListSet.Add("MyChildTable", ChildTable)
        ''Me.dgvCajasAssig.Engine.SourceListSet.Add("MyGrandChildTable", grandChildTable)

        'Me.dgvCajasAssig.DataSource = parentTable

        ''Me.dgvCajasAssig.GridVisualStyles = GridVisualStyles.Metro
        ''Me.dgvCajasAssig.GridOfficeScrollBars = OfficeScrollBars.Metro
        'Me.dgvCajasAssig.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        'Me.dgvCajasAssig.TopLevelGroupOptions.ShowCaption = False


        'parentToChildRelationDescriptor.ChildTableDescriptor.VisibleColumns.Remove("idcajaUsuario")

        'parentToChildRelationDescriptor.ChildTableDescriptor.Columns(0).Width = 0
        'parentToChildRelationDescriptor.ChildTableDescriptor.Columns(1).Width = 190
        'parentToChildRelationDescriptor.ChildTableDescriptor.Columns(2).Width = 95
    End Sub


    Public Class Data
        Public Sub New()
            Me.New("", 0)
        End Sub

        Public Sub New(pers As String, imp As Decimal)
            Me.Persona = pers
            Me.ImporteSub = imp
        End Sub
        Private Perso As String
        Public Property Persona() As String
            Get
                Return Me.Perso
            End Get
            Set(value As String)
                Me.Perso = value
            End Set
        End Property

        Private importe_ As String
        Public Property ImporteSub() As String
            Get
                Return Me.importe_
            End Get
            Set(value As String)
                Me.importe_ = value
            End Set
        End Property

    End Class

    Public Class ChildList
        Inherits ArrayList
        Implements ITypedList

#Region "ITypedList Members"

        Public Function GetItemProperties(listAccessors As PropertyDescriptor()) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
            Return TypeDescriptor.GetProperties(GetType(Data))
        End Function

        Public Function GetListName(listAccessors As PropertyDescriptor()) As String Implements ITypedList.GetListName
            Return "Data"
        End Function

#End Region

    End Class

    Public Class ParentItem
        Private idCaja As Integer, fecha As String, OrigenCaja As String, nomPerson As String, CajaDestino As String, fondo_mn As Decimal, fondo_me As Decimal, estado As String
        Private m_child As ChildList
        Public Property idCajaUsuario() As Integer
            Get
                Return idCaja
            End Get
            Set(value As Integer)
                idCaja = value
            End Set
        End Property
        Public Property fechaRegistro() As String
            Get
                Return fecha
            End Get
            Set(value As String)
                fecha = value
            End Set
        End Property
        Public Property NombreCajaOrigen() As String
            Get
                Return OrigenCaja
            End Get
            Set(value As String)
                OrigenCaja = value
            End Set
        End Property

        Public Property NombrePersona() As String
            Get
                Return nomPerson
            End Get
            Set(value As String)
                nomPerson = value
            End Set
        End Property

        Public Property NombreCajaDestino() As String
            Get
                Return CajaDestino
            End Get
            Set(value As String)
                CajaDestino = value
            End Set
        End Property

        Public Property fondoMN() As Decimal
            Get
                Return fondo_mn
            End Get
            Set(value As Decimal)
                fondo_mn = value
            End Set
        End Property

        Public Property fondoME() As Decimal
            Get
                Return fondo_me
            End Get
            Set(value As Decimal)
                fondo_me = value
            End Set
        End Property

        Public Property estadoCaja() As String
            Get
                Return estado
            End Get
            Set(value As String)
                estado = value
            End Set
        End Property

        Public Property Child() As ChildList
            Get
                Return m_child
            End Get
            Set(value As ChildList)
                m_child = value
            End Set
        End Property

        'Public Sub New()
        '    Me.New("", "", "", "", "", "", 0, 0, 0)
        'End Sub
        Public Sub New(id As Integer, fec As String, cOrige As String, perso As String, desti As String, soles As Decimal, dolares As Decimal, estados As String, dt As ChildList)
            Me.idCajaUsuario = id
            Me.fechaRegistro = fec
            Me.NombreCajaOrigen = cOrige
            Me.NombrePersona = perso
            Me.NombreCajaDestino = desti
            Me.fondoMN = soles
            Me.fondoME = dolares
            Me.estadoCaja = estados
            Me.m_child = dt
        End Sub
    End Class

    Public Sub CargarCajasPadreEhijo(GGC As GridGroupingControl)
        Dim cajaSa As New cajaUsuarioSA
        Dim str As String
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()
        For Each i As cajaUsuario In cajaSa.ListaCajasHabilitadas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

            cl1 = New ChildList()
            For Each x As cajaUsuario In cajaSa.UbicarCajasHijasXpadre(i.idcajaUsuario)
                cl1.Add(New Data(x.NombrePersona, x.fondoMN))

            Next
            str = Nothing
            str = CDate(i.fechaRegistro).ToString("dd-MMM HH:mm tt ")
            al.Add(New ParentItem(i.idcajaUsuario, str, i.NombreCajaOrigen, i.NombrePersona, i.NombreCajaDestino, i.fondoMN, i.fondoME, i.estadoCaja, cl1))
        Next

        GGC.DataSource = al
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        GGC.Engine.SetSourceList(al)

        Dim grd As New GridRelationDescriptor()
        grd.RelationKind = RelationKind.UniformChildList
        grd.MappingName = "Child"
        'name of  property with child arraylist
        GGC.Engine.SourceListSet.Clear()
        GGC.TableDescriptor.Relations.Add(grd)
        For Each td As GridTableDescriptor In GGC.Engine.EnumerateTableDescriptor()
            td.Appearance.AnyCell.[ReadOnly] = True
            td.AllowNew = False
        Next

    End Sub

    Function ComprobanteCaja() As documento
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle


        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento   'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If

        nDocumentoCaja.tipoDoc = "9903"
        nDocumentoCaja.fechaProceso = DateTime.Now
        nDocumentoCaja.nroDoc = "EFECTIVO"
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9906"
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.TipoDocumentoPago = "VOCJ"
        objCaja.codigoLibro = "9906" ' TIPO OPERACION
        objCaja.periodo = PeriodoGeneral
        objCaja.codigoProveedor = USer.idPersona
        objCaja.fechaProceso = DateTime.Now
        objCaja.fechaCobro = DateTime.Now
        objCaja.tipoDocPago = "9903"
        objCaja.numeroDoc = 0 ' txtNumeroComp.Text
        objCaja.moneda = USer.moneda
        objCaja.entidadFinanciera = USer.idCajaDestino
        objCaja.numeroOperacion = "00001" 'txtNumeroComp.Text
        objCaja.tipoCambio = USer.tipoCambio

        utilidadMN = USer.fondoMN + USer.ingresoAdicMN - USer.otrosEgresosMN
        utilidadME = USer.fondoME + USer.ingresoAdicME - USer.otrosEgresosME

        objCaja.montoSoles = utilidadMN
        objCaja.montoUsd = utilidadME
        objCaja.glosa = "Apertura de caja"
        objCaja.entregado = "SI"
        objCaja.usuarioModificacion = USer.idcajaUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        objCajaDetalle = New documentoCajaDetalle
        objCajaDetalle.fecha = DateTime.Now
        objCajaDetalle.idItem = "00"
        objCajaDetalle.DetalleItem = "POR CIERRE DE CAJA"
        objCajaDetalle.montoSoles = utilidadMN
        objCajaDetalle.montoUsd = utilidadME
        
        objCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
      
        objCajaDetalle.documentoAfectado = 0
        objCajaDetalle.usuarioModificacion = USer.idcajaUsuario
        objCajaDetalle.fechaModificacion = Date.Now
        nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)

        Return nDocumentoCaja
    End Function

    Dim USer As New cajaUsuario
    Public Sub AperturarCajaUsuario(intIdUSer As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario

        Dim nDocumento As New documento
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            USer = cajaUsuarioSA.UbicarCajaUsuarioPorID(intIdUSer)
            With cajaUsuario
                .idcajaUsuario = USer.idcajaUsuario
                .fechaCierre = DateTime.Now
                .enUso = "N"
                .estadoCaja = "A"
                .otrosEgresosMN = USer.otrosEgresosMN
                .otrosEgresosME = USer.otrosEgresosME
                .ingresoAdicMN = USer.ingresoAdicMN
                .ingresoAdicME = USer.ingresoAdicME
                .idCajaCierre = Nothing
            End With
            nDocumento = ComprobanteCaja()
            asiento = asientoCaja()
            ListaAsiento.Add(asiento)
            nDocumento.asiento = ListaAsiento
            cajaUsuarioSA.AperturarCajaUsuario(cajaUsuario, nDocumento)
            '       Dispose()
            lblEstado.Text = "Caja reaperturar ...."
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message

            ' lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Private Sub EliminarSL(idCajaUsuario As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen

        With objDocumento

            .tipoDoc = 9901
            .idDocumento = Me.dgvCajasAssig.Table.CurrentRecord.GetValue("idcajaUsuario")
        End With

        If (documentoSA.DeleteUsuarioCajaSL(objDocumento).Length > 0) Then

            lblEstado.Text = "No se pudo eliminar la caja"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Else
            Me.dgvCajasAssig.Table.CurrentRecord.Delete()
            lblEstado.Text = "caja eliminada!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub


    Function asientoCaja() As asiento
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento

        utilidadMN = USer.fondoMN + USer.ingresoAdicMN - USer.otrosEgresosMN
        utilidadME = USer.fondoME + USer.ingresoAdicME - USer.otrosEgresosME

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = USer.idPersona
        nAsiento.nombreEntidad = Me.dgvCajasAssig.Table.CurrentRecord.GetValue("NombrePersona")
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
        nAsiento.fechaProceso = DateTime.Now
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.CIERRE_CAJA_USUARIO
        nAsiento.importeMN = utilidadMN
        nAsiento.importeME = utilidadME
        nAsiento.glosa = "Apertura caja"
        nAsiento.usuarioActualizacion = USer.idcajaUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        nAsiento.movimiento.Add(AS_CAJA_ORIGEN)
        nAsiento.movimiento.Add(AS_CAJA_DESTINO)

        Return nAsiento
    End Function

    Public Function AS_CAJA_ORIGEN() As movimiento
        Dim nMovimiento As New movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros

        ef = efSA.GetUbicar_estadosFinancierosPorID(USer.idCajaCierre)

        nMovimiento = New movimiento With {
              .cuenta = ef.cuenta,
              .descripcion = ef.descripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = utilidadMN,
              .montoUSD = utilidadME,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_CAJA_DESTINO() As movimiento
        Dim nMovimiento As New movimiento

        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros

        ef = efSA.GetUbicar_estadosFinancierosPorID(USer.idCajaDestino)

        nMovimiento = New movimiento With {
       .cuenta = ef.cuenta,
       .descripcion = ef.descripcion,
       .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
       .monto = utilidadMN,
       .montoUSD = utilidadME,
       .fechaActualizacion = DateTime.Now,
       .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Sub EliminarTransferencia(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documento As New documento

        With documento
            .idDocumento = intIdDocumento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = "Maykol"
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .tipoOperacion = "01"
            .fechaActualizacion = Date.Now
        End With

        documentoSA.EliminarTransferenciaCaja(documento)
        Me.dgvMovAdic.Table.CurrentRecord.Delete()
        lblEstado.Text = "Transferencia eliminada!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
    End Sub

    Public Sub EliminarOtrosMovimientos(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documento As New documento

        With documento
            .idDocumento = intIdDocumento
        End With

        documentoSA.EliminarOtrosMovimientosCaja(documento)
        Me.dgvMovAdic.Table.CurrentRecord.Delete()
        lblEstado.Text = "Movimiento eliminado!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
    End Sub
    Private Sub getTableMovAdicPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("NomCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NomCajaDestino", GetType(String)))

        Dim str As String
        For Each i As documentoCaja In documentoCajaSA.ObtenerMovimientosPorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)

            Select Case i.tipoOperacion
                Case "TEC"
                    If i.tipoMovimiento = "PG" Then
                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                        dr(0) = i.idDocumento
                        dr(1) = i.tipoOperacion
                        dr(2) = str
                        dr(3) = i.tipoDocPago
                        dr(4) = i.numeroOperacion
                        dr(5) = i.moneda
                        dr(6) = i.montoSoles
                        dr(7) = i.tipoCambio
                        dr(8) = i.montoUsd
                        dr(9) = i.NomCajaOrigen
                        dr(10) = i.NomCajaDestino
                        dt.Rows.Add(dr)
                    End If
                Case "OEC"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = str
                    dr(3) = i.tipoDocPago
                    dr(4) = i.numeroOperacion
                    dr(5) = i.moneda
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = "-"
                    dr(10) = i.NomCajaOrigen
                    dt.Rows.Add(dr)
                Case "OSC"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = str
                    dr(3) = i.tipoDocPago
                    dr(4) = i.numeroOperacion
                    dr(5) = i.moneda
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    dt.Rows.Add(dr)
            End Select

        Next
        dgvMovAdic.DataSource = dt

    End Sub

    Public Sub EliminarPersona(intIdPersona As Integer)
        Dim PersonaSA As New PersonaSA
        Dim PersonaBE As New Persona

        PersonaBE.idPersona = intIdPersona

        PersonaSA.EliminarPersona(PersonaBE)
        PanelError.Visible = True
        lblEstado.Text = "Usuario eliminado"
    End Sub

    Dim colorx As New GridMetroColors()
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
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub getTableUsuariosEstablecimiento()
        Dim cajaSa As New cajaUsuarioSA

        Dim dt As New DataTable("Usuarios")
        dt.Columns.Add(New DataColumn("idcajaUsuario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaRegistro", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("NombreCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NombrePersona", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreCajaDestino", GetType(String)))
        dt.Columns.Add(New DataColumn("fondoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fondoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estadoCaja", GetType(String)))

        Dim str As String
        For Each i As cajaUsuario In cajaSa.ListaCajasHabilitadas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaRegistro).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idcajaUsuario
            dr(1) = str
            dr(2) = i.NombreCajaOrigen
            dr(3) = i.NombrePersona
            dr(4) = i.NombreCajaDestino
            dr(5) = i.fondoMN
            dr(6) = i.fondoME
            dr(7) = i.estadoCaja
            dt.Rows.Add(dr)
        Next
        dgvCajasAssig.DataSource = dt

    End Sub

    Public Sub ObtenerListaCajas()
        Dim entidadSA As New EstadosFinancierosSA

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idEF", GetType(Integer)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripEF", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoEF", GetType(String)))

        For Each i In entidadSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idestado
            If i.codigo = 1 Then
                dr(1) = ("NACIONAL")
            Else
                dr(1) = ("EXTRANJERA")
            End If
            dr(2) = i.cuenta
            dr(3) = i.descripcion
            If (i.tipo = "BC") Then
                dr(4) = "BANCO"
            ElseIf (i.tipo = "EF") Then
                dr(4) = "EFECTIVO"
            ElseIf (i.tipo = "TC") Then
                dr(4) = "TARJETA"
            End If
            dt.Rows.Add(dr)
        Next
        dgvEF.DataSource = dt
    End Sub

    Private Sub getTableUsuarioCajas()
        Dim UsuarioSA As New UsuarioSA

        Dim dt As New DataTable("Usuarios")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("dni", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombres", GetType(String)))
        dt.Columns.Add(New DataColumn("appat", GetType(String)))
        dt.Columns.Add(New DataColumn("apmat", GetType(String)))
        'dt.Columns.Add(New DataColumn("fechaActualizacion", GetType(String)))

        Dim str As String
        For Each i As Usuario In UsuarioSA.GetListaUsuarios()

            If (i.Rol = "Cajero") Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                '  str = CDate(i.fechaActualizacion).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.IDUsuario
                If (Not IsNothing(i.NroDocumento)) Then
                    dr(1) = i.NroDocumento
                Else
                    dr(1) = ""
                End If
                dr(2) = i.Nombres
                dr(3) = i.ApellidoPaterno
                dr(4) = i.ApellidoMaterno
                'dr(4) = str
                dt.Rows.Add(dr)
            End If

            
        Next
        dgvUsuarios.DataSource = dt

    End Sub

    Public Sub ObtenerListaCajaAsignacion()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCaja", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("DNI", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFull(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            usuario = New Usuario
            usuario.IDUsuario = i.idPersona

            usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            If (Not IsNothing(usuario)) Then
                Dim dr As DataRow = dt.NewRow()

                Select Case i.estadoCaja
                    Case "A"
                        dr(0) = i.idPersona
                        dr(1) = i.idcajaUsuario
                        dr(2) = usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno
                        dr(3) = usuario.NroDocumento
                        Select Case i.estadoCaja
                            Case "A"
                                dr(4) = "ABIERTO"
                        End Select

                        dt.Rows.Add(dr)

                End Select


            End If
        Next
        dgvEntidadFinanciera.DataSource = dt


    End Sub

    Public Sub ObtenerListaCajaAsignacionReporte()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCaja", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("DNI", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFull(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            usuario = New Usuario
            usuario.IDUsuario = i.idPersona

            usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            If (Not IsNothing(usuario)) Then
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idPersona
                dr(1) = i.idcajaUsuario
                dr(2) = usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno
                dr(3) = usuario.NroDocumento
                Select Case i.estadoCaja
                    Case "A"
                        dr(4) = "ABIERTO"
                    Case "C"
                        dr(4) = "CERRADO"
                End Select

                dt.Rows.Add(dr)


            End If
        Next
        dgvReporteCaja.DataSource = dt


    End Sub

    Public Sub ObtenerListaCajaAsignacionDetalle(idCajausuario As Integer, idpersona As Integer)
        Dim cajausuariosa As New cajaUsuarioSA

        Dim cajausuario As New List(Of cajaUsuario)

        cajausuario = cajausuariosa.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = idCajausuario, .idPersona = idpersona})

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idCajaUsuario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("fondoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fondoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ingresoAdicMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ingresoAdicME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))

        For Each i In cajausuario
            Dim dr As DataRow = dt.NewRow()

            Select Case i.moneda
                Case 1
                    dr(0) = i.idcajaUsuario
                    dr(1) = i.idPersona
                    dr(2) = i.NombreEntidad
                    dr(3) = i.Tipo
                    dr(4) = "NACIONAL"
                    dr(5) = i.fondoMN
                    dr(6) = 0
                    dr(7) = i.ingresoAdicMN
                    dr(8) = 0
                    dr(9) = i.Saldo
                    dr(10) = 0
                    dt.Rows.Add(dr)
                Case 2
                    dr(0) = i.idcajaUsuario
                    dr(1) = i.idPersona
                    dr(2) = i.NombreEntidad
                    dr(3) = i.Tipo
                    dr(4) = "EXTRANJERA"
                    dr(5) = i.fondoMN
                    dr(6) = i.fondoME
                    dr(7) = i.ingresoAdicMN
                    dr(8) = i.ingresoAdicME
                    dr(9) = i.Saldo
                    dr(10) = i.SaldoME
                    dt.Rows.Add(dr)
            End Select



        Next
        dgvCajasAssig.DataSource = dt

    End Sub

    'Public Sub ObtenerListaCajaAsignacionDetalle(strIdCaja As Integer)
    '    Dim cajaUsuarioSA As New cajaUsuarioSA

    '    Dim dt As New DataTable("Entidades financieras")
    '    dt.Columns.Add(New DataColumn("idcajaUsuario", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("idPersona", GetType(String)))
    '    dt.Columns.Add(New DataColumn("descripcionPersona", GetType(String)))
    '    dt.Columns.Add(New DataColumn("idCajaOrigen", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("descripcionCaja", GetType(String)))
    '    dt.Columns.Add(New DataColumn("moneda", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fondoMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("fondoME", GetType(Decimal)))


    '    For Each i In cajaUsuarioSA.ListarPorCaja(strIdCaja)
    '        Dim dr As DataRow = dt.NewRow()

    '        dr(0) = i.idcajaUsuario
    '        dr(1) = i.idPersona
    '        dr(1) = i.NombrePersona
    '        dr(1) = i.idCajaOrigen
    '        dr(4) = i.NombreCajaOrigen
    '        If i.moneda = 1 Then
    '            dr(2) = ("Nacional")
    '        Else
    '            dr(2) = ("Extranjera")
    '        End If
    '        dr(3) = i.fondoMN
    '        dr(3) = i.fondoME

    '        dt.Rows.Add(dr)
    '    Next
    '    dgvCajasAssig.DataSource = dt
    'End Sub
#End Region

    Private Sub frmMasterCajas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMasterCajas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TabPageAdv8.Parent = Nothing
        'TabPageAdv9.Parent = Nothing
        'TabPageAdv10.Parent = Nothing
        'TabPageAdv11.Parent = Nothing
        'TabPageAdv12.Parent = Nothing
        'TabPageAdv13.Parent = Nothing
        'TabPageAdv14.Parent = Nothing
        'TabDashboard.Parent = TabControlAdv2
        '
        btOpen.Visible = False
        btCloseBox.Visible = False
        btIncident.Visible = False


        TabPageAdv8.Parent = Nothing
        TabPageAdv9.Parent = Nothing
        TabPageAdv10.Parent = Nothing
        TabPageAdv11.Parent = Nothing
        TabPageAdv12.Parent = Nothing
        TabPageAdv13.Parent = Nothing
        TabPageAdv14.Parent = Nothing
        TabDashboard.Parent = TabControlAdv2
        TabReporteCaja.Parent = Nothing

    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click

        Select Case Tag
            Case "newusuario"
                With frmNuevoUsuario
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Case "entidadesfinancieras"
                With frmModalCaja
                    .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                    .ObtenerMascaraMercaderia()
                    .txtCuentaID.Text = "101"
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Case "aperturacaja"
                'With frmAsignaCajaUser
                '    .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
                ' Me.Cursor = Cursors.WaitCursor
                Dim f As New frmAbrirCajaUsuario ' frmCreaUsuarioEmpresa
                f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                Me.Cursor = Cursors.Arrow
            Case "anticipos"
                If IsNothing(GFichaUsuarios) Then
                    lblEstado.Text = "Debe iniciar una caja válida!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                Else
                    With frmModalAnticipo
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        '.txtCuentaOrigen.Text = GFichaUsuarios.cuentaDestino
                        '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                End If

            Case "anticiposotorgados"

                If IsNothing(GFichaUsuarios) Then
                    lblEstado.Text = "Debe iniciar una caja válida!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                Else
                    With frmModalAnticipoOtor
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        '.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        '.txtCuentaOrigen.Text = GFichaUsuarios.cuentaDestino
                        '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                End If

            Case "ingresosadicionales"

                '    ListBox1.Items.Clear()
                '    ListBox1.Items.Add("Transferencia entre cajas")
                '    ListBox1.Items.Add("Otras entradas")
                '    ListBox1.Items.Add("Otras sálidas")

                '    Me.PopupControlContainer2.ParentControl = Me.btOperacion
                '    Me.PopupControlContainer2.ShowPopup(Point.Empty)

                'Case "asigcajas"
                '    ListBox1.Items.Clear()
                'Case "cuentaporpagar"
                '    ListBox1.Items.Clear()
                'Case "cuentasporcobrar"
                '    ListBox1.Items.Clear()
                'Case "prestotorg"
                '    ListBox1.Items.Clear()
                'Case "prestamorecibido"
                '    ListBox1.Items.Clear()
        End Select

    End Sub

    'Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
    '    Me.Cursor = Cursors.WaitCursor
    '    If e.PopupCloseType = PopupCloseType.Done Then
    '        Select Case ListBox1.Text
    '            Case "Nuevo usuario de caja"
    '                With frmNuevoUsuario
    '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                End With
    '            Case "Nueva entidad financiera"
    '                With frmModalCaja
    '                    .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
    '                    .ObtenerMascaraMercaderia()
    '                    .txtCuentaID.Text = "101"
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                End With

    '            Case "Asignar una caja a usuario"
    '                With frmAsignaCajaUser
    '                    .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                End With

    '            Case "Transferencia entre cajas"
    '                With frmTransferenciaCaja
    '                    .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
    '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
    '                    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                End With
    '            Case "Otras entradas"
    '                With frmEntradaSalidaCaja
    '                    .lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
    '                    .CaptionLabels(0).Text = "OTRAS ENTRADAS A CAJA"
    '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
    '                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
    '                    .txtFechaTrans.Value = Date.Now
    '                    '.lblPerido.Text = PeriodoGeneral
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                End With
    '            Case "Otras sálidas"

    '                With frmEntradaSalidaCaja
    '                    ' .lblCaja.Text = "Caja de origen:"
    '                    .lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
    '                    .CaptionLabels(0).Text = "OTRAS SALIDAS DE CAJA"
    '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
    '                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
    '                    .txtFechaTrans.Value = Date.Now
    '                    '.lblPerido.Text = PeriodoGeneral
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                End With
    '            Case "Nuevo anticipo"
    '                With frmModalAnticipo
    '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    '  If .TieneCuentaFinanciera = True Then
    '                    '.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
    '                    '.txtCuentaOrigen.Text = GFichaUsuarios.cuentaDestino
    '                    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                    'Else
    '                    'lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
    '                    'PanelError.Visible = True
    '                    'Timer1.Enabled = True
    '                    'TiempoEjecutar(5)
    '                    'End If
    '                End With
    '        End Select
    '    End If
    '    ' Set focus back to textbox.
    '    If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '        Me.btOperacion.Focus()
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub
    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
    Private Sub dgvUsuario_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvUsuarios.TableControl.Selections.Clear()
        End If
    End Sub
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
    Private Sub dgvUsuario_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs)
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvUsuarios)
    End Sub

    Private Sub dgvEF_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvEF.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvEF_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs)
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvEF)
    End Sub

    Private Sub dgvCajasAssig_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvCajasAssig.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvCajasAssig_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs)
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCajasAssig)
    End Sub

    'Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
    '    Me.Cursor = Cursors.WaitCursor
    '    If ListBox1.SelectedItems.Count > 0 Then
    '        Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub
    Dim filter As New GridExcelFilter()


    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btIncident_Click(sender As Object, e As EventArgs) Handles btIncident.Click
        Me.Cursor = Cursors.WaitCursor
        Dim el As Element = Me.dgvCajasAssig.Table.GetInnerMostCurrentElement()

        If el IsNot Nothing Then
            Dim table As GridTable = TryCast(el.ParentTable, GridTable)
            Dim tableControl As GridTableControl = Me.dgvCajasAssig.GetTableControl(table.TableDescriptor.Name)
            Dim cc As GridCurrentCell = tableControl.CurrentCell
            Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
            Dim rec As GridRecord = TryCast(el, GridRecord)
            If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                rec = TryCast(el.ParentRecord, GridRecord)
            End If
            If rec IsNot Nothing Then
                Dim f As New frmUsuariosDependientesView
                f.UbicarCajaPadre(rec.GetValue("idcajaUsuario"))
                f.UbicarCajasHijas(rec.GetValue("idcajaUsuario"))
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Maximized
                f.ShowDialog()

                'With frmArqueoCaja
                '    If Not IsNothing(Me.dgvCajasAssig.Table.CurrentRecord) Then
                '        .ConsultaReportePadre(rec.GetValue("idcajaUsuario"))
                '    Else
                '        .ConsultaReporte(rec.GetValue("idcajaUsuario"))
                '    End If

                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btCloseBox_Click(sender As Object, e As EventArgs) Handles btCloseBox.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUser As New cajaUsuario
        Dim el As Element = Me.dgvEntidadFinanciera.Table.GetInnerMostCurrentElement()
        Try
            If el IsNot Nothing Then

                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.dgvEntidadFinanciera.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)
                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                End If
                If rec IsNot Nothing Then

                    If cajaUsuarioSA.UbicarCajaUsuarioPorID(rec.GetValue("idCaja")).estadoCaja = "A" Then

                        '   Console.WriteLine(style.TableCellIdentity.Column.Name)
                        'MsgBox(rec.GetValue("idcajaUsuario"))
                        If Not IsNothing(Me.dgvEntidadFinanciera.Table.CurrentRecord) Then
                            Dim f As New frmCerrarCajaUsuario(Me.dgvEntidadFinanciera.Table.CurrentRecord)

                            With f
                                '.IDCajaUser =
                                '.ListaCierresPorModulo(rec.GetValue("idCajaUsuario"))
                                '.UbicarCaja(rec.GetValue("idCajaUsuario"))
                                f.txtUsuariocaja.Text = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("nombre")
                                f.txtUsuariocaja.Tag = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja")
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                            End With
                        Else
                            If MessageBoxAdv.Show("Desea cerrar la caja seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                cajaUser = New cajaUsuario
                                cajaUser.idcajaUsuario = rec.GetValue("idCaja")
                                cajaUser.estadoCaja = "C"
                                cajaUsuarioSA.CerrarAbrirCajaSubUsuario(cajaUser)
                                MessageBoxAdv.Show("Caja cerrada correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If


                    End If

                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub btOpen_Click(sender As Object, e As EventArgs) Handles btOpen.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUser As New cajaUsuario
        Dim el As Element = Me.dgvCajasAssig.Table.GetInnerMostCurrentElement()
        Try
            If el IsNot Nothing Then
                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.dgvCajasAssig.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)
                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                End If
                If rec IsNot Nothing Then
                    If Not IsNothing(Me.dgvCajasAssig.Table.CurrentRecord) Then
                        If cajaUsuarioSA.UbicarCajaUsuarioPorID(rec.GetValue("idcajaUsuario")).estadoCaja = "C" Then
                            AperturarCajaUsuario(rec.GetValue("idcajaUsuario"))
                        End If

                    Else
                        If MessageBoxAdv.Show("Desea Re-aperturar la caja seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                            cajaUser = New cajaUsuario
                            cajaUser.idcajaUsuario = rec.GetValue("idcajaUsuario")
                            cajaUser.estadoCaja = "A"
                            cajaUsuarioSA.CerrarAbrirCajaSubUsuario(cajaUser)
                            MessageBoxAdv.Show("Caja abierta correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If



                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvMovAdic_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvMovAdic.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvMovAdic.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvMovAdic_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvMovAdic.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvMovAdic)
    End Sub

    Private Sub dgvCajasAssig_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)
        'If Not IsNothing(Me.dgvCajasAssig.Table.CurrentRecord) Then
        '    btOpen.Enabled = True
        'Else
        '    btOpen.Enabled = False
        'End If
    End Sub

    Private Sub dgvCajasAssig_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs)
        If Not IsNothing(Me.dgvCajasAssig.Table.CurrentRecord) Then
            btOpen.Enabled = True
            btCloseBox.Enabled = True
            btEdit.Enabled = True
            btEliminar.Enabled = True
        Else
            btOpen.Enabled = True
            btCloseBox.Enabled = True
            btEdit.Enabled = False
            btEliminar.Enabled = False
        End If
    End Sub

    Private Sub dgvUsuario_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    Private Sub dgvAnticipos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvAnticipos.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvAnticipos.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvAnticipos_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvAnticipos.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvAnticipos)
    End Sub



    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub
    Public Sub CargarCajasTipo2(tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            ListaEstadoFinancierosMaster = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = tiping,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Me.cboEntidadFinanciera.DataSource = ListaEstadoFinancierosMaster
            Me.cboEntidadFinanciera.DisplayMember = "descripcion"
            Me.cboEntidadFinanciera.ValueMember = "idestado"
            cboEntidadFinanciera.SelectedValue = -1
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarCajasTipoME(tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            ListaEstadosFiancierosME = estadoSA.ObtenerEstadosFinancierosPorMoneda(GEstableciento.IdEstablecimiento, tiping, 2)
            Me.cboEntidadFinancieraME.DataSource = ListaEstadosFiancierosME
            Me.cboEntidadFinancieraME.DisplayMember = "descripcion"
            Me.cboEntidadFinancieraME.ValueMember = "idestado"
            cboEntidadFinancieraME.SelectedValue = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        dgvKardex2.Table.Records.DeleteAll()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo2("EF")
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo2("BC")
        ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo2("TC")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboConsulta_Click(sender As Object, e As EventArgs) Handles cboConsulta.Click

    End Sub

    Private Sub cboConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConsulta.SelectedIndexChanged
        If cboConsulta.Text = "POR PERIODO" Then
            txtPeriodo.Visible = True
            txtFechaDesdeME.Visible = False
            txtFechaHastaME.Visible = False
            Label6.Visible = False
        ElseIf cboConsulta.Text = "RANGO DE FECHA" Then
            txtPeriodo.Visible = False
            txtFechaDesdeME.Visible = True
            txtFechaHastaME.Visible = True
            Label6.Visible = True
        End If
    End Sub
    Sub ConsultasKardex()
        Dim strPeriodo As String = Nothing
        Select Case cboConsulta.Text
            Case "POR PERIODO"
                strPeriodo = String.Format("{0:00}", CInt(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
                GetTableXperiodo(cboEntidadFinanciera.SelectedValue, strPeriodo)

            Case "RANGO DE FECHA"

        End Select
    End Sub

    Sub ConsultasKardexME()
        Dim strPeriodo As String = Nothing
        Select Case cboConsulta.Text
            Case "POR PERIODO"
                strPeriodo = String.Format("{0:00}", CInt(txtPeriodoME.Value.Month)) & "/" & txtPeriodoME.Value.Year
                GetTableXperiodoME(CInt(cboEntidadFinancieraME.SelectedValue), strPeriodo)

            Case "RANGO DE FECHA"

        End Select
    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        Me.Cursor = Cursors.WaitCursor
        ConsultasKardex()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles tsbEntidades.Click
        Me.Cursor = Cursors.WaitCursor
        With frmModalCaja
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .ObtenerMascaraMercaderia()
            .txtCuentaID.Text = "101"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsbAsignacion.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmAbrirCajaUsuario ' frmCreaUsuarioEmpresa
        f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles tsbCajaUsuario.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmCrearUsuarioEmpresa
        '  f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        'f.pnCajero.Location = New Point(5, 22)
        'f.pnCajero.Enabled = False
        'f.pnCajero.Visible = True
        Me.Cursor = Cursors.Arrow

        'Me.Cursor = Cursors.WaitCursor
        'Dim f As New frmVentasDia
        'f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'f.pnCajero.Location = New Point(5, 22)
        'f.pnCajero.Enabled = False
        'f.pnCajero.Visible = True
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OtorgadosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'If IsNothing(GFichaUsuarios) Then
        '    lblEstado.Text = "Debe iniciar una caja válida!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'Else
        With frmModalAnticipoOtor
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        'End If
    End Sub

    Private Sub RecibidodToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'If IsNothing(GFichaUsuarios) Then
        '    lblEstado.Text = "Debe iniciar una caja válida!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'Else
        With frmModalAnticipo
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        'End If
    End Sub

    Private Sub TrasnferenciaEntreCajasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        With frmTransferenciaCaja
            .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        'With frmEntradaSalidaCaja
        '    .lblMovimiento.Tag = "OEC"
        '    .lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
        '    .CaptionLabels(0).Text = "OTRAS ENTRADAS A CAJA"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    .txtTipoCambio.Value = TmpTipoCambio
        '    '   .txtFechaTrans.Value = Date.Now
        '    '.lblPerido.Text = PeriodoGeneral
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    'Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
    '    With frmEntradaSalidaCaja
    '        ' .lblCaja.Text = "Caja de origen:"
    '        .lblMovimiento.Tag = "OSC"
    '        .lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
    '        .CaptionLabels(0).Text = "OTRAS SALIDAS DE CAJA"
    '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '        '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
    '        '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
    '        '.txtFechaTrans.Value = Date.Now
    '        '.lblPerido.Text = PeriodoGeneral
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '    End With
    'End Sub

    Private Sub ToolStripDropDownButton4_Click(sender As Object, e As EventArgs) Handles tsbPagar.Click
        'If IsNothing(GFichaUsuarios) Then
        '    lblEstado.Text = "Debe iniciar una caja válida!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'Else
        With frmCentroDePagos
            'ListBox1.Items.Clear()
            .ShowDialog()
        End With
        'End If
    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles tsbCobrar.Click
        'If IsNothing(GFichaUsuarios) Then
        '    lblEstado.Text = "Debe iniciar una caja válida!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'Else
        With frmCentroDeCobros
            'ListBox1.Items.Clear()
            .ShowDialog()
        End With

        'End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        'With frmPrestamosMaster
        '    'ListBox1.Items.Clear()
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        
    End Sub

    Private Sub ComboBoxAdv2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoME.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        dgvKardexME.Table.Records.DeleteAll()
        If cboTipoME.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipoME("EF")
        ElseIf cboTipoME.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipoME("BC")
        ElseIf cboTipoME.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipoME("TC")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        ConsultasKardexME()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboConsulaME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConsulaME.SelectedIndexChanged
        If cboConsulta.Text = "POR PERIODO" Then
            txtPeriodo.Visible = True
            txtFechaDesde.Visible = False
            txtFechaHasta.Visible = False
            Label6.Visible = False
        ElseIf cboConsulta.Text = "RANGO DE FECHA" Then
            txtPeriodo.Visible = False
            txtFechaDesde.Visible = True
            txtFechaHasta.Visible = True
            Label6.Visible = True
        End If
    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellClick
        If Not IsNothing(Me.dgvEntidadFinanciera.Table.CurrentRecord) Then
            ObtenerListaCajaAsignacionDetalle(Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja"), Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idPersona"))
        End If
    End Sub

    Private Sub treeViewAdv2_DoubleClick(sender As Object, e As EventArgs) Handles treeViewAdv2.DoubleClick
        Me.Cursor = Cursors.WaitCursor

        Select Case treeViewAdv2.SelectedNode.Text
            Case "DASHBOARD"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = Nothing
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                TabDashboard.Parent = TabControlAdv2

                btOpen.Visible = False
                btCloseBox.Visible = False
                btIncident.Visible = False
                Tag = "newusuario"
                'ListBox1.Items.Clear()
                CargarDatosInformativos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)


                '******************************* CAJA *********************************
            Case "ASIGNACION DE CAJA"
                Tag = "asigcajas"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = TabControlAdv2
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = Nothing
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                'ListBox1.Items.Clear()
                btCloseBox.Visible = True
                dgvCajasAssig.Table.Records.DeleteAll()
                ObtenerListaCajaAsignacion()
                btEliminar.Visible = True

            Case "USUARIO DE CAJA"
                TabPageAdv8.Parent = TabControlAdv2
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = Nothing
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = Nothing

                btOpen.Visible = False
                btCloseBox.Visible = False
                btIncident.Visible = False
                Tag = "newusuario"
                'ListBox1.Items.Clear()
                getTableUsuarioCajas()
                btEliminar.Visible = True

            Case "ENTIDADES FINANCIERAS"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = TabControlAdv2
                TabPageAdv10.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = Nothing
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                btOpen.Visible = False
                btCloseBox.Visible = False
                btIncident.Visible = False
                Tag = "entidadesfinancieras"
                'ListBox1.Items.Clear()
                ObtenerListaCajas()
                btEliminar.Visible = True


                '******************************** FLUJO DE CAJA ***************************************
            Case "FLUJO DE CAJA"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = Nothing
                TabPageAdv13.Parent = TabControlAdv2
                TabPageAdv14.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                txtPeriodo.Value = PeriodoGeneral

            Case "ANALISIS FLUJO ME"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = Nothing
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = TabControlAdv2
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                txtPeriodoME.Value = PeriodoGeneral


                '******************************** ENTRADA Y SALIDA DE CAJA ***************************************

            Case "ENTRADAS - VARIOS"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = TabControlAdv2
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = Nothing

                Tag = "anticipos"
                'ListBox1.Items.Clear()
                getTableAnticiposPorPeriodoTipoRecibido()

            Case "SALIDAS - VARIOS"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = TabControlAdv2
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = Nothing

                Tag = "anticiposotorgados"
                'ListBox1.Items.Clear()
                getTableAnticiposPorPeriodoTipoOtorgado()


                '**************************************     ANTICIPOS **********************************
            Case "ANTICIPOS RECIBIDOS"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = Nothing
                TabPageAdv11.Parent = TabControlAdv2
                TabPageAdv12.Parent = Nothing
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                btOpen.Visible = False
                btCloseBox.Visible = False
                btIncident.Visible = False
                Tag = "ingresosadicionales"
                getTableMovAdicPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)

                '********************************** REPORTES ***************************************
            Case "CAJA"
                Tag = "asigcajas"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = Nothing
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = Nothing
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = TabControlAdv2
                'ListBox1.Items.Clear()
                btCloseBox.Visible = True
                dgvReporteCaja.Table.Records.DeleteAll()
                ObtenerListaCajaAsignacionReporte()
                btEliminar.Visible = True

            Case "CIERRE DE CAJAS"
                TabPageAdv8.Parent = Nothing
                TabPageAdv9.Parent = Nothing
                TabPageAdv10.Parent = TabControlAdv2
                TabPageAdv11.Parent = Nothing
                TabPageAdv12.Parent = Nothing
                TabPageAdv13.Parent = Nothing
                TabPageAdv14.Parent = Nothing
                TabDashboard.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                btOpen.Visible = True
                btCloseBox.Visible = True
                btIncident.Visible = True
                Tag = "aperturacaja"
                'ListBox1.Items.Clear()
                LoadCajas()



           

            Case "Cuentas por Pagar"
                Tag = "cuentaporpagar"
                If IsNothing(GFichaUsuarios) Then
                    lblEstado.Text = "Debe iniciar una caja válida!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                Else
                    With frmCentroDePagos
                        'ListBox1.Items.Clear()
                        .ShowDialog()
                    End With
                End If

            Case "Cuentas por Cobrar"
                Tag = "cuentasporcobrar"

                If IsNothing(GFichaUsuarios) Then
                    lblEstado.Text = "Debe iniciar una caja válida!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                Else
                    With frmCentroDeCobros
                        'ListBox1.Items.Clear()
                        .ShowDialog()
                    End With
                End If

            Case "Prestamos Otorgados"
                'Tag = "prestotorg"
                'With frmPrestamosMaster
                '    'ListBox1.Items.Clear()
                '    .ShowDialog()
                'End With

            Case "Prestamos Recibidos"
                'Tag = "prestamorecibido"
                'With frmMaestroPrestamosRecibidos
                '    'ListBox1.Items.Clear()
                '    .ShowDialog()
                'End With

           

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboEntidadFinanciera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadFinanciera.SelectedIndexChanged
        dgvKardex2.Table.Records.DeleteAll()

        Dim cod = cboEntidadFinanciera.SelectedValue

        If IsNumeric(cod) Then
            If (Not IsNothing(ListaEstadoFinancierosMaster)) Then
                Dim conusulta = (From a In ListaEstadoFinancierosMaster Where a.idestado = cod Select a).FirstOrDefault
                If (Not IsNothing(conusulta)) Then
                    txtMonedaKardex.Text = conusulta.codigo
                End If
            End If
        End If


    End Sub

    Private Sub cboEntidadFinancieraME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadFinancieraME.SelectedIndexChanged
        dgvKardexME.Table.Records.DeleteAll()
        If (Not IsNothing(ListaEstadosFiancierosME)) Then

            Dim cod = cboEntidadFinancieraME.SelectedValue

            If IsNumeric(cod) Then
                Dim conusulta = (From a In ListaEstadosFiancierosME Where a.idestado = cod Select a).FirstOrDefault
                If (Not IsNothing(conusulta)) Then
                    Select Case conusulta.codigo
                        Case 2
                            cboMonedakardexME.Text = "EXTRANJERA"
                    End Select

                End If
            End If
        End If

    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles tsbPrestamosOtor.Click
        'With frmPrestamosMaster
        '    'ListBox1.Items.Clear()
        '    .ShowDialog()
        'End With

    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles tsbAnticipoRecibido.Click
        With frmModalAnticipo
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles tsbAnticiposOtor.Click
        With frmModalAnticipoOtor
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles tsbPrestamosRecibidos.Click
      
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles tsbEntradaCaja.Click
        'With frmEntradaSalidaCaja
        '    .lblMovimiento.Tag = "OEC"
        '    .lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
        '    .CaptionLabels(0).Text = "OTRAS ENTRADAS A CAJA"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .txtTipoCambio.Value = TmpTipoCambio
        '    '.txtFechaTrans.Value = Date.Now
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles tsbSalidaCaja.Click
        'With frmEntradaSalidaCaja
        '    .lblMovimiento.Tag = "OSC"
        '    .lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
        '    .CaptionLabels(0).Text = "OTRAS SALIDAS DE CAJA"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    '    .txtFechaTrans.Value = Date.Now
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles tsbTranferencias.Click
        With frmTransferenciaCaja
            .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub chartControl1_ChartFormatAxisLabel(sender As Object, e As Chart.ChartFormatAxisLabelEventArgs)

    End Sub

    Private Sub ToolStripButton18_Click(sender As Object, e As EventArgs) Handles ToolStripButton18.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Usuarios"
                filter.ClearFilters(Me.dgvUsuarios)
                Me.dgvUsuarios.TopLevelGroupOptions.ShowFilterBar = False
            Case "Entidades financieras"
                filter.ClearFilters(Me.dgvEF)
                Me.dgvEF.TopLevelGroupOptions.ShowFilterBar = False

            Case "Apertura/cierre de caja"
                filter.ClearFilters(Me.dgvCajasAssig)
                Me.dgvCajasAssig.TopLevelGroupOptions.ShowFilterBar = False
            Case "Ingresos de Período"
                filter.ClearFilters(Me.dgvMovAdic)
                Me.dgvMovAdic.TopLevelGroupOptions.ShowFilterBar = False
        End Select
    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Usuarios"
                Me.dgvUsuarios.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvUsuarios.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvUsuarios.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvUsuarios.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvUsuarios.OptimizeFilterPerformance = True
                Me.dgvUsuarios.ShowNavigationBar = True

                filter.WireGrid(dgvUsuarios)
                'Me.dgvVentasTicket.TopLevelGroupOptions.ShowFilterBar = False

            Case "Entidades financieras"
                Me.dgvEF.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvEF.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvEF.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvEF.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvEF.OptimizeFilterPerformance = True
                Me.dgvEF.ShowNavigationBar = True

                filter.WireGrid(dgvEF)

            Case "Apertura/cierre de caja"

                Me.dgvCajasAssig.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvCajasAssig.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvCajasAssig.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvCajasAssig.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvCajasAssig.OptimizeFilterPerformance = True
                Me.dgvCajasAssig.ShowNavigationBar = True

                filter.WireGrid(dgvCajasAssig)

            Case "Ingresos de Período"
                Me.dgvMovAdic.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvMovAdic.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvMovAdic.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvMovAdic.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                'Dim td As GridTableDescriptor = Me.dgvVentasTicket.TableDescriptor.Relations("ParentToChild").ChildTableDescriptor
                'For Each col As GridColumnDescriptor In td.Columns
                '    col.AllowFilter = True
                'Next

                Me.dgvMovAdic.OptimizeFilterPerformance = True
                Me.dgvMovAdic.ShowNavigationBar = True

                filter.WireGrid(dgvMovAdic)

        End Select
    End Sub

    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs) Handles ToolStripButton19.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Usuarios"
                dgvUsuarios.TableDescriptor.GroupedColumns.Clear()
                If dgvUsuarios.ShowGroupDropArea = True Then
                    dgvUsuarios.ShowGroupDropArea = False
                Else
                    dgvUsuarios.ShowGroupDropArea = True
                End If
            Case "Entidades financieras"
                dgvEF.TableDescriptor.GroupedColumns.Clear()
                If dgvEF.ShowGroupDropArea = True Then
                    dgvEF.ShowGroupDropArea = False
                Else
                    dgvEF.ShowGroupDropArea = True
                End If

            Case "Apertura/cierre de caja"

                dgvCajasAssig.TableDescriptor.GroupedColumns.Clear()
                If dgvCajasAssig.ShowGroupDropArea = True Then
                    dgvCajasAssig.ShowGroupDropArea = False
                Else
                    dgvCajasAssig.ShowGroupDropArea = True
                End If


            Case "Ingresos de Período"
                dgvMovAdic.TableDescriptor.GroupedColumns.Clear()
                If dgvMovAdic.ShowGroupDropArea = True Then
                    dgvMovAdic.ShowGroupDropArea = False
                Else
                    dgvMovAdic.ShowGroupDropArea = True
                End If
        End Select
    End Sub

    Private Sub ToolStripButton8_Click_1(sender As Object, e As EventArgs) Handles btEdit.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Usuarios"
                If Not IsNothing(Me.dgvUsuarios.Table.CurrentRecord) Then
                    With frmNuevoUsuario
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .UbicarporDNI(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                Else
                    lblEstado.Text = "Debe seleccionar un usuario!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If


            Case "Entidades financieras"
                If Not IsNothing(Me.dgvEF.Table.CurrentRecord) Then
                    With frmModalCaja
                        .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                        .ObtenerMascaraMercaderia()
                        .txtCuentaID.Text = "101"
                        .UbicarPorID(Me.dgvEF.Table.CurrentRecord.GetValue("idEF"))
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                Else
                    lblEstado.Text = "Debe seleccionar una entidad financiera!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If

            Case "ASIGNACION DE CAJA"

                With frmAbrirCajaUsuario
                    .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE

                    If (Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("estado")) = "ABIERTO" Then
                        .idCajauser = Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja")
                        .UbicarCajaUsuario()
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    Else
                        lblEstado.Text = "La caja esta cerrada!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If


                End With

                'Dim el As Element = Me.dgvCajasAssig.Table.GetInnerMostCurrentElement()
                'If el IsNot Nothing Then
                '    Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                '    Dim tableControl As GridTableControl = Me.dgvCajasAssig.GetTableControl(table.TableDescriptor.Name)
                '    Dim cc As GridCurrentCell = tableControl.CurrentCell
                '    Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                '    Dim rec As GridRecord = TryCast(el, GridRecord)
                '    If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                '        rec = TryCast(el.ParentRecord, GridRecord)
                '    End If
                '    If rec IsNot Nothing Then

                'With frmAsignaCajaUser
                '    .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                '    .ConfigModulo()
                '    .btGrabar.Enabled = False
                '    .ToolStripButton3.Visible = False
                '    .ToolStripButton4.Visible = False
                '    .ObtenerCajaUser(rec.GetValue("idcajaUsuario"))
                '    .UbicarCajasHijas(rec.GetValue("idcajaUsuario"))
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
                '    End If
                'End If



            Case "Ingresos de Período"

                If Not IsNothing(Me.dgvMovAdic.Table.CurrentRecord) Then
                    Select Case Me.dgvMovAdic.Table.CurrentRecord.GetValue("movimiento")
                        Case "TEC"

                        Case "OEC", "OSC"
                            'With frmEntradaSalidaCaja
                            '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            '    '.UbicarDocumento(Me.dgvMovAdic.Table.CurrentRecord.GetValue("idDocumento"))
                            '    .StartPosition = FormStartPosition.CenterParent
                            '    .ShowDialog()
                            'End With
                    End Select

                End If

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Usuarios"
                getTableUsuarioCajas()
            Case "Entidades financieras"
                ObtenerListaCajas()
            Case "Apertura/cierre de caja"

                'getTableUsuariosEstablecimiento()
                LoadCajas()
            Case "Ingresos de Período"
                getTableMovAdicPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Try
            Select Case treeViewAdv2.SelectedNode.Text
                Case "Usuarios"
                    If Not IsNothing(Me.dgvUsuarios.Table.CurrentRecord) Then
                        If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            EliminarPersona(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                            Me.dgvUsuarios.Table.CurrentRecord.Delete()
                        End If
                    Else
                        Me.Cursor = Cursors.Arrow
                    End If
                Case "Entidades financieras"

                Case "Apertura/cierre de caja"
                    Dim ventaSA As New documentoVentaAbarrotesSA
                    Dim el As Element = Me.dgvCajasAssig.Table.GetInnerMostCurrentElement()
                    Try

                        If el IsNot Nothing Then
                            Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                            Dim tableControl As GridTableControl = Me.dgvCajasAssig.GetTableControl(table.TableDescriptor.Name)
                            Dim cc As GridCurrentCell = tableControl.CurrentCell
                            Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                            Dim rec As GridRecord = TryCast(el, GridRecord)
                            If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                                rec = TryCast(el.ParentRecord, GridRecord)
                            End If
                            If rec IsNot Nothing Then

                                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    EliminarSL(rec.GetValue("idcajaUsuario"))
                                End If

                            End If
                        End If


                    Catch ex As Exception
                        lblEstado.Text = ex.Message
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End Try
                Case "Ingresos de Período"
                    If Not IsNothing(Me.dgvMovAdic.Table.CurrentRecord) Then
                        If Me.dgvMovAdic.Table.CurrentRecord.GetValue("movimiento") = "TEC" Then
                            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                EliminarTransferencia(Me.dgvMovAdic.Table.CurrentRecord.GetValue("idDocumento"))
                            End If
                        Else
                            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                EliminarOtrosMovimientos(Me.dgvMovAdic.Table.CurrentRecord.GetValue("idDocumento"))
                            End If

                        End If
                    End If

            End Select
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
         Select treeViewAdv2.SelectedNode.Text
            Case "ASIGNACION DE CAJA"
                Me.Cursor = Cursors.WaitCursor
                Dim f As New frmAbrirCajaUsuario ' frmCreaUsuarioEmpresa
                f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                Me.Cursor = Cursors.Arrow
            Case "USUARIO DE CAJA"
                Me.Cursor = Cursors.WaitCursor
                Dim f As New frmCrearUsuarioEmpresa
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                Me.Cursor = Cursors.Arrow
            Case "ENTIDADES FINANCIERAS"
                Me.Cursor = Cursors.WaitCursor
                With frmModalCaja
                    .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                    .ObtenerMascaraMercaderia()
                    .txtCuentaID.Text = "101"
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
                Me.Cursor = Cursors.Arrow
            Case "CUENTAS POR PAGAR"
                Me.Cursor = Cursors.WaitCursor
                With frmCentroDePagos
                    .ShowDialog()
                End With
                Me.Cursor = Cursors.Arrow
            Case "CUENTAS POR COBRAR"
                Me.Cursor = Cursors.WaitCursor
                With frmCentroDeCobros
                    .ShowDialog()
                End With
                Me.Cursor = Cursors.Arrow
            Case "ENTRADAS - VARIOS"
                'With frmEntradaSalidaCaja
                '    .lblMovimiento.Tag = "OEC"
                '    .lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                '    .CaptionLabels(0).Text = "OTRAS ENTRADAS A CAJA"
                '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '    .txtTipoCambio.Value = TmpTipoCambio
                '    '     .txtFechaTrans.Value = Date.Now
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
            Case "SALIDAS - VARIOS"
                'With frmEntradaSalidaCaja
                '    .lblMovimiento.Tag = "OSC"
                '    .lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                '    .CaptionLabels(0).Text = "OTRAS SALIDAS DE CAJA"
                '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '    '  .txtFechaTrans.Value = Date.Now
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With

            Case "ANTICIPOS RECIBIDOS"
                 With frmModalAnticipo
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With

            Case "PRESTAMOS RECIBIDOS"
                Me.Cursor = Cursors.WaitCursor
               
                Me.Cursor = Cursors.Arrow
            Case "PRESTAMOS OTORGADOS"
                Me.Cursor = Cursors.WaitCursor
                'With frmPrestamosMaster
                '    .ShowDialog()
                'End With
                Me.Cursor = Cursors.Arrow
            Case "RECLAMACIONES DE TERCEROS"
                Me.Cursor = Cursors.WaitCursor
                Me.Cursor = Cursors.Arrow
            Case "RECLAMACIONES A TERCEROS"
                Me.Cursor = Cursors.WaitCursor
                Me.Cursor = Cursors.Arrow
            Case "TRANSFERENCIA ENTRE CAJAS"
                Me.Cursor = Cursors.WaitCursor
                With frmTransferenciaCaja
                    .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
                Me.Cursor = Cursors.Arrow
                'Case "ENTRADAS - VARIOS""
                '    Me.Cursor = Cursors.WaitCursor
                '    With frmEntradaSalidaCaja
                '        .lblMovimiento.Tag = "OEC"
                '        .lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                '        .CaptionLabels(0).Text = "OTRAS ENTRADAS A CAJA"
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .txtTipoCambio.Value = TmpTipoCambio
                '        .txtFechaTrans.Value = Date.Now
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    End With
                '    Me.Cursor = Cursors.Arrow
                'Case "SALIDAS - VARIOS"
                '    Me.Cursor = Cursors.WaitCursor
                '    With frmEntradaSalidaCaja
                '        .lblMovimiento.Tag = "OSC"
                '        .lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                '        .CaptionLabels(0).Text = "OTRAS SALIDAS DE CAJA"
                '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '        .txtFechaTrans.Value = Date.Now
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    End With
                '    Me.Cursor = Cursors.Arrow
                'Case "CUENTAS POR COBRAR"
                '    Me.Cursor = Cursors.WaitCursor
                '    Me.Cursor = Cursors.Arrow
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
      
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNothing(Me.dgvReporteCaja.Table.CurrentRecord) Then
            With frmCajausuario
                .ConsultaReporte(Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idCaja"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idPersona"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("nombre"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("DNI"))
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If Not IsNothing(Me.dgvReporteCaja.Table.CurrentRecord) Then
            With frmCajaUsuarioCierre
                '.ConsultaReporte(Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idCaja"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idPersona"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("nombre"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("DNI"))
                .ShowDialog()
            End With
        End If
      
    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick

    End Sub
End Class