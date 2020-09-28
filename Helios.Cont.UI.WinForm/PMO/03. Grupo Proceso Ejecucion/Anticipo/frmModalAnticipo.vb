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
Public Class frmModalAnticipo


#Region "Attributes"
    Inherits frmMaster
    Public ManipulacionEstado As String
    Public Property ListaAsientonTransito As New List(Of asiento)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "ANT", "ANTICIPOS", GEstableciento.IdEstablecimiento)
        ObtenerTablaGenerales()
        txtFechaComprobante.Value = Date.Now

    End Sub
#End Region

#Region "Methods"
    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        'cbotipoOperacion.ValueMember = "codigoDetalle"
        'cbotipoOperacion.DisplayMember = "descripcion"
        'cbotipoOperacion.DataSource = tablaSA.GetListaTablaDetalle(12, "1")
        'cbotipoOperacion.SelectedValue = -1

        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")
        cboMoneda.SelectedValue = -1

        cbotipoOperacion.ValueMember = "codigoDetalle"
        cbotipoOperacion.DisplayMember = "descripcion"
        cbotipoOperacion.DataSource = tablaSA.GetListaTablaDetalleMotivo(12, "1", "103")

        cboEntidad.ValueMember = "codigoDetalle"
        cboEntidad.DisplayMember = "descripcion"
        cboEntidad.DataSource = tablaSA.GetListaTablaDetalle(3, "1")

    End Sub

    Sub calculos()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value

        If tcambio > 0 Then
            Imn = txtImporteCompramn.Value
            txtImporteComprame.Value = Math.Round(Imn / tcambio, 2)
        End If

    End Sub

    Sub CalculoDolares()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value

        If tcambio > 0 Then
            Imn = txtImporteComprame.Value
            txtImporteCompramn.Value = Math.Round(Imn * tcambio, 2)
        End If
    End Sub

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


    Private Sub cargarCtasFinan()
        If cboTipoCuenta.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")

            ListaDocPago(lista)
        ElseIf cboTipoCuenta.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)

        ElseIf cboTipoCuenta.Text = "TARJETA DE CREDITO" Then
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
        cboTipoDocumento.DataSource = tabla
        cboTipoDocumento.ValueMember = "codigoDetalle"
        cboTipoDocumento.DisplayMember = "descripcion"
        cboTipoDocumento.SelectedValue = "001"
        'CargarDAtos()
    End Sub

    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros

        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)
        estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(idCaja, txtFechaComprobante.Value)
        If (Not IsNothing(estadoBL)) Then
            cboMoneda.SelectedValue = estadoBL.codigo
            txtCuentaOrigen.Text = estadoBL.cuenta
            lblDeudaPendienteme.Text = estadoSaldoBL.importeBalanceME
            lblDeudaPendientemn.Text = estadoSaldoBL.importeBalanceMN
            GroupBox5.Visible = True
            Select Case cboMoneda.SelectedValue
                Case 1
                    pnImpMEDisp.Visible = False
                    pnTipoCambio.Visible = False
                    pnImpMNDisp.Visible = True
                    PictureBox5.Visible = False
                    PictureBox4.Visible = True
                    pnImpMEDisp.Location = New Point(170, 19)
                    pnImpMNDisp.Location = New Point(8, 19)
                    pnTipoCambio.Location = New Point(250, 22)
                    pnNacional.Location = New Point(53, 22)
                    pnExtranjero.Location = New Point(400, 22)
                    pnExtranjero.Enabled = False
                    pnNacional.Enabled = True
                    pnExtranjero.Visible = False
                    txtTipoCambio.Value = TmpTipoCambio
                    pnAnticipoDetalle.Enabled = True
                Case 2

                    pnImpMNDisp.Visible = False
                    pnTipoCambio.Visible = True
                    pnImpMEDisp.Visible = True
                    PictureBox5.Visible = True
                    PictureBox4.Visible = False
                    pnImpMEDisp.Location = New Point(9, 19)
                    pnImpMNDisp.Location = New Point(170, 19)
                    pnTipoCambio.Location = New Point(250, 22)
                    pnNacional.Location = New Point(400, 22)
                    pnExtranjero.Location = New Point(53, 22)
                    txtTipoCambio.Value = TmpTipoCambioTransaccionVenta
                    pnTipoCambio.Enabled = False
                    pnNacional.Visible = False
                    pnTipoCambio.Visible = False
                    'pnNacional.Visible = False
                    pnExtranjero.Visible = True
                    pnExtranjero.Enabled = True
                    pnNacional.Enabled = False
                    pnAnticipoDetalle.Enabled = True
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
            cboMoneda.SelectedValue = -1

        Catch ex As Exception

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

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9901"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante) ' txtNumeroComp.Text
            .idOrden = Nothing
            .tipoOperacion = cboTipoDocumento.SelectedValue
            .usuarioActualizacion = cboDepositoHijo.SelectedValue
            .fechaActualizacion = txtFechaComprobante.Value
        End With

        With ndocumentoAnticipo

            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoDocumento = "9901"
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .numeroDoc = .IdNumeracion
            .fechaDoc = txtFechaComprobante.Value
            .fechaPeriodo = PeriodoGeneral
            .tipoOperacion = cboTipoDocumento.SelectedValue
            .tipoAnticipo = "AR"
            .razonSocial = CInt(txtCliente2.Tag)
            .TipoCambio = txtTipoCambio.Value
            .Moneda = cboMoneda.SelectedValue
            .importeMN = txtImporteCompramn.Value
            .importeME = txtImporteComprame.Value
            .idEntidadFinanciera = cboDepositoHijo.SelectedValue
            '.idEntidadFinanciera = DirectCast(Me.cboEntidades.SelectedItem, Categoria).Id
            .usuarioModificacion = cboDepositoHijo.SelectedValue
            .fechaActualizacion = txtFechaComprobante.Value
        End With
        ndocumento.documentoAnticipo = ndocumentoAnticipo

        With ndocumentoAnticipoDetalle
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .codigoOperacion = "103"
            .descripcion = "Anticipos Recibidos"
            .importeMN = txtImporteCompramn.Value
            .importeME = txtImporteComprame.Value
            .usuarioModificacion = cboDepositoHijo.SelectedValue
            .fechaActualizacion = txtFechaComprobante.Value
        End With
        ndocumento.documentoAnticipo.documentoAnticipoDetalle.Add(ndocumentoAnticipoDetalle)
        ListaAsientonTransito.Add(GeneraraAsiento)
        ndocumento.asiento = ListaAsientonTransito
        DocCaja = ComprobanteCaja()

        documentoAnticipoSA.SaveAnticipoSL(ndocumento, DocCaja)
        lblEstado.Text = "Caja registrada correctamente!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        Dispose()
    End Sub

    Public Sub UpdateAnticipo()

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

        With ndocumento

            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .idDocumento = lblIdDocumento.Text
            .tipoDoc = "9901"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = 0 ' txtNumeroComp.Text
            .idOrden = Nothing
            .tipoOperacion = "103"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = txtFechaComprobante.Value
        End With

        With ndocumentoAnticipo
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento

            .tipoDocumento = "9901"
            .numeroDoc = IIf(IsNothing(GConfiguracion.ValorActual), 0, GConfiguracion.ValorActual)
            .fechaDoc = txtFechaComprobante.Value
            .fechaPeriodo = PeriodoGeneral
            .tipoOperacion = "103"
            .tipoAnticipo = "AR"
            .razonSocial = CInt(txtCliente2.Tag)
            .TipoCambio = txtTipoCambio.Value
            .Moneda = cboMoneda.SelectedValue
            .importeMN = txtImporteCompramn.Value
            .importeME = txtImporteComprame.Value
            '.idEntidadFinanciera = txtCajaOrigen.ValueMember
            .idEntidadFinanciera = DirectCast(Me.cboEntidad.SelectedItem, Categoria).Id
            .usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = txtFechaComprobante.Value
        End With
        ndocumento.documentoAnticipo = ndocumentoAnticipo

        With ndocumentoAnticipoDetalle
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .codigoOperacion = "103"
            .descripcion = "Voucher contable " & "1"
            .importeMN = txtImporteCompramn.Value
            .importeME = txtImporteComprame.Value
            .usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = txtFechaComprobante.Value
        End With
        ListaDetalle.Add(ndocumentoAnticipoDetalle)
        ListaAsientonTransito.Add(GeneraraAsiento)
        ndocumento.asiento = ListaAsientonTransito
        DocCaja = ComprobanteCaja()

        documentoAnticipoSA.UpdateAnticipoSL(ndocumento, DocCaja)
        lblEstado.Text = "Caja registrada correctamente!"


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

        nDocumentoCaja.fechaProceso = txtFechaComprobante.Value
        nDocumentoCaja.tipoDoc = "9901"
        nDocumentoCaja.nroDoc = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante) ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = cbotipoOperacion.SelectedValue
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.tipoMovimiento = MovimientoCaja.EntradaDinero
        objCaja.IdProveedor = CInt(txtCliente2.Tag)
        objCaja.codigoLibro = "1"
        objCaja.codigoProveedor = CInt(txtCliente2.Tag)
        objCaja.TipoDocumentoPago = cboTipoDocumento.SelectedValue
        objCaja.tipoDocPago = cboTipoDocumento.SelectedValue
        objCaja.periodo = PeriodoGeneral
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2") ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        If (txtDescripcion.Text.Length > 0) Then
            objCaja.glosa = txtDescripcion.Text
        Else
            objCaja.glosa = Glosa()
        End If

        If cboTipoDocumento.SelectedValue = "001" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = txtCuentaCorriente.Text
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = cboEntidad.SelectedValue
            objCaja.fechaProceso = txtFechaComprobante.Value
            objCaja.fechaCobro = Date.Now
            objCaja.entregado = "SI"

        ElseIf cboTipoDocumento.SelectedValue = "007" Then ' cheques
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaProceso = txtFechaEmision.Value
            objCaja.fechaCobro = txtFechaCobro.Value
            objCaja.entregado = "NO"
        ElseIf cboTipoDocumento.SelectedValue = "111" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaProceso = txtFechaEmision.Value
            objCaja.fechaCobro = txtFechaCobro.Value
            objCaja.entregado = "NO"
        ElseIf cboTipoDocumento.SelectedValue = "109" Then
            objCaja.numeroOperacion = txtNumOper.Text.Trim
            objCaja.ctaCorrienteDeposito = Nothing
            objCaja.ctaIntebancaria = Nothing
            objCaja.bancoEntidad = Nothing
            objCaja.fechaCobro = txtFechaComprobante.Value
            objCaja.fechaProceso = Date.Now
            objCaja.entregado = "NO"
        End If
        objCaja.tipoCambio = txtTipoCambio.Value
        objCaja.montoSoles = txtImporteCompramn.Value
        objCaja.montoUsd = txtImporteComprame.Value
        objCaja.entidadFinanciera = cboDepositoHijo.SelectedValue
        objCaja.tipoOperacion = "103"
        objCaja.movimientoCaja = "AR"
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja


        Select Case cboMoneda.SelectedValue
            Case 1
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = txtFechaComprobante.Value
                objCajaDetalle.idItem = Nothing
                objCajaDetalle.DetalleItem = Nothing
                objCajaDetalle.montoSoles = CDec(txtImporteCompramn.Value) 'CDec(txtTotalmn.Text)
                objCajaDetalle.montoUsd = CDec(txtImporteComprame.Value) ' CDec(txtTotalme.Text)
                objCajaDetalle.entregado = "SI"
                objCajaDetalle.moneda = cboMoneda.SelectedValue
                objCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                objCajaDetalle.usuarioModificacion = cboDepositoHijo.SelectedValue
                objCajaDetalle.fechaModificacion = DateTime.Now
                ListaDetalle.Add(objCajaDetalle)
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle

            Case 2
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = txtFechaComprobante.Value
                objCajaDetalle.idItem = Nothing
                objCajaDetalle.DetalleItem = Nothing
                objCajaDetalle.montoSoles = CDec(txtImporteCompramn.Value) 'CDec(txtTotalmn.Text)
                objCajaDetalle.montoUsd = CDec(txtImporteComprame.Value) ' CDec(txtTotalme.Text)
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
        Return "Por voucher contable " & txtCliente2.Text.Trim
    End Function

    Private Function GeneraraAsiento() As asiento
        Dim nAsiento As New asiento
        Dim movimiento As movimiento
        Try
            nAsiento = New asiento
            nAsiento.idDocumento = 0
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = txtCliente2.Tag
            nAsiento.nombreEntidad = txtCliente2.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nAsiento.fechaProceso = txtFechaComprobante.Value
            nAsiento.periodo = PeriodoGeneral
            nAsiento.codigoLibro = "1"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Finanzas
            nAsiento.importeMN = txtImporteCompramn.Value
            nAsiento.importeME = txtImporteComprame.Value
            nAsiento.glosa = Glosa()
            nAsiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.fechaActualizacion = DateTime.Now


            movimiento = New movimiento With {
                  .cuenta = "122",
                  .descripcion = "Anticipos por pagar",
                  .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
                  .monto = txtImporteCompramn.Value,
                  .montoUSD = txtImporteComprame.Value,
                  .fechaActualizacion = DateTime.Now,
                  .usuarioActualizacion = usuario.IDUsuario}
            nAsiento.movimiento.Add(movimiento)
            '.cuenta = "122"= txtCuenta.Text,
            movimiento = New movimiento With {
                .cuenta = txtCuentaOrigen.Text,
                .descripcion = cboDepositoHijo.Text,
                .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
                .monto = txtImporteCompramn.Value,
                .montoUSD = txtImporteComprame.Value,
                .fechaActualizacion = DateTime.Now,
                .usuarioActualizacion = usuario.IDUsuario}
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
    '            txtImporteCompramn.Value = .importeMN
    '            txtImporteComprame.Value = .importeME
    '            txtTipoCambio.Value = .TipoCambio

    '            'PROVEEDOR
    '            nEntidad = objEntidad.UbicarEntidadPorID(.razonSocial).First()
    '            txtRuc2.Text = nEntidad.nrodoc
    '            txtCuenta.Text = nEntidad.cuentaAsiento
    '            txtCliente2.Tag = nEntidad.idEntidad
    '            txtCliente2.Text = nEntidad.nombreCompleto

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

    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim alEFSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim establecimientoSA As New establecimientoSA
        Dim entidadsa As New entidadSA
        Try
            With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)

                'Select Case .tipoMovimiento
                '    Case MovimientoCaja.SalidaDinero
                '        lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                '    Case MovimientoCaja.EntradaDinero
                '        lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                'End Select

                lblIdDocumento.Text = .idDocumento
                txtFechaComprobante.Value = .fechaProceso
                Dim codigoDoc = .tipoDocPago

                cboMoneda.SelectedValue = .moneda


                Dim A As String
                A = .codigoLibro
                cbotipoOperacion.SelectedValue = A
                Select Case .tipoOperacion
                    Case 17
                        cbotipoOperacion.Text = "APORTES"

                End Select

                Select Case .moneda
                    Case 1
                        cboMoneda.Text = "NACIONAL"
                    Case 2
                        cboMoneda.Text = "EXTRANJERO"
                End Select

                With alEFSA.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)
                    'txtEstablecimientoDestino.ValueMember = .idEstablecimiento
                    'txtEstablecimientoDestino.Text = establecimientoSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
                    'txtCajaOrigen.ValueMember = .idestado
                    'txtCajaOrigen.Text = .descripcion
                    Select Case .tipo
                        Case CuentaFinanciera.Banco
                            cboTipoCuenta.Text = "CUENTAS EN BANCO"
                        Case CuentaFinanciera.Efectivo
                            cboTipoCuenta.Text = "CUENTAS EN EFECTIVO"

                        Case CuentaFinanciera.Tarjeta_Credito
                            cboTipoCuenta.Text = "TARJETA DE CREDITO"
                    End Select

                    cboDepositoHijo.SelectedValue = .idestado
                    cargarDatosCuenta(cboDepositoHijo.SelectedValue)

                    txtCuenta.Text = .cuenta

                End With
                cboTipoDocumento.SelectedValue = codigoDoc
                Select Case codigoDoc
                    Case "001"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito

                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                            txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        End If

                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro

                    Case "007" 'cheques

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                            txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                    Case "111"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                            txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro

                    Case "109"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        If (Not IsNothing(.bancoEntidad)) Then
                            cboEntidad.SelectedValue = .bancoEntidad
                            txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        End If
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                End Select

                txtTipoCambio.Value = .tipoCambio
                txtImporteCompramn.Value = .montoSoles
                txtImporteComprame.Value = .montoUsd
                txtDescripcion.Text = .glosa

                With entidadsa.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, "CL", .codigoProveedor)
                    txtCliente2.Text = .nombreCompleto
                    txtRuc2.Text = .nrodoc
                End With

            End With

            'With documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento).First
            '    lblSecuenciaDetalle.Text = .secuencia
            'End With
            ' cboMovimiento.Enabled = False
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

#End Region

#Region "Events"




    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If lsvTipoCambio.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub dropDownBtn_Click(sender As Object, e As EventArgs)
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

    End Sub

    Private Sub frmModalAnticipo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs)
        cboDepositoHijo.Tag = 1
    End Sub



    Private Sub nudMonedaExtranjero_ValueChanged(sender As Object, e As EventArgs)
        Select Case cboMoneda.SelectedValue
            Case 1
                calculos()
            Case 2
                CalculoDolares()
        End Select
    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs)
        cboMoneda.SelectedValue = -1
        txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        txtImporteCompramn.Value = 0
        cboTipoDocumento.SelectedValue = -1
        txtDescripcion.Clear()
        'cbotipoOperacion.SelectedValue = -1
        txtNumOper.Clear()
        cargarCtasFinan()
        pnAnticipoDetalle.Enabled = False
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim value As Object = Me.cboDepositoHijo.SelectedValue
        txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        txtImporteCompramn.Value = 0
        txtImporteComprame.Value = 0
        txtCliente2.Clear()
        txtRuc2.Clear()
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

    Private Sub cboTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        If cboTipoDocumento.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDocumento.SelectedValue = "109" Then 'EFECTIVO (que se genere un vocher de caja con los datos del comprobante que se está pagando) 
                pnEntidad.Visible = False
                pnFecha.Visible = False
                Label17.Text = "NRO. VOUCHER:"

            ElseIf cboTipoDocumento.SelectedValue = "007" Then ' CHEQUES
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            ElseIf cboTipoDocumento.SelectedValue = "001" Then ' DEPOSITO EN CUENTA 
                pnEntidad.Visible = True
                pnFecha.Visible = False
                Label17.Text = "NRO. OPERACIÓN:"

            ElseIf cboTipoDocumento.SelectedValue = "111" Then ' CHEQUE NO NEGOCIABLE 
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            End If
        End If
    End Sub

    Private Sub nudMonedaNacional_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteCompramn.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtTipoCambio.Select()
                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub nudMonedaNacional_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteCompramn.ValueChanged
        Select Case cboMoneda.SelectedValue
            Case 1
                calculos()
            Case 2
                CalculoDolares()
        End Select
    End Sub

    Private Sub nudMonedaExtranjero_ValueChanged_1(sender As Object, e As EventArgs) Handles txtImporteComprame.ValueChanged
        Select Case cboMoneda.SelectedValue
            Case 1
                calculos()
            Case 2
                CalculoDolares()
        End Select
    End Sub

    Private Sub nudMonedaExtranjero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteComprame.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtTipoCambio.Select()
                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        Select Case cboMoneda.SelectedValue
            Case 1
                calculos()
            Case 2
                CalculoDolares()
        End Select
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If Not Me.PopupControlContainer2.IsShowing() Then
            ' Let the popup align around the source textBox.
            Me.PopupControlContainer2.ParentControl = Me.txtImporteCompramn
            ' Passing Point.Empty will align it automatically around the above ParentControl.
            Me.PopupControlContainer2.ShowPopup(Point.Empty)

        End If

        If txtImporteCompramn.Text.Trim.Length > 0 Then
            Me.PopupControlContainer2.ParentControl = Me.txtImporteCompramn
            Me.PopupControlContainer2.ShowPopup(Point.Empty)
            CargarEntidadesXtipo()
        End If
    End Sub

    Public Sub CargarEntidadesXtipo()
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        Dim sumatoria As Decimal
        Try

            Select Case cboMoneda.SelectedValue
                Case 1
                    If (txtImporteCompramn.Value <= lblDeudaPendientemn.Value) Then
                        lsvTipoCambio.Items.Clear()
                        lsvTipoCambio.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
                        lsvTipoCambio.Columns.Add("T/C", 40, HorizontalAlignment.Left) '1
                        lsvTipoCambio.Columns.Add("Importe ME", 65, HorizontalAlignment.Left) '1
                        lsvTipoCambio.Columns.Add("Importe MN", 65, HorizontalAlignment.Left) '1

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteCompramn.Value, cboDepositoHijo.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(CDec(i.diferTipoCambio).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoUsd).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoSoles).ToString("N2"))
                            lsvTipoCambio.Items.Add(n)
                            sumatoria += i.montoSoles
                        Next
                        txtImporteCompramn.Value = sumatoria
                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual! "
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteCompramn.Value = 0.0
                        txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                    End If
                Case 2
                    If (txtImporteComprame.Value <= lblDeudaPendienteme.Value) Then
                        lsvTipoCambio.Items.Clear()
                        lsvTipoCambio.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
                        lsvTipoCambio.Columns.Add("T/C", 40, HorizontalAlignment.Left) '1
                        lsvTipoCambio.Columns.Add("Importe ME", 65, HorizontalAlignment.Left) '1
                        lsvTipoCambio.Columns.Add("Importe MN", 65, HorizontalAlignment.Left) '1

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(CDec(i.diferTipoCambio).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoUsd).ToString("N2"))
                            n.SubItems.Add(CDec(i.montoSoles).ToString("N2"))
                            lsvTipoCambio.Items.Add(n)
                            sumatoria += i.montoSoles
                        Next
                        txtImporteCompramn.Value = sumatoria
                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteComprame.Value = 0.0
                        txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                    End If
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If Not Me.PopupControlContainer2.IsShowing() Then
            ' Let the popup align around the source textBox.
            Me.PopupControlContainer2.ParentControl = Me.txtImporteComprame
            ' Passing Point.Empty will align it automatically around the above ParentControl.
            Me.PopupControlContainer2.ShowPopup(Point.Empty)

        End If

        If txtImporteCompramn.Text.Trim.Length > 0 Then
            Me.PopupControlContainer2.ParentControl = Me.txtImporteComprame
            Me.PopupControlContainer2.ShowPopup(Point.Empty)
            CargarEntidadesXtipo()
        End If
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

    Private Sub txtCuentaCorriente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuentaCorriente.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                Select Case cboMoneda.SelectedValue
                    Case 1
                        txtImporteCompramn.Select()
                        txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                    Case 2
                        txtImporteComprame.Select()
                        txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim documentoCajaSA As New DocumentoCajaSA
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not cboDepositoHijo.Text.Length > 0 Then
                lblEstado.Text = "Ingrese la entidad financiera."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboDepositoHijo.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub

            End If

            If Not cbotipoOperacion.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cbotipoOperacion.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            Select Case cboMoneda.SelectedValue
                Case 1
                    If Not txtTipoCambio.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtTipoCambio.Select()
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If Not txtImporteCompramn.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                Case 2

                    If Not txtImporteComprame.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If Not txtTipoCambio.Value > 0 Then
                        lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

            End Select

            If cboTipoDocumento.SelectedValue = "001" Then
                If Not cboTipoDocumento.Text.Length > 0 Then
                    lblEstado.Text = "Ingrese tipo documento."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    cboTipoDocumento.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de cuenta."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtCuentaCorriente.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If


            ElseIf cboTipoDocumento.SelectedValue = "007" Then

            ElseIf cboTipoDocumento.SelectedValue = "109" Then
                If Not cboTipoDocumento.Text.Length > 0 Then
                    lblEstado.Text = "Ingrese tipo documento."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    cboTipoDocumento.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

            ElseIf cboTipoDocumento.SelectedValue = "111" Then

            End If

            If Not txtCliente2.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un proveedor."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtRuc2.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un proveedor valido."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If



            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                lblEstado.Text = "Proceso normal"
                Grabar()
            Else
                UpdateAnticipo()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message

            Me.Cursor = Cursors.Arrow
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboTipoCuenta.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        txtImporteComprame.Value = 0
        txtImporteCompramn.Value = 0
        txtTipoCambio.Value = 0
        txtNumOper.Clear()
        cboDepositoHijo.SelectedValue = -1
        cboMoneda.SelectedValue = -1
        'txtCuentaCorriente.Clear()
        cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim value As Object = Me.cboDepositoHijo.SelectedValue

        If IsNumeric(value) Then
            txtImporteComprame.Value = 0
            txtImporteCompramn.Value = 0
            txtTipoCambio.Value = 0
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            cargarDatosCuenta(CInt(value))
        Else
            'txtFondoEF.DecimalValue = 0
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
        f.CaptionLabels(0).Text = "Cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, entidad)
            'Dim c = CType(f.Tag, entidad)
            txtCliente2.Text = c.nombreCompleto
            txtCliente2.Tag = c.idEntidad
            txtRuc2.Text = c.nrodoc
            txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

#End Region
End Class