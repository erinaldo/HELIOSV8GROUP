Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class frmDevolucionAcliente
    Inherits frmMaster

    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String

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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ObtenerTablaGenerales()
        ListaDocPago()
        txtTipoCambio.DecimalValue = TmpTipoCambio
    End Sub

#Region "Métodos"
    Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "46",
              .descripcion = "CUENTAS POR PAGAR DIVERSAS – TERCEROS",
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario}

        Return nMovimiento
    End Function

    Public Function AS_HaberCliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim EFSA As New EstadosFinancierosSA
        Dim nMovimiento As New movimiento
        Dim EF As New estadosFinancieros
        EF = EFSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)

        nMovimiento = New movimiento With {
      .cuenta = EF.cuenta,
      .descripcion = EF.descripcion,
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario}

        Return nMovimiento


    End Function

    Function asientoCaja() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFechaComprobante.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
        nAsiento.importeMN = txtMontoMN.DecimalValue  ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtMontoME.DecimalValue  ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
            End If
        Next

        Return nAsiento
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
        Dim ListaAsiento As New List(Of asiento)

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
                .fechaProceso = txtFechaComprobante.Value
                .nroDoc = txtNumero.Text.Trim
                .idOrden = Nothing
                .tipoOperacion = "9920" 'DEVOLUCION DE DINERO A CLIENTE X NOTA DE CREDITO
                .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
                .fechaActualizacion = DateTime.Now
            End With

            With ndocumentoCaja
                .codigoLibro = "9920"
                .periodo = PeriodoGeneral
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                .codigoProveedor = lblIdProveedor
                .fechaProceso = txtFechaComprobante.Value
                .fechaCobro = txtFechaComprobante.Value
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
                .entidadFinanciera = GFichaUsuarios.IdCajaDestino
                .tipoCambio = txtTipoCambio.DecimalValue
                .montoSoles = txtMontoMN.DecimalValue
                .montoUsd = txtMontoME.DecimalValue
                .glosa = txtGlosa.Text.Trim
                .usuarioModificacion = GFichaUsuarios.IdCajaUsuario
                .fechaModificacion = DateTime.Now
                .DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
            End With

            ndocumento.documentoCaja = ndocumentoCaja


            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = txtFechaComprobante.Value
                    ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                    ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()
                    ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                    ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                    'dgvDetalleItems.Rows(i).Cells(3).Value()
                    ' dgvDetalleItems.Rows(i).Cells(4).Value()
                    ndocumentoCajaDetalle.entregado = "SI"
                    '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0


                    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                    ndocumentoCajaDetalle.documentoAfectadodetalle = dgvDetalleItems.Rows(i.Index).Cells(11).Value
                    ndocumentoCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
                    ndocumentoCajaDetalle.fechaModificacion = Date.Now
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cboTipoDoc.SelectedValue
                Case "109", "003"
                    asiento = asientoCaja()
                    ListaAsiento.Add(asiento)
                    ndocumento.asiento = ListaAsiento
                Case "007"
                    '   cajaUsarioBE = Nothing
            End Select

            n.IdAlmacen = documentoCajaSA.GrabarExcedenteVenta(ndocumento)
            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
            lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
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

    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim itemSA As New detalleitemsSA

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim estadoF As New EstadosFinancierosSA
        Try
            With documentoSA.UbicarDocumento(intIdDocumento)

                txtFechaComprobante.Tag = .idDocumento
                txtFechaComprobante.Value = .fechaProceso
                txtNumero.Text = .nroDoc
                cboTipoDoc.SelectedValue = .tipoDoc
                '  txtComprobante.Text = tablaSA.GetUbicarTablaID(1, .tipoDoc).descripcion
            End With

            With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)
                cboMoneda.SelectedValue = .moneda
                txtTipoCambio.DecimalValue = .tipoCambio
                txtMontoMN.DecimalValue = .montoSoles
                txtMontoME.DecimalValue = .montoUsd

                With entidadSA.UbicarEntidadPorID(.codigoProveedor).First
                    lblNomProveedor = .nombreCompleto
                    lblIdProveedor = .idEntidad
                    lblCuentaProveedor = .cuentaAsiento
                End With
            End With
            dgvDetalleItems.Rows.Clear()
            For Each i In documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento)
                dgvDetalleItems.Rows.Add(i.secuencia, i.DetalleItem, itemSA.InvocarProductoID(i.idItem).unidad1, "0.00", i.montoSoles, i.montoUsd, "0.00", "0.00", "0.00", "0.00",
                                         Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE)
            Next

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA
        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

        cboEntidades.ValueMember = "codigoDetalle"
        cboEntidades.DisplayMember = "descripcion"
        cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
    End Sub

    Sub CalculoGRID()
        Dim valDolares As Decimal = 0
        Dim nudvalueImporte As Decimal = txtMontoMN.DecimalValue
        Dim nudSaldo As Decimal = nudvalueImporte
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0

        valDolares = Math.Round(txtMontoMN.DecimalValue / txtTipoCambio.DecimalValue, 2)
        txtMontoME.DecimalValue = valDolares

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
    End Sub

    Sub CalculoSoles()
        If cboMoneda.SelectedValue = 1 Then
            If txtTipoCambio.DecimalValue > 0 Then
                If CDec(txtMontoMN.DecimalValue) > CDec(lblDeudaPendiente.Text) Then
                    MsgBox("El valor ingreso excede el valor permitido.", MsgBoxStyle.Information, String.Concat("Monto permitido (S/.):", Space(2), lblDeudaPendiente.Text))
                    txtMontoMN.DecimalValue = 0
                    txtMontoME.DecimalValue = 0
                    Exit Sub
                End If
            End If
        End If
    End Sub
#End Region

    Private Sub frmDevolucionAcliente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmDevolucionAcliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If cboTipoDoc.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDoc.SelectedValue = "109" Then
                txtNumero.Clear()
                txtNumero.Visible = False

            ElseIf cboTipoDoc.SelectedValue = "007" Then
                txtNumero.Clear()
                txtNumero.Visible = True

            Else
                txtNumero.Clear()
                txtNumero.Visible = True
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If txtMontoMN.DecimalValue > 0 Then

            If cboTipoDoc.SelectedValue = "109" Then

            ElseIf cboTipoDoc.SelectedValue = "007" Then
                If Not txtNumero.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número del tipo de documento."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If
            Else
                If Not txtNumero.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número del tipo de documento."
                    'lblEstado.Image = My.Resources.warning2
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumero.Focus()
                    Exit Sub
                End If
                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación de la transacción."
                    'lblEstado.Image = My.Resources.warning2
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtNumOper.Focus()
                    Exit Sub
                End If
                If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de cta. corriente del banco."
                    'lblEstado.Image = My.Resources.warning2
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    txtCuentaCorriente.Focus()
                    Exit Sub
                End If
            End If

            '    If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
            Grabar()
            'ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
            '    '   Editar()
            'End If
        Else
        lblEstado.Text = "Ingresar el importe a pagar!"
        'lblEstado.Image = My.Resources.warning2
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        End If
    End Sub

    Private Sub txtMontoMN_TextChanged(sender As Object, e As EventArgs) Handles txtMontoMN.TextChanged
        If txtTipoCambio.DecimalValue > 0 Then
            If txtMontoMN.DecimalValue > 0 Then
                CalculoSoles()
                CalculoGRID()
            End If
        End If
  
    End Sub

    Private Sub txtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged
        txtMontoMN_TextChanged(sender, e)
    End Sub

    Private Sub DockingClientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles DockingClientPanel1.Paint

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs)

    End Sub
End Class