Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class frmCobroPrestamo
    Inherits frmMaster

    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property lblTipoEntidad() As String
    Public fecha As DateTime

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        SetRenderer()
        ObtenerTablaGenerales()
        lblPerido.Text = PeriodoGeneral
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ListaDocPago()
    End Sub


    Public Sub CargarCajasTipo(tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            


            'cboEntidadFinanciera.Items.Clear()
            'txtCuenta.Clear()
            'For Each i In estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, tiping)
            '    cboEntidadFinanciera.Items.Add(New Categoria(i.descripcion, i.idestado, i.cuenta))
            'Next
            'cboEntidadFinanciera.DisplayMember = "Name"
            'cboEntidadFinanciera.ValueMember = "Id"
            'txtCuenta.Text = DirectCast(Me.cboEntidadFinanciera.SelectedItem, Categoria).Cuenta


            cboEntidadFinanciera.ValueMember = "idestado"
            cboEntidadFinanciera.DisplayMember = "descripcion"
            cboEntidadFinanciera.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, tiping)


        Catch ex As Exception

        End Try
    End Sub



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
                    '.UbicarUsuarioCaja(intIdDocumento, "CUENTAS_POR_PAGAR")

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
            ToolStrip1.Visible = False
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

    Sub CalculoGRID()
        Dim valDolares As Decimal = 0
        Dim nudvalueImporte As Decimal = txtImporteCompramn.Value
        Dim nudSaldo As Decimal = nudvalueImporte
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0



        If txtTipoCambio.Value > 0 Then


            valDolares = Math.Round(txtImporteCompramn.Value / txtTipoCambio.Value, 2)
            txtImporteComprame.Value = valDolares


            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                cSaldo = CDec(i.Cells(4).Value) - nudSaldo
                cSaldoex = CDec(i.Cells(5).Value) - valDolares
                'If CDec(i.Cells(4).Value) = "" Then
                If cSaldo >= 0 Then
                    i.Cells(6).Value = nudSaldo
                    i.Cells(8).Value = cSaldo
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    nudSaldo = 0
                Else
                    i.Cells(6).Value = i.Cells(4).Value
                    i.Cells(8).Value = "0.00"
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    nudSaldo = cSaldo * -1
                End If


                If cSaldoex >= 0 Then
                    i.Cells(7).Value = valDolares
                    i.Cells(9).Value = cSaldoex
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    valDolares = 0
                Else
                    i.Cells(7).Value = i.Cells(5).Value
                    i.Cells(9).Value = "0.00"
                    '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                    '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                    valDolares = cSaldoex * -1
                End If
            Next


        Else

            lblEstado.Text = "ingrese tipo de cambio"

        End If
    End Sub


    Sub CalculoSoles()
        If cboMoneda.SelectedValue = 1 Then
            If txtTipoCambio.Value > 0 Then
                If CDec(txtImporteCompramn.Value) > CDec(lblDeudaPendiente.Text) Then
                    MsgBox("El valor ingreso excede el valor permitido.", MsgBoxStyle.Information, String.Concat("Monto permitido (S/.):", Space(2), lblDeudaPendiente.Text))
                    txtImporteCompramn.Value = 0
                    txtImporteComprame.Value = 0
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Public Sub ListaDocPago()
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)
        Dim lista As New List(Of String)
        lista.Add("109")
        lista.Add("007")
        lista.Add("003")
        tabla = tablaSA.GetListaTablaDetalle(1, "1")
        tabla = (From n In tabla _
                     Where lista.Contains(n.codigoDetalle) _
                    Select n).ToList
        cboTipoDoc.DataSource = tabla
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.Enabled = True
        cboTipoDoc.SelectedValue = "109"
    End Sub

    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        '  tbFormaPago.Renderer = styleRenderer1
        'Dim styleRenderer2 As New StyledRenderer()
        'tbIGV.Renderer = styleRenderer2
        'Dim styleRenderer3 As New StyledRenderer()
        'toggleButton11.Renderer = styleRenderer3
        'Dim styleRenderer4 As New StyledRenderer()
        'toggleButton12.Renderer = styleRenderer4
        ' Panel2.Visible = False
    End Sub

    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA


        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

        cboEntidades.ValueMember = "codigoDetalle"
        cboEntidades.DisplayMember = "descripcion"
        cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")

        'If tbFormaPago.ToggleState = Tools.ToggleButtonState.Active Then
        '    txtNumero.Visible = True
        '    cboTipoDoc.SelectedValue = "007"
        'ElseIf tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive Then

        '    txtNumero.Visible = False
        '    cboTipoDoc.SelectedValue = "109"
        'End If
    End Sub
#End Region
    Public Property ListaAsientos As New List(Of asiento)
#Region "Manipulación Data"

    Sub AsientoInteres()

        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        nAsiento = New asiento
        nAsiento.idDocumento = lblIdDocumento.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = lblTipoEntidad
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        Select Case lblTipoPres.Tag
            Case "PR"
                nAsiento.glosa = "Préstamos recibido interes"
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRESTAMOS_RECIBIDO_INTERES
            Case "PO"
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRESTAMOS_OTORGADOS_INTERES
                nAsiento.glosa = "Préstámos otorgado interes"
        End Select
        nAsiento.importeMN = txtImporteCompramn.Value
        nAsiento.importeME = txtImporteComprame.Value

        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        '--------------------------------------------------------------------------------

        nMovimiento = New movimiento()
        Select Case lblTipoPres.Tag
            Case "PR"
                nMovimiento.cuenta = "67"
                nMovimiento.descripcion = "PROVISIONES"
            Case "PO"
                nMovimiento.cuenta = "49"
                nMovimiento.descripcion = "PASIVO DIFERIDO"
        End Select

        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = txtImporteCompramn.Value
        nMovimiento.montoUSD = txtImporteComprame.Value
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento()
        Select Case lblTipoPres.Tag
            Case "PR"
                nMovimiento.cuenta = "37"
                nMovimiento.descripcion = "ACTIVO DIFERIDO"
            Case "PO"
                nMovimiento.cuenta = "77"
                nMovimiento.descripcion = "INGRESOS FINANCIEROS"
        End Select

        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = txtImporteCompramn.Value
        nMovimiento.montoUSD = txtImporteComprame.Value
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)

        ListaAsientos.Add(nAsiento)
    End Sub

    Sub AsientoPrestamo(strTipoPago As String)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim CajaSA As New EstadosFinancierosSA
        Dim Caja As New estadosFinancieros

        ListaAsientos = New List(Of asiento)

        Caja = CajaSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)

        nAsiento = New asiento
        nAsiento.idDocumento = lblIdDocumento.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = lblTipoEntidad
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        Select Case lblTipoPres.Tag
            Case "PR"
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRESTAMOS_RECIBIDO
                nAsiento.glosa = "Préstamo recibido"
            Case "PO"
                nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRESTAMOS_OTORGADOS
                nAsiento.glosa = "Préstamo otorgado"
        End Select
        nAsiento.importeMN = txtImporteCompramn.Value
        nAsiento.importeME = txtImporteComprame.Value
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        '---------------------------------------------------------------------------------

        nMovimiento = New movimiento()
        Select Case lblTipoPres.Tag
            Case "PR"
                nMovimiento.cuenta = "45"
            Case "PO"
                nMovimiento.cuenta = Caja.cuenta
        End Select
        nMovimiento.descripcion = Caja.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = txtImporteCompramn.Value
        nMovimiento.montoUSD = txtImporteComprame.Value
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento()
        Select Case lblTipoPres.Tag
            Case "PR"
                nMovimiento.cuenta = Caja.cuenta
                nMovimiento.descripcion = "Préstamo recibido " & lblNomProveedor
            Case "PO"
                nMovimiento.cuenta = "16"
                nMovimiento.descripcion = "Préstamo otorgado " & lblNomProveedor
        End Select
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = txtImporteCompramn.Value
        nMovimiento.montoUSD = txtImporteComprame.Value
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)

        ListaAsientos.Add(nAsiento)

        Select Case strTipoPago
            Case "INTERES"
                AsientoInteres()
        End Select

    End Sub

    Function Glosa() As String
        Dim strGlosa As String = Nothing

        'With frmCuentasPorPagar
        strGlosa = "Por COBRO con tipo documento, en " & cboTipoDoc.Text & " con fecha: " & fecha

        'End With
        Return strGlosa
    End Function

    Public Sub Grabar()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento

        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)

        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Try


            With ndocumento
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                .tipoDoc = cboTipoDoc.SelectedValue
                .fechaProceso = fecha
                .nroDoc = txtNumero.Text.Trim
                .idOrden = Nothing
                Select Case lblTipoPres.Tag
                    Case "PR"
                        .tipoOperacion = "101"
                    Case "PO"
                        .tipoOperacion = "100"
                End Select


                .usuarioActualizacion = usuario.IDUsuario




                .fechaActualizacion = DateTime.Now
            End With

            With ndocumentoCaja
                .periodo = PeriodoGeneral
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                Select Case lblTipoPres.Tag
                    Case "PR"
                        .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                        .codigoLibro = "101"
                    Case "PO"
                        .tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                        .codigoLibro = "100"
                End Select
                .codigoProveedor = lblIdProveedor
                .fechaProceso = fecha
                .fechaCobro = fecha
                .tipoDocPago = cboTipoDoc.SelectedValue
                If cboTipoDoc.SelectedValue = "109" Then
                    .numeroDoc = Nothing
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "007" Then
                    .numeroDoc = txtNumero.Text.Trim
                    .numeroOperacion = Nothing
                    .entregado = "NO"
                Else
                    .numeroDoc = txtNumero.Text.Trim
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .bancoEntidad = cboEntidades.SelectedValue
                    .entregado = "SI"
                End If
                .moneda = cboMoneda.SelectedValue

                .entidadFinanciera = cboEntidadFinanciera.SelectedValue

                .tipoCambio = txtTipoCambio.Value
                .montoSoles = txtImporteCompramn.Value
                .montoUsd = txtImporteComprame.Value
                .glosa = Glosa()




                .usuarioModificacion = usuario.IDUsuario




                .fechaModificacion = DateTime.Now
                .DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
            End With

            ndocumento.documentoCaja = ndocumentoCaja

            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = fecha
                    ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                    ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()
                    ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                    ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                   
                    '   ndocumentoCajaDetalle.entregado = "SI"
                    Select Case Label23.Text
                        Case "CAPITAL"
                            ndocumentoCajaDetalle.entregado = "C"
                        Case "INTERES"
                            ndocumentoCajaDetalle.entregado = "I"
                        Case "SEGURO"
                            ndocumentoCajaDetalle.entregado = "S"
                        Case "TODO"
                            ndocumentoCajaDetalle.entregado = "T"
                    End Select
                    '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
                    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text

                    ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario




                    ndocumentoCajaDetalle.fechaModificacion = Date.Now
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cboTipoDoc.SelectedValue
                Case "109", "003"
                    AsientoPrestamo(Label23.Text)
                    ndocumento.asiento = ListaAsientos
                Case "007"
                    cajaUsarioBE = Nothing
            End Select

            n.IdAlmacen = documentoCajaSA.SaveGroupCajaPrestamo(ndocumento, cajaUsarioBE)
            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
            lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub
#End Region

    Private Sub frmCobroPrestamo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCobroPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If cboTipoDoc.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDoc.SelectedValue = "109" Then
                txtNumero.Clear()
                txtNumero.Visible = False
                GradientPanel2.Enabled = False
            ElseIf cboTipoDoc.SelectedValue = "007" Then
                txtNumero.Clear()
                txtNumero.Visible = True
                GradientPanel2.Enabled = False
            Else
                txtNumero.Clear()
                txtNumero.Visible = True
                GradientPanel2.Enabled = True
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub


    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        txtImporteCompramn_ValueChanged(sender, e)
    End Sub

    Private Sub txtImporteCompramn_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtImporteCompramn.ValueChanged
        If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
            CalculoSoles()
            CalculoGRID()
        ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
            CalculoGRID()
        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        If txtTipoCambio.Value > 0 Then
            If txtImporteCompramn.Value > 0 Then

                If cboTipoDoc.SelectedValue = "109" Then

                ElseIf cboTipoDoc.SelectedValue = "007" Then
                    If Not txtNumero.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número del tipo de documento."
                        Timer1.Enabled = True
                        ToolStrip1.Visible = True
                        TiempoEjecutar(10)
                        'lblEstado.Image = My.Resources.warning2
                        Exit Sub
                    End If
                Else
                    If Not txtNumero.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número del tipo de documento."
                        Timer1.Enabled = True
                        ToolStrip1.Visible = True
                        TiempoEjecutar(10)
                        'lblEstado.Image = My.Resources.warning2
                        txtNumero.Focus()
                        Exit Sub
                    End If
                    If Not txtNumOper.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de operación de la transacción."
                        Timer1.Enabled = True
                        ToolStrip1.Visible = True
                        TiempoEjecutar(10)
                        'lblEstado.Image = My.Resources.warning2
                        txtNumOper.Focus()
                        Exit Sub
                    End If
                    If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de cta. corriente del banco."
                        Timer1.Enabled = True
                        ToolStrip1.Visible = True
                        TiempoEjecutar(10)
                        'lblEstado.Image = My.Resources.warning2
                        txtCuentaCorriente.Focus()
                        Exit Sub
                    End If
                End If

                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    Grabar()
                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    '   Editar()
                End If



            Else
                lblEstado.Text = "Ingresar el importe a pagar!"
                Timer1.Enabled = True
                ToolStrip1.Visible = True
                TiempoEjecutar(10)
                'lblEstado.Image = My.Resources.warning2
            End If

        Else
            lblEstado.Text = "El tipo de cambio debe ser mayor a cero!"
            Timer1.Enabled = True
            ToolStrip1.Visible = True
            TiempoEjecutar(10)
            'txtTipoCambio.Select()
            'txtTipoCambio.Focus()
            'Me.Cursor = Cursors.Arrow
            'Exit Sub
        End If
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                'txtProveedor.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress

    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        Try
            If txtNumero.Text.Trim.Length > 0 Then

                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()

            lblEstado.Text = "error"



        End Try
    End Sub


    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
        End If
    End Sub

    Private Sub DockingClientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles DockingClientPanel1.Paint

    End Sub
End Class