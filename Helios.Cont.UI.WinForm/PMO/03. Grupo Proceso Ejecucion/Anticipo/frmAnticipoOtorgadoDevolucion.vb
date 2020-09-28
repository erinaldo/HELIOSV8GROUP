Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmAnticipoOtorgadoDevolucion

    Public ManipulacionEstado As String
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "ANT", "ANTICIPOS", GEstableciento.IdEstablecimiento)
        ObtenerTablaGenerales()
        'txtFechaComprobante.Value = Date.Now

    End Sub

#Region "metodos"


    Public Sub ObtenerSaldoAnticipo(idanticipo As Integer)
        Dim DocumentoAnticipoSL As New documentoAnticipo

        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim saldo As Decimal = CDec(0.0)
        Dim saldome As Decimal = CDec(0.0)

        DocumentoAnticipoSL = documentoAnticipoSA.SaldoAnticipo(idanticipo)

        saldo = DocumentoAnticipoSL.MontoDeudaSoles - DocumentoAnticipoSL.MontoPagadoSoles
        saldome = DocumentoAnticipoSL.MontoDeudaUSD - DocumentoAnticipoSL.MontoPagadoUSD
        lblDeudaPendiente.Text = saldo
        lblDeudaPendienteme.Text = saldome
        lblTipoCambio.Text = DocumentoAnticipoSL.TipoCambio

       

    End Sub


    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        cbotipoOperacion.ValueMember = "codigoDetalle"
        cbotipoOperacion.DisplayMember = "descripcion"
        cbotipoOperacion.DataSource = tablaSA.GetListaTablaDetalle(12, "1")
        cbotipoOperacion.SelectedValue = -1

        cboEntidades.ValueMember = "codigoDetalle"
        cboEntidades.DisplayMember = "descripcion"
        cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")

    End Sub


    Sub calculos()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value

        If tcambio > 0 Then
            Imn = nudMonedaNacional.Value
            nudMonedaExtranjero.Value = Math.Round(Imn / tcambio, 2)
        End If

    End Sub

    Sub CalculoDolares()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value

        If tcambio > 0 Then
            Imn = nudMonedaExtranjero.Value
            nudMonedaNacional.Value = Math.Round(Imn * tcambio, 2)
        End If
    End Sub


#End Region

#Region "PROVEEDOR"

    'Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
    '    Dim personaSA As New PersonaSA
    '    Try
    '        lsvProveedor.Items.Clear()
    '        For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
    '            Dim n As New ListViewItem(i.idPersona)
    '            n.SubItems.Add(i.nombreCompleto)
    '            n.SubItems.Add(String.Empty)
    '            n.SubItems.Add(i.idPersona)
    '            lsvProveedor.Items.Add(n)
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    
#End Region


#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean
        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            PanelError.Visible = False
        Else
            Timer1.Enabled = False
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



#Region "VALIDA USUARIO CAJA"
    'Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
    '    Dim efSA As New EstadosFinancierosSA
    '    Dim ef As New estadosFinancieros
    '    Dim estableSA As New establecimientoSA

    '    GFichaUsuarios = New GFichaUsuario
    '    Select Case ManipulacionEstado
    '        Case ENTITY_ACTIONS.INSERT

    '            If IsNothing(GFichaUsuarios.NombrePersona) Then
    '                With frmFichaUsuarioCaja
    '                    .txtDni.Enabled = True
    '                    ModuloAppx = ModuloSistema.CAJA
    '                    .lblNivel.Text = "Caja"
    '                    .lblEstadoCaja.Visible = True
    '                    .GroupBox1.Visible = True
    '                    .GroupBox2.Visible = True
    '                    .GroupBox4.Visible = True
    '                    .cboMoneda.Visible = True
    '                    .Timer1.Enabled = True
    '                    .Tipo_SituacionCaja = TIPO_SITUACION.CAJA_COBRO
    '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                    If IsNothing(GFichaUsuarios.NombrePersona) Then
    '                        Return False
    '                    Else
    '                        Return True
    '                    End If
    '                End With

    '            End If
    '        Case ENTITY_ACTIONS.UPDATE
    '            With frmFichaUsuarioCaja
    '                ModuloAppx = ModuloSistema.CAJA
    '                .lblNivel.Text = "Caja"
    '                .lblEstadoCaja.Visible = True
    '                .GroupBox1.Visible = True
    '                .GroupBox2.Visible = True
    '                .GroupBox4.Visible = True
    '                .cboMoneda.Visible = True
    '                .Timer1.Enabled = False
    '                .txtDni.Enabled = False
    '                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
    '                .StartPosition = FormStartPosition.CenterParent
    '                .UbicarUsuarioCaja(intIdDocumento, "ANTICIPOS")
    '                .ShowDialog()
    '                If IsNothing(GFichaUsuarios.NombrePersona) Then
    '                    Return False
    '                Else
    '                    Return True
    '                End If
    '            End With

    '    End Select
    '    Return True

    'End Function
#End Region


#Region "Metodos"

    Private Sub cargarCtasFinan()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")

            ListaDocPago(lista)
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)

        ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo("TC")
            Dim lista As New List(Of String)
            lista.Add("001")
            ListaDocPago(lista)
        End If
    End Sub

    Public Sub ListaDocPago(listaCuenta As List(Of String))
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)

        tabla = tablaSA.GetListaTablaDetalle(1, "1")
        tabla = (From n In tabla _
                     Where listaCuenta.Contains(n.codigoDetalle) _
                    Select n).ToList
        cboTipoDoc.DataSource = tabla
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.SelectedValue = "001"
        'CargarDAtos()
    End Sub




    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros

        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)
        estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(idCaja, txtFechaTrans.Value)
        If (Not IsNothing(estadoBL)) Then
            cboMoneda.SelectedValue = estadoBL.codigo
            txtCuentaOrigen.Text = estadoBL.cuenta
            nudDeudaPendienteme.Text = estadoSaldoBL.importeBalanceME
            nudDeudaPendientemn.Text = estadoSaldoBL.importeBalanceMN

            Select Case cboMoneda.SelectedValue
                Case 1
                    pnExtranjero.Visible = False
                    pnTipoCambio.Visible = False
                    pnNacional.Visible = True
                    PictureBox5.Visible = False
                    PictureBox4.Visible = True
                    pnImpMEDisp.Location = New Point(170, 21)
                    pnImpMNDisp.Location = New Point(9, 21)
                    pnExtranjero.Enabled = False
                    pnNacional.Enabled = True
                    txtTipoCambio.Value = TmpTipoCambio
                Case 2

                    pnExtranjero.Visible = True
                    pnTipoCambio.Visible = True
                    pnNacional.Visible = True
                    PictureBox5.Visible = True
                    PictureBox4.Visible = False
                    pnImpMEDisp.Location = New Point(9, 21)
                    pnImpMNDisp.Location = New Point(170, 21)
                    pnNacional.Location = New Point(550, 22)
                    pnExtranjero.Location = New Point(53, 22)
                    'pnNacional.Visible = False
                    pnExtranjero.Enabled = True
                    pnNacional.Enabled = False
            End Select


            cbotipoOperacion.SelectedValue = "103"
            'GetObtenerSaldoEF()
        End If
    End Sub

    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try
            Me.cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = strBusqueda,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Me.cboDepositoHijo.DisplayMember = "descripcion"
            Me.cboDepositoHijo.ValueMember = "idestado"
            cboDepositoHijo.SelectedValue = -1
            cboDepositoHijo.Tag = 0

            cboMoneda.ValueMember = "codigoDetalle"
            cboMoneda.DisplayMember = "descripcion"
            cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            cboMoneda.SelectedValue = -1

        Catch ex As Exception

        End Try
    End Sub

    'Public Sub UbicarEntidadPorRuc(strNro As String)
    '    Dim entidadSA As New entidadSA
    '    Dim entidad As New entidad

    '    entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
    '    If Not IsNothing(entidad) Then
    '        With entidad
    '            txtProveedor.Text = .nombreCompleto
    '            txtProveedor.Tag = .idEntidad
    '            txtCuenta.Text = .cuentaAsiento
    '            txtRuc.Text = .nrodoc
    '        End With
    '    Else
    '        txtProveedor.Clear()
    '        txtProveedor.Clear()
    '        txtCuenta.Clear()
    '        txtRuc.Clear()
    '        If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
    '            txtDocProveedor.Clear()
    '            txtNomProv.Clear()
    '            txtApePat.Clear()
    '            pcProveedor.Font = New Font("Tahoma", 8)
    '            pcProveedor.Size = New Size(321, 248)
    '            Me.pcProveedor.ParentControl = Me.txtProveedor
    '            Me.pcProveedor.ShowPopup(Point.Empty)
    '        End If
    '    End If
    'End Sub

    'Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
    '    Dim entidadSA As New entidadSA
    '    Try

    '        lsvproveedor.Items.Clear()
    '        For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
    '            Dim n As New ListViewItem(i.idEntidad)
    '            n.SubItems.Add(i.nombreCompleto)
    '            n.SubItems.Add(i.cuentaAsiento)
    '            n.SubItems.Add(i.nrodoc)
    '            lsvproveedor.Items.Add(n)
    '        Next
    '    Catch ex As Exception

    '    End Try

    'End Sub

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

    Public Sub Grabar()
        Dim DocCaja As New documento
        Dim documentoSA As New DocumentoSA
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim ndocumento As New documento
        Dim ndocumentoAnticipo As New documentoAnticipo
        Dim ndocumentoAnticipoDetalle As New documentoAnticipoDetalle
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        ListaAsientonTransito = New List(Of asiento)
        Dim ListaDetalle As New List(Of documentoAnticipoDetalle)
        Dim idNumeracion As Integer

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9901"
            .fechaProceso = DateTime.Now
            idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = idNumeracion
            .idOrden = Nothing
            .tipoOperacion = "104"
            .usuarioActualizacion = cboDepositoHijo.SelectedValue
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoAnticipo

            .codigoLibro = "1"
            .fechaPeriodo = PeriodoGeneral
            '.idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .movimiento = "DC"
            .tipoDocumento = "9901"
            .fechaDoc = DateTime.Now
            .tipoOperacion = "104"
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .numeroDoc = .IdNumeracion
            .Moneda = "1"
            .TipoCambio = txtTipoCambio.Value
            .importeMN = nudMonedaNacional.Value
            .importeME = nudMonedaExtranjero.Value
            '.glosa = Glosa()
            .usuarioModificacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .codigoProveedor = CInt(txtProveedor.Tag)
        End With
        ndocumento.documentoAnticipo = ndocumentoAnticipo

        With ndocumentoAnticipoDetalle

            .fecha = txtFechaTrans.Value
            .idAnticipo = lblanticipo.Text
            .DetalleItem = "DEVOLUCION"
            .importeMN = CDec(nudMonedaNacional.Value)
            .montoSolesRef = CDec(nudMonedaNacional.Value)
            .importeME = CDec(nudMonedaExtranjero.Value)
            .montoUsdRef = CDec(nudMonedaExtranjero.Value)
            .entregado = "SI"
            .diferTipoCambio = txtTipoCambio.Value
            .estadoAnticipo = "0"
            '.documentoAfectado = lblIdDocumento.Text
            .usuarioModificacion = usuario.IDUsuario
            .fechaActualizacion = Date.Now
            ' .documentoAfectadodetalle = CDec(i.GetValue("iddocumentodet"))
        End With
        ListaDetalle.Add(ndocumentoAnticipoDetalle)
        'ListaAsientonTransito.Add(GeneraraAsiento)
        'ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentoAnticipo.documentoAnticipoDetalle = ListaDetalle
        DocCaja = ComprobanteCaja()

        documentoAnticipoSA.SaveAnticipoDevolucion(ndocumento, DocCaja)
        lblEstado.Text = "Caja registrada correctamente!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        '    lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub

  

    Function ComprobanteCaja() As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)


        ef = efSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If

        nDocumentoCaja.fechaProceso = DateTime.Now
        nDocumentoCaja.tipoDoc = "9901"
        nDocumentoCaja.nroDoc = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante) ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = cbotipoOperacion.SelectedValue
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.tipoMovimiento = "DC"
        objCaja.IdProveedor = CInt(txtProveedor.Tag)
        objCaja.codigoLibro = "104"
        objCaja.codigoProveedor = CInt(txtProveedor.Tag)
        objCaja.TipoDocumentoPago = cboTipoDoc.SelectedValue
        objCaja.tipoDocPago = cboTipoDoc.SelectedValue
        objCaja.periodo = PeriodoGeneral
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2") ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")

        If (txtDescripcion.Text.Length > 0) Then
            objCaja.glosa = txtDescripcion.Text
        Else
            objCaja.glosa = Glosa()
        End If

        If cboTipoDoc.SelectedValue = "001" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = cboEntidades.SelectedValue
            objCaja.fechaProceso = DateTime.Now
            objCaja.fechaCobro = Date.Now
            objCaja.entregado = "SI"

        ElseIf cboTipoDoc.SelectedValue = "007" Then ' cheques
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaProceso = txtFechaEmision.Value
            objCaja.fechaCobro = txtFechaCobro.Value
            objCaja.entregado = "NO"
        ElseIf cboTipoDoc.SelectedValue = "111" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaProceso = txtFechaEmision.Value
            objCaja.fechaCobro = txtFechaCobro.Value
            objCaja.entregado = "NO"
        ElseIf cboTipoDoc.SelectedValue = "109" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaCobro = DateTime.Now
            objCaja.fechaProceso = Date.Now
            objCaja.entregado = "NO"
        End If
        objCaja.tipoCambio = txtTipoCambio.Value
        objCaja.montoSoles = nudMonedaNacional.Value
        objCaja.montoUsd = nudMonedaExtranjero.Value
        'objCaja.glosa = Glosa()
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        'End With

        objCaja.entidadFinanciera = cboDepositoHijo.SelectedValue
        objCaja.usuarioModificacion = cboDepositoHijo.SelectedValue
        objCaja.fechaModificacion = DateTime.Now
        objCaja.tipoOperacion = "AR"
        nDocumentoCaja.documentoCaja = objCaja


        Select Case cboMoneda.SelectedValue
            Case 1
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = DateTime.Now
                objCajaDetalle.idItem = Nothing
                objCajaDetalle.DetalleItem = Nothing
                objCajaDetalle.montoSoles = CDec(nudMonedaNacional.Value) 'CDec(txtTotalmn.Text)
                objCajaDetalle.montoUsd = CDec(nudMonedaExtranjero.Value) ' CDec(txtTotalme.Text)
                objCajaDetalle.entregado = "SI"
                objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
                objCajaDetalle.moneda = cboMoneda.SelectedValue
                objCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                objCajaDetalle.usuarioModificacion = cboDepositoHijo.SelectedValue
                objCajaDetalle.fechaModificacion = DateTime.Now
                ListaDetalle.Add(objCajaDetalle)
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle

            Case 2
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = DateTime.Now
                objCajaDetalle.idItem = Nothing
                objCajaDetalle.DetalleItem = Nothing
                objCajaDetalle.montoSoles = CDec(nudMonedaNacional.Value) 'CDec(txtTotalmn.Text)
                objCajaDetalle.montoUsd = CDec(nudMonedaExtranjero.Value) ' CDec(txtTotalme.Text)
                objCajaDetalle.entregado = "SI"
                objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
                objCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                objCajaDetalle.usuarioModificacion = cboDepositoHijo.SelectedValue
                objCajaDetalle.fechaModificacion = DateTime.Now
                ListaDetalle.Add(objCajaDetalle)
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle
            Case 2
        End Select
        '   nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)
        Return nDocumentoCaja
    End Function


    Public Function Glosa() As String
        Return "Por voucher contable " & txtProveedor.Text.Trim
    End Function

    Private Function GeneraraAsiento() As asiento
        Dim nAsiento As New asiento
        Dim movimiento As movimiento
        Try
            nAsiento = New asiento
            nAsiento.idDocumento = 0
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = txtProveedor.Tag
            nAsiento.nombreEntidad = txtProveedor.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nAsiento.fechaProceso = DateTime.Now
            nAsiento.codigoLibro = "103"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.ANTICIPOS
            nAsiento.importeMN = nudMonedaNacional.Value
            nAsiento.importeME = nudMonedaExtranjero.Value
            nAsiento.glosa = Glosa()
            nAsiento.usuarioActualizacion = "jiuni"
            nAsiento.fechaActualizacion = DateTime.Now


            movimiento = New movimiento With {
                  .cuenta = "122",
                  .descripcion = "Anticipos por pagar",
                  .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
                  .monto = nudMonedaNacional.Value,
                  .montoUSD = nudMonedaExtranjero.Value,
                  .fechaActualizacion = DateTime.Now,
                  .usuarioActualizacion = "Jiuni"}
            nAsiento.movimiento.Add(movimiento)
            '.cuenta = "122"= txtCuenta.Text,
            movimiento = New movimiento With {
                .cuenta = txtCuentaOrigen.Text,
                .descripcion = cboDepositoHijo.Text,
                .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
                .monto = nudMonedaNacional.Value,
                .montoUSD = nudMonedaExtranjero.Value,
                .fechaActualizacion = DateTime.Now,
                .usuarioActualizacion = "Jiuni"}
            nAsiento.movimiento.Add(movimiento)

        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
        Return nAsiento
    End Function

    'Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)

    '    Dim DocCaja As New documento
    '    Dim documentoSA As New DocumentoSA
    '    Dim documentoAnticipoSA As New documentoAnticipoSA
    '    Dim ndocumento As New documento
    '    Dim ndocumentoAnticipo As New documentoAnticipo
    '    Dim objEntidad As New entidadSA
    '    Dim nEntidad As New entidad

    '    Dim objEntidadFinanciera As New EstadosFinancierosSA
    '    Dim nEntidadfinanciera As New estadosFinancieros


    '    Try
    '        'CABECERA COMPROBANTE
    '        With documentoAnticipoSA.UbicarDocumentoAnticipo(intIdDocumento)
    '            lblIdDocumento.Text = .idDocumento
    '            txtFechaComprobante.Value = .fechaDoc
    '            'txtNumero.Text = .numeroDoc
    '            cboMoneda.SelectedValue = .Moneda
    '            nudMonedaNacional.Value = .importeMN
    '            nudMonedaExtranjero.Value = .importeME
    '            txtTipoCambio.Value = .TipoCambio

    '            'PROVEEDOR
    '            nEntidad = objEntidad.UbicarEntidadPorID(.razonSocial).First()
    '            txtRuc.Text = nEntidad.nrodoc
    '            txtCuenta.Text = nEntidad.cuentaAsiento
    '            txtProveedor.Tag = nEntidad.idEntidad
    '            txtProveedor.Text = nEntidad.nombreCompleto

    '            'caja

    '            nEntidadfinanciera = objEntidadFinanciera.GetUbicar_estadosFinancierosPorID(.idEntidadFinanciera)
    '            txtCuentaOrigen.Text = nEntidadfinanciera.cuenta
    '            'txtCajaOrigen.ValueMember = nEntidadfinanciera.idestado
    '            'txtCajaOrigen.Text = nEntidadfinanciera.descripcion

    '        End With

    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try

    'End Sub

#End Region

    Private Sub frmAnticipoOtorgadoDevolucion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _cuenta As String

        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal cuenta As String)
            _name = name
            _id = id
            _cuenta = cuenta
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

        Public Property Cuenta() As String
            Get
                Return _cuenta
            End Get
            Set(ByVal value As String)
                _cuenta = value
            End Set
        End Property

    End Class






    Private Sub frmAnticipoOtorgadoDevolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
            Exit Sub
            MessageBox.Show("Escriba una Cuenta Corriente")
        End If

        If Not txtNumOper.Text.Trim.Length > 0 Then
            Exit Sub
            MessageBox.Show("Escriba un numero de operacion")
        End If

        If Not cbotipoOperacion.Text.Trim.Length > 0 Then
            Exit Sub
            MessageBox.Show("Seleccione un Tipo de operacion")
        End If

        If Not CDec(lblDeudaPendiente.Text) >= nudMonedaNacional.Value Then
            Exit Sub
            MessageBox.Show("El monto a devolver no debe ser mayor al Saldo")
        End If
        Grabar()
    End Sub

   

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        cboMoneda.SelectedValue = -1
        ' txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        nudMonedaNacional.Value = 0
        cboTipoDoc.SelectedValue = -1
        'txtDescripcion.Clear()
        cbotipoOperacion.SelectedValue = -1
        txtNumOper.Clear()
        cargarCtasFinan()
    End Sub

    

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click
        If cboTipoDoc.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDoc.SelectedValue = "109" Then 'EFECTIVO (que se genere un vocher de caja con los datos del comprobante que se está pagando) 
                pnEntidad.Visible = False
                pnFecha.Visible = False
                Label17.Text = "NRO. VOUCHER:"

            ElseIf cboTipoDoc.SelectedValue = "007" Then ' CHEQUES
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            ElseIf cboTipoDoc.SelectedValue = "001" Then ' DEPOSITO EN CUENTA 
                pnEntidad.Visible = True
                pnFecha.Visible = False
                Label17.Text = "NRO. OPERACIÓN:"

            ElseIf cboTipoDoc.SelectedValue = "111" Then ' CHEQUE NO NEGOCIABLE 
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            End If
        End If
    End Sub

    Public Sub CargarEntidadesXtipo()
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        Dim sumatoria As Decimal
        Try

            Select Case cboMoneda.SelectedValue
                Case 1
                    If (nudMonedaNacional.Value <= nudDeudaPendientemn.Value) Then
                        lsvTipoCambio.Items.Clear()
                        lsvTipoCambio.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
                        lsvTipoCambio.Columns.Add("T/C", 40, HorizontalAlignment.Left) '1
                        lsvTipoCambio.Columns.Add("Importe ME", 65, HorizontalAlignment.Left) '1
                        lsvTipoCambio.Columns.Add("Importe MN", 65, HorizontalAlignment.Left) '1

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(nudMonedaNacional.Value, cboDepositoHijo.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(CDec(i.diferTipoCambio).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoUsd).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoSoles).ToString("N2"))
                            lsvTipoCambio.Items.Add(n)
                            sumatoria += i.montoSoles
                        Next
                        nudMonedaNacional.Value = sumatoria
                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual! "
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        nudMonedaNacional.Value = 0.0
                        nudMonedaNacional.Select(0, nudMonedaNacional.Text.Length)
                    End If
                Case 2
                    If (nudMonedaExtranjero.Value <= nudDeudaPendienteme.Value) Then
                        lsvTipoCambio.Items.Clear()
                        lsvTipoCambio.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
                        lsvTipoCambio.Columns.Add("T/C", 40, HorizontalAlignment.Left) '1
                        lsvTipoCambio.Columns.Add("Importe ME", 65, HorizontalAlignment.Left) '1
                        lsvTipoCambio.Columns.Add("Importe MN", 65, HorizontalAlignment.Left) '1

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(nudMonedaExtranjero.Value, cboDepositoHijo.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(CDec(i.diferTipoCambio).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoUsd).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoSoles).ToString("N2"))
                            lsvTipoCambio.Items.Add(n)
                            sumatoria += i.montoSoles
                        Next
                        nudMonedaNacional.Value = sumatoria
                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        nudMonedaExtranjero.Value = 0.0
                        nudMonedaExtranjero.Select(0, nudMonedaExtranjero.Text.Length)
                    End If
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumOper.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtDescripcion.Clear()
        End Try
    End Sub



    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub txtNumOper_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumOper.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtCuentaCorriente.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumOper.Clear()
        End Try
    End Sub

    Private Sub txtNumOper_TextChanged(sender As Object, e As EventArgs) Handles txtNumOper.TextChanged

    End Sub

    Private Sub txtCuentaCorriente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuentaCorriente.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case cboMoneda.SelectedValue
                    Case 1
                        nudMonedaNacional.Select()
                        nudMonedaNacional.Select(0, nudMonedaNacional.Text.Length)
                    Case 2
                        nudMonedaExtranjero.Select()
                        nudMonedaExtranjero.Select(0, nudMonedaExtranjero.Text.Length)
                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub txtCuentaCorriente_TextChanged(sender As Object, e As EventArgs) Handles txtCuentaCorriente.TextChanged

    End Sub

    Private Sub nudMonedaNacional_ValueChanged(sender As Object, e As EventArgs) Handles nudMonedaNacional.ValueChanged
        Select Case cboMoneda.SelectedValue
            Case 1
                calculos()
            Case 2
                CalculoDolares()
        End Select
    End Sub

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click
        cboDepositoHijo.Tag = 1
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Dim value As Object = Me.cboDepositoHijo.SelectedValue
        txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        nudMonedaNacional.Value = 0
        nudMonedaExtranjero.Value = 0
        'txtProveedor.Clear()
        'txtRuc.Clear()
        txtDescripcion.Clear()
        txtNumOper.Clear()

        If (cboDepositoHijo.Tag = 1) Then
            If IsNumeric(value) Then
                cargarDatosCuenta(CInt(value))
            Else

            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        Select Case cboMoneda.SelectedValue
            Case 1
                calculos()
            Case 2
                CalculoDolares()
        End Select
    End Sub

    Private Sub nudMonedaExtranjero_ValueChanged(sender As Object, e As EventArgs) Handles nudMonedaExtranjero.ValueChanged
        Select Case cboMoneda.SelectedValue
            Case 1
                calculos()
            Case 2
                CalculoDolares()
        End Select
    End Sub
End Class