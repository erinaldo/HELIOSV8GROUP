Imports System.ComponentModel
Imports System.Runtime.Serialization
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class FormVentaNuevoPosV2
    Implements IForm, IListaInventario, IProductoConsignado, IPrecio

#Region "Fields"
    Dim conf As New GConfiguracionModulo
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property listaClientes As New List(Of entidad)
    Public Property entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Friend Delegate Sub SetDataSourceDelegateNumeracion(ByVal numeracion As moduloConfiguracion)
    Public ListaAlmacenes As List(Of almacen)
    Public Alert As Alert
    Public Property documentoVenta As documentoventaAbarrotes
    Public Property documentoVentaDetalle As List(Of documentoventaAbarrotesDet)
    Public Property entidad As entidad
    Public Property frmCanastaInventary As frminfoInventario
    Public Property InventarioSA As New TotalesAlmacenSA
    Private FormInventarioCanastaTotales As FormInventarioCanastaTotales
    Private FormNotaCompraDirecta As FormNotaCompraDirecta
    Property ManipulacionEstado() As String
    Public Property documentoID As Integer
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCompra, False, False)
        frmCanastaInventary = New frminfoInventario
        ConfiguracionInicio()
        CalculoGridCeldas()
        GetTableGrid()
        threadClientes()
        bgCombos.RunWorkerAsync()
        dgvCompra.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(dgvCompra.TableModel))
    End Sub

    Public Sub New(iddocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCompra, False, False)
        frmCanastaInventary = New frminfoInventario
        ConfiguracionInicio()
        CalculoGridCeldas()
        GetTableGrid()
        documentoID = iddocumento
        threadClientes()
        bgCombos.RunWorkerAsync()
        Tag = iddocumento
        bgVenta.RunWorkerAsync()
        dgvCompra.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(dgvCompra.TableModel))
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

#Region "Variables"
    Dim VentaSA As New documentoVentaAbarrotesSA
    Dim ndocumento As New documento()
    Dim nDocumentoVenta As New documentoventaAbarrotes()
    Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
    Dim proveedor As String = Nothing
    Dim idProveedor As Integer

    Dim TipoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
    Dim TipoEntrega = TipoEntregado.PorEntregar
#End Region

#Region "Methods"
    Private Sub CalculoGridCeldas()
        Dim expField0 As ExpressionFieldDescriptor = New ExpressionFieldDescriptor("totalmn", "([cantidad]*[pumn])", GetType(System.Double))
        Dim expField1 As ExpressionFieldDescriptor = New ExpressionFieldDescriptor("totalme", "([cantidad]*[pume])", GetType(System.Double))

        dgvCompra.TableDescriptor.ExpressionFields.AddRange(New ExpressionFieldDescriptor() {expField0, expField1})
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
        ConteoLabelVentas()
        txtStockDisponible.Clear()
        txtCodigoBarra.Clear()
        txtCodigoBarra.Select()
    End Sub

    Public Sub GetDocumentoVentaID(ID As Integer)
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA

        documentoVenta = New documentoventaAbarrotes
        documentoVentaDetalle = New List(Of documentoventaAbarrotesDet)

        documentoVenta = objDocCompra.GetUbicar_documentoventaAbarrotesPorID(ID)
        entidad = entidadSA.UbicarEntidadPorID(documentoVenta.idCliente).FirstOrDefault
        documentoVentaDetalle = objDocCompraDet.Get_EditarDetalleVentaSinLote(ID)
    End Sub

    Public Sub GetDocumentoVentaIDDone()
        'CABECERA COMPROBANTE
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim cantidad As Integer = 1
        Dim listaProductoBE As New List(Of documentoventaAbarrotesDet)
        Dim nombre As String = ""
        Dim relacion As Integer = 0
        'FECHAS SERVICIOS
        Dim conversion As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim cantidadDisponible = 1

        With documentoVenta
            txtFecha.Value = .fechaDoc
            lblPerido.Text = .fechaPeriodo
            txtSerie.Text = .serie
            txtNumero.Text = .numeroDoc
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
                MappingCliente(entidad.nombreCompleto, entidad.idEntidad)
            Else
                TXTcOMPRADOR.Text = .nombrePedido
            End If
            txtGlosa.Text = .glosa
        End With

        'DETALLE DE LA COMPRA
        dgvCompra.Table.Records.DeleteAll()
        For Each i In documentoVentaDetalle


            valPUmn = i.precioUnitario
            valPUme = i.precioUnitarioUS

            'CalculosByCantidad(CDec(cantidad))

            Dim colPrecUnitAlmacen = valPUmn / i.monto1
            Dim colPrecUnitUSAlmacen = valPUme / i.monto1
            Dim colPrecUnit = valPUmn
            Dim colPrecUnitme = valPUme
            Dim colDestinoGravado = 1

            Dim colCostoMN = i.monto1 * colPrecUnitAlmacen
            Dim colCostoME = i.monto1 * colPrecUnitUSAlmacen

            Dim totalMN = i.monto1 * colPrecUnit
            Dim totalME = i.monto1 * colPrecUnitme

            Dim iva As Decimal = TmpIGV / 100

            If i.monto1 > 0 Then

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

            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", i.secuencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)
            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", i.importeMNK)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", i.importeMEK)
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", i.montokardex)
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", i.montokardexUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", i.stock)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", i.tipoVenta)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.NombreAlmacen)
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigoLote", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", i.tipoVenta)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        'Calculos()
        'btGrabar.Enabled = True
        TotalTalesXcolumna()
    End Sub

    Sub Grabar()
        MappingCliente(proveedor, idProveedor)
        ndocumento = Part_Documento()
        nDocumentoVenta = Part_DocumentoVenta(proveedor, idProveedor, TipoCobro, TipoEntrega)
        ndocumento.documentoventaAbarrotes = nDocumentoVenta
        ListaDetalle = New List(Of documentoventaAbarrotesDet)
        For Each r As Record In dgvCompra.Table.Records
            ValidandoFilas(r)
            ListaDetalle.Add(AdditemDetalleVenta(TipoEntrega, r))
        Next

        Dim sumaBaseImponibleGravada =
            ListaDetalle.Where(Function(o) o.destino = 1).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBaseImponibleExonerada =
            ListaDetalle.Where(Function(o) o.destino = 2).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaIgv = ListaDetalle.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim VentaTotal = ListaDetalle.Sum(Function(o) o.importeMN).GetValueOrDefault

        ndocumento.documentoventaAbarrotes.bi01 = sumaBaseImponibleGravada
        ndocumento.documentoventaAbarrotes.bi02 = sumaBaseImponibleExonerada

        ndocumento.documentoventaAbarrotes.igv01 = sumaIgv
        ndocumento.documentoventaAbarrotes.igv02 = 0

        ndocumento.documentoventaAbarrotes.bi01us = 0
        ndocumento.documentoventaAbarrotes.bi02us = 0

        ndocumento.documentoventaAbarrotes.igv01us = 0
        ndocumento.documentoventaAbarrotes.igv02us = 0

        ndocumento.documentoventaAbarrotes.ImporteNacional = VentaTotal
        ndocumento.documentoventaAbarrotes.ImporteExtranjero = 0

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        ndocumento.ListaCustomDocumento = Nothing

        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then

            'Dim idDocumentoGrabado = VentaSA.Grabar_Venta(ndocumento)
            Dim idDocumentoGrabado = VentaSA.SaveVentaTicketPS(ndocumento, Nothing)

            LimpiarControles()
            Alert = New Alert("Pedido registrado", alertType.success)
            Alert.TopMost = True
            Alert.Show()
        Else
            Throw New Exception("Debe verificar que las celdas esten completas!")
        End If
    End Sub

    Sub updateVenta()
        MappingCliente(proveedor, idProveedor)
        ndocumento = Part_UpdateDocumento()
        nDocumentoVenta = Part_UpdateDocumentoVenta(proveedor, idProveedor, TipoCobro, TipoEntrega)
        ndocumento.documentoventaAbarrotes = nDocumentoVenta
        ListaDetalle = New List(Of documentoventaAbarrotesDet)
        For Each r As Record In dgvCompra.Table.Records
            ValidandoFilas(r)
            ListaDetalle.Add(UpdateitemDetalleVenta(TipoEntrega, r))
        Next

        Dim sumaBaseImponibleGravada =
            ListaDetalle.Where(Function(o) o.destino = 1).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBaseImponibleExonerada =
            ListaDetalle.Where(Function(o) o.destino = 2).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaIgv = ListaDetalle.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim VentaTotal = ListaDetalle.Sum(Function(o) o.importeMN).GetValueOrDefault

        ndocumento.documentoventaAbarrotes.bi01 = sumaBaseImponibleGravada
        ndocumento.documentoventaAbarrotes.bi02 = sumaBaseImponibleExonerada

        ndocumento.documentoventaAbarrotes.igv01 = sumaIgv
        ndocumento.documentoventaAbarrotes.igv02 = 0

        ndocumento.documentoventaAbarrotes.bi01us = 0
        ndocumento.documentoventaAbarrotes.bi02us = 0

        ndocumento.documentoventaAbarrotes.igv01us = 0
        ndocumento.documentoventaAbarrotes.igv02us = 0

        ndocumento.documentoventaAbarrotes.ImporteNacional = VentaTotal
        ndocumento.documentoventaAbarrotes.ImporteExtranjero = 0

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        ndocumento.ListaCustomDocumento = Nothing

        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then

            'Dim idDocumentoGrabado = VentaSA.Grabar_Venta(ndocumento)
            Dim idDocumentoGrabado = VentaSA.UpdateVentaPS(ndocumento, Nothing)

            LimpiarControles()
            Alert = New Alert("Pedido actualizado", alertType.success)
            Alert.TopMost = True
            Alert.Show()
            Dispose()
        Else
            Throw New Exception("Debe verificar que las celdas esten completas!")
        End If
    End Sub

    Private Sub MappingCliente(ByRef proveedor As String, ByRef idProveedor As Integer)
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TXTcOMPRADOR.Text
            idProveedor = CInt(TXTcOMPRADOR.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If
    End Sub

    ''' <summary>
    ''' Validando importes validos por fila {importes > 0}
    ''' </summary>
    ''' <param name="r"></param>
    Private Shared Sub ValidandoFilas(r As Record)
        If CDec(r.GetValue("cantidad")) <= 0 Then
            Throw New Exception("Debe ingresar un cantidad mayor a cero.")
        End If

        If CDec(r.GetValue("totalmn")) <= 0 Then
            Throw New Exception("El importe de venta debe ser mayor a cero.")
        End If
    End Sub

    ''' <summary>
    ''' Mapeando Objeto items a la cansta de venta
    ''' </summary>
    ''' <param name="TipoEntrega"></param>
    ''' <param name="r"></param>
    ''' <returns></returns>
    Private Function AdditemDetalleVenta(TipoEntrega As String, r As Record) As documentoventaAbarrotesDet
        Dim objDocumentoVentaDet As documentoventaAbarrotesDet
        objDocumentoVentaDet = New documentoventaAbarrotesDet
        objDocumentoVentaDet.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
        objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
        objDocumentoVentaDet.FechaDoc = txtFecha.Value
        objDocumentoVentaDet.Serie = conf.Serie
        objDocumentoVentaDet.NumDoc = conf.Serie
        objDocumentoVentaDet.TipoDoc = conf.TipoComprobante
        If r.GetValue("tipoExistencia") = "GS" Then
            objDocumentoVentaDet.idAlmacenOrigen = Nothing
            objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
        Else
            objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
            objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
        End If
        objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
        objDocumentoVentaDet.cuentaOrigen = Nothing
        objDocumentoVentaDet.idItem = r.GetValue("idProducto")
        objDocumentoVentaDet.DetalleItem = r.GetValue("item")
        objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
        objDocumentoVentaDet.destino = r.GetValue("gravado")
        objDocumentoVentaDet.unidad1 = r.GetValue("um")
        objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
        objDocumentoVentaDet.unidad2 = Nothing
        objDocumentoVentaDet.monto2 = Nothing 'CDec(r.GetValue("cantidad2"))
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
        objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
        objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
        objDocumentoVentaDet.fechaVcto = txtFecha.Value
        objDocumentoVentaDet.estadoEntrega = TipoEntrega
        objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
        objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
        objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)
        objDocumentoVentaDet.categoria = Nothing
        objDocumentoVentaDet.preEvento = Nothing
        objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
        objDocumentoVentaDet.fechaModificacion = DateTime.Now
        objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim

        Return objDocumentoVentaDet
    End Function

    Private Function UpdateitemDetalleVenta(TipoEntrega As String, r As Record) As documentoventaAbarrotesDet
        Dim objDocumentoVentaDet As documentoventaAbarrotesDet
        objDocumentoVentaDet = New documentoventaAbarrotesDet
        objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
        objDocumentoVentaDet.idDocumento = documentoID
        objDocumentoVentaDet.secuencia = r.GetValue("codigo")
        objDocumentoVentaDet.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
        objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
        objDocumentoVentaDet.FechaDoc = txtFecha.Value
        objDocumentoVentaDet.Serie = conf.Serie
        objDocumentoVentaDet.NumDoc = conf.Serie
        objDocumentoVentaDet.TipoDoc = conf.TipoComprobante
        If r.GetValue("tipoExistencia") = "GS" Then
            objDocumentoVentaDet.idAlmacenOrigen = Nothing
            objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
        Else
            objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
            objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
        End If
        objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
        objDocumentoVentaDet.cuentaOrigen = Nothing
        objDocumentoVentaDet.idItem = r.GetValue("idProducto")
        objDocumentoVentaDet.DetalleItem = r.GetValue("item")
        objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
        objDocumentoVentaDet.destino = r.GetValue("gravado")
        objDocumentoVentaDet.unidad1 = r.GetValue("um")
        objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
        objDocumentoVentaDet.unidad2 = Nothing
        objDocumentoVentaDet.monto2 = Nothing 'CDec(r.GetValue("cantidad2"))
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
        objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
        objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
        objDocumentoVentaDet.fechaVcto = txtFecha.Value
        objDocumentoVentaDet.estadoEntrega = TipoEntrega
        objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
        objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
        objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)
        objDocumentoVentaDet.categoria = Nothing
        objDocumentoVentaDet.preEvento = Nothing
        objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
        objDocumentoVentaDet.fechaModificacion = DateTime.Now
        objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim

        Return objDocumentoVentaDet
    End Function

    ''' <summary>
    ''' Mapeando Objeto Documento venta
    ''' </summary>
    ''' <param name="proveedor"></param>
    ''' <param name="idProveedor"></param>
    ''' <param name="TipoCobro"></param>
    ''' <param name="TipoEntrega"></param>
    ''' <returns></returns>
    Private Function Part_DocumentoVenta(proveedor As String, idProveedor As Integer, TipoCobro As String, TipoEntrega As String) As documentoventaAbarrotes
        Return New documentoventaAbarrotes With {
                           .TipoConfiguracion = conf.TipoConfiguracion,
                          .IdNumeracion = IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante),
                          .tipoOperacion = StatusTipoOperacion.VENTA,
                          .codigoLibro = "14",
                          .tipoDocumento = conf.TipoComprobante,
                          .idEmpresa = Gempresas.IdEmpresaRuc,
                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                          .fechaDoc = txtFecha.Value,
                          .fechaPeriodo = lblPerido.Text,
                          .serie = conf.Serie,
                          .numeroDocNormal = Nothing,
                          .idCliente = CInt(idProveedor),
                          .idClientePedido = CInt(idProveedor),
                          .nombrePedido = proveedor,
                          .moneda = "1",
                          .tasaIgv = TmpIGV,
                          .tipoCambio = TmpTipoCambio,
                          .tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO,
                          .estadoCobro = TipoCobro,
                          .estadoEntrega = StatusArticuloVentaPreparado.Pendiente,
                          .terminos = "CREDITO",
                          .glosa = txtGlosa.Text.Trim,
                          .fechaVcto = txtFecha.Value,
                          .usuarioActualizacion = usuario.IDUsuario,
                          .fechaActualizacion = DateTime.Now}
    End Function

    Private Function Part_UpdateDocumentoVenta(proveedor As String, idProveedor As Integer, TipoCobro As String, TipoEntrega As String) As documentoventaAbarrotes
        Return New documentoventaAbarrotes With {
            .idDocumento = documentoID,
                          .TipoConfiguracion = conf.TipoConfiguracion,
                          .IdNumeracion = IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante),
                          .tipoOperacion = StatusTipoOperacion.VENTA,
                          .codigoLibro = "14",
                          .tipoDocumento = conf.TipoComprobante,
                          .idEmpresa = Gempresas.IdEmpresaRuc,
                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                          .fechaDoc = txtFecha.Value,
                          .fechaPeriodo = lblPerido.Text,
                          .serie = conf.Serie,
                          .numeroDocNormal = Nothing,
                          .idCliente = CInt(idProveedor),
                          .idClientePedido = CInt(idProveedor),
                          .nombrePedido = proveedor,
                          .moneda = "1",
                          .tasaIgv = TmpIGV,
                          .tipoCambio = TmpTipoCambio,
                          .tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO,
                          .estadoCobro = TipoCobro,
                          .estadoEntrega = TipoEntrega,
                          .terminos = "CREDITO",
                          .glosa = txtGlosa.Text.Trim,
                          .fechaVcto = txtFecha.Value,
                          .usuarioActualizacion = usuario.IDUsuario,
                          .fechaActualizacion = DateTime.Now}
    End Function

    ''' <summary>
    ''' Mapeando Objeto Documento
    ''' </summary>
    ''' <returns></returns>
    Private Function Part_Documento() As documento
        Dim ndocumento As documento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = conf.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = conf.Serie
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
        Return ndocumento
    End Function

    Private Function Part_UpdateDocumento() As documento
        Dim ndocumento As documento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idDocumento = documentoID
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = conf.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = conf.Serie
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
        Return ndocumento
    End Function

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
            'Modificar precio'
            If e.ClickedItem.Text = "Modificar precio" Then
                Dim f As New FormModificarPecio
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            End If
            'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
            '    Case 1
            '        If e.ClickedItem.Text = "Agregar nuevo precio" Then
            '            Dim f As New frmNuevoPrecio
            '            f.txtProducto.Tag = dgvCompra.Table.CurrentRecord.GetValue("idProducto")
            '            f.txtProducto.Text = dgvCompra.Table.CurrentRecord.GetValue("item")
            '            f.txtGrav.Text = dgvCompra.Table.CurrentRecord.GetValue("gravado")
            '            f.StartPosition = FormStartPosition.CenterParent
            '            f.ShowDialog()

            '            nuevoprecio = precioSA.GetPreciosproductoMaxFecha(Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("idProducto")), Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("cboprecio")))

            '            If Not IsNothing(nuevoprecio) Then
            '                dgvCompra.Table.CurrentRecord.SetValue("pumn", nuevoprecio.precioMN)
            '                dgvCompra.Table.CurrentRecord.SetValue("pume", nuevoprecio.precioME)
            '                Calculos()

            '            Else
            '                MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            '                dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            '                Calculos()
            '            End If
            '        ElseIf e.ClickedItem.Text = "Ver tabla de precios" Then
            '            Dim f As New frmPreciosByArticulos(New detalleitems With {.codigodetalle = dgvCompra.Table.CurrentRecord.GetValue("idProducto"),
            '                                               .descripcionItem = dgvCompra.Table.CurrentRecord.GetValue("item")})
            '            f.StartPosition = FormStartPosition.CenterParent
            '            f.ShowDialog()
            '        End If

            '    Case Else
            '        MessageBox.Show("No tiene derechos de administrador, para realizar está tarea", "No autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End Select

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

    Sub ConteoLabelVentas()
        lblConteo.Text = "Artículos en Canasta: " & dgvCompra.Table.Records.Count
    End Sub

    Sub ConfiguracionInicio()

        'confgiurando variables generales
        cboTipoDoc.Enabled = True
        txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text
        txtFecha.Value = DateTime.Now
        txtFecha.Select()
    End Sub

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

    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub

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
    '                        GConfiguracion2.TipoComprobante = .tipo
    '                        GConfiguracion2.Serie = .serie
    '                        GConfiguracion2.ValorActual = .valorInicial
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
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                'GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

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
        dt.Columns.Add("cantidad2")
        dgvCompra.DataSource = dt
        dgvCompra.TableDescriptor.Columns("item").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvCompra.TableDescriptor.Columns("item").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Public Sub GetCombos()
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA

        ListaAlmacenes = New List(Of almacen)
        ListaAlmacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub

    Public Sub Loadcontroles()
        cboalmacen.ValueMember = "idAlmacen"
        cboalmacen.DisplayMember = "descripcionAlmacen"
        cboalmacen.DataSource = ListaAlmacenes 'almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
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
        '****************************************************
        'If cboMoneda.SelectedValue = 1 Then
        txtTotalBase3.DecimalValue = totalVC3
        txtTotalBase2.DecimalValue = totalVC2
        txtTotalBase.DecimalValue = totalVC
        txtTotalIva.Text = ((totalIVA))
        'Label4.Text = Decimal.Round(totalIVA)
        'Button1.Text = (CDec(totalIVA))
        txtTotalPagar.DecimalValue = total
        lblTotalPercepcion.DecimalValue = 0 'TotalesXcanbeceras.PercepcionMN

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
                    'colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    'cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    'colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    'colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    'colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    'colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    'colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    'colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                    'colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                    'totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
                    'totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

                    'If colDestinoGravado = 1 Then
                    '    Dim iva As Decimal = TmpIGV / 100
                    '    colBI = (totalMN / (iva + 1))
                    '    colBIme = (totalME / (iva + 1))

                    '    Dim iv As Decimal = 0
                    '    Dim iv2 As Decimal = 0
                    '    iv = totalMN / (iva + 1)
                    '    iv2 = totalME / (iva + 1)

                    '    Igv = iv * (iva)
                    '    IgvME = iv2 * (iva)
                    'Else

                    '    colBI = 0
                    '    colBIme = 0
                    '    Igv = 0
                    '    IgvME = 0

                    'End If

                    ''****************************************************************

                    'Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    'If colcantidad > 0 Then



                    '    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    '    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    'Else

                    'End If

                    'Select Case colDestinoGravado
                    '    Case 1
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '    Case 2
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    'End Select
                    'TotalTalesXcolumna()
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
                                '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                                '   Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
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
                                '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                                '   Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
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
                        '   Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                        '  Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
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
                    '         colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    '        colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
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
                            '      Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            '       Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
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
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
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
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
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
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
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
                        '     Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                        '      Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
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

    Private Sub LimpiarProductosIguales(idItem As Integer)
        For Each r As Record In dgvCompra.Table.Records
            If Integer.Parse(r.GetValue("idProducto")) = idItem Then
                r.Delete()
            End If
        Next
    End Sub

#End Region

#Region "Class LinkLabel"
    Public Class LinkLabelCellModel
        Inherits GridStaticCellModel

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Sub New(ByVal grid As GridModel)
            MyBase.New(grid)
        End Sub

        Public Overrides Function CreateRenderer(ByVal control As GridControlBase) As GridCellRendererBase
            Return New LinkLabelCellRenderer(control, Me)
        End Function
    End Class

    Public Class LinkLabelCellRenderer
        Inherits GridStaticCellRenderer

        Private _isMouseDown As Boolean
        Private _drawHotLink As Boolean
        Private _hotColor As Color
        Private _visitedColor As Color
        Private _EXEname As String

        Public Sub New(ByVal grid As GridControlBase, ByVal cellModel As GridCellModelBase)
            MyBase.New(grid, cellModel)
            _isMouseDown = False
            _drawHotLink = False
            _hotColor = Color.Red
            _visitedColor = Color.Purple
            _EXEname = "iexplore.exe"
        End Sub

        Public Property VisitedLinkColor As Color
            Get
                Return _visitedColor
            End Get
            Set(ByVal value As Color)
                _visitedColor = value
            End Set
        End Property

        Public Property ActiveLinkColor As Color
            Get
                Return _hotColor
            End Get
            Set(ByVal value As Color)
                _hotColor = value
            End Set
        End Property

        Public Property EXEname As String
            Get
                Return _EXEname
            End Get
            Set(ByVal value As String)
                _EXEname = value
            End Set
        End Property

        Private Sub DrawLink(ByVal useHotColor As Boolean, ByVal rowIndex As Integer, ByVal colIndex As Integer)
            If useHotColor Then _drawHotLink = True
            Me.Grid.RefreshRange(GridRangeInfo.Cell(rowIndex, colIndex), GridRangeOptions.None)
            _drawHotLink = False
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(rowIndex, colIndex, e)
            DrawLink(True, rowIndex, colIndex)
            _isMouseDown = True
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(rowIndex, colIndex, e)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(New Point(e.X, e.Y), row, col)

            If row = rowIndex AndAlso col = colIndex Then
                Dim style As GridStyleInfo = Me.Grid.Model(row, col)
                style.TextColor = VisitedLinkColor
            End If

            DrawLink(False, rowIndex, colIndex)
            _isMouseDown = False
        End Sub

        Protected Overrides Sub OnCancelMode(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnCancelMode(rowIndex, colIndex)
            _isMouseDown = False
            _drawHotLink = False
        End Sub

        Protected Overrides Function OnGetCursor(ByVal rowIndex As Integer, ByVal colIndex As Integer) As System.Windows.Forms.Cursor
            Dim pt As Point = Me.Grid.PointToClient(Cursor.Position)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(pt, row, col)
            Return If((row = rowIndex AndAlso col = colIndex), Cursors.Hand, If((Me._isMouseDown), Cursors.No, MyBase.OnGetCursor(rowIndex, colIndex)))
        End Function

        Protected Overrides Function OnHitTest(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As MouseEventArgs, ByVal controller As IMouseController) As Integer
            If controller IsNot Nothing AndAlso controller.Name = "OleDataSource" Then Return 0
            Return 1
        End Function

        Protected Overrides Sub OnDraw(ByVal g As System.Drawing.Graphics, ByVal clientRectangle As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal style As Syncfusion.Windows.Forms.Grid.GridStyleInfo)
            style.Font.Underline = True

            If _drawHotLink Then
                style.TextColor = ActiveLinkColor
            End If

            MyBase.OnDraw(g, clientRectangle, rowIndex, colIndex, style)
        End Sub

        Protected Overrides Sub OnMouseHoverEnter(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnMouseHoverEnter(rowIndex, colIndex)
            DrawLink(True, rowIndex, colIndex)
        End Sub

        Protected Overrides Sub OnMouseHoverLeave(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.EventArgs)
            MyBase.OnMouseHoverLeave(rowIndex, colIndex, e)
            DrawLink(False, rowIndex, colIndex)
        End Sub
    End Class
#End Region

#Region "Events"
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
            ConteoLabelVentas()
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

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTcOMPRADOR.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})

            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList


            consulta.AddRange(consulta2)
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
            ConteoLabelVentas()
        End If
    End Sub

    Private Sub GetSummaryColumn()
        Dim sd1 As GridSummaryColumnDescriptor = New GridSummaryColumnDescriptor()
        sd1.Name = "QuantityTotal"
        sd1.DataMember = "cantidad"
        sd1.DisplayColumn = "cantidad"
        sd1.Format = "{Total}"
        sd1.SummaryType = SummaryType.Custom
        dgvCompra.TableDescriptor.SummaryRows.Add(New GridSummaryRowDescriptor("Row 1", "Total", sd1))
    End Sub

    Private Sub gridGroupingControl1_QueryCustomSummary(ByVal sender As Object, ByVal e As GridQueryCustomSummaryEventArgs) Handles dgvCompra.QueryCustomSummary
        Select Case e.SummaryColumn.Name
            Case "QuantityTotal"
                e.SummaryDescriptor.CreateSummaryMethod = New CreateSummaryDelegate(AddressOf TotalSummary.CreateSummaryMethod)
                Exit Select
                'Case "QuantityDistinctCount"
                '    e.SummaryDescriptor.CreateSummaryMethod = New CreateSummaryDelegate(DistinctInt32CountSummary.CreateSummaryMethod)
                '    Exit Select
                'Case "QuantityMedian"
                '    e.SummaryDescriptor.CreateSummaryMethod = New CreateSummaryDelegate(StatisticsSummary.CreateSummaryMethod)
                '    Exit Select
        End Select
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
                '  Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                'Select Case strTipoExistencia
                '    Case "GS"
                '        'e.Style.BackColor = Color.Yellow
                '        'e.Style.TextColor = Color.Black
                '        e.Style.[ReadOnly] = True
                '    Case Else
                '        e.Style.[ReadOnly] = True
                'End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "totalmn")) Then
                'Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                'Select Case strTipoExistencia
                '    Case "GS"
                '        e.Style.BackColor = Color.Yellow
                '        e.Style.TextColor = Color.Black
                '        e.Style.[ReadOnly] = False
                '    Case Else
                '        e.Style.[ReadOnly] = True
                'End Select


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "item")) Then
                'Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                'Select Case strTipoExistencia
                '    Case "GS"
                '        e.Style.[ReadOnly] = False
                '    Case Else
                '        e.Style.[ReadOnly] = True
                'End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then
                'Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                'Select Case strTipoExistencia
                '    Case "GS"
                '        e.Style.[ReadOnly] = False
                '    Case Else
                '        e.Style.[ReadOnly] = True
                'End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                'Dim cantidadActual = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 7).CellValue
                'Dim cantidadDisponible = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 25).CellValue
                'fds
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


        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then


            If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                    Dim r As Record = el.GetRecord()
                    If r Is Nothing Then Return
                    Dim cant As Decimal? = r.GetValue("cantidad")
                    Dim cantDis As Decimal? = r.GetValue("canDisponible")

                    If cant > cantDis Then
                        'e.Style.Enabled = False
                        e.Style.CellValue = 0
                    End If
                End If
            End If

        End If


    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim precio As New configuracionPrecioProducto

        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
        '    Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

        '    Select Case ColIndex
        '        Case 1 ' CODIGO BARRA


        '        Case 2 ' seleccion de empresa stock

        '        Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            If Not IsNothing(r) Then

        '                Select Case Int32.Parse(r.GetValue("cboprecio"))
        '                    Case 0
        '                        'Dim f As New frmPreciosByArticulos(r)
        '                        'f.StartPosition = FormStartPosition.CenterParent
        '                        'f.ShowDialog()

        '                    Case Else
        '                        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

        '                        If Not IsNothing(precio) Then
        '                            r.SetValue("pumn", precio.precioMN)
        '                            r.SetValue("pume", precio.precioME)
        '                            Calculos()
        '                        Else
        '                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            r.SetValue("pumn", 0)
        '                            r.SetValue("pume", 0)
        '                            Calculos()
        '                        End If
        '                End Select

        '            Else

        '            End If

        'End Select
        'End If

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                e.Inner.Cancel = True
            End If
            '   Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            '     Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
        Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style3.Enabled Then
            If style3.TableCellIdentity.Column.Name = "item" Then
                '       e.Inner.Cancel = True
                dgvCompra.TableDescriptor.GroupedColumns.Clear()
                Dim nomproduct = Me.dgvCompra.TableModel(e.Inner.RowIndex, 5).CellValue
                FormInventarioCanastaTotales = New FormInventarioCanastaTotales(cboalmacen.SelectedValue, nomproduct)
                FormInventarioCanastaTotales.validaStocks = True
                FormInventarioCanastaTotales.StartPosition = FormStartPosition.CenterScreen
                FormInventarioCanastaTotales.Show(Me)
            End If

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
                                dgvCompra.TableDescriptor.GroupedColumns.Clear()
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
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim text As String = cc.Renderer.ControlText
                    If text.Trim.Length > 0 Then
                        Dim value As Decimal = Convert.ToDecimal(text)
                        cc.Renderer.ControlValue = value

                        Dim cantiDisponible = r.GetValue("canDisponible")
                        If value > cantiDisponible Then
                            cc.Renderer.ControlValue = 0
                            cc.ConfirmChanges()
                            cc.EndEdit()
                            Calculos()
                            lblEstado.Text = "La cantidad disponible es: " & cantiDisponible
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            Calculos()
                        End If

                    End If

                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Calculos()
            End Select
        End If

    End Sub

    Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim precio As New configuracionPrecioProducto
        'Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
        '    Select Case cc.ColIndex
        '        Case 1 ' CODIGO BARRA


        '        Case 2 ' seleccion de empresa stock

        '        Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            If Not IsNothing(r) Then

        '                Select Case Int32.Parse(r.GetValue("cboprecio"))
        '                    Case 0
        '                        'Dim f As New frmPreciosByArticulos(r)
        '                        'f.StartPosition = FormStartPosition.CenterParent
        '                        'f.ShowDialog()

        '                    Case Else
        '                        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

        '                        If Not IsNothing(precio) Then
        '                            r.SetValue("pumn", precio.precioMN)
        '                            r.SetValue("pume", precio.precioME)
        '                            Calculos()
        '                        Else
        '                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            r.SetValue("pumn", 0)
        '                            r.SetValue("pume", 0)
        '                            Calculos()
        '                        End If
        '                End Select

        '            Else

        '            End If



        '        Case 7 ' cantidad
        '            'Select Case strTipoEx
        '            'Case "GS"
        '            Dim r As Record = dgvCompra.Table.CurrentRecord

        '            If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

        '            Else
        '                cc.ConfirmChanges()
        '                cc.EndEdit()

        '            End If
        '            Calculos()

        '            'End Select
        '        Case 8
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            Calculos()
        '    End Select
        'End If
    End Sub

    Private Sub dgvCompra_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlKeyPress
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim precio As New configuracionPrecioProducto
        'Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
        '    Select Case cc.ColIndex
        '        Case 1 ' CODIGO BARRA


        '        Case 2 ' seleccion de empresa stock

        '        Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            If Not IsNothing(r) Then

        '                Select Case Int32.Parse(r.GetValue("cboprecio"))
        '                    Case 0
        '                        'Dim f As New frmPreciosByArticulos(r)
        '                        'f.StartPosition = FormStartPosition.CenterParent
        '                        'f.ShowDialog()

        '                    Case Else
        '                        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

        '                        If Not IsNothing(precio) Then
        '                            r.SetValue("pumn", precio.precioMN)
        '                            r.SetValue("pume", precio.precioME)
        '                            Calculos()
        '                        Else
        '                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            r.SetValue("pumn", 0)
        '                            r.SetValue("pume", 0)
        '                            Calculos()
        '                        End If
        '                End Select

        '            Else

        '            End If



        '        Case 7 ' cantidad
        '            'Select Case strTipoEx
        '            'Case "GS"
        '            Dim r As Record = dgvCompra.Table.CurrentRecord

        '            If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

        '            Else
        '                cc.ConfirmChanges()
        '                cc.EndEdit()

        '            End If
        '            Calculos()

        '            'End Select
        '        Case 8
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            Calculos()
        '    End Select
        'End If
    End Sub

    Private Sub dgvCompra_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyUp
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim precio As New configuracionPrecioProducto
        'Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
        '    Select Case cc.ColIndex
        '        Case 1 ' CODIGO BARRA


        '        Case 2 ' seleccion de empresa stock

        '        Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            If Not IsNothing(r) Then

        '                Select Case Int32.Parse(r.GetValue("cboprecio"))
        '                    Case 0
        '                        'Dim f As New frmPreciosByArticulos(r)
        '                        'f.StartPosition = FormStartPosition.CenterParent
        '                        'f.ShowDialog()

        '                    Case Else
        '                        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

        '                        If Not IsNothing(precio) Then
        '                            r.SetValue("pumn", precio.precioMN)
        '                            r.SetValue("pume", precio.precioME)
        '                            Calculos()
        '                        Else
        '                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            r.SetValue("pumn", 0)
        '                            r.SetValue("pume", 0)
        '                            Calculos()
        '                        End If
        '                End Select

        '            Else

        '            End If



        '        Case 7 ' cantidad
        '            'Select Case strTipoEx
        '            'Case "GS"
        '            Dim r As Record = dgvCompra.Table.CurrentRecord

        '            If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

        '            Else
        '                cc.ConfirmChanges()
        '                cc.EndEdit()

        '            End If
        '            Calculos()

        '            'End Select
        '        Case 8
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            Calculos()
        '    End Select
        'End If
    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            ProgressBar2.Visible = True
            ProgressBar2.Style = ProgressBarStyle.Marquee
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        configuracionModuloV2(strIDEmpresa, "VT1", "", GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        txtSerie.Text = conf.Serie
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
                If (ManipulacionEstado = ENTITY_ACTIONS.INSERT) Then
                    Grabar()
                ElseIf (ManipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
                    updateVenta()
                End If
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        FormInventarioCanastaTotales = New FormInventarioCanastaTotales(cboalmacen.SelectedValue)
        FormInventarioCanastaTotales.validaStocks = True
        FormInventarioCanastaTotales.StartPosition = FormStartPosition.CenterScreen
        FormInventarioCanastaTotales.Show(Me)
    End Sub

    Private Sub bgVenta_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgVenta.DoWork
        GetDocumentoVentaID(Integer.Parse(Tag))
    End Sub

    Private Sub bgVenta_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgVenta.RunWorkerCompleted
        GetDocumentoVentaIDDone()
    End Sub

    Private Sub txtCodigoBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoBarra.KeyDown
        If e.KeyCode = Keys.Enter Then
            'e.SuppressKeyPress = True
            'If txtCodigoBarra.Text.Trim.Length > 0 Then
            '    GetExistenciaByCodigoBar(txtCodigoBarra.Text.Trim)
            'End If
        End If
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If LsvProveedor.SelectedItems.Count > 0 Then
                If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
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
                Else
                    TXTcOMPRADOR.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TXTcOMPRADOR.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                    txtruc.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TXTcOMPRADOR.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub EnviarListaArticulos(lista As List(Of totalesAlmacen)) Implements IListaInventario.EnviarListaArticulos
        LimpiarProductosIguales(lista(0).idItem)
        For Each i In lista
            EnvioProductoSolo(i)
        Next
        ConteoLabelVentas()
        TotalTalesXcolumna()
        '  TotalTalesXcolumnaEspecial()
    End Sub

    Sub CalculosByCantidadExistente(cant As Decimal, recordAlive As Record)
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

        Dim strTipoExistencia = recordAlive.GetValue("tipoExistencia")
        Select Case strTipoExistencia
            Case "GS"
                colcantidad = 1 ' Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                colPrecUnit = recordAlive.GetValue("totalmn")
                colPrecUnitme = recordAlive.GetValue("totalmn")
                colDestinoGravado = recordAlive.GetValue("gravado")

                colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                totalMN = recordAlive.GetValue("totalmn") ' colcantidad * colPrecUnit
                totalME = recordAlive.GetValue("totalme") ' colcantidad * colPrecUnitme

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

                recordAlive.SetValue("cantidad", colcantidad)
                If colcantidad > 0 Then



                    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                Else

                End If

                Select Case colDestinoGravado
                    Case 1
                        recordAlive.SetValue("vcmn", Math.Round(colBI, 2))
                        recordAlive.SetValue("vcme", Math.Round(colBIme, 2))
                        recordAlive.SetValue("pumn", colPrecUnit)
                        recordAlive.SetValue("pume", colPrecUnitme)
                        recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                        recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                        recordAlive.SetValue("igvmn", Math.Round(Igv, 2))
                        recordAlive.SetValue("igvme", Math.Round(IgvME, 2))
                        recordAlive.SetValue("percepcionMN", 0)
                        recordAlive.SetValue("percepcionME", 0)
                        recordAlive.SetValue("costoMN", colCostoMN)
                        recordAlive.SetValue("costoME", colCostoME)
                    Case 2
                        recordAlive.SetValue("vcmn", Math.Round(totalMN, 2))
                        recordAlive.SetValue("vcme", Math.Round(totalME, 2))
                        recordAlive.SetValue("pumn", colPrecUnit)
                        recordAlive.SetValue("pume", colPrecUnitme)
                        recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                        recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                        recordAlive.SetValue("igvmn", 0)
                        recordAlive.SetValue("igvme", 0)
                        recordAlive.SetValue("percepcionMN", 0)
                        recordAlive.SetValue("percepcionME", 0)
                        recordAlive.SetValue("costoMN", colCostoMN)
                        recordAlive.SetValue("costoME", colCostoME)
                End Select
                TotalTalesXcolumna()
                'TotalTalesXcolumnaEspecial()
            Case Else
                If (recordAlive.GetValue("cantidad") <= recordAlive.GetValue("canDisponible")) Then

                    colcantidad = CDec(recordAlive.GetValue("cantidad")) + cant
                    cantidadDisponible = recordAlive.GetValue("canDisponible")
                    colPrecUnitAlmacen = recordAlive.GetValue("puKardex")
                    colPrecUnitUSAlmacen = recordAlive.GetValue("pukardeme")
                    colPrecUnit = recordAlive.GetValue("pumn")
                    colPrecUnitme = recordAlive.GetValue("pume")
                    colDestinoGravado = recordAlive.GetValue("gravado")

                    colCostoMN = colcantidad * colPrecUnitAlmacen
                    colCostoME = colcantidad * colPrecUnitUSAlmacen

                    totalMN = colcantidad * colPrecUnit
                    totalME = colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        valPercepMN = recordAlive.GetValue("percepcionMN")
                        valPercepME = recordAlive.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    Dim iva As Decimal = TmpIGV / 100

                    recordAlive.SetValue("cantidad", colcantidad)
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
                            recordAlive.SetValue("vcmn", Math.Round(colBI, 2))
                            recordAlive.SetValue("vcme", Math.Round(colBIme, 2))
                            recordAlive.SetValue("pumn", colPrecUnit)
                            recordAlive.SetValue("pume", colPrecUnitme)
                            recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                            recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                            recordAlive.SetValue("igvmn", Math.Round(Igv, 2))
                            recordAlive.SetValue("igvme", Math.Round(IgvME, 2))
                            recordAlive.SetValue("percepcionMN", 0)
                            recordAlive.SetValue("percepcionME", 0)
                            recordAlive.SetValue("costoMN", colCostoMN)
                            recordAlive.SetValue("costoME", colCostoME)
                        Case 2
                            recordAlive.SetValue("vcmn", Math.Round(totalMN, 2))
                            recordAlive.SetValue("vcme", Math.Round(totalME, 2))
                            recordAlive.SetValue("pumn", colPrecUnit)
                            recordAlive.SetValue("pume", colPrecUnitme)
                            recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                            recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                            recordAlive.SetValue("igvmn", 0)
                            recordAlive.SetValue("igvme", 0)
                            recordAlive.SetValue("percepcionMN", 0)
                            recordAlive.SetValue("percepcionME", 0)
                            recordAlive.SetValue("costoMN", colCostoMN)
                            recordAlive.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                    'TotalTalesXcolumnaEspecial()
                Else
                    dgvCompra.Table.CurrentRecord.EndEdit()
                    lblEstado.Text = "La cantidad disponible es: " & recordAlive.GetValue("canDisponible")
                    recordAlive.SetValue("cantidad", 0.0)
                    recordAlive.SetValue("vcmn", Math.Round(colBI, 2))
                    recordAlive.SetValue("vcme", Math.Round(colBIme, 2))
                    'recordAlive.SetValue("pumn", colPrecUnit)
                    'recordAlive.SetValue("pume", colPrecUnitme)
                    recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                    recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                    recordAlive.SetValue("igvmn", Math.Round(Igv, 2))
                    recordAlive.SetValue("igvme", Math.Round(IgvME, 2))
                    recordAlive.SetValue("percepcionMN", 0)
                    recordAlive.SetValue("percepcionME", 0)
                    recordAlive.SetValue("costoMN", colCostoMN)
                    recordAlive.SetValue("costoME", colCostoME)
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

    End Sub

    Private Function VerificarItemDuplicadoV2(cantidad As Decimal, lote As Integer, intIdItem As Integer) As Boolean
        VerificarItemDuplicadoV2 = False
        Dim colIdItem As Integer
        Dim codigoLote As Integer

        colIdItem = intIdItem
        codigoLote = lote
        For Each i In dgvCompra.Table.Records
            If colIdItem = i.GetValue("idProducto") Then
                CalculosByCantidadExistente(cantidad, i)
                VerificarItemDuplicadoV2 = True
                Exit For
            End If
        Next
    End Function

    'Private Function VerificarItemDuplicado(cantidad As Decimal, lote As Integer, intIdItem As Integer, tipoprecio As String) As Boolean
    '    VerificarItemDuplicado = False
    '    Dim colIdItem As Integer
    '    Dim precio As String
    '    Dim codigoLote As Integer

    '    colIdItem = intIdItem
    '    precio = tipoprecio
    '    codigoLote = lote
    '    For Each i In dgvCompra.Table.Records
    '        If colIdItem = i.GetValue("idProducto") AndAlso precio = i.GetValue("cboprecio") AndAlso codigoLote = i.GetValue("codigoLote") Then
    '            CalculosByCantidadExistente(cantidad, i)
    '            VerificarItemDuplicado = True
    '            Exit For
    '        End If
    '    Next
    'End Function



    Sub EnvioProductoSolo(productoBE As totalesAlmacen)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            Dim cantidad = Nothing
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0
            cantidad = productoBE.cantidad
            valPUmn = productoBE.PMprecioMN
            valPUme = productoBE.PMprecioME
            Dim existeEnCanasta = VerificarItemDuplicadoV2(CDec(cantidad), 0, productoBE.idItem)
            If existeEnCanasta Then

            Else

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

                Select Case productoBE.origenRecaudo
                    Case OperacionGravada.Grabado
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
                    Case OperacionGravada.Exonerado, OperacionGravada.Inafecto
                        If cantidad > 0 Then
                            colBI = (totalMN)
                            colBIme = (totalME)
                            Igv = 0
                            IgvME = 0
                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If
                End Select


                With dgvCompra.Table
                    .AddNewRecord.SetCurrent()
                    .AddNewRecord.BeginEdit()
                    .CurrentRecord.SetValue("codigo", 0)
                    .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
                    .CurrentRecord.SetValue("idProducto", productoBE.idItem)
                    .CurrentRecord.SetValue("item", productoBE.descripcion)
                    .CurrentRecord.SetValue("um", productoBE.idUnidad)
                    .CurrentRecord.SetValue("cantidad", cantidad)
                    .CurrentRecord.SetValue("canDisponible", productoBE.cantidad2)
                    .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))

                    .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                    .CurrentRecord.SetValue("marca", Nothing) ') If(productoBE.CustomLote.productoSustentado = True, "Doc.", "Not.")) 'Susuentado y no sustentado

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
                    .CurrentRecord.SetValue("cat", StatusCategoriaVenta.Productos)
                    .CurrentRecord.SetValue("codigoLote", 0) ' productoBE.codigoLote)
                    .CurrentRecord.SetValue("codBarra", productoBE.CodigoBarra)
                    .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                    .CurrentRecord.SetValue("tipoventa", "V")
                    .CurrentRecord.SetValue("cantidad2", 0)
                    .AddNewRecord.EndEdit()
                    .TableDirty = True
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
    End Sub

    Public Sub EnviarConsigna(be As totalesAlmacen) Implements IProductoConsignado.EnviarConsigna
        EnvioProductoConsignado(be)
    End Sub

    Sub EnvioProductoConsignado(productoBE As totalesAlmacen)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            Dim cantidad = Nothing
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0


            cantidad = productoBE.cantidad

            'Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, productoBE.idItem)

            'If precios.Count = 0 Then
            '    MessageBox.Show("El producto seleccionado no tiene precios configurados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

            '    Exit Sub
            'End If
            'productoBE.PMprecioMN = precios.FirstOrDefault.precioMN ' Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciomn")
            'productoBE.PMprecioME = precios.FirstOrDefault.precioME
            'productoBE.tipoConfiguracion = precios.FirstOrDefault.idPrecio
            valPUmn = productoBE.PMprecioMN
            valPUme = productoBE.PMprecioME

            'Dim existeEnCanasta = VerificarItemDuplicado(CDec(cantidad), productoBE.codigoLote, productoBE.idItem, productoBE.tipoConfiguracion)
            ' If existeEnCanasta Then

            ' Else
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

            Select Case productoBE.origenRecaudo
                Case OperacionGravada.Grabado
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
                Case OperacionGravada.Exonerado, OperacionGravada.Inafecto
                    If cantidad > 0 Then
                        colBI = (totalMN)
                        colBIme = (totalME)
                        Igv = 0
                        IgvME = 0
                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If
            End Select


            With dgvCompra.Table
                .AddNewRecord.SetCurrent()
                .AddNewRecord.BeginEdit()
                .CurrentRecord.SetValue("codigo", 0)
                .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
                .CurrentRecord.SetValue("idProducto", productoBE.idItem)
                .CurrentRecord.SetValue("item", productoBE.descripcion)
                .CurrentRecord.SetValue("um", productoBE.idUnidad)
                .CurrentRecord.SetValue("cantidad", cantidad)
                .CurrentRecord.SetValue("canDisponible", 100000)
                .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                .CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))

                .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                .CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                .CurrentRecord.SetValue("marca", "Doc.") 'Susuentado y no sustentado

                .CurrentRecord.SetValue("pumn", valPUmn)
                .CurrentRecord.SetValue("pume", valPUme)

                .CurrentRecord.SetValue("puKardex", productoBE.importeSoles / productoBE.cantidad)
                .CurrentRecord.SetValue("pukardeme", productoBE.importeDolares / productoBE.cantidad)

                .CurrentRecord.SetValue("chPago", False)
                .CurrentRecord.SetValue("valPago", "No Pagado")

                .CurrentRecord.SetValue("chBonif", False)
                .CurrentRecord.SetValue("valBonif", "N")
                '   If .tipoExistencia <> "GS" Then
                .CurrentRecord.SetValue("almacen", cboalmacen.SelectedValue)
                .CurrentRecord.SetValue("presentacion", cboalmacen.Text)

                .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                .CurrentRecord.SetValue("costoMN", colCostoMN)
                .CurrentRecord.SetValue("costoME", colCostoME)
                .CurrentRecord.SetValue("tipoPrecio", 1)
                .CurrentRecord.SetValue("cboprecio", 1)
                .CurrentRecord.SetValue("cat", StatusCategoriaVenta.ProductosEnConsigna)
                .CurrentRecord.SetValue("codigoLote", "-")
                .CurrentRecord.SetValue("codBarra", "-")
                .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                .CurrentRecord.SetValue("tipoventa", "V")
                .AddNewRecord.EndEdit()
                .TableDirty = True
            End With
            '    End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        'FormVentaEnConsigna = New FormVentaEnConsigna
        'FormVentaEnConsigna.StartPosition = FormStartPosition.CenterScreen
        'FormVentaEnConsigna.ShowDialog(Me)
        FormNotaCompraDirecta = New FormNotaCompraDirecta(txtFecha.Value)
        FormNotaCompraDirecta.StartPosition = FormStartPosition.CenterScreen
        FormNotaCompraDirecta.ShowDialog(Me)
        Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Public Sub CambiarPrecio(precio As configuracionPrecioProducto) Implements IPrecio.CambiarPrecio
        dgvCompra.Table.CurrentRecord.SetValue("pumn", precio.precioMN)
        dgvCompra.Table.CurrentRecord.SetValue("pume", precio.precioME)
        dgvCompra.Refresh()
        Calculos()
        TotalTalesXcolumna()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If dgvCompra.Table.CurrentRecord IsNot Nothing Then
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            Dim f As New FormModificarPecio
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If

    End Sub

    Private Sub FormVentaNuevoPosV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        lblConteo.Visible = True

        dgvCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.CellType = "LinkLabelCell"
        dgvCompra.Refresh()
        '   GetSummaryColumn()
    End Sub


#End Region

End Class