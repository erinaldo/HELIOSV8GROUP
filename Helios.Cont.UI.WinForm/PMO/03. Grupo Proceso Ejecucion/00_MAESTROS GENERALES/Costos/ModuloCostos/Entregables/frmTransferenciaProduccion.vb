Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmTransferenciaProduccion
    Inherits frmMaster

#Region "Attributes"
    Dim empresaPeriodoSA As New empresaCierreMensualSA
    Dim srtNomAlmacen As String = Nothing
    Dim strUM As String = Nothing
    Dim strTipoEx As String = Nothing
    Dim strCuenta As String = Nothing
    Dim intIdEstableAlm As Integer
    Dim strIdPresentacion As String = Nothing
    Dim selAlmacenPC As String
    Dim tipoEstado As String
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property ListaMovimientos As New List(Of movimiento)
    Public Property ListadoDestinatarios As New List(Of entidad)
    Public Property ManipulacionEstado() As String
    Private cantidaExistente As New List(Of Integer)
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Dim colorx As New GridMetroColors()
    Dim almacenDestino As New List(Of almacen)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Add any initialization after the InitializeComponent() call.
        GetTableGrid()
        Docking()

        'INICIO PERIODO
        txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFechaComprobante.Select()

        txtfechaTraslado.Value = txtFechaComprobante.Value
        txtfehcaEmision.Value = txtFechaComprobante.Value

        lblEmpresa.Text = Gempresas.NomEmpresa
        lblEstablecimiento.Text = GEstableciento.NombreEstablecimiento

        'dockingManager1.CloseEnabled = False
        CargarListas()
        dgvCompra.DataSource = GetTableGrid2()
        GridCFG(dgvCompra)
        txtTipoCambio.Value = TmpTipoCambio
        GridCFG(dgvTransferencia)
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "TEA", Me.Text, GEstableciento.IdEstablecimiento)
        'cboEstablecimiento.SelectedIndex = -1

    End Sub

    Public Sub New(idDocumento As Integer)
        ' This call is required by the designer.
        ' This call is required by the designer.
        InitializeComponent()
        'Dim almacenSA As New almacenSA
        'almacenDestino = almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)

        GetTableGrid()

        lblEmpresa.Text = Gempresas.NomEmpresa
        lblEstablecimiento.Text = GEstableciento.NombreEstablecimiento

        'INICIO PERIODO
        '  lblPerido.Text = PeriodoGeneral

        CargarListas()
        'dgvCompra.DataSource = GetTableGrid2()
        'GridCFG(dgvCompra)
        txtTipoCambio.Value = TmpTipoCambio
        GridCFG(dgvTransferencia)

        UbicarDocumento(idDocumento)

        GradientPanel3.Enabled = False
        GradientPanel8.Enabled = False
        GradientPanel4.Enabled = False
        ToolStripButton4.Visible = False
        btGrabar.Visible = False

    End Sub
#End Region

#Region "Methods"

#Region "Asientos"

    Sub RegistrarMovimiento(nAsiento As asiento)

        Dim cuentaSA As New cuentaplanContableEmpresaSA

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipos", GetType(String))
        dt.Columns.Add("cant", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("descripcion", GetType(String))

        Dim cosnulta = (From i In ListaMovimientos _
                       Where i.idAsiento = nAsiento.idAsiento).ToList

        '   For x As Integer = 0 To cosnulta.Count - 1

        'dt.Rows.Add(dt.NewRow())
        'dt.Rows(x)(0) = CInt(cosnulta(x).idmovimiento)
        'If Not IsNothing(cosnulta(x).cuenta) Then
        '    dt.Rows(x)(1) = cosnulta(x).nombreEntidad
        'Else
        '    dt.Rows(x)(1) = String.Empty
        'End If
        'dt.Rows(x)(2) = cosnulta(x).cuenta
        'dt.Rows(x)(3) = cosnulta(x).tipo
        'dt.Rows(x)(4) = cosnulta(x).Cant
        'dt.Rows(x)(5) = cosnulta(x).PUmn
        'dt.Rows(x)(6) = cosnulta(x).monto
        'dt.Rows(x)(7) = cosnulta(x).PUme
        'dt.Rows(x)(8) = cosnulta(x).montoUSD
        'dt.Rows(x)(9) = cosnulta(x).descripcion
        For Each x In cosnulta
            Dim dr As DataRow = dt.NewRow
            dr(0) = x.idmovimiento
            If Not IsNothing(x.cuenta) Then
                dr(1) = x.nombreEntidad
            Else
                dr(1) = String.Empty
            End If
            dr(2) = x.cuenta
            dr(3) = x.tipo
            dr(4) = x.Cant
            dr(5) = x.PUmn
            dr(6) = x.monto
            dr(7) = x.PUme
            dr(8) = x.montoUSD
            dr(9) = x.descripcion
            dt.Rows.Add(dr)
        Next

        dgvCompra.DataSource = dt
    End Sub

    Sub UbicarAsientoPorId(asiento As asiento)
        Dim consulta = (From n In ListaAsientonTransito _
                Where n.idAsiento = asiento.idAsiento).FirstOrDefault

        If Not IsNothing(consulta) Then
            txtGlosaAsiento.Text = consulta.glosa
        End If
    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Function GetTableGrid2() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("cant", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("descripcion", GetType(String))

        Return dt
    End Function

    Sub updateMovimiento(r As Record)
        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

        Try
            Dim consulta = (From n In ListaMovimientos _
                       Where n.idmovimiento = r.GetValue("id")).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.cuenta = r.GetValue("cuenta")
                Dim md = r.GetValue("Modulo").ToString
                If md.Trim.Length > 0 Then
                    consulta.nombreEntidad = r.GetValue("Modulo")
                Else
                    consulta.nombreEntidad = String.Empty
                End If

                Dim des = r.GetValue("descripcion").ToString
                If des.Trim.Length > 0 Then
                    consulta.descripcion = r.GetValue("descripcion")
                Else
                    consulta.descripcion = String.Empty
                End If
                consulta.tipo = r.GetValue("tipoAsiento")
                consulta.Cant = r.GetValue("cant")
                consulta.PUmn = r.GetValue("pumn")
                consulta.PUme = r.GetValue("pume")
                consulta.monto = r.GetValue("importeMN")
                consulta.montoUSD = r.GetValue("importeME")
            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub

    Function GetMaxIDMovimiento() As Integer
        If ListaMovimientos.Count > 0 Then
            Return ListaMovimientos.Max(Function(o) o.idmovimiento)
        Else
            Return 0
        End If
    End Function

    Sub RegsitarMovimiento(nAsiento As asiento)
        Dim n As New movimiento
        n.cuenta = "10"
        n.idAsiento = nAsiento.idAsiento
        n.idmovimiento = GetMaxIDMovimiento() + 1
        n.tipo = "D"
        n.Cant = 1
        n.PUmn = 0
        n.PUme = 0
        n.monto = 0
        n.montoUSD = 0
        ListaMovimientos.Add(n)
    End Sub

    Sub RegistrarAsientos()
        Dim nAsiento As New asiento

        If ListaAsientonTransito.Count > 0 Then
            nAsiento.idAsiento = ListaAsientonTransito.Count + 1
        Else
            nAsiento.idAsiento = 1
        End If
        nAsiento.Descripcion = "Asiento Nro. " & ListaAsientonTransito.Count + 1
        ListaAsientonTransito.Add(nAsiento)

        GetasientosListbox()
    End Sub

    Sub GetasientosListbox()
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")

        For Each i In ListaAsientonTransito
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAsiento
            dr(1) = i.Descripcion
            dt.Rows.Add(dr)
        Next

        lstAsiento.DisplayMember = "nombre"
        lstAsiento.ValueMember = "id"
        lstAsiento.DataSource = dt
    End Sub
#End Region

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

            Dim n As New ListViewItem(codx)
            n.SubItems.Add(objCliente.nombreCompleto)
            n.SubItems.Add(objCliente.cuentaAsiento)
            n.SubItems.Add(objCliente.nrodoc)
            lsvProveedor.Items.Add(n)

            txtProveedor.Tag = codx
            txtProveedor.Text = objCliente.nombreCompleto
            txtRuc.Text = objCliente.nrodoc
            txtCuenta = objCliente.cuentaAsiento
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "PERSONA"
    Public Class Personal

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

    Public Sub GrabarPersona()
        Dim personaSA As New PersonaSA
        Dim personaBE As New Persona

        With personaBE
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idPersona = txtDniTrab.Text.Trim
            .nombres = txtNombreTrab.Text.Trim
            .appat = txtAppatTrab.Text.Trim
            .apmat = txtApmatTrab.Text.Trim
            .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
        End With
        personaSA.InsertPersona(personaBE)
        txtProveedor.Tag = personaBE.idPersona
        txtProveedor.Text = personaBE.nombreCompleto
        txtRuc.Text = personaBE.idPersona
        txtCuenta = "TR"

        lstPersonas.Items.Add(New Personal(personaBE.nombreCompleto, personaBE.idPersona))
    End Sub

    Private Sub ObtenerPersonaPorNombre(strPersona As String)
        Dim PersonaSA As New PersonaSA
        lstPersonas.Items.Clear()
        For Each i In PersonaSA.ObtenerPersonaPorNombres(Gempresas.IdEmpresaRuc, strPersona)
            lstPersonas.Items.Add(New Personal(i.nombreCompleto, i.idPersona))
        Next
        lstPersonas.DisplayMember = "Name"
        lstPersonas.ValueMember = "Id"
    End Sub
#End Region

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
    '                        GConfiguracion.NombreComprobante = "" 'TablaSA.GetUbicarTablaID(10, .tipo).descripcion
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
    '            '    If Not IsNothing(.configAlmacen) Then
    '            'Dim estableSA As New establecimientoSA
    '            'With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '            '    GConfiguracion.IdAlmacen = .idAlmacen
    '            '    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '            '    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '            '    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '            '    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '            '        'txtIdEstableAlmacen.Text = .idCentroCosto
    '            '        'txtEstableAlmacen.Text = .nombre
    '            '    End With
    '            'End With
    '            '    End If
    '            'If Not IsNothing(.ConfigentidadFinanciera) Then
    '            '    With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '            '        GConfiguracion.IDCaja = .idestado
    '            '        GConfiguracion.NomCaja = .descripcion
    '            '    End With
    '            'End If

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
                GConfiguracion.NombreComprobante = "" ' TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Docking()

        ' Me.dockingManager1.DockControl(Me.PanelMontos, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 152)

        'Me.dockingManager1.DockControl(Me.PanelCanasta, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)
        'dockingManager1.DockControlInAutoHideMode(PanelCanasta, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        Me.dockingManager1.DockControl(Me.Panel2, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)
        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        dockingManager1.SetDockLabel(Panel2, "Canasta existencias")

        '    dockingManager1.SetDockLabel(PanelMontos, "Importes del Comprobante")
        dockingManager1.CloseEnabled = False
    End Sub

    Public Sub UbicarDocumento(IdDocumento As Integer)
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim ObjCompraDetalleSA As New DocumentoCompraDetalleSA
        Dim listaDocumentoCompra As New List(Of documentocompradetalle)
        Dim almacenSA As New almacenSA
        Dim objAlmacen As New almacen
        Dim ObjGuiaDetalleSA As New DocumentoGuiaSA
        Dim ObjGuiaDetalle As New List(Of documentoGuia)
        Dim PersonaSA As New Helios.Planilla.WCFService.ServiceAccess.PersonalSA
        listaDocumentoCompra = ObjCompraDetalleSA.GetUbicar_PorDocumento(IdDocumento)
        ObjGuiaDetalle = ObjGuiaDetalleSA.ListaGuiasPorCompra(IdDocumento)

        cboAlmacen.SelectedValue = listaDocumentoCompra(0).almacenRef

        txtFechaComprobante.Value = listaDocumentoCompra(0).FechaDoc

        txtfechaTraslado.Value = ObjGuiaDetalle(0).fechaTraslado
        txtfehcaEmision.Value = ObjGuiaDetalle(0).fechaDoc

        If ((listaDocumentoCompra(0).almacenDestino) <> 0) Then
            objAlmacen = almacenSA.GetUbicar_almacenPorID(listaDocumentoCompra(0).almacenDestino)
            cboEstablecimiento.SelectedValue = objAlmacen.idEstablecimiento

            cboalmacenDestino.SelectedValue = listaDocumentoCompra(0).almacenDestino
        End If



        'If Not IsNothing(.idProveedor) Then
        '    chProv.Checked = True
        '    chTrab.Checked = False

        '    'PROVEEDOR
        '    nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
        '    txtRuc.Text = nEntidad.nrodoc
        '    txtCuenta = nEntidad.cuentaAsiento
        '    txtProveedor.Tag = nEntidad.idEntidad
        '    txtProveedor.Text = nEntidad.nombreCompleto

        'Else
        '    Dim codPerson = .idPersona
        '    chTrab.Checked = True
        '    chProv.Checked = False
        '    Dim Persona = PersonaSA.PersonalSelxID(New Planilla.Business.Entity.Personal With {.IDPersonal = codPerson})
        '    If Not IsNothing(Persona) Then
        '        txtRuc.Text = Persona.Numerodocumento
        '        txtCuenta = "TR"
        '        txtProveedor.Tag = Persona.IDPersonal
        '        txtProveedor.Text = Persona.FullName
        '    End If
        'End If
        'If ((ObjGuiaDetalle(0).idEntidad) <> 0) Then
        '    nEntidad = objEntidad.UbicarEntidadPorID(ObjGuiaDetalle(0).idEntidad).First()
        '    txtRuc.Text = nEntidad.nrodoc
        '    txtProveedor.Tag = nEntidad.idEntidad
        '    txtProveedor.Text = nEntidad.nombreCompleto
        'End If

        If ((ObjGuiaDetalle(0).idEntidadTransporte) <> 0) Then
            nEntidad = objEntidad.UbicarEntidadPorID(ObjGuiaDetalle(0).idEntidadTransporte).First()
            txtRuc2.Text = nEntidad.nrodoc
            txtCliente2.Tag = nEntidad.idEntidad
            txtCliente2.Text = nEntidad.nombreCompleto
        End If

        For Each i In listaDocumentoCompra

            Me.dgvTransferencia.Table.AddNewRecord.SetCurrent()
            Me.dgvTransferencia.Table.AddNewRecord.BeginEdit()
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Secuencia", i.secuencia)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Gravado", i.destino)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("IDArticulo", i.idItem)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Art", i.descripcionItem)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("uni2", i.unidad2)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Cant2", i.monto2)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Uni1", i.unidad1)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Can1", i.monto1)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Prec", i.precioUnitario)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("PrecUnitUS", i.precioUnitarioUS)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("ImporteNeto", i.importe)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("ImporteUS", i.importeUS)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Estado", "U")
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("TipoExistencia", i.tipoExistencia)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Cuenta", i.CuentaItem)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("cbopreEvento", 0)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("Evento", 0)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("colAlmacenRef", i.almacenDestino)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("colSelAlmacen", 0)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("colAlmacenRef", Nothing)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("coliDestableAlmacen", 0)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("colAlmacenBAck", Nothing)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("colIdAlmacenOrigen", i.almacenRef)
            Me.dgvTransferencia.Table.CurrentRecord.SetValue("colDisponible", i.monto1)
            Me.dgvTransferencia.Table.AddNewRecord.EndEdit()

        Next

        txtSerie.Text = ObjGuiaDetalle(0).serie
        txtNumero.Text = ObjGuiaDetalle(0).numeroDoc
        txtfechaTraslado.Value = ObjGuiaDetalle(0).fechaTraslado
        txtfehcaEmision.Value = ObjGuiaDetalle(0).fechaDoc

        TotalesCabeceras()
        GradientPanel4.Visible = False
    End Sub

    Private Sub cargarDatosCuenta(idEstable As Integer)

        dgvTransferencia.Table.Records.DeleteAll()
        lsvExistencias.Items.Clear()

        Dim almacenSA As New almacenSA
        Dim codAlmacen As Integer = cboAlmacen.SelectedValue

        If Not IsNothing(cboAlmacen.SelectedValue) Then
            If IsNumeric(codAlmacen) Then


                almacenDestino = almacenSA.GetListar_almacenesTipo(idEstable, "AP")

                Dim con = (From n In almacenDestino _
                          Where n.idAlmacen <> codAlmacen).ToList

                cboalmacenDestino.ValueMember = "idAlmacen"
                cboalmacenDestino.DisplayMember = "descripcionAlmacen"
                cboalmacenDestino.DataSource = con
                cboalmacenDestino.SelectedIndex = -1
            End If
        Else
            lblEstado.Text = "seleccione un establecimiento!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("Secuencia", GetType(String)) '0
        dt.Columns.Add("Gravado", GetType(String))
        dt.Columns.Add("IDArticulo", GetType(String))
        dt.Columns.Add("Art", GetType(String))
        dt.Columns.Add("uni2", GetType(String))
        dt.Columns.Add("Cant2", GetType(String)) '5
        dt.Columns.Add("Uni1", GetType(String))
        dt.Columns.Add("Can1", GetType(String)) '7
        dt.Columns.Add("Prec", GetType(String))
        dt.Columns.Add("PrecUnitUS", GetType(String))
        dt.Columns.Add("ImporteNeto", GetType(String)) '10
        dt.Columns.Add("ImporteUS", GetType(String))
        dt.Columns.Add("Estado", GetType(String))
        dt.Columns.Add("TipoExistencia", GetType(String)) '13
        dt.Columns.Add("Cuenta", GetType(String))
        dt.Columns.Add("cbopreEvento", GetType(String))
        dt.Columns.Add("Evento", GetType(String))
        dt.Columns.Add("colAlmacenRef", GetType(String))
        dt.Columns.Add("colSelAlmacen", GetType(String))
        dt.Columns.Add("coliDestableAlmacen", GetType(String))
        dt.Columns.Add("colAlmacenBAck", GetType(String)) '20
        dt.Columns.Add("colIdAlmacenOrigen", GetType(String))
        dt.Columns.Add("colDisponible", GetType(String))
        dt.Columns.Add("nrolote", GetType(String))
        dgvTransferencia.DataSource = dt
        'dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50

    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION

        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "13"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value
            .periodo = lblPerido.Text
            .tipoDoc = "09"
            .idEntidad = CInt(txtProveedor.Tag)
            .monedaDoc = "1" 'IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtMontoIGVmn.Text
            .tipoCambio = TmpTipoCambio
            .importeMN = CDec(txtTotalmn.Text)
            .importeME = CDec(txtTotalme.Text)
            .glosa = txtGlosa.Text.Trim
            .estado = tipoEstado
            .idEntidadTransporte = CInt(txtCliente2.Tag)
            .direccionPartida = "ORIGEN"
            .fechaTraslado = Date.Now
            .estado = TipoGuia.Pendiente
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now

            If (cboTipoDoc.Text = "VOUCHER CONTABLE") Then
                .numeroDoc = GConfiguracion.Serie
                .serie = GConfiguracion.Serie
                .estadoGuia = "PN"
            ElseIf (cboTipoDoc.Text = "GUIA DE REMISION") Then
                .numeroDoc = txtNumero.Text
                .serie = txtSerie.Text
                .estadoGuia = "DC"
            End If

        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As Record In dgvTransferencia.Table.Records
            If r.GetValue("tipoExistencia") <> "GS" Then
                '     If r.GetValue("almacen") <> idAlmacenVirtual Then
                documentoguiaDetalle = New documentoguiaDetalle
                'If txtSerie.Text.Trim.Length > 0 Then
                '    objDocumentoCompra.documentoGuia.serie = txtSerie.Text
                'Else
                '    Throw New Exception("Ingrese número de serie de la guía!")
                'End If
                'If txtSerie.Text.Trim.Length > 0 Then
                '    objDocumentoCompra.documentoGuia.numeroDoc = txtSerie.Text
                'Else
                '    Throw New Exception("Ingrese el nùmero de la guía!")
                'End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.GetValue("IDArticulo")
                documentoguiaDetalle.descripcionItem = r.GetValue("Art")
                documentoguiaDetalle.destino = r.GetValue("Gravado")
                documentoguiaDetalle.unidadMedida = r.GetValue("Uni1")
                documentoguiaDetalle.cantidad = CDec(r.GetValue("Can1"))
                documentoguiaDetalle.tipoExistencia = r.GetValue("TipoExistencia")
                documentoguiaDetalle.precioUnitario = CDec(r.GetValue("Prec"))
                documentoguiaDetalle.precioUnitarioUS = CDec(r.GetValue("PrecUnitUS"))
                documentoguiaDetalle.importeMN = CDec(r.GetValue("ImporteNeto"))
                documentoguiaDetalle.importeME = CDec(r.GetValue("ImporteUS"))

                documentoguiaDetalle.almacenRef = cboalmacenDestino.SelectedValue
                documentoguiaDetalle.nombreRecepcion = txtProveedor.Text
                documentoguiaDetalle.dniRecepcion = txtRuc.Text
                documentoguiaDetalle.puntoLlegada = "ORIGEN"
                documentoguiaDetalle.estado = TipoGuiaDetalle.Pendiente
                documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub



    Public Sub ListaMercaderiasXIdHijo(intIdAlmacen As Integer, strtipoEx As String, idItem As Integer)
        Dim tablaSA As New tablaDetalleSA
        Dim totalSA As New TotalesAlmacenSA
        Try
            lsvExistencias.Items.Clear()
            For Each i As totalesAlmacen In totalSA.GetProductoPorAlmacenItem(intIdAlmacen, strtipoEx, idItem)
                If i.cantidad > 0 Then
                    Dim n As New ListViewItem(i.idEstablecimiento)
                    n.SubItems.Add(i.origenRecaudo)
                    n.SubItems.Add(i.idItem)
                    n.SubItems.Add(i.descripcion)
                    n.SubItems.Add(i.unidadMedida)
                    n.SubItems.Add(tablaSA.GetUbicarTablaID(21, i.Presentacion).descripcion)
                    n.SubItems.Add(FormatNumber(i.cantidad, 2))
                    n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                    n.SubItems.Add(FormatNumber(i.importeDolares, 2))
                    If CDec(i.cantidad) > 0 Then
                        n.SubItems.Add(Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2).ToString("N2"))
                    Else
                        n.SubItems.Add(0)
                    End If

                    If CDec(i.cantidad) > 0 Then
                        n.SubItems.Add(Math.Round(CDec(i.importeDolares) / CDec(i.cantidad), 2).ToString("N2"))
                    Else
                        n.SubItems.Add(0)
                    End If
                    lsvExistencias.Items.Add(n)
                End If

            Next
            For Each item As ListViewItem In lsvExistencias.Items
                Dim i As Short
                If i Mod 2 = 0 Then
                    item.BackColor = Color.Transparent
                    item.ForeColor = Color.Gray
                Else
                    item.BackColor = Color.WhiteSmoke
                    item.ForeColor = Color.Gray
                End If
                i = i + 1
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub


    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        '   Dim personaSA As New PersonaSA
        Dim personalSA As New Helios.Planilla.WCFService.ServiceAccess.PersonalSA

        Try
            lsvProveedor.Items.Clear()
            For Each i In personalSA.PersonalSelStartwithNombres(New Helios.Planilla.Business.Entity.Personal With {.Nombre = strBusqueda})
                Dim n As New ListViewItem(i.IDPersonal)
                n.SubItems.Add(i.FullName)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.IDPersonal)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarEntidadesXtipoTransporte(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            ListBox2.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                ListBox2.Items.Add(n)
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
                txtProveedor.Tag = .idEntidad
                txtCuenta = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtProveedor.Clear()
            txtProveedor.Clear()

            txtRuc.Clear()
        End If
    End Sub

    Public Sub UbicarTrabPorDNI(strNumero As String)
        Dim personaSA As New PersonaSA
        Dim persona As New Persona

        persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, strNumero)
        If Not IsNothing(persona) Then
            With persona
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idPersona
                txtCuenta = "TR"
                txtRuc.Text = .idPersona
            End With
        End If
    End Sub

#Region "Clases Asientos"

    Private Shared datos As List(Of Asientos_MN)
    Private Shared datosMov As List(Of Movimientos)
    ' Asiento contable Class.
    Private Class Asientos_MN
        Public Property AsientoID As Integer
        Public Property NombreAsiento As String
        Public Property Tipo As String
        'Public Property Country As String

        Public Shared Function GetAsientos() As List(Of Asientos_MN)

            If datos Is Nothing Then
                datos = New List(Of Asientos_MN)
            End If

            Return datos
        End Function



        Private Sub AddAsiento(objAsiento As Asientos_MN)
            datos.Add(objAsiento)
        End Sub



    End Class
    Public Class Movimientos

        Public Property IdMovimiento As Integer
        Public Property AsientoID As Integer
        Public Property Cuenta As String
        Public Property Descripcion As String
        Public Property Tipo As String
        Public Property Importemn As Decimal
        Public Property Importeme As Decimal


        Public Shared Function GetMovimientos() As List(Of Movimientos)

            If datosMov Is Nothing Then
                datosMov = New List(Of Movimientos)
            End If

            Return datosMov
        End Function

        Public Sub AddMovimiento(nMovimiento As Movimientos)
            datosMov.Add(nMovimiento)
        End Sub
    End Class
    ' Detalle movimientos del asiento Class.


    Private Sub DeletePorID(id As Integer)

        Dim queryResults = (From cust In datos _
                           Where cust.AsientoID = id).First
        datos.Remove(queryResults)

        Dim ListaMov = (From n In datosMov _
                  Where n.AsientoID = id).ToList

        For Each i In ListaMov
            datosMov.Remove(i)
        Next

        'lstAsientos.DataSource = Nothing
        'lstAsientos.DisplayMember = "NombreAsiento"
        'lstAsientos.ValueMember = "AsientoID"
        'lstAsientos.DataSource = datos

        'If Not datosMov.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        'End If

    End Sub

    Private Sub DeleteMovimientoID(id As Integer)

        Dim queryResults = (From cust In datosMov _
                           Where cust.IdMovimiento = id).First
        datosMov.Remove(queryResults)

        'If Not datosMov.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        'End If

    End Sub

    Private Sub ubicarMovimientoporID(id As Integer)

        Dim queryResults = (From cust In datosMov _
                           Where cust.AsientoID = id).ToList

        'If queryResults.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        '    For Each I As Movimientos In queryResults
        '        If I.Tipo = "D" Then
        '            dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, I.Importemn, I.Importeme, "0.00", "0.00", I.IdMovimiento)
        '        ElseIf I.Tipo = "H" Then
        '            dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, "0.00", "0.00", I.Importemn, I.Importeme, I.IdMovimiento)
        '        End If

        '    Next
        '    lblEstado.Text = "Listado de movimientos"
        'Else
        '    dgvMovimiento.Rows.Clear()
        'End If


    End Sub


    Private Function ListarMovimientoporAsiento(id As Integer) As List(Of Movimientos)

        Dim queryResults = (From cust In datosMov _
                           Where cust.AsientoID = id).ToList


        Return queryResults
    End Function

    Private Function SumatoriaMovimientosMN(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov _
                        Where cust.AsientoID = idAsiento _
                        And cust.Tipo = strTipo _
                        Select cust.Importemn).Sum


        Return queryResults
    End Function

    Private Function SumatoriaMovimientosME(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov _
                        Where cust.AsientoID = idAsiento _
                        And cust.Tipo = strTipo _
                        Select cust.Importeme).Sum


        Return queryResults
    End Function
#End Region

#Region "ASIENTOS"
    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        'Dim objTotalesDet As New totalesAlmacen
        'Dim ListaTotales As New List(Of totalesAlmacen)
        'Dim almacenSA As New almacenSA

        'For Each i As DataGridViewRow In dgvNuevoDoc.Rows
        '    objTotalesDet = New totalesAlmacen
        '    objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
        '    objTotalesDet.SecuenciaDetalle = 0
        '    objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
        '    objTotalesDet.Modulo = "N"
        '    objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(CInt(cboalmacenDestino.SelectedValue)).idEstablecimiento
        '    objTotalesDet.idAlmacen = cboalmacenDestino.SelectedValue
        '    objTotalesDet.origenRecaudo = i.Cells(1).Value()
        '    objTotalesDet.tipoCambio = txtTipoCambio.Value
        '    objTotalesDet.tipoExistencia = i.Cells(13).Value()
        '    objTotalesDet.idItem = i.Cells(2).Value()
        '    objTotalesDet.descripcion = i.Cells(3).Value()
        '    objTotalesDet.idUnidad = i.Cells(6).Value()
        '    objTotalesDet.unidadMedida = Nothing
        '    objTotalesDet.cantidad = CType(i.Cells(7).Value(), Decimal)
        '    objTotalesDet.precioUnitarioCompra = CType(i.Cells(8).Value(), Decimal)
        '    objTotalesDet.importeSoles = CType(i.Cells(10).Value(), Decimal)
        '    objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal)
        '    objTotalesDet.montoIsc = 0
        '    objTotalesDet.montoIscUS = 0
        '    objTotalesDet.Otros = 0
        '    objTotalesDet.OtrosUS = 0
        '    objTotalesDet.porcentajeUtilidad = 0
        '    objTotalesDet.importePorcentaje = 0
        '    objTotalesDet.importePorcentajeUS = 0
        '    objTotalesDet.precioVenta = 0
        '    objTotalesDet.precioVentaUS = 0
        '    objTotalesDet.usuarioActualizacion = "NN"
        '    objTotalesDet.fechaActualizacion = Date.Now
        '    ListaTotales.Add(objTotalesDet)
        'Next

        'Return ListaTotales
        Return Nothing
    End Function

    Private Function ListaTotalesAlmacenOrigen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA


        For Each r As Record In dgvTransferencia.Table.Records
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(CInt(r.GetValue("colIdAlmacenOrigen"))).idEstablecimiento
            objTotalesDet.idAlmacen = r.GetValue("colIdAlmacenOrigen")
            objTotalesDet.origenRecaudo = r.GetValue("Gravado")
            objTotalesDet.tipoCambio = txtTipoCambio.Value
            objTotalesDet.tipoExistencia = r.GetValue("TipoExistencia")
            objTotalesDet.idItem = r.GetValue("IDArticulo")
            objTotalesDet.descripcion = r.GetValue("Art")
            objTotalesDet.idUnidad = r.GetValue("Uni1")
            objTotalesDet.unidadMedida = Nothing
            objTotalesDet.cantidad = CType(r.GetValue("Can1"), Decimal) * -1
            objTotalesDet.precioUnitarioCompra = CType(r.GetValue("Prec"), Decimal) * -1
            objTotalesDet.importeSoles = CType(r.GetValue("ImporteNeto"), Decimal) * -1
            objTotalesDet.importeDolares = CType(r.GetValue("ImporteUS"), Decimal) * -1
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
        Next

        'For Each i As DataGridViewRow In dgvNuevoDoc.Rows

        'Next

        Return ListaTotales
    End Function

    Sub AsientoTransferenciaEntreAlmacenes()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Try
            ListaAsientonTransito = New List(Of asiento)

            asientoBL = New asiento
            asientoBL.periodo = lblPerido.Text
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(txtProveedor.Tag)
            asientoBL.nombreEntidad = txtProveedor.Text
            If chProv.Checked = True Then
                asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            Else
                asientoBL.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
            End If

            asientoBL.fechaProceso = txtFechaComprobante.Value
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.importeMN = CDec(txtTotalmn.Text)
            asientoBL.importeME = CDec(txtTotalme.Text)
            asientoBL.glosa = "Transferencia entre almacenes" ' Glosa()

            For Each r As Record In dgvTransferencia.Table.Records
                nMovimiento = New movimiento
                Select Case r.GetValue("TipoExistencia")
                    Case "01"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS01.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "02"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "02", "ITEM", "TRANS02.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "03"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "ALM03.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "04"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "ALM04.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "05"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "ALM05.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                        'Case "06"
                        '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "06", "ITEM", "TRANS06.1")
                        '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                        'Case "07"
                        '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "07", "ITEM", "TRANS07.1")
                        '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                        'Case "08"
                        '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "08", "ITEM", "TRANS08.1")
                        '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                End Select

                nMovimiento.descripcion = r.GetValue("Art")
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(r.GetValue("ImporteNeto"))
                nMovimiento.montoUSD = CDec(r.GetValue("ImporteUS"))
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
                asientoBL.movimiento.Add(HaberTransferenciaMOv(r))
            Next

            ListaAsientonTransito.Add(asientoBL)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Function HaberTransferenciaMOv(r As Record) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        Select Case r.GetValue("TipoExistencia")
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "ALM01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                'Case "02"
                '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS02.2")
                'nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "ALM03.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "ALM04.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "ALM05.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                'Case "06"
                '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS06.2")
                '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                'Case "07"
                '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS07.2")
                '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                'Case "08"
                '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS08.2")
                '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        End Select
        nMovimiento.descripcion = r.GetValue("Art")
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(r.GetValue("ImporteNeto"))
        nMovimiento.montoUSD = CDec(r.GetValue("ImporteUS"))
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now

        Return nMovimiento
    End Function

    Function HaberOtrasExistenciasMOv(r As Record) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1000"
        nMovimiento.descripcion = r.GetValue("Art")
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(r.GetValue("ImporteNeto"))
        nMovimiento.montoUSD = CDec(r.GetValue("ImporteUS"))
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now

        Return nMovimiento
    End Function

    Sub AsientoEntrada()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim TLmn As Decimal = 0
        Dim TLme As Decimal = 0
        For Each i In datos
            asientoBL = New asiento
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(txtProveedor.Tag)
            asientoBL.nombreEntidad = txtProveedor.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            asientoBL.fechaProceso = txtFechaComprobante.Value
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.glosa = i.NombreAsiento
            listaMovimiento = ListarMovimientoporAsiento(i.AsientoID)
            For Each x In listaMovimiento
                nMovimiento = New movimiento
                nMovimiento.cuenta = x.Cuenta
                nMovimiento.idAsiento = x.AsientoID
                nMovimiento.descripcion = x.Descripcion
                nMovimiento.tipo = x.Tipo
                nMovimiento.monto = x.Importemn
                nMovimiento.montoUSD = x.Importeme
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
            Next
            asientoBL.importeMN = SumatoriaMovimientosMN(i.AsientoID, "D")
            asientoBL.importeME = SumatoriaMovimientosME(i.AsientoID, "D")
            ListaAsientonTransito.Add(asientoBL)
        Next
    End Sub

    Sub AsientoEntradaExistencia()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Try
            asientoBL = New asiento
            asientoBL.periodo = lblPerido.Text
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(txtProveedor.Tag)
            asientoBL.nombreEntidad = txtProveedor.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            asientoBL.fechaProceso = txtFechaComprobante.Value
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.importeMN = CDec(txtTotalmn.Text)
            asientoBL.importeME = CDec(txtTotalme.Text)
            asientoBL.glosa = txtGlosa.Text.Trim 'Glosa()

            For Each r As Record In dgvTransferencia.Table.Records
                'If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                nMovimiento = New movimiento
                If r.GetValue("TipoExistencia") = "01" Then
                    nMovimiento.cuenta = mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, r.GetValue("Cuenta")).cuentaDestinoKardex
                Else
                    nMovimiento.cuenta = mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, r.GetValue("Cuenta"), r.GetValue("TipoExistencia")).cuentaIngAlmacen
                End If
                nMovimiento.descripcion = r.GetValue("Art")
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(r.GetValue("ImporteNeto"))
                nMovimiento.montoUSD = CDec(r.GetValue("ImporteUS"))
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
                asientoBL.movimiento.Add(HaberOtrasExistenciasMOv(r))
                'End If
            Next

            ListaAsientonTransito.Add(asientoBL)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub

#End Region

    'Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
    '    Dim asientoSA As New AsientoSA
    '    Dim movimientoSA As New MovimientoSA

    '    Dim objDoc As New DocumentoSA
    '    Dim objDocCompra As New DocumentoCompraSA
    '    Dim objDocCompraDet As New DocumentoCompraDetalleSA
    '    Dim objTabla As New tablaDetalleSA
    '    Dim objEntidad As New entidadSA
    '    Dim nEntidad As New entidad
    '    Dim VALUEDES As String = ""
    '    Dim insumosSA As New detalleitemsSA
    '    Dim almacenSA As New almacenSA
    '    Dim PersonaSA As New PersonaSA
    '    Dim Persona As New Persona
    '    Try
    '        With objDoc.UbicarDocumento(intIdDocumento)
    '            txtFechaComprobante.Value = .fechaProceso
    '            'COMPROBANTE
    '            txtIdComprobante.Text = "99 - GUIA DE REMISION"
    '        End With

    '        'CABECERA COMPROBANTE
    '        With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
    '            Select Case .destino
    '                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
    '                    lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
    '                    '  ToolStripLabel1.Text = "TRANSFERENCIA ENTRE ALMACENES"
    '                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
    '                    lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
    '                    ' ToolStripLabel1.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
    '            End Select

    '            lblIdDocumento.Text = .idDocumento
    '            txtFechaComprobante.Text = .fechaDoc
    '            lblPerido.Text = .fechaContable
    '            txtSerie.Text = .serie
    '            txtNumero.Text = .numeroDoc
    '            txtGlosa.Text = .glosa
    '            If Not IsNothing(.idProveedor) Then
    '                chProv.Checked = True
    '                chTrab.Checked = False

    '                'PROVEEDOR
    '                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
    '                txtRuc.Text = nEntidad.nrodoc
    '                txtCuenta = nEntidad.cuentaAsiento
    '                txtProveedor.Tag = nEntidad.idEntidad
    '                txtProveedor.Text = nEntidad.nombreCompleto

    '            Else
    '                chTrab.Checked = True
    '                chProv.Checked = False
    '                Persona = PersonaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, .idPersona)
    '                If Not IsNothing(Persona) Then
    '                    txtRuc.Text = Persona.idPersona
    '                    txtCuenta = "TR"
    '                    txtProveedor.Tag = Persona.idPersona
    '                    txtProveedor.Text = Persona.nombreCompleto
    '                End If
    '            End If
    '            dgvNuevoDoc.ReadOnly = True
    '            '_::::::::::::::::::        :::::::::::::::::::
    '            txtTipoCambio.Value = .tcDolLoc
    '        End With

    '        'DETALLE DE LA COMPRA
    '        dgvNuevoDoc.Rows.Clear()
    '        Dim almacenDestino As Integer
    '        For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)
    '            almacenDestino = i.almacenDestino
    '            If i.destino = "1" Then
    '                VALUEDES = "1"
    '            ElseIf i.destino.Trim = "2" Then
    '                VALUEDES = "2"
    '            ElseIf i.destino.Trim = "3" Then
    '                VALUEDES = "3"
    '            ElseIf i.destino.Trim = "4" Then
    '                VALUEDES = "4"
    '            End If

    '            dgvNuevoDoc.Rows.Add(i.secuencia,
    '                                 VALUEDES,
    '                                 i.idItem,
    '                                 i.descripcionItem,
    '                                 i.unidad2,
    '                                 i.monto2,
    '                                 i.unidad1,
    '                                 FormatNumber(i.monto1, 2),
    '                                 FormatNumber(i.precioUnitario, 2),
    '                                 FormatNumber(i.precioUnitarioUS, 2),
    '                                 FormatNumber(i.importe, 2),
    '                                 FormatNumber(i.importeUS, 2),
    '                                 Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
    '                                 insumosSA.InvocarProductoID(i.idItem).cuenta,
    '                                 i.preEvento, Nothing, i.almacenRef, almacenSA.GetUbicar_almacenPorID(i.almacenRef).descripcionAlmacen,
    '                                 Nothing, almacenSA.GetUbicar_almacenPorID(i.almacenRef).descripcionAlmacen, i.almacenRef)
    '        Next
    '        With almacenSA.GetUbicar_almacenPorID(almacenDestino)
    '            cboalmacenDestino.SelectedValue = .idAlmacen
    '        End With
    '        colAlmacenBAck.Visible = True

    '        TotalesCabeceras()
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try

    'End Sub


    'Public Function Glosa() As String
    '    Return "Por Transferencia de " & cboTipoExistencia.Text & ", Del almacén " & cboAlmacen.Text & "hacia el almacén " & cboalmacenDestino.Text & ", según Doc. Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
    'End Function

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaTotalesOrigen As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim numeroDoc As String = ""
        Dim serie As String = ""

        If (cboTipoDoc.Text = "VOUCHER CONTABLE") Then
            numeroDoc = Nothing
            serie = GConfiguracion.Serie
        ElseIf (cboTipoDoc.Text = "GUIA DE REMISION") Then
            serie = txtSerie.Text.Trim
            numeroDoc = txtNumero.Text
        End If

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            If (cboTipoDoc.Text = "VOUCHER CONTABLE") Then
                .tipoDoc = "9901"
            ElseIf (cboTipoDoc.Text = "GUIA DE REMISION") Then
                .tipoDoc = "09"
            End If

            .fechaProceso = txtFechaComprobante.Value
            '.nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .nroDoc = serie & "-" & numeroDoc
            .idOrden = Nothing ' Me.IdOrden
            .moneda = "1"
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .nrodocEntidad = txtRuc.Text
            If chProv.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf chCli.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf chTrab.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
            End If
            .tipoOperacion = "19"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        'Select Case ToolStripComboBox2.Text
        '    Case "TOTAL"

        '        tipoEstado = TipoGuia.Entregado
        '    Case Else

        '        tipoEstado = TipoGuia.Pendiente
        'End Select

        With nDocumentoCompra
            .tipoOperacion = "19"
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            If (cboTipoDoc.Text = "VOUCHER CONTABLE") Then
                .tipoDoc = "9901"
            ElseIf (cboTipoDoc.Text = "GUIA DE REMISION") Then
                .tipoDoc = "09"
            End If
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            .fechaContable = lblPerido.Text
            .numeroDoc = numeroDoc
            .serie = serie

            If chProv.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)

            ElseIf chCli.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)
            ElseIf chTrab.Checked = True Then
                .idPersona = CInt(txtProveedor.Tag)
            End If

            .nombreProveedor = txtProveedor.Text
            .monedaDoc = "1"
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            .estadoEntrega = TipoEntregado.PorEntregar
            .importeTotal = CDec(txtTotalmn.Text)
            .importeUS = CDec(txtTotalme.Text)

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim ' Glosa()
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'ASIENTOS CONTABLES
        Dim almacenSA As New almacenSA

        For Each r As Record In dgvTransferencia.Table.Records
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.TipoOperacion = "19"
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(cboalmacenDestino.SelectedValue).idEstablecimiento ' i.Cells(19).Value()
            objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            If (cboTipoDoc.Text = "VOUCHER CONTABLE") Then
                objDocumentoCompraDet.TipoDoc = "9901"
            ElseIf (cboTipoDoc.Text = "GUIA DE REMISION") Then
                objDocumentoCompraDet.TipoDoc = "09"
            End If

            'objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            'objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = numeroDoc
            objDocumentoCompraDet.Serie = serie
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If r.GetValue("Gravado") = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf r.GetValue("Gravado") = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf r.GetValue("Gravado") = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf r.GetValue("Gravado") = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If

            If (Not IsNothing(r.GetValue("Cuenta"))) Then
                objDocumentoCompraDet.CuentaItem = ""

            Else
                objDocumentoCompraDet.CuentaItem = r.GetValue("Cuenta")
            End If

            objDocumentoCompraDet.idItem = r.GetValue("IDArticulo")
            objDocumentoCompraDet.tipoExistencia = r.GetValue("TipoExistencia")
            objDocumentoCompraDet.descripcionItem = r.GetValue("Art")
            objDocumentoCompraDet.DetalleItem = r.GetValue("Art")
            objDocumentoCompraDet.unidad1 = r.GetValue("Uni1")

            objDocumentoCompraDet.nrolote = r.GetValue("nrolote")

            'objDocumentoCompraDet.idCosto = txtidEntregable.Text
            'objDocumentoCompraDet.tipoCosto = "PC"



            If IsNumeric(r.GetValue("Can1")) Then
                If CDec(r.GetValue("Can1")) <= 0 Then
                    MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If

            If IsNumeric(r.GetValue("ImporteNeto")) Then
                If CDec(r.GetValue("ImporteNeto")) < 0 Then
                    MessageBox.Show("El valor del importe no puede ser negativo", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If

            If CDec(r.GetValue("Can1")) > CDec(r.GetValue("colDisponible")) Then

                MessageBox.Show("El valor de la cantidad no puede exceder el stock disponible", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            objDocumentoCompraDet.monto1 = CDec(r.GetValue("Can1"))
            objDocumentoCompraDet.unidad2 = r.GetValue("uni2").ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = r.GetValue("Cant2") ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("Prec"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("PrecUnitUS"))
            objDocumentoCompraDet.importe = CDec(r.GetValue("ImporteNeto"))
            objDocumentoCompraDet.importeUS = CDec(r.GetValue("ImporteUS"))

            If (Not IsNothing(r.GetValue("cbopreEvento"))) Then
                objDocumentoCompraDet.CuentaItem = ""
            Else
                objDocumentoCompraDet.preEvento = r.GetValue("cbopreEvento")
            End If
            '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.almacenRef = CInt(r.GetValue("colIdAlmacenOrigen"))
            objDocumentoCompraDet.almacenDestino = cboalmacenDestino.SelectedValue ' CDec(i.Cells(17).Value())
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim 'Glosa()
            ' objDocumentoCompraDet.BonificacionMN =
            'ValidarCantidad(dgvNuevoDoc.CurrentRow.Index)

            ListaDetalle.Add(objDocumentoCompraDet)
        Next


        GuiaRemision(ndocumento)



        'TOTALES ALMACEN
        '     ListaTotales = ListaTotalesAlmacen() '+positivo

        'Select Case lblMovimiento.Text
        '    Case "TRANSFERENCIA ENTRE ALMACENES"
        AsientoTransferenciaEntreAlmacenes()
        'ListaTotalesOrigen = ListaTotalesAlmacenOrigen() 'negativo
        '    Case Else
        'AsientoEntrada()
        'End Select

        'For Each i In ListaAsientonTransito

        '    Dim consultaMov = (From n In ListaMovimientos _
        '                      Where n.idAsiento = i.idAsiento).ToList


        '    i.idEmpresa = Gempresas.IdEmpresaRuc
        '    i.idCentroCostos = GEstableciento.IdEstablecimiento
        '    i.idEntidad = CInt(txtProveedor.Tag)
        '    i.nombreEntidad = txtProveedor.Text
        '    i.tipoEntidad = "PR"
        '    i.fechaProceso = txtFechaComprobante.Value
        '    i.codigoLibro = "08"
        '    i.tipo = "D"
        '    i.tipoAsiento = "AS-M"
        '    i.importeMN = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
        '    i.importeME = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
        '    i.glosa = "Asiento manual trasferencia entre almacenes"
        '    i.usuarioActualizacion = usuario.IDUsuario
        '    i.fechaActualizacion = DateTime.Now

        '    For Each mov In consultaMov
        '        i.movimiento.Add(mov)
        '    Next
        'Next

        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN

        CompraSA.GrabarSalidaProduccion(ndocumento)
        lblEstado.Text = "entrada registrada!"

        Dispose()
    End Sub

    Sub GrabarDefault()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaTotalesOrigen As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "99"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDoc = "99"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaContable = lblPerido.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            If chProv.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)
            Else
                .idPersona = CInt(txtProveedor.Tag)
            End If
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = 1
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = CDec(txtTotalmn.Text)
            .importeUS = CDec(txtTotalme.Text)

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim ' Glosa()
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        GuiaRemision(ndocumento)

        'ASIENTOS CONTABLES

        For Each r As Record In dgvCompra.Table.Records
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = r.GetValue("coliDestableAlmacen")
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = "99"
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If r.GetValue("Gravado") = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf r.GetValue("Gravado") = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf r.GetValue("Gravado") = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf r.GetValue("Gravado") = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.CuentaItem = r.GetValue("Cuenta")
            objDocumentoCompraDet.idItem = r.GetValue("IDArticulo")
            objDocumentoCompraDet.tipoExistencia = r.GetValue("TipoExistencia")
            objDocumentoCompraDet.descripcionItem = r.GetValue("Art")
            objDocumentoCompraDet.unidad1 = r.GetValue("Uni1")
            objDocumentoCompraDet.monto1 = CDec(r.GetValue("Can1"))
            objDocumentoCompraDet.unidad2 = r.GetValue("uni2").ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = r.GetValue("Cant2") ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("Prec"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("PrecUnitUS"))
            objDocumentoCompraDet.importe = CDec(r.GetValue("ImporteNeto"))
            objDocumentoCompraDet.importeUS = CDec(r.GetValue("ImporteUS"))
            'objDocumentoCompraDet.montokardex = CDec(i.Cells(12).Value())
            'objDocumentoCompraDet.montoIsc = CDec(i.Cells(13).Value())
            'objDocumentoCompraDet.montoIgv = CDec(i.Cells(14).Value())
            'objDocumentoCompraDet.otrosTributos = CDec(i.Cells(15).Value())
            ''**********************************************************************************
            'objDocumentoCompraDet.montokardexUS = CDec(i.Cells(16).Value())
            'objDocumentoCompraDet.montoIscUS = CDec(i.Cells(17).Value())
            'objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
            'objDocumentoCompraDet.otrosTributosUS = CDec(i.Cells(19).Value())
            objDocumentoCompraDet.preEvento = r.GetValue("cbopreEvento") '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            'objDocumentoCompraDet.bonificacion = i.Cells(29).Value()
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            'If i.Cells(18).Value() = "Asignar almacén" Then
            '    lblEstado.Enabled = "Debe asignar un almacén en la celda!"


            '    'Timer1.Enabled = True
            '    'TiempoEjecutar(5)
            '    Exit Sub
            'End If
            objDocumentoCompraDet.almacenRef = CInt(r.GetValue("colAlmacenRef"))
            '   objDocumentoCompraDet.almacenDestino = CDec(i.Cells(17).Value())
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim ' Glosa()
            ' objDocumentoCompraDet.BonificacionMN =



            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next


        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen() '+positivo
        AsientoEntradaExistencia()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN

        Dim xcod As Integer = CompraSA.SaveOtrasEntradasDefault(ndocumento, ListaTotales)
        lblEstado.Text = "entrada registrada!"

     
        Dispose()
    End Sub

    Sub UpdateCompra()
        Dim CompraSA As New DocumentoCompraSA
        Dim DocCaja As New documento

        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle

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
        With ndocumento
            .idDocumento = lblIdDocumento.Text
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "99"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idDocumento = lblIdDocumento.Text
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDoc = "99"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value
            .fechaContable = lblPerido.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            If chProv.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)
            Else
                .idPersona = CInt(txtProveedor.Tag)
            End If
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = 1 'IIf(cboMoneda.SelectedValue = "1", "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = IIf(txtTipoCambio.Value = 0 Or txtTipoCambio.Value = "0.00", 0, CDec(txtTipoCambio.Value))
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            '****************************************************************************************************************
            .importeTotal = CDec(txtTotalmn.Text)
            .importeUS = CDec(txtTotalme.Text)

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim ' Glosa()
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        AsientoEntradaExistencia()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        CompraSA.UpdateOtrasEntradas(ndocumento, ListaTotales, ListaDeleteEO)
        lblEstado.Text = "entrada modificada!"

        Dispose()
    End Sub

    Sub Productoshijos()
        Dim categoriaSA As New itemSA

        cboProductos.DisplayMember = "descripcion"
        cboProductos.ValueMember = "idItem"
        cboProductos.DataSource = categoriaSA.GetListaMarcaPadre(CboClasificacion.SelectedValue)
    End Sub

    Public Sub CargarListas()
        Dim tablaSA As New tablaDetalleSA
        Dim almacenSA As New almacenSA
        '   Dim entidadSA As New entidadSA
        Dim almacen As New List(Of almacen)
        Dim entidadSA As New entidadSA
        Dim categoriaSA As New itemSA
        Dim estableSA As New establecimientoSA

        Dim listatabla As New List(Of tabladetalle)

        almacen = almacenSA.GetListar_almacenesTipo(GEstableciento.IdEstablecimiento, "AF")
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.DataSource = almacen



        'TIPO DE EXISTENCIA
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(5, "1")
        Dim listaNoExistencias As New List(Of String)
        listaNoExistencias.Add("06")
        listaNoExistencias.Add("07")
        listaNoExistencias.Add("08")
        listaNoExistencias.Add("02")
        listaNoExistencias.Add("01")

        Dim consultaExistencia = (From n In listatabla
                                  Where Not listaNoExistencias.Contains(n.codigoDetalle)).ToList

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = consultaExistencia


        'cboTipoExistencia.ValueMember = "codigoDetalle"
        'cboTipoExistencia.DisplayMember = "descripcion"
        'cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")


        'CboClasificacion.DisplayMember = "descripcion"
        'CboClasificacion.ValueMember = "idItem"
        'CboClasificacion.DataSource = categoriaSA.GetListaPadre()

        ListadoDestinatarios = New List(Of entidad)
        ListadoDestinatarios = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})


        cboEstablecimiento.DataSource = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
        cboEstablecimiento.DisplayMember = "nombre"
        cboEstablecimiento.ValueMember = "idCentroCosto"
        cboEstablecimiento.SelectedValue = GEstableciento.IdEstablecimiento

        almacenDestino = almacenSA.GetListar_almacenesTipo(cboEstablecimiento.SelectedValue, "AP")

        Dim con = (From n In almacenDestino
                   Where n.idAlmacen <> cboAlmacen.SelectedValue).ToList

        cboalmacenDestino.ValueMember = "idAlmacen"
        cboalmacenDestino.DisplayMember = "descripcionAlmacen"
        cboalmacenDestino.DataSource = con
        cboalmacenDestino.SelectedValue = -1
    End Sub

    Public Sub ObtenerListadoPreciosLiked(intIdAlmacen As Integer, strtipoEx As String, strBusqueda As String)
        Dim tablaSA As New tablaDetalleSA
        Dim totalSA As New TotalesAlmacenSA
        Try
            lsvExistencias.Items.Clear()
            For Each i As totalesAlmacen In totalSA.GetProductoPorAlmacenTipoEx(intIdAlmacen, strtipoEx, strBusqueda)
                Dim n As New ListViewItem(i.idEstablecimiento)
                n.SubItems.Add(i.origenRecaudo)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.idUnidad)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(FormatNumber(i.cantidad, 2))
                n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                n.SubItems.Add(FormatNumber(i.importeDolares, 2))
                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(CDec(i.importeSoles) / CDec(i.cantidad))
                Else
                    n.SubItems.Add(0)
                End If

                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(CDec(i.importeDolares) / CDec(i.cantidad))
                Else
                    n.SubItems.Add(0)
                End If

                n.SubItems.Add(i.NroLote)
                lsvExistencias.Items.Add(n)
            Next
            For Each item As ListViewItem In lsvExistencias.Items
                Dim i As Short
                If i Mod 2 = 0 Then
                    item.BackColor = Color.Transparent
                    item.ForeColor = Color.Gray
                Else
                    item.BackColor = Color.WhiteSmoke
                    item.ForeColor = Color.Gray
                End If
                i = i + 1
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Public Sub ObtenerListadoByCodigoBarra(intIdAlmacen As Integer, strtipoEx As String, CodBarra As String)
        Dim tablaSA As New tablaDetalleSA
        Dim totalSA As New TotalesAlmacenSA
        Try
            lsvExistencias.Items.Clear()
            For Each i As totalesAlmacen In totalSA.GetProductoPorAlmacenTipoExByCodigoBarra(intIdAlmacen, strtipoEx, CodBarra)
                Dim n As New ListViewItem(i.idEstablecimiento)
                n.SubItems.Add(i.origenRecaudo)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.idUnidad)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(FormatNumber(i.cantidad, 2))
                n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                n.SubItems.Add(FormatNumber(i.importeDolares, 2))
                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(CDec(i.importeSoles) / CDec(i.cantidad))
                Else
                    n.SubItems.Add(0)
                End If

                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(CDec(i.importeDolares) / CDec(i.cantidad))
                Else
                    n.SubItems.Add(0)
                End If
                lsvExistencias.Items.Add(n)
            Next
            For Each item As ListViewItem In lsvExistencias.Items
                Dim i As Short
                If i Mod 2 = 0 Then
                    item.BackColor = Color.Transparent
                    item.ForeColor = Color.Gray
                Else
                    item.BackColor = Color.WhiteSmoke
                    item.ForeColor = Color.Gray
                End If
                i = i + 1
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Public Sub TotalesCabeceras()
        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0

        For Each r As Record In dgvTransferencia.Table.Records

            'If r.GetValue("Estado") <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
            cTotalMN += CDec(r.GetValue("ImporteNeto"))
            cTotalME += CDec(r.GetValue("ImporteUS"))
            'End If
        Next
        txtTotalmn.Text = cTotalMN.ToString("N2")
        txtTotalme.Text = cTotalME.ToString("N2")


    End Sub

    Private Sub CellEndEditRefresh()
        Dim colDestinoGravado As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colPrecUnitUSD As Decimal = 0

        '**************************************************************
        If dgvTransferencia.Table.Records.Count > 0 Then
            'DECLARANDO VARIABLES

            For Each r As Record In dgvTransferencia.Table.Records
                'If r.GetValue("Estado").ToString <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then

                colDestinoGravado = r.GetValue("Gravado")
                'DECLARANDO VARIABLES
                colPrecUnit = r.GetValue("Prec")
                colPrecUnitUSD = r.GetValue("PrecUnitUS")

                If Not CStr(r.GetValue("Can1")).Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese una cantidad válida!"
                    Exit Sub
                Else
                    colCantidad = r.GetValue("Can1")
                End If

                Dim colMN As Decimal = 0
                colMN = Math.Round(colCantidad * colPrecUnit, 2)

                Dim colME As Decimal = 0
                colME = Math.Round(colCantidad * colPrecUnitUSD, 2)

                r.SetValue(("ImporteNeto"), colMN.ToString("N2"))
                r.SetValue(("ImporteUS"), colME.ToString("N2"))


                'End If

            Next
            'For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            'Next
            TotalesCabeceras()
        Else
            TotalesCabeceras()
        End If


    End Sub

    Public Function GetTableAlmacen() As DataTable

        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dt As New DataTable()
        dt.Columns.Add("idCuenta", GetType(Integer))
        dt.Columns.Add("descripcionCuenta", GetType(String))

        For Each i In cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.cuenta
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function GetTableAsientos() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Return dt

    End Function

    Public Sub GetTableAlmacen2()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        comboTableh = New DataTable("Cuentas")
        comboTableh.Columns.Add("idCuenta")
        comboTableh.Columns.Add("descripcionCuenta")

        For Each i In cuentaSA.ObtenerCuentasPorEmpresaEscalableV2(Gempresas.IdEmpresaRuc)
            comboTableh.Rows.Add(New Object() {i.cuenta, i.descripcion})
        Next

    End Sub

#End Region

#Region "Events"

    Private Sub frmMovimientoAlmacen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub
    Dim comboTable As New DataTable
   
    Dim comboTableh As New DataTable

    Private Sub frmMovimientoAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTableAlmacen2()

        Dim ggcStyle7 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
        ggcStyle7.CellType = "ComboBox"
        ggcStyle7.DataSource = Me.comboTableh
        ggcStyle7.ValueMember = "idCuenta"
        ggcStyle7.DisplayMember = "descripcionCuenta"
        ggcStyle7.DropDownStyle = GridDropDownStyle.AutoComplete

        Dim ggcStyle3 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(3).Appearance.AnyRecordFieldCell
        ggcStyle7.CellType = "ComboBox"
        ggcStyle7.DataSource = Me.comboTableh
        ggcStyle7.DropDownStyle = GridDropDownStyle.AutoComplete

        Dim ggcStyle2 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(3).Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = Me.GetTableAsientos
        ggcStyle2.ValueMember = "id"
        ggcStyle2.DisplayMember = "name"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive

        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.SelectAll
        dgvCompra.ShowRowHeaders = False

        dgvTransferencia.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvTransferencia.ShowRowHeaders = False

        RegistrarAsientos()

    End Sub



    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub dropDownBtn_Click(sender As Object, e As EventArgs)
        If chProv.Checked = True Then
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
        End If
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtBuscarProducto.Text.Trim.Length > 0 Then
                ObtenerListadoPreciosLiked(CInt(cboAlmacen.SelectedValue), cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)
            Else

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvExistencias_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvExistencias.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        Dim itemsSA As New detalleitemsSA
        Dim almacenSA As New almacenSA
        Dim boollExiste As Boolean = False
        Try
            If lsvExistencias.SelectedItems.Count > 0 Then

                '   If datos.Count > 0 Then
                Select Case lblMovimiento.Text
                    Case "TRANSFERENCIA ENTRE ALMACENES"

                        With itemsSA.InvocarProductoID(lsvExistencias.SelectedItems(0).SubItems(2).Text)
                            strUM = .unidad1
                            strTipoEx = .tipoExistencia
                            strCuenta = .cuenta
                            strIdPresentacion = .presentacion
                        End With
                        With almacenSA.GetUbicar_almacenPorID(CInt(cboAlmacen.SelectedValue))
                            srtNomAlmacen = .descripcionAlmacen
                            intIdEstableAlm = .idEstablecimiento
                        End With

                        'se valida que el articulo seleccionado para transferir no se duplique
                        If dgvTransferencia.Table.Records.Count > 0 Then

                            'For i As Integer = 0 To GridGroupingControl1.Table.Records.Count - 1
                            '    If GridGroupingControl1.Item(2, i).Value = lsvExistencias.SelectedItems(0).SubItems(2).Text Then
                            '        boollExiste = True
                            '        Exit For
                            '    End If
                            'Next
                        End If

                        'If Not boollExiste Then
                        cantidaExistente.Add(lsvExistencias.SelectedItems(0).SubItems(6).Text)

                        Me.dgvTransferencia.Table.AddNewRecord.SetCurrent()
                        Me.dgvTransferencia.Table.AddNewRecord.BeginEdit()
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Secuencia", "0")
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Gravado", lsvExistencias.SelectedItems(0).SubItems(1).Text)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("IDArticulo", lsvExistencias.SelectedItems(0).SubItems(2).Text)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Art", lsvExistencias.SelectedItems(0).SubItems(3).Text)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("uni2", strIdPresentacion)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Cant2", lsvExistencias.SelectedItems(0).SubItems(5).Text)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Uni1", strUM)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Can1", lsvExistencias.SelectedItems(0).SubItems(6).Text)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Prec", lsvExistencias.SelectedItems(0).SubItems(9).Text)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("PrecUnitUS", lsvExistencias.SelectedItems(0).SubItems(10).Text)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("ImporteNeto", 0)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("ImporteUS", 0)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Estado", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("TipoExistencia", strTipoEx)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Cuenta", strCuenta)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("cbopreEvento", Nothing)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("Evento", Nothing)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("colAlmacenRef", Nothing)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("colSelAlmacen", "Asignar almacén")
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("coliDestableAlmacen", intIdEstableAlm)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("colAlmacenBAck", Nothing)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("colIdAlmacenOrigen", CInt(cboAlmacen.SelectedValue))
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("colDisponible", lsvExistencias.SelectedItems(0).SubItems(6).Text)
                        Me.dgvTransferencia.Table.CurrentRecord.SetValue("nrolote", lsvExistencias.SelectedItems(0).SubItems(11).Text)

                        Me.dgvTransferencia.Table.AddNewRecord.EndEdit()
                        dgvTransferencia.TableControl.CurrentCell.EndEdit()
                        dgvTransferencia.TableControl.Table.TableDirty = True
                        dgvTransferencia.TableControl.Table.EndEdit()


                    Case Else

                End Select


                '   End If
            End If
            If dgvTransferencia.Table.Records.Count > 0 Then
                CellEndEditRefresh()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumero.Focus()
        End If
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs)
        If txtSerie.Text.Trim.Length > 0 Then
            txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
        End If
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        If txtNumero.Text.Trim.Length > 0 Then
            txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
        End If
    End Sub

    Private Sub txtComprobante_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtSerie.Focus()
        End If
    End Sub

    Private Sub txtAlmacenDestino_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Focus()
        End If
    End Sub

    Private Sub dgvNuevoDoc_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
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


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        If chProv.Checked = True Then
            txtDocProveedor.Clear()
            txtNomProv.Clear()
            txtApePat.Clear()
            pcProveedor.Font = New Font("Segoe UI", 8)
            pcProveedor.Size = New Size(321, 259)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
        End If

    End Sub

    Private Sub btnGrabTRab_Click(sender As Object, e As EventArgs) Handles btnGrabTRab.Click
        If Not txtDniTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtDniTrab.Select()
            Exit Sub
        End If

        If Not txtNombreTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtNombreTrab.Select()
            Exit Sub
        End If

        If Not txtAppatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtAppatTrab.Select()
            Exit Sub
        End If

        If Not txtApmatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtApmatTrab.Select()
            Exit Sub
        End If

        btnGrabTRab.Tag = "G"
        Me.pcTrabajador.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.pcTrabajador.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcTrabajador_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcTrabajador.BeforePopup
        Me.pcTrabajador.BackColor = Color.White
    End Sub

    Private Sub pcTrabajador_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcTrabajador.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDniTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtDniTrab.Select()
                Exit Sub
            End If

            If Not txtNombreTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtNombreTrab.Select()
                Exit Sub
            End If

            If Not txtAppatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtAppatTrab.Select()
                Exit Sub
            End If

            If Not txtApmatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtApmatTrab.Select()
                Exit Sub
            End If

            If btnGrabTRab.Tag = "G" Then
                GrabarPersona()
                btnGrabTRab.Tag = "N"
            Else
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub btnGRabarProv_Click(sender As Object, e As EventArgs) Handles btnGRabarProv.Click
        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(327, 259)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(327, 259)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtNomProv.Select()
            Exit Sub
        End If

        If rbNatural.Checked = True Then
            If Not txtApePat.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
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

    Private Sub rbNatural_CheckChanged(sender As Object, e As EventArgs) Handles rbNatural.CheckChanged
        If rbNatural.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()
            Label31.Visible = True
            Label30.Text = "Nombres:"

            If btnRuc.Checked = True Then
                If rbNatural.Checked = True Then
                    txtDocProveedor.Text = "10"
                    txtDocProveedor.Select()
                End If
            End If
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

    Private Sub rbJuridico_CheckChanged(sender As Object, e As EventArgs) Handles rbJuridico.CheckChanged
        If rbJuridico.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            Label31.Visible = False
            Label30.Text = "Nombre o Razón Social:"

            If btnRuc.Checked = True Then
                If rbJuridico.Checked = True Then
                    txtDocProveedor.Text = "20"
                    txtDocProveedor.Select()
                End If
            End If
        End If
    End Sub

    Private Sub pcProveedor_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProveedor.BeforePopup
        Me.pcProveedor.BackColor = Color.White
    End Sub

    Private Sub pcProveedor_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProveedor.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDocProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtDocProveedor.Select()
                Exit Sub
            End If

            If Not txtNomProv.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtNomProv.Select()
                Exit Sub
            End If

            If rbNatural.Checked = True Then
                If Not txtApePat.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese los apellidos del proveedor"
                    pcProveedor.Font = New Font("Tahoma", 8)
                    pcProveedor.Size = New Size(327, 259)
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
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lstPersonas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstPersonas.MouseDoubleClick
        If lstPersonas.SelectedItems.Count > 0 Then
            Me.pcPersonas.HidePopup(PopupCloseType.Done)
        End If
    End Sub


    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Cursor = Cursors.WaitCursor
        If txtFiltroTrab.Text.Trim.Length > 0 Then
            ObtenerPersonaPorNombre(txtFiltroTrab.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pcPersonas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcPersonas.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstPersonas.SelectedItems.Count > 0 Then
                Me.txtProveedor.Tag = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
                txtProveedor.Text = lstPersonas.Text
                txtCuenta = "TR"
                txtRuc.Text = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor

        'If Not txtEntregable.ToString.Trim.Length > 0 Then
        '    lblEstado.Text = "Ingrese un Entregable!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'End If


        Dim codProv = txtProveedor.Tag
        If IsNothing(codProv) Then
            lblEstado.Text = "Ingrese el personal!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(5)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        If Not codProv.ToString.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el proveedor!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If


        If Not cboalmacenDestino.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe indicar el almacén de destino"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
            cboalmacenDestino.Select()
            Exit Sub
        End If

        Try


            '***********************************************************************
            Select Case lblMovimiento.Text
                Case "TRANSFERENCIA ENTRE ALMACENES"
                    Me.lblEstado.Text = "Done!"
                    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                        If dgvTransferencia.Table.Records.Count > 0 Then
                            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtFechaComprobante.Value.Year, .mes = txtFechaComprobante.Value.Month})
                            If Not IsNothing(valida) Then
                                If valida = True Then
                                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If

                            If MessageBox.Show("Desea realizar la transferencia con fecha: " & vbCrLf & _
                                                txtFechaComprobante.Value, "Verifique la fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Grabar()
                            End If

                            '    If ListaAsientonTransito.Count > 0 Then

                            'Else
                            '    Me.lblEstado.Text = "Ingrese items a la canasta de asientos contables!"
                            '    PanelError.Visible = True
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)

                            'End If
                        Else
                            Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)

                        End If

                    Else
                        'Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                        'If Filas > 0 Then
                        '    UpdateCompra()
                        'Else
                        '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                        '    PanelError.Visible = True
                        '    Timer1.Enabled = True
                        '    TiempoEjecutar(10)

                        'End If

                    End If

            End Select


        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub


    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        RegistrarAsientos()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Dim consulta = (From n In ListaAsientonTransito _
                 Where n.idAsiento = lstAsiento.SelectedValue).FirstOrDefault


        If Not IsNothing(consulta) Then
            Dim listaMov = (From i In ListaMovimientos _
                           Where i.idAsiento = lstAsiento.SelectedValue).ToList

            For Each obj In listaMov
                ListaMovimientos.Remove(obj)
            Next
            ListaAsientonTransito.Remove(consulta)
            GetasientosListbox()
            lstAsiento_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub lstAsiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAsiento.SelectedIndexChanged
        If lstAsiento.SelectedItems.Count > 0 Then

            RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
            UbicarAsientoPorId(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If lstAsiento.SelectedItems.Count > 0 Then
            RegsitarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
            RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
            Dim rec As Record = dgvCompra.Table.CurrentRecord
            Dim consulta = (From n In ListaMovimientos _
                           Where n.idmovimiento = rec.GetValue("id")).First

            If Not IsNothing(consulta) Then
                ListaMovimientos.Remove(consulta)
                Me.dgvCompra.Table.CurrentRecord.Delete()
            End If
        End If
        lstAsiento_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If lstAsiento.SelectedItems.Count > 0 Then
            Dim consulta = (From n In ListaMovimientos _
                           Where n.idAsiento = lstAsiento.SelectedValue).ToList

            If consulta.Count > 0 Then

                Dim f As New frmViewAsiento(consulta)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            'Select Case ColIndex
            '    Case 4
            '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

            '        'Case 7
            '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
            'End Select

            If ColIndex = 1 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 3 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanging
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            If ColIndex = 3 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
        End If
    End Sub


    Private Sub dgvCompra_TableControlCurrentCellAcceptedChanges(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellAcceptedChanges
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            If ColIndex = 2 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 4 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 7 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 1 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If

        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellChanging
        Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell

        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If cc.ColIndex = 1 Then
            cc.ConfirmChanges()
            ' Me.dgvCompra.TableModel(cc.RowIndex, cc.ColIndex + 1).CellValue = "Hai"
            '  updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            Dim str = Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue
            If str = "H" Then
                Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "D"
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            Else
                Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "H"
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
        End If
        If cc.ColIndex = 3 Then

            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

        End If
        If cc.ColIndex = 2 Then

            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

        End If


    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            'Select Case ColIndex
            '    Case 4
            '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

            '        'Case 7
            '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
            'End Select

            If ColIndex = 1 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 3 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 2 Then

                Dim cuentaSA As New cuentaplanContableEmpresaSA

                Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta")).descripcion)

                'Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta"))
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 4 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 7 Then

                Dim colMN As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")
                Dim cant As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("cant")
                Dim colPUMN As Decimal = Math.Round(colMN / cant, 2).ToString("N2")

                Dim colPUME As Decimal = Math.Round(colMN / txtTipoCambio.Value, 2).ToString("N2")
                Dim colME As Decimal = Math.Round(colPUME / cant, 2).ToString("N2")

                Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", colME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPUME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPUMN)


                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If

        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyDown
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            If ColIndex = 1 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 3 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 6 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
        End If
    End Sub

    Private Sub txtSerie_LostFocus1(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'End If
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

    Private Sub txtNumero_KeyDown1(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtProveedor.Select()
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtNumero_LostFocus1(sender As Object, e As EventArgs)
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()
            lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        End Try
    End Sub

    Private Sub txtProveedor_KeyDown_1(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
                'ElseIf chTrab.Checked = True Then
                '    CargarTrabajadoresXnivel(TIPO_ENTIDAD.PERSONA_GENERAL, txtProveedor.Text.Trim)

            ElseIf chCli.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)

            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel(TIPO_ENTIDAD.PERSONA_GENERAL, txtProveedor.Text.Trim)
            End If
        End If
    End Sub
    Public Property txtCuenta As String
    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text

                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick_1(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub chProv_Click_1(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()
    End Sub

    Private Sub chTrab_Click_1(sender As Object, e As EventArgs)
        chProv.Checked = False
        'chTrab.Checked = True
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub txtRuc_KeyDown_1(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If chProv.Checked = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtRuc.Text.Trim.Length > 0 Then
                    UbicarEntidadPorRuc(txtRuc.Text.Trim)
                End If
            End If
          
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Sub updateGlosaAsiento(asiento As asiento)
        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

        Try
            Dim consulta = (From n In ListaAsientonTransito _
                       Where n.idAsiento = asiento.idAsiento).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.glosa = txtGlosaAsiento.Text.Trim
            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        If lstAsiento.SelectedItems.Count > 0 Then
            If txtGlosaAsiento.Text.Trim.Length > 0 Then
                updateGlosaAsiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
                lstAsiento_SelectedIndexChanged(sender, e)
            End If
        Else
            lblEstado.Text = "Debe seleccionar un asiento!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If Not IsNothing(Me.dgvTransferencia.Table.CurrentRecord) Then
            Me.dgvTransferencia.Table.CurrentRecord.Delete()
            TotalesCabeceras()
        End If
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()
    End Sub


    Private Sub CboClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboClasificacion.SelectedIndexChanged
        Productoshijos()
    End Sub

    Private Sub cboProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProductos.SelectedIndexChanged

        Dim codAlmacen = cboAlmacen.SelectedValue
        If IsNumeric(codAlmacen) Then
            ListaMercaderiasXIdHijo(codAlmacen, cboTipoExistencia.SelectedValue, cboProductos.SelectedValue)
        End If

    End Sub


    Private Sub txtProveedor_TextChanged_1(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged
        txtProveedor.ForeColor = Color.Black
        txtProveedor.Tag = Nothing
        txtRuc.ForeColor = Color.Black
        txtRuc.Tag = Nothing
    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlmacen.SelectedIndexChanged
        dgvTransferencia.Table.Records.DeleteAll()
        lsvExistencias.Items.Clear()

        Dim almacenSA As New almacenSA
        Dim codAlmacen As Integer = cboAlmacen.SelectedValue

        If Not IsNothing(cboAlmacen.SelectedValue) Then
            If IsNumeric(codAlmacen) Then

                Dim con = (From n In almacenDestino _
                          Where n.idAlmacen <> codAlmacen).ToList

                cboalmacenDestino.ValueMember = "idAlmacen"
                cboalmacenDestino.DisplayMember = "descripcionAlmacen"
                cboalmacenDestino.DataSource = con
                'cboalmacenDestino.SelectedIndex = -1
            End If
        End If

    End Sub

    Private Sub txtCodBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodBarra.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCodBarra.Text.Trim.Length > 0 Then
                ObtenerListadoByCodigoBarra(CInt(cboAlmacen.SelectedValue), cboTipoExistencia.SelectedValue, txtCodBarra.Text.Trim)
            Else
                MessageBox.Show("Ingrese un codigo de artículo válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCodBarra.SelectAll()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub txtCliente2_TextChanged(sender As Object, e As EventArgs) Handles txtCliente2.TextChanged
        txtCliente2.ForeColor = Color.Black
        txtCliente2.Tag = Nothing
        txtTipoVehiculo.Clear()
        txtMarcaVehiculo.Clear()
        txtPlacaVehiculo.Clear()
        txtPlacaRemolque.Clear()
        txtCertificado.Clear()
        txtBrevete.Clear()
    End Sub


    Private Sub txtCliente2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente2.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.PopupControlContainer3.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer3.Size = New Size(241, 110)
            Me.PopupControlContainer3.ParentControl = Me.txtCliente2
            Me.PopupControlContainer3.ShowPopup(Point.Empty)

            Dim con = (ListadoDestinatarios.Where(Function(s) s.nombreCompleto.StartsWith(txtCliente2.Text))).ToList()

            ListBox2.DataSource = con
            ListBox2.DisplayMember = "nombreCompleto"
            ListBox2.ValueMember = "idEntidad"

            'txtCliente.DataSource = CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente.Text.Trim)
            'txtCliente.DisplayMember = "nombreCompleto"
            'txtCliente.ValueMember = "idEntidad"
        End If
        If e.KeyCode = Keys.Down Then
            Me.PopupControlContainer3.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer3.Size = New Size(241, 110)
            Me.PopupControlContainer3.ParentControl = Me.txtCliente2
            Me.PopupControlContainer3.ShowPopup(Point.Empty)
            txtCliente2.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer3.IsShowing() Then
                Me.PopupControlContainer3.HidePopup(PopupCloseType.Canceled)
            End If
        End If


        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.PopupControlContainer3.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer3.ParentControl = Me.txtCliente2
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer3.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer3.IsShowing() Then
                Me.PopupControlContainer3.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCliente2.Text.Trim.Length > 0 Then
                Me.PopupControlContainer3.ParentControl = Me.txtCliente2
                Me.PopupControlContainer3.ShowPopup(Point.Empty)
                CargarEntidadesXtipoTransporte(TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR, txtCliente2.Text.Trim)
            End If
        End If
    End Sub

    Private Sub PopupControlContainer3_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer3.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If ListBox2.SelectedItems.Count > 0 Then
                txtCliente2.Text = ListBox2.Text
                txtCliente2.Tag = ListBox2.SelectedValue

                Dim con = (ListadoDestinatarios.Where(Function(s) s.idEntidad = CInt(txtCliente2.Tag))).FirstOrDefault()

                If con IsNot Nothing Then
                    txtRuc2.Text = con.nrodoc
                End If
                txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtTipoVehiculo.Clear()
                txtMarcaVehiculo.Clear()
                txtPlacaVehiculo.Clear()
                txtPlacaRemolque.Clear()
                txtCertificado.Clear()
                txtBrevete.Clear()

            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCliente2.Focus()
        End If
    End Sub

    Private Sub ListBox2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox2.MouseDoubleClick
        If ListBox2.SelectedItems.Count > 0 Then
            Me.PopupControlContainer3.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub cboEstablecimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstablecimiento.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor

        Dim value As Object = Me.cboEstablecimiento.SelectedValue

        Dim almacenSA As New almacenSA
        Dim codAlmacen As Integer = cboAlmacen.SelectedValue

        If IsNumeric(value) Then
            cargarDatosCuenta(CInt(value))
        Else

      
            Me.Cursor = Cursors.Arrow

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR
        f.tipoPersona(TIPO_ENTIDAD.CLIENTE, txtRuc.Text)
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            'ListadoProveedores.Add(c)
            txtCliente2.Text = c.nombreCompleto
            txtCliente2.Tag = c.idEntidad
            txtRuc2.Text = c.nrodoc
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtCliente2.Text.Length > 0 And txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)) Then
            Panel5.Visible = True
            txtTipoVehiculo.Select()
            txtNombreConductor.Text = txtCliente2.Text
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel5.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel5.Visible = False
        txtTipoVehiculo.Clear()
        txtMarcaVehiculo.Clear()
        txtPlacaVehiculo.Clear()
        txtPlacaRemolque.Clear()
        txtNombreConductor.Clear()
        txtBrevete.Clear()
        txtCertificado.Clear()
    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chCli.Checked = False
        chTrab.Checked = True
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If chProv.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chCli.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo Cliente"
            f.strTipo = TIPO_ENTIDAD.CLIENTE
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chTrab.Checked = True Then
            Dim f As New frmNuevoTrabajador
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub dgvTransferencia_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvTransferencia.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = dgvTransferencia.TableControl.CurrentCell
        cc.ConfirmChanges()
        Dim colDestinoGravado As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colPM As Decimal = 0
        Dim colPrecUnitUSD As Decimal = 0
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0
        ' Abort validation if cell is not in the CompanyName column.

        Select Case lblMovimiento.Text
            Case "TRANSFERENCIA ENTRE ALMACENES"
                Dim colCant As Decimal = 0
                colCant = CDec(dgvTransferencia.Table.CurrentRecord.GetValue("Can1"))
                'DECLARANDO VARIABLES
                colPrecUnit = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                colPrecUnitUSD = dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")

                '  ValidarCantidad(dgvNuevoDoc.CurrentRow.Index)
                'Valida que la cantidad no este vacia
                If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("Can1")).Trim.Length > 0 Then
                    dgvTransferencia.Table.CurrentRecord.SetValue("Can1", 0)
                    lblEstado.Text = "Ingrese una cantidad válida!"
                    Exit Sub
                End If
                ''Valida que la cantidad sea mayor que cero
                If colCant <= 0 Then
                    dgvTransferencia.Table.CurrentRecord.SetValue("Can1", 0)
                    lblEstado.Text = "Ingrese una cantidad mayor que 0!"
                    Exit Sub
                End If

                'Se valida que no se transfiera una cantidad mayor a la existente
                If colCant > CDec(dgvTransferencia.Table.CurrentRecord.GetValue("colDisponible")) Then
                    Dim title = "Cantidad Incorrecta"
                    Dim msg = "La cantidad a transferir debe ser menor o igual a la cantidad exitente en el almacén"
                    MsgBox(msg, , title)
                    dgvTransferencia.Table.CurrentRecord.SetValue("Can1", 0)
                    'dgvTransferencia.Table.CurrentRecord.SetValue(("Prec"), 0.0)
                    'dgvTransferencia.Table.CurrentRecord.SetValue(("PrecUnitUS"), 0.0)
                    dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteNeto"), 0)
                    dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), 0)

                    e.TableControl.Table.TableDirty = True
                    e.TableControl.Table.EndEdit()
                    e.TableControl.CurrentCell.EndEdit()
                    'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 2, GridSetCurrentCellOptions.SetFocus)
                    Exit Sub
                End If

            Case "OTRAS ENTRADAS DE EXISTENCIAS"
                ''DECLARANDO VARIABLES
                'colPrecUnit = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                'colPrecUnitUSD = Math.Round(colPrecUnit / txtTipoCambio.Value, 2)
                'dgvTransferencia.Table.CurrentRecord.SetValue("PrecUnitUS", colPrecUnitUSD.ToString("N2"))
        End Select

        colDestinoGravado = dgvTransferencia.Table.CurrentRecord.GetValue("Gravado")

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 4 ' cantidad

                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("Can1")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese una cantidad válida!"
                        Exit Sub
                    Else
                        colCantidad = dgvTransferencia.Table.CurrentRecord.GetValue("Can1")
                        colPrecUnit = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                        colPrecUnitUSD = dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")

                        'Se valida que no se transfiera una cantidad mayor a la existente
                        If colCantidad > CDec(dgvTransferencia.Table.CurrentRecord.GetValue("colDisponible")) Then
                            Dim title = "Cantidad Incorrecta"
                            Dim msg = "La cantidad a transferir debe ser menor o igual a la cantidad exitente en el almacén"
                            MsgBox(msg, , title)
                            dgvTransferencia.Table.CurrentRecord.SetValue("Can1", 0)
                            Exit Sub
                        End If



                        colMN = Math.Round(colCantidad * colPrecUnit, 2)
                        colME = Math.Round(colCantidad * colPrecUnitUSD, 2)
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteNeto"), colMN.ToString("N2"))
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))

                        'dgvNuevoDoc.Item(23, dgvNuevoDoc.CurrentRow.Index).Value = colCantidad
                        'dgvNuevoDoc.Item(24, dgvNuevoDoc.CurrentRow.Index).Value = 0
                        'dgvNuevoDoc.Item(25, dgvNuevoDoc.CurrentRow.Index).Value = colCantidad
                    End If
                    TotalesCabeceras()
                Case 8 ' cantidad
                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("Prec")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un precio unitario válida!"
                        Exit Sub
                    Else

                        If CDec(dgvTransferencia.Table.CurrentRecord.GetValue("Prec")) <= 0 Then
                            lblEstado.Text = "Ingrese un precio unitario mayor a cero!"
                            dgvTransferencia.Table.CurrentRecord.SetValue(("Prec"), 0)
                            Exit Sub
                        End If

                        colPM = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                        colMN = Math.Round(CDec(dgvTransferencia.Table.CurrentRecord.GetValue("Can1")) * colPM, 2)
                        colME = 0.0
                        dgvTransferencia.Table.CurrentRecord.SetValue(("PrecUnitUS"), 0.0)
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteNeto"), colMN.ToString("N2"))
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))
                    End If
                    TotalesCabeceras()
                Case 9
                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un precio unitario extranjero válida!"
                        Exit Sub
                    Else
                        Dim colPMExtranjero As Decimal = 0
                        colPMExtranjero = dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")
                        colCantidad = dgvTransferencia.Table.CurrentRecord.GetValue("Can1")
                        colME = CDec(colCantidad) * colPMExtranjero
                        'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value = 0.0
                        'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = colMN.ToString("N2")
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))
                    End If
                    TotalesCabeceras()
            End Select

        End If
    End Sub

    Private Sub txtFechaComprobante_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaComprobante.ValueChanged
        If IsDate(txtFechaComprobante.Value) Then
            If txtFechaComprobante.Value.Date > DiaLaboral.Date Then
                txtFechaComprobante.Value = DiaLaboral
                MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If (cboTipoDoc.Text = "VOUCHER CONTABLE") Then
            PNSerieNro.Visible = False
        ElseIf (cboTipoDoc.Text = "GUIA DE REMISION") Then
            PNSerieNro.Visible = True
        End If
    End Sub

    Private Sub dgvTransferencia_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvTransferencia.TableControlKeyDown
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = dgvTransferencia.TableControl.CurrentCell
        cc.ConfirmChanges()
        Dim colDestinoGravado As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colPM As Decimal = 0
        Dim colPrecUnitUSD As Decimal = 0
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0
        ' Abort validation if cell is not in the CompanyName column.

        colDestinoGravado = dgvTransferencia.Table.CurrentRecord.GetValue("Gravado")

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 4 ' cantidad

                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("Can1")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese una cantidad válida!"
                        Exit Sub
                    Else
                        colCantidad = dgvTransferencia.Table.CurrentRecord.GetValue("Can1")
                        colPrecUnit = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                        colPrecUnitUSD = dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")

                        colMN = Math.Round(colCantidad * colPrecUnit, 2)
                        colME = Math.Round(colCantidad * colPrecUnitUSD, 2)
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteNeto"), colMN.ToString("N2"))
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))

                    End If
                    TotalesCabeceras()
                Case 8 ' cantidad
                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("Prec")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un precio unitario válida!"
                        Exit Sub
                    Else

                        If CDec(dgvTransferencia.Table.CurrentRecord.GetValue("Prec")) <= 0 Then
                            lblEstado.Text = "Ingrese un precio unitario mayor a cero!"
                            dgvTransferencia.Table.CurrentRecord.SetValue(("Prec"), 0)
                            Exit Sub
                        End If

                        colPM = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                        colMN = Math.Round(CDec(dgvTransferencia.Table.CurrentRecord.GetValue("Can1")) * colPM, 2)
                        colME = 0.0
                        dgvTransferencia.Table.CurrentRecord.SetValue(("PrecUnitUS"), 0.0)
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteNeto"), colMN.ToString("N2"))
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))
                    End If
                    TotalesCabeceras()
                Case 9
                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un precio unitario extranjero válida!"
                        Exit Sub
                    Else
                        Dim colPMExtranjero As Decimal = 0
                        colPMExtranjero = dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")
                        colCantidad = dgvTransferencia.Table.CurrentRecord.GetValue("Can1")
                        colME = CDec(colCantidad) * colPMExtranjero
                        'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value = 0.0
                        'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = colMN.ToString("N2")
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))
                    End If
                    TotalesCabeceras()
            End Select

        End If
    End Sub

    Private Sub dgvTransferencia_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvTransferencia.TableControlKeyPress
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = dgvTransferencia.TableControl.CurrentCell
        cc.ConfirmChanges()
        Dim colDestinoGravado As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colPM As Decimal = 0
        Dim colPrecUnitUSD As Decimal = 0
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0
        ' Abort validation if cell is not in the CompanyName column.

        colDestinoGravado = dgvTransferencia.Table.CurrentRecord.GetValue("Gravado")

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 4 ' cantidad

                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("Can1")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese una cantidad válida!"
                        Exit Sub
                    Else
                        colCantidad = dgvTransferencia.Table.CurrentRecord.GetValue("Can1")
                        colPrecUnit = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                        colPrecUnitUSD = dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")
                        colMN = Math.Round(colCantidad * colPrecUnit, 2)
                        colME = Math.Round(colCantidad * colPrecUnitUSD, 2)
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteNeto"), colMN.ToString("N2"))
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))

                    End If
                    TotalesCabeceras()
                Case 8 ' cantidad
                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("Prec")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un precio unitario válida!"
                        Exit Sub
                    Else

                        If CDec(dgvTransferencia.Table.CurrentRecord.GetValue("Prec")) <= 0 Then
                            lblEstado.Text = "Ingrese un precio unitario mayor a cero!"
                            dgvTransferencia.Table.CurrentRecord.SetValue(("Prec"), 0)
                            Exit Sub
                        End If

                        colPM = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                        colMN = Math.Round(CDec(dgvTransferencia.Table.CurrentRecord.GetValue("Can1")) * colPM, 2)
                        colME = 0.0
                        dgvTransferencia.Table.CurrentRecord.SetValue(("PrecUnitUS"), 0.0)
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteNeto"), colMN.ToString("N2"))
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))
                    End If
                    TotalesCabeceras()
                Case 9
                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un precio unitario extranjero válida!"
                        Exit Sub
                    Else
                        Dim colPMExtranjero As Decimal = 0
                        colPMExtranjero = dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")
                        colCantidad = dgvTransferencia.Table.CurrentRecord.GetValue("Can1")
                        colME = CDec(colCantidad) * colPMExtranjero
                        'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value = 0.0
                        'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = colMN.ToString("N2")
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))
                    End If
                    TotalesCabeceras()
            End Select

        End If
    End Sub

    Private Sub dgvTransferencia_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvTransferencia.TableControlKeyUp
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = dgvTransferencia.TableControl.CurrentCell
        cc.ConfirmChanges()
        Dim colDestinoGravado As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colPM As Decimal = 0
        Dim colPrecUnitUSD As Decimal = 0
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0
        ' Abort validation if cell is not in the CompanyName column.

        colDestinoGravado = dgvTransferencia.Table.CurrentRecord.GetValue("Gravado")

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 4 ' cantidad

                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("Can1")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese una cantidad válida!"
                        Exit Sub
                    Else
                        colCantidad = dgvTransferencia.Table.CurrentRecord.GetValue("Can1")
                        colPrecUnit = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                        colPrecUnitUSD = dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")



                        colMN = Math.Round(colCantidad * colPrecUnit, 2)
                        colME = Math.Round(colCantidad * colPrecUnitUSD, 2)
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteNeto"), colMN.ToString("N2"))
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))

                    End If
                    TotalesCabeceras()
                Case 8 ' cantidad
                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("Prec")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un precio unitario válida!"
                        Exit Sub
                    Else

                        If CDec(dgvTransferencia.Table.CurrentRecord.GetValue("Prec")) <= 0 Then
                            lblEstado.Text = "Ingrese un precio unitario mayor a cero!"
                            dgvTransferencia.Table.CurrentRecord.SetValue(("Prec"), 0)
                            Exit Sub
                        End If

                        colPM = dgvTransferencia.Table.CurrentRecord.GetValue("Prec")
                        colMN = Math.Round(CDec(dgvTransferencia.Table.CurrentRecord.GetValue("Can1")) * colPM, 2)
                        colME = 0.0
                        dgvTransferencia.Table.CurrentRecord.SetValue(("PrecUnitUS"), 0.0)
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteNeto"), colMN.ToString("N2"))
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))
                    End If
                    TotalesCabeceras()
                Case 9
                    If Not CStr(dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese un precio unitario extranjero válida!"
                        Exit Sub
                    Else
                        Dim colPMExtranjero As Decimal = 0
                        colPMExtranjero = dgvTransferencia.Table.CurrentRecord.GetValue("PrecUnitUS")
                        colCantidad = dgvTransferencia.Table.CurrentRecord.GetValue("Can1")
                        colME = CDec(colCantidad) * colPMExtranjero
                        'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value = 0.0
                        'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = colMN.ToString("N2")
                        dgvTransferencia.Table.CurrentRecord.SetValue(("ImporteUS"), colME.ToString("N2"))
                    End If
                    TotalesCabeceras()
            End Select

        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

        Dim f As New frmSelectCosto()
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, SeleccionCosto)
            'r.SetValue("idSubProyecto", c.idSubProyecto)
            'r.SetValue("Subproyecto", c.SubProyecto)
            'r.SetValue("idEDT", c.idEntregable)
            'r.SetValue("edt", c.Entregable)
            'r.SetValue("idCosto", c.idProyectoGeneral)
            'r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
            'r.SetValue("tipoCosto", c.TipoCosto)
            'r.SetValue("idElemento", c.idElemento)
            'r.SetValue("Elemento", c.ElementoCosto)
            'r.SetValue("abrev", c.Abreviatura)
            'r.SetValue("fechaTrabajo", c.fechaTrabajo)
            txtEntregable.Text = c.Entregable
            txtidEntregable.Text = c.idEntregable
        End If

    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub lsvExistencias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvExistencias.SelectedIndexChanged

    End Sub


#End Region
End Class