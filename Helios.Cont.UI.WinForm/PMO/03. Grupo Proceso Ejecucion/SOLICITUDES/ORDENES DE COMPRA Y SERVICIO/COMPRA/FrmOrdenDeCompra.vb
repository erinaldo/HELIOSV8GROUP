Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class FrmOrdenDeCompra
    Inherits frmMaster

    Sub ControlsHide()

    End Sub


#Region "Manipulación Data"

    Private Sub UbicarDocumentos(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim docOtros As New DocumentoOtrosDatosSA
        Dim entidadSA As New entidadSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA


        With documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)

            With entidadSA.UbicarEntidadPorID(.idProveedor).First
                txtProveedor.Text = .nombreCompleto
                txtProveedor.ValueMember = .idEntidad
                txtRuc.Text = .nrodoc
                txtTelefono.Text = .telefono
                txtCorreo.Text = .email
            End With

            With docOtros.UbicarDocumentoOtros(intIdDocumento)
                txtFechaInicioPlazo.Value = .fechaInicio
                txtFechaFinPlazo.Value = .fechaFin
                txtFechaInicioGarantia.Value = .FechaIniGarantia
                txtFechaFinGarantia.Value = .FechaFinGarantia
                txtNotas.Text = .notas
                txtIndicaciones.Text = .indicaciones
                CboPago.Text = tablaDetalleSA.GetUbicarTablaID(501, .condicionPago).descripcion
                txtVcto.Text = .Vcto
                cboModalidad.Text = tablaDetalleSA.GetUbicarTablaID(1, .Modalidad).descripcion
                txtcto.Text = .ctaDeposito
                txtFinaciera.Text = .institucionFinanciera
                cboAlmacen.Text = almacenSA.GetUbicar_almacenPorID(.idAlmacen).descripcionAlmacen
            End With

            If (.monedaDoc = "1") Then
                cboMoneda.DisplayMember = "NACIONAL"
                cboMoneda.SelectedValue = CInt(1)

            ElseIf (.monedaDoc = "2") Then
                cboMoneda.DisplayMember = "EXTRANJERA"
                cboMoneda.SelectedValue = CInt(2)
            End If
            txtFechaComprobante.Value = .fechaDoc
        End With
        dgvCompra.Rows.Clear()
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(intIdDocumento)
            dgvCompra.Rows.Add(i.secuencia, "1", i.idItem, i.descripcionItem, "1", "1", i.unidad1, i.monto1, i.precioUnitario, i.precioUnitarioUS, i.importe, i.importeUS,
                                   i.montokardex, i.montoIsc, i.montoIgv, i.otrosTributos, i.montokardexUS, i.montoIscUS, i.montoIgvUS, i.otrosTributosUS, Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia, "1")
        Next
    End Sub




    Sub GrabarSolicitud()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim objDocOtros As New documentoOtrosDatos()
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim g As New ListViewGroup

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "00"
            .tipoDoc = TXTComprobante.ValueMember
            .fechaProceso = txtFechaComprobante.Value
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With
        With nDocumentoCompra
            .codigoLibro = "1"
            .serie = GConfiguracion.Serie
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .tipoDoc = "00"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tcDolLoc = txtTipoCambio.Value
            .monedaDoc = cboMoneda.SelectedValue
            .idProveedor = txtProveedor.ValueMember
            .nombreProveedor = txtProveedor.Text
            .tipoDoc = GConfiguracion.TipoComprobante
            .fechaContable = lblPerido.Text
            .nroRegimen = Nothing
            .importeTotal = lblTotalAdquisiones.Text 'MARTIN
            .importeUS = lblTotalUS.Text 'MARTIN
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.ORDEN_COMPRA  'MARTIN
            .estadoPago = "P"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra
        With objDocOtros
            .CentroCostos = CInt("1")
            .idAlmacen = cboAlmacen.SelectedValue
            .fechaInicio = txtFechaInicioPlazo.Value
            .fechaFin = txtFechaFinPlazo.Value
            .FechaIniGarantia = txtFechaInicioGarantia.Value
            .FechaFinGarantia = txtFechaFinGarantia.Value
            .notas = txtNotas.Text
            .indicaciones = txtIndicaciones.Text
            .condicionPago = CboPago.SelectedValue
            .Vcto = txtVcto.Text
            .Modalidad = cboModalidad.SelectedValue
            .ctaDeposito = txtcto.Text
            .institucionFinanciera = txtFinaciera.Text
            .estado = "P"
            .CentroCostos = cboAlmacen.SelectedValue
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ' ndocumento.documentocompra.documentoOtrosDatos = objDocOtros

        Dim S As Integer = 0
        For Each i As DataGridViewRow In dgvCompra.Rows
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.idItem = CDec(i.Cells(2).Value()) 'IDITEM
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(21).Value()
            objDocumentoCompraDet.unidad1 = i.Cells(6).Value()
            objDocumentoCompraDet.Action = i.Cells(20).Value()
            objDocumentoCompraDet.unidad2 = CDec(i.Cells(4).Value())
            objDocumentoCompraDet.monto2 = i.Cells(5).Value()


            If CDec(i.Cells(7).Value()) > 0 Then
                objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
            Else
                lblEstado.Text = "ingrese una cantidad mayor a cero"
                Exit Sub
            End If
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())

            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())
            objDocumentoCompraDet.montokardex = CDec(i.Cells(12).Value())
            objDocumentoCompraDet.montoIsc = CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(i.Cells(14).Value())
            objDocumentoCompraDet.otrosTributos = CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(i.Cells(16).Value())
            objDocumentoCompraDet.montoIscUS = CDec(i.Cells(17).Value())
            objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
            objDocumentoCompraDet.otrosTributosUS = CDec(i.Cells(19).Value())
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing
            ListaDetalle.Add(objDocumentoCompraDet)
        Next
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        ''CompraSA.GrabarOrdenes(ndocumento)

    End Sub


#End Region

#Region "Variables DetalleCompra"
    Public Property nudBase4 As Decimal = 0
    Public Property nudBase1 As Decimal = 0
    Public Property nudBase2 As Decimal = 0
    Public Property nudBase3 As Decimal = 0

    Public Property nudMontoIgv1 As Decimal = 0
    Public Property nudMontoIgv2 As Decimal = 0
    Public Property nudMontoIgv3 As Decimal = 0

    Public Property nudBaseus4 As Decimal = 0
    Public Property nudBaseus1 As Decimal = 0
    Public Property nudBaseus2 As Decimal = 0
    Public Property nudBaseus3 As Decimal = 0

    Public Property nudMontoIgvus1 As Decimal = 0
    Public Property nudMontoIgvus2 As Decimal = 0
    Public Property nudMontoIgvus3 As Decimal = 0

    Public Property nudIsc1 As Decimal = 0
    Public Property nudIsc2 As Decimal = 0
    Public Property nudIsc3 As Decimal = 0
    Public Property nudIscus1 As Decimal = 0
    Public Property nudIscus2 As Decimal = 0
    Public Property nudIscus3 As Decimal = 0

    Public Property nudOtrosTributosus1 As Decimal = 0
    Public Property nudOtrosTributosus2 As Decimal = 0
    Public Property nudOtrosTributosus3 As Decimal = 0
    Public Property nudOtrosTributosus4 As Decimal = 0

    Public Property nudOtrosTributos1 As Decimal = 0
    Public Property nudOtrosTributos2 As Decimal = 0
    Public Property nudOtrosTributos3 As Decimal = 0
    Public Property nudOtrosTributos4 As Decimal = 0

    Public Property txtIdComprobanteCaja As Integer
    Public Property txtComprobanteCaja As String
    Public Property txtNumCaja As String
    Public Property txtIdEstablecimientoCaja As Integer
    Public Property txtEstablecimientoCaja As String
    Public Property txtIdCaja As Integer
    Public Property txtCaja As String
    Public Property txtCuentaEF As String

    '   Public Property GlosaCompra As String = Nothing
#End Region

    Public Property Flag() As String
    Dim UserControl1 As New ucConfiguracion
    Dim toolTip As Popup
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public fecha As DateTime

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        SelecIDEstable = Nothing
        SelecNombreEstable = Nothing
        SelectIdAlmacen = Nothing
        SelectNombreAlmacen = Nothing
        IdAlmacenBack = Nothing

        GConfiguracion = New GConfiguracionModulo

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OC", Me.Text, GEstableciento.IdEstablecimiento)
        ObtenerListaControlesLoad()
        CargarCMBGastos()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName

        Me.dockingManager1.DockControl(Me.Panel2, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(Panel2, "Existencias")
        
        'INICIO PERIODO
        lblPerido.Text = PeriodoGeneral
        ControlsHide()
        txtFechaComprobante.Select()
    End Sub

#Region "Métodos"
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

    Sub CALCULO_TRIBUTOS()





    End Sub

    'Private Sub ListadoProductosPorCategoria(strCategoria As String)
    '    Dim itemSA As New detalleitemsSA
    '    lsvListadoItems.Items.Clear()
    '    Try
    '        For Each i In itemSA.ListaProductosClasificados(GEstableciento.IdEstablecimiento, strCategoria)
    '            Dim n As New ListViewItem(i.codigodetalle)
    '            n.SubItems.Add(i.descripcionItem)
    '            n.SubItems.Add(i.unidad1)
    '            n.SubItems.Add(i.tipoExistencia)
    '            n.SubItems.Add(String.Empty)
    '            n.SubItems.Add(i.cuenta)
    '            lsvListadoItems.Items.Add(n)
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub ListadoProductosPorCategoriaTipoExistencia(strCategoria As Integer, strTipoExistencia As String)
        Dim itemSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        Try
            For Each i In itemSA.GetUbicarDetalleItemTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strCategoria, strTipoExistencia)
                Dim n As New ListViewItem(i.codigodetalle)
                n.SubItems.Add(i.descripcionItem)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.cuenta)
                lsvListadoItems.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ObtenerListaControlesLoad()
        'Dim personaSA As New PersonaSA
        'Dim tablaSA As New tablaDetalleSA
        'Dim categoriaSA As New itemSA

        'lsvProveedor.Items.Clear()
        'For Each i As Persona In personaSA.ObtenerPersona(Gempresas.IdEmpresaRuc)
        '    Dim n As New ListViewItem(i.idPersona)
        '    n.SubItems.Add(i.nombreCompleto)
        '    'n.SubItems.Add(i.cuentaAsiento)
        '    'n.SubItems.Add(i.nrodoc)
        '    lsvProveedor.Items.Add(n)
        'Next
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim categoriaSA As New itemSA
        Dim almacenSA As New almacenSA

        lsvProveedor.Items.Clear()
        For Each i As entidad In entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idEntidad)
            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.cuentaAsiento)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.telefono)
            n.SubItems.Add(i.email)
            lsvProveedor.Items.Add(n)
        Next


        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0



        CboMonedaPago.ValueMember = "id"
        CboMonedaPago.DisplayMember = "name"
        CboMonedaPago.DataSource = dt
        CboMonedaPago.SelectedIndex = 0

        ''COMPROBANTE TIPO DOCUMENTOS
        'cboTipoDoc.DisplayMember = "descripcion"
        'cboTipoDoc.ValueMember = "codigoDetalle"
        'cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(10, "1")

        'TIPO DE EXISTENCIA
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")


        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)


        cboModalidad.DisplayMember = "descripcion"
        cboModalidad.ValueMember = "codigoDetalle"
        cboModalidad.DataSource = tablaSA.GetListaTablaDetalle(1, "1")

        CboPago.DisplayMember = "descripcion"
        CboPago.ValueMember = "codigoDetalle"
        CboPago.DataSource = tablaSA.GetListaTablaDetalle(501, "1")




        lstCategoria.DisplayMember = "descripcion"
        lstCategoria.ValueMember = "idItem"
        lstCategoria.DataSource = categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)

    End Sub
#End Region

#Region "CESTO SERVICIOS"
    Public Sub CargarGastoCuentaPAdreLIke()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Try
            'lsvServicios.Columns.Clear()
            'lsvServicios.Items.Clear()
            'lsvServicios.Columns.Add("Cuenta", 75)
            'lsvServicios.Columns.Add("Descripcion", 318)
            '  lsvServicios.Columns.Add("Cuenta Padre", 0)
            For Each i As cuentaplanContableEmpresa In cuentaSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "18")
                Dim n As New ListViewItem(i.cuenta)
                n.SubItems.Add(i.descripcion)
                'lsvServicios.Items.Add(n)
            Next
        Catch ex As Exception
            lblEstado.Text = "Error al obtener Cuentas." & vbCrLf & ex.Message
        End Try
    End Sub

    'Public Sub CargarListaGasto()
    '    Dim cuentaSA As New mascaraGastosEmpresaSA
    '    Try

    '        '  lsvServicios.Columns.Add("Cuenta Padre", 0)
    '        For Each i As mascaraGastosEmpresa In cuentaSA.ObtenerMascaraGastos(Gempresas.IdEmpresaRuc, txtServicio.Text)
    '            Dim n As New ListViewItem(i.cuentaCompra)
    '            n.SubItems.Add(i.descripcionCompra)
    '            lsvServicios.Items.Add(n)
    '        Next
    '    Catch ex As Exception
    '        lblEstado.Text = ("Error al cargar datos. " & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    Public Sub CargarCMBGastos()
        Dim planContableSA As New cuentaplanContableEmpresaSA
        Try
            cboCuentas.DataSource = Nothing
            cboCuentas.DisplayMember = "descripcion"
            cboCuentas.ValueMember = "cuenta"
            cboCuentas.DataSource = planContableSA.LoadCuentasGastos(Gempresas.IdEmpresaRuc)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub
#End Region

#Region "Métodos DGV"
    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvCompra.CurrentCell()

        If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 8 Then

            If e.KeyChar = "."c Or e.KeyChar = ","c Then

                If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

                    e.Handled = True
                Else

                    e.Handled = False
                End If
            Else

                If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

                    If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                        e.Handled = False
                    Else

                        e.Handled = True
                    End If
                Else

                    If e.KeyChar = "0"c Then

                        e.Handled = True
                    Else

                        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                            e.Handled = False
                        Else

                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub Bonificacion()
        '    Dim i As Integer
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0
        Dim base3 As Decimal = 0
        Dim base4 As Decimal = 0
        Dim baseus1 As Decimal = 0
        Dim baseus2 As Decimal = 0
        Dim baseus3 As Decimal = 0
        Dim baseus4 As Decimal = 0
        Dim otc1 As Decimal = 0
        Dim otc2 As Decimal = 0
        Dim otc3 As Decimal = 0
        Dim otc4 As Decimal = 0
        Dim otc1US As Decimal = 0
        Dim otc2US As Decimal = 0
        Dim otc3US As Decimal = 0
        Dim otc4US As Decimal = 0
        Dim total As Decimal = 0
        Dim totalbase2 As Decimal = 0
        Dim totalbase3 As Decimal = 0
        Dim totalbase4 As Decimal = 0
        Dim igv As Decimal = 0
        Dim IGVUS As Decimal = 0
        Dim tus1 As Decimal = 0
        Dim tus2 As Decimal = 0
        Dim tus3 As Decimal = 0
        Dim tus4 As Decimal = 0


        'COLUMNAS
        Dim colCantidad As Decimal = 0
        Dim colPU As Decimal = 0
        Dim colPU_ME As Decimal = 0
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0


        For Each i As DataGridViewRow In dgvCompra.Rows
            colCantidad = i.Cells(7).Value
            colMN = i.Cells(10).Value
            colME = Math.Round(CDec(i.Cells(10).Value) / CDec(txtTipoCambio.Value), 2)
            colPU = Math.Round(CDec(i.Cells(10).Value) / colCantidad, 2)
            colPU_ME = Math.Round(colME / colCantidad, 2)
            '  If Not dgvCompra.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
            If colCantidad > 0 Then

                If i.Cells(27).Value = "S" Then





                    totalbase4 += CDec(i.Cells(10).Value())
                    tus4 += CDec(i.Cells(11).Value()) ' total base 01
                    If cboMoneda.SelectedValue = 1 Then
                        ' DATOS SOLES

                        Select Case i.Cells(1).Value
                            Case "4"
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO SOLES
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(11).Value = colME ' Math.Round(CDec(i.Cells(10).Value / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                i.Cells(10).Value = colMN

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                            Case Else
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO SOLES
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(10).Value = colMN
                                i.Cells(11).Value = colME ' Math.Round(CDec(i.Cells(10).Value / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES


                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                        End Select

                    Else 'If 'txtMoneda.Text = "2" Then
                        ' DATOS DOLARES

                        Select Case i.Cells(1).Value
                            Case "4"
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")  ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value = colMN ' Math.Round(CDec(i.Cells(11).Value * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value = colME

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                            Case Else
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value = colMN ' Math.Round(CDec(i.Cells(11).Value * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value = colME

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                        End Select
                    End If
                Else

                End If
            End If
        Next


        Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)

        '*********************** SOLES ***********************************************
        '****************IMPUESTO 4*******************
        base4 = totalbase4
        nudBase4 = Math.Round(base4, NumDigitos)
        nudBase1 = 0
        nudBase2 = 0
        nudBase3 = 0

        nudMontoIgv1 = 0
        nudMontoIgv2 = 0
        nudMontoIgv3 = 0

        nudBaseus4 = Math.Round(tus4, NumDigitos)
        nudBaseus1 = 0
        nudBaseus2 = 0
        nudBaseus3 = 0

        nudMontoIgvus1 = 0
        nudMontoIgvus2 = 0
        nudMontoIgvus3 = 0
        '***********IMPORTE GRAVADO******************
        'subTotales("All")

        '  totales()
        totales_xx()
        TotalesCabeceras()

    End Sub

    Private Sub MyMethodOnCheckBoxes()
        'DO WHAT EVER WHEN THE SELECTED CHECKBOX IS CHECKED
        If CheckBoxClicked Then
            'DO WHAT DO YOU WANT TO, WHEN CHECKBOX IS NOT CHECKED!!
            '  MsgBox(True)
            Bonificacion()
            dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "S"

        ElseIf Not CheckBoxClicked Then

            CellEndEditRefresh()
            dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "N"

        End If
    End Sub

    Public Sub TotalesCabeceras()

        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0

        Dim cTotalBI As Decimal = 0
        Dim cTotalBI_ME As Decimal = 0

        Dim cTotalIGV As Decimal = 0
        Dim cTotalIGV_ME As Decimal = 0

        Dim cTotalIsc As Decimal = 0
        Dim cTotalIsc_ME As Decimal = 0

        Dim cTotalOTC As Decimal = 0
        Dim cTotalOTC_ME As Decimal = 0

        For Each i As DataGridViewRow In dgvCompra.Rows
            If i.Cells(20).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                cTotalMN += CDec(i.Cells(10).Value)
                cTotalME += CDec(i.Cells(11).Value)

                cTotalBI += CDec(i.Cells(12).Value)
                cTotalBI_ME += CDec(i.Cells(16).Value)

                cTotalIGV += CDec(i.Cells(14).Value)
                cTotalIGV_ME += CDec(i.Cells(18).Value)

                cTotalIsc += CDec(i.Cells(13).Value)
                cTotalIsc_ME += CDec(i.Cells(17).Value)

                cTotalOTC += CDec(i.Cells(15).Value)
                cTotalOTC_ME += CDec(i.Cells(19).Value)
            End If
        Next

        lblTotalBase.Text = cTotalBI.ToString("N2")
        lblTotalBaseUS.Text = cTotalBI_ME.ToString("N2")

        lblTotalISc.Text = cTotalIsc.ToString("N2")
        lblTotalIScUS.Text = cTotalIsc_ME.ToString("N2")

        lblTotalMontoIgv.Text = cTotalIGV.ToString("N2")
        lblTotalMontoIgvUS.Text = cTotalIGV_ME.ToString("N2")

        lblOtrostribTotal.Text = cTotalOTC.ToString("N2")
        lblOtrostribTotalUS.Text = cTotalOTC_ME.ToString("N2")

        Select Case TXTComprobante.ValueMember
            Case "02", "03"
                lblTotalAdquisiones.Text = cTotalMN   'cTotalMN.ToString("N2")
                'lblTotalUS.Text = cTotalME   'cTotalME.ToString("N2")
            Case "08"
                'Instrucciones
            Case Else

                lblTotalAdquisiones.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
                'lblTotalUS.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
        End Select

    End Sub

    Public Sub totales_xx()

        Dim i As Integer
        Dim total, totalbase2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
        Dim tus1, tus2 As Decimal 'tus3, tus4 
        Dim totalIgv1 As Decimal = 0
        Dim totalIgv1_ME As Decimal = 0
        Dim totalIgv2 As Decimal = 0
        Dim totalIgv2_ME As Decimal = 0
        Dim totalIgv3 As Decimal = 0
        Dim totalIgv3_ME As Decimal = 0
        Dim totalIgv4 As Decimal = 0
        Dim totalIgv4_ME As Decimal = 0



        Dim totalBI3 As Decimal = 0
        Dim totalBI3_ME As Decimal = 0
        Dim totalBI4 As Decimal = 0
        Dim totalBI4_ME As Decimal = 0


        Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
        For i = 0 To dgvCompra.Rows.Count - 1
            If dgvCompra.Rows(i).Cells(20).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                'total += carrito.Rows(i)(5)
                If Not dgvCompra.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
                    If dgvCompra.Rows(i).Cells(1).Value() = "1" Then

                        total += dgvCompra.Rows(i).Cells(12).Value() ' total base 01 soles
                        tus1 += dgvCompra.Rows(i).Cells(16).Value() ' total base 01 dolares
                        totalIgv1 += dgvCompra.Rows(i).Cells(14).Value()
                        totalIgv1_ME += dgvCompra.Rows(i).Cells(18).Value()

                    ElseIf dgvCompra.Rows(i).Cells(1).Value() = "2" Then

                        totalbase2 += dgvCompra.Rows(i).Cells(12).Value()
                        tus2 += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
                        totalIgv2 += dgvCompra.Rows(i).Cells(14).Value()
                        totalIgv2_ME += dgvCompra.Rows(i).Cells(18).Value()

                    ElseIf dgvCompra.Rows(i).Cells(1).Value() = "3" Then
                        totalBI3 += dgvCompra.Rows(i).Cells(12).Value()
                        totalBI3_ME += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
                        totalIgv3 += dgvCompra.Rows(i).Cells(14).Value()
                        totalIgv3_ME += dgvCompra.Rows(i).Cells(18).Value()

                    ElseIf dgvCompra.Rows(i).Cells(1).Value() = "4" Then
                        totalBI4 += dgvCompra.Rows(i).Cells(12).Value()
                        totalBI4_ME += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
                        totalIgv4 += dgvCompra.Rows(i).Cells(14).Value()
                        totalIgv4_ME += dgvCompra.Rows(i).Cells(18).Value()
                    End If
                End If
            End If

        Next
        nudBase1 = total.ToString("N2")
        nudBaseus1 = tus1.ToString("N2")
        nudBase2 = totalbase2.ToString("N2")
        nudBaseus2 = tus2.ToString("N2")

        nudBase3 = totalBI3.ToString("N2")
        nudBaseus3 = totalBI3_ME.ToString("N2")
        nudBase4 = totalBI4.ToString("N2")
        nudBaseus4 = totalBI4_ME.ToString("N2")

        nudMontoIgv1 = totalIgv1.ToString("N2")
        nudMontoIgvus1 = totalIgv1_ME.ToString("N2")
        nudMontoIgv2 = totalIgv2.ToString("N2")
        nudMontoIgvus2 = totalIgv2_ME.ToString("N2")

        nudMontoIgv3 = totalIgv3.ToString("N2")
        nudMontoIgvus3 = totalIgv3_ME.ToString("N2")
        nudMontoIgv3 = totalIgv3.ToString("N2")
        nudMontoIgvus3 = totalIgv3_ME.ToString("N2")

    End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************

        If dgvCompra.Rows.Count > 0 Then
            'DECLARANDO VARIABLES

            For Each i As DataGridViewRow In dgvCompra.Rows
                If i.Cells(20).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                    Dim colDestinoGravado As String = 0
                    colDestinoGravado = i.Cells(1).Value

                    Dim colCantidad As Decimal = CDec(i.Cells(7).Value)


                    Dim colBI As Decimal = 0
                    Dim colBI_ME As Decimal = 0
                    Dim colIGV_ME As Decimal = 0
                    Dim colIGV As Decimal = 0
                    Dim colMN As Decimal = i.Cells(10).Value
                    Dim colME As Decimal = Math.Round(CDec(i.Cells(10).Value) / CDec(txtTipoCambio.Value), 2)
                    Dim colPrecUnit As Decimal = 0
                    Dim colPrecUnitUSD As Decimal = 0

                    If colMN > 0 Then

                        colPrecUnit = Math.Round(colMN / colCantidad, 2)
                        colPrecUnitUSD = Math.Round(colME / colCantidad, 2)

                        colBI = Math.Round(colMN / 1.18, 2)
                        colBI_ME = Math.Round(colME / 1.18, 2)
                        colIGV = Math.Round((colMN / 1.18) * 0.18, 2)
                        colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2)


                    Else
                        colPrecUnit = 0

                        colPrecUnitUSD = 0

                        colBI = 0
                        colBI_ME = 0
                        colIGV = 0
                        colIGV_ME = 0
                    End If
                    Select Case TXTComprobante.ValueMember
                        Case "08"
                            'If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                            '    totales_xx()
                            'End If
                        Case "03", "02"
                            '   If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoSolessc" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "Can1" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoUsdsc" Then 'Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                            If txtTipoCambio.Value = 0.0 Then
                                MsgBox("Ingrese Tipo de Cambio..!")
                                txtTipoCambio.Focus()
                                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                Exit Sub
                            End If
                            Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                            If colCantidad = 0 And colMN = 0 And colME = 0 Then
                                i.Cells(8).Value() = "0.00"
                                i.Cells(9).Value() = "0.00"
                                Exit Sub
                            Else 'If colCantidad = 0 Then

                                If cboMoneda.SelectedValue = 1 Then
                                    ' DATOS SOLES
                                    Select Case colDestinoGravado
                                        Case "4"
                                            i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN
                                            i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)

                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                        Case Else
                                            i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value = colMN
                                            i.Cells(9).Value = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                    End Select

                                ElseIf cboMoneda.SelectedValue = 2 Then
                                    ' DATOS DOLARES
                                    Select Case colDestinoGravado
                                        Case "4"
                                            i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                            i.Cells(10).Value() = colMN
                                            i.Cells(11).Value() = colME
                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                        Case Else
                                            i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                    End Select

                                    '      End If
                                ElseIf colCantidad > 0 Then
                                    If cboMoneda.SelectedValue = 1 Then
                                        ' DATOS SOLES
                                        If i.Cells(1).Value = "4" Then
                                            i.Cells(7).Value() = colCantidad
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN 'CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")

                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                        Else
                                            i.Cells(7).Value() = colCantidad 'CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                        End If

                                    ElseIf cboMoneda.SelectedValue = 2 Then

                                        Select Case colDestinoGravado
                                            Case "4"
                                                ' DATOS DOLARES

                                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                                i.Cells(12).Value() = "0.00"
                                                i.Cells(13).Value() = "0.00"
                                                i.Cells(14).Value() = "0.00"
                                                i.Cells(15).Value() = "0.00"
                                                i.Cells(16).Value() = "0.00"
                                                i.Cells(17).Value() = "0.00"
                                                i.Cells(18).Value() = "0.00"
                                                i.Cells(19).Value() = "0.00"
                                            Case Else
                                                ' DATOS DOLARES
                                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                                i.Cells(12).Value() = "0.00"
                                                i.Cells(13).Value() = "0.00"
                                                i.Cells(14).Value() = "0.00"
                                                i.Cells(15).Value() = "0.00"
                                                i.Cells(16).Value() = "0.00"
                                                i.Cells(17).Value() = "0.00"
                                                i.Cells(18).Value() = "0.00"
                                                i.Cells(19).Value() = "0.00"
                                        End Select

                                    End If
                                End If

                                totales_xx()
                                TotalesCabeceras()

                            End If

                            '**********************************************************************************************************************************************************************************
                        Case Else
                            '       If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoSolessc" Then
                            If txtTipoCambio.Value = 0.0 Then
                                MsgBox("Ingrese Tipo de Cambio..!")
                                txtTipoCambio.Focus()
                                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                Exit Sub
                            End If

                            Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                            If colCantidad = 0 And colMN = 0 And colME = 0 Then
                                i.Cells(8).Value() = "0.00"
                                i.Cells(9).Value() = "0.00"
                                Exit Sub

                            ElseIf colCantidad = 0 Then

                                If cboMoneda.SelectedValue = 1 Then
                                    ' DATOS SOLES
                                    Select Case colDestinoGravado
                                        Case "4"
                                            i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                        Case Else

                                            ''   If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
                                            'dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            'dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            'dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            'dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            'dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            'dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                            'dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                            'dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                            'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                            'Else
                                            i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(12).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(14).Value() = colIGV  ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                            i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                            i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                            '      i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                            '   End If
                                    End Select

                                ElseIf cboMoneda.SelectedValue = 2 Then
                                    ' DATOS DOLARES
                                    Select Case colDestinoGravado
                                        Case "4"
                                            i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME

                                            ' dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                            ' dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                            '  dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                            '  dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                            '  dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                        Case Else

                                            'If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
                                            '    dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            '    dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN 'Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            '    dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME

                                            '    dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            '    dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                            '    dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            '    dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV
                                            '    dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                            '    dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                            'Else
                                            i.Cells(8).Value() = "0.00"
                                            i.Cells(9).Value() = "0.00"
                                            i.Cells(10).Value() = colMN
                                            i.Cells(11).Value() = colME

                                            i.Cells(12).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(14).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                            '    i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                            'End If
                                    End Select

                                End If
                            ElseIf colCantidad > 0 Then
                                If cboMoneda.SelectedValue = 1 Then
                                    ' DATOS SOLES
                                    If colDestinoGravado = "4" Then
                                        i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                        '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto igv del item

                                        ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex USD
                                        ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV USD


                                        'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS DOLARES
                                    Else
                                        If i.Cells(27).Value() = "S" Then
                                            i.Cells(7).Value() = colCantidad '  CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            i.Cells(12).Value() = "0.00" ' monto para el kardex
                                            i.Cells(14).Value() = "0.00" ' monto igv del item

                                            i.Cells(16).Value() = "0.00" ' monto para el kardex USD
                                            i.Cells(18).Value() = "0.00" ' monto para el IGV USD


                                            i.Cells(19).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                        Else
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            i.Cells(12).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(14).Value() = colIGV ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                            i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                            i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                            '        i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

                                        End If

                                    End If

                                ElseIf cboMoneda.SelectedValue = 2 Then

                                    Select Case colDestinoGravado
                                        Case "4"
                                            ' DATOS DOLARES
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                            '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                            ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                            ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                            ' dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                        Case Else
                                            ' DATOS DOLARES
                                            If i.Cells(27).Value() = "S" Then
                                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                                i.Cells(12).Value() = "0.00" ' monto para el kardex
                                                i.Cells(14).Value() = "0.00" ' igv del item

                                                i.Cells(16).Value() = "0.00" ' monto para el kardex
                                                i.Cells(18).Value() = "0.00" ' monto para el IGV

                                                i.Cells(15).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                            Else
                                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                                i.Cells(12).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                i.Cells(14).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                                i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                                '        i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                            End If

                                    End Select

                                End If
                            End If
                            totales_xx()
                            TotalesCabeceras()


                    End Select
                End If

            Next
        End If

    End Sub


#End Region

#Region "Manipulación Data"

    Function DocObligacion() As documento
        Dim documento As New documento
        Dim documentoObligacion As New documentoObligacionTributaria
        Dim documentoDetalle As New List(Of documentoObligacionDetalle)
        Dim objdocumentoDetalle As New documentoObligacionDetalle
        Dim docTributoSA As New DocumentoObligacionTributariaSA

        With documento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaProceso = fecha
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With documentoObligacion
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .codigoLibro = "8"
            .fechaDoc = fecha
            .periodo = lblPerido.Text


            .idEntidad = txtProveedor.ValueMember
            .tipoOperacion = "02"
            .idEntidadFinanciera = Nothing
            .tipoDesposito = Nothing

            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")

            .tipoCambio = txtTipoCambio.Value


            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        documento.documentoObligacionTributaria = documentoObligacion

        objdocumentoDetalle = New documentoObligacionDetalle
        objdocumentoDetalle.idItem = Nothing

        objdocumentoDetalle.destino = "0"
        objdocumentoDetalle.unidadMedida = Nothing
        objdocumentoDetalle.cantidad = Nothing
        objdocumentoDetalle.precioUnitario = Nothing
        objdocumentoDetalle.precioUnitarioUS = Nothing
        objdocumentoDetalle.porcTributo = Nothing

        objdocumentoDetalle.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        objdocumentoDetalle.fechaActualizacion = DateTime.Now
        documentoDetalle.Add(objdocumentoDetalle)

        documento.documentoObligacionTributaria.documentoObligacionDetalle = documentoDetalle

        Return documento
    End Function

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim estadoF As New EstadosFinancierosSA

        Dim inventarioBL As New inventarioMovimientoSA
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen

        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle
        Try
            'chObligacion.Visible = False
            With objDoc.UbicarDocumento(intIdDocumento)
                fecha = .fechaProceso
                txtFechaComprobante.Text = .fechaProceso
                'COMPROBANTE
                'With objTabla.GetUbicarTablaID(10, .tipoDoc)
                '   TXTComprobante.ValueMember.SelectedValue = .tipoDoc
                'cboTipoDoc.Text = .descripcion
                'End With
            End With

            DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            If Not IsNothing(DocumentoGuia) Then
                With DocumentoGuia

                End With
            End If

            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                lblIdDocumento.Text = .idDocumento
                '   cboTipoDoc.SelectedValue = .tipoDoc

                'With objTabla.GetUbicarTablaID(10, .tipoDoc)
                '    txtComprobante.Text = .descripcion
                'End With


                lblPerido.Text = .fechaContable


                'PROVEEDOR
                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                'txtCuenta.Text = nEntidad.cuentaAsiento
                txtProveedor.ValueMember = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                '_::::::::::::::::::        :::::::::::::::::::
                txtTipoCambio.Value = .tcDolLoc

            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Rows.Clear()

            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)
                If i.destino = "1" Then
                    VALUEDES = "1"
                ElseIf i.destino.Trim = "2" Then
                    VALUEDES = "2"
                ElseIf i.destino.Trim = "3" Then
                    VALUEDES = "3"
                ElseIf i.destino.Trim = "4" Then
                    VALUEDES = "4"
                End If

                Select Case i.tipoExistencia
                    Case "GS"
                        dgvCompra.Rows.Add(i.secuencia,
                                    VALUEDES,
                                    i.idItem,
                                    i.descripcionItem,
                                    i.unidad2,
                                    i.monto2,
                                    i.unidad1,
                                    FormatNumber(i.monto1, 2),
                                    FormatNumber(i.precioUnitario, 2),
                                    FormatNumber(i.precioUnitarioUS, 2),
                                    FormatNumber(i.importe, 2),
                                    FormatNumber(i.importeUS, 2),
                                    FormatNumber(i.montokardex, 2),
                                    FormatNumber(i.montoIsc, 2),
                                    FormatNumber(i.montoIgv, 2),
                                    FormatNumber(i.otrosTributos, 2),
                                    FormatNumber(i.montokardexUS, 2),
                                    FormatNumber(i.montoIscUS, 2),
                                    FormatNumber(i.montoIgvUS, 2),
                                    FormatNumber(i.otrosTributosUS, 2),
                                    Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                    i.idItem,
                                    i.preEvento,
                                    Nothing, Nothing, Nothing,
                                    IIf(i.bonificacion = "S", "S", "N"), Nothing, i.bonificacion, i.almacenRef)
                    Case Else

                        dgvCompra.Rows.Add(i.secuencia,
                                    VALUEDES,
                                    i.idItem,
                                    i.descripcionItem,
                                    i.unidad2,
                                    i.monto2,
                                    i.unidad1,
                                    FormatNumber(i.monto1, 2),
                                    FormatNumber(i.precioUnitario, 2),
                                    FormatNumber(i.precioUnitarioUS, 2),
                                    FormatNumber(i.importe, 2),
                                    FormatNumber(i.importeUS, 2),
                                    FormatNumber(i.montokardex, 2),
                                    FormatNumber(i.montoIsc, 2),
                                    FormatNumber(i.montoIgv, 2),
                                    FormatNumber(i.otrosTributos, 2),
                                    FormatNumber(i.montokardexUS, 2),
                                    FormatNumber(i.montoIscUS, 2),
                                    FormatNumber(i.montoIgvUS, 2),
                                    FormatNumber(i.otrosTributosUS, 2),
                                    Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                    insumosSA.InvocarProductoID(i.idItem).cuenta,
                                    i.preEvento,
                                    Nothing, Nothing, Nothing,
                                    IIf(i.bonificacion = "S", "S", "N"), Nothing, i.bonificacion, i.almacenRef)
                End Select


            Next


            '    lblTotalItems.Text = "Nro. de items: " & dgvCompra.Rows.Count
            totales_xx()
            TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .descripcion = txtProveedor.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.ValueMember
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS

        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO
        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .destinoCompra
                End With
            Case "02", "03", "04", "05"
                With mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, cCuenta, strTipoExistencia)
                    nMovimiento.cuenta = .destinoCompra
                End With
        End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .destinoCompra2
                End With
            Case "02", "03", "04", "05"
                With mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, cCuenta, strTipoExistencia)
                    nMovimiento.cuenta = .destinoCompra2
                End With
        End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Function AsientoCabeceraCompra(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        'ASIENTO POR LA COMPRA
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.ValueMember
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.OrdenCompra
        'nAsiento.importeMN = CDec(lblTotalAdquisiones.Text)
        'nAsiento.importeME = CDec(lblTotalUS.Text)

        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function


    Public Sub AsientoCompra()
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoCabeceraCompra(CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text)) ' CABECERA ASIENTO

        '---------------------------------------------------------------------------------------------
        'DETALLE DEL ASIENTO DE COMPRA
        'MOVIMIENTOS
        For Each i As DataGridViewRow In dgvCompra.Rows

            If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                If dgvCompra.Rows(i.Index).Cells(27).Value() <> "S" Then
                    nMovimiento = New movimiento
                    nMovimiento.cuenta = dgvCompra.Rows(i.Index).Cells(22).Value()
                    nMovimiento.descripcion = dgvCompra.Rows(i.Index).Cells(3).Value()
                    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                    Select Case TXTComprobante.ValueMember
                        Case "03", "02"
                            nMovimiento.monto = CDec(dgvCompra.Rows(i.Index).Cells(10).Value())
                            nMovimiento.montoUSD = CDec(dgvCompra.Rows(i.Index).Cells(11).Value())
                        Case Else
                            Select Case dgvCompra.Rows(i.Index).Cells(1).Value()
                                Case "1"
                                    nMovimiento.monto = CDec(dgvCompra.Rows(i.Index).Cells(12).Value())
                                    nMovimiento.montoUSD = CDec(dgvCompra.Rows(i.Index).Cells(16).Value())
                                Case Else
                                    nMovimiento.monto = CDec(dgvCompra.Rows(i.Index).Cells(10).Value())
                                    nMovimiento.montoUSD = CDec(dgvCompra.Rows(i.Index).Cells(11).Value())
                            End Select
                    End Select
                    nMovimiento.fechaActualizacion = DateTime.Now
                    nMovimiento.usuarioActualizacion = "Jiuni"
                    asientoTransitod.movimiento.Add(nMovimiento)
                End If
            End If
        Next
        Select Case TXTComprobante.ValueMember
            Case "03", "02"
                'NO TIENE ASIENTO DE IGV
            Case Else
                asientoTransitod.movimiento.Add(AS_IGV(CDec(lblTotalMontoIgv.Text), CDec(lblTotalMontoIgvUS.Text)))
        End Select
        asientoTransitod.movimiento.Add(AS_Proveedor(CDec(lblTotalAdquisiones.Text), CDec(lblTotalUS.Text)))

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Function ASBOF(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.ValueMember
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.BONIFICACION
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Sub UpdateOtros()
        Dim nRecursoSA As New DocumentoOtrosDatosSA
        Dim nRecurso As New documentoOtrosDatos
        For i = 0 To dgvCompra.Rows.Count - 1
            nRecurso = New documentoOtrosDatos With {
            .idDocumento = CInt(lblIdDocumento.Text),
            .fechaInicio = txtFechaInicioPlazo.Value,
            .fechaFin = txtFechaFinPlazo.Value,
            .FechaIniGarantia = txtFechaInicioGarantia.Value,
            .FechaFinGarantia = txtFechaFinGarantia.Value,
            .notas = txtNotas.Text,
            .indicaciones = txtIndicaciones.Text,
            .condicionPago = CboPago.SelectedValue,
             .CentroCostos = CInt("1"),
            .idAlmacen = cboAlmacen.SelectedValue,
            .Vcto = txtVcto.Text,
            .Modalidad = cboModalidad.SelectedValue,
            .ctaDeposito = txtcto.Text,
            .institucionFinanciera = txtFinaciera.Text,
            .estado = "P",
            .usuarioActualizacion = "Jiuni",
            .fechaActualizacion = DateTime.Now}
            If (nRecursoSA.UpdateOtros(nRecurso)) Then
                lblEstado.Text = " editado!"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Next


    End Sub
    'martin upodate doc

    Sub UpdateDoc()
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        For i = 0 To dgvCompra.Rows.Count - 1
            nRecurso = New documentocompra With {
            .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
            .codigoLibro = "1",
            .serie = GConfiguracion.Serie,
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
            .tipoDoc = "00",
            .idDocumento = CInt(lblIdDocumento.Text),
            .fechaDoc = txtFechaComprobante.Value,
            .idProveedor = txtProveedor.ValueMember,
            .monedaDoc = cboMoneda.SelectedValue,
            .tcDolLoc = CDec(txtTipoCambio.Value),
            .importeTotal = lblTotalAdquisiones.Text,
            .importeUS = lblTotalUS.Text}
            If (nRecursoSA.UpdateDoc(nRecurso)) Then
                UpdateOtros()
                lblEstado.Text = " editado!"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Next


    End Sub
    'martin update
    Sub UpdateCompra()
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompradetalle
        For i = 0 To dgvCompra.Rows.Count - 1
            Dim a As Integer
            If dgvCompra.Item(20, i).Value = Business.Entity.BaseBE.EntityAction.UPDATE Then
                a = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvCompra.Item(20, i).Value = Business.Entity.BaseBE.EntityAction.INSERT Then
                a = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvCompra.Item(20, i).Value = Business.Entity.BaseBE.EntityAction.DELETE Then
                a = Business.Entity.BaseBE.EntityAction.DELETE
            End If
            'Dim a As Integer
            nRecurso = New documentocompradetalle With {
            .usuarioModificacion = "jiuni",
            .fechaModificacion = DateTime.Now,
            .Action = a,
            .idDocumento = CInt(lblIdDocumento.Text),
            .idItem = dgvCompra.Item(2, i).Value.ToString,
            .descripcionItem = dgvCompra.Item(3, i).Value.ToString,
            .secuencia = dgvCompra.Item(0, i).Value.ToString,
             .monto1 = dgvCompra.Item(7, i).Value.ToString,
            .precioUnitario = dgvCompra.Item(8, i).Value.ToString,
            .precioUnitarioUS = dgvCompra.Item(9, i).Value.ToString,
            .importe = dgvCompra.Item(10, i).Value.ToString,
            .tipoExistencia = dgvCompra.Item(21, i).Value.ToString,
            .importeUS = dgvCompra.Item(11, i).Value.ToString,
            .montokardex = dgvCompra.Item(12, i).Value.ToString,
            .montoIsc = dgvCompra.Item(13, i).Value.ToString,
            .montoIgv = dgvCompra.Item(14, i).Value.ToString,
            .otrosTributos = dgvCompra.Item(15, i).Value.ToString,
            .montokardexUS = dgvCompra.Item(16, i).Value.ToString,
            .montoIscUS = dgvCompra.Item(17, i).Value.ToString,
            .montoIgvUS = dgvCompra.Item(18, i).Value.ToString,
            .otrosTributosUS = dgvCompra.Item(19, i).Value.ToString,
            .unidad1 = dgvCompra.Item(6, i).Value.ToString}

            If dgvCompra.Item(7, i).Value.ToString = 0 Then
                lblEstado.Text = "debe ingresar cantidades mayor a cero"
                Exit Sub
            End If
            If (nRecursoSA.UpdateOrdenCompra(nRecurso, "tipo")) Then
                lblEstado.Text = " editado!"
                lblEstado.Image = My.Resources.ok4
                UpdateDoc()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Next
    End Sub

    Enum Sys
        Inicio
        Proceso
    End Enum

    Sub InfoConfiguracion(n As Sys)
        If Not IsNothing(GConfiguracion) Then
            If Not IsNothing(GConfiguracion.NomModulo) Then
                UserControl1.lblCodigo.Text = "C1"
                UserControl1.lblModulo.Text = Me.Text
                UserControl1.lblConfiguracion.Text = IIf(GConfiguracion.TipoConfiguracion = "M", "MANUAL", "PROGRAMADA")
                UserControl1.lblComprobante.Text = GConfiguracion.NombreComprobante
                UserControl1.lblSerie.Text = GConfiguracion.Serie
                UserControl1.lblNumImpresiones.Text = IIf(IsNothing(GConfiguracion.ValorActual), 0, GConfiguracion.ValorActual)
                UserControl1.lblAlmacen.Text = GConfiguracion.NombreAlmacen
                UserControl1.lblCaja.Text = GConfiguracion.NomCaja
                ' position the tooltip with its stem towards the right end of the button
                If n = Sys.Inicio Then
                ElseIf n = Sys.Proceso Then
                    toolTip.Show(btnConfiguracion)
                End If
            End If
        End If
    End Sub

#End Region


    Private Sub frmCompraCreditoSinRecepcion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCompraCreditoSinRecepcion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblPerido.Text = PeriodoGeneral
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        toolTip = New Popup(UserControl1)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracion(Sys.Inicio)
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            cboMoneda.SelectedValue = 1
        ElseIf IsNothing(ManipulacionEstado) Then
            cboMoneda.SelectedValue = 1
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        Else
            If DocumentoCompraSA.TieneItemsEnAV(CInt(lblIdDocumento.Text)) = True Then
            Else
            End If
        End If

        If lblIdDocumento.Text > 0 Then
            UbicarDocumentos(lblIdDocumento.Text)
        End If

        If dgvCompra.Rows.Count > 0 Then
            For Each i As DataGridViewRow In dgvCompra.Rows
                Dim a As Decimal
                Dim g As Decimal
                a += Math.Round(CDec(i.Cells(10).Value), 2)
                lblTotalAdquisiones.Text = a.ToString("N2")
                g += Math.Round(CDec(i.Cells(11).Value), 2)
                lblTotalUS.Text = g.ToString("N2")
            Next
        End If


    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub tbnAlmacen_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnConfiguracion_Click(sender As System.Object, e As System.EventArgs) Handles btnConfiguracion.Click
        InfoConfiguracion(Sys.Proceso)
    End Sub

    Private Sub chObligacion_CheckStateChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp

    End Sub

    Private Sub btnVer_Click(sender As System.Object, e As System.EventArgs)
        dockingManager1.SetDockVisibility(Panel2, True)
        dockingManager1.DockControl(Panel8, Me, Tools.DockingStyle.Left, 528)


    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        If dgvCompra.Rows.Count > 0 Then

            If Not IsNothing(dgvCompra.CurrentRow) Then

                If dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    dgvCompra.Rows.RemoveAt(dgvCompra.CurrentCell.RowIndex)
                ElseIf dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvCompra.CurrentRow.Index

                    dgvCompra.CurrentCell = Nothing
                    Me.dgvCompra.Rows(pos).Visible = False
                End If
                If dgvCompra.Rows.Count > 0 Then
                    For Each i As DataGridViewRow In dgvCompra.Rows
                        If i.Cells(10).Visible = True Then
                            Dim a As Decimal
                            Dim g As Decimal
                            a += Math.Round(CDec(i.Cells(10).Value), 2)
                            lblTotalAdquisiones.Text = a.ToString("N2")
                            g += Math.Round(CDec(i.Cells(11).Value), 2)
                            lblTotalUS.Text = g.ToString("N2")
                        End If

                    Next
                End If
            End If
        End If
    End Sub

    Private Sub rbRetencion_CheckChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub rbDetraccion_CheckChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub rbPercepcion_CheckChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub nudPorcentajeTributo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CALCULO_TRIBUTOS()
        End If
    End Sub

    Private Sub nudPorcentajeTributo_ValueChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub dropDownBtn_Click_1(sender As System.Object, e As System.EventArgs)
        Me.popupControlContainer1.ParentControl = Me.txtProveedor
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                'txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                txtTelefono.Text = lsvProveedor.SelectedItems(0).SubItems(4).Text
                txtCorreo.Text = lsvProveedor.SelectedItems(0).SubItems(5).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs)
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cancel_Click(sender As System.Object, e As System.EventArgs)
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs)
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub cboTipoDoc_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub chFormato_CheckStateChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            cboMoneda.Select()
        End If
    End Sub

    Private Sub cboMoneda_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboMoneda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            dropDownBtn.Focus()
        End If
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True

        End If
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub txtSerieGuia_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub txtNumeroGuia_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub dgvCompra_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        If dgvCompra.Rows.Count > 0 Then
            'DECLARANDO VARIABLES
            Dim colDestinoGravado As Decimal = 0
            colDestinoGravado = dgvCompra.Item(1, dgvCompra.CurrentRow.Index).Value

            Dim colCantidad As Decimal = 0
            If Not CStr(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value).Trim.Length > 0 Then
                lblEstado.Text = "Ingrese una cantidad válida!"
                lblEstado.Image = My.Resources.warning2
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
                Exit Sub
            Else
                colCantidad = dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value
            End If

            Dim colBI As Decimal = 0
            Dim colBI_ME As Decimal = 0
            Dim colIGV_ME As Decimal = 0
            Dim colIGV As Decimal = 0
            Dim colMN As Decimal = 0

            If Not CStr(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value).Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un importe válido!"
                lblEstado.Image = My.Resources.warning2
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
                Exit Sub
            Else
                colMN = dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value
            End If

            Dim colME As Decimal = Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value) / CDec(txtTipoCambio.Value), 2)
            Dim colPrecUnit As Decimal = 0
            Dim colPrecUnitUSD As Decimal = 0


            If colCantidad > 0 AndAlso colMN > 0 Then

                colPrecUnit = Math.Round(colMN / colCantidad, 2)
                colPrecUnitUSD = Math.Round(colME / colCantidad, 2)

                colBI = Math.Round(colMN / 1.18, 2)
                colBI_ME = Math.Round(colME / 1.18, 2)
                colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)


            Else

                colPrecUnit = 0
                colPrecUnitUSD = 0
                colBI = 0
                colBI_ME = 0
                colIGV = 0
                colIGV_ME = 0
            End If
            Select Case TXTComprobante.ValueMember
                Case "08"
                    If dgvCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        totales_xx()
                    End If
                Case "03", "02"
                    If dgvCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvCompra.Columns(e.ColumnIndex).Name = "Can1" Or dgvCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        If txtTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            txtTipoCambio.Focus()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If

                        Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"
                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00"
                            Exit Sub

                        ElseIf colCantidad = 0 Then

                            If cboMoneda.SelectedValue = 1 Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)

                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    Case Else
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                End Select

                            ElseIf cboMoneda.SelectedValue = 2 Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES

                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    Case Else
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                End Select

                            End If
                        ElseIf colCantidad > 0 Then
                            If cboMoneda.SelectedValue = 1 Then
                                ' DATOS SOLES
                                If dgvCompra.Item(1, dgvCompra.CurrentRow.Index).Value = "4" Then
                                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2")
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") 'CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")

                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                Else
                                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") 'CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")


                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                End If

                            ElseIf cboMoneda.SelectedValue = 2 Then

                                Select Case colDestinoGravado
                                    Case "4"
                                        ' DATOS DOLARES

                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")


                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    Case Else
                                        ' DATOS DOLARES
                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")


                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                End Select

                            End If
                        End If
                        'totales()
                        'subTotales("All")
                        totales_xx()
                        TotalesCabeceras()
                    End If
                    If dgvCompra.Columns(e.ColumnIndex).Name = "ISC" Then
                        'totalesPorCaja("ISC")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "ISCus" Then
                        'totalesPorCaja("ISCUS")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "igv" Then
                        'totalesPorCaja("IGV")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "IGVus" Then
                        'totalesPorCaja("IGVUS")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "otrostributos" Then
                        'totalesPorCaja("OTC")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        'totalesPorCaja("OTCUS")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "kardex" Then
                        'totalesPorCaja("KARDEX")
                        'subTotales("All")
                    End If

                    If dgvCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                    End If
                    '**********************************************************************************************************************************************************************************
                    '**********************************************************************************************************************************************************************************
                    '**********************************************************************************************************************************************************************************
                Case Else
                    If dgvCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvCompra.Columns(e.ColumnIndex).Name = "Can1" Or dgvCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Or dgvCompra.Columns(e.ColumnIndex).Name = "Prec" Then 'Or dgvCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        If txtTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            txtTipoCambio.Focus()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If

                        Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"
                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00"
                            Exit Sub

                        ElseIf colCantidad = 0 Then

                            If cboMoneda.SelectedValue = 1 Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                    Case Else

                                        If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                            dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                        Else
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2")  ' Math.Round(CDec(neto - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                            '        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                        End If
                                End Select


                            ElseIf cboMoneda.SelectedValue = 2 Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")

                                    Case Else

                                        If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") 'Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")

                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                            dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        Else
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")

                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(netous - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV


                                        End If
                                End Select

                            End If
                        ElseIf colCantidad > 0 Then
                            If cboMoneda.SelectedValue = 1 Then
                                ' DATOS SOLES
                                If colDestinoGravado = "4" Then
                                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")

                                Else
                                    If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") '  CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item

                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD


                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                    Else
                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(neto - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD




                                    End If

                                End If

                            ElseIf cboMoneda.SelectedValue = 2 Then

                                Select Case colDestinoGravado
                                    Case "4"
                                        ' DATOS DOLARES
                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")


                                    Case Else
                                        ' DATOS DOLARES
                                        If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                            dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV

                                            dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        Else
                                            dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(netous - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                        End If

                                End Select

                            End If
                        End If

                        totales_xx()
                        TotalesCabeceras()
                    End If


            End Select
        End If
    End Sub

    Private Sub dgvCompra_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.RowIndex > -1 Then
            If e.ColumnIndex = Me.dgvCompra.Columns("Gravado").Index _
AndAlso (e.Value IsNot Nothing) Then

                With Me.dgvCompra.Rows(e.RowIndex).Cells(e.ColumnIndex)

                    If e.Value.Equals("1") Then
                        .ToolTipText = "1: ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES"
                    ElseIf e.Value.Equals("2") Then
                        .ToolTipText = "2: ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV"
                    ElseIf e.Value.Equals("3") Then
                        .ToolTipText = "3: ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS"
                    ElseIf e.Value.Equals("4") Then
                        .ToolTipText = "4: ADQUISICIONES NO GRAVADAS"
                    End If

                End With

            End If
        End If
    End Sub

    Private Sub dgvCompra_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        If dgvCompra.Rows.Count > 0 Then



            Dim b As Decimal
            Dim c As Decimal
            Dim d As Decimal
            Dim h As Decimal
            Dim f As Decimal


            b = Math.Round(((dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value) * CDec(dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value)), 2)
            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = b.ToString("N2")
            c = Math.Round(CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value), 2)
            dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = c.ToString("N2")
            d = Math.Round(CDec(dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value), 2)
            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = d.ToString("N2")


            h = Math.Round(((dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value) * CDec(txtTipoCambio.Value)), 2)
            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = h.ToString("N2")
            f = Math.Round(((dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value) * CDec(dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value)), 2)
            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = f.ToString("N2")


            For Each i As DataGridViewRow In dgvCompra.Rows
                Dim a As Decimal
                Dim g As Decimal
                a += Math.Round(CDec(i.Cells(10).Value), 2)
                lblTotalAdquisiones.Text = a.ToString("N2")
                g += Math.Round(CDec(i.Cells(11).Value), 2)
                lblTotalUS.Text = g.ToString("N2")
            Next

        End If




    End Sub

    Private Sub dgvCompra_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs)
        Try
            If dgvCompra.IsCurrentCellDirty Then
                dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            If TypeOf dgvCompra.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        Catch
        End Try
    End Sub

    Private Sub dgvCompra_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvCompra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        Dim conteo As Integer = dgvCompra.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvCompra.CurrentCell.ColumnIndex)
                    Case 7
                        If cboMoneda.SelectedValue = 1 Then
                            If conteo = 1 Then
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(8, Me.dgvCompra.CurrentCell.RowIndex)
                            Else
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(8, Me.dgvCompra.CurrentCell.RowIndex)
                            End If
                        Else
                            If conteo = 1 Then
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            Else
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            End If
                        End If
                    Case 3
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(0, Me.dgvCompra.CurrentCell.RowIndex)
                    Case 10 Or 11
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(23, Me.dgvCompra.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub dgvCompra_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Dim grid As DataGridView = TryCast(sender, DataGridView)

        If Not grid.RowHeadersVisible Then
            Return
        End If

        'this method overrides the DataGridView's RowPostPaint event 
        'in order to automatically draw numbers on the row header cells
        'and to automatically adjust the width of the column containing
        'the row header cells so that it can accommodate the new row
        'numbers,

        'store a string representation of the row number in 'strRowNumber'
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()

        'prepend leading zeros to the string if necessary to improve
        'appearance. For example, if there are ten rows in the grid,
        'row seven will be numbered as "07" instead of "7". Similarly, if 
        'there are 100 rows in the grid, row seven will be numbered as "007".
        While strRowNumber.Length < grid.RowCount.ToString().Length
            strRowNumber = Convert.ToString("0") & strRowNumber
        End While

        'determine the display size of the row number string using
        'the DataGridView's current font.
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, grid.Font)

        'adjust the width of the column that contains the row header cells 
        'if necessary
        If grid.RowHeadersWidth < CInt(size.Width + 20) Then
            grid.RowHeadersWidth = CInt(size.Width + 20)
        End If

        'this brush will be used to draw the row number string on the
        'row header cell using the system's current ControlText color
        Dim b As Brush = SystemBrushes.ControlText

        'draw the row number string on the current row header cell using
        'the brush defined above and the DataGridView's default font
        e.Graphics.DrawString(strRowNumber, grid.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        'Me.PopupControlContainer2.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCategoria.SelectedItems.Count > 0 Then
                Me.txtCategoria.ValueMember = lstCategoria.SelectedValue
                txtCategoria.Text = lstCategoria.Text
                ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As System.Object, e As System.EventArgs)
        'Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs)
        'Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub ButtonCategoria_Click(sender As System.Object, e As System.EventArgs)
        'Me.PopupControlContainer2.ParentControl = Me.txtCategoria
        'Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub cboTipoExistencia_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        If cboTipoExistencia.SelectedIndex > -1 Then

        End If
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        'If lsvListadoItems.SelectedItems.Count > 0 Then
        '    With objInsumo.InvocarProductoID(CInt(lsvListadoItems.SelectedItems(0).SubItems(0).Text))
        '        dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
        '                             .presentacion,
        '                                tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
        '                              0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
        '                              .tipoExistencia, .cuenta, Nothing)
        '    End With
        'End If
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboCuentas_Click(sender As System.Object, e As System.EventArgs) Handles cboCuentas.Click

    End Sub

    Private Sub cboCuentas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCuentas.SelectedIndexChanged

    End Sub

    Private Sub lsvServicios_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click


        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"
                lblEstado.Image = My.Resources.warning2
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"
                lblEstado.Image = My.Resources.ok4
            End If

            If Not IsNothing(GConfiguracion.NomModulo) Then
                Select Case GConfiguracion.TipoConfiguracion
                    Case "M"

                    Case "P"

                End Select
            End If

            If dgvCompra.Rows.Count > 0 Then
                If lblIdDocumento.Text = "00" Then
                    Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                    Me.lblEstado.Text = "Done!"

                    'If txtIndicaciones.MaxLength > 0 Then
                    GrabarSolicitud()
                    Dispose()

                    'Else
                    '    MessageBox.Show("INGRESE INDICACIONES")
                    'End If

                ElseIf lblIdDocumento.Text > 0 Then
                    Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    If Filas > 0 Then

                        UpdateCompra()
                        Dispose()

                    Else
                        Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                        Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                        'Timer1.Enabled = True
                        'TiempoEjecutar(5)
                    End If


                End If
            Else
                Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
            'Timer1.Enabled = True
            'TiempoEjecutar(5)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnConfiguracion_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnConfiguracion.MouseLeave
        toolTip.Close()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub dgvCompra_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs)


    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lblTotalBaseUS_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ButtonAdv2_Click_1(sender As System.Object, e As System.EventArgs)
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv1_Click_1(sender As System.Object, e As System.EventArgs)
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub PopupControlContainer2_BeforeCloseUp(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        Me.PopupControlContainer2.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer2_CloseUp1(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCategoria.SelectedItems.Count > 0 Then
                Me.txtCategoria.ValueMember = lstCategoria.SelectedValue
                txtCategoria.Text = lstCategoria.Text
                ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub ButtonCategoria_Click_1(sender As System.Object, e As System.EventArgs)
        Me.PopupControlContainer2.ParentControl = Me.txtCategoria
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick1(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        If lsvListadoItems.SelectedItems.Count > 0 Then
            With objInsumo.InvocarProductoID(CInt(lsvListadoItems.SelectedItems(0).SubItems(0).Text))
                dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
                                     .presentacion,
                                        tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                      .tipoExistencia, .cuenta, Nothing)
            End With
        End If
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoExistencia_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged1(sender As Object, e As System.EventArgs)
        If cboTipoExistencia.SelectedIndex > -1 Then
            If txtCategoria.Text.Trim.Length > 0 Then
                ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton4_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub dgvCompra_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    End Sub

    Private Sub Panel8_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel8.Paint

    End Sub

    Private Sub ButtonAdv2_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub btnVer_Click_1(sender As System.Object, e As System.EventArgs) Handles btnVer.Click
        dockingManager1.SetDockVisibility(Panel2, True)

    End Sub

    Private Sub ToolStripButton1_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If dgvCompra.Rows.Count > 0 Then
            If Not IsNothing(dgvCompra.CurrentRow) Then

                If dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    dgvCompra.Rows.RemoveAt(dgvCompra.CurrentCell.RowIndex)
                ElseIf dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvCompra.CurrentRow.Index
                    dgvCompra.CurrentCell = Nothing
                    Me.dgvCompra.Rows(pos).Visible = False
                End If
                If dgvCompra.Rows.Count > 0 Then
                    For Each i As DataGridViewRow In dgvCompra.Rows
                        If i.Cells(10).Visible = True Then
                            Dim a As Decimal
                            Dim g As Decimal
                            a += Math.Round(CDec(i.Cells(10).Value), 2)
                            lblTotalAdquisiones.Text = a.ToString("N2")
                            g += Math.Round(CDec(i.Cells(11).Value), 2)
                            lblTotalUS.Text = g.ToString("N2")
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub ButtonCategoria_Click_2(sender As System.Object, e As System.EventArgs) Handles ButtonCategoria.Click
        Me.PopupControlContainer2.ParentControl = Me.txtCategoria
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub ButtonAdv2_Click_2(sender As System.Object, e As System.EventArgs) Handles ButtonAdv2.Click
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv1_Click_2(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub cboTipoExistencia_Click_2(sender As System.Object, e As System.EventArgs) Handles cboTipoExistencia.Click

    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged2(sender As Object, e As System.EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        If cboTipoExistencia.SelectedIndex > -1 Then
            If txtCategoria.Text.Trim.Length > 0 Then
                ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
            End If
        End If
    End Sub

    Private Sub cboTipoExistencia_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboTipoExistencia.SelectedValueChanged
        
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick2(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        If lsvListadoItems.SelectedItems.Count > 0 Then
            With objInsumo.InvocarProductoID(CInt(lsvListadoItems.SelectedItems(0).SubItems(0).Text))
                '   If dgvCompra.Rows.Count > 0 Then
                'For Each i As DataGridViewRow In dgvCompra.Rows
                '    If i.Cells(2).Value() = .codigodetalle Then
                '        lblEstado.Text = "INGRESE OTRO DIFERENTE"
                '        'Exit Sub
                '    Else
                If dgvCompra.Rows.Count > 0 Then

                    If ExisteFila(.codigodetalle) = True Then
                        lblEstado.Text = "Producto ingresado!!"
                    Else

                        dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
                                     .presentacion,
                                        tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                     .tipoExistencia, .cuenta, Nothing)
                    End If
                Else
                    dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
                                  .presentacion,
                                     tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
                                   0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                  .tipoExistencia, .cuenta, Nothing)
                End If

            End With
        End If
        '        Next
        '    Else
        '    dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
        '                                 .presentacion,
        '                                    tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
        '                                  0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
        '                                  .tipoExistencia, .cuenta, Nothing)
        '    End If

        '  End If
    End Sub

    Function ExisteFila(intIdItem As Integer) As Boolean
        For Each i As DataGridViewRow In dgvCompra.Rows
            If i.Cells(2).Value = intIdItem Then
                lblEstado.Text = "El item ya se encuentra en la canasta!!"
                Return True
                Exit Function
            Else
                Return False
                Exit Function
            End If
        Next
        Return True
    End Function


    Private Sub lsvListadoItems_SelectedIndexChanged_2(sender As System.Object, e As System.EventArgs) Handles lsvListadoItems.SelectedIndexChanged

    End Sub

    Private Sub PopupControlContainer2_CloseUp_1(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCategoria.SelectedItems.Count > 0 Then
                Me.txtCategoria.ValueMember = lstCategoria.SelectedValue
                txtCategoria.Text = lstCategoria.Text
                ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub dgvCompra_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompra.CellContentClick

    End Sub

    Private Sub dgvCompra_CellEndEdit1(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompra.CellEndEdit
        If dgvCompra.Rows.Count > 0 Then
            'DECLARANDO VARIABLES
            Dim colDestinoGravado As Decimal = 0
            colDestinoGravado = dgvCompra.Item(1, dgvCompra.CurrentRow.Index).Value

            Dim colCantidad As Decimal = 0
            If Not CStr(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value).Trim.Length > 0 Then
                lblEstado.Text = "Ingrese una cantidad válida!"
                lblEstado.Image = My.Resources.warning2
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
                Exit Sub
            Else
                colCantidad = dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value
            End If

            Dim colBI As Decimal = 0
            Dim colBI_ME As Decimal = 0
            Dim colIGV_ME As Decimal = 0
            Dim colIGV As Decimal = 0
            Dim colMN As Decimal = 0

            If Not CStr(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value).Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un importe válido!"
                lblEstado.Image = My.Resources.warning2
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
                Exit Sub
            Else
                colMN = dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value
            End If

            Dim colME As Decimal = Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value) / CDec(txtTipoCambio.Value), 2)
            Dim colPrecUnit As Decimal = 0
            Dim colPrecUnitUSD As Decimal = 0


            If colCantidad > 0 AndAlso colMN > 0 Then

                colPrecUnit = Math.Round(colMN / colCantidad, 2)
                colPrecUnitUSD = Math.Round(colME / colCantidad, 2)

                colBI = Math.Round(colMN / 1.18, 2)
                colBI_ME = Math.Round(colME / 1.18, 2)
                colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)


            Else

                colPrecUnit = 0
                colPrecUnitUSD = 0
                colBI = 0
                colBI_ME = 0
                colIGV = 0
                colIGV_ME = 0
            End If
            Select Case TXTComprobante.ValueMember
                Case "08"
                    If dgvCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        totales_xx()
                    End If
                Case "03", "02"
                    If dgvCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvCompra.Columns(e.ColumnIndex).Name = "Can1" Or dgvCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        If txtTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            txtTipoCambio.Focus()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If

                        Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"
                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00"
                            Exit Sub

                        ElseIf colCantidad = 0 Then

                            If cboMoneda.SelectedValue = 1 Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)

                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    Case Else
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                End Select

                            ElseIf cboMoneda.SelectedValue = 2 Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES

                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    Case Else
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                End Select

                            End If
                        ElseIf colCantidad > 0 Then
                            If cboMoneda.SelectedValue = 1 Then
                                ' DATOS SOLES
                                If dgvCompra.Item(1, dgvCompra.CurrentRow.Index).Value = "4" Then
                                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2")
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") 'CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")

                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                Else
                                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") 'CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")


                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                End If

                            ElseIf cboMoneda.SelectedValue = 2 Then

                                Select Case colDestinoGravado
                                    Case "4"
                                        ' DATOS DOLARES

                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")


                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    Case Else
                                        ' DATOS DOLARES
                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")


                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(17, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                End Select

                            End If
                        End If
                        'totales()
                        'subTotales("All")
                        totales_xx()
                        TotalesCabeceras()
                    End If
                    If dgvCompra.Columns(e.ColumnIndex).Name = "ISC" Then
                        'totalesPorCaja("ISC")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "ISCus" Then
                        'totalesPorCaja("ISCUS")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "igv" Then
                        'totalesPorCaja("IGV")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "IGVus" Then
                        'totalesPorCaja("IGVUS")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "otrostributos" Then
                        'totalesPorCaja("OTC")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        'totalesPorCaja("OTCUS")
                        'subTotales("All")
                    ElseIf dgvCompra.Columns(e.ColumnIndex).Name = "kardex" Then
                        'totalesPorCaja("KARDEX")
                        'subTotales("All")
                    End If

                    If dgvCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                    End If
                    '**********************************************************************************************************************************************************************************
                    '**********************************************************************************************************************************************************************************
                    '**********************************************************************************************************************************************************************************
                Case Else
                    If dgvCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvCompra.Columns(e.ColumnIndex).Name = "Can1" Or dgvCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Or dgvCompra.Columns(e.ColumnIndex).Name = "Prec" Then 'Or dgvCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        If txtTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            txtTipoCambio.Focus()
                            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                            Exit Sub
                        End If

                        Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"
                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00"
                            Exit Sub

                        ElseIf colCantidad = 0 Then

                            If cboMoneda.SelectedValue = 1 Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                    Case Else

                                        If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                            dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                        Else
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2")  ' Math.Round(CDec(neto - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                            '        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                        End If
                                End Select


                            ElseIf cboMoneda.SelectedValue = 2 Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")

                                    Case Else

                                        If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") 'Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")

                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                            dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        Else
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")

                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(netous - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV


                                        End If
                                End Select

                            End If
                        ElseIf colCantidad > 0 Then
                            If cboMoneda.SelectedValue = 1 Then
                                ' DATOS SOLES
                                If colDestinoGravado = "4" Then
                                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")

                                Else
                                    If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") '  CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item

                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD


                                        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                    Else
                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(neto - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                        dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD




                                    End If

                                End If

                            ElseIf cboMoneda.SelectedValue = 2 Then

                                Select Case colDestinoGravado
                                    Case "4"
                                        ' DATOS DOLARES
                                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")


                                    Case Else
                                        ' DATOS DOLARES
                                        If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                            dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV

                                            dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        Else
                                            dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(netous - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                        End If

                                End Select

                            End If
                        End If

                        totales_xx()
                        TotalesCabeceras()
                    End If


            End Select
        End If
    End Sub

    Private Sub dgvCompra_CellValueChanged1(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompra.CellValueChanged
        If dgvCompra.Rows.Count > 0 Then
            Dim b As Decimal
            Dim c As Decimal
            Dim d As Decimal
            Dim h As Decimal
            Dim f As Decimal

            b = Math.Round(((dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value) * CDec(dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value)), 2)
            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = b.ToString("N2")
            c = Math.Round(CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value), 2)
            dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = c.ToString("N2")
            d = Math.Round(CDec(dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value), 2)
            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = d.ToString("N2")
            h = Math.Round(((dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value) * CDec(txtTipoCambio.Value)), 2)
            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = h.ToString("N2")
            f = Math.Round(((dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value) * CDec(dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value)), 2)
            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = f.ToString("N2")

            For Each i As DataGridViewRow In dgvCompra.Rows
                Dim a As Decimal
                Dim g As Decimal
                a += Math.Round(CDec(i.Cells(10).Value), 2)
                lblTotalAdquisiones.Text = a.ToString("N2")
                g += Math.Round(CDec(i.Cells(11).Value), 2)
                lblTotalUS.Text = g.ToString("N2")
            Next

        End If
    End Sub

    Private Sub dgvCompra_CurrentCellDirtyStateChanged1(sender As Object, e As System.EventArgs) Handles dgvCompra.CurrentCellDirtyStateChanged
        Try
            If dgvCompra.IsCurrentCellDirty Then
                dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
            If TypeOf dgvCompra.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        Catch
        End Try
    End Sub

    Private Sub dgvCompra_EditingControlShowing1(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCompra.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvCompra_KeyDown1(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvCompra.KeyDown
        Dim conteo As Integer = dgvCompra.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvCompra.CurrentCell.ColumnIndex)
                    Case 7
                        If cboMoneda.SelectedValue = 1 Then
                            If conteo = 1 Then
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(8, Me.dgvCompra.CurrentCell.RowIndex)
                            Else
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(8, Me.dgvCompra.CurrentCell.RowIndex)
                            End If
                        Else
                            If conteo = 1 Then
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            Else
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            End If
                        End If
                    Case 3
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(0, Me.dgvCompra.CurrentCell.RowIndex)
                    Case 10 Or 11
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(23, Me.dgvCompra.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dropDownBtn_Click(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        Me.popupControlContainer1.ParentControl = Me.txtProveedor
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub OK_Click_1(sender As System.Object, e As System.EventArgs) Handles OK.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cancel_Click_1(sender As System.Object, e As System.EventArgs) Handles cancel.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub popupControlContainer1_BeforePopup_1(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp_1(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtTelefono.Text = lsvProveedor.SelectedItems(0).SubItems(4).Text
                txtCorreo.Text = lsvProveedor.SelectedItems(0).SubItems(5).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtTipoCambio_ValueChanged_1(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub
End Class