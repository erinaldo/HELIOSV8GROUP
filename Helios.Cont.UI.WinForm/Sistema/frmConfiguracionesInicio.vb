Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmConfiguracionesInicio
    Inherits frmMaster

    Private dtTableGrd As DataTable
    Dim almacen As List(Of almacen)
    Public Property TipoModulo() As String

    Public Sub New()

        ' Llamada necesaria para el diseñador.


        Me.WindowState = FormWindowState.Maximized

        InitializeComponent()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        SetRenderer()
        IniciarControles()
        'If Not IsNothing(GEstableciento) Then
        '    If Not IsNothing(GEstableciento.NombreEstablecimiento) Then
        '        txtEstablecimiento.ValueMember = GEstableciento.IdEstablecimiento
        '        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento

        '    End If
        'End If
        'If ((lstAlmacen.Items.Count) > 0) Then
        '    txtAlmacenTrab.Text = lstAlmacen.SelectedItems(0)
        '    'txtAlmacenTrab .ValueMember =0
        'End If
        'nupIGV.Value = 18.0
        'nudTipoCambio.Value = 3.0
        'cboIVA.SelectedIndex = -1

        'TmpIGV = 18.0
        'TmpTipoCambio = 3.0
        'TmpTipoIVA = "SIVA"
    End Sub

#Region "DOCKING"
    Public Sub DOckControls()
        dockingManager1.DockControl(PanelSerie, Me, DockingStyle.Right, 305)
        dockingManager1.SetDockLabel(PanelSerie, "Series")
        dockingManager1.CloseEnabled = False
    End Sub
#End Region

    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        tbAlmacen.Renderer = styleRenderer1
        Dim styleRenderer2 As New StyledRenderer()
        tbEF.Renderer = styleRenderer2
        'Dim styleRenderer3 As New StyledRenderer()
        'toggleButton11.Renderer = styleRenderer3
        'Dim styleRenderer4 As New StyledRenderer()
        'toggleButton12.Renderer = styleRenderer4
        Panel2.Visible = False
    End Sub

#Region "Métodos"
#Region "ESTABLECIMIENTO"
    Public Class Destablecimiento

        Private _name As String
        Private _id As Integer
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
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
    End Class

    'Private Sub GrabarEstablecimiento()
    '    Dim estableSA As New establecimientoSA
    '    Dim estable As New centrocosto
    '    With estable
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .nombre = txtNewEstable.Text.Trim
    '        .TipoEstab = cboTipoEstable.SelectedValue
    '        .usuarioActualizacion = "Jiuni"
    '        .fechaActualizacion = DateTime.Now
    '    End With
    '    Dim codx As Integer = estableSA.InsertEstablecimiento(estable)

    '    GEstableciento.IdEstablecimiento = codx
    '    GEstableciento.NombreEstablecimiento = txtNewEstable.Text.Trim

    '    lstEstablecimiento.Items.Add(New Destablecimiento(txtNewEstable.Text.Trim, codx))
    '    txtEstablecimiento.ValueMember = codx
    '    txtEstablecimiento.Text = txtNewEstable.Text.Trim
    'End Sub
#End Region

    Public Sub GrabarSerieModulo()
        Dim numeracionSA As New NumeracionBoletaSA
        Dim numeracion As New numeracionBoletas

        With numeracion
            .empresa = Gempresas.IdEmpresaRuc
            .establecimiento = GEstableciento.IdEstablecimiento
            .codigoNumeracion = txtSelModulo.ValueMember
            .tipo = cboTipoDoc.SelectedValue
            .serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieNew.Text))
            .valorInicial = nudValInicialNew.Value
            .valorMinimo = 0
            .valorMaximo = 1000000000
            .incremento = nudValIncrementoNew.Value

            If PanelVisibleFac.Visible = True Then
                .tipo1 = "01"
                .serie1 = String.Format("{0:00000}", Convert.ToInt32(txtSerieFac.Text.Trim))
                .valorInicial1 = nudValInicial2.Value
                .valorMinimo1 = 0
                .valorMaximo1 = 1000000000
                .incremento1 = nudValIncremento2.Value
            End If
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        numeracionSA.InsertNumBoletas(numeracion)
        ObtenerListaSeriesPorModulo(lstModulos.SelectedValue)

    End Sub


    Private Sub GrabarConfiguracion(intIdConfigComprobante As Integer, strTipoConfig As String)
        Dim moduloSA As New ModuloConfiguracionSA
        Dim modulo As New moduloConfiguracion
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TAblaSA As New tablaDetalleSA
        With modulo
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idModulo = txtSelModulo.ValueMember
            .tipoConfiguracion = strTipoConfig ' IIf(rbManual.Checked = True, "M", "P")
            .configComprobante = intIdConfigComprobante ' CInt(lstTipoDoc.SelectedValue)
        End With
        Dim xCod As Integer = moduloSA.GrabarConfigSistema(modulo)
        UbicarModuloConfig(xCod)
    End Sub

    'Private Sub GrabarAnio()
    '    Dim AnioSA As New empresaPeriodoSA
    '    Dim Anio As New empresaPeriodo
    '    Try
    '        Anio.idEmpresa = Gempresas.IdEmpresaRuc
    '        Anio.periodo = txtnewAnio.Value.Year
    '        Anio.usuarioActualizacion = "Jiuni"
    '        Anio.fechaActualizacion = DateTime.Now
    '        AnioSA.InsertarPeriodo(Anio)

    '        Dim AniosSA As New empresaPeriodoSA
    '        cboAnios.DisplayMember = "periodo"
    '        cboAnios.ValueMember = "periodo"
    '        cboAnios.DataSource = AniosSA.GetListar_empresaPeriodo(Gempresas.IdEmpresaRuc)

    '        PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month)) & "/" & txtnewAnio.Value.Year
    '        AnioGeneral = txtnewAnio.Value.Year
    '        cboAnios.Text = AnioGeneral ' txtnewAnio.Value.Year
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub UpdateConfiguracion(intIdConfigComprobante As Integer, strTipoConfig As String)
        Dim moduloSA As New ModuloConfiguracionSA
        Dim modulo As New moduloConfiguracion
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TAblaSA As New tablaDetalleSA
        With modulo
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idModulo = txtSelModulo.ValueMember
            .tipoConfiguracion = strTipoConfig ' IIf(rbManual.Checked = True, "M", "P")
            .configComprobante = intIdConfigComprobante ' CInt(lstTipoDoc.SelectedValue)
        End With
        Dim codx As Integer = moduloSA.UpdateConfigSistema(modulo)
        UbicarModuloConfig(codx)
    End Sub

    Private Sub UpdateConfiguracionGeneric()
        Dim moduloSA As New ModuloConfiguracionSA
        Dim modulo As New moduloConfiguracion
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TAblaSA As New tablaDetalleSA
        With modulo
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idModulo = txtSelModulo.ValueMember
            .tipoConfiguracion = IIf(txtConfig.Text = "Manual", "M", "P")
            If txtIdComprobante.Text.Trim.Length > 0 Then
                .configComprobante = txtIdComprobante.Text
            End If
            If txtCuentaFinanciera.Text.Trim.Length > 0 Then
                .ConfigentidadFinanciera = txtCuentaFinanciera.ValueMember
            Else
                .ConfigentidadFinanciera = Nothing
            End If

        End With
        moduloSA.UpdateConfigSistema(modulo)
    End Sub

    Enum MODULOS
        COMPRA = 0
        VENTA = 1
    End Enum
    Private Sub UbicarNumeracionPorID(intIdNumeracion As Integer)
        Dim numeracionSA As New NumeracionBoletaSA

        With numeracionSA.GetUbicar_numeracionBoletasPorID(intIdNumeracion)
            txtSerieConf.Text = .serie
        End With
    End Sub

    Public Sub ObtenerListaSeriesPorModulo(strModulo As String)
        Dim numeracionSA As New NumeracionBoletaSA
        lsvSeriesModulo.Items.Clear()
        For Each i In numeracionSA.ObtenerSeriesPorModulo(GEstableciento.IdEstablecimiento, strModulo)
            Dim n As New ListViewItem(i.IdEnumeracion)
            n.SubItems.Add(i.tipo)
            n.SubItems.Add(i.serie)
            n.SubItems.Add(i.valorInicial)
            n.SubItems.Add(i.incremento)
            lsvSeriesModulo.Items.Add(n)
        Next

    End Sub

    Private Sub ListaPredeterminados(NModulo As String)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        Select Case NModulo
            Case MODULOS.COMPRA
                For Each i As numeracionBoletas In numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "COMPRA")
                    dt.Rows.Add(i.IdEnumeracion, TablaSA.GetUbicarTablaID(10, i.tipo).descripcion)
                Next
                lstTipoDoc.DisplayMember = "Name"
                lstTipoDoc.ValueMember = "ID"
                lstTipoDoc.DataSource = dt 'numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "COMPRA")
            Case MODULOS.VENTA
                For Each i As numeracionBoletas In numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "VENTA")
                    dt.Rows.Add(i.IdEnumeracion, TablaSA.GetUbicarTablaID(10, i.tipo).descripcion)
                Next
                lstTipoDoc.DisplayMember = "Name"
                lstTipoDoc.ValueMember = "ID"
                lstTipoDoc.DataSource = dt  ' numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "VENTA")
        End Select
    End Sub

    Public Sub IniciarControles()

        Dim estableSA As New establecimientoSA
        Dim almacenSA As New almacenSA

        For Each i In estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
            lstEstablecimiento.Items.Add(New Destablecimiento(i.nombre, i.idCentroCosto))
        Next
        lstEstablecimiento.DisplayMember = "Name"
        lstEstablecimiento.ValueMember = "Id"

        Dim moduloSA As New ModuloConfiguracionSA
        lstModulos.DisplayMember = "descripcionModulo"
        lstModulos.ValueMember = "idModulo"
        lstModulos.DataSource = moduloSA.ListaModulos()

        Dim tablaSA As New tablaDetalleSA
        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

        'lstAlmacen.DisplayMember = "descripcionAlmacen"
        'lstAlmacen.ValueMember = "idAlmacen"
        'almacen = almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
        'lstAlmacen.DataSource = almacen

        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(10, "1")

        'cboTipoEstable.ValueMember = "codigoDetalle"
        'cboTipoEstable.DisplayMember = "descripcion"
        'cboTipoEstable.DataSource = tablaSA.GetListaTablaDetalle(14, "1")

        'Dim AniosSA As New empresaPeriodoSA
        'cboAnios.DisplayMember = "periodo"
        'cboAnios.ValueMember = "periodo"
        'cboAnios.DataSource = AniosSA.GetListar_empresaPeriodo(Gempresas.IdEmpresaRuc)

        'UbicarExistencias()
    End Sub

    Public Sub ObtenerEntidadesFinancieras(ByVal intIdEstablecimiento As Integer, ByVal strTipoEF As String, ByVal strMoneda As String)
        Dim objEstados As New EstadosFinancierosSA
        Try
            lstCuentaFinanciera.DisplayMember = "descripcion"
            lstCuentaFinanciera.ValueMember = "idestado"
            lstCuentaFinanciera.DataSource = objEstados.ObtenerEstadosFinancierosPorMoneda(intIdEstablecimiento, strTipoEF, strMoneda)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información para la lista de EF." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            Select Case txtSelModulo.ValueMember
                Case "C2", "C3"
                    'tbAlmacen.ToggleState = ToggleButtonState.Inactive
                    'tbAlmacen.Visible = False
                    TipoModulo = "0"

                Case "C1"
                    TipoModulo = "0"
                Case Else
                    TipoModulo = "1"
            End Select

            txtModulo.Text = txtSelModulo.Text
            txtCodigo.Text = txtSelModulo.ValueMember

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                txtComprobante.Text = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                txtIdComprobante.Text = RecuperacionNumeracion.IdEnumeracion
                txtSerie.Text = RecuperacionNumeracion.serie
                txtNumImpresiones.Text = RecuperacionNumeracion.valorInicial
                If PanelVisibleFac.Visible = True Then
                    If Not IsNothing(RecuperacionNumeracion.tipo1) Then
                        txtDocCF2.Text = "FACTURA"
                        txtSerieCF2.Text = RecuperacionNumeracion.serie1
                        TextBoxExt1.Text = RecuperacionNumeracion.valorInicial1
                    End If
                End If

            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdestablecimiento As integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA
    '    Dim numeracion As New numeracionBoletas

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdestablecimiento)
    '    Select Case txtSelModulo.ValueMember
    '        Case "C2", "C3"
    '            'tbAlmacen.ToggleState = ToggleButtonState.Inactive
    '            'tbAlmacen.Visible = False
    '            TipoModulo = "0"

    '        Case "C1"
    '            TipoModulo = "0"
    '        Case Else
    '            TipoModulo = "1"
    '    End Select

    '    txtModulo.Text = txtSelModulo.Text
    '    txtCodigo.Text = txtSelModulo.ValueMember
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            txtConfig.Text = IIf(.tipoConfiguracion = "P", "Automático", "Manual")
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            'Select Case .idModulo
    '            '    Case "C1", "C3"
    '            '        tbAlmacen.Visible = False
    '            '    Case Else
    '            '        tbAlmacen.Visible = True
    '            'End Select


    '            Select Case .tipoConfiguracion


    '                Case "P"
    '                    numeracion = numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                    If Not IsNothing(numeracion) Then
    '                        With numeracion
    '                            GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                            GConfiguracion.TipoComprobante = .tipo
    '                            GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                            GConfiguracion.Serie = .serie
    '                            GConfiguracion.ValorActual = .valorInicial
    '                            txtComprobante.Text = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                            txtIdComprobante.Text = .IdEnumeracion
    '                            txtSerie.Text = .serie
    '                            txtNumImpresiones.Text = .valorInicial
    '                            If PanelVisibleFac.Visible = True Then
    '                                If Not IsNothing(.tipo1) Then
    '                                    txtDocCF2.Text = "FACTURA"
    '                                    txtSerieCF2.Text = .serie1
    '                                    TextBoxExt1.Text = .valorInicial1
    '                                End If
    '                            End If

    '                        End With
    '                    End If

    '                Case "M"
    '                    txtComprobante.Clear()
    '                    txtSerie.Clear()
    '                    txtNumImpresiones.Clear()

    '                    txtDocCF2.Clear()
    '                    txtSerieCF2.Clear()
    '                    TextBoxExt1.Clear()
    '            End Select
    '        End With
    '    Else
    '        tbAlmacen.ToggleState = ToggleButtonState.Inactive

    '        txtConfig.Text = "No tiene configuración"
    '        txtComprobante.Clear()
    '        txtSerie.Clear()
    '        txtNumImpresiones.Clear()
    '        '  lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub UbicarModuloConfig(intIdConfig As Integer)
        Dim moduloSA As New ModuloConfiguracionSA
        Dim numeracionSA As New NumeracionBoletaSA
        Dim numeracion As New numeracionBoletas
        Dim tablaSA As New tablaDetalleSA

        With moduloSA.UbicarConfiguracionPorID(intIdConfig)
            numeracion = numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
            txtCodigo.Text = txtSelModulo.ValueMember
            txtModulo.Text = txtSelModulo.Text
            txtConfig.Text = IIf(.tipoConfiguracion = "M", "Manual", "Programado")
            Select Case .tipoConfiguracion
                Case "M"
                    txtComprobante.Clear()
                    txtSerie.Clear()
                    txtNumImpresiones.Clear()

                    txtDocCF2.Clear()
                    txtSerieCF2.Clear()
                    TextBoxExt1.Clear()
                Case Else
                    txtComprobante.Text = tablaSA.GetUbicarTablaID(10, numeracion.tipo).descripcion
                    txtSerie.Text = numeracion.serie
                    txtNumImpresiones.Text = numeracion.valorInicial

                    If PanelVisibleFac.Visible = True Then
                        txtDocCF2.Text = "FACTURA"
                        txtSerieCF2.Text = numeracion.serie1
                        TextBoxExt1.Text = numeracion.valorInicial1
                    End If
            End Select


        End With
    End Sub
#End Region

    Private Sub frmConfiguracionesInicio_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmConfiguracionesInicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        chModulo.Checked = True
        'cboAnios.SelectedValue = AnioGeneral
        'txtMes.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstModulos.SelectedItems.Count > 0 Then
                Me.txtSelModulo.ValueMember = lstModulos.SelectedValue
                txtSelModulo.Text = lstModulos.Text
                txtCuentaFinanciera.Clear()
                txtCuentaFinanciera.ValueMember = Nothing
                configuracionModuloV2(Gempresas.IdEmpresaRuc, lstModulos.SelectedValue, lstModulos.Text, GEstableciento.IdEstablecimiento)
                ObtenerListaSeriesPorModulo(lstModulos.SelectedValue)
                Select Case txtSelModulo.ValueMember
                    Case "VT1"
                        PaneDoc2.Visible = False
                        PanelVisibleFac.Visible = False
                        cboTipoDoc.SelectedValue = "9907"
                        cboTipoDoc.Enabled = False
                    Case "VT2"
                        PaneDoc2.Visible = True
                        PanelVisibleFac.Visible = True
                        cboTipoDoc.SelectedValue = "03"
                        cboTipoDoc.Enabled = False
                    Case Else
                        PaneDoc2.Visible = False
                        PanelVisibleFac.Visible = False
                        cboTipoDoc.Enabled = True
                End Select
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtSelModulo.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PopupControlContainer2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles PopupControlContainer2.Paint

    End Sub

    Private Sub ButtonAdv6_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv6.Click
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub popupControlContainer1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles popupControlContainer1.Paint

    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs)
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cancel_Click(sender As System.Object, e As System.EventArgs)
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub ButtonAdv2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv2.Click
        PopupControlContainer2.Font = New Font("Tahoma", 8)
        PopupControlContainer2.Size = New Size(418, 110)
        Me.PopupControlContainer2.ParentControl = Me.txtSelModulo
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub chModulo_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles chModulo.CheckStateChanged
        Me.Cursor = Cursors.WaitCursor
        If chModulo.Checked = True Then
            Panel2.Visible = True
            DOckControls()
            dockingManager1.SetDockVisibility(PanelConfig, True)
        Else
            Panel2.Visible = False
            dockingManager1.SetDockVisibility(PanelConfig, False)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstEstablecimiento_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstEstablecimiento.MouseDoubleClick
        '    Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub tbAlmacen_ToggleStateChanged(sender As Object, e As Syncfusion.Windows.Forms.Tools.ToggleStateChangedEventArgs) Handles tbAlmacen.ToggleStateChanged
        If tbAlmacen.ToggleState = ToggleButtonState.Active Then
            txtAlmacen.Visible = True
            btnAlmacen.Visible = True
        ElseIf tbAlmacen.ToggleState = ToggleButtonState.Inactive Then
            txtAlmacen.Visible = False
            btnAlmacen.Visible = False
        End If
    End Sub

    Private Sub tbEF_ToggleStateChanged(sender As Object, e As Syncfusion.Windows.Forms.Tools.ToggleStateChangedEventArgs) Handles tbEF.ToggleStateChanged
        If tbEF.ToggleState = ToggleButtonState.Active Then
            txtCuentaFinanciera.Visible = True
            btnEF.Visible = True

        ElseIf tbEF.ToggleState = ToggleButtonState.Inactive Then
            txtCuentaFinanciera.Visible = False
            btnEF.Visible = False
            txtCuentaFinanciera.Clear()
            txtCuentaFinanciera.ValueMember = Nothing
            UpdateConfiguracionGeneric()
        End If
    End Sub

    Private Sub rbManual_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbManual.CheckChanged
        If rbManual.Checked = True Then
            Label6.Visible = False
            lstTipoDoc.Visible = False
            txtSerieConf.Visible = False
        End If
    End Sub

    Private Sub rbAuto_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbAuto.CheckChanged
        If rbAuto.Checked = True Then
            Label6.Visible = True
            lstTipoDoc.Visible = True
            txtSerieConf.Visible = True
            ListaPredeterminados(TipoModulo)
        End If
    End Sub

    'Private Sub PopupControlContainer3_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
    '    Dim moduloConSA As New ModuloConfiguracionSA
    '    If e.PopupCloseType = PopupCloseType.Done Then
    '        txtSerie.Text = txtSerieConf.Text
    '        txtComprobante.Text = lstTipoDoc.Text
    '        txtIdComprobante.Text = lstTipoDoc.SelectedValue
    '        txtConfig.Text = IIf(rbAuto.Checked = True, "Automático", "Manual")
    '        Select Case txtConfig.Text
    '            Case "Automático"

    '            Case "Manual"
    '                txtComprobante.Clear()
    '                txtSerie.Clear()
    '                txtNumImpresiones.Clear()
    '        End Select

    '        If moduloConSA.TieneConfiguracionComprobante(Gempresas.IdEmpresaRuc, txtSelModulo.ValueMember) = True Then
    '            'METODO EDITAR
    '            '   UpdateConfiguracion()
    '        Else
    '            'METODO GRABAR NUEVA CONFIGURACION
    '            '   GrabarConfiguracion()
    '        End If
    '    End If
    '    ' Set focus back to textbox.
    '    If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '        Me.txtSerie.Focus()
    '    End If
    'End Sub

    Private Sub btnConfigCaja_Click(sender As System.Object, e As System.EventArgs)
        'If txtSelModulo.Text.Trim.Length > 0 Then
        '    PopupControlContainer3.Font = New Font("Tahoma", 8)
        '    PopupControlContainer3.Width = 306
        '    PopupControlContainer3.Height = 212
        '    Me.PopupControlContainer3.ParentControl = btnConfigCaja
        '    Me.PopupControlContainer3.ShowPopup(Point.Empty)
        'End If
    End Sub

    Private Sub lstTipoDoc_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstTipoDoc.SelectedIndexChanged
        UbicarNumeracionPorID(lstTipoDoc.SelectedValue)
    End Sub

    Private Sub btnEF_Click(sender As System.Object, e As System.EventArgs) Handles btnEF.Click
        PopupControlContainer5.Font = New Font("Tahoma", 8)
        PopupControlContainer5.Width = 263
        PopupControlContainer5.Height = 191
        Me.PopupControlContainer5.ParentControl = Me.txtCuentaFinanciera
        Me.PopupControlContainer5.ShowPopup(Point.Empty)
    End Sub

    Private Sub PopupControlContainer5_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer5.BeforePopup
        Me.PopupControlContainer5.BackColor = Color.White
    End Sub
    Private Sub PopupControlContainer5_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles PopupControlContainer5.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCuentaFinanciera.SelectedItems.Count > 0 Then
                Me.txtCuentaFinanciera.ValueMember = lstCuentaFinanciera.SelectedValue
                txtCuentaFinanciera.Text = lstCuentaFinanciera.Text
                ' ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
                UpdateConfiguracionGeneric()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCuentaFinanciera.Focus()
        End If
    End Sub

    'Private Sub rbBanco_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbBanco.CheckChanged
    '    If rbBanco.Checked = True Then
    '        ObtenerEntidadesFinancieras(txtEstablecimiento.ValueMember, "BC", cboMoneda.SelectedValue)
    '    End If
    'End Sub

    'Private Sub rbEfectivo_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbEfectivo.CheckChanged
    '    If rbEfectivo.Checked = True Then
    '        ObtenerEntidadesFinancieras(txtEstablecimiento.ValueMember, "EF", cboMoneda.SelectedValue)
    '    End If
    'End Sub

    'Private Sub cboMoneda_Click(sender As System.Object, e As System.EventArgs) Handles cboMoneda.Click
    '    ObtenerEntidadesFinancieras(txtEstablecimiento.ValueMember, IIf(rbBanco.Checked = True, "BC", "EF"), cboMoneda.SelectedValue)
    'End Sub

    'Private Sub cboAnios_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboAnios.SelectedIndexChanged
    '    PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month)) & "/" & cboAnios.SelectedValue
    '    AnioGeneral = cboAnios.SelectedValue
    'End Sub

    'Private Sub txtMes_ValueChanged(sender As System.Object, e As System.EventArgs)
    '    PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month)) & "/" & cboAnios.SelectedValue
    '    MesGeneral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month))
    'End Sub

    'Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs)
    '    If Not txtNewEstable.Text.Trim.Length > 0 Then
    '        ' lblEstado.Text = "Ingrese el nombre de la clasificación"
    '        pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
    '        pcNuevoEstablecimiento.Size = New Size(318, 102)
    '        Me.pcNuevoEstablecimiento.ParentControl = Me.txtEstablecimiento
    '        Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
    '        txtNewEstable.Select()
    '        Exit Sub
    '    End If
    '    ButtonAdv1.Tag = "G"
    '    Me.pcNuevoEstablecimiento.HidePopup(PopupCloseType.Done)
    'End Sub

    'Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs)
    '    Me.pcNuevoEstablecimiento.HidePopup(PopupCloseType.Canceled)
    'End Sub

    'Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs)
    '    pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
    '    pcNuevoEstablecimiento.Size = New Size(322, 148)
    '    Me.pcNuevoEstablecimiento.ParentControl = Me.txtEstablecimiento
    '    Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
    '    txtNewEstable.Clear()
    '    txtNewEstable.Select()
    'End Sub

    'Private Sub pcNuevoEstablecimiento_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
    '    If e.PopupCloseType = PopupCloseType.Done Then
    '        If Not txtNewEstable.Text.Trim.Length > 0 Then
    '            '  lblEstado.Text = "Ingrese el nombre de la clasificación"
    '            pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
    '            pcNuevoEstablecimiento.Size = New Size(322, 148)
    '            Me.pcNuevoEstablecimiento.ParentControl = Me.txtEstablecimiento
    '            Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
    '            txtNewEstable.Select()
    '            Exit Sub
    '        End If


    '        If ButtonAdv1.Tag = "G" Then
    '            GrabarEstablecimiento()
    '            ButtonAdv1.Tag = "N"
    '        Else
    '            pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
    '            pcNuevoEstablecimiento.Size = New Size(322, 148)
    '            Me.pcNuevoEstablecimiento.ParentControl = Me.txtEstablecimiento
    '            Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
    '        End If

    '    End If
    '    ' Set focus back to textbox.
    '    If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '        Me.txtEstablecimiento.Focus()
    '    End If
    'End Sub

    'Private Sub pcNuevoEstablecimiento_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
    '    Me.pcNuevoEstablecimiento.BackColor = Color.FromArgb(227, 241, 254)
    'End Sub

    'Private Sub ButtonAdv11_Click(sender As System.Object, e As System.EventArgs)
    '    pcAño.Font = New Font("Tahoma", 8)
    '    pcAño.Size = New Size(141, 83)
    '    Me.pcAño.ParentControl = Me.cboAnios
    '    Me.pcAño.ShowPopup(Point.Empty)
    '    txtnewAnio.Select()

    '    ButtonAdv11.Tag = "G"
    '    Me.pcAño.HidePopup(PopupCloseType.Done)
    'End Sub

    'Private Sub pcAño_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
    '    If e.PopupCloseType = PopupCloseType.Done Then

    '        If ButtonAdv11.Tag = "G" Then
    '            GrabarAnio()
    '            ButtonAdv11.Tag = "N"
    '        Else
    '            pcAño.Font = New Font("Tahoma", 8)
    '            pcAño.Size = New Size(141, 83)
    '            Me.pcAño.ParentControl = Me.cboAnios
    '            Me.pcAño.ShowPopup(Point.Empty)
    '        End If

    '    End If
    '    ' Set focus back to textbox.
    '    If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '        Me.cboAnios.Focus()
    '    End If
    'End Sub

    'Private Sub pcAño_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
    '    Me.pcAño.BackColor = Color.FromArgb(227, 241, 254)
    'End Sub

    'Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs)
    '    pcAño.Font = New Font("Tahoma", 8)
    '    pcAño.Size = New Size(141, 83)
    '    Me.pcAño.ParentControl = Me.cboAnios
    '    Me.pcAño.ShowPopup(Point.Empty)
    '    txtnewAnio.Select()
    'End Sub

    Private Sub lstModulos_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstModulos.MouseDoubleClick
        Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub txtSerieNew_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieNew.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudValInicialNew.Focus()
        End If
    End Sub

    Private Sub txtSerieNew_LostFocus(sender As Object, e As EventArgs) Handles txtSerieNew.LostFocus
        If txtSerieNew.Text.Trim.Length > 0 Then
            txtSerieNew.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieNew.Text))
        End If

    End Sub

    Private Sub nudValInicialNew_KeyDown(sender As Object, e As KeyEventArgs) Handles nudValInicialNew.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudValIncrementoNew.Focus()
        End If
    End Sub

    Private Sub nudValInicialNew_ValueChanged(sender As Object, e As EventArgs) Handles nudValInicialNew.ValueChanged

    End Sub

    Private Sub lsvSeriesModulo_MouseClick(sender As Object, e As MouseEventArgs) Handles lsvSeriesModulo.MouseClick
        If lsvSeriesModulo.SelectedItems.Count > 0 Then
            If e.Button = MouseButtons.Right Then
                If lsvSeriesModulo.FocusedItem.Bounds.Contains(e.Location) = True Then
                    ContextMenuStrip1.Show(Cursor.Position)
                End If
            End If
        End If
    End Sub

    Private Sub lsvSeriesModulo_MouseUp(sender As Object, e As MouseEventArgs) Handles lsvSeriesModulo.MouseUp

    End Sub

    Private Sub InciarEnAutomáticoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InciarEnAutomáticoToolStripMenuItem.Click
        Dim moduloConSA As New ModuloConfiguracionSA
        Me.Cursor = Cursors.WaitCursor
        If moduloConSA.TieneConfiguracionComprobante(Gempresas.IdEmpresaRuc, txtSelModulo.ValueMember) = True Then
            'METODO EDITAR
            UpdateConfiguracion(lsvSeriesModulo.SelectedItems(0).SubItems(0).Text, "P")
        Else
            'METODO GRABAR NUEVA CONFIGURACION
            GrabarConfiguracion(lsvSeriesModulo.SelectedItems(0).SubItems(0).Text, "P")
        End If
        '   configuracionModulo(Gempresas.IdEmpresaRuc, txtSelModulo.ValueMember, txtSelModulo.Text)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub IniciarEnManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IniciarEnManualToolStripMenuItem.Click
        Dim moduloConSA As New ModuloConfiguracionSA
        Me.Cursor = Cursors.WaitCursor
        If moduloConSA.TieneConfiguracionComprobante(Gempresas.IdEmpresaRuc, txtSelModulo.ValueMember) = True Then
            UpdateConfiguracion(Nothing, "M")
        Else
            GrabarConfiguracion(Nothing, "M")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub ButtonAdv12_Click(sender As Object, e As EventArgs)
    '    PopupControlContainer3.Font = New Font("Tahoma", 8)
    '    PopupControlContainer3.Size = New Size(344, 130)
    '    Me.PopupControlContainer3.ParentControl = Me.txtAlmacenTrab
    '    Me.PopupControlContainer3.ShowPopup(Point.Empty)
    'End Sub

    'Private Sub PopupControlContainer3_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    Me.PopupControlContainer3.BackColor = Color.FromArgb(227, 241, 254)
    'End Sub

    'Private Sub PopupControlContainer3_CloseUp_1(sender As Object, e As PopupClosedEventArgs)
    '    If e.PopupCloseType = PopupCloseType.Done Then
    '        If lstAlmacen.SelectedItems.Count > 0 Then
    '            Me.txtAlmacenTrab.ValueMember = lstAlmacen.SelectedValue
    '            txtAlmacenTrab.Text = lstAlmacen.Text
    '            TmpIdAlmacen = lstAlmacen.SelectedValue
    '            TmpNombreAlmacen = lstAlmacen.Text

    '            For Each item In almacen
    '                If (txtAlmacenTrab.ValueMember = item.idAlmacen) Then
    '                    '    nudPorGanancia.Value = item.porcentajeUtilidad
    '                    '   TmpPorcGanacia = nudPorGanancia.Value
    '                End If
    '            Next
    '        End If
    '    End If
    '    ' Set focus back to textbox.
    '    If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '        Me.txtAlmacen.Focus()
    '    End If
    'End Sub

    'Private Sub txtAlmacenTrab_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Down Then
    '        If Not Me.PopupControlContainer3.IsShowing() Then
    '            ' Let the popup align around the source textBox.
    '            PopupControlContainer3.Font = New Font("Segoe UI", 8)
    '            PopupControlContainer3.Size = New Size(260, 110)
    '            Me.PopupControlContainer3.ParentControl = Me.txtAlmacen
    '            Me.PopupControlContainer3.ShowPopup(Point.Empty)
    '            e.Handled = True
    '        End If
    '    End If
    '    '  End If
    '    ' Escape should close the popup.
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.PopupControlContainer3.IsShowing() Then
    '            Me.PopupControlContainer3.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    'End Sub

    'Private Sub lstAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs)
    '    Me.PopupControlContainer3.HidePopup(PopupCloseType.Done)
    'End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        'With frmNuevoAlmacen
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        '    .txtEstablecimiento.Tag = GEstableciento.IdEstablecimiento
        '    .txtEmpresa.Text = Gempresas.NomEmpresa
        '    .txtEmpresa.Tag = Gempresas.IdEmpresaRuc
        '    '.WindowState = FormWindowState.Maximized
        '    .ShowDialog()
        'End With
        'With frmConfigPrecioVenta

        'End With
    End Sub

    'Private Sub nudTipoCambio_KeyDown(sender As Object, e As KeyEventArgs)
    '    Try
    '        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
    '            e.SuppressKeyPress = True
    '            TmpTipoCambio = nudTipoCambio.Value
    '        End If
    '    Catch ex As Exception
    '    End Try

    'End Sub

    Private Sub cboIVA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIVA.SelectedIndexChanged
        Try
            Select Case cboIVA.Text
                Case "VALORES CON IVA"
                    TmpTipoIVA = "SIVA"
                Case "VALORES SIN IVA"
                    TmpTipoIVA = "NIVA"
            End Select
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub nupIGV_KeyDown(sender As Object, e As KeyEventArgs)
    '    Try
    '        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
    '            e.SuppressKeyPress = True
    '            TmpIGV = nupIGV.Value
    '            nudTipoCambio.Select()
    '            nudTipoCambio.Focus()
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Private Sub ButtonAdv13_Click(sender As Object, e As EventArgs)
    '    PopupControlContainer4.Font = New Font("Tahoma", 8)
    '    PopupControlContainer4.Size = New Size(300, 200)
    '    Me.PopupControlContainer4.ParentControl = ButtonAdv13
    '    Me.PopupControlContainer4.ShowPopup(Point.Empty)
    '    txtbuscarItems.Select()
    '    txtbuscarItems.Focus()
    '    UbicarExistencias()
    'End Sub

    'Private Sub txtItems_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Down Then
    '        If Not Me.PopupControlContainer3.IsShowing() Then
    '            ' Let the popup align around the source textBox.
    '            PopupControlContainer4.Font = New Font("Segoe UI", 8)
    '            PopupControlContainer4.Size = New Size(300, 200)
    '            Me.PopupControlContainer4.ParentControl = ButtonAdv13
    '            Me.PopupControlContainer4.ShowPopup(Point.Empty)
    '            e.Handled = True
    '        End If
    '    End If
    '    '  End If
    '    ' Escape should close the popup.
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.PopupControlContainer4.IsShowing() Then
    '            Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    'End Sub

    Private Sub PopupControlContainer4_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer4.BeforePopup
        Me.PopupControlContainer4.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            'If dgvItems.SelectedRows.Count > 0 Then
            updateUtilidadExistencias()
            'End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.PopupControlContainer4.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub dgvItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellEndEdit
        If (dgvItems.Item(2, dgvItems.CurrentRow.Index).Value >= 0) Then
            dgvItems.Item(3, dgvItems.CurrentRow.Index).Value = 1
        End If
    End Sub

    Private Sub updateUtilidadExistencias()
        Dim listaUtilidad As New List(Of item)
        Dim itemSA As New itemSA
        Dim item As New item
        For Each i As DataGridViewRow In dgvItems.Rows
            If i.Cells(3).Value = 1 Then
                item = New item
                With item
                    .idItem = i.Cells(0).Value
                    .utilidad = CDec(i.Cells(2).Value)
                End With
                listaUtilidad.Add(item)
            End If
        Next
        If Not IsNothing(listaUtilidad) Then
            itemSA.UpdateCategoriaFull(listaUtilidad)
        End If
    End Sub

    'Private Sub PictureBox4_Click(sender As Object, e As EventArgs)
    '    PopupControlContainer4.Font = New Font("Tahoma", 8)
    '    PopupControlContainer4.Size = New Size(300, 200)
    '    Me.PopupControlContainer4.ParentControl = ButtonAdv13
    '    Me.PopupControlContainer4.ShowPopup(Point.Empty)
    '    dgvItems.Rows.Clear()
    '    dgvItems.AllowUserToAddRows = True
    'End Sub

    Private Sub UbicarExistencias()
        Dim objLista As New List(Of item)
        Dim itemSA As New itemSA

        txtbuscarItems.Clear()
        Dim dt As New DataTable("Existencias " & "ID")

        dt.Columns.Add(New DataColumn("ID", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Utilidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Estado", GetType(Integer)))

        objLista = itemSA.GetListaItemPorEmpresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        For Each i As item In objLista

            Dim dr As DataRow = dt.NewRow()
            dr(0) = CInt(i.idItem)
            dr(1) = i.descripcion
            dr(2) = i.utilidad
            dr(3) = CInt(0)

            dt.Rows.Add(dr)
        Next

        dgvItems.DataSource = dt
        dtTableGrd = dt
        dgvItems.Columns(0).Visible = False
        dgvItems.Columns(1).Width = 200
        dgvItems.Columns(1).DefaultCellStyle.ForeColor = SystemColors.HotTrack
        dgvItems.Columns(1).ReadOnly = True
        dgvItems.Columns(2).Width = 70
        dgvItems.Columns(3).Visible = False
    End Sub

    Private Sub txtbuscarItems_TextChanged(sender As Object, e As EventArgs) Handles txtbuscarItems.TextChanged
        dtTableGrd.DefaultView.RowFilter = "Descripcion Like '%" & txtbuscarItems.Text & "%'"
    End Sub


    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtSelModulo.Text.Trim.Length > 0 Then
                MsgBox("Ingrese un modulo a configurar!", MsgBoxStyle.Information, "Atención!")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If Not txtSerieNew.Text.Trim.Length > 0 Then
                MsgBox("Ingrese una serie válida!", MsgBoxStyle.Information, "Atención!")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            GrabarSerieModulo()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Atención")
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSerieNew_TextChanged(sender As Object, e As EventArgs) Handles txtSerieNew.TextChanged

    End Sub

    Private Sub txtSerieFac_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieFac.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudValInicial2.Focus()
        End If
    End Sub

    Private Sub txtSerieFac_LostFocus(sender As Object, e As EventArgs) Handles txtSerieFac.LostFocus
        If txtSerieFac.Text.Trim.Length > 0 Then
            txtSerieFac.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieFac.Text))
        End If
    End Sub

    Private Sub txtSerieFac_TextChanged(sender As Object, e As EventArgs) Handles txtSerieFac.TextChanged

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click

    End Sub
End Class