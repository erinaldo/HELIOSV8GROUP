Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.Drawing
Imports System.Drawing.Printing

Public Class frmPagoTicket
    Inherits frmMaster

    Public Property ListaAsientonTransito As New List(Of asiento)
    Dim Sep As Char
    'Public datos2 As PrintUtilListViewCollection
    Public Título As String = ""
    Private prtSettings As PrinterSettings
    Private prtDoc As PrintDocument
    Private ppc As New PrintPreviewControl
    Private prtFont As System.Drawing.Font
    Dim conteo As Integer = 0
    Dim datosEst As Integer = 0
    Private lineaActual As Integer
    Public fontNCabecera As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
    Dim X1, X2, X3, X4, X5 As Integer
    Dim W1, W2, W3, W4, W5 As Integer
    Dim Y As Integer

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GFichaUsuarios = New GFichaUsuario
        Dim cfecha As Date = DateTime.Now.Date
        lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & cfecha.Year
        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        ObtenerEFPrdeterminada()
        lblNombreCliente.Text = String.Empty
        lblTipoDoc.Text = String.Empty
        lblNumDoc.Text = String.Empty
        lblSerieDoc.Text = String.Empty
        lblImporte.Text = String.Empty
        lbligv.Text = String.Empty
        lblImporteme.Text = String.Empty
        lbligvme.Text = String.Empty

        lblEstado.Text = "Ingrese código de venta!"
        lblEstado.Image = My.Resources.ok4
        Timer1.Enabled = True
        TiempoEjecutar(5)
    End Sub



#Region "Métodos" 'GetObtenerVentaPorNumero

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

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
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
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

    Public Function AS_CAJA(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = lblCuenta.Text,
              .descripcion = txtCaja.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFechaPago.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

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
                    nMovimiento.cuenta = .cuentaKardex
                End With
        End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    nMovimiento.cuenta = .cuentaKardex2
                End With

        End Select

        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Function ComprobanteCaja() As documento
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaCajaDetalle As New List(Of documentoCajaDetalle)

        nDocumentoCaja.idDocumento = lblIdDoc.Text
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = txtIDEstablecimientoCaja.Text 'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "12"
        nDocumentoCaja.fechaProceso = txtFechaPago.Value
        nDocumentoCaja.nroDoc = IIf(rbEfectivo.Checked = True, Nothing, lblSerieDoc.Text & "-" & lblNumDoc.Text)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "01"
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now


        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = txtIDEstablecimientoCaja.Text ' GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFechaPago.Value
        objCaja.fechaCobro = txtFechaPago.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If txtCliente.Text.Trim.Length > 0 Then
            objCaja.IdProveedor = txtCliente.Text
        End If
        objCaja.TipoDocumentoPago = "12"
        objCaja.tipoDocPago = "12"
        objCaja.NumeroDocumento = lblSerieDoc.Text & "-" & lblNumDoc.Text
        objCaja.moneda = IIf(rbNac.Checked = True, "1", "2") ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = lblTipoCambio.Text
        objCaja.montoSoles = CDec(lblImporte.Text)
        objCaja.montoUsd = CDec(lblImporteme.Text)

        objCaja.glosa = txtGlosa.Text
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = txtIdCaja.Text
        objCaja.usuarioModificacion = "Jiuni"
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        For Each i As ListViewItem In lsvDetalle.Items
            objCajaDetalle = New documentoCajaDetalle
            objCajaDetalle.idDocumento = 0
            objCajaDetalle.fecha = txtFechaPago.Value
            objCajaDetalle.montoSoles = CDec(i.SubItems(5).Text)
            objCajaDetalle.montoUsd = CDec(i.SubItems(6).Text)
            objCajaDetalle.entregado = "SI"
            objCajaDetalle.documentoAfectado = lblIdDoc.Text
            objCajaDetalle.usuarioModificacion = "Jiuni"
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaCajaDetalle.Add(objCajaDetalle)
        Next

        'nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaCajaDetalle

        Return nDocumentoCaja
    End Function

    'Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
    '    Dim objTotalesDet As New totalesAlmacen
    '    Dim ListaTotales As New List(Of totalesAlmacen)

    '    For Each i As ListViewItem In lsvDetalle.Items

    '        Select Case lblTipoDoc.Text
    '            Case "03", "02"
    '                MV_Item_Transito(i.SubItems(9).Text, i.SubItems(2).Text, CDec(i.SubItems(5).Text), CDec(i.SubItems(6).Text), i.SubItems(12).Text)
    '            Case Else

    '                Select Case i.SubItems(0).Text
    '                    Case "1"
    '                        MV_Item_Transito(i.SubItems(9).Text, i.SubItems(2).Text, CDec(i.SubItems(7).Text), CDec(i.SubItems(8).Text), i.SubItems(12).Text)
    '                    Case Else
    '                        MV_Item_Transito(i.SubItems(9).Text, i.SubItems(2).Text, CDec(i.SubItems(5).Text), CDec(i.SubItems(6).Text), i.SubItems(12).Text)

    '                End Select
    '        End Select


    '        objTotalesDet = New totalesAlmacen
    '        objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        objTotalesDet.SecuenciaDetalle = i.SubItems(15).Text
    '        objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
    '        objTotalesDet.Modulo = "N"
    '        objTotalesDet.idEstablecimiento = i.SubItems(11).Text
    '        objTotalesDet.idAlmacen = i.SubItems(10).Text
    '        objTotalesDet.origenRecaudo = i.SubItems(0).Text
    '        objTotalesDet.tipoCambio = lblTipoCambio.Text
    '        objTotalesDet.tipoExistencia = i.SubItems(12).Text
    '        objTotalesDet.idItem = i.SubItems(1).Text
    '        objTotalesDet.descripcion = i.SubItems(2).Text
    '        objTotalesDet.idUnidad = i.SubItems(4).Text
    '        objTotalesDet.unidadMedida = Nothing
    '        objTotalesDet.cantidad = CType(i.SubItems(16).Text, Decimal) * -1
    '        objTotalesDet.precioUnitarioCompra = 0 ' CType(i.Cells(8).Value(), Decimal)

    '        Select Case lblTipoDoc.Text
    '            Case "03", "02"

    '                objTotalesDet.importeSoles = CType(i.SubItems(5).Text, Decimal) * -1
    '                objTotalesDet.importeDolares = CType(i.SubItems(6).Text, Decimal) * -1
    '            Case Else
    '                Select Case i.SubItems(0).Text
    '                    Case "1"
    '                        objTotalesDet.importeSoles = CType(i.SubItems(7).Text, Decimal) * -1
    '                        objTotalesDet.importeDolares = CType(i.SubItems(8).Text, Decimal) * -1
    '                    Case Else
    '                        objTotalesDet.importeSoles = CType(i.SubItems(5).Text, Decimal) * -1
    '                        objTotalesDet.importeDolares = CType(i.SubItems(6).Text, Decimal) * -1
    '                End Select

    '        End Select


    '        objTotalesDet.montoIsc = 0
    '        objTotalesDet.montoIscUS = 0
    '        objTotalesDet.Otros = 0
    '        objTotalesDet.OtrosUS = 0
    '        objTotalesDet.porcentajeUtilidad = 0
    '        objTotalesDet.importePorcentaje = 0
    '        objTotalesDet.importePorcentajeUS = 0
    '        objTotalesDet.precioVenta = 0
    '        objTotalesDet.precioVentaUS = 0
    '        objTotalesDet.usuarioActualizacion = "NN"
    '        objTotalesDet.fechaActualizacion = Date.Now
    '        ListaTotales.Add(objTotalesDet)
    '    Next

    '    Return ListaTotales
    'End Function

    Public Function RecuperaCuentaVenta(cCuenta As String, strTipoExistencia As String) As String
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim strCuenta As String = Nothing

        Select Case strTipoExistencia
            Case "01"
                With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                    strCuenta = .cuentaVenta
                End With
        End Select
        Return strCuenta
    End Function

    Sub AsientoVenta()
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento.idAsiento = 0
        nAsiento.idDocumento = lblIdDoc.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = lblIdDoc.Text
        nAsiento.fechaProceso = txtFechaPago.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "ASIENTO x VENTA PAGADA-TICKET"
        nAsiento.importeMN = lblImporte.Text
        nAsiento.importeME = lblImporteme.Text
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = "Jiuni"
        ListaAsientonTransito.Add(nAsiento)
        nAsiento.movimiento.Add(AS_CAJA(CDec(lblImporte.Text), CDec(lblImporteme.Text)))
        For Each i As ListViewItem In lsvDetalle.Items
            Select Case lblTipoDoc.Text
                Case "03", "02"
                    MV_Item_Transito(i.SubItems(9).Text, i.SubItems(2).Text, CDec(i.SubItems(13).Text), CDec(i.SubItems(14).Text), i.SubItems(12).Text)
                Case Else

                    Select Case i.SubItems(0).Text
                        Case "1"
                            MV_Item_Transito(i.SubItems(9).Text, i.SubItems(2).Text, CDec(i.SubItems(13).Text), CDec(i.SubItems(14).Text), i.SubItems(12).Text)
                        Case Else
                            MV_Item_Transito(i.SubItems(9).Text, i.SubItems(2).Text, CDec(i.SubItems(13).Text), CDec(i.SubItems(14).Text), i.SubItems(12).Text)

                    End Select
            End Select


            nMovimiento = New movimiento
            nMovimiento.cuenta = RecuperaCuentaVenta(i.SubItems(9).Text, i.SubItems(12).Text)
            nMovimiento.descripcion = i.SubItems(2).Text
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            'Select Case lblTipoDoc.Text
            '    Case "03", "02"
            '        nMovimiento.monto = CDec(i.SubItems(5).Text)
            '        nMovimiento.montoUSD = CDec(i.SubItems(6).Text)
            '    Case Else
            Select Case i.SubItems(0).Text
                Case "1"
                    nMovimiento.monto = CDec(i.SubItems(7).Text)
                    nMovimiento.montoUSD = CDec(i.SubItems(8).Text)
                Case Else
                    nMovimiento.monto = CDec(i.SubItems(5).Text)
                    nMovimiento.montoUSD = CDec(i.SubItems(6).Text)
                    'End Select
            End Select
            'nMovimiento.monto = CDec(i.SubItems(13).Text)
            'nMovimiento.montoUSD = CDec(i.SubItems(14).Text)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = "Jiuni"

            nAsiento.movimiento.Add(nMovimiento)


        Next
        nAsiento.movimiento.Add(AS_IGV(CDec(lbligv.Text), CDec(lbligvme.Text)))
        '   Return nAsiento
    End Sub

    Public Sub ConfirmarVenta()

        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)

        Dim nDocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim nDocumentoVenta As New documentoventaAbarrotes
        Dim nDocumentoVentaDetalle As New documentoventaAbarrotesDet
        Dim ListaDocumentoVentaDetalle As New List(Of documentoventaAbarrotesDet)
        Try
            'INGRESANDO LA VENTA => CAJA
            DocCaja = ComprobanteCaja()

            With ndocumento
                .idDocumento = lblIdDoc.Text
            End With

            With cajaUsarioBE
                .idcajaUsuario = GFichaUsuarios.IdCajaUsuario
                .ingresoAdicMN = CDec(lblImporte.Text)
                .ingresoAdicME = CDec(lblImporteme.Text)
            End With

            cajaUsariodetalleBE = New cajaUsuariodetalle
            cajaUsariodetalleBE.idcajaUsuario = GFichaUsuarios.IdCajaUsuario
            cajaUsariodetalleBE.importeMN = CDec(lblImporte.Text)
            cajaUsariodetalleBE.importeME = CDec(lblImporteme.Text)
            cajaUsariodetalleListaBE.Add(cajaUsariodetalleBE)

            cajaUsarioBE.cajaUsuariodetalle = cajaUsariodetalleListaBE

            With nDocumentoVenta
                .idDocumento = lblIdDoc.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoDocumento = lblTipoDoc.Text
                .serie = lblSerieDoc.Text
                .fechaConfirmacion = txtFechaPago.Value
                '  .NumeroDoc = txtNumeroDoc.Text
                .idCliente = txtIdCliente.Text
                .estadoCobro = TIPO_VENTA.PAGO.COBRADO   ' DOCUMENTO COBRADO
                .establecimientoCobro = txtIDEstablecimientoCaja.Text
                .entidadFinanciera = txtIdCaja.Text
                .glosa = txtGlosa.Text
            End With
            ndocumento.documentoventaAbarrotes = nDocumentoVenta

            With nDocumentoVentaDetalle
                .idDocumento = lblIdDoc.Text
                .entregado = "S"
            End With
            ListaDocumentoVentaDetalle.Add(nDocumentoVentaDetalle)
            ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDocumentoVentaDetalle
            '*********************************** ZONA ASIENTO* *************************************************
            AsientoVenta()


            ndocumento.asiento = ListaAsientonTransito

            nDocumentoVentaSA.ConfirmarVentaTicket(ndocumento, DocCaja, ListaTotales, cajaUsarioBE)
            lblEstado.Text = "Venta confirmada correctamente!"
            lblEstado.Image = My.Resources.ok4
            'If objService.ConfirmarVtaAbarrote(objDocCaja, objDocumentoEO, objDocumentoVentaEO, objAsiento, ObjAsientoAlmacen) Then
            '    ' verReporte()
            '    MsgBox("Confirmación completada correctamente", MsgBoxStyle.Information, "Done!")
            '    Dispose()
            'Else
            '    MsgBox("EL registro ya fue cancelado en otra ubicación!", MsgBoxStyle.Information, "Aviso del Sistema!")
            'End If
        Catch ex As Exception
            lblEstado.Text = "Error al Grabar datos" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Public Sub ObtenerEFPrdeterminada()
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        If IsNothing(GFichaUsuarios.NombrePersona) Then
            lblEstado.Text = "Debe confgiurar una cuenta financiera o caja"
            Timer1.Enabled = True
            TiempoEjecutar(5)

            With frmFichaUsuarioCaja
                ModuloAppx = ModuloSistema.CAJA
                .lblNivel.Text = "Caja"
                .lblEstadoCaja.Visible = True
                '.GroupBox1.Visible = True
                '.GroupBox2.Visible = True
                '.GroupBox4.Visible = True
                '.cboMoneda.Visible = True
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            With efSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
                txtIdCaja.Text = .idestado
                txtCaja.Text = .descripcion
                lblCuenta.Text = .cuenta
                If .codigo = "1" Then
                    rbNac.Checked = True
                Else
                    rbExtra.Checked = True
                End If
                If .tipo = "BC" Then
                    rbBanco.Checked = True
                Else
                    rbEfectivo.Checked = True
                End If
                With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
                    txtIDEstablecimientoCaja.Text = .idCentroCosto
                    txtEstablecimientoCaja.Text = .nombre
                End With
            End With
        End If

    

        'ef = efSA.ObtenerEstadosFinancierosPredeterminado(GEstableciento.IdEstablecimiento)
        'With ef
        '    txtIdCaja.Text = .idestado
        '    txtCaja.Text = .descripcion
        '    lblCuenta.Text = .cuenta
        '    If .codigo = "1" Then
        '        rbNac.Checked = True
        '    Else
        '        rbExtra.Checked = True
        '    End If
        '    If .tipo = "BC" Then
        '        rbBanco.Checked = True
        '    Else
        '        rbEfectivo.Checked = True
        '    End If
        '    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
        '        txtIDEstablecimientoCaja.Text = .idCentroCosto
        '        txtEstablecimientoCaja.Text = .nombre
        '    End With
        'End With
    End Sub

    Public Sub ObtenerDetallePedido(ByVal intIdDocumento As Integer)
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA

        Try
            lsvDetalle.Columns.Clear()
            lsvDetalle.Items.Clear()
            lsvDetalle.Columns.Add("Destino", 0) '0
            lsvDetalle.Columns.Add("Id Item", 0) '01
            lsvDetalle.Columns.Add("Cant", 80, HorizontalAlignment.Right) '3
            lsvDetalle.Columns.Add("Producto", 500) '02
            lsvDetalle.Columns.Add("Presentación", 0, HorizontalAlignment.Center) '03
            lsvDetalle.Columns.Add("U.M", 0, HorizontalAlignment.Center) '04
            lsvDetalle.Columns.Add("Importe MN", 150, HorizontalAlignment.Right) '05
            lsvDetalle.Columns.Add("Importe ME", 0, HorizontalAlignment.Right) '06
            lsvDetalle.Columns.Add("Base MN", 0, HorizontalAlignment.Right) '07
            lsvDetalle.Columns.Add("Base ME", 0, HorizontalAlignment.Right) '08
            lsvDetalle.Columns.Add("Cuenta", 0, HorizontalAlignment.Right) '09
            lsvDetalle.Columns.Add("Almacén", 0, HorizontalAlignment.Right) '10
            lsvDetalle.Columns.Add("Establecimiento", 0, HorizontalAlignment.Right) '11
            lsvDetalle.Columns.Add("T/EX", 0, HorizontalAlignment.Right) '12

            lsvDetalle.Columns.Add("Costo MN", 0, HorizontalAlignment.Right) '13
            lsvDetalle.Columns.Add("Costo ME", 0, HorizontalAlignment.Right) '14
            lsvDetalle.Columns.Add("Secuencia", 0, HorizontalAlignment.Right) '15

            For Each i As documentoventaAbarrotesDet In ventaDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
                Dim n As New ListViewItem(i.destino)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(CInt(i.monto1))
                n.SubItems.Add(i.nombreItem)
                n.SubItems.Add(i.monto2)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(FormatNumber(i.importeMN, 2))
                n.SubItems.Add(FormatNumber(i.importeME, 2))
                n.SubItems.Add(FormatNumber(i.montokardex, 2))
                n.SubItems.Add(FormatNumber(i.montokardexUS, 2))
                n.SubItems.Add(i.cuentaOrigen)
                n.SubItems.Add(i.idAlmacenOrigen)
                n.SubItems.Add(i.establecimientoOrigen)
                n.SubItems.Add(i.tipoExistencia)

                n.SubItems.Add(i.salidaCostoMN)
                n.SubItems.Add(i.salidaCostoME)
                n.SubItems.Add(i.secuencia)

                n.Checked = True
                lsvDetalle.Items.Add(n)
            Next
        Catch ex As Exception
            MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub

    Public Sub ObtenerVentaPorCodigo(strNumDoc As String)
        Dim docuemntoventaSA As New documentoVentaAbarrotesSA
        Dim docuemntoventa As New documentoventaAbarrotes
        Dim strxSerie As String = Nothing
        Try
            strxSerie = String.Format("{0:00000}", txtSerie.Text)
            docuemntoventa = docuemntoventaSA.GetObtenerVentaPorNumero(GEstableciento.IdEstablecimiento, lblPerido.Text, TIPO_VENTA.VENTA_AL_TICKET, IIf(rbBoleta.Checked = True, "03", "01"), strxSerie, strNumDoc)
            If Not IsNothing(docuemntoventa) Then
                With docuemntoventa
                    lblIdDoc.Text = .idDocumento
                    lblTipoCambio.Text = .tipoCambio
                    lblNombreCliente.Text = .nombrePedido
                    lblTipoDoc.Text = .tipoDocumento
                    lblNumDoc.Text = .numeroDoc
                    lblSerieDoc.Text = .serie
                    lblImporte.Text = FormatNumber(.ImporteNacional, 2)
                    lbligv.Text = FormatNumber(.igv01, 2)
                    lblImporteme.Text = FormatNumber(.ImporteExtranjero, 2)
                    lbligvme.Text = FormatNumber(.igv01us, 2)
                    txtGlosa.Text = .glosa

                    If .tipoDocumento = "03" Then
                        rbBoleta.Checked = True
                    Else
                        rbFactura.Checked = True
                    End If

                End With
                ObtenerDetallePedido(docuemntoventa.idDocumento)
                lblEstado.Text = "Número de venta encontrada: " & docuemntoventa.nombrePedido
                lblEstado.Image = My.Resources.ok4
            Else
                lblNombreCliente.Text = String.Empty
                lblTipoDoc.Text = String.Empty
                lblNumDoc.Text = String.Empty
                lblSerieDoc.Text = String.Empty
                lblImporte.Text = String.Empty
                lbligv.Text = String.Empty
                lblImporteme.Text = String.Empty
                lbligvme.Text = String.Empty
                lblTipoCambio.Text = String.Empty
                txtGlosa.Text = String.Empty
                lblEstado.Text = "Código no encontrado!"
                lblEstado.Image = My.Resources.warning2
                txtNumFiltro.Focus()
                lsvDetalle.Items.Clear()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub
#End Region

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        ConfirmarVenta()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtNumFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If txtSerie.Text.Trim.Length > 0 Then
                Aplica()
                If txtNumFiltro.Text.Trim.Length > 0 Then
                    ObtenerVentaPorCodigo(txtNumFiltro.Text.Trim)
                Else
                    lblEstado.Text = "Debe ingresar un codigo de venta válido!"
                    lblEstado.Image = My.Resources.warning2
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                End If
            Else
                lblEstado.Text = "Ingrese el número de serie de venta!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
            End If
        End If
    End Sub

    Private Sub txtNumFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumFiltro.TextChanged
        If txtNumFiltro.Text = Sep Then
            'si el separador decimal es tecleado directamente
            txtNumFiltro.Text = "0" & Sep
            txtNumFiltro.SelectionStart = Len(txtNumFiltro.Text)
        ElseIf Not IsNumeric(Trim(txtNumFiltro.Text)) Then
            Beep()
            If Len(txtNumFiltro.Text) < 1 Then
                txtNumFiltro.Text = ""
            Else
                txtNumFiltro.Text = Microsoft.VisualBasic.Left(txtNumFiltro.Text, Len(txtNumFiltro.Text) - 1)
                txtNumFiltro.SelectionStart = Len(txtNumFiltro.Text)
            End If
        End If

    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Select Case cboPeriodo.Text
            Case "ENERO"
                lblPerido.Text = "01" & "/2014"
            Case "FEBRERO"
                lblPerido.Text = "02" & "/2014"
            Case "MARZO"
                lblPerido.Text = "03" & "/2014"
            Case "ABRIL"
                lblPerido.Text = "04" & "/2014"
            Case "MAYO"
                lblPerido.Text = "05" & "/2014"
            Case "JUNIO"
                lblPerido.Text = "06" & "/2014"
            Case "JULIO"
                lblPerido.Text = "07" & "/2014"
            Case "AGOSTO"
                lblPerido.Text = "08" & "/2014"
            Case "SETIEMBRE"
                lblPerido.Text = "09" & "/2014"
            Case "OCTUBRE"
                lblPerido.Text = "10" & "/2014"
            Case "NOVIEMBRE"
                lblPerido.Text = "11" & "/2014"
            Case "DICIEMBRE"
                lblPerido.Text = "12" & "/2014"
        End Select
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim p As Point = e.Location
        p.Offset(lblPerido.Bounds.Location)
        '   ContextMenuStrip1.Show(ToolStrip4.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub

    Private Sub frmPagoTicket_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmPagoTicket_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub
    Sub Aplica()
        Dim DT As String
        'Para adaptar a la configuracion del PC huesped.
        DT = Replace(txtNumFiltro.Text, ".", Sep)
        DT = Replace(DT, ",", Sep)
        Label1.Text = CDbl(DT)
        On Error Resume Next
        txtNumFiltro.SelectionStart = 0
        txtNumFiltro.SelectionLength = Len(txtNumFiltro.Text)
        txtNumFiltro.Focus()
    End Sub

    Private Sub btnProforma_Click(sender As System.Object, e As System.EventArgs)
        If lsvDetalle.Items.Count > 0 Then
            ' Vista preliminar
            conteo = 0
            llenarDatos()
            imprimir(False)
        End If
    End Sub

    Sub llenarDatos()

        PrintPreviewDialogTicket.Document = PrintTikect

        'PrintPreviewDialog1.ShowDialog()

        ' La fuente a usar en la impresión
        prtFont = New System.Drawing.Font("Courier New", 11)
        '
        ' La configuración actual de la impresora predeterminada
        prtSettings = New PrinterSettings

    End Sub

    Private Sub imprimir(ByVal esPreview As Boolean)

        ' imprimir o mostrar el PrintPreview
        '
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If
        '
        'If chkSelAntes.Checked Then
        If seleccionarImpresora() = False Then Return
        'End If
        '
        If prtDoc Is Nothing Then
            prtDoc = New PrintDocument
            AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage

        End If
        '
        ' resetear la línea actual
        lineaActual = 0
        '
        ' la configuración a usar en la impresión
        prtDoc.PrinterSettings = prtSettings
        '
        If esPreview Then
            Dim prtPrev As New PrintPreviewDialog
            prtPrev.PrintPreviewControl.Zoom = 1.0
            prtPrev.Document = prtDoc
            prtPrev.Text = "Previsualizar datos de Ticket" & Título
            DirectCast(prtPrev, Form).WindowState = FormWindowState.Maximized
            prtPrev.ShowDialog()
        Else
            prtDoc.Print()
        End If
    End Sub

    Private Function seleccionarImpresora() As Boolean
        Dim prtDialog As New PrintDialog
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If

        'SELECCION DE IMPRESORA
        'With prtDialog
        '    .AllowPrintToFile = False
        '    .AllowSelection = False
        '    .AllowSomePages = False
        '    .PrintToFile = False
        '    .ShowHelp = False
        '    .ShowNetwork = True

        '    .PrinterSettings = prtSettings

        '    If .ShowDialog() = DialogResult.OK Then
        '        prtSettings = .PrinterSettings
        '    Else
        '        Return False
        '    End If

        'End With
        Return (True)
    End Function

    Public Sub prt_PrintPage(ByVal sender As Object, _
                             ByVal e As PrintPageEventArgs)
        ' Este evento se produce cada vez que se va a imprimir una página
        Dim pageWidth As Integer
        Dim lineHeight As Single
        Dim yPos As Single = e.MarginBounds.Top
        Dim leftMargin As Single = e.MarginBounds.Left

        Dim printFont As System.Drawing.Font

        ' Asignar el tipo de letra
        printFont = prtFont
        lineHeight = printFont.GetHeight(e.Graphics)

        If (lineaActual < 37 And lineaActual = 0) Then

            '--------------------------------------------- Encabezado del reporte -------------------------------------------
            Dim NEmpresa As String = Gempresas.NomEmpresa & vbLf
            'separacion del primer titulo con la segunda linea
            Dim fontNEmpresa As New System.Drawing.Font("Tahoma", 9, FontStyle.Bold)
            e.Graphics.DrawString(NEmpresa, fontNEmpresa, _
                                   Brushes.Black, leftMargin - 80, yPos - 100)

            Dim EmpresaRUC As String = "RUC  " & Gempresas.IdEmpresaRuc & vbLf
            Dim fontNEmpresaRUC As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            e.Graphics.DrawString(EmpresaRUC, fontNEmpresaRUC, _
                                   Brushes.Black, leftMargin - 35, yPos - 84)

            Dim NEstablecimiento As String = GEstableciento.NombreEstablecimiento & vbLf
            'separacion del primer titulo con la segunda linea
            Dim fontNEstablecimiento As New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            e.Graphics.DrawString(NEstablecimiento, fontNEstablecimiento, _
                                   Brushes.Black, leftMargin - 40, yPos - 70)

            Dim NLinea As String = "----------------------------------------------------------" & vbLf
            'separacion del primer titulo con la segunda linea
            Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            e.Graphics.DrawString(NLinea, fontNLinea, _
                                   Brushes.Black, leftMargin - 100, yPos - 60)

            '-----------------------------------------------------------------------------------------------------------------
            '------------------------------------------Segundo Encabezado datos del cliente -----------------------------------
            ' titulo 2 ubicacion de la hoja
            '10 masrgen a la izquierda
            ' ypos ubicacion hacia abajo del titulo primero
            Dim NCliente As String = vbCrLf & vbCrLf & "Cliente: " & lblNombreCliente.Text & _
                vbCrLf & "ID: " & lblIdDoc.Text & "                         Nro Doc: " & lblNumDoc.Text & _
                vbCrLf & "RUC: " & txtNumFiltro.Text & _
                vbCrLf & "Razón Social: " & txtCliente.Text & _
                vbCrLf & "Código máquina registradora: " & _
                vbCrLf & "Caja: " & txtCaja.Text & _
                vbCrLf & "Fecha: " & Date.Now & _
                vbCrLf & "------------------------------------------------------------"

            Dim fontNCliente As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            e.Graphics.DrawString(NCliente, fontNCliente, Brushes.Black, leftMargin - 100, yPos - 77)

            'margen a la derecha de toda la lista
            X1 = PrintTikect.DefaultPageSettings.Margins.Left + 85
            With PrintTikect.DefaultPageSettings
                pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right)
                If .Landscape Then
                    pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
                End If
            End With
            'tamaño de la primera celda cantidad
            X2 = X1 + 17
            'tamaño de la segunda celda
            X3 = CInt(X2 + pageWidth * 3)

            X4 = X1 + 5
            X5 = X1 + 20

            W1 = (X2 - X1)
            W2 = (X3 - X2)
            W4 = (X3 - X2)
            W5 = (X3 - X2)
            W3 = pageWidth - W1 - W2

            'If itm < lsvDetalle.Items.Count Then
            'ubicacion para abajo
            Y = PrintTikect.DefaultPageSettings.Margins.Top + 50
            Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            ' Draw the column headers at the top of the page
            'ubicacion de las columnas para la izquierda
            e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
            e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
            e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
            e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
            ' Advance the Y coordinate for the first text line on the printout
            Y = Y + 20
            'End If
            Dim ii As Integer = 0
            Dim ultimaFila As Integer = 0
            For Each i As ListViewItem In lsvDetalle.Items

                ' extract each item's text into the str variable
                Dim str As String
                str = (CInt(i.SubItems(2).Text))

                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

                str = i.SubItems(3).Text
                Dim R As New RectangleF(X2 - 175, Y, W2, 80)
                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

                Dim lines, cols As Integer
                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
                Dim subitm As Integer, Yc As Integer
                Yc = Y

                str = Math.Round(CDec(i.SubItems(6).Text / i.SubItems(2).Text), 2)
                Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R2)

                str = Math.Round(CDec(i.SubItems(6).Text), 2)
                Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R3)

                Dim conteo As Integer

                For subitm = 1 To 1
                    str = i.SubItems(subitm).Text
                    'conteo = 0
                    conteo = (str.Length / 2)
                    Dim strformat As New StringFormat
                    strformat.Trimming = StringTrimming.EllipsisCharacter
                    Yc = Yc + fontNCabecera.Height + 2
                Next
                Y = Y + lines * fontNCabecera.Height + (conteo + 2)
                Y = Math.Max(Y, Yc)

                With PrintTikect.DefaultPageSettings
                    If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or _
                     (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
                        e.HasMorePages = True
                        ii += 1
                        Exit Sub
                    Else
                        ii += 1
                        e.HasMorePages = False
                    End If
                End With

            Next

            Dim NIgv As String = vbCrLf & vbCrLf & "IGV:   " & lbligv.Text
            Dim fontNIgv As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 75, Y - 20)

            Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
            Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

            Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total a Pagar S/: " & lblImporte.Text
            Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 32, Y)

            Dim NTotalImpPagar As String = vbCrLf & vbCrLf & "Importe Pagado S/: " & lblImporte.Text
            Dim fontNTotalImpPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NTotalImpPagar, fontNTotalImpPagar, Brushes.Black, leftMargin + 20, Y + 10)

            Dim NTotalVuelto As String = vbCrLf & vbCrLf & "Vuelto S/: " & lblImporte.Text
            Dim fontNNTotalVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NTotalVuelto, fontNNTotalVuelto, Brushes.Black, leftMargin + 62, Y + 20)

            Dim NLinea2 As String = "----------------------------------------------------------------"
            Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)

            Dim NVEndedor As String = vbCrLf & vbCrLf & "Vendedor: " & "Maykol sanchez coris"
            Dim fontNVEndedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NVEndedor, fontNVEndedor, Brushes.Black, leftMargin - 90, Y + 38)

            Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
            vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
            Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
            e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

            e.HasMorePages = False

        End If

    End Sub

    Private Sub btnVistaPrevia_Click(sender As System.Object, e As System.EventArgs)
        If lsvDetalle.Items.Count > 0 Then
            ' Vista preliminar
            conteo = 0
            llenarDatos()
            imprimir(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)
        If lsvDetalle.Items.Count > 0 Then
            ' Vista preliminar
            llenarDatos()
            imprimir(True)
        End If
    End Sub

    Private Sub menbtnSave_Click(sender As System.Object, e As System.EventArgs)
        If lsvDetalle.Items.Count > 0 Then
            ' Vista preliminar
            llenarDatos()
            imprimir(False)
        End If
    End Sub

    Private Sub ToolStripButton4_Click_1(sender As System.Object, e As System.EventArgs)
        If lsvDetalle.Items.Count > 0 Then
            ' Vista preliminar
            conteo = 0
            llenarDatos()
            imprimir(True)
        End If
    End Sub

    Private Sub menbtnSave_Click_1(sender As System.Object, e As System.EventArgs)
        If lsvDetalle.Items.Count > 0 Then
            ' Vista preliminar
            conteo = 0
            llenarDatos()
            imprimir(False)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If lsvDetalle.Items.Count > 0 Then
            llenarDatos()
            imprimir(True)
        End If
    End Sub

    Private Sub menbtnSave_Click_2(sender As System.Object, e As System.EventArgs) Handles menbtnSave.Click
        If lsvDetalle.Items.Count > 0 Then
            llenarDatos()
            imprimir(False)
        End If
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
     
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs)
      
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtSerie_KeyDown1(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumFiltro.Select()
        End If
    End Sub

    Private Sub txtSerie_LostFocus1(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        Try
            Select Case "99"
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
                        If IsNumeric(txtSerie.Text) Then
                            txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerie.Clear()
                            txtSerie.Focus()
                            txtSerie.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
                        If IsNumeric(txtSerie.Text) Then
                            '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerie.Clear()
                            txtSerie.Focus()
                            txtSerie.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"

                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select

        Catch ex As Exception
            MsgBox("Formato Incorrecto " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub txtSerie_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub
End Class