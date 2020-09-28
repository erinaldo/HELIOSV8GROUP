Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Imports System.Threading
Imports ProcesosGeneralesCajamiSoft
Imports System.Net
Imports System.IO

Public Class frmConfirmacionPedido
    Inherits frmMaster

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread
    Public Property IdTipoServicio As Integer
    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Public listaProductosNuevo As New List(Of personaBeneficio)
    Public Property idPadreDoc As Integer
    Public Property FormPurchase As UCEstructuraRecepcionCliente
    Public Property venta As List(Of documentoventaAbarrotes)

    Public Property ListaproductosVendidos As List(Of documentoventaAbarrotesDet)

    Public Property documentoPreVenta As New documento

    Public Property ListaDocumentoPreVenta As New List(Of documento)

    Private FormImpresionNuevo As FormImpresionEquivalencia

    Public Sub New(ID As List(Of Integer))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        FormatoGrid(GridCompra)

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        UbicarDocumentoVenta(ID)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.Escape
                Close()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub UbicarDocumentoVenta(idDocumento As List(Of Integer))
        Dim entidadSA As New entidadSA
        Dim ventaSA As New documentoVentaAbarrotesSA
        'Dim venta = ventaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = idDocumento})
        venta = ventaSA.GetListaVentaID(New Business.Entity.documento With {.ListaDocumentoID = idDocumento})

        'Dim ent = venta.CustomEntidad ' entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault
        If venta IsNot Nothing Then
            'VerCabeceraDocumento(venta, ent)
            VerDetalleVenta(venta)
        End If
    End Sub

    Private Sub VerDetalleVenta(venta As List(Of documentoventaAbarrotes))
        ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)

        Dim totalImporte As Decimal = 0.0
        Dim totalPedio As Integer = venta.Count

        For Each doc In venta
            ListaproductosVendidos = (doc.documentoventaAbarrotesDet.ToList)
        Next


        'ListaproductosVendidos = venta.documentoventaAbarrotesDet.ToList
        '     UCEstructuraCabeceraVentaV2.LoadCanastaVentas(UCEstructuraCabeceraVentaV2.ListaproductosVendidos)

        Dim articuloSA As New detalleitemsSA


        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("contenido")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("precioventa")
        dt.Columns.Add("vcmn")
        dt.Columns.Add("igvmn")
        dt.Columns.Add("pumn")
        dt.Columns.Add("totalmn")
        dt.Columns.Add("almacen")
        dt.Columns.Add("tipofraccion")
        dt.Columns.Add("bonificacion", GetType(Boolean))
        dt.Columns.Add("catalogo")
        dt.Columns.Add("descuentoMN")
        dt.Columns.Add("afectoInventario", GetType(Boolean))
        dt.Columns.Add("manipulacion")

        For Each i In ListaproductosVendidos
            totalImporte += i.importeMN
            Select Case i.tipoExistencia
                Case TipoExistencia.ServicioGasto
                    Dim art = articuloSA.GetUbicaProductoID(i.idItem)
                    i.CustomProducto = art
                    i.CustomCatalogo = Nothing
                    i.PrecioUnitarioVentaMN = Decimal.Parse(i.monto2)
                    i.CodigoCosto = i.secuencia
                    i.FlagBonif = i.bonificacion.ToString
                    dt.Rows.Add(i.CodigoCosto,
                          i.destino,
                          i.nombreItem,
                          i.unidad1,
                          0,
                          i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                          i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                          i.importeMN.GetValueOrDefault, 0,
                          0, i.bonificacion, 0, i.descuentoMN.GetValueOrDefault, True)
                Case Else
                    Dim art = articuloSA.GetUbicaProductoID(i.idItem)
                    i.CustomProducto = art
                    i.CustomCatalogo = i.CustomCatalogo
                    i.PrecioUnitarioVentaMN = Decimal.Parse(i.monto2)
                    i.CodigoCosto = i.secuencia
                    i.FlagBonif = i.bonificacion.ToString
                    dt.Rows.Add(i.CodigoCosto,
                          i.CustomProducto.origenProducto,
                          i.CustomProducto.descripcionItem,
                          i.CustomProducto.unidad1,
                          i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault,
                          i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                          i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                          i.importeMN.GetValueOrDefault, 0,
                          i.CustomEquivalencia.equivalencia_id, i.bonificacion, If(i.CustomCatalogo Is Nothing, "-", i.CustomCatalogo.idCatalogo), i.descuentoMN.GetValueOrDefault, True)
            End Select


            'dt.Rows.Add(i.CodigoCosto,
            '        i.destino,
            '        i.nombreItem,
            '        i.unidad1,
            '        i.unidad2,
            '        i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
            '        i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
            '        i.importeMN.GetValueOrDefault, 0,
            '        "-", i.bonificacion)
        Next

        'For Each i In UCEstructuraCabeceraVentaV2.ListaproductosVendidos
        '    dt.Rows.Add(i.secuencia,
        '            i.CustomProducto.origenProducto,
        '            i.CustomProducto.descripcionItem,
        '            i.CustomProducto.unidad1,
        '            i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault,
        '            i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
        '            i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
        '            i.importeMN.GetValueOrDefault, 0,
        '            i.CustomEquivalencia.detalle, i.bonificacion)
        'Next
        GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0
        GridCompra.DataSource = dt
        GridCompra.Refresh()
        'GetTotalesDocumento()

        lblNumeroPedido.Text = totalPedio
        lblImporteTotal.Text = totalImporte
    End Sub

    Private Sub VerCabeceraDocumento(venta As documentoventaAbarrotes, ent As entidad)
        Dim tipoVenta As String = Nothing
        Select Case venta.tipoVenta
            Case TIPO_VENTA.VENTA_ELECTRONICA
                ComboComprobante.Text = "VENTA"
            Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                ComboComprobante.Text = "PRE VENTA"
            Case TIPO_VENTA.NOTA_DE_VENTA
                ComboComprobante.Text = "NOTA DE VENTA"
            Case TIPO_COMPRA.OTRAS_SALIDAS
                ComboComprobante.Text = "OTRA SALIDA DE ALMACEN"
            Case TIPO_VENTA.COTIZACION
                ComboComprobante.Text = "PROFORMA"
        End Select

        'Select Case ComboComprobante.Text
        '    Case "VENTA"

        '        tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
        '    Case "PRE VENTA"
        '        tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO

        '    Case "NOTA DE VENTA"
        '        tipoVenta = TIPO_VENTA.NOTA_DE_VENTA
        '    Case "OTRA SALIDA DE ALMACEN"
        '        tipoVenta = TIPO_COMPRA.OTRAS_SALIDAS
        '    Case "PROFORMA"
        '        tipoVenta = TIPO_VENTA.COTIZACION
        'End Select

        'With UCEstructuraCabeceraVentaV2
        '    .TextDescuento.Enabled = False
        '    .TextSubTotal.DecimalValue = venta.ImporteNacional.GetValueOrDefault + venta.importeCostoMN.GetValueOrDefault
        '    .TextDescuento.DecimalValue = venta.importeCostoMN.GetValueOrDefault
        '    .TxtDia.DecimalValue = venta.fechaDoc.Value.Day
        '    .cboMesCompra.SelectedValue = String.Format("{0:00}", venta.fechaDoc.Value.Month)
        '    .TextAnio.DecimalValue = venta.fechaDoc.Value.Year
        '    .txtHora.Value = venta.fechaDoc.Value
        '    .cboMoneda.SelectedValue = venta.moneda
        '    .txtTipoCambio.DecimalValue = venta.tipoCambio.GetValueOrDefault
        '    .txtIva.DoubleValue = venta.tasaIgv
        '    .cboTipoDoc.SelectedValue = venta.tipoDocumento
        If ent IsNot Nothing Then
                If ent.tipoEntidad = "VR" Then
                '.RadioButton2.Checked = True
                TextProveedor.Tag = ent.idEntidad
                TextProveedor.Text = venta.nombrePedido
            Else
                '.RadioButton1.Checked = True
                TextNumIdentrazon.Text = ent.nrodoc
                TextProveedor.Text = ent.nombreCompleto
                TextProveedor.Tag = ent.idEntidad
            End If
            End If
        'End With
    End Sub

    Private Sub AgregarCanasta(listaProductos As List(Of personaBeneficio))
        Dim dt As New DataTable
        Dim conteo As Integer = 1

        dt.Columns.Add("idComponente") '0
        dt.Columns.Add("numero")
        dt.Columns.Add("dni") '2
        dt.Columns.Add("nombre")
        dt.Columns.Add("nacionalidad")
        dt.Columns.Add("sexo")
        dt.Columns.Add("action")

        For Each i In listaProductos
            dt.Rows.Add(i.idPersonaBeneficio,
                    conteo,
                    i.nroDocumento,
                    i.nombrePersona,
                    i.nacionalidad,
                    i.sexo,
                    "U"
                   )
            conteo = conteo + 1
        Next

        'dgvCompras.DataSource = dt
        'dgvCompras.Refresh()
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

    Private Function MappingDocumento(doc As documentoventaAbarrotes) As documento

        Dim fechaVenta = Date.Now

        MappingDocumento = New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = "1000",
        .fechaProceso = fechaVenta,
        .moneda = doc.moneda,
        .idEntidad = doc.idCliente,
        .entidad = doc.CustomEntidad.nombreCompleto,
        .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
        .nrodocEntidad = 0,
        .nroDoc = "0",'$"{UCEstructuraCabeceraVentaV2.txtSerie.Text}-{UCEstructuraCabeceraVentaV2.txtNumero.Text}",
        .idOrden = doc.CustomEntidad.nrodoc,
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

    End Function

    Private Sub MappingDocumentoCompraCabecera(be As documento, documentoRecuperado As documentoventaAbarrotes)
        Dim tipoVenta As String = String.Empty
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0

        Dim base1ME As Decimal = 0
        Dim base2ME As Decimal = 0

        Dim iva1 As Decimal = 0
        Dim iva1ME As Decimal = 0
        Dim iva2 As Decimal = 0
        Dim total As Decimal = 0 ' 
        Dim totalME As Decimal = 0 ' UCEstructuraDocumentocabecera.txtTotalPagar.DecimalValue

        Dim icbper As Decimal = 0
        Dim icbperME As Decimal = 0

        Select Case be.moneda
            Case "1"
                base1 = documentoRecuperado.bi01
                base2 = documentoRecuperado.bi02
                base1ME = documentoRecuperado.bi01us
                base2ME = documentoRecuperado.bi02us
                iva1 = documentoRecuperado.igv01
                iva1ME = documentoRecuperado.igv01us

                total = documentoRecuperado.ImporteNacional
                totalME = documentoRecuperado.ImporteExtranjero

                icbper = documentoRecuperado.icbper.GetValueOrDefault
                icbperME = documentoRecuperado.icbperus.GetValueOrDefault

                'Case "2"

                '    base1ME =
                '    base2ME = 

                '    base1 =
                '    base2 = 

                '    iva1ME =
                '    iva1 = 

                '    totalME =
                '    total = 

                '    icbperME = UCEstructuraCabeceraVentaV2.txtTotalIcbper.DecimalValue
                '    icbper = 
        End Select

        Select Case ComboComprobante.Text
            'Case "PEDIDO"
            '    tipoVenta = TIPO_VENTA.VENTA_PEDIDO
            'Case "VENTA"
            '    tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
            Case "PRE VENTA"
                tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO
                'Case "NOTA DE VENTA"
                '    tipoVenta = TIPO_VENTA.NOTA_DE_VENTA
                'Case "OTRA SALIDA DE ALMACEN"
                '    tipoVenta = TIPO_COMPRA.OTRAS_SALIDAS
                'Case "PROFORMA"
                ''    tipoVenta = TIPO_VENTA.COTIZACION
        End Select

        'Select Case be.tipoDoc
        '    Case "1000"
        '        tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO
        '    Case "9907"
        '        tipoVenta = TIPO_VENTA.NOTA_DE_VENTA
        '    Case "01", "03"
        '        tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
        '    Case "9903" ' PROFORMA
        '        tipoVenta = TIPO_VENTA.COTIZACION
        'End Select

        '.serie = UCEstructuraCabeceraVentaV2.txtSerie.Text.Trim,
        '.numeroDoc = UCEstructuraCabeceraVentaV2.txtNumero.Text.Trim,

        Dim obj As New documentoventaAbarrotes With
        {
        .codigoLibro = "8",
        .idEmpresa = be.idEmpresa,
        .idEstablecimiento = be.idCentroCosto,
        .fechaLaboral = Date.Now,
        .fechaDoc = be.fechaProceso,
        .fechaVcto = Nothing,
        .fechaPeriodo = GetPeriodo(be.fechaProceso, True),
        .tipoDocumento = "1000",
        .idCliente = be.idEntidad,
        .nombrePedido = be.entidad,
        .moneda = be.moneda,
        .tasaIgv = documentoRecuperado.tasaIgv,
        .tipoCambio = documentoRecuperado.tipoCambio,
        .bi01 = base1,
        .bi02 = base2,
        .isc01 = 0,
        .isc02 = 0,
        .igv01 = iva1,
        .igv02 = 0,
        .icbper = icbper,
        .icbperus = icbperME,
        .otc01 = 0,
        .otc02 = 0,
        .bi01us = base1ME,
        .bi02us = base2ME,
        .isc01us = 0,
        .isc02us = 0,
        .igv01us = iva1ME,
        .igv02us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .importeCostoMN = documentoRecuperado.importeCostoMN,
        .terminos = documentoRecuperado.terminos,
        .ImporteNacional = total,
        .ImporteExtranjero = totalME,
        .tipoVenta = tipoVenta,
        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
        .glosa = "Salida de mercadería",
        .sustentado = "S",
        .idPadre = documentoRecuperado.idDocumento,
        .estadoEntrega = "1",
        .usuarioActualizacion = be.usuarioActualizacion,' usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        'If btGrabar.Text = "Editar - F2" Then
        '    obj.idDocumento = venta.idDocumento
        '    obj.serieVenta = venta.serieVenta
        '    obj.serie = venta.serie
        '    obj.numeroVenta = venta.numeroVenta
        '    obj.numeroDoc = venta.numeroDoc
        'End If
        be.documentoventaAbarrotes = obj
        'Select Case UCCondicionesPago.RBNo.Checked
        '    Case True
        be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        '    Case Else
        '        If UCCondicionesPago.UCPagoCompletoDocumento.TextPagado.DecimalValue > 0 Then
        '            be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PagoParcial
        '        End If

        '        If UCCondicionesPago.UCPagoCompletoDocumento.TextSaldo.DecimalValue <= 0 Then
        '            be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        '        End If
        'End Select



        be.documentoventaAbarrotes.documentoventaAbarrotesDet = New List(Of documentoventaAbarrotesDet)
    End Sub

    Private Sub MappingDocumentoCompraCabeceraDetalle(obj As documento)
        Dim objDet As documentoventaAbarrotesDet
        Dim precUnitEquivalencia As Decimal = 0
        For Each i In ListaproductosVendidos.Where(Function(o) o.idDocumento = obj.documentoventaAbarrotes.idPadre).ToList

            Select Case i.tipoExistencia
                Case TipoExistencia.ServicioGasto
                    objDet = New documentoventaAbarrotesDet With
                            {
                            .tasaIcbper = 0,
                            .montoIcbper = 0,
                            .AfectoInventario = i.AfectoInventario,
                            .CodigoCosto = i.CodigoCosto,
                            .CustomProducto = i.CustomProducto,
                            .catalogo_id = 0,
                            .idItem = i.CustomProducto.codigodetalle,
                            .nombreItem = i.CustomProducto.descripcionItem,
                            .tipoExistencia = i.CustomProducto.tipoExistencia,
                            .destino = i.CustomProducto.origenProducto,
                            .unidad1 = i.CustomProducto.unidad1,
                            .monto1 = i.monto1,
                            .equivalencia_id = 0,
                            .unidad2 = Nothing,
                            .monto2 = i.PrecioUnitarioVentaMN,
                            .precioUnitario = i.precioUnitario.GetValueOrDefault,
                            .precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault,
                            .importeMN = i.importeMN,
                            .importeME = i.importeME.GetValueOrDefault,
                            .montokardex = i.montokardex,
                            .montoIsc = 0,
                            .montoIgv = i.montoIgv,
                            .otrosTributos = 0,
                            .montokardexUS = i.montokardex.GetValueOrDefault,
                            .montoIscUS = 0,
                            .montoIgvUS = i.montoIgvUS.GetValueOrDefault,
                            .otrosTributosUS = 0,
                            .entregado = "1",
                            .estadoPago = i.estadoPago,
                            .estadoEntrega = "PN",
                            .detalleAdicional = i.detalleAdicional,
                            .tipobeneficio = i.tipobeneficio,
                            .bonificacion = Boolean.Parse(i.FlagBonif),
                            .estadoDistribucion = "A",
                            .idDistribucion = txtInfraestructura.Tag,
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }

                Case Else
                    If i.CustomEquivalencia.fraccionUnidad <= 0 Then
                        Throw New Exception($"Debe ingresar un factor de conversión > 0, para el Producto-{i.CustomProducto.descripcionItem}")
                    End If
                    'precUnitEquivalencia = i.monto1 * i.CustomEquivalencia.fraccionUnidad

                    If ComboComprobante.Text = "OTRA SALIDA DE ALMACEN" Then

                    Else
                        If i.importeMN.GetValueOrDefault <= 0 Then
                            Throw New Exception($"Debe ingresar un importe de venta > 0, para el Producto-{i.CustomProducto.descripcionItem}")
                        End If
                    End If

                    objDet = New documentoventaAbarrotesDet With
                            {
                            .tasaIcbper = i.tasaIcbper,
                            .detalleAdicional = i.detalleAdicional,
                            .montoIcbper = i.montoIcbper,
                            .AfectoInventario = i.AfectoInventario,
                            .estadoMovimiento = i.AfectoInventario.ToString(),
                            .CodigoCosto = i.CodigoCosto,
                            .CustomEquivalencia = i.CustomEquivalencia,
                            .CustomProducto = i.CustomProducto,
                            .CustomCatalogo = i.CustomCatalogo,
                            .catalogo_id = i.CustomCatalogo.idCatalogo,
                            .idItem = i.CustomProducto.codigodetalle,
                            .nombreItem = i.CustomProducto.descripcionItem,
                            .tipoExistencia = i.CustomProducto.tipoExistencia,
                            .destino = i.CustomProducto.origenProducto,
                            .unidad1 = i.CustomProducto.unidad1,
                            .monto1 = i.monto1,
                            .equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                            .unidad2 = Nothing,
                            .monto2 = i.PrecioUnitarioVentaMN,
                            .precioUnitario = i.monto1 * i.CustomEquivalencia.fraccionUnidad,'   i.precioUnitario.GetValueOrDefault,
                            .precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault,
                            .importeMN = i.importeMN,
                            .importeME = i.importeME.GetValueOrDefault,
                            .montokardex = i.montokardex,
                            .montoIsc = 0,
                            .montoIgv = i.montoIgv,
                            .otrosTributos = 0,
                            .montokardexUS = i.montokardex.GetValueOrDefault,
                            .montoIscUS = 0,
                            .montoIgvUS = i.montoIgvUS.GetValueOrDefault,
                            .otrosTributosUS = 0,
                            .entregado = "1",
                            .estadoPago = i.estadoPago,
                                .estadoEntrega = "PN",
                            .bonificacion = Boolean.Parse(i.FlagBonif),
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .tipobeneficio = i.tipobeneficio,
                            .estadoDistribucion = "A",
                            .idDistribucion = txtInfraestructura.Tag,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }
                    If i.CustomProducto.tipoExistencia = TipoExistencia.Kit Then
                        'AgregarArticulosConexos(i.CustomProducto.detalleitems_conexo.ToList, obj, i.monto1)

                    End If

            End Select


            obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet)
        Next
    End Sub


    Private Sub GridCompra_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridCompra.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 22 Then
                e.Inner.Style.Description = "Anular"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridCompra.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 22 Then
                Dim tipoModalidad = GridCompra.TableModel(e.Inner.RowIndex, 6).CellValue
                Dim precioMenor = GridCompra.TableModel(e.Inner.RowIndex, 8).CellValue
                Dim precioMenorME = GridCompra.TableModel(e.Inner.RowIndex, 9).CellValue
                Dim precioMayor = GridCompra.TableModel(e.Inner.RowIndex, 10).CellValue
                Dim precioMayorME = GridCompra.TableModel(e.Inner.RowIndex, 11).CellValue
                Dim preciogranmayor = GridCompra.TableModel(e.Inner.RowIndex, 12).CellValue
                Dim preciogranmayorME = GridCompra.TableModel(e.Inner.RowIndex, 13).CellValue
                Dim idProducto = GridCompra.TableModel(e.Inner.RowIndex, 16).CellValue

                'If CheckboxMoneda.Checked = True Then
                '    GrabarPrecio(precioMenor, precioMenorME,
                '             precioMayor, precioMayorME,
                '             preciogranmayor, preciogranmayorME,
                '             idProducto, tipoModalidad)
                'Else

                'GrabarPrecio(precioMenor, precioMayor, preciogranmayor, idProducto, tipoModalidad)

                'End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            Dim ventaSA As New documentoVentaAbarrotesSA
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura

            Dim Vendedor = GetCodigoVendedor()
            If Vendedor Is Nothing Then
                Throw New Exception("Debe indicar el codigo del vendedor!")
            End If
            documentoPreVenta.usuarioActualizacion = Vendedor.IDUsuario

            For Each documento In venta
                documentoPreVenta = MappingDocumento(documento)

                MappingDocumentoCompraCabecera(documentoPreVenta, documento)
                MappingDocumentoCompraCabeceraDetalle(documentoPreVenta)

                Dim doc = ventaSA.GrabarVentaEquivalenciaXInfra(documentoPreVenta)

            Next

            If GridCompra.Table.Records.Count > 0 Then

                'Dim doc = ventaSA.GrabarVentaEquivalenciaXInfra(documentoPreVenta)

                distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                distribucionInfraestructuraBE.idDistribucion = txtInfraestructura.Tag
                distribucionInfraestructuraBE.estado = "P"
                distribucionInfraestructuraSA.updateDistribucionxID(distribucionInfraestructuraBE)

                FormImpresionNuevo = New FormImpresionEquivalencia(ListaproductosVendidos, True)  ' frmVentaNuevoFormato
                FormImpresionNuevo.tienda = ""
                FormImpresionNuevo.FormaPago = "2"
                'FormImpresionNuevo.DocumentoID = doc.idDocumento
                FormImpresionNuevo.Email = ""
                FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                FormImpresionNuevo.ShowDialog(Me)

            Else
                MessageBox.Show("No existe productos ")
            End If

            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Close()
    End Sub
End Class