Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmVentaPV
    Inherits frmMaster
    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String
    Dim time As Integer = 0
    Public Property TieneCotizacionInfo() As Boolean
    Public Property IdDocumentoCotizacion() As Integer?
    '    Public Property ListadoProveedores As New List(Of entidad)
    Public Property listaServicio As New List(Of servicio)
    Dim proveedor As String
    Dim idProveedor As Integer


#Region "Attributes"
    Public Property InventarioSA As New TotalesAlmacenSA
#End Region

    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        GetTableGrid()
        UbicarDocumento(intIdDocumento)
        dgvCompra.Enabled = True
        btGrabar.Enabled = False
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Docking()
        GridCFG(GridGroupingControl2)
        GridCFG(dgvCompra)
        Loadcontroles()
        ConfiguracionInicio()
        GetTableGrid()
        'cboServicio.SelectedValue = -1
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT1", Me.Text, GEstableciento.IdEstablecimiento)
        IdDocumentoCotizacion = Nothing
        ConfiguracionColumnsGridArticulos()
        txtFiltrar.Select()
        UbicarServicios()
    End Sub

    Public Sub New(TieneCotizacion As Boolean, intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Docking()
        GridCFG(GridGroupingControl2)
        GridCFG(dgvCompra)
        Loadcontroles()
        ConfiguracionInicio()
        GetTableGrid()

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT1", Me.Text, GEstableciento.IdEstablecimiento)
        UbicarDocumentoCotizacionDetails(intIdDocumento)
        TieneCotizacion = TieneCotizacion
        TieneCotizacionInfo = intIdDocumento
        ConfiguracionColumnsGridArticulos()
    End Sub

    Public Sub ConfiguracionColumnsGridArticulos()
        GridDataBoundGrid1.GridBoundColumns("idEmpresa").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("destino").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("idItem").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("idPres").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("presentacion").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("puKardexmn").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("puKardexme").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("idalmacen").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("almacen").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("importeME").Hidden = True
        GridDataBoundGrid1.GridBoundColumns("importeMn").Hidden = True

        'Tamaño de encabezado

        GridDataBoundGrid1.GridBoundColumns("descripcion").HeaderText = "Artículos"
        GridDataBoundGrid1.GridBoundColumns("cantidad").HeaderText = "Cant."
        GridDataBoundGrid1.GridBoundColumns("unidad").HeaderText = "U.M."
        GridDataBoundGrid1.GridBoundColumns("descripcion").Width = 220

        GridDataBoundGrid1.GridBoundColumns("btn").HeaderText = "Action"

        Dim style As GridStyleInfo = GridDataBoundGrid1.GridBoundColumns(14).StyleInfo
        style.TextColor = Color.FromKnownColor(KnownColor.HotTrack)
        style.TextAlign = GridTextAlign.Default
        style.CellType = "PushButton"
        style.Description = "agregar"
        style.HorizontalAlignment = GridHorizontalAlignment.Center
    End Sub

    Public Sub UbicarServicios()
        Dim servicioSA As New servicioSA

        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("idServicio")

        For Each i In servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = Nothing, .idPadre = 1015})
            Dim dr As DataRow = dt.NewRow
            dr(0) = "GS"
            dr(1) = i.cuenta
            dr(2) = i.descripcion
            dr(3) = i.idServicio
            dt.Rows.Add(dr)

        Next
        dgvServicios.DataSource = dt
        dgvServicios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub CargarPrecios()
        Dim precioSA As New ConfiguracionPrecioSA
        Dim precio As New List(Of configuracionPrecio)
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("cboprecio").Appearance.AnyRecordFieldCell

        precio.AddRange(precioSA.ListadoPrecios())
        'precio.Add(New configuracionPrecio With {.idPrecio = 0, .precio = "-Ver tabla de precios-"})

        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = precio ' precioSA.ListadoPrecios()
        ggcStyle.ValueMember = "idPrecio"
        ggcStyle.DisplayMember = "precio"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Public Sub UbicarDocumentoCotizacionDetails(intIdDocumento As Integer)
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0

        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA

        For Each i In objDocCompraDet.usp_EditarDetalleVenta(intIdDocumento)
            colBI = 0
            colBIme = 0

            Igv = 0
            IgvME = 0

            Select Case i.destino
                Case "1"
                    colBI = CDec(i.importeMN) / 1.18
                    colBIme = CDec(i.importeME) / 1.18

                    Igv = colBI * (TmpIGV / 100)
                    IgvME = colBIme * (TmpIGV / 100)

                Case "2"
                    colBI = i.importeMN
                    colBIme = i.importeME

                    Igv = 0
                    IgvME = 0
            End Select



            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", i.stock)

            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        TotalTalesXcolumna()
    End Sub

    Sub ConteoLabelVentas()
        lblConteo.Text = "Artículos en Canasta: " & dgvCompra.Table.Records.Count
    End Sub

    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal

        Public Property BaseMN2() As Decimal
        Public Property BaseME2() As Decimal

        Public Property BaseMN3() As Decimal
        Public Property BaseME3() As Decimal

        Public Property IgvMN() As Decimal
        Public Property IgvME() As Decimal
        Public Property TotalMN() As Decimal
        Public Property TotalME() As Decimal

        Public Property base1() As Decimal
        Public Property base1me() As Decimal
        Public Property base2() As Decimal
        Public Property base2me() As Decimal
        Public Property MontoIgv1() As Decimal
        Public Property MontoIgv1me() As Decimal
        Public Property MontoIgv2() As Decimal
        Public Property MontoIgv2me() As Decimal

        Public Property PercepcionMN() As Decimal
        Public Property PercepcionME() As Decimal

        Public Sub New()
            BaseMN = 0
            BaseME = 0
            BaseMN2 = 0
            BaseME2 = 0
            BaseMN3 = 0
            BaseME3 = 0
            IgvMN = 0
            IgvME = 0
            TotalMN = 0
            TotalME = 0
            base1 = 0
            base1me = 0
            base2 = 0
            base2me = 0
            MontoIgv1 = 0
            MontoIgv1me = 0
            MontoIgv2 = 0
            MontoIgv2me = 0
            PercepcionMN = 0
            PercepcionME = 0
        End Sub


    End Class

    Public Function TieneCuentaFinanciera() As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA
        Dim valBool As Boolean = False

        GFichaUsuarios = New GFichaUsuario

        If IsNothing(GFichaUsuarios.NombrePersona) Then
            With frmFichaUsuarioCaja
                ModuloAppx = ModuloSistema.CAJA
                .lblNivel.Text = "Caja"
                .lblEstadoCaja.Visible = True
                '.GroupBox1.Visible = True
                '.GroupBox2.Visible = True
                '.GroupBox4.Visible = True
                '.cboMoneda.Visible = True
                .Timer1.Enabled = True
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    valBool = False
                    '   Return False
                Else
                    valBool = True
                    '   Return True
                End If
            End With
        End If
        Return valBool
    End Function

    Private Sub Docking()

        ' Me.dockingManager1.DockControl(Me.PanelMontos, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 152)

        Me.dockingManager1.DockControl(Me.PanelCanasta, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)
        'dockingManager1.DockControlInAutoHideMode(PanelCanasta, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        Me.dockingManager1.DockControl(Me.Panel5, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)
        dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 461)

        DockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        dockingManager1.SetDockLabel(PanelCanasta, "Canasta de Inventario")
        dockingManager1.SetDockLabel(Panel5, "Servicios")
        '    dockingManager1.SetDockLabel(PanelMontos, "Importes del Comprobante")
        dockingManager1.CloseEnabled = False
    End Sub

    Sub ConfiguracionInicio()
        'Me.WindowState = FormWindowState.Maximized
        TotalesXcanbeceras = New TotalesXcanbecera()
        Dim almacenSA As New almacenSA
        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen

        If Not IsNothing(GFichaUsuarios) Then
            ToolStripButton1.Image = ImageListAdv1.Images(1)
            dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        Else
            dgvCompra.TableDescriptor.Columns("chPago").Width = 0
            ToolStripButton1.Image = ImageListAdv1.Images(0)
            GFichaUsuarios = Nothing
        End If

        'confgiurando variables generales
        txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text
        txtIva.DoubleValue = TmpIGV / 100
        '   lblPerido.Text =  lblPerido.Text
        txtTipoCambio.DecimalValue = TmpTipoCambio

        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Dim colorx As New GridMetroColors()
#Region "Métodos"

    Public Sub AgregarAcanastaServicvioCodigoBarra(r As Record, precio As configuracionPrecioProducto)
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        'If rbMenor.Checked = True Then
        '    valTipoVenta = "MN"
        valPUmn = precio.precioMN
        valPUme = precio.precioME


        Me.Cursor = Cursors.WaitCursor
        'Dim valTipoVenta As String = Nothing
        'Dim valPUmn As Decimal = 0
        'Dim valPUme As Decimal = 0
        Dim tasaIva As Decimal = TmpIGV / 100
        'Dim productoSA As New detalleitemsSA

        'valPUmn = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciomn")
        'valPUme = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciome")

        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        If cboDestino.Text = "2-Exonerado" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "2")
        Else
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
        End If

        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", r.GetValue("idServicio"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("item", r.GetValue("descripcion"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("um", "07")
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", 1)
        If cboDestino.Text = "2-Exonerado" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", valPUmn)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
        Else
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", (valPUmn / (tasaIva + 1)))
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)

            Dim iv As Decimal = 0
            iv = valPUmn / (tasaIva + 1)

            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", (iv * tasaIva))
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", iv * tasaIva)
        End If
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", valPUmn)
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", valPUme)

        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "GS")
        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

        Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", 0)

        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
        '   If .tipoExistencia <> "GS" Then
        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", 0)
        'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
        '   End If
        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", String.Empty)

        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", precio.idPrecio)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", r.GetValue("idServicio"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantEntregar", 1)
        Me.dgvCompra.Table.CurrentRecord.SetValue("cantPendiente", 1)

        Me.dgvCompra.Table.AddNewRecord.EndEdit()

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        TotalTalesXcolumna()

    End Sub

    Public Sub GetExistenciaByCodigoBar(CodigoBarra As String)
        Dim totalSA As New TotalesAlmacenSA
        Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim existenciaSA As New detalleitemsSA
        'Dim existencia As New detalleitems

        'existencia = existenciaSA.GetExistenciaByCodeBar(CodigoBarra)
        Dim lista = totalSA.GetProductosByAlmacenCodigo(0, CodigoBarra)


        GetListaProductosEmpresaByCodigoBarra(lista)
        If GridDataBoundGrid1.Model.RowCount > 0 Then

        End If

        'If gridGroupingControl1.Table.Records.Count > 0 Then
        '    gridGroupingControl1.Table.Records(0).SetCurrent()
        '    gridGroupingControl1.Table.Records(0).SetSelected(True)


        '    Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, gridGroupingControl1.Table.Records(0).GetValue("idItem"))

        '    If listaPrecios.Count > 0 Then
        '        AgregarAcanastaCodigoBarra(gridGroupingControl1.Table.CurrentRecord, listaPrecios(0))
        '    Else
        '        MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'End If



    End Sub

    Public Sub UbicarUltimosPreciosXproductoBarCode(intIdItem As Integer)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdItem)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl2.DataSource = dt
        GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Public Sub UbicarUltimosPreciosXproducto()
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl2.DataSource = dt
        GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    'Public Sub UbicarUltimosPreciosServicio(intIdServicio As Integer)
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    Dim dt As New DataTable("Historial de últimas entradas ")
    '    dt.Columns.Add("fecha")
    '    dt.Columns.Add("idPrecio")
    '    dt.Columns.Add("Precio")
    '    dt.Columns.Add("tipoConfig")
    '    dt.Columns.Add("tasa")
    '    dt.Columns.Add("Preciomn")
    '    dt.Columns.Add("Preciome")

    '    For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdServicio)
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.fecha
    '        dr(1) = i.idPrecio
    '        dr(2) = i.descripcion
    '        dr(3) = IIf(i.tipo = "P", "%", "Fijo")
    '        dr(4) = i.valPorcentaje
    '        dr(5) = i.precioMN
    '        dr(6) = i.precioME
    '        dt.Rows.Add(dr)
    '    Next
    '    dgvPreciosServicio.DataSource = dt
    '    dgvPreciosServicio.TableOptions.ListBoxSelectionMode = SelectionMode.One
    'End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA
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
            DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            If Not IsNothing(DocumentoGuia) Then
                With DocumentoGuia
                    txtSerieGuia.Text = .Serie
                    txtNumeroGuia.Text = .Numero
                End With
            End If

            'CABECERA COMPROBANTE
            With objDocCompra.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
                txtFecha.Value = .fechaDoc
                lblPerido.Text = .fechaPeriodo
                cboTipoDoc.SelectedValue = .tipoDocumento
                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

                        cboMoneda.SelectedValue = 1
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                        cboMoneda.SelectedValue = 2
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idCliente).FirstOrDefault
                If Not IsNothing(nEntidad) Then
                    txtRuc2.Text = nEntidad.nrodoc
                    txtCliente2.Tag = nEntidad.idEntidad
                    txtCliente2.Text = nEntidad.nombreCompleto
                Else

                End If

                TXTcOMPRADOR.Text = .nombrePedido

                txtTipoCambio.DecimalValue = .tipoCambio
                txtIva.DoubleValue = .tasaIgv / 100
                txtGlosa.Text = .glosa
            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            PanelCanasta.Visible = False
            Panel5.Visible = False
            For Each i In objDocCompraDet.usp_EditarDetalleVenta(intIdDocumento)

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", i.stock)

                'Select Case i.estadoPago
                '    Case TIPO_VENTA.PAGO.COBRADO
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
                '    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
                'End Select

                'Select Case i.bonificacion
                '    Case "S"
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", True)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "S")
                '    Case "N"
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                '        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                'End Select

                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            btGrabar.Enabled = False
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub


    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        grid.TableOptions.SelectionBackColor = Color.Gray
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFG2(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim almacenSA As New almacenSA
        Dim entidadSA As New entidadSA
        Dim servicioSA As New servicioSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0


        'listaServicio.Clear()
        'listaServicio = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = Nothing, .idPadre = 1015})
        'cboServicio.DisplayMember = "descripcion"
        'cboServicio.ValueMember = "idServicio"
        'cboServicio.DataSource = listaServicio


        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetUbicarTablaexistencia

        'ListadoProveedores = New List(Of entidad)
        'ListadoProveedores = entidadSA.ObtenerListaEntidad(TIPO_ENTIDAD.CLIENTE, Gempresas.IdEmpresaRuc)
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idProducto", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("um", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("vcmn", GetType(Decimal))
        dt.Columns.Add("pcmn", GetType(Decimal))
        dt.Columns.Add("totalmn", GetType(Decimal))
        dt.Columns.Add("vcme", GetType(Decimal))
        dt.Columns.Add("pcme", GetType(Decimal))
        dt.Columns.Add("totalme", GetType(Decimal))
        dt.Columns.Add("igvmn", GetType(Decimal))
        dt.Columns.Add("igvme", GetType(Decimal))

        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("marca", GetType(String))
        dt.Columns.Add("almacen", GetType(String))
        dt.Columns.Add("caja", GetType(String))

        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("chPago", GetType(Boolean))
        dt.Columns.Add("valPago", GetType(String))

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))
        dt.Columns.Add("presentacion", GetType(String))

        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("puKardex", GetType(Decimal))
        dt.Columns.Add("pukardeme", GetType(Decimal))
        dt.Columns.Add("canDisponible", GetType(Decimal))
        dt.Columns.Add("costoMN", GetType(Decimal))
        dt.Columns.Add("costoME", GetType(Decimal))
        dt.Columns.Add("tipoPrecio", GetType(String))
        dt.Columns.Add("cat", GetType(Integer))
        dt.Columns.Add("codBarra", GetType(String))
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("cboprecio", GetType(String))
        dgvCompra.DataSource = dt
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean
        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtCliente2.Text = .nombreCompleto
                txtCliente2.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        Else
            txtCliente2.Clear()
            '  txtCuenta.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub

    Sub TotalTalesXcolumna()
        Dim totalpercepMN As Decimal = 0
        Dim totalpercepME As Decimal = 0

        'VC01
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        'VC02
        Dim totalVC2 As Decimal = 0
        Dim totalVCme2 As Decimal = 0

        'VC03
        Dim totalVC3 As Decimal = 0
        Dim totalVCme3 As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        For Each r As Record In dgvCompra.Table.Records
            totalpercepMN += CDec(r.GetValue("percepcionMN"))
            totalpercepME += CDec(r.GetValue("percepcionME"))

            'If r.GetValue("valBonif") = "S" Then
            '    totalDesc += CDec(r.GetValue("igvmn"))
            '    totalDescme += CDec(r.GetValue("igvme"))
            'Else

            Select Case r.GetValue("gravado")
                Case OperacionGravada.Grabado
                    totalVC += CDec(r.GetValue("vcmn"))
                    totalVCme += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Exonerado
                    totalVC2 += CDec(r.GetValue("vcmn"))
                    totalVCme2 += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Inafecto
                    totalVC3 += CDec(r.GetValue("vcmn"))
                    totalVCme3 += CDec(r.GetValue("vcme"))
            End Select



            totalIVA += CDec(r.GetValue("igvmn"))
            totalIVAme += CDec(r.GetValue("igvme"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))
            'End If

            Select Case r.GetValue("gravado")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    igv1 += CDec(r.GetValue("igvmn"))
                    igv1me += CDec(r.GetValue("igvme"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    igv2 += CDec(r.GetValue("igvmn"))
                    igv2me += CDec(r.GetValue("igvme"))
            End Select




        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.PercepcionMN = totalpercepMN
        TotalesXcanbeceras.PercepcionME = totalpercepME

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.BaseMN2 = totalVC2
        TotalesXcanbeceras.BaseME2 = totalVCme2

        TotalesXcanbeceras.BaseMN3 = totalVC3
        TotalesXcanbeceras.BaseME3 = totalVCme3

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        '****************************************************
        If cboMoneda.SelectedValue = 1 Then
            txtTotalBase3.DecimalValue = totalVC3
            txtTotalBase2.DecimalValue = totalVC2
            txtTotalBase.DecimalValue = totalVC
            txtTotalIva.Text = ((totalIVA))
            'Label4.Text = Decimal.Round(totalIVA)
            'Button1.Text = (CDec(totalIVA))
            txtTotalPagar.DecimalValue = total
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        Else
            txtTotalBase3.DecimalValue = totalVCme3
            txtTotalBase2.DecimalValue = totalVCme2
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar.DecimalValue = totalme
            lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        End If


    End Sub


    'Sub Calculos()
    '    Dim colcantidad As Decimal = 0
    '    Dim cantidadDisponible As Decimal = 0
    '    Dim Igv As Decimal = 0
    '    Dim IgvME As Decimal = 0
    '    Dim totalMN As Decimal = 0
    '    Dim totalME As Decimal = 0
    '    Dim colBI As Decimal = 0
    '    Dim colBIme As Decimal = 0
    '    Dim colPrecUnit As Decimal = 0
    '    Dim colPrecUnitme As Decimal = 0
    '    Dim colDestinoGravado As Integer
    '    Dim colBonifica As String = Nothing

    '    Dim valPercepMN As Decimal = 0
    '    Dim valPercepME As Decimal = 0

    '    Dim colCostoMN As Decimal = 0
    '    Dim colCostoME As Decimal = 0
    '    Dim colPrecUnitAlmacen As Decimal = 0
    '    Dim colPrecUnitUSAlmacen As Decimal = 0

    '    Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
    '    Select Case strTipoExistencia
    '        Case "GS"
    '            colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
    '            cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '            colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
    '            colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
    '            colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
    '            colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
    '            colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

    '            colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
    '            colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

    '            totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
    '            totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

    '            If colDestinoGravado = 1 Then
    '                Dim iva As Decimal = TmpIGV / 100
    '                colBI = (totalMN / (iva + 1))
    '                colBIme = (totalME / (iva + 1))

    '                Dim iv As Decimal = 0
    '                Dim iv2 As Decimal = 0
    '                iv = totalMN / (iva + 1)
    '                iv2 = totalME / (iva + 1)

    '                Igv = iv * (iva)
    '                IgvME = iv2 * (iva)
    '            Else

    '                colBI = 0
    '                colBIme = 0
    '                Igv = 0
    '                IgvME = 0

    '            End If

    '            '****************************************************************

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
    '            If colcantidad > 0 Then



    '                'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
    '                'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

    '            Else

    '            End If

    '            Select Case colDestinoGravado
    '                Case 1
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                Case 2
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '            End Select
    '            TotalTalesXcolumna()
    '        Case Else
    '            If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

    '                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
    '                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '                colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
    '                colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
    '                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
    '                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
    '                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

    '                colCostoMN = colcantidad * colPrecUnitAlmacen
    '                colCostoME = colcantidad * colPrecUnitUSAlmacen

    '                totalMN = colcantidad * colPrecUnit
    '                totalME = colcantidad * colPrecUnitme

    '                If colDestinoGravado = 1 Then
    '                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
    '                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
    '                Else
    '                    valPercepMN = 0
    '                    valPercepME = 0

    '                End If

    '                '****************************************************************
    '                Dim iva As Decimal = TmpIGV / 100

    '                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
    '                If colcantidad > 0 Then

    '                    colBI = (totalMN / (iva + 1))
    '                    colBIme = (totalME / (iva + 1))

    '                    Dim iv As Decimal = 0
    '                    Dim iv2 As Decimal = 0
    '                    iv = totalMN / (iva + 1)
    '                    iv2 = totalME / (iva + 1)

    '                    Igv = iv * (iva)
    '                    IgvME = iv2 * (iva)

    '                    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
    '                    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

    '                Else
    '                    colBI = 0
    '                    colBIme = 0
    '                    Igv = 0
    '                    IgvME = 0
    '                End If

    '                Select Case colDestinoGravado
    '                    Case 1
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                    Case 2
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                End Select
    '                TotalTalesXcolumna()
    '            Else
    '                dgvCompra.Table.CurrentRecord.EndEdit()
    '                lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
    '                'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                txtTotalBase.Text = 0.0
    '                txtTotalBase2.Text = 0.0
    '                txtTotalIva.Text = 0.0
    '                lblTotalPercepcion.Text = 0.0
    '                txtTotalPagar.Text = 0.0
    '                PanelError.Visible = True
    '                Timer1.Enabled = True
    '                TiempoEjecutar(10)
    '            End If
    '    End Select
    'End Sub


    '''' <summary>
    '''' Calculo de importes de venta
    '''' </summary>
    '''' <param name="r"></param>
    'Sub CalculoRecord(r As Record)
    '    Dim colcantidad As Decimal = 0
    '    Dim cantidadDisponible As Decimal = 0
    '    Dim ValorVenta As Decimal = 0
    '    Dim ValorVentaME As Decimal = 0
    '    Dim totalMN As Decimal = 0
    '    Dim totalME As Decimal = 0
    '    Dim colDestinoGravado As Integer
    '    Dim colCostoMN As Decimal = 0
    '    Dim colCostoME As Decimal = 0
    '    Dim colPrecUnitAlmacen As Decimal = 0
    '    Dim colPrecUnitUSAlmacen As Decimal = 0
    '    Dim resulIGV As Decimal = 0
    '    Dim resulIGVME As Decimal = 0

    '    Dim strTipoExistencia As String = r.GetValue("tipoExistencia")
    '    Select Case strTipoExistencia
    '        Case TipoExistencia.ServicioGasto

    '        Case Else

    '            If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

    '                colcantidad = r.GetValue("cantidad")
    '                cantidadDisponible = r.GetValue("canDisponible")
    '                colPrecUnitAlmacen = r.GetValue("puKardex")
    '                colPrecUnitUSAlmacen = r.GetValue("pukardeme")
    '                Dim colPrecUnit = r.GetValue("pumn")
    '                Dim colPrecUnitme = r.GetValue("pume")
    '                colDestinoGravado = r.GetValue("gravado")

    '                colCostoMN = colcantidad * colPrecUnitAlmacen
    '                colCostoME = colcantidad * colPrecUnitUSAlmacen

    '                totalMN = colcantidad * colPrecUnit
    '                totalME = colcantidad * colPrecUnitme

    '                '****************************************************************
    '                '0.18+1
    '                Dim iva As Decimal = (TmpIGV / 100) + 1

    '                r.SetValue("cantidad", colcantidad)
    '                If colcantidad > 0 Then
    '                    'Valor de venta = total / 1.18
    '                    ValorVenta = Math.Round(totalMN / iva, 2)
    '                    ValorVentaME = Math.Round(totalME / iva, 2)
    '                    'Igv = Total - ValorDeVenta
    '                    resulIGV = totalMN - ValorVenta
    '                    resulIGVME = totalME - ValorVenta
    '                    'Total = Igv + Valor de venta
    '                Else
    '                    ValorVenta = 0
    '                    ValorVentaME = 0
    '                    resulIGV = 0
    '                    resulIGVME = 0
    '                End If

    '                Select Case colDestinoGravado
    '                    Case 1
    '                        CalculoConImpuesto(r, ValorVenta, ValorVentaME,
    '                                           resulIGV, resulIGVME,
    '                                           totalMN, totalME,
    '                                           colPrecUnit, colPrecUnitme,
    '                                           colCostoMN, colCostoME)
    '                    Case 2
    '                        ClaculoSinImpuesto(r, totalMN, totalME, colCostoMN, colCostoME, colPrecUnit, colPrecUnitme)
    '                End Select
    '                TotalTalesXcolumna()
    '            Else
    '                r.EndEdit()
    '                lblEstado.Text = "La cantidad disponible es: " & r.GetValue("canDisponible")
    '                LimpiarRecordSelected(r)
    '                PanelError.Visible = True
    '                Timer1.Enabled = True
    '                TiempoEjecutar(10)
    '            End If
    '    End Select

    'End Sub

    ''' <summary>
    ''' Limpia la fila seleccionada
    ''' </summary>
    ''' <param name="r"></param>
    Private Sub LimpiarRecordSelected(r As Record)
        r.SetValue("cantidad", 0.0)
        r.SetValue("vcmn", 0)
        r.SetValue("vcme", 0)
        'r.SetValue("pumn", colPrecUnit)
        'r.SetValue("pume", colPrecUnitme)
        r.SetValue("totalmn", 0)
        r.SetValue("totalme", 0)
        r.SetValue("igvmn", 0)
        r.SetValue("igvme", 0)
        r.SetValue("percepcionMN", 0)
        r.SetValue("percepcionME", 0)
        r.SetValue("costoMN", 0)
        r.SetValue("costoME", 0)
        txtTotalBase.Text = 0.0
        txtTotalBase2.Text = 0.0
        txtTotalIva.Text = 0.0
        lblTotalPercepcion.Text = 0.0
        txtTotalPagar.Text = 0.0
    End Sub

    'Private Sub ClaculoSinImpuesto(r As Record, totalMN As Decimal, totalME As Decimal, colCostoMN As Decimal, colCostoME As Decimal, colPrecUnit As Decimal, colPrecUnitme As Decimal)
    '    r.SetValue("vcmn", totalMN)
    '    r.SetValue("vcme", totalME)
    '    r.SetValue("pumn", colPrecUnit)
    '    r.SetValue("pume", colPrecUnitme)
    '    r.SetValue("totalmn", totalMN)
    '    r.SetValue("totalme", totalME)
    '    r.SetValue("igvmn", 0)
    '    r.SetValue("igvme", 0)
    '    r.SetValue("percepcionMN", 0)
    '    r.SetValue("percepcionME", 0)
    '    r.SetValue("costoMN", colCostoMN)
    '    r.SetValue("costoME", colCostoME)
    'End Sub


    'Private Sub CalculoConImpuesto(r As Record, ValorVenta As Decimal, valorVentaME As Decimal,
    '                               Igv As Decimal, IgvME As Decimal,
    '                               totalMN As Decimal, totalME As Decimal,
    '                               precioUnit As Decimal, precioUnitME As Decimal,
    '                               colCostoMN As Decimal, colCostoME As Decimal)

    '    r.SetValue("vcmn", ValorVenta)
    '    r.SetValue("vcme", valorVentaME)
    '    r.SetValue("pumn", precioUnit)
    '    r.SetValue("pume", precioUnitME)
    '    r.SetValue("totalmn", totalMN)
    '    r.SetValue("totalme", totalME)
    '    r.SetValue("igvmn", Igv)
    '    r.SetValue("igvme", IgvME)
    '    r.SetValue("percepcionMN", 0)
    '    r.SetValue("percepcionME", 0)
    '    r.SetValue("costoMN", colCostoMN)
    '    r.SetValue("costoME", colCostoME)
    'End Sub

    'Sub Calculos()
    '    Dim colcantidad As Decimal = 0
    '    Dim cantidadDisponible As Decimal = 0
    '    Dim Igv As Decimal = 0
    '    Dim IgvME As Decimal = 0
    '    Dim totalMN As Decimal = 0
    '    Dim totalME As Decimal = 0
    '    Dim colBI As Decimal = 0
    '    Dim colBIme As Decimal = 0
    '    Dim colPrecUnit As Decimal = 0
    '    Dim colPrecUnitme As Decimal = 0
    '    Dim colDestinoGravado As Integer
    '    Dim colBonifica As String = Nothing

    '    Dim valPercepMN As Decimal = 0
    '    Dim valPercepME As Decimal = 0

    '    Dim colCostoMN As Decimal = 0
    '    Dim colCostoME As Decimal = 0
    '    Dim colPrecUnitAlmacen As Decimal = 0
    '    Dim colPrecUnitUSAlmacen As Decimal = 0

    '    Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
    '    Select Case strTipoExistencia
    '        Case "GS"
    '            colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
    '            cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '            colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
    '            colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
    '            colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
    '            colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
    '            colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

    '            colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
    '            colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

    '            totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
    '            totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

    '            If colDestinoGravado = 1 Then
    '                Dim iva As Decimal = TmpIGV / 100
    '                colBI = (totalMN / (iva + 1))
    '                colBIme = (totalME / (iva + 1))

    '                Dim iv As Decimal = 0
    '                Dim iv2 As Decimal = 0
    '                iv = totalMN / (iva + 1)
    '                iv2 = totalME / (iva + 1)

    '                Igv = iv * (iva)
    '                IgvME = iv2 * (iva)
    '            Else

    '                colBI = 0
    '                colBIme = 0
    '                Igv = 0
    '                IgvME = 0

    '            End If

    '            '****************************************************************

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
    '            If colcantidad > 0 Then



    '                'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
    '                'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

    '            Else

    '            End If

    '            Select Case colDestinoGravado
    '                Case 1
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                Case 2
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '            End Select
    '            TotalTalesXcolumna()
    '        Case Else
    '            If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

    '                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
    '                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '                colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
    '                colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
    '                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
    '                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
    '                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

    '                colCostoMN = colcantidad * colPrecUnitAlmacen
    '                colCostoME = colcantidad * colPrecUnitUSAlmacen

    '                totalMN = colcantidad * colPrecUnit
    '                totalME = colcantidad * colPrecUnitme

    '                If colDestinoGravado = 1 Then
    '                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
    '                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
    '                Else
    '                    valPercepMN = 0
    '                    valPercepME = 0

    '                End If

    '                '****************************************************************
    '                Dim iva As Decimal = TmpIGV / 100

    '                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
    '                If colcantidad > 0 Then

    '                    colBI = (totalMN / (iva + 1))
    '                    colBIme = (totalME / (iva + 1))

    '                    Dim iv As Decimal = 0
    '                    Dim iv2 As Decimal = 0
    '                    iv = totalMN / (iva + 1)
    '                    iv2 = totalME / (iva + 1)

    '                    Igv = iv * (iva)
    '                    IgvME = iv2 * (iva)

    '                    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
    '                    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

    '                Else
    '                    colBI = 0
    '                    colBIme = 0
    '                    Igv = 0
    '                    IgvME = 0
    '                End If

    '                Select Case colDestinoGravado
    '                    Case 1
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                    Case 2
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                End Select
    '                TotalTalesXcolumna()
    '            Else
    '                dgvCompra.Table.CurrentRecord.EndEdit()
    '                lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
    '                'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                txtTotalBase.Text = 0.0
    '                txtTotalBase2.Text = 0.0
    '                txtTotalIva.Text = 0.0
    '                lblTotalPercepcion.Text = 0.0
    '                txtTotalPagar.Text = 0.0
    '                PanelError.Visible = True
    '                Timer1.Enabled = True
    '                TiempoEjecutar(10)
    '            End If
    '    End Select
    'End Sub

    'Sub CalculosGasto()
    '    Dim colcantidad As Decimal = 0
    '    Dim cantidadDisponible As Decimal = 0
    '    Dim Igv As Decimal = 0
    '    Dim IgvME As Decimal = 0
    '    Dim totalMN As Decimal = 0
    '    Dim totalME As Decimal = 0
    '    Dim colBI As Decimal = 0
    '    Dim colBIme As Decimal = 0
    '    Dim colPrecUnit As Decimal = 0
    '    Dim colPrecUnitme As Decimal = 0
    '    Dim colDestinoGravado As Integer
    '    Dim colBonifica As String = Nothing

    '    Dim valPercepMN As Decimal = 0
    '    Dim valPercepME As Decimal = 0

    '    Dim colCostoMN As Decimal = 0
    '    Dim colCostoME As Decimal = 0
    '    Dim colPrecUnitAlmacen As Decimal = 0
    '    Dim colPrecUnitUSAlmacen As Decimal = 0
    '    Dim VC As Decimal = 0
    '    Dim VCme As Decimal = 0

    '    Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
    '    Select Case strTipoExistencia
    '        Case "GS"
    '            VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
    '            VCme = VC / txtTipoCambio.DecimalValue

    '            colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
    '            cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '            colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
    '            colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
    '            colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
    '            colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
    '            colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

    '            colCostoMN = colcantidad * colPrecUnitAlmacen
    '            colCostoME = colcantidad * colPrecUnitUSAlmacen

    '            totalMN = colcantidad * colPrecUnit
    '            totalME = colcantidad * colPrecUnitme

    '            If colDestinoGravado = 1 Then
    '                valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
    '                valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
    '            Else
    '                valPercepMN = 0
    '                valPercepME = 0

    '            End If

    '            '****************************************************************
    '            colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
    '            If colcantidad > 0 AndAlso VC > 0 Then
    '                Igv = VC * (TmpIGV / 100)
    '                IgvME = VCme * (TmpIGV / 100)

    '                colBI = VC + Igv + valPercepMN
    '                colBIme = VCme + IgvME + valPercepMN

    '                colPrecUnit = VC / colcantidad
    '                colPrecUnitme = VCme / colcantidad
    '            ElseIf colcantidad = 0 Then
    '                Igv = VC * (TmpIGV / 100)
    '                IgvME = VCme * (TmpIGV / 100)
    '                colBI = VC + Igv + valPercepMN
    '                colBIme = VCme + IgvME + valPercepME
    '                colPrecUnit = 0
    '                colPrecUnitme = 0
    '            Else
    '                colPrecUnit = 0
    '                colPrecUnitme = 0

    '                colBI = 0
    '                colBIme = 0
    '                Igv = 0
    '                IgvME = 0
    '            End If

    '            Select Case colDestinoGravado
    '                Case 1
    '                    'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
    '                Case 2
    '                    'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
    '                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
    '            End Select
    '            TotalTalesXcolumna()
    '        Case Else
    '            If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

    '                VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
    '                VCme = VC / txtTipoCambio.DecimalValue

    '                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
    '                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '                colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
    '                colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
    '                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
    '                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
    '                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

    '                colCostoMN = colcantidad * colPrecUnitAlmacen
    '                colCostoME = colcantidad * colPrecUnitUSAlmacen

    '                totalMN = colcantidad * colPrecUnit
    '                totalME = colcantidad * colPrecUnitme

    '                If colDestinoGravado = 1 Then
    '                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
    '                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
    '                Else
    '                    valPercepMN = 0
    '                    valPercepME = 0

    '                End If

    '                '****************************************************************
    '                colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
    '                If colcantidad > 0 AndAlso VC > 0 Then
    '                    Igv = VC * (TmpIGV / 100)
    '                    IgvME = VCme * (TmpIGV / 100)

    '                    colBI = VC + Igv + valPercepMN
    '                    colBIme = VCme + IgvME + valPercepMN

    '                    colPrecUnit = VC / colcantidad
    '                    colPrecUnitme = VCme / colcantidad
    '                ElseIf colcantidad = 0 Then
    '                    Igv = VC * (TmpIGV / 100)
    '                    IgvME = VCme * (TmpIGV / 100)
    '                    colBI = VC + Igv + valPercepMN
    '                    colBIme = VCme + IgvME + valPercepME
    '                    colPrecUnit = 0
    '                    colPrecUnitme = 0
    '                Else
    '                    colPrecUnit = 0
    '                    colPrecUnitme = 0

    '                    colBI = 0
    '                    colBIme = 0
    '                    Igv = 0
    '                    IgvME = 0
    '                End If

    '                Select Case colDestinoGravado
    '                    Case 1
    '                        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
    '                    Case 2
    '                        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
    '                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
    '                End Select
    '                TotalTalesXcolumna()
    '            Else
    '                lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
    '                'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
    '                'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
    '                txtTotalBase.Text = 0.0
    '                txtTotalBase2.Text = 0.0
    '                txtTotalIva.Text = 0.0
    '                lblTotalPercepcion.Text = 0.0
    '                txtTotalPagar.Text = 0.0
    '                PanelError.Visible = True
    '                Timer1.Enabled = True
    '                TiempoEjecutar(10)
    '            End If
    '    End Select
    'End Sub

    Sub Calculos()
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
            Select Case strTipoExistencia
                Case "GS"
                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                    colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                    totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
                    totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        Dim iva As Decimal = TmpIGV / 100
                        colBI = (totalMN / (iva + 1))
                        colBIme = (totalME / (iva + 1))

                        Dim iv As Decimal = 0
                        Dim iv2 As Decimal = 0
                        iv = totalMN / (iva + 1)
                        iv2 = totalME / (iva + 1)

                        Igv = iv * (iva)
                        IgvME = iv2 * (iva)
                    Else

                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0

                    End If

                    '****************************************************************

                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then



                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    Else

                    End If

                    Select Case colDestinoGravado
                        Case 1
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                Case Else
                    If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                        colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                        colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                        colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                        colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                        colCostoMN = colcantidad * colPrecUnitAlmacen
                        colCostoME = colcantidad * colPrecUnitUSAlmacen

                        totalMN = colcantidad * colPrecUnit
                        totalME = colcantidad * colPrecUnitme

                        If colDestinoGravado = 1 Then
                            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                        Else
                            valPercepMN = 0
                            valPercepME = 0

                        End If

                        '****************************************************************
                        Dim iva As Decimal = TmpIGV / 100

                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                        If colcantidad > 0 Then

                            colBI = (totalMN / (iva + 1))
                            colBIme = (totalME / (iva + 1))

                            Dim iv As Decimal = 0
                            Dim iv2 As Decimal = 0
                            iv = totalMN / (iva + 1)
                            iv2 = totalME / (iva + 1)

                            Igv = iv * (iva)
                            IgvME = iv2 * (iva)

                            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If

                        Select Case colDestinoGravado
                            Case 1
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            Case 2
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        End Select
                        TotalTalesXcolumna()
                    Else
                        dgvCompra.Table.CurrentRecord.EndEdit()
                        lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        txtTotalBase.Text = 0.0
                        txtTotalBase2.Text = 0.0
                        txtTotalIva.Text = 0.0
                        lblTotalPercepcion.Text = 0.0
                        txtTotalPagar.Text = 0.0
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
            End Select
        End If
    End Sub

    Sub CalculosGasto()
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0

        Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        Select Case strTipoExistencia
            Case "GS"
                VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                VCme = VC / txtTipoCambio.DecimalValue

                colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                colCostoMN = colcantidad * colPrecUnitAlmacen
                colCostoME = colcantidad * colPrecUnitUSAlmacen

                totalMN = colcantidad * colPrecUnit
                totalME = colcantidad * colPrecUnitme

                If colDestinoGravado = 1 Then
                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                Else
                    valPercepMN = 0
                    valPercepME = 0

                End If

                '****************************************************************
                colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                If colcantidad > 0 AndAlso VC > 0 Then
                    Igv = VC * (TmpIGV / 100)
                    IgvME = VCme * (TmpIGV / 100)

                    colBI = VC + Igv + valPercepMN
                    colBIme = VCme + IgvME + valPercepMN

                    colPrecUnit = VC / colcantidad
                    colPrecUnitme = VCme / colcantidad
                ElseIf colcantidad = 0 Then
                    Igv = VC * (TmpIGV / 100)
                    IgvME = VCme * (TmpIGV / 100)
                    colBI = VC + Igv + valPercepMN
                    colBIme = VCme + IgvME + valPercepME
                    colPrecUnit = 0
                    colPrecUnitme = 0
                Else
                    colPrecUnit = 0
                    colPrecUnitme = 0

                    colBI = 0
                    colBIme = 0
                    Igv = 0
                    IgvME = 0
                End If

                Select Case colDestinoGravado
                    Case 1
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                    Case 2
                        'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                End Select
                TotalTalesXcolumna()
            Case Else
                If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                    VCme = VC / txtTipoCambio.DecimalValue

                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = colcantidad * colPrecUnitAlmacen
                    colCostoME = colcantidad * colPrecUnitUSAlmacen

                    totalMN = colcantidad * colPrecUnit
                    totalME = colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                        valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 AndAlso VC > 0 Then
                        Igv = VC * (TmpIGV / 100)
                        IgvME = VCme * (TmpIGV / 100)

                        colBI = VC + Igv + valPercepMN
                        colBIme = VCme + IgvME + valPercepMN

                        colPrecUnit = VC / colcantidad
                        colPrecUnitme = VCme / colcantidad
                    ElseIf colcantidad = 0 Then
                        Igv = VC * (TmpIGV / 100)
                        IgvME = VCme * (TmpIGV / 100)
                        colBI = VC + Igv + valPercepMN
                        colBIme = VCme + IgvME + valPercepME
                        colPrecUnit = 0
                        colPrecUnitme = 0
                    Else
                        colPrecUnit = 0
                        colPrecUnitme = 0

                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If

                    Select Case colDestinoGravado
                        Case 1
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", colBI)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", colBIme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                        Case 2
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", totalMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", 0)
                    End Select
                    TotalTalesXcolumna()
                Else
                    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", colBI)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", colBIme)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", totalMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", totalME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Igv)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", IgvME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    txtTotalBase.Text = 0.0
                    txtTotalBase2.Text = 0.0
                    txtTotalIva.Text = 0.0
                    lblTotalPercepcion.Text = 0.0
                    txtTotalPagar.Text = 0.0
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select
    End Sub

    Dim precioSA As New ListadoPrecioSA
    'Dim precio As New listadoPrecios
    'Public Sub CargaPrecios(intIdAlmacen As Integer, intIdItem As Integer)
    '    precio = precioSA.UbicarVentaPorItem(intIdAlmacen, intIdItem)

    '    lblMenor.Value = precio.pvmenor.GetValueOrDefault
    '    lblMenorME.Value = precio.pvmenorme.GetValueOrDefault
    '    ' lblDscto.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(2).Text
    '    ' lblDsctoME.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(3).Text

    '    lblMayor.Value = precio.pvmayor.GetValueOrDefault
    '    lblMayorME.Value = precio.pvmayorme.GetValueOrDefault
    '    ' lblDscto.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(6).Text
    '    ' lblDsctoME.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(7).Text

    '    lblGMayor.Value = precio.pvgranmayor.GetValueOrDefault
    '    lblGMayorME.Value = precio.pvgranmayorme.GetValueOrDefault
    '    ' lblDscto.Text = frmCanastaVentas.lsvDetalle.SelectedItems(0).SubItems(10).Text
    '    ' lblDsctoME.Text = frmCanastaPedidos.lsvDetalle.SelectedItems(0).SubItems(11).Text
    '    '     nudCantidad_MouseClick(sender, e)
    'End Sub

    'Private Sub ConfiguracionVenta()
    '    If CDec(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenor")) = 0 Then
    '        lblEstado.Text = "El producto no tiene configurado un precio.!!"
    '    Else
    '        CargaPrecios(txtAlmacen.Tag, Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))
    '        txtFiltrar.Clear()
    '        txtFiltrar.Focus()
    '    End If
    'End Sub

    Public Sub AgregarAcanastaCodigoBarra(precio As configuracionPrecioProducto)
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        valPUmn = precio.precioMN
        valPUme = precio.precioME

        With productoSA.InvocarProductoID(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem"))
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "destino"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "descripcion"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "unidad"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "puKardexmn"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "puKardexme"))

            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            '   If .tipoExistencia <> "GS" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idalmacen"))
            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
            '   End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "almacen"))

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", precio.idPrecio)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

            Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)
            Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idEmpresa"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With
        'txtBarCode.Select()
        'txtBarCode.SelectAll()


    End Sub

    Public Sub AgregarAcanastaCodigoBarra_Index(precio As configuracionPrecioProducto, index As Integer)
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        valPUmn = precio.precioMN
        valPUme = precio.precioME

        With productoSA.InvocarProductoID(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", index))
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "destino", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "descripcion", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "unidad", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "puKardexmn", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "puKardexme", index))

            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            '   If .tipoExistencia <> "GS" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idalmacen", index))
            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
            '   End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "almacen", index))

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", precio.idPrecio)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

            Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)
            Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idEmpresa", index))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With
        'txtBarCode.Select()
        'txtBarCode.SelectAll()


    End Sub

    Public Sub AgregarAcanasta()
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        valPUmn = Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciomn")
        valPUme = Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciome")

        With productoSA.InvocarProductoID(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem"))
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "destino"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "descripcion"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "unidad"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "puKardexmn"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "puKardexme"))

            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            '   If .tipoExistencia <> "GS" Then
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idalmacen"))
            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
            '   End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "almacen"))

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Me.GridGroupingControl2.Table.CurrentRecord.GetValue("idPrecio"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

            Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)
            Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idEmpresa"))
            Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With

    End Sub

    'Public Sub AgregarAcanastaServicio()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim valTipoVenta As String = Nothing
    '    Dim valPUmn As Decimal = 0
    '    Dim valPUme As Decimal = 0
    '    Dim tasaIva As Decimal = TmpIGV / 100
    '    Dim productoSA As New detalleitemsSA


    '    Select Case cboMoneda.SelectedValue
    '        Case 1
    '            valPUmn = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciomn")
    '            valPUme = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciome")

    '            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '            If cboDestino.Text = "2-Exonerado" Then
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "2")
    '            Else
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
    '            End If

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", cboServicio.SelectedValue)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("item", cboServicio.Text)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("um", "07")
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", 0)
    '            If cboDestino.Text = "2-Exonerado" Then
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", valPUmn)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)

    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '            Else
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", (valPUmn / (tasaIva + 1)))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0)

    '                Dim iv As Decimal = 0
    '                iv = valPUmn / (tasaIva + 1)

    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", (iv * tasaIva))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", iv * tasaIva)
    '            End If
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", valPUmn)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", valPUme)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "GS")
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", 0)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
    '            '   If .tipoExistencia <> "GS" Then
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", 0)
    '            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
    '            '   End If
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", String.Empty)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("idPrecio"))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", cboServicio.SelectedValue)
    '            Me.dgvCompra.Table.AddNewRecord.EndEdit()

    '            dgvCompra.TableControl.CurrentCell.EndEdit()
    '            dgvCompra.TableControl.Table.TableDirty = True
    '            dgvCompra.TableControl.Table.EndEdit()
    '        Case 2

    '            valPUmn = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciomn")
    '            valPUme = Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("Preciome")

    '            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '            If cboDestino.Text = "2-Exonerado" Then
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "2")
    '            Else
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
    '            End If

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", cboServicio.SelectedValue)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("item", cboServicio.Text)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("um", "07")
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", 0)
    '            If cboDestino.Text = "2-Exonerado" Then
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", valPUmn)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)

    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '            Else
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", (valPUmn / (tasaIva + 1)))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", (valPUme / (tasaIva + 1)))

    '                Dim iv As Decimal = 0
    '                iv = valPUmn / (tasaIva + 1)

    '                Dim ivme As Decimal = 0
    '                ivme = (valPUme / (tasaIva + 1))

    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", (iv * tasaIva))
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", ivme * tasaIva)
    '            End If
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", valPUmn)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", valPUme)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "GS")
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", 0)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", 0)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
    '            '   If .tipoExistencia <> "GS" Then
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", 0)
    '            'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
    '            '   End If
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", String.Empty)

    '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Me.dgvPreciosServicio.Table.CurrentRecord.GetValue("idPrecio"))
    '            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", cboServicio.SelectedValue)
    '            Me.dgvCompra.Table.AddNewRecord.EndEdit()

    '            dgvCompra.TableControl.CurrentCell.EndEdit()
    '            dgvCompra.TableControl.Table.TableDirty = True
    '            dgvCompra.TableControl.Table.EndEdit()


    '    End Select

    '    TotalTalesXcolumna()
    'End Sub

    Private Sub AceptarPrecioProducto(intDisponible As Decimal)
        AgregarAcanasta()
    End Sub

    'Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
    '    Dim CanastaSA As New TotalesAlmacenSA
    '    Dim listaSA As New ListadoPrecioSA
    '    Dim lista As New listadoPrecios

    '    Dim dt As New DataTable()
    '    Try
    '        dt.Columns.Add("destino", GetType(String))
    '        dt.Columns.Add("idItem", GetType(Integer))
    '        dt.Columns.Add("descripcion", GetType(String))
    '        dt.Columns.Add("unidad", GetType(String))
    '        dt.Columns.Add("idPres", GetType(String))
    '        dt.Columns.Add("presentacion", GetType(String))
    '        dt.Columns.Add("cantidad", GetType(Decimal))
    '        dt.Columns.Add("puKardexmn", GetType(Decimal))
    '        dt.Columns.Add("puKardexme", GetType(Decimal))
    '        dt.Columns.Add("importeMn", GetType(Decimal))
    '        dt.Columns.Add("importeME", GetType(Decimal))
    '        dt.Columns.Add("pvmenor", GetType(Decimal))
    '        dt.Columns.Add("pvmenorme", GetType(Decimal))
    '        dt.Columns.Add("pvmayor", GetType(Decimal))
    '        dt.Columns.Add("pvmayorme", GetType(Decimal))
    '        dt.Columns.Add("pvGmayor", GetType(Decimal))
    '        dt.Columns.Add("pvGmayorme", GetType(Decimal))

    '        'ListView1.Items.Clear()
    '        Dim cprecioVentaFinalMenorMN As Decimal = 0
    '        Dim cprecioVentaFinalMenorME As Decimal = 0
    '        Dim cmontoDsctounitMenorMN As Decimal = 0
    '        Dim cmontoDsctounitMenorME As Decimal = 0
    '        Dim cprecioVentaFinalMayorMN As Decimal = 0
    '        Dim cprecioVentaFinalGMayorMN As Decimal = 0
    '        Dim cprecioVentaFinalMayorME As Decimal = 0
    '        Dim cprecioVentaFinalGMayorME As Decimal = 0
    '        Dim cdetalleMenor As String = Nothing
    '        Dim cdetalleMayor As String = Nothing
    '        Dim cdetalleGMayor As String = Nothing
    '        For Each i As totalesAlmacen In CanastaSA.ObtenerCanastaDeVentaPorProducto(IntIdAlmacen, strTipoExistencia, strProducto)
    '            If CDec(i.cantidad) > 0 Then
    '                Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
    '                Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

    '                lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui
    '                '    Case "NIVA"
    '                'lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "NIVA")
    '                'End Select

    '                If Not IsNothing(lista) Then
    '                    With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
    '                        cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
    '                        cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
    '                        cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
    '                        cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
    '                        cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
    '                        cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
    '                        cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
    '                        cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)
    '                        'cdetalleMenor = .detalleMenor
    '                        'cdetalleMayor = .detalleMayor
    '                        'cdetalleGMayor = .detalleGMayor
    '                    End With
    '                Else
    '                    lblEstado.Text = "EL producto no contiene una configuración de precio.!"
    '                    lblEstado.Image = My.Resources.warning2
    '                End If

    '                Dim dr As DataRow = dt.NewRow()
    '                dr(0) = i.origenRecaudo
    '                dr(1) = i.idItem
    '                dr(2) = i.descripcion
    '                dr(3) = i.unidadMedida
    '                dr(4) = i.Presentacion
    '                dr(5) = i.NombrePresentacion
    '                dr(6) = i.cantidad
    '                dr(7) = valPrecUnitario
    '                dr(8) = valPrecUnitarioUS
    '                dr(9) = i.importeSoles
    '                dr(10) = i.importeDolares

    '                dr(11) = cprecioVentaFinalMenorMN
    '                dr(12) = cprecioVentaFinalMenorME
    '                dr(13) = cprecioVentaFinalMayorMN
    '                dr(14) = cprecioVentaFinalMayorME
    '                dr(15) = cprecioVentaFinalGMayorMN
    '                dr(16) = cprecioVentaFinalGMayorME
    '                dt.Rows.Add(dr)
    '            End If
    '        Next
    '        gridGroupingControl1.DataSource = dt
    '        gridGroupingControl1.TableDescriptor.Relations.Clear()
    '        gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '        gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '        'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
    '        gridGroupingControl1.GroupDropPanel.Visible = True
    '        gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Sub CargarPrecioXproducto(intIdAlmacen As Integer, intIdItem As Integer)
    '    Dim lista As New List(Of listadoPrecios)
    '    Dim listaPrecioSA As New ListadoPrecioSA

    '    lista = listaPrecioSA.PrecioVentaXitemXiva(intIdAlmacen, intIdItem, Nothing) ' no funciona aqui

    'End Sub


    Private Sub ObtenerCanastaVentaFiltroEmpresa(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))

            'ListView1.Items.Clear()
            Dim cprecioVentaFinalMenorMN As Decimal = 0
            Dim cprecioVentaFinalMenorME As Decimal = 0
            Dim cmontoDsctounitMenorMN As Decimal = 0
            Dim cmontoDsctounitMenorME As Decimal = 0
            Dim cprecioVentaFinalMayorMN As Decimal = 0
            Dim cprecioVentaFinalGMayorMN As Decimal = 0
            Dim cprecioVentaFinalMayorME As Decimal = 0
            Dim cprecioVentaFinalGMayorME As Decimal = 0
            Dim cdetalleMenor As String = Nothing
            Dim cdetalleMayor As String = Nothing
            Dim cdetalleGMayor As String = Nothing


            For Each i As totalesAlmacen In InventarioSA.GetListadoProductosByAlmacen(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = "", .idEmpresa = Gempresas.IdEmpresaRuc}).OrderBy(Function(o) o.descripcion).ToList
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)
                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.idEmpresa
                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares
                    dr(12) = i.idAlmacen
                    dr(13) = i.NomAlmacen
                    dt.Rows.Add(dr)
                End If
            Next
            GridDataBoundGrid1.DataSource = dt
            GridDataBoundGrid1.Binder.EnableAddNew = False
            GridGroupingControl2.Table.Records.DeleteAll()
            If GridDataBoundGrid1.Model.RowCount > 0 Then
                UbicarUltimosPreciosXproducto()
            End If
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub GetListaProductosEmpresaByCodigoBarra(lista As List(Of totalesAlmacen))
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))


            For Each i As totalesAlmacen In lista
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)
                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.idEmpresa
                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares
                    dr(12) = i.idAlmacen
                    dr(13) = i.NomAlmacen
                    dt.Rows.Add(dr)
                End If
            Next
            GridDataBoundGrid1.DataSource = dt
            GridDataBoundGrid1.Binder.EnableAddNew = False
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idEmpresa", GetType(String))
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("idalmacen", GetType(Integer))
            dt.Columns.Add("almacen", GetType(String))

            For Each i As totalesAlmacen In InventarioSA.GetListadoProductosParaVentaXproducto(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .tipoExistencia = strTipoExistencia, .descripcion = strProducto, .NomAlmacen = "", .idEmpresa = Gempresas.IdEmpresaRuc})
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.idEmpresa
                    dr(1) = i.origenRecaudo
                    dr(2) = i.idItem
                    dr(3) = i.descripcion
                    dr(4) = i.unidadMedida
                    dr(5) = i.Presentacion
                    dr(6) = i.NombrePresentacion
                    dr(7) = i.cantidad
                    dr(8) = valPrecUnitario
                    dr(9) = valPrecUnitarioUS
                    dr(10) = i.importeSoles
                    dr(11) = i.importeDolares
                    dr(12) = i.idAlmacen
                    dr(13) = i.NomAlmacen
                    dt.Rows.Add(dr)
                End If
            Next
            GridDataBoundGrid1.DataSource = dt
            GridDataBoundGrid1.Binder.EnableAddNew = False
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerExistenciaByCode(IntIdAlmacen As Integer, intIdExistencia As Integer)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim i As New totalesAlmacen
        Dim listaSA As New ListadoPrecioSA
        'Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))

            'ListView1.Items.Clear()
            Dim cprecioVentaFinalMenorMN As Decimal = 0
            Dim cprecioVentaFinalMenorME As Decimal = 0
            Dim cmontoDsctounitMenorMN As Decimal = 0
            Dim cmontoDsctounitMenorME As Decimal = 0
            Dim cprecioVentaFinalMayorMN As Decimal = 0
            Dim cprecioVentaFinalGMayorMN As Decimal = 0
            Dim cprecioVentaFinalMayorME As Decimal = 0
            Dim cprecioVentaFinalGMayorME As Decimal = 0
            Dim cdetalleMenor As String = Nothing
            Dim cdetalleMayor As String = Nothing
            Dim cdetalleGMayor As String = Nothing

            i = CanastaSA.GetListadoProductosParaVentaXbarCode(New totalesAlmacen With {.idAlmacen = IntIdAlmacen, .idItem = intIdExistencia})

            If Not IsNothing(i) Then
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
                    Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.origenRecaudo
                    dr(1) = i.idItem
                    dr(2) = i.descripcion
                    dr(3) = i.unidadMedida
                    dr(4) = i.Presentacion
                    dr(5) = i.NombrePresentacion
                    dr(6) = i.cantidad
                    dr(7) = valPrecUnitario
                    dr(8) = valPrecUnitarioUS
                    dr(9) = i.importeSoles
                    dr(10) = i.importeDolares
                    dt.Rows.Add(dr)
                End If
            End If

            GridDataBoundGrid1.DataSource = dt
            GridDataBoundGrid1.Binder.EnableAddNew = False
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub


    Public Function AS_CAJA(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = GFichaUsuarios.IdCajaDestino,
              .descripcion = GFichaUsuarios.NomCajaDestinb,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente2.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        nMovimiento.cuenta = "69112"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        nMovimiento.cuenta = "20111"
        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Sub AsientoVenta(listadoExistencias As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoExistencias
                         Into totalMN = Sum(n.importeMN),
                         TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente2.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = "Jiuni"
        Else
            nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)



        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoExistencias
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoExistencias
            MV_Item_Transito(i.DetalleItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)
            nMovimiento = New movimiento
            nMovimiento.cuenta = "70111"
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = "Jiuni"
            nAsiento.movimiento.Add(nMovimiento)
        Next
        'For Each r As Record In dgvCompra.Table.Records
        '    MV_Item_Transito(r.GetValue("item"), r.GetValue("costoMN"), r.GetValue("costoME"), r.GetValue("tipoExistencia"))
        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "70111"
        '    nMovimiento.descripcion = r.GetValue("item")
        '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        '    nMovimiento.monto = CDec(r.GetValue("vcmn"))
        '    nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    nMovimiento.usuarioActualizacion = "Jiuni"
        '    nAsiento.movimiento.Add(nMovimiento)
        'Next

    End Sub

    Sub AsientoVentaServicios(listadoServicios As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoServicios
                    Into totalMN = Sum(n.importeMN),
                    TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente2.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = "Jiuni"
        Else
            nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoServicios
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoServicios
            nMovimiento = New movimiento
            nMovimiento.cuenta = i.idItem
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = "Jiuni"
            nAsiento.movimiento.Add(nMovimiento)
        Next
        'For Each r As Record In dgvCompra.Table.Records
        '    MV_Item_Transito(r.GetValue("item"), r.GetValue("costoMN"), r.GetValue("costoME"), r.GetValue("tipoExistencia"))
        '    nMovimiento = New movimiento
        '    nMovimiento.cuenta = "70111"
        '    nMovimiento.descripcion = r.GetValue("item")
        '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        '    nMovimiento.monto = CDec(r.GetValue("vcmn"))
        '    nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    nMovimiento.usuarioActualizacion = "Jiuni"
        '    nAsiento.movimiento.Add(nMovimiento)
        'Next

    End Sub

    Public Function AS_Cliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1212",
              .descripcion = txtCliente2.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        '    GConfiguracion.NombreComprobante = "" 'TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            'If Not IsNothing(.configAlmacen) Then
    '            '    'Dim estableSA As New establecimientoSA
    '            '    'With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '            '    '    GConfiguracion.IdAlmacen = .idAlmacen
    '            '    '    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '            '    '    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '            '    '    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '            '    '    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '            '    '        'txtIdEstableAlmacen.Text = .idCentroCosto
    '            '    '        'txtEstableAlmacen.Text = .nombre
    '            '    '    End With
    '            '    'End With
    '            'End If
    '            'If Not IsNothing(.ConfigentidadFinanciera) Then
    '            '    With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '            '        GConfiguracion.IDCaja = .idestado
    '            '        GConfiguracion.NomCaja = .descripcion
    '            '    End With
    '            'End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = "" ' TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Grabar()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        If (chIdentificacion.Checked = False) Then
            proveedor = txtCliente2.Text
            idProveedor = CInt(txtCliente2.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.TieneCotizacion = TieneCotizacionInfo
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = New DateTime(txtFecha.Value.Year, txtFecha.Value.Month, txtFecha.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
        ndocumento.idEntidad = Val(idProveedor)
        ndocumento.entidad = proveedor
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.nrodocEntidad = txtRuc2.Text
        ndocumento.tipoOperacion = "01"
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now


        'Dim idproveeedor As Integer
        'Dim comprador As String

        'If chIdentificacion.Checked = False Then
        '    idproveeedor = txtCliente2.Tag
        '    comprador = txtCliente2.Text

        'Else
        '    idproveeedor = Nothing
        '    comprador = TXTcOMPRADOR.Text
        'End If

        nDocumentoVenta = New documentoventaAbarrotes With {
            .IdDocumentoCotizacion = IdDocumentoCotizacion,
                  .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = New DateTime(txtFecha.Value.Year, txtFecha.Value.Month, txtFecha.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second),
                  .fechaPeriodo = lblPerido.Text,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = idProveedor,
                  .nombrePedido = proveedor,
                  .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2"),
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO,
                  .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                  .glosa = txtGlosa.Text.Trim,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            Select Case r.GetValue("valPago")
                Case "Pagado"
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Case Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End Select
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = New DateTime(txtFecha.Value.Year, txtFecha.Value.Month, txtFecha.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second) ' txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = Nothing
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = Nothing
            Else
                objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")
            If CDec(r.GetValue("cantidad")) <= 0 Then
                MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = Nothing

            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value())
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value())

            Dim cat = r.GetValue("cat")
            If Not IsNothing(cat) Then
                If cat.ToString.Trim.Length > 0 Then
                    objDocumentoVentaDet.categoria = r.GetValue("cat")
                Else
                    objDocumentoVentaDet.categoria = Nothing
                End If
            Else
                objDocumentoVentaDet.categoria = Nothing
            End If


            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = Date.Now

            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)
        Next
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
            Dim listaTotalAlmacen As Integer = VentaSA.SaveVentaTicketPS(ndocumento, Nothing)

            If (Not IsNothing(listaTotalAlmacen)) Then
                lblEstado.Text = "venta registrada!"
                ' statusForm.lblMensaje.Text = "..estableciendo..."
                '   Dim strNumDoc As String = String.Format("{0:00000}", Convert.ToInt32(docVentaSA.GetUbicar_documentoventaAbarrotesPorID(xcod).numeroDoc))
                Dim strNumDoc As String = Convert.ToInt32(docVentaSA.GetUbicar_documentoventaAbarrotesPorID(listaTotalAlmacen).numeroDoc)
                'TimerCustom.Enabled = True
                'TimerCustom.Start()
                Dim statusForm As New frmMensajeCodigoVenta
                statusForm.StartPosition = FormStartPosition.CenterScreen
                statusForm.lblMensaje.Text = strNumDoc '.Replace("0", "")
                statusForm.ShowDialog()

                'If MessageBox.Show("Va realizar un nuevo pedido", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                '    Close()
                '    Dim objPleaseWait As New FeedbackForm()
                '    objPleaseWait.StartPosition = FormStartPosition.CenterScreen
                '    objPleaseWait.Show()
                '    Application.DoEvents()
                '    Dim f As New frmVentaPV
                '    objPleaseWait.Close()
                '    f.lblPerido.Text = MesGeneral & "/" & AnioGeneral
                '    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                '    f.WindowState = FormWindowState.Maximized
                '    f.StartPosition = FormStartPosition.CenterParent
                '    f.ShowDialog()
                'Else
                '    Close()
                'End If

                ' statusForm.Dispose()
                Dispose()
            Else
                lblEstado.Text = "Excedio la cantidad de venta"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                limpiarCajas()
            End If
        Else
            Throw New Exception("Debe verificar que las celdas estan completas!")
        End If

    End Sub

    'Sub UpdateVenta()
    '    Dim VentaSA As New documentoVentaAbarrotesSA
    '    Dim ndocumento As New documento()
    '    Dim DocCaja As New documento

    '    Dim ListaTotales As New List(Of totalesAlmacen)
    '    Dim ListaDeleteEO As New List(Of totalesAlmacen)

    '    Dim nDocumentoVenta As New documentoventaAbarrotes()
    '    Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
    '    Dim entidadSA As New entidadSA
    '    Dim entidad As New entidad

    '    Dim asientoSA As New AsientoSA
    '    ' Dim ListaAsiento As New List(Of asiento)
    '    Dim nAsiento As New asiento
    '    Dim nMovimiento As New movimiento

    '    Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
    '    With ndocumento
    '        .Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        .idDocumento = lblIdDocumento.Text
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idCentroCosto = GEstableciento.IdEstablecimiento
    '        If IsNothing(GProyectos) Then
    '        Else
    '            .idProyecto = GProyectos.IdProyectoActividad
    '        End If
    '        .tipoDoc = GConfiguracion.TipoComprobante
    '        .fechaProceso = fecha
    '        .nroDoc = txtSerie & "-" & NumeroComprobante
    '        .idOrden = Nothing ' Me.IdOrden
    '        .tipoOperacion = "01"
    '        .usuarioActualizacion = "NN"
    '        .fechaActualizacion = DateTime.Now
    '    End With

    '    With nDocumentoVenta
    '        .idDocumento = lblIdDocumento.Text
    '        If IsNothing(GProyectos) Then
    '        Else
    '            .idPadre = GProyectos.IdProyectoActividad
    '        End If
    '        .TipoDocNumeracion = Nothing
    '        .codigoLibro = "8"
    '        .tipoDocumento = txtIdComprobante
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idEstablecimiento = GEstableciento.IdEstablecimiento
    '        .fechaDoc = fecha ' PERIODO
    '        .fechaPeriodo =  lblPerido.Text
    '        .serie = txtSerie
    '        .numeroDoc = NumeroComprobante
    '        .nombrePedido = txtCliente.Text
    '        ' .nombrePedido = txtPedidoRef.Text
    '        .moneda = IIf(cboMoneda.SelectedValue, "1", "2")
    '        .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
    '        .tipoCambio = txtTipoCambio.Value

    '        '****************** DESTINO EN SOLES ************************************************************************
    '        .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
    '        .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))

    '        .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
    '        .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))

    '        .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
    '        .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))

    '        .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
    '        .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))

    '        '****************************************************************************************************************

    '        '****************** DESTINO EN DOLARES ************************************************************************
    '        .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
    '        .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))

    '        .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
    '        .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))

    '        .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
    '        .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))

    '        .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
    '        .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))

    '        '****************************************************************************************************************
    '        .ImporteNacional = IIf(txtTotalPedidomn.Text = 0 Or txtTotalPedidomn.Text = "0.00", CDec(0.0), CDec(txtTotalPedidomn.Text))
    '        .ImporteExtranjero = IIf(txtTotalPedidome.Text = 0 Or txtTotalPedidome.Text = "0.00", CDec(0.0), CDec(txtTotalPedidome.Text))

    '        .tipoVenta = TIPO_VENTA.VENTA_AL_TICKET
    '        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
    '        .glosa = GlosaVenta()
    '        '    .RE = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
    '        ' = TIPO_VENTA.VENTA_PAGADA
    '        ' .DocumentoSustentado = "S"
    '        .usuarioActualizacion = "Jiuni"
    '        .fechaActualizacion = DateTime.Now
    '    End With
    '    ndocumento.documentoventaAbarrotes = nDocumentoVenta

    '    For Each i As DataGridViewRow In dgvNuevoDoc.Rows

    '        Dim almacenSA As New almacenSA
    '        objDocumentoVentaDet = New documentoventaAbarrotesDet
    '        objDocumentoVentaDet.idDocumento = lblIdDocumento.Text
    '        objDocumentoVentaDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
    '        objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
    '        objDocumentoVentaDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
    '        objDocumentoVentaDet.FechaDoc = fecha

    '        objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
    '        objDocumentoVentaDet.idAlmacenOrigen = CDec(dgvNuevoDoc.Rows(i.Index).Cells(24).Value())
    '        objDocumentoVentaDet.establecimientoOrigen = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
    '        objDocumentoVentaDet.cuentaOrigen = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
    '        objDocumentoVentaDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
    '        objDocumentoVentaDet.DetalleItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
    '        objDocumentoVentaDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
    '        objDocumentoVentaDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
    '        objDocumentoVentaDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim
    '        objDocumentoVentaDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())
    '        objDocumentoVentaDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(29).Value()
    '        objDocumentoVentaDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(31).Value()
    '        objDocumentoVentaDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
    '        objDocumentoVentaDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
    '        objDocumentoVentaDet.importeMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
    '        objDocumentoVentaDet.importeME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
    '        objDocumentoVentaDet.descuentoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(12).Value())
    '        objDocumentoVentaDet.descuentoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value())

    '        objDocumentoVentaDet.montokardex = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value())
    '        objDocumentoVentaDet.montoIsc = CDec(dgvNuevoDoc.Rows(i.Index).Cells(15).Value())
    '        objDocumentoVentaDet.montoIgv = CDec(dgvNuevoDoc.Rows(i.Index).Cells(16).Value())
    '        objDocumentoVentaDet.otrosTributos = CDec(dgvNuevoDoc.Rows(i.Index).Cells(17).Value())
    '        '**********************************************************************************
    '        objDocumentoVentaDet.montokardexUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value())
    '        objDocumentoVentaDet.montoIscUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(19).Value())
    '        objDocumentoVentaDet.montoIgvUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(20).Value())
    '        objDocumentoVentaDet.otrosTributosUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(21).Value())
    '        '  objDocumentoVentaDet.PreEvento = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
    '        objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
    '        '**********************************************************************************
    '        objDocumentoVentaDet.importeMNK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value())
    '        objDocumentoVentaDet.importeMEK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value())
    '        objDocumentoVentaDet.fechaVcto = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()), Nothing, CDate(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))

    '        objDocumentoVentaDet.salidaCostoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value()) ' CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())
    '        objDocumentoVentaDet.salidaCostoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value()) 'CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())

    '        objDocumentoVentaDet.preEvento = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(27).Value()), Nothing, dgvNuevoDoc.Rows(i.Index).Cells(27).Value())
    '        objDocumentoVentaDet.usuarioModificacion = "Jiuni"
    '        objDocumentoVentaDet.fechaModificacion = Date.Now
    '        objDocumentoVentaDet.tipoVenta = dgvNuevoDoc.Rows(i.Index).Cells(32).Value()
    '        If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
    '            objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
    '        ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
    '            objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
    '        ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
    '            objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
    '        End If

    '        objDocumentoVentaDet.Glosa = GlosaVenta()

    '        ListaDetalle.Add(objDocumentoVentaDet)
    '        '   End If
    '    Next

    '    ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
    '    'TOTALES ALMACEN
    '    ListaTotales = ListaTotalesAlmacen()
    '    ListaDeleteEO = ListaDeleteTotales()
    '    'DocCaja = ComprobanteCaja()

    '    VentaSA.UpdateVentaTicket(ndocumento, ListaTotales, ListaDeleteEO)
    '    lblEstado.Text = "venta modificada!"
    '    lblEstado.Image = My.Resources.ok4

    '    Dispose()
    'End Sub

    Private Sub AsientoItemPagado()
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim cajaSa As New EstadosFinancierosSA
        Try
            nAsiento = New asiento
            nAsiento.idDocumento = 0
            nAsiento.periodo = lblPerido.Text
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = CInt(idProveedor)
            nAsiento.nombreEntidad = proveedor
            nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nAsiento.fechaProceso = txtFecha.Value
            nAsiento.codigoLibro = "14"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
            nAsiento.importeMN = TotalesXcanbeceras.TotalMN
            nAsiento.importeME = TotalesXcanbeceras.TotalME
            nAsiento.glosa = txtGlosa.Text.Trim
            nAsiento.usuarioActualizacion = "jiuni"
            nAsiento.fechaActualizacion = DateTime.Now

            For Each r As Record In dgvCompra.Table.Records
                nMovimiento = New movimiento
                nMovimiento.cuenta = cajaSa.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino).cuenta
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = "1212"
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"
                nAsiento.movimiento.Add(nMovimiento)
            Next
            ListaAsientonTransito.Add(nAsiento)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = CInt(idProveedor)
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tipoCambio = txtTipoCambio.DecimalValue
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("tipoExistencia") <> "GS" Then
                '     If r.GetValue("almacen") <> idAlmacenVirtual Then
                documentoguiaDetalle = New documentoguiaDetalle
                If txtSerieGuia.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                Else
                    Throw New Exception("Ingrese número de serie de la guía!")
                End If
                If txtNumeroGuia.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                Else
                    Throw New Exception("Ingrese el nùmero de la guía!")
                End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.GetValue("idProducto")
                documentoguiaDetalle.descripcionItem = r.GetValue("item")
                documentoguiaDetalle.destino = r.GetValue("gravado")
                documentoguiaDetalle.unidadMedida = r.GetValue("um")
                documentoguiaDetalle.cantidad = CDec(r.GetValue("cantidad"))
                documentoguiaDetalle.precioUnitario = CDec(r.GetValue("pumn"))
                documentoguiaDetalle.precioUnitarioUS = CDec(r.GetValue("pume"))
                documentoguiaDetalle.importeMN = CDec(r.GetValue("totalmn"))
                documentoguiaDetalle.importeME = CDec(r.GetValue("totalme"))
                documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

#End Region



    Private Sub frmVentaPV_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmVentaPV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        CargarPrecios()
        chIdentificacion.Checked = True
        'chIdentificacion.Visible = True
        lblEmpresa.Text = Gempresas.NomEmpresa
        lblEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        lblConteo.Visible = True

        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Agregar nuevo precio")
        ContextMenuStrip.Items.Add("Ver tabla de precios")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler dgvCompra.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        dgvCompra.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = dgvCompra.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu

        Else
            dgvCompra.ContextMenuStrip = ContextMenuStrip
            'If it is not column header cell
            'dgvCompra.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Cursor = Cursors.WaitCursor
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim nuevoprecio As New configuracionPrecioProducto
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then

            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 1
                    If e.ClickedItem.Text = "Agregar nuevo precio" Then
                        Dim f As New frmNuevoPrecio
                        f.txtProducto.Tag = dgvCompra.Table.CurrentRecord.GetValue("idProducto")
                        f.txtProducto.Text = dgvCompra.Table.CurrentRecord.GetValue("item")
                        f.txtGrav.Text = dgvCompra.Table.CurrentRecord.GetValue("gravado")
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()

                        nuevoprecio = precioSA.GetPreciosproductoMaxFecha(Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("idProducto")), Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("cboprecio")))

                        If Not IsNothing(nuevoprecio) Then
                            dgvCompra.Table.CurrentRecord.SetValue("pumn", nuevoprecio.precioMN)
                            dgvCompra.Table.CurrentRecord.SetValue("pume", nuevoprecio.precioME)
                            Calculos()

                        Else
                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                            dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                            Calculos()
                        End If
                    ElseIf e.ClickedItem.Text = "Ver tabla de precios" Then
                        Dim f As New frmPreciosByArticulos(New detalleitems With {.codigodetalle = dgvCompra.Table.CurrentRecord.GetValue("idProducto"),
                                                           .descripcionItem = dgvCompra.Table.CurrentRecord.GetValue("item")})
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                    End If

                Case Else
                    MessageBox.Show("No tiene derechos de administrador, para realizar está tarea", "No autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridDataBoundGrid1_CurrentCellKeyUp(sender As Object, e As KeyEventArgs) Handles GridDataBoundGrid1.CurrentCellKeyUp
        Cursor = Cursors.WaitCursor
        If e.KeyData = Keys.Down Or e.KeyData = Keys.Up Then
            GridGroupingControl2.Table.Records.DeleteAll()
            UbicarUltimosPreciosXproducto()
        End If
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub gridGroupingControl1_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    GridGroupingControl2.Table.Records.DeleteAll()
    '    If Not IsNothing(e.SelectedRecord) Then
    '        UbicarUltimosPreciosXproducto(e.SelectedRecord.Record)
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
            If dgvCompra.Table.Records.Count > 0 Then
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
            End If
            ConteoLabelVentas()
        End If
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumeroGuia.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerieGuia.Clear()
        End Try
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As EventArgs) Handles txtSerieGuia.LostFocus
        Try
            If txtSerieGuia.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerieGuia.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1)) = True Then

                        If Len(txtSerieGuia.Text) <= 2 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1))

                        ElseIf Len(txtSerieGuia.Text) <= 3 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 2))

                        ElseIf Len(txtSerieGuia.Text) <= 4 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 3))

                        ElseIf Len(txtSerieGuia.Text) <= 5 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 4))

                        End If
                    End If
                Else

                    txtSerieGuia.Select()
                    txtSerieGuia.Focus()
                    txtSerieGuia.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerieGuia.Select()
                txtSerieGuia.Focus()
                txtSerieGuia.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtSerieGuia.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumeroGuia.Clear()
        End Try
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As EventArgs) Handles txtNumeroGuia.LostFocus
        Try
            If txtNumeroGuia.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumeroGuia.Select()
            txtNumeroGuia.Focus()
            txtNumeroGuia.Clear()
            lblEstado.Text = "Error de formato verifique el ingreso!"
        End Try
    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb19.ButtonStateChanged
        If Not IsNothing(TotalesXcanbeceras) Then
            If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                cboMoneda.SelectedValue = 2
            ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                cboMoneda.SelectedValue = 1
            End If
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc2.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc2.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFiltrar_Click(sender As Object, e As EventArgs) Handles txtFiltrar.Click
        txtFiltrar.SelectAll()
    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltrar.Text.Trim.Length > 0 Then
                ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)


                If chempresa.Checked = True Then
                    ObtenerCanastaVentaFiltro(0, cboTipoExistencia.SelectedValue, txtFiltrar.Text.Trim)

                ElseIf chempresa.Checked = False Then

                    ObtenerCanastaVentaFiltroEmpresa(cboAlmacen.SelectedValue, cboTipoExistencia.SelectedValue, txtFiltrar.Text.Trim)
                End If

                lblEstado.Text = "productos encontrados: " & GridDataBoundGrid1.Model.RowCount
            Else
                lblEstado.Text = "Digitar un producto válido!"
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvCompra.KeyPress
        'If e.KeyChar = Convert.ToChar(Keys.Enter) Then
        '    'Como se sabe los lectores de barra al final mandan un {ENTER}
        '    'por eso una vez que lo envía aqui se haces la función que deseas realizar
        '    MessageBox.Show("ds")
        'Else
        '    'e.Handled = True

        'End If
    End Sub

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chPago" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chBonif" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        'e.Style.BackColor = Color.Yellow
                        'e.Style.TextColor = Color.Black
                        e.Style.[ReadOnly] = True
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "totalmn")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "item")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                'Dim cantidadActual = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 7).CellValue
                'Dim cantidadDisponible = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 25).CellValue

                'If cantidadActual > cantidadDisponible Then
                '    e.Style.CellValue = 0
                'End If

                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                End Select


            End If


        End If

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

                Select Case ColIndex
                    Case 1 ' CODIGO BARRA


                    Case 2 ' seleccion de empresa stock

                    Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                        Dim r As Record = dgvCompra.Table.CurrentRecord
                        If Not IsNothing(r) Then

                            Select Case Int32.Parse(r.GetValue("cboprecio"))
                                Case 0
                                    'Dim f As New frmPreciosByArticulos(r)
                                    'f.StartPosition = FormStartPosition.CenterParent
                                    'f.ShowDialog()

                                Case Else
                                    precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                    If Not IsNothing(precio) Then
                                        r.SetValue("pumn", precio.precioMN)
                                        r.SetValue("pume", precio.precioME)
                                        Calculos()
                                    Else
                                        MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        r.SetValue("pumn", 0)
                                        r.SetValue("pume", 0)
                                        Calculos()
                                    End If
                            End Select

                        Else

                        End If

                End Select
            End If

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor

        UbicarUltimosPreciosXproducto()

        'If gridGroupingControl1.Table.SelectedRecords.Count > 0 Then
        '    Dim f As New frmInsertarPrecio
        '    f.txtid.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))
        '    f.txtDescripcion.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion"))
        '    f.txtxmenor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenor"))
        '    f.txtxmayor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmayor"))
        '    f.txtxgranmayor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvGmayor"))
        '    f.txtalmacen.Text = txtAlmacen.Tag
        '    f.txtxmenorme.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenorme"))
        '    f.txtxmayorme.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmayorme"))
        '    f.txtxgranmayorme.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvGmayorme"))
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            'If Not txtCliente.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingresar un cliente válido"

            '    Timer1.Enabled = True
            '    PanelError.Visible = True
            '    TiempoEjecutar(10)

            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'Else
            '    lblEstado.Text = "Done cliente"

            'End If

            If (chIdentificacion.Checked = True) Then
                If Not TXTcOMPRADOR.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar el nombre de comprador"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done comprador"
                End If
            Else
                If Not txtCliente2.Text.Trim.Length > 0 Then

                    MessageBox.Show("Ingrese el cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCliente2.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                If txtCliente2.Text.Trim.Length > 0 Then
                    If txtCliente2.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtCliente2.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                If txtRuc2.Text.Trim.Length > 0 Then
                    If txtRuc2.ForeColor = Color.Black Then
                        MessageBox.Show("Verificar el ingreso correcto del cliente", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtRuc2.Select()
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If
            End If

            '***********************************************************************
            If dgvCompra.Table.Records.Count > 0 Then
                Me.lblEstado.Text = "Done!"
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    '  If MessageBox.Show("Está seguro de guardar la venta con fecha:" & vbCrLf & txtFecha.Value.Date, "Validar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If txtTotalPagar.DecimalValue >= 700 Then
                        If chIdentificacion.Checked = True Then
                            MessageBox.Show("Debe identificar al cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            chIdentificacion.Checked = False
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If
                    Grabar()
                    'End If
                Else
                    'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    'If Filas > 0 Then
                    '    UpdateCompra()
                    'Else

                    '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                    '    Timer1.Enabled = True
                    '    PanelError.Visible = True
                    '    TiempoEjecutar(10)

                    'End If


                End If
            Else

                Me.lblEstado.Text = "Ingrese items a la canasta de venta!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

            ListaAsientonTransito = New List(Of asiento)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

        'Me.Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
        '    UbicarUltimosPreciosXproducto(Me.gridGroupingControl1.Table.CurrentRecord)
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If IsNothing(GFichaUsuarios) Then
            If TieneCuentaFinanciera() = True Then
                ToolStripButton1.Image = ImageListAdv1.Images(1)
                dgvCompra.TableDescriptor.Columns("chPago").Width = 0
                MessageBoxAdv.Show("Usuario iniciado!")
            Else

            End If
        Else

        End If
    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub
    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvCompra.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex
        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            If IsNothing(GFichaUsuarios) Then
                lblEstado.Text = "Debe iniciar una caja, antes de realizar esta operación.!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                'Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = False
                Exit Sub
            Else
                If style.Enabled Then
                    Dim column As Integer = Me.dgvCompra.TableModel.NameToColIndex("chPago")
                    ' Console.WriteLine("CheckBoxClicked")
                    '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                    If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                        chk = CBool(Me.dgvCompra.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                        e.TableControl.BeginUpdate()

                        e.TableControl.EndUpdate(True)
                    End If
                    If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                        Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                        Dim curStatus As Boolean = Boolean.Parse(style.Text)
                        e.TableControl.BeginUpdate()

                        If curStatus Then
                            '   CheckBoxValue = False
                        End If
                        If curStatus = True Then
                            Dim RowIndex As Integer = e.Inner.RowIndex
                            Dim ColIndex As Integer = e.Inner.ColIndex

                            Me.dgvCompra.TableModel(RowIndex, 19).CellValue = "No Pagado"

                        Else
                            Dim RowIndex As Integer = e.Inner.RowIndex
                            Dim ColIndex As Integer = e.Inner.ColIndex

                            Me.dgvCompra.TableModel(RowIndex, 19).CellValue = "Pagado"



                        End If
                        e.TableControl.EndUpdate()
                        If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                        ElseIf Not ht.Contains(curStatus) Then
                        End If
                        ht.Clear()
                    End If
                End If
            End If


            Me.dgvCompra.TableControl.Refresh()
            TotalTalesXcolumna()
        End If
    End Sub

    'Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs)

    '    If txtServicio.Text.Trim.Length > 0 Then
    '        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
    '        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
    '        Select Case cboDestino.Text
    '            Case "1-Gravado"
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "1")
    '            Case "2-Exonerado"
    '                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", "2")
    '        End Select

    '        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", txtCuenta.Text.Trim)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("item", txtServicio.Text.Trim)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("um", "09")
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", 0)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

    '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", "GS")
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

    '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)

    '        Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", 0)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", 0)

    '        Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

    '        Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
    '        '   If .tipoExistencia <> "GS" Then
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", String.Empty)
    '        'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
    '        '   End If
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", String.Empty)

    '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", (0))
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", (0))
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", Nothing)
    '        Me.dgvCompra.Table.CurrentRecord.SetValue("cat", cboServicio.SelectedValue)
    '        Me.dgvCompra.Table.AddNewRecord.EndEdit()
    '    Else
    '        MessageBox.Show("Debe indicar el servicio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtServicio.Select()
    '    End If
    'End Sub

    Private Sub cboServicio_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub cboServicio_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim servicioSA As New servicioSA
    '    Dim servicio As New servicio
    '    If cboServicio.SelectedIndex > -1 Then
    '        If Not IsNothing(cboServicio.SelectedValue) Then
    '            Dim codValue = cboServicio.SelectedValue
    '            'servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
    '            'txtCuenta.Text = servicio.cuenta
    '            If IsNumeric(codValue) Then
    '                UbicarUltimosPreciosServicio(cboServicio.SelectedValue)

    '                Dim consulta = (From a In listaServicio Where a.idServicio = cboServicio.SelectedValue).FirstOrDefault
    '                txtCuenta.Text = consulta.cuenta
    '            End If
    '        End If
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub
    Private Sub ValidarItemsDuplicados(intIdItem As Integer)
        Dim colIdItem As Integer

        colIdItem = intIdItem

        For Each i In dgvCompra.Table.Records
            If colIdItem = i.GetValue("idProducto") Then
                Throw New Exception("El artículo " & i.GetValue("item") & ", ya se encuentra en la canasta. Ingrese otro")
            End If
        Next
    End Sub
    Private Sub GridGroupingControl2_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles GridGroupingControl2.TableControlCurrentCellControlDoubleClick
        'Me.Cursor = Cursors.WaitCursor
        'Try
        '    If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then

        '        ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
        '        lblProducto.Text = String.Empty
        '        AceptarPrecioProducto(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"))
        '    End If
        '    '    txtBarCode.Select()
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End Try

        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tb19_Click(sender As Object, e As EventArgs) Handles tb19.Click

    End Sub

    Private Sub TimerMesj_Tick(sender As Object, e As EventArgs) Handles TimerMesj.Tick
        'time += 1000
        'If time = 1000 Then

        'End If

        'If time >= 4000 Then
        '    '  Timer3.Stop()
        '    statusForm.Dispose()
        '    'Dispose()
        '    TimerMesj.Enabled = False
        '    PanelError.Visible = False
        'Else

        'End If
    End Sub

    Sub limpiarCajas()
        txtFiltrar.Clear()
        GridGroupingControl2.Table.Records.DeleteAll()
        dgvCompra.Table.Records.DeleteAll()
    End Sub

    Private Sub ToolStrip5_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip5.ItemClicked

    End Sub

    Private Sub TimerCustom_Tick(sender As Object, e As EventArgs) Handles TimerCustom.Tick
        time += 1000
        If time = 1000 Then

        End If

        If time >= 4000 Then
            '  Timer3.Stop()
            'statusForm.Dispose()
            'Dispose()
            TimerMesj.Enabled = False
            PanelError.Visible = False
        Else

        End If
    End Sub

    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarCode.KeyDown

    End Sub

    Private Sub txtBarCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarCode.KeyPress
        Me.Cursor = Cursors.WaitCursor
        If Char.IsDigit(e.KeyChar) Then
            txtBarCode.Select(txtBarCode.Text.Length, 0)
            e.Handled = False
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            'Como se sabe los lectores de barra al final mandan un {ENTER}
            'por eso una vez que lo envía aqui se haces la función que deseas realizar
            If txtBarCode.Text.Trim.Length > 0 Then
                GetExistenciaByCodigoBar(txtBarCode.Text.Trim)

            End If
        Else
            '  e.Handled = True

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBarCode_TextChanged(sender As Object, e As EventArgs) Handles txtBarCode.TextChanged

    End Sub

    Private Sub GridGroupingControl2_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl2.TableControlCellClick

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub dgvPreciosServicio_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    'Private Sub dgvPreciosServicio_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        If Not IsNothing(Me.dgvPreciosServicio.Table.CurrentRecord) Then

    '            ' ValidarItemsDuplicados(Val(dgvPreciosServicio.Table.CurrentRecord.GetValue("idItem")))
    '            txtServicio.Text = String.Empty
    '            AgregarAcanastaServicio()
    '        End If
    '        '    txtBarCode.Select()
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        PanelError.Visible = True
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End Try

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub chIdentificacion_CheckedChanged(sender As Object, e As EventArgs) Handles chIdentificacion.CheckedChanged
        If chIdentificacion.Checked = True Then
            txtCliente2.Visible = False
            txtRuc2.Visible = False
            lblCliente.Visible = False
            GradientPanel7.Visible = False
            PictureBox5.Visible = False
            TXTcOMPRADOR.Visible = True
        Else
            PictureBox5.Visible = True
            txtCliente2.Visible = True
            txtRuc2.Visible = True
            GradientPanel7.Visible = True
            lblCliente.Visible = True
            TXTcOMPRADOR.Visible = False
        End If
    End Sub

    'Private Sub TextBoxExt3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente2.KeyDown
    '    If e.Alt Then
    '        If e.KeyCode = Keys.Down Then
    '            If Not Me.popupControlContainer1.IsShowing() Then
    '                ' Let the popup align around the source textBox.
    '                Me.popupControlContainer1.ParentControl = Me.txtCliente
    '                ' Passing Point.Empty will align it automatically around the above ParentControl.
    '                Me.popupControlContainer1.ShowPopup(Point.Empty)

    '                e.Handled = True
    '            End If
    '        End If
    '    End If
    '    '' Escape should close the popup.
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.popupControlContainer1.IsShowing() Then
    '            Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        If txtCliente.Text.Trim.Length > 0 Then
    '            Me.popupControlContainer1.ParentControl = Me.txtCliente
    '            Me.popupControlContainer1.ShowPopup(Point.Empty)
    '            CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtCliente.Text.Trim)
    '        End If
    '    End If
    'End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        If Not IsNothing(TotalesXcanbeceras) Then
            If cboMoneda.SelectedValue = 2 Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                cboMoneda.SelectedValue = 2
            Else
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
                lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                cboMoneda.SelectedValue = 1
            End If
        End If
    End Sub


    Private Sub txtRuc2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc2.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc2.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc2.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        txtFiltrar.Clear()
        GridGroupingControl2.Table.Records.DeleteAll()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Function pedidoCantidad() As Decimal
        Dim cantidad = InputBox("Ingrese cantidad", "Realizar Venta", 0)
        Return cantidad
    End Function

    Private Sub GridDataBoundGrid1_CellDoubleClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs) Handles GridDataBoundGrid1.CellDoubleClick
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim totalSA As New TotalesAlmacenSA
        'Try
        '    If e.RowIndex <> 0 Then
        '        Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem"))

        '        If listaPrecios.Count > 0 Then
        '            Dim cantidad = InputBox("Ingrese cantidad a vender", "Stock disponible: " & MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad"), "")
        '            If IsNumeric(cantidad) Then
        '                If (CDec(cantidad) > CDec(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad"))) Then
        '                    MessageBox.Show("La cantidad ingresada no debe exceder la disponible!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                    Exit Sub
        '                    Cursor = Cursors.Default
        '                End If

        '                '    ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
        '                AgregarAcanastaCodigoBarra(listaPrecios(0))
        '                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent("cantidad")
        '                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetValue("cantidad", CDec(cantidad))
        '                Calculos()
        '                txtFiltrar.Select()
        '                txtFiltrar.Focus()
        '                txtFiltrar.SelectAll()
        '            Else
        '                MessageBox.Show("Ingrese una cantidad válida!", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                Return
        '            End If
        '        Else
        '            MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End If
        '    End If
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End Try

    End Sub

    'Private Sub gridGroupingControl1_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs)
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    Dim totalSA As New TotalesAlmacenSA
    '    Try
    '        If gridGroupingControl1.Table.Records.Count > 0 Then
    '            Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))

    '            If listaPrecios.Count > 0 Then
    '                Dim cantidad = InputBox("Ingrese cantidad a vender", "Stock disponible: " & gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"), "")

    '                'dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetSelected(True)
    '                '    dgvCompra.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 5, GridSetCurrentCellOptions.SetFocus)
    '                If IsNumeric(cantidad) Then
    '                    If (CDec(cantidad) > CDec(gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"))) Then
    '                        MessageBox.Show("La cantidad ingresada no debe exceder la disponible!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                        Exit Sub
    '                        Cursor = Cursors.Default
    '                    End If

    '                    '    ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
    '                    AgregarAcanastaCodigoBarra(gridGroupingControl1.Table.CurrentRecord, listaPrecios(0))
    '                    'dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
    '                    'dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()

    '                    'dgvCompra.Refresh()
    '                    'dgvCompra.TableControl.CurrentCell.MoveTo(dgvCompra.Table.Records.Count - 1, 5, GridSetCurrentCellOptions.SetFocus)
    '                    'dgvCompra.Focus()
    '                    'dgvCompra.TableControl.CurrentCell.BeginEdit()

    '                    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent("cantidad")
    '                    dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetValue("cantidad", CDec(cantidad))
    '                    Calculos()

    '                Else
    '                    MessageBox.Show("Ingrese una cantidad válida!", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Return
    '                End If
    '            Else
    '                MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            End If

    '        End If


    '        'If GridGroupingControl2.Table.Records.Count > 0 Then
    '        '    GridGroupingControl2.Table.Records(0).SetCurrent()
    '        '    GridGroupingControl2.Table.Records(0).SetSelected(True)


    '        '    ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
    '        '    AgregarAcanasta(gridGroupingControl1.Table.CurrentRecord)

    '        'Else

    '        'End If
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        PanelError.Visible = True
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End Try
    'End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        f.StartPosition = FormStartPosition.CenterParent
        'f.rbJuridico.Checked = True
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, entidad)
            txtCliente2.Text = c.nombreCompleto
            txtRuc2.Text = c.nrodoc
            txtCliente2.Tag = c.idEntidad
            txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellChanging

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
        f.CaptionLabels(0).Text = "Clientes"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, entidad)
            'Dim c = CType(f.Tag, entidad)
            txtCliente2.Text = c.nombreCompleto
            txtCliente2.Tag = c.idEntidad
            txtRuc2.Text = c.nrodoc
            txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub txtRuc2_TextChanged(sender As Object, e As EventArgs) Handles txtRuc2.TextChanged

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"
                    Dim r As Record = dgvCompra.Table.CurrentRecord

                    If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

                    Else
                        cc.ConfirmChanges()
                        cc.EndEdit()

                    End If
                    Calculos()

                    'End Select
                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Calculos()
            End Select
        End If

    End Sub

    Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"
                    Dim r As Record = dgvCompra.Table.CurrentRecord

                    If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

                    Else
                        cc.ConfirmChanges()
                        cc.EndEdit()

                    End If
                    Calculos()

                    'End Select
                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Calculos()
            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlKeyPress
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"
                    Dim r As Record = dgvCompra.Table.CurrentRecord

                    If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

                    Else
                        cc.ConfirmChanges()
                        cc.EndEdit()

                    End If
                    Calculos()

                    'End Select
                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Calculos()
            End Select
        End If
    End Sub

    Private Sub dgvCompra_TableControlLeftColChanged(sender As Object, e As GridTableControlRowColIndexChangedEventArgs) Handles dgvCompra.TableControlLeftColChanged

    End Sub

    Private Sub dgvCompra_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyUp
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        Select Case Int32.Parse(r.GetValue("cboprecio"))
                            Case 0
                                'Dim f As New frmPreciosByArticulos(r)
                                'f.StartPosition = FormStartPosition.CenterParent
                                'f.ShowDialog()

                            Case Else
                                precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                If Not IsNothing(precio) Then
                                    r.SetValue("pumn", precio.precioMN)
                                    r.SetValue("pume", precio.precioME)
                                    Calculos()
                                Else
                                    MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    r.SetValue("pumn", 0)
                                    r.SetValue("pume", 0)
                                    Calculos()
                                End If
                        End Select

                    Else

                    End If



                Case 7 ' cantidad
                    'Select Case strTipoEx
                    'Case "GS"
                    Dim r As Record = dgvCompra.Table.CurrentRecord

                    If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

                    Else
                        cc.ConfirmChanges()
                        cc.EndEdit()

                    End If
                    Calculos()

                    'End Select
                Case 8
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Calculos()
            End Select
        End If
    End Sub

    Private Sub GridDataBoundGrid1_CellClick(sender As Object, e As GridCellClickEventArgs) Handles GridDataBoundGrid1.CellClick
        Cursor = Cursors.WaitCursor
        If e.RowIndex <> 0 Then
            GridGroupingControl2.Table.Records.DeleteAll()
            UbicarUltimosPreciosXproducto()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        If GridDataBoundGrid1.Binder.RecordCount > 0 Then
            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 1
                    Dim f As New frmNuevoPrecio
                    f.txtProducto.Tag = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem")
                    f.txtProducto.Text = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "descripcion")
                    f.txtGrav.Text = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "destino")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case Else
                    MessageBox.Show("No tiene derechos de administrador, para realizar está tarea", "No autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
        End If
    End Sub

    Private Sub GridDataBoundGrid1_CellButtonClicked(sender As Object, e As GridCellButtonClickedEventArgs) Handles GridDataBoundGrid1.CellButtonClicked
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim intSelectedRow = GridDataBoundGrid1.Selections.Ranges.ActiveRange.Top
        Try
            If e.RowIndex <> 0 Then
                Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", e.RowIndex))
                If listaPrecios.Count > 0 Then
                    Dim cantidad = InputBox("Ingrese cantidad a vender", "Stock disponible: " & MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad", e.RowIndex), "")
                    If IsNumeric(cantidad) Then
                        If cantidad <= 0 Then
                            MessageBox.Show("La cantidad ingresada debe ser mayor a cero!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                            Cursor = Cursors.Default
                        End If

                        'If cantidad <= 0 Then
                        '    MessageBox.Show("La cantidad ingresada no debe ser mayor a cero!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Exit Sub
                        '    Cursor = Cursors.Default
                        'End If

                        If (CDec(cantidad) > CDec(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "cantidad", e.RowIndex))) Then
                            MessageBox.Show("La cantidad ingresada no debe exceder la disponible!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                            Cursor = Cursors.Default
                        End If


                        ValidarStockDisponible(Integer.Parse(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idItem", e.RowIndex)),
                                              Integer.Parse(MetodosGenericos.GetCellValue(GridDataBoundGrid1, "idalmacen", e.RowIndex)),
                                               cantidad)
                        '    ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
                        AgregarAcanastaCodigoBarra_Index(listaPrecios(0), e.RowIndex)
                        GridDataBoundGrid1.Focus()
                        GridDataBoundGrid1.Model.Rows.MoveRange(intSelectedRow, e.RowIndex, e.RowIndex)

                        dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent("cantidad")
                        dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetValue("cantidad", CDec(cantidad))
                        Calculos()
                        ConteoLabelVentas()
                        txtFiltrar.Select()
                        txtFiltrar.Focus()
                        txtFiltrar.SelectAll()
                    Else
                        MessageBox.Show("Ingrese una cantidad válida!", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                Else
                    MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Dim s As String = String.Format("You clicked ({0},{1}).", e.RowIndex, e.ColIndex)
        'Dim s As String = MetodosGenericos.GetCellValue(GridDataBoundGrid1, "descripcion", e.RowIndex)

        'MessageBox.Show(s)
    End Sub

    Private Sub ValidarStockDisponible(iditem As Integer, idAlmacen As Integer, cantidadSalida As Decimal)
        Dim cantidadVenta As Decimal = 0
        Dim articulo = InventarioSA.ObtenerCanDisponibleProduct(New totalesAlmacen With {.idItem = iditem, .idAlmacen = idAlmacen})

        For Each i In dgvCompra.Table.Records
            If articulo IsNot Nothing Then
                If Integer.Parse(i.GetValue("idProducto")) = articulo.idItem AndAlso
                        Integer.Parse(i.GetValue("almacen")) = articulo.idAlmacen Then

                    cantidadVenta += Decimal.Parse(i.GetValue("cantidad"))

                    '
                End If
            End If
        Next
        cantidadVenta = cantidadVenta + cantidadSalida
        If cantidadVenta > articulo.cantidad Then
            Throw New Exception("El producto a ingresar no tiene stock disponible!")
        End If
    End Sub

    Private Function ArticuloStockDisponible(iditem As Integer, idAlmacen As Integer) As Boolean
        Dim cantidadVenta As Decimal = 0
        Dim articulo = InventarioSA.ObtenerCanDisponibleProduct(New totalesAlmacen With {.idItem = iditem, .idAlmacen = idAlmacen})

        For Each i In dgvCompra.Table.Records
            If articulo IsNot Nothing Then
                If Integer.Parse(i.GetValue("idProducto")) = articulo.idItem AndAlso
                        Integer.Parse(i.GetValue("almacen")) = articulo.idAlmacen Then

                    cantidadVenta += Decimal.Parse(i.GetValue("cantidad"))

                    '
                End If
            End If
        Next
        cantidadVenta = cantidadVenta
        If cantidadVenta > articulo.cantidad Then
            ArticuloStockDisponible = False
        Else
            ArticuloStockDisponible = True
        End If
    End Function

    Private Sub dgvServicios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvServicios.TableControlCellClick
        Cursor = Cursors.WaitCursor
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim totalSA As New TotalesAlmacenSA
        Try


            '   If gridGroupingControl1.Table.Records.Count > 0 Then
            Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, dgvServicios.Table.CurrentRecord.GetValue("idServicio"))

            If listaPrecios.Count > 0 Then
                'ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
                AgregarAcanastaServicvioCodigoBarra(dgvServicios.Table.CurrentRecord, listaPrecios(0))
            Else
                MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvServicios_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvServicios.TableControlCellDoubleClick
        Cursor = Cursors.WaitCursor
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim totalSA As New TotalesAlmacenSA
        Try


            '   If gridGroupingControl1.Table.Records.Count > 0 Then
            Dim listaPrecios = precioSA.ListarPreciosXproductoMaxFecha(0, dgvServicios.Table.CurrentRecord.GetValue("idServicio"))

            If listaPrecios.Count > 0 Then
                'ValidarItemsDuplicados(Val(gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))
                AgregarAcanastaServicvioCodigoBarra(dgvServicios.Table.CurrentRecord, listaPrecios(0))
            Else
                MessageBox.Show("El artículo no tiene configurado ningún precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub
End Class


