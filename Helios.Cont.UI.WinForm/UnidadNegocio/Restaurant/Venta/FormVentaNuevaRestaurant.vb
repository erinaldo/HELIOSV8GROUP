Imports Syncfusion.Grouping
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity

Public Class FormVentaNuevaRestaurant

#Region "Attributes"
    Private FormImpresionNuevo As FormImpresionEquivalencia ' FormImpresionNuevo
    '  Public UCEstructuraCabeceraVentaV2 As UCEstructuraCabeceraVentaV2
    Public UCEstructuraCabeceraVentaV2 As UCEstructuraVentaRestaurant
    Public UCCondicionesPago As UCPagoVentarestaurant
    Public Property cajaUsuaroSA As New cajaUsuarioSA
    Public Property venta As documentoventaAbarrotes

    Public Property ManipulacionEstado As String

#End Region

#Region "Constructors"

    Public Sub New(CodigoProforma As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetComboPrincipal()
        Me.KeyPreview = True
        UCEstructuraCabeceraVentaV2 = New UCEstructuraVentaRestaurant(Me)
        UCCondicionesPago = New UCPagoVentarestaurant(Me)

        ' Add any initialization after the InitializeComponent() call.
        'UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        'PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        PanelBody.Controls.Add(UCCondicionesPago)
        GetDocumentosDefault()
        ToolStrip1.Select()
        ToolStrip1.Focus()
        ImportarProforma(CodigoProforma)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'UCEstructuraCabeceraVentaV2 = New UCEstructuraCabeceraVentaV2(Me)
        GetComboPrincipal()
        Me.KeyPreview = True
        UCEstructuraCabeceraVentaV2 = New UCEstructuraVentaRestaurant(Me)
        UCCondicionesPago = New UCPagoVentarestaurant(Me)

        ' Add any initialization after the InitializeComponent() call.
        'UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        'PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        PanelBody.Controls.Add(UCCondicionesPago)
        GetDocumentosDefault()
        UCEstructuraCabeceraVentaV2.RBFullName.Visible = True
        ToolStrip1.Select()
        ToolStrip1.Focus()
    End Sub

    Public Sub New(be As documento)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetComboPrincipal()
        UCEstructuraCabeceraVentaV2 = New UCEstructuraVentaRestaurant(Me)
        UCCondicionesPago = New UCPagoVentarestaurant(Me)
        Me.KeyPreview = True
        ' Add any initialization after the InitializeComponent() call.
        'UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        'PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        PanelBody.Controls.Add(UCCondicionesPago)
        GetDocumentosDefault()
        UbicarDocumentoVenta(be.documentoventaAbarrotes)
        ToolStrip1.Select()
        ToolStrip1.Focus()

    End Sub

    Public Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        'UCEstructuraCabeceraVentaV2 = New UCEstructuraCabeceraVentaV2(Me)
        UCEstructuraCabeceraVentaV2 = New UCEstructuraVentaRestaurant(Me)
        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
        'UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        'PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)



        GetDocumentosDefault()
        BunifuFlatButton2.Visible = False
        UbicarDocumentoVenta(IdDocumento)
        ComboComprobante.Enabled = False



        UCEstructuraCabeceraVentaV2.TextFiltrar.Enabled = False
        UCEstructuraCabeceraVentaV2.RBFullName.Visible = False
        btGrabar.Text = "Editar - F2"
    End Sub

#End Region

#Region "Methods"

    Private Sub GetComboPrincipal()
        ComboComprobante.Items.Clear()

        ComboComprobante.Items.Add("PEDIDO")
        If Gempresas.ubigeo IsNot Nothing Then
            ComboComprobante.Items.Add("VENTA")
        End If
        ComboComprobante.Items.Add("NOTA DE VENTA")
        'ComboComprobante.Items.Add("PROFORMA")
        ComboComprobante.Items.Add("PRE VENTA")
        'ComboComprobante.Items.Add("OTRA SALIDA DE ALMACEN")
    End Sub


    Public Sub EnviarFacturaElectronica(doc As documento, idPSE As Integer)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
        Try
            Dim comprobante = doc.documentoventaAbarrotes ' documentoSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
            'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(doc.idDocumento)
            Dim receptor = comprobante.CustomEntidad ' entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
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
            Factura.TipoDocumento = tipoDoc
            Factura.TipoOperacion = "0101"
            Factura.TotalIcbper = comprobante.icbper.GetValueOrDefault

            If comprobante.importeCostoMN.GetValueOrDefault > 0 Then
                Factura.DescuentoGlobal = comprobante.importeCostoMN
            Else
                Factura.DescuentoGlobal = 0
            End If

            If comprobante.moneda = "1" Then
                Factura.Moneda = "PEN"
                Factura.TotalIgv = comprobante.igv01
                Factura.TotalVenta = comprobante.ImporteNacional ' + Factura.DescuentoGlobal.GetValueOrDefault
                Factura.Gravadas = comprobante.bi01
                Factura.Exoneradas = comprobante.bi02
            ElseIf comprobante.moneda = "2" Then
                Factura.Moneda = "USD"
                Factura.TotalIgv = comprobante.igv01us
                Factura.TotalVenta = comprobante.ImporteExtranjero ' + Factura.DescuentoGlobal.GetValueOrDefault
                Factura.Gravadas = comprobante.bi01us
                Factura.Exoneradas = comprobante.bi02us
            End If

            'Cargando el Detalle de la Factura
            Dim precioSinIva As Decimal = 0
            Dim precioConIva As Decimal = 0
            Dim cantEquiva As Decimal = 0
            For Each i In comprobante.documentoventaAbarrotesDet
                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                Select Case i.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        cantEquiva = 1
                        DetalleFactura.CodigoItem = 1
                    Case Else
                        cantEquiva = i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                        DetalleFactura.CodigoItem = i.idItem
                End Select

                precioSinIva = i.montokardex / cantEquiva
                precioConIva = i.importeMN / cantEquiva

                conteo += 1

                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = cantEquiva ' i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault 'i.monto1


                DetalleFactura.Descripcion = i.nombreItem
                DetalleFactura.UnidadMedida = i.unidad1

                If comprobante.moneda = "1" Then
                    DetalleFactura.PrecioReferencial = precioConIva 'i.precioUnitario
                    DetalleFactura.Impuesto = i.montoIgv
                    DetalleFactura.TotalVenta = i.montokardex
                    If i.destino = "1" Then
                        DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                        DetalleFactura.PrecioUnitario = precioSinIva ' CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    ElseIf i.destino = "2" Then
                        DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                        DetalleFactura.PrecioUnitario = precioConIva ' i.precioUnitario
                    End If
                ElseIf comprobante.moneda = "2" Then
                    'DetalleFactura.PrecioReferencial = i.precioUnitarioUS
                    'DetalleFactura.Impuesto = i.montoIgvUS
                    'DetalleFactura.TotalVenta = i.montokardexUS
                    'If i.destino = "1" Then
                    '    DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                    '    DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                    '    DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitarioUS, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    'ElseIf i.destino = "2" Then
                    '    DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                    '    DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                    '    DetalleFactura.PrecioUnitario = i.precioUnitarioUS
                    'End If
                End If
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                If i.tasaIcbper.GetValueOrDefault > 0 Then
                    DetalleFactura.TotalIcbper = i.montoIcbper.GetValueOrDefault
                    DetalleFactura.ImpuestoIcbper = i.tasaIcbper.GetValueOrDefault
                    DetalleFactura.CantidadBolsa = cantEquiva
                Else
                    DetalleFactura.TotalIcbper = 0
                    DetalleFactura.ImpuestoIcbper = 0
                    DetalleFactura.CantidadBolsa = 0
                End If
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next
            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSaveValidado(Factura, Nothing)

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
        Catch ex As Exception
        End Try



    End Sub

    Public Sub UbicarDocumentoImportado(doc As documento)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim venta = doc.documentoventaAbarrotes ' ventaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = idDocumento})
        Dim ent = venta.CustomEntidad ' entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault
        Try
            If venta IsNot Nothing Then
                MapearDocumentoImportado(venta, ent)
                VerDetalleVentaImportado(venta)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

#Region "Proforma"
    Private Sub ImportarProforma(Codigoproforma As String)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim venta = ventaSA.GetProformaCode(New documento With {.idEmpresa = Gempresas.IdEmpresaRuc, .nroDoc = Codigoproforma})
        Try
            If venta IsNot Nothing Then
                Dim ent = venta.CustomEntidad
                MapearDocumentoProforma(venta, ent)
                ImportarDetalleProforma(venta)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub ImportarDetalleProforma(venta As documentoventaAbarrotes)
        Dim articuloSA As New detalleitemsSA

        UCEstructuraCabeceraVentaV2.ListaproductosVendidos = venta.documentoventaAbarrotesDet.ToList
        '     UCEstructuraCabeceraVentaV2.LoadCanastaVentas(UCEstructuraCabeceraVentaV2.ListaproductosVendidos)


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

        For Each i In UCEstructuraCabeceraVentaV2.ListaproductosVendidos

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

                    i.CodigoCosto = i.secuencia
                    Dim art = articuloSA.GetUbicaProductoID(i.idItem)
                    i.CustomProducto = art
                    i.CustomCatalogo = i.CustomCatalogo
                    i.PrecioUnitarioVentaMN = Decimal.Parse(i.monto2)
                    i.FlagBonif = i.bonificacion.ToString
                    dt.Rows.Add(i.CodigoCosto,
                          i.CustomProducto.origenProducto,
                          i.CustomProducto.descripcionItem,
                          i.CustomProducto.unidad1,
                          i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault,
                          i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                          i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                          i.importeMN.GetValueOrDefault, 0,
                          i.CustomEquivalencia.equivalencia_id, i.bonificacion, i.CustomCatalogo.idCatalogo, i.descuentoMN.GetValueOrDefault, True)

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
        '    Dim art = articuloSA.GetUbicaProductoID(i.idItem)

        '    dt.Rows.Add(i.CodigoCosto,
        '            i.destino,
        '            i.nombreItem,
        '            i.unidad1,
        '            i.unidad2,
        '            i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
        '            i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
        '            i.importeMN.GetValueOrDefault, 0,
        '            "-", i.bonificacion)
        'Next

        'For Each i In UCEstructuraCabeceraVentaV2.ListaproductosVendidos
        '    i.PrecioUnitarioVentaMN = Decimal.Parse(i.monto2)
        '    i.CodigoCosto = i.secuencia
        '    'Dim art = articuloSA.GetUbicaProductoID(i.idItem)
        '    'i.CustomProducto = art

        '    ''Dim ListaEquivalencias = art.detalleitem_equivalencias.ToList
        '    ''Dim objEquivalencia = ListaEquivalencias.Where(Function(o) o.equivalencia_id = i.equivalencia_id).SingleOrDefault
        '    i.CustomEquivalencia = i.CustomEquivalencia ' objEquivalencia

        '    dt.Rows.Add(i.secuencia,
        '            i.CustomProducto.origenProducto,
        '            i.CustomProducto.descripcionItem,
        '            i.CustomProducto.unidad1,
        '            i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault,
        '            i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
        '            i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
        '            i.importeMN.GetValueOrDefault, 0,
        '            i.CustomEquivalencia.unidadComercial, i.bonificacion)
        ' Next

        UCEstructuraCabeceraVentaV2.GridCompra.DataSource = dt
        UCEstructuraCabeceraVentaV2.GridCompra.Refresh()
        UCEstructuraCabeceraVentaV2.GetTotalesDocumento()
    End Sub

    Private Sub MapearDocumentoProforma(venta As documentoventaAbarrotes, ent As entidad)
        With UCEstructuraCabeceraVentaV2 'UCEstructuraCabeceraVentaV2
            '.TxtDia.DecimalValue = venta.fechaDoc.Value.Day
            '.cboMesCompra.SelectedValue = String.Format("{0:00}", venta.fechaDoc.Value.Month)
            '.TextAnio.DecimalValue = venta.fechaDoc.Value.Year
            ' .txtHora.Value = venta.fechaDoc.Value
            .cboMoneda.SelectedValue = venta.moneda
            .txtTipoCambio.DecimalValue = venta.tipoCambio.GetValueOrDefault
            .txtIva.DoubleValue = venta.tasaIgv
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

#End Region

    Private Sub MapearDocumentoImportado(venta As documentoventaAbarrotes, ent As entidad)
        With UCEstructuraCabeceraVentaV2 'UCEstructuraCabeceraVentaV2
            '.TxtDia.DecimalValue = venta.fechaDoc.Value.Day
            '.cboMesCompra.SelectedValue = String.Format("{0:00}", venta.fechaDoc.Value.Month)
            '.TextAnio.DecimalValue = venta.fechaDoc.Value.Year
            ' .txtHora.Value = venta.fechaDoc.Value
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

    Private Sub UbicarDocumentoVenta(venta As documentoventaAbarrotes)
        Dim entidadSA As New entidadSA
        '  Dim ventaSA As New documentoVentaAbarrotesSA
        '   Dim venta = ventaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = be.idDocumento})
        Dim ent = venta.CustomEntidad ' entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault
        If venta IsNot Nothing Then
            VerCabeceraDocumento(venta, ent)
            VerDetalleVenta(venta)
        End If
    End Sub

    Private Sub VerDetalleVenta(venta As documentoventaAbarrotes)
        UCEstructuraCabeceraVentaV2.ListaproductosVendidos = venta.documentoventaAbarrotesDet.ToList
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

        For Each i In UCEstructuraCabeceraVentaV2.ListaproductosVendidos

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
        UCEstructuraCabeceraVentaV2.GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0
        UCEstructuraCabeceraVentaV2.GridCompra.DataSource = dt
        UCEstructuraCabeceraVentaV2.GridCompra.Refresh()
        UCEstructuraCabeceraVentaV2.GetTotalesDocumento()
    End Sub

    Private Sub VerDetalleVentaImportado(venta As documentoventaAbarrotes)
        Dim articuloSA As New detalleitemsSA

        UCEstructuraCabeceraVentaV2.ListaproductosVendidos = venta.documentoventaAbarrotesDet.ToList
        '     UCEstructuraCabeceraVentaV2.LoadCanastaVentas(UCEstructuraCabeceraVentaV2.ListaproductosVendidos)


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

        For Each i In UCEstructuraCabeceraVentaV2.ListaproductosVendidos

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

                    i.CodigoCosto = i.secuencia
                    Dim art = articuloSA.GetUbicaProductoID(i.idItem)
                    i.CustomProducto = art
                    i.CustomCatalogo = i.CustomCatalogo
                    i.PrecioUnitarioVentaMN = Decimal.Parse(i.monto2)
                    i.FlagBonif = i.bonificacion.ToString
                    dt.Rows.Add(i.CodigoCosto,
                          i.CustomProducto.origenProducto,
                          i.CustomProducto.descripcionItem,
                          i.CustomProducto.unidad1,
                          i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault,
                          i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                          i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                          i.importeMN.GetValueOrDefault, 0,
                          i.CustomEquivalencia.equivalencia_id, i.bonificacion, i.CustomCatalogo.idCatalogo, i.descuentoMN.GetValueOrDefault, True)

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
        '    Dim art = articuloSA.GetUbicaProductoID(i.idItem)

        '    dt.Rows.Add(i.CodigoCosto,
        '            i.destino,
        '            i.nombreItem,
        '            i.unidad1,
        '            i.unidad2,
        '            i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
        '            i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
        '            i.importeMN.GetValueOrDefault, 0,
        '            "-", i.bonificacion)
        'Next

        'For Each i In UCEstructuraCabeceraVentaV2.ListaproductosVendidos
        '    i.PrecioUnitarioVentaMN = Decimal.Parse(i.monto2)
        '    i.CodigoCosto = i.secuencia
        '    'Dim art = articuloSA.GetUbicaProductoID(i.idItem)
        '    'i.CustomProducto = art

        '    ''Dim ListaEquivalencias = art.detalleitem_equivalencias.ToList
        '    ''Dim objEquivalencia = ListaEquivalencias.Where(Function(o) o.equivalencia_id = i.equivalencia_id).SingleOrDefault
        '    i.CustomEquivalencia = i.CustomEquivalencia ' objEquivalencia

        '    dt.Rows.Add(i.secuencia,
        '            i.CustomProducto.origenProducto,
        '            i.CustomProducto.descripcionItem,
        '            i.CustomProducto.unidad1,
        '            i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault,
        '            i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
        '            i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
        '            i.importeMN.GetValueOrDefault, 0,
        '            i.CustomEquivalencia.unidadComercial, i.bonificacion)
        ' Next

        UCEstructuraCabeceraVentaV2.GridCompra.DataSource = dt
        UCEstructuraCabeceraVentaV2.GridCompra.Refresh()
        UCEstructuraCabeceraVentaV2.GetTotalesDocumento()
    End Sub

    Private Sub VerCabeceraDocumento(venta As documentoventaAbarrotes, ent As entidad)
        Dim tipoVenta As String = Nothing
        Select Case venta.tipoVenta
            Case TIPO_VENTA.VENTA_ELECTRONICA
                ComboComprobante.Text = "VENTA"
            Case TIPO_VENTA.VENTA_PEDIDO
                ComboComprobante.Text = "PEDIDO"
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

        With UCEstructuraCabeceraVentaV2
            .TextDescuento.Enabled = False
            .TextSubTotal.DecimalValue = venta.ImporteNacional.GetValueOrDefault + venta.importeCostoMN.GetValueOrDefault
            .TextDescuento.DecimalValue = venta.importeCostoMN.GetValueOrDefault
            .TxtDia.DecimalValue = venta.fechaDoc.Value.Day
            .cboMesCompra.SelectedValue = String.Format("{0:00}", venta.fechaDoc.Value.Month)
            .TextAnio.DecimalValue = venta.fechaDoc.Value.Year
            .txtHora.Value = venta.fechaDoc.Value
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

    Private Sub GetDocumentosDefault()
        Dim documentos As New List(Of String)
        documentos.Add("01")
        documentos.Add("03")

        UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) documentos.Contains(o.codigoDetalle)).ToList
        UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
        UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.F2
                btGrabar.PerformClick()

            Case Keys.F4
                'ToolStripButton1.PerformClick()
                UCEstructuraCabeceraVentaV2.TextFiltrar.Select()
                UCEstructuraCabeceraVentaV2.TextFiltrar.Focus()
                UCEstructuraCabeceraVentaV2.TextFiltrar.SelectAll()

            Case Keys.F5
                ToolStripButton1.PerformClick()

            Case Keys.F3
                UCEstructuraCabeceraVentaV2.Button1.PerformClick()

            Case Keys.F8
                'If (ValidarKey = True) Then
                'btGrabar.PerformClick()
                ToolStripButton3.PerformClick()

            Case Keys.F9
                ToolStripButton4.PerformClick()

            Case Keys.Escape
                Close()

                'If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                '    UCEstructuraCabeceraVentaV2.ucB_OKEvent()
                'End If
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


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
                nDocumentoCaja.moneda = venta.moneda

                nDocumentoCaja.idEntidad = venta.idCliente
                nDocumentoCaja.entidad = UCEstructuraCabeceraVentaV2.TextProveedor.Text
                nDocumentoCaja.nrodocEntidad = UCEstructuraCabeceraVentaV2.TextNumIdentrazon.Text

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

                objCaja.moneda = venta.moneda
                objCaja.tipoCambio = TmpTipoCambio
                objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

                objCaja.estado = "1"
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
                                   .destino = i.CodigoCosto,
                                   .otroMN = 0,
                                   .idItem = i.idItem,
                                   .DetalleItem = i.nombreItem,
                                   .montoSoles = (i.MontoPago + i.montoIcbper.GetValueOrDefault),
                                   .montoUsd = FormatNumber((i.MontoPago + i.montoIcbper.GetValueOrDefault) / TmpTipoCambio, 2),
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
                    i.estadoPago = i.estadoPago
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
    End Function

    Private Sub MappingDocumentoCompraCabeceraDetalle(obj As documento)
        Dim objDet As documentoventaAbarrotesDet
        Dim precUnitEquivalencia As Decimal = 0
        For Each i In UCEstructuraCabeceraVentaV2.ListaproductosVendidos

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
                            .idDistribucion = UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag,
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
                            .idDistribucion = UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }
                    If i.CustomProducto.tipoExistencia = TipoExistencia.Kit Then
                        AgregarArticulosConexos(i.CustomProducto.detalleitems_conexo.ToList, obj, i.monto1)

                    End If

            End Select



            If btGrabar.Text = "Editar - F2" Then
                objDet.idDocumento = venta.idDocumento
                objDet.secuencia = i.secuencia
            End If

            obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet)
        Next
    End Sub

    Private Sub AgregarArticulosConexos(ListaArticulosKit As List(Of detalleitems_conexo), obj As documento, cantidadVentaKit As Decimal)
        Dim objDet As documentoventaAbarrotesDet
        Dim productoSA As New detalleitemsSA
        Dim equivalenciaSA As New detalleitem_equivalenciasSA

        '   AgregarArticulosConexos = New List(Of documentoventaAbarrotesDet)
        Dim index = 1
        While index <= cantidadVentaKit

            For Each i In ListaArticulosKit
                Dim prod = productoSA.InvocarProductoID(i.idProducto)
                'equivalenciaSA.EquivalenciaSelID(New detalleitem_equivalencias With {.equivalencia_id = i.equivalencia_id}) '
                Dim equivalencias = prod.detalleitem_equivalencias.ToList
                Dim eq = equivalencias.Where(Function(o) o.equivalencia_id = i.equivalencia_id).SingleOrDefault


                objDet = New documentoventaAbarrotesDet With
                                {
                                .AfectoInventario = prod.AfectoStock,
                                .CodigoCosto = 0,'i.CodigoCosto,
                                .CustomEquivalencia = eq,
                                .CustomProducto = prod,
                                .idItem = prod.codigodetalle,
                                .nombreItem = prod.descripcionItem,
                                .tipoExistencia = prod.tipoExistencia,
                                .destino = prod.origenProducto,
                                .unidad1 = prod.unidad1,
                                .monto1 = i.cantidad,
                                .equivalencia_id = eq.equivalencia_id,
                                .unidad2 = Nothing,
                                .monto2 = 0,
                                .precioUnitario = i.cantidad * eq.fraccionUnidad,'   i.precioUnitario.GetValueOrDefault,
                                .precioUnitarioUS = 0,
                                .importeMN = 0,
                                .importeME = 0,
                                .montokardex = 0,
                                .montoIsc = 0,
                                .montoIgv = 0,
                                .otrosTributos = 0,
                                .montokardexUS = 0,
                                .montoIscUS = 0,
                                .montoIgvUS = 0,
                                .otrosTributosUS = 0,
                                .entregado = "1",
                                .estadoPago = "PG",
                                .bonificacion = False,
                                .descuentoMN = 0,
                                .tipoVenta = "KIT",
                                .usuarioModificacion = usuario.IDUsuario,' usuario.IDUsuario,
                                .fechaModificacion = Date.Now
                                }
                obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet)
                '  AgregarArticulosConexos.Add(objDet)

            Next
            index = index + 1
        End While


    End Sub

    Private Function ValidarForm() As Boolean
        Dim listaErrores As Integer = 0
        'If chPedido.Checked = True Then
        If UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CONTADO" Then

            Select Case UCEstructuraCabeceraVentaV2.RBFullName.Checked = True
                Case True
                    If UCEstructuraCabeceraVentaV2.TextProveedor.Tag Is Nothing Then
                        ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, "Ingrese un cliente")
                        listaErrores += 1
                        UCCondicionesPago.Visible = False
                        btGrabar.Text = "Cobrar - F2"
                        MessageBox.Show("Debe identificar el cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                            UCEstructuraCabeceraVentaV2.Visible = True
                            UCEstructuraCabeceraVentaV2.BringToFront()
                            UCEstructuraCabeceraVentaV2.Show()
                            UCCondicionesPago.Visible = False
                        End If
                    Else
                        ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, Nothing)
                    End If


                Case False
                    If UCEstructuraCabeceraVentaV2.TextProveedor.Text.Trim.Length = 0 Then
                        ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, "Ingrese un cliente")
                        listaErrores += 1
                        UCCondicionesPago.Visible = False
                        btGrabar.Text = "Cobrar - F2"
                        MessageBox.Show("Debe identificar el cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                            UCEstructuraCabeceraVentaV2.Visible = True
                            UCEstructuraCabeceraVentaV2.BringToFront()
                            UCEstructuraCabeceraVentaV2.Show()
                            UCCondicionesPago.Visible = False
                        End If
                    Else
                        ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, Nothing)
                    End If
            End Select




            If UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.Items.Count = 0 Then
                ErrorProvider1.SetError(BunifuFlatButton2, "no tiene configurada un caja")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(BunifuFlatButton2, Nothing)
            End If
        End If

        If UCEstructuraCabeceraVentaV2.TxtDia.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TxtDia, "Identificar la fecha de compra")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TxtDia, Nothing)
        End If

        If ComboComprobante.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(ComboComprobante, "Ingrese un comprobante")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(ComboComprobante, Nothing)
        End If

        If UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue <= 0 Then
            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.txtTipoCambio, "Ingrese un tipo de cambio mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.txtTipoCambio, Nothing)
        End If

        If UCEstructuraCabeceraVentaV2.txtIva.DoubleValue <= 0 Then
            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.txtIva, "Ingrese una tasa de igv. mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.txtIva, Nothing)
        End If


        Select Case UCEstructuraCabeceraVentaV2.RBFullName.Checked = True
            Case True
                If UCEstructuraCabeceraVentaV2.TextProveedor.Tag Is Nothing Then
                    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, Nothing)
                End If

            Case False
                If UCEstructuraCabeceraVentaV2.TextProveedor.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, Nothing)
                End If

                If UCEstructuraCabeceraVentaV2.TextProveedor.Tag Is Nothing Then
                    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.TextProveedor, Nothing)
                End If
        End Select

        Select Case ComboComprobante.Text
            Case "OTRA SALIDA DE ALMACEN"

            Case Else
                If UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue <= 0 Then
                    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.txtTotalPagar, "La venta debe ser mayor a cero")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(UCEstructuraCabeceraVentaV2.txtTotalPagar, Nothing)
                End If
        End Select

        If listaErrores > 0 Then
            ValidarForm = False
        Else
            ValidarForm = True
        End If
    End Function

    Private Sub MappingDocumentoPedidoCabecera(be As documento)
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

        Select Case be.moneda
            Case "1"
                base1 = UCEstructuraCabeceraVentaV2.txtTotalBase.DecimalValue
                base2 = UCEstructuraCabeceraVentaV2.txtTotalBase2.DecimalValue
                base1ME = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
                base2ME = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase2.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
                iva1 = UCEstructuraCabeceraVentaV2.txtTotalIva.DecimalValue
                iva1ME = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalIva.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                total = UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue
                totalME = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
            Case "2"

                base1ME = UCEstructuraCabeceraVentaV2.txtTotalBase.DecimalValue
                base2ME = UCEstructuraCabeceraVentaV2.txtTotalBase2.DecimalValue

                base1 = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase.DecimalValue * UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
                base2 = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase2.DecimalValue * UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                iva1ME = UCEstructuraCabeceraVentaV2.txtTotalIva.DecimalValue
                iva1 = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalIva.DecimalValue * UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                totalME = UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue
                total = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue * UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
        End Select

        Select Case ComboComprobante.Text
            Case "PEDIDO"
                tipoVenta = TIPO_VENTA.VENTA_PEDIDO
        End Select

        Dim obj As New documentoPedido With
        {
        .codigoLibro = "8",
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
        .tasaIgv = UCEstructuraCabeceraVentaV2.txtIva.DoubleValue,
        .tipoCambio = UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue,
        .bi01 = base1,
        .bi02 = base2,
        .isc01 = 0,
        .isc02 = 0,
        .igv01 = iva1,
        .igv02 = 0,
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
        .importeCostoMN = If(UCEstructuraCabeceraVentaV2.TextDescuento.DecimalValue > 0, UCEstructuraCabeceraVentaV2.TextDescuento.DecimalValue, 0),
        .terminos = UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text,
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
            obj.idDocumento = venta.idDocumento
            obj.serieVenta = venta.serieVenta
            obj.serie = venta.serie
            obj.numeroVenta = venta.numeroVenta
            obj.numeroDoc = venta.numeroDoc
        End If
        be.documentoPedido = obj
        'Select Case UCCondicionesPago.RBNo.Checked
        '    Case True
        be.documentoPedido.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        '    Case Else
        '        If UCCondicionesPago.UCPagoCompletoDocumento.TextPagado.DecimalValue > 0 Then
        '            be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PagoParcial
        '        End If

        '        If UCCondicionesPago.UCPagoCompletoDocumento.TextSaldo.DecimalValue <= 0 Then
        '            be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        '        End If
        'End Select

        be.documentoPedido.documentoPedidoDet = New List(Of documentoPedidoDet)
    End Sub

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
                base1 = UCEstructuraCabeceraVentaV2.txtTotalBase.DecimalValue
                base2 = UCEstructuraCabeceraVentaV2.txtTotalBase2.DecimalValue
                base1ME = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
                base2ME = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase2.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
                iva1 = UCEstructuraCabeceraVentaV2.txtTotalIva.DecimalValue
                iva1ME = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalIva.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                total = UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue
                totalME = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                icbper = UCEstructuraCabeceraVentaV2.txtTotalIcbper.DecimalValue
                icbperME = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalIcbper.DecimalValue / UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

            Case "2"

                base1ME = UCEstructuraCabeceraVentaV2.txtTotalBase.DecimalValue
                base2ME = UCEstructuraCabeceraVentaV2.txtTotalBase2.DecimalValue

                base1 = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase.DecimalValue * UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
                base2 = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalBase2.DecimalValue * UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                iva1ME = UCEstructuraCabeceraVentaV2.txtTotalIva.DecimalValue
                iva1 = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalIva.DecimalValue * UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                totalME = UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue
                total = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue * UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)

                icbperME = UCEstructuraCabeceraVentaV2.txtTotalIcbper.DecimalValue
                icbper = Math.Round(UCEstructuraCabeceraVentaV2.txtTotalIcbper.DecimalValue * UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue, 2)
        End Select

        Select Case ComboComprobante.Text
            Case "PEDIDO"
                tipoVenta = TIPO_VENTA.VENTA_PEDIDO
            Case "VENTA"
                tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
            Case "PRE VENTA"
                tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO
            Case "NOTA DE VENTA"
                tipoVenta = TIPO_VENTA.NOTA_DE_VENTA
            Case "OTRA SALIDA DE ALMACEN"
                tipoVenta = TIPO_COMPRA.OTRAS_SALIDAS
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
        .tasaIgv = UCEstructuraCabeceraVentaV2.txtIva.DoubleValue,
        .tipoCambio = UCEstructuraCabeceraVentaV2.txtTipoCambio.DecimalValue,
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
        .importeCostoMN = If(UCEstructuraCabeceraVentaV2.TextDescuento.DecimalValue > 0, UCEstructuraCabeceraVentaV2.TextDescuento.DecimalValue, 0),
        .terminos = UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text,
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
            obj.idDocumento = venta.idDocumento
            obj.serieVenta = venta.serieVenta
            obj.serie = venta.serie
            obj.numeroVenta = venta.numeroVenta
            obj.numeroDoc = venta.numeroDoc
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

    Private Sub Grabarventa()
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim DstribucionBE As New distribucionInfraestructura
        Dim obj As New documento
        Try
            obj = MappingDocumento()

            Select Case ComboComprobante.Text
                Case "PEDIDO"
                    Dim Vendedor = GetCodigoVendedor()
                    If Vendedor Is Nothing Then
                        Throw New Exception("Debe indicar el codigo del vendedor!")
                    End If
                    obj.usuarioActualizacion = Vendedor.IDUsuario
                    'MappingDocumentoPedidoCabecera(obj)
                    'MappingDocumentoPedidoCabeceraDetalle(obj)

                    'If validarCanastaDeVentas(obj) Then
                    '    Dim doc = ventaSA.GrabarVentaEquivalenciaXPedido(obj)
                    'End If
                    'LimpiarControles()
                    'Dispose()
                    'Exit Sub
                Case "OTRA SALIDA DE ALMACEN", "PROFORMA", "PRE VENTA"
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
                        Select Case UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text
                            Case "CONTADO"
                                Dim codigo As Integer = Integer.Parse(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)
                                Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(codigo)
                                '   Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)
                                envio = GetConfiguracionUsuario(usuarioSel, cajaUsuario)
                            Case "CREDITO"

                            Case "CRONOGRAMA"
                                'If UCCondicionesPago.UCCronogramaPagos.ListaCronograma IsNot Nothing Then


                                If UCCondicionesPago.UCCronogramaPagos.ListaCronograma Is Nothing Then
                                    Throw New Exception("Debe registrar el cronograma de pagos")
                                End If

                                If UCCondicionesPago.UCCronogramaPagos.ListaCronograma.Count <= 0 Then
                                    Throw New Exception("Debe registrar el cronograma de pagos")
                                End If

                                obj.Cronograma = New List(Of Cronograma)
                                obj.Cronograma = UCCondicionesPago.UCCronogramaPagos.ListaCronograma
                                'Else
                                'Throw New Exception("Debe registrar el cronograma de pagos")
                                'End If

                                'Dim codigo As Integer = Integer.Parse(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)
                                'Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(codigo)
                                'envio = GetConfiguracionUsuario(usuarioSel, cajaUsuario)
                        End Select
                    Else
                        MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False
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

                            Select Case UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text
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
                Dim doc = ventaSA.GrabarVentaEquivalenciaXInfra(obj)

                Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
                Dim distribucionInfraestructuraBE As New distribucionInfraestructura

                distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                distribucionInfraestructuraBE.idDistribucion = UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag
                distribucionInfraestructuraBE.estado = "U"
                distribucionInfraestructuraSA.updateDistribucionxID(distribucionInfraestructuraBE)

                If UCEstructuraCabeceraVentaV2.cboTipoDoc.Text = "FACTURA" Or UCEstructuraCabeceraVentaV2.cboTipoDoc.Text = "BOLETA" Then
                    If My.Computer.Network.IsAvailable = True Then
                        If My.Computer.Network.Ping("138.128.171.106") Then
                            If Gempresas.ubigeo > 0 Then

                                Dim comprobante = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                                doc.documentoventaAbarrotes = comprobante
                                doc.ListaCustomDocumento = ListaPagos
                                EnviarFacturaElectronica(doc, Gempresas.ubigeo)

                                FormImpresionNuevo = New FormImpresionEquivalencia(doc)  ' frmVentaNuevoFormato
                                FormImpresionNuevo.tienda = UCEstructuraCabeceraVentaV2.txtInfraestructura.Text
                                FormImpresionNuevo.FormaPago = ""
                                FormImpresionNuevo.DocumentoID = doc.idDocumento
                                FormImpresionNuevo.Email = ""
                                FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                                FormImpresionNuevo.ShowDialog(Me)

                            End If
                        End If
                    Else
                        MessageBox.Show("Envío a Respositorio!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False
                        'Alert = New Alert("Envio a Respositorio", alertType.success)
                        'Alert.TopMost = True
                        'Alert.Show()
                    End If
                ElseIf UCEstructuraCabeceraVentaV2.cboTipoDoc.Text = "PROFORMA" Or UCEstructuraCabeceraVentaV2.cboTipoDoc.Text = "NOTA DE VENTA" Or UCEstructuraCabeceraVentaV2.cboTipoDoc.Text = "NOTA" Then
                    Dim comprobante = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                    doc.documentoventaAbarrotes = comprobante
                    doc.ListaCustomDocumento = ListaPagos
                    FormImpresionNuevo = New FormImpresionEquivalencia(doc)
                    FormImpresionNuevo.tienda = UCEstructuraCabeceraVentaV2.txtInfraestructura.Text
                    FormImpresionNuevo.FormaPago = ""
                    FormImpresionNuevo.DocumentoID = doc.idDocumento
                    FormImpresionNuevo.Email = ""
                    FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                    FormImpresionNuevo.ShowDialog(Me)
                ElseIf UCEstructuraCabeceraVentaV2.cboTipoDoc.Text = "PRE VENTA" Then
                    Dim statusForm As New frmMensajeCodigoVenta
                    statusForm.StartPosition = FormStartPosition.CenterScreen
                    statusForm.lblMensaje.Text = doc.CustomNumero '.Replace("0", "")
                    statusForm.ShowDialog()

                ElseIf UCEstructuraCabeceraVentaV2.cboTipoDoc.Text = "PEDIDO" Then
                    Dim comprobante = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                    doc.documentoventaAbarrotes = comprobante
                    doc.ListaCustomDocumento = ListaPagos
                    FormImpresionNuevo = New FormImpresionEquivalencia(doc)
                    FormImpresionNuevo.tienda = UCEstructuraCabeceraVentaV2.txtInfraestructura.Text
                    FormImpresionNuevo.FormaPago = "1"
                    FormImpresionNuevo.DocumentoID = doc.idDocumento
                    FormImpresionNuevo.Email = ""
                    FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen
                    FormImpresionNuevo.ShowDialog(Me)
                End If

                '   MessageBox.Show("Operación registrada!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LimpiarControles()

                DstribucionBE.Devolucion = obj.documentoventaAbarrotes.ImporteNacional
                DstribucionBE.tipo = ComboComprobante.Text
                DstribucionBE.TipoExistencia = UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text
                DstribucionBE.estado = "U"

                Me.Tag = DstribucionBE

                Dispose()
            Else
                MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Verificar el detalle de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btGrabar.Enabled = True
                UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
            UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False
        End Try
    End Sub

    Private Sub EditaDocumentoVenta()
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim obj As New documento
        Try
            ' obj.AfectaInventario = SwitchInventario.Value
            obj = MappingDocumento()
            MappingDocumentoCompraCabecera(obj)
            MappingDocumentoCompraCabeceraDetalle(obj)

            If validarCanastaDeVentas(obj) Then
                '  obj.AfectaInventario = SwitchInventario.Value
                ventaSA.EditarDocumentoVenta(obj)
                '   MessageBox.Show("Operación registrada!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Tag = "Grabado"
                Close()
            Else
                MessageBox.Show("Debe ingresar una ca6ntidad mayor a cero", "Verificar el detalle de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btGrabar.Enabled = True
                UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
            If UCCondicionesPago IsNot Nothing Then
                UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = False
            End If
        End Try
    End Sub

    Private Sub LimpiarControles()

        PanelBody.Controls.Clear()

        UCEstructuraCabeceraVentaV2 = New UCEstructuraVentaRestaurant(Me)
        UCCondicionesPago = New UCPagoVentarestaurant(Me)

        sliderTop.Left = BunifuFlatButton15.Left
        sliderTop.Width = BunifuFlatButton15.Width

        UCCondicionesPago.Visible = False
        btGrabar.Text = "Cobrar - F2"
        If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
            UCEstructuraCabeceraVentaV2.Visible = True
            UCEstructuraCabeceraVentaV2.BringToFront()
            UCEstructuraCabeceraVentaV2.Show()
        End If

        ' Add any initialization after the InitializeComponent() call.
        'UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        'PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        UCEstructuraCabeceraVentaV2.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCEstructuraCabeceraVentaV2)

        PanelBody.Controls.Add(UCCondicionesPago)
        GetDocumentosDefault()
#Region "Reiniciar ComboBoxVenta"
        Select Case ComboComprobante.Text
            Case "VENTA"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    Dim documentos As New List(Of String)
                    documentos.Add("01")
                    documentos.Add("03")

                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) documentos.Contains(o.codigoDetalle)).ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = True
                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Cobrar - F2"
                End If



                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If


            Case "PRE VENTA"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "1000").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Guardar - F2"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CREDITO"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Enabled = False
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

            Case "PEDIDO"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "1001").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Guardar - F2"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CREDITO"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Enabled = False
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

            Case "NOTA DE VENTA"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9907").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = True


                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Cobrar - F2"
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

            Case "OTRA SALIDA DE ALMACEN"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9907").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CREDITO"

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If

                    btGrabar.Text = "Guardar - F2"
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

            Case "PROFORMA"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9903").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Guardar - F2"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CREDITO"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Enabled = False
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

        End Select
#End Region

        UCEstructuraCabeceraVentaV2.TextFiltrar.Select()
        UCEstructuraCabeceraVentaV2.TextFiltrar.Focus()

    End Sub

    Private Function validarCanastaDeVentas(obj As documento) As Boolean
        validarCanastaDeVentas = True

        Select Case ComboComprobante.Text
            Case "OTRA SALIDA DE ALMACEN"
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

    Private Function MappingDocumento() As documento
        'Dim IDCliente As Integer = 0
        'Dim Cliente As String = String.Empty

        Dim fechaVenta As New DateTime(UCEstructuraCabeceraVentaV2.TextAnio.DecimalValue,
                                  CInt(UCEstructuraCabeceraVentaV2.cboMesCompra.SelectedValue),
                                  CInt(UCEstructuraCabeceraVentaV2.TxtDia.DecimalValue),
                                  UCEstructuraCabeceraVentaV2.txtHora.Value.TimeOfDay.Hours,
                                  UCEstructuraCabeceraVentaV2.txtHora.Value.TimeOfDay.Minutes,
                                  UCEstructuraCabeceraVentaV2.txtHora.Value.TimeOfDay.Seconds)


        'If UCEstructuraCabeceraVentaV2.RadioButton1.Checked = True Then ' razon social
        '    IDCliente = UCEstructuraCabeceraVentaV2.TextProveedor.Tag
        '    Cliente = UCEstructuraCabeceraVentaV2.TextProveedor.Text
        'Else ' cliente varios
        '    IDCliente = UCEstructuraCabeceraVentaV2.TextProveedor.Tag
        '    Cliente = UCEstructuraCabeceraVentaV2.TextProveedor.Text
        'End If

        MappingDocumento = New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = UCEstructuraCabeceraVentaV2.cboTipoDoc.SelectedValue,
        .fechaProceso = fechaVenta,
        .moneda = If(UCEstructuraCabeceraVentaV2.cboMoneda.Text = "NUEVO SOL", "1", "2"),
        .idEntidad = UCEstructuraCabeceraVentaV2.TextProveedor.Tag,
        .entidad = UCEstructuraCabeceraVentaV2.TextProveedor.Text,
        .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
        .nrodocEntidad = UCEstructuraCabeceraVentaV2.TextNumIdentrazon.Text,
        .nroDoc = "0",'$"{UCEstructuraCabeceraVentaV2.txtSerie.Text}-{UCEstructuraCabeceraVentaV2.txtNumero.Text}",
        .idOrden = 0,
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        If btGrabar.Text = "Editar - F2" Then
            MappingDocumento.idDocumento = venta.idDocumento
        End If

    End Function
#End Region

#Region "Events"
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
            Dim r As Record = UCEstructuraCabeceraVentaV2.GridCompra.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim codigo = r.GetValue("codigo")
                Dim item = UCEstructuraCabeceraVentaV2.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigo).SingleOrDefault
                If item IsNot Nothing Then
                    If item.tipobeneficio Is Nothing Then
                        ' LimpiarPagos(UCEstructuraCabeceraVentaV2.ListaproductosVendidos)
                        If item.CustomListaVentaDetalle IsNot Nothing Then
                            For Each i In item.CustomListaVentaDetalle
                                Dim prod = UCEstructuraCabeceraVentaV2.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = i.CodigoCosto).Single
                                UCEstructuraCabeceraVentaV2.ListaproductosVendidos.Remove(prod)
                            Next
                        End If
                        item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
                        UCEstructuraCabeceraVentaV2.ListaproductosVendidos.Remove(item)

                        UCEstructuraCabeceraVentaV2.LoadCanastaVentas(UCEstructuraCabeceraVentaV2.ListaproductosVendidos)
                        UCEstructuraCabeceraVentaV2.GetTotalesDocumento()
                    End If
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Cursor = Cursors.WaitCursor
        If BunifuFlatButton2.Visible = True Then
            Select Case btGrabar.Text
                Case "Cobrar - F2"
                    If ValidarForm() = True Then
                        IrPago()
                    End If
                Case "Guardar - F2"
                    UCCondicionesPago.UCPagoCompletoDocumento.PanelWaith.Visible = True
                    If ValidarForm() = True Then
                        Application.DoEvents()
                        Grabarventa()
                    End If
                Case "Editar - F2"
                    EditaDocumentoVenta()
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
                        EditaDocumentoVenta()
                End Select

            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'Dim f As New FormCanstaVentaEquivalencia(Me.UCEstructuraCabeceraVentaV2)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog(Me)
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Sub IrPago()
        btGrabar.Text = "Guardar - F2"

        '  If UCCondicionesPago.RBPagoAcumulado.Checked = True Then
        UCEstructuraCabeceraVentaV2.Visible = False
        If UCCondicionesPago IsNot Nothing Then
            UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotal.DecimalValue = UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue
            UCCondicionesPago.Dock = DockStyle.Fill
            UCCondicionesPago.Visible = True
            UCCondicionesPago.BringToFront()
            If UCCondicionesPago.RBPagoAcumulado.Checked = True Then
                If IsNumeric(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue) Then
                    UCCondicionesPago.UCPagoCompletoDocumento.GetLoadGridCajas(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)
                End If
                'UCCondicionesPago.UCPagoCompletoDocumento.LoadGrid()
                'UCCondicionesPago.UCPagoCompletoDocumento.SumaPagos()
            ElseIf UCCondicionesPago.RBCronograma.Checked = True Then
                UCCondicionesPago.UCCronogramaPagos.TextImporte.DecimalValue = UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue
            End If
            UCCondicionesPago.Show()
        End If
        'ElseIf UCCondicionesPago.RBCronograma.Checked = True Then

        'End If
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click
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
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If
            Case "DISTRIBUCION"

            Case "CONDICIONES DE PAGO"
                'UCTransporteDistribucionProductos.Visible = False
                btGrabar.Text = "Guardar - F2"
                UCEstructuraCabeceraVentaV2.Visible = False
                If UCCondicionesPago IsNot Nothing Then
                    UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotal.DecimalValue = UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue
                    UCCondicionesPago.Dock = DockStyle.Fill
                    UCCondicionesPago.Visible = True
                    UCCondicionesPago.BringToFront()
                    If UCCondicionesPago.RBPagoAcumulado.Checked = True Then
                        If IsNumeric(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue) Then
                            UCCondicionesPago.UCPagoCompletoDocumento.GetLoadGridCajas(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)

                            Dim pagos As Decimal = UCCondicionesPago.UCPagoCompletoDocumento.SumaPagos()

                            UCCondicionesPago.UCPagoCompletoDocumento.TextSaldo.DecimalValue = UCCondicionesPago.UCPagoCompletoDocumento.TextCompraTotal.DecimalValue - pagos
                        End If
                        'UCCondicionesPago.UCPagoCompletoDocumento.LoadGrid()
                        'UCCondicionesPago.UCPagoCompletoDocumento.SumaPagos()
                    ElseIf UCCondicionesPago.RBCronograma.Checked = True Then
                        UCCondicionesPago.UCCronogramaPagos.TextImporte.DecimalValue = UCEstructuraCabeceraVentaV2.txtTotalPagar.DecimalValue
                    End If
                    UCCondicionesPago.Show()
                End If
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub ComboComprobante_Click(sender As Object, e As EventArgs) Handles ComboComprobante.Click

    End Sub

    Private Sub ComboComprobante_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboComprobante.SelectedValueChanged

        If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
            UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CONTADO"
            UCEstructuraCabeceraVentaV2.ComboTerminosPago.Enabled = True

            UCEstructuraCabeceraVentaV2.GridCompra.TableDescriptor.Columns("afectoInventario").Width = 50

            'UCEstructuraCabeceraVentaV2.ComboTerminosPago.Enabled = False
            UCEstructuraCabeceraVentaV2.txtTotalPagar.Visible = True
            UCEstructuraCabeceraVentaV2.Label13.Visible = True
            UCEstructuraCabeceraVentaV2.ComboTerminosPago.Visible = True
        End If
        Select Case ComboComprobante.Text
            Case "VENTA"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    ToolStripButton4.Visible = True

                    Dim documentos As New List(Of String)

                    If Gempresas.ubigeo IsNot Nothing Then
                        documentos.Add("01")
                        documentos.Add("03")
                    End If

                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) documentos.Contains(o.codigoDetalle)).ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = True
                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Cobrar - F2"
                End If



                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If


            Case "PRE VENTA"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "1000").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Guardar - F2"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CREDITO"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Enabled = False

                    ToolStripButton4.Visible = True
                    UCEstructuraCabeceraVentaV2.GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0

                    UCEstructuraCabeceraVentaV2.RadioButton2.Checked = True
                    UCEstructuraCabeceraVentaV2.TextNumIdentrazon.Enabled = False
                    UCEstructuraCabeceraVentaV2.TextNumIdentrazon.Text = VarClienteGeneral.idEntidad
                    UCEstructuraCabeceraVentaV2.TextProveedor.Text = VarClienteGeneral.nombreCompleto
                    UCEstructuraCabeceraVentaV2.TextProveedor.Tag = VarClienteGeneral.idEntidad

                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Visible = False
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

            Case "PEDIDO"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "1001").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Guardar - F2"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CREDITO"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Enabled = False

                    ToolStripButton4.Visible = True
                    UCEstructuraCabeceraVentaV2.GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0

                    UCEstructuraCabeceraVentaV2.RadioButton2.Checked = True
                    UCEstructuraCabeceraVentaV2.TextNumIdentrazon.Enabled = False
                    UCEstructuraCabeceraVentaV2.TextNumIdentrazon.Text = VarClienteGeneral.idEntidad
                    UCEstructuraCabeceraVentaV2.TextProveedor.Text = VarClienteGeneral.nombreCompleto
                    UCEstructuraCabeceraVentaV2.TextProveedor.Tag = VarClienteGeneral.idEntidad

                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Visible = False
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

            Case "NOTA DE VENTA"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    ToolStripButton4.Visible = True
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9907").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = True


                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Cobrar - F2"
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

            Case "OTRA SALIDA DE ALMACEN"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    ToolStripButton4.Visible = False
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9907").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CREDITO"

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If

                    btGrabar.Text = "Guardar - F2"
                    UCEstructuraCabeceraVentaV2.txtTotalPagar.Visible = False
                    UCEstructuraCabeceraVentaV2.Label13.Visible = False
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Visible = False
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

            Case "PROFORMA"
                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    ToolStripButton4.Visible = False
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DataSource = UCEstructuraCabeceraVentaV2.ListaDocumentos.Where(Function(o) o.codigoDetalle = "9903").ToList
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.DisplayMember = "descripcion"
                    UCEstructuraCabeceraVentaV2.cboTipoDoc.ValueMember = "codigoDetalle"
                    BunifuFlatButton2.Visible = False

                    If UCCondicionesPago IsNot Nothing Then
                        UCCondicionesPago.Visible = False
                    End If
                    btGrabar.Text = "Guardar - F2"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text = "CREDITO"
                    UCEstructuraCabeceraVentaV2.ComboTerminosPago.Enabled = False
                    UCEstructuraCabeceraVentaV2.GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0
                End If

                If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                    UCEstructuraCabeceraVentaV2.Visible = True
                    UCEstructuraCabeceraVentaV2.BringToFront()
                    UCEstructuraCabeceraVentaV2.Show()
                End If

        End Select
    End Sub

    Private Sub ToolImportar_Click(sender As Object, e As EventArgs) Handles ToolImportar.Click
        Try
            Dim f As New FormBuscarVentasGeneral
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim c = CType(f.Tag, documento)
                UbicarDocumentoImportado(c)
                'dgvCompra.Focus()
                'Me.dgvCompra.TableControl.CurrentCell.MoveTo(dgvCompra.Table.Records.Count - 1, 7, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                'dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                'dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
                'Me.ActiveControl = Me.dgvCompra.TableControl
                'dgvCompra.WantTabKey = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btServicio_Click(sender As Object, e As EventArgs) Handles btServicio.Click

    End Sub

    Private Sub FormVentaNueva_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim DstribucionBE As New distribucionInfraestructura
        If General.ClipBoardDocumento IsNot Nothing Then
            General.ClipBoardDocumento = New documento
        End If

        If UCEstructuraCabeceraVentaV2.GridCompra.Table.Records.Count > 0 Then
            If btGrabar.Text = "Guardar - F2" Then
                If MessageBox.Show("¿Desea salir de la venta?", "Salir de la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    'If ListaEstadosFinancieros IsNot Nothing Then
                    '    ListaEstadosFinancieros.Clear()
                    'End If

                    If (ManipulacionEstado = ENTITY_ACTIONS.INSERT) Then
                        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
                        Dim distribucionInfraestructuraBE As New distribucionInfraestructura

                        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                        distribucionInfraestructuraBE.idDistribucion = UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag
                        distribucionInfraestructuraBE.estado = "A"
                        distribucionInfraestructuraSA.updateDistribucionxID(distribucionInfraestructuraBE)

                        Tag = distribucionInfraestructuraBE

                    End If

                Else
                    e.Cancel = True
                End If
            ElseIf btGrabar.Text = "Editar - F2" Then

            Else
                If MessageBox.Show("¿Desea salir de la venta?", "Salir de la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    'If ListaEstadosFinancieros IsNot Nothing Then
                    '    ListaEstadosFinancieros.Clear()
                    'End If

                    If (ManipulacionEstado = ENTITY_ACTIONS.INSERT) Then
                        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
                        Dim distribucionInfraestructuraBE As New distribucionInfraestructura

                        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                        distribucionInfraestructuraBE.idDistribucion = UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag
                        distribucionInfraestructuraBE.estado = "A"
                        distribucionInfraestructuraSA.updateDistribucionxID(distribucionInfraestructuraBE)

                        Tag = distribucionInfraestructuraBE
                    End If

                Else
                    e.Cancel = True
                End If
            End If

        Else
            'Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            'Dim distribucionInfraestructuraBE As New distribucionInfraestructura

            'distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            'distribucionInfraestructuraBE.idDistribucion = UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag
            'distribucionInfraestructuraBE.estado = "A"
            'distribucionInfraestructuraSA.updateDistribucionxID(distribucionInfraestructuraBE)

            'DstribucionBE.Codigo = 1

            'Me.Tag = DstribucionBE
        End If
    End Sub

    Private Sub FormVentaNueva_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            '    Me.Hide()
            'UCEstructuraCabeceraVentaV2.usercontrol.Hide()
        End If
    End Sub

    Private Sub FormVentaNueva_Load(sender As Object, e As EventArgs) Handles Me.Load
        Centrar(Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim formCode As New FormCodeEnter
        formCode.StartPosition = FormStartPosition.CenterParent
        formCode.ShowDialog(Me)
        If formCode.Tag IsNot Nothing Then
            UCEstructuraCabeceraVentaV2.PanelWaith.Visible = True
            ImportarProforma(formCode.Tag)
            UCEstructuraCabeceraVentaV2.PanelWaith.Visible = False
        Else
            MessageBox.Show("El codigo ingreso no pudo ser encontrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UCEstructuraCabeceraVentaV2.PanelWaith.Visible = False
        End If
    End Sub

#End Region

End Class