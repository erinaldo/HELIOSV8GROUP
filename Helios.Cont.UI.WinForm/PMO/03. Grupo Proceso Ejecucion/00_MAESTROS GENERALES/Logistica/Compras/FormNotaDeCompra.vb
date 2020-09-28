Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormNotaDeCompra
    Implements IExistencias

#Region "Fields"
    Public Property VentanaSel As FormMaestroLogistica
    Private threadEntidades As Thread
    Public Property ListaEntidad As List(Of entidad)
    Dim entidadSA As New entidadSA
    Friend Delegate Sub SetDelegateEntidad(ByVal lista As List(Of entidad), tipo As String)
#End Region

#Region "Attributes"
    Public Property CompraSA As New DocumentoCompraSA
#End Region

#Region "Proveedor"
    Private Sub GetThreadEntidades()
        ProgressBar2.Visible = True
        ProgressBar2.Style = ProgressBarStyle.Marquee
        threadEntidades = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetEntidades()))
        threadEntidades.Start()
    End Sub

    Private Sub GetEntidades()
        Dim ListaEntidades As New List(Of entidad)
        ListaEntidades = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        setDataSourceEntidad(ListaEntidades, "PR")
    End Sub

    Private Sub setDataSourceEntidad(GetEntidades As List(Of entidad), tipo As String)
        If Me.InvokeRequired Then
            Dim deleg As New SetDelegateEntidad(AddressOf setDataSourceEntidad)
            Invoke(deleg, New Object() {GetEntidades, tipo})
        Else
            ListaEntidad = New List(Of entidad)
            ListaEntidad = GetEntidades
            ProgressBar2.Visible = False
        End If
    End Sub
#End Region

#Region "Constructors"
    Public Sub New(ventana As FormMaestroLogistica)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.KeyPreview = True
        FormatoGridAvanzado(dgvCompra, False, False, 11)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        VentanaSel = ventana
        GetConfiguracionInicio()
        GetCombos()
        GetThreadEntidades()
    End Sub

    Public Sub New(IdDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormatoGridAvanzado(dgvCompra, False, False, 11)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetConfiguracionInicio()
        GetCombos()
        GetThreadEntidades()
        UbicarDocumento(IdDocumento)
    End Sub

#End Region

#Region "Methods"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.F9
                ToolStripButton1.PerformClick()

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle

        Try
            'DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            'If Not IsNothing(DocumentoGuia) Then
            '    With DocumentoGuia
            '        txtFechaGuia.Value = New DateTime(.fecha.Year, .fecha.Month, .fecha.Day, .fecha.Hour, .fecha.Minute, .fecha.Second)
            '        txtSerieGuia.Text = .Serie
            '        txtNumeroGuia.Text = .Numero
            '    End With
            'End If

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                Tag = .idDocumento
                cboMesCompra.SelectedValue = String.Format("{0:00}", .fechaDoc.Value.Month)
                TxtDia.Text = .fechaDoc.Value.Day
                cboAnio.Text = .fechaDoc.Value.Year
                txtHora.Value = .fechaDoc.Value
                txtNumero.Text = .numeroDoc
                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtruc.Text = nEntidad.nrodoc
                txtProveedor.Tag = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto
                txtGlosa.Text = .glosa
            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            For Each i In objDocCompraDet.GetUbicarDetalleCompraLote(intIdDocumento)
                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", i.secuencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                Me.dgvCompra.Table.CurrentRecord.SetValue("baseimponible", i.montokardex)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igv", i.montoIgv)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)
                dgvCompra.Table.CurrentRecord.SetValue("codigoLote", i.CustomRecursoCostoLote.codigoLote)
                Me.dgvCompra.Table.CurrentRecord.SetValue("lote", i.CustomRecursoCostoLote.nroLote)
                Me.dgvCompra.Table.CurrentRecord.SetValue("fechaProd", i.CustomRecursoCostoLote.fechaProduccion.GetValueOrDefault)
                If i.CustomRecursoCostoLote.fechaVcto.HasValue Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("fechaVcto", i.CustomRecursoCostoLote.fechaVcto.GetValueOrDefault)
                End If
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            btGrabar.Enabled = False
            dgvCompra.TableDescriptor.Columns("codigoLote").ReadOnly = True
            dgvCompra.TableDescriptor.Columns("lote").ReadOnly = True
            dgvCompra.TableDescriptor.Columns("fechaProd").ReadOnly = True
            dgvCompra.TableDescriptor.Columns("fechaVcto").ReadOnly = True
            txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If TxtDia.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxtDia, "El campo fecha es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TxtDia, Nothing)
        End If

        If txtProveedor.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtProveedor, "El campo persona es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtProveedor, Nothing)
        End If

        If txtProveedor.Text.Trim.Length > 0 Then
            If txtProveedor.ForeColor = Color.Black Then
                ErrorProvider1.SetError(txtProveedor, "Verificar el ingreso correcto del personal")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(txtProveedor, Nothing)
            End If
        Else
            'ErrorProvider1.SetError(TextPersona, Nothing)
        End If

        If txtGlosa.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtGlosa, "El campo glosa es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtGlosa, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Private Function GetTotalCompra() As Decimal
        Dim suma As Decimal = 0
        For Each i In dgvCompra.Table.Records
            suma += CDec(i.GetValue("totalmn"))
        Next
        Return suma
    End Function

    Private Sub Grabar()
        FinalizandoEventosGrid()
        Dim FormatoFecha = New DateTime(cboAnio.Text, cboMesCompra.SelectedValue, TxtDia.Text, txtHora.Value.Hour, txtHora.Value.Minute, txtHora.Value.Second)


        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        Dim ImporteTotalCompras As Decimal = GetTotalCompra()

        Dim be As New documento With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = "9907",
        .fechaProceso = FormatoFecha,
        .moneda = "1",
        .idEntidad = txtProveedor.Tag,
        .entidad = txtProveedor.Text,
        .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR,
        .nrodocEntidad = txtruc.Text,
        .nroDoc = txtNumero.Text,
        .tipoOperacion = StatusTipoOperacion.COMPRA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }

        be.documentocompra = New documentocompra With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_COMPRAS,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .fechaLaboral = DateTime.Now,
        .fechaDoc = FormatoFecha,
        .fechaContable = GetPeriodo(FormatoFecha, True),
        .tipoDoc = "9907",
        .serie = "NOTE",
        .numeroDoc = txtNumero.Text,
        .idProveedor = Integer.Parse(txtProveedor.Tag),
        .monedaDoc = "1",
        .tasaIgv = 0,
        .tcDolLoc = 0,
        .tipocambio = 0,
        .bi01 = ImporteTotalCompras,
        .bi02 = 0,
        .bi03 = 0,
        .bi04 = 0,
        .isc01 = 0,
        .isc02 = 0,
        .isc03 = 0,
        .igv01 = 0,
        .igv02 = 0,
        .igv03 = 0,
        .otc01 = 0,
        .otc02 = 0,
        .otc03 = 0,
        .otc04 = 0,
        .bi01us = 0,
        .bi02us = 0,
        .bi03us = 0,
        .bi04us = 0,
        .isc01us = 0,
        .isc02us = 0,
        .isc03us = 0,
        .igv01us = 0,
        .igv02us = 0,
        .igv03us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .otc03us = 0,
        .otc04us = 0,
        .importeTotal = ImporteTotalCompras,
        .importeUS = 0,
        .destino = TIPO_COMPRA.NOTA_DE_COMPRA,
        .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
        .glosa = txtGlosa.Text,
        .tipoCompra = TIPO_COMPRA.NOTA_DE_COMPRA,
        .situacion = statusComprobantes.Normal,
        .tieneDetraccion = "N",
        .aprobado = "N",
        .usuarioActualizacion = usuario.IDUsuario.ToString,
        .fechaActualizacion = DateTime.Now
        }

        be.documentocompra.documentocompradetalle = GetDetalleNota(be)
        CompraSA.GrabarNotaCompra(be)
        If VentanaSel IsNot Nothing Then
            VentanaSel.ThreadTransito()
        End If
        With FormCanastaCompras
            .GridItems.Table.Records.DeleteAll()
            .txtFiltrar.Clear()
        End With
        Close()
    End Sub

    Private Function GetDetalleNota(ndocumento As documento) As List(Of documentocompradetalle)
        GetDetalleNota = New List(Of documentocompradetalle)
        Dim nroLotex = Nothing
        Dim obj As recursoCostoLote = Nothing
        Dim objDetalle As documentocompradetalle
        For Each i In dgvCompra.Table.Records

            If Decimal.Parse(i.GetValue("cantidad")) <= 0 Then
                Throw New Exception("Debe ingresar una cantidad mayor a cero")
            End If

            If Decimal.Parse(i.GetValue("vcmn")) <= 0 Then
                Throw New Exception("Debe ingresar una valor de compra mayor a cero")
            End If

            objDetalle = New documentocompradetalle
            Select Case cboAsignacion.Text
                Case "POR LOTES"
                    ndocumento.documentocompra.AsigancionDeLotes = "POR LOTES"

                    nroLotex = i.GetValue("lote").ToString
                    If nroLotex.ToString.Trim.Length > 0 Then
                        obj = New recursoCostoLote With
                            {
                            .fechaentrada = ndocumento.fechaProceso,
                            .nroLote = nroLotex,
                            .detalle = i.GetValue("item"),
                            .fechaProduccion = Date.Now,
                            .fechaVcto = CDate(i.GetValue("fechaVcto")),
                            .productoSustentado = False
                            }
                    Else
                        nroLotex = txtNumero.Text.Trim

                        obj = New recursoCostoLote With
                            {
                            .fechaentrada = ndocumento.fechaProceso,
                            .nroLote = nroLotex,
                            .detalle = i.GetValue("item"),
                            .fechaProduccion = Date.Now,
                            .fechaVcto = CDate(i.GetValue("fechaVcto")),
                            .productoSustentado = False
                            }
                    End If
                Case "LOTE EXISTENTE"
                    'ndocumento.documentocompra.AsigancionDeLotes = "LOTE EXISTENTE"

                    'objDocumentoCompraDet.nrolote = r.GetValue("lote")
                    'objDocumentoCompraDet.codigoLote = Integer.Parse(r.GetValue("codigoLote"))

                    'objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                    'objDocumentoCompraDet.CustomRecursoCostoLote.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
                    'objDocumentoCompraDet.CustomRecursoCostoLote.nroLote = r.GetValue("lote")
                    'objDocumentoCompraDet.CustomRecursoCostoLote.detalle = r.GetValue("item")
                Case "CONTROL POR COMPROBANTE"
                    ndocumento.documentocompra.AsigancionDeLotes = "CONTROL POR COMPROBANTE"

                    nroLotex = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
                    obj = New recursoCostoLote With
                             {
                             .fechaentrada = ndocumento.fechaProceso,
                             .nroLote = nroLotex,
                             .detalle = i.GetValue("item"),
                             .fechaProduccion = Nothing,
                             .fechaVcto = Nothing,
                             .productoSustentado = False
                             }

            End Select


            objDetalle = New documentocompradetalle With
                               {
                               .nrolote = nroLotex,
                               .CustomRecursoCostoLote = obj,
                               .IdEmpresa = Gempresas.IdEmpresaRuc,
                               .IdEstablecimiento = GEstableciento.IdEstablecimiento,
                               .tipoCompra = TIPO_COMPRA.COMPRA,
                               .TipoOperacion = StatusTipoOperacion.COMPRA,
                               .FechaDoc = ndocumento.fechaProceso,
                               .FechaLaboral = DateTime.Now,
                               .CuentaProvedor = "4212",
                               .NombreProveedor = txtProveedor.Text.Trim,
                               .Serie = "NT",
                               .NumDoc = txtNumero.Text.Trim,
                               .TipoDoc = ndocumento.tipoDoc,
                               .idItem = i.GetValue("idProducto"),
                               .descripcionItem = i.GetValue("item"),
                               .ItemEntregadototal = "N",
                               .tipoExistencia = i.GetValue("tipoExistencia"),
                               .destino = i.GetValue("gravado"),
                               .unidad1 = i.GetValue("um"),
                               .monto1 = Decimal.Parse(i.GetValue("cantidad")),
                               .precioUnitario = Decimal.Parse(i.GetValue("pumn")),
                               .precioUnitarioUS = 0,
                               .importe = Decimal.Parse(i.GetValue("totalmn")),
                               .importeUS = 0,
                               .montokardex = Decimal.Parse(i.GetValue("vcmn")),
                               .montoIsc = 0,
                               .montoIgv = 0,
                               .otrosTributos = 0,
                               .montokardexUS = 0,
                               .montoIscUS = 0,
                               .montoIgvUS = 0,
                               .otrosTributosUS = 0,
                               .almacenRef = Integer.Parse(i.GetValue("almacen")),
                               .fechaEntrega = DateTime.Now,
                               .estadoPago = "PN",
                               .usuarioModificacion = usuario.IDUsuario,
                               .fechaModificacion = DateTime.Now
                               }
            'objDetalle.CustomInventarioMovimiento = GetInventario(objDetalle)
            GetDetalleNota.Add(objDetalle)
        Next
    End Function

    Private Sub FinalizandoEventosGrid()
        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()
    End Sub

    Private Sub CalculoGridCeldas()
        Dim expField0 As ExpressionFieldDescriptor = New ExpressionFieldDescriptor("totalmn", "([vcmn])", GetType(System.Double))
        Dim expField1 As ExpressionFieldDescriptor = New ExpressionFieldDescriptor("pumn", "([totalmn]/[cantidad])", GetType(System.Double))
        dgvCompra.TableDescriptor.ExpressionFields.AddRange(New ExpressionFieldDescriptor() {expField0, expField1})
    End Sub

    Private Sub GetConfiguracionInicio()
        GetnumeracionNotaCompra()
        ' CalculoGridCeldas()
        FormatoGridAvanzado(dgvCompra, False, False)
        dgvCompra.DataSource = GridTable()
        txtHora.Value = DateTime.Now
    End Sub

    Private Sub GetnumeracionNotaCompra()
        Dim numero = CType(CompraSA.GetNumeracionCompra(
            New documentocompra With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc, .tipoCompra = TIPO_COMPRA.NOTA_DE_COMPRA
            }), Integer)

        txtNumero.Text = numero.ToString()
    End Sub

    Private Function GridTable() As DataTable
        Dim dt As New DataTable()

        AddColumnLotes()

        With dt.Columns
            .Add("codigo")
            .Add("gravado")
            .Add("idProducto")
            .Add("item")
            .Add("um")
            .Add("cantidad")
            .Add("vcmn")
            .Add("pumn")
            .Add("totalmn")
            .Add("tipoExistencia")
            .Add("almacen")
            .Add("lote", GetType(String))
            .Add("fechaProd", GetType(DateTime))
            .Add("fechaVcto", GetType(DateTime))
            .Add("codigoLote")
            .Add("baseimponible")
            .Add("igv")
        End With

        Return dt
    End Function

    Private Sub AddColumnLotes()
        Dim costoSA As New recursoCostoLoteSA
        Dim lista As New List(Of recursoCostoLote)
        dgvCompra.TableDescriptor.Columns.Add("lote")
        dgvCompra.TableDescriptor.VisibleColumns.Add("lote")
        dgvCompra.TableDescriptor.Columns("lote").MappingName = "lote"
        dgvCompra.TableDescriptor.Columns("lote").HeaderText = "Nro.Lote"
        dgvCompra.TableDescriptor.Columns("lote").Name = "lote"
        dgvCompra.TableDescriptor.Columns("lote").Width = 100
        dgvCompra.TableDescriptor.Columns("lote").ReadOnly = False
        dgvCompra.TableDescriptor.Columns("lote").AllowSort = False

        dgvCompra.TableDescriptor.Columns.Add("fechaProd")
        dgvCompra.TableDescriptor.VisibleColumns.Add("fechaProd")
        dgvCompra.TableDescriptor.Columns("fechaProd").MappingName = "fechaProd"
        dgvCompra.TableDescriptor.Columns("fechaProd").HeaderText = "Fec. Prod."
        dgvCompra.TableDescriptor.Columns("fechaProd").Name = "fechaProd"
        dgvCompra.TableDescriptor.Columns("fechaProd").Width = 0 '100
        dgvCompra.TableDescriptor.Columns("fechaProd").ReadOnly = False
        dgvCompra.TableDescriptor.Columns("fechaProd").Appearance.AnyRecordFieldCell.CellType = "MonthCalendar"
        dgvCompra.TableDescriptor.Columns("fechaProd").AllowSort = False

        dgvCompra.TableDescriptor.Columns.Add("fechaVcto")
        dgvCompra.TableDescriptor.VisibleColumns.Add("fechaVcto")
        dgvCompra.TableDescriptor.Columns("fechaVcto").MappingName = "fechaVcto"
        dgvCompra.TableDescriptor.Columns("fechaVcto").HeaderText = "Fec. Vcto."
        dgvCompra.TableDescriptor.Columns("fechaVcto").Name = "fechaVcto"
        dgvCompra.TableDescriptor.Columns("fechaVcto").Width = 100
        dgvCompra.TableDescriptor.Columns("fechaVcto").ReadOnly = False
        dgvCompra.TableDescriptor.Columns("fechaVcto").Appearance.AnyRecordFieldCell.CellType = "MonthCalendar"
        dgvCompra.TableDescriptor.Columns("fechaVcto").AllowSort = False

    End Sub

    Private Sub GetCombos()
        Dim periodoSA As New empresaPeriodoSA

        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"

        cboAnio.DataSource = periodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
    End Sub

    Private Sub FillLSVEntidades(consulta As List(Of entidad))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next
    End Sub
#End Region

#Region "Events"


    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then

        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            If IsNumeric(cboAnio.Text) AndAlso IsNumeric(cboMesCompra.SelectedValue) Then

                If TxtDia.Text.Trim.Length > 0 Then
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                Else
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                    TxtDia.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            TxtDia_TextChanged(sender, e)
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged
        txtProveedor.ForeColor = Color.Black
        txtProveedor.Tag = Nothing
        If txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub TextPersona_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown


        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else

            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
            Dim consulta2 = (From n In ListaEntidad
                             Where n.nombreCompleto.StartsWith(txtProveedor.Text) Or n.nrodoc.StartsWith(txtProveedor.Text)).ToList
            consulta.AddRange(consulta2)
            '     consulta.Add(New entidad With {.idEntidad = 0, .nombreCompleto = "Agregar nuevo"})
            FillLSVEntidades(consulta)
            e.Handled = True

        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            lsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer4.IsShowing() Then
                Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                If lsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Nuevo proveedor"
                    f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, entidad)
                        txtProveedor.Text = c.nombreCompleto
                        txtProveedor.Tag = c.idEntidad
                        txtruc.Visible = True
                        txtruc.Text = c.nrodoc
                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        ListaEntidad.Add(c)
                    End If

                Else
                    txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                    txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            txtProveedor.Focus()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            PopupControlContainer4.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub cboAsignacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAsignacion.SelectedValueChanged
        If dgvCompra.Table.Records.Count > 0 Then
            Select Case cboAsignacion.Text
                Case "POR LOTES"
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Add("lote")
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Add("fechaProd")
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Add("fechaVcto")
                Case "LOTE EXISTENTE"

                Case "CONTROL POR COMPROBANTE"

                    Me.dgvCompra.TableDescriptor.VisibleColumns.Remove("lote")
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Remove("fechaProd")
                    Me.dgvCompra.TableDescriptor.VisibleColumns.Remove("fechaVcto")
            End Select
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        With FormCanastaCompras
            .StartPosition = FormStartPosition.CenterParent
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

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyDown
        If e.Inner.KeyCode = Keys.Delete Then
            If Me.dgvCompra.Table.CurrentRecord IsNot Nothing Then
                Me.dgvCompra.Table.CurrentRecord.Delete()
                ToolStripButton2.PerformClick()
            End If
        End If
    End Sub

    Public Sub EnviarItem(productoBE As detalleitems) Implements IExistencias.EnviarItem
        Dim almacenSA As New almacenSA
        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", productoBE.origenProducto)
        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", productoBE.codigodetalle)
        Me.dgvCompra.Table.CurrentRecord.SetValue("item", productoBE.descripcionItem)
        Me.dgvCompra.Table.CurrentRecord.SetValue("um", productoBE.unidad1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
        '   Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
        '   Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", productoBE.tipoExistencia)
        Dim almacen = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacen.idAlmacen)
        Me.dgvCompra.Table.CurrentRecord.SetValue("fechaVcto", Date.Now)
        Me.dgvCompra.Table.CurrentRecord.SetValue("fechaProd", Date.Now)
        Me.dgvCompra.Table.CurrentRecord.SetValue("codigoLote", 0)
        Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Me.dgvCompra.Table.TableDirty = True
        dgvCompra.Focus()
    End Sub



    Private Sub cboMesCompra_Click(sender As Object, e As EventArgs) Handles cboMesCompra.Click

    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If ValidarGrabado() Then
                If dgvCompra.Table.Records.Count > 0 Then
                    Grabar()
                Else
                    MsgBox("Debe ingresar items a la canasta", MsgBoxStyle.Exclamation, "Verificar canasta")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub FormNotaDeCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        Try
            cc.ConfirmChanges()
            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "cantidad" Then
                    Dim text As String = cc.Renderer.ControlText

                    If text.Trim.Length > 0 Then
                        Dim value As Decimal = Convert.ToDecimal(text)
                        cc.Renderer.ControlValue = value

                        CalculoCeldas(e.TableControl.Table.CurrentRecord, value, "cantidad")
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "pumn" Then
                    Dim text As String = cc.Renderer.ControlText

                    If text.Trim.Length > 0 Then
                        Dim value As Decimal = Convert.ToDecimal(text)
                        cc.Renderer.ControlValue = value

                        CalculoCeldas(e.TableControl.Table.CurrentRecord, value, "pumn")
                    End If

                ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
                    Dim text As String = cc.Renderer.ControlText

                    If text.Trim.Length > 0 Then
                        Dim value As Decimal = Convert.ToDecimal(text)
                        cc.Renderer.ControlValue = value

                        CalculoCeldas(e.TableControl.Table.CurrentRecord, value, "importe")
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CalculoCeldas(r As Record, value As Decimal, opcion As String)
        Dim iva As Decimal = (TmpIGV / 100) + 1
        Select Case opcion
            Case "cantidad"
                Dim importe As Decimal? = 0
                Dim cantidad As Decimal? = value
                If IsNumeric(r.GetValue("totalmn")) Then
                    importe = CDec(r.GetValue("totalmn"))
                Else
                    importe = 0
                End If

                Dim base = Math.Round(CDec(CalculoBaseImponible(importe, iva)), 2)
                Dim igv = importe - base
                If cantidad.GetValueOrDefault > 0 Then
                    Dim precioUnitario = Math.Round(CDec(importe / cantidad), 2)
                    r.SetValue("pumn", precioUnitario)
                Else
                    r.SetValue("pumn", 0)
                End If


                r.SetValue("baseimponible", base)
                r.SetValue("vcmn", base)
                r.SetValue("igv", igv)

            Case "importe"
                Dim cantidad As Decimal? = CDec(r.GetValue("cantidad"))
                Dim importe As Decimal? = value
                Dim base = Math.Round(CDec(CalculoBaseImponible(importe, iva)), 2)
                Dim igv = importe - base
                If cantidad.GetValueOrDefault > 0 Then
                    Dim precioUnitario = Math.Round(CDec(importe / cantidad), 2)
                    r.SetValue("pumn", precioUnitario)
                Else
                    r.SetValue("pumn", 0)
                End If

                r.SetValue("baseimponible", base)
                r.SetValue("vcmn", base)
                r.SetValue("igv", igv)

            Case "pumn"
                Dim cantidad As Decimal? = CDec(r.GetValue("cantidad"))
                Dim precio As Decimal? = value
                Dim importe As Decimal? = precio * cantidad
                Dim base = Math.Round(CDec(CalculoBaseImponible(importe, iva)), 2)
                Dim igv = importe - base

                r.SetValue("baseimponible", base)
                r.SetValue("vcmn", base)
                r.SetValue("igv", igv)
        End Select
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyUp
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        If cc.Renderer Is Nothing Then Exit Sub
        Dim style As GridTableCellStyleInfo = TryCast(cc.Renderer.CurrentStyle, GridTableCellStyleInfo)

        If style IsNot Nothing Then
            If style.TableCellIdentity.Column Is Nothing Then Exit Sub    
                Select Case style.TableCellIdentity.Column.Name
                    Case "cantidad"
                        If e.Inner.KeyData = Keys.Enter Then
                        e.TableControl.Table.CurrentRecord.SetCurrent("totalmn")
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

    Private Sub FormNotaDeCompra_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        With FormCanastaCompras
            .GridItems.Table.Records.DeleteAll()
            .txtFiltrar.Clear()
        End With
    End Sub
#End Region

End Class