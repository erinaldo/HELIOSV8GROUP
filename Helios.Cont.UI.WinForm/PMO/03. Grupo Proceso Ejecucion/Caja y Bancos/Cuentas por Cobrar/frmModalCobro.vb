Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalCobro
    Public Property Estado() As String
#Region "Métodos"
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
                txtIdComprobante.Text = .tipoDoc
                txtComprobante.Text = tablaSA.GetUbicarTablaID(1, .tipoDoc).descripcion
                If .tipoDoc = "109" Then
                    txtNumeroComp.Visible = False
                    txtNumeroComp.Text = .nroDoc
                Else
                    txtNumeroComp.Visible = True
                    txtNumeroComp.Text = .nroDoc
                End If
            End With

            With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)
                If .moneda = "1" Then
                    rbNac.Checked = True
                ElseIf .moneda = "2" Then
                    rbExt.Checked = True
                End If

                txtIDEstablecimientoCaja.Text = .idEstablecimiento
                txtEstablecimientoCaja.Text = establecSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
                txtIdCaja.Text = .entidadFinanciera
                nudTipoCambio.Value = .tipoCambio
                nudImporteNac.Value = .montoSoles
                nudImporteExt.Value = .montoUsd

                With entidadSA.UbicarEntidadPorID(.codigoProveedor).First
                    lblNomCliente.Text = .nombreCompleto
                    lblIdCliente.Text = .idEntidad
                    lblCuentaCliente.Text = .cuentaAsiento
                End With

                With estadoF.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)

                    Select Case .tipo
                        Case "BC"
                            rbBanco.Checked = True
                        Case Else
                            rbEfectivo.Checked = True
                    End Select

                    txtCaja.Text = .descripcion
                    lblCuenta.Text = .cuenta
                End With
            End With
            dgvDetalleItems.Rows.Clear()
            For Each i In documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento)
                dgvDetalleItems.Rows.Add(i.secuencia, i.DetalleItem, itemSA.InvocarProductoID(i.idItem).unidad1, "0.00", i.montoSoles, i.montoUsd, "0.00", "0.00", "0.00", "0.00",
                                         Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE)
            Next


        Catch ex As Exception

        End Try
    End Sub

    Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_HaberCliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = lblCuentaCliente.Text,
      .descripcion = lblNomCliente.Text,
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = "Jiuni"}

        Return nMovimiento


    End Function

    Function asientoCaja() As asiento
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdCliente.Text
        nAsiento.nombreEntidad = lblNomCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFechaComprobante.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.COBRO_VENTA
        nAsiento.importeMN = nudImporteNac.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = nudImporteExt.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                nAsiento.movimiento.Add(AS_DebeCaja(lblCuenta.Text, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
                nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
            End If
        Next

        Return nAsiento
    End Function

    Public Sub Grabar()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            With ndocumento
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idProyecto = GProyectos.IdProyectoActividad
                .tipoDoc = txtIdComprobante.Text
                .fechaProceso = txtFechaComprobante.Value
                .nroDoc = txtNumeroComp.Text
                .idOrden = Nothing
                .tipoOperacion = "01"
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            With ndocumentoCaja
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                .codigoProveedor = lblIdCliente.Text
                .fechaProceso = txtFechaComprobante.Value
                .fechaCobro = txtFechaComprobante.Value
                .tipoDocPago = txtIdComprobante.Text
                .numeroDoc = txtNumeroComp.Text

                .moneda = IIf(rbNac.Checked = True, "1", "2")
                .entidadFinanciera = txtIdCaja.Text
                .numeroOperacion = txtNumeroComp.Text
                .tipoCambio = nudTipoCambio.Value
                .montoSoles = nudImporteNac.Value
                .montoUsd = nudImporteExt.Value
                .glosa = Glosa()
                .entregado = "SI"
                .usuarioModificacion = "Jiuni"
                .fechaModificacion = DateTime.Now
                .DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
            End With

            ndocumento.documentoCaja = ndocumentoCaja


            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = txtFechaComprobante.Value
                ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()
                ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())

                ndocumentoCajaDetalle.entregado = "SI"
                '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0

                ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                ndocumentoCajaDetalle.usuarioModificacion = "Jiuni"
                ndocumentoCajaDetalle.fechaModificacion = Date.Now
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            asiento = asientoCaja()
            ListaAsiento.Add(asiento)
            ndocumento.asiento = ListaAsiento
            '    documentoCajaSA.SaveGroupCaja(ndocumento)
            lblEstado.Text = "Transacción realizada con éxito!"
            lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Public Sub Editar()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            With ndocumento
                .idDocumento = lbldDocCaja.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idProyecto = GProyectos.IdProyectoActividad
                .tipoDoc = txtIdComprobante.Text
                .fechaProceso = txtFechaComprobante.Value
                .nroDoc = txtNumeroComp.Text
                .idOrden = Nothing
                .tipoOperacion = "01"
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            With ndocumentoCaja
                .idDocumento = lbldDocCaja.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                .codigoProveedor = lblIdCliente.Text
                .fechaProceso = txtFechaComprobante.Value
                .fechaCobro = txtFechaComprobante.Value
                .tipoDocPago = txtIdComprobante.Text
                .numeroDoc = txtNumeroComp.Text
                .moneda = IIf(rbNac.Checked = True, "1", "2")
                .entidadFinanciera = txtIdCaja.Text
                .numeroOperacion = txtNumeroComp.Text
                .tipoCambio = nudTipoCambio.Value
                .montoSoles = nudImporteNac.Value
                .montoUsd = nudImporteExt.Value
                .glosa = Glosa()
                .entregado = "SI"
                .usuarioModificacion = "Jiuni"
                .fechaModificacion = DateTime.Now
            End With

            ndocumento.documentoCaja = ndocumentoCaja

            For Each i As DataGridViewRow In dgvDetalleItems.Rows
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.idDocumento = lbldDocCaja.Text
                ndocumentoCajaDetalle.secuencia = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                ndocumentoCajaDetalle.fecha = txtFechaComprobante.Value
                ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
                ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()
                ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
                ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
              
                ndocumentoCajaDetalle.entregado = "SI"
                '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
              
                ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                ndocumentoCajaDetalle.Action = Business.Entity.BaseBE.EntityAction.UPDATE
                ndocumentoCajaDetalle.usuarioModificacion = "Jiuni"
                ndocumentoCajaDetalle.fechaModificacion = Date.Now
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            asiento = asientoCaja()
            ListaAsiento.Add(asiento)
            ndocumento.asiento = ListaAsiento
            documentoCajaSA.EditarGroupCaja(ndocumento)
            lblEstado.Text = "Transacción realizada con éxito!"
            lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Function Glosa() As String
        Dim strGlosa As String = Nothing

        With frmCuentasPorCobrar
            If .TabControl1.SelectedTab Is .TabPage2 Then
                strGlosa = "Por cobro de ventas doc/: " & .txtIdComprobante.Text & _
         " número: " & .txtNumDoc.Text

            ElseIf .TabControl1.SelectedTab Is .TabPage1 Then
                With .lsvDocs.SelectedItems(0)
                    strGlosa = "Por cobro de ventas doc/: " & .SubItems(1).Text & _
 " número: " & .SubItems(2).Text
                End With

            End If

        End With
        Return strGlosa
    End Function
    Public Sub ObtenerEFPredeterminada()
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        ef = efSA.ObtenerEstadosFinancierosPredeterminado(GEstableciento.IdEstablecimiento)
        With ef
            txtIdCaja.Text = .idestado
            txtCaja.Text = .descripcion
            lblCuenta.Text = .cuenta
            If .codigo = "1" Then
                rbNac.Checked = True
            Else
                rbExt.Checked = True
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
    End Sub
#End Region

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Glosa()
    End Sub

    Private Sub GuardarToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton2.Click
        If nudImporteNac.Value > 0 Then
            If Estado = ENTITY_ACTIONS.INSERT Then
                Grabar()
            ElseIf Estado = ENTITY_ACTIONS.UPDATE Then
                Editar()
            End If
        Else
            lblEstado.Text = "Ingresar el importe a pagar!"
            lblEstado.Image = My.Resources.warning2
        End If

    End Sub

    Private Sub Panel3_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub
    Sub CalculoGRID()
        Dim valDolares As Decimal = 0
        Dim nudvalueImporte As Decimal = nudImporteNac.Value
        Dim nudSaldo As Decimal = nudvalueImporte
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0

        valDolares = Math.Round(nudImporteNac.Value / nudTipoCambio.Value, 2)
        nudImporteExt.Value = valDolares

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
        If rbNac.Checked = True Then
            If nudTipoCambio.Value > 0 Then
                If CDec(nudImporteNac.Value) > CDec(lblDeudaPendiente.Text) Then
                    MsgBox("El valor ingreso excede el valor permitido.", MsgBoxStyle.Information, String.Concat("Monto permitido (S/.):", Space(2), lblDeudaPendiente.Text))
                    nudImporteNac.Value = 0
                    nudImporteExt.Value = 0
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub nudImporteNac_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudImporteNac.ValueChanged
        If txtIdCaja.Text.Trim.Length > 0 Then
            If Estado = ENTITY_ACTIONS.INSERT Then
                CalculoSoles()
                CalculoGRID()
            ElseIf Estado = ENTITY_ACTIONS.UPDATE Then
                CalculoGRID()
            End If
        Else
            lblEstado.Text = "Seleccione Entidad Financiera o Caja Efectiva."
            lblEstado.Image = My.Resources.warning2
        End If
    End Sub

    Private Sub frmModalCobro_LocationChanged(sender As Object, e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub LinkTipoDoc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkTipoDoc.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "1"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdComprobante.Text = datos(0).ID
        '        txtComprobante.Text = datos(0).NombreCampo
        '        Glosa()
        '        If txtIdComprobante.Text = "109" Then
        '            txtNumeroComp.Clear()
        '            txtNumeroComp.Visible = False
        '        Else
        '            txtNumeroComp.Clear()
        '            txtNumeroComp.Visible = True
        '        End If
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub
    Sub CajaSelecionadaShowed()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()

        'With frmModalEstadosFinancieros
        '    .ObtenerEstadosFinancieros(txtIdEstablecimientoCaja.Text, IIf(rbEfectivo.Checked = True, "EF", "BC"), IIf(rbNac.Checked = True, "1", "2"))
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdCaja.Text = datos(0).ID
        '        txtCaja.Text = datos(0).NombreCampo
        '        lblCuenta.Text = datos(0).Codigo
        '        glosa()
        '        'txtNumCaja.Focus()
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Call CajaSelecionadaShowed()
    End Sub

    Private Sub nudTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudTipoCambio.ValueChanged
        nudImporteNac_ValueChanged(sender, e)
    End Sub

    Private Sub nudImporteExt_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudImporteExt.ValueChanged

    End Sub
End Class