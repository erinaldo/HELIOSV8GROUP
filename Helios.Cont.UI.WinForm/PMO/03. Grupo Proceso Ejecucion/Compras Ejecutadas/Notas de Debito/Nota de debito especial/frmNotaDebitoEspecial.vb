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
Public Class frmNotaDebitoEspecial
    Inherits frmMaster

    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property tipoCambio() As Decimal
    Public Property IdCompraOrigen() As Integer
    Public Property ListaAsientonTransito As New List(Of asiento)

    Public Sub New(intidDoc As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfiguracionInicio()
        UbicarDetalle(intidDoc)
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



    Private Sub UbicarCompraDetalle(idDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        Dim documentoCompra As New List(Of documentocompradetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        dt.Columns.Add("idItem", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoexistencia", GetType(String))
        dt.Columns.Add("unidad", GetType(String))

        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("importemn", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))

        documentoCompra = documentoCompraSA.UbicarDocumentoCompraDetalle(idDocumento)

        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idItem
                dr(1) = i.descripcionItem
                'dr(2) = i.tipoExistencia
                dr(2) = tablaSA.GetUbicarTablaID(5, i.tipoExistencia).descripcion
                'dr(3) = i.unidad1
                dr(3) = tablaSA.GetUbicarTablaID(6, i.unidad1).descripcion.Substring(0, 3)
                'dr(4) = tablaSA.GetUbicarTablaID(10, i.TipoDoc).descripcion.Substring(0, 3)
                dr(4) = i.monto1
                dr(5) = i.precioUnitario
                dr(6) = i.precioUnitarioUS
                dr(7) = i.importe
                dr(8) = i.importeUS
                '
                dt.Rows.Add(dr)
            Next
            dgvCompraDetalle.DataSource = dt

        Else

        End If
    End Sub


    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento

        Select Case txtTipoDoc.Tag
            Case TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                nMovimiento.cuenta = "424"

            Case Else
                nMovimiento.cuenta = "4212"
        End Select


        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario

        Return nMovimiento
    End Function

    Sub AsientoNotaDedito()
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtProveedor.Tag)
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaDebito
        nAsiento.importeMN = TotalesXcanbeceras.TotalMN
        nAsiento.importeME = TotalesXcanbeceras.TotalME
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)


        For Each r As Record In dgvMov.Table.Records
           
            MV_Item_Transito(r.GetValue("idItem"), r.GetValue("item"), CDec(r.GetValue("vcmn")), CDec(r.GetValue("vcme")), r.GetValue("tipoEx"))
           


            nMovimiento = New movimiento
            nMovimiento.cuenta = r.GetValue("idItem")
            nMovimiento.descripcion = r.GetValue("item")
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE

            nMovimiento.monto = CDec(r.GetValue("vcmn"))
            nMovimiento.montoUSD = CDec(r.GetValue("vcme"))

            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario

            nAsiento.movimiento.Add(nMovimiento)

        Next
        nAsiento.movimiento.Add(AS_IGV(TotalesXcanbeceras.IgvMN, TotalesXcanbeceras.IgvME))
        nAsiento.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))

        '   Return nAsiento
    End Sub
    Public Function AS_Default(cMonto As Decimal, cMontoUS As Decimal, tipoex As String, DescItem As String, CuentaServicio As String) As movimiento
        Dim nMovimiento As New movimiento
        Dim cuentaMascaraSA As New cuentaMascaraSA
        nMovimiento = New movimiento

        If tipoex = TipoRecurso.SERVICIO Then
            nMovimiento.cuenta = CuentaServicio
        Else
            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, tipoex, "ITEM", "COMPRA")
            Select Case cuentaMascara.parametro
                Case "01"
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        End If
        nMovimiento.descripcion = DescItem
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
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
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtProveedor.Tag)
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaDebito
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function
    Dim cuentaMascara As New cuentaMascara
    Public Sub MV_Item_Transito(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .destinoCompra
                End With
            Case "02", "03", "04", "05"
                With mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, cCuenta, strTipoExistencia)
                    nMovimiento.cuenta = .cuentaIngAlmacen2
                End With
        End Select
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .destinoCompra2
                End With
            Case "02", "03", "04", "05"
                With mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, cCuenta, strTipoExistencia)
                    nMovimiento.cuenta = .cuentaSalida
                End With
        End Select

        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Function ComprobanteCaja() As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento


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
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.IdProveedor = txtProveedor.Tag
        objCaja.codigoLibro = "9912"
        objCaja.codigoProveedor = CInt(txtProveedor.Tag)
        objCaja.TipoDocumentoPago = "109"
        objCaja.tipoDocPago = "109"
        objCaja.periodo = lblPerido.Text
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = "1" ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = CDec(txtTipoCambio.Text)
        objCaja.montoSoles = TotalesXcanbeceras.importeDevmn
        objCaja.montoUsd = TotalesXcanbeceras.importeDevme

        objCaja.glosa = txtGlosa.Text.Trim
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        '   For Each i As DataGridViewRow In dgvNuevoDoc.Rows
        objCajaDetalle = New documentoCajaDetalle
        objCajaDetalle.idDocumento = 0
        objCajaDetalle.fecha = txtFecha.Value
        objCajaDetalle.idItem = "00"
        objCajaDetalle.DetalleItem = "Por excedente, nota de crédito"
        objCajaDetalle.montoSoles = TotalesXcanbeceras.importeDevmn
        objCajaDetalle.montoUsd = TotalesXcanbeceras.importeDevme
        objCajaDetalle.entregado = "SI"
        objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
        objCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        objCajaDetalle.fechaModificacion = DateTime.Now
        ListaDetalle.Add(objCajaDetalle)
        '   Next
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE

        asiento = New asiento
        With asiento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idEntidad = txtProveedor.Tag
            .nombreEntidad = txtProveedor.Text
            .tipoEntidad = "PR"
            .fechaProceso = txtFecha.Value
            .codigoLibro = "8"
            .tipo = "D"
            .tipoAsiento = "AS-NTC"
            .importeMN = TotalesXcanbeceras.importeDevmn
            .importeME = TotalesXcanbeceras.importeDevme
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = "D"
        nMovimiento.monto = TotalesXcanbeceras.importeDevmn
        nMovimiento.montoUSD = TotalesXcanbeceras.importeDevme
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "16"
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = "H"
        nMovimiento.monto = TotalesXcanbeceras.importeDevmn
        nMovimiento.montoUSD = TotalesXcanbeceras.importeDevme
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        'ListaAsientonTransito.Add(asiento)

        Return nDocumentoCaja
    End Function

    Sub GuiaRemision(objDocumentoCompra As documento, Lista As List(Of documentocompradetalle))
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = CInt(txtProveedor.Tag)
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

        For Each r As documentocompradetalle In Lista

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
                documentoguiaDetalle.descripcionItem = r.descripcionItem
                documentoguiaDetalle.destino = r.destino
                documentoguiaDetalle.unidadMedida = Nothing  'r.GetValue("um")
                documentoguiaDetalle.cantidad = r.monto1
                documentoguiaDetalle.precioUnitario = r.precioUnitario
                documentoguiaDetalle.precioUnitarioUS = r.precioUnitarioUS
                documentoguiaDetalle.importeMN = r.importe
                documentoguiaDetalle.importeME = r.importeUS
                documentoguiaDetalle.almacenRef = r.almacenRef
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub AsientoNotaCreditoNormal(consultaAsiento As List(Of documentocompradetalle))
        Dim SumTotalMN As Decimal = 0
        Dim SumTotalME As Decimal = 0

        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaDebito
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        For Each i In consultaAsiento
            SumTotalMN += CDec(i.importe)
            SumTotalME += CDec(i.importeUS)

            If i.TipoOperacion = "9921" Then ' INCREMENTO DEL COSTO
                nAsiento.movimiento.Add(AS_Default(i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem, i.idItem))
                If i.montoIgv > 0 Then
                    nAsiento.movimiento.Add(AS_IGV(i.montoIgv, i.montoIgvUS))
                End If
                nAsiento.movimiento.Add(AS_Proveedor(i.importe, i.importeUS))
            ElseIf i.TipoOperacion = "9923" Then ' GASTOS FINANCIEROS
                nMovimiento = New movimiento
                nMovimiento.cuenta = "6799"
                nMovimiento.descripcion = "Otros Gastos Financieros"
                nMovimiento.tipo = "D"
                nMovimiento.monto = i.montokardex
                nMovimiento.montoUSD = i.montokardexUS
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                nAsiento.movimiento.Add(nMovimiento)

                nAsiento.movimiento.Add(AS_IGV(i.montoIgv, i.montoIgvUS))

                nMovimiento = New movimiento
                nMovimiento.cuenta = "4212"
                nMovimiento.descripcion = i.descripcionItem
                nMovimiento.tipo = "H"
                nMovimiento.monto = i.importe
                nMovimiento.montoUSD = i.importeUS
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                nAsiento.movimiento.Add(nMovimiento)

            End If
        Next
        nAsiento.importeMN = SumTotalMN
        nAsiento.importeME = SumTotalME
    End Sub

    Dim cuentaMascaraSA As New cuentaMascaraSA
    Public Sub MV_Item_Transito(i As Record)
        Dim almacenSA As New almacenSA
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento
        Dim idAlmacenVirtual As Integer

        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen

        asientoTransitod = AsientoTransito(CDec(i.GetValue("vcmn")), CDec(i.GetValue("vcme"))) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        If i.GetValue("almacenRef") = idAlmacenVirtual Then
            Select Case i.GetValue("tipoEx")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        Else
            Select Case i.GetValue("tipoEx")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "ALM01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "ALM03.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "ALM04.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "ALM05.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select

        End If

        nMovimiento.descripcion = i.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = i.GetValue("vcmn")
        nMovimiento.montoUSD = i.GetValue("vcme")
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        If i.GetValue("almacenRef") = idAlmacenVirtual Then

            Select Case i.GetValue("tipoEx")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select

        Else
            Select Case i.GetValue("tipoEx")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.2")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        End If


        nMovimiento.descripcion = i.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = i.GetValue("vcmn")
        nMovimiento.montoUSD = i.GetValue("vcme")
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoExce As New documento
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim DocCaja As New documento

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim almacenSA As New almacenSA
        Dim ListaDetalle As New List(Of documentocompradetalle)
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
            .tipoDoc = "88"
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            .nrodocEntidad = txtRuc.Text
            .tipoOperacion = StatusTipoOperacion.COMPRA
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .tieneDetraccion = "N"
            .idPadre = IdCompraOrigen
            .codigoLibro = "8"
            .tipoDoc = "88"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            .fechaContable = lblPerido.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = CInt(txtProveedor.Tag)
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)    ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = CDec(txtTipoCambio.Text)
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
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
            .importeTotal = TotalesXcanbeceras.TotalMN
            .importeUS = TotalesXcanbeceras.TotalME
            .destino = TIPO_COMPRA.NOTA_DEBITO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.NOTA_DEBITO
            .situacion = statusComprobantes.Normal
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01" 'strTipoNota
            .aprobado = "N"
            .ImporteDevMN = TotalesXcanbeceras.importeDevmn
            .ImporteDevME = TotalesXcanbeceras.importeDevme
            .SaldoVentaMN = TotalesXcanbeceras.SaldoVentaMN
            .SaldoVentaME = TotalesXcanbeceras.SaldoVentaME
        End With
        ndocumento.documentocompra = nDocumentoCompra


        For Each r As Record In dgvMov.Table.Records
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
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

            objDocumentoCompraDet.secuencia = r.GetValue("sec")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            'objDocumentoCompraDet.TipoDoc = "07"
            'objDocumentoCompraDet.Serie = txtSerie.Text
            'objDocumentoCompraDet.NumDoc = txtNumero.Text
            Select Case r.GetValue("cboMov")
                Case "9921" 'INCREMENTO DEL COSTO
                    Select Case r.GetValue("tipoEx")
                        Case "GS"
                            objDocumentoCompraDet.tipoExistencia = "GS"
                        Case Else
                            objDocumentoCompraDet.tipoExistencia = CStr(r.GetValue("tipoEx"))
                            MV_Item_Transito(r)
                    End Select

                    If Not CDec(r.GetValue("vcmn")) > 0 Then
                        lblEstado.Text = "Ingrese un Valor de compra mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                    objDocumentoCompraDet.TipoOperacion = "9921"
                Case "9923" 'OTROS GASTOS FINANCIEROS
                    Select Case r.GetValue("tipoEx")
                        Case "GS"
                            objDocumentoCompraDet.tipoExistencia = "GS"
                        Case Else
                            objDocumentoCompraDet.tipoExistencia = CStr(r.GetValue("tipoEx"))
                    End Select

                    If Not CDec(r.GetValue("vcmn")) > 0 Then
                        lblEstado.Text = "Ingrese un Valor de compra mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If

                    objDocumentoCompraDet.TipoOperacion = "9923"
            End Select
            objDocumentoCompraDet.destino = r.GetValue("grav")
            objDocumentoCompraDet.idItem = r.GetValue("idItem")
            objDocumentoCompraDet.descripcionItem = CStr(r.GetValue("item"))

            objDocumentoCompraDet.monto1 = 0
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoCompraDet.importe = CDec(r.GetValue("totalmn"))
            objDocumentoCompraDet.importeUS = CDec(r.GetValue("totalme"))
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
            objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacenRef"))

            objDocumentoCompraDet.preEvento = r.GetValue("estadoPago") '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = Nothing


            objDocumentoCompraDet.idPadreDTCompra = CInt(r.GetValue("sec"))
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            ' objDocumentoCompraDet.BonificacionMN =

            objDocumentoCompraDet.NumDoc = txtNumero.Text
            objDocumentoCompraDet.Serie = txtSerie.Text
            objDocumentoCompraDet.TipoDoc = "88"
            'objDocumentoCompraDet.estadoPago = r.GetValue("estadoPago")
            objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PAGADO
            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        '---------------------------------------------------------------------------------
        'If chDeposito.Checked = True Then
        '    
        'End If

        'Dim listaCaja As List(Of documentocompradetalle) = (From n In ListaDetalle _
        '                Where Fix(n.ImporteDevolucionmn) > 0).ToList

        'If listaCaja.Count > 0 Then
        '    DocCaja = ComprobanteCaja()
        'End If

        'AsientoNotaDedito()
        'ndocumento.asiento = ListaAsientonTransito
        AsientoNotaCreditoNormal(ListaDetalle)
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        Dim xcod As Integer = CompraSA.GrabarNotaDebito(ndocumento, DocCaja)
        lblEstado.Text = "nota de crédito registrada!"
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
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentocompradetalle
        Dim compraSA As New DocumentoCompraSA
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
            With compraSA.UbicarDocumentoCompra(intIddocumento)
                IdCompraOrigen = .idDocumento

                txtTipoDoc.Tag = .tipoCompra

                If .monedaDoc = "1" Then
                    txtMon.Text = "1"
                ElseIf .monedaDoc = "2" Then
                    txtMon.Text = "2"
                End If


                txtTipoCambio.Text = .tcDolLoc
                txtTipoCambio.ReadOnly = True
                txtIva.Text = .tasaIgv
                txtImpFacmn.DecimalValue = .importeTotal
                txtImpFacme.DecimalValue = .importeUS




                Dim tablaSA As New tablaDetalleSA

                txtTipoDoc.Text = tablaSA.GetUbicarTablaID(CInt(10), .tipoDoc).descripcion

                TextBoxExt4.Text = .serie
                TextBoxExt3.Text = .numeroDoc


            End With

            Dim saldomn As Decimal = 0
            Dim saldome As Decimal = 0

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

            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(intIddocumento)
                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                Select Case i.EstadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe ' + detalle.ImporteDBMN
                        cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS '+ detalle.ImporteDBME
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                        'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)

                        'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles)
                        'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD)

                        cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN
                        cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME
                End Select


                saldomn += cTotalmn
                saldome += cTotalme

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
                    Case TIPO_COMPRA.PAGO.PAGADO

                        dr(29) = "Pagado"
                    Case Else
                        dr(29) = "Pendiente"

                End Select
                dr(30) = 0
                dr(31) = 0
                dr(32) = "activo"
                dt.Rows.Add(dr)
            Next
            dgvMov.DataSource = dt
            dgvMov.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
            '    Me.dgvMov.TableOptions.ListBoxSelectionMode = SelectionMode.One

        Catch ex As Exception

        End Try
    End Sub

    Sub ConfiguracionInicio()
        'Centrar(Me)
        dgvMov.TableDescriptor.Columns("cantCompra").Width = 0
        dgvMov.TableDescriptor.Columns("compraMN").Width = 0
        dgvMov.TableDescriptor.Columns("compraME").Width = 0
        dgvMov.TableDescriptor.Columns("montokardex").Width = 0
        dgvMov.TableDescriptor.Columns("montokardexus").Width = 0
        dgvMov.TableDescriptor.Columns("montoIgv").Width = 0
        dgvMov.TableDescriptor.Columns("montoIgvUS").Width = 0
        dgvMov.TableDescriptor.Columns("estadoPago").Width = 0
        dgvMov.TableDescriptor.Columns("ValDevmn").Width = 0
        dgvMov.TableDescriptor.Columns("ValDevme").Width = 0
        dgvMov.TableDescriptor.Columns("action").Width = 0
        'configurando docking manager
        ' Me.WindowState = FormWindowState.Maximized
        dockingManager1.DockControlInAutoHideMode(Panel8, DockingStyle.Right, 565)
        dockingManager1.SetDockLabel(Panel8, "Compras")
        dockingManager1.CloseEnabled = False
        ' ToolStripButton1.Image = ImageListAdv1.Images(1)

        dgvCompra.ShowRowHeaders = False
        'confgiurando variables generales
        '     lblPerido.Text = lblPerido.Text 
        txtPeriodoCompras.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
    End Sub


    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UbicarCompraXProveedorNroSerie(RucProveedor As String, strPeriodo As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
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

        documentoCompra = documentoCompraSA.UbicarCompraPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, strPeriodo)
        Dim str As String
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.fechaContable
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select
                dr(8) = i.importeTotal
                dr(9) = i.importeUS
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

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "9923"
        dr(1) = "Gastos Financieros"
        dt.Rows.Add(dr)

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

    Private Sub frmNotaDebitoEspecial_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNotaDebitoEspecial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ggcStyle As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns(19).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text


                If txtSerie.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por el registro de la nota de débito " & "del proveedor, " & txtProveedor.Text.Trim & "de fecha " & txtFecha.Value
                End If
                dgvMov.Table.Records.DeleteAll()
                dgvCompra.Table.Records.DeleteAll()
                dgvCompraDetalle.Table.Records.DeleteAll()
                txtSerieGuia.Select()
                txtSerieGuia.SelectAll()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumero.Select()
                If txtSerie.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por el registro de la nota de débito " & "del proveedor, " & txtProveedor.Text.Trim & "de fecha " & txtFecha.Value
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        'Try
        '    If txtSerie.Text.Trim.Length > 0 Then
        '        '  If chFormato.Checked = True Then
        '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
        '        'End If
        '    End If

        'Catch ex As Exception

        '    If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

        '        If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

        '            If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

        '                If Len(txtSerie.Text) <= 2 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

        '                ElseIf Len(txtSerie.Text) <= 3 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

        '                ElseIf Len(txtSerie.Text) <= 4 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

        '                ElseIf Len(txtSerie.Text) <= 5 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

        '                End If
        '            End If
        '        Else

        '            txtSerie.Select()
        '            txtSerie.Focus()
        '            txtSerie.Clear()
        '            lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '            Timer1.Enabled = True
        '            PanelError.Visible = True
        '            TiempoEjecutar(10)

        '        End If

        '    Else

        '        txtSerie.Select()
        '        txtSerie.Focus()
        '        txtSerie.Clear()
        '        lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '        Timer1.Enabled = True
        '        PanelError.Visible = True
        '        TiempoEjecutar(10)
        '    End If

        'End Try
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCompra.TableControlCurrentCellControlDoubleClick
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        Me.Cursor = Cursors.WaitCursor
        If DocumentoCompraSA.TieneItemsEnAV(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = True Then
            PanelError.Visible = True
            lblEstado.Text = "El comprobante posee items en el almacen en transito, " & "necesita realizar la distribución, para seguir el proceso!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
        Else
            UbicarDetalle(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
        End If

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

        porcentajeIgv = txtIva.Text
        '****************************************************************
        'colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
        colDestinoGravado = Me.dgvMov.Table.CurrentRecord.GetValue("grav")
        cantidad = Me.dgvMov.Table.CurrentRecord.GetValue("canDev")
        Me.dgvMov.Table.CurrentRecord.SetValue("canDev", cantidad.ToString("N2"))
        VC = Me.dgvMov.Table.CurrentRecord.GetValue("vcmn")
        VCme = Math.Round(VC / CDec(txtTipoCambio.Text), 2)
        If VC > 0 Then
            Igv = Math.Round(VC * porcentajeIgv, 2)
            IgvME = Math.Round(VCme * porcentajeIgv, 2)

            colBI = VC + Igv
            colBIme = VCme + IgvME

            'colPrecUnit = Math.Round(VC / cantidad, 2)
            'colPrecUnitme = Math.Round(VCme / cantidad, 2)
        ElseIf VC = 0 Then
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
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                Select Case ColIndex
                    Case 11
                        'Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
                        '    Case "1"
                        '        Dim cantidadOrigen As Decimal = 0
                        '        cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
                        '        If cantidadOrigen <= 0 Then
                        '            dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
                        '            Throw New Exception("Esta opción no esta disponible elija otra!")
                        '        End If
                        '        dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                        '    Case "2"
                        '        dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
                        '    Case "3"
                        '        Dim cantidadOrigen As Decimal = 0
                        '        cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
                        '        If cantidadOrigen <= 0 Then
                        '            dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
                        '            Throw New Exception("Esta opción no esta disponible elija otra!")
                        '        End If
                        'End Select

                        Calculos()
                    Case 12
                        'Dim cantidad As Decimal = 0
                        'Dim canSaldo As Decimal = 0
                        'Dim cantidadOrigen As Decimal = 0

                        'cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
                        'If cantidadOrigen <= 0 Then
                        '    dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
                        '    Throw New Exception("El valor de la cantidad no esta disponible")
                        'End If

                        'If CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) > cantidadOrigen Then
                        '    dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
                        '    Throw New Exception("El valor de la cantidad excede al monto original")
                        'End If

                        'cantidad = dgvMov.Table.CurrentRecord.GetValue("cantCompra")
                        'canSaldo = cantidad - CDec(dgvMov.Table.CurrentRecord.GetValue("canDev"))
                        'dgvMov.Table.CurrentRecord.SetValue("canSaldo", canSaldo)
                        Calculos()
                    Case 13
                        Calculos()
                        'Select Case dgvMov.Table.CurrentRecord.GetValue("estadoPago")
                        '    Case "Pagado"
                        '        Dim saldoFinalmn As Decimal = 0
                        '        Dim saldoFinalme As Decimal = 0

                        '        Dim saldoCompramn As Decimal = 0
                        '        Dim saldoComprame As Decimal = 0
                        '        Dim valAbonomn As Decimal = 0
                        '        Dim valAbonome As Decimal = 0
                        '        Dim ventaOriginalMN As Decimal = 0
                        '        Dim ventaOriginalME As Decimal = 0

                        '        ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
                        '        ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

                        '        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
                        '        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))

                        '        'If saldoCompramn <= 0 Then
                        '        '    dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                        '        '    dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
                        '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                        '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                        '        '    Calculos()
                        '        '    Throw New Exception("El Comprobante no esta disponible")
                        '        'End If
                        '        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
                        '        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")

                        '        saldoFinalmn = ventaOriginalMN - valAbonomn
                        '        saldoFinalme = ventaOriginalME - valAbonome

                        '        If saldoFinalmn < 0 Then
                        '            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                        '            Calculos()
                        '            Throw New Exception("El monto ingresado supera al valor original del artículo!")

                        '        ElseIf saldoFinalmn >= 0 Then
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
                        '            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                        '        End If

                        '        'If saldoFinalmn <= 0 Then
                        '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
                        '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
                        '        '    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                        '        'Else
                        '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
                        '        '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
                        '        '    dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                        '        ''End If
                        '        'Calculos()

                        '    Case Else

                        '        Dim saldoFinalmn As Decimal = 0
                        '        Dim saldoFinalme As Decimal = 0
                        '        Dim ventaOriginalMN As Decimal = 0
                        '        Dim ventaOriginalME As Decimal = 0

                        '        Dim saldoCompramn As Decimal = 0
                        '        Dim saldoComprame As Decimal = 0
                        '        Dim valAbonomn As Decimal = 0
                        '        Dim valAbonome As Decimal = 0

                        '        ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
                        '        ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

                        '        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
                        '        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))


                        '        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
                        '        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")


                        '        If saldoCompramn <= 0 Then
                        '            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                        '            Calculos()
                        '            Throw New Exception("El Comprobante no esta disponible")
                        '        End If

                        '        If valAbonomn > ventaOriginalMN Then
                        '            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                        '            Calculos()
                        '            Throw New Exception("El importe de la nota supera al importe de venta, " & ventaOriginalMN.ToString("N2"))
                        '        End If

                        '        saldoFinalmn = saldoCompramn - valAbonomn
                        '        saldoFinalme = saldoComprame - valAbonome

                        '        If saldoFinalmn < 0 Then
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                        '            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                        '        Else
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                        '            dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                        '        End If
                        'End Select

                        'Calculos()
                    Case 16
                        'dgvMov.Table.CurrentRecord.SetValue("ValDevmn", CDec(dgvMov.Table.CurrentRecord.GetValue("totalmn")))
                        'dgvMov.Table.CurrentRecord.SetValue("ValDevme", CDec(dgvMov.Table.CurrentRecord.GetValue("totalme")))

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

            If Not txtProveedor.Text.Trim.Length > 0 Then
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
                txtProveedor.Select()
                If txtSerie.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por el registro de la nota de débito " & "del proveedor, " & txtProveedor.Text.Trim & "de fecha " & txtFecha.Value
                End If
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        'Try
        '    If txtNumero.Text.Trim.Length > 0 Then
        '        '    If chFormato.Checked = True Then
        '        txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

        '        'End If
        '    End If
        'Catch ex As Exception
        '    'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
        '    txtNumero.Select()
        '    txtNumero.Focus()
        '    txtNumero.Clear()
        '    lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        'End Try
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
        'Try
        '    If txtSerieGuia.Text.Trim.Length > 0 Then
        '        '  If chFormato.Checked = True Then
        '        txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
        '        'End If
        '    End If

        'Catch ex As Exception

        '    If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerieGuia.Text), 2, 1)) = True Then

        '        If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1)) = True Then

        '            If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1)) = True Then

        '                If Len(txtSerieGuia.Text) <= 2 Then

        '                    txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1))

        '                ElseIf Len(txtSerieGuia.Text) <= 3 Then

        '                    txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 2))

        '                ElseIf Len(txtSerieGuia.Text) <= 4 Then

        '                    txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 3))

        '                ElseIf Len(txtSerieGuia.Text) <= 5 Then

        '                    txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 4))

        '                End If
        '            End If
        '        Else

        '            txtSerieGuia.Select()
        '            txtSerieGuia.Focus()
        '            txtSerieGuia.Clear()
        '            lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '            Timer1.Enabled = True
        '            PanelError.Visible = True
        '            TiempoEjecutar(10)

        '        End If

        '    Else

        '        txtSerieGuia.Select()
        '        txtSerieGuia.Focus()
        '        txtSerieGuia.Clear()
        '        lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '        Timer1.Enabled = True
        '        PanelError.Visible = True
        '        TiempoEjecutar(10)
        '    End If

        'End Try
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
        'Try
        '    If txtNumeroGuia.Text.Trim.Length > 0 Then
        '        '    If chFormato.Checked = True Then
        '        txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))

        '        'End If
        '    End If
        'Catch ex As Exception
        '    'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
        '    txtNumeroGuia.Select()
        '    txtNumeroGuia.Focus()
        '    txtNumeroGuia.Clear()
        '    lblEstado.Text = "Error de formato verifique el ingreso!"
        'End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Me.dgvMov.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvCompra.Table.Records.Count > 0 Then

            Dim el As Element = Me.dgvCompra.Table.GetInnerMostCurrentElement()
            If el IsNot Nothing Then
                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.dgvCompra.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)
                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                End If
                If rec IsNot Nothing Then



                    If IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

                    Else
                        UbicarCompraDetalle(CInt(rec.GetValue("idDocumento")))
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtPeriodoCompras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeriodoCompras.KeyPress

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim strPeriodo As String = String.Format("{0:00}", CInt(txtPeriodoCompras.Value.Month))
        strPeriodo = String.Concat(strPeriodo, "/", txtPeriodoCompras.Value.Year)
        UbicarCompraXProveedorNroSerie(txtRuc.Text, strPeriodo)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompraDetalle_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompraDetalle.TableControlCellClick

    End Sub

    Private Sub GradientPanel3_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel3.Paint

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub

    Private Sub dgvMov_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellChanged
        'Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell
        'cc.ConfirmChanges()
        'Try
        '    If Not IsNothing(cc) Then
        '        Select Case cc.ColIndex
        '            Case 11

        '                Calculos()
        '            Case 12

        '                Calculos()
        '            Case 13
        '                Calculos()

        '            Case 16
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

    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged
        If IsDate(txtFecha.Value) Then
            If txtFecha.Value.Date > DiaLaboral.Date Then
                txtFecha.Value = DiaLaboral
                MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub
End Class