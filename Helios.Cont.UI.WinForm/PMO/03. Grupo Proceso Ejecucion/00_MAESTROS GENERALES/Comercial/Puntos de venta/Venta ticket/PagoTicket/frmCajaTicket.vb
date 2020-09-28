Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.Drawing
Imports System.Drawing.Printing
Imports Syncfusion.Windows.Forms

Imports PopupControl
Public Class frmCajaTicket
    Inherits frmMaster
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
    Public NCliente As String
    Dim TipoTicket As String
    Dim lblIdDocreferenciaAnticipo As Integer
    Dim lblNumeroDoc As Integer
    Dim ImporteSobranteMN As Decimal
    Dim ImporteTotalMN As Decimal
    Dim ImporteTotalME As Decimal
    Dim estadoImpresion As Integer
    Public Property ListaAsientonTransito As New List(Of asiento)

    Dim UcConfigCaja As New ucConfiguracionCaja
    Dim UserControl1 As New ucConfiguracion
    Dim toolTipCaja As Popup
    Dim toolTip As Popup
    Public fecha As DateTime
    Dim Sep As Char
    Dim cajaSA As New EstadosFinancierosSA
    Dim caja As New estadosFinancieros

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

        If keyData = Keys.Tab AndAlso txtCliente.Focused Then
            '  MessageBox.Show("Tab pressed")
            Return True
        End If

        If keyData = (Keys.Tab Or Keys.Shift) AndAlso txtCliente.Focused Then
            '  MessageBox.Show("Shift-Tab pressed")
            Return True
        End If

        Return baseResult
    End Function

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblPerido.Text = PeriodoGeneral
        ButtonAdv1.Enabled = False
        'Me.WindowState = FormWindowState.Maximized
        '   Listas()
    End Sub

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
            lsvCliente.Items.Add(n)

            txtCliente.Tag = codx
            txtCliente.Text = objCliente.nombreCompleto
            txtRuc.Text = objCliente.nrodoc
            txtCuenta.Text = objCliente.cuentaAsiento
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
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

#Region "Métodos Lista"
    Public Sub EliminarItemVenta(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetalleSA As New documentoVentaAbarrotesDetSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New totalesAlmacen

        With objDocumento
            .idDocumento = IntIdDocumento
        End With

        almacen = almacenSA.GetUbicar_almacenPorID(lsvDetalle.SelectedItems(0).SubItems(11).Text)
        objNuevo = New totalesAlmacen
        objNuevo.SecuenciaDetalle = lsvDetalle.SelectedItems(0).SubItems(16).Text
        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
        objNuevo.idEstablecimiento = almacen.idEstablecimiento
        objNuevo.idAlmacen = almacen.idAlmacen
        objNuevo.origenRecaudo = lsvDetalle.SelectedItems(0).SubItems(0).Text
        objNuevo.idItem = lsvDetalle.SelectedItems(0).SubItems(1).Text
        '    objNuevo.TipoDoc = ""

        objNuevo.importeSoles = CDec(lsvDetalle.SelectedItems(0).SubItems(14).Text) * -1
        objNuevo.importeDolares = CDec(lsvDetalle.SelectedItems(0).SubItems(15).Text) * -1

        objNuevo.cantidad = CDec(lsvDetalle.SelectedItems(0).SubItems(2).Text) * -1
        objNuevo.precioUnitarioCompra = 0 ' i.precioUnitario

        objNuevo.montoIsc = 0 ' i.montoIsc * -1
        objNuevo.montoIscUS = 0 ' i.montoIscUS * -1

        ListaTotales = objNuevo
        documentoSA.DeleteVentaTicketXitem(objDocumento, ListaTotales)
        lsvDetalle.SelectedItems(0).Remove()
    End Sub

    Function ComprobanteCaja() As documento
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaCajaDetalle As New List(Of documentoCajaDetalle)
        Dim cajaSA As New EstadosFinancierosSA
        Dim nDocumentoCaja As New documento()
        Dim caja As New estadosFinancieros

        caja = cajaSA.GetUbicar_estadosFinancierosPorID(txtCajaOrigen.Tag)

        nDocumentoCaja.idDocumento = lblIdDoc.Text
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
        nDocumentoCaja.fechaProceso = fecha
        nDocumentoCaja.nroDoc = txtSerieVenta.Text & "-" & txtNumeroVenta.Text
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = IIf(rbBoleta.Checked = True, "12.1", "12.2") ' "01"
        'nDocumentoCaja.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idDocumento = 0
        objCaja.periodo = PeriodoGeneral
        If txtCliente.Text.Trim.Length > 0 Then
            objCaja.codigoProveedor = lblNumeroDoc
        End If
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = fecha
        objCaja.fechaCobro = fecha
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If txtCliente.Text.Trim.Length > 0 Then
            objCaja.IdProveedor = txtCliente.Tag
        End If
        objCaja.TipoDocumentoPago = IIf(rbBoleta.Checked = True, "12.1", "12.2")
        objCaja.codigoLibro = IIf(rbBoleta.Checked = True, "12.1", "12.2") ' "01"
        objCaja.tipoDocPago = IIf(rbBoleta.Checked = True, "12.1", "12.2")
        objCaja.NumeroDocumento = txtSerieVenta.Text & "-" & txtNumeroVenta.Text
        objCaja.moneda = txtMoneda.ValueMember
        objCaja.tipoCambio = txtTipoCambio.Text
        If (rbConAnticipo.Checked = True) Then
            objCaja.montoSoles = CDec(txtImporteMn.Text - txtAnticipoMN.Value)
            objCaja.montoUsd = CDec((txtImporteMn.Text - txtAnticipoMN.Value) / txtTipoCambioVenta.Value)
        ElseIf (rbSinAnticipo.Checked = True) Then
            objCaja.montoSoles = CDec(txtImporteMn.Text)
            objCaja.montoUsd = CDec(txtImporteMn.Text / txtTipoCambioVenta.Value)
        End If

        objCaja.glosa = "Por ventas con tipo doc. " & IIf(rbBoleta.Checked = True, "BOL, ", "FAC, ") & "nro. " & txtSerieVenta.Text & "-" & txtNumeroVenta.Text & " fecha: " & txtFechaComprobante.Value
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = txtCajaOrigen.Tag
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        Return nDocumentoCaja
    End Function

    Function ObjDocCajaDetalle() As List(Of documentoCajaDetalle)
        Dim nDocumentoCaja As New documento()
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaCajaDetalle As New List(Of documentoCajaDetalle)
        Dim objCajaDetalleAnticipo As New documentoCajaDetalle

        If (rbConAnticipo.Checked = True) Then
            If (txtAnticipoMN.Value > 0 And txtIngresoMN.Value > 0) Then
                Tag = "VENTA"
                ImporteTotalMN = (txtImporteMn.Value - txtAnticipoMN.Value)
                For Each i As ListViewItem In lsvDetalle.Items
                    objCajaDetalle = New documentoCajaDetalle
                    objCajaDetalleAnticipo = New documentoCajaDetalle

                    Select Case Tag
                        Case "ANTICIPO"
                            objCajaDetalleAnticipo.idDocumento = 0
                            objCajaDetalleAnticipo.fecha = fecha
                            objCajaDetalleAnticipo.idItem = i.SubItems(1).Text
                            objCajaDetalleAnticipo.DetalleItem = i.SubItems(3).Text
                            objCajaDetalleAnticipo.entregado = "SI"
                            objCajaDetalleAnticipo.documentoAfectado = lblIdDoc.Text
                            objCajaDetalleAnticipo.usuarioModificacion = txtCajaOrigen.Tag
                            objCajaDetalleAnticipo.fechaModificacion = DateTime.Now
                            objCajaDetalleAnticipo.razonSocial = lblNumeroDoc
                            objCajaDetalleAnticipo.montoSoles = CDec(i.SubItems(6).Text)
                            objCajaDetalleAnticipo.montoUsd = CDec(i.SubItems(6).Text / txtTipoCambio.Value)
                            objCajaDetalleAnticipo.tipoEstadoCompra = "ANTICIPO"
                            Tag = "ANTICIPO"
                            ListaCajaDetalle.Add(objCajaDetalleAnticipo)
                        Case "VENTA"

                            If (ImporteTotalMN < CDec(i.SubItems(6).Text) And txtAnticipoMN.Value <> 0 _
                                And txtIngresoMN.Value <> 0 And ImporteTotalMN <> 0) Then

                                ImporteSobranteMN = (ImporteTotalMN - CDec(i.SubItems(6).Text))
                                'ImporteSobranteME = (ImporteTotalME - CDec(i.SubItems(7).Text))

                                objCajaDetalle.idDocumento = 0
                                objCajaDetalle.fecha = fecha
                                objCajaDetalle.idItem = i.SubItems(1).Text
                                objCajaDetalle.DetalleItem = i.SubItems(3).Text


                                objCajaDetalle.entregado = "SI"
                                objCajaDetalle.documentoAfectado = lblIdDoc.Text
                                objCajaDetalle.usuarioModificacion = usuario.IDUsuario
                                objCajaDetalle.fechaModificacion = DateTime.Now
                                objCajaDetalle.montoSoles = CDec(i.SubItems(6).Text) - CDec(ImporteSobranteMN * (-1))
                                objCajaDetalle.montoUsd = CDec((i.SubItems(6).Text - ImporteSobranteMN * (-1)) / txtTipoCambio.Value)
                                objCajaDetalle.tipoEstadoCompra = "VENTA"

                                objCajaDetalleAnticipo.idDocumento = 0
                                objCajaDetalleAnticipo.fecha = fecha
                                objCajaDetalleAnticipo.idItem = i.SubItems(1).Text
                                objCajaDetalleAnticipo.DetalleItem = i.SubItems(3).Text
                                objCajaDetalleAnticipo.entregado = "SI"
                                objCajaDetalleAnticipo.documentoAfectado = lblIdDoc.Text
                                objCajaDetalleAnticipo.usuarioModificacion = usuario.IDUsuario
                                objCajaDetalleAnticipo.fechaModificacion = DateTime.Now
                                objCajaDetalleAnticipo.razonSocial = lblNumeroDoc
                                objCajaDetalleAnticipo.montoSoles = CDec(ImporteSobranteMN * (-1))
                                objCajaDetalleAnticipo.montoUsd = CDec((ImporteSobranteMN * (-1)) / txtTipoCambio.Value)
                                objCajaDetalleAnticipo.tipoEstadoCompra = "ANTICIPO"
                                Tag = "ANTICIPO"

                                ListaCajaDetalle.Add(objCajaDetalle)
                                ListaCajaDetalle.Add(objCajaDetalleAnticipo)

                            ElseIf (CDec(txtIngresoMN.Value - txtVueltoMN.Value) = ImporteTotalMN) Then
                                objCajaDetalle.idDocumento = 0
                                objCajaDetalle.fecha = fecha
                                objCajaDetalle.idItem = i.SubItems(1).Text
                                objCajaDetalle.idItem = i.SubItems(1).Text
                                objCajaDetalle.DetalleItem = i.SubItems(3).Text
                                objCajaDetalle.montoSoles = CDec(i.SubItems(6).Text)
                                objCajaDetalle.montoUsd = CDec(i.SubItems(7).Text)


                                objCajaDetalle.entregado = "SI"
                                objCajaDetalle.documentoAfectado = lblIdDoc.Text
                                objCajaDetalle.usuarioModificacion = usuario.IDUsuario
                                objCajaDetalle.fechaModificacion = DateTime.Now
                                '***** resta el importe total para dividir el item *******
                                ImporteTotalMN -= CDec(i.SubItems(6).Text)
                                ImporteTotalME -= CDec(i.SubItems(6).Text / txtTipoCambio.Value)
                                objCajaDetalle.tipoEstadoCompra = "VENTA"
                                Tag = "VENTA"
                                ListaCajaDetalle.Add(objCajaDetalle)

                            ElseIf (ImporteTotalMN = 0) Then
                                objCajaDetalle.idDocumento = 0
                                objCajaDetalle.fecha = fecha
                                objCajaDetalle.idItem = i.SubItems(1).Text
                                objCajaDetalle.idItem = i.SubItems(1).Text
                                objCajaDetalle.DetalleItem = i.SubItems(3).Text
                                objCajaDetalle.montoSoles = CDec(i.SubItems(6).Text)
                                objCajaDetalle.montoUsd = CDec(i.SubItems(6).Text / txtTipoCambio.Value)


                                objCajaDetalle.entregado = "SI"
                                objCajaDetalle.razonSocial = lblNumeroDoc
                                objCajaDetalle.documentoAfectado = lblIdDoc.Text
                                objCajaDetalle.usuarioModificacion = usuario.IDUsuario
                                objCajaDetalle.fechaModificacion = DateTime.Now
                                '***** resta el importe total para dividir el item *******
                                ImporteTotalMN -= CDec(i.SubItems(6).Text)
                                'ImporteTotalME -= CDec(i.SubItems(7).Text)
                                'objCajaDetalle.montoSoles = CDec(i.SubItems(6).Text)
                                'objCajaDetalle.montoUsd = CDec(i.SubItems(7).Text)
                                objCajaDetalle.tipoEstadoCompra = "ANTICIPO"
                                Tag = "ANTICIPO"
                                ListaCajaDetalle.Add(objCajaDetalle)
                            End If

                    End Select
                Next
            ElseIf (txtIngresoMN.Value = 0 And txtAnticipoMN.Value > 0) Then
                For Each i As ListViewItem In lsvDetalle.Items
                    objCajaDetalle = New documentoCajaDetalle
                    objCajaDetalle.idDocumento = 0
                    objCajaDetalle.fecha = fecha
                    objCajaDetalle.idItem = i.SubItems(1).Text
                    objCajaDetalle.DetalleItem = i.SubItems(3).Text
                    objCajaDetalle.montoSoles = CDec(i.SubItems(6).Text)
                    objCajaDetalle.montoUsd = CDec(i.SubItems(6).Text / txtTipoCambio.Value)


                    objCajaDetalle.entregado = "SI"
                    objCajaDetalle.documentoAfectado = lblIdDoc.Text
                    objCajaDetalle.razonSocial = lblNumeroDoc
                    objCajaDetalle.usuarioModificacion = usuario.IDUsuario
                    objCajaDetalle.fechaModificacion = DateTime.Now
                    ListaCajaDetalle.Add(objCajaDetalle)
                Next
            End If

        ElseIf (rbSinAnticipo.Checked = True) Then
            For Each i As ListViewItem In lsvDetalle.Items
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = fecha
                objCajaDetalle.idItem = i.SubItems(1).Text
                objCajaDetalle.DetalleItem = i.SubItems(3).Text
                objCajaDetalle.montoSoles = CDec(i.SubItems(6).Text)
                objCajaDetalle.montoUsd = CDec(i.SubItems(6).Text / txtTipoCambio.Value)


                objCajaDetalle.entregado = "SI"
                objCajaDetalle.documentoAfectado = lblIdDoc.Text
                objCajaDetalle.usuarioModificacion = usuario.IDUsuario
                objCajaDetalle.fechaModificacion = DateTime.Now
                ListaCajaDetalle.Add(objCajaDetalle)
            Next
        End If

        Return ListaCajaDetalle
    End Function

    Private Function ComprobanteCajaAnticipo() As documento
        Dim documentoSA As New DocumentoSA
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim ndocumento As New documento
        Dim ndocumentoAnticipo As New documentoAnticipo
        Dim ndocumentoAnticipoDetalle As New documentoAnticipoDetalle
        Dim ListaDetalle As New List(Of documentoAnticipoDetalle)

        With ndocumento
            '    .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9901"
            .fechaProceso = Date.Now
            .nroDoc = 0 ' txtNumeroComp.Text
            .idOrden = Nothing
            .tipoOperacion = "103"
            .usuarioActualizacion = txtCajaOrigen.Tag
            .fechaActualizacion = DateTime.Now
        End With


        With nDocumentoAnticipo

            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoDocumento = "9901"
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            'txtNumero.Text = .IdNumeracion
            .numeroDoc = .IdNumeracion
            .fechaDoc = Date.Now
            .fechaPeriodo = PeriodoGeneral
            .tipoOperacion = "103"
            .tipoAnticipo = "AR"
            .razonSocial = lblNumeroDoc
            .TipoCambio = txtTipoCambio.Value
            .Moneda = "1"
            .importeMN = CDec(txtAnticipoMN.Value)
            .importeME = CDec(txtAnticipoMN.Value / txtTipoCambioVenta.Value)
            .idEntidadFinanciera = Nothing
            .usuarioModificacion = txtCajaOrigen.Tag
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoAnticipo = nDocumentoAnticipo

        Return ndocumento
    End Function

    Public Function AS_CAJA(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = caja.cuenta,
              .descripcion = caja.descripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

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
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = "Por ventas con tipo doc. " & IIf(rbBoleta.Checked = True, "BOL, ", "FAC, ") & "nro. " & txtSerieVenta.Text & "-" & txtNumeroVenta.Text & " fecha: " & txtFechaComprobante.Value
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        'Dim mascaraSA As New mascaraContable2SA
        'Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                '   With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                nMovimiento.cuenta = "69112"
                '    End With
        End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = txtCajaOrigen.Tag
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                'With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                nMovimiento.cuenta = "20111"
                '     End With

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

    Public Function RecuperaCuentaVenta(cCuenta As String, strTipoExistencia As String) As String
        'Dim mascaraSA As New mascaraContable2SA
        'Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim strCuenta As String = Nothing

        Select Case strTipoExistencia
            Case "01"
                '     With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
                strCuenta = "70111"
                '    End With
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
        nAsiento.fechaProceso = fecha
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        If txtCliente.Text.Trim.Length > 0 Then
            nAsiento.idEntidad = txtCliente.Tag
            nAsiento.nombreEntidad = txtCliente.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        End If
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "ASIENTO x VENTA PAGADA-TICKET"
        nAsiento.importeMN = txtImporteMn.Text
        nAsiento.importeME = txtImporteME.Text
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        ListaAsientonTransito.Add(nAsiento)
        nAsiento.movimiento.Add(AS_CAJA(CDec(txtImporteMn.Text), CDec(txtImporteME.Text)))
        For Each i As ListViewItem In lsvDetalle.Items
            Select Case txtComprobante.Text
                Case "03", "02"
                    MV_Item_Transito(i.SubItems(10).Text, i.SubItems(3).Text, CDec(i.SubItems(14).Text), CDec(i.SubItems(15).Text), i.SubItems(13).Text)
                Case Else

                    Select Case i.SubItems(0).Text
                        Case "1"
                            MV_Item_Transito(i.SubItems(10).Text, i.SubItems(3).Text, CDec(i.SubItems(14).Text), CDec(i.SubItems(15).Text), i.SubItems(13).Text)
                        Case Else
                            MV_Item_Transito(i.SubItems(10).Text, i.SubItems(3).Text, CDec(i.SubItems(14).Text), CDec(i.SubItems(15).Text), i.SubItems(13).Text)

                    End Select
            End Select


            nMovimiento = New movimiento
            nMovimiento.cuenta = RecuperaCuentaVenta(i.SubItems(10).Text, i.SubItems(13).Text)
            nMovimiento.descripcion = i.SubItems(3).Text
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            'Select Case lblTipoDoc.Text
            '    Case "03", "02"
            '        nMovimiento.monto = CDec(i.SubItems(5).Text)
            '        nMovimiento.montoUSD = CDec(i.SubItems(6).Text)
            '    Case Else
            Select Case i.SubItems(0).Text
                Case "1"
                    nMovimiento.monto = CDec(i.SubItems(8).Text)
                    nMovimiento.montoUSD = CDec(i.SubItems(9).Text)
                Case Else
                    nMovimiento.monto = CDec(i.SubItems(6).Text)
                    nMovimiento.montoUSD = CDec(i.SubItems(7).Text)
                    'End Select
            End Select
            'nMovimiento.monto = CDec(i.SubItems(13).Text)
            'nMovimiento.montoUSD = CDec(i.SubItems(14).Text)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario

            nAsiento.movimiento.Add(nMovimiento)


        Next
        nAsiento.movimiento.Add(AS_IGV(txtIgv.Value, txtIgvme.Value))
        '   Return nAsiento
    End Sub

    Public Sub ConfirmarVenta()
        Dim nDocumentoCaja As New documento()
        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim DocCajaAnticipo As New documento
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
        Dim nDocumentoanticipoDetalle As New documentoAnticipoDetalle
        Dim ListaDocumentoanticipoDetalle As New List(Of documentoAnticipoDetalle)

        Dim ListaDocumentoCajaDetalle As New List(Of documentoCajaDetalle)

        Try
            'INGRESANDO LA VENTA => CAJA
            If (txtIngresoMN.Value > 0) Then
                DocCaja = ComprobanteCaja()
            ElseIf (txtIngresoMN.Value = 0 And txtAnticipoMN.Value > 0) Then
                DocCajaAnticipo = ComprobanteCajaAnticipo()
            End If

            'If (txtAnticipoMN.Value > 0) Then
            '    DocCajaAnticipo = ComprobanteCajaAnticipo()
            'End If

            With ndocumento
                .idDocumento = lblIdDoc.Text
                If (rbConAnticipo.Checked = True) Then
                    If (txtIngresoMN.Value > 0) Then
                        .tipoConfirmacion = "CAV"
                    ElseIf (txtAnticipoMN.Value > 0) Then
                        .tipoConfirmacion = "CA"
                    End If
                ElseIf (rbSinAnticipo.Checked = True) Then
                    .tipoConfirmacion = "SA"
                End If
            End With

            ListaDocumentoCajaDetalle = ObjDocCajaDetalle()

            With nDocumentoVenta
                .TipoConfiguracion = GConfiguracion.TipoConfiguracion
                .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)

                .idDocumento = lblIdDoc.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoDocumento = IIf(rbBoleta.Checked = True, "12.1", "12.2")
                .serie = txtSerieVenta.Text
                .serieVenta = GConfiguracion.Serie
                .fechaConfirmacion = fecha
                '  .NumeroDoc = txtNumeroDoc.Text
                If txtCliente.Text.Trim.Length > 0 Then
                    .idCliente = txtCliente.Tag
                End If
                .estadoCobro = TIPO_VENTA.PAGO.COBRADO   ' DOCUMENTO COBRADO
                .establecimientoCobro = caja.idEstablecimiento
                '.entidadFinanciera = caja.idestado
                .entidadFinanciera = txtCajaOrigen.Tag
                .glosa = "Por ventas con tipo doc. " & IIf(rbBoleta.Checked = True, "BOL, ", "FAC, ") & "nro. " & txtSerieVenta.Text & "-" & txtNumeroVenta.Text & " fecha: " & txtFechaComprobante.Value
                .tipoVenta = TIPO_VENTA.VENTA_AL_TICKET
                .usuarioActualizacion = usuario.IDUsuario
            End With
            ndocumento.documentoventaAbarrotes = nDocumentoVenta

            With nDocumentoVentaDetalle
                .idDocumento = lblIdDoc.Text
                .entregado = "S"
            End With
            ListaDocumentoVentaDetalle.Add(nDocumentoVentaDetalle)
            ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDocumentoVentaDetalle


            '****************************************ZONA ANTICIPO *********************************************

            'If (rbConAnticipo.Checked = True) Then
            '    With nDocumentoanticipoDetalle
            '        '.idDocumento = lblNumeroDoc
            '        .docAfectado = lblIdDoc.Text
            '        .importeMN = CDec(txtAnticipoMN.Value)
            '        .importeME = CDec(txtAnticipoME.Value)
            '        .idEmpresa = Gempresas.IdEmpresaRuc
            '        .idEstablecimiento = GEstableciento.IdEstablecimiento
            '        .usuarioModificacion = lblNumeroDoc
            '        .fechaActualizacion = Date.Now
            '        .descripcion = "ANTICIPO " & IIf(rbBoleta.Checked = True, "BOL, ", "FAC, ") & "nro. " & txtSerieVenta.Text & "-" & txtNumeroVenta.Text & " fecha: " & txtFechaComprobante.Value
            '    End With

            'End If

            '*********************************** ZONA ASIENTO* *************************************************
            AsientoVenta()

            ndocumento.asiento = ListaAsientonTransito
            nDocumentoVentaSA.ConfirmarVentaTicketSL(ndocumento, DocCaja, ListaTotales, cajaUsarioBE, nDocumentoanticipoDetalle, DocCajaAnticipo, ListaDocumentoCajaDetalle)
            lblEstado.Text = "Venta confirmada correctamente!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

            nDocumentoVentaSA = New documentoVentaAbarrotesSA
            With nDocumentoVentaSA.GetUbicar_documentoventaAbarrotesPorID(CInt(lblIdDoc.Text))
                txtSerVenta.Text = .serieVenta
                txtnroVenta.Text = .numeroVenta
                ButtonAdv1.Enabled = True
            End With

            If MessageBoxAdv.Show("Desea imprimir la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If lsvDetalle.Items.Count > 0 Then
                    llenarDatos()
                    imprimir(True)
                End If
            End If

            '   Dispose()
            'If objService.ConfirmarVtaAbarrote(objDocCaja, objDocumentoEO, objDocumentoVentaEO, objAsiento, ObjAsientoAlmacen) Then
            '    ' verReporte()
            '    MsgBox("Confirmación completada correctamente", MsgBoxStyle.Information, "Done!")
            '    Dispose()
            'Else
            '    MsgBox("EL registro ya fue cancelado en otra ubicación!", MsgBoxStyle.Information, "Aviso del Sistema!")
            'End If
        Catch ex As Exception
            lblEstado.Text = "Error al procesar venta" & vbCrLf & ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End Try
    End Sub


    Public Sub ObtenerDetallePedido(ByVal intIdDocumento As Integer)
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA

        Try
            lsvDetalle.Columns.Clear()
            lsvDetalle.Items.Clear()
            lsvDetalle.Columns.Add("Destino", 0) '0
            lsvDetalle.Columns.Add("Id Item", 0) '01
            lsvDetalle.Columns.Add("Cant", 80, HorizontalAlignment.Right) '3
            lsvDetalle.Columns.Add("Producto", 350) '02
            lsvDetalle.Columns.Add("Presentación", 80, HorizontalAlignment.Center) '03
            lsvDetalle.Columns.Add("U.M", 60, HorizontalAlignment.Center) '04
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
                If i.tipoExistencia = "GS" Then
                    n.SubItems.Add(0)
                    n.SubItems.Add(0)
                Else
                    n.SubItems.Add(i.cuentaOrigen)
                    n.SubItems.Add(i.idAlmacenOrigen)
                End If
              
                n.SubItems.Add(i.establecimientoOrigen)
                n.SubItems.Add(i.tipoExistencia)

                n.SubItems.Add(i.salidaCostoMN)
                n.SubItems.Add(i.salidaCostoME)
                n.SubItems.Add(i.secuencia)

                n.Checked = True
                lsvDetalle.Items.Add(n)
            Next
            lsvDetalle.MultiSelect = False
            lsvDetalle.HideSelection = False
            lsvDetalle.FullRowSelect = True
        Catch ex As Exception
            MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub

    Public Sub ObtenerVentaPorCodigo(strNumDoc As String)
        Dim docuemntoventaSA As New documentoVentaAbarrotesSA
        Dim docuemntoventa As New documentoventaAbarrotes
        Dim strxSerie As String = Nothing
        Try
            strxSerie = String.Format("{0:00000}", txtSerieVenta.Text)
            docuemntoventa = docuemntoventaSA.GetObtenerVentaPorNumero(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_VENTA.VENTA_NOTA_PEDIDO, "9907", txtSeriePedido.Text, strNumDoc)
            If Not IsNothing(docuemntoventa) Then

                rbSinAnticipo.Checked = True
                txtAnticipoMN.Value = 0
                txtAnticipoME.Value = 0

                txtSerVenta.Clear()
                txtnroVenta.Clear()
                rbBoleta.Checked = False
                rbFactura.Checked = False
                txtTipoCambioVenta.Value = 0
                txtIngresoMN.Value = 0
                txtIngresoME.Value = 0
                txtVueltoMN.Value = 0
                txtVueltoME.Value = 0

                DigitalGauge2.Value = "0.00"
                lblIdDoc.Text = String.Empty
                txtTipoCambio.Text = 0
                txtComprador.Text = String.Empty
                txtComprobante.Text = String.Empty
                txtNumeroVenta.Text = String.Empty
                txtSerieVenta.Text = String.Empty
                txtImporteMn.Value = 0
                txtImporteME.Value = 0

                txtIgv.Text = 0
                txtIgvme.Value = 0
                txtTasaIgv.Value = 0
                lsvDetalle.Items.Clear()

                txtAnticipoMN.Value = 0
                txtAnticipoME.Value = 0

                txtCobroMN.Value = 0
                txtCobroME.Value = 0
                rbSinAnticipo.Checked = True

                Panel3.Enabled = True
                pnDatos.Enabled = True
                pnVentas.Enabled = True
                txtCajaOrigen.Text = String.Empty

                With docuemntoventa
                    txtFechaComprobante.Value = .fechaDoc
                    txtFechaComprobante.Enabled = False
                    lblIdDoc.Text = .idDocumento
                    txtTipoCambio.Text = .tipoCambio
                    txtComprador.Text = .nombrePedido
                    '   lblInfoComprador.Text = "Comprador: " & .nombrePedido
                    txtComprobante.Text = .tipoDocumento
                    txtNumeroVenta.Text = .numeroDoc
                    txtSerieVenta.Text = .serie
                    txtImporteMn.Value = FormatNumber(.ImporteNacional, 2)
                    Dim c = CDec(.ImporteNacional).ToString("N2")
                    DigitalGauge2.Value = c 'FormatNumber(.ImporteNacional, 2)
                    txtImporteME.Value = FormatNumber(.ImporteExtranjero, 2)
                    txtPeriodo.Text = .fechaPeriodo
                    txtIgv.Value = FormatNumber(.igv01, 2)
                    txtIgvme.Value = FormatNumber(.igv01us, 2)
                    txtTasaIgv.Value = .tasaIgv
                    'se agrego caja manual
                    txtCajaOrigen.Text = GFichaUsuarios.NomCajaDestinb
                    txtCajaOrigen.Tag = GFichaUsuarios.IdCajaDestino

                    '   txtGlosa.Text = .glosa
                    txtMoneda.ValueMember = .moneda
                    Select Case .moneda
                        Case 1
                            txtMoneda.Text = "NAC"
                        Case Else
                            txtMoneda.Text = "EXT"
                    End Select
                    'If .tipoDocumento = "03" Then
                    '    rbBoleta.Checked = True
                    'Else
                    '    rbFactura.Checked = True
                    'End If

                    txtCobroMN.Value = FormatNumber(.ImporteNacional, 2)
                    txtCobroME.Value = FormatNumber(.ImporteExtranjero, 2)



                End With
                ObtenerDetallePedido(docuemntoventa.idDocumento)
                lblEstado.Text = "Pedido encontrado: " & docuemntoventa.nombrePedido
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                txtTipoCambioVenta.Focus()
                txtTipoCambioVenta.Select(0, txtTipoCambioVenta.Text.Length)
                'lblEstado.Image = My.Resources.ok4
            Else
                '  lblInfoComprador.Text = String.Empty
                'lblImporteComprador.Text = "0.00"
                rbSinAnticipo.Checked = True
                txtAnticipoMN.Value = 0
                txtAnticipoME.Value = 0
                txtSerVenta.Clear()
                txtnroVenta.Clear()
                rbBoleta.Checked = False
                rbFactura.Checked = False
                txtTipoCambioVenta.Value = 0
                txtIngresoMN.Value = 0
                txtIngresoME.Value = 0
                txtVueltoMN.Value = 0
                txtVueltoME.Value = 0

                DigitalGauge2.Value = "0.00"
                lblIdDoc.Text = String.Empty
                txtTipoCambio.Text = 0
                txtComprador.Text = String.Empty
                txtComprobante.Text = String.Empty
                txtNumeroVenta.Text = String.Empty
                txtSerieVenta.Text = String.Empty
                txtImporteMn.Value = 0
                txtImporteME.Value = 0


                txtAnticipoMN.Value = 0
                txtAnticipoME.Value = 0

                txtIgv.Text = 0
                txtIgvme.Value = 0
                txtTasaIgv.Value = 0
                lsvDetalle.Items.Clear()

                txtCobroMN.Value = 0
                txtCobroME.Value = 0
                rbSinAnticipo.Checked = True
                txtCajaOrigen.Text = String.Empty

                lblEstado.Text = "El pedido ya fue procesado y/o no existe, ingrese otro número a consultar."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumeroPedido.Focus()
                txtNumeroPedido.Select(0, txtNumeroPedido.Text.Length)
                Panel3.Enabled = False
                pnDatos.Enabled = False
                pnVentas.Enabled = False
                txtNumeroPedido.Select(0, txtNumeroPedido.Text.Length)
                Exit Sub
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.cross
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End Try

    End Sub

    'Public Sub configuracionModulo2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.NomModulo = strNomModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        If rbBoleta.Checked = True Then
    '                            GConfiguracion2.TipoComprobante = .tipo
    '                            GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                            txtSerVenta.Text = .serie
    '                            txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        End If


    '                        If rbFactura.Checked = True Then
    '                            GConfiguracion2.TipoComprobante = .tipo1
    '                            GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo1).descripcion
    '                            GConfiguracion2.Serie = .serie1
    '                            GConfiguracion2.ValorActual = .valorInicial1
    '                            txtSerVenta.Text = .serie1
    '                            txtTipoDocVenta.Text = GConfiguracion2.NombreComprobante
    '                        End If
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion2.IdAlmacen = .idAlmacen
    '                    GConfiguracion2.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    'With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                    '    'txtIdEstableAlmacen.Text = .idCentroCosto
    '                    '    'txtEstableAlmacen.Text = .nombre
    '                    'End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion2.IDCaja = .idestado
    '                    GConfiguracion2.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)

                If rbBoleta.Checked = True Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                    GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                    txtSerVenta.Text = RecuperacionNumeracion.serie
                    txtTipoDocVenta.Text = GConfiguracion.NombreComprobante
                End If


                If rbFactura.Checked = True Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo1
                    GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo1).descripcion
                    GConfiguracion.Serie = RecuperacionNumeracion.serie1
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial1
                    txtSerVenta.Text = RecuperacionNumeracion.serie1
                    txtTipoDocVenta.Text = GConfiguracion.NombreComprobante
                End If


            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        txtSeriePedido.Text = .serie
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub Listas()
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim categoriaSA As New itemSA

        lsvCliente.Items.Clear()
        For Each i As entidad In entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idEntidad)
            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.cuentaAsiento)
            n.SubItems.Add(i.nrodoc)
            lsvCliente.Items.Add(n)
        Next
    End Sub
#End Region

#Region "VALIDA USUARIO CAJA"
    Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA
        Dim strBool As Boolean

        GFichaUsuarios = New GFichaUsuario
        If IsNothing(GFichaUsuarios.NombrePersona) Then
            With frmFichaUsuarioCaja
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                ModuloAppx = ModuloSistema.CAJA
                .lblNivel.Text = "Caja"
                .lblEstadoCaja.Visible = True
                '.GroupBox1.Visible = True
                '.GroupBox2.Visible = True
                '.GroupBox4.Visible = True
                '.cboMoneda.Visible = True
                .Tipo_SituacionCaja = TIPO_SITUACION.CAJA_COBRO
                .Timer1.Enabled = True
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    strBool = False
                Else
                    strBool = True
                End If
            End With

        End If
        Return strBool
    End Function
#End Region

    Private Sub frmCajaTicket_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCajaTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaCobro.Value = DateTime.Now
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub chCliente_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles chCliente.CheckStateChanged
        If chCliente.Checked Then
            'Panel2.Visible = True
            GradientPanel3.Visible = True
        Else
            'Panel2.Visible = False
            GradientPanel3.Visible = False
        End If
    End Sub

    Private Sub lsvCliente_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvCliente.MouseDoubleClick
        If lsvCliente.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvCliente.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCliente.SelectedItems.Count > 0 Then
                Me.txtCliente.Text = lsvCliente.SelectedItems(0).SubItems(1).Text
                txtCliente.Tag = lsvCliente.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvCliente.SelectedItems(0).SubItems(3).Text
                txtCuenta.Text = lsvCliente.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCliente.Focus()
        End If
    End Sub

    Private Sub dropDownBtn_Click(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        'Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
        'Me.popupControlContainer1.ParentControl = Me.txtCliente
        'Me.popupControlContainer1.ShowPopup(Point.Empty)
        Me.PopupControlContainer2.ParentControl = Me.txtCajaOrigen
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
        CargarusuarioCaja(GEstableciento.IdEstablecimiento)
    End Sub

    Enum Sys
        Inicio
        Proceso
    End Enum

    Sub Aplica()
        Dim DT As String
        'Para adaptar a la configuracion del PC huesped.
        DT = Replace(txtNumeroPedido.Text, ".", Sep)
        DT = Replace(DT, ",", Sep)
        '  Label1.Text = CDbl(DT)
        On Error Resume Next
        txtNumeroPedido.SelectionStart = 0
        txtNumeroPedido.SelectionLength = Len(txtNumeroPedido.Text)
        txtNumeroPedido.Focus()
    End Sub


    Sub InfoConfiguracionCaja(n As Sys)

        If Not IsNothing(GFichaUsuarios) Then
            If Not IsNothing(GFichaUsuarios.NombrePersona) Then


                UcConfigCaja.lblidPersona.Text = GFichaUsuarios.IdPersona
                UcConfigCaja.lblEncargado.Text = GFichaUsuarios.NombrePersona
                UcConfigCaja.lblCajaHabilitada.Text = GFichaUsuarios.NomCajaDestinb
                UcConfigCaja.lblMoneda.Text = GFichaUsuarios.Moneda
                ' position the tooltip with its stem towards the right end of the button
                If n = Sys.Inicio Then

                ElseIf n = Sys.Proceso Then
                    toolTipCaja.Show(btnConfigCaja)
                End If

            End If
        End If
    End Sub

    Sub InfoConfiguracion(n As Sys)
        If Not IsNothing(GConfiguracion) Then
            If Not IsNothing(GConfiguracion.NomModulo) Then
                UserControl1.lblCodigo.Text = "C2"
                UserControl1.lblModulo.Text = Me.Text
                UserControl1.lblConfiguracion.Text = IIf(GConfiguracion.TipoConfiguracion = "M", "MANUAL", "PROGRAMADA")
                UserControl1.lblComprobante.Text = GConfiguracion.NombreComprobante
                UserControl1.lblSerie.Text = GConfiguracion.Serie
                UserControl1.lblNumImpresiones.Text = IIf(IsNothing(GConfiguracion.ValorActual), 0, GConfiguracion.ValorActual)
                UserControl1.lblAlmacen.Text = GConfiguracion.NombreAlmacen
                UserControl1.lblCaja.Text = GConfiguracion.NomCaja
                ' position the tooltip with its stem towards the right end of the button
                If n = Sys.Inicio Then

                ElseIf n = Sys.Proceso Then
                    toolTip.Show(btnConfiguracion)
                End If

            End If
        End If
    End Sub

    Private Sub btnConfigCaja_Click(sender As Object, e As EventArgs) Handles btnConfigCaja.Click
        Try
            InfoConfiguracionCaja(Sys.Proceso)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfiguracion.Click
        Try
            InfoConfiguracion(Sys.Proceso)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnConfigCaja_MouseLeave(sender As Object, e As EventArgs) Handles btnConfigCaja.MouseLeave
        toolTipCaja.Close()
    End Sub

    Private Sub btnConfiguracion_MouseLeave(sender As Object, e As EventArgs) Handles btnConfiguracion.MouseLeave
        toolTip.Close()
    End Sub


    Private Sub txtNumeroPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroPedido.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtSeriePedido.Text.Trim.Length > 0 Then
                Aplica()
                If txtNumeroPedido.Text.Trim.Length > 0 Then
                    ObtenerVentaPorCodigo(txtNumeroPedido.Text.Trim)
                Else
                    '    lblInfoComprador.Text = String.Empty
                    DigitalGauge2.Value = "0.00"
                    PanelError.Visible = True
                    lblEstado.Text = "Debe ingresar un codigo de venta válido!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            Else
                lblEstado.Text = "Ingrese el número de serie de venta!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtNumeroPedido_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroPedido.TextChanged
        If txtNumeroPedido.Text = Sep Then
            'si el separador decimal es tecleado directamente
            txtNumeroPedido.Text = "0" & Sep
            txtNumeroPedido.SelectionStart = Len(txtNumeroPedido.Text)
        ElseIf Not IsNumeric(Trim(txtNumeroPedido.Text)) Then
            Beep()
            If Len(txtNumeroPedido.Text) < 1 Then
                txtNumeroPedido.Text = ""
            Else
                txtNumeroPedido.Text = Microsoft.VisualBasic.Left(txtNumeroPedido.Text, Len(txtNumeroPedido.Text) - 1)
                txtNumeroPedido.SelectionStart = Len(txtNumeroPedido.Text)
            End If
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor

        If txtSeriePedido.Text.Trim.Length > 0 Then
            Aplica()
            If txtNumeroPedido.Text.Trim.Length > 0 Then
                ObtenerVentaPorCodigo(txtNumeroPedido.Text.Trim)
            Else
                PanelError.Visible = True
                lblEstado.Text = "Debe ingresar un codigo de venta válido!"
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        Else
            lblEstado.Text = "Ingrese el número de serie de venta!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvDetalle.Items.Count > 0 Then
            llenarDatos()
            imprimir(True)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

#Region "PRINT"
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
            AddHandler prtDoc.PrintPage, AddressOf prt_PrintPageSinRuc

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
    Public Sub prt_PrintPageSinRuc(ByVal sender As Object, _
                            ByVal e As PrintPageEventArgs)
        'mostrar si existe ruc o no
        Dim Ruc As String = ""
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

            If (TipoTicket = "ConRUC") Then

                Select Case estadoImpresion
                    Case 1
                        NCliente = vbCrLf & vbCrLf & "Comprador: " & txtCompradorN.Text & _
                           vbCrLf & "ID: " & lblIdDoc.Text & "                         Nro Doc: " & String.Concat(txtSerVenta.Text, "-", txtnroVenta.Text) & _
                           vbCrLf & "RUC: " & txtRuc.Text & _
                           vbCrLf & "Razón Social: " & txtCliente.Text & _
                           vbCrLf & "Código máquina registradora: " & txtCodMaqN.Text & _
                           vbCrLf & "Caja: " & txtCajaN.Text & _
                           vbCrLf & "Fecha: " & txtFechaN.Value & _
                           vbCrLf & "------------------------------------------------------------"
                    Case Else
                        NCliente = vbCrLf & vbCrLf & "Comprador: " & txtComprador.Text & _
                      vbCrLf & "ID: " & lblIdDoc.Text & "                         Nro Doc: " & String.Concat(txtSerVenta.Text, "-", txtnroVenta.Text) & _
                      vbCrLf & "RUC: " & txtRuc.Text & _
                      vbCrLf & "Razón Social: " & txtCliente.Text & _
                      vbCrLf & "Código máquina registradora: " & _
                      vbCrLf & "Caja: " & txtCajaOrigen.Text & _
                      vbCrLf & "Fecha: " & Date.Now & _
                      vbCrLf & "------------------------------------------------------------"
                      
                End Select
               

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
                    e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

                    str = Math.Round(CDec(i.SubItems(6).Text), 2)
                    Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
                    e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

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

                Dim NIgv As String = vbCrLf & vbCrLf & "IGV:   " & txtIgv.Value
                Dim fontNIgv As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 75, Y - 20)

                Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
                Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

                Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total a Pagar S/: " & txtImporteMn.Value
                Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 32, Y)

                Dim NTotalImpPagar As String = vbCrLf & vbCrLf & "Importe Pagado S/: " & txtIngresoMN.Value
                Dim fontNTotalImpPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NTotalImpPagar, fontNTotalImpPagar, Brushes.Black, leftMargin + 20, Y + 10)

                Dim NTotalVuelto As String = vbCrLf & vbCrLf & "Vuelto S/: " & txtVueltoMN.Value
                Dim fontNNTotalVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NTotalVuelto, fontNNTotalVuelto, Brushes.Black, leftMargin + 62, Y + 20)

                Dim NLinea2 As String = "----------------------------------------------------------------"
                Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)


                Select Case estadoImpresion
                    Case 1
                        Dim NVEndedor As String = vbCrLf & vbCrLf & "Vendedor: " & txtVendedorN.Text
                        Dim fontNVEndedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                        e.Graphics.DrawString(NVEndedor, fontNVEndedor, Brushes.Black, leftMargin - 90, Y + 38)
                    Case Else
                        Dim NVEndedor As String = vbCrLf & vbCrLf & "Vendedor: " & "Maykol sanchez coris"
                        Dim fontNVEndedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                        e.Graphics.DrawString(NVEndedor, fontNVEndedor, Brushes.Black, leftMargin - 90, Y + 38)
                End Select

                'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
                'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
                'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

                e.HasMorePages = False

            ElseIf (TipoTicket = "SinRUC") Then

                Select Case estadoImpresion
                    Case 1
                        NCliente = vbCrLf & vbCrLf & "Cliente: " & txtCompradorN.Text & _
                      vbCrLf & "ID: " & lblIdDoc.Text & "                         Nro Doc: " & String.Concat(txtSerVenta.Text, "-", txtnroVenta.Text) & _
                      vbCrLf & "Código máquina registradora: " & txtCodMaqN.Text & _
                      vbCrLf & "Caja: " & txtCajaN.Text & _
                      vbCrLf & "Fecha: " & txtFechaN.Value & _
                      vbCrLf & "------------------------------------------------------------"
                    Case Else
                        NCliente = vbCrLf & vbCrLf & "Cliente: " & txtComprador.Text & _
                         vbCrLf & "ID: " & lblIdDoc.Text & "                         Nro Doc: " & String.Concat(txtSerVenta.Text, "-", txtnroVenta.Text) & _
                         vbCrLf & "Código máquina registradora: " & _
                         vbCrLf & "Caja: " & txtCajaOrigen.Text & _
                         vbCrLf & "Fecha: " & Date.Now & _
                         vbCrLf & "------------------------------------------------------------"
                End Select

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
                Y = PrintTikect.DefaultPageSettings.Margins.Top + 25
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

                    str = Math.Round(CDec(i.SubItems(6).Text / (i.SubItems(2).Text)), 2)
                    Dim R2 As New RectangleF(X4 - 45, Y, W4, 80)
                    e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R2)

                    str = Math.Round(CDec(i.SubItems(6).Text), 2)
                    Dim R3 As New RectangleF(X5 - 13, Y, W5, 80)
                    e.Graphics.DrawString(CDec(str), fontNCabecera, Brushes.Black, R3)

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

                Dim NIgv As String = vbCrLf & vbCrLf & "IGV:   " & txtIgv.Value
                Dim fontNIgv As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NIgv, fontNCliente, Brushes.Black, leftMargin + 75, Y - 20)

                Dim NLinea1 As String = vbCrLf & vbCrLf & "------------------------------------"
                Dim fontNLinea1 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NLinea1, fontNLinea1, Brushes.Black, leftMargin + 10, Y - 10)

                Dim NTotalPagar As String = vbCrLf & vbCrLf & "Total a Pagar S/: " & txtImporteMn.Value
                Dim fontNTotalPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 32, Y)

                Dim NTotalImpPagar As String = vbCrLf & vbCrLf & "Importe Pagado S/: " & txtIngresoMN.Value
                Dim fontNTotalImpPagar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NTotalImpPagar, fontNTotalImpPagar, Brushes.Black, leftMargin + 20, Y + 10)

                Dim NTotalVuelto As String = vbCrLf & vbCrLf & "Vuelto S/: " & txtVueltoMN.Value
                Dim fontNNTotalVuelto As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NTotalVuelto, fontNNTotalVuelto, Brushes.Black, leftMargin + 62, Y + 20)

                Dim NLinea2 As String = "----------------------------------------------------------------"
                Dim fontNLinea2 As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                e.Graphics.DrawString(NLinea2, fontNLinea2, Brushes.Black, leftMargin - 90, Y + 53)

                Select Case estadoImpresion
                    Case 1
                        Dim NVEndedor As String = vbCrLf & vbCrLf & "Vendedor: " & txtVendedorN.Text
                        Dim fontNVEndedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                        e.Graphics.DrawString(NVEndedor, fontNVEndedor, Brushes.Black, leftMargin - 90, Y + 38)
                    Case Else
                        Dim NVEndedor As String = vbCrLf & vbCrLf & "Vendedor: " & "Maykol sanchez coris"
                        Dim fontNVEndedor As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                        e.Graphics.DrawString(NVEndedor, fontNVEndedor, Brushes.Black, leftMargin - 90, Y + 38)
                End Select

                'Dim NFijar As String = "ANTES DE RETIRARSE VERIFIQUE SU DINERO" & _
                'vbCrLf & "GRACIAS. EVITEMOS MOLESTIAS INNECESARIAS"
                'Dim fontNFijar As New System.Drawing.Font("Tahoma", 7, FontStyle.Regular)
                'e.Graphics.DrawString(NFijar, fontNFijar, Brushes.Black, leftMargin - 82, Y + 75)

                e.HasMorePages = False

            End If

        End If

    End Sub

#End Region

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvDetalle.Items.Count > 0 Then
            'llenarDatos()
            'imprimir(False)
            ConfirmarVenta()

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
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

    Private Sub btnGRabarProv_Click(sender As Object, e As EventArgs) Handles btnGRabarProv.Click
        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del cliente"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 252)
            Me.pcProveedor.ParentControl = Me.txtCliente
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del cliente"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 252)
            Me.pcProveedor.ParentControl = Me.txtCliente
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtNomProv.Select()
            Exit Sub
        End If

        If rbNatural.Checked = True Then
            If Not txtApePat.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del cliente"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtCliente
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
                Me.pcProveedor.ParentControl = Me.txtCliente
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtDocProveedor.Select()
                Exit Sub
            End If

            If Not txtNomProv.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del cliente"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtCliente
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtNomProv.Select()
                Exit Sub
            End If

            If rbNatural.Checked = True Then
                If Not txtApePat.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese los apellidos del cliente"
                    pcProveedor.Font = New Font("Tahoma", 8)
                    pcProveedor.Size = New Size(321, 252)
                    Me.pcProveedor.ParentControl = Me.txtCliente
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
                Me.pcProveedor.ParentControl = Me.txtCliente
                Me.pcProveedor.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCliente.Focus()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        txtDocProveedor.Clear()
        txtNomProv.Clear()
        txtApePat.Clear()
        txtDocProveedor.Select()
        rbNatural.Checked = True
        pcProveedor.Font = New Font("Tahoma", 8)
        pcProveedor.Size = New Size(321, 252)
        Me.pcProveedor.ParentControl = Me.txtCliente
        Me.pcProveedor.ShowPopup(Point.Empty)
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
       
        entidad = entidadSA.UbicarClientePoID(txtRuc.Text)
        'entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtCliente.Text = .nombreCompleto
                txtCliente.Tag = .idEntidad
                txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            NuevoIngreso()
        End If
    End Sub

    Sub NuevoIngreso()
        txtCliente.Clear()
        txtCliente.Clear()
        txtCuenta.Clear()
        'txtRuc.Clear()
        If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            If (rbBoleta.Checked = True) Then
                tipoPersona("BOLETA")
                txtDocProveedor.Text = txtRuc.Text
                'txtDocProveedor.Clear()
                txtNomProv.Clear()
                txtApePat.Clear()
                txtNomProv.Select()
                rbNatural.Checked = True
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 248)
                Me.pcProveedor.ParentControl = Me.txtCliente
                Me.pcProveedor.ShowPopup(Point.Empty)

            ElseIf (rbFactura.Checked = True) Then
                tipoPersona("RUC")
                txtDocProveedor.Text = txtRuc.Text
                'txtDocProveedor.Clear()
                txtNomProv.Clear()
                txtApePat.Clear()
                txtNomProv.Select()
                rbNatural.Checked = False
                rbNatural.Enabled = False
                rbJuridico.Checked = True
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 248)
                Me.pcProveedor.ParentControl = Me.txtCliente
                Me.pcProveedor.ShowPopup(Point.Empty)

            End If


        Else
            limpiarBoleta()
        End If
    End Sub


    Private Sub txtRuc_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmCajaTicket_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '  GFichaUsuarios = New GFichaUsuario
        GConfiguracion = New GConfiguracionModulo

        '    If TieneCuentaFinanciera() = True Then
        GuardarToolStripButton.Enabled = True
        txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        lblPerido.Text = PeriodoGeneral

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT1", Me.Text, GEstableciento.IdEstablecimiento)
        toolTipCaja = New Popup(UcConfigCaja)
        toolTipCaja.AutoClose = False
        toolTipCaja.FocusOnOpen = False
        toolTipCaja.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracionCaja(Sys.Inicio)

        toolTip = New Popup(UserControl1)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracion(Sys.Inicio)
        caja = cajaSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
        txtNumeroPedido.Select()
        txtNumeroPedido.Focus()
        'Else
        '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(5)
        '    GuardarToolStripButton.Enabled = False
        'End If
    End Sub

    Private Sub rbBoleta_CheckedChanged(sender As Object, e As EventArgs) Handles rbBoleta.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        If rbBoleta.Checked = True Then
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)

            If (CDec(txtImporteMn.Value > 699.99)) Then
                limpiarBoleta()
                CargarCajasComprobante(True)
                pnVentas.Size = New Size(357, 127)
                'pnDatos.Location = New Point(0, 418)
                TipoTicket = "ConRUC"
                txtRuc.Select()
                txtRuc.SelectAll()
            Else
                limpiarBoleta()
                CargarCajasComprobante(False)
                pnVentas.Size = New Size(357, 80)
                'pnDatos.Location = New Point(0, 373)
                TipoTicket = "SinRUC"
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CargarCajasComprobante(ByVal strCondicion As Boolean)
        PictureBox3.Visible = strCondicion
        txtRuc.Visible = strCondicion
        Label16.Visible = strCondicion
        Label15.Visible = strCondicion
        txtCliente.Visible = strCondicion
        Label3.Visible = strCondicion
        txtCuenta.Visible = strCondicion
    End Sub

    Private Sub rbFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rbFactura.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        If rbFactura.Checked = True Then
            limpiarBoleta()
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
            CargarCajasComprobante(True)
            pnVentas.Size = New Size(357, 127)
            'pnDatos.Location = New Point(0, 418)
            txtRuc.Select()
            txtRuc.SelectAll()
            TipoTicket = "ConRUC"
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If lsvDetalle.SelectedItems.Count > 0 Then
            If MessageBoxAdv.Show("Desea eliminar el producto seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                EliminarItemVenta(lblIdDoc.Text)
            End If
        End If
    End Sub


    Private Sub txtIngresoMN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIngresoMN.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtTipoCambioVenta.Value > 0.0 Then
                If (rbConAnticipo.Checked = True) Then

                    If (CDec((txtIngresoMN.Value + txtAnticipoMN.Value) >= txtCobroMN.Value) _
                        And txtAnticipoMN.Value < txtCobroMN.Value) Then
                        'Label30.Text = "Mensaje error"
                        txtIngresoMN.Select(0, txtIngresoMN.Text.Length)
                        txtVueltoMN.Value = CDec((txtIngresoMN.Value + txtAnticipoMN.Value) - txtCobroMN.Value)
                        txtIngresoME.Value = CDec(txtIngresoMN.Value / txtTipoCambioVenta.Value)
                        txtVueltoME.Value = CDec(txtVueltoMN.Value / txtTipoCambioVenta.Value)
                        txtAnticipoME.Value = CDec(txtAnticipoMN.Value / txtTipoCambioVenta.Value)
                    ElseIf (CDec(txtAnticipoMN.Value = txtCobroMN.Value)) Then
                        txtIngresoMN.Value = 0.0
                        txtIngresoME.Value = 0.0
                        PanelError.Visible = True
                        lblEstado.Text = "ingreso incorrecto, anticipo correcto "
                        Timer1.Enabled = True
                        TiempoEjecutar(5)
                    ElseIf (CDec(txtIngresoMN.Value + txtAnticipoMN.Value) <= txtCobroMN.Value) Then
                        txtVueltoMN.Value = 0.0
                        txtIngresoME.Value = 0.0
                        txtVueltoME.Value = 0.0
                        txtIngresoMN.Value = 0.0
                        txtIngresoMN.Select(0, txtIngresoMN.Text.Length)
                        PanelError.Visible = True
                        lblEstado.Text = "Monto ingresado debe ser mayor o igual al monto de venta"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If

                ElseIf (rbSinAnticipo.Checked = True) Then
                    If (CDec(txtIngresoMN.Value >= txtCobroMN.Value)) Then
                        'Label30.Text = "Mensaje error"
                        txtVueltoMN.Value = 0.0
                        txtVueltoME.Value = 0.0
                        txtVueltoMN.Value = CDec(txtIngresoMN.Value - txtCobroMN.Value)
                        txtIngresoME.Value = CDec(txtIngresoMN.Value / txtTipoCambioVenta.Value)
                        txtVueltoME.Value = CDec(txtVueltoMN.Value / txtTipoCambioVenta.Value)
                    Else
                        txtVueltoMN.Value = 0.0
                        txtIngresoME.Value = 0.0
                        txtVueltoME.Value = 0.0
                        txtIngresoMN.Value = 0.0
                        txtIngresoMN.Focus()
                        txtIngresoMN.Select(0, txtIngresoMN.Text.Length)
                        PanelError.Visible = True
                        lblEstado.Text = "Monto ingresado debe ser mayor o igual al monto de venta"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
                End If

            Else
                PanelError.Visible = True
                lblEstado.Text = "Debe ingresar el tipo de cambio"
                Timer1.Enabled = True
                TiempoEjecutar(10)
                txtTipoCambioVenta.Focus()
                txtTipoCambioVenta.Select(0, txtTipoCambioVenta.Text.Length)
                txtIngresoMN.Value = 0.0
                txtIngresoME.Value = 0.0
            End If
        End If
        Me.Cursor = Cursors.Arrow
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

    Private Sub txtNomProv_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNomProv.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtApePat.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNomProv.Clear()
        End Try
    End Sub

    Private Sub txtDocProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDocProveedor.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNomProv.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtDocProveedor.Clear()
        End Try
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Me.Cursor = Cursors.WaitCursor
        Try
            If rbNatural.Checked = True Then
                If Not CDec(txtTipoCambioVenta.Text) > 0 Then
                    PanelError.Visible = True
                    lblEstado.Text = "Ingrese tipo de cambio"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtTipoCambioVenta.Select()
                    txtTipoCambioVenta.Select(0, txtTipoCambioVenta.Text.Length)
                    Exit Sub
                End If
                If Not txtCajaOrigen.Tag > 0 Then
                    PanelError.Visible = True
                    lblEstado.Text = "Ingrese unca caja valida"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtCajaOrigen.Select()
                    Exit Sub
                End If

                If Not CDec(txtAnticipoMN.Value + txtIngresoMN.Value) >= txtCobroMN.Value Then
                    PanelError.Visible = True
                    lblEstado.Text = "El monto debe ser mayor o igual al monto a cobrar!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

                If rbBoleta.Checked = False And rbFactura.Checked = False Then
                    PanelError.Visible = True
                    lblEstado.Text = "Debe indicar el modo a cobrar el pedido!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

                If txtRuc.Text.Length > 0 Then
                    If (rbBoleta.Checked = True And CDec(txtCobroMN.Value) > 699.99 And txtRuc.Text = "0000") Then
                        PanelError.Visible = True
                        lblEstado.Text = "Ingrese RUC o boleta correcta"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtRuc.Select()
                        'NuevoIngreso()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                    If (rbFactura.Checked = True And txtRuc.Text = "0000") Then
                        PanelError.Visible = True
                        lblEstado.Text = "Ingrese RUC correcta"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        txtRuc.Select()
                        'NuevoIngreso()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

            End If

            If (rbConAnticipo.Checked = True) Then
                If lsvDetalle.Items.Count > 0 Then
                    If (txtAnticipoMN.Value <= txtCobroMN.Value _
                        And (txtAnticipoMN.Value + txtIngresoMN.Value) >= txtCobroMN.Value) Then
                        ConfirmarVenta()
                        limpiarConfirmarVenta()
                    ElseIf (CDec(txtAnticipoMN.Value = txtCobroMN.Value)) Then
                        ConfirmarVenta()
                        limpiarConfirmarVenta()
                    ElseIf (CDec(txtAnticipoMN.Value < txtCobroMN.Value)) Then
                        PanelError.Visible = True
                        lblEstado.Text = "El monto debe ser mayor o igual al monto a cobrar!"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                End If

            ElseIf (rbSinAnticipo.Checked = True) Then
                If lsvDetalle.Items.Count > 0 Then
                    If (txtTipoCambioVenta.Value > 0) Then
                        ConfirmarVenta()
                        limpiarConfirmarVenta()
                    Else
                        txtTipoCambioVenta.Focus()
                        txtTipoCambioVenta.Select(0, txtTipoCambioVenta.Text.Length)
                        PanelError.Visible = True
                        lblEstado.Text = "Debe ingresar un tipo de cambio de venta"
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                End If
            End If
           
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbConAnticipo_CheckedChanged(sender As Object, e As EventArgs) Handles rbConAnticipo.CheckedChanged
        If (txtTipoCambioVenta.Value > 0) Then
            If (rbConAnticipo.Checked = True) Then
                ConAnticipo()
                Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                datos.Clear()
                txtAnticipoMN.Value = 0.0
                txtAnticipoME.Value = 0.0
                With frmSalidaAnticipo
                    txtIngresoMN.Value = 0.0
                    txtIngresoME.Value = 0.0
                    txtVueltoMN.Value = 0.0
                    txtVueltoME.Value = 0.0
                    .txtMontoCobrarMN.Value = txtCobroMN.Value
                    .txtMontoCobrarME.Value = txtCobroME.Value
                    .txtTipoCambio.Value = txtTipoCambioVenta.Value
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    If datos.Count > 0 Then
                        txtAnticipoMN.Value = datos(0).PMmn
                        txtAnticipoME.Value = datos(0).PMme
                        lblNumeroDoc = datos(0).IdResponsable

                    Else
                        rbSinAnticipo.Checked = True
                        SinAnticipo()
                    End If
                End With
            End If
        Else
            PanelError.Visible = True
            lblEstado.Text = "Debe indicar el tipo de cambio venta!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
            rbSinAnticipo.Checked = True
            txtTipoCambioVenta.Focus()
            txtTipoCambioVenta.Select(0, txtTipoCambioVenta.Text.Length)

        End If

    End Sub

    Private Sub rbSinAnticipo_CheckedChanged(sender As Object, e As EventArgs) Handles rbSinAnticipo.CheckedChanged
        If (rbSinAnticipo.Checked = True) Then
            SinAnticipo()
        End If

    End Sub

    Public Sub ConAnticipo()
        lblAnticipoMN.Visible = True
        txtAnticipoMN.Visible = True
        lblAnticipoME.Visible = True
        txtAnticipoME.Visible = True

        txtIngresoMN.Location = New Point(91, 123)
        txtIngresoME.Location = New Point(265, 123)
        lblReciboMN.Location = New Point(16, 127)
        lblReciboME.Location = New Point(191, 126)

        txtVueltoMN.Location = New Point(91, 149)
        txtVueltoME.Location = New Point(265, 149)
        lblVueltoMN.Location = New Point(28, 152)
        lblVueltoME.Location = New Point(201, 152)

        pnDatos.Size = New Size(366, 185)
        Panel2.Location = New Point(0, 348)
        pnVentas.Location = New Point(-1, 378)
    End Sub

    Public Sub SinAnticipo()
        lblAnticipoMN.Visible = False
        txtAnticipoMN.Visible = False
        lblAnticipoME.Visible = False
        txtAnticipoME.Visible = False

        txtIngresoMN.Value = 0.0
        txtIngresoME.Value = 0.0
        txtVueltoMN.Value = 0.0
        txtVueltoME.Value = 0.0
        txtAnticipoMN.Value = 0.0
        txtAnticipoME.Value = 0.0

        txtIngresoMN.Location = New Point(91, 99)
        txtIngresoME.Location = New Point(265, 99)
        lblReciboMN.Location = New Point(16, 103)
        lblReciboME.Location = New Point(191, 102)

        txtVueltoMN.Location = New Point(91, 123)
        txtVueltoME.Location = New Point(265, 123)
        lblVueltoMN.Location = New Point(16, 127)
        lblVueltoME.Location = New Point(191, 126)

        pnDatos.Size = New Size(366, 150)
        Panel2.Location = New Point(0, 313)
        pnVentas.Location = New Point(-1, 343)
    End Sub


    Private Sub txtTipoCambioVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTipoCambioVenta.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtAnticipoME.Value = CDec(txtAnticipoMN.Value / txtTipoCambioVenta.Value)
                txtIngresoME.Value = CDec(txtIngresoMN.Value / txtTipoCambioVenta.Value)
                txtVueltoME.Value = CDec(txtVueltoME.Value / txtTipoCambioVenta.Value)
                txtIngresoMN.Focus()
                txtIngresoMN.Select(0, txtIngresoMN.Text.Length)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Private Sub limpiarConfirmarVenta()
        txtSerVenta.Clear()
        txtnroVenta.Clear()
        rbBoleta.Checked = False
        rbFactura.Checked = False
        txtTipoCambioVenta.Value = 0
        txtIngresoMN.Value = 0
        txtIngresoME.Value = 0
        txtVueltoMN.Value = 0
        txtVueltoME.Value = 0

        DigitalGauge2.Value = "0.00"
        lblIdDoc.Text = String.Empty
        txtTipoCambio.Text = 0
        txtComprador.Text = String.Empty
        txtComprobante.Text = String.Empty
        txtNumeroVenta.Text = String.Empty
        txtSerieVenta.Text = String.Empty
        txtImporteMn.Value = 0
        txtImporteME.Value = 0

        txtSerVenta.Text = String.Empty
        txtIgv.Text = 0
        txtIgvme.Value = 0
        txtTasaIgv.Value = 0
        lsvDetalle.Items.Clear()
        rbSinAnticipo.Checked = True
        txtCobroMN.Value = 0
        txtCobroME.Value = 0
        txtAnticipoMN.Value = 0.0
        txtAnticipoME.Value = 0.0

        Panel3.Enabled = False
        pnDatos.Enabled = False
        pnVentas.Enabled = False

        txtTipoDocVenta.Text = String.Empty
        txtRuc.Text = "0000"
        txtCliente.Text = "Clientes varios"
        rbBoleta.Checked = False
        rbFactura.Checked = False
        txtCajaOrigen.Text = String.Empty

        txtNumeroPedido.Clear()
        txtNumeroPedido.Focus()
        txtNumeroPedido.Select(0, txtNumeroPedido.Text.Length)
        estadoImpresion = 0
        pnVentas.Size = New Size(357, 80)
    End Sub

    Sub limpiarBoleta()
        txtRuc.Text = "0000"
        txtCliente.Text = "Clientes varios"
    End Sub


    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        pnImpresionTicket.Visible = False
        Me.pnImpresionTicket = Nothing
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If Not txtCompradorN.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese un comprador valido!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtCompradorN.Select()
            Exit Sub
        End If

        If Not txtCodMaqN.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese un codigo de maquina!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtCodMaqN.Select()
            Exit Sub
        End If

        If Not txtCajaN.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese nombre de caja!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtCajaN.Select()
            Exit Sub
        End If

        If Not txtVendedorN.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese un vendedor!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtVendedorN.Select()
            Exit Sub
        End If
        estadoImpresion = 1
        pnImpresionTicket.Visible = False
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        pnImpresionTicket.Visible = True
        txtCompradorN.Select()
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtCajaOrigen.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                Me.txtCajaOrigen.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtCliente.Select()
                txtCajaOrigen.SelectAll()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCliente.Focus()
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtCajaOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCajaOrigen.KeyDown
        '    If e.Alt Then
        '        If e.KeyCode = Keys.Down Then
        '            If Not Me.PopupControlContainer2.IsShowing() Then
        '                ' Let the popup align around the source textBox.
        '                Me.PopupControlContainer2.ParentControl = Me.txtCajaOrigen
        '                ' Passing Point.Empty will align it automatically around the above ParentControl.
        '                Me.PopupControlContainer2.ShowPopup(Point.Empty)

        '                e.Handled = True
        '            End If
        '        End If
        '    End If
        '    '' Escape should close the popup.
        '    If e.KeyCode = Keys.Escape Then
        '        If Me.PopupControlContainer2.IsShowing() Then
        '            Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
        '        End If
        '    End If
        '    If e.KeyCode = Keys.Enter Then
        '        e.SuppressKeyPress = True
        '        If txtCajaOrigen.Text.Trim.Length > 0 Then
        '            Me.PopupControlContainer2.ParentControl = Me.txtCajaOrigen
        '            Me.PopupControlContainer2.ShowPopup(Point.Empty)
        '            CargarusuarioCaja(GEstableciento.IdEstablecimiento)
        '        End If
        '    End If
    End Sub

    Public Sub CargarusuarioCaja(strEstablecimiento As Integer)
        Dim estadosFinancierosSA As New EstadosFinancierosSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"

            'caja = cajaSA.GetUbicar_estadosFinancierosPorID(txtCajaOrigen.Tag)

            lsvProveedor.Items.Clear()
            For Each i As estadosFinancieros In estadosFinancierosSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = strEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                Dim n As New ListViewItem(i.idestado)
                n.SubItems.Add(i.cuenta)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.usuarioActualizacion)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub tipoPersona(strTipo As String)

        Select Case strTipo
            Case "RUC"
                btnRuc.Checked = True
                If btnRuc.Checked = True Then
                    btnDni.Enabled = False
                    btnRuc.Enabled = True
                    btnPassport.Enabled = False
                    btnCarnetEx.Enabled = False
                End If

            Case "BOLETA"
                btnDni.Checked = True
                If btnDni.Checked = True Then
                    btnDni.Enabled = True
                    btnRuc.Enabled = True
                    btnRuc.Checked = False
                    btnPassport.Enabled = False
                    btnCarnetEx.Enabled = False
                End If
        End Select
       
    End Sub

    Private Sub txtIngresoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtIngresoMN.ValueChanged

    End Sub

    Private Sub txtAnticipoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtAnticipoMN.ValueChanged

    End Sub

    Private Sub txtVueltoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtVueltoMN.ValueChanged

    End Sub

    Private Sub txtCobroMN_ValueChanged(sender As Object, e As EventArgs) Handles txtCobroMN.ValueChanged

    End Sub

    Private Sub txtTipoCambioVenta_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambioVenta.ValueChanged

    End Sub
End Class