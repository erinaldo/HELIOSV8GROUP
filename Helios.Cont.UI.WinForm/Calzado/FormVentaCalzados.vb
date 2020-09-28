Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Imports System.Net.Http
Imports ProcesosGeneralesCajamiSoft
Imports System.ComponentModel

Public Class FormVentaCalzados

    Private FormImpresionNuevo As FormImpresionEquivalencia ' FormImpresionNuevo
    Public Property cajaUsuaroSA As New cajaUsuarioSA
    Public Property ucEstructuraCalzado As ucEstructuraCalzado

    Public UCCondicionesPago As ucPagoVentaCalzado
    Public Property catalogoPrecios As List(Of detalleitemequivalencia_catalogos)
    Public Property listaProductos As List(Of detalleitems)
    Public Property ListaGeneralTallas As List(Of talla)

    Public Property lstTotalesAlmacen As List(Of totalesAlmacenOthers)

    Public Property ListaproductosVendidos As List(Of documentoventaAbarrotesDet)

    Public Property venta As documentoventaAbarrotes

    Dim tallaSA As New tallaSA
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ucEstructuraCalzado = New ucEstructuraCalzado(Me) With {.Dock = DockStyle.Fill, .Visible = True}
        UCCondicionesPago = New ucPagoVentaCalzado(Me) With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(ucEstructuraCalzado)
        PanelBody.Controls.Add(UCCondicionesPago)

        ' Add any initialization after the InitializeComponent() call.
        ListaGeneralTallas = tallaSA.GetPlantillaTallas()
        ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)

        TextCodigoBarra.Select()
    End Sub

    Public Sub New(IDDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ucEstructuraCalzado = New ucEstructuraCalzado(Me) With {.Dock = DockStyle.Fill, .Visible = True}
        UCCondicionesPago = New ucPagoVentaCalzado(Me) With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(ucEstructuraCalzado)
        PanelBody.Controls.Add(UCCondicionesPago)

        ' Add any initialization after the InitializeComponent() call.
        ListaGeneralTallas = tallaSA.GetPlantillaTallas()
        ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)

        UbicarDocumentoVenta(IDDocumento)
    End Sub

    Private Sub UbicarDocumentoVenta(idDocumento As Integer)
        Dim entidadSA As New entidadSA
        Dim ventaSA As New documentoVentaAbarrotesSA
        'Dim venta = ventaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = idDocumento})
        venta = ventaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = idDocumento})
        Dim ent = venta.CustomEntidad ' entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault
        If venta IsNot Nothing Then
            VerCabeceraDocumento(venta, ent)
            VerDetalleVenta(venta)
        End If
    End Sub

    Private Sub VerDetalleVenta(venta As documentoventaAbarrotes)
        ListaproductosVendidos = venta.documentoventaAbarrotesDet.ToList
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
        dt.Columns.Add("tipoAfectacion")
        dt.Columns.Add("afectacion")
        dt.Columns.Add("totalafect")

        For Each i In ListaproductosVendidos

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
                          0, i.bonificacion, 0, i.descuentoMN.GetValueOrDefault, True, "-", 0, 0)
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
                          i.CustomEquivalencia.equivalencia_id, i.bonificacion, If(i.CustomCatalogo Is Nothing, "-", i.CustomCatalogo.idCatalogo), i.descuentoMN.GetValueOrDefault, True,
If(i.CustomProducto.tipoOtroImpuesto = "ICBPER", "ICBPER", "-"), i.CustomProducto.otroImpuesto.GetValueOrDefault, i.CustomProducto.otroImpuesto.GetValueOrDefault)
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
        ucEstructuraCalzado.GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0
        ucEstructuraCalzado.GridCompra.DataSource = dt
        ucEstructuraCalzado.GridCompra.Refresh()
        ucEstructuraCalzado.GridCompra.TableDescriptor.AllowEdit = False
        ucEstructuraCalzado.GetTotalesDocumento()
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
            Case TIPO_COMPRA.TRANSFERENCIA_ENTRE_ALMACEN
                ComboComprobante.Text = "TRANSFERENCIA ENTRE ALMACENES"

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

        With ucEstructuraCalzado
            '.TextDescuento.Enabled = False
            '.TextSubTotal.DecimalValue = venta.ImporteNacional.GetValueOrDefault + venta.importeCostoMN.GetValueOrDefault
            '.TextDescuento.DecimalValue = venta.importeCostoMN.GetValueOrDefault
            '.TxtDia.DecimalValue = venta.fechaDoc.Value.Day
            '.cboMesCompra.SelectedValue = String.Format("{0:00}", venta.fechaDoc.Value.Month)
            '.TextAnio.DecimalValue = venta.fechaDoc.Value.Year
            '.txtHora.Value = venta.fechaDoc.Value
            .cboMoneda.SelectedValue = venta.moneda
            .txtTipoCambio.DecimalValue = venta.tipoCambio.GetValueOrDefault
            .txtIva.DoubleValue = venta.tasaIgv
            .cboTipoDoc.SelectedValue = venta.tipoDocumento
            If ent IsNot Nothing Then
                If ent.tipoEntidad = "VR" Then
                    .RadioButton2.Checked = True
                    .TextProveedor.Tag = ent.idEntidad
                    .TextProveedor.Text = venta.nombrePedido
                Else
                    .RadioButton1.Checked = True
                    .TextNumIdentrazon.Text = ent.nrodoc
                    .TextProveedor.Text = ent.nombreCompleto
                    .TextProveedor.Tag = ent.idEntidad
                End If
            End If
        End With
    End Sub

    Public Sub BuscarProductoBarCode(TextFilter As String)
        '   Dim catalagoDefault As Object
        Dim listaSA As New detalleitemsSA
        listaProductos = listaSA.GetProductsBarCode(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .codigo = TextFilter
                                                          })
        If listaProductos.Count > 0 Then
            TextProduct.Text = listaProductos.FirstOrDefault().descripcionItem
            TextProduct.Tag = listaProductos.FirstOrDefault().codigodetalle
            '     LabelStockDisponible.Text = listaProductos.FirstOrDefault().stock
            GetTallasSelproduct(listaProductos.FirstOrDefault().codigodetalle)
            GetComboCatalogo(listaProductos.FirstOrDefault())

            Dim foto = listaProductos.FirstOrDefault().fotoUrl
            If foto IsNot Nothing Then

                If foto.ToString.Trim.Length > 0 Then
                    PictureBox1.Image = Image.FromFile(listaProductos.FirstOrDefault().fotoUrl)
                Else
                    PictureBox1.Image = ImageListAdv1.Images(0)
                End If
            End If
        End If
        PictureLoadingProduct.Visible = False
    End Sub

    Private Sub GetTallasSelproduct(codigodetalle As Integer)
        Dim tallaSA As New totalesAlmacenOthersSA
        lstTotalesAlmacen = tallaSA.GetInventarioSelCodigo(New totalesAlmacenOthers With {.idProducto = codigodetalle})
        If lstTotalesAlmacen IsNot Nothing Then
            Dim generoList = lstTotalesAlmacen.Select(Function(o) o.genero).Distinct.ToList()
            Dim listaGeneros As New List(Of Genero)
            For Each i In generoList
                listaGeneros.Add(New Genero With {.idGenero = i, .genero = i})
            Next
            ucEstructuraCalzado.Combogenero.DataSource = listaGeneros
            ucEstructuraCalzado.Combogenero.DisplayMember = "NameGenero"
            ucEstructuraCalzado.Combogenero.ValueMember = "idGenero"

            If ucEstructuraCalzado.Combogenero.Items.Count > 0 Then
                ucEstructuraCalzado.GetTabllaDetalleSelGenero(ucEstructuraCalzado.Combogenero.SelectedValue)
            End If
        End If
    End Sub

    Private Sub GetComboCatalogo(prod As detalleitems)
        catalogoPrecios = prod.detalleitem_equivalencias.FirstOrDefault().detalleitemequivalencia_catalogos.ToList()
        ComboCatalogo.DataSource = catalogoPrecios
        ComboCatalogo.DisplayMember = "nombre_corto"
        ComboCatalogo.ValueMember = "idCatalogo"

        GetPreciosSelcatalogo(ComboCatalogo.SelectedValue)
    End Sub

    Private Sub TextCodigoBarra_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigoBarra.KeyDown
        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                If TextCodigoBarra.Text.Trim.Length > 0 AndAlso TextCodigoBarra.Text.Trim.Length >= 2 Then
                    PictureLoadingProduct.Visible = True
                    BuscarProductoBarCode(TextCodigoBarra.Text.Trim)

                End If
            Else

            End If

            If e.KeyCode = Keys.Escape Then
                'If Me.PopupProductos.IsShowing() Then
                '    Me.PopupProductos.HidePopup(PopupCloseType.Canceled)
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboCatalogo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboCatalogo.SelectionChangeCommitted
        GetPreciosSelcatalogo(ComboCatalogo.SelectedValue)
    End Sub

    Private Sub GetPreciosSelcatalogo(idcatalogo As Integer)
        If idcatalogo > 0 Then


            Dim catalogoSel = catalogoPrecios.Where(Function(o) o.idCatalogo = idcatalogo).SingleOrDefault
            Dim listaPrecios = catalogoSel.detalleitemequivalencia_precios.ToList

            ComboPrecios.DataSource = listaPrecios
            ComboPrecios.ValueMember = "precio_id"
            ComboPrecios.DisplayMember = "precio"

            If (ComboPrecios.Items.Count > 0) Then
                ucEstructuraCalzado.CurrencyPrecioVenta.DecimalValue = ComboPrecios.Text
            End If
        End If
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

    Private Function ValidarForm() As Boolean
        Dim listaErrores As Integer = 0
        'If chPedido.Checked = True Then
        If ucEstructuraCalzado.ComboTerminosPago.Text = "CONTADO" Then

            Select Case ucEstructuraCalzado.RBFullName.Checked = True
                Case True
                    If ucEstructuraCalzado.TextProveedor.Tag Is Nothing Then
                        ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, "Ingrese un cliente")
                        listaErrores += 1
                        UCCondicionesPago.Visible = False
                        btGrabar.Text = "Cobrar - F2"
                        MessageBox.Show("Debe identificar el cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        If ucEstructuraCalzado IsNot Nothing Then
                            ucEstructuraCalzado.Visible = True
                            ucEstructuraCalzado.BringToFront()
                            ucEstructuraCalzado.Show()
                            UCCondicionesPago.Visible = False
                        End If
                    Else
                        ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, Nothing)
                    End If


                Case False
                    If ucEstructuraCalzado.TextProveedor.Text.Trim.Length = 0 Then
                        ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, "Ingrese un cliente")
                        listaErrores += 1
                        UCCondicionesPago.Visible = False
                        btGrabar.Text = "Cobrar - F2"
                        MessageBox.Show("Debe identificar el cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        If ucEstructuraCalzado IsNot Nothing Then
                            ucEstructuraCalzado.Visible = True
                            ucEstructuraCalzado.BringToFront()
                            ucEstructuraCalzado.Show()
                            UCCondicionesPago.Visible = False
                        End If
                    Else
                        ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, Nothing)
                    End If
            End Select




            If UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.Items.Count = 0 Then
                ucEstructuraCalzado.ErrorProvider1.SetError(BunifuFlatButton2, "no tiene configurada un caja")
                listaErrores += 1
            Else
                ucEstructuraCalzado.ErrorProvider1.SetError(BunifuFlatButton2, Nothing)
            End If
        End If

        'If ucEstructuraCalzado.TxtDia.Text.Trim.Length = 0 Then
        '    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TxtDia, "Identificar la fecha de compra")
        '    listaErrores += 1
        'Else
        '    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TxtDia, Nothing)
        'End If

        'If ComboComprobante.Text.Trim.Length = 0 Then
        '    ErrorProvider1.SetError(ComboComprobante, "Ingrese un comprobante")
        '    listaErrores += 1
        'Else
        '    ErrorProvider1.SetError(ComboComprobante, Nothing)
        'End If

        'If UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue <= 0 Then
        '    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.txtTipoCambio, "Ingrese un tipo de cambio mayor a cero")
        '    listaErrores += 1
        'Else
        '    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.txtTipoCambio, Nothing)
        'End If

        If ucEstructuraCalzado.txtIva.DoubleValue <= 0 Then
            ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.txtIva, "Ingrese una tasa de igv. mayor a cero")
            listaErrores += 1
        Else
            ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.txtIva, Nothing)
        End If


        Select Case ucEstructuraCalzado.RBFullName.Checked = True
            Case True
                If ucEstructuraCalzado.TextProveedor.Tag Is Nothing Then
                    ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, Nothing)
                End If

            Case False
                If ucEstructuraCalzado.TextProveedor.Text.Trim.Length = 0 Then
                    ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, Nothing)
                End If

                If ucEstructuraCalzado.TextProveedor.Tag Is Nothing Then
                    ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ucEstructuraCalzado.ErrorProvider1.SetError(ucEstructuraCalzado.TextProveedor, Nothing)
                End If
        End Select

        Select Case ComboComprobante.Text
            Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"

            Case Else
                If CDec(txtTotalPagar.Value) <= 0 Then
                    ucEstructuraCalzado.ErrorProvider1.SetError(txtTotalPagar, "La venta debe ser mayor a cero")
                    listaErrores += 1
                Else
                    ucEstructuraCalzado.ErrorProvider1.SetError(txtTotalPagar, Nothing)
                End If
        End Select

        If listaErrores > 0 Then
            ValidarForm = False
        Else
            ValidarForm = True
        End If
    End Function

    Sub IrPago()
        btGrabar.Text = "Guardar - F2"

        '  If UCCondicionesPago.RBPagoAcumulado.Checked = True Then
        ucEstructuraCalzado.Visible = False
        If UCCondicionesPago IsNot Nothing Then
            ' If UCEstructuraCabeceraVentaV2.cboMoneda.Text = "NUEVO SOL" Then
            'UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotal.DecimalValue = CDec(UCEstructuraCabeceraVentaV2.txtTotalPagar.Value)
            'Else
            UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotal.DecimalValue = CDec(txtTotalPagar.Value)
            UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotalME.DecimalValue = 0 'CDec(ucEstructuraCalzado.DigitalME.Value)
            'End If

            UCCondicionesPago.Dock = DockStyle.Fill
            UCCondicionesPago.Visible = True
            UCCondicionesPago.BringToFront()
            If UCCondicionesPago.RBPagoAcumulado.Checked = True Then
                If ucEstructuraCalzado.cboMoneda.Text = "NUEVO SOL" Then
                    UCCondicionesPago.UCPagoCompletoDocumento.LabelTotalCobrarCliente.Text = CDec(txtTotalPagar.Value)
                Else
                    UCCondicionesPago.UCPagoCompletoDocumento.LabelTotalCobrarCliente.Text = 0 ' CDec(UCEstructuraCabeceraVentaV2.DigitalME.Value)
                End If

                UCCondicionesPago.UCPagoCompletoDocumento.TextTotalPagosCliente.DecimalValue = 0
                UCCondicionesPago.UCPagoCompletoDocumento.LabelVueltoCliente.Text = "0.00"

                If IsNumeric(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue) Then
                    UCCondicionesPago.UCPagoCompletoDocumento.GetLoadGridCajas(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)
                End If
                'UCCondicionesPago.UCPagoCompletoDocumento.LoadGrid()
                'UCCondicionesPago.UCPagoCompletoDocumento.SumaPagos()
            ElseIf UCCondicionesPago.RBCronograma.Checked = True Then
                If ucEstructuraCalzado.cboMoneda.Text = "NUEVO SOL" Then
                    '    UCCondicionesPago.UCCronogramaPagos.TextImporte.DecimalValue = CDec(UCEstructuraCabeceraVentaV2.txtTotalPagar.Value)
                Else

                    '   UCCondicionesPago.UCCronogramaPagos.TextImporte.DecimalValue = CDec(UCEstructuraCabeceraVentaV2.DigitalME.Value)
                End If

            End If
            UCCondicionesPago.Show()
            UCCondicionesPago.UCPagoCompletoDocumento.TextTotalPagosCliente.Select()
            UCCondicionesPago.UCPagoCompletoDocumento.TextTotalPagosCliente.Focus()
        End If
        'ElseIf UCCondicionesPago.RBCronograma.Checked = True Then

        'End If
    End Sub

    Private Sub BtGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Cursor = Cursors.WaitCursor
        If BunifuFlatButton2.Visible = True Then
            Select Case btGrabar.Text
                Case "Cobrar - F2"
                    If ValidarForm() = True Then
                        IrPago()
                    End If
                Case "Guardar - F2"
                    '      UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = True
                    If ValidarForm() = True Then
                        Application.DoEvents()
                        Grabarventa()
                    End If
                Case "Editar - F2"
                    '      EditaDocumentoVenta()
            End Select
        Else
            'UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = True
            If ValidarForm() = True Then
                Select Case btGrabar.Text
                    Case "Guardar - F2"
                        Application.DoEvents()
                        Grabarventa()
                    Case "Editar - F2"
                        Application.DoEvents()
                        '  EditaDocumentoVenta()
                End Select

            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TextCodigoBarra_TextChanged(sender As Object, e As EventArgs) Handles TextCodigoBarra.TextChanged

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim r As Record = ucEstructuraCalzado.GridCompra.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim codigo = r.GetValue("codigo")
            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigo).SingleOrDefault
            If item IsNot Nothing Then
                If item.tipobeneficio Is Nothing Then
                    ' LimpiarPagos(ListaproductosVendidos)
                    If item.CustomListaVentaDetalle IsNot Nothing Then
                        For Each i In item.CustomListaVentaDetalle
                            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = i.CodigoCosto).Single
                            ListaproductosVendidos.Remove(prod)
                        Next
                    End If
                    item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
                    ListaproductosVendidos.Remove(item)

                    ucEstructuraCalzado.LoadCanastaVentas(ListaproductosVendidos)
                    ucEstructuraCalzado.GetTotalesDocumento()
                End If
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton2.Click
        Cursor = Cursors.WaitCursor
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "INFORMACION GENERAL"
                If UCCondicionesPago IsNot Nothing Then
                    UCCondicionesPago.Visible = False
                End If
                btGrabar.Text = "Cobrar - F2"
                If ucEstructuraCalzado IsNot Nothing Then
                    ucEstructuraCalzado.Visible = True
                    ucEstructuraCalzado.BringToFront()
                    ucEstructuraCalzado.Show()
                End If
            Case "DISTRIBUCION"

            Case "CONDICIONES DE PAGO"
                'UCTransporteDistribucionProductos.Visible = False
                btGrabar.Text = "Guardar - F2"
                ucEstructuraCalzado.Visible = False
                If UCCondicionesPago IsNot Nothing Then
                    If ucEstructuraCalzado.cboMoneda.Text = "NUEVO SOL" Then
                        UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotal.DecimalValue = CDec(txtTotalPagar.Value)
                        UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotalME.DecimalValue = 0 ' CDec(ucEstructuraCalzado.DigitalME.Value)

                        UCCondicionesPago.UCPagoCompletoDocumento.LabelTotalCobrarCliente.Text = CDec(txtTotalPagar.Value)
                    Else
                        UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotal.DecimalValue = CDec(txtTotalPagar.Value)
                        UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotalME.DecimalValue = 0 'CDec(ucEstructuraCalzado.DigitalME.Value)

                        UCCondicionesPago.UCPagoCompletoDocumento.LabelTotalCobrarCliente.Text = 0 ' CDec(ucEstructuraCalzado.DigitalME.Value)
                    End If
                    UCCondicionesPago.UCPagoCompletoDocumento.TextTotalPagosCliente.DecimalValue = 0
                    UCCondicionesPago.UCPagoCompletoDocumento.LabelVueltoCliente.Text = "0.00"
                    UCCondicionesPago.Dock = DockStyle.Fill
                    UCCondicionesPago.Visible = True
                    UCCondicionesPago.BringToFront()
                    If UCCondicionesPago.RBPagoAcumulado.Checked = True Then
                        If IsNumeric(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue) Then
                            UCCondicionesPago.UCPagoCompletoDocumento.GetLoadGridCajas(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)

                            Dim pagos As Decimal = 0
                            Dim pagosME As Decimal = 0
                            'If UCEstructuraCabeceraVentaV2.cboMoneda.SelectedValue = "1" Then
                            pagos = UCCondicionesPago.UCPagoCompletoDocumento.SumaPagos()
                            'Else
                            pagosME = UCCondicionesPago.UCPagoCompletoDocumento.SumaPagosME()
                            'End If

                            UCCondicionesPago.UCPagoCompletoDocumento.TextSaldo.DecimalValue = UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotal.DecimalValue - pagos
                            UCCondicionesPago.UCPagoCompletoDocumento.TextSaldoME.DecimalValue = UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotalME.DecimalValue - pagosME
                        End If
                        'UCCondicionesPago.UCPagoCompletoDocumento.LoadGrid()
                        'UCCondicionesPago.UCPagoCompletoDocumento.SumaPagos()
                    ElseIf UCCondicionesPago.RBCronograma.Checked = True Then
                        If ucEstructuraCalzado.cboMoneda.Text = "NUEVO SOL" Then
                            ' UCCondicionesPago.UCCronogramaPagos.TextImporte.DecimalValue = CDec(UCEstructuraCabeceraVentaV2.txtTotalPagar.Value)
                        Else
                            ' UCCondicionesPago.UCCronogramaPagos.TextImporte.DecimalValue = CDec(UCEstructuraCabeceraVentaV2.DigitalME.Value)
                        End If

                    End If
                    UCCondicionesPago.Show()
                    UCCondicionesPago.UCPagoCompletoDocumento.TextTotalPagosCliente.Select()
                    UCCondicionesPago.UCPagoCompletoDocumento.TextTotalPagosCliente.Focus()
                End If
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Function MappingDocumento() As documento
        Dim tipoOper As String

        Select Case ComboComprobante.Text
            Case "OTRA SALIDA DE ALMACEN"
                tipoOper = General.StatusTipoOperacion.OTRAS_SALIDAS_DE_ALMACEN
            Case "TRANSFERENCIA ENTRE ALMACENES"
                tipoOper = General.StatusTipoOperacion.TRANSFERENCIA_ENTRE_ALMACENES
            Case Else
                tipoOper = General.StatusTipoOperacion.VENTA

        End Select

        MappingDocumento = New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = ucEstructuraCalzado.cboTipoDoc.SelectedValue,
        .fechaProceso = DateTime.Now,' fechaVenta,
        .moneda = If(ucEstructuraCalzado.cboMoneda.Text = "NUEVO SOL", "1", "2"),
        .idEntidad = ucEstructuraCalzado.TextProveedor.Tag,
        .entidad = ucEstructuraCalzado.TextProveedor.Text,
        .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
        .nrodocEntidad = ucEstructuraCalzado.TextNumIdentrazon.Text,
        .nroDoc = "0",'$"{UCEstructuraCabeceraVentaV2.txtSerie.Text}-{UCEstructuraCabeceraVentaV2.txtNumero.Text}",
        .idOrden = 0,
        .tipoOperacion = tipoOper,'StatusTipoOperacion.VENTA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        If btGrabar.Text = "Editar - F2" Then
            'MappingDocumento.idDocumento = venta.idDocumento
        End If

    End Function

    Private Function GetConfiguracionUsuario(usuarioSel As Seguridad.Business.Entity.Usuario, cajaUsuario As cajaUsuario) As EnvioImpresionVendedorPernos
        Dim envio As EnvioImpresionVendedorPernos
        envio = New EnvioImpresionVendedorPernos With
            {
            .CodigoVendedor = UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Text.Trim,
            .IDCaja = cajaUsuario.idcajaUsuario,' ComboCaja.SelectedValue,
            .IDVendedor = usuarioSel.IDUsuario,
            .print = True,
            .Nombreprint = String.Empty,
            .NombreCajero = UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.Text,
            .EntidadFinanciera = 0,'ef.idestado,
            .EntidadFinancieraName = String.Empty
        }
        Return envio
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

        Select Case be.moneda
            Case "1"
                base1 = txtTotalBase.DecimalValue
                base2 = txtTotalBase2.DecimalValue
                base1ME = 0 'Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
                base2ME = 0 'Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase2.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
                iva1 = txtTotalIva.DecimalValue
                iva1ME = 0 'Math.Round(UCEstructuraCabeceraVentaV2.txtTotalIva.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                total = CDec(txtTotalPagar.Value)
                totalME = 0 'Math.Round(UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                icbper = txtTotalIcbper.DecimalValue
                icbperME = Math.Round(txtTotalIcbper.DecimalValue / ucEstructuraCalzado.txtTipoCambio.DecimalValue, 2)

            Case "2"

                base1ME = txtTotalBaseME.DecimalValue
                base2ME = txtTotalBase2ME.DecimalValue

                base1 = txtTotalBase.DecimalValue
                base2 = txtTotalBase2.DecimalValue

                iva1ME = txtTotalIvaME.DecimalValue
                iva1 = txtTotalIva.DecimalValue

                totalME = 0 'CDec(ucEstructuraCalzado.DigitalME.Value)
                total = CDec(txtTotalPagar.Value)

                icbperME = txtTotalIcbperME.DecimalValue
                icbper = txtTotalIcbper.DecimalValue
        End Select

        Select Case ComboComprobante.Text
            Case "VENTA"

                tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
            Case "PRE VENTA"
                tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO

            Case "NOTA DE VENTA"
                tipoVenta = TIPO_VENTA.NOTA_DE_VENTA
            Case "OTRA SALIDA DE ALMACEN"
                tipoVenta = TIPO_COMPRA.OTRAS_SALIDAS

            Case "TRANSFERENCIA ENTRE ALMACENES"
                tipoVenta = TIPO_COMPRA.TRANSFERENCIA_ENTRE_ALMACEN

            Case "PROFORMA"
                tipoVenta = TIPO_VENTA.COTIZACION
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
        .tipoOperacion = be.tipoOperacion,
        .idEmpresa = be.idEmpresa,
        .idEstablecimiento = be.idCentroCosto,
        .fechaLaboral = Date.Now,
        .fechaDoc = be.fechaProceso,
        .fechaVcto = Nothing,
        .fechaPeriodo = GetPeriodo(be.fechaProceso, True),
        .tipoDocumento = be.tipoDoc,
        .idCliente = be.idEntidad,
        .nombrePedido = be.entidad,
        .moneda = be.moneda,
        .tasaIgv = ucEstructuraCalzado.txtIva.DoubleValue,
        .tipoCambio = ucEstructuraCalzado.txtTipoCambio.DecimalValue,
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
        .importeCostoMN = 0, 'If(ucEstructuraCalzado.TextDescuento.DecimalValue > 0, ucEstructuraCalzado.TextDescuento.DecimalValue, 0),
        .terminos = ucEstructuraCalzado.ComboTerminosPago.Text,
        .ImporteNacional = total,
        .ImporteExtranjero = totalME,
        .tipoVenta = tipoVenta,
        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
        .glosa = "Salida de mercadería",
        .sustentado = "S",
        .idPadre = 0,
        .estadoEntrega = "1",
        .usuarioActualizacion = be.usuarioActualizacion,' usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        If btGrabar.Text = "Editar - F2" Then
            'obj.idDocumento = venta.idDocumento
            'obj.serieVenta = venta.serieVenta
            'obj.serie = venta.serie
            'obj.numeroVenta = venta.numeroVenta
            'obj.numeroDoc = venta.numeroDoc
        End If
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
                            .montokardexUS = i.montokardexUS.GetValueOrDefault,
                            .montoIscUS = 0,
                            .montoIgvUS = i.montoIgvUS.GetValueOrDefault,
                            .otrosTributosUS = 0,
                            .entregado = "1",
                            .estadoPago = i.estadoPago,
                            .detalleAdicional = i.detalleAdicional,
                            .tipobeneficio = i.tipobeneficio,
                            .bonificacion = Boolean.Parse(i.FlagBonif),
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }

                Case Else
                    If i.CustomEquivalencia.fraccionUnidad <= 0 Then
                        Throw New Exception($"Debe ingresar un factor de conversión > 0, para el Producto-{i.CustomProducto.descripcionItem}")
                    End If
                    'precUnitEquivalencia = i.monto1 * i.CustomEquivalencia.fraccionUnidad

                    If ComboComprobante.Text = "OTRA SALIDA DE ALMACEN" Or ComboComprobante.Text = "TRANSFERENCIA ENTRE ALMACENES" Then

                    Else

                        If i.FlagBonif = "False" Then
                            If i.importeMN.GetValueOrDefault <= 0 Then
                                Throw New Exception($"Debe ingresar un importe de venta > 0, para el Producto-{i.CustomProducto.descripcionItem}")
                            End If
                        End If
                    End If


                    objDet = New documentoventaAbarrotesDet With
                            {
                            .CustomtotalesAlmacenOthers = i.CustomtotalesAlmacenOthers,
                            .tasaIcbper = i.tasaIcbper,
                            .detalleAdicional = i.detalleAdicional,
                            .montoIcbper = i.montoIcbper,
                            .AfectoInventario = i.AfectoInventario,
                            .estadoMovimiento = i.AfectoInventario.ToString(),
                            .CodigoCosto = i.CodigoCosto,
                            .CustomEquivalencia = i.CustomEquivalencia,
                            .ContenidoNetoUnidadComercialMaxima = i.ContenidoNetoUnidadComercialMaxima.GetValueOrDefault,
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
                            .montokardexUS = i.montokardexUS.GetValueOrDefault,
                            .montoIscUS = 0,
                            .montoIgvUS = i.montoIgvUS.GetValueOrDefault,
                            .otrosTributosUS = 0,
                            .entregado = "1",
                            .estadoPago = i.estadoPago,
                            .bonificacion = Boolean.Parse(i.FlagBonif),
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .tipobeneficio = i.tipobeneficio,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }

                    If ComboComprobante.Text = "TRANSFERENCIA ENTRE ALMACENES" Then
                        objDet.idAlmacenOrigen = i.idAlmacenOrigen
                    End If

                    'If i.CustomProducto.tipoExistencia = TipoExistencia.Kit Then
                    '    AgregarArticulosConexos(i.CustomProducto.detalleitems_conexo.ToList, obj, i.monto1)

                    'End If

            End Select



            If btGrabar.Text = "Editar - F2" Then
                'objDet.idDocumento = venta.idDocumento
                objDet.secuencia = i.secuencia
            End If

            obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet)
        Next
    End Sub

    Private Sub MappingPagos(envio As EnvioImpresionVendedorPernos, obj As documento)
        Dim ListaPagos = ListaPagosCajas(obj.documentoventaAbarrotes, obj.documentoventaAbarrotes.documentoventaAbarrotesDet, envio)
        obj.ListaCustomDocumento = ListaPagos.ToList

        Dim SumaPagos As Decimal = 0
        For Each i In ListaPagos
            SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
        Next
        If SumaPagos = obj.documentoventaAbarrotes.ImporteNacional Then 'txtTotalPagar.DecimalValue Then
            obj.documentoventaAbarrotes.terminos = "CONTADO"
        Else
            'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
            obj.documentoventaAbarrotes.terminos = "CREDITO"
        End If
        obj.documentoventaAbarrotes.estadoCobro = obj.documentoventaAbarrotes.GetEstadoPagoComprobante
    End Sub

    Public Function ListaPagosCajas(venta As documentoventaAbarrotes, ventaDetalle As List(Of documentoventaAbarrotesDet), envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        For Each i In UCCondicionesPago.UCPagoCompletoDocumento.GridCompra.Table.Records
            If Decimal.Parse(i.GetValue("monto")) > 0 Then
                nDocumentoCaja = New documento
                nDocumentoCaja.idDocumento = 0 'CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
                nDocumentoCaja.tipoDoc = "9903" ' cbotipoDocPago.SelectedValue
                nDocumentoCaja.nroDoc = "0"
                nDocumentoCaja.fechaProceso = venta.fechaDoc
                nDocumentoCaja.moneda = i.GetValue("moneda")

                nDocumentoCaja.idEntidad = venta.idCliente
                nDocumentoCaja.entidad = ucEstructuraCalzado.TextProveedor.Text
                nDocumentoCaja.nrodocEntidad = ucEstructuraCalzado.TextNumIdentrazon.Text

                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                nDocumentoCaja.usuarioActualizacion = envio.IDCaja ' usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now


                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                objCaja.idDocumento = 0
                objCaja.periodo = venta.fechaPeriodo
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = venta.fechaDoc
                objCaja.fechaCobro = venta.fechaDoc
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                objCaja.codigoProveedor = venta.idCliente
                objCaja.IdProveedor = venta.idCliente
                objCaja.idPersonal = venta.idCliente
                objCaja.TipoDocumentoPago = "9903" 'cbotipoDocPago.SelectedValue
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = "9903" ' venta.tipoDocumento
                objCaja.formapago = i.GetValue("IDforma")
                objCaja.formaPagoName = i.GetValue("forma")
                objCaja.NumeroDocumento = "-"
                Dim numeroop = i.GetValue("nrooper")

                If numeroop.ToString.Trim.Length > 0 Then
                    objCaja.numeroOperacion = i.GetValue("nrooper")
                End If

                If i.GetValue("IDforma") = "006" Or i.GetValue("IDforma") = "007" Then
                    objCaja.estadopago = 1
                End If

                Select Case venta.tipoDocumento
                    Case "9907"
                        objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
                    Case "9903"
                        objCaja.movimientoCaja = TIPO_VENTA.PROFORMA
                    Case Else
                        objCaja.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA
                End Select
                objCaja.montoSoles = Decimal.Parse(i.GetValue("monto"))

                objCaja.moneda = i.GetValue("moneda")
                objCaja.tipoCambio = Decimal.Parse(i.GetValue("tipocambio"))
                objCaja.montoUsd = Decimal.Parse(i.GetValue("montoME"))

                objCaja.estado = "1"
                objCaja.estadopago = 0
                objCaja.glosa = "Venta de mercaderías"
                objCaja.entregado = "SI"

                objCaja.entidadFinanciera = i.GetValue("idCuenta")
                objCaja.NombreEntidad = i.GetValue("Cuenta")
                objCaja.idCajaUsuario = envio.IDCaja 'GFichaUsuarios.IdCajaUsuario
                objCaja.usuarioModificacion = envio.IDCaja 'usuario.IDUsuario

                objCaja.fechaModificacion = DateTime.Now
                nDocumentoCaja.documentoCaja = objCaja
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle, envio)
                ListaDoc.Add(nDocumentoCaja)
            End If
        Next

        Return ListaDoc
    End Function

    Private Function GetDetallePago(objCaja As documentoCaja, ventaDetalle As List(Of documentoventaAbarrotesDet), envio As EnvioImpresionVendedorPernos) As List(Of documentoCajaDetalle)
        Dim listaBeneficio As New List(Of String)
        listaBeneficio.Add("OFERTA")
        listaBeneficio.Add("REGALO")
        Dim montoPago = objCaja.montoSoles
        Dim montoPagoME = objCaja.montoUsd

        GetDetallePago = New List(Of documentoCajaDetalle)
        For Each i In ventaDetalle.Where(Function(o) Not listaBeneficio.Contains(o.tipobeneficio)).ToList()

            If ucEstructuraCalzado.cboMoneda.SelectedValue = "1" Then
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

                        If ucEstructuraCalzado.cboMoneda.SelectedValue = "1" Then
                            GetDetallePago.Add(New documentoCajaDetalle With
                                       {
                                       .fecha = Date.Now,
                                       .destino = i.CodigoCosto,
                                       .otroMN = 0,
                                       .idItem = i.idItem,
                                       .DetalleItem = i.nombreItem,
                                       .montoSoles = (i.MontoPago + i.montoIcbper.GetValueOrDefault),
                                       .montoUsd = 0,'(i.MontoPagoME + i.montoIcbper.GetValueOrDefault),' FormatNumber((i.MontoPago + i.montoIcbper.GetValueOrDefault) / TmpTipoCambio, 2),
                                       .diferTipoCambio = i.tipoCambio,
                                       .tipoCambioTransacc = i.tipoCambio,
                                       .entregado = "SI",
                                       .idCajaUsuario = envio.IDCaja,
                                       .usuarioModificacion = envio.IDCaja,' usuario.IDUsuario,
                                       .documentoAfectado = CInt(Me.Tag),
                                       .documentoAfectadodetalle = i.secuencia,
                                       .EstadoCobro = i.estadoPago,
                                       .fechaModificacion = DateTime.Now
                                       })
                        Else

                            GetDetallePago.Add(New documentoCajaDetalle With
                                       {
                                       .fecha = Date.Now,
                                       .destino = i.CodigoCosto,
                                       .otroMN = 0,
                                       .idItem = i.idItem,
                                       .DetalleItem = i.nombreItem,
                                       .montoSoles = (i.MontoPago + i.montoIcbper.GetValueOrDefault),
                                       .montoUsd = (i.MontoPagoME + i.montoIcbper.GetValueOrDefault),' FormatNumber((i.MontoPago + i.montoIcbper.GetValueOrDefault) / TmpTipoCambio, 2),
                                       .diferTipoCambio = TmpTipoCambio,
                                       .tipoCambioTransacc = TmpTipoCambio,
                                       .entregado = "SI",
                                       .idCajaUsuario = envio.IDCaja,
                                       .usuarioModificacion = envio.IDCaja,' usuario.IDUsuario,
                                       .documentoAfectado = CInt(Me.Tag),
                                       .documentoAfectadodetalle = i.secuencia,
                                       .EstadoCobro = i.estadoPago,
                                       .fechaModificacion = DateTime.Now
                                       })
                        End If
                        '.codigoLote = Integer.Parse(i.codigoLote),




                        i.estadoPago = i.estadoPago
                        'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                        'item.estadoPago = i.EstadoPagos
                    End If
                End If

            Else 'MONEDA DOLARES

                If montoPagoME > 0 Then
                    If i.MontoSaldoME > 0 Then
                        If i.MontoSaldoME > montoPagoME Then
                            Dim canUso = montoPagoME
                            i.MontoPagoME = canUso
                            i.estadoPago = i.ItemPendiente
                        ElseIf i.MontoSaldoME = montoPagoME Then
                            i.MontoPagoME = montoPagoME
                            i.estadoPago = i.ItemSaldado
                        Else
                            Dim canUso = i.MontoSaldoME
                            i.MontoPagoME = canUso
                            i.estadoPago = i.ItemSaldado
                        End If
                        montoPagoME -= i.MontoPagoME 'ImporteDisponible

                        GetDetallePago.Add(New documentoCajaDetalle With
                                       {
                                       .fecha = Date.Now,
                                       .destino = i.CodigoCosto,
                                       .otroMN = 0,
                                       .idItem = i.idItem,
                                       .DetalleItem = i.nombreItem,
                                       .montoSoles = Math.Round(i.MontoPagoME * objCaja.tipoCambio.GetValueOrDefault, 2),
                                       .montoUsd = (i.MontoPagoME + i.montoIcbper.GetValueOrDefault),'(i.MontoPagoME + i.montoIcbper.GetValueOrDefault),' FormatNumber((i.MontoPago + i.montoIcbper.GetValueOrDefault) / TmpTipoCambio, 2),
                                       .diferTipoCambio = objCaja.tipoCambio,
                                       .tipoCambioTransacc = objCaja.tipoCambio,
                                       .entregado = "SI",
                                       .idCajaUsuario = envio.IDCaja,
                                       .usuarioModificacion = envio.IDCaja,' usuario.IDUsuario,
                                       .documentoAfectado = CInt(Me.Tag),
                                       .documentoAfectadodetalle = i.secuencia,
                                       .EstadoCobro = i.estadoPago,
                                       .fechaModificacion = DateTime.Now
                                       })

                        '.codigoLote = Integer.Parse(i.codigoLote),

                        i.estadoPago = i.estadoPago
                        'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                        'item.estadoPago = i.EstadoPagos
                    End If
                End If
            End If


        Next
    End Function

    Private Function validarCanastaDeVentas(obj As documento) As Boolean
        validarCanastaDeVentas = True

        Select Case ComboComprobante.Text
            Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                Dim CantidadesCero = obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Where(Function(o) o.monto1 <= 0).Count

                If CantidadesCero > 0 Then
                    validarCanastaDeVentas = False
                End If
            Case Else
                Dim CantidadesCero = obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Where(Function(o) o.monto1 <= 0 And o.bonificacion = False).Count

                If CantidadesCero > 0 Then
                    validarCanastaDeVentas = False
                End If
        End Select
    End Function

    Private Sub Grabarventa()
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim obj As New documento
        Try
            obj = MappingDocumento()

            Select Case ComboComprobante.Text
                Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES", "PROFORMA", "PRE VENTA"
                    Dim Vendedor = GetCodigoVendedor()
                    If Vendedor Is Nothing Then
                        Throw New Exception("Debe indicar el codigo del vendedor!")
                    End If
                    obj.usuarioActualizacion = Vendedor.IDUsuario
                Case Else
                    Dim Vendedor = GetCodigoVendedor()
                    If Vendedor Is Nothing Then
                        Throw New Exception("Debe indicar el codigo del vendedor!")
                    End If
                    obj.usuarioActualizacion = Vendedor.IDUsuario

                    Dim codigoVendedor = Vendedor.codigo ' UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Text.Trim
                    Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

                    'Dim codigoVendedor = UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Text.Trim
                    'Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

                    If usuarioSel IsNot Nothing Then
                        obj.usuarioActualizacion = usuarioSel.IDUsuario
                        Select Case ucEstructuraCalzado.ComboTerminosPago.Text
                            Case "CONTADO"
                                Dim codigo As Integer = Integer.Parse(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)
                                Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(codigo)
                                '   Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)
                                envio = GetConfiguracionUsuario(usuarioSel, cajaUsuario)
                            Case "CREDITO"

                            Case "CRONOGRAMA"
                                'If UCCondicionesPago.UCCronogramaPagos.ListaCronograma IsNot Nothing Then


                                'If UCCondicionesPago.UCCronogramaPagos.ListaCronograma Is Nothing Then
                                '    Throw New Exception("Debe registrar el cronograma de pagos")
                                'End If

                                'If UCCondicionesPago.UCCronogramaPagos.ListaCronograma.Count <= 0 Then
                                '    Throw New Exception("Debe registrar el cronograma de pagos")
                                'End If

                                'obj.Cronograma = New List(Of Cronograma)
                                'obj.Cronograma = UCCondicionesPago.UCCronogramaPagos.ListaCronograma
                                'Else
                                'Throw New Exception("Debe registrar el cronograma de pagos")
                                'End If

                                'Dim codigo As Integer = Integer.Parse(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)
                                'Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(codigo)
                                'envio = GetConfiguracionUsuario(usuarioSel, cajaUsuario)
                        End Select
                    Else
                        MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        'UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False

                        btGrabar.Enabled = True
                        UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Select()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
            End Select
            MappingDocumentoCompraCabecera(obj)
            MappingDocumentoCompraCabeceraDetalle(obj)

            Select Case ComboComprobante.Text
                Case "VENTA", "NOTA DE VENTA"
                    Select Case obj.tipoDoc
                        Case "03", "01", "9907"

                            Select Case ucEstructuraCalzado.ComboTerminosPago.Text
                                Case "CONTADO"
                                    MappingPagos(envio, obj)
                                Case "CREDITO"

                                Case "CRONOGRAMA"

                            End Select
                        Case "9903", "1000" ' PROFORMA

                    End Select
                Case Else

            End Select

            If validarCanastaDeVentas(obj) Then
                '   obj.AfectaInventario = SwitchInventario.Value
                Dim ListaPagos = obj.ListaCustomDocumento
                Dim doc = ventaSA.GrabarVentaEquivalencia(obj)

                If ucEstructuraCalzado.cboTipoDoc.Text = "FACTURA" Or ucEstructuraCalzado.cboTipoDoc.Text = "BOLETA" Then
                    If My.Computer.Network.IsAvailable = True Then
                        If My.Computer.Network.Ping("138.128.171.106") Then
                            If Gempresas.ubigeo > 0 Then

                                Dim comprobante = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                                doc.documentoventaAbarrotes = comprobante
                                doc.ListaCustomDocumento = ListaPagos

                                'EnviarFacturaElectronica(doc, Gempresas.ubigeo)

                                FormImpresionNuevo = New FormImpresionEquivalencia(doc)  ' frmVentaNuevoFormato
                                FormImpresionNuevo.tienda = ""
                                FormImpresionNuevo.FormaPago = ""
                                FormImpresionNuevo.DocumentoID = doc.idDocumento
                                FormImpresionNuevo.Email = ""
                                FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                                FormImpresionNuevo.ShowDialog(Me)

                            End If
                        End If
                    Else
                        MessageBox.Show("Envío a Respositorio!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False
                        'Alert = New Alert("Envio a Respositorio", alertType.success)
                        'Alert.TopMost = True
                        'Alert.Show()
                    End If
                ElseIf ucEstructuraCalzado.cboTipoDoc.Text = "PROFORMA" Or ucEstructuraCalzado.cboTipoDoc.Text = "NOTA DE VENTA" Or ucEstructuraCalzado.cboTipoDoc.Text = "NOTA" Then
                    Dim comprobante = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                    doc.documentoventaAbarrotes = comprobante
                    doc.ListaCustomDocumento = ListaPagos
                    FormImpresionNuevo = New FormImpresionEquivalencia(doc)  ' frmVentaNuevoFormato
                    FormImpresionNuevo.tienda = ""
                    FormImpresionNuevo.FormaPago = ""
                    FormImpresionNuevo.DocumentoID = doc.idDocumento
                    FormImpresionNuevo.Email = ""
                    FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                    FormImpresionNuevo.ShowDialog(Me)
                ElseIf ucEstructuraCalzado.cboTipoDoc.Text = "PRE VENTA" Then
                    Dim statusForm As New frmMensajeCodigoVenta
                    statusForm.StartPosition = FormStartPosition.CenterScreen
                    statusForm.lblMensaje.Text = doc.CustomNumero '.Replace("0", "")
                    statusForm.ShowDialog()
                End If

                '   MessageBox.Show("Operación registrada!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LimpiarControles()
                'Close()
            Else
                MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Verificar el detalle de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btGrabar.Enabled = True
                '    UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
            'UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False
        End Try
    End Sub

    Private Sub GetDocumentosDefault()
        Dim documentos As New List(Of String)
        documentos.Add("01")
        documentos.Add("03")

        ucEstructuraCalzado.cboTipoDoc.DataSource = ucEstructuraCalzado.ListaDocumentos.Where(Function(o) documentos.Contains(o.codigoDetalle)).ToList
        ucEstructuraCalzado.cboTipoDoc.DisplayMember = "descripcion"
        ucEstructuraCalzado.cboTipoDoc.ValueMember = "codigoDetalle"
    End Sub

    Private Sub LimpiarControles()

        PanelBody.Controls.Clear()

        ucEstructuraCalzado = New ucEstructuraCalzado(Me)
        UCCondicionesPago = New ucPagoVentaCalzado(Me)

        sliderTop.Left = BunifuFlatButton15.Left
        sliderTop.Width = BunifuFlatButton15.Width

        UCCondicionesPago.Visible = False
        btGrabar.Text = "Cobrar - F2"
        If ucEstructuraCalzado IsNot Nothing Then
            ucEstructuraCalzado.Visible = True
            ucEstructuraCalzado.BringToFront()
            ucEstructuraCalzado.Show()
        End If

        ' Add any initialization after the InitializeComponent() call.
        'UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        'PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        ucEstructuraCalzado.Dock = DockStyle.Fill
        PanelBody.Controls.Add(ucEstructuraCalzado)

        PanelBody.Controls.Add(UCCondicionesPago)
        GetDocumentosDefault()
#Region "Reiniciar ComboBoxVenta"
        If ucEstructuraCalzado IsNot Nothing Then
            ucEstructuraCalzado.RBFullName.Visible = True
            ucEstructuraCalzado.ComboTerminosPago.Text = "CONTADO"
            ucEstructuraCalzado.ComboTerminosPago.Enabled = True

            ucEstructuraCalzado.GridCompra.TableDescriptor.Columns("afectoInventario").Width = 50

            'UCEstructuraCabeceraVentaV2.ComboTerminosPago.Enabled = False
            ' ucEstructuraCalzado.txtTotalPagar.Visible = True
            ucEstructuraCalzado.Label13.Visible = True
            ucEstructuraCalzado.ComboTerminosPago.Visible = True
        End If
        Select Case ComboComprobante.Text
            Case "VENTA"
                If ucEstructuraCalzado IsNot Nothing Then
                    ToolStripButton4.Visible = True

                    Dim documentos As New List(Of String)

                    'If Gempresas.ubigeo IsNot Nothing Then
                    documentos.Add("01")
                        documentos.Add("03")
                    'End If

                    ucEstructuraCalzado.cboTipoDoc.DataSource = ucEstructuraCalzado.ListaDocumentos.Where(Function(o) documentos.Contains(o.codigoDetalle)).ToList
                    ucEstructuraCalzado.cboTipoDoc.DisplayMember = "descripcion"
                    ucEstructuraCalzado.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = True
                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Cobrar - F2"
                End If



                If ucEstructuraCalzado IsNot Nothing Then
                    ucEstructuraCalzado.Visible = True
                    ucEstructuraCalzado.BringToFront()
                    ucEstructuraCalzado.Show()
                End If


            Case "PRE VENTA"
                If ucEstructuraCalzado IsNot Nothing Then
                    ucEstructuraCalzado.cboTipoDoc.DataSource = ucEstructuraCalzado.ListaDocumentos.Where(Function(o) o.codigoDetalle = "1000").ToList
                    ucEstructuraCalzado.cboTipoDoc.DisplayMember = "descripcion"
                    ucEstructuraCalzado.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Guardar - F2"
                    ucEstructuraCalzado.ComboTerminosPago.Text = "CREDITO"
                    ucEstructuraCalzado.ComboTerminosPago.Enabled = False

                    ToolStripButton4.Visible = True
                    ucEstructuraCalzado.GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0

                    ucEstructuraCalzado.RadioButton2.Checked = True
                    ucEstructuraCalzado.TextNumIdentrazon.Enabled = False
                    ucEstructuraCalzado.TextNumIdentrazon.Text = VarClienteGeneral.idEntidad
                    ucEstructuraCalzado.TextProveedor.Text = VarClienteGeneral.nombreCompleto
                    ucEstructuraCalzado.TextProveedor.Tag = VarClienteGeneral.idEntidad

                    ucEstructuraCalzado.ComboTerminosPago.Visible = False
                End If

                If ucEstructuraCalzado IsNot Nothing Then
                    ucEstructuraCalzado.Visible = True
                    ucEstructuraCalzado.BringToFront()
                    ucEstructuraCalzado.Show()
                End If

            Case "NOTA DE VENTA"
                If ucEstructuraCalzado IsNot Nothing Then
                    ToolStripButton4.Visible = True
                    ucEstructuraCalzado.cboTipoDoc.DataSource = ucEstructuraCalzado.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9907").ToList
                    ucEstructuraCalzado.cboTipoDoc.DisplayMember = "descripcion"
                    ucEstructuraCalzado.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = True


                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Cobrar - F2"
                End If

                If ucEstructuraCalzado IsNot Nothing Then
                    ucEstructuraCalzado.Visible = True
                    ucEstructuraCalzado.BringToFront()
                    ucEstructuraCalzado.Show()
                End If

            Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                If ucEstructuraCalzado IsNot Nothing Then
                    ToolStripButton4.Visible = False
                    ucEstructuraCalzado.cboTipoDoc.DataSource = ucEstructuraCalzado.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9907").ToList
                    ucEstructuraCalzado.cboTipoDoc.DisplayMember = "descripcion"
                    ucEstructuraCalzado.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False
                    ucEstructuraCalzado.ComboTerminosPago.Text = "CREDITO"

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If

                    btGrabar.Text = "Guardar - F2"
                    txtTotalPagar.Visible = False
                    ucEstructuraCalzado.Label13.Visible = False
                    ucEstructuraCalzado.ComboTerminosPago.Visible = False
                End If

                If ucEstructuraCalzado IsNot Nothing Then
                    ucEstructuraCalzado.Visible = True
                    ucEstructuraCalzado.BringToFront()
                    ucEstructuraCalzado.Show()
                End If

            Case "PROFORMA"
                If ucEstructuraCalzado IsNot Nothing Then
                    ToolStripButton4.Visible = False
                    ucEstructuraCalzado.cboTipoDoc.DataSource = ucEstructuraCalzado.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9903").ToList
                    ucEstructuraCalzado.cboTipoDoc.DisplayMember = "descripcion"
                    ucEstructuraCalzado.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Guardar - F2"
                    ucEstructuraCalzado.ComboTerminosPago.Text = "CREDITO"
                    ucEstructuraCalzado.ComboTerminosPago.Enabled = False
                    ucEstructuraCalzado.GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0
                End If

                If ucEstructuraCalzado IsNot Nothing Then
                    ucEstructuraCalzado.Visible = True
                    ucEstructuraCalzado.BringToFront()
                    ucEstructuraCalzado.Show()
                End If

        End Select
#End Region

        'UCEstructuraCabeceraVentaV2.TextFiltrar.Select()
        'UCEstructuraCabeceraVentaV2.TextFiltrar.Focus()
        ucEstructuraCalzado.GetConfiguracionEmpresa()

        listaProductos = New List(Of detalleitems)
        lstTotalesAlmacen = New List(Of totalesAlmacenOthers)
        catalogoPrecios = New List(Of detalleitemequivalencia_catalogos)
        ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)

        TextCodigoBarra.Clear()
        TextProduct.Clear()
        ComboCatalogo.DataSource = Nothing
        ComboPrecios.DataSource = Nothing

        ucEstructuraCalzado.TextTallaSel.Clear()
        ucEstructuraCalzado.TextTallaSel.Tag = Nothing
        ucEstructuraCalzado.NumericCantidad.Value = 0
        ucEstructuraCalzado.CurrencyPrecioVenta.DecimalValue = 0
        TextCodigoBarra.Select()
    End Sub

    Private Sub ComboPrecios_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboPrecios.SelectionChangeCommitted
        ucEstructuraCalzado.CurrencyPrecioVenta.DecimalValue = ComboPrecios.Text
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim strFileName As String = ""
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Title = "Open an Image"
        OpenFileDialog1.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim DidWork As Integer = OpenFileDialog1.ShowDialog()

        PictureBox1.Image.Tag = Nothing

        If DidWork <> DialogResult.Cancel Then
            strFileName = OpenFileDialog1.FileName
            PictureBox1.Image = Image.FromFile(strFileName)
            PictureBox1.Image.Tag = strFileName
            OpenFileDialog1.Reset()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If PictureBox1.Image.Tag IsNot Nothing Then
            If listaProductos IsNot Nothing Then
                Dim itemSA As New detalleitemsSA
                itemSA.EditarImageUrlProducto(New detalleitems With {.codigodetalle = listaProductos.FirstOrDefault.codigodetalle, .fotoUrl = PictureBox1.Image.Tag})
                MessageBox.Show("Imagen actualizada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class