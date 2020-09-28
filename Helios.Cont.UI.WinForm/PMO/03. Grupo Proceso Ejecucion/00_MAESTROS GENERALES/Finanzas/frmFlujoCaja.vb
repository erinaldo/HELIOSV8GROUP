Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmFlujoCaja
    Inherits frmMaster

    Public lblEntidades As New Label

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvEF)
        lblPeriodo.Text = PeriodoGeneral
        txtPeriodoME.Value = PeriodoGeneral
        txtPeriodo.Value = PeriodoGeneral
        cargarConteoUsuario()
    End Sub

#Region "Métodos"
    Dim ListaEstadosFiancierosME As New List(Of estadosFinancieros)
    Dim ListaEstadoFinancierosMaster As New List(Of estadosFinancieros)

    Public Sub GetCuentasFinancieras()
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

    Public Sub ConteoEntidades()
        Dim EstadosFinancierosSA As New EstadosFinancierosSA
        Dim totalesEntidad As Integer

        totalesEntidad = EstadosFinancierosSA.ListadoEstadosFinanConteo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        Me.lblEntidades.Text = totalesEntidad
        lblEntidades.AutoSize = False
        lblEntidades.BackColor = Color.Transparent
        lblEntidades.Dock = DockStyle.Fill
        lblEntidades.ForeColor = Color.Yellow
        lblEntidades.TextAlign = ContentAlignment.MiddleLeft
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

    Sub ConsultasKardex()
        Dim strPeriodo As String = Nothing
        strPeriodo = String.Format("{0:00}", CInt(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        GetTableXperiodo(cboEntidadFinanciera.SelectedValue, strPeriodo)
    End Sub

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

    Public Sub EliminarEntidadFinanciera(intIdEntidad As Integer)
        Dim estadosFinancierosSA As New EstadosFinancierosSA
        Dim estadosFinancierosBE As New estadosFinancieros
        estadosFinancierosBE.idestado = intIdEntidad
        estadosFinancierosSA.DeleteEF(estadosFinancierosBE)
        PanelError.Visible = True
        lblEstado.Text = "Usuario eliminado"
    End Sub

    Sub cargarConteoUsuario()

        ConteoEntidades()
        Me.treeViewAdv2.Nodes(0).CustomControl = lblEntidades
  
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
                            co = i.montoMNSalida
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
                            dr(12) = i.montoMNSalida
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

                'For Each i In documentoCajaSA.ObtenerCajaOnline(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, String.Format("{0:00}", CInt(txtPeriodo.Value.Month)), txtPeriodo.Value.Year, intIdCaja)
                '    importeDeficit = 0
                '    importeDeficitme = 0

                '    Dim dr As DataRow = dt.NewRow()
                '    dr(0) = i.idDocumento
                '    dr(1) = i.fechaCobro
                '    dr(2) = i.dni
                '    dr(3) = i.tipousuario
                '    Select Case i.tipoMovimiento
                '        Case "DC"

                '            If producto = i.IdEntidadFinanciera Then
                '                productoCache = i.NombreCaja
                '                ImporteSaldo += CDec(i.montoSoles)
                '                ImporteSaldoME += CDec(i.montoUsd)
                '            Else
                '                importeDeficit = ImporteSaldo
                '                importeDeficitme = ImporteSaldoME

                '                ImporteSaldo = 0
                '                ImporteSaldoME = 0

                '                ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.IdEntidadFinanciera, dt)

                '                'ImporteSaldo = ImporteSaldo + saldoImporteAnual
                '                'ImporteSaldoME = ImporteSaldoME + saldoImporteAnualME
                '                ImporteSaldo = saldoImporteAnual
                '                ImporteSaldoME = saldoImporteAnualME

                '                ImporteSaldo = CDec(i.montoSoles) + ImporteSaldo
                '                ImporteSaldoME = CDec(i.montoUsd) + ImporteSaldoME
                '            End If

                '            dr(10) = i.montoSoles
                '            dr(11) = i.montoUsd
                '            dr(12) = 0
                '            dr(13) = 0
                '            dr(14) = ImporteSaldo
                '            dr(15) = ImporteSaldoME

                '            dr(4) = "ENTRADA"

                '        Case "PG"
                '            Dim co As Decimal = 0
                '            Dim come As Decimal = 0
                '            co = i.montoSoles
                '            come = i.montoUsd

                '            If producto = i.IdEntidadFinanciera Then
                '                productoCache = i.NombreCaja
                '                ImporteSaldo -= co
                '                ImporteSaldoME -= come
                '            Else
                '                importeDeficit = ImporteSaldo
                '                importeDeficitme = ImporteSaldoME

                '                ImporteSaldo = 0
                '                ImporteSaldoME = 0
                '                ObtenerSaldoInicioXmes(txtPeriodo.Value.Year, txtPeriodo.Value.Month, i.IdEntidadFinanciera, dt)

                '                ImporteSaldo = saldoImporteAnual
                '                ImporteSaldoME = saldoImporteAnualME

                '                ImporteSaldo -= CDec(i.montoSoles)
                '                ImporteSaldoME -= CDec(i.montoUsd)
                '            End If
                '            dr(10) = 0
                '            dr(11) = 0
                '            dr(12) = i.montoSoles
                '            dr(13) = i.montoUsd
                '            dr(14) = ImporteSaldo
                '            dr(15) = ImporteSaldoME
                '            dr(4) = "SALIDA"

                '    End Select
                '    dr(5) = i.DetalleItem
                '    dr(6) = i.tipoDocPago
                '    dr(7) = i.NumeroDocumento
                '    dr(8) = i.moneda

                '    If (Not IsNothing(i.tipoCambio)) Then
                '        dr(9) = i.tipoCambio
                '    Else
                '        dr(9) = i.difTipoCambio
                '    End If
                '    producto = i.IdEntidadFinanciera
                '    productoCache = i.NombreCaja
                '    dt.Rows.Add(dr)
                'Next

                For Each i In documentoCajaSA.ObtenerCajaOnlineME(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, String.Format("{0:00}", CInt(txtPeriodo.Value.Month)), txtPeriodo.Value.Year, intIdCaja)
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




                    'dr(12) = CDec(i.difTipoCambio)
                    'dr(13) = i.fechaProceso
                    'dr(14) = CDec(i.saldoMN)
                    'dr(15) = CDec(i.difTipoCambio - i.tipoCambio)
                    'dr(16) = CDec(i.saldoMN - i.montoSoles)
                    'CDec(i.saldoMN - i.montoSoles)

                    'End If

                    ''dr(6) = i.tipoCambio

                    'producto = i.IdEntidadFinanciera
                    'productoCache = i.NombreCaja

                    'dt.Rows.Add(dr)

                Next
                dgvKardex2.DataSource = dt


        End Select

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
            MessageBox.Show(ex.Message)
        End Try
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


    Dim saldoImporteAnual As Decimal = 0
    Dim saldoImporteAnualME As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim ImporteSaldoME As Decimal = 0
    Dim canSaldo As Decimal = 0
    Dim SaldoSoles As Decimal = 0
    Dim SaldoUSD As Decimal = 0

    Dim SaldoSolesNN As Decimal = 0
    Dim SaldoUSDNN As Decimal = 0

    Dim SaldoSolesNN1 As Decimal = 0
    Dim SaldoUSDNN1 As Decimal = 0

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
        dt.Columns.Add(New DataColumn("importeOtros", GetType(Decimal))) '13
        dt.Columns.Add(New DataColumn("diferenciaTC", GetType(Decimal))) '14
        dt.Columns.Add(New DataColumn("importeDif", GetType(Decimal))) '15


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
                dr(9) = CDec(i.montoSoles).ToString("N2")
                dr(10) = ImporteSaldo
                dr(11) = 0
                dr(12) = i.difTipoCambio
                dr(13) = CDec(i.montoSolesTransacc).ToString("N2")
                dr(14) = CDec(i.tipoCambio - i.difTipoCambio).ToString("N2")
                dr(15) = CDec((i.montoSolesTransacc) - (i.montoSoles)).ToString("N2")



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
            If (i.montoUsd > 0) Then
                dr(0) = 0
                dr(1) = ""
                dr(2) = ""

                dr(3) = 0
                dr(4) = 0
                dr(5) = CDec(i.montoUsd).ToString("N2")
                dr(6) = 0

                dr(7) = 0
                dr(8) = 0
                dr(9) = 0



                If (Not IsNothing(i.tipoCambio)) Then
                    dr(10) = CDec(i.montoUsd * i.tipoCambio).ToString("N2")
                Else
                    dr(10) = CDec(i.montoUsd * i.difTipoCambio).ToString("N2")
                End If

                dr(11) = 0
                dr(12) = (0)

                'dr(13) = (0)
                'dr(14) = (0)
                'dr(15) = (0)
                dt.Rows.Add(dr)
            End If
        Next
    End Sub

    Sub ConsultasKardexME()
        Dim strPeriodo As String = Nothing
        strPeriodo = String.Format("{0:00}", CInt(txtPeriodoME.Value.Month)) & "/" & txtPeriodoME.Value.Year
        GetTableXperiodoME(CInt(cboEntidadFinancieraME.SelectedValue), strPeriodo)
    End Sub
#End Region

    Private Sub frmFlujoCaja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmFlujoCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        treeViewAdv2.BackColor = Color.MediumSeaGreen
        TabCuentas.Parent = TabControlAdv1
        TabKardex.Parent = Nothing
        TabAnalisis.Parent = Nothing
    End Sub

    Private Sub cboTipoME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoME.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        dgvKardexME.Table.Records.DeleteAll()
        If cboTipoME.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipoME(CuentaFinanciera.Efectivo)
        ElseIf cboTipoME.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipoME(CuentaFinanciera.Banco)
        ElseIf cboTipoME.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipoME(CuentaFinanciera.Tarjeta_Credito)
        End If
        Me.Cursor = Cursors.Arrow
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

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        ConsultasKardexME()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        dgvKardex2.Table.Records.DeleteAll()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo2(CuentaFinanciera.Efectivo)
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo2(CuentaFinanciera.Banco)
        ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo2(CuentaFinanciera.Tarjeta_Credito)
        End If
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

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        Me.Cursor = Cursors.WaitCursor
        ConsultasKardex()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Cuentas Financieras"
                GridCFG(dgvEF)
                TabCuentas.Parent = TabControlAdv1
                TabKardex.Parent = Nothing
                TabAnalisis.Parent = Nothing
            Case "Analisis Moneda Nacional"
                GridCFG(dgvKardex2)
                TabCuentas.Parent = Nothing
                TabKardex.Parent = TabControlAdv1
                TabAnalisis.Parent = Nothing
            Case "Analisis Moneda Extranj."
                GridCFG(dgvKardexME)
                TabCuentas.Parent = Nothing
                TabKardex.Parent = Nothing
                TabAnalisis.Parent = TabControlAdv1
        End Select
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Cuentas Financieras"
                GetCuentasFinancieras()
            Case "Analisis Moneda Nacional"

            Case "Analisis Moneda Extranj."

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor 
        If TabControlAdv1.SelectedTab Is TabCuentas Then
            GetCuentasFinancieras()
        ElseIf TabControlAdv1.SelectedTab Is TabKardex Then

        ElseIf TabControlAdv1.SelectedTab Is TabAnalisis Then

        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabCuentas Then
            If Not IsNothing(Me.dgvEF.Table.CurrentRecord) Then
                With frmModalCaja
                    .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                    .ObtenerMascaraMercaderia()
                    '.txtCuentaID.Text = "101"
                    .UbicarPorID(Me.dgvEF.Table.CurrentRecord.GetValue("idEF"))
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe seleccionar una entidad financiera!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf TabControlAdv1.SelectedTab Is TabKardex Then

        ElseIf TabControlAdv1.SelectedTab Is TabAnalisis Then

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        With frmModalCaja
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .ObtenerMascaraMercaderia()
            .txtCuentaID.Text = "101"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            cargarConteoUsuario()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If TabControlAdv1.SelectedTab Is TabCuentas Then
            Dim ventaSA As New documentoVentaAbarrotesSA

            Try
                If Not IsNothing(Me.dgvEF.Table.CurrentRecord) Then
                    Dim cajaUsaurioSA As New cajaUsuarioSA
                    Dim documentoCajaSA As New DocumentoCajaSA
                    Dim conteoDocumentoCaja As Integer
                    Dim conteoEntidad As Integer
                    conteoEntidad = cajaUsaurioSA.UbicarCajaXIdEntidadOrigen(Me.dgvEF.Table.CurrentRecord.GetValue("idEF"), GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
                    conteoDocumentoCaja += documentoCajaSA.UbicarDocCajaXIdEntidadOrigen(Me.dgvEF.Table.CurrentRecord.GetValue("idEF"), GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc) + conteoEntidad
                    If (conteoDocumentoCaja = 0) Then
                        If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            EliminarEntidadFinanciera(Me.dgvEF.Table.CurrentRecord.GetValue("idEF"))
                            Me.dgvEF.Table.CurrentRecord.Delete()
                            cargarConteoUsuario()
                        End If
                    Else
                        MessageBox.Show("No se puede eliminar Entidad Financiera!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    Me.Cursor = Cursors.Arrow
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
End Class