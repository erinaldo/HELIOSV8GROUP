Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports System.ComponentModel
Imports Syncfusion.Windows.Forms.Tools

Public Class frmMaestroAsientoContables
    Inherits frmMaster

    Dim lblCenter As New Label

    Public Property ListaAsientos As New List(Of asiento)
    Public Property ListaMovimiento As New List(Of movimiento)

    Public Property ListadoCuentasContables As New List(Of cuentaplanContableEmpresa)
    Public Property ListadoOperaciones As New List(Of tabladetalle)

    Dim feed As New FeedbackForm

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
     
        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Normal
        ButtonAdv18.Visible = False
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        txtAnioCompra.Text = AnioGeneral
    End Sub


#Region "Métodos"


    Public Sub EliminarGastoModulo(iddocumento As Integer)
        Dim objeto As New documentoLibroDiarioSA

        objeto.DeleteLibroDiario(iddocumento)

    End Sub

    Private Sub GetExistenciasInicio()
        Dim dt As New DataTable
        Dim libroSA As New documentoLibroDiarioSA

        dt.Columns.Add("codigo")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")

        For Each i In libroSA.GetExistenciasInicio(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.secuencia
            dr(1) = i.idItem
            dr(2) = i.descripcion
            dr(3) = i.importeMN
            dr(4) = i.importeME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl3.DataSource = dt
    End Sub

    Private Sub GetPagos()
        Dim dt As New DataTable
        Dim compraSA As New DocumentoCompraSA

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("razon")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        For Each i In compraSA.GetComprasDeApertura(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.tipoDoc
            dr(3) = i.serie
            dr(4) = i.numeroDoc
            dr(5) = i.nombreProveedor
            dr(6) = i.importeTotal
            dr(7) = i.importeUS
            dt.Rows.Add(dr)
        Next
        dgvpagos.DataSource = dt
    End Sub

    Private Sub GetCobros()
        Dim dt As New DataTable
        Dim ventaSA As New documentoVentaAbarrotesSA

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("razon")
        dt.Columns.Add("montoMN")
        dt.Columns.Add("montoME")

        For Each i In ventaSA.GetventasDeApertura(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.tipoDocumento
            dr(3) = i.serie
            dr(4) = i.numeroDoc
            dr(5) = i.NombreEntidad
            dr(6) = i.ImporteNacional
            dr(7) = i.ImporteExtranjero
            dt.Rows.Add(dr)
        Next
        dgvCobros.DataSource = dt
    End Sub

    Sub ObtenerEF()
        Dim estadosSA As New EstadosFinancierosSA
        Dim dt As New DataTable()

        dt.Columns.Add("entidad")
        dt.Columns.Add("tipo")
        dt.Columns.Add("numero")
        dt.Columns.Add("moneda")
        dt.Columns.Add("balance")

        For Each i In estadosSA.GetCuentasByTipoDeAporteInicio(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.descripcion
            Select Case i.tipo
                Case CuentaFinanciera.Efectivo
                    dr(1) = "Efectivo"
                Case CuentaFinanciera.Banco
                    dr(1) = "Banco"
                Case CuentaFinanciera.Tarjeta_Credito
                    dr(1) = "Tarjeta de crédito"
                Case CuentaFinanciera.Tarjeta_Debito
                    dr(1) = "Tarjeta de débito"
            End Select

            dr(2) = i.nroCtaCorriente
            dr(3) = i.codigo
            dr(4) = i.importeBalanceMN
            dt.Rows.Add(dr)
        Next
        dgvEntidadFinanciera.DataSource = dt

    End Sub

    Private Sub GetSumaCuentasByTipo()
        Dim cuentasSA As New EstadosFinancierosSA
        Dim cuentas As New List(Of estadosFinancieros)
        Dim compraSA As New DocumentoCompraSA
        Dim compra As New documentocompra

        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim venta As New documentoventaAbarrotes

        Dim libroSA As New documentoLibroDiarioSA
        Dim libro As New documentoLibroDiario

        cuentas = cuentasSA.GetSumaCuentasByTipo(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc})

        For Each i In cuentas
            Select Case i.tipo
                Case CuentaFinanciera.Efectivo
                    lblEfectivo.Text = CDec(i.importeBalanceMN.GetValueOrDefault).ToString("N2")
                Case CuentaFinanciera.Banco
                    lblBanco.Text = CDec(i.importeBalanceMN.GetValueOrDefault).ToString("N2")
                Case CuentaFinanciera.Tarjeta_Credito
                    lblTarjetaCredito.Text = CDec(i.importeBalanceMN.GetValueOrDefault).ToString("N2")
                Case CuentaFinanciera.Tarjeta_Debito

            End Select
        Next

        compra = compraSA.GetCuentasPorPagarInicio(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc})
        lblCuentasPorPagar.Text = CDec(compra.importeTotal.GetValueOrDefault).ToString("N2")

        venta = VentaSA.GetCuentasPorCobrarInicio(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc})
        lblCuentasporCobrar.Text = CDec(venta.ImporteNacional.GetValueOrDefault).ToString("N2")

        libro = libroSA.GetSumaInicioExistencias(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc})
        lblExistencias.Text = CDec(libro.importeMN.GetValueOrDefault).ToString("N2")


    End Sub

    Private Sub GetCuentaManuales()
        Dim libroSA As New documentoLibroDiarioSA

        Try
            Dim dt As New DataTable()
            dt.Columns.Add("codigo")
            dt.Columns.Add("cuenta")
            dt.Columns.Add("descripcion")
            dt.Columns.Add("debe")
            dt.Columns.Add("haber")

            For Each i In libroSA.GetCuentasAperturaEmpresa(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc})
                Dim dr As DataRow = dt.NewRow
                dr(0) = i.secuencia
                dr(1) = i.cuenta
                dr(2) = i.descripcion
                Select Case i.tipoAsiento
                    Case "D"
                        dr(3) = CDec(i.importeMN).ToString("N2")
                        dr(4) = "0.00"
                    Case Else
                        dr(3) = "0.00"
                        dr(4) = CDec(i.importeMN).ToString("N2")
                End Select
                dt.Rows.Add(dr)
            Next
            dgvCuentaApertura.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub GetCostoByTipoCMB(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        cboCosto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})

        cboCosto.DisplayMember = "nombreCosto"
        cboCosto.ValueMember = "idCosto"
    End Sub

    Public Sub GetCostoByTipoCMBServicios(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        cboCostoDestino.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})

        cboCostoDestino.DisplayMember = "nombreCosto"
        cboCostoDestino.ValueMember = "idCosto"
    End Sub

    Public Sub GetCostoByTipoCMBServicios1(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        cboCosto.DataSource = recursoSA.GetListaPryectosEnCarteraFull(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})


        cboCosto.DisplayMember = "nombreCosto"
        cboCosto.ValueMember = "idCosto"
    End Sub

    Private Sub GetItemsCosto(strCosto As String)
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("name")
        Select Case strCosto
            Case "HC"

                If TmpProyecto = True Then
                    Dim dr As DataRow = dt.NewRow
                    dr(0) = TipoCosto.Proyecto
                    dr(1) = "PROYECTO"
                    dt.Rows.Add(dr)
                End If

                If TmpOrdenProduccion = True Then
                    Dim dr1 As DataRow = dt.NewRow
                    dr1(0) = TipoCosto.OrdenProduccion
                    dr1(1) = "ORDEN DE PRODUCCION"
                    dt.Rows.Add(dr1)
                End If

                If TmpActivo = True Then
                    Dim dr2 As DataRow = dt.NewRow
                    dr2(0) = TipoCosto.ActivoFijo
                    dr2(1) = "ACTIVO FIJO"
                    dt.Rows.Add(dr2)
                End If

                'cboTipoCosto.DataSource = dt
                'cboTipoCosto.DisplayMember = "name"
                'cboTipoCosto.ValueMember = "id"

                cboIdentCosto.DataSource = dt
                cboIdentCosto.DisplayMember = "name"
                cboIdentCosto.ValueMember = "id"
            Case "HG"

                If TmpGastoAdmin = True Then
                    Dim dr As DataRow = dt.NewRow
                    dr(0) = TipoCosto.GastoAdministrativo
                    dr(1) = "GASTO ADMINISTRATIVO"
                    dt.Rows.Add(dr)
                End If

                If TmpGastoVentas = True Then
                    Dim dr1 As DataRow = dt.NewRow
                    dr1(0) = TipoCosto.GastoVentas
                    dr1(1) = "GASTO DE VENTAS"
                    dt.Rows.Add(dr1)
                End If

                If TmpGastoFinanciero = True Then
                    Dim dr2 As DataRow = dt.NewRow
                    dr2(0) = TipoCosto.GastoFinanciero
                    dr2(1) = "GASTO FINANCIERO"
                    dt.Rows.Add(dr2)
                End If

                'cboTipoCosto.DataSource = dt
                'cboTipoCosto.DisplayMember = "name"
                'cboTipoCosto.ValueMember = "id"

                cboIdentCosto.DataSource = dt
                cboIdentCosto.DisplayMember = "name"
                cboIdentCosto.ValueMember = "id"
        End Select
    End Sub

    'Public Sub EliminarLibroDiario(intIdDocumento As Integer)
    '    Dim asientoSA As New documentoLibroDiarioSA
    '    asientoSA.DeleteLibroDiario(intIdDocumento)
    '    dgvLibroDiario.Table.CurrentRecord.Delete()
    'End Sub

    Public Sub ListadoItems()
        Dim listadoSA As New documentoLibroDiarioSA
        Dim objeto As New tablaDetalleSA
        Dim dt As New DataTable()
        Dim entidadSA As New entidadSA
        Dim personaSA As New Helios.Planilla.WCFService.ServiceAccess.PersonalSA

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoBen", GetType(String))
        dt.Columns.Add("beneficiario", GetType(String))
        dt.Columns.Add("tipodoc", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoc", GetType(Decimal))
        dt.Columns.Add("importemn", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechavct", GetType(Date))
        dt.Columns.Add("idBene", GetType(Integer))
        dt.Columns.Add("identificacion", GetType(String))



        'Dim str As String
        For Each i In listadoSA.ListarGastosModulo("GXM", cboMesCompra.SelectedValue & "/" & AnioGeneral)
            Dim dr As DataRow = dt.NewRow()
            'str = Nothing
            'If Not IsNothing(i.fecha) Then
            '    str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            'End If
            dr(0) = i.idDocumento
            dr(1) = i.infoReferencial

            If IsNothing(i.razonSocial) Then

            Else
                Select Case i.tipoRazonSocial
                    Case TIPO_ENTIDAD.PROVEEDOR
                        dr(2) = "Proveedor"
                        With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                            dr(3) = .nombreCompleto
                        End With
                    Case TIPO_ENTIDAD.CLIENTE
                        dr(2) = "Cliente"
                        With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                            dr(3) = .nombreCompleto
                        End With
                    Case "TR"
                        dr(2) = "Trabajador"
                        With personaSA.PersonalSelxID(New Planilla.Business.Entity.Personal With {.IDPersonal = i.razonSocial})
                            dr(3) = .FullName
                        End With
                End Select
            End If


            dr(4) = "VOUCHER CONTABLE"
            dr(5) = i.nroDoc

            If i.moneda = "1" Then
                dr(6) = "NACIONAL"

            ElseIf i.moneda = "2" Then

                dr(6) = "EXTRANJERO"
            End If

            dr(7) = i.tipoCambio
            dr(8) = i.importeMN

            dr(9) = i.importeME
            dr(10) = i.fecha
            dr(11) = i.fechaVct


            If IsNothing(i.razonSocial) Then
                dr(13) = "N"
            Else
                dr(12) = i.razonSocial
                dr(13) = "S"
            End If
            dt.Rows.Add(dr)
        Next
        dgvCompra.DataSource = dt
        Me.dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One

    End Sub



    'Private Sub ListadoLibroAsiento(strTipoRegistro As String)
    '    Dim libroSA As New documentoLibroDiarioSA
    '    Dim libroBE As New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoRegistro = strTipoRegistro, .fechaPeriodo = cboMesCompra.SelectedValue & "/" & AnioGeneral}

    '    dgvLibroDiario.DataSource = libroSA.ListaLibroContable(libroBE)
    '    dgvLibroDiario.TableDescriptor.Relations.Clear()
    'End Sub

    Private Sub getConteoVentasObservadas()
        Dim ventaSA As New documentoVentaAbarrotesSA

        btAlertaVentas.Text = ventaSA.ListadoventasObservadasConteo(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .notificacionAsiento = "S"})

    End Sub

    Private Sub getVentasObservadas()
        Dim ventaSA As New documentoVentaAbarrotesSA

        dgvAlertaVentas.DataSource = ventaSA.ListadoventasObservadas(New documentoventaAbarrotes With {.idEmpresa = Gempresas.IdEmpresaRuc, .notificacionAsiento = "S"})

    End Sub


    Sub GridCFG2(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

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

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFGFinanzas(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True
        Dim colorx As New GridMetroColors
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.None
        GGC.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
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

    Private Sub GetPlantillaByOperacion()
        Dim plantillaSA As New asientoContablePlantillaSA
        Dim plantilla As New List(Of asientoContablePlantilla)

        plantilla = plantillaSA.GetPantillasGeneral("0000")

        lsvPlantilla.Items.Clear()
        For Each i In plantilla
            Dim n As New ListViewItem(i.tipoOperacion)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.tipo)
            lsvPlantilla.Items.Add(n)
        Next
    End Sub

    Private Sub LoadCombos()
        Dim tablaSA As New tablaDetalleSA

        cboOperacion.DisplayMember = "descripcion"
        cboOperacion.ValueMember = "codigoDetalle"
        cboOperacion.DataSource = tablaSA.GetListaTablaDetalle(12, "1")

        Dim cuentaSA As New cuentaplanContableEmpresaSA
        ListadoCuentasContables = cuentaSA.ObtenerCuentasPorEmpresaEscalable(Gempresas.IdEmpresaRuc)

    End Sub

    Private Sub getAlertasInventario()
        Dim documentoSA As New DocumentoCompraSA

        Dim conteo1 = documentoSA.GetNumAlertasInventariosSinAsiento(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                  .fechaContable = PeriodoGeneral,
                                                                                  .aprobado = "N", .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS})


        Dim conteo2 = documentoSA.GetNumFinanzasSinAsiento(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                 .periodo = PeriodoGeneral,
                                                                                 .estado = "N"})


        lblAlertaInventario.Text = conteo1
        lblAlertaFinanzas.Text = conteo2

        lblAlertasgeneral.Text = conteo1 + conteo2
    End Sub

    Private Sub GetAlertaInventarios()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("tipoCompra")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("tipoDocEntidad")
        dt.Columns.Add("NroDocEntidad")
        dt.Columns.Add("NombreEntidad")
        dt.Columns.Add("tipoPersona")
        dt.Columns.Add("importeTotal")
        dt.Columns.Add("tcDolLoc")
        dt.Columns.Add("importeUS")
        dt.Columns.Add("monedaDoc")
        dt.Columns.Add("usuarioActualizacion")
        dt.Columns.Add("glosa")
        dt.Columns.Add("tipooperacion")

        For Each i In compraSA.GetInventariosSinAsiento(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                  .fechaContable = PeriodoGeneral,
                                                                                  .aprobado = "N", .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS})

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = i.fechaDoc
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = ""
            dr(7) = ""
            dr(8) = ""
            dr(9) = ""
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.glosa
            dr(16) = i.tipoOperacion
            dt.Rows.Add(dr)
        Next
        dgvAlerta.DataSource = dt

        If dgvAlerta.Table.Records.Count > 0 Then
            dgvAlerta.Table.Records(0).SetCurrent()
            dgvAlerta.Table.Records(0).SetSelected(True)

            Dim detallename = (From n In ListadoOperaciones _
                        Where n.codigoDetalle = dgvAlerta.Table.CurrentRecord.GetValue("tipooperacion")).FirstOrDefault

            lblOperacion.Text = "Tipo Operación: " & detallename.descripcion

            lblDetalleOperacion.Text = dgvAlerta.Table.CurrentRecord.GetValue("glosa")

            dgvMovimientos.DataSource = New List(Of movimiento)
            GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
            UbicarDetalleComprobante(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        End If

    End Sub

    Private Sub GetAlertaFinanzas()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("tipoCompra")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("tipoDocEntidad")
        dt.Columns.Add("NroDocEntidad")
        dt.Columns.Add("NombreEntidad")
        dt.Columns.Add("tipoPersona")
        dt.Columns.Add("importeTotal")
        dt.Columns.Add("tcDolLoc")
        dt.Columns.Add("importeUS")
        dt.Columns.Add("monedaDoc")
        dt.Columns.Add("usuarioActualizacion")
        dt.Columns.Add("glosa")
        dt.Columns.Add("tipooperacion")

        For Each i In compraSA.GetFinanzasSinAsiento(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .periodo = PeriodoGeneral,
                                                                                  .estado = "N"})

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.movimientoCaja
            dr(2) = i.fechaProceso
            dr(3) = i.tipoDocPago
            dr(4) = "-"
            dr(5) = i.numeroDoc
            dr(6) = ""
            dr(7) = i.entidadFinanciera
            dr(8) = i.NombreEntidad
            dr(9) = ""
            dr(10) = i.montoSoles
            dr(11) = i.tipoCambio
            dr(12) = i.montoUsd
            dr(13) = i.moneda
            dr(14) = i.usuarioModificacion
            dr(15) = i.glosa
            dr(16) = i.tipoOperacion
            dt.Rows.Add(dr)
        Next
        dgvAlerta.DataSource = dt

        If dgvAlerta.Table.Records.Count > 0 Then
            dgvAlerta.Table.Records(0).SetCurrent()
            dgvAlerta.Table.Records(0).SetSelected(True)

            Dim detallename = (From n In ListadoOperaciones _
                        Where n.codigoDetalle = dgvAlerta.Table.CurrentRecord.GetValue("tipooperacion")).FirstOrDefault

            lblOperacion.Text = "Tipo Operación: " & detallename.descripcion

            lblDetalleOperacion.Text = dgvAlerta.Table.CurrentRecord.GetValue("glosa")

            dgvMovimientos.DataSource = New List(Of movimiento)
            'GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
            'UbicarDetalleComprobante(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        End If

    End Sub
#End Region

    Private Sub frmMaestroAsientoContables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblIniciOperaciones.Text = "/ " & Gempresas.InicioOpeaciones
        dgvpagos.TableDescriptor.VisibleColumns.Remove("idDocumento")
        dgvpagos.TableDescriptor.Columns("serie").Width = 55
        dgvpagos.TableDescriptor.Columns("numero").Width = 55

        dgvCobros.TableDescriptor.VisibleColumns.Remove("idDocumento")
        dgvCobros.TableDescriptor.Columns("serie").Width = 55
        dgvCobros.TableDescriptor.Columns("numero").Width = 55

        panelCosto.Visible = False
        ListaAsientos = New List(Of asiento)
        ListaMovimiento = New List(Of movimiento)


        treeViewAdv2.LeftImageList = ImageList1

        For Each node As TreeNodeAdv In Me.treeViewAdv2.Nodes
            node.TextColor = Color.White
            node.Font = New Font("Tahoma", 8)
            node.LeftImageIndices = New Integer() {node.Index}
            'node.RightImageIndices = New Integer() {-1}
        Next node

        treeViewAdv2.BackColor = Color.FromArgb(218, 79, 67) ' Color.DarkRed  Color.FromArgb(41, 44, 51)

        TabRegistroAsientos.Parent = Nothing
        TabAlerta.Parent = Nothing
        TabAlertaVentas.Parent = Nothing
        TabSituacion.Parent = Nothing
        TabInteres.Parent = Nothing
        TabEstadoResultados.Parent = Nothing
        TabApertura.Parent = Nothing
        TabCompras.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabDashboard.Parent = TabContol

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr As DataRow = dt.NewRow
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Dim ggcStyle As GridTableCellStyleInfo = dgvMovimientos.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvMovimientos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        Me.treeViewAdv2.Nodes(1).CustomControl = lblCenter
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Dashboard"
                TabDashboard.Parent = TabContol
                TabRegistroAsientos.Parent = Nothing
                TabAlerta.Parent = Nothing
                TabAlertaVentas.Parent = Nothing
                TabSituacion.Parent = Nothing
                TabInteres.Parent = Nothing
                TabEstadoResultados.Parent = Nothing
                TabApertura.Parent = Nothing
                TabCompras.Parent = Nothing
            Case "Asientos del período"
                TabDashboard.Parent = Nothing
                TabRegistroAsientos.Parent = TabContol
                TabAlerta.Parent = Nothing
                TabAlertaVentas.Parent = Nothing
                TabSituacion.Parent = Nothing
                TabInteres.Parent = Nothing
                TabEstadoResultados.Parent = Nothing
                TabApertura.Parent = Nothing
                TabCompras.Parent = Nothing
            Case "Hoja de trabajo"

            Case "Plan Contable"

            Case "Alertas"
                TabDashboard.Parent = Nothing
                TabRegistroAsientos.Parent = Nothing
                TabAlerta.Parent = TabContol
                TabAlertaVentas.Parent = Nothing
                TabSituacion.Parent = Nothing
                TabInteres.Parent = Nothing
                TabEstadoResultados.Parent = Nothing
                TabApertura.Parent = Nothing
                TabCompras.Parent = Nothing
            Case "Situacion Financiera"
                TabDashboard.Parent = Nothing
                TabRegistroAsientos.Parent = Nothing
                TabAlerta.Parent = Nothing
                TabAlertaVentas.Parent = Nothing
                TabInteres.Parent = Nothing
                TabEstadoResultados.Parent = Nothing
                TabApertura.Parent = Nothing
                TabCompras.Parent = Nothing
                TabSituacion.Parent = TabContol
                '   SituacionFinanciera()

            Case "intereses"

                TabDashboard.Parent = Nothing
                TabRegistroAsientos.Parent = Nothing
                TabAlerta.Parent = Nothing
                TabAlertaVentas.Parent = Nothing
                TabInteres.Parent = TabContol
                TabSituacion.Parent = Nothing
                TabEstadoResultados.Parent = Nothing
                TabApertura.Parent = Nothing
                TabCompras.Parent = Nothing
            Case "eeff"

                TabDashboard.Parent = Nothing
                TabRegistroAsientos.Parent = Nothing
                TabAlerta.Parent = Nothing
                TabAlertaVentas.Parent = Nothing
                TabInteres.Parent = Nothing
                TabSituacion.Parent = Nothing
                TabApertura.Parent = Nothing
                TabCompras.Parent = Nothing
                TabEstadoResultados.Parent = TabContol
                '   EstadosResultadosByFuncion()

            Case "apertura"

                TabDashboard.Parent = Nothing
                TabRegistroAsientos.Parent = Nothing
                TabAlerta.Parent = Nothing
                TabAlertaVentas.Parent = Nothing
                TabInteres.Parent = Nothing
                TabSituacion.Parent = Nothing
                TabEstadoResultados.Parent = Nothing
                TabCompras.Parent = Nothing
                TabApertura.Parent = TabContol
                'GetCuentaManuales()
                'GetSumaCuentasByTipo()

            Case "servicios"

                TabDashboard.Parent = Nothing
                TabRegistroAsientos.Parent = Nothing
                TabAlerta.Parent = Nothing
                TabAlertaVentas.Parent = Nothing
                TabInteres.Parent = Nothing
                TabSituacion.Parent = Nothing
                TabEstadoResultados.Parent = Nothing
                TabApertura.Parent = Nothing
                'TabCompras.Parent = TabContol
                TabCompras.Parent = Nothing
        End Select
    End Sub

    ''' <summary>
    ''' Siatuación Financiera Anual
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SituacionFinanciera()
        Dim movimiento As New List(Of movimiento)
        Dim movimientoSA As New MovimientoSA

        movimiento = movimientoSA.BalanceGeneralAnual(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        Me.gridSituacion(27, 5).Text = 0
        Me.gridSituacion(4, 4).Text = AnioGeneral
        Me.gridSituacion(5, 4).Text = Gempresas.IdEmpresaRuc
        Me.gridSituacion(6, 4).Text = Gempresas.NomEmpresa
        For Each i In movimiento
            Select Case i.cuenta
                Case "10"
                    Me.gridSituacion(12, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "11"
                    Me.gridSituacion(16, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "12"
                    Me.gridSituacion(17, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "13"
                    Me.gridSituacion(20, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "14"
                    Me.gridSituacion(21, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "15"
                    Me.gridSituacion(22, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "16"
                    Me.gridSituacion(23, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "17"
                    Me.gridSituacion(24, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "18"
                    Me.gridSituacion(25, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "19"
                    Me.gridSituacion(26, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "20", "21", "22", "23", "24", "25", "26", "27", "28", "29"
                    Me.gridSituacion(27, 5).Text += (i.debeSaldoS - i.haberSaldoS)

                Case "30"
                    Me.gridSituacion(35, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "31"
                    Me.gridSituacion(36, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "32"
                    Me.gridSituacion(37, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "33"
                    Me.gridSituacion(38, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "34"
                    Me.gridSituacion(39, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "35"
                    Me.gridSituacion(40, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "36"
                    Me.gridSituacion(41, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "37"
                    Me.gridSituacion(42, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "38"
                    Me.gridSituacion(43, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "39"
                    Me.gridSituacion(44, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "40"
                    Me.gridSituacion(28, 5).Text = i.debeSaldoS - i.haberSaldoS


                    'RESULTADOS DEL HABER

                Case "41"
                    Me.gridSituacion(15, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "42"
                    Me.gridSituacion(16, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "43"
                    Me.gridSituacion(18, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "44"
                    Me.gridSituacion(20, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "45"
                    Me.gridSituacion(21, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "46"
                    Me.gridSituacion(22, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "47"
                    Me.gridSituacion(23, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "48"
                    Me.gridSituacion(24, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "49"
                    Me.gridSituacion(25, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "50"
                    Me.gridSituacion(50, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "51"
                    Me.gridSituacion(51, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "52"
                    Me.gridSituacion(52, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "53"
                    Me.gridSituacion(53, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "54"
                    Me.gridSituacion(54, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "55"
                    Me.gridSituacion(55, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "56"
                    Me.gridSituacion(56, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "57"
                    Me.gridSituacion(57, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "58"
                    Me.gridSituacion(58, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "59"
                    Me.gridSituacion(59, 13).Text = i.haberSaldoS - i.debeSaldoS

            End Select

        Next

        Me.gridSituacion(32, 5).Format = "c"
        Me.gridSituacion(48, 5).Format = "c"
        Me.gridSituacion(63, 5).Format = "c"

        Me.gridSituacion(28, 13).Format = "c"
        Me.gridSituacion(45, 13).Format = "c"
        Me.gridSituacion(61, 13).Format = "c"
        Me.gridSituacion(63, 13).Format = "c"
    End Sub


    ''' <summary>
    ''' Reporte Aunual EEFF Estado por función
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EstadosResultadosByFuncion()
        Dim movimiento As New List(Of movimiento)
        Dim movimientoSA As New MovimientoSA

        movimiento = movimientoSA.BalanceGeneralAnual(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        Me.GridControl2(32, 7).Text = 0
        Me.GridControl2(8, 4).Text = AnioGeneral
        Me.GridControl2(9, 4).Text = Gempresas.IdEmpresaRuc
        Me.GridControl2(10, 4).Text = Gempresas.NomEmpresa
        For Each i In movimiento
            Select Case i.cuenta
                Case "70"
                    Me.GridControl2(14, 7).Text = i.haberSaldoS - i.debeSaldoS

                Case "73"
                    Me.GridControl2(15, 7).Text = i.haberSaldoS - i.debeSaldoS

                Case "74"
                    Me.GridControl2(16, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "69"
                    Me.GridControl2(19, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "94"
                    Me.GridControl2(23, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "95"
                    Me.GridControl2(24, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "96"
                    Me.GridControl2(25, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "97"
                    Me.GridControl2(26, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "77"
                    Me.GridControl2(30, 7).Text = i.haberSaldoS - i.debeSaldoS

                Case "75", "76"
                    Me.GridControl2(32, 7).Text += (i.haberSaldoS - i.debeSaldoS)

            End Select

        Next

        Me.GridControl2(17, 7).Format = "c"
        Me.GridControl2(20, 7).Format = "c"
        Me.GridControl2(27, 7).Format = "c"

        Me.GridControl2(39, 7).Format = "c"
        Me.GridControl2(41, 7).Format = "c"
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub ImportacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportacionesToolStripMenuItem.Click
        Dim cierreSA As New empresaCierreMensualSA
        Dim fechaAnt = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        Dim f As New frmnuevoLibroDiario
        If Not IsNothing(dgvAlertaVentas.Table.CurrentRecord) Then
            f.AsientoNotificado = dgvAlertaVentas.Table.CurrentRecord.GetValue("idDocumento")
        Else
            f.AsientoNotificado = Nothing
        End If
        f.valorNode = "AS-M"
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Dashboard"

            Case "Movimientos del período"

            Case "Hoja de Trabajo"
                Dim f As New FrmHojaTrabajo
                f.Show()

            Case "Plan Contable"
                Dim f As New frmcatalogoCuentas
                f.Show()
            Case "Alertas"

            Case "Costos & servicios"
                'GetItemsNoAsignados()

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        lsvPlantilla.Items.Clear()
        ListaAsientos = New List(Of asiento)
        ListaMovimiento = New List(Of movimiento)
        GetAlertaInventarios()
        'ToolStripButton6_Click(sender, e)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboOperacion_Click(sender As Object, e As EventArgs) Handles cboOperacion.Click

    End Sub

    Private Sub cboOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOperacion.SelectedIndexChanged
        'GetPlantillaByOperacion()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.dgvAlerta.Table.SelectedRecords.Clear()
        Me.dgvAlerta.Table.Records.SelectAll()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.dgvAlerta.Table.SelectedRecords.Clear()
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCuentaBuscar.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcCuentas.Font = New Font("Segoe UI", 8)
            Me.pcCuentas.Size = New Size(337, 142)
            Me.pcCuentas.ParentControl = Me.txtCodigoCuentaBuscar
            Me.pcCuentas.ShowPopup(Point.Empty)
            Dim consulta = (From n In ListadoCuentasContables _
                     Where n.cuenta.StartsWith(txtCodigoCuentaBuscar.Text)).ToList

            lsvCuentasEncontradas.DataSource = consulta
            lsvCuentasEncontradas.DisplayMember = "descripcion"
            lsvCuentasEncontradas.ValueMember = "cuenta"
           
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcCuentas.Font = New Font("Segoe UI", 8)
            Me.pcCuentas.Size = New Size(337, 142)
            Me.pcCuentas.ParentControl = Me.txtCodigoCuentaBuscar
            Me.pcCuentas.ShowPopup(Point.Empty)
            lsvCuentasEncontradas.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcCuentas.IsShowing() Then
                Me.pcCuentas.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtRuc_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoCuentaBuscar.TextChanged

    End Sub

    Private Sub pcCuentas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcCuentas.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCuentasEncontradas.SelectedItems.Count > 0 Then
                txtCuentaSel.Text = lsvCuentasEncontradas.Text
                txtCuentaSel.Tag = lsvCuentasEncontradas.SelectedValue


                If lstAsientos.SelectedItems.Count > 0 Then
                    If txtCuentaSel.Text.Trim.Length > 0 Then
                        AddMovimiento()
                    End If
                End If
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCodigoCuentaBuscar.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvCuentasEncontradas_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        Me.pcCuentas.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvCuentasEncontradas_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            AddAsiento()
        Else
            MessageBoxAdv.Show("Debe seleccionar el documento base!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub AddAsientoInventarioOE()
        Dim n As New asiento
        n.periodo = PeriodoGeneral
        n.Action = Business.Entity.BaseBE.EntityAction.INSERT
        n.idDocumento = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento"))
        n.idEmpresa = Gempresas.IdEmpresaRuc
        n.idCentroCostos = GEstableciento.IdEstablecimiento
        n.fechaProceso = DateTime.Now
        n.codigoLibro = "13"
        n.tipo = "D"
        n.tipoAsiento = "AS-M"
        n.glosa = lblDetalleOperacion.Text
        If ListaAsientos.Count > 0 Then
            n.idAsiento = ListaAsientos.Count + 1
            n.Descripcion = "Asiento " & ListaAsientos.Count + 1
        Else
            n.idAsiento = 1
            n.Descripcion = "Asiento " & 1
        End If
        n.usuarioActualizacion = usuario.IDUsuario
        n.fechaActualizacion = DateTime.Now
        ListaAsientos.Add(n)
        '--------------------------------------------------------------------------------------
        'MOVIMIENTO
        Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
            Case TIPO_COMPRA.OTRAS_ENTRADAS

                For Each i As ListViewItem In lsvPlantilla.Items
                    Select Case i.SubItems(5).Text
                        Case "MERCADERIA" '01
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "20111"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)


                        Case "PRODUCTO TERMINADO" '02
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "211"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "MATERIAS PRIMAS" '03
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "241"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)
                        Case "ENVASES Y EMBALAJES" '04
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "261"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS" '05
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "251"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS" '06
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "221"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "PRODUCTOS EN PROCESO" '07
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "231"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "ACTIVO INMOVILIZADO" '08
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "338"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)
                    End Select
                Next

                
            Case TIPO_VENTA.OTRAS_SALIDAS
                For Each i As ListViewItem In lsvPlantilla.Items
                    Select Case i.SubItems(5).Text
                        Case "MERCADERIA" '01
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "20111"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)


                        Case "PRODUCTO TERMINADO" '02
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "211"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "MATERIAS PRIMAS" '03
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "241"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)
                        Case "ENVASES Y EMBALAJES" '04
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "261"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS" '05
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "251"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS" '06
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "221"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "PRODUCTOS EN PROCESO" '07
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "231"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "ACTIVO INMOVILIZADO" '08
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "338"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)
                    End Select
                Next
        End Select
        GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = n.idAsiento})
    End Sub


    Private Sub AddAsientoFinanzas()
        Dim n As New asiento
        n.periodo = PeriodoGeneral
        n.Action = Business.Entity.BaseBE.EntityAction.INSERT
        n.idDocumento = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento"))
        n.idEmpresa = Gempresas.IdEmpresaRuc
        n.idCentroCostos = GEstableciento.IdEstablecimiento
        n.fechaProceso = DateTime.Now

        Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
            Case "OEC"
                n.codigoLibro = "1"
            Case "OSC"
                n.codigoLibro = "1"
            Case TIPO_COMPRA.OTRAS_ENTRADAS
                n.codigoLibro = "13"
            Case TIPO_VENTA.OTRAS_SALIDAS
                n.codigoLibro = "13"
        End Select

        n.tipo = "D"
        n.tipoAsiento = "AS-M"
        n.glosa = lblDetalleOperacion.Text
        If ListaAsientos.Count > 0 Then
            n.idAsiento = ListaAsientos.Count + 1
            n.Descripcion = "Asiento " & ListaAsientos.Count + 1
        Else
            n.idAsiento = 1
            n.Descripcion = "Asiento " & 1
        End If
        n.usuarioActualizacion = usuario.IDUsuario
        n.fechaActualizacion = DateTime.Now
        ListaAsientos.Add(n)
        '--------------------------------------------------------------------------------------
        'MOVIMIENTO
        Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
            Case "OEC"
                Dim nc As New movimiento
                nc.idAsiento = n.idAsiento
                If ListaMovimiento.Count > 0 Then
                    nc.idmovimiento = ListaMovimiento.Count + 1
                Else
                    nc.idmovimiento = 1
                End If
                nc.cuenta = dgvAlerta.Table.CurrentRecord.GetValue("NroDocEntidad")
                nc.descripcion = dgvAlerta.Table.CurrentRecord.GetValue("NombreEntidad")
                nc.tipo = "D"
                nc.monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal"))
                nc.montoUSD = 0

                ListaMovimiento.Add(nc)
            Case "OSC"
                Dim nc As New movimiento
                nc.idAsiento = n.idAsiento
                If ListaMovimiento.Count > 0 Then
                    nc.idmovimiento = ListaMovimiento.Count + 1
                Else
                    nc.idmovimiento = 1
                End If
                nc.cuenta = dgvAlerta.Table.CurrentRecord.GetValue("NroDocEntidad")
                nc.descripcion = dgvAlerta.Table.CurrentRecord.GetValue("NombreEntidad")
                nc.tipo = "H"
                nc.monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal"))
                nc.montoUSD = 0

                ListaMovimiento.Add(nc)
            Case TIPO_COMPRA.OTRAS_ENTRADAS

            Case TIPO_VENTA.OTRAS_SALIDAS

        End Select
        GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = n.idAsiento})
    End Sub
    Dim n As New asiento

    Private Sub AddAsiento()
        Dim n As New asiento
        n.periodo = PeriodoGeneral
        n.Action = Business.Entity.BaseBE.EntityAction.INSERT
        n.idDocumento = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento"))
        n.idEmpresa = Gempresas.IdEmpresaRuc
        n.idCentroCostos = GEstableciento.IdEstablecimiento
        n.fechaProceso = DateTime.Now

        Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
            Case "OEC"
                n.codigoLibro = "1"
            Case "OSC"
                n.codigoLibro = "1"
            Case TIPO_COMPRA.OTRAS_ENTRADAS
                n.codigoLibro = "13"
            Case TIPO_VENTA.OTRAS_SALIDAS
                n.codigoLibro = "13"
        End Select

        n.tipo = "D"
        n.tipoAsiento = "AS-M"
        n.glosa = lblDetalleOperacion.Text
        If ListaAsientos.Count > 0 Then
            n.idAsiento = ListaAsientos.Count + 1
            n.Descripcion = "Asiento " & ListaAsientos.Count + 1
        Else
            n.idAsiento = 1
            n.Descripcion = "Asiento " & 1
        End If
        n.usuarioActualizacion = usuario.IDUsuario
        n.fechaActualizacion = DateTime.Now
        ListaAsientos.Add(n)
        GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
    End Sub

    Private Sub AddMovimiento()
        Dim n As New movimiento
        n.idAsiento = lstAsientos.SelectedValue
        If ListaMovimiento.Count > 0 Then
            n.idmovimiento = ListaMovimiento.Count + 1
        Else
            n.idmovimiento = 1
        End If
        n.cuenta = txtCuentaSel.Tag
        n.descripcion = txtCuentaSel.Text
        n.tipo = "D"
        n.monto = 0
        n.montoUSD = 0

        ListaMovimiento.Add(n)

        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
    End Sub

    Private Sub EliminarFilaMovimiento(mov As movimiento)
        Dim consulta = (From n In ListaMovimiento _
                       Where n.idmovimiento = mov.idmovimiento).FirstOrDefault

        ListaMovimiento.Remove(consulta)
        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
    End Sub


    Private Sub UbicarDetalleComprobante(intIdDocumento As Integer)
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim suma As Decimal = 0
        lsvPlantilla.Items.Clear()

        For Each i In compraSA.UbicarDocumentoCompraDetalle(intIdDocumento)
            suma += CDec(i.importe)
            Dim n As New ListViewItem(i.secuencia)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.destino)
            n.SubItems.Add(i.monto1)
            n.SubItems.Add(i.importe)
            Select Case i.tipoExistencia
                Case "01"
                    n.SubItems.Add("MERCADERIA")
                Case "02"
                    n.SubItems.Add("PRODUCTO TERMINADO")
                Case "03"
                    n.SubItems.Add("MATERIAS PRIMAS")
                Case "04"
                    n.SubItems.Add("ENVASES Y EMBALAJES")
                Case "05"
                    n.SubItems.Add("MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS")
                Case "06"
                    n.SubItems.Add("SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS")
                Case "07"
                    n.SubItems.Add("PRODUCTOS EN PROCESO")

                Case "08"
                    n.SubItems.Add("ACTIVO INMOVILIZADO")

            End Select

            lsvPlantilla.Items.Add(n)

            'Dim n2 As New ListViewItem()
            'Select Case i.tipoExistencia
            '    Case "01"
            '        n2.SubItems.Add("MERCADERIA").BackColor = Color.LightYellow
            '    Case "02"
            '        n2.SubItems.Add("PRODUCTO TERMINADO").BackColor = Color.LightYellow
            '    Case "03"
            '        n2.SubItems.Add("MATERIAS PRIMAS").BackColor = Color.LightYellow
            '    Case "04"
            '        n2.SubItems.Add("ENVASES Y EMBALAJES").BackColor = Color.LightYellow
            '    Case "05"
            '        n2.SubItems.Add("MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS").BackColor = Color.LightYellow
            '    Case "06"
            '        n2.SubItems.Add("SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS").BackColor = Color.LightYellow
            '    Case "07"
            '        n2.SubItems.Add("PRODUCTOS EN PROCESO").BackColor = Color.LightYellow

            '    Case "08"
            '        n2.SubItems.Add("ACTIVO INMOVILIZADO").BackColor = Color.LightYellow

            'End Select
            'n2.SubItems.Add(String.Empty)
            'n2.SubItems.Add(String.Empty)
            'n2.SubItems.Add(String.Empty)
            'n2.SubItems.Add(String.Empty)
            'lsvPlantilla.Items.Add(n2)

        Next

        'Dim n1 As New ListViewItem()
        'n1.SubItems.Add("Total")
        'n1.SubItems.Add(String.Empty)
        'n1.SubItems.Add(String.Empty)
        'n1.SubItems.Add(suma)
        'n1.SubItems.Add(String.Empty)
        'lsvPlantilla.Items.Add(n1)
    End Sub

    Private Sub GetListadoAsientos(intIdDocumento As Integer)
        Dim con = (From n In ListaAsientos _
                   Where n.idDocumento = intIdDocumento).ToList

        lstAsientos.DataSource = con
        lstAsientos.ValueMember = "idAsiento"
        lstAsientos.DisplayMember = "Descripcion"
    End Sub

    Private Sub GetListadoMovimientoByAsiento(be As asiento)
        Dim con = (From n In ListaMovimiento _
                  Where n.idAsiento = be.idAsiento).ToList

        dgvMovimientos.DataSource = con
    End Sub

    Private Sub EliminarAsientoByCodigo(be As asiento)

        Dim con1 = (From n In ListaMovimiento _
                   Where n.idAsiento = be.idAsiento).ToList

        For Each i In con1
            ListaMovimiento.Remove(i)
        Next

        Dim con2 = (From n In ListaAsientos _
                   Where n.idAsiento = be.idAsiento).FirstOrDefault

        ListaAsientos.Remove(con2)

        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        End If

        If lstAsientos.SelectedItems.Count > 0 Then
            GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
        Else
            dgvMovimientos.DataSource = New List(Of movimiento)
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If lstAsientos.SelectedItems.Count > 0 Then
            If txtCuentaSel.Text.Trim.Length > 0 Then
                AddMovimiento()
            End If
        End If
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
    End Sub

    Private Sub lstAsientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAsientos.SelectedIndexChanged
        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            Dim cod = lstAsientos.SelectedValue
            If IsNumeric(cod) Then
                GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
            End If
        End If
    End Sub

    Private Sub dgvAlerta_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAlerta.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            Dim detallename = (From n In ListadoOperaciones _
                          Where n.codigoDetalle = dgvAlerta.Table.CurrentRecord.GetValue("tipooperacion")).FirstOrDefault

            lblOperacion.Text = "Tipo Operación: " & detallename.descripcion

            lblDetalleOperacion.Text = dgvAlerta.Table.CurrentRecord.GetValue("glosa")

            dgvMovimientos.DataSource = New List(Of movimiento)
            GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
            UbicarDetalleComprobante(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))

            panelCosto.Visible = False
        End If

        

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        If Not IsNothing(dgvMovimientos.Table.CurrentRecord) Then
            EliminarFilaMovimiento(New movimiento With {.idmovimiento = Val(dgvMovimientos.Table.CurrentRecord.GetValue("idmovimiento"))})
        End If
    End Sub

    Private Sub lsvCuentasEncontradas_MouseDoubleClick1(sender As Object, e As MouseEventArgs) Handles lsvCuentasEncontradas.MouseDoubleClick
        If lsvCuentasEncontradas.SelectedItems.Count > 0 Then
            Me.pcCuentas.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvCuentasEncontradas_MouseDown(sender As Object, e As MouseEventArgs) Handles lsvCuentasEncontradas.MouseDown

    End Sub

    Private Sub lsvCuentasEncontradas_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lsvCuentasEncontradas.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If lstAsientos.SelectedItems.Count > 0 Then
            EliminarAsientoByCodigo(New asiento With {.idAsiento = lstAsientos.SelectedValue})
        End If
    End Sub

    Function validacionCajaCosto() As Boolean
        Dim costoSA As New recursoCostoSA
        Dim valReturn As Boolean
        Dim cuentasCosto = (From n In ListaMovimiento _
                           Where n.cuenta.StartsWith("6")).ToList

        For Each i In cuentasCosto
            Dim codigoContable = Mid(i.cuenta, 1, 2)

            Select Case Val(codigoContable)
                Case 62 To 68
                    If panelCosto.Visible Then
                        If rbCosto.Checked Or rbGasto.Checked Then

                            valReturn = True

                            Dim nAsiento As New asiento
                            Dim nMovimiento As New movimiento
                            Dim codLibro As String = dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")

                            Select Case codLibro
                                Case "OSA"
                                    codLibro = "13"
                                Case "OEA"
                                    codLibro = "13"
                                Case Else
                                    codLibro = "1"
                            End Select

                            If panelCosto.Visible = True Then
                                'ASIENTOS CONTABLES
                                nAsiento = New asiento With {
                                    .periodo = PeriodoGeneral,
                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                .idCentroCostos = GEstableciento.IdEstablecimiento,
                                .idDocumento = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")),
                                .idDocumentoRef = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")),
                                .idAlmacen = 0,
                                .nombreAlmacen = String.Empty,
                                .idEntidad = String.Empty,
                                .nombreEntidad = String.Empty,
                                .tipoEntidad = String.Empty,
                                .fechaProceso = CDate(dgvAlerta.Table.CurrentRecord.GetValue("fechaDoc")),
                                .codigoLibro = codLibro,
                                .tipo = "D",
                                .tipoAsiento = "ACCA",
                                .importeMN = 0,
                                .importeME = 0,
                                .glosa = lblDetalleOperacion.Text.Trim,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now}
                            End If

                            Select Case txtTipoCosto.Text
                                Case TipoCosto.Proyecto
                                    nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
                                    .descripcion = "MATERIALES AUXILIARES",
                                    .tipo = "D",
                                    .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                    .montoUSD = 0,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                    nAsiento.movimiento.Add(nMovimiento)


                                    nMovimiento = New movimiento With {
                                 .cuenta = "791",
                                 .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                 .tipo = "H",
                                 .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                 .montoUSD = 0,
                                 .usuarioActualizacion = usuario.IDUsuario,
                                 .fechaActualizacion = DateTime.Now
                             }
                                    nAsiento.movimiento.Add(nMovimiento)


                                Case TipoCosto.OrdenProduccion

                                    nMovimiento = New movimiento With {
                                        .cuenta = "231",
                                        .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                        .tipo = "D",
                                        .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                        .montoUSD = 0,
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    nAsiento.movimiento.Add(nMovimiento)


                                    nMovimiento = New movimiento With {
                                        .cuenta = "7111",
                                        .descripcion = "PRODUCTOS MANUFACTURADOS",
                                        .tipo = "H",
                                        .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                        .montoUSD = 0,
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    nAsiento.movimiento.Add(nMovimiento)

                                Case TipoCosto.ActivoFijo


                                    nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
                                    .descripcion = "CONSTRUCCIONES Y OBRAS EN CURSO",
                                    .tipo = "D",
                                    .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                    .montoUSD = 0,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                    nAsiento.movimiento.Add(nMovimiento)


                                    nMovimiento = New movimiento With {
                                        .cuenta = "7225",
                                        .descripcion = "EQUIPOS DIVERSOS",
                                        .tipo = "H",
                                        .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                        .montoUSD = 0,
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    nAsiento.movimiento.Add(nMovimiento)

                                Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero


                                    nMovimiento = New movimiento With {
                                   .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboCosto.SelectedValue}).codigo,
                                   .descripcion = "GASTOS ADMINISTRATIVOS.",
                                   .tipo = "D",
                                   .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                   .montoUSD = 0,
                                   .usuarioActualizacion = usuario.IDUsuario,
                                   .fechaActualizacion = DateTime.Now
                               }
                                    nAsiento.movimiento.Add(nMovimiento)


                                    nMovimiento = New movimiento With {
                                        .cuenta = "79",
                                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        .tipo = "H",
                                        .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                        .montoUSD = 0,
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    nAsiento.movimiento.Add(nMovimiento)

                            End Select
                            ListaAsientos.Add(nAsiento)
                        Else
                            panelCosto.Visible = True
                            MessageBoxAdv.Show("Debe identificar el costo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            valReturn = False
                        End If
                    Else
                        panelCosto.Visible = True
                        MessageBoxAdv.Show("Debe habilitar el centro de costos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        valReturn = False
                    End If
                Case Else
                    panelCosto.Visible = False
                    valReturn = False
            End Select
        Next
        Return valReturn
    End Function


    Sub validacionCosto()
        Dim costoSA As New recursoCostoSA
        Dim valReturn As Boolean
        Dim cuentasCosto = (From n In ListaMovimiento _
                           Where n.cuenta.StartsWith("6")).ToList

        For Each i In cuentasCosto
            Dim codigoContable = Mid(i.cuenta, 1, 2)

            Select Case Val(codigoContable)
                Case 62 To 68
                    If panelCosto.Visible Then
                        If rbCosto.Checked Or rbGasto.Checked Then

                            valReturn = True

                            Dim nAsiento As New asiento
                            Dim nMovimiento As New movimiento
                            Dim codLibro As String = dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")

                            Select Case codLibro
                                Case "OSA"
                                    codLibro = "13"
                                Case "OEA"
                                    codLibro = "13"
                                Case Else
                                    codLibro = "1"
                            End Select

                            If panelCosto.Visible = True Then
                                'ASIENTOS CONTABLES
                                nAsiento = New asiento With {
                                    .periodo = PeriodoGeneral,
                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                .idCentroCostos = GEstableciento.IdEstablecimiento,
                                .idDocumento = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")),
                                .idDocumentoRef = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")),
                                .idAlmacen = 0,
                                .nombreAlmacen = String.Empty,
                                .idEntidad = String.Empty,
                                .nombreEntidad = String.Empty,
                                .tipoEntidad = String.Empty,
                                .fechaProceso = CDate(dgvAlerta.Table.CurrentRecord.GetValue("fechaDoc")),
                                .codigoLibro = codLibro,
                                .tipo = "D",
                                .tipoAsiento = "ACCA",
                                .importeMN = 0,
                                .importeME = 0,
                                .glosa = lblDetalleOperacion.Text.Trim,
                                .usuarioActualizacion = usuario.IDUsuario,
                                .fechaActualizacion = DateTime.Now}
                            End If

                            Select Case txtTipoCosto.Text
                                Case TipoCosto.Proyecto, _
                                    TipoCosto.CONTRATOS_DE_CONSTRUCCION, _
                                    TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES, _
                                    TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                                    nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
                                    .descripcion = "MATERIALES AUXILIARES",
                                    .tipo = "D",
                                    .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                    .montoUSD = 0,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                    nAsiento.movimiento.Add(nMovimiento)


                                    nMovimiento = New movimiento With {
                                 .cuenta = "791",
                                 .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                 .tipo = "H",
                                 .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                 .montoUSD = 0,
                                 .usuarioActualizacion = usuario.IDUsuario,
                                 .fechaActualizacion = DateTime.Now
                             }
                                    nAsiento.movimiento.Add(nMovimiento)


                                Case TipoCosto.OrdenProduccion, _
                                    TipoCosto.OP_CONTINUA_DE_BIENES, _
                                    TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE, _
                                    TipoCosto.OP_CONTINUA_DE_SERVICIOS, _
                                    TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE, _
                                    TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES

                                    nMovimiento = New movimiento With {
                                        .cuenta = "231",
                                        .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                        .tipo = "D",
                                        .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                        .montoUSD = 0,
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    nAsiento.movimiento.Add(nMovimiento)


                                    nMovimiento = New movimiento With {
                                        .cuenta = "7111",
                                        .descripcion = "PRODUCTOS MANUFACTURADOS",
                                        .tipo = "H",
                                        .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                        .montoUSD = 0,
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    nAsiento.movimiento.Add(nMovimiento)

                                Case TipoCosto.ActivoFijo


                                    nMovimiento = New movimiento With {
                                    .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
                                    .descripcion = "CONSTRUCCIONES Y OBRAS EN CURSO",
                                    .tipo = "D",
                                    .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                    .montoUSD = 0,
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                    nAsiento.movimiento.Add(nMovimiento)


                                    nMovimiento = New movimiento With {
                                        .cuenta = "7225",
                                        .descripcion = "EQUIPOS DIVERSOS",
                                        .tipo = "H",
                                        .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                        .montoUSD = 0,
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    nAsiento.movimiento.Add(nMovimiento)

                                Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero


                                    nMovimiento = New movimiento With {
                                   .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboCosto.SelectedValue}).codigo,
                                   .descripcion = "GASTOS ADMINISTRATIVOS.",
                                   .tipo = "D",
                                   .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                   .montoUSD = 0,
                                   .usuarioActualizacion = usuario.IDUsuario,
                                   .fechaActualizacion = DateTime.Now
                               }
                                    nAsiento.movimiento.Add(nMovimiento)


                                    nMovimiento = New movimiento With {
                                        .cuenta = "79",
                                        .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                        .tipo = "H",
                                        .monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal")),
                                        .montoUSD = 0,
                                        .usuarioActualizacion = usuario.IDUsuario,
                                        .fechaActualizacion = DateTime.Now
                                    }
                                    nAsiento.movimiento.Add(nMovimiento)

                            End Select
                            ListaAsientos.Add(nAsiento)
                        Else
                            panelCosto.Visible = True
                            MessageBoxAdv.Show("Debe identificar el costo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If
                    Else
                        panelCosto.Visible = True
                        MessageBoxAdv.Show("Debe habilitar el centro de costos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                Case Else
                    
            End Select
        Next
    End Sub

    Private Sub GrabarListaAsientos()
        Dim asientoSA As New AsientoSA

        'If dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra") = "OSC" Or dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_VENTA.OTRAS_SALIDAS Then

        Dim sumMov = (From t In ListaMovimiento _
                     Where t.cuenta.StartsWith("6")).ToList

        Dim keyCosto As Integer = 0
        For Each i In sumMov
            Dim cod = Mid(i.cuenta, 1, 2)
            Select Case cod
                Case 62 To 68
                    keyCosto += 1
                Case Else

            End Select
        Next

        If keyCosto > 0 Then
            'If panelCosto.Visible = True Then
            '    If rbCosto.Checked Or rbGasto.Checked = True Then

            'Dim updateCosto = (From n In ListaAsientos
            '                   Select n).ToList

            'For Each i In updateCosto
            '    If rbCosto.Checked = True Then
            '        i.idCosto = cboElementoCosto.SelectedValue
            '        i.IdProceso = cboproceso2.SelectedValue
            '    ElseIf rbGasto.Checked = True Then
            '        i.idCosto = cboCosto.SelectedValue
            '        i.IdProceso = cboproceso2.SelectedValue
            '    End If
            'Next

            '        validacionCosto() ' add asiento adicional por el costo


            '        If cboproceso2.Text.Trim.Length > 0 Then
            asientoSA.GrabarListaAsientosXConciliar(ListaAsientos)

            For Each i In ListaAsientos
                For Each r As Record In dgvAlerta.Table.Records
                    If r.GetValue("idDocumento") = i.idDocumento Then
                        r.Delete()
                    End If
                Next
            Next
            MessageBoxAdv.Show("Comprobantes asignados!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ButtonAdv1.Focus()
            ButtonAdv1.Select()
            ListaAsientos = New List(Of asiento)
            ListaMovimiento = New List(Of movimiento)
            lstAsientos.DataSource = Nothing
            dgvMovimientos.DataSource = New List(Of movimiento)
            lblOperacion.Text = String.Empty
            panelCosto.Visible = False
            getAlertasInventario()

            '        Else
            '            MessageBoxAdv.Show("Debe seleccionar un proceso!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '            cboproceso2.Select()
            '            cboproceso2.DroppedDown = True
            '        End If

            '    Else
            '        panelCosto.Visible = True
            '        MessageBox.Show("Debe Identificar el costo!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'Else
            '    panelCosto.Visible = True
            '    MessageBox.Show("Debe Identificar el costo!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    rbGasto.Checked = True
            'End If
        Else
            panelCosto.Visible = False
            asientoSA.GrabarListaAsientosXConciliar(ListaAsientos)


            For Each i In ListaAsientos
                For Each r As Record In dgvAlerta.Table.Records
                    If r.GetValue("idDocumento") = i.idDocumento Then
                        r.Delete()
                    End If
                Next
            Next
            MessageBoxAdv.Show("Comprobantes asignados!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ButtonAdv1.Focus()
            ButtonAdv1.Select()
            ListaAsientos = New List(Of asiento)
            ListaMovimiento = New List(Of movimiento)
            lstAsientos.DataSource = Nothing
            dgvMovimientos.DataSource = New List(Of movimiento)
            lblOperacion.Text = String.Empty
            panelCosto.Visible = False
            getAlertasInventario()
        End If


        'If panelCosto.Visible Then
        '    If validacionCajaCosto() = True Then
        '        Dim updateCosto = (From n In ListaAsientos _
        '                          Select n).ToList

        '        For Each i In updateCosto
        '            i.idCosto = cboElementoCosto.SelectedValue
        '        Next

        '    Else
        '        Exit Sub

        '    End If

        'Else

        'End If


        
    End Sub
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        If ListaAsientos.Count > 0 Then
            For Each i In ListaAsientos

                Dim conteoMov = ListaMovimiento.Where(Function(o) o.idAsiento = i.idAsiento).Count

                If conteoMov > 0 Then

                    For Each mov In ListaMovimiento
                        If i.idAsiento = mov.idAsiento Then

                            Dim sumaDebe As Decimal = 0
                            sumaDebe = ListaMovimiento.Where(Function(o) o.idAsiento = i.idAsiento And o.tipo = "D").Sum(Function(o) o.monto)

                            If sumaDebe <= 0 Then
                                MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "El monto de la columna del debe es cero, verifique.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If


                            Dim sumaHaber As Decimal = 0
                            sumaHaber = ListaMovimiento.Where(Function(o) o.idAsiento = i.idAsiento And o.tipo = "H").Sum(Function(o) o.monto)


                            If sumaHaber <= 0 Then
                                MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "El monto de la columna del haber es cero, verifique.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If

                            If sumaDebe <> sumaHaber Then
                                MessageBoxAdv.Show("El " & i.Descripcion & vbCrLf & vbCrLf & "Deben cuadrar los asientos del debe y haber.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If

                            i.movimiento.Add(mov)
                        End If
                    Next
                Else
                    MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "El asiento no contiene movimientos!", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

            Next
        Else
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        GrabarListaAsientos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        lsvPlantilla.Items.Clear()
        ListaAsientos = New List(Of asiento)
        ListaMovimiento = New List(Of movimiento)
        GetAlertaFinanzas()

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblAlertaInventario_Click(sender As Object, e As EventArgs) Handles lblAlertaInventario.Click

    End Sub

    Private Sub lblAlertasgeneral_Click(sender As Object, e As EventArgs) Handles lblAlertasgeneral.Click
        TabDashboard.Parent = Nothing
        TabRegistroAsientos.Parent = Nothing
        TabAlertaVentas.Parent = Nothing
        TabSituacion.Parent = Nothing
        TabInteres.Parent = Nothing
        TabAlerta.Parent = TabContol
    End Sub

    Private Sub btAlertaVentas_Click(sender As Object, e As EventArgs) Handles btAlertaVentas.Click
        Me.Cursor = Cursors.WaitCursor
        TabDashboard.Parent = Nothing
        TabRegistroAsientos.Parent = Nothing
        TabAlerta.Parent = Nothing
        TabSituacion.Parent = Nothing
        TabInteres.Parent = Nothing
        TabAlertaVentas.Parent = TabContol
        getVentasObservadas()
        If dgvAlertaVentas.Table.Records.Count > 0 Then
            dgvAlertaVentas.Table.Records(0).SetCurrent()
            dgvAlertaVentas.Table.Records(0).SetSelected(True)

            VerAsientosByDocumento(dgvAlertaVentas.Table.CurrentRecord.GetValue("idDocumento"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub VerAsientosByDocumento(intIdDocumento As Integer)
        Dim movimientoSA As New MovimientoSA

        Dim dt As New DataTable()
        dt.Columns.Add("idAsiento")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("debe")
        dt.Columns.Add("haber")
        Dim codAsiento As Integer = 0
        Dim conteo As Integer = 0
        For Each i In movimientoSA.UbicarAsientoXidDocumento(intIdDocumento)

            If codAsiento = i.idAsiento Then
                Dim dr As DataRow = dt.NewRow
                dr(0) = i.idAsiento
                dr(1) = i.cuenta
                dr(2) = i.descripcion
                Select Case i.tipo
                    Case "D"
                        dr(3) = i.monto
                        dr(4) = 0.0
                    Case "H"
                        dr(3) = 0.0
                        dr(4) = i.monto
                End Select
                dt.Rows.Add(dr)
            Else
                conteo += 1

                Dim dr1 As DataRow = dt.NewRow
                dr1(0) = String.Empty
                dr1(1) = String.Empty
                dr1(2) = String.Empty
                dr1(3) = String.Empty
                dr1(4) = String.Empty
                dt.Rows.Add(dr1)

                Dim dr0 As DataRow = dt.NewRow
                dr0(0) = i.idAsiento
                dr0(1) = String.Empty
                dr0(2) = "Asiento N° " & conteo
                dr0(3) = String.Empty
                dr0(4) = String.Empty
                dt.Rows.Add(dr0)


                Dim dr As DataRow = dt.NewRow
                dr(0) = i.idAsiento
                dr(1) = i.cuenta
                dr(2) = i.descripcion
                Select Case i.tipo
                    Case "D"
                        dr(3) = i.monto
                        dr(4) = 0.0
                    Case "H"
                        dr(3) = 0.0
                        dr(4) = i.monto
                End Select
                dt.Rows.Add(dr)
            End If

            codAsiento = i.idAsiento
        Next
        dgvAsientosventa.DataSource = dt

    End Sub
    Private Sub dgvAlertaVentas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAlertaVentas.TableControlCellClick
        If Not IsNothing(dgvAlertaVentas.Table.CurrentRecord) Then
            VerAsientosByDocumento(dgvAlertaVentas.Table.CurrentRecord.GetValue("idDocumento"))
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        If TabContol.SelectedTab Is TabSituacion Then
            SituacionFinanciera()
        ElseIf TabContol.SelectedTab Is TabRegistroAsientos Then
            '    ListadoLibroAsiento("AS-M")

        ElseIf TabContol.SelectedTab Is TabEstadoResultados Then
            EstadosResultadosByFuncion()

        ElseIf TabContol.SelectedTab Is TabApertura Then
            TabApertura.Parent = TabContol
            GetCuentaManuales()
            GetSumaCuentasByTipo()

        ElseIf TabContol.SelectedTab Is TabCompras Then
            GetItemsNoAsignados()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            ListaAsientos = New List(Of asiento)
            ListaMovimiento = New List(Of movimiento)


            Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
                Case "OEC", "OSC"
                    AddAsientoFinanzas()

                Case TIPO_COMPRA.OTRAS_ENTRADAS
                    AddAsientoInventarioOE()
                Case TIPO_VENTA.OTRAS_SALIDAS
                    AddAsientoInventarioOE()
            End Select


        End If

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If TabContol.SelectedTab Is TabRegistroAsientos Then
        '    If Not IsNothing(dgvLibroDiario.Table.CurrentRecord) Then
        '        Dim frm As New frmnuevoLibroDiario(dgvLibroDiario.Table.CurrentRecord.GetValue("idDocumento"))
        '        frm.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        '        frm.Tag = "editar"
        '        frm.StartPosition = FormStartPosition.CenterParent
        '        frm.ShowDialog()
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If TabContol.SelectedTab Is TabRegistroAsientos Then
        '    If Not IsNothing(dgvLibroDiario.Table.CurrentRecord) Then
        '        If MessageBoxAdv.Show("Desea eliminar el asiento seleccionado? ", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '            EliminarLibroDiario(Val(dgvLibroDiario.Table.CurrentRecord.GetValue("idDocumento")))
        '            ListadoLibroAsiento("AS-M")
        '        End If
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbCosto_CheckChanged(sender As Object, e As EventArgs) Handles rbCosto.CheckChanged
        If rbCosto.Checked = True Then
            'Label3.Text = "Asignar recursos (Elmento del costo)"
            cboElementoCosto.Visible = True

            GetCostoByTipoCMBServicios1(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
            cboCosto.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboTipoCosto_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub cboTipoCosto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCosto.SelectedIndexChanged
    '    'cboCosto.DataSource = Nothing
    '    'Dim codValue = cboTipoCosto.Text.ToString

    '    'Select Case codValue
    '    '    Case "PROYECTO"
    '    '        GetCostoByTipoCMB(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
    '    '    Case "ORDEN DE PRODUCCION"
    '    '        GetCostoByTipoCMB(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OrdenProduccion})
    '    '    Case "ACTIVO FIJO"
    '    '        GetCostoByTipoCMB(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})
    '    '    Case "GASTO ADMINISTRATIVO"
    '    '        GetCostoByTipoCMB(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
    '    '    Case "GASTO DE VENTAS"
    '    '        GetCostoByTipoCMB(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
    '    '    Case "GASTO FINANCIERO"
    '    '        GetCostoByTipoCMB(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})
    '    'End Select

    '    'cboCosto.SelectedIndex = -1
    'End Sub
    Sub ComboProcesos1(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA

        cboproceso2.DataSource = costoSA.GetActividadProcesoByProyecto(New recursoCosto With {.idCosto = intIdCostoPadre})
        cboproceso2.ValueMember = "idCosto"
        cboproceso2.DisplayMember = "nombreCosto"
    End Sub
    Private Sub rbGasto_CheckChanged(sender As Object, e As EventArgs) Handles rbGasto.CheckChanged
        If rbGasto.Checked = True Then
            'Label3.Text = "Asignar recursos"
            cboElementoCosto.Visible = False

        End If
    End Sub

    Private Sub cboCosto_Click(sender As Object, e As EventArgs) Handles cboCosto.Click

    End Sub

    Private Sub cboCosto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCosto.SelectedIndexChanged
        Dim costoSA As New recursoCostoSA
        cboElementoCosto.DataSource = Nothing
        cboproceso2.DataSource = Nothing
        If cboCosto.SelectedIndex > -1 Then
            If rbCosto.Checked = True Then
                Dim recursoSA As New recursoCostoSA

                Dim codValue = cboCosto.SelectedValue


                If IsNumeric(codValue) Then
                    codValue = Val(codValue)
                    txtTipoCosto.Text = costoSA.GetCostoById(New recursoCosto With {.idCosto = codValue}).subtipo

                    cboElementoCosto.Visible = True

                    cboElementoCosto.DisplayMember = "nombreCosto"
                    cboElementoCosto.ValueMember = "idCosto"
                    cboElementoCosto.DataSource = recursoSA.GetElementosCostoByCosto(New recursoCosto With {.idCosto = codValue})

                    ComboProcesos1(codValue)

                End If
            End If
        End If
        cboElementoCosto.SelectedIndex = -1
        cboproceso2.SelectedIndex = -1

        'Dim recursoSA As New recursoCostoSA

        'cboElementoCosto.DataSource = Nothing
        'cboproceso2.DataSource = Nothing

        'If Not IsNothing(cboCosto.SelectedValue) Then
        '    Dim codValue = cboCosto.SelectedValue.ToString
        '    codValue = Val(codValue)

        '    If IsNumeric(codValue) Then
        '        Select Case txtTipoCosto.Text
        '            Case TipoCosto.Proyecto, TipoCosto.OrdenProduccion, TipoCosto.ActivoFijo
        '                cboElementoCosto.Visible = True

        '                cboElementoCosto.DisplayMember = "nombreCosto"
        '                cboElementoCosto.ValueMember = "idCosto"
        '                cboElementoCosto.DataSource = recursoSA.GetElementosCostoByCosto(New recursoCosto With {.idCosto = codValue})

        '                ComboProcesos2(codValue)
        '            Case Else
        '                cboElementoCosto.Visible = False
        '        End Select
        '    End If
        'End If


        'cboproceso2.SelectedIndex = -1
        'cboElementoCosto.SelectedIndex = -1
    End Sub

    Private Sub Panel30_Click(sender As Object, e As EventArgs) Handles Panel30.Click
      
    End Sub

    Private Sub Panel30_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel30.MouseClick
  
    End Sub

    Private Sub Panel30_Paint(sender As Object, e As PaintEventArgs) Handles Panel30.Paint
      
    End Sub

    Private Sub Panel31_Click(sender As Object, e As EventArgs) Handles Panel31.Click
        Me.Cursor = Cursors.WaitCursor
        TabCuentasFinancieras.Parent = TabControlAdv3
        TabCuentasporCobrar.Parent = Nothing
        TabCuentasporPagar.Parent = Nothing
        TabExistenciaInicio.Parent = Nothing
        PanelFinanzas.Visible = False
        ObtenerEF()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel31_Paint(sender As Object, e As PaintEventArgs) Handles Panel31.Paint

    End Sub

    Private Sub Panel32_Click(sender As Object, e As EventArgs) Handles Panel32.Click
        Me.Cursor = Cursors.WaitCursor
        TabCuentasFinancieras.Parent = TabControlAdv3
        TabCuentasporCobrar.Parent = Nothing
        TabCuentasporPagar.Parent = Nothing
        TabExistenciaInicio.Parent = Nothing
        PanelFinanzas.Visible = False
        ObtenerEF()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel32_Paint(sender As Object, e As PaintEventArgs) Handles Panel32.Paint

    End Sub

    Private Sub Panel33_Click(sender As Object, e As EventArgs) Handles Panel33.Click
        Me.Cursor = Cursors.WaitCursor
        PanelFinanzas.Visible = False
        TabCuentasFinancieras.Parent = TabControlAdv3
        TabCuentasporCobrar.Parent = Nothing
        TabCuentasporPagar.Parent = Nothing
        TabExistenciaInicio.Parent = Nothing
        ObtenerEF()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel33_Paint(sender As Object, e As PaintEventArgs) Handles Panel33.Paint

    End Sub

    Private Sub Panel34_Click(sender As Object, e As EventArgs) Handles Panel34.Click
        Me.Cursor = Cursors.WaitCursor
        PanelFinanzas.Visible = False
        TabCuentasFinancieras.Parent = Nothing
        TabCuentasporCobrar.Parent = Nothing
        TabExistenciaInicio.Parent = Nothing
        TabCuentasporPagar.Parent = TabControlAdv3
        GetPagos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel35_Click(sender As Object, e As EventArgs) Handles Panel35.Click
        Me.Cursor = Cursors.WaitCursor
        PanelFinanzas.Visible = False
        TabCuentasFinancieras.Parent = Nothing
        TabCuentasporCobrar.Parent = TabControlAdv3
        TabCuentasporPagar.Parent = Nothing
        TabExistenciaInicio.Parent = Nothing
        GetCobros()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel37_Click(sender As Object, e As EventArgs) Handles Panel37.Click
        PanelFinanzas.Visible = True
    End Sub

    Private Sub Panel36_Click(sender As Object, e As EventArgs) Handles Panel36.Click
        Me.Cursor = Cursors.WaitCursor
        PanelFinanzas.Visible = False
        TabCuentasFinancieras.Parent = Nothing
        TabCuentasporCobrar.Parent = Nothing
        TabCuentasporPagar.Parent = Nothing
        TabExistenciaInicio.Parent = TabControlAdv3
        GetExistenciasInicio()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RadioButtonAdv2_CheckChanged(sender As Object, e As EventArgs) Handles rbHojaCosto.CheckChanged
        If rbHojaCosto.Checked = True Then
            Label29.Text = "Asignar recursos (Elmento del costo)"
            cboElemento.Visible = True
            GetItemsCosto("HC")
            cboIdentCosto_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub rbHojaGasto_CheckChanged(sender As Object, e As EventArgs) Handles rbHojaGasto.CheckChanged
        If rbHojaGasto.Checked = True Then
            Label29.Text = "Asignar recursos"
            cboElemento.Visible = False
            GetItemsCosto("HG")
            cboIdentCosto_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub cboIdentCosto_Click(sender As Object, e As EventArgs) Handles cboIdentCosto.Click

    End Sub

    Private Sub cboIdentCosto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIdentCosto.SelectedIndexChanged
        cboCostoDestino.DataSource = Nothing
        '  cboCostoDestino.SelectedIndex = -1

        'If cboCostoDestino.SelectedIndex > -1 Then
        Dim codValue = cboIdentCosto.Text.ToString

        Select Case codValue
            Case "PROYECTO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
            Case "ORDEN DE PRODUCCION"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OrdenProduccion})
            Case "ACTIVO FIJO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})
            Case "GASTO ADMINISTRATIVO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
            Case "GASTO DE VENTAS"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
            Case "GASTO FINANCIERO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})
        End Select
        cboCostoDestino.SelectedIndex = -1
        'End If

    End Sub

    Private Sub cboCostoDestino_Click(sender As Object, e As EventArgs) Handles cboCostoDestino.Click

    End Sub

    Private Sub cboCostoDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCostoDestino.SelectedIndexChanged
        cboElemento.DataSource = Nothing
        cboProceso.DataSource = Nothing
        If cboCostoDestino.SelectedIndex > -1 Then
            If rbHojaCosto.Checked = True Then
                Dim recursoSA As New recursoCostoSA

                Dim codValue = cboCostoDestino.SelectedValue
                codValue = Val(codValue)

                If IsNumeric(codValue) Then
                    Select Case cboIdentCosto.SelectedValue
                        Case TipoCosto.Proyecto, TipoCosto.OrdenProduccion, TipoCosto.ActivoFijo
                            cboElemento.Visible = True

                            cboElemento.DisplayMember = "nombreCosto"
                            cboElemento.ValueMember = "idCosto"
                            cboElemento.DataSource = recursoSA.GetElementosCostoByCosto(New recursoCosto With {.idCosto = codValue})

                            ComboProcesos(codValue)
                        Case Else
                            cboElemento.Visible = False
                    End Select
                End If
            End If
        End If
        cboElemento.SelectedIndex = -1
        cboProceso.SelectedIndex = -1
    End Sub
#Region "Metodos costo"
    Function ValidaNotaByReferencia(intIdDocumentoPadre As Integer) As documentocompradetalle
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim compra As New documentocompradetalle
        compra = compraSA.GetUbicar_documentocompradetallePorID(intIdDocumentoPadre)

        Return compra
    End Function

    Public Sub RegistrarItemsAsignados()
        Dim obj As New recursoCostoDetalle
        Dim Lista As New List(Of recursoCostoDetalle)
        Dim costoSA As New recursoCostoDetalleSA
        Dim codigoCosto As Integer
        Dim listaAsiento As New List(Of asiento)
        Dim objAsiento As New asiento
        Dim objMovimiento As New movimiento
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim objDetalleCompra As New documentocompradetalle
        Try

            Lista = New List(Of recursoCostoDetalle)
            listaAsiento = New List(Of asiento)

            If rbHojaCosto.Checked = True Then
                codigoCosto = cboElemento.SelectedValue
            ElseIf rbHojaGasto.Checked = True Then
                codigoCosto = cboCostoDestino.SelectedValue
            End If


            For Each i As SelectedRecord In dgvItemsNoasignados.Table.SelectedRecords

                objDetalleCompra = New documentocompradetalle

                Select Case i.Record.GetValue("TipoDoc")
                    Case "07" 'NOTA DE CREDITO
                        objDetalleCompra = ValidaNotaByReferencia(dgvItemsNoasignados.Table.CurrentRecord.GetValue("idPadreDTCompra"))

                        If IsNothing(obj) Then
                            Throw New Exception("Debe asignar primero el comprobante padre!")
                        End If

                    Case Else

                End Select


                objAsiento = New asiento
                objAsiento.idEmpresa = Gempresas.IdEmpresaRuc
                objAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
                objAsiento.idDocumento = Val(i.Record.GetValue("idDocumento"))
                objAsiento.idDocumentoRef = Nothing
                objAsiento.idAlmacen = 0
                objAsiento.nombreAlmacen = String.Empty
                objAsiento.idEntidad = String.Empty
                objAsiento.nombreEntidad = String.Empty
                objAsiento.tipoEntidad = String.Empty
                objAsiento.fechaProceso = DateTime.Now
                objAsiento.codigoLibro = "8"
                objAsiento.tipo = "D"
                objAsiento.tipoAsiento = "ACCA"
                objAsiento.importeMN = CDec(i.Record.GetValue("montokardex"))
                objAsiento.importeME = CDec(i.Record.GetValue("montokardexUS"))


                objAsiento.glosa = "Ingreso a centro de costo"
                objAsiento.usuarioActualizacion = usuario.IDUsuario
                objAsiento.fechaActualizacion = DateTime.Now


                Select Case cboIdentCosto.SelectedValue
                    Case TipoCosto.Proyecto
                        recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = cboElemento.SelectedValue})

                        Select Case i.Record.GetValue("TipoDoc")
                            Case "07" 'NOTA DE CREDITO

                                objMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    .tipo = "D",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                  .cuenta = recurso.codigo,
                                  .descripcion = recurso.nombreCosto,
                                  .tipo = "H",
                                  .monto = CDec(i.Record.GetValue("montokardex")),
                                  .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                  .usuarioActualizacion = usuario.IDUsuario,
                                  .fechaActualizacion = DateTime.Now
                              }
                                objAsiento.movimiento.Add(objMovimiento)


                            Case Else

                                objMovimiento = New movimiento With {
                                    .cuenta = recurso.codigo,
                                    .descripcion = recurso.nombreCosto,
                                    .tipo = "D",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    .tipo = "H",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                        End Select
                        listaAsiento.Add(objAsiento)

                    Case TipoCosto.OrdenProduccion

                        Select Case i.Record.GetValue("TipoDoc")
                            Case "07" 'NOTA DE CREDITO

                                objMovimiento = New movimiento With {
                                  .cuenta = "7111",
                                  .descripcion = "PRODUCTOS MANUFACTURADOS",
                                  .tipo = "D",
                                  .monto = CDec(i.Record.GetValue("montokardex")),
                                  .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                  .usuarioActualizacion = usuario.IDUsuario,
                                  .fechaActualizacion = DateTime.Now
                              }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                   .cuenta = "231",
                                   .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                   .tipo = "H",
                                   .monto = CDec(i.Record.GetValue("montokardex")),
                                   .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                   .usuarioActualizacion = usuario.IDUsuario,
                                   .fechaActualizacion = DateTime.Now
                               }
                                objAsiento.movimiento.Add(objMovimiento)



                            Case Else

                                objMovimiento = New movimiento With {
                                    .cuenta = "231",
                                    .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
                                    .tipo = "D",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                    .cuenta = "7111",
                                    .descripcion = "PRODUCTOS MANUFACTURADOS",
                                    .tipo = "H",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                        End Select

                        listaAsiento.Add(objAsiento)

                    Case TipoCosto.ActivoFijo
                        recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = cboElemento.SelectedValue})
                        Select Case i.Record.GetValue("TipoDoc")
                            Case "07" 'NOTA DE CREDITO

                                objMovimiento = New movimiento With {
                                    .cuenta = "7225",
                                    .descripcion = "EQUIPOS DIVERSOS",
                                    .tipo = "D",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                    .cuenta = recurso.codigo,
                                    .descripcion = recurso.nombreCosto,
                                    .tipo = "H",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)


                            Case Else

                                objMovimiento = New movimiento With {
                                    .cuenta = recurso.codigo,
                                    .descripcion = recurso.nombreCosto,
                                    .tipo = "D",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                    .cuenta = "7225",
                                    .descripcion = "EQUIPOS DIVERSOS",
                                    .tipo = "H",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                        End Select

                        listaAsiento.Add(objAsiento)

                    Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero
                        recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = cboCostoDestino.SelectedValue})


                        Select Case i.Record.GetValue("TipoDoc")
                            Case "07" 'NOTA DE CREDITO
                                objMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    .tipo = "D",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)


                                objMovimiento = New movimiento With {
                                    .cuenta = recurso.codigo,
                                    .descripcion = recurso.nombreCosto,
                                    .tipo = "H",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                            Case Else

                                objMovimiento = New movimiento With {
                                    .cuenta = recurso.codigo,
                                    .descripcion = recurso.nombreCosto,
                                    .tipo = "D",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)

                                objMovimiento = New movimiento With {
                                    .cuenta = "791",
                                    .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
                                    .tipo = "H",
                                    .monto = CDec(i.Record.GetValue("montokardex")),
                                    .montoUSD = CDec(i.Record.GetValue("montokardexUS")),
                                    .usuarioActualizacion = usuario.IDUsuario,
                                    .fechaActualizacion = DateTime.Now
                                }
                                objAsiento.movimiento.Add(objMovimiento)
                        End Select



                        listaAsiento.Add(objAsiento)
                End Select



                Select Case i.Record.GetValue("TipoDoc")
                    Case "07" 'NOTA DE CREDITO
                        obj = New recursoCostoDetalle With {
                            .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                            .idCosto = codigoCosto,
                            .iditem = Val(i.Record.GetValue("idItem")),
                            .destino = i.Record.GetValue("destino"),
                            .descripcion = i.Record.GetValue("descripcionItem"),
                            .um = i.Record.GetValue("unidad1"),
                            .cant = CDec(i.Record.GetValue("monto1")),
                            .puMN = 0,
                            .puME = 0,
                            .montoMN = CDec(i.Record.GetValue("montokardex")) * -1,
                            .montoME = CDec(i.Record.GetValue("montokardexUS")) * -1,
                            .documentoRef = i.Record.GetValue("idDocumento"),
                            .itemRef = i.Record.GetValue("secuencia"),
                            .operacion = i.Record.GetValue("TipoOperacion"),
                            .idProceso = cboProceso.SelectedValue,
                            .procesado = "N",
                            .recursoCosto = New recursoCosto With
                                            {
                                                .subtipo = cboIdentCosto.Text
                                            }
                        }
                        Lista.Add(obj)

                    Case Else


                        obj = New recursoCostoDetalle With {
                            .idCosto = codigoCosto,
                            .fechaRegistro = CDate(i.Record.GetValue("FechaDoc")),
                            .iditem = Val(i.Record.GetValue("idItem")),
                            .destino = i.Record.GetValue("destino"),
                            .descripcion = i.Record.GetValue("descripcionItem"),
                            .um = i.Record.GetValue("unidad1"),
                            .cant = CDec(i.Record.GetValue("monto1")),
                            .puMN = 0,
                            .puME = 0,
                            .montoMN = CDec(i.Record.GetValue("montokardex")),
                            .montoME = CDec(i.Record.GetValue("montokardexUS")),
                            .documentoRef = i.Record.GetValue("idDocumento"),
                            .itemRef = i.Record.GetValue("secuencia"),
                            .operacion = i.Record.GetValue("TipoOperacion"),
                            .procesado = "N",
                            .idProceso = cboProceso.SelectedValue,
                        .recursoCosto = New recursoCosto With
                                        {
                        .subtipo = cboIdentCosto.Text
                                        }
                        }
                        Lista.Add(obj)
                End Select
            Next
            costoSA.GrabarDetalleRecursos(Lista, listaAsiento)
            GetItemsNoAsignados()
            MessageBoxAdv.Show("Recursos asignados")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Sub ComboProcesos(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA

        cboProceso.DataSource = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdCostoPadre})
        cboProceso.ValueMember = "idCosto"
        cboProceso.DisplayMember = "nombreCosto"
    End Sub

    Sub ComboProcesos2(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA

        cboproceso2.DataSource = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdCostoPadre})
        cboproceso2.ValueMember = "idCosto"
        cboproceso2.DisplayMember = "nombreCosto"
    End Sub


    Public Sub GetItemsNoAsignados()
        Dim compraSA As New DocumentoCompraSA
        'Dim dt As New DataTable
        'dt.Columns.Add("idDocumento")
        'dt.Columns.Add("secuencia")
        'dt.Columns.Add("FechaDoc")
        'dt.Columns.Add("TipoDoc")
        'dt.Columns.Add("Serie")
        'dt.Columns.Add("NumDoc")
        'dt.Columns.Add("Moneda")
        'dt.Columns.Add("idItem")
        'dt.Columns.Add("descripcionItem")
        'dt.Columns.Add("tipoExistencia")
        'dt.Columns.Add("destino")
        'dt.Columns.Add("unidad1")
        'dt.Columns.Add("monto1")
        'dt.Columns.Add("montokardex")
        'dt.Columns.Add("montokardexUS")

        'dt.Columns.Add("TipoOperacion")
        'dt.Columns.Add("idPadreDTCompra")
        'dt.Columns.Add("proceso")

        'For Each i In compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                            .fechaContable = PeriodoGeneral})

        '    Dim dr As DataRow = dt.NewRow
        '    dr(0) = i.idDocumento
        '    dr(1) = i.secuencia
        '    dr(2) = i.FechaDoc
        '    dr(3) = i.TipoDoc
        '    dr(4) = i.Serie
        '    dr(5) = i.NumDoc
        '    dr(6) = i.Moneda
        '    dr(7) = i.idItem
        '    dr(8) = i.descripcionItem
        '    dr(9) = i.tipoExistencia
        '    dr(10) = i.destino
        '    dr(11) = i.unidad1
        '    dr(12) = i.monto1
        '    dr(13) = i.montokardex
        '    dr(14) = i.montokardexUS
        '    dr(15) = i.TipoOperacion
        '    dr(16) = i.idPadreDTCompra
        '    dr(17) = String.Empty
        '    dt.Rows.Add(dr)
        'Next

        dgvItemsNoasignados.DataSource = compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                .fechaContable = PeriodoGeneral})
        dgvItemsNoasignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub

    Public Sub GetCountItemsNoAsignados()
        Dim compraSA As New DocumentoCompraDetalleSA

        Dim compra = compraSA.GetCountItemsNoAsignados(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                .fechaContable = PeriodoGeneral})
        '   lblCenter = New Label
        lblCenter.Text = compra
        lblCenter.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblCenter.AutoSize = False
        lblCenter.BackColor = Color.Transparent
        lblCenter.Dock = DockStyle.Fill
        lblCenter.ForeColor = Color.Yellow
        lblCenter.TextAlign = ContentAlignment.MiddleLeft

    End Sub
#End Region
    Private Sub ButtonAdv11_Click(sender As Object, e As EventArgs) Handles ButtonAdv11.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvItemsNoasignados.Table.Records.Count > 0 Then
            If dgvItemsNoasignados.Table.SelectedRecords.Count > 0 Then

                If cboCostoDestino.Text.Trim.Length > 0 Then
                    If cboProceso.Text.Trim.Length > 0 Then
                        RegistrarItemsAsignados()
                        GetCountItemsNoAsignados()
                    Else
                        MessageBox.Show("Debe seleccionar el proceso de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe seleccionar el destino de los items", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvItemsNoasignados) Then
            Select Case dgvItemsNoasignados.Table.CurrentRecord.GetValue("TipoDoc")
                Case "07", "08"
                    Dim f As New frmInfoCosto(Val(dgvItemsNoasignados.Table.CurrentRecord.GetValue("idPadreDTCompra")))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case Else

            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
    End Sub

    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New List(Of documentoCaja)
        Dim efsa As New EstadosFinancierosSA
        Dim dt As New DataTable
        dt.Columns.Add("tipooperacion")
        dt.Columns.Add("movimiento")
        dt.Columns.Add("total")


        caja = cajaSA.GetFlujoEfectivo()
        For Each i In caja
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.tipoOperacion
            dr(1) = If(i.tipoMovimiento = "PG", "Pagos", "Cobros")
            dr(2) = i.montoSoles
            dt.Rows.Add(dr)
        Next
        DgvFlujoEfectivo.DataSource = dt

        Dim obj = efsa.GetEstadoCajasTodos()
        lblTotalCajas.Text = CDec(obj.importeBalanceMN).ToString("N2")
        lblTotalEntradas.Text = caja.Where(Function(o) o.tipoMovimiento = "DC").Sum(Function(o) o.montoSoles).GetValueOrDefault
        lblTotalSalida.Text = caja.Where(Function(o) o.tipoMovimiento = "PG").Sum(Function(o) o.montoSoles).GetValueOrDefault


        'DETALLE DE AJAS
        Dim dtCajas As New DataTable()
        dtCajas.Columns.Add("ef")
        dtCajas.Columns.Add("moneda")
        dtCajas.Columns.Add("tipo")
        dtCajas.Columns.Add("ingreso")
        dtCajas.Columns.Add("salida")
        dtCajas.Columns.Add("saldo")

        For Each i In efsa.GetEstadoCajasTodosDetalle()
            Dim dr As DataRow = dtCajas.NewRow
            dr(0) = i.descripcion
            dr(1) = i.codigo
            Select Case i.tipo
                Case CuentaFinanciera.Banco
                    dr(2) = "Banco"
                Case CuentaFinanciera.Efectivo
                    dr(2) = "Efectivo"
                Case CuentaFinanciera.Tarjeta_Credito
                    dr(2) = "Tarj. crédito"
                Case CuentaFinanciera.Tarjeta_Debito
                    dr(2) = "Tarj. Débito"
            End Select

            dr(3) = i.Ingresos.GetValueOrDefault
            dr(4) = i.Salidas.GetValueOrDefault
            dr(5) = i.SaldoCaja.GetValueOrDefault
            dtCajas.Rows.Add(dr)
        Next
        dgvDetalleCajas.DataSource = dtCajas
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmSituacionFinanciera1
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmEstadoDeResultados
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click

    End Sub

    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmEstadoFlujoEfectivo
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvItemsNoasignados_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvItemsNoasignados.SelectedRecordsChanged

    End Sub

    Private Sub dgvItemsNoasignados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvItemsNoasignados.TableControlCellClick

    End Sub

    Private Sub bgGeneral_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgGeneral.DoWork
        Dim tablaSA As New tablaDetalleSA
        LoadCombos()
        getAlertasInventario()
        getConteoVentasObservadas()


        ListadoOperaciones = tablaSA.GetListaTablaDetalle(12, "1")
    End Sub

    Private Sub bgGeneral_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgGeneral.RunWorkerCompleted
        GetCountItemsNoAsignados()
        GridCFGFinanzas(dgvEntidadFinanciera)
        GridCFG(dgvCompra)
        GridCFG(dgvAlerta)
        GridCFG(dgvAlertaVentas)
        GridCFG(dgvItemsNoasignados)
        GridCFG(dgvAsientosventa)
        GridCFG2(dgvMovimientos)
        GridCFG(dgvCuentaApertura)
        GridCFG(dgvCobros)
        GridCFG(dgvpagos)
        GridCFG(GridGroupingControl3)

        rbHojaGasto.Checked = True

        feed.Hide()
    End Sub

    Private Sub frmMaestroAsientoContables_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        feed.StartPosition = FormStartPosition.CenterScreen
        feed.TopMost = True
        feed.Show()
        bgGeneral.RunWorkerAsync()
    End Sub

    Private Sub AsientoManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsientoManualToolStripMenuItem.Click
        Dim cierreSA As New empresaCierreMensualSA
        If TabContol.SelectedTab Is TabRegistroAsientos Then

            Dim fechaAnt = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If cboMesCompra.Text.Trim.Length > 0 Then
                With frmGastoXModulos
                    .txtPeriodo.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    .txtFecha.Value = New DateTime(AnioGeneral, Integer.Parse(cboMesCompra.SelectedValue), 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe seleccionar un período válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un período válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        '   ListadoLibroAsiento("AS-M")
        'ListadoLibroAsiento("NM")

        ListadoItems()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        Dim r As Record = dgvCompra.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmCambiarPeriodo2(New documentoLibroDiario With {.idDocumento = Val(r.GetValue("idDocumento"))})
            f.operacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            ButtonAdv19_Click(sender, e)
        End If
    End Sub

    Private Sub ButtonAdv12_Click(sender As Object, e As EventArgs) Handles ButtonAdv12.Click
        Dim cierreSA As New empresaCierreMensualSA
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then

            Dim fechaAnt = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            With frmGastoXModulos
                .txtPeriodo.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                .UbicarDocumento(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                .lblIdDocumento.Text = dgvCompra.Table.CurrentRecord.GetValue("idDocumento")


                If dgvCompra.Table.CurrentRecord.GetValue("identificacion") = "S" Then
                    .txtProveedor.Tag = dgvCompra.Table.CurrentRecord.GetValue("idBene")
                    .txtProveedor.Text = dgvCompra.Table.CurrentRecord.GetValue("beneficiario")
                    .CheckBox2.Checked = True
                End If

                .cboMoneda.ReadOnly = True
                .txtFecha.ReadOnly = True
                .ComboBoxAdv2.ReadOnly = True
                .txtPeriodo.ReadOnly = True
                .txtGlosa.ReadOnly = True
                .txtProveedor.ReadOnly = True
                .txtRuc.ReadOnly = True
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub ButtonAdv13_Click(sender As Object, e As EventArgs) Handles ButtonAdv13.Click
        Dim cierreSA As New empresaCierreMensualSA

        Me.Cursor = Cursors.WaitCursor
        Dim fechaAnt = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
            EliminarGastoModulo(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
            dgvCompra.Table.CurrentRecord.Delete()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvMovimientos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMovimientos.TableControlCellClick

    End Sub

    Private Sub Panel34_Paint(sender As Object, e As PaintEventArgs) Handles Panel34.Paint

    End Sub
End Class