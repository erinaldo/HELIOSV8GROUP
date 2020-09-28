Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmNotaDebitoVenta
    Inherits frmMaster
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property tipoCambio() As Decimal
    Public Property IdCompraOrigen() As Integer
    Public Property ListaAsientonTransito As New List(Of asiento)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfiguracionInicio()
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



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

#Region "Metodos"



    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento
        nMovimiento.cuenta = "1212"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario

        Return nMovimiento
    End Function

    Public Function Ad_Cli_Excedente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento
        nMovimiento.cuenta = "46"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario

        Return nMovimiento
    End Function

    Sub AsientoNotaCreditoNormal(consultaAsiento As List(Of documentoventaAbarrotesDet))
        Dim SumTotalMN As Decimal = 0
        Dim SumTotalME As Decimal = 0

        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtCliente.Tag
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_NotaDebito
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Proveedor(SumTotalMN, SumTotalME))
        For Each i In consultaAsiento
            SumTotalMN += CDec(i.importeMN)
            SumTotalME += CDec(i.importeME)
            nAsiento.movimiento.Add(AS_IGV(i.montoIgv, i.montoIgvUS))
            nAsiento.movimiento.Add(AS_Default(i.montokardex, i.montokardexUS, i.tipoExistencia, i.nombreItem))
        Next

        nAsiento.importeMN = SumTotalMN
        nAsiento.importeME = SumTotalME
    End Sub

    Sub AsientoNotaCreditoExcedente(consultaAsiento As List(Of documentoventaAbarrotesDet))
        Dim SumTotalMN As Decimal = 0
        Dim SumTotalME As Decimal = 0

        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtCliente.Tag
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_NotaDebito

        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)


        For Each i In consultaAsiento
            SumTotalMN += CDec(i.importeMN)
            SumTotalME += CDec(i.importeME)
            'Select Case i.destino
            '    Case "1"
            '        MV_Item_Transito(i.nombreItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
            '    Case Else
            MV_Item_Transito(i.nombreItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)

            'End Select
            nAsiento.movimiento.Add(AS_Default(i.montokardex, i.montokardexUS, i.tipoExistencia, i.nombreItem))
            nAsiento.movimiento.Add(AS_IGV(i.montoIgv, i.montoIgvUS))
        Next
        nAsiento.movimiento.Add(Ad_Cli_Excedente(SumTotalMN, SumTotalME))
        nAsiento.importeMN = SumTotalMN
        nAsiento.importeME = SumTotalME
    End Sub


    Public Function AS_Default(cMonto As Decimal, cMontoUS As Decimal, tipoex As String, DescItem As String) As movimiento
        Dim nMovimiento As New movimiento
        Dim cuentaMascaraSA As New cuentaMascaraSA
        nMovimiento = New movimiento
        nMovimiento.cuenta = "75"
        nMovimiento.descripcion = DescItem
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.periodo = lblPerido.Text
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtCliente.Tag)
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function
    Dim cuentaMascara As New cuentaMascara
    Public Sub MV_Item_Transito(cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        nMovimiento.cuenta = "20111"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 69
        nMovimiento = New movimiento
        nMovimiento.cuenta = "69112"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Function ComprobanteCaja(listaCaja As List(Of documentoventaAbarrotesDet)) As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento

        Dim sumMN As Decimal = 0
        Dim sumME As Decimal = 0


        ef = efSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
        nDocumentoCaja = New documento()
        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9912" ' INGRESO DE DINERO A CAJA
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja = New documentoCaja
        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
        objCaja.IdProveedor = txtCliente.Tag
        objCaja.codigoLibro = "9912"
        objCaja.codigoProveedor = CInt(txtCliente.Tag)
        objCaja.TipoDocumentoPago = "109"
        objCaja.tipoDocPago = "109"
        objCaja.periodo = lblPerido.Text
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = "1" ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")

        objCaja.tipoCambio = CDec(txtTipoCambio.Text)


        objCaja.glosa = txtGlosa.Text.Trim
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        '   For Each i As DataGridViewRow In dgvNuevoDoc.Rows
        For Each i In listaCaja

            sumMN += CDec(i.importeMN)
            sumME += CDec(i.importeME)

            objCajaDetalle = New documentoCajaDetalle
            objCajaDetalle.idDocumento = 0
            objCajaDetalle.fecha = txtFecha.Value
            objCajaDetalle.idItem = i.idItem
            objCajaDetalle.DetalleItem = i.DetalleItem
            objCajaDetalle.montoSoles = i.ImporteDevolucionmn
            objCajaDetalle.montoUsd = i.ImporteDevolucionme
            objCajaDetalle.entregado = "SI"
            objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
            objCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaDetalle.Add(objCajaDetalle)
        Next

        nDocumentoCaja.documentoCaja.montoSoles = sumMN
        nDocumentoCaja.documentoCaja.montoUsd = sumME
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE

        asiento = New asiento
        With asiento
            .periodo = lblPerido.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idEntidad = txtCliente.Tag
            .nombreEntidad = txtCliente.Text
            .tipoEntidad = "CL"
            .fechaProceso = txtFecha.Value
            .codigoLibro = "14"
            .tipo = "D"
            .tipoAsiento = "AS-NTC"
            .importeMN = sumMN ' TotalesXcanbeceras.importeDevmn
            .importeME = sumME 'TotalesXcanbeceras.importeDevme
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        nMovimiento.cuenta = "46"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.importeDevmn
        nMovimiento.montoUSD = sumME 'TotalesXcanbeceras.importeDevme
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = "H"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.importeDevmn
        nMovimiento.montoUSD = sumME ' TotalesXcanbeceras.importeDevme
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asiento)

        Return nDocumentoCaja
    End Function

    Function ComprobanteCajaSaldo(listaCaja As List(Of documentoventaAbarrotesDet)) As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento

        Dim sumMN As Decimal = 0
        Dim sumME As Decimal = 0


        ef = efSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
        nDocumentoCaja = New documento()
        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9908" ' INGRESO DE DINERO A CAJA
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja = New documentoCaja
        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.IdProveedor = txtCliente.Tag
        objCaja.codigoLibro = "9908"
        objCaja.codigoProveedor = CInt(txtCliente.Tag)
        objCaja.TipoDocumentoPago = "109"
        objCaja.tipoDocPago = "109"
        objCaja.periodo = lblPerido.Text
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = "1" ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = CDec(txtTipoCambio.Text)


        objCaja.glosa = txtGlosa.Text.Trim
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        '   For Each i As DataGridViewRow In dgvNuevoDoc.Rows
        For Each i In listaCaja
            sumMN += CDec(i.saldoVentaMN)
            sumME += CDec(i.saldoVentaME)
            objCajaDetalle = New documentoCajaDetalle
            objCajaDetalle.idDocumento = 0
            objCajaDetalle.fecha = txtFecha.Value
            objCajaDetalle.idItem = i.idItem
            objCajaDetalle.DetalleItem = i.DetalleItem
            objCajaDetalle.montoSoles = i.saldoVentaMN
            objCajaDetalle.montoUsd = i.saldoVentaME
            objCajaDetalle.entregado = "SI"
            objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
            objCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaDetalle.Add(objCajaDetalle)
        Next
        nDocumentoCaja.documentoCaja.montoSoles = sumMN
        nDocumentoCaja.documentoCaja.montoUsd = sumME

        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE

        asiento = New asiento
        With asiento
            .periodo = lblPerido.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idEntidad = txtCliente.Tag
            .nombreEntidad = txtCliente.Text
            .tipoEntidad = "CL"
            .fechaProceso = txtFecha.Value
            .codigoLibro = "14"
            .tipo = "D"
            .tipoAsiento = "AS-NTC"
            .importeMN = sumMN ' TotalesXcanbeceras.SaldoVentaMN
            .importeME = sumME ' TotalesXcanbeceras.SaldoVentaME
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1212"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.SaldoVentaMN
        nMovimiento.montoUSD = sumME ' TotalesXcanbeceras.SaldoVentaME
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "46"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = "H"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.SaldoVentaMN
        nMovimiento.montoUSD = sumME 'TotalesXcanbeceras.SaldoVentaME
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asiento)

        Return nDocumentoCaja
    End Function

    Sub GuiaRemision(objDocumentoCompra As documento, Lista As List(Of documentoventaAbarrotesDet))
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = CInt(txtCliente.Tag)
            .monedaDoc = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)
            .tipoCambio = CDec(txtTipoCambio.Text)
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As documentoventaAbarrotesDet In Lista

            If r.tipoExistencia <> "GS" Then
                'If r.GetValue("almacen") <> idAlmacenVirtual Then
                documentoguiaDetalle = New documentoguiaDetalle
                If txtSerieGuia.Text.Trim.Length > 0 Then
                    'objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                    objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                Else
                    Throw New Exception("Ingrese número de serie de la guía!")
                    'MessageBoxAdv.Show("Ingrese número de serie de la guía!")
                    'Exit Sub
                End If
                If txtNumeroGuia.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                Else
                    Throw New Exception("Ingrese número de la guía!")
                    'MessageBoxAdv.Show("Ingrese número de la guía!")
                    'Exit Sub
                End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.idItem
                documentoguiaDetalle.descripcionItem = r.nombreItem
                documentoguiaDetalle.destino = r.destino
                documentoguiaDetalle.unidadMedida = Nothing  'r.GetValue("um")
                documentoguiaDetalle.cantidad = r.monto1
                documentoguiaDetalle.precioUnitario = r.precioUnitario
                documentoguiaDetalle.precioUnitarioUS = r.precioUnitarioUS
                documentoguiaDetalle.importeMN = r.importeMN
                documentoguiaDetalle.importeME = r.importeME
                documentoguiaDetalle.almacenRef = r.idAlmacenOrigen
                documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub Grabar()
        Dim CompraSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim nDocumentoExce As New documento
        Dim nDocumentoCompra As New documentoventaAbarrotes()
        Dim objDocumentoCompraDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim DocCaja As New documento

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim almacenSA As New almacenSA
        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim ListaTotales As New List(Of totalesAlmacen)
        ''''''''''' LIMPIANDO VARIABLES---------------------

        ListaAsientonTransito = New List(Of asiento)

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "08"
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .idEntidad = Val(txtCliente.Tag)
            .entidad = txtCliente.Text
            .tipoEntidad = TIPO_ENTIDAD.CLIENTE
            .nrodocEntidad = txtRuc.Text
            .tipoOperacion = "01"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = IdCompraOrigen
            .codigoLibro = "14"
            .tipoDocumento = "08"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaPeriodo = lblPerido.Text
            .serie = txtSerie.Text.Trim
            .numeroDocNormal = txtNumero.Text.Trim
            .idCliente = CInt(txtCliente.Tag)
            .nombrePedido = txtCliente.Text
            .NombreEntidad = txtCliente.Text

            'If txtMon.Text = "NACIONAL" Then
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            ' .moneda = "1"
            'ElseIf txtMon.Text = "EXTRANJERO" Then
            '    .moneda = "2"
            'End If


            .tasaIgv = CDec(txtIva.Text)    ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = CDec(txtTipoCambio.Text)

            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = TotalesXcanbeceras.base1
            .bi02 = TotalesXcanbeceras.base2

            .igv01 = TotalesXcanbeceras.MontoIgv1
            .igv02 = TotalesXcanbeceras.MontoIgv2


            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = TotalesXcanbeceras.base1me
            .bi02us = TotalesXcanbeceras.base2me

            .igv01us = TotalesXcanbeceras.MontoIgv1me
            .igv02us = TotalesXcanbeceras.MontoIgv2me

            '****************************************************************************************************************
            .ImporteNacional = TotalesXcanbeceras.TotalMN
            .ImporteExtranjero = TotalesXcanbeceras.TotalME
            .tipoVenta = TIPO_COMPRA.NOTA_DEBITO

            .glosa = txtGlosa.Text.Trim
            .tipoVenta = TIPO_COMPRA.NOTA_DEBITO

            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01" 'strTipoNota
            ' .aprobado = "N"
            'If cboDevolucion.Visible = True Then
            '    If cboDevolucion.Text = "PAGADO" Then
            '        .EstadoPagoDevolucion = TIPO_VENTA.PAGO.COBRADO
            '    Else
            '        .EstadoPagoDevolucion = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            '    End If
            'Else
            '    .EstadoPagoDevolucion = Nothing
            'End If

            .ImporteDevMN = TotalesXcanbeceras.importeDevmn
            .ImporteDevME = TotalesXcanbeceras.importeDevme
            .SaldoVentaMN = TotalesXcanbeceras.SaldoVentaMN
            .SaldoVentaME = TotalesXcanbeceras.SaldoVentaME
        End With

        ndocumento.documentoventaAbarrotes = nDocumentoCompra


        For Each r As Record In dgvMov.Table.Records

            objDocumentoCompraDet = New documentoventaAbarrotesDet
            objDocumentoCompraDet.saldoVentaMN = r.GetValue("importeMN")
            objDocumentoCompraDet.saldoVentaME = r.GetValue("importeME")
            Select Case r.GetValue("estadoPago")
                Case "Pagado"
                    objDocumentoCompraDet.ImporteDevolucionmn = r.GetValue("ValDevmn")
                    objDocumentoCompraDet.ImporteDevolucionme = r.GetValue("ValDevme")

                Case Else
                    objDocumentoCompraDet.ImporteDevolucionmn = r.GetValue("ValDevmn")
                    objDocumentoCompraDet.ImporteDevolucionme = r.GetValue("ValDevme")
            End Select

            If objDocumentoCompraDet.ImporteDevolucionmn > 0 Then
                objDocumentoCompraDet.TieneExcedente = True
            Else
                objDocumentoCompraDet.TieneExcedente = False
            End If

            objDocumentoCompraDet.secuencia = r.GetValue("sec")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            'objDocumentoCompraDet.TipoDoc = "07"
            'objDocumentoCompraDet.Serie = txtSerie.Text
            'objDocumentoCompraDet.NumDoc = txtNumero.Text
            Select Case r.GetValue("cboMov")
                Case "9921" '"DISMINUIR IMPORTE"
                    If Not CDec(r.GetValue("vcmn")) > 0 Then
                        lblEstado.Text = "Ingrese un Valor de compra mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        'Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(8)
                        'Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                    objDocumentoCompraDet.TipoOperacion = "9921"

                Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                    objDocumentoCompraDet.TipoOperacion = "9917"
                Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                    objDocumentoCompraDet.TipoOperacion = "9918"
                    objDocumentoCompraDet.tipoVenta = "9918"
                    'objDocumentoCompraDet.FlagBonif = i.Cells(40).Value()
            End Select
            objDocumentoCompraDet.destino = r.GetValue("grav")
            objDocumentoCompraDet.idItem = r.GetValue("idItem")
            objDocumentoCompraDet.nombreItem = CStr(r.GetValue("item"))
            objDocumentoCompraDet.DetalleItem = CStr(r.GetValue("item"))
            objDocumentoCompraDet.tipoExistencia = CStr(r.GetValue("tipoEx"))
            objDocumentoCompraDet.monto1 = CDec(r.GetValue("canDev"))
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoCompraDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoCompraDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoCompraDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("ivamn"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0 'CDec(i.Cells(17).Value())
            objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("ivame"))
            objDocumentoCompraDet.otrosTributosUS = 0 ' CDec(i.Cells(19).Value())

            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.idAlmacenOrigen = CInt(r.GetValue("almacenRef"))

            objDocumentoCompraDet.preEvento = r.GetValue("estadoPago")  '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            '        objDocumentoCompraDet.bonificacion = Nothing


            objDocumentoCompraDet.idPadreDTVenta = CInt(r.GetValue("sec"))
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.fechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            ' objDocumentoCompraDet.BonificacionMN =

            objDocumentoCompraDet.NumDoc = txtNumeroGuia.Text
            objDocumentoCompraDet.Serie = txtSerieGuia.Text
            objDocumentoCompraDet.TipoDoc = "99"
            objDocumentoCompraDet.estadoPago = TIPO_VENTA.PAGO.COBRADO ' r.GetValue("estadoPago")
            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        '---------------------------------------------------------------------------------
        ndocumento.documentoventaAbarrotes.tipoOperacion = "01"



        AsientoNotaCreditoNormal(ListaDetalle)
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        Dim xcod As Integer = CompraSA.SaveVentaNotaDebito(ndocumento)
        lblEstado.Text = "nota de débito registrada!"
        Dispose()
    End Sub

    Public Class TotalesXcanbecera
        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal
        Public Property IgvMN() As Decimal
        Public Property IgvME() As Decimal
        Public Property TotalMN() As Decimal
        Public Property TotalME() As Decimal
        Public Property base1() As Decimal
        Public Property base1me() As Decimal
        Public Property base2() As Decimal
        Public Property base2me() As Decimal
        Public Property MontoIgv1() As Decimal
        Public Property MontoIgv1me() As Decimal
        Public Property MontoIgv2() As Decimal
        Public Property MontoIgv2me() As Decimal

        Public Property importeDevmn() As Decimal
        Public Property importeDevme() As Decimal

        Public Property SaldoVentaMN() As Decimal
        Public Property SaldoVentaME() As Decimal

        Public Sub New()

        End Sub


    End Class

    Sub TotalTalesXcolumna()
        'Dim totalDevolucionMN As Decimal = 0
        'Dim totalDevolucionME As Decimal = 0
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        Dim dvmn As Decimal = 0
        Dim dvme As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoME As Decimal = 0
        For Each r As Record In dgvMov.Table.Records
            'devolucion de dinero
            'totalDevolucionMN += CDec(r.GetValue("ValDevmn"))
            'totalDevolucionME += CDec(r.GetValue("ValDevme"))
            saldoMN += CDec(r.GetValue("importeMN"))
            saldoME += CDec(r.GetValue("importeME"))

            '      If r.GetValue("estadoPago") = "Pagado" Then
            dvmn += CDec(r.GetValue("ValDevmn"))
            dvme += CDec(r.GetValue("ValDevme"))
            '   End If

            'If r.GetValue("valBonif") = "S" Then
            '    totalDesc += CDec(r.GetValue("igvmn"))
            '    totalDescme += CDec(r.GetValue("igvme"))
            'Else
            totalVC += CDec(r.GetValue("vcmn"))
            totalVCme += CDec(r.GetValue("vcme"))

            totalIVA += CDec(r.GetValue("ivamn"))
            totalIVAme += CDec(r.GetValue("ivame"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))
            'End If

            Select Case r.GetValue("grav")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    igv1 += CDec(r.GetValue("ivamn"))
                    igv1me += CDec(r.GetValue("ivame"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    igv2 += CDec(r.GetValue("ivamn"))
                    igv2me += CDec(r.GetValue("ivame"))
            End Select


        Next
        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        TotalesXcanbeceras.importeDevmn = dvmn
        TotalesXcanbeceras.importeDevme = dvme
        TotalesXcanbeceras.SaldoVentaMN = saldoMN
        TotalesXcanbeceras.SaldoVentaME = saldoME

        '****************************************************
        txtSaldoPendiente.DecimalValue = saldoMN
        txtBonifica.DecimalValue = dvmn
        txtTotalBase.DecimalValue = totalVC
        txtTotalIva.DecimalValue = totalIVA
        txtTotalPagar.DecimalValue = total

        'If TotalesXcanbeceras.importeDevmn > 0 Then
        '    lbldev.Visible = True
        '    cboDevolucion.Visible = True
        'Else
        '    lbldev.Visible = False
        '    cboDevolucion.Visible = False
        'End If

    End Sub

    Public Sub UbicarDetalle(intIddocumento As Integer)
        Dim detalleSA As New documentoVentaAbarrotesDetSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentoventaAbarrotesDet
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim entidadSA As New entidadSA
        Dim dt As New DataTable

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Dim cCantidadNC As Decimal = 0
        Dim cCantidadDB As Decimal = 0
        Dim cTotalCantidad As Decimal = 0
        Try
            With compraSA.GetUbicar_documentoventaAbarrotesPorID(intIddocumento)
                IdCompraOrigen = .idDocumento
                txtMon.Text = .moneda
                If .moneda = "1" Then
                    txtdesmoneda.Text = "NACIONAL"
                ElseIf .moneda = "2" Then
                    txtdesmoneda.Text = "EXTRANJERO"
                End If

                txtTipoCambio.Text = .tipoCambio
                txtTipoCambio.ReadOnly = True
                txtIva.Text = .tasaIgv
                txtImpFacmn.DecimalValue = .ImporteNacional
                txtImpFacme.DecimalValue = .ImporteExtranjero
                txtTipoDoc.Text = .tipoDocumento

                Dim tablaSA As New tablaDetalleSA
                txtdescdocu.Text = tablaSA.GetUbicarTablaID(CInt(10), .tipoDocumento).descripcion

            End With

            Dim saldomn As Decimal = 0
            Dim saldome As Decimal = 0
            Dim saldoCantidad As Decimal = 0

            dt.Columns.Add("sec", GetType(Integer))
            dt.Columns.Add("grav", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("item", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("precMN", GetType(Decimal))
            dt.Columns.Add("importeMN", GetType(Decimal))
            dt.Columns.Add("precME", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("tipoEx", GetType(String))
            dt.Columns.Add("almacenRef", GetType(Integer))

            dt.Columns.Add("cantCompra", GetType(Decimal))
            dt.Columns.Add("compraMN", GetType(Decimal))
            dt.Columns.Add("compraME", GetType(Decimal))
            dt.Columns.Add("montokardex", GetType(Decimal))
            dt.Columns.Add("montokardexus", GetType(Decimal))
            dt.Columns.Add("montoIgv", GetType(Decimal))
            dt.Columns.Add("montoIgvUS", GetType(Decimal))
            dt.Columns.Add("cboMov", GetType(String))
            dt.Columns.Add("canDev", GetType(Decimal))
            dt.Columns.Add("canSaldo", GetType(Decimal))

            dt.Columns.Add("vcmn", GetType(Decimal))
            dt.Columns.Add("vcme", GetType(Decimal))
            dt.Columns.Add("ivamn", GetType(Decimal))
            dt.Columns.Add("ivame", GetType(Decimal))
            dt.Columns.Add("totalmn", GetType(Decimal))
            dt.Columns.Add("totalme", GetType(Decimal))

            dt.Columns.Add("pumn", GetType(Decimal))
            dt.Columns.Add("pume", GetType(Decimal))
            dt.Columns.Add("estadoPago", GetType(String))

            dt.Columns.Add("ValDevmn", GetType(Decimal))
            dt.Columns.Add("ValDevme", GetType(Decimal))
            dt.Columns.Add("action", GetType(String))
            dt.Columns.Add("pmMN", GetType(Decimal))
            dt.Columns.Add("pmME", GetType(Decimal))

            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(intIddocumento)
                detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                saldoCantidad = i.CantidadCompra - detalle.monto1
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles)
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD)

                saldomn += cTotalmn
                saldome += cTotalme
                'If saldomn <= 0 AndAlso saldoCantidad <= 0 Then
                '    '    Throw New Exception("El comprobante no está disponible")
                'Else
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.secuencia
                dr(1) = i.destino
                dr(2) = i.idItem
                dr(3) = i.DetalleItem
                Select Case i.TipoExistencia
                    Case "GS"
                        dr(4) = 0
                    Case Else
                        If IsNothing(detalle) Then
                            dr(4) = 0
                        Else
                            dr(4) = i.CantidadCompra - detalle.monto1  ' detalle.monto1
                        End If
                End Select
                dr(5) = 0
                If cTotalmn < 0 Then
                    cTotalmn = 0
                End If
                dr(6) = cTotalmn
                dr(7) = 0
                If cTotalme < 0 Then
                    cTotalme = 0
                End If
                dr(8) = cTotalme
                dr(9) = i.TipoExistencia
                dr(10) = i.almacenRef

                dr(11) = i.CantidadCompra
                dr(12) = i.MontoDeudaSoles
                dr(13) = i.MontoDeudaUSD
                dr(14) = i.montokardex
                dr(15) = i.montokardexus
                dr(16) = i.montoIgv
                dr(17) = i.montoIgvUS
                dr(18) = "9921"
                dr(19) = 0
                dr(20) = 0
                dr(21) = 0
                dr(22) = 0
                dr(23) = 0
                dr(24) = 0
                dr(25) = 0
                dr(26) = 0
                dr(27) = 0
                dr(28) = 0
                Select Case i.EstadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(29) = "Pagado"
                    Case Else
                        dr(29) = "Pendiente"
                End Select
                dr(30) = 0
                dr(31) = 0
                dr(32) = "activo"
                dr(33) = i.pmMN
                dr(34) = i.pmME
                dt.Rows.Add(dr)
                'End If
            Next
            dgvMov.DataSource = dt
            dgvMov.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
            '    Me.dgvMov.TableOptions.ListBoxSelectionMode = SelectionMode.One

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Sub ConfiguracionInicio()

        'configurando docking manager
        Me.WindowState = FormWindowState.Maximized
        dockingManager1.DockControlInAutoHideMode(Panel8, DockingStyle.Right, 565)
        dockingManager1.SetDockLabel(Panel8, "Ventas")
        dockingManager1.CloseEnabled = False
        ToolStripButton1.Image = ImageListAdv1.Images(1)
        dgvCompra.ShowRowHeaders = False
        'confgiurando variables generales

        txtPeriodoCompras.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        ' lblPerido.Text = lblPerido.Text
        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
    End Sub

    Private Sub UbicarCompraXProveedorNroSerie(RucProveedor As String, strPeriodo As String)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoMN", GetType(Decimal))
        dt.Columns.Add("montoME", GetType(Decimal))


        documentoVenta = documentoVentaSA.UbicarVentaPorClienteXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, strPeriodo)
        Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoVenta
                dr(2) = str
                dr(3) = i.fechaPeriodo
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select
                dr(8) = i.ImporteNacional
                dr(9) = i.ImporteExtranjero
                dt.Rows.Add(dr)
            Next
            dgvCompra.DataSource = dt

        Else

        End If
    End Sub
    Private Function comboTable() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        'Dim dr As DataRow = dt.NewRow()
        'dr(0) = "1"
        'dr(1) = "DISMINUIR CANTIDAD"
        'dt.Rows.Add(dr)

        'Dim dr2 As DataRow = dt.NewRow()
        'dr2(0) = "2"
        'dr2(1) = "DISMINUIR IMPORTE"
        'dt.Rows.Add(dr2)

        Dim dr3 As DataRow = dt.NewRow()
        dr3(0) = "9921"
        dr3(1) = "INCREMENTO DEL COSTO"
        dt.Rows.Add(dr3)

        Return dt
    End Function

#End Region

    Private Sub frmNotaDebitoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ggcStyle As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns(19).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumero.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCompra.TableControlCurrentCellControlDoubleClick
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        Me.Cursor = Cursors.WaitCursor
        'If DocumentoCompraSA.TieneItemsEnAV(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = True Then
        '    PanelError.Visible = True
        '    lblEstado.Text = "El comprobante posee items en el almacen en transito, " & "necesita realizar la distribución, para seguir el proceso!"
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        '    Me.Cursor = Cursors.Arrow
        'Else
        UbicarDetalle(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
        'End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvMov_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvMov.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "canDev")) Then

                Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 11).CellValue
                Select Case str
                    Case "3" '  "DEVOLUCION DE EXISTENCIAS"
                        e.Style.[ReadOnly] = False
                        ''e.Style.BackColor = Color.AliceBlue
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case "1" ' "DISMINUIR CANTIDAD"
                        e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.AliceBlue

                    Case "9921" '"DISMINUIR IMPORTE"
                        e.Style.[ReadOnly] = True
                        'e.Style.BackColor = Color.AliceBlue
                End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 11).CellValue
                Select Case str
                    Case "3" '  "DEVOLUCION DE EXISTENCIAS"
                        e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.AliceBlue
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case "1" ' "DISMINUIR CANTIDAD"
                        e.Style.[ReadOnly] = True
                        'e.Style.BackColor = Color.AliceBlue

                    Case "9921" '"DISMINUIR IMPORTE"
                        e.Style.[ReadOnly] = False
                        'e.Style.BackColor = Color.AliceBlue
                End Select

            Else
                'e.Style.[ReadOnly] = False
            End If

            'If e.TableCellIdentity.Column.Name = "gravado" Then
            '    If e.Style.CellValue.Equals("1") Then



            '        e.Style.BackColor = Color.LightYellow
            '    End If
            'End If


        End If
    End Sub

    Sub Calculos()
        Dim cantidad As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Decimal = 0
        Dim colBonifica As String = Nothing
        Dim porcentajeIgv As Decimal = 0

        porcentajeIgv = Math.Round(CDec(txtIva.Text) / 100, 2)
        '****************************************************************
        'colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
        colDestinoGravado = Me.dgvMov.Table.CurrentRecord.GetValue("grav")
        cantidad = Me.dgvMov.Table.CurrentRecord.GetValue("canDev")
        Me.dgvMov.Table.CurrentRecord.SetValue("canDev", cantidad.ToString("N2"))
        VC = Me.dgvMov.Table.CurrentRecord.GetValue("vcmn")
        VCme = Math.Round(VC / CDec(txtTipoCambio.Text), 2)
        If cantidad > 0 AndAlso VC > 0 Then
            Igv = Math.Round(VC * porcentajeIgv, 2)
            IgvME = Math.Round(VCme * porcentajeIgv, 2)

            colBI = VC + Igv
            colBIme = VCme + IgvME

            colPrecUnit = Math.Round(VC / cantidad, 2)
            colPrecUnitme = Math.Round(VCme / cantidad, 2)
        ElseIf cantidad = 0 Then
            Igv = Math.Round(VC * porcentajeIgv, 2)
            IgvME = Math.Round(VCme * porcentajeIgv, 2)
            colBI = VC + Igv
            colBIme = VCme + IgvME
            colPrecUnit = 0
            colPrecUnitme = 0
        Else
            colPrecUnit = 0
            colPrecUnitme = 0

            colBI = 0
            colBIme = 0
            Igv = 0
            IgvME = 0
        End If


        Select Case TextBoxExt1.Tag

            Case "03", "02"
                Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("igvmn", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("igvme", 0)
            Case Else
                If txtMon.Text = 1 Then
                    ' DATOS SOLES

                    Select Case colDestinoGravado
                        Case "2", "3", "4"

                            Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("ivame", 0)

                        Case Else
                            If Me.dgvMov.Table.CurrentRecord.GetValue("chBonif") = "1" Then ' BOnIFICACIOn
                                Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("ivame", 0)

                            Else
                                If cantidad > 0 Then

                                    Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", Igv.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("ivame", IgvME.ToString("N2"))

                                Else

                                    Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", Igv.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("ivame", IgvME.ToString("N2"))

                                End If

                            End If
                    End Select

                ElseIf txtMon.Text = 2 Then

                    Select Case colDestinoGravado
                        Case "4"

                        Case Else


                    End Select

                End If
        End Select
        TotalTalesXcolumna()
    End Sub

    Private Sub dgvMov_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try
        '    If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
        '        Select Case ColIndex
        '            Case 11
        '                'Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
        '                '    Case "1"
        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If
        '                '        dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                '    Case "2"
        '                '        dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        '                '    Case "3"
        '                '        Dim cantidadOrigen As Decimal = 0
        '                '        cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
        '                '        If cantidadOrigen <= 0 Then
        '                '            dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                '            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                '        End If
        '                'End Select

        '                Calculos()
        '            Case 12
        '                'Dim cantidad As Decimal = 0
        '                'Dim canSaldo As Decimal = 0
        '                'Dim cantidadOrigen As Decimal = 0

        '                'cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
        '                'If cantidadOrigen <= 0 Then
        '                '    dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        '                '    Throw New Exception("El valor de la cantidad no esta disponible")
        '                'End If

        '                'If CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) > cantidadOrigen Then
        '                '    dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        '                '    Throw New Exception("El valor de la cantidad excede al monto original")
        '                'End If

        '                'cantidad = dgvMov.Table.CurrentRecord.GetValue("cantCompra")
        '                'canSaldo = cantidad - CDec(dgvMov.Table.CurrentRecord.GetValue("canDev"))
        '                'dgvMov.Table.CurrentRecord.SetValue("canSaldo", canSaldo)
        '                Calculos()
        '            Case 13
        '                Calculos()
        '                'Select Case dgvMov.Table.CurrentRecord.GetValue("estadoPago")
        '                '    Case "Pagado"
        '                '        Dim saldoFinalmn As Decimal = 0
        '                '        Dim saldoFinalme As Decimal = 0

        '                '        Dim saldoCompramn As Decimal = 0
        '                '        Dim saldoComprame As Decimal = 0
        '                '        Dim valAbonomn As Decimal = 0
        '                '        Dim valAbonome As Decimal = 0
        '                '        Dim ventaOriginalMN As Decimal = 0
        '                '        Dim ventaOriginalME As Decimal = 0

        '                '        ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
        '                '        ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

        '                '        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
        '                '        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))

        '                '        'If saldoCompramn <= 0 Then
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                '        '    Calculos()
        '                '        '    Throw New Exception("El Comprobante no esta disponible")
        '                '        'End If
        '                '        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
        '                '        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")

        '                '        saldoFinalmn = ventaOriginalMN - valAbonomn
        '                '        saldoFinalme = ventaOriginalME - valAbonome

        '                '        If saldoFinalmn < 0 Then
        '                '            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                '            Calculos()
        '                '            Throw New Exception("El monto ingresado supera al valor original del artículo!")

        '                '        ElseIf saldoFinalmn >= 0 Then
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
        '                '            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                '        End If

        '                '        'If saldoFinalmn <= 0 Then
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                '        'Else
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
        '                '        '    dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                '        ''End If
        '                '        'Calculos()

        '                '    Case Else

        '                '        Dim saldoFinalmn As Decimal = 0
        '                '        Dim saldoFinalme As Decimal = 0
        '                '        Dim ventaOriginalMN As Decimal = 0
        '                '        Dim ventaOriginalME As Decimal = 0

        '                '        Dim saldoCompramn As Decimal = 0
        '                '        Dim saldoComprame As Decimal = 0
        '                '        Dim valAbonomn As Decimal = 0
        '                '        Dim valAbonome As Decimal = 0

        '                '        ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
        '                '        ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

        '                '        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
        '                '        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))


        '                '        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
        '                '        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")


        '                '        If saldoCompramn <= 0 Then
        '                '            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                '            Calculos()
        '                '            Throw New Exception("El Comprobante no esta disponible")
        '                '        End If

        '                '        If valAbonomn > ventaOriginalMN Then
        '                '            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                '            Calculos()
        '                '            Throw New Exception("El importe de la nota supera al importe de venta, " & ventaOriginalMN.ToString("N2"))
        '                '        End If

        '                '        saldoFinalmn = saldoCompramn - valAbonomn
        '                '        saldoFinalme = saldoComprame - valAbonome

        '                '        If saldoFinalmn < 0 Then
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
        '                '            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                '        Else
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                '            dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                '        End If
        '                'End Select

        '                'Calculos()
        '            Case 16
        '                'dgvMov.Table.CurrentRecord.SetValue("ValDevmn", CDec(dgvMov.Table.CurrentRecord.GetValue("totalmn")))
        '                'dgvMov.Table.CurrentRecord.SetValue("ValDevme", CDec(dgvMov.Table.CurrentRecord.GetValue("totalme")))

        '                TotalTalesXcolumna()

        '        End Select
        '    End If
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End Try


    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"
            End If

            If Not txtCliente.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"

                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"

            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de comprobante válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done número comprobante"

            End If

            '***********************************************************************
            If dgvMov.Table.Records.Count > 0 Then
                Grabar()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtCliente.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumeroGuia.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerieGuia.Clear()
        End Try
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As EventArgs) Handles txtSerieGuia.LostFocus
        
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtSerieGuia.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumeroGuia.Clear()
        End Try
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As EventArgs) Handles txtNumeroGuia.LostFocus
        
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Me.dgvMov.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim strPeriodo As String = String.Format("{0:00}", CInt(txtPeriodoCompras.Value.Month))
        strPeriodo = String.Concat(strPeriodo, "/", txtPeriodoCompras.Value.Year)
        UbicarCompraXProveedorNroSerie(txtRuc.Text, strPeriodo)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged

    End Sub

    Private Sub dgvMov_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If Not IsNothing(cc) Then
                Select Case cc.ColIndex
                    Case 11

                        Calculos()
                    Case 12
                        Calculos()
                    Case 13
                        Calculos()

                    Case 16
                        TotalTalesXcolumna()
                    Case 4

                        TotalTalesXcolumna()
                End Select


            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
        f.CaptionLabels(0).Text = "Clientes"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            dgvMov.DataSource = New DataTable

            Dim c = DirectCast(f.Tag, entidad)
            'Dim c = CType(f.Tag, entidad)
            txtCliente.Text = c.nombreCompleto
            txtCliente.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub
End Class