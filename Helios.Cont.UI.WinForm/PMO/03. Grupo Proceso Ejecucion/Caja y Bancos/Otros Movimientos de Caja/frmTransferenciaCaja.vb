Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class frmTransferenciaCaja
    Inherits frmMaster
    Public fecha As DateTime
    Public ManipulacionEstado As String
    Dim sumatoria As Decimal
    Public Property ListaAsientos As New List(Of asiento)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        '' Add any initialization after the InitializeComponent() call.
        ObtenerTablaGenerales()
        txtFechaComprobante.Value = Date.Now
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "TF", Me.Text, GEstableciento.IdEstablecimiento)
        cboTipoOrigen.SelectedIndex = -1
        cboTipoDestino.SelectedIndex = -1
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

#Region "DatosEntidades"
    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA
        cbotipoOperacion.ValueMember = "codigoDetalle"
        cbotipoOperacion.DisplayMember = "descripcion"
        cbotipoOperacion.DataSource = tablaSA.GetListaTablaDetalleMotivo(12, "1", "9911")
    End Sub

    Private Sub cargarCtasFinan()
        If cboTipoOrigen.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            Dim lista As New List(Of String)
            lista.Add("003")
            ListaDocPago(lista)
        ElseIf cboTipoOrigen.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            Dim lista As New List(Of String)
            lista.Add("003")
            ListaDocPago(lista)
        ElseIf cboTipoOrigen.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo("TC")
            cboDepositoHijo.Enabled = True
            Dim lista As New List(Of String)
            lista.Add("003")
            ListaDocPago(lista)
        End If


    End Sub

    Private Sub cargarCtasFinanDestino(cbomoneda As Integer)
        If cboTipoDestino.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipoDestino("EF", "1", cboEntidadFinancieraOrigen.SelectedValue)
          
        ElseIf cboTipoDestino.Text = "CUENTAS EN BANCO" Then
            'CargarCajasTipoDestino("BC", cbomoneda)
            CargarCajasTipoDestino("BC", "1", cboEntidadFinancieraOrigen.SelectedValue)

        ElseIf cboTipoDestino.Text = "TARJETA DE CREDITO" Then
            'CargarCajasTipoDestino("BC", cbomoneda)
            CargarCajasTipoDestino("TC", "1", cboEntidadFinancieraOrigen.SelectedValue)
        End If
    End Sub

    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros

        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)
        estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(idCaja, txtFechaComprobante.Value)
        If (Not IsNothing(estadoBL)) Then
            cboMonedaOrigen.SelectedValue = estadoBL.codigo
            txtCuentaO.Text = estadoBL.cuenta
            lblDeudaPendienteme.Text = estadoSaldoBL.importeBalanceME
            lblDeudaPendientemn.Text = estadoSaldoBL.importeBalanceMN

            Select Case cboMonedaOrigen.SelectedValue
                Case 1
                    pnMNOrigen.Visible = True
                    pnMNDestino.Visible = True
                    pnMEDestino.Visible = False
                    pnMEOrigen.Visible = False
                    PictureBox4.Visible = True
                    PictureBox1.Visible = True
                    pnImpMEDisp.Location = New Point(170, 15)
                    pnImpMNDisp.Location = New Point(9, 15)
                    pnImpMNDisp.Visible = True
                    pnImpMEDisp.Visible = False
                    pnMNOrigen.Location = New Point(28, 72)
                    pnMEOrigen.Location = New Point(28, 72)
                    pnMEDestino.Location = New Point(28, 72)
                    pnMNDestino.Location = New Point(28, 72)

                Case 2

                    pnImpMEDisp.Location = New Point(9, 15)
                    pnImpMNDisp.Location = New Point(170, 15)
                    pnMNOrigen.Visible = False
                    pnMNDestino.Visible = False
                    pnMEDestino.Visible = True
                    pnMEOrigen.Visible = True
                    PictureBox4.Visible = True
                    PictureBox1.Visible = True
                    pnImpMNDisp.Visible = False
                    pnImpMEDisp.Visible = True
                    pnMNOrigen.Location = New Point(28, 72)
                    pnMEOrigen.Location = New Point(28, 72)
                    pnMEDestino.Location = New Point(28, 72)
                    pnMNDestino.Location = New Point(28, 72)
                     
            End Select

        End If
    End Sub

    Private Sub cargarDatosCuentaDestino(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros

        If ((idCaja) <> 0) Then
            estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)
            If (Not IsNothing(estadoBL)) Then
                If (cboEntidadFinancieraOrigen.Text.Length > 0) Then
                    If (cboEntidadFinancieraDestino.Text.Length > 0) Then
                        txtCuentaD.Text = estadoBL.cuenta
                        txtDescripcion.Text = "TRANSFERENCIA DE DINERO: DE " & cboEntidadFinancieraOrigen.Text & "  A  " & cboEntidadFinancieraDestino.Text
                    End If
                End If

            End If
        End If

        '    'Select Case cboMonedaDestino.SelectedValue
        '    '    Case 1

        '    Select Case cboMonedaOrigen.SelectedValue
        '        Case 1
        '            'pnTCDestino.Visible = False
        '            'txtTipoCambioDestino.Visible = True
        '            pnMEDestino.Visible = True
        '            pnMNDestino.Visible = True
        '            'pnTCDestino.Visible = True
        '            'pnMNDestino.Location = New Point(63, 26)
        '            'pnMEDestino.Location = New Point(514, 26)
        '            PictureBox1.Visible = False
        '            PictureBox4.Visible = False
        '            pnMNOrigen.Location = New Point(63, 19)
        '            pnMEOrigen.Location = New Point(330, 19)
        '            pnMEDestino.Location = New Point(330, 19)
        '            pnMNDestino.Location = New Point(63, 19)

        '        Case 2
        '            pnMEDestino.Visible = True
        '            pnMNDestino.Visible = True

        '            pnMNDestino.Location = New Point(63, 26)
        '            pnMEDestino.Location = New Point(330, 26)

        '            PictureBox4.Visible = False
        '            PictureBox1.Visible = True
        '    End Select
        '    '    Case 2
        '    'pnMEDestino.Visible = True
        '    'pnMNDestino.Visible = True
        '    'PictureBox4.Visible = True
        '    'PictureBox1.Visible = False
        '    'pnMNDestino.Location = New Point(330, 26)
        '    'pnMEDestino.Location = New Point(63, 26)

        '    'End Select



        'End If
    End Sub

    Public Sub CargarCajasTipoDestino(strBusqueda As String, intMoneda As Integer, cuentaOrigen As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try
            Me.cboEntidadFinancieraDestino.DataSource = Nothing
            'cboEntidadFinancieraDestino.Items.Clear()
            Me.cboEntidadFinancieraDestino.DataSource = estadoSA.ObtenerEFPorCuentaFinancieraDestino(GEstableciento.IdEstablecimiento, strBusqueda, cuentaOrigen, cboMonedaOrigen.SelectedValue)
            Me.cboEntidadFinancieraDestino.DisplayMember = "descripcion"
            Me.cboEntidadFinancieraDestino.ValueMember = "idestado"
            cboEntidadFinancieraDestino.SelectedValue = -1
            cboEntidadFinancieraDestino.Tag = 1

            'cboEntidadFinancieraDestino.Items.Clear()
            'cboMonedaDestino.ValueMember = "codigoDetalle"
            'cboMonedaDestino.DisplayMember = "descripcion"
            'cboMonedaDestino.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            'cboMonedaDestino.SelectedValue = -1

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try
            Me.cboEntidadFinancieraOrigen.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = strBusqueda,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Me.cboEntidadFinancieraOrigen.DisplayMember = "descripcion"
            Me.cboEntidadFinancieraOrigen.ValueMember = "idestado"
            cboEntidadFinancieraOrigen.SelectedValue = -1
            cboEntidadFinancieraOrigen.Tag = 0

            cboMonedaOrigen.ValueMember = "codigoDetalle"
            cboMonedaOrigen.DisplayMember = "descripcion"
            cboMonedaOrigen.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            cboMonedaOrigen.SelectedValue = -1

            'estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID()
            'txtMoneda.Tag = estadoBL.codigo
            'txtMoneda.Text = estadoBL.descripcion

        Catch ex As Exception

        End Try
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
        cboTipoDoc.SelectedValue = "003"

    End Sub
#End Region

#Region "Manipulación Data"


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

    Public Function Glosa() As String
        Return "Por transferencia de cajas con fecha " & fecha
    End Function

    Sub Calculo()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0



      
                If tcambio = 0 Then
                    Imn = txtFondoMN.Value
                    txtFondoME.Value = Math.Round(Imn / tcambio, 2)
                    txtFondoMNDestino.Value = txtFondoMN.Value
            txtFondoMEDestino.Value = txtFondoME.Value
                End If
        '    Case 1
        '        If tcambio > 0 Then
        '            Imn = txtFondoMN.Value
        '            txtFondoME.Value = Math.Round(Imn / tcambio, 2)
        '            txtFondoMNDestino.Value = txtFondoMN.Value
        '            txtTipoCambioDestino.Value = txtTipoCambio.Value
        '            txtFondoMEDestino.Value = txtFondoME.Value
        '        End If
        'End Select

    End Sub

    Public Sub AsientoContableTransferencia()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento

        asientoBL = New asiento
        asientoBL.periodo = txtPeriodo.Text
        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
        'asientoBL.idEntidad = txtCajaDestino.ValueMember
        asientoBL.idEntidad = cboEntidadFinancieraDestino.SelectedValue
        ' asientoBL.nombreEntidad = txtCajaDestino.Text
        asientoBL.nombreEntidad = cboEntidadFinancieraDestino.Text

        ' IIf(cboTipoCuentaD.Text = "EFECTIVO", "EF", "BC")

        Select Case cboTipoOrigen.SelectedItem
            Case "CUENTAS EN EFECTIVO"
                asientoBL.tipoEntidad = "EF"
            Case "CUENTAS EN BANCO"
                asientoBL.tipoEntidad = "BC"
            Case "TARJETA DE CREDITO"
                asientoBL.tipoEntidad = "TC"
        End Select

        asientoBL.fechaProceso = fecha
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"
        asientoBL.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        asientoBL.importeMN = CDec(txtFondoMN.Value)
        asientoBL.importeME = CDec(txtFondoME.Value)
        asientoBL.glosa = Glosa()


        nMovimiento = New movimiento
        nMovimiento.cuenta = txtCuentaO.Text
        'nMovimiento.descripcion = txtCajaOrigen.Text
        nMovimiento.descripcion = cboEntidadFinancieraOrigen.Text
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(txtFondoMN.Value)
        nMovimiento.montoUSD = CDec(txtFondoME.Value)
        nMovimiento.usuarioActualizacion = cboEntidadFinancieraOrigen.SelectedValue
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = txtCuentaD.Text
        'nMovimiento.descripcion = txtCajaDestino.Text
        nMovimiento.descripcion = cboEntidadFinancieraDestino.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(txtFondoMN.Value)
        nMovimiento.montoUSD = CDec(txtFondoMEDestino.Value)
        nMovimiento.usuarioActualizacion = cboEntidadFinancieraDestino.SelectedValue
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)
        ListaAsientos.Add(asientoBL)
    End Sub

    Public Sub GrabarTransferenciaCaja()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim idNumeracion As Integer

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = fecha
            idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = idNumeracion ' txtNumeroComp.Text
            .idOrden = Nothing
            .moneda = cboMonedaOrigen.SelectedValue
            .idEntidad = usuario.IDUsuario
            .entidad = usuario.CustomUsuario.Full_Name
            .tipoEntidad = "US"
            .nrodocEntidad = usuario.CustomUsuario.NroDocumento
            .tipoOperacion = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            .movimientoCaja = MovimientoCaja.TrasferenciaEntreCajas
            .codigoLibro = "1"
            .tipoOperacion = StatusTipoOperacion.TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO
            .tipoCambio = TmpTipoCambio
            '   .idDocumento = lblIdDocumento.Text
            .periodo = txtPeriodo.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = cboTipoDoc.SelectedValue
            .codigoProveedor = Nothing 'txtPersona.ValueMember
            .fechaProceso = txtFechaComprobante.Value
            .fechaCobro = txtFechaComprobante.Value
            .tipoDocPago = cboTipoDoc.SelectedValue
            .numeroDoc = idNumeracion
            .moneda = cboMonedaOrigen.SelectedValue
            '.entidadFinanciera = txtCajaOrigen.ValueMember
            .entidadFinanciera = cboEntidadFinancieraOrigen.SelectedValue
            ' .entidadFinancieraDestino = txtCajaDestino.ValueMember
            .entidadFinancieraDestino = cboEntidadFinancieraDestino.SelectedValue
            .numeroOperacion = Nothing

            Select Case cboMonedaOrigen.SelectedValue
                Case 1
                    .montoSoles = txtFondoMN.Value
                    .montoUsd = CDec(txtFondoMN.Value / TmpTipoCambio).ToString("N2")
                Case 2
                    .montoSoles = sumatoria
                    .montoUsd = txtFondoME.Value
            End Select


            If (txtDescripcion.Text.Length > 0) Then
                .glosa = txtDescripcion.Text
            Else
                .glosa = Glosa()
            End If
            .numeroOperacion = txtNumOper.Text.Trim
            .ctaCorrienteDeposito = Nothing
            'OJO FALTA
            '.bancoEntidad = cboEntidades.SelectedValue
            '.ctaIntebancaria = txtCuentaCorriente.Text
            .entregado = "SI"
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = DateTime.Now
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.fecha = fecha
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = "Por transferencia de dinero"
        ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
        ndocumentoCajaDetalle.montoSolesTransacc = txtFondoMN.Value
        ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
        ndocumentoCajaDetalle.montoUsdTransacc = txtFondoME.Value
        ndocumentoCajaDetalle.entregado = "SI"
        'ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.moneda = cboMonedaOrigen.SelectedValue
        ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
        ndocumentoCajaDetalle.idCajaPadre = 0
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

        AsientoContableTransferencia()
        ndocumento.asiento = ListaAsientos
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        documentoCajaSA.SaveGroupCajaOtrosMovimientosME(ndocumento)
        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub
#End Region
#Region "Métodos"
    'Private Sub ObtenerCuentasFinancierasPorMoneda(strIdMoneda As String)
    '    Dim cFinancieraSA As New EstadosFinancierosSA
    '    gridGroupingControl1.DataSource = cFinancieraSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, strIdMoneda)
    '    gridGroupingControl1.TableDescriptor.GroupedColumns.Add("tipo")
    '    gridGroupingControl1.TableDescriptor.Relations.Clear()
    '    gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '    gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    gridGroupingControl1.Appearance.AnyRecordFieldCell.Enabled = False
    '    gridGroupingControl1.GroupDropPanel.Visible = False
    'End Sub

    'Public Sub CargarListas()
    '    Dim tablaSA As New tablaDetalleSA
    '    cboTipoDoc.DisplayMember = "descripcion"
    '    cboTipoDoc.ValueMember = "codigoDetalle"
    '    cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(1, "1")

    '    cboMoneda.DisplayMember = "descripcion"
    '    cboMoneda.ValueMember = "codigoDetalle"
    '    cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")


    'End Sub
#End Region

    Private Sub frmTransferenciaCaja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub txtFondoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoMN.ValueChanged
        If (txtFondoMN.Value <= lblDeudaPendientemn.Value) Then
            CargarEntidadesXMN()
        Else
            txtFondoMN.Value = 0.0
            txtFondoMNDestino.Value = 0.0
            lblEstado.Text = "Debe ingresar un importe permitido!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs)
        If (cboEntidadFinancieraDestino.SelectedValue > 0) Then
            Calculo()
        Else
            lblEstado.Text = "Debe ingresar una cuenta destino!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Exit Sub
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PanelError.Visible = False
        Timer1.Enabled = False
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

    Private Sub cboTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedValueChanged
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
        End If
    End Sub

    Private Sub cboTipoOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoOrigen.SelectedValueChanged
        cboMonedaOrigen.SelectedValue = -1
        txtFondoMN.Value = 0
        txtFondoME.Value = 0
        txtFondoMEDestino.Value = 0
        txtFondoMNDestino.Value = 0
        txtDescripcion.Clear()
        cboTipoDestino.Text = ""
        cboEntidadFinancieraDestino.SelectedValue = -1
        cboTipoDestino.SelectedIndex = -1
        txtDescripcion.Text = ""
        txtNumOper.Clear()
        cargarCtasFinan()
    End Sub

    Private Sub cboEntidadFinancieraOrigen_Click(sender As Object, e As EventArgs) Handles cboEntidadFinancieraOrigen.Click
        cboEntidadFinancieraOrigen.Tag = 1
    End Sub

    Private Sub cboTipoDestino_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDestino.SelectedValueChanged
        txtDescripcion.Text = ""
        cargarCtasFinanDestino(cboMonedaOrigen.SelectedValue)
    End Sub

    Private Sub cboEntidadFinancieraOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadFinancieraOrigen.SelectedIndexChanged
        Dim value As Object = Me.cboEntidadFinancieraOrigen.SelectedValue
        cboMonedaOrigen.SelectedValue = -1
        txtFondoMN.Value = 0
        txtFondoME.Value = 0
        txtFondoMEDestino.Value = 0
        txtFondoMNDestino.Value = 0
        txtDescripcion.Clear()
        txtNumOper.Clear()
        cboEntidadFinancieraDestino.SelectedValue = -1
        cboTipoDestino.SelectedIndex = -1
        txtDescripcion.Text = ""
        cboTipoDestino.Text = ""
        If (cboEntidadFinancieraOrigen.Tag = 1) Then
            If IsNumeric(value) Then
                cargarDatosCuenta(CInt(value))
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboEntidadFinancieraDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadFinancieraDestino.SelectedIndexChanged
        If ((cboEntidadFinancieraDestino.Tag = 1)) Then
            cargarDatosCuentaDestino(cboEntidadFinancieraDestino.SelectedValue)
        End If
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs)
        'If e.PopupCloseType = PopupCloseType.Done Then
        '    If lsvProveedor.SelectedItems.Count > 0 Then
        '        'Me.txtSaldoMN.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
        '    End If
        'End If
        '' Set focus back to textbox.
        'If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '    'Me.txtProveedor.Focus()
        'End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        'If Not Me.popupControlContainer1.IsShowing() Then
        '     Let the popup align around the source textBox.
        '    Me.popupControlContainer1.ParentControl = Me.txtSaldoMN
        '     Passing Point.Empty will align it automatically around the above ParentControl.
        '    Me.popupControlContainer1.ShowPopup(Point.Empty)

        'End If

        'If txtSaldoMN.Text.Trim.Length > 0 Then
        '    Me.popupControlContainer1.ParentControl = Me.txtSaldoMN
        '    Me.popupControlContainer1.ShowPopup(Point.Empty)
        '    CargarEntidadesXtipo()
        'End If
    End Sub

    Public Sub CargarEntidadesXtipo()
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        Try

            Select Case cboMonedaOrigen.SelectedValue
                Case 1
                    txtFondoMNDestino.Value = txtFondoMN.Value
                Case 2
                    txtFondoMEDestino.Value = txtFondoME.Value
                    CargarEntidadesXME()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarEntidadesXMN()
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA

        Try
            txtFondoMNDestino.Value = txtFondoMN.Value



            'Select Case cboMonedaOrigen.SelectedValue
            '    Case 1
            '        If (txtFondoMN.Value <= lblDeudaPendientemn.Value) Then
            '            lsvMN.Items.Clear()
            '            lsvMN.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            '            lsvMN.Columns.Add("T/C", 50, HorizontalAlignment.Left) '1
            '            lsvMN.Columns.Add("Importe MN", 70, HorizontalAlignment.Left) '1
            '            lsvMN.Columns.Add("Importe ME", 70, HorizontalAlignment.Left) '1

            '            For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalle(txtFondoMN.Value, cboEntidadFinancieraOrigen.SelectedValue)
            '                Dim n As New ListViewItem(i.idDocumento)
            '                n.SubItems.Add(i.diferTipoCambio)
            '                n.SubItems.Add(i.montoSoles)
            '                n.SubItems.Add(i.montoUsd)
            '                lsvMN.Items.Add(n)
            '                sumatoria += i.montoUsd
            '            Next
            '            txtFondoME.Value = sumatoria
            '            txtFondoMNDestino.Value = txtFondoMN.Value
            '        Else
            '            lblEstado.Text = "Debe ingresar un importe menor o igual!"
            '            PanelError.Visible = True
            '            Timer1.Enabled = True
            '            TiempoEjecutar(10)
            '            txtFondoMN.Value = 0.0
            '            txtFondoMN.Select(0, txtFondoMN.Text.Length)
            '        End If
            '    Case 2
            '        If (txtFondoME.Value <= lblDeudaPendienteme.Value) Then
            '            lsvMN.Items.Clear()
            '            lsvMN.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            '            lsvMN.Columns.Add("T/C", 50, HorizontalAlignment.Left) '1
            '            lsvMN.Columns.Add("Importe MN", 70, HorizontalAlignment.Left) '1
            '            lsvMN.Columns.Add("Importe ME", 70, HorizontalAlignment.Left) '1

            '            For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalle(txtFondoMN.Value, cboEntidadFinancieraOrigen.SelectedValue)
            '                Dim n As New ListViewItem(i.idDocumento)
            '                n.SubItems.Add(i.diferTipoCambio)
            '                n.SubItems.Add(i.montoSoles)
            '                n.SubItems.Add(i.montoUsd)
            '                lsvMN.Items.Add(n)
            '                sumatoria += i.montoUsd
            '            Next
            '            txtFondoME.Value = sumatoria
            '            txtFondoMNDestino.Value = txtFondoMN.Value
            '        Else
            '            lblEstado.Text = "Debe ingresar un importe menor o igual!"
            '            PanelError.Visible = True
            '            Timer1.Enabled = True
            '            TiempoEjecutar(10)
            '            txtFondoMN.Value = 0.0
            '            txtFondoMN.Select(0, txtFondoMN.Text.Length)
            '        End If
            'End Select

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarEntidadesXME()
        Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
        'Dim sumatoria As Decimal
        Try

            'lsvProveedor.Columns.Clear()


            Select Case cboMonedaOrigen.SelectedValue
                Case 1
                    If (txtFondoMN.Value <= lblDeudaPendientemn.Value) Then
                        lsvME.Items.Clear()
                        lsvME.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
                        lsvME.Columns.Add("T/C", 50, HorizontalAlignment.Left) '1
                        lsvME.Columns.Add("Importe ME", 70, HorizontalAlignment.Left) '1
                        lsvME.Columns.Add("Importe MN", 70, HorizontalAlignment.Left) '1

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtFondoME.Value, cboEntidadFinancieraOrigen.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(i.diferTipoCambio)
                            n.SubItems.Add(i.montoUsd)
                            n.SubItems.Add(i.montoSoles)
                            lsvME.Items.Add(n)
                            sumatoria += i.montoSoles
                        Next
                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtFondoMN.Value = 0.0
                        txtFondoMN.Select(0, txtFondoMN.Text.Length)
                    End If
                Case 2
                    If (txtFondoME.Value <= lblDeudaPendienteme.Value) Then
                        lsvME.Items.Clear()
                        lsvME.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
                        lsvME.Columns.Add("T/C", 50, HorizontalAlignment.Left) '1
                        lsvME.Columns.Add("Importe ME", 70, HorizontalAlignment.Left) '1
                        lsvME.Columns.Add("Importe MN", 70, HorizontalAlignment.Left) '1

                        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtFondoME.Value, cboEntidadFinancieraOrigen.SelectedValue)
                            Dim n As New ListViewItem(i.idDocumento)
                            n.SubItems.Add(i.diferTipoCambio)
                            n.SubItems.Add(i.montoUsd)
                            n.SubItems.Add(i.montoSoles)
                            lsvME.Items.Add(n)
                            sumatoria += i.montoSoles
                        Next
                    Else
                        lblEstado.Text = "Debe ingresar un importe menor o igual!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtFondoMN.Value = 0.0
                        txtFondoMN.Select(0, txtFondoMN.Text.Length)
                    End If
            End Select


        Catch ex As Exception

        End Try
    End Sub

    'Public Sub CargarEntidadesXTC()
    '    Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
    '    Dim sumatoria As Decimal
    '    Try

    '        'lsvProveedor.Columns.Clear()
    '        lsvTCDestino.Items.Clear()
    '        lsvTCDestino.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
    '        lsvTCDestino.Columns.Add("T/C", 50, HorizontalAlignment.Left) '1
    '        lsvTCDestino.Columns.Add("Importe ME", 0, HorizontalAlignment.Left) '1
    '        lsvTCDestino.Columns.Add("Importe MN", 0, HorizontalAlignment.Left) '1

    '        For Each i As documentoCajaDetalle In documentoCajaEtalleSA.ObtenerCajaDetalleME(txtFondoME.Value, cboEntidadFinancieraOrigen.SelectedValue)
    '            Dim n As New ListViewItem(i.idDocumento)
    '            n.SubItems.Add(i.diferTipoCambio)
    '            n.SubItems.Add(i.montoUsd)
    '            n.SubItems.Add(i.montoSoles)
    '            lsvTCDestino.Items.Add(n)
    '            'sumatoria += i.montoSoles
    '        Next
    '        'txtSaldoMN.Value = sumatoria

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub txtFondoMN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFondoMN.KeyDown
        'Try

        '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        '        e.SuppressKeyPress = True
        '        txtTipoCambio.Select()
        '        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
        '    End If
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    'txtImporteCompramn.Clear()
        'End Try
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvMN.SelectedItems.Count > 0 Then
                Me.txtFondoMNDestino.Text = lsvMN.SelectedItems(0).SubItems(1).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            'Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub PopupControlContainer3_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer3.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvME.SelectedItems.Count > 0 Then
                Me.txtFondoMEDestino.Text = lsvME.SelectedItems(0).SubItems(1).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            'Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If Not Me.PopupControlContainer2.IsShowing() Then
            ' Let the popup align around the source textBox.
            Me.PopupControlContainer2.ParentControl = Me.txtFondoMNDestino
            ' Passing Point.Empty will align it automatically around the above ParentControl.
            Me.PopupControlContainer2.ShowPopup(Point.Empty)

        End If

        If txtFondoMNDestino.Text.Trim.Length > 0 Then
            Me.PopupControlContainer2.ParentControl = Me.txtFondoMNDestino
            Me.PopupControlContainer2.ShowPopup(Point.Empty)
            CargarEntidadesXMN()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Not Me.PopupControlContainer3.IsShowing() Then
            ' Let the popup align around the source textBox.
            Me.PopupControlContainer3.ParentControl = Me.txtFondoMEDestino
            ' Passing Point.Empty will align it automatically around the above ParentControl.
            Me.PopupControlContainer3.ShowPopup(Point.Empty)

        End If

        If txtFondoMEDestino.Text.Trim.Length > 0 Then
            Me.PopupControlContainer3.ParentControl = Me.txtFondoMEDestino
            Me.PopupControlContainer3.ShowPopup(Point.Empty)
            CargarEntidadesXME()
        End If
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs)
        'If e.PopupCloseType = PopupCloseType.Done Then
        '    If lsvTCDestino.SelectedItems.Count > 0 Then
        '        Me.txtTipoCambioDestino.Text = lsvTCDestino.SelectedItems(0).SubItems(1).Text
        '    End If
        'End If
        '' Set focus back to textbox.
        'If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '    'Me.txtProveedor.Focus()
        'End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)
        'If Not Me.PopupControlContainer4.IsShowing() Then
        '    ' Let the popup align around the source textBox.
        '    Me.PopupControlContainer4.ParentControl = Me.txtTipoCambioDestino
        '    ' Passing Point.Empty will align it automatically around the above ParentControl.
        '    Me.PopupControlContainer4.ShowPopup(Point.Empty)

        'End If

        'If txtTipoCambioDestino.Text.Trim.Length > 0 Then
        '    Me.PopupControlContainer4.ParentControl = Me.txtTipoCambioDestino
        '    Me.PopupControlContainer4.ShowPopup(Point.Empty)
        '    'CargarEntidadesXTC()
        'End If
    End Sub

    Private Sub txtFondoME_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoME.ValueChanged
        'If (cboEntidadFinancieraDestino.SelectedValue > 0) Then
        If (txtFondoME.Value <= lblDeudaPendienteme.Value) Then
            CargarEntidadesXtipo()
        Else
            txtFondoME.Value = 0.0
            txtFondoMEDestino.Value = 0.0
            lblEstado.Text = "Debe ingresar un importe permitido!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
        'Else
        'CargarEntidadesXtipo()
        'lblEstado.Text = "Debe ingresar una cuenta destino!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        'End If


    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs)

        Select Case cboMonedaOrigen.SelectedValue
            Case 1
                'If Not txtTipoCambio.Value > 0 Then
                '    lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                '    PanelError.Visible = True
                '    Timer1.Enabled = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If

                If Not txtFondoMN.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

            Case 2

        End Select


        If Not cboEntidadFinancieraOrigen.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe ingresar la caja de origen!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Exit Sub
        End If

        If Not cboEntidadFinancieraDestino.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe ingresar la caja de destino!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Exit Sub
        End If

        If Not txtNumOper.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el número de operación."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtNumOper.Select()
            Exit Sub
        End If

        Select Case ManipulacionEstado
            Case ENTITY_ACTIONS.INSERT
                GrabarTransferenciaCaja()
            Case ENTITY_ACTIONS.UPDATE

        End Select
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtNumOper.Text.Trim.Length > 0 Then
                    txtNumOper.Select()
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtDescripcion.Clear()
        End Try
    End Sub

    Private Sub cboEntidadFinancieraDestino_Click(sender As Object, e As EventArgs) Handles cboEntidadFinancieraDestino.Click
        cboEntidadFinancieraDestino.Tag = 1
    End Sub

    Private Sub frmTransferenciaCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtFechaComprobante_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaComprobante.ValueChanged

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub GroupBox7_Enter(sender As Object, e As EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub GradientPanel5_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel5.Paint

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Select Case cboMonedaOrigen.SelectedValue
            Case 1
                'If Not txtTipoCambio.Value > 0 Then
                '    lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                '    PanelError.Visible = True
                '    Timer1.Enabled = True
                '    TiempoEjecutar(10)
                '    Exit Sub
                'End If

                If Not txtFondoMN.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

            Case 2

        End Select


        If Not cboEntidadFinancieraOrigen.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe ingresar la caja de origen!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Exit Sub
        End If

        If Not cboEntidadFinancieraDestino.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe ingresar la caja de destino!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Exit Sub
        End If

        If Not txtNumOper.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el número de operación."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtNumOper.Select()
            Exit Sub
        End If

        Select Case ManipulacionEstado
            Case ENTITY_ACTIONS.INSERT
                GrabarTransferenciaCaja()
            Case ENTITY_ACTIONS.UPDATE

        End Select
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Dispose()
    End Sub
End Class