
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel

Public Class frmAsignaCajaUser
    Inherits frmMaster
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property strButton As String = "b1"

    Private idCajaUsuario As Integer = 0

    Public strEstadoManipulacion As String
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DockingClientPanel1.Visible = False
        configDockingManger()
        ObtenerCuentasFinancierasPorMoneda("1")
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        COntrolesLOAd()
        lblPerido.Text = "Período: " & PeriodoGeneral
        txtFechaComprobante.Value = Date.Now
        dgvUsers.DataSource = GetTableGrid()

        'txtClave.PasswordChar = "*"
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
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

        If keyData = Keys.Tab AndAlso txtFiltro.Focused Then
            '  MessageBox.Show("Tab pressed")
            Return True
        End If

        If keyData = (Keys.Tab Or Keys.Shift) AndAlso txtFiltro.Focused Then
            '  MessageBox.Show("Shift-Tab pressed")
            Return True
        End If

        Return baseResult
    End Function

    Private Function GeneraraAsiento() As asiento
        Dim nAsiento As New asiento
        Dim movimiento As movimiento
        Try
            nAsiento = New asiento
            nAsiento.idDocumento = 0
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = txtPersona.ValueMember
            nAsiento.nombreEntidad = txtPersona.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
            nAsiento.fechaProceso = txtFechaComprobante.Value
            nAsiento.codigoLibro = "1"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
            nAsiento.importeMN = txtFondoMN.Value
            nAsiento.importeME = txtFondoME.Value
            nAsiento.glosa = Glosa()
            nAsiento.usuarioActualizacion = "jiuni"
            nAsiento.fechaActualizacion = DateTime.Now


            movimiento = New movimiento With {
                  .cuenta = txtCuentaOrigen.Text,
                  .descripcion = txtCajaOrigen.Text,
                  .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
                  .monto = txtFondoMN.Value,
                  .montoUSD = txtFondoME.Value,
                  .fechaActualizacion = DateTime.Now,
                  .usuarioActualizacion = "Jiuni"}
            nAsiento.movimiento.Add(movimiento)

            movimiento = New movimiento With {
                .cuenta = txtCuentaDestino.Text,
                .descripcion = txtCajaDestino.Text,
                .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
                .monto = txtFondoMN.Value,
                .montoUSD = txtFondoME.Value,
                .fechaActualizacion = DateTime.Now,
                .usuarioActualizacion = "Jiuni"}
            nAsiento.movimiento.Add(movimiento)


        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
        Return nAsiento
    End Function

#Region "Métodos"

    Public Sub UbicarCajasHijas(iNtIdPadre As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim DT As New DataTable()

        DT.Columns.Add("id")
        DT.Columns.Add("Usuario")
        DT.Columns.Add("importeInicio")

        For Each i In cajaUsuarioSA.UbicarCajasHijasXpadre(iNtIdPadre)
            Dim dr As DataRow = DT.NewRow()
            dr(0) = i.idcajaUsuario
            dr(1) = i.idPersona
            dr(2) = i.fondoMN
            DT.Rows.Add(dr)
        Next

        dgvUsers.DataSource = DT
    End Sub


    Private Function GetTableGrid() As DataTable

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Usuario", GetType(String))
        dt.Columns.Add("importeInicio", GetType(Decimal))

        Return dt
    End Function

    Private comboTable As DataTable
    Public Function GetTableAlmacen() As DataTable
        Dim PersonaSA As New PersonaSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))

        For Each i In PersonaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idPersona
            dr(1) = i.nombreCompleto
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Sub calculos()

        If txtTipoCambio.Value > 0 Then
            txtFondoME.Value = Math.Round(txtFondoMN.Value / txtTipoCambio.Value, 2)
        Else

        End If


    End Sub

    'Public Sub ObtenerPersonasStarWidth(strTexto As String)
    '    Dim personaSA As New PersonaSA

    '    lstPersonas.DisplayMember = "nombreCompleto"
    '    lstPersonas.ValueMember = "idPersona"
    '    lstPersonas.DataSource = personaSA.ObtenerPersonaPorNombres(Gempresas.IdEmpresaRuc, strTexto)
    'End Sub

    Sub COntrolesLOAd()
        Dim tablaSA As New tablaDetalleSA
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")
    End Sub



    Private Sub ObtenerCuentasFinancierasPorMoneda(strIdMoneda As String)
        Dim cFinancieraSA As New EstadosFinancierosSA
        gridGroupingControl1.DataSource = cFinancieraSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, strIdMoneda)
        gridGroupingControl1.TableDescriptor.GroupedColumns.Add("tipo")
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
        Try
            With personaBE
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idPersona = txtDniTrab.Text.Trim
                .nombres = txtNombreTrab.Text.Trim
                .appat = txtAppatTrab.Text.Trim
                .apmat = txtApmatTrab.Text.Trim
                .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
            End With
            personaSA.InsertPersona(personaBE)
            txtPersona.ValueMember = personaBE.idPersona
            txtPersona.Text = personaBE.nombreCompleto
            txtDni.Text = personaBE.idPersona
            ObtenerPersonaPorNombre(CStr(personaBE.nombreCompleto))
        Catch ex As Exception
            MessageBoxAdv.Show("La persona ingresada ya se encuntra en la base de datos!")
        End Try

        '   lstPersonas.Items.Add(New Personal(personaBE.nombreCompleto, personaBE.idPersona))
    End Sub

    Public Sub ObtenerCajaUser(intIdCaja As Integer)
        Dim cajaUsuariosBL As New cajaUsuarioSA
        Dim cajaUser As New cajaUsuario

        cajaUser = cajaUsuariosBL.ObtenerCajaUser(intIdCaja)

        idCajaUsuario = cajaUser.idcajaUsuario
        lblIdDocumento.Text = cajaUser.IdDocumentoVenta
        txtFechaComprobante.Value = cajaUser.fechaRegistro
        txtPersona.ValueMember = cajaUser.idPersona
        txtPersona.Text = cajaUser.NombrePersona
        txtDni.Text = cajaUser.idPersona
        txtFondoMN.Value = cajaUser.fondoMN
        txtTipoCambio.Value = cajaUser.tipoCambio
        txtFondoME.Value = cajaUser.fondoME
        ' txtClave.Text = cajaUser.claveIngreso
        txtCajaOrigen.Text = cajaUser.NombreCajaOrigen
        txtCajaOrigen.ValueMember = cajaUser.idCajaOrigen
        txtCuentaOrigen.Text = cajaUser.cuentaCajaOrigen
        txtCajaDestino.Text = cajaUser.NombreCajaDestino
        txtCajaDestino.ValueMember = cajaUser.idCajaDestino
        txtCuentaDestino.Text = cajaUser.CuentaCajaDestino



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

#Region "CONFIGURACION DOCKING CONTROL"
    Sub configDockingManger()
        '     Me.DockingManager1.DockControl(Me.PanelEstadosFinancieros, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 318)
        Me.dockingManager1.DockControl(Me.PanelUsuarios, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Top, 97)
        '      DockingManager1.SetDockLabel(PanelEstadosFinancieros, "Cuentas")
        dockingManager1.SetDockLabel(PanelUsuarios, "Seleccionar Usuario")
        dockingManager1.CloseEnabled = False
    End Sub
#End Region

#Region "Manipulación data"
    Public Function Glosa() As String
        Return "Por Apertura de caja al usuario: " & txtPersona.Text.Trim
    End Function
    Dim statusForm As New frmMensajeCodigoVenta
    Public Sub Grabar()
        Dim cajaSA As New cajaUsuarioSA
        Dim objCaja As New cajaUsuario

        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)


        Dim ListaSubUsers As New List(Of cajaUsuario)
        Dim SubUsers As New cajaUsuario


        ListaSubUsers = New List(Of cajaUsuario)
        For Each r As Record In dgvUsers.Table.Records
            SubUsers = New cajaUsuario
            'objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            'objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            'objDocumentoCompraDet.modulo = r.GetValue("tipoEx")
            'objDocumentoCompraDet.idModulo = r.GetValue("idModulo")
            'objDocumentoCompraDet.descripcionItem = r.GetValue("cuenta")
            'objDocumentoCompraDet.TipoDoc = "9901"

            SubUsers.idEmpresa = Gempresas.IdEmpresaRuc
            SubUsers.idEstablecimiento = GEstableciento.IdEstablecimiento
            SubUsers.periodo = PeriodoGeneral
            SubUsers.idPersona = r.GetValue("Usuario")
            SubUsers.idCajaOrigen = txtCajaOrigen.ValueMember
            SubUsers.idCajaDestino = txtCajaDestino.ValueMember
            SubUsers.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            SubUsers.tipoCambio = txtTipoCambio.Value
            SubUsers.fechaRegistro = txtFechaComprobante.Value
            SubUsers.fondoMN = r.GetValue("importeInicio")
            SubUsers.fondoME = Math.Round(CDec(r.GetValue("importeInicio")) / txtTipoCambio.Value, 2)
            SubUsers.claveIngreso = r.GetValue("Usuario")
            SubUsers.ingresoAdicMN = 0
            SubUsers.ingresoAdicME = 0
            SubUsers.otrosIngresosMN = 0
            SubUsers.otrosIngresosME = 0
            SubUsers.otrosEgresosMN = 0
            SubUsers.otrosEgresosME = 0
            SubUsers.estadoCaja = "A"
            SubUsers.enUso = "N"
            SubUsers.usuarioActualizacion = "Jiuni"
            SubUsers.fechaActualizacion = DateTime.Now
            ListaSubUsers.Add(SubUsers)
        Next


        ListaAsientonTransito = New List(Of asiento)
        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9903"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = 0 ' txtNumeroComp.Text
            .idOrden = Nothing
            .tipoOperacion = "01"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            '   .idDocumento = lblIdDocumento.Text
            .periodo = PeriodoGeneral
            .codigoLibro = "105"
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = "VOCJ"
            .codigoProveedor = txtPersona.ValueMember
            .fechaProceso = txtFechaComprobante.Value
            .fechaCobro = txtFechaComprobante.Value
            .tipoDocPago = "9903"
            .numeroDoc = 0 ' txtNumeroComp.Text
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .entidadFinanciera = txtCajaOrigen.ValueMember
            .entidadFinancieraDestino = txtCajaDestino.ValueMember
            .numeroOperacion = "00001" 'txtNumeroComp.Text
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtFondoMN.Value
            .montoUsd = txtFondoME.Value

            .glosa = Glosa()
            .entregado = "SI"
            .usuarioModificacion = "Jiuni"
            .fechaModificacion = DateTime.Now
        End With
        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.fecha = txtFechaComprobante.Value
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = "POR APERTURA DE CAJA"
        ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
        ndocumentoCajaDetalle.montoUsd = txtFondoME.Value

        ndocumentoCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0

        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.usuarioModificacion = "Jiuni"
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
        ListaAsientonTransito.Add(GeneraraAsiento)
        ndocumento.asiento = ListaAsientonTransito
        With objCaja
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .periodo = PeriodoGeneral
            .idPersona = txtPersona.ValueMember
            .idCajaOrigen = txtCajaOrigen.ValueMember
            .idCajaDestino = txtCajaDestino.ValueMember
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tipoCambio = txtTipoCambio.Value
            .fechaRegistro = txtFechaComprobante.Value
            .fondoMN = txtFondoMN.Value
            .fondoME = txtFondoME.Value
            '.claveIngreso = txtClave.Text.Trim
            .ingresoAdicMN = 0
            .ingresoAdicME = 0
            .otrosIngresosMN = 0
            .otrosIngresosME = 0
            .otrosEgresosMN = 0
            .otrosEgresosME = 0
            .estadoCaja = "A"
            .enUso = "N"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        'statusForm.StartPosition = FormStartPosition.CenterScreen
        'statusForm.Show()
        Dim codigoUsuarioClave = documentoCajaSA.SaveGroupCajaApertura(ndocumento, objCaja, ListaSubUsers)
        lblEstado.Text = "Caja registrada correctamente!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)


        'statusForm.lblMensaje.Text = "..estableciendo..."
        'TimerMesj.Enabled = True

        'statusForm.lblMensaje.Text = codigoUsuarioClave '.Replace("0", "")

        Dispose()
    End Sub

    Public Sub UpdateCaja()
        Dim cajaSA As New cajaUsuarioSA
        Dim objCaja As New cajaUsuario

        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        Dim ListaSubUsers As New List(Of cajaUsuario)
        Dim SubUsers As New cajaUsuario


        ListaSubUsers = New List(Of cajaUsuario)
        For Each r As Record In dgvUsers.Table.Records
            SubUsers = New cajaUsuario
            'objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            'objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            'objDocumentoCompraDet.modulo = r.GetValue("tipoEx")
            'objDocumentoCompraDet.idModulo = r.GetValue("idModulo")
            'objDocumentoCompraDet.descripcionItem = r.GetValue("cuenta")
            'objDocumentoCompraDet.TipoDoc = "9901"

            SubUsers.idEmpresa = Gempresas.IdEmpresaRuc
            SubUsers.idEstablecimiento = GEstableciento.IdEstablecimiento
            SubUsers.periodo = PeriodoGeneral
            SubUsers.idcajaUsuario = r.GetValue("id")
            SubUsers.idPersona = r.GetValue("Usuario")
            SubUsers.idCajaOrigen = txtCajaOrigen.ValueMember
            SubUsers.idCajaDestino = txtCajaDestino.ValueMember
            SubUsers.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            SubUsers.tipoCambio = txtTipoCambio.Value
            SubUsers.fechaRegistro = txtFechaComprobante.Value
            SubUsers.fondoMN = CDec(r.GetValue("importeInicio"))
            SubUsers.fondoME = Math.Round(CDec(r.GetValue("importeInicio")) / txtTipoCambio.Value, 2)
            ' SubUsers.claveIngreso = txtClave.Text.Trim
            SubUsers.ingresoAdicMN = 0
            SubUsers.ingresoAdicME = 0
            SubUsers.otrosIngresosMN = 0
            SubUsers.otrosIngresosME = 0
            SubUsers.otrosEgresosMN = 0
            SubUsers.otrosEgresosME = 0
            SubUsers.estadoCaja = "A"
            SubUsers.enUso = "N"
            SubUsers.usuarioActualizacion = "Jiuni"
            SubUsers.fechaActualizacion = DateTime.Now
            ListaSubUsers.Add(SubUsers)
        Next



        ListaAsientonTransito = New List(Of asiento)
        With ndocumento
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = "9903"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = 0 ' txtNumeroComp.Text
            .idOrden = Nothing
            .tipoOperacion = "01"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .periodo = PeriodoGeneral
            .codigoLibro = "105"
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = "VOCJ"
            .codigoProveedor = txtPersona.ValueMember
            .fechaProceso = txtFechaComprobante.Value
            .fechaCobro = txtFechaComprobante.Value
            .tipoDocPago = "9903"
            .numeroDoc = 0 ' txtNumeroComp.Text
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .entidadFinanciera = txtCajaOrigen.ValueMember
            .entidadFinancieraDestino = txtCajaDestino.ValueMember
            .numeroOperacion = "00001" 'txtNumeroComp.Text
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtFondoMN.Value
            .montoUsd = txtFondoME.Value

            .glosa = Glosa()
            .entregado = "SI"
            .usuarioModificacion = "Jiuni"
            .fechaModificacion = DateTime.Now
        End With
        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.fecha = txtFechaComprobante.Value
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = "POR APERTURA DE CAJA"
        ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
        ndocumentoCajaDetalle.montoUsd = txtFondoME.Value

        ndocumentoCajaDetalle.entregado = "SI"

        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.usuarioModificacion = "Jiuni"
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
        ListaAsientonTransito.Add(GeneraraAsiento)
        ndocumento.asiento = ListaAsientonTransito
        With objCaja
            .idcajaUsuario = idCajaUsuario
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .periodo = PeriodoGeneral
            .idPersona = txtPersona.ValueMember
            .idCajaOrigen = txtCajaOrigen.ValueMember
            .idCajaDestino = txtCajaDestino.ValueMember
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tipoCambio = txtTipoCambio.Value
            .fechaRegistro = txtFechaComprobante.Value
            .fondoMN = txtFondoMN.Value
            .fondoME = txtFondoME.Value
            '.claveIngreso = txtClave.Text.Trim
            .ingresoAdicMN = 0
            .ingresoAdicME = 0
            .otrosIngresosMN = 0
            .otrosIngresosME = 0
            .otrosEgresosMN = 0
            .otrosEgresosME = 0
            .estadoCaja = "A"
            .enUso = "N"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        documentoCajaSA.UpdateGroupCajaApertura(ndocumento, objCaja, ListaSubUsers)
        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub


    Public Sub ConfigModulo()
        DockingClientPanel1.Visible = True
        dockingManager1.SetDockVisibility(PanelUsuarios, False)
    End Sub

#End Region

    Private Sub frmAsignaCajaUser_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAsignaCajaUser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        gridGroupingControl1.TableDescriptor.Relations.Clear()
        gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        gridGroupingControl1.Appearance.AnyRecordFieldCell.Enabled = False
        gridGroupingControl1.GroupDropPanel.Visible = False
        txtFiltro.Focus()
        txtFiltro.Select()

        comboTable = Me.GetTableAlmacen
        Dim ggcStyle As GridTableCellStyleInfo = dgvUsers.TableDescriptor.Columns(1).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"

        dgvUsers.ActivateCurrentCellBehavior = Grid.GridCellActivateAction.DblClickOnCell
    End Sub

    Private Sub NumericUpDownExt2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFondoME.ValueChanged

    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltro.Text.Trim.Length > 0 Then
                ObtenerPersonaPorNombre(txtFiltro.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
                If strButton = "b1" Then
                    Me.txtCajaOrigen.ValueMember = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idestado")
                    Me.txtCajaOrigen.Text = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion")
                    txtCuentaOrigen.Text = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cuenta")
                ElseIf strButton = "b2" Then
                    Me.txtCajaDestino.ValueMember = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idestado")
                    Me.txtCajaDestino.Text = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion")
                    txtCuentaDestino.Text = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cuenta")
                End If
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCuentaOrigen.Focus()
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlCellDoubleClick(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellDoubleClick
        If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
            Me.pcAlmacen.HidePopup(PopupCloseType.Done)
        Else

            If strButton = "b1" Then
                pcAlmacen.Font = New Font("Tahoma", 8)
                pcAlmacen.Size = New Size(357, 249)
                Me.pcAlmacen.ParentControl = Me.txtCajaOrigen
                Me.pcAlmacen.ShowPopup(Point.Empty)
            ElseIf strButton = "b2" Then
                pcAlmacen.Font = New Font("Tahoma", 8)
                pcAlmacen.Size = New Size(357, 249)
                Me.pcAlmacen.ParentControl = Me.txtCajaDestino
                Me.pcAlmacen.ShowPopup(Point.Empty)
            End If

        End If

    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(357, 249)
        strButton = "b1"
        Me.pcAlmacen.ParentControl = Me.txtCajaOrigen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub lstPersonas_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstPersonas.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If lstPersonas.SelectedItems.Count > 0 Then
            txtPersona.Text = DirectCast(Me.lstPersonas.SelectedItem, Personal).Name
            txtPersona.ValueMember = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
            txtDni.Text = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
            DockingClientPanel1.Visible = True
            dockingManager1.SetDockVisibility(PanelUsuarios, False)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstPersonas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstPersonas.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub ButtonAdv2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv2.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(357, 249)
        strButton = "b2"
        Me.pcAlmacen.ParentControl = Me.txtCajaDestino
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub txtFondoMN_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFondoMN.ValueChanged
        calculos()

        If dgvUsers.Table.Records IsNot Nothing AndAlso dgvUsers.Table.Records.Count > 0 Then

            For Each r As Record In dgvUsers.Table.Records

                r.SetValue("importeInicio", 0.0)

            Next
        End If


    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        calculos()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click

    End Sub

    Private Sub btnGrabTRab_Click(sender As Object, e As EventArgs) Handles btnGrabTRab.Click
        If Not txtDniTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtFiltro
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtDniTrab.Select()
            Exit Sub
        End If

        If Not txtNombreTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtFiltro
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtNombreTrab.Select()
            Exit Sub
        End If

        If Not txtAppatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtFiltro
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtAppatTrab.Select()
            Exit Sub
        End If

        If Not txtApmatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtFiltro
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
                Me.pcTrabajador.ParentControl = Me.txtFiltro
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtDniTrab.Select()
                Exit Sub
            End If

            If Not txtNombreTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtFiltro
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtNombreTrab.Select()
                Exit Sub
            End If

            If Not txtAppatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtFiltro
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtAppatTrab.Select()
                Exit Sub
            End If

            If Not txtApmatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtFiltro
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
                Me.pcTrabajador.ParentControl = Me.txtFiltro
                Me.pcTrabajador.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtFiltro.Focus()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        pcTrabajador.Font = New Font("Segoe UI", 8)
        pcTrabajador.Size = New Size(327, 250)
        Me.pcTrabajador.ParentControl = Me.txtFiltro
        Me.pcTrabajador.ShowPopup(Point.Empty)
    End Sub

    Private Sub txtDniTrab_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDniTrab.KeyDown
        'pcTrabajador.Font = New Font("Segoe UI", 8)
        'pcTrabajador.Size = New Size(327, 250)
        'Me.pcTrabajador.ParentControl = Me.txtFiltro
        'Me.pcTrabajador.ShowPopup(Point.Empty)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNombreTrab.Focus()
            txtNombreTrab.Select()
        End If
    End Sub

    Private Sub txtDniTrab_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDniTrab.TextChanged

    End Sub

    Private Sub txtNombreTrab_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNombreTrab.KeyDown
        'pcTrabajador.Font = New Font("Segoe UI", 8)
        'pcTrabajador.Size = New Size(327, 250)
        'Me.pcTrabajador.ParentControl = Me.txtFiltro
        'Me.pcTrabajador.ShowPopup(Point.Empty)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtAppatTrab.Focus()
            txtAppatTrab.Select()
        End If
    End Sub

    Private Sub txtNombreTrab_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombreTrab.TextChanged

    End Sub

    Private Sub txtAppatTrab_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAppatTrab.KeyDown
        'pcTrabajador.Font = New Font("Segoe UI", 8)
        'pcTrabajador.Size = New Size(327, 250)
        'Me.pcTrabajador.ParentControl = Me.txtFiltro
        'Me.pcTrabajador.ShowPopup(Point.Empty)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtApmatTrab.Focus()
            txtApmatTrab.Select()
        End If
    End Sub

    Private Sub txtFondoMN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFondoMN.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtClave.Select()

            If dgvUsers.Table.Records IsNot Nothing AndAlso dgvUsers.Table.Records.Count > 0 Then

                For Each r As Record In dgvUsers.Table.Records

                    r.SetValue("importeInicio", 0.0)
                Next
            End If


        End If
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtFondoMN.Focus()
            txtFondoMN.Select(0, txtFondoMN.Text.Length)
        End If
    End Sub


    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            '' If dgvUsers.Table.Records IsNot Nothing AndAlso dgvUsers.Table.Records.Count > 0 Then
            ''If Me.dgvUsers.Table.CurrentRecord.GetValue("importeInicio") <= txtFondoMN.Value Then
            'Dim monto As Decimal
            'For Each r As Record In dgvUsers.Table.Records
            '    monto += r.GetValue("importeInicio")
            'Next
            'If Not txtFondoMN.Value >= monto Then
            '    'Else
            '    lblEstado.Text = "Debe ingresar menor o igual al Monto ME"
            '    'Me.dgvUsers.Table.CurrentRecord.SetValue("importeInicio", 0.0)
            '    PanelError.Visible = True
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            'End If
            ''Else
            ''    lblEstado.Text = "Debe ingresar menor o igual al Monto ME"
            ''    ' Me.dgvUsers.Table.CurrentRecord.SetValue("importeInicio", 0.0)
            ''    PanelError.Visible = True
            ''    Timer1.Enabled = True
            ''    TiempoEjecutar(10)
            ''End If
            '' End If



            If Not txtCajaOrigen.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese una caja de origen válida!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                '    lblEstado.Image = My.Resources.warning2
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If Not txtPersona.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un personal!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                '  lblEstado.Image = My.Resources.warning2
                txtPersona.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtFondoMN.Value > 0 Then
                lblEstado.Text = "Ingrese un fondo mayor a cero!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                '    lblEstado.Image = My.Resources.warning2
                txtFondoMN.Select(0, txtFondoMN.Text.Length)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If



            Dim monto As Decimal
            For Each r As Record In dgvUsers.Table.Records
                monto += r.GetValue("importeInicio")
            Next
            If Not txtFondoMN.Value >= monto Then
                'Else
                lblEstado.Text = "Debe ingresar menor o igual al Monto ME"
                'Me.dgvUsers.Table.CurrentRecord.SetValue("importeInicio", 0.0)
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If





            'If Not txtClave.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingrese una contraseña valida!"
            '    PanelError.Visible = True
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            '    '   lblEstado.Image = My.Resources.warning2
            '    txtClave.Select()
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If
            If strEstadoManipulacion = ENTITY_ACTIONS.INSERT Then
                lblEstado.Text = "Proceso normal"

                '    lblEstado.Image = My.Resources.ok4
                Grabar()
            Else
                UpdateCaja()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
            Me.Cursor = Cursors.Arrow
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        dockingManager1.SetDockVisibility(PanelUsuarios, True)
        dockingManager1.DockControlInAutoHideMode(PanelUsuarios, Tools.DockingStyle.Top, 97)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.dgvUsers.Table.AddNewRecord.SetCurrent()
        Me.dgvUsers.Table.AddNewRecord.BeginEdit()
        Me.dgvUsers.Table.CurrentRecord.SetValue("id", 0)

        ' Me.dgvUsers.Table.CurrentRecord.SetValue("usuario", 0)

        '    Me.dgvUsers.Table.CurrentRecord.SetValue("Usuario", lsvMercaderia.SelectedItems(0).SubItems(0).Text)
        Me.dgvUsers.Table.CurrentRecord.SetValue("importeInicio", 0.0)
        Me.dgvUsers.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If Not IsNothing(Me.dgvUsers.Table.CurrentRecord) Then
            Me.dgvUsers.Table.CurrentRecord.Delete()
        End If
    End Sub
    Dim time As Integer = 0

    'Private Sub TimerMesj_Tick(sender As Object, e As EventArgs) Handles TimerMesj.Tick
    '    time += 1000
    '    If time = 1000 Then

    '    End If

    '    If time >= 4000 Then
    '        Timer3.Stop()
    '        statusForm.Dispose()
    '        Dispose()
    '    Else

    '    End If
    'End Sub



    Private Sub ToolStrip5_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip5.ItemClicked

    End Sub

    Private Sub dgvUsers_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvUsers.TableControlCurrentCellKeyDown

        If Not IsDBNull(Me.dgvUsers.Table.CurrentRecord.GetValue("Usuario")) Then
            Dim igual As String
            igual = Me.dgvUsers.Table.CurrentRecord.GetValue("Usuario")
            Dim conteo As Integer
            conteo = 1
            For Each r As Record In dgvUsers.Table.Records

                If r.GetValue("Usuario") = igual Then
                    conteo += conteo
                End If
            Next
            If conteo = 2 Then

            ElseIf conteo > 2 Then
                Me.dgvUsers.Table.CurrentRecord.SetValue("Usuario", 0)
                lblEstado.Text = "No debe ingrese 2 usuarios iguales"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If


            Dim a As Integer
            a = Me.dgvUsers.Table.CurrentRecord.GetValue("Usuario")
            Dim caja As New cajaUsuarioSA
            Dim cajadet As New cajaUsuario
            Try
                cajadet = caja.UbicarUsuarioAbierto(a)
                If cajadet.idcajaUsuario > 0 Then
                    Me.dgvUsers.Table.CurrentRecord.SetValue("Usuario", 0)
                    lblEstado.Text = "Seleccione otro usuario este se encuentra activo"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    'ulti
                End If
            Catch
            End Try
        Else
            lblEstado.Text = "Seleccione un usuario"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If



        If dgvUsers.Table.Records IsNot Nothing AndAlso dgvUsers.Table.Records.Count > 0 Then


            If Me.dgvUsers.Table.CurrentRecord.GetValue("importeInicio") <= txtFondoMN.Value Then
                Dim monto As Decimal
                For Each r As Record In dgvUsers.Table.Records
                    monto += r.GetValue("importeInicio")
                Next
                If txtFondoMN.Value >= monto Then
                Else
                    lblEstado.Text = "Debe ingresar menor o igual al Monto ME"
                    Me.dgvUsers.Table.CurrentRecord.SetValue("importeInicio", 0.0)
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            Else
                lblEstado.Text = "Debe ingresar menor o igual al Monto ME"
                Me.dgvUsers.Table.CurrentRecord.SetValue("importeInicio", 0.0)
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        End If

    End Sub

    Private Sub dgvUsers_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvUsers.TableControlCellClick

    End Sub
End Class