Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Imports Syncfusion.DocIO
Imports Syncfusion.DocIO.DLS
Imports System.Data.OleDb
Imports System.Data.SqlServerCe
Imports System.ComponentModel
Public Class frmCierreCaja
    Inherits frmMaster

    Public Property IDCajaUser As Integer

#Region "Métodos"
    Private Sub ObtenerCuentasFinancierasPorMoneda(strIdMoneda As String)
        Dim cFinancieraSA As New EstadosFinancierosSA
        gridGroupingControl1.DataSource = cFinancieraSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, strIdMoneda)
        gridGroupingControl1.TableDescriptor.GroupedColumns.Add("tipo")
    End Sub

    Public Function AS_CAJA_ORIGEN() As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = txtCuentaOrigen.Text,
              .descripcion = txtCajaOrigen.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = CDec(ImporteUtilidadMN.Text),
              .montoUSD = CDec(ImporteUtilidadME.Text),
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_CAJA_DESTINO() As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
       .cuenta = txtCuentaDestino.Text,
       .descripcion = txtCajaDestino.Text,
       .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
       .monto = CDec(ImporteUtilidadMN.Text),
       .montoUSD = CDec(ImporteUtilidadME.Text),
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
        nAsiento.idEntidad = txtPersona.ValueMember
        nAsiento.nombreEntidad = txtPersona.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
        nAsiento.fechaProceso = txtFechaCierre.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.CIERRE_CAJA_USUARIO
        nAsiento.importeMN = CDec(ImporteUtilidadMN.Text)  ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = CDec(ImporteUtilidadME.Text) ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now

        nAsiento.movimiento.Add(AS_CAJA_ORIGEN)
        nAsiento.movimiento.Add(AS_CAJA_DESTINO)

        Return nAsiento
    End Function

    Public Sub CerrarCajaUsuario()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim nDocumento As New documento
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            With cajaUsuario
                .idcajaUsuario = lblIdCajaUsuario.Text
                .fechaCierre = txtFechaCierre.Value
                .enUso = "N"
                .estadoCaja = "C"
                .otrosEgresosMN = nudImporteEgresosmn.Value
                .otrosEgresosME = nudImporteEgresosme.Value
                .ingresoAdicMN = nudIngresoMN.Value
                .ingresoAdicME = nudIngresoME.Value
                .idCajaCierre = txtCajaDestino.ValueMember
            End With
            nDocumento = ComprobanteCaja()
            asiento = asientoCaja()
            ListaAsiento.Add(asiento)
            nDocumento.asiento = ListaAsiento
            cajaUsuarioSA.CerrarCajaUsuario(cajaUsuario, nDocumento)
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Public Sub UbicarCaja(intIdCajaUsuario As Integer)
        Dim compra As Decimal = 0
        Dim compraME As Decimal = 0
        Dim prestamoOtorgado As Decimal = 0
        Dim prestamoOtorgadoME As Decimal = 0

        Dim prestamoRecibido As Decimal = 0
        Dim prestamoRecibidoME As Decimal = 0

        Dim VentasTicket As Decimal = 0
        Dim VentasTicketME As Decimal = 0

        Dim utilidad As Decimal = 0
        Dim utilidadME As Decimal = 0

        Dim ingresos As Decimal = 0
        Dim ingresosME As Decimal = 0

        Dim egresos As Decimal = 0
        Dim egresosME As Decimal = 0

        Dim fondo As Decimal = 0
        Dim fondoME As Decimal = 0
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim efSA As New EstadosFinancierosSA
        Dim personaSA As New PersonaSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCaja As New documentoCaja

        With cajaUsuarioSA.UbicarCajaUsuarioAbierto(intIdCajaUsuario, "A")
            lblIdCajaUsuario.Text = .idcajaUsuario
            With efSA.GetUbicar_estadosFinancierosPorID(.idCajaDestino)
                txtCajaOrigen.Text = .descripcion
                txtCajaOrigen.ValueMember = .idestado
                txtCuentaOrigen.Text = .cuenta
            End With
            With personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, .idPersona)
                txtPersona.ValueMember = .idPersona
                lblusuario.Text = .nombreCompleto
                txtPersona.Text = .nombreCompleto
                txtDni.Text = .idPersona
            End With
            txtFechaComprobante.Value = .fechaRegistro
            cboMoneda.Text = IIf(.moneda = 1, "NACIONAL", "EXTRANJERA")
            '   txtHora.Text = .fechaRegistro.Value.Hour & ":" & .fechaRegistro.Value.Minute
            'nudIngresoMN.Value = .ingresoAdicMN
            'nudIngresoME.Value = .ingresoAdicME
            'nudImporteEgresosmn.Value = .otrosEgresosMN
            'nudImporteEgresosme.Value = .otrosEgresosME
            txtFondoMN.Value = .fondoMN
            txtFondoME.Value = .fondoME
            txtTipoCambio.Value = .tipoCambio
        End With

        For Each r As Record In dgvCierres.Table.Records
            Select Case r.GetValue("codigoLibro")
                Case "COMPRA", "PAGO A PROVEEDORES"
                    compra += r.GetValue("montoSoles")
                    compraME += r.GetValue("montoUsd")
                Case "PRESTAMOS OTORGADOS"
                    prestamoOtorgado = r.GetValue("montoSoles")
                    prestamoOtorgadoME = r.GetValue("montoUsd")
                Case "PRESTAMOS RECIBIDOS"
                    prestamoRecibido = r.GetValue("montoSoles")
                    prestamoRecibidoME = r.GetValue("montoUsd")
                Case "VENTA", "TICKET BOLETA", "TICKET FACTURA"
                    VentasTicket += r.GetValue("montoSoles")
                    VentasTicketME += r.GetValue("montoUsd")
            End Select
        Next r


        egresos = compra + prestamoOtorgado
        egresosME = compraME + prestamoOtorgadoME

        ingresos = prestamoRecibido + VentasTicket
        ingresosME = prestamoRecibidoME + VentasTicketME

        nudIngresoMN.Value = ingresos
        nudIngresoME.Value = ingresosME

        nudImporteEgresosmn.Value = egresos
        nudImporteEgresosme.Value = egresosME

        nudIngresoMN.Value = ingresos
        nudIngresoME.Value = ingresosME

        fondo = txtFondoMN.Value
        fondoME = txtFondoME.Value

        utilidad = fondo + ingresos - egresos
        utilidadME = fondoME + ingresosME - egresosME
        'lsvDetalle.Items.Clear()
        ImporteUtilidadMN.Text = utilidad
        ImporteUtilidadME.Text = utilidadME
        'ImporteUtilidadME.Text = nudIngresoME.Value - nudImporteEgresosme.Value
        'For Each i In cajaUsuarioDetalleSA.ListaDetallePorCaja(intIdCajaUsuario)
        '    Select Case i.tipoVenta
        '        Case TIPO_VENTA.VENTA_AL_TICKET
        '            Dim n As New ListViewItem("Ventas con ticket")
        '            n.SubItems.Add(i.tipoDoc)
        '            n.SubItems.Add(i.importeMN)
        '            n.SubItems.Add(i.importeME)
        '            lsvDetalle.Items.Add(n)
        '        Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
        '            Dim n As New ListViewItem("Ventas con ticket pagado")
        '            n.SubItems.Add(i.tipoDoc)
        '            n.SubItems.Add(i.importeMN)
        '            n.SubItems.Add(i.importeME)
        '            lsvDetalle.Items.Add(n)
        '        Case TIPO_VENTA.VENTA_PAGADA
        '            Dim n As New ListViewItem("Venta pagada")
        '            n.SubItems.Add(i.tipoDoc)
        '            n.SubItems.Add(i.importeMN)
        '            n.SubItems.Add(i.importeME)
        '            lsvDetalle.Items.Add(n)
        '        Case TIPO_VENTA.VENTA_AL_CREDITO

        '        Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION
        '            Dim n As New ListViewItem("Compra Directa con recepción de existencias")
        '            n.SubItems.Add(i.tipoDoc)
        '            n.SubItems.Add(i.importeMN)
        '            n.SubItems.Add(i.importeME)
        '            lsvDetalle.Items.Add(n)

        '        Case TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
        '            Dim n As New ListViewItem("Compra Directa sin recepción de existencias")
        '            n.SubItems.Add(i.tipoDoc)
        '            n.SubItems.Add(i.importeMN)
        '            n.SubItems.Add(i.importeME)
        '            lsvDetalle.Items.Add(n)
        '    End Select
        'Next

        documentoCaja = documentoCajaSA.ResumenTransaccionesUsuarios(intIdCajaUsuario, "PG")
        txtUserEMN.Value = documentoCaja.montoSoles
        txtUserEME.Value = documentoCaja.montoUsd

        documentoCaja = documentoCajaSA.ResumenTransaccionesUsuarios(intIdCajaUsuario, "CB")
        txtUserIMN.Value = documentoCaja.montoSoles
        txtUserIME.Value = documentoCaja.montoUsd

        ImporteUtilidadMN.Text += txtUserIMN.Value - txtUserEMN.Value
        ImporteUtilidadME.Text += txtUserIME.Value - txtUserEME.Value
    End Sub

    Public Function Glosa() As String
        Return "Por Cierre/arqueo de caja a Usuario " & txtPersona.Text.Trim
    End Function

    Function ComprobanteCaja() As documento
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle

        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento   'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If

        nDocumentoCaja.tipoDoc = "9903"
        nDocumentoCaja.fechaProceso = txtFechaCierre.Value
        nDocumentoCaja.nroDoc = "EFECTIVO"
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9906"
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.TipoDocumentoPago = "VOCJ"
        objCaja.codigoLibro = "9906" ' TIPO OPERACION
        objCaja.periodo = PeriodoGeneral
        objCaja.codigoProveedor = txtPersona.ValueMember
        objCaja.fechaProceso = txtFechaCierre.Value
        objCaja.fechaCobro = txtFechaCierre.Value
        objCaja.tipoDocPago = "9903"
        objCaja.numeroDoc = 0 ' txtNumeroComp.Text
        objCaja.moneda = IIf(cboMoneda.Text = "NACIONAL", "1", "2")
        objCaja.entidadFinanciera = txtCajaDestino.ValueMember
        objCaja.numeroOperacion = "00001" 'txtNumeroComp.Text
        objCaja.tipoCambio = txtTipoCambio.Value
        objCaja.montoSoles = CDec(ImporteUtilidadMN.Text)
        objCaja.montoUsd = CDec(ImporteUtilidadME.Text)
       
        objCaja.glosa = Glosa()
        objCaja.entregado = "SI"
        objCaja.usuarioModificacion = IDCajaUser
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        objCajaDetalle = New documentoCajaDetalle
        objCajaDetalle.fecha = txtFechaCierre.Value
        objCajaDetalle.idItem = "00"
        objCajaDetalle.DetalleItem = "POR CIERRE DE CAJA"
        objCajaDetalle.montoSoles = CDec(ImporteUtilidadMN.Text)
        objCajaDetalle.montoUsd = CDec(ImporteUtilidadME.Text)
        objCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
        objCajaDetalle.documentoAfectado = 0
        objCajaDetalle.usuarioModificacion = IDCajaUser
        objCajaDetalle.fechaModificacion = Date.Now
        nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)

        Return nDocumentoCaja
    End Function
#End Region

#Region "Lista DGV"
    Private Function getParentCierreModulos(intIdUser As Integer) As DataTable
        Dim cajaSa As New DocumentoCajaSA
        Dim tablaSA As New tablaDetalleSA()

        Dim dt As New DataTable("Modulos")
        dt.Columns.Add(New DataColumn("codigoLibro", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        For Each i As documentoCaja In cajaSa.GetObtenerCierreCajasModulos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, intIdUser)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = tablaSA.GetUbicarTablaID(12, i.codigoLibro).descripcion
            dr(1) = i.montoSoles
            dr(2) = i.montoUsd
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Sub ListaCierresPorModulo(intIdUser As Integer)
        'GetObtenerCierreCajasModulos
        dgvCierres.TableOptions.ClearCache()
        '    dgvCuentasFinanzas.DataSource = Nothing
        dgvCierres.DataSource = getParentCierreModulos(intIdUser) ' cajaSa.ListaCajasHabilitadas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        dgvCierres.TableDescriptor.Relations.Clear()
        dgvCierres.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvCierres.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvCierres.TableOptions.ShowRowHeader = False
        dgvCierres.Appearance.AnyRecordFieldCell.Enabled = False
        Me.dgvCierres.TableDescriptor.GroupedColumns.Clear()
    End Sub
#End Region

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

    Private Sub frmCierreCaja_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCierreCaja_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ObtenerCuentasFinancierasPorMoneda("1")
        gridGroupingControl1.TableDescriptor.Relations.Clear()
        gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        gridGroupingControl1.Appearance.AnyRecordFieldCell.Enabled = False
        gridGroupingControl1.GroupDropPanel.Visible = False
        gridGroupingControl1.ForeColor = Color.Black
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
       
    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
                Me.txtCajaDestino.ValueMember = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idestado")
                Me.txtCajaDestino.Text = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion")
                txtCuentaDestino.Text = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cuenta")
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCajaDestino.Focus()
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlCellCursor(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellCursorEventArgs) Handles gridGroupingControl1.TableControlCellCursor

    End Sub

    Private Sub gridGroupingControl1_TableControlCellDoubleClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellDoubleClick
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv2.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(357, 249)
        Me.pcAlmacen.ParentControl = Me.txtCajaDestino
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        If Not txtCajaDestino.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese la caja de destino de la utilidad.!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            '  lblEstado.Image = My.Resources.warning2
            Exit Sub
        End If
        CerrarCajaUsuario()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub Label20_MouseClick(sender As Object, e As MouseEventArgs) Handles Label20.MouseClick
        With frmCerrarCaja
            .IdPadre = IDCajaUser
            .TipoMov = "CB"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        With frmCerrarCaja
            .IdPadre = IDCajaUser
            .TipoMov = "PG"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub
End Class