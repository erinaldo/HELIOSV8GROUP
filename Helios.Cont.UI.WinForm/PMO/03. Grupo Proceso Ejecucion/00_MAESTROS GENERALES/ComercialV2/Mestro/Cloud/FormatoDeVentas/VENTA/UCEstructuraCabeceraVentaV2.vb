Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports HtmlAgilityPack
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Imports System.Xml
Imports Syncfusion.Drawing
Imports System.Threading.Tasks

Public Class UCEstructuraCabeceraVentaV2

#Region "Attributes"
    Dim popup As Popup
    '  Private UCCanastaDeVentas As UCCanstaDeVentas
    Public Property usercontrol As UserControlCanasta
    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Public Property ListaproductosVendidos As List(Of documentoventaAbarrotesDet)
    Private Property ProductoSA As New detalleitemsSA
    Public Property FormPurchase As FormVentaNueva
    Public Property ListaDocumentos As List(Of tabladetalle)

    Public listaProductos As List(Of detalleitems)
    Private Property UCPreciosCanastaVenta As UCPreciosCanastaVenta

    Private Property UserControlPreciosCompraVenta As UserControlPreciosCompraVenta

    Private Property UCbeneficiosCanastaVenta As UCbeneficiosCanastaVenta
    '   Public listaEquivalencias As List(Of detalleitem_equivalencias)
    Public Property UCVentaDescripcion As UCVentaDescripcion
    Public Property ListaTipoCategorias As New List(Of item)

    Public Event OKEvent()

    Dim m_xmld As XmlDocument
    Dim m_nodelist As XmlNodeList
    Dim m_node As XmlNode

#End Region

#Region "Constructors"
    Public Sub New(formventaNueva As FormVentaNueva)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormPurchase = formventaNueva
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        '  FormatoGridAvanzado(GridTotales, False, False, 8.0F)
        '   listaEquivalencias = New List(Of detalleitem_equivalencias)
        ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)
        GetTablasGenerales()
        FormatoGrid(GridCompra)
        '  FormatoGrid(GridTotales)
        LoadTablaEquivalencias()

        '  UCCanastaDeVentas = New UCCanstaDeVentas(Me)
        usercontrol = New UserControlCanasta(Me)
        popup = New Popup(usercontrol)
        popup.Resizable = True
        UCPreciosCanastaVenta = New UCPreciosCanastaVenta With {.Dock = DockStyle.Fill}
        UCbeneficiosCanastaVenta = New UCbeneficiosCanastaVenta(formventaNueva) With {.Dock = DockStyle.Fill, .Visible = False}
        UserControlPreciosCompraVenta = New UserControlPreciosCompraVenta With {.Dock = DockStyle.Fill, .Visible = False}
        UCVentaDescripcion = New UCVentaDescripcion(formventaNueva) With {.Dock = DockStyle.Fill, .Visible = False}

        UCPreciosCanastaVenta.BringToFront()
        UCPreciosCanastaVenta.Visible = False
        PanelBody.Controls.Add(UCPreciosCanastaVenta)
        PanelBody.Controls.Add(UCbeneficiosCanastaVenta)
        PanelBody.Controls.Add(UserControlPreciosCompraVenta)
        PanelBody.Controls.Add(UCVentaDescripcion)

        AddHandler usercontrol.OKEvent, AddressOf ucB_OKEvent
        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        Me.GridCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.Trimming = StringTrimming.EllipsisCharacter
        Me.GridCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.HorizontalAlignment = GridHorizontalAlignment.Left
        Me.GridCompra.TableControl.CellToolTip.AutomaticDelay = 25000

        'AddHandler GridCompra.TableModel.QueryRowHeight, AddressOf TableModel_QueryRowHeight

        '        AddHandler GridCompra.TableControl.DrawCommentIndicator, AddressOf TableControl_DrawCommentIndicator
        '  Me.GridCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.CommentTip.CommentArrowSize = New Size(0, 10)

        ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications

    End Sub
#End Region

#Region "Methods"

    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Private Sub TableModel_QueryRowHeight(ByVal sender As Object, ByVal e As GridRowColSizeEventArgs)
        If e.Index > 0 Then
            Dim graphicsProvider As IGraphicsProvider = Me.GridCompra.TableModel.GetGraphicsProvider()
            Dim g As Graphics = graphicsProvider.Graphics
            Dim style As GridStyleInfo = Me.GridCompra.TableModel(e.Index, 3)
            Dim model As GridCellModelBase = style.CellModel
            e.Size = model.CalculatePreferredCellSize(g, e.Index, 3, style, GridQueryBounds.Height).Height
            e.Handled = True
        End If
    End Sub

    Private Function GetConsultarDNIReniecAPIs(Dni As String) As String
        Dim strJSON As String = String.Empty
        Dim rClient As RESTClientAPI = New RESTClientAPI()
        Dim appat As String = String.Empty
        Dim apmat As String = String.Empty
        Dim nom As String = String.Empty
        Dim fullName As String = String.Empty
        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                rClient.endPoint = "https://api.reniec.cloud/dni/" & Dni
            Case ApisReniec.ApiGrupoTeComCom
                rClient.endPoint = "http://apis.grupotecom.com/api/ConsultaDni?dni=" & Dni
            Case ApisReniec.ApiConsultasDsdInformaticos
                rClient.endPoint = "http://consultas.dsdinformaticos.com/reniec.php?dni=" & Dni
        End Select

        strJSON = rClient.makeRequest()
        Dim res = JsonConvert.DeserializeObject(strJSON)

        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                appat = res("apellido_paterno").ToString() 'res.apellido_paterno
                apmat = res("apellido_materno").ToString() ' res.apellido_materno
                nom = res("nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")
            Case ApisReniec.ApiGrupoTeComCom

                fullName = res("result")("NombreCompleto")
                fullName = Trim(fullName)
            Case ApisReniec.ApiConsultasDsdInformaticos
                appat = res("result")("ApellidoPaterno").ToString() 'res.apellido_paterno
                apmat = res("result")("ApellidoMaterno").ToString() ' res.apellido_materno
                nom = res("result")("Nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")
        End Select

        'Dim s = res("dni").ToString()

        '  nombres = MIHTML.Replace("|", Space(1))
        Return fullName
    End Function
    Public Sub AgregarComboXTipoCategoria(tipo As String)

        Dim Consultas = (From i In ListaTipoCategorias
                         Where i.tipo = tipo).ToList


        ComboTipoCategorias.ValueMember = "idItem"
        ComboTipoCategorias.DisplayMember = "descripcion"
        ComboTipoCategorias.DataSource = Consultas



    End Sub


    Public Sub ListarTipodCategoria()
        Dim itemsa As New itemSA
        Dim TablaSA As New tablaDetalleSA

        ListaTipoCategorias = itemsa.ListaTotalItem(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})



    End Sub

    Private Sub ZeroRows()
        For Each i In GridCompra.Table.Records
            i.SetValue("totalmn", 0)
            i.SetValue("totalme", 0)
            i.SetValue("vcmn", 0)
            i.SetValue("vcme", 0)
            i.SetValue("pumn", 0)
            i.SetValue("pume", 0)
            i.SetValue("igvmn", 0)
            i.SetValue("igvme", 0)

            GetCalculoItemV2(i)
            EditarItemVenta(i)
        Next
    End Sub

    Private Sub ChangeRowsTipoCambio()
        For Each i In GridCompra.Table.Records
            GetCalculoItemV2(i)
            EditarItemVenta(i)
        Next
    End Sub
    Public Sub ucB_OKEvent()
        popup.Hide()
        'Debug.Print("OK Event received from UserControl in FormB")
        RaiseEvent OKEvent()
    End Sub


    Sub BuscarProductoxAlmacen(tipo As String, idalmacen As Integer)
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
        dt.Columns.Add("idAlmacen")


        If CheckStock.Checked = True Then

            If ChVentaLote.Checked = True Then

                listaProductos = listaSA.GetProductosWithInventarioAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = TextFiltrar.Text,
                                                          .idAlmacen = 2
                                                          })
            Else

                Select Case ComboTipoBusqueda.Text
                    Case "PRODUCTO"

                        listaProductos = listaSA.GetProductosWithInventarioTipoAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = TextFiltrar.Text,
                                                          .typeConsult = tipo,
                                                         .idAlmacen = idalmacen
                                                          })

                    Case "CATEGORIA", "SUBCATEGORIA", "MARCA"
                        listaProductos = listaSA.GetProductosWithInventarioTipoAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = TextFiltrar.Text,
                                                           .typeConsult = tipo,
                                                       .idItem = ComboTipoCategorias.SelectedValue,
                                                       .unidad2 = ComboTipoCategorias.SelectedValue,
                                                       .marcaRef = ComboTipoCategorias.SelectedValue,
                                                         .idAlmacen = idalmacen
                                                          })


                    Case "COLOR"

                        listaProductos = listaSA.GetProductosWithInventarioTipoAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .color = TextFiltrar.Text,
                                                          .typeConsult = tipo,
                                                         .idAlmacen = idalmacen
                                                          })

                    Case "TALLA"

                        listaProductos = listaSA.GetProductosWithInventarioTipoAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .talla = TextFiltrar.Text,
                                                          .typeConsult = tipo,
                                                         .idAlmacen = idalmacen
                                                          })
                    Case "ADICIONAL1"

                        listaProductos = listaSA.GetProductosWithInventarioTipoAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .electricidad = TextFiltrar.Text,
                                                          .typeConsult = tipo,
                                                         .idAlmacen = idalmacen
                                                          })
                    Case "ADICIONAL2"

                        listaProductos = listaSA.GetProductosWithInventarioTipoAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .transmision = TextFiltrar.Text,
                                                          .typeConsult = tipo,
                                                         .idAlmacen = idalmacen
                                                          })
                    Case "PRESENTACION/MODELO"


                        listaProductos = listaSA.GetProductosWithInventarioTipoAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .presentacion = TextFiltrar.Text,
                                                          .typeConsult = tipo,
                                                         .idAlmacen = idalmacen
                                                          })
                End Select




            End If

        Else



            Me.listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                        {
                                                        .idEmpresa = Gempresas.IdEmpresaRuc,
                                                        .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                        .descripcionItem = TextFiltrar.Text
                                                        })

        End If

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

                If usuario.tipoNegocio = "1" Then
                    i.detalleitem_equivalencias = i.detalleitem_equivalencias.OrderByDescending(Function(z) z.contenido_neto).ToList
                Else
                    i.detalleitem_equivalencias = i.detalleitem_equivalencias.OrderBy(Function(z) z.contenido_neto).ToList
                End If


                catalagoDefault = i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault
                Else
                    catalagoDefault = Nothing
            End If


            StockTotal = 0
            If CheckStock.Checked = True Then
                StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            End If

            If i.detalleitem_equivalencias.FirstOrDefault IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
                Dim unidadMaxima = i.detalleitem_equivalencias.Max(Function(o) o.contenido_neto).GetValueOrDefault

                dt.Rows.Add(
                    i.origenProducto,
                    i.codigodetalle,
                    i.descripcionItem,
                    StockTotal,
                    i.unidad1,
                     i.detalleitem_equivalencias.FirstOrDefault.equivalencia_id, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0, i.idAlmacen)
            Else
                dt.Rows.Add(
                    i.origenProducto,
                    i.codigodetalle,
                    i.descripcionItem,
                    StockTotal,
                    i.unidad1,
                    0, If(catalagoDefault IsNot Nothing, catalagoDefault.idCatalogo, Nothing), 0, i.idAlmacen)
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
        usercontrol.GridCompra.DataSource = dt
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub


    Sub BuscarProductoBarCodeUnidadComercial()
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


        listaProductos = listaSA.GetProductsCodeUnidadComercial(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .codigo = TextFiltrar.Text
                                                          })
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
            If CheckStock.Checked = True Then
                StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            End If

            If i.detalleitem_equivalencias.FirstOrDefault IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
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
        usercontrol.GridCompra.DataSource = dt
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Sub BuscarProductoBarCodeUnidadComercialAlmacen()
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

        listaProductos = listaSA.GetProductsCodeUnidadComercialAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .codigo = TextFiltrar.Text,
                                                          .idAlmacen = combotipoalmacen.SelectedValue
                                                          })
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
            If CheckStock.Checked = True Then
                StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            End If

            If i.detalleitem_equivalencias.FirstOrDefault IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
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
        usercontrol.GridCompra.DataSource = dt
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Sub BuscarProducto(tipo As String)
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





        If CheckStock.Checked = True Then

            If ChVentaLote.Checked = True Then

                listaProductos = listaSA.GetProductosWithInventarioAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = TextFiltrar.Text,
                                                          .idAlmacen = 2
                                                          })
            Else

                Select Case ComboTipoBusqueda.Text
                    Case "PRODUCTO"

                        listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = TextFiltrar.Text,
                                                          .typeConsult = tipo
                                                          })

                    Case "CATEGORIA", "SUBCATEGORIA", "MARCA"
                        listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .descripcionItem = TextFiltrar.Text,
                                                           .typeConsult = tipo,
                                                       .idItem = ComboTipoCategorias.SelectedValue,
                                                       .unidad2 = ComboTipoCategorias.SelectedValue,
                                                       .marcaRef = ComboTipoCategorias.SelectedValue
                                                          })


                    Case "COLOR"

                        listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .color = TextFiltrar.Text,
                                                          .typeConsult = tipo
                                                          })

                    Case "TALLA"

                        listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .talla = TextFiltrar.Text,
                                                          .typeConsult = tipo
                                                          })
                    Case "ADICIONAL1"

                        listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .electricidad = TextFiltrar.Text,
                                                          .typeConsult = tipo
                                                          })
                    Case "ADICIONAL2"

                        listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .transmision = TextFiltrar.Text,
                                                          .typeConsult = tipo
                                                          })
                    Case "PRESENTACION/MODELO"


                        listaProductos = listaSA.GetProductosWithInventario(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .presentacion = TextFiltrar.Text,
                                                          .typeConsult = tipo
                                                          })
                End Select




            End If

        Else



            Me.listaProductos = listaSA.GetProductosWithEquivalencias(New detalleitems With
                                                        {
                                                        .idEmpresa = Gempresas.IdEmpresaRuc,
                                                        .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                        .descripcionItem = TextFiltrar.Text
                                                        })

        End If

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


                If usuario.tipoNegocio = "1" Then
                    i.detalleitem_equivalencias = i.detalleitem_equivalencias.Where(Function(o) o.estado = "A").OrderByDescending(Function(z) z.contenido_neto).ToList
                Else
                    i.detalleitem_equivalencias = i.detalleitem_equivalencias.Where(Function(o) o.estado = "A").OrderBy(Function(z) z.contenido_neto).ToList
                End If


                catalagoDefault = i.detalleitem_equivalencias.FirstOrDefault.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True And o.estado = 1).FirstOrDefault
            Else
                catalagoDefault = Nothing
            End If


            StockTotal = 0
            If CheckStock.Checked = True Then
                StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            End If

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
        'usercontrol.GridTotales.DataSource = dt
        'usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'usercontrol.GridTotales.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left


        usercontrol.GridCompra.DataSource = dt
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left




    End Sub


    Sub BuscarProductoCodigoInternoAlmacen(idAlmacen As Integer)
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


        listaProductos = listaSA.GetProductsCodigoInternoAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .codigoInterno = TextFiltrar.Text,
                                                          .idAlmacen = idAlmacen
                                                          })
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
            If CheckStock.Checked = True Then
                StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            End If

            If i.detalleitem_equivalencias.FirstOrDefault IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
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
        usercontrol.GridCompra.DataSource = dt
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Sub BuscarProductoCodigoInterno()
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


        listaProductos = listaSA.GetProductsCodigoInterno(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .codigoInterno = TextFiltrar.Text
                                                          })
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
            If CheckStock.Checked = True Then
                StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            End If

            If i.detalleitem_equivalencias.FirstOrDefault IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
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
        usercontrol.GridCompra.DataSource = dt
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Sub BuscarProductoBarCodeAlmacen(idalmacen As Integer)
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


        listaProductos = listaSA.GetProductsBarCodeAlmacen(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .codigoInterno = TextFiltrar.Text,
                                                          .idAlmacen = idalmacen
                                                          })
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
            If CheckStock.Checked = True Then
                StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            End If

            If i.detalleitem_equivalencias.FirstOrDefault IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
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
        usercontrol.GridCompra.DataSource = dt
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Sub BuscarProductoBarCode()
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


        listaProductos = listaSA.GetProductsBarCode(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .codigoInterno = TextFiltrar.Text
                                                          })
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
            If CheckStock.Checked = True Then
                StockTotal = If(i.totalesAlmacen IsNot Nothing, i.totalesAlmacen.Sum(Function(o) o.cantidad), 0)
            End If

            If i.detalleitem_equivalencias.FirstOrDefault IsNot Nothing AndAlso i.detalleitem_equivalencias.Count > 0 Then
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
        usercontrol.GridCompra.DataSource = dt
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        usercontrol.GridCompra.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub GridTotales_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboEquivalencias" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = Me.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim listaEquivalencias = prod.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

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
        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboPrecios" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim prod = Me.listaProductos.Where(Function(o) o.codigodetalle = value).Single
            Dim idEquiva = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cboEquivalencias").ToString()
            If idEquiva.Trim.Length > 0 Then
                Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                Dim listaPreciosVenta = GetCatalogoPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
                e.Style.DataSource = listaPreciosVenta
                e.Style.DisplayMember = "nombre_corto"
                e.Style.ValueMember = "idCatalogo"
            Else
                e.Style.DataSource = Nothing
                e.Style.DisplayMember = "nombre_corto"
                e.Style.ValueMember = "idCatalogo"
            End If
            'If idEquiva.Trim.Length > 0 Then
            '    Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
            '    Dim listaPreciosVenta = GetPrecios(objEquivalencia.detalleitemequivalencia_catalogos.ToList)
            '    e.Style.DataSource = listaPreciosVenta
            '    e.Style.DisplayMember = "precioCode"
            '    e.Style.ValueMember = "precio"
            'Else
            '    e.Style.DataSource = Nothing
            '    e.Style.DisplayMember = "precioCode"
            '    e.Style.ValueMember = "precio"
            'End If
        ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "importeMn" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then


        End If
    End Sub

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

#Region "GridTotales"
    'Private Sub GridTotales_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridTotales.QueryCellStyleInfo
    '    If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboEquivalencias" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

    '        Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
    '        ' If value > 0 Then
    '        Dim prod = listaProductos.Where(Function(o) o.codigodetalle = value).Single
    '            Dim listaEquivalencias = prod.detalleitem_equivalencias.ToList

    '            '   If value = "a" Then
    '            e.Style.DataSource = GetEquivalencias(listaEquivalencias)
    '            e.Style.DisplayMember = "detalle"
    '            e.Style.ValueMember = "equivalencia_id"
    '        'End If

    '        'ElseIf value = "b" Then
    '        '    e.Style.DataSource = ZipCodes
    '        '    e.Style.DisplayMember = "City"
    '        '    e.Style.ValueMember = "Class"
    '        'ElseIf value = "c" Then
    '        '    e.Style.DataSource = Shippers
    '        '    e.Style.DisplayMember = "Shipper ID"
    '        '    e.Style.ValueMember = "Company Name"
    '        'End If
    '    ElseIf e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cboPrecios" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

    '        Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
    '        'If value > 0 Then
    '        Dim prod = listaProductos.Where(Function(o) o.codigodetalle = value).Single
    '            Dim idEquiva = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("cboEquivalencias").ToString()
    '            If idEquiva.Trim.Length > 0 Then
    '                Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
    '                Dim listaPreciosVenta = GetPrecios(objEquivalencia.detalleitemequivalencia_precios.ToList)
    '                e.Style.DataSource = listaPreciosVenta
    '                e.Style.DisplayMember = "precioCode"
    '                e.Style.ValueMember = "precio"
    '            Else
    '                e.Style.DataSource = Nothing
    '                e.Style.DisplayMember = "precioCode"
    '                e.Style.ValueMember = "precio"
    '            End If
    '        '  End If

    '    End If
    'End Sub

    Private Sub GridTotales_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs)
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "Agregar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            ElseIf e.Inner.ColIndex = 10 Then
                e.Inner.Style.Description = "Stock"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
            End If
        End If
    End Sub

    Private Sub GridTotales_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 9 Then
                Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                MsgBox("Cantidad: " & inp)
            ElseIf e.Inner.ColIndex = 10 Then
                '        Dim idProducto = UCCanastaDeVentas.GridTotales.TableModel(e.Inner.RowIndex, 2).CellValue
                '   GetProductosEnAlmacen(idProducto)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub GridTotales_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridTotales.TableControlCurrentCellCloseDropDown

    '    Dim cc As GridCurrentCell = GridTotales.TableControl.CurrentCell
    '    cc.ConfirmChanges()

    '    e.TableControl.CurrentCell.EndEdit()
    '    e.TableControl.Table.TableDirty = True
    '    e.TableControl.Table.EndEdit()

    '    If cc.ColIndex > -1 Then
    '        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

    '        If style.TableCellIdentity.Column.Name = "cboEquivalencias" Then
    '            'Dim CodigoEQ As String = cc.Renderer.ControlText
    '            Dim r As Record = GridTotales.Table.CurrentRecord
    '            r.SetValue("cboPrecios", String.Empty)
    '            'r.SetValue("cboEquivalencias", String.Empty)
    '            r.SetValue("importeMn", 0)

    '            'If text.Trim.Length > 0 Then
    '            '    Dim value As Decimal = Convert.ToDecimal(text)
    '            '    cc.Renderer.ControlValue = value

    '            'End If
    '        ElseIf style.TableCellIdentity.Column.Name = "cboPrecios" Then
    '            Dim text As String = cc.Renderer.ControlText

    '            If text.Trim.Length > 0 Then
    '                Dim r As Record = GridTotales.Table.CurrentRecord

    '                Dim CodigoPrecio As String = text
    '                Dim codigoEQ = r.GetValue("cboEquivalencias")

    '                'cc.Renderer.ControlValue = CodigoPrecio

    '                Dim prod = listaProductos.Where(Function(o) o.codigodetalle = r.GetValue("idItem")).Single
    '                Dim objEquivalencia = prod.detalleitem_equivalencias.Where(Function(i) i.equivalencia_id = codigoEQ).SingleOrDefault
    '                If prod IsNot Nothing Then
    '                    Dim precID = text
    '                    Dim Precios = objEquivalencia.detalleitemequivalencia_precios.Where(Function(o) o.precioCode = precID).SingleOrDefault
    '                    If Precios IsNot Nothing Then
    '                        r.SetValue("importeMn", Precios.precio)
    '                    End If
    '                End If
    '            End If

    '        End If

    '    End If

    'End Sub
#End Region

    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("U.M.")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("contenido")

        dt.Columns(0).ColumnMapping = MappingType.Hidden
        dt.Columns(1).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.contenido_neto) ' i.fraccionUnidad)
        Next
        Return dt
    End Function

    Private Function GetPrecios(lista As List(Of detalleitemequivalencia_precios)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("precioCode")
        dt.Columns.Add("precio")

        For Each i In lista
            dt.Rows.Add(i.precioCode, i.precio)
        Next
        Return dt
    End Function

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

    Private Sub FormatoGrid(grid As GridGroupingControl)
        For Each i In grid.TableDescriptor.Columns
            i.AllowSort = False
            i.Appearance.AnyRecordFieldCell.TextColor = Color.Black
        Next
    End Sub

    Public Sub GetTotalesDocumento()
        Dim sumaTotal As Decimal = 0
        Dim sumaBaseImponible1 As Decimal = 0
        Dim sumaBaseImponible2 As Decimal = 0
        Dim sumaIva1 As Decimal = 0
        Dim sumaIva2 As Decimal = 0
        Dim descuento As Decimal = TextDescuento.DecimalValue
        Dim sumaIcbper As Decimal = 0
        Dim sumaIcbperME As Decimal = 0

        'MONEDA EXTRANJERA
        Dim sumaTotalME As Decimal = 0
        Dim sumaBaseImponible1ME As Decimal = 0
        Dim sumaBaseImponible2ME As Decimal = 0
        Dim sumaIva1ME As Decimal = 0
        Dim sumaIva2ME As Decimal = 0
        For Each i In GridCompra.Table.Records
            Dim codigoItem = i.GetValue("codigo")
            Dim Item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigoItem).SingleOrDefault

            'Select Case Boolean.Parse(Item.FlagBonif)
            '    Case True

            '    Case Else
            Select Case Item.tipobeneficio
                Case "OFERTA"

                Case Else
                    sumaTotal += CDec(i.GetValue("totalmn"))
                    sumaTotalME += CDec(i.GetValue("totalme"))
                    Select Case i.GetValue("gravado")
                        Case "1"
                            sumaBaseImponible1 += CDec(i.GetValue("vcmn"))
                            sumaIva1 += CDec(i.GetValue("igvmn"))

                            sumaBaseImponible1ME += CDec(i.GetValue("vcme"))
                            sumaIva1ME += CDec(i.GetValue("igvme"))
                        Case "2"
                            sumaBaseImponible2 += CDec(i.GetValue("vcmn"))
                            sumaIva2 += CDec(i.GetValue("igvmn"))

                            sumaBaseImponible2ME += CDec(i.GetValue("vcme"))
                            sumaIva2ME += CDec(i.GetValue("igvme"))
                    End Select

                    If i.GetValue("tipoAfectacion") = "ICBPER" Then
                        sumaIcbper += CDec(i.GetValue("totalafect"))
                    End If
            End Select
            '  End Select
        Next
        TextSubTotal.DecimalValue = sumaTotal
        txtTotalPagar.Value = (sumaTotal - descuento + sumaIcbper).ToString("N2")
        DigitalME.Value = (sumaTotalME - descuento + sumaIcbper).ToString("N2")

        'MONEDA EXTRANJERA
        txtTotalBase.DecimalValue = sumaBaseImponible1
        txtTotalBase2.DecimalValue = sumaBaseImponible2
        txtTotalIva.DecimalValue = sumaIva1
        txtTotalIcbper.DecimalValue = sumaIcbper

        'MONEDA EXTRANJERA
        txtTotalBaseME.DecimalValue = sumaBaseImponible1ME
        txtTotalBase2ME.DecimalValue = sumaBaseImponible2ME
        txtTotalIvaME.DecimalValue = sumaIva1ME
        txtTotalIcbperME.DecimalValue = sumaIcbperME
    End Sub

    Private Sub GetTablasGenerales()
        Dim listaMoneda = General.TablasGenerales.GetMonedas()
        ListaDocumentos = GetComprobantesCompra()
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9907", .descripcion = "NOTA"})
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9903", .descripcion = "COTIZACION"})
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "1000", .descripcion = "PRE VENTA"})

        cboMesCompra.DataSource = General.ListaDeMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.SelectedValue = String.Format("{0:00}", Date.Now.Month)
        TextAnio.DecimalValue = Date.Now.Year

        cboMoneda.DataSource = listaMoneda
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.ValueMember = "codigoDetalle"


        cboTipoDoc.DataSource = ListaDocumentos
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"

        'Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl

        'Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.DisplayMember = "detalle"
        'Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"
        txtHora.Value = Date.Now
        TxtDia.DecimalValue = Date.Now.Day

        Select Case tmpConfigInicio.FormatoVenta
            Case "FACT"
                GridCompra.TableDescriptor.Columns("afectoInventario").ReadOnly = True
            Case Else
                GridCompra.TableDescriptor.Columns("afectoInventario").ReadOnly = False
        End Select

        ListarTipodCategoria()





        Dim almacenSA As New almacenSA
        Dim almacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        Dim objeto As New almacen
        objeto.idAlmacen = 0
        objeto.descripcionAlmacen = "TODOS"
        almacenes.Add(objeto)

        combotipoalmacen.DataSource = almacenes
        combotipoalmacen.DisplayMember = "descripcionAlmacen"
        combotipoalmacen.ValueMember = "idAlmacen"

        combotipoalmacen.Text = "TODOS"




        txtTotalPagar.OuterFrameGradientStartColor = Color.White
        txtTotalPagar.OuterFrameGradientEndColor = Color.White
        txtTotalPagar.ForeColor = Color.Purple

        DigitalME.OuterFrameGradientStartColor = Color.White
        DigitalME.OuterFrameGradientEndColor = Color.White
        DigitalME.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

    End Sub

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        'Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://clientes.reniec.gob.pe/padronElectoral2012/consulta.htm?hTipo=2&hDni=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        Dim nombres = String.Empty
        ' Dim array = MIHTML.Split("|")
        Dim posicion = 0
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument
        doc.LoadHtml(MIHTML)

        For Each node As HtmlTextNode In doc.DocumentNode.SelectNodes("//text()")
            Select Case posicion
                Case 36
                    nombres = node.Text
                    Exit For
                Case 42
                   ' TextDNI.Text = node.Text
                Case 60
                  '  TextProvincia.Text = node.Text
                Case 66
                 '   TextDepartamento.Text = node.Text
                Case 54
                    '   TextDistrito.Text = node.Text
            End Select
            posicion = posicion + 1
        Next


        '  nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            GetValidarLocalDB = True
            PictureLoad.Visible = False

            If TextProveedor.Text.Trim.Length > 0 Then
                TextFiltrar.Select()
                TextFiltrar.Focus()
            Else
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

    Private Sub GrabarEntidadRapida()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = TextProveedor.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                                   .Action = BaseBE.EntityAction.INSERT,
                                                   .tipo = "DOMICILIO",
                                                   .tipoVia = SelRazon.TipoVia,
                                                   .Via = SelRazon.Via,
                                                   .ubigeo = SelRazon.Ubigeo,
                                                   .estado = 1,
                                                   .valorAtributo = SelRazon.direccion,
                                                   .usuarioModificacion = usuario.IDUsuario,
                                                   .fechaModificacion = Date.Now
                                                   })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                ' If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                SelRazon.tipoPersona = "N"
                SelRazon.tipoDoc = "6"
                ' End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextProveedor.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextProveedor.Clear()
                PictureLoad.Visible = False
            End If
        End If
        TextNumIdentrazon.ReadOnly = False
    End Sub

    Private Async Sub GetApiSunat(ByVal nroruc As String)
        'SelRazon = New entidad()

        'Using client = New HttpClient()

        '    If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
        '        SelRazon.tipoPersona = "N"
        '    ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
        '        SelRazon.tipoPersona = "J"
        '    End If

        '    'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")


        '    'Dim responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)


        '    Dim responseTask = Await client.GetAsync("https://api.sunat.cloud/ruc/" & nroruc)
        '    ' responseTask.Wait()
        '    'Dim result = responseTask.Result

        '    If responseTask.IsSuccessStatusCode Then
        '        Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente2)()
        '        readTask.Wait()
        '        Dim students = readTask.Result
        '        SelRazon.tipoDoc = "6"
        '        SelRazon.tipoEntidad = "CL"
        '        SelRazon.nombreCompleto = students.NombreORazonSocial
        '        SelRazon.nombreContacto = students.NombreORazonSocial
        '        TextProveedor.Text = students.NombreORazonSocial
        '        SelRazon.estado = students.EstadoDelContribuyente
        '        SelRazon.nrodoc = students.Ruc
        '        SelRazon.direccion = students.Direccion

        '        'SelRazon.TipoVia = students.TipoDeVia
        '        'SelRazon.Via = students.NombreDeVia
        '        'SelRazon.Ubigeo = students.Ubigeo

        '        GrabarEntidadRapida()
        '        PictureLoad.Visible = False
        '    Else
        '        GetConsultaSunatAsync(nroruc)

        '        'TextProveedor.Clear()
        '        'PictureLoad.Visible = False
        '    End If
        '    TextNumIdentrazon.ReadOnly = False
        'End Using

        SelRazon = New entidad()
        Dim responseTask As New HttpResponseMessage
        Using client = New HttpClient()
            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If

            Select Case ApiRucOption
                Case ApisRuc.ApiRucCloudPeru
                    Try

                        client.Timeout = TimeSpan.FromSeconds(5)
                        responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)

                        If responseTask.IsSuccessStatusCode Then
                            Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
                            readTask.Wait()
                            Dim students = readTask.Result
                            SelRazon.tipoDoc = "6"
                            SelRazon.tipoEntidad = "CL"
                            SelRazon.nombreCompleto = students.NombreORazonSocial
                            SelRazon.nombreContacto = students.NombreORazonSocial
                            TextProveedor.Text = students.NombreORazonSocial
                            SelRazon.estado = students.EstadoDelContribuyente
                            SelRazon.nrodoc = students.Ruc
                            SelRazon.direccion = students.Direccion & " " & students.Manzana & " " & students.Lote & " " & students.CodigoDeZona & " " & students.TipoDeZona

                            SelRazon.TipoVia = students.TipoDeVia
                            SelRazon.Via = students.NombreDeVia
                            SelRazon.Ubigeo = students.Ubigeo

                            GrabarEntidadRapida()
                            PictureLoad.Visible = False
                        Else
                            GetConsultaSunatAsync(nroruc)

                            'TextProveedor.Clear()
                            'PictureLoad.Visible = False
                        End If
                        TextNumIdentrazon.ReadOnly = False

                    Catch ex As WebException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As TaskCanceledException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                        Dim Login As New frmCrearENtidades
                        Login.WebBrowser1.Navigate("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaMovil.jsp")
                        Login.strTipo = TIPO_ENTIDAD.CLIENTE
                        Login.StartPosition = FormStartPosition.CenterParent
                        Login.ShowDialog(Me)

                        If Login.Tag IsNot Nothing Then
                            Dim ent = CType(Login.Tag, entidad)
                            TextNumIdentrazon.Text = ent.nrodoc
                            TextProveedor.Text = ent.nombreCompleto
                            TextProveedor.Tag = ent.idEntidad
                        Else
                            TextNumIdentrazon.Text = String.Empty
                            TextProveedor.Text = String.Empty
                            TextProveedor.Tag = Nothing
                        End If

                    End Try
                Case ApisRuc.ApiRucSunatCloud
                    'client.Timeout = TimeSpan.FromSeconds(5)
                    'responseTask = Await client.GetAsync("https://api.sunat.cloud/ruc/" & nroruc)

                    'If responseTask.IsSuccessStatusCode Then
                    '    Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente2)()
                    '    readTask.Wait()
                    '    Dim students = readTask.Result
                    '    SelRazon.tipoDoc = "6"
                    '    SelRazon.tipoEntidad = "CL"
                    '    SelRazon.nombreCompleto = students.NombreORazonSocial
                    '    SelRazon.nombreContacto = students.NombreORazonSocial
                    '    TextProveedor.Text = students.NombreORazonSocial
                    '    SelRazon.estado = students.EstadoDelContribuyente
                    '    SelRazon.nrodoc = students.Ruc
                    '    SelRazon.direccion = students.Direccion

                    '    'SelRazon.TipoVia = students.TipoDeVia
                    '    'SelRazon.Via = students.NombreDeVia
                    '    'SelRazon.Ubigeo = students.Ubigeo

                    '    GrabarEntidadRapida()
                    '    PictureLoad.Visible = False
                    'Else
                    '    GetConsultaSunatAsync(nroruc)

                    '    'TextProveedor.Clear()
                    '    'PictureLoad.Visible = False
                    'End If
                    'TextNumIdentrazon.ReadOnly = False

                    Try
                        client.Timeout = TimeSpan.FromSeconds(5)
                        responseTask = Await client.GetAsync("https://api.sunat.cloud/ruc/" & nroruc)

                        If responseTask.IsSuccessStatusCode Then
                            Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente2)()
                            readTask.Wait()
                            Dim students = readTask.Result
                            SelRazon.tipoDoc = "6"
                            SelRazon.tipoEntidad = "CL"
                            SelRazon.nombreCompleto = students.NombreORazonSocial
                            SelRazon.nombreContacto = students.NombreORazonSocial
                            TextProveedor.Text = students.NombreORazonSocial
                            SelRazon.estado = students.EstadoDelContribuyente
                            SelRazon.nrodoc = students.Ruc
                            SelRazon.direccion = students.Direccion

                            'SelRazon.TipoVia = students.TipoDeVia
                            'SelRazon.Via = students.NombreDeVia
                            'SelRazon.Ubigeo = students.Ubigeo
                            GrabarEntidadRapida()
                            PictureLoad.Visible = False
                        Else
                            GetConsultaSunatAsync(nroruc)
                            'TextProveedor.Clear()
                            'PictureLoad.Visible = False
                        End If
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As WebException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As TaskCanceledException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                        Dim Login As New frmCrearENtidades
                        Login.WebBrowser1.Navigate("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaMovil.jsp")
                        Login.strTipo = TIPO_ENTIDAD.CLIENTE
                        Login.StartPosition = FormStartPosition.CenterParent
                        Login.ShowDialog(Me)

                        If Login.Tag IsNot Nothing Then
                            Dim ent = CType(Login.Tag, entidad)
                            TextNumIdentrazon.Text = ent.nrodoc
                            TextProveedor.Text = ent.nombreCompleto
                            TextProveedor.Tag = ent.idEntidad
                        Else
                            TextNumIdentrazon.Text = String.Empty
                            TextProveedor.Text = String.Empty
                            TextProveedor.Tag = Nothing
                        End If

                    End Try


                Case ApisRuc.ApiRucaqfac
                    Try

                        client.Timeout = TimeSpan.FromSeconds(5)
                        responseTask = Await client.GetAsync("http://ruc.aqpfact.pe/sunat/" & nroruc)

                        If responseTask.IsSuccessStatusCode Then
                            Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente3)()
                            readTask.Wait()
                            Dim students = readTask.Result
                            SelRazon.tipoDoc = "6"
                            SelRazon.tipoEntidad = "CL"
                            SelRazon.nombreCompleto = students.NombreORazonSocial
                            SelRazon.nombreContacto = students.NombreORazonSocial
                            TextProveedor.Text = students.NombreORazonSocial
                            SelRazon.estado = students.EstadoDelContribuyente
                            SelRazon.nrodoc = students.Ruc
                            SelRazon.direccion = students.Direccion

                            'SelRazon.TipoVia = students.TipoDeVia
                            'SelRazon.Via = students.NombreDeVia
                            'SelRazon.Ubigeo = students.Ubigeo

                            GrabarEntidadRapida()
                            PictureLoad.Visible = False
                        Else
                            GetConsultaSunatAsync(nroruc)

                            'TextProveedor.Clear()
                            'PictureLoad.Visible = False
                        End If
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As WebException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As TaskCanceledException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                        Dim Login As New frmCrearENtidades
                        Login.WebBrowser1.Navigate("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaMovil.jsp")
                        Login.strTipo = TIPO_ENTIDAD.CLIENTE
                        Login.StartPosition = FormStartPosition.CenterParent
                        Login.ShowDialog(Me)

                        If Login.Tag IsNot Nothing Then
                            Dim ent = CType(Login.Tag, entidad)
                            TextNumIdentrazon.Text = ent.nrodoc
                            TextProveedor.Text = ent.nombreCompleto
                            TextProveedor.Tag = ent.idEntidad
                        Else
                            TextNumIdentrazon.Text = String.Empty
                            TextProveedor.Text = String.Empty
                            TextProveedor.Tag = Nothing
                        End If

                    End Try
            End Select
        End Using

    End Sub

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextProveedor.Text = ent.nombreCompleto
            TextProveedor.Tag = ent.idEntidad
        Else
            TextNumIdentrazon.Text = String.Empty
            TextProveedor.Text = String.Empty
            TextProveedor.Tag = Nothing
        End If
    End Sub
#End Region

#Region "Events"

    Private Sub TextNumIdentrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumIdentrazon.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            PictureLoad.Visible = True
                            'nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)
                            nombres = GetConsultarDNIReniecAPIs(TextNumIdentrazon.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumIdentrazon.Clear()
                                    TextProveedor.Text = String.Empty
                                    TextProveedor.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextProveedor.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()
                                    PictureLoad.Visible = False
                                Else
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextProveedor.Tag = existeEnDB.idEntidad
                                    'If RadioButton2.Checked = True Then
                                    TextFiltrar.Focus()
                                    TextFiltrar.Select()
                                    'ElseIf RadioButton1.Checked = True Then
                                    '    txtruc.Focus()
                                    '    txtruc.Select()
                                    'End If
                                End If
                            Else
                                TextNumIdentrazon.Clear()
                                TextProveedor.Text = String.Empty
                                TextProveedor.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = TextProveedor.Text.Trim
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()
                                PictureLoad.Visible = False
                            Else
                                TextProveedor.Text = existeEnDB.nombreCompleto
                                TextProveedor.Tag = existeEnDB.idEntidad
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'If RadioButton2.Checked = True Then
                                TextFiltrar.Focus()
                                TextFiltrar.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                            End If
                        End If



                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextProveedor.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                TextNumIdentrazon.ReadOnly = True

                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        '  GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                        GetApiSunat(TextNumIdentrazon.Text.Trim)
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        BgProveedor.RunWorkerAsync()
                                End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                Dim nroDoc = TextNumIdentrazon.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        TextFiltrar.Select()
                                        TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        TextFiltrar.Select()
                                        TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextProveedor.Text = String.Empty
                        TextNumIdentrazon.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextProveedor.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
    '    GrabarEnFormBasico()
    'End Sub


    Public Sub AgregarProductoDetalleVenta(cantidad As Decimal, idProductoSel As Integer, precioventa As Decimal, eq As detalleitem_equivalencias, CatalogoPrecio As Integer)
        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = idProductoSel
        Dim total As Decimal = 0

        'Dim precioVentaValue As Decimal = precioventa
        'Dim canti As Decimal = cantidad
        'Dim baseImponible As Decimal = 0
        'Dim Iva As Decimal = 0
        'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
        'Dim total As Decimal = sub_total * precioventa '  canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
        'baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
        'Iva = Math.Round(total - baseImponible, 2)

        Dim precioVentaValue As Decimal = precioventa
        Dim canti As Decimal = cantidad
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0
        'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        Select Case producto.origenProducto
            Case "1"
                total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                Iva = Math.Round(total - baseImponible, 2)
            Case Else
                total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                baseImponible = total ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                Iva = 0
        End Select


        If producto IsNot Nothing Then
            'Dim listaUnidadesComerciales = producto.detalleitem_equivalencias.ToList
            'Dim UnidadComercialMaxima = listaUnidadesComerciales.Where(Function(o) o.flag = "MAX").SingleOrDefault

            Dim catalogoOBJ = eq.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CatalogoPrecio).SingleOrDefault

            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()

            If FormPurchase.CheckDistribucion.Checked = True Then
                obj.AfectoInventario = False
                obj.estadoEntrega = EstadoTrasladoVenta.Pedido
            Else
                Select Case tmpConfigInicio.FormatoVenta
                    Case "FACT"
                        obj.AfectoInventario = False
                        obj.estadoEntrega = EstadoTrasladoVenta.Pedido
                    Case Else
                        obj.AfectoInventario = producto.AfectoStock.GetValueOrDefault ' True
                        obj.estadoEntrega = EstadoTrasladoVenta.EntregaConExito
                End Select
            End If

            obj.CodigoCosto = cod
            obj.ContenidoNetoUnidadComercialMaxima = eq.contenido_neto ' UnidadComercialMaxima.contenido ' UnidadComercialMaxima.fraccionUnidad
            obj.idItem = producto.codigodetalle
            obj.CustomProducto = producto
            obj.CustomEquivalencia = eq
            obj.CustomCatalogo = catalogoOBJ
            obj.catalogo_id = catalogoOBJ.idCatalogo
            obj.monto1 = cantidad
            AddItemVentaDetalle(producto, obj)
            obj.unidad2 = eq.detalle
            obj.montokardex = baseImponible
            obj.montoIgv = Iva
            obj.importeMN = total
            obj.PrecioUnitarioVentaMN = precioventa
            obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            obj.descuentoMN = 0
            obj.tasaIcbper = producto.otroImpuesto
            obj.montoIcbper = producto.otroImpuesto * cantidad
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
            GetTotalesDocumento()

        End If

        ' MsgBox(listViewItem.SubItems(1).Text)
    End Sub




    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextFiltrar.KeyDown
        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                If TextFiltrar.Text.Trim.Length > 0 AndAlso TextFiltrar.Text.Trim.Length >= 2 Then
                    PictureLoadingProduct.Visible = True
                    'listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextFiltrar.Text})
                    'DFGFGFG
                    'UCCanastaDeVentas.GridTotales.Table.Records.DeleteAll()
                    'ListProductos.Items.Clear()
                    Select Case ComboTipoBusqueda.Text
                        Case "CODIGO BARRA UC"
                            If combotipoalmacen.Text = "TODOS" Then
                                BuscarProductoBarCodeUnidadComercial()
                            Else
                                BuscarProductoBarCodeUnidadComercialAlmacen()
                            End If


                            If listaProductos.Count > 0 AndAlso listaProductos.Count = 1 Then
                                Dim equivalencia = usercontrol.GridCompra.Table.Records(0).GetValue("cboEquivalencias")
                                Dim CatalogoPrecio = usercontrol.GridCompra.Table.Records(0).GetValue("cboPrecios")
                                ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                                Dim eqLista = listaProductos.Where(Function(o) o.codigodetalle = Me.usercontrol.GridCompra.Table.Records(0).GetValue("idItem")).SingleOrDefault

                                If eqLista.productoRestringido = True Then
                                    If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                End If

                                Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                                Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                                If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                                    Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                                    If catalogPredeterminado IsNot Nothing Then
                                        usercontrol.GridCompra.Table.Records(0).SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                                    Else
                                        usercontrol.GridCompra.Table.Records(0).SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                    End If

                                    usercontrol.GridCompra.Table.Records(0).SetCurrent("descripcion")
                                    TextFiltrar.Clear()
                                    TextFiltrar.Select()
                                    'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                                End If

                                '-----------------------------------------------------------------------------------------------------------------------------------------------
                                '-----------------------------------------------------------------------------------------------------------------------------------------------

                                If CatalogoPrecio.ToString.Trim.Length = 0 Then
                                    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If

                                Dim codiAlmacen = Me.usercontrol.GridCompra.Table.Records(0).GetValue("idAlmacen")

                                Dim idProducto = Me.usercontrol.GridCompra.Table.Records(0).GetValue("idItem")
                                Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                                Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                                '   If inp IsNot Nothing Then
                                If IsNumeric(inp) Then
                                    If (inp) > 0 Then

                                        Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                                        precioVenta = precioventaFormula


                                        If codiAlmacen IsNot Nothing Then
                                            AgregarProductoDetalleVentaAlmacen(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio, codiAlmacen)
                                        Else
                                            AgregarProductoDetalleVenta(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio)
                                        End If




                                        LoadCanastaVentas(ListaproductosVendidos)
                                        PictureLoadingProduct.Visible = False
                                        'Me.usercontrol.GridTotales.Table.Records(0).SetCurrent("descripcion")
                                        'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                                        'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
                                    Else
                                        MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            ElseIf listaProductos.Count >= 2 Then
                                popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                                PictureLoadingProduct.Visible = False

                                'Dim rec As GridRecord = Me.usercontrol.GridTotales.Table.Records(1)
                                'rec.SetCurrent("descripcion")
                                'usercontrol.GridTotales.Focus()

                                Dim colIndex As Integer = Me.usercontrol.GridCompra.TableDescriptor.FieldToColIndex(0)
                                Dim rowIndex As Integer = Me.usercontrol.GridCompra.Table.Records(0).GetRowIndex()
                                Me.usercontrol.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                            ElseIf listaProductos.Count <= 0 Then
                                PictureLoadingProduct.Visible = False
                                MessageBox.Show("El código ingresado no se encuentra en la base de datos de productos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                TextFiltrar.Clear()
                                TextFiltrar.Select()
                            End If

                        Case "CODIGO BARRA"

                            If combotipoalmacen.Text = "TODOS" Then
                                BuscarProductoBarCode()
                            Else
                                BuscarProductoBarCodeAlmacen(combotipoalmacen.SelectedValue)
                            End If

                            If listaProductos.Count > 0 AndAlso listaProductos.Count = 1 Then
                                Dim equivalencia = usercontrol.GridCompra.Table.Records(0).GetValue("cboEquivalencias")
                                Dim CatalogoPrecio = usercontrol.GridCompra.Table.Records(0).GetValue("cboPrecios")
                                ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                                Dim eqLista = listaProductos.Where(Function(o) o.codigodetalle = usercontrol.GridCompra.Table.Records(0).GetValue("idItem")).SingleOrDefault

                                If eqLista.productoRestringido = True Then
                                    If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                End If

                                Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                                Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                                If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                                    Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                                    If catalogPredeterminado IsNot Nothing Then
                                        usercontrol.GridCompra.Table.Records(0).SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                                    Else
                                        usercontrol.GridCompra.Table.Records(0).SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                    End If

                                    usercontrol.GridCompra.Table.Records(0).SetCurrent("descripcion")
                                    TextFiltrar.Clear()
                                    TextFiltrar.Select()
                                    'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                                End If

                                '-----------------------------------------------------------------------------------------------------------------------------------------------
                                '-----------------------------------------------------------------------------------------------------------------------------------------------

                                If CatalogoPrecio.ToString.Trim.Length = 0 Then
                                    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If

                                Dim idProducto = Me.usercontrol.GridCompra.Table.Records(0).GetValue("idItem")
                                Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                                Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                                '   If inp IsNot Nothing Then
                                If IsNumeric(inp) Then
                                    If (inp) > 0 Then

                                        Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                                        precioVenta = precioventaFormula

                                        AgregarProductoDetalleVenta(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio)
                                        LoadCanastaVentas(ListaproductosVendidos)
                                        PictureLoadingProduct.Visible = False
                                        'Me.usercontrol.GridTotales.Table.Records(0).SetCurrent("descripcion")
                                        'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                                        'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
                                    Else
                                        MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            ElseIf listaProductos.Count >= 2 Then
                                popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                                PictureLoadingProduct.Visible = False

                                'Dim rec As GridRecord = Me.usercontrol.GridTotales.Table.Records(1)
                                'rec.SetCurrent("descripcion")
                                'usercontrol.GridTotales.Focus()

                                Dim colIndex As Integer = Me.usercontrol.GridCompra.TableDescriptor.FieldToColIndex(0)
                                Dim rowIndex As Integer = Me.usercontrol.GridCompra.Table.Records(0).GetRowIndex()
                                Me.usercontrol.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                            ElseIf listaProductos.Count <= 0 Then
                                PictureLoadingProduct.Visible = False
                                MessageBox.Show("El código ingresado no se encuentra en la base de datos de productos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                TextFiltrar.Clear()
                                TextFiltrar.Select()
                            End If


                        Case "CODIGO INTERNO"
                            If combotipoalmacen.Text = "TODOS" Then
                                BuscarProductoCodigoInterno()
                            Else
                                BuscarProductoCodigoInternoAlmacen(combotipoalmacen.SelectedValue)
                            End If

                            If listaProductos.Count > 0 AndAlso listaProductos.Count = 1 Then
                                Dim equivalencia = usercontrol.GridCompra.Table.Records(0).GetValue("cboEquivalencias")
                                Dim CatalogoPrecio = usercontrol.GridCompra.Table.Records(0).GetValue("cboPrecios")
                                ' If CatalogoPrecio.ToString.Trim.Length > 0 Then
                                Dim eqLista = listaProductos.Where(Function(o) o.codigodetalle = usercontrol.GridCompra.Table.Records(0).GetValue("idItem")).SingleOrDefault

                                If eqLista.productoRestringido = True Then
                                    If MessageBox.Show("El producto seleccionado está restringido, Desea añadir?", "Producto prohibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                End If

                                Dim listaEquivalencias = eqLista.detalleitem_equivalencias.ToList
                                Dim objEQ = listaEquivalencias.Where(Function(o) o.equivalencia_id = equivalencia).SingleOrDefault

                                If objEQ.detalleitemequivalencia_catalogos IsNot Nothing Then
                                    Dim catalogPredeterminado = objEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault

                                    If catalogPredeterminado IsNot Nothing Then
                                        usercontrol.GridCompra.Table.Records(0).SetValue("cboPrecios", catalogPredeterminado.idCatalogo)
                                    Else
                                        usercontrol.GridCompra.Table.Records(0).SetValue("cboPrecios", objEQ.detalleitemequivalencia_catalogos.FirstOrDefault.idCatalogo)
                                    End If

                                    usercontrol.GridCompra.Table.Records(0).SetCurrent("descripcion")
                                    TextFiltrar.Clear()
                                    TextFiltrar.Select()
                                    'Me.GridTotales.TableControl.CurrentCell.ShowDropDown()
                                End If

                                '-----------------------------------------------------------------------------------------------------------------------------------------------
                                '-----------------------------------------------------------------------------------------------------------------------------------------------

                                If CatalogoPrecio.ToString.Trim.Length = 0 Then
                                    MessageBox.Show("Debe ingresar un catalogo de precios valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If

                                Dim idProducto = Me.usercontrol.GridCompra.Table.Records(0).GetValue("idItem")
                                Dim precioVenta = 0 ' CDec(GridTotales.Table.CurrentRecord.GetValue("importeMn")) 'CDec(GridTotales.TableModel(e.Inner.RowIndex, 8).CellValue)
                                Dim inp = 1 'InputBox("Ingreser cantidad", "Atención", "")
                                '   If inp IsNot Nothing Then
                                If IsNumeric(inp) Then
                                    If (inp) > 0 Then

                                        Dim precioventaFormula = GetCalculoPrecioVenta(CDec(inp), idProducto, equivalencia, CatalogoPrecio)
                                        precioVenta = precioventaFormula

                                        AgregarProductoDetalleVenta(inp, idProducto, precioventaFormula, objEQ, CatalogoPrecio)
                                        LoadCanastaVentas(ListaproductosVendidos)
                                        PictureLoadingProduct.Visible = False
                                        'Me.usercontrol.GridTotales.Table.Records(0).SetCurrent("descripcion")
                                        'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Focus()
                                        'UCEstructuraCabeceraVenta.FormPurchase.ToolStrip1.Select()
                                    Else
                                        MessageBox.Show("Debe ingresar un cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Debe ingresar un cantidad válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            ElseIf listaProductos.Count >= 2 Then
                                popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                                PictureLoadingProduct.Visible = False

                                'Dim rec As GridRecord = Me.usercontrol.GridTotales.Table.Records(1)
                                'rec.SetCurrent("descripcion")
                                'usercontrol.GridTotales.Focus()

                                Dim colIndex As Integer = Me.usercontrol.GridCompra.TableDescriptor.FieldToColIndex(0)
                                Dim rowIndex As Integer = Me.usercontrol.GridCompra.Table.Records(0).GetRowIndex()
                                Me.usercontrol.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                            ElseIf listaProductos.Count <= 0 Then
                                PictureLoadingProduct.Visible = False
                                MessageBox.Show("El código ingresado no se encuentra en la base de datos de productos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                TextFiltrar.Clear()
                                TextFiltrar.Select()
                            End If


                        Case "PRODUCTO"


                            If combotipoalmacen.Text = "TODOS" Then
                                BuscarProducto("NOMBRE")
                            Else
                                BuscarProductoxAlmacen("NOMBRE", combotipoalmacen.SelectedValue)
                            End If

                            If listaProductos.Count > 0 Then
                                popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                                PictureLoadingProduct.Visible = False

                                'Dim rec As GridRecord = Me.usercontrol.GridTotales.Table.Records(1)
                                'rec.SetCurrent("descripcion")
                                'usercontrol.GridTotales.Focus()

                                Dim colIndex As Integer = Me.usercontrol.GridCompra.TableDescriptor.FieldToColIndex(0)
                                Dim rowIndex As Integer = Me.usercontrol.GridCompra.Table.Records(0).GetRowIndex()
                                Me.usercontrol.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                                'Me.usercontrol.GridTotales.Focus()
                            Else

                                PictureLoadingProduct.Visible = False
                            End If
                        Case "SERVICIO"
                            PictureLoadingProduct.Visible = False
                    End Select
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
                If usercontrol.GridCompra.Table.Records.Count > 0 Then
                    popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                    Dim colIndex As Integer = Me.usercontrol.GridCompra.TableDescriptor.FieldToColIndex(0)
                    Dim rowIndex As Integer = Me.usercontrol.GridCompra.Table.Records(0).GetRowIndex()
                    Me.usercontrol.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
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

    Public Sub AgregarProductoDetalleCompra(rec As Record)
        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = Integer.Parse(rec.GetValue("idItem"))

        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        If producto IsNot Nothing Then
            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()
            obj.CodigoCosto = cod
            obj.idItem = producto.codigodetalle
            obj.CustomProducto = producto
            obj.monto1 = 1
            AddItemVentaDetalle(producto, obj)
            obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            'obj.CustomDocumentoCaja = New List(Of documentoCaja)
            ListaproductosVendidos.Add(obj)
            LoadCanastaVentas(ListaproductosVendidos)
        End If

        ' MsgBox(listViewItem.SubItems(1).Text)
    End Sub



    Public Sub AgregarProductoLoteDetalle(cantidad As Decimal, idProductoSel As Integer, precioventa As Decimal, eq As detalleitem_equivalencias, CatalogoPrecio As Integer, loteDet As Integer, idlote As Integer, detAdicional As String)
        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = idProductoSel
        Dim total As Decimal = 0
        Dim totalME As Decimal = 0

        Dim consulta = (From i In ListaproductosVendidos
                        Where i.idLoteDetalle = loteDet).Count

        If consulta > 0 Then

            MessageBox.Show("Este producto ya fue agregado ala canasta")
            Exit Sub
        End If


        Dim precioVentaValue As Decimal = precioventa
        Dim canti As Decimal = cantidad
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0

        Dim baseImponibleME As Decimal = 0
        Dim IvaME As Decimal = 0

        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault


        If cboMoneda.Text = "NUEVO SOL" Then
            Select Case producto.origenProducto
                Case "1"
                    total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                    baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = Math.Round(total - baseImponible, 2)

                    totalME = 0
                    baseImponibleME = 0
                    IvaME = 0
                Case Else
                    total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                    baseImponible = total ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = 0

                    totalME = 0
                    baseImponibleME = 0 ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    IvaME = 0
            End Select

        Else 'MONEDA EXTRANJERA
            totalME = Math.Round(canti * precioventa, 2)
            total = Math.Round(totalME * txtTipoCambio.DecimalValue, 2)

            Select Case producto.origenProducto
                Case "1"
                    baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = Math.Round(total - baseImponible, 2)

                    baseImponibleME = Math.Round(CDec(CalculoBaseImponible(totalME, 1.18)), 2)
                    IvaME = Math.Round(totalME - baseImponibleME, 2)
                Case Else

                    baseImponible = total ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = 0

                    baseImponibleME = totalME ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    IvaME = 0
            End Select
        End If


        'Select Case producto.origenProducto
        '    Case "1"
        '        total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
        '        baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
        '        Iva = Math.Round(total - baseImponible, 2)
        '    Case Else
        '        total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
        '        baseImponible = total ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
        '        Iva = 0
        'End Select


        If producto IsNot Nothing Then

            Dim catalogoOBJ = eq.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CatalogoPrecio).SingleOrDefault

            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()

            Select Case tmpConfigInicio.FormatoVenta
                Case "FACT"
                    obj.AfectoInventario = False
                Case Else
                    obj.AfectoInventario = producto.AfectoStock.GetValueOrDefault ' True
            End Select

            'obj.CodigoCosto = cod
            'obj.detalleAdicional = detAdicional
            'obj.idLote = idlote
            'obj.idLoteDetalle = loteDet
            'obj.ContenidoNetoUnidadComercialMaxima = eq.contenido
            'obj.idItem = producto.codigodetalle
            'obj.CustomProducto = producto
            'obj.CustomEquivalencia = eq
            'obj.CustomCatalogo = catalogoOBJ
            'obj.catalogo_id = catalogoOBJ.idCatalogo
            'obj.monto1 = cantidad
            'AddItemVentaDetalle(producto, obj)
            'obj.unidad2 = eq.detalle
            'obj.montokardex = baseImponible
            'obj.montoIgv = Iva
            'obj.importeMN = total
            'obj.PrecioUnitarioVentaMN = precioventa
            'obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            'obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            'obj.descuentoMN = 0
            'obj.tasaIcbper = producto.otroImpuesto
            'obj.montoIcbper = producto.otroImpuesto * cantidad

            'ListaproductosVendidos.Add(obj)





            obj.CodigoCosto = cod
            obj.detalleAdicional = detAdicional
            obj.idLote = idlote
            obj.idLoteDetalle = loteDet
            obj.ContenidoNetoUnidadComercialMaxima = eq.contenido_neto ' UnidadComercialMaxima.contenido ' UnidadComercialMaxima.fraccionUnidad
            obj.idItem = producto.codigodetalle
            obj.CustomProducto = producto
            obj.CustomEquivalencia = eq
            obj.CustomCatalogo = catalogoOBJ
            obj.catalogo_id = catalogoOBJ.idCatalogo
            obj.monto1 = cantidad
            AddItemVentaDetalle(producto, obj)
            obj.unidad2 = eq.detalle
            obj.montokardex = baseImponible
            obj.montokardexUS = baseImponibleME
            obj.montoIgv = Iva
            obj.montoIgvUS = IvaME
            obj.importeMN = total
            obj.importeME = totalME
            obj.PrecioUnitarioVentaMN = precioventa
            obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            obj.descuentoMN = 0
            obj.tasaIcbper = producto.otroImpuesto
            obj.montoIcbper = producto.otroImpuesto * cantidad
            'obj.CustomDocumentoCaja = New List(Of documentoCaja)
            ListaproductosVendidos.Add(obj)



            LoadCanastaVentas(ListaproductosVendidos)
            GetTotalesDocumento()

        End If

    End Sub


    Public Sub AgregarProductoDetalleVentaLote(CatalogoPrecio As Integer, cantidad As Decimal, idProductoSel As Integer, eq As detalleitem_equivalencias, stock As Decimal?, Optional lote As recursoCostoLote = Nothing)
        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = idProductoSel
        Dim total As Decimal = 0
        Dim totalME As Decimal = 0
        Dim canti As Decimal = cantidad
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0

        Dim baseImponibleME As Decimal = 0
        Dim IvaME As Decimal = 0


        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        total = 0

        baseImponible = 0
        Iva = 0

        If producto IsNot Nothing Then

            Dim catalogoOBJ = eq.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CatalogoPrecio).SingleOrDefault

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
            obj.CustomCatalogo = catalogoOBJ
            obj.catalogo_id = catalogoOBJ.idCatalogo
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
                obj.idLote = lote.codigoLote
                obj.Customlote = lote
            End If

            ListaproductosVendidos.Add(obj)

            LoadCanastaVentas(ListaproductosVendidos)

        End If

        ' MsgBox(listViewItem.SubItems(1).Text)
    End Sub


    Public Sub AgregarProductoDetalleVentaAlmacen(cantidad As Decimal, idProductoSel As Integer, precioventa As Decimal, eq As detalleitem_equivalencias, CatalogoPrecio As Integer, idAlmacen As Integer)
        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = idProductoSel
        Dim total As Decimal = 0
        Dim totalME As Decimal = 0

        'Dim precioVentaValue As Decimal = precioventa
        'Dim canti As Decimal = cantidad
        'Dim baseImponible As Decimal = 0
        'Dim Iva As Decimal = 0
        'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
        'Dim total As Decimal = sub_total * precioventa '  canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
        'baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
        'Iva = Math.Round(total - baseImponible, 2)

        Dim precioVentaValue As Decimal = precioventa
        Dim canti As Decimal = cantidad
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0

        Dim baseImponibleME As Decimal = 0
        Dim IvaME As Decimal = 0


        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        If cboMoneda.Text = "NUEVO SOL" Then
            Select Case producto.origenProducto
                Case "1"
                    total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                    baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = Math.Round(total - baseImponible, 2)

                    totalME = 0
                    baseImponibleME = 0
                    IvaME = 0
                Case Else
                    total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                    baseImponible = total ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = 0

                    totalME = 0
                    baseImponibleME = 0 ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    IvaME = 0
            End Select

        Else 'MONEDA EXTRANJERA
            totalME = Math.Round(canti * precioventa, 2)
            total = Math.Round(totalME * txtTipoCambio.DecimalValue, 2)

            Select Case producto.origenProducto
                Case "1"
                    baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = Math.Round(total - baseImponible, 2)

                    baseImponibleME = Math.Round(CDec(CalculoBaseImponible(totalME, 1.18)), 2)
                    IvaME = Math.Round(totalME - baseImponibleME, 2)
                Case Else

                    baseImponible = total ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = 0

                    baseImponibleME = totalME ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    IvaME = 0
            End Select
        End If

        'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault

        If producto IsNot Nothing Then
            'Dim listaUnidadesComerciales = producto.detalleitem_equivalencias.ToList
            'Dim UnidadComercialMaxima = listaUnidadesComerciales.Where(Function(o) o.flag = "MAX").SingleOrDefault

            Dim catalogoOBJ = eq.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CatalogoPrecio).SingleOrDefault

            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()

            If FormPurchase.CheckDistribucion.Checked = True Then
                obj.AfectoInventario = False
            Else
                Select Case tmpConfigInicio.FormatoVenta
                    Case "FACT"
                        obj.AfectoInventario = False
                        obj.estadoEntrega = EstadoTrasladoVenta.Pedido
                    Case Else
                        obj.AfectoInventario = producto.AfectoStock.GetValueOrDefault ' True
                        obj.estadoEntrega = EstadoTrasladoVenta.EntregaConExito
                End Select
            End If

            obj.CodigoCosto = cod
            obj.ContenidoNetoUnidadComercialMaxima = eq.contenido_neto ' UnidadComercialMaxima.contenido ' UnidadComercialMaxima.fraccionUnidad
            obj.idItem = producto.codigodetalle
            obj.CustomProducto = producto
            obj.CustomEquivalencia = eq
            obj.CustomCatalogo = catalogoOBJ
            obj.catalogo_id = catalogoOBJ.idCatalogo
            obj.monto1 = cantidad
            AddItemVentaDetalle(producto, obj)
            obj.unidad2 = eq.detalle
            obj.montokardex = baseImponible
            obj.montokardexUS = baseImponibleME
            obj.montoIgv = Iva
            obj.montoIgvUS = IvaME
            obj.importeMN = total
            obj.importeME = totalME
            obj.PrecioUnitarioVentaMN = precioventa
            obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            obj.descuentoMN = 0
            obj.tasaIcbper = producto.otroImpuesto
            obj.montoIcbper = producto.otroImpuesto * cantidad
            obj.idAlmacenOrigen = idAlmacen
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
            GetTotalesDocumento()

        End If

        ' MsgBox(listViewItem.SubItems(1).Text)
    End Sub



    Public Function AgregarProductoDetalleVentaPorAmarre(cantidad As Decimal, idProductoSel As Integer, precioventa As Decimal, eq As detalleitem_equivalencias, CatalogoPrecio As Integer) As documentoventaAbarrotesDet
        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = idProductoSel
        Dim total As Decimal = 0

        Dim precioVentaValue As Decimal = precioventa
        Dim canti As Decimal = cantidad
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0
        'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        Select Case producto.origenProducto
            Case "1"
                total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                Iva = Math.Round(total - baseImponible, 2)
            Case Else
                total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                baseImponible = total ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                Iva = 0
        End Select


        If producto IsNot Nothing Then
            Dim catalogoOBJ = eq.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CatalogoPrecio).SingleOrDefault

            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()

            Select Case tmpConfigInicio.FormatoVenta
                Case "FACT"
                    obj.AfectoInventario = False
                Case Else
                    obj.AfectoInventario = producto.AfectoStock.GetValueOrDefault ' True
            End Select

            obj.CodigoCosto = cod
            obj.idItem = producto.codigodetalle
            obj.CustomProducto = producto
            obj.CustomEquivalencia = eq
            obj.CustomCatalogo = catalogoOBJ
            obj.catalogo_id = catalogoOBJ.idCatalogo
            obj.monto1 = cantidad
            AddItemVentaDetalle(producto, obj)
            obj.unidad2 = eq.detalle
            obj.montokardex = baseImponible
            obj.montoIgv = Iva
            obj.importeMN = total
            obj.PrecioUnitarioVentaMN = precioventa
            obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            obj.descuentoMN = 0
            obj.tasaIcbper = producto.otroImpuesto
            obj.montoIcbper = producto.otroImpuesto * cantidad
            'obj.CustomDocumentoCaja = New List(Of documentoCaja)
            'ListaproductosVendidos.Add(obj)
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
            AgregarProductoDetalleVentaPorAmarre = obj
            'LoadCanastaVentas(ListaproductosVendidos)
            'GetTotalesDocumento()

        End If

        ' MsgBox(listViewItem.SubItems(1).Text)
    End Function

    Public Sub AgregarBeneficioProductoDetalleVenta(cantidad As Decimal, idProductoSel As Integer, precioventa As Decimal, eq As detalleitem_equivalencias, CatalogoPrecio As Integer, beneficio As String, itemVenta As documentoventaAbarrotesDet)

        '  AgregarBeneficioProductoDetalleVenta = New List(Of documentoventaAbarrotesDet)

        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = idProductoSel
        Dim total As Decimal = 0

        'Dim precioVentaValue As Decimal = precioventa
        'Dim canti As Decimal = cantidad
        'Dim baseImponible As Decimal = 0
        'Dim Iva As Decimal = 0
        'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
        'Dim total As Decimal = sub_total * precioventa '  canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
        'baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
        'Iva = Math.Round(total - baseImponible, 2)

        Dim precioVentaValue As Decimal = precioventa
        Dim canti As Decimal = cantidad
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0
        'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        Select Case producto.origenProducto
            Case "1"
                total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                Iva = Math.Round(total - baseImponible, 2)
            Case Else
                total = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
                baseImponible = total ' Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                Iva = 0
        End Select

        If producto IsNot Nothing Then
            Dim catalogoOBJ = eq.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CatalogoPrecio).SingleOrDefault

            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()

            Select Case tmpConfigInicio.FormatoVenta
                Case "FACT"
                    obj.AfectoInventario = False
                Case Else
                    obj.AfectoInventario = producto.AfectoStock.GetValueOrDefault ' True
            End Select

            obj.CodigoCosto = cod
            obj.idItem = producto.codigodetalle
            obj.CustomProducto = producto
            obj.CustomEquivalencia = eq
            obj.CustomCatalogo = catalogoOBJ
            obj.catalogo_id = catalogoOBJ.idCatalogo
            obj.monto1 = cantidad
            AddItemVentaDetalle(producto, obj)
            obj.unidad2 = eq.detalle
            obj.montokardex = baseImponible
            obj.montoIgv = Iva
            obj.importeMN = total
            obj.PrecioUnitarioVentaMN = precioventa
            obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            obj.descuentoMN = 0
            obj.tasaIcbper = producto.otroImpuesto
            obj.montoIcbper = producto.otroImpuesto * cantidad
            obj.tipobeneficio = beneficio
            'obj.CustomDocumentoCaja = New List(Of documentoCaja)

            itemVenta.CustomListaVentaDetalle.Add(obj)

            ListaproductosVendidos.Add(obj)
            LoadCanastaVentas(ListaproductosVendidos)
            GetTotalesDocumento()
        End If

        ' MsgBox(listViewItem.SubItems(1).Text)
    End Sub

    Public Sub AgregarServicioDetalleVenta(cantidad As Decimal, idProductoSel As Integer, precioventa As Decimal)
        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = idProductoSel

        Dim precioVentaValue As Decimal = precioventa
        Dim canti As Decimal = cantidad
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0
        'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
        Dim total As Decimal = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
        baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
        Iva = Math.Round(total - baseImponible, 2)

        Dim producto As New detalleitems With {.codigodetalle = 1, .descripcionItem = TextFiltrar.Text.Trim, .unidad1 = "NIU", .tipoExistencia = TipoExistencia.ServicioGasto, .origenProducto = 1}
        If producto IsNot Nothing Then
            '   Dim catalogoOBJ = eq.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CatalogoPrecio).SingleOrDefault

            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()
            obj.CodigoCosto = cod
            obj.idItem = producto.codigodetalle
            obj.CustomProducto = producto
            obj.CustomEquivalencia = Nothing 'eq
            obj.CustomCatalogo = Nothing 'catalogoOBJ
            obj.catalogo_id = 0 'catalogoOBJ.idCatalogo
            obj.monto1 = cantidad
            AddItemVentaDetalle(producto, obj)
            obj.unidad2 = Nothing ' eq.detalle
            obj.montokardex = baseImponible
            obj.montoIgv = Iva
            obj.importeMN = total
            obj.PrecioUnitarioVentaMN = precioventa
            obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            'obj.CustomDocumentoCaja = New List(Of documentoCaja)
            obj.descuentoMN = 0
            ListaproductosVendidos.Add(obj)
            LoadCanastaVentas(ListaproductosVendidos)
            GetTotalesDocumento()
        End If

        ' MsgBox(listViewItem.SubItems(1).Text)
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
        'obj.estadoEntrega = "SI"
        obj.idCajaUsuario = 0
        obj.FlagBonif = "False"
        obj.usuarioModificacion = usuario.IDUsuario
        obj.fechaModificacion = Date.Now

    End Sub

    Private Function GetCalculoPrecioVenta(cantidadVenta As Decimal, CodigoFila As String, idEquivalencia As Integer, idCatalogo As String, rec As Record) As Decimal
        GetCalculoPrecioVenta = 0
        Dim objProducto = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = CodigoFila).SingleOrDefault

        If objProducto IsNot Nothing Then
            Dim listaEquivalencias = objProducto.CustomProducto.detalleitem_equivalencias.ToList

            Dim objEQ = listaEquivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

            Dim catalogoOBJ As detalleitemequivalencia_catalogos
            If IsNumeric(idCatalogo) Then
                catalogoOBJ = objEQ.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault
            Else
                catalogoOBJ = objEQ.detalleitemequivalencia_catalogos.Where(Function(c) c.nombre_corto = idCatalogo).SingleOrDefault
            End If


            If catalogoOBJ IsNot Nothing Then

                Dim ListaPrecios = catalogoOBJ.detalleitemequivalencia_precios.ToList
                Dim listaDeRangos = ConvertirPreciosArangos(ListaPrecios)

                If listaDeRangos.Count = 0 Or listaDeRangos Is Nothing Then
                    rec.SetValue("precioventa", 0)
                    GetCalculoItemV2(rec)
                    EditarItemVenta(rec)
                    Throw New Exception("El producto no tiene precios de venta asignados")
                End If

                Dim index = 0
                Dim ultimaPosicion = listaDeRangos.Count - 1

                For Each i In listaDeRangos
                    Dim rango_inicio = i.rango_inicio
                    Dim rango_fin = i.rango_final
                    If cantidadVenta >= rango_inicio AndAlso rango_fin = 0 Then

                        If FormPurchase.ComboComprobante.Text = "PRE VENTA" Then
                            Select Case cboMoneda.Text
                                Case "NUEVO SOL"
                                    'Corregido evaluar

                                    Dim HasCategory = False
                                    If objProducto.CustomProducto.idItem > 0 Then
                                        HasCategory = True
                                    End If

                                    If listaDeRangos.Count = 1 Then

                                        If HasCategory Then
                                            'NIVEL DE CATEGORIA

                                            Dim category = objProducto.CustomProducto.item
                                            Dim configuration = category.preciocompratipo
                                            Select Case configuration
                                                Case "NN"
                                                    Select Case objProducto.CustomProducto.preciocompratipo
                                                        Case "FJ"
                                                            GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        Case Else
                                                            Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent ' objProducto.CustomProducto.firstpercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                    End Select
                                                Case "PCT"
                                                    Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.CustomProducto.firstpercent


                                                    If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                        GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                    Else
                                                        GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                    End If
                                                Case "FJ"

                                            End Select
                                        Else
                                            'NIVEL DE PRODUCTO
                                            Select Case objProducto.CustomProducto.preciocompratipo
                                                Case "PCT"
                                                    Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                    If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                        Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                        GetCalculoPrecioVenta = result
                                                    Else
                                                        GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                    End If

                                                Case Else '"FJ"
                                                    GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                            End Select
                                        End If


                                        'mayor a una unidad comercial
                                    ElseIf listaDeRangos.Count > 1 Then

                                        If index = ultimaPosicion Then 'ultima fila

                                            If HasCategory Then
                                                'AFECTO A CATEGORIA
                                                Dim category = objProducto.CustomProducto.item
                                                Dim configuration = category.preciocompratipo
                                                Select Case configuration
                                                    Case "NN"
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "FJ"
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                            Case Else

                                                                Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent

                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If

                                                        End Select

                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.CustomProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                        Else
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        End If
                                                    Case "FJ"

                                                End Select


                                            Else
                                                'AFECTO A PRODCUTOS
                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                        Else
                                                            ' Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                        End If
                                                    Case Else
                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                End Select
                                            End If
                                        Else ' no es la ultima fila

                                            If HasCategory Then
                                                Dim category = objProducto.CustomProducto.item
                                                Dim configuration = category.preciocompratipo
                                                Select Case configuration
                                                    Case "NN"
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "FJ"
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)

                                                            Case Else
                                                                Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                        End Select


                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            ' Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            '    Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.CustomProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                        Else
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            '   Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.CustomProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        End If
                                                    Case "FJ"

                                                End Select

                                            Else
                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            '    Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                        Else
                                                            '   Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                        End If
                                                    Case Else
                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                End Select
                                            End If
                                        End If
                                    End If

                                Case Else
                                    'DOLARES

                                    If i.precioUSD.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                    End If
                            End Select
                        Else
                            Select Case cboMoneda.Text
                                Case "NUEVO SOL"
                                    Select Case ComboTerminosPago.Text
                                        Case "CONTADO"
                                            'If i.precio.GetValueOrDefault > 0 Then
                                            '    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                            'Else
                                            '    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                            'End If

                                            Dim HasCategory = False
                                            If objProducto.CustomProducto.idItem > 0 Then
                                                HasCategory = True
                                            End If

                                            'categoria

                                            If listaDeRangos.Count = 1 Then
                                                If HasCategory Then
                                                    Dim category = objProducto.CustomProducto.item
                                                    Dim configuration = category.preciocompratipo
                                                    Select Case configuration
                                                        Case "NN"
                                                            Select Case objProducto.CustomProducto.preciocompratipo
                                                                Case "FJ"
                                                                    GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                                Case Else
                                                                    Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                            End Select
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                            ' GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case "FJ"

                                                    End Select
                                                Else
                                                    'NIVEL DE PRODUCTO
                                                    Select Case objProducto.CustomProducto.preciocompratipo
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                GetCalculoPrecioVenta = result
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If


                                                        Case Else '"FJ"
                                                            GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                    End Select
                                                End If

                                            ElseIf listaDeRangos.Count > 1 Then
                                                If index = ultimaPosicion Then 'ultima posicion ++

                                                    If HasCategory Then

                                                        Dim category = objProducto.CustomProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                            ' Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                            ' Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If

                                                                End Select

                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then

                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent '
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    '   Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select

                                                    Else
                                                        'AFECTO A PRODCUTOS
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        End Select
                                                    End If

                                                Else ' no es la ultima posicion
                                                    If HasCategory Then
                                                        Dim category = objProducto.CustomProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)

                                                                    Case Else
                                                                        Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                            '   Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            '  Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                        End If
                                                                End Select


                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select
                                                    Else
                                                        Select Case objProducto.CustomProducto.preciocompratipo

                                                            Case "PCT"
                                                                Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    '  Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    ' Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        End Select
                                                    End If
                                                End If
                                            End If


                                        Case "CREDITO"

                                            Dim HasCategory = False
                                            If objProducto.CustomProducto.idItem > 0 Then
                                                HasCategory = True
                                            End If

                                            If listaDeRangos.Count = 1 Then 'unidad principal
                                                If HasCategory Then
                                                    Dim category = objProducto.CustomProducto.item
                                                    Dim configuration = category.preciocompratipo
                                                    Select Case configuration
                                                        Case "NN"
                                                            Select Case objProducto.CustomProducto.preciocompratipo
                                                                Case "FJ"
                                                                    GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                                Case Else
                                                                    Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                            End Select
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.CustomProducto.firstpercent
                                                            '   GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)


                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case "FJ"

                                                    End Select
                                                Else
                                                    'NIVEL DE PRODUCTO
                                                    Select Case objProducto.CustomProducto.preciocompratipo
                                                        Case "PCT"
                                                            Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                            '  Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                            '  GetCalculoPrecioVenta = result

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                GetCalculoPrecioVenta = result
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                            End If
                                                        Case Else '"FJ"
                                                            GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                    End Select
                                                End If

                                            ElseIf listaDeRangos.Count > 1 Then
                                                If index = ultimaPosicion Then 'ultima posicion
                                                    If HasCategory Then

                                                        Dim category = objProducto.CustomProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                                    Case Else
                                                                        Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                            '  Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            ' Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                        End If

                                                                End Select

                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.beforepercent '
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select

                                                    Else
                                                        'AFECTO A PRODCUTOS
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                        End Select
                                                    End If

                                                Else ' no es la ultima posicion
                                                    If HasCategory Then
                                                        Dim category = objProducto.CustomProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)

                                                                    Case Else
                                                                        Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                        End If
                                                                End Select


                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select
                                                    Else
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, porcentaje)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, porcentaje)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                        End Select
                                                    End If
                                                End If
                                            End If

                                    End Select
                                    '   End Select
                                Case Else
                                    'DOLARES
                                    Select Case ComboTerminosPago.Text
                                        Case "CONTADO"
                                            If i.precioUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                            End If

                                        Case "CREDITO"
                                            If i.precioCreditoUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
                                            End If
                                    End Select

                            End Select
                        End If
                        Exit Function
                    End If
                    If cantidadVenta >= rango_inicio AndAlso cantidadVenta <= rango_fin Then
                        If FormPurchase.ComboComprobante.Text = "PRE VENTA" Then
                            Select Case cboMoneda.Text
                                Case "NUEVO SOL"
                                    'If i.precio.GetValueOrDefault > 0 Then
                                    '    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                    'Else
                                    '    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                    'End If

                                    Dim HasCategory = False
                                    If objProducto.CustomProducto.idItem > 0 Then
                                        HasCategory = True
                                    End If

                                    If listaDeRangos.Count = 1 Then
                                        If HasCategory Then
                                            Dim category = objProducto.CustomProducto.item
                                            Dim configuration = category.preciocompratipo
                                            Select Case configuration
                                                Case "NN"
                                                    Select Case objProducto.CustomProducto.preciocompratipo
                                                        Case "FJ"
                                                            GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        Case Else
                                                            Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                    End Select
                                                Case "PCT"
                                                    Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                    ' GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)


                                                    If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                        GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                    Else
                                                        GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                    End If
                                                Case "FJ"

                                            End Select
                                        Else
                                            'NIVEL DE PRODUCTO
                                            Select Case objProducto.CustomProducto.preciocompratipo
                                                Case "PCT"
                                                    Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                    'Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                    'GetCalculoPrecioVenta = result

                                                    If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                        Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                        GetCalculoPrecioVenta = result
                                                    Else
                                                        GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                    End If
                                                Case Else '"FJ"
                                                    GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                            End Select
                                        End If

                                    ElseIf listaDeRangos.Count > 1 Then
                                        If index = ultimaPosicion Then 'ultima posicion

                                            If HasCategory Then

                                                Dim category = objProducto.CustomProducto.item
                                                Dim configuration = category.preciocompratipo
                                                Select Case configuration
                                                    Case "NN"
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "FJ"
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                            Case Else
                                                                Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If

                                                        End Select

                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.CustomProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                        Else
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        End If
                                                    Case "FJ"

                                                End Select

                                            Else
                                                'AFECTO A PRODCUTOS
                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            ' Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                        Else
                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                        End If
                                                    Case Else
                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                End Select
                                            End If

                                        Else 'no es la ultima fila
                                            If HasCategory Then
                                                Dim category = objProducto.CustomProducto.item
                                                Dim configuration = category.preciocompratipo
                                                Select Case configuration
                                                    Case "NN"
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "FJ"
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)

                                                            Case Else
                                                                Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                        End Select


                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            'Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.CustomProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                        Else
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.CustomProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                        End If
                                                    Case "FJ"

                                                End Select
                                            Else
                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                    Case "PCT"
                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            GetCalculoPrecioVenta = result
                                                        Else
                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                        End If
                                                    Case Else
                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                End Select
                                            End If
                                        End If
                                    End If


                                Case Else
                                    'DOLARES

                                    If i.precioUSD.GetValueOrDefault > 0 Then
                                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                    Else
                                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                    End If
                            End Select
                        Else
                            Select Case cboMoneda.Text
                                Case "NUEVO SOL"
                                    Select Case ComboTerminosPago.Text
                                        Case "CONTADO"
                                            'If i.precio.GetValueOrDefault > 0 Then
                                            '    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                            'Else
                                            '    GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                                            'End If
                                            Dim HasCategory = False
                                            If objProducto.CustomProducto.idItem > 0 Then
                                                HasCategory = True
                                            End If

                                            If listaDeRangos.Count = 1 Then
                                                If HasCategory Then
                                                    Dim category = objProducto.CustomProducto.item
                                                    Dim configuration = category.preciocompratipo
                                                    Select Case configuration
                                                        Case "NN"
                                                            Select Case objProducto.CustomProducto.preciocompratipo
                                                                Case "FJ"
                                                                    GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                                Case Else
                                                                    Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                            End Select
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                            '   GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case "FJ"

                                                    End Select
                                                Else
                                                    'NIVEL DE PRODUCTO
                                                    Select Case objProducto.CustomProducto.preciocompratipo
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            'Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            'GetCalculoPrecioVenta = result

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                GetCalculoPrecioVenta = result
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case Else '"FJ"
                                                            GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                    End Select
                                                End If

                                            ElseIf listaDeRangos.Count > 1 Then
                                                If index = ultimaPosicion Then 'ultima pisicion

                                                    If HasCategory Then

                                                        Dim category = objProducto.CustomProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If

                                                                End Select

                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select

                                                    Else
                                                        'AFECTO A PRODCUTOS
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    '  Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    ' Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        End Select
                                                    End If

                                                Else ' no es la ultima fila
                                                    If HasCategory Then
                                                        Dim category = objProducto.CustomProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)

                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If
                                                                End Select


                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = category.beforepercent 'objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select
                                                    Else
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                        End Select
                                                    End If
                                                End If
                                            End If

                                          '  End Select


                                        Case "CREDITO"
                                            'If i.precioCredito.GetValueOrDefault > 0 Then
                                            '    GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                                            'Else
                                            '    GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
                                            'End If
                                            Dim HasCategory = False
                                            If objProducto.CustomProducto.idItem > 0 Then
                                                HasCategory = True
                                            End If


                                            If listaDeRangos.Count = 1 Then
                                                If HasCategory Then
                                                    Dim category = objProducto.CustomProducto.item
                                                    Dim configuration = category.preciocompratipo
                                                    Select Case configuration
                                                        Case "NN"
                                                            Select Case objProducto.CustomProducto.preciocompratipo
                                                                Case "FJ"
                                                                    GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                                Case Else
                                                                    Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                            End Select
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = category.firstpercent ' objProducto.CustomProducto.firstpercent
                                                            ' GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case "FJ"

                                                    End Select
                                                Else
                                                    'NIVEL DE PRODUCTO
                                                    Select Case objProducto.CustomProducto.preciocompratipo
                                                        Case "PCT"
                                                            Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                            'Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                            'GetCalculoPrecioVenta = result

                                                            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                GetCalculoPrecioVenta = result
                                                            Else
                                                                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                            End If
                                                        Case Else '"FJ"
                                                            GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                    End Select
                                                End If

                                            ElseIf listaDeRangos.Count > 1 Then
                                                If index = ultimaPosicion Then 'ultima posicion
                                                    If HasCategory Then

                                                        Dim category = objProducto.CustomProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                            '     Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            '    Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If

                                                                End Select

                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    '  Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    ' Dim PocentajeUtilidad As Decimal = category.firstpercent 'objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select

                                                    Else
                                                        'AFECTO A PRODCUTOS
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.firstpercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                        End Select
                                                    End If

                                                Else ' no es la ultima fila
                                                    If HasCategory Then
                                                        Dim category = objProducto.CustomProducto.item
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)

                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                        If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                            'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                            GetCalculoPrecioVenta = result
                                                                        Else
                                                                            'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                            GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                        End If
                                                                End Select


                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    ' Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    ' Dim PocentajeUtilidad As Decimal = category.beforepercent ' objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select
                                                    Else
                                                        Select Case objProducto.CustomProducto.preciocompratipo
                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent
                                                                    'Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.beforepercent
                                                                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto, PocentajeUtilidad)
                                                                    GetCalculoPrecioVenta = result
                                                                Else
                                                                    'Dim porcentaje As Decimal = objProducto.CustomProducto.beforepercent
                                                                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                            Case Else
                                                                GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                                        End Select
                                                    End If
                                                End If
                                            End If

                                    End Select
                                Case Else
                                    'DOLARES -----------------

                                    Select Case ComboTerminosPago.Text
                                        Case "CONTADO"
                                            If i.precioUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                                            End If

                                            'Select Case objProducto.CustomProducto.preciocompratipo
                                            '    Case "FJ"
                                            '        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                            '    Case Else

                                            '        If objProducto.CustomProducto.detalleitem_equivalencias.Count = 1 Then
                                            '            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '            GetCalculoPrecioVenta = result

                                            '        ElseIf objProducto.CustomProducto.detalleitem_equivalencias.Count > 1 Then
                                            '            If objEQ.flag = "MAX" Or objEQ.flag = "SOLO"  Then
                                            '                Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '                GetCalculoPrecioVenta = result
                                            '            Else
                                            '                GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto)
                                            '            End If
                                            '        End If

                                            'End Select


                                        Case "CREDITO"
                                            If i.precioCreditoUSD.GetValueOrDefault > 0 Then
                                                GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
                                            Else
                                                GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
                                            End If

                                            'Select Case objProducto.CustomProducto.preciocompratipo
                                            '    Case "FJ"
                                            '        GetCalculoPrecioVenta = GetPrecioCreditoFijo(i)
                                            '    Case Else

                                            '        If listaDeRangos.Count = 1 Then
                                            '            Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '            GetCalculoPrecioVenta = result

                                            '        ElseIf listaDeRangos.Count > 1 Then
                                            '            If index = ultimaPosicion Then 'posi
                                            '                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO"  Then
                                            '                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '                    GetCalculoPrecioVenta = result
                                            '                Else
                                            '                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto)
                                            '                End If
                                            '            Else
                                            '                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO"  Then
                                            '                    Dim result As Decimal? = GetPrecioUnidadComercialMax(objProducto)
                                            '                    GetCalculoPrecioVenta = result
                                            '                Else
                                            '                    GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto)
                                            '                End If
                                            '            End If
                                            '        End If

                                            'End Select

                                    End Select
                            End Select
                        End If
                        'Select Case ComboTerminosPago.Text
                        '    Case "CONTADO"
                        '        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                        '    Case "CREDITO"
                        '        GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                        'End Select
                        Exit Function
                    End If
                    index = index + 1
                Next
            Else
                rec.SetValue("precioventa", 0)
                GetCalculoItemV2(rec)
                EditarItemVenta(rec)
                Throw New Exception("Debe configurar los catálogos de precios!")
            End If
        End If
    End Function

    Private Shared Function GetPrecioCreditoFijo(i As detalleitemequivalencia_precios) As Decimal
        Dim GetCalculoPrecioVenta As Decimal

        If i.precioCredito.GetValueOrDefault > 0 Then
            GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
        Else
            GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
        End If

        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPriceProductUniCategoryMIN(objProducto As documentoventaAbarrotesDet, category As item, PocentajeUtilidad As Decimal) As Decimal
        Dim GetCalculoPrecioVenta As Decimal
        Dim eqprec = objProducto.CustomProducto.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
        Dim valorUnitarioItem = objProducto.CustomProducto.precioCompra / eqprec.contenido_neto
        '   Dim firstPercent = objProducto.CustomProducto.firstpercent
        'Dim precioCompra = category.precioCompra
        Dim result = valorUnitarioItem * (PocentajeUtilidad / 100)
        result = result + valorUnitarioItem
        GetCalculoPrecioVenta = result
        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPriceProductUnidMIN(objProducto As documentoventaAbarrotesDet, porcentaje As Decimal) As Decimal
        Dim GetCalculoPrecioVenta As Decimal
        Dim eqprec = objProducto.CustomProducto.detalleitem_equivalencias.Where(Function(e) e.flag = "MAX").SingleOrDefault
        Dim valorUnitarioItem = objProducto.CustomProducto.precioCompra / eqprec.contenido_neto
        '   Dim firstPercent = objProducto.CustomProducto.firstpercent
        Dim precioCompra = objProducto.CustomProducto.precioCompra
        Dim result = valorUnitarioItem * (porcentaje / 100)
        result = result + valorUnitarioItem
        GetCalculoPrecioVenta = result
        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPriceCategoryMax(category As item, PocentajeUtilidad As Decimal, precioCompra As Decimal) As Decimal
        Dim GetCalculoPrecioVenta As Decimal
        'Dim firstPercent = objProducto.CustomProducto.firstpercent
        ' Dim precioCompra = category.precioCompra
        Dim result = precioCompra * (PocentajeUtilidad / 100)
        result = result + precioCompra
        GetCalculoPrecioVenta = result
        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPrecioFijo1(i As detalleitemequivalencia_precios) As Decimal
        Dim GetCalculoPrecioVenta As Decimal

        If i.precio.GetValueOrDefault > 0 Then
            GetCalculoPrecioVenta = i.precio.GetValueOrDefault
        Else
            GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
        End If

        Return GetCalculoPrecioVenta
    End Function

    Private Shared Function GetPrecioUnidadComercialMax(objProducto As documentoventaAbarrotesDet, porcentaje As Decimal) As Decimal?
        ' Dim firstPercent = objProducto.CustomProducto.firstpercent
        Dim precioCompra = objProducto.CustomProducto.precioCompra
        Dim result = precioCompra * (porcentaje / 100)
        result = result + precioCompra
        Return result
    End Function

    Private Function GetCalculoPrecioVenta(cantidadVenta As Decimal, idProducto As Integer, idEquivalencia As Integer, idCatalogo As Integer) As Decimal
        GetCalculoPrecioVenta = 0
        Dim objProducto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

        If objProducto IsNot Nothing Then
            Dim listaEquivalencias = objProducto.detalleitem_equivalencias.ToList

            Dim objEQ = listaEquivalencias.Where(Function(e) e.equivalencia_id = idEquivalencia).SingleOrDefault

            Dim catalogoOBJ = objEQ.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = idCatalogo).SingleOrDefault

            If catalogoOBJ IsNot Nothing Then



                Dim ListaPrecios = catalogoOBJ.detalleitemequivalencia_precios.ToList
                Dim listaDeRangos = ConvertirPreciosArangos(ListaPrecios)

                If listaDeRangos.Count = 0 Or listaDeRangos Is Nothing Then
                    Throw New Exception("El producto no tiene precios de venta asignados")
                End If

                For Each i In listaDeRangos
                    Dim rango_inicio = i.rango_inicio
                    Dim rango_fin = i.rango_final
                    If cantidadVenta >= rango_inicio AndAlso rango_fin = 0 Then
                        'Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                        '    Case "CONTADO"
                        '        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                        '    Case "CREDITO"
                        '        GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                        'End Select

                        If FormPurchase.ComboComprobante.Text = "PRE VENTA" Then
                            GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                        Else
                            Select Case ComboTerminosPago.Text
                                Case "CONTADO"
                                    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                Case "CREDITO"
                                    GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                            End Select
                        End If
                        Exit Function
                    End If
                    If cantidadVenta >= rango_inicio AndAlso cantidadVenta <= rango_fin Then
                        If FormPurchase.ComboComprobante.Text = "PRE VENTA" Then
                            GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                        Else
                            Select Case ComboTerminosPago.Text
                                Case "CONTADO"
                                    GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                                Case "CREDITO"
                                    GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                            End Select
                        End If
                        Exit Function
                    End If
                Next
            Else
                Throw New Exception("Debe configurar los catálogos de precios!")
            End If
        End If
    End Function
    Private Function AddItemNuevaListaPrecios(be As detalleitemequivalencia_precios, rangoMinimo As Decimal?, max As Decimal) As detalleitemequivalencia_precios

        AddItemNuevaListaPrecios = New detalleitemequivalencia_precios
        AddItemNuevaListaPrecios = be
        AddItemNuevaListaPrecios.rango_inicio = rangoMinimo
        AddItemNuevaListaPrecios.rango_final = max
    End Function

    Private Function ConvertirPreciosArangos(lista As List(Of detalleitemequivalencia_precios)) As List(Of detalleitemequivalencia_precios)
        '   Dim ListaEntera = GetConverToListInteger(lista)

        ConvertirPreciosArangos = New List(Of detalleitemequivalencia_precios)

        Dim maxValor = lista.Max(Function(o) o.rango_inicio).GetValueOrDefault
        Dim max As Decimal = 0
        For index = 0 To lista.Count - 1
            Dim rangoMinimo = lista(index).rango_inicio
            If rangoMinimo = maxValor Then
                max = 0
            Else
                Dim max1 = lista(index + 1).rango_inicio.GetValueOrDefault
                If max1 <= 1 Then
                    max = lista(index + 1).rango_inicio.GetValueOrDefault - 0.01
                Else
                    max = lista(index + 1).rango_inicio.GetValueOrDefault - 1
                End If
            End If
            ConvertirPreciosArangos.Add(AddItemNuevaListaPrecios(lista(index), rangoMinimo, max))
        Next
    End Function


    Private Function GetCalculoDescuento(ImporteVenta As Decimal, rec As Record, lista As List(Of detalleitemequivalencia_beneficio)) As Decimal
        GetCalculoDescuento = 0

        ' If catalogoOBJ IsNot Nothing Then

        Dim listaDeRangos = ConvertirDsctosArangos(lista)

        If listaDeRangos.Count = 0 Or listaDeRangos Is Nothing Then
            rec.SetValue("descuentoMN", 0)
            GetCalculoItemV2(rec)
            EditarItemVenta(rec)
            Throw New Exception("El producto no tiene precios de venta asignados")
        End If

        For Each i In listaDeRangos
            Dim rango_inicio = i.valor_evaluado
            Dim rango_fin = i.rango_final
            If ImporteVenta >= rango_inicio AndAlso rango_fin = 0 Then

                Select Case i.valor_conversion
                    Case "VALOR UNICO"
                        'descuentoFinal = importeventa - ben.valor_beneficio
                        If i.valor_beneficio > 0 Then
                            ' Dim cantActualizada As Decimal? = descuentoFinal ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                            GetCalculoDescuento = i.valor_beneficio
                            rec.SetValue("descuentoMN", GetCalculoDescuento)
                            GetCalculoItemV2(rec)
                            EditarItemVenta(rec)
                        End If
                    Case "PORCENTAJE"
                        Dim valorPorcentajeDscto As Decimal = 0
                        valorPorcentajeDscto = ImporteVenta * (i.valor_beneficio / 100)

                        If i.valor_beneficio > 0 Then
                            ' Dim cantActualizada As Decimal? = descuentoFinal ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                            GetCalculoDescuento = valorPorcentajeDscto
                            rec.SetValue("descuentoMN", GetCalculoDescuento)
                            GetCalculoItemV2(rec)
                            EditarItemVenta(rec)
                        End If
                End Select
                Exit Function



                'If FormPurchase.ComboComprobante.Text = "PRE VENTA" Then
                '    Select Case cboMoneda.Text
                '        Case "NUEVO SOL"
                '            If i.precio.GetValueOrDefault > 0 Then
                '                GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                '            Else
                '                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                '            End If

                '        Case Else
                '            'DOLARES

                '            If i.precioUSD.GetValueOrDefault > 0 Then
                '                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                '            Else
                '                GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                '            End If
                '    End Select
                'Else
                '    Select Case cboMoneda.Text
                '        Case "NUEVO SOL"
                '            Select Case ComboTerminosPago.Text
                '                Case "CONTADO"
                '                    If i.precio.GetValueOrDefault > 0 Then
                '                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                '                    Else
                '                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                '                    End If

                '                Case "CREDITO"
                '                    If i.precioCredito.GetValueOrDefault > 0 Then
                '                        GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                '                    Else
                '                        GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
                '                    End If
                '            End Select
                '        Case Else
                '            'DOLARES
                '            Select Case ComboTerminosPago.Text
                '                Case "CONTADO"
                '                    If i.precioUSD.GetValueOrDefault > 0 Then
                '                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                '                    Else
                '                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                '                    End If

                '                Case "CREDITO"
                '                    If i.precioCreditoUSD.GetValueOrDefault > 0 Then
                '                        GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
                '                    Else
                '                        GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
                '                    End If
                '            End Select

                '    End Select
                'End If

            End If
            If ImporteVenta >= rango_inicio AndAlso ImporteVenta <= rango_fin Then
                'If FormPurchase.ComboComprobante.Text = "PRE VENTA" Then
                '    Select Case cboMoneda.Text
                '        Case "NUEVO SOL"
                '            If i.precio.GetValueOrDefault > 0 Then
                '                GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                '            Else
                '                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                '            End If
                '        Case Else
                '            'DOLARES

                '            If i.precioUSD.GetValueOrDefault > 0 Then
                '                GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                '            Else
                '                GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                '            End If
                '    End Select
                'Else
                '    Select Case cboMoneda.Text
                '        Case "NUEVO SOL"
                '            Select Case ComboTerminosPago.Text
                '                Case "CONTADO"
                '                    If i.precio.GetValueOrDefault > 0 Then
                '                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                '                    Else
                '                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault * TmpTipoCambio
                '                    End If

                '                Case "CREDITO"
                '                    If i.precioCredito.GetValueOrDefault > 0 Then
                '                        GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                '                    Else
                '                        GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault * TmpTipoCambio
                '                    End If

                '            End Select
                '        Case Else
                '            'DOLARES -----------------

                '            Select Case ComboTerminosPago.Text
                '                Case "CONTADO"
                '                    If i.precioUSD.GetValueOrDefault > 0 Then
                '                        GetCalculoPrecioVenta = i.precioUSD.GetValueOrDefault
                '                    Else
                '                        GetCalculoPrecioVenta = i.precio.GetValueOrDefault / TmpTipoCambio
                '                    End If

                '                Case "CREDITO"
                '                    If i.precioCreditoUSD.GetValueOrDefault > 0 Then
                '                        GetCalculoPrecioVenta = i.precioCreditoUSD.GetValueOrDefault
                '                    Else
                '                        GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault / TmpTipoCambio
                '                    End If

                '            End Select
                '    End Select
                'End If
                'GetCalculoDescuento = i.valor_beneficio
                'rec.SetValue("descuentoMN", GetCalculoDescuento)
                'GetCalculoItemV2(rec)
                'EditarItemVenta(rec)
                Select Case i.valor_conversion
                    Case "VALOR UNICO"
                        'descuentoFinal = importeventa - ben.valor_beneficio
                        If i.valor_beneficio > 0 Then
                            ' Dim cantActualizada As Decimal? = descuentoFinal ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                            GetCalculoDescuento = i.valor_beneficio
                            rec.SetValue("descuentoMN", GetCalculoDescuento)
                            GetCalculoItemV2(rec)
                            EditarItemVenta(rec)
                        End If
                    Case "PORCENTAJE"
                        Dim valorPorcentajeDscto As Decimal = 0
                        valorPorcentajeDscto = ImporteVenta * (i.valor_beneficio / 100)

                        If i.valor_beneficio > 0 Then
                            ' Dim cantActualizada As Decimal? = descuentoFinal ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                            GetCalculoDescuento = valorPorcentajeDscto
                            rec.SetValue("descuentoMN", GetCalculoDescuento)
                            GetCalculoItemV2(rec)
                            EditarItemVenta(rec)
                        End If
                End Select
                Exit Function
            End If
        Next
        'Else
        '    rec.SetValue("precioventa", 0)
        '    GetCalculoItem(rec)
        '    EditarItemVenta(rec)
        '    Throw New Exception("Debe configurar los catálogos de precios!")
        'End If

    End Function


    Public Function ConvertirDsctosArangosVolumen(listaEval As List(Of detalleitemequivalencia_beneficio)) As List(Of detalleitemequivalencia_beneficio)
        '   Dim ListaEntera = GetConverToListInteger(lista)

        ConvertirDsctosArangosVolumen = New List(Of detalleitemequivalencia_beneficio)
        Dim lista = listaEval.Where(Function(o) o.aplica = "2" And o.tipoafectacion = "CANTIDAD").ToList

        Dim maxValor = lista.Max(Function(o) o.valor_evaluado).GetValueOrDefault
        Dim max As Decimal = 0
        For index = 0 To lista.Count - 1
            Dim rangoMinimo = lista(index).valor_evaluado
            If rangoMinimo = maxValor Then
                max = 0
            Else
                Dim max1 = lista(index + 1).valor_evaluado.GetValueOrDefault
                If max1 <= 1 Then
                    max = lista(index + 1).valor_evaluado.GetValueOrDefault - 0.01
                Else
                    max = lista(index + 1).valor_evaluado.GetValueOrDefault - 1
                End If
            End If
            ConvertirDsctosArangosVolumen.Add(AddItemNuevaListaDescuentos(lista(index), rangoMinimo, max))
        Next
    End Function

    Private Function GetCalculoDescuentoVolumen(CantidadVenta As Decimal, rec As Record, lista As List(Of detalleitemequivalencia_beneficio), Optional importeVenta As Decimal = 0) As Decimal
        GetCalculoDescuentoVolumen = 0

        Dim listaDeRangos = ConvertirDsctosArangosVolumen(lista)

        If listaDeRangos.Count = 0 Or listaDeRangos Is Nothing Then
            rec.SetValue("descuentoMN", 0)
            GetCalculoItemV2(rec)
            EditarItemVenta(rec)
            Throw New Exception("El producto no tiene precios de venta asignados")
        End If

        For Each i In listaDeRangos
            Dim rango_inicio = i.valor_evaluado
            Dim rango_fin = i.rango_final
            If CantidadVenta >= rango_inicio AndAlso rango_fin = 0 Then

                Select Case i.valor_conversion
                    Case "VALOR UNICO"
                        'descuentoFinal = importeventa - ben.valor_beneficio
                        If i.valor_beneficio > 0 Then
                            ' Dim cantActualizada As Decimal? = descuentoFinal ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                            GetCalculoDescuentoVolumen = i.valor_beneficio
                            rec.SetValue("descuentoMN", GetCalculoDescuentoVolumen)
                            GetCalculoItemV2(rec)
                            EditarItemVenta(rec)
                        End If
                    Case "PORCENTAJE"
                        Dim valorPorcentajeDscto As Decimal = 0
                        valorPorcentajeDscto = importeVenta * (i.valor_beneficio / 100)

                        If i.valor_beneficio > 0 Then
                            ' Dim cantActualizada As Decimal? = descuentoFinal ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                            GetCalculoDescuentoVolumen = valorPorcentajeDscto
                            rec.SetValue("descuentoMN", GetCalculoDescuentoVolumen)
                            GetCalculoItemV2(rec)
                            EditarItemVenta(rec)
                        End If
                End Select
                Exit Function

            End If
            If CantidadVenta >= rango_inicio AndAlso CantidadVenta <= rango_fin Then

                Select Case i.valor_conversion
                    Case "VALOR UNICO"
                        'descuentoFinal = importeventa - ben.valor_beneficio
                        If i.valor_beneficio > 0 Then
                            ' Dim cantActualizada As Decimal? = descuentoFinal ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                            GetCalculoDescuentoVolumen = i.valor_beneficio
                            rec.SetValue("descuentoMN", GetCalculoDescuentoVolumen)
                            GetCalculoItemV2(rec)
                            EditarItemVenta(rec)
                        End If
                    Case "PORCENTAJE"
                        Dim valorPorcentajeDscto As Decimal = 0
                        valorPorcentajeDscto = importeVenta * (i.valor_beneficio / 100)

                        If i.valor_beneficio > 0 Then
                            ' Dim cantActualizada As Decimal? = descuentoFinal ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                            GetCalculoDescuentoVolumen = valorPorcentajeDscto
                            rec.SetValue("descuentoMN", GetCalculoDescuentoVolumen)
                            GetCalculoItemV2(rec)
                            EditarItemVenta(rec)
                        End If
                End Select
                Exit Function
            End If
        Next

    End Function

    Public Function ConvertirDsctosArangos(listaEval As List(Of detalleitemequivalencia_beneficio)) As List(Of detalleitemequivalencia_beneficio)
        '   Dim ListaEntera = GetConverToListInteger(lista)

        ConvertirDsctosArangos = New List(Of detalleitemequivalencia_beneficio)
        Dim lista = listaEval.Where(Function(o) o.aplica = "2" And o.tipoafectacion = "IMPORTE").ToList

        Dim maxValor = lista.Max(Function(o) o.valor_evaluado).GetValueOrDefault
        Dim max As Decimal = 0
        For index = 0 To lista.Count - 1
            Dim rangoMinimo = lista(index).valor_evaluado
            If rangoMinimo = maxValor Then
                max = 0
            Else
                Dim max1 = lista(index + 1).valor_evaluado.GetValueOrDefault
                If max1 <= 1 Then
                    max = lista(index + 1).valor_evaluado.GetValueOrDefault - 0.01
                Else
                    max = lista(index + 1).valor_evaluado.GetValueOrDefault - 1
                End If
            End If
            ConvertirDsctosArangos.Add(AddItemNuevaListaDescuentos(lista(index), rangoMinimo, max))
        Next
    End Function

    Private Function AddItemNuevaListaDescuentos(be As detalleitemequivalencia_beneficio, rangoMinimo As Decimal?, max As Decimal) As detalleitemequivalencia_beneficio

        AddItemNuevaListaDescuentos = New detalleitemequivalencia_beneficio
        AddItemNuevaListaDescuentos = be
        AddItemNuevaListaDescuentos.valor_evaluado = rangoMinimo
        AddItemNuevaListaDescuentos.rango_final = max
    End Function


    Public Sub LoadCanastaVentas(listaProductos As List(Of documentoventaAbarrotesDet))
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("item")
        dt.Columns.Add("detalle")
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

        dt.Columns.Add("vcme")
        dt.Columns.Add("igvme")
        dt.Columns.Add("pume")
        dt.Columns.Add("totalme")

        dt.Columns.Add("idLote")
        dt.Columns.Add("idLoteDetalle")

        For Each i In listaProductos
            Select Case i.tipoExistencia
                Case TipoExistencia.ServicioGasto

                    dt.Rows.Add(i.CodigoCosto,
                                i.CustomProducto.origenProducto,
                                i.CustomProducto.descripcionItem, "",
                                i.CustomProducto.unidad1,
                                "",
                                i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                                i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                                i.importeMN.GetValueOrDefault, 0,
                                "", If(i.FlagBonif = "True", True, False), "", i.descuentoMN.GetValueOrDefault, i.AfectoInventario,
                                "-", 0, 0,
                                i.montokardexUS.GetValueOrDefault,
                                i.montoIgvUS.GetValueOrDefault,
                                0, i.importeME.GetValueOrDefault)

                Case Else
                    dt.Rows.Add(i.CodigoCosto,
                                i.CustomProducto.origenProducto,
                                i.CustomProducto.descripcionItem, i.detalleAdicional,
                                i.CustomProducto.unidad1,
                                i.CustomEquivalencia.contenido_neto,'fraccionUnidad.GetValueOrDefault,
                                i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                                i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                                i.importeMN.GetValueOrDefault, 0,
                                i.CustomEquivalencia.equivalencia_id, If(i.FlagBonif = "True", True, False), i.CustomCatalogo.idCatalogo, i.descuentoMN.GetValueOrDefault, i.AfectoInventario,
                                If(i.CustomProducto.tipoOtroImpuesto = "ICBPER", "ICBPER", "-"),
                                i.CustomProducto.otroImpuesto.GetValueOrDefault,
                                i.CustomProducto.otroImpuesto.GetValueOrDefault,
                                i.montokardexUS.GetValueOrDefault,
                                i.montoIgvUS.GetValueOrDefault,
                                0, i.importeME.GetValueOrDefault, i.idLote, i.idLoteDetalle)

                    If i.CustomListaVentaDetalle IsNot Nothing Then
                        'If i.CustomListaVentaDetalle.Count > 0 Then
                        '    MappingDetalleVentaInherits(i.CustomListaVentaDetalle.ToList, dt)
                        'End If
                    End If

            End Select
        Next
        GridCompra.DataSource = dt
        GridCompra.Refresh()
    End Sub

    Private Sub MappingDetalleVentaInherits(ListaItems As List(Of documentoventaAbarrotesDet), dt As DataTable)
        For Each i In ListaItems
            dt.Rows.Add(i.CodigoCosto,
                    i.CustomProducto.origenProducto,
                    i.CustomProducto.descripcionItem, "",
                    i.CustomProducto.unidad1,
                    i.CustomEquivalencia.contenido_neto.GetValueOrDefault,'fraccionUnidad.GetValueOrDefault,
                    i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                    i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                    i.importeMN.GetValueOrDefault, 0,
                    i.CustomEquivalencia.equivalencia_id, If(i.FlagBonif = "True", True, False), i.CustomCatalogo.idCatalogo, i.descuentoMN.GetValueOrDefault, i.AfectoInventario,
                    If(i.CustomProducto.tipoOtroImpuesto = "ICBPER", "ICBPER", "-"), i.CustomProducto.otroImpuesto.GetValueOrDefault, i.CustomProducto.otroImpuesto.GetValueOrDefault)
        Next
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Cursor = Cursors.WaitCursor
        BuscarProducto("NOMBRE")
        If listaProductos.Count > 0 Then
            popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
            PictureLoadingProduct.Visible = False

            'Dim rec As GridRecord = Me.usercontrol.GridTotales.Table.Records(1)
            'rec.SetCurrent("descripcion")
            'usercontrol.GridTotales.Focus()

            Dim colIndex As Integer = Me.usercontrol.GridCompra.TableDescriptor.FieldToColIndex(0)
            Dim rowIndex As Integer = Me.usercontrol.GridCompra.Table.Records(0).GetRowIndex()
            Me.usercontrol.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
            'Me.usercontrol.GridTotales.Focus()
        Else

            PictureLoadingProduct.Visible = False
        End If
        'Dim frmNuevaExistencia As New frmNuevaExistencia
        'With frmNuevaExistencia
        '    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
        '        .UCNuenExistencia.cboTipoExistencia.Enabled = False
        '        .UCNuenExistencia.cboUnidades.SelectedIndex = -1
        '        .UCNuenExistencia.cboUnidades.Enabled = True
        '    Else

        '    End If

        '    If Gempresas.Regimen = "1" Then
        '        .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
        '        .UCNuenExistencia.cboIgv.Enabled = True
        '    Else
        '        .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
        '        .UCNuenExistencia.cboIgv.Enabled = True
        '    End If
        '    .UCNuenExistencia.chClasificacion.Checked = False
        '    .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
        '    .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
        '    .EstadoManipulacion = ENTITY_ACTIONS.INSERT
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
        Cursor = Cursors.Default
    End Sub

    Private Sub EditarItemVenta(r As Record)
        If r IsNot Nothing Then

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
            If item IsNot Nothing Then
                With item
                    .monto1 = Decimal.Parse(r.GetValue("cantidad"))
                    .PrecioUnitarioVentaMN = Decimal.Parse(r.GetValue("precioventa"))
                    .montokardex = Decimal.Parse(r.GetValue("vcmn"))
                    .montokardexUS = Decimal.Parse(r.GetValue("vcme"))
                    .montoIgv = Decimal.Parse(r.GetValue("igvmn"))
                    .montoIgvUS = Decimal.Parse(r.GetValue("igvme"))
                    .precioUnitario = 0
                    .precioUnitarioUS = 0
                    .importeMN = Decimal.Parse(r.GetValue("totalmn"))
                    .importeME = Decimal.Parse(r.GetValue("totalme"))
                    .FlagBonif = r.GetValue("bonificacion").ToString
                    .descuentoMN = Decimal.Parse(r.GetValue("descuentoMN"))
                    .montoIcbper = Decimal.Parse(r.GetValue("totalafect"))
                    Dim DET = r.GetValue("detalle")
                    If DET.ToString.Trim.Length > 0 Then
                        .detalleAdicional = r.GetValue("detalle")
                    End If


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

    Private Sub EditarItemVentaV2(r As Record)
        If r IsNot Nothing Then

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
            If item IsNot Nothing Then
                With item
                    .monto1 = Decimal.Parse(r.GetValue("cantidad"))
                    .PrecioUnitarioVentaMN = Decimal.Parse(r.GetValue("precioventa"))
                    .montokardex = Decimal.Parse(r.GetValue("vcmn"))
                    .montokardexUS = Decimal.Parse(r.GetValue("vcme"))
                    .montoIgv = Decimal.Parse(r.GetValue("igvmn"))
                    .montoIgvUS = Decimal.Parse(r.GetValue("igvme"))
                    .precioUnitario = 0
                    .precioUnitarioUS = 0
                    .importeMN = Decimal.Parse(r.GetValue("totalmn"))
                    .importeME = Decimal.Parse(r.GetValue("totalme"))
                    '.FlagBonif = If(r.GetValue("bonificacion") = False, "True", "False")
                    .descuentoMN = Decimal.Parse(r.GetValue("descuentoMN"))
                    .montoIcbper = Decimal.Parse(r.GetValue("totalafect"))

                    Dim DET = r.GetValue("detalle")
                    If DET.ToString.Trim.Length > 0 Then
                        .detalleAdicional = r.GetValue("detalle")
                    End If

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

    Private Sub EditarItemVenta(RowIndex As Integer)
        If RowIndex <> -1 Then
            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
            If item IsNot Nothing Then
                With item
                    .monto1 = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 7).CellValue)
                    .montokardex = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 9).CellValue)
                    .montoIgv = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 10).CellValue)
                    .precioUnitario = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 8).CellValue)
                    .importeMN = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 12).CellValue)
                    .FlagBonif = If(Me.GridCompra.TableModel(RowIndex, 15).CellValue = False, "True", "False")
                    .descuentoMN = CDec(Me.GridCompra.TableModel(RowIndex, 17).CellValue)
                    .montoIcbper = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 21).CellValue)
                    .detalleAdicional = Me.GridCompra.TableModel(RowIndex, 4).CellValue.ToString()
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

    Public Sub GetCalculoItemImporte(r As Record)
        Select Case cboMoneda.Text
            Case "NUEVO SOL"
                CalculoImporteMN(r)
            Case Else
                CalculoImporteME(r)
        End Select
    End Sub

    Private Sub CalculoImporteMN(r As Record)
        If r IsNot Nothing Then
            Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
            Dim recaudo As Decimal = CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(r.GetValue("precioventa"))
            Dim canti As Decimal = CDec(r.GetValue("cantidad"))
            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0
            Dim precioUnitario As Decimal = 0

            Dim afectacion As String = r.GetValue("tipoAfectacion")
            Dim tasa As Decimal = CDec(r.GetValue("afectacion"))

            Dim totalicpbc As Decimal = canti * tasa

            Dim total As Decimal = Decimal.Parse(r.GetValue("totalmn"))

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
            If item IsNot Nothing Then
                If canti > 0 Then
                    precioVenta = total / canti
                Else
                    precioVenta = 0
                End If
                r.SetValue("precioventa", precioVenta)
                'Dim sub_total As Decimal = canti * item.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                'Dim total As Decimal = sub_total * precioVenta '
                Select Case bonificacion
                    Case True
                        baseImponible = 0
                        Iva = 0
                        total = 0
                    Case Else
                        Select Case recaudo
                            Case 2
                                baseImponible = total
                                Iva = 0
                            Case Else
                                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                Iva = Math.Round(total - baseImponible, 2)
                        End Select
                End Select

                r.SetValue("vcmn", baseImponible)
                r.SetValue("igvmn", Iva)
                r.SetValue("totalmn", total)
                r.SetValue("totalafect", totalicpbc)

                'moneda extranjera
                r.SetValue("vcme", 0)
                r.SetValue("igvme", 0)
                r.SetValue("totalme", 0)

                If CDec(r.GetValue("cantidad")) = 0 Or CDec(r.GetValue("cantidad")) = 0 Then
                    'precioUnitario = 0
                    'r.SetValue("pumn", 0)
                    'item.precioUnitario = 0
                Else
                    'precioUnitario = CalculoPrecioUnitario(total, canti)
                    'r.SetValue("pumn", precioUnitario)
                    'item.precioUnitario = precioUnitario
                End If

                GridCompra.Refresh()

                GetTotalesDocumento()
            End If
        End If
    End Sub

    Private Sub CalculoImporteME(r As Record)
        If r IsNot Nothing Then
            Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
            Dim recaudo As Decimal = CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(r.GetValue("precioventa"))
            Dim canti As Decimal = CDec(r.GetValue("cantidad"))
            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0
            Dim precioUnitario As Decimal = 0

            Dim baseImponibleME As Decimal = 0
            Dim IvaME As Decimal = 0
            Dim precioUnitarioME As Decimal = 0

            Dim afectacion As String = r.GetValue("tipoAfectacion")
            Dim tasa As Decimal = CDec(r.GetValue("afectacion"))

            Dim totalicpbc As Decimal = canti * tasa

            Dim totalME As Decimal = Decimal.Parse(r.GetValue("totalme"))
            Dim total As Decimal = Math.Round(totalME * txtTipoCambio.DecimalValue, 2) ' Decimal.Parse(r.GetValue("totalmn"))

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
            If item IsNot Nothing Then
                If canti > 0 Then
                    precioVenta = totalME / canti
                Else
                    precioVenta = 0
                End If
                r.SetValue("precioventa", precioVenta)
                'Dim sub_total As Decimal = canti * item.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                'Dim total As Decimal = sub_total * precioVenta '
                Select Case bonificacion
                    Case True
                        baseImponible = 0
                        Iva = 0
                        total = 0
                    Case Else
                        Select Case recaudo
                            Case 2
                                baseImponible = total
                                Iva = 0

                                baseImponibleME = totalME
                                IvaME = 0
                            Case Else
                                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                Iva = Math.Round(total - baseImponible, 2)

                                baseImponibleME = Math.Round(CDec(CalculoBaseImponible(totalME, 1.18)), 2)
                                IvaME = Math.Round(totalME - baseImponibleME, 2)
                        End Select
                End Select

                r.SetValue("vcmn", baseImponible)
                r.SetValue("igvmn", Iva)
                r.SetValue("totalmn", total)
                r.SetValue("totalafect", totalicpbc)

                'moneda extranjera
                r.SetValue("vcme", baseImponibleME)
                r.SetValue("igvme", IvaME)
                r.SetValue("totalme", totalME)

                If CDec(r.GetValue("cantidad")) = 0 Or CDec(r.GetValue("cantidad")) = 0 Then
                    'precioUnitario = 0
                    'r.SetValue("pumn", 0)
                    'item.precioUnitario = 0
                Else
                    'precioUnitario = CalculoPrecioUnitario(total, canti)
                    'r.SetValue("pumn", precioUnitario)
                    'item.precioUnitario = precioUnitario
                End If

                GridCompra.Refresh()

                GetTotalesDocumento()
            End If
        End If
    End Sub

    'Public Sub GetCalculoItem(r As Record)
    '    If r IsNot Nothing Then
    '        Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
    '        Dim recaudo As Decimal = CDec(r.GetValue("gravado"))
    '        Dim precioVenta As Decimal = CDec(r.GetValue("precioventa"))
    '        Dim canti As Decimal = CDec(r.GetValue("cantidad"))
    '        'Dim descuentoItem As Decimal = CDec(r.GetValue("descuentoMN"))



    '        Dim baseImponible As Decimal = 0
    '        Dim Iva As Decimal = 0
    '        Dim precioUnitario As Decimal = 0

    '        Dim afectacion As String = r.GetValue("tipoAfectacion")
    '        Dim tasa As Decimal = CDec(r.GetValue("afectacion"))

    '        Dim totalicpbc As Decimal = canti * tasa

    '        Dim total As Decimal = canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))
    '        total = total '- descuentoItem

    '        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
    '        If item IsNot Nothing Then
    '            If item.CustomListaVentaDetalle IsNot Nothing Then
    '                If item.CustomListaVentaDetalle.Count > 0 Then
    '                    r.EndEdit()
    '                    EditarItemVenta(r)
    '                    EliminarProductosInherits(item.CustomListaVentaDetalle.ToList)
    '                    item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
    '                End If
    '            End If

    '            r.SetValue("totalmn", total)
    '            Dim descuentoConfigurado = GetBeneficioItem(r)

    '            If descuentoConfigurado IsNot Nothing Then

    '                Select Case descuentoConfigurado.tipobeneficio
    '                    Case "DESCUENTO"
    '                        If descuentoConfigurado IsNot Nothing Then

    '                            r.SetValue("descuentoMN", descuentoConfigurado.valor_beneficio)
    '                            total = total - descuentoConfigurado.valor_beneficio.GetValueOrDefault
    '                            r.SetValue("totalmn", total)
    '                        End If
    '                        'Dim sub_total As Decimal = canti * item.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
    '                        'Dim total As Decimal = sub_total * precioVenta '
    '                        Select Case bonificacion
    '                            Case True
    '                                baseImponible = 0
    '                                Iva = 0
    '                                total = 0
    '                            Case Else
    '                                Select Case recaudo
    '                                    Case 2
    '                                        baseImponible = total
    '                                        Iva = 0
    '                                    Case Else
    '                                        baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
    '                                        Iva = Math.Round(total - baseImponible, 2)
    '                                End Select
    '                        End Select

    '                        r.SetValue("vcmn", baseImponible)
    '                        r.SetValue("igvmn", Iva)
    '                        'r.SetValue("descuentoMN", descuentoItem)
    '                        r.SetValue("totalmn", total)
    '                        r.SetValue("totalafect", totalicpbc)
    '                    Case "OFERTA"

    '                End Select
    '            End If
    '            If CDec(r.GetValue("cantidad")) = 0 Or CDec(r.GetValue("cantidad")) = 0 Then
    '                'precioUnitario = 0
    '                'r.SetValue("pumn", 0)
    '                'item.precioUnitario = 0
    '            Else
    '                'precioUnitario = CalculoPrecioUnitario(total, canti)
    '                'r.SetValue("pumn", precioUnitario)
    '                'item.precioUnitario = precioUnitario
    '            End If

    '            GridCompra.Refresh()

    '            GetTotalesDocumento()
    '        End If
    '    End If
    'End Sub

    Private Sub EliminarProductosInherits(Lista As List(Of documentoventaAbarrotesDet))
        For Each i In Lista
            For Each r In GridCompra.Table.Records
                If r.GetValue("codigo") = i.CodigoCosto Then
                    r.Delete()
                End If
            Next

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = i.CodigoCosto).Single
            ListaproductosVendidos.Remove(item)
        Next
        Lista.Clear()


        'LoadCanastaVentas(ListaproductosVendidos)
    End Sub

    Public Sub GetCalculoItemV2(r As Record)
        If r IsNot Nothing Then
            Select Case cboMoneda.Text
                Case "NUEVO SOL"
                    CalculoMN(r)
                Case Else
                    CalculoME(r)
            End Select

        End If
    End Sub

    Private Sub CalculoMN(r As Record)
        Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
        Dim recaudo As Decimal = CDec(r.GetValue("gravado"))
        Dim precioVenta As Decimal = CDec(r.GetValue("precioventa"))
        Dim canti As Decimal = CDec(r.GetValue("cantidad"))
        Dim descuentoItem As Decimal = CDec(r.GetValue("descuentoMN"))

        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0
        Dim precioUnitario As Decimal = 0

        Dim afectacion As String = r.GetValue("tipoAfectacion")
        Dim tasa As Decimal = CDec(r.GetValue("afectacion"))

        Dim totalicpbc As Decimal = canti * tasa

        Dim total As Decimal = canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))
        total = total - descuentoItem

        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
        If item IsNot Nothing Then
            'Dim sub_total As Decimal = canti * item.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
            'Dim total As Decimal = sub_total * precioVenta '
            Select Case bonificacion
                Case True
                    baseImponible = 0
                    Iva = 0
                    total = 0
                Case Else
                    Select Case recaudo
                        Case 2
                            baseImponible = total
                            Iva = 0
                        Case Else
                            baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                            Iva = Math.Round(total - baseImponible, 2)
                    End Select
            End Select

            r.SetValue("vcmn", baseImponible)
            r.SetValue("igvmn", Iva)
            r.SetValue("descuentoMN", descuentoItem)
            r.SetValue("totalmn", total)
            r.SetValue("totalafect", totalicpbc)

            'MONEDA EXTRANJERA
            r.SetValue("vcme", 0)
            r.SetValue("igvme", 0)
            r.SetValue("descuentoME", 0)
            r.SetValue("totalme", 0)
            ' r.SetValue("totalafect", 0)

            If CDec(r.GetValue("cantidad")) = 0 Or CDec(r.GetValue("cantidad")) = 0 Then
                'precioUnitario = 0
                'r.SetValue("pumn", 0)
                'item.precioUnitario = 0
            Else
                'precioUnitario = CalculoPrecioUnitario(total, canti)
                'r.SetValue("pumn", precioUnitario)
                'item.precioUnitario = precioUnitario
            End If

            GridCompra.Refresh()

            GetTotalesDocumento()
        End If
    End Sub

    Private Sub CalculoME(r As Record)
        Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
        Dim recaudo As Decimal = CDec(r.GetValue("gravado"))
        Dim precioVenta As Decimal = CDec(r.GetValue("precioventa"))
        Dim canti As Decimal = CDec(r.GetValue("cantidad"))
        Dim descuentoItem As Decimal = CDec(r.GetValue("descuentoMN"))

        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0
        Dim precioUnitario As Decimal = 0

        Dim baseImponibleME As Decimal = 0
        Dim IvaME As Decimal = 0
        Dim precioUnitarioME As Decimal = 0

        Dim afectacion As String = r.GetValue("tipoAfectacion")
        Dim tasa As Decimal = CDec(r.GetValue("afectacion"))

        Dim totalicpbc As Decimal = canti * tasa

        Dim totalME As Decimal = Math.Round(canti * precioVenta, 2)
        Dim total As Decimal = Math.Round(totalME * txtTipoCambio.DecimalValue, 2)  'Decimal.Parse(r.GetValue("totalmn"))
        totalME = totalME - descuentoItem
        total = total - descuentoItem

        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
        If item IsNot Nothing Then
            'Dim sub_total As Decimal = canti * item.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
            'Dim total As Decimal = sub_total * precioVenta '
            Select Case bonificacion
                Case True
                    baseImponible = 0
                    Iva = 0
                    total = 0

                    baseImponibleME = 0
                    IvaME = 0
                    totalME = 0
                Case Else
                    Select Case recaudo
                        Case 2
                            baseImponible = total
                            baseImponibleME = totalME
                            Iva = 0
                            IvaME = 0
                        Case Else
                            baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                            baseImponibleME = Math.Round(CDec(CalculoBaseImponible(totalME, 1.18)), 2)
                            Iva = Math.Round(total - baseImponible, 2)
                            IvaME = Math.Round(totalME - baseImponibleME, 2)
                    End Select
            End Select

            r.SetValue("vcmn", baseImponible)
            r.SetValue("igvmn", Iva)
            r.SetValue("descuentoMN", descuentoItem)
            r.SetValue("totalmn", total)
            r.SetValue("totalafect", totalicpbc)

            'MONEDA EXTRANJERA
            r.SetValue("vcme", baseImponibleME)
            r.SetValue("igvme", IvaME)
            r.SetValue("descuentoME", descuentoItem)
            r.SetValue("totalme", totalME)
            r.SetValue("totalafect", totalicpbc)

            If CDec(r.GetValue("cantidad")) = 0 Or CDec(r.GetValue("cantidad")) = 0 Then
                'precioUnitario = 0
                'r.SetValue("pumn", 0)
                'item.precioUnitario = 0
            Else
                'precioUnitario = CalculoPrecioUnitario(total, canti)
                'r.SetValue("pumn", precioUnitario)
                'item.precioUnitario = precioUnitario
            End If

            GridCompra.Refresh()

            GetTotalesDocumento()
        End If
    End Sub


    Public Function GetBeneficioItem(r As Record) As detalleitemequivalencia_beneficio
        GetBeneficioItem = Nothing
        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
        Dim listaBeneficios = item.CustomEquivalencia.detalleitemequivalencia_beneficio.ToList
        Dim importeventa = Decimal.Parse(r.GetValue("precioventa")) * Decimal.Parse(r.GetValue("cantidad")) 'Decimal.Parse(r.GetValue("totalmn"))
        Dim cantidadVenta = Decimal.Parse(r.GetValue("cantidad"))


        Dim DescuentosSuperiores As Boolean = listaBeneficios.Any(Function(o) o.aplica = 2 And o.tipobeneficio = "DESCUENTO" And o.tipoafectacion = "IMPORTE" And o.beneficio_detalle <> "Dscto por amarres, segundo item paga 50%")
        Dim DescuentosPorCada As Boolean = listaBeneficios.Any(Function(o) o.aplica = 1 And o.tipobeneficio = "DESCUENTO" And o.tipoafectacion = "IMPORTE" And o.beneficio_detalle <> "Dscto por amarres, segundo item paga 50%")

        Dim DescuentosPorCadaVolumen As Boolean = listaBeneficios.Any(Function(o) o.aplica = 1 And o.tipobeneficio = "DESCUENTO" And o.tipoafectacion = "CANTIDAD" And o.beneficio_detalle <> "Dscto por amarres, segundo item paga 50%")
        Dim DescuentosSuperioresVolumen As Boolean = listaBeneficios.Any(Function(o) o.aplica = 2 And o.tipobeneficio = "DESCUENTO" And o.tipoafectacion = "CANTIDAD" And o.beneficio_detalle <> "Dscto por amarres, segundo item paga 50%")


        Dim DescuentosItemsPorAmarre As Boolean = listaBeneficios.Any(Function(o) o.beneficio_detalle = "Dscto por amarres, segundo item paga 50%")

        If DescuentosPorCada Then
            If listaBeneficios IsNot Nothing Then
                For Each i In listaBeneficios
                    Select Case i.tipobeneficio
                        Case "DESCUENTO"
                            Select Case i.aplica
                                Case "1" 'por cada
                                    r.SetValue("descuentoMN", 0)
                                    Dim Conversion = i.valor_conversion
                                    Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                                    Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault

                                    If i.tipoafectacion = "IMPORTE" Then
                                        Select Case Conversion
                                            Case "VALOR UNICO", "PORCENTAJE"
                                                If importeventa >= EvaluaApartirDe Then

                                                    Dim valorResultado As Decimal = AgregarDsctoPorCada(r, importeventa, EvaluaApartirDe, i, item)

                                                    GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                                       {
                                                       .tipobeneficio = "DSCTO",
                                                       .tipoafectacion = "IMPORTE",
                                                       .valor_conversion = Conversion,
                                                       .valor_beneficio = valorResultado
                                                       }
                                                End If
                                                'Case "PORCENTAJE"
                                                '    Dim valorResultado As Decimal = AgregarDsctoPorCada(r, importeventa, EvaluaApartirDe, i, item)

                                                '    GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                                '       {
                                                '       .tipobeneficio = "DSCTO",
                                                '       .tipoafectacion = "IMPORTE",
                                                '       .valor_conversion = Conversion,
                                                '       .valor_beneficio = valorResultado
                                                '       }
                                        End Select
                                    End If

                                Case Else ' a partir de/Superior a...
                                    'r.SetValue("descuentoMN", 0)
                                    'If i.tipoafectacion = "IMPORTE" Then
                                    '    Dim Conversion = i.valor_conversion
                                    '    Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                                    '    Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault
                                    '    Select Case Conversion
                                    '        Case "VALOR UNICO", "PORCENTAJE"
                                    '            If importeventa >= EvaluaApartirDe Then
                                    '                '  Dim descuentoFinal As Decimal = importeventa - ValorBeneficio

                                    '                Dim valorResultado = AgregarDsctoSuperiorA(r, importeventa, i)

                                    '                GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                    '                {
                                    '                .tipobeneficio = "DESCUENTO",
                                    '                .tipoafectacion = "IMPORTE",
                                    '                .valor_conversion = Conversion,
                                    '                .valor_beneficio = valorResultado
                                    '                }

                                    '                ' GetBeneficioItem = descuentoFinal
                                    '            End If
                                    '            '   Case "PORCENTAJE"
                                    '            'If importeventa >= EvaluaApartirDe Then
                                    '            '    Dim porcentaje = ValorBeneficio / 100
                                    '            '    Dim descuentoFinal As Decimal = importeventa * porcentaje

                                    '            '    GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                    '            '    {
                                    '            '    .tipobeneficio = "DESCUENTO",
                                    '            '    .tipoafectacion = "IMPORTE",
                                    '            '    .valor_conversion = Conversion,
                                    '            '    .valor_beneficio = descuentoFinal
                                    '            '    }

                                    '            '    ' GetBeneficioItem = descuentoFinal
                                    '            'End If
                                    '    End Select

                                    'ElseIf i.tipoafectacion = "CANTIDAD" Then

                                    '    Dim Conversion = i.valor_conversion
                                    '    Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                                    '    Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault
                                    '    Select Case Conversion
                                    '        Case "VALOR UNICO"
                                    '            If cantidadVenta >= EvaluaApartirDe Then
                                    '                Dim descuentoFinal As Decimal = cantidadVenta - ValorBeneficio
                                    '                ' GetBeneficioItem = descuentoFinal

                                    '                GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                    '                {
                                    '                .tipobeneficio = "DESCUENTO",
                                    '                .tipoafectacion = "CANTIDAD",
                                    '                .valor_conversion = Conversion,
                                    '                .valor_beneficio = descuentoFinal
                                    '                }
                                    '            End If
                                    '        Case "PORCENTAJE"
                                    '            If cantidadVenta >= EvaluaApartirDe Then
                                    '                Dim porcentaje = ValorBeneficio / 100
                                    '                Dim descuentoFinal As Decimal = importeventa * porcentaje

                                    '                GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                    '                {
                                    '                .tipobeneficio = "DESCUENTO",
                                    '                .tipoafectacion = "CANTIDAD",
                                    '                .valor_conversion = Conversion,
                                    '                .valor_beneficio = descuentoFinal
                                    '                }
                                    '                'GetBeneficioItem = descuentoFinal
                                    '            End If
                                    '    End Select
                                    'End If
                            End Select



                        Case "OFERTA", "PROMOCION"
                            Dim Conversion = i.valor_conversion
                            Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                            Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault

                            If i.tipoafectacion = "CANTIDAD" Then
                                Select Case Conversion
                                    Case "VALOR UNICO"
                                        If cantidadVenta >= EvaluaApartirDe Then
                                            AgregarPromocion(r, cantidadVenta, EvaluaApartirDe, i, item)

                                            GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                           {
                                           .tipobeneficio = "OFERTA",
                                           .tipoafectacion = "CANTIDAD",
                                           .valor_conversion = Conversion,
                                           .valor_beneficio = 0
                                           }
                                        End If

                                End Select
                            End If
                    End Select
                Next
            Else
                GetBeneficioItem = Nothing
            End If
        ElseIf DescuentosPorCadaVolumen Then
            For Each i In listaBeneficios
                Select Case i.aplica
                    Case "1" 'por cada
                        r.SetValue("descuentoMN", 0)
                        Dim Conversion = i.valor_conversion
                        Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                        Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault

                        If i.tipoafectacion = "CANTIDAD" Then
                            Select Case Conversion
                                Case "VALOR UNICO" ', "PORCENTAJE"
                                    If cantidadVenta >= EvaluaApartirDe Then

                                        Dim valorResultado As Decimal = AgregarDsctoPorCadaVolumen(r, cantidadVenta, EvaluaApartirDe, i, item)

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                           {
                                           .tipobeneficio = "DSCTO",
                                           .tipoafectacion = "IMPORTE",
                                           .valor_conversion = Conversion,
                                           .valor_beneficio = valorResultado
                                           }
                                    End If
                                Case "PORCENTAJE"
                                    Dim valorResultado As Decimal = AgregarDsctoPorCadaVolumen(r, cantidadVenta, EvaluaApartirDe, i, item)

                                    GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                       {
                                       .tipobeneficio = "DSCTO",
                                       .tipoafectacion = "IMPORTE",
                                       .valor_conversion = Conversion,
                                       .valor_beneficio = valorResultado
                                       }
                            End Select
                        End If
                    Case "2" 'Superior a...

                End Select
            Next
        End If

        If DescuentosSuperiores Then
            Dim Descto = GetCalculoDescuento(importeventa, r, listaBeneficios.Where(Function(o) o.aplica = 2 And o.tipobeneficio = "DESCUENTO" And o.tipoafectacion = "IMPORTE").ToList)
            'r.SetValue("descuentoMN", precioVenta)
        End If

        If DescuentosSuperioresVolumen Then
            Dim Descto = GetCalculoDescuentoVolumen(cantidadVenta, r, listaBeneficios.Where(Function(o) o.aplica = 2 And o.tipobeneficio = "DESCUENTO" And o.tipoafectacion = "CANTIDAD").ToList, importeventa)
            'r.SetValue("descuentoMN", precioVenta)
        End If

        If DescuentosItemsPorAmarre Then
            Dim form As New FormDsctoAmarresModal(2, FormPurchase)
            form.StartPosition = FormStartPosition.CenterParent
            form.ShowDialog(Me)
        End If

    End Function

    Private Function GetBeneficioItem(obj As documentoventaAbarrotesDet) As detalleitemequivalencia_beneficio
        GetBeneficioItem = Nothing
        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = obj.CodigoCosto).SingleOrDefault
        Dim listaBeneficios = item.CustomEquivalencia.detalleitemequivalencia_beneficio.ToList
        Dim importeventa = obj.importeMN
        Dim cantidadVenta = obj.monto1

        If listaBeneficios IsNot Nothing Then
            For Each i In listaBeneficios
                Select Case i.tipobeneficio
                    Case "DESCUENTO"
                        obj.descuentoMN = 0
                        If i.tipoafectacion = "IMPORTE" Then
                            Dim Conversion = i.valor_conversion
                            Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                            Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault
                            Select Case Conversion
                                Case "VALOR UNICO"
                                    If importeventa >= EvaluaApartirDe Then
                                        Dim descuentoFinal As Decimal = importeventa - ValorBeneficio

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                        {
                                        .tipobeneficio = "DESCUENTO",
                                        .tipoafectacion = "IMPORTE",
                                        .valor_conversion = Conversion,
                                        .valor_beneficio = descuentoFinal
                                        }

                                        ' GetBeneficioItem = descuentoFinal
                                    End If
                                Case "PORCENTAJE"
                                    If importeventa >= EvaluaApartirDe Then
                                        Dim porcentaje = ValorBeneficio / 100
                                        Dim descuentoFinal As Decimal = importeventa * porcentaje

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                        {
                                        .tipobeneficio = "DESCUENTO",
                                        .tipoafectacion = "IMPORTE",
                                        .valor_conversion = Conversion,
                                        .valor_beneficio = descuentoFinal
                                        }

                                        ' GetBeneficioItem = descuentoFinal
                                    End If
                            End Select

                        ElseIf i.tipoafectacion = "CANTIDAD" Then

                            Dim Conversion = i.valor_conversion
                            Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                            Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault
                            Select Case Conversion
                                Case "VALOR UNICO"
                                    If cantidadVenta >= EvaluaApartirDe Then
                                        Dim descuentoFinal As Decimal = cantidadVenta - ValorBeneficio
                                        ' GetBeneficioItem = descuentoFinal

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                        {
                                        .tipobeneficio = "DESCUENTO",
                                        .tipoafectacion = "CANTIDAD",
                                        .valor_conversion = Conversion,
                                        .valor_beneficio = descuentoFinal
                                        }
                                    End If
                                Case "PORCENTAJE"
                                    If cantidadVenta >= EvaluaApartirDe Then
                                        Dim porcentaje = ValorBeneficio / 100
                                        Dim descuentoFinal As Decimal = importeventa * porcentaje

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                        {
                                        .tipobeneficio = "DESCUENTO",
                                        .tipoafectacion = "CANTIDAD",
                                        .valor_conversion = Conversion,
                                        .valor_beneficio = descuentoFinal
                                        }
                                        'GetBeneficioItem = descuentoFinal
                                    End If
                            End Select
                        End If

                    Case "OFERTA", "PROMOCION"
                        Dim Conversion = i.valor_conversion
                        Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                        Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault

                        If i.tipoafectacion = "CANTIDAD" Then
                            Select Case Conversion
                                Case "VALOR UNICO"
                                    If cantidadVenta >= EvaluaApartirDe Then
                                        AgregarPromocion(cantidadVenta, EvaluaApartirDe, i, item)

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                       {
                                       .tipobeneficio = "OFERTA",
                                       .tipoafectacion = "CANTIDAD",
                                       .valor_conversion = Conversion,
                                       .valor_beneficio = 0
                                       }
                                    End If

                            End Select
                        End If
                End Select
            Next
        Else
            GetBeneficioItem = Nothing
        End If
    End Function

    Private Function GetBeneficioItem(rowIndex As Integer) As detalleitemequivalencia_beneficio
        GetBeneficioItem = Nothing
        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(rowIndex, 1).CellValue).SingleOrDefault
        Dim listaBeneficios = item.CustomEquivalencia.detalleitemequivalencia_beneficio.ToList
        Dim importeventa = Decimal.Parse(Me.GridCompra.TableModel(rowIndex, 12).CellValue)
        Dim cantidadVenta = CDec(Me.GridCompra.TableModel(rowIndex, 7).CellValue)

        If listaBeneficios IsNot Nothing Then
            For Each i In listaBeneficios
                Select Case i.tipobeneficio
                    Case "DESCUENTO"
                        If i.tipoafectacion = "IMPORTE" Then
                            Dim Conversion = i.valor_conversion
                            Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                            Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault
                            Select Case Conversion
                                Case "VALOR UNICO"
                                    If importeventa >= EvaluaApartirDe Then
                                        Dim descuentoFinal As Decimal = importeventa - ValorBeneficio

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                        {
                                        .tipobeneficio = "DESCUENTO",
                                        .tipoafectacion = "IMPORTE",
                                        .valor_conversion = Conversion,
                                        .valor_beneficio = descuentoFinal
                                        }

                                        ' GetBeneficioItem = descuentoFinal
                                    End If
                                Case "PORCENTAJE"
                                    If importeventa >= EvaluaApartirDe Then
                                        Dim porcentaje = ValorBeneficio / 100
                                        Dim descuentoFinal As Decimal = importeventa * porcentaje

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                        {
                                        .tipobeneficio = "DESCUENTO",
                                        .tipoafectacion = "IMPORTE",
                                        .valor_conversion = Conversion,
                                        .valor_beneficio = descuentoFinal
                                        }

                                        ' GetBeneficioItem = descuentoFinal
                                    End If
                            End Select

                        ElseIf i.tipoafectacion = "CANTIDAD" Then

                            Dim Conversion = i.valor_conversion
                            Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                            Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault
                            Select Case Conversion
                                Case "VALOR UNICO"
                                    If cantidadVenta >= EvaluaApartirDe Then
                                        Dim descuentoFinal As Decimal = cantidadVenta - ValorBeneficio
                                        ' GetBeneficioItem = descuentoFinal

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                        {
                                        .tipobeneficio = "DESCUENTO",
                                        .tipoafectacion = "CANTIDAD",
                                        .valor_conversion = Conversion,
                                        .valor_beneficio = descuentoFinal
                                        }
                                    End If
                                Case "PORCENTAJE"
                                    If cantidadVenta >= EvaluaApartirDe Then
                                        Dim porcentaje = ValorBeneficio / 100
                                        Dim descuentoFinal As Decimal = importeventa * porcentaje

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                        {
                                        .tipobeneficio = "DESCUENTO",
                                        .tipoafectacion = "CANTIDAD",
                                        .valor_conversion = Conversion,
                                        .valor_beneficio = descuentoFinal
                                        }
                                        'GetBeneficioItem = descuentoFinal
                                    End If
                            End Select
                        End If

                    Case "OFERTA", "PROMOCION"
                        Dim Conversion = i.valor_conversion
                        Dim EvaluaApartirDe = i.valor_evaluado.GetValueOrDefault
                        Dim ValorBeneficio = i.valor_beneficio.GetValueOrDefault

                        If i.tipoafectacion = "CANTIDAD" Then
                            Select Case Conversion
                                Case "VALOR UNICO"
                                    If cantidadVenta >= EvaluaApartirDe Then
                                        AgregarPromocion(rowIndex, cantidadVenta, EvaluaApartirDe, i, item)

                                        GetBeneficioItem = New detalleitemequivalencia_beneficio With
                                       {
                                       .tipobeneficio = "OFERTA",
                                       .tipoafectacion = "CANTIDAD",
                                       .valor_conversion = Conversion,
                                       .valor_beneficio = 0
                                       }
                                    End If

                            End Select
                        End If
                End Select
            Next
        Else
            GetBeneficioItem = Nothing
        End If
    End Function

    Public Function AgregarDsctoPorCada(r As Record, cantidadVenta As Decimal, CantidadBaseDb As Decimal, ben As detalleitemequivalencia_beneficio, itemventa As documentoventaAbarrotesDet) As Decimal
        AgregarDsctoPorCada = 0

        Select Case ben.valor_conversion
            Case "VALOR UNICO"
                Dim Base As Decimal = cantidadVenta
                Dim BaseDB As Decimal = CantidadBaseDb
                Dim nrollevar As Decimal = BaseDB
                Dim nroPagar As Decimal = ben.valor_beneficio.GetValueOrDefault
                Dim totalpromocionesRegaladas As Decimal = Base / nrollevar

                Dim parteEntera = Int(totalpromocionesRegaladas)
                Dim parteDecimal As Decimal = (totalpromocionesRegaladas) - parteEntera
                If parteDecimal > 0 Then
                    parteDecimal = 1
                End If
                Dim Valorregalo As Decimal = nroPagar 'nrollevar - nroPagar
                Dim NumTotalregalos As Decimal = parteEntera * Valorregalo


                If NumTotalregalos > 0 Then

                    Dim cantActualizada As Decimal? = NumTotalregalos ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                    r.SetValue("descuentoMN", cantActualizada)
                    r.EndEdit()
                    GetCalculoItemV2(r)
                    EditarItemVenta(r)
                    AgregarDsctoPorCada = cantActualizada
                End If
            Case "PORCENTAJE"


                Dim Base As Decimal = cantidadVenta
                Dim BaseDB As Decimal = CantidadBaseDb
                Dim nrollevar As Decimal = BaseDB
                Dim nroPagar As Decimal = ben.valor_beneficio.GetValueOrDefault
                Dim totalpromocionesRegaladas As Decimal = Base / nrollevar

                Dim parteEntera = Int(totalpromocionesRegaladas)
                Dim parteDecimal As Decimal = (totalpromocionesRegaladas) - parteEntera
                If parteDecimal > 0 Then
                    parteDecimal = 1
                End If
                Dim Valorregalo As Decimal = nroPagar 'nrollevar - nroPagar
                Dim NumTotalregalos As Decimal = parteEntera * Valorregalo
                Dim descuentototalPorc As Decimal = 0
                descuentototalPorc = cantidadVenta * (NumTotalregalos / 100)

                If descuentototalPorc > 0 Then

                    Dim cantActualizada As Decimal? = descuentototalPorc ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                    r.SetValue("descuentoMN", cantActualizada)
                    r.EndEdit()
                    GetCalculoItemV2(r)
                    EditarItemVenta(r)
                    AgregarDsctoPorCada = cantActualizada
                End If

        End Select


    End Function

    Public Function AgregarDsctoPorCadaVolumen(r As Record, cantidadVenta As Decimal, CantidadBaseDb As Decimal, ben As detalleitemequivalencia_beneficio, itemventa As documentoventaAbarrotesDet) As Decimal
        AgregarDsctoPorCadaVolumen = 0

        Select Case ben.valor_conversion
            Case "VALOR UNICO"
                Dim Base As Decimal = cantidadVenta
                Dim BaseDB As Decimal = CantidadBaseDb
                Dim nrollevar As Decimal = BaseDB
                Dim nroPagar As Decimal = ben.valor_beneficio.GetValueOrDefault
                Dim totalpromocionesRegaladas As Decimal = Base / nrollevar

                Dim parteEntera = Int(totalpromocionesRegaladas)
                Dim parteDecimal As Decimal = (totalpromocionesRegaladas) - parteEntera
                If parteDecimal > 0 Then
                    parteDecimal = 1
                End If
                Dim Valorregalo As Decimal = nroPagar 'nrollevar - nroPagar
                Dim NumTotalregalos As Decimal = parteEntera * Valorregalo


                If NumTotalregalos > 0 Then

                    Dim cantActualizada As Decimal? = NumTotalregalos ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                    r.SetValue("descuentoMN", cantActualizada)
                    r.EndEdit()
                    GetCalculoItemV2(r)
                    EditarItemVenta(r)
                    AgregarDsctoPorCadaVolumen = cantActualizada
                End If
            Case "PORCENTAJE"


                Dim Base As Decimal = cantidadVenta
                Dim BaseDB As Decimal = CantidadBaseDb
                Dim nrollevar As Decimal = BaseDB
                Dim nroPagar As Decimal = ben.valor_beneficio.GetValueOrDefault
                Dim totalpromocionesRegaladas As Decimal = Base / nrollevar

                Dim parteEntera = Int(totalpromocionesRegaladas)
                Dim parteDecimal As Decimal = (totalpromocionesRegaladas) - parteEntera
                If parteDecimal > 0 Then
                    parteDecimal = 1
                End If
                Dim Valorregalo As Decimal = nroPagar 'nrollevar - nroPagar
                Dim NumTotalregalos As Decimal = parteEntera * Valorregalo
                Dim descuentototalPorc As Decimal = 0
                descuentototalPorc = Decimal.Parse(r.GetValue("totalmn")) * (NumTotalregalos / 100)

                If descuentototalPorc > 0 Then

                    Dim cantActualizada As Decimal? = descuentototalPorc ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                    r.SetValue("descuentoMN", cantActualizada)
                    r.EndEdit()
                    GetCalculoItemV2(r)
                    EditarItemVenta(r)
                    AgregarDsctoPorCadaVolumen = cantActualizada
                End If

        End Select


    End Function

    Public Function AgregarDsctoSuperiorA(r As Record, importeventa As Decimal, ben As detalleitemequivalencia_beneficio) As Decimal
        AgregarDsctoSuperiorA = 0
        Dim descuentoFinal As Decimal = 0
        If importeventa >= ben.valor_evaluado Then

            Select Case ben.valor_conversion
                Case "VALOR UNICO"
                    'descuentoFinal = importeventa - ben.valor_beneficio
                    If ben.valor_beneficio > 0 Then
                        ' Dim cantActualizada As Decimal? = descuentoFinal ' NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                        r.SetValue("descuentoMN", ben.valor_beneficio)
                        r.EndEdit()
                        GetCalculoItemV2(r)
                        EditarItemVenta(r)
                        AgregarDsctoSuperiorA = ben.valor_beneficio
                    End If
                Case "PORCENTAJE"
                    Dim valorPorcentajeDscto As Decimal = 0
                    valorPorcentajeDscto = importeventa * (ben.valor_beneficio / 100)
                    r.SetValue("descuentoMN", valorPorcentajeDscto)
                    r.EndEdit()
                    GetCalculoItemV2(r)
                    EditarItemVenta(r)
                    AgregarDsctoSuperiorA = valorPorcentajeDscto
            End Select
        End If
    End Function

    Private Sub AgregarPromocion(r As Record, cantidadVenta As Decimal, CantidadBaseDb As Decimal, ben As detalleitemequivalencia_beneficio, itemventa As documentoventaAbarrotesDet)
        Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
        Dim Base As Decimal = cantidadVenta
        Dim BaseDB As Decimal = CantidadBaseDb
        Dim nrollevar As Decimal = BaseDB
        Dim nroPagar As Decimal = ben.valor_beneficio.GetValueOrDefault
        Dim totalpromocionesRegaladas As Decimal = Base / nrollevar

        Dim parteEntera = Int(totalpromocionesRegaladas)
        Dim parteDecimal As Decimal = (totalpromocionesRegaladas) - parteEntera
        If parteDecimal > 0 Then
            parteDecimal = 1
        End If
        Dim Valorregalo As Decimal = nrollevar - nroPagar
        Dim NumTotalregalos As Decimal = parteEntera * Valorregalo
        Dim NumTotalProductosLLevar As Decimal = Base - NumTotalregalos
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0
        Dim total As Decimal = 0
        If NumTotalProductosLLevar > 0 Then
            Dim recaudo = CDec(r.GetValue("gravado"))

            Select Case bonificacion
                Case True
                    baseImponible = 0
                    Iva = 0
                    total = 0
                Case Else

                    Dim pu As Decimal = CDec(r.GetValue("precioventa"))

                    Dim cantActualizada As Decimal? = NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                    r.SetValue("cantidad", cantActualizada)
                    total = NumTotalregalos * pu ' cantActualizada * pu

                    Select Case recaudo
                        Case 2
                            baseImponible = total
                            Iva = 0
                        Case Else
                            baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                            Iva = Math.Round(total - baseImponible, 2)
                    End Select
            End Select

            r.SetValue("vcmn", baseImponible)
            r.SetValue("igvmn", Iva)
            'r.SetValue("descuentoMN", descuentoItem)
            r.SetValue("totalmn", total)
            r.SetValue("totalafect", 0)
            r.EndEdit()

            EditarItemVenta(r)
        End If

        itemventa.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
        Select Case bonificacion
            Case True

            Case Else
                AgregarBeneficioProductoDetalleVenta(NumTotalregalos, itemventa.CustomProducto.codigodetalle, CDec(r.GetValue("precioventa")), itemventa.CustomEquivalencia, itemventa.CustomCatalogo.idCatalogo, "OFERTA", itemventa)
        End Select

    End Sub

    Private Sub AgregarPromocion(cantidadVenta As Decimal, CantidadBaseDb As Decimal, ben As detalleitemequivalencia_beneficio, itemventa As documentoventaAbarrotesDet)

        Dim Base As Decimal = cantidadVenta
        Dim BaseDB As Decimal = CantidadBaseDb
        Dim nrollevar As Decimal = BaseDB
        Dim nroPagar As Decimal = ben.valor_beneficio.GetValueOrDefault
        Dim totalpromocionesRegaladas As Decimal = Base / nrollevar

        Dim parteEntera = Int(totalpromocionesRegaladas)
        Dim parteDecimal As Decimal = (totalpromocionesRegaladas) - parteEntera
        If parteDecimal > 0 Then
            parteDecimal = 1
        End If
        Dim Valorregalo As Decimal = nrollevar - nroPagar
        Dim NumTotalregalos As Decimal = parteEntera * Valorregalo
        Dim NumTotalProductosLLevar As Decimal = Base - NumTotalregalos
        Dim baseImponible As Decimal = 0
        Dim Iva As Decimal = 0
        Dim total As Decimal = 0
        If NumTotalProductosLLevar > 0 Then
            Dim recaudo = itemventa.destino

            'Select Case bonificacion
            '    Case True
            '        baseImponible = 0
            '        Iva = 0
            '        total = 0
            '    Case Else

            Dim pu As Decimal = itemventa.precioUnitario

            Dim cantActualizada As Decimal? = NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
            itemventa.monto1 = cantActualizada
            total = NumTotalregalos * pu ' cantActualizada * pu

            Select Case recaudo
                Case 2
                    baseImponible = total
                    Iva = 0
                Case Else
                    baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = Math.Round(total - baseImponible, 2)
            End Select
            'End Select

            itemventa.montokardex = baseImponible
            itemventa.montoIgv = Iva
            itemventa.importeMN = total
            'r.SetValue("totalafect", 0)
        End If

        itemventa.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
        AgregarBeneficioProductoDetalleVenta(NumTotalregalos, itemventa.CustomProducto.codigodetalle, itemventa.precioUnitario, itemventa.CustomEquivalencia, itemventa.CustomCatalogo.idCatalogo, "OFERTA", itemventa)
    End Sub

    Private Sub AgregarPromocion(rowIndex As Integer, cantidadVenta As Decimal, CantidadBaseDb As Decimal, ben As detalleitemequivalencia_beneficio, itemventa As documentoventaAbarrotesDet)

        Dim bonificacion = Boolean.Parse(Me.GridCompra.TableModel(rowIndex, 15).CellValue)
        Dim Base As Decimal = cantidadVenta
        Dim BaseDB As Decimal = CantidadBaseDb
        Dim nrollevar As Decimal = BaseDB
        Dim nroPagar As Decimal = ben.valor_beneficio.GetValueOrDefault
        Dim totalpromocionesRegaladas As Decimal = Base / nrollevar

        Dim parteEntera = Int(totalpromocionesRegaladas)
        Dim parteDecimal As Decimal = (totalpromocionesRegaladas) - parteEntera
        If parteDecimal > 0 Then
            parteDecimal = 1
        End If
        Dim Valorregalo As Decimal = nrollevar - nroPagar
        Dim NumTotalregalos As Decimal = parteEntera * Valorregalo
        Dim NumTotalProductosLLevar As Decimal = Base - NumTotalregalos


        If NumTotalProductosLLevar > 0 Then
            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0
            'Dim pu As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 8).CellValue) ' CDec(r.GetValue("precioventa"))
            Dim total As Decimal = 0
            'Dim cantActualizada As Decimal? = NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
            ''r.SetValue("cantidad", cantActualizada)
            'Me.GridCompra.TableModel(rowIndex, 7).CellValue = cantActualizada
            'total = NumTotalregalos * pu ' cantActualizada * pu

            Dim recaudo = CDec(Me.GridCompra.TableModel(rowIndex, 2).CellValue) 'CDec(r.GetValue("gravado"))

            Select Case bonificacion
                Case True
                    baseImponible = 0
                    Iva = 0
                    total = 0
                Case Else
                    Dim pu As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 8).CellValue) 'CDec(r.GetValue("precioventa"))

                    Dim cantActualizada As Decimal? = NumTotalProductosLLevar ' cantidadVenta - NumTotalProductosLLevar
                    'r.SetValue("cantidad", cantActualizada)
                    Me.GridCompra.TableModel(rowIndex, 7).CellValue = cantActualizada
                    total = NumTotalregalos * pu ' cantActualizada * pu

                    Select Case recaudo
                        Case 2
                            baseImponible = total
                            Iva = 0
                        Case Else
                            baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                            Iva = Math.Round(total - baseImponible, 2)
                    End Select
            End Select

            'r.SetValue("vcmn", baseImponible)
            'r.SetValue("igvmn", Iva)
            ''r.SetValue("descuentoMN", descuentoItem)
            'r.SetValue("totalmn", total)
            'r.SetValue("totalafect", 0)
            'r.EndEdit()

            Me.GridCompra.TableModel(rowIndex, 9).CellValue = baseImponible
            Me.GridCompra.TableModel(rowIndex, 10).CellValue = Iva

            Me.GridCompra.TableModel(rowIndex, 11).CellValue = 0
            Me.GridCompra.TableModel(rowIndex, 12).CellValue = total
            Me.GridCompra.TableModel(rowIndex, 17).CellValue = 0
            Me.GridCompra.TableModel(rowIndex, 21).CellValue = 0

            EditarItemVenta(rowIndex)
        End If

        itemventa.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
        Select Case bonificacion
            Case True

            Case Else
                AgregarBeneficioProductoDetalleVenta(NumTotalregalos, itemventa.CustomProducto.codigodetalle, CDec(Me.GridCompra.TableModel(rowIndex, 8).CellValue), itemventa.CustomEquivalencia, itemventa.CustomCatalogo.idCatalogo, "OFERTA", itemventa)
        End Select

    End Sub

    Public Sub GetCalculoItem(rowIndex As Integer)

        If rowIndex <> -1 Then
            Dim bonificacion = If(Boolean.Parse(Me.GridCompra.TableModel(rowIndex, 15).CellValue) = False, True, False)
            Dim recaudo As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 2).CellValue) ' CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 8).CellValue) 'precioventa
            Dim canti As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 7).CellValue)

            Dim descuentoItem As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 17).CellValue)

            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0


            Dim afectacion As String = Me.GridCompra.TableModel(rowIndex, 19).CellValue 'r.GetValue("tipoAfectacion")
            Dim tasa As Decimal = Me.GridCompra.TableModel(rowIndex, 20).CellValue ' CDec(r.GetValue("afectacion"))


            Dim totalicpbc As Decimal = canti * tasa

            Dim total As Decimal = canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))
            total = total - descuentoItem

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(rowIndex, 1).CellValue).SingleOrDefault
            If item IsNot Nothing Then

                'If item.CustomListaVentaDetalle IsNot Nothing Then
                '    If item.CustomListaVentaDetalle.Count > 0 Then
                '        '  r.EndEdit()
                '        ' EditarItemVenta(rowIndex)
                '        EliminarProductosInherits(item.CustomListaVentaDetalle.ToList)
                '        item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
                '    End If
                'End If

                'Me.GridCompra.TableModel(rowIndex, 12).CellValue = total
                'Dim descuentoConfigurado = GetBeneficioItem(rowIndex)

                'If descuentoConfigurado IsNot Nothing Then

                '    Select Case descuentoConfigurado.tipobeneficio
                '        Case "DESCUENTO"
                '            If descuentoConfigurado IsNot Nothing Then

                '                '  r.SetValue("descuentoMN", descuentoConfigurado.valor_beneficio)
                '                Me.GridCompra.TableModel(rowIndex, 17).CellValue = descuentoConfigurado.valor_beneficio

                '                total = total - descuentoConfigurado.valor_beneficio.GetValueOrDefault
                '                ' r.SetValue("totalmn", total)
                '                Me.GridCompra.TableModel(rowIndex, 12).CellValue = total
                '            End If
                '            'Dim sub_total As Decimal = canti * item.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                '            'Dim total As Decimal = sub_total * precioVenta '
                '            Select Case bonificacion
                '                Case True
                '                    baseImponible = 0
                '                    Iva = 0
                '                    total = 0
                '                Case Else
                '                    Select Case recaudo
                '                        Case 2
                '                            baseImponible = total
                '                            Iva = 0
                '                        Case Else
                '                            baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                '                            Iva = Math.Round(total - baseImponible, 2)
                '                    End Select
                '            End Select

                '            'r.SetValue("vcmn", baseImponible)
                '            'r.SetValue("igvmn", Iva)

                '            'r.SetValue("totalmn", total)
                '            'r.SetValue("totalafect", totalicpbc)

                '            Me.GridCompra.TableModel(rowIndex, 9).CellValue = baseImponible
                '            Me.GridCompra.TableModel(rowIndex, 10).CellValue = Iva

                '            Me.GridCompra.TableModel(rowIndex, 11).CellValue = 0
                '            Me.GridCompra.TableModel(rowIndex, 12).CellValue = total
                '            Me.GridCompra.TableModel(rowIndex, 17).CellValue = descuentoItem
                '            Me.GridCompra.TableModel(rowIndex, 21).CellValue = totalicpbc
                '        Case "OFERTA"

                '    End Select
                'End If


                Select Case bonificacion
                    Case True
                        baseImponible = 0
                        Iva = 0
                        total = 0
                    Case Else
                        Select Case recaudo
                            Case 2
                                baseImponible = total
                                Iva = 0
                            Case Else
                                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                Iva = Math.Round(total - baseImponible, 2)
                        End Select
                End Select

                Me.GridCompra.TableModel(rowIndex, 9).CellValue = baseImponible
                Me.GridCompra.TableModel(rowIndex, 10).CellValue = Iva

                Me.GridCompra.TableModel(rowIndex, 11).CellValue = 0
                Me.GridCompra.TableModel(rowIndex, 13).CellValue = total
                Me.GridCompra.TableModel(rowIndex, 16).CellValue = descuentoItem

                'r.SetValue("pumn", 0)
                'r.SetValue("totalmn", total)

                '    EditarItemVenta(rowIndex)
                GridCompra.Refresh()

                GetTotalesDocumento()
            End If
        End If
    End Sub

    Public Sub GetCalculoItemV2(rowIndex As Integer)
        If rowIndex <> -1 Then
            Dim bonificacion = If(Boolean.Parse(Me.GridCompra.TableModel(rowIndex, 15).CellValue) = False, True, False)
            Dim recaudo As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 2).CellValue) ' CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 8).CellValue) 'precioventa
            Dim canti As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 7).CellValue)

            Dim descuentoItem As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 17).CellValue)

            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0
            Dim total As Decimal = 0

            Dim afectacion As String = Me.GridCompra.TableModel(rowIndex, 19).CellValue 'r.GetValue("tipoAfectacion")
            Dim tasa As Decimal = Me.GridCompra.TableModel(rowIndex, 20).CellValue ' CDec(r.GetValue("afectacion"))

            Dim totalicpbc As Decimal = canti * tasa



            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(rowIndex, 1).CellValue).SingleOrDefault
            If item IsNot Nothing Then

                If item.CustomListaVentaDetalle IsNot Nothing Then
                    If item.CustomListaVentaDetalle.Count > 0 Then
                        '  r.EndEdit()
                        'EditarItemVenta(rowIndex)
                        EliminarProductosInherits(item.CustomListaVentaDetalle.ToList)
                        item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
                    End If
                End If

                Select Case bonificacion
                    Case True
                        baseImponible = 0
                        Iva = 0
                        total = 0
                    Case Else
                        total = canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))
                        total = total - descuentoItem

                        Select Case recaudo
                            Case 2
                                baseImponible = total
                                Iva = 0
                            Case Else
                                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                Iva = Math.Round(total - baseImponible, 2)
                        End Select
                End Select

                Me.GridCompra.TableModel(rowIndex, 9).CellValue = baseImponible
                Me.GridCompra.TableModel(rowIndex, 10).CellValue = Iva

                Me.GridCompra.TableModel(rowIndex, 11).CellValue = 0
                Me.GridCompra.TableModel(rowIndex, 12).CellValue = total

                Me.GridCompra.TableModel(rowIndex, 17).CellValue = descuentoItem
                Me.GridCompra.TableModel(rowIndex, 21).CellValue = totalicpbc
                'r.SetValue("pumn", 0)
                'r.SetValue("totalmn", total)

                EditarItemVenta(rowIndex)
                GridCompra.Refresh()

                GetTotalesDocumento()
            End If
        End If
    End Sub

    Private Sub TextBoxExt1_LostFocus(sender As Object, e As EventArgs) Handles TextFiltrar.LostFocus
        'PopupProductos.HidePopup(PopupCloseType.Done)
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
#Region "Precios"
                                    Dim CodigoEQ As String = r.GetValue("tipofraccion")
                                    Dim value As String = r.GetValue("codigo").ToString()
                                    Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

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
                                            r.SetValue("contenido", obEQ.contenido_neto) 'fraccionUnidad)
                                            r.SetValue("tipofraccion", obEQ.equivalencia_id)

                                            Dim catalogo_id = r.GetValue("catalogo")

                                            'Dim catalagoDefault = obEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault
                                            Dim catalagoDefault = obEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = catalogo_id).FirstOrDefault

                                            If catalagoDefault IsNot Nothing Then
                                                r.SetValue("catalogo", catalagoDefault.idCatalogo)
                                                prod.catalogo_id = catalagoDefault.idCatalogo
                                                prod.CustomCatalogo = catalagoDefault
                                            End If

                                            Dim codigo = r.GetValue("codigo")
                                            Dim cantidad = Decimal.Parse(r.GetValue("cantidad"))
                                            Dim idcatalogo = r.GetValue("catalogo")

                                            Dim precioVenta = GetCalculoPrecioVenta(cantidad, codigo, obEQ.equivalencia_id, idcatalogo, r)
                                            r.SetValue("precioventa", precioVenta)
                                    End Select


#End Region
                                    GetCalculoItemV2(GridCompra.Table.CurrentRecord)
                                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "detalle" Then

                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            Dim r As Record = GridCompra.Table.CurrentRecord

                            If text.Trim.Length > 0 Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then


                                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If

                ElseIf style.TableCellIdentity.Column.Name = "totalmn" Or style.TableCellIdentity.Column.Name = "totalme" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            Dim r As Record = GridCompra.Table.CurrentRecord

                            If IsNumeric(text.Trim.Length) Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                    r.SetValue("descuentoMN", 0)
                                    GetCalculoItemImporte(GridCompra.Table.CurrentRecord)
                                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "precioventa" Then

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
                ElseIf style.TableCellIdentity.Column.Name = "descuentoMN" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            Dim r As Record = GridCompra.Table.CurrentRecord

                            If text.Trim.Length > 0 Then
                                Dim topeMaximo = CDec(r.GetValue("cantidad")) * CDec(r.GetValue("precioventa"))
                                Dim montoDescuento As Decimal = CDec(r.GetValue("descuentoMN"))
                                If montoDescuento <= topeMaximo Then
                                    If r IsNot Nothing Then
                                        GetCalculoItemV2(r)
                                        EditarItemVenta(r)
                                    End If
                                Else
                                    cc.Renderer.ControlValue = 0
                                    cc.Renderer.ControlText = 0
                                    MessageBox.Show("El descuento no debe ser mayor a la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If
                    'ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
                    'If cc.Renderer IsNot Nothing Then
                    '    Dim text As String = cc.Renderer.ControlText

                    '    If text.Trim.Length > 0 Then
                    '        If GridCompra.Table.CurrentRecord IsNot Nothing Then
                    '            GetCalculoItem(GridCompra.Table.CurrentRecord)
                    '            EditarItemVenta(GridCompra.Table.CurrentRecord)
                    '            '   FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
                    '        End If
                    '        'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
                    '    End If
                    'End If
                End If
            End If
        End If

    End Sub



    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged

    End Sub

    Private Sub TxtDia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TxtDia.Text.Trim.Length > 0 Then
                e.SuppressKeyPress = True
                cboTipoDoc.Select()
                cboTipoDoc.DroppedDown = True
            End If
        End If

    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub cboTipoDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTipoDoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextNumIdentrazon.Enabled Then
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
            Else
                TextFiltrar.Select()
                TextFiltrar.Focus()
            End If

        End If
    End Sub

    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

    End Sub

    Private Sub cboMoneda_KeyDown(sender As Object, e As KeyEventArgs) Handles cboMoneda.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextNumIdentrazon.SelectAll()
            TextNumIdentrazon.Focus()
        End If
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextFiltrar.TextChanged

    End Sub

    'Private Sub TableControl_DrawCommentIndicator(ByVal sender As Object, ByVal e As DrawCommentIndicatorEventArgs)

    '    If e.ColIndex = 2 Then
    '        e.Cancel = True

    '        'Set the comment indicator color and shape.
    '        e.Graphics.FillRectangle(New SolidBrush(Color.Orange), e.IndicatorBounds)
    '    End If
    'End Sub

    Private col2Check As Boolean = True
    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)

        If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "afectoInventario" Then
            Me.col2Check = Not Me.col2Check

            For Each i In GridCompra.Table.Records
                i.SetValue("afectoInventario", Me.col2Check)

                Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = i.GetValue("codigo")).SingleOrDefault
                If item IsNot Nothing Then
                    With item
                        .AfectoInventario = Me.col2Check
                    End With
                End If
            Next

            e.Inner.Cancel = True
        End If

        Dim r As Record = GridCompra.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridCompra.Table.Records.Count > 0 Then

                If UCPreciosCanastaVenta IsNot Nothing Then
                    ' If UCPreciosCanastaVenta.Visible Then
                    Dim value As String = r.GetValue("codigo").ToString()
                    Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single
                    Dim idEquiva = r.GetValue("tipofraccion").ToString()

                    Select Case prod.tipoExistencia
                        Case TipoExistencia.ServicioGasto

                        Case Else
                            If idEquiva.Trim.Length > 0 Then
                                Dim objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                Dim idCat = r.GetValue("catalogo").ToString()
                                If idCat.Trim.Length > 0 Then
                                    Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                                    UCPreciosCanastaVenta.ListInventario.Items.Clear()
                                    UCbeneficiosCanastaVenta.ListInventario.Items.Clear()
                                    UserControlPreciosCompraVenta.ListInventario.Items.Clear()

                                    If OBJCatalog IsNot Nothing Then
                                        Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                        UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                    End If

                                    Dim ListaBeneficios = objEquivalencia.detalleitemequivalencia_beneficio.ToList
                                    If ListaBeneficios IsNot Nothing Then

                                        UCbeneficiosCanastaVenta.GetDetallePrecios(ListaBeneficios)
                                    End If
                                Else
                                End If
                            End If
                    End Select


                    'End If
                End If

            End If
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextNumIdentrazon.Enabled = False
            cboTipoDoc.Text = "BOLETA"
            TextNumIdentrazon.Text = VarClienteGeneral.idEntidad
            TextProveedor.Text = VarClienteGeneral.nombreCompleto
            TextProveedor.Tag = VarClienteGeneral.idEntidad
            TextProveedor.Enabled = True
            TextProveedor.Focus()
            TextProveedor.SelectAll()

        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TextNumIdentrazon.Enabled = True
            TextNumIdentrazon.Clear()
            TextProveedor.Clear()
            TextProveedor.Enabled = False
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        GrabarEnFormBasico()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If TextProveedor.Tag IsNot Nothing Then

            If Not TextProveedor.Tag = VarClienteGeneral.idEntidad Then

                Dim f As New frmCrearENtidades(CInt(TextProveedor.Tag))
                f.CaptionLabels(0).Text = "Editar Cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.intIdEntidad = TextProveedor.Tag
                'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                Dim cliente = entidadSA.UbicarEntidadPorID(CInt(TextProveedor.Tag)).FirstOrDefault

                If cliente IsNot Nothing Then
                    TextNumIdentrazon.Text = cliente.nrodoc
                    TextProveedor.Text = cliente.nombreCompleto
                    TextProveedor.Tag = cliente.idEntidad
                End If
            Else
                MessageBox.Show("Seleccione Solo RUC O DNI para editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Try
            If TextProveedor.Text.Trim.Length > 0 Then
                Dim f As New FormBuscarVentasGeneral(New entidad With
                                                 {
                                                 .idEntidad = TextProveedor.Tag,
                                                 .nombreCompleto = TextProveedor.Text.Trim,
                                                 .nrodoc = TextNumIdentrazon.Text
                                                 })
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, documento)
                    FormPurchase.UbicarDocumentoImportado(c)
                    ' UbicarDocumentoImportado(c)
                    'dgvCompra.Focus()
                    'Me.dgvCompra.TableControl.CurrentCell.MoveTo(dgvCompra.Table.Records.Count - 1, 7, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                    'dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                    'dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
                    'Me.ActiveControl = Me.dgvCompra.TableControl
                    'dgvCompra.WantTabKey = True
                End If
            Else
                MessageBox.Show("Debe indicar un cliente para consultar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ValidarBusuqedaXML()
        'Creamos el "Document"
        m_xmld = New XmlDocument()

        'Cargamos el archivo
        m_xmld.Load("C:\SPKconfiguration.xml")

        'Obtenemos la lista de los nodos "name"
        m_nodelist = m_xmld.SelectNodes("/spk/company")

        'Iniciamos el ciclo de lectura


        Dim m_nodeAPI = m_xmld.SelectNodes("/spk/company/searchProduct")
        For Each m_node In m_nodeAPI
            'Obtenemos el Elemento RUC
            Dim TipoBusqueda = m_node.ChildNodes.Item(0).InnerText
            If TipoBusqueda.ToString.Trim.Length > 0 Then

                If TipoBusqueda = "1" Then

                    ComboTipoBusqueda.Text = "PRODUCTO"
                ElseIf TipoBusqueda = "2" Then

                    ComboTipoBusqueda.Text = "CODIGO BARRA UC"

                ElseIf TipoBusqueda = "3" Then
                    ComboTipoBusqueda.Text = "CODIGO BARRA"
                End If

            End If
        Next
    End Sub

    Private Sub UCEstructuraCabeceraVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GridCompra.TableModel.Options.AllowScrollCurrentCellInView = GridScrollCurrentCellReason.Click Or GridScrollCurrentCellReason.KeyPress


        ComboTipoBusqueda.Items.Add("SERVICIO")

        GetConfiguracionEmpresa()
        ValidarBusuqedaXML()

    End Sub

    Public Sub GetConfiguracionEmpresa()
        GridCompra.TableDescriptor.Columns("catalogo").Width = 150
        GridCompra.TableDescriptor.Columns("tipofraccion").Width = 140
        GridCompra.TableDescriptor.Columns("afectoInventario").Width = 90
        GridCompra.TableDescriptor.Columns("item").Width = 250

        Select Case tmpConfigInicio.FormatoVenta
            Case "FACT"
                ComboTipoBusqueda.Text = "PRODUCTO"
                ComboTipoBusqueda.Enabled = True
            Case "FACSV"
                ComboTipoBusqueda.Text = "SERVICIO"
                ComboTipoBusqueda.Enabled = False
                GridCompra.TableDescriptor.Columns("catalogo").Width = 0
                GridCompra.TableDescriptor.Columns("tipofraccion").Width = 0
                GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0
                GridCompra.TableDescriptor.Columns("item").Width = 350
            Case Else
                ComboTipoBusqueda.Text = "PRODUCTO"
                ComboTipoBusqueda.Enabled = True
        End Select

        If cboMoneda.Text = "NUEVO SOL" Then
            GridCompra.TableDescriptor.Columns("totalmn").ReadOnly = False
            GridCompra.TableDescriptor.Columns("totalme").ReadOnly = True

        Else
            GridCompra.TableDescriptor.Columns("totalmn").ReadOnly = True
            GridCompra.TableDescriptor.Columns("totalme").ReadOnly = False

        End If
    End Sub

    Private Sub GridCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
            If style3.Enabled Then
                If style3.TableCellIdentity.Column.Name = "bonificacion" Then

                    Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)

                    If sty.TableCellIdentity.DisplayElement.Kind = DisplayElementKind.Record Then
                        Dim record = sty.TableCellIdentity.DisplayElement.GetRecord()

                        Dim valCheck = record.GetValue("bonificacion") 'Me.GridCompra.TableModel(RowIndex, 15).CellValue
                        Select Case valCheck
                            Case "False" 'TRUE

                                Dim bonificacion = If(Boolean.Parse(record.GetValue("bonificacion")) = False, True, False)
                                Dim recaudo As Decimal = record.GetValue("gravado") ' CDec(r.GetValue("gravado"))
                                Dim precioVenta As Decimal = CDec(record.GetValue("precioventa")) 'precioventa
                                Dim canti As Decimal = CDec(record.GetValue("cantidad"))

                                'record.SetValue("totalmn", 0)
                                Select Case cboMoneda.Text
                                    Case "NUEVO SOL"
                                        Dim descuentoItem As Decimal = CDec(record.GetValue("descuentoMN"))

                                        Dim baseImponible As Decimal = 0
                                        Dim Iva As Decimal = 0


                                        Dim afectacion As String = record.GetValue("tipoAfectacion") 'r.GetValue("tipoAfectacion")
                                        Dim tasa As Decimal = CDec(record.GetValue("afectacion")) ' CDec(r.GetValue("afectacion"))


                                        Dim totalicpbc As Decimal = canti * tasa

                                        Dim total As Decimal = canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))
                                        total = total - descuentoItem

                                        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = record.GetValue("codigo")).SingleOrDefault
                                        If item IsNot Nothing Then
                                            item.FlagBonif = "True"
                                            If item.CustomListaVentaDetalle IsNot Nothing Then
                                                If item.CustomListaVentaDetalle.Count > 0 Then
                                                    'record.EndEdit()
                                                    'EditarItemVentaV2(record)
                                                    EliminarProductosInherits(item.CustomListaVentaDetalle.ToList)
                                                    item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
                                                End If
                                            End If


                                            Select Case bonificacion
                                                Case True
                                                    baseImponible = 0
                                                    Iva = 0
                                                    total = 0
                                                Case Else
                                                    Select Case recaudo
                                                        Case 2
                                                            baseImponible = total
                                                            Iva = 0
                                                        Case Else
                                                            baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                                            Iva = Math.Round(total - baseImponible, 2)
                                                    End Select
                                            End Select

                                            record.SetValue("vcmn", baseImponible)
                                            record.SetValue("igvmn", Iva)
                                            record.SetValue("pumn", 0)
                                            record.SetValue("totalmn", total)

                                            'MONEDA EXTRANJERA
                                            record.SetValue("vcme", 0)
                                            record.SetValue("igvme", 0)
                                            record.SetValue("pume", 0)
                                            record.SetValue("totalme", 0)

                                            record.SetValue("descuentoMN", descuentoItem)


                                            EditarItemVentaV2(record)
                                            GridCompra.Refresh()
                                            GetTotalesDocumento()
                                        End If

                                    Case Else 'MONEDA EXTRANJERA


                                        Dim descuentoItem As Decimal = CDec(record.GetValue("descuentoMN"))

                                        Dim baseImponible As Decimal = 0
                                        Dim Iva As Decimal = 0

                                        Dim baseImponibleME As Decimal = 0
                                        Dim IvaME As Decimal = 0


                                        Dim afectacion As String = record.GetValue("tipoAfectacion") 'r.GetValue("tipoAfectacion")
                                        Dim tasa As Decimal = CDec(record.GetValue("afectacion")) ' CDec(r.GetValue("afectacion"))


                                        Dim totalicpbc As Decimal = canti * tasa

                                        Dim totalME As Decimal = Math.Round(canti * precioVenta, 2)
                                        Dim total As Decimal = Math.Round(totalME * txtTipoCambio.DecimalValue, 2)   'Decimal.Parse(r.GetValue("totalmn"))
                                        total = total - descuentoItem
                                        totalME = totalME - descuentoItem

                                        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = record.GetValue("codigo")).SingleOrDefault
                                        If item IsNot Nothing Then
                                            item.FlagBonif = "True"
                                            If item.CustomListaVentaDetalle IsNot Nothing Then
                                                If item.CustomListaVentaDetalle.Count > 0 Then
                                                    'record.EndEdit()
                                                    'EditarItemVentaV2(record)
                                                    EliminarProductosInherits(item.CustomListaVentaDetalle.ToList)
                                                    item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
                                                End If
                                            End If


                                            Select Case bonificacion
                                                Case True
                                                    baseImponible = 0
                                                    Iva = 0
                                                    total = 0

                                                    baseImponibleME = 0
                                                    IvaME = 0
                                                    totalME = 0
                                                Case Else
                                                    Select Case recaudo
                                                        Case 2
                                                            baseImponible = total
                                                            Iva = 0

                                                            baseImponibleME = totalME
                                                            IvaME = 0
                                                        Case Else
                                                            baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                                            Iva = Math.Round(total - baseImponible, 2)

                                                            baseImponibleME = Math.Round(CDec(CalculoBaseImponible(totalME, 1.18)), 2)
                                                            IvaME = Math.Round(totalME - baseImponibleME, 2)
                                                    End Select
                                            End Select

                                            record.SetValue("vcmn", baseImponible)
                                            record.SetValue("igvmn", Iva)
                                            record.SetValue("pumn", 0)
                                            record.SetValue("totalmn", total)

                                            'MONEDA EXTRANJERA
                                            record.SetValue("vcme", baseImponibleME)
                                            record.SetValue("igvme", IvaME)
                                            record.SetValue("pume", 0)
                                            record.SetValue("totalme", totalME)

                                            record.SetValue("descuentoMN", descuentoItem)


                                            EditarItemVentaV2(record)
                                            GridCompra.Refresh()
                                            GetTotalesDocumento()
                                        End If
                                End Select

                                'GetCalculoItem(record)
                                'EditarItemVenta(record)
                                'MessageBox.Show(True)



                            Case Else ' FALSE
                                'GetCalculoItem(record)
                                'EditarItemVenta(record)
                                'MessageBox.Show(False)

                                Dim bonificacion = If(Boolean.Parse(record.GetValue("bonificacion")) = False, True, False)
                                Dim recaudo As Decimal = record.GetValue("gravado") ' CDec(r.GetValue("gravado"))
                                Dim precioVenta As Decimal = CDec(record.GetValue("precioventa")) 'precioventa
                                Dim canti As Decimal = CDec(record.GetValue("cantidad"))

                                Dim descuentoItem As Decimal = CDec(record.GetValue("descuentoMN"))

                                Dim baseImponible As Decimal = 0
                                Dim Iva As Decimal = 0

                                Dim baseImponibleME As Decimal = 0
                                Dim IvaME As Decimal = 0


                                Dim afectacion As String = record.GetValue("tipoAfectacion") 'r.GetValue("tipoAfectacion")
                                Dim tasa As Decimal = CDec(record.GetValue("afectacion")) ' CDec(r.GetValue("afectacion"))
                                Dim totalicpbc As Decimal = canti * tasa

                                Select Case cboMoneda.Text
                                    Case "NUEVO SOL"
                                        Dim total As Decimal = canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))
                                        total = total - descuentoItem

                                        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = record.GetValue("codigo")).SingleOrDefault
                                        If item IsNot Nothing Then
                                            item.FlagBonif = "False"
                                            If item.CustomListaVentaDetalle IsNot Nothing Then
                                                If item.CustomListaVentaDetalle.Count > 0 Then
                                                    'record.EndEdit()
                                                    'EditarItemVentaV2(record)
                                                    EliminarProductosInherits(item.CustomListaVentaDetalle.ToList)
                                                    item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
                                                End If
                                            End If


                                            Select Case bonificacion
                                                Case True
                                                    baseImponible = 0
                                                    Iva = 0
                                                    total = 0
                                                Case Else
                                                    Select Case recaudo
                                                        Case 2
                                                            baseImponible = total
                                                            Iva = 0
                                                        Case Else
                                                            baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                                            Iva = Math.Round(total - baseImponible, 2)
                                                    End Select
                                            End Select

                                            record.SetValue("vcmn", baseImponible)
                                            record.SetValue("igvmn", Iva)
                                            record.SetValue("pumn", 0)
                                            record.SetValue("totalmn", total)

                                            'MONEDA EXTRANJERA
                                            record.SetValue("vcme", 0)
                                            record.SetValue("igvme", 0)
                                            record.SetValue("pume", 0)
                                            record.SetValue("totalme", 0)

                                            record.SetValue("descuentoMN", descuentoItem)
                                            'record.SetValue("bonificacion", bonificacion)
                                            'r.SetValue("pumn", 0)
                                            'r.SetValue("totalmn", total)

                                            EditarItemVentaV2(record)
                                            GridCompra.Refresh()
                                            GetTotalesDocumento()
                                        End If


                                    Case Else 'moneda extranjera
                                        '-------------------------------------------------------------------------------------
                                        Dim totalME As Decimal = Math.Round(canti * precioVenta, 2)  '
                                        Dim total As Decimal = Math.Round(totalME * txtTipoCambio.DecimalValue, 2)   'Decimal.Parse(r.GetValue("totalmn"))
                                        total = total - descuentoItem
                                        totalME = totalME - descuentoItem

                                        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = record.GetValue("codigo")).SingleOrDefault
                                        If item IsNot Nothing Then
                                            item.FlagBonif = "False"
                                            If item.CustomListaVentaDetalle IsNot Nothing Then
                                                If item.CustomListaVentaDetalle.Count > 0 Then
                                                    'record.EndEdit()
                                                    'EditarItemVentaV2(record)
                                                    EliminarProductosInherits(item.CustomListaVentaDetalle.ToList)
                                                    item.CustomListaVentaDetalle = New List(Of documentoventaAbarrotesDet)
                                                End If
                                            End If


                                            Select Case bonificacion
                                                Case True
                                                    baseImponible = 0
                                                    Iva = 0
                                                    total = 0

                                                    baseImponibleME = 0
                                                    IvaME = 0
                                                    totalME = 0
                                                Case Else
                                                    Select Case recaudo
                                                        Case 2
                                                            baseImponible = total
                                                            Iva = 0

                                                            baseImponibleME = totalME
                                                            IvaME = 0
                                                        Case Else
                                                            baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                                            Iva = Math.Round(total - baseImponible, 2)

                                                            baseImponibleME = Math.Round(CDec(CalculoBaseImponible(totalME, 1.18)), 2)
                                                            IvaME = Math.Round(totalME - baseImponibleME, 2)
                                                    End Select
                                            End Select

                                            record.SetValue("vcmn", baseImponible)
                                            record.SetValue("igvmn", Iva)
                                            record.SetValue("pumn", 0)
                                            record.SetValue("totalmn", total)

                                            'MONEDA EXTRANJERA
                                            record.SetValue("vcme", baseImponibleME)
                                            record.SetValue("igvme", IvaME)
                                            record.SetValue("pume", 0)
                                            record.SetValue("totalme", totalME)

                                            record.SetValue("descuentoMN", descuentoItem)
                                            'record.SetValue("bonificacion", bonificacion)
                                            'r.SetValue("pumn", 0)
                                            'r.SetValue("totalmn", total)

                                            EditarItemVentaV2(record)
                                            GridCompra.Refresh()
                                            GetTotalesDocumento()
                                        End If
                                End Select
                        End Select
                        'If lis.Contains(sty.TableCellIdentity.DisplayElement.GetRecord().Id) Then
                        '    e.Inner.Cancel = True
                        'Else
                        '    lis.Add(sty.TableCellIdentity.DisplayElement.GetRecord().Id)
                        '    Me.gridGroupingControl1.Refresh()
                        'End If
                    End If

                    'Dim valCheck = Me.GridCompra.TableModel(RowIndex, 15).CellValue

                ElseIf style3.TableCellIdentity.Column.Name = "afectoInventario" Then
                    Dim afectaStock = Me.GridCompra.TableModel(RowIndex, 19).CellValue
                    Select Case afectaStock
                        Case "False" 'TRUE
                            If RowIndex <> -1 Then
                                Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
                                If item IsNot Nothing Then
                                    With item
                                        .AfectoInventario = True
                                        .estadoEntrega = EstadoTrasladoVenta.EntregaConExito
                                    End With
                                End If
                            End If
                        Case Else ' FALSE
                            If RowIndex <> -1 Then
                                Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
                                If item IsNot Nothing Then
                                    With item
                                        .AfectoInventario = False
                                        .estadoEntrega = EstadoTrasladoVenta.Pedido
                                    End With
                                End If
                            End If
                    End Select
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboTerminosPago.Click

    End Sub

    Private Sub ComboTerminosPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboTerminosPago.SelectedValueChanged
        If ComboTerminosPago.Text = "CONTADO" Then
            If FormPurchase IsNot Nothing AndAlso FormPurchase.UCCondicionesPago IsNot Nothing Then
                FormPurchase.BunifuFlatButton2.Visible = True
                FormPurchase.UCCondicionesPago.RBSi.Checked = True
                FormPurchase.UCCondicionesPago.RBPagoAcumulado.Checked = True
                FormPurchase.btGrabar.Text = "Cobrar - F2"
            End If
        ElseIf ComboTerminosPago.Text = "CREDITO" Then
            If FormPurchase IsNot Nothing AndAlso FormPurchase.UCCondicionesPago IsNot Nothing Then
                FormPurchase.UCCondicionesPago.RBNo.Checked = True
                FormPurchase.BunifuFlatButton2.Visible = False
                FormPurchase.btGrabar.Text = "Guardar - F2"
            End If
        ElseIf ComboTerminosPago.Text = "CRONOGRAMA" Then
            If FormPurchase IsNot Nothing AndAlso FormPurchase.UCCondicionesPago IsNot Nothing Then
                FormPurchase.BunifuFlatButton2.Visible = True
                FormPurchase.UCCondicionesPago.RBSi.Checked = True
                FormPurchase.UCCondicionesPago.RBCronograma.Checked = True
                FormPurchase.btGrabar.Text = "Cobrar - F2"
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'BuscarProducto()
        popup.Show(TryCast(sender, Button))
    End Sub

    Private Sub GridCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridCompra.QueryCellStyleInfo

        If e.TableCellIdentity IsNot Nothing Then
            If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "afectoInventario" Then
                e.Style.CellType = "CheckBox"
                e.Style.Description = e.Style.Text
                e.Style.CellValue = Me.col2Check
                e.Style.Enabled = True
            End If
        End If

        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "tipofraccion" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault
            If prod IsNot Nothing Then
                Select Case prod.tipoExistencia
                    Case TipoExistencia.ServicioGasto

                    Case Else
                        Dim listaEquivalencias = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

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


                'Dim lote As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idLote").ToString()
                'Dim loteDetalle As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idLoteDetalle").ToString()


                If prod IsNot Nothing Then
                    Select Case prod.tipoExistencia
                        Case TipoExistencia.ServicioGasto
                            e.Style.BackColor = Color.FromKnownColor(KnownColor.InactiveBorder)
                            e.Style.TextColor = Color.Black
                            e.Style.Enabled = True
                            ' e.Style.Text = 1
                        Case Else
                            'If lote = "" Then
                            '    e.Style.Enabled = True
                            'Else

                            '    If loteDetalle = "" Then
                            '        e.Style.Enabled = True
                            '    Else
                            '        e.Style.Enabled = False
                            '    End If
                            'End If
                    End Select
                End If


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "igvmn")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "pumn")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "totalmn")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "descuentoMN")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "bonificacion")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                        e.Style.Enabled = False
                        e.Style.Text = False
                    Case Else
                        e.Style.Enabled = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "afectoInventario")) Then

                If FormPurchase.CheckDistribucion.Checked = True Then
                    e.Style.Enabled = False
                    e.Style.Text = False
                Else
                    Select Case FormPurchase.ComboComprobante.Text
                        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                            e.Style.Enabled = False
                            e.Style.Text = True
                        Case Else
                            e.Style.Enabled = True
                    End Select
                End If


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "precioventa")) Then
                Select Case FormPurchase.ComboComprobante.Text
                    Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                        e.Style.Enabled = False
                        e.Style.Text = 0
                    Case Else
                        e.Style.Enabled = True
                End Select
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

        If e.TableCellIdentity.ColIndex > 0 Then
            If e.TableCellIdentity.ColIndex > -1 Then
                Dim el As Element = e.TableCellIdentity.DisplayElement
                Dim r As Record = el.GetRecord()

                If r IsNot Nothing Then
                    ' Dim row As Integer = e.TableCellIdentity.Table.UnsortedRecords.IndexOf(r)

                    Dim codigoItem = r.GetValue("codigo")

                    Dim Item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigoItem).SingleOrDefault
                    If Item Is Nothing Then Exit Sub
                    Select Case Item.tipobeneficio
                        Case "OFERTA"
                            e.Style.ReadOnly = True 'False
                            e.Style.BackColor = ColorTranslator.FromHtml("#FF72E49E") 'Color.LightCyan
                        Case Else
                            e.Style.ReadOnly = False 'True
                    End Select
                    ' If row = 7 Then e.Style.Enabled = False
                End If
            End If

        End If
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
                                r.SetValue("contenido", obEQ.contenido_neto) 'fraccionUnidad)
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

                                Dim precioVenta = GetCalculoPrecioVenta(cantidad, codigo, obEQ.equivalencia_id, idcatalogo, r)
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
                                    UCPreciosCanastaVenta.GetDetallePrecios(catalogoOBJ.detalleitemequivalencia_precios.ToList)
                                End If
                                'Calculando Precio de venta por equivalencia y catalogo
                                Dim precioVenta = GetCalculoPrecioVenta(cantidad, codigo, obEQ.equivalencia_id, CodigoCat, r)
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

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click, BunifuFlatButton5.Click
        Try
            Dim btn = sender
            'Dim btn2 = CType(sender, Button)

            If btn IsNot Nothing Then
                Select Case btn.Text
                    Case "VENTA"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        PanelPrice.Visible = True
                        UCPreciosCanastaVenta.Visible = False
                        UCbeneficiosCanastaVenta.Visible = False
                        UserControlPreciosCompraVenta.Visible = False
                        UCVentaDescripcion.Visible = False
                    Case "INFO. COMPRA"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        PanelPrice.Visible = False
                        UCPreciosCanastaVenta.Visible = False
                        UCbeneficiosCanastaVenta.Visible = False
                        UserControlPreciosCompraVenta.Visible = True
                        UCVentaDescripcion.Visible = False
                        If GridCompra.Table.CurrentRecord IsNot Nothing Then
                            Dim codigoVenta = GridCompra.Table.CurrentRecord.GetValue("codigo")
                            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigoVenta).SingleOrDefault
                            If item Is Nothing Then Exit Sub
                            UserControlPreciosCompraVenta.GetDetalleEntradasDeinventario(item.CustomProducto.codigodetalle)
                        Else
                            MsgBox("Seleccionar un producto!", MsgBoxStyle.Exclamation, "Atención")
                        End If

                    Case "PRECIOS"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        PanelPrice.Visible = False
                        UCbeneficiosCanastaVenta.Visible = False
                        UCPreciosCanastaVenta.Visible = True
                        UserControlPreciosCompraVenta.Visible = False
                        UCVentaDescripcion.Visible = False

                    Case "BENEFICIOS"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        PanelPrice.Visible = False
                        UCPreciosCanastaVenta.Visible = False
                        UCbeneficiosCanastaVenta.Visible = True
                        UserControlPreciosCompraVenta.Visible = False
                        UCVentaDescripcion.Visible = False

                    Case "DESCRIPCION"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        PanelPrice.Visible = False
                        UCPreciosCanastaVenta.Visible = False
                        UCbeneficiosCanastaVenta.Visible = False
                        UserControlPreciosCompraVenta.Visible = False
                        UCVentaDescripcion.Visible = True
                        If (Gempresas.IdEmpresaRuc = "20508447494") Then
                            UCVentaDescripcion.txtDescripcionVenta.Text = "Observaciones: Se entregarán los productos una vez culmine la cuarentena"
                        End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridCompra.TableControlKeyDown
        Try
            If UCPreciosCanastaVenta IsNot Nothing Then
                '   If UCPreciosCanastaVenta.Visible Then
                Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
                If cc.RowIndex > -1 Then
                    If e.Inner.KeyCode = Keys.Up Then
                        If cc IsNot Nothing Then
                            cc.ConfirmChanges()
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
                            '                        Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            'Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                            If currenrecord IsNot Nothing Then
                                Dim value As String = currenrecord.GetValue("codigo").ToString()
                                Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

                                Dim hab = e.TableControl.Table.GetTableCellStyle(currenrecord, "codigo").Enabled

                                If hab = False Then Exit Sub

                                Select Case prod.tipoExistencia
                                    Case TipoExistencia.ServicioGasto

                                    Case Else
                                        Dim idEquiva = currenrecord.GetValue("tipofraccion").ToString()

                                        If idEquiva.Trim.Length > 0 Then
                                            Dim objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                            Dim idCat = currenrecord.GetValue("catalogo").ToString()
                                            If idCat.Trim.Length > 0 Then
                                                Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault
                                                UCPreciosCanastaVenta.ListInventario.Items.Clear()
                                                UCbeneficiosCanastaVenta.ListInventario.Items.Clear()
                                                UserControlPreciosCompraVenta.ListInventario.Items.Clear()
                                                If OBJCatalog IsNot Nothing Then

                                                    Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)

                                                    UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                                End If

                                                Dim ListaBeneficios = objEquivalencia.detalleitemequivalencia_beneficio.ToList
                                                If ListaBeneficios IsNot Nothing Then
                                                    UCbeneficiosCanastaVenta.GetDetallePrecios(ListaBeneficios)
                                                End If
                                            Else
                                            End If
                                        End If
                                End Select


                            End If

                        End If
                    ElseIf e.Inner.KeyCode = Keys.Down Then
                        If cc IsNot Nothing Then
                            cc.ConfirmChanges()
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex + 1, cc.ColIndex), GridTableCellStyleInfo)
                            If style.TableCellIdentity IsNot Nothing Then
                                Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                                Dim hab = e.TableControl.Table.GetTableCellStyle(currenrecord, "codigo").Enabled
                                Dim rowsTotal = GridCompra.Table.Records.Count ' - 1
                                Dim filaSel = cc.RowIndex ' + 1
                                If filaSel > rowsTotal Then
                                    'enviar a la primera fila
                                    'Dim colIndex As Integer = GridCompra.TableDescriptor.FieldToColIndex(0)
                                    'Dim rowIndex As Integer = GridCompra.Table.Records(0).GetRowIndex()
                                    'Me.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                                End If
                                ' Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                                '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                                If currenrecord IsNot Nothing Then
                                    If hab Then
                                        Dim value As String = currenrecord.GetValue("codigo").ToString()
                                        Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

                                        Select Case prod.tipoExistencia
                                            Case TipoExistencia.ServicioGasto

                                            Case Else
                                                Dim idEquiva = currenrecord.GetValue("tipofraccion").ToString()

                                                If idEquiva.Trim.Length > 0 Then
                                                    Dim objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                                    Dim idCat = currenrecord.GetValue("catalogo").ToString()
                                                    If idCat.Trim.Length > 0 Then
                                                        Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault

                                                        UCPreciosCanastaVenta.ListInventario.Items.Clear()
                                                        UCbeneficiosCanastaVenta.ListInventario.Items.Clear()
                                                        UserControlPreciosCompraVenta.ListInventario.Items.Clear()
                                                        If OBJCatalog IsNot Nothing Then
                                                            Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                                            UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                                        End If

                                                        Dim ListaBeneficios = objEquivalencia.detalleitemequivalencia_beneficio.ToList
                                                        If ListaBeneficios IsNot Nothing Then
                                                            UCbeneficiosCanastaVenta.GetDetallePrecios(ListaBeneficios)
                                                        End If
                                                    Else
                                                    End If
                                                End If
                                        End Select
                                    Else
                                        Dim colIndex As Integer = GridCompra.TableDescriptor.FieldToColIndex(2)
                                        Dim rowIndex As Integer = cc.RowIndex ' GridCompra.Table.Records(0).GetRowIndex()
                                        Me.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex - 1, 4, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                                        GridCompra.Focus()

                                    End If

                                End If
                            End If

                        End If

                    Else
                        If cc IsNot Nothing Then
                            cc.ConfirmChanges()
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                            'Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            'Dim currenrecord As Record = style.TableCellIdentity.Table.CurrentRecord
                            If style.TableCellIdentity Is Nothing Then Exit Sub

                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim hab = e.TableControl.Table.GetTableCellStyle(currenrecord, "codigo").Enabled
                            '  Dim idProducto As Integer = Integer.Parse(currenrecord.GetValue("idproducto"))
                            If hab = False Then Exit Sub
                            If currenrecord IsNot Nothing Then
                                Dim value As String = currenrecord.GetValue("codigo").ToString()
                                Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

                                Select Case prod.tipoExistencia
                                    Case TipoExistencia.ServicioGasto

                                    Case Else
                                        Dim idEquiva = currenrecord.GetValue("tipofraccion").ToString()

                                        If idEquiva.Trim.Length > 0 Then
                                            Dim objEquivalencia = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = idEquiva).Single
                                            Dim idCat = currenrecord.GetValue("catalogo").ToString()
                                            If idCat.Trim.Length > 0 Then
                                                Dim OBJCatalog = objEquivalencia.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = idCat).SingleOrDefault
                                                UCPreciosCanastaVenta.ListInventario.Items.Clear()
                                                UCbeneficiosCanastaVenta.ListInventario.Items.Clear()
                                                UserControlPreciosCompraVenta.ListInventario.Items.Clear()
                                                If OBJCatalog IsNot Nothing Then
                                                    Dim lista = ConvertirPreciosArangos(OBJCatalog.detalleitemequivalencia_precios.ToList)
                                                    UCPreciosCanastaVenta.GetDetallePrecios(lista)
                                                End If

                                                Dim ListaBeneficios = objEquivalencia.detalleitemequivalencia_beneficio.ToList
                                                If ListaBeneficios IsNot Nothing Then
                                                    UCbeneficiosCanastaVenta.GetDetallePrecios(ListaBeneficios)
                                                End If
                                            Else
                                            End If
                                        End If
                                End Select


                            End If


                        End If
                    End If
                End If
                '  End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#Region "Sunat"

#End Region

    Private Sub TextNumIdentrazon_TextChanged(sender As Object, e As EventArgs) Handles TextNumIdentrazon.TextChanged

    End Sub

    Private Sub BgProveedor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgProveedor.DoWork
        GetConsultaSunatThread(TextNumIdentrazon.Text)
    End Sub

    Private Sub GetConsultaSunatThread(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then

            'getRuc donde ase llama como el company
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim datosSunat = New Helios.Sunat.Consulta.GetConsultaSunat()
            'Dim company = datosSunat.GetConsultaRuc(ruc)

            '  Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "CL"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.nrodoc = company.Ruc
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                End If

            Else

            End If
        ElseIf nroDoc = "2" Then
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "J"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "CL"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                    SelRazon.nrodoc = company.Ruc

                End If
            Else

            End If
        End If
    End Sub

    'Private Sub GetConsultaSunatThreadV2(ruc As String)
    '    SelRazon = New entidad
    '    Dim nroDoc = ruc.Substring(0, 1).ToString
    '    If nroDoc = "1" Then

    '        'getRuc donde ase llama como el company
    '        Dim sunat As New Helios.Consultas.Sunat.Sunat()
    '        sunat.GenerateCapchaTemporal()
    '        Dim valorCapcha = sunat.Decode_CapchaTemporal()
    '        Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

    '        'Dim datosSunat = New Helios.Sunat.Consulta.GetConsultaSunat()
    '        'Dim company = datosSunat.GetConsultaRuc(ruc)

    '        '  Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
    '        If company.Ruc IsNot Nothing Then
    '            If company.RazonSocial = "ERROR" Then

    '            Else
    '                SelRazon.tipoPersona = "N"
    '                SelRazon.tipoDoc = "6"
    '                SelRazon.tipoEntidad = "CL"
    '                SelRazon.nombreCompleto = company.RazonSocial
    '                SelRazon.nombreContacto = company.RazonSocial
    '                SelRazon.estado = company.Estado_Contribuyente
    '                SelRazon.nrodoc = company.Ruc
    '                SelRazon.direccion = company.DireccionDomicilioFiscal
    '            End If

    '        Else

    '        End If
    '    ElseIf nroDoc = "2" Then
    '        Dim sunat As New Helios.Consultas.Sunat.Sunat()
    '        sunat.GenerateCapchaTemporal()
    '        Dim valorCapcha = sunat.Decode_CapchaTemporal()
    '        Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

    '        'Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
    '        If company.Ruc IsNot Nothing Then
    '            'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
    '            If company.RazonSocial = "ERROR" Then

    '            Else
    '                SelRazon.tipoPersona = "J"
    '                SelRazon.tipoDoc = "6"
    '                SelRazon.tipoEntidad = "CL"
    '                SelRazon.nombreCompleto = company.RazonSocial
    '                SelRazon.nombreContacto = company.RazonSocial
    '                SelRazon.estado = company.Estado_Contribuyente
    '                SelRazon.direccion = company.DireccionDomicilioFiscal
    '                SelRazon.nrodoc = company.Ruc

    '            End If
    '        Else

    '        End If
    '    End If
    'End Sub

    Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgProveedor.RunWorkerCompleted
        If SelRazon.nrodoc IsNot Nothing Then
            SelRazon.tipoEntidad = "CL"
            SelRazon.nombreCompleto = SelRazon.nombreCompleto.ToString.Replace(Chr(34), "")
            GrabarEntidadRapidaThread()
            TextNumIdentrazon.Text = SelRazon.nrodoc
            TextProveedor.Text = SelRazon.nombreCompleto
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextFiltrar.Select()

        Else
            TextProveedor.Clear()
            TextProveedor.Tag = Nothing
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextNumIdentrazon.Select()
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub GrabarEntidadRapidaThread()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = SelRazon.nombreCompleto
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                                   .Action = BaseBE.EntityAction.INSERT,
                                                   .tipo = "DOMICILIO",
                                                   .estado = 1,
                                                   .valorAtributo = SelRazon.direccion,
                                                   .usuarioModificacion = usuario.IDUsuario,
                                                   .fechaModificacion = Date.Now
                                                   })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad

            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Sub TextDescuento_TextChanged(sender As Object, e As EventArgs) Handles TextDescuento.TextChanged
        If TextDescuento.DecimalValue > TextSubTotal.DecimalValue Then
            TextDescuento.DecimalValue = 0
        End If
        GetTotalesDocumento()
    End Sub

    Private Sub ButtonAddServicio_Click(sender As Object, e As EventArgs) Handles ButtonAddServicio.Click
        If TextFiltrar.Text.Trim.Length > 0 Then
            AgregarServicioDetalleVenta(1, 0, 1)
            TextFiltrar.Clear()
            TextFiltrar.Select()
        Else
            MessageBox.Show("Describir el servicio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextFiltrar.Select()
        End If
    End Sub

    Private Sub ComboTipoBusqueda_Click(sender As Object, e As EventArgs) Handles ComboTipoBusqueda.Click

    End Sub

    Private Sub ComboTipoBusqueda_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboTipoBusqueda.SelectedValueChanged
        Select Case ComboTipoBusqueda.Text
            Case "PRODUCTO"
                ButtonAddServicio.Visible = False
                TextFiltrar.Clear()
                TextFiltrar.Select()

                TextFiltrar.Visible = True
                ComboTipoCategorias.Visible = False

            Case "SERVICIO"
                ButtonAddServicio.Visible = True
                TextFiltrar.Clear()
                TextFiltrar.Select()

                TextFiltrar.Visible = True
                ComboTipoCategorias.Visible = False

            Case "CODIGO BARRA"
                ButtonAddServicio.Visible = False
                TextFiltrar.Clear()
                TextFiltrar.Select()


                TextFiltrar.Visible = True
                ComboTipoCategorias.Visible = False
            Case "CODIGO INTERNO"
                ButtonAddServicio.Visible = False
                TextFiltrar.Clear()
                TextFiltrar.Select()

                TextFiltrar.Visible = True
                ComboTipoCategorias.Visible = False



            Case "CATEGORIA"
                TextFiltrar.Visible = False
                ComboTipoCategorias.Visible = True
                AgregarComboXTipoCategoria(TipoGrupoArticulo.CategoriaGeneral)
                ComboTipoCategorias.Select()

            Case "SUBCATEGORIA"
                TextFiltrar.Visible = False
                ComboTipoCategorias.Visible = True
                AgregarComboXTipoCategoria(TipoGrupoArticulo.SubCategoriaGeneral)
                ComboTipoCategorias.Select()

            Case "MARCA"
                TextFiltrar.Visible = False
                ComboTipoCategorias.Visible = True
                AgregarComboXTipoCategoria(TipoGrupoArticulo.Marca)
                ComboTipoCategorias.Select()

            Case "PRESENTACION/MODELO"
                ButtonAddServicio.Visible = False
                TextFiltrar.Clear()
                TextFiltrar.Select()
                TextFiltrar.Visible = True
                ComboTipoCategorias.Visible = False

            Case "COLOR"
                ButtonAddServicio.Visible = False
                TextFiltrar.Clear()
                TextFiltrar.Select()
                TextFiltrar.Visible = True
                ComboTipoCategorias.Visible = False

            Case "TALLA"
                ButtonAddServicio.Visible = False
                TextFiltrar.Clear()
                TextFiltrar.Select()
                TextFiltrar.Visible = True
                ComboTipoCategorias.Visible = False
        End Select

    End Sub

    Private Sub TextFiltrar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextFiltrar.KeyPress
        Dim re As New Regex("^[|_''!°@#[]$%&/()=?¿.¡}´]*$", RegexOptions.IgnoreCase)
        e.Handled = re.IsMatch(e.KeyChar)
    End Sub

    Private Sub RBFullName_CheckedChanged(sender As Object, e As EventArgs) Handles RBFullName.CheckedChanged
        If RBFullName.Checked = True Then
            TextNumIdentrazon.Enabled = False
            TextProveedor.Enabled = True
            TextProveedor.Focus()
            TextProveedor.SelectAll()

        End If
    End Sub

    Private Sub TextProveedor_TextChanged(sender As Object, e As EventArgs) Handles TextProveedor.TextChanged
        If RBFullName.Checked = True Then
            TextProveedor.ForeColor = Color.Black
            TextProveedor.Tag = Nothing
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

    Private Sub TextProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TextProveedor.KeyDown
        If RBFullName.Checked = True Then
            Dim entidadSA As New entidadSA
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            Else
                If e.KeyCode = Keys.Enter Then
                    e.SuppressKeyPress = True
                    Dim consulta = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, "CL", TextProveedor.Text.Trim)

                    If consulta.Count > 0 Then
                        FillLSVClientes(consulta)
                        Me.pcLikeCategoria.Size = New Size(282, 128)
                        Me.pcLikeCategoria.ParentControl = Me.TextProveedor
                        Me.pcLikeCategoria.ShowPopup(Point.Empty)
                    End If
                    e.Handled = True
                End If
            End If

            If e.KeyCode = Keys.Down Then
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                If LsvProveedor.Items.Count > 0 Then
                    Me.pcLikeCategoria.Size = New Size(282, 128)
                    Me.pcLikeCategoria.ParentControl = Me.TextProveedor
                    Me.pcLikeCategoria.ShowPopup(Point.Empty)
                    LsvProveedor.Focus()
                End If
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                If Me.pcLikeCategoria.IsShowing() Then
                    Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
                End If
            End If
        End If

    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then

                    TextProveedor.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TextProveedor.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    TextNumIdentrazon.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextProveedor.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub GridCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                'If style.TableCellIdentity.Column.Name = "descuentoMN" Then
                '    If cc.Renderer IsNot Nothing Then

                '        If e.TableControl.Model.Modified = True Then
                '            Dim text As String = cc.Renderer.ControlText

                '            Dim r As Record = GridCompra.Table.CurrentRecord

                '            If IsNumeric(text.Trim.Length) Then
                '                Dim topeMaximo = CDec(r.GetValue("cantidad")) * CDec(r.GetValue("precioventa"))
                '                Dim montoDescuento As Decimal = CDec(r.GetValue("descuentoMN"))

                '                If montoDescuento <= topeMaximo Then
                '                    If GridCompra.Table.CurrentRecord IsNot Nothing Then
                '                        GetCalculoItemV2(GridCompra.Table.CurrentRecord)
                '                        EditarItemVenta(GridCompra.Table.CurrentRecord)
                '                    End If
                '                Else
                '                    cc.Renderer.ControlValue = 0
                '                    cc.Renderer.ControlText = 0
                '                    r.SetValue("descuentoMN", 0)
                '                    MessageBox.Show("El descuento no debe ser mayor a la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '                    GetCalculoItemV2(r)
                '                    EditarItemVenta(r)
                '                    Exit Sub
                '                End If
                '                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                '            End If
                '        End If
                '    End If
                'Else
                If style.TableCellIdentity.Column.Name = "cantidad" Then
                    If cc.Renderer IsNot Nothing Then

                        '                        If e.TableControl.Model.Modified = True Then
                        '                            Dim text As String = cc.Renderer.ControlText

                        '                            Dim r As Record = GridCompra.Table.CurrentRecord

                        '                            If IsNumeric(text.Trim.Length) Then
                        '                                If GridCompra.Table.CurrentRecord IsNot Nothing Then

                        '#Region "Precios"
                        '                                    Dim CodigoEQ As String = r.GetValue("tipofraccion")
                        '                                    Dim value As String = r.GetValue("codigo").ToString()
                        '                                    Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

                        '                                    Select Case prod.tipoExistencia
                        '                                        Case TipoExistencia.ServicioGasto

                        '                                        Case Else
                        '                                            Dim listaEquivalencias = prod.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.estado = "A").ToList

                        '                                            'Dim idEquivalencia = r.GetValue("tipofraccion")
                        '                                            Dim obEQ As detalleitem_equivalencias
                        '                                            If IsNumeric(CodigoEQ) Then
                        '                                                obEQ = listaEquivalencias.Where(Function(i) i.equivalencia_id = (CodigoEQ)).SingleOrDefault
                        '                                            Else
                        '                                                obEQ = listaEquivalencias.Where(Function(i) i.unidadComercial = (CodigoEQ)).SingleOrDefault
                        '                                            End If

                        '                                            prod.CustomEquivalencia = obEQ
                        '                                            r.SetValue("contenido", obEQ.fraccionUnidad)
                        '                                            r.SetValue("tipofraccion", obEQ.equivalencia_id)

                        '                                            Dim catalogo_id = r.GetValue("catalogo")

                        '                                            'Dim catalagoDefault = obEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault
                        '                                            Dim catalagoDefault = obEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = catalogo_id).FirstOrDefault

                        '                                            If catalagoDefault IsNot Nothing Then
                        '                                                r.SetValue("catalogo", catalagoDefault.idCatalogo)
                        '                                                prod.catalogo_id = catalagoDefault.idCatalogo
                        '                                                prod.CustomCatalogo = catalagoDefault
                        '                                            End If

                        '                                            Dim codigo = r.GetValue("codigo")
                        '                                            Dim cantidad = Decimal.Parse(r.GetValue("cantidad"))
                        '                                            Dim idcatalogo = r.GetValue("catalogo")

                        '                                            Dim precioVenta = GetCalculoPrecioVenta(cantidad, codigo, obEQ.equivalencia_id, idcatalogo, r)
                        '                                            r.SetValue("precioventa", precioVenta)
                        '                                    End Select


                        '#End Region

                        '                                    Select Case prod.tipoExistencia
                        '                                        Case TipoExistencia.ServicioGasto
                        '                                            GetCalculoItemV2(GridCompra.Table.CurrentRecord)
                        '                                        Case Else
                        '                                            GetCalculoItem(GridCompra.Table.CurrentRecord)
                        '                                    End Select


                        '                                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                        '                                End If
                        '                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                        '                            End If
                        '                        End If
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "gravado" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            Dim r As Record = GridCompra.Table.CurrentRecord

                            If IsNumeric(text.Trim.Length) Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then

#Region "Precios"
                                    Dim CodigoEQ As String = r.GetValue("tipofraccion")
                                    Dim value As String = r.GetValue("codigo").ToString()
                                    Dim prod = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

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
                                            r.SetValue("contenido", obEQ.contenido_neto) 'fraccionUnidad)
                                            r.SetValue("tipofraccion", obEQ.equivalencia_id)

                                            Dim catalogo_id = r.GetValue("catalogo")

                                            'Dim catalagoDefault = obEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.predeterminado = True).FirstOrDefault
                                            Dim catalagoDefault = obEQ.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = catalogo_id).FirstOrDefault

                                            If catalagoDefault IsNot Nothing Then
                                                r.SetValue("catalogo", catalagoDefault.idCatalogo)
                                                prod.catalogo_id = catalagoDefault.idCatalogo
                                                prod.CustomCatalogo = catalagoDefault
                                            End If

                                            Dim codigo = r.GetValue("codigo")
                                            Dim cantidad = Decimal.Parse(r.GetValue("cantidad"))
                                            Dim idcatalogo = r.GetValue("catalogo")

                                            Dim precioVenta = GetCalculoPrecioVenta(cantidad, codigo, obEQ.equivalencia_id, idcatalogo, r)
                                            r.SetValue("precioventa", precioVenta)
                                    End Select


#End Region

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

    Private Sub BunifuCheckbox1_OnChange(sender As Object, e As EventArgs) Handles BunifuCheckbox1.OnChange
        If BunifuCheckbox1.Checked = True Then
            GridCompra.TableDescriptor.Columns("detalle").Width = 120

        ElseIf BunifuCheckbox1.Checked = False Then

            GridCompra.TableDescriptor.Columns("detalle").Width = 0
        End If
    End Sub

    Private Sub GridCompra_TableControlPrepareViewStyleInfo(sender As Object, e As GridTableControlPrepareViewStyleInfoEventArgs) Handles GridCompra.TableControlPrepareViewStyleInfo
        If e.Inner.RowIndex > 0 AndAlso e.Inner.ColIndex > 0 Then

            Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
            'cc.ConfirmChanges()
            If cc.Renderer IsNot Nothing Then
                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)
                    If style.TableCellIdentity.Column.Name = "item" Then
                        e.Inner.Style.WrapText = False
                        e.Inner.Style.Trimming = StringTrimming.EllipsisCharacter
                        '  e.Inner.Style.CellTipText = e.Inner.Style.Text
                        'Else
                        '    e.Inner.Style.WrapText = False
                        '    e.Inner.Style.Trimming = StringTrimming.EllipsisCharacter
                        'e.Inner.Style.CellTipText = e.Inner.Style.Text
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlCurrentCellValidated(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellValidated

    End Sub

    Private Sub GridCompra_TableControlCurrentCellAcceptedChanges(sender As Object, e As GridTableControlCancelEventArgs) Handles GridCompra.TableControlCurrentCellAcceptedChanges
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        ''cc.ConfirmChanges()
        'If cc.Renderer IsNot Nothing Then

        '    If cc.ColIndex > -1 Then
        '        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        '        Select Case style.TableCellIdentity.Column.Name
        '            Case "descuentoMN" ', "rangofin", "tipoprecio", "PrecioContado", "PrecioCredito", "PrecioContadoUSD", "PrecioCreditoUSD"
        '                If cc.Renderer IsNot Nothing Then

        '                    Dim oldValue = CDec(Me.GridCompra.TableModel(cc.RowIndex, 17).CellValue)
        '                    Dim newValue = CDec(cc.Renderer.ControlText)
        '                    Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
        '                    If oldValue <> newValue Then
        '                        Dim text As String = cc.Renderer.ControlText
        '                        If text.Trim.Length > 0 Then
        '                            Dim mensaje = $"Descto. nuevo: {newValue}, Dscto. anterior: {oldValue} {vbCrLf} Guardar cambios?"
        '                            If MessageBox.Show(mensaje, "(%)Descuentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

        '                                If r IsNot Nothing Then
        '                                    r.SetValue("descuentoMN", newValue)
        '                                    '  EditarPrecio(r)
        '                                    Dim topeMaximo = CDec(r.GetValue("cantidad")) * CDec(r.GetValue("precioventa"))
        '                                    Dim montoDescuento As Decimal = CDec(r.GetValue("descuentoMN"))

        '                                    If montoDescuento <= topeMaximo Then
        '                                        ' If GridCompra.Table.CurrentRecord IsNot Nothing Then
        '                                        GetCalculoItemV2(r)
        '                                        EditarItemVenta(r)
        '                                        'End If
        '                                    Else
        '                                        cc.Renderer.ControlValue = 0
        '                                        cc.Renderer.ControlText = 0
        '                                        r.SetValue("descuentoMN", 0)
        '                                        MessageBox.Show("El descuento no debe ser mayor a la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                                        GetCalculoItemV2(r)
        '                                        EditarItemVenta(r)
        '                                        Me.GridCompra.TableModel(cc.RowIndex, 17).CellValue = oldValue
        '                                        Me.GridCompra.EndUpdate(True)
        '                                        Exit Sub
        '                                    End If


        '                                End If
        '                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '                            Else
        '                                cc.RejectChanges()
        '                                Me.GridCompra.TableModel(cc.RowIndex, 17).CellValue = oldValue
        '                                Me.GridCompra.EndUpdate(True)
        '                            End If
        '                        End If
        '                    End If
        '                End If
        '        End Select


        '    End If
        'End If
    End Sub

    Private Sub TxtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged
        ChangeRowsTipoCambio()
    End Sub

    Private Sub ComboTipoCategorias_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboTipoCategorias.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If ComboTipoBusqueda.Text.Trim.Length > 0 Then


                Select Case ComboTipoBusqueda.Text

                    Case "CATEGORIA"

                        'If combotipoalmacen.Text = "TODOS" Then
                        BuscarProducto("CATEGORIA")
                        'Else
                        '    BuscarProductoxAlmacen("CATEGORIA", combotipoalmacen.SelectedValue)
                        'End If



                        If listaProductos.Count > 0 Then
                            popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.ComboBoxAdv))
                            PictureLoadingProduct.Visible = False



                            Dim colIndex As Integer = Me.usercontrol.GridCompra.TableDescriptor.FieldToColIndex(0)
                            Dim rowIndex As Integer = Me.usercontrol.GridCompra.Table.Records(0).GetRowIndex()
                            Me.usercontrol.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)

                        Else

                            PictureLoadingProduct.Visible = False
                        End If
                    Case "SUBCATEGORIA"



                        'If combotipoalmacen.Text = "TODOS" Then
                        BuscarProducto("SUBCATEGORIA")
                        'Else
                        '    BuscarProductoxAlmacen("SUBCATEGORIA", combotipoalmacen.SelectedValue)
                        'End If

                        If listaProductos.Count > 0 Then
                            popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.ComboBoxAdv))
                            PictureLoadingProduct.Visible = False


                            Dim colIndex As Integer = Me.usercontrol.GridCompra.TableDescriptor.FieldToColIndex(0)
                            Dim rowIndex As Integer = Me.usercontrol.GridCompra.Table.Records(0).GetRowIndex()
                            Me.usercontrol.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)

                        Else

                            PictureLoadingProduct.Visible = False
                        End If

                    Case "MARCA"


                        'If combotipoalmacen.Text = "TODOS" Then
                        BuscarProducto("MARCA")
                        'Else
                        '    BuscarProductoxAlmacen("MARCA", combotipoalmacen.SelectedValue)
                        'End If

                        If listaProductos.Count > 0 Then
                            popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.ComboBoxAdv))
                            PictureLoadingProduct.Visible = False

                            Dim colIndex As Integer = Me.usercontrol.GridCompra.TableDescriptor.FieldToColIndex(0)
                            Dim rowIndex As Integer = Me.usercontrol.GridCompra.Table.Records(0).GetRowIndex()
                            Me.usercontrol.GridCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)

                        Else

                            PictureLoadingProduct.Visible = False
                        End If

                End Select

            End If




        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click

    End Sub

#End Region

End Class
