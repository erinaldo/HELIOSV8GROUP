Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl

Public Class frmCompraPagadaSinRecepcion
    Inherits frmMaster
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Dim ReferenciaFondoMN, ReferenciaFondoME As Decimal
    Sub ControlsHide()
        rbDetraccion.Visible = False
        rbRetencion.Visible = False
        rbPercepcion.Visible = False
        nudPorcentajeTributo.Visible = False
        Label22.Visible = False
        nudImporteMN.Visible = False
        nudImporteMe.Visible = False
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

        If keyData = Keys.Tab AndAlso txtProveedor.Focused Then
            '  MessageBox.Show("Tab pressed")
            Return True
        End If

        If keyData = (Keys.Tab Or Keys.Shift) AndAlso txtProveedor.Focused Then
            '  MessageBox.Show("Shift-Tab pressed")
            Return True
        End If

        Return baseResult
    End Function

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

    Dim UserControl1 As New ucConfiguracion
    Dim UcConfigCaja As New ucConfiguracionCaja
    Dim toolTip As Popup
    Dim toolTipCaja As Popup
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
        'GFichaUsuarios = New GFichaUsuario
        GConfiguracion = New GConfiguracionModulo
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "C3", Me.Text, GEstableciento.IdEstablecimiento)
        ObtenerListaControlesLoad()
        CargarCMBGastos()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dockingManager1.DockControl(Me.Panel2, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        Me.dockingManager1.DockControl(Me.PanelServicios, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.DockControlInAutoHideMode(PanelServicios, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        ' Me.Panel2.BringToFront()
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        '  Me.dockingClientPanel1.SizeToFit = True
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        ' dockingManager1.SetDockVisibility ( panel)
        dockingManager1.SetDockLabel(Panel2, "Existencias")
        dockingManager1.SetDockLabel(PanelServicios, "Servicios")
        'dockingManager1.ImageList = ImageListAdv1
        '  dockingManager1.SetDockIcon(Panel2, 1)

        'INICIO PERIODO
        lblPerido.Text = PeriodoGeneral ' String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
        ControlsHide()
        SetRenderer()
        txtFechaComprobante.Select()
        dockingManager1.CloseEnabled = False
        txtTipoCambio.Value = TmpTipoCambio
        txtIgv.Value = TmpIGV
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
#End Region

#Region "PROVEEDOR"
    Public Sub InsertProveedor()
        Dim objCliente As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            objCliente.idEmpresa = Gempresas.IdEmpresaRuc
            objCliente.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR

            If btnRuc.Checked = True Then
                objCliente.tipoDoc = "6"
            ElseIf btnDni.Checked = True Then
                objCliente.tipoDoc = "1"
            ElseIf btnPassport.Checked = True Then
                objCliente.tipoDoc = "7"
            ElseIf btnCarnetEx.Checked = True Then
                objCliente.tipoDoc = "4"
            End If
            objCliente.nrodoc = txtDocProveedor.Text.Trim

            If rbNatural.Checked = True Then
                objCliente.appat = txtApePat.Text.Trim
                objCliente.nombre1 = txtNomProv.Text.Trim
                objCliente.nombreCompleto = objCliente.appat & ", " & objCliente.nombre1
                objCliente.tipoPersona = "N"
            ElseIf rbJuridico.Checked = True Then
                objCliente.nombre = txtNomProv.Text.Trim
                objCliente.nombreCompleto = txtNomProv.Text.Trim
                objCliente.tipoPersona = "J"
            End If
            objCliente.cuentaAsiento = "4212"
            objCliente.estado = "A"
            objCliente.usuarioModificacion = "NN"
            objCliente.fechaModificacion = DateTime.Now

            Dim codx As Integer = entidadSA.GrabarEntidad(objCliente)
            'lblEstado.Text = "Entidad registrada:" & vbCrLf & "Tipo: " & objCliente.tipoEntidad & vbCrLf & "Nombre: " & objCliente.nombreCompleto
            'lblEstado.Image = My.Resources.ok4

            Dim n As New ListViewItem(codx)
            n.SubItems.Add(objCliente.nombreCompleto)
            n.SubItems.Add(objCliente.cuentaAsiento)
            n.SubItems.Add(objCliente.nrodoc)
            lsvProveedor.Items.Add(n)

            txtProveedor.ValueMember = codx
            txtProveedor.Text = objCliente.nombreCompleto
            txtRuc.Text = objCliente.nrodoc
            txtCuenta.Text = objCliente.cuentaAsiento
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "PRODUCTOS"
    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        tbIGV.Renderer = styleRenderer1

    End Sub

    Public Sub GrabarItemEstablec()
        Dim objitem As New detalleitems
        Dim itemSA As New detalleitemsSA
        Try
            'Se asigna cada uno de los datos registrados
            objitem.idItem = txtCategoria.ValueMember    ' Trim(txtCodigoDocumento.Text)
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.cuenta = txtCuentaCodigo.Text
            objitem.descripcionItem = txtProductoNew.Text.Trim
            objitem.presentacion = txtPresentacion.ValueMember
            objitem.unidad1 = txtNomUnidad.ValueMember
            ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
            objitem.tipoExistencia = cboTipoExistencia.SelectedValue
            objitem.origenProducto = IIf(tbIGV.ToggleState = Tools.ToggleButtonState.Active, "1", "2")
            objitem.tipoProducto = "I"

            objitem.usuarioActualizacion = "Jiuni"
            objitem.fechaActualizacion = DateTime.Now

            Dim codxIdtem As Integer = itemSA.InsertNuevaItems(objitem)
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Item registrado!"

            If chAddCanasta.Checked = True Then
                Dim objInsumo As New detalleitemsSA
                Dim tablaSA As New tablaDetalleSA

                With objInsumo.InvocarProductoID(codxIdtem)
                    dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
                                         .presentacion,
                                            tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
                                          0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                          .tipoExistencia, .cuenta, Nothing)
                    txtProductoNew.Clear()
                    txtProductoNew.Select()
                End With
            Else
                txtProductoNew.Clear()
                txtProductoNew.Select()

            End If


        Catch ex As Exception
            'Manejo de errores
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub


#End Region

#Region "Métodos"
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
    '                Case "M"

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
    '        Timer1.Enabled = True
    '        PanelError.Visible = True
    '        TiempoEjecutar(10)
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

    Public Sub ObtenerListaControlesLoad()
        '  Dim entidadSA As New entidadSA
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

        cboMarca.DisplayMember = "descripcion"
        cboMarca.ValueMember = "codigoDetalle"
        cboMarca.DataSource = tablaSA.GetListaTablaDetalle(503, "1")

        'COMPROBANTE TIPO DOCUMENTOS
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(10, "1")

        'TIPO DE EXISTENCIA
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        Dim dtUM As New DataTable
        dtUM.Columns.Add("ID")
        dtUM.Columns.Add("Name")

        Dim dtPresentacion As New DataTable
        dtPresentacion.Columns.Add("IDPres")
        dtPresentacion.Columns.Add("NamePres")

        For Each i In categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
            lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem, i.utilidad, i.utilidadmayor, i.utilidadgranmayor))
        Next
        lstCategoria.DisplayMember = "Name"
        lstCategoria.ValueMember = "Id"

    End Sub
#End Region

#Region "CESTO SERVICIOS"
    Public Sub CargarGastoCuentaPAdreLIke()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Try
            lsvServicios.Columns.Clear()
            lsvServicios.Items.Clear()
            lsvServicios.Columns.Add("Cuenta", 75)
            lsvServicios.Columns.Add("Descripcion", 318)
            '  lsvServicios.Columns.Add("Cuenta Padre", 0)
            For Each i As cuentaplanContableEmpresa In cuentaSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "18")
                Dim n As New ListViewItem(i.cuenta)
                n.SubItems.Add(i.descripcion)
                lsvServicios.Items.Add(n)
            Next
        Catch ex As Exception
            lblEstado.Text = "Error al obtener Cuentas." & vbCrLf & ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub CargarListaGasto()
        Dim cuentaSA As New mascaraGastosEmpresaSA
        Try
            lsvServicios.Columns.Clear()
            lsvServicios.Items.Clear()
            lsvServicios.Columns.Add("Cuenta", 75)
            lsvServicios.Columns.Add("Descripcion", 318)
            '  lsvServicios.Columns.Add("Cuenta Padre", 0)
            For Each i As mascaraGastosEmpresa In cuentaSA.ObtenerMascaraGastos(Gempresas.IdEmpresaRuc, txtServicio.Text)
                Dim n As New ListViewItem(i.cuentaCompra)
                n.SubItems.Add(i.descripcionCompra)
                lsvServicios.Items.Add(n)
            Next
        Catch ex As Exception
            lblEstado.Text = ("Error al cargar datos. " & vbCrLf & ex.Message)
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
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
#End Region

#Region "Métodos DGV"
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

        Select Case cboTipoDoc.SelectedValue
            Case "02", "03"
                txtTotalmn.Text = cTotalMN   'cTotalMN.ToString("N2")
                txtTotalme.Text = cTotalME   'cTotalME.ToString("N2")
            Case "08"
                'Instrucciones
            Case Else

                txtTotalmn.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
                txtTotalme.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
        End Select

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
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)
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
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
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

                Select Case cboTipoDoc.SelectedValue
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

    Private Function GlosaCompra() As String
        If Not String.IsNullOrEmpty(txtSerie.Text) And Not String.IsNullOrEmpty(txtNumero.Text) And _
        Not String.IsNullOrEmpty(txtProveedor.Text) Then
            Return String.Concat("Por compras", Space(1), "según/ ", Space(1), cboTipoDoc.Text, Space(1), "Nro.", Space(1), txtSerie.Text, "-", txtNumero.Text, ", de Fecha:", Space(1), txtFechaComprobante.Text, Space(1))
        Else
            Return False
        End If
    End Function
#End Region

#Region "Manipulación Data"

    Public Sub ExistenciaPorNotificacion(ByVal idItem As Integer, ByVal IdAlmacen As Integer)
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA


        With objInsumo.InvocarProductoID(CInt(idItem))
            dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
                                     .presentacion,
                                        tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                      .tipoExistencia, .cuenta, Nothing)
            Tag = 1
        End With

    End Sub

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

            If rbDetraccion.Checked = True Then
                .tipoDoc = "9904"
            ElseIf rbRetencion.Checked = True Then
                .tipoDoc = "9905"
            ElseIf rbPercepcion.Checked = True Then
                .tipoDoc = "9906"
            End If

            .fechaProceso = fecha
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
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
            .periodo = PeriodoGeneral
            If rbDetraccion.Checked = True Then
                .tipoDoc = "9904"
                .tipoTributo = "D"
            ElseIf rbRetencion.Checked = True Then
                .tipoTributo = "R"
                .tipoDoc = "9905"
            ElseIf rbPercepcion.Checked = True Then
                .tipoTributo = "P"
                .tipoDoc = "9906"
            End If

            .idEntidad = txtProveedor.ValueMember
            .tipoOperacion = "02"
            .idEntidadFinanciera = Nothing
            .tipoDesposito = Nothing
            .serieDoc = txtSerie.Text
            .numeroDoc = txtNumero.Text
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .porcTributario = nudPorcentajeTributo.Value
            .tipoCambio = txtTipoCambio.Value
            .importeTotal = CDec(nudImporteMN.Text)
            .importeUS = CDec(nudImporteMe.Text)
            .glosa = GlosaCompra()
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        documento.documentoObligacionTributaria = documentoObligacion

        objdocumentoDetalle = New documentoObligacionDetalle
        objdocumentoDetalle.idItem = Nothing
        objdocumentoDetalle.descripcionItem = GlosaCompra()
        objdocumentoDetalle.destino = "0"
        objdocumentoDetalle.unidadMedida = Nothing
        objdocumentoDetalle.cantidad = Nothing
        objdocumentoDetalle.precioUnitario = Nothing
        objdocumentoDetalle.precioUnitarioUS = Nothing
        objdocumentoDetalle.porcTributo = Nothing
        objdocumentoDetalle.importeMN = CDec(nudImporteMN.Text)
        objdocumentoDetalle.importeME = CDec(nudImporteMe.Text)
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
            chObligacion.Visible = False
            With objDoc.UbicarDocumento(intIdDocumento)
                fecha = .fechaProceso
                txtFechaComprobante.Value = fecha
                'COMPROBANTE
                'With objTabla.GetUbicarTablaID(10, .tipoDoc)
                cboTipoDoc.SelectedValue = .tipoDoc
                'cboTipoDoc.Text = .descripcion
                'End With
            End With

            DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            If Not IsNothing(DocumentoGuia) Then
                With DocumentoGuia
                    txtSerieGuia.Text = .Serie
                    txtNumeroGuia.Text = .Numero
                End With
            End If
            'With objDocCaja.UbicarDocumento(documentoCajaDetalleSA.RecuperarIDCompra(intIdDocumento))
            '    With objTabla.GetUbicarTablaID(1, .tipoDoc)
            '        txtIdComprobanteCaja = .codigoDetalle
            '        txtComprobanteCaja = .descripcion
            '    End With
            '    txtNumCaja = .nroDoc

            '    With documentoCajaSA.GetUbicar_documentoCajaPorID(documentoCajaDetalleSA.RecuperarIDCompra(intIdDocumento))
            '        txtIdEstablecimientoCaja = .idEstablecimiento
            '        txtEstablecimientoCaja = establecSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
            '        txtIdCaja = .entidadFinanciera
            '        With estadoF.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)

            '            'Select Case .tipo
            '            '    Case "BC"
            '            '        rbBanco.Checked = True
            '            '    Case Else
            '            '        rbEfectivo.Checked = True
            '            'End Select

            '            txtCaja = .descripcion
            '            txtCuentaEF = .cuenta
            '        End With
            '    End With


            'End With


            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                lblIdDocumento.Text = .idDocumento
                cboTipoDoc.SelectedValue = .tipoDoc

                'With objTabla.GetUbicarTablaID(10, .tipoDoc)
                '    txtComprobante.Text = .descripcion
                'End With

                lblSituacion.Text = .situacion
                PeriodoGeneral = .fechaContable
                txtSerie.Text = .serie

                txtNumero.Text = .numeroDoc

                'PROVEEDOR
                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtCuenta.Text = nEntidad.cuentaAsiento
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
                                    FormatNumber(i.montokardex, 2),
                                    FormatNumber(i.precioUnitario, 2),
                                    FormatNumber(i.importe, 2),
                                    FormatNumber(i.montokardexUS, 2),
                                    FormatNumber(i.precioUnitarioUS, 2),
                                    FormatNumber(i.importeUS, 2),
                                    FormatNumber(i.montoIsc, 2),
                                    FormatNumber(i.montoIgv, 2),
                                    FormatNumber(i.otrosTributos, 2),
                                    FormatNumber(i.montoIscUS, 2),
                                    FormatNumber(i.montoIgvUS, 2),
                                    FormatNumber(i.otrosTributosUS, 2),
                                    Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                    i.idItem,
                                    i.preEvento,
                                    Nothing, Nothing, Nothing,
                                    IIf(i.bonificacion = "S", "S", "N"), Nothing, i.bonificacion,
                                    Nothing, Nothing,
                                    Nothing, Nothing)

                    Case Else
                        dgvCompra.Rows.Add(i.secuencia,
                                    VALUEDES,
                                    i.idItem,
                                    i.descripcionItem,
                                    i.unidad2,
                                    i.monto2,
                                    i.unidad1,
                                    FormatNumber(i.monto1, 2),
                                    FormatNumber(i.montokardex, 2),
                                    FormatNumber(i.precioUnitario, 2),
                                    FormatNumber(i.importe, 2),
                                    FormatNumber(i.montokardexUS, 2),
                                    FormatNumber(i.precioUnitarioUS, 2),
                                    FormatNumber(i.importeUS, 2),
                                    FormatNumber(i.montoIsc, 2),
                                    FormatNumber(i.montoIgv, 2),
                                    FormatNumber(i.otrosTributos, 2),
                                    FormatNumber(i.montoIscUS, 2),
                                    FormatNumber(i.montoIgvUS, 2),
                                    FormatNumber(i.otrosTributosUS, 2),
                                    Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                    insumosSA.InvocarProductoID(i.idItem).cuenta,
                                    i.preEvento,
                                     Nothing, Nothing, Nothing,
                                    IIf(i.bonificacion = "S", "S", "N"), Nothing, i.bonificacion, i.almacenRef,
                                    almacenSA.GetUbicar_almacenPorID(i.almacenRef).descripcionAlmacen,
                                    i.almacenRef,
                                    Nothing)
                End Select


            Next

            totales_xx()
            TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function AS_CAJA(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        Dim cajaSA As New EstadosFinancierosSA

        With cajaSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
            nMovimiento = New movimiento
            nMovimiento.cuenta = .cuenta
            nMovimiento.descripcion = .descripcion
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = cMonto
            nMovimiento.montoUSD = cMontoUS
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = "Jiuni"
        End With
        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "IGV", "COMPRA")
        nMovimiento = New movimiento With {
              .cuenta = cuentaMascara.cuentaEspecifica,
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
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = GlosaCompra()
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

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
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Existencia
        nAsiento.importeMN = CDec(txtTotalmn.Text)
        nAsiento.importeME = CDec(txtTotalme.Text)
        nAsiento.glosa = GlosaCompra()
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

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
        nAsiento.glosa = GlosaCompra()
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
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
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
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
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

    Public Sub AsientoCompra()
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoCabeceraCompra(CDec(txtTotalmn.Text), CDec(txtTotalme.Text)) ' CABECERA ASIENTO

        '---------------------------------------------------------------------------------------------
        'DETALLE DEL ASIENTO DE COMPRA
        'MOVIMIENTOS
        For Each i As DataGridViewRow In dgvCompra.Rows

            If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                If dgvCompra.Rows(i.Index).Cells(27).Value() <> "S" Then
                    nMovimiento = New movimiento
                    If Not i.Cells(21).Value = "GS" Then
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, dgvCompra.Rows(i.Index).Cells(21).Value(), "ITEM", "COMPRA")
                        Select Case dgvCompra.Rows(i.Index).Cells(21).Value()
                            Case "08"
                                nMovimiento.cuenta = "28"
                            Case Else
                                Select Case cuentaMascara.parametro
                                    Case "01"
                                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                    Case "03"
                                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                    Case "04"
                                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                    Case "05"
                                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                End Select
                        End Select
                    Else
                        nMovimiento.cuenta = dgvCompra.Rows(i.Index).Cells(2).Value()
                    End If


                    nMovimiento.descripcion = dgvCompra.Rows(i.Index).Cells(3).Value()
                    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                    Select Case cboTipoDoc.SelectedValue
                        Case "03", "02"
                            nMovimiento.monto = CDec(dgvCompra.Rows(i.Index).Cells(10).Value())
                            nMovimiento.montoUSD = CDec(dgvCompra.Rows(i.Index).Cells(13).Value())
                        Case Else
                            Select Case dgvCompra.Rows(i.Index).Cells(1).Value()
                                Case "1"
                                    nMovimiento.monto = CDec(dgvCompra.Rows(i.Index).Cells(8).Value())
                                    nMovimiento.montoUSD = CDec(dgvCompra.Rows(i.Index).Cells(11).Value())
                                Case Else
                                    nMovimiento.monto = CDec(dgvCompra.Rows(i.Index).Cells(10).Value())
                                    nMovimiento.montoUSD = CDec(dgvCompra.Rows(i.Index).Cells(13).Value())
                            End Select

                    End Select

                    nMovimiento.fechaActualizacion = DateTime.Now
                    nMovimiento.usuarioActualizacion = "Jiuni"
                    asientoTransitod.movimiento.Add(nMovimiento)
                End If
            End If
        Next
        Select Case cboTipoDoc.SelectedValue
            Case "03", "02"
                'NO TIENE ASIENTO DE IGV
            Case Else
                asientoTransitod.movimiento.Add(AS_IGV(CDec(txtMontoIGVmn.Text), CDec(txtMontoIGVme.Text)))
        End Select
        asientoTransitod.movimiento.Add(AS_CAJA(CDec(txtTotalmn.Text), CDec(txtTotalme.Text)))

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Sub AsientoBONIF(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = ASBOF(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento

        Select Case strTipoExistencia
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
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
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        End Select
        nMovimiento.descripcion = "Bonif. obtenidas, descuentos rebajas-terceros"
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Function ComprobanteCaja() As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)


        ef = efSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)

        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = fecha
        nDocumentoCaja.nroDoc = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "02"
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now


        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.fechaProceso = fecha
        objCaja.fechaCobro = fecha
        objCaja.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
        objCaja.IdProveedor = txtProveedor.ValueMember
        objCaja.codigoLibro = "02"
        objCaja.codigoProveedor = txtProveedor.ValueMember
        objCaja.TipoDocumentoPago = "109"
        objCaja.tipoDocPago = "109"
        objCaja.periodo = PeriodoGeneral
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2") ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = txtTipoCambio.Value
        objCaja.montoSoles = CDec(txtTotalmn.Text)
        objCaja.montoUsd = CDec(txtTotalme.Text)

        objCaja.glosa = GlosaCompra()
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        For Each i As DataGridViewRow In dgvCompra.Rows
            objCajaDetalle = New documentoCajaDetalle
            objCajaDetalle.idDocumento = 0
            objCajaDetalle.fecha = fecha
            objCajaDetalle.idItem = i.Cells(2).Value
            objCajaDetalle.DetalleItem = i.Cells(3).Value
            objCajaDetalle.montoSoles = CDec(i.Cells(10).Value) 'CDec(txtTotalmn.Text)
            objCajaDetalle.montoUsd = CDec(i.Cells(13).Value) ' CDec(txtTotalme.Text)
          
            objCajaDetalle.entregado = "SI"
            objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
            objCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaDetalle.Add(objCajaDetalle)
        Next
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle

        '   nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)
        Return nDocumentoCaja
    End Function

    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each i As DataGridViewRow In dgvCompra.Rows

            If Not i.Cells(21).Value() = "GS" Then


                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = 0
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.Modulo = "N"
                objTotalesDet.idEstablecimiento = GEstableciento.IdEstablecimiento
                objTotalesDet.idAlmacen = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
                objTotalesDet.origenRecaudo = i.Cells(1).Value()
                objTotalesDet.tipoCambio = txtTipoCambio.Value
                objTotalesDet.tipoExistencia = i.Cells(21).Value()
                objTotalesDet.idItem = i.Cells(2).Value()
                objTotalesDet.descripcion = i.Cells(3).Value()
                objTotalesDet.idUnidad = i.Cells(6).Value()
                objTotalesDet.unidadMedida = Nothing
                objTotalesDet.cantidad = CType(i.Cells(7).Value(), Decimal)
                objTotalesDet.precioUnitarioCompra = CType(i.Cells(8).Value(), Decimal)

                If i.Cells(27).Value = "S" Then
                    objTotalesDet.importeSoles = CType(i.Cells(8).Value(), Decimal)
                    objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal)
                Else

                    Select Case cboTipoDoc.SelectedValue
                        Case "03", "02"

                            objTotalesDet.importeSoles = CType(i.Cells(8).Value(), Decimal)
                            objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal)
                        Case Else
                            Select Case i.Cells(1).Value()
                                Case "1"
                                    objTotalesDet.importeSoles = CType(i.Cells(8).Value(), Decimal)
                                    objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal)
                                Case Else
                                    objTotalesDet.importeSoles = CType(i.Cells(8).Value(), Decimal)
                                    objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal)
                            End Select
                    End Select
                End If


                objTotalesDet.montoIsc = 0
                objTotalesDet.montoIscUS = 0
                objTotalesDet.Otros = 0
                objTotalesDet.OtrosUS = 0
                objTotalesDet.porcentajeUtilidad = 0
                objTotalesDet.importePorcentaje = 0
                objTotalesDet.importePorcentajeUS = 0
                objTotalesDet.precioVenta = 0
                objTotalesDet.precioVentaUS = 0
                objTotalesDet.usuarioActualizacion = "NN"
                objTotalesDet.fechaActualizacion = Date.Now
                ListaTotales.Add(objTotalesDet)
            End If


        Next

        Return ListaTotales
    End Function

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = lblIdDocumento.Text
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            '.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
            '.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
            .idEntidad = txtProveedor.ValueMember
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value
            .tipoCambio = txtTipoCambio.Value
            .importeMN = CDec(txtTotalmn.Text)
            .importeME = CDec(txtTotalme.Text)
            .glosa = GlosaCompra()
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each i As DataGridViewRow In dgvCompra.Rows
            If Not i.Cells(21).Value = "GS" Then
                If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                    documentoguiaDetalle = New documentoguiaDetalle
                    If txtSerieGuia.Text.Trim.Length > 0 Then
                        objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                    Else
                        MessageBoxAdv.Show("Ingrese número de serie de la guía!")
                        Exit Sub
                    End If
                    If txtNumeroGuia.Text.Trim.Length > 0 Then
                        objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                    Else
                        MessageBoxAdv.Show("Ingrese número de la guía!")
                        Exit Sub
                    End If
                    documentoguiaDetalle.idDocumento = lblIdDocumento.Text
                    documentoguiaDetalle.idItem = i.Cells(2).Value
                    documentoguiaDetalle.descripcionItem = i.Cells(3).Value
                    documentoguiaDetalle.destino = i.Cells(1).Value
                    documentoguiaDetalle.unidadMedida = i.Cells(6).Value
                    documentoguiaDetalle.cantidad = CDec(i.Cells(7).Value)
                    documentoguiaDetalle.precioUnitario = CDec(i.Cells(9).Value)
                    documentoguiaDetalle.precioUnitarioUS = CDec(i.Cells(12).Value)
                    documentoguiaDetalle.importeMN = CDec(i.Cells(10).Value)
                    documentoguiaDetalle.importeME = CDec(i.Cells(13).Value)
                    documentoguiaDetalle.almacenRef = CInt(i.Cells(30).Value)
                    documentoguiaDetalle.usuarioModificacion = "Jiuni"
                    documentoguiaDetalle.fechaModificacion = DateTime.Now
                    ListaGuiaDetalle.Add(documentoguiaDetalle)
                End If
            End If
        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim almacenSA As New almacenSA

        Dim ListaTotales As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        'Dim cajaUsarioBE As New cajaUsuario
        'Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        'Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)

        Dim guiaRemisionBE As New documentoGuia
        Dim guiaREmisionDetaellBE As New documentoguiaDetalle

        Dim documentoTributo As New documento

        'With cajaUsarioBE
        '    .idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        '    .otrosEgresosMN = CDec(txtTotalmn.Text)
        '    .otrosEgresosME = CDec(txtTotalme.Text)
        'End With

        'cajaUsariodetalleBE = New cajaUsuariodetalle
        'cajaUsariodetalleBE.idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        'cajaUsariodetalleBE.tipoDoc = cboTipoDoc.SelectedValue
        'cajaUsariodetalleBE.tipoVenta = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
        'cajaUsariodetalleBE.importeMN = CDec(txtTotalmn.Text)
        'cajaUsariodetalleBE.importeME = CDec(txtTotalme.Text)
        'cajaUsariodetalleListaBE.Add(cajaUsariodetalleBE)
        'cajaUsarioBE.cajaUsuariodetalle = cajaUsariodetalleListaBE

        'Limpiando lista asientos contables
        ListaAsientonTransito = New List(Of asiento)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "8"
            .tipoDoc = cboTipoDoc.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .fechaContable = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = txtProveedor.ValueMember
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
            .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))
            .bi03 = IIf(nudBase3 = 0 Or nudBase3 = "0.00", CDec(0.0), CDec(nudBase3))
            .bi04 = IIf(nudBase4 = 0 Or nudBase4 = "0.00", CDec(0.0), CDec(nudBase4))
            .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
            .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))
            .isc03 = IIf(nudIsc3 = 0 Or nudIsc3 = "0.00", CDec(0.0), CDec(nudIsc3))
            .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
            .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))
            .igv03 = IIf(nudMontoIgv3 = 0 Or nudMontoIgv3 = "0.00", CDec(0.0), CDec(nudMontoIgv3))
            .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
            .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))
            .otc03 = IIf(nudOtrosTributos3 = 0 Or nudOtrosTributos3 = "0.00", CDec(0.0), CDec(nudOtrosTributos3))
            .otc04 = IIf(nudOtrosTributos4 = 0 Or nudOtrosTributos4 = "0.00", CDec(0.0), CDec(nudOtrosTributos4))
            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
            .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))
            .bi03us = IIf(nudBaseus3 = 0 Or nudBaseus3 = "0.00", CDec(0.0), CDec(nudBaseus3))
            .bi04us = IIf(nudBaseus4 = 0 Or nudBaseus4 = "0.00", CDec(0.0), CDec(nudBaseus4))
            .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
            .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))
            .isc03us = IIf(nudIscus3 = 0 Or nudIscus3 = "0.00", CDec(0.0), CDec(nudIscus3))
            .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
            .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))
            .igv03us = IIf(nudMontoIgvus3 = 0 Or nudMontoIgvus3 = "0.00", CDec(0.0), CDec(nudMontoIgvus3))
            .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
            .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))
            .otc03us = IIf(nudOtrosTributosus3 = 0 Or nudOtrosTributosus3 = "0.00", CDec(0.0), CDec(nudOtrosTributosus3))
            .otc04us = IIf(nudOtrosTributosus4 = 0 Or nudOtrosTributosus4 = "0.00", CDec(0.0), CDec(nudOtrosTributosus4))
            '****************************************************************************************************************
            .importeTotal = CDec(txtTotalmn.Text)
            .importeUS = CDec(txtTotalme.Text)
            .destino = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = GlosaCompra()
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
            .situacion = TIPO_SITUACION.ALMACEN_TRANSITO
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'REGISTRANDO LA GUIA DE REMISION
        '  GuiaRemision(ndocumento)


        If CDec(txtTotalmn.Text) > 0 Then
            AsientoCompra()
        End If
        'ASIENTOS CONTABLES
        For Each i As DataGridViewRow In dgvCompra.Rows
            If i.Cells(27).Value = "S" Then
                Select Case i.Cells(21).Value()
                    Case "GS"

                    Case Else
                        AsientoBONIF(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(8).Value()), CDec(i.Cells(11).Value()), i.Cells(21).Value())
                End Select
            Else
                Select Case i.Cells(21).Value()
                    Case "08"

                    Case "GS"

                    Case Else
                        Select Case cboTipoDoc.SelectedValue
                            Case "03", "02"
                                MV_Item_Transito(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(8).Value()), CDec(i.Cells(11).Value()), i.Cells(21).Value())
                            Case Else

                                Select Case i.Cells(1).Value()
                                    Case "1"
                                        MV_Item_Transito(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(8).Value()), CDec(i.Cells(11).Value()), i.Cells(21).Value())
                                    Case Else
                                        MV_Item_Transito(i.Cells(22).Value(), i.Cells(3).Value(), CDec(i.Cells(8).Value()), CDec(i.Cells(11).Value()), i.Cells(21).Value())

                                End Select
                        End Select
                End Select
            End If

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION     'aqui
            objDocumentoCompraDet.FechaDoc = fecha
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = cboTipoDoc.SelectedValue
            '   If dgvCompra.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.CuentaItem = i.Cells(22).Value()
            objDocumentoCompraDet.idItem = i.Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(21).Value()
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            If IsNumeric(i.Cells(7).Value()) Then
                If CDec(i.Cells(7).Value()) > 0 Then
                    objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value()) ' cantidad
                Else
                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoCompraDet.monto1 = 0
                    Else
                        lblEstado.Text = "Ingrese una cantidad mayor a cero del item, " & i.Cells(3).Value()
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                End If
            Else
                lblEstado.Text = "Ingrese una cantidad válida del item, " & i.Cells(3).Value()
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If
            Select Case i.Cells(21).Value()
                Case "GS"
                    objDocumentoCompraDet.unidad1 = Nothing
                    objDocumentoCompraDet.unidad2 = Nothing
                    objDocumentoCompraDet.monto2 = Nothing
                    objDocumentoCompraDet.almacenRef = Nothing
                Case Else
                    objDocumentoCompraDet.unidad1 = i.Cells(6).Value().ToString.Trim
                    objDocumentoCompraDet.unidad2 = i.Cells(4).Value().ToString.Trim 'IDPRESENTACION
                    objDocumentoCompraDet.monto2 = i.Cells(5).Value() ' PRESENTACION
                    objDocumentoCompraDet.almacenRef = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
            End Select
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(9).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(12).Value())

            If IsNumeric(i.Cells(10).Value()) Then
                If CDec(i.Cells(10).Value()) > 0 Then
                    objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
                Else
                    lblEstado.Text = "Ingrese un importe mayor a cero del item, " & i.Cells(3).Value()
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If
            Else
                lblEstado.Text = "Ingrese un importe válido del item, " & i.Cells(3).Value()
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If


            objDocumentoCompraDet.importeUS = CDec(i.Cells(13).Value())


            objDocumentoCompraDet.montokardex = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(i.Cells(15).Value())
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(i.Cells(11).Value())
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = i.Cells(23).Value() '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = i.Cells(29).Value()
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = GlosaCompra()
            objDocumentoCompraDet.situacion = TIPO_SITUACION.ALMACEN_TRANSITO
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
            objDocumentoCompraDet.porcUtimenor = i.Cells(33).Value()
            objDocumentoCompraDet.porcUtimayor = i.Cells(34).Value()
            objDocumentoCompraDet.porcUtigranMayor = i.Cells(35).Value()
            objDocumentoCompraDet.FlagModificaPrecioVenta = i.Cells(36).Value()
            objDocumentoCompraDet.marcaRef = i.Cells(37).Value()
            ListaDetalle.Add(objDocumentoCompraDet)

        Next
        'If chObligacion.Checked = True Then
        '    documentoTributo = DocObligacion()
        'End If
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen()

        DocCaja = ComprobanteCaja()

        Dim xcod As Integer = CompraSA.SaveCompraDirectaSinRecepcion(ndocumento, ListaTotales, DocCaja, Nothing, documentoTributo)
        lblEstado.Text = "compra registrada!"
        'lblEstado.Image = My.Resources.ok4
        GFichaUsuarios.SaldoMN = GFichaUsuarios.SaldoMN - CDec(txtTotalmn.Text)
        GFichaUsuarios.SaldoME = GFichaUsuarios.SaldoME - CDec(txtTotalme.Text)
        Dispose()
    End Sub

    Sub UpdateCompra()
        Dim DocCaja As New documento
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim documentoTributo As New documento
        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim objTotalesDet As New totalesAlmacen()
        Dim objActividadDeleteEO As New totalesAlmacen()
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaDeleteEO As New List(Of totalesAlmacen)
        Dim almacensa As New almacenSA

        Dim ListaDetalle As New List(Of documentocompradetalle)

        'Dim cajaUsuarioMontos As New cajaUsuario
        'Dim cajaEliminarMontos As New cajaUsuario
        'Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        'Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)

        'With cajaUsuarioMontos
        '    .IdDocumentoVenta = lblIdDocumento.Text
        '    .idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        '    .otrosEgresosMN = CDec(txtTotalmn.Text)
        '    .otrosEgresosME = CDec(txtTotalme.Text)
        'End With

        'cajaUsariodetalleBE = New cajaUsuariodetalle
        'cajaUsariodetalleBE.idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        'cajaUsariodetalleBE.tipoDoc = cboTipoDoc.SelectedValue
        'cajaUsariodetalleBE.tipoVenta = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
        'cajaUsariodetalleBE.importeMN = CDec(txtTotalmn.Text)
        'cajaUsariodetalleBE.importeME = CDec(txtTotalme.Text)
        'cajaUsariodetalleListaBE.Add(cajaUsariodetalleBE)
        'cajaUsuarioMontos.cajaUsuariodetalle = cajaUsariodetalleListaBE

        'With cajaEliminarMontos
        '    .idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        '    .IdDocumentoVenta = lblIdDocumento.Text
        'End With

        'Limpiando lista asientos contables
        ListaAsientonTransito = New List(Of asiento)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idDocumento = lblIdDocumento.Text
            .codigoLibro = "1"
            .tipoDoc = cboTipoDoc.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .fechaContable = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = txtProveedor.ValueMember
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
            .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))
            .bi03 = IIf(nudBase3 = 0 Or nudBase3 = "0.00", CDec(0.0), CDec(nudBase3))
            .bi04 = IIf(nudBase4 = 0 Or nudBase4 = "0.00", CDec(0.0), CDec(nudBase4))
            .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
            .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))
            .isc03 = IIf(nudIsc3 = 0 Or nudIsc3 = "0.00", CDec(0.0), CDec(nudIsc3))
            .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
            .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))
            .igv03 = IIf(nudMontoIgv3 = 0 Or nudMontoIgv3 = "0.00", CDec(0.0), CDec(nudMontoIgv3))
            .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
            .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))
            .otc03 = IIf(nudOtrosTributos3 = 0 Or nudOtrosTributos3 = "0.00", CDec(0.0), CDec(nudOtrosTributos3))
            .otc04 = IIf(nudOtrosTributos4 = 0 Or nudOtrosTributos4 = "0.00", CDec(0.0), CDec(nudOtrosTributos4))
            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
            .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))
            .bi03us = IIf(nudBaseus3 = 0 Or nudBaseus3 = "0.00", CDec(0.0), CDec(nudBaseus3))
            .bi04us = IIf(nudBaseus4 = 0 Or nudBaseus4 = "0.00", CDec(0.0), CDec(nudBaseus4))
            .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
            .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))
            .isc03us = IIf(nudIscus3 = 0 Or nudIscus3 = "0.00", CDec(0.0), CDec(nudIscus3))
            .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
            .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))
            .igv03us = IIf(nudMontoIgvus3 = 0 Or nudMontoIgvus3 = "0.00", CDec(0.0), CDec(nudMontoIgvus3))
            .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
            .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))
            .otc03us = IIf(nudOtrosTributosus3 = 0 Or nudOtrosTributosus3 = "0.00", CDec(0.0), CDec(nudOtrosTributosus3))
            .otc04us = IIf(nudOtrosTributosus4 = 0 Or nudOtrosTributosus4 = "0.00", CDec(0.0), CDec(nudOtrosTributosus4))
            '****************************************************************************************************************
            .importeTotal = IIf(txtTotalmn.Text = 0 Or txtTotalmn.Text = "0.00", CDec(0.0), CDec(txtTotalmn.Text))
            .importeUS = IIf(txtTotalme.Text = 0 Or txtTotalme.Text = "0.00", CDec(0.0), CDec(txtTotalme.Text))

            .destino = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = GlosaCompra()
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
            ' .DocumentoSustentado = "S"
            '.situacion = TIPO_SITUACION.ALMACEN_TRANSITO

            If lblSituacion.Text = "ALT" Then
                .situacion = TIPO_SITUACION.ALMACEN_TRANSITO
            ElseIf lblSituacion.Text = "ALTF" Then
                .situacion = TIPO_SITUACION.ALMACEN_TRANSITO_FISICO
            End If

            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'ASIENTO POR LA COMPRA
        If CDec(txtTotalmn.Text) > 0 Then
            AsientoCompra()
        End If

        For Each i As DataGridViewRow In dgvCompra.Rows
            If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                If dgvCompra.Rows(i.Index).Cells(27).Value() = "S" Then
                    Select Case dgvCompra.Rows(i.Index).Cells(21).Value()
                        Case "GS"

                        Case Else
                            AsientoBONIF(dgvCompra.Rows(i.Index).Cells(22).Value(), dgvCompra.Rows(i.Index).Cells(3).Value(),
                                           CDec(dgvCompra.Rows(i.Index).Cells(8).Value()), CDec(dgvCompra.Rows(i.Index).Cells(11).Value()), dgvCompra.Rows(i.Index).Cells(21).Value())
                    End Select


                Else
                    Select Case cboTipoDoc.SelectedValue
                        Case "03", "02"
                            Select Case dgvCompra.Rows(i.Index).Cells(21).Value()
                                Case "GS"

                                Case Else
                                    MV_Item_Transito(dgvCompra.Rows(i.Index).Cells(22).Value(), dgvCompra.Rows(i.Index).Cells(3).Value(),
                                           CDec(dgvCompra.Rows(i.Index).Cells(8).Value()), CDec(dgvCompra.Rows(i.Index).Cells(11).Value()), dgvCompra.Rows(i.Index).Cells(21).Value())
                            End Select



                        Case Else
                            Select Case dgvCompra.Rows(i.Index).Cells(21).Value()
                                Case "GS"

                                Case Else
                                    Select Case dgvCompra.Rows(i.Index).Cells(1).Value()
                                        Case "1"
                                            MV_Item_Transito(dgvCompra.Rows(i.Index).Cells(22).Value(),
                                                              dgvCompra.Rows(i.Index).Cells(3).Value(),
                                                             CDec(dgvCompra.Rows(i.Index).Cells(8).Value()),
                                                             CDec(dgvCompra.Rows(i.Index).Cells(11).Value()),
                                                            dgvCompra.Rows(i.Index).Cells(21).Value())
                                        Case Else
                                            MV_Item_Transito(dgvCompra.Rows(i.Index).Cells(22).Value(),
                                                             dgvCompra.Rows(i.Index).Cells(3).Value(),
                                                             CDec(dgvCompra.Rows(i.Index).Cells(8).Value()),
                                                             CDec(dgvCompra.Rows(i.Index).Cells(11).Value()),
                                                             dgvCompra.Rows(i.Index).Cells(21).Value())
                                    End Select
                            End Select



                    End Select
                End If
            End If

            Select Case dgvCompra.Rows(i.Index).Cells(21).Value()
                Case "GS"

                Case Else
                    If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                        objTotalesDet = New totalesAlmacen
                        objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                        objTotalesDet.SecuenciaDetalle = dgvCompra.Rows(i.Index).Cells(0).Value()
                        objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                        objTotalesDet.TipoDoc = cboTipoDoc.SelectedValue
                        objTotalesDet.Modulo = "N"
                        If IsNothing(dgvCompra.Rows(i.Index).Cells(30).Value()) Then
                            With almacensa.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
                                objTotalesDet.idEstablecimiento = .idEstablecimiento ' almacensa.GetUbicar_almacenPorID(CInt(i.Cells(30).Value())).idEstablecimiento
                                objTotalesDet.idAlmacen = .idAlmacen
                            End With
                        Else
                            With almacensa.GetUbicar_almacenPorID(dgvCompra.Rows(i.Index).Cells(30).Value())
                                objTotalesDet.idEstablecimiento = .idEstablecimiento ' almacensa.GetUbicar_almacenPorID(CInt(i.Cells(30).Value())).idEstablecimiento
                                objTotalesDet.idAlmacen = .idAlmacen
                            End With
                        End If
                        objTotalesDet.origenRecaudo = dgvCompra.Rows(i.Index).Cells(1).Value()
                        objTotalesDet.tipoCambio = "2.77"
                        objTotalesDet.tipoExistencia = dgvCompra.Rows(i.Index).Cells(21).Value()
                        objTotalesDet.idItem = dgvCompra.Rows(i.Index).Cells(2).Value()
                        objTotalesDet.descripcion = dgvCompra.Rows(i.Index).Cells(3).Value()
                        objTotalesDet.idUnidad = dgvCompra.Rows(i.Index).Cells(6).Value()
                        objTotalesDet.unidadMedida = Nothing
                        objTotalesDet.cantidad = CType(dgvCompra.Rows(i.Index).Cells(7).Value(), Decimal)
                        objTotalesDet.precioUnitarioCompra = CType(dgvCompra.Rows(i.Index).Cells(9).Value(), Decimal)
                        If dgvCompra.Rows(i.Index).Cells(27).Value() = "S" Then
                            objTotalesDet.importeSoles = CType(dgvCompra.Rows(i.Index).Cells(8).Value(), Decimal)
                            objTotalesDet.importeDolares = CType(dgvCompra.Rows(i.Index).Cells(11).Value(), Decimal)
                        Else
                            Select Case cboTipoDoc.SelectedValue
                                Case "03", "02"
                                    objTotalesDet.importeSoles = CType(dgvCompra.Rows(i.Index).Cells(8).Value(), Decimal)
                                    objTotalesDet.importeDolares = CType(dgvCompra.Rows(i.Index).Cells(11).Value(), Decimal)
                                Case Else
                                    Select Case dgvCompra.Rows(i.Index).Cells(1).Value()
                                        Case "1"
                                            objTotalesDet.importeSoles = CType(dgvCompra.Rows(i.Index).Cells(8).Value(), Decimal)
                                            objTotalesDet.importeDolares = CType(dgvCompra.Rows(i.Index).Cells(11).Value(), Decimal)
                                        Case Else
                                            objTotalesDet.importeSoles = CType(dgvCompra.Rows(i.Index).Cells(8).Value(), Decimal)
                                            objTotalesDet.importeDolares = CType(dgvCompra.Rows(i.Index).Cells(11).Value(), Decimal)
                                    End Select
                            End Select
                        End If
                        objTotalesDet.montoIsc = 0
                        objTotalesDet.montoIscUS = 0
                        objTotalesDet.Otros = 0
                        objTotalesDet.OtrosUS = 0
                        objTotalesDet.porcentajeUtilidad = 0
                        objTotalesDet.importePorcentaje = 0
                        objTotalesDet.importePorcentajeUS = 0
                        objTotalesDet.precioVenta = 0
                        objTotalesDet.precioVentaUS = 0
                        objTotalesDet.usuarioActualizacion = "NN"
                        objTotalesDet.fechaActualizacion = Date.Now
                        ListaTotales.Add(objTotalesDet)
                    End If

                    If dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Or
                        dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                        Dim almacenVR As New almacen
                        Dim almacenFS As New almacen
                        objActividadDeleteEO = New totalesAlmacen
                        objActividadDeleteEO.Action = Business.Entity.BaseBE.EntityAction.INSERT
                        objActividadDeleteEO.TipoDoc = cboTipoDoc.SelectedValue
                        objActividadDeleteEO.SecuenciaDetalle = dgvCompra.Rows(i.Index).Cells(0).Value()
                        objActividadDeleteEO.idEmpresa = Gempresas.IdEmpresaRuc
                        objActividadDeleteEO.Modulo = "N"
                        With almacensa.GetUbicar_almacenPorID(dgvCompra.Rows(i.Index).Cells(30).Value())
                            objActividadDeleteEO.idEstablecimiento = .idEstablecimiento
                            objActividadDeleteEO.idAlmacen = .idAlmacen ' dgvCompra.Rows(i.Index).
                        End With

                        'almacenFS = almacensa.GetUbicar_almacenPorID(CInt(dgvCompra.Rows(i.Index).Cells(30).Value()))
                        'If Not IsNothing(almacenFS) Then
                        '    Cells(30).Value()
                        'Else
                        '    almacenVR = almacensa.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
                        '    If Not IsNothing(almacenVR) Then
                        '        objActividadDeleteEO.idEstablecimiento = almacenVR.idEstablecimiento
                        '        objActividadDeleteEO.idAlmacen = almacenVR.idAlmacen
                        '    End If

                        'End If
                        objActividadDeleteEO.origenRecaudo = dgvCompra.Rows(i.Index).Cells(1).Value()
                        objActividadDeleteEO.tipoCambio = "2.77"
                        objActividadDeleteEO.tipoExistencia = dgvCompra.Rows(i.Index).Cells(21).Value()
                        objActividadDeleteEO.idItem = dgvCompra.Rows(i.Index).Cells(2).Value()
                        objActividadDeleteEO.descripcion = dgvCompra.Rows(i.Index).Cells(3).Value()
                        ListaDeleteEO.Add(objActividadDeleteEO)
                    End If
            End Select

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = fecha
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = cboTipoDoc.SelectedValue


            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.secuencia = dgvCompra.Rows(i.Index).Cells(0).Value()
            objDocumentoCompraDet.destino = dgvCompra.Rows(i.Index).Cells(1).Value()
            objDocumentoCompraDet.CuentaItem = dgvCompra.Rows(i.Index).Cells(22).Value()
            objDocumentoCompraDet.idItem = dgvCompra.Rows(i.Index).Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = dgvCompra.Rows(i.Index).Cells(21).Value()
            objDocumentoCompraDet.descripcionItem = dgvCompra.Rows(i.Index).Cells(3).Value()

            objDocumentoCompraDet.monto1 = CDec(dgvCompra.Rows(i.Index).Cells(7).Value())
            Select Case dgvCompra.Rows(i.Index).Cells(21).Value()
                Case "GS"
                    objDocumentoCompraDet.unidad1 = Nothing
                    objDocumentoCompraDet.unidad2 = Nothing
                    objDocumentoCompraDet.monto2 = Nothing
                    objDocumentoCompraDet.almacenRef = Nothing
                Case Else
                    objDocumentoCompraDet.unidad1 = dgvCompra.Rows(i.Index).Cells(6).Value()
                    objDocumentoCompraDet.unidad2 = dgvCompra.Rows(i.Index).Cells(4).Value().ToString.Trim 'IDPRESENTACION
                    objDocumentoCompraDet.monto2 = dgvCompra.Rows(i.Index).Cells(5).Value() ' PRESENTACION
                    If Not IsNothing(dgvCompra.Rows(i.Index).Cells(30).Value()) Then
                        objDocumentoCompraDet.almacenRef = CInt(dgvCompra.Rows(i.Index).Cells(30).Value())
                    Else
                        objDocumentoCompraDet.almacenRef = almacensa.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
                    End If
            End Select
            objDocumentoCompraDet.precioUnitario = CDec(dgvCompra.Rows(i.Index).Cells(9).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(dgvCompra.Rows(i.Index).Cells(12).Value())
            objDocumentoCompraDet.importe = CDec(dgvCompra.Rows(i.Index).Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(dgvCompra.Rows(i.Index).Cells(13).Value())
            objDocumentoCompraDet.montokardex = CDec(dgvCompra.Rows(i.Index).Cells(8).Value())
            objDocumentoCompraDet.montoIsc = 0 ' CDec(dgvCompra.Rows(i.Index).Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(dgvCompra.Rows(i.Index).Cells(15).Value())
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(dgvCompra.Rows(i.Index).Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(dgvCompra.Rows(i.Index).Cells(11).Value())
            objDocumentoCompraDet.montoIscUS = 0 'CDec(dgvCompra.Rows(i.Index).Cells(17).Value())
            objDocumentoCompraDet.montoIgvUS = CDec(dgvCompra.Rows(i.Index).Cells(18).Value())
            objDocumentoCompraDet.otrosTributosUS = 0 ' CDec(dgvCompra.Rows(i.Index).Cells(19).Value())
            objDocumentoCompraDet.preEvento = dgvCompra.Rows(i.Index).Cells(23).Value()
            objDocumentoCompraDet.bonificacion = dgvCompra.Rows(i.Index).Cells(29).Value()
            If dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            '**********************************************************************************


            objDocumentoCompraDet.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing
            objDocumentoCompraDet.situacion = TIPO_SITUACION.ALMACEN_TRANSITO
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
            objDocumentoCompraDet.Glosa = GlosaCompra()
            ListaDetalle.Add(objDocumentoCompraDet)
        Next
        ' documentoTributo = DocObligacion()

        If Panel8.Visible = True Then
            GuiaRemision(ndocumento)
        End If

        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        DocCaja = ComprobanteCaja()
        CompraSA.UpdateCompraDirectaSinRecepcion(ndocumento, ListaTotales, ListaDeleteEO, DocCaja, Nothing, Nothing)
        lblEstado.Text = "compra modificada!"
        ' lblEstado.Image = My.Resources.ok4
        Dispose()
    End Sub
#End Region

#Region "VALIDA USUARIO CAJA"
    Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        GFichaUsuarios = New GFichaUsuario
        Select Case ManipulacionEstado
            Case ENTITY_ACTIONS.INSERT

                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    With frmFichaUsuarioCaja
                        ModuloAppx = ModuloSistema.CAJA
                        .lblNivel.Text = "Caja"
                        .lblEstadoCaja.Visible = True
                        '.GroupBox1.Visible = True
                        '.GroupBox2.Visible = True
                        '.GroupBox4.Visible = True
                        '.cboMoneda.Visible = True
                        .Timer1.Enabled = True
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        If IsNothing(GFichaUsuarios.NombrePersona) Then
                            Return False
                        Else
                            Return True
                        End If
                    End With

                End If
            Case ENTITY_ACTIONS.UPDATE
                With frmFichaUsuarioCaja
                    ModuloAppx = ModuloSistema.CAJA
                    .lblNivel.Text = "Caja"
                    .lblEstadoCaja.Visible = True
                    '.GroupBox1.Visible = True
                    '.GroupBox2.Visible = True
                    '.GroupBox4.Visible = True
                    '.cboMoneda.Visible = True
                    .Timer1.Enabled = False
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .StartPosition = FormStartPosition.CenterParent
                    ' .UbicarUsuarioCaja(intIdDocumento, "COMPRA")
                    .ShowDialog()
                    If IsNothing(GFichaUsuarios.NombrePersona) Then
                        Return False
                    Else
                        Return True
                    End If
                End With
        End Select
        Return True

    End Function
#End Region

    Private Sub frmCompraPagadaSinRecepcion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCompraPagadaSinRecepcion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ListaAsientonTransito = New List(Of asiento)
      
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        toolTip = New Popup(UserControl1)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracion(Sys.Inicio)
        cboTipoDoc.SelectedIndex = 0

        toolTipCaja = New Popup(UcConfigCaja)
        toolTipCaja.AutoClose = False
        toolTipCaja.FocusOnOpen = False
        toolTipCaja.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracionCaja(Sys.Inicio)

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            If Not IsNothing(GFichaUsuarios.NombrePersona) Then

            Else
                dockingClientPanel1.Enabled = False
                '   btnConfigCaja_Click(sender, e)
            End If
            Panel8.Visible = False
            GradientPanel3.Visible = False
            cboMoneda.SelectedValue = 1
        Else
            If DocumentoCompraSA.TieneItemsEnAV(CInt(lblIdDocumento.Text)) = True Then
                Panel8.Visible = False
                GradientPanel3.Visible = False
            Else
                Panel8.Visible = True
                GradientPanel3.Visible = True
            End If

        End If
    End Sub

    Private Sub Panel3_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub popupControlContainer1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles popupControlContainer1.Paint

    End Sub

    Private Sub lblPerido_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        'Dim p As Point = e.Location
        'p.Offset(lblPerido.Bounds.Location)
        'ContextMenuStrip1.Show(ToolStrip3.PointToScreen(p))
        'cboPeriodo.DroppedDown = True
    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Select Case cboPeriodo.Text
            Case "ENERO"
                PeriodoGeneral = "01" & "/" & PeriodoGeneral
            Case "FEBRERO"
                PeriodoGeneral = "02" & "/" & PeriodoGeneral
            Case "MARZO"
                PeriodoGeneral = "03" & "/" & PeriodoGeneral
            Case "ABRIL"
                PeriodoGeneral = "04" & "/" & PeriodoGeneral
            Case "MAYO"
                PeriodoGeneral = "05" & "/" & PeriodoGeneral
            Case "JUNIO"
                PeriodoGeneral = "06" & "/" & PeriodoGeneral
            Case "JULIO"
                PeriodoGeneral = "07" & "/" & PeriodoGeneral
            Case "AGOSTO"
                PeriodoGeneral = "08" & "/" & PeriodoGeneral
            Case "SETIEMBRE"
                PeriodoGeneral = "09" & "/" & PeriodoGeneral
            Case "OCTUBRE"
                PeriodoGeneral = "10" & "/" & PeriodoGeneral
            Case "NOVIEMBRE"
                PeriodoGeneral = "11" & "/" & PeriodoGeneral
            Case "DICIEMBRE"
                PeriodoGeneral = "12" & "/" & PeriodoGeneral
        End Select
        '    ListaCompras(PeriodoGeneral)
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub dropDownBtn_Click(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        Me.popupControlContainer1.ParentControl = Me.txtProveedor
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub cancel_Click(sender As System.Object, e As System.EventArgs) Handles cancel.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs) Handles OK.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        ' Me.popupTextBox.Text = Me.sourceTextBox.Text
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click

    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub


    Private Sub btnConfiguracion_Click(sender As System.Object, e As System.EventArgs) Handles btnConfiguracion.Click
        InfoConfiguracion(Sys.Proceso)
    End Sub

    Private Sub btnConfiguracion_MouseLeave(sender As Object, e As System.EventArgs) Handles btnConfiguracion.MouseLeave
        toolTip.Close()
    End Sub

    Enum Sys
        Inicio
        Proceso
    End Enum
    Sub InfoConfiguracion(n As Sys)
        If Not IsNothing(GConfiguracion) Then
            If Not IsNothing(GConfiguracion.NomModulo) Then
                UserControl1.lblCodigo.Text = "C3"
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

    Sub InfoConfiguracionCaja(n As Sys)

        If Not IsNothing(GFichaUsuarios) Then
            If Not IsNothing(GFichaUsuarios.NombrePersona) Then


                UcConfigCaja.lblidPersona.Text = GFichaUsuarios.IdPersona
                UcConfigCaja.lblEncargado.Text = GFichaUsuarios.NombrePersona
                UcConfigCaja.lblCajaHabilitada.Text = GFichaUsuarios.NomCajaDestinb
                UcConfigCaja.lblMoneda.Text = GFichaUsuarios.Moneda
                UcConfigCaja.lblFondoMN.Text = GFichaUsuarios.FondoMN
                UcConfigCaja.lblFondoME.Text = GFichaUsuarios.FondoME

                ' position the tooltip with its stem towards the right end of the button
                If n = Sys.Inicio Then

                ElseIf n = Sys.Proceso Then
                    toolTipCaja.Show(btnConfigCaja)
                End If

            End If
        End If
    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumero.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try

    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                If chFormato.Checked = True Then
                    txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

                        If Len(txtSerie.Text) <= 2 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

                        ElseIf Len(txtSerie.Text) <= 3 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

                        ElseIf Len(txtSerie.Text) <= 4 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

                        ElseIf Len(txtSerie.Text) <= 5 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

                        End If
                    End If
                Else

                    txtSerie.Select()
                    txtSerie.Focus()
                    txtSerie.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerie.Select()
                txtSerie.Focus()
                txtSerie.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtProveedor.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try

    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumero.LostFocus
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                If chFormato.Checked = True Then
                    txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

                End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()

            lblEstado.Text = "error"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)



        End Try
    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub chFormato_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles chFormato.CheckStateChanged
        If chFormato.Checked = True Then
            If txtSerie.Text.Trim.Length > 0 Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
            End If
            If txtNumero.Text.Trim.Length > 0 Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
            End If
        Else
            If txtSerie.Text.Trim.Length > 0 Then
                txtSerie.Text = String.Format("{0:0}", Convert.ToInt32(txtSerie.Text))
            End If
            If txtNumero.Text.Trim.Length > 0 Then
                txtNumero.Text = String.Format("{0:0}", Convert.ToInt32(txtNumero.Text))
            End If
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub ButtonCategoria_Click(sender As System.Object, e As System.EventArgs) Handles ButtonCategoria.Click
        Me.PopupControlContainer2.Font = New Font("Tahoma", 8)
        Me.PopupControlContainer2.Size = New Size(238, 110)
        Me.PopupControlContainer2.ParentControl = Me.txtCategoria
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub PopupControlContainer2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles PopupControlContainer2.Paint

    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
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

    Private Sub ButtonAdv2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv2.Click
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        If cboTipoExistencia.SelectedIndex > -1 Then
            If txtCategoria.Text.Trim.Length > 0 Then
                ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanging(sender As Object, e As Syncfusion.Windows.Forms.Tools.SelectedIndexChangingArgs) Handles cboTipoExistencia.SelectedIndexChanging
        'If cboTipoExistencia.SelectedIndex > -1 Then
        '    If txtCategoria.Text.Trim.Length > 0 Then
        '        ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
        '    End If
        'End If
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        If lsvListadoItems.SelectedItems.Count > 0 Then
            With objInsumo.InvocarProductoID(CInt(lsvListadoItems.SelectedItems(0).SubItems(0).Text))
                dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
                                     .presentacion,
                                        tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                      .tipoExistencia, .cuenta, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                      Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, .marcaRef)


                Dim caja As New ListadoPrecioSA
                Dim cajadet As New listadoPrecios
                Try
                    cajadet = caja.UbicarPrecioExistente(.codigodetalle)
                    If cajadet.vcmenor > 0 Then
                        lblEstado.Text = "tiene precio configurado"
                        dgvCompra.Item("colModifiPrecio", dgvCompra.Rows.Count - 1).Style.BackColor = Color.GreenYellow
                        '  dgvCompra.Columns("colModifiPrecio").DefaultCellStyle.BackColor = Color.GreenYellow
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        'ulti
                    End If
                Catch
                    dgvCompra.Item("colModifiPrecio", dgvCompra.Rows.Count - 1).Style.BackColor = Color.Red
                    'dgvCompra.Columns("colModifiPrecio").DefaultCellStyle.BackColor = Color.Red
                    lblEstado.Text = "aun no tiene un precio"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End Try
                'm
            End With
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub dgvCompra_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellClick

        If e.RowIndex > -1 Then
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
        End If
    End Sub

    Private Sub dgvCompra_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompra.CellContentClick

    End Sub

    Private Sub dgvCompra_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompra.CellEndEdit
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
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
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
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            Else
                colMN = dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value
            End If

            Dim colME As Decimal = Math.Round(CDec(dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value) / CDec(txtTipoCambio.Value), 2)
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
                dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2")
            ElseIf colCantidad = 0 Then
                'colIGV = Math.Round(colMN * 0.18, 2) 'Math.Round((colMN / 1.18) * 0.18, 2)
                colIGV = Math.Round(colMN * (txtIgv.Value / 100), 2)
                'colIGV_ME = Math.Round(colME * 0.18, 2) ' Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)
                colIGV_ME = Math.Round(colME * (txtIgv.Value), 2)


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

            Select Case cboTipoDoc.SelectedValue
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

    Private Sub dgvCompra_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCompra.CellFormatting
        If e.RowIndex > -1 Then
            'If txtAlmacen.Text.Trim.Length > 0 Then
            '    If (Tag = 1) Then
            '        If Not dgvCompra.Rows(e.RowIndex).Cells(21).Value = "GS" Then
            '            'dgvCompra.Rows(e.RowIndex).Cells(30).Value = txtAlmacen.ValueMember
            '            'dgvCompra.Rows(e.RowIndex).Cells(31).Value = txtAlmacen.Text
            '        Else
            '            dgvCompra.Rows(e.RowIndex).Cells(30).Value = String.Empty
            '            dgvCompra.Rows(e.RowIndex).Cells(31).Value = String.Empty
            '        End If
            '    End If
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

    Private Sub dgvCompra_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompra.CellValueChanged
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

    Private Sub dgvCompra_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvCompra.CurrentCellDirtyStateChanged
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

    Private Sub dgvCompra_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCompra.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvCompra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvCompra.KeyDown
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
                            'If conteo = 1 Then
                            '    Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            'Else
                            '    Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            'End If
                        End If
                    Case 3
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(8, Me.dgvCompra.CurrentCell.RowIndex)
                        'Case 10 Or 11
                        '    Me.dgvCompra.CurrentCell = Me.dgvCompra(23, Me.dgvCompra.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvCompra_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvCompra.RowPostPaint
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

    Private Sub btnInfoCaja_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnConfigCaja_Click(sender As System.Object, e As System.EventArgs) Handles btnConfigCaja.Click
        If Not IsNothing(GFichaUsuarios.NombrePersona) Then
            InfoConfiguracionCaja(Sys.Proceso)
        Else
            With frmFichaUsuarioCaja
                ModuloAppx = ModuloSistema.CAJA
                .lblNivel.Text = "Caja"
                .lblEstadoCaja.Visible = True
                '.GroupBox1.Visible = True
                '.GroupBox2.Visible = True
                '.GroupBox4.Visible = True
                '.cboMoneda.Visible = True
                .Timer1.Enabled = True
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    dockingClientPanel1.Enabled = False
                Else
                    Dim cfecha As Date = Date.Now.Day & "/" & PeriodoGeneral
                    dockingClientPanel1.Enabled = True
                    ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    Panel8.Visible = False
                    GradientPanel3.Visible = False
                    cboMoneda.SelectedValue = 1
                End If
            End With
        End If
    End Sub

    Private Sub btnConfigCaja_MouseLeave(sender As Object, e As System.EventArgs) Handles btnConfigCaja.MouseLeave
        toolTipCaja.Close()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        'glosa()
        'CALCULO_TRIBUTOS()
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieGuia.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumeroGuia.Select()
        End If
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerieGuia.LostFocus
        Try
            If txtSerieGuia.Text.Trim.Length > 0 Then
                If chFormato.Checked = True Then
                    txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                End If
            End If

        Catch ex As Exception
            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerieGuia.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1)) = True Then

                        If Len(txtSerieGuia.Text) <= 2 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1))

                        ElseIf Len(txtSerieGuia.Text) <= 3 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 2))

                        ElseIf Len(txtSerieGuia.Text) <= 4 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 3))

                        ElseIf Len(txtSerieGuia.Text) <= 5 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 4))

                        End If
                    End If
                Else

                    txtSerieGuia.Select()
                    txtSerieGuia.Focus()
                    txtSerieGuia.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If
            Else

                txtSerieGuia.Select()
                txtSerieGuia.Focus()
                txtSerieGuia.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

            End If
        End Try
    End Sub

    Private Sub txtSerieGuia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerieGuia.TextChanged

    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroGuia.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumeroGuia.LostFocus
        Try
            If txtNumeroGuia.Text.Trim.Length > 0 Then
                txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
            End If
        Catch ex As Exception
            txtNumeroGuia.Select()
            txtNumeroGuia.Focus()
            txtNumeroGuia.Clear()
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub txtNumeroGuia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroGuia.TextChanged

    End Sub
    Sub CALCULO_TRIBUTOS()
        Dim valPorcentaje As Decimal = 0
        valPorcentaje = nudPorcentajeTributo.Value / 100

        If valPorcentaje > 0 Then
            If CDec(txtTotalmn.Text) > 0 Then
                nudImporteMN.Text = CDec(txtTotalmn.Text) * valPorcentaje
                nudImporteMe.Text = CDec(txtTotalme.Text) * valPorcentaje
            End If
        Else
            nudImporteMN.Text = 0
            nudImporteMe.Text = 0
        End If

    End Sub
    Private Sub chObligacion_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles chObligacion.CheckStateChanged
        If chObligacion.Checked = True Then

            rbDetraccion.Visible = True
            rbRetencion.Visible = True
            rbPercepcion.Visible = True
            nudPorcentajeTributo.Visible = True
            Label22.Visible = True
            nudImporteMN.Visible = True
            nudImporteMe.Visible = True
        Else

            rbDetraccion.Visible = False
            rbRetencion.Visible = False
            rbPercepcion.Visible = False
            nudPorcentajeTributo.Visible = False
            Label22.Visible = False
            nudImporteMN.Visible = False
            nudImporteMe.Visible = False
        End If
    End Sub

    Private Sub nudPorcentajeTributo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudPorcentajeTributo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CALCULO_TRIBUTOS()
        End If
    End Sub

    Private Sub nudPorcentajeTributo_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPorcentajeTributo.ValueChanged
        '    CALCULO_TRIBUTOS()
    End Sub

    Private Sub rbRetencion_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbRetencion.CheckChanged
        If rbRetencion.Checked = True Then
            CALCULO_TRIBUTOS()
        End If
    End Sub

    Private Sub rbDetraccion_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbDetraccion.CheckChanged
        If rbDetraccion.Checked = True Then
            CALCULO_TRIBUTOS()
        End If
    End Sub

    Private Sub rbPercepcion_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbPercepcion.CheckChanged
        If rbPercepcion.Checked = True Then
            CALCULO_TRIBUTOS()
        End If
    End Sub

    Private Sub txtTipoCambio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtIgv.Select()
        End If
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub txtFechaComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaComprobante.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or _
            e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
            cboTipoDoc.Select()
        End If
    End Sub

    Private Sub txtFechaComprobante_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaComprobante.ValueChanged

    End Sub

    Private Sub cboTipoDoc_Click(sender As System.Object, e As System.EventArgs) Handles cboTipoDoc.Click
        '  If cboTipoDoc.SelectedIndex > -1 Then

        '  End If
    End Sub

    Private Sub cboTipoDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipoDoc.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtSerie.Select()
        End If
    End Sub

    Private Sub btnVer_Click(sender As System.Object, e As System.EventArgs) Handles btnVer.Click
        dockingManager1.SetDockVisibility(Panel2, True)
        dockingManager1.SetDockVisibility(PanelServicios, True)
    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub cboCuentas_Click(sender As System.Object, e As System.EventArgs) Handles cboCuentas.Click

    End Sub

    Private Sub cboCuentas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCuentas.SelectedIndexChanged
        If String.IsNullOrEmpty(cboCuentas.ValueMember.ToString) Then
            Exit Sub
        Else
            If cboCuentas.Text = "" Then
                cboCuentas.Text = ""
                txtServicio.Text = ""
            Else
                txtServicio.Text = cboCuentas.SelectedValue
                Select Case txtServicio.Text
                    Case "18"
                        CargarGastoCuentaPAdreLIke()
                    Case Else
                        CargarListaGasto()
                End Select
            End If
        End If
    End Sub

    Private Sub cboCuentas_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCuentas.SelectedValueChanged

    End Sub

    Private Sub lsvServicios_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvServicios.MouseDoubleClick
        If lsvServicios.SelectedItems.Count > 0 Then
            Dim n As New GInsumo()
            Dim objInsumo As GInsumo = GInsumo.InstanceSingle
            objInsumo.Clear()
            objInsumo.origenProducto = "1"
            objInsumo.IdActividadRecurso = Nothing ' lsvListadoItems.SelectedItems(0).SubItems(7).Text
            objInsumo.IdInsumo = lsvServicios.SelectedItems(0).SubItems(0).Text
            objInsumo.descripcionItem = lsvServicios.SelectedItems(0).SubItems(1).Text
            objInsumo.tipoExistencia = TipoRecurso.SERVICIO
            objInsumo.unidad1 = 0.0
            objInsumo.Cantidad = 1
            objInsumo.PU = 0.0
            objInsumo.Total = 0.0
            objInsumo.cuenta = lsvServicios.SelectedItems(0).SubItems(0).Text

            dgvCompra.Rows.Add(0, "1", objInsumo.IdInsumo, objInsumo.descripcionItem,
                                   objInsumo.presentacion,
                                       objInsumo.Nombrepresentacion, objInsumo.unidad1, objInsumo.Cantidad, objInsumo.PU, objInsumo.PU, objInsumo.Total, objInsumo.Total, 0,
                                    0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                    objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso)


        End If
    End Sub

    Private Sub lblPerido_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub cboMoneda_Click(sender As System.Object, e As System.EventArgs) Handles cboMoneda.Click

    End Sub

    Private Sub cboMoneda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMoneda.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            dropDownBtn.Focus()
        End If
    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstCategoria.SelectedIndexChanged

    End Sub

    Private Sub cboTipoExistencia_Click(sender As System.Object, e As System.EventArgs) Handles cboTipoExistencia.Click

    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvListadoItems.SelectedIndexChanged

    End Sub

    Private Sub lsvServicios_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvServicios.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        dockingManager1.SetDockVisibility(PanelNuevoItem, False)
        dockingManager1.SetDockVisibility(Panel2, True)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor
        If Not txtProductoNew.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del producto"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        GrabarItemEstablec()
        'dockingManager1.SetDockVisibility(PanelNuevoItem, False)
        'dockingManager1.SetDockVisibility(Panel2, True)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AutoComplete1_AutoCompleteItemSelected(sender As System.Object, args As Syncfusion.Windows.Forms.Tools.AutoCompleteItemEventArgs) Handles AutoComplete1.AutoCompleteItemSelected
        Dim itemText As String = args.ItemArray(1).ToString()
        Dim eventlogmessage As String = [String].Format("Event: {0} Item: {1}", "AutoCompleteItemSelected", itemText)
        txtNomUnidad.Text = itemText
        txtNomUnidad.ValueMember = args.ItemArray(0).ToString()
    End Sub

    Private Sub AutoComplete1_AutoCompleteItemBrowsed(sender As System.Object, args As Syncfusion.Windows.Forms.Tools.AutoCompleteItemEventArgs) Handles AutoComplete1.AutoCompleteItemBrowsed
        Dim itemText As String = args.ItemArray(1).ToString()
        Dim eventlogmessage As String = [String].Format("Event: {0} Item: {1}", "AutoCompleteItemBrowsed", itemText)
    End Sub

    Private Sub btnNuevoProd_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoProd.Click



        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim catSA As New itemSA
        Dim cat As New item
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        ' If txtAlmacen.Text.Trim.Length > 0 Then
        If txtCategoria.Text.Trim.Length > 0 Then
            With frmNuevaExistencia
                .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                .UCNuenExistencia.cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If datos.Count > 0 Then
                    If MessageBoxAdv.Show("Desea agregar el producto a la canasta de compras?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        If datos(0).Cuenta = "Grabado" Then
                            'If txtAlmacen.Text.Trim.Length > 0 Then

                            '  If lsvListadoItems.SelectedItems.Count > 0 Then
                            cat = catSA.UbicarCategoriaPorID(datos(0).IdEvento)
                            With objInsumo.InvocarProductoID(CInt(datos(0).ID))
                                dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
                                                     .presentacion,
                                                        tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
                                                      0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                                      .tipoExistencia, .cuenta, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                                      Nothing, 0, "NULL", Nothing,
                                                      cat.utilidad, cat.utilidadmayor, cat.utilidadgranmayor)
                                Tag = 1
                            End With

                        End If
                    End If


                End If
            End With

        Else
            lblEstado.Text = "Debe elegir una clasificacion"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If


        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub AutoComplete2_AutoCompleteItemSelected(sender As System.Object, args As Syncfusion.Windows.Forms.Tools.AutoCompleteItemEventArgs) Handles AutoComplete2.AutoCompleteItemSelected
        Dim itemText As String = args.ItemArray(1).ToString()
        Dim eventlogmessage As String = [String].Format("Event: {0} Item: {1}", "AutoCompleteItemSelected", itemText)
        txtPresentacion.Text = itemText
        txtPresentacion.ValueMember = args.ItemArray(0).ToString()
    End Sub

    Private Sub AutoComplete2_AutoCompleteItemBrowsed(sender As System.Object, args As Syncfusion.Windows.Forms.Tools.AutoCompleteItemEventArgs) Handles AutoComplete2.AutoCompleteItemBrowsed
        Dim itemText As String = args.ItemArray(1).ToString()
        Dim eventlogmessage As String = [String].Format("Event: {0} Item: {1}", "AutoCompleteItemBrowsed", itemText)
    End Sub

    Private Sub btnGRabarProv_Click(sender As System.Object, e As System.EventArgs) Handles btnGRabarProv.Click
        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del proveedor"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 248)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del proveedor"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
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
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
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

    Private Sub btnCancelarProv_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarProv.Click
        Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub btnRuc_Click(sender As System.Object, e As System.EventArgs) Handles btnRuc.Click
        btnRuc.Checked = True
        If btnRuc.Checked = True Then
            btnDni.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnDni_Click(sender As System.Object, e As System.EventArgs) Handles btnDni.Click
        btnDni.Checked = True
        If btnDni.Checked = True Then
            btnRuc.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnPassport_Click(sender As System.Object, e As System.EventArgs) Handles btnPassport.Click
        btnPassport.Checked = True
        If btnPassport.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnCarnetEx_Click(sender As System.Object, e As System.EventArgs) Handles btnCarnetEx.Click
        btnCarnetEx.Checked = True
        If btnCarnetEx.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnPassport.Checked = False
        End If
    End Sub

    Private Sub rbNatural_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbNatural.CheckChanged
        If rbNatural.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()
            Label31.Visible = True
            Label30.Text = "Nombres:"
        End If
    End Sub

    Private Sub rbJuridico_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbJuridico.CheckChanged
        If rbJuridico.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            Label31.Visible = False
            Label30.Text = "Nombre o Razón Social:"
        End If
    End Sub

    Private Sub pcProveedor_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcProveedor.BeforePopup
        Me.pcProveedor.BackColor = Color.White
    End Sub

    Private Sub pcProveedor_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcProveedor.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDocProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del proveedor"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 248)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtDocProveedor.Select()
                Exit Sub
            End If

            If Not txtNomProv.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del proveedor"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
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
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    pcProveedor.Font = New Font("Tahoma", 8)
                    pcProveedor.Size = New Size(321, 248)
                    Me.pcProveedor.ParentControl = Me.txtProveedor
                    Me.pcProveedor.ShowPopup(Point.Empty)
                    txtApePat.Select()
                    Exit Sub
                End If
            End If
            If btnGRabarProv.Tag = "G" Then
                InsertProveedor()
                btnGRabarProv.Tag = "N"
            Else
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 248)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        txtDocProveedor.Clear()
        txtNomProv.Clear()
        txtApePat.Clear()
        pcProveedor.Font = New Font("Tahoma", 8)
        pcProveedor.Size = New Size(321, 248)
        Me.pcProveedor.ParentControl = Me.txtProveedor
        Me.pcProveedor.ShowPopup(Point.Empty)
    End Sub

    Private Sub btmGrabarClasificacion_Click(sender As System.Object, e As System.EventArgs) Handles btmGrabarClasificacion.Click
        If Not txtNewClasificacion.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre de la clasificación"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            txtNewClasificacion.Select()
            Exit Sub
        End If
        If Not nupUtilidad.Value > 0 Then
            lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            nupUtilidad.Select()
            Exit Sub
        End If
        If Not nupUtilidadMayor.Value > 0 Then
            lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            nupUtilidadMayor.Select()
            Exit Sub
        End If
        If Not nupUtilidadGranMayor.Value > 0 Then
            lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
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

    Private Sub ButtonAdv6_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv6.Click
        Me.pcClasificacion.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcClasificacion_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcClasificacion.BeforePopup
        Me.pcClasificacion.BackColor = Color.White
    End Sub

    Private Sub pcClasificacion_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcClasificacion.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtNewClasificacion.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre de la clasificación"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(337, 150)
                Me.pcClasificacion.ParentControl = Me.txtCategoria
                Me.pcClasificacion.ShowPopup(Point.Empty)
                txtNewClasificacion.Select()
                Exit Sub
            End If

            If Not nupUtilidad.Value > 0 Then
                lblEstado.Text = "Ingrese la utilidad de la clasificaión!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(337, 150)
                Me.pcClasificacion.ParentControl = Me.txtCategoria
                Me.pcClasificacion.ShowPopup(Point.Empty)
                nupUtilidad.Select()
                Exit Sub
            End If

            If btmGrabarClasificacion.Tag = "G" Then
                GrabarCategoria()
                btmGrabarClasificacion.Tag = "N"
            Else
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(337, 150)
                Me.pcClasificacion.ParentControl = Me.txtCategoria
                Me.pcClasificacion.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor
        pcClasificacion.Font = New Font("Tahoma", 8)
        pcClasificacion.Size = New Size(337, 150)
        Me.pcClasificacion.ParentControl = Me.txtCategoria
        Me.pcClasificacion.ShowPopup(Point.Empty)
        txtNewClasificacion.Clear()
        txtNewClasificacion.Select()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PopupControlContainer2_Popup(sender As Object, e As EventArgs) Handles PopupControlContainer2.Popup
        lstCategoria.Focus()
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

    Private Sub txtRuc_TextChanged(sender As Object, e As EventArgs) Handles txtRuc.TextChanged

    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            '    If txtProveedor.Text.Trim.Length > 0 Then
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            '   End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub Panel3_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListaMercaderias(cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"

                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"

            End If

            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"

            End If

            If Not IsNothing(GConfiguracion.NomModulo) Then
                Select Case GConfiguracion.TipoConfiguracion
                    Case "M"
                        If Not txtNumero.Text.Trim.Length > 0 Then
                            lblEstado.Text = "Ingresar un número de comprobante válido"
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        Else
                            lblEstado.Text = "Done número comprobante"

                        End If
                    Case "P"

                End Select
            End If



            '***********************************************************************
            If dgvCompra.Rows.Count > 0 Then

                Me.lblEstado.Text = "Done!"
                If (txtTotalmn.Text <= GFichaUsuarios.FondoMN) Then
                    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                        If (CDec(txtTotalmn.Text) <= CDec(GFichaUsuarios.FondoMN)) Then
                            Grabar()
                        Else
                            lblEstado.Text = "La compra debe ser menor a S/." & GFichaUsuarios.FondoMN
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)
                        End If
                    Else
                        Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                        If Filas > 0 Then
                            If (CDec(txtTotalmn.Text) <= CDec(GFichaUsuarios.FondoMN + ReferenciaFondoMN)) Then
                                UpdateCompra()
                            Else
                                lblEstado.Text = "No debe exceder el monto de S/." & CDec(GFichaUsuarios.FondoMN + ReferenciaFondoMN)
                                Timer1.Enabled = True
                                PanelError.Visible = True
                                TiempoEjecutar(10)
                            End If
                        Else

                            Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)

                        End If
                    End If
                Else

                    Me.lblEstado.Text = "La compra no debe exceder el monto de caja"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                End If
            Else

                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            'Limpiando lista asientos contables
            ListaAsientonTransito = New List(Of asiento)

        End Try
        Me.Cursor = Cursors.Arrow
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

    Private Sub txtNewClasificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNewClasificacion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                nupUtilidad.Select()
                nupUtilidad.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNewClasificacion_TextChanged(sender As Object, e As EventArgs) Handles txtNewClasificacion.TextChanged

    End Sub

    Private Sub txtIgv_ValueChanged(sender As Object, e As EventArgs) Handles txtIgv.ValueChanged
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub
End Class