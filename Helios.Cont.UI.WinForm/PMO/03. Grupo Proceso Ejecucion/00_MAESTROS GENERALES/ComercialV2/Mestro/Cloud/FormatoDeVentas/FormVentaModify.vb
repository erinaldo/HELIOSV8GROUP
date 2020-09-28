Imports System.ComponentModel
Imports System.Runtime.Serialization
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class FormVentaModify
    Implements IForm, IPrecio, IListaInventario, IProductoConsignado,
        IOferta, ICommitOperacionMKT, IListaServicio
#Region "Attributes"
    ' Public Property ventaSA As New documentoVentaAbarrotesSA
    Public Property documentoSA As New DocumentoSA

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.F2
                btGrabar.PerformClick()

            Case Keys.F5
                ToolStripButton1.PerformClick()

            'Case Keys.F9
            '    ToolStripButton1.PerformClick()

            Case Keys.F8
                ToolStripButton2.PerformClick()

            Case Keys.F7
                ToolImportar.PerformClick()

            Case Keys.F10
                'If (ValidarKey = True) Then
                'btGrabar.PerformClick()
                ToolStripButton3.PerformClick()
            Case Keys.F6
                btServicio.PerformClick()

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region


#Region "Variables"
    Dim thread As System.Threading.Thread
    Public Property ListaBeneficios As List(Of Business.Entity.beneficio)
    Public Property inicioComprobante() As String
    Public Property VentaSA As New documentoVentaAbarrotesSA
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property listaClientes As New List(Of entidad)
    Public Property entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Friend Delegate Sub SetDataSourceDelegateNumeracion(ByVal numeracion As moduloConfiguracion)
    '    Public ListaEstadosFinancieros As List(Of estadosFinancieros)
    '    Public ListaTipoExistencia As List(Of tabladetalle)
    '   Public ListaComprobantesCaja As List(Of tabladetalle)
    Public ListaAlmacenes As List(Of almacen)
    Public Alert As Alert
    Public Property documentoVenta As documentoventaAbarrotes
    Public Property documentoVentaDetalle As List(Of documentoventaAbarrotesDet)
    Public Property entidad As entidad
    Public Property frmCanastaInventary As frminfoInventario
    'Public Property FormInventarioCanastaTotales As FormInventarioCanastaTotales
    'Public Property FormVentaEnConsigna As FormVentaEnConsigna
    Private FormNotaCompraDirecta As FormNotaCompraDirecta
    Public Property InventarioSA As New TotalesAlmacenSA

    Public Property TipoVentaGeneral As String
    Public Property ListaventasEnEspera As List(Of documentoventaAbarrotes)
    Public Property ManipulacionEstado As String
#End Region

#Region "Constructors"
    Public Sub New(IDventa As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(dgvCompra, False, False, 11.5F)
        ' Add any initialization after the InitializeComponent() call.
        GetTableGrid()
        GetVenta(IDventa)
        frmCanastaInventary = New frminfoInventario()
        ConfiguracionInicio()

        threadClientes()
        bgCombos.RunWorkerAsync()
        dgvCompra.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(dgvCompra.TableModel))
        If ClipBoardDocumento IsNot Nothing Then
            If Not IsNothing(ClipBoardDocumento.documentoventaAbarrotes) Then
                '      btnPegadoEspecial.Visible = True
            End If
        End If
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "COTIZACION", "", GEstableciento.IdEstablecimiento)
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

#Region "Methods"

    Private Sub GetVenta(idDocumento As Integer)
        Dim entidadSA As New entidadSA
        Try
            venta = VentaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = idDocumento})
            Dim ent = entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault
            LabelFecha.Text = $"{"Fecha: "}{venta.fechaDoc}"
            TextComprador.Text = venta.nombrePedido

            If venta IsNot Nothing Then
                Select Case venta.tipoDocumento
                    Case "01"
                        ComboComprobante.Text = "FACTURA ELECTRONICA"
                        TextNumeroVenta.Text = $"{venta.serieVenta}-{venta.numeroVenta}"
                    Case "03"
                        ComboComprobante.Text = "BOLETA ELECTRONICA"
                        TextNumeroVenta.Text = $"{venta.serieVenta}-{venta.numeroVenta}"
                    Case "9907"
                        ComboComprobante.Text = "NOTA DE VENTA"
                        TextNumeroVenta.Text = $"{venta.serie}-{venta.numeroDoc}"
                    Case Else
                        ComboComprobante.Text = "PROFORMA"
                        TextNumeroVenta.Text = $"{venta.serie}-{venta.numeroDoc}"
                End Select
            End If

            TextCliente.Text = ent.nombreCompleto
            TextCliente.Tag = ent.idEntidad
            txtruc.Text = ent.nrodoc

            'identificando al vendedor
            Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = venta.usuarioActualizacion).FirstOrDefault
            If vendedor IsNot Nothing Then
                TextVendedor.Text = vendedor.Full_Name
                TextVendedor.Tag = vendedor.IDUsuario
            End If

            'TextBaseImponible.DecimalValue = venta.bi01
            'TextIVA.DecimalValue = venta.igv01 + venta.igv02
            'TextTotal.DecimalValue = venta.ImporteNacional
            'DigitalGauge2.Value = venta.ImporteNacional

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            ' GridBeneficios.Table.Records.DeleteAll()
            For Each i In venta.documentoventaAbarrotesDet.ToList

                Dim productoInventory = VentaSA.GetInventoryProductoID(i.idItem, i.idAlmacenOrigen)
                'Dim lote = loteSA.GetLoteByID(i.codigoLote)


                Select Case i.tipobeneficio
                    Case "REGALO"
                    'With GridBeneficios.Table
                    '    .AddNewRecord.SetCurrent()
                    '    .AddNewRecord.BeginEdit()
                    '    .CurrentRecord.SetValue("idItem", i.idItem)
                    '    .CurrentRecord.SetValue("detalle", i.nombreItem)
                    '    .CurrentRecord.SetValue("um", i.unidad1)
                    '    .CurrentRecord.SetValue("cantidad", i.monto1)
                    '    .CurrentRecord.SetValue("beneficio", i.tipobeneficio)
                    '    .CurrentRecord.SetValue("beneficiobase", i.beneficiobase)
                    '    .CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
                    '    .CurrentRecord.SetValue("gravado", i.destino)
                    '    .AddNewRecord.EndEdit()
                    '    '.TableDirty = True
                    'End With

                    Case "OFERTA"
                    'With GridBeneficios.Table
                    '    .AddNewRecord.SetCurrent()
                    '    .AddNewRecord.BeginEdit()
                    '    .CurrentRecord.SetValue("idItem", i.idItem)
                    '    .CurrentRecord.SetValue("detalle", i.nombreItem)
                    '    .CurrentRecord.SetValue("um", i.unidad1)
                    '    .CurrentRecord.SetValue("cantidad", i.monto1)
                    '    .CurrentRecord.SetValue("beneficio", i.tipobeneficio)
                    '    .CurrentRecord.SetValue("beneficiobase", i.beneficiobase)
                    '    .CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
                    '    .CurrentRecord.SetValue("gravado", i.destino)
                    '    .AddNewRecord.EndEdit()
                    '    '.TableDirty = True
                    'End With

                    Case "DESCUENTO REBAJA"
                        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", productoInventory.stock)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", i.importeMN)

                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(lote.productoSustentado = True, "Doc.", "Not."))

                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)

                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipobeneficio", i.tipobeneficio)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valorbase", i.beneficiobase)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valorafecto", i.descuentoMN.GetValueOrDefault)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN.GetValueOrDefault + i.descuentoMN.GetValueOrDefault)

                        'Me.dgvCompra.Table.CurrentRecord.SetValue("tipoventa", i.tipoVenta)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", i.tipoVenta)

                        If productoInventory.menor > 0 Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "1")
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.menor)
                        ElseIf productoInventory.mayor > 0 Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "2")
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.mayor)
                        ElseIf productoInventory.granMayor > 0 Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "3")
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.granMayor)
                        Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "0")
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                        End If

                        Me.dgvCompra.Table.CurrentRecord.SetValue("menor", productoInventory.menor)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("mayor", productoInventory.mayor)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("gmayor", productoInventory.granMayor)

                        Me.dgvCompra.Table.AddNewRecord.EndEdit()
                    Case Else
                        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", productoInventory.stock)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", i.importeMN)

                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(lote.productoSustentado = True, "Doc.", "Not."))

                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)

                        Me.dgvCompra.Table.CurrentRecord.SetValue("tipobeneficio", i.tipobeneficio)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valorbase", i.beneficiobase)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("valorafecto", i.descuentoMN.GetValueOrDefault)

                        'Me.dgvCompra.Table.CurrentRecord.SetValue("tipoventa", i.tipoVenta)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", i.tipoVenta)

                        Me.dgvCompra.Table.CurrentRecord.SetValue("menor", productoInventory.menor)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("mayor", productoInventory.mayor)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("gmayor", productoInventory.granMayor)

                        If productoInventory.menor > 0 Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "1")
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.menor)
                        ElseIf productoInventory.mayor > 0 Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "2")
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.mayor)
                        ElseIf productoInventory.granMayor > 0 Then
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "3")
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.granMayor)
                        Else
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "0")
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                        End If


                        Me.dgvCompra.Table.AddNewRecord.EndEdit()
                End Select

            Next
            TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

            ' btGrabar.Enabled = False
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        '  Dim varios = VarClienteGeneral ' entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(VarClienteGeneral)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
        End If
    End Sub

    Public Sub EnviarFacturaElectronica(idDocumento As Integer, idPSE As Integer)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        Try

            Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
            Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
            Dim conteo As Integer = 0

            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = idPSE 'lblIdPse.Text
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = comprobante.serieVenta & "-" & numerovent
            Factura.FechaEmision = comprobante.fechaDoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")
            If comprobante.moneda = "1" Then
                Factura.Moneda = "PEN"
            ElseIf comprobante.moneda = "2" Then
                Factura.Moneda = "USD"
            End If
            Factura.TipoDocumento = tipoDoc
            Factura.TotalIgv = comprobante.igv01
            Factura.TotalVenta = comprobante.ImporteNacional
            Factura.Gravadas = comprobante.bi01
            Factura.Exoneradas = comprobante.bi02
            Factura.TipoOperacion = "0101"

            'Cargando el Detalle de la Factura

            For Each i In comprobanteDetalle
                conteo += 1

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = i.monto1
                DetalleFactura.PrecioReferencial = i.precioUnitario
                DetalleFactura.CodigoItem = i.idItem
                DetalleFactura.Descripcion = i.nombreItem
                DetalleFactura.UnidadMedida = i.unidad1
                DetalleFactura.Impuesto = i.montoIgv
                If i.destino = "1" Then
                    DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                    DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                    DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                ElseIf i.destino = "2" Then
                    DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                    DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                    DetalleFactura.PrecioUnitario = i.precioUnitario
                End If

                DetalleFactura.TotalVenta = i.montokardex
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next


            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSave(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then

                UpdateEnvioSunatEstado(comprobante.idDocumento, "SI")
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

            'MessageBox.Show("No se Pudo Enviar")

        End Try


    End Sub

    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateFacturasXEstado(idDoc, estado)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            'MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub

    Sub ImprimirTicket(intIdDocumento As Integer)
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()

        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


        'Ya podemos usar todos sus metodos
        ticket.AbreCajon()
        'Para abrir el cajon de dinero.
        'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        'Datos de la cabecera del Ticket.
        ticket.TextoCentro("REPRESENTACIONES PIEROS")
        'ticket.TextoCentro("ERM NEGOCIOS SAC.")
        'ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
        'ticket.TextoCentro("JESUS MARIA - LIMA PERU")
        'ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
        ticket.TextoCentro("RUC. " & "20486529131")
        '   ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com")
        'Es el mio por si me quieren contactar ...
        ticket.TextoIzquierda("")
        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)

            Case Else
                ticket.TextoIzquierda("Ticket nota # " & comprobante.numeroVenta)
        End Select


        ticket.lineasHorizontales()
        'Sub cabecera.
        ticket.TextoIzquierda("")

        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
            ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                ticket.TextoIzquierda("RUC.: " & entidad.nrodoc)
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                ticket.TextoIzquierda("DNI.: " & entidad.nrodoc)
            Else
                ticket.TextoIzquierda("NRO DOC.: " & entidad.nrodoc)
            End If

        Else
            Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
            ticket.TextoIzquierda(NBoletaElectronica)

        End If
        '    ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
        ticket.TextoIzquierda("")
        ticket.TextoExtremos("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString(), "HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())
        ticket.lineasHorizontales()

        'Articulos a vender.
        ticket.EncabezadoVentaV2()
        'NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        'ticket.lineasAsteriscos()
        ticket.lineasHorizontales()
        'Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        'foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        '{
        'ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        'decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        '}

        For Each i In comprobanteDetalle

            Select Case i.destino
                Case OperacionGravada.Grabado
                    gravMN += CDec(i.montokardex)
                    gravME += CDec(i.montokardexUS)

                Case OperacionGravada.Exonerado
                    ExoMN += CDec(i.montokardex)
                    ExoME += CDec(i.montokardexUS)

                Case OperacionGravada.Inafecto
                    InaMN += CDec(i.montokardex)
                    InaME += CDec(i.montokardexUS)
            End Select

            ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next
        ticket.lineasIgual()

        'Resumen de la venta. Sólo son ejemplos
        'ticket.AgregarTotales("         TOTAL.........$", comprobante.ImporteNacional)

        'ticket.AgregarTotales("         EXONERADA...S/.", ExoMN)
        'ticket.AgregarTotales("         INAFECTA....S/.", InaMN)
        'ticket.AgregarTotales("         GRAVADA.....S/.", gravMN)
        'ticket.AgregarTotales("         IGV.........S/.", comprobante.igv01)
        'La M indica que es un decimal en C#
        ticket.AgregarTotales("         TOTAL.......S/.", comprobante.ImporteNacional)
        'ticket.TextoIzquierda("")
        'ticket.AgregarTotales("         EFECTIVO....S/.", comprobante.ImporteNacional)
        'ticket.AgregarTotales("         CAMBIO........$", 0)

        'Texto final del Ticket.
        'ticket.TextoIzquierda("")
        'ticket.TextoIzquierda("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
        ticket.TextoIzquierda("")
        ticket.TextoCentro("¡GRACIAS POR SU COMPRA!")
        ticket.CortaTicket()

        ticket.ImprimirTicket("POS-80C")
        ' ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

    Private Sub GetReiniciarPagos()
        For Each i In dgvCompra.Table.Records
            i.SetValue("MontoSaldo", i.GetValue("totalmn"))
        Next
    End Sub

    Private Sub LimpiarControles()
        dgvCompra.DataSource = New DataTable
        txtTotalBase.DecimalValue = 0
        txtTotalBase2.DecimalValue = 0
        txtTotalBase3.DecimalValue = 0
        txtTotalIva.DecimalValue = 0
        TextTotalDescuentos.DecimalValue = 0
        txtVentaTotal.DecimalValue = 0
        txtTotalPagar.DecimalValue = 0
        DigitalGauge2.Text = "0.00"
        DigitalGauge2.Value = "0.00"
        ' TextCliente.Clear()
        TextComprador.Clear()
        ' TextCliente.Tag = String.Empty
        txtruc.Clear()
        txtTipoDocClie.Clear()
        GetTableGrid()
        ComboComprobante.SelectedIndex = -1
        If ListaBeneficios IsNot Nothing Then
            ListaBeneficios.Clear()
        End If
        ConteoLabelVentas()
        'UbicarClienteGeneral()
        'GridBeneficios.Table.Records.DeleteAll()


    End Sub

    Private Function GetDetallePago(objCaja As documentoCaja, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documentoCajaDetalle)
        Dim listaBeneficio As New List(Of String)
        listaBeneficio.Add("OFERTA")
        listaBeneficio.Add("REGALO")
        Dim montoPago = objCaja.montoSoles
        GetDetallePago = New List(Of documentoCajaDetalle)
        For Each i In ventaDetalle.Where(Function(o) Not listaBeneficio.Contains(o.tipobeneficio)).ToList()
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

                    '.codigoLote = Integer.Parse(i.codigoLote),

                    GetDetallePago.Add(New documentoCajaDetalle With
                                   {
                                   .fecha = Date.Now,
                                   .codigoLote = 0,
                                   .otroMN = 0,
                                   .idItem = i.idItem,
                                   .DetalleItem = i.DetalleItem,
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

    Private Function VerificarItemDuplicadoServicio(cantidad As Decimal, lote As Integer, intIdItem As Integer) As Boolean
        VerificarItemDuplicadoServicio = False
        Dim colIdItem As Integer
        Dim codigoLote As Integer

        colIdItem = intIdItem
        codigoLote = lote
        For Each i In dgvCompra.Table.Records
            If colIdItem = i.GetValue("idProducto") Then
                'CalculosByCantidadExistente(cantidad, i)
                VerificarItemDuplicadoServicio = True
                Exit For
            End If
        Next
    End Function

    Private Sub ListaDetalleCajaGenerico(doc As documentoCaja, detalleVenta As List(Of documentoventaAbarrotesDet))
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i In detalleVenta

            obj = New documentoCajaDetalle
            obj.fecha = Date.Now
            '   obj.codigoLote = Integer.Parse(i.codigoLote)
            obj.idItem = CInt(i.idItem)
            obj.DetalleItem = i.DetalleItem
            obj.montoSoles = FormatNumber(Decimal.Parse(i.importeMN), 2)
            obj.montoUsd = FormatNumber(Decimal.Parse(i.importeME), 2) '
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

    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As Record In dgvCompra.Table.Records
            If i.GetValue("tipobeneficio") <> "OFERTA" Then
                If i.GetValue("tipobeneficio") <> "REGALO" Then
                    obj = New documentoCajaDetalle
                    obj.fecha = Date.Now
                    obj.codigoLote = 0 'Integer.Parse(i.GetValue("codigoLote"))
                    obj.otroMN = 0 'Integer.Parse(i.GetValue("codigoLote"))
                    obj.idItem = CInt(i.GetValue("idProducto"))
                    obj.DetalleItem = i.GetValue("item")
                    'obj.montoSoles = FormatNumber(Decimal.Parse(i.GetValue("totalmn")), 2)
                    'obj.montoUsd = FormatNumber(Decimal.Parse(i.GetValue("totalme")), 2) '
                    obj.montoSoles = FormatNumber(Decimal.Parse(i.GetValue("totalpagar")), 2)
                    obj.montoUsd = Decimal.Parse(i.GetValue("totalpagar")) / TmpTipoCambio
                    obj.diferTipoCambio = TmpTipoCambio
                    obj.tipoCambioTransacc = TmpTipoCambio
                    obj.entregado = "SI"
                    obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                    obj.usuarioModificacion = usuario.IDUsuario
                    obj.documentoAfectado = CInt(Me.Tag)
                    obj.fechaModificacion = DateTime.Now
                    lista.Add(obj)
                End If
            End If
        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Sub ConfiguracionInicio()
        'Me.WindowState = FormWindowState.Maximized
        TotalesXcanbeceras = New TotalesXcanbecera()

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

    'Private Sub ThreadNumeracion()
    '    Dim strIdModulo As String = Nothing
    '    If ComboComprobante.Text = "BOLETA" Then
    '        strIdModulo = "VT2"
    '    ElseIf ComboComprobante.Text = "FACTURA" Then
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
    '        'TabCompra.Enabled = False

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
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

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

        dt.Columns.Add("menor")
        dt.Columns.Add("mayor")
        dt.Columns.Add("gmayor")

        dt.Columns.Add("tipobeneficio")
        dt.Columns.Add("valorbase")
        dt.Columns.Add("valorafecto")
        dt.Columns.Add("totalpagar")
        dgvCompra.DataSource = dt
        dgvCompra.TopLevelGroupOptions.ShowCaption = True
    End Sub

    Public Sub GetCombos()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA

        ListaAlmacenes = New List(Of almacen)
        '     ListaEstadosFinancieros = New List(Of estadosFinancieros)
        '    ListaTipoExistencia = New List(Of tabladetalle)
        'ListaComprobantesCaja = New List(Of tabladetalle)

        '  ListaTipoExistencia = tablaDetalleSA.GetListaTablaDetalle(5, "1")

        ListaAlmacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        '  ListaComprobantesCaja = tablaDetalleSA.GetListaTablaDetalle(10, "1")
        'Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
        'If Not IsNothing(cajaUsuario) Then

        'For Each i As cajaUsuario In cajaUsuarioSA.ResumenTransaccionesXusuarioCajaPago(
        '    New cajaUsuario With {
        '    .idcajaUsuario = GFichaUsuarios.IdCajaUsuario,
        '    .idPersona = usuario.IDUsuario
        '    })
        '    ListaEstadosFinancieros.Add(New estadosFinancieros With {.idestado = i.idEntidad, .descripcion = i.NombreEntidad, .tipo = i.Tipo, .codigo = i.moneda})
        'Next
        'Else
        '    ListaEstadosFinancieros = cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
        'End If

    End Sub

    Public Sub Loadcontroles()
        If ListaAlmacenes.Count > 0 Then
            cboalmacen.ValueMember = "idAlmacen"
            cboalmacen.DisplayMember = "descripcionAlmacen"
            cboalmacen.DataSource = ListaAlmacenes 'almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
        End If



        'ComboComprobantePago.DataSource = ListaComprobantesCaja 'tablaDetalleSA.GetListaTablaDetalle(10, "1")
        'ComboComprobantePago.ValueMember = "codigoDetalle"
        'ComboComprobantePago.DisplayMember = "descripcion"
        'If ListaEstadosFinancieros IsNot Nothing Then
        '    If ListaEstadosFinancieros.Count > 0 Then
        '        cbocajaPago.DataSource = ListaEstadosFinancieros ' cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
        '        cbocajaPago.ValueMember = "idestado"
        '        cbocajaPago.DisplayMember = "descripcion"
        '    End If
        'End If

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
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(item.CustomLote.productoSustentado = True, "Doc.", "Not."))

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
        '  Dim totalNotaMN As Decimal = 0
        Dim totalNotaME As Decimal = 0
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
        Dim descuentos As Decimal = 0
        For Each r As Record In dgvCompra.Table.Records
            descuentos += CDec(r.GetValue("valorafecto"))

            totalpercepMN += CDec(r.GetValue("percepcionMN"))
            totalpercepME += CDec(r.GetValue("percepcionME"))

            totalIVA += CDec(r.GetValue("igvmn"))
            totalIVAme += CDec(r.GetValue("igvme"))

            'total += CDec(r.GetValue("totalmn"))
            'totalme += CDec(r.GetValue("totalme"))
            total += CDec(r.GetValue("totalpagar"))
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

        txtTotalNotaVenta.DecimalValue = 0
        'Select Case cboMoneda.Text
        '    Case "NACIONAL"

        'If total >= CDec(TextBenefClienteBase.Text) Then
        '    descuentos = CDec(TextValorAfecto.Text)
        '    TextTotalDescuentos.DecimalValue = descuentos
        '    total = total - descuentos
        'Else

        'End If

        txtTotalBase3.DecimalValue = totalVC3
        txtTotalBase2.DecimalValue = totalVC2
        txtTotalBase.DecimalValue = totalVC
        txtTotalIva.Text = ((totalIVA))
        txtVentaTotal.DecimalValue = total
        txtTotalPagar.DecimalValue = total
        DigitalGauge2.Text = total.ToString("N2")
        DigitalGauge2.Value = total.ToString("N2")

        TextGravado.DecimalValue = totalVC
        TextExonerada.DecimalValue = totalVC2
        TextInafecta.DecimalValue = totalVC3
        TextIGV.DecimalValue = totalIVA

        TextTotalDescuentos.DecimalValue = descuentos

        '    Case "EXTRANJERA"
        '        txtTotalBase3.DecimalValue = totalVCme3
        '        txtTotalBase2.DecimalValue = totalVCme2
        '        txtTotalBase.DecimalValue = totalVCme
        '        txtTotalIva.Text = ((totalIVAme))

        '        TextGravado.DecimalValue = totalVCme
        '        TextExonerada.DecimalValue = totalVCme2
        '        TextInafecta.DecimalValue = totalVCme3
        '        TextIGV.DecimalValue = totalIVAme

        '        txtVentaTotal.DecimalValue = totalme
        '        txtTotalPagar.DecimalValue = totalme
        '        DigitalGauge2.Text = totalme.ToString("N2")
        '        DigitalGauge2.Value = totalme.ToString("N2")

        '        DigitalGauge1.Text = totalme.ToString("N2")
        '        DigitalGauge1.Value = totalme.ToString("N2")
        'End Select

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
        Dim totalPagar As Decimal = 0
        Dim descuentoItem As Decimal = 0

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
            Select Case strTipoExistencia
                Case "GS"
                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") / colcantidad
                    colPrecUnitme = (Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") / colcantidad) / TmpTipoCambio
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


                    'Select Case tmpConfigInicio.FormatoVenta
                    '    Case "MKT"

                    '                            If RBProforma.Checked = True Then
                    '#Region "Calculos"

                    '                                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    '                                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    '                                colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    '                                colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    '                                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    '                                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    '                                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    '                                colCostoMN = colcantidad * colPrecUnitAlmacen
                    '                                colCostoME = colcantidad * colPrecUnitUSAlmacen

                    '                                Dim valorBeneficio = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("valorbase"))

                    '                                descuentoItem = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("valorafecto"))
                    '                                totalMN = Math.Round(colcantidad * colPrecUnit, 2)

                    '                                If valorBeneficio = 0 Then
                    '                                    descuentoItem = 0
                    '                                Else
                    '                                    If totalMN < valorBeneficio Then
                    '                                        descuentoItem = 0
                    '                                    End If
                    '                                End If

                    '                                totalPagar = totalMN - descuentoItem

                    '                                totalME = Math.Round(colcantidad * colPrecUnitme, 2)

                    '                                If colDestinoGravado = 1 Then
                    '                                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    '                                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    '                                Else
                    '                                    valPercepMN = 0
                    '                                    valPercepME = 0

                    '                                End If

                    '                                '****************************************************************
                    '                                Dim iva As Decimal = TmpIGV / 100

                    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    '                                If colcantidad > 0 Then

                    '                                    colBI = Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2) ' (totalMN / (iva + 1))
                    '                                    colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                    '                                    'Dim iv As Decimal = 0
                    '                                    'Dim iv2 As Decimal = 0
                    '                                    'iv = totalMN / (iva + 1)
                    '                                    'iv2 = totalME / (iva + 1)


                    '                                    Igv = totalMN - colBI ' iv * (iva)
                    '                                    IgvME = totalME - colBIme ' iv2 * (iva)

                    '                                    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    '                                    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    '                                Else
                    '                                    colBI = 0
                    '                                    colBIme = 0
                    '                                    Igv = 0
                    '                                    IgvME = 0
                    '                                End If

                    '                                Select Case colDestinoGravado
                    '                                    Case 1
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", Math.Round(totalPagar, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                    Case 2
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", Math.Round(totalPagar, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                End Select
                    '                                TotalTalesXcolumna()
                    '                                If ListaBeneficios.Count > 0 Then
                    '                                    TotalesColumnaDescuentos(ListaBeneficios)
                    '                                End If
                    '#End Region
                    '                            End If

                    '                            If RBVenta.Checked = True Then
                    '                                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    '                                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    '                                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    '                                    colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    '                                    colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    '                                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    '                                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    '                                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    '                                    colCostoMN = colcantidad * colPrecUnitAlmacen
                    '                                    colCostoME = colcantidad * colPrecUnitUSAlmacen

                    '                                    Dim valorBeneficio = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("valorbase"))

                    '                                    descuentoItem = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("valorafecto"))
                    '                                    totalMN = Math.Round(colcantidad * colPrecUnit, 2)

                    '                                    If valorBeneficio = 0 Then
                    '                                        descuentoItem = 0
                    '                                    Else
                    '                                        If totalMN < valorBeneficio Then
                    '                                            descuentoItem = 0
                    '                                        End If
                    '                                    End If

                    '                                    totalPagar = totalMN - descuentoItem

                    '                                    totalME = Math.Round(colcantidad * colPrecUnitme, 2)

                    '                                    If colDestinoGravado = 1 Then
                    '                                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    '                                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    '                                    Else
                    '                                        valPercepMN = 0
                    '                                        valPercepME = 0

                    '                                    End If

                    '                                    '****************************************************************
                    '                                    Dim iva As Decimal = TmpIGV / 100

                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    '                                    If colcantidad > 0 Then
                    '                                        colBI = Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2) ' (totalMN / (iva + 1))
                    '                                        colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                    '                                        'Dim iv As Decimal = 0
                    '                                        'Dim iv2 As Decimal = 0
                    '                                        'iv = totalMN / (iva + 1)
                    '                                        'iv2 = totalME / (iva + 1)

                    '                                        Igv = totalMN - colBI ' iv * (iva)
                    '                                        IgvME = totalME - colBIme ' iv2 * (iva)

                    '                                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    '                                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    '                                    Else
                    '                                        colBI = 0
                    '                                        colBIme = 0
                    '                                        Igv = 0
                    '                                        IgvME = 0
                    '                                    End If

                    '                                    Select Case colDestinoGravado
                    '                                        Case 1
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", Math.Round(totalPagar, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                        Case 2
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", Math.Round(totalPagar, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                    End Select
                    '                                    TotalTalesXcolumna()
                    '                                    If ListaBeneficios IsNot Nothing Then
                    '                                        If ListaBeneficios.Count > 0 Then
                    '                                            TotalesColumnaDescuentos(ListaBeneficios)
                    '                                        End If
                    '                                    End If
                    '                                Else
                    '                                    dgvCompra.Table.CurrentRecord.EndEdit()
                    '                                    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '                                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                    'Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
                    '                                    'Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                    txtTotalBase.Text = 0.0
                    '                                    txtTotalBase2.Text = 0.0
                    '                                    txtTotalIva.Text = 0.0
                    '                                    TextTotalDescuentos.Text = 0.0
                    '                                    txtTotalPagar.Text = 0.0
                    '                                    PanelError.Visible = True
                    '                                    Timer1.Enabled = True
                    '                                    TiempoEjecutar(10)
                    '                                End If
                    '                            End If

                    '    Case Else
                    Select Case ComboComprobante.Text
                        Case "PROFORMA"
#Region "Calculos"

                            colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                            cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                            colPrecUnitAlmacen = 0 'Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                            colPrecUnitUSAlmacen = 0 'Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                            colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                            colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                            colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                            colCostoMN = colcantidad * colPrecUnitAlmacen
                            colCostoME = colcantidad * colPrecUnitUSAlmacen

                            'totalMN = Math.Round(colcantidad * colPrecUnit, 2)
                            'totalME = Math.Round(colcantidad * colPrecUnitme, 2)

                            Dim valorBeneficio = 0 'CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("valorbase"))

                            descuentoItem = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("valorafecto"))
                            totalMN = Math.Round(colcantidad * colPrecUnit, 2)

                            If valorBeneficio = 0 Then
                                descuentoItem = 0
                            Else
                                If totalMN < valorBeneficio Then
                                    descuentoItem = 0
                                End If
                            End If

                            totalPagar = totalMN - descuentoItem

                            totalME = Math.Round(colcantidad * colPrecUnitme, 2)

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

                                colBI = Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2) ' (totalMN / (iva + 1))
                                colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                                'Dim iv As Decimal = 0
                                'Dim iv2 As Decimal = 0
                                'iv = totalMN / (iva + 1)
                                'iv2 = totalME / (iva + 1)

                                Igv = totalMN - colBI ' iv * (iva)
                                IgvME = totalME - colBIme ' iv2 * (iva)

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
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", Math.Round(totalPagar, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
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
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", Math.Round(totalPagar, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            End Select
                            TotalTalesXcolumna()
                            If ListaBeneficios IsNot Nothing Then
                                If ListaBeneficios.Count > 0 Then
                                    'TotalesColumnaDescuentos(ListaBeneficios)
                                End If
                            End If
#End Region
                        Case Else
                            If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                                colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                                colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                                colCostoMN = colcantidad * colPrecUnitAlmacen
                                colCostoME = colcantidad * colPrecUnitUSAlmacen

                                'totalMN = Math.Round(colcantidad * colPrecUnit, 2)

                                Dim valorBeneficio = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("valorbase"))

                                descuentoItem = CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("valorafecto"))
                                totalMN = Math.Round(colcantidad * colPrecUnit, 2)

                                If valorBeneficio = 0 Then
                                    descuentoItem = 0
                                Else
                                    If totalMN < valorBeneficio Then
                                        descuentoItem = 0
                                    End If
                                End If

                                totalPagar = totalMN - descuentoItem

                                totalME = Math.Round(colcantidad * colPrecUnitme, 2)

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

                                    colBI = Math.Round(CDec(CalculoBaseImponible(totalPagar, iva + 1)), 2) ' (totalMN / (iva + 1))
                                    colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                                    Igv = totalPagar - colBI ' iv * (iva)
                                    IgvME = totalME - colBIme ' iv2 * (iva)

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
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", Math.Round(totalPagar, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
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
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", Math.Round(totalPagar, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                                End Select
                                TotalTalesXcolumna()
                                If ListaBeneficios IsNot Nothing Then
                                    If ListaBeneficios.Count > 0 Then
                                        '    TotalesColumnaDescuentos(ListaBeneficios)
                                    End If
                                End If

                            Else
                                dgvCompra.Table.CurrentRecord.EndEdit()
                                'lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalpagar", Math.Round(totalPagar, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalPagar, 2))
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
                                TextTotalDescuentos.Text = 0.0
                                txtTotalPagar.Text = 0.0
                            End If
                    End Select
                    '  End Select
            End Select
        End If
    End Sub

    Sub CalculosAPartirDeImporte()
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

                    'Select Case tmpConfigInicio.FormatoVenta
                    '    Case "MKT"

                    '                            If RBProforma.Checked = True Then
                    '#Region "Calculos"

                    '                                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    '                                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    '                                colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    '                                colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    '                                totalMN = Math.Round(Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn"), 2)
                    '                                totalME = Math.Round(Me.dgvCompra.Table.CurrentRecord.GetValue("totalme"), 2)

                    '                                colPrecUnit = Math.Round(totalMN / colcantidad, 2)
                    '                                colPrecUnitme = Math.Round(totalME / colcantidad, 2)

                    '                                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    '                                colCostoMN = colcantidad * colPrecUnitAlmacen
                    '                                colCostoME = colcantidad * colPrecUnitUSAlmacen

                    '                                If colDestinoGravado = 1 Then
                    '                                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    '                                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    '                                Else
                    '                                    valPercepMN = 0
                    '                                    valPercepME = 0

                    '                                End If

                    '                                '****************************************************************
                    '                                Dim iva As Decimal = TmpIGV / 100

                    '                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    '                                If colcantidad > 0 Then

                    '                                    colBI = Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2) ' (totalMN / (iva + 1))
                    '                                    colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                    '                                    'Dim iv As Decimal = 0
                    '                                    'Dim iv2 As Decimal = 0
                    '                                    'iv = totalMN / (iva + 1)
                    '                                    'iv2 = totalME / (iva + 1)


                    '                                    Igv = totalMN - colBI ' iv * (iva)
                    '                                    IgvME = totalME - colBIme ' iv2 * (iva)

                    '                                    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    '                                    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    '                                Else
                    '                                    colBI = 0
                    '                                    colBIme = 0
                    '                                    Igv = 0
                    '                                    IgvME = 0
                    '                                End If

                    '                                Select Case colDestinoGravado
                    '                                    Case 1
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                    Case 2
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                End Select
                    '                                TotalTalesXcolumna()
                    '                                If ListaBeneficios.Count > 0 Then
                    '                                    TotalesColumnaDescuentos(ListaBeneficios)
                    '                                End If
                    '#End Region
                    '                            End If

                    '  If RBVenta.Checked = True Then
                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                        colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                        colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                        totalMN = Math.Round(Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn"), 2)
                        totalME = Math.Round(Me.dgvCompra.Table.CurrentRecord.GetValue("totalme"), 2)

                        colPrecUnit = Math.Round(totalMN / colcantidad, 2)
                        colPrecUnitme = Math.Round(totalME / colcantidad, 2)

                        colCostoMN = colcantidad * colPrecUnitAlmacen
                        colCostoME = colcantidad * colPrecUnitUSAlmacen

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
                            colBI = Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2) ' (totalMN / (iva + 1))
                            colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                            'Dim iv As Decimal = 0
                            'Dim iv2 As Decimal = 0
                            'iv = totalMN / (iva + 1)
                            'iv2 = totalME / (iva + 1)

                            Igv = totalMN - colBI ' iv * (iva)
                            IgvME = totalME - colBIme ' iv2 * (iva)

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
                        If ListaBeneficios.Count > 0 Then
                            'TotalesColumnaDescuentos(ListaBeneficios)
                        End If
                    Else
                        dgvCompra.Table.CurrentRecord.EndEdit()
                        '  lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        txtTotalBase.Text = 0.0
                        txtTotalBase2.Text = 0.0
                        txtTotalIva.Text = 0.0
                        TextTotalDescuentos.Text = 0.0
                        txtTotalPagar.Text = 0.0

                    End If
                    '   End If

                    '   Case Else
                    '                            Select Case ComboComprobante.Text
                    '                                Case "PROFORMA"
                    '#Region "Calculos"

                    '                                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    '                                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    '                                    colPrecUnitAlmacen = 0 'Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    '                                    colPrecUnitUSAlmacen = 0 'Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    '                                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    '                                    totalMN = Math.Round(Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn"), 2)
                    '                                    totalME = Math.Round(Me.dgvCompra.Table.CurrentRecord.GetValue("totalme"), 2)

                    '                                    colPrecUnit = Math.Round(totalMN / colcantidad, 2)
                    '                                    colPrecUnitme = Math.Round(totalME / colcantidad, 2)

                    '                                    colCostoMN = colcantidad * colPrecUnitAlmacen
                    '                                    colCostoME = colcantidad * colPrecUnitUSAlmacen

                    '                                    If colDestinoGravado = 1 Then
                    '                                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    '                                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    '                                    Else
                    '                                        valPercepMN = 0
                    '                                        valPercepME = 0

                    '                                    End If

                    '                                    '****************************************************************
                    '                                    Dim iva As Decimal = TmpIGV / 100

                    '                                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    '                                    If colcantidad > 0 Then

                    '                                        colBI = Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2) ' (totalMN / (iva + 1))
                    '                                        colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                    '                                        'Dim iv As Decimal = 0
                    '                                        'Dim iv2 As Decimal = 0
                    '                                        'iv = totalMN / (iva + 1)
                    '                                        'iv2 = totalME / (iva + 1)

                    '                                        Igv = totalMN - colBI ' iv * (iva)
                    '                                        IgvME = totalME - colBIme ' iv2 * (iva)

                    '                                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    '                                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    '                                    Else
                    '                                        colBI = 0
                    '                                        colBIme = 0
                    '                                        Igv = 0
                    '                                        IgvME = 0
                    '                                    End If

                    '                                    Select Case colDestinoGravado
                    '                                        Case 1
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                        Case 2
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                    End Select
                    '                                    TotalTalesXcolumna()
                    '                                    If ListaBeneficios.Count > 0 Then
                    '                                        TotalesColumnaDescuentos(ListaBeneficios)
                    '                                    End If
                    '#End Region
                    '                                Case Else
                    '                                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    '                                        colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    '                                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    '                                        colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    '                                        colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    '                                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    '                                        totalMN = Math.Round(Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn"), 2)
                    '                                        totalME = Math.Round(Me.dgvCompra.Table.CurrentRecord.GetValue("totalme"), 2)

                    '                                        colPrecUnit = Math.Round(totalMN / colcantidad, 2)
                    '                                        colPrecUnitme = Math.Round(totalME / colcantidad, 2)

                    '                                        colCostoMN = colcantidad * colPrecUnitAlmacen
                    '                                        colCostoME = colcantidad * colPrecUnitUSAlmacen

                    '                                        If colDestinoGravado = 1 Then
                    '                                            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    '                                            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    '                                        Else
                    '                                            valPercepMN = 0
                    '                                            valPercepME = 0

                    '                                        End If

                    '                                        '****************************************************************
                    '                                        Dim iva As Decimal = TmpIGV / 100

                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    '                                        If colcantidad > 0 Then

                    '                                            colBI = Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2) ' (totalMN / (iva + 1))
                    '                                            colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                    '                                            'Dim iv As Decimal = 0
                    '                                            'Dim iv2 As Decimal = 0
                    '                                            'iv = totalMN / (iva + 1)
                    '                                            'iv2 = totalME / (iva + 1)

                    '                                            Igv = totalMN - colBI ' iv * (iva)
                    '                                            IgvME = totalME - colBIme ' iv2 * (iva)

                    '                                            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    '                                            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    '                                        Else
                    '                                            colBI = 0
                    '                                            colBIme = 0
                    '                                            Igv = 0
                    '                                            IgvME = 0
                    '                                        End If

                    '                                        Select Case colDestinoGravado
                    '                                            Case 1
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                            Case 2
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                        End Select
                    '                                        TotalTalesXcolumna()
                    '                                        If ListaBeneficios.Count > 0 Then
                    '                                            TotalesColumnaDescuentos(ListaBeneficios)
                    '                                        End If
                    '                                    Else
                    '                                        dgvCompra.Table.CurrentRecord.EndEdit()
                    '                                        lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '                                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '                                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '                                        txtTotalBase.Text = 0.0
                    '                                        txtTotalBase2.Text = 0.0
                    '                                        txtTotalIva.Text = 0.0
                    '                                        TextTotalDescuentos.Text = 0.0
                    '                                        txtTotalPagar.Text = 0.0
                    '                                        PanelError.Visible = True
                    '                                        Timer1.Enabled = True
                    '                                        TiempoEjecutar(10)
                    '                                    End If
                    '                            End Select
                    '  End Select
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
                    If ListaBeneficios.Count > 0 Then
                        'TotalesColumnaDescuentos(ListaBeneficios)
                    End If
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
                        If ListaBeneficios.Count > 0 Then
                            '           TotalesColumnaDescuentos(ListaBeneficios)
                        End If
                    Else
                        dgvCompra.Table.CurrentRecord.EndEdit()
                        '        lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
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
                        TextTotalDescuentos.Text = 0.0
                        txtTotalPagar.Text = 0.0

                    End If
            End Select
        End If
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
                If ListaBeneficios.Count > 0 Then
                    'TotalesColumnaDescuentos(ListaBeneficios)
                End If
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
                    If ListaBeneficios.Count > 0 Then
                        ' TotalesColumnaDescuentos(ListaBeneficios)
                    End If
                Else
                    dgvCompra.Table.CurrentRecord.EndEdit()
                    '  lblEstado.Text = "La cantidad disponible es: " & recordAlive.GetValue("canDisponible")
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
                    TextTotalDescuentos.Text = 0.0
                    txtTotalPagar.Text = 0.0
                End If
        End Select

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

    Sub ConteoLabelVentas()
        lblConteo.Text = "Artículos en Canasta: " & dgvCompra.Table.Records.Count
    End Sub

    Private Sub LimpiarProductosIguales(idItem As Integer)
        For Each r As Record In dgvCompra.Table.Records
            If Integer.Parse(r.GetValue("idProducto")) = idItem Then
                r.Delete()
            End If
        Next
    End Sub
#End Region

#Region "Events"

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
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


    Private Function sumColumnByName(Column As String, sustentado As String) As Decimal
        Dim suma As Decimal = 0
        For Each i In dgvCompra.Table.Records
            If i.GetValue("marca") = sustentado Then
                Dim valNumber = i.GetValue(Column).ToString
                If valNumber.Trim.Length > 0 Then
                    suma += CDec(i.GetValue(Column))
                End If
            End If
        Next
        Return suma
    End Function

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
                        e.Style.[ReadOnly] = False 'True
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

            '    If tmpConfigInicio.FormatoVenta = "MKT" Then

            'If RBVenta.Checked = True Then
            '    If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
            '        Dim el As Element = e.Style.TableCellIdentity.DisplayElement
            '        If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
            '            Dim r As Record = el.GetRecord()
            '            If r Is Nothing Then Return
            '            Dim cant As Decimal? = r.GetValue("cantidad")
            '            Dim cantDis As Decimal? = r.GetValue("canDisponible")

            '            If (r.GetValue("tipoExistencia") <> TipoExistencia.ServicioGasto) Then
            '                If cant > cantDis Then
            '                    'e.Style.Enabled = False
            '                    e.Style.CellValue = 0
            '                End If
            '            End If
            '            'If cant > cantDis Then
            '            '    'e.Style.Enabled = False
            '            '    e.Style.CellValue = 0
            '            'End If
            '        End If
            '    ElseIf e.TableCellIdentity.Column.MappingName = "pumn" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
            '        Dim el As Element = e.Style.TableCellIdentity.DisplayElement
            '        If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
            '            Dim r As Record = el.GetRecord()
            '            If r Is Nothing Then Return
            '            If (r.GetValue("tipoExistencia") <> TipoExistencia.ServicioGasto) Then
            '                If r.GetValue("chPago") = True Then

            '                Else
            '                    Dim PrecioVenta As Decimal? = r.GetValue("pumn")
            '                    Dim PrecioMenor = r.GetValue("menor")
            '                    Dim PrecioMayor = r.GetValue("mayor")
            '                    Dim PrecioGranMayor = r.GetValue("gmayor")

            '                    Dim lista As New List(Of Decimal)
            '                    If PrecioMenor > 0.00001 Then
            '                        lista.Add(PrecioMenor)
            '                    End If
            '                    If PrecioMayor > 0.00001 Then
            '                        lista.Add(PrecioMayor)
            '                    End If
            '                    If PrecioGranMayor > 0.00001 Then
            '                        lista.Add(PrecioGranMayor)
            '                    End If

            '                    Dim minimo = lista.Min()
            '                    Dim maximo = lista.Max()

            '                    If IsNumeric(minimo) AndAlso IsNumeric(maximo) Then
            '                        If PrecioVenta < minimo Then
            '                            e.Style.CellValue = minimo
            '                        Else

            '                        End If
            '                    End If
            '                End If

            '            End If

            '            'If IsNumeric(PrecioMenor) AndAlso IsNumeric(PrecioGranMayor) Then
            '            '        If PrecioVenta >= PrecioGranMayor And PrecioVenta <= PrecioMenor Then

            '            '        Else
            '            '            e.Style.CellValue = PrecioVenta
            '            '        End If
            '            '    End If
            '            'End If
            '        End If
            '    ElseIf e.TableCellIdentity.Column.MappingName = "pume" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
            '        Dim el As Element = e.Style.TableCellIdentity.DisplayElement
            '        If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
            '            Dim r As Record = el.GetRecord()
            '            If r Is Nothing Then Return

            '            If (r.GetValue("tipoExistencia") <> TipoExistencia.ServicioGasto) Then
            '                If r.GetValue("chPago") = True Then

            '                Else
            '                    Dim PrecioVenta As Decimal? = r.GetValue("pume")
            '                    Dim PrecioMenor = r.GetValue("menor")
            '                    Dim PrecioMayor = r.GetValue("mayor")
            '                    Dim PrecioGranMayor = r.GetValue("gmayor")

            '                    Dim lista As New List(Of Decimal)
            '                    If PrecioMenor > 0.00001 Then
            '                        lista.Add(PrecioMenor)
            '                    End If
            '                    If PrecioMayor > 0.00001 Then
            '                        lista.Add(PrecioMayor)
            '                    End If
            '                    If PrecioGranMayor > 0.00001 Then
            '                        lista.Add(PrecioGranMayor)
            '                    End If

            '                    Dim minimo = lista.Min()
            '                    Dim maximo = lista.Max()

            '                    If IsNumeric(minimo) AndAlso IsNumeric(maximo) Then
            '                        If PrecioVenta < minimo Then
            '                            e.Style.CellValue = minimo
            '                        Else

            '                        End If
            '                    End If
            '                End If
            '            End If

            '            'If IsNumeric(PrecioMenor) AndAlso IsNumeric(PrecioGranMayor) Then
            '            '        If PrecioVenta >= PrecioGranMayor And PrecioVenta <= PrecioMenor Then

            '            '        Else
            '            '            e.Style.CellValue = PrecioVenta
            '            '        End If
            '            '    End If
            '            'End If
            '        End If
            '    End If
            'End If

            ' Else ' venta normal
            Select Case ComboComprobante.Text
                Case "PROFORMA"

                Case Else
                    If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                        Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                        If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                            Dim r As Record = el.GetRecord()
                            If r Is Nothing Then Return
                            Dim cant As Decimal? = r.GetValue("cantidad")
                            Dim cantDis As Decimal? = r.GetValue("canDisponible")

                            If (r.GetValue("tipoExitencia") <> TipoExistencia.ServicioGasto) Then
                                If cant > cantDis Then
                                    'e.Style.Enabled = False
                                    e.Style.CellValue = 0
                                End If
                            End If

                            'If cant > cantDis Then
                            '    'e.Style.Enabled = False
                            '    e.Style.CellValue = 0
                            'End If
                        End If
                    ElseIf e.TableCellIdentity.Column.MappingName = "pumn" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                        Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                        If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                            Dim r As Record = el.GetRecord()
                            If r Is Nothing Then Return

                            If (r.GetValue("tipoExitencia") <> TipoExistencia.ServicioGasto) Then
                                If r.GetValue("chPago") = True Then

                                Else
                                    Dim PrecioVenta As Decimal? = r.GetValue("pumn")
                                    Dim PrecioMenor = r.GetValue("menor")
                                    Dim PrecioMayor = r.GetValue("mayor")
                                    Dim PrecioGranMayor = r.GetValue("gmayor")

                                    Dim lista As New List(Of Decimal)
                                    If PrecioMenor > 0.00001 Then
                                        lista.Add(PrecioMenor)
                                    End If
                                    If PrecioMayor > 0.00001 Then
                                        lista.Add(PrecioMayor)
                                    End If
                                    If PrecioGranMayor > 0.00001 Then
                                        lista.Add(PrecioGranMayor)
                                    End If

                                    Dim minimo = lista.Min()
                                    Dim maximo = lista.Max()

                                    If IsNumeric(minimo) AndAlso IsNumeric(maximo) Then
                                        If PrecioVenta < minimo Then
                                            e.Style.CellValue = minimo
                                        Else

                                        End If
                                    End If
                                End If
                            End If

                            'If IsNumeric(PrecioMenor) AndAlso IsNumeric(PrecioGranMayor) Then
                            '        If PrecioVenta >= PrecioGranMayor And PrecioVenta <= PrecioMenor Then

                            '        Else
                            '            e.Style.CellValue = PrecioVenta
                            '        End If
                            '    End If
                            'End If
                        End If
                    ElseIf e.TableCellIdentity.Column.MappingName = "pume" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                        Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                        If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                            Dim r As Record = el.GetRecord()
                            If r Is Nothing Then Return

                            If (r.GetValue("tipoExitencia") <> TipoExistencia.ServicioGasto) Then
                                If r.GetValue("chPago") = True Then

                                Else
                                    Dim PrecioVenta As Decimal? = r.GetValue("pume")
                                    Dim PrecioMenor = r.GetValue("menor")
                                    Dim PrecioMayor = r.GetValue("mayor")
                                    Dim PrecioGranMayor = r.GetValue("gmayor")

                                    Dim lista As New List(Of Decimal)
                                    If PrecioMenor > 0.00001 Then
                                        lista.Add(PrecioMenor)
                                    End If
                                    If PrecioMayor > 0.00001 Then
                                        lista.Add(PrecioMayor)
                                    End If
                                    If PrecioGranMayor > 0.00001 Then
                                        lista.Add(PrecioGranMayor)
                                    End If

                                    Dim minimo = lista.Min()
                                    Dim maximo = lista.Max()

                                    If IsNumeric(minimo) AndAlso IsNumeric(maximo) Then
                                        If PrecioVenta < minimo Then
                                            e.Style.CellValue = minimo
                                        Else

                                        End If
                                    End If
                                End If
                            End If

                            'If IsNumeric(PrecioMenor) AndAlso IsNumeric(PrecioGranMayor) Then
                            '        If PrecioVenta >= PrecioGranMayor And PrecioVenta <= PrecioMenor Then

                            '        Else
                            '            e.Style.CellValue = PrecioVenta
                            '        End If
                            '    End If
                            'End If
                        End If
                    End If
            End Select
            '    End If


        End If
        'Select Case e.TableCellIdentity.TableCellType
        '    Case GridTableCellType.SummaryFieldCell
        '        If e.TableCellIdentity.SummaryColumn.Name = "totalDocMN" Then
        '            Dim sumaTotalDoc As Decimal = sumColumnByName("totalmn", "Doc.")
        '            e.Style.CellValue = sumaTotalDoc
        '        End If

        '        If e.TableCellIdentity.SummaryColumn.Name = "totalNotaMN" Then
        '            Dim sumaTotalNota As Decimal = sumColumnByName("totalmn", "Not.")
        '            e.Style.CellValue = sumaTotalNota
        '        End If

        '        Exit Select
        'End Select
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        'Select Case Int32.Parse(r.GetValue("cboprecio"))
                        '    Case 0
                        '        'Dim f As New frmPreciosByArticulos(r)
                        '        'f.StartPosition = FormStartPosition.CenterParent
                        '        'f.ShowDialog()

                        '    Case Else
                        '        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                        '        If Not IsNothing(precio) Then
                        '            r.SetValue("pumn", precio.precioMN)
                        '            r.SetValue("pume", precio.precioME)
                        '            Calculos()
                        '        Else
                        '            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '            r.SetValue("pumn", 0)
                        '            r.SetValue("pume", 0)
                        '            Calculos()
                        '        End If
                        'End Select

                    Else

                    End If

                Case 9 'precio unitario

                    'Dim r As Record = dgvCompra.Table.CurrentRecord
                    'Dim text As String = cc.Renderer.ControlText
                    'If r.GetValue("chPago") = True Then
                    '    Calculos()
                    'Else
                    '    Dim valuePrecioVenta As Decimal = Convert.ToDecimal(text)
                    '    cc.Renderer.ControlValue = valuePrecioVenta

                    '    Dim menor = r.GetValue("menor")
                    '    Dim mayor = r.GetValue("mayor")
                    '    Dim gmayor = r.GetValue("gmayor")


                    '    Dim lista As New List(Of Decimal)
                    '    If menor > 0.00001 Then
                    '        lista.Add(menor)
                    '    End If
                    '    If mayor > 0.00001 Then
                    '        lista.Add(mayor)
                    '    End If
                    '    If gmayor > 0.00001 Then
                    '        lista.Add(gmayor)
                    '    End If

                    '    Dim minimo = lista.Min()
                    '    Dim maximo = lista.Max()

                    '    If valuePrecioVenta < minimo Then
                    '        cc.Renderer.ControlValue = menor
                    '        cc.ConfirmChanges()
                    '        cc.EndEdit()
                    '        Calculos()
                    '        r.SetValue("tipoPrecio", "0")
                    '        Exit Sub
                    '    Else
                    '        If valuePrecioVenta = menor Then
                    '            r.SetValue("tipoPrecio", "1")
                    '        ElseIf valuePrecioVenta = mayor Then
                    '            r.SetValue("tipoPrecio", "2")
                    '        ElseIf valuePrecioVenta = gmayor Then
                    '            r.SetValue("tipoPrecio", "3")
                    '        Else
                    '            r.SetValue("tipoPrecio", "0")
                    '        End If
                    '        Calculos()
                    '    End If
                    'End If

                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim text As String = cc.Renderer.ControlText
                    If (r.GetValue("tipoExistencia") <> TipoExistencia.ServicioGasto) Then

                        If r.GetValue("chPago") = True Then
                            Calculos()
                        Else
                            Dim valuePrecioVenta As Decimal = Convert.ToDecimal(text)
                            cc.Renderer.ControlValue = valuePrecioVenta

                            Dim menor = r.GetValue("menor")
                            Dim mayor = r.GetValue("mayor")
                            Dim gmayor = r.GetValue("gmayor")


                            Dim lista As New List(Of Decimal)
                            If menor > 0.00001 Then
                                lista.Add(menor)
                            End If
                            If mayor > 0.00001 Then
                                lista.Add(mayor)
                            End If
                            If gmayor > 0.00001 Then
                                lista.Add(gmayor)
                            End If

                            Dim minimo = lista.Min()
                            Dim maximo = lista.Max()

                            If valuePrecioVenta < minimo Then
                                cc.Renderer.ControlValue = menor
                                cc.ConfirmChanges()
                                cc.EndEdit()
                                Calculos()
                                r.SetValue("tipoPrecio", "0")
                                Exit Sub
                            Else
                                If valuePrecioVenta = menor Then
                                    r.SetValue("tipoPrecio", "1")
                                ElseIf valuePrecioVenta = mayor Then
                                    r.SetValue("tipoPrecio", "2")
                                ElseIf valuePrecioVenta = gmayor Then
                                    r.SetValue("tipoPrecio", "3")
                                Else
                                    r.SetValue("tipoPrecio", "0")
                                End If
                                Calculos()
                            End If
                        End If
                    Else
                        r.SetValue("totalmn", r.GetValue("cantidad") * r.GetValue("pumn"))
                        r.SetValue("totalme", r.GetValue("cantidad") * r.GetValue("pume"))
                        Calculos()
                    End If

                    ' If text.Trim.Length > 0 Then


                    'If valuePrecioVenta > gmayor And valuePrecioVenta > menor Then
                    '    cc.Renderer.ControlValue = menor
                    '    cc.ConfirmChanges()
                    '    cc.EndEdit()
                    '    Calculos()
                    '    Exit Sub
                    'ElseIf valuePrecioVenta > menor Then
                    '    cc.Renderer.ControlValue = menor
                    '    cc.ConfirmChanges()
                    '    cc.EndEdit()
                    '    Calculos()
                    '    Exit Sub
                    'ElseIf valuePrecioVenta < gmayor Then
                    '    cc.Renderer.ControlValue = menor
                    '    cc.ConfirmChanges()
                    '    cc.EndEdit()
                    '    Calculos()
                    '    Exit Sub
                    'Else
                    '    Calculos()
                    'End If

                    '   End If

                Case 12
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim text As String = cc.Renderer.ControlText
                    If r.GetValue("tipoExistencia") = TipoExistencia.ServicioGasto Then
                        'Dim total = r.GetValue("totalmn")
                        'Dim cantidad = r.GetValue("cantidad")

                        'r.SetValue("pumn", CDec(total / cantidad))
                        Calculos()
                    End If

                Case 14
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim text As String = cc.Renderer.ControlText
                    If r.GetValue("chPago") = True Then
                        Calculos()
                    Else
                        Dim valuePrecioVenta As Decimal = Convert.ToDecimal(text)
                        cc.Renderer.ControlValue = valuePrecioVenta

                        Dim menor = r.GetValue("menor")
                        Dim mayor = r.GetValue("mayor")
                        Dim gmayor = r.GetValue("gmayor")


                        Dim lista As New List(Of Decimal)
                        If menor > 0.00001 Then
                            lista.Add(menor)
                        End If
                        If mayor > 0.00001 Then
                            lista.Add(mayor)
                        End If
                        If gmayor > 0.00001 Then
                            lista.Add(gmayor)
                        End If

                        Dim minimo = lista.Min()
                        Dim maximo = lista.Max()

                        If valuePrecioVenta < minimo Then
                            cc.Renderer.ControlValue = menor
                            cc.ConfirmChanges()
                            cc.EndEdit()
                            Calculos()
                            r.SetValue("tipoPrecio", "0")
                            Exit Sub
                        Else
                            If valuePrecioVenta = menor Then
                                r.SetValue("tipoPrecio", "1")
                            ElseIf valuePrecioVenta = mayor Then
                                r.SetValue("tipoPrecio", "2")
                            ElseIf valuePrecioVenta = gmayor Then
                                r.SetValue("tipoPrecio", "3")
                            Else
                                r.SetValue("tipoPrecio", "0")
                            End If
                            Calculos()
                        End If
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
                'FormInventarioCanastaTotales = New FormInventarioCanastaTotales(cboalmacen.SelectedValue, nomproduct)
                'FormInventarioCanastaTotales.validaStocks = True
                'FormInventarioCanastaTotales.StartPosition = FormStartPosition.CenterScreen
                'FormInventarioCanastaTotales.Show(Me)
            End If

        End If
        If dgvCompra.Table.Records.Count > 0 Then
            GetUbicarPrecio(dgvCompra.Table.CurrentRecord)
        End If
    End Sub

    Private Sub GetUbicarPrecio()
        Dim precioSA As New detalleitemsSA
        Dim r As Record = dgvCompra.Table.CurrentRecord
        TextArticuloLeft.Text = r.GetValue("item")
        Dim precio = precioSA.GetPrecioPorProducto(Gempresas.IdEmpresaRuc, r.GetValue("idProducto"))
        If precio.Count > 0 Then
            For Each i In precio
                TextMenorLeft.DecimalValue = i.precioMenor.GetValueOrDefault
                TextMayorLeft.DecimalValue = i.precioMayor.GetValueOrDefault
                TextGMayorLeft.DecimalValue = i.precioGranMayor.GetValueOrDefault
                If i.CustomDetalleCompra IsNot Nothing Then
                    If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                        If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                            Select Case i.CustomDetalleCompra.destino
                                Case 1
                                    Dim precioTotalConIva =
                           i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                    Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                    '    dr(13) = precioTotalSinIva
                                    '   TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
                                    '    TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                                Case Else

                                    Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                    '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                    '  dr(13) = precioTotalConIva
                                    '  TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
                                    '   TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            End Select

                        Else

                            Select Case i.CustomDetalleCompra.destino
                                Case 1
                                    Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                    Dim iva = precioTotalConIva2 * 0.18
                                    precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                    Dim precioTotalConIva =
                           i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                    '     TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
                                    '   dr(14) = precioTotalConIva2 '0 'precioTotalConIva
                                    '   TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                                Case Else

                                    Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                    '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                    'TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
                                    'dr(14) = 0 'precioTotalConIva
                                    '  TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            End Select

                        End If

                    End If
                End If
            Next

        End If

    End Sub

    Private Sub GetUbicarPrecio(r As Record)
        Dim precioSA As New detalleitemsSA
        TextArticuloLeft.Text = r.GetValue("item")
        Dim precioMenor = r.GetValue("menor")
        Dim precioMayor = r.GetValue("mayor")
        Dim precioGmayor = r.GetValue("gmayor")

        If r IsNot Nothing Then
            If precioMenor.ToString.Trim.Length > 0 Then
                TextMenorLeft.DecimalValue = r.GetValue("menor")
            End If
            If precioMayor.ToString.Trim.Length > 0 Then
                TextMayorLeft.DecimalValue = r.GetValue("mayor")
            End If
            If precioGmayor.ToString.Trim.Length > 0 Then
                TextGMayorLeft.DecimalValue = r.GetValue("gmayor")
            End If
        Else
            TextMenorLeft.DecimalValue = String.Empty
            TextMayorLeft.DecimalValue = String.Empty
            TextGMayorLeft.DecimalValue = String.Empty
        End If




        '   Dim precio = precioSA.GetPrecioPorProducto(Gempresas.IdEmpresaRuc, r.GetValue("idProducto"))
        'If precio.Count > 0 Then
        '    For Each i In precio
        '        TextMenor.DecimalValue = i.precioMenor.GetValueOrDefault
        '        TextMayor.DecimalValue = i.precioMayor.GetValueOrDefault
        '        TextGMayor.DecimalValue = i.precioGranMayor.GetValueOrDefault
        '        If i.CustomDetalleCompra IsNot Nothing Then
        '            If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

        '                If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
        '                    Select Case i.CustomDetalleCompra.destino
        '                        Case 1
        '                            Dim precioTotalConIva =
        '                   i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

        '                            Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

        '                            '    dr(13) = precioTotalSinIva
        '                            '     TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
        '                            '   TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
        '                        Case Else

        '                            Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
        '                            '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

        '                            '  dr(13) = precioTotalConIva
        '                            '   TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
        '                            '     TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
        '                    End Select

        '                Else

        '                    Select Case i.CustomDetalleCompra.destino
        '                        Case 1
        '                            Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

        '                            Dim iva = precioTotalConIva2 * 0.18
        '                            precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

        '                            Dim precioTotalConIva =
        '                   i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

        '                            ' TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
        '                            '   dr(14) = precioTotalConIva2 '0 'precioTotalConIva
        '                            ' TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
        '                        Case Else

        '                            Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
        '                            '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

        '                            ' TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
        '                            'dr(14) = 0 'precioTotalConIva
        '                            ' TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
        '                    End Select

        '                End If

        '            End If
        '        End If
        '    Next

        'End If

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
        Try
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

                        'Select Case tmpConfigInicio.FormatoVenta
                        '    Case "MKT"

                        '        If RBProforma.Checked = True Then
                        '            Dim r As Record = dgvCompra.Table.CurrentRecord
                        '            Dim text As String = cc.Renderer.ControlText
                        '            If text.Trim.Length > 0 Then
                        '                Dim value As Decimal = Convert.ToDecimal(text)
                        '                cc.Renderer.ControlValue = value
                        '                Calculos()
                        '            End If
                        '        End If

                        '        If RBVenta.Checked = True Then
                        '            Dim r As Record = dgvCompra.Table.CurrentRecord
                        '            Dim text As String = cc.Renderer.ControlText
                        '            If text.Trim.Length > 0 Then
                        '                Dim value As Decimal = Convert.ToDecimal(text)
                        '                cc.Renderer.ControlValue = value

                        '                'Dim cantiDisponible = r.GetValue("canDisponible")
                        '                'If value > cantiDisponible Then
                        '                '    cc.Renderer.ControlValue = 0
                        '                '    cc.ConfirmChanges()
                        '                '    cc.EndEdit()
                        '                '    Calculos()
                        '                '    lblEstado.Text = "La cantidad disponible es: " & cantiDisponible
                        '                '    PanelError.Visible = True
                        '                '    Timer1.Enabled = True
                        '                '    TiempoEjecutar(10)
                        '                '    Exit Sub
                        '                'Else
                        '                '    Calculos()
                        '                'End If

                        '                If (r.GetValue("tipoExistencia") <> TipoExistencia.ServicioGasto) Then
                        '                    Dim cantiDisponible = r.GetValue("canDisponible")
                        '                    If value > cantiDisponible Then
                        '                        cc.Renderer.ControlValue = 0
                        '                        cc.ConfirmChanges()
                        '                        cc.EndEdit()
                        '                        Calculos()
                        '                        lblEstado.Text = "La cantidad disponible es: " & cantiDisponible
                        '                        PanelError.Visible = True
                        '                        Timer1.Enabled = True
                        '                        TiempoEjecutar(10)
                        '                        Exit Sub
                        '                    Else
                        '                        Calculos()
                        '                    End If
                        '                Else
                        '                    Calculos()
                        '                End If

                        '            End If
                        '        End If

                        '    Case Else
                        Select Case ComboComprobante.Text
                            Case "PROFORMA"
                                Dim r As Record = dgvCompra.Table.CurrentRecord
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim value As Decimal = Convert.ToDecimal(text)
                                    cc.Renderer.ControlValue = value
                                    Calculos()
                                End If


                            Case Else
                                Dim r As Record = dgvCompra.Table.CurrentRecord
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim value As Decimal = Convert.ToDecimal(text)
                                    cc.Renderer.ControlValue = value

                                    If (r.GetValue("tipoExistencia") <> TipoExistencia.ServicioGasto) Then
                                        Dim cantiDisponible = r.GetValue("canDisponible")
                                        If value > cantiDisponible Then
                                            cc.Renderer.ControlValue = 0
                                            cc.ConfirmChanges()
                                            cc.EndEdit()
                                            Calculos()

                                            Exit Sub
                                        Else
                                            Calculos()
                                        End If
                                    Else
                                        Calculos()
                                    End If

                                    'Dim cantiDisponible = r.GetValue("canDisponible")
                                    'If value > cantiDisponible Then
                                    '    cc.Renderer.ControlValue = 0
                                    '    cc.ConfirmChanges()
                                    '    cc.EndEdit()
                                    '    Calculos()
                                    '    lblEstado.Text = "La cantidad disponible es: " & cantiDisponible
                                    '    PanelError.Visible = True
                                    '    Timer1.Enabled = True
                                    '    TiempoEjecutar(10)
                                    '    Exit Sub
                                    'Else
                                    '    Calculos()
                                    'End If

                                End If
                        End Select
                     '   End Select



                    Case 8
                        Dim r As Record = dgvCompra.Table.CurrentRecord
                        Calculos()

                    Case 9 'precio unitario

                        'Dim r As Record = dgvCompra.Table.CurrentRecord
                        'Dim text As String = cc.Renderer.ControlText
                        'If text.Trim.Length > 0 Then
                        '    Dim valuePrecioVenta As Decimal = Convert.ToDecimal(text)
                        '    cc.Renderer.ControlValue = valuePrecioVenta

                        '    Dim menor = r.GetValue("menor")
                        '    Dim gmayor = r.GetValue("gmayor")

                        '    'If valuePrecioVenta >= gmayor And valuePrecioVenta <= menor Then
                        '    '    Calculos()
                        '    'Else
                        '    '    'cc.Renderer.ControlValue = menor
                        '    '    cc.ConfirmChanges()
                        '    '    cc.EndEdit()
                        '    '    Calculos()
                        '    '    Exit Sub
                        '    'End If

                        '    If valuePrecioVenta > gmayor And valuePrecioVenta > menor Then
                        '        cc.Renderer.ControlValue = menor
                        '        'cc.ConfirmChanges()
                        '        'cc.EndEdit()
                        '        Calculos()
                        '        Exit Sub
                        '    ElseIf valuePrecioVenta > menor Then
                        '        cc.Renderer.ControlValue = menor
                        '        'cc.ConfirmChanges()
                        '        'cc.EndEdit()
                        '        Calculos()
                        '        Exit Sub
                        '    ElseIf valuePrecioVenta < gmayor Then
                        '        cc.Renderer.ControlValue = menor
                        '        'cc.ConfirmChanges()
                        '        'cc.EndEdit()
                        '        Calculos()
                        '        Exit Sub
                        '    Else
                        '        Calculos()
                        '    End If

                        'End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    'Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
    '    Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    Dim precio As New configuracionPrecioProducto
    '    Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
    '    cc.ConfirmChanges()

    '    If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
    '        Select Case cc.ColIndex
    '            Case 1 ' CODIGO BARRA


    '            Case 2 ' seleccion de empresa stock

    '            Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
    '                Dim r As Record = dgvCompra.Table.CurrentRecord
    '                If Not IsNothing(r) Then

    '                    Select Case Int32.Parse(r.GetValue("cboprecio"))
    '                        Case 0
    '                            'Dim f As New frmPreciosByArticulos(r)
    '                            'f.StartPosition = FormStartPosition.CenterParent
    '                            'f.ShowDialog()

    '                        Case Else
    '                            precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

    '                            If Not IsNothing(precio) Then
    '                                r.SetValue("pumn", precio.precioMN)
    '                                r.SetValue("pume", precio.precioME)
    '                                Calculos()
    '                            Else
    '                                MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                                r.SetValue("pumn", 0)
    '                                r.SetValue("pume", 0)
    '                                Calculos()
    '                            End If
    '                    End Select

    '                Else

    '                End If



    '            Case 7 ' cantidad
    '                'Select Case strTipoEx
    '                'Case "GS"
    '                Dim r As Record = dgvCompra.Table.CurrentRecord

    '                If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

    '                Else
    '                    cc.ConfirmChanges()
    '                    cc.EndEdit()

    '                End If
    '                Calculos()

    '                'End Select
    '            Case 8
    '                Dim r As Record = dgvCompra.Table.CurrentRecord
    '                Calculos()
    '        End Select
    '    End If
    'End Sub

    'Private Sub dgvCompra_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlKeyPress
    '    Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    Dim precio As New configuracionPrecioProducto
    '    Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
    '    cc.ConfirmChanges()

    '    If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
    '        Select Case cc.ColIndex
    '            Case 1 ' CODIGO BARRA


    '            Case 2 ' seleccion de empresa stock

    '            Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
    '                Dim r As Record = dgvCompra.Table.CurrentRecord
    '                If Not IsNothing(r) Then

    '                    Select Case Int32.Parse(r.GetValue("cboprecio"))
    '                        Case 0
    '                            'Dim f As New frmPreciosByArticulos(r)
    '                            'f.StartPosition = FormStartPosition.CenterParent
    '                            'f.ShowDialog()

    '                        Case Else
    '                            precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

    '                            If Not IsNothing(precio) Then
    '                                r.SetValue("pumn", precio.precioMN)
    '                                r.SetValue("pume", precio.precioME)
    '                                Calculos()
    '                            Else
    '                                MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                                r.SetValue("pumn", 0)
    '                                r.SetValue("pume", 0)
    '                                Calculos()
    '                            End If
    '                    End Select

    '                Else

    '                End If



    '            Case 7 ' cantidad
    '                'Select Case strTipoEx
    '                'Case "GS"
    '                Dim r As Record = dgvCompra.Table.CurrentRecord

    '                If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

    '                Else
    '                    cc.ConfirmChanges()
    '                    cc.EndEdit()

    '                End If
    '                Calculos()

    '                'End Select
    '            Case 8
    '                Dim r As Record = dgvCompra.Table.CurrentRecord
    '                Calculos()
    '        End Select
    '    End If
    'End Sub

    Private Sub dgvCompra_TableControlLeftColChanged(sender As Object, e As GridTableControlRowColIndexChangedEventArgs) Handles dgvCompra.TableControlLeftColChanged

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

    Private Sub gradientPanel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub GetResetCantidades()
        For Each i In dgvCompra.Table.Records
            i.SetValue("cantidad", 0)
        Next
        txtTotalBase.DecimalValue = 0
        txtTotalBase2.DecimalValue = 0
        txtTotalBase3.DecimalValue = 0
        txtTotalIva.DecimalValue = 0
        TextTotalDescuentos.DecimalValue = 0
        txtVentaTotal.DecimalValue = 0
        txtTotalPagar.DecimalValue = 0
        DigitalGauge2.Text = "0.00"
        DigitalGauge2.Value = "0.00"
        dgvCompra.Refresh()
        'Calculos()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If BackgroundWorker1.CancellationPending Then
            ' MessageBox.Show("Up to here? ...")
            e.Cancel = True
        Else
            Dim strIdModulo As String = Nothing
            If ComboComprobante.Text = "BOLETA" Then
                strIdModulo = "VT2"
            ElseIf ComboComprobante.Text = "FACTURA" Then
                strIdModulo = "VT3"
            ElseIf ComboComprobante.Text = "BOLETA ELECTRONICA" Then
                strIdModulo = "VT2E"
            ElseIf ComboComprobante.Text = "FACTURA ELECTRONICA" Then
                strIdModulo = "VT3E"
            ElseIf ComboComprobante.Text = "PROFORMA" Then
                strIdModulo = "COTIZACION"
            End If
            Dim strIDEmpresa = Gempresas.IdEmpresaRuc
            configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then

        Else
            'Select Case ComboComprobante.Text
            '    Case "FACTURA ELECTRONICA", "BOLETA ELECTRONICA"
            '        txtSerie.Text = conf.Serie
            '        txtNumero.Text = conf.ValorActual + 1

            '        ProgressBar2.Visible = False
            '    Case Else
            'End Select

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        'Dim f As New FormUltimasVentas(TextCliente.Tag)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog(Me)

        'Dim f As New frmCrearENtidades
        'f.CaptionLabels(0).Text = "Nuevo cliente"
        'f.strTipo = TIPO_ENTIDAD.CLIENTE
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        ''f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'If Not IsNothing(f.Tag) Then
        '    Dim c = CType(f.Tag, entidad)
        '    listaClientes.Add(c)
        '    TextCliente.Text = c.nombreCompleto
        '    txtruc.Text = c.nrodoc
        '    TextCliente.Tag = c.idEntidad
        '    txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '    txtruc.Visible = True
        '    TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        'End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try

            'If tmpConfigInicio.FormatoVenta = "MKT" Then
            If ValidarGrabado() = True Then
                If ManipulacionEstado = ENTITY_ACTIONS.UPDATE AndAlso inicioComprobante = "PROFORMA" Then
                    '   EditarCotizacion()
                Else
                    If dgvCompra.Table.Records.Count > 0 Then
                        'Dim Vendedor = GetCodigoVendedor()
                        Select Case ComboComprobante.Text
                            Case "PROFORMA"
                                EditarPedido(New Seguridad.Business.Entity.Usuario With {.IDUsuario = Integer.Parse(TextVendedor.Tag)})
                            Case Else
                                EditarPedido(New Seguridad.Business.Entity.Usuario With {.IDUsuario = Integer.Parse(TextVendedor.Tag)})
                        End Select


                    Else
                        MessageBox.Show("Debe ingresar productos a la canasta de venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
            End If

            'Else

            'End If

        Catch ex As Exception
            objPleaseWait.Close()
            MsgBox(ex.Message)
            btGrabar.Enabled = True
        End Try
    End Sub

    Private Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0


        If ComboComprobante.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(ComboComprobante, "Ingrese un comprobante")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(ComboComprobante, Nothing)
            End If

            If TextComprador.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(TextComprador, "Ingrese el nombre del comprador")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(TextCliente, Nothing)
            End If

            If TextCliente.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(TextCliente, "Ingrese un cliente")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(TextCliente, Nothing)
            End If

            If TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                ErrorProvider1.SetError(TextCliente, Nothing)
            Else
                ErrorProvider1.SetError(TextCliente, "Ingrese un cliente válido")
                listaErrores += 1
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

    Sub GrabarProforma()
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
        Dim proveedor As String
        Dim idProveedor As Integer

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()
        proveedor = TextCliente.Text
        idProveedor = CInt(TextCliente.Tag)

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = Date.Now.ToUniversalTime
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.moneda = "1"
        ndocumento.idEntidad = Val(idProveedor)
        ndocumento.entidad = proveedor
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.nrodocEntidad = txtruc.Text
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        nDocumentoVenta = New documentoventaAbarrotes With {
            .IdDocumentoCotizacion = False,
                 .TipoConfiguracion = If(GConfiguracion Is Nothing, Nothing, GConfiguracion.TipoConfiguracion),
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = Date.Now.ToUniversalTime,
                  .fechaPeriodo = GetPeriodo(Date.Now, True),' lblPerido.Text,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = idProveedor,
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
                  .tipoVenta = TIPO_VENTA.COTIZACION,
                  .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                  .glosa = "Por cotizacion de venta",
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            'Select Case r.GetValue("valPago")
            '    Case "Pagado"
            '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            '    Case Else
            '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            'End Select
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = Date.Now.ToUniversalTime
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = Nothing
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = Nothing
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
            If CDec(r.GetValue("cantidad")) <= 0 Then
                MessageBox.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                MessageBox.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

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
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = 0 'CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = 0 'CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = Nothing
            objDocumentoVentaDet.salidaCostoMN = 0
            objDocumentoVentaDet.salidaCostoME = 0
            objDocumentoVentaDet.categoria = Nothing
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = Date.Now

            objDocumentoVentaDet.Glosa = "Por cotizacion de venta"
            ListaDetalle.Add(objDocumentoVentaDet)
        Next

        '-------------------------------------------------------------------------------------
        '---------------- VALIDACION DE IMPORTE CON DETALLE DE VENTA -------------------------
        Dim sumaVentaMN As Decimal = ListaDetalle.Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim sumaVentaME As Decimal = ListaDetalle.Sum(Function(o) o.importeME).GetValueOrDefault
        Dim sumaBase1MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase1ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaBase2MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase2ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaIgvMN As Decimal = ListaDetalle.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim sumaIgvME As Decimal = ListaDetalle.Sum(Function(o) o.montoIgvUS).GetValueOrDefault

        Dim totalVentaDetalle As Decimal = sumaBase1MN + sumaBase2MN + sumaIgvMN
        Dim totalHeader As Decimal = txtTotalPagar.DecimalValue
        If totalHeader <> totalVentaDetalle Then
            Throw New Exception("Los importes no coinciden, tanto del detalle con la cabecera ")
        End If
        '-------------------------------------------------------------------------------------
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        Dim cod = VentaSA.GrabarCotizacion(ndocumento)
        LimpiarControles()
        Alert = New Alert("Proforma registrada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        ToolStripButton1.Select()
    End Sub

    Private Sub EditarPedido(Vendedor As Helios.Seguridad.Business.Entity.Usuario)
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

        Dim CompradorID As String = String.Empty
        Dim tipoComprobante As String = String.Empty
        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim proveedor As String
        Dim idProveedor As Integer

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        Select Case ComboComprobante.Text
            Case "BOLETA", "BOLETA ELECTRONICA"
                tipoComprobante = "03"
            Case "FACTURA", "FACTURA ELECTRONICA"
                tipoComprobante = "01"
            Case "NOTA DE VENTA"
                tipoComprobante = "9907"
            Case "PROFORMA"
                tipoComprobante = "9901"
        End Select


        proveedor = TextCliente.Text '¨Pedido"
        idProveedor = TextCliente.Tag ' VarClienteGeneral.idEntidad

        CompradorID = TextComprador.Text.Trim

        Dim fechaSel = DateTime.Now
        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idDocumento = venta.idDocumento
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = venta.tipoDocumento
        ndocumento.fechaProceso = Date.Now
        ndocumento.nroDoc = TextNumeroVenta.Text.Trim
        ndocumento.moneda = venta.moneda
        ndocumento.idEntidad = Val(idProveedor)
        ndocumento.entidad = proveedor
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.nrodocEntidad = "-"
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = Vendedor.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        nDocumentoVenta = New documentoventaAbarrotes With {
            .idDocumento = venta.idDocumento,
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = venta.tipoDocumento,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = Date.Now,
                  .fechaPeriodo = GetPeriodo(Date.Now, True),
                  .serieVenta = venta.serieVenta,
                  .numeroVenta = venta.numeroVenta,
                  .serie = venta.serie,
                  .numeroDocNormal = venta.numeroDocNormal,
                  .idCliente = idProveedor,
                  .nombrePedido = CompradorID,
                  .moneda = venta.moneda,
                  .tasaIgv = venta.tasaIgv,
                  .tipoCambio = venta.tipoCambio,
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
                  .tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO,
                  .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                  .glosa = txtGlosa.Text.Trim,
                  .usuarioActualizacion = Vendedor.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.idDocumento = venta.idDocumento
            'Select Case r.GetValue("valPago")
            '    Case "Pagado"
            '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            '    Case Else
            objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            'End Select
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells
            objDocumentoVentaDet.FechaDoc = Date.Now
            objDocumentoVentaDet.TipoDoc = tipoComprobante '"9907"
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = Nothing
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
            If CDec(r.GetValue("cantidad")) <= 0 Then
                MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalpagar")) 'CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalpagar")) / TmpTipoCambio ' CDec(r.GetValue
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
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = 0 'CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = 0 'CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = Nothing
            objDocumentoVentaDet.salidaCostoMN = 0 'CDec(r.GetValue("costoMN")) ' CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value())
            objDocumentoVentaDet.salidaCostoME = 0 ' CDec(r.GetValue("costoME")) 'CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value())
            objDocumentoVentaDet.categoria = Nothing
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.tipobeneficio = "-"
            objDocumentoVentaDet.beneficiobase = 0

            objDocumentoVentaDet.usuarioModificacion = Vendedor.IDUsuario
            objDocumentoVentaDet.fechaModificacion = Date.Now

            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)
        Next

        'Dim listaBeneficios = GetDetalleBeneficios()
        'If listaBeneficios.Count > 0 Then
        '    ListaDetalle.AddRange(listaBeneficios)
        'End If
        '-------------------------------------------------------------------------------------
        '---------------- VALIDACION DE IMPORTE CON DETALLE DE VENTA -------------------------

        Dim sumaVentaMN As Decimal = ListaDetalle.Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim sumaVentaME As Decimal = ListaDetalle.Sum(Function(o) o.importeME).GetValueOrDefault
        Dim sumaBase1MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase1ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaBase2MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase2ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaIgvMN As Decimal = ListaDetalle.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim sumaIgvME As Decimal = ListaDetalle.Sum(Function(o) o.montoIgvUS).GetValueOrDefault

        Dim totalVentaDetalle As Decimal = sumaBase1MN + sumaBase2MN + sumaIgvMN
        Dim totalHeader As Decimal = txtTotalPagar.DecimalValue
        If totalHeader <> totalVentaDetalle Then
            Throw New Exception("Los importes no coinciden, tanto del detalle con la cabecera ")
        End If
        '-------------------------------------------------------------------------------------

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        If ListaDetalle.Count = 0 Then
            MessageBox.Show("Debe ingresar productos a la canasta", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim cod = VentaSA.UpdatePedidoProforma(ndocumento)
        Tag = "Grabado"
        Close()
    End Sub

    Private Sub bgCombos_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgCombos.DoWork
        If bgCombos.CancellationPending Then
            ' MessageBox.Show("Up to here? ...")
            e.Cancel = True
        Else
            GetCombos()
        End If
    End Sub

    Private Sub bgCombos_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgCombos.RunWorkerCompleted
        If e.Cancelled Then

        Else
            Loadcontroles()
        End If
    End Sub

    Sub GetLimpiarBeneficios()
        'For Each r In dgvCompra.Table.Records
        '    If r.GetValue("tipobeneficio") = "REGALO" Then
        '        r.Delete()
        '    ElseIf r.GetValue("tipobeneficio") = "OFERTA" Then
        '        r.Delete()
        '    End If
        'Next
        '    GridBeneficios.Table.Records.DeleteAll()
    End Sub

    Public Sub TotalesColumnaDescuentos(listaBeneficios As List(Of Business.Entity.beneficio))
        GetLimpiarBeneficios()

        For Each r In dgvCompra.Table.Records

            Dim codProducto = Integer.Parse(r.GetValue("idProducto"))
            Dim productoBeneficio = listaBeneficios.Where(Function(o) o.detalleBeneficio = codProducto).SingleOrDefault
            Dim tipotabla As String = String.Empty

            If productoBeneficio IsNot Nothing Then

                Select Case productoBeneficio.tipoTabla
                    Case General.TipoTabla.DescuentoRebaja
                        Select Case productoBeneficio.tipoTabla
                            Case General.TipoTabla.regalo
                                tipotabla = "REGALO"
                            Case General.TipoTabla.Bonificacion
                                tipotabla = "BONIFICACION"
                            Case General.TipoTabla.DescuentoRebaja
                                tipotabla = "DESCUENTO REBAJA"
                        End Select

                        r.SetValue("tipobeneficio", tipotabla)
                        r.SetValue("valorbase", productoBeneficio.importeBase)
                        r.SetValue("valorafecto", productoBeneficio.valorConvertido)
                        'calculo base imponible e igv
                        If CDec(r.GetValue("totalpagar")) >= productoBeneficio.importeBase Then
                            Dim total = CDec(r.GetValue("totalmn")) - CDec(r.GetValue("valorafecto"))
                            Dim baseImponible As Decimal = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                            Dim iva As Decimal = total - baseImponible
                            'Dim pu As Decimal = Math.Round(total / CDec(r.GetValue("cantidad")), 2)
                            r.SetValue("totalpagar", total)
                            r.SetValue("igvmn", iva)
                            r.SetValue("vcmn", baseImponible)
                            ' r.SetValue("pumn", pu)
                        Else
                            r.SetValue("tipobeneficio", "")
                            r.SetValue("valorbase", 0)
                            r.SetValue("valorafecto", 0)
                        End If

                    Case General.TipoTabla.regalo, General.TipoTabla.Bonificacion
                        Select Case productoBeneficio.tipoTabla
                            Case General.TipoTabla.regalo
                                tipotabla = "REGALO"
                            Case General.TipoTabla.Bonificacion
                                tipotabla = "BONIFICACION"
                            Case General.TipoTabla.DescuentoRebaja
                                tipotabla = "DESCUENTO REBAJA"
                        End Select

                        r.SetValue("tipobeneficio", "-")
                        r.SetValue("valorbase", productoBeneficio.importeBase)
                        r.SetValue("valorafecto", productoBeneficio.valorConvertido)
                        'calculo base imponible e igv
                        If CDec(r.GetValue("totalpagar")) >= productoBeneficio.importeBase Then
                            Dim total = CDec(r.GetValue("totalmn")) - CDec(r.GetValue("valorafecto"))
                            Dim baseImponible As Decimal = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                            Dim iva As Decimal = total - baseImponible
                            'Dim pu As Decimal = Math.Round(total / CDec(r.GetValue("cantidad")), 2)
                            r.SetValue("totalpagar", total)
                            r.SetValue("igvmn", iva)
                            r.SetValue("vcmn", baseImponible)
                            ' r.SetValue("pumn", pu)
                        Else
                            r.SetValue("tipobeneficio", "-")
                            r.SetValue("valorbase", 0)
                            r.SetValue("valorafecto", 0)
                        End If


                        'Funcionamiento para agregar reaglos y bonificaciones
                        GetBonificacionesByRegalos(productoBeneficio.beneficio_id)
                    Case General.TipoTabla.Promocion

                        If CDec(r.GetValue("cantidad")) >= productoBeneficio.importeBase Then
                            r.SetValue("tipobeneficio", "-")
                            r.SetValue("valorbase", CDec(r.GetValue("cantidad")))
                            r.SetValue("valorafecto", 0)
                            GetPromocion(productoBeneficio.beneficio_id, r, productoBeneficio)
                        End If
                End Select


            Else
                Dim destinoGravado = r.GetValue("gravado")
                Dim total = CDec(r.GetValue("totalmn"))
                Select Case destinoGravado
                    Case 1
                        Dim baseImponible As Decimal = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                        Dim iva As Decimal = Math.Round(CDec(total - baseImponible), 2)
                        'Dim pu As Decimal = Math.Round(total / CDec(r.GetValue("cantidad")), 2)
                        r.SetValue("totalpagar", total)
                        r.SetValue("igvmn", iva)
                        r.SetValue("vcmn", baseImponible)
                    Case 2

                        'Dim pu As Decimal = Math.Round(total / CDec(r.GetValue("cantidad")), 2)
                        r.SetValue("totalpagar", total)
                        r.SetValue("igvmn", 0)
                        r.SetValue("vcmn", total)
                End Select

                ' r.SetValue("totalpagar", CDec(r.GetValue("totalmn")))
                r.SetValue("tipobeneficio", "-")
                r.SetValue("valorbase", 0)
                r.SetValue("valorafecto", 0)
            End If


        Next
        dgvCompra.Refresh()
        TotalTalesXcolumna()
    End Sub

    Private Sub GetBonificacionesByRegalos(beneficio_id As Integer)
        Dim f As New FormViewbeneficiosDetails(beneficio_id)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ListaRegalos = CType(f.Tag, List(Of beneficioDetalle))
            If ListaRegalos.Count > 0 Then
                For Each i In ListaRegalos
                    AddCanastaventaBeneficio(i)
                Next
            End If
        End If
    End Sub

    Private Sub GetPromocion(beneficio_id As Integer, fila As Record, beneficio As Business.Entity.beneficio)
        Dim f As New FormViewbeneficiosDetails(beneficio_id)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ListaRegalos = CType(f.Tag, List(Of beneficioDetalle))
            If ListaRegalos.Count > 0 Then
                'Dim cantidadModificada = CDec(fila.GetValue("cantidad")) - ListaRegalos.Sum(Function(o) o.cantidad).GetValueOrDefault

                Dim nroLlevar = beneficio.importeBase
                Dim nroPorPagar = ListaRegalos.Sum(Function(o) o.cantidad).GetValueOrDefault
                Dim totalPromocionesRegaladas = Math.Round(CDec(fila.GetValue("valorbase")) / CDec(nroLlevar), 2)

                Dim ParteEntera = Int(totalPromocionesRegaladas)
                Dim ParteDecimal = totalPromocionesRegaladas - ParteEntera
                If ParteDecimal > 0 Then
                    ParteDecimal = 1
                End If
                Dim valorRegalo = nroLlevar - nroPorPagar
                Dim numTotalregalos = ParteEntera * valorRegalo
                Dim numTotalProductosLlevar = CDec(fila.GetValue("valorbase")) - numTotalregalos


                Dim precioUnitarioVenta = CDec(fila.GetValue("pumn"))
                Dim total = numTotalProductosLlevar * precioUnitarioVenta
                Dim base = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                Dim iva = Math.Round(CDec(total) - CDec(base), 2)
                fila.EndEdit()

                fila.SetValue("cantidad", numTotalProductosLlevar)
                fila.SetValue("vcmn", base)
                fila.SetValue("igvmn", iva)
                fila.SetValue("totalmn", total)
                fila.SetValue("totalpagar", total)
                dgvCompra.Refresh()
                'fila.Delete()

                'AddCanastaRow(fila)
                For Each i In ListaRegalos
                    AddCanastaPremio(i, numTotalregalos)
                Next
            End If
        End If
    End Sub

    Private Sub AddCanastaRow(nuevaFila As Record)
        With dgvCompra.Table
            .AddNewRecord.SetCurrent()
            .AddNewRecord.BeginEdit()
            .CurrentRecord.SetValue("codigo", 0)
            .CurrentRecord.SetValue("gravado", nuevaFila.GetValue("gravado"))
            .CurrentRecord.SetValue("idProducto", nuevaFila.GetValue("idProducto"))
            .CurrentRecord.SetValue("item", nuevaFila.GetValue("item"))
            .CurrentRecord.SetValue("um", nuevaFila.GetValue("um"))
            .CurrentRecord.SetValue("cantidad", nuevaFila.GetValue("cantidad"))
            .CurrentRecord.SetValue("canDisponible", nuevaFila.GetValue("canDisponible"))

            .CurrentRecord.SetValue("tipoExistencia", nuevaFila.GetValue("tipoExistencia"))
            .CurrentRecord.SetValue("marca", Nothing) ') If(productoBE.CustomLote.productoSustentado = True, "Doc.", "Not.")) 'Susuentado y no sustentado

            .CurrentRecord.SetValue("vcmn", nuevaFila.GetValue("vcmn"))
            .CurrentRecord.SetValue("MontoSaldo", nuevaFila.GetValue("MontoSaldo"))
            .CurrentRecord.SetValue("vcme", nuevaFila.GetValue("vcme"))
            .CurrentRecord.SetValue("igvmn", nuevaFila.GetValue("igvmn"))
            .CurrentRecord.SetValue("igvme", nuevaFila.GetValue("igvme"))
            .CurrentRecord.SetValue("pumn", nuevaFila.GetValue("pumn"))
            .CurrentRecord.SetValue("pume", nuevaFila.GetValue("pume"))

            .CurrentRecord.SetValue("menor", nuevaFila.GetValue("menor"))
            .CurrentRecord.SetValue("mayor", nuevaFila.GetValue("mayor"))
            .CurrentRecord.SetValue("gmayor", nuevaFila.GetValue("gmayor"))

            .CurrentRecord.SetValue("puKardex", nuevaFila.GetValue("puKardex"))
            .CurrentRecord.SetValue("pukardeme", nuevaFila.GetValue("pukardeme"))

            .CurrentRecord.SetValue("chPago", nuevaFila.GetValue("chPago"))
            .CurrentRecord.SetValue("valPago", nuevaFila.GetValue("valPago"))

            .CurrentRecord.SetValue("chBonif", nuevaFila.GetValue("chBonif"))
            .CurrentRecord.SetValue("valBonif", nuevaFila.GetValue("valBonif"))
            '   If .tipoExistencia <> "GS" Then
            .CurrentRecord.SetValue("almacen", nuevaFila.GetValue("almacen"))
            .CurrentRecord.SetValue("presentacion", nuevaFila.GetValue("presentacion"))

            .CurrentRecord.SetValue("percepcionMN", 0)
            .CurrentRecord.SetValue("percepcionME", 0)
            .CurrentRecord.SetValue("costoMN", 0)
            .CurrentRecord.SetValue("costoME", 0)
            .CurrentRecord.SetValue("tipoPrecio", nuevaFila.GetValue("tipoPrecio"))
            .CurrentRecord.SetValue("cboprecio", nuevaFila.GetValue("cboprecio"))
            .CurrentRecord.SetValue("cat", nuevaFila.GetValue("cat"))
            .CurrentRecord.SetValue("codigoLote", nuevaFila.GetValue("codigoLote")) ' productoBE.codigoLote)
            .CurrentRecord.SetValue("codBarra", nuevaFila.GetValue("codBarra"))
            .CurrentRecord.SetValue("empresa", nuevaFila.GetValue("empresa"))
            .CurrentRecord.SetValue("tipoventa", nuevaFila.GetValue("tipoventa"))
            .CurrentRecord.SetValue("cantidad2", nuevaFila.GetValue("cantidad2"))

            .CurrentRecord.SetValue("totalmn", nuevaFila.GetValue("totalmn"))
            .CurrentRecord.SetValue("totalpagar", nuevaFila.GetValue("totalpagar"))
            .CurrentRecord.SetValue("totalme", nuevaFila.GetValue("totalme"))

            .CurrentRecord.SetValue("tipobeneficio", "PROMOCION")
            .CurrentRecord.SetValue("valorbase", 0)
            .CurrentRecord.SetValue("valorafecto", 0)
            .AddNewRecord.EndEdit()
            .TableDirty = True
        End With
    End Sub

    Private Sub AddCanastaventaBeneficio(i As beneficioDetalle)
        Dim lista = InventarioSA.GetDetalleLoteXproducto(New totalesAlmacen With
                                                         {
                                                         .idEmpresa = Gempresas.IdEmpresaRuc,
                                                         .idAlmacen = i.almacen,
                                                         .idItem = i.iditem
                                                         })

        Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

        If cantidadDisponible <= 0 Then
            Throw New Exception("Stock cero")
        End If

        If i.cantidad > cantidadDisponible Then
            '    cantidadComprada = CantidadSolicitada - cantidadDisponible
            Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
            '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
        End If

        Dim obj = New totalesAlmacen
        obj.idEmpresa = Gempresas.IdEmpresaRuc
        obj = lista.FirstOrDefault
        obj.cantidad = i.cantidad
        obj.NomAlmacen = lista.FirstOrDefault.NomAlmacen
        obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote

        obj.PMprecioMN = 0
        obj.PMprecioME = 0
        obj.tipoConfiguracion = 0

        obj.montoDsctounitMenorMN = 0
        obj.montoDsctounitMayorMN = 0
        obj.montoDsctounitGMayorMN = 0


        EnvioProductoBeneficio(obj)
        ConteoLabelVentas()
        TotalTalesXcolumna()
    End Sub


    Private Sub AddCanastaPremio(i As beneficioDetalle, totalPromocionesRegaladas As Decimal)
        Dim lista = InventarioSA.GetDetalleLoteXproducto(New totalesAlmacen With
                                                         {
                                                         .idEmpresa = Gempresas.IdEmpresaRuc,
                                                         .idAlmacen = i.almacen,
                                                         .idItem = i.iditem
                                                         })

        Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

        If cantidadDisponible <= 0 Then
            Throw New Exception("Stock cero")
        End If

        If totalPromocionesRegaladas > cantidadDisponible Then
            '    cantidadComprada = CantidadSolicitada - cantidadDisponible
            Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
            '   CantidadSolicitada = CantidadSolicitada + cantidadComprada
        End If

        Dim obj = New totalesAlmacen
        obj.idEmpresa = Gempresas.IdEmpresaRuc
        obj = lista.FirstOrDefault
        obj.cantidad = totalPromocionesRegaladas
        obj.NomAlmacen = lista.FirstOrDefault.NomAlmacen
        obj.cantidad2 = cantidadDisponible ' cantidadDisponibleXLote

        obj.PMprecioMN = 0
        obj.PMprecioME = 0
        obj.tipoConfiguracion = 0

        obj.montoDsctounitMenorMN = 0
        obj.montoDsctounitMayorMN = 0
        obj.montoDsctounitGMayorMN = 0


        EnvioProductoPromocion(obj)
        ConteoLabelVentas()
        TotalTalesXcolumna()
    End Sub

    'Private Function VerificarItemDuplicadoV2(cantidad As Decimal, lote As Integer, intIdItem As Integer) As Boolean
    '    VerificarItemDuplicadoV2 = False
    '    Dim colIdItem As Integer
    '    Dim codigoLote As Integer

    '    colIdItem = intIdItem
    '    codigoLote = lote
    '    For Each i In dgvCompra.Table.Records
    '        If colIdItem = i.GetValue("idProducto") AndAlso codigoLote = i.GetValue("codigoLote") Then
    '            CalculosByCantidadExistente(cantidad, i)
    '            VerificarItemDuplicadoV2 = True
    '            Exit For
    '        End If
    '    Next
    'End Function

    'Private Sub ValidarItemsDuplicados(intIdItem As Integer, tipoprecio As String)
    '    Dim colIdItem As Integer
    '    Dim precio As String

    '    colIdItem = intIdItem
    '    precio = tipoprecio

    '    For Each i In dgvCompra.Table.Records
    '        If colIdItem = i.GetValue("idProducto") AndAlso precio = i.GetValue("cboprecio") Then
    '            Throw New Exception("El artículo " & i.GetValue("item") & ", ya se encuentra en la canasta. Ingrese otro")
    '        End If
    '    Next
    'End Sub
    Private Function VerificarItemDuplicadoV2(cantidad As Decimal, lote As Integer, intIdItem As Integer) As Boolean
        VerificarItemDuplicadoV2 = False
        Dim colIdItem As Integer
        Dim codigoLote As Integer

        colIdItem = intIdItem
        codigoLote = lote
        For Each i In dgvCompra.Table.Records
            If colIdItem = i.GetValue("idProducto") Then
                '   CalculosByCantidadExistente(cantidad, i)
                VerificarItemDuplicadoV2 = True
                Exit For
            End If
        Next
    End Function
    Dim objPleaseWait As New FeedbackForm()
    Private venta As documentoventaAbarrotes

    Public Sub EnviarProducto(productoBE As totalesAlmacen) Implements IForm.EnviarProducto
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

                    .CurrentRecord.SetValue("puKardex", 0) 'productoBE.importeSoles / productoBE.cantidad)
                    .CurrentRecord.SetValue("pukardeme", 0) 'productoBE.importeDolares / productoBE.cantidad)

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
                    .CurrentRecord.SetValue("cantidad2", productoBE.CantidadComprada)

                    .CurrentRecord.SetValue("menor", productoBE.montoDsctounitMenorMN)
                    .CurrentRecord.SetValue("mayor", productoBE.montoDsctounitMayorMN)
                    .CurrentRecord.SetValue("gmayor", productoBE.montoDsctounitGMayorMN)
                    .AddNewRecord.EndEdit()
                    .TableDirty = True
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
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

    Public Sub CambiarPrecio(precio As configuracionPrecioProducto) Implements IPrecio.CambiarPrecio
        Select Case precio.ModificaColumna
            Case "PRECIO"
                dgvCompra.Table.CurrentRecord.SetValue("pumn", precio.precioMN)
                dgvCompra.Table.CurrentRecord.SetValue("pume", precio.precioME)

                dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", 0)
                dgvCompra.Refresh()
                Calculos()
                TotalTalesXcolumna()
                If ListaBeneficios IsNot Nothing Then
                    If ListaBeneficios.Count > 0 Then
                        TotalesColumnaDescuentos(ListaBeneficios)
                    End If
                End If

            Case "IMPORTE"
                dgvCompra.Table.CurrentRecord.SetValue("totalmn", precio.precioMN)
                dgvCompra.Table.CurrentRecord.SetValue("totalme", precio.precioME)

                dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", 0)
                dgvCompra.Refresh()
                CalculosAPartirDeImporte()
                TotalTalesXcolumna()
                If ListaBeneficios IsNot Nothing Then
                    If ListaBeneficios.Count > 0 Then
                        TotalesColumnaDescuentos(ListaBeneficios)
                    End If
                End If
        End Select

    End Sub

    Public Sub EnviarListaArticulos(lista As List(Of totalesAlmacen)) Implements IListaInventario.EnviarListaArticulos
        LimpiarProductosIguales(lista(0).idItem)
        For Each i In lista
            EnvioProductoSolo(i)
        Next
        ConteoLabelVentas()
        TotalTalesXcolumna()
        If ListaBeneficios IsNot Nothing Then
            If ListaBeneficios.Count > 0 Then
                TotalesColumnaDescuentos(ListaBeneficios)
            End If
        End If

    End Sub

    Sub EnvioProductoSolo(productoBE As totalesAlmacen)
        '   Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            Dim cantidad = Nothing
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0
            Dim valorBeneficio As Decimal = 0
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

                Dim totalMN = Math.Round(cantidad * colPrecUnit, 2)
                Dim totalME = Math.Round(cantidad * colPrecUnitme, 2)

                Dim iva As Decimal = TmpIGV / 100
                Dim descuentoItem As Decimal = 0
                Dim totalPagar As Decimal = 0

                Select Case productoBE.origenRecaudo
                    Case OperacionGravada.Grabado
                        If cantidad > 0 Then

                            colBI = Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2) ' (totalMN / (iva + 1))
                            colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                            'Dim iv As Decimal = 0
                            'Dim iv2 As Decimal = 0
                            'iv = totalMN / (iva + 1)
                            'iv2 = totalME / (iva + 1)

                            Igv = totalMN - colBI ' iv * (iva)
                            IgvME = totalME - colBIme ' iv2 * (iva)

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

                    .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                    .CurrentRecord.SetValue("marca", Nothing) ') If(productoBE.CustomLote.productoSustentado = True, "Doc.", "Not.")) 'Susuentado y no sustentado

                    'Select Case cboMoneda.Text
                    '    Case "NACIONAL"
                    .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    .CurrentRecord.SetValue("pumn", valPUmn)
                    .CurrentRecord.SetValue("pume", valPUme)

                    .CurrentRecord.SetValue("menor", productoBE.montoDsctounitMenorMN)
                    .CurrentRecord.SetValue("mayor", productoBE.montoDsctounitMayorMN)
                    .CurrentRecord.SetValue("gmayor", productoBE.montoDsctounitGMayorMN)
                    '    Case "EXTRANJERA"
                    '        .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '        .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '        .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '        .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '        .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '        .CurrentRecord.SetValue("pumn", valPUmn)
                    '        .CurrentRecord.SetValue("pume", valPUme)

                    '        .CurrentRecord.SetValue("menor", productoBE.montoDsctounitMenorME)
                    '        .CurrentRecord.SetValue("mayor", productoBE.montoDsctounitMayorME)
                    '        .CurrentRecord.SetValue("gmayor", productoBE.montoDsctounitGMayorME)
                    'End Select



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
                    .CurrentRecord.SetValue("cantidad2", productoBE.CantidadComprada)

                    .CurrentRecord.SetValue("totalmn", totalMN)
                    .CurrentRecord.SetValue("totalpagar", totalMN)
                    .CurrentRecord.SetValue("totalme", totalME)

                    .CurrentRecord.SetValue("tipobeneficio", "-")
                    .CurrentRecord.SetValue("valorbase", 0)
                    .CurrentRecord.SetValue("valorafecto", 0)
                    .AddNewRecord.EndEdit()
                    .TableDirty = True
                End With
            End If
            'If ListaBeneficios IsNot Nothing Then
            '    If ListaBeneficios.Count > 0 Then
            '        TotalesColumnaDescuentos(ListaBeneficios)
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
    End Sub

    'SERVICIO
    Public Sub EnviarListaServicio(lista As List(Of totalesAlmacen)) Implements IListaServicio.EnviarListaServicio
        LimpiarProductosIguales(lista(0).idItem)
        For Each i In lista
            EnvioProductoServicio(i)
        Next
        ConteoLabelVentas()
        TotalTalesXcolumna()
    End Sub

    Sub EnvioProductoServicio(productoBE As totalesAlmacen)
        '   Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            Dim cantidad = Nothing
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0
            cantidad = productoBE.cantidad
            valPUmn = productoBE.PMprecioMN
            valPUme = productoBE.PMprecioME
            Dim existeEnCanasta = VerificarItemDuplicadoServicio(CDec(cantidad), 0, productoBE.idItem)
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

                Dim totalMN = Math.Round(cantidad * colPrecUnit, 2)
                Dim totalME = Math.Round(cantidad * colPrecUnitme, 2)

                Dim iva As Decimal = TmpIGV / 100

                Select Case productoBE.origenRecaudo
                    Case OperacionGravada.Grabado
                        If cantidad > 0 Then

                            colBI = Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2) ' (totalMN / (iva + 1))
                            colBIme = Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2) '(totalME / (iva + 1))

                            'Dim iv As Decimal = 0
                            'Dim iv2 As Decimal = 0
                            'iv = totalMN / (iva + 1)
                            'iv2 = totalME / (iva + 1)

                            Igv = totalMN - colBI ' iv * (iva)
                            IgvME = totalME - colBIme ' iv2 * (iva)

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

                    .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.ServicioGasto)
                    .CurrentRecord.SetValue("marca", Nothing) ') If(productoBE.CustomLote.productoSustentado = True, "Doc.", "Not.")) 'Susuentado y no sustentado
                    'Select Case cboMoneda.Text
                    '    Case "NACIONAL"
                    .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    .CurrentRecord.SetValue("pumn", valPUmn)
                    .CurrentRecord.SetValue("pume", valPUme)

                    .CurrentRecord.SetValue("menor", productoBE.montoDsctounitMenorMN)
                    .CurrentRecord.SetValue("mayor", productoBE.montoDsctounitMayorMN)
                    .CurrentRecord.SetValue("gmayor", productoBE.montoDsctounitGMayorMN)
                    '    Case "EXTRANJERA"
                    '        .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '        .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                    '        .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '        .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '        .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '        .CurrentRecord.SetValue("pumn", valPUmn)
                    '        .CurrentRecord.SetValue("pume", valPUme)

                    '        .CurrentRecord.SetValue("menor", productoBE.montoDsctounitMenorME)
                    '        .CurrentRecord.SetValue("mayor", productoBE.montoDsctounitMayorME)
                    '        .CurrentRecord.SetValue("gmayor", productoBE.montoDsctounitGMayorME)
                    'End Select


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
                    .CurrentRecord.SetValue("cantidad2", productoBE.CantidadComprada)

                    .CurrentRecord.SetValue("totalmn", totalMN)
                    .CurrentRecord.SetValue("totalme", totalME)

                    .AddNewRecord.EndEdit()
                    .TableDirty = True
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
    End Sub

    Sub EnvioProductoPromocion(productoBE As totalesAlmacen)
        '   Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            Dim cantidad = Nothing
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0
            Dim valorBeneficio As Decimal = 0
            cantidad = productoBE.cantidad
            valPUmn = productoBE.PMprecioMN
            valPUme = productoBE.PMprecioME
            Dim existeEnCanasta = VerificarItemDuplicadoV2(CDec(cantidad), 0, productoBE.idItem)
            'If existeEnCanasta Then

            'Else
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

            Dim colCostoMN = 0 'cantidad * colPrecUnitAlmacen
            Dim colCostoME = 0 'cantidad * colPrecUnitUSAlmacen

            Dim totalMN = 0 'Math.Round(cantidad * colPrecUnit, 2)
            Dim totalME = 0 'Math.Round(cantidad * colPrecUnitme, 2)

            Dim iva As Decimal = 0 ' TmpIGV / 100
            Dim descuentoItem As Decimal = 0
            Dim totalPagar As Decimal = 0

            Select Case productoBE.origenRecaudo
                Case OperacionGravada.Grabado
                    If cantidad > 0 Then

                        colBI = 0 'Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2)
                        colBIme = 0 ' Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2)
                        Igv = 0 ' totalMN - colBI
                        IgvME = 0 ' totalME - colBIme
                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If
                Case OperacionGravada.Exonerado, OperacionGravada.Inafecto
                    If cantidad > 0 Then
                        colBI = 0 ' (totalMN)
                        colBIme = 0 ' (totalME)
                        Igv = 0
                        IgvME = 0
                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If
            End Select


#Region "Add Fila Beneficios"
            'With GridBeneficios.Table
            '    .AddNewRecord.SetCurrent()
            '    .AddNewRecord.BeginEdit()
            '    .CurrentRecord.SetValue("idItem", productoBE.idItem)
            '    .CurrentRecord.SetValue("detalle", productoBE.descripcion)
            '    .CurrentRecord.SetValue("um", productoBE.idUnidad)
            '    .CurrentRecord.SetValue("cantidad", cantidad)
            '    .CurrentRecord.SetValue("beneficio", "OFERTA")
            '    .CurrentRecord.SetValue("beneficiobase", 0)
            '    .CurrentRecord.SetValue("almacen", productoBE.idAlmacen)
            '    .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
            '    .AddNewRecord.EndEdit()
            '    .TableDirty = True
            'End With
#End Region

            'With dgvCompra.Table
            '    .AddNewRecord.SetCurrent()
            '    .AddNewRecord.BeginEdit()
            '    .CurrentRecord.SetValue("codigo", 0)
            '    .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
            '    .CurrentRecord.SetValue("idProducto", productoBE.idItem)
            '    .CurrentRecord.SetValue("item", productoBE.descripcion & " " & "PROMOCION")
            '    .CurrentRecord.SetValue("um", productoBE.idUnidad)
            '    .CurrentRecord.SetValue("cantidad", cantidad)
            '    .CurrentRecord.SetValue("canDisponible", productoBE.cantidad2)

            '    .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
            '    .CurrentRecord.SetValue("marca", Nothing) ') If(productoBE.CustomLote.productoSustentado = True, "Doc.", "Not.")) 'Susuentado y no sustentado

            '    .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
            '    .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
            '    .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
            '    .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
            '    .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
            '    .CurrentRecord.SetValue("pumn", valPUmn)
            '    .CurrentRecord.SetValue("pume", valPUme)

            '    .CurrentRecord.SetValue("menor", productoBE.montoDsctounitMenorMN)
            '    .CurrentRecord.SetValue("mayor", productoBE.montoDsctounitMayorMN)
            '    .CurrentRecord.SetValue("gmayor", productoBE.montoDsctounitGMayorMN)

            '    .CurrentRecord.SetValue("puKardex", productoBE.importeSoles / productoBE.cantidad)
            '    .CurrentRecord.SetValue("pukardeme", productoBE.importeDolares / productoBE.cantidad)

            '    .CurrentRecord.SetValue("chPago", False)
            '    .CurrentRecord.SetValue("valPago", "No Pagado")

            '    .CurrentRecord.SetValue("chBonif", False)
            '    .CurrentRecord.SetValue("valBonif", "N")
            '    '   If .tipoExistencia <> "GS" Then
            '    .CurrentRecord.SetValue("almacen", productoBE.idAlmacen)
            '    .CurrentRecord.SetValue("presentacion", productoBE.NomAlmacen)

            '    .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            '    .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
            '    .CurrentRecord.SetValue("costoMN", colCostoMN)
            '    .CurrentRecord.SetValue("costoME", colCostoME)
            '    .CurrentRecord.SetValue("tipoPrecio", productoBE.tipoConfiguracion)
            '    .CurrentRecord.SetValue("cboprecio", Integer.Parse(productoBE.tipoConfiguracion))
            '    .CurrentRecord.SetValue("cat", StatusCategoriaVenta.Productos)
            '    .CurrentRecord.SetValue("codigoLote", 0) ' productoBE.codigoLote)
            '    .CurrentRecord.SetValue("codBarra", productoBE.CodigoBarra)
            '    .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
            '    .CurrentRecord.SetValue("tipoventa", "V")
            '    .CurrentRecord.SetValue("cantidad2", productoBE.CantidadComprada)

            '    .CurrentRecord.SetValue("totalmn", totalMN)
            '    .CurrentRecord.SetValue("totalpagar", totalMN)
            '    .CurrentRecord.SetValue("totalme", totalME)

            '    .CurrentRecord.SetValue("tipobeneficio", "OFERTA")
            '    .CurrentRecord.SetValue("valorbase", 0)
            '    .CurrentRecord.SetValue("valorafecto", 0)
            '    .AddNewRecord.EndEdit()
            '    .TableDirty = True
            'End With
            'End If
            'If ListaBeneficios IsNot Nothing Then
            '    If ListaBeneficios.Count > 0 Then
            '        TotalesColumnaDescuentos(ListaBeneficios)
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
    End Sub

    Sub EnvioProductoBeneficio(productoBE As totalesAlmacen)
        '   Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            Dim cantidad = Nothing
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0
            Dim valorBeneficio As Decimal = 0
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

                Dim colCostoMN = 0 'cantidad * colPrecUnitAlmacen
                Dim colCostoME = 0 'cantidad * colPrecUnitUSAlmacen

                Dim totalMN = 0 'Math.Round(cantidad * colPrecUnit, 2)
                Dim totalME = 0 'Math.Round(cantidad * colPrecUnitme, 2)

                Dim iva As Decimal = 0 ' TmpIGV / 100
                Dim descuentoItem As Decimal = 0
                Dim totalPagar As Decimal = 0

                Select Case productoBE.origenRecaudo
                    Case OperacionGravada.Grabado
                        If cantidad > 0 Then

                            colBI = 0 'Math.Round(CDec(CalculoBaseImponible(totalMN, iva + 1)), 2)
                            colBIme = 0 ' Math.Round(CDec(CalculoBaseImponible(totalME, iva + 1)), 2)
                            Igv = 0 ' totalMN - colBI
                            IgvME = 0 ' totalME - colBIme
                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If
                    Case OperacionGravada.Exonerado, OperacionGravada.Inafecto
                        If cantidad > 0 Then
                            colBI = 0 ' (totalMN)
                            colBIme = 0 ' (totalME)
                            Igv = 0
                            IgvME = 0
                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If
                End Select

#Region "Add Fila Beneficios"
                'With GridBeneficios.Table
                '    .AddNewRecord.SetCurrent()
                '    .AddNewRecord.BeginEdit()
                '    .CurrentRecord.SetValue("idItem", productoBE.idItem)
                '    .CurrentRecord.SetValue("detalle", productoBE.descripcion)
                '    .CurrentRecord.SetValue("um", productoBE.idUnidad)
                '    .CurrentRecord.SetValue("cantidad", cantidad)
                '    .CurrentRecord.SetValue("beneficio", "REGALO")
                '    .CurrentRecord.SetValue("beneficiobase", 0)
                '    .CurrentRecord.SetValue("almacen", productoBE.idAlmacen)
                '    .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
                '    .AddNewRecord.EndEdit()
                '    .TableDirty = True
                'End With
#End Region


                'With dgvCompra.Table
                '    .AddNewRecord.SetCurrent()
                '    .AddNewRecord.BeginEdit()
                '    .CurrentRecord.SetValue("codigo", 0)
                '    .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
                '    .CurrentRecord.SetValue("idProducto", productoBE.idItem)
                '    .CurrentRecord.SetValue("item", productoBE.descripcion)
                '    .CurrentRecord.SetValue("um", productoBE.idUnidad)
                '    .CurrentRecord.SetValue("cantidad", cantidad)
                '    .CurrentRecord.SetValue("canDisponible", productoBE.cantidad2)

                '    .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                '    .CurrentRecord.SetValue("marca", Nothing) ') If(productoBE.CustomLote.productoSustentado = True, "Doc.", "Not.")) 'Susuentado y no sustentado

                '    .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                '    .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                '    .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                '    .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                '    .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                '    .CurrentRecord.SetValue("pumn", valPUmn)
                '    .CurrentRecord.SetValue("pume", valPUme)

                '    .CurrentRecord.SetValue("menor", productoBE.montoDsctounitMenorMN)
                '    .CurrentRecord.SetValue("mayor", productoBE.montoDsctounitMayorMN)
                '    .CurrentRecord.SetValue("gmayor", productoBE.montoDsctounitGMayorMN)

                '    .CurrentRecord.SetValue("puKardex", productoBE.importeSoles / productoBE.cantidad)
                '    .CurrentRecord.SetValue("pukardeme", productoBE.importeDolares / productoBE.cantidad)

                '    .CurrentRecord.SetValue("chPago", False)
                '    .CurrentRecord.SetValue("valPago", "No Pagado")

                '    .CurrentRecord.SetValue("chBonif", False)
                '    .CurrentRecord.SetValue("valBonif", "N")
                '    '   If .tipoExistencia <> "GS" Then
                '    .CurrentRecord.SetValue("almacen", productoBE.idAlmacen)
                '    .CurrentRecord.SetValue("presentacion", productoBE.NomAlmacen)

                '    .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                '    .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                '    .CurrentRecord.SetValue("costoMN", colCostoMN)
                '    .CurrentRecord.SetValue("costoME", colCostoME)
                '    .CurrentRecord.SetValue("tipoPrecio", productoBE.tipoConfiguracion)
                '    .CurrentRecord.SetValue("cboprecio", Integer.Parse(productoBE.tipoConfiguracion))
                '    .CurrentRecord.SetValue("cat", StatusCategoriaVenta.Productos)
                '    .CurrentRecord.SetValue("codigoLote", 0) ' productoBE.codigoLote)
                '    .CurrentRecord.SetValue("codBarra", productoBE.CodigoBarra)
                '    .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                '    .CurrentRecord.SetValue("tipoventa", "V")
                '    .CurrentRecord.SetValue("cantidad2", productoBE.CantidadComprada)

                '    .CurrentRecord.SetValue("totalmn", totalMN)
                '    .CurrentRecord.SetValue("totalpagar", totalMN)
                '    .CurrentRecord.SetValue("totalme", totalME)

                '    .CurrentRecord.SetValue("tipobeneficio", "REGALO")
                '    .CurrentRecord.SetValue("valorbase", 0)
                '    .CurrentRecord.SetValue("valorafecto", 0)
                '    .AddNewRecord.EndEdit()
                '    .TableDirty = True
                'End With
            End If
            'If ListaBeneficios IsNot Nothing Then
            '    If ListaBeneficios.Count > 0 Then
            '        TotalesColumnaDescuentos(ListaBeneficios)
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
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

    Public Sub EnviarConsigna(be As totalesAlmacen) Implements IProductoConsignado.EnviarConsigna
        EnvioProductoConsignado(be)
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)
        Dim f As New FormCanastaOfertas
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        'FormVentaEnConsigna = New FormVentaEnConsigna
        'FormVentaEnConsigna.StartPosition = FormStartPosition.CenterScreen
        'FormVentaEnConsigna.ShowDialog(Me)
        FormNotaCompraDirecta = New FormNotaCompraDirecta(Date.Now)
        FormNotaCompraDirecta.StartPosition = FormStartPosition.CenterScreen
        FormNotaCompraDirecta.ShowDialog(Me)
        Cursor = Cursors.Arrow
    End Sub

    Private Sub ComboComprobante_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If dgvCompra.Table.CurrentRecord IsNot Nothing Then
            Dim f As New FormModificarPecio
            f.monedaSel = "NACIONAL"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
    End Sub

    Private Sub FormVentaGeneral_Load(sender As Object, e As EventArgs) Handles Me.Load

        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0 '65
        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0 '65
        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        CargarPrecios()
        lblConteo.Visible = True
        'dgvCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.CellType = "LinkLabelCell"
        DigitalGauge2.ForeColor = Color.DarkViolet
        dgvCompra.TableDescriptor.Columns("pumn").ReadOnly = False
        dgvCompra.Refresh()

        ' If tmpConfigInicio.FormatoVenta = "MKT" Then
        '   PanelPrecios2.Visible = True
        PanelPrecios2.Size = New Size(355, 585)
        PanelMontos.Visible = False
        dgvCompra.BackColor = Color.White
        DigitalGauge2.Visible = True
        'If inicioComprobante IsNot Nothing Then

        '    If inicioComprobante.ToString.Trim.Length > 0 Then
        '        RBProforma.Checked = True
        '        If ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
        '            GroupBarMKT.Visible = True
        '            btGrabar.Enabled = True
        '        End If
        '    End If
        'Else

        'End If
        'Else
        '    DigitalGauge2.Visible = True
        '    ' GroupBar1.Visible = True
        '    '   PanelPrecios2.Visible = False
        '    PanelPrecios2.Size = New Size(355, 585)
        '    PanelMontos.Visible = True
        '    dgvCompra.BackColor = Color.WhiteSmoke
        '    If inicioComprobante IsNot Nothing Then
        '        If inicioComprobante.ToString.Trim.Length > 0 Then
        '            ComboComprobante.Text = "PROFORMA"
        '            If ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
        '                GroupBarMKT.Visible = False
        '                btGrabar.Enabled = True
        '            End If
        '        End If
        '    End If
        'End If
        Centrar(Me)

        '        PanelMontos.Size = New Size(1217, 181) 'grande
        '       PanelMontos.Size = New Size(1217, 5) 'pequeño
    End Sub

    Public Sub RecuperarOferta(be As oferta) Implements IOferta.RecuperarOferta
        If be IsNot Nothing Then
            InsertarOfertaEnCanasta(be)
        End If
    End Sub

    Private Sub btnPegadoEspecial_Click(sender As Object, e As EventArgs)
        If Not IsNothing(ClipBoardDocumento) Then
            UbicarDocumentoPegado()
        End If
    End Sub

    Public Sub UbicarDocumentoPegado()
        Dim ventaSA As New documentoVentaAbarrotesSA
        With ClipBoardDocumento.documentoventaAbarrotes
            ' txtFecha.Value = .fechaDoc
            'txtSerie.Text = .serieVenta
            'txtNumero.Text = .numeroVenta
            'txtNumero.Visible = True
            'Dim codigoComprobante = .tipoDocumento
            'Select Case codigoComprobante
            '    Case "12.1", "03"
            '        ComboComprobante.Text = "BOLETA"
            '    Case "12.2", "01"
            '        ComboComprobante.Text = "FACTURA"

            '    Case "9907"
            '        ComboComprobante.Text = "NOTA DE VENTA"
            'End Select
            'ComboComprobante.SelectedValue = .tipoDocumento
            'ComboComprobante.Enabled = False
            dgvCompra.TableDescriptor.Columns("pumn").Width = 60
            dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
            dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
            dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

            dgvCompra.TableDescriptor.Columns("pume").Width = 0
            dgvCompra.TableDescriptor.Columns("vcme").Width = 0
            dgvCompra.TableDescriptor.Columns("igvme").Width = 0
            dgvCompra.TableDescriptor.Columns("totalme").Width = 0

            If Not IsNothing(entidad) Then
                'txtruc.Text = entidad.nrodoc
                'TextCliente.Tag = entidad.idEntidad
                'TextCliente.Text = entidad.nombreCompleto
                'TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                'txtruc.Visible = True
            Else
                ' TextCliente.Text = .nombrePedido
            End If
            txtGlosa.Text = .glosa
        End With

        'DETALLE DE LA COMPRA
        dgvCompra.Table.Records.DeleteAll()
        For Each i In ClipBoardDocumento.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList
            'Dim lote = loteSA.GetLoteByID(i.codigoLote)
            Dim productoInventory = ventaSA.GetInventoryProductoID(i.idItem, i.idAlmacenOrigen)

            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", productoInventory.stock.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(lote.productoSustentado = True, "Doc.", "Not."))

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", productoInventory.descripcionAlmacen)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)

            If productoInventory.menor > 0 Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "1")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.menor)
            ElseIf productoInventory.mayor > 0 Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "2")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.mayor)
            ElseIf productoInventory.granMayor > 0 Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "3")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.granMayor)
            Else
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "0")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("menor", productoInventory.menor)
            Me.dgvCompra.Table.CurrentRecord.SetValue("mayor", productoInventory.mayor)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gmayor", productoInventory.granMayor)

            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        btGrabar.Enabled = True
        TotalTalesXcolumna()
        If ListaBeneficios.Count > 0 Then
            TotalesColumnaDescuentos(ListaBeneficios)
        End If
        ConteoLabelVentas()
        '   TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        'Dim objEntidad As New entidadSA
        'Dim nEntidad As New entidad
        'Try

        '    txtSerieGuia.Text = ClipBoardDocumento.documentocompra.serie
        '    txtNumeroGuia.Text = ClipBoardDocumento.documentocompra.numeroDoc

        '    'CABECERA COMPROBANT
        '    cboMesCompra.SelectedValue = String.Format("{0:00}", ClipBoardDocumento.documentocompra.fechaDoc.Value.Month)
        '    TxtDia.Text = ClipBoardDocumento.documentocompra.fechaDoc.Value.Day
        '    cboAnio.Text = ClipBoardDocumento.documentocompra.fechaDoc.Value.Year
        '    txtFechaGuia.Value = ClipBoardDocumento.documentocompra.fechaDoc
        '    ComboComprobante.SelectedValue = ClipBoardDocumento.documentocompra.tipoDoc
        '    txtSerie.Text = ClipBoardDocumento.documentocompra.serie
        '    txtNumero.Text = ClipBoardDocumento.documentocompra.numeroDoc
        '    cboMoneda.SelectedValue = ClipBoardDocumento.documentocompra.monedaDoc

        '    Select Case cboMoneda.SelectedValue
        '        Case 1

        '            dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        '            dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        '            dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
        '            dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
        '            dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70
        '            dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50

        '            dgvCompra.TableDescriptor.Columns("pume").Width = 0
        '            dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        '            dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        '            dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        '            dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

        '            cboMoneda.SelectedValue = 1
        '            '      tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
        '        Case 2

        '            dgvCompra.TableDescriptor.Columns("pumn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

        '            dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50
        '            dgvCompra.TableDescriptor.Columns("pume").Width = 60
        '            dgvCompra.TableDescriptor.Columns("vcme").Width = 65
        '            dgvCompra.TableDescriptor.Columns("igvme").Width = 65
        '            dgvCompra.TableDescriptor.Columns("totalme").Width = 70
        '            dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
        '            cboMoneda.SelectedValue = 2
        '            '    tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
        '    End Select

        '    nEntidad = objEntidad.UbicarEntidadPorID(ClipBoardDocumento.documentocompra.idProveedor).First()
        '    txtruc.Text = nEntidad.nrodoc
        '    txtProveedor.Tag = nEntidad.idEntidad
        '    txtProveedor.Text = nEntidad.nombreCompleto

        '    txtTipoCambio.DecimalValue = ClipBoardDocumento.documentocompra.tcDolLoc
        '    txtIva.DoubleValue = ClipBoardDocumento.documentocompra.tasaIgv
        '    txtGlosa.Text = ClipBoardDocumento.documentocompra.glosa


        '    'DETALLE DE LA COMPRA
        '    dgvCompra.Table.Records.DeleteAll()

        '    For Each i In ClipBoardDocumento.documentocompra.documentocompradetalle.ToList

        '        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        '        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME)

        '        Select Case i.estadoPago
        '            Case TIPO_COMPRA.PAGO.PAGADO
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
        '            Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
        '        End Select

        '        Select Case i.bonificacion
        '            Case "S"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", True)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "S")
        '            Case "N"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
        '        End Select


        '        Select Case i.tipoExistencia
        '            Case "GS"

        '            Case "01"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
        '            Case "08"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")

        '        End Select



        '        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)



        '        Me.dgvCompra.Table.AddNewRecord.EndEdit()
        '    Next
        '    TotalTalesXcolumna()
        'Catch ex As Exception
        '    MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        'End Try

    End Sub

    Public Sub UbicarDocumentoImportado(documento As documento)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim entidadSA As New entidadSA
        With documento.documentoventaAbarrotes
            'txtFecha.Value = .fechaDoc
            'lblPerido.Text = .fechaPeriodo
            'txtSerie.Text = .serieVenta
            'txtNumero.Text = .numeroVenta
            'txtNumero.Visible = True
            'Dim codigoComprobante = .tipoDocumento
            'Select Case codigoComprobante
            '    Case "12.1", "03"
            '        ComboComprobante.Text = "BOLETA"
            '    Case "12.2", "01"
            '        ComboComprobante.Text = "FACTURA"

            '    Case "9907"
            '        ComboComprobante.Text = "NOTA DE VENTA"
            'End Select
            'ComboComprobante.SelectedValue = .tipoDocumento
            'ComboComprobante.Enabled = False
            dgvCompra.TableDescriptor.Columns("pumn").Width = 60
            dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
            dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
            dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

            dgvCompra.TableDescriptor.Columns("pume").Width = 0
            dgvCompra.TableDescriptor.Columns("vcme").Width = 0
            dgvCompra.TableDescriptor.Columns("igvme").Width = 0
            dgvCompra.TableDescriptor.Columns("totalme").Width = 0

            Dim entidad = .idCliente
            If entidad.ToString.Trim.Length > 0 Then
                Dim entidadSel = entidadSA.UbicarEntidadPorID(entidad).ToList
                'txtruc.Text = entidadSel.FirstOrDefault.nrodoc
                'TextCliente.Text = entidadSel.FirstOrDefault.nombreCompleto
                'TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                'txtruc.Visible = True
                'TextCliente.Tag = entidadSel.FirstOrDefault.idEntidad
            Else
                '  TextCliente.Text = .nombrePedido
            End If


            'If entidad.Count > 0 Then
            '    txtruc.Text = entidad.FirstOrDefault.nrodoc
            '    TextCliente.Text = entidad.FirstOrDefault.nombreCompleto
            '    TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            '    txtruc.Visible = True
            '    TextCliente.Tag = entidad.FirstOrDefault.idEntidad
            'Else

            'End If
            txtGlosa.Text = .glosa
        End With

        'DETALLE DE LA COMPRA
        dgvCompra.Table.Records.DeleteAll()
        For Each i In documento.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList
            'Dim lote = loteSA.GetLoteByID(i.codigoLote)
            Dim productoInventory = ventaSA.GetInventoryProductoID(i.idItem, i.idAlmacenOrigen)

            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", productoInventory.stock.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(lote.productoSustentado = True, "Doc.", "Not."))

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", productoInventory.descripcionAlmacen)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)

            If productoInventory.menor > 0 Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "1")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.menor)
            ElseIf productoInventory.mayor > 0 Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "2")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.mayor)
            ElseIf productoInventory.granMayor > 0 Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "3")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.granMayor)
            Else
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "0")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("menor", productoInventory.menor)
            Me.dgvCompra.Table.CurrentRecord.SetValue("mayor", productoInventory.mayor)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gmayor", productoInventory.granMayor)


            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        btGrabar.Enabled = True
        TotalTalesXcolumna()
        ConteoLabelVentas()
        '  TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        'Dim objEntidad As New entidadSA
        'Dim nEntidad As New entidad
        'Try

        '    txtSerieGuia.Text = ClipBoardDocumento.documentocompra.serie
        '    txtNumeroGuia.Text = ClipBoardDocumento.documentocompra.numeroDoc

        '    'CABECERA COMPROBANT
        '    cboMesCompra.SelectedValue = String.Format("{0:00}", ClipBoardDocumento.documentocompra.fechaDoc.Value.Month)
        '    TxtDia.Text = ClipBoardDocumento.documentocompra.fechaDoc.Value.Day
        '    cboAnio.Text = ClipBoardDocumento.documentocompra.fechaDoc.Value.Year
        '    txtFechaGuia.Value = ClipBoardDocumento.documentocompra.fechaDoc
        '    ComboComprobante.SelectedValue = ClipBoardDocumento.documentocompra.tipoDoc
        '    txtSerie.Text = ClipBoardDocumento.documentocompra.serie
        '    txtNumero.Text = ClipBoardDocumento.documentocompra.numeroDoc
        '    cboMoneda.SelectedValue = ClipBoardDocumento.documentocompra.monedaDoc

        '    Select Case cboMoneda.SelectedValue
        '        Case 1

        '            dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        '            dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        '            dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
        '            dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
        '            dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70
        '            dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50

        '            dgvCompra.TableDescriptor.Columns("pume").Width = 0
        '            dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        '            dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        '            dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        '            dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

        '            cboMoneda.SelectedValue = 1
        '            '      tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
        '        Case 2

        '            dgvCompra.TableDescriptor.Columns("pumn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

        '            dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50
        '            dgvCompra.TableDescriptor.Columns("pume").Width = 60
        '            dgvCompra.TableDescriptor.Columns("vcme").Width = 65
        '            dgvCompra.TableDescriptor.Columns("igvme").Width = 65
        '            dgvCompra.TableDescriptor.Columns("totalme").Width = 70
        '            dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
        '            cboMoneda.SelectedValue = 2
        '            '    tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
        '    End Select

        '    nEntidad = objEntidad.UbicarEntidadPorID(ClipBoardDocumento.documentocompra.idProveedor).First()
        '    txtruc.Text = nEntidad.nrodoc
        '    txtProveedor.Tag = nEntidad.idEntidad
        '    txtProveedor.Text = nEntidad.nombreCompleto

        '    txtTipoCambio.DecimalValue = ClipBoardDocumento.documentocompra.tcDolLoc
        '    txtIva.DoubleValue = ClipBoardDocumento.documentocompra.tasaIgv
        '    txtGlosa.Text = ClipBoardDocumento.documentocompra.glosa


        '    'DETALLE DE LA COMPRA
        '    dgvCompra.Table.Records.DeleteAll()

        '    For Each i In ClipBoardDocumento.documentocompra.documentocompradetalle.ToList

        '        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        '        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME)

        '        Select Case i.estadoPago
        '            Case TIPO_COMPRA.PAGO.PAGADO
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
        '            Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
        '        End Select

        '        Select Case i.bonificacion
        '            Case "S"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", True)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "S")
        '            Case "N"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
        '        End Select


        '        Select Case i.tipoExistencia
        '            Case "GS"

        '            Case "01"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
        '            Case "08"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")

        '        End Select



        '        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)



        '        Me.dgvCompra.Table.AddNewRecord.EndEdit()
        '    Next
        '    TotalTalesXcolumna()
        'Catch ex As Exception
        '    MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        'End Try

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolImportar.Click
        Try
            Dim f As New FormBuscarVentasGeneral
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim c = CType(f.Tag, documento)
                UbicarDocumentoImportado(c)
                dgvCompra.Focus()
                Me.dgvCompra.TableControl.CurrentCell.MoveTo(dgvCompra.Table.Records.Count - 1, 7, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
                Me.ActiveControl = Me.dgvCompra.TableControl
                dgvCompra.WantTabKey = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextMenor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub InsertarOfertaEnCanasta(be As oferta)

        Dim colBI = CalculoBaseImponible(be.precioventa, 1.18)
        Dim iva = CalculoIva(colBI, 0.18)


        With dgvCompra.Table
            .AddNewRecord.SetCurrent()
            .AddNewRecord.BeginEdit()
            .CurrentRecord.SetValue("codigo", be.id)
            .CurrentRecord.SetValue("gravado", "1")
            .CurrentRecord.SetValue("idProducto", be.id)
            .CurrentRecord.SetValue("item", be.descripcion)
            .CurrentRecord.SetValue("um", be.codigo)
            .CurrentRecord.SetValue("cantidad", 1)
            .CurrentRecord.SetValue("canDisponible", 1)
            .CurrentRecord.SetValue("vcmn", Math.Round(CDec(colBI), 2))
            '.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
            .CurrentRecord.SetValue("MontoSaldo", be.precioventa)

            .CurrentRecord.SetValue("vcme", 0)
            '.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
            .CurrentRecord.SetValue("igvmn", Math.Round(CDec(iva), 2))
            .CurrentRecord.SetValue("igvme", 0)
            .CurrentRecord.SetValue("tipoExistencia", "OF")
            .CurrentRecord.SetValue("marca", Nothing) ') If(productoBE.CustomLote.productoSustentado = True, "Doc.", "Not.")) 'Susuentado y no sustentado

            .CurrentRecord.SetValue("pumn", be.precioventa)
            .CurrentRecord.SetValue("pume", 0)

            .CurrentRecord.SetValue("puKardex", be.precioventa)
            .CurrentRecord.SetValue("pukardeme", be.precioventa)

            .CurrentRecord.SetValue("chPago", False)
            .CurrentRecord.SetValue("valPago", "No Pagado")

            .CurrentRecord.SetValue("chBonif", False)
            .CurrentRecord.SetValue("valBonif", "N")
            '   If .tipoExistencia <> "GS" Then
            .CurrentRecord.SetValue("almacen", 0)
            .CurrentRecord.SetValue("presentacion", "-")

            .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
            .CurrentRecord.SetValue("costoMN", 0)
            .CurrentRecord.SetValue("costoME", 0)
            .CurrentRecord.SetValue("tipoPrecio", 0)
            .CurrentRecord.SetValue("cboprecio", 0)
            .CurrentRecord.SetValue("cat", StatusCategoriaVenta.Productos)
            .CurrentRecord.SetValue("codigoLote", 0) ' productoBE.codigoLote)
            .CurrentRecord.SetValue("codBarra", be.codigo)
            .CurrentRecord.SetValue("empresa", be.idemprea)
            .CurrentRecord.SetValue("tipoventa", "V")
            .CurrentRecord.SetValue("cantidad2", 0)
            .AddNewRecord.EndEdit()
            .TableDirty = True
        End With
        TotalTalesXcolumna()
    End Sub

    Private Sub TextMayor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyDown
        If e.Inner.KeyCode = Keys.Delete Then
            'If Me.dgvCompra.Table.CurrentRecord IsNot Nothing Then
            '    Me.dgvCompra.Table.CurrentRecord.Delete()
            '    TotalTalesXcolumna()
            'End If
            'If dgvCompra.Table.Records.Count > 0 Then
            '    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
            '    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
            'End If
            'ConteoLabelVentas()
        ElseIf e.Inner.KeyCode = Keys.Up Or e.Inner.KeyCode = Keys.Down Then
            'If Me.dgvCompra.Table.CurrentRecord IsNot Nothing Then
            '    GetUbicarPrecio(Me.dgvCompra.Table.CurrentRecord)
            'End If

        End If
    End Sub

    Private Sub TextGMayor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormVentaGeneral_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FormVentaGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If dgvCompra.Table.Records.Count > 0 Then
        '    If ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then

        '    Else
        '        If MessageBox.Show("¿Desea salir de la venta?", "Salir de la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '            'If ListaEstadosFinancieros IsNot Nothing Then
        '            '    ListaEstadosFinancieros.Clear()
        '            'End If

        '            If ListaventasEnEspera IsNot Nothing Then
        '                If ListaventasEnEspera.Count > 0 Then
        '                    If MessageBox.Show("¿Tiene reservas de venta, desea salir de la venta?", "Salir de la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
        '                        e.Cancel = True
        '                    End If
        '                End If
        '            End If

        '            If ListaventasEnEspera IsNot Nothing Then
        '                ListaventasEnEspera.Clear()
        '            End If

        '            If ListaAlmacenes IsNot Nothing Then
        '                ListaAlmacenes.Clear()
        '            End If

        '            If ListaBeneficios IsNot Nothing Then
        '                ListaBeneficios.Clear()
        '            End If

        '            bgCombos.CancelAsync()
        '            BackgroundWorker1.CancelAsync()
        '            With FormInventarioCanastaTotales
        '                .GridTotales.Table.Records.DeleteAll()
        '                .txtFiltrar.Clear()
        '            End With
        '        Else
        '            e.Cancel = True
        '        End If
        '    End If

        'Else

        '    'If ListaEstadosFinancieros IsNot Nothing Then
        '    '    ListaEstadosFinancieros.Clear()
        '    'End If
        '    If ListaventasEnEspera IsNot Nothing Then
        '        ListaventasEnEspera.Clear()
        '    End If

        '    If ListaAlmacenes IsNot Nothing Then
        '        ListaAlmacenes.Clear()
        '    End If
        '    If ListaBeneficios IsNot Nothing Then
        '        ListaBeneficios.Clear()
        '    End If
        '    bgCombos.CancelAsync()
        '    'bgCombos.Dispose()
        '    'bgCombos = Nothing

        '    'bgVenta.Dispose()
        '    'bgVenta = Nothing

        '    BackgroundWorker1.CancelAsync()
        '    'BackgroundWorker1.Dispose()
        '    'BackgroundWorker1 = Nothing

        '    With FormInventarioCanastaTotales
        '        .GridTotales.Table.Records.DeleteAll()
        '        .txtFiltrar.Clear()
        '    End With
        'End If
    End Sub

    Private Sub cboMoneda_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanged
        Try
            If e.SelectedRecord IsNot Nothing Then
                GetUbicarPrecio(e.SelectedRecord.Record)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
        Try
            Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
            If cc.RowIndex > -1 Then
                If e.Inner.KeyCode = Keys.Up Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        If cc.RowIndex = 2 Then
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            GetUbicarPrecio(currenrecord)
                        Else
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            GetUbicarPrecio(currenrecord)
                        End If

                    End If
                ElseIf e.Inner.KeyCode = Keys.Down Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex + 1, cc.ColIndex), GridTableCellStyleInfo)
                        If style IsNot Nothing Then
                            ' Dim rows = dgvCompra.Table.Records.Count
                            If style.TableCellIdentity IsNot Nothing Then
                                Dim currenrecord = style.TableCellIdentity.DisplayElement.GetRecord()
                                If currenrecord IsNot Nothing Then
                                    GetUbicarPrecio(currenrecord)
                                End If
                            End If

                        End If

                    End If

                Else
                    cc.ConfirmChanges()
                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                    GetUbicarPrecio(currenrecord)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextMayorLeft_TextChanged(sender As Object, e As EventArgs) Handles TextMayorLeft.TextChanged

    End Sub

    Private Sub FormVentaGeneral_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub TextGMayorLeft_TextChanged(sender As Object, e As EventArgs) Handles TextGMayorLeft.TextChanged

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyUp
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        Dim style As GridTableCellStyleInfo = TryCast(cc.Renderer.CurrentStyle, GridTableCellStyleInfo)

        If style IsNot Nothing Then

            Select Case style.TableCellIdentity.Column.Name
                Case "cantidad"
                    If e.Inner.KeyData = Keys.Enter Then
                        'e.TableControl.Table.CurrentRecord.SetCurrent("pumn")
                        'e.TableControl.CurrentCell.MoveTo(cc.RowIndex, cc.ColIndex + 1, GridSetCurrentCellOptions.SetFocus)
                    End If
                Case "pumn"
                    If e.Inner.KeyData = Keys.Enter Then
                        e.TableControl.Table.CurrentRecord.SetCurrent("totalmn")
                    End If

                Case "pume"
                    If e.Inner.KeyData = Keys.Enter Then
                        e.TableControl.Table.CurrentRecord.SetCurrent("totalme")
                    End If

                Case "totalmn"
                    If e.Inner.KeyData = Keys.Enter Then
                        e.TableControl.Table.CurrentRecord.SetCurrent("cantidad")
                    End If

                Case "totalme"
                    If e.Inner.KeyData = Keys.Enter Then
                        e.TableControl.Table.CurrentRecord.SetCurrent("cantidad")
                    End If

                Case "codBarra"
                    e.TableControl.Table.CurrentRecord.SetCurrent("cantidad")
                Case Else
                    If e.Inner.KeyData = Keys.Enter Then
                        ' // e.TableControl.Table.CurrentRecord.SetCurrent("FirstColumnName")
                        e.TableControl.CurrentCell.MoveTo(cc.RowIndex, cc.ColIndex + 1, GridSetCurrentCellOptions.SetFocus)
                    End If
            End Select
        End If

    End Sub

    Private Sub btServicio_Click(sender As Object, e As EventArgs) Handles btServicio.Click
        Dim MonedaSel As String = String.Empty
        'Select Case cboMoneda.Text
        '    Case "NACIONAL"
        MonedaSel = "SOL"
        '    Case "EXTRANJERA"
        '        MonedaSel = "USD"

        'End Select
        Dim valida As Boolean

        'If tmpConfigInicio.FormatoVenta = "MKT" Then
        '    If RBVenta.Checked = True Then
        '        valida = True
        '    End If

        '    If RBProforma.Checked = True Then
        '        valida = False
        '    End If
        'Else
        Select Case ComboComprobante.Text
            Case "PROFORMA"
                valida = False
            Case Else
                valida = True
        End Select
        ' End If

        With FormServicioCanasta
            .monedaVenta = MonedaSel
            .validaSelPrecioVenta = True
            '.chCantidadPrevia.Checked = True
            .validaStocks = valida ' True
            .StartPosition = FormStartPosition.CenterScreen
            ' .Show(Me)
            .ShowDialog(Me)
            If dgvCompra.Table.Records.Count > 0 Then
                dgvCompra.Focus()
                Me.dgvCompra.TableControl.CurrentCell.MoveTo(dgvCompra.Table.Records.Count - 1, 7, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
                Me.ActiveControl = Me.dgvCompra.TableControl
                dgvCompra.WantTabKey = True


            End If
        End With
    End Sub

    Public Sub Commit(Confirmado As Boolean, idDocumento As Integer) Implements ICommitOperacionMKT.Commit
        If Confirmado = True Then
            'Me.KeyPreview = False
            LimpiarControles()
            objPleaseWait.Close()
            Alert = New Alert("Operación registrada", alertType.success)
            Alert.TopMost = True
            Alert.Show()
            With FormInventarioCanastaTotales
                .GridTotales.Table.Records.DeleteAll()
                .txtFiltrar.Clear()
            End With

            With FormServicioCanasta
                .GridTotales.Table.Records.DeleteAll()
                .txtFiltrar.Clear()
            End With

            'ToolStrip5.Focus()
            ToolStripButton1.Select()
            'ValidarKey = False
            'GetImpresionTicketsEspecialNota(idDocumento)
            'Me.KeyPreview = True
        End If
    End Sub

    'Public Sub Commit(Confirmado As Boolean) Implements ICommitOperacion .Commit
    '    If Confirmado = True Then
    '        LimpiarControles()
    '        ChPagoDirecto.Checked = True
    '        ChPagoAvanzado.Checked = False
    '        PagoDirectoCheck()
    '        objPleaseWait.Close()
    '        Alert = New Alert("Operación registrada", alertType.success)
    '        Alert.TopMost = True
    '        Alert.Show()
    '        With FormInventarioCanastaTotales
    '            .GridTotales.Table.Records.DeleteAll()
    '            .txtFiltrar.Clear()
    '        End With
    '        ToolStrip5.Focus()
    '        ToolStripButton1.Select()
    '    End If
    'End Sub

    Private Sub TextMenorLeft_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextMenorLeft.MouseDoubleClick
        Dim r As Record = dgvCompra.Table.CurrentRecord
        If r IsNot Nothing Then

            'Select Case cboMoneda.Text
            '    Case "NACIONAL"
            dgvCompra.Table.CurrentRecord.SetValue("pumn", TextMenorLeft.DecimalValue)
            '    Case "EXTRANJERA"
            '        dgvCompra.Table.CurrentRecord.SetValue("pume", TextMenorLeft.DecimalValue)
            'End Select
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", 1)
            dgvCompra.Refresh()
            Calculos()
            TotalTalesXcolumna()
            If ListaBeneficios.Count > 0 Then
                TotalesColumnaDescuentos(ListaBeneficios)
            End If
        Else
            MessageBox.Show("Debe seleccionar un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TextMayorLeft_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextMayorLeft.MouseDoubleClick
        Dim r As Record = dgvCompra.Table.CurrentRecord
        If r IsNot Nothing Then

            'Select Case cboMoneda.Text
            '    Case "NACIONAL"
            dgvCompra.Table.CurrentRecord.SetValue("pumn", TextMayorLeft.DecimalValue)
            '    Case "EXTRANJERA"
            '        dgvCompra.Table.CurrentRecord.SetValue("pume", TextMayorLeft.DecimalValue)
            'End Select

            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", 2)
            dgvCompra.Refresh()
            Calculos()
            TotalTalesXcolumna()
            If ListaBeneficios.Count > 0 Then
                TotalesColumnaDescuentos(ListaBeneficios)
            End If
        Else
            MessageBox.Show("Debe seleccionar un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TextGMayorLeft_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextGMayorLeft.MouseDoubleClick
        Dim r As Record = dgvCompra.Table.CurrentRecord
        If r IsNot Nothing Then
            'Select Case cboMoneda.Text
            '    Case "NACIONAL"
            dgvCompra.Table.CurrentRecord.SetValue("pumn", TextGMayorLeft.DecimalValue)
            '    Case "EXTRANJERA"
            '        dgvCompra.Table.CurrentRecord.SetValue("pume", TextGMayorLeft.DecimalValue)
            'End Select
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", 3)
            dgvCompra.Refresh()
            Calculos()
            TotalTalesXcolumna()
            If ListaBeneficios.Count > 0 Then
                TotalesColumnaDescuentos(ListaBeneficios)
            End If
        Else
            MessageBox.Show("Debe seleccionar un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton5_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'FormInventarioCanastaTotales = New FormInventarioCanastaTotales(cboalmacen.SelectedValue)
        'FormInventarioCanastaTotales.validaStocks = True
        'FormInventarioCanastaTotales.StartPosition = FormStartPosition.CenterScreen
        '  FormInventarioCanastaTotales.Show(Me)
        Dim MonedaSel As String = String.Empty
        'Select Case cboMoneda.Text
        '    Case "NACIONAL"
        MonedaSel = "SOL"
        'Case "EXTRANJERA"
        '    MonedaSel = "USD"

        '  End Select
        Dim valida As Boolean

        'If tmpConfigInicio.FormatoVenta = "MKT" Then
        '    If RBVenta.Checked = True Then
        '        valida = True
        '    End If

        '    If RBProforma.Checked = True Then
        '        valida = False
        '    End If
        'Else
        Select Case ComboComprobante.Text
            Case "PROFORMA"
                valida = False
            Case Else
                valida = True
        End Select
        '   End If



        With FormInventarioCanastaTotales
            .monedaVenta = MonedaSel
            .validaSelPrecioVenta = True
            .chCantidadPrevia.Checked = True
            .validaStocks = valida ' True
            .txtFiltrar.Clear()
            .StartPosition = FormStartPosition.CenterScreen
            ' .Show(Me)
            .ShowDialog(Me)
            If dgvCompra.Table.Records.Count > 0 Then
                dgvCompra.Focus()
                Me.dgvCompra.TableControl.CurrentCell.MoveTo(dgvCompra.Table.Records.Count - 1, 7, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
                Me.ActiveControl = Me.dgvCompra.TableControl
                dgvCompra.WantTabKey = True

                'Dim colIndex As Integer = Me.dgvCompra.TableDescriptor.FieldToColIndex(0)
                'Dim rowIndex As Integer = Me.dgvCompra.Table.Records(0).GetRowIndex()
                'Me.dgvCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                'Me.dgvCompra.Focus()
            End If
        End With


        'frmCanastaInventary = New frminfoInventario(cboalmacen.SelectedValue)
        'frmCanastaInventary.StartPosition = FormStartPosition.CenterScreen
        'frmCanastaInventary.Show(Me)
    End Sub

    'Private Sub TextCliente_TextChanged_1(sender As Object, e As EventArgs)
    '    TextCliente.ForeColor = Color.Black
    '    TextCliente.Tag = Nothing
    '    If TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
    '        txtruc.Visible = True
    '    Else
    '        txtruc.Visible = False
    '    End If
    'End Sub

    'Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs)
    '    Dim beneficioSA As New beneficioSA
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        If e.PopupCloseType = PopupCloseType.Done Then
    '            If LsvProveedor.SelectedItems.Count > 0 Then
    '                If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
    '                    Dim f As New frmCrearENtidades
    '                    f.CaptionLabels(0).Text = "Nuevo cliente"
    '                    f.strTipo = TIPO_ENTIDAD.CLIENTE
    '                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
    '                    f.StartPosition = FormStartPosition.CenterParent
    '                    f.ShowDialog()
    '                    If Not IsNothing(f.Tag) Then
    '                        Dim c = CType(f.Tag, entidad)
    '                        listaClientes.Add(c)
    '                        txtTipoDocClie.Text = c.tipoDoc
    '                        TextCliente.Text = c.nombreCompleto
    '                        txtruc.Text = c.nrodoc
    '                        TextCliente.Tag = c.idEntidad
    '                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                        txtruc.Visible = True
    '                        TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                    End If
    '                Else
    '                    TextCliente.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
    '                    TextCliente.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
    '                    TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                    txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
    '                    txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
    '                    txtruc.Visible = True
    '                    ListaBeneficios = New List(Of Business.Entity.beneficio)
    '                    ListaBeneficios = beneficioSA.BeneficioListaClienteProductions(New Business.Entity.beneficio With {.idCliente = Integer.Parse(TextCliente.Tag)})

    '                    If ListaBeneficios.Count > 0 Then
    '                        TotalesColumnaDescuentos(ListaBeneficios)
    '                    Else
    '                        TotalesColumnaDescuentos(ListaBeneficios)
    '                    End If


    '                    'TextBenefClienteBase.Text = beneficio.importeBase.GetValueOrDefault
    '                    'TextValorAfecto.Text = beneficio.valorConvertido

    '                    'Select Case beneficio.tipoAfectacion
    '                    '    Case "I"
    '                    '        TextTipoBeneficio.Text = "IMPORTE"
    '                    '    Case "C"
    '                    '        TextTipoBeneficio.Text = "CANTIDAD"
    '                    '    Case "P"
    '                    '        TextTipoBeneficio.Text = "PORCENTAJE"
    '                    'End Select

    '                End If
    '                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
    '            End If
    '        End If

    '        'Set focus back to textbox.
    '        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '            Me.TextCliente.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub TextCliente_TextChanged(sender As Object, e As EventArgs) Handles TextCliente.TextChanged
        TextCliente.ForeColor = Color.Black
        TextCliente.Tag = Nothing
        If TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
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
                            txtTipoDocClie.Text = c.tipoDoc
                            TextCliente.Text = c.nombreCompleto
                            txtruc.Text = c.nrodoc
                            TextCliente.Tag = c.idEntidad
                            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            txtruc.Visible = True
                            TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    Else
                        TextCliente.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                        TextCliente.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                        TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                        txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
                        txtruc.Visible = True
                        ListaBeneficios = New List(Of Business.Entity.beneficio)
                        ListaBeneficios = beneficioSA.BeneficioListaClienteProductions(New Business.Entity.beneficio With {.idCliente = Integer.Parse(TextCliente.Tag)})

                        If ListaBeneficios.Count > 0 Then
                            TotalesColumnaDescuentos(ListaBeneficios)
                        Else
                            TotalesColumnaDescuentos(ListaBeneficios)
                        End If


                        'TextBenefClienteBase.Text = beneficio.importeBase.GetValueOrDefault
                        'TextValorAfecto.Text = beneficio.valorConvertido

                        'Select Case beneficio.tipoAfectacion
                        '    Case "I"
                        '        TextTipoBeneficio.Text = "IMPORTE"
                        '    Case "C"
                        '        TextTipoBeneficio.Text = "CANTIDAD"
                        '    Case "P"
                        '        TextTipoBeneficio.Text = "PORCENTAJE"
                        'End Select

                    End If
                    'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextCliente.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCliente.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            Me.pcLikeCategoria.Size = New Size(319, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextCliente
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TextCliente.Text) Or n.nrodoc.StartsWith(TextCliente.Text)).ToList


            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            If consulta.Count <= 1 Then
                If MessageBox.Show("El cliente ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim f As New frmCrearENtidades(TextCliente.Text)
                    f.CaptionLabels(0).Text = "Nuevo cliente"
                    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, entidad)
                        TextCliente.Text = c.nombreCompleto
                        TextCliente.Tag = c.idEntidad
                        txtruc.Visible = True
                        txtruc.Text = c.nrodoc
                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        TextCliente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        listaClientes.Add(c)
                    End If

                End If

            End If
        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextCliente
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TextCliente.Text) Or n.nrodoc.StartsWith(TextCliente.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextCliente
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

    Private Sub ToolStripButton3_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Me.dgvCompra.Table.CurrentRecord IsNot Nothing Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
        If dgvCompra.Table.Records.Count > 0 Then
            dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
            dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
        End If
        ConteoLabelVentas()
    End Sub

#End Region
End Class