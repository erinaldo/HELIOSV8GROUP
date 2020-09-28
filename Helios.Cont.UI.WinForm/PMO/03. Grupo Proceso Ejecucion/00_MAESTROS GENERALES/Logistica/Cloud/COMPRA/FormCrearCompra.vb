Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class FormCrearCompra
#Region "Attributes"
    Public UCEstructuraDocumentocabecera As UCEstructuraDocumentocabecera
    Public UCTransporteDistribucionProductos As UCTransporteDistribucionProductos
    Public UCCondicionesPago As UCCondicionesPago
    Public Property ListaPagos As List(Of documento)

    Public Property FormMaestroLogistica As FormMaestroLogistica
#End Region

#Region "Constructors"
    Public Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListaPagos = New List(Of documento)
        UCEstructuraDocumentocabecera = New UCEstructuraDocumentocabecera(Me)
        'UCTransporteDistribucionProductos = New UCTransporteDistribucionProductos(UCEstructuraDocumentocabecera)
        'UCCondicionesPago = New UCCondicionesPago(Me)
        UCEstructuraDocumentocabecera.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCEstructuraDocumentocabecera)
        'PanelBody.Controls.Add(UCTransporteDistribucionProductos)
        'PanelBody.Controls.Add(UCCondicionesPago)
        '  GetDocumentosDefault()
        UbicarDocumentoCompra(IdDocumento)
        BunifuFlatButton1.Visible = False
        BunifuFlatButton2.Visible = False
        ToolStrip1.Enabled = False

        BunifuFlatButton1.Visible = False
        BunifuFlatButton2.Visible = False

        UCEstructuraDocumentocabecera.ComboAlmacen.Visible = False
        UCEstructuraDocumentocabecera.ComboDespacho.Visible = False
    End Sub

    Public Sub New(Logistica As FormMaestroLogistica)

        ' This call is required by the designer.
        InitializeComponent()
        FormMaestroLogistica = Logistica
        Me.KeyPreview = True
        ' Add any initialization after the InitializeComponent() call.
        ListaPagos = New List(Of documento)
        UCEstructuraDocumentocabecera = New UCEstructuraDocumentocabecera(Me)
        UCTransporteDistribucionProductos = New UCTransporteDistribucionProductos(UCEstructuraDocumentocabecera)
        UCCondicionesPago = New UCCondicionesPago(Me)
        UCEstructuraDocumentocabecera.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCEstructuraDocumentocabecera)
        PanelBody.Controls.Add(UCTransporteDistribucionProductos)
        PanelBody.Controls.Add(UCCondicionesPago)
        'GetDocumentosDefault()
        'ComboComprobante.Enabled = False
    End Sub

    Public Sub New(Opcion As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.KeyPreview = True
        ' Add any initialization after the InitializeComponent() call.
        ListaPagos = New List(Of documento)
        UCEstructuraDocumentocabecera = New UCEstructuraDocumentocabecera(Me)
        UCTransporteDistribucionProductos = New UCTransporteDistribucionProductos(UCEstructuraDocumentocabecera)
        UCCondicionesPago = New UCCondicionesPago(Me)
        UCEstructuraDocumentocabecera.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCEstructuraDocumentocabecera)
        PanelBody.Controls.Add(UCTransporteDistribucionProductos)
        PanelBody.Controls.Add(UCCondicionesPago)
        LoadComboOpciones(Opcion)
        'GetDocumentosDefault()
        ' ComboComprobante.Enabled = False
    End Sub



#End Region

#Region "Methods"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.F2
                btGrabar.PerformClick()

            Case Keys.F10
                ToolStripButton3.PerformClick()

            Case Keys.Escape
                Close()

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub LoadComboOpciones(Opcion As String)
        ComboComprobante.Items.Clear()

        Select Case Opcion
            Case "COMPRAS"
                ComboComprobante.Items.Add("Compra recepción directa")
                'ComboComprobante.Items.Add("Recepción directa + distribución")
                'ComboComprobante.Items.Add("Recepción directa + distribución + pago")
                'ComboComprobante.Items.Add("Recepción directa + cronograma de distribución + cronograma de pago")
                ComboComprobante.Text = "Compra recepción directa"
            Case "ALMACEN"
                ComboComprobante.Items.Add("Otra entrada")
                'ComboComprobante.Items.Add("Otra salida")

                ComboComprobante.Text = "Otra entrada"
                'UCEstructuraDocumentocabecera.txtSerie.Visible = False
                'UCEstructuraDocumentocabecera.txtNumero.Visible = False
                'UCEstructuraDocumentocabecera.Label8.Visible = False
                'UCEstructuraDocumentocabecera.Label9.Visible = False

                'UCEstructuraDocumentocabecera.cboTipoDoc.DataSource = UCEstructuraDocumentocabecera.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9907").ToList
                'UCEstructuraDocumentocabecera.cboTipoDoc.DisplayMember = "descripcion"
                'UCEstructuraDocumentocabecera.cboTipoDoc.ValueMember = "codigoDetalle"
                'BUTTON CONDICIONES DE PAGO
                BunifuFlatButton2.Visible = False

                'BUTTON DISTRIBUCION DE PRODUCTOS
                BunifuFlatButton1.Visible = False
                If UCCondicionesPago IsNot Nothing Then
                    UCCondicionesPago.Visible = False
                End If

        End Select

    End Sub

    Private Sub UbicarDocumentoCompra(idDocumento As Integer)
        Dim entidadSA As New entidadSA
        Dim compraSA As New DocumentoCompraSA
        Dim compra = compraSA.GetCompraID(New Business.Entity.documento With {.idDocumento = idDocumento})
        Dim ent = entidadSA.UbicarEntidadPorID(compra.idProveedor).FirstOrDefault
        If compra IsNot Nothing Then
            VerCabeceraDocumento(compra, ent)
            VerDetalleCompra(compra)
        End If
    End Sub

    Private Sub VerCabeceraDocumento(venta As documentocompra, ent As entidad)

        Select Case venta.tipoCompra
            Case TIPO_COMPRA.COMPRA
                ComboComprobante.Text = "Compra recepción directa"
            Case TIPO_COMPRA.NOTA_DE_COMPRA
                ComboComprobante.Text = "NOTA DE COMPRA"
            Case TIPO_COMPRA.OTRAS_ENTRADAS
                ComboComprobante.Text = "Otra entrada"
        End Select
        BunifuFlatButton15.Enabled = False
        ComboComprobante.Enabled = False

        With UCEstructuraDocumentocabecera
            .TxtDia.DecimalValue = venta.fechaDoc.Value.Day
            .cboMesCompra.SelectedValue = String.Format("{0:00}", venta.fechaDoc.Value.Month)
            .TextAnio.DecimalValue = venta.fechaDoc.Value.Year
            .txtHora.Value = venta.fechaDoc.Value
            .cboMoneda.SelectedValue = venta.monedaDoc
            .txtTipoCambio.DecimalValue = venta.tipocambio.GetValueOrDefault
            .txtIva.DoubleValue = venta.tasaIgv
            .cboTipoDoc.SelectedValue = venta.tipoDoc
            .txtSerie.Text = venta.serie
            .txtNumero.Text = venta.numeroDoc


            If ent IsNot Nothing Then
                If ent.tipoEntidad = "VR" Then
                    .RadioButton2.Checked = True
                    .TextProveedor.Tag = ent.idEntidad
                    .TextProveedor.Text = ent.nombreCompleto
                Else
                    .RadioButton1.Checked = True
                    .TextNumIdentrazon.Text = ent.nrodoc
                    .TextProveedor.Text = ent.nombreCompleto
                    .TextProveedor.Tag = ent.idEntidad
                End If
            End If
        End With
    End Sub

    Private Sub VerDetalleCompra(compra As documentocompra)
        Dim productoSA As New detalleitemsSA
        UCEstructuraDocumentocabecera.ListaproductosComprados = compra.documentocompradetalle.ToList
        '     UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)


        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("contenido")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("fraccion")
        dt.Columns.Add("vcmn")
        dt.Columns.Add("pumn")
        dt.Columns.Add("totalmn")
        dt.Columns.Add("vcme")
        dt.Columns.Add("pume")
        dt.Columns.Add("totalme")
        dt.Columns.Add("igvmn")
        dt.Columns.Add("igvme")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("marca")
        dt.Columns.Add("almacen")
        dt.Columns.Add("codigoLote")
        dt.Columns.Add("equivalencia")
        dt.Columns.Add("bonificacion")
        dt.Columns.Add("bonificaionval")

        Dim equivalencia As detalleitem_equivalencias
        Dim id_Equiva = 0
        For Each i In UCEstructuraDocumentocabecera.ListaproductosComprados
            Dim articulo = productoSA.GetUbicaProductoID(i.idItem)
            i.CustomProducto = articulo

            Dim eq = articulo.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = i.equivalencia_id).SingleOrDefault

            i.CustomProducto_equivalencia = eq

            If i.CustomProducto_equivalencia IsNot Nothing Then
                i.CodigoCosto = i.secuencia
                equivalencia = i.CustomProducto_equivalencia
                id_Equiva = i.CustomProducto_equivalencia.equivalencia_id



                dt.Rows.Add(i.secuencia,
                        i.CustomProducto.origenProducto,
                        i.CustomProducto.codigodetalle,
                        i.CustomProducto.descripcionItem,
                        i.CustomProducto.unidad1,
                        i.CustomProducto.composicion,
                        i.monto1,
                        equivalencia.fraccionUnidad.GetValueOrDefault,
                        i.montokardex.GetValueOrDefault, 0,
                        i.importe.GetValueOrDefault,
                        i.montokardexUS.GetValueOrDefault, 0,
                        i.importeUS.GetValueOrDefault,
                        i.montoIgv.GetValueOrDefault,
                        i.montoIgvUS.GetValueOrDefault,
                        i.CustomProducto.tipoExistencia,
                        "-",
                        0,
                        0,
                        id_Equiva, If(i.bonificacion = "S", True, False), i.bonificacion)
            Else
                dt.Rows.Add(i.CodigoCosto,
                        i.CustomProducto.origenProducto,
                        i.CustomProducto.codigodetalle,
                        i.CustomProducto.descripcionItem,
                        i.CustomProducto.unidad1,
                        i.CustomProducto.composicion,
                        i.monto1,
                        "",
                        i.montokardex.GetValueOrDefault, 0,
                        i.importe.GetValueOrDefault,
                        i.montokardexUS.GetValueOrDefault, 0,
                        i.importeUS.GetValueOrDefault,
                        i.montoIgv.GetValueOrDefault,
                        i.montoIgvUS.GetValueOrDefault,
                        i.CustomProducto.tipoExistencia,
                        "-",
                        0,
                        0,
                        "", If(i.bonificacion = "S", True, False), i.bonificacion)
            End If


        Next

        'For Each i In UCEstructuraCabeceraVenta.ListaproductosVendidos
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

        UCEstructuraDocumentocabecera.GridCompra.DataSource = dt
        UCEstructuraDocumentocabecera.GridCompra.Refresh()
        UCEstructuraDocumentocabecera.GetTotalesDocumento()
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click

        'If UCEstructuraDocumentocabecera.CheckDistribucion.Checked = False Then

        'Else
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "INFORMACION GENERAL"
                UCTransporteDistribucionProductos.Visible = False
                UCCondicionesPago.Visible = False
                If UCEstructuraDocumentocabecera IsNot Nothing Then
                    UCEstructuraDocumentocabecera.Visible = True
                    UCEstructuraDocumentocabecera.BringToFront()
                    UCEstructuraDocumentocabecera.Show()
                End If
            Case "DISTRIBUCION"
                If UCEstructuraDocumentocabecera.CheckDistribucion.Checked = True Then
                    UCEstructuraDocumentocabecera.Visible = False
                    UCCondicionesPago.Visible = False
                    If UCTransporteDistribucionProductos IsNot Nothing Then
                        UCTransporteDistribucionProductos.UCDistribucionAlmacen.GridCompra.Table.Records.DeleteAll()
                        UCTransporteDistribucionProductos.GetListaProductos(UCEstructuraDocumentocabecera.ListaproductosComprados)
                        UCTransporteDistribucionProductos.Visible = True
                        'UCEquivalencias.BringToFront()
                        UCTransporteDistribucionProductos.Show()
                    End If
                End If
            Case "CONDICIONES DE PAGO"
                UCTransporteDistribucionProductos.Visible = False
                UCEstructuraDocumentocabecera.Visible = False
                If UCCondicionesPago IsNot Nothing Then
                    UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotal.DecimalValue = CDec(UCEstructuraDocumentocabecera.DigitalTotal.Value)
                    UCCondicionesPago.Dock = DockStyle.Fill
                    UCCondicionesPago.Visible = True
                    UCCondicionesPago.BringToFront()
                    If UCCondicionesPago.RBPagoAcumulado.Checked = True Then
                        UCCondicionesPago.UCPagoCompletoDocumento.LoadGrid()
                        UCCondicionesPago.UCPagoCompletoDocumento.SumaPagos()
                    End If
                    UCCondicionesPago.Show()
                End If
        End Select
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If UCEstructuraDocumentocabecera IsNot Nothing Then
            Dim r As Record = UCEstructuraDocumentocabecera.GridCompra.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim codigo = r.GetValue("codigo")
                Dim item = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigo).SingleOrDefault
                If item IsNot Nothing Then
                    LimpiarPagos(UCEstructuraDocumentocabecera.ListaproductosComprados)
                    UCEstructuraDocumentocabecera.ListaproductosComprados.Remove(item)
                    UCEstructuraDocumentocabecera.LoadCanastaCompras(UCEstructuraDocumentocabecera.ListaproductosComprados)
                    UCEstructuraDocumentocabecera.GetTotalesDocumento()
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Public Sub LimpiarPagos(listaproductosComprados As List(Of documentocompradetalle))
        For Each i In listaproductosComprados
            i.CustomDocumentoCaja = New List(Of documentoCaja)
        Next
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If ValidarForm() Then
                GrabarCompra()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar")
        End Try
    End Sub

    Private Sub GetDocumentosDefault()
        Dim documentos As New List(Of String)
        documentos.Add("01")
        documentos.Add("03")

        UCEstructuraDocumentocabecera.cboTipoDoc.DataSource = UCEstructuraDocumentocabecera.ListaDocumentos.Where(Function(o) documentos.Contains(o.codigoDetalle)).ToList
        UCEstructuraDocumentocabecera.cboTipoDoc.DisplayMember = "descripcion"
        UCEstructuraDocumentocabecera.cboTipoDoc.ValueMember = "codigoDetalle"
    End Sub

    Private Function ValidarForm() As Boolean
        Dim listaErrores As Integer = 0
        'If chPedido.Checked = True Then

        Dim fechaPeriodo = New Date(UCEstructuraDocumentocabecera.cboAnio.Text, CInt(UCEstructuraDocumentocabecera.cboMesPeriodo.SelectedValue), 1)
        Dim fechaProceso = New Date(UCEstructuraDocumentocabecera.TextAnio.Text, CInt(UCEstructuraDocumentocabecera.cboMesCompra.SelectedValue), UCEstructuraDocumentocabecera.TxtDia.Text)

        If fechaProceso.Year > fechaPeriodo.Year Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TxtDia, "La fecha no debe ser despues al periodo seleccionado")
            MessageBox.Show("La fecha no debe ser despues al periodo seleccionado")
            listaErrores += 1
        End If
        If fechaProceso.Year = fechaPeriodo.Year Then
            If fechaProceso.Month > fechaPeriodo.Month Then
                ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TxtDia, "La fecha no debe ser despues al periodo seleccionado")
                MessageBox.Show("La fecha no debe ser despues al periodo seleccionado")
                listaErrores += 1
            End If
        End If

        If fechaProceso > DateTime.Now.Date Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TxtDia, "La fecha no puede ser mayor ala de hoy")
            MessageBox.Show("La fecha no puede ser mayor ala de hoy")
            listaErrores += 1
        End If
        If fechaPeriodo > DateTime.Now.Date Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TxtDia, "La fecha no puede ser mayor ala de hoy")
            MessageBox.Show("El periodo no puede mayor al actual")
            listaErrores += 1
        End If


        If UCEstructuraDocumentocabecera.TextNumIdentrazon.Text = Gempresas.IdEmpresaRuc Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TextNumIdentrazon, "No se puede registrar una compra de la misma empresa")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TextNumIdentrazon, Nothing)
        End If

        If UCEstructuraDocumentocabecera.TxtDia.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TxtDia, "Identificar la fecha")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TxtDia, Nothing)
        End If

        If ComboComprobante.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(ComboComprobante, "Ingrese un comprobante")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(ComboComprobante, Nothing)
        End If

        Select Case ComboComprobante.Text
            Case "Compra recepción directa"
                If UCEstructuraDocumentocabecera.txtSerie.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.txtSerie, "Ingrese el número de serie")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.txtSerie, Nothing)
                End If

                If UCEstructuraDocumentocabecera.txtNumero.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.txtNumero, "Ingrese el número de compra")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.txtNumero, Nothing)
                End If

                If UCEstructuraDocumentocabecera.ComboAlmacen.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.ComboAlmacen, "Indicar el almacén de envío")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.ComboAlmacen, Nothing)
                End If
            Case "Otra entrada"

                If UCEstructuraDocumentocabecera.TextMotivoOperacion.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TextMotivoOperacion, "Indicar el motivo de la operación")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TextMotivoOperacion, Nothing)
                End If

                If UCEstructuraDocumentocabecera.ComboAlmacen.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.ComboAlmacen, "Indicar el almacén de envío")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(UCEstructuraDocumentocabecera.ComboAlmacen, Nothing)
                End If
        End Select



        If UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue <= 0 Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.txtTipoCambio, "Ingrese un tipo de cambio mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.txtTipoCambio, Nothing)
        End If

        If UCEstructuraDocumentocabecera.txtIva.DoubleValue <= 0 Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.txtIva, "Ingrese una tasa de igv. mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.txtIva, Nothing)
        End If

        If UCEstructuraDocumentocabecera.TextProveedor.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TextProveedor, "Ingrese un proveedor")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TextProveedor, Nothing)
        End If

        If UCEstructuraDocumentocabecera.TextProveedor.Tag Is Nothing Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TextProveedor, "Ingrese un proveedor")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.TextProveedor, Nothing)
        End If

        If CDec(UCEstructuraDocumentocabecera.DigitalTotal.Value) <= 0 Then
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.DigitalTotal, "La compra debe ser mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraDocumentocabecera.DigitalTotal, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarForm = False
        Else
            ValidarForm = True
        End If
    End Function

    Private Sub GrabarCompra()
        Dim compraSA As New DocumentoCompraSA
        Dim obj As New documento
        obj = MappingDocumento()
        MappingDocumentoCompraCabecera(obj)
        MappingDocumentoCompraCabeceraDetalle(obj)
        obj = MappingPagos(obj)
        'o.bonificacion = "N" And
        If obj.documentocompra.documentocompradetalle.Where(Function(o) o.importe.GetValueOrDefault = 0).Count > 0 Then
            MessageBox.Show("Debe verificar, que las celdas de importe total de compra, sean mayores a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        compraSA.GrabarCompraEquivalencia(obj)
        MessageBox.Show("Compra registrada!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If FormMaestroLogistica IsNot Nothing Then
            FormMaestroLogistica.ThreadTransito()
        End If
        Close()
    End Sub

    Private Function MappingPagos(obj As documento) As documento
        If UCCondicionesPago.UCPagoCompletoDocumento.DocCaja.Count > 0 Then
            obj.ListaCustomDocumento = UCCondicionesPago.UCPagoCompletoDocumento.DocCaja.ToList
        End If

        Return obj
    End Function

    Private Function GetMappingInventarioTransito(lista As List(Of InventarioMovimiento)) As List(Of inventarioTransito)
        GetMappingInventarioTransito = New List(Of inventarioTransito)
        For Each i In lista
            Select Case ComboComprobante.Text
                Case "Compra recepción directa"
                    i.tipoOperacion = StatusTipoOperacion.COMPRA

                Case "NOTA DE COMPRA"
                    i.tipoOperacion = StatusTipoOperacion.COMPRA

                Case "Otra entrada"
                    i.tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_A_ALMACEN
            End Select


            Dim almacenSel = UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen).SingleOrDefault

            If almacenSel.tipo = "AV" Then
                GetMappingInventarioTransito.Add(New inventarioTransito With
                                             {
                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                             .almacen = i.idAlmacen,
                                             .idProducto = i.idItem,
                                             .cantidad = i.cantidad,
                                             .monto = i.monto,
                                             .montoME = i.montoUSD,
                                             .tipoOperacion = i.tipoOperacion,
                                             .status = 1
                                             })
            End If
        Next
    End Function

    Private Sub MappingDocumentoCompraCabeceraDetalle(obj As documento)
        Dim objDet As documentocompradetalle
        Dim listaProdEnTransito As List(Of inventarioTransito)
        Dim idalmacen As Integer = 0
        For Each i In UCEstructuraDocumentocabecera.ListaproductosComprados

            Dim almacenSel = UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen.Where(Function(o) o.idAlmacen = i.almacenRef).SingleOrDefault

            If almacenSel IsNot Nothing Then
                listaProdEnTransito = New List(Of inventarioTransito)
                'If almacenSel.tipo = "AV" Then

                Select Case UCEstructuraDocumentocabecera.ComboDespacho.Text
                    Case "UN ALMACEN"
                        idalmacen = Integer.Parse(UCEstructuraDocumentocabecera.ComboAlmacen.SelectedValue)
                        For Each c In i.CustomListaInventarioMovimiento.ToList
                            c.idAlmacen = UCEstructuraDocumentocabecera.ComboAlmacen.SelectedValue
                        Next
                        'i.CustomListaInventarioMovimiento.ToList().ForEach(Function(o) o.idAlmacen = UCEstructuraDocumentocabecera.ComboAlmacen.SelectedValue)
                    Case "EN TRANSITO"
                        idalmacen = Integer.Parse(UCEstructuraDocumentocabecera.ComboAlmacen.SelectedValue)
                        ValidarCantidadInventario(i.CustomListaInventarioMovimiento.ToList)
                        listaProdEnTransito = GetMappingInventarioTransito(i.CustomListaInventarioMovimiento.ToList)
                    Case Else
                        idalmacen = i.almacenRef.GetValueOrDefault
                        ValidarCantidadInventario(i.CustomListaInventarioMovimiento.ToList)
                        listaProdEnTransito = GetMappingInventarioTransito(i.CustomListaInventarioMovimiento.ToList)
                End Select
                'End If

                '     Dim listaInventarioCorregida = SumaInventarioMovimiento()

                ' Dim listaCustomInventario = 

                objDet = New documentocompradetalle With
                {
                .inventarioTransito = listaProdEnTransito,
                .CustomListaInventarioMovimiento = i.CustomListaInventarioMovimiento,
                .CustomProducto = i.CustomProducto,
                .CustomProducto_equivalencia = i.CustomProducto_equivalencia,
                .equivalencia_id = i.CustomProducto_equivalencia.equivalencia_id,
                .idItem = i.CustomProducto.codigodetalle,
                .descripcionItem = i.CustomProducto.descripcionItem,
                .tipoExistencia = i.CustomProducto.tipoExistencia,
                .destino = i.CustomProducto.origenProducto,
                .unidad1 = i.CustomProducto.unidad1,
                .monto1 = i.monto1,
                .unidad2 = Nothing,
                .monto2 = i.CustomProducto_equivalencia.fraccionUnidad,
                .precioUnitario = i.precioUnitario.GetValueOrDefault,
                .precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault,
                .importe = i.importe,
                .importeUS = i.importeUS.GetValueOrDefault,
                .montokardex = i.montokardex,
                .montoIsc = 0,
                .montoIgv = i.montoIgv,
                .otrosTributos = 0,
                .montokardexUS = i.montokardexUS.GetValueOrDefault,
                .montoIscUS = 0,
                .montoIgvUS = i.montoIgvUS.GetValueOrDefault,
                .otrosTributosUS = 0,
                .percepcionMN = 0,
                .percepcionME = 0,
                .bonificacion = i.bonificacion,
                .nrolote = i.nrolote,
                .almacenRef = idalmacen,'i.almacenRef.GetValueOrDefault,
                .entregable = "N",
                .estadoPago = i.estadoPago,
                .ItemEntregadototal = i.ItemEntregadototal,
                .usuarioModificacion = usuario.IDUsuario,
                .fechaModificacion = Date.Now
                }
                obj.documentocompra.documentocompradetalle.Add(objDet)
            End If
        Next
    End Sub

    Private Sub ValidarCantidadInventario(ListaInventario As List(Of InventarioMovimiento))

        Dim CerosCount = ListaInventario.Where(Function(o) o.cantidad <= 0).Count
        If CerosCount > 0 Then
            Throw New Exception("Debe completar la distibucion de la compra!")
        End If
    End Sub

    Private Sub MappingDocumentoCompraCabecera(be As documento)
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0
        Dim glosa As String = Nothing
        Dim base1ME As Decimal = 0
        Dim base2ME As Decimal = 0

        Dim iva1 As Decimal = 0
        Dim iva1ME As Decimal = 0
        Dim iva2 As Decimal = 0
        Dim total As Decimal = 0 ' 
        Dim totalME As Decimal = 0 ' UCEstructuraDocumentocabecera.txtTotalPagar.DecimalValue

        Dim TIPOCOMPRA As String = String.Empty

        Select Case ComboComprobante.Text
            Case "Compra recepción directa"
                TIPOCOMPRA = TIPO_COMPRA.COMPRA
                glosa = "Compra recepción directa"
            Case "NOTA DE COMPRA"
                TIPOCOMPRA = TIPO_COMPRA.NOTA_DE_COMPRA
                glosa = "Nota de compra"
            Case "Otra entrada"
                TIPOCOMPRA = TIPO_COMPRA.OTRAS_ENTRADAS
                glosa = UCEstructuraDocumentocabecera.TextMotivoOperacion.Text.Trim
        End Select


        Select Case be.moneda
            Case "1"
                base1 = UCEstructuraDocumentocabecera.txtTotalBase.DecimalValue
                base2 = UCEstructuraDocumentocabecera.txtTotalBase2.DecimalValue
                base1ME = 0 'Math.Round(UCEstructuraDocumentocabecera.txtTotalBase.DecimalValue / UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue, 2)
                base2ME = 0 'Math.Round(UCEstructuraDocumentocabecera.txtTotalBase2.DecimalValue / UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue, 2)
                iva1 = UCEstructuraDocumentocabecera.txtTotalIva.DecimalValue
                iva1ME = 0 ' Math.Round(UCEstructuraDocumentocabecera.txtTotalIva.DecimalValue / UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue, 2)

                total = CDec(UCEstructuraDocumentocabecera.DigitalTotal.Value)
                totalME = 0' Math.Round(CDec(UCEstructuraDocumentocabecera.DigitalTotal.Value) / UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue, 2)
            Case "2"

                base1ME = UCEstructuraDocumentocabecera.txtTotalBaseME.DecimalValue
                base2ME = UCEstructuraDocumentocabecera.txtTotalBase2me.DecimalValue

                base1 = UCEstructuraDocumentocabecera.txtTotalBase.DecimalValue ' * UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue, 2)
                base2 = UCEstructuraDocumentocabecera.txtTotalBase2.DecimalValue ' * UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue, 2)

                iva1ME = UCEstructuraDocumentocabecera.txtTotalIvaME.DecimalValue
                iva1 = UCEstructuraDocumentocabecera.txtTotalIva.DecimalValue

                totalME = CDec(UCEstructuraDocumentocabecera.DigitalME.Value)
                total = CDec(UCEstructuraDocumentocabecera.DigitalTotal.Value) 'Math.Round(CDec(UCEstructuraDocumentocabecera.DigitalTotal.Value) * UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue, 2)
        End Select

        '.fechaContable = GetPeriodo(be.fechaProceso, True),

        Dim obj As New documentocompra With
        {
        .codigoLibro = "8",
        .idEmpresa = be.idEmpresa,
        .idCentroCosto = be.idCentroCosto,
        .fechaLaboral = Date.Now,
        .fechaDoc = be.fechaProceso,
        .fechaVcto = Nothing,
        .fechaContable = UCEstructuraDocumentocabecera.cboMesPeriodo.SelectedValue & "/" & UCEstructuraDocumentocabecera.cboAnio.Text, 'GetPeriodo(be.fechaProceso, True),
        .tipoDoc = be.tipoDoc,
        .serie = UCEstructuraDocumentocabecera.txtSerie.Text.Trim,
        .numeroDoc = UCEstructuraDocumentocabecera.txtNumero.Text.Trim,
        .idProveedor = be.idEntidad,
        .monedaDoc = be.moneda,
        .tasaIgv = UCEstructuraDocumentocabecera.txtIva.DoubleValue,
        .tcDolLoc = UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue,
        .tipocambio = UCEstructuraDocumentocabecera.txtTipoCambio.DecimalValue,
        .bi01 = base1,
        .bi02 = base2,
        .bi03 = 0,
        .bi04 = 0,
        .isc01 = 0,
        .isc02 = 0,
        .isc03 = 0,
        .igv01 = iva1,
        .igv02 = 0,
        .igv03 = 0,
        .otc01 = 0,
        .otc02 = 0,
        .otc03 = 0,
        .otc04 = 0,
        .bi01us = base1ME,
        .bi02us = base2ME,
        .bi03us = 0,
        .bi04us = 0,
        .isc01us = 0,
        .isc02us = 0,
        .isc03us = 0,
        .igv01us = iva1ME,
        .igv02us = 0,
        .igv03us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .otc03us = 0,
        .otc04us = 0,
        .percepcion = 0,
        .percepcionus = 0,
        .importeTotal = total,
        .importeUS = totalME,
        .destino = TIPOCOMPRA,
        .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
        .glosa = glosa,
        .tipoCompra = TIPOCOMPRA,
        .sustentado = "S",
        .idPadre = 0,
        .aprobado = "S",
        .apruebaPago = "S",
        .tieneDetraccion = "N",
        .situacion = statusComprobantes.Normal,
        .estadoEntrega = "1",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        be.documentocompra = obj
        Select Case UCCondicionesPago.RBNo.Checked
            Case True
                be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            Case Else
                If UCCondicionesPago.UCPagoCompletoDocumento.TextPagado.DecimalValue > 0 Then
                    be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PagoParcial
                End If

                If UCCondicionesPago.UCPagoCompletoDocumento.TextSaldo.DecimalValue <= 0 Then
                    be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                End If
        End Select
        be.documentocompra.documentocompradetalle = New List(Of documentocompradetalle)
    End Sub

    Private Function MappingDocumento() As documento
        Dim fechaCompra As New DateTime(UCEstructuraDocumentocabecera.TextAnio.DecimalValue,
                                  CInt(UCEstructuraDocumentocabecera.cboMesCompra.SelectedValue),
                                  CInt(UCEstructuraDocumentocabecera.TxtDia.DecimalValue),
                                  UCEstructuraDocumentocabecera.txtHora.Value.TimeOfDay.Hours,
                                  UCEstructuraDocumentocabecera.txtHora.Value.TimeOfDay.Minutes,
                                  UCEstructuraDocumentocabecera.txtHora.Value.TimeOfDay.Seconds)



        Dim NUMERO_DOC As String = String.Empty
        Dim OPERACION_DOC As String = String.Empty

        Select Case ComboComprobante.Text
            Case "Compra recepción directa"
                NUMERO_DOC = $"{UCEstructuraDocumentocabecera.txtSerie.Text}-{UCEstructuraDocumentocabecera.txtNumero.Text}"
                OPERACION_DOC = StatusTipoOperacion.COMPRA

            Case "NOTA DE COMPRA"
                NUMERO_DOC = "0"
                OPERACION_DOC = StatusTipoOperacion.COMPRA

            Case "Otra entrada"
                NUMERO_DOC = "0"
                OPERACION_DOC = StatusTipoOperacion.OTRAS_ENTRADAS_A_ALMACEN
        End Select


        MappingDocumento = New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = UCEstructuraDocumentocabecera.cboTipoDoc.SelectedValue,
        .fechaProceso = fechaCompra,
        .moneda = If(UCEstructuraDocumentocabecera.cboMoneda.Text = "NUEVO SOL", "1", "2"),
        .idEntidad = UCEstructuraDocumentocabecera.TextProveedor.Tag,
        .entidad = UCEstructuraDocumentocabecera.TextProveedor.Text,
        .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR,
        .nrodocEntidad = UCEstructuraDocumentocabecera.TextNumIdentrazon.Text,
        .nroDoc = NUMERO_DOC,
        .idOrden = 0,
        .tipoOperacion = OPERACION_DOC,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now,
        .IdPerfil = usuario.IDRol
        }
    End Function

    Private Sub ComboComprobante_Click(sender As Object, e As EventArgs) Handles ComboComprobante.Click

    End Sub

    Private Sub ComboComprobante_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboComprobante.SelectedValueChanged
        Select Case ComboComprobante.Text
            Case "Compra recepción directa"
                If UCEstructuraDocumentocabecera IsNot Nothing Then
                    MappingComboDespacho("Compra recepción directa")
                    UCEstructuraDocumentocabecera.RadioButton1.Checked = True
                    UCEstructuraDocumentocabecera.txtSerie.Visible = True
                    UCEstructuraDocumentocabecera.txtNumero.Visible = True
                    UCEstructuraDocumentocabecera.Label8.Visible = True
                    UCEstructuraDocumentocabecera.Label9.Visible = True

                    UCEstructuraDocumentocabecera.LabelMotivo.Visible = False
                    UCEstructuraDocumentocabecera.TextMotivoOperacion.Visible = False

                    Dim documentos As New List(Of String)
                    documentos.Add("01")
                    documentos.Add("03")

                    UCEstructuraDocumentocabecera.cboTipoDoc.DataSource = UCEstructuraDocumentocabecera.ListaDocumentos.Where(Function(o) documentos.Contains(o.codigoDetalle)).ToList
                    UCEstructuraDocumentocabecera.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraDocumentocabecera.cboTipoDoc.ValueMember = "codigoDetalle"

                    'BUTTON CONDICIONES DE PAGO
                    BunifuFlatButton2.Visible = False

                    'BUTTON DISTRIBUCION DE PRODUCTOS
                    BunifuFlatButton1.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                End If

                If UCEstructuraDocumentocabecera IsNot Nothing Then
                    UCEstructuraDocumentocabecera.Visible = True
                    UCEstructuraDocumentocabecera.BringToFront()
                    UCEstructuraDocumentocabecera.Show()
                End If


            Case "NOTA DE COMPRA", "Otra entrada"
                If UCEstructuraDocumentocabecera IsNot Nothing Then
                    UCEstructuraDocumentocabecera.RadioButton2.Checked = True

                    UCEstructuraDocumentocabecera.txtSerie.Visible = False
                    UCEstructuraDocumentocabecera.txtNumero.Visible = False
                    UCEstructuraDocumentocabecera.Label8.Visible = False
                    UCEstructuraDocumentocabecera.Label9.Visible = False

                    UCEstructuraDocumentocabecera.LabelMotivo.Visible = True
                    UCEstructuraDocumentocabecera.TextMotivoOperacion.Visible = True

                    UCEstructuraDocumentocabecera.cboTipoDoc.DataSource = UCEstructuraDocumentocabecera.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9907").ToList
                    UCEstructuraDocumentocabecera.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraDocumentocabecera.cboTipoDoc.ValueMember = "codigoDetalle"
                    'BUTTON CONDICIONES DE PAGO
                    BunifuFlatButton2.Visible = False

                    'BUTTON DISTRIBUCION DE PRODUCTOS
                    BunifuFlatButton1.Visible = False
                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                End If

                If UCEstructuraDocumentocabecera IsNot Nothing Then
                    UCEstructuraDocumentocabecera.Visible = True
                    UCEstructuraDocumentocabecera.BringToFront()
                    UCEstructuraDocumentocabecera.Show()
                End If

            Case "PROFORMA"
            Case "COMPRA SERVICIOS PUBLICOS"

                If UCEstructuraDocumentocabecera IsNot Nothing Then
                    MappingComboDespacho("Compra servicios publicos")
                    UCEstructuraDocumentocabecera.RadioButton1.Checked = True
                    UCEstructuraDocumentocabecera.txtSerie.Visible = True
                    UCEstructuraDocumentocabecera.txtNumero.Visible = True
                    UCEstructuraDocumentocabecera.Label8.Visible = True
                    UCEstructuraDocumentocabecera.Label9.Visible = True

                    UCEstructuraDocumentocabecera.LabelMotivo.Visible = False
                    UCEstructuraDocumentocabecera.TextMotivoOperacion.Visible = False

                    Dim documentos As New List(Of String)
                    documentos.Add("14")


                    UCEstructuraDocumentocabecera.cboTipoDoc.DataSource = UCEstructuraDocumentocabecera.ListaDocumentos.Where(Function(o) documentos.Contains(o.codigoDetalle)).ToList
                    UCEstructuraDocumentocabecera.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraDocumentocabecera.cboTipoDoc.ValueMember = "codigoDetalle"

                    'BUTTON CONDICIONES DE PAGO
                    BunifuFlatButton2.Visible = False

                    'BUTTON DISTRIBUCION DE PRODUCTOS
                    BunifuFlatButton1.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                End If

                If UCEstructuraDocumentocabecera IsNot Nothing Then
                    UCEstructuraDocumentocabecera.Visible = True
                    UCEstructuraDocumentocabecera.BringToFront()
                    UCEstructuraDocumentocabecera.Show()
                End If

            Case "COMPRA RECIBO HONORARIOS"
                If UCEstructuraDocumentocabecera IsNot Nothing Then
                    MappingComboDespacho("Compra honorarios")
                    UCEstructuraDocumentocabecera.RadioButton1.Checked = True
                    UCEstructuraDocumentocabecera.txtSerie.Visible = True
                    UCEstructuraDocumentocabecera.txtNumero.Visible = True
                    UCEstructuraDocumentocabecera.Label8.Visible = True
                    UCEstructuraDocumentocabecera.Label9.Visible = True

                    UCEstructuraDocumentocabecera.LabelMotivo.Visible = False
                    UCEstructuraDocumentocabecera.TextMotivoOperacion.Visible = False

                    Dim documentos As New List(Of String)
                    documentos.Add("02")


                    UCEstructuraDocumentocabecera.cboTipoDoc.DataSource = UCEstructuraDocumentocabecera.ListaDocumentos.Where(Function(o) documentos.Contains(o.codigoDetalle)).ToList
                    UCEstructuraDocumentocabecera.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraDocumentocabecera.cboTipoDoc.ValueMember = "codigoDetalle"

                    'BUTTON CONDICIONES DE PAGO
                    BunifuFlatButton2.Visible = False

                    'BUTTON DISTRIBUCION DE PRODUCTOS
                    BunifuFlatButton1.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                End If

                If UCEstructuraDocumentocabecera IsNot Nothing Then
                    UCEstructuraDocumentocabecera.Visible = True
                    UCEstructuraDocumentocabecera.BringToFront()
                    UCEstructuraDocumentocabecera.Show()
                End If

        End Select
    End Sub

    Private Sub MappingComboDespacho(valor As String)
        Select Case valor
            Case "Compra recepción directa"
                UCEstructuraDocumentocabecera.ComboDespacho.Items.Clear()
                UCEstructuraDocumentocabecera.ComboDespacho.Items.Add("")
                UCEstructuraDocumentocabecera.ComboDespacho.Items.Add("UN ALMACEN")
                UCEstructuraDocumentocabecera.ComboDespacho.Items.Add("EN TRANSITO")
             '   UCEstructuraDocumentocabecera.ComboDespacho.Items.Add("MULTI-ALMACENES")
            Case ""

            Case ""

        End Select
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub FormCrearCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        Close()
    End Sub
#End Region

#Region "Events"

#End Region
End Class