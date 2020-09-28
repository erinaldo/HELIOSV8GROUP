Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmOrdenCompra
    Public Property Flag() As String
    Dim UserControl1 As New ucConfiguracion
    Dim toolTip As Popup
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public fecha As DateTime
    Public lblIdDocumento As Integer

    Public Sub New()
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
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dockingManager1.DockControl(Me.Panel2, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.MDIActivatedVisibility = True
        'dockingClientPanel1.BringToFront()
        'Me.dockingClientPanel1.AutoScroll = True
        'Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(Panel2, "Existencias")

        'INICIO PERIODO
        lblPerido.Text = PeriodoGeneral
        ControlsHide()
        SetRenderer()
        txtFechaComprobante.Select()
        dockingManager1.CloseEnabled = False
        txtTipoCambio.Value = TmpTipoCambio
        txtIgv.Value = TmpIGV
        txtFechaComprobante.Value = Date.Now
        dtpFechaVencimiento.Value = Date.Now
    End Sub

#Region "CATEGORIA"
    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _Utilidad As Decimal
        Private _UtilidadMayor As Decimal
        Private _UtilidadGranMayor As Decimal
        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal utilidad As Decimal, utiMayor As Decimal, utiGranMayor As Decimal)
            _name = name
            _id = id
            _Utilidad = utilidad
            _UtilidadMayor = utiMayor
            _UtilidadGranMayor = utiGranMayor
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property Utilidad() As Decimal
            Get
                Return _Utilidad
            End Get
            Set(ByVal value As Decimal)
                _Utilidad = value
            End Set
        End Property

        Public Property UtilidadMayor() As Decimal
            Get
                Return _UtilidadMayor
            End Get
            Set(ByVal value As Decimal)
                _UtilidadMayor = value
            End Set
        End Property

        Public Property UtilidadGranMayor() As Decimal
            Get
                Return _UtilidadGranMayor
            End Get
            Set(ByVal value As Decimal)
                _UtilidadGranMayor = value
            End Set
        End Property
    End Class

    Public Sub GrabarCategoria()
        Dim itemSA As New itemSA
        Dim item As New item
        Try
            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .descripcion = txtNewClasificacion.Text.Trim
                .fechaIngreso = DateTime.Now
                .utilidad = nupUtilidad.Value
                .utilidadmayor = nupUtilidadMayor.Value
                .utilidadgranmayor = nupUtilidadGranMayor.Value
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.SaveCategoria(item)
            lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, nupUtilidad.Value, nupUtilidadMayor.Value, nupUtilidadGranMayor.Value))
            Me.txtCategoria.ValueMember = CStr(codx)
            txtCategoria.Text = txtNewClasificacion.Text.Trim
            txtCategoria.Tag = nupUtilidad.Value
            ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, nupUtilidad.Value, nupUtilidadMayor.Value, nupUtilidadGranMayor.Value)
        Catch ex As Exception
            lblEstado.Text = (ex.Message)
        End Try
    End Sub

    Private Sub ListaMercaderiasXIdHijo(iditem As Integer, tipo As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXIdHijo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, iditem, tipo)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.origenProducto)
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub

    Private Sub ListadoProductosPorCategoriaTipoExistencia(strCategoria As Integer, strTipoExistencia As String, intUtilidad As Decimal, utiMayor As Decimal, utiGranMayor As Decimal)
        Dim itemSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        Try
            For Each i In itemSA.GetUbicarDetalleItemTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strCategoria, strTipoExistencia)
                Dim n As New ListViewItem(i.codigodetalle)
                n.SubItems.Add(i.descripcionItem)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(intUtilidad)
                n.SubItems.Add(utiMayor)
                n.SubItems.Add(utiGranMayor)
                n.SubItems.Add(i.cuenta)
                lsvListadoItems.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
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

#End Region

#Region "Manipulación Data"

    Private Sub ObtenerCuentasFinancierasPorMoneda(strIdMoneda As String)
        Dim cFinancieraSA As New EstadosFinancierosSA
        gridGroupingControl1.DataSource = cFinancieraSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, strIdMoneda)
        gridGroupingControl1.TableDescriptor.GroupedColumns.Add("tipo")
    End Sub

    Public Sub ObtenerListaControlesLoad()
        Dim tablaSA As New tablaDetalleSA
        Dim categoriaSA As New itemSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0

        'TIPO DE EXISTENCIA
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        Dim dtUM As New DataTable
        dtUM.Columns.Add("ID")
        dtUM.Columns.Add("Name")

        cboModalidad.DisplayMember = "descripcion"
        cboModalidad.ValueMember = "codigoDetalle"
        cboModalidad.DataSource = tablaSA.GetListaTablaDetalle(1, "1")
        cboModalidad.SelectedValue = -1

        CboPago.DisplayMember = "descripcion"
        CboPago.ValueMember = "codigoDetalle"
        CboPago.DataSource = tablaSA.GetListaTablaDetalle(501, "1")
        CboPago.SelectedValue = -1

        Dim dtPresentacion As New DataTable
        dtPresentacion.Columns.Add("IDPres")
        dtPresentacion.Columns.Add("NamePres")

        For Each i In categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
            lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
        Next
        lstCategoria.DisplayMember = "Name"
        lstCategoria.ValueMember = "Id"

        ObtenerCuentasFinancierasPorMoneda("1")

        txtComprobante.Text = "ORDEN DE COMPRA"
        txtComprobante.ValueMember = "02"

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
    '                    End With
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
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

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.Utilidad)
            n.SubItems.Add(i.UtilidadMayor)
            n.SubItems.Add(i.UtilidadGranMayor)
            n.SubItems.Add(i.cuenta)
            lsvListadoItems.Items.Add(n)
        Next
    End Sub

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
            .idDocumento = CInt(lblIdDocumento),
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
            .unidad1 = dgvCompra.Item(6, i).Value.ToString,
            .situacion = TIPO_SITUACION.ORDEN_COMPRA_TRANSITO,
            .Glosa = GlosaCompra(),
            .FlagModificaPrecioVenta = dgvCompra.Item(35, i).Value.ToString}

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
            .idDocumento = CInt(lblIdDocumento),
            .fechaDoc = txtFechaComprobante.Value,
            .idProveedor = txtProveedor.ValueMember,
            .monedaDoc = cboMoneda.SelectedValue,
            .tcDolLoc = CDec(txtTipoCambio.Value),
            .importeTotal = txtTotalmn.Text,
            .importeUS = txtTotalme.Text,
            .situacion = TIPO_SITUACION.ORDEN_COMPRA_TRANSITO}
            If (nRecursoSA.UpdateDoc(nRecurso)) Then
                'UpdateOtros()
                lblEstado.Text = " editado!"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Next
    End Sub

    'Sub UpdateOtros()
    '    Dim nRecursoSA As New DocumentoOtrosDatosSA
    '    Dim nRecurso As New documentoOtrosDatos
    '    For i = 0 To dgvCompra.Rows.Count - 1
    '        nRecurso = New documentoOtrosDatos With {
    '        .idDocumento = CInt(lblIdDocumento.Text),
    '        .fechaInicio = txtFechaInicioPlazo.Value,
    '        .fechaFin = txtFechaFinPlazo.Value,
    '        .FechaIniGarantia = txtFechaInicioGarantia.Value,
    '        .FechaFinGarantia = txtFechaFinGarantia.Value,
    '        .notas = txtNotas.Text,
    '        .indicaciones = txtIndicaciones.Text,
    '        .condicionPago = CboPago.SelectedValue,
    '         .CentroCostos = CInt("1"),
    '        .idAlmacen = cboAlmacen.SelectedValue,
    '        .Vcto = dtpFechaVencimiento.Value,
    '        .Modalidad = cboModalidad.SelectedValue,
    '        .ctaDeposito = txtcto.Text,
    '        .institucionFinanciera = txtCajaOrigen.ValueMember,
    '        .estado = "P",
    '        .usuarioActualizacion = "Jiuni",
    '        .fechaActualizacion = DateTime.Now}
    '        If (nRecursoSA.UpdateOtros(nRecurso)) Then
    '            lblEstado.Text = " editado!"
    '            lblEstado.Image = My.Resources.ok4
    '        Else
    '            lblEstado.Text = "Error al grabar Cadena!"
    '            lblEstado.Image = My.Resources.cross
    '        End If
    '    Next
    'End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.ValueMember = .idEntidad
                txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtProveedor.Clear()
            txtProveedor.Clear()
            txtCuenta.Clear()
            txtRuc.Clear()
        End If
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
            '.tipoDoc = "00"
            .tipoDoc = txtComprobante.ValueMember
            .fechaProceso = txtFechaComprobante.Value
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With
        With nDocumentoCompra
            .codigoLibro = "1"
            .serie = txtSerie.Text
            .numeroDoc = txtNumero.Text
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
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
            .importeTotal = txtTotalmn.Text 'MARTIN
            .importeUS = txtTotalme.Text 'MARTIN
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.ORDEN_COMPRA  'MARTIN
            .estadoPago = "P"
            .situacion = TIPO_SITUACION.ORDEN_COMPRA_TRANSITO
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        With objDocOtros
            '.Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idAlmacen = Nothing
            .fechaInicio = Nothing
            .fechaFin = Nothing
            .FechaIniGarantia = Nothing
            .FechaFinGarantia = Nothing
            .notas = Nothing
            .indicaciones = Nothing
            .idItem = Nothing
            .cantidad = Nothing
            .idReferencia = Nothing
            .condicionPago = CboPago.SelectedValue
            .Vcto = CStr(dtpFechaVencimiento.Value).ToString
            .Modalidad = cboModalidad.SelectedValue
            .ctaDeposito = txtcto.Text
            .institucionFinanciera = txtCajaOrigen.ValueMember
            .estado = "P"
            .moneda = CInt(cboMoneda.SelectedValue)
            .CentroCostos = GEstableciento.IdEstablecimiento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now

        End With
        'ndocumento.documentocompra.documentoOtrosDatos = objDocOtros

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
            objDocumentoCompraDet.destino = i.Cells(1).Value()

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
            objDocumentoCompraDet.Glosa = GlosaCompra()
            objDocumentoCompraDet.situacion = TIPO_COMPRA.ORDEN_COMPRA
            objDocumentoCompraDet.porcUtimenor = CDec(i.Cells(32).Value())
            objDocumentoCompraDet.porcUtimayor = CDec(i.Cells(33).Value())
            objDocumentoCompraDet.porcUtigranMayor = CDec(i.Cells(34).Value())
            objDocumentoCompraDet.FlagModificaPrecioVenta = Nothing
            ListaDetalle.Add(objDocumentoCompraDet)
        Next
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        CompraSA.GrabarOrdenes(ndocumento, objDocOtros)

    End Sub


    Public Sub UbicarDocumentos(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim docOtros As New DocumentoOtrosDatosSA
        Dim entidadSA As New entidadSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA
        Dim cFinancieraSA As New EstadosFinancierosSA
        Try
            With documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)

                With entidadSA.UbicarEntidadPorID(.idProveedor).First
                    txtProveedor.Text = .nombreCompleto
                    txtProveedor.ValueMember = .idEntidad
                    txtRuc.Text = .nrodoc
                    txtCuenta.Text = .cuentaAsiento
                End With

                With docOtros.UbicarDocumentoOtros(intIdDocumento)
                    If (Not IsNothing(.condicionPago)) Then
                        CboPago.Text = tablaDetalleSA.GetUbicarTablaID(501, .condicionPago).descripcion
                    End If

                    If (Not IsNothing(.Vcto)) Then
                        dtpFechaVencimiento.Value = CDate(.Vcto).Date
                    End If

                    If (Not IsNothing(.Modalidad)) Then
                        cboModalidad.Text = tablaDetalleSA.GetUbicarTablaID(1, .Modalidad).descripcion
                    End If
                    txtcto.Text = .ctaDeposito

                    If ((.institucionFinanciera).Length > 0) Then
                        With cFinancieraSA.ObtenerEstadosFinancierosPorCodigo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, .institucionFinanciera)
                            txtCajaOrigen.ValueMember = .idestado
                            txtCajaOrigen.Text = .descripcion
                        End With
                    End If

                    'If (Not IsNothing(.idAlmacen)) Then
                    '    cboAlmacen.Text = almacenSA.GetUbicar_almacenPorID(.idAlmacen).descripcionAlmacen
                    'End If

                End With

                If (.monedaDoc = "1") Then
                    cboMoneda.DisplayMember = "NACIONAL"
                    cboMoneda.SelectedValue = CInt(1)
                    'CboMonedaPago.DisplayMember = "NACIONAL"
                    'CboMonedaPago.SelectedValue = CInt(1)
                ElseIf (.monedaDoc = "2") Then
                    cboMoneda.DisplayMember = "EXTRANJERA"
                    cboMoneda.SelectedValue = CInt(2)
                    'CboMonedaPago.DisplayMember = "EXTRANJERA"
                    'CboMonedaPago.SelectedValue = CInt(2)
                End If
                txtFechaComprobante.Value = .fechaDoc
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
            End With
            dgvCompra.Rows.Clear()
            For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(intIdDocumento)
                dgvCompra.Rows.Add(i.secuencia, "1", i.idItem, i.descripcionItem, "1", "1", i.unidad1, i.monto1, i.precioUnitario, i.precioUnitarioUS, i.importe, i.importeUS,
                                       i.montokardex, i.montoIsc, i.montoIgv, i.otrosTributos, i.montokardexUS, i.montoIscUS, i.montoIgvUS, i.otrosTributosUS, Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia, "1")
            Next

            totales_xx()
            TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "Metodos"

    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)




        Dim Celda As DataGridViewCell = Me.dgvCompra.CurrentCell()

        If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 8 Or Celda.ColumnIndex = 11 Then

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
            colPU = Math.Round(CDec(i.Cells(9).Value) / colCantidad, 2)
            colPU_ME = Math.Round(colME / colCantidad, 2)
            If colCantidad > 0 Then

                If i.Cells(27).Value = "S" Then
                    totalbase4 += CDec(i.Cells(8).Value())
                    tus4 += CDec(i.Cells(11).Value()) ' total base 01
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

        totales_xx()
        TotalesCabeceras()

    End Sub

    Private Sub MyMethodOnCheckBoxes()

        'DO WHAT EVER WHEN THE SELECTED CHECKBOX IS CHECKED
        If CheckBoxClicked Then
            'DO WHAT DO YOU WANT TO, WHEN CHECKBOX IS NOT CHECKED!!
            Bonificacion()
            dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "S"

        ElseIf Not CheckBoxClicked Then

            '  CellEndEditRefresh()
            dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "N"
            totales_xx()
            TotalesCabeceras()
        End If
    End Sub

    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        'tbIGV.Renderer = styleRenderer1
    End Sub

    Sub ControlsHide()
        rbDetraccion.Visible = False
        rbRetencion.Visible = False
        rbPercepcion.Visible = False
        nudPorcentajeTributo.Visible = False
        '  Label22.Visible = False
        nudImporteMN.Visible = False
        nudImporteMe.Visible = False
    End Sub

    Private Function GlosaCompra() As String
        If Not String.IsNullOrEmpty(txtSerie.Text) And Not String.IsNullOrEmpty(txtNumero.Text) And _
        Not String.IsNullOrEmpty(txtProveedor.Text) Then
            Return String.Concat("Por compras", Space(1), "según/ ", Space(1), txtComprobante.Text, Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, ", de Fecha:", Space(1), txtFechaComprobante.Text, Space(1))
        Else
            Return False
        End If
    End Function

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
                If i.Cells(27).Value() <> "S" Then
                    cTotalMN += CDec(i.Cells(10).Value)
                    cTotalME += CDec(i.Cells(13).Value)

                    cTotalBI += CDec(i.Cells(8).Value)
                    cTotalBI_ME += CDec(i.Cells(11).Value)

                    cTotalIGV += CDec(i.Cells(15).Value)
                    cTotalIGV_ME += CDec(i.Cells(18).Value)

                    'cTotalIsc += CDec(i.Cells(13).Value)
                    'cTotalIsc_ME += CDec(i.Cells(17).Value)

                    'cTotalOTC += CDec(i.Cells(15).Value)
                    'cTotalOTC_ME += CDec(i.Cells(19).Value)
                End If
            End If
        Next

        txtTotalBImn.Text = cTotalBI.ToString("N2")
        txtTotalBIme.Text = cTotalBI_ME.ToString("N2")

        'lblTotalISc.Text = cTotalIsc.ToString("N2")
        'lblTotalIScUS.Text = cTotalIsc_ME.ToString("N2")

        txtMontoIGVmn.Text = cTotalIGV.ToString("N2")
        txtMontoIGVme.Text = cTotalIGV_ME.ToString("N2")

        'lblOtrostribTotal.Text = cTotalOTC.ToString("N2")
        'lblOtrostribTotalUS.Text = cTotalOTC_ME.ToString("N2")

        Select Case txtComprobante.ValueMember
            Case "02", "03"
                txtTotalmn.Text = cTotalMN   'cTotalMN.ToString("N2")
                txtTotalme.Text = cTotalME   'cTotalME.ToString("N2")
            Case "08"
                'Instrucciones
            Case Else

                txtTotalmn.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
                txtTotalme.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
        End Select

        'Dim cTotalMN As Decimal = 0
        'Dim cTotalME As Decimal = 0

        'Dim cTotalBI As Decimal = 0
        'Dim cTotalBI_ME As Decimal = 0

        'Dim cTotalIGV As Decimal = 0
        'Dim cTotalIGV_ME As Decimal = 0

        'Dim cTotalIsc As Decimal = 0
        'Dim cTotalIsc_ME As Decimal = 0

        'Dim cTotalOTC As Decimal = 0
        'Dim cTotalOTC_ME As Decimal = 0

        'For Each i As DataGridViewRow In dgvCompra.Rows
        '    If i.Cells(20).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
        '        cTotalMN += CDec(i.Cells(10).Value)
        '        cTotalME += CDec(i.Cells(11).Value)

        '        cTotalBI += CDec(i.Cells(12).Value)
        '        cTotalBI_ME += CDec(i.Cells(16).Value)

        '        cTotalIGV += CDec(i.Cells(14).Value)
        '        cTotalIGV_ME += CDec(i.Cells(18).Value)

        '        cTotalIsc += CDec(i.Cells(13).Value)
        '        cTotalIsc_ME += CDec(i.Cells(17).Value)

        '        cTotalOTC += CDec(i.Cells(15).Value)
        '        cTotalOTC_ME += CDec(i.Cells(19).Value)
        '    End If
        'Next

        'lblTotalBase.Text = cTotalBI.ToString("N2")
        'lblTotalBaseUS.Text = cTotalBI_ME.ToString("N2")

        'lblTotalISc.Text = cTotalIsc.ToString("N2")
        'lblTotalIScUS.Text = cTotalIsc_ME.ToString("N2")

        'lblTotalMontoIgv.Text = cTotalIGV.ToString("N2")
        'lblTotalMontoIgvUS.Text = cTotalIGV_ME.ToString("N2")

        'lblOtrostribTotal.Text = cTotalOTC.ToString("N2")
        'lblOtrostribTotalUS.Text = cTotalOTC_ME.ToString("N2")

        'Select Case cboTipoDoc.SelectedValue
        '    Case "02", "03"
        '        lblTotalAdquisiones.Text = cTotalMN   'cTotalMN.ToString("N2")
        '        lblTotalUS.Text = cTotalME   'cTotalME.ToString("N2")
        '    Case "08"
        '        'Instrucciones
        '    Case Else

        '        lblTotalAdquisiones.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
        '        lblTotalUS.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
        'End Select

    End Sub

    Public Sub totales_xx()

        '     Dim objService = HeliosSEProxy.CrearProxyHELIOS
        ' Dim t As DataTable
        Dim i As Integer
        'Dim base1, base2 As Decimal
        'Dim baseus1, baseus2 As Decimal
        'Dim otc1, otc2 As Decimal ', otc3, otc4
        'Dim otc1US, otc2US As Decimal ', otc3US, otc4US
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

                        total += dgvCompra.Rows(i).Cells(8).Value() ' total base 01 soles
                        tus1 += dgvCompra.Rows(i).Cells(11).Value() ' total base 01 dolares
                        totalIgv1 += dgvCompra.Rows(i).Cells(15).Value()
                        totalIgv1_ME += dgvCompra.Rows(i).Cells(18).Value()

                    ElseIf dgvCompra.Rows(i).Cells(1).Value() = "2" Then

                        totalbase2 += dgvCompra.Rows(i).Cells(8).Value()
                        tus2 += dgvCompra.Rows(i).Cells(11).Value() ' total base 01
                        totalIgv2 += dgvCompra.Rows(i).Cells(15).Value()
                        totalIgv2_ME += dgvCompra.Rows(i).Cells(18).Value()

                    ElseIf dgvCompra.Rows(i).Cells(1).Value() = "3" Then
                        totalBI3 += dgvCompra.Rows(i).Cells(8).Value()
                        totalBI3_ME += dgvCompra.Rows(i).Cells(11).Value() ' total base 01
                        totalIgv3 += dgvCompra.Rows(i).Cells(15).Value()
                        totalIgv3_ME += dgvCompra.Rows(i).Cells(18).Value()

                    ElseIf dgvCompra.Rows(i).Cells(1).Value() = "4" Then
                        totalBI4 += dgvCompra.Rows(i).Cells(8).Value()
                        totalBI4_ME += dgvCompra.Rows(i).Cells(11).Value() ' total base 01
                        totalIgv4 += dgvCompra.Rows(i).Cells(15).Value()
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

        ''     Dim objService = HeliosSEProxy.CrearProxyHELIOS
        '' Dim t As DataTable
        'Dim i As Integer
        ''Dim base1, base2 As Decimal
        ''Dim baseus1, baseus2 As Decimal
        ''Dim otc1, otc2 As Decimal ', otc3, otc4
        ''Dim otc1US, otc2US As Decimal ', otc3US, otc4US
        'Dim total, totalbase2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
        'Dim tus1, tus2 As Decimal 'tus3, tus4 
        'Dim totalIgv1 As Decimal = 0
        'Dim totalIgv1_ME As Decimal = 0
        'Dim totalIgv2 As Decimal = 0
        'Dim totalIgv2_ME As Decimal = 0
        'Dim totalIgv3 As Decimal = 0
        'Dim totalIgv3_ME As Decimal = 0
        'Dim totalIgv4 As Decimal = 0
        'Dim totalIgv4_ME As Decimal = 0



        'Dim totalBI3 As Decimal = 0
        'Dim totalBI3_ME As Decimal = 0
        'Dim totalBI4 As Decimal = 0
        'Dim totalBI4_ME As Decimal = 0


        'Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
        'For i = 0 To dgvCompra.Rows.Count - 1
        '    If dgvCompra.Rows(i).Cells(20).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
        '        'total += carrito.Rows(i)(5)
        '        If Not dgvCompra.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
        '            If dgvCompra.Rows(i).Cells(1).Value() = "1" Then

        '                total += dgvCompra.Rows(i).Cells(12).Value() ' total base 01 soles
        '                tus1 += dgvCompra.Rows(i).Cells(16).Value() ' total base 01 dolares
        '                totalIgv1 += dgvCompra.Rows(i).Cells(14).Value()
        '                totalIgv1_ME += dgvCompra.Rows(i).Cells(18).Value()

        '            ElseIf dgvCompra.Rows(i).Cells(1).Value() = "2" Then

        '                totalbase2 += dgvCompra.Rows(i).Cells(12).Value()
        '                tus2 += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
        '                totalIgv2 += dgvCompra.Rows(i).Cells(14).Value()
        '                totalIgv2_ME += dgvCompra.Rows(i).Cells(18).Value()

        '            ElseIf dgvCompra.Rows(i).Cells(1).Value() = "3" Then
        '                totalBI3 += dgvCompra.Rows(i).Cells(12).Value()
        '                totalBI3_ME += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
        '                totalIgv3 += dgvCompra.Rows(i).Cells(14).Value()
        '                totalIgv3_ME += dgvCompra.Rows(i).Cells(18).Value()

        '            ElseIf dgvCompra.Rows(i).Cells(1).Value() = "4" Then
        '                totalBI4 += dgvCompra.Rows(i).Cells(12).Value()
        '                totalBI4_ME += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
        '                totalIgv4 += dgvCompra.Rows(i).Cells(14).Value()
        '                totalIgv4_ME += dgvCompra.Rows(i).Cells(18).Value()
        '            End If
        '        End If
        '    End If

        'Next
        'nudBase1 = total.ToString("N2")
        'nudBaseus1 = tus1.ToString("N2")
        'nudBase2 = totalbase2.ToString("N2")
        'nudBaseus2 = tus2.ToString("N2")

        'nudBase3 = totalBI3.ToString("N2")
        'nudBaseus3 = totalBI3_ME.ToString("N2")
        'nudBase4 = totalBI4.ToString("N2")
        'nudBaseus4 = totalBI4_ME.ToString("N2")

        'nudMontoIgv1 = totalIgv1.ToString("N2")
        'nudMontoIgvus1 = totalIgv1_ME.ToString("N2")
        'nudMontoIgv2 = totalIgv2.ToString("N2")
        'nudMontoIgvus2 = totalIgv2_ME.ToString("N2")

        'nudMontoIgv3 = totalIgv3.ToString("N2")
        'nudMontoIgvus3 = totalIgv3_ME.ToString("N2")
        'nudMontoIgv3 = totalIgv3.ToString("N2")
        'nudMontoIgvus3 = totalIgv3_ME.ToString("N2")



    End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************

        If dgvCompra.Rows.Count > 0 Then
            'DECLARANDO VARIABLES

            For Each i As DataGridViewRow In dgvCompra.Rows
                Dim colDestinoGravado As Decimal = 0
                colDestinoGravado = i.Cells(1).Value

                Dim colCantidad As Decimal = 0
                Select Case i.Cells(21).Value
                    Case "GS"
                        colCantidad = 1
                        i.Cells(7).Value = 1
                    Case Else
                        If Not CStr(i.Cells(7).Value).Trim.Length > 0 Then
                            lblEstado.Text = "Ingrese una cantidad válida!"
                            lblEstado.Image = My.Resources.warning2
                            'Timer1.Enabled = True
                            'TiempoEjecutar(5)
                            Exit Sub
                        Else
                            colCantidad = i.Cells(7).Value
                            i.Cells(7).Value = colCantidad.ToString("N2")
                        End If
                End Select


                Dim colBI As Decimal = 0
                Dim colBI_ME As Decimal = 0
                Dim colIGV_ME As Decimal = 0
                Dim colIGV As Decimal = 0
                Dim colMN As Decimal = 0

                If Not CStr(i.Cells(8).Value).Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el valor de compra!"
                    lblEstado.Image = My.Resources.warning2
                    'Timer1.Enabled = True
                    'TiempoEjecutar(5)
                    Exit Sub
                Else
                    colMN = i.Cells(8).Value
                End If

                Dim colME As Decimal = Math.Round(CDec(i.Cells(8).Value) / CDec(txtTipoCambio.Value), 2)
                Dim colPrecUnit As Decimal = 0
                Dim colPrecUnitUSD As Decimal = 0

                If colCantidad > 0 AndAlso colMN > 0 Then

                    'colIGV = Math.Round(colMN * 0.18, 2) 'Math.Round((colMN / 1.18) * 0.18, 2)
                    colIGV = Math.Round(colMN * (txtIgv.Value / 100), 2)
                    'colIGV_ME = Math.Round(colME * 0.18, 2) ' Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)
                    colIGV_ME = Math.Round(colME * (txtIgv.Value / 100), 2)


                    colBI = colMN + colIGV
                    colBI_ME = colME + colIGV_ME

                    colPrecUnit = Math.Round(colMN / colCantidad, 2)
                    colPrecUnitUSD = Math.Round(colME / colCantidad, 2)
                    i.Cells(7).Value() = colCantidad.ToString("N2")
                ElseIf colCantidad = 0 Then
                    'colIGV = Math.Round(colMN * 0.18, 2) 'Math.Round((colMN / 1.18) * 0.18, 2)
                    colIGV = Math.Round(colMN * (txtIgv.Value / 100), 2)
                    'colIGV_ME = Math.Round(colME * 0.18, 2) ' Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)
                    colIGV_ME = Math.Round(colME * (txtIgv.Value / 100), 2)


                    colBI = colMN + colIGV
                    colBI_ME = colME + colIGV_ME

                    colPrecUnit = 0
                    colPrecUnitUSD = 0
                Else
                    colPrecUnit = 0

                    colPrecUnitUSD = 0

                    colBI = 0
                    colBI_ME = 0
                    colIGV = 0
                    colIGV_ME = 0
                End If

                Select Case txtComprobante.ValueMember
                    Case "08"

                    Case "03", "02"
                        i.Cells(8).Value() = colMN.ToString("N2")
                        i.Cells(11).Value() = colME.ToString("N2")
                        i.Cells(9).Value() = colPrecUnit.ToString("N2")
                        i.Cells(12).Value() = colPrecUnitUSD.ToString("N2")
                        i.Cells(10).Value() = colMN.ToString("N2")
                        i.Cells(13).Value() = colME.ToString("N2")
                        i.Cells(15).Value() = 0
                        i.Cells(18).Value() = 0
                    Case Else
                        If cboMoneda.SelectedValue = 1 Then
                            ' DATOS SOLES

                            Select Case colDestinoGravado
                                Case "2", "3", "4"
                                    i.Cells(8).Value() = colMN.ToString("N2")
                                    i.Cells(11).Value() = colME.ToString("N2")
                                    i.Cells(9).Value() = colPrecUnit.ToString("N2")
                                    i.Cells(12).Value() = colPrecUnitUSD.ToString("N2")
                                    i.Cells(10).Value() = colMN.ToString("N2")
                                    i.Cells(13).Value() = colME.ToString("N2")
                                    i.Cells(15).Value() = 0
                                    i.Cells(18).Value() = 0
                                Case Else
                                    If i.Cells(27).Value() = "S" Then ' BOnIFICACIOn
                                        i.Cells(8).Value() = colMN.ToString("N2")
                                        i.Cells(11).Value() = colME.ToString("N2")
                                        i.Cells(9).Value() = colPrecUnit.ToString("N2")
                                        i.Cells(12).Value() = colPrecUnitUSD.ToString("N2")
                                        i.Cells(10).Value() = colMN.ToString("N2")
                                        i.Cells(13).Value() = colME.ToString("N2")
                                        i.Cells(15).Value() = 0
                                        i.Cells(18).Value() = 0
                                    Else
                                        If colCantidad > 0 Then
                                            i.Cells(8).Value() = colMN.ToString("N2")
                                            i.Cells(11).Value() = colME.ToString("N2")
                                            i.Cells(9).Value() = colPrecUnit.ToString("N2")
                                            i.Cells(12).Value() = colPrecUnitUSD.ToString("N2")
                                            i.Cells(10).Value() = colBI.ToString("N2")
                                            i.Cells(13).Value() = colBI_ME.ToString("N2")
                                            i.Cells(15).Value() = colIGV.ToString("N2")
                                            i.Cells(18).Value() = colIGV_ME.ToString("N2")
                                        Else
                                            i.Cells(8).Value() = colMN.ToString("N2")
                                            i.Cells(11).Value() = colME.ToString("N2")
                                            i.Cells(9).Value() = colPrecUnit.ToString("N2")
                                            i.Cells(12).Value() = colPrecUnitUSD.ToString("N2")
                                            i.Cells(10).Value() = colMN.ToString("N2")
                                            i.Cells(13).Value() = colME.ToString("N2")
                                            i.Cells(15).Value() = colIGV.ToString("N2")
                                            i.Cells(18).Value() = colIGV_ME.ToString("N2")
                                        End If

                                    End If
                            End Select

                        ElseIf cboMoneda.SelectedValue = 2 Then

                            Select Case colDestinoGravado
                                Case "4"

                                Case Else
                                    ' DATOS DOLARES
                                    If i.Cells(27).Value() = "S" Then

                                    Else

                                    End If

                            End Select

                        End If

                End Select
            Next

        End If
        totales_xx()
        TotalesCabeceras()


    End Sub
#End Region


    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"
                lblEstado.Image = My.Resources.warning2
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"
                lblEstado.Image = My.Resources.ok4
            End If

            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"
                lblEstado.Image = My.Resources.warning2
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"
                lblEstado.Image = My.Resources.ok4
            End If

            If Not IsNothing(GConfiguracion.NomModulo) Then
                Select Case GConfiguracion.TipoConfiguracion
                    Case "M"
                        If Not txtNumero.Text.Trim.Length > 0 Then
                            lblEstado.Text = "Ingresar un número de comprobante válido"
                            lblEstado.Image = My.Resources.warning2
                            'Timer1.Enabled = True
                            'TiempoEjecutar(5)
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        Else
                            lblEstado.Text = "Done número comprobante"
                            lblEstado.Image = My.Resources.ok4
                        End If
                    Case "P"

                End Select
            End If

            '***********************************************************************
            If dgvCompra.Rows.Count > 0 Then
                Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                Me.lblEstado.Text = "Done!"
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    GrabarSolicitud()
                    Dispose()
                Else
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
            ListaAsientonTransito = New List(Of asiento)
            '  Dispose()
            'Timer1.Enabled = True
            'TiempoEjecutar(5)
        End Try
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            'If Not txtSerie.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingresar un número de serie válido"
            '    lblEstado.Image = My.Resources.warning2
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'Else
            '    lblEstado.Text = "Done serie"
            '    lblEstado.Image = My.Resources.ok4
            'End If

            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"
                lblEstado.Image = My.Resources.warning2
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"
                lblEstado.Image = My.Resources.ok4
            End If

            If Not IsNothing(GConfiguracion.NomModulo) Then
                Select Case GConfiguracion.TipoConfiguracion
                    Case "M"
                        If Not txtNumero.Text.Trim.Length > 0 Then
                            lblEstado.Text = "Ingresar un número de comprobante válido"
                            lblEstado.Image = My.Resources.warning2
                            'Timer1.Enabled = True
                            'TiempoEjecutar(5)
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        Else
                            lblEstado.Text = "Done número comprobante"
                            lblEstado.Image = My.Resources.ok4
                        End If
                    Case "P"

                End Select
            End If

            '***********************************************************************
            If dgvCompra.Rows.Count > 0 Then
                Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                Me.lblEstado.Text = "Done!"
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    GrabarSolicitud()
                    Dispose()
                Else
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
            ListaAsientonTransito = New List(Of asiento)
            '  Dispose()
            'Timer1.Enabled = True
            'TiempoEjecutar(5)
        End Try
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        txtDocProveedor.Clear()
        txtNomProv.Clear()
        txtApePat.Clear()
        pcProveedor.Font = New Font("Tahoma", 8)
        pcProveedor.Size = New Size(321, 248)
        Me.pcProveedor.ParentControl = Me.txtProveedor
        Me.pcProveedor.ShowPopup(Point.Empty)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown
        Dim categoriaSA As New itemSA
        If e.KeyCode = Keys.Down Then
            If Not Me.PopupControlContainer2.IsShowing() Then
                ' Let the popup align around the source textBox.
                Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
                Me.PopupControlContainer2.Size = New Size(238, 110)
                Me.PopupControlContainer2.ParentControl = Me.txtCategoria
                Me.PopupControlContainer2.ShowPopup(Point.Empty)

                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer2.IsShowing() Then
                Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCategoria.Text.Trim.Length > 0 Then
                lstCategoria.Items.Clear()
                For Each i In categoriaSA.GetListaItemPorEstableLike(GEstableciento.IdEstablecimiento, txtCategoria.Text.Trim)
                    lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
                Next
                lstCategoria.DisplayMember = "Name"
                lstCategoria.ValueMember = "Id"
                Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
                Me.PopupControlContainer2.Size = New Size(238, 110)
                Me.PopupControlContainer2.ParentControl = Me.txtCategoria
                Me.PopupControlContainer2.ShowPopup(Point.Empty)
            End If
        End If
    End Sub

    Private Sub ButtonCategoria_Click(sender As Object, e As EventArgs) Handles ButtonCategoria.Click
        Me.PopupControlContainer2.Font = New Font("Tahoma", 8)
        Me.PopupControlContainer2.Size = New Size(238, 110)
        Me.PopupControlContainer2.ParentControl = Me.txtCategoria
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor
        pcClasificacion.Font = New Font("Tahoma", 8)
        pcClasificacion.Size = New Size(337, 150)
        Me.pcClasificacion.ParentControl = Me.txtCategoria
        Me.pcClasificacion.ShowPopup(Point.Empty)
        txtNewClasificacion.Clear()
        txtNewClasificacion.Select()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        If cboTipoExistencia.SelectedIndex > -1 Then
            If txtCategoria.Text.Trim.Length > 0 Then
                ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListaMercaderias(cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnNuevoProd_Click(sender As Object, e As EventArgs) Handles btnNuevoProd.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCategoria.Text.Trim.Length > 0 Then
            'PanelNuevoItem.Visible = True
            'dockingManager1.SetDockVisibility(PanelNuevoItem, True)
            'Me.dockingManager1.DockControl(Me.PanelNuevoItem, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 335)
            'dockingManager1.SetDockLabel(PanelNuevoItem, "Nuevo producto")
            'dockingManager1.SetDockVisibility(Panel2, False)
            'txtcodCategoria.Text = txtCategoria.Text
            'txtcodCategoria.ValueMember = txtCategoria.ValueMember
            'txtTipoExistencia.Text = cboTipoExistencia.Text
            'txtTipoExistencia.ValueMember = cboTipoExistencia.SelectedValue
            'txtProductoNew.Clear()
            'txtProductoNew.Select()
            'Me.Cursor = Cursors.Arrow
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
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


    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.txtProveedor
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.popupControlContainer1.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.txtProveedor
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        pcAlmacen.Font = New Font("Segoe UI", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtCajaOrigen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
                Me.txtCajaOrigen.ValueMember = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idestado")
                Me.txtCajaOrigen.Text = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion")
                Me.txtcto.Text = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("nroCtaCorriente")
            End If
        End If
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCajaOrigen.Focus()
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick
        If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
            Me.pcAlmacen.HidePopup(PopupCloseType.Done)
        Else
            pcAlmacen.Font = New Font("Tahoma", 8)
            pcAlmacen.Size = New Size(400, 370)
            Me.pcAlmacen.ParentControl = Me.txtCajaOrigen
            Me.pcAlmacen.ShowPopup(Point.Empty)
        End If
    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub dgvCompra_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellClick
        If Not dgvCompra.Item(21, dgvCompra.CurrentRow.Index).Value = "GS" Then
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            If e.ColumnIndex = 31 Then
                'Se ha pulsado sobre un botón
                If e.RowIndex > -1 Then
                    With frmModalAlmacen
                        Tag = 0
                        .ObtenerAlmacenes(GEstableciento.IdEstablecimiento)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        If datos.Count > 0 Then
                            dgvCompra.Item(30, dgvCompra.CurrentRow.Index).Value = datos(0).ID
                            dgvCompra.Item(31, dgvCompra.CurrentRow.Index).Value = datos(0).NombreEntidad
                        End If
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub dgvCompra_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellEndEdit
        If dgvCompra.Rows.Count > 0 Then
            'DECLARANDO VARIABLES
            Dim colDestinoGravado As Decimal = 0
            colDestinoGravado = dgvCompra.Item(1, dgvCompra.CurrentRow.Index).Value

            Dim colCantidad As Decimal = 0
            Select Case dgvCompra.Item(21, dgvCompra.CurrentRow.Index).Value
                Case "GS"
                    colCantidad = 1
                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value = 1
                Case Else
                    If Not CStr(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese una cantidad válida!"
                        lblEstado.Image = My.Resources.warning2
                        'Timer1.Enabled = True
                        'TiempoEjecutar(5)
                        Exit Sub
                    Else
                        colCantidad = dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value
                        dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value = colCantidad.ToString("N2")
                    End If
            End Select


            Dim colBI As Decimal = 0
            Dim colBI_ME As Decimal = 0
            Dim colIGV_ME As Decimal = 0
            Dim colIGV As Decimal = 0
            Dim colMN As Decimal = 0

            If Not CStr(dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value).Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el valor de compra!"
                lblEstado.Image = My.Resources.warning2
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
                Exit Sub
            Else
                colMN = dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value
            End If

            Dim colME As Decimal = Math.Round(CDec(dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value) / CDec(txtTipoCambio.Value), 2)
            Dim colPrecUnit As Decimal = 0
            Dim colPrecUnitUSD As Decimal = 0

            If colCantidad > 0 AndAlso colMN > 0 Then

                ' colIGV = Math.Round(colMN * 0.18, 2) 'Math.Round((colMN / 1.18) * 0.18, 2)
                colIGV = Math.Round(colMN * (txtIgv.Value / 100), 2)
                'colIGV_ME = Math.Round(colME * 0.18, 2) ' Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)
                colIGV_ME = Math.Round(colME * (txtIgv.Value / 100), 2)


                colBI = colMN + colIGV
                colBI_ME = colME + colIGV_ME

                colPrecUnit = Math.Round(colMN / colCantidad, 2)
                colPrecUnitUSD = Math.Round(colME / colCantidad, 2)
                dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2")
            ElseIf colCantidad = 0 Then
                'colIGV = Math.Round(colMN * 0.18, 2) 'Math.Round((colMN / 1.18) * 0.18, 2)
                colIGV = Math.Round(colMN * (txtIgv.Value / 100), 2)
                'colIGV_ME = Math.Round(colME * 0.18, 2) ' Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)
                colIGV_ME = Math.Round(colME * (txtIgv.Value / 100), 2)


                colBI = colMN + colIGV
                colBI_ME = colME + colIGV_ME

                colPrecUnit = 0
                colPrecUnitUSD = 0
            Else
                colPrecUnit = 0

                colPrecUnitUSD = 0

                colBI = 0
                colBI_ME = 0
                colIGV = 0
                colIGV_ME = 0
            End If

            Select Case txtComprobante.ValueMember
                Case "08"

                Case "03", "02"
                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2")
                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2")
                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                    dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                    dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = 0
                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = 0
                Case Else
                    If dgvCompra.Columns(e.ColumnIndex).Name = "kardex" Or dgvCompra.Columns(e.ColumnIndex).Name = "Can1" Then
                        If cboMoneda.SelectedValue = 1 Then
                            ' DATOS SOLES

                            Select Case colDestinoGravado
                                Case "2", "3", "4"
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2")
                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2")
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                    dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                                    dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = 0
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = 0
                                Case Else
                                    If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then ' BOnIFICACIOn
                                        dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                                        dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2")
                                        dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2")
                                        dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                                        dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = 0
                                        dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = 0
                                    Else
                                        If colCantidad > 0 Then
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2")
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2")
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colBI.ToString("N2")
                                            dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = colBI_ME.ToString("N2")
                                            dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2")
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2")
                                        Else
                                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2")
                                            dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2")
                                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                            dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")
                                            dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = colIGV.ToString("N2")
                                            dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = colIGV_ME.ToString("N2")
                                        End If

                                    End If
                            End Select

                        ElseIf cboMoneda.SelectedValue = 2 Then

                            Select Case colDestinoGravado
                                Case "4"

                                Case Else
                                    ' DATOS DOLARES
                                    If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then

                                    Else

                                    End If

                            End Select

                        End If
                    End If
            End Select

        End If
        totales_xx()
        TotalesCabeceras()
    End Sub

    Private Sub dgvCompra_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCompra.CellFormatting

        If e.RowIndex > -1 Then
            ' If txtAlmacen.Text.Trim.Length > 0 Then
            If (Tag = 1) Then
                If Not dgvCompra.Rows(e.RowIndex).Cells(21).Value = "GS" Then
                    'dgvCompra.Rows(e.RowIndex).Cells(30).Value = txtAlmacen.ValueMember
                    'dgvCompra.Rows(e.RowIndex).Cells(31).Value = txtAlmacen.Text
                Else
                    dgvCompra.Rows(e.RowIndex).Cells(30).Value = String.Empty
                    dgvCompra.Rows(e.RowIndex).Cells(31).Value = String.Empty
                End If
            End If
            'End If

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

    Private Sub dgvCompra_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellValueChanged
        If dgvCompra.Rows.Count > 0 Then

            If e.ColumnIndex = 27 Then
                If (Me.dgvCompra.Rows(e.RowIndex).Cells("colBonif").Value) = "S" Then
                    CheckBoxClicked = True
                    '      dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "S"
                    txtBonifmn.Text += CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value)
                    txtBonifme.Text += CDec(dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value)
                Else
                    CheckBoxClicked = False
                    txtBonifmn.Text -= CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value)
                    txtBonifme.Text -= CDec(dgvCompra.Item(13, dgvCompra.CurrentRow.Index).Value)
                    '  dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "N"
                End If
                'Call the method to do when selected checkbox changes its state:
                MyMethodOnCheckBoxes()
            ElseIf e.ColumnIndex = 12 Then
                '    ValidaMontosBase()
            ElseIf e.ColumnIndex = 16 Then
                '      ValidaMontosBase()
            ElseIf e.ColumnIndex = 36 Then
                If (Me.dgvCompra.Rows(e.RowIndex).Cells("colModifiPrecio").Value) = "S" Then
                Else
                End If
            End If
        End If
    End Sub

    Private Sub dgvCompra_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvCompra.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCompra.KeyDown
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
                        End If
                    Case 3
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(8, Me.dgvCompra.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub txtIgv_ValueChanged(sender As Object, e As EventArgs) Handles txtIgv.ValueChanged
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub btmGrabarClasificacion_Click(sender As Object, e As EventArgs) Handles btmGrabarClasificacion.Click
        If Not txtNewClasificacion.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre de la clasificación"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            txtNewClasificacion.Select()
            Exit Sub
        End If
        If Not nupUtilidad.Value > 0 Then
            lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            nupUtilidad.Select()
            Exit Sub
        End If
        If Not nupUtilidadMayor.Value > 0 Then
            lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            nupUtilidadMayor.Select()
            Exit Sub
        End If
        If Not nupUtilidadGranMayor.Value > 0 Then
            lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            nupUtilidadGranMayor.Select()
            Exit Sub
        End If
        btmGrabarClasificacion.Tag = "G"
        Me.pcClasificacion.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCategoria.SelectedItems.Count > 0 Then
                Me.txtCategoria.ValueMember = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id)
                txtCategoria.Tag = DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad
                txtCategoria.Text = lstCategoria.Text
                ListadoProductosPorCategoriaTipoExistencia(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id, cboTipoExistencia.SelectedValue, DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnRuc_Click(sender As Object, e As EventArgs) Handles btnRuc.Click
        btnRuc.Checked = True
        If btnRuc.Checked = True Then
            btnDni.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnDni_Click(sender As Object, e As EventArgs) Handles btnDni.Click
        btnDni.Checked = True
        If btnDni.Checked = True Then
            btnRuc.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnPassport_Click(sender As Object, e As EventArgs) Handles btnPassport.Click
        btnPassport.Checked = True
        If btnPassport.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnCarnetEx_Click(sender As Object, e As EventArgs) Handles btnCarnetEx.Click
        btnCarnetEx.Checked = True
        If btnCarnetEx.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnPassport.Checked = False
        End If
    End Sub

    Private Sub rbNatural_CheckChanged(sender As Object, e As EventArgs) Handles rbNatural.CheckChanged
        If rbNatural.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()
            Label31.Visible = True
            Label30.Text = "Nombres:"
        End If
    End Sub

    Private Sub rbJuridico_CheckChanged(sender As Object, e As EventArgs) Handles rbJuridico.CheckChanged
        If rbJuridico.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            Label31.Visible = False
            Label30.Text = "Nombre o Razón Social:"
        End If
    End Sub

    Private Sub btnGRabarProv_Click(sender As Object, e As EventArgs) Handles btnGRabarProv.Click
        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 248)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 248)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtNomProv.Select()
            Exit Sub
        End If

        If rbNatural.Checked = True Then
            If Not txtApePat.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 248)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtApePat.Select()
                Exit Sub
            End If
        End If
        btnGRabarProv.Tag = "G"
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btnCancelarProv_Click(sender As Object, e As EventArgs) Handles btnCancelarProv.Click
        Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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
                    CellEndEditRefresh()
                End If
            End If
        End If
    End Sub
End Class