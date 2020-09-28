Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class UCEstructuraCabeceraVenta

#Region "Attributes"
    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Public Property ListaproductosVendidos As List(Of documentoventaAbarrotesDet)
    Private Property ProductoSA As New detalleitemsSA
    Public Property FormPurchase As FormVentaNueva
    Public Property ListaDocumentos As List(Of tabladetalle)
    Public listaProductos As List(Of detalleitems)
#End Region

#Region "Constructors"
    Public Sub New(formventaNueva As FormVentaNueva)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormPurchase = formventaNueva
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        FormatoGridAvanzado(GridTotales, False, False, 8.0F)
        ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)
        GetTablasGenerales()
        FormatoGrid(GridCompra)
        FormatoGrid(GridTotales)
        LoadTablaEquivalencias()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


#End Region

#Region "Methods"

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

    Private Sub GridTotales_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridTotales.TableControlDrawCell
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

    Private Sub GridTotales_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridTotales.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 9 Then
                Dim inp = InputBox("Ingreser cantidad", "Atención", "")
                MsgBox("Cantidad: " & inp)
            ElseIf e.Inner.ColIndex = 10 Then
                Dim idProducto = GridTotales.TableModel(e.Inner.RowIndex, 2).CellValue
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
        dt.Columns.Add("detalle")
        dt.Columns.Add("fraccion")

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.detalle, i.fraccionUnidad)
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
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.DisplayMember = "detalle"
        Me.GridTotales.TableDescriptor.Columns("cboEquivalencias").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.DisplayMember = "precioCode"
        Me.GridTotales.TableDescriptor.Columns("cboPrecios").Appearance.AnyRecordFieldCell.ValueMember = "precio"
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

        For Each i In GridCompra.Table.Records
            sumaTotal += CDec(i.GetValue("totalmn"))
            Select Case i.GetValue("gravado")
                Case "1"
                    sumaBaseImponible1 += CDec(i.GetValue("vcmn"))
                    sumaIva1 += CDec(i.GetValue("igvmn"))
                Case "2"
                    sumaBaseImponible2 += CDec(i.GetValue("vcmn"))
                    sumaIva2 += CDec(i.GetValue("igvmn"))
            End Select
        Next
        txtTotalPagar.DecimalValue = sumaTotal
        txtTotalBase.DecimalValue = sumaBaseImponible1
        txtTotalBase2.DecimalValue = sumaBaseImponible2
        txtTotalIva.DecimalValue = sumaIva1
    End Sub

    Private Sub GetTablasGenerales()
        Dim listaMoneda = General.TablasGenerales.GetMonedas()
        ListaDocumentos = GetComprobantesCompra()
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9907", .descripcion = "NOTA"})
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9903", .descripcion = "PROFORMA"})

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
    End Sub

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        ' Dim array = MIHTML.Split("|")

        Dim nombres = MIHTML.Replace("|", Space(1))
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
                If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                End If
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
                                    TextBoxExt1.Focus()
                                    TextBoxExt1.Select()
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
                                TextBoxExt1.Focus()
                                TextBoxExt1.Select()
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
                                GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
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

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            PictureLoadingProduct.Visible = True
            listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text})

            GridTotales.Table.Records.DeleteAll()
            'ListProductos.Items.Clear()

            If listaProductos.Count > 0 Then
                Dim consulta As New List(Of detalleitems)
                'consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                consulta.AddRange(listaProductos)
                GetListProductos(consulta)

                'Me.PopupProductos.Size = New Size(426, 147)
                Me.PopupProductos.ParentControl = Me.TextBoxExt1
                Me.PopupProductos.ShowPopup(Point.Empty)
                PictureLoadingProduct.Visible = False
            Else
                If Me.PopupProductos.IsShowing() Then
                    Me.PopupProductos.HidePopup(PopupCloseType.Canceled)
                End If
                PictureLoadingProduct.Visible = False
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
            Me.PopupProductos.ParentControl = Me.TextBoxExt1
            Me.PopupProductos.ShowPopup(Point.Empty)
            GridTotales.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PopupProductos.IsShowing() Then
                Me.PopupProductos.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub GetListProductos(consulta As List(Of detalleitems))
        GridTotales.Table.Records.DeleteAll()
        'ListProductos.Items.Clear()
        Dim dt As New DataTable
        dt.Columns.Add("destino")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cboEquivalencias")
        dt.Columns.Add("cboPrecios")
        dt.Columns.Add("importeMn")

        For Each i In consulta
            dt.Rows.Add(
                i.origenProducto,
                i.codigodetalle,
                i.descripcionItem,
                i.composicion,
                i.unidad1)
        Next
        GridTotales.DataSource = dt
        GridTotales.Refresh()
    End Sub

    Private Sub PopupProductos_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupProductos.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If GridTotales.Table.Records.Count > 0 AndAlso GridTotales.Table.CurrentRecord IsNot Nothing Then
                AgregarProductoDetalleCompra(GridTotales.Table.CurrentRecord)
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            TextBoxExt1.Focus()
        End If
        Me.Cursor = Cursors.Arrow
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

    Public Sub AgregarProductoDetalleVenta(cantidad As Decimal, idProductoSel As Integer, precioventa As Decimal, eq As detalleitem_equivalencias)
        Dim obj As documentoventaAbarrotesDet
        Dim idProducto = idProductoSel


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
        Dim total As Decimal = canti * precioventa   'Decimal.Parse(r.GetValue("totalmn"))
        baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
        Iva = Math.Round(total - baseImponible, 2)

        Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
        If producto IsNot Nothing Then
            obj = New documentoventaAbarrotesDet
            Dim cod = System.Guid.NewGuid.ToString()
            obj.CodigoCosto = cod
            obj.idItem = producto.codigodetalle
            obj.CustomProducto = producto
            obj.CustomEquivalencia = eq
            obj.monto1 = cantidad
            AddItemVentaDetalle(producto, obj)
            obj.unidad2 = eq.detalle
            obj.montokardex = baseImponible
            obj.montoIgv = Iva
            obj.importeMN = total
            obj.PrecioUnitarioVentaMN = precioventa
            obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
            'obj.CustomDocumentoCaja = New List(Of documentoCaja)
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
        obj.estadoEntrega = "SI"
        obj.idCajaUsuario = 0
        obj.FlagBonif = "False"
        obj.usuarioModificacion = usuario.IDUsuario
        obj.fechaModificacion = Date.Now

    End Sub

    Public Sub LoadCanastaVentas(listaProductos As List(Of documentoventaAbarrotesDet))
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

        For Each i In listaProductos
            dt.Rows.Add(i.CodigoCosto,
                    i.CustomProducto.origenProducto,
                    i.CustomProducto.descripcionItem,
                    i.CustomProducto.unidad1,
                    i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault,
                    i.monto1, i.PrecioUnitarioVentaMN.GetValueOrDefault,
                    i.montokardex.GetValueOrDefault, i.montoIgv.GetValueOrDefault, 0,
                    i.importeMN.GetValueOrDefault, 0,
                    i.CustomEquivalencia.detalle, If(i.FlagBonif = "True", True, False))
        Next
        GridCompra.DataSource = dt
        GridCompra.Refresh()
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Dim frmNuevaExistencia As New frmNuevaExistencia
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            If Gempresas.Regimen = "1" Then
                .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            Else
                .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            End If
            '.UCNuenExistencia.chClasificacion.Checked = False
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
            .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub EditarItemVenta(r As Record)
        If r IsNot Nothing Then

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
            If item IsNot Nothing Then
                With item
                    .monto1 = Decimal.Parse(r.GetValue("cantidad"))
                    .montokardex = Decimal.Parse(r.GetValue("vcmn"))
                    .montoIgv = Decimal.Parse(r.GetValue("igvmn"))
                    .precioUnitario = 0
                    .importeMN = Decimal.Parse(r.GetValue("totalmn"))
                    .FlagBonif = r.GetValue("bonificacion").ToString
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
                    .precioUnitario = 0
                    .importeMN = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 12).CellValue)
                    .FlagBonif = If(Me.GridCompra.TableModel(RowIndex, 14).CellValue = False, "True", "False")
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

    Public Sub GetCalculoItem(r As Record)
        If r IsNot Nothing Then
            Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
            Dim recaudo As Decimal = CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(r.GetValue("precioventa"))
            Dim canti As Decimal = CDec(r.GetValue("cantidad"))
            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0

            Dim total As Decimal = canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))

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
                r.SetValue("pumn", 0)
                r.SetValue("totalmn", total)

                GridCompra.Refresh()

                GetTotalesDocumento()
            End If
        End If
    End Sub

    Public Sub GetCalculoItem(rowIndex As Integer)
        If rowIndex <> -1 Then
            Dim bonificacion = If(Boolean.Parse(Me.GridCompra.TableModel(rowIndex, 14).CellValue) = False, True, False)
            Dim recaudo As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 2).CellValue) ' CDec(r.GetValue("gravado"))
            Dim precioVenta As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 8).CellValue) 'precioventa
            Dim canti As Decimal = CDec(Me.GridCompra.TableModel(rowIndex, 7).CellValue)
            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0

            Dim total As Decimal = canti * precioVenta   'Decimal.Parse(r.GetValue("totalmn"))

            Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(rowIndex, 1).CellValue).SingleOrDefault
            If item IsNot Nothing Then

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
                Me.GridCompra.TableModel(rowIndex, 12).CellValue = total
                'r.SetValue("pumn", 0)
                'r.SetValue("totalmn", total)

                GridCompra.Refresh()

                GetTotalesDocumento()
            End If
        End If
    End Sub

    Private Sub TextBoxExt1_LostFocus(sender As Object, e As EventArgs) Handles TextBoxExt1.LostFocus
        'PopupProductos.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub GridCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "cantidad" Or style.TableCellIdentity.Column.Name = "precioventa" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            If text.Trim.Length > 0 Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                    GetCalculoItem(GridCompra.Table.CurrentRecord)
                                    EditarItemVenta(GridCompra.Table.CurrentRecord)
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        End If
                    End If


                ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
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
            TextNumIdentrazon.Select()
            TextNumIdentrazon.Focus()
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

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged

    End Sub

    Public Sub BunifuThinButton25_Click(sender As Object, e As EventArgs) Handles BunifuThinButton25.Click
        'Dim f As New FormCanstaVentaEquivalenciav2(Me)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog(Me)

        'With FormCanstaVentaEquivalenciav2
        '    .UCEstructuraCabeceraVenta = Me
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog(Me)
        'End With
    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
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

    Private Sub UCEstructuraCabeceraVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GridCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.GridCompra.TableModel(RowIndex, 14).CellValue
            Select Case valCheck
                Case "False" 'TRUE
                    GetCalculoItem(RowIndex)
                    EditarItemVenta(RowIndex)
                    'MessageBox.Show(True)
                Case Else ' FALSE
                    GetCalculoItem(RowIndex)
                    EditarItemVenta(RowIndex)
                    'MessageBox.Show(False)
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboTerminosPago.Click

    End Sub

    Private Sub ComboTerminosPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboTerminosPago.SelectedValueChanged
        If ComboTerminosPago.Text = "CONTADO" Then
            If FormPurchase IsNot Nothing Then
                FormPurchase.BunifuFlatButton2.Visible = True
                FormPurchase.UCCondicionesPago.RBSi.Checked = True
                FormPurchase.UCCondicionesPago.RBPagoAcumulado.Checked = True
                FormPurchase.btGrabar.Text = "Cobrar - F2"
            End If
        ElseIf ComboTerminosPago.Text = "CREDITO" Then
            If FormPurchase IsNot Nothing Then
                FormPurchase.UCCondicionesPago.RBNo.Checked = True
                FormPurchase.BunifuFlatButton2.Visible = False
                FormPurchase.btGrabar.Text = "Guardar - F2"
            End If
        ElseIf ComboTerminosPago.Text = "CRONOGRAMA" Then
            If FormPurchase IsNot Nothing Then
                FormPurchase.BunifuFlatButton2.Visible = True
                FormPurchase.UCCondicionesPago.RBSi.Checked = True
                FormPurchase.UCCondicionesPago.RBCronograma.Checked = True
                FormPurchase.btGrabar.Text = "Cobrar - F2"
            End If
        End If
    End Sub

#End Region

End Class
