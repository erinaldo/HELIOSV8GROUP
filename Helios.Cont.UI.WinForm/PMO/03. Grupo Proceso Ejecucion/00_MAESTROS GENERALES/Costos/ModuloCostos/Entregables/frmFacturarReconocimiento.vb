Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmFacturarReconocimiento
    Implements IForm

#Region "Fields"
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property listaClientes As New List(Of entidad)
    Public Property entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Friend Delegate Sub SetDataSourceDelegateNumeracion(ByVal numeracion As moduloConfiguracion)
    Public ListaEstadosFinancieros As List(Of estadosFinancieros)
    '    Public ListaTipoExistencia As List(Of tabladetalle)
    '   Public ListaComprobantesCaja As List(Of tabladetalle)
    Public ListaAlmacenes As List(Of almacen)
    Public Alert As Alert
    Public Property documentoVenta As documentoventaAbarrotes
    Public Property documentoVentaDetalle As List(Of documentoventaAbarrotesDet)
    Public Property entidad As entidad
    Public Property frmCanastaInventary As frminfoInventario
    Public Property InventarioSA As New TotalesAlmacenSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCompra, False, False)
        FormatoGridAvanzado(dgCanastaSel, True, False)
        frmCanastaInventary = New frminfoInventario()
        ConfiguracionInicio()
        GetTableGrid()
        threadClientes()
        bgCombos.RunWorkerAsync()
        ' ThreadNumeracion()
    End Sub

    Public Sub New(iddocumento As Integer)
        InitializeComponent()
        FormatoGridAvanzado(dgvCompra, False, False)
        FormatoGridAvanzado(dgCanastaSel, True, False)
        frmCanastaInventary = New frminfoInventario
        ConfiguracionInicio()
        GetTableGrid()
        threadClientes()
        bgCombos.RunWorkerAsync()
        Tag = iddocumento
        bgVenta.RunWorkerAsync()
    End Sub
#End Region

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

#Region "Methods"


    Public Sub LlenarReconocimientos(objeto As List(Of totalesAlmacen))
        'Dim valPUmn As Decimal = 0
        'Dim valPUme As Decimal = 0

        'valPUmn = productoBE.PMprecioMN
        'valPUme = productoBE.PMprecioME

        ''With productoSA.InvocarProductoID(r.GetValue("idItem"))


        'Dim cantidad = InputBox("Ingrese cantidad a vender", productoBE.descripcion, "")
        'If IsNumeric(cantidad) Then
        '    If cantidad <= 0 Then
        '        MessageBox.Show("La cantidad ingresada debe ser mayor a cero!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        Exit Sub
        '        Cursor = Cursors.Default
        '    End If

        '    If (CDec(cantidad) > productoBE.cantidad) Then
        '        MessageBox.Show("La cantidad ingresada no debe exceder la disponible!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        Exit Sub
        '        Cursor = Cursors.Default
        'End If

        'ValidarStockDisponible(Integer.Parse(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", e.RowIndex)),
        '                      Integer.Parse(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idalmacen", e.RowIndex)),
        '                       cantidad)
        'CalculosByCantidad(CDec(cantidad))

        'Dim colBI As Decimal = 0
        'Dim colBIme As Decimal = 0
        ''Dim Igv As Decimal = 0
        ''Dim IgvME As Decimal = 0

        ''Dim colPrecUnitAlmacen = objeto.importeSoles / 1
        ''Dim colPrecUnitUSAlmacen = objeto.importeDolares / objeto.cantidad
        ''Dim colPrecUnit = valPUmn
        ''Dim colPrecUnitme = valPUme
        ''  Dim colDestinoGravado = productoBE.origenRecaudo

        ''Dim colCostoMN = cantidad * colPrecUnitAlmacen
        ''Dim colCostoME = cantidad * colPrecUnitUSAlmacen

        ''Dim totalMN = cantidad * colPrecUnit
        ''Dim totalME = cantidad * colPrecUnitme

        'Dim iva As Decimal = TmpIGV / 100

        ''If objeto.cantidad > 0 Then

        'colBI = (objeto.importeSoles / (iva + 1))
        'colBIme = (objeto.importeDolares / (iva + 1))

        '    Dim iv As Decimal = 0
        '    Dim iv2 As Decimal = 0
        '    iv = objeto.importeSoles / (iva + 1)
        '    iv2 = objeto.importeDolares / (iva + 1)

        '    Igv = iv * (iva)
        '    IgvME = iv2 * (iva)

        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

        'Else
        '    colBI = 0
        '    colBIme = 0
        '    Igv = 0
        '    IgvME = 0
        'End If
        For Each i In objeto

            Dim colBI As Decimal = 0
            Dim colBIme As Decimal = 0
            Dim iva As Decimal = TmpIGV / 100

            If i.origenRecaudo = "1" Then


                If iva = 0 Then
                    colBI = CDec(0.0)
                Else
                    'colBI = (i.importeSoles * (iva + 1))
                    colBI = Math.Round(CDec(i.importeSoles) * (iva), 2)
                    '  Igv = Math.Round(VC * (TmpIGV / 100), 2)

                End If
            ElseIf i.origenRecaudo = "2" Then
                colBI = CDec(0.0)
            End If
                'colBIme = (i.importeDolares / (iva + 1))

                With dgvCompra.Table
                    .AddNewRecord.SetCurrent()
                    .AddNewRecord.BeginEdit()
                    .CurrentRecord.SetValue("codigo", 0)
                    .CurrentRecord.SetValue("gravado", i.origenRecaudo)
                    .CurrentRecord.SetValue("idProducto", i.idDocumento)
                    .CurrentRecord.SetValue("item", i.descripcion)
                    .CurrentRecord.SetValue("um", "")
                    .CurrentRecord.SetValue("cantidad", "1")
                    .CurrentRecord.SetValue("canDisponible", "1")
                    .CurrentRecord.SetValue("vcmn", i.importeSoles)
                    .CurrentRecord.SetValue("totalmn", i.importeSoles + colBI)
                    .CurrentRecord.SetValue("MontoSaldo", CDec(0.0))

                    .CurrentRecord.SetValue("vcme", CDec(0.0))
                    .CurrentRecord.SetValue("totalme", CDec(0.0))
                    .CurrentRecord.SetValue("igvmn", colBI)
                    .CurrentRecord.SetValue("igvme", CDec(0.0))
                    .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                    .CurrentRecord.SetValue("marca", Nothing)

                    .CurrentRecord.SetValue("pumn", i.importeSoles)
                    .CurrentRecord.SetValue("pume", CDec(0))

                    .CurrentRecord.SetValue("puKardex", CDec(0))
                    .CurrentRecord.SetValue("pukardeme", CDec(0))

                    .CurrentRecord.SetValue("chPago", False)
                    .CurrentRecord.SetValue("valPago", "No Pagado")

                    .CurrentRecord.SetValue("chBonif", False)
                    .CurrentRecord.SetValue("valBonif", "N")
                    '   If .tipoExistencia <> "GS" Then
                    .CurrentRecord.SetValue("almacen", "")
                    .CurrentRecord.SetValue("presentacion", "")

                    .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                    .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                    .CurrentRecord.SetValue("costoMN", CDec(0))
                    .CurrentRecord.SetValue("costoME", CDec(0))
                    '.CurrentRecord.SetValue("tipoPrecio", "")
                    '.CurrentRecord.SetValue("cboprecio", Integer.Parse(productoBE.tipoConfiguracion))
                    .CurrentRecord.SetValue("cat", 0)
                    '.CurrentRecord.SetValue("codigoLote", productoBE.codigoLote)
                    '.CurrentRecord.SetValue("codBarra", productoBE.CodigoBarra)
                    .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                    .CurrentRecord.SetValue("tipoventa", "V")
                    .AddNewRecord.EndEdit()
                    .TableDirty = True
                End With
        Next

        TotalTalesXcolumna()
        'ConteoLabelVentas()
        'TotalTalesXcolumna()

        'Dim conexos = InventarioSA.ListProductsConexos(New totalesAlmacen With {.idMovimiento = productoBE.idMovimiento})
        'If conexos.Count > 0 Then
        '    If MessageBox.Show("El producto tiene, articulos conexos, desea agregarlos", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '        GetproductsConexos(valPUmn, valPUme, conexos)
        '    End If
        'End If
        'Else
        '    MessageBox.Show("Ingrese una cantidad válida!", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return
        'End If
    End Sub




    Public Sub GetDocumentoVentaID(ID As Integer)
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA

        documentoVenta = New documentoventaAbarrotes
        documentoVentaDetalle = New List(Of documentoventaAbarrotesDet)

        documentoVenta = objDocCompra.GetUbicar_documentoventaAbarrotesPorID(ID)
        entidad = entidadSA.UbicarEntidadPorID(documentoVenta.idCliente).FirstOrDefault
        documentoVentaDetalle = objDocCompraDet.usp_EditarDetalleVenta(ID)
    End Sub

    Public Sub GetDocumentoVentaIDDone()
        'CABECERA COMPROBANTE
        With documentoVenta
            txtFecha.Value = .fechaDoc
            lblPerido.Text = .fechaPeriodo
            txtSerie.Text = .serieVenta
            txtNumero.Text = .numeroVenta
            txtNumero.Visible = True
            Dim codigoComprobante = .tipoDocumento
            Select Case codigoComprobante
                Case "12.1"
                    cboTipoDoc.Text = "BOLETA"
                Case "12.2"
                    cboTipoDoc.Text = "FACTURA"
            End Select
            cboTipoDoc.SelectedValue = .tipoDocumento

            dgvCompra.TableDescriptor.Columns("pumn").Width = 60
            dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
            dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
            dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

            dgvCompra.TableDescriptor.Columns("pume").Width = 0
            dgvCompra.TableDescriptor.Columns("vcme").Width = 0
            dgvCompra.TableDescriptor.Columns("igvme").Width = 0
            dgvCompra.TableDescriptor.Columns("totalme").Width = 0

            If Not IsNothing(entidad) Then
                txtruc.Text = entidad.nrodoc
                TXTcOMPRADOR.Tag = entidad.idEntidad
                TXTcOMPRADOR.Text = entidad.nombreCompleto
                TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtruc.Visible = True
            Else
                TXTcOMPRADOR.Text = .nombrePedido
            End If
            txtGlosa.Text = .glosa
        End With

        'DETALLE DE LA COMPRA
        dgvCompra.Table.Records.DeleteAll()
        For Each i In documentoVentaDetalle
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", i.stock)

            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        btGrabar.Enabled = False
        TotalTalesXcolumna()
    End Sub

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

    Sub AsientoVenta(listadoExistencias As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoExistencias
                         Into totalMN = Sum(n.importeMN),
                         TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
            nAsiento.idEntidad = Integer.Parse(TXTcOMPRADOR.Tag)
        Else
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
            nAsiento.idEntidad = Integer.Parse(0)
        End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = usuario.IDUsuario

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoExistencias
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoExistencias
            'MV_Item_Transito(i.DetalleItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)
            nMovimiento = New movimiento
            nMovimiento.cuenta = "70111"
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next

    End Sub

    Sub AsientoVentaServicios(listadoServicios As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoServicios
                    Into totalMN = Sum(n.importeMN),
                    TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.periodo = lblPerido.Text
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nAsiento.idEntidad = Integer.Parse(TXTcOMPRADOR.Tag) ' txtIdCliente.Text
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        Else
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
            nAsiento.idEntidad = Integer.Parse(0)
        End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = usuario.IDUsuario
        Else
            nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoServicios
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoServicios
            nMovimiento = New movimiento
            nMovimiento.cuenta = "7041" 'i.idItem
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next

    End Sub

    Public Function AS_Cliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1213",
              .descripcion = TXTcOMPRADOR.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If TXTcOMPRADOR.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
        End If

        If txtTotalPagar.DecimalValue <= 0 Then
            ErrorProvider1.SetError(txtTotalPagar, "La venta debe ser mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtTotalPagar, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Sub Grabar()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
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

        Dim TipoCobro As String

        Dim proveedor As String
        Dim idProveedor As Integer
        Dim conteoCantidad As Integer
        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.moneda = "1"

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = txtruc.Text
            ndocumento.idEntidad = Val(TXTcOMPRADOR.Tag)
        Else
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        End If
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        TipoCobro = TIPO_VENTA.PAGO.COBRADO
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim tipoEstado = TipoGuia.Entregado

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TXTcOMPRADOR.Text
            idProveedor = CInt(TXTcOMPRADOR.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If


        nDocumentoVenta = New documentoventaAbarrotes With {
                  .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = lblPerido.Text,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = proveedor,
                  .moneda = "1",
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.VENTA_RECONOCIMIENTO,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .terminos = "CONTADO",
                  .glosa = txtGlosa.Text.Trim,
                  .fechaVcto = txtFecha.Value,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records

            If CDec(r.GetValue("cantidad")) <= 0 Then
                'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Throw New Exception("Debe ingresar un cantidad mayor a cero.")
                'Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                Throw New Exception("El importe de venta debe ser mayor a cero.")
                '  MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                '  Exit Sub
            End If
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            ' objDocumentoVentaDet.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
            'If ChPagoDirecto.Checked Then
            '    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            'ElseIf ChPagoAvanzado.Checked Then
            '    If CDec(r.GetValue("MontoSaldo")) <= 0 Then
            '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            '    Else
            '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            '    End If
            'Else
            objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            ' End If

            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = GConfiguracion.Serie
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            'If r.GetValue("tipoExistencia") = "GS" Then
            '    objDocumentoVentaDet.idAlmacenOrigen = Nothing
            '    objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            'Else
            '    objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
            '    objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            'End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            ' objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            ' objDocumentoVentaDet.unidad1 = r.GetValue("um")
            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            '**********************************************************************************
            'objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
            'objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = txtFecha.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            'objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
            ' objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            ' objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            'If (TipoEntrega = TipoEntregado.PorEntregar) Then
            '    conteoCantidad = CDec(r.GetValue("cantEntregar"))
            'End If
            objDocumentoVentaDet.categoria = Nothing
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)
        Next
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        'Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
        '                                                               Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        'If listaExistencias.Count > 0 Then
        '    AsientoVenta(listaExistencias)
        'End If

        'Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
        '                                                             Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        'If listaServicios.Count > 0 Then
        '    AsientoVentaServicios(listaServicios)
        'End If

        'GuiaRemision(ndocumento)

        'If ChPagoDirecto.Checked Then
        '    ndocumento.ListaCustomDocumento = ListaDocumentoCaja()
        '    ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        '    ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
        'ElseIf ChPagoAvanzado.Checked = True Then
        '    Dim f As New frmFormatoPagoComprobantes
        '    f.txtMontoXcobrar.Text = txtTotalPagar.DecimalValue
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        '    If f.Tag IsNot Nothing Then
        '        Dim c = CType(f.Tag, List(Of documentoCaja))
        '        If c.Count > 0 Then
        '            Dim ListaPagos = ListaPagosCajas(c, ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet)
        '            Dim SumaPagos As Decimal = 0
        '            For Each i In ListaPagos
        '                SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
        '            Next
        '            If SumaPagos = txtTotalPagar.DecimalValue Then
        '                ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
        '            Else
        '                ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
        '            End If
        '            ndocumento.documentoventaAbarrotes.estadoCobro = ndocumento.documentoventaAbarrotes.GetEstadoPagoComprobante
        '            ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
        '        Else
        '            MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Exit Sub
        '        End If
        '    Else
        '        MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        Exit Sub
        '    End If
        'Else
        ndocumento.documentoventaAbarrotes.estadoCobro = "PN"
        ' End If


        'Dim idDocuentoGrabado As Integer
        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
            ndocumento.asiento = ListaAsientonTransito
            'idDocuentoGrabado = VentaSA.GrabarFacReconocimiento(ndocumento)
            VentaSA.GrabarFacReconocimiento(ndocumento)
            LimpiarControles()
            'ChPagoDirecto.Checked = True
            'ChPagoAvanzado.Checked = False
            'PagoDirectoCheck()
            'Alert = New Alert("Venta registrada", alertType.success)
            'Alert.TopMost = True
            'Alert.Show()
            Dispose()
        Else
            Throw New Exception("Debe verificar que las celdas estan completas!")
        End If
    End Sub

    Private Sub GetReiniciarPagos()
        For Each i In dgvCompra.Table.Records
            i.SetValue("MontoSaldo", i.GetValue("totalmn"))
        Next
    End Sub

    Private Sub LimpiarControles()
        TXTcOMPRADOR.Clear()
        txtruc.Clear()
        dgvCompra.DataSource = New DataTable
        txtTotalBase.DecimalValue = 0
        txtTotalBase2.DecimalValue = 0
        txtTotalBase3.DecimalValue = 0
        txtTotalIva.DecimalValue = 0
        lblTotalPercepcion.DecimalValue = 0
        TXTcOMPRADOR.Clear()
        txtTotalPagar.DecimalValue = 0
        GetTableGrid()
        txtFecha.Value = Date.Now
        'ConteoLabelVentas()
        'txtStockDisponible.Clear()
        'txtCodigoBarra.Clear()
        'txtCodigoBarra.Select()
    End Sub

    Public Function ListaPagosCajas(lista As List(Of documentoCaja), ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        For Each i In lista

            nDocumentoCaja = New documento
            nDocumentoCaja.idDocumento = CInt(Me.Tag)
            nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
            nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
            nDocumentoCaja.tipoDoc = GConfiguracion.TipoComprobante ' cbotipoDocPago.SelectedValue
            nDocumentoCaja.fechaProceso = txtFecha.Value
            nDocumentoCaja.nroDoc = GConfiguracion.Serie
            nDocumentoCaja.idOrden = Nothing
            nDocumentoCaja.moneda = 1
            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
                nDocumentoCaja.entidad = TXTcOMPRADOR.Text
                nDocumentoCaja.nrodocEntidad = txtruc.Text
            Else
                nDocumentoCaja.entidad = TXTcOMPRADOR.Text
                nDocumentoCaja.nrodocEntidad = 0
                nDocumentoCaja.idEntidad = Val(0)
            End If
            nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
            nDocumentoCaja.fechaActualizacion = DateTime.Now


            'DOCUMENTO CAJA
            objCaja = New documentoCaja
            objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            objCaja.idDocumento = 0
            objCaja.periodo = lblPerido.Text
            objCaja.idEmpresa = Gempresas.IdEmpresaRuc
            objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
            objCaja.fechaProceso = txtFecha.Value
            objCaja.fechaCobro = txtFecha.Value
            objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
                objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
                objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
            End If
            objCaja.TipoDocumentoPago = GConfiguracion.TipoComprobante 'cbotipoDocPago.SelectedValue
            objCaja.codigoLibro = "1"
            objCaja.tipoDocPago = GConfiguracion.TipoComprobante
            objCaja.formapago = i.formapago
            objCaja.NumeroDocumento = "-"
            objCaja.numeroOperacion = "-"
            objCaja.movimientoCaja = TIPO_VENTA.VENTA_POS_DIRECTA
            objCaja.montoSoles = Decimal.Parse(i.montoSoles)

            objCaja.moneda = 1
            objCaja.tipoCambio = TmpTipoCambio
            objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

            objCaja.estado = "P"
            objCaja.glosa = "Por ventas POS directa"
            objCaja.entregado = "SI"

            objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            objCaja.entidadFinanciera = i.IdEntidadFinanciera
            objCaja.NombreEntidad = i.NomCajaOrigen
            objCaja.usuarioModificacion = usuario.IDUsuario
            objCaja.fechaModificacion = DateTime.Now
            nDocumentoCaja.documentoCaja = objCaja
            nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle)
            asientoDocumento(nDocumentoCaja.documentoCaja)
            ListaDoc.Add(nDocumentoCaja)
        Next

        Return ListaDoc
    End Function

    'Public Function ListaPagosCajas(lista As List(Of documentoCaja)) As List(Of documento)
    '    Dim entidadSA As New entidadSA
    '    Dim nDocumentoCaja As New documento
    '    Dim objCaja As New documentoCaja
    '    Dim ListaDoc As New List(Of documento)
    '    Dim r As Record = dgvCompra.Table.CurrentRecord
    '    For Each i In lista

    '        nDocumentoCaja = New documento
    '        nDocumentoCaja.idDocumento = CInt(Me.Tag)
    '        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
    '        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
    '        nDocumentoCaja.tipoDoc = conf.TipoComprobante ' cbotipoDocPago.SelectedValue
    '        nDocumentoCaja.fechaProceso = venta.fechaDoc
    '        nDocumentoCaja.nroDoc = conf.Serie
    '        nDocumentoCaja.idOrden = Nothing
    '        nDocumentoCaja.moneda = 1

    '        Dim cliente = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, venta.idCliente)
    '        If cliente IsNot Nothing Then
    '            nDocumentoCaja.idEntidad = cliente.idEntidad
    '            nDocumentoCaja.entidad = cliente.nombreCompleto
    '            nDocumentoCaja.nrodocEntidad = cliente.nrodoc
    '        Else
    '            nDocumentoCaja.idEntidad = "0"
    '            nDocumentoCaja.entidad = "Clientes varios"
    '            nDocumentoCaja.nrodocEntidad = "-"
    '        End If
    '        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
    '        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
    '        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
    '        nDocumentoCaja.fechaActualizacion = DateTime.Now

    '        '  documento CAJA
    '        objCaja = New documentoCaja
    '        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
    '        objCaja.idDocumento = 0
    '        objCaja.periodo = venta.fechaPeriodo
    '        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
    '        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
    '        objCaja.fechaProceso = venta.fechaDoc
    '        objCaja.fechaCobro = DateTime.Now
    '        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO

    '        If cliente IsNot Nothing Then
    '            objCaja.codigoProveedor = cliente.idEntidad
    '            objCaja.IdProveedor = cliente.idEntidad
    '            objCaja.idPersonal = Integer.Parse(cliente.idEntidad)
    '        End If

    '        objCaja.TipoDocumentoPago = conf.TipoComprobante 'cbotipoDocPago.SelectedValue
    '        objCaja.codigoLibro = "1"
    '        objCaja.tipoDocPago = conf.TipoComprobante
    '        objCaja.formapago = i.formapago
    '        objCaja.NumeroDocumento = "-"
    '        objCaja.numeroOperacion = "-"
    '        objCaja.movimientoCaja = TIPO_VENTA.VENTA_POS_DIRECTA
    '        objCaja.montoSoles = Decimal.Parse(i.montoSoles)

    '        objCaja.moneda = venta.moneda
    '        objCaja.tipoCambio = TmpTipoCambio
    '        objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

    '        objCaja.estado = "P"
    '        objCaja.glosa = "Por ventas con ticket"
    '        objCaja.entregado = "SI"

    '        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
    '        objCaja.entidadFinanciera = i.IdEntidadFinanciera
    '        objCaja.NombreEntidad = i.NomCajaOrigen
    '        objCaja.usuarioModificacion = usuario.IDUsuario
    '        objCaja.fechaModificacion = DateTime.Now
    '        nDocumentoCaja.documentoCaja = objCaja
    '        nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja)
    '        asientoDocumento(nDocumentoCaja.documentoCaja)
    '        ListaDoc.Add(nDocumentoCaja)
    '    Next

    '    Return ListaDoc
    'End Function

    'Private Function GetDetallePago(objCaja As documentoCaja) As List(Of documentoCajaDetalle)
    '    Dim montoPago = objCaja.montoSoles
    '    GetDetallePago = New List(Of documentoCajaDetalle)
    '    For Each i In dgvCompra.Table.Records
    '        If montoPago > 0 Then
    '            If CDec(i.GetValue("MontoSaldo")) > 0 Then
    '                Dim ImporteDisponible = CDec(i.GetValue("MontoSaldo"))
    '                Dim ImportetDisponibleRow As Decimal = i.GetValue("MontoSaldo")

    '                Dim calculoCelda = ImporteDisponible - montoPago
    '                If calculoCelda <= 0 Then
    '                    i.SetValue("MontoSaldo", 0)
    '                    i.SetValue("MontoPago", ImporteDisponible)
    '                Else
    '                    i.SetValue("MontoSaldo", calculoCelda)
    '                    If ImporteDisponible > montoPago Then
    '                        Dim canUso = montoPago
    '                        i.SetValue("MontoPago", canUso)
    '                    Else
    '                        Dim canUso = ImporteDisponible
    '                        i.SetValue("MontoPago", canUso)
    '                    End If
    '                End If
    '                montoPago -= ImporteDisponible

    '                GetDetallePago.Add(New documentoCajaDetalle With
    '                               {
    '                               .fecha = Date.Now,
    '                               .idItem = CInt(i.GetValue("idProducto")),
    '                               .DetalleItem = i.GetValue("item"),
    '                               .montoSoles = FormatNumber(Decimal.Parse(i.GetValue("MontoPago")), 2),
    '                               .montoUsd = FormatNumber(Decimal.Parse(i.GetValue("MontoPago") / TmpTipoCambio), 2),
    '                               .diferTipoCambio = TmpTipoCambio,
    '                               .tipoCambioTransacc = TmpTipoCambio,
    '                               .entregado = "SI",
    '                               .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
    '                               .usuarioModificacion = usuario.IDUsuario,
    '                               .documentoAfectado = CInt(Me.Tag),
    '                               .fechaModificacion = DateTime.Now
    '                               })
    '            End If
    '        End If
    '    Next
    'End Function

    Private Function GetDetallePago(objCaja As documentoCaja, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documentoCajaDetalle)
        Dim montoPago = objCaja.montoSoles
        GetDetallePago = New List(Of documentoCajaDetalle)
        For Each i In ventaDetalle
            If montoPago > 0 Then
                If i.MontoSaldo > 0 Then
                    If i.MontoSaldo > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemPendiente
                    ElseIf i.MontoSaldo = montoPago Then
                        i.MontoPago = montoPago
                        i.estadoPago = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldo
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible

                    GetDetallePago.Add(New documentoCajaDetalle With
                                   {
                                   .fecha = Date.Now,
                                   .idItem = i.idItem,
                                   .DetalleItem = i.nombreItem,
                                   .montoSoles = i.MontoPago,
                                   .montoUsd = FormatNumber(i.MontoPago / TmpTipoCambio, 2),
                                   .diferTipoCambio = TmpTipoCambio,
                                   .tipoCambioTransacc = TmpTipoCambio,
                                   .entregado = "SI",
                                   .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
                                   .usuarioModificacion = usuario.IDUsuario,
                                   .documentoAfectado = CInt(Me.Tag),
                                   .documentoAfectadodetalle = i.secuencia,
                                   .EstadoCobro = i.estadoPago,
                                   .fechaModificacion = DateTime.Now
                                   })
                    i.estadoPago = i.estadoPago
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
    End Function

    Function ListaDocumentoCaja() As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        nDocumentoCaja = New documento
        'DOCUMENTO
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = GConfiguracion.TipoComprobante ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = GConfiguracion.Serie
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = 1
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = txtruc.Text
        Else
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = 0
            nDocumentoCaja.idEntidad = Val(0)
        End If
        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        'DOCUMENTO CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = lblPerido.Text
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
        End If
        objCaja.TipoDocumentoPago = GConfiguracion.TipoComprobante 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.tipoDocPago = cboTipoDoc.SelectedValue
        objCaja.formapago = "EF"
        objCaja.NumeroDocumento = "-"
        objCaja.numeroOperacion = "-"
        objCaja.movimientoCaja = TIPO_VENTA.VENTA_POS_DIRECTA
        objCaja.montoSoles = Decimal.Parse(txtTotalPagar.DecimalValue)

        objCaja.moneda = 1
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles * TmpTipoCambio)

        objCaja.estado = "P"
        objCaja.glosa = "Por ventas POS directa"
        objCaja.entregado = "SI"

        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        objCaja.usuarioModificacion = usuario.IDUsuario
        'objCaja.entidadFinanciera = cbocajaPago.SelectedValue
        'objCaja.NombreEntidad = cbocajaPago.Text
        objCaja.fechaModificacion = DateTime.Now

        nDocumentoCaja.documentoCaja = objCaja
        ListaDoc.Add(nDocumentoCaja)
        ListaDetalleCaja(nDocumentoCaja.documentoCaja)
        asientoDocumento(nDocumentoCaja.documentoCaja)

        Return ListaDoc
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nAsiento.idEntidad = Integer.Parse(TXTcOMPRADOR.Tag)
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        Else
            nAsiento.idEntidad = Integer.Parse(0)
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Sub asientoDocumento(doc As documentoCaja)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros


        ef = efSA.GetUbicar_estadosFinancierosPorID(doc.entidadFinanciera)

        asiento = AsientoTransito(doc.montoSoles, doc.montoUsd)

        ListaAsientonTransito.Add(asiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = TXTcOMPRADOR.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

    End Sub

    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As Record In dgvCompra.Table.Records

            obj = New documentoCajaDetalle
            obj.fecha = Date.Now
            obj.idItem = CInt(i.GetValue("idProducto"))
            obj.DetalleItem = i.GetValue("item")
            obj.montoSoles = FormatNumber(Decimal.Parse(i.GetValue("totalmn")), 2)
            obj.montoUsd = FormatNumber(Decimal.Parse(i.GetValue("totalme")), 2) '
            obj.diferTipoCambio = TmpTipoCambio
            obj.tipoCambioTransacc = TmpTipoCambio
            obj.entregado = "SI"
            obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            obj.usuarioModificacion = usuario.IDUsuario
            obj.documentoAfectado = CInt(Me.Tag)
            obj.fechaModificacion = DateTime.Now
            lista.Add(obj)
        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION

        Dim idCliente As Integer = 0
        Dim nomCliente As String = Nothing

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            idCliente = TXTcOMPRADOR.Tag
            nomCliente = TXTcOMPRADOR.Text
        Else
            nomCliente = TXTcOMPRADOR.Text
        End If

        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = idCliente
            .monedaDoc = "1"
            .tasaIgv = 0 'txtIva.DoubleValue
            .tipoCambio = 1 ' txtTipoCambio.DecimalValue
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .estado = TipoGuia.Entregado
            .direccionPartida = "ORIGEN"
            .fechaTraslado = Date.Now
            .estado = TipoGuia.Entregado
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("tipoExistencia") <> "GS" Then
                documentoguiaDetalle = New documentoguiaDetalle
                objDocumentoCompra.documentoGuia.serie = GConfiguracion.Serie
                objDocumentoCompra.documentoGuia.numeroDoc = GConfiguracion.Serie
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.GetValue("idProducto")
                documentoguiaDetalle.descripcionItem = r.GetValue("item")
                documentoguiaDetalle.destino = r.GetValue("gravado")
                documentoguiaDetalle.unidadMedida = r.GetValue("um")
                documentoguiaDetalle.cantidad = CDec(r.GetValue("cantEntregar"))

                documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                documentoguiaDetalle.nombreRecepcion = nomCliente
                documentoguiaDetalle.dniRecepcion = Nothing
                documentoguiaDetalle.puntoLlegada = "ORIGEN"
                documentoguiaDetalle.estado = TipoGuiaDetalle.Entrega_Total
                documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub ConfiguracionInicio()
        'Me.WindowState = FormWindowState.Maximized
        TotalesXcanbeceras = New TotalesXcanbecera()

        'confgiurando variables generales
        cboTipoDoc.Enabled = True
        'cbocajaPago.Enabled = True
        '  cbotipoDocPago.Enabled = True
        txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text
        txtFecha.Value = DateTime.Now
        txtFecha.Select()
    End Sub

    ''' <summary>
    ''' Calculando totas las filas de la venta
    ''' </summary>
    Function GetDetalleVenta_Calculo(item As totalesAlmacen, cantventa As Decimal?, pumn As Decimal, pume As Decimal,
                                     puKardex As Decimal, puKardexme As Decimal) As DetalleVentageneral
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0


        colcantidad = item.cantidad
        cantidadDisponible = 0
        colPrecUnitAlmacen = puKardex ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
        colPrecUnitUSAlmacen = puKardexme ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
        colPrecUnit = pumn ' Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
        colPrecUnitme = pume ' Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
        colDestinoGravado = item.origenRecaudo

        colCostoMN = colcantidad * colPrecUnitAlmacen
        colCostoME = colcantidad * colPrecUnitUSAlmacen

        totalMN = colcantidad * colPrecUnit
        totalME = colcantidad * colPrecUnitme

        If colDestinoGravado = 1 Then
            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
        Else
            valPercepMN = 0
            valPercepME = 0

        End If

        '****************************************************************
        Dim iva As Decimal = TmpIGV / 100

        If colcantidad > 0 Then

            colBI = (totalMN / (iva + 1))
            colBIme = (totalME / (iva + 1))

            Dim iv As Decimal = 0
            Dim iv2 As Decimal = 0
            iv = totalMN / (iva + 1)
            iv2 = totalME / (iva + 1)

            Igv = iv * (iva)
            IgvME = iv2 * (iva)

            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

        Else
            colBI = 0
            colBIme = 0
            Igv = 0
            IgvME = 0
        End If
        GetDetalleVenta_Calculo = New DetalleVentageneral
        Select Case colDestinoGravado
            Case 1

                GetDetalleVenta_Calculo.valorVentaMN = Math.Round(colBI, 2)
                GetDetalleVenta_Calculo.valorVentaME = Math.Round(colBIme, 2)
                GetDetalleVenta_Calculo.precioUnitMN = colPrecUnit
                GetDetalleVenta_Calculo.precioUnitME = colPrecUnitme
                GetDetalleVenta_Calculo.TotalVentaMN = Math.Round(totalMN, 2)
                GetDetalleVenta_Calculo.TotalVentaME = Math.Round(totalME, 2)
                GetDetalleVenta_Calculo.IgvMN = Math.Round(Igv, 2)
                GetDetalleVenta_Calculo.IgvME = Math.Round(IgvME, 2)
                GetDetalleVenta_Calculo.CostoMN = colCostoMN
                GetDetalleVenta_Calculo.CostoME = colCostoME

            Case 2

                GetDetalleVenta_Calculo.valorVentaMN = Math.Round(totalMN, 2)
                GetDetalleVenta_Calculo.valorVentaME = Math.Round(totalME, 2)
                GetDetalleVenta_Calculo.precioUnitMN = colPrecUnit
                GetDetalleVenta_Calculo.precioUnitME = colPrecUnitme
                GetDetalleVenta_Calculo.TotalVentaMN = Math.Round(totalMN, 2)
                GetDetalleVenta_Calculo.TotalVentaME = Math.Round(totalME, 2)
                GetDetalleVenta_Calculo.IgvMN = 0
                GetDetalleVenta_Calculo.IgvME = 0
                GetDetalleVenta_Calculo.CostoMN = colCostoMN
                GetDetalleVenta_Calculo.CostoME = colCostoME
        End Select
        ' TotalTalesXcolumna()
    End Function

    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        setDataSource(lista)
    End Sub

    'Private Sub ThreadNumeracion()
    '    Dim strIdModulo As String = Nothing
    '    If cboTipoDoc.Text = "BOLETA" Then
    '        strIdModulo = "VT2"
    '    ElseIf cboTipoDoc.Text = "FACTURA" Then
    '        strIdModulo = "VT3"
    '    End If

    '    Dim strIDEmpresa = Gempresas.IdEmpresaRuc
    '    ProgressBar2.Visible = True
    '    ProgressBar2.Style = ProgressBarStyle.Marquee
    '    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetNumeracion(strIdModulo, strIDEmpresa)))
    '    thread.Start()
    'End Sub

    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub
    'Dim conf As New GConfiguracionModulo
    'Private v As Object

    'Private Sub SetDataSourceNumeracion(ByVal moduloConfiguracion As moduloConfiguracion)
    '    If Me.InvokeRequired Then
    '        'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

    '        Dim deleg As New SetDataSourceDelegateNumeracion(AddressOf SetDataSourceNumeracion)
    '        Invoke(deleg, New Object() {moduloConfiguracion})
    '    Else
    '        conf = New GConfiguracionModulo
    '        conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '        ProgressBar2.Visible = False
    '    End If
    '    'txtSerie.Text = conf.Serie
    'End Sub

    'Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        If cboTipoDoc.Text = "BOLETA" Then
    '                            GConfiguracion2.TipoComprobante = "12.1" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If
    '                        If cboTipoDoc.Text = "FACTURA" Then
    '                            GConfiguracion2.TipoComprobante = "12.2" '.tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If

    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        TiempoEjecutar(5)
    '    End If
    '    Return GConfiguracion2
    'End Function

    Public Function configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer) As GConfiguracionModulo
        Try
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)

                If cboTipoDoc.Text = "BOLETA" Then
                    GConfiguracion.TipoComprobante = "12.1" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If
                If cboTipoDoc.Text = "FACTURA" Then
                    GConfiguracion.TipoComprobante = "12.2" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return GConfiguracion
    End Function

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
            ProgressBar1.Visible = False
        End If
    End Sub

    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal

        Public Property BaseMN2() As Decimal
        Public Property BaseME2() As Decimal

        Public Property BaseMN3() As Decimal
        Public Property BaseME3() As Decimal

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

        Public Property PercepcionMN() As Decimal
        Public Property PercepcionME() As Decimal

        Public Sub New()
            BaseMN = 0
            BaseME = 0
            BaseMN2 = 0
            BaseME2 = 0
            BaseMN3 = 0
            BaseME3 = 0
            IgvMN = 0
            IgvME = 0
            TotalMN = 0
            TotalME = 0
            base1 = 0
            base1me = 0
            base2 = 0
            base2me = 0
            MontoIgv1 = 0
            MontoIgv1me = 0
            MontoIgv2 = 0
            MontoIgv2me = 0
            PercepcionMN = 0
            PercepcionME = 0
        End Sub


    End Class

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idProducto", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("um", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("vcmn", GetType(Decimal))
        dt.Columns.Add("pcmn", GetType(Decimal))
        dt.Columns.Add("totalmn", GetType(Decimal))
        dt.Columns.Add("vcme", GetType(Decimal))
        dt.Columns.Add("pcme", GetType(Decimal))
        dt.Columns.Add("totalme", GetType(Decimal))
        dt.Columns.Add("igvmn", GetType(Decimal))
        dt.Columns.Add("igvme", GetType(Decimal))

        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("marca", GetType(String))
        dt.Columns.Add("almacen", GetType(String))
        dt.Columns.Add("caja", GetType(String))

        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("chPago", GetType(Boolean))
        dt.Columns.Add("valPago", GetType(String))

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))
        dt.Columns.Add("presentacion", GetType(String))

        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("puKardex", GetType(Decimal))
        dt.Columns.Add("pukardeme", GetType(Decimal))
        dt.Columns.Add("canDisponible", GetType(Decimal))
        dt.Columns.Add("costoMN", GetType(Decimal))
        dt.Columns.Add("costoME", GetType(Decimal))
        dt.Columns.Add("tipoPrecio", GetType(String))
        dt.Columns.Add("cat", GetType(Integer))
        dt.Columns.Add("codBarra", GetType(String))
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("cboprecio", GetType(String))
        dt.Columns.Add("codigoLote")
        dt.Columns.Add("MontoPago")
        dt.Columns.Add("MontoSaldo")
        dt.Columns.Add("tipoventa")
        dgvCompra.DataSource = dt
    End Sub

    Public Sub GetCombos()
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA

        ListaAlmacenes = New List(Of almacen)
        ListaEstadosFinancieros = New List(Of estadosFinancieros)
        '    ListaTipoExistencia = New List(Of tabladetalle)
        'ListaComprobantesCaja = New List(Of tabladetalle)

        '  ListaTipoExistencia = tablaDetalleSA.GetListaTablaDetalle(5, "1")

        ListaAlmacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        '  ListaComprobantesCaja = tablaDetalleSA.GetListaTablaDetalle(10, "1")
        ListaEstadosFinancieros = cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
    End Sub

    Public Sub Loadcontroles()


        'cboalmacen.ValueMember = "idAlmacen"
        'cboalmacen.DisplayMember = "descripcionAlmacen"
        'cboalmacen.DataSource = ListaAlmacenes 'almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)

        'cbotipoDocPago.DataSource = ListaComprobantesCaja 'tablaDetalleSA.GetListaTablaDetalle(10, "1")
        'cbotipoDocPago.ValueMember = "codigoDetalle"
        'cbotipoDocPago.DisplayMember = "descripcion"

        'cbocajaPago.DataSource = ListaEstadosFinancieros ' cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
        'cbocajaPago.ValueMember = "idestado"
        'cbocajaPago.DisplayMember = "descripcion"

    End Sub


    Private Sub CalcularArticulosDisponibles(cantidadVenta As Decimal, precio As configuracionPrecioProducto, item As totalesAlmacen)
        For Each r As Record In dgCanastaSel.Table.Records
            If cantidadVenta > 0 Then
                Dim cantidadDisponible = CDec(r.GetValue("cantidad"))
                Dim cantDisponibleRow As Decimal = CDec(r.GetValue("cantidad"))
                If cantidadDisponible > 0 Then
                    Dim calculoCelda = cantidadDisponible - cantidadVenta
                    If calculoCelda <= 0 Then
                        r.SetValue("cantDisponible", 0)
                        r.SetValue("cantUso", cantidadDisponible)
                        item.cantidad = cantidadDisponible
                    Else
                        r.SetValue("cantDisponible", calculoCelda)
                        If cantidadDisponible > cantidadVenta Then
                            Dim canUso = cantidadVenta
                            r.SetValue("cantUso", canUso)
                            item.cantidad = canUso
                        Else
                            Dim canUso = cantidadDisponible
                            r.SetValue("cantUso", canUso)
                            item.cantidad = canUso
                        End If


                    End If
                End If
                cantidadVenta -= cantidadDisponible

                AgregarAcanastaCodigoBarra_Index(precio, item, cantDisponibleRow)
            End If
        Next r
    End Sub

    Public Sub AgregarAcanastaCodigoBarra_Index(precio As configuracionPrecioProducto, item As totalesAlmacen, cantidadDisponible As Decimal)
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        valPUmn = precio.precioMN
        valPUme = precio.precioME

        Dim valPUKardexMN = CDec(item.importeSoles) / CDec(item.cantidad)
        Dim valPUKardexME = CDec(item.importeDolares) / CDec(item.cantidad)

        Dim calculoDetalle = GetDetalleVenta_Calculo(item, item.cantidad, valPUmn, valPUme, valPUKardexMN, valPUKardexME)


        With productoSA.InvocarProductoID(item.idItem)
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", .descripcionItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", .unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", item.cantidad)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", cantidadDisponible)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", calculoDetalle.valorVentaMN.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", calculoDetalle.TotalVentaMN.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", calculoDetalle.TotalVentaMN.GetValueOrDefault)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", calculoDetalle.valorVentaME.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", calculoDetalle.TotalVentaME.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", calculoDetalle.IgvMN.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", calculoDetalle.IgvME.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", CDec(item.importeSoles) / CDec(item.cantidad))
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", CDec(item.importeDolares) / CDec(item.cantidad))

            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", item.idAlmacen)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", item.NomAlmacen)

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", calculoDetalle.CostoMN.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", calculoDetalle.CostoME.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", precio.idPrecio)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

            Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)
            Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", item.idEmpresa)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigoLote", item.CustomLote.codigoLote)
            dgvCompra.Table.CurrentRecord.SetValue("tipoventa", "V")
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With
        'txtBarCode.Select()
        'txtBarCode.SelectAll()


    End Sub

    Sub TotalTalesXcolumna()
        Dim totalpercepMN As Decimal = 0
        Dim totalpercepME As Decimal = 0

        'VC01
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        'VC02
        Dim totalVC2 As Decimal = 0
        Dim totalVCme2 As Decimal = 0

        'VC03
        Dim totalVC3 As Decimal = 0
        Dim totalVCme3 As Decimal = 0

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

        For Each r As Record In dgvCompra.Table.Records
            totalpercepMN += CDec(r.GetValue("percepcionMN"))
            totalpercepME += CDec(r.GetValue("percepcionME"))

            'If r.GetValue("valBonif") = "S" Then
            '    totalDesc += CDec(r.GetValue("igvmn"))
            '    totalDescme += CDec(r.GetValue("igvme"))
            'Else

            Select Case r.GetValue("gravado")
                Case OperacionGravada.Grabado
                    totalVC += CDec(r.GetValue("vcmn"))
                    totalVCme += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Exonerado
                    totalVC2 += CDec(r.GetValue("vcmn"))
                    totalVCme2 += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Inafecto
                    totalVC3 += CDec(r.GetValue("vcmn"))
                    totalVCme3 += CDec(r.GetValue("vcme"))
            End Select



            totalIVA += CDec(r.GetValue("igvmn"))
            totalIVAme += CDec(r.GetValue("igvme"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))
            'End If

            Select Case r.GetValue("gravado")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    igv1 += CDec(r.GetValue("igvmn"))
                    igv1me += CDec(r.GetValue("igvme"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    igv2 += CDec(r.GetValue("igvmn"))
                    igv2me += CDec(r.GetValue("igvme"))
            End Select




        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.PercepcionMN = totalpercepMN
        TotalesXcanbeceras.PercepcionME = totalpercepME

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.BaseMN2 = totalVC2
        TotalesXcanbeceras.BaseME2 = totalVCme2

        TotalesXcanbeceras.BaseMN3 = totalVC3
        TotalesXcanbeceras.BaseME3 = totalVCme3

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

        '****************************************************
        'If cboMoneda.SelectedValue = 1 Then
        txtTotalBase3.DecimalValue = totalVC3
        txtTotalBase2.DecimalValue = totalVC2
        txtTotalBase.DecimalValue = totalVC
        txtTotalIva.Text = ((totalIVA))
        'Label4.Text = Decimal.Round(totalIVA)
        'Button1.Text = (CDec(totalIVA))
        txtTotalPagar.DecimalValue = total
        lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        'Else
        '    txtTotalBase3.DecimalValue = totalVCme3
        '    txtTotalBase2.DecimalValue = totalVCme2
        '    txtTotalBase.DecimalValue = totalVCme
        '    txtTotalIva.DecimalValue = totalIVAme
        '    txtTotalPagar.DecimalValue = totalme
        '    lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        'End If


    End Sub

    Sub Calculos()
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
            Select Case strTipoExistencia
                Case "GS"
                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                    colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                    totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
                    totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        Dim iva As Decimal = TmpIGV / 100
                        colBI = (totalMN / (iva + 1))
                        colBIme = (totalME / (iva + 1))

                        Dim iv As Decimal = 0
                        Dim iv2 As Decimal = 0
                        iv = totalMN / (iva + 1)
                        iv2 = totalME / (iva + 1)

                        Igv = iv * (iva)
                        IgvME = iv2 * (iva)
                    Else

                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0

                    End If

                    '****************************************************************

                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then



                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    Else

                    End If

                    Select Case colDestinoGravado
                        Case 1
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                Case Else
                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                        colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                        colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                        colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                        colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                        colCostoMN = colcantidad * colPrecUnitAlmacen
                        colCostoME = colcantidad * colPrecUnitUSAlmacen

                        totalMN = colcantidad * colPrecUnit
                        totalME = colcantidad * colPrecUnitme

                        If colDestinoGravado = 1 Then
                            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                        Else
                            valPercepMN = 0
                            valPercepME = 0

                        End If

                        '****************************************************************
                        Dim iva As Decimal = TmpIGV / 100

                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                        If colcantidad > 0 Then

                            colBI = (totalMN / (iva + 1))
                            colBIme = (totalME / (iva + 1))

                            Dim iv As Decimal = 0
                            Dim iv2 As Decimal = 0
                            iv = totalMN / (iva + 1)
                            iv2 = totalME / (iva + 1)

                            Igv = iv * (iva)
                            IgvME = iv2 * (iva)

                            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If

                        Select Case colDestinoGravado
                            Case 1
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            Case 2
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        End Select
                        TotalTalesXcolumna()
                    Else
                        dgvCompra.Table.CurrentRecord.EndEdit()
                        lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        txtTotalBase.Text = 0.0
                        txtTotalBase2.Text = 0.0
                        txtTotalIva.Text = 0.0
                        lblTotalPercepcion.Text = 0.0
                        txtTotalPagar.Text = 0.0
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
            End Select
        End If
    End Sub

    Sub CalculosByCantidad(cant As Decimal)
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
            Select Case strTipoExistencia
                Case "GS"
                    colcantidad = 1 ' Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                    colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                    totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
                    totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        Dim iva As Decimal = TmpIGV / 100
                        colBI = (totalMN / (iva + 1))
                        colBIme = (totalME / (iva + 1))

                        Dim iv As Decimal = 0
                        Dim iv2 As Decimal = 0
                        iv = totalMN / (iva + 1)
                        iv2 = totalME / (iva + 1)

                        Igv = iv * (iva)
                        IgvME = iv2 * (iva)
                    Else

                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0

                    End If

                    '****************************************************************

                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then



                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    Else

                    End If

                    Select Case colDestinoGravado
                        Case 1
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                Case Else
                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                        colcantidad = cant 'Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                        colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                        colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                        colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                        colCostoMN = colcantidad * colPrecUnitAlmacen
                        colCostoME = colcantidad * colPrecUnitUSAlmacen

                        totalMN = colcantidad * colPrecUnit
                        totalME = colcantidad * colPrecUnitme

                        If colDestinoGravado = 1 Then
                            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                        Else
                            valPercepMN = 0
                            valPercepME = 0

                        End If

                        '****************************************************************
                        Dim iva As Decimal = TmpIGV / 100

                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                        If colcantidad > 0 Then

                            colBI = (totalMN / (iva + 1))
                            colBIme = (totalME / (iva + 1))

                            Dim iv As Decimal = 0
                            Dim iv2 As Decimal = 0
                            iv = totalMN / (iva + 1)
                            iv2 = totalME / (iva + 1)

                            Igv = iv * (iva)
                            IgvME = iv2 * (iva)

                            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If

                        Select Case colDestinoGravado
                            Case 1
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            Case 2
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        End Select
                        TotalTalesXcolumna()
                    Else
                        dgvCompra.Table.CurrentRecord.EndEdit()
                        lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        txtTotalBase.Text = 0.0
                        txtTotalBase2.Text = 0.0
                        txtTotalIva.Text = 0.0
                        lblTotalPercepcion.Text = 0.0
                        txtTotalPagar.Text = 0.0
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
            End Select
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        dgvCompra.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = dgvCompra.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu

        Else
            dgvCompra.ContextMenuStrip = ContextMenuStrip
            'If it is not column header cell
            'dgvCompra.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Cursor = Cursors.WaitCursor
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim nuevoprecio As New configuracionPrecioProducto
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then

            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 1
                    If e.ClickedItem.Text = "Agregar nuevo precio" Then
                        Dim f As New frmNuevoPrecio
                        f.txtProducto.Tag = dgvCompra.Table.CurrentRecord.GetValue("idProducto")
                        f.txtProducto.Text = dgvCompra.Table.CurrentRecord.GetValue("item")
                        f.txtGrav.Text = dgvCompra.Table.CurrentRecord.GetValue("gravado")
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()

                        nuevoprecio = precioSA.GetPreciosproductoMaxFecha(Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("idProducto")), Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("cboprecio")))

                        If Not IsNothing(nuevoprecio) Then
                            dgvCompra.Table.CurrentRecord.SetValue("pumn", nuevoprecio.precioMN)
                            dgvCompra.Table.CurrentRecord.SetValue("pume", nuevoprecio.precioME)
                            Calculos()

                        Else
                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                            dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                            Calculos()
                        End If
                    ElseIf e.ClickedItem.Text = "Ver tabla de precios" Then
                        Dim f As New frmPreciosByArticulos(New detalleitems With {.codigodetalle = dgvCompra.Table.CurrentRecord.GetValue("idProducto"),
                                                           .descripcionItem = dgvCompra.Table.CurrentRecord.GetValue("item")})
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                    End If

                Case Else
                    MessageBox.Show("No tiene derechos de administrador, para realizar está tarea", "No autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select

        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub CargarPrecios()
        Dim precioSA As New ConfiguracionPrecioSA
        Dim precio As New List(Of configuracionPrecio)
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("cboprecio").Appearance.AnyRecordFieldCell

        precio.AddRange(precioSA.ListadoPrecios())
        'precio.Add(New configuracionPrecio With {.idPrecio = 0, .precio = "-Ver tabla de precios-"})

        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = precio ' precioSA.ListadoPrecios()
        ggcStyle.ValueMember = "idPrecio"
        ggcStyle.DisplayMember = "precio"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    'Sub ConteoLabelVentas()
    '    lblConteo.Text = "Artículos en Canasta: " & dgvCompra.Table.Records.Count
    'End Sub

    'Public Sub GetExistenciaByCodigoBar(CodigoBarra As String)
    '    Dim totalSA As New TotalesAlmacenSA
    '    Dim stockTotal As Decimal? = 0
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    dgCanastaSel.Table.Records.DeleteAll()
    '    Dim lista = totalSA.GetProductosByAlmacenCodigo(cboalmacen.SelectedValue, CodigoBarra)
    '    GetListaProductosEmpresaByCodigoBarra(lista)
    '    stockTotal = Aggregate n In lista
    '                         Into Sum(n.cantidad)

    '    txtStockDisponible.Text = stockTotal.GetValueOrDefault

    '    If dgCanastaSel.Table.Records.Count > 0 Then

    '        Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, lista(0).idItem)
    '        If listaPrecios.Count > 0 Then

    '            LimpiarProductosIguales(lista(0).idItem)

    '            'Dim cantidad = InputBox("Ingrese cantidad a vender", "Stock disponible: " & MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad", e.RowIndex), "")
    '            Dim cantidad = InputBox("Ingrese cantidad a vender", lista(0).descripcion, "1")
    '            If IsNumeric(cantidad) Then
    '                If cantidad <= 0 Then
    '                    MessageBox.Show("La cantidad ingresada debe ser mayor a cero!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Exit Sub
    '                    Cursor = Cursors.Default
    '                End If

    '                If (CDec(cantidad) > stockTotal) Then
    '                    MessageBox.Show("La cantidad ingresada no debe exceder la disponible!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Exit Sub
    '                    Cursor = Cursors.Default
    '                End If

    '                'ValidarStockDisponible(Integer.Parse(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", e.RowIndex)),
    '                '                      Integer.Parse(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idalmacen", e.RowIndex)),
    '                '                       cantidad)
    '                CalcularArticulosDisponibles(Decimal.Parse(cantidad), listaPrecios(0), lista(0))
    '                TotalTalesXcolumna()
    '                ConteoLabelVentas()
    '                txtStockDisponible.Clear()
    '                txtCodigoBarra.Clear()
    '                txtCodigoBarra.Select()
    '                txtCodigoBarra.Focus()
    '                txtCodigoBarra.SelectAll()
    '            Else
    '                MessageBox.Show("Ingrese una cantidad válida!", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Return
    '            End If
    '        Else
    '            MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '    End If

    'End Sub

    Private Sub LimpiarProductosIguales(idItem As Integer)
        For Each r As Record In dgvCompra.Table.Records
            If Integer.Parse(r.GetValue("idProducto")) = idItem Then
                r.Delete()
            End If
        Next
    End Sub

    Private Sub GetListaProductosEmpresaByCodigoBarra(lista As List(Of totalesAlmacen))
        Dim CanastaSA As New TotalesAlmacenSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))
            dt.Columns.Add("cantDisponible", GetType(Decimal))
            dt.Columns.Add("cantUso", GetType(Decimal))

            For Each i As totalesAlmacen In lista
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.idEmpresa
                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares
                    dr(12) = i.idAlmacen
                    dr(13) = i.NomAlmacen
                    dr(14) = 0
                    dr(15) = 0
                    dt.Rows.Add(dr)
                End If
            Next
            dgCanastaSel.DataSource = dt
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "Events"
    

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTcOMPRADOR.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaClientes
                            Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList


            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub lsvProveedor_MouseDown(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub TXTcOMPRADOR_TextChanged(sender As Object, e As EventArgs) Handles TXTcOMPRADOR.TextChanged
        TXTcOMPRADOR.ForeColor = Color.Black
        TXTcOMPRADOR.Tag = Nothing
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
            If dgvCompra.Table.Records.Count > 0 Then
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
            End If
            ' ConteoLabelVentas()
        End If
    End Sub

    Private Sub frmVentaNuevoFormato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelProductosSel.Visible = False
        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        CargarPrecios()
        'lblConteo.Visible = True

        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Agregar nuevo precio")
        ContextMenuStrip.Items.Add("Ver tabla de precios")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler dgvCompra.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chPago" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chBonif" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        'e.Style.BackColor = Color.Yellow
                        'e.Style.TextColor = Color.Black
                        e.Style.[ReadOnly] = True
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "totalmn")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "item")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                'Dim cantidadActual = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 7).CellValue
                'Dim cantidadDisponible = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 25).CellValue

                'If cantidadActual > cantidadDisponible Then
                '    e.Style.CellValue = 0
                'End If

                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                End Select


            End If


        End If

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

            Select Case ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If

            End Select
        End If

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"
                    Dim r As Record = dgvCompra.Table.CurrentRecord

                    If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

                    Else
                        cc.ConfirmChanges()
                        cc.EndEdit()

                    End If
                    Calculos()

                    'End Select
                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Calculos()
            End Select
        End If

    End Sub

    Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"
                    Dim r As Record = dgvCompra.Table.CurrentRecord

                    If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

                    Else
                        cc.ConfirmChanges()
                        cc.EndEdit()

                    End If
                    Calculos()

                    'End Select
                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Calculos()
            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlKeyPress
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"
                    Dim r As Record = dgvCompra.Table.CurrentRecord

                    If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

                    Else
                        cc.ConfirmChanges()
                        cc.EndEdit()

                    End If
                    Calculos()

                    'End Select
                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Calculos()
            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlLeftColChanged(sender As Object, e As GridTableControlRowColIndexChangedEventArgs) Handles dgvCompra.TableControlLeftColChanged

    End Sub

    Private Sub dgvCompra_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyUp
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"
                    Dim r As Record = dgvCompra.Table.CurrentRecord

                    If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

                    Else
                        cc.ConfirmChanges()
                        cc.EndEdit()

                    End If
                    Calculos()

                    'End Select
                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Calculos()
            End Select
        End If
    End Sub

    Private Sub gradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles gradientPanel2.Paint

    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            ProgressBar2.Visible = True
            ProgressBar2.Style = ProgressBarStyle.Marquee
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim strIdModulo As String = Nothing
        If cboTipoDoc.Text = "BOLETA" Then
            strIdModulo = "VT2"
        ElseIf cboTipoDoc.Text = "FACTURA" Then
            strIdModulo = "VT3"
        End If
        Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        txtSerie.Text = GConfiguracion.Serie
        ProgressBar2.Visible = False
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            listaClientes.Add(c)
            TXTcOMPRADOR.Text = c.nombreCompleto
            txtruc.Text = c.nrodoc
            TXTcOMPRADOR.Tag = c.idEntidad
            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtruc.Visible = True
            TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub TXTcOMPRADOR_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TXTcOMPRADOR.MouseDoubleClick
        TXTcOMPRADOR.SelectAll()
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If ValidarGrabado() = True Then
                Grabar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bgCombos_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgCombos.DoWork
        GetCombos()
    End Sub

    Private Sub bgCombos_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgCombos.RunWorkerCompleted
        Loadcontroles()
    End Sub

    'Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
    '    frmCanastaInventary = New frminfoInventario(cboalmacen.SelectedValue)
    '    frmCanastaInventary.StartPosition = FormStartPosition.CenterScreen
    '    frmCanastaInventary.Show(Me)
    'End Sub

    Private Sub bgVenta_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgVenta.DoWork
        GetDocumentoVentaID(Integer.Parse(Tag))
    End Sub

    Private Sub bgVenta_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgVenta.RunWorkerCompleted
        GetDocumentoVentaIDDone()
    End Sub

  

    'Private Sub ChPagoAvanzado_OnChange(sender As Object, e As EventArgs) Handles ChPagoAvanzado.OnChange
    '    If ChPagoAvanzado.Checked = True Then
    '        ChPagoDirecto.Checked = False
    '        cbocajaPago.Visible = False
    '    Else
    '        '       cbocajaPago.Visible = True
    '    End If
    '    If ChPagoAvanzado.Checked = False AndAlso ChPagoDirecto.Checked = False Then
    '        LblPagoCredito.Visible = True
    '    Else
    '        LblPagoCredito.Visible = False
    '    End If
    'End Sub

    'Private Sub ChPagoQuestion_OnChange(sender As Object, e As EventArgs) Handles ChPagoDirecto.OnChange
    '    PagoDirectoCheck()
    'End Sub

    'Private Sub PagoDirectoCheck()
    '    If ChPagoDirecto.Checked Then
    '        cbocajaPago.Visible = True
    '        ' ChPagoAvanzado.Visible = True
    '        ChPagoAvanzado.Checked = False
    '        Label8.Visible = True
    '    Else
    '        cbocajaPago.Visible = False
    '        ''  ChPagoAvanzado.Visible = False
    '        'ChPagoAvanzado.Checked = False
    '        'Label8.Visible = False
    '    End If
    '    If ChPagoAvanzado.Checked = False AndAlso ChPagoDirecto.Checked = False Then
    '        LblPagoCredito.Visible = True
    '    Else
    '        LblPagoCredito.Visible = False
    '    End If
    'End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If LsvProveedor.SelectedItems.Count > 0 Then
                TXTcOMPRADOR.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                TXTcOMPRADOR.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                txtruc.Visible = True
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TXTcOMPRADOR.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub EnviarProducto(productoBE As totalesAlmacen) Implements IForm.EnviarProducto
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0

        valPUmn = productoBE.PMprecioMN
        valPUme = productoBE.PMprecioME

        'With productoSA.InvocarProductoID(r.GetValue("idItem"))


        Dim cantidad = InputBox("Ingrese cantidad a vender", productoBE.descripcion, "")
        If IsNumeric(cantidad) Then
            If cantidad <= 0 Then
                MessageBox.Show("La cantidad ingresada debe ser mayor a cero!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
                Cursor = Cursors.Default
            End If

            If (CDec(cantidad) > productoBE.cantidad) Then
                MessageBox.Show("La cantidad ingresada no debe exceder la disponible!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
                Cursor = Cursors.Default
            End If

            'ValidarStockDisponible(Integer.Parse(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", e.RowIndex)),
            '                      Integer.Parse(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idalmacen", e.RowIndex)),
            '                       cantidad)
            CalculosByCantidad(CDec(cantidad))

            Dim colBI As Decimal = 0
            Dim colBIme As Decimal = 0
            Dim Igv As Decimal = 0
            Dim IgvME As Decimal = 0
            Dim cantidadDisponible = productoBE.cantidad
            Dim colPrecUnitAlmacen = productoBE.importeSoles / productoBE.cantidad
            Dim colPrecUnitUSAlmacen = productoBE.importeDolares / productoBE.cantidad
            Dim colPrecUnit = valPUmn
            Dim colPrecUnitme = valPUme
            Dim colDestinoGravado = productoBE.origenRecaudo

            Dim colCostoMN = cantidad * colPrecUnitAlmacen
            Dim colCostoME = cantidad * colPrecUnitUSAlmacen

            Dim totalMN = cantidad * colPrecUnit
            Dim totalME = cantidad * colPrecUnitme

            Dim iva As Decimal = TmpIGV / 100

            If cantidad > 0 Then

                colBI = (totalMN / (iva + 1))
                colBIme = (totalME / (iva + 1))

                Dim iv As Decimal = 0
                Dim iv2 As Decimal = 0
                iv = totalMN / (iva + 1)
                iv2 = totalME / (iva + 1)

                Igv = iv * (iva)
                IgvME = iv2 * (iva)

                'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

            Else
                colBI = 0
                colBIme = 0
                Igv = 0
                IgvME = 0
            End If

            With dgvCompra.Table
                .AddNewRecord.SetCurrent()
                .AddNewRecord.BeginEdit()
                .CurrentRecord.SetValue("codigo", 0)
                .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
                .CurrentRecord.SetValue("idProducto", productoBE.idItem)
                .CurrentRecord.SetValue("item", productoBE.descripcion)
                .CurrentRecord.SetValue("um", productoBE.idUnidad)
                .CurrentRecord.SetValue("cantidad", cantidad)
                .CurrentRecord.SetValue("canDisponible", productoBE.cantidad)
                .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                .CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))

                .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                .CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                .CurrentRecord.SetValue("marca", Nothing)

                .CurrentRecord.SetValue("pumn", valPUmn)
                .CurrentRecord.SetValue("pume", valPUme)

                .CurrentRecord.SetValue("puKardex", productoBE.importeSoles / productoBE.cantidad)
                .CurrentRecord.SetValue("pukardeme", productoBE.importeDolares / productoBE.cantidad)

                .CurrentRecord.SetValue("chPago", False)
                .CurrentRecord.SetValue("valPago", "No Pagado")

                .CurrentRecord.SetValue("chBonif", False)
                .CurrentRecord.SetValue("valBonif", "N")
                '   If .tipoExistencia <> "GS" Then
                .CurrentRecord.SetValue("almacen", productoBE.idAlmacen)
                .CurrentRecord.SetValue("presentacion", productoBE.NomAlmacen)

                .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                .CurrentRecord.SetValue("costoMN", colCostoMN)
                .CurrentRecord.SetValue("costoME", colCostoME)
                .CurrentRecord.SetValue("tipoPrecio", productoBE.tipoConfiguracion)
                .CurrentRecord.SetValue("cboprecio", Integer.Parse(productoBE.tipoConfiguracion))
                .CurrentRecord.SetValue("cat", 0)
                .CurrentRecord.SetValue("codigoLote", productoBE.codigoLote)
                .CurrentRecord.SetValue("codBarra", productoBE.CodigoBarra)
                .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                .CurrentRecord.SetValue("tipoventa", "V")
                .AddNewRecord.EndEdit()
                .TableDirty = True
            End With
            ' ConteoLabelVentas()
            TotalTalesXcolumna()

            Dim conexos = InventarioSA.ListProductsConexos(New totalesAlmacen With {.idMovimiento = productoBE.idMovimiento})
            If conexos.Count > 0 Then
                If MessageBox.Show("El producto tiene, articulos conexos, desea agregarlos", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    GetproductsConexos(valPUmn, valPUme, conexos)
                End If
            End If
        Else
            MessageBox.Show("Ingrese una cantidad válida!", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
    End Sub

    Private Sub GetproductsConexos(valPUmn As Decimal, valPUme As Decimal, conexos As List(Of totalesAlmacen))
        For Each i In conexos
            With dgvCompra.Table
                .AddNewRecord.SetCurrent()
                .AddNewRecord.BeginEdit()
                .CurrentRecord.SetValue("codigo", 0)
                .CurrentRecord.SetValue("gravado", i.origenRecaudo)
                .CurrentRecord.SetValue("idProducto", i.idItem)
                .CurrentRecord.SetValue("item", i.descripcion)
                .CurrentRecord.SetValue("um", i.idUnidad)
                .CurrentRecord.SetValue("cantidad", 0)
                .CurrentRecord.SetValue("canDisponible", i.cantidad)
                .CurrentRecord.SetValue("vcmn", 0)
                .CurrentRecord.SetValue("totalmn", 0)
                .CurrentRecord.SetValue("MontoSaldo", 0)

                .CurrentRecord.SetValue("vcme", 0)
                .CurrentRecord.SetValue("totalme", 0)
                .CurrentRecord.SetValue("igvmn", 0)
                .CurrentRecord.SetValue("igvme", 0)
                .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                .CurrentRecord.SetValue("marca", Nothing)

                .CurrentRecord.SetValue("pumn", valPUmn)
                .CurrentRecord.SetValue("pume", valPUme)

                .CurrentRecord.SetValue("puKardex", i.importeSoles / i.cantidad)
                .CurrentRecord.SetValue("pukardeme", i.importeDolares / i.cantidad)

                .CurrentRecord.SetValue("chPago", False)
                .CurrentRecord.SetValue("valPago", "No Pagado")

                .CurrentRecord.SetValue("chBonif", False)
                .CurrentRecord.SetValue("valBonif", "N")
                '   If .tipoExistencia <> "GS" Then
                .CurrentRecord.SetValue("almacen", i.idAlmacen)
                .CurrentRecord.SetValue("presentacion", i.NomAlmacen)

                .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                .CurrentRecord.SetValue("costoMN", 0)
                .CurrentRecord.SetValue("costoME", 0)
                .CurrentRecord.SetValue("tipoPrecio", i.tipoConfiguracion)
                .CurrentRecord.SetValue("cboprecio", Integer.Parse(i.tipoConfiguracion))
                .CurrentRecord.SetValue("cat", 0)
                .CurrentRecord.SetValue("codigoLote", i.codigoLote)
                .CurrentRecord.SetValue("codBarra", i.CodigoBarra)
                .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                .AddNewRecord.EndEdit()
                .TableDirty = True
            End With
        Next
    End Sub
#End Region

    
  
   
   

End Class