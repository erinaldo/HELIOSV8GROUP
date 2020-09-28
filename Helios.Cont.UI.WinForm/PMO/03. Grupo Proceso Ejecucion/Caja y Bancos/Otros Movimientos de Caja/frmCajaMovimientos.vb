Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCajaMovimientos
    Public Property ListaAsientos As New List(Of asiento)
    Public Property manipulacionEstado() As String
#Region "Métodos"
    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim alEFSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim establecimientoSA As New establecimientoSA
        Try
            With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)

                Select Case .tipoOperacion
                    Case "TEC"
                        cboMovimiento.Text = "TRANSFERENCIA ENTRE CAJAS"
                    Case "OSC"
                        cboMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                    Case "OEC"
                        cboMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                End Select

                lblIdDocumento.Text = .idDocumento
                txtFecha.Value = .fechaCobro
                lblPeriodo.Text = .periodo
                txtTipoDoc.ValueMember = .tipoDocPago
                txtTipoDoc.Text = tablaSA.GetUbicarTablaID(1, .tipoDocPago).descripcion
                txtNumero.Text = .numeroDoc
                Select Case .moneda
                    Case 1
                        cboMoneda.Text = "MONEDA NACIONAL"
                    Case 2
                        cboMoneda.Text = "MONEDA EXTRANJERA"
                End Select

                With alEFSA.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)
                    txtEstablecimientoDestino.ValueMember = .idEstablecimiento
                    txtEstablecimientoDestino.Text = establecimientoSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
                    txtCajaDestino.ValueMember = .idestado
                    txtCajaDestino.Text = .descripcion
                    txtCuentaD.Text = .cuenta
                    Select Case .tipo
                        Case "EF"
                            cboTipoCuentaD.Text = "EFECTIVO"
                        Case "BC"
                            cboTipoCuentaD.Text = "BANCO"
                    End Select
                End With

                txtTipocambio.Value = .tipoCambio
                txtImporteMN.Value = .montoSoles
                txtImporteME.Value = .montoUsd
                txtGlosa.Text = .glosa
            End With

            With documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento).First
                lblSecuenciaDetalle.Text = .secuencia
            End With
            cboMovimiento.Enabled = False
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub


    Public Sub AsientoContableTransferencia()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento

        asientoBL = New asiento
        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
        asientoBL.idEntidad = txtCajaDestino.ValueMember
        asientoBL.nombreEntidad = txtCajaDestino.Text
        asientoBL.tipoEntidad = IIf(cboTipoCuentaD.Text = "EFECTIVO", "EF", "BC")
        asientoBL.fechaProceso = txtFecha.Value
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"
        asientoBL.tipoAsiento = ASIENTO_CONTABLE.TRANSFERENCIA_CAJA
        asientoBL.importeMN = CDec(txtImporteMN.Value)
        asientoBL.importeME = CDec(txtImporteME.Value)
        asientoBL.glosa = txtGlosa.Text


        nMovimiento = New movimiento
        nMovimiento.cuenta = txtCuentaO.Text
        nMovimiento.descripcion = txtCajaOrigen.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(txtImporteMN.Value)
        nMovimiento.montoUSD = CDec(txtImporteME.Value)
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = txtCuentaD.Text
        nMovimiento.descripcion = txtCajaDestino.Text
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(txtImporteMN.Value)
        nMovimiento.montoUSD = CDec(txtImporteME.Value)
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)
        ListaAsientos.Add(asientoBL)
    End Sub

    Public Sub AsientoContableCaja()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento

        asientoBL = New asiento
        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
        asientoBL.idEntidad = txtCajaDestino.ValueMember
        asientoBL.nombreEntidad = txtCajaDestino.Text
        asientoBL.tipoEntidad = IIf(cboTipoCuentaD.Text = "EFECTIVO", "EF", "BC")
        asientoBL.fechaProceso = txtFecha.Value
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"
        Select Case cboMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS_CAJA
            Case "OTRAS SALIDAS DE CAJA"
                asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_SALIDAS_CAJA
        End Select
        asientoBL.importeMN = CDec(txtImporteMN.Value)
        asientoBL.importeME = CDec(txtImporteME.Value)
        asientoBL.glosa = txtGlosa.Text


        Select Case cboMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                nMovimiento = New movimiento
                nMovimiento.cuenta = txtCuentaD.Text
                nMovimiento.descripcion = txtCajaDestino.Text
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(txtImporteMN.Value)
                nMovimiento.montoUSD = CDec(txtImporteME.Value)
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)


                nMovimiento = New movimiento
                nMovimiento.cuenta = "2000"
                nMovimiento.descripcion = "Por regularizar"
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(txtImporteMN.Value)
                nMovimiento.montoUSD = CDec(txtImporteME.Value)
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
            Case "OTRAS SALIDAS DE CAJA"

                nMovimiento = New movimiento
                nMovimiento.cuenta = "3000"
                nMovimiento.descripcion = "Por regularizar"
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(txtImporteMN.Value)
                nMovimiento.montoUSD = CDec(txtImporteME.Value)
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = txtCuentaD.Text
                nMovimiento.descripcion = txtCajaDestino.Text
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(txtImporteMN.Value)
                nMovimiento.montoUSD = CDec(txtImporteME.Value)
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)

        End Select
        ListaAsientos.Add(asientoBL)
    End Sub

    Public Sub GrabarTransferenciaCaja()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = txtTipoDoc.ValueMember
            .fechaProceso = txtFecha.Value
            .nroDoc = 0 ' txtNumeroComp.Text
            .idOrden = Nothing
            .tipoOperacion = "01"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            '   .idDocumento = lblIdDocumento.Text
            .periodo = lblPeriodo.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = txtTipoDoc.ValueMember
            .codigoProveedor = Nothing 'txtPersona.ValueMember
            .fechaProceso = txtFecha.Value
            .fechaCobro = txtFecha.Value
            .tipoDocPago = txtTipoDoc.ValueMember
            .numeroDoc = 0 ' txtNumeroComp.Text
            .moneda = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            .entidadFinanciera = txtCajaOrigen.ValueMember
            .entidadFinancieraDestino = txtCajaDestino.ValueMember
            .tipoOperacion = "TEC"
            .numeroOperacion = txtNumero.Text.Trim
            .tipoCambio = txtTipocambio.Value
            .montoSoles = txtImporteMN.Value
            .montoUsd = txtImporteME.Value
            .glosa = txtGlosa.Text.Trim
            .entregado = "SI"
            .usuarioModificacion = "Jiuni"
            .fechaModificacion = DateTime.Now
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.fecha = txtFecha.Value
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = "Por transferencia de dinero"
        ndocumentoCajaDetalle.montoSoles = txtImporteMN.Value
        ndocumentoCajaDetalle.montoUsd = txtImporteME.Value
        ndocumentoCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

        AsientoContableTransferencia()
        ndocumento.asiento = ListaAsientos
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        documentoCajaSA.SaveGroupCajaOtrosMovimientos(ndocumento)
        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub

    Public Sub GrabarOtrosMovimientos()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = txtTipoDoc.ValueMember
            .fechaProceso = txtFecha.Value
            .nroDoc = txtNumero.Text
            .idOrden = Nothing
            .tipoOperacion = "01"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            '   .idDocumento = lblIdDocumento.Text
            .periodo = lblPeriodo.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = txtTipoDoc.ValueMember
            .codigoProveedor = Nothing 'txtPersona.ValueMember
            .fechaProceso = txtFecha.Value
            .fechaCobro = txtFecha.Value
            .tipoDocPago = txtTipoDoc.ValueMember
            .numeroDoc = txtNumero.Text
            .moneda = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            Select Case cboMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .tipoMovimiento = "DC"
                    .tipoOperacion = "OEC"
                    .entidadFinanciera = txtCajaDestino.ValueMember
                Case "OTRAS SALIDAS DE CAJA"
                    .tipoMovimiento = "PG"
                    .tipoOperacion = "OSC"
                    .entidadFinanciera = txtCajaDestino.ValueMember
            End Select
            .numeroOperacion = txtNumero.Text.Trim
            .tipoCambio = txtTipocambio.Value
            .montoSoles = txtImporteMN.Value
            .montoUsd = txtImporteME.Value
            .glosa = txtGlosa.Text.Trim
            .entregado = "SI"
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = DateTime.Now
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.fecha = txtFecha.Value
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = txtGlosa.Text
        ndocumentoCajaDetalle.montoSoles = txtImporteMN.Value
        ndocumentoCajaDetalle.montoUsd = txtImporteME.Value
        ndocumentoCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

        AsientoContableCaja()
        ndocumento.asiento = ListaAsientos
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        Dim xCodigoDoc As Integer = documentoCajaSA.SaveGroupCajaOtrosMovimientosSingle(ndocumento)


        Dim n As New ListViewItem(xCodigoDoc)
        n.SubItems.Add(txtFecha.Value)
        n.SubItems.Add(cboMovimiento.Text)
        n.SubItems.Add(txtTipoDoc.Text)
        n.SubItems.Add(txtNumero.Text)
        Select Case cboMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(txtCajaDestino.Text)
            Case "OTRAS SALIDAS DE CAJA"
                n.SubItems.Add(txtCajaDestino.Text)
                n.SubItems.Add(String.Empty)
        End Select
        Select Case cboMoneda.Text
            Case "MONEDA NACIONAL"
                n.SubItems.Add(1)
            Case Else
                n.SubItems.Add(2)
        End Select
        n.SubItems.Add(FormatNumber(txtImporteMN.Value, 2))
        n.SubItems.Add(FormatNumber(txtTipocambio.Value, 2))
        n.SubItems.Add(FormatNumber(txtImporteME.Value, 2))

        With frmMantenimientoCaja
            .lsvProduccion.Items.Add(n)
        End With

        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub

    Public Sub UPDATEOtrosMovimientos()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        With ndocumento
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = txtTipoDoc.ValueMember
            .fechaProceso = txtFecha.Value
            .nroDoc = txtNumero.Text
            .idOrden = Nothing
            .tipoOperacion = "01"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            .idDocumento = lblIdDocumento.Text
            .periodo = lblPeriodo.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = txtTipoDoc.ValueMember
            .codigoProveedor = Nothing 'txtPersona.ValueMember
            .fechaProceso = txtFecha.Value
            .fechaCobro = txtFecha.Value
            .tipoDocPago = txtTipoDoc.ValueMember
            .numeroDoc = txtNumero.Text
            .moneda = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            Select Case cboMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"
                    .tipoMovimiento = "DC"
                    .tipoOperacion = "OEC"
                    .entidadFinanciera = txtCajaDestino.ValueMember
                Case "OTRAS SALIDAS DE CAJA"
                    .tipoMovimiento = "PG"
                    .tipoOperacion = "OSC"
                    .entidadFinanciera = txtCajaDestino.ValueMember
            End Select
            .numeroOperacion = txtNumero.Text.Trim
            .tipoCambio = txtTipocambio.Value
            .montoSoles = txtImporteMN.Value
            .montoUsd = txtImporteME.Value
          
            .glosa = txtGlosa.Text.Trim
            .entregado = "SI"
            .usuarioModificacion = "Jiuni"
            .fechaModificacion = DateTime.Now
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.idDocumento = lblIdDocumento.Text
        ndocumentoCajaDetalle.secuencia = lblSecuenciaDetalle.Text
        ndocumentoCajaDetalle.fecha = txtFecha.Value
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = txtGlosa.Text
        ndocumentoCajaDetalle.montoSoles = txtImporteMN.Value
        ndocumentoCajaDetalle.montoUsd = txtImporteME.Value
      
        ndocumentoCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
       
        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.usuarioModificacion = "Jiuni"
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

        AsientoContableCaja()
        ndocumento.asiento = ListaAsientos
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        documentoCajaSA.UpdateGroupCajaOtrosMovimientosSingle(ndocumento)
        lblEstado.Text = "Caja actualizada correctamente!"
        lblEstado.Image = My.Resources.ok4


        With frmMantenimientoCaja
            With .lsvProduccion.SelectedItems(0)
                .SubItems(1).Text = txtFecha.Value
                .SubItems(2).Text = cboMovimiento.Text
                .SubItems(3).Text = txtTipoDoc.Text
                .SubItems(4).Text = txtNumero.Text
                Select Case cboMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        .SubItems(5).Text = String.Empty
                        .SubItems(6).Text = txtCajaDestino.Text
                    Case "OTRAS SALIDAS DE CAJA"
                        .SubItems(5).Text = txtCajaDestino.Text
                        .SubItems(6).Text = String.Empty
                End Select
                Select Case cboMoneda.Text
                    Case "MONEDA NACIONAL"
                        .SubItems(7).Text = 1
                    Case Else
                        .SubItems(7).Text = 2
                End Select

                .SubItems(8).Text = FormatNumber(txtImporteMN.Value, 2)
                .SubItems(9).Text = FormatNumber(txtTipocambio.Value, 2)
                .SubItems(10).Text = FormatNumber(txtImporteME.Value, 2)
            End With
        End With

        Dispose()
    End Sub

    Sub Calculo()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipocambio.Value

        If tcambio > 0 Then
            Imn = txtImporteMN.Value
            txtImporteME.Value = Math.Round(Imn / tcambio, 2)
        End If
    End Sub
#End Region

    Private Sub cboMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboMoneda.KeyPress
        e.Handled = True
    End Sub


    Private Sub cboMoneda_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboMoneda.TextChanged

    End Sub

    Private Sub cboMovimiento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboMovimiento.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboMovimiento_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboMovimiento.TextChanged
        Select Case cboMovimiento.Text
            Case "TRANSFERENCIA ENTRE CAJAS"
                Label13.Text = "CAJA DE DESTINO:"
                Panel4.Visible = True
                gbxOrigen.Visible = True
                txtGlosa.Text = "Por tansferencia de dinero entre cajas."
            Case "OTRAS ENTRADAS A CAJA"
                Panel4.Visible = True
                Label13.Text = "CAJA DE DESTINO:"
                gbxOrigen.Visible = False
                txtGlosa.Text = "Por otras entradas de dinero a caja."
            Case "OTRAS SALIDAS DE CAJA"
                Panel4.Visible = True
                Label13.Text = "CAJA DE ORIGEN:"
                gbxOrigen.Visible = False
                txtGlosa.Text = "Por otras salidas de dinero a caja."
        End Select
        txtCuentaD.Clear()
        txtCuentaO.Clear()
        txtCajaOrigen.Clear()
        txtCajaDestino.Clear()
        txtFecha.Select()
        txtFecha.Focus()
    End Sub

    Private Sub cboTipoCuentaO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoCuentaO.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboTipoCuentaO_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoCuentaO.TextChanged

    End Sub

    Private Sub cboTipoCuentaD_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoCuentaD.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboTipoCuentaD_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoCuentaD.TextChanged

    End Sub

    Private Sub frmCajaMovimientos_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "1"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtTipoDoc.ValueMember = datos(0).ID
        '        txtTipoDoc.Text = datos(0).NombreCampo
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalEstablecimientoCaja
        '    .StrParametroCarga = "ET"
        '    .ObtenerEstablecimientos()
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then

        '        txtEstablecimientoOrigen.ValueMember = datos(0).ID
        '        txtEstablecimientoOrigen.Text = datos(0).NombreCampo
        '    Else

        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalEstablecimientoCaja
        '    .StrParametroCarga = "ET"
        '    .ObtenerEstablecimientos()
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then

        '        txtEstablecimientoDestino.ValueMember = datos(0).ID
        '        txtEstablecimientoDestino.Text = datos(0).NombreCampo
        '    Else

        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()

        'With frmModalEstadosFinancieros
        '    .ObtenerEstadosFinancieros(txtEstablecimientoOrigen.ValueMember, IIf(cboTipoCuentaO.Text = "EFECTIVO", "EF", "BC"), IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2"))
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtCajaOrigen.ValueMember = datos(0).ID
        '        txtCajaOrigen.Text = datos(0).NombreCampo
        '        txtCuentaO.Text = datos(0).Codigo
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        Select Case cboMovimiento.Text
            Case "TRANSFERENCIA ENTRE CAJAS"
                If Not txtCajaOrigen.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Debe Seleccionar una caja de origen!"
                    txtCajaOrigen.Select()
                    txtCajaOrigen.Focus()
                    Exit Sub
                End If

                'With frmModalEstadosFinancieros
                '    .ObtenerEstadosFinancieros(txtEstablecimientoDestino.ValueMember, IIf(cboTipoCuentaD.Text = "EFECTIVO", "EF", "BC"), IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2"))
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                '    If datos.Count > 0 Then
                '        If datos(0).NombreCampo = txtCajaOrigen.Text.Trim Then
                '            lblEstado.Text = "Debe ingresar una caja diferente a la de origen!"
                '            Me.Cursor = Cursors.Arrow
                '            Exit Sub
                '        End If
                '        txtCajaDestino.ValueMember = datos(0).ID
                '        txtCajaDestino.Text = datos(0).NombreCampo
                '        txtCuentaD.Text = datos(0).Codigo
                '    End If
                'End With

            Case "OTRAS ENTRADAS A CAJA"
                'With frmModalEstadosFinancieros
                '    .ObtenerEstadosFinancieros(txtEstablecimientoDestino.ValueMember, IIf(cboTipoCuentaD.Text = "EFECTIVO", "EF", "BC"), IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2"))
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                '    If datos.Count > 0 Then
                '        txtCajaDestino.ValueMember = datos(0).ID
                '        txtCajaDestino.Text = datos(0).NombreCampo
                '        txtCuentaD.Text = datos(0).Codigo
                '    End If
                'End With
            Case "OTRAS SALIDAS DE CAJA"
                'With frmModalEstadosFinancieros
                '    .ObtenerEstadosFinancieros(txtEstablecimientoDestino.ValueMember, IIf(cboTipoCuentaD.Text = "EFECTIVO", "EF", "BC"), IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2"))
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                '    If datos.Count > 0 Then
                '        txtCajaDestino.ValueMember = datos(0).ID
                '        txtCajaDestino.Text = datos(0).NombreCampo
                '        txtCuentaD.Text = datos(0).Codigo
                '    End If
                'End With
        End Select

       
    End Sub

    Private Sub txtTipoCambio_TextChanged(sender As System.Object, e As System.EventArgs)
        Calculo()
    End Sub

    Private Sub txtImporteMN_TextChanged(sender As System.Object, e As System.EventArgs)
        Calculo()
    End Sub

    Private Sub txtTipocambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTipocambio.ValueChanged
        Calculo()
    End Sub

    Private Sub txtImporteMN_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtImporteMN.ValueChanged
        Calculo()
    End Sub

    Private Sub QRibbonApplicationButton1_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRibbonApplicationButton1.ItemActivating
        If Not cboMovimiento.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe seleccionar el método de trabajo!"
            cboMovimiento.DroppedDown = True
            Exit Sub
        End If

        If Not txtTipoDoc.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe ingresar un comprobante!"
            Exit Sub
        End If

        If Not txtNumero.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe ingresar un número de comprobante!"
            Exit Sub
        End If

     

        If Not txtTipocambio.Value > 0 Then
            lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
            Exit Sub
        End If

        If Not txtImporteMN.Value > 0 Then
            lblEstado.Text = "Debe ingresar un importe mayor a cero!"
            Exit Sub
        End If

        Select Case cboMovimiento.Text
            Case "TRANSFERENCIA ENTRE CAJAS"
                If Not txtCajaOrigen.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Debe ingresar la caja de origen!"
                    Exit Sub
                End If

                If Not txtCajaDestino.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Debe ingresar la caja de destino!"
                    Exit Sub
                End If
                Select Case manipulacionEstado
                    Case ENTITY_ACTIONS.INSERT
                        GrabarTransferenciaCaja()
                    Case ENTITY_ACTIONS.UPDATE

                End Select

            Case "OTRAS ENTRADAS A CAJA", "OTRAS SALIDAS DE CAJA"

                If Not txtCajaDestino.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Debe ingresar la caja de destino!"
                    Exit Sub
                End If

                Select Case manipulacionEstado
                    Case ENTITY_ACTIONS.INSERT
                        GrabarOtrosMovimientos()
                    Case ENTITY_ACTIONS.UPDATE
                        UPDATEOtrosMovimientos()
                End Select

        End Select


    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonCaption1.ItemActivated

    End Sub

    Private Sub QRibbonApplicationButton1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonApplicationButton1.ItemActivated

    End Sub
End Class