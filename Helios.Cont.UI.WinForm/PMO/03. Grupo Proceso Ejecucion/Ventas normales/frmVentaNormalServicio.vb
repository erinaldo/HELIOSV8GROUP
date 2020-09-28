Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid


Public Class frmVentaNormalServicio
    Inherits frmMaster

    Public Property ManipulacionEstado() As String
    Public Property fecha() As DateTime
    Public Property ListaAsientonTransito As New List(Of asiento)

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




#Region "PROVEEDOR"
    Public Sub InsertProveedor()
        Dim objCliente As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            objCliente.idEmpresa = Gempresas.IdEmpresaRuc
            objCliente.tipoEntidad = TIPO_ENTIDAD.CLIENTE

            If btnRuc.Checked = True Then
                objCliente.tipoDoc = "6"
            ElseIf btnDni.Checked = True Then
                objCliente.tipoDoc = "1"
            ElseIf btnPassport.Checked = True Then
                objCliente.tipoDoc = "7"
            ElseIf btnCarnetEx.Checked = True Then
                objCliente.tipoDoc = "4"
            End If
            objCliente.nrodoc = txtDocProveedor.Text.Trim

            If rbNatural.Checked = True Then
                objCliente.appat = txtApePat.Text.Trim
                objCliente.nombre1 = txtNomProv.Text.Trim
                objCliente.nombreCompleto = objCliente.appat & ", " & objCliente.nombre1
                objCliente.tipoPersona = "N"
            ElseIf rbJuridico.Checked = True Then
                objCliente.nombre = txtNomProv.Text.Trim
                objCliente.nombreCompleto = txtNomProv.Text.Trim
                objCliente.tipoPersona = "J"
            End If
            objCliente.cuentaAsiento = "1213"
            objCliente.estado = "A"
            objCliente.usuarioModificacion = "NN"
            objCliente.fechaModificacion = DateTime.Now

            Dim codx As Integer = entidadSA.GrabarEntidad(objCliente)
            'lblEstado.Text = "Entidad registrada:" & vbCrLf & "Tipo: " & objCliente.tipoEntidad & vbCrLf & "Nombre: " & objCliente.nombreCompleto
            'lblEstado.Image = My.Resources.ok4

            Dim n As New ListViewItem(codx)
            n.SubItems.Add(objCliente.nombreCompleto)
            n.SubItems.Add(objCliente.cuentaAsiento)
            n.SubItems.Add(objCliente.nrodoc)
            lsvProveedor.Items.Add(n)

            txtProveedor.Tag = codx
            txtProveedor.Text = objCliente.nombreCompleto
            txtRuc.Text = objCliente.nrodoc
            txtCuenta.Text = objCliente.cuentaAsiento
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "Variables DetalleCompra"
    Public Property nudBase4 As Decimal = 0
    Public Property nudBase1 As Decimal = 0
    Public Property nudBase2 As Decimal = 0
    Public Property nudBase3 As Decimal = 0

    Public Property nudMontoIgv1 As Decimal = 0
    Public Property nudMontoIgv2 As Decimal = 0
    Public Property nudMontoIgv3 As Decimal = 0

    Public Property nudBaseus4 As Decimal = 0
    Public Property nudBaseus1 As Decimal = 0
    Public Property nudBaseus2 As Decimal = 0
    Public Property nudBaseus3 As Decimal = 0

    Public Property nudMontoIgvus1 As Decimal = 0
    Public Property nudMontoIgvus2 As Decimal = 0
    Public Property nudMontoIgvus3 As Decimal = 0

    Public Property nudIsc1 As Decimal = 0
    Public Property nudIsc2 As Decimal = 0
    Public Property nudIsc3 As Decimal = 0
    Public Property nudIscus1 As Decimal = 0
    Public Property nudIscus2 As Decimal = 0
    Public Property nudIscus3 As Decimal = 0

    Public Property nudOtrosTributosus1 As Decimal = 0
    Public Property nudOtrosTributosus2 As Decimal = 0
    Public Property nudOtrosTributosus3 As Decimal = 0
    Public Property nudOtrosTributosus4 As Decimal = 0

    Public Property nudOtrosTributos1 As Decimal = 0
    Public Property nudOtrosTributos2 As Decimal = 0
    Public Property nudOtrosTributos3 As Decimal = 0
    Public Property nudOtrosTributos4 As Decimal = 0

    Public Property txtIdComprobanteCaja As Integer
    Public Property txtComprobanteCaja As String
    Public Property txtNumCaja As String
    Public Property txtIdEstablecimientoCaja As Integer
    Public Property txtEstablecimientoCaja As String
    Public Property txtIdCaja As Integer
    Public Property txtCaja As String
    Public Property txtCuentaEF As String

    '   Public Property GlosaCompra As String = Nothing
#End Region



    Private Function GlosaVenta() As String
        Return String.Concat("Por ventas normales de servicio", Space(1), "según/ ", Space(1), IIf(rbBoleta.Checked = True, "03", "01"), Space(1), "Nro.", Space(1), txtSerie.Text & "-" & txtNumero.Text)
    End Function



    Public Sub totales_xx()
        Dim i As Integer

        Dim bi1, bi2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
        Dim bi1me, bi2me As Decimal 'tus3, tus4 
        Dim totalIgv1 As Decimal = 0
        Dim totalIgv1_ME As Decimal = 0
        Dim totalIgv2 As Decimal = 0
        Dim totalIgv2_ME As Decimal = 0


        Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
        For i = 0 To dgvNuevoDoc.Rows.Count - 1
            'total += carrito.Rows(i)(5)
            If dgvNuevoDoc.Rows(i).Cells(22).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                If Not dgvNuevoDoc.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
                    If dgvNuevoDoc.Rows(i).Cells(1).Value() = "1" Then

                        bi1 += dgvNuevoDoc.Rows(i).Cells(10).Value() ' total base 01 soles
                        bi1me += dgvNuevoDoc.Rows(i).Cells(12).Value() ' total base 01 dolares
                        totalIgv1 += dgvNuevoDoc.Rows(i).Cells(17).Value()
                        totalIgv1_ME += dgvNuevoDoc.Rows(i).Cells(20).Value()

                    ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "2" Then

                        bi2 += dgvNuevoDoc.Rows(i).Cells(10).Value()
                        bi2me += dgvNuevoDoc.Rows(i).Cells(12).Value() ' total base 01
                        totalIgv2 += dgvNuevoDoc.Rows(i).Cells(17).Value()
                        totalIgv2_ME += dgvNuevoDoc.Rows(i).Cells(20).Value()

                    End If
                End If
            End If

        Next
        nudBase1 = bi1.ToString("N2")
        nudBaseus1 = bi1me.ToString("N2")
        nudBase2 = bi2.ToString("N2")
        nudBaseus2 = bi2me.ToString("N2")

        nudMontoIgv1 = totalIgv1.ToString("N2")
        nudMontoIgvus1 = totalIgv1_ME.ToString("N2")
        nudMontoIgv2 = totalIgv2.ToString("N2")
        nudMontoIgvus2 = totalIgv2_ME.ToString("N2")

    End Sub

    Function ComprobanteCaja() As documento
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaCajaDetalle As New List(Of documentoCajaDetalle)

        nDocumentoCaja.idDocumento = lblIdDocumento.Text
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = fecha
        nDocumentoCaja.nroDoc = txtSerie.Text & "-" & txtNumero.Text
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "01"
        nDocumentoCaja.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now


        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = fecha
        objCaja.fechaCobro = fecha
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.TipoDocumentoPago = "109"
        objCaja.codigoLibro = "01"
        objCaja.periodo = PeriodoGeneral
        objCaja.tipoDocPago = "109"
        objCaja.NumeroDocumento = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtSerieComp.Text & "-" & txtNumeroComp.Text)
        objCaja.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2") ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")

        objCaja.tipoCambio = txtTipoCambio.Value
        objCaja.montoSoles = CDec(txtTotalPedidomn.Text)
        objCaja.montoUsd = CDec(txtTotalPedidome.Text)

        objCaja.glosa = GlosaVenta()
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = GFichaUsuarios.IdCajaDestino
        objCaja.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.DetalleItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                objCajaDetalle.fecha = fecha
                objCajaDetalle.montoSoles = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
                objCajaDetalle.montoUsd = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value())
                objCajaDetalle.entregado = "SI"
                objCajaDetalle.documentoAfectado = lblIdDocumento.Text
                objCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
                objCajaDetalle.fechaModificacion = DateTime.Now
                ListaCajaDetalle.Add(objCajaDetalle)
            End If
        Next

        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaCajaDetalle

        Return nDocumentoCaja
    End Function


    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO


        nMovimiento = New movimiento
        nMovimiento.cuenta = "70"

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

    Public Function AS_CLIENTE(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = txtCuenta.Text,
              .descripcion = txtProveedor.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

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


    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim DocumentoGuia As New documentoguiaDetalle
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim alm As New almacenSA
        Try

            With objDoc.UbicarDocumento(intIdDocumento)
                fecha = .fechaProceso
                txtFechaComprobante.Value = .fechaProceso

            End With

            DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            If Not IsNothing(DocumentoGuia) Then
                With DocumentoGuia
                    txtSerieGuia.Text = .Serie
                    txtNumeroGuia.Text = .Numero
                End With
            End If


            With objDocCompra.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)

                Select Case .tipoDocumento
                    Case "01"
                        rbFactura.Checked = True
                    Case Else
                        rbBoleta.Checked = True
                End Select

                lblIdDocumento.Text = .idDocumento
                lblPerido.Text = .fechaPeriodo
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDocNormal

                'DATOS DEL CLIENTE
                If Not IsNothing(.idCliente) Then
                    nEntidad = objEntidad.UbicarEntidadPorID(.idCliente).First()
                    txtRuc.Text = nEntidad.nrodoc
                    txtCuenta.Text = nEntidad.cuentaAsiento
                    txtProveedor.ValueMember = nEntidad.idEntidad
                    txtProveedor.Text = nEntidad.nombreCompleto
                End If
                '_::::::::::::::::::        :::::::::::::::::::
                txtTipoCambio.Value = .tipoCambio
                txtGlosa.Text = .glosa
            End With
            'DETALLE DE LA COMPRA
            dgvNuevoDoc.Rows.Clear()

            For Each i In objDocCompraDet.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)

                If i.destino = "1" Then
                    VALUEDES = "1"
                ElseIf i.destino.Trim = "2" Then
                    VALUEDES = "2"
                ElseIf i.destino.Trim = "3" Then
                    VALUEDES = "3"
                ElseIf i.destino.Trim = "4" Then
                    VALUEDES = "4"
                End If


                dgvNuevoDoc.Rows.Add(i.secuencia,
                                    i.destino,
                                    i.idItem,
                                    i.nombreItem,
                                    i.unidad1,
                                    i.monto1,
                                   i.importeMNK, "1",
                                    i.precioUnitario,
                                    i.precioUnitarioUS,
                                    i.montokardex,
                                    i.importeMN,
                                    i.montokardexUS,
                                    i.importeME,
                                    i.descuentoMN,
                                    i.descuentoME,
                                    i.montoIsc,
                                    i.montoIgv,
                                    i.otrosTributos,
                                    i.montoIscUS,
                                    i.montoIgvUS,
                                    i.otrosTributosUS, Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE,
                                    i.tipoExistencia,
                                    i.idAlmacenOrigen,
                                    i.cuentaOrigen,
                                    i.establecimientoOrigen,
                                    i.preEvento,
                                    i.importeMEK, i.unidad2,
                                    i.fechaVcto,
                                    i.monto2,
                                    i.tipoVenta,
                                    i.salidaCostoMN,
                                    i.salidaCostoME)

            Next

            'totales_xx()
            TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub




    Sub AsientoVenta()
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento.idAsiento = 0
        nAsiento.idDocumento = lblIdDocumento.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = lblIdDocumento.Text
        nAsiento.fechaProceso = fecha
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "ASIENTO x VENTA PAGADA-TICKET"
        nAsiento.importeMN = txtTotalPedidomn.Text
        nAsiento.importeME = txtTotalPedidome.Text
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = "Jiuni"
        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_CLIENTE(CDec(txtTotalPedidomn.Text), CDec(txtTotalPedidome.Text)))
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                Dim td As String = IIf(rbBoleta.Checked = True, "03", "01")
                Select Case td

                    Case "03", "02"
                        MV_Item_Transito(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(3).Value, CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value), CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value), dgvNuevoDoc.Rows(i.Index).Cells(23).Value)
                    Case Else

                        Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value
                            Case "1"
                                MV_Item_Transito(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(3).Value, CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value), CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value), dgvNuevoDoc.Rows(i.Index).Cells(23).Value)
                            Case Else
                                MV_Item_Transito(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(3).Value, CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value), CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value), dgvNuevoDoc.Rows(i.Index).Cells(23).Value)

                        End Select
                End Select


                nMovimiento = New movimiento
                nMovimiento.cuenta = RecuperaCuentaVenta(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(23).Value)
                nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER

                Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value
                    Case "1"
                        nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value)
                        nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value)
                    Case Else
                        nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value)
                        nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value)
                        'End Select
                End Select

                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"


                nAsiento.movimiento.Add(nMovimiento)
            End If




        Next
        nAsiento.movimiento.Add(AS_IGV(CDec(txtMontoIGVmn.Text), CDec(txtMontoIGVme.Text)))

    End Sub

    Public Sub ObtenerListaControlesLoad()
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0



    End Sub


    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub




    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = lblIdDocumento.Text
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .periodo = lblPerido.Text
            .serie = txtSerieGuia.Text
            .numeroDoc = txtNumeroGuia.Text
            .tipoDoc = "99"
            .idEntidad = txtProveedor.ValueMember
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value
            .tipoCambio = txtTipoCambio.Value
            .importeMN = CDec(txtTotalPedidomn.Text)
            .importeME = CDec(txtTotalPedidome.Text)
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                documentoguiaDetalle = New documentoguiaDetalle
                If txtSerieGuia.Text.Trim.Length > 0 Then
                    'objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                    objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                Else
                    MessageBoxAdv.Show("Ingrese número de serie de la guía!")
                    Exit Sub
                End If
                If txtNumeroGuia.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))

                Else
                    MessageBoxAdv.Show("Ingrese número de la guía!")
                    Exit Sub
                End If
                documentoguiaDetalle.idDocumento = lblIdDocumento.Text
                documentoguiaDetalle.idItem = i.Cells(2).Value
                documentoguiaDetalle.descripcionItem = i.Cells(3).Value
                documentoguiaDetalle.destino = i.Cells(1).Value
                documentoguiaDetalle.unidadMedida = i.Cells(4).Value
                documentoguiaDetalle.cantidad = CDec(i.Cells(5).Value)

                documentoguiaDetalle.precioUnitario = CDec(i.Cells(8).Value)
                documentoguiaDetalle.precioUnitarioUS = CDec(i.Cells(9).Value)
                documentoguiaDetalle.importeMN = CDec(i.Cells(10).Value)
                documentoguiaDetalle.importeME = CDec(i.Cells(11).Value)
                documentoguiaDetalle.almacenRef = CInt(i.Cells(24).Value)
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If
        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Public Sub New()

        InitializeComponent()

        '   Me.WindowState = FormWindowState.Maximized
        GConfiguracion = New GConfiguracionModulo
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName

        fecha = Date.Now
        'ObtenerAlmacenes()
        'Docking()
        'GridCFG()
        lblPerido.Text = PeriodoGeneral
        'dockingManager1.CloseEnabled = False
        txtTipoCambio.Value = TmpTipoCambio
        txtIgv.Value = TmpIGV

        ObtenerListaControlesLoad()
        txtFechaComprobante.Select()
    End Sub


#Region "METODOS"


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
                    '.UbicarUsuarioCaja(intIdDocumento, "VENTA")
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



    Sub UpdateVentaCredito()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = IIf(rbBoleta.Checked = True, "03", "01")
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "01"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoVenta
            .idDocumento = lblIdDocumento.Text
            If IsNothing(GProyectos) Then
            Else
                .idPadre = GProyectos.IdProyectoActividad
            End If
            .TipoDocNumeracion = Nothing
            .codigoLibro = "8"
            .tipoDocumento = IIf(rbBoleta.Checked = True, "03", "01")
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha ' PERIODO
            .fechaPeriodo = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .idCliente = txtProveedor.ValueMember
            .numeroDocNormal = txtNumero.Text.Trim
            .nombrePedido = txtProveedor.Text
            ' .nombrePedido = txtPedidoRef.Text
            .moneda = IIf(cboMoneda.SelectedValue, "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = txtTipoCambio.Value

            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
            .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))

            .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
            .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))

            .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
            .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))

            .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
            .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))

            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
            .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))

            .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
            .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))

            .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
            .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))

            .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
            .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))

            '****************************************************************************************************************
            .ImporteNacional = CDec(txtTotalPedidomn.Text) 'IIf(txtTotalPedidomn.Text = 0 Or txtTotalPedidomn.Text = "0.00", CDec(0.0), CDec(txtTotalPedidomn.Text))
            .ImporteExtranjero = CDec(txtTotalPedidome.Text) 'IIf(txtTotalPedidome.Text = 0 Or txtTotalPedidome.Text = "0.00", CDec(0.0), CDec(txtTotalPedidome.Text))

            If lblServicio.Text = "Contado" Then
                .tipoVenta = TIPO_VENTA.VENTA_NORMAL_SERVICIO
                .estadoCobro = TIPO_VENTA.PAGO.COBRADO
            ElseIf lblServicio.Text = "Credito" Then
                .tipoVenta = TIPO_VENTA.VENTA_NORMAL_SERVICIO_CREDITO
                .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        GuiaRemision(ndocumento)
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            Dim almacenSA As New almacenSA
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.idDocumento = lblIdDocumento.Text
            objDocumentoVentaDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento 'almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = fecha

            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            objDocumentoVentaDet.idAlmacenOrigen = CDec(dgvNuevoDoc.Rows(i.Index).Cells(24).Value())
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento 'almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
            objDocumentoVentaDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
            objDocumentoVentaDet.DetalleItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
            objDocumentoVentaDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
            objDocumentoVentaDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
            objDocumentoVentaDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim
            objDocumentoVentaDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())
            objDocumentoVentaDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(29).Value()
            objDocumentoVentaDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
            objDocumentoVentaDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
            objDocumentoVentaDet.importeMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
            objDocumentoVentaDet.importeME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value())
            objDocumentoVentaDet.descuentoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value())
            objDocumentoVentaDet.descuentoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(15).Value())

            objDocumentoVentaDet.montokardex = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
            objDocumentoVentaDet.montoIsc = CDec(dgvNuevoDoc.Rows(i.Index).Cells(16).Value())
            objDocumentoVentaDet.montoIgv = CDec(dgvNuevoDoc.Rows(i.Index).Cells(17).Value())
            objDocumentoVentaDet.otrosTributos = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value())
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(12).Value())
            objDocumentoVentaDet.montoIscUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(19).Value())
            objDocumentoVentaDet.montoIgvUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(20).Value())
            objDocumentoVentaDet.otrosTributosUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(21).Value())
            '  objDocumentoVentaDet.PreEvento = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "SI" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value())
            objDocumentoVentaDet.importeMEK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value())
            objDocumentoVentaDet.fechaVcto = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()), Nothing, CDate(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))

            objDocumentoVentaDet.salidaCostoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value()) ' Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value()) 'Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)

            objDocumentoVentaDet.preEvento = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(27).Value()), Nothing, dgvNuevoDoc.Rows(i.Index).Cells(27).Value())
            objDocumentoVentaDet.usuarioModificacion = "Jiuni"
            objDocumentoVentaDet.fechaModificacion = Date.Now
            objDocumentoVentaDet.tipoVenta = dgvNuevoDoc.Rows(i.Index).Cells(32).Value()
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim

            ListaDetalle.Add(objDocumentoVentaDet)
            '   End If
        Next

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        'TOTALES ALMACEN
        'ListaTotales = ListaTotalesAlmacen()
        'ListaDeleteEO = ListaDeleteTotales()

        AsientoVenta()

        ndocumento.asiento = ListaAsientonTransito
        VentaSA.UpdateVentaNormalServicioCredito(ndocumento)
        lblEstado.Text = "venta modificada!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub



    Sub UpdateVenta()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento


        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = IIf(rbBoleta.Checked = True, "03", "01")
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "01"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoVenta
            .idDocumento = lblIdDocumento.Text
            If IsNothing(GProyectos) Then
            Else
                .idPadre = GProyectos.IdProyectoActividad
            End If
            .TipoDocNumeracion = Nothing
            .codigoLibro = "8"
            .tipoDocumento = IIf(rbBoleta.Checked = True, "03", "01")
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha ' PERIODO
            .fechaPeriodo = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .idCliente = txtProveedor.ValueMember
            .numeroDocNormal = txtNumero.Text.Trim
            .nombrePedido = txtProveedor.Text
            ' .nombrePedido = txtPedidoRef.Text
            .moneda = IIf(cboMoneda.SelectedValue, "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = txtTipoCambio.Value

            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
            .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))

            .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
            .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))

            .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
            .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))

            .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
            .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))

            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
            .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))

            .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
            .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))

            .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
            .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))

            .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
            .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))

            '****************************************************************************************************************
            .ImporteNacional = CDec(txtTotalPedidomn.Text) 'IIf(txtTotalPedidomn.Text = 0 Or txtTotalPedidomn.Text = "0.00", CDec(0.0), CDec(txtTotalPedidomn.Text))
            .ImporteExtranjero = CDec(txtTotalPedidome.Text) 'IIf(txtTotalPedidome.Text = 0 Or txtTotalPedidome.Text = "0.00", CDec(0.0), CDec(txtTotalPedidome.Text))

            If lblServicio.Text = "Contado" Then
                .tipoVenta = TIPO_VENTA.VENTA_NORMAL_SERVICIO
                .estadoCobro = TIPO_VENTA.PAGO.COBRADO
            ElseIf lblServicio.Text = "Credito" Then
                .tipoVenta = TIPO_VENTA.VENTA_NORMAL_SERVICIO_CREDITO
                .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        GuiaRemision(ndocumento)
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            Dim almacenSA As New almacenSA
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.idDocumento = lblIdDocumento.Text
            objDocumentoVentaDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento 'almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = fecha

            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            objDocumentoVentaDet.idAlmacenOrigen = CDec(dgvNuevoDoc.Rows(i.Index).Cells(24).Value())
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento 'almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
            objDocumentoVentaDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
            objDocumentoVentaDet.DetalleItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
            objDocumentoVentaDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
            objDocumentoVentaDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
            objDocumentoVentaDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim
            objDocumentoVentaDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())
            objDocumentoVentaDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(29).Value()
            objDocumentoVentaDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
            objDocumentoVentaDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
            objDocumentoVentaDet.importeMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
            objDocumentoVentaDet.importeME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value())
            objDocumentoVentaDet.descuentoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value())
            objDocumentoVentaDet.descuentoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(15).Value())

            objDocumentoVentaDet.montokardex = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
            objDocumentoVentaDet.montoIsc = CDec(dgvNuevoDoc.Rows(i.Index).Cells(16).Value())
            objDocumentoVentaDet.montoIgv = CDec(dgvNuevoDoc.Rows(i.Index).Cells(17).Value())
            objDocumentoVentaDet.otrosTributos = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value())
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(12).Value())
            objDocumentoVentaDet.montoIscUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(19).Value())
            objDocumentoVentaDet.montoIgvUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(20).Value())
            objDocumentoVentaDet.otrosTributosUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(21).Value())
            '  objDocumentoVentaDet.PreEvento = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "SI" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value())
            objDocumentoVentaDet.importeMEK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value())
            objDocumentoVentaDet.fechaVcto = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()), Nothing, CDate(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))

            objDocumentoVentaDet.salidaCostoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value()) ' Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value()) 'Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)

            objDocumentoVentaDet.preEvento = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(27).Value()), Nothing, dgvNuevoDoc.Rows(i.Index).Cells(27).Value())
            objDocumentoVentaDet.usuarioModificacion = "Jiuni"
            objDocumentoVentaDet.fechaModificacion = Date.Now
            objDocumentoVentaDet.tipoVenta = dgvNuevoDoc.Rows(i.Index).Cells(32).Value()
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim

            ListaDetalle.Add(objDocumentoVentaDet)
            '   End If
        Next

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        'TOTALES ALMACEN
        'ListaTotales = ListaTotalesAlmacen()
        'ListaDeleteEO = ListaDeleteTotales()
        DocCaja = ComprobanteCaja()
        AsientoVenta()

        ndocumento.asiento = ListaAsientonTransito
        VentaSA.UpdateVentaNormalServicio(ndocumento, DocCaja)
        lblEstado.Text = "venta modificada!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub


    Sub GrabarCredito()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()

        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = IIf(rbBoleta.Checked = True, "03", "01")
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "01"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With







        With nDocumentoVenta
            '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            'If IsNothing(GProyectos) Then
            'Else
            '    .idPadre = GProyectos.IdProyectoActividad
            'End If
            .TipoDocNumeracion = Nothing
            .codigoLibro = "8"
            .tipoDocumento = IIf(rbBoleta.Checked = True, "03", "01")
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha ' PERIODO
            .fechaPeriodo = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .numeroDocNormal = txtNumero.Text.Trim
            .idCliente = txtProveedor.ValueMember
            .nombrePedido = txtProveedor.Text
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = IIf(txtTipoCambio.Value = 0 Or txtTipoCambio.Value = "0.00", 0, CDec(txtTipoCambio.Value))

            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
            .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))

            .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
            .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))

            .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
            .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))

            .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
            .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))

            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
            .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))

            .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
            .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))

            .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
            .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))

            .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
            .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))

            '****************************************************************************************************************
            .ImporteNacional = CDec(txtTotalPedidomn.Text) 'IIf(txtTotalPedidomn.Text = 0 Or txtTotalPedidomn.Text = "0.00", CDec(0.0), CDec(txtTotalPedidomn.Text))
            .ImporteExtranjero = CDec(txtTotalPedidome.Text) 'IIf(txtTotalPedidome.Text = 0 Or txtTotalPedidome.Text = "0.00", CDec(0.0), CDec(txtTotalPedidome.Text))

            If lblServicio.Text = "Contado" Then
                .tipoVenta = TIPO_VENTA.VENTA_NORMAL_SERVICIO
                .estadoCobro = TIPO_VENTA.PAGO.COBRADO
            ElseIf lblServicio.Text = "Credito" Then
                .tipoVenta = TIPO_VENTA.VENTA_NORMAL_SERVICIO_CREDITO
                .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If


            .glosa = txtGlosa.Text.Trim
            '    .RE = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            ' = TIPO_VENTA.VENTA_PAGADA
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        GuiaRemision(ndocumento)

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            Dim almacenSA As New almacenSA
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento 'almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = fecha

            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            objDocumentoVentaDet.idAlmacenOrigen = CDec(i.Cells(24).Value())
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento 'almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = i.Cells(25).Value()
            objDocumentoVentaDet.idItem = i.Cells(2).Value()


            If i.Cells(3).Value.ToString.Trim.Length > 0 Then
                objDocumentoVentaDet.DetalleItem = i.Cells(3).Value()
            Else

                lblEstado.Text = "Debe Ingresar Descripcion"
                PanelError.Visible = True
                Exit Sub

            End If
            objDocumentoVentaDet.tipoExistencia = i.Cells(23).Value()
            objDocumentoVentaDet.destino = i.Cells(1).Value()
            objDocumentoVentaDet.unidad1 = i.Cells(4).Value().ToString.Trim
            objDocumentoVentaDet.monto1 = CDec(i.Cells(5).Value())
            objDocumentoVentaDet.unidad2 = i.Cells(29).Value()
            objDocumentoVentaDet.monto2 = i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoVentaDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoVentaDet.importeMN = CDec(i.Cells(11).Value())
            objDocumentoVentaDet.importeME = CDec(i.Cells(13).Value())
            objDocumentoVentaDet.descuentoMN = CDec(i.Cells(14).Value())
            objDocumentoVentaDet.descuentoME = CDec(i.Cells(15).Value())

            objDocumentoVentaDet.montokardex = CDec(i.Cells(10).Value())
            objDocumentoVentaDet.montoIsc = CDec(i.Cells(16).Value())
            objDocumentoVentaDet.montoIgv = CDec(i.Cells(17).Value())
            objDocumentoVentaDet.otrosTributos = CDec(i.Cells(18).Value())
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(i.Cells(12).Value())
            objDocumentoVentaDet.montoIscUS = CDec(i.Cells(19).Value())
            objDocumentoVentaDet.montoIgvUS = CDec(i.Cells(20).Value())
            objDocumentoVentaDet.otrosTributosUS = CDec(i.Cells(21).Value())
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "SI" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(i.Cells(6).Value())
            objDocumentoVentaDet.importeMEK = CDec(i.Cells(28).Value())
            objDocumentoVentaDet.fechaVcto = IIf(IsNothing(i.Cells(30).Value()), Nothing, CDate(i.Cells(30).Value()))

            objDocumentoVentaDet.salidaCostoMN = CDec(i.Cells(33).Value()) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(i.Cells(34).Value()) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            objDocumentoVentaDet.preEvento = IIf(IsNothing(i.Cells(27).Value()), Nothing, i.Cells(27).Value())
            objDocumentoVentaDet.usuarioModificacion = "Jiuni"
            objDocumentoVentaDet.fechaModificacion = Date.Now
            objDocumentoVentaDet.tipoVenta = i.Cells(32).Value()
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)

        Next

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        'ListaTotales = ListaTotalesAlmacen()
        AsientoVenta()

        ndocumento.asiento = ListaAsientonTransito

        Dim xcod As Integer = VentaSA.SaveVentaNormalServicioCredito(ndocumento)
        lblEstado.Text = "venta registrada!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub


    Sub Grabar()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = IIf(rbBoleta.Checked = True, "03", "01")
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "01"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario '"NN"
            .fechaActualizacion = DateTime.Now
        End With



        DocCaja = ComprobanteCaja()



        With nDocumentoVenta
            '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            'If IsNothing(GProyectos) Then
            'Else
            '    .idPadre = GProyectos.IdProyectoActividad
            'End If
            .TipoDocNumeracion = Nothing
            .codigoLibro = "8"
            .tipoDocumento = IIf(rbBoleta.Checked = True, "03", "01")
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha ' PERIODO
            .fechaPeriodo = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .numeroDocNormal = txtNumero.Text.Trim
            .idCliente = txtProveedor.ValueMember
            .nombrePedido = txtProveedor.Text
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = IIf(txtTipoCambio.Value = 0 Or txtTipoCambio.Value = "0.00", 0, CDec(txtTipoCambio.Value))

            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
            .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))

            .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
            .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))

            .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
            .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))

            .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
            .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))

            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
            .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))

            .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
            .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))

            .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
            .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))

            .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
            .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))

            '****************************************************************************************************************
            .ImporteNacional = CDec(txtTotalPedidomn.Text) 'IIf(txtTotalPedidomn.Text = 0 Or txtTotalPedidomn.Text = "0.00", CDec(0.0), CDec(txtTotalPedidomn.Text))
            .ImporteExtranjero = CDec(txtTotalPedidome.Text) 'IIf(txtTotalPedidome.Text = 0 Or txtTotalPedidome.Text = "0.00", CDec(0.0), CDec(txtTotalPedidome.Text))

            If lblServicio.Text = "Contado" Then
                .tipoVenta = TIPO_VENTA.VENTA_NORMAL_SERVICIO
                .estadoCobro = TIPO_VENTA.PAGO.COBRADO
            ElseIf lblServicio.Text = "Credito" Then
                .tipoVenta = TIPO_VENTA.VENTA_NORMAL_SERVICIO_CREDITO
                .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If


            .glosa = txtGlosa.Text.Trim
            '    .RE = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            ' = TIPO_VENTA.VENTA_PAGADA
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        GuiaRemision(ndocumento)

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            Dim almacenSA As New almacenSA
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento 'almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = fecha

            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            objDocumentoVentaDet.idAlmacenOrigen = CDec(i.Cells(24).Value())
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento 'almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = i.Cells(25).Value()
            objDocumentoVentaDet.idItem = i.Cells(2).Value()


            If i.Cells(3).Value.ToString.Trim.Length > 0 Then
                objDocumentoVentaDet.DetalleItem = i.Cells(3).Value()
            Else

                lblEstado.Text = "Debe Ingresar Descripcion"
                PanelError.Visible = True
                Exit Sub

            End If
            objDocumentoVentaDet.tipoExistencia = i.Cells(23).Value()
            objDocumentoVentaDet.destino = i.Cells(1).Value()
            objDocumentoVentaDet.unidad1 = i.Cells(4).Value().ToString.Trim
            objDocumentoVentaDet.monto1 = CDec(i.Cells(5).Value())
            objDocumentoVentaDet.unidad2 = i.Cells(29).Value()
            objDocumentoVentaDet.monto2 = i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoVentaDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoVentaDet.importeMN = CDec(i.Cells(11).Value())
            objDocumentoVentaDet.importeME = CDec(i.Cells(13).Value())
            objDocumentoVentaDet.descuentoMN = CDec(i.Cells(14).Value())
            objDocumentoVentaDet.descuentoME = CDec(i.Cells(15).Value())

            objDocumentoVentaDet.montokardex = CDec(i.Cells(10).Value())
            objDocumentoVentaDet.montoIsc = CDec(i.Cells(16).Value())
            objDocumentoVentaDet.montoIgv = CDec(i.Cells(17).Value())
            objDocumentoVentaDet.otrosTributos = CDec(i.Cells(18).Value())
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(i.Cells(12).Value())
            objDocumentoVentaDet.montoIscUS = CDec(i.Cells(19).Value())
            objDocumentoVentaDet.montoIgvUS = CDec(i.Cells(20).Value())
            objDocumentoVentaDet.otrosTributosUS = CDec(i.Cells(21).Value())
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "SI" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(i.Cells(6).Value())
            objDocumentoVentaDet.importeMEK = CDec(i.Cells(28).Value())
            objDocumentoVentaDet.fechaVcto = IIf(IsNothing(i.Cells(30).Value()), Nothing, CDate(i.Cells(30).Value()))

            objDocumentoVentaDet.salidaCostoMN = CDec(i.Cells(33).Value()) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(i.Cells(34).Value()) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            objDocumentoVentaDet.preEvento = IIf(IsNothing(i.Cells(27).Value()), Nothing, i.Cells(27).Value())
            objDocumentoVentaDet.usuarioModificacion = "Jiuni"
            objDocumentoVentaDet.fechaModificacion = Date.Now
            objDocumentoVentaDet.tipoVenta = i.Cells(32).Value()
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)

        Next

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        'ListaTotales = ListaTotalesAlmacen()
        AsientoVenta()

        ndocumento.asiento = ListaAsientonTransito

        Dim xcod As Integer = VentaSA.SaveVentaNormalServicio(ndocumento, DocCaja)
        lblEstado.Text = "venta registrada!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub


    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvNuevoDoc.CurrentCell()

        If Celda.ColumnIndex = 8 Or Celda.ColumnIndex = 11 Or Celda.ColumnIndex = 13 Then

            If e.KeyChar = "."c Or e.KeyChar = ","c Then

                If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

                    e.Handled = True
                Else

                    e.Handled = False
                End If
            Else

                If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

                    If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                        e.Handled = False
                    Else

                        e.Handled = True
                    End If
                Else

                    If e.KeyChar = "0"c Then

                        e.Handled = True
                    Else

                        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                            e.Handled = False
                        Else

                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If


        'If Celda.ColumnIndex = 3 Then
        '    Celda = Char.ToUpper(e.KeyChar)
        'End If


    End Sub

    Public Sub TotalesCabeceras()
        Dim cTotalCosto As Decimal = 0
        Dim cTotalCostoME As Decimal = 0

        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0

        Dim cTotalBI As Decimal = 0
        Dim cTotalBI_ME As Decimal = 0

        Dim cTotalIGV As Decimal = 0
        Dim cTotalIGV_ME As Decimal = 0

        Dim cTotalIsc As Decimal = 0
        Dim cTotalIsc_ME As Decimal = 0

        Dim cTotalOTC As Decimal = 0
        Dim cTotalOTC_ME As Decimal = 0
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If i.Cells(22).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                cTotalMN += CDec(i.Cells(11).Value)
                cTotalME += CDec(i.Cells(13).Value)

                cTotalBI += CDec(i.Cells(10).Value)
                cTotalBI_ME += CDec(i.Cells(12).Value)

                cTotalIGV += CDec(i.Cells(17).Value)
                cTotalIGV_ME += CDec(i.Cells(20).Value)

                cTotalIsc += CDec(i.Cells(16).Value)
                cTotalIsc_ME += CDec(i.Cells(19).Value)

                cTotalOTC += CDec(i.Cells(18).Value)
                cTotalOTC_ME += CDec(i.Cells(21).Value)

                cTotalCosto += CDec(i.Cells(33).Value)
                cTotalCostoME += CDec(i.Cells(34).Value)
            End If
        Next

        txtTotalBImn.Text = cTotalBI.ToString("N2")
        txtTotalBIme.Text = cTotalBI_ME.ToString("N2")

        'lblTotalISc.Text = cTotalIsc.ToString("N2")
        'lblTotalIScUS.Text = cTotalIsc_ME.ToString("N2")

        txtMontoIGVmn.Text = cTotalIGV.ToString("N2")
        txtMontoIGVme.Text = cTotalIGV_ME.ToString("N2")

        'lblOtrostribTotal.Text = cTotalOTC.ToString("N2")
        'lblOtrostribTotalUS.Text = cTotalOTC_ME.ToString("N2")


        txtTotalPedidomn.Text = cTotalMN   'cTotalMN.ToString("N2")
        txtTotalPedidome.Text = cTotalME

        'Select Case cboTipoDoc.SelectedValue
        '    Case "02", "03"
        '        txtTotalPedidomn.Text = cTotalMN   'cTotalMN.ToString("N2")
        '        txtTotalPedidome.Text = cTotalME   'cTotalME.ToString("N2")
        '        lblCostoMN.Text = cTotalCosto
        '        lblCostoME.Text = cTotalCostoME
        '    Case "08"
        '        'Instrucciones
        '    Case Else
        '        txtTotalPedidomn.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
        '        txtTotalPedidome.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
        '        lblCostoMN.Text = cTotalCosto
        '        lblCostoME.Text = cTotalCostoME
        'End Select

    End Sub

    'Public Sub totales_xx()
    '    Dim i As Integer

    '    Dim bi1, bi2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
    '    Dim bi1me, bi2me As Decimal 'tus3, tus4 
    '    Dim totalIgv1 As Decimal = 0
    '    Dim totalIgv1_ME As Decimal = 0
    '    Dim totalIgv2 As Decimal = 0
    '    Dim totalIgv2_ME As Decimal = 0


    '    Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
    '    For i = 0 To dgvNuevoDoc.Rows.Count - 1
    '        'total += carrito.Rows(i)(5)
    '        If dgvNuevoDoc.Rows(i).Cells(22).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
    '            If Not dgvNuevoDoc.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
    '                If dgvNuevoDoc.Rows(i).Cells(1).Value() = "1" Then

    '                    bi1 += dgvNuevoDoc.Rows(i).Cells(14).Value() ' total base 01 soles
    '                    bi1me += dgvNuevoDoc.Rows(i).Cells(18).Value() ' total base 01 dolares
    '                    totalIgv1 += dgvNuevoDoc.Rows(i).Cells(16).Value()
    '                    totalIgv1_ME += dgvNuevoDoc.Rows(i).Cells(20).Value()

    '                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "2" Then

    '                    bi2 += dgvNuevoDoc.Rows(i).Cells(14).Value()
    '                    bi2me += dgvNuevoDoc.Rows(i).Cells(18).Value() ' total base 01
    '                    totalIgv2 += dgvNuevoDoc.Rows(i).Cells(16).Value()
    '                    totalIgv2_ME += dgvNuevoDoc.Rows(i).Cells(20).Value()

    '                End If
    '            End If
    '        End If

    '    Next
    '    nudBase1 = bi1.ToString("N2")
    '    nudBaseus1 = bi1me.ToString("N2")
    '    nudBase2 = bi2.ToString("N2")
    '    nudBaseus2 = bi2me.ToString("N2")

    '    nudMontoIgv1 = totalIgv1.ToString("N2")
    '    nudMontoIgvus1 = totalIgv1_ME.ToString("N2")
    '    nudMontoIgv2 = totalIgv2.ToString("N2")
    '    nudMontoIgvus2 = totalIgv2_ME.ToString("N2")

    'End Sub


#End Region

    Private Sub frmVentaNormalServicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub



    Private Sub frmVentaNormalServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

    End Sub

    Private Sub dgvNuevoDoc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellContentClick

    End Sub

    Private Sub dgvNuevoDoc_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellEndEdit
        If dgvNuevoDoc.Rows.Count > 0 Then
            If txtTipoCambio.Value > 0 Then
                'DECLARANDO VARIABLES
                'Dim colPrecUnitAlmacen As Decimal = 0
                'Dim colPrecUnitUSAlmacen As Decimal = 0

                'colPrecUnitAlmacen = dgvNuevoDoc.Item(6, dgvNuevoDoc.CurrentRow.Index).Value
                'colPrecUnitUSAlmacen = dgvNuevoDoc.Item(28, dgvNuevoDoc.CurrentRow.Index).Value


                Dim colPrecUnit As Decimal = 0
                Dim colPrecUnitUSD As Decimal = 0
                Dim colDestinoGravado As Decimal = 0

                colPrecUnit = dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value
                'colPrecUnitUSD = dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value

                colDestinoGravado = dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value

                Dim colCantidad As Decimal = dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value
                Dim colCantidadDisponible As Decimal = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value

                Dim colBI As Decimal = 0
                Dim colBI_ME As Decimal = 0
                Dim colIGV_ME As Decimal = 0
                Dim colIGV As Decimal = 0
                Dim colMN As Decimal = Math.Round(colCantidad * colPrecUnit, 2)
                ' Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)


                'Dim colCostoMN As Decimal = Math.Round(colCantidad * colPrecUnitAlmacen, 2)
                'Dim colCostoME As Decimal = Math.Round(colCantidad * colPrecUnitUSAlmacen, 2)

                If colCantidad > 0 AndAlso colMN > 0 Then

                    colBI = Math.Round(colMN / 1.18, 2)
                    'colBI_ME = Math.Round(colME / 1.18, 2)
                    'colIGV = Math.Round((colMN / 1.18) * (txtIgv.Value / 100), 2)

                    colIGV = Math.Round(colMN * (txtIgv.Value / 100), 2)

                    ' Math.Round(colBI * 0.18, 2)
                    'colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                Else
                    colBI = 0
                    colBI_ME = 0
                    colIGV = 0
                    colIGV_ME = 0
                End If

                Select Case dgvNuevoDoc.Columns(e.ColumnIndex).Name
                    Case "Can1"
                        If colCantidad > colCantidadDisponible Then
                            MsgBox("Debe ingresar un monto, " & vbCrLf & "que no supere la cantidad disponible.", MsgBoxStyle.Information, "Atención!")
                            dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value = 0
                            Exit Sub
                        Else
                            dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value = colCantidad.ToString("N2")
                        End If
                End Select

                Dim valor As Decimal = 0
                Dim NUDIGV_VALUE As Decimal = 0
                '  If IsNothing(cboMoneda.SelectedValue) Then Exit Sub
                If cboMoneda.SelectedValue = 1 Then
                    Select Case colDestinoGravado
                        Case 1
                            NUDIGV_VALUE = Math.Round((txtIgv.Value / 100) + 1, 2)

                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "kardex" Then
                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") 'prec unit usd

                                dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = (CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value / txtTipoCambio.Value)).ToString("N2")


                                colPrecUnitUSD = dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value
                                Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)

                                If colCantidad > 0 AndAlso colMN > 0 Then

                                    ' colBI = Math.Round(colMN / 1.18, 2)
                                    colBI_ME = Math.Round(colME / 1.18, 2)
                                    ' colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                                    'colIGV_ME = Math.Round((colME / 1.18) * (txtIgv.Value / 100), 2) ' Math.Round(colBI_ME * 0.18, 2)
                                    colIGV_ME = Math.Round(colME * (txtIgv.Value / 100), 2)
                                Else
                                    ' colBI = 0
                                    colBI_ME = 0
                                    'colIGV = 0
                                    colIGV_ME = 0
                                End If

                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = (colMN + colIGV).ToString("N2")
                                dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = (CDec((dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value * dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value) + colIGV_ME)).ToString("N2")

                                ' dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = (colMN + colIGV).ToString("N2") ' monto para el kardex
                                ' dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = (CDec((dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value * dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value) + colIGV_ME)).ToString("N2")

                                dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' monto igv del item
                                ' dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = 0
                                dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = 0




                            End If

                        Case 2
                            NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "kardex" Then

                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2")
                                dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = (dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value / txtTipoCambio.Value)

                                colPrecUnitUSD = dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value
                                Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)

                                If colCantidad > 0 AndAlso colMN > 0 Then

                                    ' colBI = Math.Round(colMN / 1.18, 2)
                                    colBI_ME = Math.Round(colME / 1.18, 2)
                                    ' colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                                    'colIGV_ME = Math.Round((colME / 1.18) * (txtIgv.Value / 100), 2) ' Math.Round(colBI_ME * 0.18, 2)
                                    colIGV_ME = Math.Round(colME * (txtIgv.Value / 100), 2)
                                Else
                                    colBI = 0
                                    colBI_ME = 0
                                    colIGV = 0
                                    colIGV_ME = 0
                                End If


                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = (colMN + colIGV).ToString("N2")
                                dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = (CDec((dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value * dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value) + colIGV_ME)).ToString("N2")

                                ' dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = (colMN + colIGV).ToString("N2") ' monto para el kardex
                                ' dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = (CDec((dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value * dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value) + colIGV_ME)).ToString("N2")

                                dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' monto igv del item
                                ' dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = 0
                                dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = 0

                            End If

                    End Select
                    totales_xx()
                    TotalesCabeceras()
                Else
                    'IMPLEMENTAR CODIGO PARA MONEDA EXTRANJERA
                End If

            Else
                MsgBox("Ingrese un tipo de cambio mayor a cero", MsgBoxStyle.Information, "Atención!")
                txtTipoCambio.Focus()
                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
            End If

        End If
    End Sub

    Private Sub dgvNuevoDoc_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvNuevoDoc.CellFormatting

        If e.RowIndex > -1 Then
            If e.ColumnIndex = Me.dgvNuevoDoc.Columns("Gravado").Index _
    AndAlso (e.Value IsNot Nothing) Then

                With Me.dgvNuevoDoc.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    If e.Value.Equals("1") Then
                        .ToolTipText = "1: ADQ. AFECTOS AL I.G.V."
                    ElseIf e.Value.Equals("2") Then
                        .ToolTipText = "2: ADQ. NO AFECTOS AL I.G.V."
                    End If

                End With

            End If
        End If
    End Sub

    Private Sub dgvNuevoDoc_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvNuevoDoc.CurrentCellDirtyStateChanged
        Try
            If dgvNuevoDoc.IsCurrentCellDirty Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            If TypeOf dgvNuevoDoc.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

        Catch
        End Try
    End Sub

    Private Sub dgvNuevoDoc_Disposed(sender As Object, e As EventArgs) Handles dgvNuevoDoc.Disposed

    End Sub

    Private Sub dgvNuevoDoc_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvNuevoDoc.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros

        If TypeOf e.Control Is TextBox Then
            'Indico la columna que deseo cambiar
            If dgvNuevoDoc.CurrentCell.ColumnIndex = 3 Then
                'Pone en mayúsculas la celda del grid
                DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper

            End If
        End If




    End Sub







    Private Sub dgvNuevoDoc_ImeModeChanged(sender As Object, e As EventArgs) Handles dgvNuevoDoc.ImeModeChanged

    End Sub

    Private Sub dgvNuevoDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvNuevoDoc.KeyDown
        Dim conteo As Integer = dgvNuevoDoc.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvNuevoDoc.CurrentCell.ColumnIndex)
                    Case 5
                        'If cboMoneda.SelectedValue Then
                        '    If conteo = 1 Then
                        '        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                        '    Else
                        '        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                        '    End If
                        'Else
                        '    If conteo = 1 Then
                        '        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                        '    Else
                        '        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                        '    End If
                        'End If
                    Case 3
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvNuevoDoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvNuevoDoc.KeyPress

    End Sub

    Private Sub dgvNuevoDoc_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvNuevoDoc.RowPostPaint
        Dim grid As DataGridView = TryCast(sender, DataGridView)

        If Not grid.RowHeadersVisible Then
            Return
        End If

        Dim strRowNumber As String = (e.RowIndex + 1).ToString()

        While strRowNumber.Length < grid.RowCount.ToString().Length
            strRowNumber = Convert.ToString("0") & strRowNumber
        End While
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, grid.Font)

        If grid.RowHeadersWidth < CInt(size.Width + 20) Then
            grid.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim b As Brush = SystemBrushes.ControlText

        e.Graphics.DrawString(strRowNumber, grid.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
        End If

    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)

            'txtAlmacen.Select()
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
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
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                'If chFormato.Checked = True Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

                        If Len(txtSerie.Text) <= 2 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

                        ElseIf Len(txtSerie.Text) <= 3 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

                        ElseIf Len(txtSerie.Text) <= 4 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

                        ElseIf Len(txtSerie.Text) <= 5 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

                        End If
                    End If
                Else

                    txtSerie.Select()
                    txtSerie.Focus()
                    txtSerie.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"

                End If

            Else

                txtSerie.Select()
                txtSerie.Focus()
                txtSerie.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"

            End If

        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtProveedor.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                'If chFormato.Checked = True Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()
            lblEstado.Text = "DEBE INGRESAR UN NUMERO"
        End Try
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click



    End Sub

    Private Sub ToolStrip3_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip3.ItemClicked

    End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                If i.Cells(22).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                    If txtTipoCambio.Value > 0 Then
                        'DECLARANDO VARIABLES
                        'Dim colPrecUnitAlmacen As Decimal = 0 '
                        'Dim colPrecUnitUSAlmacen As Decimal = 0 '

                        'colPrecUnitAlmacen = i.Cells(6).Value '
                        'colPrecUnitUSAlmacen = i.Cells(28).Value '


                        Dim colPrecUnit As Decimal = 0 '
                        'Dim colPrecUnitUSD As Decimal = 0 '
                        Dim colDestinoGravado As Decimal = 0 '

                        colPrecUnit = i.Cells(10).Value '
                        'colPrecUnitUSD = i.Cells(9).Value '
                        colDestinoGravado = i.Cells(1).Value '

                        Dim colCantidad As Decimal = i.Cells(5).Value '
                        Dim colCantidadDisponible As Decimal = i.Cells(7).Value '

                        Dim colBI As Decimal = 0
                        Dim colBI_ME As Decimal = 0
                        Dim colIGV_ME As Decimal = 0
                        Dim colIGV As Decimal = 0
                        Dim colMN As Decimal = Math.Round(colCantidad * colPrecUnit, 2)
                        'Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)


                        'Dim colCostoMN As Decimal = Math.Round(colCantidad * colPrecUnitAlmacen, 2)
                        'Dim colCostoME As Decimal = Math.Round(colCantidad * colPrecUnitUSAlmacen, 2)

                        If colCantidad > 0 AndAlso colMN > 0 Then

                            colBI = Math.Round(colMN / 1.18, 2)
                            'colBI_ME = Math.Round(colME / 1.18, 2)
                            'colIGV = Math.Round((colMN / 1.18) * (txtIgv.Value / 100), 2) ' Math.Round(colBI * 0.18, 2)
                            colIGV = Math.Round(colMN * (txtIgv.Value / 100), 2)
                            'colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                        Else
                            colBI = 0
                            colBI_ME = 0
                            colIGV = 0
                            colIGV_ME = 0
                        End If

                        If colCantidad > colCantidadDisponible Then
                            MsgBox("Debe ingresar un monto, " & vbCrLf & "que no supere la cantidad disponible.", MsgBoxStyle.Information, "Atención!")
                            i.Cells(5).Value = 0
                            Exit Sub
                        Else
                            i.Cells(5).Value = colCantidad.ToString("N2")
                        End If

                        Dim valor As Decimal = 0
                        Dim NUDIGV_VALUE As Decimal = 0
                        '  If IsNothing(cboMoneda.SelectedValue) Then Exit Sub
                        If cboMoneda.SelectedValue = 1 Then
                            Select Case colDestinoGravado
                                Case 1
                                    NUDIGV_VALUE = Math.Round((txtIgv.Value / 100) + 1, 2)
                                    i.Cells(10).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    i.Cells(12).Value() = (CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value / txtTipoCambio.Value)).ToString("N2") 'prec unit usd


                                    Dim colPrecUnitUSD As Decimal = 0 '
                                    colPrecUnitUSD = i.Cells(12).Value '
                                    Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)

                                    If colCantidad > 0 AndAlso colMN > 0 Then

                                        ' colBI = Math.Round(colMN / 1.18, 2)
                                        colBI_ME = Math.Round(colME / 1.18, 2)
                                        'colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                                        'colIGV_ME = Math.Round((colME / 1.18) * (txtIgv.Value / 100), 2) ' Math.Round(colBI_ME * 0.18, 2)
                                        colIGV_ME = Math.Round(colME * (txtIgv.Value / 100), 2)
                                    Else
                                        'colBI = 0
                                        colBI_ME = 0
                                        'colIGV = 0
                                        colIGV_ME = 0
                                    End If


                                    i.Cells(11).Value() = (colMN + colIGV).ToString("N2")
                                    i.Cells(13).Value() = (CDec((dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value * dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value) + colIGV_ME)).ToString("N2") ' MONTO TOTAL DOLARES
                                    'i.Cells(10).Value() = colBI.ToString("N2") ' monto para el kardex
                                    i.Cells(17).Value() = colIGV.ToString("N2") ' monto igv del item
                                    'i.Cells(12).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                    i.Cells(20).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                    i.Cells(33).Value() = 0
                                    i.Cells(34).Value() = 0

                                Case 2

                                    NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)

                                    i.Cells(10).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    i.Cells(12).Value() = (CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value / txtTipoCambio.Value)).ToString("N2") 'prec unit usd


                                    Dim colPrecUnitUSD As Decimal = 0 '
                                    colPrecUnitUSD = i.Cells(12).Value '
                                    Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)

                                    If colCantidad > 0 AndAlso colMN > 0 Then

                                        ' colBI = Math.Round(colMN / 1.18, 2)
                                        colBI_ME = Math.Round(colME / 1.18, 2)
                                        'colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                                        ' colIGV_ME = Math.Round((colME / 1.18) * (txtIgv.Value / 100), 2) ' Math.Round(colBI_ME * 0.18, 2)
                                        colIGV_ME = Math.Round(colME * (txtIgv.Value / 100), 2)
                                    Else
                                        'colBI = 0
                                        colBI_ME = 0
                                        'colIGV = 0
                                        colIGV_ME = 0
                                    End If

                                    i.Cells(11).Value() = (colMN + colIGV).ToString("N2")
                                    i.Cells(13).Value() = (CDec((dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value * dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value) + colIGV_ME)).ToString("N2")  ' MONTO TOTAL DOLARES
                                    i.Cells(10).Value() = colBI.ToString("N2") ' monto para el kardex
                                    i.Cells(17).Value() = colIGV.ToString("N2") ' monto igv del item
                                    'i.Cells(12).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                    i.Cells(20).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                    i.Cells(33).Value() = 0
                                    i.Cells(34).Value() = 0

                            End Select
                            totales_xx()
                            TotalesCabeceras()
                        Else
                            'IMPLEMENTAR CODIGO PARA MONEDA EXTRANJERA
                        End If

                    Else
                        MsgBox("Ingrese un tipo de cambio mayor a cero", MsgBoxStyle.Information, "Atención!")
                        txtTipoCambio.Focus()
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                    End If
                End If

            Next
        End If
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        If dgvNuevoDoc.Rows.Count > 0 Then
            If txtTipoCambio.Value > 0 Then
                CellEndEditRefresh()
            End If

        End If
    End Sub

    Private Sub txtIgv_ValueChanged(sender As Object, e As EventArgs) Handles txtIgv.ValueChanged
        If dgvNuevoDoc.Rows.Count > 0 Then
            If txtTipoCambio.Value > 0 Then
                CellEndEditRefresh()
            End If

        End If
    End Sub

    Private Sub txtRuc_TextChanged(sender As Object, e As EventArgs) Handles txtRuc.TextChanged

    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieGuia.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumeroGuia.Select()
        End If
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As EventArgs) Handles txtSerieGuia.LostFocus
        Try
            If txtSerieGuia.Text.Trim.Length > 0 Then
                'If chFormato.Checked = True Then
                txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                'End If
            End If

        Catch ex As Exception
            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerieGuia.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1)) = True Then

                        If Len(txtSerieGuia.Text) <= 2 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1))

                        ElseIf Len(txtSerieGuia.Text) <= 3 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 2))

                        ElseIf Len(txtSerieGuia.Text) <= 4 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 3))

                        ElseIf Len(txtSerieGuia.Text) <= 5 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 4))

                        End If
                    End If
                Else

                    txtSerieGuia.Select()
                    txtSerieGuia.Focus()
                    txtSerieGuia.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"

                End If
            Else

                txtSerieGuia.Select()
                txtSerieGuia.Focus()
                txtSerieGuia.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"

            End If
        End Try
    End Sub

    Private Sub txtSerieGuia_TextChanged(sender As Object, e As EventArgs) Handles txtSerieGuia.TextChanged

    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroGuia.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As EventArgs) Handles txtNumeroGuia.LostFocus
        Try
            If txtNumeroGuia.Text.Trim.Length > 0 Then
                txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub txtNumeroGuia_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroGuia.TextChanged

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                'Me.lblEstado.Image = My.Resources.ok4  ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Done Serie!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            Else

                'Me.lblEstado.Image = My.Resources.warning2   ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Ingrese la serie del comprobante!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub

            End If

            If txtNumero.Text.Trim.Length > 0 Then
                'Me.lblEstado.Image = My.Resources.ok4  ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Done Número!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)

            Else
                'Me.lblEstado.Image = My.Resources.warning2   ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Ingrese el numero del comprobante!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If txtProveedor.Text.Trim.Length > 0 Then
                'Me.lblEstado.Image = My.Resources.ok4  ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Done cliente!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            Else
                ' Me.lblEstado.Image = My.Resources.warning2   ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                Me.lblEstado.Text = "Ingrese el nombre del cliente!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub

            End If

            If dgvNuevoDoc.Rows.Count > 0 Then
                ' Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
                Me.lblEstado.Text = "Done!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    '   For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                    If lblServicio.Text = "Contado" Then
                        Grabar()
                    ElseIf lblServicio.Text = "Credito" Then
                        GrabarCredito()
                    End If
                    ' Next
                Else
                    Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                    If Filas > 0 Then
                        If lblServicio.Text = "Contado" Then
                            UpdateVenta()
                        ElseIf lblServicio.Text = "Credito" Then
                            UpdateVentaCredito()
                        End If
                    Else
                        ' Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                        Me.lblEstado.Text = "Ingrese items a la canasta de ventas!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        Me.Cursor = Cursors.Arrow
                    End If
                End If

            End If
        Catch ex As Exception
            Me.lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
     
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GradientPanel4_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel4.Paint

    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs) Handles Panel9.Paint

    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        dgvNuevoDoc.Rows.Add(0, "1",
                                 "1",
                                 "",
                                 "07",
                                 1,
                                 0,
                                 1,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 0,
                                 Business.Entity.BaseBE.EntityAction.INSERT,
                                0,
                                 0,
                                 Nothing,
                                 GEstableciento.IdEstablecimiento,
                                 Nothing,
                                0,
                                 0,
                                 Nothing,
                                 0,
                                 "NULL",
                                 0,
                                 0)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click

    End Sub

    Private Sub btnRuc_Click(sender As Object, e As EventArgs) Handles btnRuc.Click
        btnRuc.Checked = True
        If btnRuc.Checked = True Then
            btnDni.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnDni_Click(sender As Object, e As EventArgs) Handles btnDni.Click
        btnDni.Checked = True
        If btnDni.Checked = True Then
            btnRuc.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnPassport_Click(sender As Object, e As EventArgs) Handles btnPassport.Click
        btnPassport.Checked = True
        If btnPassport.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnCarnetEx_Click(sender As Object, e As EventArgs) Handles btnCarnetEx.Click
        btnCarnetEx.Checked = True
        If btnCarnetEx.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnPassport.Checked = False
        End If
    End Sub

    Private Sub rbNatural_CheckChanged(sender As Object, e As EventArgs) Handles rbNatural.CheckChanged
        If rbNatural.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()
            Label31.Visible = True
            txtNomProv.Select()
            Label30.Text = "Nombres:"
        End If
    End Sub

    Private Sub rbJuridico_CheckChanged(sender As Object, e As EventArgs) Handles rbJuridico.CheckChanged
        If rbJuridico.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            Label31.Visible = False
            txtNomProv.Select()
            Label30.Text = "Nombre o Razón Social:"
        End If
    End Sub

    Private Sub btnGRabarProv_Click(sender As Object, e As EventArgs) Handles btnGRabarProv.Click
        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del cliente"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 252)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del cliente"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 252)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtNomProv.Select()
            Exit Sub
        End If

        If rbNatural.Checked = True Then
            If Not txtApePat.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del cliente"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtApePat.Select()
                Exit Sub
            End If
        End If
        btnGRabarProv.Tag = "G"
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btnCancelarProv_Click(sender As Object, e As EventArgs) Handles btnCancelarProv.Click
        Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
        txtRuc.Clear()
    End Sub

    Private Sub pcProveedor_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProveedor.BeforePopup
        Me.pcProveedor.BackColor = Color.White
    End Sub

    Private Sub pcProveedor_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProveedor.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDocProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del cliente"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtDocProveedor.Select()
                Exit Sub
            End If

            If Not txtNomProv.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del cliente"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtNomProv.Select()
                Exit Sub
            End If

            If rbNatural.Checked = True Then
                If Not txtApePat.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese los apellidos del cliente"
                    pcProveedor.Font = New Font("Tahoma", 8)
                    pcProveedor.Size = New Size(321, 252)
                    Me.pcProveedor.ParentControl = Me.txtProveedor
                    Me.pcProveedor.ShowPopup(Point.Empty)
                    txtApePat.Select()
                    Exit Sub
                End If
            End If
            If btnGRabarProv.Tag = "G" Then
                InsertProveedor()
                btnGRabarProv.Tag = "N"
            Else
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        txtDocProveedor.Clear()
        txtNomProv.Clear()
        txtApePat.Clear()
        txtDocProveedor.Select()
        rbNatural.Checked = True
        pcProveedor.Font = New Font("Tahoma", 8)
        pcProveedor.Size = New Size(321, 252)
        Me.pcProveedor.ParentControl = Me.txtProveedor
        Me.pcProveedor.ShowPopup(Point.Empty)
    End Sub
End Class