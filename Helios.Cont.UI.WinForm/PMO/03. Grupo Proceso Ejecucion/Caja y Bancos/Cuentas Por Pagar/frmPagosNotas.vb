Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class frmPagosNotas
    Inherits frmMaster
    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public fecha As DateTime

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        SetRenderer()
        ObtenerTablaGenerales()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ListaDocPago()

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
                        '   .GroupBox1.Visible = True
                        '    .GroupBox2.Visible = True
                        '   .GroupBox4.Visible = True
                        '  .cboMoneda.Visible = True
                        .Timer1.Enabled = True
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
                    '   .GroupBox1.Visible = True
                    '      .GroupBox2.Visible = True
                    '  .GroupBox4.Visible = True
                    ' .cboMoneda.Visible = True
                    .Timer1.Enabled = False
                    .StartPosition = FormStartPosition.CenterParent
                    '  .UbicarUsuarioCaja(intIdDocumento, "CUENTAS_POR_PAGAR")
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


#Region "Métodos"
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

                lbldDocCaja.Text = .idDocumento
                txtFechaComprobante.Value = .fechaProceso
                txtNumero.Text = .nroDoc
                cboTipoDoc.SelectedValue = .tipoDoc
                '  txtComprobante.Text = tablaSA.GetUbicarTablaID(1, .tipoDoc).descripcion
            End With

            With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)
                cboMoneda.SelectedValue = .moneda
                'txtIDEstablecimientoCaja.Text = .idEstablecimiento
                'txtEstablecimientoCaja.Text = establecSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
                'txtIdCaja.Text = .entidadFinanciera
                txtTipoCambio.Value = .tipoCambio
                txtImporteCompramn.Value = .montoSoles
                txtImporteComprame.Value = .montoUsd

                With entidadSA.UbicarEntidadPorID(.codigoProveedor).First
                    lblNomProveedor = .nombreCompleto
                    lblIdProveedor = .idEntidad
                    lblCuentaProveedor = .cuentaAsiento
                End With

                'With estadoF.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)

                '    Select Case .tipo
                '        Case "BC"
                '            rbBanco.Checked = True
                '        Case Else
                '            rbEfectivo.Checked = True
                '    End Select

                '    txtCaja.Text = .descripcion
                '    lblCuenta.Text = .cuenta
                'End With
            End With
            dgvDetalleItems.Rows.Clear()
            For Each i In documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento)
                dgvDetalleItems.Rows.Add(i.secuencia, i.DetalleItem, itemSA.InvocarProductoID(i.idItem).unidad1, "0.00", i.montoSoles, i.montoUsd, "0.00", "0.00", "0.00", "0.00",
                                         Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE)
            Next


        Catch ex As Exception

        End Try
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

    Sub CalculoGRID()
        Dim valDolares As Decimal = 0
        Dim nudvalueImporte As Decimal = txtImporteCompramn.Value
        Dim nudSaldo As Decimal = nudvalueImporte
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0

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

#End Region

#Region "Manipulación data"

#Region "DEBITO ASIENTO"
    Public Function AS_EntidadFinanciera(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario}

        Return nMovimiento
    End Function

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = lblCuentaProveedor,
      .descripcion = lblNomProveedor,
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario}

        Return nMovimiento


    End Function
#End Region

    Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario}

        Return nMovimiento
    End Function

    Public Function AS_HaberCliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "16",
      .descripcion = "CUENTAS POR COBRAR DIVERSAS - TERCEROS",
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
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
        nAsiento.importeMN = txtImporteCompramn.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtImporteComprame.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
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


    Function asientoDebito() As asiento
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
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
        nAsiento.importeMN = txtImporteCompramn.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtImporteComprame.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                nAsiento.movimiento.Add(AS_Proveedor(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                nAsiento.movimiento.Add(AS_EntidadFinanciera(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
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
                .tipoOperacion = "02"
                .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
                .fechaActualizacion = DateTime.Now
            End With

            With ndocumentoCaja
                .codigoLibro = "02"
                .periodo = PeriodoGeneral
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                Select Case Label23.Text
                    Case "NOTA DE CREDITO"
                        .tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                    Case "NOTA DE DEBITO"
                        .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
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
                .entidadFinanciera = GFichaUsuarios.IdCajaDestino
                .tipoCambio = txtTipoCambio.Value
                .montoSoles = txtImporteCompramn.Value
                .montoUsd = txtImporteComprame.Value
                .glosa = Glosa()
                .usuarioModificacion = GFichaUsuarios.IdCajaUsuario
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
                
                    ndocumentoCajaDetalle.entregado = "SI"
                    '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
                 
                    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                    ndocumentoCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
                    ndocumentoCajaDetalle.fechaModificacion = Date.Now
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cboTipoDoc.SelectedValue
                Case "109", "003"
                    Select Case Label23.Text
                        Case "NOTA DE CREDITO"
                            asiento = asientoCaja()
                            ListaAsiento.Add(asiento)
                        Case "NOTA DE DEBITO"
                            asiento = asientoDebito()
                            ListaAsiento.Add(asiento)
                    End Select

                 
                    ndocumento.asiento = ListaAsiento
                Case "007"
                    cajaUsarioBE = Nothing
            End Select

            n.IdAlmacen = documentoCajaSA.SaveGroupCajaNotas(ndocumento)
            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
            lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    'Public Sub Editar()
    '    Dim documentoSA As New DocumentoSA
    '    Dim documentoCajaSA As New DocumentoCajaSA
    '    Dim ndocumento As New documento
    '    Dim ndocumentoCaja As New documentoCaja
    '    Dim ndocumentoCajaDetalle As New documentoCajaDetalle
    '    Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
    '    Dim asiento As New asiento
    '    Dim ListaAsiento As New List(Of asiento)
    '    Try
    '        With ndocumento
    '            .idDocumento = lbldDocCaja.Text
    '            .idEmpresa = Gempresas.IdEmpresaRuc
    '            .idCentroCosto = GEstableciento.IdEstablecimiento
    '            .idProyecto = GProyectos.IdProyectoActividad
    '            .tipoDoc = txtIdComprobante.Text
    '            .fechaProceso = txtFechaComprobante.Value
    '            .nroDoc = txtNumeroComp.Text
    '            .idOrden = Nothing
    '            .tipoOperacion = "01"
    '            .usuarioActualizacion = "Jiuni"
    '            .fechaActualizacion = DateTime.Now
    '        End With

    '        With ndocumentoCaja
    '            .idDocumento = lbldDocCaja.Text
    '            .idEmpresa = Gempresas.IdEmpresaRuc
    '            .idEstablecimiento = GEstableciento.IdEstablecimiento
    '            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
    '            .codigoProveedor = lblIdProveedor.Text
    '            .fechaProceso = txtFechaComprobante.Value
    '            .fechaCobro = txtFechaComprobante.Value
    '            .tipoDocPago = txtIdComprobante.Text
    '            .numeroDoc = txtNumeroComp.Text
    '            .monedaObligacion = IIf(rbNac.Checked = True, "1", "2")
    '            .moneda = IIf(rbNac.Checked = True, "1", "2")
    '            .entidadFinanciera = txtIdCaja.Text
    '            .numeroOperacion = txtNumeroComp.Text
    '            .tipoCambio = nudTipoCambio.Value
    '            .montoSoles = nudImporteNac.Value
    '            .montoUsd = nudImporteExt.Value
    '            .montoItf = 0
    '            .montoItfusd = 0
    '            .glosa = Glosa()
    '            .entregado = "SI"
    '            .usuarioModificacion = "Jiuni"
    '            .fechaModificacion = DateTime.Now
    '        End With

    '        ndocumento.documentoCaja = ndocumentoCaja

    '        For Each i As DataGridViewRow In dgvDetalleItems.Rows
    '            ndocumentoCajaDetalle = New documentoCajaDetalle
    '            ndocumentoCajaDetalle.idDocumento = lbldDocCaja.Text
    '            ndocumentoCajaDetalle.secuencia = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
    '            ndocumentoCajaDetalle.fecha = txtFechaComprobante.Value
    '            ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
    '            ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()
    '            ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
    '            ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
    '            ndocumentoCajaDetalle.montoItf = 0 'dgvDetalleItems.Rows(i).Cells(3).Value()
    '            ndocumentoCajaDetalle.montoItfusd = 0 ' dgvDetalleItems.Rows(i).Cells(4).Value()
    '            ndocumentoCajaDetalle.entregado = "SI"
    '            '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
    '            ndocumentoCajaDetalle.difMN = 0
    '            ndocumentoCajaDetalle.difME = 0
    '            ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
    '            ndocumentoCajaDetalle.Action = Business.Entity.BaseBE.EntityAction.UPDATE
    '            ndocumentoCajaDetalle.usuarioModificacion = "Jiuni"
    '            ndocumentoCajaDetalle.fechaModificacion = Date.Now
    '            ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
    '        Next
    '        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
    '        asiento = asientoCaja()
    '        ListaAsiento.Add(asiento)
    '        ndocumento.asiento = ListaAsiento
    '        documentoCajaSA.EditarGroupCaja(ndocumento)
    '        lblEstado.Text = "Transacción realizada con éxito!"
    '        lblEstado.Image = My.Resources.ok4
    '        Dispose()
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        lblEstado.Image = My.Resources.warning2
    '    End Try
    'End Sub

    Function Glosa() As String
        Dim strGlosa As String = Nothing

        'With frmCuentasPorPagar
        strGlosa = "Por pagos con comprobante, en " & cboTipoDoc.Text & " con fecha: " & fecha

        'End With
        Return strGlosa
    End Function
#End Region

    Private Sub frmPagos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub txtImporteCompramn_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtImporteCompramn.ValueChanged
        If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
            CalculoSoles()
            CalculoGRID()
        ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
            CalculoGRID()
        End If

    End Sub

    Private Sub txtTipoCambio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTipoCambio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtImporteCompramn.Select()
        End If
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        txtImporteCompramn_ValueChanged(sender, e)
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If txtImporteCompramn.Value > 0 Then

            If cboTipoDoc.SelectedValue = "109" Then

            ElseIf cboTipoDoc.SelectedValue = "007" Then
                If Not txtNumero.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número del tipo de documento."
                    lblEstado.Image = My.Resources.warning2
                    Exit Sub
                End If
            Else
                If Not txtNumero.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número del tipo de documento."
                    lblEstado.Image = My.Resources.warning2
                    txtNumero.Focus()
                    Exit Sub
                End If
                If Not txtNumOper.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de operación de la transacción."
                    lblEstado.Image = My.Resources.warning2
                    txtNumOper.Focus()
                    Exit Sub
                End If
                If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese el número de cta. corriente del banco."
                    lblEstado.Image = My.Resources.warning2
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
            lblEstado.Image = My.Resources.warning2
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tbFormaPago_Click(sender As System.Object, e As System.EventArgs)
        'If tbFormaPago.ToggleState = Tools.ToggleButtonState.Active Then
        '    txtNumero.Visible = True
        '    cboTipoDoc.SelectedValue = "007"
        'ElseIf tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive Then
        '    txtNumero.Visible = False
        '    cboTipoDoc.SelectedValue = "109"
        'End If
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        'If tbFormaPago.ToggleState = Tools.ToggleButtonState.Active Then
        '    txtNumero.Visible = False
        '    cboTipoDoc.SelectedValue = "109"
        '    If flagItem = 1 Then
        '        MsgBox("Lista efectivo")
        '        flagItem = 0
        '    End If
        'ElseIf tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive Then

        '    txtNumero.Visible = True
        '    cboTipoDoc.SelectedValue = "007"
        '    If flagItem = 2 Then
        '        MsgBox("Lista efectivo")
        '        flagItem = 0
        '    End If
        'End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub cboEntidades_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub GradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel2.Paint

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.pcEntidad.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Me.pcEntidad.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcEntidad_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcEntidad.BeforePopup
        Me.pcEntidad.BackColor = Color.White
    End Sub

    Private Sub pcEntidad_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcEntidad.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            'If lstCategoria.SelectedItems.Count > 0 Then
            '    Me.txtCategoria.ValueMember = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id)
            '    txtCategoria.Text = lstCategoria.Text
            '    ListadoProductosPorCategoriaTipoExistencia(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id, cboTipoExistencia.SelectedValue)
            'End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.cboEntidades.Focus()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.pcEntidad.Font = New Font("Tahoma", 8)
        Me.pcEntidad.Size = New Size(212, 139)
        Me.pcEntidad.ParentControl = Me.cboEntidades
        Me.pcEntidad.ShowPopup(Point.Empty)
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

    Private Sub frmPagosNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Visible = True
    End Sub
End Class