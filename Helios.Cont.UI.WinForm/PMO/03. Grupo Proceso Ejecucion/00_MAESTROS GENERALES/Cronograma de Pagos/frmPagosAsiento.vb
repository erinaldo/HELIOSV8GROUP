Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmPagosAsiento
    Inherits frmMaster

    Dim docCompra As documentocompra


    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    'Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property lblTipoCambioOriginal() As Decimal
    Public Property ListaMontos As List(Of documentocompra)
    Public Property ListaMontosAsiento As List(Of documentoLibroDiarioDetalle)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvPagosVarios)
        'GridCFG2(GridGroupingControl1)
        'GetTableGridConcepto2()
        'GridCFG(dgvDistribucionME)
        'ObtenerTablaGenerales()
        'txtFechaTrans.Value = Date.Now
        'Me.WindowState = FormWindowState.Maximized
        'txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
        'txtPeriodo.Value = PeriodoGeneral
        txttipocambiop.Value = TmpTipoCambioTransaccionVenta
    End Sub


#Region "Metodos"


    Public Sub GrabarPagoAsiento()
        Dim libroSA As New documentoLibroDiarioSA
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
        'Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        'datos.Clear()
        Try
            With ndocumento
                '.idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                .tipoDoc = cajaSeleccionada.tipoDoc
                .fechaProceso = cajaSeleccionada.fechatransferencia
                .idEntidad = Val(txtProveedor.Tag)
                .entidad = txtProveedor.Text
                .tipoEntidad = txttipoProveedor.Text
                .nrodocEntidad = txtNumIdent.Text
                .idOrden = Nothing
                .tipoOperacion = "9907"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = cajaSeleccionada.fechatransferencia
            End With

            With ndocumentoCaja
                .codigoLibro = "1"
                .tipoOperacion = "9907"
                .periodo = PeriodoGeneral
                '.idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                .tipoDocPago = cajaSeleccionada.tipoDoc
                If cajaSeleccionada.tipoDoc = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = cajaSeleccionada.txtNumOper
                    .ctaCorrienteDeposito = cajaSeleccionada.CuentaCorriente
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cajaSeleccionada.bancoEntidad
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "SI"
                ElseIf cajaSeleccionada.tipoDoc = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = cajaSeleccionada.txtNumOper
                    .ctaCorrienteDeposito = Nothing
                    .bancoEntidad = cajaSeleccionada.bancoEntidad
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "SI"
                    '.ctaIntebancaria = txtCtaInterbancaria.Text
                ElseIf cajaSeleccionada.tipoDoc = "007" Then ' cheques
                    '.numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "NO"
                ElseIf cajaSeleccionada.tipoDoc = "111" Then
                    '.numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "NO"
                ElseIf cajaSeleccionada.tipoDoc = "109" Then
                    '.numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .entregado = "NO"
                End If
                .moneda = cajaSeleccionada.moneda
                .entidadFinanciera = cajaSeleccionada.depositohijo
                .tipoCambio = CDec(cajaSeleccionada.tipocambio).ToString("N3")
                .montoSoles = cajaSeleccionada.importe
                .montoUsd = cajaSeleccionada.importeme
                .glosa = "Por Pago Cronograma"
                .usuarioModificacion = cajaSeleccionada.depositohijo
                .fechaModificacion = cajaSeleccionada.fechatransferencia
                '.DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                '.DeudaEvalME = CDec(lblDeudaPendienteme.Text)
                .codigoProveedor = CInt(txtProveedor.Tag)
            End With

            ndocumento.documentoCaja = ndocumentoCaja

            'For Each i As Record In dgvPagosVarios.Table.Records
            For Each i As Record In dgvPagosVarios.Table.Records

                If CDec(i.GetValue("pago")) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = cajaSeleccionada.fechatransferencia
                    'ndocumentoCajaDetalle.idItem = i.GetValue("iditem")
                    ndocumentoCajaDetalle.DetalleItem = i.GetValue("detalle")

                    Select Case cajaSeleccionada.moneda
                        Case 1
                            ndocumentoCajaDetalle.moneda = cajaSeleccionada.moneda
                            ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("pago"))
                            ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("pagome"))
                            If cboMonedaProveedor.Text = "NACIONAL" Then
                                ndocumentoCajaDetalle.monedaDoc = "1"
                            ElseIf cboMonedaProveedor.Text = "EXTRANJERA" Then
                                ndocumentoCajaDetalle.monedaDoc = "2"
                            End If
                        Case 2


                            If txtmonedaprog.Text = "EXTRANJERO" Then
                                ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("pagome") * TmpTipoCambio).ToString("N2")
                                ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("pagome"))
                                ndocumentoCajaDetalle.moneda = cajaSeleccionada.moneda

                            ElseIf txtmonedaprog.Text = "NACIONAL" Then
                                ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("pago"))
                                ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("pagome"))
                                ndocumentoCajaDetalle.moneda = cajaSeleccionada.moneda
                            End If

                            If cboMonedaProveedor.Text = "NACIONAL" Then
                                ndocumentoCajaDetalle.monedaDoc = "1"
                            ElseIf cboMonedaProveedor.Text = "EXTRANJERA" Then
                                ndocumentoCajaDetalle.monedaDoc = "2"
                            End If
                    End Select



                    ndocumentoCajaDetalle.entregado = "SI"
                    ndocumentoCajaDetalle.tipoCambioTransacc = CDec(cajaSeleccionada.tipocambio).ToString("N3")

                    ndocumentoCajaDetalle.documentoAfectado = i.GetValue("idDocumento")
                    ndocumentoCajaDetalle.usuarioModificacion = CStr(cajaSeleccionada.depositohijo)
                    ndocumentoCajaDetalle.fechaModificacion = cajaSeleccionada.fechatransferencia
                    ndocumentoCajaDetalle.idCajaPadre = cajaSeleccionada.depositohijo
                    ndocumentoCajaDetalle.documentoAfectadodetalle = i.GetValue("idsecuencia")
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cajaSeleccionada.tipoDoc
                Case "109", "003", "001"
                    'asiento = asientoCaja()
                    asiento = asientoCajaModulo()
                    ListaAsiento.Add(asiento)
                    ndocumento.asiento = ListaAsiento
                Case "007", "111"
                    cajaUsarioBE = Nothing
            End Select

            Dim iddoc As Integer


            iddoc = documentoCajaSA.SaveGroupCajaMEAsiento(ndocumento, cajaUsarioBE, ListadocumentoCajaDetalle2)


            'UpdateGasto(CInt(lblIdCronograma.Text), "PG", iddoc)
            'UpdateGastoListaAsiento(iddoc)
            'datos.Add(n)
            Dim datos As List(Of item) = item.Instance()
            datos.Clear()
            Dim c As New item
            c.idItem = iddoc
            ' c.idItem = 1
            datos.Add(c)
            'Dispose()


            Label2.Text = "Transacción realizada con éxito!"
            Label2.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            Label2.Text = ex.Message
            Label2.Image = My.Resources.warning2
        End Try
    End Sub


    Function Glosa() As String
        Dim strGlosa As String = Nothing
        strGlosa = "Por pagos de otras obligaciones"
        Return strGlosa
    End Function

    Function asientoCajaModulo() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = PeriodoGeneral
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'nAsiento.idEntidad = lblIdProveedor
        nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.nombreEntidad = txtProveedor.Text
        'nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.tipoEntidad = txttipoProveedor.Text
        nAsiento.fechaProceso = cajaSeleccionada.fechatransferencia
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Finanzas
        'correccin asientos
        nAsiento.importeMN = cajaSeleccionada.importe ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = cajaSeleccionada.importeme  ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        'For Each i As DataGridViewRow In dgvDetalleItems.Rows

        'aquiiiiiiiiiiiiiiiiii!()
        For Each i As Record In dgvPagosVarios.Table.Records



            'For Each i As DataGridViewRow In dgvPagosVarios.Rows
            If CDec(i.GetValue("pago")) > 0 Then

                Select Case cajaSeleccionada.moneda
                    Case 1
                        If (cajaSeleccionada.moneda = 1 And txtmonedaprog.Text = "EXTRANJERO") Then
                            nAsiento.movimiento.Add(AS_HaberAsiento(i.GetValue("detalle"), i.GetValue("cuenta"), i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))

                        ElseIf (cajaSeleccionada.moneda = 1 And txtmonedaprog.Text = "NACIONAL") Then
                            nAsiento.movimiento.Add(AS_HaberAsiento(i.GetValue("detalle"), i.GetValue("cuenta"), i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))

                        End If
                    Case 2
                        If (cajaSeleccionada.moneda = 2 And txtmonedaprog.Text = "EXTRANJERO") Then
                            nAsiento.movimiento.Add(AS_HaberAsiento(i.GetValue("detalle"), i.GetValue("cuenta"), i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))
                        ElseIf (cajaSeleccionada.moneda = 2 And txtmonedaprog.Text = "NACIONAL") Then
                            nAsiento.movimiento.Add(AS_HaberAsiento(i.GetValue("detalle"), i.GetValue("cuenta"), i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))
                        End If
                End Select
            End If
        Next

        'Corregir
        'For Each r As Record In dgvDiferencia.Table.Records

        For Each r In listamov



            Select Case cajaSeleccionada.moneda
                Case 1 '    nacional
                    'Select Case tb19.ToggleState
                    'Case ToggleButton2.ToggleButtonState.OFF 'dolares


                    If txtmonedaprog.Text = "EXTRANJERO" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = r.monto
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, "4212", lblNomProveedor))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1)
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, "4212", lblNomProveedor))
                        End If

                    End If

                    'Case ToggleButton2.ToggleButtonState.ON 'soles
                    If txtmonedaprog.Text = "NACIONAL" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = CDec(r.monto)
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1)
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                        End If
                    End If
                    'End Select

                Case 2 ' extranjero
                    'Select Case tb19.ToggleState
                    'Case ToggleButton2.ToggleButtonState.OFF 'dolares
                    If txtmonedaprog.Text = "EXTRANJERO" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = CDec((r.monto)).ToString("N2")
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1).ToString("N2")
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                        End If
                    End If
                    'Case ToggleButton2.ToggleButtonState.ON 'soles
                    If txtmonedaprog.Text = "NACIONAL" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = CDec((r.monto)).ToString("N2")
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1).ToString("N2")
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                        End If
                    End If
                    ' End Select
            End Select

        Next

        Return nAsiento
    End Function

    Public Function AS_HaberCajaDiferencia(cMonto As Decimal, cMontoUS As Decimal, asientoDestino As String, cuenta As String, descripcion As String) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = cuenta,
      .descripcion = descripcion,
      .tipo = asientoDestino,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento

    End Function

    Public Function AS_HaberAsiento(descrip As String, cuentaAsiento As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = cuentaAsiento,
      .descripcion = descrip,
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_DebeCajaDiferencia(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal, asientoDestino As String) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = asientoDestino,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
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
              .usuarioActualizacion = cajaSeleccionada.depositohijo}
        Return nMovimiento
    End Function



    Sub listaAsientosPorPagar(lista As List(Of documentoLibroDiarioDetalle))

        Dim objLista As New DocumentoCajaDetalleSA
        Dim objLista2 As New documentoAnticipoDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        'Dim cTotalmn As Decimal = 0
        'Dim cTotalme As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim tablaSA As New tablaDetalleSA
        'Dim nombredoc As String

        Dim deudatotal As Decimal = CDec(0.0)
        Dim deudatotalme As Decimal = CDec(0.0)


        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        ' Dim lista As New List(Of documentoCajaDetalle)

        dgvPagosVarios.TableDescriptor.Columns.Clear()
        dgvPagosVarios.TableDescriptor.Columns.Add("idDocumento")
        dgvPagosVarios.TableDescriptor.Columns(0).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(0).HeaderText = "idDocumento"
        dgvPagosVarios.TableDescriptor.Columns(0).MappingName = "idDocumento"

        dgvPagosVarios.TableDescriptor.Columns.Add("idsecuencia")
        dgvPagosVarios.TableDescriptor.Columns(1).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(1).HeaderText = "idsecuencia"
        dgvPagosVarios.TableDescriptor.Columns(1).MappingName = "idsecuencia"

        dgvPagosVarios.TableDescriptor.Columns.Add("comprobante")
        dgvPagosVarios.TableDescriptor.Columns(2).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(2).HeaderText = "comprobante"
        dgvPagosVarios.TableDescriptor.Columns(2).MappingName = "comprobante"

        dgvPagosVarios.TableDescriptor.Columns.Add("detalle")
        dgvPagosVarios.TableDescriptor.Columns(3).Width = 250
        dgvPagosVarios.TableDescriptor.Columns(3).HeaderText = "detalle"
        dgvPagosVarios.TableDescriptor.Columns(3).MappingName = "detalle"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldo")
        dgvPagosVarios.TableDescriptor.Columns(4).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(4).HeaderText = "Deuda"
        dgvPagosVarios.TableDescriptor.Columns(4).MappingName = "saldo"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldome")
        dgvPagosVarios.TableDescriptor.Columns(5).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(5).HeaderText = "saldome"
        dgvPagosVarios.TableDescriptor.Columns(5).MappingName = "saldome"


        dgvPagosVarios.TableDescriptor.Columns.Add("pago")
        dgvPagosVarios.TableDescriptor.Columns(6).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(6).HeaderText = "Monto a Pagar"
        dgvPagosVarios.TableDescriptor.Columns(6).MappingName = "pago"


        ''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("pagome")
        dgvPagosVarios.TableDescriptor.Columns(7).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(7).HeaderText = "Monto a Pagar ME"
        dgvPagosVarios.TableDescriptor.Columns(7).MappingName = "pagome"


        dgvPagosVarios.TableDescriptor.Columns.Add("saldop")
        dgvPagosVarios.TableDescriptor.Columns(8).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(8).HeaderText = "saldop"
        dgvPagosVarios.TableDescriptor.Columns(8).MappingName = "saldop"

        '''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("saldopme")
        dgvPagosVarios.TableDescriptor.Columns(9).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(9).HeaderText = "saldopme"
        dgvPagosVarios.TableDescriptor.Columns(9).MappingName = "saldopme"


        dgvPagosVarios.TableDescriptor.Columns.Add("tipocambio")
        dgvPagosVarios.TableDescriptor.Columns(10).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(10).HeaderText = "T.C"
        dgvPagosVarios.TableDescriptor.Columns(10).MappingName = "tipocambio"

        dgvPagosVarios.TableDescriptor.Columns.Add("cuenta")
        dgvPagosVarios.TableDescriptor.Columns(11).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(11).HeaderText = "cuenta"
        dgvPagosVarios.TableDescriptor.Columns(11).MappingName = "cuenta"



        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("comprobante", GetType(String))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("saldop", GetType(Decimal))
        dt.Columns.Add("saldopme", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        'dt.Columns.Add("iditem", GetType(Integer))


        dgvPagosVarios.TableDescriptor.Columns("idDocumento").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("idsecuencia").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("comprobante").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("detalle").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldo").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldome").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("pago").ReadOnly = False
        dgvPagosVarios.TableDescriptor.Columns("pagome").ReadOnly = False
        dgvPagosVarios.TableDescriptor.Columns("saldop").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldopme").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("tipocambio").ReadOnly = True
        'dgvPagosVarios.TableDescriptor.Columns("iditem").ReadOnly = True

        dgvPagosVarios.TableDescriptor.Columns("saldo").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("saldome").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("pago").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("pagome").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("saldop").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        dgvPagosVarios.TableDescriptor.Columns("saldopme").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        'lista = objLista.ObtenerCuentasPorPagarTodDetails(idprov)

        If txtmonedaprog.Text = "NACIONAL" Then
            For Each i In lista



                'If Not i.EstadoCobro = "PG" Then

                'cTotalmn = CDec(i.importeMN)
                'cTotalme = CDec(i.importeME)


                ' If cTotalmn > 0 Or cTotalme > 0 Then

                'nombredoc = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion

                dt.Rows.Add(i.idDocumento, i.secuencia, i.numeroDoc, i.descripcion, i.importeMN, i.importeME, CDec(0.0), CDec(0.0), CDec(0.0), CDec(0.0), i.tipoCambio, i.cuenta)

                'deudatotal += i.importeMN
                'deudatotalme += i.importeME



                ' End If
                ' End If
            Next


        ElseIf txtmonedaprog.Text = "EXTRANJERO" Then

            For Each i In lista
                ' If Not i.EstadoCobro = "PG" Then
                'detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.montoUsdTransacc) + detalle.ImporteDBME - detalle.ImporteAJme
                'cTotalme = CDec(i.MontoDeudaUSD) - CDec(i.montoUsdTransacc)
                'cTotalmn = CDec(cTotalme * TmpTipoCambio).ToString("N2")
                'If cTotalmn < 0 Then
                '    cTotalmn = 0
                'End If
                'If cTotalme < 0 Then
                '    cTotalme = 0
                'End If
                'saldomn += cTotalmn
                'saldome += cTotalme
                ' If cTotalmn > 0 Or cTotalme > 0 Then


                'nombredoc = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion

                dt.Rows.Add(i.idDocumento, i.secuencia, i.numeroDoc, i.descripcion, i.importeMN, i.importeME, CDec(0.0), CDec(0.0), CDec(0.0), CDec(0.0), i.tipoCambio, i.cuenta)

                'deudatotal += i.importeMN
                'deudatotalme += i.importeME

                '.dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                '                           Nothing, cTotalmn, cTotalme,
                '                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                ' End If
                ' End If
            Next

        End If
        dgvPagosVarios.DataSource = dt
        'dgvPagosVarios.ShowGroupDropArea = False
        'dgvPagosVarios.TableDescriptor.GroupedColumns.Clear()
        'dgvPagosVarios.TableDescriptor.GroupedColumns.Add("comprobante")

        'txtdeudatotal.Value = deudatotal
        'txtdeudatotalme.Value = deudatotalme


        If txtmonedaprog.Text = "NACIONAL" Then
            dgvPagosVarios.TableDescriptor.Columns("saldo").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("saldome").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("pago").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("pagome").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("saldop").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("saldopme").Width = 0

            ' PagoDocumentosAsiento()

        ElseIf txtmonedaprog.Text = "EXTRANJERO" Then
            dgvPagosVarios.TableDescriptor.Columns("saldo").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("saldome").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("pago").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("pagome").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("saldop").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("saldopme").Width = 70
            'PagoDocumentosAsientome()
        End If

    End Sub


    Dim colorx As New GridMetroColors()


    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray

        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F


    End Sub

#End Region

    Private Sub frmPagosAsiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvPagosVarios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPagosVarios.TableControlCellClick

    End Sub

    Private Sub dgvPagosVarios_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPagosVarios.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvPagosVarios.Table.CurrentRecord) Then
            Select Case ColIndex

                Case 7


                    If Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pago") >= 0 Then

                        If Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pago") <= Me.dgvPagosVarios.Table.CurrentRecord.GetValue("saldo") Then

                            Dim colPercepcionME As Decimal = 0
                            colPercepcionME = Math.Round(CDec(Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pago")) / TmpTipoCambio, 2)
                            Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pagome", colPercepcionME)



                            Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldop", Me.dgvPagosVarios.Table.CurrentRecord.GetValue("saldo") - Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pago"))
                            Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldopme", Me.dgvPagosVarios.Table.CurrentRecord.GetValue("saldome") - Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pagome"))

                            'If Me.dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoMN") > 0 Then

                            '    ' Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("chBonif", True)
                            '    ' Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("val", "S")
                            'Else

                            '    'Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("chBonif", False)
                            '    ' Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("val", "N")

                            'End If

                        Else

                            Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pago", CDec(0.0))
                            Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pagome", CDec(0.0))
                            ' MessageBox.Show("Ingrese un Monto Menor o Igual ala deuda")
                            MessageBox.Show("Ingrese un Monto Menor o Igual ala deuda!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                            'Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("chBonif", False)
                            'Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("val", "N")
                        End If

                    Else
                        Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pago", CDec(0.0))
                        Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pagome", CDec(0.0))
                    End If


                    Dim pago As Decimal = CDec(0.0)
                    For Each i As Record In dgvPagosVarios.Table.Records
                        pago += i.GetValue("pago")
                    Next

                    txtmontomn.Value = pago
                    txtmontome.Value = pago / txttipocambiop.Value



                    'calculototalpagos()

            End Select
        End If
    End Sub

    Dim listamov As New List(Of movimiento)
    Dim cajaSeleccionada As New CajaInfo
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim listapagodocumento As New List(Of documentocompra)
        Dim docCompra As New documentocompra
        Dim montotot As Decimal = CDec(0.0)
        Dim montototme As Decimal = CDec(0.0)

        For Each i As Record In dgvPagosVarios.Table.Records

            If i.GetValue("pago") > 0 Then
                docCompra = New documentocompra
                docCompra.idDocumento = i.GetValue("idDocumento")
                docCompra.idCentroCosto = i.GetValue("idsecuencia")
                docCompra.importeTotal = i.GetValue("pago")
                docCompra.importeUS = i.GetValue("pagome")
                docCompra.tipocambio = i.GetValue("tipocambio")
                montotot += i.GetValue("pago")
                montototme += i.GetValue("pagome")

                listapagodocumento.Add(docCompra)
            End If
        Next


        Dim f As New frmcajapagos

        f.StartPosition = FormStartPosition.CenterParent
        f.txtImporteCompramn.Value = montotot
        f.txtImporteComprame.Value = montototme
        f.txtTipoCambio.Value = TmpTipoCambioTransaccionVenta
        f.listaPagosCompra = listapagodocumento
        If txtmonedaprog.Text = "NACIONAL" Then
            f.tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
        ElseIf txtmonedaprog.Text = "EXTRANJERO" Then
            f.tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            cajaSeleccionada = CType(f.Tag, CajaInfo)


            txtCaja.Text = cajaSeleccionada.CajaNombre

        End If



        listamov = f.movimientos()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim pagotot As Decimal = CDec(0.0)
        'For Each i As Record In dgvPagosVarios.Table.Records
        '    pagotot += i.GetValue("pago")
        'Next

        If Not IsNothing(cajaSeleccionada) Then
        Else


            MessageBox.Show("Seleccione una Caja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If cajaSeleccionada.importe = txtmontomn.Value Then
        Else
            MessageBox.Show("Seleccione la caja con el monto a pagar")
            Exit Sub
        End If


        Dim FichaEFSaldo As New GFichaUsuario

        Try

            If txtmontomn.Value > 0 Then



                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    'obteniendo saldo  de la entidad financiera seleccionada
                    Select Case cajaSeleccionada.moneda
                        Case 1
                           

                            GrabarPagoAsiento()
                            
                        Case 2
                       
                            GrabarPagoAsiento()
                            
                    End Select

                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then

                End If
            Else
                'lblEstado.Text = "Ingresar el importe a pagar!"
                'Timer1.Enabled = True
                'PanelError.Visible = True
                'TiempoEjecutar(10)
            End If

        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'Timer1.Enabled = True
            'PanelError.Visible = True
            'TiempoEjecutar(10)

        End Try
        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub
End Class