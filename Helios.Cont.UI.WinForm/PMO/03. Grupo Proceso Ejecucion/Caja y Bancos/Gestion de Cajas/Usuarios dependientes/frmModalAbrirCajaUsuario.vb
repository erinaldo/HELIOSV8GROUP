Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Public Class frmModalAbrirCajaUsuario
    Inherits frmMaster
    Dim colorx As New GridMetroColors()
    Dim usuarioSA As New UsuarioSA
    Dim usuariobe As New Usuario
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property strEstadoManipulacion() As String
    Public Property tipoCambioME() As Decimal
    Public Property idCajauser() As Integer
    Public Property frmSeleccionCuentaFinanciera As frmSeleccionCuentaFinanciera
    Dim idNumeracion As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OES", Me.Text, GEstableciento.IdEstablecimiento)
        'ListaUsuariosAdmin()
        txtAnioCompra.Text = DateTime.Now.Year
        GridCFG(dgvCuentasApertura)
        dgvCuentasApertura.DataSource = UbicarCajasHijas()

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

    Public Sub UbicarCajaUsuario()
        Dim cajausuarioSA As New cajaUsuarioSA
        Dim cajausuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim cajausuario As New cajaUsuario
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros

        cajausuario = cajausuarioSA.UbicarCajaUsuarioPorID(idCajauser)

        txtCliente2.Tag = CInt(cajausuario.idPersona)
        txtCliente2.Text = cajausuario.NombrePersona

        txtSaldoResponsableMN.DecimalValue = cajausuario.fondoMN
        txtSaldoResponsableMe.DecimalValue = cajausuario.fondoME
        Me.dgvCuentasApertura.Table.Records.DeleteAll()
        For Each i In cajausuarioDetalleSA.ListaDetallePorCaja(idCajauser)
            ef = efSA.GetUbicar_estadosFinancierosPorID(i.idEntidad)

            Me.dgvCuentasApertura.Table.AddNewRecord.SetCurrent()
            Me.dgvCuentasApertura.Table.AddNewRecord.BeginEdit()
            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("codigo", i.secuencia)
            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("IdEntidad", i.idEntidad)
            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("entidad", ef.descripcion)
            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("moneda", IIf(ef.codigo = "1", "NACIONAL", "EXTRANJERA"))
            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("tc", TmpTipoCambio)
            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", i.importeMN)
            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", i.importeME)
            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("montoMax", 0)
            Me.dgvCuentasApertura.Table.AddNewRecord.EndEdit()
        Next

    End Sub

    Sub ActualizarCajaUsuario()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim UserDetalle = New cajaUsuariodetalle
        Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)
        Try

            cajaUsuario = New cajaUsuario()
            cajaUsuario.idcajaUsuario = idCajauser
            cajaUsuario.idEmpresa = Gempresas.IdEmpresaRuc
            cajaUsuario.idEstablecimiento = GEstableciento.IdEstablecimiento
            cajaUsuario.periodo = PeriodoGeneral
            cajaUsuario.idPersona = txtCliente2.Tag
            cajaUsuario.idCajaOrigen = txtCF_name.Tag
            cajaUsuario.idCajaDestino = Nothing
            cajaUsuario.moneda = txtCF_name.tag
            cajaUsuario.tipoCambio = TmpTipoCambio
            cajaUsuario.fechaRegistro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            cajaUsuario.fondoMN = txtSaldoResponsableMN.DecimalValue
            cajaUsuario.fondoME = txtSaldoResponsableMe.DecimalValue
            cajaUsuario.ingresoAdicMN = 0
            cajaUsuario.ingresoAdicME = 0
            cajaUsuario.otrosIngresosMN = 0
            cajaUsuario.otrosIngresosME = 0
            cajaUsuario.otrosEgresosMN = 0
            cajaUsuario.otrosEgresosME = 0
            cajaUsuario.estadoCaja = "A"
            cajaUsuario.enUso = "N"
            cajaUsuario.usuarioActualizacion = usuario.IDUsuario
            cajaUsuario.fechaActualizacion = DateTime.Now

            For Each i As Record In dgvCuentasApertura.Table.Records
                UserDetalle = New cajaUsuariodetalle
                UserDetalle.idcajaUsuario = idCajauser
                UserDetalle.idEntidad = i.GetValue("IdEntidad")
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        UserDetalle.moneda = 1
                    Case Else
                        UserDetalle.moneda = 2
                End Select
                UserDetalle.importeMN = i.GetValue("importeMN")
                UserDetalle.importeME = i.GetValue("importeME")
                UserDetalle.usuarioActualizacion = usuario.IDUsuario
                UserDetalle.fechaActualizacion = DateTime.Now
                ListaUserDetalle.Add(UserDetalle)
            Next
            cajaUsuario.cajaUsuariodetalle = ListaUserDetalle
            cajaUsuarioSA.EditarCajaUsuarioNuevo(cajaUsuario)
            Tag = "Grabado"
            Dispose()
        Catch ex As Exception
            Tag = Nothing
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub


    Sub TotalDGV()
        Dim monto As Decimal = 0
        Dim montoUS As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoME As Decimal = 0
        For Each r As Record In dgvCuentasApertura.Table.Records

            Select Case r.GetValue("moneda")
                Case "NACIONAL"
                    monto += r.GetValue("importeMN")
                Case "EXTRANJERA"
                    montoUS += r.GetValue("importeME")
            End Select

        Next

        txtSaldoResponsableMN.DecimalValue = monto
        txtSaldoResponsableMe.DecimalValue = montoUS

    End Sub

    'Private Function GeneraraAsiento() As asiento
    '    Dim nAsiento As New asiento
    '    Dim movimiento As movimiento
    '    Dim efsa As New EstadosFinancierosSA
    '    Try
    '        nAsiento = New asiento
    '        nAsiento.idDocumento = 0
    '        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
    '        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
    '        nAsiento.idEntidad = cboPersona.SelectedValue
    '        nAsiento.nombreEntidad = cboPersona.Text
    '        nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
    '        nAsiento.fechaProceso = txtFecHaApertura.Value
    '        nAsiento.codigoLibro = "1"
    '        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
    '        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
    '        nAsiento.importeMN = txtFondoMN.DecimalValue
    '        nAsiento.importeME = txtFondoME.DecimalValue
    '        nAsiento.glosa = Glosa()
    '        nAsiento.usuarioActualizacion = "jiuni"
    '        nAsiento.fechaActualizacion = DateTime.Now


    '        movimiento = New movimiento With {
    '              .cuenta = efsa.GetUbicar_estadosFinancierosPorID(txtCF_name.tag).cuenta,
    '              .descripcion = txtCF_name.text,
    '              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
    '              .monto = txtFondoMN.DecimalValue,
    '              .montoUSD = txtFondoME.DecimalValue,
    '              .fechaActualizacion = DateTime.Now,
    '              .usuarioActualizacion = "Jiuni"}
    '        nAsiento.movimiento.Add(movimiento)

    '        'movimiento = New movimiento With {
    '        '    .cuenta = efsa.GetUbicar_estadosFinancierosPorID(txtDestino.Tag).cuenta,
    '        '    .descripcion = txtDestino.Text,
    '        '    .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
    '        '    .monto = txtFondoMN.DecimalValue,
    '        '    .montoUSD = txtFondoME.DecimalValue,
    '        '    .fechaActualizacion = DateTime.Now,
    '        '    .usuarioActualizacion = "Jiuni"}
    '        'nAsiento.movimiento.Add(movimiento)


    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '    End Try
    '    Return nAsiento
    'End Function

    Public Function Glosa() As String
        Return "Por Apertura de caja al usuario: " & txtCliente2.Text.Trim
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
        Dim listaDocumento As New List(Of documento)
        Dim ListaSubUsers As New List(Of cajaUsuario)
        Dim SubUsers As New cajaUsuario
        Dim UserDetalle As New cajaUsuariodetalle
        Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)

        ListaAsientonTransito = New List(Of asiento)

        Try
            With objCaja
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .periodo = PeriodoGeneral
                .idPersona = txtCliente2.Tag
                .idCajaOrigen = txtCF_name.tag
                .idCajaDestino = Nothing ' txtDestino.Tag
                .moneda = txtCF_moneda.Tag
                .tipoCambio = TmpTipoCambio
                .fechaRegistro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .fondoMN = txtSaldoResponsableMN.DecimalValue ' txtFondoMN.DecimalValue
                .fondoME = txtSaldoResponsableMe.DecimalValue ' txtFondoME.DecimalValue
                .ingresoAdicMN = 0
                .ingresoAdicME = 0
                .otrosIngresosMN = 0
                .otrosIngresosME = 0
                .otrosEgresosMN = 0
                .otrosEgresosME = 0
                .estadoCaja = "A"
                .enUso = "N"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            For Each i As Record In dgvCuentasApertura.Table.Records
                UserDetalle = New cajaUsuariodetalle
                UserDetalle.idEntidad = i.GetValue("IdEntidad")
                Select Case i.GetValue("moneda")
                    Case "NACIONAL"
                        UserDetalle.moneda = 1
                    Case Else
                        UserDetalle.moneda = 2
                End Select
                UserDetalle.importeMN = CDec(i.GetValue("importeMN"))
                UserDetalle.importeME = CDec(i.GetValue("importeME"))
                UserDetalle.usuarioActualizacion = usuario.IDUsuario
                UserDetalle.fechaActualizacion = DateTime.Now
                ListaUserDetalle.Add(UserDetalle)


                'If (chSinReferencia.Checked = False) Then
                '    ndocumento = New documento
                '    With ndocumento
                '        .idEmpresa = Gempresas.IdEmpresaRuc
                '        .idCentroCosto = GEstableciento.IdEstablecimiento
                '        .tipoDoc = "9908"
                '        .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '        idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
                '        .nroDoc = idNumeracion
                '        .idOrden = Nothing
                '        .moneda = txtCF_moneda.Tag
                '        .idEntidad = txtCliente2.Tag
                '        .entidad = txtCliente2.Text
                '        .nrodocEntidad = txtRuc2.Text
                '        .tipoOperacion = StatusTipoOperacion.Apertura_Cierre_de_Caja
                '        .tipoEntidad = "UC"
                '        .usuarioActualizacion = usuario.IDUsuario
                '        .fechaActualizacion = DateTime.Now
                '    End With

                '    With ndocumentoCaja
                '        .periodo = GetPeriodo(txtPeriodo.Value, True)
                '        .idEmpresa = Gempresas.IdEmpresaRuc
                '        .idEstablecimiento = GEstableciento.IdEstablecimiento
                '        .TipoDocumentoPago = "9908"
                '        .formapago = Nothing
                '        .codigoProveedor = txtCliente2.Tag  'txtPersona.ValueMember
                '        .idPersonal = txtCliente2.Tag
                '        .tipoPersona = "UC"
                '        .codigoLibro = "1"
                '        .tipoDocPago = "9908"
                '        .numeroDoc = idNumeracion
                '        Select Case i.GetValue("moneda")
                '            Case "NACIONAL"
                '                .moneda = 1
                '            Case Else
                '                .moneda = 2
                '        End Select
                '        .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '        .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '        .tipoMovimiento = MovimientoCaja.SalidaDinero
                '        .tipoOperacion = StatusTipoOperacion.Apertura_Cierre_de_Caja
                '        .entidadFinanciera = txtCF_name.Tag
                '        .movimientoCaja = "AC"
                '        .IdEntidadFinanciera = i.GetValue("IdEntidad")
                '        .tipoCambio = TmpTipoCambio
                '        .montoSoles = CDec(i.GetValue("importeMN"))
                '        .montoUsd = CDec(i.GetValue("importeME"))
                '        .glosa = "Apertura de Caja - " + CStr(i.GetValue("IdEntidad"))
                '        .estado = "N"
                '        .idcosto = Nothing
                '        .usuarioModificacion = usuario.IDUsuario
                '        .fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '    End With

                '    ndocumento.documentoCaja = ndocumentoCaja

                '    Select Case txtCF_moneda.Tag
                '        Case 1
                '            ndocumentoCajaDetalle = New documentoCajaDetalle
                '            ndocumentoCajaDetalle.fecha = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '            ndocumentoCajaDetalle.idItem = "00"
                '            ndocumentoCajaDetalle.DetalleItem = Glosa()
                '            ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("importeMN"))
                '            ndocumentoCajaDetalle.montoSolesTransacc = CDec(i.GetValue("importeMN"))
                '            ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("importeME"))
                '            ndocumentoCajaDetalle.montoUsdTransacc = CDec(i.GetValue("importeME"))
                '            ndocumentoCajaDetalle.entregado = "SI"
                '            ndocumentoCajaDetalle.diferTipoCambio = TmpTipoCambio
                '            ndocumentoCajaDetalle.tipoCambioTransacc = TmpTipoCambio
                '            ndocumentoCajaDetalle.documentoAfectado = 0
                '            Select Case i.GetValue("moneda")
                '                Case "NACIONAL"
                '                    ndocumentoCajaDetalle.moneda = 1
                '                Case Else
                '                    ndocumentoCajaDetalle.moneda = 2
                '            End Select
                '            ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                '            ndocumentoCajaDetalle.fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '            ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                '        Case 2
                '            ndocumentoCajaDetalle = New documentoCajaDetalle
                '            ndocumentoCajaDetalle.fecha = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '            ndocumentoCajaDetalle.idItem = "00"
                '            ndocumentoCajaDetalle.DetalleItem = Glosa()

                '            ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("importeME"))
                '            ndocumentoCajaDetalle.montoUsdTransacc = CDec(i.GetValue("importeME"))
                '            ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("importeMN"))
                '            ndocumentoCajaDetalle.montoSolesTransacc = CDec(i.GetValue("importeMN"))
                '            ndocumentoCajaDetalle.diferTipoCambio = TmpTipoCambio
                '            ndocumentoCajaDetalle.tipoCambioTransacc = TmpTipoCambio


                '            ndocumentoCajaDetalle.entregado = "SI"
                '            ndocumentoCajaDetalle.documentoAfectado = 0
                '            ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                '            ndocumentoCajaDetalle.fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                '            Select Case i.GetValue("moneda")
                '                Case "NACIONAL"
                '                    ndocumentoCajaDetalle.moneda = 1
                '                Case Else
                '                    ndocumentoCajaDetalle.moneda = 2
                '            End Select
                '            ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                '    End Select

                'End If

            Next
            objCaja.cajaUsuariodetalle = ListaUserDetalle
            'ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            listaDocumento.Add(ndocumento)
            Dim codigoUsuarioClave = documentoCajaSA.SaveGroupCajaApertura(Nothing, objCaja, ListaSubUsers)
            Tag = codigoUsuarioClave
            Dispose()
        Catch ex As Exception
            Tag = Nothing
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub


    Public Function UbicarCajasHijas() As DataTable

        Dim DT As New DataTable()
        DT.Columns.Add("codigo", GetType(String))
        DT.Columns.Add("IdEntidad", GetType(Integer))
        DT.Columns.Add("entidad", GetType(String))
        DT.Columns.Add("moneda", GetType(String))
        DT.Columns.Add("tc", GetType(Decimal))
        DT.Columns.Add("importeMN", GetType(Decimal))
        DT.Columns.Add("importeME", GetType(Decimal))
        DT.Columns.Add("montoMax", GetType(Decimal))
        Return DT
    End Function

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

    Public Sub ListaUsuariosAdmin()
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
        Dim listaUsuario As New List(Of Usuario)
        Dim condicion As New List(Of String)
        condicion.Add("3")
        condicion.Add("4")

        listaUsuario = usuarioSA.GetListaUsuarios()
        Dim nuevaLista = listaUsuario.Where(Function(o) condicion.Contains(o.Rol)).ToList
        '   listaUsuario = usuarioSA.ListadoUsuariosPuntoVenta(New UsuarioRol With {.IDRol = 3})

        'cboPersona.DataSource = nuevaLista
        'cboPersona.ValueMember = "IDUsuario"
        'cboPersona.DisplayMember = "Full_Name"
        'cboPersona.SelectedValue = -1
    End Sub

    Public Sub ListaUsuarios()
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
        Dim TablaSA As New tablaDetalleSA
        Try
            Dim lista2 As List(Of Usuario) = usuarioSA.ListadoUsuariosPuntoVenta(New UsuarioRol With {.IDRol = 3})
            Dim dt As New DataTable

            dt.Columns.Add("ident", GetType(String))
            dt.Columns.Add("nomUser", GetType(String))
            dt.Columns.Add("idUsuario", GetType(Integer))

            For Each i In lista2
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.NroDocumento
                dr(1) = i.Nombres & " " & i.ApellidoPaterno & ", " & i.ApellidoMaterno
                dr(2) = i.IDUsuario
                dt.Rows.Add(dr)
            Next
            'GridGroupingControl2.DataSource = dt
            'Me.GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'cboMoneda.ValueMember = "codigoDetalle"
            'cboMoneda.DisplayMember = "descripcion"
            'cboMoneda.DataSource = TablaSA.GetListaTablaDetalle(4, "1")
            'txtCF_name.tag = -1

        Catch ex As Exception

        End Try

    End Sub

#End Region

    Private Sub frmAbrirCajaUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAbrirCajaUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCuentasApertura.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Dim selCaja As String = Nothing

    Private Sub btOperacion_Click(sender As Object, e As EventArgs)
        If Not IsNothing(Me.dgvCuentasApertura.Table.CurrentRecord) Then
            Me.dgvCuentasApertura.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim montoME As Decimal = 0
        Dim montoMN As Decimal = 0
        Dim montoAperturaMN As Decimal
        Dim montoAperturaME As Decimal
        Dim moneda As String
        Dim entidad As String

        If (btnMin.Tag = 0) Then
            If Not IsNothing(Me.dgvCuentasApertura.Table.CurrentRecord) Then
                Select Case ColIndex
                    Case 6

                        entidad = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("entidad")
                        moneda = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("moneda")
                        montoMN = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeMN")

                        If (montoMN > 0) Then

                            If (moneda = "NACIONAL") Then
                                If chSinReferencia.Checked = True Then
                                    Select Case txtCF_name.Tag
                                        Case 1
                                            montoME = 0.0
                                            TotalDGV()
                                        Case 2
                                            montoME = 0.0
                                            TotalDGV()
                                    End Select
                                Else
                                    If (entidad = txtCF_name.Text) Then
                                        montoAperturaMN = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeMN")


                                        If (montoAperturaMN <= CDec(SaldoEFMN.Text)) Then
                                            Dim disponible As Double = 0

                                            Select Case txtCF_name.Tag
                                                Case 1
                                                    montoME = 0.0
                                                    TotalDGV()
                                                Case 2
                                                    montoME = 0.0
                                                    TotalDGV()
                                            End Select
                                        Else
                                            lblEstado.Text = "El importe ingresado excede al permitido!"
                                            PanelError.Visible = True
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                                        End If
                                    Else
                                        'If (montoMN > 0) Then
                                        '    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", montoMN)
                                        'Else
                                        Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                        'End If

                                        lblEstado.Text = "La entidad selecciona no coincide!"
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)

                                    End If
                                End If

                            Else
                                Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                lblEstado.Text = "la cuenta seleccionada es Extranjera!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                            End If


                        Else

                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                            TotalDGV()
                            'lblEstado.Text = "El importe no debe ser negativo!"
                            'PanelError.Visible = True
                            'Timer1.Enabled = True
                            'TiempoEjecutar(10)
                        End If

                    Case 7

                        entidad = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("entidad")
                        moneda = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("moneda")
                        montoME = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeME")

                        If (montoME > 0) Then

                            If chSinReferencia.Checked = True Then
                                Dim disponible As Double = 0
                                If (moneda = "EXTRANJERA") Then
                                    montoMN = Math.Round(Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeME") * CDec(Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("tc")), 2)
                                    TotalDGV()
                                Else
                                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                                    lblEstado.Text = "la cuenta seleccionada es Nacional!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                End If
                            Else
                                If (moneda = "EXTRANJERA") Then
                                    If (entidad = txtCF_name.Text) Then
                                        montoAperturaME = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeME")
                                        If (montoAperturaME <= CDec(SaldoEFMN.Text)) Then
                                            Dim disponible As Double = 0

                                            montoMN = Math.Round(Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeME") * CDec(Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("tc")), 2)
                                            TotalDGV()
                                        Else
                                            lblEstado.Text = "El importe ingresado excede al permitido!"
                                            PanelError.Visible = True
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                                        End If
                                    Else
                                        lblEstado.Text = "La entidad selecciona no coincide!"
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                        Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", montoME)
                                    End If

                                Else
                                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                                    lblEstado.Text = "la cuenta seleccionada es Nacional!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                End If
                            End If

                        Else
                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                            'lblEstado.Text = "El importe no debe ser negativo!"
                            TotalDGV()
                            'PanelError.Visible = True
                            'Timer1.Enabled = True
                            'TiempoEjecutar(10)
                        End If
                End Select
            End If
        End If


    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        'If SaldoEFMN > 0 Then
        Dim nombreEntidad As Integer = 0

        For Each i As Record In dgvCuentasApertura.Table.Records
            If (i.GetValue("IdEntidad") = txtCF_name.tag) Then
                nombreEntidad += 1
            End If
        Next

        If (nombreEntidad = 0) Then

            Select Case txtCF_moneda.text
                Case "NACIONAL"
                    Me.dgvCuentasApertura.Table.AddNewRecord.SetCurrent()
                    Me.dgvCuentasApertura.Table.AddNewRecord.BeginEdit()
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("codigo", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("IdEntidad", txtCF_name.tag)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("entidad", txtCF_name.text)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("moneda", txtCF_moneda.text)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("tc", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("montoMax", SaldoEFMN)
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeME").ReadOnly = True
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeMN").ReadOnly = False
                    Me.dgvCuentasApertura.Table.AddNewRecord.EndEdit()

                Case "EXTRANJERA"
                    Me.dgvCuentasApertura.Table.AddNewRecord.SetCurrent()
                    Me.dgvCuentasApertura.Table.AddNewRecord.BeginEdit()
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("codigo", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("IdEntidad", txtCF_name.tag)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("entidad", txtCF_name.text)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("moneda", txtCF_moneda.text)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("tc", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("montoMax", SaldoEFMN)
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeME").ReadOnly = False
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeMN").ReadOnly = True
                    Me.dgvCuentasApertura.Table.AddNewRecord.EndEdit()


            End Select

        Else
            lblEstado.Text = "Ya existe entidad financiera!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)

        End If

    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs)
        If dgvCuentasApertura.Table.Records.Count > 0 Then
            dgvCuentasApertura.Table.Records.Delete(dgvCuentasApertura.Table.CurrentRecord)
            dgvCuentasApertura.Refresh()
            TotalDGV()
            btnMin.Tag = 0
        End If
    End Sub

    Private Sub cboPersona_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim Usuario As New Usuario
        Dim CajaUsuario As New cajaUsuario
        Me.Cursor = Cursors.WaitCursor
        Try
            Usuario = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = txtCliente2.Tag})

            If (Not IsNothing(txtCliente2.Tag)) Then

                CajaUsuario = cajaUsuarioSA.UbicarUsuarioAbierto(txtCliente2.Tag)

                Select Case strEstadoManipulacion
                    Case ENTITY_ACTIONS.INSERT
                        If (IsNothing(CajaUsuario)) Then
                            If (Not IsNothing(Usuario)) Then
                                txtRuc2.Text = Usuario.NroDocumento
                            End If
                        Else
                            lblEstado.Text = "El usuario tiene una caja activa!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)

                            txtSaldoResponsableMN.Clear()
                            txtSaldoResponsableMe.Clear()
                        End If
                    Case ENTITY_ACTIONS.UPDATE
                        If (Not IsNothing(Usuario)) Then
                            txtRuc2.Text = Usuario.NroDocumento
                        End If
                End Select

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
            Me.Cursor = Cursors.Arrow
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtCliente2.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un personal!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not dgvCuentasApertura.Table.Records.Count > 0 Then
                lblEstado.Text = "Ingrese cuenta financieras!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If strEstadoManipulacion = ENTITY_ACTIONS.INSERT Then
                lblEstado.Text = "Proceso normal"
                Grabar()
            Else
                ActualizarCajaUsuario()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
            Me.Cursor = Cursors.Arrow
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        If dgvCuentasApertura.Table.Records.Count > 0 Then
            dgvCuentasApertura.Table.Records.Delete(dgvCuentasApertura.Table.CurrentRecord)
            dgvCuentasApertura.Refresh()
            TotalDGV()
            btnMin.Tag = 0
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LoadingAnimator.Wire(dgvCuentasApertura.TableControl)
        If txtCliente2.Text.Trim.Length = 0 Then
            MsgBox("Debe seleccionar un usuario!", MsgBoxStyle.Exclamation, "Atención")
            LoadingAnimator.UnWire(dgvCuentasApertura.TableControl)
            Exit Sub
        End If

        If cboMesCompra.Text.Trim.Length = 0 Then
            MsgBox("Debe seleccionar un período valido!", MsgBoxStyle.Exclamation, "Atención")
            LoadingAnimator.UnWire(dgvCuentasApertura.TableControl)
            Exit Sub
        End If

        Dim fechaActual As DateTime = Format(Now, txtAnioCompra.Text & "-" & cboMesCompra.SelectedValue & "-" & txtDia.Value.Day)

        'frmSeleccionCuentaFinanciera = New frmSeleccionCuentaFinanciera
        'frmSeleccionCuentaFinanciera.txtPeriodo.Value = txtPeriodo.Value

        frmSeleccionCuentaFinanciera = New frmSeleccionCuentaFinanciera
        frmSeleccionCuentaFinanciera.txtPeriodo.Value = fechaActual
        frmSeleccionCuentaFinanciera.GetCuentasFinancieras("CUENTAS EN EFECTIVO")
        frmSeleccionCuentaFinanciera.StartPosition = FormStartPosition.CenterParent
        frmSeleccionCuentaFinanciera.ShowDialog()
        If frmSeleccionCuentaFinanciera.Tag IsNot Nothing Then
            'txtFondoMN.Value = 0
            'txtFondoME.Value = 0
            'txtTipoCambio.Value = 0
            'txtNumOper.Clear()
            'txtCuentaCorriente.Clear()
            SaldoEFME.DoubleValue = 0
            SaldoEFMN.DoubleValue = 0

            Dim c = CType(frmSeleccionCuentaFinanciera.Tag, estadosFinancieros)
            Select Case c.tipo
                Case "EF"
                    txtCF_tipo.Tag = c.tipo
                    txtCF_tipo.Text = "CUENTA EN EFECTIVO"
                Case "BC"
                    txtCF_tipo.Tag = c.tipo
                    txtCF_tipo.Text = "CUENTAS EN BANCO"
                Case "TC"
                    txtCF_tipo.Tag = c.tipo
                    txtCF_tipo.Text = "TARJETA DE CREDITO"
            End Select
            txtCF_name.Text = c.descripcion
            txtCF_name.Tag = c.idestado

            Select Case c.codigo
                Case 1
                    txtCF_moneda.Text = "NACIONAL"
                    txtCF_moneda.Tag = "1"
                Case 2
                    txtCF_moneda.Text = "EXTRANJERA"
                    txtCF_moneda.Tag = 2
            End Select

            txtCF_cuentaContable.Text = c.cuenta
            SaldoEFMN.DoubleValue = c.importeBalanceMN.GetValueOrDefault
            SaldoEFME.DoubleValue = 0

        End If
        LoadingAnimator.UnWire(dgvCuentasApertura.TableControl)
    End Sub


    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.USUARIO)
        f.CaptionLabels(0).Text = "Usuarios"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, Usuario)
            'Dim c = CType(f.Tag, entidad)
            txtCliente2.Text = c.Nombres + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno
            txtCliente2.Tag = c.IDUsuario
            txtRuc2.Text = c.NroDocumento
            txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        'If SaldoEFMN > 0 Then
        Dim nombreEntidad As Integer = 0

        For Each i As Record In dgvCuentasApertura.Table.Records
            If (i.GetValue("IdEntidad") = txtCF_name.tag) Then
                nombreEntidad += 1
            End If
        Next

        If (nombreEntidad = 0) Then

            Select Case txtCF_moneda.text
                Case "NACIONAL"
                    Me.dgvCuentasApertura.Table.AddNewRecord.SetCurrent()
                    Me.dgvCuentasApertura.Table.AddNewRecord.BeginEdit()
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("codigo", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("IdEntidad", txtCF_name.tag)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("entidad", txtCF_name.text)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("moneda", txtCF_moneda.text)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("tc", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("montoMax", CDec(SaldoEFMN.Text))
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeME").ReadOnly = True
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeMN").ReadOnly = False
                    Me.dgvCuentasApertura.Table.AddNewRecord.EndEdit()

                Case "EXTRANJERA"
                    Me.dgvCuentasApertura.Table.AddNewRecord.SetCurrent()
                    Me.dgvCuentasApertura.Table.AddNewRecord.BeginEdit()
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("codigo", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("IdEntidad", txtCF_name.tag)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("entidad", txtCF_name.text)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("moneda", txtCF_moneda.text)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("tc", 0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("montoMax", CDec(SaldoEFMN.Text))
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeME").ReadOnly = False
                    'gridGroupingControl1.Table.TableDescriptor.Columns("importeMN").ReadOnly = True
                    Me.dgvCuentasApertura.Table.AddNewRecord.EndEdit()


            End Select

        Else
            lblEstado.Text = "Ya existe entidad financiera!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)

        End If

    End Sub

    Private Sub dgvCuentasApertura_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCuentasApertura.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim montoME As Decimal = 0
        Dim montoMN As Decimal = 0
        Dim montoAperturaMN As Decimal
        Dim montoAperturaME As Decimal
        Dim moneda As String
        Dim entidad As String

        If (btnMin.Tag = 0) Then
            If Not IsNothing(Me.dgvCuentasApertura.Table.CurrentRecord) Then
                Select Case ColIndex
                    Case 6

                        entidad = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("entidad")
                        moneda = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("moneda")
                        montoMN = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeMN")

                        If (montoMN > 0) Then

                            If (moneda = "NACIONAL") Then
                                If chSinReferencia.Checked = True Then
                                    Select Case txtCF_moneda.Tag
                                        Case 1
                                            montoME = 0.0
                                            TotalDGV()
                                        Case 2
                                            montoME = 0.0
                                            TotalDGV()
                                    End Select
                                Else
                                    If (entidad = txtCF_name.Text) Then
                                        montoAperturaMN = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeMN")


                                        If (montoAperturaMN <= CDec(SaldoEFMN.Text)) Then
                                            Dim disponible As Double = 0

                                            Select Case txtCF_moneda.Tag
                                                Case 1
                                                    montoME = 0.0
                                                    TotalDGV()
                                                Case 2
                                                    montoME = 0.0
                                                    TotalDGV()
                                            End Select
                                        Else
                                            lblEstado.Text = "El importe ingresado excede al permitido!"
                                            PanelError.Visible = True
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                                        End If
                                    Else
                                        'If (montoMN > 0) Then
                                        '    Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", montoMN)
                                        'Else
                                        Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                        'End If

                                        lblEstado.Text = "La entidad selecciona no coincide!"
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)

                                    End If
                                End If

                            Else
                                Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                lblEstado.Text = "la cuenta seleccionada es Extranjera!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                            End If


                        Else

                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                            TotalDGV()
                            'lblEstado.Text = "El importe no debe ser negativo!"
                            'PanelError.Visible = True
                            'Timer1.Enabled = True
                            'TiempoEjecutar(10)
                        End If

                    Case 7

                        entidad = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("entidad")
                        moneda = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("moneda")
                        montoME = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeME")

                        If (montoME > 0) Then

                            If chSinReferencia.Checked = True Then
                                Dim disponible As Double = 0
                                If (moneda = "EXTRANJERA") Then
                                    montoMN = Math.Round(Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeME") * CDec(Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("tc")), 2)
                                    TotalDGV()
                                Else
                                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                                    lblEstado.Text = "la cuenta seleccionada es Nacional!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                End If
                            Else
                                If (moneda = "EXTRANJERA") Then
                                    If (entidad = txtCF_name.Text) Then
                                        montoAperturaME = Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeME")
                                        If (montoAperturaME <= CDec(SaldoEFMN.Text)) Then
                                            Dim disponible As Double = 0

                                            montoMN = Math.Round(Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("importeME") * CDec(Me.dgvCuentasApertura.Table.CurrentRecord.GetValue("tc")), 2)
                                            TotalDGV()
                                        Else
                                            lblEstado.Text = "El importe ingresado excede al permitido!"
                                            PanelError.Visible = True
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeMN", 0.0)
                                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                                        End If
                                    Else
                                        lblEstado.Text = "La entidad selecciona no coincide!"
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                        Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", montoME)
                                    End If

                                Else
                                    Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                                    lblEstado.Text = "la cuenta seleccionada es Nacional!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                End If
                            End If

                        Else
                            Me.dgvCuentasApertura.Table.CurrentRecord.SetValue("importeME", 0.0)
                            'lblEstado.Text = "El importe no debe ser negativo!"
                            TotalDGV()
                            'PanelError.Visible = True
                            'Timer1.Enabled = True
                            'TiempoEjecutar(10)
                        End If
                End Select
            End If
        End If
    End Sub
End Class