Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools
Public Class frmControlEntregables
    Inherits frmMaster

    Dim ListaAsientonTransito As New List(Of asiento)
    'Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Public Property ListaTipoCambio As New List(Of TipoCambioSunatV2)
    Private sToolTip As SuperToolTip
    Private IdDocumentoOrden As Integer

    Private conteoListaServicio As Integer = 0

    Private ServicioHijo As New List(Of servicio)
    Public Property ListadoProveedores As New List(Of entidad)

    Public Property ListadoDestinatarios As New List(Of entidad)

    Public Property ListadoUbigeo As New List(Of ubigeo)

    Sub Recomendacion()
        'lblEstado.Text = "Indicaciones: Identifique la fecha y el tipo de documento de la compra y luego identifique al proveedor!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(20)
    End Sub

    Public Sub New(IdDocumento As Integer)
        'IdDocumento As Integer
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompra)
        GridCFG(dgvCanastaExistencia)
        Loadcontroles()
        GetTableGrid()
        GetTablebigeo()
        ConfiguracionInicio()
        UbicarDocumento(IdDocumento)
        GetListaVentasPorPeriodo(IdDocumento)
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

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False
        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left
        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub ConfiguracionInicio()
        'TotalesXcanbeceras = New TotalesXcanbecera()
        'Dim almacenSA As New almacenSA
        'idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
        'configurando docking manager
        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            ' dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            dockingManager1.SetDockLabel(Panel2, "Existencias")
            'Panel5.Visible = False
        Else
            'dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            'dockingManager1.SetDockLabel(Panel2, "Existencias")
            dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            ' dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
            dockingManager1.SetDockLabel(Panel2, "Existencias")
        End If
        'dockingManager1.SetDockLabel(Panel4, "Activo Inmovilizado")
        dockingManager1.CloseEnabled = False
        'If Not IsNothing(GFichaUsuarios) Then
        ' ToolStripButton1.Image = ImageListAdv1.Images(1)
        'dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'Else
        'dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'ToolStripButton1.Image = ImageListAdv1.Images(0)
        'GFichaUsuarios = Nothing
        'End If
        'dgvCompra.TableDescriptor.Columns("pume").Width = 0
        'dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        'dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        'dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        'dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        cboMoneda.SelectedValue = 1
        'confgiurando variables generales
        txtGlosa.Text = "Guia por la venta según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        lblPerido.Text = PeriodoGeneral
        '   txtTipoCambio.DecimalValue = TmpTipoCambio
        'ListaTipoCambio = New List(Of tipoCambio)
        'LoadTipoCambio()

        txtfehcaEmision.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtfechaTraslado.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        'txtFecVence.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
    End Sub

    Public Sub GetTablebigeo()
        Dim ubigeoSA As New ubigeoSA
        'Dim dt As New DataTable()
        'dt.Columns.Add("ubigeo", GetType(Integer))
        'dt.Columns.Add("departamento", GetType(String))

        ListadoUbigeo = (ubigeoSA.listarUbigeo)

    End Sub


    'Sub Grabar()
    '    Dim VentaSA As New documentoVentaAbarrotesSA
    '    Dim ndocumento As New documento()
    '    Dim DocCaja As New documento
    '    Dim ListaTotales As New List(Of totalesAlmacen)
    '    DimdocVentaSA As New documentoVentaAbarrotesSA
    '    Dim nDocumentoVenta As New documentoventaAbarrotes()
    '    Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
    '    Dim entidadSA As New entidadSA
    '    Dim entidad As New entidad
    '    Dim asientoSA As New AsientoSA
    '    ' Dim ListaAsiento As New List(Of asiento)
    '    Dim nAsiento As New asiento
    '    Dim nMovimiento As New movimiento
    '    Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
    '    dgvCompra.TableControl.CurrentCell.EndEdit()
    '    dgvCompra.TableControl.Table.TableDirty = True
    '    dgvCompra.TableControl.Table.EndEdit()
    '    '-------------------------------------------------------------------------------------
    '    ndocumento = New documento
    '    ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
    '    ndocumento.TieneCotizacion = TieneCotizacionInfo
    '    ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
    '    ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
    '    If IsNothing(GProyectos) Then
    '    Else
    '        ndocumento.idProyecto = GProyectos.IdProyectoActividad
    '    End If
    '    ndocumento.tipoDoc = GConfiguracion.TipoComprobante
    '    ndocumento.fechaProceso = txtFecha.Value
    '    ndocumento.nroDoc = GConfiguracion.Serie
    '    ndocumento.idOrden = Nothing ' Me.IdOrden
    '    ndocumento.tipoOperacion = "01"
    '    ndocumento.usuarioActualizacion = usuario.IDUsuario
    '    ndocumento.fechaActualizacion = DateTime.Now
    '    nDocumentoVenta = New documentoventaAbarrotes With {
    '        .IdDocumentoCotizacion = IdDocumentoCotizacion,
    '              .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
    '              .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
    '              .tipoOperacion = "01",
    '              .codigoLibro = "14",
    '              .tipoDocumento = GConfiguracion.TipoComprobante,
    '              .idEmpresa = Gempresas.IdEmpresaRuc,
    '              .idEstablecimiento = GEstableciento.IdEstablecimiento,
    '              .fechaDoc = txtFecha.Value,
    '              .fechaPeriodo = PeriodoGeneral,
    '              .serie = GConfiguracion.Serie,
    '              .numeroDocNormal = Nothing,
    '              .idCliente = Nothing,
    '              .nombrePedido = TXTcOMPRADOR.Text.Trim,
    '              .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2"),
    '              .tasaIgv = TmpIGV,
    '              .tipoCambio = TmpTipoCambio,
    '              .bi01 = TotalesXcanbeceras.base1,
    '              .bi02 = TotalesXcanbeceras.base2,
    '              .igv01 = TotalesXcanbeceras.MontoIgv1,
    '              .igv02 = TotalesXcanbeceras.MontoIgv2,
    '              .bi01us = TotalesXcanbeceras.base1me,
    '              .bi02us = TotalesXcanbeceras.base2me,
    '              .igv01us = TotalesXcanbeceras.MontoIgv1me,
    '              .igv02us = TotalesXcanbeceras.MontoIgv2me,
    '              .ImporteNacional = TotalesXcanbeceras.TotalMN,
    '              .ImporteExtranjero = TotalesXcanbeceras.TotalME,
    '              .tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO,
    '              .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
    '              .glosa = txtGlosa.Text.Trim,
    '              .usuarioActualizacion = usuario.IDUsuario,
    '              .fechaActualizacion = DateTime.Now}
    '    ndocumento.documentoventaAbarrotes = nDocumentoVenta
    '    'REGISTRANDO LA GUIA DE REMISION
    '    'GuiaRemision(ndocumento)
    '    For Each r As Record In dgvCompra.Table.Records
    '        objDocumentoVentaDet = New documentoventaAbarrotesDet
    '        Select Case r.GetValue("valPago")
    '            Case "Pagado"
    '                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
    '            Case Else
    '                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
    '        End Select
    '        objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
    '        objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
    '        objDocumentoVentaDet.FechaDoc = txtFecha.Value
    '        objDocumentoVentaDet.Serie = GConfiguracion.Serie
    '        objDocumentoVentaDet.NumDoc = Nothing
    '        objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
    '        If r.GetValue("tipoExistencia") = "GS" Then
    '            objDocumentoVentaDet.idAlmacenOrigen = Nothing
    '            objDocumentoVentaDet.tipoVenta = Nothing
    '        Else
    '            objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
    '            objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
    '        End If
    '        objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
    '        objDocumentoVentaDet.cuentaOrigen = Nothing
    '        objDocumentoVentaDet.idItem = r.GetValue("idProducto")
    '        objDocumentoVentaDet.DetalleItem = r.GetValue("item")
    '        objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
    '        objDocumentoVentaDet.destino = r.GetValue("gravado")
    '        objDocumentoVentaDet.unidad1 = r.GetValue("um")
    '        If CDec(r.GetValue("cantidad")) <= 0 Then
    '            MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
    '            Exit Sub
    '        End If
    '        If CDec(r.GetValue("totalmn")) <= 0 Then
    '            MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
    '            Exit Sub
    '        End If
    '        objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
    '        objDocumentoVentaDet.unidad2 = Nothing
    '        objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
    '        objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
    '        objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
    '        objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
    '        objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
    '        objDocumentoVentaDet.descuentoMN = 0
    '        objDocumentoVentaDet.descuentoME = 0
    '        objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
    '        objDocumentoVentaDet.montoIsc = 0
    '        objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
    '        objDocumentoVentaDet.otrosTributos = 0
    '        '**********************************************************************************
    '        objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
    '        objDocumentoVentaDet.montoIscUS = 0
    '        objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
    '        objDocumentoVentaDet.otrosTributosUS = 0
    '        '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
    '        objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
    '        '**********************************************************************************
    '        objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
    '        objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
    '        objDocumentoVentaDet.fechaVcto = Nothing

    '        objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value())
    '        objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value())

    '        Dim cat = r.GetValue("cat")
    '        If Not IsNothing(cat) Then
    '            If cat.ToString.Trim.Length > 0 Then
    '                objDocumentoVentaDet.categoria = r.GetValue("cat")
    '            Else
    '                objDocumentoVentaDet.categoria = Nothing
    '            End If
    '        Else
    '            objDocumentoVentaDet.categoria = Nothing
    '        End If
    '        objDocumentoVentaDet.preEvento = Nothing
    '        objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
    '        objDocumentoVentaDet.fechaModificacion = Date.Now
    '        objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
    '        ListaDetalle.Add(objDocumentoVentaDet)
    '    Next
    '    ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

    '    If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
    '        Dim listaTotalAlmacen As Integer = VentaSA.SaveVentaTicketPS(ndocumento, Nothing)

    '        If (Not IsNothing(listaTotalAlmacen)) Then
    '            lblEstado.Text = "venta registrada!"
    '            ' statusForm.lblMensaje.Text = "..estableciendo..."
    '            '   Dim strNumDoc As String = String.Format("{0:00000}", Convert.ToInt32(docVentaSA.GetUbicar_documentoventaAbarrotesPorID(xcod).numeroDoc))
    '            Dim strNumDoc As String = Convert.ToInt32(docVentaSA.GetUbicar_documentoventaAbarrotesPorID(listaTotalAlmacen).numeroDoc)
    '            'TimerCustom.Enabled = True
    '            'TimerCustom.Start()
    '            Dim statusForm As New frmMensajeCodigoVenta
    '            statusForm.StartPosition = FormStartPosition.CenterScreen
    '            statusForm.lblMensaje.Text = strNumDoc '.Replace("0", "")
    '            statusForm.ShowDialog()

    '            ' statusForm.Dispose()
    '            Dispose()
    '        Else
    '            lblEstado.Text = "Excedio la cantidad de venta"
    '            PanelError.Visible = True
    '            Timer1.Enabled = True
    '            TiempoEjecutar(10)
    '            limpiarCajas()
    '        End If
    '    Else
    '        Throw New Exception("Debe verificar que las celdas estan completas!")
    '    End If
    'End Sub

    Public Sub GuiaRemision()

        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        Dim ndocumento As New documento()
        Dim objGuia As New DocumentoGuiaSA
        'REGISTRANDO LA GUIA DE REMISION

        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        'ndocumento.TieneCotizacion = TieneCotizacionInfo
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = cboTipoDoc.SelectedValue
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = txtNumero.Text
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.tipoOperacion = "01"
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtfehcaEmision.Value
            .periodo = PeriodoGeneral
            .tipoDoc = "99"
            .idEntidad = CInt(txtProveedor.Tag)
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tipoCambio = txtTipoCambio.DecimalValue
            .fechaTraslado = txtfechaTraslado.Value
            .tipoMovimiento = "VNT"
            .direccionPartida = txtdireccionPartida.Text
            .ubigeo = txtUbigeo.Tag
            .idEntidadTransporte = txtCliente2.Tag
            .estado = TipoGuia.Pendiente
            .tipoVehiculo = txtTipoVehiculo.Text
            .marcaVehiculo = txtMarcaVehiculo.Text
            .placaVehiculo = txtPlacaVehiculo.Text
            .placaRemolque = txtPlacaRemolque.Text
            .certificado = txtCertificado.Text
            .nroBrevete = txtBrevete.Text

            '.importeMN = TotalesXcanbeceras.TotalMN
            '.importeME = TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoGuia = guiaRemisionBE

        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("tipoExistencia") <> "GS" Then
                '     If r.GetValue("almacen") <> idAlmacenVirtual Then
                documentoguiaDetalle = New documentoguiaDetalle
                If txtSerieGuia.Text.Trim.Length > 0 Then
                    ndocumento.documentoGuia.serie = txtSerieGuia.Text
                Else
                    Throw New Exception("Ingrese número de serie de la guía!")
                End If
                If txtNumeroGuia.Text.Trim.Length > 0 Then
                    ndocumento.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                Else
                    Throw New Exception("Ingrese el nùmero de la guía!")
                End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.GetValue("idItem")
                documentoguiaDetalle.descripcionItem = r.GetValue("descripcion")
                'documentoguiaDetalle.destino = r.GetValue("gravado")
                'documentoguiaDetalle.unidadMedida = r.GetValue("um")
                documentoguiaDetalle.cantidad = CDec(r.GetValue("unidad"))
                'documentoguiaDetalle.precioUnitario = CDec(r.GetValue("pumn"))
                'documentoguiaDetalle.precioUnitarioUS = CDec(r.GetValue("pume"))
                'documentoguiaDetalle.importeMN = CDec(r.GetValue("totalmn"))
                'documentoguiaDetalle.importeME = CDec(r.GetValue("totalme"))
                'documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                'documentoguiaDetalle.observaciones = r.GetValue("observaciones")
                documentoguiaDetalle.estado = TipoGuiaDetalle.Pendiente
                documentoguiaDetalle.puntoLlegada = r.GetValue("puntoLlegada")
                documentoguiaDetalle.ubigeo = r.GetValue("idUbigeo")
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.idDocumentoPadre = CInt(r.GetValue("idDocumento"))
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If
        Next
        ndocumento.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle

        Dim listaTotalAlmacen As Integer = objGuia.SaveGuiaRemisionEntregado(ndocumento)
    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle

        Try
            'DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            'If Not IsNothing(DocumentoGuia) Then
            '    With DocumentoGuia
            '        txtSerieGuia.Text = .Serie
            '        txtNumeroGuia.Text = .Numero
            '    End With
            'End If

            'CABECERA COMPROBANTE
            With objDocCompra.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
                'If Not IsNothing(.fechaConstancia) Then
                '    txtFecDetraccion.Value = .fechaConstancia
                'End If
                'txtNroConstancia.Text = .nroConstancia
                txtFecha.Value = .fechaDoc
                'lblIdDocumento.Text = .idDocumento
                PeriodoGeneral = .fechaPeriodo
                cboTipoDoc.SelectedValue = .tipoDocumento
                cboMoneda.SelectedValue = .moneda

                '.p()
                If ((.idCliente) <> 0) Then
                    nEntidad = objEntidad.UbicarEntidadPorID(.idCliente).First()
                    txtRuc.Text = nEntidad.nrodoc


                    txtProveedor.Text = nEntidad.nombreCompleto
                    txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtProveedor.Tag = nEntidad.idEntidad
                Else
                    'txtProveedor.Text = 

                End If
               
                'TextBoxExt3.Text = nEntidad.direccion

                txtTipoCambio.DecimalValue = .tipoCambio
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa

                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc

                'Select Case .tieneDetraccion
                '    Case "S"
                '        chDetraccion.Checked = True
                '    Case Else
                '        chDetraccion.Checked = False
                'End Select

            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()


        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtCliente2.Text = .nombreCompleto
                txtCliente2.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc2.Text = .nrodoc
                txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            txtCliente2.Clear()
            '  txtCuenta.Clear()
            txtRuc2.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub

    Public Sub UbicarEntidadPorRucDestinatario(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            txtProveedor.Clear()
            '  txtCuenta.Clear()
            txtRuc.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub


    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarAcanastaServicio()
        Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim tasaIva As Decimal = TmpIGV / 100
        Dim productoSA As New detalleitemsSA


        'valPUmn = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciomn")
        'valPUme = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciome")

        If (Me.dgvCanastaExistencia.Table.CurrentRecord.GetValue("pendiente") > 0) Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("idDocumento", Me.dgvCanastaExistencia.Table.CurrentRecord.GetValue("idDocumento"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("secuencia", Me.dgvCanastaExistencia.Table.CurrentRecord.GetValue("secuencia"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "01")
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", Me.dgvCanastaExistencia.Table.CurrentRecord.GetValue("pendiente"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("unidad", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idItem", Me.dgvCanastaExistencia.Table.CurrentRecord.GetValue("idItem"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("descripcion", Me.dgvCanastaExistencia.Table.CurrentRecord.GetValue("descripcionItem"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("puntoLlegada", "")
            'Me.dgvCompra.Table.CurrentRecord.SetValue("observaciones", "")
            Me.dgvCompra.Table.CurrentRecord.SetValue("idUbigeo", "")
            Me.dgvCompra.Table.CurrentRecord.SetValue("nombreUbigeo", "")
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
            dgvCompra.TableControl.CurrentCell.EndEdit()
            dgvCompra.TableControl.Table.TableDirty = True
            dgvCompra.TableControl.Table.EndEdit()
        Else
            lblEstado.Text = "Ya realizo las entregas pendientes"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

    End Sub

    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim listatabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim servicioSA As New servicioSA
        Dim efSA As New EstadosFinancierosSA
        Dim entidadSA As New entidadSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0

        'COMPROBANTE TIPO DOCUMENTOS
        Dim list As New List(Of String)
        list.Add("07")
        list.Add("08")
        list.Add("02")
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(10, "1")

        Dim Comprobantes = (From n In listatabla _
                           Where Not list.Contains(n.codigoDetalle)).ToList


        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = Comprobantes

        'TIPO DE EXISTENCIA
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(5, "1")
        Dim listaNoExistencias As New List(Of String)
        listaNoExistencias.Add("06")
        listaNoExistencias.Add("07")
        listaNoExistencias.Add("08")
        listaNoExistencias.Add("02")

        Dim consultaExistencia = (From n In listatabla _
                                 Where Not listaNoExistencias.Contains(n.codigoDetalle)).ToList

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = consultaExistencia
        '-------------------------------------------------------------------
        'TextBoxExt3.Visible = True
        'PictureBox5.Visible = True

        'Label31.Text = "Buscar activo"
        'CboClasificacion1.Visible = False
        'PictureBox4.Visible = False
        ''------------------------------------

        'Label39.Visible = False
        'cboProductos2.Visible = False
        'PictureBox7.Visible = False

        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            cboDestino.Enabled = False
        Else
            cboDestino.Enabled = True
        End If

        ListadoProveedores = New List(Of entidad)
        ListadoProveedores = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        ListadoDestinatarios = New List(Of entidad)
        ListadoDestinatarios = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento", GetType(String))
        dt.Columns.Add("secuencia", GetType(String))
        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("cantidad", GetType(Integer))
        dt.Columns.Add("unidad", GetType(String))
        dt.Columns.Add("idItem", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("puntoLlegada", GetType(String))
        dt.Columns.Add("observaciones", GetType(String))
        dt.Columns.Add("idUbigeo", GetType(String))
        dt.Columns.Add("nombreUbigeo", GetType(String))
        dgvCompra.DataSource = dt
        'dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50

    End Sub

    Private Sub GetListaVentasPorPeriodo(stridDocimento As Integer)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesDetSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        'Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("secuencia", GetType(String)))
        dt.Columns.Add(New DataColumn("idItem", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcionItem", GetType(String)))
        dt.Columns.Add(New DataColumn("entregado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("pendiente", GetType(Integer)))
        dt.Columns.Add(New DataColumn("totalCant", GetType(Integer)))

        For Each i As documentoventaAbarrotesDet In DocumentoVentaSA.GetListarAllVentasEntregablesDeMercaderia(GEstableciento.IdEstablecimiento, PeriodoGeneral, stridDocimento)
            Dim dr As DataRow = dt.NewRow()



            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.idItem
            dr(3) = i.nombreItem
            dr(4) = CInt(i.monto2)
            dr(5) = CInt(i.monto1 - i.monto2)
            dr(6) = CInt(i.monto1)


            dt.Rows.Add(dr)
        Next
        dgvCanastaExistencia.DataSource = dt

    End Sub

    Private Sub dgvCanastaExistencia_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCanastaExistencia.TableControlCellDoubleClick

    End Sub

    Private Sub dgvCanastaExistencia_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCanastaExistencia.TableControlCurrentCellControlDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsNothing(Me.dgvCanastaExistencia.Table.CurrentRecord) Then

                ' ValidarItemsDuplicados(Val(dgvPreciosServicio.Table.CurrentRecord.GetValue("idItem")))
                'txtServicio.Text = String.Empty
                AgregarAcanastaServicio()
            End If
            '    txtBarCode.Select()
        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtProveedor.Text.Trim.Length > 0 Then

                MessageBox.Show("Ingrese el proveedor de la compra", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProveedor.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If txtProveedor.Text.Trim.Length > 0 Then
                If txtProveedor.ForeColor = Color.Black Then
                    MessageBox.Show("Verificar el ingreso correcto del proveedor", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtProveedor.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If

            If Not txtUbigeo.Tag.ToString.Length > 0 Then
                MessageBox.Show("Verificar el ingreso del ubigeo", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProveedor.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If



            Dim contador As Integer
            Dim contUbgeo As Integer
            For Each item In dgvCompra.Table.Records
                If (item.GetValue("unidad") = 0) Then
                    contador = +1
                End If

                If (item.GetValue("nombreUbigeo").ToString.Length = 0) Then
                    contUbgeo = +1
                End If

            Next

            If (contador > 0) Then
                MessageBox.Show("Verificar la cantidad a entregar de la guia!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProveedor.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If (contUbgeo > 0) Then
                MessageBox.Show("Rellene todos los campos del Ubigeo!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProveedor.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            '***********************************************************************
            If dgvCompra.Table.Records.Count > 0 Then

                'If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then

                If MessageBox.Show("Está seguro de guardar la guia de remisión con fecha:" & vbCrLf & txtFecha.Value.Date, "Validar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    GuiaRemision()
                    Dispose()
                End If
                'Else


                'End If
            Else

                Me.lblEstado.Text = "Ingrese items a la canasta de venta!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

            ListaAsientonTransito = New List(Of asiento)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtCliente.Text.Trim.Length > 0 Then
                '    txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del cliente " & txtCliente.Text.Trim
                'End If
                txtNumero.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True


                txtSerieGuia.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub


    Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True


                txtNumeroGuia.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 2 ' cantidad

                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("unidad") > 0) Then
                        If (Me.dgvCompra.Table.CurrentRecord.GetValue("unidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")) Then

                        Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("unidad", 0.0)
                            Me.lblEstado.Text = "no debe exceder a la cantidad disponible!"
                            Timer1.Enabled = True
                            PanelError.Visible = True
                            TiempoEjecutar(10)
                        End If
                    Else
                        Me.dgvCompra.Table.CurrentRecord.SetValue("unidad", 0.0)
                        Me.lblEstado.Text = "la cantidad no debe ser negativo!"
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                    End If

                  

                Case 4 ' cantidad
                    'Dim a As String
                    'Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
                    'Me.popupControlContainer1.Size = New Size(241, 110)
                    'Me.popupControlContainer1.ParentControl = dgvCompra
                    'Me.popupControlContainer1.ShowPopup(Point.Empty)


                    'If (dgvCompra.Table.CurrentRecord.GetValue("puntoLlegada") <> "") Then
                    '    a = Me.dgvCompra.Table.CurrentRecord.GetValue("puntoLlegada")
                    'Else
                    '    a = ""
                    'End If

                    'Dim con = (ListadoDestinatarios.Where(Function(s) s.nombreCompleto.StartsWith(a))).ToList()

                    'lsvProveedor.DataSource = con
                    'lsvProveedor.DisplayMember = "nombreCompleto"
                    'lsvProveedor.ValueMember = "idEntidad"

                    'Dim comboTableProvincia As New DataTable
                    'Dim ubigeoSA As New ubigeoSA
                    'Dim dt As New DataTable()
                    'dt.Columns.Add("ubigeo", GetType(Integer))
                    'dt.Columns.Add("provincia", GetType(String))


                    'For Each i In ListadoUbigeo

                    '    Dim dr As DataRow = dt.NewRow()
                    '    dr(0) = i.ubigeo1
                    '    dr(1) = i.provincia
                    '    dt.Rows.Add(dr)
                    'Next


                    'comboTableProvincia = dt
                    'Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(9).Appearance.AnyRecordFieldCell
                    'ggcStyle.CellType = "ComboBox"
                    'ggcStyle.DataSource = comboTableProvincia
                    'ggcStyle.ValueMember = "ubigeo"
                    'ggcStyle.DisplayMember = "provincia"
                    'ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
                    'dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
                    'dgvCompra.ShowRowHeaders = False

                    'If (Me.dgvCompra.Table.CurrentRecord.GetValue("unidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")) Then

                    'Else
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("unidad", 0.0)
                    '    Me.lblEstado.Text = "no debe exceder a la cantidad disponible!"
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)
                    'End If

            End Select
        End If
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True


                txtProveedor.Select()

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtCliente2_TextChanged(sender As Object, e As EventArgs) Handles txtCliente2.TextChanged
        txtCliente2.ForeColor = Color.Black
        txtCliente2.Tag = Nothing
        txtRuc2.ForeColor = Color.Black
        txtRuc2.Tag = Nothing
        txtTipoVehiculo.Clear()
        txtMarcaVehiculo.Clear()
        txtPlacaVehiculo.Clear()
        txtPlacaRemolque.Clear()
        txtCertificado.Clear()
        txtBrevete.Clear()
    End Sub

    Private Sub txtCliente2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente2.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(241, 110)
            Me.popupControlContainer1.ParentControl = Me.txtCliente2
            Me.popupControlContainer1.ShowPopup(Point.Empty)

            Dim con = (ListadoDestinatarios.Where(Function(s) s.nombreCompleto.StartsWith(txtCliente2.Text))).ToList()

            lsvProveedor.DataSource = con
            lsvProveedor.DisplayMember = "nombreCompleto"
            lsvProveedor.ValueMember = "idEntidad"

            'txtCliente.DataSource = CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente.Text.Trim)
            'txtCliente.DisplayMember = "nombreCompleto"
            'txtCliente.ValueMember = "idEntidad"
        End If
        If e.KeyCode = Keys.Down Then
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(241, 110)
            Me.popupControlContainer1.ParentControl = Me.txtCliente2
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            txtCliente2.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If


        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.txtCliente2
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.popupControlContainer1.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCliente2.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.txtCliente2
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR, txtCliente2.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtRuc2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc2.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc2.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc2.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            ListadoProveedores.Add(c)
            txtCliente2.Text = c.nombreCompleto
            txtCliente2.Tag = c.idEntidad
            txtRuc2.Text = c.nrodoc
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                txtCliente2.Text = lsvProveedor.Text

                Dim con = (ListadoDestinatarios.Where(Function(s) s.idEntidad = CInt(lsvProveedor.SelectedValue))).FirstOrDefault()

                If con IsNot Nothing Then
                    txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtRuc2.Text = con.nrodoc
                    txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtCliente2.Tag = lsvProveedor.SelectedValue

                End If

                txtTipoVehiculo.Clear()
                txtMarcaVehiculo.Clear()
                txtPlacaVehiculo.Clear()
                txtPlacaRemolque.Clear()
                txtCertificado.Clear()
                txtBrevete.Clear()

            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCliente2.Focus()
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub chIdentificacion_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        'txtTipoVehiculo.Clear()
        'txtMarcaVehiculo.Clear()
        'txtPlacaVehiculo.Clear()
        'txtPlacaRemolque.Clear()
        'txtCertificado.Clear()
        'txtBrevete.Clear()
        Panel5.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtCliente2.Text.Length > 0 And txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)) Then
            Panel5.Visible = True
            txtTipoVehiculo.Select()
            txtNombreConductor.Text = txtCliente2.Text
        Else

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'txtTipoVehiculo.Clear()
        'txtMarcaVehiculo.Clear()
        'txtPlacaVehiculo.Clear()
        'txtPlacaRemolque.Clear()
        'txtCertificado.Clear()
        'txtBrevete.Clear()
        Panel5.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel5.Visible = False
    End Sub

    Private Sub txtTipoVehiculo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTipoVehiculo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtMarcaVehiculo.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtMarcaVehiculo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarcaVehiculo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtPlacaVehiculo.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtPlacaVehiculo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPlacaVehiculo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtPlacaRemolque.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtPlacaRemolque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPlacaRemolque.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtBrevete.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtBrevete_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBrevete.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtCertificado.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged
        txtProveedor.ForeColor = Color.Black
        txtProveedor.Tag = Nothing
        txtRuc.ForeColor = Color.Black
        txtRuc.Tag = Nothing
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.PopupControlContainer4.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(241, 110)
            Me.PopupControlContainer4.ParentControl = Me.txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)

            Dim con = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()

            lsvDestinatario.DataSource = con
            lsvDestinatario.DisplayMember = "nombreCompleto"
            lsvDestinatario.ValueMember = "idEntidad"

            'txtCliente.DataSource = CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente.Text.Trim)
            'txtCliente.DisplayMember = "nombreCompleto"
            'txtCliente.ValueMember = "idEntidad"
        End If
        If e.KeyCode = Keys.Down Then
            Me.PopupControlContainer4.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(241, 110)
            Me.PopupControlContainer4.ParentControl = Me.txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            txtProveedor.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer4.IsShowing() Then
                Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
            End If
        End If


        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.PopupControlContainer4.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer4.ParentControl = Me.txtProveedor
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer4.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer4.IsShowing() Then
                Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor.Text.Trim.Length > 0 Then
                Me.PopupControlContainer4.ParentControl = Me.txtProveedor
                Me.PopupControlContainer4.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRucDestinatario(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            ListadoProveedores.Add(c)
            txtProveedor.Text = c.nombreCompleto
            txtProveedor.Tag = c.idEntidad
            txtRuc.Text = c.nrodoc
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub lsvDestinatario_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvDestinatario.MouseDoubleClick
        If lsvDestinatario.SelectedItems.Count > 0 Then
            Me.PopupControlContainer4.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtProveedor.MouseDoubleClick

    End Sub
    'Dim comboTableP As New DataTable
    'Private Sub frmControlEntregables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    comboTableP = Me.GetTableAlmacen
    '    Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(9).Appearance.AnyRecordFieldCell
    '    ggcStyle.CellType = "ComboBox"
    '    ggcStyle.DataSource = Me.comboTableP
    '    ggcStyle.ValueMember = "ubigeo"
    '    ggcStyle.DisplayMember = "departamento"
    '    ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    '    dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    '    dgvCompra.ShowRowHeaders = False
    'End Sub


    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyDown
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Select Case ColIndex
        '        Case 6 ' cantidad
        '            Panel7.Visible = True
        '    End Select
        'End If
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Select Case ColIndex
        '        Case 4 ' cantidad
        '            Dim a As String
        '            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
        '            Me.popupControlContainer1.Size = New Size(241, 110)
        '            Me.popupControlContainer1.ParentControl = dgvCompra
        '            Me.popupControlContainer1.ShowPopup(Point.Empty)


        '            If (dgvCompra.Table.CurrentRecord.GetValue("puntoLlegada") <> "") Then
        '                a = Me.dgvCompra.Table.CurrentRecord.GetValue("puntoLlegada")
        '            Else
        '                a = ""
        '            End If

        '            Dim con = (ListadoDestinatarios.Where(Function(s) s.nombreCompleto.StartsWith(a))).ToList()

        '            lsvProveedor.DataSource = con
        '            lsvProveedor.DisplayMember = "nombreCompleto"
        '            lsvProveedor.ValueMember = "idEntidad"

        '    End Select
        'End If
    End Sub

    Private Sub PopupControlContainer5_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer5.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvDepartamento.SelectedItems.Count > 0 Then

                If (Panel7.Tag = 1) Then
                    TextBoxExt1.Text = lsvDepartamento.Text
                    TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                Else
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                        TextBoxExt1.Text = lsvDepartamento.Text
                        TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If
                End If

               
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextBoxExt3.Focus()
        End If
    End Sub

    Private Sub lsvDepartamento_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvDepartamento.MouseDoubleClick
        If lsvDepartamento.SelectedItems.Count > 0 Then
            Me.PopupControlContainer5.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.PopupControlContainer5.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer5.Size = New Size(241, 110)
            Me.PopupControlContainer5.ParentControl = TextBoxExt1
            Me.PopupControlContainer5.ShowPopup(Point.Empty)

            Dim con = (ListadoUbigeo.Where(Function(s) s.departamento.StartsWith(TextBoxExt1.Text))).Distinct
            'Dim con = (From v In ListadoUbigeo Group v By v.departamento Into TupleGroup = Group Select departamento Where departamento.StartsWith(TextBoxExt1.Text)).ToList

            lsvDepartamento.DataSource = con.ToList
            lsvDepartamento.DisplayMember = "departamento"
            lsvDepartamento.ValueMember = "departamento"
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel7.Visible = False
    End Sub


    Private Sub TextBoxExt3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt3.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.PopupControlContainer6.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer6.Size = New Size(241, 110)
            Me.PopupControlContainer6.ParentControl = TextBoxExt3
            Me.PopupControlContainer6.ShowPopup(Point.Empty)

            Dim con = (ListadoUbigeo.Where(Function(s) s.departamento = TextBoxExt1.Text And s.provincia.StartsWith(TextBoxExt3.Text))).ToList()
            'Dim con = (From v In ListadoUbigeo Where v.departamento = TextBoxExt1.Text And v.provincia.StartsWith(TextBoxExt3.Text) Order By v.provincia).ToList
            lsvProvincia.DataSource = con
            lsvProvincia.DisplayMember = "provincia"
            lsvProvincia.ValueMember = "provincia"
        End If

    End Sub

    Private Sub TextBoxExt4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt4.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Me.PopupControlContainer7.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer7.Size = New Size(241, 110)
            Me.PopupControlContainer7.ParentControl = TextBoxExt4
            Me.PopupControlContainer7.ShowPopup(Point.Empty)

            Dim con = (ListadoUbigeo.Where(Function(s) s.departamento = TextBoxExt1.Text And s.provincia = TextBoxExt3.Text And s.distrito.StartsWith(TextBoxExt4.Text))).ToList()

            lsvDistrito.DataSource = con
            lsvDistrito.DisplayMember = "distrito"
            lsvDistrito.ValueMember = "distrito"
        End If
    End Sub

    Private Sub lsvProvincia_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProvincia.MouseDoubleClick
        If lsvProvincia.SelectedItems.Count > 0 Then
            Me.PopupControlContainer6.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvDistrito_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvDistrito.MouseDoubleClick
        If lsvDistrito.SelectedItems.Count > 0 Then
            Me.PopupControlContainer7.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PopupControlContainer6_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer6.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProvincia.SelectedItems.Count > 0 Then

                If (Panel7.Tag = 1) Then
                    TextBoxExt3.Text = lsvProvincia.Text
                    TextBoxExt3.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                Else
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                        TextBoxExt3.Text = lsvProvincia.Text
                        TextBoxExt3.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If
                End If

               
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextBoxExt4.Focus()
        End If
    End Sub

    Private Sub PopupControlContainer7_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer7.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvDistrito.SelectedItems.Count > 0 Then

                If (Panel7.Tag = 1) Then
                    TextBoxExt4.Text = lsvDistrito.Text
                    TextBoxExt4.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                Else
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                        TextBoxExt4.Text = lsvDistrito.Text
                        TextBoxExt4.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If
                End If
             
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextBoxExt4.Focus()
        End If
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged
        TextBoxExt1.ForeColor = Color.Black
        TextBoxExt1.Tag = Nothing
    End Sub

    Private Sub TextBoxExt3_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt3.TextChanged
        TextBoxExt3.ForeColor = Color.Black
        TextBoxExt3.Tag = Nothing
    End Sub

    Private Sub TextBoxExt4_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt4.TextChanged
        TextBoxExt4.ForeColor = Color.Black
        TextBoxExt4.Tag = Nothing
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (TextBoxExt4.Text.Length > 0 And TextBoxExt3.Text.Length > 0 And TextBoxExt1.Text.Length > 0) Then
            If (TextBoxExt4.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) And TextBoxExt3.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) And TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)) Then
                Dim nombreUbigeo As String
                Dim con = (ListadoUbigeo.Where(Function(s) s.departamento = TextBoxExt1.Text And s.provincia = TextBoxExt3.Text And s.distrito = TextBoxExt4.Text)).FirstOrDefault

                If (Panel7.Tag = 1) Then
                    nombreUbigeo = con.departamento & "/" & con.provincia & "/" & con.distrito
                    txtUbigeo.Tag = con.ubigeo1
                    txtUbigeo.Text = nombreUbigeo
                    Panel7.Visible = False
                Else
                    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                        nombreUbigeo = con.departamento & "/" & con.provincia & "/" & con.distrito
                        dgvCompra.Table.CurrentRecord.SetValue("idUbigeo", con.ubigeo1)
                        dgvCompra.Table.CurrentRecord.SetValue("nombreUbigeo", nombreUbigeo)
                        TextBoxExt1.Clear()
                        TextBoxExt4.Clear()
                        TextBoxExt3.Clear()
                        Panel7.Visible = False
                    End If
                End If

            Else
                Me.lblEstado.Text = "Debe ingresar bien los campos!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If
        Else
            Me.lblEstado.Text = "Debe ingresar bien los campos!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvDestinatario.SelectedItems.Count > 0 Then
                txtProveedor.Text = lsvDestinatario.Text

                Dim con = (ListadoProveedores.Where(Function(s) s.idEntidad = CInt(lsvDestinatario.SelectedValue))).FirstOrDefault()

                If con IsNot Nothing Then
                    txtRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtRuc.Text = con.nrodoc
                    txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtProveedor.Tag = lsvDestinatario.SelectedValue

                End If

            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCliente2.Focus()
        End If
    End Sub

    Private Sub dgvCompra_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvCompra.TableControlPushButtonClick
        Panel7.Tag = 0
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If (ColIndex = 5) Then

                TextBoxExt1.Clear()
                TextBoxExt3.Clear()
                TextBoxExt4.Clear()
                Panel7.Visible = True

            Else
                Me.lblEstado.Text = "Debe seleccionar el campo Provincia/Departamento/Distrito!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If
        Else
            Me.lblEstado.Text = "Debe seleccionar el campo Provincia/Departamento/Distrito!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If

    End Sub

    Private Sub lsvDestinatario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvDestinatario.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBoxExt1.Clear()
        TextBoxExt3.Clear()
        TextBoxExt4.Clear()
        Panel7.Visible = True
        Panel7.Tag = 1
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim idUbigeo As String
        Dim nombreUbigeo As String
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            idUbigeo = dgvCompra.Table.CurrentRecord.GetValue("idUbigeo")
            nombreUbigeo = dgvCompra.Table.CurrentRecord.GetValue("nombreUbigeo")
            For Each item In dgvCompra.Table.Records
                item.SetValue("idUbigeo", idUbigeo)
                item.SetValue("nombreUbigeo", nombreUbigeo)
            Next
        End If
    End Sub
End Class