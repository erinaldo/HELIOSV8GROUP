Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class frmRegistroClienteMembresia

#Region "Attributes"
    Public Property membresia As membresia_Gym
    Public Property membresiaSA As membresia_GymSA
    Protected Friend tablaSA As tablaDetalleSA
    Protected Friend documento As documento
    Protected frmSeleccionCuentaFinanciera As frmSeleccionCuentaFinanciera
    Protected frmTrabajadorBusqueda As frmTrabajadorBusqueda
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarCombosPrincipales()
        LoadCombos(True)
                'txtFecha.Value = Date.Now
        txtFechaInicio.Value = Date.Now
        txtFecha.Value = Date.Now
    End Sub

    Public Sub New(idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarCombosPrincipales()
        LoadCombos(True)
        UbicarDocumentoMembresia(idDocumento)
        Tag = idDocumento
        btRegistrar.Enabled = False
    End Sub
#End Region

#Region "Methods"
    Private Sub cargarCtasFinan()
        If txtCF_tipo.Tag = "EF" Then
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")
            ListaDocPago(lista)
            cboFormaPagoCaja.SelectedValue = "109"
        ElseIf txtCF_tipo.Tag = "BC" Then
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)
            cboFormaPagoCaja.SelectedValue = "109"
        ElseIf txtCF_tipo.Tag = "TC" Then
            Dim lista As New List(Of String)
            lista.Add("001")
            ListaDocPago(lista)
            cboFormaPagoCaja.SelectedValue = "109"
        End If
    End Sub

    Public Sub ListaDocPago(listaCuenta As List(Of String))
        Dim tabla = tablaSA.GetListaTablaDetalle(1, "1")
        tabla = (From n In tabla
                 Where listaCuenta.Contains(n.codigoDetalle)
                 Select n).ToList
        cboFormaPagoCaja.DataSource = tabla
        cboFormaPagoCaja.ValueMember = "codigoDetalle"
        cboFormaPagoCaja.DisplayMember = "descripcion"
        cboFormaPagoCaja.SelectedValue = "109"
    End Sub

    Private Sub UbicarDocumentoMembresia(iddocumento As Integer)
        Dim objDocumento = Entidadmembresia_GymSA.GetUbicarDocumentoMembresia(iddocumento)
        If objDocumento IsNot Nothing Then
            'Dim fechasDB = membresia_congelamientoSA.GetMaximoMinimoFechaCongelamiento(New membresia_congelamiento With {.idDocumento = objDocumento.idDocumento})

            Tag = objDocumento.idDocumento
            Dim fecaPeriodo = CType("1/" & objDocumento.periodo, Date)
            txtPeriodo.Value = fecaPeriodo
            txtRuc2.Text = objDocumento.CustomEntidad.nrodoc
            txtCliente2.Text = objDocumento.CustomEntidad.nombreCompleto
            txtCliente2.Tag = objDocumento.CustomEntidad.idEntidad
            txtFecha.Value = objDocumento.fechaRegistro
            cboTipoDoc.SelectedValue = objDocumento.tipodoc
            txtSerie.Text = objDocumento.serie
            txtNumero.Text = objDocumento.numero
            cboMembresia.SelectedValue = objDocumento.CustomMembresia.idMembresia
            cboPeriodicida.SelectedValue = objDocumento.CustomMembresia.tipo.ToString
            txtValDuracion.Text = objDocumento.CustomMembresia.valorDuracion
            txtDuracion.Text = objDocumento.CustomMembresia.tipoDuracion
            txtValido.Value = objDocumento.CustomMembresia.fechafin
            txtInfoExtra.Text = objDocumento.CustomMembresia.detalle

            'Servicio Contractutal
            txtFechaInicio.Value = objDocumento.fechaInicio.Value
            txtFechVcto.Value = objDocumento.fechaVcto
            txtCongela_dia.Value = objDocumento.congela_dia
            txtTotalPagar.DecimalValue = objDocumento.importe
            CalculoVenta()
        End If
    End Sub

    Private Sub CalculoDias()
        Dim result = Nothing
        Dim fActual = txtFechaInicio.Value
        Select Case txtDuracion.Text.ToLower
            Case "años"
                result = fActual.AddYears(Decimal.Parse(txtValDuracion.Text))
            Case "mes"
                result = fActual.AddMonths(Decimal.Parse(txtValDuracion.Text)).AddDays(-1)
            Case "días"
                result = fActual.AddDays(Decimal.Parse(txtValDuracion.Text)).AddDays(-1)
        End Select
        txtFechVcto.Value = result

    End Sub


    Private Sub CalculoVenta()
        Dim total As Decimal = txtTotalPagar.DecimalValue
        Dim opGravada As Decimal = Math.Round(total / 1.18, 2)
        Dim Iva As Decimal = total - opGravada

        txtOpGravada.DecimalValue = opGravada
        txtTotalIva.DecimalValue = Iva
    End Sub

    Private Sub Grabar()
        Dim numeroDocCaja As String = Nothing
        Dim strPago As Integer
        Dim total As Decimal = 0
        Dim opGravada As Decimal = 0
        Dim opExonera As Decimal = 0
        Dim opInafecta As Decimal = 0
        Dim Iva As Decimal = 0

        If chIngresoLibre.Checked = True Then
            strPago = Gimnasio_EstadoMembresiaPago.IngresoLibre
        Else
            Select Case cboPago.Text
                Case "AL CONTADO"
                    strPago = Gimnasio_EstadoMembresiaPago.Completo
                Case "AL CREDITO"
                    strPago = Gimnasio_EstadoMembresiaPago.Pendiente
                Case "PAGO PARCIAL"
                    strPago = Gimnasio_EstadoMembresiaPago.PagoParcial
            End Select
        End If

        documento = New documento
        documento.IsFormatoGeneral = CheckBox1.Checked
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = cboTipoDoc.SelectedValue
        documento.fechaProceso = txtFecha.Value
        documento.moneda = "1"
        documento.idEntidad = txtCliente2.Tag
        documento.entidad = txtCliente2.Text
        documento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        documento.nrodocEntidad = txtRuc2.Text
        documento.nroDoc = txtSerie.Text & "-" & txtNumero.Text
        documento.tipoOperacion = StatusTipoOperacion.VENTA
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = Date.Now

        membresia = membresiaSA.UbicarMembresia(cboMembresia.SelectedValue)

        Dim totalDias = DateDiff(DateInterval.Day, txtFechaInicio.Value, txtFechVcto.Value)
        totalDias += 1

        Dim stadoMembresia = Nothing
        If totalDias = 1 Then
            stadoMembresia = Integer.Parse(Gimnasio_EstadoMembresia.Baja)
        ElseIf totalDias <= 0 Then
            Throw New Exception("El número de días de servicio contractual debe ser mayor a cero")
        Else
            stadoMembresia = Integer.Parse(Gimnasio_EstadoMembresia.Activo)
        End If

        Select Case strPago
            Case Gimnasio_EstadoMembresiaPago.Completo, Gimnasio_EstadoMembresiaPago.PagoParcial, Gimnasio_EstadoMembresiaPago.Pendiente
                opGravada = txtOpGravada.DecimalValue
                opExonera = txtOpExonerada.DecimalValue
                opInafecta = txtOpInafecta.DecimalValue
                Iva = txtTotalIva.DecimalValue
                total = txtTotalPagar.DecimalValue
            Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                opGravada = 0
                opExonera = 0
                opInafecta = 0
                Iva = 0
                total = 0
        End Select

        documento.Entidadmembresia_Gym = New Entidadmembresia_Gym With
            {
            .idMembresia = membresia.idMembresia,
            .restriccion = chRestriccion.Checked,
            .diashabilesUso = txtDiasHabilitados.Value,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .tipoServicio = Integer.Parse(membresia.tipoServicio),
            .idEntidad = txtCliente2.Tag,
            .tipodoc = cboTipoDoc.SelectedValue,
            .serie = txtSerie.Text,
            .numero = txtNumero.Text,
            .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
            .fechaRegistro = txtFecha.Value,
            .periodo = GetPeriodo(txtPeriodo.Value, True),
            .fechaInicio = txtFechaInicio.Value,
            .fechaVcto = txtFechVcto.Value,
            .contract_mes = 0,
            .contract_dia = 0,
            .congela_mes = 0,
            .congela_dia = txtCongela_dia.Value,
            .opGravado = opGravada,
            .opExonerada = opExonera,
            .opInafecta = opInafecta,
            .iva = Iva,
            .importe = total,
            .statusMembresia = stadoMembresia,
            .statusPago = strPago,
            .vendedor = txtVendedor.Tag,
            .instructor = txtInstructor.Tag,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
        }

        Select Case cboFormaPagoCaja.SelectedValue
            Case "109"
                numeroDocCaja = "-"
            Case "001"
                numeroDocCaja = "-"
        End Select

        Select Case strPago
            Case Gimnasio_EstadoMembresiaPago.Completo
                'Mapeando el pago
                Dim documentocaja As New documento
                documentocaja = New documento
                documentocaja.idEmpresa = Gempresas.IdEmpresaRuc
                documentocaja.idCentroCosto = GEstableciento.IdEstablecimiento
                documentocaja.tipoDoc = "9908" ' cboFormaPagoCaja.SelectedValue
                documentocaja.nroDoc = numeroDocCaja
                'Select Case cboFormaPago.Text
                '    Case "Efectivo"
                '        documentocaja.tipoDoc = "109"
                '    Case "Tarjeta"
                '        documentocaja.tipoDoc = "005"
                '    Case "Deposito"
                '        documentocaja.tipoDoc = "001"
                'End Select
                documentocaja.fechaProceso = txtFecha.Value
                documentocaja.moneda = "1"
                documentocaja.idEntidad = txtCliente2.Tag
                documentocaja.entidad = txtCliente2.Text
                documentocaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                documentocaja.nrodocEntidad = txtRuc2.Text
                documentocaja.nroDoc = txtSerie.Text & "-" & txtNumero.Text
                documentocaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                documentocaja.usuarioActualizacion = usuario.IDUsuario
                documentocaja.fechaActualizacion = Date.Now

                documentocaja.documentoCaja = New documentoCaja With
                    {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .entidadFinanciera = txtCF_name.Tag,
                    .tipoDocPago = "9908",
                    .TipoDocumentoPago = "9908",
                    .formapago = cboFormaPagoCaja.SelectedValue,
                    .numeroDoc = numeroDocCaja,
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_VENTAS_E_INGRESOS,
                    .tipoMovimiento = "DC",
                    .idPersonal = txtCliente2.Tag,
                    .fechaProceso = txtFecha.Value,
                    .periodo = GetPeriodo(txtPeriodo.Value, True),
                    .fechaCobro = txtFecha.Value,
                    .tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES,
                    .numeroOperacion = txtNumOper.Text,
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text,
                    .tipoCambio = 1,
                    .montoSoles = txtTotalPagar.DecimalValue,
                    .montoUsd = 0,
                    .glosa = "Venta de membresias",
                    .entregado = "NO",
                    .movimientoCaja = "DC",
                    .estadopago = Gimnasio_StatusCobrosRealizados.DineroEntregado,
                    .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
                    .usuarioModificacion = usuario.IDUsuario,
                    .fechaModificacion = Date.Now
                }

                documentocaja.documentoCaja.documentoCajaDetalle.Add(New documentoCajaDetalle With
                                                                                      {
                                                                                     .fecha = txtFecha.Value,
                                                                                     .idItem = cboMembresia.SelectedValue,
                                                                                     .DetalleItem = cboMembresia.Text,
                                                                                     .montoSoles = txtTotalPagar.DecimalValue,
                                                                                     .montoUsd = 0,
                                                                                     .entregado = "S",
                                                                                     .estado = "",
                                                                                     .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
                                                                                     .usuarioModificacion = usuario.IDUsuario,
                                                                                     .fechaModificacion = Date.Now
                                                                                      })


                documento.CustomDocumentoCaja = documentocaja
            Case Gimnasio_EstadoMembresiaPago.Pendiente

            Case Gimnasio_EstadoMembresiaPago.PagoParcial
                'Mapeando el pago parcial
                Dim documentocaja As New documento
                documentocaja = New documento
                documentocaja.idEmpresa = Gempresas.IdEmpresaRuc
                documentocaja.idCentroCosto = GEstableciento.IdEstablecimiento
                documentocaja.tipoDoc = "9908" ' cboFormaPagoCaja.SelectedValue
                documentocaja.nroDoc = numeroDocCaja
                'Select Case cboFormaPago.Text
                '    Case "Efectivo"
                '        documentocaja.tipoDoc = "109"
                '    Case "Tarjeta"
                '        documentocaja.tipoDoc = "005"
                '    Case "Deposito"
                '        documentocaja.tipoDoc = "001"
                'End Select
                documentocaja.fechaProceso = txtFecha.Value
                documentocaja.moneda = "1"
                documentocaja.idEntidad = txtCliente2.Tag
                documentocaja.entidad = txtCliente2.Text
                documentocaja.tipoEntidad = "CL"
                documentocaja.nrodocEntidad = txtRuc2.Text
                documentocaja.nroDoc = txtSerie.Text & "-" & txtNumero.Text
                documentocaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                documentocaja.usuarioActualizacion = usuario.IDUsuario
                documentocaja.fechaActualizacion = Date.Now

                documentocaja.documentoCaja = New documentoCaja With
                    {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .entidadFinanciera = txtCF_name.Tag,
                    .tipoDocPago = "9908",
                    .TipoDocumentoPago = "9908",
                    .formapago = cboFormaPagoCaja.SelectedValue,
                    .numeroDoc = numeroDocCaja,
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_VENTAS_E_INGRESOS,
                    .tipoMovimiento = "DC",
                    .idPersonal = txtCliente2.Tag,
                    .fechaProceso = txtFecha.Value,
                    .periodo = GetPeriodo(txtPeriodo.Value, True),
                    .fechaCobro = txtFecha.Value,
                    .tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES,
                    .numeroOperacion = txtNumOper.Text,
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text,
                    .tipoCambio = 1,
                    .montoSoles = txtPagoParcial.DecimalValue,
                    .montoUsd = 0,
                    .glosa = "Venta de membresías",
                    .entregado = "NO",
                    .movimientoCaja = "DC",
                    .estadopago = Gimnasio_StatusCobrosRealizados.DineroEntregado,
                    .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
                    .usuarioModificacion = usuario.IDUsuario,
                    .fechaModificacion = Date.Now
                }

                documentocaja.documentoCaja.documentoCajaDetalle.Add(New documentoCajaDetalle With
                                                                                      {
                                                                                     .fecha = txtFecha.Value,
                                                                                     .idItem = cboMembresia.SelectedValue,
                                                                                     .DetalleItem = cboMembresia.Text,
                                                                                     .montoSoles = txtPagoParcial.DecimalValue,
                                                                                     .montoUsd = 0,
                                                                                     .entregado = "S",
                                                                                     .estado = "",
                                                                                     .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
                                                                                     .usuarioModificacion = usuario.IDUsuario,
                                                                                     .fechaModificacion = Date.Now
                                                                                      })


                documento.CustomDocumentoCaja = documentocaja
        End Select



        membresia_GymSA.GrabarClienteMembresia(documento)
        Close()
    End Sub

    ''' <summary>
    ''' Cargar combobox tipo de comprobantes de venta
    ''' </summary>
    ''' <param name="FormatoGeneral"></param>
    Private Sub LoadCombos(FormatoGeneral As Boolean)
        tablaSA = New tablaDetalleSA
        membresiaSA = New membresia_GymSA
        Dim listax As New List(Of String)

        Select Case FormatoGeneral
            Case True ' formato general
                listax.Add("01")
                listax.Add("03")
            Case Else
                listax.Add("12.1")
                listax.Add("12.2")
        End Select
        cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(10, "1").Where(Function(o) listax.Contains(o.codigoDetalle)).ToList
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
    End Sub

    Sub CargarCombosPrincipales()
        tablaSA = New tablaDetalleSA
        cboMembresia.DataSource = membresia_GymSA.GetMembresiasByStatus(New membresia_Gym With {.idEmpresa = Gempresas.IdEmpresaRuc, .status = Gimnasio_EstadoMembresia.Activo})
        cboMembresia.DisplayMember = "descripcion"
        cboMembresia.ValueMember = "idMembresia"

        cboPeriodicida.DataSource = tablaSA.GetListaTablaDetalle(505, "1")
        cboPeriodicida.DisplayMember = "descripcion"
        cboPeriodicida.ValueMember = "codigoDetalle"
        ubicarMembresia(cboMembresia.SelectedValue)
    End Sub

    Private Sub ubicarMembresia(id As Integer)
        membresiaSA = New membresia_GymSA
        Dim membresia = membresiaSA.UbicarMembresia(id)
        If membresia IsNot Nothing Then
            cboPeriodicida.SelectedValue = membresia.tipo.ToString()
            txtValido.Value = membresia.fechafin
            txtInfoExtra.Text = membresia.detalle
            txtValDuracion.Text = membresia.valorDuracion
            txtDuracion.Text = membresia.tipoDuracion
            txtDiasHabilitados.Maximum = membresia.valorDuracion
            txtDiasHabilitados.Value = membresia.valorDuracion
            'txtContrac_mes.Value = membresia.contract_mes
            'txtContrac_dia.Value = membresia.contract_dia
            'txtCongela_mes.Value = membresia.congela_mes
            txtCongela_dia.Value = membresia.congela_dia
            txtTotalPagar.DecimalValue = membresia.costo
            CalculoVenta()
            CalculoDias()
        End If
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If CheckBox1.Checked = True Then
            If txtSerie.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(txtSerie, "Ingrese Serie")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(txtSerie, Nothing)
            End If

            If txtNumero.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(txtNumero, "Ingrese número documento")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(txtNumero, Nothing)
            End If
        End If

        If txtCliente2.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtCliente2, "Ingrese al cliente")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtCliente2, Nothing)
        End If

        If chIngresoLibre.Checked = True Then
            txtOpGravada.DecimalValue = 0
            txtOpExonerada.DecimalValue = 0
            txtOpInafecta.DecimalValue = 0
            txtTotalIva.DecimalValue = 0
            txtTotalPagar.DecimalValue = 0
        Else
            Select Case cboPago.Text
                Case "AL CONTADO"
                    If txtCF_name.Text.Trim.Length = 0 Then
                        ErrorProvider1.SetError(txtCF_name, "Ingrese una cuenta financiera")
                        listaErrores += 1
                    Else
                        ErrorProvider1.SetError(txtCF_name, Nothing)
                    End If
                Case "AL CREDITO"

                Case "PAGO PARCIAL"
                    If txtCF_name.Text.Trim.Length = 0 Then
                        ErrorProvider1.SetError(txtCF_name, "Ingrese una cuenta financiera")
                        listaErrores += 1
                    Else
                        ErrorProvider1.SetError(txtCF_name, Nothing)
                    End If

                    If txtPagoParcial.DecimalValue <= 0 Then
                        ErrorProvider1.SetError(txtPagoParcial, "Ingrese un importe del pago  parcial")
                        listaErrores += 1
                    Else
                        ErrorProvider1.SetError(txtPagoParcial, Nothing)
                    End If
            End Select
        End If


        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function
#End Region

#Region "Events"
    Private Sub ComboBoxAdv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMembresia.SelectedIndexChanged
        If Not IsNothing(cboMembresia.SelectedValue) Then
            Dim codMembresia = cboMembresia.SelectedValue
            If IsNumeric(codMembresia) Then
                ubicarMembresia(Integer.Parse(codMembresia))
            End If
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
        f.CaptionLabels(0).Text = "Clientes"
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

    Private Sub txtRuc2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc2.Text.Trim.Length > 0 Then
                Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE, txtRuc2.Text.Trim)
                f.CaptionLabels(0).Text = "Clientes"
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
            End If
        End If
    End Sub

    Private Sub btRegistrar_Click(sender As Object, e As EventArgs) Handles btRegistrar.Click
        Try
            If ValidarGrabado() = True Then
                Grabar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Validar membresía activa", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub cboPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPago.SelectedValueChanged
        Try
            If Not IsNothing(cboPago.Text) Then
                Select Case cboPago.Text
                    Case "AL CONTADO"
                        txtPagoParcial.Visible = False
                        txtPagoParcial.DecimalValue = 0
                        Size = New Size(816, 720)
                    Case "AL CREDITO"
                        txtPagoParcial.Visible = False
                        txtPagoParcial.DecimalValue = 0
                        Size = New Size(816, 575)
                    Case "PAGO PARCIAL"
                        txtPagoParcial.Visible = True
                        txtPagoParcial.DecimalValue = 0
                        txtPagoParcial.Select()
                        Size = New Size(816, 720)
                End Select
                Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
                Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
                Dim x As Integer = boundWidth - Width
                Dim y As Integer = boundHeight - Height
                Location = New Point(x \ 2, y \ 2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicio.ValueChanged
        If IsDate(txtFechaInicio.Value) Then
            CalculoDias()
        End If
    End Sub

    Private Sub cboMembresia_Click(sender As Object, e As EventArgs) Handles cboMembresia.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmSeleccionCuentaFinanciera = New frmSeleccionCuentaFinanciera
        frmSeleccionCuentaFinanciera.txtPeriodo.Value = txtPeriodo.Value
        frmSeleccionCuentaFinanciera.GetCuentasFinancieras("CUENTAS EN EFECTIVO")
        frmSeleccionCuentaFinanciera.StartPosition = FormStartPosition.CenterParent
        frmSeleccionCuentaFinanciera.ShowDialog()
        If frmSeleccionCuentaFinanciera.Tag IsNot Nothing Then
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

    Private Sub cboPago_Click(sender As Object, e As EventArgs) Handles cboPago.Click

    End Sub

    Private Sub cboFormaPagoCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFormaPagoCaja.SelectedValueChanged
        If Not IsNothing(cboFormaPagoCaja.SelectedValue) Then
            Dim v = cboFormaPagoCaja.SelectedValue.ToString
            Select Case v
                Case "109"
                    cboEntidades.Visible = False
                    PictureBox1.Visible = False
                    txtCuentaCorriente.Visible = False
                    txtNumOper.Visible = False
                Case "001"
                    cboEntidades.Visible = True
                    PictureBox1.Visible = True
                    txtCuentaCorriente.Visible = True
                    txtNumOper.Visible = True
            End Select
        End If
    End Sub

    Private Sub cboFormaPagoCaja_Click(sender As Object, e As EventArgs) Handles cboFormaPagoCaja.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim f As New frmNuevoSocioGym()
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        'f.rbJuridico.Checked = True
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            txtCliente2.Text = c.nombreCompleto
            txtRuc2.Text = c.nrodoc
            txtCliente2.Tag = c.idEntidad
            txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles chIngresoLibre.CheckedChanged
        Cursor = Cursors.WaitCursor
        If chIngresoLibre.Checked = True Then
            '   ComboBoxAdv1_SelectedIndexChanged(sender, e)
            cboPago.SelectedIndex = 1
            cboPago.Enabled = False
            txtOpGravada.DecimalValue = 0
            txtOpExonerada.DecimalValue = 0
            txtOpInafecta.DecimalValue = 0
            txtTotalIva.DecimalValue = 0
            txtTotalPagar.DecimalValue = 0
        Else
            cboPago.SelectedIndex = 0
            cboPago.Enabled = True
            ComboBoxAdv1_SelectedIndexChanged(sender, e)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            LoadCombos(False)
            txtSerie.Visible = False
            txtNumero.Visible = False
            txtSerie.Clear()
            txtNumero.Clear()
            txtSerie.Text = 0
            txtNumero.Text = 0
        Else
            LoadCombos(True)
            txtSerie.Visible = True
            txtNumero.Visible = True
            txtSerie.Clear()
            txtNumero.Clear()
        End If
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkVendedor.LinkClicked
        frmTrabajadorBusqueda = New frmTrabajadorBusqueda
        frmTrabajadorBusqueda.statusEntidad = TIPO_ENTIDAD.VENDEDOR_MEMBRESIAS
        frmTrabajadorBusqueda.StartPosition = FormStartPosition.CenterParent
        frmTrabajadorBusqueda.ShowDialog()
        If frmTrabajadorBusqueda.Tag IsNot Nothing Then
            Dim c = CType(frmTrabajadorBusqueda.Tag, Helios.Planilla.Business.Entity.Personal)
            txtVendedor.Text = c.FullName
            txtVendedor.Tag = c.IDPersonal
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkInstructor.LinkClicked
        frmTrabajadorBusqueda = New frmTrabajadorBusqueda
        frmTrabajadorBusqueda.statusEntidad = TIPO_ENTIDAD.INSTRUCTOR_GIMNASIO
        frmTrabajadorBusqueda.StartPosition = FormStartPosition.CenterParent
        frmTrabajadorBusqueda.ShowDialog()
        If frmTrabajadorBusqueda.Tag IsNot Nothing Then
            Dim c = CType(frmTrabajadorBusqueda.Tag, Helios.Planilla.Business.Entity.Personal)
            txtInstructor.Text = c.FullName
            txtInstructor.Tag = c.IDPersonal
        End If
    End Sub

    Private Sub chVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chVendedor.CheckedChanged
        If chVendedor.Checked = True Then
            LinkVendedor.Visible = True
            txtVendedor.Visible = True
        Else
            LinkVendedor.Visible = False
            txtVendedor.Visible = False
        End If
    End Sub

    Private Sub chInstructor_CheckedChanged(sender As Object, e As EventArgs) Handles chInstructor.CheckedChanged
        If chInstructor.Checked = True Then
            LinkInstructor.Visible = True
            txtInstructor.Visible = True
        Else
            LinkInstructor.Visible = False
            txtInstructor.Visible = False
        End If
    End Sub

    Private Sub chRestriccion_CheckedChanged(sender As Object, e As EventArgs) Handles chRestriccion.CheckedChanged
        If chRestriccion.Checked = True Then
            txtDiasHabilitados.Value = txtValDuracion.Text
            txtDiasHabilitados.Enabled = True
        Else
            txtDiasHabilitados.Value = txtValDuracion.Text
            txtDiasHabilitados.Enabled = False
        End If
    End Sub
#End Region

End Class