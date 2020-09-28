Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Tools
Public Class frminfocierreProduccion
    Inherits frmMaster
    Public Property GConfiguracion As New GConfiguracionModulo

    Public Sub New(intIdCosto As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GConfiguracion = New GConfiguracionModulo
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "AST", Me.Text, GEstableciento.IdEstablecimiento)
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvProductosTerminados)
        UbicarByIdCosto(intIdCosto)
        Almacenes(intIdCosto)
        GetSumaTotalElmentos(New recursoCosto With {.idCosto = intIdCosto})
        txtSerie.Enabled = True
        txtSerie.ReadOnly = False
        txtNumero.Enabled = True
        txtNumero.ReadOnly = False
    End Sub

#Region "Metodos"

    Sub GridCFG(grid As GridGroupingControl)
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

    Private Sub Almacenes(intIdCosto As Integer)
        Dim recursoCostoSA As New recursoCostoSA
        Dim itemSA As New detalleitemsSA
        Dim item As New detalleitems
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable()



        Dim almacenSA As New almacenSA
        Dim almacen As New List(Of almacen)

        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        CBOalmacenDestino.DataSource = almacen
        CBOalmacenDestino.DisplayMember = "descripcionAlmacen"
        CBOalmacenDestino.ValueMember = "idAlmacen"
        CBOalmacenDestino.Enabled = True

        cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(10, "1")
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.SelectedValue = "99"

        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        Dim ggcStyle As GridTableCellStyleInfo = dgvProductosTerminados.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = almacen
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvProductosTerminados.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvProductosTerminados.ShowRowHeaders = False

        '-----------------------------------------------------------------------------------------------

        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("pu")
        dt.Columns.Add("costo")
        dt.Columns.Add("cantCierre")
        dt.Columns.Add("puCierre")
        dt.Columns.Add("costoCierre")
        dt.Columns.Add("almacen")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idCosto")

        For Each i In recursoCostoSA.GetProductosTerminadosByCosto(New recursoCosto With {.idCosto = intIdCosto})

            item = itemSA.InvocarProductoID(Val(i.codigo))

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.codigo
            If Not IsNothing(item) Then
                dr(1) = item.descripcionItem
                dr(2) = item.tipoExistencia
                dr(3) = item.unidad1
                dr(11) = item.origenProducto
            Else
                dr(1) = i.detalle
                dr(2) = "Gasto/Servicio"
                dr(3) = "UND"
                dr(11) = String.Empty
            End If

            
            dr(4) = i.cantidad
            dr(5) = i.precUnit
            dr(6) = i.costo
            dr(7) = i.cantidad
            dr(8) = i.precUnit
            dr(9) = i.costo
            dr(10) = i.almacen

            dr(12) = i.idCosto
            dt.Rows.Add(dr)
        Next
        dgvProductosTerminados.DataSource = dt

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
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
    '                    End With
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
    '        '    lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
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

    Public Sub UbicarByIdCosto(intidCosto As Integer)
        Dim costoSA As New recursoCostoDetalleSA
        Dim costo As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        With recursoSA.GetCostoById(New recursoCosto With {.idCosto = intidCosto})
            Select Case .subtipo

                Case TipoCosto.Proyecto

                Case TipoCosto.CONTRATOS_DE_CONSTRUCCION
                    txtTipoCosto.Text = "CONTRATOS DE CONSTRUCCION"
                Case TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
                    txtTipoCosto.Text = "CONTRATOS DE ARRENDAMIENTOS"
                Case TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES
                    txtTipoCosto.Text = "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES"


                Case TipoCosto.OrdenProduccion
                    txtTipoCosto.Text = ""
                Case TipoCosto.OP_CONTINUA_DE_BIENES
                    txtTipoCosto.Text = "OP. CONTINUA DE BIENES"
                Case TipoCosto.OP_CONTINUA_DE_SERVICIOS
                    txtTipoCosto.Text = "OP. CONTINUA DE SERVICIOS"
                Case TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE
                    txtTipoCosto.Text = "OP. DE BIENES - CONTROL INDEPENDIENTE"
                Case TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES
                    txtTipoCosto.Text = "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES"
                Case TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE
                    txtTipoCosto.Text = "OP. DE SERVICIOS - CONTROL INDEPENDIENTE"

                    'Case TipoCosto.Proyecto
                    '    txtTipoCosto.Text = "OBRAS DE CONTRUCCION"
                    'Case TipoCosto.OrdenProduccion
                    '    txtTipoCosto.Text = "ORDEN DE PRODUCCION"
                Case TipoCosto.ActivoFijo
                    txtTipoCosto.Text = "ACTIVOS FIJOS"

                Case TipoCosto.GastoAdministrativo
                    txtTipoCosto.Text = "GASTO ADMINISTRATIVO"
                Case TipoCosto.GastoVentas
                    txtTipoCosto.Text = "GASTO DE VENTAS"
                Case TipoCosto.GastoFinanciero
                    txtTipoCosto.Text = "GASTO FINANCIERO"
            End Select

            txtNomCosto.Text = .nombreCosto
            txtNomCosto.Tag = .idCosto
        End With

        costo = costoSA.GetSumaTotalImportesByCosto(New recursoCosto With {.idCosto = intidCosto})
        txtImporteMN.Text = costo.TotalMN
        txtImporteME.Text = costo.TotalME

    End Sub

    Public Sub GetSumaTotalElmentos(be As recursoCosto)
        Dim recursoSA As New recursoCostoDetalleSA
        lsvElemento.Items.Clear()

        For Each i As recursoCostoDetalle In recursoSA.GetSumaTotalElementoCosto(be)
            Dim n As New ListViewItem(i.descripcion)
            n.SubItems.Add(i.montoMN)
            n.SubItems.Add(i.montoME)
            n.SubItems.Add(i.operacion)
            lsvElemento.Items.Add(n)
        Next

    End Sub
#End Region

    Private Sub frminfocierreProduccion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frminfocierreProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim documento As New documento
        Dim nDocumentoCompra As New documentocompra
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim costoSA As New recursoCostoSA
        Dim listAsiento As New List(Of asiento)

        Dim recursocosto As New recursoCosto
        recursocosto.idCosto = txtNomCosto.Tag
        recursocosto.status = StatusCosto.Culminado

        listAsiento = New List(Of asiento)

        documento = New documento
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = DateTime.Now
        documento.nroDoc = "1"
        documento.tipoOperacion = "9906"
        documento.idOrden = Nothing
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now

        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = "OPCN"
        documentoLibroDiario.fecha = DateTime.Now
        documentoLibroDiario.fechaPeriodo = PeriodoGeneral

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        documentoLibroDiario.tipoRazonSocial = "PR"
        documentoLibroDiario.razonSocial = Nothing
        documentoLibroDiario.infoReferencial = "Asientos Manuales"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = "9906"
        documentoLibroDiario.moneda = "1"
        documentoLibroDiario.tipoCambio = 1
        documentoLibroDiario.importeMN = CDec(txtImporteMN.Text)
        documentoLibroDiario.importeME = CDec(txtImporteME.Text)
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = DateTime.Now

        documentoLibroDiario.tieneCosto = "S"
        documentoLibroDiario.idCosto = txtNomCosto.Tag
        documento.documentoLibroDiario = documentoLibroDiario

        'ASIENTOS CONTABLES
        nAsiento = New asiento With {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCostos = GEstableciento.IdEstablecimiento,
        .idDocumentoRef = Nothing,
        .idAlmacen = 0,
        .nombreAlmacen = String.Empty,
        .idEntidad = String.Empty,
        .nombreEntidad = String.Empty,
        .tipoEntidad = String.Empty,
        .fechaProceso = DateTime.Now,
        .codigoLibro = "5",
        .tipo = "D",
        .tipoAsiento = "OPCN",
        .importeMN = CDec(txtImporteMN.Text),
        .importeME = CDec(txtImporteME.Text),
        .glosa = "CIERRE DE ORDEN DE PRODUCCION",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now}

        nMovimiento = New movimiento
        nMovimiento.cuenta = "7111"
        nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(txtImporteMN.Text)
        nMovimiento.montoUSD = CDec(txtImporteME.Text)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "231"
        nMovimiento.descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA"
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(txtImporteMN.Text)
        nMovimiento.montoUSD = CDec(txtImporteME.Text)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)
        '-------------------------------------------------------------------------------
        For Each i As ListViewItem In lsvElemento.Items

            nMovimiento = New movimiento
            nMovimiento.cuenta = i.SubItems(3).Text
            nMovimiento.descripcion = i.SubItems(0).Text
            nMovimiento.tipo = "D"
            nMovimiento.monto = CDec(i.SubItems(1).Text)
            nMovimiento.montoUSD = CDec(i.SubItems(2).Text)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "791"
            nMovimiento.descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS"
            nMovimiento.tipo = "H"
            nMovimiento.monto = CDec(i.SubItems(1).Text)
            nMovimiento.montoUSD = CDec(i.SubItems(2).Text)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)
        Next

      
        '------------------------------------------------------------------------------------------
        '-------------- Otras entradas a almacén --------------------------------------------------

        With nDocumentoCompra
            .situacion = "9903"
            .codigoLibro = "13"
            .tipoDoc = cboTipoDoc.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = DateTime.Now
            .fechaContable = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .aprobado = "N"
            .idPersona = Nothing
            .nombreProveedor = Nothing
            .monedaDoc = "1"
            .tasaIgv = 0 ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = 1
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = "Ingreso de productos terminados"
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        documento.documentocompra = nDocumentoCompra


        Dim almacenSA As New almacenSA
        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0

        For Each r As Record In dgvProductosTerminados.Table.Records
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.idCosto = Val(r.GetValue("idCosto"))

            objDocumentoCompraDet.Serie = txtSerie.Text
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = cboTipoDoc.SelectedValue
            objDocumentoCompraDet.FlagModificaPrecioVenta = Nothing ' Me.dgvMov.Table.CurrentRecord.GetValue("valCheck")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            objDocumentoCompraDet.porcUtimenor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiMenor")
            objDocumentoCompraDet.porcUtimayor = 0 'Me.dgvMov.Table.CurrentRecord.GetValue("utiMayor")
            objDocumentoCompraDet.porcUtigranMayor = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("utiGranMayor")
            objDocumentoCompraDet.TipoOperacion = "9903"
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.FechaDoc = DateTime.Now
            objDocumentoCompraDet.CuentaProvedor = "4212"
            objDocumentoCompraDet.NombreProveedor = Nothing
            objDocumentoCompraDet.destino = r.GetValue("gravado")
            objDocumentoCompraDet.idItem = r.GetValue("idItem")
            objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoCompraDet.descripcionItem = r.GetValue("descripcion")
            objDocumentoCompraDet.unidad1 = r.GetValue("unidad")
            objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantCierre"))
            objDocumentoCompraDet.unidad2 = Nothing 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = Nothing ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("puCierre"))
            objDocumentoCompraDet.precioUnitarioUS = 0 ' CDec(r.GetValue("precME"))
            objDocumentoCompraDet.importe = CType(r.GetValue("costoCierre"), Decimal)
            objDocumentoCompraDet.importeUS = 0 ' CType(r.GetValue("importeME"), Decimal)

            sumaMN += CDec(r.GetValue("costoCierre"))
            sumaME += 0 ' CDec(r.GetValue("costoCierre"))
            objDocumentoCompraDet.FechaVcto = Nothing
            objDocumentoCompraDet.preEvento = Nothing
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.almacenRef = Val(r.GetValue("almacen"))
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.Glosa = "Ingreso de productos terminados"
            ListaDetalle.Add(objDocumentoCompraDet)


            '---------------------- Aisnto de los productos terminados ---------------------

            nMovimiento = New movimiento
            nMovimiento.cuenta = "211"
            nMovimiento.descripcion = r.GetValue("descripcion")
            nMovimiento.tipo = "D"
            nMovimiento.monto = CType(r.GetValue("costoCierre"), Decimal)
            nMovimiento.montoUSD = 0 'CDec(txtImporteME.Text)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "7111"
            nMovimiento.descripcion = r.GetValue("descripcion")
            nMovimiento.tipo = "H"
            nMovimiento.monto = CType(r.GetValue("costoCierre"), Decimal)
            nMovimiento.montoUSD = 0 'CDec(txtImporteME.Text)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            nAsiento.movimiento.Add(nMovimiento)

        Next

        listAsiento.Add(nAsiento)
        documento.asiento = listAsiento

        documento.documentocompra.importeTotal = sumaMN
        documento.documentocompra.importeUS = sumaME
        documento.documentocompra.documentocompradetalle = ListaDetalle


        '------------------------------------------------------------------------------------------

        costoSA.GetCulminarCostoProduccion(recursocosto, documento)
        MessageBox.Show("Costo cerrado correctamente!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dispose()
    End Sub

    Private Sub dgvProductosTerminados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvProductosTerminados.TableControlCellClick

    End Sub

    Private Sub dgvProductosTerminados_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvProductosTerminados.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvProductosTerminados_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvProductosTerminados.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvProductosTerminados.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 7 ' cantidad
                    Dim colCantidad As Decimal = Me.dgvProductosTerminados.Table.CurrentRecord.GetValue("cantCierre")
                    Dim colCosto As Decimal = Me.dgvProductosTerminados.Table.CurrentRecord.GetValue("costoCierre")
                    If colCantidad > 0 Then
                        Dim colPU As Decimal = colCosto / colCantidad
                        Me.dgvProductosTerminados.Table.CurrentRecord.SetValue("puCierre", colPU)
                    Else
                        Me.dgvProductosTerminados.Table.CurrentRecord.SetValue("costoCierre", 0)
                    End If
                Case 9, 10 'Valor de compra
                    Dim colCantidad As Decimal = Me.dgvProductosTerminados.Table.CurrentRecord.GetValue("cantCierre")
                    Dim colCosto As Decimal = Me.dgvProductosTerminados.Table.CurrentRecord.GetValue("costoCierre")
                    If colCantidad > 0 Then
                        Dim colPU As Decimal = colCosto / colCantidad
                        Me.dgvProductosTerminados.Table.CurrentRecord.SetValue("puCierre", colPU)
                    Else
                        Me.dgvProductosTerminados.Table.CurrentRecord.SetValue("costoCierre", 0)
                    End If


            End Select
        End If

    End Sub
End Class