Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms

Public Class frmPagoMembresia

#Region "Attributes"
    Protected Friend tablaSA As New tablaDetalleSA
    Protected EstadosFinancierosSA As New EstadosFinancierosSA
    Protected frmSeleccionCuentaFinanciera As frmSeleccionCuentaFinanciera
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ObtenerTablaGenerales()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral
        txtAnioCompra.Text = AnioGeneral
        GetCuentaPorPagar(idDocumento)
    End Sub

#End Region

#Region "Methods"
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

    Function Glosa() As String
        Dim strGlosa As String = Nothing
        strGlosa = "Por pagos con comprobante, en " & cboTipoDoc.Text & " con fecha: " & New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
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
        Dim ListadocumentoCajaDetalle2 As New List(Of documentoCajaDetalle)
        Dim ndocumentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim SaldoMonedaExt As Decimal = 0
        Dim MontoMonedaExt As Decimal = 0
        Dim MontoSoles As Decimal = 0
        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Try
            With ndocumento
                .idDocumento = Tag
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .tipoDoc = cboTipoDoc.SelectedValue
                .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .nroDoc = "-"
                .idOrden = Nothing
                .moneda = "1"
                .idEntidad = Val(txtEntidad.Tag)
                .entidad = txtEntidad.Text
                .tipoEntidad = TIPO_ENTIDAD.CLIENTE
                .nrodocEntidad = txtNroDocEntidad.Text
                .tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            End With

            With ndocumentoCaja
                .codigoLibro = "1"
                .tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                .periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
                .idDocumento = Tag
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                .tipoDocPago = cboTipoDoc.SelectedValue
                If cboTipoDoc.SelectedValue = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "SI"
                    '.ctaIntebancaria = txtCtaInterbancaria.Text
                ElseIf cboTipoDoc.SelectedValue = "007" Then ' cheques
                    .numeroDoc = "-"
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "111" Then
                    .numeroDoc = "-"
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "109" Then
                    .numeroDoc = "-"
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaCobro = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    .entregado = "NO"
                End If
                .moneda = "1"
                .entidadFinanciera = txtCF_name.Tag
                .tipoCambio = CDec(txtTipoCambio.DoubleValue).ToString("N3")
                .montoSoles = txtPagoMN.Value
                .montoUsd = txtPagoME.Value
                .glosa = Glosa()
                .usuarioModificacion = usuario.IDUsuario
                .fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                .DeudaEvalMN = CDec(txtSaldoPorPagar.DecimalValue)
                .DeudaEvalME = 0
                .codigoProveedor = CInt(txtEntidad.Tag)
            End With

            ndocumento.documentoCaja = ndocumentoCaja
            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                    ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

                    Select Case txtCF_moneda.Text
                        Case 1
                            ndocumentoCajaDetalle.moneda = "1"
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                        Case 2
                            ndocumentoCajaDetalle.moneda = "2"
                            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                    End Select

                    ndocumentoCajaDetalle.entregado = "SI"
                    ndocumentoCajaDetalle.tipoCambioTransacc = CDec(txtTipoCambio.DoubleValue).ToString("N3")
                    ndocumentoCajaDetalle.documentoAfectado = Tag
                    ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                    ndocumentoCajaDetalle.fechaModificacion = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    ndocumentoCajaDetalle.idCajaPadre = txtCF_name.Tag
                    ndocumentoCajaDetalle.documentoAfectadodetalle = Tag
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                    SaldoMonedaExt += CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
                    MontoMonedaExt += CDec(dgvDetalleItems.Rows(i.Index).Cells(5).Value())
                    MontoSoles += CDec(dgvDetalleItems.Rows(i.Index).Cells(8).Value())
                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cboTipoDoc.SelectedValue
                Case "109", "003", "001"
                    asiento = asientoCaja(SaldoMonedaExt, MontoMonedaExt, MontoSoles)
                    ListaAsiento.Add(asiento)
                    ndocumento.asiento = ListaAsiento
                Case "007", "111"
                    cajaUsarioBE = Nothing
            End Select
            n.IdAlmacen = documentoCajaSA.GrabarPagoMembresia(ndocumento)
            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
            Close()
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Function asientoCaja(monedaExtrajera As Decimal, MontoMonedaExt As Decimal, MontoSoles As Decimal) As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = String.Format("{0:00}", txtPeriodo.Value.Month) & "/" & txtPeriodo.Value.Year
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtEntidad.Tag
        nAsiento.nombreEntidad = txtEntidad.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = New DateTime(AnioGeneral, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        'correccin asientos
        nAsiento.importeMN = txtPagoME.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtPagoME.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                nAsiento.movimiento.Add(AS_DebeCaja(txtCF_cuentaContable.Text, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
            End If
        Next
        Return nAsiento
    End Function

    Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberCliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
            .cuenta = "1213",
            .descripcion = txtEntidad.Text,
            .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
            .monto = cMonto,
            .montoUSD = cMontoUS,
            .fechaActualizacion = DateTime.Now,
            .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Private Sub cargarCtasFinan()
        If txtCF_tipo.Tag = "EF" Then
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        ElseIf txtCF_tipo.Tag = "BC" Then
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        ElseIf txtCF_tipo.Tag = "TC" Then
            Dim lista As New List(Of String)
            lista.Add("001")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        End If
    End Sub

    Public Sub ListaDocPago(listaCuenta As List(Of String))
        Dim tabla = tablaSA.GetListaTablaDetalle(1, "1")
        tabla = (From n In tabla
                 Where listaCuenta.Contains(n.codigoDetalle)
                 Select n).ToList
        cboTipoDoc.DataSource = tabla
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.SelectedValue = "001"
    End Sub

    Public Sub ObtenerTablaGenerales()
        cboEntidades.ValueMember = "codigoDetalle"
        cboEntidades.DisplayMember = "descripcion"
        cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
    End Sub

    Private Sub GetCuentaPorPagar(idDocumento As Integer)
        Dim pagoDocumento = Entidadmembresia_GymSA.GetDocumentoCajaMembresiaByDocumento(idDocumento)
        If pagoDocumento IsNot Nothing Then
            Tag = pagoDocumento.idDocumento
            txtEntidad.Text = pagoDocumento.CustomEntidad.nombreCompleto
            txtNroDocEntidad.Text = pagoDocumento.CustomEntidad.nrodoc
            txtTipoEntidad.Text = "CL"
            TXTVENTA.DecimalValue = pagoDocumento.importe
            txtPagoAcuenta.Text = pagoDocumento.CustomDocumentoCaja.montoSoles.GetValueOrDefault
            txtSaldoPorPagar.DecimalValue = pagoDocumento.importe - pagoDocumento.CustomDocumentoCaja.montoSoles.GetValueOrDefault
            lblMoneda.Text = "NAC"

            dgvDetalleItems.Rows.Clear()
            dgvDetalleItems.Rows.Add(0, pagoDocumento.CustomMembresia.descripcion, "UND", "0.00", txtSaldoPorPagar.DecimalValue, 0, "0.00", "0.00", "0.00", "0.00",
                                         Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
        End If
    End Sub

    Sub CalculoGRID()
        Dim valDolares As Decimal = 0
        Dim nudvalueImporte As Decimal = txtPagoMN.Value
        Dim nudSaldo As Decimal = nudvalueImporte
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0
        Dim montoMN As Decimal = 0
        If (CDec(txtPagoMN.Value <= txtSaldoPorPagar.DecimalValue)) Then
            If (txtPagoMN.Value > 0) Then

                montoMN = Math.Round(CDec(txtPagoMN.Value), 2)

                If txtTipoCambio.DoubleValue = 0 Then
                    txtTipoCambio.DoubleValue = 1
                End If
                valDolares = montoMN / txtTipoCambio.DoubleValue
                txtPagoME.Value = (valDolares)

                For Each i As DataGridViewRow In dgvDetalleItems.Rows
                    cSaldo = CDec(i.Cells(4).Value) - nudSaldo
                    cSaldoex = CDec(i.Cells(5).Value) - valDolares
                    'If CDec(i.Cells(4).Value) = "" Then
                    If cSaldo >= 0 Then
                        i.Cells(6).Value = CDec(nudSaldo)
                        i.Cells(8).Value = CDec(cSaldo)
                        '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                        '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                        nudSaldo = 0
                    Else
                        i.Cells(6).Value = CDec(i.Cells(4).Value)
                        i.Cells(8).Value = "0.00"
                        '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                        '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                        nudSaldo = cSaldo * -1
                    End If

                    If cSaldoex >= 0 Then
                        i.Cells(7).Value = CDec(valDolares)
                        i.Cells(9).Value = CDec(cSaldoex)
                        '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                        '    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                        valDolares = 0
                    Else
                        i.Cells(7).Value = CDec(i.Cells(5).Value)
                        i.Cells(9).Value = "0.00"
                        '   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
                        '   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
                        valDolares = cSaldoex * -1
                    End If

                Next
            End If

        Else
            txtPagoME.Value = 0
            txtPagoMN.Value = 0
            lblEstado.Text = "Ingreso del importe no debe exceder S/." & txtSaldoPorPagar.DecimalValue
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtPagoMN.Select()
            txtPagoMN.Select(0, txtPagoMN.Text.Length)
        End If
    End Sub

#End Region

#Region "Events"
    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDoc.SelectedValue = "109" Then 'EFECTIVO (que se genere un vocher de caja con los datos del comprobante que se está pagando) 
                'Label17.Text = "NRO. VOUCHER:"
                Dim f As New BannerTextInfo
                f.Mode = BannerTextMode.FocusMode
                f.Text = "NRO. VOUCHER"
                f.Visible = True
                f.Color = Color.FromKnownColor(KnownColor.ControlDark)
                BannerTextProvider1.SetBannerText(txtNumOper, f)
            ElseIf cboTipoDoc.SelectedValue = "007" Then ' CHEQUES
                '  Label17.Text = "NRO. CHEQUE:"
                Dim f As New BannerTextInfo
                f.Mode = BannerTextMode.FocusMode
                f.Text = "NRO. CHEQUE"
                f.Visible = True
                f.Color = Color.FromKnownColor(KnownColor.ControlDark)
                BannerTextProvider1.SetBannerText(txtNumOper, f)
            ElseIf cboTipoDoc.SelectedValue = "001" Then ' DEPOSITO EN CUENTA 
                '   Label17.Text = "NRO. OPERACIÓN:"
                Dim f As New BannerTextInfo
                f.Mode = BannerTextMode.FocusMode
                f.Text = "NRO. OPERACIÓN"
                f.Visible = True
                f.Color = Color.FromKnownColor(KnownColor.ControlDark)
                BannerTextProvider1.SetBannerText(txtNumOper, f)
            ElseIf cboTipoDoc.SelectedValue = "111" Then ' CHEQUE NO NEGOCIABLE 
                '    Label17.Text = "NRO. CHEQUE:"
                Dim f As New BannerTextInfo
                f.Mode = BannerTextMode.FocusMode
                f.Text = "NRO. CHEQUE"
                f.Visible = True
                f.Color = Color.FromKnownColor(KnownColor.ControlDark)
            End If
        End If
    End Sub

    Private Sub txtPagoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtPagoMN.ValueChanged
        If (CDec(txtPagoMN.Value <= SaldoEFMN.DoubleValue) And txtPagoMN.Value <> 0) Then
            CalculoGRID()
        ElseIf (txtPagoMN.Value <> 0) Then
            lblEstado.Text = "no debe exceder el monto permitido"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtPagoMN.Value = 0.0
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmSeleccionCuentaFinanciera = New frmSeleccionCuentaFinanciera
        frmSeleccionCuentaFinanciera.txtPeriodo.Value = txtPeriodo.Value
        frmSeleccionCuentaFinanciera.GetCuentasFinancieras("CUENTAS EN EFECTIVO")
        frmSeleccionCuentaFinanciera.StartPosition = FormStartPosition.CenterParent
        frmSeleccionCuentaFinanciera.ShowDialog()
        If frmSeleccionCuentaFinanciera.Tag IsNot Nothing Then
            txtPagoME.Value = 0
            txtPagoMN.Value = 0
            txtTipoCambio.DoubleValue = 0
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
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
            txtCF_moneda.Text = c.codigo
            txtCF_cuentaContable.Text = c.cuenta
            SaldoEFMN.DoubleValue = c.importeBalanceMN.GetValueOrDefault
            SaldoEFME.DoubleValue = 0
            cargarCtasFinan()
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        Try
            '  If txtPagoMN.Value > 0 Then
            If Not txtCF_name.Text.Length > 0 Then
                    lblEstado.Text = "Ingrese la entidad financiera."
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                If cboTipoDoc.SelectedValue = "001" Then
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

                ElseIf cboTipoDoc.SelectedValue = "003" Then

                    If Not txtNumOper.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de operación."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtNumOper.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                ElseIf cboTipoDoc.SelectedValue = "007" Then

                    'ElseIf cboTipoDoc.SelectedValue = "109" Then
                    '    If Not txtNumeroCompr.Text.Length > 0 Then
                    '        lblEstado.Text = "Ingrese el numero de voucher"
                    '        Timer1.Enabled = True
                    '        PanelError.Visible = True
                    '        TiempoEjecutar(10)
                    '        Me.Cursor = Cursors.Arrow
                    '        Exit Sub
                    '    End If
                ElseIf cboTipoDoc.SelectedValue = "111" Then

                ElseIf cboTipoDoc.SelectedValue = "007" Then
                    'If Not txtNumeroCompr.Text.Trim.Length > 0 Then
                    '    lblEstado.Text = "Ingrese el número del tipo de documento."
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)
                    '    Me.Cursor = Cursors.Arrow
                    '    Exit Sub
                    'End If
                Else
                    'If Not txtNumeroCompr.Text.Trim.Length > 0 Then
                    '    lblEstado.Text = "Ingrese el número del tipo de documento."
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)
                    '    txtNumeroCompr.Focus()
                    '    Me.Cursor = Cursors.Arrow
                    '    Exit Sub
                    'End If

                End If

            'obteniendo saldo  de la entidad financiera seleccionada
            'If txtPagoMN.Value > SaldoEFMN.DoubleValue Then
            '    Throw New Exception("El importe excede al monto de la cuenta financiera actual!")
            'Else
            'PAGO COMPRA NORMAL
            Grabar()
            'End If
            'Else
            '    lblEstado.Text = "Ingresar el importe a pagar!"
            '    Timer1.Enabled = True
            '    PanelError.Visible = True
            '    TiempoEjecutar(10)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub
#End Region

End Class