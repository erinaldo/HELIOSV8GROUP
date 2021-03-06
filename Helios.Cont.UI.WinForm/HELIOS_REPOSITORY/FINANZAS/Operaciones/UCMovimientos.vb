Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Public Class UCMovimientos

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
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
    Public Property ListaEstadoFinancierosMaster As List(Of estadosFinancieros)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvKardex2, True, False, 8.0F)
        OrdenamientoGrid(dgvKardex2, False)
        txtPeriodoAFC.Value = DateTime.Now
    End Sub
#End Region

#Region "Methods"
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

    Public Sub CargarCajasTipo2(tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            ListaEstadoFinancierosMaster = New List(Of estadosFinancieros)
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


    Private Sub GetTableXperiodoAdministracion(intIdEntidad As Integer, Periodo As String, tipoEnt As String)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing
        Dim listaDocCaja As New List(Of documentoCaja)
        Dim dt As New DataTable("Movimientos período - " & Periodo)
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


                '  listaDocCaja = documentoCajaSA.ObtenerCajaOnline(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)), CStr(txtPeriodoAFC.Value.Year), CStr(intIdEntidad)).Where(Function(o) o.estado = "1").ToList
                Dim IDEmpresa = Gempresas.IdEmpresaRuc
                Dim IDEStable = GEstableciento.IdEstablecimiento
                Dim fechaCobro = GetPeriodoConvertirToDate(Periodo)
                listaDocCaja = documentoCajaSA.GetKardexCajaAdministracion(New documentoCaja With
                                                              {
                                                              .idEmpresa = IDEmpresa,
                                                              .idEstablecimiento = IDEStable,
                                                              .fechaCobro = fechaCobro,
                                                              .entidadFinancieraDestino = CStr(intIdEntidad),
                                                              .tipoEntidadFinanciera = tipoEnt
                                                              }).Where(Function(o) o.estado = "1").ToList

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

    Private Sub GetTableXperiodoPOS(intIdEntidad As Integer, Periodo As String)
        Dim producto As String = Nothing
        Dim cantidadDeficit As Decimal = 0
        Dim importeDeficit As Decimal = 0
        Dim importeDeficitme As Decimal = 0
        Dim productoCache As String = Nothing
        Dim listaDocCaja As New List(Of documentoCaja)
        Dim dt As New DataTable("Movimientos período - " & Periodo)
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


                '  listaDocCaja = documentoCajaSA.ObtenerCajaOnlinePOS(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)), CStr(txtPeriodoAFC.Value.Year), CStr(intIdEntidad)).Where(Function(o) o.estado = "1").ToList
                Dim IDEmpresa = Gempresas.IdEmpresaRuc
                Dim IDEStable = GEstableciento.IdEstablecimiento
                Dim fechaCobro = GetPeriodoConvertirToDate(Periodo)
                listaDocCaja = documentoCajaSA.GetKardexCaja(New documentoCaja With
                                                              {
                                                              .idEmpresa = IDEmpresa,
                                                              .idEstablecimiento = IDEStable,
                                                              .fechaCobro = fechaCobro,
                                                              .entidadFinanciera = CStr(intIdEntidad)
                                                              }).Where(Function(o) o.estado = "1").ToList

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

    Private Sub GetTableXperiodoConDocumentoAdministracion(intIdEntidad As Integer, Periodo As String, tipoEnt As String)
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

                '    listaDocCaja = documentoCajaSA.ObtenerCajaOnlineConTramiteDoc(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)), CStr(txtPeriodoAFC.Value.Year), CStr(intIdEntidad), listaEstado).Where(Function(o) o.estado = "1").ToList

                Dim IDEmpresa = Gempresas.IdEmpresaRuc
                Dim IDEStable = GEstableciento.IdEstablecimiento
                Dim fechaCobro = GetPeriodoConvertirToDate(Periodo)
                listaDocCaja = documentoCajaSA.GetKardexCajaTramiteDocAdministracion(New documentoCaja With
                                                              {
                                                              .idEmpresa = IDEmpresa,
                                                              .idEstablecimiento = IDEStable,
                                                              .fechaCobro = fechaCobro,
                                                              .entidadFinancieraDestino = CStr(intIdEntidad),
                                                              .tipoEntidadFinanciera = tipoEnt
                                                              }).Where(Function(o) o.estado = "1").ToList

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

    Private Sub GetTableXperiodoConDocumentoPOS(intIdEntidad As Integer, Periodo As String)
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

                '    listaDocCaja = documentoCajaSA.ObtenerCajaOnlineConTramiteDocPOS(Gempresas.IdEmpresaRuc, CInt(GEstableciento.IdEstablecimiento), String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)), CStr(txtPeriodoAFC.Value.Year), CStr(intIdEntidad), listaEstado).Where(Function(o) o.estado = "1").ToList

                Dim IDEmpresa = Gempresas.IdEmpresaRuc
                Dim IDEStable = GEstableciento.IdEstablecimiento
                Dim fechaCobro = GetPeriodoConvertirToDate(Periodo)
                listaDocCaja = documentoCajaSA.GetKardexCajaTramiteDoc(New documentoCaja With
                                                              {
                                                              .idEmpresa = IDEmpresa,
                                                              .idEstablecimiento = IDEStable,
                                                              .fechaCobro = fechaCobro,
                                                              .entidadFinanciera = CStr(intIdEntidad)
                                                              }).Where(Function(o) o.estado = "1").ToList

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

    Sub ConsultasKardex()
        Dim strPeriodo As String = Nothing
        strPeriodo = String.Format("{0:00}", CInt(txtPeriodoAFC.Value.Month)) & "/" & txtPeriodoAFC.Value.Year

        Select Case cboTipoMovimiento.Text
            Case "CON MOV. DOCUMENTARIO"


                If cboTipo.Text = "CUENTAS EN EFECTIVO" Then

                    GetTableXperiodoAdministracion(cboEntidadFinanciera.SelectedValue, strPeriodo, "EF")
                ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
                    GetTableXperiodoAdministracion(cboEntidadFinanciera.SelectedValue, strPeriodo, "BC")
                ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
                    GetTableXperiodoAdministracion(cboEntidadFinanciera.SelectedValue, strPeriodo, "TC")
                ElseIf cboTipo.Text = "CUENTAS EN EFECTIVO CAJERO" Then
                    'SOLO ANTIGUO
                    GetTableXperiodoPOS(cboEntidadFinanciera.SelectedValue, strPeriodo)

                End If






            Case "SIN MOV. DOCUMENTARIO"



                If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
                    GetTableXperiodoConDocumentoAdministracion(cboEntidadFinanciera.SelectedValue, strPeriodo, "EF")
                ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
                    GetTableXperiodoConDocumentoAdministracion(cboEntidadFinanciera.SelectedValue, strPeriodo, "BC")
                ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
                    GetTableXperiodoConDocumentoAdministracion(cboEntidadFinanciera.SelectedValue, strPeriodo, "TC")

                ElseIf cboTipo.Text = "CUENTAS EN EFECTIVO CAJERO" Then
                    'SOLO ANTIGUO
                    GetTableXperiodoConDocumentoPOS(cboEntidadFinanciera.SelectedValue, strPeriodo)


                End If

        End Select

    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvKardex2.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Ver documento de origen..." Then
                '   Me.dgvCompra.Table.CurrentRecord.Delete()
                Select Case Me.dgvKardex2.Table.CurrentRecord.GetValue("tipoOperacion")
                    Case "COMPRA", "OTRAS ENTRADAS A ALMACEN", "TRANSFERENCIA ENTRE ALMACENES", "OTRAS SALIDAS DE ALMACEN", "NC-DISMINUIR CANTIDAD", "NC-DISMINUIR IMPORTE", "NC-DISMINUIR CANTIDAD E IMPORTE", "NC-DEVOLUCION DE EXISTENCIAS",
                        "NOTA DE CREDITO ESPECIAL", "NOTA DE DEBITO ESPECIAL", "PAGO A PROVEEDOR"
                        Dim a As New frmInfSourceMovimiento(Me.dgvKardex2.Table.CurrentRecord.GetValue("tipoOperacion"), Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumentoRef"), True)
                        ' Me.dgvCompra.TableDescriptor.Columns("CompanyName").HeaderText = "Hello"
                        a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha operación"
                        a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Proveedor y/o trabajador"
                        a.StartPosition = FormStartPosition.CenterParent
                        a.ShowDialog()
                    Case "VENTA", "VENTA TICKET BOLETA", "VENTA TICKET FACTURA", "COBRO A CLIENTES" ', "OTRAS SALIDAS DE ALMACEN"
                        Dim a As New frmInfSourceMovimiento(Me.dgvKardex2.Table.CurrentRecord.GetValue("tipoOperacion"), Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumentoRef"), True)
                        a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha venta"
                        a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Cliente"
                        a.StartPosition = FormStartPosition.CenterParent
                        a.ShowDialog()
                    Case "APORTES"
                        Dim a As New frmInfoSourceAlmacen(Me.dgvKardex2.Table.CurrentRecord.GetValue("tipoOperacion"), Me.dgvKardex2.Table.CurrentRecord.GetValue("idDocumentoRef"))
                        a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha venta"
                        a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Trabajador"
                        a.StartPosition = FormStartPosition.CenterParent
                        a.ShowDialog()
                End Select
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        dgvKardex2.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = dgvKardex2.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvKardex2.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub
#End Region

#Region "Events"

    Private Sub dgvKardex2_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvKardex2.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvKardex2.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvKardex2_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvKardex2.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvKardex2)
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

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        dgvKardex2.Table.Records.DeleteAll()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo2(CuentaFinanciera.Efectivo)
        ElseIf cboTipo.Text = "CUENTAS EN EFECTIVO CAJERO" Then
            CargarCajasTipo2(CuentaFinanciera.Efectivo_Cajero)
            ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
                CargarCajasTipo2(CuentaFinanciera.Banco)
            ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
                CargarCajasTipo2(CuentaFinanciera.Tarjeta_Credito)
        End If
        Cursor = Cursors.Default
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

    Private Sub UCMovimientos_Load(sender As Object, e As EventArgs) Handles Me.Load
        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Ver documento de origen...")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler Me.dgvKardex2.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboEntidadFinanciera_Click(sender As Object, e As EventArgs) Handles cboEntidadFinanciera.Click

    End Sub
#End Region

End Class
