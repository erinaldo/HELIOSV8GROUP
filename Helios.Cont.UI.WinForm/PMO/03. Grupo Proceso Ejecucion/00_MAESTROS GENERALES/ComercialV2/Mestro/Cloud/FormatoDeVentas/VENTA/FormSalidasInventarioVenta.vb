Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class FormSalidasInventarioVenta
#Region "Attributes"
    Public Property almacenListado As List(Of almacen)
    Public Property almacenSA As New almacenSA
    Public Property usercontrol As UserControlCanastaInventario
    Dim popup As Popup
    Public listaProductos As List(Of detalleitems)
    Public Property ListaproductosVendidos As List(Of documentoventaAbarrotesDet)
#End Region

#Region "Constructors"
    Public Sub New(be As documentoventaAbarrotes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetEstablecimientos()
        GetAlmacenes()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        '  FormatoGridAvanzado(GridTotales, False, False, 8.0F)
        '   listaEquivalencias = New List(Of detalleitem_equivalencias)
        ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)
        'FormatoGrid(GridCompra)
        FormatoGridBlack(GridCompra, False)
        '  FormatoGrid(GridTotales)
        LoadTablaEquivalencias()

        '  UCCanastaDeVentas = New UCCanstaDeVentas(Me)
        usercontrol = New UserControlCanastaInventario(Me)
        popup = New Popup(usercontrol)
        popup.Resizable = True

        'AddHandler usercontrol.OKEvent, AddressOf ucB_OKEvent
        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        Me.GridCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.Trimming = StringTrimming.EllipsisCharacter
        Me.GridCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.HorizontalAlignment = GridHorizontalAlignment.Left
        Me.GridCompra.TableControl.CellToolTip.AutomaticDelay = 25000

        lblUnidadNegocio.Text = GEstableciento.NombreEstablecimiento
        lblUnidadNegocio.Tag = GEstableciento.IdEstablecimiento

        UbicarDocumento(be)

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetEstablecimientos()
        GetAlmacenes()
        LinkLabel4.Visible = True
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        '  FormatoGridAvanzado(GridTotales, False, False, 8.0F)
        '   listaEquivalencias = New List(Of detalleitem_equivalencias)
        ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)
        'FormatoGrid(GridCompra)
        FormatoGridBlack(GridCompra, False)
        '  FormatoGrid(GridTotales)
        LoadTablaEquivalencias()

        '  UCCanastaDeVentas = New UCCanstaDeVentas(Me)
        usercontrol = New UserControlCanastaInventario(Me)
        popup = New Popup(usercontrol)
        popup.Resizable = True

        'AddHandler usercontrol.OKEvent, AddressOf ucB_OKEvent
        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        Me.GridCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.Trimming = StringTrimming.EllipsisCharacter
        Me.GridCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.HorizontalAlignment = GridHorizontalAlignment.Left
        Me.GridCompra.TableControl.CellToolTip.AutomaticDelay = 25000

        LabelEmpresa.Text = Gempresas.NomEmpresa
        LabelEmpresa.Tag = Gempresas.IdEmpresaRuc

        lblUnidadNegocio.Text = GEstableciento.NombreEstablecimiento
        lblUnidadNegocio.Tag = GEstableciento.IdEstablecimiento

    End Sub


#End Region

#Region "Methods"

    Private Sub GetComboAlmacenDestino()
        Dim almacenDestino = almacenListado.Where(Function(o) o.idEstablecimiento = ComboUnidadDest.SelectedValue And o.idAlmacen <> cboAlmacen.SelectedValue).ToList
        ComboAlmacenDestino.ValueMember = "idAlmacen"
        ComboAlmacenDestino.DisplayMember = "descripcionAlmacen"
        ComboAlmacenDestino.DataSource = almacenDestino
    End Sub

    Private Sub UbicarEmpresa()
        Dim emprersaSA As New empresaSA

        ComboEmpresa.DataSource = emprersaSA.ObtenerListaEmpresas.Where(Function(o) o.idEmpresa <> Gempresas.IdEmpresaRuc).ToList
        ComboEmpresa.DisplayMember = "razonSocial"
        ComboEmpresa.ValueMember = "idEmpresa"

    End Sub

    Private Sub UbicarDocumento(be As documentoventaAbarrotes)
        cboAlmacen.SelectedValue = be.documentoventaAbarrotesDet.FirstOrDefault.CustomAlmacenPartida.idAlmacen
        ComboAlmacenDestino.SelectedValue = be.documentoventaAbarrotesDet.FirstOrDefault.CustomAlmacenLlegada.idAlmacen
        ChVentaLote.Enabled = False
        LoadCanastaVentas(be.documentoventaAbarrotesDet.ToList)
        GridCompra.TableDescriptor.AllowEdit = False
    End Sub

    Private Function MappingDocumento() As documento
        Dim tipoOper As String
        Dim empesaIdDes As String = String.Empty

        If (chEmpresa.Checked = True) Then
            empesaIdDes = ComboEmpresa.SelectedValue
        ElseIf (chEmpresa.Checked = False) Then
            empesaIdDes = Gempresas.IdEmpresaRuc
        End If

        tipoOper = General.StatusTipoOperacion.TRANSFERENCIA_ENTRE_ALMACENES

        MappingDocumento = New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEmpresaDes = empesaIdDes,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idEstablecimientoTransaccion = ComboUnidadDest.SelectedValue,
        .idProyecto = 0,
        .tipoDoc = "9907",
        .fechaProceso = DateTime.Now,' fechaVenta,
        .moneda = "1",
        .idEntidad = TextProveedor.Tag,
        .entidad = TextProveedor.Text,
        .tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL,
        .nrodocEntidad = TextNumIdentrazon.Text,
        .nroDoc = "0",'$"{UCEstructuraCabeceraVentaV2.txtSerie.Text}-{UCEstructuraCabeceraVentaV2.txtNumero.Text}",
        .idOrden = 0,
        .tipoOperacion = tipoOper,'StatusTipoOperacion.VENTA,
        .ventaConLotes = IIf(ChVentaLote.Checked = True, True, False),
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now,
        .tipo = "TEA",
        .IdPerfil = usuario.IDRol
        }

        'If btGrabar.Text = "Editar - F2" Then
        '    MappingDocumento.idDocumento = venta.idDocumento
        'End If

    End Function

    Private Sub MappingDocumentoCompraCabecera(be As documento)
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

        base1 = 0
        base2 = 0
        base1ME = 0
        base2ME = 0
        iva1 = 0
        iva1ME = 0

        total = 0
        totalME = 0

        icbper = 0
        icbperME = 0

        tipoVenta = TIPO_COMPRA.TRANSFERENCIA_ENTRE_ALMACEN

        Dim obj As New documentoventaAbarrotes With
        {
        .codigoLibro = "8",
        .tipoOperacion = be.tipoOperacion,
        .idEmpresa = be.idEmpresa,
        .idEmpresaDes = be.idEmpresaDes,
        .idEstablecimiento = be.idCentroCosto,
        .idEstablecimientoDestino = ComboUnidadDest.SelectedValue,
        .fechaLaboral = Date.Now,
        .fechaDoc = be.fechaProceso,
        .fechaVcto = Nothing,
        .fechaPeriodo = GetPeriodo(be.fechaProceso, True),
        .tipoDocumento = be.tipoDoc,
        .idCliente = be.idEntidad,
        .nombrePedido = be.entidad,
        .moneda = be.moneda,
        .tasaIgv = 0,
        .tipoCambio = 1,
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
        .importeCostoMN = 0,
        .terminos = "TRANSFERENCIA",
        .ImporteNacional = total,
        .ImporteExtranjero = totalME,
        .tipoVenta = tipoVenta,
        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
        .glosa = "TRANSFERENCIA de mercadería",
        .sustentado = "S",
        .idPadre = 0,
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
        For Each i In ListaproductosVendidos

            '' se sesactivo por que no se utilkiza
            If i.CustomEquivalencia.contenido_neto <= 0 Then
                Throw New Exception($"Debe ingresar un factor de conversión > 0, para el Producto-{i.CustomProducto.descripcionItem}")
            End If

            'precUnitEquivalencia = i.monto1 * i.CustomEquivalencia.fraccionUnidad

            objDet = New documentoventaAbarrotesDet With
                            {
                            .tasaIcbper = i.tasaIcbper,
                            .idAlmacenOrigen = cboAlmacen.SelectedValue,
                            .idalmacenDestino = ComboAlmacenDestino.SelectedValue,
                            .categoria = ComboAlmacenDestino.SelectedValue,
                            .detalleAdicional = i.detalleAdicional,
                            .montoIcbper = i.montoIcbper,
                            .AfectoInventario = True,
                            .estadoMovimiento = "True",
                            .CodigoCosto = i.CodigoCosto,
                            .CustomEquivalencia = i.CustomEquivalencia,
                            .ContenidoNetoUnidadComercialMaxima = i.ContenidoNetoUnidadComercialMaxima.GetValueOrDefault,
                            .CustomProducto = i.CustomProducto,
                            .Customlote = i.Customlote,
                            .codigoLote = i.codigoLote,
                            .CustomCatalogo = Nothing,'i.CustomCatalogo,
                            .catalogo_id = 0,'i.CustomCatalogo.idCatalogo,
                            .idItem = i.CustomProducto.codigodetalle,
                            .nombreItem = i.CustomProducto.descripcionItem,
                            .tipoExistencia = i.CustomProducto.tipoExistencia,
                            .destino = i.CustomProducto.origenProducto,
                            .unidad1 = i.CustomProducto.unidad1,
                            .monto1 = i.monto1,
                            .equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                            .unidad2 = Nothing,
                            .monto2 = i.PrecioUnitarioVentaMN,
                            .precioUnitario = i.monto1 * i.CustomEquivalencia.contenido_neto,'   i.precioUnitario.GetValueOrDefault,
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
                            .bonificacion = False,
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .tipobeneficio = i.tipobeneficio,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }


            '  objDet.idAlmacenOrigen = i.idAlmacenOrigen

            'If btGrabar.Text = "Editar - F2" Then
            '    objDet.idDocumento = venta.idDocumento
            '    objDet.secuencia = i.secuencia
            'End If

            obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet)
        Next
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

    Private Function validarCanastaDeVentas(obj As documento) As Boolean
        validarCanastaDeVentas = True


        Dim CantidadesCero = obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Where(Function(o) o.monto1 <= 0).Count

        If CantidadesCero > 0 Then
            validarCanastaDeVentas = False
        End If

    End Function
    Private Sub Grabarventa()
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Dim obj As New documento
        Try

            Dim cajaActiva

            If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then


                cajaActiva = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

                If cajaActiva Is Nothing Then
                    ListaCajasActivas = cajaUsuaroSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                     .estadoCaja = "A"
                                                                     })
                    Throw New Exception("La Caja Administrativa no esta Abierta ")

                End If

            ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

                cajaActiva = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario And o.IDRol = usuario.IDRol).SingleOrDefault

                If cajaActiva Is Nothing Then
                    ListaCajasActivas = cajaUsuaroSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                     .estadoCaja = "A"
                                                                     })
                    Throw New Exception("Su usuario  no tiene una Caja abierta ")

                End If
            Else
                MessageBox.Show("Su Cargo no esta configurado")
                Exit Sub
            End If


            obj = MappingDocumento()
            'Dim Vendedor = GetCodigoVendedor()
            'If Vendedor Is Nothing Then
            '    Throw New Exception("Debe indicar el codigo del vendedor!")
            'End If
            obj.usuarioActualizacion = usuario.IDUsuario

            MappingDocumentoCompraCabecera(obj)
            MappingDocumentoCompraCabeceraDetalle(obj)

            If validarCanastaDeVentas(obj) Then
                '   obj.AfectaInventario = SwitchInventario.Value
                '  Dim ListaPagos = obj.ListaCustomDocumento
                Dim doc = ventaSA.GrabarInventarioEquivalenciaTranferencia(obj)

                MessageBox.Show("Operación registrada!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
                '  LimpiarControles()
                'Close()
            Else
                MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Verificar el detalle de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btGrabar.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub LoadTablaEquivalencias()
        Me.GridCompra.TableDescriptor.Columns("tipofraccion").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridCompra.TableDescriptor.Columns("tipofraccion").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
        Me.GridCompra.TableDescriptor.Columns("tipofraccion").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        Me.GridCompra.TableDescriptor.Columns("tipofraccion").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridCompra.TableDescriptor.Columns("tipofraccion").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCell


        Me.GridCompra.TableDescriptor.Columns("catalogo").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridCompra.TableDescriptor.Columns("catalogo").Appearance.AnyRecordFieldCell.DisplayMember = "nombre_corto"
        Me.GridCompra.TableDescriptor.Columns("catalogo").Appearance.AnyRecordFieldCell.ValueMember = "idCatalogo"

        '     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
        Me.GridCompra.TableDescriptor.Columns("catalogo").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Public Sub AgregarProductoDetalleVenta(cantidad As Decimal, idProductoSel As Integer, eq As detalleitem_equivalencias, stock As Decimal?, Optional lote As recursoCostoLote = Nothing)
        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = idProductoSel
        Dim total As Decimal = 0
        Dim canti As Decimal = cantidad
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0
        'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        total = 0
        baseImponible = 0
        Iva = 0

        If producto IsNot Nothing Then
            'Dim listaUnidadesComerciales = producto.detalleitem_equivalencias.ToList
            'Dim UnidadComercialMaxima = listaUnidadesComerciales.Where(Function(o) o.flag = "MAX").SingleOrDefault

            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()

            Select Case tmpConfigInicio.FormatoVenta
                Case "FACT"
                    obj.AfectoInventario = False
                Case Else
                    obj.AfectoInventario = producto.AfectoStock.GetValueOrDefault ' True
            End Select

            obj.CodigoCosto = cod
            obj.ContenidoNetoUnidadComercialMaxima = eq.contenido_neto ' UnidadComercialMaxima.contenido ' UnidadComercialMaxima.fraccionUnidad
            obj.idItem = producto.codigodetalle
            obj.CustomProducto = producto
            obj.CustomEquivalencia = eq
            obj.monto1 = cantidad
            AddItemVentaDetalle(producto, obj)
            obj.unidad2 = eq.detalle
            obj.montokardex = baseImponible
            obj.montoIgv = Iva
            obj.importeMN = total
            obj.PrecioUnitarioVentaMN = 0
            obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            obj.descuentoMN = 0
            obj.tasaIcbper = producto.otroImpuesto
            obj.montoIcbper = producto.otroImpuesto * cantidad
            obj.stock = stock
            If ChVentaLote.Checked Then
                obj.codigoLote = lote.codigoLote
                obj.Customlote = lote
            End If

            'obj.CustomDocumentoCaja = New List(Of documentoCaja)
            ListaproductosVendidos.Add(obj)
            'LoadCanastaVentas(ListaproductosVendidos)
            'GetTotalesDocumento()

            '#Region "Beneficios"
            '            Dim descuentoConfigurado = GetBeneficioItem(obj)
            '            If descuentoConfigurado IsNot Nothing Then

            '                Select Case descuentoConfigurado.tipobeneficio
            '                    Case "DESCUENTO"
            '                        If descuentoConfigurado IsNot Nothing Then
            '                            obj.descuentoMN = descuentoConfigurado.valor_beneficio
            '                            'r.SetValue("descuentoMN", descuentoConfigurado.valor_beneficio)
            '                            total = total - descuentoConfigurado.valor_beneficio.GetValueOrDefault
            '                            obj.importeMN = total
            '                            '.SetValue("totalmn", total)
            '                        End If
            '                        'Dim sub_total As Decimal = canti * item.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
            '                        'Dim total As Decimal = sub_total * precioVenta '

            '                        Select Case obj.destino
            '                            Case 2
            '                                baseImponible = total
            '                                Iva = 0
            '                            Case Else
            '                                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
            '                                Iva = Math.Round(total - baseImponible, 2)
            '                        End Select

            '                        obj.montokardex = baseImponible
            '                        obj.montoIgv = Iva
            '                        'r.SetValue("vcmn", baseImponible)
            '                        'r.SetValue("igvmn", Iva)
            '                        'r.SetValue("descuentoMN", descuentoItem)
            '                        obj.importeMN = total
            '                        obj.montoIcbper = 0
            '                        'r.SetValue("totalmn", total)
            '                        'r.SetValue("totalafect", 0)
            '                    Case "OFERTA"

            '                End Select
            '            End If


            '#End Region

            LoadCanastaVentas(ListaproductosVendidos)
            'GetTotalesDocumento()

        End If

        ' MsgBox(listViewItem.SubItems(1).Text)
    End Sub

    Public Sub LoadCanastaVentas(listaProductos As List(Of documentoventaAbarrotesDet))
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("item")
        dt.Columns.Add("detalle")
        dt.Columns.Add("um")
        dt.Columns.Add("contenido")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("cantidadtotal")
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
        dt.Columns.Add("tipoAfectacion")
        dt.Columns.Add("afectacion")
        dt.Columns.Add("totalafect")
        dt.Columns.Add("disponible")
        dt.Columns.Add("lote")


        For Each i In listaProductos

            dt.Rows.Add(i.CodigoCosto,
                    i.CustomProducto.origenProducto,
                    i.CustomProducto.descripcionItem, "",
                    i.CustomProducto.unidad1,
                    i.CustomEquivalencia.contenido_neto.GetValueOrDefault,
                    i.monto1,
                    i.monto1 * i.CustomEquivalencia.contenido_neto.GetValueOrDefault,
                    i.PrecioUnitarioVentaMN.GetValueOrDefault,
                    i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                    i.importeMN.GetValueOrDefault, 0,
                    i.CustomEquivalencia.equivalencia_id, If(i.FlagBonif = "True", True, False), Nothing, i.descuentoMN.GetValueOrDefault, i.AfectoInventario,
                    If(i.CustomProducto.tipoOtroImpuesto = "ICBPER", "ICBPER", "-"), i.CustomProducto.otroImpuesto.GetValueOrDefault, i.CustomProducto.otroImpuesto.GetValueOrDefault,
i.stock, i.codigoLote)

            If i.CustomListaVentaDetalle IsNot Nothing Then
                'If i.CustomListaVentaDetalle.Count > 0 Then
                '    MappingDetalleVentaInherits(i.CustomListaVentaDetalle.ToList, dt)
                'End If
            End If


        Next
        GridCompra.DataSource = dt
        GridCompra.Refresh()
    End Sub

    Private Sub AddItemVentaDetalle(producto As detalleitems, obj As documentoventaAbarrotesDet)

        obj.idItem = producto.codigodetalle
        obj.nombreItem = producto.descripcionItem
        obj.tipoExistencia = producto.tipoExistencia
        obj.destino = producto.origenProducto
        obj.unidad1 = producto.unidad1
        obj.unidad2 = "0"
        obj.monto2 = 0
        obj.precioUnitario = 0
        obj.precioUnitarioUS = 0
        obj.importeMN = 0
        obj.importeME = 0
        obj.montokardex = 0
        obj.montoIsc = 0
        obj.montoIgv = 0
        obj.otrosTributos = 0
        obj.montokardexUS = 0
        obj.entregado = 0
        obj.estadoPago = "PN"
        obj.estadoEntrega = "SI"
        obj.idCajaUsuario = 0
        obj.FlagBonif = "False"
        obj.usuarioModificacion = usuario.IDUsuario
        obj.fechaModificacion = Date.Now

    End Sub

    Sub BuscarProducto()
        Dim catalagoDefault As Object
        Dim listaSA As New detalleitemsSA
        Dim dt As New DataTable
        dt.Columns.Add("destino")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cboEquivalencias")
        dt.Columns.Add("cboPrecios")
        dt.Columns.Add("importeMn")

        '  If CheckStock.Checked = True Then

        listaProductos = listaSA.GetProductosWithInventarioAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = TextFiltrar.Text,
                                                          .idAlmacen = cboAlmacen.SelectedValue
                                                          })


        'listaProductos = (From n In listaProductos
        '                  From tot In n.totalesAlmacen
        '                  Where tot.idAlmacen = cboAlmacen.SelectedValue)

        'Else

        '    Me.listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
        '                                                {
        '                                                .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                .descripcionItem = TextFiltrar.Text
        '                                                })
        'End If

        Dim StockTotal As Decimal = 0
        For Each i In Me.listaProductos
            'dt.Rows.Add(
            '    i.origenProducto,
            '    i.codigodetalle,
            '    i.descripcionItem,
            '    i.composicion,
            '    i.unidad1)

            '   Dim catalagoDefault As Object
            If i.detalleitem_equivalencias.Count > 0 Then
                catalagoDefault = i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault
            Else
                catalagoDefault = Nothing
            End If


            StockTotal = 0
            '  If CheckStock.Checked = True Then
            StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            '  End If

            If StockTotal > 0 Then
                If i.detalleitem_equivalencias.FirstOrDefault IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
                    Dim unidadMaxima = i.detalleitem_equivalencias.Max(Function(o) o.contenido_neto).GetValueOrDefault

                    dt.Rows.Add(
                        i.origenProducto,
                        i.codigodetalle,
                        i.descripcionItem,
                        StockTotal,
                        i.unidad1,
                         i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0)
                Else
                    dt.Rows.Add(
                        i.origenProducto,
                        i.codigodetalle,
                        i.descripcionItem,
                        StockTotal,
                        i.unidad1,
                        0, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0)
                End If
            End If

            'dt.Rows.Add(
            '  i.origenProducto,
            '  i.codigodetalle,
            '  i.descripcionItem,
            '  StockTotal,
            '  i.unidad1,
            '  i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0)
            '              If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precioCode, "0"),
            'If(i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios IsNot Nothing AndAlso i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.Count > 0, i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_precios.FirstOrDefault.precio, "0"))
        Next
        usercontrol.GridTotales.DataSource = dt
        usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Public Sub GetEstablecimientos()
        Dim centroSA As New establecimientoSA
        'Dim ListaEstablecimiento As List(Of centrocosto)
        Dim ListaEstablecimientoDestino As List(Of centrocosto)

        'ListaEstablecimiento = centroSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN").ToList
        ListaEstablecimientoDestino = centroSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN").ToList

        'ComboEmpresa.DataSource = ListaEstablecimiento
        'ComboEmpresa.DisplayMember = "nombre"
        'ComboEmpresa.ValueMember = "idCentroCosto"
        'ComboEmpresa.SelectedValue = GEstableciento.IdEstablecimiento

        ComboUnidadDest.DataSource = ListaEstablecimientoDestino
        ComboUnidadDest.DisplayMember = "nombre"
        ComboUnidadDest.ValueMember = "idCentroCosto"

    End Sub

    Public Sub GetEstablecimientosXEmpresa(IdEmpresaDestino As String)
        Dim centroSA As New establecimientoSA
        Dim ListaEstablecimientoDestino As List(Of centrocosto)

        ListaEstablecimientoDestino = centroSA.ObtenerListaEstablecimientos(IdEmpresaDestino).Where(Function(o) o.TipoEstab = "UN").ToList

        ComboUnidadDest.DataSource = Nothing

        ComboUnidadDest.DisplayMember = "nombre"
        ComboUnidadDest.ValueMember = "idCentroCosto"
        ComboUnidadDest.DataSource = ListaEstablecimientoDestino

        almacenListado = New List(Of almacen)
        almacenListado = almacenSA.GetListar_almacenALL(ComboEmpresa.SelectedValue)

        Dim almacenDestino = almacenListado.Where(Function(o) o.idEstablecimiento = ComboUnidadDest.SelectedValue And o.idAlmacen <> cboAlmacen.SelectedValue).ToList

        ComboAlmacenDestino.DataSource = Nothing
        ComboAlmacenDestino.ValueMember = "idAlmacen"
        ComboAlmacenDestino.DisplayMember = "descripcionAlmacen"
        ComboAlmacenDestino.DataSource = almacenDestino

    End Sub

    Private Sub GetAlmacenes()
        'Dim UNOrigen As Integer = ComboEmpresa.SelectedValue
        Dim UNDestino As Integer = ComboUnidadDest.SelectedValue
        almacenListado = New List(Of almacen)
        almacenListado = almacenSA.GetListar_almacenALL(Gempresas.IdEmpresaRuc)

        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.DataSource = almacenListado.Where(Function(o) o.idEstablecimiento = GEstableciento.IdEstablecimiento).ToList
        'ComboEmpresa.SelectedValue = UNOrigen

        Dim almacenDestino = almacenListado.Where(Function(o) o.idEstablecimiento = UNDestino And o.idAlmacen <> cboAlmacen.SelectedValue).ToList
        ComboUnidadDest.SelectedValue = UNDestino
        ComboAlmacenDestino.ValueMember = "idAlmacen"
        ComboAlmacenDestino.DisplayMember = "descripcionAlmacen"
        ComboAlmacenDestino.DataSource = almacenDestino
    End Sub
#End Region

#Region "Events"
    Private Sub cboAlmacen_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAlmacen.SelectedValueChanged
        If almacenListado.Count > 0 Then
            If IsNumeric(cboAlmacen.SelectedValue) Then
                Dim almacenDestino = almacenListado.Where(Function(o) o.idAlmacen <> cboAlmacen.SelectedValue).ToList

                ComboAlmacenDestino.ValueMember = "idAlmacen"
                ComboAlmacenDestino.DisplayMember = "descripcionAlmacen"
                ComboAlmacenDestino.DataSource = almacenDestino

                ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)
                LoadCanastaVentas(ListaproductosVendidos)
            End If

        End If
    End Sub

    Private Sub TextFiltrar_TextChanged(sender As Object, e As EventArgs) Handles TextFiltrar.TextChanged

    End Sub

    Private Sub TextFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles TextFiltrar.KeyDown
        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                If TextFiltrar.Text.Trim.Length > 0 AndAlso TextFiltrar.Text.Trim.Length >= 2 Then
                    PictureLoadingProduct.Visible = True
                    'listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextFiltrar.Text})
                    'DFGFGFG
                    'UCCanastaDeVentas.GridTotales.Table.Records.DeleteAll()
                    'ListProductos.Items.Clear()
                    'Select Case ComboTipoBusqueda.Text
                    '    Case "CODIGO BARRA"
                    '        BuscarProductoBarCode()
                    '        If listaProductos.Count > 0 AndAlso listaProductos.Count = 1 Then
                    '            Dim equivalencia = UserControl.GridTotales.Table.Records(0).GetValue("cboEquivalencias")
                    '            Dim CatalogoPrecio = UserControl.GridTotales.Table.Records(0).GetValue("cboPrecios")
                    '            ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                    '            Dim eqLista = listaProductos.Where(Function(o) o.codigodetalle = UserControl.GridTotales.Table.Records(0).GetValue("idItem")).SingleOrDefault

                    '            If eqLista.productoRestringido = True Then
                    '                If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    '                    Me.Cursor = Cursors.Default
                    '                    Exit Sub
                    '                End If
                    '            End If

                    '            Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                    '            Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                    '            If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                    '                Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                    '                If catalogPredeterminado IsNot Nothing Then
                    '                    UserControl.GridTotales.Table.Records(0).SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                    '                Else
                    '                    UserControl.GridTotales.Table.Records(0).SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                    '                End If

                    '                UserControl.GridTotales.Table.Records(0).SetCurrent("descripcion")
                    '                TextFiltrar.Clear()
                    '                TextFiltrar.Select()
                    '                'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                    '            End If

                    '            '-----------------------------------------------------------------------------------------------------------------------------------------------
                    '            '-----------------------------------------------------------------------------------------------------------------------------------------------

                    '            If CatalogoPrecio.ToString.Trim.Length = 0 Then
                    '                MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '                Me.Cursor = Cursors.Default
                    '                Exit Sub
                    '            End If

                    '            Dim idProducto = Me.usercontrol.GridTotales.Table.Records(0).GetValue("idItem")
                    '            Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                    '            Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                    '            '   If inp IsNot Nothing Then
                    '            If IsNumeric(inp) Then
                    '                If (inp) > 0 Then

                    '                    Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                    '                    precioVenta = precioventaFormula

                    '                    AgregarProductoDetalleVenta(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio)
                    '                    LoadCanastaVentas(ListaproductosVendidos)
                    '                    PictureLoadingProduct.Visible = False
                    '                    'Me.usercontrol.GridTotales.Table.Records(0).SetCurrent("descripcion")
                    '                    'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                    '                    'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
                    '                Else
                    '                    MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '                    Me.Cursor = Cursors.Default
                    '                    Exit Sub
                    '                End If
                    '            Else
                    '                MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '                Me.Cursor = Cursors.Default
                    '                Exit Sub
                    '            End If
                    '        ElseIf listaProductos.Count >= 2 Then
                    '            popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                    '            PictureLoadingProduct.Visible = False

                    '            'Dim rec As GridRecord = Me.usercontrol.GridTotales.Table.Records(1)
                    '            'rec.SetCurrent("descripcion")
                    '            'usercontrol.GridTotales.Focus()

                    '            Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
                    '            Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
                    '            Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                    '        ElseIf listaProductos.Count <= 0 Then
                    '            PictureLoadingProduct.Visible = False
                    '            MessageBox.Show("El código ingresado no se encuentra en la base de datos de productos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '            TextFiltrar.Clear()
                    '            TextFiltrar.Select()
                    '        End If

                    '    Case "PRODUCTO"
                    BuscarProducto()

                    If listaProductos.Count > 0 Then
                        popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                        PictureLoadingProduct.Visible = False

                        'Dim rec As GridRecord = Me.usercontrol.GridTotales.Table.Records(1)
                        'rec.SetCurrent("descripcion")
                        'usercontrol.GridTotales.Focus()
                        If Me.usercontrol.GridTotales.Table.Records.Count > 0 Then
                            Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
                            Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
                            Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                        End If

                        'Me.usercontrol.GridTotales.Focus()
                    Else

                        PictureLoadingProduct.Visible = False
                    End If
                    '    Case "SERVICIO"
                    '        PictureLoadingProduct.Visible = False
                    'End Select
                End If
            Else
                'Me.PopupProductos.Size = New Size(319, 128)
                'Me.PopupProductos.ParentControl = Me.TextBoxExt1
                'Me.PopupProductos.ShowPopup(Point.Empty)
                'Dim consulta As New List(Of entidad)
                'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
                'Dim consulta2 = (From n In listaProveedores
                '                 Where n.nombreCompleto.StartsWith(txtProveedor.Text) Or n.nrodoc.StartsWith(txtProveedor.Text)).ToList

                'consulta.AddRange(consulta2)
                'FillLSVProveedores(consulta)
                'e.Handled = True
            End If

            If e.KeyCode = Keys.Down Then
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                'Me.PopupProductos.Size = New Size(426, 147)
                'Me.PopupProductos.ParentControl = Me.TextFiltrar
                'Me.PopupProductos.ShowPopup(Point.Empty)
                'GridTotales.Focus()
                'GridTotales.
                If usercontrol.GridTotales.Table.Records.Count > 0 Then
                    usercontrol.ListInventario.Items.Clear()
                    popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                    Dim colIndex As Integer = Me.usercontrol.GridTotales.TableDescriptor.FieldToColIndex(0)
                    Dim rowIndex As Integer = Me.usercontrol.GridTotales.Table.Records(0).GetRowIndex()
                    If usercontrol.GridTotales.Table.Records.Count > 0 Then
                        Me.usercontrol.GridTotales.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                    End If

                End If


                'usercontrol.GridTotales.TableControl.CurrentCell.ShowDropDown()
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                'If Me.PopupProductos.IsShowing() Then
                '    Me.PopupProductos.HidePopup(PopupCloseType.Canceled)
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("U.M.")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("contenido")

        dt.Columns(0).ColumnMapping = MappingType.Hidden
        dt.Columns(1).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.contenido_neto)
        Next
        Return dt
    End Function

    Private Function GetCatalogoPrecios(lista As List(Of detalleitemequivalencia_catalogos)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("idCatalogo")
        dt.Columns.Add("nombre_corto")

        dt.Columns(0).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.idCatalogo, i.nombre_corto)
        Next

        'Dim dt As New DataTable
        'dt.Columns.Add("idCatalogo")
        'dt.Columns.Add("nombre_corto")
        'dt.Columns.Add("Cant.minima")
        'dt.Columns.Add("Al credito")
        'dt.Columns.Add("Al contado")
        'For Each i In lista
        '    dt.Rows.Add(i.idCatalogo, i.nombre_corto)
        '    For Each prec In i.detalleitemequivalencia_precios
        '        dt.Rows.Add(Nothing, Nothing, prec.rango_inicio, prec.precioCredito, prec.precio)
        '    Next
        'Next
        Return dt
    End Function

    Private Sub GridCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridCompra.QueryCellStyleInfo

        'If e.TableCellIdentity IsNot Nothing Then
        '    If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "afectoInventario" Then
        '        e.Style.CellType = "CheckBox"
        '        e.Style.Description = e.Style.Text
        '        e.Style.CellValue = Me.col2Check
        '        e.Style.Enabled = True
        '    End If
        'End If

        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "tipofraccion" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault
            If prod IsNot Nothing Then
                Select Case prod.tipoExistencia
                    Case TipoExistencia.ServicioGasto

                    Case Else
                        Dim listaEquivalencias = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").OrderBy(Function(z) z.contenido).ToList

                        '   If value = "a" Then
                        e.Style.DataSource = GetEquivalencias(listaEquivalencias)
                        e.Style.DisplayMember = "unidadComercial"
                        e.Style.ValueMember = "equivalencia_id"
                        'ElseIf value = "b" Then
                        '    e.Style.DataSource = ZipCodes
                        '    e.Style.DisplayMember = "City"
                        '    e.Style.ValueMember = "Class"
                        'ElseIf value = "c" Then
                        '    e.Style.DataSource = Shippers
                        '    e.Style.DisplayMember = "Shipper ID"
                        '    e.Style.ValueMember = "Company Name"
                        'End If
                End Select
            End If

        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "gravado" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then
            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

            Dim gravado = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("gravado").ToString()

            If prod IsNot Nothing Then
                Select Case prod.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        e.Style.Enabled = True
                        If gravado > 2 Then
                            e.Style.Text = 1
                        ElseIf gravado <= 0 Then
                            e.Style.Text = 1
                        End If
                    Case Else
                        e.Style.Enabled = False
                End Select
            End If

        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "catalogo" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

            If prod IsNot Nothing Then
                Select Case prod.tipoExistencia
                    Case TipoExistencia.ServicioGasto

                    Case Else
                        Dim idEquiva = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("tipofraccion").ToString() 'idEquivalencia
                        If idEquiva.Trim.Length > 0 Then
                            Dim objEquivalencia As detalleitem_equivalencias
                            If IsNumeric(idEquiva) Then
                                objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                            Else
                                objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.unidadComercial = idEquiva).Single
                            End If

                            Dim listaPreciosVenta = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.estado = 1).ToList)
                            e.Style.DataSource = listaPreciosVenta
                            e.Style.DisplayMember = "nombre_corto"
                            e.Style.ValueMember = "idCatalogo"
                        Else
                            e.Style.DataSource = Nothing
                            e.Style.DisplayMember = "nombre_corto"
                            e.Style.ValueMember = "idCatalogo"
                        End If
                End Select
            End If



        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "importeMn" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then


        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "detalle" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then
            e.Style.CharacterCasing = CharacterCasing.Upper

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

            If prod IsNot Nothing Then
                Select Case prod.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        e.Style.ReadOnly = False
                    Case Else
                        e.Style.ReadOnly = True
                End Select
            End If
        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "item" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then
            Dim value = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

            If prod IsNot Nothing Then
                Select Case prod.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
                e.Style.CellTipText = e.Style.Text
            End If


            'ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "bonificacion" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then
            '    Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            '    Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

            '    If prod IsNot Nothing Then
            '        If prod.CustomListaVentaDetalle IsNot Nothing Then
            '            If prod.CustomListaVentaDetalle.Count > 0 Then
            '                e.Style.Enabled = False
            '            Else
            '                e.Style.Enabled = True
            '            End If
            '        Else
            '            e.Style.Enabled = True
            '        End If
            '    End If

        End If


        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement


            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "tipofraccion")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

                If prod IsNot Nothing Then
                    Select Case prod.tipoExistencia
                        Case TipoExistencia.ServicioGasto
                            'e.Style.BackColor = Color.Yellow
                            'e.Style.TextColor = Color.Black
                            e.Style.Enabled = False
                        Case Else
                            e.Style.Enabled = True
                    End Select
                End If


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "catalogo")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

                If prod IsNot Nothing Then
                    Select Case prod.tipoExistencia
                        Case TipoExistencia.ServicioGasto
                            e.Style.BackColor = Color.Yellow
                            e.Style.TextColor = Color.Black
                            e.Style.Enabled = False
                        Case Else
                            e.Style.Enabled = True
                    End Select
                End If

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim r = e.TableCellIdentity.DisplayElement.GetRecord
                If r Is Nothing Then Exit Sub
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
                Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

                If prod IsNot Nothing Then
                    Select Case prod.tipoExistencia
                        Case TipoExistencia.ServicioGasto
                            'e.Style.BackColor = Color.FromKnownColor(KnownColor.InactiveBorder)
                            'e.Style.TextColor = Color.Black
                            e.Style.Enabled = True
                            ' e.Style.Text = 1
                        Case Else
                            e.Style.Enabled = True
                    End Select
                End If


                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                '    Select Case FormPurchase.ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select

                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "igvmn")) Then
                '    Select Case FormPurchase.ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "pumn")) Then
                '    Select Case FormPurchase.ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "totalmn")) Then
                '    Select Case FormPurchase.ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "descuentoMN")) Then
                '    Select Case FormPurchase.ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select


                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "bonificacion")) Then
                '    Select Case FormPurchase.ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = False
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "afectoInventario")) Then
                '    Select Case FormPurchase.ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = True
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "precioventa")) Then
                '    Select Case FormPurchase.ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "item")) Then
                '    Dim strTipoExistencia = Me.GridCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                '    Select Case strTipoExistencia
                '        Case "GS"
                '            e.Style.[ReadOnly] = False
                '        Case Else
                '            e.Style.[ReadOnly] = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then
                '    Dim strTipoExistencia = Me.GridCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                '    Select Case strTipoExistencia
                '        Case "GS"
                '            e.Style.[ReadOnly] = False
                '        Case Else
                '            e.Style.[ReadOnly] = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                '    Dim strTipoExistencia = Me.GridCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                '    'Dim cantidadActual = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 7).CellValue
                '    'Dim cantidadDisponible = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 25).CellValue

                '    'If cantidadActual > cantidadDisponible Then
                '    '    e.Style.CellValue = 0
                '    'End If

                '    Select Case strTipoExistencia
                '        Case "GS"
                '            e.Style.[ReadOnly] = False 'True
                '            e.Style.BackColor = Color.Yellow
                '            e.Style.TextColor = Color.Black
                '        Case Else
                '            e.Style.[ReadOnly] = False
                '            e.Style.BackColor = Color.Yellow
                '            e.Style.TextColor = Color.Black
                '    End Select


            End If


        End If

        'If e.TableCellIdentity.ColIndex > 0 Then
        '    If e.TableCellIdentity.ColIndex > -1 Then
        '        Dim el As Element = e.TableCellIdentity.DisplayElement
        '        Dim r As Record = el.GetRecord()

        '        If r IsNot Nothing Then
        '            ' Dim row As Integer = e.TableCellIdentity.Table.UnsortedRecords.IndexOf(r)

        '            Dim codigoItem = r.GetValue("codigo")

        '            Dim Item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigoItem).SingleOrDefault
        '            If Item Is Nothing Then Exit Sub
        '            Select Case Item.tipobeneficio
        '                Case "OFERTA"
        '                    e.Style.ReadOnly = True 'False
        '                    e.Style.BackColor = ColorTranslator.FromHtml("#FF72E49E") 'Color.LightCyan
        '                Case Else
        '                    e.Style.ReadOnly = False 'True
        '            End Select
        '            ' If row = 7 Then e.Style.Enabled = False
        '        End If
        '    End If

        'End If
    End Sub

    Private Sub GridCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridCompra.TableControlCurrentCellCloseDropDown
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)


                If style.TableCellIdentity.Column.Name = "tipofraccion" Then
                    Dim equ = style.TableCellIdentity.DisplayElement.GetRecord().GetValue("tipofraccion")
                    Dim CodigoEQ As String = cc.Renderer.ControlText
                    Dim r As Record = GridCompra.Table.CurrentRecord
                    If r IsNot Nothing Then

                        Dim value As String = r.GetValue("codigo").ToString()
                        Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

                        If prod.tipobeneficio IsNot Nothing Then Exit Sub

                        Select Case prod.tipoExistencia
                            Case TipoExistencia.ServicioGasto

                            Case Else
                                Dim listaEquivalencias = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

                                'Dim idEquivalencia = r.GetValue("tipofraccion")
                                Dim obEQ As detalleitem_equivalencias
                                If IsNumeric(CodigoEQ) Then
                                    obEQ = listaEquivalencias.Where(Function(i) i.equivalencia_id = (CodigoEQ)).SingleOrDefault
                                Else
                                    obEQ = listaEquivalencias.Where(Function(i) i.unidadComercial = (CodigoEQ)).SingleOrDefault
                                End If

                                prod.CustomEquivalencia = obEQ
                                r.SetValue("contenido", obEQ.contenido_neto)
                                r.SetValue("tipofraccion", obEQ.equivalencia_id)

                                Dim catalagoDefault = obEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                                If catalagoDefault IsNot Nothing Then
                                    r.SetValue("catalogo", catalagoDefault.idCatalogo)
                                    prod.catalogo_id = catalagoDefault.idCatalogo
                                    prod.CustomCatalogo = catalagoDefault
                                End If

                                Dim codigo = r.GetValue("codigo")
                                Dim cantidad = Decimal.Parse(r.GetValue("cantidad"))
                                Dim idcatalogo = r.GetValue("catalogo")

                                Dim precioVenta = 0 'GetCalculoPrecioVenta(cantidad, codigo, obEQ.equivalencia_id, idcatalogo, r)
                                r.SetValue("precioventa", precioVenta)
                        End Select

                        GetCalculoItemV2(r)
                        EditarItemVenta(r)



                        ' Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

                        'r.SetValue("cboPrecios", String.Empty)
                        'r.SetValue("cboEquivalencias", String.Empty)
                        'r.SetValue("importeMn", 0)
                    End If
                    'If text.Trim.Length > 0 Then
                    '    Dim value As Decimal = Convert.ToDecimal(text)
                    '    cc.Renderer.ControlValue = value

                    'End If
                ElseIf style.TableCellIdentity.Column.Name = "catalogo" Then
                    Dim CodigoCat As String = cc.Renderer.ControlText
                    Dim r = style.TableCellIdentity.Table.CurrentRecord
                    If r IsNot Nothing Then
                        Dim codigo = r.GetValue("codigo")
                        Dim cantidad = Decimal.Parse(r.GetValue("cantidad"))

                        Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigo).Single
                        If prod.tipobeneficio IsNot Nothing Then Exit Sub
                        Select Case prod.tipoExistencia
                            Case TipoExistencia.ServicioGasto

                            Case Else
                                Dim listaEquivalencias = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

                                Dim idEquivalencia = r.GetValue("tipofraccion")

                                Dim obEQ As detalleitem_equivalencias
                                If IsNumeric(idEquivalencia) Then
                                    obEQ = listaEquivalencias.Where(Function(i) i.equivalencia_id = (idEquivalencia)).SingleOrDefault
                                Else
                                    obEQ = listaEquivalencias.Where(Function(i) i.unidadComercial = (idEquivalencia)).SingleOrDefault
                                End If


                                Dim catalogoOBJ As detalleitemequivalencia_catalogos
                                If IsNumeric(CodigoCat) Then
                                    catalogoOBJ = obEQ.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CodigoCat).SingleOrDefault
                                Else
                                    catalogoOBJ = obEQ.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = CodigoCat).SingleOrDefault
                                End If
                                prod.catalogo_id = catalogoOBJ.idCatalogo
                                prod.CustomCatalogo = catalogoOBJ

                                If catalogoOBJ IsNot Nothing Then
                                    '    UCPreciosCanastaVenta.GetDetallePrecios(catalogoOBJ.detalleitemequivalencia_precios.ToList)
                                End If
                                'Calculando Precio de venta por equivalencia y catalogo
                                Dim precioVenta = 0 'GetCalculoPrecioVenta(cantidad, codigo, obEQ.equivalencia_id, CodigoCat, r)
                                r.SetValue("precioventa", precioVenta)
                                r.EndEdit()
                                GetCalculoItemV2(r)
                                EditarItemVenta(r)
                        End Select


                    End If



                    'Dim r = style.TableCellIdentity.Table.CurrentRecord
                    'If r IsNot Nothing Then
                    '    Dim value As String = r.GetValue("idItem").ToString()
                    '    Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                    '    Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

                    '    If idEquiva.Trim.Length > 0 Then
                    '        Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                    '        Dim idCat = r.GetValue("cboPrecios").ToString()
                    '        If idCat.Trim.Length > 0 Then
                    '            Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                    '            UCPreciosCanastaVenta.ListInventario.Items.Clear()

                    '            If OBJCatalog IsNot Nothing Then
                    '                Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                    '                UCPreciosCanastaVenta.GetDetallePrecios(lista)
                    '            End If
                    '        Else
                    '        End If
                    '    End If
                    'End If

                    'Dim text As String = cc.Renderer.ControlText

                    'Dim r As Record = GridTotales.Table.CurrentRecord
                    'If r IsNot Nothing Then
                    '    Dim value As String = r.GetValue("idItem").ToString()
                    '    Dim prod = UCEstructuraCabeceraVenta.listaProductos.Where(Function(o) o.codigodetalle = value).Single
                    '    Dim idEquiva = r.GetValue("cboEquivalencias").ToString()

                    '    If idEquiva.Trim.Length > 0 Then
                    '        Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single

                    '        Dim idCat = r.GetValue("cboPrecios").ToString()
                    '        Dim style2 As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex + 1)
                    '        If idCat.Trim.Length > 0 Then

                    '            Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                    '            'Dim listaCatalog = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
                    '            Dim listaPreciosVenta = GetDetallePrecios(OBJCatalog.detalleitemequivalencia_precios.ToList)


                    '            'style2.DataSource = listaPreciosVenta 'OBJCatalog.detalleitemequivalencia_precios.ToList
                    '            'style2.DisplayMember = "precio"
                    '            'style2.ValueMember = "precio_id"

                    '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
                    '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
                    '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.ValueMember = "precio"
                    '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DataSource = listaPreciosVenta
                    '            '     Me.GridTotales.TableDescriptor.Columns("CategoryID").Appearance.AnyRecordFieldCell.ChoiceList = Collection
                    '            Me.GridTotales.TableDescriptor.Columns("importeMn").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
                    '        Else
                    '            'style2.DataSource = Nothing
                    '            'style2.DisplayMember = "precio"
                    '            'style2.ValueMember = "precio_id"
                    '        End If


                    '    End If
                    'End If

                ElseIf style.TableCellIdentity.Column.Name = "importeMn" Then

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub GetCalculoItemV2(r As Record)
        If r IsNot Nothing Then
            Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
            Dim recaudo As Decimal = CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(r.GetValue("precioventa"))
            Dim canti As Decimal = CDec(r.GetValue("cantidad"))
            Dim cantiTotal As Decimal = canti * CDec(r.GetValue("contenido"))
            Dim descuentoItem As Decimal = CDec(r.GetValue("descuentoMN"))



            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0
            Dim precioUnitario As Decimal = 0

            Dim afectacion As String = r.GetValue("tipoAfectacion")
            Dim tasa As Decimal = CDec(r.GetValue("afectacion"))

            Dim totalicpbc As Decimal = cantiTotal * tasa

            Dim total As Decimal = 0 'canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
            If item IsNot Nothing Then
                'Dim sub_total As Decimal = canti * item.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                'Dim total As Decimal = sub_total * precioVenta '

                baseImponible = 0
                Iva = 0
                total = 0

                r.SetValue("vcmn", baseImponible)
                r.SetValue("igvmn", Iva)
                r.SetValue("descuentoMN", descuentoItem)
                r.SetValue("totalmn", total)
                r.SetValue("totalafect", totalicpbc)
                r.SetValue("cantidadtotal", cantiTotal)



                If CDec(r.GetValue("cantidadtotal")) = 0 Or CDec(r.GetValue("cantidadtotal")) = 0 Then
                    'precioUnitario = 0
                    'r.SetValue("pumn", 0)
                    'item.precioUnitario = 0
                Else
                    'precioUnitario = CalculoPrecioUnitario(total, canti)
                    'r.SetValue("pumn", precioUnitario)
                    'item.precioUnitario = precioUnitario
                End If

                GridCompra.Refresh()

                '    GetTotalesDocumento()
            End If
        End If
    End Sub

    Private Sub EditarItemVenta(r As Record)
        If r IsNot Nothing Then

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
            If item IsNot Nothing Then
                With item
                    .monto1 = Decimal.Parse(r.GetValue("cantidad"))
                    .PrecioUnitarioVentaMN = Decimal.Parse(r.GetValue("precioventa"))
                    .montokardex = Decimal.Parse(r.GetValue("vcmn"))
                    .montoIgv = Decimal.Parse(r.GetValue("igvmn"))
                    .precioUnitario = 0
                    .importeMN = Decimal.Parse(r.GetValue("totalmn"))
                    .FlagBonif = r.GetValue("bonificacion").ToString
                    .descuentoMN = Decimal.Parse(r.GetValue("descuentoMN"))
                    .montoIcbper = Decimal.Parse(r.GetValue("totalafect"))
                    .detalleAdicional = r.GetValue("detalle")
                    .CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                    '  .CustomDocumentoCaja = New List(Of documentoCaja)
                End With
                ' FormPurchase.LimpiarPagos(ListaproductosComprados)
                'Dim codigoCompra = ListDetalle.SelectedItems(0).SubItems(0).Text
                'Dim cantidad As Decimal = Decimal.Parse(ListDetalle.SelectedItems(0).SubItems(6).Text)

                'If item IsNot Nothing Then
                '    item.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                '    GetEntregas(1, Decimal.Parse(r.GetValue("cantidad")), item.CodigoCosto)
                'End If

            End If
        End If
        'LoadCanastaCompras(ListaproductosComprados)
    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "cantidad" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            Dim r As Record = GridCompra.Table.CurrentRecord

                            If IsNumeric(text.Trim.Length) Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                    r.SetValue("descuentoMN", 0)

                                    GetCalculoItemV2(GridCompra.Table.CurrentRecord)
                                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextNumIdentrazon.Enabled = False
            '   cboTipoDoc.Text = "BOLETA"
            TextNumIdentrazon.Text = VarClienteGeneral.idEntidad
            TextProveedor.Text = VarClienteGeneral.nombreCompleto
            TextProveedor.Tag = VarClienteGeneral.idEntidad
            TextProveedor.Enabled = True
            TextProveedor.Focus()
            TextProveedor.SelectAll()

        End If
    End Sub

    Private Sub GridCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "cantidad" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            Dim r As Record = GridCompra.Table.CurrentRecord

                            If IsNumeric(text.Trim.Length) Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                    r.SetValue("descuentoMN", 0)
                                    GetCalculoItemV2(GridCompra.Table.CurrentRecord)
                                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        Dim r As Record = GridCompra.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim codigo = r.GetValue("codigo")
            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigo).SingleOrDefault
            If item IsNot Nothing Then
                If item.tipobeneficio Is Nothing Then
                    ' LimpiarPagos(UCEstructuraCabeceraVentaV2.ListaproductosVendidos)
                    If item.CustomListaVentaDetalle IsNot Nothing Then
                        For Each i In item.CustomListaVentaDetalle
                            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = i.CodigoCosto).Single
                            ListaproductosVendidos.Remove(prod)
                        Next
                    End If
                    item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
                    ListaproductosVendidos.Remove(item)

                    LoadCanastaVentas(ListaproductosVendidos)
                    '     GetTotalesDocumento()
                End If
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Function ValidarForm() As Boolean
        Dim listaErrores As Integer = 0
        'If chPedido.Checked = True Then



        'Select Case UCEstructuraCabeceraVentaV2.RBFullName.Checked = True
        '    Case True
        '        If UCEstructuraCabeceraVentaV2.TextProveedor.Tag Is Nothing Then
        '            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, "Ingrese un cliente")
        '            listaErrores += 1
        '        Else
        '            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, Nothing)
        '        End If

        '    Case False
        '        If UCEstructuraCabeceraVentaV2.TextProveedor.Text.Trim.Length = 0 Then
        '            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, "Ingrese un cliente")
        '            listaErrores += 1
        '        Else
        '            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, Nothing)
        '        End If

        '        If UCEstructuraCabeceraVentaV2.TextProveedor.Tag Is Nothing Then
        '            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, "Ingrese un cliente")
        '            listaErrores += 1
        '        Else
        '            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, Nothing)
        '        End If
        'End Select



        If listaErrores > 0 Then
            ValidarForm = False
        Else
            ValidarForm = True
        End If
    End Function

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Cursor = Cursors.WaitCursor
        If ValidarForm() = True Then
            'Select Case btGrabar.Text
            '    Case "Guardar - F2"
            Application.DoEvents()
            Grabarventa()
            '    Case "Editar - F2"
            '        Application.DoEvents()
            '        'EditaDocumentoVenta()
            'End Select
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        Close()
    End Sub

    Private Sub GridCompra_TableControlCurrentCellShowingDropDown(sender As Object, e As GridTableControlCurrentCellShowingDropDownEventArgs) Handles GridCompra.TableControlCurrentCellShowingDropDown
        'Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell

        '   Dim gridControl As GridControl = TryCast(sender, GridControl)
        Dim cc As GridCurrentCell = e.TableControl.CurrentCell
        Dim cr As GridDropDownGridListControlCellRenderer = TryCast(cc.Renderer, GridDropDownGridListControlCellRenderer)
        cr.ListControlPart.BackColor = Color.White
        cr.ListControlPart.ForeColor = Color.White
        'Dim cr As GridComboBoxCellRenderer = CType(IIf(TypeOf cc.Renderer Is GridComboBoxCellRenderer, cc.Renderer, Nothing), GridComboBoxCellRenderer)
        'cr.ListBoxPart.BackColor = Color.Black
        'cr.ListBoxPart.ForeColor = Color.Yellow
    End Sub

    Private Sub cboAlmacen_Click(sender As Object, e As EventArgs) Handles cboAlmacen.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboUnidad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboEmpresa.SelectionChangeCommitted
        Try
            GridCompra.Table.Records.DeleteAll()
            'GetEstablecimientos()
            GetAlmacenes()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub ComboUnidadDest_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboUnidadDest.SelectionChangeCommitted
        Try
            GridCompra.Table.Records.DeleteAll()

            If (chEmpresa.Checked = True) Then
                GetComboAlmacenDestino()
            ElseIf (chEmpresa.Checked = False) Then
                GetAlmacenes()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Try
            Dim detallaitemsBE As New detalleitems
            Dim detalleitemsSA As New detalleitemsSA

            If (Not IsNothing(GridCompra.Table.CurrentRecord)) Then

                Dim codigo = GridCompra.Table.CurrentRecord.GetValue("tipofraccion")

                detallaitemsBE.codigodetalle = codigo
                detallaitemsBE.idEstablecimiento = ComboUnidadDest.SelectedValue
                detallaitemsBE.descripcionItem = GridCompra.Table.CurrentRecord.GetValue("item")

                Dim dettaleItemNuevo = detalleitemsSA.InsertCopyItemXIdEsblecimiento(detallaitemsBE)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ChEmpresa_CheckedChanged(sender As Object, e As EventArgs) Handles chEmpresa.CheckedChanged
        Try
            If (chEmpresa.Checked = True) Then
                ComboEmpresa.Visible = True
                lblEmpresa.Visible = True
                ComboEmpresa.DataSource = Nothing
                ComboUnidadDest.DataSource = Nothing
                UbicarEmpresa()
                GetEstablecimientosXEmpresa(ComboEmpresa.SelectedValue)
            ElseIf (chEmpresa.Checked = False) Then
                ComboEmpresa.Visible = False
                lblEmpresa.Visible = False
                ComboEmpresa.DataSource = Nothing
                ComboUnidadDest.DataSource = Nothing
                GetEstablecimientos()
                GetAlmacenes()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region
End Class