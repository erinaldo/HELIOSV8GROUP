Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmModalMovimientosMN

#Region "Variables"
    Dim saldoImporteAnual As Decimal = 0
    Dim saldoImporteAnualME As Decimal = 0
    Dim ImporteSaldo As Decimal = 0
    Dim ImporteSaldoME As Decimal = 0
    Dim canSaldo As Decimal = 0
    Dim SaldoSoles As Decimal = 0
    Dim SaldoUSD As Decimal = 0
    Dim SaldoSolesNN As Decimal = 0
    Dim SaldoUSDNN As Decimal = 0
    Dim idCaja As Integer
    Dim SaldoSolesNN1 As Decimal = 0
    Dim SaldoUSDNN1 As Decimal = 0
#End Region

#Region "Attributes"
    Public Property ListaEstadoFinancierosMaster() As New List(Of estadosFinancieros)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvKardex2)
        txtPeriodoAFC.Value = DateTime.Now

    End Sub
#End Region

#Region "Métodos"
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
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub GetTableXperiodoConDocumento(intIdEntidad As Integer, Periodo As String)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing
        Dim listaDocCaja As New List(Of documentoCaja)
        Dim dt As New DataTable("Movimientos período - " & PeriodoGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim listaEstado As New List(Of String)

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0

        listaEstado.Add("AC")

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
                dt.Columns.Add(New DataColumn("entradaMN")) '10
                dt.Columns.Add(New DataColumn("entradaME"))
                dt.Columns.Add(New DataColumn("salidaMN")) '12
                dt.Columns.Add(New DataColumn("salidaME"))
                dt.Columns.Add(New DataColumn("saldoMN")) '14
                dt.Columns.Add(New DataColumn("saldoME"))
                dt.Columns.Add(New DataColumn("idDocumentoRef"))
                dt.Columns.Add(New DataColumn("tipoOperacion"))

                dgvKardex2.Table.TableDescriptor.Columns("moneda").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("tipoCambio").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("entradaME").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("salidaME").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("saldoME").Width = 0

                ImporteSaldo = 0
                ImporteSaldoME = 0
                'canSaldo = 0
                listaDocCaja = documentoCajaSA.ObtenerCajaOnlineConTramiteDoc(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)), CStr(txtPeriodoAFC.Value.Year), CStr(intIdEntidad), listaEstado)

                For Each i In listaDocCaja
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
                                ImporteSaldo += (i.montoSoles.GetValueOrDefault)
                                ImporteSaldoME += (i.montoUsd.GetValueOrDefault)
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME
                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '    ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)
                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME
                                ImporteSaldo = (i.montoSoles.GetValueOrDefault) + ImporteSaldo
                                ImporteSaldoME = (i.montoUsd.GetValueOrDefault) + ImporteSaldoME
                            End If

                            dr(10) = (i.montoSoles)
                            dr(11) = (i.montoUsd)
                            dr(12) = 0
                            dr(13) = 0
                            dr(14) = (ImporteSaldo)
                            dr(15) = (ImporteSaldoME)
                            dr(16) = (i.idCajaUsuario)
                            dr(17) = (i.NombreOperacion)
                            dr(4) = "ENTRADA"

                        Case "PG"
                            Dim co As Decimal = 0
                            Dim come As Decimal = 0
                            co = CDec(i.montoSoles)
                            come = CDec(i.montoUsd)

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo -= co
                                ImporteSaldoME -= come
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '   ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)

                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo -= (i.montoSoles.GetValueOrDefault)
                                ImporteSaldoME -= (i.montoUsd.GetValueOrDefault)
                            End If
                            dr(10) = 0
                            dr(11) = 0
                            dr(12) = i.montoSoles.GetValueOrDefault
                            dr(13) = i.montoUsd.GetValueOrDefault
                            dr(14) = ImporteSaldo
                            dr(15) = ImporteSaldoME
                            dr(16) = (i.idCajaUsuario)
                            dr(17) = (i.NombreOperacion)
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
                    producto = CStr(i.IdEntidadFinanciera)
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
                dt.Columns.Add(New DataColumn("entradaMN")) '10
                dt.Columns.Add(New DataColumn("entradaME"))
                dt.Columns.Add(New DataColumn("salidaMN")) '12
                dt.Columns.Add(New DataColumn("salidaME"))
                dt.Columns.Add(New DataColumn("saldoMN")) '14
                dt.Columns.Add(New DataColumn("saldoME"))
                dt.Columns.Add(New DataColumn("idDocumentoRef"))
                dt.Columns.Add(New DataColumn("tipoOperacion"))
                dgvKardex2.Table.TableDescriptor.Columns("moneda").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("tipoCambio").Width = 80
                dgvKardex2.Table.TableDescriptor.Columns("entradaME").Width = 90
                dgvKardex2.Table.TableDescriptor.Columns("salidaME").Width = 90
                dgvKardex2.Table.TableDescriptor.Columns("saldoME").Width = 90
                ImporteSaldo = 0
                ImporteSaldoME = 0

                For Each i In documentoCajaSA.ObtenerCajaOnlineME(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)), CStr(txtPeriodoAFC.Value.Year), CStr(intIdEntidad))
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
                                ImporteSaldo += (i.montoSoles)
                                ImporteSaldoME += (i.montoUsd)
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME
                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '       ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)
                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME
                                ImporteSaldo = (i.montoSoles) + ImporteSaldo
                                ImporteSaldoME = (i.montoUsd) + ImporteSaldoME
                            End If

                            dr(10) = (i.montoSoles) '.ToString("N2")
                            dr(11) = (i.montoUsd) '.ToString("N2")
                            dr(12) = 0
                            dr(13) = 0
                            dr(14) = (ImporteSaldo) '.ToString("N2")
                            dr(15) = (ImporteSaldoME) '.ToString("N2")
                            dr(16) = (i.idCajaUsuario)
                            dr(17) = (i.NombreOperacion)
                            dr(4) = "ENTRADA"

                        Case "PG"
                            Dim co As Decimal = 0
                            Dim come As Decimal = 0
                            co = CDec(i.montoSoles)
                            come = CDec(i.montoUsd)

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo -= co
                                ImporteSaldoME -= come
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '        ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)

                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo -= (i.montoSoles.GetValueOrDefault)
                                ImporteSaldoME -= (i.montoUsd.GetValueOrDefault)
                            End If
                            dr(10) = 0
                            dr(11) = 0
                            dr(12) = (i.montoSoles)
                            dr(13) = (i.montoUsd)
                            dr(14) = (ImporteSaldo)
                            dr(15) = (ImporteSaldoME)
                            dr(16) = (i.idCajaUsuario)
                            dr(17) = (i.NombreOperacion)
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
                    producto = CStr(i.IdEntidadFinanciera)
                    productoCache = i.NombreCaja
                    dt.Rows.Add(dr)

                Next
                dgvKardex2.DataSource = dt
        End Select

    End Sub

    Private Sub GetTableXperiodo(intIdEntidad As Integer, Periodo As String)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing
        Dim listaDocCaja As New List(Of documentoCaja)
        Dim dt As New DataTable("Movimientos período - " & PeriodoGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim listaEstado As New List(Of String)

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0

        listaEstado.Add("AC")

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
                dt.Columns.Add(New DataColumn("entradaMN")) '10
                dt.Columns.Add(New DataColumn("entradaME"))
                dt.Columns.Add(New DataColumn("salidaMN")) '12
                dt.Columns.Add(New DataColumn("salidaME"))
                dt.Columns.Add(New DataColumn("saldoMN")) '14
                dt.Columns.Add(New DataColumn("saldoME"))
                dt.Columns.Add(New DataColumn("idDocumentoRef"))
                dt.Columns.Add(New DataColumn("tipoOperacion"))

                dgvKardex2.Table.TableDescriptor.Columns("moneda").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("tipoCambio").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("entradaME").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("salidaME").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("saldoME").Width = 0

                ImporteSaldo = 0
                ImporteSaldoME = 0
                'canSaldo = 0

                'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                '    Case 3, 4
                '        idCaja = GFichaUsuarios.IdCajaUsuario
                '        listaDocCaja = documentoCajaSA.ObtenerCajaOnlineXDocumentoXId(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)), CStr(txtPeriodoAFC.Value.Year), CStr(intIdEntidad), GFichaUsuarios.IdCajaUsuario)
                '    Case Else
                listaDocCaja = documentoCajaSA.ObtenerCajaOnlineXDocumento(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)), CStr(txtPeriodoAFC.Value.Year), CStr(intIdEntidad), listaEstado)
                'End Select

                For Each i In listaDocCaja
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
                                ImporteSaldo += (i.montoSoles.GetValueOrDefault)
                                ImporteSaldoME += (i.montoUsd.GetValueOrDefault)
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME
                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '    ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)
                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME
                                ImporteSaldo = (i.montoSoles.GetValueOrDefault) + ImporteSaldo
                                ImporteSaldoME = (i.montoUsd.GetValueOrDefault) + ImporteSaldoME
                            End If

                            dr(10) = (i.montoSoles)
                            dr(11) = (i.montoUsd)
                            dr(12) = 0
                            dr(13) = 0
                            dr(14) = (ImporteSaldo)
                            dr(15) = (ImporteSaldoME)
                            dr(16) = (i.idCajaUsuario)
                            dr(17) = (i.NombreOperacion)
                            dr(4) = "ENTRADA"

                        Case "PG"
                            Dim co As Decimal = 0
                            Dim come As Decimal = 0
                            co = CDec(i.montoSoles)
                            come = CDec(i.montoUsd)

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo -= co
                                ImporteSaldoME -= come
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '   ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)

                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo -= (i.montoSoles.GetValueOrDefault)
                                ImporteSaldoME -= (i.montoUsd.GetValueOrDefault)
                            End If
                            dr(10) = 0
                            dr(11) = 0
                            dr(12) = i.montoSoles.GetValueOrDefault
                            dr(13) = i.montoUsd.GetValueOrDefault
                            dr(14) = ImporteSaldo
                            dr(15) = ImporteSaldoME
                            dr(16) = (i.idCajaUsuario)
                            dr(17) = (i.NombreOperacion)
                            dr(4) = "SALIDA"

                    End Select
                    dr(5) = i.NombreOperacion
                    dr(6) = i.tipoDocPago
                    dr(7) = i.NumeroDocumento
                    dr(8) = i.moneda

                    If (Not IsNothing(i.tipoCambio)) Then
                        dr(9) = i.tipoCambio
                    Else
                        dr(9) = i.difTipoCambio
                    End If
                    producto = CStr(i.IdEntidadFinanciera)
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
                dt.Columns.Add(New DataColumn("entradaMN")) '10
                dt.Columns.Add(New DataColumn("entradaME"))
                dt.Columns.Add(New DataColumn("salidaMN")) '12
                dt.Columns.Add(New DataColumn("salidaME"))
                dt.Columns.Add(New DataColumn("saldoMN")) '14
                dt.Columns.Add(New DataColumn("saldoME"))
                dgvKardex2.Table.TableDescriptor.Columns("moneda").Width = 0
                dgvKardex2.Table.TableDescriptor.Columns("tipoCambio").Width = 80
                dgvKardex2.Table.TableDescriptor.Columns("entradaME").Width = 90
                dgvKardex2.Table.TableDescriptor.Columns("salidaME").Width = 90
                dgvKardex2.Table.TableDescriptor.Columns("saldoME").Width = 90
                ImporteSaldo = 0
                ImporteSaldoME = 0

                For Each i In documentoCajaSA.ObtenerCajaOnlineME(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)), CStr(txtPeriodoAFC.Value.Year), CStr(intIdEntidad))
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
                                ImporteSaldo += (i.montoSoles)
                                ImporteSaldoME += (i.montoUsd)
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME
                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '       ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)
                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME
                                ImporteSaldo = (i.montoSoles) + ImporteSaldo
                                ImporteSaldoME = (i.montoUsd) + ImporteSaldoME
                            End If

                            dr(10) = (i.montoSoles) '.ToString("N2")
                            dr(11) = (i.montoUsd) '.ToString("N2")
                            dr(12) = 0
                            dr(13) = 0
                            dr(14) = (ImporteSaldo) '.ToString("N2")
                            dr(15) = (ImporteSaldoME) '.ToString("N2")

                            dr(4) = "ENTRADA"

                        Case "PG"
                            Dim co As Decimal = 0
                            Dim come As Decimal = 0
                            co = CDec(i.montoSoles)
                            come = CDec(i.montoUsd)

                            If producto = i.IdEntidadFinanciera Then
                                productoCache = i.NombreCaja
                                ImporteSaldo -= co
                                ImporteSaldoME -= come
                            Else
                                importeDeficit = ImporteSaldo
                                importeDeficitme = ImporteSaldoME

                                ImporteSaldo = 0
                                ImporteSaldoME = 0
                                '        ObtenerSaldoInicioXmes(txtPeriodoAFC.Value.Year, txtPeriodoAFC.Value.Month, i.IdEntidadFinanciera, dt)

                                ImporteSaldo = saldoImporteAnual
                                ImporteSaldoME = saldoImporteAnualME

                                ImporteSaldo -= (i.montoSoles.GetValueOrDefault)
                                ImporteSaldoME -= (i.montoUsd.GetValueOrDefault)
                            End If
                            dr(10) = 0
                            dr(11) = 0
                            dr(12) = (i.montoSoles)
                            dr(13) = (i.montoUsd)
                            dr(14) = (ImporteSaldo)
                            dr(15) = (ImporteSaldoME)
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
                    producto = CStr(i.IdEntidadFinanciera)
                    productoCache = i.NombreCaja
                    dt.Rows.Add(dr)

                Next
                dgvKardex2.DataSource = dt
        End Select

    End Sub

    Sub ConsultasKardex()
        Dim strPeriodo As String = Nothing
        strPeriodo = String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)) & "/" & txtPeriodoAFC.Value.Year

        Select Case cboTipoMovimiento.Text
            Case "CON MOV. DOCUMENTARIO"
                GetTableXperiodo(cboEntidadFinanciera.SelectedValue, strPeriodo)
            Case "SIN MOV. DOCUMENTARIO"
                GetTableXperiodoConDocumento(cboEntidadFinanciera.SelectedValue, strPeriodo)
        End Select



    End Sub

    Public Sub CargarCajasTipo2(tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            ListaEstadoFinancierosMaster = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = tiping,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            cboEntidadFinanciera.DataSource = ListaEstadoFinancierosMaster
            cboEntidadFinanciera.DisplayMember = "descripcion"
            cboEntidadFinanciera.ValueMember = "idestado"
            cboEntidadFinanciera.SelectedValue = -1
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Events"
    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        dgvKardex2.Table.Records.DeleteAll()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo2(CuentaFinanciera.Efectivo)
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo2(CuentaFinanciera.Banco)
        ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo2(CuentaFinanciera.Tarjeta_Credito)
        End If
        Cursor = Cursors.Default
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
        Cursor = Cursors.WaitCursor
        If (cboEntidadFinanciera.Text.Length > 0) Then
            ConsultasKardex()
        Else
            MessageBox.Show("Debe seleccionar una entidad financiera!")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub
#End Region

End Class