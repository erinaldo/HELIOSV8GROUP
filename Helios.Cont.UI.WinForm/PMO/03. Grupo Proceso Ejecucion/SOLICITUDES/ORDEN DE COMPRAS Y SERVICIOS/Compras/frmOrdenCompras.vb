Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools
Public Class frmOrdenCompras
    Inherits frmMaster

    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Public Property ListaTipoCambio As New List(Of TipoCambioSunatV2)
    Private sToolTip As SuperToolTip
    Public lblIdDocumento As Integer
    Dim listaSubCategoria As New List(Of item)

    Dim ListaDetalleEntrega As New List(Of documentoOtrosDatos)

    Private chk As Boolean, check As Boolean = False

    Private ht As New ArrayList()
    Public strTipo As String

    Private conteoCompras As Integer

    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal

        Public Property BaseMN2() As Decimal
        Public Property BaseME2() As Decimal

        Public Property BaseMN3() As Decimal
        Public Property BaseME3() As Decimal

        Public Property IgvMN() As Decimal
        Public Property IgvME() As Decimal
        Public Property TotalMN() As Decimal
        Public Property TotalME() As Decimal

        Public Property base1() As Decimal
        Public Property base1me() As Decimal
        Public Property base2() As Decimal
        Public Property base2me() As Decimal
        Public Property MontoIgv1() As Decimal
        Public Property MontoIgv1me() As Decimal
        Public Property MontoIgv2() As Decimal
        Public Property MontoIgv2me() As Decimal

        Public Property PercepcionMN() As Decimal
        Public Property PercepcionME() As Decimal

        Public Sub New()
            BaseMN = 0
            BaseME = 0
            BaseMN2 = 0
            BaseME2 = 0
            BaseMN3 = 0
            BaseME3 = 0
            IgvMN = 0
            IgvME = 0
            TotalMN = 0
            TotalME = 0
            base1 = 0
            base1me = 0
            base2 = 0
            base2me = 0
            MontoIgv1 = 0
            MontoIgv1me = 0
            MontoIgv2 = 0
            MontoIgv2me = 0
            PercepcionMN = 0
            PercepcionME = 0
        End Sub
    End Class

    Public fecha As DateTime

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompras)
        Loadcontroles()
        GetTableGrid()
        'ConfiguracionInicio()
        GConfiguracion = New GConfiguracionModulo
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OC", Me.Text, GEstableciento.IdEstablecimiento)
        'txtTipoCambio.DecimalValue = TmpTipoCambio
        Recomendacion()
        txtFecha.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)
        'If (strTipo = "SERVICIOS") Then
        '    ConfiguracionInicioServicio()
        '    Panel2.Visible = False
        '    Panel5.Visible = True
        '    cboTipoDoc.SelectedValue = "1002"
        '    cboTipoServicio.Visible = True
        '    lblTipoServicio.Visible = True
        '    cboTipoServicio.SelectedIndex = -1
        'ElseIf (strTipo = "ORDEN") Then
        ConfiguracionInicioServicio()
        Panel2.Visible = True
        Panel5.Visible = False
        cboTipoDoc.SelectedValue = "1001"
        cboTipoServicio.Visible = False
        lblTipoServicio.Visible = False
        'End If
        'ComboBoxAdv1.SelectedIndex = -1
    End Sub

    Sub Recomendacion()
        lblEstado.Text = "Indicaciones: Identifique la fecha y el tipo de documento deL orden de compra y luego identifique al proveedor!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(20)
    End Sub

    Public Sub New(strTipos As String)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompras)
        Loadcontroles()
        GetTableGrid()

        GConfiguracion = New GConfiguracionModulo
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OC", Me.Text, GEstableciento.IdEstablecimiento)
        txtFecha.Value = New DateTime(DiaLaboral.Year, MesGeneral, CInt(DiaLaboral.Day), DateTime.Now.Hour, DateTime.Now.Minute, 0)
        'txtTipoCambio.DecimalValue = TmpTipoCambio
        Recomendacion()
        If (strTipos = "SERVICIOS") Then
            strTipo = "SERVICIOS"
            ConfiguracionInicioServicio()
            Panel2.Visible = False
            Panel5.Visible = True
            cboTipoDoc.SelectedValue = "1002"
            cboTipoServicio.Visible = True
            lblTipoServicio.Visible = True
            cboTipoServicio.SelectedIndex = -1
        ElseIf (strTipos = "ORDEN") Then

            strTipo = "ORDEN"
            ConfiguracionInicioServicio()
            Panel2.Visible = True
            Panel5.Visible = False
            cboTipoDoc.SelectedValue = "1001"
            cboTipoServicio.Visible = False
            lblTipoServicio.Visible = False
        End If
        'ComboBoxAdv1.SelectedIndex = -1
    End Sub



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
        grid.TableOptions.SelectionBackColor = Color.Gray
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Sub ConfiguracionInicio()
        TotalesXcanbeceras = New TotalesXcanbecera()
        Dim almacenSA As New almacenSA
        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
        'configurando docking manager

        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            ' dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            dockingManager1.SetDockLabel(Panel2, "Existencias")
            'dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
            Panel5.Visible = False
        Else
            dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            dockingManager1.SetDockLabel(Panel2, "Existencias")
            dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
        End If



        'dockingManager1.SetDockLabel(Panel4, "Activo Inmovilizado")
        dockingManager1.CloseEnabled = False

        'If Not IsNothing(GFichaUsuarios) Then
        ' ToolStripButton1.Image = ImageListAdv1.Images(1)
        dgvCompras.TableDescriptor.Columns("chPago").Width = 0
        'Else
        'dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'ToolStripButton1.Image = ImageListAdv1.Images(0)
        'GFichaUsuarios = Nothing
        'End If
        dgvCompras.TableDescriptor.Columns("pume").Width = 0
        dgvCompras.TableDescriptor.Columns("vcme").Width = 0
        dgvCompras.TableDescriptor.Columns("igvme").Width = 0
        dgvCompras.TableDescriptor.Columns("totalme").Width = 0
        dgvCompras.TableDescriptor.Columns("percepcionME").Width = 0
        cboMoneda.SelectedValue = 1


        'confgiurando variables generales
        'txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        '  lblPerido.Text = PeriodoGeneral
        '   txtTipoCambio.DecimalValue = TmpTipoCambio
        ListaTipoCambio = New List(Of TipoCambioSunatV2)
        LoadTipoCambio()

        'txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        'txtFecVence.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
    End Sub

    Sub ConfiguracionInicioServicio()
        TotalesXcanbeceras = New TotalesXcanbecera()
        Dim almacenSA As New almacenSA
        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
        'configurando docking manager

        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        'If strTipo = "ORDEN" Then
        '    dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        '    ' dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        '    dockingManager1.SetDockLabel(Panel2, "Existencias")
        '    'dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
        '    Panel5.Visible = False
        'ElseIf strTipo = "SERVICIOS" Then
        '    dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        '    dockingManager1.SetDockLabel(Panel5, "Servicios")
        'End If
        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        ' dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        dockingManager1.SetDockLabel(Panel2, "Existencias")
        'dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
        Panel5.Visible = False
        dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        dockingManager1.SetDockLabel(Panel5, "Servicios")

        'dockingManager1.SetDockLabel(Panel4, "Activo Inmovilizado")
        dockingManager1.CloseEnabled = False

        'If Not IsNothing(GFichaUsuarios) Then
        ' ToolStripButton1.Image = ImageListAdv1.Images(1)
        'dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        ''Else
        ''dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        ''ToolStripButton1.Image = ImageListAdv1.Images(0)
        ''GFichaUsuarios = Nothing
        ''End If
        'dgvCompra.TableDescriptor.Columns("pume").Width = 0
        'dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        'dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        'dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        'dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        cboMoneda.SelectedValue = 1


        'confgiurando variables generales
        'txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        '  lblPerido.Text = PeriodoGeneral
        '   txtTipoCambio.DecimalValue = TmpTipoCambio
        ListaTipoCambio = New List(Of TipoCambioSunatV2)
        LoadTipoCambio()

        'txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        'txtFecVence.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
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


#End Region

#Region "Metodo"

    'Public Sub GetServiviosHijo(idservicio As Integer)
    '    Dim servicioSA As New servicioSA


    '    cboServicio.DisplayMember = "descripcion"
    '    cboServicio.ValueMember = "idServicio"
    '    cboServicio.DataSource = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "CM", .idPadre = idservicio})

    'End Sub

    'Public Sub GetServiviosHijoActivos(cuentaPadre As String)
    '    Dim servicioSA As New cuentaplanContableEmpresaSA


    '    cboServicio.DisplayMember = "descripcion"
    '    cboServicio.ValueMember = "cuenta"
    '    cboServicio.DataSource = servicioSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, cuentaPadre)

    'End Sub

    'Public Sub GetServiviosPadre()
    '    Dim servicioSA As New servicioSA
    '    For Each I In servicioSA.ListadoServiciosPadreTipo("PC")
    '        Dim n As New ListViewItem()
    '        n.Text = I.idServicio
    '        n.SubItems.Add(I.descripcion)
    '        lsvServicios.Items.Add(n)
    '    Next

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

    'Public Sub UbicarDocumentos(intIdDocumento As Integer)
    '    Dim documentoCompraSA As New DocumentoCompraSA
    '    Dim documentoDetalleSA As New DocumentoCompraDetalleSA
    '    Dim entidadSA As New entidadSA
    '    Dim tablaDetalleSA As New tablaDetalleSA
    '    Dim docOtros As New DocumentoOtrosDatosSA
    '    Dim cFinancieraSA As New EstadosFinancierosSA

    '    With documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)

    '        With docOtros.UbicarDocumentoOtros(intIdDocumento)
    '            'fechainicio.Value = .fechaInicio
    '            'fechafin.Value = .fechaFin

    '            If (Not IsNothing(.condicionPago)) Then
    '                CboPago.Text = tablaDetalleSA.GetUbicarTablaID(501, CInt(.condicionPago)).descripcion
    '            End If

    '            If (Not IsNothing(.Vcto)) Then
    '                dtpFechaVencimiento.Value = CDate(.Vcto).Date
    '            End If

    '            If (Not IsNothing(.Modalidad)) Then
    '                cboModalidad.Text = tablaDetalleSA.GetUbicarTablaID(1, .Modalidad).descripcion
    '            End If




    '            If (Not IsNothing(.ctaDeposito)) Then
    '                TextBoxExt1.Text = .ctaDeposito
    '            End If


    '            If (Not IsNothing(.institucionFinanciera)) Then
    '                'With cFinancieraSA.ObtenerEstadosFinancierosPorCodigo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, .institucionFinanciera)
    '                cboDepositoHijo.SelectedValue = .institucionFinanciera
    '                'End With
    '            End If

    '            txtTipoCambio.Text = .

    '            'txtContra.Text = .objetoContratacion
    '            'txtImporteContratacion.Value = .importeContratacion
    '            'txtPeriodoValorizacion.Text = .periodoValorizacion
    '            'txtPenalidades.Text = .penalidades
    '            'If .etracciones.Length > 0 Then
    '            '    nudDetraccion.Value = .etracciones
    '            '    tbDetraccion.ToggleState = ToggleButtonState.Active
    '            'Else
    '            '    nudDetraccion.Value = 0
    '            '    tbDetraccion.ToggleState = ToggleButtonState.Inactive
    '            'End If

    '            'txtAdelanto.Value = .adelanto
    '            'txtFondoGarantia.Value = .fondoGarantia

    '            'If (.moneda = "1") Then
    '            '    cboMoneda.DisplayMember = "NACIONAL"
    '            '    cboMoneda.SelectedValue = CInt(1)

    '            'ElseIf (.moneda = "2") Then
    '            '    cboMoneda.DisplayMember = "EXTRANJERA"
    '            '    cboMoneda.SelectedValue = CInt(2)

    '            'End If

    '        End With

    '        If (Not IsNothing(.idProveedor)) Then
    '            With entidadSA.UbicarEntidadPorID(.idProveedor).First
    '                txtProveedor.Text = .nombreCompleto
    '                txtProveedor.Tag = .idEntidad
    '                txtRuc.Text = .nrodoc
    '                txtCuenta.Text = .cuentaAsiento
    '            End With
    '        End If

    '        If (.monedaDoc = "1") Then
    '            cboMoneda.DisplayMember = "NACIONAL"
    '            cboMoneda.SelectedValue = CInt(1)

    '        ElseIf (.monedaDoc = "2") Then
    '            cboMoneda.DisplayMember = "EXTRANJERA"
    '            cboMoneda.SelectedValue = CInt(2)

    '        End If

    '        'txtFechaComprobante.Value = .fechaDoc

    '    End With
    '    'dgvCompra.Rows.Clear()
    '    'For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(intIdDocumento)
    '    '    dgvCompra.Rows.Add(i.secuencia, "1", i.idItem, i.descripcionItem, i.entregable, i.fechaEntrega, Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia)


    '    'Next
    'End Sub

    Sub UpdateDoc(intIdDocumento As Integer)
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        nRecurso = New documentocompra With {
        .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
        .idDocumento = intIdDocumento,
        .tipoCompra = TIPO_COMPRA.ORDEN_APROBADO}
        If (nRecursoSA.EstadoSoli(nRecurso)) Then
            'lblEstado.Text = " editado!"
            'lblEstado.Image = My.Resources.ok4
        Else
            'lblEstado.Text = "Error al grabar Cadena!"
            'lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim docOtros As New DocumentoOtrosDatosSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle
        Dim tablaDetalleSA As New tablaDetalleSA

        Try
            DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            'If Not IsNothing(DocumentoGuia) Then
            '    With DocumentoGuia
            '        txtSerie.Text = .Serie
            '        txtNumero.Text = .Numero
            '    End With
            'End If

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                'If Not IsNothing(.fechaConstancia) Then
                '    txtFecDetraccion.Value = .fechaConstancia
                'End If
                'txtNroConstancia.Text = .nroConstancia
                txtFecha.Value = .fechaDoc
                'lblIdDocumento.Text = .idDocumento
                lblPerido.Text = .fechaContable
                cboTipoDoc.SelectedValue = .tipoDoc
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .monedaDoc

                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompras.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompras.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompras.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompras.TableDescriptor.Columns("totalmn").Width = 70
                        dgvCompras.TableDescriptor.Columns("percepcionMN").Width = 70

                        dgvCompras.TableDescriptor.Columns("pume").Width = 0
                        dgvCompras.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompras.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompras.TableDescriptor.Columns("totalme").Width = 0
                        dgvCompras.TableDescriptor.Columns("percepcionME").Width = 0

                        cboMoneda.SelectedValue = 1
                        '      tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case 2

                        dgvCompras.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompras.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompras.TableDescriptor.Columns("igvmn").Width = 0
                        dgvCompras.TableDescriptor.Columns("totalmn").Width = 0
                        dgvCompras.TableDescriptor.Columns("percepcionMN").Width = 0

                        dgvCompras.TableDescriptor.Columns("pume").Width = 60
                        dgvCompras.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompras.TableDescriptor.Columns("igvme").Width = 65
                        dgvCompras.TableDescriptor.Columns("totalme").Width = 70
                        dgvCompras.TableDescriptor.Columns("percepcionME").Width = 70
                        cboMoneda.SelectedValue = 2
                        '    tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtProveedor.Tag = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                txtTipoCambio.DecimalValue = .tcDolLoc
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa


                'Select Case .tieneDetraccion
                '    Case "S"
                '        chDetraccion.Checked = True
                '    Case Else
                '        chDetraccion.Checked = False
                'End Select

            End With

            'DETALLE DE LA COMPRA
            dgvCompras.Table.Records.DeleteAll()
            Panel2.Visible = False
            Panel5.Visible = False
            Panel4.Visible = False

            With docOtros.UbicarDocumentoOtros(intIdDocumento)
                If (Not IsNothing(.condicionPago)) Then
                    CboPago.Text = tablaDetalleSA.GetUbicarTablaID(501, CInt(.condicionPago)).descripcion
                End If

                If (Not IsNothing(.Vcto)) Then
                    dtpFechaVencimiento.Value = CDate(.Vcto).Date
                End If

                If (Not IsNothing(.Modalidad)) Then
                    cboModalidad.Text = tablaDetalleSA.GetUbicarTablaID(1, .Modalidad).descripcion
                End If




                If (Not IsNothing(.ctaDeposito)) Then
                    TextBoxExt1.Text = .ctaDeposito
                End If


                If (Not IsNothing(.institucionFinanciera)) Then
                    'With cFinancieraSA.ObtenerEstadosFinancierosPorCodigo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, .institucionFinanciera)
                    cboDepositoHijo.SelectedValue = .institucionFinanciera
                    'End With
                End If
            End With



            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)

                Me.dgvCompras.Table.AddNewRecord.SetCurrent()
                Me.dgvCompras.Table.AddNewRecord.BeginEdit()
                Me.dgvCompras.Table.CurrentRecord.SetValue("codigo", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("gravado", i.destino)
                Me.dgvCompras.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                Me.dgvCompras.Table.CurrentRecord.SetValue("item", i.descripcionItem)
                Me.dgvCompras.Table.CurrentRecord.SetValue("um", i.unidad1)
                Me.dgvCompras.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", i.importe)

                Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", i.importeUS)
                Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
                Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                Me.dgvCompras.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                Me.dgvCompras.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                Me.dgvCompras.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                Me.dgvCompras.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN)
                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME)

                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        Me.dgvCompras.Table.CurrentRecord.SetValue("chPago", True)
                        Me.dgvCompras.Table.CurrentRecord.SetValue("valPago", "Pagado")
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        Me.dgvCompras.Table.CurrentRecord.SetValue("chPago", False)
                        Me.dgvCompras.Table.CurrentRecord.SetValue("valPago", "No Pagado")
                End Select

                Select Case i.bonificacion
                    Case "S"
                        Me.dgvCompras.Table.CurrentRecord.SetValue("chBonif", True)
                        Me.dgvCompras.Table.CurrentRecord.SetValue("valBonif", "S")
                    Case "N"
                        Me.dgvCompras.Table.CurrentRecord.SetValue("chBonif", False)
                        Me.dgvCompras.Table.CurrentRecord.SetValue("valBonif", "N")
                End Select


                Select Case i.tipoExistencia
                    Case "GS"

                    Case "01"
                        Me.dgvCompras.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega)
                        Me.dgvCompras.Table.CurrentRecord.SetValue("tipo", "A")
                    Case "08"
                        Me.dgvCompras.Table.CurrentRecord.SetValue("tipo", "T")

                End Select



                'Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)



                Me.dgvCompras.Table.AddNewRecord.EndEdit()
            Next
            btGrabar.Enabled = False
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub


    Dim listaCategoria As New List(Of item)
    Private Sub CMBClasificacion()
        Dim categoriaSA As New itemSA
        'Dim objItem As New item With {.idItem = 0, .descripcion = "Seleccione un Item"}
        listaCategoria = New List(Of item)


        listaCategoria = categoriaSA.GetListaPadre()
        Label42.Text = listaCategoria.Count & " items"

    End Sub

    Private Sub LoadTipoCambio()
        Dim tipocambioSA As New tipoCambioSA
        ListaTipoCambio = tipocambioSA.GetListar_tipoCambioByPeriodo(Gempresas.IdEmpresaRuc, CInt(MesGeneral), CInt(AnioGeneral), GEstableciento.IdEstablecimiento)
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

    'Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
    '    Dim objDoc As New DocumentoSA
    '    Dim objDocCompra As New DocumentoCompraSA
    '    Dim objDocCompraDet As New DocumentoCompraDetalleSA
    '    Dim objEntidad As New entidadSA
    '    Dim nEntidad As New entidad
    '    Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
    '    Dim documentoCajaSA As New DocumentoCajaSA
    '    Dim objDocCaja As New DocumentoSA
    '    Dim establecSA As New establecimientoSA
    '    Dim inventarioBL As New inventarioMovimientoSA
    '    Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
    '    Dim DocumentoGuia As New documentoguiaDetalle
    '    Try
    '        DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
    '        If Not IsNothing(DocumentoGuia) Then
    '            With DocumentoGuia
    '                'txtSerieGuia.Text = .Serie
    '                'txtNumeroGuia.Text = .Numero
    '            End With
    '        End If
    '        'CABECERA COMPROBANTE
    '        With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
    '            If Not IsNothing(.fechaConstancia) Then
    '                'txtFecDetraccion.Value = .fechaConstancia
    '            End If
    '            'txtNroConstancia.Text = .nroConstancia
    '            txtFecha.Value = .fechaDoc
    '            'lblIdDocumento.Text = .idDocumento
    '            PeriodoGeneral = .fechaContable
    '            cboTipoDoc.SelectedValue = .tipoDoc
    '            txtSerie.Text = .serie
    '            txtNumero.Text = .numeroDoc
    '            cboMoneda.SelectedValue = .monedaDoc
    '            Select Case cboMoneda.SelectedValue
    '                Case 1
    '                    dgvCompra.TableDescriptor.Columns("pumn").Width = 60
    '                    dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
    '                    dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
    '                    dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
    '                    dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70
    '                    dgvCompra.TableDescriptor.Columns("pume").Width = 0
    '                    dgvCompra.TableDescriptor.Columns("vcme").Width = 0
    '                    dgvCompra.TableDescriptor.Columns("igvme").Width = 0
    '                    dgvCompra.TableDescriptor.Columns("totalme").Width = 0
    '                    dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
    '                    cboMoneda.SelectedValue = 1
    '                    '      tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
    '                Case 2
    '                    dgvCompra.TableDescriptor.Columns("pumn").Width = 0
    '                    dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
    '                    dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
    '                    dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
    '                    dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0
    '                    dgvCompra.TableDescriptor.Columns("pume").Width = 60
    '                    dgvCompra.TableDescriptor.Columns("vcme").Width = 65
    '                    dgvCompra.TableDescriptor.Columns("igvme").Width = 65
    '                    dgvCompra.TableDescriptor.Columns("totalme").Width = 70
    '                    dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
    '                    cboMoneda.SelectedValue = 2
    '                    '    tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
    '            End Select
    '            nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
    '            txtRuc.Text = nEntidad.nrodoc
    '            txtProveedor.Tag = nEntidad.idEntidad
    '            txtProveedor.Text = nEntidad.nombreCompleto
    '            txtTipoCambio.DecimalValue = .tcDolLoc
    '            txtIva.DoubleValue = .tasaIgv
    '            txtGlosa.Text = .glosa
    '            'Select Case .tieneDetraccion
    '            '    Case "S"
    '            '        chDetraccion.Checked = True
    '            '    Case Else
    '            '        chDetraccion.Checked = False
    '            'End Select
    '        End With
    '        'DETALLE DE LA COMPRA
    '        dgvCompra.Table.Records.DeleteAll()
    '        Panel2.Visible = False
    '        Panel5.Visible = False
    '        Panel4.Visible = False
    '        For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)
    '            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME)
    '            Select Case i.estadoPago
    '                Case TIPO_COMPRA.PAGO.PAGADO
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
    '                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
    '            End Select
    '            Select Case i.bonificacion
    '                Case "S"
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", True)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "S")
    '                Case "N"
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
    '            End Select
    '            Select Case i.tipoExistencia
    '                Case "GS"
    '                Case "01"
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
    '                Case "08"
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")
    '            End Select
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)
    '            Me.dgvCompra.Table.AddNewRecord.EndEdit()
    '        Next
    '        btGrabar.Enabled = False
    '        TotalTalesXcolumna()
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    Sub Grabar()
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
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = txtFecha.Value
            .nroDoc = GConfiguracion.Serie
            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            .nrodocEntidad = txtRuc.Text
            .tipoOperacion = "02"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now

        End With
        With nDocumentoCompra
            .codigoLibro = "1"

            .serie = GConfiguracion.Serie
            .numeroDoc = GConfiguracion.Serie
            .tipoDoc = cboTipoDoc.SelectedValue
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaVcto = txtFecVence.Value
            .fechaContable = lblPerido.Text
            .tipoRecaudo = Nothing
            If ToggleButton1.ToggleState = ToggleButtonState.Active Then
                .regimen = "AP"
                .asignacionPorcentaje = CInt(txtFGarantia.Text)
            ElseIf ToggleButton1.ToggleState = ToggleButtonState.Inactive Then
                .regimen = Nothing
                .asignacionPorcentaje = 0
            End If
            .tcDolLoc = txtTipoCambio.DecimalValue
            .monedaDoc = cboMoneda.SelectedValue
            .idProveedor = CInt(txtProveedor.Tag)
            .nombreProveedor = txtProveedor.Text
            .fechaVcto = txtFecha.Value
            .glosa = txtGlosa.Text
            .fechaContable = lblPerido.Text
            .nroRegimen = Nothing
            .tasaIgv = txtIva.DoubleValue
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = TotalesXcanbeceras.base1
            .bi02 = TotalesXcanbeceras.base2
            .igv01 = TotalesXcanbeceras.MontoIgv1
            .igv02 = TotalesXcanbeceras.MontoIgv2

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = TotalesXcanbeceras.base1me
            .bi02us = TotalesXcanbeceras.base2me

            .igv01us = TotalesXcanbeceras.MontoIgv1me
            .igv02us = TotalesXcanbeceras.MontoIgv2me
            '****************************************************************************************************************

            .importeTotal = TotalesXcanbeceras.TotalMN
            .importeUS = TotalesXcanbeceras.TotalME

            If tbDetraccion.ToggleState = ToggleButtonState.Active Then
                .tieneDetraccion = "S"
                .detraccionPorcentaje = CInt(txtDetracciones.Text)
            ElseIf tbDetraccion.ToggleState = ToggleButtonState.Inactive Then
                .tieneDetraccion = "N"
                .detraccionPorcentaje = 0
            End If

            'Select Case strTipo
            '    Case "ORDEN"
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .tipoCompra = TIPO_COMPRA.ORDEN_COMPRA  'MARTIN
            .situacion = TIPO_SITUACION.ORDEN_COMPRA_TRANSITO
            .usuarioActualizacion = "ORDEN DE COMPRA DIVERSOS"
            '    Case "SERVICIOS"
            '.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            '.tipoCompra = TIPO_COMPRA.ORDEN_SERVICIO   'MARTIN
            '.situacion = TIPO_SITUACION.ORDEN_SERVICIO_TRANSITO
            '.usuarioActualizacion = cboTipoServicio.SelectedItem
            'End Select

            .referenciaDestino = Nothing

            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'With objDocOtros
        '    '.Action = Business.Entity.BaseBE.EntityAction.INSERT
        '    .idAlmacen = Nothing
        '    .fechaInicio = Nothing
        '    .fechaFin = Nothing
        '    .FechaIniGarantia = Nothing
        '    .FechaFinGarantia = Nothing
        '    .notas = Nothing
        '    .indicaciones = Nothing
        '    .idItem = Nothing
        '    .cantidad = Nothing
        '    .idReferencia = Nothing
        '    .condicionPago = CboPago.SelectedValue
        '    .Vcto = CStr(dtpFechaVencimiento.Value).ToString
        '    .Modalidad = cboModalidad.SelectedValue
        '    .institucionFinanciera = CStr(cboDepositoHijo.SelectedValue)
        '    .ctaDeposito = CStr(TextBoxExt1.Text)
        '    .estado = "PN"
        '    .moneda = CInt(cboMoneda.SelectedValue)
        '    .CentroCostos = GEstableciento.IdEstablecimiento
        '    .idEmpresa = Gempresas.IdEmpresaRuc
        '    .usuarioActualizacion = "Jiuni"
        '    .fechaActualizacion = DateTime.Now

        'End With
        ndocumento.documentocompra.documentoOtrosDatos = ListaDetalleEntrega

        Dim S As Integer = 0

        For Each r As Record In dgvCompras.Table.Records
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.idDocumento = r.GetValue("codigo")
            objDocumentoCompraDet.estadoPago = r.GetValue("valPago")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento

            Select Case r.GetValue("tipoCompra")
                Case TIPO_COMPRA.ORDEN_COMPRA
                    objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.ORDEN_COMPRA
                    objDocumentoCompraDet.situacion = TIPO_COMPRA.ORDEN_COMPRA
                Case TIPO_COMPRA.ORDEN_SERVICIO
                    objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.ORDEN_SERVICIO
                    objDocumentoCompraDet.situacion = TIPO_COMPRA.ORDEN_SERVICIO
            End Select

            objDocumentoCompraDet.CuentaProvedor = "4212" ' txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = cboTipoDoc.SelectedValue
            objDocumentoCompraDet.destino = r.GetValue("gravado")
            objDocumentoCompraDet.CuentaItem = Nothing
            objDocumentoCompraDet.idItem = r.GetValue("idProducto")
            objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoCompraDet.descripcionItem = r.GetValue("item")

            If IsNumeric(r.GetValue("cantidad")) Then
                If CDec(r.GetValue("cantidad")) < 0 Then
                    lblEstado.Text = "La cantidad debe ser mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If


                If CDec(r.GetValue("cantidad")) > 0 Then
                    objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
                Else
                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoCompraDet.monto1 = 0
                    Else
                        lblEstado.Text = "Ingrese una cantidad mayor a cero del item, " & r.GetValue("item")
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                End If
            Else
                lblEstado.Text = "Ingrese una cantidad válida del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If
            Select Case r.GetValue("tipoExistencia")
                Case "GS"
                    objDocumentoCompraDet.unidad1 = Nothing
                    objDocumentoCompraDet.unidad2 = Nothing
                    objDocumentoCompraDet.monto2 = Nothing
                    objDocumentoCompraDet.almacenRef = Nothing
                    objDocumentoCompraDet.unidad1 = r.GetValue("um")
                Case "08"
                    objDocumentoCompraDet.unidad1 = Nothing
                    objDocumentoCompraDet.unidad2 = Nothing
                    objDocumentoCompraDet.monto2 = Nothing
                    objDocumentoCompraDet.almacenRef = Nothing
                    objDocumentoCompraDet.unidad1 = r.GetValue("um")
                Case Else
                    objDocumentoCompraDet.unidad1 = r.GetValue("um")
                    objDocumentoCompraDet.unidad2 = r.GetValue("presentacion")  'IDPRESENTACION
                    objDocumentoCompraDet.monto2 = Nothing  ' PRESENTACION


            End Select
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            If IsNumeric(r.GetValue("totalmn")) Then
                If CDec(r.GetValue("totalmn")) < 0 Then
                    lblEstado.Text = "El importe debe ser mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

                If CDec(r.GetValue("totalmn")) > 0 Then
                    objDocumentoCompraDet.importe = CDec(r.GetValue("totalmn"))
                Else
                    lblEstado.Text = "Ingrese un importe mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If
            Else
                lblEstado.Text = "Ingrese un importe válido del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If


            objDocumentoCompraDet.importeUS = CDec(r.GetValue("totalme"))

            objDocumentoCompraDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = r.GetValue("valBonif")
            objDocumentoCompraDet.percepcionMN = CDec(r.GetValue("percepcionMN"))
            objDocumentoCompraDet.percepcionME = CDec(r.GetValue("percepcionME"))
            '**********************************************************************************
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim

            'Select Case cboTipoDoc.Text
            '    Case "ORDEN DE COMPRA"
            '        objDocumentoCompraDet.situacion = TIPO_COMPRA.ORDEN_COMPRA
            '    Case "ORDEN DE SERVICIO"
            '        objDocumentoCompraDet.situacion = TIPO_COMPRA.ORDEN_SERVICIO
            'End Select



            ' Dim montopagado As Decimal
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario

            Dim marcaVal = IIf(IsDBNull(r.GetValue("marca")), Nothing, r.GetValue("marca"))
            objDocumentoCompraDet.marcaRef = marcaVal

            Dim clas = (r.GetValue("cat"))

            If clas.ToString.Trim.Length > 0 Then
                objDocumentoCompraDet.categoria = clas
            Else
                objDocumentoCompraDet.categoria = Nothing
            End If

            objDocumentoCompraDet.fechaEntrega = CDate(r.GetValue("fecEntrega"))

            ListaDetalle.Add(objDocumentoCompraDet)

        Next

        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        CompraSA.GrabarOrdenes(ndocumento, objDocOtros)

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

    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
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

    'Public Sub HIJOS(idservicio As Integer)
    '    Dim servicioSA As New servicioSA
    '    cboServicio.DisplayMember = "descripcion"
    '    cboServicio.ValueMember = "idServicio"
    '    cboServicio.DataSource = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "CM", .idPadre = idservicio})
    'End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idProducto", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("um", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("vcmn", GetType(Decimal))
        dt.Columns.Add("pcmn", GetType(Decimal))
        dt.Columns.Add("totalmn", GetType(Decimal))
        dt.Columns.Add("vcme", GetType(Decimal))
        dt.Columns.Add("pcme", GetType(Decimal))
        dt.Columns.Add("totalme", GetType(Decimal))
        dt.Columns.Add("igvmn", GetType(Decimal))
        dt.Columns.Add("igvme", GetType(Decimal))

        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("marca", GetType(String))
        dt.Columns.Add("almacen", GetType(String))
        dt.Columns.Add("caja", GetType(String))

        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("chPago", GetType(Boolean))
        dt.Columns.Add("valPago", GetType(String))

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))
        dt.Columns.Add("presentacion", GetType(String))

        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("cat", GetType(String))
        dt.Columns.Add("fecEntrega", GetType(DateTime))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("cantidadPen", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("estadoOrden", GetType(String))

        ' dt.Columns.Add("cuentaAct", GetType(String))

        dgvCompras.DataSource = dt



        Dim dtHistorial As New DataTable
        dtHistorial.Columns.Add("idDocumento", GetType(Integer))
        dtHistorial.Columns.Add("secuencia", GetType(Integer))
        dtHistorial.Columns.Add("cantidad", GetType(Integer))
        dtHistorial.Columns.Add("idAlmacen", GetType(Integer))
        dtHistorial.Columns.Add("nombreAlmacen", GetType(String))
        dtHistorial.Columns.Add("direccionAlmacen", GetType(String))
        dtHistorial.Columns.Add("fechainicio", GetType(String))
        dtHistorial.Columns.Add("fechaFin", GetType(String))
        dtHistorial.Columns.Add("FechaIniGarantia", GetType(String))
        dtHistorial.Columns.Add("FechaFinGarantia", GetType(String))
        dtHistorial.Columns.Add("notas", GetType(String))
        dtHistorial.Columns.Add("indicaciones", GetType(String))
        dtHistorial.Columns.Add("idItem", GetType(Integer))
        dtHistorial.Columns.Add("estado", GetType(String))
        dgvHistorialDetalle.DataSource = dtHistorial

        Dim dtHistorialOS As New DataTable
        dtHistorialOS.Columns.Add("idDocumento", GetType(Integer))
        dtHistorialOS.Columns.Add("nombreEntrega", GetType(String))
        dtHistorialOS.Columns.Add("periodoValorizacion", GetType(String))
        dtHistorialOS.Columns.Add("penalidades", GetType(String))
        dtHistorialOS.Columns.Add("importeMN", GetType(Decimal))
        dtHistorialOS.Columns.Add("importeME", GetType(String))
        dtHistorialOS.Columns.Add("plazoContratacionInicio", GetType(String))
        dtHistorialOS.Columns.Add("plazoContratacionFin", GetType(String))
        dgvDetalleOServicio.DataSource = dtHistorialOS

    End Sub

    Public Function GetTableAlmacenPuntoUbi() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))

        For Each i In almacenSA.GetListar_almaUbiPunto(GEstableciento.IdEstablecimiento)

            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idAlmacen
            dr(1) = i.descripcionAlmacen
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Sub Productoshijos()
        Dim categoriaSA As New itemSA

        listaSubCategoria = categoriaSA.GetListaMarcaPadre(Val(txtCategoria.Tag))
        Label43.Text = listaSubCategoria.Count & " items"

    End Sub

    Sub Calculos()
        Dim cantidad As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0
        Try
            If txtTipoCambio.DecimalValue > 0 Then
                colDestinoGravado = Me.dgvCompras.Table.CurrentRecord.GetValue("gravado")

                If colDestinoGravado = 1 Then
                    valPercepMN = Me.dgvCompras.Table.CurrentRecord.GetValue("percepcionMN")
                    valPercepME = Me.dgvCompras.Table.CurrentRecord.GetValue("percepcionME")
                Else
                    valPercepMN = 0
                    valPercepME = 0
                End If

                '****************************************************************
                '    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                cantidad = Me.dgvCompras.Table.CurrentRecord.GetValue("cantidad")

                Select Case cboMoneda.SelectedValue
                    Case 1 'MONEDA NACIONAL
                        Me.dgvCompras.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                        VC = Me.dgvCompras.Table.CurrentRecord.GetValue("vcmn")
                        VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)

                    Case 2 'MONEDA EXTRANJERA

                        Me.dgvCompras.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                        VCme = Me.dgvCompras.Table.CurrentRecord.GetValue("vcme") ' 
                        VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)

                End Select

                'calculo Compratido por ambas monedas(Nacional y extranjera)
                If cantidad > 0 AndAlso VC > 0 Then
                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                    colBI = VC + Igv + valPercepMN
                    colBIme = VCme + IgvME + valPercepME

                    colPrecUnit = Math.Round(VC / cantidad, 2)
                    colPrecUnitme = Math.Round(VCme / cantidad, 2)
                ElseIf cantidad = 0 AndAlso VC > 0 Then
                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                    colBI = VC + Igv + valPercepMN
                    colBIme = VCme + IgvME + valPercepME

                    colPrecUnit = 0
                    colPrecUnitme = 0
                ElseIf cantidad = 0 Then
                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
                    colBI = VC + Igv + valPercepMN
                    colBIme = VCme + IgvME + valPercepME
                    colPrecUnit = 0
                    colPrecUnitme = 0
                Else
                    colPrecUnit = 0
                    colPrecUnitme = 0

                    colBI = 0
                    colBIme = 0
                    Igv = 0
                    IgvME = 0
                End If

                Me.dgvCompras.Table.CurrentRecord.SetValue("cantidadPen", cantidad)
                Me.dgvCompras.Table.CurrentRecord.SetValue("estadoOrden", "PENDIENTE")

                Select Case cboTipoDoc.SelectedValue
                    Case "08"

                    Case "03", "02"
                        Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                        Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                        Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                        Me.dgvCompras.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                        Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                        Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                        Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", 0)
                    Case Else
                        'If cboMoneda.SelectedValue = 1 Then
                        ' DATOS SOLES

                        Select Case colDestinoGravado
                            Case "2", "3", "4"

                                Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", 0)

                            Case Else
                                If Me.dgvCompras.Table.CurrentRecord.GetValue("chBonif") = "1" Then ' BOnIFICACIOn
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", 0)
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", 0)
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                    Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Else
                                    If cantidad > 0 Then

                                        Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", Igv.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", IgvME.ToString("N2"))

                                    Else

                                        Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", Igv.ToString("N2"))
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", IgvME.ToString("N2"))

                                    End If

                                End If
                        End Select

                End Select
                TotalTalesXcolumna()

            Else
                txtTipoCambio.Select()
                Throw New Exception("Debe indicar un tipo de cambio")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Public Function GetTableAlmacen() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))



        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then

            For Each i In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idAlmacen
                dr(1) = i.descripcionAlmacen
                dt.Rows.Add(dr)
            Next

        Else
            For Each i In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idAlmacen
                dr(1) = i.descripcionAlmacen
                dt.Rows.Add(dr)
            Next
        End If


        Return dt
    End Function

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
#End Region

#Region "DAtos"

    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try


            Me.cboDepositoHijo.DataSource = taBLASA.GetListaTablaDetalle(3, "1")
            Me.cboDepositoHijo.DisplayMember = "descripcion"
            Me.cboDepositoHijo.ValueMember = "codigoDetalle"
            cboDepositoHijo.SelectedValue = -1


            'cboMoneda.ValueMember = "codigoDetalle"
            'cboMoneda.DisplayMember = "descripcion"
            'cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            'cboMoneda.SelectedValue = -1

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarCtasFinan()
        'If  cboTipo.Text = "CUENTAS EN BANCO" Then
        '    CargarCajasTipo("BC")
        '    Dim lista As New List(Of String)
        '    lista.Add("001")
        '    lista.Add("003")
        '    lista.Add("007")
        '    lista.Add("111")
        '    'cboTipoDoc.SelectedValue = "001"
        'End If
    End Sub

    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim listatabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim servicioSA As New servicioSA
        Dim efSA As New EstadosFinancierosSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0


        cboModalidad.DisplayMember = "descripcion"
        cboModalidad.ValueMember = "codigoDetalle"
        cboModalidad.DataSource = tablaSA.GetListaTablaDetalle(1, "1")
        cboModalidad.SelectedValue = -1

        CboPago.DisplayMember = "descripcion"
        CboPago.ValueMember = "codigoDetalle"
        CboPago.DataSource = tablaSA.GetListaTablaDetalle(501, "1")
        CboPago.SelectedValue = -1


        'cboServicioPadre.DisplayMember = "descripcion"
        'cboServicioPadre.ValueMember = "idServicio"
        'cboServicioPadre.DataSource = servicioSA.ListadoServiciosPadreTipo("PC")



        'COMPROBANTE TIPO DOCUMENTOS
        Dim list As New List(Of String)
        list.Add("07")
        list.Add("08")
        list.Add("02")
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(10, "1")

        Dim Comprobantes = (From n In listatabla _
                           Where Not list.Contains(n.codigoDetalle)).ToList


        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = Comprobantes
        Select Case strTipo
            Case "ORDEN"
                cboTipoDoc.SelectedValue = "1001"
            Case "SERVICIO"
                cboTipoDoc.SelectedValue = "1002"
        End Select

        'TIPO DE EXISTENCIA
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(5, "1")
        Dim listaNoExistencias As New List(Of String)
        listaNoExistencias.Add("06")
        listaNoExistencias.Add("07")
        listaNoExistencias.Add("08")
        listaNoExistencias.Add("02")

        Dim consultaExistencia = (From n In listatabla _
                                 Where Not listaNoExistencias.Contains(n.codigoDetalle)).ToList

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = consultaExistencia
        '-------------------------------------------------------------------
        txtBuscarProducto.Visible = True
        btnNuevoProd.Visible = True

        Label16.Text = "Buscar item"
        txtCategoria.Visible = False
        PictureBox2.Visible = False
        Label42.Visible = False
        Label43.Visible = False

        Label35.Visible = False
        txtSubCategoria.Visible = False
        PictureBox6.Visible = False

        'TextBoxExt3.Visible = True
        'PictureBox5.Visible = True

        'Label31.Text = "Buscar activo"
        'CboClasificacion1.Visible = False
        'PictureBox4.Visible = False
        ''------------------------------------

        'Label39.Visible = False
        'cboProductos2.Visible = False
        'PictureBox7.Visible = False

        CargarCajasTipo("BC")

        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            cboDestino.Enabled = False
        Else
            cboDestino.Enabled = True
        End If

        dgvCompras.TableDescriptor.Columns("pumn").Width = 60
        dgvCompras.TableDescriptor.Columns("vcmn").Width = 65
        dgvCompras.TableDescriptor.Columns("igvmn").Width = 65
        dgvCompras.TableDescriptor.Columns("totalmn").Width = 70
        dgvCompras.TableDescriptor.Columns("percepcionMN").Width = 70
        dgvCompras.TableDescriptor.Columns("pume").Width = 0
        dgvCompras.TableDescriptor.Columns("vcme").Width = 0
        dgvCompras.TableDescriptor.Columns("igvme").Width = 0
        dgvCompras.TableDescriptor.Columns("totalme").Width = 0
        dgvCompras.TableDescriptor.Columns("percepcionME").Width = 0

        txtTipoCambio.DecimalValue = TmpTipoCambio

    End Sub

    Sub TotalTalesXcolumna()
        Dim totalpercepMN As Decimal = 0
        Dim totalpercepME As Decimal = 0

        'VC01
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        'VC02
        Dim totalVC2 As Decimal = 0
        Dim totalVCme2 As Decimal = 0

        'VC03
        Dim totalVC3 As Decimal = 0
        Dim totalVCme3 As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        For Each r As Record In dgvCompras.Table.Records
            totalpercepMN += CDec(r.GetValue("percepcionMN"))
            totalpercepME += CDec(r.GetValue("percepcionME"))

            If (Not IsNothing(r.GetValue("valBonif"))) Then

                If r.GetValue("valBonif") = "S" Then
                    totalDesc += CDec(r.GetValue("igvmn"))
                    totalDescme += CDec(r.GetValue("igvme"))
                Else
                    'totalVC += CDec(r.GetValue("vcmn"))
                    'totalVCme += CDec(r.GetValue("vcme"))

                    totalIVA += CDec(r.GetValue("igvmn"))
                    totalIVAme += CDec(r.GetValue("igvme"))

                    total += CDec(r.GetValue("totalmn"))
                    totalme += CDec(r.GetValue("totalme"))
                End If
            End If
            If (Not IsNothing(r.GetValue("gravado"))) Then
                Select Case r.GetValue("gravado")
                    Case "1"
                        If r.GetValue("valBonif") <> "S" Then
                            bs1 += CDec(r.GetValue("vcmn"))
                            bs1me += CDec(r.GetValue("vcme"))

                            igv1 += CDec(r.GetValue("igvmn"))
                            igv1me += CDec(r.GetValue("igvme"))
                        End If



                    Case "2"
                        If r.GetValue("valBonif") <> "S" Then
                            bs2 += CDec(r.GetValue("vcmn"))
                            bs2me += CDec(r.GetValue("vcme"))

                            igv2 += CDec(r.GetValue("igvmn"))
                            igv2me += CDec(r.GetValue("igvme"))
                        End If

                End Select


                Select Case r.GetValue("gravado")
                    Case OperacionGravada.Grabado
                        If r.GetValue("valBonif") <> "S" Then
                            totalVC += CDec(r.GetValue("vcmn"))
                            totalVCme += CDec(r.GetValue("vcme"))
                        End If


                    Case OperacionGravada.Exonerado
                        If r.GetValue("valBonif") <> "S" Then
                            totalVC2 += CDec(r.GetValue("vcmn"))
                            totalVCme2 += CDec(r.GetValue("vcme"))
                        End If


                    Case OperacionGravada.Inafecto
                        If r.GetValue("valBonif") <> "S" Then
                            totalVC3 += CDec(r.GetValue("vcmn"))
                            totalVCme3 += CDec(r.GetValue("vcme"))
                        End If

                End Select

            End If












        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.PercepcionMN = totalpercepMN
        TotalesXcanbeceras.PercepcionME = totalpercepME

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.BaseMN2 = totalVC2
        TotalesXcanbeceras.BaseME2 = totalVCme2

        TotalesXcanbeceras.BaseMN3 = totalVC3
        TotalesXcanbeceras.BaseME3 = totalVCme3

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        '****************************************************

        If cboMoneda.SelectedValue = 1 Then
            txtTotalBase3.DecimalValue = totalVC3
            txtTotalBase2.DecimalValue = totalVC2
            txtTotalBase.DecimalValue = totalVC
            txtTotalIva.DecimalValue = totalIVA
            txtTotalPagar.DecimalValue = total
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        Else
            txtTotalBase3.DecimalValue = totalVCme3
            txtTotalBase2.DecimalValue = totalVCme2
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar.DecimalValue = totalme
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        End If


    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtProveedor.Clear()
            '  txtCuenta.Clear()
            txtRuc.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub

#End Region

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

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

    Dim comboTable As New DataTable
    Dim comboTable1 As New DataTable
    Dim comboTable3 As New DataTable
    Dim comboTableP As New DataTable

    Private Sub frmOrdenCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboTableP = Me.GetTableAlmacen
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompras.TableDescriptor.Columns(14).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTableP
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvCompras.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvCompras.ShowRowHeaders = False
    End Sub

    Private Sub frmOrdenCompras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
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
            'If txtProveedor.Text.Trim.Length > 0 Then
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            'End If
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo proveedor"
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    'Private Sub cargarDatosCuenta(idCaja As Integer)
    '    Dim estadoSA As New EstadosFinancierosSA
    '    Dim estadoBL As New estadosFinancieros
    '    Dim estadoSaldoBL As New estadosFinancieros

    '    estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
    '    If (Not IsNothing(estadoBL)) Then
    '        cboMoneda.SelectedValue = estadoBL.codigo
    '        'txtCuentaOrigen.Text = estadoBL.cuenta
    '    End If
    'End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        If Not IsNothing(TotalesXcanbeceras) Then
            If cboMoneda.SelectedValue = 2 Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompras.TableDescriptor.Columns("pumn").Width = 0
                dgvCompras.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompras.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompras.TableDescriptor.Columns("totalmn").Width = 0
                dgvCompras.TableDescriptor.Columns("percepcionMN").Width = 0

                dgvCompras.TableDescriptor.Columns("pume").Width = 60
                dgvCompras.TableDescriptor.Columns("vcme").Width = 65
                dgvCompras.TableDescriptor.Columns("igvme").Width = 65
                dgvCompras.TableDescriptor.Columns("totalme").Width = 70
                dgvCompras.TableDescriptor.Columns("percepcionME").Width = 70
                '   cboMoneda.SelectedValue = 2

                'If dgvCompra.Table.Records.Count > 0 Then

                'Else
                txtTipoCambio.DecimalValue = TmpTipoCambio
                'End If

            ElseIf cboMoneda.SelectedValue = 1 Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompras.TableDescriptor.Columns("pumn").Width = 60
                dgvCompras.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompras.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompras.TableDescriptor.Columns("totalmn").Width = 70
                dgvCompras.TableDescriptor.Columns("percepcionMN").Width = 70
                dgvCompras.TableDescriptor.Columns("pume").Width = 0
                dgvCompras.TableDescriptor.Columns("vcme").Width = 0
                dgvCompras.TableDescriptor.Columns("igvme").Width = 0
                dgvCompras.TableDescriptor.Columns("totalme").Width = 0
                dgvCompras.TableDescriptor.Columns("percepcionME").Width = 0
                '    cboMoneda.SelectedValue = 1

                'Dim consulta = (From n In ListaTipoCambio _
                '             Where n.fechaIgv.Year = txtFecha.Value.Year _
                '             And n.fechaIgv.Month = txtFecha.Value.Month _
                '             And n.fechaIgv.Day = txtFecha.Value.Day).FirstOrDefault

                'If Not IsNothing(consulta) Then
                txtTipoCambio.DecimalValue = TmpTipoCambio
                'Else
                '    txtTipoCambio.DecimalValue = 0
                'End If
            End If
        End If
    End Sub

    Private Sub txtTipoCambio_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtTipoCambio.MouseDoubleClick
        txtTipoCambio.Enabled = True
        txtTipoCambio.Select()
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        With frmTipoCambio
            .txtFechaIgv.Value = DateTime.Now.Date
            .StartPosition = FormStartPosition.CenterParent
            .nudTipoCambioCompra.Value = 0
            .nudTipoCambio.Value = 0
            .ShowDialog()
            LoadTipoCambio()
        End With
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'txtNumeroGuia.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'txtSerieGuia.Clear()
        End Try
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                'txtSerieGuia.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'txtNumeroGuia.Clear()
        End Try
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    'txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim

                End If
                txtNumero.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    'txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim

                End If
                'cboMoneda.Select()
                txtProveedor.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        If (Not IsNothing(dgvCompras.Table.CurrentRecord)) Then
            dgvDetalleOServicio.Table.Records.DeleteAll()
            dgvHistorialDetalle.Table.Records.DeleteAll()
            If (Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.ORDEN_COMPRA) Then
                Dim aa As Integer
                aa = Me.dgvCompras.Table.CurrentRecord.GetValue("codigo")
                Dim consultas = (From a In ListaDetalleEntrega Where a.idDocumento = aa).ToList

                Dim dt As New DataTable("Movimientos - período " & lblPerido.Text & " ")
                Dim DocumentoOtrosDatosSA As New DocumentoOtrosDatosSA
                dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
                dt.Columns.Add(New DataColumn("secuencia", GetType(Integer)))
                dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
                dt.Columns.Add(New DataColumn("idAlmacen", GetType(Integer)))
                dt.Columns.Add(New DataColumn("nombreAlmacen", GetType(String)))
                dt.Columns.Add(New DataColumn("direccionAlmacen", GetType(String)))
                dt.Columns.Add(New DataColumn("fechainicio", GetType(String)))
                dt.Columns.Add(New DataColumn("fechaFin", GetType(String)))
                dt.Columns.Add(New DataColumn("FechaIniGarantia", GetType(String)))
                dt.Columns.Add(New DataColumn("FechaFinGarantia", GetType(String)))
                dt.Columns.Add(New DataColumn("notas", GetType(String)))
                dt.Columns.Add(New DataColumn("indicaciones", GetType(String)))
                dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
                dt.Columns.Add(New DataColumn("estado", GetType(String)))

                For Each i As documentoOtrosDatos In consultas
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = conteoCompras
                    dr(1) = i.secuencia
                    dr(2) = i.cantidad
                    dr(3) = i.idAlmacen
                    dr(4) = i.nombreAlmacen
                    dr(5) = i.direccionAlmacen
                    dr(6) = CStr(i.fechaInicio)
                    dr(7) = CStr(i.fechaFin)
                    dr(8) = CStr(i.FechaIniGarantia)
                    dr(9) = CStr(i.fechaFin)
                    dr(10) = i.notas
                    dr(11) = i.indicaciones
                    dr(12) = i.idItem
                    dr(13) = "U"
                    dt.Rows.Add(dr)
                Next

                tsrTodo.Visible = true
                tsrItem.Visible = True
                tsrItem.Checked = False
                tsrTodo.Checked = False

                dgvHistorialDetalle.DataSource = dt
                dgvDetalleOServicio.Dock = DockStyle.None
                dgvHistorialDetalle.Dock = DockStyle.Fill
                dgvDetalleOServicio.Visible = False
                dgvHistorialDetalle.Visible = True

            ElseIf (Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.ORDEN_SERVICIO) Then

                Dim aa As Integer
                aa = Me.dgvCompras.Table.CurrentRecord.GetValue("codigo")
                Dim consultas = (From a In ListaDetalleEntrega Where a.idDocumento = aa).ToList

                Dim dt As New DataTable("Movimientos - período " & lblPerido.Text & " ")
                Dim DocumentoOtrosDatosSA As New DocumentoOtrosDatosSA
                dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
                dt.Columns.Add(New DataColumn("nombreEntrega", GetType(String)))
                dt.Columns.Add(New DataColumn("periodoValorizacion", GetType(String)))
                dt.Columns.Add(New DataColumn("penalidades", GetType(String)))
                dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))
                dt.Columns.Add(New DataColumn("plazoContratacionInicio", GetType(String)))
                dt.Columns.Add(New DataColumn("plazoContratacionFin", GetType(String)))

                For Each i As documentoOtrosDatos In consultas
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = conteoCompras
                    dr(1) = Me.dgvCompras.Table.CurrentRecord.GetValue("item")
                    dr(2) = i.objetoContratacion
                    dr(3) = i.penalidades
                    dr(4) = i.importeContratacionMN.GetValueOrDefault
                    dr(5) = i.importeContratacionME.GetValueOrDefault
                    dr(6) = i.fechaInicio
                    dr(7) = i.fechaFin

                    dt.Rows.Add(dr)
                Next

                tsrTodo.Visible = False
                tsrItem.Visible = True
                tsrItem.Checked = True
                tsrTodo.Checked = False

                dgvDetalleOServicio.Visible = True
                dgvHistorialDetalle.Visible = False
                dgvDetalleOServicio.Dock = DockStyle.Fill
                dgvHistorialDetalle.Dock = DockStyle.None
                dgvDetalleOServicio.DataSource = dt

            End If

        End If

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompras.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvCompras.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal
                Case 18

                    'If IsNothing(GFichaUsuarios) Then
                    '    lblEstado.Text = "Debe iniciar una caja, antes de realizar esta operación.!"
                    '    PanelError.Visible = True
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    '    'Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = False
                    '    Exit Sub
                    'Else
                    If style.Enabled Then
                        Dim column As Integer = Me.dgvCompras.TableModel.NameToColIndex("chPago")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgvCompras.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex

                                Me.dgvCompras.TableModel(RowIndex, 19).CellValue = "No Pagado"

                            Else
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex

                                Me.dgvCompras.TableModel(RowIndex, 19).CellValue = "Pagado"



                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
                    'End If




                Case 20

                    '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                    If style.Enabled Then
                        Dim column As Integer = Me.dgvCompras.TableModel.NameToColIndex("chBonif")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgvCompras.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chBonif" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '      MsgBox(False)
                                Me.dgvCompras.TableModel(RowIndex, 21).CellValue = "N" ' curStatus

                                '******************************************************************

                                Dim cantidad As Decimal = 0
                                Dim VC As Decimal = 0
                                Dim VCme As Decimal = 0
                                Dim Igv As Decimal = 0
                                Dim IgvME As Decimal = 0
                                Dim totalMN As Decimal = 0
                                Dim colBI As Decimal = 0
                                Dim colBIme As Decimal = 0
                                Dim colPrecUnit As Decimal = 0
                                Dim colPrecUnitme As Decimal = 0
                                Dim colDestinoGravado As Integer
                                Dim colBonifica As String = Nothing

                                Dim valPercepMN As Decimal = 0
                                Dim valPercepME As Decimal = 0


                                colDestinoGravado = Me.dgvCompras.TableModel(RowIndex, 1).CellValue

                                If colDestinoGravado = 1 Then
                                    valPercepMN = Me.dgvCompras.TableModel(RowIndex, 8).CellValue
                                    valPercepME = Me.dgvCompras.TableModel(RowIndex, 13).CellValue
                                Else
                                    valPercepMN = 0
                                    valPercepME = 0
                                End If

                                '****************************************************************
                                '      colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")

                                cantidad = Me.dgvCompras.TableModel(RowIndex, 4).CellValue
                                Me.dgvCompras.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                                VC = Me.dgvCompras.TableModel(RowIndex, 5).CellValue
                                VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                                If cantidad > 0 AndAlso VC > 0 Then
                                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                                    colBI = VC + Igv + valPercepMN
                                    colBIme = VCme + IgvME + valPercepME

                                    colPrecUnit = Math.Round(VC / cantidad, 2)
                                    colPrecUnitme = Math.Round(VCme / cantidad, 2)
                                ElseIf cantidad = 0 Then
                                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
                                    colBI = VC + Igv + valPercepMN
                                    colBIme = VCme + IgvME + valPercepME
                                    colPrecUnit = 0
                                    colPrecUnitme = 0
                                Else
                                    colPrecUnit = 0
                                    colPrecUnitme = 0

                                    colBI = 0
                                    colBIme = 0
                                    Igv = 0
                                    IgvME = 0
                                End If


                                Select Case cboTipoDoc.SelectedValue
                                    Case "08"

                                    Case "03", "02"

                                        Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                        Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                        Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                        Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                        Me.dgvCompras.TableModel(RowIndex, 9).CellValue = VC.ToString("N2") 'importe total
                                        Me.dgvCompras.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2") 'importe total me

                                        Me.dgvCompras.TableModel(RowIndex, 7).CellValue = 0 'igvmn
                                        Me.dgvCompras.TableModel(RowIndex, 12).CellValue = 0 'igvme

                                        Me.dgvCompras.TableModel(RowIndex, 8).CellValue = 0 'percepcion
                                        Me.dgvCompras.TableModel(RowIndex, 13).CellValue = 0 'percepcion me


                                    Case Else
                                        If cboMoneda.SelectedValue = 1 Then
                                            ' DATOS SOLES

                                            Select Case colDestinoGravado
                                                Case "2", "3", "4"

                                                    Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                    Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                    Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                    Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                    Me.dgvCompras.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                    Me.dgvCompras.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                    Me.dgvCompras.TableModel(RowIndex, 7).CellValue = 0
                                                    Me.dgvCompras.TableModel(RowIndex, 12).CellValue = 0

                                                    Me.dgvCompras.TableModel(RowIndex, 8).CellValue = 0
                                                    Me.dgvCompras.TableModel(RowIndex, 13).CellValue = 0


                                                Case Else
                                                    If Me.dgvCompras.TableModel(RowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

                                                        Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                        Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                        Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                        Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")
                                                        Me.dgvCompras.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                        Me.dgvCompras.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                        Me.dgvCompras.TableModel(RowIndex, 7).CellValue = 0
                                                        Me.dgvCompras.TableModel(RowIndex, 12).CellValue = 0

                                                        Me.dgvCompras.TableModel(RowIndex, 8).CellValue = 0
                                                        Me.dgvCompras.TableModel(RowIndex, 13).CellValue = 0

                                                    Else
                                                        If cantidad > 0 Then


                                                            Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                            Me.dgvCompras.TableModel(RowIndex, 9).CellValue = colBI.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 14).CellValue = colBIme.ToString("N2")

                                                            Me.dgvCompras.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                                        Else

                                                            Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                            Me.dgvCompras.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                            Me.dgvCompras.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                                        End If

                                                    End If
                                            End Select

                                        ElseIf cboMoneda.SelectedValue = 2 Then

                                            Select Case colDestinoGravado
                                                Case "4"

                                                Case Else


                                            End Select

                                        End If
                                End Select

                            Else
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                Me.dgvCompras.TableModel(RowIndex, 21).CellValue = "S"

                                '******************************************************************

                                Dim cantidad As Decimal = 0
                                Dim VC As Decimal = 0
                                Dim VCme As Decimal = 0
                                Dim Igv As Decimal = 0
                                Dim IgvME As Decimal = 0
                                Dim totalMN As Decimal = 0
                                Dim colBI As Decimal = 0
                                Dim colBIme As Decimal = 0
                                Dim colPrecUnit As Decimal = 0
                                Dim colPrecUnitme As Decimal = 0
                                Dim colDestinoGravado As Integer
                                Dim colBonifica As String = Nothing
                                '****************************************************************


                                Dim valPercepMN As Decimal = 0
                                Dim valPercepME As Decimal = 0


                                colDestinoGravado = Me.dgvCompras.TableModel(RowIndex, 1).CellValue

                                If colDestinoGravado = 1 Then
                                    valPercepMN = Me.dgvCompras.TableModel(RowIndex, 8).CellValue
                                    valPercepME = Me.dgvCompras.TableModel(RowIndex, 13).CellValue
                                Else
                                    valPercepMN = 0
                                    valPercepME = 0
                                End If

                                '      colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                                cantidad = Me.dgvCompras.TableModel(RowIndex, 4).CellValue
                                Me.dgvCompras.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                                VC = Me.dgvCompras.TableModel(RowIndex, 5).CellValue
                                VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
                                If cantidad > 0 AndAlso VC > 0 Then
                                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

                                    colBI = VC + Igv
                                    colBIme = VCme + IgvME

                                    colPrecUnit = Math.Round(VC / cantidad, 2)
                                    colPrecUnitme = Math.Round(VCme / cantidad, 2)
                                ElseIf cantidad = 0 Then
                                    Igv = Math.Round(VC * (TmpIGV / 100), 2)
                                    IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
                                    colBI = VC + Igv
                                    colBIme = VCme + IgvME
                                    colPrecUnit = 0
                                    colPrecUnitme = 0
                                Else
                                    colPrecUnit = 0
                                    colPrecUnitme = 0

                                    colBI = 0
                                    colBIme = 0
                                    Igv = 0
                                    IgvME = 0
                                End If


                                Select Case cboTipoDoc.SelectedValue
                                    Case "08"

                                    Case "03", "02"

                                        Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                        Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                        Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                        Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                        Me.dgvCompras.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                        Me.dgvCompras.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                        Me.dgvCompras.TableModel(RowIndex, 7).CellValue = 0
                                        Me.dgvCompras.TableModel(RowIndex, 12).CellValue = 0

                                        Me.dgvCompras.TableModel(RowIndex, 8).CellValue = 0
                                        Me.dgvCompras.TableModel(RowIndex, 13).CellValue = 0


                                    Case Else
                                        If cboMoneda.SelectedValue = 1 Then
                                            ' DATOS SOLES

                                            Select Case colDestinoGravado
                                                Case "2", "3", "4"

                                                    Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                    Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                    Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                    Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                    Me.dgvCompras.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                    Me.dgvCompras.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                    Me.dgvCompras.TableModel(RowIndex, 7).CellValue = 0
                                                    Me.dgvCompras.TableModel(RowIndex, 12).CellValue = 0
                                                    Me.dgvCompras.TableModel(RowIndex, 8).CellValue = 0
                                                    Me.dgvCompras.TableModel(RowIndex, 13).CellValue = 0

                                                Case Else
                                                    If Me.dgvCompras.TableModel(RowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

                                                        Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                        Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                        Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                        Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                        Me.dgvCompras.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                        Me.dgvCompras.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                        Me.dgvCompras.TableModel(RowIndex, 7).CellValue = 0
                                                        Me.dgvCompras.TableModel(RowIndex, 12).CellValue = 0

                                                        Me.dgvCompras.TableModel(RowIndex, 8).CellValue = 0
                                                        Me.dgvCompras.TableModel(RowIndex, 13).CellValue = 0
                                                    Else
                                                        If cantidad > 0 Then


                                                            Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                            Me.dgvCompras.TableModel(RowIndex, 9).CellValue = colBI.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 14).CellValue = colBIme.ToString("N2")

                                                            Me.dgvCompras.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                                        Else

                                                            Me.dgvCompras.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

                                                            Me.dgvCompras.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

                                                            Me.dgvCompras.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
                                                            Me.dgvCompras.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


                                                        End If

                                                    End If
                                            End Select

                                        ElseIf cboMoneda.SelectedValue = 2 Then

                                            Select Case colDestinoGravado
                                                Case "4"

                                                Case Else


                                            End Select

                                        End If
                                End Select


                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
            End Select

            Me.dgvCompras.TableControl.Refresh()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompras.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 4 ' cantidad
                    Calculos()
                    eliminarDetalle()
                Case 5, 10 'Valor de compra
                    Calculos()
                    'eliminarDetalle()
                Case 6
                    Calculos()
                    'eliminarDetalle()
                Case 8
                    Dim colPercepcionME As Decimal = 0
                    colPercepcionME = Math.Round(CDec(Me.dgvCompras.Table.CurrentRecord.GetValue("percepcionMN")) / txtTipoCambio.DecimalValue, 2)
                    Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
                    Calculos()
                    'eliminarDetalle()
                Case 13
                    Dim colPercepcionMN As Decimal = 0
                    colPercepcionMN = Math.Round(CDec(Me.dgvCompras.Table.CurrentRecord.GetValue("percepcionME")) * txtTipoCambio.DecimalValue, 2)
                    Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", colPercepcionMN)
                    Calculos()
                    'eliminarDetalle()
                Case 14
                    If Me.dgvCompras.Table.CurrentRecord.GetValue("tipoExistencia") = "GS" Then
                        Me.dgvCompras.Table.CurrentRecord.SetValue("almacen", String.Empty)
                    End If

                Case 1
                    Calculos()
                    'eliminarDetalle()
            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellShowingDropDown(sender As Object, e As GridTableControlCurrentCellShowingDropDownEventArgs) Handles dgvCompras.TableControlCurrentCellShowingDropDown
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then

            If ColIndex = 24 Then

            ElseIf ColIndex = 16 Then

                If Me.dgvCompras.Table.CurrentRecord.GetValue("tipo") = "T" Then
                End If

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipo") = "A" Then

            ElseIf Me.dgvCompras.Table.CurrentRecord.GetValue("tipo") = "S" Then



            End If
        End If

        'End If
    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.White
    End Sub

    Private Sub cboServicio_SelectedValueChanged(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Dim servicioSA As New servicioSA
        'Dim servicio As New servicio
        'If cboServicio.SelectedIndex > -1 Then
        '    servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
        '    txtCuenta.Text = servicio.cuenta
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs)
        If txtTipoCambio.DecimalValue > 0 Then
            If txtServicio.Text.Trim.Length > 0 Then



                'If cboServicio.Text.Trim.Length > 0 Then
                '    If txtCuenta.Text.Trim.Length > 0 Then

                Me.dgvCompras.Table.AddNewRecord.SetCurrent()
                Me.dgvCompras.Table.AddNewRecord.BeginEdit()
                Me.dgvCompras.Table.CurrentRecord.SetValue("codigo", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("gravado", 1)
                Me.dgvCompras.Table.CurrentRecord.SetValue("idProducto", Nothing)
                Me.dgvCompras.Table.CurrentRecord.SetValue("item", txtServicio.Text.Trim)
                Me.dgvCompras.Table.CurrentRecord.SetValue("um", "07")
                Me.dgvCompras.Table.CurrentRecord.SetValue("cantidad", 1)
                Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", 0.0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", 0)

                Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", 0.0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("tipoExistencia", TipoRecurso.SERVICIO)
                Me.dgvCompras.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("pume", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("chPago", False)
                Me.dgvCompras.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                Me.dgvCompras.Table.CurrentRecord.SetValue("chBonif", False)
                Me.dgvCompras.Table.CurrentRecord.SetValue("valBonif", "N")
                Me.dgvCompras.Table.CurrentRecord.SetValue("presentacion", Nothing)
                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

                Me.dgvCompras.Table.CurrentRecord.SetValue("cat", Nothing)
                Me.dgvCompras.Table.CurrentRecord.SetValue("tipo", "S")
                Me.dgvCompras.Table.AddNewRecord.EndEdit()
                '    Else
                '        lblEstado.Text = "Seleccione un Servicio hijo"
                '        PanelError.Visible = True
                '        TiempoEjecutar(10)

                '    End If
                'Else
                '    lblEstado.Text = "Seleccione un Servicio hijo"
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                'End If


            Else
                lblEstado.Text = "Ingrese un Detalle"
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        Else
            MessageBox.Show("Debe ingresar un tipo de cambio mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaCategoria _
                     Where n.descripcion.StartsWith(txtCategoria.Text)).ToList

            lsvCategoria.DataSource = consulta
            lsvCategoria.DisplayMember = "descripcion"
            lsvCategoria.ValueMember = "idItem"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            lsvCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If

        '     End If
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        'If cboTipoExistencia.SelectedIndex > -1 Then
        '    If txtCategoria.Text.Trim.Length > 0 Then
        '        ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
        '    End If
        'End If
    End Sub

    Private Sub txtSubCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSubCategoria.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtSubCategoria
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaSubCategoria _
                     Where n.descripcion.StartsWith(txtSubCategoria.Text)).ToList

            lsvSubCategoria.DataSource = consulta
            lsvSubCategoria.DisplayMember = "descripcion"
            lsvSubCategoria.ValueMember = "idItem"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtSubCategoria
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            lsvSubCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcSubCategoria.IsShowing() Then
                Me.pcSubCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    'txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If

                'txtSerieGuia.Select()
                'txtSerieGuia.SelectAll()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If

    End Sub

    Private Sub lsvCategoria_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick_1(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim ITEMSA As New itemSA
        Dim ITEM As New item

        If txtTipoCambio.DecimalValue > 0 Then
            If lsvListadoItems.SelectedItems.Count > 0 Then
                Dim selFila As ListViewItem = lsvListadoItems.SelectedItems(0)

                'With objInsumo.InvocarProductoID(CInt(selFila.SubItems(0).Text))

                conteoCompras += 1

                Me.dgvCompras.Table.AddNewRecord.SetCurrent()
                Me.dgvCompras.Table.AddNewRecord.BeginEdit()
                Me.dgvCompras.Table.CurrentRecord.SetValue("codigo", conteoCompras)
                Me.dgvCompras.Table.CurrentRecord.SetValue("gravado", CStr(selFila.SubItems(4).Text))
                Me.dgvCompras.Table.CurrentRecord.SetValue("idProducto", CInt(selFila.SubItems(0).Text))
                Me.dgvCompras.Table.CurrentRecord.SetValue("item", CStr(selFila.SubItems(1).Text))
                Me.dgvCompras.Table.CurrentRecord.SetValue("um", CStr(selFila.SubItems(2).Text))
                Me.dgvCompras.Table.CurrentRecord.SetValue("cantidad", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", 0.0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", 0) '8

                Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", 0.0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("tipoExistencia", CStr(selFila.SubItems(3).Text))

                'Dim imItem = .idItem
                'If Not IsNothing(imItem) Then
                '    Me.dgvCompra.Table.CurrentRecord.SetValue("marca", CStr(imItem))
                'Else
                Me.dgvCompras.Table.CurrentRecord.SetValue("marca", Nothing)
                'End If


                Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("pume", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("chPago", False)
                Me.dgvCompras.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                Me.dgvCompras.Table.CurrentRecord.SetValue("chBonif", False)
                Me.dgvCompras.Table.CurrentRecord.SetValue("valBonif", "N")
                If CStr(selFila.SubItems(3).Text) <> "GS" Then
                    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                        Me.dgvCompras.Table.CurrentRecord.SetValue("almacen", Nothing)
                    Else
                        Me.dgvCompras.Table.CurrentRecord.SetValue("almacen", idAlmacenVirtual)
                    End If
                End If

                Me.dgvCompras.Table.CurrentRecord.SetValue("tipo", "A")

                Me.dgvCompras.Table.CurrentRecord.SetValue("presentacion", CStr(selFila.SubItems(8).Text))

                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

                'Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

                'Dim codCat = .idItem

                'If Not IsNothing(codCat) Then
                '    ITEM = ITEMSA.UbicarCategoriaPorID(.idItem)
                '    If Not IsNothing(ITEM) Then
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", ITEM.idPadre)
                '    Else
                Me.dgvCompras.Table.CurrentRecord.SetValue("cat", Nothing)

                Me.dgvCompras.Table.CurrentRecord.SetValue("tipoCompra", TIPO_COMPRA.ORDEN_COMPRA)
                Me.dgvCompras.Table.CurrentRecord.SetValue("estadoOrden", "PENDIENTE")

                'End If
                '    End If



                Me.dgvCompras.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)
                Me.dgvCompras.Table.CurrentRecord.SetValue("cantidadPen", 0)
                Me.dgvCompras.Table.AddNewRecord.EndEdit()

                tsrTodo.Visible = True
                tsrItem.Visible = True

                'End With
            End If

        Else
            MessageBox.Show("Ingrese un tipo de cambio mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim f As New frmNuevaClasificacion
        f.StartPosition = FormStartPosition.CenterParent

        f.ShowDialog()
        CMBClasificacion()

    End Sub

    Private Sub ToggleButton21_ButtonStateChanged_1(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        Me.Cursor = Cursors.WaitCursor
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            txtBuscarProducto.Visible = False
            btnNuevoProd.Visible = False

            Label16.Text = "Clasificación"
            txtCategoria.Visible = True
            PictureBox2.Visible = True
            Label42.Visible = True
            Label43.Visible = True

            Label35.Visible = True
            txtSubCategoria.Visible = True
            PictureBox6.Visible = True

            CMBClasificacion()

        Else
            txtBuscarProducto.Visible = True
            btnNuevoProd.Visible = True

            Label16.Text = "Buscar item"
            txtCategoria.Visible = False
            PictureBox2.Visible = False
            Label42.Visible = False
            Label43.Visible = False

            Label35.Visible = False
            txtSubCategoria.Visible = False
            PictureBox6.Visible = False

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvSubCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvSubCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcSubCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcSubCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvSubCategoria.SelectedItems.Count > 0 Then
                txtSubCategoria.Text = lsvSubCategoria.Text
                txtSubCategoria.Tag = lsvSubCategoria.SelectedValue

                ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtSubCategoria.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListaMercaderias(cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        If ListBox1.SelectedItems.Count > 0 Then
            Me.PopupControlContainer3.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PopupControlContainer3_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer3.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If ListBox1.SelectedItems.Count > 0 Then
                '   Me.TextBoxExt1.Tag = CStr(DirectCast(Me.ListBox1.SelectedItem, Categoria).Id)
                'txtCategoria.PasswordChar = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Utilidad)
                '   TextBoxExt1.Text = ListBox1.Text
                ListadoProductosPorCategoriaTipoExistencia(DirectCast(Me.ListBox1.SelectedItem, Categoria).Id, "08", DirectCast(Me.ListBox1.SelectedItem, Categoria).Utilidad, DirectCast(Me.ListBox1.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.ListBox1.SelectedItem, Categoria).UtilidadGranMayor)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            '  Me.TextBoxExt1.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PopupControlContainer3_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer3.BeforePopup
        Me.PopupControlContainer3.BackColor = Color.White
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
            Me.dgvCompras.Table.CurrentRecord.Delete()
            eliminarDetalle()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            'If Not txtSerie.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingresar un número de serie válido"
            '    PanelError.Visible = True
            '    TiempoEjecutar(10)
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'Else
            '    lblEstado.Text = "Done serie"
            'End If

            If Not txtProveedor.Tag > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"

                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"

            End If

            'If Not txtNumero.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingresar un número de comprobante válido"
            '    Timer1.Enabled = True
            '    PanelError.Visible = True
            '    TiempoEjecutar(10)

            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'Else
            '    lblEstado.Text = "Done número comprobante"

            'End If

            If Not txtTipoCambio.DecimalValue > 0 Then
                lblEstado.Text = "Ingresar un tipo de cambio mayor a cero!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtTipoCambio.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If


            '***********************************************************************
            If dgvCompras.Table.Records.Count > 0 Then
                Dim CONTEO As Integer = 0
                Me.lblEstado.Text = "Done!"
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    For Each item As Record In dgvCompras.Table.Records
                        If (item.GetValue("estadoOrden") = "PENDIENTE") Then
                            CONTEO += 1
                        End If
                    Next

                    If (CONTEO = 0) Then
                        Grabar()
                        Dispose()
                    Else
                        lblEstado.Text = "Debe ingresar todo los detalles de entrega de cada item!"
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtTipoCambio.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                  
                Else
                    'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    'If Filas > 0 Then
                    '    UpdateCompra()
                    'Else

                    '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)

                    'End If


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

            ListaAsientonTransito = New List(Of asiento)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        'Me.Cursor = Cursors.WaitCursor
        'Dim value As Object = Me.cboDepositoHijo.SelectedValue

        'If IsNumeric(value) Then
        '    cargarDatosCuenta(CInt(value))
        'Else

        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ComboBoxAdv1_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Dim n As New ListViewItem
        'lsvServicios.Items.Clear()
        'If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
        '    GetServiviosPadre()



        'ElseIf ComboBoxAdv1.Text = "ACTIVO INMOVILIZADO" Then

        '    n = New ListViewItem
        '    n.Text = "30"
        '    n.SubItems.Add("INVERSIONES MOVILIZARIAS")
        '    lsvServicios.Items.Add(n)

        '    n = New ListViewItem
        '    n.Text = "31"
        '    n.SubItems.Add("INVERSIONES INMOBILIARIAS")
        '    lsvServicios.Items.Add(n)

        '    n = New ListViewItem
        '    n.Text = "32"
        '    n.SubItems.Add("ACTIVOS ADQUIRIDOS EN ARRENDAMIENTO FINANCIERO")
        '    lsvServicios.Items.Add(n)

        '    n = New ListViewItem
        '    n.Text = "33"
        '    n.SubItems.Add("INMUEBLES MAQUINARIA Y EQUIPO")
        '    lsvServicios.Items.Add(n)

        '    n = New ListViewItem
        '    n.Text = "34"
        '    n.SubItems.Add("INTANGIBLES")
        '    lsvServicios.Items.Add(n)

        '    n = New ListViewItem
        '    n.Text = "35"
        '    n.SubItems.Add("ACTIVOS BIOLOGICOS")
        '    lsvServicios.Items.Add(n)

        '    n = New ListViewItem
        '    n.Text = "38"
        '    n.SubItems.Add("OTROS ACTIVOS")
        '    lsvServicios.Items.Add(n)

        'Else
        '    ComboBoxAdv1.Items.Clear()
        '    ComboBoxAdv1.Items.Add("SERVICIOS & GASTOS")
        '    ComboBoxAdv1.Items.Add("ACTIVO INMOVILIZADO")
        'End If
    End Sub

    Private Sub lsvServicios_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'txtCuenta.Text = ""

        'If lsvServicios.SelectedItems.Count > 0 Then

        '    If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
        '        GetServiviosHijo(lsvServicios.SelectedItems(0).SubItems(0).Text)
        '    Else
        '        GetServiviosHijoActivos(lsvServicios.SelectedItems(0).SubItems(0).Text)
        '    End If

        'Else
        '    lblEstado.Text = "Seleccione un Servicio Padre"
        'End If
        ''SDSSD()
        'If lsvServicios.SelectedItems.Count > 0 Then
        '    If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
        '        Dim servicioSA As New servicioSA
        '        Dim servicio As New servicio
        '        If cboServicio.SelectedIndex > -1 Then
        '            servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
        '            txtCuenta.Text = servicio.cuenta
        '        End If
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Dim servicioSA As New servicioSA
        'Dim servicio As New servicio
        'If cboServicio.SelectedIndex > -1 Then
        '    If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
        '        servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
        '        txtCuenta.Text = servicio.cuenta
        '    ElseIf ComboBoxAdv1.Text = "ACTIVO INMOVILIZADO" Then
        '        txtCuenta.Text = cboServicio.SelectedValue
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv15_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        If txtTipoCambio.DecimalValue > 0 Then
            If txtServicio.Text.Trim.Length > 0 Then



                'If cboServicio.Text.Trim.Length > 0 Then
                '    If txtCuenta.Text.Trim.Length > 0 Then

                conteoCompras += 1

                Me.dgvCompras.Table.AddNewRecord.SetCurrent()
                Me.dgvCompras.Table.AddNewRecord.BeginEdit()
                Me.dgvCompras.Table.CurrentRecord.SetValue("codigo", conteoCompras)
                Me.dgvCompras.Table.CurrentRecord.SetValue("gravado", 1)
                Me.dgvCompras.Table.CurrentRecord.SetValue("idProducto", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("item", txtServicio.Text.Trim)
                Me.dgvCompras.Table.CurrentRecord.SetValue("um", "07")
                Me.dgvCompras.Table.CurrentRecord.SetValue("cantidad", 1)
                Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", 0.0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", 0)

                Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", 0.0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("tipoExistencia", TipoRecurso.SERVICIO)
                Me.dgvCompras.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("pume", 0)
                Me.dgvCompras.Table.CurrentRecord.SetValue("chPago", False)
                Me.dgvCompras.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                Me.dgvCompras.Table.CurrentRecord.SetValue("chBonif", False)
                Me.dgvCompras.Table.CurrentRecord.SetValue("valBonif", "N")
                Me.dgvCompras.Table.CurrentRecord.SetValue("presentacion", Nothing)
                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

                Me.dgvCompras.Table.CurrentRecord.SetValue("cat", Nothing)
                Me.dgvCompras.Table.CurrentRecord.SetValue("tipo", "S")
                Me.dgvCompras.Table.CurrentRecord.SetValue("cantidadPen", 1)

                Me.dgvCompras.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)

                Me.dgvCompras.Table.CurrentRecord.SetValue("tipoCompra", TIPO_COMPRA.ORDEN_SERVICIO)
                Me.dgvCompras.Table.CurrentRecord.SetValue("estadoOrden", "PENDIENTE")

                Me.dgvCompras.Table.AddNewRecord.EndEdit()
                txtServicio.Clear()
                '    Else
                '        lblEstado.Text = "Seleccione un Servicio hijo"
                '        PanelError.Visible = True
                '        TiempoEjecutar(10)

                '    End If
                'Else
                '    lblEstado.Text = "Seleccione un Servicio hijo"
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)
                'End If


            Else
                lblEstado.Text = "Ingrese un Detalle"
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        Else
            MessageBox.Show("Debe ingresar un tipo de cambio mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim almacenSA As New almacenSA
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA

        Dim cat As New item
        Dim ITEMSA As New itemSA
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'If txtCategoria.Text.Trim.Length > 0 Then
        'If Not IsNothing(txtCategoria.Tag) Then
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '.cboIgv.Enabled = False
                '.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            '.txtCategoria.Tag = txtCategoria.Tag
            '.txtCategoria.Text = txtCategoria.Text
            ' .CboClasificacion.SelectedValue = CboClasificacion.SelectedValue
            '.cboProductos.SelectedValue = cboProductos.SelectedValue
            '  .cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue

            .UCNuenExistencia.cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                If txtTipoCambio.DecimalValue > 0 Then
                    If MessageBoxAdv.Show("Desea agregar el producto a la canasta de compras?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        If datos(0).Cuenta = "Grabado" Then
                            '  If lsvListadoItems.SelectedItems.Count > 0 Then

                            With objInsumo.InvocarProductoID(CInt(datos(0).ID))
                                Me.dgvCompras.Table.AddNewRecord.SetCurrent()
                                Me.dgvCompras.Table.AddNewRecord.BeginEdit()
                                Me.dgvCompras.Table.CurrentRecord.SetValue("codigo", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("item", .descripcionItem)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("um", .unidad1)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", 0.0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", 0)

                                Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", 0.0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", .marcaRef)

                                Dim imItem = .idItem
                                Me.dgvCompras.Table.CurrentRecord.SetValue("marca", CStr(imItem))

                                Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("pume", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("chPago", False)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                                Me.dgvCompras.Table.CurrentRecord.SetValue("chBonif", False)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("valBonif", "N")
                                If .tipoExistencia <> "GS" Then
                                    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("almacen", Nothing)
                                    Else
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("almacen", idAlmacenVirtual)
                                    End If
                                    'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                                End If
                                Me.dgvCompras.Table.CurrentRecord.SetValue("presentacion", .presentacion)

                                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("tipo", "A")

                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)

                                Me.dgvCompras.Table.CurrentRecord.SetValue("cat", ITEMSA.UbicarCategoriaPorID(.idItem).idPadre)
                                Me.dgvCompras.Table.AddNewRecord.EndEdit()
                            End With
                            ' End If


                        End If
                    End If
                Else
                    MessageBox.Show("Debe ingresar un t/c mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtTipoCambio.Select()
                End If

            End If
        End With
        'Else

        '    lblEstado.Text = "Debe elegir una clasificacion"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        'End If
        'Else
        '    lblEstado.Text = "Debe elegir una clasificacion"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        'End If

        Me.Cursor = Cursors.Arrow


        'Else

        '    lblEstado.Text = "Seleccione una Marca"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub btnNuevoProd_Click(sender As Object, e As EventArgs) Handles btnNuevoProd.Click
        Dim almacenSA As New almacenSA
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA

        Dim cat As New item
        Dim ITEMSA As New itemSA
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'If txtCategoria.Text.Trim.Length > 0 Then
        'If Not IsNothing(txtCategoria.Tag) Then
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                '.cboIgv.Enabled = False
                '.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            '.txtCategoria.Tag = txtCategoria.Tag
            '.txtCategoria.Text = txtCategoria.Text
            ' .CboClasificacion.SelectedValue = CboClasificacion.SelectedValue
            '.cboProductos.SelectedValue = cboProductos.SelectedValue
            '  .cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue

            .UCNuenExistencia.cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                If txtTipoCambio.DecimalValue > 0 Then
                    If MessageBoxAdv.Show("Desea agregar el producto a la canasta de compras?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        If datos(0).Cuenta = "Grabado" Then
                            '  If lsvListadoItems.SelectedItems.Count > 0 Then

                            With objInsumo.InvocarProductoID(CInt(datos(0).ID))
                                Me.dgvCompras.Table.AddNewRecord.SetCurrent()
                                Me.dgvCompras.Table.AddNewRecord.BeginEdit()
                                Me.dgvCompras.Table.CurrentRecord.SetValue("codigo", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("item", .descripcionItem)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("um", .unidad1)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("cantidad", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("vcmn", 0.0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("totalmn", 0)

                                Me.dgvCompras.Table.CurrentRecord.SetValue("vcme", 0.0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("totalme", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", .marcaRef)

                                Dim imItem = .idItem
                                Me.dgvCompras.Table.CurrentRecord.SetValue("marca", CStr(imItem))

                                Me.dgvCompras.Table.CurrentRecord.SetValue("pumn", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("pume", 0)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("chPago", False)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                                Me.dgvCompras.Table.CurrentRecord.SetValue("chBonif", False)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("valBonif", "N")
                                If .tipoExistencia <> "GS" Then
                                    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("almacen", Nothing)
                                    Else
                                        Me.dgvCompras.Table.CurrentRecord.SetValue("almacen", idAlmacenVirtual)
                                    End If
                                    'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                                End If
                                Me.dgvCompras.Table.CurrentRecord.SetValue("presentacion", .presentacion)

                                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                                Me.dgvCompras.Table.CurrentRecord.SetValue("tipo", "A")

                                'Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
                                Me.dgvCompras.Table.CurrentRecord.SetValue("fecEntrega", txtFecha.Value)

                                Me.dgvCompras.Table.CurrentRecord.SetValue("cat", ITEMSA.UbicarCategoriaPorID(.idItem).idPadre)
                                Me.dgvCompras.Table.AddNewRecord.EndEdit()
                            End With
                            ' End If
                        End If
                    End If
                Else
                    MessageBox.Show("Debe ingresar un t/c mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtTipoCambio.Select()
                End If

            End If
        End With
        'Else

        '    lblEstado.Text = "Debe elegir una clasificacion"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        'End If
        'Else
        '    lblEstado.Text = "Debe elegir una clasificacion"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        'End If

        Me.Cursor = Cursors.Arrow


        'Else

        '    lblEstado.Text = "Seleccione una Marca"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        'End If

    End Sub

    Private Sub ToggleButton1_ToggleStateChanged(sender As Object, e As ToggleStateChangedEventArgs) Handles ToggleButton1.ToggleStateChanged
        If ToggleButton1.ToggleState = ToggleButtonState.Active Then
            txtFGarantia.Visible = True
            txtFGarantia.Select()
            lblFGarantia.Visible = True
        ElseIf ToggleButton1.ToggleState = ToggleButtonState.Inactive Then
            txtFGarantia.Visible = False
            txtFGarantia.Select()
            lblFGarantia.Visible = False
        End If
    End Sub

    Private Sub tbDetraccion_ToggleStateChanged(sender As Object, e As ToggleStateChangedEventArgs) Handles tbDetraccion.ToggleStateChanged
        If tbDetraccion.ToggleState = ToggleButtonState.Active Then
            txtDetracciones.Visible = True
            txtDetracciones.Select()
            lblDetracciones.Visible = True
        ElseIf tbDetraccion.ToggleState = ToggleButtonState.Inactive Then
            txtDetracciones.Visible = False
            txtDetracciones.Select()
            lblDetracciones.Visible = False
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim cantidadTotal As Integer = 0
        Dim total As Integer = 0
        Dim cantidadEntrega As Integer
        Dim conteoCantidad As Integer = 0

        If (tsrTodo.Checked = True) Then

            For Each item As Record In dgvCompras.Table.Records

                If (item.GetValue("cantidad") = 0) Then
                    conteoCantidad += 1
                End If

            Next

            If (conteoCantidad = 0) Then
                Dim f As New frmModalHistorialOC
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Normal
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.ubicar("1")
                f.ShowDialog()
                actualizaDataGridEstadoFull()
            Else
                tsrItem.Checked = False
                tsrTodo.Checked = False
                PanelError.Visible = True
                lblEstado.Text = "Debe ingresar todas las cantidades de los items"
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If

          
        ElseIf (tsrItem.Checked = True) Then
            If (Not IsNothing(Me.dgvCompras.Table.CurrentRecord)) Then
                If (Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.ORDEN_COMPRA) Then


                    If (Me.dgvCompras.Table.CurrentRecord.GetValue("cantidad") > 0) Then
                        If (Me.dgvCompras.Table.CurrentRecord.GetValue("cantidadPen") > 0) Then
                            Dim f As New frmModalHistorialOC
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            cantidadTotal = Me.dgvCompras.Table.CurrentRecord.GetValue("cantidad")
                            cantidadEntrega = Me.dgvCompras.Table.CurrentRecord.GetValue("cantidadPen")
                            f.txtCantidad.Text = cantidadEntrega
                            f.lblIdDocumento.Text = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
                            f.txtNombreItem.Text = Me.dgvCompras.Table.CurrentRecord.GetValue("item")
                            f.cantidad = cantidadEntrega
                            f.pnDetallesOC.Enabled = True
                            'f.data = dgvCompras
                            f.idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
                            f.secuencias = Me.dgvCompras.Table.CurrentRecord.GetValue("secuencia")
                            f.item = Me.dgvCompras.Table.CurrentRecord.GetValue("idProducto")
                            f.ubicarPorItem("2", Me.dgvCompras.Table.CurrentRecord.GetValue("secuencia"), Me.dgvCompras.Table.CurrentRecord.GetValue("idItem"))
                            f.ShowDialog()
                            tsrItem.Checked = False
                            tsrTodo.Checked = True
                            actualizaDataGridEstado()
                        End If
                       
                    Else
                        tsrItem.Checked = False
                        tsrTodo.Checked = False
                        PanelError.Visible = True
                        lblEstado.Text = "Debe ingresar una cantidad del item seleccionado"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If


                ElseIf (Me.dgvCompras.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.ORDEN_SERVICIO) Then
                    If (Me.dgvCompras.Table.CurrentRecord.GetValue("cantidad") > 0) Then
                        If (Me.dgvCompras.Table.CurrentRecord.GetValue("vcmn") > 0) Then
                            Dim f As New frmModalHistorialOS
                            f.StartPosition = FormStartPosition.CenterParent
                            f.WindowState = FormWindowState.Normal
                            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            cantidadTotal = Me.dgvCompras.Table.CurrentRecord.GetValue("cantidad")
                            cantidadEntrega = Me.dgvCompras.Table.CurrentRecord.GetValue("cantidadPen")
                            f.txtNombreEntregable.Text = Me.dgvCompras.Table.CurrentRecord.GetValue("item")
                            f.txtImporteContratacion.Value = Me.dgvCompras.Table.CurrentRecord.GetValue("totalmn")
                            f.txtImporteContratacionME.Value = Me.dgvCompras.Table.CurrentRecord.GetValue("totalme")
                            f.GroupBox3.Enabled = True
                            f.ShowDialog()
                            tsrItem.Checked = False
                            tsrTodo.Checked = True
                            actualizaDataGridEstadoOS()
                        Else
                            tsrItem.Checked = False
                            tsrTodo.Checked = False
                            PanelError.Visible = True
                            lblEstado.Text = "Ingresar importe del item seleccionado"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If
                    Else
                        tsrItem.Checked = False
                        tsrTodo.Checked = False
                        PanelError.Visible = True
                        lblEstado.Text = "Ingresar una cantidad del item seleccionado"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If

                Else
                    tsrItem.Checked = False
                    tsrTodo.Checked = True
                    PanelError.Visible = True
                    lblEstado.Text = "Debe seleccionar un item"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If


            End If

        End If


        'HistorialCompra(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
    End Sub

    Sub actualizaDataGridEstado()
        Dim n As New RecuperarEntregables()
        Dim datos As List(Of RecuperarEntregables) = RecuperarEntregables.Instance()
        Dim conteokiojklj As Integer = 0
        Dim cantidad As Integer = 0
        Dim cantidadEntrg As Integer = 0
        Dim objOtrosDAtos As New documentoOtrosDatos

        If ((datos.Count) > 0) Then

            Me.dgvHistorialDetalle.Table.AddNewRecord.SetCurrent()
            Me.dgvHistorialDetalle.Table.AddNewRecord.BeginEdit()

            conteokiojklj = Me.dgvCompras.Table.CurrentRecord.GetValue("codigo")

            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("idDocumento", conteokiojklj)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("secuencia", 0)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("cantidad", datos(0).cantidad)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("idAlmacen", datos(0).idAlmacen)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("nombreAlmacen", datos(0).nombreAlmacen)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("direccionAlmacen", datos(0).direccionAlmacen)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("fechainicio", datos(0).fechaIncio)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("fechaFin", datos(0).fechaFin)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("FechaIniGarantia", datos(0).fechaInicioGarantia)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("FechaFinGarantia", datos(0).fechaFinGarantia)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("notas", datos(0).notas)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("indicaciones", datos(0).indicaciones)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("idItem", datos(0).idItem)
            Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("estado", Nothing)
            Me.dgvHistorialDetalle.Table.AddNewRecord.EndEdit()


            With objOtrosDAtos
                .idDocumento = conteokiojklj
                .idEmpresa = Gempresas.IdEmpresaRuc
                .CentroCostos = GEstableciento.IdEstablecimiento
                .cantidad = datos(0).cantidad
                .idAlmacen = datos(0).idAlmacen
                .nombreAlmacen = datos(0).nombreAlmacen
                .direccionAlmacen = datos(0).direccionAlmacen
                .fechaInicio = datos(0).fechaIncio
                .fechaFin = datos(0).fechaFin
                .FechaIniGarantia = datos(0).fechaInicioGarantia
                .FechaFinGarantia = datos(0).fechaFinGarantia
                .notas = datos(0).notas
                .indicaciones = datos(0).indicaciones
                .idItem = datos(0).idItem
            End With


            ListaDetalleEntrega.Add(objOtrosDAtos)


            For Each r As Record In dgvHistorialDetalle.Table.Records

                cantidad += Me.dgvHistorialDetalle.Table.CurrentRecord.GetValue("cantidad")

            Next
            cantidad += datos(0).cantidad

            cantidad = cantidad
            cantidadEntrg = Me.dgvCompras.Table.CurrentRecord.GetValue("cantidadPen")


            If ((cantidadEntrg - cantidad) = 0) Then
                dgvCompras.Table.CurrentRecord.SetValue("estadoOrden", "LISTO")
            End If

            dgvCompras.Table.CurrentRecord.SetValue("cantidadPen", cantidadEntrg - cantidad)
        End If
    End Sub

    Sub actualizaDataGridEstadoFull()
        Dim n As New RecuperarEntregables()
        Dim datos As List(Of RecuperarEntregables) = RecuperarEntregables.Instance()
        Dim conteokiojklj As Integer = 0
        Dim cantidad As Integer = 0
        Dim cantidadEntrg As Integer = 0
        Dim objOtrosDAtos As New documentoOtrosDatos

        If ((datos.Count) > 0) Then

            For Each item As Record In dgvCompras.Table.Records

                If (item.GetValue("cantidadPen") <> 0 And item.GetValue("tipoCompra") = TIPO_COMPRA.ORDEN_COMPRA) Then
                    Me.dgvHistorialDetalle.Table.AddNewRecord.SetCurrent()
                    Me.dgvHistorialDetalle.Table.AddNewRecord.BeginEdit()
                    conteokiojklj = Me.dgvCompras.Table.CurrentRecord.GetValue("codigo")
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("idDocumento", item.GetValue("codigo"))
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("secuencia", 0)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("cantidad", item.GetValue("cantidadPen"))
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("idAlmacen", datos(0).idAlmacen)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("nombreAlmacen", datos(0).nombreAlmacen)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("direccionAlmacen", datos(0).direccionAlmacen)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("fechainicio", datos(0).fechaIncio)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("fechaFin", datos(0).fechaFin)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("FechaIniGarantia", datos(0).fechaInicioGarantia)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("FechaFinGarantia", datos(0).fechaFinGarantia)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("notas", datos(0).notas)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("indicaciones", datos(0).indicaciones)
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("idItem", item.GetValue("idProducto"))
                    Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("estado", "LISTO")
                    Me.dgvHistorialDetalle.Table.AddNewRecord.EndEdit()

                    objOtrosDAtos = New documentoOtrosDatos
                    With objOtrosDAtos
                        .idDocumento = item.GetValue("codigo")
                        .idEmpresa = Gempresas.IdEmpresaRuc
                        .CentroCostos = GEstableciento.IdEstablecimiento
                        .cantidad = item.GetValue("cantidadPen")
                        .idAlmacen = datos(0).idAlmacen
                        .nombreAlmacen = datos(0).nombreAlmacen
                        .direccionAlmacen = datos(0).direccionAlmacen
                        .fechaInicio = datos(0).fechaIncio
                        .fechaFin = datos(0).fechaFin
                        .FechaIniGarantia = datos(0).fechaInicioGarantia
                        .FechaFinGarantia = datos(0).fechaFinGarantia
                        .notas = datos(0).notas
                        .indicaciones = datos(0).indicaciones
                        .idItem = item.GetValue("idProducto")
                    End With

                    ListaDetalleEntrega.Add(objOtrosDAtos)
                    item.SetValue("cantidadPen", 0)
                    item.SetValue("estadoOrden", "LISTO")
                End If

            Next

        End If

        Me.dgvHistorialDetalle.Table.Records.DeleteAll()

    End Sub

    Sub actualizaDataGridEstadoOS()
        Dim n As New RecuperarEntregables()
        Dim datos As List(Of RecuperarEntregables) = RecuperarEntregables.Instance()
        Dim conteokiojklj As Integer = 0
        Dim cantidad As Integer = 0
        Dim cantidadEntrg As Integer = 0
        Dim objOtrosDAtos As New documentoOtrosDatos

        If ((datos.Count) > 0) Then
            Me.dgvDetalleOServicio.Table.AddNewRecord.SetCurrent()
            Me.dgvDetalleOServicio.Table.AddNewRecord.BeginEdit()
            conteokiojklj = Me.dgvCompras.Table.CurrentRecord.GetValue("codigo")
            Me.dgvDetalleOServicio.Table.CurrentRecord.SetValue("idDocumento", conteokiojklj)
            Me.dgvDetalleOServicio.Table.CurrentRecord.SetValue("nombreEntrega", datos(0).nombreItem)
            Me.dgvDetalleOServicio.Table.CurrentRecord.SetValue("periodoValorizacion", datos(0).periodoValorizacion)
            Me.dgvDetalleOServicio.Table.CurrentRecord.SetValue("penalidades", datos(0).penalidades)
            Me.dgvDetalleOServicio.Table.CurrentRecord.SetValue("importeMN", datos(0).importeMN)
            Me.dgvDetalleOServicio.Table.CurrentRecord.SetValue("importeME", datos(0).importeME)
            Me.dgvDetalleOServicio.Table.CurrentRecord.SetValue("plazoContratacionInicio", datos(0).fechaIncio)
            Me.dgvDetalleOServicio.Table.CurrentRecord.SetValue("plazoContratacionFin", datos(0).fechaFin)
            Me.dgvDetalleOServicio.Table.AddNewRecord.EndEdit()


            With objOtrosDAtos
                .idDocumento = conteokiojklj
                .idEmpresa = Gempresas.IdEmpresaRuc
                .CentroCostos = GEstableciento.IdEstablecimiento
                '.cantidad = Me.dgvCompras.Table.CurrentRecord.GetValue("cantidad")
                .periodoValorizacion = datos(0).periodoValorizacion
                .importeContratacionMN = datos(0).importeMN
                .importeContratacionME = datos(0).importeME
                .penalidades = datos(0).penalidades
                .fechaInicio = datos(0).fechaIncio
                .fechaFin = datos(0).fechaFin
            End With
            ListaDetalleEntrega.Add(objOtrosDAtos)

            'For Each r As Record In dgvHistorialDetalle.Table.Records
            '    cantidad += Me.dgvHistorialDetalle.Table.CurrentRecord.GetValue("cantidad")
            'Next
            'cantidad += datos(0).cantidad

            'cantidad = cantidad
            'cantidadEntrg = Me.dgvCompras.Table.CurrentRecord.GetValue("cantidadPen")


            'If ((cantidadEntrg - cantidad) = 0) Then
            dgvCompras.Table.CurrentRecord.SetValue("estadoOrden", "LISTO")
            'End If

            dgvCompras.Table.CurrentRecord.SetValue("cantidadPen", 0)
        End If
    End Sub

    Sub eliminarDetalle()
        If (Not IsNothing(Me.dgvCompras.Table.CurrentRecord)) Then
            Dim consulta = (From a In ListaDetalleEntrega Where a.idDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("codigo")).ToList
            For Each item In consulta
                ListaDetalleEntrega.Remove(item)
            Next
            dgvHistorialDetalle.Table.Records.DeleteAll()
        End If

    End Sub


    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub DockingClientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles DockingClientPanel1.Paint

    End Sub
End Class