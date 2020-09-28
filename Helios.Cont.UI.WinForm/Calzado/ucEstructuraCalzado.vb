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
Imports Newtonsoft.Json

Public Class ucEstructuraCalzado

    Public Property entidadSA As New entidadSA

    Public Property ListaDocumentos As List(Of tabladetalle)

    Private Property SelRazon As entidad

    Dim tallaSA As New tallaSA

    Public ReadOnly Property _formVentaCalzados As FormVentaCalzados


    Public Sub New(FormVentaCalzados As FormVentaCalzados)

        ' This call is required by the designer.
        InitializeComponent()
        _formVentaCalzados = FormVentaCalzados
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridTallasStock, False, False, 12.0F, SelectionMode.One)
        FormatoGridAvanzado(GridTallaDetails, False, False, 12.0F, SelectionMode.One)
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        ' Add any initialization after the InitializeComponent() call.

        GetTablasGenerales()
        LoadTablaEquivalencias()
        Me.GridCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.Trimming = StringTrimming.EllipsisCharacter
        Me.GridCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.HorizontalAlignment = GridHorizontalAlignment.Left
        Me.GridCompra.TableControl.CellToolTip.AutomaticDelay = 25000
    End Sub

#Region "Methods"
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

    Private Sub GetTablasGenerales()
        Dim listaMoneda = General.TablasGenerales.GetMonedas()
        ListaDocumentos = GetComprobantesCompra()
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9907", .descripcion = "NOTA"})
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9903", .descripcion = "PROFORMA"})
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "1000", .descripcion = "PRE VENTA"})

        'cboMesCompra.DataSource = General.ListaDeMeses()
        'cboMesCompra.DisplayMember = "Mes"
        'cboMesCompra.ValueMember = "Codigo"
        'cboMesCompra.SelectedValue = String.Format("{0:00}", Date.Now.Month)
        'TextAnio.DecimalValue = Date.Now.Year

        cboMoneda.DataSource = listaMoneda
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.ValueMember = "codigoDetalle"


        cboTipoDoc.DataSource = ListaDocumentos
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"

        'Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl

        'Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.DisplayMember = "detalle"
        'Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"
        'txtHora.Value = Date.Now
        'TxtDia.DecimalValue = Date.Now.Day

        Select Case tmpConfigInicio.FormatoVenta
            Case "FACT"
                GridCompra.TableDescriptor.Columns("afectoInventario").ReadOnly = True
            Case Else
                GridCompra.TableDescriptor.Columns("afectoInventario").ReadOnly = False
        End Select

        _formVentaCalzados.txtTotalPagar.OuterFrameGradientStartColor = Color.White
        _formVentaCalzados.txtTotalPagar.OuterFrameGradientEndColor = Color.White
        _formVentaCalzados.txtTotalPagar.ForeColor = Color.Purple

        'DigitalME.OuterFrameGradientStartColor = Color.White
        'DigitalME.OuterFrameGradientEndColor = Color.White
        'DigitalME.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

    End Sub



    Private Function GetConsultarDNIReniec(Dni As String) As String
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
                'TextFiltrar.Select()
                'TextFiltrar.Focus()
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
        SelRazon = New entidad()

        Using client = New HttpClient()

            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If

            'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")
            Dim responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)
            ' responseTask.Wait()
            'Dim result = responseTask.Result

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
                SelRazon.direccion = students.Direccion

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
        Dim producto = _formVentaCalzados.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

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
            Dim talla = CType(TextTallaSel.Tag, talla_equivalencias)

            If talla Is Nothing Then Exit Sub

            Dim catalogoOBJ = eq.detalleitemequivalencia_catalogos.Where(Function(c) c.idCatalogo = CatalogoPrecio).SingleOrDefault

            obj = New documentoventaAbarrotesDet
            obj.CustomtotalesAlmacenOthers = New totalesAlmacenOthers With
            {
            .idProducto = producto.codigodetalle,
            .id_equivalencia = talla.id_equivalencia,
            .idcategoria = producto.item.idItem,
            .idalmacen = 0,
            .genero = Combogenero.SelectedValue,
            .cantidad = cantidad * -1,
            .tipoRegistro = "S",
            .status = 1
            }

            Dim cod = System.Guid.NewGuid.ToString()

            'Select Case tmpConfigInicio.FormatoVenta
            '    Case "FACT"
            '        obj.AfectoInventario = False
            '    Case Else
            '        obj.AfectoInventario = producto.AfectoStock.GetValueOrDefault ' True
            'End Select

            obj.AfectoInventario = True

            obj.CodigoCosto = cod
            obj.ContenidoNetoUnidadComercialMaxima = eq.contenido ' UnidadComercialMaxima.contenido ' UnidadComercialMaxima.fraccionUnidad
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
            _formVentaCalzados.ListaproductosVendidos.Add(obj)
            LoadCanastaVentas(_formVentaCalzados.ListaproductosVendidos)
            GetTotalesDocumento()
        End If

        ' MsgBox(listViewItem.SubItems(1).Text)
    End Sub

    Public Sub GetTotalesDocumento()
        Dim sumaTotal As Decimal = 0
        Dim sumaBaseImponible1 As Decimal = 0
        Dim sumaBaseImponible2 As Decimal = 0
        Dim sumaIva1 As Decimal = 0
        Dim sumaIva2 As Decimal = 0
        Dim descuento As Decimal = 0 ' TextDescuento.DecimalValue
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
            Dim Item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigoItem).SingleOrDefault

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
        'TextSubTotal.DecimalValue = sumaTotal
        _formVentaCalzados.txtTotalPagar.Value = (sumaTotal - descuento + sumaIcbper).ToString("N2")
        '  DigitalME.Value = (sumaTotalME - descuento + sumaIcbper).ToString("N2")

        'MONEDA EXTRANJERA
        _formVentaCalzados.txtTotalBase.DecimalValue = sumaBaseImponible1
        _formVentaCalzados.txtTotalBase2.DecimalValue = sumaBaseImponible2
        _formVentaCalzados.txtTotalIva.DecimalValue = sumaIva1
        _formVentaCalzados.txtTotalIcbper.DecimalValue = sumaIcbper

        'MONEDA EXTRANJERA
        _formVentaCalzados.txtTotalBaseME.DecimalValue = sumaBaseImponible1ME
        _formVentaCalzados.txtTotalBase2ME.DecimalValue = sumaBaseImponible2ME
        _formVentaCalzados.txtTotalIvaME.DecimalValue = sumaIva1ME
        _formVentaCalzados.txtTotalIcbperME.DecimalValue = sumaIcbperME
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
                                i.CustomProducto.descripcionItem, "",
                                i.CustomProducto.unidad1,
                                i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault,
                                i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                                i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                                i.importeMN.GetValueOrDefault, 0,
                                i.CustomEquivalencia.equivalencia_id, If(i.FlagBonif = "True", True, False), i.CustomCatalogo.idCatalogo, i.descuentoMN.GetValueOrDefault, i.AfectoInventario,
                                If(i.CustomProducto.tipoOtroImpuesto = "ICBPER", "ICBPER", "-"),
                                i.CustomProducto.otroImpuesto.GetValueOrDefault,
                                i.CustomProducto.otroImpuesto.GetValueOrDefault,
                                i.montokardexUS.GetValueOrDefault,
                                i.montoIgvUS.GetValueOrDefault,
                                0, i.importeME.GetValueOrDefault)

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

    Private Sub GetTallasSelproduct(codigodetalle As Integer)
        Dim tallaSA As New totalesAlmacenOthersSA
        _formVentaCalzados.lstTotalesAlmacen = tallaSA.GetInventarioSelCodigo(New totalesAlmacenOthers With {.idProducto = codigodetalle})
        If _formVentaCalzados.lstTotalesAlmacen IsNot Nothing Then
            Dim generoList = _formVentaCalzados.lstTotalesAlmacen.Select(Function(o) o.genero).Distinct.ToList()
            Dim listaGeneros As New List(Of Genero)
            For Each i In generoList
                listaGeneros.Add(New Genero With {.idGenero = i, .genero = i})
            Next
            Combogenero.DataSource = listaGeneros
            Combogenero.DisplayMember = "NameGenero"
            Combogenero.ValueMember = "idGenero"
        End If
    End Sub

    Private Sub GetComboColumna(cabecera As String, stock As Decimal, id_equivalencia As Integer)
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("name")

        dt.Rows.Add(id_equivalencia, stock)

        Me.GridTallasStock.TableDescriptor.Columns(cabecera).Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl

        Me.GridTallasStock.TableDescriptor.Columns(cabecera).Appearance.AnyRecordFieldCell.DataSource = dt
        Me.GridTallasStock.TableDescriptor.Columns(cabecera).Appearance.AnyRecordFieldCell.DisplayMember = "name"
        Me.GridTallasStock.TableDescriptor.Columns(cabecera).Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"
        Me.GridTallasStock.TableDescriptor.Columns(cabecera).Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridTallasStock.TableDescriptor.Columns(cabecera).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCellEditing
    End Sub

    Public Sub GetTabllaDetalleSelGenero(GeneroID As String)
        Dim dt As New DataTable
        Dim dr As DataRow = Nothing
        Dim listaColumns As New List(Of String)

        GridTallasStock.DataSource = New DataTable

        Dim consultaStock = (From s In _formVentaCalzados.lstTotalesAlmacen
                             Where s.genero = GeneroID
                             Group s By s.genero, s.idProducto, s.id_equivalencia Into g = Group
                             Select New With
                    {
                    .genero = genero,
                    .idProducto = idProducto,
                    .id_equivalencia = id_equivalencia,
                    .totalStock = g.Sum(Function(s) s.cantidad)
                    }).ToList

        'Creacion de columnas

        Dim listaNueva = consultaStock.OrderBy(Function(o) o.id_equivalencia).ToList

        For Each i In listaNueva
            Dim item = (From t In _formVentaCalzados.ListaGeneralTallas
                        From det In t.talla_equivalencias
                        Where det.idtalla = t.idtalla And det.id_equivalencia = i.id_equivalencia
                        Select det).FirstOrDefault


            dt.Columns.Add($"T-{item.usa}")
            dt.Columns.Add(i.id_equivalencia.ToString())
            listaColumns.Add(i.id_equivalencia)
        Next


        ' For Each i In listaNueva

        '    Dim item = (From t In _formVentaCalzados.ListaGeneralTallas
        '                From det In t.talla_equivalencias
        '                Where det.idtalla = t.idtalla And det.id_equivalencia = i.id_equivalencia
        '                Select det).FirstOrDefault

        '    dt.Columns.Add(item.usa)
        '    listaColumns.Add(item.id_equivalencia)
        '    dt.Columns.Add(item.id_equivalencia.ToString())
        'Next


        'Creacion de filas
        Dim contador As Integer = 0
        For Each i In consultaStock.OrderBy(Function(o) o.id_equivalencia).ToList
            If contador = 0 Then
                dr = dt.NewRow()
                dr(0) = i.totalStock
                dr(1) = i.id_equivalencia
            Else
                dr(contador) = i.totalStock
                dr(contador + 1) = i.id_equivalencia
            End If
            contador += 2
        Next
        dt.Rows.Add(dr)
        GridTallasStock.DataSource = dt

        For Each i In listaColumns
            GridTallasStock.TableDescriptor.Columns(i).Width = 0
        Next

        'For Each i In consultaStock.OrderBy(Function(o) o.id_equivalencia).ToList
        '    Dim item = (From t In ListaGeneralTallas
        '                From det In t.talla_equivalencias
        '                Where det.idtalla = t.idtalla And det.id_equivalencia = i.id_equivalencia
        '                Select det).FirstOrDefault
        '    GetComboColumna(item.usa, i.totalStock, i.id_equivalencia)
        'Next

    End Sub
#End Region

#Region "Events"
    Private Sub Combogenero_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Combogenero.SelectionChangeCommitted
        GetTabllaDetalleSelGenero(Combogenero.SelectedValue)
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextTallaSel.TextChanged

    End Sub

    Private Sub GridTallasStock_TableControlCurrentCellActivated(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlEventArgs) Handles GridTallasStock.TableControlCurrentCellActivated

    End Sub

    Private Sub GridTallasStock_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridTallasStock.TableControlCellClick
        Dim cc As GridCurrentCell = GridTallasStock.TableControl.CurrentCell
        'Dim style As GridTableCellStyleInfo = TryCast(e.TableControl.Model(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        Dim RowIndex As Integer = e.Inner.RowIndex
        Dim ColIndex As Integer = e.Inner.ColIndex

        If style IsNot Nothing AndAlso style.TableCellIdentity.Column IsNot Nothing Then
            Dim eDisplayElement As Element = style.TableCellIdentity.DisplayElement


            Dim valCheck = Me.GridTallasStock.TableModel(RowIndex, ColIndex + 1).CellValue
            'Dim valCheck2 = Me.GridTallasStock.TableModel(RowIndex, ColIndex).CellValue

            'Dim record = style.TableCellIdentity.DisplayElement.GetRecord()
            'Dim codigo = record.GetValue(style.TableCellIdentity.Column.Name)

            Dim tall = (From n In _formVentaCalzados.ListaGeneralTallas
                        From eq In n.talla_equivalencias
                        Where eq.id_equivalencia = valCheck
                        Select eq).SingleOrDefault


            TextTallaSel.Text = style.TableCellIdentity.Column.Name
            TextTallaSel.Tag = tall
            '   TextStockSel.Text = cc.Renderer.ControlText
            GetDetailTalla(tall)
            'End If
        Else
            TextTallaSel.Text = ""
            TextTallaSel.Tag = Nothing
        End If
    End Sub

    Private Sub GetDetailTalla(tall As talla_equivalencias)
        Dim dt As New DataTable
        dt.Columns.Add("usa")
        dt.Columns.Add("uk")
        dt.Columns.Add("eur")
        dt.Columns.Add("cm")

        dt.Rows.Add(tall.usa, tall.uk, tall.eur, tall.cm)
        GridTallaDetails.DataSource = dt
    End Sub

    Private Sub GridTallasStock_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridTallasStock.TableControlCurrentCellChanged
        'Dim cc As GridCurrentCell = Me.GridGroupingControl1.TableControl.CurrentCell
        'Dim style As GridTableCellStyleInfo = TryCast(e.TableControl.Model(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)

        'If style IsNot Nothing AndAlso style.TableCellIdentity.Column IsNot Nothing Then
        '    Dim eDisplayElement As Element = style.TableCellIdentity.DisplayElement

        '    'If eDisplayElement.Kind = DisplayElementKind.Record AndAlso eDisplayElement.ParentTable IsNot Nothing Then
        '    'Console.WriteLine("Current Record:" & eDisplayElement.ParentTable.CurrentRecord)
        '    'Console.WriteLine("Current ColumnName: " & style.TableCellIdentity.Column.Name)

        '    TextTallaSel.Text = style.TableCellIdentity.Column.MappingName
        '    TextStockSel.Text = cc.Renderer.ControlText
        '    'End If
        'End If
    End Sub

    Private Sub GridTallasStock_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridTallasStock.TableControlCurrentCellCloseDropDown
        Dim cc As GridCurrentCell = GridTallasStock.TableControl.CurrentCell
        'Dim style As GridTableCellStyleInfo = TryCast(e.TableControl.Model(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)
        If style IsNot Nothing AndAlso style.TableCellIdentity.Column IsNot Nothing Then
            Dim eDisplayElement As Element = style.TableCellIdentity.DisplayElement

            Dim record = style.TableCellIdentity.DisplayElement.GetRecord()
            Dim codigo = record.GetValue(style.TableCellIdentity.Column.Name)
            Dim codigo1 = GridTallasStock.Table.CurrentRecord.GetValue("7")

            Dim tall = (From n In _formVentaCalzados.ListaGeneralTallas
                        From eq In n.talla_equivalencias
                        Where eq.id_equivalencia = codigo
                        Select eq).SingleOrDefault


            TextTallaSel.Text = style.TableCellIdentity.Column.Name
            TextTallaSel.Tag = tall
            '  TextStockSel.Text = cc.Renderer.ControlText
            'End If
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        If _formVentaCalzados.listaProductos Is Nothing Then Exit Sub

        Dim prodExiste = _formVentaCalzados.ListaproductosVendidos.Any(Function(o) o.CustomProducto.codigodetalle = _formVentaCalzados.listaProductos.FirstOrDefault.codigodetalle)
        If prodExiste Then
            MessageBox.Show("El producto ya está, en la canasta de venta, ingrese otro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If NumericCantidad.Value > 0 Then
            AgregarProductoDetalleVenta(NumericCantidad.Value, _formVentaCalzados.listaProductos.FirstOrDefault.codigodetalle, CurrencyPrecioVenta.DecimalValue, _formVentaCalzados.listaProductos.FirstOrDefault.detalleitem_equivalencias.First, _formVentaCalzados.ComboCatalogo.SelectedValue)
        Else
            MessageBox.Show("Ingrese una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private col2Check As Boolean = True
    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)

        If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "afectoInventario" Then
            Me.col2Check = Not Me.col2Check

            For Each i In GridCompra.Table.Records
                i.SetValue("afectoInventario", Me.col2Check)

                Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = i.GetValue("codigo")).SingleOrDefault
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

            End If
        End If


        'Dim style As GridTableCellStyleInfo = TryCast(e.TableControl.Model(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)

        Dim RowIndex As Integer = e.Inner.RowIndex
        Dim ColIndex As Integer = e.Inner.ColIndex

        If style IsNot Nothing AndAlso style.TableCellIdentity.Column IsNot Nothing Then
            Dim eDisplayElement As Element = style.TableCellIdentity.DisplayElement
            Dim record = style.TableCellIdentity.DisplayElement.GetRecord()
            Dim codigoCosto = record.GetValue("codigo")

            Dim imagen = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigoCosto).SingleOrDefault()
            If imagen IsNot Nothing Then
                Dim foto = imagen.CustomProducto.fotoUrl
                If foto IsNot Nothing Then

                    If foto.ToString.Trim.Length > 0 Then
                        _formVentaCalzados.PictureBox1.Image = Image.FromFile(foto)
                    Else
                        _formVentaCalzados.PictureBox1.Image = _formVentaCalzados.ImageListAdv1.Images(0)
                    End If
                End If
            End If

            'End If
        Else
            TextTallaSel.Text = ""
            TextTallaSel.Tag = Nothing
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
#Region "Precios"
                                    Dim CodigoEQ As String = r.GetValue("tipofraccion")
                                    Dim value As String = r.GetValue("codigo").ToString()
                                    Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

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
                                            r.SetValue("contenido", obEQ.fraccionUnidad)
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
                                    EditarTotalesAlmacenTallas(GridCompra.Table.CurrentRecord)
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

    Private Sub EliminarProductosInherits(Lista As List(Of documentoventaAbarrotesDet))
        For Each i In Lista
            For Each r In GridCompra.Table.Records
                If r.GetValue("codigo") = i.CodigoCosto Then
                    r.Delete()
                End If
            Next

            Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = i.CodigoCosto).Single
            _formVentaCalzados.ListaproductosVendidos.Remove(item)
        Next
        Lista.Clear()
    End Sub

    'LoadCanastaVentas(ListaproductosVendidos)

    Private Sub EditarItemVentaV2(r As Record)
        If r IsNot Nothing Then

            Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
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
                    .detalleAdicional = r.GetValue("detalle")
                    .CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                    '  .CustomDocumentoCaja = New List(Of documentoCaja)
                End With
                ' LimpiarPagos(ListaproductosComprados)
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
            Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
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
                ' LimpiarPagos(ListaproductosComprados)
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

                                        Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = record.GetValue("codigo")).SingleOrDefault
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

                                        Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = record.GetValue("codigo")).SingleOrDefault
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

                                        Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = record.GetValue("codigo")).SingleOrDefault
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

                                        Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = record.GetValue("codigo")).SingleOrDefault
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
                    Dim afectaStock = Me.GridCompra.TableModel(RowIndex, 18).CellValue
                    Select Case afectaStock
                        Case "False" 'TRUE
                            If RowIndex <> -1 Then
                                Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
                                If item IsNot Nothing Then
                                    With item
                                        .AfectoInventario = True
                                    End With
                                End If
                            End If
                        Case Else ' FALSE
                            If RowIndex <> -1 Then
                                Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
                                If item IsNot Nothing Then
                                    With item
                                        .AfectoInventario = False
                                    End With
                                End If
                            End If
                    End Select
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("U.M.")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("fraccion")

        dt.Columns(0).ColumnMapping = MappingType.Hidden
        dt.Columns(1).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.unidadComercial, i.fraccionUnidad)
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
            Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault
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
            Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

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
            Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

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
            Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

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
            Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

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
                Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

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
                Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

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
                Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).SingleOrDefault

                If prod IsNot Nothing Then
                    Select Case prod.tipoExistencia
                        Case TipoExistencia.ServicioGasto
                            e.Style.BackColor = Color.FromKnownColor(KnownColor.InactiveBorder)
                            e.Style.TextColor = Color.Black
                            e.Style.Enabled = True
                            ' e.Style.Text = 1
                        Case Else
                            e.Style.Enabled = True
                    End Select
                End If


                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                '    Select Case ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select

                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "igvmn")) Then
                '    Select Case ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "pumn")) Then
                '    Select Case ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "totalmn")) Then
                '    Select Case ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "descuentoMN")) Then
                '    Select Case ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select


                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "bonificacion")) Then
                '    Select Case ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = False
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "afectoInventario")) Then
                '    Select Case ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = True
                '        Case Else
                '            e.Style.Enabled = True
                '    End Select
                'ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "precioventa")) Then
                '    Select Case ComboComprobante.Text
                '        Case "OTRA SALIDA DE ALMACEN", "TRANSFERENCIA ENTRE ALMACENES"
                '            e.Style.Enabled = False
                '            e.Style.Text = 0
                '        Case Else
                '            e.Style.Enabled = True
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

                    Dim Item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigoItem).SingleOrDefault
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

    Private Function GetCalculoPrecioVenta(cantidadVenta As Decimal, CodigoFila As String, idEquivalencia As Integer, idCatalogo As String, rec As Record) As Decimal
        GetCalculoPrecioVenta = 0
        Dim objProducto = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = CodigoFila).SingleOrDefault

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

                        If _formVentaCalzados.ComboComprobante.Text = "PRE VENTA" Then
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
                                                    If category IsNot Nothing Then
                                                        Dim configuration = category.preciocompratipo
                                                        Select Case configuration
                                                            Case "NN"
                                                                Select Case objProducto.CustomProducto.preciocompratipo
                                                                    Case "FJ"
                                                                        GetCalculoPrecioVenta = GetPrecioFijo1(i)
                                                                    Case Else
                                                                        Dim PocentajeUtilidad As Decimal = objProducto.CustomProducto.firstpercent.GetValueOrDefault
                                                                        GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                End Select
                                                            Case "PCT"
                                                                Dim PocentajeUtilidad As Decimal = category.firstpercent.GetValueOrDefault 'objProducto.CustomProducto.firstpercent
                                                                ' GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)

                                                                If objEQ.flag = "MAX" Or objEQ.flag = "SOLO" Then
                                                                    GetCalculoPrecioVenta = GetPriceCategoryMax(category, PocentajeUtilidad, objProducto.CustomProducto.precioCompra.GetValueOrDefault)
                                                                Else
                                                                    GetCalculoPrecioVenta = GetPriceProductUniCategoryMIN(objProducto, category, PocentajeUtilidad)
                                                                    '   GetCalculoPrecioVenta = GetPriceProductUnidMIN(objProducto, PocentajeUtilidad)
                                                                End If
                                                            Case "FJ"

                                                        End Select
                                                    End If

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
                        If _formVentaCalzados.ComboComprobante.Text = "PRE VENTA" Then
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

    Private Function GetCalculoPrecioVenta(cantidadVenta As Decimal, idProducto As Integer, idEquivalencia As Integer, idCatalogo As Integer) As Decimal
        GetCalculoPrecioVenta = 0
        Dim objProducto = _formVentaCalzados.listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault

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

                        If _formVentaCalzados.ComboComprobante.Text = "PRE VENTA" Then
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
                        If _formVentaCalzados.ComboComprobante.Text = "PRE VENTA" Then
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

            Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
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

            Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
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

    Private Sub EditarItemVenta(r As Record)
        If r IsNot Nothing Then

            Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
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
                    .detalleAdicional = r.GetValue("detalle")
                    .CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                    '  .CustomDocumentoCaja = New List(Of documentoCaja)
                End With
                ' LimpiarPagos(ListaproductosComprados)
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

    Private Sub EditarTotalesAlmacenTallas(r As Record)
        If r IsNot Nothing Then

            Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
            If item IsNot Nothing Then
                item.CustomtotalesAlmacenOthers.cantidad = Decimal.Parse(r.GetValue("cantidad")) * -1
            End If
        End If
        'LoadCanastaCompras(ListaproductosComprados)
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

        Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
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

        Dim item = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
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
                        Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

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
                                r.SetValue("contenido", obEQ.fraccionUnidad)
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

                        Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = codigo).Single
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
                                    '   UCPreciosCanastaVenta.GetDetallePrecios(catalogoOBJ.detalleitemequivalencia_precios.ToList)
                                End If
                                'Calculando Precio de venta por equivalencia y catalogo
                                Dim precioVenta = GetCalculoPrecioVenta(cantidad, codigo, obEQ.equivalencia_id, CodigoCat, r)
                                r.SetValue("precioventa", precioVenta)
                                r.EndEdit()
                                GetCalculoItemV2(r)
                                EditarItemVenta(r)
                        End Select


                    End If




                ElseIf style.TableCellIdentity.Column.Name = "importeMn" Then

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

    Private Sub GridCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)


                If style.TableCellIdentity.Column.Name = "cantidad" Then
                    If cc.Renderer IsNot Nothing Then


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
                                    Dim prod = _formVentaCalzados.ListaproductosVendidos.Where(Function(o) o.CodigoCosto = value).Single

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
                                            r.SetValue("contenido", obEQ.fraccionUnidad)
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
                            nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)

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
                                    'TextFiltrar.Focus()
                                    'TextFiltrar.Select()
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
                                'TextFiltrar.Focus()
                                'TextFiltrar.Select()
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

                                Select Case _formVentaCalzados.ToggleConsultas.ToggleState
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
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
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
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
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

    Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgProveedor.RunWorkerCompleted
        If SelRazon.nrodoc IsNot Nothing Then
            SelRazon.tipoEntidad = "CL"
            SelRazon.nombreCompleto = SelRazon.nombreCompleto.ToString.Replace(Chr(34), "")
            GrabarEntidadRapidaThread()
            TextNumIdentrazon.Text = SelRazon.nrodoc
            TextProveedor.Text = SelRazon.nombreCompleto
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            ' TextFiltrar.Select()

        Else
            TextProveedor.Clear()
            TextProveedor.Tag = Nothing
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextNumIdentrazon.Select()
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TextNumIdentrazon.Enabled = True
            TextNumIdentrazon.Clear()
            TextProveedor.Clear()
            TextProveedor.Enabled = False
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

    Private Sub RBFullName_CheckedChanged(sender As Object, e As EventArgs) Handles RBFullName.CheckedChanged
        If RBFullName.Checked = True Then
            TextNumIdentrazon.Enabled = False
            TextProveedor.Enabled = True
            TextProveedor.Focus()
            TextProveedor.SelectAll()

        End If
    End Sub

    Private Sub GridTallaDetails_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridTallaDetails.TableControlCellClick

    End Sub

    Public Sub GetConfiguracionEmpresa()
        GridCompra.TableDescriptor.Columns("catalogo").Width = 150
        GridCompra.TableDescriptor.Columns("tipofraccion").Width = 140
        GridCompra.TableDescriptor.Columns("afectoInventario").Width = 90
        GridCompra.TableDescriptor.Columns("item").Width = 250

        'Select Case tmpConfigInicio.FormatoVenta
        '    Case "FACT"
        '        ComboTipoBusqueda.Text = "PRODUCTO"
        '        ComboTipoBusqueda.Enabled = True
        '    Case "FACSV"
        '        ComboTipoBusqueda.Text = "SERVICIO"
        '        ComboTipoBusqueda.Enabled = False
        '        GridCompra.TableDescriptor.Columns("catalogo").Width = 0
        '        GridCompra.TableDescriptor.Columns("tipofraccion").Width = 0
        '        GridCompra.TableDescriptor.Columns("afectoInventario").Width = 0
        '        GridCompra.TableDescriptor.Columns("item").Width = 350
        '    Case Else
        '        ComboTipoBusqueda.Text = "PRODUCTO"
        '        ComboTipoBusqueda.Enabled = True
        'End Select

        If cboMoneda.Text = "NUEVO SOL" Then
            GridCompra.TableDescriptor.Columns("totalmn").ReadOnly = False
            GridCompra.TableDescriptor.Columns("totalme").ReadOnly = True

        Else
            GridCompra.TableDescriptor.Columns("totalmn").ReadOnly = True
            GridCompra.TableDescriptor.Columns("totalme").ReadOnly = False

        End If
    End Sub

    Private Sub Combogenero_Click(sender As Object, e As EventArgs) Handles Combogenero.Click

    End Sub

    Private Sub TextNumIdentrazon_TextChanged(sender As Object, e As EventArgs) Handles TextNumIdentrazon.TextChanged

    End Sub
#End Region

End Class
