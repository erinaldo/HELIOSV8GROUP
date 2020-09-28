Imports Helios.Cont.Business.Entity
Imports Syncfusion.Grouping
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion
Imports Syncfusion.Windows.Forms.Grid
Imports System.Runtime.Serialization
Imports Syncfusion.Windows.Forms

Public Class FormPagarDoc

#Region "Variables"
    Public Property pagoAnticipo As documentoAnticipo
    Public Property Saldo As Decimal
    Public Property compraSA As New DocumentoCompraSA
    Public Property ListaDetalleCompra As List(Of documentocompradetalle)
    Public Property compraCabecera As documentocompra
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetConfigInicio()
        GetpagosDetalle(idDocumento)
        HistorialPagos(idDocumento)
        LoadComboFechas()
        GetDataPays()
    End Sub
#End Region

#Region "Methdos"

    Private Sub HistorialPagos(iddoc As Integer)
        Dim cajaSA As New DocumentoCajaSA
        Dim dt As New DataTable

        dt.Columns.Add("iddoc")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("numerodoc")
        dt.Columns.Add("formapago")
        dt.Columns.Add("nrooper")
        dt.Columns.Add("entidadfinanciera")
        dt.Columns.Add("identidadfinanciera")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tcambio")
        dt.Columns.Add("importe")
        dt.Columns.Add("importeME")

        Dim listado = cajaSA.ListadoComprobaNtesXidPadre(iddoc)

        Dim valor As Decimal = 0
        For Each i In listado

            Select Case compraCabecera.monedaDoc
                Case "1"
                    If i.moneda = "1" Then
                        valor = 0
                    Else
                        valor = i.montoUsdTransacc
                    End If
                Case "2"
                    If i.moneda = "1" Then
                        valor = i.montoUsd
                    Else
                        valor = i.montoUsd 'i.montoUsdTransacc
                    End If
            End Select

            dt.Rows.Add(
                i.idDocumento,
                i.fechaCobro,
                i.tipoDocPago,
                i.numeroDoc,
                i.formapago,
                i.numeroOperacion,
                i.NombreCaja,
                String.Empty,
                i.moneda,
                i.tipoCambio,
                i.montoSoles,
                valor)
        Next
        GridPagosResumen.DataSource = dt
    End Sub

    Sub GetCajasSaldo()
        'Dim pagoSA As New EstadosFinancierosConfiguracionPagosSA
        'ListConfigurationPays = pagoSA.GetConfigurationPaySaldo(New estadosFinancierosConfiguracionPagos With
        '        {
        '        .idEmpresa = Gempresas.IdEmpresaRuc,
        '        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '        .fecha = DateTime.Now
        '                                                   })
        If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

            Dim query = (From i In ListaCajasActivas
                         Where i.estadoCaja = "A" And i.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault



            If query IsNot Nothing Then

                Dim pagoSA As New EstadosFinancierosConfiguracionPagosSA
                ListConfigurationPays = pagoSA.GetConfigurationPaySaldo(New estadosFinancierosConfiguracionPagos With
                    {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fecha = DateTime.Now,
                    .IDCaja = query.idcajaUsuario,
                    .tipoCaja = "EF"
                                                               })
            End If




        ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

            Dim query = (From i In ListaCajasActivas
                         Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).SingleOrDefault
            If query IsNot Nothing Then

                Dim pagoSA As New EstadosFinancierosConfiguracionPagosSA
                ListConfigurationPays = pagoSA.GetConfigurationPaySaldoCajero(New estadosFinancierosConfiguracionPagos With
                    {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fecha = DateTime.Now,
                    .IDCaja = query.idcajaUsuario,
                    .tipoCaja = "EP"
                                                               })
            End If
        End If

        TxtDia.Text = DateTime.Now.Day
    End Sub

    Sub GetDataPays()

        GetCajasSaldo()

        Dim dt As New DataTable
        dt.Columns.Add("idforma")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("identidad")
        dt.Columns.Add("entidad")
        dt.Columns.Add("codigocontable")
        dt.Columns.Add("importe")
        dt.Columns.Add("saldo")
        dt.Columns.Add("nrooperacion")
        dt.Columns.Add("tipo")
        dt.Columns.Add("caja", GetType(documentoCaja))
        dt.Columns.Add("moneda")
        dt.Columns.Add("abonadoME")

        For Each i In ListConfigurationPays
            Select Case i.moneda
                Case "1"
                    dt.Rows.Add(i.IDFormaPago, $"{i.FormaPago} - {If(i.moneda = "1", "{Soles}", "{Dolares}")}", i.identidad, i.entidad, String.Empty, 0, i.MontoCaja, String.Empty, "CA", Nothing, i.moneda, 0)
                Case "2"
                    dt.Rows.Add(i.IDFormaPago, $"{i.FormaPago} - {If(i.moneda = "1", "{Soles}", "{Dolares}")}", i.identidad, i.entidad, String.Empty, 0, i.MontoCajaME, String.Empty, "CA", Nothing, i.moneda, 0)
            End Select

        Next
        'Dim efectivo = ListConfigurationPays.Where(Function(o) o.tipo = "EF").SingleOrDefault

        'If efectivo IsNot Nothing Then
        '    dt.Rows.Add("EFECTIVO", efectivo.identidad, efectivo.entidad, String.Empty, 0)
        'Else
        '    'dt.Rows.Add("EFECTIVO", 0, String.Empty, String.Empty, 0)
        'End If

        'dt.Rows.Add("DEPOSITO", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("TARJETA", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("CHEQUE", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("VALE", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("COMPENSACION", 0, String.Empty, String.Empty, 0)

        GridPagos.DataSource = dt
    End Sub

    Private Sub LoadComboFechas()
        Dim empresaAnioSA As New empresaPeriodoSA

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

    End Sub

    Private Sub GetpagosDetalle(idDocumento As Integer)
        compraCabecera = compraSA.GetUbicarCompraPorID(idDocumento)
        If compraCabecera Is Nothing Then
            Throw New Exception("No se encontró el documento de referencia")
        End If

        ListaDetalleCompra = compraSA.GetPagosByDocumento(
            New documentocompra With {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = GEstableciento.IdEstablecimiento,
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
            .idDocumento = idDocumento})

        If ListaDetalleCompra.Count <= 0 Then
            Throw New Exception("No se encontraron items para pagar")
        Else
            If compraCabecera.monedaDoc = "1" Then
                Saldo = ListaDetalleCompra.Sum(Function(o) o.importe).GetValueOrDefault
            Else
                Saldo = ListaDetalleCompra.Sum(Function(o) o.importeUS).GetValueOrDefault
            End If

            DigitalGauge2.Text = Saldo
            DigitalGauge2.Value = Saldo

            DigitalPagos.Text = "0.00"
            DigitalPagos.Value = "0.00"

            DigitalSaldo.Text = "0.00"
            DigitalSaldo.Value = "0.00"
        End If
    End Sub

    Private Sub GetConfigInicio()
        GridPagosResumen.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(GridPagosResumen.TableModel))
        FormatoGridAvanzado(GridPagosResumen, False, False, 9.0F)
        DigitalGauge2.OuterFrameGradientStartColor = Color.White
        DigitalGauge2.OuterFrameGradientEndColor = Color.White
        DigitalGauge2.ForeColor = Color.Black
        DigitalGauge2.FrameBorderColor = Color.Black

        DigitalPagos.OuterFrameGradientStartColor = Color.White
        DigitalPagos.OuterFrameGradientEndColor = Color.White
        DigitalPagos.ForeColor = Color.Purple
        DigitalGauge2.FrameBorderColor = Color.Purple

        DigitalSaldo.OuterFrameGradientStartColor = Color.White
        DigitalSaldo.OuterFrameGradientEndColor = Color.White
        DigitalSaldo.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        DigitalGauge2.FrameBorderColor = Color.FromKnownColor(KnownColor.HotTrack)
    End Sub

    Private Function GetPagos() As List(Of documentoCaja)
        GetPagos = New List(Of documentoCaja)
        For Each r As Record In GridPagos.Table.Records
            'If CDec(r.GetValue("importe")) <= 0 Then
            '    Throw New Exception("Debe indicar un importe mayor a cero")
            'End If
            If compraCabecera.monedaDoc = "1" Then
                If r.GetValue("tipo") = "CA" Then
                    If CDec(r.GetValue("importe")) > 0 Then

                        Dim movimientosCajaex = CType(r.GetValue("caja"), documentoCaja)

                        GetPagos.Add(New documentoCaja With
                                 {
                                    .IdEntidadFinanciera = Integer.Parse(r.GetValue("identidad").ToString()),
                                    .NomCajaOrigen = r.GetValue("entidad"),
                                    .montoSoles = Decimal.Parse(r.GetValue("importe")),
                                    .montoUsd = Decimal.Parse(r.GetValue("abonadoME")),
                                    .formapago = r.GetValue("idforma"),
                                    .numeroOperacion = r.GetValue("nrooperacion"),
                                    .movimientocajaextranjera = movimientosCajaex.movimientocajaextranjera
                                 })
                    End If

                End If
            Else

                If r.GetValue("tipo") = "CA" Then
                    If CDec(r.GetValue("abonadoME")) > 0 Then

                        Dim movimientosCajaex = CType(r.GetValue("caja"), documentoCaja)

                        GetPagos.Add(New documentoCaja With
                                 {
                                    .IdEntidadFinanciera = Integer.Parse(r.GetValue("identidad").ToString()),
                                    .NomCajaOrigen = r.GetValue("entidad"),
                                    .montoSoles = Decimal.Parse(r.GetValue("importe")),
                                    .montoUsd = Decimal.Parse(r.GetValue("abonadoME")),
                                    .formapago = r.GetValue("idforma"),
                                    .numeroOperacion = r.GetValue("nrooperacion"),
                                    .movimientocajaextranjera = movimientosCajaex.movimientocajaextranjera
                                 })
                    End If

                End If

            End If

        Next
    End Function

    Private Function SumaPagos() As Decimal
        SumaPagos = 0
        For Each i In GridPagos.Table.Records
            'If i.GetValue("importe") <= 0 Then
            '    Throw New Exception("El monto abonado debe sre mayor a cero")
            'End If
            SumaPagos += CDec(i.GetValue("importe"))
        Next
        Return SumaPagos
    End Function

    Private Function SumaPagosME() As Decimal
        SumaPagosME = 0
        For Each i In GridPagos.Table.Records
            'If i.GetValue("importe") <= 0 Then
            '    Throw New Exception("El monto abonado debe sre mayor a cero")
            'End If
            SumaPagosME += CDec(i.GetValue("abonadoME"))
        Next
        Return SumaPagosME
    End Function

    Public Function RegistrarPagos() As List(Of documentoCaja)
        RegistrarPagos = New List(Of documentoCaja)
        Try
            Dim pagos As Decimal = 0
            If compraCabecera.monedaDoc = "1" Then
                pagos = SumaPagos()
            Else
                pagos = SumaPagosME()
            End If

            If pagos > CDec(Saldo) Then
                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            ElseIf pagos <= 0 Then
                MessageBox.Show("El pago debe ser mayor cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            End If

            If pagos < CDec(Saldo) Then
                If MessageBox.Show("El pago realizado es menor a la venta total, desea continuar ?", "Verificar pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RegistrarPagos = GetPagos()

                    If RegistrarPagos.Count = 0 Then
                        MessageBox.Show("Debe realizar al menos un pago", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Function
                    End If

                    Return RegistrarPagos

                Else
                    Exit Function
                End If
            ElseIf pagos = CDec(Saldo) Then
                RegistrarPagos = GetPagos()
                If RegistrarPagos.Count = 0 Then
                    MessageBox.Show("Debe realizar al menos un pago", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Function
                End If
                Return RegistrarPagos

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Validar importe")
        End Try
    End Function

    Public Function ListaPagosCajas(lista As List(Of documentoCaja), envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        Dim fechaPago As New DateTime(cboAnio.Text, cboMesCompra.SelectedValue, TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        For Each i In lista

            nDocumentoCaja = New documento
            nDocumentoCaja.idDocumento = 0
            nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
            nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
            nDocumentoCaja.tipoDoc = "9903" ' cbotipoDocPago.SelectedValue
            nDocumentoCaja.fechaProceso = fechaPago
            nDocumentoCaja.nroDoc = i.numeroOperacion ' txtNumOper.Text
            nDocumentoCaja.idOrden = Nothing
            nDocumentoCaja.moneda = i.movimientocajaextranjera.FirstOrDefault.moneda ' i.moneda

            nDocumentoCaja.idEntidad = compraCabecera.entidad.idEntidad
            nDocumentoCaja.entidad = compraCabecera.entidad.nombreCompleto
            nDocumentoCaja.nrodocEntidad = compraCabecera.entidad.nrodoc

            nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            nDocumentoCaja.tipoOperacion = StatusTipoOperacion.PAGO_A_PROVEEDORES
            nDocumentoCaja.usuarioActualizacion = envio.IDCaja ' usuario.IDUsuario
            nDocumentoCaja.fechaActualizacion = DateTime.Now

            'DOCUMENTO CAJA
            objCaja = New documentoCaja
            objCaja.tipoOperacion = StatusTipoOperacion.PAGO_A_PROVEEDORES
            objCaja.idDocumento = 0
            objCaja.periodo = GetPeriodo(fechaPago, True)
            objCaja.idEmpresa = Gempresas.IdEmpresaRuc
            objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
            objCaja.fechaProceso = fechaPago
            objCaja.fechaCobro = fechaPago
            objCaja.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            objCaja.codigoProveedor = compraCabecera.entidad.idEntidad
            objCaja.IdProveedor = compraCabecera.entidad.idEntidad
            objCaja.idPersonal = compraCabecera.entidad.idEntidad
            objCaja.TipoDocumentoPago = compraCabecera.tipoDoc 'cbotipoDocPago.SelectedValue
            objCaja.codigoLibro = "1"
            objCaja.tipoDocPago = "9903"
            objCaja.formapago = i.formapago
            objCaja.NumeroDocumento = "-"
            objCaja.numeroOperacion = i.numeroOperacion
            objCaja.movimientoCaja = MovimientoCaja.PagoProveedor 'TIPO_VENTA.VENTA_POS_DIRECTA,
            objCaja.montoSoles = Decimal.Parse(i.montoSoles)

            objCaja.moneda = i.movimientocajaextranjera.FirstOrDefault.moneda ' "1"
            objCaja.tipoCambio = i.movimientocajaextranjera.FirstOrDefault.tipocambio.GetValueOrDefault ' TmpTipoCambio

            Select Case compraCabecera.monedaDoc
                Case "1"
                    If i.movimientocajaextranjera.FirstOrDefault.moneda = "1" Then
                        objCaja.montoUsd = 0 ' Decimal.Parse(objCaja.montoSoles / objCaja.tipoCambio)
                    Else
                        objCaja.montoUsd = i.movimientocajaextranjera.FirstOrDefault.Desembolso.GetValueOrDefault 'Decimal.Parse(objCaja.montoSoles / objCaja.tipoCambio)
                    End If
                Case "2"
                    If i.movimientocajaextranjera.FirstOrDefault.moneda = "1" Then
                        objCaja.montoUsd = i.movimientocajaextranjera.FirstOrDefault.importe.GetValueOrDefault ' Decimal.Parse(objCaja.montoSoles / objCaja.tipoCambio)
                    Else
                        objCaja.montoUsd = i.movimientocajaextranjera.FirstOrDefault.Desembolso.GetValueOrDefault 'Decimal.Parse(objCaja.montoSoles / objCaja.tipoCambio)
                    End If
            End Select




            objCaja.estado = "1"
            objCaja.glosa = ""
            objCaja.entregado = "SI"

            objCaja.idCajaUsuarioDestino = envio.IDCaja 'GFichaUsuarios.IdCajaUsuario
            objCaja.entidadFinancieraDestino = i.IdEntidadFinanciera
            objCaja.NombreEntidad = i.NomCajaOrigen
            objCaja.usuarioModificacion = envio.IDCaja ' usuario.IDUsuario
            objCaja.fechaModificacion = DateTime.Now
            objCaja.fechaProcesoDestino = fechaPago
            nDocumentoCaja.documentoCaja = objCaja
            nDocumentoCaja.documentoCaja.movimientocajaextranjera = i.movimientocajaextranjera
            nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, envio)
            '   asientoDocumento(nDocumentoCaja.documentoCaja)
            ListaDoc.Add(nDocumentoCaja)
        Next

        Return ListaDoc
    End Function


    Private Function GetDetallePago(objCaja As documentoCaja, envio As EnvioImpresionVendedorPernos) As List(Of documentoCajaDetalle)
        Dim montoPago = objCaja.montoSoles
        Dim montoPagoME = objCaja.montoUsd

        GetDetallePago = New List(Of documentoCajaDetalle)
        For Each i In ListaDetalleCompra

            'Select Case objCaja.moneda
            'Case "1"
            If compraCabecera.monedaDoc = "1" Then
                GetPagoMN(envio, GetDetallePago, montoPago, i)
            Else
                GetPagoME(envio, GetDetallePago, montoPagoME, montoPago, i, objCaja)
            End If

            '    Case "2"
            '  GetPagoME(envio, GetDetallePago, montoPago, i)
            ' End Select


        Next
    End Function

    Private Sub GetPagoMN(envio As EnvioImpresionVendedorPernos, GetDetallePago As List(Of documentoCajaDetalle), ByRef montoPago As Decimal?, ByRef i As documentocompradetalle)
        If montoPago > 0 Then
            If i.MontoSaldo > 0 Then
                If i.MontoSaldo > montoPago Then
                    Dim canUso = montoPago
                    i.MontoPago = canUso
                    i.estadoPago = i.ItemPendiente
                ElseIf i.MontoSaldo = montoPago Then
                    i.MontoPago = montoPago
                    i.estadoPago = i.ItemSaldado
                Else
                    Dim canUso = i.MontoSaldo
                    i.MontoPago = canUso
                    i.estadoPago = i.ItemSaldado
                End If
                montoPago -= i.MontoPago 'ImporteDisponible

                '.codigoLote = Integer.Parse(i.codigoLote),

                GetDetallePago.Add(New documentoCajaDetalle With
                               {
                               .fecha = Date.Now,
                               .codigoLote = 0,
                               .otroMN = 0,
                               .idItem = i.idItem,
                               .DetalleItem = i.descripcionItem,
                               .montoSoles = i.MontoPago,
                               .montoUsd = 0,' FormatNumber(i.MontoPago / TmpTipoCambio, 2),
                               .diferTipoCambio = 1,'TmpTipoCambio,
                               .tipoCambioTransacc = 1,' TmpTipoCambio,
                               .entregado = "SI",
                               .idCajaUsuario = envio.IDCaja,' GFichaUsuarios.IdCajaUsuario,
                               .usuarioModificacion = envio.IDCaja,' usuario.IDUsuario,
                               .documentoAfectado = compraCabecera.idDocumento,
                               .documentoAfectadodetalle = i.secuencia,
                               .EstadoCobro = i.estadoPago,
                               .fechaModificacion = DateTime.Now
                               })
                i.estadoPago = i.estadoPago
                'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                'item.estadoPago = i.EstadoPagos
            End If
        End If
    End Sub

    Private Sub GetPagoME(envio As EnvioImpresionVendedorPernos, GetDetallePago As List(Of documentoCajaDetalle), ByRef montoPagoME As Decimal?, montoPago As Decimal?, ByRef i As documentocompradetalle,
                          caja As documentoCaja)
        If montoPagoME > 0 Then
            If i.MontoSaldoME > 0 Then
                'REGION MONEDA EXTRANJERA
                '-----------------------------------------------
                If i.MontoSaldoME > montoPagoME Then
                    Dim canUso = montoPagoME
                    i.MontoPagoME = canUso
                    i.estadoPago = i.ItemPendiente
                ElseIf i.MontoSaldoME = montoPagoME Then
                    i.MontoPagoME = montoPagoME
                    i.estadoPago = i.ItemSaldado
                Else
                    Dim canUso = i.MontoSaldoME
                    i.MontoPagoME = canUso
                    i.estadoPago = i.ItemSaldado
                End If
                montoPagoME -= i.MontoPagoME 'ImporteDisponible


                'REGION MONEDA NACIONAL
                '-----------------------------------------------
                'If i.MontoSaldo > montoPago Then
                '    Dim canUso = montoPago
                '    i.MontoPago = canUso
                '    i.estadoPago = i.ItemPendiente
                'ElseIf i.MontoSaldo = montoPago Then
                '    i.MontoPago = montoPago
                '    i.estadoPago = i.ItemSaldado
                'Else
                '    Dim canUso = i.MontoSaldo
                '    i.MontoPago = canUso
                '    i.estadoPago = i.ItemSaldado
                'End If
                'montoPago -= i.MontoPago


                '.codigoLote = Integer.Parse(i.codigoLote),
                GetDetallePago.Add(New documentoCajaDetalle With
                               {
                               .fecha = Date.Now,
                               .codigoLote = 0,
                               .otroMN = 0,
                               .idItem = i.idItem,
                               .DetalleItem = i.descripcionItem,
                               .montoSoles = i.MontoPagoME * caja.tipoCambio,
                               .montoUsd = i.MontoPagoME,
                               .diferTipoCambio = TmpTipoCambio,
                               .tipoCambioTransacc = TmpTipoCambio,
                               .entregado = "SI",
                               .idCajaUsuario = envio.IDCaja,' GFichaUsuarios.IdCajaUsuario,
                               .usuarioModificacion = envio.IDCaja,' usuario.IDUsuario,
                               .documentoAfectado = compraCabecera.idDocumento,
                               .documentoAfectadodetalle = i.secuencia,
                               .EstadoCobro = i.estadoPago,
                               .fechaModificacion = DateTime.Now
                               })
                i.estadoPago = i.estadoPago
                'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                'item.estadoPago = i.EstadoPagos
            End If
        End If
    End Sub

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub
#End Region

#Region "Events"
    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridPagosResumen.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridPagosResumen.TableControlPushButtonClick
        Dim documentoSA As New DocumentoSA
        Dim docCajaSA As New DocumentoCajaSA
        Dim nDocumento As New documento()
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 9 Then

                Dim IdDocumentoPago = GridPagosResumen.TableModel(e.Inner.RowIndex, 1).CellValue
                If MessageBox.Show("Esta seguro de eliminar el pago selecionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    With nDocumento
                        .IdDocumentoAfectado = compraCabecera.idDocumento
                        .idDocumento = IdDocumentoPago
                        .idOrden = 9907
                        '     .usuarioActualizacion = docCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento).usuarioModificacion
                    End With
                    documentoSA.ElimiNarPagoCompra(nDocumento)
                    Me.GridPagosResumen.Table.Records(e.Inner.RowIndex - 2).Delete()
                    GetpagosDetalle(compraCabecera.idDocumento)

                    GetDataPays()

                    For Each i In GridPagos.Table.Records
                        i.SetValue("importe", 0)
                        i.SetValue("nrooperacion", String.Empty)
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Function GetDetallePagoAntComp(objCaja As documentoAnticipo, envio As EnvioImpresionVendedorPernos) As List(Of documentoAnticipoConciliacionCompra)
        Dim montoPago = objCaja.importeMN
        Dim tipoCon = ""
        Dim Operacion = ""
        GetDetallePagoAntComp = New List(Of documentoAnticipoConciliacionCompra)
        For Each i In ListaDetalleCompra
            If montoPago > 0 Then
                If i.MontoSaldo > 0 Then
                    If i.MontoSaldo > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemPendiente
                    ElseIf i.MontoSaldo = montoPago Then
                        i.MontoPago = montoPago
                        i.estadoPago = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldo
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible

                    '.codigoLote = Integer.Parse(i.codigoLote),
                    If objCaja.tipoAnticipo = "VNCA" Then
                        tipoCon = "ANT"
                        Operacion = "9936"
                    ElseIf objCaja.tipoAnticipo = "VRC" Then
                        tipoCon = "REC"
                        Operacion = "9935"
                    End If

                    GetDetallePagoAntComp.Add(New documentoAnticipoConciliacionCompra With
                                   {
                                   .idDocumento = objCaja.idDocumento,
                                   .fechaRegistro = DateTime.Now,
                                   .tipoOperacion = Operacion,'StatusTipoOperacion.COBRO_A_CLIENTES,
                                   .tipoConciliacion = tipoCon,
                                   .serie = "CMP",
                                   .tipoDocumento = "9912",
                                   .idItem = i.idItem,
                                   .detalle = i.descripcionItem,
                                   .importe = i.MontoPago,
                                   .idDetalle = i.secuencia,
                                   .idCajaUsuario = envio.IDCaja,' GFichaUsuarios.IdCajaUsuario,
                                   .usuarioActualizacion = envio.IDCaja, 'usuario.IDUsuario,
                                   .fechaActualizacion = DateTime.Now
                                   })
                    i.estadoPago = i.estadoPago
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
    End Function

    Private Function ListaPagosAntComp(lista As List(Of documentoAnticipo), envio As EnvioImpresionVendedorPernos) As List(Of documentoAnticipoConciliacionCompra)
        Dim ListaDoc As New List(Of documentoAnticipoConciliacionCompra)

        For Each i In lista

            ListaDoc.AddRange(GetDetallePagoAntComp(i, envio))

        Next

        Return ListaDoc

    End Function

    Private Function GetAnticipoRec() As List(Of documentoAnticipo)
        GetAnticipoRec = New List(Of documentoAnticipo)
        For Each r As Record In GridPagos.Table.Records

            If r.GetValue("tipo") = "VNCA" Or r.GetValue("tipo") = "VRC" Then

                If CDec(r.GetValue("importe")) > 0 Then
                    GetAnticipoRec.Add(New documentoAnticipo With
                             {
                                .idDocumento = Integer.Parse(r.GetValue("identidad").ToString()),
                                .importeMN = Decimal.Parse(r.GetValue("importe")),
                                .tipoAnticipo = r.GetValue("tipo")
                                 })
                End If
            End If

        Next
    End Function

    Private Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function

    Private Function GetConfiguracionUsuario(usuarioSel As Seguridad.Business.Entity.Usuario, cajaUsuario As cajaUsuario) As EnvioImpresionVendedorPernos
        Dim envio As EnvioImpresionVendedorPernos
        envio = New EnvioImpresionVendedorPernos With
            {
            .CodigoVendedor = usuarioSel.codigo,
            .IDCaja = cajaUsuario.idcajaUsuario,
            .IDVendedor = usuarioSel.IDUsuario,
            .print = True,
            .Nombreprint = String.Empty,
            .NombreCajero = usuarioSel.Full_Name,
            .EntidadFinanciera = 0,'ef.idestado,
            .EntidadFinancieraName = String.Empty
        }
        Return envio
    End Function

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim ndocumento As New documento
        Dim cajaSA As New DocumentoCajaSA
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Try

            If TxtDia.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar la fecha de pago")
                TxtDia.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            Dim Vendedor = (From i In UsuariosList Where i.IDUsuario = usuario.IDUsuario).FirstOrDefault   'GetCodigoVendedor()
            If Vendedor Is Nothing Then
                Throw New Exception("Debe indicar el codigo del vendedor!")
            End If

            'Dim cajaActiva = ListaCajasActivas.Where(Function(o) o.idPersona = Vendedor.IDUsuario).SingleOrDefault

            Dim cajaActiva = (From i In ListaCajasActivas
                              Where i.estadoCaja = "A" And i.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

            If cajaActiva Is Nothing Then
                Throw New Exception("no existe una caja activa, para " & Vendedor.Full_Name)
            End If

            Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(cajaActiva.idcajaUsuario)
            If cajaUsuario Is Nothing Then
                Throw New Exception("no existe caja activa!")
            End If
            Dim envio = GetConfiguracionUsuario(Vendedor, cajaUsuario)

            Dim ant = GetAnticipoRec()

            Dim c = RegistrarPagos()
            If c.Count > 0 Then
                ndocumento.documentocompra = New documentocompra
                Dim ListaPagos = ListaPagosCajas(c, envio)

                Dim ListaCompAnt = ListaPagosAntComp(ant, envio)

                Dim SumaPagos As Decimal = 0
                Dim SumaPagosAnt As Decimal = 0
                If compraCabecera.monedaDoc = "1" Then
                    For Each i In ListaPagos
                        SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
                    Next

                    For Each i In ListaCompAnt
                        SumaPagos += i.importe.GetValueOrDefault
                    Next
                Else
                    For Each i In ListaPagos
                        SumaPagos += i.documentoCaja.montoUsd.GetValueOrDefault
                    Next

                    For Each i In ListaCompAnt
                        SumaPagos += i.importe.GetValueOrDefault
                        'FALTA CREAR CAMPO DOLARES EN EL ANITCIPO {CREAR}
                    Next
                End If

                If SumaPagos = Saldo Then
                    ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                Else
                    'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                    ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                End If
                ndocumento.idDocumento = compraCabecera.idDocumento
                'ndocumento.documentocompra.documentocompradetalle = ListaDetalleCompra
                ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
                ndocumento.ListaDetalleAnticiposCompra = ListaCompAnt
                cajaSA.PagoDocCompras(ndocumento)
                MessageBox.Show("Pago realizado con éxito", "Hecho", MessageBoxButtons.OK)
                Close()
            ElseIf ant.Count > 0 Then

                ndocumento.documentoventaAbarrotes = New documentoventaAbarrotes
                Dim SumaPagos As Decimal = 0

                Dim ListaCompAnt = ListaPagosAntComp(ant, envio)

                If compraCabecera.monedaDoc = "1" Then
                    For Each i In ListaCompAnt
                        SumaPagos += i.importe.GetValueOrDefault
                    Next
                Else
                    For Each i In ListaCompAnt
                        SumaPagos += i.importe.GetValueOrDefault
                        'FALTA CREAR CAMPO DOLARES EN EL ANITCIPO {CREAR}
                    Next
                End If

                If SumaPagos = Saldo Then
                    ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
                Else
                    'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                    ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If

                ndocumento.idDocumento = compraCabecera.idDocumento
                ndocumento.ListaDetalleAnticiposCompra = ListaCompAnt
                cajaSA.PagoCompensacionCompras(ndocumento)
                MessageBox.Show("Pago realizado con éxito", "Hecho", MessageBoxButtons.OK)
                Close()
            Else
                Throw New Exception("Debe realizar el pago del comprobante")
            End If
        Catch ex As Exception
            GetDataPays()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then

        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        cboAnio_SelectedValueChanged(sender, e)
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            If Not IsNothing(cboMesCompra.SelectedValue) Then
                'txtPeriodo.Value = GetPeriodoConvertirToDate(cboMesCompra.SelectedValue & "/" & cboAnio.Text)
                If TxtDia.Text.Trim.Length > 0 Then
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                Else
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                    TxtDia.Clear()
                End If
                TxtDia_TextChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub GridPagos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridPagos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        Dim cc As GridCurrentCell = GridPagos.TableControl.CurrentCell
        cc.ConfirmChanges()

        Try
            Select Case ColIndex
                Case 2

                    Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(cc.RowIndex, cc.ColIndex)
                    If style3.TableCellIdentity.Table.CurrentRecord Is Nothing Then Exit Sub
                    Dim r = style3.TableCellIdentity.Table.CurrentRecord
                    'If r.GetValue("tipo") = "VNCA" Or r.GetValue("tipo") = "VRC" Then
                    Dim saldocaja = CDec(r.GetValue("saldo"))
                    Dim text As String = cc.Renderer.ControlText
                        If text.Trim.Length > 0 Then
                            Dim value As Decimal = Convert.ToDecimal(text)
                            cc.Renderer.ControlValue = value
                        If value > saldocaja Then
                            cc.Renderer.ControlValue = 0
                            cc.ConfirmChanges()
                            cc.EndEdit()
                            DigitalPagos.Value = 0
                            Exit Sub
                        End If
                    End If
                    'End If

                    Dim pagos As Decimal = SumaPagos()
                    DigitalPagos.Text = pagos
                    DigitalPagos.Value = pagos

                    DigitalSaldo.Text = Saldo - pagos
                    DigitalSaldo.Value = Saldo - pagos

                    If pagos > CDec(Saldo) Then
                        MessageBox.Show("El pago no debe exceder el valor permitido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        GridPagos.Table.CurrentRecord.SetValue("importe", 0)
                        Dim pagos2 As Decimal = SumaPagos()
                        DigitalPagos.Text = pagos2
                        DigitalPagos.Value = pagos2

                        DigitalSaldo.Text = Saldo - pagos2
                        DigitalSaldo.Value = Saldo - pagos2
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Sub GridPagos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPagos.TableControlCellClick
        Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        Dim estadoSA As New EstadosFinancierosSA
        If style3.Enabled Then
            If style3.TableCellIdentity.Column Is Nothing Then Exit Sub
            If style3.TableCellIdentity.Column.Name = "importe" Then
                '       e.Inner.Cancel = True
                'Dim disponible As Decimal = Decimal.Parse(style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("disponible").ToString()) 'Decimal.Parse(r.GetValue("disponible"))
                'Dim value As String = style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                'Dim cantidad = InputBox("Rango disponible de [0 - " & disponible & "]", "Cantidad", 0)

                Dim Estado = estadoSA.GetUbicar_estadosFinancierosPorID(Integer.Parse(style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("identidad").ToString()))

                Dim f As New frmCajaEntranjera(Estado, compraCabecera)
                f.txtCuenta.Text = Estado.descripcion
                f.txtCuenta.Tag = Estado.idestado
                f.txtDeuda.DoubleValue = Decimal.Parse(DigitalGauge2.Value) ' txtSaldoPorPagar.DecimalValue

                If style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda") = "1" Then
                    f.cboPago.Text = "NACIONAL"
                Else
                    f.cboPago.Text = "EXTRANJERO"
                End If

                'If lblMonedaCobro.Text = "NACIONAL" Then

                'Else
                '    f.cboPago.Text = "EXTRANJERO"
                'End If
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If f.Tag IsNot Nothing Then
                    Dim pagos As Decimal = 0

                    Dim listaPagosDetail = CType(f.Tag, List(Of movimientocajaextranjera))
                    Dim cajadoc As New documentoCaja With {
                        .idDocumento = 1,
                        .movimientocajaextranjera = listaPagosDetail
                        }

                    Select Case compraCabecera.monedaDoc
                        Case "1"
                            If style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda") = "1" Then
                                style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("importe", listaPagosDetail.Sum(Function(o) o.importe).GetValueOrDefault())
                                style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("abonadoME", 0)
                            Else
                                Dim soles = listaPagosDetail.FirstOrDefault().Importe2.GetValueOrDefault
                                Dim extranjera = listaPagosDetail.Sum(Function(o) o.importe).GetValueOrDefault()

                                style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("importe", soles)
                                style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("abonadoME", extranjera)
                            End If
                        Case "2"
                            If style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda") = "1" Then
                                Dim soles = listaPagosDetail.FirstOrDefault().importe.GetValueOrDefault
                                Dim extranjera = listaPagosDetail.Sum(Function(o) o.Desembolso).GetValueOrDefault()

                                'style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("importe", listaPagosDetail.Sum(Function(o) o.importe).GetValueOrDefault())
                                style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("importe", extranjera) 'listaPagosDetail.Sum(Function(o) o.importe).GetValueOrDefault())
                                style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("abonadoME", soles)
                            Else
                                Dim soles = listaPagosDetail.FirstOrDefault().Importe2.GetValueOrDefault
                                Dim extranjera = listaPagosDetail.Sum(Function(o) o.importe).GetValueOrDefault()

                                style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("importe", soles)
                                style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("abonadoME", extranjera)
                            End If
                    End Select


                    style3.TableCellIdentity.DisplayElement.GetRecord().SetValue("caja", cajadoc)


                    'Realizar movimiento
                    ' Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(cc.RowIndex, cc.ColIndex)
                    If style3.TableCellIdentity.Table.CurrentRecord Is Nothing Then Exit Sub
                    Dim r = style3.TableCellIdentity.Table.CurrentRecord
                    'If r.GetValue("tipo") = "VNCA" Or r.GetValue("tipo") = "VRC" Then

                    Select Case compraCabecera.monedaDoc
                        Case "1"

                            If style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda") = "1" Then
                                Dim saldocaja = CDec(r.GetValue("saldo"))
                                Dim text = CDec(r.GetValue("importe")) 'cc.Renderer.ControlText

                                Dim value As Decimal = Convert.ToDecimal(text)
                                'cc.Renderer.ControlValue = value
                                If value > saldocaja Then
                                    r.SetValue("importe", 0)
                                    r.SetValue("abonadoME", 0)
                                    DigitalPagos.Value = 0
                                    Exit Sub
                                End If


                                pagos = SumaPagos()
                                DigitalPagos.Text = pagos
                                DigitalPagos.Value = pagos

                                DigitalSaldo.Text = Saldo - pagos
                                DigitalSaldo.Value = Saldo - pagos

                            Else 'MONEDA EXTRANJERA
                                '-----------------------------------------------------------------------
                                Dim saldocaja = CDec(r.GetValue("saldo"))
                                Dim text = CDec(r.GetValue("abonadoME")) 'cc.Renderer.ControlText

                                Dim value As Decimal = Convert.ToDecimal(text)
                                'cc.Renderer.ControlValue = value
                                If value > saldocaja Then
                                    r.SetValue("importe", 0)
                                    r.SetValue("abonadoME", 0)
                                    DigitalPagos.Value = 0
                                    Exit Sub
                                End If


                                pagos = SumaPagosME()
                                DigitalPagos.Text = pagos
                                DigitalPagos.Value = pagos

                                DigitalSaldo.Text = Saldo - pagos
                                DigitalSaldo.Value = Saldo - pagos

                            End If


                        Case "2"

                            If style3.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda") = "1" Then
                                Dim saldocaja = CDec(r.GetValue("saldo"))
                                Dim text = CDec(r.GetValue("abonadoME")) 'cc.Renderer.ControlText

                                Dim value As Decimal = Convert.ToDecimal(text)
                                'cc.Renderer.ControlValue = value
                                If CDec(r.GetValue("importe")) > saldocaja Then
                                    r.SetValue("importe", 0)
                                    r.SetValue("abonadoME", 0)
                                    DigitalPagos.Value = 0
                                    Exit Sub
                                End If


                                pagos = SumaPagosME()
                                DigitalPagos.Text = pagos
                                DigitalPagos.Value = pagos

                                DigitalSaldo.Text = Saldo - pagos
                                DigitalSaldo.Value = Saldo - pagos

                            Else 'MONEDA EXTRANJERA
                                '-----------------------------------------------------------------------
                                Dim saldocaja = CDec(r.GetValue("saldo"))
                                Dim text = CDec(r.GetValue("abonadoME")) 'cc.Renderer.ControlText

                                Dim value As Decimal = Convert.ToDecimal(text)
                                'cc.Renderer.ControlValue = value
                                If value > saldocaja Then
                                    r.SetValue("importe", 0)
                                    r.SetValue("abonadoME", 0)
                                    DigitalPagos.Value = 0
                                    Exit Sub
                                End If


                                pagos = SumaPagosME()
                                DigitalPagos.Text = pagos
                                DigitalPagos.Value = pagos

                                DigitalSaldo.Text = Saldo - pagos
                                DigitalSaldo.Value = Saldo - pagos

                            End If

                    End Select
                    If pagos > CDec(Saldo) Then
                        MessageBox.Show("El pago no debe exceder el valor permitido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        GridPagos.Table.CurrentRecord.SetValue("importe", 0)
                        GridPagos.Table.CurrentRecord.SetValue("abonadoME", 0)
                        Dim pagos2 As Decimal = SumaPagos()
                        DigitalPagos.Text = pagos2
                        DigitalPagos.Value = pagos2

                        DigitalSaldo.Text = Saldo - pagos2
                        DigitalSaldo.Value = Saldo - pagos2
                        Exit Sub
                    End If


                End If
            End If

            End If
    End Sub

    Private Sub GridStatus_TableControlCellClick(sender As Object, e As Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridPagosResumen.TableControlCellClick
        Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style3.Enabled Then
            If style3.TableCellIdentity.Column.Name = "iddoc" Then
                '       e.Inner.Cancel = True

            End If

        End If
    End Sub

    Private Sub FormPagarDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridPagosResumen.TableDescriptor.Columns("iddoc").Appearance.AnyRecordFieldCell.CellType = "LinkLabelCell"

        GridPagos.TableModel.CellModels.Clear()
        GridPagos.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(GridPagos.TableModel))
        GridPagos.TableDescriptor.Columns("importe").Appearance.AnyRecordFieldCell.CellType = "LinkLabelCell"
    End Sub
#End Region

#Region "Class LinkLabel"
    Public Class LinkLabelCellModel
        Inherits GridStaticCellModel

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Sub New(ByVal grid As GridModel)
            MyBase.New(grid)
        End Sub

        Public Overrides Function CreateRenderer(ByVal control As GridControlBase) As GridCellRendererBase
            Return New LinkLabelCellRenderer(control, Me)
        End Function
    End Class

    Public Class LinkLabelCellRenderer
        Inherits GridStaticCellRenderer

        Private _isMouseDown As Boolean
        Private _drawHotLink As Boolean
        Private _hotColor As Color
        Private _visitedColor As Color
        Private _EXEname As String

        Public Sub New(ByVal grid As GridControlBase, ByVal cellModel As GridCellModelBase)
            MyBase.New(grid, cellModel)
            _isMouseDown = False
            _drawHotLink = False
            _hotColor = Color.Red
            _visitedColor = Color.Purple
            _EXEname = "iexplore.exe"
        End Sub

        Public Property VisitedLinkColor As Color
            Get
                Return _visitedColor
            End Get
            Set(ByVal value As Color)
                _visitedColor = value
            End Set
        End Property

        Public Property ActiveLinkColor As Color
            Get
                Return _hotColor
            End Get
            Set(ByVal value As Color)
                _hotColor = value
            End Set
        End Property

        Public Property EXEname As String
            Get
                Return _EXEname
            End Get
            Set(ByVal value As String)
                _EXEname = value
            End Set
        End Property

        Private Sub DrawLink(ByVal useHotColor As Boolean, ByVal rowIndex As Integer, ByVal colIndex As Integer)
            If useHotColor Then _drawHotLink = True
            Me.Grid.RefreshRange(GridRangeInfo.Cell(rowIndex, colIndex), GridRangeOptions.None)
            _drawHotLink = False
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(rowIndex, colIndex, e)
            DrawLink(True, rowIndex, colIndex)
            _isMouseDown = True
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(rowIndex, colIndex, e)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(New Point(e.X, e.Y), row, col)

            If row = rowIndex AndAlso col = colIndex Then
                Dim style As GridStyleInfo = Me.Grid.Model(row, col)
                style.TextColor = VisitedLinkColor
            End If

            DrawLink(False, rowIndex, colIndex)
            _isMouseDown = False
        End Sub

        Protected Overrides Sub OnCancelMode(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnCancelMode(rowIndex, colIndex)
            _isMouseDown = False
            _drawHotLink = False
        End Sub

        Protected Overrides Function OnGetCursor(ByVal rowIndex As Integer, ByVal colIndex As Integer) As System.Windows.Forms.Cursor
            Dim pt As Point = Me.Grid.PointToClient(Cursor.Position)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(pt, row, col)
            Return If((row = rowIndex AndAlso col = colIndex), Cursors.Hand, If((Me._isMouseDown), Cursors.No, MyBase.OnGetCursor(rowIndex, colIndex)))
        End Function

        Protected Overrides Function OnHitTest(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As MouseEventArgs, ByVal controller As IMouseController) As Integer
            If controller IsNot Nothing AndAlso controller.Name = "OleDataSource" Then Return 0
            Return 1
        End Function

        Protected Overrides Sub OnDraw(ByVal g As System.Drawing.Graphics, ByVal clientRectangle As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal style As Syncfusion.Windows.Forms.Grid.GridStyleInfo)
            style.Font.Underline = True

            If _drawHotLink Then
                style.TextColor = ActiveLinkColor
            End If

            MyBase.OnDraw(g, clientRectangle, rowIndex, colIndex, style)
        End Sub

        Protected Overrides Sub OnMouseHoverEnter(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnMouseHoverEnter(rowIndex, colIndex)
            DrawLink(True, rowIndex, colIndex)
        End Sub

        Protected Overrides Sub OnMouseHoverLeave(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.EventArgs)
            MyBase.OnMouseHoverLeave(rowIndex, colIndex, e)
            DrawLink(False, rowIndex, colIndex)
        End Sub
    End Class

    Private Function VerificarItemDuplicadoV2(idDoc As Integer, tipo As String) As Boolean
        VerificarItemDuplicadoV2 = False



        For Each i In GridPagos.Table.Records
            If idDoc = CDec(i.GetValue("identidad")) Then
                If tipo = i.GetValue("tipo") Then
                    '   CalculosByCantidadExistente(cantidad, i)
                    VerificarItemDuplicadoV2 = True
                    Exit For
                End If
            End If
        Next
    End Function

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            If txtCliente.Tag IsNot Nothing Then
                If txtCliente.Text.Trim.Length > 0 Then
                    Dim f As New FormAntReclamacionesPendientes(New entidad With {
                                                                .idEntidad = Val(txtCliente.Tag),
                                                                .nombreCompleto = txtCliente.Text,
                                                                .nrodoc = txtruc.Text
                                                                }, "COMPRAS")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    pagoAnticipo = New documentoAnticipo
                    If f.Tag IsNot Nothing Then
                        Dim anticipoSA As New documentoAnticipoSA
                        Dim codigoDoc = CType(f.Tag, Decimal)
                        pagoAnticipo = anticipoSA.GetANTReclamacionesXDocumentoCompra(New documentocompra With {.idDocumento = codigoDoc})

                        'TextPagoAnticipoDisponible.DecimalValue = pagoAnticipo.SaldoReclamacion.GetValueOrDefault
                        'TextValoranticipo.MaxValue = pagoAnticipo.SaldoReclamacion.GetValueOrDefault
                        'TextValoranticipo.MinValue = 0

                        Dim existeEnCanasta = VerificarItemDuplicadoV2(pagoAnticipo.idDocumento, pagoAnticipo.tipoOperacion)
                        If Not existeEnCanasta Then
                            Me.GridPagos.Table.AddNewRecord.SetCurrent()
                            Me.GridPagos.Table.AddNewRecord.BeginEdit()
                            Me.GridPagos.Table.CurrentRecord.SetValue("idforma", 1)

                            Me.GridPagos.Table.CurrentRecord.SetValue("identidad", pagoAnticipo.idDocumento)

                            Me.GridPagos.Table.CurrentRecord.SetValue("codigocontable", 1)
                            Me.GridPagos.Table.CurrentRecord.SetValue("importe", 0) 'pagoAnticipo.SaldoReclamacion.GetValueOrDefault)
                            Me.GridPagos.Table.CurrentRecord.SetValue("saldo", pagoAnticipo.SaldoReclamacion.GetValueOrDefault)
                            Me.GridPagos.Table.CurrentRecord.SetValue("nrooperacion", "")
                            Me.GridPagos.Table.CurrentRecord.SetValue("tipo", pagoAnticipo.tipoOperacion)

                            If pagoAnticipo.tipoOperacion = "VNCA" Then
                                Me.GridPagos.Table.CurrentRecord.SetValue("entidad", "COMPENSACION ANTICIPO")
                                Me.GridPagos.Table.CurrentRecord.SetValue("cuenta", "COMPENSACION ANTICIPO")
                            ElseIf pagoAnticipo.tipoOperacion = "VRC" Then
                                Me.GridPagos.Table.CurrentRecord.SetValue("entidad", "COMPENSACION RECLAMACION")
                                Me.GridPagos.Table.CurrentRecord.SetValue("cuenta", "COMPENSACION RECLAMACION")
                            End If

                            Me.GridPagos.Table.AddNewRecord.EndEdit()
                        Else

                        End If
                    End If

                Else
                    MessageBox.Show("Debe identificar un cliente válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



#End Region

End Class