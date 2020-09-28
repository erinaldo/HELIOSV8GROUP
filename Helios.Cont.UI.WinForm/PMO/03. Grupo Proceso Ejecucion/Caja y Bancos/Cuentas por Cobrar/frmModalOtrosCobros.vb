Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalOtrosCobros
    Public Property Estado() As String
#Region "Métodos"

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
      .cuenta = "1624",
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
        If lblTipo.Text = "Proveedor" Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        ElseIf lblTipo.Text = "Cliente" Then
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.fechaProceso = txtFechaComprobante.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.COBRO_OTROS_CONCEPTOS
        nAsiento.importeMN = nudImporteNac.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = nudImporteExt.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i As DataGridViewRow In dgvDetalleItems.Rows
            If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
                nAsiento.movimiento.Add(AS_DebeCaja(lblCuenta.Text, txtCaja.Text, dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
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
            documentoCajaSA.SaveCajaExcedente(ndocumento)
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

        With frmOtrasCuentasPorCobrar
            If .TabControl1.SelectedTab Is .TabPage2 Then
                strGlosa = "Por cobro doc/: " & .txtIdComprobante.Text & _
         " número: " & .txtNumDoc.Text

            ElseIf .TabControl1.SelectedTab Is .TabPage1 Then
                With .lsvDocs.SelectedItems(0)
                    strGlosa = "Por cobro doc/: " & .SubItems(1).Text & _
 " número: " & .SubItems(2).Text
                End With

            End If

        End With
        Return strGlosa
    End Function
#End Region

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
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

    Private Sub nudTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudTipoCambio.ValueChanged
        nudImporteNac_ValueChanged(sender, e)
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
End Class