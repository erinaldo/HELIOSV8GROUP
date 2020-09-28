Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.Xml

Public Class Tab_ListaPedidosRestaurant

    Private FormImpresionNuevo As FormImpresionEquivalencia

    Private frmCambiarMesa As frmCambiarMesa

    Private FormImpresionPrecuenta As FormImpresionPrecuenta
    Public Property FormPurchase As FormControlRestaurant
    'Public Property documentoVentaDetalle As List(Of documentoPedidoDet)
    Public Property ID As Integer

    Public Property documentoPreVenta As New documento

    Public Property ListaDocumentoPreVenta As New List(Of documento)

    Public Property venta As List(Of documentoventaAbarrotes)

    Public Property ListaproductosVendidos As List(Of documentoventaAbarrotesDet)

    Public Property listaIDDocumento As New List(Of Integer)

    Public Property conteo As Integer = 0

    Dim consulta As List(Of documentoventaAbarrotesDet)

    Public Property NombreMesa As String

    Dim m_xmld As XmlDocument
    Dim m_nodelist As XmlNodeList
    Dim m_node As XmlNode

    Public Sub New(formRepPiscina As FormControlRestaurant)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        FormPurchase = formRepPiscina

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvPedidoDetalle, False, False)
    End Sub

    Public Sub New(formRepPiscina As FormControlRestaurant, TIPO As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        FormPurchase = formRepPiscina
        BunifuFlatButton7.Visible = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvPedidoDetalle, False, False)
    End Sub

#Region "Metodos"





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

        Dim ListaIDRef As New List(Of String)

        ListaIDRef.Add(documentoRecuperado.idDocumento)

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

        'Select Case ComboComprobante.Text
        '    'Case "PEDIDO"
        '    '    tipoVenta = TIPO_VENTA.VENTA_PEDIDO
        '    'Case "VENTA"
        '    '    tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
        '    Case "PRE VENTA"
        tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO
        'Case "NOTA DE VENTA"
        '    tipoVenta = TIPO_VENTA.NOTA_DE_VENTA
        'Case "OTRA SALIDA DE ALMACEN"
        '    tipoVenta = TIPO_COMPRA.OTRAS_SALIDAS
        'Case "PROFORMA"
        ''    tipoVenta = TIPO_VENTA.COTIZACION
        'End Select

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
        .ListaEstado = ListaIDRef,
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

                    'If ComboComprobante.Text = "OTRA SALIDA DE ALMACEN" Then

                    'Else
                    If i.importeMN.GetValueOrDefault <= 0 Then
                        Throw New Exception($"Debe ingresar un importe de venta > 0, para el Producto-{i.CustomProducto.descripcionItem}")
                    End If
                    'End If

                    objDet = New documentoventaAbarrotesDet With
                            {
                            .tasaIcbper = i.tasaIcbper.GetValueOrDefault,
                            .detalleAdicional = i.detalleAdicional,
                            .montoIcbper = i.montoIcbper.GetValueOrDefault,
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
                            .monto2 = i.PrecioUnitarioVentaMN.GetValueOrDefault,
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
                            .bonificacion = False,
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .tipobeneficio = 1,
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


    Public Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function

    Public Sub GetDocumentoVentaID(ID As Integer, TipoBusqueda As List(Of String), listaEstadoEntrega As List(Of String), listaTipoVenta As List(Of String))
        'Dim SumatoriaPendientes As Decimal = 0.0
        'Dim SumatoriaTotalVenta As Decimal = 0.0
        Dim documentoPedidoDetSA As New documentoPedidoDetSA
        Dim eentidaSA As New entidadSA
        Dim documentoBE As New documentoPedido
        Dim conteoNumeracio As Integer = 1
        Dim idDocumentoAnt As Integer = 0
        Dim ListaTipoExistencia As New List(Of String)
        Dim usuariosa As New UsuarioSA
        Dim dt As New DataTable

        listaIDDocumento = New List(Of Integer)

        documentoBE.idEmpresa = Gempresas.IdEmpresaRuc
        documentoBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoBE.ListaTipoVenta = New List(Of String)

        documentoBE.ListaTipoVenta = listaTipoVenta
        documentoBE.idCliente = ID
        documentoBE.ListaEstado = New List(Of String)
        documentoBE.ListaEstado = listaEstadoEntrega

        documentoBE.listaIdDistribucion = New List(Of String)
        documentoBE.listaIdDistribucion.Add(ID)

        consulta = New List(Of documentoventaAbarrotesDet)

        consulta = documentoPedidoDetSA.GetUbicar_DocveNTAxIdDistribucion(documentoBE)

        If (consulta.Count > 0) Then
            idDocumentoAnt = consulta(0).idDocumento
        End If

        'DETALLE DE LA COMPRA
        dgvPedidoDetalle.Table.Records.DeleteAll()

        With dt.Columns
            .Add("idDocumento")
            .Add("fecha")
            .Add("hora")
            .Add("tipoDoc")
            .Add("numero")
            .Add("Descripcion")
            .Add("cantidad")
            .Add("pumn")
            .Add("total")
            .Add("estado")
            .Add("idCliente")
            .Add("cliente")
            .Add("idVendedor")
            .Add("nombreVendedor")
            .Add("eliminar")
            .Add("tipoPreCuenta")
            .Add("secuencia")
        End With

        Dim ListaUsuarios = usuariosa.GetListaUsuarios()

        Dim sumatoriaPreCuenta As Decimal = (consulta.Where(Function(o) o.TipoDoc = "1000").Sum(Function(X) X.importeMN))

        Dim sumatoriaPendiente As Decimal = (consulta.Where(Function(o) o.TipoDoc = "1001").Sum(Function(X) X.importeMN))

        Dim SumatoriaCobrado As Decimal = (consulta.Where(Function(o) o.TipoDoc = "01" Or o.TipoDoc = "03" Or o.TipoDoc = "9907").Sum(Function(X) X.importeMN))

        For Each i In consulta.Where(Function(O) TipoBusqueda.Contains(O.TipoDoc)).ToList  '.Where(Function(o) tables.Contains(o.idtabla)).ToList

            Dim numeropedido As String = String.Empty
            Dim tipoDocumento As String = String.Empty

            If (idDocumentoAnt <> i.idDocumento) Then
                conteoNumeracio = conteoNumeracio + 1
                idDocumentoAnt = i.idDocumento
                numeropedido = (conteoNumeracio)
            Else
                numeropedido = (conteoNumeracio)
            End If

            Dim estadoCobr As String = String.Empty

            If (i.estadoPago = "DC") Then
                estadoCobr = "COBRADO"
            ElseIf (i.estadoPago = "PN") Then
                estadoCobr = "PENDIENTE"
            End If

            If (conteo = 0) Then
                Select Case i.TipoDoc
                    Case "01"
                        tipoDocumento = "FACTURA"
                    Case "03"
                        tipoDocumento = "BOLETA"
                    Case "1000"
                        tipoDocumento = "PRE CUENTA"
                        'SumatoriaTotalVenta = SumatoriaTotalVenta + i.importeMN
                    Case "9907"
                        tipoDocumento = "NOTA DE VENTA"
                    Case "1001"
                        tipoDocumento = "PEDIDO"
                        'SumatoriaPendientes = SumatoriaPendientes + i.importeMN
                End Select
            End If

            Dim USUARIO = (From LitUsu In ListaUsuarios Where LitUsu.IDUsuario = i.usuarioModificacion).FirstOrDefault

            If (Not IsNothing(USUARIO)) Then
                dt.Rows.Add(i.idDocumento,
                        i.FechaDoc.Value.ToShortDateString,
                        i.FechaDoc.Value.ToLongTimeString,
                       tipoDocumento,
                        numeropedido, i.nombreItem, i.monto1, (i.importeMN / i.monto1), i.importeMN, estadoCobr,
                        i.idCajaUsuario, i.NombreProveedor, i.usuarioModificacion,
                        (USUARIO.Nombres & " " & USUARIO.ApellidoPaterno & " " & USUARIO.ApellidoMaterno),
                        Nothing, True, i.secuencia)

            Else
                dt.Rows.Add(i.idDocumento,
                        i.FechaDoc.Value.ToShortDateString,
                        i.FechaDoc.Value.ToLongTimeString,
                       tipoDocumento,
                        numeropedido, i.nombreItem, i.monto1, (i.importeMN / i.monto1), i.importeMN, estadoCobr,
                        i.idCajaUsuario, i.NombreProveedor, i.usuarioModificacion, "VARIOS", Nothing, True, i.secuencia)

            End If

            listaIDDocumento.Add(i.idDocumento)

        Next
        dgvPedidoDetalle.DataSource = dt

        CALCULAR((sumatoriaPendiente + sumatoriaPreCuenta + SumatoriaCobrado), sumatoriaPreCuenta, sumatoriaPendiente, SumatoriaCobrado, conteoNumeracio)

    End Sub


    Sub CALCULAR(TotalVentas As Decimal, PreCuenta As Decimal, Pedido As Decimal, cobrado As Decimal, numPedidos As Integer)

        If (conteo = 0) Then
            TextSubTotal.Text = Pedido
            txtNumeroPedidos.Text = numPedidos
            txtTotalVenta.Text = TotalVentas
            txtNroPedidos.Text = PreCuenta
            txtCobrado.Text = cobrado
        End If

    End Sub

    Private Sub llamarDefault()
        Try
            Dim listaEntrega = New List(Of String)
            listaEntrega.Add("DC")
            listaEntrega.Add("PN")
            listaEntrega.Add("PR")
            listaEntrega.Add("AN")

            Dim listaTipoVenta = New List(Of String)
            listaTipoVenta.Add("VP")
            listaTipoVenta.Add("VNP")
            listaTipoVenta.Add("VELC")
            listaTipoVenta.Add("NOTE")

            Dim listaTipoVenta2 = New List(Of String)
            listaTipoVenta2.Add("1001")

            GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnRetorno_Click(sender As Object, e As EventArgs) Handles btnRetorno.Click
        Try
            FormPurchase.Tab_ListaPedidosRestaurant.Visible = False

            If FormPurchase.TabR_GestionInfraRestaurant IsNot Nothing Then
                FormPurchase.TabR_GestionInfraRestaurant.CargarDefault()
                FormPurchase.TabR_GestionInfraRestaurant.Visible = True
                FormPurchase.TabR_GestionInfraRestaurant.BringToFront()
                FormPurchase.TabR_GestionInfraRestaurant.Show()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton17_Click(sender As Object, e As EventArgs)
        Try
            Dim f As New FormCanastaPedidoDeVentasInfra()
            'f.IdDistribucion = txtInfraestructura.Tag
            f.txtInfraestructura.Tag = txtInfraestructura.Tag
            f.txtInfraestructura.Text = txtInfraestructura.Name
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            FormPurchase.Tab_ListaPedidosRestaurant.Visible = False
            If FormPurchase.TabR_GestionInfraRestaurant IsNot Nothing Then
                FormPurchase.TabR_GestionInfraRestaurant.CargarDefault()
                FormPurchase.TabR_GestionInfraRestaurant.Visible = True
                FormPurchase.TabR_GestionInfraRestaurant.BringToFront()
                FormPurchase.TabR_GestionInfraRestaurant.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Try


            Dim Formulario As Object = Nothing

            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load("C:\SPKconfiguration.xml")

            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el Formulario de inicio
                Formulario = m_node.ChildNodes.Item(0).InnerText
                Exit For
            Next

            If Formulario = "PRECUENTA" Then
                Dim ListaDocumentoGuardar As New List(Of documento)
                Dim ventaSA As New documentoVentaAbarrotesSA
                'Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
                'Dim distribucionInfraestructuraBE As New distribucionInfraestructura

                Dim Vendedor = GetCodigoVendedor()

                If Vendedor Is Nothing Then
                    Throw New Exception("Debe indicar el codigo del vendedor!")
                End If

                documentoPreVenta.usuarioActualizacion = Vendedor.IDUsuario

                venta = ventaSA.GetListaVentaID(New Business.Entity.documento With {.ListaDocumentoID = listaIDDocumento, .tipoDoc = "VP"})

                ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)

                Dim totalImporte As Decimal = 0.0
                Dim totalPedio As Integer = venta.Count

                For Each document In venta
                    ListaproductosVendidos = (document.documentoventaAbarrotesDet.Where(Function(O) O.estadoDistribucion = "A").ToList)
                    Exit For
                Next


                For Each documento In venta
                    documentoPreVenta = MappingDocumento(documento)
                    MappingDocumentoCompraCabecera(documentoPreVenta, documento)
                    MappingDocumentoCompraCabeceraDetalle(documentoPreVenta)

                    ListaDocumentoGuardar.Add(documentoPreVenta)
                Next

                Dim doc = ventaSA.GrabarVentaEquivalenciaXListaDoc(ListaDocumentoGuardar)

                If dgvPedidoDetalle.Table.Records.Count > 0 Then

                    Dim nombre = UsuariosList.Where(Function(O) O.IDUsuario = CInt(venta(0).usuarioActualizacion)).FirstOrDefault.Full_Name

                    FormImpresionNuevo = New FormImpresionEquivalencia(ListaproductosVendidos, True)  ' frmVentaNuevoFormato
                    FormImpresionNuevo.tienda = nombre
                    FormImpresionNuevo.FormaPago = "2"
                    FormImpresionNuevo.Email = txtInfraestructura.Text & " " & lblHabitacion.Text
                    FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen
                    FormImpresionNuevo.ShowDialog(Me)


                    FormPurchase.Tab_ListaPedidosRestaurant.Visible = False
                    If FormPurchase.TabR_GestionInfraRestaurant IsNot Nothing Then
                        FormPurchase.TabR_GestionInfraRestaurant.CargarDefault()
                        FormPurchase.TabR_GestionInfraRestaurant.Visible = True
                        FormPurchase.TabR_GestionInfraRestaurant.BringToFront()
                        FormPurchase.TabR_GestionInfraRestaurant.Show()
                    End If
                Else
                    MessageBox.Show("No existe productos ")
                End If

            ElseIf Formulario = "DIRECTO" Then

                FormPurchase.TabP_RestaurantMaster.Visible = False
                FormPurchase.TabR_GestionInfraRestaurant.Visible = False

                If FormPurchase.FormCanastaPedidoPorCobrar IsNot Nothing Then
                    FormPurchase.FormCanastaPedidoPorCobrar.Visible = True
                    FormPurchase.FormCanastaPedidoPorCobrar.listaDistribucion = New List(Of String)
                    FormPurchase.FormCanastaPedidoPorCobrar.listaDistribucion.Add(txtInfraestructura.Tag)
                    FormPurchase.FormCanastaPedidoPorCobrar.txtInfraestructura.Tag = txtInfraestructura.Tag
                    FormPurchase.FormCanastaPedidoPorCobrar.txtInfraestructura.Text = txtInfraestructura.Text & " " & lblHabitacion.Text
                    FormPurchase.FormCanastaPedidoPorCobrar.CARGARdATOS()
                    FormPurchase.FormCanastaPedidoPorCobrar.BringToFront()
                    FormPurchase.FormCanastaPedidoPorCobrar.Show()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try
            If MessageBox.Show("¿Desea eliminar todo el pedido?", "Eliminar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim documentoventaBE As New documentoventaAbarrotes
                Dim documentoventaSA As New documentoVentaAbarrotesDetSA
                Dim listaID As New List(Of String)

                For Each ite In listaIDDocumento
                    listaID.Add(ite)
                Next

                documentoventaBE.ListaIdDocumento = listaID
                documentoventaBE.idCliente = ID
                documentoventaBE.idEmpresa = Gempresas.IdEmpresaRuc
                documentoventaBE.estado = "A"

                documentoventaSA.DeletePedidoRestaurant(documentoventaBE)


                FormPurchase.Tab_ListaPedidosRestaurant.Visible = False

                If FormPurchase.TabR_GestionInfraRestaurant IsNot Nothing Then
                    FormPurchase.TabR_GestionInfraRestaurant.CargarDefault()
                    FormPurchase.TabR_GestionInfraRestaurant.Visible = True
                    FormPurchase.TabR_GestionInfraRestaurant.BringToFront()
                    FormPurchase.TabR_GestionInfraRestaurant.Show()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try

            Dim Formulario As Object = Nothing

            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load("C:\SPKconfiguration.xml")

            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el Formulario de inicio
                Formulario = m_node.ChildNodes.Item(0).InnerText
                Exit For
            Next


            Dim f As New FormVentaTouch()
            f.GetComboPrincipal()
            f.UCEstructuraCabeceraVentaV2.PanelCenter.Size = New Size(521, 73)
            If Formulario = "DIRECTO" Then
                f.ComboComprobante.Text = "PRE VENTA"
            ElseIf Formulario = "PRECUENTA" Then
                f.ComboComprobante.Text = "PEDIDO"
            End If
            f.ComboComprobante.ReadOnly = True
            f.UCEstructuraCabeceraVentaV2.CargarCategorias()
            f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = txtInfraestructura.Text & " " & lblHabitacion.Text
            f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = txtInfraestructura.Tag
            f.UCEstructuraCabeceraVentaV2.RadioButton2.Checked = True
            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            ID = txtInfraestructura.Tag
            'Dim listaEntrega = New List(Of String)
            'listaEntrega.Add("DC")
            'listaEntrega.Add("PN")
            'listaEntrega.Add("PR")
            'listaEntrega.Add("AN")

            'Dim listaTipoVenta = New List(Of String)
            'listaTipoVenta.Add("VP")
            'listaTipoVenta.Add("VNP")
            'listaTipoVenta.Add("VELC")
            'listaTipoVenta.Add("NOTE")

            ''Dim listaTipoVenta2 = New List(Of String)
            ''listaTipoVenta2.Add("1001")

            'If Formulario = "DIRECTO" Then
            '    Dim listaTipoVenta2 = New List(Of String)
            '    listaTipoVenta2.Add("1000")
            '    GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)
            'ElseIf Formulario = "PRECUENTA" Then
            '    Dim listaTipoVenta2 = New List(Of String)
            '    listaTipoVenta2.Add("1001")
            '    GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)
            'End If

            FormPurchase.Tab_ListaPedidosRestaurant.Visible = False
            If FormPurchase.TabR_GestionInfraRestaurant IsNot Nothing Then
                FormPurchase.TabR_GestionInfraRestaurant.CargarDefault()
                FormPurchase.TabR_GestionInfraRestaurant.Visible = True
                FormPurchase.TabR_GestionInfraRestaurant.BringToFront()
                FormPurchase.TabR_GestionInfraRestaurant.Show()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            Dim Formulario As Object = Nothing
            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load("C:\SPKconfiguration.xml")

            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el Formulario de inicio
                Formulario = m_node.ChildNodes.Item(0).InnerText
                Exit For
            Next

            Dim listaTipoVenta2 = New List(Of String)
            If Formulario = "PRECUENTA" Then
                listaTipoVenta2.Add("1001")
            ElseIf Formulario = "DIRECTO" Then
                listaTipoVenta2.Add("1000")
            End If

            Dim listaEntrega = New List(Of String)
            listaEntrega.Add("DC")
            listaEntrega.Add("PN")
            listaEntrega.Add("PR")
            listaEntrega.Add("AN")

            Dim listaTipoVenta = New List(Of String)
            listaTipoVenta.Add("VP")
            listaTipoVenta.Add("VNP")
            listaTipoVenta.Add("VELC")
            listaTipoVenta.Add("NOTE")

            GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DgvPedidoDetalle_QueryCellStyleInfo(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs) Handles dgvPedidoDetalle.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "estado")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("estado").ToString()

                Select Case value
                    Case "PENDIENTE"
                        e.Style.BackColor = Color.Red
                        e.Style.TextColor = Color.White
                    Case "COBRADO"
                        e.Style.BackColor = Color.BlueViolet
                        e.Style.TextColor = Color.White
                End Select
            End If
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim listaEntrega = New List(Of String)
        listaEntrega.Add("DC")
        listaEntrega.Add("PN")
        listaEntrega.Add("PR")
        listaEntrega.Add("AN")

        Dim listaTipoVenta = New List(Of String)
        listaTipoVenta.Add("VP")
        listaTipoVenta.Add("VNP")
        listaTipoVenta.Add("VELC")
        listaTipoVenta.Add("NOTE")

        Dim listaTipoVenta2 = New List(Of String)
        listaTipoVenta2.Add("1000")

        GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles lblpendiente.Click
        Dim listaEntrega = New List(Of String)
        listaEntrega.Add("DC")
        listaEntrega.Add("PN")
        listaEntrega.Add("PR")
        listaEntrega.Add("AN")

        Dim listaTipoVenta = New List(Of String)
        listaTipoVenta.Add("VP")
        listaTipoVenta.Add("VNP")
        listaTipoVenta.Add("VELC")
        listaTipoVenta.Add("NOTE")

        Dim listaTipoVenta2 = New List(Of String)
        listaTipoVenta2.Add("1001")


        GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim listaEntrega = New List(Of String)
        listaEntrega.Add("DC")
        listaEntrega.Add("PN")
        listaEntrega.Add("PR")
        listaEntrega.Add("AN")

        Dim listaTipoVenta = New List(Of String)
        listaTipoVenta.Add("VP")
        listaTipoVenta.Add("VNP")
        listaTipoVenta.Add("VELC")
        listaTipoVenta.Add("NOTE")

        Dim listaTipoVenta2 = New List(Of String)
        listaTipoVenta2.Add("1000")
        listaTipoVenta2.Add("1001")
        listaTipoVenta2.Add("01")
        listaTipoVenta2.Add("03")
        listaTipoVenta2.Add("9907")

        GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try
            Dim nombre = "VARIOS"
            Dim DocumentoBE As New documentoventaAbarrotesDet
            Dim ListaDocumentoBE As New List(Of documentoventaAbarrotesDet)

            'For Each ITEM In dgvPedidoDetalle.Table.Records
            '    DocumentoBE = New documentoventaAbarrotesDet
            '    DocumentoBE.nombreItem = ITEM.GetValue("Descripcion")
            '    DocumentoBE.monto1 = CInt(ITEM.GetValue("cantidad"))
            '    DocumentoBE.importeMN = CDec(ITEM.GetValue("total"))

            '    ListaDocumentoBE.Add(DocumentoBE)
            'Next

            FormImpresionPrecuenta = New FormImpresionPrecuenta(txtInfraestructura.Tag)  ' frmVentaNuevoFormato
            FormImpresionPrecuenta.tienda = txtInfraestructura.Text & " " & lblHabitacion.Text
            FormImpresionPrecuenta.FormaPago = "1"
            FormImpresionPrecuenta.TIPOiMPESION = 2
            FormImpresionPrecuenta.Email = txtInfraestructura.Text & " " & lblHabitacion.Text
            FormImpresionPrecuenta.StartPosition = FormStartPosition.CenterScreen
            FormImpresionPrecuenta.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim listaEntrega = New List(Of String)
        listaEntrega.Add("DC")
        listaEntrega.Add("PN")
        listaEntrega.Add("PR")
        listaEntrega.Add("AN")

        Dim listaTipoVenta = New List(Of String)
        listaTipoVenta.Add("VP")
        listaTipoVenta.Add("VNP")
        listaTipoVenta.Add("VELC")
        listaTipoVenta.Add("NOTE")

        Dim listaTipoVenta2 = New List(Of String)
        listaTipoVenta2.Add("01")
        listaTipoVenta2.Add("02")
        listaTipoVenta2.Add("9907")

        GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        frmCambiarMesa = New frmCambiarMesa()  ' frmVentaNuevoFormato
        frmCambiarMesa.cargarCombo()
        frmCambiarMesa.txtInfraestructura.Text = txtInfraestructura.Text & " " & lblHabitacion.Text
        frmCambiarMesa.txtInfraestructura.Tag = txtInfraestructura.Tag
        frmCambiarMesa.StartPosition = FormStartPosition.CenterScreen
        frmCambiarMesa.ShowDialog(Me)

        FormPurchase.Tab_ListaPedidosRestaurant.Visible = False

        If FormPurchase.TabR_GestionInfraRestaurant IsNot Nothing Then
            FormPurchase.TabR_GestionInfraRestaurant.CargarDefault()
            FormPurchase.TabR_GestionInfraRestaurant.Visible = True
            FormPurchase.TabR_GestionInfraRestaurant.BringToFront()
            FormPurchase.TabR_GestionInfraRestaurant.Show()

        End If


    End Sub

    Private Sub DgvPedidoDetalle_TableControlDrawCell(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlDrawCellEventArgs) Handles dgvPedidoDetalle.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 15 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub DgvPedidoDetalle_TableControlPushButtonClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellPushButtonClickEventArgs) Handles dgvPedidoDetalle.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 15 Then
                If MessageBox.Show("¿Desea eliminar el producto?", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    Dim idDistribucion = dgvPedidoDetalle.TableModel(e.Inner.RowIndex, 17).CellValue
                    Dim IdDocumento = dgvPedidoDetalle.TableModel(e.Inner.RowIndex, 1).CellValue
                    Dim tipodoc = dgvPedidoDetalle.TableModel(e.Inner.RowIndex, 4).CellValue


                    Dim Formulario As Object = Nothing

                    'Creamos el "Document"
                    m_xmld = New XmlDocument()

                    'Cargamos el archivo
                    m_xmld.Load("C:\SPKconfiguration.xml")

                    'Obtenemos la lista de los nodos "name"
                    m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

                    'Iniciamos el ciclo de lectura
                    For Each m_node In m_nodelist
                        'Obtenemos el Formulario de inicio
                        Formulario = m_node.ChildNodes.Item(0).InnerText
                        Exit For
                    Next


                    If Formulario = "PRECUENTA" Then
                        If (tipodoc = "PEDIDO") Then
                            UpdatePedido(idDistribucion, IdDocumento)

                            Dim listaEntrega = New List(Of String)
                            listaEntrega.Add("DC")
                            listaEntrega.Add("PN")
                            listaEntrega.Add("PR")
                            listaEntrega.Add("AN")

                            Dim listaTipoVenta = New List(Of String)
                            listaTipoVenta.Add("VP")
                            listaTipoVenta.Add("VNP")
                            listaTipoVenta.Add("VELC")
                            listaTipoVenta.Add("NOTE")

                            Dim listaTipoVenta2 = New List(Of String)
                            listaTipoVenta2.Add("1001")

                            GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)

                        Else
                            MessageBox.Show("No se puede eliminar")
                        End If

                    ElseIf Formulario = "DIRECTO" Then
                        If (tipodoc = "PRE CUENTA") Then
                            UpdatePedido(idDistribucion, IdDocumento)

                            Dim listaEntrega = New List(Of String)
                            listaEntrega.Add("DC")
                            listaEntrega.Add("PN")
                            listaEntrega.Add("PR")
                            listaEntrega.Add("AN")

                            Dim listaTipoVenta = New List(Of String)
                            listaTipoVenta.Add("VP")
                            listaTipoVenta.Add("VNP")
                            listaTipoVenta.Add("VELC")
                            listaTipoVenta.Add("NOTE")

                            Dim listaTipoVenta2 = New List(Of String)
                            listaTipoVenta2.Add("1000")

                            GetDocumentoVentaID(ID, listaTipoVenta2, listaEntrega, listaTipoVenta)

                        Else
                            MessageBox.Show("No se puede eliminar")
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UpdatePedido(IDSecuencia As Integer, IdDocumento As Integer)
        Try
            Dim documentoventaBE As New documentoventaAbarrotesDet
            Dim documentoventaSA As New documentoVentaAbarrotesDetSA

            documentoventaBE.secuencia = IDSecuencia
            documentoventaBE.idDocumento = IdDocumento
            documentoventaBE.idDistribucion = ID
            documentoventaBE.IdEmpresa = Gempresas.IdEmpresaRuc
            documentoventaBE.estadoDistribucion = "A"

            documentoventaSA.DeleteItemVentaRestaurant(documentoventaBE)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Try
            Dim nombre = "VARIOS"
            Dim DocumentoBE As New documentoventaAbarrotesDet
            Dim ListaDocumentoBE As New List(Of documentoventaAbarrotesDet)

            FormImpresionPrecuenta = New FormImpresionPrecuenta(txtInfraestructura.Tag, False)  ' frmVentaNuevoFormato
            FormImpresionPrecuenta.tienda = txtInfraestructura.Text & " " & lblHabitacion.Text
            FormImpresionPrecuenta.FormaPago = "2"
            FormImpresionPrecuenta.Email = "---"
            FormImpresionPrecuenta.StartPosition = FormStartPosition.CenterScreen
            FormImpresionPrecuenta.ShowDialog(Me)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#End Region

End Class
